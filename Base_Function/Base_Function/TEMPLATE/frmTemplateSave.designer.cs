namespace Base_Function.TEMPLATE
{
    partial class frmTemplateSave
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
            this.cboTextKind = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cboSicknessKind = new System.Windows.Forms.ComboBox();
            this.cboSys = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtAutoTPName = new System.Windows.Forms.TextBox();
            this.lblDefaultModel = new System.Windows.Forms.Label();
            this.rdbYes = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdoSection = new System.Windows.Forms.RadioButton();
            this.rdoPersonal = new System.Windows.Forms.RadioButton();
            this.rdoHospital = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pnlAge = new System.Windows.Forms.Panel();
            this.rdoOld = new System.Windows.Forms.RadioButton();
            this.rdoMiddle = new System.Windows.Forms.RadioButton();
            this.rdoYouth = new System.Windows.Forms.RadioButton();
            this.rdoLad = new System.Windows.Forms.RadioButton();
            this.rdoEnfant = new System.Windows.Forms.RadioButton();
            this.rdoAgeNull = new System.Windows.Forms.RadioButton();
            this.pnlSex = new System.Windows.Forms.Panel();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoSexNull = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlAge.SuspendLayout();
            this.pnlSex.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboTextKind
            // 
            this.cboTextKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTextKind.Enabled = false;
            this.cboTextKind.FormattingEnabled = true;
            this.cboTextKind.Items.AddRange(new object[] {
            "请选择..."});
            this.cboTextKind.Location = new System.Drawing.Point(177, 105);
            this.cboTextKind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTextKind.Name = "cboTextKind";
            this.cboTextKind.Size = new System.Drawing.Size(202, 25);
            this.cboTextKind.TabIndex = 21;
            this.cboTextKind.SelectedIndexChanged += new System.EventHandler(this.cboTextKind_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "三级目录（模版名称）：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(387, 31);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 21);
            this.checkBox1.TabIndex = 19;
            this.checkBox1.Text = "设为默认选项";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cboSicknessKind
            // 
            this.cboSicknessKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSicknessKind.FormattingEnabled = true;
            this.cboSicknessKind.Items.AddRange(new object[] {
            "请选择..."});
            this.cboSicknessKind.Location = new System.Drawing.Point(177, 68);
            this.cboSicknessKind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSicknessKind.Name = "cboSicknessKind";
            this.cboSicknessKind.Size = new System.Drawing.Size(202, 25);
            this.cboSicknessKind.TabIndex = 18;
            this.cboSicknessKind.SelectedIndexChanged += new System.EventHandler(this.cboSicknessKind_SelectedIndexChanged);
            // 
            // cboSys
            // 
            this.cboSys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSys.FormattingEnabled = true;
            this.cboSys.Location = new System.Drawing.Point(177, 30);
            this.cboSys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSys.Name = "cboSys";
            this.cboSys.Size = new System.Drawing.Size(202, 25);
            this.cboSys.TabIndex = 17;
            this.cboSys.SelectedIndexChanged += new System.EventHandler(this.cboSys_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "二级目录（病 种 类）：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "一级目录（所属系统）：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSicknessKind);
            this.groupBox1.Controls.Add(this.cboTextKind);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cboSys);
            this.groupBox1.Location = new System.Drawing.Point(14, 90);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(506, 152);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "疾病种类";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 334);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "年龄段：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "诊断：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 380);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 27;
            this.label6.Text = "性别：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 29;
            this.label7.Text = "日期：";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.Location = new System.Drawing.Point(168, 466);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 33);
            this.btnOK.TabIndex = 30;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.Location = new System.Drawing.Point(266, 466);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 33);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 261);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "自动生成模版名称：";
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(80, 424);
            this.dtpTime.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(132, 23);
            this.dtpTime.TabIndex = 33;
            // 
            // txtAutoTPName
            // 
            this.txtAutoTPName.Location = new System.Drawing.Point(153, 256);
            this.txtAutoTPName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAutoTPName.Name = "txtAutoTPName";
            this.txtAutoTPName.Size = new System.Drawing.Size(360, 23);
            this.txtAutoTPName.TabIndex = 34;
            // 
            // lblDefaultModel
            // 
            this.lblDefaultModel.AutoSize = true;
            this.lblDefaultModel.Location = new System.Drawing.Point(248, 427);
            this.lblDefaultModel.Name = "lblDefaultModel";
            this.lblDefaultModel.Size = new System.Drawing.Size(68, 17);
            this.lblDefaultModel.TabIndex = 35;
            this.lblDefaultModel.Text = "默认模板：";
            // 
            // rdbYes
            // 
            this.rdbYes.AutoSize = true;
            this.rdbYes.Location = new System.Drawing.Point(5, 3);
            this.rdbYes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbYes.Name = "rdbYes";
            this.rdbYes.Size = new System.Drawing.Size(38, 21);
            this.rdbYes.TabIndex = 36;
            this.rdbYes.Text = "是";
            this.rdbYes.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbNo);
            this.panel1.Controls.Add(this.rdbYes);
            this.panel1.Location = new System.Drawing.Point(331, 420);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(90, 30);
            this.panel1.TabIndex = 38;
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Checked = true;
            this.rdbNo.Location = new System.Drawing.Point(48, 3);
            this.rdbNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(38, 21);
            this.rdbNo.TabIndex = 37;
            this.rdbNo.TabStop = true;
            this.rdbNo.Text = "否";
            this.rdbNo.UseVisualStyleBackColor = true;
            // 
            // rdoSection
            // 
            this.rdoSection.AutoSize = true;
            this.rdoSection.Location = new System.Drawing.Point(98, 34);
            this.rdoSection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoSection.Name = "rdoSection";
            this.rdoSection.Size = new System.Drawing.Size(50, 21);
            this.rdoSection.TabIndex = 13;
            this.rdoSection.Text = "科室";
            this.rdoSection.UseVisualStyleBackColor = true;
            // 
            // rdoPersonal
            // 
            this.rdoPersonal.AutoSize = true;
            this.rdoPersonal.Checked = true;
            this.rdoPersonal.Location = new System.Drawing.Point(21, 34);
            this.rdoPersonal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoPersonal.Name = "rdoPersonal";
            this.rdoPersonal.Size = new System.Drawing.Size(50, 21);
            this.rdoPersonal.TabIndex = 12;
            this.rdoPersonal.TabStop = true;
            this.rdoPersonal.Text = "个人";
            this.rdoPersonal.UseVisualStyleBackColor = true;
            // 
            // rdoHospital
            // 
            this.rdoHospital.AutoSize = true;
            this.rdoHospital.Location = new System.Drawing.Point(177, 34);
            this.rdoHospital.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoHospital.Name = "rdoHospital";
            this.rdoHospital.Size = new System.Drawing.Size(50, 21);
            this.rdoHospital.TabIndex = 14;
            this.rdoHospital.Text = "全院";
            this.rdoHospital.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.rdoHospital);
            this.groupBox2.Controls.Add(this.rdoPersonal);
            this.groupBox2.Controls.Add(this.rdoSection);
            this.groupBox2.Location = new System.Drawing.Point(14, 8);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(506, 70);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "使用范围";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(318, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "test1";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(260, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 17);
            this.label9.TabIndex = 16;
            this.label9.Text = "test";
            this.label9.Visible = false;
            // 
            // pnlAge
            // 
            this.pnlAge.Controls.Add(this.rdoOld);
            this.pnlAge.Controls.Add(this.rdoMiddle);
            this.pnlAge.Controls.Add(this.rdoYouth);
            this.pnlAge.Controls.Add(this.rdoLad);
            this.pnlAge.Controls.Add(this.rdoEnfant);
            this.pnlAge.Controls.Add(this.rdoAgeNull);
            this.pnlAge.Location = new System.Drawing.Point(75, 322);
            this.pnlAge.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlAge.Name = "pnlAge";
            this.pnlAge.Size = new System.Drawing.Size(364, 37);
            this.pnlAge.TabIndex = 39;
            // 
            // rdoOld
            // 
            this.rdoOld.AutoSize = true;
            this.rdoOld.Location = new System.Drawing.Point(301, 8);
            this.rdoOld.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoOld.Name = "rdoOld";
            this.rdoOld.Size = new System.Drawing.Size(50, 21);
            this.rdoOld.TabIndex = 46;
            this.rdoOld.Text = "老年";
            this.rdoOld.UseVisualStyleBackColor = true;
            // 
            // rdoMiddle
            // 
            this.rdoMiddle.AutoSize = true;
            this.rdoMiddle.Location = new System.Drawing.Point(239, 8);
            this.rdoMiddle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoMiddle.Name = "rdoMiddle";
            this.rdoMiddle.Size = new System.Drawing.Size(50, 21);
            this.rdoMiddle.TabIndex = 45;
            this.rdoMiddle.Text = "中年";
            this.rdoMiddle.UseVisualStyleBackColor = true;
            // 
            // rdoYouth
            // 
            this.rdoYouth.AutoSize = true;
            this.rdoYouth.Location = new System.Drawing.Point(177, 8);
            this.rdoYouth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoYouth.Name = "rdoYouth";
            this.rdoYouth.Size = new System.Drawing.Size(50, 21);
            this.rdoYouth.TabIndex = 44;
            this.rdoYouth.Text = "青年";
            this.rdoYouth.UseVisualStyleBackColor = true;
            // 
            // rdoLad
            // 
            this.rdoLad.AutoSize = true;
            this.rdoLad.Location = new System.Drawing.Point(115, 8);
            this.rdoLad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoLad.Name = "rdoLad";
            this.rdoLad.Size = new System.Drawing.Size(50, 21);
            this.rdoLad.TabIndex = 43;
            this.rdoLad.Text = "少年";
            this.rdoLad.UseVisualStyleBackColor = true;
            // 
            // rdoEnfant
            // 
            this.rdoEnfant.AutoSize = true;
            this.rdoEnfant.Location = new System.Drawing.Point(54, 8);
            this.rdoEnfant.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoEnfant.Name = "rdoEnfant";
            this.rdoEnfant.Size = new System.Drawing.Size(50, 21);
            this.rdoEnfant.TabIndex = 42;
            this.rdoEnfant.Text = "儿童";
            this.rdoEnfant.UseVisualStyleBackColor = true;
            // 
            // rdoAgeNull
            // 
            this.rdoAgeNull.AutoSize = true;
            this.rdoAgeNull.Checked = true;
            this.rdoAgeNull.Location = new System.Drawing.Point(6, 8);
            this.rdoAgeNull.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoAgeNull.Name = "rdoAgeNull";
            this.rdoAgeNull.Size = new System.Drawing.Size(38, 21);
            this.rdoAgeNull.TabIndex = 41;
            this.rdoAgeNull.TabStop = true;
            this.rdoAgeNull.Text = "无";
            this.rdoAgeNull.UseVisualStyleBackColor = true;
            // 
            // pnlSex
            // 
            this.pnlSex.Controls.Add(this.rdoFemale);
            this.pnlSex.Controls.Add(this.rdoMale);
            this.pnlSex.Controls.Add(this.rdoSexNull);
            this.pnlSex.Location = new System.Drawing.Point(75, 373);
            this.pnlSex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlSex.Name = "pnlSex";
            this.pnlSex.Size = new System.Drawing.Size(320, 37);
            this.pnlSex.TabIndex = 40;
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(101, 4);
            this.rdoFemale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(38, 21);
            this.rdoFemale.TabIndex = 44;
            this.rdoFemale.Text = "女";
            this.rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(54, 4);
            this.rdoMale.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(38, 21);
            this.rdoMale.TabIndex = 43;
            this.rdoMale.Text = "男";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoSexNull
            // 
            this.rdoSexNull.AutoSize = true;
            this.rdoSexNull.Checked = true;
            this.rdoSexNull.Location = new System.Drawing.Point(6, 4);
            this.rdoSexNull.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdoSexNull.Name = "rdoSexNull";
            this.rdoSexNull.Size = new System.Drawing.Size(38, 21);
            this.rdoSexNull.TabIndex = 42;
            this.rdoSexNull.TabStop = true;
            this.rdoSexNull.Text = "无";
            this.rdoSexNull.UseVisualStyleBackColor = true;
            // 
            // frmTemplateSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(534, 509);
            this.Controls.Add(this.pnlSex);
            this.Controls.Add(this.pnlAge);
            this.Controls.Add(this.lblDefaultModel);
            this.Controls.Add(this.txtAutoTPName);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTemplateSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模版保存";
            this.Load += new System.EventHandler(this.frmTemplateSave_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlAge.ResumeLayout(false);
            this.pnlAge.PerformLayout();
            this.pnlSex.ResumeLayout(false);
            this.pnlSex.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTextKind;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cboSicknessKind;
        private System.Windows.Forms.ComboBox cboSys;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.TextBox txtAutoTPName;
        private System.Windows.Forms.Label lblDefaultModel;
        private System.Windows.Forms.RadioButton rdbYes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.RadioButton rdoSection;
        private System.Windows.Forms.RadioButton rdoPersonal;
        private System.Windows.Forms.RadioButton rdoHospital;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlAge;
        private System.Windows.Forms.RadioButton rdoOld;
        private System.Windows.Forms.RadioButton rdoMiddle;
        private System.Windows.Forms.RadioButton rdoYouth;
        private System.Windows.Forms.RadioButton rdoLad;
        private System.Windows.Forms.RadioButton rdoEnfant;
        private System.Windows.Forms.RadioButton rdoAgeNull;
        private System.Windows.Forms.Panel pnlSex;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoSexNull;
    }
}