using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    public partial class frmWrite_Type_Order : DevComponents.DotNetBar.Office2007Form
    {
        private string fatherId = "";

        public frmWrite_Type_Order()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ³õÊ¼»¯
        /// </summary>
        /// <param name="fid">¸¸½ÚµãID</param>
        public frmWrite_Type_Order(string fid,int sindex)
        {
            InitializeComponent();
            fatherId = fid;
            ucWrite_Type.isShowNumChange = false;
            DataSet ds = App.GetDataSet("select a.code,a.name from t_data_code a inner join t_data_code_type b on a.type=b.id where b.type='pxfa001'");
            cboSortType.DisplayMember = "name";
            cboSortType.ValueMember = "code";
            cboSortType.DataSource = ds.Tables[0].DefaultView;
            cboSortType.SelectedIndex = sindex;

        }

        private void frmWrite_Type_Order_Load(object sender, EventArgs e)
        {
            btnReflesh_Click(sender, e);
            dataGridViewX1.AllowUserToAddRows = false;
        }

        private void btnReflesh_Click(object sender, EventArgs e)
        {
            DataSet ds = App.GetDataSet("select a.id,a.textname as Ãû³Æ,b.shownum as ÅÅÐòºÅÂë from t_text a left join t_text_sort b on a.id=b.text_id and b.sort_type='" + cboSortType.SelectedValue + "' where a.parentid='" + this.fatherId + "' order by b.shownum");
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            dataGridViewX1.ReadOnly = false;
            for (int i = 0; i < dataGridViewX1.Columns.Count; i++)
            {
                if (i == dataGridViewX1.Columns.Count - 1)
                    dataGridViewX1.Columns[i].ReadOnly = false;
                else
                    dataGridViewX1.Columns[i].ReadOnly = true;
            }
            #region ÅÅÐò×÷·Ï
            //try
            //{
            //    string sql_sort = "select c.text_id from t_text_sort c where c.sort_type=" + cboSortType.SelectedValue + " and c.parent_id=" + fatherId + "";
            //    DataSet ds_sort = App.GetDataSet(sql_sort);
            //    string sql = "select a.id,a.textname as Ãû³Æ ,b.shownum as ÅÅÐòºÅÂë from t_text a left join T_TEXT_SORT b on a.id=b.text_id ";
            //    if (ds_sort.Tables[0].Rows.Count > 0)
            //    {
            //        //ÓÐÅÅÐòÐÅÏ¢
            //        sql = sql + " where b.parent_id=" + fatherId + " and b.sort_type=" + cboSortType.SelectedValue + " order by b.shownum asc";
            //    }
            //    else
            //    {
            //        //ÎÞÅÅÐòÐÅÏ¢
            //        sql = sql + " where a.parentid=" + fatherId + " order by a.id asc";
            //    }


            //    //DataSet ds = App.GetDataSet("select id,t.textname as Ãû³Æ,t.shownum as ÅÅÐòºÅÂë from t_text t where t.parentid=" + fatherId + " and t.enable_flag='Y' order by t.shownum");
            //    DataSet ds = App.GetDataSet(sql);
            //    dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            //    for (int i = 0; i < dataGridViewX1.Columns.Count - 1; i++)
            //    {
            //        dataGridViewX1.Columns[i].ReadOnly = true;
            //    }
            //}
            //catch
            //{ }
            # endregion
        }

        /// <summary>
        /// ÐÞ¸ÄÅÅÐò
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnSure_Click(object sender, EventArgs e)
        {
            ArrayList sqls = new ArrayList();
            //string sql = "";
            string sql = "delete from T_TEXT_SORT where PARENT_ID=" + fatherId + " and SORT_TYPE=" + cboSortType.SelectedValue + "";
            sqls.Add(sql);
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                string shownum = "0";
                if (dataGridViewX1["ÅÅÐòºÅÂë", i].Value.ToString() != "")
                {
                    shownum = dataGridViewX1["ÅÅÐòºÅÂë", i].Value.ToString();
                }
                sql = "insert into T_TEXT_SORT(SORT_TYPE,TEXT_ID,PARENT_ID,SHOWNUM)values(" + cboSortType.SelectedValue + "," + dataGridViewX1["id", i].Value.ToString() + "," + fatherId + "," + shownum + ")";
                sqls.Add(sql);
                if (cboSortType.SelectedValue.ToString()=="1")
                {//ÐÞ¸Ät_textÅÅÐò
                    sql = "update t_text t set t.shownum=" + shownum + " where id=" + dataGridViewX1["id", i].Value.ToString() + "";
                    sqls.Add(sql);
                }
            }



            string[] strsqls = new string[sqls.Count];
            for (int i = 0; i < sqls.Count; i++)
            {
                strsqls[i] = sqls[i].ToString();
            }
            if (App.ExecuteBatch(strsqls) > 0)
            {
                ucWrite_Type.isShowNumChange = true;
                App.Msg("²Ù×÷ÒÑ¾­³É¹¦£¡");
                btnReflesh_Click(sender, e);

            }
            else
            {
                ucWrite_Type.isShowNumChange = false;
                App.Msg("²Ù×÷Ê§°Ü£¡");
            }
            //ArrayList sqls = new ArrayList();
            //for (int i = 1; i < dataGridViewX1.Rows.Count; i++)
            //{
            //    if (dataGridViewX1["ÅÅÐòºÅÂë", i].Value.ToString() != "")
            //    {
            //        string sql = "update t_text set shownum=" + dataGridViewX1["ÅÅÐòºÅÂë", i].Value.ToString() + " where id=" + dataGridViewX1["id", i].Value.ToString() + "";
            //        sqls.Add(sql);
            //    }
            //}
            //string[] strsqls = new string[sqls.Count];
            //for (int i = 0; i < sqls.Count; i++)
            //{
            //    strsqls[i] = sqls[i].ToString();
            //}
            //if (App.ExecuteBatch(strsqls) > 0)
            //{
            //    ucWrite_Type.isShowNumChange = true;
            //    App.Msg("²Ù×÷ÒÑ¾­³É¹¦£¡");
            //    btnReflesh_Click(sender, e);

            //}
            //else
            //{
            //    ucWrite_Type.isShowNumChange = false;
            //    App.Msg("²Ù×÷Ê§°Ü£¡");
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {           
            this.Close();
        }

        private void cboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnReflesh_Click(sender,e);
        }
    }
}