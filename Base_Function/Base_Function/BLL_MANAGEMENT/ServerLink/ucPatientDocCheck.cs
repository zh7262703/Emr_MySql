using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_DOCTOR;

namespace Base_Function.BLL_MANAGEMENT.ServerLink
{
    public partial class ucPatientDocCheck : UserControl
    {
        public ucPatientDocCheck()
        {
            InitializeComponent();
            ucGridviewX1.fg.Sorted += new EventHandler(fg_Sorted);
            ucGridviewX1.fg.DoubleClick += new EventHandler(fg_DoubleClick);
            ucGridviewX1.fg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// 查询统计       
        /// </summary>
        private void CheckData()
        {
            try
            {
                string Sql = "select distinct t.id,t.section_name as 科室,t.patient_name as 姓名," +
                             "t.pid as 住院号,t.in_time as 入区时间,case when (select count(tid) from T_PATIENTS_DOC a1 where a1.textkind_id in (125,119) and a1.patient_id=t.id)=2 then '两个都写了' when (select count(tid) from T_PATIENTS_DOC a1 where a1.textkind_id=125 and a1.patient_id=t.id)=1 then '首次病程' else '入院记录' end 所写首程或入院记录,case when (select count(tid) from T_PATIENTS_DOC a2 where a2.patient_id=t.id and a2.submitted='Y' and a2.textkind_id=158)>0 then '完成' else '未完成' end 出院记录,case when (select c.action_type from t_inhospital_action c where c.next_id=0 and c.action_state=3 and c.pid=t.id and rownum=1)='出区' then '是' else '否' end 是否出院," +
                             "t.sick_doctor_name 管床医生 from t_in_patient t " +
                             "inner join T_PATIENTS_DOC b on b.patient_id=t.id " +
                             "where b.textkind_id=125 or b.textkind_id=119 order by t.section_name";


                ucGridviewX1.DataBd(Sql, "id", "", "");
                ucGridviewX1.fg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                /*
                 * 已出院，但是出院记录未完成的
                 */
                for (int i = 0; i < ucGridviewX1.fg.RowCount; i++)
                {
                    if (ucGridviewX1.fg["出院记录", i].Value.ToString() == "未完成")
                    {
                        if (ucGridviewX1.fg["是否出院", i].Value.ToString() == "是")
                        {
                            for (int j = 0; j < ucGridviewX1.fg.Columns.Count; j++)
                            {
                                ucGridviewX1.fg[j, i].Style.ForeColor = Color.Red;
                            }
                        }
                    }
                }
                ucGridviewX1.fg.Refresh();

            }
            catch//(Exception ex)
            {
                //App.MsgErr("查询出错，原因："+ex.ToString());
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            CheckData();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //CheckData();
        }

        private void ucPatientDocCheck_Load(object sender, EventArgs e)
        {
            //CheckData();
            timer1.Enabled = true;
        }

        private void fg_Sorted(object sender, EventArgs e)
        {
            for (int i = 0; i < ucGridviewX1.fg.RowCount; i++)
            {
                if (ucGridviewX1.fg["出院记录", i].Value != null)
                {
                    if (ucGridviewX1.fg["出院记录", i].Value.ToString() == "未完成")
                    {
                        if (ucGridviewX1.fg["是否出院", i].Value.ToString() == "是")
                        {
                            for (int j = 0; j < ucGridviewX1.fg.Columns.Count; j++)
                            {
                                ucGridviewX1.fg[j, i].Style.ForeColor = Color.Red;
                            }
                        }
                    }
                }
            }
        }


        private void fg_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //获取病人ID
                string id = ucGridviewX1.fg.SelectedRows[0].Cells[0].Value.ToString();
               
                    string sql = "select * from t_in_patient t where t.id='" + id + "'";
                    DataSet ds1 = App.GetDataSet(sql);
                    if (ds1 != null)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            InPatientInfo patientInfo = new InPatientInfo();
                            patientInfo.Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"]);
                            patientInfo.Patient_Name = ds1.Tables[0].Rows[0]["Patient_Name"].ToString();
                            patientInfo.Gender_Code = ds1.Tables[0].Rows[0]["Gender_Code"].ToString();
                            patientInfo.Marrige_State = ds1.Tables[0].Rows[0]["marriage_state"].ToString();
                            patientInfo.Medicare_no = ds1.Tables[0].Rows[0]["Medicare_no"].ToString();
                            patientInfo.Home_address = ds1.Tables[0].Rows[0]["Home_address"].ToString();
                            patientInfo.HomePostal_code = ds1.Tables[0].Rows[0]["HomePostal_code"].ToString();
                            patientInfo.Home_phone = ds1.Tables[0].Rows[0]["Home_phone"].ToString();
                            patientInfo.Office = ds1.Tables[0].Rows[0]["Office"].ToString();
                            patientInfo.Office_address = ds1.Tables[0].Rows[0]["Office_Address"].ToString();
                            patientInfo.Office_phone = ds1.Tables[0].Rows[0]["Office_phone"].ToString();
                            patientInfo.Relation = ds1.Tables[0].Rows[0]["Relation"].ToString();
                            patientInfo.Relation_address = ds1.Tables[0].Rows[0]["Relation_address"].ToString();
                            patientInfo.Relation_phone = ds1.Tables[0].Rows[0]["Relation_phone"].ToString();
                            patientInfo.RelationPos_code = ds1.Tables[0].Rows[0]["RelationPos_code"].ToString();
                            patientInfo.OfficePos_code = ds1.Tables[0].Rows[0]["OfficePos_code"].ToString();
                            if (ds1.Tables[0].Rows[0]["InHospital_Count"].ToString() != "")
                                patientInfo.InHospital_count = Convert.ToInt32(ds1.Tables[0].Rows[0]["InHospital_Count"].ToString());
                            patientInfo.Cert_Id = ds1.Tables[0].Rows[0]["cert_id"].ToString();
                            patientInfo.Pay_Manager = ds1.Tables[0].Rows[0]["pay_manner"].ToString();
                            patientInfo.In_Circs = ds1.Tables[0].Rows[0]["IN_Circs"].ToString();
                            patientInfo.Natiye_place = ds1.Tables[0].Rows[0]["native_place"].ToString();
                            patientInfo.Birth_place = ds1.Tables[0].Rows[0]["Birth_place"].ToString();
                            patientInfo.Folk_code = ds1.Tables[0].Rows[0]["Folk_code"].ToString();

                            patientInfo.Birthday = ds1.Tables[0].Rows[0]["Birthday"].ToString();
                            patientInfo.PId = ds1.Tables[0].Rows[0]["PId"].ToString();
                            patientInfo.Insection_Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["insection_id"]);
                            patientInfo.Insection_Name = ds1.Tables[0].Rows[0]["insection_name"].ToString();
                            patientInfo.In_Area_Id = ds1.Tables[0].Rows[0]["in_area_id"].ToString();
                            patientInfo.In_Area_Name = ds1.Tables[0].Rows[0]["in_area_name"].ToString();
                            if (ds1.Tables[0].Rows[0]["Age"].ToString() != "")
                                patientInfo.Age = ds1.Tables[0].Rows[0]["Age"].ToString();
                            else
                            {
                                if (patientInfo.Age == "0")
                                {
                                    patientInfo.Age = Convert.ToString(App.GetSystemTime().Year - Convert.ToDateTime(patientInfo.Birthday).Year);
                                    patientInfo.Age_unit = "岁";
                                }
                            }
                            patientInfo.Sick_Doctor_Id = ds1.Tables[0].Rows[0]["sick_doctor_id"].ToString();
                            patientInfo.Sick_Doctor_Name = ds1.Tables[0].Rows[0]["sick_doctor_name"].ToString();
                            if (ds1.Tables[0].Rows[0]["Sick_Area_Id"] != null)
                                patientInfo.Sike_Area_Id = ds1.Tables[0].Rows[0]["Sick_Area_Id"].ToString();
                            patientInfo.Sick_Area_Name = ds1.Tables[0].Rows[0]["sick_area_name"].ToString();
                            if (ds1.Tables[0].Rows[0]["section_id"].ToString() != "")
                                patientInfo.Section_Id = Int32.Parse(ds1.Tables[0].Rows[0]["section_id"].ToString());
                            patientInfo.Section_Name = ds1.Tables[0].Rows[0]["section_name"].ToString();
                            if (ds1.Tables[0].Rows[0]["in_time"] != null)
                                patientInfo.In_Time = DateTime.Parse(ds1.Tables[0].Rows[0]["in_time"].ToString());
                            patientInfo.State = ds1.Tables[0].Rows[0]["state"].ToString();
                            if (ds1.Tables[0].Rows[0]["sick_bed_id"].ToString() != "")
                                patientInfo.Sick_Bed_Id = Int32.Parse(ds1.Tables[0].Rows[0]["sick_bed_id"].ToString());
                            patientInfo.Sick_Bed_Name = ds1.Tables[0].Rows[0]["sick_bed_no"].ToString();
                            patientInfo.Age_unit = ds1.Tables[0].Rows[0]["age_unit"].ToString();
                            patientInfo.Sick_Degree = Convert.ToString(ds1.Tables[0].Rows[0]["Sick_Degree"]);
                            if (ds1.Tables[0].Rows[0]["Die_flag"].ToString() != "")
                                patientInfo.Die_flag = Convert.ToInt32(ds1.Tables[0].Rows[0]["Die_flag"]);
                            patientInfo.Card_Id = ds1.Tables[0].Rows[0]["card_id"].ToString();
                            patientInfo.Nurse_Level = ds1.Tables[0].Rows[0]["nurse_level"].ToString();
                            patientInfo.Career = ds1.Tables[0].Rows[0]["Career"].ToString();//职业
                            patientInfo.Out_Id = ds1.Tables[0].Rows[0]["out_id"].ToString();//门诊号
                            patientInfo.Relation_name = ds1.Tables[0].Rows[0]["Relation_Name"].ToString();//联系人姓名

                            //frmMain fq = new frmMain(patientInfo, false, patientInfo.Id);
                            ucDoctorOperater fq = new ucDoctorOperater(patientInfo); 
                            App.AddNewBusUcControl(fq,"病人文书");
                        }
                    }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }
    }
}
