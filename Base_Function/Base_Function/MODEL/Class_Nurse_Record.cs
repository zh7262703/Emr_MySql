using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    class Class_Nurse_Record
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

        private string pathography;
        /// <summary>
        /// 病情记录
        /// </summary>
        public string Pathography
        {
            get { return pathography; }
            set { pathography = value; }
        }
        
        private string nurseLevel;
        /// <summary>
        /// 护理级别
        /// </summary>
        public string NurseLevel
        {
            get { return nurseLevel; }
            set { nurseLevel = value; }
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

        private string heartRate;
        /// <summary>
        /// 心率
        /// </summary>
        public string HeartRate
        {
            get { return heartRate; }
            set { heartRate = value; }
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

        private string consciousness;
        /// <summary>
        /// 意识
        /// </summary>
        public string Consciousness
        {
            get { return consciousness; }
            set { consciousness = value; }
        }

        private string pupil_left;
        /// <summary>
        /// 瞳孔左
        /// </summary>
        public string Pupil_left
        {
            get { return pupil_left; }
            set { pupil_left = value; }
        }

        private string pupil_right;
        /// <summary>
        /// 瞳孔右
        /// </summary>
        public string Pupil_right
        {
            get { return pupil_right; }
            set { pupil_right = value; }
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

        private string shit;
        /// <summary>
        /// 大便
        /// </summary>
        public string Shit
        {
            get { return shit; }
            set { shit = value; }
        }

        private string urine;
        /// <summary>
        /// 小便
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }

        private string pipe1_Color;
        /// <summary>
        /// 管1颜色
        /// </summary>
        public string Pipe1_Color
        {
            get { return pipe1_Color; }
            set { pipe1_Color = value; }
        }

        private string pipe1_Value;
        /// <summary>
        /// 管1量
        /// </summary>
        public string Pipe1_Value
        {
            get { return pipe1_Value; }
            set { pipe1_Value = value; }
        }

        private string pipe2_Color;
        /// <summary>
        /// 管2颜色
        /// </summary>
        public string Pipe2_Color
        {
            get { return pipe2_Color; }
            set { pipe2_Color = value; }
        }

        private string pipe2_Value;
        /// <summary>
        /// 管2量
        /// </summary>
        public string Pipe2_Value
        {
            get { return pipe2_Value; }
            set { pipe2_Value = value; }
        }

        private string pipe3_Color;
        /// <summary>
        /// 管3颜色
        /// </summary>
        public string Pipe3_Color
        {
            get { return pipe3_Color; }
            set { pipe3_Color = value; }
        }

        private string pipe3_Value;
        /// <summary>
        /// 管3量
        /// </summary>
        public string Pipe3_Value
        {
            get { return pipe3_Value; }
            set { pipe3_Value = value; }
        }

        private string pipe4_Color;
        /// <summary>
        /// 管4颜色
        /// </summary>
        public string Pipe4_Color
        {
            get { return pipe4_Color; }
            set { pipe4_Color = value; }
        }

        private string pipe4_Value;
        /// <summary>
        /// 管4量
        /// </summary>
        public string Pipe4_Value
        {
            get { return pipe4_Value; }
            set { pipe4_Value = value; }
        }

        private string pipe5_Color;
        /// <summary>
        ///管5颜色 
        /// </summary>
        public string Pipe5_Color
        {
            get { return pipe5_Color; }
            set { pipe5_Color = value; }
        }

        private string pipe5_Value;
        /// <summary>
        /// 管5量
        /// </summary>
        public string Pipe5_Value
        {
            get { return pipe5_Value; }
            set { pipe5_Value = value; }
        }
        private string operation;
        /// <summary>
        /// 手术
        /// </summary>
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }
        private string specialCheck;
        /// <summary>
        /// 特检
        /// </summary>
        public string SpecialCheck
        {
            get { return specialCheck; }
            set { specialCheck = value; }
        }


        private string wound;
        /// <summary>
        /// 伤口
        /// </summary>
        public string Wound
        {
            get { return wound; }
            set { wound = value; }
        }

        private string skin;
        /// <summary>
        /// 皮肤
        /// </summary>
        public string Skin
        {
            get { return skin; }
            set { skin = value; }
        }

        private string xy;
        /// <summary>
        /// 吸氧
        /// </summary>
        public string Xy
        {
            get { return xy; }
            set { xy = value; }
        }

        private string ll;
        /// <summary>
        /// 流量
        /// </summary>
        public string Ll
        {
            get { return ll; }
            set { ll = value; }
        }

        private string safe_Nurse;
        /// <summary>
        /// 安全护理
        /// </summary>
        public string Safe_Nurse
        {
            get { return safe_Nurse; }
            set { safe_Nurse = value; }
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

        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        
    }
}
