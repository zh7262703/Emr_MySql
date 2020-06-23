namespace Base_Function.BLL_MANAGEMENT
{
    partial class frmLis_Query
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
            this.ucGridviewX1 = new Bifrost.ucGridviewX();
            this.SuspendLayout();
            // 
            // ucGridviewX1
            // 
            this.ucGridviewX1.Location = new System.Drawing.Point(0, 1);
            this.ucGridviewX1.Name = "ucGridviewX1";
            this.ucGridviewX1.Size = new System.Drawing.Size(783, 533);
            this.ucGridviewX1.TabIndex = 0;
            this.ucGridviewX1.Load += new System.EventHandler(this.ucGridviewX1_Load);
            // 
            // frmLis_Query
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 535);
            this.Controls.Add(this.ucGridviewX1);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLis_Query";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.frmLis_Query_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bifrost.ucGridviewX ucGridviewX1;
    }
}