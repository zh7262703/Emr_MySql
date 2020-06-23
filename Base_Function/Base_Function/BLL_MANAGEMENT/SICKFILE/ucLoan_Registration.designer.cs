namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucLoan_Registration
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chkToHospital = new System.Windows.Forms.CheckBox();
            this.chkState = new System.Windows.Forms.CheckBox();
            this.chkHospital = new System.Windows.Forms.CheckBox();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtICD9 = new System.Windows.Forms.TextBox();
            this.txtICD10 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpHospitalEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblTohospital = new System.Windows.Forms.Label();
            this.dtpHospitalStartTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblHospital = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btnSelect = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.flgView = new Bifrost.ucC1FlexGrid();
            this.groupPanel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkToHospital
            // 
            this.chkToHospital.AutoSize = true;
            this.chkToHospital.Location = new System.Drawing.Point(662, 26);
            this.chkToHospital.Name = "chkToHospital";
            this.chkToHospital.Size = new System.Drawing.Size(15, 14);
            this.chkToHospital.TabIndex = 30;
            this.chkToHospital.UseVisualStyleBackColor = true;
            this.chkToHospital.CheckedChanged += new System.EventHandler(this.chkToHospital_CheckedChanged);
            // 
            // chkState
            // 
            this.chkState.AutoSize = true;
            this.chkState.Location = new System.Drawing.Point(374, 54);
            this.chkState.Name = "chkState";
            this.chkState.Size = new System.Drawing.Size(15, 14);
            this.chkState.TabIndex = 29;
            this.chkState.UseVisualStyleBackColor = true;
            this.chkState.CheckedChanged += new System.EventHandler(this.chkState_CheckedChanged);
            // 
            // chkHospital
            // 
            this.chkHospital.AutoSize = true;
            this.chkHospital.Location = new System.Drawing.Point(374, 26);
            this.chkHospital.Name = "chkHospital";
            this.chkHospital.Size = new System.Drawing.Size(15, 14);
            this.chkHospital.TabIndex = 28;
            this.chkHospital.UseVisualStyleBackColor = true;
            this.chkHospital.CheckedChanged += new System.EventHandler(this.chkHospital_CheckedChanged);
            // 
            // cboState
            // 
            this.cboState.FormattingEnabled = true;
            this.cboState.Location = new System.Drawing.Point(451, 51);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(112, 20);
            this.cboState.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(386, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "查询状态：";
            // 
            // txtICD9
            // 
            this.txtICD9.Location = new System.Drawing.Point(277, 51);
            this.txtICD9.Name = "txtICD9";
            this.txtICD9.Size = new System.Drawing.Size(81, 21);
            this.txtICD9.TabIndex = 25;
            // 
            // txtICD10
            // 
            this.txtICD10.Location = new System.Drawing.Point(95, 51);
            this.txtICD10.Name = "txtICD10";
            this.txtICD10.Size = new System.Drawing.Size(81, 21);
            this.txtICD10.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "疾病分类代码：";
            // 
            // dtpHospitalEndTime
            // 
            this.dtpHospitalEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpHospitalEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHospitalEndTime.Location = new System.Drawing.Point(841, 22);
            this.dtpHospitalEndTime.Name = "dtpHospitalEndTime";
            this.dtpHospitalEndTime.Size = new System.Drawing.Size(89, 21);
            this.dtpHospitalEndTime.TabIndex = 22;
            // 
            // lblTohospital
            // 
            this.lblTohospital.AutoSize = true;
            this.lblTohospital.Location = new System.Drawing.Point(827, 26);
            this.lblTohospital.Name = "lblTohospital";
            this.lblTohospital.Size = new System.Drawing.Size(17, 12);
            this.lblTohospital.TabIndex = 21;
            this.lblTohospital.Text = "－";
            // 
            // dtpHospitalStartTime
            // 
            this.dtpHospitalStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpHospitalStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHospitalStartTime.Location = new System.Drawing.Point(734, 22);
            this.dtpHospitalStartTime.Name = "dtpHospitalStartTime";
            this.dtpHospitalStartTime.Size = new System.Drawing.Size(89, 21);
            this.dtpHospitalStartTime.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(674, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "出院时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(558, 22);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(89, 21);
            this.dtpEndTime.TabIndex = 18;
            // 
            // lblHospital
            // 
            this.lblHospital.AutoSize = true;
            this.lblHospital.Location = new System.Drawing.Point(541, 27);
            this.lblHospital.Name = "lblHospital";
            this.lblHospital.Size = new System.Drawing.Size(17, 12);
            this.lblHospital.TabIndex = 17;
            this.lblHospital.Text = "－";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(277, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(79, 21);
            this.txtName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "患者姓名：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(95, 23);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(81, 21);
            this.txtCode.TabIndex = 14;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(451, 22);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(89, 21);
            this.dtpStartTime.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(386, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "入院时间：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "住院号：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(188, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 1;
            this.label12.Text = "手术分类代码：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnSelect);
            this.groupPanel1.Controls.Add(this.chkToHospital);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.chkState);
            this.groupPanel1.Controls.Add(this.label12);
            this.groupPanel1.Controls.Add(this.chkHospital);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.cboState);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.txtICD9);
            this.groupPanel1.Controls.Add(this.dtpStartTime);
            this.groupPanel1.Controls.Add(this.txtICD10);
            this.groupPanel1.Controls.Add(this.txtCode);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtName);
            this.groupPanel1.Controls.Add(this.dtpHospitalEndTime);
            this.groupPanel1.Controls.Add(this.lblHospital);
            this.groupPanel1.Controls.Add(this.lblTohospital);
            this.groupPanel1.Controls.Add(this.dtpEndTime);
            this.groupPanel1.Controls.Add(this.dtpHospitalStartTime);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(943, 113);
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
            this.groupPanel1.TabIndex = 8;
            this.groupPanel1.Text = "借阅登记查询";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(572, 49);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 31;
            this.btnSelect.Text = "查 询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgView);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 113);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(943, 530);
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
            this.groupPanel2.TabIndex = 9;
            this.groupPanel2.Text = "借阅登记显示列表";
            // 
            // flgView
            // 
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Size = new System.Drawing.Size(937, 506);
            this.flgView.TabIndex = 1;
            // 
            // ucLoan_Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucLoan_Registration";
            this.Size = new System.Drawing.Size(943, 643);
            this.Load += new System.EventHandler(this.ucLoan_Registration_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private Bifrost.ucC1FlexGrid flgView;
        private System.Windows.Forms.DateTimePicker dtpHospitalEndTime;
        private System.Windows.Forms.Label lblTohospital;
        private System.Windows.Forms.DateTimePicker dtpHospitalStartTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.Label lblHospital;
        private System.Windows.Forms.TextBox txtICD10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboState;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtICD9;
        private System.Windows.Forms.CheckBox chkToHospital;
        private System.Windows.Forms.CheckBox chkState;
        private System.Windows.Forms.CheckBox chkHospital;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnSelect;
    }
}
