using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// Ѫ�Ǽ���
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
        /// Ѫ�Ǽ��ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// סԺ����ID
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public string Take_over_seq
        {
            get { return take_over_seq; }
            set { take_over_seq = value; }
        }
        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        public DateTime Record_time
        {
            get { return record_time; }
            set { record_time = value; }
        }
        /// <summary>
        /// ��¼��ID
        /// </summary>
        public string Record_id
        {
            get { return record_id; }
            set { record_id = value; }
        }
        /// <summary>
        /// ��¼������
        /// </summary>
        public string Record_name
        {
            get { return record_name; }
            set { record_name = value; }
        }
        /// <summary>
        /// ���ֵ
        /// </summary>
        public string Item_value
        {
            get { return item_value; }
            set { item_value = value; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string Item_type
        {
            get { return item_type; }
            set { item_type = value; }
        }

    }
}
