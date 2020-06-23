namespace Base_Function.TEMPLATE
{
    partial class frmSmallTemplateSave
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
            this.rdoPersonal = new System.Windows.Forms.RadioButton();
            this.rdoSection = new System.Windows.Forms.RadioButton();
            this.pnlSex = new System.Windows.Forms.Panel();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.rdoSexNull = new System.Windows.Forms.RadioButton();
            this.txtAutoTPName = new System.Windows.Forms.TextBox();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboModelType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbSection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSex.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdoPersonal
            // 
            this.rdoPersonal.AutoSize = true;
            this.rdoPersonal.Checked = true;
            this.rdoPersonal.Location = new System.Drawing.Point(9, 7);
            this.rdoPersonal.Name = "rdoPersonal";
            this.rdoPersonal.Size = new System.Drawing.Size(47, 16);
            this.rdoPersonal.TabIndex = 12;
            this.rdoPersonal.TabStop = true;
            this.rdoPersonal.Text = "个人";
            this.rdoPersonal.UseVisualStyleBackColor = true;
            this.rdoPersonal.CheckedChanged += new System.EventHandler(this.rdoPersonal_CheckedChanged);
            // 
            // rdoSection
            // 
            this.rdoSection.AutoSize = true;
            this.rdoSection.Location = new System.Drawing.Point(57, 7);
            this.rdoSection.Name = "rdoSection";
            this.rdoSection.Size = new System.Drawing.Size(47, 16);
            this.rdoSection.TabIndex = 13;
            this.rdoSection.Text = "科室";
            this.rdoSection.UseVisualStyleBackColor = true;
            // 
            // pnlSex
            // 
            this.pnlSex.Controls.Add(this.rdoFemale);
            this.pnlSex.Controls.Add(this.rdoMale);
            this.pnlSex.Controls.Add(this.rdoSexNull);
            this.pnlSex.Location = new System.Drawing.Point(70, 96);
            this.pnlSex.Name = "pnlSex";
            this.pnlSex.Size = new System.Drawing.Size(136, 26);
            this.pnlSex.TabIndex = 55;
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Location = new System.Drawing.Point(87, 3);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(35, 16);
            this.rdoFemale.TabIndex = 44;
            this.rdoFemale.Text = "女";
            this.rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(46, 3);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(35, 16);
            this.rdoMale.TabIndex = 43;
            this.rdoMale.Text = "男";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoSexNull
            // 
            this.rdoSexNull.AutoSize = true;
            this.rdoSexNull.Checked = true;
            this.rdoSexNull.Location = new System.Drawing.Point(5, 3);
            this.rdoSexNull.Name = "rdoSexNull";
            this.rdoSexNull.Size = new System.Drawing.Size(35, 16);
            this.rdoSexNull.TabIndex = 42;
            this.rdoSexNull.TabStop = true;
            this.rdoSexNull.Text = "无";
            this.rdoSexNull.UseVisualStyleBackColor = true;
            // 
            // txtAutoTPName
            // 
            this.txtAutoTPName.Location = new System.Drawing.Point(70, 70);
            this.txtAutoTPName.Name = "txtAutoTPName";
            this.txtAutoTPName.Size = new System.Drawing.Size(309, 21);
            this.txtAutoTPName.TabIndex = 51;
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(70, 128);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(114, 21);
            this.dtpTime.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 49;
            this.label8.Text = "模版名称：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(201, 169);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 48;
            this.btnCancel.Text = "取消";
            
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(120, 169);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 47;
            this.btnOK.Text = "确定";
            
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 46;
            this.label7.Text = "日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 45;
            this.label6.Text = "性别：";
            // 
            // cboModelType
            // 
            this.cboModelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModelType.FormattingEnabled = true;
            this.cboModelType.Location = new System.Drawing.Point(70, 44);
            this.cboModelType.Name = "cboModelType";
            this.cboModelType.Size = new System.Drawing.Size(174, 20);
            this.cboModelType.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "模板类型：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbSection);
            this.panel1.Controls.Add(this.rdoPersonal);
            this.panel1.Controls.Add(this.rdoSection);
            this.panel1.Location = new System.Drawing.Point(70, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 26);
            this.panel1.TabIndex = 56;
            // 
            // cmbSection
            // 
            this.cmbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSection.FormattingEnabled = true;
            this.cmbSection.Location = new System.Drawing.Point(110, 4);
            this.cmbSection.Name = "cmbSection";
            this.cmbSection.Size = new System.Drawing.Size(126, 20);
            this.cmbSection.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 57;
            this.label1.Text = "模板类型：";
            // 
            // frmSmallTemplateSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 215);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboModelType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlSex);
            this.Controls.Add(this.txtAutoTPName);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSmallTemplateSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "小模板保存";
            this.Load += new System.EventHandler(this.frmSmallTemplateSave_Load);
            this.pnlSex.ResumeLayout(false);
            this.pnlSex.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoPersonal;
        private System.Windows.Forms.RadioButton rdoSection;
        private System.Windows.Forms.Panel pnlSex;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.RadioButton rdoSexNull;
        private System.Windows.Forms.TextBox txtAutoTPName;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label label8;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboModelType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSection;
    }
}