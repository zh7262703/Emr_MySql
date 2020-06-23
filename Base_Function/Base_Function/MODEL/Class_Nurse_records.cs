using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 危重患者护理记录信息
    /// </summary>
    public class Class_Nurse_records
    {
        private string date;

        private string time;

        private string r_item_name;

        private string r_item_count;      

        private string urine;         //尿

        private string shit;          //大便

        private string vomit;         //呕吐

        private string drainage;      //引流项目

        private string drainage_value;//引流量值
        
        private string c_other;       //出量其他
                
        private string temperature;

        private string pulse;

        private string breathe;

        private string blood_pressure;

        private string bp_saturation;

        private string pupil_left;
       
        private string pupil_right;
      
        private string idea;       
             
        private string pathograhy;
  
        private string signature;      

        private string section;
     
        private string bed;

        private string pname;
      
        private string age;             

        private string has_sum;

        private string number;
    
       
        /// <summary>
        /// 日期
        /// </summary>
        public string  Date
        {
            get { return date; }
            set { date = value; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public string  Time
        {
            get { return time; }
            set { time = value; }
        }


        /// <summary>
        /// 入量名称
        /// </summary>
        public string R_item_name
        {
            get { return r_item_name; }
            set { r_item_name = value; }
        }

        /// <summary>
        /// 入量值
        /// </summary>
        public string R_item_count
        {
            get { return r_item_count; }
            set { r_item_count = value; }
        }

        /// <summary>
        /// 尿量
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }

        /// <summary>
        /// 大便量
        /// </summary>
        public string Shit
        {
            get { return shit; }
            set { shit = value; }
        }

        /// <summary>
        /// 呕吐量
        /// </summary>
        public string Vomit
        {
            get { return vomit; }
            set { vomit = value; }
        }

        /// <summary>
        /// 引流项目
        /// </summary>
        public string Drainage
        {
            get { return drainage; }
            set { drainage = value; }
        }

        /// <summary>
        /// 引流值
        /// </summary>
        public string Drainage_Value
        {
            get { return drainage_value; }
            set { drainage_value = value; }
        }

       
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        /// <summary>
        /// 脉搏
        /// </summary>
        public string Pulse
        {
            get { return pulse; }
            set { pulse = value; }
        }
        /// <summary>
        /// 呼吸
        /// </summary>
        public string Breathe
        {
            get { return breathe; }
            set { breathe = value; }
        }
       

        /// <summary>
        /// 血压
        /// </summary>
        public string Blood_pressure
        {
            get { return blood_pressure; }
            set { blood_pressure = value; }
        }       

        /// <summary>
        /// 血养饱和度
        /// </summary>
        public string Bp_saturation
        {
            get { return bp_saturation; }
            set { bp_saturation = value; }
        }

        /// <summary>
        /// 瞳孔左
        /// </summary>
        public string Pupil_left
        {
            get { return pupil_left; }
            set { pupil_left = value; }
        }

        /// <summary>
        /// 瞳孔右
        /// </summary>
        public string Pupil_right
        {
            get { return pupil_right; }
            set { pupil_right = value; }
        }

        /// <summary>
        /// 神志意识
        /// </summary>
        public string Idea
        {
            get { return idea; }
            set { idea = value; }
        }
      
               
      
        /// <summary>
        /// 病情记录
        /// </summary>
        public string Pathograhy
        {
            get { return pathograhy; }
            set { pathograhy = value; }
        }
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature
        {
            get { return signature; }
            set { signature = value; }
        }

        /// <summary>
        /// 科室
        /// </summary>
        public string Section
        {
            get { return section; }
            set { section = value; }
        }

        /// <summary>
        /// 床号
        /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        /// <summary>
        /// HIS入区名称
        /// </summary>
        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
      
        /// <summary>
        /// 是否汇总
        /// </summary>
        public string Has_sum
        {
            get { return has_sum; }
            set { has_sum = value; }
        }

        /// <summary>
        /// 住院病历好
        /// </summary>
        public string Number
        {
            get { return number; }
            set { number = value; }
        }

        /// <summary>
        /// 出量其他
        /// </summary>
        public string C_other
        {
            get { return c_other; }
            set { c_other = value; }
        }

    }
}
