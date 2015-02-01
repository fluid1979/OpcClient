namespace OPCDialog
{
    partial class OPCClient
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRemoteServerIP = new System.Windows.Forms.MaskedTextBox();
            this.cmbServerName = new System.Windows.Forms.ComboBox();
            this.btnConnLocalServer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTimeStamps = new System.Windows.Forms.TextBox();
            this.txtQualities = new System.Windows.Forms.TextBox();
            this.txtTagValue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnBegin = new System.Windows.Forms.Button();
            this.bt_saveList = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSetGroupPro = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_biasTime = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUpdateRate = new System.Windows.Forms.TextBox();
            this.txtIsSubscribed = new System.Windows.Forms.TextBox();
            this.txtIsActive = new System.Windows.Forms.TextBox();
            this.txtGroupDeadband = new System.Windows.Forms.TextBox();
            this.txtGroupIsActive = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslServerState = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslServerStartTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslversion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool_state = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblState = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.bt_add = new System.Windows.Forms.Button();
            this.bt_remove = new System.Windows.Forms.Button();
            this.lb_info = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.opcreaderlogin = new System.Windows.Forms.ComboBox();
            this.bt_login = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtRemoteServerIP);
            this.groupBox1.Controls.Add(this.cmbServerName);
            this.groupBox1.Controls.Add(this.btnConnLocalServer);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 130);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(354, 208);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接OPC服务器";
            // 
            // txtRemoteServerIP
            // 
            this.txtRemoteServerIP.Location = new System.Drawing.Point(136, 26);
            this.txtRemoteServerIP.Margin = new System.Windows.Forms.Padding(6);
            this.txtRemoteServerIP.Name = "txtRemoteServerIP";
            this.txtRemoteServerIP.Size = new System.Drawing.Size(196, 35);
            this.txtRemoteServerIP.TabIndex = 4;
            this.txtRemoteServerIP.Visible = false;
            // 
            // cmbServerName
            // 
            this.cmbServerName.FormattingEnabled = true;
            this.cmbServerName.Location = new System.Drawing.Point(134, 102);
            this.cmbServerName.Margin = new System.Windows.Forms.Padding(6);
            this.cmbServerName.Name = "cmbServerName";
            this.cmbServerName.Size = new System.Drawing.Size(196, 32);
            this.cmbServerName.TabIndex = 3;
            // 
            // btnConnLocalServer
            // 
            this.btnConnLocalServer.Enabled = false;
            this.btnConnLocalServer.Location = new System.Drawing.Point(184, 154);
            this.btnConnLocalServer.Margin = new System.Windows.Forms.Padding(6);
            this.btnConnLocalServer.Name = "btnConnLocalServer";
            this.btnConnLocalServer.Size = new System.Drawing.Size(150, 46);
            this.btnConnLocalServer.TabIndex = 2;
            this.btnConnLocalServer.Text = "连接";
            this.btnConnLocalServer.UseVisualStyleBackColor = true;
            this.btnConnLocalServer.Click += new System.EventHandler(this.btnConnLocalServer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "服务器：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTimeStamps);
            this.groupBox3.Controls.Add(this.txtQualities);
            this.groupBox3.Controls.Add(this.txtTagValue);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(1432, 130);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(382, 236);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "当前值";
            // 
            // txtTimeStamps
            // 
            this.txtTimeStamps.Location = new System.Drawing.Point(96, 162);
            this.txtTimeStamps.Margin = new System.Windows.Forms.Padding(6);
            this.txtTimeStamps.Name = "txtTimeStamps";
            this.txtTimeStamps.Size = new System.Drawing.Size(249, 35);
            this.txtTimeStamps.TabIndex = 5;
            // 
            // txtQualities
            // 
            this.txtQualities.Location = new System.Drawing.Point(96, 102);
            this.txtQualities.Margin = new System.Windows.Forms.Padding(6);
            this.txtQualities.Name = "txtQualities";
            this.txtQualities.Size = new System.Drawing.Size(249, 35);
            this.txtQualities.TabIndex = 4;
            // 
            // txtTagValue
            // 
            this.txtTagValue.Location = new System.Drawing.Point(96, 40);
            this.txtTagValue.Margin = new System.Windows.Forms.Padding(6);
            this.txtTagValue.Name = "txtTagValue";
            this.txtTagValue.Size = new System.Drawing.Size(249, 35);
            this.txtTagValue.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 168);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "时间戳";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 110);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "品质:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 46);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tag值:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnBegin);
            this.groupBox4.Controls.Add(this.bt_saveList);
            this.groupBox4.Controls.Add(this.btnStop);
            this.groupBox4.Location = new System.Drawing.Point(1432, 403);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox4.Size = new System.Drawing.Size(382, 265);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "控制面板";
            // 
            // btnBegin
            // 
            this.btnBegin.Enabled = false;
            this.btnBegin.Location = new System.Drawing.Point(72, 54);
            this.btnBegin.Margin = new System.Windows.Forms.Padding(6);
            this.btnBegin.Name = "btnBegin";
            this.btnBegin.Size = new System.Drawing.Size(140, 46);
            this.btnBegin.TabIndex = 17;
            this.btnBegin.Text = "开始";
            this.btnBegin.UseVisualStyleBackColor = true;
            this.btnBegin.Click += new System.EventHandler(this.btnBegin_Click);
            // 
            // bt_saveList
            // 
            this.bt_saveList.Enabled = false;
            this.bt_saveList.Location = new System.Drawing.Point(72, 204);
            this.bt_saveList.Name = "bt_saveList";
            this.bt_saveList.Size = new System.Drawing.Size(140, 46);
            this.bt_saveList.TabIndex = 18;
            this.bt_saveList.Text = "保存列表";
            this.bt_saveList.UseVisualStyleBackColor = true;
            this.bt_saveList.Click += new System.EventHandler(this.bt_saveList_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(72, 129);
            this.btnStop.Margin = new System.Windows.Forms.Padding(6);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(140, 46);
            this.btnStop.TabIndex = 12;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(120, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "默认组锁区：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 132);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 25);
            this.label7.TabIndex = 2;
            this.label7.Text = "是否激活：";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(142, 180);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 25);
            this.label8.TabIndex = 3;
            this.label8.Text = "是否订阅：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 230);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 25);
            this.label9.TabIndex = 4;
            this.label9.Text = "刷新频率（秒）：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(122, 44);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "激活默认组：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSetGroupPro
            // 
            this.btnSetGroupPro.Location = new System.Drawing.Point(179, 319);
            this.btnSetGroupPro.Margin = new System.Windows.Forms.Padding(6);
            this.btnSetGroupPro.Name = "btnSetGroupPro";
            this.btnSetGroupPro.Size = new System.Drawing.Size(150, 46);
            this.btnSetGroupPro.TabIndex = 4;
            this.btnSetGroupPro.Text = "设置";
            this.btnSetGroupPro.UseVisualStyleBackColor = true;
            this.btnSetGroupPro.Click += new System.EventHandler(this.btnSetGroupPro_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_biasTime);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtUpdateRate);
            this.groupBox2.Controls.Add(this.txtIsSubscribed);
            this.groupBox2.Controls.Add(this.txtIsActive);
            this.groupBox2.Controls.Add(this.txtGroupDeadband);
            this.groupBox2.Controls.Add(this.txtGroupIsActive);
            this.groupBox2.Controls.Add(this.btnSetGroupPro);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(20, 350);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(352, 381);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "更改组属性";
            // 
            // txt_biasTime
            // 
            this.txt_biasTime.Location = new System.Drawing.Point(266, 272);
            this.txt_biasTime.Margin = new System.Windows.Forms.Padding(6);
            this.txt_biasTime.Name = "txt_biasTime";
            this.txt_biasTime.Size = new System.Drawing.Size(60, 35);
            this.txt_biasTime.TabIndex = 12;
            this.txt_biasTime.Text = "8";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 279);
            this.label14.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(251, 25);
            this.label14.TabIndex = 11;
            this.label14.Text = "系统偏移时间(小时):";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUpdateRate
            // 
            this.txtUpdateRate.Location = new System.Drawing.Point(268, 224);
            this.txtUpdateRate.Margin = new System.Windows.Forms.Padding(6);
            this.txtUpdateRate.Name = "txtUpdateRate";
            this.txtUpdateRate.Size = new System.Drawing.Size(60, 35);
            this.txtUpdateRate.TabIndex = 10;
            this.txtUpdateRate.Text = "180";
            // 
            // txtIsSubscribed
            // 
            this.txtIsSubscribed.Location = new System.Drawing.Point(268, 176);
            this.txtIsSubscribed.Margin = new System.Windows.Forms.Padding(6);
            this.txtIsSubscribed.Name = "txtIsSubscribed";
            this.txtIsSubscribed.Size = new System.Drawing.Size(60, 35);
            this.txtIsSubscribed.TabIndex = 9;
            this.txtIsSubscribed.Text = "true";
            // 
            // txtIsActive
            // 
            this.txtIsActive.Location = new System.Drawing.Point(268, 128);
            this.txtIsActive.Margin = new System.Windows.Forms.Padding(6);
            this.txtIsActive.Name = "txtIsActive";
            this.txtIsActive.Size = new System.Drawing.Size(60, 35);
            this.txtIsActive.TabIndex = 8;
            this.txtIsActive.Text = "true";
            // 
            // txtGroupDeadband
            // 
            this.txtGroupDeadband.Location = new System.Drawing.Point(268, 80);
            this.txtGroupDeadband.Margin = new System.Windows.Forms.Padding(6);
            this.txtGroupDeadband.Name = "txtGroupDeadband";
            this.txtGroupDeadband.Size = new System.Drawing.Size(60, 35);
            this.txtGroupDeadband.TabIndex = 7;
            this.txtGroupDeadband.Text = "0";
            // 
            // txtGroupIsActive
            // 
            this.txtGroupIsActive.Location = new System.Drawing.Point(268, 32);
            this.txtGroupIsActive.Margin = new System.Windows.Forms.Padding(6);
            this.txtGroupIsActive.Name = "txtGroupIsActive";
            this.txtGroupIsActive.Size = new System.Drawing.Size(60, 35);
            this.txtGroupIsActive.TabIndex = 6;
            this.txtGroupIsActive.Text = "true";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslServerState,
            this.tsslServerStartTime,
            this.tsslversion,
            this.tool_state});
            this.statusStrip1.Location = new System.Drawing.Point(0, 856);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 28, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1856, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslServerState
            // 
            this.tsslServerState.Name = "tsslServerState";
            this.tsslServerState.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslServerStartTime
            // 
            this.tsslServerStartTime.Name = "tsslServerStartTime";
            this.tsslServerStartTime.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslversion
            // 
            this.tsslversion.Name = "tsslversion";
            this.tsslversion.Size = new System.Drawing.Size(0, 17);
            // 
            // tool_state
            // 
            this.tool_state.Name = "tool_state";
            this.tool_state.Size = new System.Drawing.Size(0, 17);
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(1008, 540);
            this.lblState.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(0, 25);
            this.lblState.TabIndex = 14;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(24, 28);
            this.listBox1.Margin = new System.Windows.Forms.Padding(6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(360, 556);
            this.listBox1.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.listBox1);
            this.groupBox5.Location = new System.Drawing.Point(392, 130);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(407, 601);
            this.groupBox5.TabIndex = 15;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "待选列表";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listBox2);
            this.groupBox6.Location = new System.Drawing.Point(968, 130);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(407, 601);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "已选列表";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 24;
            this.listBox2.Location = new System.Drawing.Point(24, 28);
            this.listBox2.Margin = new System.Windows.Forms.Padding(6);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(360, 556);
            this.listBox2.TabIndex = 3;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // bt_add
            // 
            this.bt_add.Location = new System.Drawing.Point(838, 320);
            this.bt_add.Name = "bt_add";
            this.bt_add.Size = new System.Drawing.Size(75, 46);
            this.bt_add.TabIndex = 17;
            this.bt_add.Text = ">>";
            this.bt_add.UseVisualStyleBackColor = true;
            this.bt_add.Click += new System.EventHandler(this.bt_add_Click);
            // 
            // bt_remove
            // 
            this.bt_remove.Location = new System.Drawing.Point(838, 529);
            this.bt_remove.Name = "bt_remove";
            this.bt_remove.Size = new System.Drawing.Size(75, 46);
            this.bt_remove.TabIndex = 18;
            this.bt_remove.Text = "<<";
            this.bt_remove.UseVisualStyleBackColor = true;
            this.bt_remove.Click += new System.EventHandler(this.bt_remove_Click);
            // 
            // lb_info
            // 
            this.lb_info.AutoSize = true;
            this.lb_info.Location = new System.Drawing.Point(1427, 706);
            this.lb_info.Name = "lb_info";
            this.lb_info.Size = new System.Drawing.Size(112, 25);
            this.lb_info.TabIndex = 23;
            this.lb_info.Text = "未启动！";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.opcreaderlogin);
            this.groupBox7.Controls.Add(this.bt_login);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Location = new System.Drawing.Point(20, 13);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(769, 100);
            this.groupBox7.TabIndex = 24;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "登陆";
            // 
            // opcreaderlogin
            // 
            this.opcreaderlogin.FormattingEnabled = true;
            this.opcreaderlogin.Location = new System.Drawing.Point(149, 42);
            this.opcreaderlogin.Name = "opcreaderlogin";
            this.opcreaderlogin.Size = new System.Drawing.Size(218, 32);
            this.opcreaderlogin.TabIndex = 25;
            // 
            // bt_login
            // 
            this.bt_login.Location = new System.Drawing.Point(430, 34);
            this.bt_login.Name = "bt_login";
            this.bt_login.Size = new System.Drawing.Size(140, 46);
            this.bt_login.TabIndex = 24;
            this.bt_login.Text = "登陆";
            this.bt_login.UseVisualStyleBackColor = true;
            this.bt_login.Click += new System.EventHandler(this.bt_login_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(137, 25);
            this.label11.TabIndex = 1;
            this.label11.Text = "内置列表：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(823, 34);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(0, 25);
            this.label12.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(823, 88);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 25);
            this.label13.TabIndex = 26;
            // 
            // OPCClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1856, 878);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.bt_remove);
            this.Controls.Add(this.lb_info);
            this.Controls.Add(this.bt_add);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "OPCClient";
            this.Text = "OPC客户端配置   版本：V2.4.6";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFrom_FormClosing);
            this.Load += new System.EventHandler(this.OPCDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbServerName;
        private System.Windows.Forms.Button btnConnLocalServer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTimeStamps;
        private System.Windows.Forms.TextBox txtQualities;
        private System.Windows.Forms.TextBox txtTagValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSetGroupPro;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtUpdateRate;
        private System.Windows.Forms.TextBox txtIsSubscribed;
        private System.Windows.Forms.TextBox txtIsActive;
        private System.Windows.Forms.TextBox txtGroupDeadband;
        private System.Windows.Forms.TextBox txtGroupIsActive;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerState;
        private System.Windows.Forms.ToolStripStatusLabel tsslServerStartTime;
        private System.Windows.Forms.ToolStripStatusLabel tsslversion;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.MaskedTextBox txtRemoteServerIP;
        private System.Windows.Forms.Button btnBegin;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button bt_add;
        private System.Windows.Forms.Button bt_remove;
        private System.Windows.Forms.Label lb_info;
        private System.Windows.Forms.ToolStripStatusLabel tool_state;
        private System.Windows.Forms.Button bt_saveList;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button bt_login;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox opcreaderlogin;
        private System.Windows.Forms.TextBox txt_biasTime;
        private System.Windows.Forms.Label label14;
    }
}

