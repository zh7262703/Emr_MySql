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
            string Sugar_sql = "select pat.sick_bed_no as ����,pat.patient_name as ��������,ITEM_VALUE as Ѫ��ֵ," +
                           " to_char(tpg.record_time,'yyyy-mm-dd') as ����,to_char(tpg.record_time,'HH24:mi') as ʱ��," +
                            "pat.id as סԺ��,pat.section_name as �Ʊ�,pat.sick_area_name as ����,pat.in_time as ��Ժʱ�� " +
                            " from T_PERIPHERY_BG_RECORD tpg left join T_IN_PATIENT pat on tpg.patient_id=pat.id " +
                           " where pat.sick_bed_no is not null and tpg.record_time is not null and pat.id='" + pid + "' and to_char(tpg.record_time,'yyyy-mm-dd')='" + date + "'";
            
            DataSet ds = App.GetDataSet(Sugar_sql);
            return ds;
            
        }
        //public static DataSet GetDate(string pid)
        //{
        //    //string pids = Class_Blood.GetSelectItemId(pid);
        //    string sql = "select  to_char(tpg.record_time,'yyyy-mm-dd') as ����,to_char(tpg.record_time,'HH24:mi') as ʱ��,tpg.ITEM_VALUE as Ѫ��ֵ,tpg.record_name as ִ����ǩ��,pat.id from T_PERIPHERY_BG_RECORD tpg left join " +
        //         @" T_IN_PATIENT pat on tpg.patient_id=pat.id  where pat.sick_bed_no is not null and tpg.record_time is not null  and  pat.id='" + pid + "' order by  ����,ʱ��";//tpg.bz as ��ע,
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
        #region ע�͵���
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
        //                temp.Date = dsBlood.Tables[0].Rows[i]["����"].ToString();
        //                temp.Time = dsBlood.Tables[0].Rows[i]["ʱ��"].ToString();
        //                temp.Value_val = dsBlood.Tables[0].Rows[i]["Ѫ��ֵ"].ToString();
        //                temp.Create_Name = dsBlood.Tables[0].Rows[i]["ִ����ǩ��"].ToString();
        //                //temp.BZ = dsBlood.Tables[0].Rows[i]["��ע"].ToString();
        //                //string date = dsBlood.Tables[0].Rows[i]["����"].ToString();
        //                //DataRow[] rows = dst.Tables[0].Select("����='" + date + "'");
        //                //DataSet dst = Class_Blood.getBlood_resful(PID, date);
        //                //if (dst.Tables[0].Rows.Count > 0)
        //                //{
                        
        //                //temp.Bed = dsBlood.Tables[0].Rows[0]["����"].ToString();
        //                //temp.Pid_name = dsBlood.Tables[0].Rows[0]["��������"].ToString();

        //                //for (int k = 0; k < dst.Tables[0].Rows.Count; k++)
        //                //{
        //                //temp.Bed = dst.Tables[0].Rows[k]["����"].ToString();
        //                //temp.Pid_name = dst.Tables[0].Rows[k]["��������"].ToString();

        //                if (dsBlood.Tables[0].Rows[k]["ʱ��"].ToString() == "07:00")
        //                {
        //                    temp.Values_7 = dsBlood.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["ʱ��"].ToString() == "09:30")
        //                {
        //                    temp.Values_9 = dsBlood.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["ʱ��"].ToString() == "11:00")
        //                {
        //                    temp.Values_11 = dsBlood.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["ʱ��"].ToString() == "14:00")
        //                {
        //                    temp.Values_14 = dsBlood.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["ʱ��"].ToString() == "17:00")
        //                {
        //                    temp.Values_17 = dsBlood.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["ʱ��"].ToString() == "20:00")
        //                {
        //                    temp.Values_20 = dsBlood.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["ʱ��"].ToString() == "22:00")
        //                {
        //                    temp.Values_22 = dsBlood.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["ʱ��"].ToString() == "00:00")
        //                {
        //                    temp.Values_00 = dsBlood.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
        //                }
        //                else if (dsBlood.Tables[0].Rows[k]["ʱ��"].ToString() == "03:00")
        //                {
        //                    temp.Values_03 = dsBlood.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
        //                }
        //                //if (dst.Tables[0].Rows[k]["����"].ToString() != "")
        //                //{
        //                //    temp.Date = dst.Tables[0].Rows[k]["����"].ToString();
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
            string sql = "select distinct to_char(tpg.record_time,'yyyy-mm-dd') as ����,pat.id from T_PERIPHERY_BG_RECORD tpg left join " +
                 @" T_IN_PATIENT pat on tpg.patient_id=pat.id  where pat.sick_bed_no is not null and tpg.record_time is not null  and  pat.id='" + pid + "' order by  ����";
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

                        string date = dsBlood.Tables[0].Rows[i]["����"].ToString();
                        //DataRow[] rows = dst.Tables[0].Select("����='" + date + "'");
                        DataSet dst = Class_Blood.getBlood_resful(PID, date);
                        if (dst.Tables[0].Rows.Count > 0)
                        {
                            Class_ucBlood_SugarRecord temp = new Class_ucBlood_SugarRecord();
                            temp.Bed = dst.Tables[0].Rows[0]["����"].ToString();
                            temp.Pid_name = dst.Tables[0].Rows[0]["��������"].ToString();
                            for (int k = 0; k < dst.Tables[0].Rows.Count; k++)
                            {
                                temp.Bed = dst.Tables[0].Rows[k]["����"].ToString();
                                temp.Pid_name = dst.Tables[0].Rows[k]["��������"].ToString();
                                if (dst.Tables[0].Rows[k]["ʱ��"].ToString() == "07:00")
                                {
                                    temp.Values_7 = dst.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["ʱ��"].ToString() == "09:30")
                                {
                                    temp.Values_9 = dst.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["ʱ��"].ToString() == "11:00")
                                {
                                    temp.Values_11 = dst.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["ʱ��"].ToString() == "14:00")
                                {
                                    temp.Values_14 = dst.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["ʱ��"].ToString() == "17:00")
                                {
                                    temp.Values_17 = dst.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["ʱ��"].ToString() == "20:00")
                                {
                                    temp.Values_20 = dst.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["ʱ��"].ToString() == "22:00")
                                {
                                    temp.Values_22 = dst.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["ʱ��"].ToString() == "00:00")
                                {
                                    temp.Values_00 = dst.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
                                }
                                else if (dst.Tables[0].Rows[k]["ʱ��"].ToString() == "03:00")
                                {
                                    temp.Values_03 = dst.Tables[0].Rows[k]["Ѫ��ֵ"].ToString();
                                }
                                if (dst.Tables[0].Rows[k]["����"].ToString() != "")
                                {
                                    temp.Date = dst.Tables[0].Rows[k]["����"].ToString();
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
        /// ���ݲ���id�õ�סԺ��
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
   /// <param name="bed">����</param>
   /// <param name="pname">��������</param>
   /// <param name="pid">סԺ��</param>
   /// <param name="section_name">����</param>
   /// <param name="sickarea_name">����</param>
   /// <param name="reportviewer"></param>
        public static void GetBloods(DataSet dsitems, DataSet dspatients, string bed, string pname, string pid, string section_name, string sickarea_name, ReportViewer reportviewer)
        {
            DataSet dsItems = new DataSet();
            DataSet dsPatients = new DataSet();
            dsItems = dsitems;
            //����
            string Bed_no = "";
             Bed_no = bed;
            //��������
             string Pname="";
             Pname = pname;
            //סԺ��
             string Pid="";
             Pid = pid;
            //����
             string Section_name = "";
            Section_name = section_name;
            //����
            string Sickarea_name="";
            Sickarea_name = sickarea_name;
            if (dsItems != null)
            {
                if (dsItems.Tables[0].Rows.Count < 1)
                {
                    App.Msg("û�п��Դ�ӡ����Ϣ��");
                    return;
                }
                else
                {
                    reportviewer.LocalReport.DataSources.Clear();
                    reportviewer.RefreshReport();
                    reportviewer.LocalReport.ReportPath = App.SysPath + "\\Report_Bgrecord.rdlc";
                    string path = "file:///" + App.SysPath + @"\2.jpg";//ͼƬ��ַ

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
