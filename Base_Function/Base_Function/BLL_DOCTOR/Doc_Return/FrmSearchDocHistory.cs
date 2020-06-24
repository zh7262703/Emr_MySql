using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

using System.Collections;

namespace Base_Function.BLL_DOCTOR.Doc_Return
{
    /// <summary>
    /// �鿴�˻غ����������޸ĵ�����
    /// </summary>
    public partial class FrmSearchDocHistory : DevComponents.DotNetBar.Office2007Form
    {
        public FrmSearchDocHistory()
        {
            InitializeComponent();
        }
       
        /// <summary>
        /// ���һ���˻�ʱ��
        /// </summary>
        string lastTime = "";
        /// <summary>
        /// ��������
        /// </summary>
        string patient_id = "";
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patient_id">��������</param>
        public FrmSearchDocHistory(string patient_id, string lastTime, string name, string inTime, string pid, string sectionName)
        {
            InitializeComponent();
            //sql_req_history = "select (select c.textname from t_patients_doc b inner join t_text c on b.textkind_id=c.id where tid=a.tid) ��������,to_char(a.oper_time,'yyyy-MM-dd HH24:mi:ss') ����ʱ��,(select user_name from t_userinfo where user_id=a.operator_user_id) ������,content �������� from t_operate_log a where patient_id=" + patient_id + " and to_char(oper_time,'yyyy-MM-dd HH24:mi:ss')>'" + lastTime + "'";
            this.lastTime = lastTime;
            this.patient_id = patient_id;
            this.lblName.Text = name;
            this.lblInTime.Text = inTime;
            this.lblPid.Text = pid;
            this.lblSection.Text = sectionName;
            this.lblLastTime.Text = lastTime;
        }

        private void FrmSearchDocHistory_Load(object sender, EventArgs e)
        {
            try
            {
                //����˻�ǰ����������ID
                string sql_tid = "select distinct tid from t_operate_log a where a.patient_id="+patient_id+" and to_char(a.oper_time,'yyyy-MM-dd HH24:mi:ss')<'" + lastTime + "' and tid is not null";

                DataSet ds_tids = App.GetDataSet(sql_tid);
                ArrayList arr_tids = new ArrayList();//����id����
                string str_tids = "";//ɸѡ����

                if (ds_tids != null)
                {
                    for (int i = 0; i < ds_tids.Tables[0].Rows.Count; i++)
                    {
                        arr_tids.Add(ds_tids.Tables[0].Rows[i]["tid"].ToString());
                        //ƴ��ɸѡ����
                        if (str_tids == "")
                        {
                            str_tids = ds_tids.Tables[0].Rows[i]["tid"].ToString();
                        }
                        else
                        {
                            str_tids += "," + ds_tids.Tables[0].Rows[i]["tid"].ToString();
                        }
                    }
                }

                Class_Table[] tables = new Class_Table[3];

                //��ѯ�´���������
                string sql_create = "select a.tid,c.textname ��������, b.doc_name ��������,to_char(a.oper_time,'yyyy-MM-dd HH24:mi:ss') ����ʱ��,d.user_name ������,a.content �������� from t_operate_log a " +
                                    " inner join t_patients_doc b on a.tid=b.tid and a.patient_id=b.patient_id " +
                                    " inner join t_text c on b.textkind_id=c.id" +
                                    " inner join t_userinfo d on a.operator_user_id=d.user_id" +
                                    " where a.patient_id=" + patient_id + "  and a.content='����' and to_char(a.oper_time,'yyyy-MM-dd HH24:mi:ss')>'" + lastTime + "'";
                //��ѯ�޸ĵ����飨�����һ���˻�ʱ��֮ǰ�������������һ���˻�ʱ��֮���޸ĵ����飩
                string sql_update = "select a.tid,c.textname ��������, b.doc_name ��������,to_char(a.oper_time,'yyyy-MM-dd HH24:mi:ss') ����ʱ��,d.user_name ������,a.content �������� from t_operate_log a " +
                                    " inner join t_patients_doc b on a.tid=b.tid and a.patient_id=b.patient_id " +
                                    " inner join t_text c on b.textkind_id=c.id" +
                                    " inner join t_userinfo d on a.operator_user_id=d.user_id" +
                                    " where a.patient_id=" + patient_id + "  and a.content='�޸�' and to_char(a.oper_time,'yyyy-MM-dd HH24:mi:ss')>'" + lastTime + "'";
                //��ѯɾ��������(�����һ���˻�ʱ��֮ǰ�������������һ���˻�ʱ��֮��ɾ��������)
                string sql_delete = "select a.tid,c.textname ��������, b.doc_name ��������,to_char(a.oper_time,'yyyy-MM-dd HH24:mi:ss') ����ʱ��,d.user_name ������,a.content �������� from t_operate_log a " +
                                    " inner join t_patients_doc_delhistory b on a.tid=b.tid and a.patient_id=b.patient_id " +
                                    " inner join t_text c on b.textkind_id=c.id" +
                                    " inner join t_userinfo d on a.operator_user_id=d.user_id" +
                                    " where a.patient_id=" + patient_id + "  and a.content='ɾ��' and to_char(a.oper_time,'yyyy-MM-dd HH24:mi:ss')>'" + lastTime + "'";

                tables[0] = new Class_Table();
                tables[0].Sql = sql_create;
                tables[0].Tablename = "create";

                tables[1] = new Class_Table();
                tables[1].Sql = sql_update;
                tables[1].Tablename = "update";

                tables[2] = new Class_Table();
                tables[2].Sql = sql_delete;
                tables[2].Tablename = "delete";

                DataSet ds = App.GetDataSet(tables);
                if (ds != null)
                {//ɾ������
                    if (ds.Tables["delete"].Rows.Count > 0)
                    {

                        DataRow[] dr_delete = ds.Tables["delete"].Select("tid in (" + str_tids + ")").Clone() as DataRow[];
                        for (int i = 0; i < dr_delete.Length; i++)
                        {
                            ds.Tables["create"].Rows.Add(dr_delete[i].ItemArray);
                            arr_tids.Remove(dr_delete[i]["tid"].ToString());
                        }
                    }
                    str_tids = "";//���ɸѡ����������ƴ��
                    for (int i = 0; i < arr_tids.Count; i++)
                    {
                        if (str_tids == "")
                        {
                            str_tids = arr_tids[i].ToString();
                        }
                        else
                        {
                            str_tids += ","+arr_tids[i].ToString();
                        }
                    }
                    //�޸�����
                    if (ds.Tables["update"].Rows.Count > 0)
                    {
                        DataRow[] dr_update = ds.Tables["update"].Select("tid in(" + str_tids + ")").Clone() as DataRow[];
                        
                        for (int i = 0; i < dr_update.Length; i++)
                        {
                            bool isAdd = true;
                            //ȥ��ͬһ������Ķ���޸�
                            if (dr_update.Length > 1&& dr_update.Length>i+1)
                            {
                                if (dr_update[i]["tid"].ToString() == dr_update[i + 1]["tid"].ToString())//����ID��ͬ
                                {
                                    isAdd = false;
                                }
                            }
                            if (isAdd)
                            {
                                ds.Tables["create"].Rows.Add(dr_update[i].ItemArray);
                            }
                        }
                    }


                    //�½�����󶨵����
                    if (ds.Tables["create"].Rows.Count > 0)
                    {
                        dgvDoc.DataSource = ds.Tables["create"];
                        dgvDoc.Columns[0].Visible = false;
                        //dgvDoc.Columns[1].Width = 150;
                        //dgvDoc.Columns[2].Width = 150;
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}