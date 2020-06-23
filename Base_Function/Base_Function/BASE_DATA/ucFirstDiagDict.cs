using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    public partial class ucFirstDiagDict : UserControl
    {
        public ucFirstDiagDict()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            condition= " where a.name like '%" + txtVindicateName.Text.Trim() + "%'";
            condition += " or upper(a.shortcut1) like '%" + txtVindicateName.Text.Trim().ToUpper() + "%'";
            SetData();
        }
        private string sql = "";
        private string condition;
        private void SetData()
        {
            DataSet ds = App.GetDataSet(sql+condition);
            if (ds != null)
            {
                this.ucGridviewX1.DataBd(sql+condition, "’Ô∂œ√˚≥∆", false, "", "");
                ucGridviewX1.fg.ReadOnly = true;
                ucGridviewX1.fg.Columns[0].Width = 100;
                ucGridviewX1.fg.Columns[1].Width = 200;
                ucGridviewX1.fg.Columns[2].Width = 80;
                ucGridviewX1.fg.Columns[3].Width = 80;
                ucGridviewX1.fg.Columns[4].Width = 100;
            }
        }

        private void ucGridviewX1_Load(object sender, EventArgs e)
        {
            sql = "select a.code as ’Ô∂œ±‡¬Î,a.name as ’Ô∂œ√˚≥∆,a.shortcut1 as ∆¥“Ù¬Î,a.shortcut2 as ŒÂ± ¬Î,a.is_chinese as  «∑Ò÷–“Ω’Ô∂œ from diag_def_icd10 a";
            SetData();
        }

        private void txtVindicateName_TextChanged(object sender, EventArgs e)
        {
            btnQuery_Click(this, null);
        }
    }
}
