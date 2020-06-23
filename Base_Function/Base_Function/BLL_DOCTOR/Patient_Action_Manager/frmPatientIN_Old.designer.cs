namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    partial class frmPatientIN_Old
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboAgeunit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPiyin = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.dtpDatetime = new System.Windows.Forms.DateTimePicker();
            this.label24 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbxDoctor = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.dtpInAreaTime = new System.Windows.Forms.DateTimePicker();
            this.cbxBed_Id = new System.Windows.Forms.ComboBox();
            this.lblInAreaTime = new System.Windows.Forms.Label();
            this.lblBed = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOk = new DevComponents.DotNetBar.ButtonX();
            this.label15 = new System.Windows.Forms.Label();
            this.cboCusection = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboCusick = new System.Windows.Forms.ComboBox();
            this.lblAgeCheck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 182;
            this.label1.Text = "病人住院号：";
            // 
            // cboAgeunit
            // 
            this.cboAgeunit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAgeunit.FormattingEnabled = true;
            this.cboAgeunit.Items.AddRange(new object[] {
            "岁",
            "不满一岁"});
            this.cboAgeunit.Location = new System.Drawing.Point(402, 76);
            this.cboAgeunit.Name = "cboAgeunit";
            this.cboAgeunit.Size = new System.Drawing.Size(59, 20);
            this.cboAgeunit.TabIndex = 171;
            this.cboAgeunit.SelectedIndexChanged += new System.EventHandler(this.cboAgeunit_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 9F);
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(284, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 175;
            this.label8.Text = "姓名：";
            // 
            // txtPiyin
            // 
            this.txtPiyin.Location = new System.Drawing.Point(92, 50);
            this.txtPiyin.Name = "txtPiyin";
            this.txtPiyin.ReadOnly = true;
            this.txtPiyin.Size = new System.Drawing.Size(130, 21);
            this.txtPiyin.TabIndex = 184;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(334, 21);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(127, 21);
            this.txtName.TabIndex = 167;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(334, 76);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(64, 21);
            this.txtAge.TabIndex = 170;
            this.txtAge.TextChanged += new System.EventHandler(this.txtAge_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 9F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(46, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 176;
            this.label7.Text = "性别：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(285, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 183;
            this.label2.Text = "年龄：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 9F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(260, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 177;
            this.label6.Text = "出生年月：";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(93, 20);
            this.txtNumber.MaxLength = 20;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(131, 21);
            this.txtNumber.TabIndex = 166;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CustomFormat = "yyyy-MM-dd";
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(334, 49);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.Size = new System.Drawing.Size(82, 21);
            this.dtpBirthday.TabIndex = 168;
            this.dtpBirthday.ValueChanged += new System.EventHandler(this.dtpBirthday_ValueChanged);
            // 
            // cboGender
            // 
            this.cboGender.AutoCompleteCustomSource.AddRange(new string[] {
            "男",
            "女"});
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "男",
            "女"});
            this.cboGender.Location = new System.Drawing.Point(93, 76);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(62, 20);
            this.cboGender.TabIndex = 169;
            // 
            // dtpDatetime
            // 
            this.dtpDatetime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatetime.Location = new System.Drawing.Point(92, 130);
            this.dtpDatetime.Name = "dtpDatetime";
            this.dtpDatetime.Size = new System.Drawing.Size(120, 21);
            this.dtpDatetime.TabIndex = 174;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("宋体", 9F);
            this.label24.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label24.Location = new System.Drawing.Point(44, 53);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 180;
            this.label24.Text = "拼音：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("宋体", 9F);
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(21, 134);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 181;
            this.label19.Text = "住院时间：";
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDoctor.FormattingEnabled = true;
            this.cbxDoctor.Location = new System.Drawing.Point(334, 164);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.Size = new System.Drawing.Size(119, 20);
            this.cbxDoctor.TabIndex = 195;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(259, 167);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(65, 12);
            this.lblDoctor.TabIndex = 194;
            this.lblDoctor.Text = "管床医生：";
            // 
            // dtpInAreaTime
            // 
            this.dtpInAreaTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpInAreaTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInAreaTime.Location = new System.Drawing.Point(93, 160);
            this.dtpInAreaTime.Name = "dtpInAreaTime";
            this.dtpInAreaTime.Size = new System.Drawing.Size(120, 21);
            this.dtpInAreaTime.TabIndex = 193;
            // 
            // cbxBed_Id
            // 
            this.cbxBed_Id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBed_Id.FormattingEnabled = true;
            this.cbxBed_Id.Location = new System.Drawing.Point(334, 134);
            this.cbxBed_Id.Name = "cbxBed_Id";
            this.cbxBed_Id.Size = new System.Drawing.Size(119, 20);
            this.cbxBed_Id.TabIndex = 192;
            // 
            // lblInAreaTime
            // 
            this.lblInAreaTime.AutoSize = true;
            this.lblInAreaTime.Location = new System.Drawing.Point(22, 164);
            this.lblInAreaTime.Name = "lblInAreaTime";
            this.lblInAreaTime.Size = new System.Drawing.Size(65, 12);
            this.lblInAreaTime.TabIndex = 186;
            this.lblInAreaTime.Text = "入区时间：";
            // 
            // lblBed
            // 
            this.lblBed.AutoSize = true;
            this.lblBed.Location = new System.Drawing.Point(259, 137);
            this.lblBed.Name = "lblBed";
            this.lblBed.Size = new System.Drawing.Size(65, 12);
            this.lblBed.TabIndex = 185;
            this.lblBed.Text = "床    号：";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(249, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 198;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOk.Location = new System.Drawing.Point(168, 211);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 197;
            this.btnOk.Text = "确定";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("宋体", 9F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(21, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 201;
            this.label15.Text = "当前科室：";
            // 
            // cboCusection
            // 
            this.cboCusection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCusection.FormattingEnabled = true;
            this.cboCusection.Location = new System.Drawing.Point(93, 104);
            this.cboCusection.Name = "cboCusection";
            this.cboCusection.Size = new System.Drawing.Size(130, 20);
            this.cboCusection.TabIndex = 199;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("宋体", 9F);
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(263, 106);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 202;
            this.label14.Text = "当前病区：";
            // 
            // cboCusick
            // 
            this.cboCusick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCusick.FormattingEnabled = true;
            this.cboCusick.Location = new System.Drawing.Point(334, 103);
            this.cboCusick.Name = "cboCusick";
            this.cboCusick.Size = new System.Drawing.Size(126, 20);
            this.cboCusick.TabIndex = 200;
            // 
            // lblAgeCheck
            // 
            this.lblAgeCheck.AutoSize = true;
            this.lblAgeCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAgeCheck.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAgeCheck.ForeColor = System.Drawing.Color.Blue;
            this.lblAgeCheck.Location = new System.Drawing.Point(418, 52);
            this.lblAgeCheck.Name = "lblAgeCheck";
            this.lblAgeCheck.Size = new System.Drawing.Size(53, 12);
            this.lblAgeCheck.TabIndex = 203;
            this.lblAgeCheck.Text = "计算年龄";
            this.lblAgeCheck.Click += new System.EventHandler(this.lblAgeCheck_Click);
            // 
            // frmPatientIN_Old
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 252);
            this.Controls.Add(this.lblAgeCheck);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cboCusection);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cboCusick);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cbxDoctor);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.dtpInAreaTime);
            this.Controls.Add(this.cbxBed_Id);
            this.Controls.Add(this.lblInAreaTime);
            this.Controls.Add(this.lblBed);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboAgeunit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPiyin);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.dtpBirthday);
            this.Controls.Add(this.cboGender);
            this.Controls.Add(this.dtpDatetime);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label19);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientIN_Old";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "病人信息";
            this.Load += new System.EventHandler(this.frmPatientIN_Old_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAgeunit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPiyin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.DateTimePicker dtpDatetime;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbxDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.DateTimePicker dtpInAreaTime;
        private System.Windows.Forms.ComboBox cbxBed_Id;
        private System.Windows.Forms.Label lblInAreaTime;
        private System.Windows.Forms.Label lblBed;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOk;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboCusection;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboCusick;
        private System.Windows.Forms.Label lblAgeCheck;
    }
}