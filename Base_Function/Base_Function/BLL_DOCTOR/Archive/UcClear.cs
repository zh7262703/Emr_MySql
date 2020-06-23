using Bifrost;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_DOCTOR.Archive
{
    /// <summary>
    /// 文书的归档
    /// </summary>
    public partial class UcClear : UserControl
    {
        //private int selrow = 0; //当前选中行

        /// <summary>
        /// 构造函数
        /// </summary>
        public UcClear()
        {
            InitializeComponent();
            cbxState.SelectedIndex = 0;
        }

        private void UcClear_Load(object sender, EventArgs e)
        {
            DataBind();
        }
        /// <summary>
        /// 绑定到列表
        /// </summary>
        public void DataBind()
        {
            string sql=null;
            if (App.UserAccount.CurrentSelectRole.Role_type=="N")
            {
                

                /*
                 * 护士归档
                 */
                sql = "select  distinct(a.pid) 住院号,a.patient_name 姓名,a.id," +
                             "case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=0 ) when 1 then '已整理' else '未整理' end  护理归档标志," +
                             "(select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=0) 护理归档时间,a.leave_time 出院时间," +
                             "(select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=0) 操作人 from t_in_patient a" +
                             " left join t_doc_neaten b on a.id=b.patient_id" +
                             " left join t_userinfo c on c.user_id = b.collate" +
                             " inner join t_inhospital_action d on a.id = d.patient_id" +
                             " where a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and a.document_state is null"+
                             " and d.action_state=3 and d.id in (select max(id) from t_inhospital_action group by patient_id)";
            } 
            else
            {
                /*
                 * 医生归档
                 */
                sql = "select  distinct(a.pid) 住院号,a.patient_name 姓名,a.id," +
                          "case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=1) when 1 then '已整理' else '未整理' end  医生归档标志," +
                          "(select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=1) 医生归档时间,a.leave_time 出院时间," +
                          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=1) 操作人 from t_in_patient a" +
                          " left join t_doc_neaten b on a.id=b.patient_id" +
                          " left join t_userinfo c on c.user_id = b.collate" +
                          " inner join t_inhospital_action d on a.id = d.patient_id" +
                          " where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.document_state is null"+
                          " and d.action_state=3 and d.id in (select max(id) from t_inhospital_action group by patient_id)";
            }
            DataSet ds = App.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            DataColumn dc = new DataColumn("是否整理", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);
            flgView.fg.DataSource = dt.DefaultView;
            flgView.fg.Cols["是否整理"].Move(1);
            flgView.fg.Cols["是否整理"].AllowEditing = true;
            flgView.fg.Cols[2].AllowEditing = false;
            flgView.fg.Cols[3].AllowEditing = false;
            flgView.fg.Cols[4].AllowEditing = false;
            flgView.fg.Cols[5].AllowEditing = false;
            flgView.fg.Cols[6].AllowEditing = false;
            flgView.fg.Cols[7].AllowEditing = false;
            flgView.fg.Cols["id"].Visible = false;
            //flgView.fg.Cols[8].AllowEditing = false;

        }
        /// <summary>
        /// 确认整理
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (flgView.fg.RowSel > 0)
            {
                string pid = flgView.fg[flgView.fg.RowSel, "住院号"].ToString();
                string patient_Id = flgView.fg[flgView.fg.RowSel, "id"].ToString(); 
                string type = "";
                if (App.UserAccount.CurrentSelectRole.Role_type=="N")
                {
                    type = "0";
                } 
                else
                {
                    type = "1";
                }
                bool flag = IsExits(patient_Id, type);
                if (!flag)
                {
                    int count = Add();
                    if (count > 0)
                    {
                        DataBind();
                        App.Msg("该病人归档成功");
                    }
                }
                else
                {
                    flgView.fg[flgView.fg.RowSel, 1] = "False";
                    App.Msg("该病人已归档，不需要再归档啦!");
                }

            }

        }
        private int Add()
        {
            int count = 0;
            try
            {
                bool flag = Convert.ToBoolean(flgView.fg[flgView.fg.RowSel, 1].ToString());
	            if (flag)
	            {
	                string pid=flgView.fg[flgView.fg.RowSel,"住院号"].ToString();
                    string patient_Id = flgView.fg[flgView.fg.RowSel, "id"].ToString(); 
                    //string Issucess = ConvetTostring(flgView.fg[flgView.fg.RowSel, 4].ToString());
	                string sql = null;
	                if (App.UserAccount.CurrentSelectRole.Role_type=="N")
	                {
                        sql = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,collate,patient_Id)" +
                                    " values ('" + pid + "',0,1,sysdate," + App.UserAccount.UserInfo.User_id + ","+patient_Id+")";
	                }
	                else
	                {
                        sql = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,collate,patient_Id)" +
                                    " values ('" + pid + "',1,1,sysdate," + App.UserAccount.UserInfo.User_id + ","+patient_Id+")";
	                }
	                count = App.ExecuteSQL(sql);
	
	            }
            }
            catch (System.Exception ex)
            {
            	
            }
            return count;
        }

        private string ConvetTostring(string str )
        {
            string str2="";
            if(str=="未整理")
            {
                str2 = "0";
            }
            else
            {
                str2="1";
            }
            return str2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            int count = Update();
            if(count>0)
            {
                App.Msg("取消归档成功！");
                DataBind();
                //flgView.fg.RowSel = selrow;
            }
        }
        private int Update()
        {
             int count = 0;
             string sql="";
             try
             {	          
                string pid = flgView.fg[flgView.fg.RowSel, "住院号"].ToString();
                string patient_Id = flgView.fg[flgView.fg.RowSel, "id"].ToString(); 
                //selrow = flgView.fg.RowSel;
	            if (App.UserAccount.CurrentSelectRole.Role_type=="N")
	            {
                    sql = "delete from T_DOC_NEATEN where patient_Id='" + patient_Id + "' and doc_neaten_type=0";
	            } 
	            else
	            {
                    sql = "delete from T_DOC_NEATEN where patient_Id='" + patient_Id + "' and doc_neaten_type=1";
	            }
	            count = App.ExecuteSQL(sql);
             }
             catch (System.Exception ex)
             {
                 App.MsgErr("取消整理操作失败。" + ex.Message);
             }
             return count;
        }

        private void btnBatch_Click(object sender, EventArgs e)
        {
           int count = AddBatch();
            if(count>0)
            {
                App.Msg("批量整理成功！");
                DataBind();
            }          
        }
        /// <summary>
        /// 批量整理
        /// </summary>
        /// <returns></returns>
        private int AddBatch()
        {
            int count = 0;
            StringBuilder strbuilder = new StringBuilder();
            try
            {
                if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                {
                    for (int i = 1; i < flgView.fg.Rows.Count; i++)
                    {
                        if (flgView.fg[i, 1].ToString() != "")
                        {
                            bool flag = Convert.ToBoolean(flgView.fg[i, 1].ToString());
                            if (flag)
                            {
                                string pid = flgView.fg[i, "住院号"].ToString();
                                string patient_Id = flgView.fg[i, "id"].ToString();
                                string type ="0";
                                bool isexit = IsExits(patient_Id, type);
                                if (!isexit)
                                {
                                    string sql = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,collate,patient_Id)" +
                                                " values ('" + pid + "',0,1,sysdate," + App.UserAccount.UserInfo.User_id + "," + patient_Id + ")";
                                    strbuilder.Append(sql + ";");
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < flgView.fg.Rows.Count; i++)
                    {
                        if (flgView.fg[i, 1].ToString() != "")
                        {
                            bool flag = Convert.ToBoolean(flgView.fg[i, 1].ToString());
                            if (flag)
                            {
                                string pid = flgView.fg[i, "住院号"].ToString();
                                string patient_Id = flgView.fg[i, "id"].ToString();
                                string type = "1";
                                bool isexit = IsExits(patient_Id, type);
                                if (!isexit)
                                {
                                    string sql = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,collate,patient_Id)" +
                                                 " values ('" + pid + "',1,1,sysdate," + App.UserAccount.UserInfo.User_id + "," + patient_Id + ")";
                                    strbuilder.Append(sql + ";");
                                }
                                else
                                {
                                    return 0;
                                }
                            }
                        }
                    }
                }
                string[] arr = strbuilder.ToString().Substring(0,strbuilder.Length-1).Split(';');
                count = App.ExecuteBatch(arr);
            }
            catch (System.Exception ex)
            {

            }
            return count;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Selected();
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        private void Selected()
        {
            try
            {
                StringBuilder strBuild = new StringBuilder();
                string sql = null;
                if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                {

                    ///*
                    // * 护士归档
                    // */
                    //sql = "select  distinct(a.pid) 住院号,a.patient_name 姓名," +
                    //             "case (select neaten_flag from T_DOC_NEATEN b where b.pid=a.pid and b.doc_neaten_type=0 ) when 1 then '已整理' else '未整理' end  护理归档标志," +
                    //             "(select c1.neaten_time from T_DOC_NEATEN c1 where c1.pid=a.pid and c1.doc_neaten_type=0) 护理归档时间,a.leave_time 出院时间," +
                    //             "(select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.pid=a.pid and c2.doc_neaten_type=0) 操作人 from t_in_patient a" +
                    //             " left join t_doc_neaten b on a.pid=b.pid" +
                    //             " left join t_userinfo c on c.user_id = b.collate" +
                    //             " where a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and a.document_state is null  ";

                    /*
                * 护士归档
                */
                    sql = "select  distinct(a.pid) 住院号,a.patient_name 姓名,a.id" +
                                 "case (select neaten_flag from T_DOC_NEATEN b where b.patient_Id=a.id and b.doc_neaten_type=0 ) when 1 then '已整理' else '未整理' end  护理归档标志," +
                                 "(select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_Id=a.id and c1.doc_neaten_type=0) 护理归档时间,a.leave_time 出院时间," +
                                 "(select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_Id=a.id and c2.doc_neaten_type=0) 操作人 from t_in_patient a" +
                                 " left join t_doc_neaten b on a.id=b.patient_Id" +
                                 " left join t_userinfo c on c.user_id = b.collate" +
                                 " inner join t_inhospital_action d on a.id = d.patient_Id" +
                                 " where a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and a.document_state is null" +
                                 " and d.action_state=3 and d.patient_Id in (select max(id) from t_inhospital_action group by patient_Id)";
                }
                else
                {
                    ///*
                    // * 医生归档
                    // */
                    //sql = "select  distinct(a.pid) 住院号,a.patient_name 姓名," +
                    //          "case (select neaten_flag from T_DOC_NEATEN b where b.pid=a.pid and b.doc_neaten_type=1) when 1 then '已整理' else '未整理' end  医生归档标志," +
                    //          "(select c1.neaten_time from T_DOC_NEATEN c1 where c1.pid=a.pid and c1.doc_neaten_type=1) 医生归档时间,a.leave_time 出院时间," +
                    //          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.pid=a.pid and c2.doc_neaten_type=1) 操作人 from t_in_patient a" +
                    //          " left join t_doc_neaten b on a.pid=b.pid" +
                    //          " left join t_userinfo c on c.user_id = b.collate" +
                    //          " where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.document_state is null  ";

                    /*
                   * 医生归档
                   */
                    sql = "select  distinct(a.pid) 住院号,a.patient_name 姓名,a.id" +
                              "case (select neaten_flag from T_DOC_NEATEN b where b.patient_Id=a.id and b.doc_neaten_type=1) when 1 then '已整理' else '未整理' end  医生归档标志," +
                              "(select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_Id=a.id and c1.doc_neaten_type=1) 医生归档时间,a.leave_time 出院时间," +
                              " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_Id=a.id and c2.doc_neaten_type=1) 操作人 from t_in_patient a" +
                              " left join t_doc_neaten b on a.id=b.patient_Id" +
                              " left join t_userinfo c on c.user_id = b.collate" +
                              " inner join t_inhospital_action d on a.id = d.patient_Id" +
                              " where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and a.document_state is null" +
                              " and d.action_state=3 and d.patient_Id in (select max(id) from t_inhospital_action group by patient_Id)";
                }
                strBuild.Append(sql);
                string leave_time = " and d.happen_time between to_timestamp('" + dtpStart.Value + "','yyyy-MM-dd HH24:mi:ss') and to_timestamp('" + dtpEnd.Value + "','yyyy-MM-dd HH24:mi:ss')";
                strBuild.Append(leave_time);
                if (txtPid.Text.Trim() != "")
                {
                    string pid = "and a.pid='" + txtPid.Text.Trim() + "'";
                    strBuild.Append(pid);
                }
                if (cbxState.SelectedIndex != 0)
                {
                    int num = 0;
                    if (cbxState.SelectedText == "已整理")
                    {
                        num = 1;
                    }
                    string flag = "and b.neaten_flag=" + num + "";
                    strBuild.Append(flag);
                }
                DataSet ds = App.GetDataSet(strBuild.ToString());
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    dt.Columns.Add("是否整理", typeof(bool));
                    flgView.fg.DataSource = dt.DefaultView;
                    flgView.fg.Cols["是否整理"].Move(1);
                    flgView.fg.Cols["是否整理"].AllowEditing = true;
                    flgView.fg.Cols[2].AllowEditing = false;
                    flgView.fg.Cols[3].AllowEditing = false;
                    flgView.fg.Cols[4].AllowEditing = false;
                    flgView.fg.Cols[5].AllowEditing = false;
                    flgView.fg.Cols[6].AllowEditing = false;
                    flgView.fg.Cols[7].AllowEditing = false;
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 判断当前病人是否已经整理文书
        /// </summary>
        /// <param name="patient_Id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private bool IsExits(string patient_Id, string type)
        {
            bool flag = false;
            try
            {
	            int count = 0;
                string sql = "select count(-1) num from T_DOC_NEATEN where patient_Id='" + patient_Id + "' and doc_neaten_type=" + type + " and neaten_flag=1";
	            count =Convert.ToInt32(App.ReadSqlVal(sql,0,"num"));
	            if (count>0)
	            {
	                flag = true;
	            }
            }
            catch (System.Exception ex)
            {
            	
            }
            return flag;
        }

    }
}
