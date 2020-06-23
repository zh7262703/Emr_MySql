using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{    
    /// <summary>
    /// 帐户表ACCOUNT
    /// 创建者：张华
    /// 创建时间：2010-6-15
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
        /// 用户编号
        /// </summary>
        public string Account_id
        {
            get { return account_id; }
            set { account_id = value; }
        }
        /// <summary>
        /// 用户类型:D-医生 N-护士 M-管理员 O-其他
        /// </summary>
        public string Account_type
        {
            get { return account_type; }
            set { account_type = value; }
        }
        /// <summary>
        ///用户姓名 
        /// </summary>
        public string Account_name
        {
            get { return account_name; }
            set { account_name = value; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// 有效标志：Y-有效 N-无效
        /// </summary>
        public string Enable
        {
            get { return enable; }
            set { enable = value; }
        }


        private int timeOut;

        /// <summary>
        /// 超时时间
        /// </summary>
        public int TimeOut
        {
            get { return timeOut; }
            set { timeOut = value; }
        }

        private string timeOut_Unit;
        /// <summary>
        /// 超时时间单位
        /// </summary>
        public string TimeOut_Unit
        {
            get { return timeOut_Unit; }
            set { timeOut_Unit = value; }
        }

        /// <summary>
        /// 有效期起始时间
        /// </summary>
        public DateTime Enable_start_time
        {
            get { return enable_start_time; }
            set { enable_start_time = value; }
        }
        /// <summary>
        /// 有效期截止时间
        /// </summary>
        public DateTime Enable_end_time
        {
            get { return enable_end_time; }
            set { enable_end_time = value; }
        }
        /// <summary>
        /// 最后登陆IP地址
        /// </summary>
        public string Last_login_ip
        {
            get { return last_login_ip; }
            set { last_login_ip = value; }
        }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime Last_login_time
        {
            get { return last_login_time; }
            set { last_login_time = value; }
        }
        /// <summary>
        /// 最后退出时间
        /// </summary>
        public DateTime Last_exit_time
        {
            get { return last_exit_time; }
            set { last_exit_time = value; }
        }

        /// <summary>
        /// 帐号想关联的用户信息
        /// </summary>
        public Class_User UserInfo
        {
            get { return userinfo; }
            set { userinfo=value; }
        }

        /// <summary>
        /// 帐号所关联的角色
        /// </summary>
        public Class_Role[] Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        /// <summary>
        /// 当前选中的权限
        /// </summary>
        public Class_Role CurrentSelectRole
        {
            get { return currentselectrole; }
            set { currentselectrole = value; }
        }

        /// <summary>
        /// 账户性质
        /// </summary>
        public int Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        /// <summary>
        /// 分院信息
        /// </summary>
        public int Hsid
        {
            get { return hsid; }
            set { hsid = value; }
        }

        /// <summary>
        /// 诊疗组ID
        /// </summary>
        public int Group_id
        {
            get { return group_id; }
            set { group_id = value; }
        }

        /// <summary>
        /// 诊疗组名称
        /// </summary>
        public string Group_name
        {
            get { return group_name; }
            set { group_name = value; }
        }
      
    }
}
