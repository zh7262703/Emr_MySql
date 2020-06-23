namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    partial class frmMsgSendDetailsUpdate
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cbReceiver = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.cbNewsType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.txtTitle = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtContent = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtEditor = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.btnSend = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.txtPerson = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSendPerson = new System.Windows.Forms.DataGridView();
            this.user_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtReceiveName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnSection_select = new DevComponents.DotNetBar.ButtonX();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new DevComponents.DotNetBar.ButtonX();
            this.cbSection = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSendPerson)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(40, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "接收人：";
            // 
            // cbReceiver
            // 
            this.cbReceiver.DisplayMember = "Text";
            this.cbReceiver.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbReceiver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReceiver.FormattingEnabled = true;
            this.cbReceiver.ItemHeight = 15;
            this.cbReceiver.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem10});
            this.cbReceiver.Location = new System.Drawing.Point(89, 12);
            this.cbReceiver.Name = "cbReceiver";
            this.cbReceiver.Size = new System.Drawing.Size(127, 21);
            this.cbReceiver.TabIndex = 1;
            this.cbReceiver.SelectedIndexChanged += new System.EventHandler(this.cbReceiver_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "全院";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "全体医生";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "全体护士";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "科室";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "病区";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "个人";
            // 
            // cbNewsType
            // 
            this.cbNewsType.DisplayMember = "Text";
            this.cbNewsType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbNewsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNewsType.FormattingEnabled = true;
            this.cbNewsType.ItemHeight = 15;
            this.cbNewsType.Items.AddRange(new object[] {
            this.comboItem7,
            this.comboItem8,
            this.comboItem9,
            this.comboItem11});
            this.cbNewsType.Location = new System.Drawing.Point(89, 79);
            this.cbNewsType.Name = "cbNewsType";
            this.cbNewsType.Size = new System.Drawing.Size(127, 21);
            this.cbNewsType.TabIndex = 3;
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "普通消息";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "重要消息";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "紧急消息";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(28, 79);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "消息类型：";
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(51, 147);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "标题：";
            // 
            // txtTitle
            // 
            // 
            // 
            // 
            this.txtTitle.Border.Class = "TextBoxBorder";
            this.txtTitle.Location = new System.Drawing.Point(89, 147);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(728, 21);
            this.txtTitle.TabIndex = 5;
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(51, 185);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "内容：";
            // 
            // txtContent
            // 
            // 
            // 
            // 
            this.txtContent.Border.Class = "TextBoxBorder";
            this.txtContent.Location = new System.Drawing.Point(89, 185);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(728, 212);
            this.txtContent.TabIndex = 7;
            // 
            // labelX5
            // 
            this.labelX5.Location = new System.Drawing.Point(51, 428);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "落款：";
            // 
            // labelX6
            // 
            this.labelX6.Location = new System.Drawing.Point(541, 425);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 10;
            this.labelX6.Text = "编辑者：";
            // 
            // txtEditor
            // 
            // 
            // 
            // 
            this.txtEditor.Border.Class = "TextBoxBorder";
            this.txtEditor.Enabled = false;
            this.txtEditor.Location = new System.Drawing.Point(594, 425);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.Size = new System.Drawing.Size(123, 21);
            this.txtEditor.TabIndex = 11;
            // 
            // labelX7
            // 
            this.labelX7.Location = new System.Drawing.Point(28, 457);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 12;
            this.labelX7.Text = "发送时间：";
            // 
            // dtTime
            // 
            this.dtTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTime.Location = new System.Drawing.Point(89, 456);
            this.dtTime.Name = "dtTime";
            this.dtTime.Size = new System.Drawing.Size(138, 21);
            this.dtTime.TabIndex = 13;
            // 
            // labelX8
            // 
            this.labelX8.Location = new System.Drawing.Point(481, 457);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(119, 23);
            this.labelX8.TabIndex = 14;
            this.labelX8.Text = "是否需要发送收条：";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(682, 459);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(35, 16);
            this.radioButton1.TabIndex = 15;
            this.radioButton1.Text = "是";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(594, 459);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(35, 16);
            this.radioButton2.TabIndex = 16;
            this.radioButton2.Text = "否";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(456, 512);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "清空";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSend
            // 
            this.btnSend.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSend.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSend.Location = new System.Drawing.Point(325, 512);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 18;
            this.btnSend.Text = "发布";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(195, 512);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtPerson
            // 
            // 
            // 
            // 
            this.txtPerson.Border.Class = "TextBoxBorder";
            this.txtPerson.Location = new System.Drawing.Point(320, 12);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(110, 21);
            this.txtPerson.TabIndex = 21;
            this.txtPerson.Visible = false;
            this.txtPerson.Enter += new System.EventHandler(this.txtPerson_Enter);
            this.txtPerson.TextChanged += new System.EventHandler(this.txtPerson_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSendPerson);
            this.panel1.Location = new System.Drawing.Point(320, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(110, 128);
            this.panel1.TabIndex = 23;
            this.panel1.Visible = false;
            // 
            // dgvSendPerson
            // 
            this.dgvSendPerson.BackgroundColor = System.Drawing.Color.White;
            this.dgvSendPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSendPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.user_id,
            this.user_name});
            this.dgvSendPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSendPerson.Location = new System.Drawing.Point(0, 0);
            this.dgvSendPerson.Name = "dgvSendPerson";
            this.dgvSendPerson.ReadOnly = true;
            this.dgvSendPerson.RowHeadersVisible = false;
            this.dgvSendPerson.RowTemplate.Height = 23;
            this.dgvSendPerson.Size = new System.Drawing.Size(110, 128);
            this.dgvSendPerson.TabIndex = 22;
            this.dgvSendPerson.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvSendPerson_KeyUp);
            this.dgvSendPerson.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSendPerson_CellContentClick);
            // 
            // user_id
            // 
            this.user_id.HeaderText = "用户id";
            this.user_id.Name = "user_id";
            this.user_id.ReadOnly = true;
            this.user_id.Visible = false;
            // 
            // user_name
            // 
            this.user_name.HeaderText = "用户名称";
            this.user_name.Name = "user_name";
            this.user_name.ReadOnly = true;
            // 
            // txtReceiveName
            // 
            // 
            // 
            // 
            this.txtReceiveName.Border.Class = "TextBoxBorder";
            this.txtReceiveName.Enabled = false;
            this.txtReceiveName.Location = new System.Drawing.Point(436, 12);
            this.txtReceiveName.Multiline = true;
            this.txtReceiveName.Name = "txtReceiveName";
            this.txtReceiveName.Size = new System.Drawing.Size(381, 129);
            this.txtReceiveName.TabIndex = 24;
            this.txtReceiveName.Visible = false;
            // 
            // btnSection_select
            // 
            this.btnSection_select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSection_select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSection_select.Location = new System.Drawing.Point(222, 12);
            this.btnSection_select.Name = "btnSection_select";
            this.btnSection_select.Size = new System.Drawing.Size(92, 21);
            this.btnSection_select.TabIndex = 26;
            this.btnSection_select.Text = "选择科室/病区";
            this.btnSection_select.Visible = false;
            this.btnSection_select.Click += new System.EventHandler(this.btnSection_select_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvUser);
            this.panel2.Location = new System.Drawing.Point(436, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 129);
            this.panel2.TabIndex = 27;
            this.panel2.Visible = false;
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvUser.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(0, 0);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowTemplate.Height = 23;
            this.dgvUser.Size = new System.Drawing.Size(381, 129);
            this.dgvUser.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "用户id";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "用户名称";
            this.Column2.Name = "Column2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem,
            this.清空ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.清空ToolStripMenuItem.Text = "清空";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClose.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClose.Location = new System.Drawing.Point(578, 512);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbSection
            // 
            this.cbSection.Location = new System.Drawing.Point(89, 425);
            this.cbSection.Name = "cbSection";
            this.cbSection.Size = new System.Drawing.Size(138, 23);
            this.cbSection.TabIndex = 29;
            // 
            // frmMsgSendDetailsUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 542);
            this.Controls.Add(this.cbSection);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnSection_select);
            this.Controls.Add(this.txtReceiveName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPerson);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.labelX8);
            this.Controls.Add(this.dtTime);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.txtEditor);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.cbNewsType);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cbReceiver);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "frmMsgSendDetailsUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "消息修改";
            this.Load += new System.EventHandler(this.frmMsgSendDetails_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSendPerson)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbReceiver;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbNewsType;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTitle;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtContent;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEditor;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.DateTimePicker dtTime;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private DevComponents.DotNetBar.ButtonX btnSend;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPerson;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtReceiveName;
        private DevComponents.DotNetBar.ButtonX btnSection_select;
        private System.Windows.Forms.DataGridView dgvSendPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn user_name;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private DevComponents.DotNetBar.ButtonX btnClose;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.DotNetBar.Controls.CheckBoxX cbSection;
    }
}