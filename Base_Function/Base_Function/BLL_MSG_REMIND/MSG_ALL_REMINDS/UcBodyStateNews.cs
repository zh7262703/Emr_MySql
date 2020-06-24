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
    public partial class UcBodyStateNews : UserControl
    {
        public UcBodyStateNews()
        {
            InitializeComponent();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
          
        }

        private void btnMakeSure_Click(object sender, EventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        /// <summary>
        /// ��ȡ����������Ϣ
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoNew.Columns.Clear();
            dgvMsgInfoNewReaded.Columns.Clear();

            dgvHistoryMsgNew.Columns.Clear();
            dgvHistoryMsgNewReaded.Columns.Clear();
            //������������
            string sqlMsg = "select distinct( m.id),p.patient_name ��������,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name ������������,m.TYPE_Name_CY ����������������," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='��������' and t.WARN_TYPE = m.WARN_TYPE and   m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='11' and  m.msg_status=0 "+
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            string sqlMsgReaded = "select distinct( m.id),p.patient_name ��������,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name ������������,m.TYPE_Name_CY ����������������," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='��������' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='11' and  m.msg_status=1 "+
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            //����������ֵ����
            string sqlHistoryMsg = "select distinct( m.id),p.patient_name ��������,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name ������������,m.TYPE_Name_CY ����������ֵ��������," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                " from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag in ('����������ֵ-����','����������ֵ-����','����������ֵ-����','����������ֵ-Ѫѹ') and t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE in (12,13,14,15) and  m.msg_status=0 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            string sqlHistoryMsgReaded = "select distinct( m.id),p.patient_name ��������,p.sick_doctor_id,p.sick_doctor_name �ܴ�ҽ��,case p.gender_code when '0' then '��' else 'Ů' end �Ա�,p.age||p.age_unit ����," +
                "p.his_id,p.in_bed_no ����,p.section_name ��ǰ����,m.type_name ������������,m.TYPE_Name_CY ����������ֵ��������," +
                " m.content ��������,m.operator_user_name ������,to_char(m.add_time,'yyyy-MM-dd hh24:mi') ����ʱ�� " +
                " from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag in ('����������ֵ-����','����������ֵ-����','����������ֵ-����','����������ֵ-Ѫѹ') and t.WARN_TYPE = m.WARN_TYPE  and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE in (12,13,14,15) and  m.msg_status=1 " +
                 "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by ����ʱ��  desc";
            Class_Table[] tab = new Class_Table[4];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sqlMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "historyMsg";
            tab[1].Sql = sqlHistoryMsg;

            tab[2] = new Class_Table();
            tab[2].Tablename = "newMsgReaded";
            tab[2].Sql = sqlMsgReaded;

            tab[3] = new Class_Table();
            tab[3].Tablename = "historyMsgReaded";
            tab[3].Sql = sqlHistoryMsgReaded;

            DataSet dsPatient = App.GetDataSet(tab);
            if (dsPatient != null)
            {
                //����Ϣ

                DataGridViewCheckBoxColumn cBox_nr = new DataGridViewCheckBoxColumn();
                cBox_nr.HeaderText = "ѡ��";
                cBox_nr.Name = "select";
                dgvMsgInfoNew.Columns.Insert(0, cBox_nr);
                dgvMsgInfoNew.Columns["select"].ReadOnly = false;

                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "��������δ����Ϣ" + "(" + n_newMsg + ")";
                }

                dgvMsgInfoNew.Columns["id"].Visible = false;
                dgvMsgInfoNew.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfoNewReaded.DataSource = dsPatient.Tables["newMsgReaded"];
                dgvMsgInfoNewReaded.Columns["id"].Visible = false;
                dgvMsgInfoNewReaded.Columns["sick_doctor_id"].Visible = false;
               

                //��ʷ��Ϣ

                DataGridViewCheckBoxColumn cBox_fzcz = new DataGridViewCheckBoxColumn();
                cBox_fzcz.HeaderText = "ѡ��";
                cBox_fzcz.Name = "select";
                dgvHistoryMsgNew.Columns.Insert(0, cBox_fzcz);
                dgvHistoryMsgNew.Columns["select"].ReadOnly = false;

                dgvHistoryMsgNew.DataSource = dsPatient.Tables["historyMsg"];

                int n_historyMsg = dsPatient.Tables["historyMsg"].Rows.Count;
                if (n_historyMsg >= 0)
                {
                    tabItem2.Text = "����������ֵδ����Ϣ (" + n_historyMsg + ")";
                }

                dgvHistoryMsgNew.Columns["id"].Visible = false;
                dgvHistoryMsgNew.Columns["sick_doctor_id"].Visible = false;

                dgvHistoryMsgNewReaded.DataSource = dsPatient.Tables["historyMsgReaded"];
                dgvHistoryMsgNewReaded.Columns["id"].Visible = false;
                dgvHistoryMsgNewReaded.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfoNew.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�ܴ�ҽ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["������������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����������������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ δ���������������
                dgvMsgInfoNew.Columns["��������"].Width = 250;
                dgvMsgInfoNew.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();

                dgvMsgInfoNewReaded.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["�ܴ�ҽ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["������������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����������������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ �Ѷ��������������
                dgvMsgInfoNewReaded.Columns["��������"].Width = 250;
                dgvMsgInfoNewReaded.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNewReaded.AutoResizeRows();
                dgvMsgInfoNewReaded.Refresh();


                dgvHistoryMsgNew.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["�ܴ�ҽ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["������������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["����������ֵ��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ δ���������������
                dgvHistoryMsgNew.Columns["��������"].Width = 250;
                dgvHistoryMsgNew.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgNew.AutoResizeRows();
                dgvHistoryMsgNew.Refresh();

                dgvHistoryMsgNewReaded.Columns["��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["�ܴ�ҽ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["�Ա�"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["��ǰ����"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["������������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["����������ֵ��������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["������"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["����ʱ��"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //������ʾ �Ѷ��������������
                dgvHistoryMsgNewReaded.Columns["��������"].Width = 250;
                dgvHistoryMsgNewReaded.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgNewReaded.AutoResizeRows();
                dgvHistoryMsgNewReaded.Refresh();

            }

        }

        private void UcBodyStateNews_Load(object sender, EventArgs e)
        {
            try
            {
                // �趨����Header�����е�Ԫ����п��Զ����� 
                //dgvMsgInfoNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvHistoryMsgNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvMsgInfoNewReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvHistoryMsgNewReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                GetMessage();
            }
            catch
            {
            }
        }

        private void UcBodyStateNews_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnMakeSure_Click_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// ȷ�Ϲ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQR_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<string> sqls = new List<string>();
                string strId = "";
                if (tabControl1.SelectedTab==tabItem1)
                {
                    for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                    {
                        if (dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                        {
                            strId = dgvMsgInfoNew.Rows[i].Cells["id"].Value.ToString();
                            string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                            sqls.Add(strSql);
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
                        else
                        {
                            App.Msg("ȷ��ʧ�ܣ�");
                        }
                    }
                    #region ע�͵�
                    //if (dgvMsgInfoNew.CurrentCell!=null)
                    //{
                    //    strId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                    //    if (strId != "")
                    //    {
                    //        string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                    //        int num = App.ExecuteSQL(strSql);
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
                    //} 
                    #endregion
                }
                else
                {
                    for (int i = 0; i < dgvHistoryMsgNew.Rows.Count; i++)
                    {
                        if (dgvHistoryMsgNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                        {
                            strId = dgvHistoryMsgNew.Rows[i].Cells["id"].Value.ToString();
                            string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                            sqls.Add(strSql);
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
                        else
                        {
                            App.Msg("ȷ��ʧ�ܣ�");
                        }
                    }
                    #region ע�͵�
                    //if (dgvHistoryMsgNew.CurrentCell!=null)
                    //{
                    //    strId = dgvHistoryMsgNew.CurrentRow.Cells["id"].Value.ToString();
                    //    if (strId != "")
                    //    {
                    //        string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                    //        int num = App.ExecuteSQL(strSql);
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
                    //} 
                    #endregion
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

        private void tabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            try
            {
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();
                dgvMsgInfoNewReaded.AutoResizeRows();
                dgvMsgInfoNewReaded.Refresh();
                dgvHistoryMsgNew.AutoResizeRows();
                dgvHistoryMsgNew.Refresh();
                dgvHistoryMsgNewReaded.AutoResizeRows();
                dgvHistoryMsgNewReaded.Refresh();
                if (tabControl1.SelectedTab == tabItem3 || tabControl1.SelectedTab == tabItem4)
                {
                    this.btnQR.Visible = false;
                    this.btnRefurbish.Visible = false;
                }
                else
                {
                    this.btnQR.Visible = true;
                    this.btnRefurbish.Visible = true;
                }
            }
            catch
            {

            }
        }

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
    }
}
