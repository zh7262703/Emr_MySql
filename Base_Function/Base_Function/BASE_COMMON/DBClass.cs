using System;
using System.Collections.Generic;
using System.Text;
using Bifrost;
using System.Data;
using Base_Function.MODEL;

namespace Base_Function.BASE_COMMON
{
    public class DBClass
    {
        /// <summary>
        /// 插入体温特征
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool InsertTempers(List<Class_T_CHILD_VITAL_SIGNS> list, Class_T_CHILD_TEMPERATURE_INFO tti)
        {
            List<string> listSql = new List<string>();
            List<string> listSql1 = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                string sql = "";
                string sql_operation = "";
                string sql_operations = "";
                if (list[i] != null)
                {

                    //if (list[i].Describe.ToString() != "")
                    //{
                    //    if (list[i].Describe.ToString().Contains("手术"))
                    //    {

                    //    }
                    //}
                    //else
                    //{
                        sql = string.Format("insert into T_CHILD_VITAL_SIGNS ( " +
                                           "CHILD_ID," +
                                           "MEASURE_TIME," +
                                           "TEMPERATURE_VALUE," +
                                           "RE_MEASURE," +
                                           "DESCRIBE," +
                                           "TEMP_STATE," +
                                           "COOLING_VALUE"+
                                           ") values(" +
                                           "'{0}'," +
                                           "to_TIMESTAMP('{1}','yyyy-MM-dd hh24:mi')," +
                                           "'{2}'," +
                                           "'{3}'," +
                                           "'{4}'," +
                                           "'{5}'," +
                                           "'{6}'" +
                                           ")",
                                           list[i].Child_id,
                                              list[i].Measure_time,
                                              list[i].Temperature_value,
                                              list[i].Re_measure,
                                              list[i].Describe,
                                              list[i].Temp_state,
                                              list[i].Cooling_value
                                              );
                   // }

                     listSql.Add(sql);
                }
                
            }
            string sql2 = string.Format("insert into T_CHILD_TEMPERATURE_INFO( " +   //其他信息SQL 语句
                                              "CHILD_ID," +
                                              "FEED_STYLE," +
                                              "ICTERUS," +
                                              "STOOL_COUNT," +
                                              "STOOL_COLOR," +
                                              "UMBILICALCORD," +
                                              "WEIGHT," +
                                              "RECORD_TIME," +
                                              "COLOUR_FACE,"+
                                              "BREATHE,"+
                                              "CRY,"+
                                              "REACTION,"+
                                              "DIAPER,"+
                                              "NUTRUE_OTHERNAME" +
                                              ") values(" +
                                              "'{0}'," +
                                              "'{1}'," +
                                              "'{2}'," +
                                              "'{3}'," +
                                              "'{4}'," +
                                              "'{5}'," +
                                              "'{6}'," +
                                              "to_TIMESTAMP('{7}','yyyy-MM-dd hh24:mi'),"+
                                               "'{8}'," +
                                               "'{9}'," +
                                               "'{10}'," +
                                               "'{11}'," +
                                               "'{12}',"+
                                               "'{13}'" +
                                               ")", tti.Child_id,
                                               tti.Feed_style,
                                               tti.Icterus,
                                               tti.Stool_count,
                                               tti.Stool_color,
                                               tti.Umbilicalcord,
                                               tti.Weight,
                                               tti.Record_time,
                                               tti.Color_face,
                                               tti.Breathe,
                                               tti.Cry,
                                               tti.Reaction,
                                               tti.Diaper,
                                               tti.Nature_0ther);
            listSql1.Add(sql2);
            try
            {

                App.ExecuteBatch(listSql.ToArray());
                App.ExecuteBatch(listSql1.ToArray());
            }
            catch (Exception)
            {
                return false;
            }
            listSql.Clear();
            return true;
        }


        public static bool SelectGreaterZero(string time, string child_id)
        {
            string sql = string.Format("SELECT count(id) FROM T_CHILD_VITAL_SIGNS WHERE to_char(measure_time,'yyyy-MM-dd') like  '{0}' AND CHILD_ID ='{1}' ", time, child_id);
            string sql2 = string.Format("SELECT count(id) FROM T_CHILD_TEMPERATURE_INFO WHERE to_char(record_time,'yyyy-MM-dd') like  '{0}' AND CHILD_ID ='{1}' ", time, child_id);

            if (Convert.ToInt32(App.GetDataSet(sql).Tables[0].Rows[0][0].ToString()) > 0
                || Convert.ToInt32(App.GetDataSet(sql2).Tables[0].Rows[0][0].ToString()) > 0)
                return false;
            else
                return true;

        }

