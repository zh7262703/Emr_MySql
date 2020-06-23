using Base_Function.BLL_MANAGEMENT;
namespace Base_Function.BLL_MANAGEMENT
{
    partial class ucUCEParam
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup7 = new System.Windows.Forms.ListViewGroup("体温单", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup8 = new System.Windows.Forms.ListViewGroup("I.T P R", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup9 = new System.Windows.Forms.ListViewGroup("II.身高 体重", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup10 = new System.Windows.Forms.ListViewGroup("III.大便 小便 呼吸", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup11 = new System.Windows.Forms.ListViewGroup("IV.血压", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup12 = new System.Windows.Forms.ListViewGroup("小儿体温", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "1",
            "1"}, -1);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwQualitys = new System.Windows.Forms.ListView();
            this.columnHeader = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuQuality = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnReset = new DevComponents.DotNetBar.ButtonX();
            this.gpbFixTime = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdoSingle = new System.Windows.Forms.RadioButton();
            this.chk10pm = new System.Windows.Forms.CheckBox();
            this.chk1am = new System.Windows.Forms.CheckBox();
            this.rdoDouble = new System.Windows.Forms.RadioButton();
            this.chk6pm = new System.Windows.Forms.CheckBox();
            this.chk2pm = new System.Windows.Forms.CheckBox();
            this.chk10am = new System.Windows.Forms.CheckBox();
            this.chk6am = new System.Windows.Forms.CheckBox();
            this.chk2am = new System.Windows.Forms.CheckBox();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdoIsCheck = new System.Windows.Forms.RadioButton();
            this.rdoIsCheckF = new System.Windows.Forms.RadioButton();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdoIsNotice = new System.Windows.Forms.RadioButton();
            this.rdoIsNoticeF = new System.Windows.Forms.RadioButton();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdoIsMend = new System.Windows.Forms.RadioButton();
            this.rdoIsMendF = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDeduction = new System.Windows.Forms.TextBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.rdoIsOverAlertF = new System.Windows.Forms.RadioButton();
            this.rdoIsOverAlert = new System.Windows.Forms.RadioButton();
            this.txtPrealertTime = new System.Windows.Forms.TextBox();
            this.cboPrealertUnit = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtExceTimes = new System.Windows.Forms.TextBox();
            this.cboTextKind = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItemMax = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblItemMax = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtItemMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblItemMin = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboMonitoring = new System.Windows.Forms.ComboBox();
            this.cboMonitorType = new System.Windows.Forms.ComboBox();
            this.txtDNightShift = new System.Windows.Forms.TextBox();
            this.cboCKTime = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtExecCycles = new System.Windows.Forms.TextBox();
            this.txtXNightShift = new System.Windows.Forms.TextBox();
            this.cboCyclesUnit = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDayShift = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpMonitoring = new System.Windows.Forms.GroupBox();
            this.btnSaveJC = new DevComponents.DotNetBar.ButtonX();
            this.label45 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.txtStoolMin = new System.Windows.Forms.TextBox();
            this.txtDBPMin = new System.Windows.Forms.TextBox();
            this.txtSBPMin = new System.Windows.Forms.TextBox();
            this.txtBreathMin = new System.Windows.Forms.TextBox();
            this.txtPulseMin = new System.Windows.Forms.TextBox();
            this.txtTemperatureMin = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.txtStoolMax = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtDBPMax = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSBPMax = new System.Windows.Forms.TextBox();
            this.txtBreathMax = new System.Windows.Forms.TextBox();
            this.txtPulseMax = new System.Windows.Forms.TextBox();
            this.txtTemperatureMax = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lblSBP = new System.Windows.Forms.Label();
            this.lblBreath = new System.Windows.Forms.Label();
            this.lblDBP = new System.Windows.Forms.Label();
            this.lblStool = new System.Windows.Forms.Label();
            this.lblPulse = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem5 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel6 = new DevComponents.DotNetBar.TabControlPanel();
            this.ucDocument_statistics2 = new Base_Function.BLL_MANAGEMENT.NURSE_MANAGE.ucDocument_statistics();
            this.tabItem6 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.caseSearchMark1 = new Base_Function.BLL_MANAGEMENT.SICKFILE.CaseSearchMark();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel7 = new DevComponents.DotNetBar.TabControlPanel();
            this.userfrmQueryLevy1 = new Base_Function.BLL_MANAGEMENT.UserfrmQueryLevy();
            this.tabItem7 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabItem8 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel8 = new DevComponents.DotNetBar.TabControlPanel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuQuality.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gpbFixTime.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.grpMonitoring.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel6.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabControlPanel7.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.lvwQualitys);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 707);
            this.splitContainer1.SplitterDistance = 362;
            this.splitContainer1.TabIndex = 0;
            // 
            // lvwQualitys
            // 
            this.lvwQualitys.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader,
            this.columnHeader1});
            this.lvwQualitys.ContextMenuStrip = this.contextMenuQuality;
            this.lvwQualitys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwQualitys.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvwQualitys.GridLines = true;
            listViewGroup7.Header = "体温单";
            listViewGroup7.Name = "group0";
            listViewGroup8.Header = "I.T P R";
            listViewGroup8.Name = "group1";
            listViewGroup9.Header = "II.身高 体重";
            listViewGroup9.Name = "group2";
            listViewGroup10.Header = "III.大便 小便 呼吸";
            listViewGroup10.Name = "group3";
            listViewGroup11.Header = "IV.血压";
            listViewGroup11.Name = "group4";
            listViewGroup12.Header = "小儿体温";
            listViewGroup12.Name = "group5";
            this.lvwQualitys.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup7,
            listViewGroup8,
            listViewGroup9,
            listViewGroup10,
            listViewGroup11,
            listViewGroup12});
            this.lvwQualitys.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lvwQualitys.Location = new System.Drawing.Point(0, 0);
            this.lvwQualitys.Name = "lvwQualitys";
            this.lvwQualitys.Size = new System.Drawing.Size(1014, 362);
            this.lvwQualitys.TabIndex = 0;
            this.lvwQualitys.UseCompatibleStateImageBehavior = false;
            this.lvwQualitys.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader
            // 
            this.columnHeader.Text = "体温单";
            this.columnHeader.Width = 1150;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "状态";
            // 
            // contextMenuQuality
            // 
            this.contextMenuQuality.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改ToolStripMenuItem,
            this.toolStripSeparator1,
            this.removeToolStripMenuItem});
            this.contextMenuQuality.Name = "contextMenuQuality";
            this.contextMenuQuality.Size = new System.Drawing.Size(101, 54);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.removeToolStripMenuItem.Text = "删除";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupBox1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.gpbFixTime);
            this.groupBox1.Controls.Add(this.groupPanel5);
            this.groupBox1.Controls.Add(this.groupPanel4);
            this.groupBox1.Controls.Add(this.groupPanel3);
            this.groupBox1.Controls.Add(this.groupPanel2);
            this.groupBox1.Controls.Add(this.txtExceTimes);
            this.groupBox1.Controls.Add(this.cboTextKind);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtItemMax);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblItemMax);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtItemMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblItemMin);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboMonitoring);
            this.groupBox1.Controls.Add(this.cboMonitorType);
            this.groupBox1.Controls.Add(this.txtDNightShift);
            this.groupBox1.Controls.Add(this.cboCKTime);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtExecCycles);
            this.groupBox1.Controls.Add(this.txtXNightShift);
            this.groupBox1.Controls.Add(this.cboCyclesUnit);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDayShift);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1014, 341);
            // 
            // 
            // 
            this.groupBox1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupBox1.Style.BackColorGradientAngle = 90;
            this.groupBox1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupBox1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupBox1.Style.BorderBottomWidth = 1;
            this.groupBox1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupBox1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupBox1.Style.BorderLeftWidth = 1;
            this.groupBox1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupBox1.Style.BorderRightWidth = 1;
            this.groupBox1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupBox1.Style.BorderTopWidth = 1;
            this.groupBox1.Style.CornerDiameter = 4;
            this.groupBox1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupBox1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupBox1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupBox1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupBox1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupBox1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupBox1.TabIndex = 1;
            this.groupBox1.Text = "参数设置";
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button1.Location = new System.Drawing.Point(484, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 21);
            this.button1.TabIndex = 59;
            this.button1.Text = "删除";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(399, 209);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 21);
            this.btnSave.TabIndex = 58;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnReset
            // 
            this.btnReset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReset.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReset.Location = new System.Drawing.Point(315, 209);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(78, 21);
            this.btnReset.TabIndex = 57;
            this.btnReset.Text = "重置";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // gpbFixTime
            // 
            this.gpbFixTime.CanvasColor = System.Drawing.SystemColors.Control;
            this.gpbFixTime.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gpbFixTime.Controls.Add(this.rdoSingle);
            this.gpbFixTime.Controls.Add(this.chk10pm);
            this.gpbFixTime.Controls.Add(this.chk1am);
            this.gpbFixTime.Controls.Add(this.rdoDouble);
            this.gpbFixTime.Controls.Add(this.chk6pm);
            this.gpbFixTime.Controls.Add(this.chk2pm);
            this.gpbFixTime.Controls.Add(this.chk10am);
            this.gpbFixTime.Controls.Add(this.chk6am);
            this.gpbFixTime.Controls.Add(this.chk2am);
            this.gpbFixTime.Location = new System.Drawing.Point(618, 82);
            this.gpbFixTime.Name = "gpbFixTime";
            this.gpbFixTime.Size = new System.Drawing.Size(356, 116);
            // 
            // 
            // 
            this.gpbFixTime.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gpbFixTime.Style.BackColorGradientAngle = 90;
            this.gpbFixTime.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gpbFixTime.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpbFixTime.Style.BorderBottomWidth = 1;
            this.gpbFixTime.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gpbFixTime.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpbFixTime.Style.BorderLeftWidth = 1;
            this.gpbFixTime.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpbFixTime.Style.BorderRightWidth = 1;
            this.gpbFixTime.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gpbFixTime.Style.BorderTopWidth = 1;
            this.gpbFixTime.Style.CornerDiameter = 4;
            this.gpbFixTime.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gpbFixTime.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gpbFixTime.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gpbFixTime.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.gpbFixTime.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.gpbFixTime.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.gpbFixTime.TabIndex = 56;
            this.gpbFixTime.Text = "执行时间点";
            // 
            // rdoSingle
            // 
            this.rdoSingle.AutoSize = true;
            this.rdoSingle.Enabled = false;
            this.rdoSingle.Location = new System.Drawing.Point(259, 7);
            this.rdoSingle.Name = "rdoSingle";
            this.rdoSingle.Size = new System.Drawing.Size(59, 16);
            this.rdoSingle.TabIndex = 26;
            this.rdoSingle.Text = "单数点";
            this.rdoSingle.UseVisualStyleBackColor = true;
            this.rdoSingle.Visible = false;
            // 
            // chk10pm
            // 
            this.chk10pm.AutoSize = true;
            this.chk10pm.Enabled = false;
            this.chk10pm.Location = new System.Drawing.Point(104, 40);
            this.chk10pm.Name = "chk10pm";
            this.chk10pm.Size = new System.Drawing.Size(48, 16);
            this.chk10pm.TabIndex = 0;
            this.chk10pm.Text = "10pm";
            this.chk10pm.UseVisualStyleBackColor = true;
            // 
            // chk1am
            // 
            this.chk1am.AutoSize = true;
            this.chk1am.Enabled = false;
            this.chk1am.Location = new System.Drawing.Point(149, 18);
            this.chk1am.Name = "chk1am";
            this.chk1am.Size = new System.Drawing.Size(42, 16);
            this.chk1am.TabIndex = 11;
            this.chk1am.Text = "8am";
            this.chk1am.UseVisualStyleBackColor = true;
            this.chk1am.Visible = false;
            // 
            // rdoDouble
            // 
            this.rdoDouble.AutoSize = true;
            this.rdoDouble.Enabled = false;
            this.rdoDouble.Location = new System.Drawing.Point(259, 40);
            this.rdoDouble.Name = "rdoDouble";
            this.rdoDouble.Size = new System.Drawing.Size(59, 16);
            this.rdoDouble.TabIndex = 27;
            this.rdoDouble.TabStop = true;
            this.rdoDouble.Text = "双数点";
            this.rdoDouble.UseVisualStyleBackColor = true;
            this.rdoDouble.Visible = false;
            this.rdoDouble.CheckedChanged += new System.EventHandler(this.rdoDouble_CheckedChanged);
            // 
            // chk6pm
            // 
            this.chk6pm.AutoSize = true;
            this.chk6pm.Enabled = false;
            this.chk6pm.Location = new System.Drawing.Point(60, 40);
            this.chk6pm.Name = "chk6pm";
            this.chk6pm.Size = new System.Drawing.Size(42, 16);
            this.chk6pm.TabIndex = 1;
            this.chk6pm.Text = "6pm";
            this.chk6pm.UseVisualStyleBackColor = true;
            // 
            // chk2pm
            // 
            this.chk2pm.AutoSize = true;
            this.chk2pm.Enabled = false;
            this.chk2pm.Location = new System.Drawing.Point(16, 40);
            this.chk2pm.Name = "chk2pm";
            this.chk2pm.Size = new System.Drawing.Size(42, 16);
            this.chk2pm.TabIndex = 2;
            this.chk2pm.Text = "2pm";
            this.chk2pm.UseVisualStyleBackColor = true;
            // 
            // chk10am
            // 
            this.chk10am.AutoSize = true;
            this.chk10am.Enabled = false;
            this.chk10am.Location = new System.Drawing.Point(104, 18);
            this.chk10am.Name = "chk10am";
            this.chk10am.Size = new System.Drawing.Size(48, 16);
            this.chk10am.TabIndex = 3;
            this.chk10am.Text = "10am";
            this.chk10am.UseVisualStyleBackColor = true;
            // 
            // chk6am
            // 
            this.chk6am.AutoSize = true;
            this.chk6am.Enabled = false;
            this.chk6am.Location = new System.Drawing.Point(60, 18);
            this.chk6am.Name = "chk6am";
            this.chk6am.Size = new System.Drawing.Size(42, 16);
            this.chk6am.TabIndex = 4;
            this.chk6am.Text = "6am";
            this.chk6am.UseVisualStyleBackColor = true;
            // 
            // chk2am
            // 
            this.chk2am.AutoSize = true;
            this.chk2am.Enabled = false;
            this.chk2am.Location = new System.Drawing.Point(16, 18);
            this.chk2am.Name = "chk2am";
            this.chk2am.Size = new System.Drawing.Size(42, 16);
            this.chk2am.TabIndex = 5;
            this.chk2am.Text = "2am";
            this.chk2am.UseVisualStyleBackColor = true;
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.rdoIsCheck);
            this.groupPanel5.Controls.Add(this.rdoIsCheckF);
            this.groupPanel5.Location = new System.Drawing.Point(474, 143);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(135, 55);
            // 
            // 
            // 
            this.groupPanel5.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel5.Style.BackColorGradientAngle = 90;
            this.groupPanel5.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel5.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderBottomWidth = 1;
            this.groupPanel5.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel5.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderLeftWidth = 1;
            this.groupPanel5.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderRightWidth = 1;
            this.groupPanel5.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel5.Style.BorderTopWidth = 1;
            this.groupPanel5.Style.CornerDiameter = 4;
            this.groupPanel5.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel5.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel5.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel5.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel5.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel5.TabIndex = 55;
            this.groupPanel5.Text = "是否当天检查一次";
            // 
            // rdoIsCheck
            // 
            this.rdoIsCheck.AutoSize = true;
            this.rdoIsCheck.Location = new System.Drawing.Point(23, 8);
            this.rdoIsCheck.Name = "rdoIsCheck";
            this.rdoIsCheck.Size = new System.Drawing.Size(35, 16);
            this.rdoIsCheck.TabIndex = 19;
            this.rdoIsCheck.Text = "是";
            this.rdoIsCheck.UseVisualStyleBackColor = true;
            // 
            // rdoIsCheckF
            // 
            this.rdoIsCheckF.AutoSize = true;
            this.rdoIsCheckF.Checked = true;
            this.rdoIsCheckF.Location = new System.Drawing.Point(75, 8);
            this.rdoIsCheckF.Name = "rdoIsCheckF";
            this.rdoIsCheckF.Size = new System.Drawing.Size(35, 16);
            this.rdoIsCheckF.TabIndex = 20;
            this.rdoIsCheckF.TabStop = true;
            this.rdoIsCheckF.Text = "否";
            this.rdoIsCheckF.UseVisualStyleBackColor = true;
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.rdoIsNotice);
            this.groupPanel4.Controls.Add(this.rdoIsNoticeF);
            this.groupPanel4.Location = new System.Drawing.Point(474, 82);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(135, 55);
            // 
            // 
            // 
            this.groupPanel4.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel4.Style.BackColorGradientAngle = 90;
            this.groupPanel4.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel4.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderBottomWidth = 1;
            this.groupPanel4.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel4.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderLeftWidth = 1;
            this.groupPanel4.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderRightWidth = 1;
            this.groupPanel4.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel4.Style.BorderTopWidth = 1;
            this.groupPanel4.Style.CornerDiameter = 4;
            this.groupPanel4.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel4.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel4.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel4.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel4.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel4.TabIndex = 54;
            this.groupPanel4.Text = "是否提醒";
            // 
            // rdoIsNotice
            // 
            this.rdoIsNotice.AutoSize = true;
            this.rdoIsNotice.Location = new System.Drawing.Point(23, 7);
            this.rdoIsNotice.Name = "rdoIsNotice";
            this.rdoIsNotice.Size = new System.Drawing.Size(35, 16);
            this.rdoIsNotice.TabIndex = 24;
            this.rdoIsNotice.Text = "是";
            this.rdoIsNotice.UseVisualStyleBackColor = true;
            // 
            // rdoIsNoticeF
            // 
            this.rdoIsNoticeF.AutoSize = true;
            this.rdoIsNoticeF.Checked = true;
            this.rdoIsNoticeF.Location = new System.Drawing.Point(73, 7);
            this.rdoIsNoticeF.Name = "rdoIsNoticeF";
            this.rdoIsNoticeF.Size = new System.Drawing.Size(35, 16);
            this.rdoIsNoticeF.TabIndex = 25;
            this.rdoIsNoticeF.TabStop = true;
            this.rdoIsNoticeF.Text = "否";
            this.rdoIsNoticeF.UseVisualStyleBackColor = true;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.rdoIsMend);
            this.groupPanel3.Controls.Add(this.rdoIsMendF);
            this.groupPanel3.Controls.Add(this.label8);
            this.groupPanel3.Controls.Add(this.txtDeduction);
            this.groupPanel3.Location = new System.Drawing.Point(246, 82);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(219, 116);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 53;
            this.groupPanel3.Text = "超时补上是否扣分";
            // 
            // rdoIsMend
            // 
            this.rdoIsMend.AutoSize = true;
            this.rdoIsMend.Location = new System.Drawing.Point(18, 15);
            this.rdoIsMend.Name = "rdoIsMend";
            this.rdoIsMend.Size = new System.Drawing.Size(35, 16);
            this.rdoIsMend.TabIndex = 21;
            this.rdoIsMend.Text = "是";
            this.rdoIsMend.UseVisualStyleBackColor = true;
            this.rdoIsMend.CheckedChanged += new System.EventHandler(this.rdoIsMend_CheckedChanged);
            // 
            // rdoIsMendF
            // 
            this.rdoIsMendF.AutoSize = true;
            this.rdoIsMendF.Checked = true;
            this.rdoIsMendF.Location = new System.Drawing.Point(83, 14);
            this.rdoIsMendF.Name = "rdoIsMendF";
            this.rdoIsMendF.Size = new System.Drawing.Size(35, 16);
            this.rdoIsMendF.TabIndex = 22;
            this.rdoIsMendF.TabStop = true;
            this.rdoIsMendF.Text = "否";
            this.rdoIsMendF.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 7;
            this.label8.Text = "扣分值：";
            // 
            // txtDeduction
            // 
            this.txtDeduction.Enabled = false;
            this.txtDeduction.Location = new System.Drawing.Point(66, 43);
            this.txtDeduction.Name = "txtDeduction";
            this.txtDeduction.Size = new System.Drawing.Size(140, 21);
            this.txtDeduction.TabIndex = 23;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.rdoIsOverAlertF);
            this.groupPanel2.Controls.Add(this.rdoIsOverAlert);
            this.groupPanel2.Controls.Add(this.txtPrealertTime);
            this.groupPanel2.Controls.Add(this.cboPrealertUnit);
            this.groupPanel2.Controls.Add(this.label12);
            this.groupPanel2.Location = new System.Drawing.Point(8, 82);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(232, 116);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 52;
            this.groupPanel2.Text = "是否预警";
            // 
            // rdoIsOverAlertF
            // 
            this.rdoIsOverAlertF.AutoSize = true;
            this.rdoIsOverAlertF.Checked = true;
            this.rdoIsOverAlertF.Location = new System.Drawing.Point(75, 14);
            this.rdoIsOverAlertF.Name = "rdoIsOverAlertF";
            this.rdoIsOverAlertF.Size = new System.Drawing.Size(35, 16);
            this.rdoIsOverAlertF.TabIndex = 18;
            this.rdoIsOverAlertF.TabStop = true;
            this.rdoIsOverAlertF.Text = "否";
            this.rdoIsOverAlertF.UseVisualStyleBackColor = true;
            // 
            // rdoIsOverAlert
            // 
            this.rdoIsOverAlert.AutoSize = true;
            this.rdoIsOverAlert.Location = new System.Drawing.Point(13, 15);
            this.rdoIsOverAlert.Name = "rdoIsOverAlert";
            this.rdoIsOverAlert.Size = new System.Drawing.Size(35, 16);
            this.rdoIsOverAlert.TabIndex = 17;
            this.rdoIsOverAlert.Text = "是";
            this.rdoIsOverAlert.UseVisualStyleBackColor = true;
            this.rdoIsOverAlert.CheckedChanged += new System.EventHandler(this.rdoIsOverAlert_CheckedChanged);
            // 
            // txtPrealertTime
            // 
            this.txtPrealertTime.Enabled = false;
            this.txtPrealertTime.Location = new System.Drawing.Point(75, 44);
            this.txtPrealertTime.Name = "txtPrealertTime";
            this.txtPrealertTime.Size = new System.Drawing.Size(76, 21);
            this.txtPrealertTime.TabIndex = 30;
            // 
            // cboPrealertUnit
            // 
            this.cboPrealertUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPrealertUnit.Enabled = false;
            this.cboPrealertUnit.FormattingEnabled = true;
            this.cboPrealertUnit.Items.AddRange(new object[] {
            "小时",
            "分",
            "天"});
            this.cboPrealertUnit.Location = new System.Drawing.Point(157, 44);
            this.cboPrealertUnit.Name = "cboPrealertUnit";
            this.cboPrealertUnit.Size = new System.Drawing.Size(58, 20);
            this.cboPrealertUnit.TabIndex = 31;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 29;
            this.label12.Text = "预警时间：";
            // 
            // txtExceTimes
            // 
            this.txtExceTimes.Location = new System.Drawing.Point(786, 4);
            this.txtExceTimes.Name = "txtExceTimes";
            this.txtExceTimes.Size = new System.Drawing.Size(63, 21);
            this.txtExceTimes.TabIndex = 51;
            // 
            // cboTextKind
            // 
            this.cboTextKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextKind.FormattingEnabled = true;
            this.cboTextKind.Location = new System.Drawing.Point(74, 5);
            this.cboTextKind.Name = "cboTextKind";
            this.cboTextKind.Size = new System.Drawing.Size(140, 20);
            this.cboTextKind.TabIndex = 11;
            this.cboTextKind.SelectedIndexChanged += new System.EventHandler(this.cboTextKind_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(715, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 50;
            this.label13.Text = "执行次数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文书类型：";
            // 
            // txtItemMax
            // 
            this.txtItemMax.Enabled = false;
            this.txtItemMax.Location = new System.Drawing.Point(709, 41);
            this.txtItemMax.Name = "txtItemMax";
            this.txtItemMax.Size = new System.Drawing.Size(63, 21);
            this.txtItemMax.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(465, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "监控患者类型：";
            // 
            // lblItemMax
            // 
            this.lblItemMax.AutoSize = true;
            this.lblItemMax.Location = new System.Drawing.Point(626, 45);
            this.lblItemMax.Name = "lblItemMax";
            this.lblItemMax.Size = new System.Drawing.Size(77, 12);
            this.lblItemMax.TabIndex = 48;
            this.lblItemMax.Text = "项目最大值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "参考时间：";
            // 
            // txtItemMin
            // 
            this.txtItemMin.Enabled = false;
            this.txtItemMin.Location = new System.Drawing.Point(548, 42);
            this.txtItemMin.Name = "txtItemMin";
            this.txtItemMin.Size = new System.Drawing.Size(62, 21);
            this.txtItemMin.TabIndex = 47;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "监控子项：";
            // 
            // lblItemMin
            // 
            this.lblItemMin.AutoSize = true;
            this.lblItemMin.Location = new System.Drawing.Point(465, 46);
            this.lblItemMin.Name = "lblItemMin";
            this.lblItemMin.Size = new System.Drawing.Size(77, 12);
            this.lblItemMin.TabIndex = 46;
            this.lblItemMin.Text = "项目最小值：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(234, 45);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 10;
            this.label11.Text = "执行周期：";
            // 
            // cboMonitoring
            // 
            this.cboMonitoring.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonitoring.Enabled = false;
            this.cboMonitoring.FormattingEnabled = true;
            this.cboMonitoring.Location = new System.Drawing.Point(305, 5);
            this.cboMonitoring.Name = "cboMonitoring";
            this.cboMonitoring.Size = new System.Drawing.Size(140, 20);
            this.cboMonitoring.TabIndex = 12;
            this.cboMonitoring.SelectedIndexChanged += new System.EventHandler(this.cboMonitoring_SelectedIndexChanged);
            // 
            // cboMonitorType
            // 
            this.cboMonitorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonitorType.FormattingEnabled = true;
            this.cboMonitorType.Location = new System.Drawing.Point(560, 5);
            this.cboMonitorType.Name = "cboMonitorType";
            this.cboMonitorType.Size = new System.Drawing.Size(140, 20);
            this.cboMonitorType.TabIndex = 13;
            this.cboMonitorType.SelectedIndexChanged += new System.EventHandler(this.cboMonitorType_SelectedIndexChanged);
            // 
            // txtDNightShift
            // 
            this.txtDNightShift.Enabled = false;
            this.txtDNightShift.Location = new System.Drawing.Point(898, 387);
            this.txtDNightShift.Name = "txtDNightShift";
            this.txtDNightShift.Size = new System.Drawing.Size(63, 21);
            this.txtDNightShift.TabIndex = 41;
            this.txtDNightShift.Text = "8:00";
            this.txtDNightShift.Visible = false;
            // 
            // cboCKTime
            // 
            this.cboCKTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCKTime.FormattingEnabled = true;
            this.cboCKTime.Location = new System.Drawing.Point(74, 42);
            this.cboCKTime.Name = "cboCKTime";
            this.cboCKTime.Size = new System.Drawing.Size(140, 20);
            this.cboCKTime.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(839, 391);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 40;
            this.label9.Text = "大夜班：";
            this.label9.Visible = false;
            // 
            // txtExecCycles
            // 
            this.txtExecCycles.Location = new System.Drawing.Point(305, 42);
            this.txtExecCycles.Name = "txtExecCycles";
            this.txtExecCycles.Size = new System.Drawing.Size(76, 21);
            this.txtExecCycles.TabIndex = 15;
            // 
            // txtXNightShift
            // 
            this.txtXNightShift.Enabled = false;
            this.txtXNightShift.Location = new System.Drawing.Point(770, 388);
            this.txtXNightShift.Name = "txtXNightShift";
            this.txtXNightShift.Size = new System.Drawing.Size(63, 21);
            this.txtXNightShift.TabIndex = 39;
            this.txtXNightShift.Text = "00:00";
            this.txtXNightShift.Visible = false;
            // 
            // cboCyclesUnit
            // 
            this.cboCyclesUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCyclesUnit.FormattingEnabled = true;
            this.cboCyclesUnit.Items.AddRange(new object[] {
            "小时",
            "分",
            "天",
            "班次"});
            this.cboCyclesUnit.Location = new System.Drawing.Point(387, 42);
            this.cboCyclesUnit.Name = "cboCyclesUnit";
            this.cboCyclesUnit.Size = new System.Drawing.Size(58, 20);
            this.cboCyclesUnit.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(714, 392);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 38;
            this.label7.Text = "小夜班：";
            this.label7.Visible = false;
            // 
            // txtDayShift
            // 
            this.txtDayShift.Enabled = false;
            this.txtDayShift.Location = new System.Drawing.Point(645, 388);
            this.txtDayShift.Name = "txtDayShift";
            this.txtDayShift.Size = new System.Drawing.Size(63, 21);
            this.txtDayShift.TabIndex = 37;
            this.txtDayShift.Text = "18:00";
            this.txtDayShift.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(607, 392);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 36;
            this.label4.Text = "白班：";
            this.label4.Visible = false;
            // 
            // grpMonitoring
            // 
            this.grpMonitoring.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMonitoring.BackColor = System.Drawing.Color.Transparent;
            this.grpMonitoring.Controls.Add(this.btnSaveJC);
            this.grpMonitoring.Controls.Add(this.label45);
            this.grpMonitoring.Controls.Add(this.label44);
            this.grpMonitoring.Controls.Add(this.label43);
            this.grpMonitoring.Controls.Add(this.label42);
            this.grpMonitoring.Controls.Add(this.txtStoolMin);
            this.grpMonitoring.Controls.Add(this.txtDBPMin);
            this.grpMonitoring.Controls.Add(this.txtSBPMin);
            this.grpMonitoring.Controls.Add(this.txtBreathMin);
            this.grpMonitoring.Controls.Add(this.txtPulseMin);
            this.grpMonitoring.Controls.Add(this.txtTemperatureMin);
            this.grpMonitoring.Controls.Add(this.label41);
            this.grpMonitoring.Controls.Add(this.label39);
            this.grpMonitoring.Controls.Add(this.label40);
            this.grpMonitoring.Controls.Add(this.label38);
            this.grpMonitoring.Controls.Add(this.label37);
            this.grpMonitoring.Controls.Add(this.label36);
            this.grpMonitoring.Controls.Add(this.label35);
            this.grpMonitoring.Controls.Add(this.label34);
            this.grpMonitoring.Controls.Add(this.label33);
            this.grpMonitoring.Controls.Add(this.label32);
            this.grpMonitoring.Controls.Add(this.label31);
            this.grpMonitoring.Controls.Add(this.label30);
            this.grpMonitoring.Controls.Add(this.label29);
            this.grpMonitoring.Controls.Add(this.label28);
            this.grpMonitoring.Controls.Add(this.txtStoolMax);
            this.grpMonitoring.Controls.Add(this.label27);
            this.grpMonitoring.Controls.Add(this.txtDBPMax);
            this.grpMonitoring.Controls.Add(this.label26);
            this.grpMonitoring.Controls.Add(this.txtSBPMax);
            this.grpMonitoring.Controls.Add(this.txtBreathMax);
            this.grpMonitoring.Controls.Add(this.txtPulseMax);
            this.grpMonitoring.Controls.Add(this.txtTemperatureMax);
            this.grpMonitoring.Controls.Add(this.label25);
            this.grpMonitoring.Controls.Add(this.label24);
            this.grpMonitoring.Controls.Add(this.label23);
            this.grpMonitoring.Controls.Add(this.label22);
            this.grpMonitoring.Controls.Add(this.label21);
            this.grpMonitoring.Controls.Add(this.lblSBP);
            this.grpMonitoring.Controls.Add(this.lblBreath);
            this.grpMonitoring.Controls.Add(this.lblDBP);
            this.grpMonitoring.Controls.Add(this.lblStool);
            this.grpMonitoring.Controls.Add(this.lblPulse);
            this.grpMonitoring.Controls.Add(this.lblTemperature);
            this.grpMonitoring.Location = new System.Drawing.Point(13, 27);
            this.grpMonitoring.Name = "grpMonitoring";
            this.grpMonitoring.Size = new System.Drawing.Size(1122, 285);
            this.grpMonitoring.TabIndex = 0;
            this.grpMonitoring.TabStop = false;
            this.grpMonitoring.Text = "监测项目设置";
            // 
            // btnSaveJC
            // 
            this.btnSaveJC.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveJC.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSaveJC.Location = new System.Drawing.Point(407, 216);
            this.btnSaveJC.Name = "btnSaveJC";
            this.btnSaveJC.Size = new System.Drawing.Size(75, 23);
            this.btnSaveJC.TabIndex = 45;
            this.btnSaveJC.Text = "保存";
            this.btnSaveJC.Click += new System.EventHandler(this.btnSaveJC_Click);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(513, 132);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(35, 12);
            this.label45.TabIndex = 43;
            this.label45.Text = "次/天";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(513, 34);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(17, 12);
            this.label44.TabIndex = 42;
            this.label44.Text = "℃";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(513, 192);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 12);
            this.label43.TabIndex = 41;
            this.label43.Text = "mmHg";
            this.label43.Visible = false;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(513, 160);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(29, 12);
            this.label42.TabIndex = 40;
            this.label42.Text = "mmHg";
            this.label42.Visible = false;
            // 
            // txtStoolMin
            // 
            this.txtStoolMin.Location = new System.Drawing.Point(407, 128);
            this.txtStoolMin.Name = "txtStoolMin";
            this.txtStoolMin.Size = new System.Drawing.Size(100, 21);
            this.txtStoolMin.TabIndex = 39;
            this.txtStoolMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDBPMin
            // 
            this.txtDBPMin.Location = new System.Drawing.Point(407, 189);
            this.txtDBPMin.Name = "txtDBPMin";
            this.txtDBPMin.Size = new System.Drawing.Size(100, 21);
            this.txtDBPMin.TabIndex = 38;
            this.txtDBPMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDBPMin.Visible = false;
            // 
            // txtSBPMin
            // 
            this.txtSBPMin.Location = new System.Drawing.Point(407, 157);
            this.txtSBPMin.Name = "txtSBPMin";
            this.txtSBPMin.Size = new System.Drawing.Size(100, 21);
            this.txtSBPMin.TabIndex = 37;
            this.txtSBPMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSBPMin.Visible = false;
            // 
            // txtBreathMin
            // 
            this.txtBreathMin.Location = new System.Drawing.Point(407, 96);
            this.txtBreathMin.Name = "txtBreathMin";
            this.txtBreathMin.Size = new System.Drawing.Size(100, 21);
            this.txtBreathMin.TabIndex = 36;
            this.txtBreathMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPulseMin
            // 
            this.txtPulseMin.Location = new System.Drawing.Point(407, 64);
            this.txtPulseMin.Name = "txtPulseMin";
            this.txtPulseMin.Size = new System.Drawing.Size(100, 21);
            this.txtPulseMin.TabIndex = 35;
            this.txtPulseMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTemperatureMin
            // 
            this.txtTemperatureMin.Location = new System.Drawing.Point(407, 30);
            this.txtTemperatureMin.Name = "txtTemperatureMin";
            this.txtTemperatureMin.Size = new System.Drawing.Size(100, 21);
            this.txtTemperatureMin.TabIndex = 34;
            this.txtTemperatureMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(372, 132);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(29, 12);
            this.label41.TabIndex = 33;
            this.label41.Text = "≥：";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(372, 196);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(29, 12);
            this.label39.TabIndex = 32;
            this.label39.Text = "≥：";
            this.label39.Visible = false;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(372, 160);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 12);
            this.label40.TabIndex = 31;
            this.label40.Text = "≥：";
            this.label40.Visible = false;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(372, 100);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(29, 12);
            this.label38.TabIndex = 30;
            this.label38.Text = "≥：";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(372, 68);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(29, 12);
            this.label37.TabIndex = 29;
            this.label37.Text = "≥：";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(305, 132);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(35, 12);
            this.label36.TabIndex = 28;
            this.label36.Text = "次/天";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(305, 192);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(29, 12);
            this.label35.TabIndex = 27;
            this.label35.Text = "mmHg";
            this.label35.Visible = false;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(305, 160);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 26;
            this.label34.Text = "mmHg";
            this.label34.Visible = false;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(305, 100);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(35, 12);
            this.label33.TabIndex = 25;
            this.label33.Text = "次/分";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(372, 34);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 12);
            this.label32.TabIndex = 24;
            this.label32.Text = "≥：";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(513, 100);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(35, 12);
            this.label31.TabIndex = 23;
            this.label31.Text = "次/分";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(513, 68);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 12);
            this.label30.TabIndex = 22;
            this.label30.Text = "次/分";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(305, 68);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 12);
            this.label29.TabIndex = 21;
            this.label29.Text = "次/分";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(305, 34);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 12);
            this.label28.TabIndex = 20;
            this.label28.Text = "℃";
            // 
            // txtStoolMax
            // 
            this.txtStoolMax.Location = new System.Drawing.Point(199, 128);
            this.txtStoolMax.Name = "txtStoolMax";
            this.txtStoolMax.Size = new System.Drawing.Size(100, 21);
            this.txtStoolMax.TabIndex = 19;
            this.txtStoolMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(197, 192);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 12);
            this.label27.TabIndex = 18;
            this.label27.Text = "≤：";
            this.label27.Visible = false;
            // 
            // txtDBPMax
            // 
            this.txtDBPMax.Location = new System.Drawing.Point(232, 189);
            this.txtDBPMax.Name = "txtDBPMax";
            this.txtDBPMax.Size = new System.Drawing.Size(67, 21);
            this.txtDBPMax.TabIndex = 17;
            this.txtDBPMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDBPMax.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(197, 160);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 16;
            this.label26.Text = "≤：";
            this.label26.Visible = false;
            // 
            // txtSBPMax
            // 
            this.txtSBPMax.Location = new System.Drawing.Point(232, 157);
            this.txtSBPMax.Name = "txtSBPMax";
            this.txtSBPMax.Size = new System.Drawing.Size(67, 21);
            this.txtSBPMax.TabIndex = 15;
            this.txtSBPMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSBPMax.Visible = false;
            // 
            // txtBreathMax
            // 
            this.txtBreathMax.Location = new System.Drawing.Point(199, 96);
            this.txtBreathMax.Name = "txtBreathMax";
            this.txtBreathMax.Size = new System.Drawing.Size(100, 21);
            this.txtBreathMax.TabIndex = 14;
            this.txtBreathMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPulseMax
            // 
            this.txtPulseMax.Location = new System.Drawing.Point(199, 64);
            this.txtPulseMax.Name = "txtPulseMax";
            this.txtPulseMax.Size = new System.Drawing.Size(100, 21);
            this.txtPulseMax.TabIndex = 13;
            this.txtPulseMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTemperatureMax
            // 
            this.txtTemperatureMax.Location = new System.Drawing.Point(199, 30);
            this.txtTemperatureMax.Name = "txtTemperatureMax";
            this.txtTemperatureMax.Size = new System.Drawing.Size(100, 21);
            this.txtTemperatureMax.TabIndex = 12;
            this.txtTemperatureMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(164, 132);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 11;
            this.label25.Text = "≤：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(164, 100);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 12);
            this.label24.TabIndex = 10;
            this.label24.Text = "≤：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(164, 68);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 9;
            this.label23.Text = "≤：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(164, 34);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 8;
            this.label22.Text = "≤：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(105, 160);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 7;
            this.label21.Text = "血压：";
            this.label21.Visible = false;
            // 
            // lblSBP
            // 
            this.lblSBP.AutoSize = true;
            this.lblSBP.Location = new System.Drawing.Point(152, 160);
            this.lblSBP.Name = "lblSBP";
            this.lblSBP.Size = new System.Drawing.Size(41, 12);
            this.lblSBP.TabIndex = 6;
            this.lblSBP.Text = "收缩压";
            this.lblSBP.Visible = false;
            // 
            // lblBreath
            // 
            this.lblBreath.AutoSize = true;
            this.lblBreath.Location = new System.Drawing.Point(105, 100);
            this.lblBreath.Name = "lblBreath";
            this.lblBreath.Size = new System.Drawing.Size(41, 12);
            this.lblBreath.TabIndex = 5;
            this.lblBreath.Text = "呼吸：";
            // 
            // lblDBP
            // 
            this.lblDBP.AutoSize = true;
            this.lblDBP.Location = new System.Drawing.Point(152, 189);
            this.lblDBP.Name = "lblDBP";
            this.lblDBP.Size = new System.Drawing.Size(41, 12);
            this.lblDBP.TabIndex = 4;
            this.lblDBP.Text = "舒张压";
            this.lblDBP.Visible = false;
            // 
            // lblStool
            // 
            this.lblStool.AutoSize = true;
            this.lblStool.Location = new System.Drawing.Point(105, 133);
            this.lblStool.Name = "lblStool";
            this.lblStool.Size = new System.Drawing.Size(41, 12);
            this.lblStool.TabIndex = 3;
            this.lblStool.Text = "大便：";
            // 
            // lblPulse
            // 
            this.lblPulse.AutoSize = true;
            this.lblPulse.Location = new System.Drawing.Point(105, 67);
            this.lblPulse.Name = "lblPulse";
            this.lblPulse.Size = new System.Drawing.Size(41, 12);
            this.lblPulse.TabIndex = 2;
            this.lblPulse.Text = "脉搏：";
            // 
            // lblTemperature
            // 
            this.lblTemperature.AutoSize = true;
            this.lblTemperature.Location = new System.Drawing.Point(105, 34);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(41, 12);
            this.lblTemperature.TabIndex = 1;
            this.lblTemperature.Text = "体温：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(199, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(308, 14);
            this.label14.TabIndex = 0;
            this.label14.Text = "体温记录表批量录入页面(合法数值范围设置)";
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(201)))), ((int)(((byte)(235)))));
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.Controls.Add(this.tabControlPanel8);
            this.tabControl2.Controls.Add(this.tabControlPanel6);
            this.tabControl2.Controls.Add(this.tabControlPanel2);
            this.tabControl2.Controls.Add(this.tabControlPanel4);
            this.tabControl2.Controls.Add(this.tabControlPanel3);
            this.tabControl2.Controls.Add(this.tabControlPanel5);
            this.tabControl2.Controls.Add(this.tabControlPanel7);
            this.tabControl2.Controls.Add(this.tabControlPanel1);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1016, 734);
            this.tabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl2.TabIndex = 1;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem1);
            this.tabControl2.Tabs.Add(this.tabItem7);
            this.tabControl2.Tabs.Add(this.tabItem2);
            this.tabControl2.Tabs.Add(this.tabItem3);
            this.tabControl2.Tabs.Add(this.tabItem4);
            this.tabControl2.Tabs.Add(this.tabItem5);
            this.tabControl2.Tabs.Add(this.tabItem6);
            this.tabControl2.Tabs.Add(this.tabItem8);
            this.tabControl2.Text = "tabControl2";
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(1016, 709);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 5;
            this.tabControlPanel5.TabItem = this.tabItem5;
            // 
            // tabItem5
            // 
            this.tabItem5.AttachedControl = this.tabControlPanel5;
            this.tabItem5.Name = "tabItem5";
            this.tabItem5.Text = "客观评分";
            this.tabItem5.Visible = false;
            // 
            // tabControlPanel6
            // 
            this.tabControlPanel6.Controls.Add(this.ucDocument_statistics2);
            this.tabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel6.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel6.Name = "tabControlPanel6";
            this.tabControlPanel6.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel6.Size = new System.Drawing.Size(1016, 709);
            this.tabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel6.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel6.Style.GradientAngle = 90;
            this.tabControlPanel6.TabIndex = 6;
            this.tabControlPanel6.TabItem = this.tabItem6;
            // 
            // ucDocument_statistics2
            // 
            this.ucDocument_statistics2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDocument_statistics2.Location = new System.Drawing.Point(1, 1);
            this.ucDocument_statistics2.Name = "ucDocument_statistics2";
            this.ucDocument_statistics2.Size = new System.Drawing.Size(1014, 707);
            this.ucDocument_statistics2.TabIndex = 0;
            // 
            // tabItem6
            // 
            this.tabItem6.AttachedControl = this.tabControlPanel6;
            this.tabItem6.Name = "tabItem6";
            this.tabItem6.Text = "文书统计报表";
            this.tabItem6.Visible = false;
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.caseSearchMark1);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1016, 709);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // caseSearchMark1
            // 
            this.caseSearchMark1.BackColor = System.Drawing.Color.Transparent;
            this.caseSearchMark1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caseSearchMark1.Location = new System.Drawing.Point(1, 1);
            this.caseSearchMark1.Name = "caseSearchMark1";
            this.caseSearchMark1.Size = new System.Drawing.Size(1014, 707);
            this.caseSearchMark1.TabIndex = 0;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "病案查阅";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.splitContainer1);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1016, 709);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "护理部调度参数";
            this.tabItem2.Visible = false;
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(1016, 709);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 4;
            this.tabControlPanel4.TabItem = this.tabItem4;
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanel4;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "实时监控";
            this.tabItem4.Visible = false;
            // 
            // tabControlPanel7
            // 
            this.tabControlPanel7.Controls.Add(this.userfrmQueryLevy1);
            this.tabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel7.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel7.Name = "tabControlPanel7";
            this.tabControlPanel7.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel7.Size = new System.Drawing.Size(1016, 709);
            this.tabControlPanel7.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel7.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel7.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel7.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel7.Style.GradientAngle = 90;
            this.tabControlPanel7.TabIndex = 7;
            this.tabControlPanel7.TabItem = this.tabItem7;
            // 
            // userfrmQueryLevy1
            // 
            this.userfrmQueryLevy1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userfrmQueryLevy1.Location = new System.Drawing.Point(1, 1);
            this.userfrmQueryLevy1.Name = "userfrmQueryLevy1";
            this.userfrmQueryLevy1.Size = new System.Drawing.Size(1014, 707);
            this.userfrmQueryLevy1.TabIndex = 0;
            // 
            // tabItem7
            // 
            this.tabItem7.AttachedControl = this.tabControlPanel7;
            this.tabItem7.Name = "tabItem7";
            this.tabItem7.Text = "在院病人病案查阅";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.label14);
            this.tabControlPanel3.Controls.Add(this.grpMonitoring);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(1016, 709);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "监测值";
            // 
            // tabItem8
            // 
            this.tabItem8.AttachedControl = this.tabControlPanel8;
            this.tabItem8.Name = "tabItem8";
            this.tabItem8.Text = "实时监控";
            // 
            // tabControlPanel8
            // 
            this.tabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel8.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel8.Name = "tabControlPanel8";
            this.tabControlPanel8.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel8.Size = new System.Drawing.Size(1016, 709);
            this.tabControlPanel8.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel8.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel8.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel8.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel8.Style.GradientAngle = 90;
            this.tabControlPanel8.TabIndex = 8;
            this.tabControlPanel8.TabItem = this.tabItem8;
            // 
            // ucUCEParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl2);
            this.DoubleBuffered = true;
            this.Name = "ucUCEParam";
            this.Size = new System.Drawing.Size(1016, 734);
            this.Load += new System.EventHandler(this.frmUCEParam_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuQuality.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gpbFixTime.ResumeLayout(false);
            this.gpbFixTime.PerformLayout();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel4.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.grpMonitoring.ResumeLayout(false);
            this.grpMonitoring.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel6.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabControlPanel7.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboTextKind;
        private System.Windows.Forms.ComboBox cboMonitoring;
        private System.Windows.Forms.ComboBox cboMonitorType;
        private System.Windows.Forms.ComboBox cboCKTime;
        private System.Windows.Forms.TextBox txtExecCycles;
        private System.Windows.Forms.ComboBox cboCyclesUnit;
        private System.Windows.Forms.RadioButton rdoIsOverAlertF;
        private System.Windows.Forms.RadioButton rdoIsOverAlert;
        private System.Windows.Forms.RadioButton rdoIsCheckF;
        private System.Windows.Forms.RadioButton rdoIsCheck;
        private System.Windows.Forms.RadioButton rdoIsMendF;
        private System.Windows.Forms.RadioButton rdoIsMend;
        private System.Windows.Forms.TextBox txtDeduction;
        private System.Windows.Forms.RadioButton rdoIsNoticeF;
        private System.Windows.Forms.RadioButton rdoIsNotice;
        private System.Windows.Forms.TextBox txtPrealertTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboPrealertUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDayShift;
        private System.Windows.Forms.TextBox txtDNightShift;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtXNightShift;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chk1am;
        private System.Windows.Forms.CheckBox chk10pm;
        private System.Windows.Forms.CheckBox chk6pm;
        private System.Windows.Forms.CheckBox chk2pm;
        private System.Windows.Forms.CheckBox chk10am;
        private System.Windows.Forms.CheckBox chk6am;
        private System.Windows.Forms.CheckBox chk2am;
        private System.Windows.Forms.RadioButton rdoSingle;
        private System.Windows.Forms.RadioButton rdoDouble;
        private System.Windows.Forms.ListView lvwQualitys;
        private System.Windows.Forms.ColumnHeader columnHeader;
        private System.Windows.Forms.TextBox txtItemMax;
        private System.Windows.Forms.Label lblItemMax;
        private System.Windows.Forms.TextBox txtItemMin;
        private System.Windows.Forms.Label lblItemMin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtExceTimes;
        private System.Windows.Forms.ContextMenuStrip contextMenuQuality;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox grpMonitoring;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblSBP;
        private System.Windows.Forms.Label lblBreath;
        private System.Windows.Forms.Label lblDBP;
        private System.Windows.Forms.Label lblStool;
        private System.Windows.Forms.Label lblPulse;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtTemperatureMax;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txtSBPMax;
        private System.Windows.Forms.TextBox txtBreathMax;
        private System.Windows.Forms.TextBox txtPulseMax;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txtDBPMax;
        private System.Windows.Forms.TextBox txtStoolMax;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox txtTemperatureMin;
        private System.Windows.Forms.TextBox txtStoolMin;
        private System.Windows.Forms.TextBox txtDBPMin;
        private System.Windows.Forms.TextBox txtSBPMin;
        private System.Windows.Forms.TextBox txtBreathMin;
        private System.Windows.Forms.TextBox txtPulseMin;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.TabItem tabItem5;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupBox1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.Controls.GroupPanel gpbFixTime;
        private DevComponents.DotNetBar.ButtonX btnReset;
        private DevComponents.DotNetBar.ButtonX button1;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnSaveJC;
        private Base_Function.BLL_MANAGEMENT.SICKFILE.CaseSearchMark caseSearchMark1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel6;
        private Base_Function.BLL_MANAGEMENT.NURSE_MANAGE.ucDocument_statistics ucDocument_statistics2;
        private DevComponents.DotNetBar.TabItem tabItem6;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel7;
        private DevComponents.DotNetBar.TabItem tabItem7;
        private UserfrmQueryLevy userfrmQueryLevy1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel8;
        private DevComponents.DotNetBar.TabItem tabItem8;
    }
}