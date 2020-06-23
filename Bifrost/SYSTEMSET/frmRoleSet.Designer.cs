namespace Bifrost
{
    partial class frmRoleSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoleSet));
            this.trvRoles = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolMenuUseful = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuUnUseful = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnGenRole = new System.Windows.Forms.Button();
            this.cboRoleType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trvPerssions = new System.Windows.Forms.TreeView();
            this.trvPerssionsButton = new System.Windows.Forms.TreeView();
            this.cboRoleState = new System.Windows.Forms.ComboBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.trvTextRole = new System.Windows.Forms.TreeView();
            this.imgList_TextTree = new System.Windows.Forms.ImageList(this.components);
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLevelSet = new System.Windows.Forms.Button();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.contextMenuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvRoles
            // 
            this.trvRoles.ContextMenuStrip = this.contextMenuStrip1;
            this.trvRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvRoles.HideSelection = false;
            this.trvRoles.ImageIndex = 0;
            this.trvRoles.ImageList = this.imageList1;
            this.trvRoles.Location = new System.Drawing.Point(0, 0);
            this.trvRoles.Name = "trvRoles";
            this.trvRoles.SelectedImageIndex = 0;
            this.trvRoles.Size = new System.Drawing.Size(254, 415);
            this.trvRoles.TabIndex = 0;
            this.trvRoles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvRoles_NodeMouseClick);
            this.trvRoles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvRoles_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolMenuUseful,
            this.toolMenuUnUseful,
            this.toolMenuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 76);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolMenuUseful
            // 
            this.toolMenuUseful.Name = "toolMenuUseful";
            this.toolMenuUseful.Size = new System.Drawing.Size(108, 24);
            this.toolMenuUseful.Text = "启用";
            this.toolMenuUseful.Click += new System.EventHandler(this.toolMenuUseful_Click);
            // 
            // toolMenuUnUseful
            // 
            this.toolMenuUnUseful.Name = "toolMenuUnUseful";
            this.toolMenuUnUseful.Size = new System.Drawing.Size(108, 24);
            this.toolMenuUnUseful.Text = "停用";
            this.toolMenuUnUseful.Click += new System.EventHandler(this.toolMenuUnUseful_Click);
            // 
            // toolMenuDelete
            // 
            this.toolMenuDelete.Name = "toolMenuDelete";
            this.toolMenuDelete.Size = new System.Drawing.Size(108, 24);
            this.toolMenuDelete.Text = "删除";
            this.toolMenuDelete.Click += new System.EventHandler(this.toolMenuDelete_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "external2.ico");
            this.imageList1.Images.SetKeyName(1, "FONTSF~1.ICO");
            this.imageList1.Images.SetKeyName(2, "BLBOOK~1.ICO");
            // 
            // btnGenRole
            // 
            this.btnGenRole.Enabled = false;
            this.btnGenRole.Location = new System.Drawing.Point(333, 7);
            this.btnGenRole.Name = "btnGenRole";
            this.btnGenRole.Size = new System.Drawing.Size(164, 28);
            this.btnGenRole.TabIndex = 29;
            this.btnGenRole.Text = "根据职务生成相关角色";
            this.btnGenRole.UseVisualStyleBackColor = true;
            this.btnGenRole.Click += new System.EventHandler(this.btnGenRole_Click);
            // 
            // cboRoleType
            // 
            this.cboRoleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleType.FormattingEnabled = true;
            this.cboRoleType.Items.AddRange(new object[] {
            "医生",
            "护士",
            "护理部",
            "医务处",
            "病案室",
            "管理员",
            "质控科",
            "院感科",
            "其他"});
            this.cboRoleType.Location = new System.Drawing.Point(105, 75);
            this.cboRoleType.Name = "cboRoleType";
            this.cboRoleType.Size = new System.Drawing.Size(164, 23);
            this.cboRoleType.TabIndex = 28;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 9F);
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(18, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 27;
            this.label4.Text = "角色类型：";
            // 
            // trvPerssions
            // 
            this.trvPerssions.CheckBoxes = true;
            this.trvPerssions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvPerssions.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvPerssions.ImageIndex = 1;
            this.trvPerssions.ImageList = this.imageList1;
            this.trvPerssions.Location = new System.Drawing.Point(1, 1);
            this.trvPerssions.Name = "trvPerssions";
            this.trvPerssions.SelectedImageIndex = 1;
            this.trvPerssions.Size = new System.Drawing.Size(682, 157);
            this.trvPerssions.TabIndex = 6;
            this.trvPerssions.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvPerssions_AfterCheck);
            this.trvPerssions.Click += new System.EventHandler(this.trvPerssions_Click);
            // 
            // trvPerssionsButton
            // 
            this.trvPerssionsButton.CheckBoxes = true;
            this.trvPerssionsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvPerssionsButton.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvPerssionsButton.ImageIndex = 2;
            this.trvPerssionsButton.ImageList = this.imageList1;
            this.trvPerssionsButton.Location = new System.Drawing.Point(1, 1);
            this.trvPerssionsButton.Name = "trvPerssionsButton";
            this.trvPerssionsButton.SelectedImageIndex = 2;
            this.trvPerssionsButton.Size = new System.Drawing.Size(682, 157);
            this.trvPerssionsButton.TabIndex = 0;
            // 
            // cboRoleState
            // 
            this.cboRoleState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoleState.FormattingEnabled = true;
            this.cboRoleState.Items.AddRange(new object[] {
            "有效",
            "无效"});
            this.cboRoleState.Location = new System.Drawing.Point(105, 43);
            this.cboRoleState.Name = "cboRoleState";
            this.cboRoleState.Size = new System.Drawing.Size(164, 23);
            this.cboRoleState.TabIndex = 3;
            // 
            // txtRoleName
            // 
            this.txtRoleName.Location = new System.Drawing.Point(105, 10);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(164, 25);
            this.txtRoleName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(18, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "角色状态：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "角色名称：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.trvRoles);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(260, 442);
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
            this.groupPanel1.Text = "角色列表";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.groupBox1);
            this.groupPanel2.Controls.Add(this.panel3);
            this.groupPanel2.Controls.Add(this.panel1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(271, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(696, 442);
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
            this.groupPanel2.Text = "角色编辑";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.tabControl2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(690, 211);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "权限设置";
            // 
            // tabControl2
            // 
            this.tabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.Controls.Add(this.tabControlPanel1);
            this.tabControl2.Controls.Add(this.tabControlPanel3);
            this.tabControl2.Controls.Add(this.tabControlPanel2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl2.Location = new System.Drawing.Point(3, 21);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 1;
            this.tabControl2.Size = new System.Drawing.Size(684, 187);
            this.tabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl2.TabIndex = 30;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem1);
            this.tabControl2.Tabs.Add(this.tabItem2);
            this.tabControl2.Tabs.Add(this.tabItem3);
            this.tabControl2.Text = "tabControl2";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.trvPerssions);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(684, 159);
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
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "菜单权限";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.trvTextRole);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(684, 159);
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
            // trvTextRole
            // 
            this.trvTextRole.CheckBoxes = true;
            this.trvTextRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvTextRole.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.trvTextRole.ImageIndex = 1;
            this.trvTextRole.ImageList = this.imgList_TextTree;
            this.trvTextRole.Location = new System.Drawing.Point(1, 1);
            this.trvTextRole.Name = "trvTextRole";
            this.trvTextRole.SelectedImageIndex = 1;
            this.trvTextRole.Size = new System.Drawing.Size(682, 157);
            this.trvTextRole.TabIndex = 7;
            this.trvTextRole.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvTextRole_AfterCheck);
            this.trvTextRole.Click += new System.EventHandler(this.trvTextRole_Click);
            // 
            // imgList_TextTree
            // 
            this.imgList_TextTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList_TextTree.ImageStream")));
            this.imgList_TextTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList_TextTree.Images.SetKeyName(0, "单例文书.png");
            this.imgList_TextTree.Images.SetKeyName(1, "多例文书.png");
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "查看文书权限";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.trvPerssionsButton);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 28);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(684, 159);
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
            this.tabItem2.Text = "按钮权限";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnSure);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 347);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(690, 68);
            this.panel3.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(398, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 31);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(62, 17);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(91, 31);
            this.btnAdd.TabIndex = 31;
            this.btnAdd.Text = "添加(&S)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(174, 17);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 31);
            this.btnUpdate.TabIndex = 32;
            this.btnUpdate.Text = "修改(&M)";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(286, 17);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(91, 31);
            this.btnSure.TabIndex = 33;
            this.btnSure.Text = "保存(&S)";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnLevelSet);
            this.panel1.Controls.Add(this.cboRoleState);
            this.panel1.Controls.Add(this.txtRoleName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cboRoleType);
            this.panel1.Controls.Add(this.btnGenRole);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 136);
            this.panel1.TabIndex = 35;
            // 
            // btnLevelSet
            // 
            this.btnLevelSet.Location = new System.Drawing.Point(333, 40);
            this.btnLevelSet.Name = "btnLevelSet";
            this.btnLevelSet.Size = new System.Drawing.Size(164, 28);
            this.btnLevelSet.TabIndex = 34;
            this.btnLevelSet.Text = "设置角色和职称级别";
            this.btnLevelSet.UseVisualStyleBackColor = true;
            this.btnLevelSet.Click += new System.EventHandler(this.btnLevelSet_Click);
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.groupPanel1;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(260, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(11, 442);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 2;
            this.expandableSplitter1.TabStop = false;
            // 
            // frmRoleSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.groupPanel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmRoleSet";
            this.Size = new System.Drawing.Size(967, 442);
            this.Load += new System.EventHandler(this.frmRoleSet_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvRoles;
        private System.Windows.Forms.ComboBox cboRoleState;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView trvPerssions;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolMenuUseful;
        private System.Windows.Forms.ToolStripMenuItem toolMenuUnUseful;
        private System.Windows.Forms.TreeView trvPerssionsButton;
        private System.Windows.Forms.ToolStripMenuItem toolMenuDelete;
        private System.Windows.Forms.ComboBox cboRoleType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenRole;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.Button btnLevelSet;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private System.Windows.Forms.TreeView trvTextRole;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private System.Windows.Forms.ImageList imgList_TextTree;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}