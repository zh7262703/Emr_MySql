namespace Base_Function.BASE_DATA
{
    partial class ucTake_over_SEQ
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ucC1FlexGrid1 = new Bifrost.ucC1FlexGrid();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnLookup = new DevComponents.DotNetBar.ButtonX();
            this.chkName = new System.Windows.Forms.CheckBox();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.label1 = new System.Windows.Forms.Label();
            this.cboStart_condition = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cboEnd_condition = new System.Windows.Forms.ComboBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.groupPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupPanel3);
            this.splitContainer1.Size = new System.Drawing.Size(730, 410);
            this.splitContainer1.SplitterDistance = 273;
            this.splitContainer1.TabIndex = 7;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ucC1FlexGrid1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 57);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(730, 216);
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
            this.groupPanel2.TabIndex = 4;
            this.groupPanel2.Text = "班次信息列表";
            // 
            // ucC1FlexGrid1
            // 
            this.ucC1FlexGrid1.ContextMenuStrip = this.contextMenuStrip1;
            this.ucC1FlexGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucC1FlexGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucC1FlexGrid1.Name = "ucC1FlexGrid1";
            this.ucC1FlexGrid1.Size = new System.Drawing.Size(724, 192);
            this.ucC1FlexGrid1.TabIndex = 2;
            this.ucC1FlexGrid1.Click += new System.EventHandler(this.ucC1FlexGrid1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(95, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnLookup);
            this.groupPanel1.Controls.Add(this.chkName);
            this.groupPanel1.Controls.Add(this.txtBox);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(730, 57);
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
            this.groupPanel1.TabIndex = 3;
            this.groupPanel1.Text = "查询设置";
            // 
            // btnLookup
            // 
            this.btnLookup.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLookup.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLookup.Location = new System.Drawing.Point(281, 4);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(75, 23);
            this.btnLookup.TabIndex = 20;
            this.btnLookup.Text = "查找";
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // chkName
            // 
            this.chkName.AutoSize = true;
            this.chkName.BackColor = System.Drawing.Color.Transparent;
            this.chkName.Checked = true;
            this.chkName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkName.Location = new System.Drawing.Point(59, 11);
            this.chkName.Name = "chkName";
            this.chkName.Size = new System.Drawing.Size(84, 16);
            this.chkName.TabIndex = 4;
            this.chkName.Text = "按班次名称";
            this.chkName.UseVisualStyleBackColor = false;
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(147, 6);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(128, 21);
            this.txtBox.TabIndex = 6;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btnCancel);
            this.groupPanel3.Controls.Add(this.btnSave);
            this.groupPanel3.Controls.Add(this.btnDelete);
            this.groupPanel3.Controls.Add(this.btnUpdate);
            this.groupPanel3.Controls.Add(this.btnAdd);
            this.groupPanel3.Controls.Add(this.label1);
            this.groupPanel3.Controls.Add(this.cboStart_condition);
            this.groupPanel3.Controls.Add(this.label8);
            this.groupPanel3.Controls.Add(this.dtpEndTime);
            this.groupPanel3.Controls.Add(this.label13);
            this.groupPanel3.Controls.Add(this.dtpStartTime);
            this.groupPanel3.Controls.Add(this.label3);
            this.groupPanel3.Controls.Add(this.txtName);
            this.groupPanel3.Controls.Add(this.label19);
            this.groupPanel3.Controls.Add(this.cboEnd_condition);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(0, 0);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(730, 133);
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
            this.groupPanel3.TabIndex = 3;
            this.groupPanel3.Text = "班次信息编辑";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(494, 77);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 198;
            this.btnCancel.Text = "取消(&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(409, 77);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 197;
            this.btnSave.Text = "确定(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(324, 77);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 196;
            this.btnDelete.Text = "删除(&D)";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(240, 77);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 195;
            this.btnUpdate.Text = "修改(&M)";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(156, 77);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 194;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 119;
            this.label1.Text = "班次名称：";
            // 
            // cboStart_condition
            // 
            this.cboStart_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStart_condition.FormattingEnabled = true;
            this.cboStart_condition.Items.AddRange(new object[] {
            ">",
            ">="});
            this.cboStart_condition.Location = new System.Drawing.Point(643, 13);
            this.cboStart_condition.Name = "cboStart_condition";
            this.cboStart_condition.Size = new System.Drawing.Size(62, 20);
            this.cboStart_condition.TabIndex = 3;
            this.cboStart_condition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboStart_condition_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(294, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "起始时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = " HH:mm";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(92, 39);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(162, 21);
            this.dtpEndTime.TabIndex = 4;
            this.dtpEndTime.Value = new System.DateTime(2010, 4, 1, 15, 21, 0, 0);
            this.dtpEndTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpEndTime_KeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("宋体", 9F);
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(270, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 71;
            this.label13.Text = "结束汇总条件：";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = " HH:mm";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(365, 12);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(164, 21);
            this.dtpStartTime.TabIndex = 2;
            this.dtpStartTime.Value = new System.DateTime(2010, 4, 1, 15, 35, 0, 0);
            this.dtpStartTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpStartTime_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 9F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(21, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 77;
            this.label3.Text = "截止时间：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(92, 13);
            this.txtName.MaxLength = 20;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 21);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("宋体", 9F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(548, 16);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(89, 12);
            this.label19.TabIndex = 102;
            this.label19.Text = "起始汇总条件：";
            // 
            // cboEnd_condition
            // 
            this.cboEnd_condition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEnd_condition.FormattingEnabled = true;
            this.cboEnd_condition.Items.AddRange(new object[] {
            "<",
            "<="});
            this.cboEnd_condition.Location = new System.Drawing.Point(365, 40);
            this.cboEnd_condition.Name = "cboEnd_condition";
            this.cboEnd_condition.Size = new System.Drawing.Size(62, 20);
            this.cboEnd_condition.TabIndex = 5;
            this.cboEnd_condition.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboEnd_condition_KeyDown);
            // 
            // ucTake_over_SEQ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Name = "ucTake_over_SEQ";
            this.Size = new System.Drawing.Size(730, 410);
            this.Load += new System.EventHandler(this.frmTake_over_SEQ_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Bifrost.ucC1FlexGrid ucC1FlexGrid1;
        private System.Windows.Forms.TextBox txtBox;
        private System.Windows.Forms.CheckBox chkName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEnd_condition;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboStart_condition;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btnLookup;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
    }
}