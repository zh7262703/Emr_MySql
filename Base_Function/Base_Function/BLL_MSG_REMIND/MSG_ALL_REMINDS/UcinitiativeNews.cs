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
    public partial class UcinitiativeNews : UserControl
    {
        public UcinitiativeNews()
        {
            InitializeComponent();
        }

        private void btnSure_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        /// <summary>
        /// 获取检验提醒消息
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfo.Columns.Clear();
            dgvMsgInfoReaded.Columns.Clear();

            dgvHistoryMsg.Columns.Clear();
            dgvHistoryMsgReaded.Columns.Clear();

            dgvCrisisValue.Columns.Clear();
            dgvCrisisValueReaded.Columns.Clear();
            //检验报告提醒内容
            string sqlMsg = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 检验提醒类型,m.TYPE_Name_CY 检验报告提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='检验报告' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='5' and  m.msg_status=0 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id+"' order by 发送时间  desc";
            string sqlMsgReaded = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 检验提醒类型,m.TYPE_Name_CY 检验报告提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='检验报告' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='5' and  m.msg_status=1 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            //非正常值提醒内容
            string sqlHistoryMsg = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 检验提醒类型,m.TYPE_Name_CY 非正常值提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='非正常值' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='6' and  m.msg_status=0 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            string sqlHistoryMsgReaded = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 检验提醒类型,m.TYPE_Name_CY 非正常值提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='非正常值' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='6' and  m.msg_status=1 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            //危机值提醒内容
            string sqlWJMsg = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 检验提醒类型,m.TYPE_Name_CY 危急值提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='危机值' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='7' and  m.msg_status=0 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            string sqlWJMsgReaded = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 检验提醒类型,m.TYPE_Name_CY 危急值提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='危机值' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='7' and  m.msg_status=1 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            Class_Table[] tab = new Class_Table[6];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sqlMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "historyMsg";
            tab[1].Sql = sqlHistoryMsg;

            tab[2] = new Class_Table();
            tab[2].Tablename = "WJMsg";
            tab[2].Sql = sqlWJMsg;

            tab[3] = new Class_Table();
            tab[3].Tablename = "newMsgReaded";
            tab[3].Sql = sqlMsgReaded;

            tab[4] = new Class_Table();
            tab[4].Tablename = "historyMsgReaded";
            tab[4].Sql = sqlHistoryMsgReaded;

            tab[5] = new Class_Table();
            tab[5].Tablename = "WJMsgReaded";
            tab[5].Sql = sqlWJMsgReaded;

            DataSet dsPatient = App.GetDataSet(tab);
            if (dsPatient != null)
            {
                DataGridViewCheckBoxColumn cBox_jybg = new DataGridViewCheckBoxColumn();
                cBox_jybg.HeaderText = "选择";
                cBox_jybg.Name = "select";
                dgvMsgInfo.Columns.Insert(0, cBox_jybg);
                dgvMsgInfo.Columns["select"].ReadOnly = false;

                //检验报告提醒内容
                dgvMsgInfo.DataSource = dsPatient.Tables["newMsg"];
                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem24.Text = "检验报告未读信息" + "(" + n_newMsg + ")";
                }
                dgvMsgInfo.Columns["id"].Visible = false;
                dgvMsgInfo.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfoReaded.DataSource = dsPatient.Tables["newMsgReaded"];
                dgvMsgInfoReaded.Columns["id"].Visible = false;
                dgvMsgInfoReaded.Columns["sick_doctor_id"].Visible = false;


                DataGridViewCheckBoxColumn cBox_fzcz = new DataGridViewCheckBoxColumn();
                cBox_fzcz.HeaderText = "选择";
                cBox_fzcz.Name = "select";
                dgvHistoryMsg.Columns.Insert(0, cBox_fzcz);
                dgvHistoryMsg.Columns["select"].ReadOnly = false;

                //非正常值提醒内容
                dgvHistoryMsg.DataSource = dsPatient.Tables["historyMsg"];

                int n_historyMsg = dsPatient.Tables["historyMsg"].Rows.Count;
                if (n_historyMsg >= 0)
                {
                    tabItem25.Text = "非正常值未读信息 (" + n_historyMsg + ")";
                }

                dgvHistoryMsg.Columns["id"].Visible = false;
                dgvHistoryMsg.Columns["sick_doctor_id"].Visible = false;

                dgvHistoryMsgReaded.DataSource = dsPatient.Tables["historyMsgReaded"];
                dgvHistoryMsgReaded.Columns["id"].Visible = false;
                dgvHistoryMsgReaded.Columns["sick_doctor_id"].Visible = false;

                DataGridViewCheckBoxColumn cBox_wjz = new DataGridViewCheckBoxColumn();
                cBox_wjz.HeaderText = "选择";
                cBox_wjz.Name = "select";
                dgvCrisisValue.Columns.Insert(0, cBox_wjz);
                dgvCrisisValue.Columns["select"].ReadOnly = false;

                //危机值提醒内容
                dgvCrisisValue.DataSource = dsPatient.Tables["WJMsg"];

                int n_WJMsg = dsPatient.Tables["WJMsg"].Rows.Count;
                if (n_WJMsg >= 0)
                {
                    tabItem1.Text = "危机值未读信息 (" + n_WJMsg + ")";
                }

                dgvCrisisValue.Columns["id"].Visible = false;
                dgvCrisisValue.Columns["sick_doctor_id"].Visible = false;
                dgvCrisisValueReaded.DataSource = dsPatient.Tables["WJMsgReaded"];
                dgvCrisisValueReaded.Columns["id"].Visible = false;
                dgvCrisisValueReaded.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfo.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["检验提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["检验报告提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfo.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvMsgInfo.Columns["提醒内容"].Width = 250;
                dgvMsgInfo.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfo.AutoResizeRows();
                dgvMsgInfo.Refresh();

                dgvMsgInfoReaded.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["检验提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["检验报告提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoReaded.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 已读界面的提醒内容
                dgvMsgInfoReaded.Columns["提醒内容"].Width = 250;
                dgvMsgInfoReaded.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoReaded.AutoResizeRows();
                dgvMsgInfoReaded.Refresh();

                dgvHistoryMsg.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["检验提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["非正常值提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsg.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvHistoryMsg.Columns["提醒内容"].Width = 250;
                dgvHistoryMsg.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsg.AutoResizeRows();
                dgvHistoryMsg.Refresh();

                dgvHistoryMsgReaded.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["检验提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["非正常值提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgReaded.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 已读界面的提醒内容
                dgvHistoryMsgReaded.Columns["提醒内容"].Width = 250;
                dgvHistoryMsgReaded.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgReaded.AutoResizeRows();
                dgvHistoryMsgReaded.Refresh();

                dgvCrisisValue.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["检验提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["危急值提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValue.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvCrisisValue.Columns["提醒内容"].Width = 250;
                dgvCrisisValue.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvCrisisValue.AutoResizeRows();
                dgvCrisisValue.Refresh();

                dgvCrisisValueReaded.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["检验提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["危急值提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvCrisisValueReaded.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 已读界面的提醒内容
                dgvCrisisValueReaded.Columns["提醒内容"].Width = 250;
                dgvCrisisValueReaded.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvCrisisValueReaded.AutoResizeRows();
                dgvCrisisValueReaded.Refresh();
            }

        }

        private void UcinitiativeNews_Load(object sender, EventArgs e)
        {
            try
            {
                // 设定包括Header和所有单元格的列宽自动调整 
                //dgvMsgInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvHistoryMsg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvCrisisValue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvMsgInfoReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvHistoryMsgReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvCrisisValueReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                GetMessage();
            }
            catch
            {
            }
        }

        private void UcinitiativeNews_SizeChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 确认  --医生操作功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<string> sqls = new List<string>();
                string strId = "";
                if (tabControl3.SelectedTab == tabItem24)//检验报告提醒
                {
                    for (int i = 0; i < dgvMsgInfo.Rows.Count; i++)
                    {
                        if (dgvMsgInfo.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                        {
                            strId = dgvMsgInfo.Rows[i].Cells["id"].Value.ToString();
                            string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                            sqls.Add(strSql);
                        }
                    }
                    if (sqls.Count>0)
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
                    //if (dgvMsgInfo.CurrentCell != null)
                    //{
                    //    strId = dgvMsgInfo.CurrentRow.Cells["id"].Value.ToString();
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
                else if (tabControl3.SelectedTab == tabItem25)//非正常值提醒
                {
                    for (int i = 0; i < dgvHistoryMsg.Rows.Count; i++)
                    {
                        if (dgvHistoryMsg.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                        {
                            strId = dgvHistoryMsg.Rows[i].Cells["id"].Value.ToString();
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
                    //if (dgvHistoryMsg.CurrentCell != null)
                    //{
                    //    strId = dgvHistoryMsg.CurrentRow.Cells["id"].Value.ToString();
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
                else//危机值
                {
                    for (int i = 0; i < dgvCrisisValue.Rows.Count; i++)
                    {
                        if (dgvCrisisValue.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                        {
                            strId = dgvCrisisValue.Rows[i].Cells["id"].Value.ToString();
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
                    //if (dgvCrisisValue.CurrentCell != null)
                    //{
                    //    strId = dgvCrisisValue.CurrentRow.Cells["id"].Value.ToString();
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
        /// <summary>
        /// 已读信息页签隐藏确定功能按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl3_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            try
            {
                dgvMsgInfo.AutoResizeRows();
                dgvMsgInfo.Refresh();
                dgvMsgInfoReaded.AutoResizeRows();
                dgvMsgInfoReaded.Refresh();
                dgvHistoryMsg.AutoResizeRows();
                dgvHistoryMsg.Refresh();
                dgvHistoryMsgReaded.AutoResizeRows();
                dgvHistoryMsgReaded.Refresh();
                dgvCrisisValue.AutoResizeRows();
                dgvCrisisValue.Refresh();
                dgvCrisisValueReaded.AutoResizeRows();
                dgvCrisisValueReaded.Refresh();
                if (tabControl3.SelectedTab == tabItem2 || tabControl3.SelectedTab == tabItem3 || tabControl3.SelectedTab == tabItem4)
                {
                    this.btnOK.Visible = false;
                    this.btnRefurbish.Visible = false;

                }
                else
                {
                    this.btnOK.Visible = true;
                    this.btnRefurbish.Visible = true;
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
    }
}