        /// <summary>
        /// 清除今天的数据
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void IsClear(string time, string child_id)
        {
            string sql = string.Format("SELECT count(id) FROM T_CHILD_VITAL_SIGNS WHERE to_char(measure_time,'yyyy-MM-dd') like  '{0}' AND CHILD_ID ='{1}' ", time, child_id);
            string sql2 = string.Format("SELECT count(id) FROM T_CHILD_TEMPERATURE_INFO WHERE to_char(record_time,'yyyy-MM-dd') like  '{0}' AND CHILD_ID ='{1}' ", time, child_id);
            if (Convert.ToInt32(App.GetDataSet(sql).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql3 = string.Format("DELETE T_CHILD_VITAL_SIGNS WHERE to_char(measure_time,'yyyy-MM-dd') like  '{0}' AND CHILD_ID ='{1}'", time, child_id);
                App.ExecuteSQL(sql3);
            }

            if (Convert.ToInt32(App.GetDataSet(sql2).Tables[0].Rows[0][0].ToString()) > 0)
            {
                string sql4 = string.Format("DELETE T_CHILD_TEMPERATURE_INFO WHERE to_char(record_time,'yyyy-MM-dd') like '{0}' AND CHILD_ID ='{1}' ", time, child_id);
                App.ExecuteSQL(sql4);
            }
        }

        /// <summary>
        /// 查询体温信息
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static List<DataTable> GetTemper(string time, string child_id)
        {
            List<DataTable> list = new List<DataTable>();
            DataSet ds = new DataSet();
            string sql = string.Format("select CHILD_ID, " +
                                        "MEASURE_TIME, TEMPERATURE_VALUE, " +
                                        "RE_MEASURE, DESCRIBE,TEMP_STATE,COOLING_VALUE from T_CHILD_VITAL_SIGNS WHERE " +
                                        "to_char(measure_time,'yyyy-MM-dd') like '{0}' AND CHILD_ID ='{1}' ORDER BY MEASURE_TIME", time, child_id);

            string sql2 = string.Format("select CHILD_ID," +
                                        "FEED_STYLE, ICTERUS, STOOL_COUNT," +
                                        "STOOL_COLOR, UMBILICALCORD, WEIGHT," +
                                        "RECORD_TIME,COLOUR_FACE,BREATHE,CRY,REACTION,DIAPER,NUTRUE_OTHERNAME from T_CHILD_TEMPERATURE_INFO WHERE " +
                                        "to_char(record_time,'yyyy-MM-dd') like  '{0}' AND CHILD_ID ='{1}' ", time, child_id);


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
        public static List<DataTable> GetTempertureCount(string inTime, string startTime, string endTime, string child_id)
        {
            List<DataTable> list = new List<DataTable>();
            string sql1 = string.Format("select CHILD_ID, " +
                                        "MEASURE_TIME, TEMPERATURE_VALUE, " +
                                        "RE_MEASURE, DESCRIBE from T_CHILD_VITAL_SIGNS WHERE" +
                                        "WHERE MEASURE_TIME " +
                                        "BETWEEN to_date('{0}','yyyy-MM-dd') AND to_date('{1}','yyyy-MM-dd') AND pid = '{2}' ORDER BY MEASURE_TIME ", startTime, endTime, child_id);

            string sql2 = string.Format("select CHILD_ID," +
                                        "FEED_STYLE, ICTERUS, STOOL_COUNT," +
                                        "STOOL_COLOR, UMBILICALCORD, WEIGHT," +
                                        "RECORD_TIME from T_CHILD_TEMPERATURE_INFO WHERE  " +
                                        "WHERE RECORD_TIME BETWEEN to_date('{0}','yyyy-MM-dd') AND to_date('{1}','yyyy-MM-dd') AND pid = '{2}' ORDER BY record_time", startTime, endTime, child_id);

            string sql3 = string.Format("select measure_time from t_vital_signs " +
                                        "where  Describe like '%手术%' " +
                                        "and CHILD_ID ='{0}' " +
                                        "and MEASURE_TIME BETWEEN to_date('{1}','yyyy-MM-dd') AND to_date('{2}','yyyy-MM-dd') " +
                                        "ORDER BY MEASURE_TIME", child_id, DateTime.Parse(inTime).ToString("yyyy-MM-dd"), endTime);
            Class_Table[] table = new Class_Table[3];

            table[0] = new Class_Table();
            table[0].Sql = sql1;
            table[0].Tablename = "sql1";

            table[1] = new Class_Table();
            table[1].Sql = sql2;
            table[1].Tablename = "sql2";

            table[2] = new Class_Table();
            table[2].Sql = sql3;
            table[2].Tablename = "sql3";
            DataSet dssqls= App.GetDataSet(table);
            try
            {
                list.Add(dssqls.Tables["sql1"]);
                list.Add(dssqls.Tables["sql2"]);
                list.Add(dssqls.Tables["sql3"]);
            }
            catch (System.Exception ex)
            {
            	
            }
            
            return list;
        }
    }
}
