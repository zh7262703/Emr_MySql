namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    partial class OperationAccraditation
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.panel5 = new System.Windows.Forms.Panel();
            this.chkLetter_of_consent = new System.Windows.Forms.CheckBox();
            this.chkPostoperation_record = new System.Windows.Forms.CheckBox();
            this.chkOperation_record = new System.Windows.Forms.CheckBox();
            this.chkOperation_discussion = new System.Windows.Forms.CheckBox();
            this.chkOperation_summary = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rdtnNO = new System.Windows.Forms.RadioButton();
            this.rdtnYES = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(534, 21);
            this.textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 27);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手术审批是否需要系统自动判断：";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(42, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(536, 197);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(271, 168);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(53, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(210, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "确定";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.chkLetter_of_consent);
            this.panel5.Controls.Add(this.chkPostoperation_record);
            this.panel5.Controls.Add(this.chkOperation_record);
            this.panel5.Controls.Add(this.chkOperation_discussion);
            this.panel5.Controls.Add(this.chkOperation_summary);
            this.panel5.Location = new System.Drawing.Point(275, 44);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(259, 119);
            this.panel5.TabIndex = 2;
            // 
            // chkLetter_of_consent
            // 
            this.chkLetter_of_consent.AutoSize = true;
            this.chkLetter_of_consent.Location = new System.Drawing.Point(18, 96);
            this.chkLetter_of_consent.Name = "chkLetter_of_consent";
            this.chkLetter_of_consent.Size = new System.Drawing.Size(60, 16);
            this.chkLetter_of_consent.TabIndex = 4;
            this.chkLetter_of_consent.Text = "同意书";
            this.chkLetter_of_consent.UseVisualStyleBackColor = true;
            // 
            // chkPostoperation_record
            // 
            this.chkPostoperation_record.AutoSize = true;
            this.chkPostoperation_record.Location = new System.Drawing.Point(18, 74);
            this.chkPostoperation_record.Name = "chkPostoperation_record";
            this.chkPostoperation_record.Size = new System.Drawing.Size(72, 16);
            this.chkPostoperation_record.TabIndex = 3;
            this.chkPostoperation_record.Text = "术后记录";
            this.chkPostoperation_record.UseVisualStyleBackColor = true;
            // 
            // chkOperation_record
            // 
            this.chkOperation_record.AutoSize = true;
            this.chkOperation_record.Location = new System.Drawing.Point(18, 52);
            this.chkOperation_record.Name = "chkOperation_record";
            this.chkOperation_record.Size = new System.Drawing.Size(72, 16);
            this.chkOperation_record.TabIndex = 2;
            this.chkOperation_record.Text = "手术记录";
            this.chkOperation_record.UseVisualStyleBackColor = true;
            // 
            // chkOperation_discussion
            // 
            this.chkOperation_discussion.AutoSize = true;
            this.chkOperation_discussion.Location = new System.Drawing.Point(18, 30);
            this.chkOperation_discussion.Name = "chkOperation_discussion";
            this.chkOperation_discussion.Size = new System.Drawing.Size(96, 16);
            this.chkOperation_discussion.TabIndex = 1;
            this.chkOperation_discussion.Text = "术前讨论记录";
            this.chkOperation_discussion.UseVisualStyleBackColor = true;
            // 
            // chkOperation_summary
            // 
            this.chkOperation_summary.AutoSize = true;
            this.chkOperation_summary.Location = new System.Drawing.Point(18, 8);
            this.chkOperation_summary.Name = "chkOperation_summary";
            this.chkOperation_summary.Size = new System.Drawing.Size(72, 16);
            this.chkOperation_summary.TabIndex = 0;
            this.chkOperation_summary.Text = "术前小结";
            this.chkOperation_summary.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(0, 44);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(278, 119);
            this.panel4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "未通过审批的手术禁止书写的文书：";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.rdtnNO);
            this.panel3.Controls.Add(this.rdtnYES);
            this.panel3.Location = new System.Drawing.Point(275, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(259, 27);
            this.panel3.TabIndex = 2;
            // 
            // rdtnNO
            // 
            this.rdtnNO.AutoSize = true;
            this.rdtnNO.Location = new System.Drawing.Point(70, 5);
            this.rdtnNO.Name = "rdtnNO";
            this.rdtnNO.Size = new System.Drawing.Size(35, 16);
            this.rdtnNO.TabIndex = 1;
            this.rdtnNO.Text = "否";
            this.rdtnNO.UseVisualStyleBackColor = true;
            // 
            // rdtnYES
            // 
            this.rdtnYES.AutoSize = true;
            this.rdtnYES.Checked = true;
            this.rdtnYES.Location = new System.Drawing.Point(18, 6);
            this.rdtnYES.Name = "rdtnYES";
            this.rdtnYES.Size = new System.Drawing.Size(35, 16);
            this.rdtnYES.TabIndex = 0;
            this.rdtnYES.TabStop = true;
            this.rdtnYES.Text = "是";
            this.rdtnYES.UseVisualStyleBackColor = true;
            // 
            // OperationAccraditation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.panel2);
            this.Name = "OperationAccraditation";
            this.Size = new System.Drawing.Size(707, 238);
            this.Load += new System.EventHandler(this.OperationAccraditation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkLetter_of_consent;
        private System.Windows.Forms.CheckBox chkPostoperation_record;
        private System.Windows.Forms.CheckBox chkOperation_record;
        private System.Windows.Forms.CheckBox chkOperation_discussion;
        private System.Windows.Forms.CheckBox chkOperation_summary;
        private System.Windows.Forms.RadioButton rdtnNO;
        private System.Windows.Forms.RadioButton rdtnYES;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnSave;

    }
}
