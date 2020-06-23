namespace Base_Function.BLL_NURSE.SickInformational
{
    partial class AddSickTeport
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
            this.checkPanl = new System.Windows.Forms.Panel();
            this.cckbOutHospital = new System.Windows.Forms.CheckBox();
            this.cckbConvey = new System.Windows.Forms.CheckBox();
            this.cckbkill = new System.Windows.Forms.CheckBox();
            this.cckbInHospital = new System.Windows.Forms.CheckBox();
            this.cckbShiftTo = new System.Windows.Forms.CheckBox();
            this.cckbSymptom = new System.Windows.Forms.CheckBox();
            this.cckbterminally = new System.Windows.Forms.CheckBox();
            this.cckbOperation = new System.Windows.Forms.CheckBox();
            this.cckbchildbearing = new System.Windows.Forms.CheckBox();
            this.ccbkCaenozoic = new System.Windows.Forms.CheckBox();
            this.ccbkmornOPS = new System.Windows.Forms.CheckBox();
            this.txtRemak = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRName = new System.Windows.Forms.TextBox();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.txtBPOnename = new System.Windows.Forms.TextBox();
            this.txtanimal_heat = new System.Windows.Forms.TextBox();
            this.txtBPTwoName = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiagnoseName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIllNessNO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtuserName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ccbkbed_No = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.btnReadLife = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.checkPanl.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkPanl
            // 
            this.checkPanl.BackColor = System.Drawing.Color.Transparent;
            this.checkPanl.Controls.Add(this.cckbOutHospital);
            this.checkPanl.Controls.Add(this.cckbConvey);
            this.checkPanl.Controls.Add(this.cckbkill);
            this.checkPanl.Controls.Add(this.cckbInHospital);
            this.checkPanl.Controls.Add(this.cckbShiftTo);
            this.checkPanl.Controls.Add(this.cckbSymptom);
            this.checkPanl.Controls.Add(this.cckbterminally);
            this.checkPanl.Controls.Add(this.cckbOperation);
            this.checkPanl.Controls.Add(this.cckbchildbearing);
            this.checkPanl.Controls.Add(this.ccbkCaenozoic);
            this.checkPanl.Controls.Add(this.ccbkmornOPS);
            this.checkPanl.Location = new System.Drawing.Point(92, 8);
            this.checkPanl.Name = "checkPanl";
            this.checkPanl.Size = new System.Drawing.Size(611, 31);
            this.checkPanl.TabIndex = 42;
            // 
            // cckbOutHospital
            // 
            this.cckbOutHospital.AutoSize = true;
            this.cckbOutHospital.Location = new System.Drawing.Point(3, 12);
            this.cckbOutHospital.Name = "cckbOutHospital";
            this.cckbOutHospital.Size = new System.Drawing.Size(48, 16);
            this.cckbOutHospital.TabIndex = 1;
            this.cckbOutHospital.Text = "出院";
            this.cckbOutHospital.UseVisualStyleBackColor = true;
            this.cckbOutHospital.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // cckbConvey
            // 
            this.cckbConvey.AutoSize = true;
            this.cckbConvey.Location = new System.Drawing.Point(57, 12);
            this.cckbConvey.Name = "cckbConvey";
            this.cckbConvey.Size = new System.Drawing.Size(48, 16);
            this.cckbConvey.TabIndex = 2;
            this.cckbConvey.Text = "转出";
            this.cckbConvey.UseVisualStyleBackColor = true;
            this.cckbConvey.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // cckbkill
            // 
            this.cckbkill.AutoSize = true;
            this.cckbkill.Location = new System.Drawing.Point(111, 12);
            this.cckbkill.Name = "cckbkill";
            this.cckbkill.Size = new System.Drawing.Size(48, 16);
            this.cckbkill.TabIndex = 3;
            this.cckbkill.Text = "死亡";
            this.cckbkill.UseVisualStyleBackColor = true;
            this.cckbkill.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // cckbInHospital
            // 
            this.cckbInHospital.AutoSize = true;
            this.cckbInHospital.Location = new System.Drawing.Point(163, 12);
            this.cckbInHospital.Name = "cckbInHospital";
            this.cckbInHospital.Size = new System.Drawing.Size(48, 16);
            this.cckbInHospital.TabIndex = 4;
            this.cckbInHospital.Text = "入院";
            this.cckbInHospital.UseVisualStyleBackColor = true;
            this.cckbInHospital.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // cckbShiftTo
            // 
            this.cckbShiftTo.AutoSize = true;
            this.cckbShiftTo.Location = new System.Drawing.Point(217, 12);
            this.cckbShiftTo.Name = "cckbShiftTo";
            this.cckbShiftTo.Size = new System.Drawing.Size(48, 16);
            this.cckbShiftTo.TabIndex = 5;
            this.cckbShiftTo.Text = "转入";
            this.cckbShiftTo.UseVisualStyleBackColor = true;
            this.cckbShiftTo.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // cckbSymptom
            // 
            this.cckbSymptom.AutoSize = true;
            this.cckbSymptom.Location = new System.Drawing.Point(271, 12);
            this.cckbSymptom.Name = "cckbSymptom";
            this.cckbSymptom.Size = new System.Drawing.Size(48, 16);
            this.cckbSymptom.TabIndex = 6;
            this.cckbSymptom.Text = "病重";
            this.cckbSymptom.UseVisualStyleBackColor = true;
            this.cckbSymptom.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // cckbterminally
            // 
            this.cckbterminally.AutoSize = true;
            this.cckbterminally.Location = new System.Drawing.Point(325, 12);
            this.cckbterminally.Name = "cckbterminally";
            this.cckbterminally.Size = new System.Drawing.Size(48, 16);
            this.cckbterminally.TabIndex = 7;
            this.cckbterminally.Text = "病危";
            this.cckbterminally.UseVisualStyleBackColor = true;
            this.cckbterminally.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // cckbOperation
            // 
            this.cckbOperation.AutoSize = true;
            this.cckbOperation.Location = new System.Drawing.Point(379, 12);
            this.cckbOperation.Name = "cckbOperation";
            this.cckbOperation.Size = new System.Drawing.Size(48, 16);
            this.cckbOperation.TabIndex = 8;
            this.cckbOperation.Text = "手术";
            this.cckbOperation.UseVisualStyleBackColor = true;
            this.cckbOperation.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // cckbchildbearing
            // 
            this.cckbchildbearing.AutoSize = true;
            this.cckbchildbearing.Location = new System.Drawing.Point(427, 12);
            this.cckbchildbearing.Name = "cckbchildbearing";
            this.cckbchildbearing.Size = new System.Drawing.Size(48, 16);
            this.cckbchildbearing.TabIndex = 9;
            this.cckbchildbearing.Text = "分娩";
            this.cckbchildbearing.UseVisualStyleBackColor = true;
            this.cckbchildbearing.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // ccbkCaenozoic
            // 
            this.ccbkCaenozoic.AutoSize = true;
            this.ccbkCaenozoic.Location = new System.Drawing.Point(481, 12);
            this.ccbkCaenozoic.Name = "ccbkCaenozoic";
            this.ccbkCaenozoic.Size = new System.Drawing.Size(60, 16);
            this.ccbkCaenozoic.TabIndex = 10;
            this.ccbkCaenozoic.Text = "新生儿";
            this.ccbkCaenozoic.UseVisualStyleBackColor = true;
            this.ccbkCaenozoic.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // ccbkmornOPS
            // 
            this.ccbkmornOPS.AutoSize = true;
            this.ccbkmornOPS.Location = new System.Drawing.Point(547, 12);
            this.ccbkmornOPS.Name = "ccbkmornOPS";
            this.ccbkmornOPS.Size = new System.Drawing.Size(60, 16);
            this.ccbkmornOPS.TabIndex = 11;
            this.ccbkmornOPS.Text = "明手术";
            this.ccbkmornOPS.UseVisualStyleBackColor = true;
            this.ccbkmornOPS.Click += new System.EventHandler(this.cckbOutHospital_Click);
            // 
            // txtRemak
            // 
            this.txtRemak.Location = new System.Drawing.Point(92, 183);
            this.txtRemak.Multiline = true;
            this.txtRemak.Name = "txtRemak";
            this.txtRemak.Size = new System.Drawing.Size(502, 78);
            this.txtRemak.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(25, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 38;
            this.label8.Text = "特殊说明：";
            // 
            // txtRName
            // 
            this.txtRName.Location = new System.Drawing.Point(496, 156);
            this.txtRName.Name = "txtRName";
            this.txtRName.Size = new System.Drawing.Size(40, 21);
            this.txtRName.TabIndex = 37;
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(405, 156);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(40, 21);
            this.txtPName.TabIndex = 36;
            // 
            // txtBPOnename
            // 
            this.txtBPOnename.Location = new System.Drawing.Point(593, 156);
            this.txtBPOnename.Name = "txtBPOnename";
            this.txtBPOnename.Size = new System.Drawing.Size(40, 21);
            this.txtBPOnename.TabIndex = 35;
            // 
            // txtanimal_heat
            // 
            this.txtanimal_heat.Location = new System.Drawing.Point(329, 156);
            this.txtanimal_heat.Name = "txtanimal_heat";
            this.txtanimal_heat.Size = new System.Drawing.Size(41, 21);
            this.txtanimal_heat.TabIndex = 34;
            // 
            // txtBPTwoName
            // 
            this.txtBPTwoName.Location = new System.Drawing.Point(646, 156);
            this.txtBPTwoName.Name = "txtBPTwoName";
            this.txtBPTwoName.Size = new System.Drawing.Size(40, 21);
            this.txtBPTwoName.TabIndex = 33;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(372, 159);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 32;
            this.label16.Text = "℃";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(386, 159);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 12);
            this.label15.TabIndex = 31;
            this.label15.Text = "P：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(446, 159);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 30;
            this.label14.Text = "次/分";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(479, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 29;
            this.label13.Text = "R：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(537, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 28;
            this.label12.Text = "次/分";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(570, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "BP：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(634, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(311, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 12);
            this.label7.TabIndex = 23;
            this.label7.Text = "T：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(91, 155);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(142, 21);
            this.dateTimePicker1.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(48, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "时间：";
            // 
            // txtDiagnoseName
            // 
            this.txtDiagnoseName.Location = new System.Drawing.Point(91, 72);
            this.txtDiagnoseName.Multiline = true;
            this.txtDiagnoseName.Name = "txtDiagnoseName";
            this.txtDiagnoseName.Size = new System.Drawing.Size(508, 78);
            this.txtDiagnoseName.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(38, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "诊断名：";
            // 
            // txtIllNessNO
            // 
            this.txtIllNessNO.Location = new System.Drawing.Point(499, 45);
            this.txtIllNessNO.Name = "txtIllNessNO";
            this.txtIllNessNO.Size = new System.Drawing.Size(100, 21);
            this.txtIllNessNO.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(439, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "病案号：";
            // 
            // txtuserName
            // 
            this.txtuserName.Location = new System.Drawing.Point(287, 45);
            this.txtuserName.Name = "txtuserName";
            this.txtuserName.Size = new System.Drawing.Size(100, 21);
            this.txtuserName.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "姓名：";
            // 
            // ccbkbed_No
            // 
            this.ccbkbed_No.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ccbkbed_No.FormattingEnabled = true;
            this.ccbkbed_No.Location = new System.Drawing.Point(92, 45);
            this.ccbkbed_No.Name = "ccbkbed_No";
            this.ccbkbed_No.Size = new System.Drawing.Size(102, 20);
            this.ccbkbed_No.TabIndex = 13;
            this.ccbkbed_No.SelectedIndexChanged += new System.EventHandler(this.ccbkbed_No_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(50, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "床号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "异动项目：";
            // 
            // groupPanel1
            // 
            this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btnCancel);
            this.groupPanel1.Controls.Add(this.btnSave);
            this.groupPanel1.Controls.Add(this.btnReadLife);
            this.groupPanel1.Controls.Add(this.checkPanl);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Controls.Add(this.txtRemak);
            this.groupPanel1.Controls.Add(this.ccbkbed_No);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.txtRName);
            this.groupPanel1.Controls.Add(this.txtuserName);
            this.groupPanel1.Controls.Add(this.txtPName);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.txtBPOnename);
            this.groupPanel1.Controls.Add(this.txtIllNessNO);
            this.groupPanel1.Controls.Add(this.txtanimal_heat);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.txtBPTwoName);
            this.groupPanel1.Controls.Add(this.txtDiagnoseName);
            this.groupPanel1.Controls.Add(this.label16);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label15);
            this.groupPanel1.Controls.Add(this.dateTimePicker1);
            this.groupPanel1.Controls.Add(this.label14);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.label13);
            this.groupPanel1.Controls.Add(this.label9);
            this.groupPanel1.Controls.Add(this.label12);
            this.groupPanel1.Controls.Add(this.label10);
            this.groupPanel1.Controls.Add(this.label11);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(0, 0);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(746, 340);
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
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "添加异动项目";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(687, 159);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 26;
            this.label10.Text = "mmHg";
            // 
            // btnReadLife
            // 
            this.btnReadLife.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnReadLife.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnReadLife.Location = new System.Drawing.Point(239, 153);
            this.btnReadLife.Name = "btnReadLife";
            this.btnReadLife.Size = new System.Drawing.Size(66, 23);
            this.btnReadLife.TabIndex = 43;
            this.btnReadLife.Text = "读生命体征";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(292, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "确 定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(373, 283);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "取 消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddSickTeport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 340);
            this.Controls.Add(this.groupPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSickTeport";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加异动信息";
            this.Load += new System.EventHandler(this.AddSickTeport_Load);
            this.checkPanl.ResumeLayout(false);
            this.checkPanl.PerformLayout();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ccbkCaenozoic;
        private System.Windows.Forms.CheckBox cckbchildbearing;
        private System.Windows.Forms.CheckBox cckbOperation;
        private System.Windows.Forms.CheckBox cckbterminally;
        private System.Windows.Forms.CheckBox cckbSymptom;
        private System.Windows.Forms.CheckBox cckbShiftTo;
        private System.Windows.Forms.CheckBox cckbInHospital;
        private System.Windows.Forms.CheckBox cckbkill;
        private System.Windows.Forms.CheckBox cckbConvey;
        private System.Windows.Forms.CheckBox cckbOutHospital;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ccbkmornOPS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIllNessNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtuserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ccbkbed_No;
        private System.Windows.Forms.TextBox txtDiagnoseName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRName;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.TextBox txtBPOnename;
        private System.Windows.Forms.TextBox txtanimal_heat;
        private System.Windows.Forms.TextBox txtBPTwoName;
        private System.Windows.Forms.TextBox txtRemak;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel checkPanl;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Label label10;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnReadLife;
    }
}