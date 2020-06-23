namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    partial class frmPatientInfo1
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
            this.lblPay = new System.Windows.Forms.Label();
            this.cbxPay = new System.Windows.Forms.ComboBox();
            this.cbxSex = new System.Windows.Forms.ComboBox();
            this.lblPName = new System.Windows.Forms.Label();
            this.cbxNationality = new System.Windows.Forms.ComboBox();
            this.lblId_Number = new System.Windows.Forms.Label();
            this.cbxNational = new System.Windows.Forms.ComboBox();
            this.lblNational = new System.Windows.Forms.Label();
            this.txtPName = new System.Windows.Forms.TextBox();
            this.txtId_Number = new System.Windows.Forms.TextBox();
            this.lblWorkAddress = new System.Windows.Forms.Label();
            this.lblAccountAddress = new System.Windows.Forms.Label();
            this.txtWorkAddress = new System.Windows.Forms.TextBox();
            this.txtAccountAddress = new System.Windows.Forms.TextBox();
            this.lblContactAddress = new System.Windows.Forms.Label();
            this.lblIn_Hospital_Time = new System.Windows.Forms.Label();
            this.txtContactAddress = new System.Windows.Forms.TextBox();
            this.txtIn_Hospital_Time = new System.Windows.Forms.TextBox();
            this.lblDiagnostic = new System.Windows.Forms.Label();
            this.txtDiagnostic = new System.Windows.Forms.TextBox();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblBirth_Date = new System.Windows.Forms.Label();
            this.lblNationality = new System.Windows.Forms.Label();
            this.dtpBirth_Date = new System.Windows.Forms.DateTimePicker();
            this.lblRelationship = new System.Windows.Forms.Label();
            this.cbxRelationship = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIn_Count = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOffice_Post = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAge = new System.Windows.Forms.TextBox();
            this.cbxAge_Unit = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.cbxMarred = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOffice_Phone = new System.Windows.Forms.TextBox();
            this.cbxProvince = new System.Windows.Forms.ComboBox();
            this.cbxShi = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHome_Post = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRelation_Phone = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbxIn_Cirs = new System.Windows.Forms.ComboBox();
            this.btnRight = new System.Windows.Forms.Button();
            this.lblLeavel = new System.Windows.Forms.Label();
            this.cbxNurse_Leavel = new System.Windows.Forms.ComboBox();
            this.btnAddIn_Danger = new DevComponents.DotNetBar.ButtonX();
            this.btnAddIll = new DevComponents.DotNetBar.ButtonX();
            this.btnStopIn_Danger = new DevComponents.DotNetBar.ButtonX();
            this.btnStopIll = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.chbReadonly = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRelationName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboCreer = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblPay
            // 
            this.lblPay.AutoSize = true;
            this.lblPay.Location = new System.Drawing.Point(13, 13);
            this.lblPay.Name = "lblPay";
            this.lblPay.Size = new System.Drawing.Size(89, 12);
            this.lblPay.TabIndex = 0;
            this.lblPay.Text = "医疗付款方式：";
            // 
            // cbxPay
            // 
            this.cbxPay.FormattingEnabled = true;
            this.cbxPay.Items.AddRange(new object[] {
            "--请选择--",
            "城镇职工医保",
            "城镇居民医保",
            "合作医疗",
            "离休",
            "自费",
            "其他"});
            this.cbxPay.Location = new System.Drawing.Point(107, 7);
            this.cbxPay.Name = "cbxPay";
            this.cbxPay.Size = new System.Drawing.Size(121, 20);
            this.cbxPay.TabIndex = 1;
            // 
            // cbxSex
            // 
            this.cbxSex.FormattingEnabled = true;
            this.cbxSex.Items.AddRange(new object[] {
            "-请选择-",
            "男",
            "女"});
            this.cbxSex.Location = new System.Drawing.Point(308, 45);
            this.cbxSex.Name = "cbxSex";
            this.cbxSex.Size = new System.Drawing.Size(78, 20);
            this.cbxSex.TabIndex = 3;
            // 
            // lblPName
            // 
            this.lblPName.AutoSize = true;
            this.lblPName.Location = new System.Drawing.Point(60, 46);
            this.lblPName.Name = "lblPName";
            this.lblPName.Size = new System.Drawing.Size(41, 12);
            this.lblPName.TabIndex = 2;
            this.lblPName.Text = "姓名：";
            // 
            // cbxNationality
            // 
            this.cbxNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNationality.FormattingEnabled = true;
            this.cbxNationality.Items.AddRange(new object[] {
            "中国",
            "日本",
            "韩国",
            "俄罗斯",
            "美国",
            "英国",
            "法国",
            "德国",
            "澳大利亚"});
            this.cbxNationality.Location = new System.Drawing.Point(308, 119);
            this.cbxNationality.Name = "cbxNationality";
            this.cbxNationality.Size = new System.Drawing.Size(108, 20);
            this.cbxNationality.TabIndex = 5;
            // 
            // lblId_Number
            // 
            this.lblId_Number.AutoSize = true;
            this.lblId_Number.Location = new System.Drawing.Point(36, 84);
            this.lblId_Number.Name = "lblId_Number";
            this.lblId_Number.Size = new System.Drawing.Size(65, 12);
            this.lblId_Number.TabIndex = 4;
            this.lblId_Number.Text = "身份证号：";
            // 
            // cbxNational
            // 
            this.cbxNational.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNational.FormattingEnabled = true;
            this.cbxNational.Location = new System.Drawing.Point(107, 118);
            this.cbxNational.Name = "cbxNational";
            this.cbxNational.Size = new System.Drawing.Size(121, 20);
            this.cbxNational.TabIndex = 7;
            // 
            // lblNational
            // 
            this.lblNational.AutoSize = true;
            this.lblNational.Location = new System.Drawing.Point(60, 121);
            this.lblNational.Name = "lblNational";
            this.lblNational.Size = new System.Drawing.Size(41, 12);
            this.lblNational.TabIndex = 6;
            this.lblNational.Text = "民族：";
            // 
            // txtPName
            // 
            this.txtPName.Location = new System.Drawing.Point(107, 43);
            this.txtPName.Name = "txtPName";
            this.txtPName.Size = new System.Drawing.Size(100, 21);
            this.txtPName.TabIndex = 8;
            // 
            // txtId_Number
            // 
            this.txtId_Number.Location = new System.Drawing.Point(107, 81);
            this.txtId_Number.Name = "txtId_Number";
            this.txtId_Number.Size = new System.Drawing.Size(100, 21);
            this.txtId_Number.TabIndex = 8;
            // 
            // lblWorkAddress
            // 
            this.lblWorkAddress.AutoSize = true;
            this.lblWorkAddress.Location = new System.Drawing.Point(1, 150);
            this.lblWorkAddress.Name = "lblWorkAddress";
            this.lblWorkAddress.Size = new System.Drawing.Size(101, 12);
            this.lblWorkAddress.TabIndex = 2;
            this.lblWorkAddress.Text = "工作单位及地址：";
            // 
            // lblAccountAddress
            // 
            this.lblAccountAddress.AutoSize = true;
            this.lblAccountAddress.Location = new System.Drawing.Point(36, 184);
            this.lblAccountAddress.Name = "lblAccountAddress";
            this.lblAccountAddress.Size = new System.Drawing.Size(65, 12);
            this.lblAccountAddress.TabIndex = 4;
            this.lblAccountAddress.Text = "户口地址：";
            // 
            // txtWorkAddress
            // 
            this.txtWorkAddress.Location = new System.Drawing.Point(107, 147);
            this.txtWorkAddress.Name = "txtWorkAddress";
            this.txtWorkAddress.Size = new System.Drawing.Size(195, 21);
            this.txtWorkAddress.TabIndex = 8;
            // 
            // txtAccountAddress
            // 
            this.txtAccountAddress.Location = new System.Drawing.Point(107, 181);
            this.txtAccountAddress.Name = "txtAccountAddress";
            this.txtAccountAddress.Size = new System.Drawing.Size(195, 21);
            this.txtAccountAddress.TabIndex = 8;
            // 
            // lblContactAddress
            // 
            this.lblContactAddress.AutoSize = true;
            this.lblContactAddress.Location = new System.Drawing.Point(25, 222);
            this.lblContactAddress.Name = "lblContactAddress";
            this.lblContactAddress.Size = new System.Drawing.Size(77, 12);
            this.lblContactAddress.TabIndex = 2;
            this.lblContactAddress.Text = "联系人地址：";
            // 
            // lblIn_Hospital_Time
            // 
            this.lblIn_Hospital_Time.AutoSize = true;
            this.lblIn_Hospital_Time.Location = new System.Drawing.Point(37, 258);
            this.lblIn_Hospital_Time.Name = "lblIn_Hospital_Time";
            this.lblIn_Hospital_Time.Size = new System.Drawing.Size(65, 12);
            this.lblIn_Hospital_Time.TabIndex = 4;
            this.lblIn_Hospital_Time.Text = "入院日期：";
            // 
            // txtContactAddress
            // 
            this.txtContactAddress.Location = new System.Drawing.Point(107, 219);
            this.txtContactAddress.Name = "txtContactAddress";
            this.txtContactAddress.Size = new System.Drawing.Size(150, 21);
            this.txtContactAddress.TabIndex = 8;
            // 
            // txtIn_Hospital_Time
            // 
            this.txtIn_Hospital_Time.Enabled = false;
            this.txtIn_Hospital_Time.Location = new System.Drawing.Point(107, 255);
            this.txtIn_Hospital_Time.Name = "txtIn_Hospital_Time";
            this.txtIn_Hospital_Time.Size = new System.Drawing.Size(100, 21);
            this.txtIn_Hospital_Time.TabIndex = 8;
            // 
            // lblDiagnostic
            // 
            this.lblDiagnostic.AutoSize = true;
            this.lblDiagnostic.Location = new System.Drawing.Point(25, 293);
            this.lblDiagnostic.Name = "lblDiagnostic";
            this.lblDiagnostic.Size = new System.Drawing.Size(77, 12);
            this.lblDiagnostic.TabIndex = 4;
            this.lblDiagnostic.Text = "门急诊诊断：";
            this.lblDiagnostic.Visible = false;
            // 
            // txtDiagnostic
            // 
            this.txtDiagnostic.Location = new System.Drawing.Point(107, 290);
            this.txtDiagnostic.Name = "txtDiagnostic";
            this.txtDiagnostic.Size = new System.Drawing.Size(100, 21);
            this.txtDiagnostic.TabIndex = 8;
            this.txtDiagnostic.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(261, 47);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(41, 12);
            this.lblSex.TabIndex = 9;
            this.lblSex.Text = "性别：";
            // 
            // lblBirth_Date
            // 
            this.lblBirth_Date.AutoSize = true;
            this.lblBirth_Date.Location = new System.Drawing.Point(261, 84);
            this.lblBirth_Date.Name = "lblBirth_Date";
            this.lblBirth_Date.Size = new System.Drawing.Size(41, 12);
            this.lblBirth_Date.TabIndex = 9;
            this.lblBirth_Date.Text = "出生：";
            // 
            // lblNationality
            // 
            this.lblNationality.AutoSize = true;
            this.lblNationality.Location = new System.Drawing.Point(261, 121);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(41, 12);
            this.lblNationality.TabIndex = 9;
            this.lblNationality.Text = "国籍：";
            // 
            // dtpBirth_Date
            // 
            this.dtpBirth_Date.Location = new System.Drawing.Point(308, 82);
            this.dtpBirth_Date.Name = "dtpBirth_Date";
            this.dtpBirth_Date.Size = new System.Drawing.Size(108, 21);
            this.dtpBirth_Date.TabIndex = 10;
            this.dtpBirth_Date.ValueChanged += new System.EventHandler(this.dtpBirth_Date_ValueChanged);
            // 
            // lblRelationship
            // 
            this.lblRelationship.AutoSize = true;
            this.lblRelationship.Location = new System.Drawing.Point(263, 222);
            this.lblRelationship.Name = "lblRelationship";
            this.lblRelationship.Size = new System.Drawing.Size(41, 12);
            this.lblRelationship.TabIndex = 11;
            this.lblRelationship.Text = "关系：";
            // 
            // cbxRelationship
            // 
            this.cbxRelationship.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRelationship.FormattingEnabled = true;
            this.cbxRelationship.Items.AddRange(new object[] {
            "--请选择--",
            "父亲",
            "母亲",
            "哥哥",
            "弟弟",
            "姐姐",
            "妹妹"});
            this.cbxRelationship.Location = new System.Drawing.Point(308, 219);
            this.cbxRelationship.Name = "cbxRelationship";
            this.cbxRelationship.Size = new System.Drawing.Size(121, 20);
            this.cbxRelationship.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "住院次数：";
            // 
            // txtIn_Count
            // 
            this.txtIn_Count.Location = new System.Drawing.Point(528, 7);
            this.txtIn_Count.Name = "txtIn_Count";
            this.txtIn_Count.Size = new System.Drawing.Size(69, 21);
            this.txtIn_Count.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(487, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "婚姻：";
            // 
            // txtOffice_Post
            // 
            this.txtOffice_Post.Location = new System.Drawing.Point(732, 147);
            this.txtOffice_Post.Name = "txtOffice_Post";
            this.txtOffice_Post.Size = new System.Drawing.Size(110, 21);
            this.txtOffice_Post.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "年龄：";
            // 
            // txtAge
            // 
            this.txtAge.Location = new System.Drawing.Point(528, 82);
            this.txtAge.Name = "txtAge";
            this.txtAge.Size = new System.Drawing.Size(27, 21);
            this.txtAge.TabIndex = 14;
            // 
            // cbxAge_Unit
            // 
            this.cbxAge_Unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAge_Unit.FormattingEnabled = true;
            this.cbxAge_Unit.Items.AddRange(new object[] {
            "岁",
            "月",
            "天"});
            this.cbxAge_Unit.Location = new System.Drawing.Point(561, 83);
            this.cbxAge_Unit.Name = "cbxAge_Unit";
            this.cbxAge_Unit.Size = new System.Drawing.Size(43, 20);
            this.cbxAge_Unit.TabIndex = 15;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(610, 82);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(27, 21);
            this.textBox4.TabIndex = 14;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(732, 116);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(110, 21);
            this.textBox5.TabIndex = 14;
            // 
            // cbxMarred
            // 
            this.cbxMarred.FormattingEnabled = true;
            this.cbxMarred.Items.AddRange(new object[] {
            "-请选择-",
            "未婚",
            "已婚",
            "离婚",
            "丧偶"});
            this.cbxMarred.Location = new System.Drawing.Point(528, 44);
            this.cbxMarred.Name = "cbxMarred";
            this.cbxMarred.Size = new System.Drawing.Size(69, 20);
            this.cbxMarred.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(475, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "出生地：";
            // 
            // txtOffice_Phone
            // 
            this.txtOffice_Phone.Location = new System.Drawing.Point(528, 147);
            this.txtOffice_Phone.Name = "txtOffice_Phone";
            this.txtOffice_Phone.Size = new System.Drawing.Size(102, 21);
            this.txtOffice_Phone.TabIndex = 14;
            // 
            // cbxProvince
            // 
            this.cbxProvince.FormattingEnabled = true;
            this.cbxProvince.Location = new System.Drawing.Point(528, 116);
            this.cbxProvince.Name = "cbxProvince";
            this.cbxProvince.Size = new System.Drawing.Size(75, 20);
            this.cbxProvince.TabIndex = 15;
            this.cbxProvince.SelectedIndexChanged += new System.EventHandler(this.cbxProvince_SelectedIndexChanged);
            // 
            // cbxShi
            // 
            this.cbxShi.FormattingEnabled = true;
            this.cbxShi.Location = new System.Drawing.Point(626, 116);
            this.cbxShi.Name = "cbxShi";
            this.cbxShi.Size = new System.Drawing.Size(74, 20);
            this.cbxShi.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(605, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "省";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(707, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "县";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(487, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "电话：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(658, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "邮政编码：";
            // 
            // txtHome_Post
            // 
            this.txtHome_Post.Location = new System.Drawing.Point(732, 181);
            this.txtHome_Post.Name = "txtHome_Post";
            this.txtHome_Post.Size = new System.Drawing.Size(110, 21);
            this.txtHome_Post.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(658, 184);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "邮政编码：";
            // 
            // txtRelation_Phone
            // 
            this.txtRelation_Phone.Location = new System.Drawing.Point(732, 220);
            this.txtRelation_Phone.Name = "txtRelation_Phone";
            this.txtRelation_Phone.Size = new System.Drawing.Size(110, 21);
            this.txtRelation_Phone.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(682, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "电话：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(646, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "入院时情况：";
            // 
            // cbxIn_Cirs
            // 
            this.cbxIn_Cirs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxIn_Cirs.FormattingEnabled = true;
            this.cbxIn_Cirs.Items.AddRange(new object[] {
            "---请选择---",
            "一般",
            "危险",
            "危重"});
            this.cbxIn_Cirs.Location = new System.Drawing.Point(732, 255);
            this.cbxIn_Cirs.Name = "cbxIn_Cirs";
            this.cbxIn_Cirs.Size = new System.Drawing.Size(121, 20);
            this.cbxIn_Cirs.TabIndex = 21;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(213, 288);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(31, 23);
            this.btnRight.TabIndex = 22;
            this.btnRight.Text = "→";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Visible = false;
            // 
            // lblLeavel
            // 
            this.lblLeavel.AutoSize = true;
            this.lblLeavel.Location = new System.Drawing.Point(463, 258);
            this.lblLeavel.Name = "lblLeavel";
            this.lblLeavel.Size = new System.Drawing.Size(65, 12);
            this.lblLeavel.TabIndex = 23;
            this.lblLeavel.Text = "护理等级：";
            // 
            // cbxNurse_Leavel
            // 
            this.cbxNurse_Leavel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNurse_Leavel.FormattingEnabled = true;
            this.cbxNurse_Leavel.Location = new System.Drawing.Point(528, 255);
            this.cbxNurse_Leavel.Name = "cbxNurse_Leavel";
            this.cbxNurse_Leavel.Size = new System.Drawing.Size(109, 20);
            this.cbxNurse_Leavel.TabIndex = 24;
            // 
            // btnAddIn_Danger
            // 
            this.btnAddIn_Danger.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddIn_Danger.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddIn_Danger.Location = new System.Drawing.Point(234, 338);
            this.btnAddIn_Danger.Name = "btnAddIn_Danger";
            this.btnAddIn_Danger.Size = new System.Drawing.Size(85, 23);
            this.btnAddIn_Danger.TabIndex = 31;
            this.btnAddIn_Danger.Text = "增加病危医嘱";
            this.btnAddIn_Danger.Visible = false;
            this.btnAddIn_Danger.Click += new System.EventHandler(this.btnAddIn_Danger_Click);
            // 
            // btnAddIll
            // 
            this.btnAddIll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddIll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAddIll.Location = new System.Drawing.Point(325, 338);
            this.btnAddIll.Name = "btnAddIll";
            this.btnAddIll.Size = new System.Drawing.Size(89, 23);
            this.btnAddIll.TabIndex = 31;
            this.btnAddIll.Text = "增加病重医嘱";
            this.btnAddIll.Visible = false;
            this.btnAddIll.Click += new System.EventHandler(this.btnAddIll_Click);
            // 
            // btnStopIn_Danger
            // 
            this.btnStopIn_Danger.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStopIn_Danger.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStopIn_Danger.Location = new System.Drawing.Point(420, 338);
            this.btnStopIn_Danger.Name = "btnStopIn_Danger";
            this.btnStopIn_Danger.Size = new System.Drawing.Size(84, 23);
            this.btnStopIn_Danger.TabIndex = 31;
            this.btnStopIn_Danger.Text = "停止病危医嘱";
            this.btnStopIn_Danger.Visible = false;
            this.btnStopIn_Danger.Click += new System.EventHandler(this.btnStopIn_Danger_Click);
            // 
            // btnStopIll
            // 
            this.btnStopIll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStopIll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnStopIll.Location = new System.Drawing.Point(510, 338);
            this.btnStopIll.Name = "btnStopIll";
            this.btnStopIll.Size = new System.Drawing.Size(93, 23);
            this.btnStopIll.TabIndex = 31;
            this.btnStopIll.Text = "停止病重医嘱";
            this.btnStopIll.Visible = false;
            this.btnStopIll.Click += new System.EventHandler(this.btnStopIll_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(350, 371);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(431, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // chbReadonly
            // 
            this.chbReadonly.AutoSize = true;
            this.chbReadonly.Location = new System.Drawing.Point(53, 324);
            this.chbReadonly.Name = "chbReadonly";
            this.chbReadonly.Size = new System.Drawing.Size(48, 16);
            this.chbReadonly.TabIndex = 32;
            this.chbReadonly.Text = "只读";
            this.chbReadonly.UseVisualStyleBackColor = true;
            this.chbReadonly.Visible = false;
            this.chbReadonly.CheckedChanged += new System.EventHandler(this.chbReadonly_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(445, 222);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 33;
            this.label12.Text = "联系人姓名：";
            // 
            // txtRelationName
            // 
            this.txtRelationName.Location = new System.Drawing.Point(528, 219);
            this.txtRelationName.Name = "txtRelationName";
            this.txtRelationName.Size = new System.Drawing.Size(102, 21);
            this.txtRelationName.TabIndex = 34;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(314, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 35;
            this.label13.Text = "职业：";
            // 
            // cboCreer
            // 
            this.cboCreer.FormattingEnabled = true;
            this.cboCreer.Items.AddRange(new object[] {
            "请选择",
            "工人",
            "农民",
            "教师",
            "科研",
            "其他",
            "国家公务员",
            "干部",
            "学生",
            "现役军人",
            "公司职员",
            "记者",
            "作家",
            "演员",
            "运动员",
            "商人",
            "退休",
            "工程师",
            "自由职业",
            "医生",
            "护士",
            "无业人员",
            "离休",
            "个体"});
            this.cboCreer.Location = new System.Drawing.Point(350, 147);
            this.cboCreer.Name = "cboCreer";
            this.cboCreer.Size = new System.Drawing.Size(98, 20);
            this.cboCreer.TabIndex = 37;
            // 
            // frmPatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 406);
            this.Controls.Add(this.cboCreer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtRelationName);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.chbReadonly);
            this.Controls.Add(this.btnStopIll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddIll);
            this.Controls.Add(this.btnStopIn_Danger);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAddIn_Danger);
            this.Controls.Add(this.cbxNurse_Leavel);
            this.Controls.Add(this.lblLeavel);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.cbxIn_Cirs);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxMarred);
            this.Controls.Add(this.cbxShi);
            this.Controls.Add(this.cbxProvince);
            this.Controls.Add(this.txtRelation_Phone);
            this.Controls.Add(this.cbxAge_Unit);
            this.Controls.Add(this.txtOffice_Phone);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.txtHome_Post);
            this.Controls.Add(this.txtAge);
            this.Controls.Add(this.txtOffice_Post);
            this.Controls.Add(this.txtIn_Count);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxRelationship);
            this.Controls.Add(this.lblRelationship);
            this.Controls.Add(this.dtpBirth_Date);
            this.Controls.Add(this.lblNationality);
            this.Controls.Add(this.lblBirth_Date);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.txtDiagnostic);
            this.Controls.Add(this.txtIn_Hospital_Time);
            this.Controls.Add(this.txtAccountAddress);
            this.Controls.Add(this.txtContactAddress);
            this.Controls.Add(this.txtId_Number);
            this.Controls.Add(this.txtWorkAddress);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.cbxNational);
            this.Controls.Add(this.lblNational);
            this.Controls.Add(this.lblDiagnostic);
            this.Controls.Add(this.lblIn_Hospital_Time);
            this.Controls.Add(this.cbxNationality);
            this.Controls.Add(this.lblAccountAddress);
            this.Controls.Add(this.lblId_Number);
            this.Controls.Add(this.lblContactAddress);
            this.Controls.Add(this.cbxSex);
            this.Controls.Add(this.lblWorkAddress);
            this.Controls.Add(this.lblPName);
            this.Controls.Add(this.cbxPay);
            this.Controls.Add(this.lblPay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPatientInfo";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmPatientInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPay;
        private System.Windows.Forms.ComboBox cbxPay;
        private System.Windows.Forms.ComboBox cbxSex;
        private System.Windows.Forms.Label lblPName;
        private System.Windows.Forms.ComboBox cbxNationality;
        private System.Windows.Forms.Label lblId_Number;
        private System.Windows.Forms.ComboBox cbxNational;
        private System.Windows.Forms.Label lblNational;
        private System.Windows.Forms.TextBox txtPName;
        private System.Windows.Forms.TextBox txtId_Number;
        private System.Windows.Forms.Label lblWorkAddress;
        private System.Windows.Forms.Label lblAccountAddress;
        private System.Windows.Forms.TextBox txtWorkAddress;
        private System.Windows.Forms.TextBox txtAccountAddress;
        private System.Windows.Forms.Label lblContactAddress;
        private System.Windows.Forms.Label lblIn_Hospital_Time;
        private System.Windows.Forms.TextBox txtContactAddress;
        private System.Windows.Forms.TextBox txtIn_Hospital_Time;
        private System.Windows.Forms.Label lblDiagnostic;
        private System.Windows.Forms.TextBox txtDiagnostic;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblBirth_Date;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.DateTimePicker dtpBirth_Date;
        private System.Windows.Forms.Label lblRelationship;
        private System.Windows.Forms.ComboBox cbxRelationship;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIn_Count;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOffice_Post;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.ComboBox cbxAge_Unit;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ComboBox cbxMarred;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOffice_Phone;
        private System.Windows.Forms.ComboBox cbxProvince;
        private System.Windows.Forms.ComboBox cbxShi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtHome_Post;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRelation_Phone;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxIn_Cirs;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Label lblLeavel;
        private System.Windows.Forms.ComboBox cbxNurse_Leavel;
        private DevComponents.DotNetBar.ButtonX btnAddIn_Danger;
        private DevComponents.DotNetBar.ButtonX btnAddIll;
        private DevComponents.DotNetBar.ButtonX btnStopIn_Danger;
        private DevComponents.DotNetBar.ButtonX btnStopIll;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.CheckBox chbReadonly;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtRelationName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboCreer;
    }
}