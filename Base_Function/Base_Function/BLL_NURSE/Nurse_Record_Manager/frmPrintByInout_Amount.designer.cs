using Bifrost;
namespace Base_Function.BLL_NURSE.Nurse_Record_Manager
{
    partial class frmPrintByInout_Amount
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.NuserInout_showBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.NuserInout_showBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // NuserInout_showBindingSource
            // 
            this.NuserInout_showBindingSource.DataSource = typeof(Bifrost.NuserInout_show);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Inhospital_Info_Model_NuserInout_show";
            reportDataSource1.Value = this.NuserInout_showBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bifrost_Hospital_Management.Nurse_Record_Manager.Report_InOutMount.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "Report_InOutMount.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(756, 465);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmPrintByInout_Amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 465);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.Name = "frmPrintByInout_Amount";
            this.ShowIcon = false;
            this.Text = "出入液量记录单打印";
            this.Load += new System.EventHandler(this.frmPrintByInout_Amount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NuserInout_showBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource NuserInout_showBindingSource;
    }
}