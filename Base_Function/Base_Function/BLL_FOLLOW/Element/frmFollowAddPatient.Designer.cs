namespace Base_Function.BLL_FOLLOW.Element
{
    partial class frmFollowAddPatient
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbSections = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDoctor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOper = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiag = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtStart = new System.Windows.Forms.DateTimePicker();
            this.ckStartTime = new System.Windows.Forms.CheckBox();
            this.txtHospital = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearch = new DevComponents.DotNetBar.ButtonX();
            this.txtPatient = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPatients = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pnlSet = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.rbtnNo = new System.Windows.Forms.RadioButton();
            this.rbtnYes = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.dgvTimeSet = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtTimeSet = new System.Windows.Forms.DateTimePicker();
            this.rbtnToday = new System.Windows.Forms.RadioButton();
            this.rbtnSetTime = new System.Windows.Forms.RadioButton();
            this.rbtnLeaveHos = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFollowSchema = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlSet.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSet)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "病人姓名：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbSections);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDoctor);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtOper);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDiag);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtEnd);
            this.groupBox1.Controls.Add(this.dtStart);
            this.groupBox1.Controls.Add(this.ckStartTime);
            this.groupBox1.Controls.Add(this.txtHospital);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtPatient);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 75);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "查询条件";
            // 
            // cmbSections
            // 
            this.cmbSections.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSections.FormattingEnabled = true;
            this.cmbSections.Location = new System.Drawing.Point(598, 48);
            this.cmbSections.Name = "cmbSections";
            this.cmbSections.Size = new System.Drawing.Size(77, 20);
            this.cmbSections.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(551, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "科室：";
            // 
            // txtDoctor
            // 
            this.txtDoctor.Location = new System.Drawing.Point(440, 48);
            this.txtDoctor.Name = "txtDoctor";
            this.txtDoctor.Size = new System.Drawing.Size(100, 21);
            this.txtDoctor.TabIndex = 14;
            this.txtDoctor.TextChanged += new System.EventHandler(this.txtDoctor_TextChanged);
            this.txtDoctor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDoctor_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(375, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "管床医生：";
            // 
            // txtOper
            // 
            this.txtOper.Location = new System.Drawing.Point(244, 48);
            this.txtOper.Name = "txtOper";
            this.txtOper.Size = new System.Drawing.Size(100, 21);
            this.txtOper.TabIndex = 12;
            this.txtOper.TextChanged += new System.EventHandler(this.txtOper_TextChanged);
            this.txtOper.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtOper_KeyUp);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "手术：";
            // 
            // txtDiag
            // 
            this.txtDiag.Location = new System.Drawing.Point(82, 48);
            this.txtDiag.Name = "txtDiag";
            this.txtDiag.Size = new System.Drawing.Size(100, 21);
            this.txtDiag.TabIndex = 10;
            this.txtDiag.TextChanged += new System.EventHandler(this.txtDiag_TextChanged);
            this.txtDiag.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDiag_KeyUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "诊断：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(552, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "-";
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(569, 17);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(106, 21);
            this.dtEnd.TabIndex = 7;
            // 
            // dtStart
            // 
            this.dtStart.Location = new System.Drawing.Point(440, 17);
            this.dtStart.Name = "dtStart";
            this.dtStart.Size = new System.Drawing.Size(106, 21);
            this.dtStart.TabIndex = 6;
            // 
            // ckStartTime
            // 
            this.ckStartTime.AutoSize = true;
            this.ckStartTime.Location = new System.Drawing.Point(362, 20);
            this.ckStartTime.Name = "ckStartTime";
            this.ckStartTime.Size = new System.Drawing.Size(84, 16);
            this.ckStartTime.TabIndex = 5;
            this.ckStartTime.Text = "出院时间：";
            this.ckStartTime.UseVisualStyleBackColor = true;
            // 
            // txtHospital
            // 
            this.txtHospital.Location = new System.Drawing.Point(244, 17);
            this.txtHospital.Name = "txtHospital";
            this.txtHospital.Size = new System.Drawing.Size(100, 21);
            this.txtHospital.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "住院号：";
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSearch.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSearch.Location = new System.Drawing.Point(708, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPatient
            // 
            this.txtPatient.Location = new System.Drawing.Point(82, 17);
            this.txtPatient.Name = "txtPatient";
            this.txtPatient.Size = new System.Drawing.Size(100, 21);
            this.txtPatient.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvPatients);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(814, 419);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "病人列表";
            // 
            // dgvPatients
            // 
            this.dgvPatients.AllowUserToAddRows = false;
            this.dgvPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPatients.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPatients.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvPatients.Location = new System.Drawing.Point(3, 17);
            this.dgvPatients.Name = "dgvPatients";
            this.dgvPatients.RowTemplate.Height = 23;
            this.dgvPatients.Size = new System.Drawing.Size(808, 399);
            this.dgvPatients.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1236, 494);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.TabIndex = 5;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pnlSet);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(418, 494);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "新增随访";
            // 
            // pnlSet
            // 
            this.pnlSet.Controls.Add(this.groupBox4);
            this.pnlSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSet.Location = new System.Drawing.Point(3, 69);
            this.pnlSet.Name = "pnlSet";
            this.pnlSet.Size = new System.Drawing.Size(412, 422);
            this.pnlSet.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.panel4);
            this.groupBox4.Controls.Add(this.panel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(412, 422);
            this.groupBox4.TabIndex = 44;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "固定随访时间";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.dgvTimeSet);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 141);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(406, 278);
            this.panel4.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.rbtnNo);
            this.panel5.Controls.Add(this.rbtnYes);
            this.panel5.Location = new System.Drawing.Point(156, 161);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 24);
            this.panel5.TabIndex = 5;
            // 
            // rbtnNo
            // 
            this.rbtnNo.AutoSize = true;
            this.rbtnNo.Checked = true;
            this.rbtnNo.Location = new System.Drawing.Point(58, 5);
            this.rbtnNo.Name = "rbtnNo";
            this.rbtnNo.Size = new System.Drawing.Size(35, 16);
            this.rbtnNo.TabIndex = 1;
            this.rbtnNo.TabStop = true;
            this.rbtnNo.Text = "否";
            this.rbtnNo.UseVisualStyleBackColor = true;
            // 
            // rbtnYes
            // 
            this.rbtnYes.AutoSize = true;
            this.rbtnYes.Location = new System.Drawing.Point(3, 5);
            this.rbtnYes.Name = "rbtnYes";
            this.rbtnYes.Size = new System.Drawing.Size(35, 16);
            this.rbtnYes.TabIndex = 0;
            this.rbtnYes.Text = "是";
            this.rbtnYes.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(43, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "此前随访是否无效:";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(143, 191);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 41);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "确认添加";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvTimeSet
            // 
            this.dgvTimeSet.AllowUserToAddRows = false;
            this.dgvTimeSet.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimeSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvTimeSet.Location = new System.Drawing.Point(0, 0);
            this.dgvTimeSet.Name = "dgvTimeSet";
            this.dgvTimeSet.RowTemplate.Height = 23;
            this.dgvTimeSet.Size = new System.Drawing.Size(406, 155);
            this.dgvTimeSet.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(406, 124);
            this.panel3.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "开始时间：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtTimeSet);
            this.panel2.Controls.Add(this.rbtnToday);
            this.panel2.Controls.Add(this.rbtnSetTime);
            this.panel2.Controls.Add(this.rbtnLeaveHos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(139, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 124);
            this.panel2.TabIndex = 3;
            // 
            // dtTimeSet
            // 
            this.dtTimeSet.Location = new System.Drawing.Point(97, 50);
            this.dtTimeSet.Name = "dtTimeSet";
            this.dtTimeSet.Size = new System.Drawing.Size(109, 21);
            this.dtTimeSet.TabIndex = 3;
            // 
            // rbtnToday
            // 
            this.rbtnToday.AutoSize = true;
            this.rbtnToday.Location = new System.Drawing.Point(4, 92);
            this.rbtnToday.Name = "rbtnToday";
            this.rbtnToday.Size = new System.Drawing.Size(47, 16);
            this.rbtnToday.TabIndex = 2;
            this.rbtnToday.Text = "今日";
            this.rbtnToday.UseVisualStyleBackColor = true;
            // 
            // rbtnSetTime
            // 
            this.rbtnSetTime.AutoSize = true;
            this.rbtnSetTime.Location = new System.Drawing.Point(4, 54);
            this.rbtnSetTime.Name = "rbtnSetTime";
            this.rbtnSetTime.Size = new System.Drawing.Size(71, 16);
            this.rbtnSetTime.TabIndex = 1;
            this.rbtnSetTime.Text = "指定时间";
            this.rbtnSetTime.UseVisualStyleBackColor = true;
            this.rbtnSetTime.CheckedChanged += new System.EventHandler(this.rbtnSetTime_CheckedChanged);
            // 
            // rbtnLeaveHos
            // 
            this.rbtnLeaveHos.AutoSize = true;
            this.rbtnLeaveHos.Checked = true;
            this.rbtnLeaveHos.Location = new System.Drawing.Point(4, 16);
            this.rbtnLeaveHos.Name = "rbtnLeaveHos";
            this.rbtnLeaveHos.Size = new System.Drawing.Size(71, 16);
            this.rbtnLeaveHos.TabIndex = 0;
            this.rbtnLeaveHos.TabStop = true;
            this.rbtnLeaveHos.Text = "出院时间";
            this.rbtnLeaveHos.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbFollowSchema);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 17);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(412, 52);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "随访方案选择：";
            // 
            // cmbFollowSchema
            // 
            this.cmbFollowSchema.FormattingEnabled = true;
            this.cmbFollowSchema.Location = new System.Drawing.Point(117, 17);
            this.cmbFollowSchema.Name = "cmbFollowSchema";
            this.cmbFollowSchema.Size = new System.Drawing.Size(161, 20);
            this.cmbFollowSchema.TabIndex = 0;
            this.cmbFollowSchema.SelectedIndexChanged += new System.EventHandler(this.cmbFollowSchema_SelectedIndexChanged);
            // 
            // frmFollowAddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1236, 494);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmFollowAddPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "加入随访";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.pnlSet.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSet)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.ButtonX btnSearch;
        private System.Windows.Forms.TextBox txtPatient;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvPatients;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel pnlSet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSections;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDoctor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOper;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtStart;
        private System.Windows.Forms.CheckBox ckStartTime;
        private System.Windows.Forms.TextBox txtHospital;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnToday;
        private System.Windows.Forms.RadioButton rbtnSetTime;
        private System.Windows.Forms.RadioButton rbtnLeaveHos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFollowSchema;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.DataGridView dgvTimeSet;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtTimeSet;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton rbtnNo;
        private System.Windows.Forms.RadioButton rbtnYes;
        private System.Windows.Forms.Label label10;
    }
}