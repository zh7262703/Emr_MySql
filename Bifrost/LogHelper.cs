using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// ��¼ϵͳ������־������
    /// ���ߣ�¬����
    /// ���ڣ�2011-03-03
    /// </summary>
    public class LogHelper
    {
        /// <summary>
        /// ��¼ϵͳ��־
        /// </summary>
        /// <param name="oper_Code">������</param>
        /// <param name="result">�������</param>
        /// <param name="content">��������</param>
        /// <param name="tid">����id</param>
        /// <param name="pid">����סԺ��id</param>
        ///  /// <param name="patient_Id">����id</param>
        public static int SystemLog(string content, string tid, string pid, int patient_Id)
        {
            /*
             * ����һ��ϵͳ������־
             */
            //����id
            string section_Id = App.UserAccount.CurrentSelectRole.Section_Id;
            //����id
            string area_Id = App.UserAccount.CurrentSelectRole.Sickarea_Id;
            //������ip��ַ
            string host_Ip = App.GetHostIp();
            //�����ߵ��˻�id
            string operator_Id = App.UserAccount.Account_id;

            //�û���ID
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
        /// �ʺ��춯��־
        /// </summary>
        /// <param name="accId">�춯�ʺ�ID</param>
        /// <param name="accType">�춯����</param>
        /// <param name="accInfo">�춯��Ϣ</param>
        /// <returns></returns>
        public static int Account_SystemLog(string accId,string accType,string accInfo)
        {
            //�����ߵ��˻�id
            string operator_Id = App.UserAccount.Account_id;
            //�û���ID
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
