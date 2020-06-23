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
        /// ѡ�е���ҽ��ϼ���
        /// </summary>
        public List<DataRow> List
        {
            get { return list; }
            set { list = value; }
        }
        private List<DataRow> clist;
        /// <summary>
        /// ѡ�е���ҽ��ϼ���
        /// </summary>
        public List<DataRow> Clist
        {
            get { return clist; }
            set { clist = value; }
        }
        public void LoadData()
        {
            string sql="select distinct a.id,a.patient_id,a.diagnose_name as �������,a.diagnose_code as ����,b.trend_diagnose_name as ������� from t_simple_diagnose a";
            sql+=" left join t_simple_trend_diagnose b on  a.id=b.diagnoseitem_id";
            sql+=" where a.is_chinese is null";
            sql += " and a.patient_id=" + inpatient.Id;
            dtEdiag = Bifrost.App.GetDataSet(sql).Tables[0];
            DataColumn dc = new DataColumn("ѡ��");
            dc.Caption = "ѡ��";
            dc.DataType = typeof(bool);
            dtEdiag.Columns.Add(dc);
            string sqlCdiag = "select a.id as cid,a.patient_id as cpatientid,a.diagnose_name as ����,a.diagnose_code as ����,a.symptoms_name as ֢�� from t_simple_diagnose a where a.is_chinese='Y'";
            sqlCdiag += " and a.patient_id=" + inpatient.Id;
            dtCdiag = Bifrost.App.GetDataSet(sqlCdiag).Tables[0];
            dc = new DataColumn("ѡ��");
            dc.Caption = "ѡ��";
            dc.DataType = typeof(bool);
            dtCdiag.Columns.Add(dc);
            for (int i = 0; i < dtEdiag.Rows.Count; i++)
            {
                dtEdiag.Rows[i]["ѡ��"] = bool.FalseString;
            }
            this.dataGridViewX1.DataSource = dtEdiag;
            this.dataGridViewX2.DataSource = dtCdiag;
            for (int i = 0; i < dtCdiag.Rows.Count; i++)
            {
                dtCdiag.Rows[i]["ѡ��"] = bool.FalseString;
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
            //��ҽ
            for (int i = 0; i < dtCdiag.Rows.Count; i++)
            {
                if (dtCdiag.Rows[i]["ѡ��"].ToString() == bool.TrueString)
                {
                    clist.Add(dtCdiag.Rows[i]);
                }
            }
            //��ҽ
            for (int i = 0; i < dtEdiag.Rows.Count; i++)
            {
                if (dtEdiag.Rows[i]["ѡ��"].ToString() == bool.TrueString)
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
            if (dtEdiag.Columns[e.ColumnIndex].ColumnName == "ѡ��")
            {
                DataRow dr = dtEdiag.Rows[e.RowIndex];
                if (dr["ѡ��"].ToString() == bool.TrueString)
                {
                    string sql = "select count(*) from diag_def_icd10 where name='" + dr["�������"].ToString() + "'";
                    if (App.ReadSqlVal(sql, 0, "count(*)") == "0")
                    {
                        App.Msg("����ֵ���û��:"+dr["�������"].ToString()+",����ϲ���д�ص���ҳ�����,����ϵ��������Ӵ����!");
                        dr["ѡ��"] = bool.FalseString;
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
            if (dtCdiag.Columns[e.ColumnIndex].ColumnName == "ѡ��")
            {
                DataRow dr = dtCdiag.Rows[e.RowIndex];
                if (dr["ѡ��"].ToString() == bool.TrueString)
                {
                    string sql = "select count(*) from t_bm where bm_name='" + dr["����"].ToString() + "'";
                    if (App.ReadSqlVal(sql, 0, "count(*)") == "0")
                    {
                        App.Msg("��ҽ����ֵ���û��:"+ dr["����"].ToString() +",����ϲ���д����ҳ�����,����ϵ��������Ӵ����!");
                        dr["ѡ��"] = bool.FalseString;
                    }
                }
            }
        }


        
    }
}