using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class frmSortDiagnose : DevComponents.DotNetBar.Office2007Form
    {
        public frmSortDiagnose()
        {
            InitializeComponent();
        }
        DataTable dt;
        List<ucOtherDiagnose> list;
        public frmSortDiagnose(DataTable _dt,List<ucOtherDiagnose>_list)
        {
            InitializeComponent();
            dt = _dt;
            list = _list;
            dt.DefaultView.Sort = "id asc";
            this.dataGridViewX1.DataSource = dt;
        }
        private void ClearValue()
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].OtherDiagnose = "";
                list[i].ICD10 = "";
                list[i].InCondition = "";
            }
        }
        /// <summary>
        /// 选中行上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count > 0)
            {
                string cid=dataGridViewX1.SelectedRows[0].Cells["id"].Value.ToString();
                int nid = int.Parse(cid);
                if (nid > 1)
                {
                    SwapRowData(nid - 1, nid - 2);
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[nid - 2].Cells[0];
                }     
            }
        }
        /// <summary>
        /// 选中行下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count > 0)
            {
                string cid = dataGridViewX1.SelectedRows[0].Cells["id"].Value.ToString();
                int nid = int.Parse(cid);
                if (nid < dt.Rows.Count)
                {
                    SwapRowData(nid - 1, nid);
                    dataGridViewX1.CurrentCell = dataGridViewX1.Rows[nid].Cells[0];
                }
            }
            
        }
        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX3_Click(object sender, EventArgs e)
        {
            ClearValue();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                list[i].OtherDiagnose = dr["name"].ToString();
                list[i].ICD10 = dr["icd10"].ToString();
                list[i].InCondition = dr["incondition"].ToString();
                list[i].Ischinese = dr["ischinese"].ToString() == "Y" ? true : false;
                list[i].SetCheckBox(list[i].Ischinese);
            }
            this.Close();
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SwapRowData(int index1, int index2)
        {
            if (index1 < 0 || index2 < 0 || index1 >= dt.Rows.Count || index2 >= dt.Rows.Count)
                return;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string strColName = dt.Columns[i].ColumnName;
                switch (strColName)
                {
                    case"id":
                        break;
                    case "icd10":
                    case "name":
                    case "incondition":
                    case"ischinese":
                        string strTemp = dt.Rows[index1][i].ToString();
                        dt.Rows[index1][i] = dt.Rows[index2][i].ToString();
                        dt.Rows[index2][i] = strTemp;
                        break;
                }
            }
        }
    }
}