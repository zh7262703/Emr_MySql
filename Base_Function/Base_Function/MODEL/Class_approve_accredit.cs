using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    public class Class_approve_accredit
    {
        private string id;
    
        private string sid;
      
        private string userid;
      
        private string type;
    
        private string aid;
        /// <summary>
        /// 授权id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 科室id
        /// </summary>
        public string Sid
        {
            get { return sid; }
            set { sid = value; }
        }
        /// <summary>
        /// 科室人id
        /// </summary>
        public string Userid
        {
            get { return userid; }
            set { userid = value; }
        }
        /// <summary>
        /// 类型
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// 登陆用户id
        /// </summary>
        public string Aid
        {
            get { return aid; }
            set { aid = value; }
        }

    }
}
