namespace Base_Function.BLL_MANAGEMENT
{
    partial class FrmSpotcheck_particulars
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSpotcheck_particulars));
            this.c1flgview = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.c1flgview)).BeginInit();
            this.SuspendLayout();
            // 
            // c1flgview
            // 
            this.c1flgview.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.c1flgview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c1flgview.Location = new System.Drawing.Point(0, 0);
            this.c1flgview.Name = "c1flgview";
            this.c1flgview.Rows.DefaultSize = 18;
            this.c1flgview.Size = new System.Drawing.Size(517, 338);
            this.c1flgview.StyleInfo = resources.GetString("c1flgview.StyleInfo");
            this.c1flgview.TabIndex = 1;
            // 
            // FrmSpotcheck_particulars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 338);
            this.Controls.Add(this.c1flgview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmSpotcheck_particulars";
            this.Text = "评分明细显示";
            this.Load += new System.EventHandler(this.FrmSpotcheck_particulars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.c1flgview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid c1flgview;
    }
}