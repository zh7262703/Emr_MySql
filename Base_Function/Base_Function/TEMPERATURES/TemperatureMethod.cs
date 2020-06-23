using System;
using System.Collections.Generic;
using System.Text;
using Bifrost;
using System.Data;

namespace Base_Function.TEMPERATURES
{
    public class TemperatureMethod
    {
        

        public static string GetTransferBed(string PatientID,string PageIndex,string bedno)
        {
            //string bed = string.Empty;
            string weekfirstbed = string.Empty;
            string inbed = App.ReadSqlVal("select a.in_bed_no bed from t_in_patient a where a.id=" +PatientID, 0, "bed");
            return GetBedNo(PatientID, PageIndex, bedno);
        }

        public static string GetBedNo(string PatientID,string PageIndex,string bedno)
        {
            string sql = " select a.id,a.pageindex,a.bedno,a.diagnose,a.patient_id from t_temperature_pageinfo a where a.patient_id='" + PatientID + "' and a.pageindex='" + PageIndex + "'";
            string bed = string.Empty;
            DataTable pageheadtable = App.GetDataSet(sql).Tables[0];
            if (pageheadtable.Rows.Count > 0)
            {
                bed = pageheadtable.Rows[0]["bedno"].ToString();
            }
            else
            {
                bed =bedno;
            }
            return bed;
        }

        public static string GetDiagnose(string PatientID,string PageIndex)
        {
            string diagnose = string.Empty;
            string sql = " select a.id,a.pageindex,a.diagnose,diagnose_count,a.patient_id from t_temperature_pageinfo a where a.patient_id='" + PatientID + "' and a.pageindex='" + PageIndex + "'";
            DataTable pageheadtable = App.GetDataSet(sql).Tables[0];
            if (pageheadtable.Rows.Count > 0)
            {
                if (pageheadtable.Rows[0]["diagnose_count"].ToString().Length > 0)
                {
                    diagnose = pageheadtable.Rows[0]["diagnose"].ToString();
                }
                else
                {
                    diagnose = GetDiagnose(PatientID);
                }
            }
            else
            {
                diagnose = GetDiagnose(PatientID);
            }
            return diagnose;
        }

        public static string GetSection(string PatientID, string PageIndex)
        {
            string section_name = App.ReadSqlVal("select section_name from t_temperature_pageinfo a where a.patient_id='" + PatientID + "' and a.pageindex='" + PageIndex + "'", 0, "section_name");
            if (string.IsNullOrEmpty(section_name))
            {
                section_name = App.ReadSqlVal("select section_name from t_in_patient a where a.id='" + PatientID + "'", 0, "section_name");
            }
            return section_name;
        }


        public static string GetDiagnose(string PatientID)
        {
            string diagnose = "";
            string sql_diagnose = "select a.diagnose_name from t_diagnose_item a where a.patient_id=" + PatientID + " order by a.diagnose_sort asc ";
            sql_diagnose = "select distinct a.diagnose_name,a.diagnose_sort from t_diagnose_item a where a.patient_id = " + PatientID + " and a.diagnose_type = '403' order by a.diagnose_sort";
            DataTable dtdiagnose = App.GetDataSet(sql_diagnose).Tables[0];
            if (dtdiagnose != null)
            {
                for (int i = 0; i < dtdiagnose.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        diagnose = Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                    }
                    else if (i >= 3)
                    {
                        break;
                    }
                    else
                    {
                        diagnose += "," + Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                    }
                }
            }
            return diagnose;
        }

