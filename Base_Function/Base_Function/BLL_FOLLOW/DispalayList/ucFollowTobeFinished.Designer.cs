namespace Base_Function.BLL_FOLLOW.DispalayList
{
    partial class ucFollowTobeFinished
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLast = new DevComponents.DotNetBar.ButtonX();
            this.btnRear = new DevComponents.DotNetBar.ButtonX();
            this.btnFirst = new DevComponents.DotNetBar.ButtonX();
            this.btnPre = new DevComponents.DotNetBar.ButtonX();
            this.cmbEachPage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.dgvPatients = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.诊断信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出随访ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.患者基本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbCurrentPage = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbLTime = new System.Windows.Forms.CheckBox();
            this.dtEndTime1 = new System.Windows.Forms.DateTimePicker();
            this.dtStartTime1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbSymbol = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.ckbFollowTime = new System.Windows.Forms.CheckBox();
            this.rtnSelectState = new DevComponents.DotNetBar.ButtonX();
            this.txtState = new System.Windows.Forms.TextBox();
            this.btnAddFollow = new DevComponents.DotNetBar.ButtonX();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiag = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbFollowInfo = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.cmbSection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHospital = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtStartTime = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExport = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(776, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "条纪录";
            // 
            // btnLast
            // 
            this.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLast.Location = new System.Drawing.Point(891, 21);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(44, 20);
            this.btnLast.TabIndex = 7;
            this.btnLast.Text = ">>";
            // 
            // btnRear
            // 
            this.btnRear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRear.Location = new System.Drawing.Point(823, 21);
            this.btnRear.Name = "btnRear";
            this.btnRear.Size = new System.Drawing.Size(44, 20);
            this.btnRear.TabIndex = 6;
            this.btnRear.Text = ">";
            // 
            // btnFirst
            // 
            this.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnFirst.Location = new System.Drawing.Point(392, 21);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(44, 20);
            this.btnFirst.TabIndex = 5;
            this.btnFirst.Text = "<<";
            // 
            // btnPre
            // 
            this.btnPre.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPre.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPre.Location = new System.Drawing.Point(468, 21);
            this.btnPre.Name = "btnPre";
            this.btnPre.Size = new System.Drawing.Size(44, 20);
            this.btnPre.TabIndex = 4;
            this.btnPre.Text = "<";
            // 
            // cmbEachPage
            // 
            this.cmbEachPage.DisplayMember = "Text";
            this.cmbEachPage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEachPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEachPage.FormattingEnabled = true;
            this.cmbEachPage.ItemHeight = 15;
            this.cmbEachPage.Location = new System.Drawing.Point(697, 21);
            this.cmbEachPage.Name = "cmbEachPage";
            this.cmbEachPage.Size = new System.Drawing.Size(73, 21);
            this.cmbEachPage.TabIndex = 3;
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatients.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatients.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPatients.Location = new System.Drawing.Point(0, 0);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.ReadOnly = true;
            this.dgvPatients.RowTemplate.Height = 23;
            this.dgvPatients.Size = new System.Drawing.Size(1414, 451);
            this.dgvPatients.TabIndex = 0;
            this.dgvPatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellClick);
            this.dgvPatients.DoubleClick += new System.EventHandler(this.dgvPatients_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.诊断信息ToolStripMenuItem,
            this.退出随访ToolStripMenuItem,
            this.患者基本信息ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(143, 70);
            // 
            // 诊断信息ToolStripMenuItem
            // 
            this.诊断信息ToolStripMenuItem.Name = "诊断信息ToolStripMenuItem";
            this.诊断信息ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.诊断信息ToolStripMenuItem.Text = "诊断信息";
            this.诊断信息ToolStripMenuItem.Click += new System.EventHandler(this.诊断信息ToolStripMenuItem_Click);
            // 
            // 退出随访ToolStripMenuItem
            // 
            this.退出随访ToolStripMenuItem.Name = "退出随访ToolStripMenuItem";
            this.退出随访ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.退出随访ToolStripMenuItem.Text = "退出随访";
            this.退出随访ToolStripMenuItem.Click += new System.EventHandler(this.退出随访ToolStripMenuItem_Click);
            // 
            // 患者基本信息ToolStripMenuItem
            // 
            this.患者基本信息ToolStripMenuItem.Name = "患者基本信息ToolStripMenuItem";
            this.患者基本信息ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.患者基本信息ToolStripMenuItem.Text = "患者基本信息";
            this.患者基本信息ToolStripMenuItem.Click += new System.EventHandler(this.患者基本信息ToolStripMenuItem_Click);
            // 
            // cmbCurrentPage
            // 
            this.cmbCurrentPage.DisplayMember = "Text";
            this.cmbCurrentPage.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCurrentPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCurrentPage.FormattingEnabled = true;
            this.cmbCurrentPage.ItemHeight = 15;
            this.cmbCurrentPage.Location = new System.Drawing.Point(577, 21);
            this.cmbCurrentPage.Name = "cmbCurrentPage";
            this.cmbCurrentPage.Size = new System.Drawing.Size(66, 21);
            this.cmbCurrentPage.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "每页：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(518, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前页：";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(1074, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(87, 17);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(100, 21);
            this.txtPatientName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "患者姓名：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnLast);
            this.panel1.Controls.Add(this.btnRear);
            this.panel1.Controls.Add(this.btnFirst);
            this.panel1.Controls.Add(this.btnPre);
            this.panel1.Controls.Add(this.cmbEachPage);
            this.panel1.Controls.Add(this.cmbCurrentPage);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 451);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1414, 58);
            this.panel1.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1420, 529);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病人列表";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvPatients);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1414, 509);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbLTime);
            this.groupBox1.Controls.Add(this.dtEndTime1);
            this.groupBox1.Controls.Add(this.dtStartTime1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbSymbol);
            this.groupBox1.Controls.Add(this.ckbFollowTime);
            this.groupBox1.Controls.Add(this.rtnSelectState);
            this.groupBox1.Controls.Add(this.txtState);
            this.groupBox1.Controls.Add(this.btnAddFollow);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txtDays);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtDiag);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbFollowInfo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDoctor);
            this.groupBox1.Controls.Add(this.cmbSection);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtHospital);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtEndTime);
            this.groupBox1.Controls.Add(this.dtStartTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1420, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询";
            // 
            // ckbLTime
            // 
            this.ckbLTime.AutoSize = true;
            this.ckbLTime.Location = new System.Drawing.Point(613, 68);
            this.ckbLTime.Name = "ckbLTime";
            this.ckbLTime.Size = new System.Drawing.Size(84, 16);
            this.ckbLTime.TabIndex = 33;
            this.ckbLTime.Text = "应随访时间";
            this.ckbLTime.UseVisualStyleBackColor = true;
            // 
            // dtEndTime1
            // 
            this.dtEndTime1.Location = new System.Drawing.Point(844, 62);
            this.dtEndTime1.Name = "dtEndTime1";
            this.dtEndTime1.Size = new System.Drawing.Size(121, 21);
            this.dtEndTime1.TabIndex = 32;
            // 
            // dtStartTime1
            // 
            this.dtStartTime1.Location = new System.Drawing.Point(700, 62);
            this.dtStartTime1.Name = "dtStartTime1";
            this.dtStartTime1.Size = new System.Drawing.Size(121, 21);
            this.dtStartTime1.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(824, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "-";
            // 
            // cmbSymbol
            // 
            this.cmbSymbol.DisplayMember = "Text";
            this.cmbSymbol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSymbol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSymbol.FormattingEnabled = true;
            this.cmbSymbol.ItemHeight = 15;
            this.cmbSymbol.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3});
            this.cmbSymbol.Location = new System.Drawing.Point(1252, 62);
            this.cmbSymbol.Name = "cmbSymbol";
            this.cmbSymbol.Size = new System.Drawing.Size(72, 21);
            this.cmbSymbol.TabIndex = 29;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = ">";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "<";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "=";
            // 
            // ckbFollowTime
            // 
            this.ckbFollowTime.AutoSize = true;
            this.ckbFollowTime.Location = new System.Drawing.Point(264, 68);
            this.ckbFollowTime.Name = "ckbFollowTime";
            this.ckbFollowTime.Size = new System.Drawing.Size(72, 16);
            this.ckbFollowTime.TabIndex = 28;
            this.ckbFollowTime.Text = "随访时间";
            this.ckbFollowTime.UseVisualStyleBackColor = true;
            // 
            // rtnSelectState
            // 
            this.rtnSelectState.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.rtnSelectState.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.rtnSelectState.Location = new System.Drawing.Point(213, 62);
            this.rtnSelectState.Name = "rtnSelectState";
            this.rtnSelectState.Size = new System.Drawing.Size(39, 24);
            this.rtnSelectState.TabIndex = 27;
            this.rtnSelectState.Text = "...";
            this.rtnSelectState.Click += new System.EventHandler(this.rtnSelectState_Click);
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(87, 53);
            this.txtState.Multiline = true;
            this.txtState.Name = "txtState";
            this.txtState.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtState.Size = new System.Drawing.Size(100, 37);
            this.txtState.TabIndex = 26;
            this.txtState.WordWrap = false;
            // 
            // btnAddFollow
            // 
            this.btnAddFollow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddFollow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddFollow.Location = new System.Drawing.Point(1236, 20);
            this.btnAddFollow.Name = "btnAddFollow";
            this.btnAddFollow.Size = new System.Drawing.Size(75, 24);
            this.btnAddFollow.TabIndex = 23;
            this.btnAddFollow.Text = "新增随访";
            this.btnAddFollow.Click += new System.EventHandler(this.btnAddFollow_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(1394, 69);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 22;
            this.label14.Text = "天";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(1330, 62);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(58, 21);
            this.txtDays.TabIndex = 21;
            this.txtDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDays_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1173, 68);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 20;
            this.label13.Text = "超期天数：";
            // 
            // txtDiag
            // 
            this.txtDiag.Location = new System.Drawing.Point(1028, 62);
            this.txtDiag.Name = "txtDiag";
            this.txtDiag.Size = new System.Drawing.Size(121, 21);
            this.txtDiag.TabIndex = 19;
            this.txtDiag.TextChanged += new System.EventHandler(this.txtDiag_TextChanged);
            this.txtDiag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiag_KeyUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(981, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 18;
            this.label12.Text = "诊断：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 68);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "随访状态：";
            // 
            // cmbFollowInfo
            // 
            this.cmbFollowInfo.DisplayMember = "Text";
            this.cmbFollowInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFollowInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFollowInfo.FormattingEnabled = true;
            this.cmbFollowInfo.ItemHeight = 15;
            this.cmbFollowInfo.Location = new System.Drawing.Point(848, 17);
            this.cmbFollowInfo.Name = "cmbFollowInfo";
            this.cmbFollowInfo.Size = new System.Drawing.Size(167, 21);
            this.cmbFollowInfo.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(777, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 14;
            this.label10.Text = "随访方案：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(585, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "科室：";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(472, 17);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(100, 21);
            this.txtDoctor.TabIndex = 12;
            this.txtDoctor.TextChanged += new System.EventHandler(this.txtDoctor_TextChanged);
            this.txtDoctor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyUp);
            // 
            // cmbSection
            // 
            this.cmbSection.DisplayMember = "Text";
            this.cmbSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.ItemHeight = 15;
            this.cmbSection.Location = new System.Drawing.Point(632, 17);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(121, 21);
            this.cmbSection.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSection.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(401, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "管床医生：";
            // 
            // txtHospital
            // 
            this.txtHospital.Location = new System.Drawing.Point(270, 17);
            this.txtHospital.Name = "txtHospital";
            this.txtHospital.Size = new System.Drawing.Size(100, 21);
            this.txtHospital.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "住院号：";
            // 
            // dtEndTime
            // 
            this.dtEndTime.Location = new System.Drawing.Point(486, 62);
            this.dtEndTime.Name = "dtEndTime";
            this.dtEndTime.Size = new System.Drawing.Size(121, 21);
            this.dtEndTime.TabIndex = 7;
            // 
            // dtStartTime
            // 
            this.dtStartTime.Location = new System.Drawing.Point(342, 62);
            this.dtStartTime.Name = "dtStartTime";
            this.dtStartTime.Size = new System.Drawing.Size(121, 21);
            this.dtStartTime.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(469, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "-";
            // 
            // btnExport
            // 
            this.btnExport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnExport.Location = new System.Drawing.Point(1155, 20);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 24);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出EXCEL";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ucFollowTobeFinished
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucFollowTobeFinished";
            this.Size = new System.Drawing.Size(1420, 625);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnLast;
        private DevComponents.DotNetBar.ButtonX btnRear;
        private DevComponents.DotNetBar.ButtonX btnFirst;
        private DevComponents.DotNetBar.ButtonX btnPre;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbEachPage;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPatients;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbCurrentPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX btnExport;
        private System.Windows.Forms.DateTimePicker dtEndTime;
        private System.Windows.Forms.DateTimePicker dtStartTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHospital;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiag;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbFollowInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDoctor;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSection;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Label label13;
        private DevComponents.DotNetBar.ButtonX btnAddFollow;
        private DevComponents.DotNetBar.ButtonX rtnSelectState;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 诊断信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出随访ToolStripMenuItem;
        private System.Windows.Forms.CheckBox ckbFollowTime;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSymbol;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private System.Windows.Forms.ToolStripMenuItem 患者基本信息ToolStripMenuItem;
        private System.Windows.Forms.CheckBox ckbLTime;
        private System.Windows.Forms.DateTimePicker dtEndTime1;
        private System.Windows.Forms.DateTimePicker dtStartTime1;
        private System.Windows.Forms.Label label5;
    }
}
