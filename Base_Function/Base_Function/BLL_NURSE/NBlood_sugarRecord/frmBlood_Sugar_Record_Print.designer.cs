namespace Base_Function.BLL_NURSE.NBlood_sugarRecord
{
    partial class frmBlood_Sugar_Record_Print
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param Name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bifrost_Nurse.Report_Bgrecord.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "Report_Bgrecord.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(754, 493);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.frmBlood_Sugar_Record_Print_Load);
            // 
            // frmBlood_Sugar_Record_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 493);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmBlood_Sugar_Record_Print";
            this.ShowIcon = false;
            this.Text = "末梢血糖监测记录单";
            this.Load += new System.EventHandler(this.frmBlood_Sugar_Record_Print_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}