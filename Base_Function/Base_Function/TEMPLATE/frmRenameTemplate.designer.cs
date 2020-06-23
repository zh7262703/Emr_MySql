namespace Base_Function.TEMPLATE
{
    partial class frmRenameTemplate
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
            this.lblTemplateName = new System.Windows.Forms.Label();
            this.txtTemplateName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lblTemplateName
            // 
            this.lblTemplateName.AutoSize = true;
            this.lblTemplateName.Location = new System.Drawing.Point(52, 26);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(65, 12);
            this.lblTemplateName.TabIndex = 3;
            this.lblTemplateName.Text = "模板名称：";
            // 
            // txtTemplateName
            // 
            // 
            // 
            // 
            this.txtTemplateName.Border.Class = "TextBoxBorder";
            this.txtTemplateName.Location = new System.Drawing.Point(123, 21);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(158, 21);
            this.txtTemplateName.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnOK.Location = new System.Drawing.Point(103, 62);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(171, 62);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmRenameTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 102);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.lblTemplateName);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenameTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板重命名";
            this.Load += new System.EventHandler(this.frmRenameTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTemplateName;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTemplateName;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.ButtonX btnCancel;
    }
}