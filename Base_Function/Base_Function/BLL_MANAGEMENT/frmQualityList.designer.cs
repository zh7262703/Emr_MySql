namespace Base_Function.BLL_MANAGEMENT
{
    partial class frmQualityList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQualityList));
            this.flgView = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).BeginInit();
            this.SuspendLayout();
            // 
            // flgView
            // 
            this.flgView.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.flgView.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView.Location = new System.Drawing.Point(12, 52);
            this.flgView.Name = "flgView";
            this.flgView.Rows.DefaultSize = 18;
            this.flgView.Size = new System.Drawing.Size(768, 509);
            this.flgView.StyleInfo = resources.GetString("flgView.StyleInfo");
            this.flgView.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(150, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmQualityList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flgView);
            this.MaximizeBox = false;
            this.Name = "frmQualityList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "质控扣分详细列表";
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid flgView;
        private System.Windows.Forms.Label label1;

    }
}