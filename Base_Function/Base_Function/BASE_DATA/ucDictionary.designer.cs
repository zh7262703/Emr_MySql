namespace Base_Function.BASE_DATA
{
    partial class ucDictionary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucDictionary));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.trvDictionary = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.cmbTypes = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.radName = new System.Windows.Forms.RadioButton();
            this.radPY = new System.Windows.Forms.RadioButton();
            this.txtConditions = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnModify = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radNo = new System.Windows.Forms.RadioButton();
            this.radYes = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPinyin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(817, 629);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lblCount);
            this.groupBox1.Controls.Add(this.trvDictionary);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 629);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据字典";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.ForeColor = System.Drawing.Color.Red;
            this.lblCount.Location = new System.Drawing.Point(200, 0);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(0, 12);
            this.lblCount.TabIndex = 2;
            // 
            // trvDictionary
            // 
            this.trvDictionary.ContextMenuStrip = this.contextMenuStrip1;
            this.trvDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDictionary.HideSelection = false;
            this.trvDictionary.ImageIndex = 0;
            this.trvDictionary.ImageList = this.imageList1;
            this.trvDictionary.Location = new System.Drawing.Point(3, 104);
            this.trvDictionary.Name = "trvDictionary";
            this.trvDictionary.SelectedImageIndex = 0;
            this.trvDictionary.Size = new System.Drawing.Size(267, 522);
            this.trvDictionary.StateImageList = this.imageList1;
            this.trvDictionary.TabIndex = 0;
            this.trvDictionary.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDictionary_AfterSelect);
            this.trvDictionary.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trvDictionary_MouseDown);
            this.trvDictionary.Click += new System.EventHandler(this.trvDictionary_Click);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Files1.ico");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.cmbTypes);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.radName);
            this.panel1.Controls.Add(this.radPY);
            this.panel1.Controls.Add(this.txtConditions);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 87);
            this.panel1.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(195, 25);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(63, 23);
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "查询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // cmbTypes
            // 
            this.cmbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypes.FormattingEnabled = true;
            this.cmbTypes.Location = new System.Drawing.Point(49, 11);
            this.cmbTypes.Name = "cmbTypes";
            this.cmbTypes.Size = new System.Drawing.Size(140, 20);
            this.cmbTypes.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(9, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "类型：";
            // 
            // radName
            // 
            this.radName.AutoSize = true;
            this.radName.ForeColor = System.Drawing.Color.Black;
            this.radName.Location = new System.Drawing.Point(118, 65);
            this.radName.Name = "radName";
            this.radName.Size = new System.Drawing.Size(47, 16);
            this.radName.TabIndex = 3;
            this.radName.Text = "名称";
            this.radName.UseVisualStyleBackColor = true;
            // 
            // radPY
            // 
            this.radPY.AutoSize = true;
            this.radPY.Checked = true;
            this.radPY.ForeColor = System.Drawing.Color.Black;
            this.radPY.Location = new System.Drawing.Point(49, 66);
            this.radPY.Name = "radPY";
            this.radPY.Size = new System.Drawing.Size(47, 16);
            this.radPY.TabIndex = 3;
            this.radPY.TabStop = true;
            this.radPY.Text = "拼音";
            this.radPY.UseVisualStyleBackColor = true;
            // 
            // txtConditions
            // 
            this.txtConditions.Location = new System.Drawing.Point(49, 37);
            this.txtConditions.Name = "txtConditions";
            this.txtConditions.Size = new System.Drawing.Size(140, 21);
            this.txtConditions.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(9, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "条件：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.label9);
            this.groupPanel1.Controls.Add(this.btnCancel);
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.btnModify);
            this.groupPanel1.Controls.Add(this.btnAdd);
            this.groupPanel1.Controls.Add(this.panel2);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cmbType);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.txtCode);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.txtPinyin);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.txtName);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(540, 629);
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
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.Text = "编辑";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(235, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(239, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "* (新添加编号请采用数字从1开始往后递增)";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(260, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(179, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnModify
            // 
            this.btnModify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnModify.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnModify.Location = new System.Drawing.Point(98, 220);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 16;
            this.btnModify.Text = "修改(&M)";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(17, 220);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radNo);
            this.panel2.Controls.Add(this.radYes);
            this.panel2.Location = new System.Drawing.Point(74, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(155, 24);
            this.panel2.TabIndex = 16;
            // 
            // radNo
            // 
            this.radNo.AutoSize = true;
            this.radNo.Location = new System.Drawing.Point(93, 3);
            this.radNo.Name = "radNo";
            this.radNo.Size = new System.Drawing.Size(47, 16);
            this.radNo.TabIndex = 1;
            this.radNo.Text = "无效";
            this.radNo.UseVisualStyleBackColor = true;
            this.radNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radNo_KeyDown);
            // 
            // radYes
            // 
            this.radYes.AutoSize = true;
            this.radYes.Checked = true;
            this.radYes.Location = new System.Drawing.Point(4, 4);
            this.radYes.Name = "radYes";
            this.radYes.Size = new System.Drawing.Size(47, 16);
            this.radYes.TabIndex = 0;
            this.radYes.TabStop = true;
            this.radYes.Text = "有效";
            this.radYes.UseVisualStyleBackColor = true;
            this.radYes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.radYes_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "代码编号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "有效标志：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(15, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "拼  音：";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(74, 139);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(155, 20);
            this.cmbType.TabIndex = 14;
            this.cmbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbType_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(15, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "名  称：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(74, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(155, 21);
            this.txtCode.TabIndex = 4;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(15, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "类  型：";
            // 
            // txtPinyin
            // 
            this.txtPinyin.BackColor = System.Drawing.SystemColors.Window;
            this.txtPinyin.Location = new System.Drawing.Point(74, 66);
            this.txtPinyin.Name = "txtPinyin";
            this.txtPinyin.ReadOnly = true;
            this.txtPinyin.Size = new System.Drawing.Size(155, 21);
            this.txtPinyin.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(235, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "*";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(74, 34);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 21);
            this.txtName.TabIndex = 7;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // ucDictionary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucDictionary";
            this.Size = new System.Drawing.Size(817, 629);
            this.Load += new System.EventHandler(this.frmDictionary_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView trvDictionary;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtConditions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radName;
        private System.Windows.Forms.RadioButton radPY;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.ComboBox cmbTypes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radNo;
        private System.Windows.Forms.RadioButton radYes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPinyin;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnSelect;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnModify;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.Label label9;
    }
}

