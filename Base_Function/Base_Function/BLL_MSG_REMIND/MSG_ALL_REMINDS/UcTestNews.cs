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
    public partial class UcTestNews : UserControl
    {
        public UcTestNews()
        {
            InitializeComponent();
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            if (dgvMsgInfoNew.Rows.Count > 0)
            {
                int strCount = 0;
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                    {
                        strCount = strCount + 1;
                        if (strCount > 1)
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
            #region 注释掉
            //if (dgvMsgInfoNew.CurrentCell!=null)
            //{
            //    string msgIds = "";
            //    if (dgvMsgInfoNew.CurrentRow.Cells["回复"].Value.ToString() == "是")
            //    {
            //        msgIds = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
            //    }
            //    if (msgIds != "")
            //    {
            //        frmMsgReplay frmR = new frmMsgReplay(msgIds);
            //        frmR.ShowDialog();
            //        if (frmR.flag)
            //        {
            //            GetMessage();
            //        }
            //    }
            //    else
            //    {
            //        App.Msg("请选择需要回复的消息！");
            //    } 
            //} 
            #endregion
        }

        private void btnMakeSure_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                List<string> sqls = new List<string>();
                string strId = "";
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["回复"].Value.ToString() != "是" && dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                    {
                        strId = dgvMsgInfoNew.Rows[i].Cells["id"].Value.ToString();
                        string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
                        sqls.Add(strSql);
                    }
                    if (dgvMsgInfoNew.Rows[i].Cells["回复"].Value.ToString() == "是" && dgvMsgInfoNew.Rows[i].Cells["select"].EditedFormattedValue.ToString() == "True")
                    {
                        App.Msg("当前选中的消息中含有需要回复的消息，请重新操作！");
                        return;
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
                //    string msgId = "";
                //    if (dgvMsgInfoNew.CurrentRow.Cells["回复"].Value.ToString() != "是")
                //    {
                //        msgId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
                //        if (msgId != "")
                //        {
                //            string update = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate,flag='true' where id ='" + msgId + "'";
                //            int num = App.ExecuteSQL(update);
                //            if (num > 0)
                //            {
                //                App.Msg("确认成功！");
                //                GetMessage();

                //            }
                //            else
                //            {
                //                App.Msg("确认失败！");
                //            }
                //        }
                //    }
                //    else
                //    {
                //        App.Msg("只有不需要回复的消息才有此确认操作！");
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
            //新消息
            string sqlMsg = @"select distinct( m.id),
                                   m.isreply 回复,
                                   p.patient_name 患者姓名,
                                   p.in_doctor_name 管床医生,
                                   case p.gender_code
                                     when '0' then
                                      '男'
                                     else
                                      '女'
                                   end 性别,
                                   p.age || p.age_unit 年龄,
                                   p.his_id,
                                   p.in_bed_no 床号,
                                   p.section_name 当前病区,
                                   m.type_name 消息类型,
                                   m.content 消息内容,
                                   m.operator_user_name 发布人,
                                   to_char(m.add_time, 'yyyy-MM-dd hh24:mi') 发布时间
                              from T_MSG_INFO m, t_in_patient p, t_msg_setting t
                             where m.pid = p.id
                               and t.WARN_TYPE = m.WARN_TYPE
                               and m.WARN_TYPE in (1,2)
                               and t.MSG_START_UP = '1'
                               and flag = 'true'
                               and msg_status = '0'
                               and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发布时间  desc";
            //查询一周内的已读消息
            string sqlHistoryMsg = "select distinct( m.id), m.patient_name 患者姓名,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区,type_name 消息类型,content 消息内容,to_char(add_time,'yyyy-MM-dd hh24:mi:ss') 发布时间,operator_user_name 发布人,to_char(dispose_time,'yyyy-MM-dd hh24:mi:ss') 确认时间,reply_msg 回复内容 " +
                                    "from t_msg_info m , t_in_patient p ,t_msg_setting t " +
                                    "where  m.pid=p.id and t.WARN_TYPE = m.WARN_TYPE and t.MSG_START_UP='1' and  m.WARN_TYPE in (1,2) " +
                                    "and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0  and  receive_user_id=" + App.UserAccount.UserInfo.User_id + " and dispose_time>(sysdate-7) order by 发布时间 desc";
            Class_Table[] tab = new Class_Table[2];
            tab[0] = new Class_Table();
            tab[0].Tablename = "newMsg";
            tab[0].Sql = sqlMsg;

            tab[1] = new Class_Table();
            tab[1].Tablename = "historyMsg";
            tab[1].Sql = sqlHistoryMsg;

            DataSet dsPatient = App.GetDataSet(tab);
            if (dsPatient != null)
            {
                //新消息
                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];

                DataGridViewCheckBoxColumn cBox_zd = new DataGridViewCheckBoxColumn();
                cBox_zd.HeaderText = "选择";
                cBox_zd.Name = "select";
                dgvMsgInfoNew.Columns.Insert(0, cBox_zd);
                dgvMsgInfoNew.Columns["select"].ReadOnly = false;

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "新的消息" + "(" + n_newMsg + ")";
                }
                dgvMsgInfoNew.Columns["id"].Visible = false;

                DataGridViewCheckBoxColumn cBox = new DataGridViewCheckBoxColumn();
                cBox.HeaderText = "回复";
                cBox.Name = "replay";
                dgvMsgInfoNew.Columns.Insert(0, cBox);
                dgvMsgInfoNew.Columns["replay"].ReadOnly = true;
                dgvMsgInfoNew.Columns["replay"].Visible = false;


                //历史消息
                dgvHistoryMsgNew.DataSource = dsPatient.Tables["historyMsg"];
                dgvHistoryMsgNew.Columns["id"].Visible = false;
                //默认回复字段是否选中
                for (int i = 0; i < dgvMsgInfoNew.Rows.Count; i++)
                {
                    if (dgvMsgInfoNew.Rows[i].Cells["回复"].Value.ToString() == "1")
                    {

                        dgvMsgInfoNew.Rows[i].Cells["回复"].Value = "是";
                    }
                    else
                    {
                        dgvMsgInfoNew.Rows[i].Cells["回复"].Value = "否";
                    }
                }

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
                dgvMsgInfoNew.Columns["发布人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["发布时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvMsgInfoNew.Columns["消息内容"].Width = 250;
                dgvMsgInfoNew.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();

                dgvHistoryMsgNew.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["消息类型"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["发布人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["发布时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvHistoryMsgNew.Columns["确认时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 已读界面的提醒内容
                dgvHistoryMsgNew.Columns["消息内容"].Width = 200;
                dgvHistoryMsgNew.Columns[8].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgNew.Columns["回复内容"].Width = 200;
                dgvHistoryMsgNew.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvHistoryMsgNew.AutoResizeRows();
                dgvHistoryMsgNew.Refresh();
            }

        }

        private void UcTestNews_Load(object sender, EventArgs e)
        {
            try
            {
                // 设定包括Header和所有单元格的列宽自动调整 
                //dgvMsgInfoNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvHistoryMsgNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                GetMessage();
                tabItem2_Click(null,null);
            }
            catch
            {
            }
        }

        private void UcTestNews_SizeChanged(object sender, EventArgs e)
        {
            int x = btnReply.Parent.Size.Width / 2 - btnReply.Size.Width;
            btnReply.Location = new Point(x, btnReply.Location.Y);
            btnRefurbish.Location = new Point(btnReply.Location.X + 100, btnRefurbish.Location.Y);
            btnMakeSure.Location = new Point(btnReply.Location.X - 100, btnMakeSure.Location.Y);
        }

        private void btnMakeSure_Click_1(object sender, EventArgs e)
        {

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

        private void tabItem2_Click(object sender, EventArgs e)
        {
            dgvMsgInfoNew.AutoResizeRows();
            dgvMsgInfoNew.Refresh();
            dgvHistoryMsgNew.AutoResizeRows();
            dgvHistoryMsgNew.Refresh();
        }
    }
}
