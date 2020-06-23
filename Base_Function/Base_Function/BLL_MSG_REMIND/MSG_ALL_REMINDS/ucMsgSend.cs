using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    /// <summary>
    /// ��Ϣ���������������  Ԭ���141110
    /// </summary>
    public partial class ucMsgSend : UserControl
    {
        public ucMsgSend()
        {
            InitializeComponent();
        }

        private void frmMsgSend_Load(object sender, EventArgs e)
        {
            try
            {
                this.getMsg();
            }
            catch
            {

            }
        }
        private void getMsg()
        {
            try
            {
                dgvMsg.Rows.Clear();
                string strSql = @"select t.id,t.type_name_cy,t.type_name,t.content,t.operator_user_name,to_char(t.add_time,'yyyy-MM-dd hh24:mi') as add_time,t.section_target,t.isreply,t.msg_status from T_MSG_INFO t where t.warn_type='19' order by add_time desc";
                DataSet ds = App.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvMsg.Rows.Add();

                        dgvMsg.Rows[i].Cells["Column9"].Value = ds.Tables[0].Rows[i]["id"].ToString();
                        dgvMsg.Rows[i].Cells["Column1"].Value = ds.Tables[0].Rows[i]["type_name_cy"].ToString();
                        dgvMsg.Rows[i].Cells["Column2"].Value = ds.Tables[0].Rows[i]["type_name"].ToString();
                        dgvMsg.Rows[i].Cells["Column3"].Value = ds.Tables[0].Rows[i]["content"].ToString();
                        dgvMsg.Rows[i].Cells["Column4"].Value = ds.Tables[0].Rows[i]["operator_user_name"].ToString();
                        dgvMsg.Rows[i].Cells["Column5"].Value = ds.Tables[0].Rows[i]["add_time"].ToString();
                        dgvMsg.Rows[i].Cells["Column6"].Value = ds.Tables[0].Rows[i]["section_target"].ToString();
                        if (ds.Tables[0].Rows[i]["isreply"].ToString() == "0")
                        {
                            dgvMsg.Rows[i].Cells["Column7"].Value = "NO";
                        }
                        else
                        {
                            dgvMsg.Rows[i].Cells["Column7"].Value = "��Ҫ";
                        }
                        if (ds.Tables[0].Rows[i]["msg_status"].ToString() == "0")
                        {
                            dgvMsg.Rows[i].Cells["Column8"].Value = "δ��";
                        }
                        else
                        {
                            dgvMsg.Rows[i].Cells["Column8"].Value = "�ѷ�";
                        }

                    }
                    dgvMsg.Columns["Column1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column4"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["column5"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column6"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column7"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column8"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //������ʾ �Ѷ��������������
                    dgvMsg.Columns["Column3"].Width = 250;
                    dgvMsg.Columns[4].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                    dgvMsg.AutoResizeRows();
                    dgvMsg.Refresh();
                }
                //dgvMsg.AutoResizeColumns();//����ȫ��
            }
            catch
            {

            }
        }
        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region ע�͵�
                //ucMsgSendDetails frm = new ucMsgSendDetails();
                //frm.ShowDialog();
                //this.getMsg(); 
                #endregion
                string strId = dgvMsg.CurrentRow.Cells["Column9"].Value.ToString();//��ȡ��Ϣ������id
                string strShouTiao = dgvMsg.CurrentRow.Cells["Column7"].Value.ToString();//��ȡ��Ϣ�Ƿ���Ҫ����
                string strSend_status = dgvMsg.CurrentRow.Cells["Column8"].Value.ToString();//��ȡ��Ϣ�ķ���״̬
                if (strId != "")
                {
                    if (strShouTiao != "NO")
                    {
                        if (strSend_status != "δ��")
                        {
                            frmMsgSendCheckReceipt frm = new frmMsgSendCheckReceipt(strId);
                            frm.ShowDialog();
                        }
                        else
                        {
                            App.Msg("��ǰѡ�е���Ϣ��û�з�����");
                            return;
                        }
                    }
                    else
                    {
                        App.Msg("��ǰѡ�е���Ϣ����Ҫ������");
                        return;
                    }
                }
                else
                {
                    App.Msg("��ѡ��һ����Ϣ���в鿴������");
                    return;
                }

            }
            catch
            {

            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                string strIds = "";//��¼����δ������Ϣ��id����
                string strLogin_name = App.UserAccount.UserInfo.User_name.ToString();//��ȡ��ǰ��¼������
                string strLogin_Id = App.UserAccount.UserInfo.User_id.ToString(); //��ȡ��ǰ��¼��id

                if (dgvMsg.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvMsg.SelectedRows.Count; i++)
                    {
                        if (dgvMsg.SelectedRows[i].Cells["Column8"].Value.ToString() == "δ��")
                        {
                            if (strIds == "")
                            {
                                strIds = dgvMsg.SelectedRows[i].Cells["Column9"].Value.ToString();
                            }
                            else
                            {
                                strIds += "," + dgvMsg.SelectedRows[i].Cells["Column9"].Value.ToString();
                            }
                        }
                    }
                    if (strIds == "")
                    {
                        App.Msg("��ǰ����Ϣ�Ѿ�ȫ�����ͣ�");
                        return;
                    }
                    else
                    {
                        string strDateTime_Now = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                        string strUpdate_sql = "update t_msg_info t set t.operator_user_id='" + strLogin_Id + "',t.operator_user_name='" + strLogin_name + "', t.msg_status='1',t.add_time=to_date('" + strDateTime_Now + "','yyyy-MM-dd hh24:mi') where t.id in (" + strIds + ") ";
                        int n = App.ExecuteSQL(strUpdate_sql);
                        if (n > 0)
                        {
                            App.Msg("��Ϣ�����ɹ���");
                            this.getMsg();
                            return;
                        }
                        else
                        {
                            App.Msg("��Ϣ����ʧ�ܣ�");
                            return;
                        }
                    }
                }
                else
                {
                    App.Msg("��ǰ������û�з�������Ϣ��");
                    return;
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string strId = dgvMsg.CurrentRow.Cells["Column9"].Value.ToString();
            if (strId == "")
            {
                App.Msg("����ѡ��һ��δ��������Ϣ�����޸ģ�");
                return;
            }
            string strMsg_status = dgvMsg.CurrentRow.Cells["Column8"].Value.ToString();
            if (strMsg_status != "δ��")
            {
                App.Msg("��ǰ��Ϣ�ѷ���,�޷������޸ģ�");
                return;
            }
            //�жϵ�ǰ��Ϣ�Ƿ����ڵ�ǰ��¼�˱༭��
            string strLogin_id = "";
            string strsql_operator_user_id = "select t.operator_user_id from t_msg_info t where t.id='" + strId + "'";
            DataSet dst = App.GetDataSet(strsql_operator_user_id);
            if (dst.Tables[0].Rows.Count > 0)
            {
                strLogin_id = dst.Tables[0].Rows[0]["operator_user_id"].ToString();
            }
            //�жϵ�ǰ�û���ɫ�Ƿ������μ���
            List<string> Sqls = new List<string>();
            string strRole_name = "";
            string strSql = @"select t4.role_name from t_userinfo t1, t_account_user t2, t_acc_role t3,t_role t4  where t1.user_id = t2.user_id  and t2.account_id = t3.account_id and t3.role_id = t4.role_id and t1.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            DataSet ds = App.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows.Count == 1)
                {
                    strRole_name = ds.Tables[0].Rows[0]["role_name"].ToString();
                }
                else
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds.Tables[0].Rows[i]["role_name"].ToString() == "�ʿذ�����" || ds.Tables[0].Rows[i]["role_name"].ToString() == "��Ϣ������" || ds.Tables[0].Rows[i]["role_name"].ToString() == "����������" || ds.Tables[0].Rows[i]["role_name"].ToString() == "ҽ�������" || ds.Tables[0].Rows[i]["role_name"].ToString() == "��������")
                        {
                            strRole_name = ds.Tables[0].Rows[i]["role_name"].ToString();
                            break;
                        }
                    }
                }
                if (strRole_name == "�ʿذ�����" || strRole_name == "��Ϣ������" || strRole_name == "����������" || strRole_name == "ҽ�������" || strRole_name == "��������" || App.UserAccount.UserInfo.User_id.ToString() == strLogin_id)
                {
                    string strContent_id = "";//���շ�ʽ
                    string strSql_Update = @"select id,
                                   pid,
                                   patient_name,
                                   receive_user_id,
                                   receive_user_name,
                                   operator_user_id,
                                   operator_user_name,
                                   type_id,
                                   type_name,
                                   content_id,
                                   content,
                                   add_time,
                                   msg_status,
                                   dispose_time,
                                   flag,
                                   reply_msg,
                                   isreply,
                                   reply_flag,
                                   type_id_cy,
                                   type_name_cy,
                                   operator_user_sender,
                                   section_target,
                                   warn_type,
                                   read_flag,
                                   section_id
                              from t_msg_info where id='" + strId + "'";
                    DataSet dss = App.GetDataSet(strSql_Update);
                    if (dss.Tables[0].Rows.Count > 0)
                    {
                        strContent_id = dss.Tables[0].Rows[0]["content_id"].ToString();
                    }
                    if (strContent_id != "")
                    {
                        frmMsgSendDetailsUpdate frm = new frmMsgSendDetailsUpdate(strId, strContent_id);//������Ϣ�������ͽ��շ�ʽ
                        frm.ShowDialog();
                        this.getMsg();
                    }
                }
                else
                {
                    App.Msg("������ӵ�����μ���Ȩ�ޣ���ǰ��ϢҲ�����������༭���������޷��޸Ĵ�����Ϣ��");
                    return;
                }
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvMsg.Rows.Count > 0)
                {
                    List<string> Sqls = new List<string>();
                    string strRole_name = "";
                    string strSql = @"select t4.role_name from t_userinfo t1, t_account_user t2, t_acc_role t3,t_role t4  where t1.user_id = t2.user_id  and t2.account_id = t3.account_id and t3.role_id = t4.role_id and t1.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                    DataSet ds = App.GetDataSet(strSql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count == 1)
                        {
                            strRole_name = ds.Tables[0].Rows[0]["role_name"].ToString();
                        }
                        else
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (ds.Tables[0].Rows[i]["role_name"].ToString() == "�ʿذ�����" || ds.Tables[0].Rows[i]["role_name"].ToString() == "��Ϣ������" || ds.Tables[0].Rows[i]["role_name"].ToString() == "����������" || ds.Tables[0].Rows[i]["role_name"].ToString() == "ҽ�������" || ds.Tables[0].Rows[i]["role_name"].ToString() == "��������")
                                {
                                    strRole_name = ds.Tables[0].Rows[i]["role_name"].ToString();
                                    break;
                                }
                            }
                        }
                        if (strRole_name == "�ʿذ�����" || strRole_name == "��Ϣ������" || strRole_name == "����������" || strRole_name == "ҽ�������" || strRole_name == "��������")
                        {
                            foreach (DataGridViewRow dr in dgvMsg.SelectedRows)
                            {

                                string strId = dr.Cells[0].Value.ToString();//ȡ������id
                                string strMsg_status = dr.Cells[8].Value.ToString();//ȡ������״̬
                                if (strId != "" && strMsg_status == "δ��")
                                {
                                    string strDeleteSql = "delete from t_msg_info t where t.id='" + strId + "'";
                                    Sqls.Add(strDeleteSql);
                                    //string strDelete_section_sql = "delete from t_msg_section t where t.id='" + strId + "'";
                                    //Sqls.Add(strDelete_section_sql);
                                }
                                else
                                {
                                    App.Msg("��ǰѡ��Ҫɾ������Ϣ�����ѷ���״̬,�޷�ɾ����");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            foreach (DataGridViewRow dr in dgvMsg.SelectedRows)
                            {

                                string strId = dr.Cells[0].Value.ToString();//ȡ������id
                                string strMsg_status = dr.Cells[8].Value.ToString();//ȡ������״̬
                                if (strId != "" && strMsg_status == "δ��")
                                {
                                    string strSelectSql = "select * from t_msg_info t where t.id='" + strId + "' and t.operator_user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                                    DataSet dst = App.GetDataSet(strSelectSql);
                                    if (dst.Tables[0].Rows.Count > 0)
                                    {
                                        string strDeleteSql = "delete from t_msg_info t where t.id='" + strId + "'";
                                        Sqls.Add(strDeleteSql);
                                        //string strDelete_section_sql = "delete from t_msg_section t where t.id='" + strId + "'";
                                        //Sqls.Add(strDelete_section_sql);
                                    }
                                    else
                                    {
                                        App.Msg("��������ǰ��ɾ��Ȩ�޲��������μ���������ֻ��ɾ�����Լ����༭����Ϣ��");
                                        return;
                                    }

                                }
                                else
                                {
                                    App.Msg("��ǰѡ��Ҫɾ������Ϣ�����ѷ���״̬,�޷�ɾ����");
                                    return;
                                }
                            }
                        }
                    }

                    if (Sqls.Count > 0)
                    {
                        int n = App.ExecuteBatch(Sqls.ToArray());
                        if (n > 0)
                        {
                            App.Msg("ɾ���ɹ���");
                            this.getMsg();
                            return;
                        }
                        else
                        {
                            App.Msg("ɾ��ʧ�ܣ�");
                            return;
                        }

                    }
                }
            }
            catch
            {

            }
        }
    }
}