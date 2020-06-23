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
        /// ��ѯ
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
                    label2.Text = "������" + txtPatientId.Text + "  סԺ�ţ�" +
                                        ds_p.Tables[0].Rows[0]["pid"].ToString() + "  ������" +
                                        ds_p.Tables[0].Rows[0]["PATIENT_NAME"].ToString();
                    Sql = "select a.tid,a.textname as ��������,a.doc_name as �������� from t_patients_doc a where a.patient_id=" + txtPatientId.Text + "";

                    DataSet ds_doc = App.GetDataSet(Sql);
                    dataGridViewX1.DataSource = ds_doc.Tables[0].DefaultView;
                    dataGridViewX1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
                else
                {
                    App.Msg("û������");
                }
            }
            else
            {
                App.Msg("û������");
            }

           

        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ɾ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentRow != null)
            {
                if (dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value != null)
                {
                    if (dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString() != "")
                    {
                        if (App.Ask("����������" + dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString() +
                            ",��������:" + dataGridViewX1["��������", dataGridViewX1.CurrentRow.Index].Value.ToString() +
                            ",��������:" + dataGridViewX1["��������", dataGridViewX1.CurrentRow.Index].Value.ToString() + "��ɾ��֮�󣬽��޷��ָ�ȷ��Ҫɾ����"))
                        {

                            string[] sqls = new string[2];
                            sqls[0] = "delete from t_patients_doc t where t.patient_id=" + txtPatientId.Text + " and t.tid=" + dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString() + "";
                            sqls[1] = "delete from t_quality_text t where t.patient_id=" + txtPatientId.Text + " and tid=" + dataGridViewX1["tid", dataGridViewX1.CurrentRow.Index].Value.ToString() + "";
                            if (App.ExecuteBatch(sqls) > 0)
                            {
                                App.Msg("�����Ѿ��ɹ���");
                                btnQuarry_Click(sender, e);
                            }
                            else
                            {
                                App.MsgErr("����ʧ�ܣ�");
                            }
                        }
                    }
                    else
                    {
                        App.Msg("��ѡ��Ҫɾ�������飡");
                    }
                }
                else
                {
                    App.Msg("��ѡ��Ҫɾ�������飡");
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
                                App.Msg("�����Ѿ��ɹ���");
                            }
                            else
                            {
                                App.Msg("����ʧ�ܣ�");
                            }
                        }
                        else
                        {
                            App.Msg("����ʧ�ܣ�");
                        }
                    }
                }
            }

        }
        /// <summary>
        /// �Զ��鵵����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnguidang_Click(object sender, EventArgs e)
        {
            try
            {

                string sqlpatient = "select distinct a.id,a.pid from t_in_patient a  " +
"inner join t_inhospital_action b on a.id=b.patient_Id inner join t_sickbedinfo c on " +
"a.sick_bed_id=c.bed_id where b.next_id=0 and b.action_state=3 and b.action_type='����' and ROUND(TO_NUMBER(sysdate-to_date(to_char(b.happen_time,'yyyy-MM-dd'),'yyyy-MM-dd')))>" + numericUpDownday.Value.ToString() + "";

                DataSet ds = App.GetDataSet(sqlpatient);

                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string pid = ds.Tables[0].Rows[i]["pid"].ToString();
                        string patient_Id = ds.Tables[0].Rows[i]["id"].ToString();

                        StringBuilder strBuilder = new StringBuilder();
                        //����
                        string SqlNeaten_Nurse = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,patient_Id)" +
                                    " values ('" + pid + "',0,1,sysdate," + patient_Id + ")";
                        string SqlNeaten_Doctor = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,patient_Id)" +
                                        " values ('" + pid + "',1,1,sysdate," + patient_Id + ")";
                        //�鵵����
                        string SqlActions_History_Delete = "delete from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + patient_Id + "'";
                        string SqlActions_History = "insert into T_INHOSPITAL_ACTION_HISTORY select * from t_inhospital_action where patient_id='" + patient_Id + "' order by id";
                        string SqlActions = "delete from t_inhospital_action where patient_id='" + patient_Id + "'";
                        //ɾ����Ȩ��¼
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

                    App.Msg("�����Ѿ��ɹ�");
                }
                else
                {
                    App.Msg("û�з��Ͽ��Թ鵵�Ĳ���");
                }
            }
            catch (System.Exception ex)
            {
                App.MsgErr("�Զ��鵵ʧ�ܣ�ԭ��:" + ex.Message);
            }

        }

        /// <summary>
        /// �Զ����ɹ鵵ִ��ʱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoDocTime_Click(object sender, EventArgs e)
        {
           string sqlnormalpatient = "select distinct a.id,a.pid,b.happen_time,a.EXE_DOCUMENT_TIME from t_in_patient a " +
                                                "inner join t_inhospital_action b on a.id=b.patient_Id " +
                                                "inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id " +
                                                "where b.next_id=0 and b.action_state=3 and b.action_type='����'"; 
 
            /*
             *��Ժ�����Զ����ɹ鵵ʱ��
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
                   App.Msg("�����Ѿ��ɹ���");
               }
               else
               {
                   App.Msg("����ʧ�ܣ�");
               }
           }


        }
    }
}
