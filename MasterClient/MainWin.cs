using System;
using System.Windows.Forms;
using System.Threading;

namespace MasterClient
{
    public partial class MainWin : Form
    {
        private Thread trdClient;

        public static MainWin ClientHandle;

        public MainWin()
        {
            InitializeComponent();
        }

        //窗体->载入
        private void MainWin_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            ClientHandle = this;
            this.Hide();//应用程序没有显式窗口
            Config.LoadConfig();//载入配置文件
            trdClient = new Thread(Client.Start);
            trdClient.Start();//启动客户端
        }

        //菜单->退出
        private void miExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //菜单->关于
        private void miAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("IanMaster Remote Tool Client.");
        }

        private void MainWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            trdClient.Abort();
        }

    }
}
