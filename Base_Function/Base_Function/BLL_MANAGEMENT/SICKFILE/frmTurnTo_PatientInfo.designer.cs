namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class frmTurnTo_PatientInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTurnTo_PatientInfo));
            this.flgView = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).BeginInit();
            this.SuspendLayout();
            // 
            // flgView
            // 
            this.flgView.AllowEditing = false;
            this.flgView.BackColor = System.Drawing.Color.White;
            this.flgView.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None;
            this.flgView.ColumnInfo = "10,1,0,0,0,0,Columns:";
            this.flgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flgView.Location = new System.Drawing.Point(0, 0);
            this.flgView.Name = "flgView";
            this.flgView.Rows.DefaultSize = 18;
            this.flgView.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.flgView.Size = new System.Drawing.Size(814, 454);
            this.flgView.StyleInfo = resources.GetString("flgView.StyleInfo");
            this.flgView.TabIndex = 0;
            // 
            // frmTurnTo_PatientInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 454);
            this.Controls.Add(this.flgView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTurnTo_PatientInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转归病人信息";
            ((System.ComponentModel.ISupportInitialize)(this.flgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid flgView;

    }
}