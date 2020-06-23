namespace Digital_Medical_Treatment.A_Discussion
{
    partial class frmAddDiscussion
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
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lnklblDiagnose = new System.Windows.Forms.LinkLabel();
            this.rtxtDiagnose = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDisscussDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDoctorName = new System.Windows.Forms.Label();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.dgvSameNamePatient = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bedno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HIS_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSameNamePatient)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(246, 4);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(83, 21);
            this.txtPatientID.TabIndex = 11;
            this.txtPatientID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientID_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(193, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "住院号：";
            // 
            // txtPatientName
            // 
            this.txtPatientName.Location = new System.Drawing.Point(76, 4);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(83, 21);
            this.txtPatientName.TabIndex = 9;
            this.txtPatientName.TextChanged += new System.EventHandler(this.txtPatientName_TextChanged);
            this.txtPatientName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPatientName_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "患者姓名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(373, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "性别：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(502, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "年龄：";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.BackColor = System.Drawing.Color.Transparent;
            this.lblSex.Location = new System.Drawing.Point(420, 8);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(0, 12);
            this.lblSex.TabIndex = 14;
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.BackColor = System.Drawing.Color.Transparent;
            this.lblAge.Location = new System.Drawing.Point(549, 8);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(0, 12);
            this.lblAge.TabIndex = 15;
            // 
            // lnklblDiagnose
            // 
            this.lnklblDiagnose.AutoSize = true;
            this.lnklblDiagnose.Location = new System.Drawing.Point(9, 38);
            this.lnklblDiagnose.Name = "lnklblDiagnose";
            this.lnklblDiagnose.Size = new System.Drawing.Size(41, 12);
            this.lnklblDiagnose.TabIndex = 16;
            this.lnklblDiagnose.TabStop = true;
            this.lnklblDiagnose.Text = "诊断：";
            this.lnklblDiagnose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblDiagnose_LinkClicked);
            // 
            // rtxtDiagnose
            // 
            this.rtxtDiagnose.Location = new System.Drawing.Point(76, 38);
            this.rtxtDiagnose.Name = "rtxtDiagnose";
            this.rtxtDiagnose.ReadOnly = true;
            this.rtxtDiagnose.Size = new System.Drawing.Size(567, 111);
            this.rtxtDiagnose.TabIndex = 17;
            this.rtxtDiagnose.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(9, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "讨论时间：";
            // 
            // dtpDisscussDate
            // 
            this.dtpDisscussDate.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpDisscussDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDisscussDate.Location = new System.Drawing.Point(76, 159);
            this.dtpDisscussDate.Name = "dtpDisscussDate";
            this.dtpDisscussDate.ShowUpDown = true;
            this.dtpDisscussDate.Size = new System.Drawing.Size(125, 21);
            this.dtpDisscussDate.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(9, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "创建者：";
            // 
            // lblDoctorName
            // 
            this.lblDoctorName.AutoSize = true;
            this.lblDoctorName.BackColor = System.Drawing.Color.Transparent;
            this.lblDoctorName.Location = new System.Drawing.Point(74, 198);
            this.lblDoctorName.Name = "lblDoctorName";
            this.lblDoctorName.Size = new System.Drawing.Size(89, 12);
            this.lblDoctorName.TabIndex = 21;
            this.lblDoctorName.Text = "当前申请人姓名";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(358, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(451, 216);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dgvSameNamePatient
            // 
            this.dgvSameNamePatient.AllowUserToAddRows = false;
            this.dgvSameNamePatient.AllowUserToDeleteRows = false;
            this.dgvSameNamePatient.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSameNamePatient.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvSameNamePatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSameNamePatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.ID,
            this.bedno,
            this.intime,
            this.sex,
            this.age,
            this.HIS_ID});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSameNamePatient.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSameNamePatient.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvSameNamePatient.Location = new System.Drawing.Point(76, 30);
            this.dgvSameNamePatient.Name = "dgvSameNamePatient";
            this.dgvSameNamePatient.RowHeadersVisible = false;
            this.dgvSameNamePatient.RowTemplate.Height = 23;
            this.dgvSameNamePatient.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSameNamePatient.Size = new System.Drawing.Size(524, 150);
            this.dgvSameNamePatient.TabIndex = 24;
            this.dgvSameNamePatient.Visible = false;
            this.dgvSameNamePatient.DoubleClick += new System.EventHandler(this.dgvSameNamePatient_DoubleClick);
            // 
            // name
            // 
            this.name.HeaderText = "患者姓名";
            this.name.Name = "name";
            // 
            // ID
            // 
            this.ID.HeaderText = "住院号";
            this.ID.Name = "ID";
            // 
            // bedno
            // 
            this.bedno.HeaderText = "床号";
            this.bedno.Name = "bedno";
            this.bedno.Width = 70;
            // 
            // intime
            // 
            this.intime.HeaderText = "住院日期";
            this.intime.Name = "intime";
            this.intime.Width = 110;
            // 
            // sex
            // 
            this.sex.HeaderText = "性别";
            this.sex.Name = "sex";
            this.sex.Width = 70;
            // 
            // age
            // 
            this.age.HeaderText = "年龄";
            this.age.Name = "age";
            this.age.Width = 70;
            // 
            // HIS_ID
            // 
            this.HIS_ID.HeaderText = "病人号";
            this.HIS_ID.Name = "HIS_ID";
            this.HIS_ID.Visible = false;
            // 
            // frmAddDiscussion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 251);
            this.Controls.Add(this.dgvSameNamePatient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblDoctorName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpDisscussDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rtxtDiagnose);
            this.Controls.Add(this.lnklblDiagnose);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPatientID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmAddDiscussion";
            this.Load += new System.EventHandler(this.frmAddDiscussion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSameNamePatient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPatientID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.LinkLabel lnklblDiagnose;
        private System.Windows.Forms.RichTextBox rtxtDiagnose;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDisscussDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDoctorName;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvSameNamePatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn bedno;
        private System.Windows.Forms.DataGridViewTextBoxColumn intime;
        private System.Windows.Forms.DataGridViewTextBoxColumn sex;
        private System.Windows.Forms.DataGridViewTextBoxColumn age;
        private System.Windows.Forms.DataGridViewTextBoxColumn HIS_ID;
    }
}