using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System;
using System.Threading;

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
        private static Dictionary<int, string> clientNameList;

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
                Log.WriteLog("Server.Start", e.Message);
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
                Log.WriteLog("Server.Stop", e.Message);
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

        /// <summary>
        /// 进入CS tcp消息循环
        /// </summary>
        /// <param name="cid">tcp连接的id</param>
        private static void StartMessageLoop(object cid)
        {
            int cid_i = (int)cid;
            NetworkStream nStream = clientList[cid_i].GetStream();
        }
    }
}
