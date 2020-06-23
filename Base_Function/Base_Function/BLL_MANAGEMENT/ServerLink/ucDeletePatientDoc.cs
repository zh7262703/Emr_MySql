using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.ServerLink
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
                    Sql = "select a.tid,a.textname as 文书类型,a.doc_name as 文书名称 from t_patients_doc a where a.patient_id=" + txtPatientId.Text + "";

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
                        string tittlename="";
                        for (int i = 0; i < docxml.ChildNodes[0].ChildNodes.Count; i++)
                        {
                            if (docxml.ChildNodes[0].ChildNodes[i].Name == "body")
                            {
                                tittlename = docxml.ChildNodes[0].ChildNodes[i].FirstChild.Attributes["title"].Value.ToString();
                                break;
                            }
                        }
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
        /// <summary>
        /// 自动归档操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnguidang_Click(object sender, EventArgs e)
        {
            try
            {

                string sqlpatient = "select distinct a.id,a.pid from t_in_patient a  " +
"inner join t_inhospital_action b on a.id=b.patient_Id inner join t_sickbedinfo c on " +
"a.sick_bed_id=c.bed_id where b.next_id=0 and b.action_state=3 and b.action_type='出区' and ROUND(TO_NUMBER(sysdate-to_date(to_char(b.happen_time,'yyyy-MM-dd'),'yyyy-MM-dd')))>" + numericUpDownday.Value.ToString() + "";

                DataSet ds = App.GetDataSet(sqlpatient);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string pid = ds.Tables[0].Rows[i]["pid"].ToString();
                        string patient_Id = ds.Tables[0].Rows[i]["id"].ToString();

                        StringBuilder strBuilder = new StringBuilder();
                        //整理
                        string SqlNeaten_Nurse = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,patient_Id)" +
                                    " values ('" + pid + "',0,1,sysdate," + patient_Id + ")";
                        string SqlNeaten_Doctor = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,patient_Id)" +
                                        " values ('" + pid + "',1,1,sysdate," + patient_Id + ")";
                        //归档操作
                        string SqlActions_History_Delete = "delete from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + patient_Id + "'";
                        string SqlActions_History = "insert into T_INHOSPITAL_ACTION_HISTORY select * from t_inhospital_action where patient_id='" + patient_Id + "' order by id";
                        string SqlActions = "delete from t_inhospital_action where patient_id='" + patient_Id + "'";
                        //删除授权记录
                        string sql = "update t_in_patient  set document_state='1',document_time=sysdate,DOCUMENT_OPER_ID=" + App.UserAccount.UserInfo.User_id + " where id='" + patient_Id + "'";
                        string sqlDocRight = "delete from t_set_text_rights aa where aa.patient_id=" + patient_Id;
                        strBuilder.Append(SqlNeaten_Nurse + ";");
                        strBuilder.Append(SqlNeaten_Doctor + ";");
                        strBuilder.Append(SqlActions_History_Delete + ";");
                        strBuilder.Append(SqlActions_History + ";");
                        strBuilder.Append(SqlActions + ";");
                        strBuilder.Append(sql + ";");
                        strBuilder.Append(sqlDocRight + ";");
                        string[] arr = strBuilder.ToString().Substring(0, strBuilder.Length - 1).Split(';');
                        App.ExecuteBatch(arr);
                    }

                    App.Msg("操作已经成功");
                }
                else
                {
                    App.Msg("没有符合可以归档的病人");
                }
            }
            catch (System.Exception ex)
            {
                App.MsgErr("自动归档失败！原因:" + ex.Message);
            }

        }

        /// <summary>
        /// 自动生成归档执行时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoDocTime_Click(object sender, EventArgs e)
        {
           string sqlnormalpatient = "select distinct a.id,a.pid,b.happen_time,a.EXE_DOCUMENT_TIME from t_in_patient a " +
                                                "inner join t_inhospital_action b on a.id=b.patient_Id " +
                                                "inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id " +
                                                "where b.next_id=0 and b.action_state=3 and b.action_type='出区'"; 
 
            /*
             *出院病人自动生成归档时间
             */
           DataSet ds = App.GetDataSet(sqlnormalpatient);
           List<string> sqls = new List<string>();
           if (ds != null)
           {
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   string id = ds.Tables[0].Rows[i]["id"].ToString();
                   DateTime outtime = Convert.ToDateTime(ds.Tables[0].Rows[i]["happen_time"]);
                   string exe_doc_time = outtime.AddDays(5).ToString("yyyy-MM-dd");
                   string strsql = "update t_in_patient set EXE_DOCUMENT_TIME=to_timestamp('" + exe_doc_time + "','yyyy-MM-dd') where id=" + id + "";
                   sqls.Add(strsql);
               }
               if (App.ExecuteBatch(sqls.ToArray()) > 0)
               {
                   App.Msg("操作已经成功！");
               }
               else
               {
                   App.Msg("操作失败！");
               }
           }


        }
    }
}
