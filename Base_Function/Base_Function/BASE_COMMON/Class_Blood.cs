using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using Bifrost;
using Microsoft.Reporting.WinForms;
using System.ComponentModel;
using System.Drawing;
using Bifrost.WebReference;
using Base_Function.MODEL;

namespace Base_Function.BASE_COMMON
{
    public class Class_Blood
    {

        public static DataSet getBlood_resful(string pid,string date)
        {
            ArrayList lists = new ArrayList();
            lists.Clear();
            //string pids = Class_Blood.GetSelectItemId(pid);
            string Sugar_sql = "select pat.sick_bed_no as 床号,pat.patient_name as 病人姓名,ITEM_VALUE as 血糖值," +
                           " to_char(tpg.record_time,'yyyy-mm-dd') as 日期,to_char(tpg.record_time,'HH24:mi') as 时间," +
                            "pat.id as 住院号,pat.section_name as 科别,pat.sick_area_name as 病区,pat.in_time as 入院时间 " +
                            " from T_PERIPHERY_BG_RECORD tpg left join T_IN_PATIENT pat on tpg.patient_id=pat.id " +
                           " where pat.sick_bed_no is not null and tpg.record_time is not null and pat.id='" + pid + "' and to_char(tpg.record_time,'yyyy-mm-dd')='" + date + "'";
            
            DataSet ds = App.GetDataSet(Sugar_sql);
            return ds;
            
        }
        //public static DataSet GetDate(string pid)
        //{
        //    //string pids = Class_Blood.GetSelectItemId(pid);
        //    string sql = "select  to_char(tpg.record_time,'yyyy-mm-dd') as 日期,to_char(tpg.record_time,'HH24:mi') as 时间,tpg.ITEM_VALUE as 血糖值,tpg.record_name as 执行者签名,pat.id from T_PERIPHERY_BG_RECORD tpg left join " +
        //         @" T_IN_PATIENT pat on tpg.patient_id=pat.id  where pat.sick_bed_no is not null and tpg.record_time is not null  and  pat.id='" + pid + "' order by  日期,时间";//tpg.bz as 备注,
        //    //string SQL_T_PASC = "select * from t_pasc t where t.patient_id=" + pid + "";
        //    //Class_Table[] tabs = new Class_Table[2];
        //    //tabs[0] = new Class_Table();
        //    //tabs[0].Sql = sql;
        //    //tabs[0].Tablename = "SQL";

        //    //tabs[1] = new Class_Table();
        //    //tabs[1].Sql = SQL_T_PASC;
        //    //tabs[1].Tablename = "T_PASC";
        //    DataSet ds1 = App.GetDataSet(sql);//tabs
        //    return ds1;
        //}
        #region 注释掉的
        //public static DataSet GETDaes(string PID)
        //{
        //    ArrayList lists = new ArrayList();
        //    lists.Clear();
        //    DataSet dsBlood = Class_Blood.GetDate(PID);
        //    DataSet dsReturn = new DataSet();
        //    if (dsBlood != null)
        //    {
        //        if (dsBlood.Tables[0].Rows.Count > 0)
        //        {
        //            for (int i = 0; i < dsBlood.Tables[0].Rows.Count; i++)
        //            {
        //                Class_ucBlood_SugarRecord temp = new Class_ucBlood_SugarRecord();
        //                temp.Date = dsBlood.Tables[0].Rows[i]["日期"].ToString();
        //                temp.Time = dsBlood.Tables[0].Rows[i]["时间"].ToString();
        //                temp.Value_val = dsBlood.Tables[0].Rows[i]["血糖值"].ToString();
        //                temp.Create_Name = dsBlood.Tables[0].Rows[i]["执行者签名"].ToString();
        //                //temp.BZ = dsBlood.Tables[0].Rows[i]["备注"].ToString();
        //                //string date = dsBlood.Tables[0].Rows[i]["日期"].ToString();
        //                //DataRow[] rows = dst.Tables[0].Select("日期='" + date + "'");
        //                //DataSet dst = Class_Blood.getBlood_resful(PID, date);
        //                //if (dst.Tables[0].Rows.Count > 0)
        //                //{
                        
        //                //temp.Bed = dsBlood.Tables[0].Rows[0]["床号"].ToString();
        //                //temp.Pid_name = dsBlood.Tables[0].Rows[0]["病人姓名"].ToString();

