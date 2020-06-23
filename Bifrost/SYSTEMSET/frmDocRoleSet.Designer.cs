namespace Bifrost
{
    partial class frmDocRoleSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDocRoleSet));
            this.trvBookOprate = new System.Windows.Forms.TreeView();
            this.imgListBook = new System.Windows.Forms.ImageList(this.components);
            this.lblSectionAllCancel = new System.Windows.Forms.Label();
            this.lblSectionAllCheck = new System.Windows.Forms.Label();
            this.chkListSection = new System.Windows.Forms.CheckedListBox();
            this.chkListFenyuan = new System.Windows.Forms.CheckedListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSelectDocType = new System.Windows.Forms.Label();
            this.cboWorkGroup = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkOtherRights = new System.Windows.Forms.CheckedListBox();
            this.cboZhiChen = new System.Windows.Forms.ComboBox();
            this.cboZhiWu = new System.Windows.Forms.ComboBox();
            this.cboSign2 = new System.Windows.Forms.ComboBox();
            this.cboSign1 = new System.Windows.Forms.ComboBox();
            this.lsbButton = new System.Windows.Forms.ListBox();
            this.chkZhiwu = new System.Windows.Forms.CheckBox();
            this.chkZhicheng = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupPanel6 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel7 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.expandableSplitter2 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupPanel5 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupPanel4 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupPanel6.SuspendLayout();
            this.groupPanel7.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupPanel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvBookOprate
            // 
            this.trvBookOprate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvBookOprate.HideSelection = false;
            this.trvBookOprate.ImageIndex = 0;
            this.trvBookOprate.ImageList = this.imgListBook;
            this.trvBookOprate.Location = new System.Drawing.Point(0, 0);
            this.trvBookOprate.Name = "trvBookOprate";
            this.trvBookOprate.SelectedImageIndex = 0;
            this.trvBookOprate.Size = new System.Drawing.Size(349, 431);
            this.trvBookOprate.TabIndex = 1;
            this.trvBookOprate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvBookOprate_AfterSelect);
            // 
            // imgListBook
            // 
            this.imgListBook.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListBook.ImageStream")));
            this.imgListBook.TransparentColor = System.Drawing.Color.Transparent;
            this.imgListBook.Images.SetKeyName(0, "paintm.ico");
            this.imgListBook.Images.SetKeyName(1, "joym.ico");
            this.imgListBook.Images.SetKeyName(2, "manilla.ico");
            this.imgListBook.Images.SetKeyName(3, "net1m.ico");
            this.imgListBook.Images.SetKeyName(4, "net2m.ico");
            this.imgListBook.Images.SetKeyName(5, "New Text Doc.ico");
            this.imgListBook.Images.SetKeyName(6, "NOTEPA~1.ICO");
            this.imgListBook.Images.SetKeyName(7, "NOTEPA~2.ICO");
            this.imgListBook.Images.SetKeyName(8, "NOTEPA~3.ICO");
            this.imgListBook.Images.SetKeyName(9, "NOTEPA~4.ICO");
            this.imgListBook.Images.SetKeyName(10, "NOTEPA~5.ICO");
            this.imgListBook.Images.SetKeyName(11, "notesg.ico");
            this.imgListBook.Images.SetKeyName(12, "notesm.ico");
            this.imgListBook.Images.SetKeyName(13, "BETEXT~1.ICO");
            this.imgListBook.Images.SetKeyName(14, "FORMATED.ICO");
            // 
            // lblSectionAllCancel
            // 
            this.lblSectionAllCancel.AutoSize = true;
            this.lblSectionAllCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSectionAllCancel.ForeColor = System.Drawing.Color.Blue;
            this.lblSectionAllCancel.Location = new System.Drawing.Point(13, 55);
            this.lblSectionAllCancel.Name = "lblSectionAllCancel";
            this.lblSectionAllCancel.Size = new System.Drawing.Size(53, 12);
            this.lblSectionAllCancel.TabIndex = 7;
            this.lblSectionAllCancel.Text = "全部取消";
            this.lblSectionAllCancel.Click += new System.EventHandler(this.lblSectionAllCancel_Click);
            // 
            // lblSectionAllCheck
            // 
            this.lblSectionAllCheck.AutoSize = true;
            this.lblSectionAllCheck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSectionAllCheck.ForeColor = System.Drawing.Color.Blue;
            this.lblSectionAllCheck.Location = new System.Drawing.Point(13, 18);
            this.lblSectionAllCheck.Name = "lblSectionAllCheck";
            this.lblSectionAllCheck.Size = new System.Drawing.Size(29, 12);
            this.lblSectionAllCheck.TabIndex = 6;
            this.lblSectionAllCheck.Text = "全选";
            this.lblSectionAllCheck.Click += new System.EventHandler(this.lblSectionAllCheck_Click);
            // 
            // chkListSection
            // 
            this.chkListSection.CheckOnClick = true;
            this.chkListSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListSection.FormattingEnabled = true;
            this.chkListSection.Location = new System.Drawing.Point(0, 0);
            this.chkListSection.Name = "chkListSection";
            this.chkListSection.Size = new System.Drawing.Size(312, 100);
            this.chkListSection.TabIndex = 3;
            this.chkListSection.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkListSection_MouseUp);
            this.chkListSection.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chkListSection_ItemCheck);
            // 
            // chkListFenyuan
            // 
            this.chkListFenyuan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListFenyuan.FormattingEnabled = true;
            this.chkListFenyuan.Location = new System.Drawing.Point(0, 0);
            this.chkListFenyuan.Name = "chkListFenyuan";
            this.chkListFenyuan.Size = new System.Drawing.Size(226, 100);
            this.chkListFenyuan.TabIndex = 2;
            this.chkListFenyuan.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkListFenyuan_MouseUp);
            this.chkListFenyuan.SelectedIndexChanged += new System.EventHandler(this.chkListFenyuan_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.lblSelectDocType);
            this.panel1.Controls.Add(this.cboWorkGroup);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 46);
            this.panel1.TabIndex = 4;
            // 
            // lblSelectDocType
            // 
            this.lblSelectDocType.AutoSize = true;
            this.lblSelectDocType.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelectDocType.ForeColor = System.Drawing.Color.Red;
            this.lblSelectDocType.Location = new System.Drawing.Point(293, 15);
            this.lblSelectDocType.Name = "lblSelectDocType";
            this.lblSelectDocType.Size = new System.Drawing.Size(96, 12);
            this.lblSelectDocType.TabIndex = 2;
            this.lblSelectDocType.Text = "当前文书类型：";
            // 
            // cboWorkGroup
            // 
            this.cboWorkGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWorkGroup.FormattingEnabled = true;
            this.cboWorkGroup.Location = new System.Drawing.Point(58, 12);
            this.cboWorkGroup.Name = "cboWorkGroup";
            this.cboWorkGroup.Size = new System.Drawing.Size(193, 20);
            this.cboWorkGroup.TabIndex = 1;
            this.cboWorkGroup.SelectedIndexChanged += new System.EventHandler(this.cboWorkGroup_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "工作组：";
            // 
            // chkOtherRights
            // 
            this.chkOtherRights.CheckOnClick = true;
            this.chkOtherRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkOtherRights.FormattingEnabled = true;
            this.chkOtherRights.Items.AddRange(new object[] {
            "仅管床",
            "仅执业证书",
            "仅本诊疗组",
            "可实习",
            "可进修",
            "可研究生"});
            this.chkOtherRights.Location = new System.Drawing.Point(0, 0);
            this.chkOtherRights.Name = "chkOtherRights";
            this.chkOtherRights.Size = new System.Drawing.Size(303, 164);
            this.chkOtherRights.TabIndex = 0;
            this.chkOtherRights.MouseUp += new System.Windows.Forms.MouseEventHandler(this.chkOtherRights_MouseUp);
            // 
            // cboZhiChen
            // 
            this.cboZhiChen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZhiChen.Enabled = false;
            this.cboZhiChen.FormattingEnabled = true;
            this.cboZhiChen.Location = new System.Drawing.Point(431, 29);
            this.cboZhiChen.Name = "cboZhiChen";
            this.cboZhiChen.Size = new System.Drawing.Size(156, 20);
            this.cboZhiChen.TabIndex = 6;
            this.cboZhiChen.SelectedIndexChanged += new System.EventHandler(this.cboZhiChen_SelectedIndexChanged);
            // 
            // cboZhiWu
            // 
            this.cboZhiWu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZhiWu.Enabled = false;
            this.cboZhiWu.FormattingEnabled = true;
            this.cboZhiWu.Location = new System.Drawing.Point(431, 3);
            this.cboZhiWu.Name = "cboZhiWu";
            this.cboZhiWu.Size = new System.Drawing.Size(156, 20);
            this.cboZhiWu.TabIndex = 5;
            this.cboZhiWu.SelectedIndexChanged += new System.EventHandler(this.cboZhiWu_SelectedIndexChanged);
            // 
            // cboSign2
            // 
            this.cboSign2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSign2.Enabled = false;
            this.cboSign2.FormattingEnabled = true;
            this.cboSign2.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            "≥",
            "≤"});
            this.cboSign2.Location = new System.Drawing.Point(372, 29);
            this.cboSign2.Name = "cboSign2";
            this.cboSign2.Size = new System.Drawing.Size(53, 20);
            this.cboSign2.TabIndex = 3;
            this.cboSign2.SelectedIndexChanged += new System.EventHandler(this.cboSign2_SelectedIndexChanged);
            // 
            // cboSign1
            // 
            this.cboSign1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSign1.Enabled = false;
            this.cboSign1.FormattingEnabled = true;
            this.cboSign1.Items.AddRange(new object[] {
            ">",
            "<",
            "=",
            "≥",
            "≤"});
            this.cboSign1.Location = new System.Drawing.Point(372, 3);
            this.cboSign1.Name = "cboSign1";
            this.cboSign1.Size = new System.Drawing.Size(53, 20);
            this.cboSign1.TabIndex = 1;
            this.cboSign1.SelectedIndexChanged += new System.EventHandler(this.cboSign1_SelectedIndexChanged);
            // 
            // lsbButton
            // 
            this.lsbButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.lsbButton.FormattingEnabled = true;
            this.lsbButton.ItemHeight = 12;
            this.lsbButton.Location = new System.Drawing.Point(0, 0);
            this.lsbButton.Name = "lsbButton";
            this.lsbButton.Size = new System.Drawing.Size(246, 256);
            this.lsbButton.TabIndex = 0;
            this.lsbButton.SelectedIndexChanged += new System.EventHandler(this.lsbButton_SelectedIndexChanged);
            // 
            // chkZhiwu
            // 
            this.chkZhiwu.AutoSize = true;
            this.chkZhiwu.BackColor = System.Drawing.Color.Transparent;
            this.chkZhiwu.Location = new System.Drawing.Point(295, 5);
            this.chkZhiwu.Name = "chkZhiwu";
            this.chkZhiwu.Size = new System.Drawing.Size(60, 16);
            this.chkZhiwu.TabIndex = 8;
            this.chkZhiwu.Text = "职务：";
            this.chkZhiwu.UseVisualStyleBackColor = false;
            this.chkZhiwu.CheckedChanged += new System.EventHandler(this.chkZhiwu_CheckedChanged);
            // 
            // chkZhicheng
            // 
            this.chkZhicheng.AutoSize = true;
            this.chkZhicheng.BackColor = System.Drawing.Color.Transparent;
            this.chkZhicheng.Location = new System.Drawing.Point(295, 31);
            this.chkZhicheng.Name = "chkZhicheng";
            this.chkZhicheng.Size = new System.Drawing.Size(60, 16);
            this.chkZhicheng.TabIndex = 9;
            this.chkZhicheng.Text = "职称：";
            this.chkZhicheng.UseVisualStyleBackColor = false;
            this.chkZhicheng.CheckedChanged += new System.EventHandler(this.chkZhicheng_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Controls.Add(this.btnCancel);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 499);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(631, 41);
            this.panel3.TabIndex = 1;
            this.panel3.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(234, 6);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(63, 31);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(372, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 31);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(303, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(63, 31);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupPanel2);
            this.panel4.Controls.Add(this.groupPanel1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(355, 540);
            this.panel4.TabIndex = 1;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.trvBookOprate);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 85);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(355, 455);
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
            this.groupPanel2.Text = "文书列表";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupPanel1.Size = new System.Drawing.Size(355, 85);
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
            this.groupPanel1.Text = "查询设置";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.panel4;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(355, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(10, 540);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 2;
            this.expandableSplitter1.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupPanel6);
            this.panel5.Controls.Add(this.panel3);
            this.panel5.Controls.Add(this.expandableSplitter2);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(365, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(631, 540);
            this.panel5.TabIndex = 3;
            // 
            // groupPanel6
            // 
            this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel6.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel6.Controls.Add(this.groupPanel7);
            this.groupPanel6.Controls.Add(this.lsbButton);
            this.groupPanel6.Controls.Add(this.cboZhiChen);
            this.groupPanel6.Controls.Add(this.chkZhiwu);
            this.groupPanel6.Controls.Add(this.cboZhiWu);
            this.groupPanel6.Controls.Add(this.chkZhicheng);
            this.groupPanel6.Controls.Add(this.cboSign2);
            this.groupPanel6.Controls.Add(this.cboSign1);
            this.groupPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel6.Location = new System.Drawing.Point(0, 209);
            this.groupPanel6.Name = "groupPanel6";
            this.groupPanel6.Size = new System.Drawing.Size(631, 290);
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
            this.groupPanel6.TabIndex = 2;
            this.groupPanel6.Text = "权限设置";
            // 
            // groupPanel7
            // 
            this.groupPanel7.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel7.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel7.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel7.Controls.Add(this.chkOtherRights);
            this.groupPanel7.Location = new System.Drawing.Point(295, 55);
            this.groupPanel7.Name = "groupPanel7";
            this.groupPanel7.Size = new System.Drawing.Size(309, 201);
            // 
            // 
            // 
            this.groupPanel7.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel7.Style.BackColorGradientAngle = 90;
            this.groupPanel7.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel7.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderBottomWidth = 1;
            this.groupPanel7.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel7.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderLeftWidth = 1;
            this.groupPanel7.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderRightWidth = 1;
            this.groupPanel7.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel7.Style.BorderTopWidth = 1;
            this.groupPanel7.Style.CornerDiameter = 4;
            this.groupPanel7.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel7.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel7.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel7.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.groupPanel7.TabIndex = 10;
            this.groupPanel7.Text = "其他权限";
            // 
            // expandableSplitter2
            // 
            this.expandableSplitter2.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandableSplitter2.ExpandableControl = this.groupPanel3;
            this.expandableSplitter2.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter2.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter2.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter2.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter2.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter2.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter2.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter2.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter2.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter2.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter2.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter2.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter2.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter2.Location = new System.Drawing.Point(0, 198);
            this.expandableSplitter2.Name = "expandableSplitter2";
            this.expandableSplitter2.Size = new System.Drawing.Size(631, 11);
            this.expandableSplitter2.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter2.TabIndex = 1;
            this.expandableSplitter2.TabStop = false;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.groupPanel5);
            this.groupPanel3.Controls.Add(this.groupPanel4);
            this.groupPanel3.Controls.Add(this.panel1);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(631, 198);
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
            this.groupPanel3.TabIndex = 0;
            this.groupPanel3.Text = "范围设置";
            // 
            // groupPanel5
            // 
            this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel5.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel5.Controls.Add(this.chkListSection);
            this.groupPanel5.Controls.Add(this.panel2);
            this.groupPanel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel5.Location = new System.Drawing.Point(232, 46);
            this.groupPanel5.Name = "groupPanel5";
            this.groupPanel5.Size = new System.Drawing.Size(390, 128);
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
            this.groupPanel5.TabIndex = 2;
            this.groupPanel5.Text = "科室";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblSectionAllCancel);
            this.panel2.Controls.Add(this.lblSectionAllCheck);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(312, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(72, 104);
            this.panel2.TabIndex = 8;
            // 
            // groupPanel4
            // 
            this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel4.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel4.Controls.Add(this.chkListFenyuan);
            this.groupPanel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel4.Location = new System.Drawing.Point(0, 46);
            this.groupPanel4.Name = "groupPanel4";
            this.groupPanel4.Size = new System.Drawing.Size(232, 128);
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
            this.groupPanel4.TabIndex = 1;
            this.groupPanel4.Text = "分院";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupPanel3);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(631, 198);
            this.panel6.TabIndex = 0;
            // 
            // frmDocRoleSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.panel4);
            this.Name = "frmDocRoleSet";
            this.Size = new System.Drawing.Size(996, 540);
            this.Load += new System.EventHandler(this.frmDocRoleSet_Load);
            this.VisibleChanged += new System.EventHandler(this.frmDocRoleSet_VisibleChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupPanel6.ResumeLayout(false);
            this.groupPanel6.PerformLayout();
            this.groupPanel7.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupPanel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imgListBook;
        private System.Windows.Forms.TreeView trvBookOprate;
        private System.Windows.Forms.CheckedListBox chkListSection;
        private System.Windows.Forms.CheckedListBox chkListFenyuan;
        private System.Windows.Forms.ComboBox cboWorkGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSelectDocType;
        private System.Windows.Forms.ComboBox cboZhiChen;
        private System.Windows.Forms.ComboBox cboZhiWu;
        private System.Windows.Forms.ComboBox cboSign2;
        private System.Windows.Forms.ComboBox cboSign1;
        private System.Windows.Forms.ListBox lsbButton;
        private System.Windows.Forms.CheckedListBox chkOtherRights;
        private System.Windows.Forms.CheckBox chkZhiwu;
        private System.Windows.Forms.CheckBox chkZhicheng;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblSectionAllCancel;
        private System.Windows.Forms.Label lblSectionAllCheck;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private System.Windows.Forms.Panel panel5;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter2;
        private System.Windows.Forms.Panel panel6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel5;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel4;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel6;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel7;
        private System.Windows.Forms.Panel panel2;
    }
}