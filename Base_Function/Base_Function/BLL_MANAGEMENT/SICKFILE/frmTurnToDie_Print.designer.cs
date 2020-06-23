using Base_Function.REPORT_DATASET;
namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    partial class frmTurnToDie_Print
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
            this.DtTurnTo_DieBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsStatistics = new Base_Function.REPORT_DATASET.DsStatistics();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.DtTurnTo_DieBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsStatistics)).BeginInit();
            this.SuspendLayout();
            // 
            // DtTurnTo_DieBindingSource
            // 
            this.DtTurnTo_DieBindingSource.DataMember = "DtTurnTo_Die";
            this.DtTurnTo_DieBindingSource.DataSource = this.DsStatistics;
            // 
            // DsStatistics
            // 
            this.DsStatistics.DataSetName = "DsStatistics";
            this.DsStatistics.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsStatistics_DtTurnTo_Die";
            reportDataSource1.Value = this.DtTurnTo_DieBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bifrost_Hospital_Management.Medical_Record_Underline_Statistics.Report_TurnToDie." +
                "rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(792, 429);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmTurnToDie_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 429);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTurnToDie_Print";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "打印死亡信息";
            this.Load += new System.EventHandler(this.frmTurnTo_Die_Print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtTurnTo_DieBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsStatistics)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DtTurnTo_DieBindingSource;
        private DsStatistics DsStatistics;
    }
}