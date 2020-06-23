using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_FOLLOW;

namespace Base_Function.BASE_DATA
{
    public partial class frmFollowWrite_Type_Order : DevComponents.DotNetBar.Office2007Form
    {
        private string fatherId = "";

        public frmFollowWrite_Type_Order()
        {
            InitializeComponent();
        }
        public frmFollowWrite_Type_Order(string fid)
        {
            InitializeComponent();
            fatherId = fid;
            ucFollowWrite_Type.isShowNumChange = false;
        }

        private void frmFollowWrite_Type_Order_Load(object sender, EventArgs e)
        {
            btnReflesh_Click(sender, e);
            dataGridViewX1.AllowUserToAddRows = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReflesh_Click(object sender, EventArgs e)
        {
            DataSet ds = App.GetDataSet("select id,t.textname as Ãû³Æ,t.shownum as ÅÅÐòºÅÂë from t_follow_text t where t.parentid=" + fatherId + " and t.enable_flag='Y' order by t.shownum");
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            for (int i = 0; i < dataGridViewX1.Columns.Count - 1; i++)
            {
                dataGridViewX1.Columns[i].ReadOnly = true;
            }
        }
        /// <summary>
        /// ÐÞ¸ÄÅÅÐò
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            ArrayList sqls = new ArrayList();
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                if (dataGridViewX1["ÅÅÐòºÅÂë", i].Value.ToString() != "")
                {
                    string sql = "update t_follow_text set shownum='" + dataGridViewX1["ÅÅÐòºÅÂë", i].Value.ToString() + "' where id=" + dataGridViewX1["id", i].Value.ToString() + "";
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
                ucFollowWrite_Type.isShowNumChange = true;
                App.Msg("²Ù×÷ÒÑ¾­³É¹¦£¡");
                btnReflesh_Click(sender, e);

            }
            else
            {
                ucFollowWrite_Type.isShowNumChange = false;
                App.Msg("²Ù×÷Ê§°Ü£¡");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}