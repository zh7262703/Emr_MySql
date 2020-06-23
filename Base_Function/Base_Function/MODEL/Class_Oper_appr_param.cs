using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
     public  class Class_Oper_appr_param
    {
        private string id;
       
        private string is_auto;
   
        private string limit_doclist;

        private DateTime record_time;
      
        private string record_by_id;
       
        private string recordby_name;
        /// <summary>
        ///id
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        ///  手术审批是否需要系统自动判断:Y N
        /// </summary>
        public string Is_auto
        {
            get { return is_auto; }
            set { is_auto = value; }
        }
        /// <summary>
        /// 未通过审批的手术禁止书写的文书
        /// </summary>
        public string Limit_doclist
        {
            get { return limit_doclist; }
            set { limit_doclist = value; }
        }
        /// <summary>
        /// 记录日期
        /// </summary>
        public DateTime Record_time
        {
            get { return record_time; }
            set { record_time = value; }
        }
        /// <summary>
        /// 记录人ID
        /// </summary>
        public string Record_by_id
        {
            get { return record_by_id; }
            set { record_by_id = value; }
        }
         /// <summary>
        /// 记录人姓名
         /// </summary>
        public string Recordby_name
        {
            get { return recordby_name; }
            set { recordby_name = value; }
        }
    }
}
