namespace Base_Function.BLL_FOLLOW.Element
{
    partial class frmFollowPatientBaseInfo
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
            this.ucPatientInfo1 = new Base_Function.BLL_DOCTOR.UcPatientInfo();
            this.SuspendLayout();
            // 
            // ucPatientInfo1
            // 
            this.ucPatientInfo1.AutoScroll = true;
            this.ucPatientInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ucPatientInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPatientInfo1.Location = new System.Drawing.Point(0, 0);
            this.ucPatientInfo1.Name = "ucPatientInfo1";
            this.ucPatientInfo1.Size = new System.Drawing.Size(900, 482);
            this.ucPatientInfo1.TabIndex = 0;
            // 
            // frmFollowPatientBaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 482);
            this.Controls.Add(this.ucPatientInfo1);
            this.DoubleBuffered = true;
            this.Name = "frmFollowPatientBaseInfo";
            this.Text = "患者基本信息";
            this.ResumeLayout(false);

        }

        #endregion

        private Base_Function.BLL_DOCTOR.UcPatientInfo ucPatientInfo1;
    }
}