using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using C1.Win.C1FlexGrid;
using Base_Function.BLL_DOCTOR;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class frmHint : Office2007Form
    {
        string tempSQL = "";
        Image imgbl;
        Image imgYel;
        Image imgRed;
        /// <summary>
        /// 当前选中的医生名称
        /// </summary>
        string current_name = string.Empty;
        /// <summary>
        /// 当前医生的所以红黄情况
        /// </summary>
        StringBuilder strsqls = new StringBuilder();
        /// <summary>
        /// 1单项不是补录
        /// </summary>
        /// <param name="q"></param>
        /// <param name="names"></param>
        /// <param name="yel"></param>
        public frmHint(Class_Record_Monitor_View q, string names,Image yel)
        {
            InitializeComponent();
            try
            {
                this.imgYel = yel;
                ucC1FlexGrid1.fg.AllowEditing = false;
                string selectDotor = string.Empty;
                if (names == "HLB" || names.Contains("护理部"))
                {
                    string DocTypeID = App.ReadSqlVal("select tqv.id from t_quality_var_hlb tqv inner join t_data_code ta on tqv.document_type=ta.id where tqv.name='" + q.DocType + "'", 0, "name");
                    tempSQL = "select tip.id,tip.pid,tip.sick_area_name,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name,tqr.note,tqr.pv from t_quality_record_hlb tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid "+
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id where " +
                        " tqr.doctype in(" + q.DocTypeID + ") and tqr.pv=" + q.PV + "";//and tip.sick_area_name='" + q.SickArea_Name + "'
                    
                    selectDotor = "select count((case tqr.pv when '1' then tip.id end)) 红灯," +
                                " count((case tqr.pv when '0' then tip.id end)) 黄灯," +
                                " tip.sick_doctor_name,tip.sick_doctor_id from t_quality_record_hlb tqr" +
                                " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                                " inner join t_sectioninfo ts on tip.section_id=ts.sid where tqr.doctype in(" + q.DocTypeID + ")";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.sick_area_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.sick_area_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                }
                if (names == "YWC" || names.Contains("医务处"))
                {
                    tempSQL = "select tip.id,tip.pid,tip.section_name,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name,tqr.note,tqr.pv from t_quality_record tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id where " +
                        "tqr.doctype='" + q.DocType + "' and tqr.pv=" + q.PV + "";
                    //if (q.SickArea_Name != null)
                    //    tempSQL += " and tip.section_name='" + q.SickArea_Name + "'";
                    selectDotor = "select count((case tqr.pv when '1' then tip.id end)) 红灯," +
                                   " count((case tqr.pv when '0' then tip.id end)) 黄灯," +
                                   " tip.sick_doctor_name,tip.sick_doctor_id from t_quality_record tqr" +
                                   " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                                   " inner join t_sectioninfo ts on tip.section_id=ts.sid where tqr.doctype='" + q.DocType + "' and tqr.pv=" + q.PV + "";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.section_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.section_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                }
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(fgDouble_Click);
                InitTable(tempSQL+" order by tip.sick_bed_id, tqr.noteztime asc", names);
                InitLigth(selectDotor, false);
            }
            catch (Exception)
            {
                
                //throw;
            }
        }

        /// <summary>
        /// 2
        /// </summary>
        /// <param name="isDoctor"></param>
        /// <param name="q"></param>
        /// <param name="names"></param>
        /// <param name="isMOre"></param>
        /// <param name="yel"></param>
        /// <param name="imgred"></param>
        public frmHint(bool isDoctor,Class_Record_Monitor_View q, string names, bool isMOre, Image yel, Image imgred)
        {
            InitializeComponent();
            try
            {
                tabItem2.Visible = isDoctor;
                this.imgRed = imgred;
                this.imgYel = yel;
                ucC1FlexGrid1.fg.AllowEditing = false;
                string selectDotor = string.Empty;
                if (names == "HLB" || names.Contains("护理部"))
                {
                    tempSQL = "select tip.id,tip.pid,tip.sick_area_name,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name," +
                              "tqr.note,tqr.pv from t_quality_record_hlb tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id where " +
                              " tip.sick_doctor_name='" + q.DocType + "'";//and tip.sick_area_name='" + q.SickArea_Name + "'

                    selectDotor = "select count((case tqr.pv when '1' then tip.id end)) 红灯," +
                                " count((case tqr.pv when '0' then tip.id end)) 黄灯," +
                                " tip.sick_doctor_name,tip.sick_doctor_id from t_quality_record_hlb tqr" +
                                " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                                " inner join t_sectioninfo ts on tip.section_id=ts.sid where tip.sick_doctor_name='" + q.DocType + "' ";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.sick_area_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.sick_area_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                }
                if (names == "YWC" || names.Contains("医务处"))
                {
                    tempSQL = "select tip.id,tip.pid,tip.section_name,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name," +
                        "tqr.note,tqr.pv from t_quality_record tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id where " +
                        "tip.sick_doctor_name='" + q.DocType + "' and tqr.pv!=3 ";
                    selectDotor = "select count((case tqr.pv when '1' then tip.id end)) 红灯," +
                                   " count((case tqr.pv when '0' then tip.id end)) 黄灯," +
                                   " tip.sick_doctor_name,tip.sick_doctor_id from t_quality_record tqr" +
                                   " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                                   " inner join t_sectioninfo ts on tip.section_id=ts.sid where tip.sick_doctor_name='" + q.DocType + "' and tqr.pv!=3 ";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.section_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.section_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                }
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(fgDouble_Click);

                InitTable(tempSQL + " order by tip.sick_bed_id, tqr.noteztime asc", names,true);
                //InitLigth(selectDotor, true);
                //tabControlPanel1.Controls.Add(ucC1FlexGrid1);
            }
            catch (Exception ex)
            {
                
                //throw;
            }
        }

        /// <summary>
        /// 3
        /// </summary>
        /// <param name="q"></param>
        /// <param name="names"></param>
        /// <param name="isMOre"></param>
        /// <param name="yel"></param>
        /// <param name="imgred"></param>
        public frmHint(Class_Record_Monitor_View q, string names, bool isMOre, Image yel, Image imgred)
        {
            InitializeComponent();
            try
            {
                this.imgRed = imgred;
                this.imgYel = yel;
                ucC1FlexGrid1.fg.AllowEditing = false;
                string selectDotor = string.Empty;
                if (names == "HLB" || names.Contains("护理部"))
                {
                    tempSQL = "select tip.id,tip.pid,tip.sick_area_name,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name," +
                              "tqr.note,tqr.pv from t_quality_record_hlb tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id where " +
                              " tqr.doctype in(" + q.DocTypeID + ")";//and tip.sick_area_name='" + q.SickArea_Name + "'
                    //if (q.SickArea_ID != null)
                    //    tempSQL += " and tqr.section_sickaera=" + q.SickArea_ID;
                    selectDotor = "select count((case tqr.pv when '1' then tip.id end)) 红灯," +
                                " count((case tqr.pv when '0' then tip.id end)) 黄灯," +
                                " tip.sick_doctor_name,tip.sick_doctor_id from t_quality_record_hlb tqr" +
                                " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                                " inner join t_sectioninfo ts on tip.section_id=ts.sid where tqr.doctype in(" + q.DocTypeID + ")";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.sick_area_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.sick_area_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                }
                if (names == "YWC" || names.Contains("医务处"))
                {
                    tempSQL = "select tip.id,tip.pid,tip.section_name,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name," +
                        "tqr.note,tqr.pv from t_quality_record tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id where " +
                        "tqr.doctype='" + q.DocType + "' and tqr.pv!=3 ";
                    selectDotor = "select count((case tqr.pv when '1' then tip.id end)) 红灯," +
                                   " count((case tqr.pv when '0' then tip.id end)) 黄灯," +
                                   " tip.sick_doctor_name,tip.sick_doctor_id from t_quality_record tqr" +
                                   " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                                   " inner join t_sectioninfo ts on tip.section_id=ts.sid where tqr.doctype='" + q.DocType + "' and tqr.pv!=3 ";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.section_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.section_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                }
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(fgDouble_Click);

                InitTable(tempSQL + " order by tip.sick_bed_id, tqr.noteztime asc", names);
                InitLigth(selectDotor, true);
                //tabControlPanel1.Controls.Add(ucC1FlexGrid1);
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        /// <summary>
        /// 4
        /// </summary>
        /// <param name="q"></param>
        /// <param name="names"></param>
        /// <param name="isMOre"></param>
        /// <param name="yel"></param>
        /// <param name="imgred"></param>
        /// <param name="isvisable"></param>
        public frmHint(Class_Record_Monitor_View q, string names, bool isMOre, Image yel, Image imgred,bool isvisable)
        {
            InitializeComponent();
            try
            {
                this.imgRed = imgred;
                this.imgYel = yel;
                ucC1FlexGrid1.fg.AllowEditing = false;
                string selectDotor = string.Empty;
                if (names == "HLB" || names.Contains("护理部"))
                {
                    tempSQL = "select tip.id,tip.pid,tip.sick_area_name,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name," +
                              "tqr.note,tqr.pv from t_quality_record_hlb tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id where " +
                              " tqr.doctype in(" + q.DocTypeID + ")";//and tip.sick_area_name='" + q.SickArea_Name + "'
                    //if (q.SickArea_ID!=null)
                    //    tempSQL+= " and tqr.section_sickaera=" + q.SickArea_ID;
                    selectDotor = "select count((case tqr.pv when '1' then tip.id end)) 红灯," +
                                " count((case tqr.pv when '0' then tip.id end)) 黄灯," +
                                " tip.sick_doctor_name,tip.sick_doctor_id from t_quality_record_hlb tqr" +
                                " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                                " inner join t_sectioninfo ts on tip.section_id=ts.sid where tqr.doctype in(" + q.DocTypeID + ")";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.sick_area_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.sick_area_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                }
                if (names == "YWC" || names.Contains("医务处"))
                {
                    tempSQL = "select tip.id,tip.pid,tip.section_name,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name," +
                        "tqr.note,tqr.pv from t_quality_record tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id where " +
                        "tqr.doctype='" + q.DocType + "'";
                    selectDotor = "select count((case tqr.pv when '1' then tip.id end)) 红灯," +
                                   " count((case tqr.pv when '0' then tip.id end)) 黄灯," +
                                   " tip.sick_doctor_name,tip.sick_doctor_id from t_quality_record tqr" +
                                   " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                                   " inner join t_sectioninfo ts on tip.section_id=ts.sid where tqr.doctype='" + q.DocType + "'";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.section_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.section_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                }
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(fgDouble_Click);

                InitTable(tempSQL + " order by tip.sick_bed_id, tqr.noteztime asc", names);
                InitLigth(selectDotor, true);
                tabItem2.Visible = isvisable;
                //tabControlPanel1.Controls.Add(ucC1FlexGrid1);
            }
            catch (Exception ex)
            {

                //throw;
            }
        }

        /// <summary>
        /// 补录信息详细查看
        /// </summary>
        /// <param name="q"></param>
        /// <param name="names"></param>
        /// <param name="blimg"></param>
        /// <param name="IsDoctor">是否管床医生界面双击进入</param>
        public frmHint(Class_Record_Monitor_View q, string names, Image blimg,bool IsDoctor)
        {
            InitializeComponent();
            try
            {
                
                this.imgbl = blimg;
                ucC1FlexGrid1.fg.AllowEditing = false;
                string selectDotor = string.Empty;

                #region 注释老版质控查询
                //if (IsDoctor == false)
                //{//是否管床医生界面双击进入
                //    tempSQL = "select tip.id,tip.section_name,tip.pid,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name,tqr.text_name||' 红灯时间:'||to_char(tqr.red_time,'yyyy-MM-dd hh24:mi')||' 操作时间:'||to_char(tqr.operate_time,'yyyy-MM-dd hh24:mi') note,'2' pv from T_QUALITY_RECORD_TEMP tqr inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                //        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id  where tqr.operate_time>tqr.red_time and " +
                //        "tqr.text_name='" + q.DocType + "'";
                //    selectDotor = "select count(tqr.text_name) 补录," +
                //                   " tip.sick_doctor_name,tip.sick_doctor_id from T_QUALITY_RECORD_TEMP tqr" +
                //                   " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                //                   " where tqr.operate_time>tqr.red_time and tqr.text_name='" + q.DocType + "'";
                //    if (q.SickArea_Name != null)
                //    {
                //        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                //        {
                //            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                //            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                //        }
                //        else
                //        {
                //            tempSQL += " and tip.section_name='" + q.SickArea_Name + "'";
                //            selectDotor += " and tip.section_name='" + q.SickArea_Name + "'";
                //        }
                //    }
                //    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                //    tabItem2.Visible = true;
                //}
                //else
                //{
                //    tempSQL = "select tip.id,tip.section_name,tip.pid,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name,tqr.text_name||' 红灯时间:'||to_char(tqr.red_time,'yyyy-MM-dd hh24:mi')||' 操作时间:'||to_char(tqr.operate_time,'yyyy-MM-dd hh24:mi') note,'2' pv from T_QUALITY_RECORD_TEMP tqr inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                //        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id  where tqr.operate_time>tqr.red_time and " +
                //        "tip.sick_doctor_name='" + q.DocType + "'";
                //    selectDotor = "select count(tqr.text_name) 补录," +
                //                   " tip.sick_doctor_name,tip.sick_doctor_id from T_QUALITY_RECORD_TEMP tqr" +
                //                   " inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                //                   " where tqr.operate_time>tqr.red_time and tip.sick_doctor_name='" + q.DocType + "'";
                //    if (q.SickArea_Name != null)
                //    {
                //        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                //        {
                //            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                //            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                //        }
                //        else
                //        {
                //            tempSQL += " and tip.section_name='" + q.SickArea_Name + "'";
                //            selectDotor += " and tip.section_name='" + q.SickArea_Name + "'";
                //        }
                //    }
                //    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                //    tabItem2.Visible = false;
                //}
                #endregion
                if (IsDoctor == false)
                {//是否管床医生界面双击进入
                    tempSQL = "select tip.id,tip.section_name,tip.pid,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name,tqr.note,'3' pv from T_QUALITY_RECORD tqr inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null and instr(tip.his_id, '_') = 0 inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id  where tqr.pv=3 and " +
                        "tqr.doctype='" + q.DocType + "'";
                    selectDotor = "select count(tqr.doctype) 补录," +
                                   " tip.sick_doctor_name,tip.sick_doctor_id from T_QUALITY_RECORD tqr" +
                                   " inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null and instr(tip.his_id, '_') = 0 inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                                   " where tqr.pv=3 and tqr.doctype='" + q.DocType + "'";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.section_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.section_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                    tabItem2.Visible = true;
                }
                else
                {
                    tempSQL = "select tip.id,tip.section_name,tip.pid,tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name,u.name,tqr.note,'3' pv from T_QUALITY_RECORD tqr inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null and instr(tip.his_id, '_') = 0 inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                        " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id  where tqr.pv=3 and " +
                        "tip.sick_doctor_name='" + q.DocType + "'";
                    selectDotor = "select count(tqr.doctype) 补录," +
                                   " tip.sick_doctor_name,tip.sick_doctor_id from T_QUALITY_RECORD tqr" +
                                   " inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null and instr(tip.his_id, '_') = 0 inner join t_sectioninfo ts on tip.section_id=ts.sid " +
                                   " where tqr.pv=3 and tip.sick_doctor_name='" + q.DocType + "'";
                    if (q.SickArea_Name != null)
                    {
                        if (q.SickArea_Name == "北院" || q.SickArea_Name == "南院")
                        {
                            tempSQL += " and ts.shid='" + q.SickArea_ID + "'";
                            selectDotor += " and ts.shid='" + q.SickArea_ID + "'";
                        }
                        else
                        {
                            tempSQL += " and tip.section_name='" + q.SickArea_Name + "'";
                            selectDotor += " and tip.section_name='" + q.SickArea_Name + "'";
                        }
                    }
                    selectDotor += " group by tip.sick_doctor_name,tip.sick_doctor_id";
                    tabItem2.Visible = false;
                }
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(fgDouble_Click);
                ucC1FlexGrid1.DataBd(tempSQL + " order by tip.sick_bed_id, tqr.noteztime asc", "note", "pid,section_name,sick_bed_no,patient_name,sick_doctor_name,name,note,pv", "住院号,科室,床号,姓名,管床医生,职称,说明内容,提醒");
                refleshgrid();
                InitLigth(selectDotor);
            }
            catch (Exception)
            {

                //throw;
            }
        }


        public void InitTable(string temp,string names)
        {
            if (names == "HLB" || names.Contains("护理部"))
            {
                ucC1FlexGrid1.DataBd(temp, "note", "pid,sick_area_name,sick_bed_no,patient_name,sick_doctor_name,name,note,pv", "住院号,病区,床号,姓名,管床医生,职称,提示内容,提醒");
            }
            if (names == "YWC" || names.Contains("医务处"))
            {
                ucC1FlexGrid1.DataBd(temp, "note", "pid,section_name,sick_bed_no,patient_name,sick_doctor_name,name,note,pv", "住院号,科室,床号,姓名,管床医生,职称,提示内容,提醒");
            }
            refleshgrid();
            
        }

        public void InitTable(string temp, string names,bool isDoctor)
        {
            if (names == "HLB" || names.Contains("护理部"))
            {
                ucC1FlexGrid1.DataBd(temp, "note", "pid,sick_area_name,sick_bed_no,patient_name,sick_doctor_name,name,doctype,note,pv", "住院号,病区,床号,姓名,管床医生,职称,文书类型,提示内容,提醒");
            }
            if (names == "YWC" || names.Contains("医务处"))
            {
                ucC1FlexGrid1.DataBd(temp, "note", "pid,section_name,sick_bed_no,patient_name,sick_doctor_name,name,doctype,note,pv", "住院号,科室,床号,姓名,管床医生,职称,文书类型,提示内容,提醒");
            }
            refleshgrid();

        }
        private void refleshgrid()
        {
            try
            {
                //for (int i = 0; i < ucGridviewX1.fg.Rows.Count; i++)
                //{

                //    /*
                //     * 小灯
                //     */
                //    DataGridViewImageCell sc = ucGridviewX1.fg["状态", i] as DataGridViewImageCell;
                //    if (ucGridviewX1.fg["pv", i].Value.ToString() == "1")
                //        sc.Value = imageList1.Images[1];
                //    else
                //        sc.Value = imageList1.Images[0];
                //}
                ucC1FlexGrid1.fg.Cols["id"].Visible = false;
                ucC1FlexGrid1.fg.Cols["note"].Width = 400;
                for (int i = 1; i < ucC1FlexGrid1.fg.Rows.Count; i++)
                {
                    CellRange r = ucC1FlexGrid1.fg.GetCellRange(i, ucC1FlexGrid1.fg.Cols["pv"].Index);
                    if (ucC1FlexGrid1.fg.GetData(i, "pv").ToString().Trim() == "1")
                    {
                        r.Image = imageList1.Images[0];
                        r.Clip = string.Empty;
                    }
                    else if (ucC1FlexGrid1.fg.GetData(i, "pv").ToString().Trim() == "0")
                    {
                        r.Image = imageList1.Images[1];
                        r.Clip = string.Empty;
                    }
                    else if (ucC1FlexGrid1.fg.GetData(i, "pv").ToString().Trim() == "3")
                    {
                        r.Image = imageList1.Images[2];
                        r.Clip = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            { ex.Message.ToString(); }
        }
        private void TextChanged(object sender, EventArgs e)
        {
            refleshgrid();
        } 

        private void frmHint_Load(object sender, EventArgs e)
        {
            ucC1FlexGrid1.cboCurrentPage.TextChanged += new EventHandler(TextChanged);
            ucC1FlexGrid1.fg.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            tabControl1.SelectedTabIndex = 0;
        }

        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            //int Rowcount = 0;

            //int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号 

            //if (rows > 0)
            //{
            //    if (Rowcount == rows)
            //    {
            //        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
            //    }
            //    else
            //    {
            //        //如果不是头行
            //        if (rows > 0)
            //        {
            //            //就改变背景色
            //            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
            //        }
            //        if (Rowcount > 0 && ds.Tables[0].Rows.Count >= Rowcount)
            //        {
            //            //定义上一次点击过的行还原
            //            this.ucC1FlexGrid1.fg.Rows[Rowcount].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
            //        }
            //    }
            //}

        }

        public void fgDouble_Click(object sender, EventArgs e)
        {
            string id = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "id"].ToString();
                if (id != null && id != "")
                {
                    string sql = "select * from t_in_patient t where t.id='" + id + "'";
                    DataSet ds1 = App.GetDataSet(sql);
                    if (ds1 != null)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            InPatientInfo patientInfo = new InPatientInfo();

                            patientInfo.Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"]);
                            patientInfo.Patient_Name = ds1.Tables[0].Rows[0]["Patient_Name"].ToString();
                            //if (ds1.Tables[0].Rows[0]["Gender_Code"].ToString().Equals("男"))
                            //{
                            patientInfo.Gender_Code = ds1.Tables[0].Rows[0]["Gender_Code"].ToString();
                            //}
                            //else
                            //{
                            //    patientInfo.Gender_Code = "1";
                            //}
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
                            //inpatient.Action_State = row["action_state"].ToString();
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


                            ucDoctorOperater fq = new ucDoctorOperater(patientInfo); //new ucDoctorOperater(patientInfo, false, patientInfo.Id);
                            App.UsControlStyle(fq);
                            App.AddNewBusUcControl(fq, "病人文书");
                        }
                    }
                }
        }


        private void AddUcLight(TabControlPanel gbx, UserControl uc)
        {
            Point pt = new Point(2, 1);
            if (gbx.Controls.Count > 0)
            {
                Control ctl = gbx.Controls[gbx.Controls.Count - 1];
                int x = ctl.Location.X + ctl.Width;
                int y = ctl.Location.Y;
                if (x + ctl.Width + uc.Width + 5 > gbx.Width)
                {
                    x = 2;
                    y += ctl.Height + 5;
                }
                else
                {
                    x = x + 10;
                }
                pt.X = x;
                pt.Y = y;
            }
            gbx.Controls.Add(uc);
            uc.Location = pt;
        }
        /// <summary>
        /// 初始化医生数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="flag">是否是红黄灯交错，还是单个红，黄灯</param>
        private void InitLigth(string sql, bool flag)
        {
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int yellow =Convert.ToInt32( row["黄灯"].ToString());
                    int red = Convert.ToInt32(row["红灯"].ToString());
                    string doctor_name = row["sick_doctor_name"].ToString();
                    string doctor_id = row["sick_doctor_id"].ToString();
                    if (flag)
                    {
                        UcMerger uc = new UcMerger(doctor_name, yellow, imgYel, red, imgRed, "", true);
                        AddUcLight(tabControlPanel2, uc);
                    }
                    else
                    {
                        int num = 0;
                        if (yellow == 0)
                        {
                            num = red;
                        }
                        else
                        {
                            num = yellow;
                        }
                        UcLight uc = new UcLight(doctor_name, num, imgYel, "", true);
                        AddUcLight(tabControlPanel2, uc);
                    }
                }
            }
        }
        /// <summary>
        /// 补录医生信息加载
        /// </summary>
        /// <param name="sql"></param>
        private void InitLigth(string sql)
        {
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int bl = Convert.ToInt32(row["补录"].ToString());
                    string doctor_name = row["sick_doctor_name"].ToString();
                    string doctor_id = row["sick_doctor_id"].ToString();
                    UcLight uc = new UcLight(doctor_name, bl, imgbl, "", true);
                    AddUcLight(tabControlPanel2, uc);
                }
            }
        }

        public void uc_DoubleClick(string doc_name)
        {
            strsqls.Remove(0, strsqls.Length);
            strsqls.Append(tempSQL);
            strsqls.Append(" and sick_doctor_name='" + doc_name + "'");
            ucC1FlexGrid1.DataBd(strsqls.ToString(), "pid", "pid,section_name,sick_bed_no,patient_name,sick_doctor_name,name,note,pv", 
                                "住院号,科室,床号,姓名,管床医生,职称,提示内容,提醒");
            tabControl1.SelectedTabIndex = 0;
            ucC1FlexGrid1.fg.Cols["note"].Width = 441;
            ucC1FlexGrid1.fg.Cols["id"].Visible = false;
            for (int i = 1; i < ucC1FlexGrid1.fg.Rows.Count; i++)
            {
                CellRange r = ucC1FlexGrid1.fg.GetCellRange(i, ucC1FlexGrid1.fg.Cols["pv"].Index);
                if (ucC1FlexGrid1.fg.GetData(i, "pv").ToString() == "1")
                {
                    r.Image = imageList1.Images[0];
                    r.Clip = string.Empty;
                }
                else if (ucC1FlexGrid1.fg.GetData(i, "pv").ToString() == "0")
                {
                    r.Image = imageList1.Images[1];
                    r.Clip = string.Empty;
                }
            }
        }

        private void tabControlPanel2_SizeChanged(object sender, EventArgs e)
        {
            Point pt = new Point(2, 1);
            int x = 2;
            int y = 1;
            bool isFirst = false;
            foreach (Control item in tabControlPanel2.Controls)
            {
                if (!isFirst)
                {
                    isFirst = true;
                }
                else
                {
                    if (x + item.Width + item.Width + 5 > tabControlPanel2.Width)
                    {
                        x = 2;
                        y += item.Height + 5;
                    }
                    else
                    {
                        x = x + item.Width + 10;

                    }
                }
                pt.X = x;
                pt.Y = y;
                item.Location = pt;
            }
        }
    }
}