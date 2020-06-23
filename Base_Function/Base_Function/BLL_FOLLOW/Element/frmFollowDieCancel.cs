using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowDieCancel : DevComponents.DotNetBar.Office2007Form
    {
        private string Pid=""; //  病人号
        private string Sid = "";    //方案号
        Class_FollowInfo[] myInfo;
        public frmFollowDieCancel(string param1,string param2)
        {
            InitializeComponent();
            Pid = param1;
            Sid = param2;
            cmbFollowInfo.Enabled = true;
            cmbCancelReason.Enabled = false;
            cmbFollowInfo.Visible = false;
            lbShema.Text = App.ReadSqlVal("select follow_name from t_follow_info where id=" + Sid + "", 0, "follow_name");
            //IniFollowInfo();
            IniFollowCancel();
        }
        public void IniFollowInfo()
        {
            //string User_Id = App.UserAccount.UserInfo.User_id;
            //string sids = GetSolutionIds(User_Id); // 测试需要先注释
            //string tempSql;
            //if (sids != "")
            //{
            //    tempSql = "select * from T_FOLLOW_INFO where id in (" + sids + ") and id not in (select solution_id from T_FOLLOW_MANUALPATIENT where patient_id="+Pid+" and solution_id <>"+Sid+") and isenable='Y'";
            //    DataSet dsTemp = App.GetDataSet(tempSql);
            //    myInfo = GetInfo(dsTemp);
            //    for (int i = 0; i < myInfo.Length; i++)
            //        cmbFollowInfo.Items.Add(myInfo[i]);
            //    cmbFollowInfo.DisplayMember = "Follow_Name";
            //    cmbFollowInfo.ValueMember = "id";
            //    cmbFollowInfo.SelectedIndex = 0;
            //}
        }
        /// <summary>
        /// 实例化方案
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public Class_FollowInfo[] GetInfo(DataSet temp)
        {
            if (temp != null)
                if (temp.Tables[0].Rows.Count != 0)
                {

                    DataTable dt = temp.Tables[0];
                    Class_FollowInfo[] info = new Class_FollowInfo[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        info[i] = new Class_FollowInfo();
                        info[i].Id = dt.Rows[i]["id"].ToString();
                        info[i].Follow_name = dt.Rows[i]["follow_name"].ToString();
                        info[i].Account_ids = dt.Rows[i]["account_ids"].ToString();
                        info[i].Section_ids = dt.Rows[i]["section_ids"].ToString();
                        info[i].Icd9codes = dt.Rows[i]["icd9codes"].ToString();
                        info[i].Icd10codes = dt.Rows[i]["icd10codes"].ToString();
                        info[i].Ismaindiag = dt.Rows[i]["ismaindiag"].ToString();
                        info[i].Startingtime = dt.Rows[i]["startingtime"].ToString();
                        info[i].Defaultdays = dt.Rows[i]["defaultdays"].ToString();
                        info[i].Followtype = dt.Rows[i]["followtype"].ToString();
                        info[i].Definefollows = dt.Rows[i]["definefollows"].ToString();
                        info[i].Followtextid = dt.Rows[i]["followtextid"].ToString();
                        info[i].Createtime = dt.Rows[i]["createtime"].ToString();
                        info[i].Isenable = dt.Rows[i]["isenable"].ToString();
                        info[i].Maintain_section = dt.Rows[i]["maintain_section"].ToString();
                        info[i].FinishType = dt.Rows[i]["finishType"].ToString();
                    }
                    return info;
                }
            return null;
        }
        /// <summary>
        /// 获取相关方案ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetSolutionIds(string id)
        {
            string getUserIds = "select id,account_ids from T_FOLLOW_INFO ";
            string ReturnIds = "";
            DataSet sTemp = App.GetDataSet(getUserIds);
            if (sTemp != null)
            {
                if (sTemp.Tables[0].Rows.Count != 0)
                {
                    DataTable dt = sTemp.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string[] ids = dt.Rows[i]["account_ids"].ToString().Split(',');
                        foreach (string temp in ids)
                        {
                            if (id == temp)
                            {
                                if (ReturnIds == "")
                                    ReturnIds = dt.Rows[i]["id"].ToString();
                                else
                                    ReturnIds += "," + dt.Rows[i]["id"].ToString();
                                break;
                            }

                        }
                    }
                    return ReturnIds;
                }
            }
            return "";
        }
        public void IniFollowCancel()
        {
            string temp = "select * from T_FOLLOW_CANCEL_REASON where des <> '死亡'";
            DataSet ds = App.GetDataSet(temp);
            if(ds!=null)
                if (ds.Tables[0].Rows.Count != 0)
                {
                    DataRow newRow = ds.Tables[0].NewRow();                    
                    newRow[0] = 0;
                    newRow[1] = "";
                    ds.Tables[0].Rows.InsertAt(newRow, 0);
                    cmbCancelReason.DataSource = ds.Tables[0].DefaultView;
                    cmbCancelReason.DisplayMember = "des";
                    cmbCancelReason.ValueMember = "id";
                }

        }

        private void rbtnFollowYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFollowYes.Checked)
            {
                cmbFollowInfo.Enabled = true;
                cmbCancelReason.Text = "";
                cmbCancelReason.Enabled = false;

            }
            else
            {
                cmbCancelReason.Enabled = true;
                cmbFollowInfo.Text = "";
                cmbFollowInfo.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList array = new ArrayList();
            array.Clear();
            string sql = "";
            if (rbtnFollowYes.Checked)
            {
                //Class_FollowInfo info = cmbFollowInfo.SelectedItem as Class_FollowInfo;
                //string selectSid = info.Id;
                //if (string.Compare(selectSid, Sid) == 0)
                //{
                    sql = "update T_FOLLOW_MANUALPATIENT set isadd=1,cancel_id=null,update_time=to_date('"+App.GetSystemTime().ToShortDateString()+"','yyyy-MM-dd') where patient_id=" + Pid + " and solution_id=" + Sid + "";
                    array.Add(sql);
                //}
                //else
                //{
                //    sql = "delete from T_FOLLOW_MANUALPATIENT where patient_id=" + Pid + " and solution_id=" + Sid + "";
                //    array.Add(sql);
                //    sql = "insert into T_FOLLOW_MANUALPATIENT(patient_id,solution_id,isadd,update_time) values(" + Pid + "," + selectSid + ",1,to_date('" + App.GetSystemTime().ToShortDateString() + "','yyyy-MM-dd'))";
                //    array.Add(sql);
                //}
            }
            else
            {
                sql = "update T_FOLLOW_MANUALPATIENT set cancel_id=" + cmbCancelReason.SelectedValue.ToString() + " ,update_time=to_date('" + App.GetSystemTime().ToShortDateString() + "','yyyy-MM-dd') where patient_id=" + Pid + " and solution_id=" + Sid + "";
                array.Add(sql);

            }
            try
            {
                string[] cmd = new string[array.Count];
                for (int i = 0; i < array.Count; i++)
                {
                    cmd[i] = array[i].ToString();
                }
                App.ExecuteBatch(cmd);
                this.Close();
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}