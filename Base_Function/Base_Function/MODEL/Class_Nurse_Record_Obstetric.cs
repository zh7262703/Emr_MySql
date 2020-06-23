using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 产科护理记录
    /// </summary>
    class Class_Nurse_Record_Obstetric
    {
        private string dateTime;
        /// <summary>
        /// 日期时间
        /// </summary>
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        private string consciousness;
        /// <summary>
        /// 意识
        /// </summary>
        public string Consciousness
        {
            get { return consciousness; }
            set { consciousness = value; }
        }

        private string temperature;
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        private string pulse;
        /// <summary>
        /// 脉搏
        /// </summary>
        public string Pulse
        {
            get { return pulse; }
            set { pulse = value; }
        }

        private string breathe;
        /// <summary>
        /// 呼吸
        /// </summary>
        public string Breathe
        {
            get { return breathe; }
            set { breathe = value; }
        }

        private string blood_pressure;
        /// <summary>
        /// 血压
        /// </summary>
        public string Blood_pressure
        {
            get { return blood_pressure; }
            set { blood_pressure = value; }
        }

        private string bp_saturation;
        /// <summary>
        /// 氧饱和度
        /// </summary>
        public string Bp_saturation
        {
            get { return bp_saturation; }
            set { bp_saturation = value; }
        }

        private string in_item_name;
        /// <summary>
        /// 入量名称
        /// </summary>
        public string In_item_name
        {
            get { return in_item_name; }
            set { in_item_name = value; }
        }

        private string in_item_value;
        /// <summary>
        /// 入量值
        /// </summary>
        public string In_item_value
        {
            get { return in_item_value; }
            set { in_item_value = value; }
        }
         
        private string abnormalvaginalbleeding;
        /// <summary>
        /// 阴道流血
        /// </summary>
        public string Abnormalvaginalbleeding
        {
            get { return abnormalvaginalbleeding; }
            set { abnormalvaginalbleeding = value; }
        }


        private string urine;
        /// <summary>
        /// 尿液
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }

        private string out_otheritem_value;
        /// <summary>
        /// 其他出量值
        /// </summary>
        public string Out_otheritem_value
        {
            get { return out_otheritem_value; }
            set { out_otheritem_value = value; }
        }

        private string pipeline_name;
        /// <summary>
        /// 管道名称
        /// </summary>
        public string Pipeline_name
        {
            get { return pipeline_name; }
            set { pipeline_name = value; }
        }


        private string pipeline_value;
        /// <summary>
        /// 管道值
        /// </summary>
        public string Pipeline_value
        {
            get { return pipeline_value; }
            set { pipeline_value = value; }
        }


        private string fetal_heart_sound;
        /// <summary>
        /// 胎心音
        /// </summary>
        public string Fetal_heart_sound
        {
            get { return fetal_heart_sound; }
            set { fetal_heart_sound = value; }
        }

        private string rupture_membranes;
        /// <summary>
        /// 胎膜破裂
        /// </summary>
        public string Rupture_membranes
        {
            get { return rupture_membranes; }
            set { rupture_membranes = value; }
        }

        private string miyaguchi_kaio;
        /// <summary>
        /// 宫口大开
        /// </summary>
        public string Miyaguchi_kaio
        {
            get { return miyaguchi_kaio; }
            set { miyaguchi_kaio = value; }
        }

        private string uterine_contraction;
        /// <summary>
        /// 宫缩状况
        /// </summary>
        public string Uterine_contraction
        {
            get { return uterine_contraction; }
            set { uterine_contraction = value; }
        }

        private string fundus_height;
        /// <summary>
        /// 宫底高度脐下
        /// </summary>
        public string Fundus_height
        {
            get { return fundus_height; }
            set { fundus_height = value; }
        }

        private string blood_oozing;
        /// <summary>
        /// 渗血
        /// </summary>
        public string Blood_oozing
        {
            get { return blood_oozing; }
            set { blood_oozing = value; }
        }

        private string redandswollen;
        /// <summary>
        /// 红肿
        /// </summary>
        public string Redandswollen
        {
            get { return redandswollen; }
            set { redandswollen = value; }
        }

        private string anus_gas;
        /// <summary>
        /// 肛门排气
        /// </summary>
        public string Anus_gas
        {
            get { return anus_gas; }
            set { anus_gas = value; }
        }

        private string breast_feeding;
        /// <summary>
        /// 哺乳技巧
        /// </summary>
        public string Breast_feeding
        {
            get { return breast_feeding; }
            set { breast_feeding = value; }
        }    

        private string remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private string signature;
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature
        {
            get { return signature; }
            set { signature = value; }
        }

        private string number;
        /// <summary>
        /// 记录主键
        /// </summary>
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
