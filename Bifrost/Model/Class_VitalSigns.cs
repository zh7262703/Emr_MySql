using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// ���µ���Ϣ��
    /// </summary>
    public class Class_VitalSigns
    {
        private int id;
      
        private string bed;
      
        private string pid;
  
        //private string measure_date;

        private string measure_time;
 
        private int temperature_value;
    
        private string temperature_body;
    
        private string re_measure;
    
        private int cooling_value;
   
        private string cooling_type;
   
        private int pulse_value;
   
        private string is_briefness;
  
        private int heart_rhythm;
      
        private string is_assist_hr;
     
        private int breath_value;
      
        private string is_assist_br;
      
        private string measure_state;
     
        private string describe;
    
        private string remark;
        /// <summary>
        /// ���
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
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
        /// סԺ����
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Measure_date
        {
            get { return Measure_date; }
            set { Measure_date = value; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public string Measure_time
        {
            get { return measure_time; }
            set { measure_time = value; }
        }
     
        /// <summary>
        /// ���²���ֵ
        /// </summary>
        public int Temperature_value
        {
            get { return temperature_value; }
            set { temperature_value = value; }
        }
        /// <summary>
        /// ���²�����λ
        /// </summary>
        public string Temperature_body
        {
            get { return temperature_body; }
            set { temperature_body = value; }
        }
        /// <summary>
        /// �����־
        /// </summary>
        public string Re_measure
        {
            get { return re_measure; }
            set { re_measure = value; }
        }
        /// <summary>
        /// ���º��¶�
        /// </summary>
        public int Cooling_value
        {
            get { return cooling_value; }
            set { cooling_value = value; }
        }
        /// <summary>
        /// ���´�ʩ
        /// </summary>
        public string Cooling_type
        {
            get { return cooling_type; }
            set { cooling_type = value; }
        }
        /// <summary>
        /// ��������ֵ
        /// </summary>
        public int Pulse_value
        {
            get { return pulse_value; }
            set { pulse_value = value; }
        }
        /// <summary>
        /// �����̴�
        /// </summary>
        public string Is_briefness
        {
            get { return is_briefness; }
            set { is_briefness = value; }
        }
        /// <summary>
        /// ���ʲ���ֵ
        /// </summary>
        public int Heart_rhythm
        {
            get { return heart_rhythm; }
            set { heart_rhythm = value; }
        }
        /// <summary>
        /// ������е������־
        /// </summary>
        public string Is_assist_hr
        {
            get { return is_assist_hr; }
            set { is_assist_hr = value; }
        }
        /// <summary>
        /// ��������ֵ
        /// </summary>
        public int Breath_value
        {
            get { return breath_value; }
            set { breath_value = value; }
        }
        /// <summary>
        /// ������е������־
        /// </summary>
        public string Is_assist_br
        {
            get { return is_assist_br; }
            set { is_assist_br = value; }
        }
        /// <summary>
        /// ����״̬
        /// </summary>
        public string Measure_state
        {
            get { return measure_state; }
            set { measure_state = value; }
        }
        /// <summary>
        /// �¼�����
        /// </summary>
        public string Describe
        {
            get { return describe; }
            set { describe = value; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
 

    }
}
