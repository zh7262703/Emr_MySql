using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Digital_Medical_Treatment
{
    public partial class frmIllnessDiscussed : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 病情讨论
        /// </summary>
        public frmIllnessDiscussed()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                dgvIllness.Rows.Clear();
                string strSql = @"select t.id,
                                   t.patient_id,
                                   t.patient_name,
                                   t.pid,
                                   t.sex,
                                   t.age,
                                   t.diagnose_name,
                                   t.time,
                                   t.editer_id,
                                   t.editer_name
                              from t_in_patient_illness t where 1=1 ";

                string strStartTime = "";//开始时间
                string strEndTime = "";  //结束时间
                if (cbTime.Checked==true)
                {
                    strStartTime = dtStartTime.Value.ToString("yyyyMMdd");
                    strEndTime = dtEndTime.Value.ToString("yyyyMMdd");
                    if (Convert.ToInt32(strStartTime) > Convert.ToInt32(strEndTime))
                    {
                        App.Msg("输入的起始时间不许大于终止时间！");
                        return;
                    }
                    strSql += " and (t.time>= to_date('" + strStartTime + "','yyyy-MM-dd hh24:mi:ss') and  t.time< to_date('" + strEndTime + "','yyyy-MM-dd hh24:mi:ss'))";
                }
                if (txtPatientName.Text!="")
                {
                    strSql += " and t.patient_name like '%" + txtPatientName.Text+ "%'";
                }
                if (txtCreater.Text!="")
                {
                    strSql += " and t.editer_name like '%" + txtCreater.Text + "%'";
                }
                DataSet ds = App.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count>0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvIllness.Rows.Add();
                        dgvIllness.Rows[i].Cells["Column1"].Value = ds.Tables[0].Rows[i]["id"].ToString();
                        dgvIllness.Rows[i].Cells["Column2"].Value = ds.Tables[0].Rows[i]["pid"].ToString();
                        dgvIllness.Rows[i].Cells["Column3"].Value = ds.Tables[0].Rows[i]["patient_id"].ToString();
                        dgvIllness.Rows[i].Cells["Column4"].Value = ds.Tables[0].Rows[i]["patient_name"].ToString();
                        dgvIllness.Rows[i].Cells["Column5"].Value = ds.Tables[0].Rows[i]["sex"].ToString();
                        dgvIllness.Rows[i].Cells["Column6"].Value = ds.Tables[0].Rows[i]["age"].ToString();
                        dgvIllness.Rows[i].Cells["Column7"].Value = ds.Tables[0].Rows[i]["diagnose_name"].ToString();
                        dgvIllness.Rows[i].Cells["Column8"].Value = ds.Tables[0].Rows[i]["time"].ToString();
                        dgvIllness.Rows[i].Cells["Column9"].Value = ds.Tables[0].Rows[i]["editer_id"].ToString();
                        dgvIllness.Rows[i].Cells["Column10"].Value = ds.Tables[0].Rows[i]["editer_name"].ToString();
                    }
                    dgvIllness.AutoResizeColumns();
                }
            }
            catch 
            {
                
            }
        }
        /// <summary>
        /// 新增功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmIllnessDiscussed_Add frm = new frmIllnessDiscussed_Add();
                frm.ShowDialog();
                btnSelect_Click(null,null);
            }
            catch 
            {
                
            }
        }
        /// <summary>
        /// 病历概述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 病历概述ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strId = dgvIllness.CurrentRow.Cells["Column3"].Value.ToString();
                DataInit.CurrentPatient = DataInit.GetInpatientInfoByPid(strId);
                if (DataInit.CurrentPatient != null)
                {
                    frmMain frm = new frmMain(DataInit.CurrentPatient);
                    frm.ShowDialog();
                }
                else
                {
                    App.Msg("请选中一条数据进行操作！");
                    return;
                }                
            }
            catch 
            {
                
                
            }
        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strId = dgvIllness.CurrentRow.Cells["Column1"].Value.ToString();
                DataInit.CurrentPatient = DataInit.GetInpatientInfoByPid(strId);
                if (strId!="")
                {
                    string strDelete_sql = "delete  from t_in_patient_illness t where t.id='" + strId + "'";
                    int n = App.ExecuteSQL(strDelete_sql);
                    if (n>0)
                    {
                        App.Msg("删除成功！");
                        btnSelect_Click(null,null);
                        return;
                    }
                }
            }
            catch 
            {
                
               
            }
        }
        /// <summary>
        /// 曲线图配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 曲线图配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strId = dgvIllness.CurrentRow.Cells["Column3"].Value.ToString();

                DataInit.CurrentPatient = DataInit.GetInpatientInfoByPid(strId);
                if (DataInit.CurrentPatient != null)
                {
                    frmPatientProgress frm = new frmPatientProgress(DataInit.CurrentPatient);
                    frm.ShowDialog();
                }
                else
                {
                    App.Msg("请选中一条数据进行操作！");
                    return;
                }

            }
            catch
            {


            }
        }
        /// <summary>
        /// 显示屏展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 显示屏展示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string strId = dgvIllness.CurrentRow.Cells["Column3"].Value.ToString();
                DataInit.CurrentPatient = DataInit.GetInpatientInfoByPid(strId);
                if (DataInit.CurrentPatient != null)
                {
                    UcScreen frm = new UcScreen(DataInit.CurrentPatient);
                    frm.ShowDialog();
                }
                else
                {
                    App.Msg("请选中一条数据进行操作！");
                    return;
                }

            }
            catch
            {


            }
        }

        private void frmIllnessDiscussed_Load(object sender, EventArgs e)
        {
           
        }
    }
}