using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Bifrost.WebReference;
using Bifrost;

namespace Base_Function.BASE_COMMON
{
    public  class Caces_DBClass
    {
        /// <summary>
        /// 根据病人id得到该病人的病案首页信息
        /// </summary>
        /// <param name="Pid"></param>
        /// <returns></returns>
        public static DataSet GetDateSet(string Pid)
        {
            DataSet ds = null;
            //病案首页基本信息
            string SQL_COVER_INFO = "select * from COVER_INFO where inpatient_id ='" + Pid + "'";
            //病案首页院内情况表
            string SQL_COVER_INSTATUS = "select * from COVER_INSTATUS where inpatient_id ='" + Pid + "'";
            //病案首页手术情况表
            string SQL_COVER_OPERATION = "select * from COVER_OPERATION where inpatient_id ='" + Pid + "'";
            //病案首页诊断表
            string SQL_COVER_DIAGNOSE = "select * from COVER_DIAGNOSE where inpatient_id ='" + Pid + "'";//4
            //病案首页转科情况表
            string SQL_COVER_TRANSFER = "select * from COVER_TRANSFER where inpatient_id ='" + Pid + "'";
            Class_Table[] tabs = new Class_Table[5];
            tabs[0] = new Class_Table();
            tabs[0].Sql = SQL_COVER_INFO;
            tabs[0].Tablename = "COVER_INFO";

            tabs[1] = new Class_Table();
            tabs[1].Sql = SQL_COVER_INSTATUS;
            tabs[1].Tablename = "COVER_INSTATUS";

            tabs[2] = new Class_Table();
            tabs[2].Sql = SQL_COVER_OPERATION;
            tabs[2].Tablename = "COVER_OPERATION";

            tabs[3] = new Class_Table();
            tabs[3].Sql = SQL_COVER_DIAGNOSE;
            tabs[3].Tablename = "COVER_DIAGNOSE";

            tabs[4] = new Class_Table();
            tabs[4].Sql = SQL_COVER_TRANSFER;
            tabs[4].Tablename = "COVER_TRANSFER";
            ds = App.GetDataSet(tabs);
            return ds;
        }
    }
}
