namespace Base_Function.EMERGENCY
{
    partial class frmZXT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZXT));
            this.c1Chart1 = new C1.Win.C1Chart.C1Chart();
            ((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Chart1
            // 
            this.c1Chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1Chart1.Location = new System.Drawing.Point(0, 0);
            this.c1Chart1.Name = "c1Chart1";
            this.c1Chart1.PropBag = resources.GetString("c1Chart1.PropBag");
            this.c1Chart1.Size = new System.Drawing.Size(687, 503);
            this.c1Chart1.TabIndex = 0;
            // 
            // frmZXT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 503);
            this.Controls.Add(this.c1Chart1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmZXT";
            this.Text = "折线图";
            this.Load += new System.EventHandler(this.frmZXT_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1Chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Chart.C1Chart c1Chart1;

    }
}