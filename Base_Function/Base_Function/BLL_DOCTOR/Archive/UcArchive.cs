using Bifrost;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_DOCTOR.Archive
{
    public partial class UcArchive : UserControl
    {
        public UcArchive()
        {
            InitializeComponent();
            txtOperator.Text = App.UserAccount.UserInfo.User_name;
        }
        /// <summary>
        /// 绑定到列表
        /// </summary>
        public void DataBind()
        {
            string sql = null;
            if (!chkYgdbr.Checked)
            {
                if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                {
                    /*
                     * 护士归档
                     */
                    sql = "select a.id,a.patient_name 姓名,a.pid 住院号,a.sick_bed_no 床号," +
                          " case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=0 ) when 1 then '已整理' else '未整理' end 护理归档标志," +
                          " (select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=0) 护理归档时间," +
                          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=0) 归档护士," +
                          " case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=1) when 1 then '已整理' else '未整理' end 医生归档标志," +
                          " (select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=1) 医生归档时间," +
                          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=1) 归档医生" +
                          " from  t_in_patient a  where a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id +
                          " and a.document_state is null  and a.id in (select dd.patient_id from (select count(-1) num,patient_id from T_DOC_NEATEN where neaten_flag=1 group by patient_id) dd where dd.num=2)";
                }
                else
                {
                    sql = "select a.id,a.patient_name 姓名,a.pid 住院号,a.sick_bed_no 床号," +
                          " case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=0 ) when 1 then '已整理' else '未整理' end 护理归档标志," +
                          " (select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=0) 护理归档时间," +
                          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=0) 归档护士," +
                          " case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=1) when 1 then '已整理' else '未整理' end 医生归档标志," +
                          " (select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=1) 医生归档时间," +
                          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=1) 归档医生" +
                          " from  t_in_patient a  where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id +
                          " and a.document_state is null and a.id in (select dd.patient_id from (select count(-1) num,patient_id from T_DOC_NEATEN where neaten_flag=1 group by patient_id) dd where dd.num=2)";
                }
            }
            else
            {
                if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                {
                    /*
                     * 护士归档
                     */
                    sql = "select a.id,a.patient_name 姓名,a.pid 住院号,a.sick_bed_no 床号," +
                          " case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=0 ) when 1 then '已整理' else '未整理' end 护理归档标志," +
                          " (select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=0) 护理归档时间," +
                          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=0) 归档护士," +
                          " case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=1) when 1 then '已整理' else '未整理' end 医生归档标志," +
                          " (select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=1) 医生归档时间," +
                          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=1) 归档医生" +
                          " from  t_in_patient a  where a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id +
                          " and a.document_state is not null  and a.id in (select dd.patient_id from (select count(-1) num,patient_id from T_DOC_NEATEN where neaten_flag=1 group by patient_id) dd where dd.num=2)";
                }
                else
                {
                    sql = "select a.id,a.patient_name 姓名,a.pid 住院号,a.sick_bed_no 床号," +
                          " case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=0 ) when 1 then '已整理' else '未整理' end 护理归档标志," +
                          " (select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=0) 护理归档时间," +
                          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=0) 归档护士," +
                          " case (select neaten_flag from T_DOC_NEATEN b where b.patient_id=a.id and b.doc_neaten_type=1) when 1 then '已整理' else '未整理' end 医生归档标志," +
                          " (select c1.neaten_time from T_DOC_NEATEN c1 where c1.patient_id=a.id and c1.doc_neaten_type=1) 医生归档时间," +
                          " (select c.user_name from T_DOC_NEATEN c2 inner join t_userinfo c on c2.collate=c.user_id where c2.patient_id=a.id and c2.doc_neaten_type=1) 归档医生" +
                          " from  t_in_patient a  where a.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id +
                          " and a.document_state is not null and a.id in (select dd.patient_id from (select count(-1) num,patient_id from T_DOC_NEATEN where neaten_flag=1 group by patient_id) dd where dd.num=2)";
                }
            }
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                DataColumn dc = new DataColumn("是否归档", typeof(bool));
                dc.DefaultValue = false;
                dt.Columns.Add(dc);
                flgView.fg.DataSource = dt.DefaultView;
                flgView.fg.Cols["是否归档"].Move(1);
                flgView.fg.Cols["是否归档"].AllowEditing = true;
                flgView.fg.Cols[2].Visible = false;
                flgView.fg.Cols[2].AllowEditing = false;
                flgView.fg.Cols[3].AllowEditing = false;
                flgView.fg.Cols[4].AllowEditing = false;
                flgView.fg.Cols[5].AllowEditing = false;
                flgView.fg.Cols[6].AllowEditing = false;
                flgView.fg.Cols[7].AllowEditing = false;
                flgView.fg.Cols[8].AllowEditing = false;
                flgView.fg.Cols[9].AllowEditing = false;
                flgView.fg.Cols[10].AllowEditing = false;
                flgView.fg.Cols["id"].Visible = false;
            }
        }

        private void UcArchive_Load(object sender, EventArgs e)
        {
            DataBind();
        }
        //归档封存
        private void btnSave_Click(object sender, EventArgs e)
        {
            int count = Update();
            if (count > 0)
            {
                //DataBind();
                App.Msg("封存成功！");
                DataBind();
            }
        }

        private int Update()
        {
            int count = 0;
            try
            {
                
                StringBuilder strBuilder = new StringBuilder();
                for (int i = 1; i < flgView.fg.Rows.Count; i++)
                {
                    bool flag = Convert.ToBoolean(flgView.fg[i, 1].ToString());
                    if (flag)
                    {
                        string pid = flgView.fg[i, "住院号"].ToString();
                        string patient_Id = flgView.fg[i, "id"].ToString();
                        string SqlActions_History_Delete = "delete from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + patient_Id + "'";
                        string SqlActions_History = "insert into T_INHOSPITAL_ACTION_HISTORY select * from t_inhospital_action where patient_id='" + patient_Id + "' order by id";
                        string SqlActions = "delete from t_inhospital_action where patient_id='" + patient_Id + "'";
                        string sql = "update t_in_patient  set document_state='1',document_time=sysdate,exe_document_time=sysdate,DOCUMENT_OPER_ID=" + App.UserAccount.UserInfo.User_id + " where id='" + patient_Id + "'";
                        strBuilder.Append(SqlActions_History_Delete + ";");
                        strBuilder.Append(SqlActions_History + ";");
                        
                        strBuilder.Append(SqlActions + ";");
                        strBuilder.Append(sql + ";");
                    }
                }
                string[] arr = strBuilder.ToString().Substring(0, strBuilder.Length - 1).Split(';');
                count = App.ExecuteBatch(arr);
            }
            catch (System.Exception ex)
            {

            }
            return count;
        }
        //自动整理+归档
        //private int Update(string pid, string patient_Id)
        //{
        //    int count = 0;
        //    try
        //    {
        //        StringBuilder strBuilder = new StringBuilder();
        //        //整理
        //        string SqlNeaten_Nurse = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,collate,patient_Id)" +
        //                    " values ('" + pid + "',0,1,sysdate," + App.UserAccount.UserInfo.User_id + "," + patient_Id + ")";

        //        string SqlNeaten_Doctor = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,collate,patient_Id)" +
        //                        " values ('" + pid + "',1,1,sysdate," + App.UserAccount.UserInfo.User_id + "," + patient_Id + ")";
        //        //归档操作
        //        string SqlActions_History_Delete = "delete from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + patient_Id + "'";
        //        string SqlActions_History = "insert into T_INHOSPITAL_ACTION_HISTORY select ID,SID,SAID,TARGET_SID,TARGET_SAID,PID,ACTION_TYPE,ACTION_STATE,HAPPEN_TIME,BED_ID,TNG_ID,DOCTOR_ID,NURSE_ID,OPERATE_ID,NEXT_ID,PREVIEW_ID,patient_id from t_inhospital_action where patient_id='" + patient_Id + "' order by id";
        //        string SqlActions = "delete from t_inhospital_action where patient_id='" + patient_Id + "'";
        //        string sql = "update t_in_patient  set document_state='1',document_time=sysdate,DOCUMENT_OPER_ID=" + App.UserAccount.UserInfo.User_id + " where id='" + patient_Id + "'";

        //        strBuilder.Append(SqlNeaten_Nurse +";");
        //        strBuilder.Append(SqlNeaten_Doctor + ";");
        //        strBuilder.Append(SqlActions_History + ";");
        //        strBuilder.Append(SqlActions + ";");
        //        strBuilder.Append(sql + ";");

        //        string[] arr = strBuilder.ToString().Substring(0, strBuilder.Length - 1).Split(';');
        //        count = App.ExecuteBatch(arr);
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //    return count;
        //}


        private void btnAll_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < flgView.fg.Rows.Count; i++)
            {
                flgView.fg[i, 1] = "True";
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < flgView.fg.Rows.Count; i++)
            {
                flgView.fg[i, 1] = "False";
            }
        }

        private void btnFan_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < flgView.fg.Rows.Count; i++)
            {
                if (flgView.fg[i, 1].ToString() != "")
                {
                    bool flag = Convert.ToBoolean(flgView.fg[i, 1].ToString());
                    if (flag)
                    {
                        flgView.fg[i, 1] = "False";
                    }
                    else
                    {
                        flgView.fg[i, 1] = "True";
                    }
                }
                else
                {
                    flgView.fg[i, 1] = "True";
                }

            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataBind();
        }
    }
}
