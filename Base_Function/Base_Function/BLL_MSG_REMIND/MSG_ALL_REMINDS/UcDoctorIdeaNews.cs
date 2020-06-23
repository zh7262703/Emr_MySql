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
    public partial class UcDoctorIdeaNews : UserControl
    {
        public UcDoctorIdeaNews()
        {
            InitializeComponent();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            string msgIds = "";
            DataGridViewCheckBoxCell cell = dgvMsgInfoNew.CurrentRow.Cells["replay"] as DataGridViewCheckBoxCell;
            if (cell != null && cell.EditedFormattedValue.ToString() == "True")
            {
                msgIds = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
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
                App.Msg("请选择需要回复的消息！");
            }
        }

        private void btnMakeSure_Click(object sender, EventArgs e)
        {
          
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //this.Close();
        }
        /// <summary>
        /// 获取未读的主动提醒消息
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoNew.Columns.Clear();
            dgvHistoryMsgNew.Columns.Clear();
            string sqlMsg = "select distinct(m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name pacs检查报告类型,m.TYPE_Name_CY 检查报告提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='检查报告' and  t.WARN_TYPE = m.WARN_TYPE  and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='16' and  m.msg_status=0 " +
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            string sqlMsgReaded = "select distinct(m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name pacs检查报告类型,m.TYPE_Name_CY 检查报告提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='检查报告' and t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='16' and  m.msg_status=1 " +
               " and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            Class_Table[] tab = new Class_Table[2];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sqlMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "historyMsg";
            tab[1].Sql = sqlMsgReaded;

            DataSet dsPatient = App.GetDataSet(tab);
            if (dsPatient != null)
            {
                //新消息

                DataGridViewCheckBoxColumn cBox_yz = new DataGridViewCheckBoxColumn();
                cBox_yz.HeaderText = "选择";
                cBox_yz.Name = "select";
                dgvMsgInfoNew.Columns.Insert(0, cBox_yz);
                dgvMsgInfoNew.Columns["select"].ReadOnly = false;

                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];
                dgvMsgInfoNew.Columns["id"].Visible = false;

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "医嘱提醒未读信息" + "(" + n_newMsg + ")";
                }

                //历史消息
                dgvHistoryMsgNew.DataSource = dsPatient.Tables["historyMsg"];
                dgvHistoryMsgNew.Columns["id"].Visible = false;
            }

        }

        private void UcDoctorIdeaNews_Load(object sender, EventArgs e)
        {
            try
            {
                // 设定包括Header和所有单元格的列宽自动调整 
                dgvMsgInfoNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvHistoryMsgNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //GetMessage();  
                //MessageBox.Show("由于医嘱提醒功能需求还需要完善，暂时不开发！");
            }
            catch
            {
            }
        }
        private void UcDoctorIdeaNews_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnMakeSure_Click_1(object sender, EventArgs e)
        {

        }
    }
}
