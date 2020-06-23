namespace Base_Function.BLL_FOLLOW.Element
{
    partial class frmRenameFollowTemplate
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
            this.txtTemplateName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.lblTemplateName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCancel.Location = new System.Drawing.Point(146, 77);
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
            this.btnOK.Location = new System.Drawing.Point(78, 77);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(62, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "确定";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTemplateName
            // 
            // 
            // 
            // 
            this.txtTemplateName.Border.Class = "TextBoxBorder";
            this.txtTemplateName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTemplateName.Location = new System.Drawing.Point(98, 36);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(158, 21);
            this.txtTemplateName.TabIndex = 4;
            // 
            // lblTemplateName
            // 
            this.lblTemplateName.AutoSize = true;
            this.lblTemplateName.Location = new System.Drawing.Point(27, 41);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(65, 12);
            this.lblTemplateName.TabIndex = 7;
            this.lblTemplateName.Text = "模板名称：";
            // 
            // frmRenameFollowTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 127);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.lblTemplateName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenameFollowTemplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "模板重命名";
            this.Load += new System.EventHandler(this.frmRenameFollowTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTemplateName;
        private System.Windows.Forms.Label lblTemplateName;
    }
}