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
    /// �ĵ籨��
    /// </summary>
    public partial class FrmECGReport : DevComponents.DotNetBar.Office2007Form
    {
        string sql = "select request_no ���뵥��,patient_id סԺ��,visit_id סԺ����,patient_name ��������, (case sex_code when '0' then '��' else 'Ů' end)�Ա�,exam_class ������,exam_item_name �����Ŀ����,dept_name �������,send_doctor_code ҽ������,send_doctor_name ����ҽ��,exam_result_diagnosis �����,exam_time ���ʱ��,doctor_name ����ҽ��,report_date ����ʱ��,exam_url from esb_view_ect_exam_report@esb ";
        string pid = "";
        string visit_id = "";
        public FrmECGReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �ĵ籨��
        /// </summary>
        /// <param name="pid">סԺ��</param>
        /// <param name="visit_id">סԺ����</param>
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

        private void ���ĵ�ͼToolStripMenuItem_Click(object sender, EventArgs e)
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