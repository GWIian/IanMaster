using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using Common;

namespace MasterClient
{
    class HandleXMsg
    {
        /// <summary>
        /// 关机
        /// </summary>
        public static void Shutdown()
        {
            Process pro = new Process();
            pro.StartInfo.FileName = "shutdown.exe";
            pro.StartInfo.Arguments = "-s -t 0";//延时时间为0（马上关机）
            pro.StartInfo.UseShellExecute = false;//不使用操作系统外壳程序启动进程
            pro.StartInfo.CreateNoWindow = true;//不创建窗体
            pro.StartInfo.RedirectStandardOutput = true;
            pro.Start();
        }

        //重启
        public static void Restart()
        {
            Process pro = new Process();
            pro.StartInfo.FileName = "shutdown.exe";
            pro.StartInfo.Arguments = "-r -t 0";//延时时间为0（马上关机）
            pro.StartInfo.UseShellExecute = false;//不使用操作系统外壳程序启动进程
            pro.StartInfo.CreateNoWindow = true;//不创建窗体
            pro.StartInfo.RedirectStandardOutput = true;
            pro.Start();
        }

        /// <summary>
        /// 执行cmd
        /// </summary>
        /// <param name="cmd"></param>
        public static void Cmd(XMessage xmsg)
        {
            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.UseShellExecute = false;//不使用操作系统外壳程序启动进程
            pro.StartInfo.CreateNoWindow = true;//不创建窗体
            //重定向标准输入
            pro.StartInfo.RedirectStandardInput = true;
            //重定向标准输出
            pro.StartInfo.RedirectStandardOutput = true;
            //重定向错误输出
            pro.StartInfo.RedirectStandardError = true;
            pro.Start();
            pro.StandardInput.WriteLine(xmsg.Params["Content"]);
            pro.StandardInput.WriteLine("exit");
            pro.WaitForExit();

            string output = pro.StandardOutput.ReadToEnd();
            string error = pro.StandardError.ReadToEnd();

            if (output != "")
            {
                Client.Msg(output);
            }
            if (error != "")
            {
                Client.Msg(error);
            }
        }
    }
}
