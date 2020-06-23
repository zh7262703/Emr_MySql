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
    public partial class ucList : UserControl
    {
        public ucList(string strid)
        {
            InitializeComponent();
            id = strid;
        }
        string id = "";

        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                string type = "";
                string where = "";
                if (id == "424" || id == "425")
                {
                    switch (id)
                    {
                        case "424":
                            type = "a.hzzg";
                            break;
                        case "425":
                            type = "a.YCXDCS";
                            break;
                    }
                    sql = "select to_char(b.outtime,'mm') as 月份,floor(count(case " + type + " when 1 then " + type + " end)/count(*)*100) as \"比例(%)\" " +
                                  "from jjhz_cont_time a " +
                                  "inner join jjhz b on a.id=b.id " +
                                  "where b.type=0 and to_char(b.outtime,'YYYY-MM-DD'）between '" + dtiStart.Text + "' and '" + dtiEnd.Text + "'" +
                                  "group by to_char(b.outtime,'mm') " +
                                  "order by to_char(b.outtime,'mm')";
                    DataSet ds = App.GetDataSet(sql);
                    dataGridViewX1.DataSource = ds.Tables[0];
                    dataGridViewX1.Columns["月份"].Width = 60;
                    dataGridViewX1.Columns["比例(%)"].Width = 130;
                }
                else
                {
                    switch (id)
                    {
                        case "419":
                            type = "scxdt-scyljc";
                            where = " and scxdt is not null and scyljc is not null ";
                            break;
                        case "420":
                        case "426":
                            type = "XDTCS-scyljc";
                            where = " and XDTCS is not null and scyljc is not null ";
                            break;
                        case "421":
                            type = "FZJCBG-scyljc";
                            where = " and FZJCBG is not null and scyljc is not null ";
                            break;
                        case "422":
                        case "423":
                            type = "QNKZ-scyljc";
                            where = " and QNKZ is not null and scyljc is not null ";
                            break;
                        case "427":
                            type = "QDDGS-scyljc";
                            where = " and QDDGS is not null and scyljc is not null ";
                            break;
                        case "428":
                        case "429":
                            type = "HZDDGS-JDJRSS";
                            where = " and HZDDGS is not null and JDJRSS is not null ";
                            break;
                        case "430":
                            type = "RSZL-scyljc";
                            where = " and RSZL is not null and scyljc is not null ";
                            break;
                        case "431":
                            type = "QNKZ-DDBYDM";
                            where = " and QNKZ is not null and DDBYDM is not null ";
                            break;
                    }
                    sql = "select to_char(b.outtime,'mm') as 月份,avg(floor((" + type + ")*24*60)) as \"平均时间(分)\" " +
                                  "from jjhz_cont_time a " +
                                  "inner join jjhz b on a.id=b.id " +
                                  "where b.type=0 and to_char(b.outtime,'YYYY-MM-DD'）between '" + dtiStart.Text + "' and '" + dtiEnd.Text + "'" + 
                                  where +
                                  "group by to_char(b.outtime,'mm') " +
                                  "order by to_char(b.outtime,'mm')";
                    DataSet ds = App.GetDataSet(sql);
                    dataGridViewX1.DataSource = ds.Tables[0];
                    dataGridViewX1.Columns["月份"].Width = 60;
                    dataGridViewX1.Columns["平均时间(分)"].Width = 130;
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void 查看折线图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = dataGridViewX1.DataSource as DataTable;
            frmZXT zxt = new frmZXT(dt);
            zxt.Show();
        }
    }
}
