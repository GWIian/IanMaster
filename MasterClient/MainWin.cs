using System;
using System.Windows.Forms;

namespace MasterClient
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
        }

        //窗体->载入
        private void MainWin_Load(object sender, EventArgs e)
        {
            this.Hide();//应用程序没有显式窗口
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

    }
}
