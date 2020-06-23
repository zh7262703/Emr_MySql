using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost.WebReference;
using DevComponents.AdvTree;
using System.Collections;
using Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class UcAllNewsNotice : UserControl
    {
        public UcAllNewsNotice()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 获取所有提醒消息
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoNew.Columns.Clear();
            dgvMsgInfoNewReaded.Columns.Clear();
            //所有消息提醒内容
            //string sqlMsg = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
            //    "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
            //    " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
            //     "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where  t.WARN_TYPE = m.WARN_TYPE and  INSTR(   (select distinct( ',' ||   t1.MSGSECTION_ID || ',' )  from t_msg_setting t1,t_msg_info t2,t_msg_content t3 " +
            //    " where t2.content_id=t3.id and t3.msg_scale=t1.msg_type and t2.warn_type=t1.warn_type),    ',' ||  TRIM(TO_CHAR(p.section_id ))  || ','  )  > 0 and m.pid=p.id and t.MSG_START_UP = '1' and  m.msg_status=0 and  receive_user_id=" + App.UserAccount.UserInfo.User_id;

            string sql_Msg = "select distinct( m.id),m.isreply 回复,m.warn_type,m.isreply,p.patient_name 患者姓名, to_char(p.sick_doctor_id) sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                 "from T_MSG_INFO m, t_in_patient p, t_msg_setting t where  t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.msg_status=0 and " +
                  " (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0   and receive_user_id=" + App.UserAccount.UserInfo.User_id;
            //全院
            string sqlMsgOne = "select distinct( m.id),m.REPLY_MSG 回复,m.warn_type,p.isreply,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and  t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1' and m.content_id='1'   and p.make_sure is null and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgTwo = "select distinct( m.id),m.REPLY_MSG 回复,m.warn_type,p.isreply,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where  m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure is null " +
                " and p.role_type in ('D','N') and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgThree = "select distinct( m.id),m.REPLY_MSG 回复,m.warn_type,p.isreply,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure is null " +
                " and m.content_id='4' and  p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgFour = "select distinct( m.id),m.REPLY_MSG 回复,m.warn_type,p.isreply,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure is null " +
                " and m.content_id='5'  and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgFive = "select distinct( m.id),m.REPLY_MSG 回复,m.warn_type,p.isreply,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure is null " +
                " and m.content_id='6'  and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";
            string sqlMsg = "select v.id,v.回复,v.warn_type,v.isreply,v.患者姓名,v.sick_doctor_id,v.管床医生,v.性别,v.年龄,v.his_id,v.床号,v.当前病区,v.消息类型,v.次消息类型,v.提醒内容,v.发送人,v.发送时间  from (" + (sql_Msg + " union " + sqlMsgOne + " union " + sqlMsgTwo + " union " + sqlMsgThree + " union " + sqlMsgFour + " union " + sqlMsgFive) + " ) v  order by v.发送时间 desc";

            string sqlMsg_Readed = "select distinct( m.id),m.isreply 回复,m.warn_type,p.patient_name 患者姓名,to_char(p.sick_doctor_id) sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间,m.REPLY_MSG 回复内容 " +
                 "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where  t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.msg_status=1 and  " +
                  " (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id=" + App.UserAccount.UserInfo.User_id;

            string sqlMsgReadedOne = "select distinct( m.id),m.isreply 回复,m.warn_type,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间,m.REPLY_MSG 回复内容 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1' and m.content_id='1'   and p.make_sure='true' and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReadedTwo = "select distinct( m.id),m.isreply 回复,m.warn_type,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间,m.REPLY_MSG 回复内容 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure='true' " +
                " and p.role_type in ('D','N') and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReadedThree = "select distinct( m.id),m.isreply 回复,m.warn_type,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间,m.REPLY_MSG 回复内容 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and  t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure='true' " +
                " and m.content_id='4' and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReadedFour = "select distinct( m.id),m.isreply 回复,m.warn_type,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间,m.REPLY_MSG 回复内容 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure='true' " +
                " and m.content_id='5'  and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReadedFive = "select distinct( m.id),m.isreply 回复,m.warn_type,m.REPLY_MSG 患者姓名,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG 管床医生,m.REPLY_MSG 性别,m.REPLY_MSG 年龄," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG 床号,m.REPLY_MSG 当前病区,m.type_name 消息类型,m.TYPE_Name_CY 次消息类型," +
               " m.content 提醒内容,case type_id when 1 then m.patient_name else m.operator_user_name  end 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间,m.REPLY_MSG 回复内容 " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure='true' " +
                " and m.content_id='6'  and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReaded = "select v.id,v.回复,v.warn_type,v.患者姓名,v.sick_doctor_id,v.性别,v.年龄,v.his_id,v.床号,v.当前病区,v.消息类型,v.次消息类型,v.提醒内容,v.发送人,v.发送时间,v.回复内容  from  (" + (sqlMsg_Readed + " union " + sqlMsgReadedOne + " union " + sqlMsgReadedTwo + " union " + sqlMsgReadedThree + " union " + sqlMsgReadedFour + " union " + sqlMsgReadedFive) + " ) v  order by v.发送时间 desc ";

            Class_Table[] tab = new Class_Table[2];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sqlMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "newMsgReaded";
            tab[1].Sql = sqlMsgReaded;



            DataSet dsPatient = App.GetDataSet(tab);
            if (dsPatient != null)
            {
                //所有消息提醒
                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "全部未读信息" + "(" + n_newMsg + ")";
                }

                DataGridViewCheckBoxColumn cBox = new DataGridViewCheckBoxColumn();
                cBox.HeaderText = "选择";
                cBox.Name = "select";
                dgvMsgInfoNew.Columns.Insert(0, cBox);
                dgvMsgInfoNew.Columns["select"].ReadOnly = false;



                dgvMsgInfoNew.Columns["id"].Visible = false;
                dgvMsgInfoNew.Columns["sick_doctor_id"].Visible = false;
                dgvMsgInfoNew.Columns["warn_type"].Visible = false;
                dgvMsgInfoNew.Columns["isreply"].Visible = false;

                dgvMsgInfoNewReaded.DataSource = dsPatient.Tables["newMsgReaded"];
                
                dgvMsgInfoNewReaded.Columns["sick_doctor_id"].Visible = false;
                dgvMsgInfoNewReaded.Columns["warn_type"].Visible = false;


                //默认回复字段是否选中
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["回复"].Value.ToString() == "1")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["回复"].Value = "是";
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["isreply"].Value.ToString() == "1" && dgvMsgInfoNew.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["回复"].Value = "需要收条";
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["回复"].Value.ToString() == "0")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["回复"].Value = "否";
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["isreply"].Value.ToString() == "0" && dgvMsgInfoNew.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["回复"].Value = "不需要";
                    }
                }
                for (int i = 0; i < dgvMsgInfoNewReaded.Rows.Count; i++)
                {
                    if (dgvMsgInfoNewReaded.Rows[i].Cells["回复"].Value.ToString() == "1" && dgvMsgInfoNewReaded.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNewReaded.Rows[i].Cells["回复"].Value = "需要收条";
                    }
                    if (dgvMsgInfoNewReaded.Rows[i].Cells["回复"].Value.ToString() == "0" && dgvMsgInfoNewReaded.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNewReaded.Rows[i].Cells["回复"].Value = "不需要";
                    }
                    if (dgvMsgInfoNewReaded.Rows[i].Cells["回复"].Value.ToString() == "1")
                    {
                        dgvMsgInfoNewReaded.Rows[i].Cells["回复"].Value = "是";
                    }
                    if (dgvMsgInfoNewReaded.Rows[i].Cells["回复"].Value.ToString() == "0")
                    {
                        dgvMsgInfoNewReaded.Rows[i].Cells["回复"].Value = "否";
                    }

                }
                dgvMsgInfoNewReaded.Columns["id"].Visible = false;
                //设置字段显示格式
                dgvMsgInfoNew.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["回复"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["消息类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["次消息类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvMsgInfoNew.Columns["提醒内容"].Width = 250;
                dgvMsgInfoNew.Columns[15].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();


                dgvMsgInfoNewReaded.Columns["回复"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["消息类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["次消息类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvMsgInfoNewReaded.Columns["提醒内容"].Width = 200;
                dgvMsgInfoNewReaded.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNewReaded.Columns["回复内容"].Width = 200;
                dgvMsgInfoNewReaded.Columns[15].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
               
              

            }

        }



        private void UcAllNewsNotice_Load(object sender, EventArgs e)
        {
            try
            {
                // 设定包括Header和所有单元格的列宽自动调整 
                //dgvMsgInfoNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvMsgInfoNewReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                GetMessage();
            }
            catch
            {
            }
        }

        private void UcAllNewsNotice_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnMakeSure_Click_1(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            try
            {
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();
                dgvMsgInfoNewReaded.AutoResizeRows();
                dgvMsgInfoNewReaded.Refresh();
                if (tabControl1.SelectedTab == tabItem7)
                {
                    this.btnRefurbish.Visible = false;
                    this.btnMakeSure.Visible = false;
                    this.btnReply.Visible = false;
                    this.btnTrueSend.Visible = false;
                }
                else
                {
                    this.btnRefurbish.Visible = true;
                    this.btnMakeSure.Visible = true;
                    this.btnReply.Visible = true;
                    this.btnTrueSend.Visible = true;
                }
            }
            catch
            {

            }
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
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeSure_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> sqls = new List<string>();
                string msgId = "";//接收主键id
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                    {
                        if (dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                        {
                            if (dgvMsgInfoNew.Rows[i].Cells["回复"].Value.ToString() != "是" && dgvMsgInfoNew.Rows[i].Cells["回复"].Value.ToString() != "需要收条")
                            {
                                if (dgvMsgInfoNew.Rows[i].Cells["回复"].Value.ToString() == "不需要")
                                {
                                    msgId = dgvMsgInfoNew.Rows[i].Cells["id"].Value.ToString();
                                    string strUpdate_one_sql = "update (select t2.make_sure,t2.dispose_time from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + msgId + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.make_sure='true',t.dispose_time=sysdate";
                                    sqls.Add(strUpdate_one_sql);
                                }
                                else
                                {
                                    msgId = dgvMsgInfoNew.Rows[i].Cells["id"].Value.ToString();
                                    string strUpdate_two_sql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + msgId + "'";
                                    sqls.Add(strUpdate_two_sql);
                                }
                            }
                            else
                            {
                                App.Msg("当前选中的消息中含有需要回复或收条的消息,不允许当前操作！");
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
                            GetMessage();
                        }
                    }

                }
                #region 注释掉
                //    if (dgvMsgInfoNew.CurrentCell != null)
                //    {
                //        string msgId = "";
                //        if (dgvMsgInfoNew.CurrentRow.Cells["回复"].Value.ToString() != "是")
                //        {
                //            if (dgvMsgInfoNew.CurrentRow.Cells["回复"].Value.ToString() == "不需要")
                //            {
                //                msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                //                if (msgId != "")
                //                {
                //                    string update = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + msgId + "'";
                //                    int num = App.ExecuteSQL(update);
                //                    if (num > 0)
                //                    {
                //                        App.Msg("确认成功！");
                //                        GetMessage();

                //                    }
                //                    else
                //                    {
                //                        App.Msg("确认失败！");
                //                    }
                //                }
                //            }
                //            if (dgvMsgInfoNew.CurrentRow.Cells["回复"].Value.ToString() == "不需要")
                //            {
                //                msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                //                if (msgId != "")
                //                {
                //                    // string update = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate,flag='true' where id ='" + msgId + "'";
                //                    string update = "update (select t2.make_sure,t2.dispose_time from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + msgId + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.make_sure='true',t.dispose_time=sysdate";
                //                    int num = App.ExecuteSQL(update);
                //                    if (num > 0)
                //                    {
                //                        App.Msg("确认成功！");
                //                        GetMessage();

                //                    }
                //                    else
                //                    {
                //                        App.Msg("确认失败！");
                //                    }
                //                }
                //            }
                //            else
                //            {

                //                msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                //                if (msgId != "")
                //                {
                //                    string update = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + msgId + "'";
                //                    int num = App.ExecuteSQL(update);
                //                    if (num > 0)
                //                    {
                //                        App.Msg("确认成功！");
                //                        GetMessage();

                //                    }
                //                    else
                //                    {
                //                        App.Msg("确认失败！");
                //                    }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            App.Msg("只有不需要回复的消息才有此操作！");
                //        }
                //    }
                #endregion
            }

            catch
            {

            }

        }
        /// <summary>
        /// 回复按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReply_Click(object sender, EventArgs e)
        {
            if (dgvMsgInfoNew.Rows.Count > 0)
            {
                int inMark = 0;
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                    {
                        inMark = inMark + 1;
                        if (inMark > 1)
                        {
                            App.Msg("回复按钮只支持单条操作,不支持批量操作！");
                            return;
                        }
                    }
                }
            }
            for (int j = 0; j < dgvMsgInfoNew.Rows.Count; j++)
            {
                if (dgvMsgInfoNew.Rows[j].Cells["select"].EditedFormattedValue.ToString() == "True")
                {
                    string msgIds = "";
                    if (dgvMsgInfoNew.Rows[j].Cells["回复"].Value.ToString() == "是")
                    {
                        msgIds = dgvMsgInfoNew.Rows[j].Cells["id"].Value.ToString();
                    }
                    if (msgIds != "")
                    {
                        frmMsgReplay frmR = new frmMsgReplay(msgIds);
                        frmR.ShowDialog();
                        if (frmR.flag)
                        {
                            GetMessage();
                        }
                    }
                    else
                    {
                        App.Msg("请选择需要回复的消息进行操作！");
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// 确认并发送收条
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrueSend_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<string> sqls = new List<string>();
                string msgId = "";//接收主键id
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                    {
                        if (dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                        {
                            if (dgvMsgInfoNew.Rows[i].Cells["回复"].Value.ToString() == "需要收条")
                            {
                                msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                                string update = "update (select t2.make_sure,t2.dispose_time,t2.isreply from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + msgId + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.make_sure='true',t.dispose_time=sysdate,t.isreply='2'";
                                sqls.Add(update);
                            }
                            else
                            {
                                App.Msg("当前选中的消息中含有不需要发送收条的消息,请重新操作！");
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
                            GetMessage();
                        }
                    }
                }
                #region 注释掉
                //if (dgvMsgInfoNew.CurrentCell != null)
                //{
                //    if (dgvMsgInfoNew.CurrentRow.Cells["回复"].Value.ToString() == "需要")
                //    {
                //        string msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                //        //string update = "update t_msg_info set flag='true' ,dispose_time=sysdate where id ='" + msgId + "'";
                //        string update = "update (select t2.make_sure,t2.dispose_time,t2.isreply from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + msgId + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.make_sure='true',t.dispose_time=sysdate,t.isreply='2'";
                //        int num = App.ExecuteSQL(update);
                //        if (num > 0)
                //        {
                //            App.Msg("确认成功！");
                //            GetMessage();

                //        }
                //        else
                //        {
                //            App.Msg("确认失败！");
                //        }
                //    }
                //    else
                //    {
                //        App.Msg("此条消息不需要发送收条！");
                //        return;
                //    }
                //} 
                #endregion
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        private void dgvMsgInfoNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dgvMsgInfoNewReaded_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        /// <summary>
        /// 双击查看消息的详细信息 (未读界面)   消息发布提醒的应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMsgInfoNew_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    if (dgvMsgInfoNew.CurrentRow.Cells["回复"].Value.ToString() == "需要收条" || dgvMsgInfoNew.CurrentRow.Cells["回复"].Value.ToString() == "不需要")
                    {
                        string strId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                        string strUser_id = App.UserAccount.UserInfo.User_id.ToString();
                        if (strId != "" && strUser_id != "")
                        {
                            frmMsgSendDetailsCheck frm = new frmMsgSendDetailsCheck(strId, strUser_id);
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        App.Msg("当前消息没有查看详细信息功能！");
                        return;
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 双击查看消息的详细信息 (未读界面)   消息发布提醒的应用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMsgInfoNewReaded_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvMsgInfoNewReaded.Rows.Count > 0)
                {
                    if (dgvMsgInfoNewReaded.CurrentRow.Cells["回复"].Value.ToString() == "需要收条" || dgvMsgInfoNewReaded.CurrentRow.Cells["回复"].Value.ToString() == "不需要")
                    {
                        string strId = dgvMsgInfoNewReaded.CurrentRow.Cells["id"].Value.ToString();
                        string strUser_id = App.UserAccount.UserInfo.User_id.ToString();
                        if (strId != "" && strUser_id != "")
                        {
                            frmMsgSendDetailsCheck frm = new frmMsgSendDetailsCheck(strId, strUser_id);
                            frm.ShowDialog();
                        }
                    }
                    else
                    {
                        App.Msg("当前消息没有查看详细信息功能！");
                        return;
                    }
                }
            }
            catch
            {

            }
        }
    }
}
