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
        /// ��ȡ����������Ϣ
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoNew.Columns.Clear();
            dgvMsgInfoNewReaded.Columns.Clear();
            //������Ϣ��������
            //string sqlMsg = "select distinct( m.id),p.patient_name ��������,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
            //    "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
            //    " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
            //     "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where  t.WARN_TYPE = m.WARN_TYPE and  INSTR(   (select distinct( ',' ||   t1.MSGSECTION_ID || ',' )  from t_msg_setting t1,t_msg_info t2,t_msg_content t3 " +
            //    " where t2.content_id=t3.id and t3.msg_scale=t1.msg_type and t2.warn_type=t1.warn_type),    ',' ||  TRIM(TO_CHAR(p.section_id ))  || ','  )  > 0 and m.pid=p.id and t.MSG_START_UP = '1' and  m.msg_status=0 and  receive_user_id=" + App.UserAccount.UserInfo.User_id;

            string sql_Msg = "select distinct( m.id),m.isreply �ظ�,m.warn_type,m.isreply,p.patient_name ��������, to_char(p.sick_doctor_id) sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                 "from T_MSG_INFO m, t_in_patient p, t_msg_setting t where  t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.msg_status=0 and " +
                  " (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0   and receive_user_id=" + App.UserAccount.UserInfo.User_id;
            //ȫԺ
            string sqlMsgOne = "select distinct( m.id),m.REPLY_MSG �ظ�,m.warn_type,p.isreply,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and  t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1' and m.content_id='1'   and p.make_sure is null and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgTwo = "select distinct( m.id),m.REPLY_MSG �ظ�,m.warn_type,p.isreply,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where  m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure is null " +
                " and p.role_type in ('D','N') and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgThree = "select distinct( m.id),m.REPLY_MSG �ظ�,m.warn_type,p.isreply,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure is null " +
                " and m.content_id='4' and  p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgFour = "select distinct( m.id),m.REPLY_MSG �ظ�,m.warn_type,p.isreply,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure is null " +
                " and m.content_id='5'  and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgFive = "select distinct( m.id),m.REPLY_MSG �ظ�,m.warn_type,p.isreply,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure is null " +
                " and m.content_id='6'  and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";
            string sqlMsg = "select v.id,v.�ظ�,v.warn_type,v.isreply,v.��������,v.sick_doctor_id,v.�ܴ�ҽ��,v.�Ա�,v.����,v.his_id,v.����,v.��ǰ����,v.��Ϣ����,v.����Ϣ����,v.��������,v.������,v.����ʱ��  from (" + (sql_Msg + " union " + sqlMsgOne + " union " + sqlMsgTwo + " union " + sqlMsgThree + " union " + sqlMsgFour + " union " + sqlMsgFive) + " ) v  order by v.����ʱ�� desc";

            string sqlMsg_Readed = "select distinct( m.id),m.isreply �ظ�,m.warn_type,p.patient_name ��������,to_char(p.sick_doctor_id) sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ��,m.REPLY_MSG �ظ����� " +
                 "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where  t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.msg_status=1 and  " +
                  " (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id=" + App.UserAccount.UserInfo.User_id;

            string sqlMsgReadedOne = "select distinct( m.id),m.isreply �ظ�,m.warn_type,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ��,m.REPLY_MSG �ظ����� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1' and m.content_id='1'   and p.make_sure='true' and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReadedTwo = "select distinct( m.id),m.isreply �ظ�,m.warn_type,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ��,m.REPLY_MSG �ظ����� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure='true' " +
                " and p.role_type in ('D','N') and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReadedThree = "select distinct( m.id),m.isreply �ظ�,m.warn_type,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ��,m.REPLY_MSG �ظ����� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and  t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure='true' " +
                " and m.content_id='4' and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReadedFour = "select distinct( m.id),m.isreply �ظ�,m.warn_type,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ��,m.REPLY_MSG �ظ����� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure='true' " +
                " and m.content_id='5'  and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReadedFive = "select distinct( m.id),m.isreply �ظ�,m.warn_type,m.REPLY_MSG ��������,m.REPLY_MSG as sick_doctor_id,  m.REPLY_MSG �ܴ�ҽ��,m.REPLY_MSG �Ա�,m.REPLY_MSG ����," +
               "m.REPLY_MSG  as his_id,m.REPLY_MSG ����,m.REPLY_MSG ��ǰ����,m.type_name ��Ϣ����,m.TYPE_Name_CY ����Ϣ����," +
               " m.content ��������,case type_id when 1 then m.patient_name else m.operator_user_name  end ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ��,m.REPLY_MSG �ظ����� " +
                "from T_MSG_INFO m,t_msg_setting t,t_msg_user p where m.id=p.id and t.WARN_TYPE = m.WARN_TYPE and m.warn_type='19' and t.MSG_START_UP = '1' and  m.msg_status='1'  and p.make_sure='true' " +
                " and m.content_id='6'  and p.user_id='" + App.UserAccount.UserInfo.User_id + "'";

            string sqlMsgReaded = "select v.id,v.�ظ�,v.warn_type,v.��������,v.sick_doctor_id,v.�Ա�,v.����,v.his_id,v.����,v.��ǰ����,v.��Ϣ����,v.����Ϣ����,v.��������,v.������,v.����ʱ��,v.�ظ�����  from  (" + (sqlMsg_Readed + " union " + sqlMsgReadedOne + " union " + sqlMsgReadedTwo + " union " + sqlMsgReadedThree + " union " + sqlMsgReadedFour + " union " + sqlMsgReadedFive) + " ) v  order by v.����ʱ�� desc ";

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
                //������Ϣ����
                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "ȫ��δ����Ϣ" + "(" + n_newMsg + ")";
                }

                DataGridViewCheckBoxColumn cBox = new DataGridViewCheckBoxColumn();
                cBox.HeaderText = "ѡ��";
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


                //Ĭ�ϻظ��ֶ��Ƿ�ѡ��
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value.ToString() == "1")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value = "��";
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["isreply"].Value.ToString() == "1" && dgvMsgInfoNew.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value = "��Ҫ����";
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value.ToString() == "0")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value = "��";
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["isreply"].Value.ToString() == "0" && dgvMsgInfoNew.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value = "����Ҫ";
                    }
                }
                for (int i = 0; i < dgvMsgInfoNewReaded.Rows.Count; i++)
                {
                    if (dgvMsgInfoNewReaded.Rows[i].Cells["�ظ�"].Value.ToString() == "1" && dgvMsgInfoNewReaded.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNewReaded.Rows[i].Cells["�ظ�"].Value = "��Ҫ����";
                    }
                    if (dgvMsgInfoNewReaded.Rows[i].Cells["�ظ�"].Value.ToString() == "0" && dgvMsgInfoNewReaded.Rows[i].Cells["warn_type"].Value.ToString() == "19")
                    {
                        dgvMsgInfoNewReaded.Rows[i].Cells["�ظ�"].Value = "����Ҫ";
                    }
                    if (dgvMsgInfoNewReaded.Rows[i].Cells["�ظ�"].Value.ToString() == "1")
                    {
                        dgvMsgInfoNewReaded.Rows[i].Cells["�ظ�"].Value = "��";
                    }
                    if (dgvMsgInfoNewReaded.Rows[i].Cells["�ظ�"].Value.ToString() == "0")
                    {
                        dgvMsgInfoNewReaded.Rows[i].Cells["�ظ�"].Value = "��";
                    }

                }
                dgvMsgInfoNewReaded.Columns["id"].Visible = false;
                //�����ֶ���ʾ��ʽ
                dgvMsgInfoNew.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�ظ�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�ܴ�ҽ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��Ϣ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����Ϣ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ δ���������������
                dgvMsgInfoNew.Columns["��������"].Width = 250;
                dgvMsgInfoNew.Columns[15].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();


                dgvMsgInfoNewReaded.Columns["�ظ�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["��Ϣ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����Ϣ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                dgvMsgInfoNewReaded.Columns["��������"].Width = 200;
                dgvMsgInfoNewReaded.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNewReaded.Columns["�ظ�����"].Width = 200;
                dgvMsgInfoNewReaded.Columns[15].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
               
              

            }

        }



        private void UcAllNewsNotice_Load(object sender, EventArgs e)
        {
            try
            {
                // �趨����Header�����е�Ԫ����п��Զ����� 
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
        /// ˢ��
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
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeSure_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> sqls = new List<string>();
                string msgId = "";//��������id
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                    {
                        if (dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                        {
                            if (dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value.ToString() != "��" && dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value.ToString() != "��Ҫ����")
                            {
                                if (dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value.ToString() == "����Ҫ")
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
                                App.Msg("��ǰѡ�е���Ϣ�к�����Ҫ�ظ�����������Ϣ,������ǰ������");
                                return;
                            }
                        }
                    }
                    if (sqls.Count > 0)
                    {
                        int n = App.ExecuteBatch(sqls.ToArray());
                        if (n > 0)
                        {
                            App.Msg("ȷ�ϳɹ���");
                            GetMessage();
                        }
                    }

                }
                #region ע�͵�
                //    if (dgvMsgInfoNew.CurrentCell != null)
                //    {
                //        string msgId = "";
                //        if (dgvMsgInfoNew.CurrentRow.Cells["�ظ�"].Value.ToString() != "��")
                //        {
                //            if (dgvMsgInfoNew.CurrentRow.Cells["�ظ�"].Value.ToString() == "����Ҫ")
                //            {
                //                msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                //                if (msgId != "")
                //                {
                //                    string update = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + msgId + "'";
                //                    int num = App.ExecuteSQL(update);
                //                    if (num > 0)
                //                    {
                //                        App.Msg("ȷ�ϳɹ���");
                //                        GetMessage();

                //                    }
                //                    else
                //                    {
                //                        App.Msg("ȷ��ʧ�ܣ�");
                //                    }
                //                }
                //            }
                //            if (dgvMsgInfoNew.CurrentRow.Cells["�ظ�"].Value.ToString() == "����Ҫ")
                //            {
                //                msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                //                if (msgId != "")
                //                {
                //                    // string update = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate,flag='true' where id ='" + msgId + "'";
                //                    string update = "update (select t2.make_sure,t2.dispose_time from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + msgId + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.make_sure='true',t.dispose_time=sysdate";
                //                    int num = App.ExecuteSQL(update);
                //                    if (num > 0)
                //                    {
                //                        App.Msg("ȷ�ϳɹ���");
                //                        GetMessage();

                //                    }
                //                    else
                //                    {
                //                        App.Msg("ȷ��ʧ�ܣ�");
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
                //                        App.Msg("ȷ�ϳɹ���");
                //                        GetMessage();

                //                    }
                //                    else
                //                    {
                //                        App.Msg("ȷ��ʧ�ܣ�");
                //                    }
                //                }
                //            }
                //        }
                //        else
                //        {
                //            App.Msg("ֻ�в���Ҫ�ظ�����Ϣ���д˲�����");
                //        }
                //    }
                #endregion
            }

            catch
            {

            }

        }
        /// <summary>
        /// �ظ���ť
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
                            App.Msg("�ظ���ťֻ֧�ֵ�������,��֧������������");
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
                    if (dgvMsgInfoNew.Rows[j].Cells["�ظ�"].Value.ToString() == "��")
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
                        App.Msg("��ѡ����Ҫ�ظ�����Ϣ���в�����");
                        return;
                    }
                }
            }
        }
        /// <summary>
        /// ȷ�ϲ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrueSend_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<string> sqls = new List<string>();
                string msgId = "";//��������id
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                    {
                        if (dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                        {
                            if (dgvMsgInfoNew.Rows[i].Cells["�ظ�"].Value.ToString() == "��Ҫ����")
                            {
                                msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                                string update = "update (select t2.make_sure,t2.dispose_time,t2.isreply from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + msgId + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.make_sure='true',t.dispose_time=sysdate,t.isreply='2'";
                                sqls.Add(update);
                            }
                            else
                            {
                                App.Msg("��ǰѡ�е���Ϣ�к��в���Ҫ������������Ϣ,�����²�����");
                                return;
                            }
                        }
                    }
                    if (sqls.Count > 0)
                    {
                        int n = App.ExecuteBatch(sqls.ToArray());
                        if (n > 0)
                        {
                            App.Msg("ȷ�ϲ����������ɹ���");
                            GetMessage();
                        }
                    }
                }
                #region ע�͵�
                //if (dgvMsgInfoNew.CurrentCell != null)
                //{
                //    if (dgvMsgInfoNew.CurrentRow.Cells["�ظ�"].Value.ToString() == "��Ҫ")
                //    {
                //        string msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                //        //string update = "update t_msg_info set flag='true' ,dispose_time=sysdate where id ='" + msgId + "'";
                //        string update = "update (select t2.make_sure,t2.dispose_time,t2.isreply from t_msg_info  t1,t_msg_user t2 where t1.id=t2.id and t1.id='" + msgId + "' and t2.user_id='" + App.UserAccount.UserInfo.User_id.ToString() + "') t set t.make_sure='true',t.dispose_time=sysdate,t.isreply='2'";
                //        int num = App.ExecuteSQL(update);
                //        if (num > 0)
                //        {
                //            App.Msg("ȷ�ϳɹ���");
                //            GetMessage();

                //        }
                //        else
                //        {
                //            App.Msg("ȷ��ʧ�ܣ�");
                //        }
                //    }
                //    else
                //    {
                //        App.Msg("������Ϣ����Ҫ����������");
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
        /// ˫���鿴��Ϣ����ϸ��Ϣ (δ������)   ��Ϣ�������ѵ�Ӧ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMsgInfoNew_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvMsgInfoNew.Rows.Count > 0)
                {
                    if (dgvMsgInfoNew.CurrentRow.Cells["�ظ�"].Value.ToString() == "��Ҫ����" || dgvMsgInfoNew.CurrentRow.Cells["�ظ�"].Value.ToString() == "����Ҫ")
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
                        App.Msg("��ǰ��Ϣû�в鿴��ϸ��Ϣ���ܣ�");
                        return;
                    }
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// ˫���鿴��Ϣ����ϸ��Ϣ (δ������)   ��Ϣ�������ѵ�Ӧ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMsgInfoNewReaded_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvMsgInfoNewReaded.Rows.Count > 0)
                {
                    if (dgvMsgInfoNewReaded.CurrentRow.Cells["�ظ�"].Value.ToString() == "��Ҫ����" || dgvMsgInfoNewReaded.CurrentRow.Cells["�ظ�"].Value.ToString() == "����Ҫ")
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
                        App.Msg("��ǰ��Ϣû�в鿴��ϸ��Ϣ���ܣ�");
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
