using System;
using System.Windows.Forms;

namespace MasterServer
{
    public partial class MainWin : Form
    {
        public static MainWin ServerHandle;

        public MainWin()
        {
            InitializeComponent();
        }

        //窗体载入
        private void MainWin_Load(object sender, EventArgs e)
        {
            Config.LoadConfig();
            this.Text += " Version: " + Config.Version;
            Control.CheckForIllegalCrossThreadCalls = false;
            ServerHandle = this;
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        public void Exit()
        {
            Application.Exit();
        }

        //退出程序 菜单点击
        private void miExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        //窗体显示
        private void MainWin_Shown(object sender, EventArgs e)
        {
            slStatus.Text = "正在启动服务...";
            if (Server.Start() == 0)
            {
                slStatus.Text = "服务启动成功，设备将会在接下来的时间内接入。";
            }
            else
            {
                slStatus.Text = "服务启动失败，请查看日志。";
            }
        }

        //窗体正在关闭
        private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            slStatus.Text = "关闭服务...";
            Server.Stop();
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            object dev = lsbDevice.SelectedItem;
            if (dev != null)
            {
                Server.Shutdown(int.Parse(dev.ToString().Split('@')[1]));
                txbConsole.AppendText("向" + dev.ToString() + "的关机命令已发送。\n");
            }
            
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            object dev = lsbDevice.SelectedItem;
            if (dev != null)
            {
                Server.Restart(int.Parse(dev.ToString().Split('@')[1]));
                txbConsole.AppendText("向" + dev.ToString() + "的重启命令已发送。\n");
            }
            
        }

        private void btnCmd_Click(object sender, EventArgs e)
        {
            object dev = lsbDevice.SelectedItem;
            if (dev != null)
            {
                Server.Cmd(int.Parse(dev.ToString().Split('@')[1]), txbCmd.Text);
                txbConsole.AppendText("向" + dev.ToString() + "的Cmd命令已发送。\n");
            }
            
        }
    }
}
