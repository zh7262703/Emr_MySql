using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmPatientDiagnose : DevComponents.DotNetBar.Office2007Form
    {
        private string Id;
        public frmPatientDiagnose()
        {
            InitializeComponent();
        }
        public frmPatientDiagnose(string id)
        {
            InitializeComponent();
            Id = id;
            DataBind();
        }
        public void DataBind()
        {
            string sql = "select '' –Ú∫≈,name ’Ô∂œ,(case type when 'M' then '÷˜’Ô∂œ'  else '∆‰À¸’Ô∂œ' end) ’Ô∂œ¿‡–Õ from COVER_DIAGNOSE  where patient_id="+Id+" and type  not in ('S','P','E') order by type";
            DataSet ds=App.GetDataSet(sql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["–Ú∫≈"] = i + 1;
                    }
                    dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
                    dataGridViewX1.ReadOnly = true;
                }
            }
        }
    }
}