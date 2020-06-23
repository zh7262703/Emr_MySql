using Base_Function.REPORT_DATASET;
namespace Base_Function.BLL_NURSE.First_cases
{
    partial class frmFirstCases_Print
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Cover_InfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsReportSource = new DsReportSource();
            this.Cover_DiagnoseBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Cover_OperationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Cover_QualityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Cover_TempBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cover_patient_costBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Cover_InfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cover_DiagnoseBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cover_OperationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cover_QualityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cover_TempBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover_patient_costBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Cover_InfoBindingSource
            // 
            this.Cover_InfoBindingSource.DataMember = "Cover_Info";
            this.Cover_InfoBindingSource.DataSource = this.DsReportSource;
            // 
            // DsReportSource
            // 
            this.DsReportSource.DataSetName = "DsReportSource";
            this.DsReportSource.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Cover_DiagnoseBindingSource
            // 
            this.Cover_DiagnoseBindingSource.DataMember = "Cover_Diagnose";
            this.Cover_DiagnoseBindingSource.DataSource = this.DsReportSource;
            // 
            // Cover_OperationBindingSource
            // 
            this.Cover_OperationBindingSource.DataMember = "Cover_Operation";
            this.Cover_OperationBindingSource.DataSource = this.DsReportSource;
            // 
            // Cover_QualityBindingSource
            // 
            this.Cover_QualityBindingSource.DataMember = "Cover_Quality";
            this.Cover_QualityBindingSource.DataSource = this.DsReportSource;
            // 
            // Cover_TempBindingSource
            // 
            this.Cover_TempBindingSource.DataMember = "Cover_Temp";
            this.Cover_TempBindingSource.DataSource = this.DsReportSource;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DsReportSource_Cover_Info";
            reportDataSource1.Value = this.Cover_InfoBindingSource;
            reportDataSource2.Name = "DsReportSource_Cover_Operation";
            reportDataSource2.Value = this.Cover_OperationBindingSource;
            reportDataSource3.Name = "DsReportSource_Cover_Diagnose";
            reportDataSource3.Value = this.Cover_DiagnoseBindingSource;
            reportDataSource4.Name = "DsReportSource_Cover_Quality";
            reportDataSource4.Value = this.Cover_QualityBindingSource;
            reportDataSource5.Name = "DsReportSource_Cover_Temp";
            reportDataSource5.Value = this.Cover_TempBindingSource;
            reportDataSource6.Name = "DsReportSource_cover_patient_cost";
            reportDataSource6.Value = this.cover_patient_costBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bifrost_Nurse.First_cases.First_Cases.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "ReportFile.First_Cases.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewer1.Size = new System.Drawing.Size(814, 624);
            this.reportViewer1.TabIndex = 0;
            // 
            // cover_patient_costBindingSource
            // 
            this.cover_patient_costBindingSource.DataMember = "cover_patient_cost";
            this.cover_patient_costBindingSource.DataSource = this.DsReportSource;
            // 
            // frmFirstCases_Print
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 624);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmFirstCases_Print";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病案首页打印";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmFirstCases_Print_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Cover_InfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsReportSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cover_DiagnoseBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cover_OperationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cover_QualityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Cover_TempBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cover_patient_costBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Cover_InfoBindingSource;
        private DsReportSource DsReportSource;
        private System.Windows.Forms.BindingSource Cover_DiagnoseBindingSource;
        private System.Windows.Forms.BindingSource Cover_OperationBindingSource;
        private System.Windows.Forms.BindingSource Cover_QualityBindingSource;
        private System.Windows.Forms.BindingSource Cover_TempBindingSource;
        private System.Windows.Forms.BindingSource cover_patient_costBindingSource;
        //private System.Windows.Forms.BindingSource Cover_InstatusBindingSource;
        //private System.Windows.Forms.BindingSource Cover_TransferBindingSource;

    }
}