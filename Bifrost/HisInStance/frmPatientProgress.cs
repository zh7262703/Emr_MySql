using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.HisInStance
{
    public partial class frmPatientProgress :DevComponents.DotNetBar.Office2007Form
    {
        

        public frmPatientProgress()
        {
            InitializeComponent();
        }

        private void frmPatientProgress_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ≤È—Ø
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string Sql = "select distinct xmdm,xmmc from t_lis_result t where  t.cssj is not null and to_date(t.cssj,'YYYY-MM-DD HH24:MI:SS') between to_date('" + dateTimePicker1.Value.ToLongTimeString() + "','yyyy-MM-dd') and to_date('" + dateTimePicker2.Value.ToLongTimeString() + "','yyyy-MM-dd') and ";
            DataSet dsItes = App.GetDataSet(Sql);
        }
    }
}