namespace Bifrost.SYSTEMSET
{
    partial class frmMsg
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnDelete = new DevComponents.DotNetBar.ButtonX();
            this.chkIsEnable = new System.Windows.Forms.CheckBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lblGenUrl = new System.Windows.Forms.Label();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.groupPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.cboSearchType);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.btnSearch);
            this.groupPanel1.Controls.Add(this.txtSearchName);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(717, 67);
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
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "查询设置";
            // 
            // cboSearchType
            // 
            this.cboSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Items.AddRange(new object[] {
            "所有",
            "医生",
            "护士"});
            this.cboSearchType.Location = new System.Drawing.Point(301, 7);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(123, 20);
            this.cboSearchType.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(242, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "消息类型";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(437, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(104, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(87, 7);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(133, 21);
            this.txtSearchName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "消息名称";
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dataGridViewX1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 67);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(717, 251);
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
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "查询结果";
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewX1.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.RowTemplate.Height = 23;
            this.dataGridViewX1.Size = new System.Drawing.Size(711, 227);
            this.dataGridViewX1.TabIndex = 0;
            this.dataGridViewX1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridViewX1_MouseClick);
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.lblGenUrl);
            this.groupPanel3.Controls.Add(this.txtUrl);
            this.groupPanel3.Controls.Add(this.label6);
            this.groupPanel3.Controls.Add(this.btnDelete);
            this.groupPanel3.Controls.Add(this.chkIsEnable);
            this.groupPanel3.Controls.Add(this.btnCancel);
            this.groupPanel3.Controls.Add(this.btnSure);
            this.groupPanel3.Controls.Add(this.btnUpdate);
            this.groupPanel3.Controls.Add(this.btnAdd);
            this.groupPanel3.Controls.Add(this.txtContent);
            this.groupPanel3.Controls.Add(this.label4);
            this.groupPanel3.Controls.Add(this.cboType);
            this.groupPanel3.Controls.Add(this.label3);
            this.groupPanel3.Controls.Add(this.txtName);
            this.groupPanel3.Controls.Add(this.label2);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel3.Location = new System.Drawing.Point(0, 318);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(717, 185);
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
            this.groupPanel3.TabIndex = 2;
            this.groupPanel3.Text = "消息编辑";
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDelete.Location = new System.Drawing.Point(274, 130);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 22);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkIsEnable
            // 
            this.chkIsEnable.AutoSize = true;
            this.chkIsEnable.BackColor = System.Drawing.Color.Transparent;
            this.chkIsEnable.Location = new System.Drawing.Point(446, 34);
            this.chkIsEnable.Name = "chkIsEnable";
            this.chkIsEnable.Size = new System.Drawing.Size(48, 16);
            this.chkIsEnable.TabIndex = 11;
            this.chkIsEnable.Text = "有效";
            this.chkIsEnable.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(456, 130);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 22);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(365, 130);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(85, 22);
            this.btnSure.TabIndex = 9;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(183, 130);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 22);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Location = new System.Drawing.Point(92, 130);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 22);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(78, 33);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(346, 57);
            this.txtContent.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(17, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "消息内容;";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "所有",
            "医生",
            "护士"});
            this.cboType.Location = new System.Drawing.Point(302, 2);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(123, 20);
            this.cboType.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(243, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "消息类型";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(78, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(133, 21);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(13, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "消息名称:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(17, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "信息地址:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(78, 102);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(486, 21);
            this.txtUrl.TabIndex = 14;
            // 
            // lblGenUrl
            // 
            this.lblGenUrl.AutoSize = true;
            this.lblGenUrl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGenUrl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblGenUrl.ForeColor = System.Drawing.Color.Blue;
            this.lblGenUrl.Location = new System.Drawing.Point(570, 105);
            this.lblGenUrl.Name = "lblGenUrl";
            this.lblGenUrl.Size = new System.Drawing.Size(77, 12);
            this.lblGenUrl.TabIndex = 15;
            this.lblGenUrl.Text = "自动生成路径";
            this.lblGenUrl.Click += new System.EventHandler(this.lblGenUrl_Click);
            // 
            // frmMsg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 503);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel3);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMsg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简易消息提醒设置";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMsg_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsEnable;
        private DevComponents.DotNetBar.ButtonX btnDelete;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblGenUrl;
    }
}