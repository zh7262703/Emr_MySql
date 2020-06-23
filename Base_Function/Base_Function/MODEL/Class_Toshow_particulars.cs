using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
   public class Class_Toshow_particulars
    {
        private string pids;

        private string person_in_change_id;

        private string person_in_change;
  
        private string deduct_mark;
    
        private string deduct_mark_book;

        private string record_time;
 
        private string deduct_mark_value;


        /// <summary>
        /// 病案号
        /// </summary>
        public string Pids
        {
            get { return pids; }
            set { pids = value; }
        }
       /// <summary>
       /// 责任人id
       /// </summary>
       public string Person_in_change_id
       {
           get { return person_in_change_id; }
           set { person_in_change_id = value; }
       }

        /// <summary>
        /// 责任人
        /// </summary>
        public string Person_in_change
        {
            get { return person_in_change; }
            set { person_in_change = value; }
        }
        /// <summary>
        /// 扣分点
        /// </summary>
        public string Deduct_mark
        {
            get { return deduct_mark; }
            set { deduct_mark = value; }
        }
        /// <summary>
        /// 扣分文书
        /// </summary>
        public string Deduct_mark_book
        {
            get { return deduct_mark_book; }
            set { deduct_mark_book = value; }
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public string Record_time
        {
            get { return record_time; }
            set { record_time = value; }
        }
       /// <summary>
       /// 扣分值
       /// </summary>
        public string Deduct_mark_value
        {
            get { return deduct_mark_value; }
            set { deduct_mark_value = value; }
        }
    }
}
