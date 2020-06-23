using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    public partial class UcfrmGradeShow : DevComponents.DotNetBar.Office2007Form
    {
      
        string patientId = "";
        string doctorID = App.UserAccount.UserInfo.User_id;
        string doctorName = App.UserAccount.UserInfo.User_name;
        public UcfrmGradeShow(string strPatientID)
        {
            InitializeComponent();
            patientId = strPatientID;//要传递患者id
                   
        }
        public UcfrmGradeShow()
        {
            InitializeComponent();
        }

        private void UcfrmGradeShow_Load(object sender, EventArgs e)
        {
            BindSource();
        }

        private void BindSource()
        {
            try
            {
                dgvSource.Rows.Clear();
                string strKouFenHuiZong = " select t.id,t.item 评分项目,t.item_score 分值,t.item_content 扣分标准,t.item_reason 扣分理由,t.ITEM_PATIENTID 病人id,t.medical_mark_id,isxg from t_deduct_score t where t.ITEM_PATIENTID='" + patientId + "'";
                DataSet ds = App.GetDataSet(strKouFenHuiZong);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgvSource.Rows.Add();
                        dgvSource.Rows[i].Cells[0].Value = dt.Rows[i]["id"];
                        dgvSource.Rows[i].Cells[1].Value = dt.Rows[i]["评分项目"];
                        dgvSource.Rows[i].Cells[2].Value = dt.Rows[i]["分值"];
                        dgvSource.Rows[i].Cells[3].Value = dt.Rows[i]["扣分标准"];
                        dgvSource.Rows[i].Cells[4].Value = dt.Rows[i]["扣分理由"];
                        dgvSource.Rows[i].Cells[5].Value = dt.Rows[i]["medical_mark_id"];
                        dgvSource.Rows[i].Cells[6].Value = dt.Rows[i]["isxg"];
                    }
                    for (int j = 0; j < dgvSource.Rows.Count; j++)
                    {
                        string xg = dgvSource.Rows[j].Cells[6].Value.ToString();
                        //标记1 为已修改 变绿色
                        if (xg == "1")
                        {
                            dgvSource.Rows[j].DefaultCellStyle.ForeColor = Color.Green;
                        }                        
                    }
                }
            }
            catch
            {

            }
        }

        private void btnQRXG_Click(object sender, EventArgs e)
        {
            try
            {                
                string id = dgvSource.SelectedCells[0].Value.ToString();
                string sql = "update t_deduct_score set isxg ='1' where id ='"+id+"'" ;
                if (MessageBox.Show("确定修改完成？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    //确定按钮的方法
                    int result = App.ExecuteSQL(sql);
                    if (result > 0)
                    {
                        MessageBox.Show("修改成功！");
                    }
                }
                else
                {
                    //取消按钮的方法
                    return;
                }               
               
            }
            catch 
            {
                
                throw;
            }
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            BindSource();
        }
    }
}
