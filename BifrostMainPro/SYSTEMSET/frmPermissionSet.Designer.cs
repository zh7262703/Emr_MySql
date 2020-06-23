namespace LeadronTest.SYSTEMSET
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trvMenuOrButton = new System.Windows.Forms.TreeView();
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fg = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fg)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(721, 548);
            this.splitContainer1.SplitterDistance = 223;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvMenuOrButton);
            this.groupBox1.Controls.Add(this.rbtnButton);
            this.groupBox1.Controls.Add(this.rbtnMenu);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 548);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "列表";
            // 
            // trvMenuOrButton
            // 
            this.trvMenuOrButton.AllowDrop = true;
            this.trvMenuOrButton.ContextMenuStrip = this.contextMenuStrip1;
            this.trvMenuOrButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvMenuOrButton.HideSelection = false;
            this.trvMenuOrButton.HotTracking = true;
            this.trvMenuOrButton.ImageIndex = 0;
            this.trvMenuOrButton.ImageList = this.imageList1;
            this.trvMenuOrButton.Location = new System.Drawing.Point(3, 17);
            this.trvMenuOrButton.Name = "trvMenuOrButton";
            this.trvMenuOrButton.SelectedImageIndex = 0;
            this.trvMenuOrButton.Size = new System.Drawing.Size(217, 528);
            this.trvMenuOrButton.TabIndex = 0;
            this.trvMenuOrButton.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trvMenuOrButton_MouseDoubleClick);
            this.trvMenuOrButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trvMenuOrButton_MouseClick);
            this.trvMenuOrButton.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvMenuOrButton_AfterSelect);
            this.trvMenuOrButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvMenuOrButton_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加主ToolStripMenuItem,
            this.添加子菜单ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.上移ToolStripMenuItem,
            this.下移ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(135, 154);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // 添加主ToolStripMenuItem
            // 
            this.添加主ToolStripMenuItem.Name = "添加主ToolStripMenuItem";
            this.添加主ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.添加主ToolStripMenuItem.Text = "添加主菜单";
            this.添加主ToolStripMenuItem.Click += new System.EventHandler(this.添加主ToolStripMenuItem_Click);
            // 
            // 添加子菜单ToolStripMenuItem
            // 
            this.添加子菜单ToolStripMenuItem.Name = "添加子菜单ToolStripMenuItem";
            this.添加子菜单ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.添加子菜单ToolStripMenuItem.Text = "添加子菜单";
            this.添加子菜单ToolStripMenuItem.Click += new System.EventHandler(this.添加子菜单ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(131, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem2.Text = "添加按钮";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(134, 22);
            this.toolStripMenuItem4.Text = "删除";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(131, 6);
            // 
            // 上移ToolStripMenuItem
            // 
            this.上移ToolStripMenuItem.Name = "上移ToolStripMenuItem";
            this.上移ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.上移ToolStripMenuItem.Text = "上移";
            this.上移ToolStripMenuItem.Click += new System.EventHandler(this.上移ToolStripMenuItem_Click);
            // 
            // 下移ToolStripMenuItem
            // 
            this.下移ToolStripMenuItem.Name = "下移ToolStripMenuItem";
            this.下移ToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
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
            this.rbtnButton.Location = new System.Drawing.Point(170, 0);
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
            this.rbtnMenu.Location = new System.Drawing.Point(117, 0);
            this.rbtnMenu.Name = "rbtnMenu";
            this.rbtnMenu.Size = new System.Drawing.Size(47, 16);
            this.rbtnMenu.TabIndex = 1;
            this.rbtnMenu.TabStop = true;
            this.rbtnMenu.Text = "菜单";
            this.rbtnMenu.UseVisualStyleBackColor = true;
            this.rbtnMenu.CheckedChanged += new System.EventHandler(this.rbtnMenu_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fg);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 548);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "菜单详细信息";
            // 
            // fg
            // 
            this.fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            this.fg.ColumnInfo = "1,1,0,0,0,0,Columns:0{Width:20;Name:\"No\";AllowMerging:True;Style:\"EditMask:\"\"1\"\";" +
                "DataType:System.Decimal;TextAlign:RightCenter;\";}\t";
            this.fg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fg.Location = new System.Drawing.Point(3, 17);
            this.fg.Name = "fg";
            this.fg.Rows.Count = 1;
            this.fg.Rows.DefaultSize = 18;
            this.fg.Size = new System.Drawing.Size(488, 528);
            this.fg.StyleInfo = resources.GetString("fg.StyleInfo");
            this.fg.TabIndex = 1;
            this.fg.Tree.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fg.Tree.NodeImageCollapsed = ((System.Drawing.Image)(resources.GetObject("fg.Tree.NodeImageCollapsed")));
            this.fg.Tree.NodeImageExpanded = ((System.Drawing.Image)(resources.GetObject("fg.Tree.NodeImageExpanded")));
            // 
            // frmPermissionSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 548);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frmPermissionSet";
            this.Text = "菜单按钮设置";
            this.Load += new System.EventHandler(this.frmPermissionSet_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView trvMenuOrButton;
        private System.Windows.Forms.GroupBox groupBox2;
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
        private C1.Win.C1FlexGrid.C1FlexGrid fg;
        private System.Windows.Forms.ImageList imageList1;
    }
}