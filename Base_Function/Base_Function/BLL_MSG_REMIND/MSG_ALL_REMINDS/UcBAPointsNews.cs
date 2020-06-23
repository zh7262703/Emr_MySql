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
    public partial class UcBAPointsNews : UserControl
    {
        public UcBAPointsNews()
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
        /// 获取病案评分提醒消息
        /// </summary>
        private void GetMessage()
        {
            dgvMsgInfoNew.Columns.Clear();
            dgvMsgInfoNewReaded.Columns.Clear();
            //病案评分提醒内容
            string sqlMsg = "select distinct( m.id),p.patient_name 患者姓名,p.pid 住院号,m.pid,m.add_time,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='病案评分' and  t.WARN_TYPE = m.WARN_TYPE and  m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='17' and  m.msg_status=0 "+
                " and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0   and receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            
            string sqlMsgReaded = "select distinct( m.id),p.patient_name 患者姓名,p.pid 住院号,m.pid,m.add_time,p.sick_doctor_id,p.sick_doctor_name 管床医生,case p.gender_code when '0' then '男' else '女' end 性别,p.age||p.age_unit 年龄," +
                "p.his_id,p.in_bed_no 床号,p.section_name 当前病区," +
                " m.content 提醒内容,m.operator_user_name 发送人,to_char(m.add_time,'yyyy-MM-dd hh24:mi') 发送时间 " +
                "from T_MSG_INFO m, t_in_patient p, t_msg_setting t  where m.flag='病案评分' and t.WARN_TYPE = m.WARN_TYPE  and m.pid=p.id and t.MSG_START_UP = '1' and  m.WARN_TYPE='17' and  m.msg_status=1 and  to_char(sysdate,'dd')-to_char(m.add_time,'dd')< 15 "+
               " and (select count(*) from t_msg_setting_section where WARN_TYPE=m.WARN_TYPE and section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + ")>0   and receive_user_id='" + App.UserAccount.UserInfo.User_id + "' order by 发送时间  desc";
            
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
                //病案评分提醒内容
                dgvMsgInfoNew.DataSource = dsPatient.Tables["newMsg"];

                DataGridViewCheckBoxColumn cBox = new DataGridViewCheckBoxColumn();
                cBox.HeaderText = "选择";
                cBox.Name = "select";
                dgvMsgInfoNew.Columns.Insert(0, cBox);
                dgvMsgInfoNew.Columns["select"].ReadOnly = false;

                int n_newMsg = dsPatient.Tables["newMsg"].Rows.Count;
                if (n_newMsg >= 0)
                {
                    tabItem1.Text = "病案评分未读信息" + "(" + n_newMsg + ")";
                }


                dgvMsgInfoNew.Columns["id"].Visible = false;
                dgvMsgInfoNew.Columns["sick_doctor_id"].Visible = false;
                dgvMsgInfoNew.Columns["住院号"].Visible = false;
                dgvMsgInfoNew.Columns["pid"].Visible = false;
                dgvMsgInfoNew.Columns["add_time"].Visible = false;

                dgvMsgInfoNewReaded.DataSource = dsPatient.Tables["newMsgReaded"];
                dgvMsgInfoNewReaded.Columns["id"].Visible = false;
                dgvMsgInfoNewReaded.Columns["sick_doctor_id"].Visible = false;
                dgvMsgInfoNewReaded.Columns["住院号"].Visible = false;
                dgvMsgInfoNewReaded.Columns["pid"].Visible = false;
                dgvMsgInfoNewReaded.Columns["add_time"].Visible = false;


                dgvMsgInfoNew.Columns["select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["管床医生"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNew.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //dgvMsgInfoNew.Columns["扣分详情"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 未读界面的提醒内容
                dgvMsgInfoNew.Columns["提醒内容"].Width = 250;
                dgvMsgInfoNew.Columns[13].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNew.AutoResizeRows();
                dgvMsgInfoNew.Refresh();

                dgvMsgInfoNewReaded.Columns["患者姓名"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["性别"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["年龄"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["HIS_ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["床号"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["当前病区"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
              
                dgvMsgInfoNewReaded.Columns["发送人"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgvMsgInfoNewReaded.Columns["发送时间"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
               // dgvMsgInfoNewReaded.Columns["扣分详情"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //换行显示 已读界面的提醒内容
                dgvMsgInfoNewReaded.Columns["提醒内容"].Width = 250;
                dgvMsgInfoNewReaded.Columns[12].CellTemplate.Style.WrapMode = DataGridViewTriState.True;
                dgvMsgInfoNewReaded.AutoResizeRows();
                dgvMsgInfoNewReaded.Refresh();
            }

        }

        private void UcBAPointsNews_Load(object sender, EventArgs e)
        {
            try
            {
                // 设定包括Header和所有单元格的列宽自动调整 
                //dgvMsgInfoNew.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //dgvMsgInfoNewReaded.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                getKouFennDetails();
                GetMessage();
                
            }
            catch
            {
            }
        }
        /// <summary>
        /// 查看扣分详情信息
        /// </summary>
        private void getKouFennDetails()
        {
            try
            {
                DataGridViewButtonColumn cBox1 = new DataGridViewButtonColumn();
                cBox1.HeaderText = "扣分详情";
                cBox1.Name = "KouFennDetails";
                //cBox.Text = "查看";
                cBox1.DefaultCellStyle.NullValue = "查看";
                dgvMsgInfoNew.Columns.Add(cBox1);

                DataGridViewButtonColumn cBox2 = new DataGridViewButtonColumn();
                cBox2.HeaderText = "扣分详情";
                cBox2.Name = "KouFennDetails";
                //cBox.Text = "查看";
                cBox2.DefaultCellStyle.NullValue = "查看";
                dgvMsgInfoNewReaded.Columns.Add(cBox2);
            }
            catch 
            {

            }
        }

        private void UcBAPointsNews_SizeChanged(object sender, EventArgs e)
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
                    getKouFennDetails();
                }
                else
                {
                    App.Msg("确认失败！");
                }
            }
            #region 注释掉
            //if (dgvMsgInfoNew.CurrentCell!=null)
            //{
            //    string strId = dgvMsgInfoNew.CurrentRow.Cells["id"].Value.ToString();
            //    if (strId != "")
            //    {
            //        string strSql = "update t_msg_info set MSG_STATUS='1' ,dispose_time=sysdate where id ='" + strId + "'";
            //        int num = App.ExecuteSQL(strSql);
            //        if (num > 0)
            //        {
            //            App.Msg("确认成功！");
            //            GetMessage();
            //            getKouFennDetails();
            //        }
            //        else
            //        {
            //            App.Msg("确认失败！");
            //        }
            //    } 
            //} 
            #endregion
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
                getKouFennDetails();
            }
            catch 
            {
             
            }
        }
        
        private void dgvMsgInfoNew_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 查看扣分详细信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMsgInfoNew_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMsgInfoNew.Columns[e.ColumnIndex].HeaderText == "扣分详情")
                {
                    // string strZYH = dgvMsgInfoNew.CurrentRow.Cells["住院号"].Value.ToString();//住院号
                    string strID = dgvMsgInfoNew.CurrentRow.Cells["pid"].Value.ToString();//病人id

                    //string strADD_TIME = dgvMsgInfoNew.CurrentRow.Cells["add_time"].Value.ToString();//添加时间
                    if (strID != "")
                    {
                        string strZYH = App.ReadSqlVal("select pid from t_in_patient where id='" + strID + "'", 0, "pid");//通过病人id查找其对应住院号
                        if (strZYH != "")
                        {
                            Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmKouFenDetailsCheck frm = new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmKouFenDetailsCheck(strZYH);
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void dgvMsgInfoNewReaded_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMsgInfoNewReaded.Columns[e.ColumnIndex].HeaderText == "扣分详情")
                {
                   // string strZYH = dgvMsgInfoNew.CurrentRow.Cells["住院号"].Value.ToString();//住院号
                    string strID = dgvMsgInfoNewReaded.CurrentRow.Cells["pid"].Value.ToString();//病人id

                    //string strADD_TIME = dgvMsgInfoNew.CurrentRow.Cells["add_time"].Value.ToString();//添加时间
                    if (strID != "")
                    {
                        string strZYH = App.ReadSqlVal("select pid from t_in_patient where id='" + strID + "'", 0, "pid");//通过病人id查找其对应住院号
                        if (strZYH != "")
                        {
                            Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmKouFenDetailsCheck frm= new Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS.frmKouFenDetailsCheck(strZYH);
                            frm.ShowDialog();
                        }
                    }
                }
            }
            catch
            {
                
            }
        }
    }
}
