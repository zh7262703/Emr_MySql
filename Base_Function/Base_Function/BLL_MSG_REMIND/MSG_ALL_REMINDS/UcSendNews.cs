using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using DevComponents.AdvTree;
using System.Collections;
using Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class UcSendNews : UserControl
    {
        public UcSendNews()
        {
            InitializeComponent();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string strDateTime = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                List<string> sqls = new List<string>();
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                    {
                        if (dgvMsgInfoNew.Rows[i].Cells["Column1"].EditedFormattedValue.ToString() == "True")
                        {
                            if (dgvMsgInfoNew.Rows[i].Cells["Column7"].EditedFormattedValue.ToString() == "需要")
                            {
                              //string strUpdate_sql = "update t_msg_info t set t.flag='true',t.dispose_time=to_date('" + strDateTime + "','yyyy-MM-dd hh24:mi') where  t.id='" + dgvMsgInfoNew.Rows[i].Cells["Column8"].Value.ToString() + "'";
                                string strUpdate_sql = "update (select t2.make_sure,t2.dispose_time,t2.isreply from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + dgvMsgInfoNew.Rows[i].Cells["Column8"].Value.ToString() + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.make_sure='true',t.dispose_time=to_date('" + strDateTime + "','yyyy-MM-dd hh24:mi'),t.isreply='2'";
                                sqls.Add(strUpdate_sql);
                            }
                            else
                            {
                                App.Msg("当前选中的消息中含有不需要收条的消息！");
                                return;
                            }
                        }
                    }
                    if (sqls.Count > 0)
                    {
                        int n = App.ExecuteBatch(sqls.ToArray());
                        if (n > 0)
                        {
                            App.Msg("确认并发送收条成功！");
                            this.GetMessage();
                        }
                        else
                        {
                            App.Msg("确认并发送收条失败！");
                        }
                    }
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

        private void btnMakeSure_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                string strDateTime = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                List<string> sqls = new List<string>();
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                    {
                        if (dgvMsgInfoNew.Rows[i].Cells["Column1"].EditedFormattedValue.ToString() == "True")
                        {
                            if (dgvMsgInfoNew.Rows[i].Cells["Column7"].EditedFormattedValue.ToString() == "NO")
                            {
                              //string strUpdate_sql = "update t_msg_info t set t.flag='true',t.dispose_time=to_date('" + strDateTime + "','yyyy-MM-dd hh24:mi') where  t.id='" + dgvMsgInfoNew.Rows[i].Cells["Column8"].Value.ToString() + "'";
                                string strUpdate_sql = "update (select t2.make_sure,t2.dispose_time from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + dgvMsgInfoNew.Rows[i].Cells["Column8"].Value.ToString() + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.make_sure='true',t.dispose_time=to_date('" + strDateTime + "','yyyy-MM-dd hh24:mi')";
                                sqls.Add(strUpdate_sql);
                            }
                            else
                            {
                                App.Msg("当前选中的消息中含有需要收条的消息！");
                                return;
                            }
                        }
                    }
                    if (sqls.Count > 0)
                    {
                        int n = App.ExecuteBatch(sqls.ToArray());
                        if (n > 0)
                        {
                            App.Msg("确认成功！");
                            this.GetMessage();
                        }
                        else
                        {
                            App.Msg("确认失败！");
                        }
                    }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
        }
        private void GetMessage()
        {
            dgvMsgInfoNew.Rows.Clear();
            dgvHistoryMsgNew.Rows.Clear();
            //新消息
            //消息发布提醒中接收人为——全院：
            string sqlMsg_One = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                               case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name  ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply
                          from t_msg_info t,t_msg_user p where 
                                t.msg_status='1' 
                                and t.id=p.id
                                and p.make_sure is null
                                and t.content_id='1'
                                and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            ////消息发布提醒中接收人为——全院医生或护士：
            string sqlMsg_Two = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                               case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply
                          from t_msg_info t,t_msg_user p where  t.id=p.id and t.msg_status='1' 
                                and p.make_sure is null
                                and p.role_type in ('D','N')
                                and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            ////消息发布提醒中接收人为——科室：
            string sqlMsg_Three = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                               case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply
                          from t_msg_info t,t_msg_user p  where t.id=p.id and t.msg_status='1' 
                                and p.make_sure is null
                                and t.content_id='4'
                                and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            //消息发布提醒中接收人为——病区：
            string sqlMsg_Four = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                              case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply
                          from t_msg_info t,t_msg_user p  where t.id=p.id and t.msg_status='1' 
                                and p.make_sure is null
                                and t.content_id='5'
                                and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            //消息发布提醒中接收人为——个人：
            string sqlMsg_Five = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                               case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply
                          from t_msg_info t,t_msg_user p  where t.id=p.id and t.msg_status='1' 
                                and p.make_sure is null
                                and t.content_id='6'
                                and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            string sqlMsg ="select m.id,m.type_name_cy,m.type_name, m.content,m.operator_user_name,m.add_time,m.isreply  from ("+(sqlMsg_One + " union " + sqlMsg_Two + " union " + sqlMsg_Three + " union " + sqlMsg_Four + " union " + sqlMsg_Five)+" ) m order by m.add_time desc";
            DataSet ds = App.GetDataSet(sqlMsg);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgvMsgInfoNew.Rows.Add();
                    dgvMsgInfoNew.Rows[i].Cells["Column8"].Value = ds.Tables[0].Rows[i]["id"].ToString();
                    dgvMsgInfoNew.Rows[i].Cells["Column2"].Value = ds.Tables[0].Rows[i]["type_name_cy"].ToString();
                    dgvMsgInfoNew.Rows[i].Cells["Column3"].Value = ds.Tables[0].Rows[i]["type_name"].ToString();
                    dgvMsgInfoNew.Rows[i].Cells["Column4"].Value = ds.Tables[0].Rows[i]["content"].ToString();
                    dgvMsgInfoNew.Rows[i].Cells["Column5"].Value = ds.Tables[0].Rows[i]["operator_user_name"].ToString();
                    dgvMsgInfoNew.Rows[i].Cells["Column6"].Value = ds.Tables[0].Rows[i]["add_time"].ToString();
                    if (ds.Tables[0].Rows[i]["isreply"].ToString() == "0")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["Column7"].Value = "NO";
                    }
                    else
                    {
                        dgvMsgInfoNew.Rows[i].Cells["Column7"].Value = "需要";
                    }

                }
                dgvMsgInfoNew.Columns["Column1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["Column2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["Column3"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
              //dgvMsgInfoNew.Columns["Column4"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["Column5"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["Column6"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["Column7"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvMsgInfoNew.Columns["Column4"].Width = 250;
                dgvMsgInfoNew.Columns[4].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();
            }
            int n_newMsg = ds.Tables[0].Rows.Count;
            if (n_newMsg >= 0)
            {
                tabItem1.Text = "消息发布未读界面" + "(" + n_newMsg + ")";
            }


            //查询已读消息
            //消息发布提醒中接收人为——全院：
            string sqlHistoryMsg_One = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                               case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply,
                               to_char(p.dispose_time, 'yyyy-MM-dd,hh24:mi') as dispose_time
                          from t_msg_info t,t_msg_user p  where t.id=p.id and t.msg_status='1' 
                                and p.make_sure='true'
                                and t.content_id='1'
                                and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
                                
            ////消息发布提醒中接收人为——全院医生或护士：
            string sqlHistoryMsg_Two = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                               case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply,
                               to_char(p.dispose_time, 'yyyy-MM-dd,hh24:mi') as dispose_time
                          from t_msg_info t,t_msg_user p  where  t.id=p.id and t.msg_status='1' 
                               and p.make_sure='true'
                               and p.role_type in ('D','N')
                                and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            ////消息发布提醒中接收人为——科室：
            string sqlHistoryMsg_Three = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                               case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply,
                               to_char(p.dispose_time, 'yyyy-MM-dd,hh24:mi') as dispose_time
                          from t_msg_info t,t_msg_user p  where t.id=p.id and t.msg_status='1' 
                                 and p.make_sure='true'
                                and t.content_id='4'
                                 and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            //消息发布提醒中接收人为——病区：
            string sqlHistoryMsg_Four = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                               case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply,
                               to_char(p.dispose_time, 'yyyy-MM-dd,hh24:mi') as dispose_time
                          from t_msg_info t ,t_msg_user p where  t.id=p.id and t.msg_status='1' 
                                and p.make_sure='true'
                                and t.content_id='5'
                                 and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            //消息发布提醒中接收人为——个人：
            string sqlHistoryMsg_Five = @"select t.id,
                               t.type_name_cy,
                               t.type_name,
                               t.content,
                               case t.type_id when 1 then t.patient_name else t.operator_user_name  end  operator_user_name ,
                               to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                               p.isreply,
                               to_char(p.dispose_time, 'yyyy-MM-dd,hh24:mi') as dispose_time
                          from t_msg_info t,t_msg_user p  where t.id=p.id and t.msg_status='1' 
                                and p.make_sure='true'
                                and t.content_id='6'
                                and p.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "'";
            string sqlHistoryMsg = "select m.id,m.type_name_cy,m.type_name, m.content,m.operator_user_name,m.add_time,m.isreply ,m.dispose_time from ("+(sqlHistoryMsg_One + " union " + sqlHistoryMsg_Two + " union " + sqlHistoryMsg_Three + " union " + sqlHistoryMsg_Four + " union " + sqlHistoryMsg_Five)+" ) m order by m.dispose_time desc";
            DataSet dst = App.GetDataSet(sqlHistoryMsg);
            if (dst.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                {
                    dgvHistoryMsgNew.Rows.Add();
                    dgvHistoryMsgNew.Rows[i].Cells["Column9"].Value = dst.Tables[0].Rows[i]["id"].ToString();
                    dgvHistoryMsgNew.Rows[i].Cells["Column10"].Value = dst.Tables[0].Rows[i]["type_name_cy"].ToString();
                    dgvHistoryMsgNew.Rows[i].Cells["Column11"].Value = dst.Tables[0].Rows[i]["type_name"].ToString();
                    dgvHistoryMsgNew.Rows[i].Cells["Column12"].Value = dst.Tables[0].Rows[i]["content"].ToString();
                    dgvHistoryMsgNew.Rows[i].Cells["Column13"].Value = dst.Tables[0].Rows[i]["operator_user_name"].ToString();
                    dgvHistoryMsgNew.Rows[i].Cells["Column15"].Value = dst.Tables[0].Rows[i]["dispose_time"].ToString();
                    if (dst.Tables[0].Rows[i]["isreply"].ToString() == "0")
                    {
                        dgvHistoryMsgNew.Rows[i].Cells["column14"].Value = "NO";
                    }
                    else
                    {
                        dgvHistoryMsgNew.Rows[i].Cells["column14"].Value = "需要";
                    }

                }
                dgvHistoryMsgNew.Columns["Column10"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["Column11"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["Column13"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["column14"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvHistoryMsgNew.Columns["Column15"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 已读界面的提醒内容
                dgvHistoryMsgNew.Columns["Column12"].Width = 250;
                dgvHistoryMsgNew.Columns[3].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgNew.AutoResizeRows();
                dgvHistoryMsgNew.Refresh();

            }

        }

        private void UcSendNews_Load(object sender, EventArgs e)
        {
            try
            {
                // 设定包括Header和所有单元格的列宽自动调整 
                //dgvMsgInfoNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvHistoryMsgNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                GetMessage();
            }
            catch
            {
            }
        }

        private void UcSendNews_SizeChanged(object sender, EventArgs e)
        {
            int x = btnReply.Parent.Size.Width / 2 - btnReply.Size.Width;
            btnReply.Location = new Point(x, btnReply.Location.Y);
            btnRefurbish.Location = new Point(btnReply.Location.X + 100, btnRefurbish.Location.Y);
            btnMakeSure.Location = new Point(btnReply.Location.X - 100, btnMakeSure.Location.Y);
        }

        private void btnMakeSure_Click_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefurbish_Click(object sender, EventArgs e)
        {
            try
            {
                GetMessage();
            }
            catch
            {

            }
        }

        private void dgvMsgInfoNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }
       
        private void dgvHistoryMsgNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        /// <summary>
        /// 双击查看消息详细信息 未读界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMsgInfoNew_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    string strId = dgvMsgInfoNew.CurrentRow.Cells["Column8"].Value.ToString();
                    string strUser_id = App.UserAccount.UserInfo.User_id.ToString();
                    if (strId != "" && strUser_id != "")
                    {
                        frmMsgSendDetailsCheck frm = new frmMsgSendDetailsCheck(strId, strUser_id);
                        frm.ShowDialog();
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 双击查看消息详细信息 已读界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvHistoryMsgNew_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvHistoryMsgNew.Rows.Count > 0)
                {
                    string strId = dgvHistoryMsgNew.CurrentRow.Cells["Column9"].Value.ToString();
                    string strUser_id = App.UserAccount.UserInfo.User_id.ToString();
                    if (strId != "" && strUser_id != "")
                    {
                        frmMsgSendDetailsCheck frm = new frmMsgSendDetailsCheck(strId, strUser_id);
                        frm.ShowDialog();
                    }
                }
            }
            catch
            {

            }
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            dgvMsgInfoNew.AutoResizeRows();
            dgvMsgInfoNew.Refresh();
            dgvHistoryMsgNew.AutoResizeRows();
            dgvHistoryMsgNew.Refresh();
        }
    }
}
