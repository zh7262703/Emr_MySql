using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class frmSelDiag : Form
    {
        public frmSelDiag()
        {
            InitializeComponent();
        }
        private Bifrost.InPatientInfo inpatient;
        public frmSelDiag(Bifrost.InPatientInfo _inpatient)
        {
            InitializeComponent();
            inpatient = _inpatient;
            LoadData();
            list = new List<DataRow>();
            clist = new List<DataRow>();
        }
        private DataTable dtEdiag;
        private DataTable dtCdiag;
        private List<DataRow> list;
        /// <summary>
        /// 选中的西医诊断集合
        /// </summary>
        public List<DataRow> List
        {
            get { return list; }
            set { list = value; }
        }
        private List<DataRow> clist;
        /// <summary>
        /// 选中的中医诊断集合
        /// </summary>
        public List<DataRow> Clist
        {
            get { return clist; }
            set { clist = value; }
        }
        public void LoadData()
        {
            string sql="select distinct a.id,a.patient_id,a.diagnose_name as 诊断名称,a.diagnose_code as 编码,b.trend_diagnose_name as 附属诊断 from t_simple_diagnose a";
            sql+=" left join t_simple_trend_diagnose b on  a.id=b.diagnoseitem_id";
            sql+=" where a.is_chinese is null";
            sql += " and a.patient_id=" + inpatient.Id;
            dtEdiag = Bifrost.App.GetDataSet(sql).Tables[0];
            DataColumn dc = new DataColumn("选择");
            dc.Caption = "选择";
            dc.DataType = typeof(bool);
            dtEdiag.Columns.Add(dc);
            string sqlCdiag = "select a.id as cid,a.patient_id as cpatientid,a.diagnose_name as 病名,a.diagnose_code as 编码,a.symptoms_name as 症候 from t_simple_diagnose a where a.is_chinese='Y'";
            sqlCdiag += " and a.patient_id=" + inpatient.Id;
            dtCdiag = Bifrost.App.GetDataSet(sqlCdiag).Tables[0];
            dc = new DataColumn("选择");
            dc.Caption = "选择";
            dc.DataType = typeof(bool);
            dtCdiag.Columns.Add(dc);
            for (int i = 0; i < dtEdiag.Rows.Count; i++)
            {
                dtEdiag.Rows[i]["选择"] = bool.FalseString;
            }
            this.dataGridViewX1.DataSource = dtEdiag;
            this.dataGridViewX2.DataSource = dtCdiag;
            for (int i = 0; i < dtCdiag.Rows.Count; i++)
            {
                dtCdiag.Rows[i]["选择"] = bool.FalseString;
            }
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
 
        }

        private void dataGridViewX2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //中医
            for (int i = 0; i < dtCdiag.Rows.Count; i++)
            {
                if (dtCdiag.Rows[i]["选择"].ToString() == bool.TrueString)
                {
                    clist.Add(dtCdiag.Rows[i]);
                }
            }
            //西医
            for (int i = 0; i < dtEdiag.Rows.Count; i++)
            {
                if (dtEdiag.Rows[i]["选择"].ToString() == bool.TrueString)
                {
                    list.Add(dtEdiag.Rows[i]);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex < 0)
                return;
            if (dtEdiag.Columns[e.ColumnIndex].ColumnName == "选择")
            {
                DataRow dr = dtEdiag.Rows[e.RowIndex];
                if (dr["选择"].ToString() == bool.TrueString)
                {
                    string sql = "select count(*) from diag_def_icd10 where name='" + dr["诊断名称"].ToString() + "'";
                    if (App.ReadSqlVal(sql, 0, "count(*)") == "0")
                    {
                        App.Msg("诊断字典中没有:"+dr["诊断名称"].ToString()+",此诊断不能写回到首页诊断中,请联系病案室添加此诊断!");
                        dr["选择"] = bool.FalseString;
                    }
                }
            }
        }

        private void dataGridViewX2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex < 0)
                return;
            if (dtCdiag.Columns[e.ColumnIndex].ColumnName == "选择")
            {
                DataRow dr = dtCdiag.Rows[e.RowIndex];
                if (dr["选择"].ToString() == bool.TrueString)
                {
                    string sql = "select count(*) from t_bm where bm_name='" + dr["病名"].ToString() + "'";
                    if (App.ReadSqlVal(sql, 0, "count(*)") == "0")
                    {
                        App.Msg("中医诊断字典中没有:"+ dr["病名"].ToString() +",此诊断不能写回首页诊断中,请联系病案室添加此诊断!");
                        dr["选择"] = bool.FalseString;
                    }
                }
            }
        }


        
    }
}