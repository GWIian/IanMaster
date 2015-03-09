using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Common;


namespace MasterClient
{
    class Client
    {
        private static TcpClient client;

        /// <summary>
        /// 启动客户端
        /// </summary>
        public static void Start()
        {
            IPAddress ip = IPAddress.Parse(Config.Ip);
            int port = int.Parse(Config.Port);
            client = new TcpClient();
            while (true)
            {
                try
                {
                    client.Connect(ip, port);
                    Login();
                    StartMessageLoop();
                }
                catch (SocketException e)
                {
                    Common.Log.WriteLog("Client.Start", e.Message);
                    Thread.Sleep(5000);
                }
                catch (InvalidOperationException e)
                {
                    Common.Log.WriteLog("Client.Start", e.Message);
                    Thread.Sleep(5000);
                    client = new TcpClient();
                }
            }
        }

        /// <summary>
        /// 向服务端发送登录
        /// </summary>
        public static void Login()
        {
            NetworkStream nStream = client.GetStream();
            XMessage msg = new XMessage();
            msg.Type = "Login";
            msg.AddParam("DeviceId", Config.DeviceId);
            byte[] buffer = Encoding.Unicode.GetBytes(msg.Raw);
            nStream.Write(buffer, 0, buffer.Length);
        }



        /// <summary>
        /// 判断连接状态
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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
        /// 进入消息循环
        /// </summary>
        public static void StartMessageLoop()
        {
            NetworkStream nStream = client.GetStream();
            byte[] buffer = new byte[4096];
            StringBuilder sbbuffer = new StringBuilder();
            int read;
            while (true)
            {

                if (IsOnline(client))
                {
                    if (nStream.CanRead)
                    {
                        while (nStream.DataAvailable)
                        {
                            read = nStream.Read(buffer, 0, buffer.Length);
                            sbbuffer.Append(Encoding.Unicode.GetString(buffer, 0, read));
                            if (!nStream.DataAvailable)
                            {
                                HandleMessage(sbbuffer.ToString());
                                sbbuffer = new StringBuilder();
                            }
                        }

                    }
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="cid"></param>
        private static void HandleMessage(string msg)
        {
            XMessage xmsg = new XMessage(msg);
            switch (xmsg.Type)
            {
                case "Shutdown":
                    HandleXMsg.Shutdown();
                    break;
                case "Restart":
                    HandleXMsg.Restart();
                    break;
                case "Cmd":
                    HandleXMsg.Cmd(xmsg);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 向服务端发送消息
        /// </summary>
        public static void Msg(string text)
        {
            NetworkStream nStream = client.GetStream();
            XMessage msg = new XMessage();
            msg.Type = "Msg";
            text = Util.EncodingText(text);
            msg.AddParam("Text", text);
            byte[] buffer = Encoding.Unicode.GetBytes(msg.Raw);
            nStream.Write(buffer, 0, buffer.Length);
        }
    }
}
