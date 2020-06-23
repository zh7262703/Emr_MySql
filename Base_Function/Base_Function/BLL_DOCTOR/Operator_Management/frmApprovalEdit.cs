using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR
{
    public partial class frmApprovalEdit : DevComponents.DotNetBar.Office2007Form
    {
        //手术id
        private string Id = null;
        //上报单位
        private string Unit = null;
        //获得选择审批医生名称
        private string Approval_DocName ="";
        //获得选择审批医生的ID
        private string Approval_DocId = "";
        public frmApprovalEdit()
        {
            InitializeComponent();
        }

        public frmApprovalEdit(string id)
        {
            InitializeComponent();
            Id = id;
            DataTable dt = GetApply_ApprovalList(id);
            lblSurgery_Type.Text = dt.Rows[0]["oper_type"].ToString();
            lblSurgery_ID.Text = dt.Rows[0]["operation_id"].ToString();
            lblSurgery_Date.Text = dt.Rows[0]["operation_date"].ToString();
            lblDisplay.Text = dt.Rows[0]["display"].ToString();
            lblOperation_Docname.Text = dt.Rows[0]["operation_docname"].ToString();
            lblBinqi_Opernotice.Text = dt.Rows[0]["binqi_opernotice"].ToString();
            lblOper_Plan.Text = dt.Rows[0]["oper_plan"].ToString();
            lblDesioper_Names.Text = dt.Rows[0]["desioper_names"].ToString();
            lblAnaes_Methodname.Text = dt.Rows[0]["anaes_methodname"].ToString();
            lblOpery_Date.Text = dt.Rows[0]["opery_date"].ToString();
            lblPatients_Views.Text = dt.Rows[0]["patients_views"].ToString();
            lblFamilydan_Views.Text = dt.Rows[0]["familydan_views"].ToString();
            lblApply_Docname.Text = dt.Rows[0]["apply_docname"].ToString();
            lblApply_Date.Text = dt.Rows[0]["apply_date"].ToString();
            lblApproval_Docname.Text = App.UserAccount.UserInfo.User_name;
            lblReport.Text = App.UserAccount.CurrentSelectRole.Role_name;
            Approval_DocName = dt.Rows[0]["APPROVAL_DOCNAMES"].ToString();
            Approval_DocId = dt.Rows[0]["APPROVAL_DOCIDS"].ToString();
            GetApproList();
            if(App.UserAccount.CurrentSelectRole.Role_type=="D")
            {
                lblReport.Text = lblReport.Text + "医务科：";
                Unit = "医务科";
            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "Y")
            {
                lblReport.Text = lblReport.Text + "院办：";
                Unit = "院办";
            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
                lblReport.Dispose();
                pnlReport.Dispose();
            }

        }

        private DataTable GetApply_ApprovalList (string id)
        {
            string Sql_Apply_ApprovalList= "select oper_type,operation_id,operation_date,display,operation_docname,binqi_opernotice,oper_plan,"+
                                           " desioper_names,anaes_methodname,opery_date,patients_views,familydan_views,apply_docname,"+
                                           " apply_date,APPROVAL_DOCNAMES,APPROVAL_DOCIDS from t_operapproval_application where id =" + id + "";
            DataTable dt = null;
            DataSet ds = App.GetDataSet(Sql_Apply_ApprovalList);
            if(ds.Tables.Count>0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
        //确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
	            bool flag = Validating();
	            if(!flag)    //如果有些必要项目没选，则不能保存
	                return ;
	            string Sql_Report = "";
	            string Sql_Approval = "";
	            string Sql_Update = "";
	            string Isagree = "";
	            //审批医生名字
	            string DocName = "";
	            //审批医生Id
	            string DocId = "";
	            string[] arr = null;
	            if(rdbtnYes.Checked)
	            {
	                string Sql_Insert = "";
	                Isagree = "Y";
	                /*
	                 *审批 
	                 */
	                Sql_Approval = "update t_operationdoctor_approval set isagree='" + Isagree + "',"+
	                               "APPROVAL_DOCTNAME='" + App.UserAccount.UserInfo.User_name + "',"+
	                               "APPROVAL_DOCTID='" + App.UserAccount.UserInfo.User_id + "',"+
	                               "APPUSER_TYPE='" + App.UserAccount.UserInfo.U_seniority + "',"+
	                               "APPROVAL_TITLE='" + App.UserAccount.UserInfo.U_tech_post + "',"+
	                               "POSITION='" + App.UserAccount.UserInfo.U_position + "',Is_Send='Y',SEND_UNIT='"+Unit+"'," +
	                              "appoval_content='" + txtContent.Text.Trim() + "',applystate_doc='通过'," +
                                  "shenpi_time=to_timestamp('" + dtpApproval_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss') " +
	                              "where oper_type='" + Id + "' and is_send='N' and applystate_doc='未通过'";
	                if (chbReport.Checked)  //如果此手术需要上报
	                {
	                    Sql_Insert = "insert into t_operationdoctor_approval(oper_type,applystate_doc,approval_doctname,approval_doctid," +
	                                  " ISAGREE,approval_title,position,is_send,send_unit)" +
	                                  " values('" + Id + "','未通过','','','N',''," +
	                                  "'','N','')";
	                    DocName = Approval_DocName;
	                    DocId = Approval_DocId;
	                    for (int i = 0; i < pnlReport.Controls.Count; i++)
	                    {
	                        CheckBox chb = pnlReport.Controls[i] as CheckBox;
	                        if (chb.Checked)
	                        {
	                            DocName += chb.Text.Trim() + ",";
	                            DocId += chb.Name + ",";
	                        }
	                    }
	                    Sql_Update = "update t_operapproval_application set APPROVAL_DOCNAMES='" + DocName + "',APPROVAL_DOCIDS='" + DocId + "' where id =" + Id + "";
	                    arr = new string[3];
	                    arr[0] = Sql_Approval;
	                    arr[1] = Sql_Insert;
	                    arr[2] = Sql_Update;
	                }
	                else
	                { 
	                    arr = new string[1];
	                    arr[0] = Sql_Approval;
	                }
	            }
	            else if (rdbtnNo.Checked)
	            {
	                Isagree = "N";
	                /*
	                 *审批 
	                 */
	                Sql_Approval = "update t_operationdoctor_approval set isagree='" + Isagree + "'," +
	                               "APPROVAL_DOCTNAME='" + App.UserAccount.UserInfo.User_name + "'," +
	                               "APPROVAL_DOCTID='" + App.UserAccount.UserInfo.User_id + "'," +
	                               "APPUSER_TYPE='" + App.UserAccount.UserInfo.U_seniority + "'," +
	                               "APPROVAL_TITLE='" + App.UserAccount.UserInfo.U_tech_post + "'," +
	                               "POSITION='" + App.UserAccount.UserInfo.U_position + "',Is_Send='N',SEND_UNIT=''," +
	                              "appoval_content='" + txtContent.Text.Trim() + "',applystate_doc='未通过'," +
                                  "shenpi_time=to_timestamp('" + dtpApproval_Time.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-MM-dd HH24:mi:ss') " +
	                              "where oper_type='" + Id + "'and is_send='N' and applystate_doc='未通过'";
	            }
	            int count = 0;
	            try
	            {
	                count = App.ExecuteBatch(arr);
	            }
	            catch (Exception)
	            {
	                
	                throw;
	            }
	            if(count>0)
	            {
	                DataInit.isInAreaSucceed = true;
	                App.Msg("审批成功！");
	                GetApproList();
	            }
            }
            catch (System.Exception ex)
            {
            	
            }
        }
        /// <summary>
        /// 获得审批列表
        /// </summary>
        public void GetApproList()
        {
            string Sql_List = "select applystate_doc 审批状态,appoval_content 审批意见,approval_doctname 审批人,to_char(shenpi_time,'yyyy-MM-dd HH24:mi') 审批时间 from t_operationdoctor_approval where applystate_doc='通过'";
            DataSet ds = App.GetDataSet(Sql_List);
            if(ds.Tables.Count>0)
            {
                DataTable dt = ds.Tables[0];
                flgList.DataSource = dt.DefaultView;
                flgList.AllowEditing = false;
            }
        }

        private void chbReport_CheckedChanged(object sender, EventArgs e)
        {
            int x = 10;
            int y = 8;
            if (chbReport.Checked)  //是否上报
            {
                string Sql = "";
                if (App.UserAccount.CurrentSelectRole.Role_type == "D") //如果当前用户是医生，上报到医务科
                {
                    Sql = "select a.user_id,a.user_name,b.type,u_tech_post,u_position from t_userinfo a" +
                          " inner join t_approve_accredit b on a.user_id = b.userid" +
                          " where b.type like '%医务科%'";
                }
                else if (App.UserAccount.CurrentSelectRole.Role_type == "Y")  //如果当前用户是医务科，上报到院办
                {
                    Sql = "select a.user_id,a.user_name,b.type,u_tech_post,u_position from t_userinfo a" +
                          " inner join t_approve_accredit b on a.user_id = b.userid" +
                          " where b.type like '%业务副院长%'";
                }
                DataSet ds = App.GetDataSet(Sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CheckBox chb = new CheckBox();
                        chb.AutoSize = true;
                        chb.Name = dt.Rows[i]["user_id"].ToString();
                        chb.Text = dt.Rows[i]["user_name"].ToString();
                        chb.Tag = dt.Rows[i]["u_tech_post"] + "," + dt.Rows[i]["u_position"];
                        if (x <= pnlReport.Width)
                        {
                            chb.Location = new Point(x, y);
                        }
                        else
                        {
                            x = 10;
                            y += chb.Height;
                            chb.Location = new Point(x, y);
                        }
                        this.pnlReport.Controls.Add(chb);
                        x = x + 80;
                    }
                }
            }
            else
            {
                pnlReport.Controls.Clear();
            }
        }

        private void rdbtnYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnYes.Checked)
            {
                chbReport.Enabled = true;
                pnlReport.Enabled = true;
            }
            else
            {
                chbReport.Enabled = false;
                pnlReport.Enabled = false;
            }
        }
        /// <summary>
        /// 验证
        /// </summary>
        private bool Validating()
        {
            bool flag = false;
            if (rdbtnYes.Checked)    //同意
            {
                if (chbReport.Checked)   //上报
                {
                    for (int i = 0; i < pnlReport.Controls.Count; i++)
                    {
                        CheckBox chk = pnlReport.Controls[i] as CheckBox;
                        if (chk.Checked)
                        {
                            flag = true;
                            break;
                        }
                    }
                    if(!flag)
                    {
                        App.Msg("请您选择上报人！");
                    }
                }
                else
                {
                    if (txtContent.Text.Trim() != "")
                    {
                        flag = true;
                    }
                    if (!flag)
                    {
                        App.Msg("请您填写审批意见！");
                    }
                }
            }
            else if (rdbtnNo.Checked)
            {
                if (txtContent.Text.Trim() != "")
                {
                    flag = true;
                }
                if (!flag)
                {
                    App.Msg("请您填写审批意见！");
                }
            }
            else
            {
                App.Msg("请您选择同意或不同意！");
            }
            return flag;
        }

        private void rdbtnNo_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnNo.Checked)
            {
                chbReport.Checked = false;
            }
        }

    }
}