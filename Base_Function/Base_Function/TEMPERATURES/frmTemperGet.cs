using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.MODEL;
using TextEditor;
using C1.Win.C1FlexGrid;

namespace Base_Function.TEMPERATURES
{
    public partial class frmTemperGet : DevComponents.DotNetBar.Office2007Form
    {
        List<string> list = new List<string>();
        private string val = "";
        private InPatientInfo inPatient;
        private frmText CTextEdit;
        DataSet dssql = new DataSet();
        /// <summary>
        /// 提取生命体征数据
        /// </summary>
        public Dictionary<string, string> dic = new Dictionary<string, string>();
        public frmTemperGet()
        {
            InitializeComponent();
        }

        public frmTemperGet(InPatientInfo info)
        {
            InitializeComponent();
            inPatient = info;
        }

        public frmTemperGet(InPatientInfo info, frmText ucEdit)
        {
            InitializeComponent();
            inPatient = info;
            CTextEdit = ucEdit;
        }
        private void frmTemperGet_Load(object sender, EventArgs e)
        {
            //判断体温、脉搏、呼吸、其他的值大小
            string sql = "select * from T_TEMPERATURE_MONITORING";
            dssql = App.GetDataSet(sql);

            GetTempInfo();
            Getdgv();//如果时间等于当前时间那么获取到当前时间所在列颜色控制为黄色
            CellChangeColor();// 异常信息提示

        }
        /// <summary>
        /// 体温变化
        /// </summary>
        private void CellChangeColor()
        {
            if (dssql == null || dssql.Tables.Count == 0)
            {
                return;
            }

            for (int i = 0; i < dgvTemp.Rows.Count; i++)
            {

                for (int j = 0; j < dgvTemp.Columns.Count; j++)
                {
                    string colname = this.dgvTemp.Columns[j].Name;
                    string cvalue = "";
                    if (dgvTemp.Rows[i].Cells[j].Value != null)
                    {
                        cvalue = dgvTemp.Rows[i].Cells[j].Value.ToString().Trim();

                    }
                    if (!App.isNumval(cvalue))
                    {
                        continue;
                    }
                    #region    /*******--判断体温大于等于38

                    if (cvalue != "" && colname.Contains("T"))
                    {
                        if (Convert.ToDouble(cvalue) > Convert.ToDouble(dssql.Tables[0].Rows[0]["TEMPERATUREMAX"].ToString()) ||
                            Convert.ToDouble(cvalue) >= 37.2)
                        {
                            dgvTemp.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                        else if (Convert.ToDouble(cvalue) < Convert.ToDouble(dssql.Tables[0].Rows[0]["TEMPERATUREMIN"].ToString()))
                        {
                            dgvTemp.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                    }
                    #endregion
                    #region /*判断脉搏大于160或小于40*/
                    /*
                                 * 判断脉搏大于160或小于40
                                 */
                    if (cvalue != "" && colname.Contains("P"))
                    {
                        if (Convert.ToDouble(cvalue) > Convert.ToInt32(dssql.Tables[0].Rows[0]["PULSEMAX"].ToString()))
                        {
                            dgvTemp.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                        else if (Convert.ToDouble(cvalue) < Convert.ToInt32(dssql.Tables[0].Rows[0]["PULSEMIN"].ToString()))
                        {
                            dgvTemp.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                    }

                    #endregion
                    #region /----***判断脉搏大于30或小于10
                    /*
                                 *判断呼吸大于30或小于10 
                                 */
                    if (cvalue != "" && colname.Contains("R"))
                    {
                        if (Convert.ToDouble(cvalue) > Convert.ToInt32(dssql.Tables[0].Rows[0]["BREATHMAX"].ToString()))
                        {
                            dgvTemp.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                        else if (Convert.ToDouble(cvalue) < Convert.ToInt32(dssql.Tables[0].Rows[0]["BREATHMIN"].ToString()))
                        {
                            dgvTemp.Rows[i].Cells[j].Style.ForeColor = Color.Red;
                        }
                    }
                    #endregion
                }
            }
        }
            
             
        
        private void Getdgv()
        {
            if (dgvTemp.Rows.Count > 0)
            {
                dgvTemp.Rows[0].Cells[0].Selected = false;
                for (int i = 0; i < dgvTemp.Rows.Count; i++)
                {
                    if (dgvTemp.Rows[i].Cells["datatime"].Value!=null && dgvTemp.Rows[i].Cells["datatime"].Value.ToString() == DateTime.Now.ToString("yyyy-MM-dd"))
                    {
                        dgvTemp.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                    }
                }
            }
        }
        private void GetTempInfo()
        {
            Class_Tempertureinfo temp = new Class_Tempertureinfo();
            //根据病人绑定体温、脉搏、呼吸、其他的值
            //string SQl = "select b.pid as 病人住院号,b.patient_name as 病人姓名,t.ID,t.BED_NO," +
            //             "t.patient_id as 病人主键,b.age as 年龄,b.age_unit as 年龄单位,b.gender_code as 性别," +
            //             "b.section_name as 科别,b.sick_area_name as 病区,b.in_time as 入院时间,t.measure_time," +
            //             "to_char(t.measure_time,'yyyy-MM-dd') as 措施日期," +
            //             "to_char(measure_time,'HH24:mi') as 措施时间,t.temperature_value," +
            //             "t.temperature_body,t.re_measure," +
            //             "t.cooling_value,t.cooling_type,t.pulse_value," +
            //             "t.is_briefness,t.is_assist_hr,t.breath_value," +
            //             "t.is_assist_br,t.measure_state,t.describe," +
            //             "t.remark,t.heart_rhythm,t.operations_time from T_VITAL_SIGNS t inner join T_IN_PATIENT b on t.patient_id=b.id " +
            //             " where t.patient_id='" + inPatient.Id + "'";//,c.stool_count inner join T_TEMPERATURE_INFO c on b.id=c.pid

            string SQl = "select b.pid as 病人住院号,b.patient_name as 病人姓名,t.patient_id as 病人主键," +
                         "b.age as 年龄,b.age_unit as 年龄单位,b.gender_code as 性别,b.section_name as 科别,b.sick_area_name as 病区," +
                         "b.in_time as 入院时间,t.measure_time,to_char(t.measure_time, 'yyyy-MM-dd') as 措施日期,to_char(measure_time, 'HH24:mi') as 措施时间," +
                         "t.VALTYPE as 类型,t.T_VAL as 类型值 from t_temperature_record t inner join T_IN_PATIENT b on t.patient_id = b.id where b.id = '" + inPatient.Id + "' and valtype in('腋温','脉搏','呼吸','血压1','血压2','身高','体重','心率') order by measure_time";


            DataSet ds = App.GetDataSet(SQl);
            DataSet ds_stoolcount = App.GetDataSet("select distinct to_char(t.measure_time, 'yyyy-MM-dd') as 措施日期 from t_temperature_record t where patient_id='" + inPatient.Id + "' and valtype in('腋温','脉搏','呼吸','血压1','血压2','身高','体重','心率') order by 措施日期");
            //DataSet ds_stoolcount = App.GetDataSet("select * from T_TEMPERATURE_INFO where patient_id='" + inPatient.Id + "'order by record_time ");
            //if (ds_stoolcount != null)
            if (ds_stoolcount != null)
            {
                //for (int i = 0; i < ds_stoolcount.Tables[0].Rows.Count; i++)
                //{
                //    dgvTemp.Rows.Add();
                //    dgvTemp.Rows[i].Cells["datatime"].Value = DateTime.Parse(ds_stoolcount.Tables[0].Rows[i]["record_time"].ToString()).ToString("yyyy-MM-dd");
                //    dgvTemp.Rows[i].Cells["SG"].Value = ds_stoolcount.Tables[0].Rows[i]["LENGTH"].ToString();
                //    dgvTemp.Rows[i].Cells["WZ"].Value = ds_stoolcount.Tables[0].Rows[i]["WEIGHT"].ToString();
                //    string[] bp_blood = { "", "" };
                //    # region 作废生命体征血压
                //    //string blood = ds_stoolcount.Tables[0].Rows[i]["bp_blood"].ToString();
                //    //if (!string.IsNullOrEmpty(blood))
                //    //{
                //        //if (blood.Contains(","))
                //        //{
                //        //    string[] bloods = blood.Split(',');
                //        //    if (bloods[0].Contains("/"))
                //        //        blood = bloods[0];
                //        //    else
                //        //        blood = bloods[1];
                //        //}
                //        //bp_blood = blood.Split('/');
                //        //if (!string.IsNullOrEmpty(bp_blood[0]))
                //        //{
                //        //    dgvTemp.Rows[i].Cells["SW"].Value = bp_blood[0];
                //        //}
                //        //if (!string.IsNullOrEmpty(bp_blood[1]))
                //        //{
                //        //    dgvTemp.Rows[i].Cells["XW"].Value = bp_blood[1];
                //    //}
                //    #endregion
                //    string pressure = ds_stoolcount.Tables[0].Rows[i]["BP_BLOOD"].ToString();
                //        if (pressure != "")
                //        {
                //            if (pressure.ToString().Contains(","))
                //            {
                //                string[] bloodArr = pressure.Split(',');

                //                if (bloodArr.Length > 1)
                //                {
                //                    string bloodOne = bloodArr[0];
                //                    if (bloodOne.Length > 1)
                //                    {

                //                        dgvTemp.Rows[i].Cells["SW"].Value = bloodOne;
                //                    }
                //                    if (bloodArr[1].ToString() != "")
                //                    {
                //                        string bloodTwo = bloodArr[1];

                //                        if (bloodTwo.Length > 1)
                //                        {
                //                            dgvTemp.Rows[i].Cells["XW"].Value = bloodTwo;
                //                        }
                //                    }

                //                }
                //            }
                //            else
                //            {
                //                string one = pressure;
                //                dgvTemp.Rows[i].Cells["SW"].Value = one;

                //            }
                //        }

                //    //}

                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count>0)
                    {
                        //DataRow[] rows = ds.Tables[0];//.Select("措施日期='" + DateTime.Parse(ds_stoolcount.Tables[0].Rows[i]["record_time"].ToString()).ToString("yyyy-MM-dd") + "'");
                        //for (int k = 0; k < rows.Length; k++)
                        for (int k = 0; k < ds_stoolcount.Tables[0].Rows.Count; k++)
                        {
                            dgvTemp.Rows.Add();
                            dgvTemp.Rows[k].Cells["datatime"].Value = DateTime.Parse(ds_stoolcount.Tables[0].Rows[k]["措施日期"].ToString()).ToString("yyyy-MM-dd");
                            //dgvTemp.Rows[i].Cells["SG"].Value = ds.Tables[0].Rows[k]["LENGTH"].ToString();
                            //dgvTemp.Rows[i].Cells["WZ"].Value = ds_stoolcount.Tables[0].Rows[i]["WEIGHT"].ToString();
                            //dgvTemp.Rows[i].Cells["SW"].Value = bp_blood[0];
                            //dgvTemp.Rows[i].Cells["XW"].Value = bp_blood[1];
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                if (ds_stoolcount.Tables[0].Rows[k]["措施日期"].ToString()==ds.Tables[0].Rows[i]["措施日期"].ToString())
                                {
                                    if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "血压1")
                                    {
                                        dgvTemp.Rows[k].Cells["SW"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "血压2")
                                    {
                                        dgvTemp.Rows[k].Cells["XW"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "身高")
                                    {
                                        dgvTemp.Rows[k].Cells["SG"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "体重")
                                    {
                                        dgvTemp.Rows[k].Cells["WZ"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    }
                                    if (ds.Tables[0].Rows[i]["措施时间"].ToString() == "04:00")
                                    {
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "腋温")
                                            dgvTemp.Rows[k].Cells["T2"].Value = double.Parse(ds.Tables[0].Rows[i]["类型值"].ToString()).ToString("0.0");
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "脉搏" || ds.Tables[0].Rows[i]["类型"].ToString() == "心率")
                                            dgvTemp.Rows[k].Cells["P2"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "呼吸")
                                            dgvTemp.Rows[k].Cells["R2"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[i]["措施时间"].ToString() == "08:00")
                                    {
                                        //if (rows[k]["temperature_value"].ToString() != "" && rows[k]["temperature_value"].ToString() != "0")
                                        //    dgvTemp.Rows[i].Cells["T6"].Value = double.Parse(rows[k]["temperature_value"].ToString()).ToString("0.0");//.TrimEnd('0');
                                        //if (rows[k]["pulse_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["P6"].Value = Convert.ToString(rows[k]["pulse_value"].ToString());
                                        //if (rows[k]["breath_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["R6"].Value = Convert.ToString(rows[k]["breath_value"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "腋温")
                                            dgvTemp.Rows[k].Cells["T6"].Value = double.Parse(ds.Tables[0].Rows[i]["类型值"].ToString()).ToString("0.0");
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "脉搏" || ds.Tables[0].Rows[i]["类型"].ToString() == "心率")
                                            dgvTemp.Rows[k].Cells["P6"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "呼吸")
                                            dgvTemp.Rows[k].Cells["R6"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[i]["措施时间"].ToString() == "12:00")
                                    {
                                        //if (rows[k]["temperature_value"].ToString() != "" && rows[k]["temperature_value"].ToString() != "0")
                                        //    dgvTemp.Rows[i].Cells["T10"].Value = double.Parse(rows[k]["temperature_value"].ToString()).ToString("0.0");//.TrimEnd('0');
                                        //if (rows[k]["pulse_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["P10"].Value = Convert.ToString(rows[k]["pulse_value"].ToString());
                                        //if (rows[k]["breath_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["R10"].Value = Convert.ToString(rows[k]["breath_value"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "腋温")
                                            dgvTemp.Rows[k].Cells["T10"].Value = double.Parse(ds.Tables[0].Rows[i]["类型值"].ToString()).ToString("0.0");
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "脉搏" || ds.Tables[0].Rows[i]["类型"].ToString() == "心率")
                                            dgvTemp.Rows[k].Cells["P10"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "呼吸")
                                            dgvTemp.Rows[k].Cells["R10"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[i]["措施时间"].ToString() == "16:00")
                                    {
                                        //if (rows[k]["temperature_value"].ToString() != "" && rows[k]["temperature_value"].ToString() != "0")
                                        //    dgvTemp.Rows[i].Cells["T14"].Value = double.Parse(rows[k]["temperature_value"].ToString()).ToString("0.0");//.TrimEnd('0');
                                        //if (rows[k]["pulse_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["P14"].Value = Convert.ToString(rows[k]["pulse_value"].ToString());
                                        //if (rows[k]["breath_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["R14"].Value = Convert.ToString(rows[k]["breath_value"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "腋温")
                                            dgvTemp.Rows[k].Cells["T14"].Value = double.Parse(ds.Tables[0].Rows[i]["类型值"].ToString()).ToString("0.0");
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "脉搏" || ds.Tables[0].Rows[i]["类型"].ToString() == "心率")
                                            dgvTemp.Rows[k].Cells["P14"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "呼吸")
                                            dgvTemp.Rows[k].Cells["R14"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[i]["措施时间"].ToString() == "20:00")
                                    {
                                        //if (rows[k]["temperature_value"].ToString() != "" && rows[k]["temperature_value"].ToString() != "0")
                                        //    dgvTemp.Rows[i].Cells["T18"].Value = double.Parse(rows[k]["temperature_value"].ToString()).ToString("0.0");//.TrimEnd('0');
                                        //if (rows[k]["pulse_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["P18"].Value = Convert.ToString(rows[k]["pulse_value"].ToString());
                                        //if (rows[k]["breath_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["R18"].Value = Convert.ToString(rows[k]["breath_value"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "腋温")
                                            dgvTemp.Rows[k].Cells["T18"].Value = double.Parse(ds.Tables[0].Rows[i]["类型值"].ToString()).ToString("0.0");
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "脉搏" || ds.Tables[0].Rows[i]["类型"].ToString() == "心率")
                                            dgvTemp.Rows[k].Cells["P18"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "呼吸")
                                            dgvTemp.Rows[k].Cells["R18"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    }
                                    else if (ds.Tables[0].Rows[i]["措施时间"].ToString() == "00:00")
                                    {
                                        //if (rows[k]["temperature_value"].ToString() != "" && rows[k]["temperature_value"].ToString() != "0")
                                        //    dgvTemp.Rows[i].Cells["T22"].Value = double.Parse(rows[k]["temperature_value"].ToString()).ToString("0.0");//.TrimEnd('0');
                                        //if (rows[k]["pulse_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["P22"].Value = Convert.ToString(rows[k]["pulse_value"].ToString());
                                        //if (rows[k]["breath_value"].ToString() != "")
                                        //    dgvTemp.Rows[i].Cells["R22"].Value = Convert.ToString(rows[k]["breath_value"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() != "" && ds.Tables[0].Rows[i]["类型"].ToString() == "腋温")
                                            dgvTemp.Rows[k].Cells["T22"].Value = double.Parse(ds.Tables[0].Rows[i]["类型值"].ToString()).ToString("0.0");
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "脉搏" || ds.Tables[0].Rows[i]["类型"].ToString() == "心率")
                                            dgvTemp.Rows[k].Cells["P22"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                        if (ds.Tables[0].Rows[i]["类型"].ToString() == "呼吸")
                                            dgvTemp.Rows[k].Cells["R22"].Value = Convert.ToString(ds.Tables[0].Rows[i]["类型值"].ToString());
                                    } 
                                }
                            }
                        }
                    }

                    dgvTemp.AutoResizeColumns();
                }
            //}


        }

        private void dgvTemp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //点表头出错
            if (e.RowIndex != -1)
            {
                dgvTemp.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.BlueViolet;
            }
        }

        private void dgvTemp_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //点表头出错
            if (e.RowIndex != -1)
            {
                dgvTemp.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            Getdgv();
        }


        private void btntq_Click(object sender, EventArgs e)
        {
            val = "";
            if (CTextEdit != null)
            {    //附一用的,注掉
                #region 文书编辑器提取
                //List<Class_Tempertureinfo> temps = new List<Class_Tempertureinfo>();
                //if (dgvTemp.Rows.Count > 0)
                //{
                //    //value.Clear();
                //    for (int i = 0; i < dgvTemp.Rows.Count; i++)
                //    {
                //        Class_Tempertureinfo temp = new Class_Tempertureinfo();
                //        for (int j = 0; j < dgvTemp.Rows[i].Cells.Count; j++)
                //        {
                //            if (dgvTemp.Rows[i].Cells[j].Selected == true)
                //            {
                //                temp.Patient_id = inPatient.Id.ToString();
                //                string n = dgvTemp.Columns[j].Name;

                //                if (n.Contains("datatime"))
                //                {
                //                    App.Msg("日期无法选择!");
                //                    return;
                //                }
                //                if (dgvTemp.Rows[i].Cells[j].Value == null || dgvTemp.Rows[i].Cells[j].Value.ToString() == "")
                //                {
                //                    App.Msg("选择中有空值!");
                //                    return;
                //                }

                //                if (n.Contains("SW"))
                //                {
                //                    temp.Bpam = "BP" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "mmHg";
                //                    val = val + temp.Bpam + "  ";
                //                }
                //                if (n.Contains("XW"))
                //                {
                //                    temp.Bpam = "BP" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "mmHg";
                //                    val = val + temp.Bpam + "  ";
                //                }
                //                if (n.Contains("SG"))
                //                {
                //                    temp.Length = "身高" + dgvTemp.Rows[i].Cells["SG"].Value.ToString() + "cm";
                //                    val = val + temp.Length + "  ";
                //                }
                //                if (n.Contains("WZ"))
                //                {
                //                    temp.Weight = "体重" + dgvTemp.Rows[i].Cells["WZ"].Value.ToString() + "kg";
                //                    val = val + temp.Weight + "  ";
                //                }

                //                if (n.Contains("2") && n.Length == 2)
                //                {
                //                    temp.Time2 = "02:00";

                //                    if (n.Remove(1, 1) == "T")
                //                    {
                //                        temp.Temperature_3am = "T" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "℃";
                //                        val = val + temp.Temperature_3am + "  ";
                //                    }
                //                    if (n.Remove(1, 1) == "P")
                //                    {
                //                        temp.Pulse_3am = "P" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Pulse_3am + "  ";
                //                    }
                //                    if (n.Remove(1, 1) == "R")
                //                    {
                //                        temp.Breathe_3am += "R" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Breathe_3am + "  ";
                //                    }
                //                }
                //                if (n.Contains("6"))
                //                {
                //                    temp.Time6 = "06:00";
                //                    if (n.Remove(1, 1) == "T")
                //                    {
                //                        temp.Temperature_7am = "T" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "℃";
                //                        val = val + temp.Temperature_7am + "  ";
                //                    }
                //                    if (n.Remove(1, 1) == "P")
                //                    {
                //                        temp.Pulse_7am = "P" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Pulse_7am + "  ";
                //                    }
                //                    if (n.Remove(1, 1) == "R")
                //                    {
                //                        temp.Breathe_7am += "R" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Breathe_7am + "  ";
                //                    }


                //                }

                //                if (n.Contains("10"))
                //                {
                //                    temp.Time10 = "10:00";

                //                    if (n.Remove(1, 2) == "T")
                //                    {
                //                        temp.Temperature_11am = "T" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "℃";
                //                        val = val + temp.Temperature_11am + "  ";
                //                    }
                //                    if (n.Remove(1, 2) == "P")
                //                    {
                //                        temp.Pulse_11am = "P" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Pulse_11am + "  ";
                //                    }
                //                    if (n.Remove(1, 2) == "R")
                //                    {
                //                        temp.Breathe_11am += "R" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Breathe_11am + "  ";
                //                    }


                //                }

                //                if (n.Contains("14"))
                //                {
                //                    temp.Time14 = "10:00";

                //                    if (n.Remove(1, 2) == "T")
                //                    {
                //                        temp.Temperature_3pm = "T" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "℃";
                //                        val = val + temp.Temperature_3pm + "  ";
                //                    }
                //                    if (n.Remove(1, 2) == "P")
                //                    {
                //                        temp.Pulse_3pm = "P" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Pulse_3pm + "  ";
                //                    }
                //                    if (n.Remove(1, 2) == "R")
                //                    {
                //                        temp.Breathe_3pm += "R" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Breathe_3pm + "  ";
                //                    }

                //                }

                //                if (n.Contains("18"))
                //                {
                //                    temp.Time18 = "10:00";

                //                    if (n.Remove(1, 2) == "T")
                //                    {
                //                        temp.Temperature_7pm = "T" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "℃";
                //                        val = val + temp.Temperature_7pm + "  ";

                //                    }
                //                    if (n.Remove(1, 2) == "P")
                //                    {
                //                        temp.Pulse_7pm = "P" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Pulse_7pm + "  ";
                //                    }
                //                    if (n.Remove(1, 2) == "R")
                //                    {
                //                        temp.Breathe_7pm += "R" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Breathe_7pm + "  ";
                //                    }

                //                }
                //                if (n.Contains("22"))
                //                {
                //                    temp.Time22 = "10:00";

                //                    if (n.Remove(1, 2) == "T")
                //                    {
                //                        temp.Temperature_11pm = "T" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "℃";
                //                        val = val + temp.Temperature_11pm + "  ";

                //                    }
                //                    if (n.Remove(1, 2) == "P")
                //                    {
                //                        temp.Pulse_11pm = "P" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Pulse_11pm + "  ";
                //                    }
                //                    if (n.Remove(1, 2) == "R")
                //                    {
                //                        temp.Breathe_11pm += "R" + dgvTemp.Rows[i].Cells[j].Value.ToString() + "次/分";
                //                        val = val + temp.Breathe_11pm + "  ";
                //                    }
                //                }

                //            }
                //        }
                //        if (temp.Patient_id != null)
                //        {
                //            temps.Add(temp);
                //        }

                //    }

                //}
                #endregion
            }
            else
            {
                #region 护理记录单提取生命体征
                List<Class_Tempertureinfo> temps = new List<Class_Tempertureinfo>();
                dic.Clear();
                if (dgvTemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dgvTemp.Rows.Count; i++)
                    {
                        Class_Tempertureinfo temp = new Class_Tempertureinfo();
                        for (int j = 0; j < dgvTemp.Rows[i].Cells.Count; j++)
                        {
                            if (dgvTemp.Rows[i].Cells[j].Selected == true)
                            {
                                string data = dgvTemp.Rows[i].Cells[0].Value.ToString();

                                temp.Patient_id = inPatient.Id.ToString();
                                string n = dgvTemp.Columns[j].Name;

                                if (n.Contains("datatime"))
                                {
                                    App.Msg("日期无法选择!");
                                    return;
                                }
                                if (dgvTemp.Rows[i].Cells[j].Value == null || dgvTemp.Rows[i].Cells[j].Value.ToString() == "")
                                {
                                    App.Msg("选择中有空值!");
                                    return;
                                }


                                string key = "";
                                if (n.Contains("T"))
                                    key = "T";
                                if (n.Contains("P"))
                                    key = "P";
                                if (n.Contains("R"))
                                    key = "R";
                                if (n.Contains("SW"))
                                    key = "BP1";
                                if (n.Contains("XW"))
                                    key = "BP2";
                                if (n.Contains("SG"))
                                    key = "身高";
                                if (n.Contains("WZ"))
                                    key = "体重";
                                if (!dic.ContainsKey(key))
                                {
                                    dic.Add(key, dgvTemp.Rows[i].Cells[j].Value.ToString());
                                }
                                dic[key] = dgvTemp.Rows[i].Cells[j].Value.ToString();

                            }
                        }

                    }

                }
                #endregion
            }
            if (val != "")
            {
                if (CTextEdit != null)
                {
                    string content2 = string.Format("<insert>{0}</insert>", "<span>" + val + "</span>");
                    CTextEdit.MyDoc._insertElements(content2);
                }
                this.DialogResult = DialogResult.OK;
            }
            this.Close();

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void dgvTemp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
