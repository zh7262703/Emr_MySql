using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_FOLLOW.Element;
using System.IO;

namespace Base_Function.BLL_FOLLOW.DispalayList
{
    public partial class ucFollowVisite : UserControl
    {
        private string SelectedId = "";
        Class_FollowInfo[] myInfo;
        private DataGridViewRow SelectedRow;
        public ucFollowVisite()
        {
            InitializeComponent();
            IniShema();
        }
        /// <summary>
        /// 初始化随访方案ComboBox
        /// </summary>
        public void IniShema()
        {
            DataSet desDs = null;
            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                string User_SickArea_Id = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                string qurySickArea = "select * from t_follow_info where exec_sickarea='" + User_SickArea_Id + "' or exec_sickarea like '%," + User_SickArea_Id + ",%' or exec_sickarea like '," + User_SickArea_Id + "%' or exec_sickarea like '" + User_SickArea_Id + ",%' or exec_sickarea='0'";
                desDs = App.GetDataSet(qurySickArea);
            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {
                string User_Section_Id = App.UserAccount.CurrentSelectRole.Section_Id;
                string qurySection = "select * from t_follow_info where exec_sections='" + User_Section_Id + "' or exec_sections like '%," + User_Section_Id + ",%' or exec_sections like '," + User_Section_Id + "%' or exec_sections like '" + User_Section_Id + ",%' or exec_sections='0'";
                desDs = App.GetDataSet(qurySection);
            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
               
                string qurySection = "select * from t_follow_info where  exec_sections='0' and rownum<200";
                desDs = App.GetDataSet(qurySection);
            }
            myInfo = GetInfo(desDs);
            if (myInfo != null&&myInfo.Length!=0)
            {
                for (int i = 0; i < myInfo.Length; i++)
                    cmbFollowInfo.Items.Add(myInfo[i]);
                cmbFollowInfo.DisplayMember = "Follow_Name";
                cmbFollowInfo.ValueMember = "id";
                cmbFollowInfo.SelectedIndex = 0;
            }
            else
                cmbFollowInfo.DataSource = null;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DisplayPatients("");
        }
        /// <summary>
        /// 显示符合条件的病人
        /// </summary>
        public void DisplayPatients(string Filter)
        {
            this.Cursor = Cursors.WaitCursor;
            Class_FollowInfo Info = cmbFollowInfo.SelectedItem as Class_FollowInfo;
            DataTable dsTb;
            dsTb = SelectDataSet(Info);
            if (Filter != "")
                dsTb=FilterDataSet(Filter, dsTb);
            if (dsTb != null)
            {
                if (dsTb.Rows.Count != 0)
                {
                    dgvPatients.DataSource = dsTb.DefaultView;
                    dgvPatients.Columns["参考时间"].Visible = false;
                    dgvPatients.Columns["科室号"].Visible = false;
                    dgvPatients.Columns["医生号"].Visible = false;
                }
                else
                    dgvPatients.DataSource = null;
            }
            else
                dgvPatients.DataSource = null;
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 筛选结果集
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="Tb"></param>
        public DataTable FilterDataSet(string filter, DataTable Tb)
        {
            if (Tb.Rows.Count != 0)

            {
                 DataRow[] Temp;
                 if (filter.IndexOf("ID") != -1)
                 {
                     string Ids = filter.Substring(2, filter.IndexOf(":") - 2);
                     Temp = Tb.Select("病人id in (" + Ids + ")");
                 }
                 else
                     Temp = Tb.Select();
                for(int i=Temp.Length-1;i>-1;i--)
                {
                    if (filter.IndexOf("NEXT") != -1)
                    {
                        string Stime = filter.Substring(filter.IndexOf("NEXT")+4, filter.IndexOf(":TO:")-filter.IndexOf("NEXT")-4);
                        string Etime = filter.Substring(filter.IndexOf(":TO:")+4);
                        if (string.Compare(Temp[i]["下次随访时间"].ToString(), Stime) == -1 || string.Compare(Temp[i]["下次随访时间"].ToString(), Etime) == 1)
                        {
                            Temp[i].Delete();
                            continue;
                        }
                    }
                    if (filter.IndexOf("OUTOFDATE") != -1)
                    {
                        if (Temp[i]["是否逾期"].ToString() == "是")
                        {
                            Temp[i].Delete();
                            continue;
                        }
                    }
                    else
                    {
                        if (Temp[i]["是否逾期"].ToString() == "否")
                        {
                            Temp[i].Delete();
                            continue;
                        }
                    }



                }

            }
            return null;
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        public DataTable SelectDataSet(Class_FollowInfo selectedInfo)
        {
            if (selectedInfo == null)
            {
                return null;
            }
            //从当前选择的解决方案中获取筛选信息
            int sMethod = 0;    //参考开始时间
            switch (selectedInfo.Startingtime)
            {
                case "出院时间":
                    sMethod = 1;
                    break;
                case "入院时间":
                    sMethod = 2;
                    break;
                case "手术时间":
                    sMethod = 3;
                    break;
                default:
                    sMethod = 4;
                    break;
            }
            string ReSpell = "";
            string pIds = "";
            //筛选手术
            string opeTemp;
            try
            {
                if (selectedInfo.Icd9codes != "")
                {
                    ReSpell = ReArrange(selectedInfo.Icd9codes);
                    opeTemp = "select distinct(patient_id) from COVER_OPERATION where oper_code in (" + ReSpell + ") and oper_code is not null";
                    DataTable ds_opeTemp = App.GetDataSet(opeTemp).Tables[0];
                    if (ds_opeTemp.Rows.Count != 0)
                        for (int i = 0; i < ds_opeTemp.Rows.Count; i++)
                        {
                            if (pIds == "")
                                pIds = ds_opeTemp.Rows[i]["patient_id"].ToString();
                            else
                                pIds += "," + ds_opeTemp.Rows[i]["patient_id"].ToString();
                        }
                    else
                        return null;
                }

                string diagTemp;
                //筛选诊断
                if (selectedInfo.Icd10codes != "")
                {
                    ReSpell = ReArrange(selectedInfo.Icd10codes);
                    if (pIds != "")
                    {
                        if (selectedInfo.Ismaindiag == "Y")
                        {
                            diagTemp = "select distinct patient_id from COVER_DIAGNOSE where icd10code in (" + ReSpell + ") and TYPE='M' and inpatient_id in (" + pIds + ") and icd10code is not null";
                        }
                        else
                            diagTemp = "select distinct patient_id from COVER_DIAGNOSE where icd10code in (" + ReSpell + ")  and inpatient_id in (" + pIds + ") and icd10code is not null and type not in ('E','S','P')";
                        pIds = "";
                    }
                    else
                    {
                        if (selectedInfo.Ismaindiag == "Y")
                            diagTemp = "select distinct(patient_id) from COVER_DIAGNOSE where icd10code in (" + ReSpell + ") and TYPE='M' and icd10code is not null";
                        else
                            diagTemp = "select distinct patient_id from COVER_DIAGNOSE where icd10code in (" + ReSpell + ")  and icd10code is not null";
                    }
                    DataTable ds_diagTemp = App.GetDataSet(diagTemp).Tables[0];
                    if (ds_diagTemp.Rows.Count != 0)
                    {
                        for (int i = 0; i < ds_diagTemp.Rows.Count; i++)
                        {
                            if (pIds == "")
                                pIds = ds_diagTemp.Rows[i]["patient_id"].ToString();
                            else
                                pIds += "," + ds_diagTemp.Rows[i]["patient_id"].ToString();
                        }

                    }
                    else
                        return null;
                }
                string paTemp = "";
                if (sMethod == 1)
                {
                    //筛选科室
                    paTemp = "select ''序号,t.id 病人ID,t.pid 住院号,t.patient_name 病人姓名,t.age||t.age_unit  年龄,t.section_id 科室号,t.section_name 科室,t.sick_doctor_id 医生号,t.sick_doctor_name 管床医生,(select name from COVER_DIAGNOSE c where c.patient_id=t.id and c.id=(select max(id) from cover_diagnose where patient_id=c.patient_id)) 诊断,t.now_addres_phone 电话,t.now_address 地址,t.leave_time 参考时间 from T_IN_PATIENT t inner join T_FOLLOW_MANUALPATIENT tf on t.id=tf.patient_id  where t.die_flag=0 and t.leave_time >to_date('" + Convert.ToDateTime(selectedInfo.Createtime.Substring(0, selectedInfo.Createtime.IndexOf(" "))).ToShortDateString() + "','yyyy-MM-dd')";
                }
                if (sMethod == 2)
                {
                    paTemp = "select ''序号,t.id 病人ID,t.pid 住院号,t.patient_name 病人姓名,t.age||t.age_unit  年龄,t.section_id 科室号,t.section_name 科室,t.sick_doctor_id 医生号,t.sick_doctor_name 管床医生,(select name from COVER_DIAGNOSE c where c.patient_id=t.id and c.id=(select max(id) from cover_diagnose where patient_id=c.patient_id)) 诊断,t.now_addres_phone 电话,t.now_address 地址,t.in_time 参考时间 from T_IN_PATIENT t inner join T_FOLLOW_MANUALPATIENT tf on t.id=tf.patient_id  where t.die_flag=0 and t.leave_time > to_date('" + Convert.ToDateTime(selectedInfo.Createtime.Substring(0, selectedInfo.Createtime.IndexOf(" "))).ToShortDateString() + "','yyyy-MM-dd')";
                }
                if (sMethod == 3)
                {
                    paTemp = "select ''序号,t.id 病人ID,t.pid 住院号,t.patient_name 病人姓名,t.age||t.age_unit  年龄,t.section_id 科室号,t.section_name 科室,t.sick_doctor_id 医生号,t.sick_doctor_name 管床医生,(select name from COVER_DIAGNOSE c where c.patient_id=t.id and c.id=(select max(id) from cover_diagnose where patient_id=c.patient_id)) 诊断,t.now_addres_phone 电话,t.now_address 地址,max(oper_date) 参考时间 from T_IN_PATIENT t join COVER_OPERATION o on t.id=patient_id inner join T_FOLLOW_MANUALPATIENT tf on t.id=tf.patient_id  where t.die_flag=0 and t.leave_time > to_date('" + Convert.ToDateTime(selectedInfo.Createtime.Substring(0, selectedInfo.Createtime.IndexOf(" "))).ToShortDateString() + "','yyyy-MM-dd')";
                }
                if (sMethod == 4)
                {
                    return null;
                }
                //方案里是否有科室限制
                if (selectedInfo.Section_ids != "0")
                {
                    if (pIds != "")
                        paTemp += " and t.section_id in(" + selectedInfo.Section_ids + ") and t.id in (" + pIds + ") and rownum<100";
                    else
                        paTemp += "and t.section_id in(" + selectedInfo.Section_ids + ")  and rownum<100";

                }
                else
                {
                    if (pIds != "")
                        paTemp += " and t.id in (" + pIds + ") and rownum<100";
                    else
                        paTemp += " and rownum<100";

                }
                //添加额外的数据（手动加入该方案的）
                string Add = "";
                string Dele = "";
                string Manual = "select * from T_FOLLOW_MANUALPATIENT where solution_id=" + selectedInfo.Id + "";
                DataTable dsManual = App.GetDataSet(Manual).Tables[0];
                for (int n = 0; n < dsManual.Rows.Count; n++)
                {
                    if (dsManual.Rows[n]["IsAdd"].ToString() == "1")
                    {
                        if (Add == "")
                            Add = dsManual.Rows[n]["patient_id"].ToString();
                        else
                            Add += "," + dsManual.Rows[n]["patient_id"].ToString();
                    }
                    else
                    {
                        if (Dele == "")
                            Dele = dsManual.Rows[n]["patient_id"].ToString();
                        else
                            Dele += "," + dsManual.Rows[n]["patient_id"].ToString();
                    }
                }
                if (Dele != "")
                    paTemp += " and t.id not in (" + Dele + ")";
                //if (Add != "")
                //    paTemp += " union select ''序号,t.id 病人ID,t.pid 住院号,t.patient_name 病人姓名,t.age||t.age_unit 年龄,t.section_id 科室号,t.section_name 科室,t.sick_doctor_id 医生号,t.sick_doctor_name 管床医生,(select name from COVER_DIAGNOSE c where c.patient_id=t.id and c.id=(select max(id) from cover_diagnose where patient_id=c.patient_id)) 诊断,t.now_addres_phone 电话,t.now_address 地址,m.update_time 参考时间 from T_IN_PATIENT t join T_FOLLOW_MANUALPATIENT m on t.id=m.patient_id where t.die_flag=0  and t.id in (" + Add + ") and m.solution_id=" + selectedInfo.Id + "";

                //paTemp = FilterSource(paTemp);
                DataTable Patients = App.GetDataSet(paTemp).Tables[0];
                //添加超期，随访次数，上次随访次数，随访状态列（默认为正常）
                DataColumn StateCol = new DataColumn("随访状态", typeof(System.String));
                DataColumn col = new DataColumn("是否逾期", typeof(System.String));
                col.DefaultValue = "是";
                Patients.Columns.Add(col);
                StateCol.DefaultValue = "正常随访";
                Patients.Columns.Add(StateCol);                
                Patients.Columns.Add("下次随访时间", typeof(System.String));
                string ExistRecord = "select (select max(ACTUAL_TIME) from T_FOLLOW_RECORD WHERE patient_id=t.patient_id and solution_id=t.solution_id) 最近随访时间,PATIENT_ID,(select count(*) from t_follow_record where t.patient_id=patient_id and t.solution_id=solution_id and isfinished=1) 随访次数,(select min(requested_time) from T_FOLLOW_RECORD where patient_id=t.patient_id and solution_id=t.solution_id and isfinished=0) 最小未随访时间,(select count(*) from t_follow_record where patient_id=t.patient_id and solution_id=t.solution_id) 次数,t.requested_time 应随访时间,(select a.des from t_follow_record r join  T_FOLLOW_STATE a on r.state_id=a.id where r.id =(select max(id) from T_FOLLOW_RECORD where isfinished=1 and t.patient_id=patient_id and solution_id=t.solution_id)) des  from T_FOLLOW_RECORD t where not exists (select 1 from T_FOLLOW_RECORD where t.patient_id=patient_id and t.solution_id=solution_id and t.id<id)  and solution_id =" + selectedInfo.Id + "";
                DataTable ExistPatients = App.GetDataSet(ExistRecord).Tables[0];

                int flag = 0;   //标记是否已随访过

                for (int i = 0; i < Patients.Rows.Count; i++)
                {
                    for (int j = 0; j < ExistPatients.Rows.Count; j++)
                    {
                        #region 已生成纪录
                        if (Patients.Rows[i]["病人ID"].ToString() == ExistPatients.Rows[j]["patient_id"].ToString())
                        {

                            flag = 1;
                            //修改访问过的记录
                            if (ExistPatients.Rows[j]["des"] != null && ExistPatients.Rows[j]["des"].ToString()!="")
                                Patients.Rows[i]["随访状态"] = ExistPatients.Rows[j]["des"].ToString();
                            //计算超期天数
                            int existTimes = 0;
                            if (ExistPatients.Rows[j]["次数"].ToString() != "" && ExistPatients.Rows[j]["次数"].ToString() != null)
                                existTimes = Convert.ToInt32(ExistPatients.Rows[j]["次数"].ToString());
                            DateTime timeNow = DateTime.Today;
                            //存在未完成纪录，显示最近未完成纪录应随访时间（下次随访时间）
                            DateTime timeMin;
                            timeMin = Convert.ToDateTime(ExistPatients.Rows[j]["应随访时间"].ToString());
                            if ((int)(timeNow - timeMin).TotalDays < 0)
                            {
                                Patients.Rows[i]["下次随访时间"] = ExistPatients.Rows[j]["应随访时间"].ToString().Substring(0,ExistPatients.Rows[j]["应随访时间"].ToString().IndexOf(" "));
                                break;
                            }
                            else
                            {
                                int Seq = Convert.ToInt32(ExistPatients.Rows[j]["次数"].ToString());
                                if (selectedInfo.FinishType != "")
                                {
                                    if (selectedInfo.FinishType.IndexOf("次") != -1)
                                    {
                                        int TotalTimes = Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("次")));
                                        if (TotalTimes <= Seq)
                                        {
                                            //Patients.Rows[i]["下次随访时间"] = ExistPatients.Rows[j]["应随访时间"].ToString().Substring(0,ExistPatients.Rows[j]["应随访时间"].ToString().IndexOf(" "));
                                            break;
                                        }
                                        else
                                        {
                                            if (selectedInfo.Followtype != "")
                                            {
                                                for (; Seq < TotalTimes; Seq++)
                                                {
                                                    if (selectedInfo.Followtype.IndexOf("年") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("年"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            timeMin = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("年"))));
                                                        }
                                                    }
                                                    if (selectedInfo.Followtype.IndexOf("月") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("月"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            timeMin = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("月"))));
                                                        }
                                                    }
                                                    if (selectedInfo.Followtype.IndexOf("天") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("天"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            timeMin = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("天"))));
                                                        }
                                                    }

                                                }
                                                
                                            }
                                            else
                                            {
                                                string[] Str = selectedInfo.Definefollows.Split(',');
                                                int SeqCopy = Seq;
                                                Seq--;
                                                if (Seq >= Str.Length)
                                                    Seq = Str.Length - 1;

                                                for (; Seq < Str.Length; Seq++)
                                                {
                                                    string Item = Str[Seq];
                                                    if (Seq == Str.Length - 1)
                                                        Seq--;
                                                    if (SeqCopy > TotalTimes)
                                                        break;
                                                    if (Item.IndexOf("年") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                            timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                    }
                                                    if (Item.IndexOf("月") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                            timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                    }
                                                    if (Item.IndexOf("天") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                            timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                    }
                                                    SeqCopy++;

                                                }
                                                
                                            }

                                        }
                                    }
                                    else
                                    {
                                        DateTime timeRef = Convert.ToDateTime(Patients.Rows[i]["参考时间"].ToString());
                                        int InfoSpan = 0;
                                        if (selectedInfo.FinishType.IndexOf("年") != -1)
                                            InfoSpan = Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("年"))) * 365;
                                        if (selectedInfo.FinishType.IndexOf("月") != -1)
                                            InfoSpan = Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("月"))) * 30;
                                        if (selectedInfo.FinishType.IndexOf("天") != -1)
                                            InfoSpan = Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("天")));
                                        if ((int)(timeMin - timeRef).TotalDays > InfoSpan)
                                            break;
                                        else
                                        {
                                            if (selectedInfo.Followtype != "")
                                            {
                                                while (true)
                                                {
                                                    if ((int)(timeMin - timeRef).TotalDays > InfoSpan)
                                                        break;
                                                    else
                                                    {
                                                        if (selectedInfo.Followtype.IndexOf("年") != -1)
                                                        {
                                                            //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("年"))));
                                                            if ((int)(timeNow - timeMin).TotalDays < 0)
                                                            {
                                                                Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                timeMin = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("年"))));
                                                            }
                                                        }
                                                        if (selectedInfo.Followtype.IndexOf("月") != -1)
                                                        {
                                                            //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("月"))));
                                                            if ((int)(timeNow - timeMin).TotalDays < 0)
                                                            {
                                                                Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                timeMin = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("月"))));
                                                            }
                                                        }
                                                        if (selectedInfo.Followtype.IndexOf("天") != -1)
                                                        {
                                                            //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("天"))));
                                                            if ((int)(timeNow - timeMin).TotalDays < 0)
                                                            {
                                                                Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                                break;
                                                            }
                                                            else
                                                            {
                                                                timeMin = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("天"))));
                                                            }
                                                        }
                                                    }
                                                }
                                                
                                            }
                                            else
                                            {
                                                string[] Str = selectedInfo.Definefollows.Split(',');
                                                int SeqCopy = Seq;
                                                Seq--;
                                                if (Seq >= Str.Length)
                                                    Seq = Str.Length - 1;

                                                for (; Seq < Str.Length; Seq++)
                                                {
                                                    string Item = Str[Seq];

                                                    if (Seq == Str.Length - 1)
                                                        Seq--;
                                                    if ((int)(timeMin - timeRef).TotalDays > InfoSpan)
                                                        break;
                                                    if (Item.IndexOf("年") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                            timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                    }
                                                    if (Item.IndexOf("月") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                            timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                    }
                                                    if (Item.IndexOf("天") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                            timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                    }
                                                    SeqCopy++;

                                                }
                                                
                                            }

                                        }

                                    }
                                }
                                //无结束条件
                                else
                                {
                                    if (selectedInfo.Followtype != "")
                                    {
                                        string Item = selectedInfo.Followtype;
                                        while (true)
                                        {
                                            if (Item.IndexOf("年") != -1)
                                            {
                                                //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                if ((int)(timeNow - timeMin).TotalDays < 0)
                                                {
                                                    Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                    break;
                                                }
                                                else
                                                    timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                            }
                                            if (Item.IndexOf("月") != -1)
                                            {
                                                //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                if ((int)(timeNow - timeMin).TotalDays < 0)
                                                {
                                                    Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                    break;
                                                }
                                                else
                                                    timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                            }
                                            if (Item.IndexOf("天") != -1)
                                            {
                                                //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                if ((int)(timeNow - timeMin).TotalDays < 0)
                                                {
                                                    Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                    break;
                                                }
                                                else
                                                    timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                            }
                                        }
                                        
                                    }
                                    else
                                    {
                                        string[] Str = selectedInfo.Definefollows.Split(',');
                                        Seq--;
                                        if (Seq >= Str.Length)
                                            Seq = Str.Length - 1;
                                        for (; Seq < Str.Length; Seq++)
                                        {
                                            if (Seq == Str.Length - 1)
                                                Seq--;
                                            string Item = Str[Seq];
                                            if (Item.IndexOf("年") != -1)
                                            {
                                                //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                if ((int)(timeNow - timeMin).TotalDays < 0)
                                                {
                                                    Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                    break;
                                                }
                                                else
                                                    timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                            }
                                            if (Item.IndexOf("月") != -1)
                                            {
                                                //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                if ((int)(timeNow - timeMin).TotalDays < 0)
                                                {
                                                    Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                    break;
                                                }
                                                else
                                                    timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                            }
                                            if (Item.IndexOf("天") != -1)
                                            {
                                                //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                if ((int)(timeNow - timeMin).TotalDays < 0)
                                                {
                                                    Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                    break;
                                                }
                                                else
                                                    timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                            }
                                        }
                                        
                                    }
                                }
                            }
                            break;
                        }

                        #endregion
                    }


                    #region 未生成纪录
                    if (flag == 0)
                    {

                        //参考时间为出院时间
                        DateTime timeMin = Convert.ToDateTime(Patients.Rows[i]["参考时间"].ToString());
                        DateTime timeNow = DateTime.Today;
                        //DateTime time1 = myTime;
                        //所有未随访过的病人的超期天数（包括手动添加）
                        if (selectedInfo.Defaultdays != "0")
                        {
                            timeMin = timeMin.AddDays(Convert.ToInt32(selectedInfo.Defaultdays));
                        }
                        else
                        {
                            if (selectedInfo.Followtype != "")
                            {
                                if (selectedInfo.Followtype.IndexOf("年") != -1)
                                {
                                    timeMin = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("年"))));
                                }
                                if (selectedInfo.Followtype.IndexOf("月") != -1)
                                {
                                    timeMin = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("月"))));
                                }
                                if (selectedInfo.Followtype.IndexOf("天") != -1)
                                {
                                    timeMin = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("天"))));
                                }
                            }
                            if (selectedInfo.Definefollows != "")
                            {
                                string Item = selectedInfo.Definefollows.Substring(0, selectedInfo.Definefollows.IndexOf(','));
                                if (Item.IndexOf("年") != -1)
                                {
                                    timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                }
                                if (Item.IndexOf("月") != -1)
                                {
                                    timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                }
                                if (Item.IndexOf("天") != -1)
                                {
                                    timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                }
                            }
                        }
                        if ((int)(timeNow - timeMin).TotalDays < 0)
                        {
                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                            Patients.Rows[i]["是否逾期"] = "否";
                            continue;
                        }
                        else
                        {
                            int Seq = 1;
                            if (selectedInfo.FinishType != "")
                            {
                                if (selectedInfo.FinishType.IndexOf("次") != -1)
                                {
                                    int TotalTimes = Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("次")));
                                    if (TotalTimes <= Seq)
                                        continue;
                                    else
                                    {
                                        if (selectedInfo.Followtype != "")
                                        {
                                            for (; Seq < TotalTimes; Seq++)
                                            {
                                                if (selectedInfo.Followtype.IndexOf("年") != -1)
                                                {
                                                    //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("年"))));
                                                    if ((int)(timeNow - timeMin).TotalDays < 0)
                                                    {
                                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        timeMin = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("年"))));
                                                    }
                                                }
                                                if (selectedInfo.Followtype.IndexOf("月") != -1)
                                                {
                                                    //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("月"))));
                                                    if ((int)(timeNow - timeMin).TotalDays < 0)
                                                    {
                                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        timeMin = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("月"))));
                                                    }
                                                }
                                                if (selectedInfo.Followtype.IndexOf("天") != -1)
                                                {
                                                    //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("天"))));
                                                    if ((int)(timeNow - timeMin).TotalDays < 0)
                                                    {
                                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        timeMin = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("天"))));
                                                    }
                                                }

                                            }
                                            
                                        }
                                        else
                                        {
                                            string[] Str = selectedInfo.Definefollows.Split(',');
                                            int SeqCopy = Seq;
                                            Seq--;
                                            if (Seq >= Str.Length)
                                                Seq = Str.Length - 1;

                                            for (; Seq < Str.Length; Seq++)
                                            {
                                                string Item = Str[Seq];
                                                if (Seq == Str.Length - 1)
                                                    Seq--;
                                                if (SeqCopy > TotalTimes)
                                                    break;
                                                if (Item.IndexOf("年") != -1)
                                                {
                                                    //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                    if ((int)(timeNow - timeMin).TotalDays < 0)
                                                    {
                                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                        break;
                                                    }
                                                    else
                                                        timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                }
                                                if (Item.IndexOf("月") != -1)
                                                {
                                                    //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                    if ((int)(timeNow - timeMin).TotalDays < 0)
                                                    {
                                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                        break;
                                                    }
                                                    else
                                                        timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                }
                                                if (Item.IndexOf("天") != -1)
                                                {
                                                    //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                    if ((int)(timeNow - timeMin).TotalDays < 0)
                                                    {
                                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                        break;
                                                    }
                                                    else
                                                        timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                }
                                                SeqCopy++;

                                            }
                                            
                                        }

                                    }
                                }
                                else
                                {
                                    DateTime timeRef = Convert.ToDateTime(Patients.Rows[i]["参考时间"].ToString());
                                    int InfoSpan = 0;
                                    if (selectedInfo.FinishType.IndexOf("年") != -1)
                                        InfoSpan = Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("年"))) * 365;
                                    if (selectedInfo.FinishType.IndexOf("月") != -1)
                                        InfoSpan = Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("月"))) * 30;
                                    if (selectedInfo.FinishType.IndexOf("天") != -1)
                                        InfoSpan = Convert.ToInt32(selectedInfo.FinishType.Substring(0, selectedInfo.FinishType.IndexOf("天")));
                                    if ((int)(timeMin - timeRef).TotalDays > InfoSpan)
                                    {
                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                        continue;
                                    }
                                    else
                                    {
                                        if (selectedInfo.Followtype != "")
                                        {
                                            while (true)
                                            {
                                                if ((int)(timeMin - timeRef).TotalDays > InfoSpan)
                                                    break;
                                                else
                                                {
                                                    if (selectedInfo.Followtype.IndexOf("年") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("年"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            timeMin = timeMin.AddYears(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("年"))));
                                                        }
                                                    }
                                                    if (selectedInfo.Followtype.IndexOf("月") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("月"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            timeMin = timeMin.AddMonths(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("月"))));
                                                        }
                                                    }
                                                    if (selectedInfo.Followtype.IndexOf("天") != -1)
                                                    {
                                                        //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("天"))));
                                                        if ((int)(timeNow - timeMin).TotalDays < 0)
                                                        {
                                                            Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            timeMin = timeMin.AddDays(Convert.ToInt32(selectedInfo.Followtype.Substring(0, selectedInfo.Followtype.IndexOf("天"))));
                                                        }
                                                    }
                                                }
                                            }
                                            
                                        }
                                        else
                                        {
                                            string[] Str = selectedInfo.Definefollows.Split(',');
                                            int SeqCopy = Seq;
                                            Seq--;
                                            if (Seq >= Str.Length)
                                                Seq = Str.Length - 1;

                                            for (; Seq < Str.Length; Seq++)
                                            {
                                                string Item = Str[Seq];

                                                if (Seq == Str.Length - 1)
                                                    Seq--;
                                                if ((int)(timeMin - timeRef).TotalDays > InfoSpan)
                                                    break;
                                                if (Item.IndexOf("年") != -1)
                                                {
                                                    //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                    if ((int)(timeNow - timeMin).TotalDays < 0)
                                                    {
                                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                        break;
                                                    }
                                                    else
                                                        timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                                }
                                                if (Item.IndexOf("月") != -1)
                                                {
                                                    //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                    if ((int)(timeNow - timeMin).TotalDays < 0)
                                                    {
                                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                        break;
                                                    }
                                                    else
                                                        timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                                }
                                                if (Item.IndexOf("天") != -1)
                                                {
                                                    //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                    if ((int)(timeNow - timeMin).TotalDays < 0)
                                                    {
                                                        Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                        break;
                                                    }
                                                    else
                                                        timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                                }
                                                SeqCopy++;

                                            }
                                            
                                        }

                                    }

                                }
                            }
                            //无结束条件
                            else
                            {
                                if (selectedInfo.Followtype != "")
                                {
                                    string Item = selectedInfo.Followtype;
                                    while (true)
                                    {
                                        if (Item.IndexOf("年") != -1)
                                        {
                                            //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                            if ((int)(timeNow - timeMin).TotalDays < 0)
                                            {
                                                Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                break;
                                            }
                                            else
                                                timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                        }
                                        if (Item.IndexOf("月") != -1)
                                        {
                                            //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                            if ((int)(timeNow - timeMin).TotalDays < 0)
                                            {
                                                Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                break;
                                            }
                                            else
                                                timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                        }
                                        if (Item.IndexOf("天") != -1)
                                        {
                                            //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                            if ((int)(timeNow - timeMin).TotalDays < 0)
                                            {
                                                Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                break;
                                            }
                                            else
                                                timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                        }
                                    }
                                    
                                }
                                else
                                {
                                    string[] Str = selectedInfo.Definefollows.Split(',');
                                    Seq--;
                                    if (Seq >= Str.Length)
                                        Seq = Str.Length - 1;
                                    for (; Seq < Str.Length; Seq++)
                                    {
                                        if (Seq == Str.Length - 1)
                                            Seq--;
                                        string Item = Str[Seq];
                                        if (Item.IndexOf("年") != -1)
                                        {
                                            //DateTime timeCopy = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                            if ((int)(timeNow - timeMin).TotalDays < 0)
                                            {
                                                Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                break;
                                            }
                                            else
                                                timeMin = timeMin.AddYears(Convert.ToInt32(Item.Substring(0, Item.IndexOf("年"))));
                                        }
                                        if (Item.IndexOf("月") != -1)
                                        {
                                            //DateTime timeCopy = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                            if ((int)(timeNow - timeMin).TotalDays < 0)
                                            {
                                                Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                break;
                                            }
                                            else
                                                timeMin = timeMin.AddMonths(Convert.ToInt32(Item.Substring(0, Item.IndexOf("月"))));
                                        }
                                        if (Item.IndexOf("天") != -1)
                                        {
                                            //DateTime timeCopy = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                            if ((int)(timeNow - timeMin).TotalDays < 0)
                                            {
                                                Patients.Rows[i]["下次随访时间"] = timeMin.ToShortDateString();
                                                break;
                                            }
                                            else
                                                timeMin = timeMin.AddDays(Convert.ToInt32(Item.Substring(0, Item.IndexOf("天"))));
                                        }
                                    }
                                    
                                }
                            }
                        }

                    }
                    #endregion
                    else
                        flag = 0;
                }
                return Patients;
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
                return null;
            }

        }
        /// <summary>
        /// 重组字符串返回'','',''形式字符串
        /// </summary>
        /// <param name="temp"></param>
        public string ReArrange(string temp)
        {
            string finalStr = "";
            if (temp.IndexOf(',') != -1)
            {
                string[] swap = temp.Split(',');
                foreach (string str in swap)
                {
                    if (finalStr == "")
                        finalStr = "'" + str + "'";
                    else
                        finalStr += ",'" + str + "'";
                }
                return finalStr;
            }
            return "'" + temp + "'";
        }
        ///// <summary>
        ///// 筛选目标数据集
        ///// </summary>
        ///// <param name="Filter"></param>
        //public DataTable FilterDataSet(String Filter, DataTable ds)
        //{
        //    return null;
        //}

        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                SelectedId = dgvPatients.Rows[e.RowIndex].Cells["病人Id"].Value.ToString();
                SelectedRow = dgvPatients.Rows[e.RowIndex];
            }
            else
            {
                SelectedId = "";
                SelectedRow = null;
            }
        }

        private void dgvPatients_DoubleClick(object sender, EventArgs e)
        {
            if (SelectedId != "")
            {
                Class_FollowInfo info = cmbFollowInfo.SelectedItem as Class_FollowInfo;
                frmFollowRecord uc = new frmFollowRecord(SelectedId, info.Id, SelectedRow);
                uc.ShowDialog();
            }
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            DataToExcel(dgvPatients);
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="m_DataView">目标数据源</param>
        public void DataToExcel(DataGridView m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXCEL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName + ".xls";
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddPatients_Click(object sender, EventArgs e)
        {
            frmFollowAddPatient frm = new frmFollowAddPatient();
            frm.ShowDialog();
        }

        private void btnComplicateSearch_Click(object sender, EventArgs e)
        {
            Class_FollowInfo info = cmbFollowInfo.SelectedItem as Class_FollowInfo;
            string ID = info.Id;
            frmFollowComplicateSearch se = new frmFollowComplicateSearch(ID);
            se.ShowDialog();
            if (se.Tag != null && se.Tag.ToString() != "")
                DisplayPatients(se.Tag.ToString());
            //Condition Filter;
            //Filter = se.Tag as Condition;
        }

        private void 诊断信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedId != "")
            {
                frmPatientDiagnose diag = new frmPatientDiagnose(SelectedId);
                diag.ShowDialog();
            }
        }

        private void 退出随访ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedId != "")
            {
                Class_FollowInfo info = cmbFollowInfo.SelectedItem as Class_FollowInfo;
                frmFollowDelete dele = new frmFollowDelete(SelectedId, info, this);
                dele.ShowDialog();
            }
        }

        private void 患者基本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedId != "")
            {
                frmFollowPatientBaseInfo frm = new frmFollowPatientBaseInfo(SelectedId);
                frm.ShowDialog();
            }
        }
    }
}
