using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{    
    /// <summary>
    /// �ʻ���ACCOUNT
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Account
    {       
        private string account_id;
      
        private string account_type;
  
        private string account_name;
  
        private string password;
 
        private string enable;

        private int kind;       

        private DateTime enable_start_time;

        private DateTime enable_end_time;
   
        private string last_login_ip;

        private DateTime last_login_time;

        private DateTime last_exit_time;

        private Class_User userinfo;

        private Class_Role[] roles;

        private Class_Role currentselectrole;

        private int hsid;

        private int group_id;

        private string group_name;

       
       
                
        /// <summary>
        /// �û����
        /// </summary>
        public string Account_id
        {
            get { return account_id; }
            set { account_id = value; }
        }
        /// <summary>
        /// �û�����:D-ҽ�� N-��ʿ M-����Ա O-����
        /// </summary>
        public string Account_type
        {
            get { return account_type; }
            set { account_type = value; }
        }
        /// <summary>
        ///�û����� 
        /// </summary>
        public string Account_name
        {
            get { return account_name; }
            set { account_name = value; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// ��Ч��־��Y-��Ч N-��Ч
        /// </summary>
        public string Enable
        {
            get { return enable; }
            set { enable = value; }
        }


        private int timeOut;

        /// <summary>
        /// ��ʱʱ��
        /// </summary>
        public int TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }

        private string timeOut_Unit;
        /// <summary>
        /// ��ʱʱ�䵥λ
        /// </summary>
        public string TimeOut_Unit
        {
            get { return timeOut_Unit; }
            set { timeOut_Unit = value; }
        }

        /// <summary>
        /// ��Ч����ʼʱ��
        /// </summary>
        public DateTime Enable_start_time
        {
            get { return enable_start_time; }
            set { enable_start_time = value; }
        }
        /// <summary>
        /// ��Ч�ڽ�ֹʱ��
        /// </summary>
        public DateTime Enable_end_time
        {
            get { return enable_end_time; }
            set { enable_end_time = value; }
        }
        /// <summary>
        /// ����½IP��ַ
        /// </summary>
        public string Last_login_ip
        {
            get { return last_login_ip; }
            set { last_login_ip = value; }
        }
        /// <summary>
        /// ����½ʱ��
        /// </summary>
        public DateTime Last_login_time
        {
            get { return last_login_time; }
            set { last_login_time = value; }
        }
        /// <summary>
        /// ����˳�ʱ��
        /// </summary>
        public DateTime Last_exit_time
        {
            get { return last_exit_time; }
            set { last_exit_time = value; }
        }

        /// <summary>
        /// �ʺ���������û���Ϣ
        /// </summary>
        public Class_User UserInfo
        {
            get { return userinfo; }
            set { userinfo=value; }
        }

        /// <summary>
        /// �ʺ��������Ľ�ɫ
        /// </summary>
        public Class_Role[] Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        /// <summary>
        /// ��ǰѡ�е�Ȩ��
        /// </summary>
        public Class_Role CurrentSelectRole
        {
            get { return currentselectrole; }
            set { currentselectrole = value; }
        }

        /// <summary>
        /// �˻�����
        /// </summary>
        public int Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        /// <summary>
        /// ��Ժ��Ϣ
        /// </summary>
        public int Hsid
        {
            get { return hsid; }
            set { hsid = value; }
        }

        /// <summary>
        /// ������ID
        /// </summary>
        public int Group_id
        {
            get { return group_id; }
            set { group_id = value; }
        }

        /// <summary>
        /// ����������
        /// </summary>
        public string Group_name
        {
            get { return group_name; }
            set { group_name = value; }
        }
      
    }
}
