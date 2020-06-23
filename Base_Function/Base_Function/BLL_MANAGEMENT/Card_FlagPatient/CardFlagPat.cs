using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using System.Collections;
using Base_Function.BLL_DOCTOR;
using Bifrost.HisInstance;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class CardFlagPat : UserControl
    {
        DataSet ds = new DataSet();
        public CardFlagPat()
        {
            InitializeComponent();
            App.UsControlStyle(this);
            ucC1FlexGrid1.fg.AllowEditing = false;
            ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
            

            //btnQuery_Click(sender, e);
            try
            {
                string sql_Section = @"select a.sid,a.section_name,a.section_code from t_sectioninfo a 
                                        inner join t_section_area b on a.sid=b.sid
                                        group  by a.shid,a.sid,a.section_code,a.section_name
                                        order by a.shid,a.section_code";//查询科室
//                string sql_Sick = @"select a.said,a.sick_area_code,a.sick_area_name from t_sickareainfo a 
//                                    inner join t_section_area b on a.said=b.said
//                                    group  by a.shid,a.said,a.sick_area_code,a.sick_area_name
//                                    order by a.shid,a.sick_area_code";//查询病区
                //绑定下拉菜单项
                //入院科室
                //DataSet ds_InSection = new DataSet();

                //ds_InSection = App.GetDataSet(sql_Section);
                ////插入默认选项（请选择）
                //if (ds_InSection != null)
                //{
                //    DataRow dr = ds_InSection.Tables[0].NewRow();
                //    dr["sid"] = 0;
                //    dr["section_name"] = "请选择";
                //    ds_InSection.Tables[0].Rows.InsertAt(dr, 0);
                //}


                //出院科室
                DataSet ds_OutSection = new DataSet();
                ds_OutSection = App.GetDataSet(sql_Section);
                //插入默认选项（请选择）
                if (ds_OutSection != null)
                {
                    DataRow dr = ds_OutSection.Tables[0].NewRow();
                    dr["sid"] = 0;
                    dr["section_name"] = "请选择";
                    ds_OutSection.Tables[0].Rows.InsertAt(dr, 0);
                }
                cbxOutSection.DataSource = ds_OutSection.Tables[0];
                cbxOutSection.DisplayMember = "section_name";
                cbxOutSection.ValueMember = "sid";

                //入院病区
                //DataSet ds_InSick = App.GetDataSet(sql_Sick);
                //插入默认选项（请选择）
                //if (ds_InSick != null)
                //{
                //    DataRow dr = ds_InSick.Tables[0].NewRow();
                //    dr["said"] = 0;
                //    dr["sick_area_name"] = "请选择";
                //    ds_InSick.Tables[0].Rows.InsertAt(dr, 0);
                //}

                //出院病区
                //DataSet ds_OutSick = App.GetDataSet(sql_Sick);
                ////插入默认选项（请选择）
                //if (ds_OutSick != null)
                //{
                //    DataRow dr = ds_OutSick.Tables[0].NewRow();
                //    dr["said"] = 0;
                //    dr["sick_area_name"] = "请选择";
                //    ds_OutSick.Tables[0].Rows.InsertAt(dr, 0);
                //}

            }
            catch { }
        }

        private void CardFlagPat_Load(object sender, EventArgs e)
        {
            btnQuery_Click(sender, e);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";

                sql = "select distinct t.id,t.pid 住院号,t.sick_bed_no 床号,t.patient_name 病人姓名,(case when gender_code=0 then '男' else '女' end) 性别 ,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,sick_doctor_name 管床医生,to_char(in_time,'yyyy-MM-dd hh24:MI:ss') 入院时间,to_char(die_time,'yyyy-MM-dd hh24:MI:ss') 出院时间,to_char(document_time,'yyyy-MM-dd hh24:MI:ss') 归档时间,case medicare_no when '门诊' then '' else medicare_no end 身份证号,section_name 科室名称,case DOCUMENT_STATE when '1' then '已归档' else '未归档' end 归档状态,birthday from t_in_patient t left join t_diagnose_item b on t.id=b.patient_id where 1=1 and typicalflag='1'";
                
                if (chbEnable.Checked)//按时间查询
                {
                   //sql += " and to_char(die_time,'yyyy-MM-dd')='" + dtpTimestart.Value.ToString("yyyy-MM-dd") + "'";
                    sql += " and to_char(die_time,'yyyy-MM-dd') between '" + dtpTimestart.Value.ToString("yyyy-MM-dd") + "' and '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'";

                }

                if (cbxOutSection.SelectedIndex != 0)//按出院科室查询
                {
                    sql += " and section_id =" + cbxOutSection.SelectedValue.ToString();
                }
                //if (txtDiagnoseName.Text != "")
                //{
                //    sql += " and b.diagnose_type=406 and b.diagnose_name like '%" + txtDiagnoseName.Text + "%'";
                //}
                sql += " order by id desc";
                ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    ucC1FlexGrid1.DataBd(sql, "id", "", "");
                    ucC1FlexGrid1.fg.Cols["birthday"].Visible = false;
                    //计算年龄
                    //CountAgeByBirthday();
                }
            }
            catch (Exception ex)
            {
                App.Msg(ex.Message.ToString());
            }
            ucC1FlexGrid1.fg.AllowEditing = false;
        }

        /// <summary>
        /// 计算年龄
        /// </summary>
        private void CountAgeByBirthday()
        {
            //分页统计当数据行数超过200时不计算
            try
            {
                for (int i = 0; i < 200; i++)
                {
                    string birthday = ds.Tables[0].Rows[i]["birthday"].ToString(); //生日
                    string in_time = ds.Tables[0].Rows[i]["入院时间"].ToString(); //生日
                    int year, month, day;
                    DataInit.GetAgeByBirthday(Convert.ToDateTime(birthday), Convert.ToDateTime(in_time), out year, out month, out day);
                    string strTemp = "";
                    if (year > 0)
                    {
                        strTemp = year.ToString() + "岁";
                    }
                    else if (month > 0)
                    {
                        strTemp = month.ToString() + "月";
                    }
                    else
                    {
                        strTemp = day.ToString() + "天";
                    }
                    ucC1FlexGrid1.fg.Cols["年龄"][i + 1] = strTemp;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 启用/禁用时间条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (chbEnable.Checked)
            {
                dtpTimestart.Enabled = true;
                this.dateTimePicker1.Enabled = true;
            }
            else
            {
                dtpTimestart.Enabled = false;
                this.dateTimePicker1.Enabled = false;
                //cbxTimeType.Enabled = false;

            }
        }

        /// <summary>
        /// 控制时间条件的显示格式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxUnit.Text == "月")
            //{
            //    dtpTimestart.CustomFormat = "yyyy-MM";
            //}
            //else
            //{
            //    dtpTimestart.CustomFormat = "yyyy-MM-dd";
            //}
        }

        /// <summary>
        /// 出院科室下拉菜单选中项改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxOutSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cbxDoctor.Items.Clear();//清空医生下拉列表的所有项
            //cbxDoctor.DataSource = null;
            if (Convert.ToInt32(cbxOutSection.SelectedIndex) != 0)
            {
                string sql_doctor = "select user_id,user_name from t_userinfo where section_id=" + cbxOutSection.SelectedValue.ToString();
                DataSet ds_Doctores = App.GetDataSet(sql_doctor);
                if (ds_Doctores != null)
                {
                    DataRow dr = ds_Doctores.Tables[0].NewRow();
                    dr["user_id"] = 0;
                    dr["user_name"] = "请选择";
                    ds_Doctores.Tables[0].Rows.InsertAt(dr, 0);
                }
                
                string said = GetSaid(cbxOutSection.SelectedValue);
            }
        }

        private void ucC1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (true)//ucC1FlexGrid1.fg.RowSel >= 1)
                {
                    
                    int row = this.ucC1FlexGrid1.fg.MouseRow;
                    string id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                    string pid = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "住院号"].ToString();
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
                                patientInfo.Sike_Area_Id = ds1.Tables[0].Rows[0]["Sick_Area_Id"].ToString().ToString();
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

                            // 修改双击禁止浏览文书  150814
                            //ucDoctorOperater fq = new ucDoctorOperater(patientInfo);

                            ucDoctorOperater fq = new ucDoctorOperater(patientInfo,"1","","1");
                            
                            //frmMain fq = new frmMain(patientInfo, false, patientInfo.Id);
                            App.AddNewBusUcControl(fq,"病人文书");
                            ucC1FlexGrid1.fg.AllowEditing = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        private void cbxInSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cbxInSection.SelectedIndex != 0)
            //{
            //    string said = GetSaid(cbxInSection.SelectedValue);
            //    cbxInSick.SelectedValue = said;
            //}
        }
        private string GetSaid(object sid)
        {
            string said =string.Empty;
            string select_said = "select said from t_section_area where sid='" + sid + "'";
            said = App.ReadSqlVal(select_said, 0, "said");

            return said;
        }

        /// <summary>
        /// 查看PACS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pACSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                InPatientInfo inPatient =BASE_COMMON.DataInit.GetInpatientInfoByPid(patient_id);
                Bifrost.HisInStance.frm_Pasc fc = new Bifrost.HisInStance.frm_Pasc(inPatient);
                App.FormStytleSet(fc, false);
                fc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "典型病历.xls";
            saveFileDialog1.Filter = "Excel工作簿(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            //fg.SaveExcel(pathname);
            ucC1FlexGrid1.fg.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);

        }
    }
}
