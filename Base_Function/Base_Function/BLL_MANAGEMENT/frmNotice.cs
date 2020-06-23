using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    /// <summary>
    /// 消息提醒
    /// 作者:李文明
    /// 时间:2013-03-15
    /// </summary>
    public partial class frmNotice : Office2007Form 
    {
        InPatientInfo inpatent;
        public frmNotice()
        {
            InitializeComponent();
        }

        public frmNotice(InPatientInfo inpatinfo)
        {
            InitializeComponent();
            App.FormStytleSet(this, false);
            this.inpatent = inpatinfo;
            dataRECEIVE_USER();
            
            txtPATIENT_NAME.Text = inpatent.Patient_Name;
            dtpIN_TIME.Value =Convert.ToDateTime(inpatent.In_Time);
            txtPID.Text = inpatent.Id.ToString();
            if (inpatent.Sick_Doctor_Id.Trim() != "")       //接收人
            {
                string vals = inpatent.Sick_Doctor_Id;
                for (int j = 0; j < chkRECEIVE_USER.Items.Count; j++)
                {
                    DataRowView temp = (DataRowView)chkRECEIVE_USER.Items[j];
                    if (temp["user_id"].ToString() == vals)
                    {
                        chkRECEIVE_USER.SetItemChecked(j, true);
                    }
                }
            }
            Reset();

        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset()
        {
            //清空添加内容
            txtTITLE.Text = "";
            txtCONTENT.Text = "";
            dtpADD_TIME.Value = App.GetSystemTime();
            txtOPERATOR_USER.Text = App.UserAccount.UserInfo.User_name;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                string PATIENT_NAME=txtPATIENT_NAME.Text;
                string IN_TIME=dtpIN_TIME.Value.ToString("yyyy/MM/dd");
                string PID = txtPID.Text;
                string RECEIVE_USER="";
                string RECEIVE_USER_NAMES = "";
                if (chkRECEIVE_USER.Items.Count > 0 && chkRECEIVE_USER.CheckedItems.Count == 0)
                {
                }
                for (int i = 0; i < chkRECEIVE_USER.CheckedItems.Count; i++)
                {
                    DataRowView temp = (DataRowView)chkRECEIVE_USER.CheckedItems[i];
                    if (RECEIVE_USER == "")
                    {
                        RECEIVE_USER = temp["user_id"].ToString();
                       
                    }
                    else
                    {
                        RECEIVE_USER = RECEIVE_USER + "," + temp["user_id"].ToString();
                    }

                    if (RECEIVE_USER_NAMES == "")
                    {
                        RECEIVE_USER_NAMES = temp["user_name"].ToString();

                    }
                    else
                    {
                        RECEIVE_USER_NAMES = RECEIVE_USER_NAMES + "," + temp["user_name"].ToString();
                    }
                }
                string TITLE=txtTITLE.Text;
                string CONTENT=txtCONTENT.Text;
                string ADD_TIME = dtpADD_TIME.Value.ToString("yyyy/MM/dd HH:mm:ss");
                string OPERATOR_USER=txtOPERATOR_USER.Text;

                string SqlMsg = "";
                SqlMsg = "insert into t_msg_info (PID,PATIENT_NAME,IN_TIME,RECEIVE_USER,TITLE,CONTENT,ADD_TIME,OPERATOR_USER,RECEIVE_USER_NAME) " +
                         "values ('{0}','{1}',to_timestamp('{2}','syyyy-mm-dd hh24:mi:ss'),'{3}','{4}','{5}',to_timestamp('{6}','syyyy-mm-dd hh24:mi:ss'),'{7}',{8})";
                SqlMsg = string.Format(SqlMsg, PID, PATIENT_NAME, IN_TIME, RECEIVE_USER, TITLE, CONTENT, ADD_TIME, OPERATOR_USER, RECEIVE_USER_NAMES);

                if (App.ExecuteSQL(SqlMsg)>0)
                {
                    App.Msg("提交成功!");
                    this.Close();
                }
                else
                {
                    App.Msg("提交失败!");
                }
                            
            }
            catch (Exception ex)
            {
                App.MsgErr("提交失败:"+ ex.ToString());
            }
        }

        private void frmNotice_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 绑定接收人下拉列表
        /// </summary>
        private void dataRECEIVE_USER()
        {
            //获取当前用户所在科室的医生            
            string Sql = "select distinct(a.user_id),a.user_name from t_userinfo a" +
                         " inner join t_account_user b on a.user_id=b.user_id" +
                         " inner join t_account c on b.account_id = c.account_id" +
                         " inner join t_acc_role d on d.account_id = c.account_id" +
                         " inner join t_role e on e.role_id = d.role_id" +
                         " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                         " where f.section_id='" + inpatent.Section_Id + "' and  e.role_type='D'";
            DataSet ds_RECEIVE_USER = App.GetDataSet(Sql);
            if (ds_RECEIVE_USER != null)
            {
                chkRECEIVE_USER.DataSource = ds_RECEIVE_USER.Tables[0].DefaultView;
                chkRECEIVE_USER.DisplayMember = "user_name";
                chkRECEIVE_USER.ValueMember = "user_id";
            }
            

        }
    }
}