using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Microsoft.Win32;

namespace Base_Function.BASE_DATA
{
    /// <summary>
    /// 心电报告
    /// </summary>
    public partial class FrmECGReport : DevComponents.DotNetBar.Office2007Form
    {
        string sql = "select request_no 申请单号,patient_id 住院号,visit_id 住院次数,patient_name 患者姓名, (case sex_code when '0' then '男' else '女' end)性别,exam_class 检查类别,exam_item_name 检查项目名称,dept_name 申请科室,send_doctor_code 医生工号,send_doctor_name 申请医生,exam_result_diagnosis 检查结果,exam_time 检查时间,doctor_name 报告医生,report_date 报告时间,exam_url from esb_view_ect_exam_report@esb ";
        string pid = "";
        string visit_id = "";
        public FrmECGReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 心电报告
        /// </summary>
        /// <param name="pid">住院号</param>
        /// <param name="visit_id">住院次数</param>
        public FrmECGReport(string pid, string visit_id)
        {
            InitializeComponent();
            this.pid = pid;
            this.visit_id = visit_id;
        }

        private void FrmECGReport_Load(object sender, EventArgs e)
        {
            try
            {
                dgvECG.ReadOnly = true;
                dgvECG.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvECG.AllowUserToDeleteRows = false;
                dgvECG.AllowUserToAddRows = false;

                sql += " where patient_id='" + pid + "' ";//and visit_id=" + visit_id;
                DataSet ds = App.GetDataSet(sql);
                if (ds != null && ds.Tables[0] != null)
                {
                    dgvECG.DataSource = ds.Tables[0];
                    dgvECG.Columns["exam_url"].Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void 打开心电图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenBrowser("http://192.168.6.56/external/getreport.php?uri=" + dgvECG.CurrentRow.Cells["exam_url"].Value);
        }

        public static bool OpenBrowser(String url)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey(@"http\shell\open\command\");
            String s = key.GetValue("").ToString();
            String browserpath = null;
            if (s.StartsWith("\""))
            {
                browserpath = s.Substring(1, s.IndexOf('\"', 1) - 1);
            }
            else
            {
                browserpath = s.Substring(0, s.IndexOf(" "));
            }
            return System.Diagnostics.Process.Start(browserpath, url) != null;
        }  
    }
}