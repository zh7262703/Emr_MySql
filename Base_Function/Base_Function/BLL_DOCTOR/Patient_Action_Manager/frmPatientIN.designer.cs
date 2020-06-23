namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    partial class frmPatientIN
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
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.lblZYH = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtConditions = new System.Windows.Forms.TextBox();
            this.cboConditions = new System.Windows.Forms.ComboBox();
            this.chkUnusual = new System.Windows.Forms.CheckBox();
            this.btnReflresh = new DevComponents.DotNetBar.ButtonX();
            this.dataHisInfos = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHisInfos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 4);
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
            this.cboAgeunit.Location = new System.Drawing.Point(404, 56);
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
            this.label8.Location = new System.Drawing.Point(286, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 175;
            this.label8.Text = "姓名：";
            // 
            // txtPiyin
            // 
            this.txtPiyin.Location = new System.Drawing.Point(94, 30);
            this.txtPiyin.Name = "txtPiyin";
            this.txtPiyin.ReadOnly = true;
            this.txtPiyin.Size = new System.Drawing.Size(130, 21);
            this.txtPiyin.TabIndex = 184;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(336, 1);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(127, 21);
            this.txtName.TabIndex = 167;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(336, 56);
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
            this.label7.Location = new System.Drawing.Point(48, 59);
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
            this.label2.Location = new System.Drawing.Point(287, 60);
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
            this.label6.Location = new System.Drawing.Point(262, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 177;
            this.label6.Text = "出生年月：";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(95, 0);
            this.txtNumber.MaxLength = 20;
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(130, 21);
            this.txtNumber.TabIndex = 166;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.CustomFormat = "yyyy-MM-dd";
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(336, 29);
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
            this.cboGender.Location = new System.Drawing.Point(95, 56);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(62, 20);
            this.cboGender.TabIndex = 169;
            // 
            // dtpDatetime
            // 
            this.dtpDatetime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDatetime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatetime.Location = new System.Drawing.Point(94, 110);
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
            this.label24.Location = new System.Drawing.Point(46, 33);
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
            this.label19.Location = new System.Drawing.Point(23, 114);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 181;
            this.label19.Text = "住院时间：";
            // 
            // cbxDoctor
            // 
            this.cbxDoctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDoctor.FormattingEnabled = true;
            this.cbxDoctor.Location = new System.Drawing.Point(336, 144);
            this.cbxDoctor.Name = "cbxDoctor";
            this.cbxDoctor.Size = new System.Drawing.Size(119, 20);
            this.cbxDoctor.TabIndex = 195;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Location = new System.Drawing.Point(261, 147);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(65, 12);
            this.lblDoctor.TabIndex = 194;
            this.lblDoctor.Text = "管床医生：";
            // 
            // dtpInAreaTime
            // 
            this.dtpInAreaTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpInAreaTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInAreaTime.Location = new System.Drawing.Point(95, 140);
            this.dtpInAreaTime.Name = "dtpInAreaTime";
            this.dtpInAreaTime.Size = new System.Drawing.Size(120, 21);
            this.dtpInAreaTime.TabIndex = 193;
            // 
            // cbxBed_Id
            // 
            this.cbxBed_Id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBed_Id.FormattingEnabled = true;
            this.cbxBed_Id.Location = new System.Drawing.Point(336, 114);
            this.cbxBed_Id.Name = "cbxBed_Id";
            this.cbxBed_Id.Size = new System.Drawing.Size(119, 20);
            this.cbxBed_Id.TabIndex = 192;
            // 
            // lblInAreaTime
            // 
            this.lblInAreaTime.AutoSize = true;
            this.lblInAreaTime.Location = new System.Drawing.Point(24, 144);
            this.lblInAreaTime.Name = "lblInAreaTime";
            this.lblInAreaTime.Size = new System.Drawing.Size(65, 12);
            this.lblInAreaTime.TabIndex = 186;
            this.lblInAreaTime.Text = "入区时间：";
            // 
            // lblBed
            // 
            this.lblBed.AutoSize = true;
            this.lblBed.Location = new System.Drawing.Point(261, 117);
            this.lblBed.Name = "lblBed";
            this.lblBed.Size = new System.Drawing.Size(65, 12);
            this.lblBed.TabIndex = 185;
            this.lblBed.Text = "床    号：";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(308, 5);
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
            this.btnOk.Location = new System.Drawing.Point(192, 5);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(110, 23);
            this.btnOk.TabIndex = 197;
            this.btnOk.Text = "导入电子病历系统";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("宋体", 9F);
            this.label15.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label15.Location = new System.Drawing.Point(23, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 201;
            this.label15.Text = "当前科室：";
            // 
            // cboCusection
            // 
            this.cboCusection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCusection.FormattingEnabled = true;
            this.cboCusection.Location = new System.Drawing.Point(95, 84);
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
            this.label14.Location = new System.Drawing.Point(265, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 202;
            this.label14.Text = "当前病区：";
            // 
            // cboCusick
            // 
            this.cboCusick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCusick.FormattingEnabled = true;
            this.cboCusick.Location = new System.Drawing.Point(336, 83);
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
            this.lblAgeCheck.Location = new System.Drawing.Point(420, 32);
            this.lblAgeCheck.Name = "lblAgeCheck";
            this.lblAgeCheck.Size = new System.Drawing.Size(53, 12);
            this.lblAgeCheck.TabIndex = 203;
            this.lblAgeCheck.Text = "计算年龄";
            this.lblAgeCheck.Click += new System.EventHandler(this.lblAgeCheck_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.lblZYH);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.txtNumber);
            this.groupPanel1.Controls.Add(this.lblAgeCheck);
            this.groupPanel1.Controls.Add(this.label19);
            this.groupPanel1.Controls.Add(this.label15);
            this.groupPanel1.Controls.Add(this.label24);
            this.groupPanel1.Controls.Add(this.cboCusection);
            this.groupPanel1.Controls.Add(this.dtpDatetime);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.cboGender);
            this.groupPanel1.Controls.Add(this.cboCusick);
            this.groupPanel1.Controls.Add(this.dtpBirthday);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.cbxDoctor);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.lblDoctor);
            this.groupPanel1.Controls.Add(this.txtAge);
            this.groupPanel1.Controls.Add(this.dtpInAreaTime);
            this.groupPanel1.Controls.Add(this.txtName);
            this.groupPanel1.Controls.Add(this.cbxBed_Id);
            this.groupPanel1.Controls.Add(this.txtPiyin);
            this.groupPanel1.Controls.Add(this.lblInAreaTime);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.lblBed);
            this.groupPanel1.Controls.Add(this.cboAgeunit);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupPanel1.Location = new System.Drawing.Point(0, 261);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(670, 195);
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
            this.groupPanel1.TabIndex = 204;
            this.groupPanel1.Text = "信息编辑";
            // 
            // lblZYH
            // 
            this.lblZYH.AutoSize = true;
            this.lblZYH.BackColor = System.Drawing.Color.Transparent;
            this.lblZYH.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblZYH.ForeColor = System.Drawing.Color.Red;
            this.lblZYH.Location = new System.Drawing.Point(531, 2);
            this.lblZYH.Name = "lblZYH";
            this.lblZYH.Size = new System.Drawing.Size(125, 16);
            this.lblZYH.TabIndex = 205;
            this.lblZYH.Text = "ZY00000000001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(469, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 14);
            this.label3.TabIndex = 204;
            this.label3.Text = "HIS主键：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 456);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 35);
            this.panel1.TabIndex = 205;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dataHisInfos);
            this.groupPanel2.Controls.Add(this.panel2);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(670, 261);
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
            this.groupPanel2.TabIndex = 206;
            this.groupPanel2.Text = "HIS系统中现有病人信息";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.txtConditions);
            this.panel2.Controls.Add(this.cboConditions);
            this.panel2.Controls.Add(this.chkUnusual);
            this.panel2.Controls.Add(this.btnReflresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(664, 37);
            this.panel2.TabIndex = 1;
            // 
            // txtConditions
            // 
            this.txtConditions.Enabled = false;
            this.txtConditions.Location = new System.Drawing.Point(154, 7);
            this.txtConditions.Name = "txtConditions";
            this.txtConditions.Size = new System.Drawing.Size(119, 21);
            this.txtConditions.TabIndex = 4;
            // 
            // cboConditions
            // 
            this.cboConditions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConditions.Enabled = false;
            this.cboConditions.FormattingEnabled = true;
            this.cboConditions.Items.AddRange(new object[] {
            "住院号",
            "病人姓名"});
            this.cboConditions.Location = new System.Drawing.Point(68, 7);
            this.cboConditions.Name = "cboConditions";
            this.cboConditions.Size = new System.Drawing.Size(80, 20);
            this.cboConditions.TabIndex = 3;
            // 
            // chkUnusual
            // 
            this.chkUnusual.AutoSize = true;
            this.chkUnusual.Location = new System.Drawing.Point(14, 9);
            this.chkUnusual.Name = "chkUnusual";
            this.chkUnusual.Size = new System.Drawing.Size(48, 16);
            this.chkUnusual.TabIndex = 1;
            this.chkUnusual.Text = "查询";
            this.chkUnusual.UseVisualStyleBackColor = true;
            this.chkUnusual.CheckedChanged += new System.EventHandler(this.chkUnusual_CheckedChanged);
            // 
            // btnReflresh
            // 
            this.btnReflresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReflresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReflresh.Location = new System.Drawing.Point(441, 4);
            this.btnReflresh.Name = "btnReflresh";
            this.btnReflresh.Size = new System.Drawing.Size(121, 27);
            this.btnReflresh.TabIndex = 0;
            this.btnReflresh.Text = "刷新HIS病人信息";
            this.btnReflresh.Click += new System.EventHandler(this.btnReflresh_Click);
            // 
            // dataHisInfos
            // 
            this.dataHisInfos.AllowUserToAddRows = false;
            this.dataHisInfos.BackgroundColor = System.Drawing.Color.White;
            this.dataHisInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataHisInfos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataHisInfos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataHisInfos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dataHisInfos.Location = new System.Drawing.Point(0, 37);
            this.dataHisInfos.Name = "dataHisInfos";
            this.dataHisInfos.RowTemplate.Height = 23;
            this.dataHisInfos.Size = new System.Drawing.Size(664, 200);
            this.dataHisInfos.TabIndex = 0;
            this.dataHisInfos.Click += new System.EventHandler(this.dataHisInfos_Click);
            // 
            // frmPatientIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 491);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientIN";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "病人信息";
            this.Load += new System.EventHandler(this.frmPatientIN_Load);
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHisInfos)).EndInit();
            this.ResumeLayout(false);

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
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private System.Windows.Forms.Panel panel2;
        private DevComponents.DotNetBar.ButtonX btnReflresh;
        private System.Windows.Forms.Label lblZYH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConditions;
        private System.Windows.Forms.ComboBox cboConditions;
        private System.Windows.Forms.CheckBox chkUnusual;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataHisInfos;
    }
}