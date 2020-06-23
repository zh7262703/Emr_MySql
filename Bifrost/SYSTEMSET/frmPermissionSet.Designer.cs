namespace Bifrost
{
    partial class frmPermissionSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPermissionSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加主ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加子菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.上移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下移ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rbtnButton = new System.Windows.Forms.RadioButton();
            this.rbtnMenu = new System.Windows.Forms.RadioButton();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.fg = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.trvMenuOrButton = new DevComponents.AdvTree.AdvTree();
            this.nodeConnector1 = new DevComponents.AdvTree.NodeConnector();
            this.elementStyle1 = new DevComponents.DotNetBar.ElementStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.rbtnTab = new System.Windows.Forms.RadioButton();
            this.contextMenuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trvMenuOrButton)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加主ToolStripMenuItem,
            this.添加子菜单ToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripMenuItem7,
            this.toolStripMenuItem8,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.上移ToolStripMenuItem,
            this.下移ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 204);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 添加主ToolStripMenuItem
            // 
            this.添加主ToolStripMenuItem.Name = "添加主ToolStripMenuItem";
            this.添加主ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.添加主ToolStripMenuItem.Text = "添加主菜单";
            this.添加主ToolStripMenuItem.Click += new System.EventHandler(this.添加主ToolStripMenuItem_Click);
            // 
            // 添加子菜单ToolStripMenuItem
            // 
            this.添加子菜单ToolStripMenuItem.Name = "添加子菜单ToolStripMenuItem";
            this.添加子菜单ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.添加子菜单ToolStripMenuItem.Text = "添加子菜单";
            this.添加子菜单ToolStripMenuItem.Click += new System.EventHandler(this.添加子菜单ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(133, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem2.Text = "添加按钮";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem4.Text = "删除";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(133, 6);
            // 
            // 上移ToolStripMenuItem
            // 
            this.上移ToolStripMenuItem.Name = "上移ToolStripMenuItem";
            this.上移ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.上移ToolStripMenuItem.Text = "上移";
            this.上移ToolStripMenuItem.Click += new System.EventHandler(this.上移ToolStripMenuItem_Click);
            // 
            // 下移ToolStripMenuItem
            // 
            this.下移ToolStripMenuItem.Name = "下移ToolStripMenuItem";
            this.下移ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.下移ToolStripMenuItem.Text = "下移";
            this.下移ToolStripMenuItem.Click += new System.EventHandler(this.下移ToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "EditCodeHS.png");
            this.imageList1.Images.SetKeyName(1, "ThumbnailView.png");
            // 
            // rbtnButton
            // 
            this.rbtnButton.AutoSize = true;
            this.rbtnButton.Location = new System.Drawing.Point(70, 8);
            this.rbtnButton.Name = "rbtnButton";
            this.rbtnButton.Size = new System.Drawing.Size(47, 16);
            this.rbtnButton.TabIndex = 2;
            this.rbtnButton.Text = "按钮";
            this.rbtnButton.UseVisualStyleBackColor = true;
            this.rbtnButton.CheckedChanged += new System.EventHandler(this.rbtnButton_CheckedChanged);
            // 
            // rbtnMenu
            // 
            this.rbtnMenu.AutoSize = true;
            this.rbtnMenu.Checked = true;
            this.rbtnMenu.Location = new System.Drawing.Point(17, 8);
            this.rbtnMenu.Name = "rbtnMenu";
            this.rbtnMenu.Size = new System.Drawing.Size(47, 16);
            this.rbtnMenu.TabIndex = 1;
            this.rbtnMenu.TabStop = true;
            this.rbtnMenu.Text = "菜单";
            this.rbtnMenu.UseVisualStyleBackColor = true;
            this.rbtnMenu.CheckedChanged += new System.EventHandler(this.rbtnButton_CheckedChanged);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.fg);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(220, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(499, 546);
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
            this.groupPanel1.Text = "菜单详细信息";
            // 
            // fg
            // 
            this.fg.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.fg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.fg.DefaultCellStyle = dataGridViewCellStyle4;
            this.fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.fg.Location = new System.Drawing.Point(0, 0);
            this.fg.Name = "fg";
            this.fg.RowTemplate.Height = 23;
            this.fg.Size = new System.Drawing.Size(493, 522);
            this.fg.TabIndex = 2;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.trvMenuOrButton);
            this.groupPanel2.Controls.Add(this.panel1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(210, 546);
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
            this.groupPanel2.TabIndex = 0;
            this.groupPanel2.Text = "菜单列表";
            // 
            // trvMenuOrButton
            // 
            this.trvMenuOrButton.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline;
            this.trvMenuOrButton.AllowDrop = true;
            this.trvMenuOrButton.BackColor = System.Drawing.SystemColors.Window;
            // 
            // 
            // 
            this.trvMenuOrButton.BackgroundStyle.Class = "TreeBorderKey";
            this.trvMenuOrButton.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.trvMenuOrButton.ContextMenuStrip = this.contextMenuStrip1;
            this.trvMenuOrButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMenuOrButton.ImageList = this.imageList1;
            this.trvMenuOrButton.Location = new System.Drawing.Point(0, 35);
            this.trvMenuOrButton.Name = "trvMenuOrButton";
            this.trvMenuOrButton.NodesConnector = this.nodeConnector1;
            this.trvMenuOrButton.NodeStyle = this.elementStyle1;
            this.trvMenuOrButton.PathSeparator = ";";
            this.trvMenuOrButton.Size = new System.Drawing.Size(204, 487);
            this.trvMenuOrButton.Styles.Add(this.elementStyle1);
            this.trvMenuOrButton.TabIndex = 1;
            this.trvMenuOrButton.Text = "advTree1";
            this.trvMenuOrButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trvMenuOrButton_MouseClick);
            this.trvMenuOrButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvMenuOrButton_MouseDown);
            this.trvMenuOrButton.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trvMenuOrButton_MouseDoubleClick);
            this.trvMenuOrButton.AfterNodeDeselect += new DevComponents.AdvTree.AdvTreeNodeEventHandler(this.trvMenuOrButton_AfterNodeDeselect);
            // 
            // nodeConnector1
            // 
            this.nodeConnector1.LineColor = System.Drawing.SystemColors.ControlText;
            // 
            // elementStyle1
            // 
            this.elementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.elementStyle1.Name = "elementStyle1";
            this.elementStyle1.TextColor = System.Drawing.SystemColors.ControlText;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.rbtnTab);
            this.panel1.Controls.Add(this.rbtnButton);
            this.panel1.Controls.Add(this.rbtnMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(204, 35);
            this.panel1.TabIndex = 0;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.groupPanel2;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(210, 0);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(10, 546);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 2;
            this.expandableSplitter1.TabStop = false;
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem7.Text = "添加主页签";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem8.Text = "添加子页签";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // rbtnTab
            // 
            this.rbtnTab.AutoSize = true;
            this.rbtnTab.Location = new System.Drawing.Point(123, 8);
            this.rbtnTab.Name = "rbtnTab";
            this.rbtnTab.Size = new System.Drawing.Size(47, 16);
            this.rbtnTab.TabIndex = 3;
            this.rbtnTab.Text = "页签";
            this.rbtnTab.UseVisualStyleBackColor = true;
            this.rbtnTab.CheckedChanged += new System.EventHandler(this.rbtnButton_CheckedChanged);
            // 
            // frmPermissionSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.groupPanel2);
            this.Name = "frmPermissionSet";
            this.Size = new System.Drawing.Size(719, 546);
            this.Load += new System.EventHandler(this.frmPermissionSet_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trvMenuOrButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加主ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加子菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 上移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下移ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.RadioButton rbtnButton;
        private System.Windows.Forms.RadioButton rbtnMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.AdvTree.AdvTree trvMenuOrButton;
        private DevComponents.AdvTree.NodeConnector nodeConnector1;
        private DevComponents.DotNetBar.ElementStyle elementStyle1;
        private DevComponents.DotNetBar.Controls.DataGridViewX fg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.RadioButton rbtnTab;
    }
}