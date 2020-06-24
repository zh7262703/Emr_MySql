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
        //��Ϣ���������� Ԭ��� 
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
            //��Ϣ���������н�����Ϊ����ȫԺ��
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
            //��Ϣ���������н�����Ϊ����ȫԺҽ����ȫԺ��ʿ��
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
            //��Ϣ���������н�����Ϊ�������ң�
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
            //��Ϣ���������н�����Ϊ����������
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
            //��Ϣ���������н�����Ϊ�������ˣ�
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
                string strAll_unReadNews = Convert.ToString(ds.Tables[0].Rows.Count);//����δ����Ϣ
                int strZDTX = 0;//��������1,2
                int strZKTX = 0;//�ʿ�����3,4
                int strJYTX = 0;//��������5,6,7
                int strPACSJCTX = 0;//�������8,9  
                int strZTTX = 0;//״̬����10
                int strTZTX = 0;//��������11,12,13,14,15
                int strYZTX = 0;//ҽ������16
                int strPFTX = 0;//��������17
                int strQTTX = 0;//��������18
                int strXXFBTX = 0;//��Ϣ��������19
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
                tabAllNewsNotice.Text = "ȫ������ (" + strAll_unReadNews + ")";// ȫ������
                tabQualityControlNotice.Text = "�ʿ����� (" + Convert.ToString(strZKTX) + ")";//  �ʿ�����
                tabTestNews.Text = "�������� (" + Convert.ToString(strJYTX) + ")";// ��������
                tabPacsNews.Text = "pacs������� (" + Convert.ToString(strPACSJCTX) + ")";//  pacs�������
                tabStateNews.Text = "״̬���� (" + Convert.ToString(strZTTX) + ")";//  ״̬����
                tabBodyStateNews.Text = "�������� (" + Convert.ToString(strTZTX) + ")";//  ��������
                tabDoctorIdeaNews.Text = "ҽ������ (" + Convert.ToString(strYZTX) + ")";//  ҽ������
                tabOtherNews.Text = "�������� (" + Convert.ToString(strQTTX) + ")";//  ��������
                tabcinitiativeNews.Text = "�������� (" + Convert.ToString(strZDTX) + ")";//  ��������
                tabBAPointsNews.Text = "������������ (" + Convert.ToString(strPFTX) + ")";//  ������������
                tabNewSend.Text = "��Ϣ�������� (" + Convert.ToString(strXXFBTX) + ")";//   ��Ϣ��������
            }
        }
    }

}