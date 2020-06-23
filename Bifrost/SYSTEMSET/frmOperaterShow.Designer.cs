namespace Bifrost.SYSTEMSET
{
    partial class frmOperaterShow
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
            this.ucOperaterLog1 = new Bifrost.SYSTEMSET.ucOperaterLog();
            this.SuspendLayout();
            // 
            // ucOperaterLog1
            // 
            this.ucOperaterLog1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucOperaterLog1.Location = new System.Drawing.Point(0, 0);
            this.ucOperaterLog1.Name = "ucOperaterLog1";
            this.ucOperaterLog1.Size = new System.Drawing.Size(761, 349);
            this.ucOperaterLog1.TabIndex = 0;
            // 
            // frmOperaterShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 349);
            this.Controls.Add(this.ucOperaterLog1);
            this.Name = "frmOperaterShow";
            this.Text = "操作日志显示";
            this.Load += new System.EventHandler(this.frmOperaterShow_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucOperaterLog ucOperaterLog1;
    }
}