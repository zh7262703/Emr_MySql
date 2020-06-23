namespace Digital_Medical_Treatment
{
    partial class frmIllnessDiscussed_Add
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
            this.txtPid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatientName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label2 = new System.Windows.Forms.Label();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.label1 = new System.Windows.Forms.Label();
            this.Txtdiagnose_Name = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.dtTime = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.btnClear = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.txtEditer = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtPid
            // 
            // 
            // 
            // 
            this.txtPid.Border.Class = "TextBoxBorder";
            this.txtPid.Location = new System.Drawing.Point(291, 26);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(111, 21);
            this.txtPid.TabIndex = 11;
            this.txtPid.TextChanged += new System.EventHandler(this.txtPid_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "住院号:";
            // 
            // txtPatientName
            // 
            // 
            // 
            // 
            this.txtPatientName.Border.Class = "TextBoxBorder";
            this.txtPatientName.Location = new System.Drawing.Point(103, 26);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(111, 21);
            this.txtPatientName.TabIndex = 9;
            this.txtPatientName.TextChanged += new System.EventHandler(this.txtPatientName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "患者姓名:";
            // 
            // labelX1
            // 
            this.labelX1.Location = new System.Drawing.Point(431, 29);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(52, 23);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "性别：";
            // 
            // labelX2
            // 
            this.labelX2.Location = new System.Drawing.Point(489, 29);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(52, 23);
            this.labelX2.TabIndex = 13;
            // 
            // labelX3
            // 
            this.labelX3.Location = new System.Drawing.Point(572, 29);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(52, 23);
            this.labelX3.TabIndex = 14;
            this.labelX3.Text = "年龄：";
            // 
            // labelX4
            // 
            this.labelX4.Location = new System.Drawing.Point(630, 29);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(52, 23);
            this.labelX4.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "诊断:";
            // 
            // Txtdiagnose_Name
            // 
            // 
            // 
            // 
            this.Txtdiagnose_Name.Border.Class = "TextBoxBorder";
            this.Txtdiagnose_Name.Location = new System.Drawing.Point(103, 76);
            this.Txtdiagnose_Name.Multiline = true;
            this.Txtdiagnose_Name.Name = "Txtdiagnose_Name";
            this.Txtdiagnose_Name.ReadOnly = true;
            this.Txtdiagnose_Name.Size = new System.Drawing.Size(299, 81);
            this.Txtdiagnose_Name.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "讨论时间:";
            // 
            // dtTime
            // 
            this.dtTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTime.Location = new System.Drawing.Point(103, 174);
            this.dtTime.Name = "dtTime";
            this.dtTime.Size = new System.Drawing.Size(157, 21);
            this.dtTime.TabIndex = 19;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(154, 247);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnClear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnClear.Location = new System.Drawing.Point(310, 247);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 21;
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(466, 247);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 22;
            this.buttonX1.Text = "取消";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // txtEditer
            // 
            // 
            // 
            // 
            this.txtEditer.Border.Class = "TextBoxBorder";
            this.txtEditer.Location = new System.Drawing.Point(103, 212);
            this.txtEditer.Name = "txtEditer";
            this.txtEditer.Size = new System.Drawing.Size(111, 21);
            this.txtEditer.TabIndex = 24;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "编辑者:";
            // 
            // frmIllnessDiscussed_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 290);
            this.Controls.Add(this.txtEditer);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Txtdiagnose_Name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPatientName);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.Name = "frmIllnessDiscussed_Add";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增病人讨论界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX txtPid;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPatientName;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.Controls.TextBoxX Txtdiagnose_Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtTime;
        private DevComponents.DotNetBar.ButtonX btnSave;
        private DevComponents.DotNetBar.ButtonX btnClear;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtEditer;
        private System.Windows.Forms.Label label5;
    }
}