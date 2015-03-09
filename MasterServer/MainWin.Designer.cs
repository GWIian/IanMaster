namespace MasterServer
{
    partial class MainWin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.miExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lsbDevice = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnShutdown = new System.Windows.Forms.Button();
            this.txbConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.slStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txbCmd = new System.Windows.Forms.TextBox();
            this.btnCmd = new System.Windows.Forms.Button();
            this.msMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ssMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExit});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(592, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "menuStrip1";
            // 
            // miExit
            // 
            this.miExit.Name = "miExit";
            this.miExit.Size = new System.Drawing.Size(65, 20);
            this.miExit.Text = "退出程序";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // lsbDevice
            // 
            this.lsbDevice.FormattingEnabled = true;
            this.lsbDevice.ItemHeight = 12;
            this.lsbDevice.Location = new System.Drawing.Point(12, 64);
            this.lsbDevice.Name = "lsbDevice";
            this.lsbDevice.Size = new System.Drawing.Size(120, 292);
            this.lsbDevice.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCmd);
            this.groupBox1.Controls.Add(this.txbCmd);
            this.groupBox1.Controls.Add(this.btnRestart);
            this.groupBox1.Controls.Add(this.btnShutdown);
            this.groupBox1.Location = new System.Drawing.Point(171, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作";
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(86, 71);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 1;
            this.btnRestart.Text = "重启";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnShutdown
            // 
            this.btnShutdown.Location = new System.Drawing.Point(6, 71);
            this.btnShutdown.Name = "btnShutdown";
            this.btnShutdown.Size = new System.Drawing.Size(75, 23);
            this.btnShutdown.TabIndex = 0;
            this.btnShutdown.Text = "关机";
            this.btnShutdown.UseVisualStyleBackColor = true;
            this.btnShutdown.Click += new System.EventHandler(this.btnShutdown_Click);
            // 
            // txbConsole
            // 
            this.txbConsole.BackColor = System.Drawing.Color.Black;
            this.txbConsole.ForeColor = System.Drawing.Color.White;
            this.txbConsole.Location = new System.Drawing.Point(170, 159);
            this.txbConsole.Multiline = true;
            this.txbConsole.Name = "txbConsole";
            this.txbConsole.ReadOnly = true;
            this.txbConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txbConsole.Size = new System.Drawing.Size(409, 197);
            this.txbConsole.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "在线设备：";
            // 
            // ssMain
            // 
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slStatus});
            this.ssMain.Location = new System.Drawing.Point(0, 374);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(592, 22);
            this.ssMain.TabIndex = 5;
            this.ssMain.Text = "statusStrip1";
            // 
            // slStatus
            // 
            this.slStatus.Name = "slStatus";
            this.slStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // txbCmd
            // 
            this.txbCmd.Location = new System.Drawing.Point(6, 16);
            this.txbCmd.Name = "txbCmd";
            this.txbCmd.Size = new System.Drawing.Size(317, 21);
            this.txbCmd.TabIndex = 2;
            // 
            // btnCmd
            // 
            this.btnCmd.Location = new System.Drawing.Point(329, 14);
            this.btnCmd.Name = "btnCmd";
            this.btnCmd.Size = new System.Drawing.Size(75, 23);
            this.btnCmd.TabIndex = 3;
            this.btnCmd.Text = "发送cmd";
            this.btnCmd.UseVisualStyleBackColor = true;
            this.btnCmd.Click += new System.EventHandler(this.btnCmd_Click);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 396);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbConsole);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lsbDevice);
            this.Controls.Add(this.msMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMain;
            this.MaximizeBox = false;
            this.Name = "MainWin";
            this.Text = "IanMaster Remote Tool";
            this.Load += new System.EventHandler(this.MainWin_Load);
            this.Shown += new System.EventHandler(this.MainWin_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWin_FormClosing);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem miExit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.ToolStripStatusLabel slStatus;
        public System.Windows.Forms.ListBox lsbDevice;
        private System.Windows.Forms.Button btnShutdown;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnCmd;
        private System.Windows.Forms.TextBox txbCmd;
        public System.Windows.Forms.TextBox txbConsole;
    }
}

