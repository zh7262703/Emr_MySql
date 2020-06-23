using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   /// <summary>
   /// ������ƶ����
   /// </summary>
   public  class Class_DiagDEF
    {
        private string diag_id;
     
        private string name;
     
        private int category_id;
    
        private string is_chn;
      
        private string shortcut1;
        
        private string shortcut2;
      
        private string is_icd10;
       
        private string icd10_id;
     
        private int attkind;
        /// <summary>
        /// ��ϱ��
        /// </summary>
        public string Diag_id
        {
            get { return diag_id; }
            set { diag_id = value; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        public int Category_id
        {
            get { return category_id; }
            set { category_id = value; }
        }
        /// <summary>
        /// �Ƿ���ҽ���
        /// </summary>
        public string Is_chn
        {
            get { return is_chn; }
            set { is_chn = value; }
        }
        /// <summary>
        /// ƴ��
        /// </summary>
        public string Shortcut1
        {
            get { return shortcut1; }
            set { shortcut1 = value; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public string Shortcut2
        {
            get { return shortcut2; }
            set { shortcut2 = value; }
        }
        /// <summary>
        /// �Ƿ�ICD10�����
        /// </summary>
        public string Is_icd10
        {
            get { return is_icd10; }
            set { is_icd10 = value; }
        }
        /// <summary>
        /// ICD10�����
        /// </summary>
        public string Icd10_id
        {
            get { return icd10_id; }
            set { icd10_id = value; }
        }
        /// <summary>
        /// �����������
        /// </summary>
        public int Attkind
        {
            get { return attkind; }
            set { attkind = value; }
        }
    }
}
