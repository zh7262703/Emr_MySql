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
        /// 消息发布新增界面  袁杨   141106
        /// </summary>
        /// <summary>
        /// 用来接收科室id的集合
        /// </summary>
        public string strSection_ids = "";
        /// <summary>
        /// 用来接收科室名称的集合
        /// </summary>
        public string strSection_names = "";
        /// <summary>
        /// 用来接收当前接收人id
        /// </summary>
        public string strUser_id = "";
        /// <summary>
        /// 用来接收当前接收人id的集合
        /// </summary>
        public string strUser_ids = "";
        /// <summary>
        /// 用来接收当前登陆科室id
        /// </summary>
        public string strtxtLkSection_id = "";
        /// <summary>
        /// 用来接收当前登录人id
        /// </summary>
        public string strtxtEditor_id = "";
        /// <summary>
        /// 用来接收需要修改的消息的主键
        /// </summary>
        public string str_id = "";
        /// <summary>
        /// 用来接收需要修改的消息的接收方式
        /// </summary>
        public string str_Content_id = "";
        /// <summary>
        /// 用来跳出修改消息时自动触发cbReceiver_SelectedIndexChanged事件
        /// </summary>
        bool flag = false;
        /// <summary>
        /// 科室id集合
        /// </summary>
        public string strMSGSECTION_ID = "";
        /// <summary>
        /// 科室名称集合
        /// </summary>
        public string strMSG_SECTION_NAME = "";
        /// <summary>
        /// 是否需要收条
        /// </summary>
        public string strIsreply = "";
        /// <summary>
        /// 修改时所要记录的id集合
        /// </summary>
        public string strSECTION_ID = "";
        /// <summary>
        /// 判断落款的方式
        /// </summary>
        public string strType = "";
        /// <summary>
        /// 落款科室id
        /// </summary>
        public string strLk_section_id = "";
        /// <summary>
        /// 落款科室名称
        /// </summary>
        public string strLk_section_name = "";

        public frmMsgSendDetailsUpdate()
        {
            InitializeComponent();
        }
        public frmMsgSendDetailsUpdate(string id, string content_id)
        {
            InitializeComponent();
            str_id = id; //接收主键
            str_Content_id = content_id; //用来 接收（接收方式）
        }

        /// <summary>
        ///  科室变化触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbReceiver_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (cbReceiver.SelectedItem.ToString() == "个人")
                {
                    txtPerson.Visible = true;
                    this.btnSection_select.Visible = false;
                    strSection_ids = "";
                    strSection_names = "";

                }
                if (cbReceiver.SelectedItem.ToString() == "科室" || cbReceiver.SelectedItem.ToString() == "病区")
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
                if (cbReceiver.SelectedItem.ToString() == "全院" || cbReceiver.SelectedItem.ToString() == "全体医生" || cbReceiver.SelectedItem.ToString() == "全体护士")
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
        /// 拼音简码搜索用户名称
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
                        dgvSendPerson.Rows.Add();//先添加一行
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
        /// 双击选择用户功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSendPerson_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string strUser_name = dgvSendPerson.CurrentRow.Cells["user_name"].Value.ToString();
                strUser_id = dgvSendPerson.CurrentRow.Cells["user_id"].Value.ToString();//给用户id赋值
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
        /// 回车键触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPerson_Enter(object sender, EventArgs e)
        {
            try
            {
                #region 注释掉
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
                    dgvUser.Rows[index].Cells["Column1"].Value = strUser_id.ToString();//接收人id赋值
                    dgvUser.Rows[index].Cells["Column2"].Value = txtPerson.Text.ToString();//接收人名称赋值
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
            string strContent_id = "";//接收方式
            string strPid = "";//落款科室id
            string strPatient_name = "";//落款科室名称
            string strReceive_user_id = "";// 接收人id
            string strReceive_user_name = "";//接收人姓名
            string strOperator_user_id = "";//发送人id
            string strOperator_user_name = "";//发送人姓名(消息编辑者)
            string strType_name = "";//标题
            string strContent = "";//内容
            string strAdd_time = "";//发送时间
            string strMsg_status = "";//是否发布
            strIsreply = "";//是否需要收条
            string strType_name_cy = "";//消息类型
            string strOperator_user_sender = "";//落款（消息编辑者所在的科室）
            string strSection_target = "";//科室名称
            strSECTION_ID = "";//科室id
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
                if (str_Content_id == "1" || str_Content_id == "D" || str_Content_id == "N")//当接收方式分别为全院,全体医生,全体护士时：
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
                    if (strType_name_cy == "普通消息")
                    {
                        cbNewsType.SelectedIndex = 0;
                    }
                    if (strType_name_cy == "重要消息")
                    {
                        cbNewsType.SelectedIndex = 1;
                    }
                    if (strType_name_cy == "紧急消息")
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
                if (str_Content_id == "4")//科室
                {
                    cbReceiver.SelectedIndex = 3;
                    btnSection_select.Visible = true;
                    if (strType_name_cy == "普通消息")
                    {
                        cbNewsType.SelectedIndex = 0;
                    }
                    if (strType_name_cy == "重要消息")
                    {
                        cbNewsType.SelectedIndex = 1;
                    }
                    if (strType_name_cy == "紧急消息")
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
                if (str_Content_id == "5")//病区
                {
                    cbReceiver.SelectedIndex = 4;
                    btnSection_select.Visible = true;
                    if (strType_name_cy == "普通消息")
                    {
                        cbNewsType.SelectedIndex = 0;
                    }
                    if (strType_name_cy == "重要消息")
                    {
                        cbNewsType.SelectedIndex = 1;
                    }
                    if (strType_name_cy == "紧急消息")
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
                    if (strType_name_cy == "普通消息")
                    {
                        cbNewsType.SelectedIndex = 0;
                    }
                    if (strType_name_cy == "重要消息")
                    {
                        cbNewsType.SelectedIndex = 1;
                    }
                    if (strType_name_cy == "紧急消息")
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
        /// 保存
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
                    App.Msg("接收人不许为空！");
                    return;
                }
                if (cbNewsType.SelectedItem.ToString() == "")
                {
                    App.Msg("消息类型不许为空");
                    return;
                }
                if (txtTitle.Text == "")
                {
                    App.Msg("标题不许为空！");
                    return;
                }
                if (txtContent.Text == "")
                {
                    App.Msg("内容不许为空！");
                    return;
                }
                if (cbReceiver.SelectedItem.ToString() != "科室" && cbReceiver.SelectedItem.ToString() != "病区")
                {
                    strSection_ids = "";
                    strSection_names = "";

                }
                if (cbReceiver.SelectedItem.ToString() == "个人")
                {
                    if (dgvUser.Rows.Count == 0)
                    {
                        App.Msg("当前接收人为空，无法保存消息！");
                        return;
                    }
                }
                //接收人的类别 对应消息表t_msg_info中的CONTENT_ID字段
                string strCONTENT_ID = "";
                if (cbReceiver.SelectedItem.ToString() == "全院")
                {
                    strCONTENT_ID = "1";
                    strSection_names = "全院";
                }
                if (cbReceiver.SelectedItem.ToString() == "全体医生")
                {
                    strCONTENT_ID = "D";
                    strSection_names = "全体医生";
                }
                if (cbReceiver.SelectedItem.ToString() == "全体护士")
                {
                    strCONTENT_ID = "N";
                    strSection_names = "全体护士";
                }
                if (cbReceiver.SelectedItem.ToString() == "科室")
                {
                    strCONTENT_ID = "4";
                }
                if (cbReceiver.SelectedItem.ToString() == "病区")
                {
                    strCONTENT_ID = "5";
                }
                if (cbReceiver.SelectedItem.ToString() == "个人")
                {
                    strCONTENT_ID = "6";
                    //strSection_names = txtReceiveName.Text.ToString(); //接收者姓名取消当前的接收方式
                    strSection_names = "";
                }
                if (cbReceiver.SelectedItem.ToString() == "科室" || cbReceiver.SelectedItem.ToString() == "病区")
                {
                    if (str_Content_id == "4" || str_Content_id == "5")
                    {
                        string strName = "";
                        if (str_Content_id == "4")
                        {
                            strName = "科室";
                        }
                        else
                        {
                            strName = "病区";
                        }
                        if (cbReceiver.SelectedItem.ToString() != strName)
                        {
                            if (strSection_ids == "")
                            {
                                App.Msg("接收人为科室或病区时，科室或病区的选择不许为空！");
                                return;
                            }
                        }
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "个人")
                {
                    if (dgvUser.Rows.Count == 0)
                    {
                        App.Msg("当前接收人为空，无法发布消息！");
                        return;
                    }
                }
                string strNewId = App.GenId("t_msg_info", "id").ToString();
                #region 注释掉
                //string strNewId_sql = "select t_msg_info_id.nextval as newId  from dual";
                //DataSet ds = App.GetDataSet(strNewId_sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    strNewId = ds.Tables[0].Rows[0]["newId"].ToString();
                //} 
                #endregion
                string strIsSend = ""; //是否发送收条
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
                string strUpdate_save_sql = "";     //当(是否需要收条)发生变动时,更新保存t_msg_user表中的是否需要收条信息
                string strDelete_all_sql = "";    //删除当前接收人为全院,全体医生,全体护士的接收权限
                string strSave_qy_sql = "";       //重新设置接收人为全院的接收权限
                string strSave_allDoctor_sql = "";//重新设置接收人为全体医生的接收权限
                string strSave_allNurse_sql = ""; //重新设置接收人为全体护士的接收权限
                string strdelete_section_sql = "";//删除存储科室或病区表的相关信息
                string strSection_user_sql = "";  //通过科室id去查询当前科室所有的用户
                string strSickArea_user_sql = ""; //通过病区id去查询当前病区所有的用户
                string strSave_section_sql = "";  //重新保存科室或病区表的相关信息
                string strdelete_user_sql = "";   //删除存储用户表对应的信息
                string strSave_User_sql = "";     //重新保存用户表对应的信息
                string strSave_sql = "";          //保存主消息表记录信息
                if (str_Content_id != "" && str_id != "")//修改消息所运行的逻辑
                {
                    //当接收人为全院,全体医生,全体护士时：
                    if (cbReceiver.SelectedItem.ToString() == "全院" || cbReceiver.SelectedItem.ToString() == "全体医生" || cbReceiver.SelectedItem.ToString() == "全体护士")
                    {
                        if (cbReceiver.SelectedItem.ToString() == "全院")
                        {
                            if (str_Content_id == "1")//本消息没有修改之前的接收人是全院，修改后还是全院
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//本消息没有修改之前的接收人不是全院，修改后是全院
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
                        if (cbReceiver.SelectedItem.ToString() == "全体医生")
                        {
                            if (str_Content_id == "D")//本消息没有修改之前的接收人是全体医生，修改后还是全体医生
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//本消息没有修改之前的接收人不是全体医生，修改后是全体医生
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
                        if (cbReceiver.SelectedItem.ToString() == "全体护士")
                        {
                            if (str_Content_id == "N")//本消息没有修改之前的接收人是全体护士，修改后还是全体护士
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//本消息没有修改之前的接收人不是全体护士，修改后是全体护士
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
                    //当接收人为科室或病区时:
                    if (cbReceiver.SelectedItem.ToString() == "科室" || cbReceiver.SelectedItem.ToString() == "病区")//科室或病区的重新处置
                    {

                        if (strSection_ids != "" && strSection_ids != strSECTION_ID)//说明当前科室或病区已经重新选择
                        {
                            strdelete_section_sql = "delete from  t_msg_user t  where t.id='" + str_id + "'";
                            sqls.Add(strdelete_section_sql);
                            string[] strSection_NAMES = strSection_ids.Split(',');
                            for (int i = 0; i < strSection_NAMES.Length; i++)
                            {
                                if (cbReceiver.SelectedItem.ToString() == "科室")
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
                            if (str_Content_id == "4" || str_Content_id == "5")//科室或病区没有发生变化
                            {
                                if (strIsreply != strIsSend)//但是是否需要收条发生了变化
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                        }
                    }
                    //当接收人为个人时：
                    if (cbReceiver.SelectedItem.ToString() == "个人")
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
                    //更新主消息表
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
                    App.Msg("保存成功！");
                    this.Close();

                }
                else
                {
                    App.Msg("保存失败！");
                    return;
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 清空操作
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
        /// 发送功能
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
                    App.Msg("接收人不许为空！");
                    return;
                }
                if (cbNewsType.SelectedItem.ToString() == "")
                {
                    App.Msg("消息类型不许为空");
                    return;
                }
                if (txtTitle.Text == "")
                {
                    App.Msg("标题不许为空！");
                    return;
                }
                if (txtContent.Text == "")
                {
                    App.Msg("内容不许为空！");
                    return;
                }
                if (cbReceiver.SelectedItem.ToString() != "科室" && cbReceiver.SelectedItem.ToString() != "病区")
                {
                    strSection_ids = "";
                    strSection_names = "";

                }
                if (cbReceiver.SelectedItem.ToString() == "科室" || cbReceiver.SelectedItem.ToString() == "病区")
                {
                    if (str_Content_id == "4" || str_Content_id == "5")
                    {
                        string strName = "";
                        if (str_Content_id == "4")
                        {
                            strName = "科室";
                        }
                        else
                        {
                            strName = "病区";
                        }
                        if (cbReceiver.SelectedItem.ToString() != strName)
                        {
                            if (strSection_ids == "")
                            {
                                App.Msg("接收人为科室或病区时，科室或病区的选择不许为空！");
                                return;
                            }
                        }
                    }
                }
                //接收人的类别 对应消息表t_msg_info中的CONTENT_ID字段
                string strCONTENT_ID = "";
                if (cbReceiver.SelectedItem.ToString() == "全院")
                {
                    strCONTENT_ID = "1";
                    strSection_names = "全院";
                }
                if (cbReceiver.SelectedItem.ToString() == "全体医生")
                {
                    strCONTENT_ID = "D";
                    strSection_names = "全体医生";
                }
                if (cbReceiver.SelectedItem.ToString() == "全体护士")
                {
                    strCONTENT_ID = "N";
                    strSection_names = "全体护士";
                }
                if (cbReceiver.SelectedItem.ToString() == "科室")
                {
                    strCONTENT_ID = "4";
                }
                if (cbReceiver.SelectedItem.ToString() == "病区")
                {
                    strCONTENT_ID = "5";
                }
                if (cbReceiver.SelectedItem.ToString() == "个人")
                {
                    strCONTENT_ID = "6";

                }
                if (cbReceiver.SelectedItem.ToString() == "个人")
                {
                    if (dgvUser.Rows.Count == 0)
                    {
                        App.Msg("当前接收人为空，无法发布消息！");
                        return;
                    }
                }
                string strNewId = App.GenId("t_msg_info", "id").ToString();
                #region 注释掉
                //string strNewId_sql = "select t_msg_info_id.nextval as newId  from dual";
                //DataSet ds = App.GetDataSet(strNewId_sql);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    strNewId = ds.Tables[0].Rows[0]["newId"].ToString();
                //} 
                #endregion
                string strIsSend = ""; //是否发送收条
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
                string strUpdate_save_sql = "";   //当(是否需要收条)发生变动时,更新保存t_msg_user表中的是否需要收条信息
                string strDelete_all_sql = "";    //删除当前接收人为全院,全体医生,全体护士的接收权限
                string strSave_qy_sql = "";       //重新设置接收人为全院的接收权限
                string strSave_allDoctor_sql = "";//重新设置接收人为全体医生的接收权限
                string strSave_allNurse_sql = ""; //重新设置接收人为全体护士的接收权限
                string strdelete_section_sql = "";//删除存储科室或病区表的相关信息
                string strSection_user_sql = "";  //通过科室id去查询当前科室所有的用户
                string strSickArea_user_sql = ""; //通过病区id去查询当前病区所有的用户
                string strSave_section_sql = "";  //重新保存科室或病区表的相关信息
                string strdelete_user_sql = "";   //删除存储用户表对应的信息
                string strSave_User_sql = "";     //重新保存用户表对应的信息
                string strSend_sql = "";          //保存主记录信息
                if (str_Content_id != "" && str_id != "")
                {
                    //当接收人为全院,全体医生,全体护士时：
                    if (cbReceiver.SelectedItem.ToString() == "全院" || cbReceiver.SelectedItem.ToString() == "全体医生" || cbReceiver.SelectedItem.ToString() == "全体护士")
                    {
                        if (cbReceiver.SelectedItem.ToString() == "全院")
                        {
                            if (str_Content_id == "1")//本消息没有修改之前的接收人是全院，修改后还是全院
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//本消息没有修改之前的接收人不是全院，修改后是全院
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
                        if (cbReceiver.SelectedItem.ToString() == "全体医生")
                        {
                            if (str_Content_id == "D")//本消息没有修改之前的接收人是全体医生，修改后还是全体医生
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//本消息没有修改之前的接收人不是全体医生，修改后是全体医生
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
                        if (cbReceiver.SelectedItem.ToString() == "全体护士")
                        {
                            if (str_Content_id == "N")//本消息没有修改之前的接收人是全体护士，修改后还是全体护士
                            {
                                if (strIsreply != strIsSend)
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                            else//本消息没有修改之前的接收人不是全体护士，修改后是全体护士
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
                    //当接收人为科室或病区时:
                    if (cbReceiver.SelectedItem.ToString() == "科室" || cbReceiver.SelectedItem.ToString() == "病区")//科室或病区的重新处置
                    {

                        if (strSection_ids != "" && strSection_ids != strSECTION_ID)//说明当前科室或病区已经重新选择
                        {
                            strdelete_section_sql = "delete from  t_msg_user t  where t.id='" + str_id + "'";
                            sqls.Add(strdelete_section_sql);
                            string[] strSection_NAMES = strSection_ids.Split(',');
                            for (int i = 0; i < strSection_NAMES.Length; i++)
                            {
                                if (cbReceiver.SelectedItem.ToString() == "科室")
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
                            if (str_Content_id == "4" || str_Content_id == "5")//科室或病区没有发生变化
                            {
                                if (strIsreply != strIsSend)//但是是否需要收条发生了变化
                                {
                                    strUpdate_save_sql = "update t_msg_user t set t.isreply='" + strIsSend + "' where t.id='" + str_id + "'";
                                    sqls.Add(strUpdate_save_sql);
                                }
                            }
                        }
                    }
                    //当接收人为个人时：
                    if (cbReceiver.SelectedItem.ToString() == "个人")
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
                    //更新消息表
                    if (strSection_names != "")//重新选择科室或病区的判断
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
                    App.Msg("发布成功！");
                    this.Close();

                }
                else
                {
                    App.Msg("发布失败！");
                    return;
                }
            }
            catch { }

        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.setClear();
        }
        /// <summary>
        /// 当接收方式选择为科室时，触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSection_select_Click(object sender, EventArgs e)
        {
            if (strSection_ids != "" && strSection_names != "")//当科室和病区已经编辑完成后，还没有保存时，在打开编辑科室或病区窗体
            {
                if (cbReceiver.SelectedItem.ToString() == "科室")
                {
                    frmSectionCheck frm = new frmSectionCheck(2, strSection_ids, strSection_names);
                    frm.ShowDialog();
                    if (frm.flag)
                    {
                        strSection_ids = frmSectionCheck.YwcSectionID;

                        strSection_names = frmSectionCheck.YwcSectionName;
                    }
                }
                if (cbReceiver.SelectedItem.ToString() == "病区")
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
            if (cbReceiver.SelectedItem.ToString() == "科室")//修改消息所运行的逻辑（科室）
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
            if (cbReceiver.SelectedItem.ToString() == "病区")//修改消息所运行的逻辑（病区）
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
        /// 当接收人为个人时，可以删除已经选中的接收人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// 当接收人为个人时，可以清空已经选中的接收人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}