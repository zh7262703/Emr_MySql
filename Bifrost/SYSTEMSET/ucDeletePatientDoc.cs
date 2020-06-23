using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Bifrost.SYSTEMSET
{
    public partial class ucDeletePatientDoc : UserControl
    {       
        public ucDeletePatientDoc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuarry_Click(object sender, EventArgs e)
        {
            string Sql = "select * from t_in_patient t where t.id=" + txtPatientId.Text+ "";
            DataSet ds_p=App.GetDataSet(Sql);
            if (ds_p != null)
            {
                if (ds_p.Tables[0].Rows.Count > 0)
                {
                    label2.Text = "主键：" + txtPatientId.Text + "  住院号：" +
                                        ds_p.Tables[0].Rows[0]["pid"].ToString() + "  姓名：" +
                                        ds_p.Tables[0].Rows[0]["PATIENT_NAME"].ToString();
                    Sql = "select a.tid,a.textname as 文书类型,b.textname as 文书名称 from t_patients_doc a inner join t_quality_text b on a.tid=b.tid where a.patient_id=" + txtPatientId.Text + "";

                    DataSet ds_doc = App.GetDataSet(Sql);
                    dataGridViewX1.DataSource = ds_doc.Tables[0].DefaultView;
                    dataGridViewX1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else
                {
                    App.Msg("没有数据");
                }
            }
            else
            {
                App.Msg("没有数据");
            }

           

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 删除文书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentRow != null)
            {
                if (dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value != null)
                {
                    if (dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString() != "")
                    {
                        if (App.Ask("文书主键：" + dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString() +
                            ",文书类型:" + dataGridViewX1["文书类型", dataGridViewX1.CurrentRow.Index].Value.ToString() +
                            ",文书名称:" + dataGridViewX1["文书名称", dataGridViewX1.CurrentRow.Index].Value.ToString() + "。删除之后，将无法恢复确定要删除吗？"))
                        {

                            string[] sqls = new string[2];
                            sqls[0] = "delete from t_patients_doc t where t.patient_id=" + txtPatientId.Text + " and t.tid=" + dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString() + "";
                            sqls[1] = "delete from t_quality_text t where t.patient_id=" + txtPatientId.Text + " and tid=" + dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString() + "";
                            if (App.ExecuteBatch(sqls) > 0)
                            {
                                App.Msg("操作已经成功！");
                                btnQuarry_Click(sender, e);
                            }
                            else
                            {
                                App.MsgErr("操作失败！");
                            }
                        }
                    }
                    else
                    {
                        App.Msg("请选择要删除的文书！");
                    }
                }
                else
                {
                    App.Msg("请选择要删除的文书！");
                }
            }
        }

        /// <summary>
        /// 同步一下DocName        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentRow != null)
            {
                if (dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value != null)
                {
                    if (dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString() != "")
                    {
                        string tid = dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString();
                        string strdoc = App.GetDataSet("select PATIENTS_DOC from T_PATIENTS_DOC where tid=" + tid + "").Tables[0].Rows[0][0].ToString();
                        XmlDocument docxml = new XmlDocument();
                        docxml.LoadXml(strdoc);

                        string tittlename = docxml.ChildNodes[0].ChildNodes[0].Attributes["title"].Value.ToString();

                        if (tittlename != "")
                        {

                            if (App.ExecuteSQL("update T_PATIENTS_DOC set DOC_NAME='" + tittlename + "' where tid=" + tid + "") > 0)
                            {
                                App.Msg("操作已经成功！");
                            }
                            else
                            {
                                App.Msg("操作失败！");
                            }
                        }
                        else
                        {
                            App.Msg("操作失败！");
                        }
                    }
                }
            }
        }
    }
}
