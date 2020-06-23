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
    /// 消息发布——浏览界面  袁杨开发141110
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
                            dgvMsg.Rows[i].Cells["Column7"].Value = "需要";
                        }
                        if (ds.Tables[0].Rows[i]["msg_status"].ToString() == "0")
                        {
                            dgvMsg.Rows[i].Cells["Column8"].Value = "未发";
                        }
                        else
                        {
                            dgvMsg.Rows[i].Cells["Column8"].Value = "已发";
                        }

                    }
                    dgvMsg.Columns["Column1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column4"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["column5"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column6"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column7"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvMsg.Columns["Column8"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //换行显示 已读界面的提醒内容
                    dgvMsg.Columns["Column3"].Width = 250;
                    dgvMsg.Columns[4].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                    dgvMsg.AutoResizeRows();
                    dgvMsg.Refresh();
                }
                //dgvMsg.AutoResizeColumns();//内容全部
            }
            catch
            {

            }
        }
        /// <summary>
        /// 查询收条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                #region 注释掉
                //ucMsgSendDetails frm = new ucMsgSendDetails();
                //frm.ShowDialog();
                //this.getMsg(); 
                #endregion
                string strId = dgvMsg.CurrentRow.Cells["Column9"].Value.ToString();//获取消息的主键id
                string strShouTiao = dgvMsg.CurrentRow.Cells["Column7"].Value.ToString();//获取消息是否需要收条
                string strSend_status = dgvMsg.CurrentRow.Cells["Column8"].Value.ToString();//获取消息的发布状态
                if (strId != "")
                {
                    if (strShouTiao != "NO")
                    {
                        if (strSend_status != "未发")
                        {
                            frmMsgSendCheckReceipt frm = new frmMsgSendCheckReceipt(strId);
                            frm.ShowDialog();
                        }
                        else
                        {
                            App.Msg("当前选中的消息还没有发布！");
                            return;
                        }
                    }
                    else
                    {
                        App.Msg("当前选中的消息不需要收条！");
                        return;
                    }
                }
                else
                {
                    App.Msg("请选择一条消息进行查看收条！");
                    return;
                }

            }
            catch
            {

            }
        }
        /// <summary>
        /// 发布
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                string strIds = "";//记录所有未发送消息的id集合
                string strLogin_name = App.UserAccount.UserInfo.User_name.ToString();//获取当前登录人姓名
                string strLogin_Id = App.UserAccount.UserInfo.User_id.ToString(); //获取当前登录人id

                if (dgvMsg.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvMsg.SelectedRows.Count; i++)
                    {
                        if (dgvMsg.SelectedRows[i].Cells["Column8"].Value.ToString() == "未发")
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
                        App.Msg("当前的消息已经全部发送！");
                        return;
                    }
                    else
                    {
                        string strDateTime_Now = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                        string strUpdate_sql = "update t_msg_info t set t.operator_user_id='" + strLogin_Id + "',t.operator_user_name='" + strLogin_name + "', t.msg_status='1',t.add_time=to_date('" + strDateTime_Now + "','yyyy-MM-dd hh24:mi') where t.id in (" + strIds + ") ";
                        int n = App.ExecuteSQL(strUpdate_sql);
                        if (n > 0)
                        {
                            App.Msg("消息发布成功！");
                            this.getMsg();
                            return;
                        }
                        else
                        {
                            App.Msg("消息发布失败！");
                            return;
                        }
                    }
                }
                else
                {
                    App.Msg("当前不存在没有发布的消息！");
                    return;
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string strId = dgvMsg.CurrentRow.Cells["Column9"].Value.ToString();
            if (strId == "")
            {
                App.Msg("请先选择一条未发布的消息进行修改！");
                return;
            }
            string strMsg_status = dgvMsg.CurrentRow.Cells["Column8"].Value.ToString();
            if (strMsg_status != "未发")
            {
                App.Msg("当前消息已发布,无法进行修改！");
                return;
            }
            //判断当前消息是否属于当前登录人编辑的
            string strLogin_id = "";
            string strsql_operator_user_id = "select t.operator_user_id from t_msg_info t where t.id='" + strId + "'";
            DataSet dst = App.GetDataSet(strsql_operator_user_id);
            if (dst.Tables[0].Rows.Count > 0)
            {
                strLogin_id = dst.Tables[0].Rows[0]["operator_user_id"].ToString();
            }
            //判断当前用户角色是否是主任级别
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
                        if (ds.Tables[0].Rows[i]["role_name"].ToString() == "质控办主任" || ds.Tables[0].Rows[i]["role_name"].ToString() == "信息科主任" || ds.Tables[0].Rows[i]["role_name"].ToString() == "病案室主任" || ds.Tables[0].Rows[i]["role_name"].ToString() == "医务科主任" || ds.Tables[0].Rows[i]["role_name"].ToString() == "护理部主任")
                        {
                            strRole_name = ds.Tables[0].Rows[i]["role_name"].ToString();
                            break;
                        }
                    }
                }
                if (strRole_name == "质控办主任" || strRole_name == "信息科主任" || strRole_name == "病案室主任" || strRole_name == "医务科主任" || strRole_name == "护理部主任" || App.UserAccount.UserInfo.User_id.ToString() == strLogin_id)
                {
                    string strContent_id = "";//接收方式
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
                        frmMsgSendDetailsUpdate frm = new frmMsgSendDetailsUpdate(strId, strContent_id);//传递消息的主键和接收方式
                        frm.ShowDialog();
                        this.getMsg();
                    }
                }
                else
                {
                    App.Msg("您即不拥有主任级别权限，当前消息也不属于您所编辑，所以您无法修改此条消息！");
                    return;
                }
            }
        }
        /// <summary>
        /// 删除
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
                                if (ds.Tables[0].Rows[i]["role_name"].ToString() == "质控办主任" || ds.Tables[0].Rows[i]["role_name"].ToString() == "信息科主任" || ds.Tables[0].Rows[i]["role_name"].ToString() == "病案室主任" || ds.Tables[0].Rows[i]["role_name"].ToString() == "医务科主任" || ds.Tables[0].Rows[i]["role_name"].ToString() == "护理部主任")
                                {
                                    strRole_name = ds.Tables[0].Rows[i]["role_name"].ToString();
                                    break;
                                }
                            }
                        }
                        if (strRole_name == "质控办主任" || strRole_name == "信息科主任" || strRole_name == "病案室主任" || strRole_name == "医务科主任" || strRole_name == "护理部主任")
                        {
                            foreach (DataGridViewRow dr in dgvMsg.SelectedRows)
                            {

                                string strId = dr.Cells[0].Value.ToString();//取到主键id
                                string strMsg_status = dr.Cells[8].Value.ToString();//取到发送状态
                                if (strId != "" && strMsg_status == "未发")
                                {
                                    string strDeleteSql = "delete from t_msg_info t where t.id='" + strId + "'";
                                    Sqls.Add(strDeleteSql);
                                    //string strDelete_section_sql = "delete from t_msg_section t where t.id='" + strId + "'";
                                    //Sqls.Add(strDelete_section_sql);
                                }
                                else
                                {
                                    App.Msg("当前选中要删除的消息存在已发布状态,无法删除！");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            foreach (DataGridViewRow dr in dgvMsg.SelectedRows)
                            {

                                string strId = dr.Cells[0].Value.ToString();//取到主键id
                                string strMsg_status = dr.Cells[8].Value.ToString();//取到发送状态
                                if (strId != "" && strMsg_status == "未发")
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
                                        App.Msg("由于您当前的删除权限不属于主任级别，所以您只能删除您自己所编辑的消息！");
                                        return;
                                    }

                                }
                                else
                                {
                                    App.Msg("当前选中要删除的消息存在已发布状态,无法删除！");
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
                            App.Msg("删除成功！");
                            this.getMsg();
                            return;
                        }
                        else
                        {
                            App.Msg("删除失败！");
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