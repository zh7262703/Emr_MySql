using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
   public class Class_Child_TemperatureInfo
    {
        private string bed;
       /// <summary>
       /// ĸ�״���
       /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        private string child_name;
       /// <summary>
       /// Ӥ������
       /// </summary>
        public string Child_name
        {
            get { return child_name; }
            set { child_name = value; }
        }
        private double  c_temperature_2am;
       /// <summary>
       /// 2������
       /// </summary>
       public double C_temperature_2am
        {
            get { return c_temperature_2am; }
            set { c_temperature_2am = value; }
        }
       private double c_temperature_6am;
       /// <summary>
        /// 6������
       /// </summary>
       public double C_temperature_6am
        {
            get { return c_temperature_6am; }
            set { c_temperature_6am = value; }
        }
       private double c_temperature_10am;
       /// <summary>
        /// 10������
       /// </summary>
       public double C_temperature_10am
        {
            get { return c_temperature_10am; }
            set { c_temperature_10am = value; }
        }
       private double c_temperature_2pm;
        /// <summary>
        /// 14������
        /// </summary>
       public double C_temperature_2pm
        {
            get { return c_temperature_2pm; }
            set { c_temperature_2pm = value; }
        }
       private int  c_excrement;
       /// <summary>
        /// ���
       /// </summary>
       public int  C_excrement
        {
            get { return c_excrement; }
            set { c_excrement = value; }
        }
       private double c_temperature_6pm;
       /// <summary>
        /// 18������
       /// </summary>
       public double C_temperature_6pm
        {
            get { return c_temperature_6pm; }
            set { c_temperature_6pm = value; }
        }
       private double c_temperature_10pm;
       /// <summary>
        /// 22������
       /// </summary>
       public double C_temperature_10pm
        {
            get { return c_temperature_10pm; }
            set { c_temperature_10pm = value; }
        }
        private string intime;
       /// <summary>
       /// Ӥ����������
       /// </summary>
        public string Intime
        {
            get { return intime; }
            set { intime = value; }
        }
        private string child_id;
       /// <summary>
       /// Ӥ�����
       /// </summary>
        public string Child_id
        {
            get { return child_id; }
            set { child_id = value; }
        }
        private string pid;
        /// <summary>
        /// ĸ��סԺ��
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        private string sex;
       /// <summary>
        /// Ӥ���Ա�
       /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string bcg_date;
       /// <summary>
        /// ��������ʱ��
       /// </summary>
        public string Bcg_date
        {
            get { return bcg_date; }
            set { bcg_date = value; }
        }
        private string bcg_count;
       /// <summary>
        /// ������������
       /// </summary>
        public string Bcg_count
        {
            get { return bcg_count; }
            set { bcg_count = value; }
        }
        private string hepatitis_b_vaccine_date;
       /// <summary>
        /// �Ҹ��������ʱ��
       /// </summary>
        public string Hepatitis_b_vaccine_date
        {
            get { return hepatitis_b_vaccine_date; }
            set { hepatitis_b_vaccine_date = value; }
        }
        private string hepatitis_b_vaccine_count;
       /// <summary>
        /// �Ҹ���������
       /// </summary>
        public string Hepatitis_b_vaccine_count
        {
            get { return hepatitis_b_vaccine_count; }
            set { hepatitis_b_vaccine_count = value; }
        }
        private string image;
       /// <summary>
       /// ��ӡͼƬ
       /// </summary>
        public string Image
        {
            get { return image; }
            set { image = value; }
        }

    }
}
