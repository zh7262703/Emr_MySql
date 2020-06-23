using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 危重患者护理记录信息
    /// </summary>
    public class Class_Nurse_record_observe
    {
        private string date;

        private string  time;

        private string temperature;

        private string pulse;

        private string breathe;

        private string blood_pressure;

        private string bp_saturation;
        private string spirit;//精神
        private string complexion;//面色
        private string consciousness;//意识
        private string diet;//饮食
        private string notch;//切口敷料
        private string xy_mode;//吸氧方式
        private string xy_flow_rate;//吸氧流量
        private string jw_physics;//物理降温
        private string jw_medicament;//药物降温


        private string r_eat_item_name;
   
        private string r_eat_item_count;

        private string c_item_name;
 
        private string c_item_count;

        private string pathograhy;
  
        private string signature;

        private string section;
     
        private string bed;

        private string pname;
      
        private string age;
     
        private string number;

        private string has_sum;
        private string weight;

        private string blood_sugar;
        private string pupil_left;

        private string pupil_right;
        private string r_medicine_item_name;

        private string r_medicine_item_count;
        
        #region New add 2012-2-20 with Chenshichang.属性



      
        #endregion


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
        /// 精神
        /// </summary>
        public string Spirit
        {
            get { return spirit; }
            set { spirit = value; }
        }


        /// <summary>
        /// 面色
        /// </summary>
        public string Complexion
        {
            get { return complexion; }
            set { complexion = value; }
        }


        /// <summary>
        /// 意识
        /// </summary>
        public string Consciousness
        {
            get { return consciousness; }
            set { consciousness = value; }
        }


        /// <summary>
        /// 饮食
        /// </summary>
        public string Diet
        {
            get { return diet; }
            set { diet = value; }
        }


        /// <summary>
        /// 切口敷料
        /// </summary>
        public string Notch
        {
            get { return notch; }
            set { notch = value; }
        }


        /// <summary>
        /// 吸氧方式
        /// </summary>
        public string Xy_mode
        {
            get { return xy_mode; }
            set { xy_mode = value; }
        }



        /// <summary>
        /// 吸氧流量
        /// </summary>
        public string Xy_flow_rate
        {
            get { return xy_flow_rate; }
            set { xy_flow_rate = value; }
        }

        /// <summary>
        /// 物理降温
        /// </summary>
        public string Jw_physics
        {
            get { return jw_physics; }
            set { jw_physics = value; }
        }



        /// <summary>
        /// 药物降温
        /// </summary>
        public string Jw_medicament
        {
            get { return jw_medicament; }
            set { jw_medicament = value; }
        }
   
      

        /// <summary>
        /// 入量食物名称
        /// </summary>
        public string R_eat_item_name
        {
            get { return r_eat_item_name; }
            set { r_eat_item_name = value; }
        }
        /// <summary>
        /// 入量食物量
        /// </summary>
        public string R_eat_item_count
        {
            get { return r_eat_item_count; }
            set { r_eat_item_count = value; }
        }
        /// <summary>
        /// 出量名称
        /// </summary>
        public string C_item_name
        {
            get { return c_item_name; }
            set { c_item_name = value; }
        }

        /// <summary>
        /// 出量量
        /// </summary>
        public string C_item_count
        {
            get { return c_item_count; }
            set { c_item_count = value; }
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


        /// <summary>
        /// 入量药物名称
        /// </summary>
        public string R_medicine_item_name
        {
            get { return r_medicine_item_name; }
            set { r_medicine_item_name = value; }
        }
        /// <summary>
        /// 入量药物量
        /// </summary>
        public string R_medicine_item_count
        {
            get { return r_medicine_item_count; }
            set { r_medicine_item_count = value; }
        }
        /// <summary>
        /// 体重
        /// </summary>
        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        /// <summary>
        /// 血糖
        /// </summary>
        public string Blood_sugar
        {
            get { return blood_sugar; }
            set { blood_sugar = value; }
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
    }
}
