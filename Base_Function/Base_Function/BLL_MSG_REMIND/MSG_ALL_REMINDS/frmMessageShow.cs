using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevComponents.AdvTree;
using System.Collections;
using Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class frmMessageShow : DevComponents.DotNetBar.Office2007Form
    {
        //消息提醒主界面 袁杨开发 
        public frmMessageShow()
        {
            InitializeComponent();
        }

        private void frmMessageShow2_Load(object sender, EventArgs e)
        {
            try
            {
                this.getCount_unRead();
            }
            catch
            {

            }
        }
        private void getCount_unRead()
        {
            string strSql_One = @"select distinct(m.id),
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m, t_in_patient p, t_msg_setting t
                             where m.pid = p.id
                               and t.WARN_TYPE = m.WARN_TYPE
                               and t.MSG_START_UP = '1'
                               and t.MSG_VOLUNTARILY_POP = '1'
                               and m.msg_status = '0'
                               and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0 and m.receive_user_id='" + App.UserAccount.UserInfo.User_id + "'";
            //消息发布提醒中接收人为——全院：
            string strSend_sql0ne = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.id=p.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure is null
                               and m.content_id='1'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";
            //消息发布提醒中接收人为——全院医生或全院护士：
            string strSend_sqlTwo = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                                   and m.id=p.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure is null
                               and m.content_id in ('D','N')
                               and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";
            //消息发布提醒中接收人为——科室：
            string strSend_sqlThree = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.id=p.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure is null
                               and m.content_id='4'
                                and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";
            //消息发布提醒中接收人为——病区：
            string strSend_sqlFour = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                                and m.id=p.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure is null
                               and m.content_id='5'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";
            //消息发布提醒中接收人为——个人：
            string strSend_sqlFive = @"
                                    select m.id,
                                   m.isreply,
                                   m.type_name,
                                   m.content,
                                   m.operator_user_name,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi'),
                                   m.warn_type
                              from T_MSG_INFO m,t_msg_setting t,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.id=p.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure is null
                               and m.content_id='6'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";
            string strSql = strSql_One + " union " + strSend_sql0ne + " union " + strSend_sqlTwo + " union " + strSend_sqlThree + " union " + strSend_sqlFour + " union " + strSend_sqlFive;
            DataSet ds = App.GetDataSet(strSql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strAll_unReadNews = Convert.ToString(ds.Tables[0].Rows.Count);//所有未读信息
                int strZDTX = 0;//主动提醒1,2
                int strZKTX = 0;//质控提醒3,4
                int strJYTX = 0;//检验提醒5,6,7
                int strPACSJCTX = 0;//检查提醒8,9  
                int strZTTX = 0;//状态提醒10
                int strTZTX = 0;//体征提醒11,12,13,14,15
                int strYZTX = 0;//医嘱提醒16
                int strPFTX = 0;//评分提醒17
                int strQTTX = 0;//其他提醒18
                int strXXFBTX = 0;//消息发布提醒19
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "1" || ds.Tables[0].Rows[i]["warn_type"].ToString() == "2")
                    {
                        strZDTX = strZDTX + 1;
                    }
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "3" || ds.Tables[0].Rows[i]["warn_type"].ToString() == "4")
                    {
                        strZKTX = strZKTX + 1;
                    }
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "5" || ds.Tables[0].Rows[i]["warn_type"].ToString() == "6" || ds.Tables[0].Rows[i]["warn_type"].ToString() == "7")
                    {
                        strJYTX = strJYTX + 1;
                    }
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "8" || ds.Tables[0].Rows[i]["warn_type"].ToString() == "9")
                    {
                        strPACSJCTX = strPACSJCTX + 1;
                    }
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "10")
                    {
                        strZTTX = strZTTX + 1;
                    }
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "11" || ds.Tables[0].Rows[i]["warn_type"].ToString() == "12" || ds.Tables[0].Rows[i]["warn_type"].ToString() == "13" || ds.Tables[0].Rows[i]["warn_type"].ToString() == "14" || ds.Tables[0].Rows[i]["warn_type"].ToString() == "15")
                    {
                        strTZTX = strTZTX + 1;
                    }
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "16")
                    {
                        strYZTX = strYZTX + 1;
                    }
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "17")
                    {
                        strPFTX = strPFTX + 1;
                    }
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "18")
                    {
                        strQTTX = strQTTX + 1;
                    }
                    if (ds.Tables[0].Rows[i]["warn_type"].ToString() == "19")
                    {
                        strXXFBTX = strXXFBTX + 1;
                    }

                }
                tabAllNewsNotice.Text = "全部提醒 (" + strAll_unReadNews + ")";// 全部提醒
                tabQualityControlNotice.Text = "质控提醒 (" + Convert.ToString(strZKTX) + ")";//  质控提醒
                tabTestNews.Text = "检验提醒 (" + Convert.ToString(strJYTX) + ")";// 检验提醒
                tabPacsNews.Text = "pacs检查提醒 (" + Convert.ToString(strPACSJCTX) + ")";//  pacs检查提醒
                tabStateNews.Text = "状态提醒 (" + Convert.ToString(strZTTX) + ")";//  状态提醒
                tabBodyStateNews.Text = "体征提醒 (" + Convert.ToString(strTZTX) + ")";//  体征提醒
                tabDoctorIdeaNews.Text = "医嘱提醒 (" + Convert.ToString(strYZTX) + ")";//  医嘱提醒
                tabOtherNews.Text = "其他提醒 (" + Convert.ToString(strQTTX) + ")";//  其他提醒
                tabcinitiativeNews.Text = "主动提醒 (" + Convert.ToString(strZDTX) + ")";//  主动提醒
                tabBAPointsNews.Text = "病案评分提醒 (" + Convert.ToString(strPFTX) + ")";//  病案评分提醒
                tabNewSend.Text = "消息发布提醒 (" + Convert.ToString(strXXFBTX) + ")";//   消息发布提醒
            }
        }
    }

}