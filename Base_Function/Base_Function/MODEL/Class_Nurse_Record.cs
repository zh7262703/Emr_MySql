using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    class Class_Nurse_Record
    {
        private string dateTime;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string DateTime
        {
            get { return dateTime; }
            set { dateTime = value; }
        }

        private string pathography;
        /// <summary>
        /// �����¼
        /// </summary>
        public string Pathography
        {
            get { return pathography; }
            set { pathography = value; }
        }
        
        private string nurseLevel;
        /// <summary>
        /// ������
        /// </summary>
        public string NurseLevel
        {
            get { return nurseLevel; }
            set { nurseLevel = value; }
        }

        private string temperature;
        /// <summary>
        /// ����
        /// </summary>
        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        private string pulse;
        /// <summary>
        /// ����
        /// </summary>
        public string Pulse
        {
            get { return pulse; }
            set { pulse = value; }
        }

        private string heartRate;
        /// <summary>
        /// ����
        /// </summary>
        public string HeartRate
        {
            get { return heartRate; }
            set { heartRate = value; }
        }

        private string breathe;
        /// <summary>
        /// ����
        /// </summary>
        public string Breathe
        {
            get { return breathe; }
            set { breathe = value; }
        }

        private string blood_pressure;
        /// <summary>
        /// Ѫѹ
        /// </summary>
        public string Blood_pressure
        {
            get { return blood_pressure; }
            set { blood_pressure = value; }
        }

        private string consciousness;
        /// <summary>
        /// ��ʶ
        /// </summary>
        public string Consciousness
        {
            get { return consciousness; }
            set { consciousness = value; }
        }

        private string pupil_left;
        /// <summary>
        /// ͫ����
        /// </summary>
        public string Pupil_left
        {
            get { return pupil_left; }
            set { pupil_left = value; }
        }

        private string pupil_right;
        /// <summary>
        /// ͫ����
        /// </summary>
        public string Pupil_right
        {
            get { return pupil_right; }
            set { pupil_right = value; }
        }

        private string bp_saturation;
        /// <summary>
        /// �����Ͷ�
        /// </summary>
        public string Bp_saturation
        {
            get { return bp_saturation; }
            set { bp_saturation = value; }
        }


        private string in_item_name;
        /// <summary>
        /// ��������
        /// </summary>
        public string In_item_name
        {
            get { return in_item_name; }
            set { in_item_name = value; }
        }

        private string in_item_value;
        /// <summary>
        /// ����ֵ
        /// </summary>
        public string In_item_value
        {
            get { return in_item_value; }
            set { in_item_value = value; }
        }

        private string shit;
        /// <summary>
        /// ���
        /// </summary>
        public string Shit
        {
            get { return shit; }
            set { shit = value; }
        }

        private string urine;
        /// <summary>
        /// С��
        /// </summary>
        public string Urine
        {
            get { return urine; }
            set { urine = value; }
        }

        private string pipe1_Color;
        /// <summary>
        /// ��1��ɫ
        /// </summary>
        public string Pipe1_Color
        {
            get { return pipe1_Color; }
            set { pipe1_Color = value; }
        }

        private string pipe1_Value;
        /// <summary>
        /// ��1��
        /// </summary>
        public string Pipe1_Value
        {
            get { return pipe1_Value; }
            set { pipe1_Value = value; }
        }

        private string pipe2_Color;
        /// <summary>
        /// ��2��ɫ
        /// </summary>
        public string Pipe2_Color
        {
            get { return pipe2_Color; }
            set { pipe2_Color = value; }
        }

        private string pipe2_Value;
        /// <summary>
        /// ��2��
        /// </summary>
        public string Pipe2_Value
        {
            get { return pipe2_Value; }
            set { pipe2_Value = value; }
        }

        private string pipe3_Color;
        /// <summary>
        /// ��3��ɫ
        /// </summary>
        public string Pipe3_Color
        {
            get { return pipe3_Color; }
            set { pipe3_Color = value; }
        }

        private string pipe3_Value;
        /// <summary>
        /// ��3��
        /// </summary>
        public string Pipe3_Value
        {
            get { return pipe3_Value; }
            set { pipe3_Value = value; }
        }

        private string pipe4_Color;
        /// <summary>
        /// ��4��ɫ
        /// </summary>
        public string Pipe4_Color
        {
            get { return pipe4_Color; }
            set { pipe4_Color = value; }
        }

        private string pipe4_Value;
        /// <summary>
        /// ��4��
        /// </summary>
        public string Pipe4_Value
        {
            get { return pipe4_Value; }
            set { pipe4_Value = value; }
        }

        private string pipe5_Color;
        /// <summary>
        ///��5��ɫ 
        /// </summary>
        public string Pipe5_Color
        {
            get { return pipe5_Color; }
            set { pipe5_Color = value; }
        }

        private string pipe5_Value;
        /// <summary>
        /// ��5��
        /// </summary>
        public string Pipe5_Value
        {
            get { return pipe5_Value; }
            set { pipe5_Value = value; }
        }
        private string operation;
        /// <summary>
        /// ����
        /// </summary>
        public string Operation
        {
            get { return operation; }
            set { operation = value; }
        }
        private string specialCheck;
        /// <summary>
        /// �ؼ�
        /// </summary>
        public string SpecialCheck
        {
            get { return specialCheck; }
            set { specialCheck = value; }
        }


        private string wound;
        /// <summary>
        /// �˿�
        /// </summary>
        public string Wound
        {
            get { return wound; }
            set { wound = value; }
        }

        private string skin;
        /// <summary>
        /// Ƥ��
        /// </summary>
        public string Skin
        {
            get { return skin; }
            set { skin = value; }
        }

        private string xy;
        /// <summary>
        /// ����
        /// </summary>
        public string Xy
        {
            get { return xy; }
            set { xy = value; }
        }

        private string ll;
        /// <summary>
        /// ����
        /// </summary>
        public string Ll
        {
            get { return ll; }
            set { ll = value; }
        }

        private string safe_Nurse;
        /// <summary>
        /// ��ȫ����
        /// </summary>
        public string Safe_Nurse
        {
            get { return safe_Nurse; }
            set { safe_Nurse = value; }
        }


        private string remark;
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private string signature;
        /// <summary>
        /// ǩ��
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
