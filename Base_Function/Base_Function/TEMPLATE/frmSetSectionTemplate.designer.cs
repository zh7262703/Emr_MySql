namespace Base_Function.TEMPLATE
{
    partial class frmSetSectionTemplate
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
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.lblSectionName = new System.Windows.Forms.Label();
            this.cboSectionName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(158, 67);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(90, 67);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblSectionName
            // 
            this.lblSectionName.AutoSize = true;
            this.lblSectionName.Location = new System.Drawing.Point(49, 31);
            this.lblSectionName.Name = "lblSectionName";
            this.lblSectionName.Size = new System.Drawing.Size(65, 12);
            this.lblSectionName.TabIndex = 7;
            this.lblSectionName.Text = "科室名称：";
            // 
            // cboSectionName
            // 
            this.cboSectionName.FormattingEnabled = true;
            this.cboSectionName.Location = new System.Drawing.Point(120, 28);
            this.cboSectionName.Name = "cboSectionName";
            this.cboSectionName.Size = new System.Drawing.Size(146, 20);
            this.cboSectionName.TabIndex = 0;
            // 
            // frmSetSectionTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 116);
            this.Controls.Add(this.cboSectionName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblSectionName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetSectionTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设为科室默认模板";
            this.Load += new System.EventHandler(this.frmSetSectionTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.Label lblSectionName;
        private System.Windows.Forms.ComboBox cboSectionName;
    }
}