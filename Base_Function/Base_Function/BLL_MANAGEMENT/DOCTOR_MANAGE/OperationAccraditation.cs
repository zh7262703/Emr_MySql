using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.MODEL;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    public partial class OperationAccraditation : UserControl
    {
        private string mark = "Y";//手术审批是否需要系统自动判断:Y代表是  N代表否
        private string ID;        //手术审批参数设置ID
        private string chk = "";
        public OperationAccraditation()
        {
            try
            {
                InitializeComponent();
            }
            catch
            {
            }

        }
        private void OperationAccraditation_Load(object sender, EventArgs e)
        {
            try
            {
                OPerationA();
            }
            catch
            {

            }

        }
        private void OPerationA()
        {
            string SQL = "select ID,IS_AUTO,LIMIT_DOCLIST,RECORD_TIME,RECORD_BY_ID,RECORDBY_NAME  from t_oper_appr_param  where RECORD_BY_ID='" + App.UserAccount.Account_id + "'";
            DataSet ds = App.GetDataSet(SQL);
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Class_Oper_appr_param parm = new Class_Oper_appr_param();
                    parm.Id = ds.Tables[0].Rows[i]["ID"].ToString();
                    parm.Is_auto = ds.Tables[0].Rows[i]["IS_AUTO"].ToString();
                    parm.Limit_doclist = ds.Tables[0].Rows[i]["LIMIT_DOCLIST"].ToString();
                    parm.Record_time = Convert.ToDateTime(ds.Tables[0].Rows[i]["RECORD_TIME"].ToString());
                    parm.Record_by_id = ds.Tables[0].Rows[i]["RECORD_BY_ID"].ToString();
                    parm.Recordby_name = ds.Tables[0].Rows[i]["RECORDBY_NAME"].ToString();

                    mark = parm.Is_auto;
                    chk = parm.Limit_doclist;
                }
            }

        }
        /// <summary>
        /// 手术审批参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            chk = "";
            //手术审批是否需要系统自动判断：是－Y  否-N
            if (!rdtnYES.Checked)
            {
                mark = "N";
            }

            string sql = "";
            ID = App.GenId("T_OPER_APPR_PARAM", "ID").ToString();
            //string opid = ID;
            //string is_auto = mark;
            //string limit_doclist = chk;

            if (chkOperation_summary.Checked == true)
            {

                chk += this.chkOperation_summary.Text + ",";
            }
            if (chkOperation_discussion.Checked == true)
            {

                chk += this.chkOperation_discussion.Text + ",";
            }
            if (chkOperation_record.Checked == true)
            {

                chk += this.chkOperation_record.Text + ",";
            }
            if (chkPostoperation_record.Checked == true)
            {

                chk += this.chkPostoperation_record.Text + ",";
            }
            if (chkLetter_of_consent.Checked == true)
            {

                chk += this.chkLetter_of_consent.Text + ",";
            }
            if (chk != "")
            {
                chk = chk.Substring(0, chk.Length - 1);
            }
            else
            {
                chk = "";
            }
            string operatiioncount = App.ReadSqlVal("select count(*) as cot from t_oper_appr_param  where RECORD_BY_ID='" + App.UserAccount.Account_id + "'", 0, "cot");
            if (operatiioncount == "0")
            {
                sql = "insert into t_oper_appr_param(ID,IS_AUTO,LIMIT_DOCLIST,RECORD_TIME,RECORD_BY_ID,RECORDBY_NAME) values('"
                        + ID + "','"
                        + mark + "','"
                        + chk + "',sysdate,'"
                        + App.UserAccount.Account_id + "','"
                        + App.UserAccount.Account_name + "')";
            }
            else
            {
                sql = "update t_oper_appr_param  set IS_AUTO='"
                        + mark + "',LIMIT_DOCLIST='"
                        + chk + "',RECORD_TIME=sysdate  where RECORD_BY_ID='" + App.UserAccount.Account_id + "'";
            }
            if (sql != "")
            {

                App.ExecuteSQL(sql);
                App.Msg("操作成功！");
                OPerationA();

            }
            //    }

            //catch (Exception ex)
            //{
            //    App.MsgErr("错误信息：" + ex.Message);
            //}



        }




    }
}
