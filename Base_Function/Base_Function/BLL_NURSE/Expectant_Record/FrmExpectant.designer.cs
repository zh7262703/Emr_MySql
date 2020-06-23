using Base_Function.REPORT_DATASET;
namespace Base_Function.BLL_NURSE.Expectant_Record
{
    partial class FrmExpectant
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet_Expectant = new DataSet_Expectant();
            this.DataTable_ExpectantBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Expectant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable_ExpectantBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet_Expectant_DataTable_Expectant";
            reportDataSource1.Value = this.DataTable_ExpectantBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Bifrost_Nurse.Report_Expectant.rdlc";
            this.reportViewer1.LocalReport.ReportPath = "Report_Expectant.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(452, 336);
            this.reportViewer1.TabIndex = 0;
            // 
            // DataSet_Expectant
            // 
            this.DataSet_Expectant.DataSetName = "DataSet_Expectant";
            this.DataSet_Expectant.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DataTable_ExpectantBindingSource
            // 
            this.DataTable_ExpectantBindingSource.DataMember = "DataTable_Expectant";
            this.DataTable_ExpectantBindingSource.DataSource = this.DataSet_Expectant;
            // 
            // FrmExpectant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 336);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmExpectant";
            this.ShowIcon = false;
            this.Text = "打印待产记录";
            this.Load += new System.EventHandler(this.FrmExpectant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataSet_Expectant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable_ExpectantBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable_ExpectantBindingSource;
        private DataSet_Expectant DataSet_Expectant;
    }
}