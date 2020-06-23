using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 记录系统操作日志帮助类
    /// 作者：卢星星
    /// 日期：2011-03-03
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// 记录系统日志
        /// </summary>
        /// <param name="oper_Code">操作码</param>
        /// <param name="result">操作结果</param>
        /// <param name="content">附加内容</param>
        /// <param name="tid">文书id</param>
        /// <param name="pid">病人住院号id</param>
        ///  /// <param name="patient_Id">病人id</param>
        public static int SystemLog(string content, string tid, string pid, int patient_Id)
        {
            /*
             * 新增一条系统操作日志
             */
            //科室id
            string section_Id = App.UserAccount.CurrentSelectRole.Section_Id;
            //病区id
            string area_Id = App.UserAccount.CurrentSelectRole.Sickarea_Id;
            //本机的ip地址
            string host_Ip = App.GetHostIp();
            //操作者的账户id
            string operator_Id = App.UserAccount.Account_id;

            //用户的ID
            string operator_user_Id = App.UserAccount.UserInfo.User_id;
            string Insert_Operate_Log = "insert into t_operate_log (operator_id,section_id,sickarea_id,oper_time,ip_address,content,tid,pid,patient_Id,OPERATOR_USER_ID)" +
                                        "values('" + operator_Id + "','" + section_Id + "','" + area_Id + "',sysdate,'" + host_Ip + "','" + content + "','" + tid + "','" + pid + "'," + patient_Id + "," + operator_user_Id + ")";
            int count = 0;
            try
            {
                count = App.ExecuteSQL(Insert_Operate_Log);
            }
            catch (Exception)
            {
            }
            return count;
        }
        /// <summary>
        /// 帐号异动日志
        /// </summary>
        /// <param name="accId">异动帐号ID</param>
        /// <param name="accType">异动类型</param>
        /// <param name="accInfo">异动信息</param>
        /// <returns></returns>
        public static int Account_SystemLog(string accId,string accType,string accInfo)
        {
            //操作者的账户id
            string operator_Id = App.UserAccount.Account_id;
            //用户的ID
            string operator_user_Id = App.UserAccount.UserInfo.User_id;

            string insert_account_action = "insert into t_account_action(account_id, action_type, action_time, action_info, operater_account_id, operater_id) values( " +
                accId + ", '" + accType + "', sysdate, '" + accInfo + "', " + operator_Id + ", " + operator_user_Id + ")";
            int count = 0;
            try
            {
                count = App.ExecuteSQL(insert_account_action);
            }
            catch (Exception ex)
            {

            }
            return count;
        }
    }

}
