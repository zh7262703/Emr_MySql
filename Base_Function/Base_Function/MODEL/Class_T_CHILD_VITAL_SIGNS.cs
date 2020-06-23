using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// ��¼Ӥ����������
    /// </summary>
     public class Class_T_CHILD_VITAL_SIGNS
    {
         private string id;

         private string temp_state;

         public string Temp_state
         {
             get { return temp_state; }
             set { temp_state = value; }
         }
         private string child_id;

         public string Child_id
         {
             get { return child_id; }
             set { child_id = value; }
         }

         public string ID
         {
             get { return id; }
             set { id = value; }
         }
         
         private string bed_no;
        /// <summary>
        /// ����
        /// </summary>
        public string Bed_no
        {
            get { return bed_no; }
            set { bed_no = value; }
        }
        private string pid;

        /// <summary>
        /// ���˱��
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        private string measure_time;
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string Measure_time
        {
            get { return measure_time; }
            set { measure_time = value; }
        }
        private float temperature_value;
        /// <summary>
        /// ���²���ֵ
        /// </summary>
        public float Temperature_value
        {
            get { return temperature_value; }
            set { temperature_value = value; }
        }
        private string temperature_body;
        /// <summary>
        /// ���²�����λ
        /// </summary>
        public string Temperature_body
        {
            get { return temperature_body; }
            set { temperature_body = value; }
        }

        private string re_measure;
        /// <summary>
        /// �����־
        /// </summary>
        public string Re_measure
        {
            get { return re_measure; }
            set { re_measure = value; }
        }
        private float cooling_value;
        /// <summary>
        /// ���º��¶�
        /// </summary>
        public float Cooling_value
        {
            get { return cooling_value; }
            set { cooling_value = value; }
        }

        private string cooling_type;
        /// <summary>
        /// ���´�ʩ
        /// </summary>
        public string Cooling_type
        {
            get { return cooling_type; }
            set { cooling_type = value; }
        }

        private int pulse_value;
        /// <summary>
        /// ��������ֵ
        /// </summary>
        public int Pulse_value
        {
            get { return pulse_value; }
            set { pulse_value = value; }
        }
        private string is_briefness;
        /// <summary>
        /// �������
        /// </summary>
        public string Is_briefness
        {
            get { return is_briefness; }
            set { is_briefness = value; }
        }

        private int heart_rhythm;
        /// <summary>
        /// ���ʲ���ֵ
        /// </summary>
        public int Heart_rhythm
        {
            get { return heart_rhythm; }
            set { heart_rhythm = value; }
        }
        private string is_assist_hr;
        /// <summary>
        ///������е������־
        /// </summary>
        public string Is_assist_hr
        {
            get { return is_assist_hr; }
            set { is_assist_hr = value; }
        }
        private int breath_value;
        /// <summary>
        /// ��������ֵ
        /// </summary>
        public int Breath_value
        {
            get { return breath_value; }
            set { breath_value = value; }
        }
        private string is_assist_br;
        /// <summary>
        /// ������е������־
        /// </summary>
        public string Is_assist_br
        {
            get { return is_assist_br; }
            set { is_assist_br = value; }
        }
        private string measure_state;
        /// <summary>
        /// ����״̬
        /// </summary>
        public string Measure_state
        {
            get { return measure_state; }
            set { measure_state = value; }
        }
        private string describe;
        /// <summary>
        /// �¼�����
        /// </summary>
        public string Describe
        {
            get { return describe; }
            set { describe = value; }
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


        private string operater_before_time;
        /// <summary>
        /// ��ǰʱ��
        /// </summary>
        public string Operater_before_time
        {
            get { return operater_before_time; }
            set { operater_before_time = value; }
        }

        private string operater_after_time;

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string Operater_after_time
        {
            get { return operater_after_time; }
            set { operater_after_time = value; }
        }

        private string patient_id;
        /// <summary>
        /// ��������
        /// </summary>
        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        private string pain_value;
        /// <summary>
        /// ��ʹ����
        /// </summary>
        public string Pain_value
        {
            get { return pain_value; }
            set { pain_value = value; }
        }

        private string pain_mothed;
        /// <summary>
        /// ��ʹ���ַ���
        /// </summary>
        public string Pain_mothed
        {
            get { return pain_mothed; }
            set { pain_mothed = value; }
        }
    }
}
