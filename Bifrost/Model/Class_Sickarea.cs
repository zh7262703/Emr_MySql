using System;
using System.Collections.Generic;
using System.Text;


namespace Bifrost
{
    /// <summary>
    /// ������Ϣ��
    /// </summary>
  public   class Class_Sickarea
    {
        private string said;

        private string shid;

        private string sick_area_code;
   
        private string sick_area_name;

        private string isbelongtosection;
    
        private string belongtosection;
     
        private string enable_flag;

        private string bed_count;
  
        private string alow_count;
        /// <summary>
        /// ���
        /// </summary>
        public string Said
        {
            get { return said; }
            set { said = value; }
        }
        /// <summary>
        /// ��Ժ
        /// </summary>
        public string Shid
        {
            get { return shid; }
            set { shid = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string Sick_area_code
        {
            get { return sick_area_code; }
            set { sick_area_code = value; }
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
        /// �Ƿ�Ϊ����
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
        public string Bed_count
        {
            get { return bed_count; }
            set { bed_count = value; }
        }

        /// <summary>
        /// ����Ӵ���
        /// </summary>
        public string Alow_count
        {
            get { return alow_count; }
            set { alow_count = value; }
        }

    
    }
}
