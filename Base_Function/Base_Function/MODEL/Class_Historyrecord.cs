using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
   public class Class_Historyrecord
    {
        private string sick_id;
  
        private string sick_name;

        private string section_id;
 
        private string section_name;
   
        private string bed;
    
        private string patient_name;
  
        private string pids;

        private string in_time;

        private string id;


        /// <summary>
        /// ����id
        /// </summary>
        public string Sick_id
        {
            get { return sick_id; }
            set { sick_id = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Sick_name
        {
            get { return sick_name; }
            set { sick_name = value; }
        }
        /// <summary>
        /// ����id
        /// </summary>
        public string Section_id
        {
            get { return section_id; }
            set { section_id = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Section_name
        {
            get { return section_name; }
            set { section_name = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Patient_name
        {
            get { return patient_name; }
            set { patient_name = value; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Pids
        {
            get { return pids; }
            set { pids = value; }
        }
       /// <summary>
       /// ��Ժʱ��
       /// </summary>
        public string In_time
        {
            get { return in_time; }
            set { in_time = value; }
        }
       /// <summary>
       /// ���
       /// </summary>
       public string Id
       {
           get { return id; }
           set { id = value; }
       }

    }
}
