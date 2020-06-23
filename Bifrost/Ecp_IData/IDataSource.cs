using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bifrost.Ecp_IData
{
    /// <summary>
    /// 数据接口
    /// 创建者:卢星星
    /// 日期:2012-07-24
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// 获得当前科室,或者病区所有病人
        /// </summary>
        /// <returns></returns>
         DataSet GetPatients(int area_Id,string account_Type);
        /// <summary>
        /// 获得病人的诊断列表
        /// </summary>
        /// <param name="patient_Id"></param>
        /// <returns></returns>
         DataSet GetDiagnoses(string patient_Id);
        /// <summary>
        /// 获得病人的手术列表
        /// </summary>
        /// <param name="patient_Id"></param>
        /// <returns></returns>
         DataSet GetOperation(string patient_Id);
        /// <summary>
         /// 获得账号id和账号类别
        /// </summary>
        /// <param name="user_Number">用户名</param>
        /// <param name="pass_World">密码</param>
         /// <param name="account_Type">账号类型</param>
        /// <returns></returns>
        Class_Account GetAccountInfo(string user_Number, string pass_World, string account_Type);
        /// <summary>
        /// 初始化病人信息
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        InPatientInfo InitPatient(DataRow row);
        /// <summary>
        /// 获得账号id和账号类别
        /// </summary>
        /// <param name="user_Number">用户名</param>
        /// <param name="account_Type">账号类型</param>
        /// <returns></returns>
        Class_Account GetAccountInfoByBrowe(string user_Number, string section_id, string account_Type);

        DataSet GetAllSection();

        DataSet GetAllArea();
    }
}
