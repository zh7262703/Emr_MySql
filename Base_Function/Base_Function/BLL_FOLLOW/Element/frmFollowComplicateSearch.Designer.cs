namespace Base_Function.BLL_FOLLOW.Element
{
    partial class frmFollowComplicateSearch
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
            this.rtnSelectState = new DevComponents.DotNetBar.ButtonX();
            this.txtState = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHospital = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbSection = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label12 = new System.Windows.Forms.Label();
            this.ckBoxLeave = new System.Windows.Forms.CheckBox();
            this.dtLeaveTimeE = new System.Windows.Forms.DateTimePicker();
            this.dtLeaveTimeS = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.ckBoxOutOfDate = new System.Windows.Forms.CheckBox();
            this.dtOutOfDateTimeE = new System.Windows.Forms.DateTimePicker();
            this.dtOutOfDateTimeS = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.ckBoxNext = new System.Windows.Forms.CheckBox();
            this.dtNextTimeE = new System.Windows.Forms.DateTimePicker();
            this.dtNextTimeS = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ckBoxActual = new System.Windows.Forms.CheckBox();
            this.dtActualTimeE = new System.Windows.Forms.DateTimePicker();
            this.dtActualTimeS = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVisitor = new System.Windows.Forms.TextBox();
            this.ckBoxLatest = new System.Windows.Forms.CheckBox();
            this.btnICD10 = new DevComponents.DotNetBar.ButtonX();
            this.btnICD9 = new DevComponents.DotNetBar.ButtonX();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbtnFinish = new System.Windows.Forms.RadioButton();
            this.rbtnOutOfDate = new System.Windows.Forms.RadioButton();
            this.ucICD9 = new Base_Function.BLL_FOLLOW.Element.ucTextBox();
            this.ucICD10 = new Base_Function.BLL_FOLLOW.Element.ucTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtnSelectState
            // 
            this.rtnSelectState.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.rtnSelectState.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.rtnSelectState.Location = new System.Drawing.Point(198, 18);
            this.rtnSelectState.Name = "rtnSelectState";
            this.rtnSelectState.Size = new System.Drawing.Size(39, 24);
            this.rtnSelectState.TabIndex = 30;
            this.rtnSelectState.Text = "...";
            this.rtnSelectState.Click += new System.EventHandler(this.rtnSelectState_Click);
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(78, 12);
            this.txtState.Multiline = true;
            this.txtState.Name = "txtState";
            this.txtState.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtState.Size = new System.Drawing.Size(100, 38);
            this.txtState.TabIndex = 29;
            this.txtState.WordWrap = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 28;
            this.label11.Text = "随访状态：";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(311, 67);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(100, 21);
            this.txtPatientName.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 31;
            this.label2.Text = "患者姓名：";
            // 
            // txtHospital
            // 
            this.txtHospital.Location = new System.Drawing.Point(510, 18);
            this.txtHospital.Name = "txtHospital";
            this.txtHospital.Size = new System.Drawing.Size(100, 21);
            this.txtHospital.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(451, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 33;
            this.label7.Text = "住院号：";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(78, 67);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(100, 21);
            this.txtDoctor.TabIndex = 36;
            this.txtDoctor.TextChanged += new System.EventHandler(this.txtDoctor_TextChanged);
            this.txtDoctor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyUp);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 35;
            this.label8.Text = "管床医生：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 38;
            this.label9.Text = "科室：";
            // 
            // cmbSection
            // 
            this.cmbSection.DisplayMember = "Text";
            this.cmbSection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.ItemHeight = 15;
            this.cmbSection.Location = new System.Drawing.Point(304, 18);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(121, 21);
            this.cmbSection.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(31, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 39;
            this.label12.Text = "诊断：";
            // 
            // ckBoxLeave
            // 
            this.ckBoxLeave.AutoSize = true;
            this.ckBoxLeave.Location = new System.Drawing.Point(13, 264);
            this.ckBoxLeave.Name = "ckBoxLeave";
            this.ckBoxLeave.Size = new System.Drawing.Size(84, 16);
            this.ckBoxLeave.TabIndex = 48;
            this.ckBoxLeave.Text = "出院时间：";
            this.ckBoxLeave.UseVisualStyleBackColor = true;
            // 
            // dtLeaveTimeE
            // 
            this.dtLeaveTimeE.Location = new System.Drawing.Point(264, 259);
            this.dtLeaveTimeE.Name = "dtLeaveTimeE";
            this.dtLeaveTimeE.Size = new System.Drawing.Size(121, 21);
            this.dtLeaveTimeE.TabIndex = 47;
            // 
            // dtLeaveTimeS
            // 
            this.dtLeaveTimeS.Location = new System.Drawing.Point(120, 259);
            this.dtLeaveTimeS.Name = "dtLeaveTimeS";
            this.dtLeaveTimeS.Size = new System.Drawing.Size(121, 21);
            this.dtLeaveTimeS.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(244, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 45;
            this.label5.Text = "-";
            // 
            // ckBoxOutOfDate
            // 
            this.ckBoxOutOfDate.AutoSize = true;
            this.ckBoxOutOfDate.Location = new System.Drawing.Point(13, 225);
            this.ckBoxOutOfDate.Name = "ckBoxOutOfDate";
            this.ckBoxOutOfDate.Size = new System.Drawing.Size(108, 16);
            this.ckBoxOutOfDate.TabIndex = 44;
            this.ckBoxOutOfDate.Text = "逾期随访时间：";
            this.ckBoxOutOfDate.UseVisualStyleBackColor = true;
            // 
            // dtOutOfDateTimeE
            // 
            this.dtOutOfDateTimeE.Location = new System.Drawing.Point(264, 220);
            this.dtOutOfDateTimeE.Name = "dtOutOfDateTimeE";
            this.dtOutOfDateTimeE.Size = new System.Drawing.Size(121, 21);
            this.dtOutOfDateTimeE.TabIndex = 43;
            // 
            // dtOutOfDateTimeS
            // 
            this.dtOutOfDateTimeS.Location = new System.Drawing.Point(120, 220);
            this.dtOutOfDateTimeS.Name = "dtOutOfDateTimeS";
            this.dtOutOfDateTimeS.Size = new System.Drawing.Size(121, 21);
            this.dtOutOfDateTimeS.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(11, 12);
            this.label6.TabIndex = 41;
            this.label6.Text = "-";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(230, 329);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 36);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Location = new System.Drawing.Point(350, 329);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 36);
            this.btnClear.TabIndex = 50;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ckBoxNext
            // 
            this.ckBoxNext.AutoSize = true;
            this.ckBoxNext.Location = new System.Drawing.Point(13, 187);
            this.ckBoxNext.Name = "ckBoxNext";
            this.ckBoxNext.Size = new System.Drawing.Size(108, 16);
            this.ckBoxNext.TabIndex = 58;
            this.ckBoxNext.Text = "下次随访时间：";
            this.ckBoxNext.UseVisualStyleBackColor = true;
            // 
            // dtNextTimeE
            // 
            this.dtNextTimeE.Location = new System.Drawing.Point(264, 182);
            this.dtNextTimeE.Name = "dtNextTimeE";
            this.dtNextTimeE.Size = new System.Drawing.Size(121, 21);
            this.dtNextTimeE.TabIndex = 57;
            // 
            // dtNextTimeS
            // 
            this.dtNextTimeS.Location = new System.Drawing.Point(120, 182);
            this.dtNextTimeS.Name = "dtNextTimeS";
            this.dtNextTimeS.Size = new System.Drawing.Size(121, 21);
            this.dtNextTimeS.TabIndex = 56;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 55;
            this.label1.Text = "-";
            // 
            // ckBoxActual
            // 
            this.ckBoxActual.AutoSize = true;
            this.ckBoxActual.Location = new System.Drawing.Point(13, 148);
            this.ckBoxActual.Name = "ckBoxActual";
            this.ckBoxActual.Size = new System.Drawing.Size(108, 16);
            this.ckBoxActual.TabIndex = 54;
            this.ckBoxActual.Text = "实际随访时间：";
            this.ckBoxActual.UseVisualStyleBackColor = true;
            // 
            // dtActualTimeE
            // 
            this.dtActualTimeE.Location = new System.Drawing.Point(264, 143);
            this.dtActualTimeE.Name = "dtActualTimeE";
            this.dtActualTimeE.Size = new System.Drawing.Size(121, 21);
            this.dtActualTimeE.TabIndex = 53;
            // 
            // dtActualTimeS
            // 
            this.dtActualTimeS.Location = new System.Drawing.Point(120, 143);
            this.dtActualTimeS.Name = "dtActualTimeS";
            this.dtActualTimeS.Size = new System.Drawing.Size(121, 21);
            this.dtActualTimeS.TabIndex = 52;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 12);
            this.label3.TabIndex = 51;
            this.label3.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(451, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 59;
            this.label4.Text = "随访者：";
            // 
            // txtVisitor
            // 
            this.txtVisitor.Location = new System.Drawing.Point(510, 67);
            this.txtVisitor.Name = "txtVisitor";
            this.txtVisitor.Size = new System.Drawing.Size(100, 21);
            this.txtVisitor.TabIndex = 60;
            this.txtVisitor.TextChanged += new System.EventHandler(this.txtVisitor_TextChanged);
            this.txtVisitor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtVisitor_KeyUp);
            // 
            // ckBoxLatest
            // 
            this.ckBoxLatest.AutoSize = true;
            this.ckBoxLatest.Location = new System.Drawing.Point(12, 302);
            this.ckBoxLatest.Name = "ckBoxLatest";
            this.ckBoxLatest.Size = new System.Drawing.Size(180, 16);
            this.ckBoxLatest.TabIndex = 61;
            this.ckBoxLatest.Text = "仅从每次随访最终状态中筛选";
            this.ckBoxLatest.UseVisualStyleBackColor = true;
            // 
            // btnICD10
            // 
            this.btnICD10.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnICD10.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnICD10.Location = new System.Drawing.Point(281, 108);
            this.btnICD10.Name = "btnICD10";
            this.btnICD10.Size = new System.Drawing.Size(40, 23);
            this.btnICD10.TabIndex = 65;
            this.btnICD10.Text = "...";
            this.btnICD10.Click += new System.EventHandler(this.btnICD10_Click);
            // 
            // btnICD9
            // 
            this.btnICD9.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnICD9.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnICD9.Location = new System.Drawing.Point(586, 108);
            this.btnICD9.Name = "btnICD9";
            this.btnICD9.Size = new System.Drawing.Size(41, 23);
            this.btnICD9.TabIndex = 67;
            this.btnICD9.Text = "...";
            this.btnICD9.Click += new System.EventHandler(this.btnICD9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(340, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 68;
            this.label10.Text = "手术：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbtnFinish);
            this.panel1.Controls.Add(this.rbtnOutOfDate);
            this.panel1.Location = new System.Drawing.Point(230, 291);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(169, 32);
            this.panel1.TabIndex = 69;
            // 
            // rbtnFinish
            // 
            this.rbtnFinish.AutoSize = true;
            this.rbtnFinish.Location = new System.Drawing.Point(92, 8);
            this.rbtnFinish.Name = "rbtnFinish";
            this.rbtnFinish.Size = new System.Drawing.Size(71, 16);
            this.rbtnFinish.TabIndex = 70;
            this.rbtnFinish.Text = "随访完成";
            this.rbtnFinish.UseVisualStyleBackColor = true;
            // 
            // rbtnOutOfDate
            // 
            this.rbtnOutOfDate.AutoSize = true;
            this.rbtnOutOfDate.Checked = true;
            this.rbtnOutOfDate.Location = new System.Drawing.Point(5, 8);
            this.rbtnOutOfDate.Name = "rbtnOutOfDate";
            this.rbtnOutOfDate.Size = new System.Drawing.Size(71, 16);
            this.rbtnOutOfDate.TabIndex = 0;
            this.rbtnOutOfDate.TabStop = true;
            this.rbtnOutOfDate.Text = "逾期随访";
            this.rbtnOutOfDate.UseVisualStyleBackColor = true;
            // 
            // ucICD9
            // 
            this.ucICD9.BackColor = System.Drawing.Color.White;
            this.ucICD9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucICD9.Location = new System.Drawing.Point(384, 106);
            this.ucICD9.Name = "ucICD9";
            this.ucICD9.Size = new System.Drawing.Size(196, 25);
            this.ucICD9.TabIndex = 66;
            // 
            // ucICD10
            // 
            this.ucICD10.BackColor = System.Drawing.Color.White;
            this.ucICD10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucICD10.Location = new System.Drawing.Point(78, 106);
            this.ucICD10.Name = "ucICD10";
            this.ucICD10.Size = new System.Drawing.Size(187, 25);
            this.ucICD10.TabIndex = 64;
            // 
            // frmFollowComplicateSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 366);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ucICD9);
            this.Controls.Add(this.btnICD9);
            this.Controls.Add(this.ucICD10);
            this.Controls.Add(this.btnICD10);
            this.Controls.Add(this.ckBoxLatest);
            this.Controls.Add(this.txtVisitor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ckBoxNext);
            this.Controls.Add(this.dtNextTimeE);
            this.Controls.Add(this.dtNextTimeS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckBoxActual);
            this.Controls.Add(this.dtActualTimeE);
            this.Controls.Add(this.dtActualTimeS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.ckBoxLeave);
            this.Controls.Add(this.dtLeaveTimeE);
            this.Controls.Add(this.dtLeaveTimeS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ckBoxOutOfDate);
            this.Controls.Add(this.dtOutOfDateTimeE);
            this.Controls.Add(this.dtOutOfDateTimeS);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbSection);
            this.Controls.Add(this.txtDoctor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtHospital);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rtnSelectState);
            this.Controls.Add(this.txtState);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFollowComplicateSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "多条件查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX rtnSelectState;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHospital;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSection;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox ckBoxLeave;
        private System.Windows.Forms.DateTimePicker dtLeaveTimeE;
        private System.Windows.Forms.DateTimePicker dtLeaveTimeS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ckBoxOutOfDate;
        private System.Windows.Forms.DateTimePicker dtOutOfDateTimeE;
        private System.Windows.Forms.DateTimePicker dtOutOfDateTimeS;
        private System.Windows.Forms.Label label6;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private System.Windows.Forms.CheckBox ckBoxNext;
        private System.Windows.Forms.DateTimePicker dtNextTimeE;
        private System.Windows.Forms.DateTimePicker dtNextTimeS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckBoxActual;
        private System.Windows.Forms.DateTimePicker dtActualTimeE;
        private System.Windows.Forms.DateTimePicker dtActualTimeS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVisitor;
        private System.Windows.Forms.CheckBox ckBoxLatest;
        private ucTextBox ucICD10;
        private DevComponents.DotNetBar.ButtonX btnICD10;
        private ucTextBox ucICD9;
        private DevComponents.DotNetBar.ButtonX btnICD9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnFinish;
        private System.Windows.Forms.RadioButton rbtnOutOfDate;
    }
}