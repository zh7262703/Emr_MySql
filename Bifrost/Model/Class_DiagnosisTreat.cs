using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// ���ƻ�������Ϣ
    /// </summary>
   public  class Class_DiagnosisTreat
    {
         private int tng_id;
     
        private string tng_code;
      
        private string tng_name;
   
        private string director_id;
      
        private string tng_type;
      
        private string enable_flag;
     
        private string belongto_id;
   
        private string specialties_flag;
        /// <summary>
        /// ���ƻ�������
        /// </summary>
        public int Tng_id
        {
            get { return tng_id; }
            set { tng_id = value; }
        }
        /// <summary>
        /// ���ƻ��������
        /// </summary>
        public string Tng_code
        {
            get { return tng_code; }
            set { tng_code = value; }
        }
        /// <summary>
        /// ���ƻ���������
        /// </summary>
        public string Tng_name
        {
            get { return tng_name; }
            set { tng_name = value; }
        }
        /// <summary>
        /// ���ƻ������鳤
        /// </summary>
        public string Director_id
        {
            get { return director_id; }
            set { director_id = value; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public string Tng_type
        {
            get { return tng_type; }
            set { tng_type = value; }
        }
        /// <summary>
        /// ��־
        /// </summary>
        public string Enable_flag
        {
            get { return enable_flag; }
            set { enable_flag = value; }
        }
        /// <summary>
        /// ���ұ�Ż������
        /// </summary>
        public string Belongto_id
        {
            get { return belongto_id; }
            set { belongto_id = value; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Specialties_flag
        {
            get { return specialties_flag; }
            set { specialties_flag = value; }
        }
    }
}
