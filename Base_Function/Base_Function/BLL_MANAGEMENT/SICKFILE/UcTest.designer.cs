namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class UcTest
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
            this.ucCoseOperate1 = new ucCoseOperate();
            this.SuspendLayout();
            // 
            // ucCoseOperate1
            // 
            this.ucCoseOperate1.BackColor = System.Drawing.Color.Transparent;
            this.ucCoseOperate1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCoseOperate1.Location = new System.Drawing.Point(0, 0);
            this.ucCoseOperate1.Name = "ucCoseOperate1";
            this.ucCoseOperate1.Size = new System.Drawing.Size(807, 578);
            this.ucCoseOperate1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 578);
            this.Controls.Add(this.ucCoseOperate1);
            this.Name = "frmTest";
            this.Text = "frmTest";
            this.ResumeLayout(false);

        }

        #endregion

        private ucCoseOperate ucCoseOperate1;
    }
}