namespace Base_Function.BLL_FOLLOW.Element
{
    partial class frmFollowTemplateSave
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoHospital = new System.Windows.Forms.RadioButton();
            this.rdoPersonal = new System.Windows.Forms.RadioButton();
            this.rdoSection = new System.Windows.Forms.RadioButton();
            this.lblDefaultModel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbNo = new System.Windows.Forms.RadioButton();
            this.rdbYes = new System.Windows.Forms.RadioButton();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.txtAutoTPName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoHospital);
            this.groupBox1.Controls.Add(this.rdoPersonal);
            this.groupBox1.Controls.Add(this.rdoSection);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 55);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "使用范围";
            // 
            // rdoHospital
            // 
            this.rdoHospital.AutoSize = true;
            this.rdoHospital.Location = new System.Drawing.Point(152, 24);
            this.rdoHospital.Name = "rdoHospital";
            this.rdoHospital.Size = new System.Drawing.Size(47, 16);
            this.rdoHospital.TabIndex = 14;
            this.rdoHospital.Text = "全院";
            this.rdoHospital.UseVisualStyleBackColor = true;
            // 
            // rdoPersonal
            // 
            this.rdoPersonal.AutoSize = true;
            this.rdoPersonal.Checked = true;
            this.rdoPersonal.Location = new System.Drawing.Point(18, 24);
            this.rdoPersonal.Name = "rdoPersonal";
            this.rdoPersonal.Size = new System.Drawing.Size(47, 16);
            this.rdoPersonal.TabIndex = 12;
            this.rdoPersonal.TabStop = true;
            this.rdoPersonal.Text = "个人";
            this.rdoPersonal.UseVisualStyleBackColor = true;
            // 
            // rdoSection
            // 
            this.rdoSection.AutoSize = true;
            this.rdoSection.Location = new System.Drawing.Point(84, 24);
            this.rdoSection.Name = "rdoSection";
            this.rdoSection.Size = new System.Drawing.Size(47, 16);
            this.rdoSection.TabIndex = 13;
            this.rdoSection.Text = "科室";
            this.rdoSection.UseVisualStyleBackColor = true;
            // 
            // lblDefaultModel
            // 
            this.lblDefaultModel.AutoSize = true;
            this.lblDefaultModel.Location = new System.Drawing.Point(12, 105);
            this.lblDefaultModel.Name = "lblDefaultModel";
            this.lblDefaultModel.Size = new System.Drawing.Size(65, 12);
            this.lblDefaultModel.TabIndex = 41;
            this.lblDefaultModel.Text = "默认模板：";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbNo);
            this.panel1.Controls.Add(this.rdbYes);
            this.panel1.Location = new System.Drawing.Point(91, 102);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 21);
            this.panel1.TabIndex = 42;
            // 
            // rdbNo
            // 
            this.rdbNo.AutoSize = true;
            this.rdbNo.Checked = true;
            this.rdbNo.Location = new System.Drawing.Point(45, 2);
            this.rdbNo.Name = "rdbNo";
            this.rdbNo.Size = new System.Drawing.Size(35, 16);
            this.rdbNo.TabIndex = 37;
            this.rdbNo.TabStop = true;
            this.rdbNo.Text = "否";
            this.rdbNo.UseVisualStyleBackColor = true;
            // 
            // rdbYes
            // 
            this.rdbYes.AutoSize = true;
            this.rdbYes.Location = new System.Drawing.Point(4, 3);
            this.rdbYes.Name = "rdbYes";
            this.rdbYes.Size = new System.Drawing.Size(35, 16);
            this.rdbYes.TabIndex = 36;
            this.rdbYes.Text = "是";
            this.rdbYes.UseVisualStyleBackColor = true;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(68, 129);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.TabIndex = 43;
            this.buttonX1.Text = "确定";
            this.buttonX1.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(154, 129);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(75, 23);
            this.buttonX2.TabIndex = 44;
            this.buttonX2.Text = "取消";
            this.buttonX2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtAutoTPName
            // 
            this.txtAutoTPName.Location = new System.Drawing.Point(91, 67);
            this.txtAutoTPName.Name = "txtAutoTPName";
            this.txtAutoTPName.Size = new System.Drawing.Size(222, 21);
            this.txtAutoTPName.TabIndex = 46;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 45;
            this.label8.Text = "模版名称：";
            // 
            // frmFollowTemplateSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 161);
            this.Controls.Add(this.txtAutoTPName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.lblDefaultModel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFollowTemplateSave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板保存";
            this.Load += new System.EventHandler(this.frmFollowTemplateSave_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoHospital;
        private System.Windows.Forms.RadioButton rdoPersonal;
        private System.Windows.Forms.RadioButton rdoSection;
        private System.Windows.Forms.Label lblDefaultModel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbNo;
        private System.Windows.Forms.RadioButton rdbYes;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private System.Windows.Forms.TextBox txtAutoTPName;
        private System.Windows.Forms.Label label8;
    }
}