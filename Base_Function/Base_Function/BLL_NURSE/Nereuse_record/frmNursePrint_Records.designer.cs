using Base_Function.REPORT_DATASET;
namespace Base_Function.BLL_NURSE.Nereuse_record
{
    partial class frmNursePrint_Records
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
            this.dataTablenurserecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Nurse_Record = new Base_Function.REPORT_DATASET.DataSet_Nurse_Record();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.dataTablenurserecordBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Nurse_Record)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTablenurserecordBindingSource
            // 
            this.dataTablenurserecordBindingSource.DataMember = "DataTable_nurse_record";
            this.dataTablenurserecordBindingSource.DataSource = this.dataSet_Nurse_Record;
            // 
            // dataSet_Nurse_Record
            // 
            this.dataSet_Nurse_Record.DataSetName = "DataSet_Nurse_Record";
            this.dataSet_Nurse_Record.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet_Nurse_Record_DataTable_nurse_record";
            reportDataSource1.Value = this.dataTablenurserecordBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bifrost_Hospital_Management.Report_Nurse_records.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "Report_Nurse_records.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.ReportServerUrl = new System.Uri("", System.UriKind.Relative);
            this.reportViewer1.Size = new System.Drawing.Size(607, 321);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            this.reportViewer1.Print += new System.ComponentModel.CancelEventHandler(this.reportViewer1_Print);
            // 
            // frmNursePrint_Records
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 321);
            this.Controls.Add(this.reportViewer1);
            this.DoubleBuffered = true;
            this.Name = "frmNursePrint_Records";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "护理记录单";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmNursePrint_Records_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTablenurserecordBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Nurse_Record)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataTablenurserecordBindingSource;
        private DataSet_Nurse_Record dataSet_Nurse_Record;
    }
}