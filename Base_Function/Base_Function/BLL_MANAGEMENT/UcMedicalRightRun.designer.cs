namespace Base_Function.BLL_MANAGEMENT
{
    partial class UcMedicalRightRun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMedicalRightRun));
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.trvAccount = new DevComponents.AdvTree.AdvTree();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblInTime = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTech_Post = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSick_area = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnRight = new DevComponents.DotNetBar.ButtonX();
            this.btnRemove = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lveSection2 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lveSection1 = new DevComponents.DotNetBar.Controls.ListViewEx();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trvAccount)).BeginInit();
            this.groupPanel5.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.groupPanel6.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.trvAccount);
            this.groupPanel1.Controls.Add(this.groupPanel5);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(192, 554);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "医生查询";
            // 
            // trvAccount
            // 
            this.trvAccount.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.trvAccount.AllowDrop = true;
            this.trvAccount.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.trvAccount.BackgroundStyle.Class = "TreeBorderKey";
            this.trvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvAccount.ImageList = this.imageList1;
            this.trvAccount.Location = new System.Drawing.Point(0, 76);
            this.trvAccount.Name = "trvAccount";
            this.trvAccount.NodesConnector = this.nodeConnector1;
            this.trvAccount.NodeStyle = this.elementStyle1;
            this.trvAccount.PathSeparator = ";";
            this.trvAccount.Size = new System.Drawing.Size(186, 454);
            this.trvAccount.Styles.Add(this.elementStyle1);
            this.trvAccount.TabIndex = 4;
            this.trvAccount.Text = "advTree1";
            this.trvAccount.SelectedIndexChanged += new System.EventHandler(this.trvAccount_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "50.ico");
            this.imageList1.Images.SetKeyName(1, "external2.ico");
            this.imageList1.Images.SetKeyName(2, "FILES4~1.ICO");
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // groupPanel5
            // 
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.chkAll);
            this.groupPanel5.Controls.Add(this.btnSearch);
            this.groupPanel5.Controls.Add(this.cboSearchType);
            this.groupPanel5.Controls.Add(this.txtName);
            this.groupPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel5.Location = new System.Drawing.Point(0, 0);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(186, 76);
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
            this.groupPanel5.TabIndex = 3;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chkAll.Location = new System.Drawing.Point(3, 47);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(72, 16);
            this.chkAll.TabIndex = 36;
            this.chkAll.Text = "显示所有";
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(102, 43);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 35;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboSearchType
            // 
            this.cboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Items.AddRange(new object[] {
            "按姓名",
            "按工号"});
            this.cboSearchType.Location = new System.Drawing.Point(0, 17);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(74, 20);
            this.cboSearchType.TabIndex = 35;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(80, 16);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 7;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.checkBoxX1);
            this.groupPanel2.Controls.Add(this.groupPanel6);
            this.groupPanel2.Controls.Add(this.btnCancel);
            this.groupPanel2.Controls.Add(this.btnRight);
            this.groupPanel2.Controls.Add(this.btnRemove);
            this.groupPanel2.Controls.Add(this.btnAdd);
            this.groupPanel2.Controls.Add(this.groupPanel4);
            this.groupPanel2.Controls.Add(this.groupPanel3);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(202, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(629, 554);
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
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "分配病例";
            // 
            // checkBoxX1
            // 
            this.checkBoxX1.Location = new System.Drawing.Point(267, 150);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(75, 23);
            this.checkBoxX1.TabIndex = 21;
            this.checkBoxX1.Text = "全选";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // groupPanel6
            // 
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.lblInTime);
            this.groupPanel6.Controls.Add(this.label13);
            this.groupPanel6.Controls.Add(this.lblTech_Post);
            this.groupPanel6.Controls.Add(this.label11);
            this.groupPanel6.Controls.Add(this.lblPosition);
            this.groupPanel6.Controls.Add(this.label9);
            this.groupPanel6.Controls.Add(this.lblSick_area);
            this.groupPanel6.Controls.Add(this.label6);
            this.groupPanel6.Controls.Add(this.lblSection);
            this.groupPanel6.Controls.Add(this.label4);
            this.groupPanel6.Controls.Add(this.lblSex);
            this.groupPanel6.Controls.Add(this.label7);
            this.groupPanel6.Controls.Add(this.lblName);
            this.groupPanel6.Controls.Add(this.label5);
            this.groupPanel6.Controls.Add(this.lblId);
            this.groupPanel6.Controls.Add(this.label2);
            this.groupPanel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel6.Location = new System.Drawing.Point(0, 0);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(623, 112);
            // 
            // 
            // 
            this.groupPanel6.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel6.Style.BackColorGradientAngle = 90;
            this.groupPanel6.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel6.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderBottomWidth = 1;
            this.groupPanel6.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel6.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderLeftWidth = 1;
            this.groupPanel6.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderRightWidth = 1;
            this.groupPanel6.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel6.Style.BorderTopWidth = 1;
            this.groupPanel6.Style.CornerDiameter = 4;
            this.groupPanel6.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel6.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel6.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel6.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel6.TabIndex = 20;
            this.groupPanel6.Text = "医生基本信息";
            // 
            // lblInTime
            // 
            this.lblInTime.AutoSize = true;
            this.lblInTime.Location = new System.Drawing.Point(596, 49);
            this.lblInTime.Name = "lblInTime";
            this.lblInTime.Size = new System.Drawing.Size(0, 12);
            this.lblInTime.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(519, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 12);
            this.label13.TabIndex = 33;
            this.label13.Text = "入职时间:";
            // 
            // lblTech_Post
            // 
            this.lblTech_Post.AutoSize = true;
            this.lblTech_Post.Location = new System.Drawing.Point(416, 49);
            this.lblTech_Post.Name = "lblTech_Post";
            this.lblTech_Post.Size = new System.Drawing.Size(0, 12);
            this.lblTech_Post.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(363, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "职称:";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(267, 49);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(0, 12);
            this.lblPosition.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(214, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "职务:";
            // 
            // lblSick_area
            // 
            this.lblSick_area.AutoSize = true;
            this.lblSick_area.Location = new System.Drawing.Point(88, 49);
            this.lblSick_area.Name = "lblSick_area";
            this.lblSick_area.Size = new System.Drawing.Size(0, 12);
            this.lblSick_area.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(35, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 12);
            this.label6.TabIndex = 27;
            this.label6.Text = "病区:";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(596, 7);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(0, 12);
            this.lblSection.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(543, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "科室:";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(416, 7);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(0, 12);
            this.lblSex.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(363, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "性别:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(267, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 12);
            this.lblName.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(214, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "姓名:";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(88, 7);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(0, 12);
            this.lblId.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(35, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "工号:";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(277, 355);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "取消授权";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRight
            // 
            this.btnRight.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRight.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRight.Location = new System.Drawing.Point(277, 309);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 12;
            this.btnRight.Text = "授权";
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRemove.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnRemove.Location = new System.Drawing.Point(291, 261);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(39, 23);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "<";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(291, 211);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = ">";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupPanel4
            // 
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.lveSection2);
            this.groupPanel4.Location = new System.Drawing.Point(365, 118);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(252, 347);
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
            this.groupPanel4.TabIndex = 7;
            this.groupPanel4.Text = "已选科室";
            // 
            // lveSection2
            // 
            // 
            // 
            // 
            this.lveSection2.Border.Class = "ListViewBorder";
            this.lveSection2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lveSection2.Font = new System.Drawing.Font("宋体", 9F);
            this.lveSection2.FullRowSelect = true;
            this.lveSection2.Location = new System.Drawing.Point(0, 0);
            this.lveSection2.MultiSelect = false;
            this.lveSection2.Name = "lveSection2";
            this.lveSection2.Size = new System.Drawing.Size(246, 323);
            this.lveSection2.TabIndex = 3;
            this.lveSection2.UseCompatibleStateImageBehavior = false;
            this.lveSection2.View = System.Windows.Forms.View.List;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.lveSection1);
            this.groupPanel3.Location = new System.Drawing.Point(3, 118);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(252, 347);
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
            this.groupPanel3.TabIndex = 6;
            this.groupPanel3.Text = "可选科室";
            // 
            // lveSection1
            // 
            // 
            // 
            // 
            this.lveSection1.Border.Class = "ListViewBorder";
            this.lveSection1.CheckBoxes = true;
            this.lveSection1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lveSection1.Font = new System.Drawing.Font("宋体", 9F);
            this.lveSection1.FullRowSelect = true;
            this.lveSection1.Location = new System.Drawing.Point(0, 0);
            this.lveSection1.MultiSelect = false;
            this.lveSection1.Name = "lveSection1";
            this.lveSection1.Size = new System.Drawing.Size(246, 323);
            this.lveSection1.TabIndex = 3;
            this.lveSection1.UseCompatibleStateImageBehavior = false;
            this.lveSection1.View = System.Windows.Forms.View.List;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(192, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(10, 554);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 23;
            this.expandableSplitter1.TabStop = false;
            // 
            // UcMedicalRightRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.groupPanel1);
            this.Name = "UcMedicalRightRun";
            this.Size = new System.Drawing.Size(831, 554);
            this.Load += new System.EventHandler(this.UcMedicalRightRun_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trvAccount)).EndInit();
            this.groupPanel5.ResumeLayout(false);
            this.groupPanel5.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel6.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.ListViewEx lveSection1;
        private DevComponents.DotNetBar.ButtonX btnRemove;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.ListViewEx lveSection2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.ButtonX btnRight;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTech_Post;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSick_area;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.AdvTree.AdvTree trvAccount;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cboSearchType;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.CheckBox chkAll;
    }
}
