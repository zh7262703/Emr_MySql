using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// Σ�ػ��߻����¼��Ϣ
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
        private string spirit;//����
        private string complexion;//��ɫ
        private string consciousness;//��ʶ
        private string diet;//��ʳ
        private string notch;//�пڷ���
        private string xy_mode;//������ʽ
        private string xy_flow_rate;//��������
        private string jw_physics;//������
        private string jw_medicament;//ҩ�ｵ��


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
        
        #region New add 2012-2-20 with Chenshichang.����



      
        #endregion


        /// <summary>
        /// ����
        /// </summary>
        public string  Date
        {
            get { return date; }
            set { date = value; }
        }
        /// <summary>
        /// ʱ��
        /// </summary>
        public string  Time
        {
            get { return time; }
            set { time = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Pulse
        {
            get { return pulse; }
            set { pulse = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Breathe
        {
            get { return breathe; }
            set { breathe = value; }
        }
        /// <summary>
        /// Ѫѹ
        /// </summary>
        public string Blood_pressure
        {
            get { return blood_pressure; }
            set { blood_pressure = value; }
        }
        /// <summary>
        /// Ѫ�����Ͷ�
        /// </summary>
        public string Bp_saturation
        {
            get { return bp_saturation; }
            set { bp_saturation = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string Spirit
        {
            get { return spirit; }
            set { spirit = value; }
        }


        /// <summary>
        /// ��ɫ
        /// </summary>
        public string Complexion
        {
            get { return complexion; }
            set { complexion = value; }
        }


        /// <summary>
        /// ��ʶ
        /// </summary>
        public string Consciousness
        {
            get { return consciousness; }
            set { consciousness = value; }
        }


        /// <summary>
        /// ��ʳ
        /// </summary>
        public string Diet
        {
            get { return diet; }
            set { diet = value; }
        }


        /// <summary>
        /// �пڷ���
        /// </summary>
        public string Notch
        {
            get { return notch; }
            set { notch = value; }
        }


        /// <summary>
        /// ������ʽ
        /// </summary>
        public string Xy_mode
        {
            get { return xy_mode; }
            set { xy_mode = value; }
        }



        /// <summary>
        /// ��������
        /// </summary>
        public string Xy_flow_rate
        {
            get { return xy_flow_rate; }
            set { xy_flow_rate = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string Jw_physics
        {
            get { return jw_physics; }
            set { jw_physics = value; }
        }



        /// <summary>
        /// ҩ�ｵ��
        /// </summary>
        public string Jw_medicament
        {
            get { return jw_medicament; }
            set { jw_medicament = value; }
        }
   
      

        /// <summary>
        /// ����ʳ������
        /// </summary>
        public string R_eat_item_name
        {
            get { return r_eat_item_name; }
            set { r_eat_item_name = value; }
        }
        /// <summary>
        /// ����ʳ����
        /// </summary>
        public string R_eat_item_count
        {
            get { return r_eat_item_count; }
            set { r_eat_item_count = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string C_item_name
        {
            get { return c_item_name; }
            set { c_item_name = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public string C_item_count
        {
            get { return c_item_count; }
            set { c_item_count = value; }
        }
      
        /// <summary>
        /// �����¼
        /// </summary>
        public string Pathograhy
        {
            get { return pathograhy; }
            set { pathograhy = value; }
        }
        /// <summary>
        /// ǩ��
        /// </summary>
        public string Signature
        {
            get { return signature; }
            set { signature = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Section
        {
            get { return section; }
            set { section = value; }
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
        /// HIS��������
        /// </summary>
        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        /// <summary>
        /// סԺ������
        /// </summary>
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public string Has_sum
        {
            get { return has_sum; }
            set { has_sum = value; }
        }


        /// <summary>
        /// ����ҩ������
        /// </summary>
        public string R_medicine_item_name
        {
            get { return r_medicine_item_name; }
            set { r_medicine_item_name = value; }
        }
        /// <summary>
        /// ����ҩ����
        /// </summary>
        public string R_medicine_item_count
        {
            get { return r_medicine_item_count; }
            set { r_medicine_item_count = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        /// <summary>
        /// Ѫ��
        /// </summary>
        public string Blood_sugar
        {
            get { return blood_sugar; }
            set { blood_sugar = value; }
        }

        /// <summary>
        /// ͫ����
        /// </summary>
        public string Pupil_left
        {
            get { return pupil_left; }
            set { pupil_left = value; }
        }
        /// <summary>
        /// ͫ����
        /// </summary>
        public string Pupil_right
        {
            get { return pupil_right; }
            set { pupil_right = value; }
        }
    }
}
