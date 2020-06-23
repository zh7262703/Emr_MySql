using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base_Function.BLL_MANAGEMENT;
using Bifrost;


namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class frmMsgSendDetailsUpdate : DevComponents.DotNetBar.Office2007Form
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
        public string strtxtLkSection_id = "";
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
        /// ����id����
        /// </summary>
        public string strMSGSECTION_ID = "";
        /// <summary>
        /// �������Ƽ���
        /// </summary>
        public string strMSG_SECTION_NAME = "";
        /// <summary>
        /// �Ƿ���Ҫ����
        /// </summary>
        public string strIsreply = "";
        /// <summary>
        /// �޸�ʱ��Ҫ��¼��id����
        /// </summary>
        public string strSECTION_ID = "";
        /// <summary>
        /// �ж����ķ�ʽ
        /// </summary>
        public string strType = "";
        /// <summary>
        /// ������id
        /// </summary>
        public string strLk_section_id = "";
        /// <summary>
        /// ����������
        /// </summary>
        public string strLk_section_name = "";

        public frmMsgSendDetailsUpdate()
        {
            InitializeComponent();
        }
        public frmMsgSendDetailsUpdate(string id, string content_id)
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
                    strSection_ids = "";
                    strSection_names = "";

                }
                if (cbReceiver.SelectedItem.ToString() == "����" || cbReceiver.SelectedItem.ToString() == "����")
                {
                    txtPerson.Visible = false;
                    txtPerson.Text = "";
                    txtReceiveName.Visible = false;
                    panel2.Visible = false;
                    panel1.Visible = false;
                    this.btnSection_select.Visible = true;
                    dgvUser.Rows.Clear();
                    strSection_ids = "";
                    strSection_names = "";

                }
                if (cbReceiver.SelectedItem.ToString() == "ȫԺ" || cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��" || cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                {
                    this.btnSection_select.Visible = false;
                    txtPerson.Visible = false;
                    txtPerson.Text = "";
                    txtReceiveName.Visible = false;
                    txtReceiveName.Text = "";
                    dgvUser.Rows.Clear();
                    panel2.Visible = false;
                    panel1.Visible = false;
                    dgvUser.Rows.Clear();
                    strSection_ids = "";
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
                    dgvUser.Rows[index].Cells["Column1"].Value = strUser_id.ToString();//������id��ֵ
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
                this.UpdateMsg();
            }
            catch
            {

            }
        }
        private void UpdateMsg()
        {
            string strContent_id = "";//���շ�ʽ
            string strPid = "";//������id
            string strPatient_name = "";//����������
            string strReceive_user_id = "";// ������id
            string strReceive_user_name = "";//����������
            string strOperator_user_id = "";//������id
            string strOperator_user_name = "";//����������(��Ϣ�༭��)
            string strType_name = "";//����
            string strContent = "";//����
            string strAdd_time = "";//����ʱ��
            string strMsg_status = "";//�Ƿ񷢲�
            strIsreply = "";//�Ƿ���Ҫ����
            string strType_name_cy = "";//��Ϣ����
            string strOperator_user_sender = "";//����Ϣ�༭�����ڵĿ��ң�
            string strSection_target = "";//��������
            strSECTION_ID = "";//����id
            string strSql = @"select id,
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
                              from t_msg_info where id='" + str_id + "'";
            DataSet ds = App.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                strContent_id = ds.Tables[0].Rows[0]["content_id"].ToString();
                if (ds.Tables[0].Rows[0]["Receive_user_id"].ToString() != "")
                {
                    strReceive_user_id = ds.Tables[0].Rows[0]["Receive_user_id"].ToString();
                }
                else
                {
                    strReceive_user_id = "";
                }
                if (ds.Tables[0].Rows[0]["pid"].ToString() != "")
                {
                    strLk_section_id = ds.Tables[0].Rows[0]["pid"].ToString();
                }
                else
                {
                    strLk_section_id = App.UserAccount.CurrentSelectRole.Section_Id.ToString();
                }
                if (ds.Tables[0].Rows[0]["patient_name"].ToString() != "")
                {
                    strLk_section_name = ds.Tables[0].Rows[0]["patient_name"].ToString();
                }
                else
                {
                    strLk_section_name = "";

                }
                if (ds.Tables[0].Rows[0]["Receive_user_name"].ToString() != "")
                {
                    strReceive_user_name = ds.Tables[0].Rows[0]["Receive_user_name"].ToString();
                }
                else
                {
                    strReceive_user_name = "";
                }
                if (ds.Tables[0].Rows[0]["type_id"].ToString() != "")
                {
                    strType = ds.Tables[0].Rows[0]["type_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Operator_user_id"].ToString() != "")
                {
                    strOperator_user_id = ds.Tables[0].Rows[0]["Operator_user_id"].ToString();
                }
                else
                {
                    strOperator_user_id = "";
                }
                if (ds.Tables[0].Rows[0]["Operator_user_name"].ToString() != "")
                {
                    strOperator_user_name = ds.Tables[0].Rows[0]["Operator_user_name"].ToString();
                }
                else
                {
                    strOperator_user_name = "";
                }
                if (ds.Tables[0].Rows[0]["Type_name"].ToString() != "")
                {
                    strType_name = ds.Tables[0].Rows[0]["Type_name"].ToString();
                }
                else
                {
                    strType_name = "";
                }
                if (ds.Tables[0].Rows[0]["Content"].ToString() != "")
                {
                    strContent = ds.Tables[0].Rows[0]["Content"].ToString();
                }
                else
                {
                    strContent = "";
                }
                if (ds.Tables[0].Rows[0]["Add_time"].ToString() != "")
                {
                    strAdd_time = ds.Tables[0].Rows[0]["Add_time"].ToString();
                }
                else
                {
                    strAdd_time = "";
                }
                if (ds.Tables[0].Rows[0]["Msg_status"].ToString() != "")
                {
                    strMsg_status = ds.Tables[0].Rows[0]["Msg_status"].ToString();
                }
                else
                {
                    strMsg_status = "";
                }
                if (ds.Tables[0].Rows[0]["Isreply"].ToString() != "")
                {
                    strIsreply = ds.Tables[0].Rows[0]["Isreply"].ToString();
                }
                else
                {
                    strIsreply = "";
                }
                if (ds.Tables[0].Rows[0]["Type_name_cy"].ToString() != "")
                {
                    strType_name_cy = ds.Tables[0].Rows[0]["Type_name_cy"].ToString();
                }
                else
                {
                    strType_name_cy = "";
                }
                if (ds.Tables[0].Rows[0]["Receive_user_id"].ToString() != "")
                {
                    strReceive_user_id = ds.Tables[0].Rows[0]["Receive_user_id"].ToString();
                }
                else
                {
                    strReceive_user_id = "";
                }
                if (ds.Tables[0].Rows[0]["Operator_user_sender"].ToString() != "")
                {
                    strOperator_user_sender = ds.Tables[0].Rows[0]["Operator_user_sender"].ToString();
                }
                else
                {
                    strOperator_user_sender = "";
                }
                if (ds.Tables[0].Rows[0]["Section_target"].ToString() != "")
                {
                    strSection_target = ds.Tables[0].Rows[0]["Section_target"].ToString();
                }
                else
                {
                    strSection_target = "";
                }
                if (ds.Tables[0].Rows[0]["SECTION_ID"].ToString() != "")
                {
                    strSECTION_ID = ds.Tables[0].Rows[0]["SECTION_ID"].ToString();

                }
                else
                {
                    strSECTION_ID = "";
                }
                if (str_Content_id == "1" || str_Content_id == "D" || str_Content_id == "N")//�����շ�ʽ�ֱ�ΪȫԺ,ȫ��ҽ��,ȫ�廤ʿʱ��
                {
                    if (str_Content_id == "1")
                    {
                        cbReceiver.SelectedIndex = 0;
                    }
                    if (str_Content_id == "D")
                    {
                        cbReceiver.SelectedIndex = 1;
                    }
                    if (str_Content_id == "N")
                    {
                        cbReceiver.SelectedIndex = 2;
                    }
                    btnSection_select.Visible = false;
                    txtPerson.Text = "";
                    txtPerson.Visible = false;
                    panel1.Visible = false;
                    panel2.Visible = false;
                    txtReceiveName.Visible = false;
                    txtReceiveName.Text = "";
                    if (strType_name_cy == "��ͨ��Ϣ")
                    {
                        cbNewsType.SelectedIndex = 0;
                    }
                    if (strType_name_cy == "��Ҫ��Ϣ")
                    {
                        cbNewsType.SelectedIndex = 1;
                    }
                    if (strType_name_cy == "������Ϣ")
                    {
                        cbNewsType.SelectedIndex = 2;
                    }
                    txtTitle.Text = strType_name;
                    txtContent.Text = strContent;
                    if (strType == "1")
                    {
                        cbSection.Text = strLk_section_name;
                        cbSection.Checked = true;
                    }
                    else
                    {
                        cbSection.Text = strLk_section_name;
                        cbSection.Checked = false;
                    }
                    txtEditor.Text = strOperator_user_name;
                    if (strIsreply == "1")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
                if (str_Content_id == "4")//����
                {
                    cbReceiver.SelectedIndex = 3;
                    btnSection_select.Visible = true;
                    if (strType_name_cy == "��ͨ��Ϣ")
                    {
                        cbNewsType.SelectedIndex = 0;
                    }
                    if (strType_name_cy == "��Ҫ��Ϣ")
                    {
                        cbNewsType.SelectedIndex = 1;
                    }
                    if (strType_name_cy == "������Ϣ")
                    {
                        cbNewsType.SelectedIndex = 2;
                    }
                    txtTitle.Text = strType_name;
                    txtContent.Text = strContent;
                    if (strType == "1")
                    {
                        cbSection.Text = strLk_section_name;
                        cbSection.Checked = true;
                    }
                    else
                    {
                        cbSection.Text = strLk_section_name;
                        cbSection.Checked = false;
                    }
                    txtEditor.Text = strOperator_user_name;
                    if (strIsreply == "1")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
                if (str_Content_id == "5")//����
                {
                    cbReceiver.SelectedIndex = 4;
                    btnSection_select.Visible = true;
                    if (strType_name_cy == "��ͨ��Ϣ")
                    {
                        cbNewsType.SelectedIndex = 0;
                    }
                    if (strType_name_cy == "��Ҫ��Ϣ")
                    {
                        cbNewsType.SelectedIndex = 1;
                    }
                    if (strType_name_cy == "������Ϣ")
                    {
                        cbNewsType.SelectedIndex = 2;
                    }
                    txtTitle.Text = strType_name;
                    txtContent.Text = strContent;
                    if (strType == "1")
                    {
                        cbSection.Text = strLk_section_name;
                        cbSection.Checked = true;
                    }
                    else
                    {
                        cbSection.Text = strLk_section_name;
                        cbSection.Checked = false;
                    }
                    txtEditor.Text = strOperator_user_name;
                    if (strIsreply == "1")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
                if (str_Content_id == "6")
                {
                    cbReceiver.SelectedIndex = 5;
                    txtPerson.Visible = true;
                    // txtPerson.Text = strReceive_user_name;
                    panel2.Visible = true;
                    txtReceiveName.Visible = true;
                    txtReceiveName.Text = strSection_target;
                    panel2.Visible = true;
                    string strsql = "select * from t_msg_user t where t.id='" + str_id + "'";
                    DataSet dst = App.GetDataSet(strsql);
                    if (dst.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                        {
                            dgvUser.Rows.Add();
                            dgvUser.Rows[i].Cells["Column1"].Value = dst.Tables[0].Rows[i]["user_id"].ToString();
                            dgvUser.Rows[i].Cells["Column2"].Value = dst.Tables[0].Rows[i]["user_name"].ToString();
                        }
                    }
                    if (strType_name_cy == "��ͨ��Ϣ")
                    {
                        cbNewsType.SelectedIndex = 0;
                    }
                    if (strType_name_cy == "��Ҫ��Ϣ")
                    {
                        cbNewsType.SelectedIndex = 1;
                    }
                    if (strType_name_cy == "������Ϣ")
                    {
                        cbNewsType.SelectedIndex = 2;
                    }
                    txtTitle.Text = strType_name;
                    txtContent.Text = strContent;
                    if (strType == "1")
                    {
                        cbSection.Text = strLk_section_name;
                        cbSection.Checked = true;
                    }
                    else
                    {
                        cbSection.Text = strLk_section_name;
                        cbSection.Checked = false;
                    }
                    txtEditor.Text = strOperator_user_name;
                    if (strIsreply == "1")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
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
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    if (dgvUser.Rows.Count == 0)
                    {
                        App.Msg("��ǰ������Ϊ�գ��޷�������Ϣ��");
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
                    //strSection_names = txtReceiveName.Text.ToString(); //����������ȡ����ǰ�Ľ��շ�ʽ
                    strSection_names = "";
                }
                if (cbReceiver.SelectedItem.ToString() == "����" || cbReceiver.SelectedItem.ToString() == "����")
                {
                    if (str_Content_id == "4" || str_Content_id == "5")
                    {
                        string strName = "";
                        if (str_Content_id == "4")
                        {
                            strName = "����";
                        }
                        else
                        {
                            strName = "����";
                        }
                        if (cbReceiver.SelectedItem.ToString() != strName)
                        {
                            if (strSection_ids == "")
                            {
                                App.Msg("������Ϊ���һ���ʱ�����һ�����ѡ����Ϊ�գ�");
                                return;
                            }
                        }
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

                if (cbSection.Checked == true)
                {
                    strType = "1";
                }
                else
                {
                    strType = "0";
                    strLk_section_id = "";
                    strLk_section_name = "";
                }
                string strUpdate_save_sql = "";     //��(�Ƿ���Ҫ����)�����䶯ʱ,���±���t_msg_user���е��Ƿ���Ҫ������Ϣ
                string strDelete_all_sql = "";    //ɾ����ǰ������ΪȫԺ,ȫ��ҽ��,ȫ�廤ʿ�Ľ���Ȩ��
                string strSave_qy_sql = "";       //�������ý�����ΪȫԺ�Ľ���Ȩ��
                string strSave_allDoctor_sql = "";//�������ý�����Ϊȫ��ҽ���Ľ���Ȩ��
                string strSave_allNurse_sql = ""; //�������ý�����Ϊȫ�廤ʿ�Ľ���Ȩ��
                string strdelete_section_sql = "";//ɾ���洢���һ�����������Ϣ
                string strSection_user_sql = "";  //ͨ������idȥ��ѯ��ǰ�������е��û�
                string strSickArea_user_sql = ""; //ͨ������idȥ��ѯ��ǰ�������е��û�
                string strSave_section_sql = "";  //���±�����һ�����������Ϣ
                string strdelete_user_sql = "";   //ɾ���洢�û����Ӧ����Ϣ
                string strSave_User_sql = "";     //���±����û����Ӧ����Ϣ
                string strSave_sql = "";          //��������Ϣ���¼��Ϣ
                if (str_Content_id != "" && str_id != "")//�޸���Ϣ�����е��߼�
                {
                    //��������ΪȫԺ,ȫ��ҽ��,ȫ�廤ʿʱ��
                    if (cbReceiver.SelectedItem.ToString() == "ȫԺ" || cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��" || cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                    {
                        if (cbReceiver.SelectedItem.ToString() == "ȫԺ")
                        {
                            if (str_Content_id == "1")//����Ϣû���޸�֮ǰ�Ľ�������ȫԺ���޸ĺ���ȫԺ
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//����Ϣû���޸�֮ǰ�Ľ����˲���ȫԺ���޸ĺ���ȫԺ
                            {
                                strDelete_all_sql = "delete  from t_msg_user t where t.id='" + str_id + "'";
                                sqls.Add(strDelete_all_sql);
                                string strTotal_sql = "select t.user_id,t.user_name from t_userinfo t";
                                DataSet ds_qy = App.GetDataSet(strTotal_sql);
                                if (ds_qy.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds_qy.Tables[0].Rows.Count; i++)
                                    {
                                        strSave_qy_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + str_id + "','" + ds_qy.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_qy.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','','','','')";
                                        sqls.Add(strSave_qy_sql);
                                    }
                                }
                            }

                        }
                        if (cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��")
                        {
                            if (str_Content_id == "D")//����Ϣû���޸�֮ǰ�Ľ�������ȫ��ҽ�����޸ĺ���ȫ��ҽ��
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//����Ϣû���޸�֮ǰ�Ľ����˲���ȫ��ҽ�����޸ĺ���ȫ��ҽ��
                            {
                                strDelete_all_sql = "delete  from t_msg_user t where t.id='" + str_id + "'";
                                sqls.Add(strDelete_all_sql);
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
                                            values('" + str_id + "','" + ds_allDoctor.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_allDoctor.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','D','','','')";
                                        sqls.Add(strSave_allDoctor_sql);
                                    }
                                }
                            }
                        }
                        if (cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                        {
                            if (str_Content_id == "N")//����Ϣû���޸�֮ǰ�Ľ�������ȫ�廤ʿ���޸ĺ���ȫ�廤ʿ
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//����Ϣû���޸�֮ǰ�Ľ����˲���ȫ�廤ʿ���޸ĺ���ȫ�廤ʿ
                            {
                                strDelete_all_sql = "delete  from t_msg_user t where t.id='" + str_id + "'";
                                sqls.Add(strDelete_all_sql);
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
                                            values('" + str_id + "','" + ds_allNurse.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_allNurse.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','N','','','')";
                                        sqls.Add(strSave_allNurse_sql);
                                    }
                                }
                            }
                        }
                    }
                    //��������Ϊ���һ���ʱ:
                    if (cbReceiver.SelectedItem.ToString() == "����" || cbReceiver.SelectedItem.ToString() == "����")//���һ��������´���
                    {

                        if (strSection_ids != "" && strSection_ids != strSECTION_ID)//˵����ǰ���һ����Ѿ�����ѡ��
                        {
                            strdelete_section_sql = "delete from  t_msg_user t  where t.id='" + str_id + "'";
                            sqls.Add(strdelete_section_sql);
                            string[] strSection_NAMES = strSection_ids.Split(',');
                            for (int i = 0; i < strSection_NAMES.Length; i++)
                            {
                                if (cbReceiver.SelectedItem.ToString() == "����")
                                {
                                    strSection_user_sql = @"select distinct(a.user_id),a.user_name,e.sid,e.section_name
                                                  from t_userinfo       a,
                                                       t_account_user   b,
                                                       t_acc_role       c,
                                                       t_acc_role_range d,
                                                       t_sectioninfo    e
                                                 where a.user_id = b.user_id
                                                   and b.account_id = c.account_id 
                                                   and c.id = d.acc_role_id
                                                   and d.section_id = e.sid
                                                   and e.sid='" + strSection_NAMES[i] + "'";
                                    DataSet ds_section = App.GetDataSet(strSection_user_sql);
                                    if (ds_section.Tables[0].Rows.Count > 0)
                                    {
                                        for (int j = 0; j < ds_section.Tables[0].Rows.Count; j++)
                                        {
                                            strSave_section_sql = " insert into t_msg_user(id,user_id,user_name, section_id,isreply,role_type,sickarea_id,read_flag,make_sure,dispose_time) values  ('" + str_id + "', '" + ds_section.Tables[0].Rows[j]["user_id"].ToString() + "', '" + ds_section.Tables[0].Rows[j]["user_name"].ToString() + "', '" + strSection_NAMES[i] + "','" + strIsSend + "','','','','','')";
                                            sqls.Add(strSave_section_sql);
                                        }
                                    }
                                }
                                else
                                {
                                    strSickArea_user_sql = @"select distinct( a.user_id),a.user_name,e.said,e.sick_area_name
                                                      from t_userinfo       a,
                                                           t_account_user   b,
                                                           t_acc_role       c,
                                                           t_acc_role_range d,
                                                           t_sickareainfo  e
                                                     where a.user_id = b.user_id
                                                       and b.account_id = c.account_id 
                                                       and c.id = d.acc_role_id
                                                       and d.sickarea_id = e.said
                                                   and e.said='" + strSection_NAMES[i] + "'";
                                    DataSet ds_sickArea = App.GetDataSet(strSickArea_user_sql);
                                    if (ds_sickArea.Tables[0].Rows.Count > 0)
                                    {
                                        for (int j = 0; j < ds_sickArea.Tables[0].Rows.Count; j++)
                                        {
                                            strSave_section_sql = " insert into t_msg_user(id,user_id,user_name, section_id,isreply,role_type,sickarea_id,read_flag,make_sure,dispose_time) values  ('" + str_id + "', '" + ds_sickArea.Tables[0].Rows[j]["user_id"].ToString() + "', '" + ds_sickArea.Tables[0].Rows[j]["user_name"].ToString() + "', '','" + strIsSend + "','','" + strSection_NAMES[i] + "','','','')";
                                            sqls.Add(strSave_section_sql);
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            if (str_Content_id == "4" || str_Content_id == "5")//���һ���û�з����仯
                            {
                                if (strIsreply != strIsSend)//�����Ƿ���Ҫ���������˱仯
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                        }
                    }
                    //��������Ϊ����ʱ��
                    if (cbReceiver.SelectedItem.ToString() == "����")
                    {
                        strdelete_user_sql = "delete from t_msg_user t where t.id='" + str_id + "'";
                        sqls.Add(strdelete_user_sql);
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
                            strSave_User_sql = "insert into t_msg_user(id,user_id,user_name,section_id,isreply,role_type,sickarea_id,read_flag,make_sure, dispose_time) values ('" + str_id + "','" + dgvUser.Rows[i].Cells["Column1"].Value.ToString() + "','" + dgvUser.Rows[i].Cells["Column2"].Value.ToString() + "','','" + strIsSend + "','','','','','')";
                            sqls.Add(strSave_User_sql);
                        }
                    }
                    //��������Ϣ��
                    if (strSection_names != "")
                    {
                        strSave_sql = @"update t_msg_info  set pid='" + strLk_section_id + "',patient_name='" + strLk_section_name + "',receive_user_id='" + strUser_id + "', receive_user_name='" + txtPerson.Text + "',type_id='" + strType + "',operator_user_id='" + strtxtEditor_id + "',operator_user_name='" + txtEditor.Text + "',type_name='" + txtTitle.Text + "',content_id='" + strCONTENT_ID + "',content='" + txtContent.Text + "',msg_status='0',isreply='" + strIsSend + "',type_name_cy='" + cbNewsType.SelectedItem.ToString() + "',section_target='" + strSection_names + "',SECTION_ID='" + strSection_ids + "' where id='" + str_id + "'";
                    }
                    else
                    {
                        strSave_sql = @"update t_msg_info  set pid='" + strLk_section_id + "',patient_name='" + strLk_section_name + "',receive_user_id='" + strUser_id + "', receive_user_name='" + txtPerson.Text + "',type_id='" + strType + "',operator_user_id='" + strtxtEditor_id + "',operator_user_name='" + txtEditor.Text + "',type_name='" + txtTitle.Text + "',content_id='" + strCONTENT_ID + "',content='" + txtContent.Text + "',msg_status='0',isreply='" + strIsSend + "',type_name_cy='" + cbNewsType.SelectedItem.ToString() + "' where id='" + str_id + "'";
                    }

                    sqls.Add(strSave_sql);

                }
                int n = App.ExecuteBatch(sqls.ToArray());
                if (n > 0)
                {
                    App.Msg("����ɹ���");
                    this.Close();

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
            radioButton2.Checked = true;
            txtPerson.Visible = false;
            panel1.Visible = false;
            txtReceiveName.Text = "";
            txtReceiveName.Visible = false;
            panel2.Visible = false;
            dgvUser.Rows.Clear();
            strSection_ids = "";
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
                    if (str_Content_id == "4" || str_Content_id == "5")
                    {
                        string strName = "";
                        if (str_Content_id == "4")
                        {
                            strName = "����";
                        }
                        else
                        {
                            strName = "����";
                        }
                        if (cbReceiver.SelectedItem.ToString() != strName)
                        {
                            if (strSection_ids == "")
                            {
                                App.Msg("������Ϊ���һ���ʱ�����һ�����ѡ����Ϊ�գ�");
                                return;
                            }
                        }
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
                if (cbSection.Checked == true)
                {
                    strType = "1";
                }
                else
                {
                    strType = "0";
                    strLk_section_id = "";
                    strLk_section_name = "";

                }
                string strUpdate_save_sql = "";   //��(�Ƿ���Ҫ����)�����䶯ʱ,���±���t_msg_user���е��Ƿ���Ҫ������Ϣ
                string strDelete_all_sql = "";    //ɾ����ǰ������ΪȫԺ,ȫ��ҽ��,ȫ�廤ʿ�Ľ���Ȩ��
                string strSave_qy_sql = "";       //�������ý�����ΪȫԺ�Ľ���Ȩ��
                string strSave_allDoctor_sql = "";//�������ý�����Ϊȫ��ҽ���Ľ���Ȩ��
                string strSave_allNurse_sql = ""; //�������ý�����Ϊȫ�廤ʿ�Ľ���Ȩ��
                string strdelete_section_sql = "";//ɾ���洢���һ�����������Ϣ
                string strSection_user_sql = "";  //ͨ������idȥ��ѯ��ǰ�������е��û�
                string strSickArea_user_sql = ""; //ͨ������idȥ��ѯ��ǰ�������е��û�
                string strSave_section_sql = "";  //���±�����һ�����������Ϣ
                string strdelete_user_sql = "";   //ɾ���洢�û����Ӧ����Ϣ
                string strSave_User_sql = "";     //���±����û����Ӧ����Ϣ
                string strSend_sql = "";          //��������¼��Ϣ
                if (str_Content_id != "" && str_id != "")
                {
                    //��������ΪȫԺ,ȫ��ҽ��,ȫ�廤ʿʱ��
                    if (cbReceiver.SelectedItem.ToString() == "ȫԺ" || cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��" || cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                    {
                        if (cbReceiver.SelectedItem.ToString() == "ȫԺ")
                        {
                            if (str_Content_id == "1")//����Ϣû���޸�֮ǰ�Ľ�������ȫԺ���޸ĺ���ȫԺ
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//����Ϣû���޸�֮ǰ�Ľ����˲���ȫԺ���޸ĺ���ȫԺ
                            {
                                strDelete_all_sql = "delete  from t_msg_user t where t.id='" + str_id + "'";
                                sqls.Add(strDelete_all_sql);
                                string strTotal_sql = "select t.user_id,t.user_name from t_userinfo t";
                                DataSet ds_qy = App.GetDataSet(strTotal_sql);
                                if (ds_qy.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds_qy.Tables[0].Rows.Count; i++)
                                    {
                                        strSave_qy_sql = @"insert into t_msg_user
                                              (id, user_id, user_name, section_id, isreply, role_type, sickarea_id,READ_FLAG,MAKE_SURE)
                                            values('" + str_id + "','" + ds_qy.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_qy.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','','','','')";
                                        sqls.Add(strSave_qy_sql);
                                    }
                                }
                            }

                        }
                        if (cbReceiver.SelectedItem.ToString() == "ȫ��ҽ��")
                        {
                            if (str_Content_id == "D")//����Ϣû���޸�֮ǰ�Ľ�������ȫ��ҽ�����޸ĺ���ȫ��ҽ��
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//����Ϣû���޸�֮ǰ�Ľ����˲���ȫ��ҽ�����޸ĺ���ȫ��ҽ��
                            {
                                strDelete_all_sql = "delete  from t_msg_user t where t.id='" + str_id + "'";
                                sqls.Add(strDelete_all_sql);
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
                                            values('" + str_id + "','" + ds_allDoctor.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_allDoctor.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','D','','','')";
                                        sqls.Add(strSave_allDoctor_sql);
                                    }
                                }
                            }
                        }
                        if (cbReceiver.SelectedItem.ToString() == "ȫ�廤ʿ")
                        {
                            if (str_Content_id == "N")//����Ϣû���޸�֮ǰ�Ľ�������ȫ�廤ʿ���޸ĺ���ȫ�廤ʿ
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//����Ϣû���޸�֮ǰ�Ľ����˲���ȫ�廤ʿ���޸ĺ���ȫ�廤ʿ
                            {
                                strDelete_all_sql = "delete  from t_msg_user t where t.id='" + str_id + "'";
                                sqls.Add(strDelete_all_sql);
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
                                            values('" + str_id + "','" + ds_allNurse.Tables[0].Rows[i]["user_id"].ToString() + "','" + ds_allNurse.Tables[0].Rows[i]["user_name"].ToString() + "','','" + strIsSend + "','N','','','')";
                                        sqls.Add(strSave_allNurse_sql);
                                    }
                                }
                            }
                        }
                    }
                    //��������Ϊ���һ���ʱ:
                    if (cbReceiver.SelectedItem.ToString() == "����" || cbReceiver.SelectedItem.ToString() == "����")//���һ��������´���
                    {

                        if (strSection_ids != "" && strSection_ids != strSECTION_ID)//˵����ǰ���һ����Ѿ�����ѡ��
                        {
                            strdelete_section_sql = "delete from  t_msg_user t  where t.id='" + str_id + "'";
                            sqls.Add(strdelete_section_sql);
                            string[] strSection_NAMES = strSection_ids.Split(',');
                            for (int i = 0; i < strSection_NAMES.Length; i++)
                            {
                                if (cbReceiver.SelectedItem.ToString() == "����")
                                {
                                    strSection_user_sql = @"select distinct(a.user_id),a.user_name,e.sid,e.section_name
                                                  from t_userinfo       a,
                                                       t_account_user   b,
                                                       t_acc_role       c,
                                                       t_acc_role_range d,
                                                       t_sectioninfo    e
                                                 where a.user_id = b.user_id
                                                   and b.account_id = c.account_id 
                                                   and c.id = d.acc_role_id
                                                   and d.section_id = e.sid
                                                   and e.sid='" + strSection_NAMES[i] + "'";
                                    DataSet ds_section = App.GetDataSet(strSection_user_sql);
                                    if (ds_section.Tables[0].Rows.Count > 0)
                                    {
                                        for (int j = 0; j < ds_section.Tables[0].Rows.Count; j++)
                                        {
                                            strSave_section_sql = " insert into t_msg_user(id,user_id,user_name, section_id,isreply,role_type,sickarea_id,read_flag,make_sure,dispose_time) values  ('" + str_id + "', '" + ds_section.Tables[0].Rows[j]["user_id"].ToString() + "', '" + ds_section.Tables[0].Rows[j]["user_name"].ToString() + "', '" + strSection_NAMES[i] + "','" + strIsSend + "','','','','','')";
                                            sqls.Add(strSave_section_sql);
                                        }
                                    }
                                }
                                else
                                {
                                    strSickArea_user_sql = @"select distinct( a.user_id),a.user_name,e.said,e.sick_area_name
                                                      from t_userinfo       a,
                                                           t_account_user   b,
                                                           t_acc_role       c,
                                                           t_acc_role_range d,
                                                           t_sickareainfo  e
                                                     where a.user_id = b.user_id
                                                       and b.account_id = c.account_id 
                                                       and c.id = d.acc_role_id
                                                       and d.sickarea_id = e.said
                                                   and e.said='" + strSection_NAMES[i] + "'";
                                    DataSet ds_sickArea = App.GetDataSet(strSickArea_user_sql);
                                    if (ds_sickArea.Tables[0].Rows.Count > 0)
                                    {
                                        for (int j = 0; j < ds_sickArea.Tables[0].Rows.Count; j++)
                                        {
                                            strSave_section_sql = " insert into t_msg_user(id,user_id,user_name, section_id,isreply,role_type,sickarea_id,read_flag,make_sure,dispose_time) values  ('" + str_id + "', '" + ds_sickArea.Tables[0].Rows[j]["user_id"].ToString() + "', '" + ds_sickArea.Tables[0].Rows[j]["user_name"].ToString() + "', '','" + strIsSend + "','','" + strSection_NAMES[i] + "','','','')";
                                            sqls.Add(strSave_section_sql);
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            if (str_Content_id == "4" || str_Content_id == "5")//���һ���û�з����仯
                            {
                                if (strIsreply != strIsSend)//�����Ƿ���Ҫ���������˱仯
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                        }
                    }
                    //��������Ϊ����ʱ��
                    if (cbReceiver.SelectedItem.ToString() == "����")
                    {
                        strdelete_user_sql = "delete from t_msg_user t where t.id='" + str_id + "'";
                        sqls.Add(strdelete_user_sql);
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
                            strSave_User_sql = "insert into t_msg_user(id,user_id,user_name,section_id,isreply,role_type,sickarea_id,read_flag,make_sure, dispose_time) values ('" + str_id + "','" + dgvUser.Rows[i].Cells["Column1"].Value.ToString() + "','" + dgvUser.Rows[i].Cells["Column2"].Value.ToString() + "','','" + strIsSend + "','','','','','')";
                            sqls.Add(strSave_User_sql);
                        }
                    }
                    //������Ϣ��
                    if (strSection_names != "")//����ѡ����һ������ж�
                    {
                        strSend_sql = @"update t_msg_info  set pid='" + strLk_section_id + "',patient_name='" + strLk_section_name + "', receive_user_id='" + strUser_id + "', receive_user_name='" + txtPerson.Text + "',operator_user_id='" + strtxtEditor_id + "',operator_user_name='" + txtEditor.Text + "',type_id='" + strType + "',type_name='" + txtTitle.Text + "',content_id='" + strCONTENT_ID + "',content='" + txtContent.Text + "',add_time= to_date('" + dtTime.Text + "','yyyy-MM-dd hh24:mi'),msg_status='1',isreply='" + strIsSend + "',type_name_cy='" + cbNewsType.SelectedItem.ToString() + "',section_target='" + strSection_names + "',SECTION_ID='" + strSection_ids + "' where id='" + str_id + "'";
                        sqls.Add(strSend_sql);
                    }
                    else
                    {
                        strSend_sql = @"update t_msg_info  set  pid='" + strLk_section_id + "',patient_name='" + strLk_section_name + "',receive_user_id='" + strUser_id + "', receive_user_name='" + txtPerson.Text + "',operator_user_id='" + strtxtEditor_id + "',operator_user_name='" + txtEditor.Text + "',type_id='" + strType + "',type_name='" + txtTitle.Text + "',content_id='" + strCONTENT_ID + "',content='" + txtContent.Text + "',add_time= to_date('" + dtTime.Text + "','yyyy-MM-dd hh24:mi'),msg_status='1',isreply='" + strIsSend + "',type_name_cy='" + cbNewsType.SelectedItem.ToString() + "' where id='" + str_id + "'";
                        sqls.Add(strSend_sql);
                    }

                }
                int n = App.ExecuteBatch(sqls.ToArray());
                if (n > 0)
                {
                    App.Msg("�����ɹ���");
                    this.Close();

                }
                else
                {
                    App.Msg("����ʧ�ܣ�");
                    return;
                }
            }
            catch { }

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
                    frmSectionCheck frm = new frmSectionCheck(2, strSection_ids, strSection_names);
                    frm.ShowDialog();
                    if (frm.flag)
                    {
                        strSection_ids = frmSectionCheck.YwcSectionID;

                        strSection_names = frmSectionCheck.YwcSectionName;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "����")
                {
                    frmSectionCheck frm = new frmSectionCheck(3, strSection_ids, strSection_names);
                    frm.ShowDialog();
                    if (frm.flag)
                    {
                        strSection_ids = frmSectionCheck.YwcSectionID;

                        strSection_names = frmSectionCheck.YwcSectionName;
                    }
                }
                return;
            }
            if (cbReceiver.SelectedItem.ToString() == "����")//�޸���Ϣ�����е��߼������ң�
            {
                string strSql = "select t.section_id,t.section_target from t_msg_info  t  where t.id='" + str_id + "'";
                DataSet ds = App.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strMSGSECTION_ID = ds.Tables[0].Rows[0]["section_id"].ToString();
                    strMSG_SECTION_NAME = ds.Tables[0].Rows[0]["section_target"].ToString();
                }
                frmSectionCheck frm = new frmSectionCheck(2, strMSGSECTION_ID, strMSG_SECTION_NAME);
                frm.ShowDialog();
                if (frm.flag)
                {
                    strSection_ids = frmSectionCheck.YwcSectionID;
                    strSection_names = frmSectionCheck.YwcSectionName;
                }
                return;
            }
            if (cbReceiver.SelectedItem.ToString() == "����")//�޸���Ϣ�����е��߼���������
            {
                string strSql = "select t.section_id,t.section_target from t_msg_info  t  where t.id='" + str_id + "'";
                DataSet ds = App.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strMSGSECTION_ID = ds.Tables[0].Rows[0]["section_id"].ToString();
                    strMSG_SECTION_NAME = ds.Tables[0].Rows[0]["section_target"].ToString();
                }
                frmSectionCheck frm = new frmSectionCheck(3, strMSGSECTION_ID, strMSG_SECTION_NAME);
                frm.ShowDialog();
                if (frm.flag)
                {
                    strSection_ids = frmSectionCheck.YwcSectionID;

                    strSection_names = frmSectionCheck.YwcSectionName;
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
        /// ��������Ϊ����ʱ����������Ѿ�ѡ�еĽ�������Ϣ
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
        /// �ر�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}