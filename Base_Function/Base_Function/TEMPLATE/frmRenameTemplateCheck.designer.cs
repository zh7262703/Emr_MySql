namespace Base_Function.TEMPLATE
{
    partial class frmRenameTemplateCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.btnCancel.Location = new System.Drawing.Point(193, 56);
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
            this.btnOK.Location = new System.Drawing.Point(112, 56);
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
            this.txtTemplateName.Location = new System.Drawing.Point(94, 15);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(229, 21);
            this.txtTemplateName.TabIndex = 4;
            // 
            // lblTemplateName
            // 
            this.lblTemplateName.AutoSize = true;
            this.lblTemplateName.Location = new System.Drawing.Point(23, 17);
            this.lblTemplateName.Name = "lblTemplateName";
            this.lblTemplateName.Size = new System.Drawing.Size(65, 12);
            this.lblTemplateName.TabIndex = 7;
            this.lblTemplateName.Text = "模板名称：";
            // 
            // frmRenameTemplateCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 95);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.lblTemplateName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRenameTemplateCheck";
            this.ShowIcon = false;
            this.Text = "审核模板重命名";
            this.Load += new System.EventHandler(this.frmRenameTemplateCheck_Load);
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