        public static DataTable GetPatientAllSections(string PatientID)
        {
            string sql = "select distinct c.sid section_id,c.section_name from(";
            sql += " select distinct a.sid from t_inhospital_action a where (a.action_type='转入' or a.action_type='转出' or a.action_type='入区' ";
            sql += " or a.action_type='出区')  and a.patient_id='" + PatientID + "'";
            sql += " union all ";
            sql += " select distinct a.sid from t_inhospital_action_history a where (a.action_type='转入' or a.action_type='转出' or a.action_type='入区' ";
            sql += " or a.action_type='出区')  and a.patient_id='" + PatientID + "') b ";
            sql += " inner join t_sectioninfo c on b.sid=c.sid";
            DataTable table = null;
            table = App.GetDataSet(sql).Tables[0];
            return table;
        }


        
        //显示患者初步诊断+确定诊断，默认读取根据第一条确定诊断信息显示，但可修改。显示格式：初步诊断→确定诊断。
        public static string GetDiagnose(string PatientID, string PageIndex, DateTime startTime, DateTime endTime)
        {
            string diagnose = "";

            string sql = " select a.id,a.pageindex,a.diagnose,diagnose_count,a.patient_id from t_temperature_pageinfo a where a.patient_id='" + PatientID + "' and a.pageindex='" + PageIndex + "'";
            DataTable pageheadtable = App.GetDataSet(sql).Tables[0];
            if (pageheadtable.Rows.Count > 0)
            {
                if (pageheadtable.Rows[0]["DIAGNOSE"].ToString().Length > 0)
                {
                    diagnose = pageheadtable.Rows[0]["DIAGNOSE"].ToString();
                    return diagnose;
                }
            }

            string sql1 = @"select t.fix_time,t.diagnose_name,diagnose_sort  from t_diagnose_item t where t.patient_id='" + PatientID + "' and t.diagnose_type=403 and to_char(t.fix_time,'yyyy-MM-dd')<='" + endTime.ToString("yyyy-MM-dd") + "' order by t.diagnose_sort";
            //初步诊断1
            string cbzd = App.ReadSqlVal(sql1, 0, "diagnose_name");

            string sql2 = @"select t.fix_time,t.diagnose_name,diagnose_sort  from t_diagnose_item t where t.patient_id='" + PatientID + "' and t.diagnose_type=7923 and to_char(t.fix_time,'yyyy-MM-dd') between  '" + startTime.ToString("yyyy-MM-dd") + "' and  '" + endTime.ToString("yyyy-MM-dd") + "' order by t.diagnose_sort";
            //确定诊断2
            string qdzd = App.ReadSqlVal(sql2, 0, "diagnose_name");

            if (!string.IsNullOrEmpty(cbzd))
            {
                diagnose = cbzd;
                if (!string.IsNullOrEmpty(qdzd))
                    diagnose += "→" + qdzd;
            }
            else if (!string.IsNullOrEmpty(qdzd))
            {
                diagnose = qdzd;
            }
            return diagnose;
        }

        //转科记录
        public static string GetSection(string PatientID, string PageIndex, DateTime startTime, DateTime endTime)
        {
            string section = "";
            //string sql = " select a.id,a.pageindex,a.SECTION_NAME,a.patient_id from t_temperature_pageinfo a where a.patient_id='" + PatientID + "' and a.pageindex='" + PageIndex + "'";
            //DataTable pageheadtable = App.GetDataSet(sql).Tables[0];
            //if (pageheadtable.Rows.Count > 0)
            //{
            //    if (pageheadtable.Rows[0]["SECTION_NAME"].ToString().Length > 0)
            //    {
            //        section = pageheadtable.Rows[0]["SECTION_NAME"].ToString();
            //        return section;
            //    }
            //}

            DataTable dt = App.GetDataSet("select a.happen_time,b.section_name from T_Inhospital_Action a inner join t_sectioninfo b on a.sid=b.sid where a.patient_id='" + PatientID + "' and to_char(a.happen_time,'yyyy-MM-dd') between '" + startTime.ToString("yyyy-MM-dd") + "' and  '" + endTime.ToString("yyyy-MM-dd") + "' and a.action_type='转入' order by a.happen_time desc").Tables[0];

            
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (j > 0)
                        section += "→";
                    section += dt.Rows[j]["section_name"].ToString();
                }
            }
            else
            {
                string section_name = App.ReadSqlVal("select section_name from t_in_patient where id='" + PatientID + "'", 0, "section_name");
                section = section_name;
            }
            return section;
        }

        //获取换床记录
        public static string GetBedNo(string PatientID, string PageIndex, DateTime startTime, DateTime endTime)
        {
            string bed_no = "";

            string sql = " select a.id,a.pageindex,a.BEDNO,a.patient_id from t_temperature_pageinfo a where a.patient_id='" + PatientID + "' and a.pageindex='" + PageIndex + "'";
            DataTable pageheadtable = App.GetDataSet(sql).Tables[0];
            if (pageheadtable.Rows.Count > 0)
            {
                if (pageheadtable.Rows[0]["BEDNO"].ToString().Length > 0)
                {
                    bed_no = pageheadtable.Rows[0]["BEDNO"].ToString();
                    return bed_no;
                }
            }
            sql = "select b.bed_no from t_inhospital_action a inner join T_SickBedInfo b on a.bed_id=b.bed_id where  a.patient_id='" + PatientID + "' and to_char(a.happen_time,'yyyy-MM-dd') between '" + startTime.ToString("yyyy-MM-dd") + "' and  '" + endTime.ToString("yyyy-MM-dd") + "' and (a.action_type='转入' or a.action_type='换床') order by a.happen_time asc";
            DataTable dt2 = App.GetDataSet(sql).Tables[0];
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                for (int j = 0; j < dt2.Rows.Count; j++)
                {
                    if (j > 0)
                        bed_no += "→";
                    bed_no += dt2.Rows[j]["bed_no"].ToString();
                }
            }
            else
            {
                string rych = App.ReadSqlVal("select sick_bed_no from t_in_patient where id='" + PatientID + "'", 0, "sick_bed_no");
                bed_no = rych;
            }
            return bed_no;
        }

    }
}
