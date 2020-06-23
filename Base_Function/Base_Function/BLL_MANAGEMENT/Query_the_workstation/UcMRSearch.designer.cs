namespace Base_Function.BLL_MANAGEMENT
{
    partial class UcMRSearch
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
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.ckboxFirstDiagnose = new System.Windows.Forms.CheckBox();
            this.cmbDiagnoseType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtDiagnose = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cmbDateType = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtAgeMax = new System.Windows.Forms.TextBox();
            this.txtAgeMin = new System.Windows.Forms.TextBox();
            this.cmbAgeUnit = new System.Windows.Forms.ComboBox();
            this.cmbPatientType = new System.Windows.Forms.ComboBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl1.SelectedTabIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1240, 558);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Flat;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.groupPanel2);
            this.tabControlPanel1.Controls.Add(this.groupPanel1);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1240, 533);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucC1FlexGrid1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(1, 124);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1238, 408);
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
            this.groupPanel2.TabIndex = 1;
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(1232, 402);
            this.ucC1FlexGrid1.TabIndex = 2;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.buttonX1);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.txtCount);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.label9);
            this.groupPanel1.Controls.Add(this.ckboxFirstDiagnose);
            this.groupPanel1.Controls.Add(this.cmbDiagnoseType);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.radioButton2);
            this.groupPanel1.Controls.Add(this.radioButton1);
            this.groupPanel1.Controls.Add(this.txtDiagnose);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.dateTimePicker1);
            this.groupPanel1.Controls.Add(this.dtpStart);
            this.groupPanel1.Controls.Add(this.cmbDateType);
            this.groupPanel1.Controls.Add(this.checkBox1);
            this.groupPanel1.Controls.Add(this.textBox2);
            this.groupPanel1.Controls.Add(this.linkLabel2);
            this.groupPanel1.Controls.Add(this.textBox1);
            this.groupPanel1.Controls.Add(this.linkLabel1);
            this.groupPanel1.Controls.Add(this.txtAgeMax);
            this.groupPanel1.Controls.Add(this.txtAgeMin);
            this.groupPanel1.Controls.Add(this.cmbAgeUnit);
            this.groupPanel1.Controls.Add(this.cmbPatientType);
            this.groupPanel1.Controls.Add(this.cmbState);
            this.groupPanel1.Controls.Add(this.cmbSection);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(1, 1);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1238, 123);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "查询条件";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(891, 68);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(67, 27);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 41;
            this.buttonX1.Text = "导出Excel";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(818, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(67, 27);
            this.btnSearch.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSearch.TabIndex = 40;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(1004, 51);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(66, 21);
            this.txtCount.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(1076, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 38;
            this.label10.Text = "份";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(981, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 12);
            this.label9.TabIndex = 37;
            this.label9.Text = "共";
            // 
            // ckboxFirstDiagnose
            // 
            this.ckboxFirstDiagnose.AutoSize = true;
            this.ckboxFirstDiagnose.BackColor = System.Drawing.Color.Transparent;
            this.ckboxFirstDiagnose.Location = new System.Drawing.Point(605, 56);
            this.ckboxFirstDiagnose.Name = "ckboxFirstDiagnose";
            this.ckboxFirstDiagnose.Size = new System.Drawing.Size(60, 16);
            this.ckboxFirstDiagnose.TabIndex = 34;
            this.ckboxFirstDiagnose.Text = "主诊断";
            this.ckboxFirstDiagnose.UseVisualStyleBackColor = false;
            // 
            // cmbDiagnoseType
            // 
            this.cmbDiagnoseType.FormattingEnabled = true;
            this.cmbDiagnoseType.Location = new System.Drawing.Point(486, 54);
            this.cmbDiagnoseType.Name = "cmbDiagnoseType";
            this.cmbDiagnoseType.Size = new System.Drawing.Size(113, 20);
            this.cmbDiagnoseType.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(405, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 32;
            this.label8.Text = "诊断类型:";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Location = new System.Drawing.Point(317, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 31;
            this.radioButton2.Text = "精确";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(262, 56);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 30;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "模糊";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // txtDiagnose
            // 
            this.txtDiagnose.Location = new System.Drawing.Point(53, 54);
            this.txtDiagnose.Name = "txtDiagnose";
            this.txtDiagnose.Size = new System.Drawing.Size(203, 21);
            this.txtDiagnose.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(1098, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(941, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(849, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 26;
            this.label5.Text = "年龄:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(405, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "患者类型:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(246, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "状态:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "科室:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(1, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "诊断:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1125, 27);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(105, 21);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(987, 26);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(105, 21);
            this.dtpStart.TabIndex = 19;
            // 
            // cmbDateType
            // 
            this.cmbDateType.FormattingEnabled = true;
            this.cmbDateType.Items.AddRange(new object[] {
            "入院时间",
            "出院时间",
            "死亡时间"});
            this.cmbDateType.Location = new System.Drawing.Point(891, 26);
            this.cmbDateType.Name = "cmbDateType";
            this.cmbDateType.Size = new System.Drawing.Size(90, 20);
            this.cmbDateType.TabIndex = 18;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Location = new System.Drawing.Point(825, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(60, 16);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "按日期";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(486, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(314, 21);
            this.textBox2.TabIndex = 16;
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(405, 31);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(59, 12);
            this.linkLabel2.TabIndex = 15;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "文    书:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(53, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(314, 21);
            this.textBox1.TabIndex = 14;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(1, 31);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 12);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "症状:";
            // 
            // txtAgeMax
            // 
            this.txtAgeMax.Location = new System.Drawing.Point(964, 0);
            this.txtAgeMax.Name = "txtAgeMax";
            this.txtAgeMax.Size = new System.Drawing.Size(47, 21);
            this.txtAgeMax.TabIndex = 12;
            // 
            // txtAgeMin
            // 
            this.txtAgeMin.Location = new System.Drawing.Point(891, 1);
            this.txtAgeMin.Name = "txtAgeMin";
            this.txtAgeMin.Size = new System.Drawing.Size(45, 21);
            this.txtAgeMin.TabIndex = 11;
            // 
            // cmbAgeUnit
            // 
            this.cmbAgeUnit.FormattingEnabled = true;
            this.cmbAgeUnit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天",
            "小时"});
            this.cmbAgeUnit.Location = new System.Drawing.Point(1022, 1);
            this.cmbAgeUnit.Name = "cmbAgeUnit";
            this.cmbAgeUnit.Size = new System.Drawing.Size(38, 20);
            this.cmbAgeUnit.TabIndex = 10;
            // 
            // cmbPatientType
            // 
            this.cmbPatientType.FormattingEnabled = true;
            this.cmbPatientType.Items.AddRange(new object[] {
            "请选择",
            "手术",
            "死亡",
            "转科",
            "会诊",
            "病危",
            "病重"});
            this.cmbPatientType.Location = new System.Drawing.Point(486, 3);
            this.cmbPatientType.Name = "cmbPatientType";
            this.cmbPatientType.Size = new System.Drawing.Size(90, 20);
            this.cmbPatientType.TabIndex = 6;
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Items.AddRange(new object[] {
            "请选择",
            "出院",
            "在院",
            "归档",
            "出院未归档"});
            this.cmbState.Location = new System.Drawing.Point(287, 2);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(80, 20);
            this.cmbState.TabIndex = 4;
            // 
            // cmbSection
            // 
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(53, 1);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(148, 20);
            this.cmbSection.TabIndex = 3;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "病历查询";
            // 
            // UcMRSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "UcMRSearch";
            this.Size = new System.Drawing.Size(1240, 558);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private System.Windows.Forms.ComboBox cmbPatientType;
        private System.Windows.Forms.ComboBox cmbState;
        private System.Windows.Forms.ComboBox cmbSection;
        private System.Windows.Forms.ComboBox cmbAgeUnit;
        private System.Windows.Forms.TextBox txtAgeMin;
        private System.Windows.Forms.TextBox txtAgeMax;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ComboBox cmbDateType;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckboxFirstDiagnose;
        private System.Windows.Forms.ComboBox cmbDiagnoseType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txtDiagnose;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}
