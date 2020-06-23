namespace Bifrost_Doctor.Consultation_Manager
{
    partial class frmConsultation_Apply
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultation_Apply));
            this.label2 = new System.Windows.Forms.Label();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.gbxApplyList = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tlspmnitUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tlspmnitDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改授权ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdbtnNormal = new System.Windows.Forms.RadioButton();
            this.rdbtnNasty = new System.Windows.Forms.RadioButton();
            this.btnSavetemp = new DevComponents.DotNetBar.ButtonX();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.btnNewApply = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbxEdit = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.lblSectionName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelApply = new DevComponents.DotNetBar.ButtonX();
            this.gbxApplyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flgGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbxEdit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(15, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "会诊类别：";
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.expandableSplitter1.ExpandableControl = this.gbxApplyList;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(0, 142);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(993, 10);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 47;
            this.expandableSplitter1.TabStop = false;
            // 
            // gbxApplyList
            // 
            this.gbxApplyList.AutoScroll = true;
            this.gbxApplyList.CanvasColor = System.Drawing.SystemColors.Control;
            this.gbxApplyList.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gbxApplyList.Controls.Add(this.flgGrid);
            this.gbxApplyList.Controls.Add(this.panel4);
            this.gbxApplyList.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxApplyList.Location = new System.Drawing.Point(0, 0);
            this.gbxApplyList.Name = "gbxApplyList";
            this.gbxApplyList.Size = new System.Drawing.Size(993, 142);
            // 
            // 
            // 
            this.gbxApplyList.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gbxApplyList.Style.BackColorGradientAngle = 90;
            this.gbxApplyList.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gbxApplyList.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxApplyList.Style.BorderBottomWidth = 1;
            this.gbxApplyList.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gbxApplyList.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxApplyList.Style.BorderLeftWidth = 1;
            this.gbxApplyList.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxApplyList.Style.BorderRightWidth = 1;
            this.gbxApplyList.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxApplyList.Style.BorderTopWidth = 1;
            this.gbxApplyList.Style.CornerDiameter = 4;
            this.gbxApplyList.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gbxApplyList.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gbxApplyList.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gbxApplyList.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.gbxApplyList.TabIndex = 46;
            this.gbxApplyList.Text = "会诊申请列表";
            // 
            // flgGrid
            // 
            this.flgGrid.AllowEditing = false;
            this.flgGrid.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgGrid.ColumnInfo = "1,1,0,0,0,0,Columns:0{Width:20;}\t";
            this.flgGrid.ContextMenuStrip = this.contextMenuStrip1;
            this.flgGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgGrid.Location = new System.Drawing.Point(0, 0);
            this.flgGrid.Name = "flgGrid";
            this.flgGrid.Rows.DefaultSize = 18;
            this.flgGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flgGrid.ShowSort = false;
            this.flgGrid.Size = new System.Drawing.Size(862, 118);
            this.flgGrid.StyleInfo = resources.GetString("flgGrid.StyleInfo");
            this.flgGrid.TabIndex = 0;
            this.flgGrid.Click += new System.EventHandler(this.flgGrid_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlspmnitUpdate,
            this.tlspmnitDelete,
            this.PrintItem,
            this.修改授权ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // tlspmnitUpdate
            // 
            this.tlspmnitUpdate.Name = "tlspmnitUpdate";
            this.tlspmnitUpdate.Size = new System.Drawing.Size(124, 22);
            this.tlspmnitUpdate.Text = "修改";
            this.tlspmnitUpdate.Click += new System.EventHandler(this.tlspmnitUpdate_Click);
            // 
            // tlspmnitDelete
            // 
            this.tlspmnitDelete.Name = "tlspmnitDelete";
            this.tlspmnitDelete.Size = new System.Drawing.Size(124, 22);
            this.tlspmnitDelete.Text = "删除";
            this.tlspmnitDelete.Click += new System.EventHandler(this.tlspmnitDelete_Click);
            // 
            // PrintItem
            // 
            this.PrintItem.Name = "PrintItem";
            this.PrintItem.Size = new System.Drawing.Size(124, 22);
            this.PrintItem.Text = "打印";
            this.PrintItem.Click += new System.EventHandler(this.PrintItem_Click);
            // 
            // 修改授权ToolStripMenuItem
            // 
            this.修改授权ToolStripMenuItem.Name = "修改授权ToolStripMenuItem";
            this.修改授权ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.修改授权ToolStripMenuItem.Text = "修改授权";
            this.修改授权ToolStripMenuItem.Click += new System.EventHandler(this.修改授权ToolStripMenuItem_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(862, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(125, 118);
            this.panel4.TabIndex = 1;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Orange;
            this.pictureBox4.Location = new System.Drawing.Point(21, 87);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 12);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox3.Location = new System.Drawing.Point(21, 70);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 12);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Red;
            this.pictureBox2.Location = new System.Drawing.Point(21, 53);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 12);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pictureBox1.Location = new System.Drawing.Point(21, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 12);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "修改授权";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "取消接诊";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "急会诊(字体)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "暂存";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "颜色说明：";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.rdbtnNormal);
            this.panel3.Controls.Add(this.rdbtnNasty);
            this.panel3.Location = new System.Drawing.Point(85, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(176, 24);
            this.panel3.TabIndex = 18;
            // 
            // rdbtnNormal
            // 
            this.rdbtnNormal.AutoSize = true;
            this.rdbtnNormal.BackColor = System.Drawing.Color.Transparent;
            this.rdbtnNormal.Checked = true;
            this.rdbtnNormal.Location = new System.Drawing.Point(11, 6);
            this.rdbtnNormal.Name = "rdbtnNormal";
            this.rdbtnNormal.Size = new System.Drawing.Size(71, 16);
            this.rdbtnNormal.TabIndex = 2;
            this.rdbtnNormal.TabStop = true;
            this.rdbtnNormal.Text = "普通会诊";
            this.rdbtnNormal.UseVisualStyleBackColor = false;
            // 
            // rdbtnNasty
            // 
            this.rdbtnNasty.AutoSize = true;
            this.rdbtnNasty.BackColor = System.Drawing.Color.Transparent;
            this.rdbtnNasty.Location = new System.Drawing.Point(109, 6);
            this.rdbtnNasty.Name = "rdbtnNasty";
            this.rdbtnNasty.Size = new System.Drawing.Size(59, 16);
            this.rdbtnNasty.TabIndex = 1;
            this.rdbtnNasty.Text = "急会诊";
            this.rdbtnNasty.UseVisualStyleBackColor = false;
            // 
            // btnSavetemp
            // 
            this.btnSavetemp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSavetemp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSavetemp.Enabled = false;
            this.btnSavetemp.Location = new System.Drawing.Point(453, 10);
            this.btnSavetemp.Name = "btnSavetemp";
            this.btnSavetemp.Size = new System.Drawing.Size(87, 31);
            this.btnSavetemp.TabIndex = 41;
            this.btnSavetemp.Text = "暂存";
            this.btnSavetemp.Click += new System.EventHandler(this.btnSavetemp_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(641, 10);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(87, 31);
            this.btnSelect.TabIndex = 40;
            this.btnSelect.Text = "选择病程";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnNewApply
            // 
            this.btnNewApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNewApply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNewApply.Location = new System.Drawing.Point(265, 10);
            this.btnNewApply.Name = "btnNewApply";
            this.btnNewApply.Size = new System.Drawing.Size(87, 31);
            this.btnNewApply.TabIndex = 41;
            this.btnNewApply.Text = "新增会诊申请";
            this.btnNewApply.Click += new System.EventHandler(this.btnNewApply_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(547, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 31);
            this.btnSave.TabIndex = 41;
            this.btnSave.Text = "提交";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(987, 28);
            this.panel2.TabIndex = 45;
            // 
            // gbxEdit
            // 
            this.gbxEdit.AutoScroll = true;
            this.gbxEdit.CanvasColor = System.Drawing.SystemColors.Control;
            this.gbxEdit.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.gbxEdit.Controls.Add(this.panelEdit);
            this.gbxEdit.Controls.Add(this.lblDoctorName);
            this.gbxEdit.Controls.Add(this.lblSectionName);
            this.gbxEdit.Controls.Add(this.panel2);
            this.gbxEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxEdit.Location = new System.Drawing.Point(0, 152);
            this.gbxEdit.Name = "gbxEdit";
            this.gbxEdit.Size = new System.Drawing.Size(993, 434);
            // 
            // 
            // 
            this.gbxEdit.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.gbxEdit.Style.BackColorGradientAngle = 90;
            this.gbxEdit.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.gbxEdit.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxEdit.Style.BorderBottomWidth = 1;
            this.gbxEdit.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.gbxEdit.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxEdit.Style.BorderLeftWidth = 1;
            this.gbxEdit.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxEdit.Style.BorderRightWidth = 1;
            this.gbxEdit.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.gbxEdit.Style.BorderTopWidth = 1;
            this.gbxEdit.Style.CornerDiameter = 4;
            this.gbxEdit.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.gbxEdit.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.gbxEdit.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.gbxEdit.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            this.gbxEdit.TabIndex = 44;
            this.gbxEdit.Text = "会诊申请编辑";
            // 
            // panelEdit
            // 
            this.panelEdit.BackColor = System.Drawing.Color.Transparent;
            this.panelEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEdit.Location = new System.Drawing.Point(0, 28);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(987, 382);
            this.panelEdit.TabIndex = 46;
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctorName.Location = new System.Drawing.Point(877, 37);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(11, 12);
            this.lblDoctorName.TabIndex = 33;
            this.lblDoctorName.Text = " ";
            this.lblDoctorName.Visible = false;
            // 
            // lblSectionName
            // 
            this.lblSectionName.AutoSize = true;
            this.lblSectionName.BackColor = System.Drawing.Color.Transparent;
            this.lblSectionName.Location = new System.Drawing.Point(714, 134);
            this.lblSectionName.Name = "lblSectionName";
            this.lblSectionName.Size = new System.Drawing.Size(11, 12);
            this.lblSectionName.TabIndex = 32;
            this.lblSectionName.Text = " ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancelApply);
            this.panel1.Controls.Add(this.btnNewApply);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnSavetemp);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 586);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 50);
            this.panel1.TabIndex = 48;
            // 
            // btnCancelApply
            // 
            this.btnCancelApply.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancelApply.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancelApply.Location = new System.Drawing.Point(359, 10);
            this.btnCancelApply.Name = "btnCancelApply";
            this.btnCancelApply.Size = new System.Drawing.Size(87, 31);
            this.btnCancelApply.TabIndex = 42;
            this.btnCancelApply.Text = "取消操作";
            this.btnCancelApply.Click += new System.EventHandler(this.btnCancelApply_Click);
            // 
            // frmConsultation_Apply
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 636);
            this.Controls.Add(this.gbxEdit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.gbxApplyList);
            this.DoubleBuffered = true;
            this.Name = "frmConsultation_Apply";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "会诊申请";
            this.Load += new System.EventHandler(this.frmConsultation_Apply_Load);
            this.gbxApplyList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flgGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbxEdit.ResumeLayout(false);
            this.gbxEdit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.Controls.GroupPanel gbxApplyList;
        private C1.Win.C1FlexGrid.C1FlexGrid flgGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tlspmnitUpdate;
        private System.Windows.Forms.ToolStripMenuItem tlspmnitDelete;
        private System.Windows.Forms.ToolStripMenuItem PrintItem;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton rdbtnNormal;
        private System.Windows.Forms.RadioButton rdbtnNasty;
        private DevComponents.DotNetBar.ButtonX btnSavetemp;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX btnNewApply;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.Controls.GroupPanel gbxEdit;
        private System.Windows.Forms.Label lblDoctorName;
        private System.Windows.Forms.Label lblSectionName;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnCancelApply;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 修改授权ToolStripMenuItem;

    }
}