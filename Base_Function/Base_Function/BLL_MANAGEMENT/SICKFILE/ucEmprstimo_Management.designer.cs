namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class ucEmprstimo_Management
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
            this.chkRange = new System.Windows.Forms.CheckBox();
            this.chkBorrowSection = new System.Windows.Forms.CheckBox();
            this.chkToHospitalTime = new System.Windows.Forms.CheckBox();
            this.chkBorrowTime = new System.Windows.Forms.CheckBox();
            this.chkHospitalTime = new System.Windows.Forms.CheckBox();
            this.cboBorrow_Section = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEndBorrow_Time = new System.Windows.Forms.DateTimePicker();
            this.lblBorrow = new System.Windows.Forms.Label();
            this.dtpStartBorrow_Time = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBorrow_People = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboInquiry_Range = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtICD9 = new System.Windows.Forms.TextBox();
            this.txtICD10 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEnd_Tohospital = new System.Windows.Forms.DateTimePicker();
            this.lblToHospital = new System.Windows.Forms.Label();
            this.dtpStart_Tohospital = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEnd_Admission = new System.Windows.Forms.DateTimePicker();
            this.lblAdmission = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.dtpStart_Admission = new System.Windows.Forms.DateTimePicker();
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
            // chkRange
            // 
            this.chkRange.AutoSize = true;
            this.chkRange.Location = new System.Drawing.Point(201, 70);
            this.chkRange.Name = "chkRange";
            this.chkRange.Size = new System.Drawing.Size(15, 14);
            this.chkRange.TabIndex = 40;
            this.chkRange.UseVisualStyleBackColor = true;
            this.chkRange.CheckedChanged += new System.EventHandler(this.chkRange_CheckedChanged);
            // 
            // chkBorrowSection
            // 
            this.chkBorrowSection.AutoSize = true;
            this.chkBorrowSection.Location = new System.Drawing.Point(659, 42);
            this.chkBorrowSection.Name = "chkBorrowSection";
            this.chkBorrowSection.Size = new System.Drawing.Size(15, 14);
            this.chkBorrowSection.TabIndex = 39;
            this.chkBorrowSection.UseVisualStyleBackColor = true;
            this.chkBorrowSection.CheckedChanged += new System.EventHandler(this.chkBorrowSection_CheckedChanged);
            // 
            // chkToHospitalTime
            // 
            this.chkToHospitalTime.AutoSize = true;
            this.chkToHospitalTime.Location = new System.Drawing.Point(659, 14);
            this.chkToHospitalTime.Name = "chkToHospitalTime";
            this.chkToHospitalTime.Size = new System.Drawing.Size(15, 14);
            this.chkToHospitalTime.TabIndex = 38;
            this.chkToHospitalTime.UseVisualStyleBackColor = true;
            this.chkToHospitalTime.CheckedChanged += new System.EventHandler(this.chkToHospitalTime_CheckedChanged);
            // 
            // chkBorrowTime
            // 
            this.chkBorrowTime.AutoSize = true;
            this.chkBorrowTime.Location = new System.Drawing.Point(374, 40);
            this.chkBorrowTime.Name = "chkBorrowTime";
            this.chkBorrowTime.Size = new System.Drawing.Size(15, 14);
            this.chkBorrowTime.TabIndex = 37;
            this.chkBorrowTime.UseVisualStyleBackColor = true;
            this.chkBorrowTime.CheckedChanged += new System.EventHandler(this.chkBorrowTime_CheckedChanged);
            // 
            // chkHospitalTime
            // 
            this.chkHospitalTime.AutoSize = true;
            this.chkHospitalTime.Location = new System.Drawing.Point(374, 14);
            this.chkHospitalTime.Name = "chkHospitalTime";
            this.chkHospitalTime.Size = new System.Drawing.Size(15, 14);
            this.chkHospitalTime.TabIndex = 36;
            this.chkHospitalTime.UseVisualStyleBackColor = true;
            this.chkHospitalTime.CheckedChanged += new System.EventHandler(this.chkHospitalTime_CheckedChanged);
            // 
            // cboBorrow_Section
            // 
            this.cboBorrow_Section.FormattingEnabled = true;
            this.cboBorrow_Section.Location = new System.Drawing.Point(736, 40);
            this.cboBorrow_Section.Name = "cboBorrow_Section";
            this.cboBorrow_Section.Size = new System.Drawing.Size(137, 20);
            this.cboBorrow_Section.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(671, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "借阅科室：";
            // 
            // dtpEndBorrow_Time
            // 
            this.dtpEndBorrow_Time.CustomFormat = "yyyy-MM-dd";
            this.dtpEndBorrow_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndBorrow_Time.Location = new System.Drawing.Point(556, 38);
            this.dtpEndBorrow_Time.Name = "dtpEndBorrow_Time";
            this.dtpEndBorrow_Time.Size = new System.Drawing.Size(89, 21);
            this.dtpEndBorrow_Time.TabIndex = 33;
            // 
            // lblBorrow
            // 
            this.lblBorrow.AutoSize = true;
            this.lblBorrow.Location = new System.Drawing.Point(539, 42);
            this.lblBorrow.Name = "lblBorrow";
            this.lblBorrow.Size = new System.Drawing.Size(17, 12);
            this.lblBorrow.TabIndex = 32;
            this.lblBorrow.Text = "－";
            // 
            // dtpStartBorrow_Time
            // 
            this.dtpStartBorrow_Time.CustomFormat = "yyyy-MM-dd";
            this.dtpStartBorrow_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartBorrow_Time.Location = new System.Drawing.Point(451, 38);
            this.dtpStartBorrow_Time.Name = "dtpStartBorrow_Time";
            this.dtpStartBorrow_Time.Size = new System.Drawing.Size(89, 21);
            this.dtpStartBorrow_Time.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(386, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "借阅时间：";
            // 
            // txtBorrow_People
            // 
            this.txtBorrow_People.Location = new System.Drawing.Point(97, 67);
            this.txtBorrow_People.Name = "txtBorrow_People";
            this.txtBorrow_People.Size = new System.Drawing.Size(81, 21);
            this.txtBorrow_People.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "借阅人：";
            // 
            // cboInquiry_Range
            // 
            this.cboInquiry_Range.FormattingEnabled = true;
            this.cboInquiry_Range.Location = new System.Drawing.Point(279, 67);
            this.cboInquiry_Range.Name = "cboInquiry_Range";
            this.cboInquiry_Range.Size = new System.Drawing.Size(81, 20);
            this.cboInquiry_Range.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "查询范围：";
            // 
            // txtICD9
            // 
            this.txtICD9.Location = new System.Drawing.Point(279, 39);
            this.txtICD9.Name = "txtICD9";
            this.txtICD9.Size = new System.Drawing.Size(81, 21);
            this.txtICD9.TabIndex = 25;
            // 
            // txtICD10
            // 
            this.txtICD10.Location = new System.Drawing.Point(97, 39);
            this.txtICD10.Name = "txtICD10";
            this.txtICD10.Size = new System.Drawing.Size(81, 21);
            this.txtICD10.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "疾病分类代码：";
            // 
            // dtpEnd_Tohospital
            // 
            this.dtpEnd_Tohospital.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd_Tohospital.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd_Tohospital.Location = new System.Drawing.Point(845, 9);
            this.dtpEnd_Tohospital.Name = "dtpEnd_Tohospital";
            this.dtpEnd_Tohospital.Size = new System.Drawing.Size(89, 21);
            this.dtpEnd_Tohospital.TabIndex = 22;
            // 
            // lblToHospital
            // 
            this.lblToHospital.AutoSize = true;
            this.lblToHospital.Location = new System.Drawing.Point(828, 15);
            this.lblToHospital.Name = "lblToHospital";
            this.lblToHospital.Size = new System.Drawing.Size(17, 12);
            this.lblToHospital.TabIndex = 21;
            this.lblToHospital.Text = "－";
            // 
            // dtpStart_Tohospital
            // 
            this.dtpStart_Tohospital.CustomFormat = "yyyy-MM-dd";
            this.dtpStart_Tohospital.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Tohospital.Location = new System.Drawing.Point(736, 10);
            this.dtpStart_Tohospital.Name = "dtpStart_Tohospital";
            this.dtpStart_Tohospital.Size = new System.Drawing.Size(89, 21);
            this.dtpStart_Tohospital.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(671, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "出院时间：";
            // 
            // dtpEnd_Admission
            // 
            this.dtpEnd_Admission.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd_Admission.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd_Admission.Location = new System.Drawing.Point(556, 10);
            this.dtpEnd_Admission.Name = "dtpEnd_Admission";
            this.dtpEnd_Admission.Size = new System.Drawing.Size(89, 21);
            this.dtpEnd_Admission.TabIndex = 18;
            // 
            // lblAdmission
            // 
            this.lblAdmission.AutoSize = true;
            this.lblAdmission.Location = new System.Drawing.Point(539, 15);
            this.lblAdmission.Name = "lblAdmission";
            this.lblAdmission.Size = new System.Drawing.Size(17, 12);
            this.lblAdmission.TabIndex = 17;
            this.lblAdmission.Text = "－";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(279, 11);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(81, 21);
            this.txtName.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "患者姓名：";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(97, 11);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(81, 21);
            this.txtNumber.TabIndex = 14;
            // 
            // dtpStart_Admission
            // 
            this.dtpStart_Admission.CustomFormat = "yyyy-MM-dd";
            this.dtpStart_Admission.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart_Admission.Location = new System.Drawing.Point(451, 10);
            this.dtpStart_Admission.Name = "dtpStart_Admission";
            this.dtpStart_Admission.Size = new System.Drawing.Size(89, 21);
            this.dtpStart_Admission.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(386, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "入院时间：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "住院号：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(189, 41);
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
            this.groupPanel1.Controls.Add(this.chkRange);
            this.groupPanel1.Controls.Add(this.label9);
            this.groupPanel1.Controls.Add(this.chkBorrowSection);
            this.groupPanel1.Controls.Add(this.label12);
            this.groupPanel1.Controls.Add(this.chkToHospitalTime);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Controls.Add(this.chkBorrowTime);
            this.groupPanel1.Controls.Add(this.chkHospitalTime);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.cboBorrow_Section);
            this.groupPanel1.Controls.Add(this.dtpStart_Admission);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.txtNumber);
            this.groupPanel1.Controls.Add(this.dtpEndBorrow_Time);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.lblBorrow);
            this.groupPanel1.Controls.Add(this.txtName);
            this.groupPanel1.Controls.Add(this.dtpStartBorrow_Time);
            this.groupPanel1.Controls.Add(this.lblAdmission);
            this.groupPanel1.Controls.Add(this.dtpEnd_Admission);
            this.groupPanel1.Controls.Add(this.txtBorrow_People);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.dtpStart_Tohospital);
            this.groupPanel1.Controls.Add(this.cboInquiry_Range);
            this.groupPanel1.Controls.Add(this.lblToHospital);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.dtpEnd_Tohospital);
            this.groupPanel1.Controls.Add(this.txtICD9);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtICD10);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(1123, 118);
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
            this.groupPanel1.TabIndex = 9;
            this.groupPanel1.Text = "借阅管理查询";
            // 
            // btnSelect
            // 
            this.btnSelect.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSelect.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSelect.Location = new System.Drawing.Point(376, 65);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 41;
            this.btnSelect.Text = "查 询";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.flgView);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 118);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(1123, 600);
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
            this.groupPanel2.TabIndex = 10;
            this.groupPanel2.Text = "借阅管理显示列表";
            // 
            // flgView
            // 
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Size = new System.Drawing.Size(1117, 576);
            this.flgView.TabIndex = 1;
            // 
            // ucEmprstimo_Management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Name = "ucEmprstimo_Management";
            this.Size = new System.Drawing.Size(1123, 718);
            this.Load += new System.EventHandler(this.ucEmprstimo_Management_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboInquiry_Range;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtICD9;
        private System.Windows.Forms.TextBox txtICD10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEnd_Tohospital;
        private System.Windows.Forms.Label lblToHospital;
        private System.Windows.Forms.DateTimePicker dtpStart_Tohospital;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEnd_Admission;
        private System.Windows.Forms.Label lblAdmission;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.DateTimePicker dtpStart_Admission;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboBorrow_Section;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpEndBorrow_Time;
        private System.Windows.Forms.Label lblBorrow;
        private System.Windows.Forms.DateTimePicker dtpStartBorrow_Time;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBorrow_People;
        private System.Windows.Forms.Label label7;
        private Bifrost.ucC1FlexGrid flgView;
        private System.Windows.Forms.CheckBox chkBorrowTime;
        private System.Windows.Forms.CheckBox chkHospitalTime;
        private System.Windows.Forms.CheckBox chkToHospitalTime;
        private System.Windows.Forms.CheckBox chkBorrowSection;
        private System.Windows.Forms.CheckBox chkRange;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btnSelect;
    }
}
