using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using C1.Win.C1FlexGrid;
using Bifrost.HisInStance;
using Base_Function.BASE_COMMON;
//using Bifrost_Doctor.CommonClass;




namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class frmKouFenDetailsCheck : DevComponents.DotNetBar.Office2007Form
    {
        public frmKouFenDetailsCheck()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 病人id
        /// </summary>
        string strzyh= "";
        public frmKouFenDetailsCheck(string zyh)
        {
            InitializeComponent();
            strzyh = zyh;

        }
        private void frmKouFenDetailsCheck_Load(object sender, EventArgs e)
        {
            try
            {
                string strSql = @"select distinct t2.item_patientid, t2.item 扣分类型,t1.down_point 扣分值,
                                    t2.item_content 详细扣分信息,t2.item_reason 扣分理由,isxg
                                     from t_doc_grade t1 ,t_deduct_score t2 
                                 where t1.emptype = 'D' and t1.patient_id =t2.item_patientid and t2.medical_mark_id =t1.item_id 
                                   and t1.pid='" + strzyh + "'";
                DataSet ds = App.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvKouFenDetails.DataSource = ds.Tables[0].DefaultView;
                    
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string xg = dgvKouFenDetails.Rows[i].Cells[5].Value.ToString();
                        if (xg == "1")
                        {
                            dgvKouFenDetails.Rows[i].DefaultCellStyle.ForeColor = Color.Green;
                        }        
                    }
                }
                dgvKouFenDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvKouFenDetails.Columns[0].Visible = false;
                dgvKouFenDetails.Columns[5].Visible = false;
            }
            catch
            {

            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (dgvKouFenDetails.Rows.Count > 0)
            {
                string patientid = dgvKouFenDetails.Rows[0].Cells[0].Value.ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patientid);
                Form frm = new Form();
                ucPFDoc uc = new ucPFDoc(inPatient);
                uc.Dock = DockStyle.Fill;
                frm.WindowState = FormWindowState.Maximized;
                frm.Controls.Add(uc);
                frm.ShowDialog();
            }
        }

    }     
}