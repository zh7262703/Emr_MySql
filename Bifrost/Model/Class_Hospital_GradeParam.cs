using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// �������Ĳ�������
    /// </summary>
    public class Class_Hospital_GradeParam
    {
        private int id;
   
        private string hospital_borrowtype;

        private string hospital_datetime;

        private string hospital_datetime_unit;
    
        private string outside_hospital_borrowtype;

        private string outside_hospital_datetime;
  
        private string outside_hospital_datetime_unit;
 
        private DateTime cradte_time;
 
        private DateTime update_time;
    
        private string username;
        /// <summary>
        /// ���
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// Ժ�ڽ���ʱ�����ñ�ʶ
        /// </summary>
        public string Hospital_borrowtype
        {
            get { return hospital_borrowtype; }
            set { hospital_borrowtype = value; }
        }
        /// <summary>
        /// Ժ��ʱ��
        /// </summary>
        public string Hospital_datetime
        {
            get { return hospital_datetime; }
            set { hospital_datetime = value; }
        }
        /// <summary>
        /// Ժ��ʱ�䵥λ
        /// </summary>
        public string Hospital_datetime_unit
        {
            get { return hospital_datetime_unit; }
            set { hospital_datetime_unit = value; }
        }
        /// <summary>
        /// Ժ�����ʱ�����ñ�ʶ
        /// </summary>
        public string Outside_hospital_borrowtype
        {
            get { return outside_hospital_borrowtype; }
            set { outside_hospital_borrowtype = value; }
        }
        /// <summary>
        /// Ժ��ʱ��
        /// </summary>
        public string Outside_hospital_datetime
        {
            get { return outside_hospital_datetime; }
            set { outside_hospital_datetime = value; }
        }
        /// <summary>
        /// Ժ��ʱ�䵥λ
        /// </summary>
        public string Outside_hospital_datetime_unit
        {
            get { return outside_hospital_datetime_unit; }
            set { outside_hospital_datetime_unit = value; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime Cradte_time
        {
            get { return cradte_time; }
            set { cradte_time = value; }
        }
        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public DateTime Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
