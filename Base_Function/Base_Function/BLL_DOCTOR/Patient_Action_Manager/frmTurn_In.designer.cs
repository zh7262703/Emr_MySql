namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    partial class frmTurn_In
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
            this.cbx_Doctor = new System.Windows.Forms.ComboBox();
            this.cbxBed_Id = new System.Windows.Forms.ComboBox();
            this.lblRollout_Time = new System.Windows.Forms.Label();
            this.lblCurentArea = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPid = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpTurnInTime = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRollout_Area = new System.Windows.Forms.Label();
            this.cbxTng = new System.Windows.Forms.ComboBox();
            this.lblTng = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // cbx_Doctor
            // 
            this.cbx_Doctor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Doctor.FormattingEnabled = true;
            this.cbx_Doctor.Location = new System.Drawing.Point(259, 123);
            this.cbx_Doctor.Name = "cbx_Doctor";
            this.cbx_Doctor.Size = new System.Drawing.Size(108, 20);
            this.cbx_Doctor.TabIndex = 36;
            this.cbx_Doctor.SelectedIndexChanged += new System.EventHandler(this.cbx_Doctor_SelectedIndexChanged);
            this.cbx_Doctor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbx_Doctor_MouseDown);
            // 
            // cbxBed_Id
            // 
            this.cbxBed_Id.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBed_Id.FormattingEnabled = true;
            this.cbxBed_Id.Location = new System.Drawing.Point(75, 122);
            this.cbxBed_Id.Name = "cbxBed_Id";
            this.cbxBed_Id.Size = new System.Drawing.Size(74, 20);
            this.cbxBed_Id.TabIndex = 37;
            // 
            // lblRollout_Time
            // 
            this.lblRollout_Time.AutoSize = true;
            this.lblRollout_Time.Location = new System.Drawing.Point(246, 63);
            this.lblRollout_Time.Name = "lblRollout_Time";
            this.lblRollout_Time.Size = new System.Drawing.Size(11, 12);
            this.lblRollout_Time.TabIndex = 35;
            this.lblRollout_Time.Text = " ";
            // 
            // lblCurentArea
            // 
            this.lblCurentArea.AutoSize = true;
            this.lblCurentArea.Location = new System.Drawing.Point(73, 63);
            this.lblCurentArea.Name = "lblCurentArea";
            this.lblCurentArea.Size = new System.Drawing.Size(11, 12);
            this.lblCurentArea.TabIndex = 34;
            this.lblCurentArea.Text = " ";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(246, 36);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(11, 12);
            this.lblSex.TabIndex = 33;
            this.lblSex.Text = " ";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(73, 36);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(11, 12);
            this.lblAge.TabIndex = 32;
            this.lblAge.Text = " ";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(246, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(11, 12);
            this.lblUserName.TabIndex = 31;
            this.lblUserName.Text = " ";
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.Location = new System.Drawing.Point(73, 9);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(11, 12);
            this.lblPid.TabIndex = 30;
            this.lblPid.Text = " ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(178, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "转出时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "目前病区：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "转入时间：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(188, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "管床医生：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "选择床号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "性    别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "年    龄：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(178, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "姓    名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "住 院 号：";
            // 
            // dtpTurnInTime
            // 
            this.dtpTurnInTime.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpTurnInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTurnInTime.Location = new System.Drawing.Point(75, 153);
            this.dtpTurnInTime.Name = "dtpTurnInTime";
            this.dtpTurnInTime.ShowUpDown = true;
            this.dtpTurnInTime.Size = new System.Drawing.Size(119, 21);
            this.dtpTurnInTime.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 28;
            this.label10.Text = "转    自：";
            // 
            // lblRollout_Area
            // 
            this.lblRollout_Area.AutoSize = true;
            this.lblRollout_Area.Location = new System.Drawing.Point(73, 94);
            this.lblRollout_Area.Name = "lblRollout_Area";
            this.lblRollout_Area.Size = new System.Drawing.Size(47, 12);
            this.lblRollout_Area.TabIndex = 34;
            this.lblRollout_Area.Text = "转   自";
            // 
            // cbxTng
            // 
            this.cbxTng.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTng.FormattingEnabled = true;
            this.cbxTng.Items.AddRange(new object[] {
            "李晓序",
            "欧阳兰兰",
            "刘浇花"});
            this.cbxTng.Location = new System.Drawing.Point(258, 157);
            this.cbxTng.Name = "cbxTng";
            this.cbxTng.Size = new System.Drawing.Size(109, 20);
            this.cbxTng.TabIndex = 40;
            this.cbxTng.Visible = false;
            // 
            // lblTng
            // 
            this.lblTng.AutoSize = true;
            this.lblTng.Location = new System.Drawing.Point(200, 158);
            this.lblTng.Name = "lblTng";
            this.lblTng.Size = new System.Drawing.Size(53, 12);
            this.lblTng.TabIndex = 39;
            this.lblTng.Text = "诊疗组：";
            this.lblTng.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(190, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(109, 185);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 41;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmTurn_In
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 220);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbxTng);
            this.Controls.Add(this.lblTng);
            this.Controls.Add(this.dtpTurnInTime);
            this.Controls.Add(this.cbx_Doctor);
            this.Controls.Add(this.cbxBed_Id);
            this.Controls.Add(this.lblRollout_Time);
            this.Controls.Add(this.lblRollout_Area);
            this.Controls.Add(this.lblCurentArea);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPid);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTurn_In";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病人转入信息";
            this.Load += new System.EventHandler(this.frmTurn_In_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_Doctor;
        private System.Windows.Forms.ComboBox cbxBed_Id;
        private System.Windows.Forms.Label lblRollout_Time;
        private System.Windows.Forms.Label lblCurentArea;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpTurnInTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRollout_Area;
        private System.Windows.Forms.ComboBox cbxTng;
        private System.Windows.Forms.Label lblTng;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
    }
}