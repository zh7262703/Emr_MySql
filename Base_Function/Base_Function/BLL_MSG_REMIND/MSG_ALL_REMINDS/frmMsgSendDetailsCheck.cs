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
    public partial class frmMsgSendDetailsCheck : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 查看消息详细信息  袁杨2014-11-27开发
        /// </summary>
        public frmMsgSendDetailsCheck()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 接收传过来的消息主键id
        /// </summary>
        public string strMsg_id = "";
        /// <summary>
        /// 接收传过来的接收人id
        /// </summary>
        public string strUserID = "";
        public frmMsgSendDetailsCheck(string str_id,string strUser_id)
        {
            InitializeComponent();
            strMsg_id = str_id;
            strUserID = strUser_id;
        }
        private void frmMsgSendDetailsCheck_Load(object sender, EventArgs e)
        {
            lbTitle.Font = new Font("宋体", 20);
            this.getMsg();
        }
        private void getMsg()
        {
            try
            {
                string strSql = @"select t.id,
                                   t.pid,
                                   t.patient_name,
                                   p.user_name,
                                   t.operator_user_id,
                                   t.operator_user_name,
                                   t.type_id,
                                   t.type_name,
                                   t.type_name_cy,
                                   t.content_id,
                                   t.content,
                                   t.section_target,
                                   to_char(t.add_time, 'yyyy-MM-dd,hh24:mi') as add_time,
                                   t.msg_status,
                                   t.dispose_time,
                                   t.isreply,
                                   t.warn_type
                              from t_msg_info t,t_msg_user p  where t.id=p.id and t.warn_type='19' and t.id='" + strMsg_id + "'";
                DataSet ds = App.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count>0)
                {
                   // lbReceiver.Text = ds.Tables[0].Rows[0]["user_name"].ToString();
                    lbMsgType.Text = ds.Tables[0].Rows[0]["type_name_cy"].ToString();
                    if (ds.Tables[0].Rows[0]["isreply"].ToString()=="0")
                    {
                        lbShouTiao.Text = "否";
                    }
                    else
                    {
                        lbShouTiao.Text = "是";
                    }
                    lbTitle.Text = ds.Tables[0].Rows[0]["type_name"].ToString();
                    txtContent.Text = "    "+ds.Tables[0].Rows[0]["content"].ToString();
                    if (ds.Tables[0].Rows[0]["patient_name"].ToString() != "")
                    {
                        lbLk.Text = ds.Tables[0].Rows[0]["patient_name"].ToString();
                    }
                    else
                    {
                        lbLk.Text = ds.Tables[0].Rows[0]["operator_user_name"].ToString();
                    }
                    lblAddTime.Text = ds.Tables[0].Rows[0]["add_time"].ToString();
                    //当前section_target不为空时，接收人直接取section_target的值，当section_target为空时，取权限表t_msg_user中的user_name的值
                    if (ds.Tables[0].Rows[0]["section_target"].ToString() != "")
                    {
                        lbReceiver.Text = ds.Tables[0].Rows[0]["section_target"].ToString();
                    }
                    else
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (lbReceiver.Text == "")
                            {
                                lbReceiver.Text = ds.Tables[0].Rows[i]["user_name"].ToString();
                            }
                            else
                            {
                                lbReceiver.Text += "," + ds.Tables[0].Rows[i]["user_name"].ToString();
                            }
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