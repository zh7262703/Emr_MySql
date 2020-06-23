using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 群录入体温单
    /// </summary>
    public class Class_Tempertureinfo
    {
        private string  bed;

        private string pidname;

        private string temperature_3am;

        private string pulse_3am;

        private string breathe_3am;

        private string temperature_7am;

        private string pulse_7am;

        private string breathe_7am;
   
        private string  temperature_11am;

        private string pulse_11am;

        private string breathe_11am;

        private string temperature_3pm;

        private string pulse_3pm;

        private string breathe_3pm;

        private string excrement;

        private string temperature_7pm;

        private string pulse_7pm;

        private string breathe_7pm;

        private string temperature_11pm;

        private string pulse_11pm;

        private string breathe_11pm;
  
        private string date;

        private string time;

        private string pids;

        private int   age;
      
        private string age_uint;
  
        private string gender_code;
      
        private string section_name;
       
        private string sick_area_name;
      
        private string in_time;

        private string patient_id;

        private string weight;
       
        private string length;

        private string urine;

     
        


     
        /// <summary>
        /// 床号
        /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        /// <summary>
        ///住院病人
        /// </summary>
        public string Pidname
        {
            get { return pidname; }
            set { pidname = value; }
        }
     
        /// <summary>
        /// 体温3am
        /// </summary>
        public string Temperature_3am
        {
            get { return temperature_3am; }
            set { temperature_3am = value; }
        }
        /// <summary>
        /// 脉搏3am
        /// </summary>
        public string Pulse_3am
        {
            get { return pulse_3am; }
            set { pulse_3am = value; }
        }
        /// <summary>
        /// 呼吸3am
        /// </summary>
        public string Breathe_3am
        {
            get { return breathe_3am; }
            set { breathe_3am = value; }
        }
        /// <summary>
        /// 体温7am
        /// </summary>
        public string Temperature_7am
        {
            get { return temperature_7am; }
            set { temperature_7am = value; }
        }
        /// <summary>
        /// 脉搏7am
        /// </summary>
        public string Pulse_7am
        {
            get { return pulse_7am; }
            set { pulse_7am = value; }
        }
        /// <summary>
        /// 呼吸7am
        /// </summary>
        public string Breathe_7am
        {
            get { return breathe_7am; }
            set { breathe_7am = value; }
        }
        /// <summary>
        /// 体温_11am
        /// </summary>
        public string Temperature_11am
        {
            get { return temperature_11am; }
            set { temperature_11am = value; }
        }
        /// <summary>
        ///  脉搏_11am
        /// </summary>
        public string Pulse_11am
        {
            get { return pulse_11am; }
            set { pulse_11am = value; }
        }
    
        /// <summary>
        /// 呼吸_11am
        /// </summary>
        public string Breathe_11am
        {
            get { return breathe_11am; }
            set { breathe_11am = value; }
        }
        /// <summary>
        /// 体温3pm
        /// </summary>
        public string Temperature_3pm
        {
            get { return temperature_3pm; }
            set { temperature_3pm = value; }
        }
        /// <summary>
        /// 脉搏3pm
        /// </summary>
        public string Pulse_3pm
        {
            get { return pulse_3pm; }
            set { pulse_3pm = value; }
        }
        /// <summary>
        /// 呼吸3pm
        /// </summary>
        public string Breathe_3pm
        {
            get { return breathe_3pm; }
            set { breathe_3pm = value; }
        }
        /// <summary>
        /// 大便
        /// </summary>
        public string Excrement
        {
            get { return excrement; }
            set { excrement = value; }
        }
        /// <summary>
        /// 体温7pm
        /// </summary>
        public string Temperature_7pm
        {
            get { return temperature_7pm; }
            set { temperature_7pm = value; }
        }
        /// <summary>
        /// 脉搏7pm
        /// </summary>
        public string Pulse_7pm
        {
            get { return pulse_7pm; }
            set { pulse_7pm = value; }
        }
        /// <summary>
        /// 呼吸7pm
        /// </summary>
        public string Breathe_7pm
        {
            get { return breathe_7pm; }
            set { breathe_7pm = value; }
        }
        /// <summary>
        /// 体温11pm
        /// </summary>
        public string Temperature_11pm
        {
            get { return temperature_11pm; }
            set { temperature_11pm = value; }
        }
        /// <summary>
        /// 脉搏11pm
        /// </summary>
        public string Pulse_11pm
        {
            get { return pulse_11pm; }
            set { pulse_11pm = value; }
        }
        /// <summary>
        /// 呼吸11pm
        /// </summary>
        public string Breathe_11pm
        {
            get { return breathe_11pm; }
            set { breathe_11pm = value; }
        }
        /// <summary>
        /// 获取病人住院号
        /// </summary>
        public string Pids
        {
            get { return pids; }
            set { pids = value; }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public  int   Age
        {
            get { return age; }
            set { age = value; }
        }
        /// <summary>
        /// 年龄单位
        /// </summary>
        public string Age_uint
        {
            get { return age_uint; }
            set { age_uint = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender_code
        {
            get { return gender_code; }
            set { gender_code = value; }
        }

        /// <summary>
        /// 科室名称
        /// </summary>
        public string Section_name
        {
            get { return section_name; }
            set { section_name = value; }
        }
        /// <summary>
        /// 病区名称
        /// </summary>
        public string Sick_area_name
        {
            get { return sick_area_name; }
            set { sick_area_name = value; }
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
        /// 病人主键
        /// </summary>
        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }


        public string Length
        {
            get { return length; }
            set { length = value; }
        }

        /// <summary>
        /// 小便
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }
    
    }
}
