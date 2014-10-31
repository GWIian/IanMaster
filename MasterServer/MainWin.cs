using System;
using System.Windows.Forms;

namespace MasterServer
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
        }

        //窗体载入
        private void MainWin_Load(object sender, EventArgs e)
        {
            Config.LoadConfig();
            this.Text += " Version: " + Config.Version;
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        private void Exit()
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
    }
}
