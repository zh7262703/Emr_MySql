using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class class_SickAreaInfo
    {
        /// <summary>
        /// ������Ϣ��
        /// </summary>
        private string said;
   
        private string sick_area_no;
    
        private string sick_area_name;
   
        private string depart_id;
    
        private string isbelongtosection;

        private string belongtosection;
  
        private string sub_hospital_code;
      
        private string enable_flag;

        private int bed_count;
    
        private int alow_count;
        /// <summary>
        /// ��������
        /// </summary>
        public string Said
        {
            get { return said; }
            set { said = value; }
        }

        /// <summary>
        /// �������
        /// </summary>
        public string Sick_area_no
        {
            get { return sick_area_no; }
            set { sick_area_no = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Sick_area_name
        {
            get { return sick_area_name; }
            set { sick_area_name = value; }
        }
        /// <summary>
        /// �������Ҵ���
        /// </summary>
        public string Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public string Isbelongtosection
        {
            get { return isbelongtosection; }
            set { isbelongtosection = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Belongtosection
        {
            get { return belongtosection; }
            set { belongtosection = value; }
        }
        /// <summary>
        /// ������Ժ������
        /// </summary>
        public string Sub_hospital_code
        {
            get { return sub_hospital_code; }
            set { sub_hospital_code = value; }
        }
        /// <summary>
        /// ��Ч��־
        /// </summary>
        public string Enable_flag
        {
            get { return enable_flag; }
            set { enable_flag = value; }
        }
        /// <summary>
        /// ��׼������
        /// </summary>
        public int Bed_count
        {
            get { return bed_count; }
            set { bed_count = value; }
        }

        /// <summary>
        /// ����Ӵ���
        /// </summary>
        public int Alow_count
        {
            get { return alow_count; }
            set { alow_count = value; }
        }
    }
}
