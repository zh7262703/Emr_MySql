namespace Base_Function.BASE_DATA
{
    partial class frmKBSCommonSection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKBSCommonSection));
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cmDirectory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.增加子目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.增加选择类元素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.父节点选择StripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.全部展开WToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部收缩ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tspUp = new System.Windows.Forms.ToolStripMenuItem();
            this.tspDown = new System.Windows.Forms.ToolStripMenuItem();
            this.排序确认ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新ZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnQuery = new DevComponents.DotNetBar.ButtonX();
            this.btnComplexSave = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComplexName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.增加输入框类元素ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制节点toolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.advTreeSmallTemplate = new Base_Function.BASE_DATA.KBS.uc_TreeView(this.components);
            this.groupPanel3.SuspendLayout();
            this.cmDirectory.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel3
            // 
            this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.advTreeSmallTemplate);
            this.groupPanel3.Controls.Add(this.panel1);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(356, 451);
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
            this.groupPanel3.TabIndex = 16;
            this.groupPanel3.Text = "知识库列表";
            // 
            // cmDirectory
            // 
            this.cmDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.父节点选择StripMenuItem,
            this.复制节点toolStripMenu,
            this.toolStripSeparator6,
            this.全部展开WToolStripMenuItem,
            this.全部收缩ToolStripMenuItem,
            this.tspUp,
            this.tspDown,
            this.排序确认ToolStripMenuItem,
            this.toolStripSeparator1,
            this.刷新ZToolStripMenuItem,
            this.toolStripSeparator5});
            this.cmDirectory.Name = "cmDirectory";
            this.cmDirectory.Size = new System.Drawing.Size(153, 286);
            this.cmDirectory.Opening += new System.ComponentModel.CancelEventHandler(this.cmDirectory_Opening);
            // 
            // zToolStripMenuItem
            // 
            this.zToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.增加子目录ToolStripMenuItem,
            this.toolStripSeparator2,
            this.增加选择类元素ToolStripMenuItem});
            this.zToolStripMenuItem.Name = "zToolStripMenuItem";
            this.zToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.zToolStripMenuItem.Text = "增加元素(&U)";
            // 
            // 增加子目录ToolStripMenuItem
            // 
            this.增加子目录ToolStripMenuItem.Name = "增加子目录ToolStripMenuItem";
            this.增加子目录ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.增加子目录ToolStripMenuItem.Text = "增加子目录            alt+1";
            this.增加子目录ToolStripMenuItem.Click += new System.EventHandler(this.增加子目录ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // 增加选择类元素ToolStripMenuItem
            // 
            this.增加选择类元素ToolStripMenuItem.Name = "增加选择类元素ToolStripMenuItem";
            this.增加选择类元素ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.增加选择类元素ToolStripMenuItem.Text = "增加内容元素      alt+2";
            this.增加选择类元素ToolStripMenuItem.Click += new System.EventHandler(this.增加选择类元素ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "修改标题(&R)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "删除节点(&Q)";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 父节点选择StripMenuItem
            // 
            this.父节点选择StripMenuItem.Name = "父节点选择StripMenuItem";
            this.父节点选择StripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.父节点选择StripMenuItem.Text = "更改父节点";
            this.父节点选择StripMenuItem.Click += new System.EventHandler(this.父节点选择StripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(149, 6);
            // 
            // 全部展开WToolStripMenuItem
            // 
            this.全部展开WToolStripMenuItem.Name = "全部展开WToolStripMenuItem";
            this.全部展开WToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全部展开WToolStripMenuItem.Text = "全部展开(&W)";
            this.全部展开WToolStripMenuItem.Click += new System.EventHandler(this.全部展开WToolStripMenuItem_Click);
            // 
            // 全部收缩ToolStripMenuItem
            // 
            this.全部收缩ToolStripMenuItem.Name = "全部收缩ToolStripMenuItem";
            this.全部收缩ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.全部收缩ToolStripMenuItem.Text = "全部收缩(&S)";
            this.全部收缩ToolStripMenuItem.Click += new System.EventHandler(this.全部收缩ToolStripMenuItem_Click);
            // 
            // tspUp
            // 
            this.tspUp.Name = "tspUp";
            this.tspUp.Size = new System.Drawing.Size(152, 22);
            this.tspUp.Text = "上移";
            this.tspUp.Click += new System.EventHandler(this.tspUp_Click);
            // 
            // tspDown
            // 
            this.tspDown.Name = "tspDown";
            this.tspDown.Size = new System.Drawing.Size(152, 22);
            this.tspDown.Text = "下移";
            this.tspDown.Click += new System.EventHandler(this.tspDown_Click);
            // 
            // 排序确认ToolStripMenuItem
            // 
            this.排序确认ToolStripMenuItem.Name = "排序确认ToolStripMenuItem";
            this.排序确认ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.排序确认ToolStripMenuItem.Text = "排序确认";
            this.排序确认ToolStripMenuItem.Click += new System.EventHandler(this.排序确认ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // 刷新ZToolStripMenuItem
            // 
            this.刷新ZToolStripMenuItem.Name = "刷新ZToolStripMenuItem";
            this.刷新ZToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.刷新ZToolStripMenuItem.Text = "刷新(&Z)";
            this.刷新ZToolStripMenuItem.Click += new System.EventHandler(this.刷新ZToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "TextEditor.icon.close_2.bmp");
            this.imageList1.Images.SetKeyName(1, "TextEditor.icon.open_2.bmp");
            this.imageList1.Images.SetKeyName(2, "TextEditor.icon.close.bmp");
            this.imageList1.Images.SetKeyName(3, "TextEditor.icon.open.bmp");
            this.imageList1.Images.SetKeyName(4, "TextEditor.icon.frm.bmp");
            this.imageList1.Images.SetKeyName(5, "script.bmp");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.btnComplexSave);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtComplexName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 31);
            this.panel1.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnQuery.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnQuery.Location = new System.Drawing.Point(187, 3);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 5;
            this.btnQuery.Text = "查找";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // btnComplexSave
            // 
            this.btnComplexSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnComplexSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnComplexSave.Location = new System.Drawing.Point(268, 3);
            this.btnComplexSave.Name = "btnComplexSave";
            this.btnComplexSave.Size = new System.Drawing.Size(75, 23);
            this.btnComplexSave.TabIndex = 4;
            this.btnComplexSave.Text = "保存";
            this.btnComplexSave.Click += new System.EventHandler(this.btnComplexSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "名称：";
            // 
            // txtComplexName
            // 
            this.txtComplexName.Location = new System.Drawing.Point(50, 5);
            this.txtComplexName.Name = "txtComplexName";
            this.txtComplexName.Size = new System.Drawing.Size(131, 21);
            this.txtComplexName.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel6);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(356, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 451);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "知识库内容";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 51);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(563, 397);
            this.panel6.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(3, 17);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(563, 34);
            this.panel5.TabIndex = 1;
            this.panel5.Visible = false;
            // 
            // 增加输入框类元素ToolStripMenuItem
            // 
            this.增加输入框类元素ToolStripMenuItem.Name = "增加输入框类元素ToolStripMenuItem";
            this.增加输入框类元素ToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.增加输入框类元素ToolStripMenuItem.Text = "增加输入框类元素   alt+3";
            // 
            // 复制节点toolStripMenu
            // 
            this.复制节点toolStripMenu.Name = "复制节点toolStripMenu";
            this.复制节点toolStripMenu.Size = new System.Drawing.Size(152, 22);
            this.复制节点toolStripMenu.Text = "复制节点";
            this.复制节点toolStripMenu.Click += new System.EventHandler(this.复制节点toolStripMenu_Click);
            // 
            // advTreeSmallTemplate
            // 
            this.advTreeSmallTemplate.ContextMenuStrip = this.cmDirectory;
            this.advTreeSmallTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.advTreeSmallTemplate.ImageIndex = 0;
            this.advTreeSmallTemplate.ImageList = this.imageList1;
            this.advTreeSmallTemplate.Location = new System.Drawing.Point(0, 31);
            this.advTreeSmallTemplate.Name = "advTreeSmallTemplate";
            this.advTreeSmallTemplate.PathSeparator = "〓";
            this.advTreeSmallTemplate.SelectedImageIndex = 0;
            this.advTreeSmallTemplate.Size = new System.Drawing.Size(350, 396);
            this.advTreeSmallTemplate.TabIndex = 1;
            this.advTreeSmallTemplate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.advTreeSmallTemplate_AfterSelect);
            // 
            // frmKBSCommonSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupPanel3);
            this.Name = "frmKBSCommonSection";
            this.Size = new System.Drawing.Size(925, 451);
            this.Load += new System.EventHandler(this.frmKBSCommon_Load);
            this.groupPanel3.ResumeLayout(false);
            this.cmDirectory.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ContextMenuStrip cmDirectory;
        private System.Windows.Forms.ToolStripMenuItem zToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加子目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 增加选择类元素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 增加输入框类元素ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem 全部展开WToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部收缩ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tspUp;
        private System.Windows.Forms.ToolStripMenuItem tspDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 刷新ZToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.ButtonX btnQuery;
        private DevComponents.DotNetBar.ButtonX btnComplexSave;
        private System.Windows.Forms.TextBox txtComplexName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolStripMenuItem 父节点选择StripMenuItem;
        private Base_Function.BASE_DATA.KBS.uc_TreeView advTreeSmallTemplate;
        private System.Windows.Forms.ToolStripMenuItem 排序确认ToolStripMenuItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem 复制节点toolStripMenu;
    }
}
