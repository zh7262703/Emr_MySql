namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    partial class ucfrmMainGradeRepart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucfrmMainGradeRepart));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmnspDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pingfentoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.c1FlexGrid1 = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.cboxRand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerIN_OUT_time = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxSick = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btntransitorily_Save = new DevComponents.DotNetBar.ButtonX();
            this.btnAddGrade = new DevComponents.DotNetBar.ButtonX();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboxSickname = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button5 = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.ctmnspDelete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1Sel";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.toolStripMenuItem1.Text = "查看";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // ctmnspDelete
            // 
            this.ctmnspDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pingfentoolStripMenuItem1,
            this.删除ToolStripMenuItem});
            this.ctmnspDelete.Name = "ctmnspDelete";
            this.ctmnspDelete.Size = new System.Drawing.Size(95, 48);
            // 
            // pingfentoolStripMenuItem1
            // 
            this.pingfentoolStripMenuItem1.Name = "pingfentoolStripMenuItem1";
            this.pingfentoolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.pingfentoolStripMenuItem1.Text = "评分";
            this.pingfentoolStripMenuItem1.Click += new System.EventHandler(this.pingfentoolStripMenuItem1_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.Transparent;
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.Controls.Add(this.tabControlPanel1);
            this.tabControl2.Controls.Add(this.tabControlPanel2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(971, 816);
            this.tabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.Flat;
            this.tabControl2.TabIndex = 2;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem1);
            this.tabControl2.Tabs.Add(this.tabItem2);
            this.tabControl2.Text = "tabControl2";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.panel2);
            this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(971, 791);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.c1FlexGrid1);
            this.panel2.Controls.Add(this.groupPanel1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(969, 789);
            this.panel2.TabIndex = 2;
            // 
            // c1FlexGrid1
            // 
            this.c1FlexGrid1.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.c1FlexGrid1.ColumnInfo = "10,1,0,0,0,0,Columns:1{Width:0;}\t";
            this.c1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1FlexGrid1.Location = new System.Drawing.Point(0, 77);
            this.c1FlexGrid1.Name = "c1FlexGrid1";
            this.c1FlexGrid1.Rows.DefaultSize = 20;
            this.c1FlexGrid1.Size = new System.Drawing.Size(969, 663);
            this.c1FlexGrid1.StyleInfo = resources.GetString("c1FlexGrid1.StyleInfo");
            this.c1FlexGrid1.TabIndex = 1;
            this.c1FlexGrid1.Click += new System.EventHandler(this.c1FlexGrid1_Click);
            this.c1FlexGrid1.DoubleClick += new System.EventHandler(this.c1FlexGrid1_DoubleClick);
            this.c1FlexGrid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.c1FlexGrid1_MouseClick);
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnQuery);
            this.groupPanel1.Controls.Add(this.cboxRand);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.dateTimePickerIN_OUT_time);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cboxSick);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(969, 77);
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
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "查询";
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(654, 15);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 14;
            this.btnQuery.Text = "查 询";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // cboxRand
            // 
            this.cboxRand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRand.FormattingEnabled = true;
            this.cboxRand.Location = new System.Drawing.Point(564, 16);
            this.cboxRand.Name = "cboxRand";
            this.cboxRand.Size = new System.Drawing.Size(79, 20);
            this.cboxRand.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "随机抽取：";
            // 
            // dateTimePickerIN_OUT_time
            // 
            this.dateTimePickerIN_OUT_time.CustomFormat = "yyyy-MM";
            this.dateTimePickerIN_OUT_time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerIN_OUT_time.Location = new System.Drawing.Point(392, 16);
            this.dateTimePickerIN_OUT_time.Name = "dateTimePickerIN_OUT_time";
            this.dateTimePickerIN_OUT_time.Size = new System.Drawing.Size(85, 21);
            this.dateTimePickerIN_OUT_time.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "出区/死亡年月：";
            // 
            // cboxSick
            // 
            this.cboxSick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSick.FormattingEnabled = true;
            this.cboxSick.Location = new System.Drawing.Point(86, 16);
            this.cboxSick.Name = "cboxSick";
            this.cboxSick.Size = new System.Drawing.Size(189, 20);
            this.cboxSick.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "病人科室：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btntransitorily_Save);
            this.panel1.Controls.Add(this.btnAddGrade);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 740);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 49);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(532, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保 存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btntransitorily_Save
            // 
            this.btntransitorily_Save.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btntransitorily_Save.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btntransitorily_Save.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btntransitorily_Save.Enabled = false;
            this.btntransitorily_Save.Location = new System.Drawing.Point(451, 13);
            this.btntransitorily_Save.Name = "btntransitorily_Save";
            this.btntransitorily_Save.Size = new System.Drawing.Size(75, 23);
            this.btntransitorily_Save.TabIndex = 4;
            this.btntransitorily_Save.Text = "暂 存";
            this.btntransitorily_Save.Visible = false;
            this.btntransitorily_Save.Click += new System.EventHandler(this.btntransitorily_Save_Click);
            // 
            // btnAddGrade
            // 
            this.btnAddGrade.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddGrade.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddGrade.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddGrade.Location = new System.Drawing.Point(350, 13);
            this.btnAddGrade.Name = "btnAddGrade";
            this.btnAddGrade.Size = new System.Drawing.Size(95, 23);
            this.btnAddGrade.TabIndex = 3;
            this.btnAddGrade.Text = "新增评分病历";
            this.btnAddGrade.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "生成评分";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.ucC1FlexGrid1);
            this.tabControlPanel2.Controls.Add(this.groupPanel2);
            this.tabControlPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(971, 791);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.SystemColors.Control;
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDark;
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.AutoScroll = true;
            this.ucC1FlexGrid1.BackColor = System.Drawing.Color.Transparent;
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(1, 79);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(969, 711);
            this.ucC1FlexGrid1.TabIndex = 2;
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
            this.ucC1FlexGrid1.DoubleClick += new System.EventHandler(this.ucC1FlexGrid1_DoubleClick);
            this.ucC1FlexGrid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ucC1FlexGrid1_MouseClick);
            // 
            // groupPanel2
            // 
            this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel2.CanvasColor = System.Drawing.Color.Transparent;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.cboxSickname);
            this.groupPanel2.Controls.Add(this.label4);
            this.groupPanel2.Controls.Add(this.button5);
            this.groupPanel2.Controls.Add(this.label5);
            this.groupPanel2.Controls.Add(this.dateTimePicker2);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(1, 1);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(969, 78);
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
            this.groupPanel2.TabIndex = 7;
            this.groupPanel2.Text = "查询";
            // 
            // cboxSickname
            // 
            this.cboxSickname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxSickname.FormattingEnabled = true;
            this.cboxSickname.Location = new System.Drawing.Point(87, 16);
            this.cboxSickname.Name = "cboxSickname";
            this.cboxSickname.Size = new System.Drawing.Size(189, 20);
            this.cboxSickname.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "评分科室：";
            // 
            // button5
            // 
            this.button5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.button5.Location = new System.Drawing.Point(488, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "查 询";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "评分年月查询：";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "yyyy-MM";
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(391, 16);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(84, 21);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "历史评分";
            // 
            // ucfrmMainGradeRepart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabControl2);
            this.Name = "ucfrmMainGradeRepart";
            this.Size = new System.Drawing.Size(971, 816);
            this.Load += new System.EventHandler(this.frmMainGradeRepart_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ctmnspDelete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1FlexGrid1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.ContextMenuStrip ctmnspDelete;
        private System.Windows.Forms.ToolStripMenuItem pingfentoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private C1.Win.C1FlexGrid.C1FlexGrid c1FlexGrid1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.ComboBox cboxRand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerIN_OUT_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxSick;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btntransitorily_Save;
        private DevComponents.DotNetBar.ButtonX btnAddGrade;
        private DevComponents.DotNetBar.ButtonX button5;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private System.Windows.Forms.ComboBox cboxSickname;
        private System.Windows.Forms.Label label4;
    }
}
