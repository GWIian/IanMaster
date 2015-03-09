using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Windows.Forms;
using System.Drawing;

namespace MasterServer
{
    class HandleXMsg
    {
        //15111466812
        /// <summary>
        /// 客户端登陆
        /// </summary>
        /// <param name="xmsg"></param>
        public static void Login(XMessage xmsg, int cid)
        {
            MainWin.ServerHandle.lsbDevice.Items.Add(xmsg.Params["DeviceId"] + "@" + cid);
            Server.clientNameList.Add(cid, xmsg.Params["DeviceId"]);
        }

        public static void Logout(int cid)
        {
            foreach (string x in MainWin.ServerHandle.lsbDevice.Items)
            {
                if (x.Split('@')[1] == cid.ToString())
                {
                    MainWin.ServerHandle.lsbDevice.Items.Remove(x);
                    Server.clientNameList.Remove(cid);
                    break;
                }
            }
        }

        public static void Msg(XMessage xmsg, int cid)
        {
            MainWin.ServerHandle.txbConsole.AppendText("------------------------------------------\n");
            MainWin.ServerHandle.txbConsole.AppendText(Server.clientNameList[cid] + "回复消息：\n");
            MainWin.ServerHandle.txbConsole.AppendText(Util.DecodingText(xmsg.Params["Text"]) + "\n");
        }
    }
}
