using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
     public class Class_ucBlood_SugarRecord
    {
        private string bed;
       
        private string pid_name;
        private string value_val;
    
        private string values_7;
  
        private string values_9;
     
        private string values_11;
       
        private string values_14;
   
        private string values_17;
      
        private string values_20;

        private string values_22;

        private string values_00;
   
        private string values_03;

        private string pid;

        private string section_name;

        private string sickarea_name;

        private string in_time;

     
        private string date;
        private string time;
        private string patient_id;

        private string bz;
         private string create_name;


       

        /// <summary>
        /// 床号
        /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Pid_name
        {
            get { return pid_name; }
            set { pid_name = value; }
        }
         /// <summary>
         /// 血糖值
         /// </summary>
         public string Value_val
         {
             get { return value_val; }
             set { value_val = value; }
         }
        /// <summary>
        /// 血糖07:00
        /// </summary>
        public string Values_7
        {
            get { return values_7; }
            set { values_7 = value; }
        }
        /// <summary>
        /// 血糖09:00
        /// </summary>
        public string Values_9
        {
            get { return values_9; }
            set { values_9 = value; }
        }
        /// <summary>
        /// 血糖11:00
        /// </summary>
        public string Values_11
        {
            get { return values_11; }
            set { values_11 = value; }
        }
        /// <summary>
        /// 血糖14:00
        /// </summary>
        public string Values_14
        {
            get { return values_14; }
            set { values_14 = value; }
        }

        /// <summary>
        /// 血糖15:00
        /// </summary>
        public string Values_17
        {
            get { return values_17; }
            set { values_17 = value; }
        }
        /// <summary>
        /// 血糖20:00
        /// </summary>
        public string Values_20
        {
            get { return values_20; }
            set { values_20 = value; }
        }
        /// <summary>
        /// 血糖22:00
        /// </summary>
        public string Values_22
        {
            get { return values_22; }
            set { values_22 = value; }
        }
        /// <summary>
        /// 血糖00:00
        /// </summary>
        public string Values_00
        {
            get { return values_00; }
            set { values_00 = value; }
        }
        /// <summary>
        /// 血糖03:00
        /// </summary>
        public string Values_03
        {
            get { return values_03; }
            set { values_03 = value; }
        }
        /// <summary>
        /// 病人pid
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        /// <summary>
        /// 所属科室
        /// </summary>
         public string Section_name
         {
             get { return section_name; }
             set { section_name = value; }
         }
         /// <summary>
         /// 所属病区
         /// </summary>
         public string Sickarea_name
        {
            get { return sickarea_name; }
            set { sickarea_name = value; }
        }
        /// <summary>
        /// 入院时间
        /// </summary>
        public string In_time
        {
            get { return in_time; }
            set { in_time = value; }
        }
         /// <summary>
         /// 日期
         /// </summary>
         public string Date
         {
             get { return date; }
             set { date = value; }
         }
         ///时间
         public string Time
         {
             get { return time; }
             set { time = value; }
         }
         /// <summary>
         /// 病人编号
         /// </summary>
         public string Patient_id
         {
             get { return patient_id; }
             set { patient_id = value; }
         }
         /// <summary>
         /// 备注
         /// </summary>
         public string BZ
         {
             get { return bz; }
             set { bz = value; }
         }
         /// <summary>
         /// 创建人
         /// </summary>
         public string Create_Name
         {
             get { return create_name; }
             set { create_name = value; }
         }

    }
}
