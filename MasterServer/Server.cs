using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Text;
using Common;

namespace MasterServer
{
    public class Server
    {
        /// <summary>
        /// 已连接的客户端列表
        /// </summary>
        private static Dictionary<int, TcpClient> clientList;

        /// <summary>
        /// 已连接的客户端名称列表
        /// </summary>
        public static Dictionary<int, string> clientNameList;

        /// <summary>
        /// 服务器监听器实例
        /// </summary>
        private static TcpListener server;

        /// <summary>
        /// 客户端ID计数器
        /// </summary>
        private static int clientId;

        #region 循环控制标志
        /// <summary>
        /// 等待连接标志
        /// </summary>
        private static bool FL_WAITCONNECTION;
        #endregion

        /// <summary>
        /// 启动服务器
        /// </summary>
        public static int Start()
        {
            clientList = new Dictionary<int, TcpClient>();
            clientNameList = new Dictionary<int, string>();

            IPAddress ip = IPAddress.Parse(Config.Listen);
            try
            {
                int port = int.Parse(Config.Port);
                int maxConn = int.Parse(Config.MaxConnection);
                server = new TcpListener(ip, port);
                server.Start(maxConn);

                FL_WAITCONNECTION = true;
                clientId = 0;
                new Thread(WaitConnectionLoop).Start();//进入连接等待循环

                return 0;
            }
            catch (Exception e)
            {
                Common.Log.WriteLog("Server.Start", e.Message);
                return -1;
            }
        }

        /// <summary>
        /// 关闭服务器
        /// </summary>
        public static void Stop()
        {
            try
            {
                #region 关闭标志
                FL_WAITCONNECTION = false;
                #endregion

                foreach (KeyValuePair<int, TcpClient> x in clientList)//关闭所有的终端连接
                {
                    x.Value.Close();
                }
                server.Stop();
            }
            catch (Exception e)
            {
                Common.Log.WriteLog("Server.Stop", e.Message);
            }
        }

        /// <summary>
        /// 等待终端连接循环
        /// </summary>
        private static void WaitConnectionLoop()
        {
            TcpClient newClient;
            while (FL_WAITCONNECTION)
            {
                try
                {
                    newClient = server.AcceptTcpClient();
                    clientList.Add(++clientId, newClient);
                    new Thread(StartMessageLoop).Start(clientId);
                }
                catch (Exception) { }
            }
        }

        public static bool IsOnline(TcpClient c)
        {
            try
            {
                return !((c.Client.Poll(1000, SelectMode.SelectRead) && (c.Client.Available == 0)) || !c.Client.Connected);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// 进入CS tcp消息循环
        /// </summary>
        /// <param name="cid">tcp连接的id</param>
        private static void StartMessageLoop(object cid)
        {
            int cid_i = (int)cid;
            NetworkStream nStream = clientList[(int)cid].GetStream();
            byte[] buffer = new byte[4096];
            StringBuilder sbbuffer = new StringBuilder();
            int read;
            while (true)
            {
                if (IsOnline(clientList[(int)cid]))
                {
                    if (nStream.CanRead)
                    {
                        while (nStream.DataAvailable)
                        {
                            read = nStream.Read(buffer, 0, buffer.Length);
                            sbbuffer.Append(Encoding.Unicode.GetString(buffer, 0, read));
                            if (!nStream.DataAvailable)
                            {
                                HandleMessage(sbbuffer.ToString(),(int)cid);
                                sbbuffer = new StringBuilder();
                            }
                        }

                    }
                }
                else
                {
                    HandleXMsg.Logout((int)cid);
                    break;
                }
            }
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="cid"></param>
        private static void HandleMessage(string msg,int cid)
        {
            XMessage xmsg = new XMessage(msg);
            switch (xmsg.Type)
            {
                case "Login":
                    HandleXMsg.Login(xmsg,cid);
                    break;
                case "Msg":
                    HandleXMsg.Msg(xmsg, cid);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 关机
        /// </summary>
        public static void Shutdown(int cid)
        {
            NetworkStream nStream = clientList[cid].GetStream();
            XMessage msg = new XMessage();
            msg.Type = "Shutdown";
            //msg.AddParam("DeviceId", Config.DeviceId);
            byte[] buffer = Encoding.Unicode.GetBytes(msg.Raw);
            nStream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 重启
        /// </summary>
        public static void Restart(int cid)
        {
            NetworkStream nStream = clientList[cid].GetStream();
            XMessage msg = new XMessage();
            msg.Type = "Restart";
            //msg.AddParam("DeviceId", Config.DeviceId);
            byte[] buffer = Encoding.Unicode.GetBytes(msg.Raw);
            nStream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 发送cmd
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="cmd"></param>
        public static void Cmd(int cid, string cmd)
        {
            NetworkStream nStream = clientList[cid].GetStream();
            XMessage msg = new XMessage();
            msg.Type = "Cmd";
            msg.AddParam("Content", cmd);
            byte[] buffer = Encoding.Unicode.GetBytes(msg.Raw);
            nStream.Write(buffer, 0, buffer.Length);
        }
    }
}
