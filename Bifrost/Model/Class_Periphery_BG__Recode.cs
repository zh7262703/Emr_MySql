using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 血糖检测表
    /// </summary>
    public class Class_Periphery_BG__Recode
    {
        private int id;
    
        private string pid;
    
        private string take_over_seq;
    
        private DateTime record_time;
      
        private string record_id;
    
        private string record_name;
    
        private string item_value;
  
        private string item_type;

        /// <summary>
        /// 血糖检测ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 住院病人ID
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        /// <summary>
        /// 班次
        /// </summary>
        public string Take_over_seq
        {
            get { return take_over_seq; }
            set { take_over_seq = value; }
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime Record_time
        {
            get { return record_time; }
            set { record_time = value; }
        }
        /// <summary>
        /// 记录人ID
        /// </summary>
        public string Record_id
        {
            get { return record_id; }
            set { record_id = value; }
        }
        /// <summary>
        /// 记录人姓名
        /// </summary>
        public string Record_name
        {
            get { return record_name; }
            set { record_name = value; }
        }
        /// <summary>
        /// 结果值
        /// </summary>
        public string Item_value
        {
            get { return item_value; }
            set { item_value = value; }
        }
        /// <summary>
        /// 检测类型
        /// </summary>
        public string Item_type
        {
            get { return item_type; }
            set { item_type = value; }
        }

    }
}
