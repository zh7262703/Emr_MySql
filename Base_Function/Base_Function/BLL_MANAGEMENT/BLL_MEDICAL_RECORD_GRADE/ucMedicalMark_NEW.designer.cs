namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE
{
    partial class ucMedicalMark_NEW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucMedicalMark_NEW));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.advAllDoc = new DevComponents.AdvTree.AdvTree();
            this.imgListBook = new System.Windows.Forms.ImageList(this.components);
            this.nodeConnector4 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle4 = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyleBlue = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyleOrange = new DevComponents.DotNetBar.ElementStyle();
            this.elementStyleRed = new DevComponents.DotNetBar.ElementStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearchAllText = new System.Windows.Forms.TextBox();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dtgRules = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnNewRule = new System.Windows.Forms.ToolStripButton();
            this.tbtnChange = new System.Windows.Forms.ToolStripButton();
            this.tbtnDel = new System.Windows.Forms.ToolStripButton();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.advAllDoc)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRules)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.advAllDoc);
            this.groupPanel1.Controls.Add(this.panel1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(212, 524);
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
            this.groupPanel1.Text = "文书类型";
            // 
            // advAllDoc
            // 
            this.advAllDoc.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.advAllDoc.AllowDrop = true;
            this.advAllDoc.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.advAllDoc.BackgroundStyle.Class = "TreeBorderKey";
            this.advAllDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.advAllDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advAllDoc.DragDropEnabled = false;
            this.advAllDoc.ImageList = this.imgListBook;
            this.advAllDoc.Location = new System.Drawing.Point(0, 21);
            this.advAllDoc.Name = "advAllDoc";
            this.advAllDoc.NodesConnector = this.nodeConnector4;
            this.advAllDoc.NodeStyle = this.elementStyle4;
            this.advAllDoc.PathSeparator = ";";
            this.advAllDoc.Size = new System.Drawing.Size(206, 477);
            this.advAllDoc.Styles.Add(this.elementStyle4);
            this.advAllDoc.Styles.Add(this.elementStyleBlue);
            this.advAllDoc.Styles.Add(this.elementStyleOrange);
            this.advAllDoc.Styles.Add(this.elementStyleRed);
            this.advAllDoc.TabIndex = 5;
            this.advAllDoc.Text = "advTree4";
            this.advAllDoc.NodeClick += new DevComponents.AdvTree.TreeNodeMouseEventHandler(this.advAllDoc_NodeClick);
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
            this.imgListBook.Images.SetKeyName(15, "表示文书大分类.gif");
            this.imgListBook.Images.SetKeyName(16, "单1.gif");
            this.imgListBook.Images.SetKeyName(17, "单2.gif");
            this.imgListBook.Images.SetKeyName(18, "多例文书.gif");
            this.imgListBook.Images.SetKeyName(19, "多例文书子节点.png");
            this.imgListBook.Images.SetKeyName(20, "文书大类的子节点.gif");
            this.imgListBook.Images.SetKeyName(21, "单例文书.png");
            this.imgListBook.Images.SetKeyName(22, "多例文书.png");
            this.imgListBook.Images.SetKeyName(23, "多例文书子文书.png");
            this.imgListBook.Images.SetKeyName(24, "文书类型.png");
            this.imgListBook.Images.SetKeyName(25, "住院记录.png");
            this.imgListBook.Images.SetKeyName(26, "pen (2).png");
            this.imgListBook.Images.SetKeyName(27, "pen.png");
            this.imgListBook.Images.SetKeyName(28, "Pencil1.png");
            this.imgListBook.Images.SetKeyName(29, "pencil-2.png");
            this.imgListBook.Images.SetKeyName(30, "pencil-16.png");
            this.imgListBook.Images.SetKeyName(31, "pencil-32.png");
            // 
            // nodeConnector4
            // 
            this.nodeConnector4.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle4
            // 
            this.elementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle4.Name = "elementStyle4";
            this.elementStyle4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            // 
            // elementStyleBlue
            // 
            this.elementStyleBlue.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyleBlue.Description = "Blue";
            this.elementStyleBlue.Name = "elementStyleBlue";
            this.elementStyleBlue.TextColor = System.Drawing.Color.Blue;
            // 
            // elementStyleOrange
            // 
            this.elementStyleOrange.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyleOrange.Description = "Orange";
            this.elementStyleOrange.Name = "elementStyleOrange";
            this.elementStyleOrange.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(130)))), ((int)(((byte)(0)))));
            // 
            // elementStyleRed
            // 
            this.elementStyleRed.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyleRed.Description = "Red";
            this.elementStyleRed.Name = "elementStyleRed";
            this.elementStyleRed.TextColor = System.Drawing.Color.Red;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtSearchAllText);
            this.panel1.Controls.Add(this.picSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(206, 21);
            this.panel1.TabIndex = 4;
            // 
            // txtSearchAllText
            // 
            this.txtSearchAllText.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSearchAllText.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtSearchAllText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchAllText.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSearchAllText.Location = new System.Drawing.Point(0, 0);
            this.txtSearchAllText.Multiline = true;
            this.txtSearchAllText.Name = "txtSearchAllText";
            this.txtSearchAllText.Size = new System.Drawing.Size(190, 21);
            this.txtSearchAllText.TabIndex = 3;
            this.txtSearchAllText.TextChanged += new System.EventHandler(this.txtSearchAllText_TextChanged);
            // 
            // picSearch
            // 
            this.picSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.picSearch.Image = global::Base_Function.Resource.search_lense;
            this.picSearch.Location = new System.Drawing.Point(190, 0);
            this.picSearch.Name = "picSearch";
            this.picSearch.Size = new System.Drawing.Size(16, 21);
            this.picSearch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSearch.TabIndex = 2;
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.picSearch_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dtgRules);
            this.groupPanel2.Controls.Add(this.toolStrip1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupPanel2.Location = new System.Drawing.Point(222, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(504, 524);
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
            this.groupPanel2.Text = "列表";
            // 
            // dtgRules
            // 
            this.dtgRules.AllowUserToAddRows = false;
            this.dtgRules.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgRules.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgRules.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRules.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtgRules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgRules.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtgRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgRules.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dtgRules.Location = new System.Drawing.Point(0, 25);
            this.dtgRules.MultiSelect = false;
            this.dtgRules.Name = "dtgRules";
            this.dtgRules.ReadOnly = true;
            this.dtgRules.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtgRules.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgRules.RowTemplate.Height = 23;
            this.dtgRules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRules.Size = new System.Drawing.Size(498, 473);
            this.dtgRules.TabIndex = 0;
            this.dtgRules.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dtgRules_RowStateChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 9F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnNewRule,
            this.tbtnChange,
            this.tbtnDel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(498, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnNewRule
            // 
            this.tbtnNewRule.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnNewRule.Image = ((System.Drawing.Image)(resources.GetObject("tbtnNewRule.Image")));
            this.tbtnNewRule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnNewRule.Name = "tbtnNewRule";
            this.tbtnNewRule.Size = new System.Drawing.Size(36, 22);
            this.tbtnNewRule.Text = "新建";
            this.tbtnNewRule.Click += new System.EventHandler(this.tbtnNewRule_Click);
            // 
            // tbtnChange
            // 
            this.tbtnChange.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnChange.Image = ((System.Drawing.Image)(resources.GetObject("tbtnChange.Image")));
            this.tbtnChange.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnChange.Name = "tbtnChange";
            this.tbtnChange.Size = new System.Drawing.Size(36, 22);
            this.tbtnChange.Text = "修改";
            this.tbtnChange.Click += new System.EventHandler(this.tbtnChange_Click);
            // 
            // tbtnDel
            // 
            this.tbtnDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tbtnDel.Image = ((System.Drawing.Image)(resources.GetObject("tbtnDel.Image")));
            this.tbtnDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDel.Name = "tbtnDel";
            this.tbtnDel.Size = new System.Drawing.Size(36, 22);
            this.tbtnDel.Text = "删除";
            this.tbtnDel.Click += new System.EventHandler(this.tbtnDel_Click);
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
            this.expandableSplitter1.Location = new System.Drawing.Point(212, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(10, 524);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 2;
            this.expandableSplitter1.TabStop = false;
            // 
            // ucMedicalMark_NEW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucMedicalMark_NEW";
            this.Size = new System.Drawing.Size(726, 524);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.advAllDoc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRules)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dtgRules;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearchAllText;
        private System.Windows.Forms.PictureBox picSearch;
        private DevComponents.AdvTree.AdvTree advAllDoc;
        private DevComponents.AdvTree.NodeConnector nodeConnector4;
        private DevComponents.DotNetBar.ElementStyle elementStyle4;
        private DevComponents.DotNetBar.ElementStyle elementStyleBlue;
        private DevComponents.DotNetBar.ElementStyle elementStyleOrange;
        private DevComponents.DotNetBar.ElementStyle elementStyleRed;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private System.Windows.Forms.ImageList imgListBook;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnNewRule;
        private System.Windows.Forms.ToolStripButton tbtnChange;
        private System.Windows.Forms.ToolStripButton tbtnDel;
    }
}
