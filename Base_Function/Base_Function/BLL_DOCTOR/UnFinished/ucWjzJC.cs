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
    public partial class ucWjzJC : UserControl
    {
        public InPatientInfo inpatient;
        public int Count = 0;

        public ucWjzJC()
        {
            InitializeComponent();
        }
        public ucWjzJC(InPatientInfo info)
        {
            InitializeComponent();
            inpatient = info;
            BindDgv();
            RefDgv();
        }


        private void ucWjzJC_Load(object sender, EventArgs e)
        {
   
        }

        private void RefDgv()
        {
            int a = 0;
            if (dgvJC.Rows.Count > 0)
            {
                for (int i = 0; i < dgvJC.Rows.Count; i++)
                {
                    if (dgvJC.Rows[i].Cells["zt"].Value.ToString() == "未读")
                    {
                        dgvJC.Rows[i].Cells["zt"].Style.ForeColor = Color.Red;
                        a++;
                    }
                    else
                    {
                        dgvJC.Rows[i].Cells["zt"].Style.ForeColor = Color.Black;
                    }
                }
            }
            Count = a;
        }

        private void BindDgv()
        {
            dgvJC.Rows.Clear();
            string sql = "select * from t_pasc_data";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvJC.Rows.Add();
                    dgvJC.Rows[i].Cells["xh"].Value = (i + 1).ToString();
                    dgvJC.Rows[i].Cells["jcdmc"].Value = ds.Tables[0].Rows[i]["method"].ToString();
                    dgvJC.Rows[i].Cells["jcrq"].Value =DateTime.Parse(ds.Tables[0].Rows[i]["sqsj"].ToString()).ToString("yyyy-MM-dd");
                    dgvJC.Rows[i].Cells["wjznr"].Value = ds.Tables[0].Rows[i]["zdbg"].ToString();
                    dgvJC.Rows[i].Cells["zt"].Value = ds.Tables[0].Rows[i]["zt"].ToString();
                    if (ds.Tables[0].Rows[i]["zt"].ToString() == "1")
                    {
                        dgvJC.Rows[i].Cells["zt"].Value = "已读";
                    }
                    else
                    {
                        dgvJC.Rows[i].Cells["zt"].Value = "未读";

                    }
                }
            }

            //演示用测试数据

            if (dgvJC.Rows.Count == 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    dgvJC.Rows.Add();
                    dgvJC.Rows[i].Cells["xh"].Value = (i + 1).ToString();
                }
                dgvJC.Rows[0].Cells["jcdmc"].Value = "心电图";
                dgvJC.Rows[0].Cells["jcrq"].Value = "2016-01-03";
                dgvJC.Rows[0].Cells["wjznr"].Value = "急性心肌梗死";
                dgvJC.Rows[0].Cells["zt"].Value = "未读";

                dgvJC.Rows[1].Cells["jcdmc"].Value = "B超";
                dgvJC.Rows[1].Cells["jcrq"].Value = "2016-01-13";
                dgvJC.Rows[1].Cells["wjznr"].Value = "2222222222";
                dgvJC.Rows[1].Cells["zt"].Value = "未读";

            }
        }

        private void dgvJC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //测试数据
            if (e.RowIndex != -1)
            {
                dgvJC.Rows[e.RowIndex].Cells["zt"].Value = "已读";
            }

            RefDgv();
        }

        private void dgvJC_KeyDown(object sender, KeyEventArgs e)
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
            if (dgvJC.Rows.Count > 0)
            {
                for (int i = 0; i < dgvJC.Rows.Count; i++)
                {
                    if (dgvJC.Rows[i].Selected == true)
                    {
                        string xmmc = dgvJC.Rows[i].Cells["jcdmc"].Value.ToString();
                        string xmjg = dgvJC.Rows[i].Cells["jcrq"].Value.ToString();
                        string dw = dgvJC.Rows[i].Cells["wjznr"].Value.ToString();
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

        private void buttonX1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvJC.Rows.Count; i++)
            {
                dgvJC.Rows[i].Cells["zt"].Value = "已读";
            }
            RefDgv();
        }


    }

}
