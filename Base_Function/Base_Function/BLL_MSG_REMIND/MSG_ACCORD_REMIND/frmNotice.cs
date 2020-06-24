using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

using System.Collections.Specialized;
using System.Collections;

namespace Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND
{
    public partial class frmNotice : DevComponents.DotNetBar.Office2007Form
    {
        //��ǰ����
        InPatientInfo currPatient;
        public frmNotice()
        {
            InitializeComponent();
        }
        public frmNotice(InPatientInfo patient)
        {
            InitializeComponent();
            currPatient = patient;
        }
        private void ucNotice_Load(object sender, EventArgs e)
        {
            try
            {
                // �趨����Header�����е�Ԫ����п��Զ����� 
                dgvNewMsg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvReadMsg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //���ò�����Ϣ
                SetPatientInfo();
                //�󶨱������
                DataBand();
                ListDictionary ldPathography = new ListDictionary();//�Ƿ���Ҫ�ظ�
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// ������
        /// </summary>
        private void DataBand()
        {
            string sql_NewMsg = "select id,pid,type_id,type_name,content,content_id,to_char(add_time,'yyyy-MM-dd hh24:mi:ss') add_time,operator_user_name,operator_user_id,receive_user_name,(case flag when 'true' then '�ѷ���' else 'δ����' end) flag,to_char(dispose_time,'yyyy-MM-dd hh24:mi:ss') dispose_time,isreply from t_msg_info where dispose_time is null and pid=" + currPatient.Id;
            string sql_ReadMsg = "select id,pid,type_id,type_name ��Ϣ����,content_id ��Ϣ����,content ��Ϣ����,to_char(add_time,'yyyy-MM-dd hh24:mi:ss') ����ʱ��,operator_user_name ������,operator_user_id,receive_user_name ������,to_char(dispose_time,'yyyy-MM-dd hh24:mi:ss') ����ʱ��,REPLY_MSG �ظ����� from t_msg_info where dispose_time is not null and pid=" + currPatient.Id;

            Class_Table[] tab = new Class_Table[2];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sql_NewMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "readMsg";
            tab[1].Sql = sql_ReadMsg;
            DataSet ds = App.GetDataSet(tab);


            if (ds != null)
            {
                dgvNewMsg.DataSource = null;
                dst_t_msg_info.T_MSG_INFO.Clear();
                #region δ�������Ϣ��δ����δ���͵ģ�
                if (ds.Tables["newMsg"].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables["newMsg"].Rows)
                    {
                        this.dst_t_msg_info.T_MSG_INFO.ImportRow(dr);
                    }
                    dgvNewMsg.DataSource = dst_t_msg_info.T_MSG_INFO;

                    //dgvNewMsg.Columns["id"].Visible = false;
                    //dgvNewMsg.Columns["pid"].Visible = false;
                    //dgvNewMsg.Columns["type_id"].Visible = false;
                    //dgvNewMsg.Columns["operator_user_id"].Visible = false;
                    //dgvNewMsg.Columns["����ʱ��"].Visible = false;


                }
                #endregion
                #region �Ѷ���Ϣ
                if (ds.Tables["readMsg"].Rows.Count > 0)
                {
                    dgvReadMsg.DataSource = ds.Tables["readMsg"];
                    dgvReadMsg.Columns["id"].Visible = false;
                    dgvReadMsg.Columns["pid"].Visible = false;
                    dgvReadMsg.Columns["type_id"].Visible = false;
                    dgvReadMsg.Columns["operator_user_id"].Visible = false;

                }
                #endregion
            }



        }
        /// <summary>
        /// ���ò�����Ϣ
        /// </summary>
        private void SetPatientInfo()
        {
            if (currPatient != null)
            {
                lblPatientId.Text = currPatient.His_id.Split('-')[0];//his����ID
                lblPid.Text = currPatient.PId;
                lblName.Text = currPatient.Patient_Name;
                lblSex.Text = currPatient.Gender_Code == "0" ? "��" : "Ů";
                lblAge.Text = currPatient.Age + " " + currPatient.Age_unit;
                lblPayManner.Text = currPatient.Pay_Manager;
                lblInTime.Text = currPatient.In_Time.ToString("yyyy-MM-dd HH:mm");
                lblOutSection.Text = currPatient.Section_Name;
               // lblInDoctor.Text = currPatient.Sick_Doctor_Name;
                lblSickDegree.Text = App.ReadSqlVal("select * from t_data_code where type='133' and code='" + currPatient.Sick_Degree + "'", 0, "name");
                lblSickDoctor.Text = currPatient.Sick_Doctor_Name;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmChooseMsg frm = new frmChooseMsg(currPatient);
            frm.ShowDialog();
            DataBand();
        }

        private void frmNotice_SizeChanged(object sender, EventArgs e)
        {
            int x = btnAdd.Parent.Size.Width / 2 - btnAdd.Size.Width;
            btnAdd.Location = new Point(x, btnAdd.Location.Y);
            btnDelete.Location = new Point(btnAdd.Location.X + 81, btnDelete.Location.Y);
        }

        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvNewMsg.CurrentRow != null)
            {
               // DataRowView drv = this.T_Msg_InfobindingSource.Current as DataRowView;
                string strId = dgvNewMsg.CurrentRow.Cells["id"].Value.ToString();
                if (strId != "")
                {
                    //������ID
                    string operatorId = dgvNewMsg.CurrentRow.Cells["operator_user_id"].Value.ToString();
                    if (dgvNewMsg.CurrentRow.Cells["flag"].Value.ToString() == "�ѷ���")
                    {
                        App.Msg("��Ϣ�ѷ��ͣ�����ɾ����");
                    }
                    else if (App.UserAccount.UserInfo.User_id == operatorId)
                    {
                        string sqlDel = "delete from t_msg_info where id=" + strId;
                        int num = App.ExecuteSQL(sqlDel);
                        if (num > 0)
                        {
                            DataBand();
                            App.Msg("ɾ���ɹ���");
                        }
                        else
                        {
                            App.Msg("ɾ��ʧ�ܣ�");
                        }
                    }
                    else
                    {
                        App.Msg("ֻ��ɾ�����˷�������Ϣ��");
                    }
                }
            }
        }

        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            string msgIds_zy = "";    //��Ҫ�ظ�����Ҫ��Ϣ����
            string msgIds_pt = "";    //��Ҫ�ظ�����ͨ��Ϣ����
            string numsgIds_zy = "";  //����Ҫ�ظ�����Ҫ��Ϣ����
            string numsgIds_pt = "";  //����Ҫ�ظ�����ͨ��Ϣ����
            ArrayList sqlList = new ArrayList();
            for (int i = 0; i < dgvNewMsg.Rows.Count; i++)
            {
                if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["flag"].ToString() == "δ����")//flag���ͱ�־��false��ʾ������Ϣû�з���
                {
                    if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["isreply"].ToString() == "1")//��Ҫ�ظ�����Ϣ
                    {
                        if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["content_id"].ToString() == "��Ҫ��Ϣ")//��Ҫ�ظ�����Ҫ��Ϣ
                        {
                            if (msgIds_zy == "")
                            {
                                msgIds_zy = dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                            else
                            {
                                msgIds_zy += "," + dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                        }
                        else if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["content_id"].ToString() == "��ͨ��Ϣ")
                        {
                            if (msgIds_pt == "")
                            {
                                msgIds_pt = dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                            else
                            {
                                msgIds_pt += "," + dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                        }

                    }
                    else//����Ҫ�ظ�����Ϣ
                    {
                        if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["content_id"].ToString() == "��Ҫ��Ϣ")//����Ҫ�ظ�����Ҫ��Ϣ
                        {
                            if (numsgIds_zy == "")
                            {
                                numsgIds_zy = dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                            else
                            {
                                numsgIds_zy += "," + dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                        }
                        else if (dst_t_msg_info.Tables["t_msg_info"].Rows[i]["content_id"].ToString() == "��ͨ��Ϣ")
                        {
                            if (numsgIds_pt == "")
                            {
                                numsgIds_pt = dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                            else
                            {
                                numsgIds_pt += "," + dst_t_msg_info.Tables["t_msg_info"].Rows[i]["id"].ToString();
                            }
                        }
                    }
                }
            }
            #region ���ص�
            //if (msgIds != "" && msgId != "")//��Ҫ�ظ��Ͳ���Ҫ�ظ�����Ϣ������
            //{
            //    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='1',WARN_TYPE='8' where id in(" + msgIds + ")");
            //    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,WARN_TYPE='8' where id in(" + msgId + ")");
            //    string[] arrStr = new string[sqlList.Count];
            //    for (int i = 0; i < sqlList.Count; i++)
            //    {
            //        arrStr[i] = sqlList[i].ToString();
            //    }
            //    int num = App.ExecuteBatch(arrStr);
            //    if (num > 0)
            //    {
            //        DataBand();
            //        App.Msg("���ͳɹ���");
            //    }
            //    else
            //    {
            //        App.Msg("����ʧ�ܣ�");
            //    }
            //}
            //else if (msgIds != "" && msgId == "")//ֻ������Ҫ�ظ�����Ϣ
            //{
            //    string strSql = "update t_msg_info set flag='true',add_time=sysdate,isreply='1',WARN_TYPE='8' where id in(" + msgIds + ")";
            //    int num = App.ExecuteSQL(strSql);
            //    if (num > 0)
            //    {
            //        DataBand();
            //        App.Msg("���ͳɹ���");
            //    }
            //    else
            //    {
            //        App.Msg("����ʧ�ܣ�");
            //    }
            //}
            //else if (msgIds == "" && msgId != "")//ֻ���ڲ���Ҫ�ظ�����Ϣ
            //{
            //    string strSql = "update t_msg_info set flag='true',add_time=sysdate,WARN_TYPE='8' where id in(" + msgId + ")";
            //    int num = App.ExecuteSQL(strSql);
            //    if (num > 0)
            //    {
            //        DataBand();
            //        App.Msg("���ͳɹ���");
            //    }
            //    else
            //    {
            //        App.Msg("����ʧ�ܣ�");
            //    }
            //}
            //else
            //{
            //    App.Msg("û��Ҫ���͵���Ϣ��");
            //} 
            #endregion
            if (msgIds_zy != "" || msgIds_pt != "" || numsgIds_zy != "" || numsgIds_pt != "") //�������ݿ����
            {
                if (msgIds_zy != "")
                {
                    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='1',WARN_TYPE='1' where id in(" + msgIds_zy + ")");//��Ҫ�ظ�����Ҫ��Ϣ����
                }
                if (msgIds_pt != "")
                {
                    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='1',WARN_TYPE='2' where id in(" + msgIds_pt + ")");  //��Ҫ�ظ�����ͨ��Ϣ����
                }
                if (numsgIds_zy != "")
                {
                    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='0',WARN_TYPE='1' where id in(" + numsgIds_zy + ")");   //����Ҫ�ظ�����Ҫ��Ϣ����                
                }
                if (numsgIds_pt != "")
                {
                    sqlList.Add("update t_msg_info set flag='true',add_time=sysdate,isreply='0',WARN_TYPE='2' where id in(" + numsgIds_pt + ")");   //����Ҫ�ظ�����ͨ��Ϣ����
                }
                string[] arrStr = new string[sqlList.Count];
                for (int i = 0; i < sqlList.Count; i++)
                {
                    arrStr[i] = sqlList[i].ToString();
                }
                int num = App.ExecuteBatch(arrStr);
                if (num > 0)
                {
                    DataBand();
                    App.Msg("���ͳɹ���");
                }
                else
                {
                    App.Msg("����ʧ�ܣ�");
                }
            }
        }
    }
}
