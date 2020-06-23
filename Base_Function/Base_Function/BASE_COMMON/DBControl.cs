using System;
using System.Collections.Generic;
using System.Text;
using Bifrost;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Base_Function.MODEL;
namespace Base_Function.BASE_COMMON
{
    public class DBControl
    {

        /// <summary>
        /// 插入综合体温特征
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool InsertTempers(List<Class_T_Vital_Signs> list, Class_T_Temperature_Info tti)
        {
            List<string> listSql = new List<string>();
            List<string> list_job_temp = new List<string>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    string sql = "";
                    string sql_operation = "";
                    string sql_operations = "";
                    if (list[i].Describe != null)
                    {
                        if (list[i].Describe.ToString().Contains("手术"))
                        {
                            sql = string.Format("insert into t_vital_signs ( " +
                                        "bed_no," +
                                        "pid," +
                                        "measure_time," +
                                        "temperature_value," +
                                        "temperature_body," +
                                        "re_measure," +
                                        "cooling_value," +
                                        "cooling_type," +
                                        "pulse_value," +
                                        "is_briefness," +
                                        "is_assist_hr," +
                                        "breath_value," +
                                        "is_assist_br," +
                                        "measure_state," +
                                        "describe," +
                                        "remark," +
                                        "heart_rhythm," +
                                        "OPERATIONS_TIME," +
                                        "PATIENT_ID" +
                                        ")values(" +
                                        "'{0}'," +
                                        "'{1}'," +
                                        "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                        "'{3}'," +
                                        "'{4}'," +
                                        "'{5}'," +
                                        "'{6}'," +
                                        "'{7}'," +
                                        "'{8}'," +
                                        "'{9}'," +
                                        "'{10}'," +
                                        "'{11}'," +
                                        "'{12}'," +
                                        "'{13}'," +
                                        "'{14}'," +
                                        "'{15}'," +
                                        "'{16}'," +
                                        "to_TIMESTAMP('{17}','yyyy-MM-dd hh24:mi')," +
                                        "'{18}'" +
                                         ")",
                                        list[i].Bed_no,
                                           list[i].Pid,
                                           list[i].Measure_time,
                                           list[i].Temperature_value,
                                           list[i].Temperature_body,
                                           list[i].Re_measure,
                                           list[i].Cooling_value,
                                           list[i].Cooling_type,
                                           list[i].Pulse_value,
                                           list[i].Is_briefness,
                                           list[i].Is_assist_hr,
                                           list[i].Breath_value,
                                           list[i].Is_assist_br,
                                           list[i].Measure_state,
                                           list[i].Describe,
                                           list[i].Remark,
                                           list[i].Heart_rhythm,
                                           list[i].Operater_after_time,
                                           list[i].Patient_id
                                           );

                            if (list[i].Describe.ToString().Contains("手术"))
                            {
                                string operater_type = "术前";
                                string operater_types = "术后";
                                string operation_startTime = list[i].Operater_before_time;
                                string operation_endTime = Convert.ToDateTime(list[i].Operater_after_time).AddDays(1).Date.ToString();
                                string pids_id = list[i].Patient_id;
                                string strAge = string.Empty;
                                string Age = App.ReadSqlVal("select age from t_in_patient where id = " + pids_id, 0, "age");
                                if (App.IsNumeric(Age))
                                {
                                    strAge = Age;
                                }
                                sql_operation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age) values('" + list[i].Pid.ToString() + "','" + operater_type + "',to_timestamp('" + operation_startTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "')";
                                sql_operations = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age) values('" + list[i].Pid.ToString() + "','" + operater_types + "',to_timestamp('" + operation_endTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "')";
                            }
                        }
                        else
                        {
                            sql = string.Format("insert into t_vital_signs ( " +
                                   "bed_no," +
                                   "pid," +
                                   "measure_time," +
                                   "temperature_value," +
                                   "temperature_body," +
                                   "re_measure," +
                                   "cooling_value," +
                                   "cooling_type," +
                                   "pulse_value," +
                                   "is_briefness," +
                                   "is_assist_hr," +
                                   "breath_value," +
                                   "is_assist_br," +
                                   "measure_state," +
                                   "describe," +
                                   "remark," +
                                   "heart_rhythm," +
                                   "patient_id" +
                                   ")values(" +
                                   "'{0}'," +
                                   "'{1}'," +
                                   "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                   "'{3}'," +
                                   "'{4}'," +
                                   "'{5}'," +
                                   "'{6}'," +
                                   "'{7}'," +
                                   "'{8}'," +
                                   "'{9}'," +
                                   "'{10}'," +
                                   "'{11}'," +
                                   "'{12}'," +
                                   "'{13}'," +
                                   "'{14}'," +
                                   "'{15}'," +
                                   "'{16}'," +
                                   "'{17}'" +
                                   ")",
                                   list[i].Bed_no,
                                      list[i].Pid,
                                      list[i].Measure_time,
                                      list[i].Temperature_value,
                                      list[i].Temperature_body,
                                      list[i].Re_measure,
                                      list[i].Cooling_value,
                                      list[i].Cooling_type,
                                      list[i].Pulse_value,
                                      list[i].Is_briefness,
                                      list[i].Is_assist_hr,
                                      list[i].Breath_value,
                                      list[i].Is_assist_br,
                                      list[i].Measure_state,
                                      list[i].Describe,
                                      list[i].Remark,
                                      list[i].Heart_rhythm,
                                      list[i].Patient_id
                                      );
                        }
                    }
                    else
                    {
                        sql = string.Format("insert into t_vital_signs ( " +
                                    "bed_no," +
                                    "pid," +
                                    "measure_time," +
                                    "temperature_value," +
                                    "temperature_body," +
                                    "re_measure," +
                                    "cooling_value," +
                                    "cooling_type," +
                                    "pulse_value," +
                                    "is_briefness," +
                                    "is_assist_hr," +
                                    "breath_value," +
                                    "is_assist_br," +
                                    "measure_state," +
                                    "describe," +
                                    "remark," +
                                    "heart_rhythm," +
                                    "patient_id" +
                                    ")values(" +
                                    "'{0}'," +
                                    "'{1}'," +
                                    "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                    "'{3}'," +
                                    "'{4}'," +
                                    "'{5}'," +
                                    "'{6}'," +
                                    "'{7}'," +
                                    "'{8}'," +
                                    "'{9}'," +
                                    "'{10}'," +
                                    "'{11}'," +
                                    "'{12}'," +
                                    "'{13}'," +
                                    "'{14}'," +
                                    "'{15}'," +
                                    "'{16}'," +
                                    "'{17}'" +
                                    ")",
                                    list[i].Bed_no,
                                       list[i].Pid,
                                       list[i].Measure_time,
                                       list[i].Temperature_value,
                                       list[i].Temperature_body,
                                       list[i].Re_measure,
                                       list[i].Cooling_value,
                                       list[i].Cooling_type,
                                       list[i].Pulse_value,
                                       list[i].Is_briefness,
                                       list[i].Is_assist_hr,
                                       list[i].Breath_value,
                                       list[i].Is_assist_br,
                                       list[i].Measure_state,
                                       list[i].Describe,
                                       list[i].Remark,
                                       list[i].Heart_rhythm,
                                       list[i].Patient_id
                                       );
                    }
                    listSql.Add(sql);
                    list_job_temp.Add(sql_operation);
                    list_job_temp.Add(sql_operations);
                }
            }
            string sql2 = string.Format("insert into t_temperature_info( " +   //其他信息SQL 语句
                                              "bed_no," +
                                              "pid," +
                                              "stool_count," +
                                              "stool_state," +
                                              "clysis_count," +
                                              "stool_count_e," +
                                              "stool_amount," +
                                              "stool_amount_unit," +
                                              "stale_amount," +
                                              "is_catheter," +
                                              "weighttype," +
                                              "weight," +
                                              "weight_unit," +
                                              "weight_special," +
                                              "length," +
                                              "sensi_test_code," +
                                              "sensi_test_result," +
                                              "sensi_test_result_temp," +
                                              "record_id," +
                                              "record_time," +
                                              "in_amount," +
                                              "out_amount," +
                                              "out_amount1," +
                                              "out_amount2," +
                                              "out_amount3," +
                                              "remark," +
                                              "bp_high," +
                                              "bp_low," +
                                              "bp_unit," +
                                              "out_other," +
                                              "bp_blood," +
                                              "STOOL_COUNT_F," +
                                              "SPO2," +
                                              "Special," +
                                              "Sputum_quantity," +
                                              "Volume_of_drainage," +
                                              "Vomit," +
                                              "PATIENT_ID)" +
                                              "values(" +
                                              "'{0}'," +
                                              "'{1}'," +
                                              "'{2}'," +
                                              "'{3}'," +
                                              "'{4}'," +
                                              "'{5}'," +
                                              "'{6}'," +
                                              "'{7}'," +
                                              "'{8}'," +
                                              "'{9}'," +
                                              "'{10}'," +
                                              "'{11}'," +
                                              "'{12}'," +
                                              "'{13}'," +
                                              "'{14}'," +
                                              "'{15}'," +
                                              "'{16}'," +
                                              "'{17}'," +
                                              "'{18}'," +
                                              "to_TIMESTAMP('{19}','yyyy-MM-dd hh24:mi')," +
                                              "'{20}'," +
                                              "'{21}'," +
                                              "'{22}'," +
                                              "'{23}'," +
                                              "'{24}'," +
                                              "'{25}'," +
                                              "'{26}'," +
                                              "'{27}'," +
                                              "'{28}'," +
                                              "'{29}'," +
                                              "'{30}'," +
                                              "'{31}'," +
                                              "'{32}'," +
                                              "'{33}'," +
                                              "'{34}'," +
                                              "'{35}'," +
                                              "'{36}'," +
                                              "'{37}')", tti.Bed_no,
                                               tti.Pid,
                                               tti.Stool_count,
                                               tti.Stool_state,
                                               tti.Clysis_count,
                                               tti.Stool_count_e,
                                               tti.Stool_amount,
                                               tti.Stool_amount_unit,
                                               tti.Stale_amount,
                                               tti.Is_catheter,
                                               tti.Weighttype,
                                               tti.Weight,
                                               tti.Weight_unit,
                                               tti.Weight_special,
                                               tti.Length,
                                               tti.Sensi_test_code,
                                               tti.Sensi_test_result,
                                               tti.Sensi_test_result_temp,
                                               tti.Record_id,
                                               tti.Record_time,
                                               tti.In_amount,
                                               tti.Out_amount,
                                               tti.Out_amount1,
                                               tti.Out_amount2,
                                               tti.Out_amount3,
                                               tti.Remark,
                                               tti.Bp_high,
                                               tti.Bp_low,
                                               tti.Bp_unit,
                                               tti.Out_other,
                                               tti.Bp_blood,
                                               tti.Stool_count_f,
                                               tti.Spo2,
                                               tti.Special,
                                               tti.Sputum_quantity,
                                               tti.Volume_of_drainage,
                                               tti.Vomit,
                                               tti.Patient_id);
            listSql.Add(sql2);
            try
            {

                App.ExecuteBatch(listSql.ToArray());
                App.ExecuteBatch(list_job_temp.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            listSql.Clear();
            list_job_temp.Clear();
            return true;
        }




        /// <summary>
        /// 插入体温生命特征
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool InsertTempers(List<Class_T_Vital_Signs> list, string time, string patient_id, string pid, bool isYN, List<string> ltime)
        {
            List<string> listSql = new List<string>();
            List<string> list_job_temp = new List<string>();
            string sqlcount = string.Format("SELECT count(id) FROM t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, patient_id);
            if (Convert.ToInt32(App.GetDataSet(sqlcount).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql_del = string.Format("DELETE t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}'", time, patient_id);
                listSql.Add(sql_del);
                if (isYN)
                {

                    //在t_job_temp表里，添加了一个相应的EVENT_TYPE字段(varchar(1))。
                    //针对术前记录做event_type字段的赋值;
                    //新增赋值"+"
                    //删除赋值"-"
                    for (int t = 0; t < ltime.Count; t++)
                    {
                        if (ltime[t] != "")
                        {
                            //string sqlTime1 = App.ReadSqlVal("SELECT to_char(measure_time,'yyyy-mm-dd')||replace(describe,'手术_',' ') otime  from t_vital_signs WHERE describe like '%手术%' AND to_char(measure_time,'yyyy-MM-dd hh24:mi') like '" + ltime[t].ToString() + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            //string sql1 = string.Format("update t_job_temp t set t.event_type='-',t.state=null where t.patient_id='{0}' and t.operate_type='术前' and to_char(t.operate_time,'yyyy-mm-dd hh24:mi')='{1}'", patient_id, sqlTime1);
                            //string sqlTime2 = App.ReadSqlVal("SELECT to_char(OPERATIONS_TIME,'yyyy-mm-dd hh24:mi') otime  from t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd hh24:mi') like '" + ltime[t].ToString() + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            //string sql2 = string.Format("update t_job_temp t set t.event_type='-',t.state=null where t.patient_id='{0}' and t.operate_type='术后' and to_char(t.operate_time,'yyyy-mm-dd hh24:mi')='{1}'", patient_id, sqlTime2);

                            string operater_type = "术前";
                            string operater_types = "术后";
                            string operation_startTime = App.ReadSqlVal("SELECT to_char(measure_time,'yyyy-mm-dd')||' '||substr(describe,instr(describe, '手术_', 1)+3,5) otime  from t_vital_signs WHERE describe like '%手术%' AND to_char(measure_time,'yyyy-MM-dd hh24:mi') like '" + ltime[t].ToString() + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            string operation_endTime = App.ReadSqlVal("SELECT to_char(OPERATIONS_TIME,'yyyy-mm-dd hh24:mi') otime  from t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd hh24:mi') like '" + ltime[t].ToString() + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            string pids_id = patient_id;
                            string strAge = string.Empty;
                            string Age = App.ReadSqlVal("select age from t_in_patient where id = " + patient_id, 0, "age");
                            if (App.IsNumeric(Age))
                            {
                                strAge = Age;
                            }
                            //删除的不用判断重复
                            //sql_del_operation = "select count(*) c from t_job_temp where patient_id='" + pids_id + "' and operate_type='术前' and event_type='+' and to_char(operate_time,'yyyy-mm-dd hh24:mi')='" + operation_startTime + "'";
                            //sql_del_operations = "select count(*) c from t_job_temp where patient_id='" + pids_id + "' and operate_type='术后' and event_type='+' and to_char(operate_time,'yyyy-mm-dd hh24:mi')='" + operation_endTime + "'";
                            //新增前,判断是否有id和时间和类型和是否带+号的相同数据存在
                            //存在就不新增,不存在就新增


                            string sql1 = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE) values('" + pid + "','" + operater_type + "',to_timestamp('" + operation_startTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "','-')";

                            string sql2 = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE) values('" + pid + "','" + operater_types + "',to_timestamp('" + operation_endTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "','-')";


                            /* 删除体温单手术事件停止线程 需在体温单删除手术事件中加入如下语句
                             * t_quality_job里的BASE_TIME字段就是t_job_Temp里的operate_time字段
                             * t_quality_record里的noteztime字段和t_quality_job里的EXEC_TIME_R字段相等
                             */
                            //string sql3 = string.Format("delete t_quality_job where text_type in('手术记录','术后首次病程记录','术后记录') and patient_id='{0}' and to_char(BASE_TIME,'yyyy-mm-dd hh24:mi')='{1}'", patient_id, sqlTime2);
                            //string sqlTime3 = App.ReadSqlVal("SELECT to_char(EXEC_TIME_R,'yyyy-mm-dd hh24:mi') otime from t_quality_job where text_type in('手术记录','术后首次病程记录','术后记录') and to_char(BASE_TIME,'yyyy-MM-dd hh24:mi') like '" + sqlTime2 + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            //string sql4 = string.Format("delete t_quality_record where doctype in('手术记录','术后首次病程记录','术后记录') and patient_id='{0}' and to_char(noteztime,'yyyy-mm-dd hh24:mi')='{1}'", patient_id, sqlTime3);
                            list_job_temp.Add(sql1);
                            list_job_temp.Add(sql2);
                            //list_job_temp.Add(sql3);
                            //list_job_temp.Add(sql4);
                        }
                    }

                }
            }

            #region 体温部分
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {

                    string sql = "";
                    string sql_delops = "";
                    string sql_del_operation = "";
                    string sql_del_operations = "";
                    string sql_operation = "";
                    string sql_operations = "";
                    if (list[i].Describe != null)
                    {
                        if (list[i].Describe.ToString().Contains("手术"))
                        {
                            sql = string.Format("insert into t_vital_signs ( " +
                                        "bed_no," +
                                        "pid," +
                                        "measure_time," +
                                        "temperature_value," +
                                        "temperature_body," +
                                        "re_measure," +
                                        "cooling_value," +
                                        "cooling_type," +
                                        "pulse_value," +
                                        "is_briefness," +
                                        "is_assist_hr," +
                                        "breath_value," +
                                        "is_assist_br," +
                                        "measure_state," +
                                        "describe," +
                                        "remark," +
                                        "heart_rhythm," +
                                        "OPERATIONS_TIME," +
                                        "PATIENT_ID,PAIN_VALUE,PAIN_MOTHED" +
                                        ")values(" +
                                        "'{0}'," +
                                        "'{1}'," +
                                        "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                        "'{3}'," +
                                        "'{4}'," +
                                        "'{5}'," +
                                        "'{6}'," +
                                        "'{7}'," +
                                        "'{8}'," +
                                        "'{9}'," +
                                        "'{10}'," +
                                        "'{11}'," +
                                        "'{12}'," +
                                        "'{13}'," +
                                        "'{14}'," +
                                        "'{15}'," +
                                        "'{16}'," +
                                        "to_TIMESTAMP('{17}','yyyy-MM-dd hh24:mi')," +
                                        "'{18}','{19}','{20}'" +
                                         ")",
                                        list[i].Bed_no,
                                           list[i].Pid,
                                           list[i].Measure_time,
                                           list[i].Temperature_value,
                                           list[i].Temperature_body,
                                           list[i].Re_measure,
                                           list[i].Cooling_value,
                                           list[i].Cooling_type,
                                           list[i].Pulse_value,
                                           list[i].Is_briefness,
                                           list[i].Is_assist_hr,
                                           list[i].Breath_value,
                                           list[i].Is_assist_br,
                                           list[i].Measure_state,
                                           list[i].Describe,
                                           list[i].Remark,
                                           list[i].Heart_rhythm,
                                           list[i].Operater_after_time,
                                           list[i].Patient_id, list[i].Pain_value, list[i].Pain_mothed
                                           );

                            if (list[i].Describe.ToString().Contains("手术"))
                            {
                                string operater_type = "术前";
                                string operater_types = "术后";
                                string operation_startTime = list[i].Operater_before_time;
                                //string operation_endTime = Convert.ToDateTime(list[i].Operater_after_time).AddDays(1).Date.ToString();
                                string operation_endTime = list[i].Operater_after_time;
                                string pids_id = list[i].Patient_id;
                                string strAge = string.Empty;
                                string Age = App.ReadSqlVal("select age from t_in_patient where id = " + pids_id, 0, "age");
                                if (App.IsNumeric(Age))
                                {
                                    strAge = Age;
                                }
                                sql_del_operation = "select count(*) c from t_job_temp where patient_id='" + pids_id + "' and operate_type='术前' and event_type='+' and to_char(operate_time,'yyyy-mm-dd hh24:mi')='" + operation_startTime + "'";
                                sql_del_operations = "select count(*) c from t_job_temp where patient_id='" + pids_id + "' and operate_type='术后' and event_type='+' and to_char(operate_time,'yyyy-mm-dd hh24:mi')='" + operation_endTime + "'";
                                //新增前,判断是否有id和时间和类型和是否带+号的相同数据存在
                                //存在就不新增,不存在就新增

                                if (App.ReadSqlVal(sql_del_operation, 0, "c") == "0")
                                {
                                    sql_operation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE) values('" + list[i].Pid.ToString() + "','" + operater_type + "',to_timestamp('" + operation_startTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "','+')";
                                }
                                if (App.ReadSqlVal(sql_del_operations, 0, "c") == "0")
                                {
                                    sql_operations = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE) values('" + list[i].Pid.ToString() + "','" + operater_types + "',to_timestamp('" + operation_endTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "','+')";
                                }
                            }
                        }
                        else
                        {
                            sql = string.Format("insert into t_vital_signs ( " +
                                   "bed_no," +
                                   "pid," +
                                   "measure_time," +
                                   "temperature_value," +
                                   "temperature_body," +
                                   "re_measure," +
                                   "cooling_value," +
                                   "cooling_type," +
                                   "pulse_value," +
                                   "is_briefness," +
                                   "is_assist_hr," +
                                   "breath_value," +
                                   "is_assist_br," +
                                   "measure_state," +
                                   "describe," +
                                   "remark," +
                                   "heart_rhythm," +
                                   "patient_id" +
                                   ",PAIN_VALUE,PAIN_MOTHED)values(" +
                                   "'{0}'," +
                                   "'{1}'," +
                                   "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                   "'{3}'," +
                                   "'{4}'," +
                                   "'{5}'," +
                                   "'{6}'," +
                                   "'{7}'," +
                                   "'{8}'," +
                                   "'{9}'," +
                                   "'{10}'," +
                                   "'{11}'," +
                                   "'{12}'," +
                                   "'{13}'," +
                                   "'{14}'," +
                                   "'{15}'," +
                                   "'{16}'," +
                                   "'{17}','{18}','{19}'" +
                                   ")",
                                   list[i].Bed_no,
                                      list[i].Pid,
                                      list[i].Measure_time,
                                      list[i].Temperature_value,
                                      list[i].Temperature_body,
                                      list[i].Re_measure,
                                      list[i].Cooling_value,
                                      list[i].Cooling_type,
                                      list[i].Pulse_value,
                                      list[i].Is_briefness,
                                      list[i].Is_assist_hr,
                                      list[i].Breath_value,
                                      list[i].Is_assist_br,
                                      list[i].Measure_state,
                                      list[i].Describe,
                                      list[i].Remark,
                                      list[i].Heart_rhythm,
                                      list[i].Patient_id,
                                      list[i].Pain_value,
                                      list[i].Pain_mothed
                                      );
                        }
                    }
                    else
                    {
                        sql = string.Format("insert into t_vital_signs ( " +
                                    "bed_no," +
                                    "pid," +
                                    "measure_time," +
                                    "temperature_value," +
                                    "temperature_body," +
                                    "re_measure," +
                                    "cooling_value," +
                                    "cooling_type," +
                                    "pulse_value," +
                                    "is_briefness," +
                                    "is_assist_hr," +
                                    "breath_value," +
                                    "is_assist_br," +
                                    "measure_state," +
                                    "describe," +
                                    "remark," +
                                    "heart_rhythm," +
                                    "patient_id" +
                                    ",PAIN_VALUE,PAIN_MOTHED)values(" +
                                    "'{0}'," +
                                    "'{1}'," +
                                    "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                    "'{3}'," +
                                    "'{4}'," +
                                    "'{5}'," +
                                    "'{6}'," +
                                    "'{7}'," +
                                    "'{8}'," +
                                    "'{9}'," +
                                    "'{10}'," +
                                    "'{11}'," +
                                    "'{12}'," +
                                    "'{13}'," +
                                    "'{14}'," +
                                    "'{15}'," +
                                    "'{16}'," +
                                    "'{17}'" +
                                    ",'{18}','{19}')",
                                    list[i].Bed_no,
                                       list[i].Pid,
                                       list[i].Measure_time,
                                       list[i].Temperature_value,
                                       list[i].Temperature_body,
                                       list[i].Re_measure,
                                       list[i].Cooling_value,
                                       list[i].Cooling_type,
                                       list[i].Pulse_value,
                                       list[i].Is_briefness,
                                       list[i].Is_assist_hr,
                                       list[i].Breath_value,
                                       list[i].Is_assist_br,
                                       list[i].Measure_state,
                                       list[i].Describe,
                                       list[i].Remark,
                                       list[i].Heart_rhythm,
                                       list[i].Patient_id,
                                       list[i].Pain_value,
                                       list[i].Pain_mothed
                                       );
                    }
                    listSql.Add(sql);
                    //list_job_temp.Add(sql_del_operation);
                    //list_job_temp.Add(sql_del_operations);
                    list_job_temp.Add(sql_operation);
                    list_job_temp.Add(sql_operations);
                }
            }
            #endregion


            try
            {

                App.ExecuteBatch(listSql.ToArray());
                App.ExecuteBatch(list_job_temp.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            listSql.Clear();
            list_job_temp.Clear();
            return true;
        }


        /// <summary>
        /// 插入体温特征其他信息
        /// </summary>
        /// <param name="t_temperature_info"></param>
        /// <returns></returns>
        public static bool InsertTempers_Others(Class_T_Temperature_Info tti)
        {
            List<string> listSql = new List<string>();
            List<string> list_job_temp = new List<string>();
            #region 其他信息部分
            string sql2 = string.Format("insert into t_temperature_info( " +   //其他信息SQL 语句
                                              "bed_no," +
                                              "pid," +
                                              "stool_count," +
                                              "stool_state," +
                                              "clysis_count," +
                                              "stool_count_e," +
                                              "stool_amount," +
                                              "stool_amount_unit," +
                                              "stale_amount," +
                                              "is_catheter," +
                                              "weighttype," +
                                              "weight," +
                                              "weight_unit," +
                                              "weight_special," +
                                              "length," +
                                              "sensi_test_code," +
                                              "sensi_test_result," +
                                              "sensi_test_result_temp," +
                                              "record_id," +
                                              "record_time," +
                                              "in_amount," +
                                              "out_amount," +
                                              "out_amount1," +
                                              "out_amount2," +
                                              "out_amount3," +
                                              "remark," +
                                              "bp_high," +
                                              "bp_low," +
                                              "bp_unit," +
                                              "out_other," +
                                              "bp_blood," +
                                              "STOOL_COUNT_F," +
                                              "SPO2," +
                                              "Special," +
                                              "Sputum_quantity," +
                                              "Volume_of_drainage," +
                                              "Vomit," +
                                              "PATIENT_ID,URINE," +
                                              "URINE_STATE," +
                                              "SHIT_STATE," +
                                              "EMPTY_NAME1,EMPTY_VALUE1,EMPTY_NAME2,EMPTY_VALUE2,EMPTY_NAME3,EMPTY_VALUE3,EMPTY_NAME4,EMPTY_VALUE4,EMPTY_NAME5,EMPTY_VALUE5,shit,SENSI,bp_blood2,URINE_COUNT,WATER_AMOUNT)" +
                                              "values(" +
                                              "'{0}'," +
                                              "'{1}'," +
                                              "'{2}'," +
                                              "'{3}'," +
                                              "'{4}'," +
                                              "'{5}'," +
                                              "'{6}'," +
                                              "'{7}'," +
                                              "'{8}'," +
                                              "'{9}'," +
                                              "'{10}'," +
                                              "'{11}'," +
                                              "'{12}'," +
                                              "'{13}'," +
                                              "'{14}'," +
                                              "'{15}'," +
                                              "'{16}'," +
                                              "'{17}'," +
                                              "'{18}'," +
                                              "to_TIMESTAMP('{19}','yyyy-MM-dd hh24:mi')," +
                                              "'{20}'," +
                                              "'{21}'," +
                                              "'{22}'," +
                                              "'{23}'," +
                                              "'{24}'," +
                                              "'{25}'," +
                                              "'{26}'," +
                                              "'{27}'," +
                                              "'{28}'," +
                                              "'{29}'," +
                                              "'{30}'," +
                                              "'{31}'," +
                                              "'{32}'," +
                                              "'{33}'," +
                                              "'{34}'," +
                                              "'{35}'," +
                                              "'{36}'," +
                                              "'{37}','{38}','{39}','{40}','{41}','{42}','{43}','{44}','{45}','{46}','{47}','{48}','{49}','{50}','{51}','{52}','{53}','{54}','{55}')", tti.Bed_no,
                                               tti.Pid,
                                               tti.Stool_count,
                                               tti.Stool_state,
                                               tti.Clysis_count,
                                               tti.Stool_count_e,
                                               tti.Stool_amount,
                                               tti.Stool_amount_unit,
                                               tti.Stale_amount,
                                               tti.Is_catheter,
                                               tti.Weighttype,
                                               tti.Weight,
                                               tti.Weight_unit,
                                               tti.Weight_special,
                                               tti.Length,
                                               tti.Sensi_test_code,
                                               tti.Sensi_test_result,
                                               tti.Sensi_test_result_temp,
                                               tti.Record_id,
                                               tti.Record_time,
                                               tti.In_amount,
                                               tti.Out_amount,
                                               tti.Out_amount1,
                                               tti.Out_amount2,
                                               tti.Out_amount3,
                                               tti.Remark,
                                               tti.Bp_high,
                                               tti.Bp_low,
                                               tti.Bp_unit,
                                               tti.Out_other,
                                               tti.Bp_blood,
                                               tti.Stool_count_f,
                                               tti.Spo2,
                                               tti.Special,
                                               tti.Sputum_quantity,
                                               tti.Volume_of_drainage,
                                               tti.Vomit,
                                               tti.Patient_id, tti.Urine, tti.Urine_state, tti.Shit_state,
                                               tti.Empty_name1, tti.Empty_value1, tti.Empty_name2,
                                               tti.Empty_value2, tti.Empty_name3, tti.Empty_value3, tti.Empty_name4, tti.Empty_value4, tti.Empty_name5, tti.Empty_value5,
                                               tti.Shit, tti.Sensi, tti.Bp_blood2,tti.Urine_count,tti.Water_amount);
            listSql.Add(sql2);
            #endregion


            try
            {

                App.ExecuteBatch(listSql.ToArray());
                //App.ExecuteBatch(list_job_temp.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            listSql.Clear();
            list_job_temp.Clear();
            return true;
        }


        /// <summary>
        /// 插入体温生命特征和其它信息
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool InsertTempers(List<Class_T_Vital_Signs> list, string time, string patient_id, string pid, bool isYN, List<string> ltime, Class_T_Temperature_Info tti)
        {
            List<string> listSql = new List<string>();
            List<string> list_job_temp = new List<string>();
            string sqlcount = string.Format("SELECT count(id) FROM t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, patient_id);
            if (Convert.ToInt32(App.GetDataSet(sqlcount).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql_del = string.Format("DELETE t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}'", time, patient_id);
                listSql.Add(sql_del);
                if (isYN)
                {

                    //在t_job_temp表里，添加了一个相应的EVENT_TYPE字段(varchar(1))。
                    //针对术前记录做event_type字段的赋值;
                    //新增赋值"+"
                    //删除赋值"-"
                    for (int t = 0; t < ltime.Count; t++)
                    {
                        if (ltime[t] != "")
                        {
                            //string sqlTime1 = App.ReadSqlVal("SELECT to_char(measure_time,'yyyy-mm-dd')||replace(describe,'手术_',' ') otime  from t_vital_signs WHERE describe like '%手术%' AND to_char(measure_time,'yyyy-MM-dd hh24:mi') like '" + ltime[t].ToString() + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            //string sql1 = string.Format("update t_job_temp t set t.event_type='-',t.state=null where t.patient_id='{0}' and t.operate_type='术前' and to_char(t.operate_time,'yyyy-mm-dd hh24:mi')='{1}'", patient_id, sqlTime1);
                            //string sqlTime2 = App.ReadSqlVal("SELECT to_char(OPERATIONS_TIME,'yyyy-mm-dd hh24:mi') otime  from t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd hh24:mi') like '" + ltime[t].ToString() + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            //string sql2 = string.Format("update t_job_temp t set t.event_type='-',t.state=null where t.patient_id='{0}' and t.operate_type='术后' and to_char(t.operate_time,'yyyy-mm-dd hh24:mi')='{1}'", patient_id, sqlTime2);

                            string operater_type = "术前";
                            string operater_types = "术后";
                            string operation_startTime = App.ReadSqlVal("SELECT to_char(measure_time,'yyyy-mm-dd')||' '||substr(describe,instr(describe, '手术_', 1)+3,5) otime  from t_vital_signs WHERE describe like '%手术%' AND to_char(measure_time,'yyyy-MM-dd hh24:mi') like '" + ltime[t].ToString() + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            string operation_endTime = App.ReadSqlVal("SELECT to_char(OPERATIONS_TIME,'yyyy-mm-dd hh24:mi') otime  from t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd hh24:mi') like '" + ltime[t].ToString() + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            string pids_id = patient_id;
                            string strAge = string.Empty;
                            string Age = App.ReadSqlVal("select age from t_in_patient where id = " + patient_id, 0, "age");
                            if (App.IsNumeric(Age))
                            {
                                strAge = Age;
                            }
                            //删除的不用判断重复
                            //sql_del_operation = "select count(*) c from t_job_temp where patient_id='" + pids_id + "' and operate_type='术前' and event_type='+' and to_char(operate_time,'yyyy-mm-dd hh24:mi')='" + operation_startTime + "'";
                            //sql_del_operations = "select count(*) c from t_job_temp where patient_id='" + pids_id + "' and operate_type='术后' and event_type='+' and to_char(operate_time,'yyyy-mm-dd hh24:mi')='" + operation_endTime + "'";
                            //新增前,判断是否有id和时间和类型和是否带+号的相同数据存在
                            //存在就不新增,不存在就新增


                            string sql1 = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE) values('" + pid + "','" + operater_type + "',to_timestamp('" + operation_startTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "','-')";

                            string sql2 = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE) values('" + pid + "','" + operater_types + "',to_timestamp('" + operation_endTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "','-')";


                            /* 删除体温单手术事件停止线程 需在体温单删除手术事件中加入如下语句
                             * t_quality_job里的BASE_TIME字段就是t_job_Temp里的operate_time字段
                             * t_quality_record里的noteztime字段和t_quality_job里的EXEC_TIME_R字段相等
                             */
                            //string sql3 = string.Format("delete t_quality_job where text_type in('手术记录','术后首次病程记录','术后记录') and patient_id='{0}' and to_char(BASE_TIME,'yyyy-mm-dd hh24:mi')='{1}'", patient_id, sqlTime2);
                            //string sqlTime3 = App.ReadSqlVal("SELECT to_char(EXEC_TIME_R,'yyyy-mm-dd hh24:mi') otime from t_quality_job where text_type in('手术记录','术后首次病程记录','术后记录') and to_char(BASE_TIME,'yyyy-MM-dd hh24:mi') like '" + sqlTime2 + "' AND PATIENT_ID ='" + patient_id + "'", 0, "otime");
                            //string sql4 = string.Format("delete t_quality_record where doctype in('手术记录','术后首次病程记录','术后记录') and patient_id='{0}' and to_char(noteztime,'yyyy-mm-dd hh24:mi')='{1}'", patient_id, sqlTime3);
                            list_job_temp.Add(sql1);
                            list_job_temp.Add(sql2);
                            //list_job_temp.Add(sql3);
                            //list_job_temp.Add(sql4);
                        }
                    }

                }
            }

            #region 体温部分
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {

                    string sql = "";
                    string sql_delops = "";
                    string sql_del_operation = "";
                    string sql_del_operations = "";
                    string sql_operation = "";
                    string sql_operations = "";
                    if (list[i].Describe != null)
                    {
                        if (list[i].Describe.ToString().Contains("手术"))
                        {
                            sql = string.Format("insert into t_vital_signs ( " +
                                        "bed_no," +
                                        "pid," +
                                        "measure_time," +
                                        "temperature_value," +
                                        "temperature_body," +
                                        "re_measure," +
                                        "cooling_value," +
                                        "cooling_type," +
                                        "pulse_value," +
                                        "is_briefness," +
                                        "is_assist_hr," +
                                        "breath_value," +
                                        "is_assist_br," +
                                        "measure_state," +
                                        "describe," +
                                        "remark," +
                                        "heart_rhythm," +
                                        "OPERATIONS_TIME," +
                                        "PATIENT_ID,PAIN_VALUE,PAIN_MOTHED" +
                                        ")values(" +
                                        "'{0}'," +
                                        "'{1}'," +
                                        "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                        "'{3}'," +
                                        "'{4}'," +
                                        "'{5}'," +
                                        "'{6}'," +
                                        "'{7}'," +
                                        "'{8}'," +
                                        "'{9}'," +
                                        "'{10}'," +
                                        "'{11}'," +
                                        "'{12}'," +
                                        "'{13}'," +
                                        "'{14}'," +
                                        "'{15}'," +
                                        "'{16}'," +
                                        "to_TIMESTAMP('{17}','yyyy-MM-dd hh24:mi')," +
                                        "'{18}','{19}','{20}'" +
                                         ")",
                                        list[i].Bed_no,
                                           list[i].Pid,
                                           list[i].Measure_time,
                                           list[i].Temperature_value,
                                           list[i].Temperature_body,
                                           list[i].Re_measure,
                                           list[i].Cooling_value,
                                           list[i].Cooling_type,
                                           list[i].Pulse_value,
                                           list[i].Is_briefness,
                                           list[i].Is_assist_hr,
                                           list[i].Breath_value,
                                           list[i].Is_assist_br,
                                           list[i].Measure_state,
                                           list[i].Describe,
                                           list[i].Remark,
                                           list[i].Heart_rhythm,
                                           list[i].Operater_after_time,
                                           list[i].Patient_id, list[i].Pain_value, list[i].Pain_mothed
                                           );

                            if (list[i].Describe.ToString().Contains("手术"))
                            {
                                string operater_type = "术前";
                                string operater_types = "术后";
                                string operation_startTime = list[i].Operater_before_time;
                                //string operation_endTime = Convert.ToDateTime(list[i].Operater_after_time).AddDays(1).Date.ToString();
                                string operation_endTime = list[i].Operater_after_time;
                                string pids_id = list[i].Patient_id;
                                string strAge = string.Empty;
                                string Age = App.ReadSqlVal("select age from t_in_patient where id = " + pids_id, 0, "age");
                                if (App.IsNumeric(Age))
                                {
                                    strAge = Age;
                                }
                                sql_del_operation = "select count(*) c from t_job_temp where patient_id='" + pids_id + "' and operate_type='术前' and event_type='+' and to_char(operate_time,'yyyy-mm-dd hh24:mi')='" + operation_startTime + "'";
                                sql_del_operations = "select count(*) c from t_job_temp where patient_id='" + pids_id + "' and operate_type='术后' and event_type='+' and to_char(operate_time,'yyyy-mm-dd hh24:mi')='" + operation_endTime + "'";
                                //新增前,判断是否有id和时间和类型和是否带+号的相同数据存在
                                //存在就不新增,不存在就新增

                                if (App.ReadSqlVal(sql_del_operation, 0, "c") == "0")
                                {
                                    sql_operation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE) values('" + list[i].Pid.ToString() + "','" + operater_type + "',to_timestamp('" + operation_startTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "','+')";
                                }
                                if (App.ReadSqlVal(sql_del_operations, 0, "c") == "0")
                                {
                                    sql_operations = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age,EVENT_TYPE) values('" + list[i].Pid.ToString() + "','" + operater_types + "',to_timestamp('" + operation_endTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + ",'" + strAge + "','+')";
                                }
                            }
                        }
                        else
                        {
                            sql = string.Format("insert into t_vital_signs ( " +
                                   "bed_no," +
                                   "pid," +
                                   "measure_time," +
                                   "temperature_value," +
                                   "temperature_body," +
                                   "re_measure," +
                                   "cooling_value," +
                                   "cooling_type," +
                                   "pulse_value," +
                                   "is_briefness," +
                                   "is_assist_hr," +
                                   "breath_value," +
                                   "is_assist_br," +
                                   "measure_state," +
                                   "describe," +
                                   "remark," +
                                   "heart_rhythm," +
                                   "patient_id" +
                                   ",PAIN_VALUE,PAIN_MOTHED)values(" +
                                   "'{0}'," +
                                   "'{1}'," +
                                   "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                   "'{3}'," +
                                   "'{4}'," +
                                   "'{5}'," +
                                   "'{6}'," +
                                   "'{7}'," +
                                   "'{8}'," +
                                   "'{9}'," +
                                   "'{10}'," +
                                   "'{11}'," +
                                   "'{12}'," +
                                   "'{13}'," +
                                   "'{14}'," +
                                   "'{15}'," +
                                   "'{16}'," +
                                   "'{17}','{18}','{19}'" +
                                   ")",
                                   list[i].Bed_no,
                                      list[i].Pid,
                                      list[i].Measure_time,
                                      list[i].Temperature_value,
                                      list[i].Temperature_body,
                                      list[i].Re_measure,
                                      list[i].Cooling_value,
                                      list[i].Cooling_type,
                                      list[i].Pulse_value,
                                      list[i].Is_briefness,
                                      list[i].Is_assist_hr,
                                      list[i].Breath_value,
                                      list[i].Is_assist_br,
                                      list[i].Measure_state,
                                      list[i].Describe,
                                      list[i].Remark,
                                      list[i].Heart_rhythm,
                                      list[i].Patient_id,
                                      list[i].Pain_value,
                                      list[i].Pain_mothed
                                      );
                        }
                    }
                    else
                    {
                        sql = string.Format("insert into t_vital_signs ( " +
                                    "bed_no," +
                                    "pid," +
                                    "measure_time," +
                                    "temperature_value," +
                                    "temperature_body," +
                                    "re_measure," +
                                    "cooling_value," +
                                    "cooling_type," +
                                    "pulse_value," +
                                    "is_briefness," +
                                    "is_assist_hr," +
                                    "breath_value," +
                                    "is_assist_br," +
                                    "measure_state," +
                                    "describe," +
                                    "remark," +
                                    "heart_rhythm," +
                                    "patient_id" +
                                    ",PAIN_VALUE,PAIN_MOTHED)values(" +
                                    "'{0}'," +
                                    "'{1}'," +
                                    "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                    "'{3}'," +
                                    "'{4}'," +
                                    "'{5}'," +
                                    "'{6}'," +
                                    "'{7}'," +
                                    "'{8}'," +
                                    "'{9}'," +
                                    "'{10}'," +
                                    "'{11}'," +
                                    "'{12}'," +
                                    "'{13}'," +
                                    "'{14}'," +
                                    "'{15}'," +
                                    "'{16}'," +
                                    "'{17}'" +
                                    ",'{18}','{19}')",
                                    list[i].Bed_no,
                                       list[i].Pid,
                                       list[i].Measure_time,
                                       list[i].Temperature_value,
                                       list[i].Temperature_body,
                                       list[i].Re_measure,
                                       list[i].Cooling_value,
                                       list[i].Cooling_type,
                                       list[i].Pulse_value,
                                       list[i].Is_briefness,
                                       list[i].Is_assist_hr,
                                       list[i].Breath_value,
                                       list[i].Is_assist_br,
                                       list[i].Measure_state,
                                       list[i].Describe,
                                       list[i].Remark,
                                       list[i].Heart_rhythm,
                                       list[i].Patient_id,
                                       list[i].Pain_value,
                                       list[i].Pain_mothed
                                       );
                    }
                    listSql.Add(sql);
                    //list_job_temp.Add(sql_del_operation);
                    //list_job_temp.Add(sql_del_operations);
                    list_job_temp.Add(sql_operation);
                    list_job_temp.Add(sql_operations);
                }
            }
            #endregion

            #region 其他信息部分
            string sql_other = string.Format("insert into t_temperature_info( " +   //其他信息SQL 语句
                                              "bed_no," +
                                              "pid," +
                                              "stool_count," +
                                              "stool_state," +
                                              "clysis_count," +
                                              "stool_count_e," +
                                              "stool_amount," +
                                              "stool_amount_unit," +
                                              "stale_amount," +
                                              "is_catheter," +
                                              "weighttype," +
                                              "weight," +
                                              "weight_unit," +
                                              "weight_special," +
                                              "length," +
                                              "sensi_test_code," +
                                              "sensi_test_result," +
                                              "sensi_test_result_temp," +
                                              "record_id," +
                                              "record_time," +
                                              "in_amount," +
                                              "out_amount," +
                                              "out_amount1," +
                                              "out_amount2," +
                                              "out_amount3," +
                                              "remark," +
                                              "bp_high," +
                                              "bp_low," +
                                              "bp_unit," +
                                              "out_other," +
                                              "bp_blood," +
                                              "STOOL_COUNT_F," +
                                              "SPO2," +
                                              "Special," +
                                              "Sputum_quantity," +
                                              "Volume_of_drainage," +
                                              "Vomit," +
                                              "PATIENT_ID,URINE,URINE_STATE,SHIT_STATE)" +
                                              "values(" +
                                              "'{0}'," +
                                              "'{1}'," +
                                              "'{2}'," +
                                              "'{3}'," +
                                              "'{4}'," +
                                              "'{5}'," +
                                              "'{6}'," +
                                              "'{7}'," +
                                              "'{8}'," +
                                              "'{9}'," +
                                              "'{10}'," +
                                              "'{11}'," +
                                              "'{12}'," +
                                              "'{13}'," +
                                              "'{14}'," +
                                              "'{15}'," +
                                              "'{16}'," +
                                              "'{17}'," +
                                              "'{18}'," +
                                              "to_TIMESTAMP('{19}','yyyy-MM-dd hh24:mi')," +
                                              "'{20}'," +
                                              "'{21}'," +
                                              "'{22}'," +
                                              "'{23}'," +
                                              "'{24}'," +
                                              "'{25}'," +
                                              "'{26}'," +
                                              "'{27}'," +
                                              "'{28}'," +
                                              "'{29}'," +
                                              "'{30}'," +
                                              "'{31}'," +
                                              "'{32}'," +
                                              "'{33}'," +
                                              "'{34}'," +
                                              "'{35}'," +
                                              "'{36}'," +
                                              "'{37}','{38}','{39}','{40}')", tti.Bed_no,
                                               tti.Pid,
                                               tti.Stool_count,
                                               tti.Stool_state,
                                               tti.Clysis_count,
                                               tti.Stool_count_e,
                                               tti.Stool_amount,
                                               tti.Stool_amount_unit,
                                               tti.Stale_amount,
                                               tti.Is_catheter,
                                               tti.Weighttype,
                                               tti.Weight,
                                               tti.Weight_unit,
                                               tti.Weight_special,
                                               tti.Length,
                                               tti.Sensi_test_code,
                                               tti.Sensi_test_result,
                                               tti.Sensi_test_result_temp,
                                               tti.Record_id,
                                               tti.Record_time,
                                               tti.In_amount,
                                               tti.Out_amount,
                                               tti.Out_amount1,
                                               tti.Out_amount2,
                                               tti.Out_amount3,
                                               tti.Remark,
                                               tti.Bp_high,
                                               tti.Bp_low,
                                               tti.Bp_unit,
                                               tti.Out_other,
                                               tti.Bp_blood,
                                               tti.Stool_count_f,
                                               tti.Spo2,
                                               tti.Special,
                                               tti.Sputum_quantity,
                                               tti.Volume_of_drainage,
                                               tti.Vomit,
                                               tti.Patient_id, tti.Urine, tti.Urine_state, tti.Shit_state);
            listSql.Add(sql_other);
            #endregion


            try
            {

                App.ExecuteBatch(listSql.ToArray());
                App.ExecuteBatch(list_job_temp.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            listSql.Clear();
            list_job_temp.Clear();
            return true;
        }





        /// <summary>
        /// 查询当天的数据
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="pid">病案号</param>
        /// <returns></returns>
        public static bool SelectGreaterZero(string time, string pid)
        {
            string sql = string.Format("SELECT count(id) FROM t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);
            string sql2 = string.Format("SELECT count(id) FROM t_temperature_info WHERE to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);

            if (Convert.ToInt32(App.GetDataSet(sql).Tables[0].Rows[0][0].ToString()) > 0
                || Convert.ToInt32(App.GetDataSet(sql2).Tables[0].Rows[0][0].ToString()) > 0)
                return false;
            else
                return true;

        }

        /// <summary>
        /// 清除今天的数据(老版本的系统用的)
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="pid">病案号</param>
        public static void IsClear(string time, string pid)
        {
            string sql = string.Format("SELECT count(id) FROM t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);
            string sql2 = string.Format("SELECT count(id) FROM t_temperature_info WHERE to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);
            if (Convert.ToInt32(App.GetDataSet(sql).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql3 = string.Format("DELETE t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}'", time, pid);
                App.ExecuteSQL(sql3);
            }

            if (Convert.ToInt32(App.GetDataSet(sql2).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql4 = string.Format("DELETE  from t_temperature_info WHERE to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID='{1}' ", time, pid);
                App.ExecuteSQL(sql4);
            }
        }

        /// <summary>
        /// 清除今天 体温呼吸血压脉搏的数据
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="pid">病案号</param>
        public static void IsClear_Temperasure(string time, string pid)
        {
            string sql = string.Format("SELECT count(id) FROM t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}'  ", time, pid);
            if (Convert.ToInt32(App.GetDataSet(sql).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql3 = string.Format("DELETE t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}'", time, pid);
                App.ExecuteSQL(sql3);

            }
        }

        /// <summary>
        /// 清除今天当前时间点的 体温呼吸血压脉搏的数据
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="pid">病案号</param>
        public static void IsClear_Temperasure_Time(DateTime time, string pid)
        {
            string t1 = time.AddHours(-2).ToString("yyyy-MM-dd HH:mm");
            string t2 = time.AddHours(2).AddMinutes(-1).ToString("yyyy-MM-dd HH:mm");

            string sql = string.Format("SELECT count(id) FROM t_vital_signs WHERE MEASURE_TIME BETWEEN to_date('{0}','yyyy-MM-dd hh24:mi') AND to_date('{1}','yyyy-MM-dd hh24:mi') AND PATIENT_ID ='{2}'  ", t1, t2, pid);
            if (Convert.ToInt32(App.GetDataSet(sql).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql3 = string.Format("DELETE t_vital_signs WHERE MEASURE_TIME BETWEEN to_date('{0}','yyyy-MM-dd hh24:mi') AND to_date('{1}','yyyy-MM-dd hh24:mi') AND PATIENT_ID ='{2}'  ", t1, t2, pid);
                App.ExecuteSQL(sql3);

            }
        }

        /// <summary>
        /// 清除今天的体温单其他数据
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="pid">病案号</param>
        public static void IsClear_Others(string time, string pid)
        {
            //string sql = string.Format("SELECT count(id) FROM t_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd hh24:mi') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);
            string sql2 = string.Format("SELECT count(id) FROM t_temperature_info WHERE to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);
            if (Convert.ToInt32(App.GetDataSet(sql2).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql4 = string.Format("DELETE  from t_temperature_info WHERE to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID='{1}' ", time, pid);
                App.ExecuteSQL(sql4);
            }
        }

        /// <summary>
        /// 查询体温信息
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static List<DataTable> GetTemper(string time, string pid)
        {
            List<DataTable> list = new List<DataTable>();
            DataSet ds = new DataSet();
            string sql = string.Format("select measure_time, " +
                                        "temperature_value, temperature_body, " +
                                        "re_measure, cooling_value, cooling_type," +
                                        "pulse_value, is_briefness, is_assist_hr, " +
                                        "breath_value, is_assist_br, measure_state, " +
                                        "describe, remark, heart_rhythm,operations_time,PAIN_VALUE,PAIN_MOTHED,PATIENT_ID,pain_value2,is_qixian from t_vital_signs WHERE " +
                                        "to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ORDER BY MEASURE_TIME", time, pid);

            
            string sql2 = string.Format("select bed_no,stool_count," +
                                        "stool_state, clysis_count, stool_count_e," +
                                        "stool_amount, stool_amount_unit, stale_amount," +
                                        "is_catheter, weighttype, weight, weight_unit," +
                                        "weight_special, length, sensi_test_code, sensi_test_result," +
                                        "sensi_test_result_temp, record_id, record_time, in_amount," +
                                        "out_amount, out_amount1, out_amount2, out_amount3," +
                                        "remark, bp_high, bp_low, bp_unit,out_other, bp_blood,bp_blood2,Stool_count_f," +
                                        "SPO2,SPUTUM_QUANTITY,VOLUME_OF_DRAINAGE,VOMIT,Special,URINE,URINE_STATE,SHIT_STATE,empty_name1," +
                                        "empty_value1,empty_name2,empty_value2,shit,empty_name3,empty_value3,empty_name4,empty_value4," +
                                        "empty_name5,empty_value5,sensi,urine_count,water_amount from t_temperature_info WHERE " +
                                        "to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID = '{1}' ", time, pid);

            DataTable dt1 = App.GetDataSet(sql).Tables[0];
            DataTable dt2 = App.GetDataSet(sql2).Tables[0];

            list.Add(dt1);
            list.Add(dt2);

            return list;
        }

        /// <summary>
        /// 返回7天的体温
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public static List<DataTable> GetTempertureCount(string inTime, string startTime, string endTime, string pid)
        {
            List<DataTable> list = new List<DataTable>();
            string sql = string.Format("select measure_time, " +
                                        "temperature_value, temperature_body, " +
                                        "re_measure, cooling_value, cooling_type," +
                                        "pulse_value, is_briefness, is_assist_hr, " +
                                        "breath_value, is_assist_br, measure_state, " +
                                        "describe, remark, heart_rhythm,PAIN_VALUE,PAIN_MOTHED,pain_value2,is_qixian from t_vital_signs " +
                                        "WHERE to_char(MEASURE_TIME,'yyyy-MM-dd') " +
                                        "BETWEEN '{0}' AND '{1}' AND pid = '{2}' ORDER BY MEASURE_TIME ", startTime, endTime, pid);

            string sql2 = string.Format("select stool_count, stool_state, clysis_count, stool_count_e, " +
                                        "stool_amount, stool_amount_unit, stale_amount, is_catheter, weighttype, " +
                                        "weight, weight_unit, weight_special, length, sensi_test_code, sensi_test_result, " +
                                        "sensi_test_result_temp, record_id, record_time, in_amount, out_amount, out_amount1, " +
                                        "out_amount2, out_amount3, remark, bp_high, bp_low, bp_unit,out_other, bp_blood,URINE,URINE_STATE,urine_count,water_amount from t_temperature_info " +
                                        "WHERE to_char(record_time,'yyyy-MM-dd') BETWEEN '{0}' AND '{1}' AND pid = '{2}' ORDER BY record_time", startTime, endTime, pid);

            string sql3 = string.Format("select measure_time from t_vital_signs " +
                                        "where  Describe like '%手术%' " +
                                        "and pid ='{0}' " +
                                        "and to_char(MEASURE_TIME,'yyyy-MM-dd') BETWEEN '{1}' AND '{2}' " +
                                        "ORDER BY MEASURE_TIME", pid, DateTime.Parse(inTime).ToString("yyyy-MM-dd"), endTime);

            list.Add(App.GetDataSet(sql).Tables[0]);
            list.Add(App.GetDataSet(sql2).Tables[0]);
            list.Add(App.GetDataSet(sql3).Tables[0]);
            return list;
        }

        /// <summary>
        /// 生成日志文件
        /// </summary>
        /// <param name="tittle"></param>
        /// <param name="ErrMsg"></param>
        public static void ErrorLog(string tittle, string ErrMsg)
        {
            try
            {
                if (!File.Exists(Application.StartupPath + "\\LOG"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "\\LOG");
                }


                string strval = "发生时间：" + DateTime.Now.ToString() + "  " + tittle + "\r\n" + "描述：" + ErrMsg + "\r\r";
                FileStream fs = null;
                byte[] array = new UTF8Encoding(true).GetBytes(strval);
                string filename = Application.StartupPath + "\\LOG\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                if (File.Exists(filename))
                {
                    StreamWriter sw = File.AppendText(filename);
                    sw.WriteLine(strval);
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                    fs.Write(array, 0, array.Length);
                    fs.Flush();
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 删除过期体温单操作日志
        /// </summary>
        /// <returns></returns>
        public static void DelLog()
        {
            string path = Application.StartupPath + "\\LOG";
            if (!Directory.Exists(path))//文件夹是否存在
                return;
            string pattern = "*.txt";
            string[] strFileName = Directory.GetFiles(path, pattern);
            foreach (string item in strFileName)
            {
                try
                {
                    TimeSpan text = DateTime.Now.Subtract(Convert.ToDateTime(Path.GetFileNameWithoutExtension(item)));
                    if (text.Days > 14)
                    {
                        File.Delete(item);
                    }
                }
                catch (Exception)
                {
                }
            }
        }
        public static bool InsertTempers_Others(Class_T_CHILD_TEMPERATURE_INFO tti)
        {
            List<string> listSql = new List<string>();
            //List<string> list_job_temp = new List<string>();
            #region 其他信息部分
            string sql2 = string.Format("insert into t_child_temperature_info( id," +   //其他信息SQL 语句
                                              "PATIENT_ID," +
                                              "record_time," +
                                              "Stool_count," +
                                              "Stool_color," +
                                              "xb," +
                                              "weight," +
                                              "Feed_style," +
                                              "qm," +
                                              "ybqk," +
                                              "Umbilicalcord)" +
                                              "values(" +
                                              "'{0}'," +
                                              "'{1}'," +
                                              "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                              "'{3}'," +
                                              "'{4}'," +
                                              "'{5}'," +
                                              "'{6}'," +
                                              "'{7}'," +
                                              "'{8}'," +
                                              "'{9}'," +
                                              "'{10}')"
                                               , tti.Id,
                                               tti.Patient_ID,
                                               tti.Record_time,
                                               tti.Stool_count,
                                               tti.Stool_color,
                                               tti.Urine,
                                               tti.Weight,
                                               tti.Feed_style,
                                               tti.Qm,
                                               tti.Ybqk,
                                               tti.Umbilicalcord);
            listSql.Add(sql2);
            #endregion


            try
            {

                App.ExecuteBatch(listSql.ToArray());
                //App.ExecuteBatch(list_job_temp.ToArray());
            }
            catch (Exception ex)
            {
                return false;
            }
            listSql.Clear();
            //list_job_temp.Clear();
            return true;
        }

        /// <summary>
        /// 插入体温特征
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool InsertTempers(List<Class_T_Vital_Signs> list)
        {
            List<string> listSql = new List<string>();
            List<string> list_job_temp = new List<string>();

            #region 体温部分
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    string sql = "";
                    string sql_operation = "";
                    string sql_operations = "";
                    if (list[i].Describe != null && list[i].Describe.ToString().Contains("手术"))
                    {
                        #region
                        sql = string.Format("insert into t_vital_signs ( " +
                                    "bed_no," +
                                    "pid," +
                                    "measure_time," +
                                    "temperature_value," +
                                    "temperature_body," +
                                    "re_measure," +
                                    "cooling_value," +
                                    "cooling_type," +
                                    "pulse_value," +
                                    "is_briefness," +
                                    "is_assist_hr," +
                                    "breath_value," +
                                    "is_assist_br," +
                                    "measure_state," +
                                    "describe," +
                                    "remark," +
                                    "heart_rhythm," +
                                    "OPERATIONS_TIME," +
                                    "PATIENT_ID,PAIN_VALUE,PAIN_MOTHED,pain_value2" +
                                    ")values(" +
                                    "'{0}'," +
                                    "'{1}'," +
                                    "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                                    "'{3}'," +
                                    "'{4}'," +
                                    "'{5}'," +
                                    "'{6}'," +
                                    "'{7}'," +
                                    "'{8}'," +
                                    "'{9}'," +
                                    "'{10}'," +
                                    "'{11}'," +
                                    "'{12}'," +
                                    "'{13}'," +
                                    "'{14}'," +
                                    "'{15}'," +
                                    "'{16}'," +
                                    "to_TIMESTAMP('{17}','yyyy-MM-dd hh24:mi')," +
                                    "'{18}','{19}','{20}','{21}'" +
                                     ")",
                                    list[i].Bed_no,
                                       list[i].Pid,
                                       list[i].Measure_time,
                                       list[i].Temperature_value,
                                       list[i].Temperature_body,
                                       list[i].Re_measure,
                                       list[i].Cooling_value,
                                       list[i].Cooling_type,
                                       list[i].Pulse_value,
                                       list[i].Is_briefness,
                                       list[i].Is_assist_hr,
                                       list[i].Breath_value,
                                       list[i].Is_assist_br,
                                       list[i].Measure_state,
                                       list[i].Describe,
                                       list[i].Remark,
                                       list[i].Heart_rhythm,
                                       list[i].Operater_after_time,
                                       list[i].Patient_id,
                                       list[i].Pain_value,
                                       list[i].Pain_mothed,
                                       list[i].Pain_value2);

                        string pid = list[i].Pid.ToString();
                        string operater_type = "术前";
                        string operater_types = "术后";
                        string operation_startTime = list[i].Operater_before_time;
                        string operation_endTime = list[i].Operater_after_time;
                        string pids_id = list[i].Patient_id;
                        string Age = App.ReadSqlVal("select age from t_in_patient where id = " + pids_id, 0, "age");
                        sql_operation = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age) values('" + pid + "','" + operater_type + "',to_timestamp('" + operation_startTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + "," + Age + ")";
                        sql_operations = "insert into t_job_temp(PID,OPERATE_TYPE,OPERATE_TIME,PATIENT_ID,age) values('" + pid + "','" + operater_types + "',to_timestamp('" + operation_endTime + "','syyyy-mm-dd hh24:mi:ss')," + pids_id + "," + Age + ")";
                        #endregion

                    }
                    else
                    {
                        #region
                        sql = string.Format("insert into t_vital_signs ( " +
                               "bed_no," +
                               "pid," +
                               "measure_time," +
                               "temperature_value," +
                               "temperature_body," +
                               "re_measure," +
                               "cooling_value," +
                               "cooling_type," +
                               "pulse_value," +
                               "is_briefness," +
                               "is_assist_hr," +
                               "breath_value," +
                               "is_assist_br," +
                               "measure_state," +
                               "describe," +
                               "remark," +
                               "heart_rhythm," +
                               "patient_id" +
                               ",PAIN_VALUE,PAIN_MOTHED,PAIN_VALUE2)values(" +
                               "'{0}'," +
                               "'{1}'," +
                               "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                               "'{3}'," +
                               "'{4}'," +
                               "'{5}'," +
                               "'{6}'," +
                               "'{7}'," +
                               "'{8}'," +
                               "'{9}'," +
                               "'{10}'," +
                               "'{11}'," +
                               "'{12}'," +
                               "'{13}'," +
                               "'{14}'," +
                               "'{15}'," +
                               "'{16}'," +
                               "'{17}','{18}','{19}','{20}'" +
                               ")",
                               list[i].Bed_no,
                                  list[i].Pid,
                                  list[i].Measure_time,
                                  list[i].Temperature_value,
                                  list[i].Temperature_body,
                                  list[i].Re_measure,
                                  list[i].Cooling_value,
                                  list[i].Cooling_type,
                                  list[i].Pulse_value,
                                  list[i].Is_briefness,
                                  list[i].Is_assist_hr,
                                  list[i].Breath_value,
                                  list[i].Is_assist_br,
                                  list[i].Measure_state,
                                  list[i].Describe,
                                  list[i].Remark,
                                  list[i].Heart_rhythm,
                                  list[i].Patient_id,
                                  list[i].Pain_value,
                                  list[i].Pain_mothed,
                                  list[i].Pain_value2
                                  );
                        #endregion
                    }

                    #region 注释:与上面重复
                    //sql = string.Format("insert into t_vital_signs ( " +
                    //            "bed_no," +
                    //            "pid," +
                    //            "measure_time," +
                    //            "temperature_value," +
                    //            "temperature_body," +
                    //            "re_measure," +
                    //            "cooling_value," +
                    //            "cooling_type," +
                    //            "pulse_value," +
                    //            "is_briefness," +
                    //            "is_assist_hr," +
                    //            "breath_value," +
                    //            "is_assist_br," +
                    //            "measure_state," +
                    //            "describe," +
                    //            "remark," +
                    //            "heart_rhythm," +
                    //            "patient_id" +
                    //            ",PAIN_VALUE,PAIN_MOTHED,PAIN_VALUE2,is_qixian)values(" +
                    //            "'{0}'," +
                    //            "'{1}'," +
                    //            "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                    //            "'{3}'," +
                    //            "'{4}'," +
                    //            "'{5}'," +
                    //            "'{6}'," +
                    //            "'{7}'," +
                    //            "'{8}'," +
                    //            "'{9}'," +
                    //            "'{10}'," +
                    //            "'{11}'," +
                    //            "'{12}'," +
                    //            "'{13}'," +
                    //            "'{14}'," +
                    //            "'{15}'," +
                    //            "'{16}'," +
                    //            "'{17}'" +
                    //            ",'{18}','{19}','{20}','{21}')",
                    //            list[i].Bed_no,
                    //               list[i].Pid,
                    //               list[i].Measure_time,
                    //               list[i].Temperature_value,
                    //               list[i].Temperature_body,
                    //               list[i].Re_measure,
                    //               list[i].Cooling_value,
                    //               list[i].Cooling_type,
                    //               list[i].Pulse_value,
                    //               list[i].Is_briefness,
                    //               list[i].Is_assist_hr,
                    //               list[i].Breath_value,
                    //               list[i].Is_assist_br,
                    //               list[i].Measure_state,
                    //               list[i].Describe,
                    //               list[i].Remark,
                    //               list[i].Heart_rhythm,
                    //               list[i].Patient_id,
                    //               list[i].Pain_value,
                    //               list[i].Pain_mothed,
                    //               list[i].Pain_value2,
                    //               list[i].Is_qixian
                    //               );
                    #endregion

                    if (list[i].Is_qixian=="Y")
                    {
                        #region 骑线体温单记录保存
                        string sqlqx = string.Format("insert into t_vital_signs ( " +
                               "bed_no," +
                               "pid," +
                               "measure_time," +
                               "temperature_value," +
                               "temperature_body," +
                               "re_measure," +
                               "cooling_value," +
                               "cooling_type," +
                               "pulse_value," +
                               "is_briefness," +
                               "is_assist_hr," +
                               "breath_value," +
                               "is_assist_br," +
                               "measure_state," +
                               "describe," +
                               "remark," +
                               "heart_rhythm," +
                               "patient_id" +
                               ",PAIN_VALUE,PAIN_MOTHED,PAIN_VALUE2,is_qixian)values(" +
                               "'{0}'," +
                               "'{1}'," +
                               "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi')," +
                               "'{3}'," +
                               "'{4}'," +
                               "'{5}'," +
                               "'{6}'," +
                               "'{7}'," +
                               "'{8}'," +
                               "'{9}'," +
                               "'{10}'," +
                               "'{11}'," +
                               "'{12}'," +
                               "'{13}'," +
                               "'{14}'," +
                               "'{15}'," +
                               "'{16}'," +
                               "'{17}','{18}','{19}','{20}','{21}'" +
                               ")",
                               list[i].Bed_no,
                                  list[i].Pid,
                                 Convert.ToDateTime(list[i].Measure_time).AddHours(-2).ToString("yyyy-MM-dd HH:mm"),
                                  list[i].Temperature_valueQX,
                                  list[i].Temperature_bodyQX,
                                  list[i].Re_measureQX,
                                  list[i].Cooling_valueQX,
                                  list[i].Cooling_typeQX,
                                  list[i].Pulse_valueQX,
                                  list[i].Is_briefnessQX,
                                  list[i].Is_assist_hrQX,
                                  list[i].Breath_valueQX,
                                  list[i].Is_assist_brQX,
                                  "F", "", "",
                                  list[i].Heart_rhythmQX,
                                  list[i].Patient_id,
                                  list[i].Pain_valueQX,
                                  list[i].Pain_mothedQX,
                                  list[i].Pain_value2QX,
                                  list[i].Is_qixian
                                  );
                        #endregion
                        listSql.Add(sqlqx);
                    }

                    listSql.Add(sql);
                    //list_job_temp.Add(sql_operation);
                    //list_job_temp.Add(sql_operations);
                }
            }
            #endregion

            try
            {

                App.ExecuteBatch(listSql.ToArray());
                //App.ExecuteBatch(list_job_temp.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            listSql.Clear();
            list_job_temp.Clear();
            return true;
        }
        /// <summary>
        /// 插入新生儿体温特征
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool InsertTempers(List<Class_T_CHILD_VITAL_SIGNS> list)
        {
            List<string> listSql = new List<string>();

            #region 体温部分
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != null)
                {
                    string sql = "";
                    
                    sql = string.Format("insert into t_child_vital_signs ( " +
                                "measure_time," +
                                "temperature_value," +
                                "temperature_body," +
                                "re_measure," +
                                "cooling_value," +
                                "measure_state," +
                                "PATIENT_ID,id" +
                                ")values(" +
                                "to_TIMESTAMP('{0}','yyyy-MM-dd hh24:mi')," +
                                "'{1}'," +
                                "'{2}'," +
                                "'{3}'," +
                                "'{4}'," +
                                "'{5}'," +
                                "'{6}'," +
                                "'{7}')",
                                   list[i].Measure_time,
                                   list[i].Temperature_value,
                                   list[i].Temperature_body,
                                   list[i].Re_measure,
                                   list[i].Cooling_value,
                                   list[i].Measure_state,
                                   list[i].Patient_id,
                                   list[i].ID);

                    listSql.Add(sql);
                }
            }
            #endregion


            try
            {

                App.ExecuteBatch(listSql.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            listSql.Clear();
            return true;
        }

        /// <summary>
        /// 清除新生儿当天数据
        /// </summary>
        /// <param name="time"></param>
        /// <param name="pid"></param>
        public static void IsClear_ChildTemperasure(string time, string pid)
        {
            string sql = string.Format("SELECT count(id) FROM t_child_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);
            if (Convert.ToInt32(App.GetDataSet(sql).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql3 = string.Format("DELETE t_child_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}'", time, pid);
                App.ExecuteSQL(sql3);
            }
            string sql2 = string.Format("SELECT count(id) FROM t_child_temperature_info WHERE to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);
            if (Convert.ToInt32(App.GetDataSet(sql2).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql4 = string.Format("DELETE  from t_child_temperature_info WHERE to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID='{1}' ", time, pid);
                App.ExecuteSQL(sql4);
            }
        }


        /// <summary>
        /// 查询新生儿体温信息
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static List<DataTable> GetChildTemper(string time, string pid)
        {
            List<DataTable> list = new List<DataTable>();
            DataSet ds = new DataSet();
            string sql = string.Format("select measure_time, " +
                                        "temperature_value, temperature_body, " +
                                        "re_measure, cooling_value, measure_state from t_child_vital_signs WHERE " +
                                        "to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ORDER BY MEASURE_TIME", time, pid);

            string sql2 = string.Format("select stool_count," +
                                        "stool_color,weight," +
                                        "record_time,feed_style," +
                                        "Umbilicalcord,ybqk,qm,xb from t_child_temperature_info WHERE " +
                                        "to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID = '{1}' ", time, pid);


            DataTable dt1 = App.GetDataSet(sql).Tables[0];
            DataTable dt2 = App.GetDataSet(sql2).Tables[0];

            list.Add(dt1);
            list.Add(dt2);

            return list;
        }



        /// <summary>
        /// 新生儿体温单当前天是否有数据
        /// </summary>
        /// <param name="time"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public static bool ChildTemperatureCurDayHaveData(string time, string pid)
        {
            string sql = string.Format("SELECT count(id) FROM t_child_vital_signs WHERE to_char(measure_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);
            string sql2 = string.Format("SELECT count(id) FROM t_child_temperature_info WHERE to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID ='{1}' ", time, pid);

            if (Convert.ToInt32(App.GetDataSet(sql).Tables[0].Rows[0][0].ToString()) > 0
                || Convert.ToInt32(App.GetDataSet(sql2).Tables[0].Rows[0][0].ToString()) > 0)
                return false;
            else
                return true;
        }


    }

    [Serializable]
    public class Class1
    {
        private List<DataTable> list;

        public List<DataTable> List
        {
            get { return list; }
            set { list = value; }
        }
    }
}