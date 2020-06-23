namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    partial class FrmApply_Medical_Record_Room
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
            this.txtApption = new System.Windows.Forms.TextBox();
            this.txtPIDS = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpApply = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSecton_or_Sick = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboState = new System.Windows.Forms.ComboBox();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnCancle = new DevComponents.DotNetBar.ButtonX();
            this.txtApplyReason = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBORROW_FAILURE_TIME = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "申请人：";
            // 
            // txtApption
            // 
            this.txtApption.BackColor = System.Drawing.Color.White;
            this.txtApption.Enabled = false;
            this.txtApption.Location = new System.Drawing.Point(93, 44);
            this.txtApption.Name = "txtApption";
            this.txtApption.ReadOnly = true;
            this.txtApption.Size = new System.Drawing.Size(151, 21);
            this.txtApption.TabIndex = 2;
            // 
            // txtPIDS
            // 
            this.txtPIDS.BackColor = System.Drawing.Color.White;
            this.txtPIDS.Enabled = false;
            this.txtPIDS.Location = new System.Drawing.Point(93, 14);
            this.txtPIDS.Name = "txtPIDS";
            this.txtPIDS.Size = new System.Drawing.Size(151, 21);
            this.txtPIDS.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "申请病历号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "申请时间：";
            // 
            // dtpApply
            // 
            this.dtpApply.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpApply.Enabled = false;
            this.dtpApply.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpApply.Location = new System.Drawing.Point(93, 74);
            this.dtpApply.Name = "dtpApply";
            this.dtpApply.Size = new System.Drawing.Size(151, 21);
            this.dtpApply.TabIndex = 6;
            this.dtpApply.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "科室：";
            // 
            // txtSecton_or_Sick
            // 
            this.txtSecton_or_Sick.BackColor = System.Drawing.Color.White;
            this.txtSecton_or_Sick.Enabled = false;
            this.txtSecton_or_Sick.Location = new System.Drawing.Point(93, 202);
            this.txtSecton_or_Sick.Name = "txtSecton_or_Sick";
            this.txtSecton_or_Sick.Size = new System.Drawing.Size(151, 21);
            this.txtSecton_or_Sick.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "审核状态：";
            // 
            // cboState
            // 
            this.cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboState.FormattingEnabled = true;
            this.cboState.Items.AddRange(new object[] {
            "通过",
            "未通过"});
            this.cboState.Location = new System.Drawing.Point(93, 232);
            this.cboState.Name = "cboState";
            this.cboState.Size = new System.Drawing.Size(151, 20);
            this.cboState.TabIndex = 10;
            this.cboState.SelectedIndexChanged += new System.EventHandler(this.cboState_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(93, 291);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(66, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "提交";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancle.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancle.Location = new System.Drawing.Point(167, 291);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(66, 23);
            this.btnCancle.TabIndex = 12;
            this.btnCancle.Text = "取消";
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // txtApplyReason
            // 
            this.txtApplyReason.BackColor = System.Drawing.Color.White;
            this.txtApplyReason.Location = new System.Drawing.Point(93, 104);
            this.txtApplyReason.Multiline = true;
            this.txtApplyReason.Name = "txtApplyReason";
            this.txtApplyReason.ReadOnly = true;
            this.txtApplyReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtApplyReason.Size = new System.Drawing.Size(304, 89);
            this.txtApplyReason.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "申请理由：";
            // 
            // txtBORROW_FAILURE_TIME
            // 
            this.txtBORROW_FAILURE_TIME.BackColor = System.Drawing.Color.White;
            this.txtBORROW_FAILURE_TIME.Location = new System.Drawing.Point(93, 261);
            this.txtBORROW_FAILURE_TIME.MaxLength = 3;
            this.txtBORROW_FAILURE_TIME.Name = "txtBORROW_FAILURE_TIME";
            this.txtBORROW_FAILURE_TIME.Size = new System.Drawing.Size(66, 21);
            this.txtBORROW_FAILURE_TIME.TabIndex = 16;
            this.txtBORROW_FAILURE_TIME.Text = "3";
            this.txtBORROW_FAILURE_TIME.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBoxInputNumber_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "失效时间：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 265);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "天";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(188, 265);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(209, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "(有效天数必须大于0,并且不能为小数)";
            // 
            // FrmApply_Medical_Record_Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 326);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBORROW_FAILURE_TIME);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtApplyReason);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboState);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSecton_or_Sick);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpApply);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPIDS);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApption);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmApply_Medical_Record_Room";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病历申请审核";
            this.Load += new System.EventHandler(this.FrmApply_Medical_Record_Room_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtApption;
        private System.Windows.Forms.TextBox txtPIDS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpApply;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSecton_or_Sick;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboState;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnCancle;
        private System.Windows.Forms.TextBox txtApplyReason;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBORROW_FAILURE_TIME;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}