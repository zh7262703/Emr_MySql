namespace Base_Function.BLL_NURSE.Nereuse_record
{
    partial class frmDiagnose
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
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            this.lblDiagnose = new System.Windows.Forms.Label();
            this.txtDiagnose = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSave.Location = new System.Drawing.Point(108, 55);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDiagnose
            // 
            this.lblDiagnose.AutoSize = true;
            this.lblDiagnose.Location = new System.Drawing.Point(3, 18);
            this.lblDiagnose.Name = "lblDiagnose";
            this.lblDiagnose.Size = new System.Drawing.Size(65, 12);
            this.lblDiagnose.TabIndex = 14;
            this.lblDiagnose.Text = "诊断名称：";
            // 
            // txtDiagnose
            // 
            this.txtDiagnose.Location = new System.Drawing.Point(73, 15);
            this.txtDiagnose.Name = "txtDiagnose";
            this.txtDiagnose.Size = new System.Drawing.Size(208, 21);
            this.txtDiagnose.TabIndex = 15;
            // 
            // frmDiagnose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 99);
            this.Controls.Add(this.txtDiagnose);
            this.Controls.Add(this.lblDiagnose);
            this.Controls.Add(this.btnSave);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDiagnose";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "诊断名称更改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnSave;
        private System.Windows.Forms.Label lblDiagnose;
        private System.Windows.Forms.TextBox txtDiagnose;
    }
}