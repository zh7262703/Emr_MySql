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
                    Sql = "select a.tid,a.textname as ��������,b.textname as �������� from t_patients_doc a inner join t_quality_text b on a.tid=b.tid where a.patient_id=" + txtPatientId.Text + "";

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

        /// <summary>
        /// ͬ��һ��DocName        
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
    }
}
