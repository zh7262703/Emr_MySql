using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.EMERGENCY
{
    public partial class ucOutPatient : UserControl
    {
        public ucOutPatient()
        {
            InitializeComponent();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select id 编号,name 姓名,sex 性别,to_char(intime,'yyyy-MM-dd HH24:mi:ss') 入院时间,to_char(outtime,'yyyy-MM-dd HH24:mi:ss') 出院时间 from jjhz where 1=1 and type=0 and to_char(intime,'yyyy-MM-dd') between '" + dtiStart.Text + "' and '" + dtiEnd.Text + "' ";
                if (txtName.Text != "")
                {
                    sql += "and name='" + txtName.Text + "'";
                }
                sql += "order by id";

                DataSet ds = App.GetDataSet(sql);
                dataGridViewX1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {

            }
        }

        private void dataGridViewX1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewX1.CurrentRow != null)
            {
                string id = dataGridViewX1.CurrentRow.Cells["编号"].Value.ToString();
                ucJZ ucJz = new ucJZ(id);
                App.UsControlStyle(ucJz);
                App.AddNewBusUcControl(ucJz, "出院患者");
            }
        }
    }
}
