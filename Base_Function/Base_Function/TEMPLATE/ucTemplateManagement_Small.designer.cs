namespace Base_Function.TEMPLATE
{
    partial class ucTemplateManagement_Small
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTemplateManagement_Small));
            this.button1 = new DevComponents.DotNetBar.ButtonX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSmallTemplate = new System.Windows.Forms.CheckBox();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.button2 = new DevComponents.DotNetBar.ButtonX();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.cboModelType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdoSection = new System.Windows.Forms.RadioButton();
            this.rdoPersonal = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ctmTreeViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSetPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSetSectionModel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.删除文书模版ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListBook = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ctmTreeViewMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button1.Location = new System.Drawing.Point(63, 176);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 33);
            this.button1.TabIndex = 24;
            this.button1.Text = "创建模板";
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1280, 616);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer2.Size = new System.Drawing.Size(308, 616);
            this.splitContainer2.SplitterDistance = 238;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSmallTemplate);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.txtDocName);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.cboModelType);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rdoSection);
            this.groupBox2.Controls.Add(this.rdoPersonal);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(308, 238);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "条件设置";
            // 
            // chkSmallTemplate
            // 
            this.chkSmallTemplate.AutoSize = true;
            this.chkSmallTemplate.Location = new System.Drawing.Point(176, 57);
            this.chkSmallTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkSmallTemplate.Name = "chkSmallTemplate";
            this.chkSmallTemplate.Size = new System.Drawing.Size(87, 21);
            this.chkSmallTemplate.TabIndex = 25;
            this.chkSmallTemplate.Text = "禁用小模板";
            this.chkSmallTemplate.UseVisualStyleBackColor = true;
            this.chkSmallTemplate.CheckedChanged += new System.EventHandler(this.chkSmallTemplate_CheckedChanged);
            // 
            // txtDocName
            // 
            this.txtDocName.Location = new System.Drawing.Point(80, 136);
            this.txtDocName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(152, 23);
            this.txtDocName.TabIndex = 19;
            // 
            // button2
            // 
            this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(157, 176);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 33);
            this.button2.TabIndex = 13;
            this.button2.Text = "保存模版";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.Location = new System.Drawing.Point(236, 133);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(58, 33);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboModelType
            // 
            this.cboModelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelType.FormattingEnabled = true;
            this.cboModelType.Location = new System.Drawing.Point(79, 96);
            this.cboModelType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboModelType.Name = "cboModelType";
            this.cboModelType.Size = new System.Drawing.Size(184, 25);
            this.cboModelType.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "类型：";
            // 
            // rdoSection
            // 
            this.rdoSection.AutoSize = true;
            this.rdoSection.Location = new System.Drawing.Point(97, 55);
            this.rdoSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoSection.Name = "rdoSection";
            this.rdoSection.Size = new System.Drawing.Size(50, 21);
            this.rdoSection.TabIndex = 2;
            this.rdoSection.Text = "科室";
            this.rdoSection.UseVisualStyleBackColor = true;
            // 
            // rdoPersonal
            // 
            this.rdoPersonal.AutoSize = true;
            this.rdoPersonal.Checked = true;
            this.rdoPersonal.Location = new System.Drawing.Point(33, 55);
            this.rdoPersonal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoPersonal.Name = "rdoPersonal";
            this.rdoPersonal.Size = new System.Drawing.Size(50, 21);
            this.rdoPersonal.TabIndex = 1;
            this.rdoPersonal.TabStop = true;
            this.rdoPersonal.Text = "个人";
            this.rdoPersonal.UseVisualStyleBackColor = true;
            this.rdoPersonal.CheckedChanged += new System.EventHandler(this.rdoPersonal_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "使用范围：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(17, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "模板名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(308, 372);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模版列表";
            // 
            // treeView1
            // 
            this.treeView1.ContextMenuStrip = this.ctmTreeViewMenu;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imgListBook;
            this.treeView1.Location = new System.Drawing.Point(3, 20);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(302, 348);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ctmTreeViewMenu
            // 
            this.ctmTreeViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSetPerson,
            this.tsmiSetSectionModel,
            this.toolStripMenuItem1,
            this.tsmiRename,
            this.删除文书模版ToolStripMenuItem});
            this.ctmTreeViewMenu.Name = "ctmTreeViewMenu";
            this.ctmTreeViewMenu.Size = new System.Drawing.Size(149, 114);
            this.ctmTreeViewMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctmTreeViewMenu_Opening);
            // 
            // tsmiSetPerson
            // 
            this.tsmiSetPerson.Name = "tsmiSetPerson";
            this.tsmiSetPerson.Size = new System.Drawing.Size(148, 22);
            this.tsmiSetPerson.Text = "设为个人模板";
            this.tsmiSetPerson.Click += new System.EventHandler(this.tsmiSetPerson_Click);
            // 
            // tsmiSetSectionModel
            // 
            this.tsmiSetSectionModel.Name = "tsmiSetSectionModel";
            this.tsmiSetSectionModel.Size = new System.Drawing.Size(148, 22);
            this.tsmiSetSectionModel.Text = "设为科室模板";
            this.tsmiSetSectionModel.Click += new System.EventHandler(this.tsmiSetSectionModel_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuItem1.Text = "添加文书模版";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // tsmiRename
            // 
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(148, 22);
            this.tsmiRename.Text = "模板重命名";
            this.tsmiRename.Click += new System.EventHandler(this.tsmiRename_Click);
            // 
            // 删除文书模版ToolStripMenuItem
            // 
            this.删除文书模版ToolStripMenuItem.Name = "删除文书模版ToolStripMenuItem";
            this.删除文书模版ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除文书模版ToolStripMenuItem.Text = "删除文书模版";
            this.删除文书模版ToolStripMenuItem.Click += new System.EventHandler(this.删除文书模版ToolStripMenuItem_Click);
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(967, 616);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "模版编辑";
            // 
            // ucTemplateManagement_Small
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ucTemplateManagement_Small";
            this.Size = new System.Drawing.Size(1280, 616);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ctmTreeViewMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDocName;
        public DevComponents.DotNetBar.ButtonX button2;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.ComboBox cboModelType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdoSection;
        private System.Windows.Forms.RadioButton rdoPersonal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip ctmTreeViewMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetPerson;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetSectionModel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
        private System.Windows.Forms.ToolStripMenuItem 删除文书模版ToolStripMenuItem;
        private System.Windows.Forms.ImageList imgListBook;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkSmallTemplate;
    }
}
