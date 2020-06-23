namespace Base_Function.BASE_DATA
{
    partial class ucScience
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param Name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucScience));
            this.lvBigsection = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.txtConditions = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lvSmallscience = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSelect_B = new DevComponents.DotNetBar.ButtonX();
            this.txtConditions_B = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSelectValue = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvRelation = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvBigsection
            // 
            this.lvBigsection.AutoArrange = false;
            this.lvBigsection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.lvBigsection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvBigsection.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvBigsection.Location = new System.Drawing.Point(0, 71);
            this.lvBigsection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvBigsection.Name = "lvBigsection";
            this.lvBigsection.Size = new System.Drawing.Size(292, 689);
            this.lvBigsection.SmallImageList = this.imageList1;
            this.lvBigsection.TabIndex = 4;
            this.lvBigsection.UseCompatibleStateImageBehavior = false;
            this.lvBigsection.View = System.Windows.Forms.View.Details;
            this.lvBigsection.Click += new System.EventHandler(this.lvBigsection_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 304;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Files1.ico");
            this.imageList1.Images.SetKeyName(1, "BEEDIT~1.ICO");
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSelect);
            this.panel3.Controls.Add(this.txtConditions);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(292, 71);
            this.panel3.TabIndex = 2;
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(224, 18);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(65, 26);
            this.btnSelect.TabIndex = 5;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtConditions
            // 
            this.txtConditions.Location = new System.Drawing.Point(57, 21);
            this.txtConditions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConditions.Name = "txtConditions";
            this.txtConditions.Size = new System.Drawing.Size(163, 23);
            this.txtConditions.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "名称：";
            // 
            // lvSmallscience
            // 
            this.lvSmallscience.AutoArrange = false;
            this.lvSmallscience.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvSmallscience.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSmallscience.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvSmallscience.Location = new System.Drawing.Point(0, 71);
            this.lvSmallscience.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvSmallscience.Name = "lvSmallscience";
            this.lvSmallscience.Size = new System.Drawing.Size(297, 689);
            this.lvSmallscience.SmallImageList = this.imageList1;
            this.lvSmallscience.TabIndex = 5;
            this.lvSmallscience.UseCompatibleStateImageBehavior = false;
            this.lvSmallscience.View = System.Windows.Forms.View.Details;
            this.lvSmallscience.RightToLeftLayoutChanged += new System.EventHandler(this.lvSmallscience_RightToLeftLayoutChanged);
            this.lvSmallscience.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSmallscience_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 304;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnSelect_B);
            this.panel4.Controls.Add(this.txtConditions_B);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(297, 71);
            this.panel4.TabIndex = 3;
            // 
            // btnSelect_B
            // 
            this.btnSelect_B.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect_B.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect_B.Location = new System.Drawing.Point(226, 18);
            this.btnSelect_B.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelect_B.Name = "btnSelect_B";
            this.btnSelect_B.Size = new System.Drawing.Size(65, 26);
            this.btnSelect_B.TabIndex = 5;
            this.btnSelect_B.Text = "查询";
            this.btnSelect_B.Click += new System.EventHandler(this.btnSelect_B_Click);
            // 
            // txtConditions_B
            // 
            this.txtConditions_B.Location = new System.Drawing.Point(56, 21);
            this.txtConditions_B.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConditions_B.Name = "txtConditions_B";
            this.txtConditions_B.Size = new System.Drawing.Size(163, 23);
            this.txtConditions_B.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(7, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "名称：";
            // 
            // lblSelectValue
            // 
            this.lblSelectValue.AutoSize = true;
            this.lblSelectValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSelectValue.ForeColor = System.Drawing.Color.Red;
            this.lblSelectValue.Location = new System.Drawing.Point(148, 23);
            this.lblSelectValue.Name = "lblSelectValue";
            this.lblSelectValue.Size = new System.Drawing.Size(0, 14);
            this.lblSelectValue.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(913, 786);
            this.splitContainer1.SplitterDistance = 298;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lvBigsection);
            this.groupPanel1.Controls.Add(this.panel3);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(298, 786);
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
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.Text = "大科表";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupPanel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer2.Size = new System.Drawing.Size(610, 786);
            this.splitContainer2.SplitterDistance = 302;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.panel2);
            this.groupPanel2.Controls.Add(this.groupBox4);
            this.groupPanel2.Controls.Add(this.panel1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(302, 786);
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
            this.groupPanel2.Text = "关系设置";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 696);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 64);
            this.panel2.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Controls.Add(this.btnClear);
            this.panel5.Location = new System.Drawing.Point(22, 8);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(252, 51);
            this.panel5.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(129, 10);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Location = new System.Drawing.Point(35, 10);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 33);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清空关系";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lvRelation);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(0, 71);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(296, 689);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "对应的关系的小科表";
            // 
            // lvRelation
            // 
            this.lvRelation.AutoArrange = false;
            this.lvRelation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvRelation.ContextMenuStrip = this.contextMenuStrip1;
            this.lvRelation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRelation.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvRelation.Location = new System.Drawing.Point(3, 20);
            this.lvRelation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvRelation.Name = "lvRelation";
            this.lvRelation.Size = new System.Drawing.Size(290, 665);
            this.lvRelation.SmallImageList = this.imageList1;
            this.lvRelation.TabIndex = 7;
            this.lvRelation.UseCompatibleStateImageBehavior = false;
            this.lvRelation.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 304;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblSelectValue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 71);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "当前大科为：";
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.lvSmallscience);
            this.groupPanel3.Controls.Add(this.panel4);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(303, 786);
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
            this.groupPanel3.TabIndex = 3;
            this.groupPanel3.Text = "小科表";
            // 
            // ucScience
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucScience";
            this.Size = new System.Drawing.Size(913, 786);
            this.Load += new System.EventHandler(this.frmScience_Load);
            this.Resize += new System.EventHandler(this.frmScience_Resize);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSelectValue;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtConditions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtConditions_B;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ListView lvBigsection;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvSmallscience;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lvRelation;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX btnSelect_B;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
    }
}