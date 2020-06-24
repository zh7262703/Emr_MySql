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
        /// 获取体征提醒消息
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoNew.Columns.Clear();
            dgvMsgInfoNewReaded.Columns.Clear();

            dgvHistoryMsgNew.Columns.Clear();
            dgvHistoryMsgNewReaded.Columns.Clear();
            //体征内容提醒
            string sqlMsg = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 体征提醒类型,m.TYPE_Name_CY 体征内容提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='体征内容' and t.WARN_TYPE = m.WARN_TYPE and   m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='11' and  m.msg_status=0 "+
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            string sqlMsgReaded = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 体征提醒类型,m.TYPE_Name_CY 体征内容提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='体征内容' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='11' and  m.msg_status=1 "+
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            //体征非正常值提醒
            string sqlHistoryMsg = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 体征提醒类型,m.TYPE_Name_CY 体征非正常值提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                " from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag in ('体征非正常值-体温','体征非正常值-脉搏','体征非正常值-呼吸','体征非正常值-血压') and t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE in (12,13,14,15) and  m.msg_status=0 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            string sqlHistoryMsgReaded = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 体征提醒类型,m.TYPE_Name_CY 体征非正常值提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                " from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag in ('体征非正常值-体温','体征非正常值-脉搏','体征非正常值-呼吸','体征非正常值-血压') and t.WARN_TYPE = m.WARN_TYPE  and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE in (12,13,14,15) and  m.msg_status=1 " +
                 "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
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
                //新消息

                DataGridViewCheckBoxColumn cBox_nr = new DataGridViewCheckBoxColumn();
                cBox_nr.HeaderText = "选择";
                cBox_nr.Name = "select";
                dgvMsgInfoNew.Columns.Insert(0, cBox_nr);
                dgvMsgInfoNew.Columns["select"].ReadOnly = false;

                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "体征内容未读信息" + "(" + n_newMsg + ")";
                }

                dgvMsgInfoNew.Columns["id"].Visible = false;
                dgvMsgInfoNew.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfoNewReaded.DataSource = dsPatient.Tables["newMsgReaded"];
                dgvMsgInfoNewReaded.Columns["id"].Visible = false;
                dgvMsgInfoNewReaded.Columns["sick_doctor_id"].Visible = false;
               

                //历史消息

                DataGridViewCheckBoxColumn cBox_fzcz = new DataGridViewCheckBoxColumn();
                cBox_fzcz.HeaderText = "选择";
                cBox_fzcz.Name = "select";
                dgvHistoryMsgNew.Columns.Insert(0, cBox_fzcz);
                dgvHistoryMsgNew.Columns["select"].ReadOnly = false;

                dgvHistoryMsgNew.DataSource = dsPatient.Tables["historyMsg"];

                int n_historyMsg = dsPatient.Tables["historyMsg"].Rows.Count;
                if (n_historyMsg >= 0)
                {
                    tabItem2.Text = "体征非正常值未读信息 (" + n_historyMsg + ")";
                }

                dgvHistoryMsgNew.Columns["id"].Visible = false;
                dgvHistoryMsgNew.Columns["sick_doctor_id"].Visible = false;

                dgvHistoryMsgNewReaded.DataSource = dsPatient.Tables["historyMsgReaded"];
                dgvHistoryMsgNewReaded.Columns["id"].Visible = false;
                dgvHistoryMsgNewReaded.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfoNew.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["体征提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["体征内容提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvMsgInfoNew.Columns["提醒内容"].Width = 250;
                dgvMsgInfoNew.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();

                dgvMsgInfoNewReaded.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["体征提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["体征内容提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 已读界面的提醒内容
                dgvMsgInfoNewReaded.Columns["提醒内容"].Width = 250;
                dgvMsgInfoNewReaded.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNewReaded.AutoResizeRows();
                dgvMsgInfoNewReaded.Refresh();


                dgvHistoryMsgNew.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["体征提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["体征非正常值提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvHistoryMsgNew.Columns["提醒内容"].Width = 250;
                dgvHistoryMsgNew.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgNew.AutoResizeRows();
                dgvHistoryMsgNew.Refresh();

                dgvHistoryMsgNewReaded.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["体征提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["体征非正常值提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNewReaded.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 已读界面的提醒内容
                dgvHistoryMsgNewReaded.Columns["提醒内容"].Width = 250;
                dgvHistoryMsgNewReaded.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgNewReaded.AutoResizeRows();
                dgvHistoryMsgNewReaded.Refresh();

            }

        }

        private void UcBodyStateNews_Load(object sender, EventArgs e)
        {
            try
            {
                // 设定包括Header和所有单元格的列宽自动调整 
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
        /// 确认功能
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
                            App.Msg("确认成功！");
                            GetMessage();
                        }
                        else
                        {
                            App.Msg("确认失败！");
                        }
                    }
                    #region 注释掉
                    //if (dgvMsgInfoNew.CurrentCell!=null)
                    //{
                    //    strId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                    //    if (strId != "")
                    //    {
                    //        string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                    //        int num = App.ExecuteSQL(strSql);
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
                            App.Msg("确认成功！");
                            GetMessage();
                        }
                        else
                        {
                            App.Msg("确认失败！");
                        }
                    }
                    #region 注释掉
                    //if (dgvHistoryMsgNew.CurrentCell!=null)
                    //{
                    //    strId = dgvHistoryMsgNew.CurrentRow.Cells["id"].Value.ToString();
                    //    if (strId != "")
                    //    {
                    //        string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                    //        int num = App.ExecuteSQL(strSql);
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
