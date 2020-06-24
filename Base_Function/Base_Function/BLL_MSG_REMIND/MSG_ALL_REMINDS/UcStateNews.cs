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
    public partial class UcStateNews : UserControl
    {
        public UcStateNews()
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
        /// 获取状态提醒消息
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoState.Columns.Clear();
            dgvMsgInfoStateReaded.Columns.Clear();

            //状态提醒内容
            string sqlMsg = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 状态提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='状态提醒' and t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='10' and  m.msg_status=0 "+
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            string sqlMsgReaded = "select distinct( m.id),p.patient_name 患者姓名,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,m.type_name 状态提醒类型," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='状态提醒' and t.WARN_TYPE = m.WARN_TYPE and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='10' and  m.msg_status=1 "+
                "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
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
                //状态提醒内容

                DataGridViewCheckBoxColumn cBox_zt = new DataGridViewCheckBoxColumn();
                cBox_zt.HeaderText = "选择";
                cBox_zt.Name = "select";
                dgvMsgInfoState.Columns.Insert(0, cBox_zt);
                dgvMsgInfoState.Columns["select"].ReadOnly = false;

                dgvMsgInfoState.DataSource = dsPatient.Tables["newMsg"];

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "状态提醒未读信息" + "(" + n_newMsg + ")";
                }

                dgvMsgInfoState.Columns["id"].Visible = false;
                dgvMsgInfoState.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfoStateReaded.DataSource = dsPatient.Tables["newMsgReaded"];
                dgvMsgInfoStateReaded.Columns["id"].Visible = false;
                dgvMsgInfoStateReaded.Columns["sick_doctor_id"].Visible = false;

                dgvMsgInfoState.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["状态提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoState.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvMsgInfoState.Columns["提醒内容"].Width = 250;
                dgvMsgInfoState.Columns[11].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoState.AutoResizeRows();
                dgvMsgInfoState.Refresh();

                dgvMsgInfoStateReaded.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["状态提醒类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoStateReaded.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 已读界面的提醒内容
                dgvMsgInfoStateReaded.Columns["提醒内容"].Width = 250;
                dgvMsgInfoStateReaded.Columns[10].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoStateReaded.AutoResizeRows();
                dgvMsgInfoStateReaded.Refresh();
            }

        }

        private void UcStateNews_Load(object sender, EventArgs e)
        {
            try
            {
                //设定包括Header和所有单元格的列宽自动调整 
                //dgvMsgInfoState.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvMsgInfoStateReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                GetMessage();
            }
            catch
            {
            }
        }

        private void UcStateNews_SizeChanged(object sender, EventArgs e)
        {

        }

        private void btnMakeSure_Click_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQR_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            string strId = "";
            for (int i = 0; i < dgvMsgInfoState.Rows.Count; i++)
            {
                if (dgvMsgInfoState.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                {
                    strId = dgvMsgInfoState.Rows[i].Cells["id"].Value.ToString();
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

        }

        private void tabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {

            try
            {
                dgvMsgInfoState.AutoResizeRows();
                dgvMsgInfoState.Refresh();
                dgvMsgInfoStateReaded.AutoResizeRows();
                dgvMsgInfoStateReaded.Refresh();
                if (tabControl1.SelectedTab == tabItem7)
                {
                    this.buttonX1.Visible = false;
                    this.btnRefurbish.Visible = false;

                }
                else
                {
                    this.buttonX1.Visible = true;
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
