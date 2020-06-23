using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 危重患者护理记录信息
    /// </summary>
    public class Class_Nurse
    {
        private string date;

        private string  time;

        private string item_name;
   
        private string actual;

        private string urine;

        private string excrement;

        private string other;
  
        private string water_spreading;
  
        private string gross;
   
        private string temperature;
 
        private string pulse;
   
        private string breathe;
    
        private string blood_pressure;
 
        private string bp_saturation;
   
        private string pathograhy;
   
        private string signature;

        private string section;
     
        private string bed;

        private string pname;
      
        private string age;
     
        private string number;

        private string has_sum;

    
      

       
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
        /// 项目名称
        /// </summary>
        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }
        /// <summary>
        /// 实入量
        /// </summary>
        public string Actual
        {
            get { return actual; }
            set { actual = value; }
        }
        /// <summary>
        /// 尿
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
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
        /// 其他
        /// </summary>
        public string Other
        {
            get { return other; }
            set { other = value; }
        }
        /// <summary>
        /// 引流
        /// </summary>
        public string Water_spreading
        {
            get { return water_spreading; }
            set { water_spreading = value; }
        }
        /// <summary>
        /// 总量
        /// </summary>
        public string Gross
        {
            get { return gross; }
            set { gross = value; }
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
        /// 住院病历好
        /// </summary>
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        /// <summary>
        /// 是否汇总
        /// </summary>
        public string Has_sum
        {
            get { return has_sum; }
            set { has_sum = value; }
        }

    }
}
