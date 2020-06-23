namespace Base_Function.BASE_DATA
{
    partial class frmOldsPatientInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dgvPatientInfo = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PATIENT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GENDER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BIRTHDAY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MARRIAGE_STATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEDICARE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOME_ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOMEPOSTAL_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HOME_PHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OFFICE_ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OFFICE_PHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RELATION_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RELATION_ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RELATION_PHONE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IN_TIME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSure = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtIDCARD = new System.Windows.Forms.TextBox();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientInfo)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dgvPatientInfo);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 62);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(730, 365);
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
            this.groupPanel1.Text = "已有基本信息列表";
            // 
            // dgvPatientInfo
            // 
            this.dgvPatientInfo.AllowUserToAddRows = false;
            this.dgvPatientInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatientInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatientInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PATIENT_NAME,
            this.AGE,
            this.GENDER_CODE,
            this.BIRTHDAY,
            this.MARRIAGE_STATE,
            this.PID,
            this.MEDICARE_NO,
            this.HOME_ADDRESS,
            this.HOMEPOSTAL_CODE,
            this.HOME_PHONE,
            this.OFFICE_ADDRESS,
            this.OFFICE_PHONE,
            this.RELATION_NAME,
            this.RELATION_ADDRESS,
            this.RELATION_PHONE,
            this.IN_TIME});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatientInfo.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPatientInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatientInfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPatientInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvPatientInfo.Name = "dgvPatientInfo";
            this.dgvPatientInfo.RowTemplate.Height = 23;
            this.dgvPatientInfo.Size = new System.Drawing.Size(724, 341);
            this.dgvPatientInfo.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // PATIENT_NAME
            // 
            this.PATIENT_NAME.HeaderText = "姓名";
            this.PATIENT_NAME.Name = "PATIENT_NAME";
            // 
            // AGE
            // 
            this.AGE.HeaderText = "年龄";
            this.AGE.Name = "AGE";
            // 
            // GENDER_CODE
            // 
            this.GENDER_CODE.HeaderText = "性别";
            this.GENDER_CODE.Name = "GENDER_CODE";
            // 
            // BIRTHDAY
            // 
            this.BIRTHDAY.HeaderText = "生日";
            this.BIRTHDAY.Name = "BIRTHDAY";
            // 
            // MARRIAGE_STATE
            // 
            this.MARRIAGE_STATE.HeaderText = "婚姻";
            this.MARRIAGE_STATE.Name = "MARRIAGE_STATE";
            // 
            // PID
            // 
            this.PID.HeaderText = "住院号";
            this.PID.Name = "PID";
            // 
            // MEDICARE_NO
            // 
            this.MEDICARE_NO.HeaderText = "身份证";
            this.MEDICARE_NO.Name = "MEDICARE_NO";
            // 
            // HOME_ADDRESS
            // 
            this.HOME_ADDRESS.HeaderText = "家庭地址";
            this.HOME_ADDRESS.Name = "HOME_ADDRESS";
            // 
            // HOMEPOSTAL_CODE
            // 
            this.HOMEPOSTAL_CODE.HeaderText = "邮编号码";
            this.HOMEPOSTAL_CODE.Name = "HOMEPOSTAL_CODE";
            // 
            // HOME_PHONE
            // 
            this.HOME_PHONE.HeaderText = "联系电话";
            this.HOME_PHONE.Name = "HOME_PHONE";
            // 
            // OFFICE_ADDRESS
            // 
            this.OFFICE_ADDRESS.HeaderText = "单位地址";
            this.OFFICE_ADDRESS.Name = "OFFICE_ADDRESS";
            // 
            // OFFICE_PHONE
            // 
            this.OFFICE_PHONE.HeaderText = "单位电话";
            this.OFFICE_PHONE.Name = "OFFICE_PHONE";
            // 
            // RELATION_NAME
            // 
            this.RELATION_NAME.HeaderText = "联系人";
            this.RELATION_NAME.Name = "RELATION_NAME";
            // 
            // RELATION_ADDRESS
            // 
            this.RELATION_ADDRESS.HeaderText = "联系人地址";
            this.RELATION_ADDRESS.Name = "RELATION_ADDRESS";
            // 
            // RELATION_PHONE
            // 
            this.RELATION_PHONE.HeaderText = "联系人电话";
            this.RELATION_PHONE.Name = "RELATION_PHONE";
            // 
            // IN_TIME
            // 
            this.IN_TIME.HeaderText = "入院时间";
            this.IN_TIME.Name = "IN_TIME";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSure);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 427);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 47);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(563, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSure
            // 
            this.btnSure.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSure.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSure.Location = new System.Drawing.Point(471, 10);
            this.btnSure.Name = "btnSure";
            this.btnSure.Size = new System.Drawing.Size(86, 26);
            this.btnSure.TabIndex = 0;
            this.btnSure.Text = "确定";
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btnSearch);
            this.groupPanel2.Controls.Add(this.txtIDCARD);
            this.groupPanel2.Controls.Add(this.txtPid);
            this.groupPanel2.Controls.Add(this.label2);
            this.groupPanel2.Controls.Add(this.label1);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(730, 62);
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
            this.groupPanel2.TabIndex = 2;
            this.groupPanel2.Text = "查询设置";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(508, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 27);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtIDCARD
            // 
            this.txtIDCARD.Location = new System.Drawing.Point(292, 7);
            this.txtIDCARD.Name = "txtIDCARD";
            this.txtIDCARD.Size = new System.Drawing.Size(182, 21);
            this.txtIDCARD.TabIndex = 3;
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(74, 8);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(137, 21);
            this.txtPid.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(225, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "身份证号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "住院号：";
            // 
            // frmOldsPatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 474);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupPanel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOldsPatientInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "本人基本信息表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOldsPatientInfo_Load);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatientInfo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.groupPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPatientInfo;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSure;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PATIENT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGE;
        private System.Windows.Forms.DataGridViewTextBoxColumn GENDER_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn BIRTHDAY;
        private System.Windows.Forms.DataGridViewTextBoxColumn MARRIAGE_STATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn MEDICARE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOME_ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOMEPOSTAL_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn HOME_PHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFFICE_ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFFICE_PHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn RELATION_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn RELATION_ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn RELATION_PHONE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IN_TIME;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.TextBox txtIDCARD;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}