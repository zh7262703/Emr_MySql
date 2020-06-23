using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataOperater.Model;

namespace DataOperater.Iinterface
{
    /// <summary>
    /// MySql的相关操作
    /// 创建者：张华
    /// 创建时间：2020-6-23
    /// </summary>
    public interface IMySql
    {
        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name=CmdString></param>
        /// <param name=TableName></param>
        /// <returns></returns> 
        DataSet GetDataSet_MySql(string CmdString);

        /// <summary>
        /// 返回DataSet 多张表
        /// </summary>
        /// <param name=CmdString></param>
        /// <param name=TableName></param>
        /// <returns></returns>       
        DataSet GetDataSets_MySql(Class_Table[] tabsqls);

        /// <summary>
        /// 根据行号和列名返回值
        /// </summary>
        /// <param name="CmdString">SQl语句</param>
        /// <param name="rowindex">行号</param>
        /// <param name="colName">列名</param>
        /// <returns></returns>
        string ReadSqlVal_MySql(string CmdString, int rowindex, string colName);


        /// <summary>
        /// 返回影响数据库的行数
        /// </summary>
        /// <param name=CmdString></param>
        /// <returns></returns>
        int ExecuteSQL_MySql(string CmdString);

        /// <summary>
        /// 以带参数的形式执行操作
        /// </summary>
        /// <param name="CmdString">SQL语句</param>
        /// <param name="Parameters">参数集合</param>       
        /// <returns></returns>
        int ExecuteSQLWithParams_MySql(string CmdString, MySqlDBParameter[] paremts);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>     
        void RunProcedure_MySql(string storedProcName, MySqlDBParameter[] parameters);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名称</param>
        /// <param name="parameters">参数</param>        
        DataSet RunProcedureGetData_MySql(string storedProcName, MySqlDBParameter[] parameters);

        ///   <summary> 
        ///   批量执行Sql语句 
        ///   </summary> 
        ///   <param name= "BatchSql "> Sql语句数组 </param> 
        int ExecuteBatch_MySql(string[] BatchSql);

        /// <summary>
        /// 连接测试
        /// </summary>
        /// <returns></returns>
        bool ConnectTest_MySql();
    }
}
