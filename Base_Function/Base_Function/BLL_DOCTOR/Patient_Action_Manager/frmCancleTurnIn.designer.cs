namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    partial class frmCancleTurnIn
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
            this.lblInArea = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPid = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCancle_Time = new System.Windows.Forms.DateTimePicker();
            this.lblOut_Time = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cbxBed = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblToAreaName = new System.Windows.Forms.Label();
            this.lblToSectionName = new System.Windows.Forms.Label();
            this.lblInBed_id = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lblInArea
            // 
            this.lblInArea.AutoSize = true;
            this.lblInArea.Location = new System.Drawing.Point(79, 73);
            this.lblInArea.Name = "lblInArea";
            this.lblInArea.Size = new System.Drawing.Size(11, 12);
            this.lblInArea.TabIndex = 34;
            this.lblInArea.Text = " ";
            // 
            // lblSex
            // 
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(277, 42);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(11, 12);
            this.lblSex.TabIndex = 33;
            this.lblSex.Text = " ";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(78, 42);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(11, 12);
            this.lblAge.TabIndex = 32;
            this.lblAge.Text = " ";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(277, 9);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(11, 12);
            this.lblUserName.TabIndex = 31;
            this.lblUserName.Text = " ";
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.Location = new System.Drawing.Point(78, 9);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(11, 12);
            this.lblPid.TabIndex = 30;
            this.lblPid.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "目前病区：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 25;
            this.label7.Text = "转出时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(219, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "性    别：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "年    龄：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "姓    名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "住 院 号：";
            // 
            // dtpCancle_Time
            // 
            this.dtpCancle_Time.CustomFormat = "yyyy-MM-dd HH:mm";
            this.dtpCancle_Time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCancle_Time.Location = new System.Drawing.Point(80, 169);
            this.dtpCancle_Time.Name = "dtpCancle_Time";
            this.dtpCancle_Time.ShowUpDown = true;
            this.dtpCancle_Time.Size = new System.Drawing.Size(121, 21);
            this.dtpCancle_Time.TabIndex = 38;
            // 
            // lblOut_Time
            // 
            this.lblOut_Time.AutoSize = true;
            this.lblOut_Time.Location = new System.Drawing.Point(78, 139);
            this.lblOut_Time.Name = "lblOut_Time";
            this.lblOut_Time.Size = new System.Drawing.Size(11, 12);
            this.lblOut_Time.TabIndex = 41;
            this.lblOut_Time.Text = " ";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(15, 173);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(65, 12);
            this.lblTime.TabIndex = 42;
            this.lblTime.Text = "取消时间：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(219, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 44;
            this.label15.Text = "选择床号：";
            this.label15.Visible = false;
            // 
            // cbxBed
            // 
            this.cbxBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBed.FormattingEnabled = true;
            this.cbxBed.Location = new System.Drawing.Point(279, 136);
            this.cbxBed.Name = "cbxBed";
            this.cbxBed.Size = new System.Drawing.Size(57, 20);
            this.cbxBed.TabIndex = 45;
            this.cbxBed.Visible = false;
            //this.cbxBed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbxBed_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "退往科别：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "退往病区：";
            // 
            // lblToAreaName
            // 
            this.lblToAreaName.AutoSize = true;
            this.lblToAreaName.Location = new System.Drawing.Point(277, 106);
            this.lblToAreaName.Name = "lblToAreaName";
            this.lblToAreaName.Size = new System.Drawing.Size(11, 12);
            this.lblToAreaName.TabIndex = 40;
            this.lblToAreaName.Text = " ";
            // 
            // lblToSectionName
            // 
            this.lblToSectionName.AutoSize = true;
            this.lblToSectionName.Location = new System.Drawing.Point(78, 106);
            this.lblToSectionName.Name = "lblToSectionName";
            this.lblToSectionName.Size = new System.Drawing.Size(11, 12);
            this.lblToSectionName.TabIndex = 39;
            this.lblToSectionName.Text = " ";
            // 
            // lblInBed_id
            // 
            this.lblInBed_id.AutoSize = true;
            this.lblInBed_id.Location = new System.Drawing.Point(277, 73);
            this.lblInBed_id.Name = "lblInBed_id";
            this.lblInBed_id.Size = new System.Drawing.Size(11, 12);
            this.lblInBed_id.TabIndex = 35;
            this.lblInBed_id.Text = " ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(219, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "目前床号：";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(98, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 46;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(179, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmCancleTurnIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 231);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbxBed);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblOut_Time);
            this.Controls.Add(this.lblToAreaName);
            this.Controls.Add(this.lblToSectionName);
            this.Controls.Add(this.dtpCancle_Time);
            this.Controls.Add(this.lblInBed_id);
            this.Controls.Add(this.lblInArea);
            this.Controls.Add(this.lblSex);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.lblPid);
            this.Controls.Add(this.label9);
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
            this.Name = "frmCancleTurnIn";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " 取消转入";
            this.Load += new System.EventHandler(this.frmCancleSection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInArea;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCancle_Time;
        private System.Windows.Forms.Label lblOut_Time;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbxBed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblToAreaName;
        private System.Windows.Forms.Label lblToSectionName;
        private System.Windows.Forms.Label lblInBed_id;
        private System.Windows.Forms.Label label9;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}