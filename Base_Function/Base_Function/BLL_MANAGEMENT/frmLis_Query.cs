using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class frmLis_Query : DevComponents.DotNetBar.Office2007Form
    {
        public string sql = "";
        public frmLis_Query()
        {
            InitializeComponent();
        }
        public frmLis_Query(string sql_data)
        {
            InitializeComponent();
            sql = sql_data;
        }

        public void ClickGrid(object sender, EventArgs e)
        {
            string pid = ucGridviewX1.fg.SelectedRows[0].Cells["住院号"].Value.ToString();
            //string patient_name= ucGridviewX1.fg.SelectedRows[0].Cells["病人名称"].Value.ToString();
            //string in_time = ucGridviewX1.fg.SelectedRows[0].Cells["入院时间"].Value.ToString();
            if (pid != "")
            {
                //string Sqlcondition = " and b.yzxmmc='" + btlis.Text + "' and jyrq=to_date('" + datetimes + "','yyyy-MM-dd')";

                string Sqlcondition = " and b.yzxmmc='" + pid + "'";
                Bifrost.HisInstance.FrmLis frm = new Bifrost.HisInstance.FrmLis(pid);
                frm.ShowDialog();
            }
            else
            {
                this.Close();
            }
        }

        private void ucGridviewX1_Load(object sender, EventArgs e)
        {
            ucGridviewX1.fg.ReadOnly = true;
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.Click += new EventHandler(ClickGrid);
            ucGridviewX1.DataBd(sql, "住院号", "", "");
        }

        private void frmLis_Query_Load(object sender, EventArgs e)
        {

        }
    }
}