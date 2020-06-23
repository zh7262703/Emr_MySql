using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 病人文书的签名
    /// </summary>
    public class Class_DocSign
    {
        private string _id;
        private string _userid;
        private string _username;      
        private string _u_tech_post;
        private string _u_tech_post_name;      
        private string _u_position;
        private string _u_position_name;      
        private DateTime _create_time;
        private string _patient_doc_id;
        private string _digtype;

       

        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
        /// <summary>
        /// 用户ID
        /// </summary>
        public string Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// 职称
        /// </summary>
        public string U_tech_post
        {
            get { return _u_tech_post; }
            set { _u_tech_post = value; }
        }

        /// <summary>
        /// 职称名称
        /// </summary>
        public string U_tech_post_name
        {
            get { return _u_tech_post_name; }
            set { _u_tech_post_name = value; }
        } 

       /// <summary>
       /// 职务
       /// </summary>
        public string U_position
        {
            get { return _u_position; }
            set { _u_position = value; }
        }

        /// <summary>
        /// 职务名称
        /// </summary>
        public string U_position_name
        {
            get { return _u_position_name; }
            set { _u_position_name = value; }
        }

        /// <summary>
        /// 签名时间
        /// </summary>
        public DateTime Create_time
        {
            get { return _create_time; }
            set { _create_time = value; }
        }

       /// <summary>
       /// 病人文书主键
       /// </summary>
        public string Patient_doc_id
        {
            get { return _patient_doc_id; }
            set { _patient_doc_id = value; }
        }

        /// <summary>
        /// 诊断类型
        /// </summary>
        public string Digtype
        {
            get { return _digtype; }
            set { _digtype = value; }
        }
    }
}
