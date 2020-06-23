using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.UnFinished
{
    public partial class ucWjzJY : UserControl
    {
        public InPatientInfo inpatient;
        public int Count = 0;
        public ucWjzJY()
        {
            InitializeComponent();
        }

        public ucWjzJY(InPatientInfo info )
        {
            InitializeComponent();
            inpatient = info; 
        }

        private void ucWjzJY_Load(object sender, EventArgs e)
        {
            
            BindDgv();
            RefDgv();
         
        }

        private void RefDgv()
        {
            int a = 0;
            if (dgvJY.Rows.Count > 0)
            {
                for (int i = 0; i < dgvJY.Rows.Count ; i++)
                {
                    if (dgvJY.Rows[i].Cells["zt"].Value.ToString() == "未读")
                    {
                        dgvJY.Rows[i].Cells["zt"].Style.ForeColor = Color.Red;
                        a++;
                    }
                    else
                    {
                        dgvJY.Rows[i].Cells["zt"].Style.ForeColor = Color.Black;
                    }
                }
            }
            Count = a;
        }

        private void BindDgv()
        {
            dgvJY.Rows.Clear();
            string sql = @"select distinct bbmc as 检验单,b.xmmc 项目名称,b.xmjg 结果,b.jgdw 单位,b.ckz 参考值, jyrq as 报告日期,
                            a.bblsh as 标本流水号,b.xmdm, case when b.biaoji='1' then '已读' else '未读' end  as 标记
                            from t_Lis_Sample a left join t_lis_result b  on a.bblsh=b.bblsh where a.his_id='" + inpatient.His_id + "'and b.jgbz is not null order by jyrq desc";
            DataSet ds =App.GetDataSet(sql);
            if (ds != null )
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvJY.Rows.Add();
                        dgvJY.Rows[i].Cells["xh"].Value = (i + 1).ToString();
                        dgvJY.Rows[i].Cells["jyd"].Value = ds.Tables[0].Rows[i]["检验单"].ToString();
                        dgvJY.Rows[i].Cells["jyxmmc"].Value = ds.Tables[0].Rows[i]["项目名称"].ToString();
                        dgvJY.Rows[i].Cells["jyjg"].Value = ds.Tables[0].Rows[i]["结果"].ToString();
                        dgvJY.Rows[i].Cells["dw"].Value = ds.Tables[0].Rows[i]["单位"].ToString();
                        dgvJY.Rows[i].Cells["ckz"].Value = ds.Tables[0].Rows[i]["参考值"].ToString();
                        dgvJY.Rows[i].Cells["bgrq"].Value = ds.Tables[0].Rows[i]["报告日期"].ToString();
                        dgvJY.Rows[i].Cells["bblsh"].Value = ds.Tables[0].Rows[i]["标本流水号"].ToString();
                        dgvJY.Rows[i].Cells["xmdm"].Value = ds.Tables[0].Rows[i]["xmdm"].ToString();
                        dgvJY.Rows[i].Cells["zt"].Value = ds.Tables[0].Rows[i]["标记"].ToString();
                       
                    }

                }
            }
        }

        private void dgvJY_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvJY.Rows.Count>0 && e.RowIndex != -1)
            {
                string lsh = dgvJY.Rows[e.RowIndex].Cells["bblsh"].Value.ToString();
                string xmdm = dgvJY.Rows[e.RowIndex].Cells["xmdm"].Value.ToString();
                string bj = dgvJY.Rows[e.RowIndex].Cells["zt"].Value.ToString();
                if (bj == "未读")
                {
                    string sql = "update t_lis_result set biaoji ='1' where bblsh ='" + lsh + "' and xmdm ='" + xmdm + "'";
                    int res = App.ExecuteSQL(sql);
                    if (res > 0)
                    {
                        dgvJY.Rows[e.RowIndex].Cells["zt"].Value = "已读";
                    }
                }

                RefDgv(); 
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            List<string> Sqls = new List<string>();
            if (dgvJY.Rows.Count > 0)
            {
                for (int i = 0; i < dgvJY.Rows.Count; i++)
                {
                    string lsh = dgvJY.Rows[i].Cells["bblsh"].Value.ToString();
                    string xmdm = dgvJY.Rows[i].Cells["xmdm"].Value.ToString();
                    string bj = dgvJY.Rows[i].Cells["zt"].Value.ToString();
                    if (bj == "未读")
                    {
                        string sql = "update t_lis_result set biaoji ='1' where bblsh ='" + lsh + "' and xmdm ='" + xmdm + "'";
                        Sqls.Add(sql);
                    }
                }
                 App.ExecuteBatch(Sqls.ToArray());
                 BindDgv();
                 RefDgv();
            }
        }

        private void dgvJY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
            {
                    string content = GetContent();
                    Clipboard.SetDataObject(content);
             
            }
        }

        private string GetContent()
        {
            string con = "";
            if (dgvJY.Rows.Count>0)
            {
                for (int i = 0; i < dgvJY.Rows.Count; i++)
                {
                    if (dgvJY.Rows[i].Selected == true)
                    {
                        string xmmc = dgvJY.Rows[i].Cells["jyxmmc"].Value.ToString();
                        string xmjg = dgvJY.Rows[i].Cells["jyjg"].Value.ToString();
                        string dw = dgvJY.Rows[i].Cells["dw"].Value.ToString();
                        if (con == "")
                        {
                            con = xmmc + " " + xmjg + " " + dw;
                        }
                        else
                        {
                            con += "," + xmmc + " " + xmjg + " " + dw;
                        }
                    }
                } 
            }
            return con;
        }




    }
}
