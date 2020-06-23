namespace Base_Function.BLL_FOLLOW
{
    partial class ucFollowTemplateManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFollowTemplateManagement));
            this.grpBoxEditor = new System.Windows.Forms.GroupBox();
            this.tsmiSetSectionModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiModel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDefaultModel = new System.Windows.Forms.ToolStripMenuItem();
            this.trvModel = new System.Windows.Forms.TreeView();
            this.ctmTreeViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加文书模板toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRename = new System.Windows.Forms.ToolStripMenuItem();
            this.删除文书模版ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无效ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgListBook = new System.Windows.Forms.ImageList(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDetaiInfo = new System.Windows.Forms.Button();
            this.txtDocName = new System.Windows.Forms.TextBox();
            this.btnNewPage = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboTextKind = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cboSicknessKind = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoHospital = new System.Windows.Forms.RadioButton();
            this.rdoSection = new System.Windows.Forms.RadioButton();
            this.rdoPersonal = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctmTreeViewMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxEditor
            // 
            this.grpBoxEditor.BackColor = System.Drawing.Color.Transparent;
            this.grpBoxEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxEditor.Location = new System.Drawing.Point(0, 0);
            this.grpBoxEditor.Name = "grpBoxEditor";
            this.grpBoxEditor.Size = new System.Drawing.Size(776, 624);
            this.grpBoxEditor.TabIndex = 0;
            this.grpBoxEditor.TabStop = false;
            this.grpBoxEditor.Text = "模版编辑";
            // 
            // tsmiSetSectionModel
            // 
            this.tsmiSetSectionModel.ForeColor = System.Drawing.Color.Black;
            this.tsmiSetSectionModel.Name = "tsmiSetSectionModel";
            this.tsmiSetSectionModel.Size = new System.Drawing.Size(184, 22);
            this.tsmiSetSectionModel.Text = "设为科室模板";
            this.tsmiSetSectionModel.Click += new System.EventHandler(this.tsmiSetSectionModel_Click);
            // 
            // tsmiModel
            // 
            this.tsmiModel.ForeColor = System.Drawing.Color.Black;
            this.tsmiModel.Name = "tsmiModel";
            this.tsmiModel.Size = new System.Drawing.Size(184, 22);
            this.tsmiModel.Text = "设置为全院模板";
            this.tsmiModel.Click += new System.EventHandler(this.tsmiModel_Click);
            // 
            // tsmiDefaultModel
            // 
            this.tsmiDefaultModel.ForeColor = System.Drawing.Color.Black;
            this.tsmiDefaultModel.Name = "tsmiDefaultModel";
            this.tsmiDefaultModel.Size = new System.Drawing.Size(184, 22);
            this.tsmiDefaultModel.Text = "设置为全院默认模板";
            this.tsmiDefaultModel.Click += new System.EventHandler(this.tsmiDefaultModel_Click);
            // 
            // trvModel
            // 
            this.trvModel.ContextMenuStrip = this.ctmTreeViewMenu;
            this.trvModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvModel.HideSelection = false;
            this.trvModel.ImageIndex = 0;
            this.trvModel.ImageList = this.imgListBook;
            this.trvModel.Location = new System.Drawing.Point(3, 17);
            this.trvModel.Name = "trvModel";
            this.trvModel.SelectedImageIndex = 0;
            this.trvModel.Size = new System.Drawing.Size(238, 352);
            this.trvModel.TabIndex = 5;
            this.trvModel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ctmTreeViewMenu
            // 
            this.ctmTreeViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDefaultModel,
            this.tsmiModel,
            this.tsmiSetSectionModel,
            this.添加文书模板toolStripMenuItem,
            this.tsmiRename,
            this.删除文书模版ToolStripMenuItem,
            this.无效ToolStripMenuItem});
            this.ctmTreeViewMenu.Name = "ctmTreeViewMenu";
            this.ctmTreeViewMenu.Size = new System.Drawing.Size(185, 158);
            this.ctmTreeViewMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ctmTreeViewMenu_Opening);
            // 
            // 添加文书模板toolStripMenuItem
            // 
            this.添加文书模板toolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.添加文书模板toolStripMenuItem.Name = "添加文书模板toolStripMenuItem";
            this.添加文书模板toolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.添加文书模板toolStripMenuItem.Text = "添加文书模版";
            this.添加文书模板toolStripMenuItem.Click += new System.EventHandler(this.添加文书模板toolStripMenuItem1_Click);
            // 
            // tsmiRename
            // 
            this.tsmiRename.ForeColor = System.Drawing.Color.Black;
            this.tsmiRename.Name = "tsmiRename";
            this.tsmiRename.Size = new System.Drawing.Size(184, 22);
            this.tsmiRename.Text = "模板重命名";
            this.tsmiRename.Click += new System.EventHandler(this.tsmirename_click);
            // 
            // 删除文书模版ToolStripMenuItem
            // 
            this.删除文书模版ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.删除文书模版ToolStripMenuItem.Name = "删除文书模版ToolStripMenuItem";
            this.删除文书模版ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.删除文书模版ToolStripMenuItem.Text = "删除文书模版";
            this.删除文书模版ToolStripMenuItem.Click += new System.EventHandler(this.删除文书模版ToolStripMenuItem_Click);
            // 
            // 无效ToolStripMenuItem
            // 
            this.无效ToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.无效ToolStripMenuItem.Name = "无效ToolStripMenuItem";
            this.无效ToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.无效ToolStripMenuItem.Text = "无效";
            this.无效ToolStripMenuItem.Click += new System.EventHandler(this.无效ToolStripMenuItem_Click);
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 34;
            this.label12.Text = "个人级模板";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Crimson;
            this.label11.Location = new System.Drawing.Point(168, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 33;
            this.label11.Text = "普通科室模板";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(43, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 32;
            this.label10.Text = "科室级默认模板";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(43, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 31;
            this.label9.Text = "全院级默认模板";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trvModel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 372);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "模版列表";
            // 
            // btnDetaiInfo
            // 
            this.btnDetaiInfo.Location = new System.Drawing.Point(167, 180);
            this.btnDetaiInfo.Name = "btnDetaiInfo";
            this.btnDetaiInfo.Size = new System.Drawing.Size(75, 23);
            this.btnDetaiInfo.TabIndex = 24;
            this.btnDetaiInfo.Text = "详细信息";
            this.btnDetaiInfo.UseVisualStyleBackColor = true;
            this.btnDetaiInfo.Click += new System.EventHandler(this.btnDetaiInfo_Click);
            // 
            // txtDocName
            // 
            this.txtDocName.Location = new System.Drawing.Point(105, 150);
            this.txtDocName.Name = "txtDocName";
            this.txtDocName.Size = new System.Drawing.Size(128, 21);
            this.txtDocName.TabIndex = 19;
            // 
            // btnNewPage
            // 
            this.btnNewPage.Location = new System.Drawing.Point(189, 273);
            this.btnNewPage.Name = "btnNewPage";
            this.btnNewPage.Size = new System.Drawing.Size(75, 23);
            this.btnNewPage.TabIndex = 17;
            this.btnNewPage.Text = "新页面";
            this.btnNewPage.UseVisualStyleBackColor = true;
            this.btnNewPage.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(74, 180);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存模版";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.grpBoxEditor);
            this.splitContainer1.Size = new System.Drawing.Size(1024, 624);
            this.splitContainer1.SplitterDistance = 244;
            this.splitContainer1.TabIndex = 7;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainer2.Size = new System.Drawing.Size(244, 624);
            this.splitContainer2.SplitterDistance = 248;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.pictureBox7);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.pictureBox4);
            this.groupBox2.Controls.Add(this.pictureBox3);
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnDetaiInfo);
            this.groupBox2.Controls.Add(this.txtDocName);
            this.groupBox2.Controls.Add(this.btnNewPage);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.cboTextKind);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.cboSicknessKind);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.rdoHospital);
            this.groupBox2.Controls.Add(this.rdoSection);
            this.groupBox2.Controls.Add(this.rdoPersonal);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 248);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "条件设置";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.DarkOrange;
            this.label15.Location = new System.Drawing.Point(168, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 40;
            this.label15.Text = "全院级模板";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(6, 180);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboTextKind
            // 
            this.cboTextKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextKind.FormattingEnabled = true;
            this.cboTextKind.Items.AddRange(new object[] {
            "请选择..."});
            this.cboTextKind.Location = new System.Drawing.Point(74, 275);
            this.cboTextKind.Name = "cboTextKind";
            this.cboTextKind.Size = new System.Drawing.Size(112, 20);
            this.cboTextKind.TabIndex = 10;
            this.cboTextKind.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 278);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "文书类型：";
            this.label4.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(192, 251);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "默认选项";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // cboSicknessKind
            // 
            this.cboSicknessKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSicknessKind.FormattingEnabled = true;
            this.cboSicknessKind.Items.AddRange(new object[] {
            "请选择..."});
            this.cboSicknessKind.Location = new System.Drawing.Point(74, 249);
            this.cboSicknessKind.Name = "cboSicknessKind";
            this.cboSicknessKind.Size = new System.Drawing.Size(112, 20);
            this.cboSicknessKind.TabIndex = 7;
            this.cboSicknessKind.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 252);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "病种类：";
            this.label3.Visible = false;
            // 
            // rdoHospital
            // 
            this.rdoHospital.AutoSize = true;
            this.rdoHospital.Location = new System.Drawing.Point(136, 39);
            this.rdoHospital.Name = "rdoHospital";
            this.rdoHospital.Size = new System.Drawing.Size(47, 16);
            this.rdoHospital.TabIndex = 3;
            this.rdoHospital.Text = "全院";
            this.rdoHospital.UseVisualStyleBackColor = true;
            // 
            // rdoSection
            // 
            this.rdoSection.AutoSize = true;
            this.rdoSection.Location = new System.Drawing.Point(83, 39);
            this.rdoSection.Name = "rdoSection";
            this.rdoSection.Size = new System.Drawing.Size(47, 16);
            this.rdoSection.TabIndex = 2;
            this.rdoSection.Text = "科室";
            this.rdoSection.UseVisualStyleBackColor = true;
            // 
            // rdoPersonal
            // 
            this.rdoPersonal.AutoSize = true;
            this.rdoPersonal.Checked = true;
            this.rdoPersonal.Location = new System.Drawing.Point(28, 39);
            this.rdoPersonal.Name = "rdoPersonal";
            this.rdoPersonal.Size = new System.Drawing.Size(47, 16);
            this.rdoPersonal.TabIndex = 1;
            this.rdoPersonal.TabStop = true;
            this.rdoPersonal.Text = "个人";
            this.rdoPersonal.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(16, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "随访问卷名称：";
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Gold;
            this.pictureBox7.Location = new System.Drawing.Point(147, 64);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(15, 15);
            this.pictureBox7.TabIndex = 39;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.SystemColors.ControlText;
            this.pictureBox4.Location = new System.Drawing.Point(17, 112);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(15, 15);
            this.pictureBox4.TabIndex = 30;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Crimson;
            this.pictureBox3.Location = new System.Drawing.Point(147, 85);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(15, 15);
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Blue;
            this.pictureBox2.Location = new System.Drawing.Point(18, 82);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 15);
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGreen;
            this.pictureBox1.Location = new System.Drawing.Point(18, 61);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // ucFollowTemplateManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucFollowTemplateManagement";
            this.Size = new System.Drawing.Size(1024, 624);
            this.ctmTreeViewMenu.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.GroupBox grpBoxEditor;
        private System.Windows.Forms.ToolStripMenuItem tsmiSetSectionModel;
        private System.Windows.Forms.ToolStripMenuItem tsmiModel;
        private System.Windows.Forms.ToolStripMenuItem tsmiDefaultModel;
        public System.Windows.Forms.TreeView trvModel;
        private System.Windows.Forms.ContextMenuStrip ctmTreeViewMenu;
        private System.Windows.Forms.ToolStripMenuItem 添加文书模板toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiRename;
        private System.Windows.Forms.ToolStripMenuItem 删除文书模版ToolStripMenuItem;
        private System.Windows.Forms.ImageList imgListBook;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDetaiInfo;
        private System.Windows.Forms.TextBox txtDocName;
        private System.Windows.Forms.Button btnNewPage;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboTextKind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cboSicknessKind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoHospital;
        private System.Windows.Forms.RadioButton rdoSection;
        private System.Windows.Forms.RadioButton rdoPersonal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolStripMenuItem 无效ToolStripMenuItem;
    }
}
