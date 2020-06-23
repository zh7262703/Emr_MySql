using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS;
using Bifrost;


namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class ucMsgSendDetails : UserControl
    {
        /// <summary>
        /// ��Ϣ������������  Ԭ��   141106
        /// </summary>
        /// <summary>
        /// �������տ���id�ļ���
        /// </summary>
        public string strSection_ids = "";
        /// <summary>
        /// �������տ������Ƶļ���
        /// </summary>
        public string strSection_names = "";
        /// <summary>
        /// �������յ�ǰ������id
        /// </summary>
        public string strUser_id = "";
        /// <summary>
        /// �������յ�ǰ������id�ļ���
        /// </summary>
        public string strUser_ids = "";
        /// <summary>
        /// �������յ�ǰ��½����id
        /// </summary>
        public string strcbSection_id = "";
        /// <summary>
        /// �������յ�ǰ��¼��id
        /// </summary>
        public string strtxtEditor_id = "";
        /// <summary>
        /// ����������Ҫ�޸ĵ���Ϣ������
        /// </summary>
        public string str_id = "";
        /// <summary>
        /// ����������Ҫ�޸ĵ���Ϣ�Ľ��շ�ʽ
        /// </summary>
        public string str_Content_id = "";
        /// <summary>
        /// ���������޸���Ϣʱ�Զ�����cbReceiver_SelectedIndexChanged�¼�
        /// </summary>
        bool flag = false;
        /// <summary>
        /// ����id���� ��������Ϊ���ҺͲ���ʱʹ��
        /// </summary>
        public string strMSG_SECTION_ID = "";
        /// <summary>
        /// ����id���� ��������Ϊ���ҺͲ���ʱʹ��
        /// </summary>
        public string strMSG_AREA_ID = "";
        public ucMsgSendDetails()
        {
            InitializeComponent();
        }
        public ucMsgSendDetails(string id, string content_id)
        {
            InitializeComponent();
            str_id = id; //��������
            str_Content_id = content_id; //���� ���գ����շ�ʽ��
        }

        /// <summary>
        ///  ���ұ仯����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbReceiver_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    txtPerson.Visible = true;
                    this.btnSection_select.Visible = false;
                    //this.btnSection.Visible = false;
                    //this.btnArea.Visible = false;
                    strSection_ids = "";
                    strMSG_SECTION_ID = "";
                    strMSG_AREA_ID = "";
                    strSection_names = "";
                }
                if (cbReceiver.SelectedItem.ToString() == "����" || cbReceiver.SelectedItem.ToString() == "����")
                {
                    //this.btnSection.Visible = false;
                    //this.btnArea.Visible = false;
                    txtPerson.Visible = false;
                    txtPerson.Text = "";
                    txtReceiveName.Visible = false;
                    txtReceiveName.Visible = false;
                    panel2.Visible = false;
                    panel1.Visible = false;
                    this.btnSection_select.Visible = true;
                    dgvUser.Rows.Clear();
                    strSection_ids = "";
                    strMSG_SECTION_ID = "";
                    strMSG_AREA_ID = "";
                    strSection_names = "";
                }
                if (cbReceiver.SelectedItem.ToString() == "���ҺͲ���")
                {
                    //this.btnSection.Visible = true;
                    //this.btnArea.Visible = true;
                    txtPerson.Visible = false;
                    txtPerson.Text = "";
                    txtReceiveName.Visible = false;
                    txtReceiveName.Visible = false;
                    panel2.Visible = false;
                    panel1.Visible = false;
                    this.btnSection_select.Visible = false;
                    dgvUser.Rows.Clear();
                    strSection_ids = "";
                    strMSG_SECTION_ID = "";
                    strMSG_AREA_ID = "";
                    strSection_names = "";
                }
                if (cbReceiver.SelectedItem.ToString() == "ȫԺ" || cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��" || cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                {
                    this.btnSection_select.Visible = false;
                    //this.btnSection.Visible = false;
                    //this.btnArea.Visible = false;
                    txtPerson.Visible = false;
                    txtPerson.Text = "";
                    txtReceiveName.Visible = false;
                    txtReceiveName.Text = "";
                    dgvUser.Rows.Clear();
                    panel2.Visible = false;
                    panel1.Visible = false;
                    dgvUser.Rows.Clear();
                    strSection_ids = "";
                    strMSG_SECTION_ID = "";
                    strMSG_AREA_ID = "";
                    strSection_names = "";
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// ƴ�����������û�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPerson_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dgvSendPerson.Rows.Clear();
                string sql_section = "select t.user_id,t.user_name from t_userinfo t  where (t.shortcut_code like '%" + txtPerson.Text.ToLower() + "%' or  t.shortcut_code like '%" + txtPerson.Text.ToUpper() + "%')";
                DataSet ds = App.GetDataSet(sql_section);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        dgvSendPerson.Rows.Add();//�����һ��
                        dgvSendPerson.Rows[i].Cells["user_id"].Value = ds.Tables[0].Rows[i]["user_id"].ToString();
                        dgvSendPerson.Rows[i].Cells["user_name"].Value = ds.Tables[0].Rows[i]["user_name"].ToString();
                    }
                    panel1.Visible = true;
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// ˫��ѡ���û�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSendPerson_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strUser_name = dgvSendPerson.CurrentRow.Cells["user_name"].Value.ToString();
                strUser_id = dgvSendPerson.CurrentRow.Cells["user_id"].Value.ToString();//���û�id��ֵ
                if (strUser_name != "")
                {
                    txtPerson.Text = strUser_name;

                    this.panel1.Visible = false;
                    txtPerson_Enter(null, null);
                    dgvSendPerson.Focus();
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSendPerson_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    dgvSendPerson.Focus();

                }
                if (e.KeyCode == Keys.Enter)
                {
                    string strUser_name = "";
                    int index = dgvSendPerson.CurrentRow.Index;
                    if (index > 0)
                    {
                        strUser_name = dgvSendPerson.Rows[index - 1].Cells["user_name"].Value.ToString();
                        strUser_id = dgvSendPerson.Rows[index - 1].Cells["user_id"].Value.ToString();
                    }
                    else
                    {
                        strUser_name = dgvSendPerson.Rows[index].Cells["user_name"].Value.ToString();
                        strUser_id = dgvSendPerson.Rows[index].Cells["user_id"].Value.ToString();
                    }
                    if (strUser_name != "")
                    {
                        txtPerson.Text = strUser_name;
                        this.panel1.Visible = false;
                        txtPerson.Focus();
                    }


                }
                if (e.KeyCode == Keys.Escape)
                {
                    panel1.Visible = false;
                    txtPerson.Focus();
                }
            }
            catch
            {

            }
        }
        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;
            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Down:
                        dgvSendPerson.Focus();
                        break;
                    case Keys.Enter:
                        dgvSendPerson.Focus();
                        dgvSendPerson.CellEnter += new DataGridViewCellEventHandler(txtPerson_TextChanged);
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        /// <summary>
        /// �س����������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPerson_Enter(object sender, EventArgs e)
        {
            try
            {
                #region ע�͵�
                //                if (txtPerson.Text != "")
                //                {
                //                    string strSql = @"select e.sid,e.section_name
                //                                  from t_userinfo       a,
                //                                       t_account_user   b,
                //                                       t_acc_role       c,
                //                                       t_acc_role_range d,
                //                                       t_sectioninfo    e
                //                                 where a.user_id = b.user_id
                //                                   and b.account_id = c.account_id 
                //                                   and c.id = d.acc_role_id
                //                                   and d.section_id = e.sid
                //                                   and a.user_id ='" + strUser_id + "'";
                //                    DataSet ds = App.GetDataSet(strSql);
                //                    if (ds.Tables[0].Rows.Count > 0)
                //                    {
                //                        txtReceiveName.Visible = true;
                //                        txtReceiveName.Text = "";
                //                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //                        {
                //                            if (i == 0)
                //                            {
                //                                txtReceiveName.Text = ds.Tables[0].Rows[0]["section_name"].ToString();
                //                                strSection_names = txtReceiveName.Text;
                //                                strSection_ids = ds.Tables[0].Rows[0]["sid"].ToString();
                //                            }
                //                            if (i > 0)
                //                            {
                //                                txtReceiveName.Text += "," + ds.Tables[0].Rows[i]["section_name"].ToString();
                //                                strSection_names = txtReceiveName.Text;
                //                                strSection_ids += "," + ds.Tables[0].Rows[i]["sid"].ToString();
                //                            }
                //                        }

                //                    }
                //                } 
                #endregion
                if (txtPerson.Text != "")
                {
                    panel2.Visible = true;
                    DataGridViewRow Row = new DataGridViewRow();
                    dgvUser.RowHeadersWidth = 45;
                    for (int i = 0; i < dgvUser.Rows.Count; i++)
                    {
                        if (dgvUser.Rows[i].Cells["Column1"].Value.ToString() == strUser_id.ToString())
                        {
                            return;
                        }
                    }
                    int index = dgvUser.Rows.Add(Row);
                    dgvUser.Rows[index].Cells["Column1"].Value = strUser_id.ToString();    //������id��ֵ
                    dgvUser.Rows[index].Cells["Column2"].Value = txtPerson.Text.ToString();//���������Ƹ�ֵ
                    if (txtReceiveName.Text == "")
                    {
                        txtReceiveName.Text = txtPerson.Text.ToString();

                    }
                    else
                    {
                        txtReceiveName.Text += "," + txtPerson.Text.ToString();
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMsgSendDetails_Load(object sender, EventArgs e)
        {
            try
            {
                txtEditor.Text = App.UserAccount.UserInfo.User_name.ToString();//��ȡ��ǰ��¼������
                strtxtEditor_id = App.UserAccount.UserInfo.User_id.ToString(); //��ȡ��ǰ��¼��id
                cbSection.Text = App.UserAccount.CurrentSelectRole.Section_name.ToString();//��ȡ��ǰ��½��������
                strcbSection_id = App.UserAccount.CurrentSelectRole.Section_Id.ToString(); //��ȡ��ǰ��½����id

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
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> sqls = new List<string>();
                if (cbReceiver.SelectedItem.ToString() == "")
                {
                    App.Msg("�����˲���Ϊ�գ�");
                    return;
                }
                if (cbNewsType.SelectedItem.ToString() == "")
                {
                    App.Msg("��Ϣ���Ͳ���Ϊ��");
                    return;
                }
                if (txtTitle.Text == "")
                {
                    App.Msg("���ⲻ��Ϊ�գ�");
                    return;
                }
                if (txtContent.Text == "")
                {
                    App.Msg("���ݲ���Ϊ�գ�");
                    return;
                }
                if (cbReceiver.SelectedItem.ToString() != "����" && cbReceiver.SelectedItem.ToString() != "����")
                {
                    strSection_ids = "";
                    strSection_names = "";
                }
                //�����˵���� ��Ӧ��Ϣ��t_msg_info�е�CONTENT_ID�ֶ�
                string strCONTENT_ID = "";
                if (cbReceiver.SelectedItem.ToString() == "ȫԺ")
                {
                    strCONTENT_ID = "1";
                    strSection_names = "ȫԺ";
                }
                if (cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��")
                {
                    strCONTENT_ID = "D";
                    strSection_names = "ȫ��ҽ��";
                }
                if (cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                {
                    strCONTENT_ID = "N";
                    strSection_names = "ȫ�廤ʿ";
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    strCONTENT_ID = "4";
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    strCONTENT_ID = "5";
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    strCONTENT_ID = "6";
                    //strSection_names = txtReceiveName.Text.ToString(); //����������ȡ����ǰ�Ľ��շ�ʽ
                    strSection_names = "";
                }
                if (cbReceiver.SelectedItem.ToString() == "����" || cbReceiver.SelectedItem.ToString() == "����")
                {
                    if (strSection_ids == "")
                    {
                        App.Msg("������Ϊ���һ���ʱ�����һ�����ѡ����Ϊ�գ�");
                        return;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    if (dgvUser.Rows.Count == 0)
                    {
                        App.Msg("��ǰ������Ϊ�գ��޷�������Ϣ��");
                        return;
                    }
                }
                string strNewId = App.GenId("t_msg_info", "id").ToString();
                #region ע�͵�
                //string strNewId_sql = "select t_msg_info_id.nextval as newId  from dual";
                //DataSet ds = App.GetDataSet(strNewId_sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    strNewId = ds.Tables[0].Rows[0]["newId"].ToString();
                //} 
                #endregion
                string strIsSend = ""; //�Ƿ�������
                if (radioButton1.Checked)
                {
                    strIsSend = "1";
                }
                else
                {
                    strIsSend = "0";
                }
                string  strType_id = "0";
                if (cbSection.Checked == true)
                {
                    strType_id = "1";
                }
                else
                {
                    cbSection.Text = "";
                    strcbSection_id = "";
                }
                string strSave_qy_sql = "";       //��������ΪȫԺʱ�����б�����ʹ�õ�sql
                string strSave_allDoctor_sql = "";//��������Ϊȫ��ҽ��ʱ�����б�����ʹ�õ�sql
                string strSave_allNurse_sql = ""; //��������Ϊȫ����ʿʱ�����б�����ʹ�õ�sql
                string strSave_Section_sql = "";  //��������Ϊ����ʱ�����б�����ʹ�õ�sql
                string strSave_Sickarea_sql = ""; //��������Ϊ����ʱ�����б�����ʹ�õ�sql 
                string strSave_User_sql = "";     //��������Ϊ����ʱ�����б�����ʹ�õ�sql
                string strSave_sql = "";          //������Ϣ���в�����Ϣ
                if (cbReceiver.SelectedItem.ToString() == "ȫԺ")
                {
                    string strTotal_sql = "select t.user_id,t.user_name from t_userinfo t";
                    DataSet ds_qy = App.GetDataSet(strTotal_sql);
                    if (ds_qy.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_qy.Tables[0].Rows.Count; i++)
                        {
                            strSave_qy_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_qy.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_qy.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','','','','')";
                            sqls.Add(strSave_qy_sql);
                        }
                    }
                    else
                    {
                        App.Msg("��ǰϵͳ�в������κν�ɫ,�޷�������Ϣ,���ȷ����ɫ��");
                        return;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��")
                {
                    string strAllDoctor_sql = @"select distinct(a.user_id), a.user_name, d.role_type
                                                  from t_userinfo a, t_account_user b, t_acc_role c, t_role d
                                                 where a.user_id = b.user_id
                                                   and b.account_id = c.account_id
                                                   and c.role_id = d.role_id
                                                   and d.role_type = 'D'";
                    DataSet ds_allDoctor = App.GetDataSet(strAllDoctor_sql);
                    if (ds_allDoctor.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_allDoctor.Tables[0].Rows.Count; i++)
                        {
                            strSave_allDoctor_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_allDoctor.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_allDoctor.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','D','','','')";
                            sqls.Add(strSave_allDoctor_sql);
                        }
                    }
                    else
                    {
                        App.Msg("��ǰϵͳ�в�����ҽ����ɫ,�޷�������Ϣ,���ȷ���ҽ����ɫ��");
                        return;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                {
                    string strAllNurse_sql = @"select distinct(a.user_id), a.user_name, d.role_type
                                                  from t_userinfo a, t_account_user b, t_acc_role c, t_role d
                                                 where a.user_id = b.user_id
                                                   and b.account_id = c.account_id
                                                   and c.role_id = d.role_id
                                                   and d.role_type = 'N'";
                    DataSet ds_allNurse = App.GetDataSet(strAllNurse_sql);
                    if (ds_allNurse.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_allNurse.Tables[0].Rows.Count; i++)
                        {
                            strSave_allNurse_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_allNurse.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_allNurse.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','N','','','')";
                            sqls.Add(strSave_allNurse_sql);
                        }
                    }
                    else
                    {
                        App.Msg("��ǰϵͳ�в����ڻ�ʿ��ɫ,�޷�������Ϣ,���ȷ��令ʿ��ɫ��");
                        return;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    string[] strSection_id = strSection_ids.Split(',');
                    for (int i = 0; i < strSection_id.Length; i++)
                    {
                        string strSection_sql = @"select distinct(a.user_id),a.user_name,e.sid,e.sid,e.section_name
                                                  from t_userinfo       a,
                                                       t_account_user   b,
                                                       t_acc_role       c,
                                                       t_acc_role_range d,
                                                       t_sectioninfo    e
                                                 where a.user_id = b.user_id
                                                   and b.account_id = c.account_id 
                                                   and c.id = d.acc_role_id
                                                   and d.section_id = e.sid
                                                   and e.sid='" + strSection_id[i] + "'";
                        DataSet ds_Section = App.GetDataSet(strSection_sql);
                        if (ds_Section.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds_Section.Tables[0].Rows.Count; j++)
                            {

                                strSave_Section_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_Section.Tables[0].Rows[j]["user_id"].ToString() + "','" + ds_Section.Tables[0].Rows[j]["user_name"].ToString() + "','" + ds_Section.Tables[0].Rows[j]["sid"].ToString() + "','" + strIsSend + "','','','','')";
                                sqls.Add(strSave_Section_sql);
                            }
                        }
                        else
                        {
                            App.Msg("��ǰ��ѡ��Ŀ���û�з����û�,�����޷�������Ϣ,���ȸ���ǰ���ҷ����û���");
                            return;
                        }
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    string[] strSickare_id = strSection_ids.Split(',');
                    for (int i = 0; i < strSickare_id.Length; i++)
                    {
                        string strSickare_sql = @"select distinct( a.user_id),a.user_name,e.said,e.sick_area_name
                                                      from t_userinfo       a,
                                                           t_account_user   b,
                                                           t_acc_role       c,
                                                           t_acc_role_range d,
                                                           t_sickareainfo  e
                                                     where a.user_id = b.user_id
                                                       and b.account_id = c.account_id 
                                                       and c.id = d.acc_role_id
                                                       and d.sickarea_id = e.said
                                                   and e.said='" + strSickare_id[i] + "'";
                        DataSet ds_Sickare = App.GetDataSet(strSickare_sql);
                        if (ds_Sickare.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds_Sickare.Tables[0].Rows.Count; j++)
                            {

                                strSave_Sickarea_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_Sickare.Tables[0].Rows[j]["user_id"].ToString() + "','" + ds_Sickare.Tables[0].Rows[j]["user_name"].ToString() + "','" + ds_Sickare.Tables[0].Rows[j]["said"].ToString() + "','" + strIsSend + "','','','','')";
                                sqls.Add(strSave_Sickarea_sql);
                            }
                        }
                        else
                        {
                            App.Msg("��ǰ��ѡ��Ĳ���û�з����û�,�����޷�������Ϣ,���ȸ���ǰ���������û���");
                            return;
                        }

                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    for (int i = 0; i < dgvUser.Rows.Count; i++)
                    {
                        if (strSection_names == "")
                        {
                            strSection_names = dgvUser.Rows[i].Cells["Column2"].Value.ToString();
                        }
                        else
                        {
                            strSection_names += "," + dgvUser.Rows[i].Cells["Column2"].Value.ToString();
                        }
                        strSave_User_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + dgvUser.Rows[i].Cells["Column1"].Value.ToString() + "','" + dgvUser.Rows[i].Cells["Column2"].Value.ToString() + "','','" + strIsSend + "','','','','')";
                        sqls.Add(strSave_User_sql);
                    }
                }
                //����Ϣ��¼�������Ϣ
                strSave_sql = @"insert into t_msg_info
                                            (id, pid, patient_name, receive_user_id, receive_user_name, operator_user_id, operator_user_name, type_id, type_name, content_id, content, add_time, msg_status, dispose_time, flag, reply_msg, isreply, reply_flag, type_id_cy, type_name_cy, operator_user_sender, section_target, warn_type, read_flag,SECTION_ID)
                                            values
                                            ('" + strNewId + "', '" + strcbSection_id + "', '" + cbSection.Text + "', '" + strUser_id + "', '" + txtPerson.Text + "','" + strtxtEditor_id + "', '" + txtEditor.Text + "', '"+strType_id+"', '" + txtTitle.Text + "', '" + strCONTENT_ID + "', '" + txtContent.Text + "', '', '0', '', '', '', '" + strIsSend + "', '', '', '" + cbNewsType.SelectedItem.ToString() + "', '" + cbSection.Text + "','" + strSection_names + "' , '19', '','" + strSection_ids + "')";
                sqls.Add(strSave_sql);
                int n = App.ExecuteBatch(sqls.ToArray());
                if (n > 0)
                {
                    App.Msg("����ɹ���");
                    this.setClear();
                }
                else
                {
                    App.Msg("����ʧ�ܣ�");
                    return;
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// ��ղ���
        /// </summary>
        private void setClear()
        {
            cbReceiver.SelectedIndex = 6;
            cbNewsType.SelectedIndex = 3;
            txtPerson.Text = "";
            txtTitle.Text = "";
            txtContent.Text = "";
            btnSection_select.Visible = false;
            this.btnSection_select.Visible = false;
           // this.btnSection.Visible = false;
            radioButton2.Checked = true;
            txtPerson.Visible = false;
            panel1.Visible = false;
            txtReceiveName.Text = "";
            txtReceiveName.Visible = false; 
            panel2.Visible = false;
            dgvUser.Rows.Clear();
            strSection_ids = "";
            strMSG_SECTION_ID = "";
            strMSG_AREA_ID = "";
            strSection_names = "";
        }
        /// <summary>
        /// ���͹���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> sqls = new List<string>();
                if (cbReceiver.SelectedItem.ToString() == "")
                {
                    App.Msg("�����˲���Ϊ�գ�");
                    return;
                }
                if (cbNewsType.SelectedItem.ToString() == "")
                {
                    App.Msg("��Ϣ���Ͳ���Ϊ��");
                    return;
                }
                if (txtTitle.Text == "")
                {
                    App.Msg("���ⲻ��Ϊ�գ�");
                    return;
                }
                if (txtContent.Text == "")
                {
                    App.Msg("���ݲ���Ϊ�գ�");
                    return;
                }
                if (cbReceiver.SelectedItem.ToString() != "����" && cbReceiver.SelectedItem.ToString() != "����")
                {
                    strSection_ids = "";
                    strSection_names = "";
                }
                if (cbReceiver.SelectedItem.ToString() == "����" || cbReceiver.SelectedItem.ToString() == "����")
                {
                    if (strSection_ids == "")
                    {
                        App.Msg("������Ϊ���һ���ʱ�����һ�����ѡ����Ϊ�գ�");
                        return;
                    }
                }
                //�����˵���� ��Ӧ��Ϣ��t_msg_info�е�CONTENT_ID�ֶ�
                string strCONTENT_ID = "";
                if (cbReceiver.SelectedItem.ToString() == "ȫԺ")
                {
                    strCONTENT_ID = "1";
                    strSection_names = "ȫԺ";
                }
                if (cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��")
                {
                    strCONTENT_ID = "D";
                    strSection_names = "ȫ��ҽ��";
                }
                if (cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                {
                    strCONTENT_ID = "N";
                    strSection_names = "ȫ�廤ʿ";
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    strCONTENT_ID = "4";
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    strCONTENT_ID = "5";
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    strCONTENT_ID = "6";
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    if (dgvUser.Rows.Count == 0)
                    {
                        App.Msg("��ǰ������Ϊ�գ��޷�������Ϣ��");
                        return;
                    }
                }
                string strNewId = App.GenId("t_msg_info", "id").ToString();
                #region ע�͵�
                //string strNewId_sql = "select t_msg_info_id.nextval as newId  from dual";
                //DataSet ds = App.GetDataSet(strNewId_sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    strNewId = ds.Tables[0].Rows[0]["newId"].ToString();
                //} 
                #endregion
                string strIsSend = ""; //�Ƿ�������
                if (radioButton1.Checked)
                {
                    strIsSend = "1";
                }
                else
                {
                    strIsSend = "0";
                }
                if (cbSection.Checked == false)
                {
                    cbSection.Text = "";
                    strcbSection_id = "";
                }
                string strType_id = "0";
                if (cbSection.Checked == true)
                {
                    strType_id = "1";
                }
                else
                {
                    cbSection.Text = "";
                    strcbSection_id = "";
                }
                string strSave_qy_sql = "";       //��������ΪȫԺʱ�����б�����ʹ�õ�sql
                string strSave_allDoctor_sql = "";//��������Ϊȫ��ҽ��ʱ�����б�����ʹ�õ�sql
                string strSave_allNurse_sql = ""; //��������Ϊȫ����ʿʱ�����б�����ʹ�õ�sql
                string strSave_Section_sql = "";  //��������Ϊ����ʱ�����б�����ʹ�õ�sql
                string strSave_Sickarea_sql = ""; //��������Ϊ����ʱ�����б�����ʹ�õ�sql 
                string strSave_User_sql = "";     //��������Ϊ����ʱ�����б�����ʹ�õ�sql
                string strSend_sql = "";          //������Ϣ���в�����Ϣ
                if (cbReceiver.SelectedItem.ToString() == "ȫԺ")
                {
                    string strTotal_sql = "select t.user_id,t.user_name from t_userinfo t";
                    DataSet ds_qy = App.GetDataSet(strTotal_sql);
                    if (ds_qy.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_qy.Tables[0].Rows.Count; i++)
                        {
                            strSave_qy_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_qy.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_qy.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','','','','')";
                            sqls.Add(strSave_qy_sql);
                        }
                    }
                    else
                    {
                        App.Msg("��ǰϵͳ�в������κν�ɫ,�޷�������Ϣ,���ȷ����ɫ��");
                        return;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��")
                {
                    string strAllDoctor_sql = @"select distinct(a.user_id), a.user_name, d.role_type
                                                  from t_userinfo a, t_account_user b, t_acc_role c, t_role d
                                                 where a.user_id = b.user_id
                                                   and b.account_id = c.account_id
                                                   and c.role_id = d.role_id
                                                   and d.role_type = 'D'";
                    DataSet ds_allDoctor = App.GetDataSet(strAllDoctor_sql);
                    if (ds_allDoctor.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_allDoctor.Tables[0].Rows.Count; i++)
                        {
                            strSave_allDoctor_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_allDoctor.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_allDoctor.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','D','','','')";
                            sqls.Add(strSave_allDoctor_sql);
                        }
                    }
                    else
                    {
                        App.Msg("��ǰϵͳ�в�����ҽ����ɫ,�޷�������Ϣ,���ȷ���ҽ����ɫ��");
                        return;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                {
                    string strAllNurse_sql = @"select distinct(a.user_id), a.user_name, d.role_type
                                                  from t_userinfo a, t_account_user b, t_acc_role c, t_role d
                                                 where a.user_id = b.user_id
                                                   and b.account_id = c.account_id
                                                   and c.role_id = d.role_id
                                                   and d.role_type = 'N'";
                    DataSet ds_allNurse = App.GetDataSet(strAllNurse_sql);
                    if (ds_allNurse.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds_allNurse.Tables[0].Rows.Count; i++)
                        {
                            strSave_allNurse_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_allNurse.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_allNurse.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','N','','','')";
                            sqls.Add(strSave_allNurse_sql);
                        }
                    }
                    else
                    {
                        App.Msg("��ǰϵͳ�в����ڻ�ʿ��ɫ,�޷�������Ϣ,���ȷ��令ʿ��ɫ��");
                        return;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    string[] strSection_id = strSection_ids.Split(',');
                    for (int i = 0; i < strSection_id.Length; i++)
                    {
                        string strSection_sql = @"select distinct(a.user_id),a.user_name,e.sid,e.sid,e.section_name
                                                  from t_userinfo       a,
                                                       t_account_user   b,
                                                       t_acc_role       c,
                                                       t_acc_role_range d,
                                                       t_sectioninfo    e
                                                 where a.user_id = b.user_id
                                                   and b.account_id = c.account_id 
                                                   and c.id = d.acc_role_id
                                                   and d.section_id = e.sid
                                                   and e.sid='" + strSection_id[i] + "'";
                        DataSet ds_Section = App.GetDataSet(strSection_sql);
                        if (ds_Section.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds_Section.Tables[0].Rows.Count; j++)
                            {

                                strSave_Section_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_Section.Tables[0].Rows[j]["user_id"].ToString() + "','" + ds_Section.Tables[0].Rows[j]["user_name"].ToString() + "','" + ds_Section.Tables[0].Rows[j]["sid"].ToString() + "','" + strIsSend + "','','','','')";
                                sqls.Add(strSave_Section_sql);
                            }
                        }
                        else
                        {
                            App.Msg("��ǰ��ѡ��Ŀ���û�з����û�,�����޷�������Ϣ,���ȸ���ǰ���ҷ����û���");
                            return;
                        }

                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    string[] strSickare_id = strSection_ids.Split(',');
                    for (int i = 0; i < strSickare_id.Length; i++)
                    {
                        string strSickare_sql = @"select distinct( a.user_id),a.user_name,e.said,e.sick_area_name
                                                      from t_userinfo       a,
                                                           t_account_user   b,
                                                           t_acc_role       c,
                                                           t_acc_role_range d,
                                                           t_sickareainfo  e
                                                     where a.user_id = b.user_id
                                                       and b.account_id = c.account_id 
                                                       and c.id = d.acc_role_id
                                                       and d.sickarea_id = e.said
                                                   and e.said='" + strSickare_id[i] + "'";
                        DataSet ds_Sickare = App.GetDataSet(strSickare_sql);
                        if (ds_Sickare.Tables[0].Rows.Count > 0)
                        {
                            for (int j = 0; j < ds_Sickare.Tables[0].Rows.Count; j++)
                            {

                                strSave_Sickarea_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + ds_Sickare.Tables[0].Rows[j]["user_id"].ToString() + "','" + ds_Sickare.Tables[0].Rows[j]["user_name"].ToString() + "','','" + strIsSend + "','','" + ds_Sickare.Tables[0].Rows[j]["said"].ToString() + "','','')";
                                sqls.Add(strSave_Sickarea_sql);
                            }
                        }
                        else
                        {
                            App.Msg("��ǰ��ѡ��Ĳ���û�з����û�,�����޷�������Ϣ,���ȸ���ǰ���������û���");
                            return;
                        }
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    for (int i = 0; i < dgvUser.Rows.Count; i++)
                    {
                        if (strSection_names == "")
                        {
                            strSection_names = dgvUser.Rows[i].Cells["Column2"].Value.ToString();
                        }
                        else
                        {
                            strSection_names += "," + dgvUser.Rows[i].Cells["Column2"].Value.ToString();
                        }
                        strSave_User_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + strNewId + "','" + dgvUser.Rows[i].Cells["Column1"].Value.ToString() + "','" + dgvUser.Rows[i].Cells["Column2"].Value.ToString() + "','','" + strIsSend + "','','','','')";
                        sqls.Add(strSave_User_sql);
                    }
                }
                strSend_sql = @"insert into t_msg_info
                                            (id, pid, patient_name, receive_user_id, receive_user_name, operator_user_id, operator_user_name, type_id, type_name, content_id, content, add_time, msg_status, dispose_time, flag, reply_msg, isreply, reply_flag, type_id_cy, type_name_cy, operator_user_sender, section_target, warn_type, read_flag,SECTION_ID)
                                            values
                                            ('" + strNewId + "', '" + strcbSection_id + "', '" + cbSection.Text + "', '', '', '" + strtxtEditor_id + "', '" + txtEditor.Text + "', '" + strType_id + "', '" + txtTitle.Text + "', '" + strCONTENT_ID + "', '" + txtContent.Text + "', to_date('" + dtTime.Text + "','yyyy-MM-dd hh24:mi'), '1', '', '', '', '" + strIsSend + "', '', '', '" + cbNewsType.SelectedItem.ToString() + "', '" + cbSection.Text + "','" + strSection_names + "' , '19', '','" + strSection_ids + "')";
                sqls.Add(strSend_sql);
                int n = App.ExecuteBatch(sqls.ToArray());
                if (n > 0)
                {
                    App.Msg("�����ɹ���");
                    this.setClear();

                }
                else
                {
                    App.Msg("����ʧ�ܣ�");
                    return;
                }
            }
            catch
            {

            }

        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.setClear();
        }
        /// <summary>
        /// �����շ�ʽѡ��Ϊ����ʱ���������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSection_select_Click(object sender, EventArgs e)
        {
            if (strSection_ids != "" && strSection_names != "")//�����ҺͲ����Ѿ��༭��ɺ󣬻�û�б���ʱ���ڴ򿪱༭���һ�������
            {
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    Base_Function.BLL_MANAGEMENT.frmSectionCheck frm = new Base_Function.BLL_MANAGEMENT.frmSectionCheck(2, strSection_ids, strSection_names);
                    frm.ShowDialog();
                    if (frm.flag)
                    {
                        strSection_ids = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionID;
                        strSection_names = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionName;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    Base_Function.BLL_MANAGEMENT.frmSectionCheck frm = new Base_Function.BLL_MANAGEMENT.frmSectionCheck(3, strSection_ids, strSection_names);
                    frm.ShowDialog();
                    if (frm.flag)
                    {
                        strSection_ids = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionID;
                        strSection_names = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionName;
                    }
                }
                return;
            }
            if (cbReceiver.SelectedItem.ToString() == "����")
            {
                Base_Function.BLL_MANAGEMENT.frmSectionCheck frm = new Base_Function.BLL_MANAGEMENT.frmSectionCheck(2);
                frm.ShowDialog();
                if (frm.flag)
                {
                    strSection_ids = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionID;
                    strSection_names = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionName;
                }
                return;
            }
            if (cbReceiver.SelectedItem.ToString() == "����")
            {
                Base_Function.BLL_MANAGEMENT.frmSectionCheck frm = new Base_Function.BLL_MANAGEMENT.frmSectionCheck(3);
                frm.ShowDialog();
                if (frm.flag)
                {
                    strSection_ids = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionID;
                    strSection_names = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionName;
                }
                return;
            }
        }
        /// <summary>
        /// ��������Ϊ����ʱ������ɾ���Ѿ�ѡ�еĽ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (dgvUser.Rows.Count > 0)
                {
                    int n = dgvUser.CurrentRow.Index;
                    dgvUser.Rows.RemoveAt(n);
                }
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// ��������Ϊ����ʱ����������Ѿ�ѡ�е����н�������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                dgvUser.Rows.Clear();
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// ��ѡ����ҺͲ���ʱ -ѡ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSection_Click(object sender, EventArgs e)
        {
            Base_Function.BLL_MANAGEMENT.frmSectionCheck frm = new Base_Function.BLL_MANAGEMENT.frmSectionCheck(2);
            frm.ShowDialog();
            if (frm.flag)
            {
                strMSG_SECTION_ID = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionID;
                if (strSection_names != "")
                {
                    strSection_names = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionName;
                }
                else
                {
                    strSection_names +=","+ Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionName;
                }
            }
        }
        /// <summary>
        /// ��ѡ����ҺͲ���ʱ -ѡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnArea_Click(object sender, EventArgs e)
        {
            Base_Function.BLL_MANAGEMENT.frmSectionCheck frm = new Base_Function.BLL_MANAGEMENT.frmSectionCheck(3);
            frm.ShowDialog();
            if (frm.flag)
            {
                strMSG_AREA_ID = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionID;
                if (strSection_names != "")
                {
                    strSection_names = Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionName;
                }
                else
                {
                    strSection_names += "," + Base_Function.BLL_MANAGEMENT.frmSectionCheck.YwcSectionName;
                }
            }
        }
    }

}