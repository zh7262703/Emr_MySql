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
    /// 住院附页的编辑
    /// 修改:李文明
    /// 时间:2013-01-27
    /// </summary>
    public partial class ucCover_Append_In : UserControl
    {

        private string PatientId="";           //当前病人的主键
        private string Cover_Append_id = "";   //当前选中的住院附页的主键

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patientid">病人主键</param>
        public ucCover_Append_In(string patientid)
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
        public ucCover_Append_In(string patientid,string cover_append_id)
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
        /// 初始化一些下拉选择项的值
        /// </summary>
        private void iniSelectValues()
        {
            string Sqlhisid = "select HIS_ID from t_in_patient  where ID ='" + PatientId + "'";
            string HIS_ID = App.ReadSqlVal(Sqlhisid, 0, "HIS_ID");
            HIS_ID = HIS_ID.Substring(0, 4);
            //是否再入院患者
            if (HIS_ID == "ZY01")
            {
                radISHAVEINNo.Checked = true;
                pISHAVEIN_YesNO.Enabled = false;
            }
            else if (HIS_ID != "")
            {
                radISHAVEINYes.Checked = true;
                pISHAVEIN_YesNO.Enabled = false;
            }
            else
            {
                pISHAVEIN_YesNO.Enabled = true;
            }

            //根据系统t_in_patient中IN_CASE字段自动选择，危 对应 此处的病危，急 与 重 对应此处的病重，一般 对应此处的一般

            string Sqlcircs = "select t.in_circs from t_in_patient t  where ID ='" + PatientId + "'";
            string circs = App.ReadSqlVal(Sqlcircs, 0, "in_circs");
            //是否再入院患者
            if (circs.IndexOf("危") > -1)
            {//字符串circs中包含字符串危
                rdoIN_CASE_BW.Checked = true;
                pIN_CASE.Enabled = false;
            }
            else if (circs.IndexOf("急") > -1 || circs.IndexOf("重") > -1)
            {
                rdoIN_CASE_BZ.Checked = true;
                pIN_CASE.Enabled = false;
            }
            else if (circs.IndexOf("一般") > -1 )
            {
                rdoIN_CASE_YB.Checked = true;
                pIN_CASE.Enabled = false;
            }
            else
            {
                pIN_CASE.Enabled = true;
            }

            //并发症
            DataSet ds_bf = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='BFZ001'");
            //医源性伤害
            DataSet ds_yxx = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='yxsh00001'");

            
            chkCOMPLICATING_DISEASE.DataSource = ds_bf.Tables[0].DefaultView;
            chkCOMPLICATING_DISEASE.DisplayMember = "name";
            chkCOMPLICATING_DISEASE.ValueMember = "id";
            chkCOMPLICATING_DISEASE.Enabled = false;

            chkIS_IATROGENIC_INJURY.DataSource = ds_yxx.Tables[0].DefaultView;
            chkIS_IATROGENIC_INJURY.DisplayMember = "name";
            chkIS_IATROGENIC_INJURY.ValueMember = "id";
            chkIS_IATROGENIC_INJURY.Enabled = false;
            

        }


        /// <summary>
        /// 初始化附页信息
        /// </summary>
        /// <param name="Cover_Append_id">附页的主键</param>
        private void iniData(string Cover_Append_id)
        {
            try
            {
                string Sql = "select Patient_Id, ISHAVEIN, HAVEIN_COUNT, HAVEIN_REASON, IN_CASE, DEATH_REASON,"+
                                      "ISINFUSE, INFUSE_REACTION, ISBOOLDINFUSE, BLOODINFUSE_REACTION, ISCOMPLICATING_DISEASE,"+
                                      "ISINFECT,OPER_FROZEN_PARAFFIN, BEF_OPER_CASE, COMPLICATING_DISEASE, IATROGENIC_INJURY,"+
                                      "IS_COMPLICATING_DISEASES,IS_IATROGENIC_INJURYS," +
                                      "IS_RESPIRATOR,RESPIRATOR_DAYS, IS_RPT_PNEUMONIA_INFECTION, IS_CATHETERIZATION, "+
                                      "CATHETERIZATION_DAYS,IS_CATHETERIZATION_INFECT, IS_CATHETER, CATHETER_DAYS,"+
                                      "IS_U_S_INFECTION, IS_HEMODIALYSIS,HEMODIALYSIS_DAYS, IS_HEMODIALYSIS_INFECT,CREATE_TIME,USER_ID"+
                                      " from cover_append_in  where id=" + Cover_Append_id;
                DataTable dt = App.GetDataSet(Sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ISHAVEIN"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["ISHAVEIN"].ToString() == "Y")//是否再次入院 Y 是 N 否
                            {
                                radISHAVEINYes.Checked = true;
                            }
                            else
                            {
                                radISHAVEINNo.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["HAVEIN_COUNT"].ToString().Trim() != "")//再入院天数
                        {
                            txtHAVEIN_COUNT.Text=dt.Rows[i]["HAVEIN_COUNT"].ToString();
                            
                        }

                        if (dt.Rows[i]["HAVEIN_REASON"].ToString().Trim() != "")//再次入院原因
                        {
                            if (dt.Rows[i]["HAVEIN_REASON"].ToString() == "2")
                            {
                                rdoHAVEIN_REASON_other.Checked = true;
                            }
                            else
                            {
                                rdoHAVEIN_REASON_as.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["IN_CASE"].ToString().Trim() != "")//入院时情况
                        {
                            if (dt.Rows[i]["IN_CASE"].ToString() == "2")
                            {
                                rdoIN_CASE_BZ.Checked = true;
                            }
                            else if (dt.Rows[i]["IN_CASE"].ToString() == "3")
                            {
                                rdoIN_CASE_YB.Checked = true;
                            }
                            else
                            {
                                rdoIN_CASE_BW.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["DEATH_REASON"].ToString().Trim() != "")//死亡原因
                        {
                            if (dt.Rows[i]["DEATH_REASON"].ToString() == "1")
                            {
                                rdoDEATH_REASON_SZSW.Checked = true;
                            }
                            else if (dt.Rows[i]["DEATH_REASON"].ToString() == "2")
                            {
                                rdoDEATH_REASON_MZSW.Checked = true;
                            }
                            else if (dt.Rows[i]["DEATH_REASON"].ToString() == "3")
                            {
                                rdoDEATH_REASON_YYCW.Checked = true;
                            }
                            else if (dt.Rows[i]["DEATH_REASON"].ToString() == "4")
                            {
                                rdoDEATH_REASON_SHBFZ.Checked = true;
                            }
                            else
                            {
                                rdoDEATH_REASON_YQSW.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ISINFUSE"].ToString().Trim() != "")//是否输液 Y 是 N 否
                        {
                            if (dt.Rows[i]["ISINFUSE"].ToString() == "Y")
                            {
                                rdoISINFUSE_Y.Checked = true;
                            }
                            else
                            {
                                rdoISINFUSE_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["INFUSE_REACTION"].ToString().Trim() != "")//输液反应
                        {
                            if (dt.Rows[i]["INFUSE_REACTION"].ToString() == "1")
                            {
                                rdoINFUSE_REACTION_Y.Checked = true;
                            }
                            else
                            {
                                rdoINFUSE_REACTION_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ISBOOLDINFUSE"].ToString().Trim() != "")//是否输血 Y 是 N 否
                        {
                            if (dt.Rows[i]["ISBOOLDINFUSE"].ToString() == "Y")
                            {
                                rdoISBOOLDINFUSE_Y.Checked = true;
                            }
                            else
                            {
                                rdoISBOOLDINFUSE_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["BLOODINFUSE_REACTION"].ToString().Trim() != "")//输血反应
                        {
                            if (dt.Rows[i]["BLOODINFUSE_REACTION"].ToString() == "1")
                            {
                                rdoBLOODINFUSE_REACTION_Y.Checked = true;
                            }
                            else
                            {
                                rdoBLOODINFUSE_REACTION_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ISCOMPLICATING_DISEASE"].ToString().Trim() != "")//是否并发症  Y 是 N 否
                        {
                            if (dt.Rows[i]["ISCOMPLICATING_DISEASE"].ToString() == "Y")
                            {
                                rdoISCOMPLICATING_DISEASE_Y.Checked = true;
                            }
                            else
                            {
                                rdoISCOMPLICATING_DISEASE_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ISINFECT"].ToString().Trim() != "")//是否院内感染  Y 是 N 否
                        {
                            if (dt.Rows[i]["ISINFECT"].ToString() == "Y")
                            {
                                rdoISINFECT_Y.Checked = true;
                            }
                            else
                            {
                                rdoISINFECT_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["OPER_FROZEN_PARAFFIN"].ToString().Trim() != "")//手术冰冻与石蜡病理诊断符合情况
                        {
                            if (dt.Rows[i]["OPER_FROZEN_PARAFFIN"].ToString() == "1")
                            {
                                rdoOPER_FROZEN_PARAFFIN_FH.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_FROZEN_PARAFFIN"].ToString() == "2")
                            {
                                rdoOPER_FROZEN_PARAFFIN_BFH.Checked = true;
                            }
                            else
                            {
                                rdoOPER_FROZEN_PARAFFIN_WZ.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["BEF_OPER_CASE"].ToString().Trim() != "")//术前诊断与术后病理诊断符合情况
                        {
                            if (dt.Rows[i]["BEF_OPER_CASE"].ToString() == "1")
                            {
                                rdoBEF_OPER_CASE_FH.Checked = true;
                            }
                            else if (dt.Rows[i]["BEF_OPER_CASE"].ToString() == "2")
                            {
                                rdoBEF_OPER_CASE_BFH.Checked = true;
                            }
                            else
                            {
                                rdoBEF_OPER_CASE_WZ.Checked = true;
                            }
                        }


                        if (dt.Rows[i]["IS_COMPLICATING_DISEASES"].ToString().Trim() != "")//是否发生术后并发症  Y 是 N 否
                        {
                            if (dt.Rows[i]["IS_COMPLICATING_DISEASES"].ToString() == "Y")
                            {
                                rdoCOMPLICATING_DISEASE_Y.Checked = true;
                                if (dt.Rows[i]["COMPLICATING_DISEASE"].ToString().Trim() != "")//并发症情况（从数据字典中取相关的代码）
                                {
                                    //cboCOMPLICATING_DISEASE.SelectedValue = dt.Rows[i]["BEF_OPER_CASE"].ToString();

                                    string[] vals = dt.Rows[i]["COMPLICATING_DISEASE"].ToString().Split(',');
                                    for (int i1 = 0; i1 < vals.Length; i1++)
                                    {
                                        for (int j = 0; j < chkCOMPLICATING_DISEASE.Items.Count; j++)
                                        {
                                            DataRowView temp = (DataRowView)chkCOMPLICATING_DISEASE.Items[j];
                                            if (temp["id"].ToString() == vals[i1])
                                            {
                                                chkCOMPLICATING_DISEASE.SetItemChecked(j, true);
                                            }
                                        }
                                    }

                                }
                            }
                            else
                            {
                                rdoCOMPLICATING_DISEASE_N.Checked = true;
                            }
                        }


                        if (dt.Rows[i]["IS_IATROGENIC_INJURYS"].ToString().Trim() != "")//是否发生医源性伤害情况  Y 是 N 否
                        {
                            if (dt.Rows[i]["IS_IATROGENIC_INJURYS"].ToString() == "Y")
                            {
                                rdoIS_IATROGENIC_INJURY_Y.Checked = true;
                                if (dt.Rows[i]["IATROGENIC_INJURY"].ToString().Trim() != "")//医源性伤害情况（从数据字典中取相关的代码）
                                {

                                    //cboIS_IATROGENIC_INJURY.SelectedValue = dt.Rows[i]["BEF_OPER_CASE"].ToString();
                                    string[] vals = dt.Rows[i]["IATROGENIC_INJURY"].ToString().Split(',');
                                    for (int i1 = 0; i1 < vals.Length; i1++)
                                    {
                                        for (int j = 0; j < chkIS_IATROGENIC_INJURY.Items.Count; j++)
                                        {
                                            DataRowView temp = (DataRowView)chkIS_IATROGENIC_INJURY.Items[j];
                                            if (temp["id"].ToString() == vals[i1])
                                            {
                                                chkIS_IATROGENIC_INJURY.SetItemChecked(j, true);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_IATROGENIC_INJURY_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["IS_RESPIRATOR"].ToString().Trim() != "")//是否使用呼吸机  Y 是 N 否
                        {
                            if (dt.Rows[i]["IS_RESPIRATOR"].ToString() == "Y")
                            {
                                rdoIS_RESPIRATOR_Y.Checked = true;
                                pIS_RESPIRATOR.Visible = true;
                                if (dt.Rows[i]["RESPIRATOR_DAYS"].ToString().Trim() != "")//呼吸机使用天数
                                {
                                    txtRESPIRATOR_DAYS.Text = dt.Rows[i]["RESPIRATOR_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_RPT_PNEUMONIA_INFECTION"].ToString().Trim() != "")//是否发生使用呼吸机相关肺炎感染  Y 是 N 否
                                {
                                    if (dt.Rows[i]["IS_RPT_PNEUMONIA_INFECTION"].ToString() == "Y")
                                    {
                                        rdoIS_RPT_PNEUMONIA_INFECTION_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_RPT_PNEUMONIA_INFECTION_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_RESPIRATOR_N.Checked = true;
                                pIS_RESPIRATOR.Visible = false;
                            }
                        }

                        if (dt.Rows[i]["IS_CATHETERIZATION"].ToString().Trim() != "")//是否使用中心静脉置管 Y 是 N 否
                        {
                            if (dt.Rows[i]["IS_CATHETERIZATION"].ToString() == "Y")
                            {
                                rdoIS_CATHETERIZATION_Y.Checked = true;
                                pIS_CATHETERIZATION.Visible = true;
                                if (dt.Rows[i]["CATHETERIZATION_DAYS"].ToString().Trim() != "")//中心静脉置管天数
                                {
                                    txtCATHETERIZATION_DAYS.Text = dt.Rows[i]["CATHETERIZATION_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_CATHETERIZATION_INFECT"].ToString().Trim() != "")//是否发生使用中心静脉置管相关血流感染  Y 是 N 否
                                {
                                    if (dt.Rows[i]["IS_CATHETERIZATION_INFECT"].ToString() == "Y")
                                    {
                                        rdoIS_CATHETERIZATION_INFECT_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_CATHETERIZATION_INFECT_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_CATHETERIZATION_N.Checked = true;
                                pIS_CATHETERIZATION.Visible = false;
                            }
                        }

                        

                        if (dt.Rows[i]["IS_CATHETER"].ToString().Trim() != "")//是否使用留置导尿管 Y 是 N 否
                        {
                            if (dt.Rows[i]["IS_CATHETER"].ToString() == "Y")
                            {
                                rdoIS_CATHETER_Y.Checked = true;
                                pIS_CATHETER.Visible = true;
                                if (dt.Rows[i]["CATHETER_DAYS"].ToString().Trim() != "")//使用导尿管天数
                                {
                                    txtCATHETER_DAYS.Text = dt.Rows[i]["CATHETER_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_U_S_INFECTION"].ToString().Trim() != "")//是否尿系感染 Y 是 N 否
                                {
                                    if (dt.Rows[i]["IS_U_S_INFECTION"].ToString() == "Y")
                                    {
                                        rdoIS_U_S_INFECTION_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_U_S_INFECTION_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_CATHETER_N.Checked = true;
                                pIS_CATHETER.Visible = false;
                            }
                        }

                        

                        if (dt.Rows[i]["IS_HEMODIALYSIS"].ToString().Trim() != "")//血液透析  Y 是 N 否
                        {
                            if (dt.Rows[i]["IS_HEMODIALYSIS"].ToString() == "Y")
                            {
                                rdoIS_HEMODIALYSIS_Y.Checked = true;
                                pIS_HEMODIALYSIS.Visible = true;
                                if (dt.Rows[i]["HEMODIALYSIS_DAYS"].ToString().Trim() != "")//血液透析天数
                                {
                                    txtHEMODIALYSIS_DAYS.Text = dt.Rows[i]["HEMODIALYSIS_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_HEMODIALYSIS_INFECT"].ToString().Trim() != "")//是否血液透析感染
                                {
                                    if (dt.Rows[i]["IS_HEMODIALYSIS_INFECT"].ToString() == "Y")
                                    {
                                        rdoIS_HEMODIALYSIS_INFECT_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_HEMODIALYSIS_INFECT_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_HEMODIALYSIS_N.Checked = true;
                                pIS_HEMODIALYSIS.Visible = false;
                            }
                        }

                        
                    }
                }

            }
            catch (Exception ex)
            {
                App.MsgErr("初始化失败,原因:"+ex.Message);
            }
        }

        /// <summary>
        /// 添加或修改附页的信息
        /// </summary>
        /// <returns></returns>
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
                foreach (Control c in this.pISHAVEIN.Controls)
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
                foreach (Control c in this.pIS_CATHETERIZATION.Controls)
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
                foreach (Control c in this.pIS_HEMODIALYSIS.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }

                //c.ForeColor = Color.Black;//赋list中的字体颜色
                   

                string ISHAVEIN = "";    //是否再次入院 Y 是 N 否
                string HAVEIN_COUNT = "";  //再次入院天数
                string HAVEIN_REASON = ""; //再次入院原因

                if (radISHAVEINNo.Checked)
                {
                    ISHAVEIN = "N";
                }
                else if (radISHAVEINYes.Checked)
                {
                    ISHAVEIN = "Y";
                    if (txtHAVEIN_COUNT.Text != "")
                    {
                        HAVEIN_COUNT = txtHAVEIN_COUNT.Text;
                    }
                    else
                    {
                        label2.ForeColor = Color.Red;
                        label13.ForeColor = Color.Red;
                        App.Msg("提示:[" + label2.Text + "]未填写!");
                        return false;
                    }


                    if (rdoHAVEIN_REASON_other.Checked)
                    {
                        HAVEIN_REASON = "2";
                    }
                    else if (rdoHAVEIN_REASON_as.Checked)
                    {
                        HAVEIN_REASON = "1";
                    }
                    else
                    {
                        label3.ForeColor = Color.Red;
                        App.Msg("提示:[" + label3.Text + "]未选择!");
                        return false;
                    }
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    App.Msg("提示:[" + label1.Text + "]未选择!");
                    return false;
                }

                
                

                string IN_CASE = "";         //入院时情况
                if (rdoIN_CASE_BW.Checked)
                {
                    IN_CASE = "1";
                }
                else if (rdoIN_CASE_BZ.Checked)
                {
                    IN_CASE = "2";
                }
                else if (rdoIN_CASE_YB.Checked)
                {
                    IN_CASE = "3";
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    App.Msg("提示:[" + label4.Text + "]未选择!");
                    return false;
                }

                string DEATH_REASON = "";    //死亡原因
                if (rdoDEATH_REASON_YQSW.Checked)
                {
                    DEATH_REASON = "0";
                }
                else if (rdoDEATH_REASON_SZSW.Checked)
                {
                    DEATH_REASON = "1";
                }
                else if (rdoDEATH_REASON_MZSW.Checked)
                {
                    DEATH_REASON = "2";
                }
                else if (rdoDEATH_REASON_YYCW.Checked)
                {
                    DEATH_REASON = "3";
                }
                else if (rdoDEATH_REASON_SHBFZ.Checked)
                {
                    DEATH_REASON = "4";
                }
                else
                {
                    label5.ForeColor = Color.Red;
                    App.Msg("提示:[" + label5.Text + "]未选择!");
                    return false;
                }



                string ISINFUSE = "";        //是否输液 Y 是 N 否
                if (rdoISINFUSE_Y.Checked)
                {
                    ISINFUSE = "Y";
                }
                else if (rdoISINFUSE_N.Checked)
                {
                    ISINFUSE = "N";
                }
                else
                {
                    label6.ForeColor = Color.Red;
                    App.Msg("提示:[" + label6.Text + "]未选择!");
                    return false;
                }

                string INFUSE_REACTION = ""; //输液反应
                if (rdoINFUSE_REACTION_Y.Checked)
                {
                    INFUSE_REACTION = "1";
                }
                else if (rdoINFUSE_REACTION_N.Checked)
                {
                    INFUSE_REACTION = "2";
                }
                else
                {
                    label14.ForeColor = Color.Red;
                    App.Msg("提示:[" + label14.Text + "]未选择!");
                    return false;
                }


                string ISBOOLDINFUSE = "";   //是否输血 Y 是 N 否
                if (rdoISBOOLDINFUSE_Y.Checked)
                {
                    ISBOOLDINFUSE = "Y";
                }
                else if (rdoISBOOLDINFUSE_N.Checked)
                {
                    ISBOOLDINFUSE = "N";
                }
                else
                {
                    label7.ForeColor = Color.Red;
                    App.Msg("提示:[" + label7.Text + "]未选择!");
                    return false;
                }

                string BLOODINFUSE_REACTION = ""; //输血反应
                if (rdoBLOODINFUSE_REACTION_Y.Checked)
                {
                    BLOODINFUSE_REACTION = "1";
                }
                else if (rdoBLOODINFUSE_REACTION_N.Checked)
                {
                    BLOODINFUSE_REACTION = "2";
                }
                else
                {
                    label15.ForeColor = Color.Red;
                    App.Msg("提示:[" + label15.Text + "]未选择!");
                    return false;
                }

                string ISCOMPLICATING_DISEASE = ""; //是否并发症  Y 是 N 否
                if (rdoISCOMPLICATING_DISEASE_Y.Checked)
                {
                    ISCOMPLICATING_DISEASE = "Y";
                }
                else if (rdoISCOMPLICATING_DISEASE_N.Checked)
                {
                    ISCOMPLICATING_DISEASE = "N";
                }
                else
                {
                    label8.ForeColor = Color.Red;
                    App.Msg("提示:[" + label8.Text + "]未选择!");
                    return false;
                }

                string ISINFECT = "";                //是否院内感染  Y 是 N 否
                if (rdoISINFECT_Y.Checked)
                {
                    ISINFECT = "Y";
                }
                else if (rdoISINFECT_N.Checked)
                {
                    ISINFECT = "N";
                }
                else
                {
                    label16.ForeColor = Color.Red;
                    App.Msg("提示:[" + label16.Text + "]未选择!");
                    return false;
                }

                string OPER_FROZEN_PARAFFIN = "";    //手术冰冻与石蜡病理诊断符合情况
                if (rdoOPER_FROZEN_PARAFFIN_WZ.Checked)
                {
                    OPER_FROZEN_PARAFFIN = "0";
                }
                else if (rdoOPER_FROZEN_PARAFFIN_FH.Checked)
                {
                    OPER_FROZEN_PARAFFIN = "1";
                }
                else if (rdoOPER_FROZEN_PARAFFIN_BFH.Checked)
                {
                    OPER_FROZEN_PARAFFIN = "2";
                }
                else
                {
                    label9.ForeColor = Color.Red;
                    App.Msg("提示:[" + label9.Text + "]未选择!");
                    return false;
                }

                string BEF_OPER_CASE = "";           //术前诊断与术后病理诊断符合情况
                if (rdoBEF_OPER_CASE_WZ.Checked)
                {
                    BEF_OPER_CASE = "0";
                }
                else if (rdoBEF_OPER_CASE_FH.Checked)
                {
                    BEF_OPER_CASE = "1";
                }
                else if (rdoBEF_OPER_CASE_BFH.Checked)
                {
                    BEF_OPER_CASE = "2";
                }
                else
                {
                    label10.ForeColor = Color.Red;
                    App.Msg("提示:[" + label10.Text + "]未选择!");
                    return false;
                }

                string IS_COMPLICATING_DISEASES = ""; //是否发生术后并发症
                if (rdoCOMPLICATING_DISEASE_Y.Checked)
                {
                    IS_COMPLICATING_DISEASES = "Y";
                }
                else if (rdoCOMPLICATING_DISEASE_N.Checked)
                {
                    IS_COMPLICATING_DISEASES = "N";
                }
                else
                {
                    label11.ForeColor = Color.Red;
                    App.Msg("提示:[" + label11.Text + "]未选择!");
                    return false;
                }

                string COMPLICATING_DISEASE = "";     //并发症情况（从数据字典中取相关的代码）

                if (rdoCOMPLICATING_DISEASE_Y.Checked)
                {
                    //if (cboCOMPLICATING_DISEASE.SelectedValue != null)
                    //{
                    //    COMPLICATING_DISEASE = cboCOMPLICATING_DISEASE.SelectedValue.ToString();
                    //}
                    if (chkCOMPLICATING_DISEASE.Items.Count > 0 && chkCOMPLICATING_DISEASE.CheckedItems.Count == 0)
                    {

                        label11.ForeColor = Color.Red;
                        App.Msg("提示:[并发症情况]未选择!");
                        return false;
                    }

                    for (int i = 0; i < chkCOMPLICATING_DISEASE.CheckedItems.Count; i++)
                    {

                        DataRowView temp = (DataRowView)chkCOMPLICATING_DISEASE.CheckedItems[i];
                        if (COMPLICATING_DISEASE == "")
                        {
                            COMPLICATING_DISEASE = temp["id"].ToString();
                        }
                        else
                        {
                            COMPLICATING_DISEASE =COMPLICATING_DISEASE+","+temp["id"].ToString();
                        }

                    }
                }

                string IS_IATROGENIC_INJURYS = ""; //是否发生医源性伤害情况
                if (rdoIS_IATROGENIC_INJURY_Y.Checked)
                {
                    IS_IATROGENIC_INJURYS = "Y";
                }
                else if (rdoIS_IATROGENIC_INJURY_N.Checked)
                {
                    IS_IATROGENIC_INJURYS = "N";
                }
                else
                {
                    label12.ForeColor = Color.Red;
                    App.Msg("提示:[" + label12.Text + "]未选择!");
                    return false;
                }

                string IATROGENIC_INJURY = "";        //医源性伤害情况（从数据字典中取相关的代码）
                if (rdoIS_IATROGENIC_INJURY_Y.Checked)
                {        
                    //if (cboIS_IATROGENIC_INJURY.SelectedValue != null)
                    //{
                    //    COMPLICATING_DISEASE = cboIS_IATROGENIC_INJURY.SelectedValue.ToString();
                    //}
                    if (chkIS_IATROGENIC_INJURY.Items.Count > 0 && chkIS_IATROGENIC_INJURY.CheckedItems.Count == 0)
                    {
                        label12.ForeColor = Color.Red;
                        App.Msg("提示:[医源性伤害情况]未选择!");
                        return false;
                    }
                    for (int i = 0; i < chkIS_IATROGENIC_INJURY.CheckedItems.Count; i++)
                    {
                        DataRowView temp = (DataRowView)chkIS_IATROGENIC_INJURY.CheckedItems[i];
                        if (IATROGENIC_INJURY == "")
                        {
                            IATROGENIC_INJURY = temp["id"].ToString();
                        }
                        else
                        {
                            IATROGENIC_INJURY = IATROGENIC_INJURY + "," + temp["id"].ToString();
                        }
                    }
                }

                string IS_RESPIRATOR = "";           //是否使用呼吸机  Y 是 N 否
                string RESPIRATOR_DAYS = "";          //呼吸机使用天数
                string IS_RPT_PNEUMONIA_INFECTION = "";//是否发生使用呼吸机相关肺炎感染  Y 是 N 否
                if (rdoIS_RESPIRATOR_Y.Checked)
                {
                    IS_RESPIRATOR = "Y";
                    if (txtRESPIRATOR_DAYS.Text != "")
                    {
                        RESPIRATOR_DAYS = txtRESPIRATOR_DAYS.Text;
                    }
                    else
                    {
                        label22.ForeColor = Color.Red;
                        label21.ForeColor = Color.Red;
                        App.Msg("提示:[" + label22.Text + "]未填写!");
                        return false;
                    }

                    if (rdoIS_RPT_PNEUMONIA_INFECTION_Y.Checked)
                    {
                        IS_RPT_PNEUMONIA_INFECTION = "Y";
                    }
                    else if (rdoIS_RPT_PNEUMONIA_INFECTION_N.Checked)
                    {
                        IS_RPT_PNEUMONIA_INFECTION = "N";
                    }
                    else
                    {
                        label29.ForeColor = Color.Red;
                        App.Msg("提示:[" + label29.Text + "]未选择!");
                        return false;
                    }
                }
                else if (rdoIS_RESPIRATOR_N.Checked)
                {
                    IS_RESPIRATOR = "N";
                }
                else
                {
                    label17.ForeColor = Color.Red;
                    App.Msg("提示:[" + label17.Text + "]未选择!");
                    return false;
                }

                
                string IS_CATHETERIZATION = "";        //是否使用中心静脉置管 Y 是 N 否
                string CATHETERIZATION_DAYS = "";       //中心静脉置管天数
                string IS_CATHETERIZATION_INFECT = ""; //是否发生使用中心静脉置管相关血流感染  Y 是 N 否
                if (rdoIS_CATHETERIZATION_Y.Checked)
                {
                    IS_CATHETERIZATION = "Y";
                    if (txtCATHETERIZATION_DAYS.Text != "")
                    {
                        CATHETERIZATION_DAYS = txtCATHETERIZATION_DAYS.Text;
                    }
                    else
                    {
                        label24.ForeColor = Color.Red;
                        label23.ForeColor = Color.Red;
                        App.Msg("提示:[" + label24.Text + "]未填写!");
                        return false;
                    }

                    if (rdoIS_CATHETERIZATION_INFECT_Y.Checked)
                    {
                        IS_CATHETERIZATION_INFECT = "Y";
                    }
                    else if (rdoIS_CATHETERIZATION_INFECT_N.Checked)
                    {
                        IS_CATHETERIZATION_INFECT = "N";
                    }
                    else
                    {
                        label30.ForeColor = Color.Red;
                        App.Msg("提示:[" + label30.Text + "]未选择!");
                        return false;
                    }
                }
                else if (rdoIS_CATHETERIZATION_N.Checked)
                {
                    IS_CATHETERIZATION = "N";
                }
                else
                {
                    label18.ForeColor = Color.Red;
                    App.Msg("提示:[" + label18.Text + "]未选择!");
                    return false;
                }

                string IS_CATHETER = "";               //是否使用留置导尿管 Y 是 N 否
                string CATHETER_DAYS = "";              //使用导尿管天数
                string IS_U_S_INFECTION = "";          //是否尿系感染 Y 是 N 否
                if (rdoIS_CATHETER_Y.Checked)
                {
                    IS_CATHETER = "Y";
                    if (txtCATHETER_DAYS.Text != "")
                    {
                        CATHETER_DAYS = txtCATHETER_DAYS.Text;
                    }
                    else
                    {
                        label26.ForeColor = Color.Red;
                        label25.ForeColor = Color.Red;
                        App.Msg("提示:[" + label26.Text + "]未填写!");
                        return false;
                    }

                    if (rdoIS_U_S_INFECTION_Y.Checked)
                    {
                        IS_U_S_INFECTION = "Y";
                    }
                    else if (rdoIS_U_S_INFECTION_N.Checked)
                    {
                        IS_U_S_INFECTION = "N";
                    }
                    else
                    {
                        label31.ForeColor = Color.Red;
                        App.Msg("提示:[" + label31.Text + "]未选择!");
                        return false;
                    }
                }
                else if (rdoIS_CATHETER_N.Checked)
                {
                    IS_CATHETER = "N";
                }
                else
                {
                    label19.ForeColor = Color.Red;
                    App.Msg("提示:[" + label19.Text + "]未选择!");
                    return false;
                }

                
                

                string IS_HEMODIALYSIS = "";           //血液透析  Y 是 N 否
                string HEMODIALYSIS_DAYS = "";          //血液透析天数
                string IS_HEMODIALYSIS_INFECT = "";    //是否血液透析感染
                if (rdoIS_HEMODIALYSIS_Y.Checked)
                {
                    IS_HEMODIALYSIS = "Y";
                    if (txtHEMODIALYSIS_DAYS.Text != "")
                    {
                        HEMODIALYSIS_DAYS = txtHEMODIALYSIS_DAYS.Text;
                    }
                    else
                    {
                        label28.ForeColor = Color.Red;
                        label27.ForeColor = Color.Red;
                        App.Msg("提示:[" + label28.Text + "]未填写!");
                        return false;
                    }

                    if (rdoIS_HEMODIALYSIS_INFECT_Y.Checked)
                    {
                        IS_HEMODIALYSIS_INFECT = "Y";
                    }
                    else if (rdoIS_HEMODIALYSIS_INFECT_N.Checked)
                    {
                        IS_HEMODIALYSIS_INFECT = "N";
                    }
                    else
                    {
                        label32.ForeColor = Color.Red;
                        App.Msg("提示:[" + label32.Text + "]未选择!");
                        return false;
                    }
                }
                else if (rdoIS_HEMODIALYSIS_N.Checked)
                {
                    IS_HEMODIALYSIS = "N";
                }
                else
                {
                    label20.ForeColor = Color.Red;
                    App.Msg("提示:[" + label20.Text + "]未选择!");
                    return false;
                }


                string Sql = "";
                if (Cover_Append_id == "")
                {
                    Sql = "insert into COVER_APPEND_IN(PATIENT_ID,ISHAVEIN,HAVEIN_COUNT,HAVEIN_REASON," +
                                                           "IN_CASE,DEATH_REASON,ISINFUSE,INFUSE_REACTION,ISBOOLDINFUSE," +
                                                           "BLOODINFUSE_REACTION,ISCOMPLICATING_DISEASE,ISINFECT,OPER_FROZEN_PARAFFIN," +
                                                           "BEF_OPER_CASE,COMPLICATING_DISEASE,IATROGENIC_INJURY,IS_RESPIRATOR," +
                                                           "RESPIRATOR_DAYS,IS_RPT_PNEUMONIA_INFECTION,IS_CATHETERIZATION,CATHETERIZATION_DAYS," +
                                                           "IS_CATHETERIZATION_INFECT,IS_CATHETER,CATHETER_DAYS,IS_U_S_INFECTION,IS_HEMODIALYSIS," +
                                                           "HEMODIALYSIS_DAYS,IS_HEMODIALYSIS_INFECT,IS_COMPLICATING_DISEASES,IS_IATROGENIC_INJURYS,CREATE_TIME,USER_ID)values({0},'{1}','{2}','{3}','{4}','{5}'," +
                                                           "'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}'," +
                                                           "'{23}','{24}','{25}','{26}','{27}','{28}','{29}',to_timestamp('{30}','syyyy-mm-dd hh24:mi'),{31})";

                    Sql = string.Format(Sql, PatientId, ISHAVEIN, HAVEIN_COUNT, HAVEIN_REASON, IN_CASE, DEATH_REASON,
                                      ISINFUSE, INFUSE_REACTION, ISBOOLDINFUSE, BLOODINFUSE_REACTION, ISCOMPLICATING_DISEASE, ISINFECT,
                                      OPER_FROZEN_PARAFFIN, BEF_OPER_CASE, COMPLICATING_DISEASE, IATROGENIC_INJURY, IS_RESPIRATOR,
                                      RESPIRATOR_DAYS, IS_RPT_PNEUMONIA_INFECTION, IS_CATHETERIZATION, CATHETERIZATION_DAYS,
                                      IS_CATHETERIZATION_INFECT, IS_CATHETER, CATHETER_DAYS, IS_U_S_INFECTION, IS_HEMODIALYSIS,
                                      HEMODIALYSIS_DAYS, IS_HEMODIALYSIS_INFECT,IS_COMPLICATING_DISEASES,IS_IATROGENIC_INJURYS, App.GetSystemTime().ToShortDateString(), App.UserAccount.UserInfo.User_id);
                }
                else
                {
                    Sql = "update COVER_APPEND_IN set ISHAVEIN='{0}',HAVEIN_COUNT='{1}',HAVEIN_REASON='{2}'," +
                                                          "IN_CASE='{3}',DEATH_REASON='{4}',ISINFUSE='{5}',INFUSE_REACTION='{6}',ISBOOLDINFUSE='{7}'," +
                                                          "BLOODINFUSE_REACTION='{8}',ISCOMPLICATING_DISEASE='{9}',ISINFECT='{10}',OPER_FROZEN_PARAFFIN='{11}'," +
                                                          "BEF_OPER_CASE='{12}',COMPLICATING_DISEASE='{13}',IATROGENIC_INJURY='{14}',IS_RESPIRATOR='{15}'," +
                                                          "RESPIRATOR_DAYS='{16}',IS_RPT_PNEUMONIA_INFECTION='{17}',IS_CATHETERIZATION='{18}',CATHETERIZATION_DAYS='{19}'," +
                                                          "IS_CATHETERIZATION_INFECT='{20}',IS_CATHETER='{21}',CATHETER_DAYS='{22}',IS_U_S_INFECTION='{23}',IS_HEMODIALYSIS='{24}'," +
                                                          "HEMODIALYSIS_DAYS='{25}',IS_HEMODIALYSIS_INFECT='{26}',IS_COMPLICATING_DISEASES='{27}',IS_IATROGENIC_INJURYS='{28}' where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";

                    Sql = string.Format(Sql, ISHAVEIN, HAVEIN_COUNT, HAVEIN_REASON, IN_CASE, DEATH_REASON,
                                    ISINFUSE, INFUSE_REACTION, ISBOOLDINFUSE, BLOODINFUSE_REACTION, ISCOMPLICATING_DISEASE, ISINFECT,
                                    OPER_FROZEN_PARAFFIN, BEF_OPER_CASE, COMPLICATING_DISEASE, IATROGENIC_INJURY, IS_RESPIRATOR,
                                    RESPIRATOR_DAYS, IS_RPT_PNEUMONIA_INFECTION, IS_CATHETERIZATION, CATHETERIZATION_DAYS,
                                    IS_CATHETERIZATION_INFECT, IS_CATHETER, CATHETER_DAYS, IS_U_S_INFECTION, IS_HEMODIALYSIS,
                                    HEMODIALYSIS_DAYS, IS_HEMODIALYSIS_INFECT,IS_COMPLICATING_DISEASES,IS_IATROGENIC_INJURYS);

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
            catch(Exception ex)
            {
                App.MsgErr("操作失败,原因:" + ex.Message);
                return false;
            }
        }
        

        #region 控制是否使用呼吸机,中心静脉置管,留置导尿管,血液透析,是否再入院,是否发生术后并发症情况,是否发生医源性伤害情况等附属的内容显示与不显示
        private void rdoIS_HEMODIALYSIS_Y_CheckedChanged(object sender, EventArgs e)
        {//血液透析
            if (rdoIS_HEMODIALYSIS_Y.Checked)
                pIS_HEMODIALYSIS.Visible = true;
            else
            {
                pIS_HEMODIALYSIS.Visible = false;
                txtHEMODIALYSIS_DAYS.Text = "";
                rdoIS_HEMODIALYSIS_INFECT_Y.Checked = false;
                rdoIS_HEMODIALYSIS_INFECT_N.Checked = false;
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
                rdoIS_U_S_INFECTION_Y.Checked = false;
                rdoIS_U_S_INFECTION_N.Checked = false; 
            }
        }

        private void rdoIS_CATHETERIZATION_Y_CheckedChanged(object sender, EventArgs e)
        {//中心静脉置管
            if (rdoIS_CATHETERIZATION_Y.Checked)
                pIS_CATHETERIZATION.Visible = true;
            else
            {
                pIS_CATHETERIZATION.Visible = false;
                txtCATHETERIZATION_DAYS.Text = "";
                rdoIS_CATHETERIZATION_INFECT_Y.Checked = false;
                rdoIS_CATHETERIZATION_INFECT_N.Checked = false;
            }
        }

        private void rdoIS_RESPIRATOR_Y_CheckedChanged(object sender, EventArgs e)
        {//呼吸机
            if (rdoIS_RESPIRATOR_Y.Checked)
                pIS_RESPIRATOR.Visible = true;
            else
            {
                pIS_RESPIRATOR.Visible = false;
                txtRESPIRATOR_DAYS.Text = "";
                rdoIS_RPT_PNEUMONIA_INFECTION_Y.Checked = false;
                rdoIS_RPT_PNEUMONIA_INFECTION_N.Checked = false;
            }
        }
        

        private void radISHAVEINYes_CheckedChanged(object sender, EventArgs e)
        {//是否再入院
            if (radISHAVEINYes.Checked)
                pISHAVEIN.Visible = true;
            else
                pISHAVEIN.Visible = false;
        }

        private void rdoCOMPLICATING_DISEASE_Y_CheckedChanged(object sender, EventArgs e)
        {//是否发生术后并发症情况
            if (rdoCOMPLICATING_DISEASE_Y.Checked)
                chkCOMPLICATING_DISEASE.Enabled = true;
            else
            {
                chkCOMPLICATING_DISEASE.Enabled = false;
                foreach (int i in chkCOMPLICATING_DISEASE.CheckedIndices)
                {
                    chkCOMPLICATING_DISEASE.SetItemChecked(i, false);
                }
            }
        }

        private void rdoIS_IATROGENIC_INJURY_Y_CheckedChanged(object sender, EventArgs e)
        {//是否发生医源性伤害情况
            if (rdoIS_IATROGENIC_INJURY_Y.Checked)
                chkIS_IATROGENIC_INJURY.Enabled = true;
            else
            {
                chkIS_IATROGENIC_INJURY.Enabled = false;
                foreach (int i in chkIS_IATROGENIC_INJURY.CheckedIndices)
                {
                    chkIS_IATROGENIC_INJURY.SetItemChecked(i, false);
                }
            }
        }

        #endregion
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

        
    }
}
