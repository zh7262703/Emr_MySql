using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.First_cases
{
    /// <summary>
    /// 重症附页的编辑
    /// 作者:李文明
    /// 时间:2013-01-29
    /// </summary>
    public partial class ucCover_Append_GRAVE : UserControl
    {

        private string PatientId = "";           //当前病人的主键
        private string Cover_Append_id = "";   //当前选中的住院附页的主键
        private string option = "-请选择-";    //下拉首选值
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patientid">病人主键</param>
        public ucCover_Append_GRAVE(string patientid)
        {
            InitializeComponent();
            PatientId = patientid;
            iniSelectValues();
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patientid">病人主键</param>
        /// <param name="cover_append_id">住院附页的主键</param>
        public ucCover_Append_GRAVE(string patientid, string cover_append_id)
        {
            InitializeComponent();
            PatientId = patientid;
            Cover_Append_id = cover_append_id;
            iniSelectValues();
            if (Cover_Append_id != "")
            {
                //当附页是已经写过的附页
                iniData(cover_append_id);

            }

        }

        /// <summary>
        /// 初始化值
        /// </summary>
        private void iniSelectValues()
        {

        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public bool SaveData()
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }
                foreach (Control c in this.pIS_RESPIRATOR.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }
                foreach (Control c in this.pIS_C_CATHETERIZATION.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }
                foreach (Control c in this.pIS_CATHETER.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }
                foreach (Control c in this.pIS_APACCHEII.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }

                if (dtpIN_TIME.Value >= dtpOUT_TIME.Value)
                {
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Red;
                    App.Msg("提示:[" + label1.Text + "]不能大于等于[" + label2.Text + "]!");
                    return false;
                }
                string IN_TIME = dtpIN_TIME.Value.ToString("yyyy/MM/dd HH:mm");            //进入时间

                string OUT_TIME = dtpOUT_TIME.Value.ToString("yyyy/MM/dd HH:mm");           //退出时间

                

                string SECTION_ID = "";         //重症科室主键
                string SECTION_NAME = "";       //重症科室名称
                if (rdoSECTION_ID_NAME_CCU.Checked)
                {
                    SECTION_ID = "6101";
                    SECTION_NAME = "CCU";
                }
                else if (rdoSECTION_ID_NAME_RICU.Checked)
                {
                    SECTION_ID = "6102";
                    SECTION_NAME = "RICU";
                }
                else if (rdoSECTION_ID_NAME_SICU.Checked)
                {
                    SECTION_ID = "6103";
                    SECTION_NAME = "SICU";
                }
                else if (rdoSECTION_ID_NAME_NICU.Checked)
                {
                    SECTION_ID = "6104";
                    SECTION_NAME = "NICU";
                }
                else if (rdoSECTION_ID_NAME_PICU.Checked)
                {
                    SECTION_ID = "6105";
                    SECTION_NAME = "PICU";
                }
                else if (rdoSECTION_ID_NAME_other.Checked)
                {
                    SECTION_ID = "6106";
                    SECTION_NAME = "其他";
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    App.Msg("提示:[" + label3.Text + "]未选择!");
                    return false;
                }

                string RETURN_CASE = "";        //非预期24/48小时重返情况
                if (rdoRETURN_CASE_Y.Checked)
                {
                    RETURN_CASE = "Y";
                }
                else if (rdoRETURN_CASE_N.Checked)
                {
                    RETURN_CASE = "N";
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    App.Msg("提示:[" + label4.Text + "]未选择!");
                    return false;
                }

                string IS_RESPIRATOR = "";                  //是否使用呼吸机 Y 是 N 否
                string RESPIRATOR_U_30_DAYS = "";           //呼吸机下抬高床头部≥30度日数
                string RESPIRATOR_U_DAYS = "";              //呼吸机使用天数
                string IS_LINE_RESPIRATOR = "";             //呼吸机是否发生管路滑脱 Y 是 N 否 
                string IS_PNEUMONIA_INFECTION = "";         //是否发生使用呼吸机相关肺炎感染  Y 是 N 否
                if (rdoIS_RESPIRATOR_Y.Checked)
                {
                    IS_RESPIRATOR = "Y";
                    if (txtRESPIRATOR_U_30_DAYS.Text.Trim() != "")
                    {
                        RESPIRATOR_U_30_DAYS = txtRESPIRATOR_U_30_DAYS.Text;
                    }
                    else
                    {
                        label6.ForeColor = Color.Red;
                        label7.ForeColor = Color.Red;
                        App.Msg("提示:[" + label6.Text + "]未填写!");
                        return false;
                    }

                    if (txtRESPIRATOR_U_DAYS.Text.Trim() != "")
                    {
                        RESPIRATOR_U_DAYS = txtRESPIRATOR_U_DAYS.Text;
                    }
                    else
                    {
                        label8.ForeColor = Color.Red;
                        label9.ForeColor = Color.Red;
                        App.Msg("提示:[" + label8.Text + "]未填写!");
                        return false;
                    }

                    if (rdoIS_LINE_RESPIRATOR_Y.Checked)
                    {
                        IS_LINE_RESPIRATOR = "Y";
                    }
                    else if (rdoIS_LINE_RESPIRATOR_N.Checked)
                    {
                        IS_LINE_RESPIRATOR = "N";
                    }
                    else
                    {
                        label10.ForeColor = Color.Red;
                        App.Msg("提示:[" + label10.Text + "]未选择!");
                        return false;
                    }

                    if (rdoIS_PNEUMONIA_INFECTION_Y.Checked)
                    {
                        IS_PNEUMONIA_INFECTION = "Y";
                    }
                    else if (rdoIS_PNEUMONIA_INFECTION_N.Checked)
                    {
                        IS_PNEUMONIA_INFECTION = "N";
                    }
                    else
                    {
                        label11.ForeColor = Color.Red;
                        App.Msg("提示:[" + label11.Text + "]未选择!");
                        return false;
                    }
                }
                else if (rdoIS_RESPIRATOR_N.Checked)
                {
                    IS_RESPIRATOR = "N";
                }
                else
                {
                    label5.ForeColor = Color.Red;
                    App.Msg("提示:[" + label5.Text + "]未选择!");
                    return false;
                }

                
                string IS_C_CATHETERIZATION = "";           //是否使用中心静脉置管   Y 是 N 否 
                string CATHETERIZATION_DAYS = "";           //使用中心静脉置管总日天数
                string IS_LINE_SURGE = "";                  //是否发生管路滑脱 Y 是 N 否 
                string IS_R_INSERT = "";                    //是否再插入 Y 是 N 否 
                string IS_LINE_SURGE_INFECT = "";           //是否发生使用中心静脉置管相关血流感染 Y 是 N 否 
                if (rdoIS_C_CATHETERIZATION_Y.Checked)
                {
                    IS_C_CATHETERIZATION = "Y";
                    if (txtCATHETERIZATION_DAYS.Text.Trim() != "")
                    {
                        CATHETERIZATION_DAYS = txtCATHETERIZATION_DAYS.Text;
                    }
                    else
                    {
                        label13.ForeColor = Color.Red;
                        label14.ForeColor = Color.Red;
                        App.Msg("提示:[" + label13.Text + "]未填写!");
                        return false;
                    }

                    if (rdoIS_LINE_SURGE_Y.Checked)
                    {
                        IS_LINE_SURGE = "Y";
                    }
                    else if (rdoIS_LINE_SURGE_N.Checked)
                    {
                        IS_LINE_SURGE = "N";
                    }
                    else
                    {
                        label15.ForeColor = Color.Red;
                        App.Msg("提示:[" + label15.Text + "]未选择!");
                        return false;
                    }

                    if (rdoIS_R_INSERT_Y.Checked)
                    {
                        IS_R_INSERT = "Y";
                    }
                    else if (rdoIS_R_INSERT_N.Checked)
                    {
                        IS_R_INSERT = "N";
                    }
                    else
                    {
                        label26.ForeColor = Color.Red;
                        App.Msg("提示:[" + label26.Text + "]未选择!");
                        return false;
                    }

                    if (rdoIS_LINE_SURGE_INFECT_Y.Checked)
                    {
                        IS_LINE_SURGE_INFECT = "Y";
                    }
                    else if (rdoIS_LINE_SURGE_INFECT_N.Checked)
                    {
                        IS_LINE_SURGE_INFECT = "N";
                    }
                    else
                    {
                        label16.ForeColor = Color.Red;
                        App.Msg("提示:[" + label16.Text + "]未选择!");
                        return false;
                    }
                }
                else if (rdoIS_C_CATHETERIZATION_N.Checked)
                {
                    IS_C_CATHETERIZATION = "N";
                }
                else
                {
                    label12.ForeColor = Color.Red;
                    App.Msg("提示:[" + label12.Text + "]未选择!");
                    return false;
                }


                string IS_CATHETER = "";                    //是否使用留置导尿管 Y 是 N 否 
                string CATHETER_DAYS = "";                  //留置导尿管总日天数
                string IS_LINE_CATHETER = "";               //是否发生管路滑脱   Y 是 N 否 
                string IS_R_C_INSERT = "";                  //是否再插入 Y 是 N 否 
                string IS_CATHETER_INFECT = "";             //是否发生留置导尿管相关泌尿系感染 Y 是 N 否 
                if (rdoIS_CATHETER_Y.Checked)
                {
                    IS_CATHETER = "Y";
                    if (txtCATHETER_DAYS.Text.Trim() != "")
                    {
                        CATHETER_DAYS = txtCATHETER_DAYS.Text;
                    }
                    else
                    {
                        label18.ForeColor = Color.Red;
                        label19.ForeColor = Color.Red;
                        App.Msg("提示:[" + label18.Text + "]未填写!");
                        return false;
                    }

                    if (rdoIS_LINE_CATHETER_Y.Checked)
                    {
                        IS_LINE_CATHETER = "Y";
                    }
                    else if (rdoIS_LINE_CATHETER_N.Checked)
                    {
                        IS_LINE_CATHETER = "N";
                    }
                    else
                    {
                        label20.ForeColor = Color.Red;
                        App.Msg("提示:[" + label20.Text + "]未选择!");
                        return false;
                    }

                    if (rdoIS_R_C_INSERT_Y.Checked)
                    {
                        IS_R_C_INSERT = "Y";
                    }
                    else if (rdoIS_R_C_INSERT_N.Checked)
                    {
                        IS_R_C_INSERT = "N";
                    }
                    else
                    {
                        label27.ForeColor = Color.Red;
                        App.Msg("提示:[" + label27.Text + "]未选择!");
                        return false;
                    }

                    if (rdoIS_CATHETER_INFECT_Y.Checked)
                    {
                        IS_CATHETER_INFECT = "Y";
                    }
                    else if (rdoIS_CATHETER_INFECT_N.Checked)
                    {
                        IS_CATHETER_INFECT = "N";
                    }
                    else
                    {
                        label21.ForeColor = Color.Red;
                        App.Msg("提示:[" + label21.Text + "]未选择!");
                        return false;
                    }
                }
                else if (rdoIS_CATHETER_N.Checked)
                {
                    IS_CATHETER = "N";
                }
                else
                {
                    label17.ForeColor = Color.Red;
                    App.Msg("提示:[" + label17.Text + "]未选择!");
                    return false;
                }

                
                string IS_APACCHEII = "";                   //是否APACCHEII评分 Y 是 N 否
                string APACCHEII = "";                      //APACCHEII评分
                string IS_PRESSURE_SORES = "";              //是否期间发生压疮 Y 是 N 否 
                string IS_DEATH = "";                       //是否死亡 Y 是 N 否  
                if (rdoIS_APACCHEII_Y.Checked)
                {
                    IS_APACCHEII = "Y";
                    if (txtAPACCHEII.Text.Trim() != "")
                    {
                        APACCHEII = txtAPACCHEII.Text;
                    }
                    else
                    {
                        label23.ForeColor = Color.Red;
                        label24.ForeColor = Color.Red;
                        App.Msg("提示:[" + label23.Text + "]未填写!");
                        return false;
                    }

                    if (rdoIS_PRESSURE_SORES_Y.Checked)
                    {
                        IS_PRESSURE_SORES = "Y";
                    }
                    else if (rdoIS_PRESSURE_SORES_N.Checked)
                    {
                        IS_PRESSURE_SORES = "N";
                    }
                    else
                    {
                        label25.ForeColor = Color.Red;
                        App.Msg("提示:[" + label25.Text + "]未选择!");
                        return false;
                    }

                    if (rdoIS_DEATH_Y.Checked)
                    {
                        IS_DEATH = "Y";
                    }
                    else if (rdoIS_DEATH_N.Checked)
                    {
                        IS_DEATH = "N";
                    }
                    else
                    {
                        label28.ForeColor = Color.Red;
                        App.Msg("提示:[" + label28.Text + "]未选择!");
                        return false;
                    }
                }
                else if (rdoIS_APACCHEII_N.Checked)
                {
                    IS_APACCHEII = "N";
                }
                else
                {
                    label22.ForeColor = Color.Red;
                    App.Msg("提示:[" + label22.Text + "]未选择!");
                    return false;
                }



                string Sql = "";

                if (Cover_Append_id=="")
                {
                    Sql = "insert into COVER_APPEND_GRAVE(PATIENT_ID,IN_TIME,OUT_TIME,SECTION_ID,SECTION_NAME,RETURN_CASE,IS_RESPIRATOR,"+
                                                         "RESPIRATOR_U_30_DAYS,RESPIRATOR_U_DAYS,IS_LINE_RESPIRATOR,IS_PNEUMONIA_INFECTION,"+
                                                         "IS_C_CATHETERIZATION,CATHETERIZATION_DAYS,IS_LINE_SURGE,IS_R_INSERT,IS_LINE_SURGE_INFECT," +
                                                         "IS_CATHETER,CATHETER_DAYS,IS_LINE_CATHETER,IS_R_C_INSERT,IS_CATHETER_INFECT,IS_APACCHEII," +
                                                         "APACCHEII,IS_PRESSURE_SORES,IS_DEATH,CREATE_TIME,USER_ID)values({0},"+
                                                         "to_timestamp('{1}','syyyy-mm-dd hh24:mi'),"+
                                                         "to_timestamp('{2}','syyyy-mm-dd hh24:mi'),'{3}','{4}','{5}','{6}','{7}','{8}'"+
                                                         ",'{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}',"+
                                                         "'{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}'," +
                                                         "to_timestamp('{25}','syyyy-mm-dd hh24:mi'),'{26}')";
                    Sql = string.Format(Sql,PatientId,IN_TIME,OUT_TIME,SECTION_ID,SECTION_NAME,RETURN_CASE,IS_RESPIRATOR,
                                         RESPIRATOR_U_30_DAYS,RESPIRATOR_U_DAYS,IS_LINE_RESPIRATOR,IS_PNEUMONIA_INFECTION,
                                         IS_C_CATHETERIZATION,CATHETERIZATION_DAYS,IS_LINE_SURGE,IS_R_INSERT,IS_LINE_SURGE_INFECT,
                                         IS_CATHETER,CATHETER_DAYS,IS_LINE_CATHETER,IS_R_C_INSERT,IS_CATHETER_INFECT,IS_APACCHEII,
                                         APACCHEII, IS_PRESSURE_SORES, IS_DEATH, App.GetSystemTime().ToShortDateString(),
                                         App.UserAccount.UserInfo.User_id);
                }
                else
                {
                    Sql = "update COVER_APPEND_GRAVE set IN_TIME=to_timestamp('{0}','syyyy-mm-dd hh24:mi'),"+
                                                     "OUT_TIME=to_timestamp('{1}','syyyy-mm-dd hh24:mi'),SECTION_ID='{2}',SECTION_NAME='{3}'," +
                                                     "RETURN_CASE='{4}',IS_RESPIRATOR='{5}',RESPIRATOR_U_30_DAYS='{6}',RESPIRATOR_U_DAYS='{7}'," +
                                                     "IS_LINE_RESPIRATOR='{8}',IS_PNEUMONIA_INFECTION='{9}',IS_C_CATHETERIZATION='{10}'," +
                                                     "CATHETERIZATION_DAYS='{11}',IS_LINE_SURGE='{12}',IS_R_INSERT='{13}',IS_LINE_SURGE_INFECT='{14}'," +
                                                     "IS_CATHETER='{15}',CATHETER_DAYS='{16}',IS_LINE_CATHETER='{17}',IS_R_C_INSERT='{18}'," +
                                                     "IS_CATHETER_INFECT='{19}',IS_APACCHEII='{20}',APACCHEII='{21}',IS_PRESSURE_SORES='{22}',IS_DEATH='{23}'"+
                                                     " where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";
                    Sql = string.Format(Sql,IN_TIME, OUT_TIME, SECTION_ID, SECTION_NAME, RETURN_CASE, IS_RESPIRATOR,
                                         RESPIRATOR_U_30_DAYS, RESPIRATOR_U_DAYS, IS_LINE_RESPIRATOR, IS_PNEUMONIA_INFECTION,
                                         IS_C_CATHETERIZATION, CATHETERIZATION_DAYS, IS_LINE_SURGE, IS_R_INSERT, IS_LINE_SURGE_INFECT,
                                         IS_CATHETER, CATHETER_DAYS, IS_LINE_CATHETER, IS_R_C_INSERT, IS_CATHETER_INFECT, IS_APACCHEII,
                                         APACCHEII, IS_PRESSURE_SORES, IS_DEATH);
                }
                if (App.ExecuteSQL(Sql) > 0)
                {
                    App.Msg("保存成功!");
                    return true;
                }
                else
                {
                    App.MsgErr("保存失败!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败,原因:" + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 初始化手术附页信息
        /// </summary>
        /// <param name="Cover_Append_id">附页的主键</param>
        private void iniData(string Cover_Append_id)
        {
            try
            {
                string sql = "select to_char(IN_TIME,'YYYY/MM/DD HH24:MI') as IN_TIME,to_char(OUT_TIME,'YYYY/MM/DD HH24:MI') as OUT_TIME," +
                                    "SECTION_ID,SECTION_NAME,RETURN_CASE,IS_RESPIRATOR,"+
                                    "RESPIRATOR_U_30_DAYS,RESPIRATOR_U_DAYS,IS_LINE_RESPIRATOR,IS_PNEUMONIA_INFECTION,"+
                                    "IS_C_CATHETERIZATION,CATHETERIZATION_DAYS,IS_LINE_SURGE,IS_R_INSERT,IS_LINE_SURGE_INFECT," +
                                    "IS_CATHETER,CATHETER_DAYS,IS_LINE_CATHETER,IS_R_C_INSERT,IS_CATHETER_INFECT,IS_APACCHEII," +
                                    "APACCHEII,IS_PRESSURE_SORES,IS_DEATH from COVER_APPEND_GRAVE where id=" + Cover_Append_id;
                DataTable dt = App.GetDataSet(sql).Tables[0];
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["IN_TIME"].ToString().Trim() != "")          //进入时间
                        {
                            dtpIN_TIME.Text = dt.Rows[i]["IN_TIME"].ToString();
                        }

                        if (dt.Rows[i]["OUT_TIME"].ToString().Trim() != "")         //退出时间
                        {
                            dtpOUT_TIME.Text = dt.Rows[i]["OUT_TIME"].ToString();
                        }

                        if (dt.Rows[i]["SECTION_ID"].ToString().Trim() != "")         //重症科室主键
                        {
                            if (dt.Rows[i]["SECTION_ID"].ToString()=="6102")
                            {
                                rdoSECTION_ID_NAME_RICU.Checked = true;
                            }
                            else if (dt.Rows[i]["SECTION_ID"].ToString() == "6103")
                            {
                                rdoSECTION_ID_NAME_SICU.Checked = true;
                            }
                            else if (dt.Rows[i]["SECTION_ID"].ToString() == "6104")
                            {
                                rdoSECTION_ID_NAME_NICU.Checked = true;
                            }
                            else if (dt.Rows[i]["SECTION_ID"].ToString() == "6105")
                            {
                                rdoSECTION_ID_NAME_PICU.Checked = true;
                            }
                            else if (dt.Rows[i]["SECTION_ID"].ToString() == "6106")
                            {
                                rdoSECTION_ID_NAME_other.Checked = true;
                            }
                            else
                            {
                                rdoSECTION_ID_NAME_CCU.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["SECTION_NAME"].ToString().Trim() != "")         //重症科室名称
                        {

                        }

                        if (dt.Rows[i]["RETURN_CASE"].ToString().Trim() != "")         //非预期24/48小时重返情况
                        {
                            if (dt.Rows[i]["RETURN_CASE"].ToString()=="Y")
                            {
                                rdoRETURN_CASE_Y.Checked=true;
                            }
                            else
                            {
                                rdoRETURN_CASE_N.Checked = true;
                            }

                        }

                        if (dt.Rows[i]["IS_RESPIRATOR"].ToString().Trim() != "")         //是否使用呼吸机 Y 是 N 否
                        {
                            if (dt.Rows[i]["IS_RESPIRATOR"].ToString() == "Y")
                            {
                                rdoIS_RESPIRATOR_Y.Checked = true;
                                if (dt.Rows[i]["RESPIRATOR_U_30_DAYS"].ToString().Trim() != "")         //呼吸机下抬高床头部≥30度日数
                                {
                                    txtRESPIRATOR_U_30_DAYS.Text = dt.Rows[i]["RESPIRATOR_U_30_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["RESPIRATOR_U_DAYS"].ToString().Trim() != "")         //呼吸机使用天数
                                {
                                    txtRESPIRATOR_U_DAYS.Text = dt.Rows[i]["RESPIRATOR_U_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_LINE_RESPIRATOR"].ToString().Trim() != "")         //呼吸机是否发生管路滑脱 Y 是 N 否 
                                {
                                    if (dt.Rows[i]["IS_LINE_RESPIRATOR"].ToString() == "Y")
                                    {
                                        rdoIS_LINE_RESPIRATOR_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_LINE_RESPIRATOR_N.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["IS_PNEUMONIA_INFECTION"].ToString().Trim() != "")         //是否发生使用呼吸机相关肺炎感染  Y 是 N 否
                                {
                                    if (dt.Rows[i]["IS_PNEUMONIA_INFECTION"].ToString() == "Y")
                                    {
                                        rdoIS_PNEUMONIA_INFECTION_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_PNEUMONIA_INFECTION_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_RESPIRATOR_N.Checked = true;
                            }
                        }

                        

                        if (dt.Rows[i]["IS_C_CATHETERIZATION"].ToString().Trim() != "")         //是否使用中心静脉置管   Y 是 N 否 
                        {
                            if (dt.Rows[i]["IS_C_CATHETERIZATION"].ToString() == "Y")
                            {
                                rdoIS_C_CATHETERIZATION_Y.Checked = true;
                                if (dt.Rows[i]["CATHETERIZATION_DAYS"].ToString().Trim() != "")         //使用中心静脉置管总日天数
                                {
                                    txtCATHETERIZATION_DAYS.Text = dt.Rows[i]["CATHETERIZATION_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_LINE_SURGE"].ToString().Trim() != "")         //是否发生管路滑脱 Y 是 N 否 
                                {
                                    if (dt.Rows[i]["IS_LINE_SURGE"].ToString() == "Y")
                                    {
                                        rdoIS_LINE_SURGE_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_LINE_SURGE_N.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["IS_R_INSERT"].ToString().Trim() != "")         //是否再插入 Y 是 N 否 
                                {
                                    if (dt.Rows[i]["IS_R_INSERT"].ToString() == "Y")
                                    {
                                        rdoIS_R_INSERT_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_R_INSERT_N.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["IS_LINE_SURGE_INFECT"].ToString().Trim() != "")         //是否发生使用中心静脉置管相关血流感染 Y 是 N 否 
                                {
                                    if (dt.Rows[i]["IS_LINE_SURGE_INFECT"].ToString() == "Y")
                                    {
                                        rdoIS_LINE_SURGE_INFECT_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_LINE_SURGE_INFECT_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_C_CATHETERIZATION_N.Checked = true;
                            }
                        }

                        

                        if (dt.Rows[i]["IS_CATHETER"].ToString().Trim() != "")         //是否使用留置导尿管 Y 是 N 否 
                        {
                            if (dt.Rows[i]["IS_CATHETER"].ToString() == "Y")
                            {
                                rdoIS_CATHETER_Y.Checked = true;
                                if (dt.Rows[i]["CATHETER_DAYS"].ToString().Trim() != "")         //留置导尿管总日天数
                                {
                                    txtCATHETER_DAYS.Text = dt.Rows[i]["CATHETER_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_LINE_CATHETER"].ToString().Trim() != "")         //是否发生管路滑脱   Y 是 N 否 
                                {
                                    if (dt.Rows[i]["IS_LINE_CATHETER"].ToString() == "Y")
                                    {
                                        rdoIS_LINE_CATHETER_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_LINE_CATHETER_N.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["IS_R_C_INSERT"].ToString().Trim() != "")         //是否再插入 Y 是 N 否 
                                {
                                    if (dt.Rows[i]["IS_R_C_INSERT"].ToString() == "Y")
                                    {
                                        rdoIS_R_C_INSERT_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_R_C_INSERT_N.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["IS_CATHETER_INFECT"].ToString().Trim() != "")         //是否发生留置导尿管相关泌尿系感染 Y 是 N 否 
                                {
                                    if (dt.Rows[i]["IS_CATHETER_INFECT"].ToString() == "Y")
                                    {
                                        rdoIS_CATHETER_INFECT_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_CATHETER_INFECT_N.Checked = true;
                                    }
                                }

                            }
                            else
                            {
                                rdoIS_CATHETER_N.Checked = true;
                            }
                        }

                        
                        if (dt.Rows[i]["IS_APACCHEII"].ToString().Trim() != "")         //是否APACCHEII评分 Y 是 N 否 
                        {
                            if (dt.Rows[i]["IS_APACCHEII"].ToString() == "Y")
                            {
                                rdoIS_APACCHEII_Y.Checked = true;
                                if (dt.Rows[i]["APACCHEII"].ToString().Trim() != "")         //APACCHEII评分
                                {
                                    txtAPACCHEII.Text = dt.Rows[i]["APACCHEII"].ToString();
                                }

                                if (dt.Rows[i]["IS_PRESSURE_SORES"].ToString().Trim() != "")         //是否期间发生压疮 Y 是 N 否  
                                {
                                    if (dt.Rows[i]["IS_PRESSURE_SORES"].ToString() == "Y")
                                    {
                                        rdoIS_PRESSURE_SORES_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_PRESSURE_SORES_N.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["IS_DEATH"].ToString().Trim() != "")         //是否死亡 Y 是 N 否  
                                {
                                    if (dt.Rows[i]["IS_DEATH"].ToString() == "Y")
                                    {
                                        rdoIS_DEATH_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_DEATH_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_APACCHEII_N.Checked = true;
                            }
                        }

                        

                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败,原因:" + ex.Message);
            }
        }

        /// <summary>
        /// 只允许输入数字和小数点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Delete)
            {
                if ((sender as TextBox).Text.Split('.').Length >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 只允许输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Back)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        #region 控制是否使用呼吸机,中心静脉置管,留置导尿管,APACCHEII评分等附属的内容显示与不显示        
        private void rdoIS_RESPIRATOR_Y_CheckedChanged(object sender, EventArgs e)
        {//呼吸机
            if (rdoIS_RESPIRATOR_Y.Checked)
                pIS_RESPIRATOR.Visible = true;
            else
            {
                pIS_RESPIRATOR.Visible = false;
                txtRESPIRATOR_U_30_DAYS.Text = "";
                txtRESPIRATOR_U_DAYS.Text = "";
                rdoIS_LINE_RESPIRATOR_Y.Checked = false;
                rdoIS_LINE_RESPIRATOR_N.Checked = false;
                rdoIS_PNEUMONIA_INFECTION_Y.Checked = false;
                rdoIS_PNEUMONIA_INFECTION_N.Checked = false;
            }

        }

        private void rdoIS_C_CATHETERIZATION_Y_CheckedChanged(object sender, EventArgs e)
        {//中心静脉置管
            if (rdoIS_C_CATHETERIZATION_Y.Checked)
                pIS_C_CATHETERIZATION.Visible = true;
            else
            {
                pIS_C_CATHETERIZATION.Visible = false;
                txtCATHETERIZATION_DAYS.Text = "";
                rdoIS_LINE_SURGE_Y.Checked = false;
                rdoIS_LINE_SURGE_N.Checked = false;
                rdoIS_R_INSERT_Y.Checked = false;
                rdoIS_R_INSERT_N.Checked = false;
                rdoIS_LINE_SURGE_INFECT_Y.Checked = false;
                rdoIS_LINE_SURGE_INFECT_N.Checked = false;
            }
        }

        private void rdoIS_CATHETER_Y_CheckedChanged(object sender, EventArgs e)
        {//留置导尿管
            if (rdoIS_CATHETER_Y.Checked)
                pIS_CATHETER.Visible = true;
            else
            {
                pIS_CATHETER.Visible = false;
                txtCATHETER_DAYS.Text = "";
                rdoIS_LINE_CATHETER_Y.Checked = false;
                rdoIS_LINE_CATHETER_N.Checked = false;
                rdoIS_R_C_INSERT_Y.Checked = false;
                rdoIS_R_C_INSERT_N.Checked = false;
                rdoIS_CATHETER_INFECT_Y.Checked = false;
                rdoIS_CATHETER_INFECT_N.Checked = false;
            }
        }

        private void rdoIS_APACCHEII_Y_CheckedChanged(object sender, EventArgs e)
        {//APACCHEII评分
            if (rdoIS_APACCHEII_Y.Checked)
                pIS_APACCHEII.Visible = true;
            else
            {
                pIS_APACCHEII.Visible = false;
                txtAPACCHEII.Text = "";
                rdoIS_PRESSURE_SORES_Y.Checked = false;
                rdoIS_PRESSURE_SORES_N.Checked = false;
                rdoIS_DEATH_Y.Checked = false;
                rdoIS_DEATH_N.Checked = false;
                rdoIS_CATHETER_INFECT_Y.Checked = false;
                rdoIS_CATHETER_INFECT_N.Checked = false;
            }

        }
        #endregion

    }
}
