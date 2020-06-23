namespace TempertureEditor
{
    partial class frmMainSelect
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
            this.btnTemplateEdit = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX3 = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btnTemplateEdit
            // 
            this.btnTemplateEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTemplateEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTemplateEdit.Location = new System.Drawing.Point(59, 12);
            this.btnTemplateEdit.Name = "btnTemplateEdit";
            this.btnTemplateEdit.Size = new System.Drawing.Size(136, 53);
            this.btnTemplateEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTemplateEdit.TabIndex = 0;
            this.btnTemplateEdit.Text = "模版编辑";
            this.btnTemplateEdit.Click += new System.EventHandler(this.btnTemplateEdit_Click);
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(59, 75);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(136, 53);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 1;
            this.buttonX2.Text = "测试模板";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(59, 138);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(136, 53);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "测试群录";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // buttonX3
            // 
            this.buttonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX3.Location = new System.Drawing.Point(59, 199);
            this.buttonX3.Name = "buttonX3";
            this.buttonX3.Size = new System.Drawing.Size(136, 53);
            this.buttonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX3.TabIndex = 3;
            this.buttonX3.Text = "测试";
            this.buttonX3.Click += new System.EventHandler(this.buttonX3_Click);
            // 
            // frmMainSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 256);
            this.Controls.Add(this.buttonX3);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.btnTemplateEdit);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMainSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "功能选择";
            this.Load += new System.EventHandler(this.frmMainSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnTemplateEdit;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX3;
    }
}