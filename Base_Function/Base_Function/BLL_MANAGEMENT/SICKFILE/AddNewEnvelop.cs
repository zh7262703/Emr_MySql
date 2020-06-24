using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class AddNewEnvelop : DevComponents.DotNetBar.Office2007Form
    {
        public AddNewEnvelop()
        {
            InitializeComponent();
        }
        ucCoseOperate _uccose;
        public AddNewEnvelop(ucCoseOperate uccose)
        {
            InitializeComponent();
            this._uccose = uccose;
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string num = this.txtShengQinghao.Text;//申请病案号
                string countnum = this.txtCount.Text;//申请病案住院次数
                string remark = this.txtRemark.Text;//申请理由
                string eName = this.labEnvelopName.Text;//申请人
                string backDocdor = "";//档案退回操作人
                string shenqingName = App.UserAccount.UserInfo.User_id;//申请人的ID
                string backID = "";//退回操作人的ID


                if (num == "")
                {
                    App.Msg("申请病案号不能为空");
                    this.txtShengQinghao.Focus();
                    return;
                }
                if (countnum == "")
                {
                    App.Msg("申请病案住院次数不能为空");
                    this.txtCount.Focus();
                    return;
                }
                if (remark == "")
                {
                    App.Msg("申请理由不能为空");
                    this.txtRemark.Focus();
                    return;
                }
                if (eName == "")
                {
                    App.Msg("申请人不能为空");
                    return;
                }
                if (lvDocdor2.Items.Count == 0)
                {
                    App.Msg("档案退回操作人不能为空");
                    return;
                }
                for (int i = 0; i < lvDocdor2.Items.Count; i++)
                {
                    backDocdor += lvDocdor2.Items[i].Text + ",";
                }
                if (backDocdor != "")
                {
                    backDocdor = backDocdor.Substring(0, backDocdor.Length - 1);
                }
                string[] str = backDocdor.Split(',');//退回操作人的姓名
                for (int i = 0; i < str.Length; i++)//根据每个人的姓名把他的ID号取出来
                {
                    string selectSQL = "select USER_ID from t_userinfo where USER_NAME='" + str[i] + "'";
                    DataSet ds = App.GetDataSet(selectSQL);
                    string aa = ds.Tables[0].Rows[0][0].ToString();
                    backID += aa + ",";
                }
                backID = backID.Substring(0, backID.Length - 1);
                string eTime = this.labEnveloptime.Text;//申请时间 

                MySqlDBParameter p_num = new MySqlDBParameter();
                p_num.Value = num;
                p_num.ParameterName = "num";
                p_num.DBType = MySqlDbType.VarChar;

                MySqlDBParameter p_count = new MySqlDBParameter();
                p_count.Value = countnum;
                p_count.ParameterName = "countnum";
                p_count.DBType = MySqlDbType.Decimal;

                MySqlDBParameter p_remark = new MySqlDBParameter();
                p_remark.Value = remark;
                p_remark.ParameterName = "remark";
                p_remark.DBType = MySqlDbType.VarChar;

                MySqlDBParameter p_eName = new MySqlDBParameter();
                p_eName.Value = eName;
                p_eName.ParameterName = "eName";
                p_eName.DBType = MySqlDbType.VarChar;


                MySqlDBParameter p_backDocdor = new MySqlDBParameter();
                p_backDocdor.Value = backDocdor;
                p_backDocdor.ParameterName = "backDocdor";
                p_backDocdor.DBType = MySqlDbType.VarChar;

                //申请人的ID
                MySqlDBParameter p_shenqingName = new MySqlDBParameter();
                p_shenqingName.Value = shenqingName;
                p_shenqingName.ParameterName = "shenqingName";
                p_shenqingName.DBType = MySqlDbType.VarChar;


                //退回操作人ID
                MySqlDBParameter p_backID = new MySqlDBParameter();
                p_backID.Value = backID;
                p_backID.ParameterName = "backID";
                p_backID.DBType = MySqlDbType.VarChar;

                ////退回操作人姓名
                //MySqlDBParameter p_backDocdo = new MySqlDBParameter();
                //p_backDocdor.Value = backDocdor;
                //p_backDocdor.ParameterName = "backDocdor";
                //p_backDocdor.DBType = MySqlDbType.VarChar;

                //if (App.UserAccount.CurrentSelectRole.Section_Id == "")
                //{
                //    //退回状态
                //    MySqlDBParameter p_backDocd = new MySqlDBParameter();
                //    p_backDocdor.Value = backDocdor;
                //    p_backDocdor.ParameterName = "backDocdor";
                //    p_backDocdor.DBType = MySqlDbType.VarChar;
                //}

                //MySqlDBParameter p_eTime = new MySqlDBParameter();
                //p_remark.Value = remak;
                //p_remark.ParameterName = "eTime";
                //p_remark.DBType = MySqlDbType.VarChar;

                MySqlDBParameter[] parameters = new MySqlDBParameter[] { 
                    p_num,
                    p_count,
                    p_remark,
                    p_eName,
                    p_backDocdor,
                    p_shenqingName,
                    p_backID
                };
                string insertSQL = "insert into T_DOC_REQ_RECORD(IN_HOSPITAL_ID,IN_COUNT,REQ_REMARK,REQ_BY_NAME,RECORD_BY_NAME,REQ_BY,RECORD_BY," +
                    " REQ_BY_TIME,REQ_STATE) values(:num, :countnum, :remark, :eName, :backDocdor,:shenqingName,:backID,to_TIMESTAMP('" + eTime + "','yyyy-MM-dd HH24:mi'),'0')";
                if (App.ExecuteSQL(insertSQL, parameters) > 0)
                {
                    App.Msg("增加成功");
                    _uccose.GetCoseData();
                    this.Close();
                }
                else
                {
                    App.Msg("增加失败，请检查参数是否正确，网络是否正常");
                }
            }
            catch (Exception exx)
            {

                App.Msg(exx.Message);
            }
        }

        private void AddNewEnvelop_Load(object sender, EventArgs e)
        {
            this.labEnvelopName.Text = App.UserAccount.UserInfo.User_name;
            this.labEnveloptime.Text = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
            GetDoctorNameBysection_officeName();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GetDoctorNameBysection_officeName()
        {
            string Sql = "";
            if (App.UserAccount.CurrentSelectRole.Section_Id == "")
            {
                Sql = "select distinct(a.user_id),a.user_name from t_userinfo a " +//病区护士
                            " inner join t_account_user b on a.user_id=b.user_id " +
                            " inner join t_account c on b.account_id = c.account_id " +
                            " inner join t_acc_role d on d.account_id = c.account_id " +
                            " inner join t_role e on e.role_id = d.role_id " +
                            " inner join t_acc_role_range f on d.id = f.acc_role_id " +
                            " where f.sickarea_id='" + App.UserAccount.UserInfo.Sickarea_id + "' and  e.role_type='N'";
            }
            else
            {
                Sql = "select distinct(a.user_id),a.user_name from t_userinfo a" +//科室医生
                                        " inner join t_account_user b on a.user_id=b.user_id" +
                                        " inner join t_account c on b.account_id = c.account_id" +
                                        " inner join t_acc_role d on d.account_id = c.account_id" +
                                        " inner join t_role e on e.role_id = d.role_id" +
                                        " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                                        " where f.section_id='" + App.UserAccount.UserInfo.Section_id + "' and  e.role_type='D'";
            }
            DataSet ds_doctor = App.GetDataSet(Sql);
            for (int i = 0; i < ds_doctor.Tables[0].Rows.Count; i++)
            {
                this.lvDoctor.Items.Add(ds_doctor.Tables[0].Rows[i][1].ToString());
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvDoctor.SelectedItems.Count != 0)
                {
                    
                    for (int i = 0; i < lvDoctor.SelectedItems.Count; i++)
                    {
                        ////lvDoctor.Items.RemoveAt(lvDoctor.SelectedItems[i].Index);
                        if (lvDocdor2.Items.Count > 0)
                        {
                            for (int j = 0; j < lvDocdor2.Items.Count; j++)
                            {
                                if (IsSame(lvDoctor.SelectedItems[i].Text))
                                {
                                    //lvDocdor2.Items[lvDoctor.SelectedItems[i].Text].Remove();
                                }
                                else
                                {
                                    lvDocdor2.Items.Add(lvDoctor.SelectedItems[i].Text.ToString());
                                }
                            }
                        }
                        else
                        {
                            lvDocdor2.Items.Add(lvDoctor.SelectedItems[i].Text.ToString());
                        }
                    }
                }
                else
                {
                    App.Msg("您还没有选择要添加的人");
                    return;
                }
            }
            catch (Exception ex)
            {
                App.Msg(ex.Message);
            }
        }

        private void btndel_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvDocdor2.Items.Count != 0)
                {
                    if (lvDocdor2.SelectedItems.Count != 0)
                    {
                        while (lvDocdor2.SelectedItems.Count > 0)
                        {
                            lvDocdor2.Items.Remove(lvDocdor2.SelectedItems[0]);
                        }
                        //int count = lvDocdor2.SelectedItems.Count;
                        //for (int i = 0; i < count; i++)
                        //{ 
                        //    //lvDoctor.Items.Add(lvDocdor2.SelectedItems[i].Text.ToString());
                        //    //lvDocdor2.Items.Remove(lvDocdor2.SelectedItems[i]);//.Text);//[lvDocdor2.SelectedItems[i].Text].Remove();
                        //    //lvDocdor2.Items.RemoveAt(lvDocdor2.SelectedItems[i].Index);
                        //    //lvDocdor2.Items.RemoveAt(lvdoc);
                        //}
                    }
                    else
                    {
                        App.Msg("您还没有选择要删除的人");
                    }
                }
                else
                {
                    App.Msg("没有可以删除的人");
                }
            }
            catch (Exception eee)
            {

                App.Msg(eee.Message);
            }
        }

        private void txtCount_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(App.isNumval(this.txtCount.Text.Trim())))
            {
                App.Msg("申请病案住院次数应该为数字，请重新输入");
                this.txtCount.Clear();
                this.txtCount.Focus();
                return;
            }
        }
        private bool IsSame(string text)
        {
            //没有相同的值为false
            bool isSame = false;
            for (int j = 0; j < lvDocdor2.Items.Count; j++)
            {
                if (text == lvDocdor2.Items[j].Text)
                {
                    isSame = true;
                    break;
                }
            }
            return isSame;
        }
    }
}