using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using System.Collections;

namespace Base_Function.BASE_DATA
{
    public partial class frmBedInfo : Office2007Form
    {
        public string bedInfo_id = "";
        public string bedInfo_name = "";

        public frmBedInfo()
        {
            InitializeComponent();
        }

        private void frmBedInfo_Load(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtBedName.Text.Contains("'"))
            {
                App.Msg("该查询条件存在SQL注入的危险!");
                txtBedName.Focus();
                return;
            }
            sql = "select t.bed_id 床位编号,t.bed_no 床位名称,b.sick_area_name 床位所属病区 from T_SICKBEDINFO t left join T_SickAreaInfo b on t.said=b.said ";
            if (txtBedName.Text.Trim() != "")
            {
                sql = "select t.bed_id 床位编号,t.bed_no 床位名称,b.sick_area_name 床位所属病区 from T_SICKBEDINFO t left join T_SickAreaInfo b on t.said=b.said where t.bed_no like '%" + txtBedName.Text.Trim() + "%'";
            }
            DataSet ds=App.GetDataSet(sql);
            if(ds!=null)
            {
                dgvBedInfo.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void dgvBedInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvBedInfo.CurrentCell.RowIndex>=0)
            {
                int rowIndex = dgvBedInfo.CurrentCell.RowIndex;
                bedInfo_id = dgvBedInfo[0, rowIndex].Value.ToString();
                bedInfo_name = dgvBedInfo[1, rowIndex].Value.ToString();
            }
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgvBedInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}