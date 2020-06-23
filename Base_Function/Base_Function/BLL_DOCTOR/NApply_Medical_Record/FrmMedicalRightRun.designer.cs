namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    partial class FrmMedicalRightRun
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
            this.ucMedicalRightRun_Search1 = new UCMedicalRightRun_Search();
            this.SuspendLayout();
            // 
            // ucMedicalRightRun_Search1
            // 
            this.ucMedicalRightRun_Search1.BackColor = System.Drawing.Color.Transparent;
            this.ucMedicalRightRun_Search1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMedicalRightRun_Search1.Location = new System.Drawing.Point(0, 0);
            this.ucMedicalRightRun_Search1.Name = "ucMedicalRightRun_Search1";
            this.ucMedicalRightRun_Search1.Size = new System.Drawing.Size(896, 537);
            this.ucMedicalRightRun_Search1.TabIndex = 0;
            // 
            // FrmMedicalRightRun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 537);
            this.Controls.Add(this.ucMedicalRightRun_Search1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "FrmMedicalRightRun";
            this.ShowIcon = false;
            this.Text = "运行病例查阅";
            this.ResumeLayout(false);

        }

        #endregion

        private UCMedicalRightRun_Search ucMedicalRightRun_Search1;
    }
}