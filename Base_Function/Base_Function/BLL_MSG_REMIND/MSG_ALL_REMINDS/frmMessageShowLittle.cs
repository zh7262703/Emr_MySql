using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using C1.Win.C1FlexGrid;
using Bifrost.HisInStance;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class frmMessageShowLittle : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 当前登陆人id
        /// </summary>
        string strID = "";
        /// <summary>
        /// 判断大窗体是否打开
        /// </summary>
        string strISWINDOWPOP = "";
        public frmMessageShowLittle()
        {
            InitializeComponent();
        }
        public frmMessageShowLittle(string strid)
        {
            InitializeComponent();
            strID = strid;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMessageShowLittle_Load(object sender, EventArgs e)
        {
            Screen screen = Screen.AllScreens[0];
            this.DesktopLocation = new Point(screen.Bounds.Width - (this.Width + 5), screen.Bounds.Height - this.Height + 33);
            this.TopMost = true;
            txtBoxShow.Font =new Font("宋体",10);
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
                               and m.read_flag is null
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
                               and p.read_flag is null
                               and p.make_sure  is null
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
                               and p.read_flag is null
                               and p.make_sure  is null
                               and p.role_type in ('D','N')
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
                               and p.read_flag is null
                               and p.make_sure  is null
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
                               and p.read_flag is null
                               and p.make_sure  is null
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
                              from T_MSG_INFO m,t_msg_setting t ,t_msg_user p
                             where t.WARN_TYPE = m.WARN_TYPE
                               and m.id=p.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.read_flag is null
                               and p.make_sure  is null
                               and m.content_id='6'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";
          // string strSql = strSql_One + " union " + strSend_sql0ne + " union " + strSend_sqlTwo + " union " + strSend_sqlThree + " union " + strSend_sqlFour + " union " + strSend_sqlFive;
           string strSql1 = " and m.warn_type=3 ";
           string strSqlTotal1 = strSql_One + strSql1 + " union " + strSend_sql0ne + strSql1 + " union " + strSend_sqlTwo + strSql1 + " union " + strSend_sqlThree + strSql1 + " union " + strSend_sqlFour + strSql1 + " union " + strSend_sqlFive + strSql1;
           if (strSqlTotal1.Length > 0)
            {
                DataSet ds1 = App.GetDataSet(strSqlTotal1);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    int n1 = ds1.Tables[0].Rows.Count;
                    if (n1 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新质控消息(红灯预警)" + Convert.ToString(n1) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新质控消息(红灯预警)" + Convert.ToString(n1) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr1 in ds1.Tables[0].Rows)
                        {
                            DataRow[] drs1 = ds1.Tables[0].Select("id='" + dr1["id"].ToString() + "'");
                            if (drs1.Length > 0)
                            {
                                string strSqlUpdate1 = "update t_msg_info t set t.read_flag='true' where t.warn_type=3 and t.id='" + drs1[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate1);
                            }
                        }
                    }
                }
            }
            string strSql1_2 = " and m.warn_type=4 ";
            string strSqlTotal1_2 = strSql_One + strSql1_2 + " union " + strSend_sql0ne + strSql1_2 + " union " + strSend_sqlTwo + strSql1_2 + " union " + strSend_sqlThree + strSql1_2 + " union " + strSend_sqlFour + strSql1_2 + " union " + strSend_sqlFive + strSql1_2; 
            if (strSqlTotal1_2.Length > 0)
            {
                DataSet ds1_2 = App.GetDataSet(strSqlTotal1_2);
                if (ds1_2.Tables[0].Rows.Count > 0)
                {
                    int n1_2 = ds1_2.Tables[0].Rows.Count;
                    if (n1_2 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新质控消息(黄灯预警)" + Convert.ToString(n1_2) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新质控消息(黄灯预警)" + Convert.ToString(n1_2) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr1_2 in ds1_2.Tables[0].Rows)
                        {
                            DataRow[] drs1_2 = ds1_2.Tables[0].Select("id='" + dr1_2["id"].ToString() + "'");
                            if (drs1_2.Length > 0)
                            {
                                string strSqlUpdate1_2 = "update t_msg_info t set t.read_flag='true' where t.warn_type=4 and t.id='" + drs1_2[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate1_2);
                            }
                        }
                    }
                }
            }
            string strSql2 = " and m.warn_type=5";
            string strSqlTotal2 = strSql_One + strSql2 + " union " + strSend_sql0ne + strSql2 + " union " + strSend_sqlTwo + strSql2 + " union " + strSend_sqlThree + strSql2 + " union " + strSend_sqlFour + strSql2 + " union " + strSend_sqlFive + strSql2; 
            if (strSqlTotal2.Length > 0)
            {
                DataSet ds2 = App.GetDataSet(strSqlTotal2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    int n2 = ds2.Tables[0].Rows.Count;
                    if (n2 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新检验消息(检验报告)" + Convert.ToString(n2) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新检验消息（检验报告）" + Convert.ToString(n2) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr2 in ds2.Tables[0].Rows)
                        {
                            DataRow[] drs2 = ds2.Tables[0].Select("id='" + dr2["id"].ToString() + "'");
                            if (drs2.Length > 0)
                            {
                                string strSqlUpdate2 = "update t_msg_info t set t.read_flag='true' where t.warn_type=5 and t.id='" + drs2[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate2);
                            }
                        }
                    }

                }
            }
            string strSql2_2 = " and m.warn_type=6";
            string strSqlTotal2_2 = strSql_One + strSql2_2 + " union " + strSend_sql0ne + strSql2_2 + " union " + strSend_sqlTwo + strSql2_2 + " union " + strSend_sqlThree + strSql2_2 + " union " + strSend_sqlFour + strSql2_2 + " union " + strSend_sqlFive + strSql2_2; 
            if (strSqlTotal2_2.Length > 0)
            {
                DataSet ds2_2 = App.GetDataSet(strSqlTotal2_2);
                if (ds2_2.Tables[0].Rows.Count > 0)
                {
                    int n2_2 = ds2_2.Tables[0].Rows.Count;
                    if (n2_2 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新检验消息(非正常值)" + Convert.ToString(n2_2) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新检验消息（非正常值）" + Convert.ToString(n2_2) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr2_2 in ds2_2.Tables[0].Rows)
                        {
                            DataRow[] drs2_2 = ds2_2.Tables[0].Select("id='" + dr2_2["id"].ToString() + "'");
                            if (drs2_2.Length > 0)
                            {
                                string strSqlUpdate2_2 = "update t_msg_info t set t.read_flag='true' where t.warn_type=6 and t.id='" + drs2_2[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate2_2);
                            }
                        }
                    }

                }
            }
            string strSql2_3 = " and m.warn_type=7";
            string strSqlTotal2_3 = strSql_One + strSql2_3 + " union " + strSend_sql0ne + strSql2_3 + " union " + strSend_sqlTwo + strSql2_3 + " union " + strSend_sqlThree + strSql2_3 + " union " + strSend_sqlFour + strSql2_3 + " union " + strSend_sqlFive + strSql2_3; 
            if (strSqlTotal2_3.Length > 0)
            {
                DataSet ds2_3 = App.GetDataSet(strSqlTotal2_3);
                if (ds2_3.Tables[0].Rows.Count > 0)
                {
                    int n2_3 = ds2_3.Tables[0].Rows.Count;
                    if (n2_3 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新检验消息(危机值)" + Convert.ToString(n2_3) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新检验消息（危机值）" + Convert.ToString(n2_3) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr2_3 in ds2_3.Tables[0].Rows)
                        {
                            DataRow[] drs2_3 = ds2_3.Tables[0].Select("id='" + dr2_3["id"].ToString() + "'");
                            if (drs2_3.Length > 0)
                            {
                                string strSqlUpdate2_3 = "update t_msg_info t set t.read_flag='true' where t.warn_type=7 and t.id='" + drs2_3[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate2_3);
                            }
                        }
                    }

                }
            }
            string strSql3 = " and m.warn_type=8";
            string strSqlTotal3 = strSql_One + strSql3 + " union " + strSend_sql0ne + strSql3 + " union " + strSend_sqlTwo + strSql3 + " union " + strSend_sqlThree + strSql3 + " union " + strSend_sqlFour + strSql3 + " union " + strSend_sqlFive + strSql3; 
            if (strSqlTotal3.Length > 0)
            {
                DataSet ds3 = App.GetDataSet(strSqlTotal3);
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    int n3 = ds3.Tables[0].Rows.Count;
                    if (n3 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新Pacs消息(检查报告)" + Convert.ToString(n3) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新Pacs消息(检查报告)" + Convert.ToString(n3) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr3 in ds3.Tables[0].Rows)
                        {
                            DataRow[] drs3 = ds3.Tables[0].Select("id='" + dr3["id"].ToString() + "'");
                            if (drs3.Length > 0)
                            {
                                string strSqlUpdate3 = "update t_msg_info t set t.read_flag='true' where t.warn_type=8 and t.id='" + drs3[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate3);
                            }
                        }
                    }
                }
            }
            string strSql3_2 = " and m.warn_type=9";
            string strSqlTotal3_2 = strSql_One + strSql3_2 + " union " + strSend_sql0ne + strSql3_2 + " union " + strSend_sqlTwo + strSql3_2 + " union " + strSend_sqlThree + strSql3_2 + " union " + strSend_sqlFour + strSql3_2 + " union " + strSend_sqlFive + strSql3_2; 
            if (strSqlTotal3_2.Length > 0)
            {
                DataSet ds3_2 = App.GetDataSet(strSqlTotal3_2);
                if (ds3_2.Tables[0].Rows.Count > 0)
                {
                    int n3_2 = ds3_2.Tables[0].Rows.Count;
                    if (n3_2 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新Pacs消息(检查表现及意见)" + Convert.ToString(n3_2) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新Pacs消息(检查表现及意见)" + Convert.ToString(n3_2) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr3_2 in ds3_2.Tables[0].Rows)
                        {
                            DataRow[] drs3_2 = ds3_2.Tables[0].Select("id='" + dr3_2["id"].ToString() + "'");
                            if (drs3_2.Length > 0)
                            {
                                string strSqlUpdate3_2 = "update t_msg_info t set t.read_flag='true' where t.warn_type=9 and t.id='" + drs3_2[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate3_2);
                            }
                        }
                    }
                }
            }
            string strSql4 = " and m.warn_type=10";
            string strSqlTotal4 = strSql_One + strSql4 + " union " + strSend_sql0ne + strSql4 + " union " + strSend_sqlTwo + strSql4 + " union " + strSend_sqlThree + strSql4 + " union " + strSend_sqlFour + strSql4 + " union " + strSend_sqlFive + strSql4; 
            if (strSqlTotal4.Length > 0)
            {
                DataSet ds4 = App.GetDataSet(strSqlTotal4);
                if (ds4.Tables[0].Rows.Count > 0)
                {
                    int n4 = ds4.Tables[0].Rows.Count;
                    if (n4 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新状态消息" + Convert.ToString(n4) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新状态消息" + Convert.ToString(n4) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr4 in ds4.Tables[0].Rows)
                        {
                            DataRow[] drs4 = ds4.Tables[0].Select("id='" + dr4["id"].ToString() + "'");
                            if (drs4.Length > 0)
                            {
                                string strSqlUpdate4 = "update t_msg_info t set t.read_flag='true' where t.warn_type=10 and t.id='" + drs4[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate4);
                            }
                        }
                    }
                }
            }
            string strSql5 = " and m.warn_type=11";
            string strSqlTotal5 = strSql_One + strSql5 + " union " + strSend_sql0ne + strSql5 + " union " + strSend_sqlTwo + strSql5 + " union " + strSend_sqlThree + strSql5 + " union " + strSend_sqlFour + strSql5 + " union " + strSend_sqlFive + strSql5; 
            if (strSqlTotal5.Length > 0)
            {
                DataSet ds5 = App.GetDataSet(strSqlTotal5);
                if (ds5.Tables[0].Rows.Count > 0)
                {
                    int n5 = ds5.Tables[0].Rows.Count;
                    if (n5 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新体征消息(体征内容)" + Convert.ToString(n5) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新体征消息(体征内容)" + Convert.ToString(n5) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr5 in ds5.Tables[0].Rows)
                        {
                            DataRow[] drs5 = ds5.Tables[0].Select("id='" + dr5["id"].ToString() + "'");
                            if (drs5.Length > 0)
                            {
                                string strSqlUpdate5 = "update t_msg_info t set t.read_flag='true' where t.warn_type=11 and t.id='" + drs5[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate5);
                            }
                        }
                    }
                }
            }
            string strSql5_2 = " and m.warn_type=12";
            string strSqlTotal5_2 = strSql_One + strSql5_2 + " union " + strSend_sql0ne + strSql5_2 + " union " + strSend_sqlTwo + strSql5_2 + " union " + strSend_sqlThree + strSql5_2 + " union " + strSend_sqlFour + strSql5_2 + " union " + strSend_sqlFive + strSql5_2; 
            if (strSqlTotal5_2.Length > 0)
            {
                DataSet ds5_2 = App.GetDataSet(strSqlTotal5_2);
                if (ds5_2.Tables[0].Rows.Count > 0)
                {
                    int n5_2 = ds5_2.Tables[0].Rows.Count;
                    if (n5_2 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新体征消息(非正常值-体温)" + Convert.ToString(n5_2) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新体征消息(非正常值-体温)" + Convert.ToString(n5_2) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr5_2 in ds5_2.Tables[0].Rows)
                        {
                            DataRow[] drs5_2 = ds5_2.Tables[0].Select("id='" + dr5_2["id"].ToString() + "'");
                            if (drs5_2.Length > 0)
                            {
                                string strSqlUpdate5_2 = "update t_msg_info t set t.read_flag='true' where t.warn_type=12 and t.id='" + drs5_2[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate5_2);
                            }
                        }
                    }
                }
            }
            string strSql5_3 = " and m.warn_type=13";
            string strSqlTotal5_3 = strSql_One + strSql5_3 + " union " + strSend_sql0ne + strSql5_3 + " union " + strSend_sqlTwo + strSql5_3 + " union " + strSend_sqlThree + strSql5_3 + " union " + strSend_sqlFour + strSql5_3 + " union " + strSend_sqlFive + strSql5_3; 
            if (strSqlTotal5_3.Length > 0)
            {
                DataSet ds5_3 = App.GetDataSet(strSqlTotal5_3);
                if (ds5_3.Tables[0].Rows.Count > 0)
                {
                    int n5_3 = ds5_3.Tables[0].Rows.Count;
                    if (n5_3 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新体征消息(非正常值-脉搏)" + Convert.ToString(n5_3) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新体征消息(非正常值-脉搏)" + Convert.ToString(n5_3) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr5_3 in ds5_3.Tables[0].Rows)
                        {
                            DataRow[] drs5_3 = ds5_3.Tables[0].Select("id='" + dr5_3["id"].ToString() + "'");
                            if (drs5_3.Length > 0)
                            {
                                string strSqlUpdate5_3 = "update t_msg_info t set t.read_flag='true' where t.warn_type=13 and t.id='" + drs5_3[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate5_3);
                            }
                        }
                    }
                }
            }
            string strSql5_4 = " and m.warn_type=14";
            string strSqlTotal5_4 = strSql_One + strSql5_4 + " union " + strSend_sql0ne + strSql5_4 + " union " + strSend_sqlTwo + strSql5_4 + " union " + strSend_sqlThree + strSql5_4 + " union " + strSend_sqlFour + strSql5_4 + " union " + strSend_sqlFive + strSql5_4; 
            if (strSqlTotal5_4.Length > 0)
            {
                DataSet ds5_4 = App.GetDataSet(strSqlTotal5_4);
                if (ds5_4.Tables[0].Rows.Count > 0)
                {
                    int n5_4 = ds5_4.Tables[0].Rows.Count;
                    if (n5_4 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新体征消息(非正常值-呼吸)" + Convert.ToString(n5_4) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新体征消息(非正常值-呼吸)" + Convert.ToString(n5_4) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr5_4 in ds5_4.Tables[0].Rows)
                        {
                            DataRow[] drs5_4 = ds5_4.Tables[0].Select("id='" + dr5_4["id"].ToString() + "'");
                            if (drs5_4.Length > 0)
                            {
                                string strSqlUpdate5_4 = "update t_msg_info t set t.read_flag='true' where t.warn_type=14 and t.id='" + drs5_4[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate5_4);
                            }
                        }
                    }
                }
            }
            string strSql5_5 = " and m.warn_type=15";
            string strSqlTotal5_5 = strSql_One + strSql5_5 + " union " + strSend_sql0ne + strSql5_5 + " union " + strSend_sqlTwo + strSql5_5 + " union " + strSend_sqlThree + strSql5_5 + " union " + strSend_sqlFour + strSql5_5 + " union " + strSend_sqlFive + strSql5_5; 
            if (strSqlTotal5_5.Length > 0)
            {
                DataSet ds5_5 = App.GetDataSet(strSqlTotal5_5);
                if (ds5_5.Tables[0].Rows.Count > 0)
                {
                    int n5_5 = ds5_5.Tables[0].Rows.Count;
                    if (n5_5 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新体征消息(非正常值-血压)" + Convert.ToString(n5_5) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新体征消息(非正常值-血压)" + Convert.ToString(n5_5) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr5_5 in ds5_5.Tables[0].Rows)
                        {
                            DataRow[] drs5_5 = ds5_5.Tables[0].Select("id='" + dr5_5["id"].ToString() + "'");
                            if (drs5_5.Length > 0)
                            {
                                string strSqlUpdate5_5 = "update t_msg_info t set t.read_flag='true' where t.warn_type=15 and t.id='" + drs5_5[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate5_5);
                            }
                        }
                    }
                }
            }
            string strSql6 = " and m.warn_type=16";
            string strSqlTotal6 = strSql_One + strSql6 + " union " + strSend_sql0ne + strSql6 + " union " + strSend_sqlTwo + strSql6 + " union " + strSend_sqlThree + strSql6 + " union " + strSend_sqlFour + strSql6 + " union " + strSend_sqlFive + strSql6; 
            if (strSqlTotal6.Length > 0)
            {
                DataSet ds6 = App.GetDataSet(strSqlTotal6);
                if (ds6.Tables[0].Rows.Count > 0)
                {
                    int n6 = ds6.Tables[0].Rows.Count;
                    if (n6 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新医嘱消息" + Convert.ToString(n6) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新医嘱消息" + Convert.ToString(n6) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr6 in ds6.Tables[0].Rows)
                        {
                            DataRow[] drs6 = ds6.Tables[0].Select("id='" + dr6["id"].ToString() + "'");
                            if (drs6.Length > 0)
                            {
                                string strSqlUpdate6 = "update t_msg_info t set t.read_flag='true' where t.warn_type=16 and t.id='" + drs6[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate6);
                            }
                        }
                    }
                }
            }
            string strSql7 = " and m.warn_type=18";
            string strSqlTotal7 = strSql_One + strSql7 + " union " + strSend_sql0ne + strSql7 + " union " + strSend_sqlTwo + strSql7 + " union " + strSend_sqlThree + strSql7 + " union " + strSend_sqlFour + strSql7 + " union " + strSend_sqlFive + strSql7; 
            if (strSqlTotal7.Length > 0)
            {
                DataSet ds7 = App.GetDataSet(strSqlTotal7);
                if (ds7.Tables[0].Rows.Count > 0)
                {
                    int n7 = ds7.Tables[0].Rows.Count;
                    if (n7 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新其他消息" + Convert.ToString(n7) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新其他消息" + Convert.ToString(n7) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr7 in ds7.Tables[0].Rows)
                        {
                            DataRow[] drs7 = ds7.Tables[0].Select("id='" + dr7["id"].ToString() + "'");
                            if (drs7.Length > 0)
                            {
                                string strSqlUpdate7 = "update t_msg_info t set t.read_flag='true' where t.warn_type=18 and t.id='" + drs7[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate7);
                            }
                        }
                    }
                }
            }
            string strSql8 = " and m.warn_type=1";
            string strSqlTotal8 = strSql_One + strSql8 + " union " + strSend_sql0ne + strSql8 + " union " + strSend_sqlTwo + strSql8 + " union " + strSend_sqlThree + strSql8 + " union " + strSend_sqlFour + strSql8 + " union " + strSend_sqlFive + strSql8; 
            if (strSqlTotal8.Length > 0)
            {
                DataSet ds8 = App.GetDataSet(strSqlTotal8);
                if (ds8.Tables[0].Rows.Count > 0)
                {
                    int n8 = ds8.Tables[0].Rows.Count;
                    if (n8 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新主动消息(重要消息)" + Convert.ToString(n8) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新主动消息(重要消息)" + Convert.ToString(n8) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr8 in ds8.Tables[0].Rows)
                        {
                            DataRow[] drs8 = ds8.Tables[0].Select("id='" + dr8["id"].ToString() + "'");
                            if (drs8.Length > 0)
                            {
                                string strSqlUpdate8 = "update t_msg_info t set t.read_flag='true' where t.warn_type=1 and t.id='" + drs8[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate8);
                            }
                        }
                    }
                }
            }
            string strSql8_2 = " and m.warn_type=2";
            string strSqlTotal8_2 = strSql_One + strSql8_2 + " union " + strSend_sql0ne + strSql8_2 + " union " + strSend_sqlTwo + strSql8_2 + " union " + strSend_sqlThree + strSql8_2 + " union " + strSend_sqlFour + strSql8_2 + " union " + strSend_sqlFive + strSql8_2; 
            if (strSqlTotal8_2.Length > 0)
            {
                DataSet ds8_2 = App.GetDataSet(strSqlTotal8_2);
                if (ds8_2.Tables[0].Rows.Count > 0)
                {
                    int n8_2 = ds8_2.Tables[0].Rows.Count;
                    if (n8_2 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新主动消息(普通消息)" + Convert.ToString(n8_2) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新主动消息(普通消息)" + Convert.ToString(n8_2) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr8_2 in ds8_2.Tables[0].Rows)
                        {
                            DataRow[] drs8_2 = ds8_2.Tables[0].Select("id='" + dr8_2["id"].ToString() + "'");
                            if (drs8_2.Length > 0)
                            {
                                string strSqlUpdate8_2 = "update t_msg_info t set t.read_flag='true' where t.warn_type=2 and t.id='" + drs8_2[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate8_2);
                            }
                        }
                    }
                }
            }
            string strSql9 = " and m.warn_type=17";
            string strSqlTotal9 = strSql_One + strSql9 + " union " + strSend_sql0ne + strSql9 + " union " + strSend_sqlTwo + strSql9 + " union " + strSend_sqlThree + strSql9 + " union " + strSend_sqlFour + strSql9 + " union " + strSend_sqlFive + strSql9; 
            if (strSqlTotal9.Length > 0)
            {
                DataSet ds9 = App.GetDataSet(strSqlTotal9);
                if (ds9.Tables[0].Rows.Count > 0)
                {
                    int n9 = ds9.Tables[0].Rows.Count;
                    if (n9 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新评分消息" + Convert.ToString(n9) + "条，请注意查收！";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新评分消息" + Convert.ToString(n9) + "条，请注意查收！";
                        }
                        foreach (DataRow dr9 in ds9.Tables[0].Rows)
                        {
                            DataRow[] drs9 = ds9.Tables[0].Select("id='" + dr9["id"].ToString() + "'");
                            if (drs9.Length > 0)
                            {
                                string strSqlUpdate9 = "update t_msg_info t set t.read_flag='true' where t.warn_type=17 and t.id='" + drs9[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate9);
                            }
                        }
                    }
                }
            }
            string strSql_zd = " and m.warn_type=19 ";
            string strSqlTotal_zd = strSql_One + strSql_zd + " union " + strSend_sql0ne + strSql_zd + " union " + strSend_sqlTwo + strSql_zd + " union " + strSend_sqlThree + strSql_zd + " union " + strSend_sqlFour + strSql_zd + " union " + strSend_sqlFive + strSql_zd; 
            if (strSqlTotal_zd.Length > 0)
            {
                DataSet ds_zd = App.GetDataSet(strSqlTotal_zd);
                if (ds_zd.Tables[0].Rows.Count > 0)
                {
                    int n1 = ds_zd.Tables[0].Rows.Count;
                    if (n1 > 0)
                    {
                        if (txtBoxShow.Text == "")
                        {
                            txtBoxShow.Text = "您有新发布消息" + Convert.ToString(n1) + "条，请注意查收！\r\n";
                        }
                        else
                        {
                            txtBoxShow.Text += "您有新发布消息" + Convert.ToString(n1) + "条，请注意查收！\r\n";
                        }
                        foreach (DataRow dr_zd in ds_zd.Tables[0].Rows)
                        {
                            DataRow[] drs_zd = ds_zd.Tables[0].Select("id='" + dr_zd["id"].ToString() + "'");
                            if (drs_zd.Length > 0)
                            {
                                string strSqlUpdate_zd = "update t_msg_info t set t.read_flag='true' where t.warn_type=19 and t.id='" + drs_zd[0]["id"] + "'";
                                App.ExecuteSQL(strSqlUpdate_zd);
                            }
                        }
                    }
                }
            }
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.PointToScreen(p);
            this.Location = p;
            for (int i = 0; i <= this.Height; i++)
            {
                this.Location = new Point(p.X, p.Y - i);
            }
            this.Activate();
        }
        /// <summary>
        /// 查看功能--消息查看界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCK_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> sqls = new List<string>();
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
                               and p.id=m.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure  is null
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
                               and p.id=m.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure  is null
                               and p.role_type in('D','N')
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
                                and p.id=m.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure  is null
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
                               and p.id=m.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure  is null
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
                               and p.id=m.id
                               and m.warn_type='19'
                               and t.MSG_START_UP = '1'
                               and m.msg_status = '1'
                               and p.make_sure  is null
                               and m.content_id='6'
                               and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";
                string strSql = strSql_One + " union " + strSend_sql0ne + " union " + strSend_sqlTwo + " union " + strSend_sqlThree + " union " + strSend_sqlFour + " union " + strSend_sqlFive;
                DataSet ds_testNewShow = App.GetDataSet(strSql);
                if (ds_testNewShow.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds_testNewShow.Tables[0].Rows)
                    {
                        DataRow[] drs = ds_testNewShow.Tables[0].Select("id='" + dr["id"].ToString() + "'");
                        if (drs.Length > 0)
                        {
                            string strSqlUpdateOne = "update t_msg_info t set t.read_flag='true' where t.id='" + drs[0]["id"] + "'";
                            sqls.Add(strSqlUpdateOne);
                            string strSqlUpdateTwo = "update (select t2.read_flag from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + drs[0]["id"] + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.read_flag='true'";
                            sqls.Add(strSqlUpdateTwo);
                            App.ExecuteBatch(sqls.ToArray());
                        }
                    }
                    Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShow frm = new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmMessageShow();
                    frm.ShowDialog();
                    this.Close();
                }
            }
            catch
            {

            }
        }
    }

}