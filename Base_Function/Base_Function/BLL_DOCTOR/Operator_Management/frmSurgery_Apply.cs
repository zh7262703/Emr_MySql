using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR
{
    public partial class frmSurgery_Apply : DevComponents.DotNetBar.Office2007Form
    {
        private string Oper_Id = "";
        private string Oper_Name = "";
        private string Id = "";
        public frmSurgery_Apply()
        {
            InitializeComponent();
        }

        public frmSurgery_Apply(string oper_Id,string oper_Name,string id)
        {
            InitializeComponent();
            this.Oper_Id = oper_Id;
            this.Oper_Name = oper_Name;
            lblDesioper_Names.Text = Oper_Name;
            Id = id;
            txtApply_Docname.Text = App.UserAccount.UserInfo.User_name;
            dtpApply_Date.Value = App.GetSystemTime();
            dtpOperation_Date.Value = App.GetSystemTime();
            dtpOpery_Date.Value = App.GetSystemTime();
            flgView.DataSource = GetApprovalList();
            flgView.Cols["code_icd9"].Visible = false;
            flgView.Cols["apply_docid"].Visible = false;
            flgView.Cols["operation_docid"].Visible = false;
            GetAllDoctor();
            GetTypeDoctor();
            GetAllAnaes();
        }
        /// <summary>
        /// 获得所有医师
        /// </summary>
        private void GetAllDoctor()
        {
            string Sql_Get_Doctor = "select distinct(a.user_id),a.user_name,a.u_position,a.u_tech_post from t_userinfo a" +
                                  " inner join t_account_user b on a.user_id=b.user_id"+
                                  " inner join t_account c on b.account_id = c.account_id"+
                                  " inner join t_acc_role d on d.account_id = c.account_id"+
                                  " inner join t_role e on e.role_id = d.role_id"+
                                  " where e.role_type='D'";
            DataSet ds = App.GetDataSet(Sql_Get_Doctor);
            DataTable dt = ds.Tables[0];
            cbxDoctor.Items.Add("--请选择--");
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                ListItem item = new ListItem();
                item.Id = dt.Rows[i]["user_id"].ToString();
                item.Name = dt.Rows[i]["user_name"].ToString();
                //职称，职务
                item.Sid = dt.Rows[i]["u_tech_post"].ToString() + "," + dt.Rows[i]["u_position"].ToString();
                cbxDoctor.Items.Add(item);
            }
            cbxDoctor.DisplayMember = "Name";
            cbxDoctor.ValueMember = "Id";
            cbxDoctor.SelectedIndex = 0;
        }
        /// <summary>
        /// 麻醉方式
        /// </summary>
        private void GetAllAnaes()
        {
            string Sql_Amaes = "select name,code from t_data_code  where type='55'";
            DataSet ds = App.GetDataSet(Sql_Amaes);
            cbxAnaes_Methodcode.Items.Add("--请选择--");
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count;i++ )
            {
                ListItem item = new ListItem();
                item.Id = dt.Rows[i]["code"].ToString();
                item.Name = dt.Rows[i]["name"].ToString();
                cbxAnaes_Methodcode.Items.Add(item);
            }
            cbxAnaes_Methodcode.DisplayMember = "Name";
            cbxAnaes_Methodcode.ValueMember = "Id";
            cbxAnaes_Methodcode.SelectedIndex = 0;
        }
        //指定
        private void btnDesignated_Click(object sender, EventArgs e)
        {
            if (cbxDoctor.SelectedIndex != 0)
            {
                ListItem item = cbxDoctor.SelectedItem as ListItem;
                lstDoctor.Items.Add(item);
                lstDoctor.DisplayMember = "Name";
                lstDoctor.ValueMember = "Id";
                cbxDoctor.Items.RemoveAt(cbxDoctor.SelectedIndex);
                cbxDoctor.SelectedIndex = 0;
            }
        }
        //收回
        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lstDoctor.SelectedIndex != -1)
            {
                ListItem items = lstDoctor.SelectedItem as ListItem;
                cbxDoctor.Items.Add(items);
                lstDoctor.Items.RemoveAt(lstDoctor.SelectedIndex);
                if (lstDoctor.Items.Count>0)
                    lstDoctor.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 获得当前类型的指定审批医师和审批医师
        /// </summary>
        private void GetTypeDoctor()
        {
            if (Oper_Id != "")
            {
                string Sql_Doctor = "select b.rela_doc_level, b.rela_appr_position,b.rela_appr_title from oper_def_icd9 a" +
                                    " inner join t_oper_level_rela b on a.oper_level = b.oper_level" +
                                    " where a.code='" + Oper_Id + "'";
                DataSet ds_All = App.GetDataSet(Sql_Doctor);
                DataTable dt_All = ds_All.Tables[0];
                //手术医师等级
                string level = dt_All.Rows[0]["rela_doc_level"].ToString();
                //职务
                string position = dt_All.Rows[0]["rela_appr_position"].ToString();
                //职称
                string title = dt_All.Rows[0]["rela_appr_title"].ToString();
                #region 手术医师
                string[] arr = level.Substring(0,level.Length-1).Split(';');
                string flag = "";
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 0; i < arr.Length;i++)
                {
                    //职称
                    string u_tech_post = arr[i].Substring(0,1);
                    //年资
                    string u_seniority =Convert_Seniority(arr[i].Substring(2, 1));
                    if (flag != u_tech_post)
                    {
                        flag = u_tech_post;
                        string Sql_All_Doctor = " union select user_id,user_name from t_userinfo where u_tech_post='" + u_tech_post + "' and u_seniority=" + u_seniority + "";
                        strBuilder.Append(Sql_All_Doctor);
                    }
                    else
                    {
                        string add = " or u_seniority=" + u_seniority + "";
                        strBuilder.Append(add);
                    }

                }
                string Sql_Select = strBuilder.ToString().Substring(6, strBuilder.Length - 6);
                DataSet ds = App.GetDataSet(Sql_Select);
                DataTable dt = ds.Tables[0];
                cbxDocLevel.DisplayMember = "user_name";
                cbxDocLevel.ValueMember = "user_id";
                cbxDocLevel.DataSource = dt.DefaultView;
                #endregion
                string[] arr_position = position.Split(';');
                string sql_position = "select user_id,user_name,u_position,u_tech_post from t_userinfo where ";
                StringBuilder strBulider_Position = new StringBuilder();
                strBulider_Position.Append(sql_position);
                /*
                 *职务 
                 */
                for (int n = 0; n < arr_position.Length - 1; n++)
                {
                    if (flag != "")
                    {
                        flag = "";
                        string u_position = "u_position='" + arr_position[n] + "'";
                        strBulider_Position.Append(u_position);
                    }
                    else
                    {
                        string u_position = " or u_position='" + arr_position[n] + "'";
                        strBulider_Position.Append(u_position);
                    }
                }
                /*
                 *职称 
                 */
                string[] arr_title = title.Split(';');
                for (int m = 0; m < arr_title.Length - 1;m++ )
                {
                    string u_title = " or u_tech_post='" + arr_title[m] + "'";
                    strBulider_Position.Append(u_title);
                }
                DataSet ds_Opper = App.GetDataSet(strBulider_Position.ToString());
                DataTable dt_Oper = ds_Opper.Tables[0];
                int x = 10, y = 6;
                for (int j = 0; j < dt_Oper.Rows.Count; j++)
                {
                    CheckBox chb = new CheckBox();
                    chb.AutoSize = true;
                    chb.Name = dt_Oper.Rows[j]["user_id"].ToString();
                    chb.Text = dt_Oper.Rows[j]["user_name"].ToString();
                    chb.Tag = dt_Oper.Rows[j]["u_tech_post"]+","+dt_Oper.Rows[j]["u_position"];
                    if (x <= pnlDoctor.Width)
                    {
                        chb.Location = new Point(x, y);
                    }
                    else
                    {
                        x = 10;
                        y += chb.Height;
                        chb.Location = new Point(x, y);
                    }
                    this.pnlDoctor.Controls.Add(chb);
                    x = x + 80;
                }
            }
            
        }

        private string Convert_Seniority(string str)
        { 
            string convert = "";
            if(str=="l")
            {
                convert ="57";
            }
            else if(str=="h")
            {
                convert ="56";
            }
            return convert;
        }
        //确定
        private void button14_Click(object sender, EventArgs e)
        {
            ListItem AnaesItem = cbxAnaes_Methodcode.SelectedItem as ListItem;
            StringBuilder strBuilder = new StringBuilder();
            //审批医生名称
            string Approval_DocNames = "";
            //审批医生id
            string Approval_DocIds = "";
            //指定审批医生名称
            string Designate_DocNames = "";
            //指定审批医生id
            string Designate_DocIds = "";
            Save(ref Approval_DocNames, ref Approval_DocIds, ref Designate_DocNames, ref Designate_DocIds);
            //手术类型
            string Oper_Type = "";
            //特殊手术类型
            string Special_Type = "";
            //麻醉方式
            string anaes_methodcode =AnaesItem .Id;
            //方式名称
            string anaes_methodname = AnaesItem.Name;
            //麻醉其他
            string anaes_othe = "";
            //其他名称
            string othe_name = "";
            //选择审批医师名称
            string approval_docnames="";
            //选择审批医师id
            string approval_docids="";
            //指定审批医生
            string designate_docnames = "";
            //指定审批医生的id
            string designate_docids = "";

            if (rdbtnNormal.Checked)
            {
                Oper_Type = rdbtnNormal.Text.Trim();
            }
            else if (rdbtnFast.Checked)
            {
                Oper_Type = rdbtnFast.Text.Trim();
            }
            else if (rdbtnSpecial.Checked)
            {
                Oper_Type = rdbtnSpecial.Text.Trim();
            }
            //插入之前先删除与该条申请审批记录有关的审批记录信息
            string Sql_Delete = "delete t_operationdoctor_approval where oper_type='"+Id+"'"+";";
            strBuilder.Append(Sql_Delete);
            /*
             *选择审批医师
             */
            if(pnlDoctor.Controls.Count>0)
            {
                for(int j=0;j<pnlDoctor.Controls.Count;j++)
                {
                    CheckBox chb = pnlDoctor.Controls[j] as CheckBox;
                    if(chb.Checked)
                    {
                        approval_docnames += chb.Text+",";
                        approval_docids += chb.Name + ",";
                        string Sql_Approval = "insert into t_operationdoctor_approval(oper_type,applystate_doc,approval_doctname,approval_doctid," +
                                              " appoval_content,approval_title,position,is_send,send_unit)"+
                                              " values('" + Id + "','未通过','" + chb.Text.Trim() + "','" + chb.Name + "','','" + chb.Tag.ToString().Split(',')[0] + "',"+
                                              "'" + chb.Tag.ToString().Split(',')[1] + "',N'','') "+";";
                        strBuilder.Append(Sql_Approval);
                    }
                }
            }
            /*
             *指定审批医师 
             */
            if(lstDoctor.Items.Count>0)
            {
                for(int i=0;i<lstDoctor.Items.Count;i++)
                {
                    ListItem item = lstDoctor.Items[i] as ListItem;
                    designate_docnames += item.Name+",";
                    designate_docids += item.Id+",";
                      string Sql_Approval = "insert into t_operationdoctor_approval(oper_type,applystate_doc,approval_doctname,approval_doctid,"+
                                              " approval_title,position,is_send,send_unit)"+
                                              " values('" + Id + "','未通过','" + item.Name+ "','" + item.Id + "','" + item.Sid.Split(',')[0] + "'," +
                                              "'" + item.Sid.Split(',')[1] + "',N'','') " + ";";
                      strBuilder.Append(Sql_Approval);
                }
            }
            /*
             *审批申请 
             */
            string Sql_Update = "update t_operapproval_application set oper_type='" + Oper_Type + "',special_typeids='',operation_date=to_timestamp('" + dtpOperation_Date.Value.ToString() + "','yyyy-mm-dd HH24:mi:ss')," +
                                "display='" + txtDisplay.Text.Trim() + "',operation_docname='"+cbxDocLevel.Text+"',"+
                                "operation_docid='"+cbxDocLevel.SelectedValue+"',binqi_opernotice='" + txtBinqi_Opernotice.Text.Trim() + "',"+
                                "oper_plan='" + txtOper_Plan.Text.Trim() + "',anaes_methodcode='" + anaes_methodcode + "',"+
                                "anaes_methodname='" + anaes_methodname + "',anaes_othe='" + anaes_othe + "',othe_name='" + othe_name + "',"+
                                "opery_date=to_timestamp('" + dtpOpery_Date.Value.ToString() + "','yyyy-mm-dd HH24:mi:ss')," +
                                "patients_views='" + txtPatients_Views.Text.Trim() + "',familydan_views='" + txtFamilydan_Views.Text.Trim() + "',"+
                                "approval_docnames='" + approval_docnames + "',approval_docids='" + approval_docids + "'," +
                                "designate_docnames='" + designate_docnames + "',designate_docids='" + designate_docids + "',"+
                                "apply_docname='"+App.UserAccount.UserInfo.User_name+"',apply_docid='"+App.UserAccount.UserInfo.User_id+"'," +
                                "apply_date=to_timestamp('" + dtpApply_Date.Value.ToString() + "','yyyy-mm-dd HH24:mi:ss') where code_icd9 = '" + Oper_Id + "'";
            strBuilder.Append(Sql_Update);
            string[] sqls = strBuilder.ToString().Split(';');
            int count = 0;
            try
            {
                count = App.ExecuteBatch(sqls);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message) ;
            }
            if(count>0)
            {
                App.Msg("操作成功！");
            }

        }
        //普通
        private void rdbtnNormal_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnNormal.Checked)
            {
                pnlSpecial.Enabled = false;
                cbxDoctor.Enabled = false;
                btnDesignated.Enabled = false;
                btnBack.Enabled = false;
                lstDoctor.Enabled = false;
                pnlDoctor.Enabled = true;
            }
        }
        //急诊
        private void rdbtnFast_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbtnFast.Checked)
            {
                pnlSpecial.Enabled = false;
                cbxDoctor.Enabled = true;
                btnDesignated.Enabled = true;
                btnBack.Enabled = true;
                lstDoctor.Enabled = true;
                pnlDoctor.Enabled = true;
            }
        }
        //特殊
        private void rdbtnSpecial_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnSpecial.Checked)
            {
                cbxDoctor.Enabled = false;
                btnDesignated.Enabled = false;
                btnBack.Enabled = false;
                lstDoctor.Enabled = false;
                pnlDoctor.Enabled = false;
                pnlSpecial.Enabled = true;
            }
        }
        /// <summary>
        /// 获得页面输入的审批医生，指定审批医生
        /// </summary>
        /// <param name="Approval_DocNames">审批医生名称</param>
        /// <param name="Approval_DocIds">审批医生id</param>
        /// <param name="Designate_DocNames">指定审批医生名称</param>
        /// <param name="Designate_DocIds">指定审批医生id</param>
        private void Save(ref string Approval_DocNames, ref string Approval_DocIds,
                          ref string Designate_DocNames, ref string Designate_DocIds)
        { 
            if(rdbtnNormal.Checked)        //普通
            {
                if(pnlDoctor.Controls.Count>0)
                {
                    for (int i = 0; i < pnlDoctor.Controls.Count;i++)
                    {
                        Approval_DocNames += pnlDoctor.Controls[i].Text+",";
                        Approval_DocIds += pnlDoctor.Controls[i].Name+",";
                    }
                }
            }
            else if (rdbtnFast.Checked)  //急诊
            {
                /*
                 *审批医生 
                 */
                if (pnlDoctor.Controls.Count > 0)
                {
                    for (int i = 0; i < pnlDoctor.Controls.Count; i++)
                    {
                        Approval_DocNames += pnlDoctor.Controls[i].Text + ",";
                        Approval_DocIds += pnlDoctor.Controls[i].Name + ",";
                    }
                }
                /*
                 * 指定审批医生
                 */
                if (lstDoctor.Controls.Count > 0)
                {
                    for (int j = 0; j < lstDoctor.Items.Count; j++)
                    {
                        ListItem item = lstDoctor.Items[j] as ListItem;
                        Designate_DocNames += item.Name + ",";
                        Designate_DocIds += item.Id + ",";
                    }
                }
            }
            else if(rdbtnSpecial.Checked)    //特殊
            { 
                
            
            }
        }

        private void txtOperation_DocName_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 获得审批审批列表
        /// </summary>
        /// <returns></returns>
        private DataTable GetApprovalList()
        {
            string Sql_List = "select distinct(a.ID), a.operation_date 手术日期,a.desioper_names 手术名称,a.operation_docname 手术医生,a.apply_date 申报时间,"+
                              " a.apply_docname 申请人,b.applystate_doc 状态,a.code_icd9,a.apply_docid,a.operation_docid from t_operapproval_application a"+
                              " inner join t_operationdoctor_approval b on a.id = b.oper_type";
            DataSet ds = App.GetDataSet(Sql_List);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        //修改
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsSuccess())  //通过
            {
                App.Msg("审批已经通过不能在修改！");
            }
            else
            {
                button14_Click(sender, e);
            }

        }
        //申请状态是否通过
        private bool IsSuccess()
        {
            bool flag = true;
            if(flgView.RowSel>0)
            {
                string Sql_State = " select b.applystate_doc from  t_operapproval_application a "+
                                   " inner join t_operationdoctor_approval b on a.id = b.oper_type"+
                                   " where a.id='" + flgView[flgView.RowSel,"id"]+ "'";
                DataSet ds_Saste = App.GetDataSet(Sql_State);
                DataTable dt_State = ds_Saste.Tables[0];
                for (int i = 0; i < dt_State.Rows.Count;i++ )
                {
                    string state = dt_State.Rows[i]["applystate_doc"].ToString();
                    if(state.Equals("未通过"))
                    {
                        flag = false;
                        break;
                    }
                }
            }
            return flag;
        }

        private void frmSurgery_Apply_Load(object sender, EventArgs e)
        {

        }
    }
}