        //                //for (int k = 0; k < dst.Tables[0].Rows.Count; k++)
        //                //{
        //                //temp.Bed = dst.Tables[0].Rows[k]["床号"].ToString();
        //                //temp.Pid_name = dst.Tables[0].Rows[k]["病人姓名"].ToString();

        //                if (dsBlood.Tables[0].Rows[k]["时间"].ToString() == "07:00")
        //                {
        //                    temp.Values_7 = dsBlood.Tables[0].Rows[k]["血糖值"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["时间"].ToString() == "09:30")
        //                {
        //                    temp.Values_9 = dsBlood.Tables[0].Rows[k]["血糖值"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["时间"].ToString() == "11:00")
        //                {
        //                    temp.Values_11 = dsBlood.Tables[0].Rows[k]["血糖值"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["时间"].ToString() == "14:00")
        //                {
        //                    temp.Values_14 = dsBlood.Tables[0].Rows[k]["血糖值"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["时间"].ToString() == "17:00")
        //                {
        //                    temp.Values_17 = dsBlood.Tables[0].Rows[k]["血糖值"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["时间"].ToString() == "20:00")
        //                {
        //                    temp.Values_20 = dsBlood.Tables[0].Rows[k]["血糖值"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["时间"].ToString() == "22:00")
        //                {
        //                    temp.Values_22 = dsBlood.Tables[0].Rows[k]["血糖值"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["时间"].ToString() == "00:00")
        //                {
        //                    temp.Values_00 = dsBlood.Tables[0].Rows[k]["血糖值"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["时间"].ToString() == "03:00")
        //                {
        //                    temp.Values_03 = dsBlood.Tables[0].Rows[k]["血糖值"].ToString();
        //                }
        //                //if (dst.Tables[0].Rows[k]["日期"].ToString() != "")
        //                //{
        //                //    temp.Date = dst.Tables[0].Rows[k]["日期"].ToString();
        //                //}
        //                //}
        //                lists.Add(temp);
        //                //}
        //            }
        //        }
        //    }
        //    Class_ucBlood_SugarRecord[] Bgrecode_objs = new Class_ucBlood_SugarRecord[lists.Count];
        //    for (int i = 0; i < lists.Count; i++)
        //    {
        //        Bgrecode_objs[i] = new Class_ucBlood_SugarRecord();
        //        Bgrecode_objs[i] = (Class_ucBlood_SugarRecord)lists[i];
        //    }
        //    dsReturn = App.ObjectArrayToDataSet(Bgrecode_objs);
        //    return App.ObjectArrayToDataSet(Bgrecode_objs);
        //}
        #endregion
        public static DataSet GetDate(string pid)
        {
            //string pids = Class_Blood.GetSelectItemId(pid);
            string sql = "select distinct to_char(tpg.record_time,'yyyy-mm-dd') as 日期,pat.id from T_PERIPHERY_BG_RECORD tpg left join " +
                 @" T_IN_PATIENT pat on tpg.patient_id=pat.id  where pat.sick_bed_no is not null and tpg.record_time is not null  and  pat.id='" + pid + "' order by  日期";
            DataSet ds1 = App.GetDataSet(sql);
            return ds1;
        }
        public static DataSet GETDaes(string PID)
        {
            ArrayList lists = new ArrayList();
            lists.Clear();
            DataSet dsBlood = Class_Blood.GetDate(PID);
            if (dsBlood != null)
            {
                if (dsBlood.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsBlood.Tables[0].Rows.Count; i++)
                    {

                        string date = dsBlood.Tables[0].Rows[i]["日期"].ToString();
                        //DataRow[] rows = dst.Tables[0].Select("日期='" + date + "'");
                        DataSet dst = Class_Blood.getBlood_resful(PID, date);
                        if (dst.Tables[0].Rows.Count > 0)
                        {
                            Class_ucBlood_SugarRecord temp = new Class_ucBlood_SugarRecord();
                            temp.Bed = dst.Tables[0].Rows[0]["床号"].ToString();
                            temp.Pid_name = dst.Tables[0].Rows[0]["病人姓名"].ToString();
                            for (int k = 0; k < dst.Tables[0].Rows.Count; k++)
                            {
                                temp.Bed = dst.Tables[0].Rows[k]["床号"].ToString();
                                temp.Pid_name = dst.Tables[0].Rows[k]["病人姓名"].ToString();
                                if (dst.Tables[0].Rows[k]["时间"].ToString() == "07:00")
                                {
                                    temp.Values_7 = dst.Tables[0].Rows[k]["血糖值"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["时间"].ToString() == "09:30")
                                {
                                    temp.Values_9 = dst.Tables[0].Rows[k]["血糖值"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["时间"].ToString() == "11:00")
                                {
                                    temp.Values_11 = dst.Tables[0].Rows[k]["血糖值"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["时间"].ToString() == "14:00")
                                {
                                    temp.Values_14 = dst.Tables[0].Rows[k]["血糖值"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["时间"].ToString() == "17:00")
                                {
                                    temp.Values_17 = dst.Tables[0].Rows[k]["血糖值"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["时间"].ToString() == "20:00")
                                {
                                    temp.Values_20 = dst.Tables[0].Rows[k]["血糖值"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["时间"].ToString() == "22:00")
                                {
                                    temp.Values_22 = dst.Tables[0].Rows[k]["血糖值"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["时间"].ToString() == "00:00")
                                {
                                    temp.Values_00 = dst.Tables[0].Rows[k]["血糖值"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["时间"].ToString() == "03:00")
                                {
                                    temp.Values_03 = dst.Tables[0].Rows[k]["血糖值"].ToString();
                                }
                                if (dst.Tables[0].Rows[k]["日期"].ToString() != "")
                                {
                                    temp.Date = dst.Tables[0].Rows[k]["日期"].ToString();
                                }

                            }
                            lists.Add(temp);
                        }
                    }

                }
            }
            Class_ucBlood_SugarRecord[] Bgrecode_objs = new Class_ucBlood_SugarRecord[lists.Count];
            for (int i = 0; i < lists.Count; i++)
            {
                Bgrecode_objs[i] = new Class_ucBlood_SugarRecord();
                Bgrecode_objs[i] = (Class_ucBlood_SugarRecord)lists[i];
            }
            return App.ObjectArrayToDataSet(Bgrecode_objs);
        }
        /// <summary>
        /// 根据病人id得到住院号
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static string GetSelectItemId(string pid)
        {
            string Sql = "select ID from T_IN_PATIENT  where PID ='" + pid + "'";
            string ID = App.ReadSqlVal(Sql, 0, "ID");
            return ID;
        }
   /// <summary>
   /// 
   /// </summary>
   /// <param name="dsitems"> </param>
   /// <param name="dspatients"></param>
   /// <param name="bed">床号</param>
   /// <param name="pname">病人名字</param>
   /// <param name="pid">住院号</param>
   /// <param name="section_name">科室</param>
   /// <param name="sickarea_name">病区</param>
   /// <param name="reportviewer"></param>
        public static void GetBloods(DataSet dsitems, DataSet dspatients, string bed, string pname, string pid, string section_name, string sickarea_name, ReportViewer reportviewer)
        {
            DataSet dsItems = new DataSet();
            DataSet dsPatients = new DataSet();
            dsItems = dsitems;
            //床号
            string Bed_no = "";
             Bed_no = bed;
            //病人名字
             string Pname="";
             Pname = pname;
            //住院号
             string Pid="";
             Pid = pid;
            //科室
             string Section_name = "";
            Section_name = section_name;
            //病区
            string Sickarea_name="";
            Sickarea_name = sickarea_name;
            if (dsItems != null)
            {
                if (dsItems.Tables[0].Rows.Count < 1)
                {
                    App.Msg("没有可以打印的信息！");
                    return;
                }
                else
                {
                    reportviewer.LocalReport.DataSources.Clear();
                    reportviewer.RefreshReport();
                    reportviewer.LocalReport.ReportPath = App.SysPath + "\\Report_Bgrecord.rdlc";
                    string path = "file:///" + App.SysPath + @"\2.jpg";//图片地址

                    reportviewer.LocalReport.EnableExternalImages = true;
                    ReportParameter[] pams = new ReportParameter[6];
                    pams[0] = new ReportParameter("Bed", Bed_no);
                    pams[1] = new ReportParameter("Name", Pname);
                    pams[2] = new ReportParameter("Hospital", Pid);
                    pams[3] = new ReportParameter("setion_name", Section_name);
                    pams[4] = new ReportParameter("sickarea_name", Sickarea_name);
                    pams[5] = new ReportParameter("image1", path);
                    reportviewer.LocalReport.SetParameters(pams);

                  
                    reportviewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Bgrecord_DateBgrecord", dsItems.Tables[0]));
                    
                    reportviewer.SetDisplayMode(DisplayMode.PrintLayout);
                    reportviewer.ZoomMode = ZoomMode.Percent;
                    reportviewer.ZoomPercent = 100;
                }
            }
        }
    }
}
