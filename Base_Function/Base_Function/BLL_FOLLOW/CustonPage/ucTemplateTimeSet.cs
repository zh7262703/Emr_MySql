using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.MODEL;

namespace Base_Function.BLL_FOLLOW.CustonPage
{
    public partial class ucTemplateTimeSet : UserControl
    {
        private DataSet ds; //显示的数据源
        private string selectedId = "";
        private int preId = -1;
        private bool IsNew = true;
        private string pId = "";
        private string sId = "";
        private string lTime = "";  //出院时间
        private string iTime = "";  //入院时间
        private string rTime = ""; //应随访时间
        private int IsLastModify = 0;//选中记录是否为最新的操作
        public DataSet Ds
        {
            get { return ds; }
            set { ds = value; }
        }
        private string recordId = "";   //记录号
        private Class_FollowInfo Info;
        private string PreVisit;
        public ucTemplateTimeSet(string param)
        {
            InitializeComponent();
            recordId = param;
            DataSet ds = App.GetDataSet("select t.patient_id,t.solution_id,p.leave_time,p.in_time,t.requested_time from T_FOLLOW_RECORD t join T_IN_PATIENT p on t.patient_id=p.id where t.id=" + recordId + "");
            if(ds!=null)
                if (ds.Tables[0].Rows.Count != 0)
                {
                    pId = ds.Tables[0].Rows[0]["patient_id"].ToString();
                    sId = ds.Tables[0].Rows[0]["solution_id"].ToString();
                    lTime = ds.Tables[0].Rows[0]["leave_time"].ToString();
                    iTime = ds.Tables[0].Rows[0]["in_time"].ToString();
                    rTime = ds.Tables[0].Rows[0]["requested_time"].ToString();
                }
            IniControls();
            DataBindState();
            ShowList();
            DataBindTimePicker();
        }
        /// <summary>
        /// 显示应随访时间
        /// </summary>
        public void DataBindTimePicker()
        {
            label4.Text = "此次随访时间：";
            dtNextTime.Value = Convert.ToDateTime(rTime);
            dtNextTime.Enabled = false;
        }
        /// <summary>
        /// 控件初始化
        /// </summary>
        public void IniControls()
        {
            Info = new Class_FollowInfo();
            PreVisit = App.ReadSqlVal("select count(*) times from T_FOLLOW_RECORD where patient_id=(select patient_id from T_FOLLOW_RECORD where id=" + recordId + ") and solution_id =(select solution_id from T_FOLLOW_RECORD where id=" + recordId + ") and id<" + recordId + "", 0, "times");
            string RelatedSchema = "select * from T_FOLLOW_INFO where id =(select solution_id from T_FOLLOW_RECORD where id=" + recordId + ")";
            DataSet temp = App.GetDataSet(RelatedSchema);
            if (temp.Tables[0].Rows.Count != 0)
            {
                Info.Id = temp.Tables[0].Rows[0]["ID"].ToString();
                Info.Defaultdays = temp.Tables[0].Rows[0]["Defaultdays"].ToString();
                Info.Definefollows = temp.Tables[0].Rows[0]["Definefollows"].ToString();
                Info.Followtype = temp.Tables[0].Rows[0]["Followtype"].ToString();
                Info.FinishType = temp.Tables[0].Rows[0]["FinishType"].ToString();
            }
            string isfinished = App.ReadSqlVal("select id from T_FOLLOW_RECORD where id="+recordId+" and isfinished=1",0,"id");
            if (isfinished != null && isfinished != "")
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;
            string isLast = App.ReadSqlVal("select id from t_follow_record where id >"+recordId+" and patient_id=" + pId + " and solution_id =" + sId + "", 0, "id");
            if (isLast != null && isLast != "")
                grpNextTimeSet.Enabled = false;
            else
                grpNextTimeSet.Enabled = true;
            if (Info.FinishType != "")
            {
                if (Info.FinishType.IndexOf("次") != -1)
                {
                    if (Convert.ToInt32(PreVisit) == (Convert.ToInt32(Info.FinishType.Substring(0, Info.FinishType.IndexOf("次"))) - 1))
                    {
                        App.Msg("已是最后一次,无法指定");
                        grpNextTimeSet.Enabled = false;
                    }
                }
                else
                {
                    DateTime Now = DateTime.Today;
                    int TimeSpan = 0;
                    if (Info.FinishType.IndexOf("年") != -1)
                    {
                        TimeSpan = Convert.ToInt32(Info.FinishType.Substring(0, Info.FinishType.IndexOf("年"))) * 365;
                    }
                    if (Info.FinishType.IndexOf("月") != -1)
                    {
                        TimeSpan = Convert.ToInt32(Info.FinishType.Substring(0, Info.FinishType.IndexOf("月"))) * 30;
                    }
                    if (Info.FinishType.IndexOf("天") != -1)
                    {
                        TimeSpan = Convert.ToInt32(Info.FinishType.Substring(0, Info.FinishType.IndexOf("天")));
                    }
                    if ((int)(Now - Convert.ToDateTime(lTime)).TotalDays > TimeSpan)
                    {
                        App.Msg("已是最后一次,无法指定");
                        grpNextTimeSet.Enabled = false;
                    }
                }
            }
            txtUser.Text = App.UserAccount.UserInfo.User_name;
            txtRemark.Text = "";                 
            rbtnOrigin.Checked = true;                       
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnUpdate.Enabled = false;

        }
        /// <summary>
        /// 随访状态绑定
        /// </summary>
        public void DataBindState()
        {
            string temp = " select * from T_FOLLOW_STATE ";
            DataSet dsTemp = App.GetDataSet(temp);
            Class_Follow_State[] State = GetStateSet(dsTemp);
            if(State.Length!=0)
                foreach (Class_Follow_State S in State)
                {
                    cmbState.Items.Add(S);
                }
            cmbState.DisplayMember = "des";
            cmbState.ValueMember = "id";

        }
        /// <summary>
        /// 获取状态实例
        /// </summary>
        /// <returns></returns>
        public Class_Follow_State[] GetStateSet(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count != 0)
            {
                Class_Follow_State[] state = new Class_Follow_State[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    state[i] = new Class_Follow_State();
                    state[i].Id = ds.Tables[0].Rows[i]["Id"].ToString();
                    state[i].Des = ds.Tables[0].Rows[i]["des"].ToString();
                    state[i].Isfinished = ds.Tables[0].Rows[i]["isfinished"].ToString();
                    
                }
                return state;
            }
            else
                return null;
        }
        /// <summary>
        /// 显示数据
        /// </summary>
        public void ShowList()
        {
            string temp = " select '' 序号,a.id 主键,a.finish_time 随访时间,a.creator_id 随访ID,b.user_name 随访者,a.state 状态号,c.des 随访状态,a.remark 备注 from T_FOLLOW_DOC_ATTACH a join T_USERINFO b on a.creator_id=b.user_id join T_FOLLOW_STATE c on a.state=c.id where a.record_id=" + recordId + " order by a.id";
            ds = App.GetDataSet(temp);
            if (ds.Tables[0].Rows.Count != 0)
            {

                dgvAttach.DataSource = ds.Tables[0].DefaultView;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    dgvAttach.Rows[i].Cells["序号"].Value = i + 1;
                dgvAttach.Columns["随访ID"].Visible = false;
                dgvAttach.Columns["状态号"].Visible = false;
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnSave_Click(object sender, EventArgs e)
        {

            string[] temp = new string[2];
            string thisTime = dtTime.Value.ToString("yyyy-MM-dd");
            if (cmbState.SelectedItem == null)
            {
                App.Msg("请选择随访状态");
                return;
            }
            Class_Follow_State state = cmbState.SelectedItem as Class_Follow_State;
            string Isfinished = "0";
            if (state.Isfinished != "")
                Isfinished = state.Isfinished;
            else
            {
                if (rbtnEnd.Checked)

                    Isfinished ="1";
                else
                    Isfinished = "0";
            }
            if (IsNew)
                temp[0] = "insert into T_FOLLOW_DOC_ATTACH(record_id,finish_time,creator_id,state,remark) values(" + recordId + ",to_date('" + thisTime + "','yyyy-MM-dd')," + App.UserAccount.UserInfo.User_id + "," + state.Id + ",'" + txtRemark.Text + "')";
            else
                temp[0] = "update T_FOLLOW_DOC_ATTACH set finish_time=to_date('" + thisTime + "','yyyy-MM-dd'),creator_id=" + App.UserAccount.UserInfo.User_id + ",state=" + state.Id + ",remark='" + txtRemark.Text + "' where id=" + selectedId + "";
            if (Isfinished == "1")
                temp[1] = "update T_FOLLOW_RECORD set actual_time=to_date('" + thisTime + "','yyyy-MM-dd'),state_id=" + state.Id + ",isfinished=" + Isfinished + " where id=" + recordId + "";
            else
            {
                if (IsLastModify == 1||dgvAttach.Rows.Count==0)
                    temp[1] = "update T_FOLLOW_RECORD set actual_time=null,state_id=" + state.Id + ",isfinished=" + Isfinished + " where id=" + recordId + "";
                else
                    temp[1] = "";
            }            
            //判断是否已完成此次随访
            string search="";
            search = App.ReadSqlVal("select finishtype from T_FOLLOW_INFO  where id =(select solution_id from T_FOLLOW_RECORD where id="+recordId+")", 0, "finishtype");
            if (Isfinished == "1")
            {
                if (search != "" && search != null)
                {

                    if (search.IndexOf("次") != -1)
                    {
                        int NowTimes = 0;
                        string tempNowTimes = App.ReadSqlVal("select count(*) 次数 from T_FOLLOW_RECORD where isfinished=1 and patient_id=" + pId + " and solution_id=" + sId + "", 0, "次数");
                        if (tempNowTimes != null && tempNowTimes != "")
                            NowTimes = Convert.ToInt32(tempNowTimes);
                        int FinishTimes = Convert.ToInt32(search.Substring(0, search.IndexOf("次")));
                        if (NowTimes == FinishTimes - 1)
                        {
                            string Exist = App.ReadSqlVal("select definefollows from T_FOLLOW_MANUALPATIENT where patient_id=" + pId + " and solution_id=" + sId + "", 0, "definifollows");
                            string AutoSet = "";

                            if (Exist != null)
                                AutoSet = "update T_FOLLOW_MANUALPATIENT set isadd=0 ,cancel_id=(select id from T_FOLLOW_CANCEL_REASON where des='完成随访'),state_id=null,update_time=to_date('" + App.GetSystemTime().ToShortDateString() + "','yyyy-MM-dd'),definefollows=null where patient_id=" + pId + " and solution_id=" + sId + "";
                            if (Exist == null)
                                AutoSet = "insert into T_FOLLOW_MANUALPATIENT(patient_id,solution_id,isadd,update_time,cancel_id) select " + pId + "," + sId + ",0,to_date('" + App.GetSystemTime().ToShortDateString() + "','yyyy-MM-dd'),id from T_FOLLOW_CANCEL_REASON where des='完成随访'";
                            App.ExecuteSQL(AutoSet);

                        }
                    }
                    else
                    {
                        TimeSpan span = Convert.ToDateTime(thisTime) - Convert.ToDateTime(lTime);
                        int totalDay = 0;
                        if (search.IndexOf("年") != -1)
                            totalDay = Convert.ToInt32(search.Substring(0, search.IndexOf("年"))) * 365;
                        if (search.IndexOf("月") != -1)
                            totalDay = Convert.ToInt32(search.Substring(0, search.IndexOf("月"))) * 30;
                        if (search.IndexOf("天") != -1)
                            totalDay = Convert.ToInt32(search.Substring(0, search.IndexOf("天")));
                        if (span.TotalDays >= totalDay)
                        {
                            string Exist = App.ReadSqlVal("select definefollows from T_FOLLOW_MANUALPATIENT where patient_id=" + pId + " and solution_id=" + sId + "", 0, "1");
                            string AutoSet = "";
                            if (Exist != null && Exist != "")
                                AutoSet = "update T_FOLLOW_MANUALPATIENT set isadd=0 ,cancel_id=(select id from T_FOLLOW_CANCEL_REASON where des='完成随访'),state_id=null,update_time=to_date('" + App.GetSystemTime().ToShortDateString() + "','yyyy-MM-dd'),definefollows=null where patient_id=" + pId + " and solution_id=" + sId + "";
                            if (Exist == null)
                                AutoSet = "insert into T_FOLLOW_MANUALPATIENT(patient_id,solution_id,isadd,update_time,cancel_id) select " + pId + "," + sId + ",0,to_date('" + App.GetSystemTime().ToShortDateString() + "','yyyy-MM-dd'),id from T_FOLLOW_CANCEL_REASON where des='完成随访'";
                            App.ExecuteSQL(AutoSet);

                        }
                    }
                }
            }
            try
            {
                App.ExecuteBatch(temp);
                App.Msg("成功");
                IniControls();
                ShowList();
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }
            

        

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string [] temp=new string[2];
            temp[0] = "delete from T_FOLLOW_DOC_ATTACH where id=" + selectedId + "";
            if (preId != -1)
            {
                if (IsLastModify == 1)
                {
                    temp[1] = "update T_FOLLOW_RECORD set state_id=" + dgvAttach.Rows[preId].Cells["状态号"].Value.ToString() + " where id=" + recordId + "";
                }
                else
                    temp[1] = "";
            }
            else
                temp[1] = "update T_FOLLOW_RECORD set actual_time=null,state_id=null where id=" + recordId + "";
            try
            {
                App.ExecuteBatch(temp);
                ShowList();
                IniControls();

            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }
        
        private void dgvAttach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex !=-1)
            {
                if (e.RowIndex == dgvAttach.Rows.Count - 1)
                    IsLastModify = 1;
                else
                    IsLastModify = 0;
                btnUpdate.Enabled = true;
                selectedId = dgvAttach.Rows[e.RowIndex].Cells["主键"].Value.ToString();
                preId = e.RowIndex - 1;
                string thisTime = dgvAttach.Rows[e.RowIndex].Cells["随访时间"].Value.ToString();
                string creator = dgvAttach.Rows[e.RowIndex].Cells["随访者"].Value.ToString();
                string state = dgvAttach.Rows[e.RowIndex].Cells["随访状态"].Value.ToString();
                string remark = dgvAttach.Rows[e.RowIndex].Cells["备注"].Value.ToString();
                FillControls(thisTime,creator,state,remark);
            }
        }
        /// <summary>
        /// 参数填充
        /// </summary>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <param name="param3"></param>
        /// <param name="param4"></param>
        public void FillControls(string param1,string param2,string param3,string param4)       
        {
            dtTime.Value = Convert.ToDateTime(param1);
            txtUser.Text = param2;
            cmbState.Text = param3;
            txtRemark.Text = param4;
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsLastModify = 1;
            btnUpdate.Enabled = false;
            IsNew = true;
            IniControls();
            
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            btnAdd.Enabled = false;
            IsNew = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IniControls();
        }

        private void rbtnThisTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnThisTime.Checked)
            {
                string RefTime;
                if (dgvAttach.Rows.Count != 0)
                {

                    RefTime = dgvAttach.Rows[dgvAttach.Rows.Count - 1].Cells["随访时间"].Value.ToString();
                }
                else
                {
                    App.Msg("暂无实际随访时间，以现在时间替代");
                    RefTime = DateTime.Today.ToShortDateString();
                }
                if (Info.Followtype != "")
                {
                    if (Info.Followtype.IndexOf("年") != -1)
                    {
                        dtNextTime.Value = Convert.ToDateTime(RefTime).AddYears(Convert.ToInt32(Info.Followtype.Substring(0, Info.Followtype.IndexOf("年"))));
                    }
                    if (Info.Followtype.IndexOf("月") != -1)
                    {
                        dtNextTime.Value = Convert.ToDateTime(RefTime).AddMonths(Convert.ToInt32(Info.Followtype.Substring(0, Info.Followtype.IndexOf("月"))));
                    }
                    if (Info.Followtype.IndexOf("天") != -1)
                    {
                        dtNextTime.Value = Convert.ToDateTime(RefTime).AddDays(Convert.ToInt32(Info.Followtype.Substring(0, Info.Followtype.IndexOf("天"))));
                    }
                   
                }
                else
                {
                    string[] Item = Info.Definefollows.Split(',');
                    if (Info.Defaultdays != "")
                    {
                        string Temp;
                        if (Convert.ToInt32(PreVisit) >= Item.Length + 1)
                        {
                            Temp = Item[Item.Length - 1];

                        }
                        else
                        {
                            Temp = Item[Convert.ToInt32(PreVisit) - 1];    
                        }
                        if (Temp.IndexOf("年") != -1)
                            dtNextTime.Value = Convert.ToDateTime(RefTime).AddYears(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("年"))));
                        if (Temp.IndexOf("月") != -1)
                            dtNextTime.Value = Convert.ToDateTime(RefTime).AddMonths(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("月"))));
                        if (Temp.IndexOf("天") != -1)
                            dtNextTime.Value = Convert.ToDateTime(RefTime).AddDays(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("天"))));
                    }
                    if (Info.Defaultdays != "")
                    {
                        string Temp;
                        if (Convert.ToInt32(PreVisit) >= Item.Length )
                        {
                            Temp = Item[Item.Length - 1];

                        }
                        else
                        {
                            Temp = Item[Convert.ToInt32(PreVisit) - 1];
                        }
                        if (Temp.IndexOf("年") != -1)
                            dtNextTime.Value = Convert.ToDateTime(RefTime).AddYears(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("年"))));
                        if (Temp.IndexOf("月") != -1)
                            dtNextTime.Value = Convert.ToDateTime(RefTime).AddMonths(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("月"))));
                        if (Temp.IndexOf("天") != -1)
                            dtNextTime.Value = Convert.ToDateTime(RefTime).AddDays(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("天"))));
                    }
                }
                dtNextTime.Enabled = false;
            }
        }

        private void rbtnOrigin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOrigin.Checked)
            {

                if (Info.Followtype != "")
                {
                    if (Info.Followtype.IndexOf("年") != -1)
                    {
                        dtNextTime.Value = Convert.ToDateTime(rTime).AddYears(Convert.ToInt32(Info.Followtype.Substring(0, Info.Followtype.IndexOf("年"))));
                    }
                    if (Info.Followtype.IndexOf("月") != -1)
                    {
                        dtNextTime.Value = Convert.ToDateTime(rTime).AddMonths(Convert.ToInt32(Info.Followtype.Substring(0, Info.Followtype.IndexOf("月"))));
                    }
                    if (Info.Followtype.IndexOf("天") != -1)
                    {
                        dtNextTime.Value = Convert.ToDateTime(rTime).AddDays(Convert.ToInt32(Info.Followtype.Substring(0, Info.Followtype.IndexOf("天"))));
                    }
                }
                else
                {
                    string[] Item = Info.Definefollows.Split(',');
                    if (Info.Defaultdays != "")
                    {
                        string Temp;
                        if (Convert.ToInt32(PreVisit) >= Item.Length + 1)
                        {
                            Temp = Item[Item.Length - 1];

                        }
                        else
                        {
                            Temp = Item[Convert.ToInt32(PreVisit) - 1];
                        }
                        if (Temp.IndexOf("年") != -1)
                            dtNextTime.Value = Convert.ToDateTime(rTime).AddYears(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("年"))));
                        if (Temp.IndexOf("月") != -1)
                            dtNextTime.Value = Convert.ToDateTime(rTime).AddMonths(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("月"))));
                        if (Temp.IndexOf("天") != -1)
                            dtNextTime.Value = Convert.ToDateTime(rTime).AddDays(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("天"))));
                    }
                    if (Info.Defaultdays != "")
                    {
                        string Temp;
                        if (Convert.ToInt32(PreVisit) >= Item.Length)
                        {
                            Temp = Item[Item.Length - 1];

                        }
                        else
                        {
                            Temp = Item[Convert.ToInt32(PreVisit) - 1];
                        }
                        if (Temp.IndexOf("年") != -1)
                            dtNextTime.Value = Convert.ToDateTime(rTime).AddYears(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("年"))));
                        if (Temp.IndexOf("月") != -1)
                            dtNextTime.Value = Convert.ToDateTime(rTime).AddMonths(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("月"))));
                        if (Temp.IndexOf("天") != -1)
                            dtNextTime.Value = Convert.ToDateTime(rTime).AddDays(Convert.ToInt32(Temp.Substring(0, Temp.IndexOf("天"))));
                    }
                }
                dtNextTime.Enabled = false;
            }
        }

        private void rbtnSetting_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSetting.Checked)
            {

                dtNextTime.Enabled = true;
            }
        }

        private void btnSaveNext_Click(object sender, EventArgs e)
        {
            try
            {
                string preTime = App.ReadSqlVal("select requested_time from t_follow_record where patient_id=" + pId + " and solution_id=" + sId + " order by id desc ", 1, "requested_time");

                if (rbtnThisTime.Checked)
                {
                    string Time = dtNextTime.Value.ToString("yyyy-MM-dd");
                    if (preTime == "" || preTime == null)
                    {
                        if (string.Compare(dtNextTime.Value.ToString("yyyy-MM-dd"), DateTime.Today.ToShortDateString()) != -1)
                        {
                            string sql = "update t_follow_record set next_time=to_date('" + Time + "','yyyy-MM-dd'),is_timeset=0 where id=" + recordId + "";
                            if (App.ExecuteSQL(sql) != -1)
                                App.Msg("设置成功");
                        }
                        else
                        {
                            rbtnOrigin.Checked = true;
                            App.Msg("时间设置不合理,将默认原方案提交");
                        }

                    }
                    else
                    {
                        
                        if (string.Compare(dtNextTime.Value.ToString("yyyy-MM-dd"), preTime) != -1)
                        {
                            string sql = "update t_follow_record set next_time=to_date('" + Time + "','yyyy-MM-dd'),is_timeset=0 where id=" + recordId + "";
                            if (App.ExecuteSQL(sql) != -1) 
                            App.Msg("设置成功");
                        }
                        else
                        {
                            rbtnOrigin.Checked=true;
                            App.Msg("操作有误，设置时间点不合理");
                        }
                    }
                }
                if (rbtnOrigin.Checked)
                {
                    string sql = "update t_follow_record set requested_time=to_date('" + rTime + "','yyyy-MM-dd'),is_timeset=1 where id=" + recordId + "";
                    if(App.ExecuteSQL(sql)!=-1)
                        App.Msg("设置成功");
                }
                if (rbtnSetting.Checked)
                {
                    string Time = dtNextTime.Value.ToString("yyyy-MM-dd");

                    if (string.Compare(Time, DateTime.Today.ToShortDateString()) != -1)
                    {
                        string sql = "update t_follow_record set next_time=to_date('" + Time + "','yyyy-MM-dd'),is_timeset=1 where id=" + recordId + "";
                        if (App.ExecuteSQL(sql) != -1)
                            App.Msg("设置成功");
                    }
                    else
                    {
                        rbtnOrigin.Checked = true;
                        App.Msg("操作有误，设置时间点不合理");
                    }

                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        private void btnNextCancel_Click(object sender, EventArgs e)
        {
            grpNextTimeSet.Enabled = false;
        }

        private void cmbState_SelectedIndexChanged(object sender, EventArgs e)
        {
            Class_Follow_State CurrentState = cmbState.SelectedItem as Class_Follow_State;
            if (CurrentState.Isfinished != "")
                panel2.Enabled = false;
            else
                panel2.Enabled = true;
        }
    }
}
