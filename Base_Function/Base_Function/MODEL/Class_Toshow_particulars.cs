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
        /// ������
        /// </summary>
        public string Pids
        {
            get { return pids; }
            set { pids = value; }
        }
       /// <summary>
       /// ������id
       /// </summary>
       public string Person_in_change_id
       {
           get { return person_in_change_id; }
           set { person_in_change_id = value; }
       }

        /// <summary>
        /// ������
        /// </summary>
        public string Person_in_change
        {
            get { return person_in_change; }
            set { person_in_change = value; }
        }
        /// <summary>
        /// �۷ֵ�
        /// </summary>
        public string Deduct_mark
        {
            get { return deduct_mark; }
            set { deduct_mark = value; }
        }
        /// <summary>
        /// �۷�����
        /// </summary>
        public string Deduct_mark_book
        {
            get { return deduct_mark_book; }
            set { deduct_mark_book = value; }
        }
        /// <summary>
        /// ��¼ʱ��
        /// </summary>
        public string Record_time
        {
            get { return record_time; }
            set { record_time = value; }
        }
       /// <summary>
       /// �۷�ֵ
       /// </summary>
        public string Deduct_mark_value
        {
            get { return deduct_mark_value; }
            set { deduct_mark_value = value; }
        }
    }
}
