using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
   public  class Class_T_FECTER_REPORT_CARD
    {
        private string patient_id;
       /// <summary>
       /// סԺ��
       /// </summary>
        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        private string patient_name;
       /// <summary>
       /// ��������
       /// </summary>
        public string Patient_name
        {
            get { return patient_name; }
            set { patient_name = value; }
        }

        private string in_section;
       /// <summary>
       /// ��ǰ����
       /// </summary>
        public string In_section
        {
            get { return in_section; }
            set { in_section = value; }
        }

        private string in_doctor;
        /// <summary>
        /// �ܴ�ҽ��
        /// </summary>
        public string In_doctor
        {
            get { return in_doctor; }
            set { in_doctor = value; }
        }

        private string in_time;
       /// <summary>
       /// ��Ժʱ��
       /// </summary>
        public string In_time
        {
            get { return in_time; }
            set { in_time = value; }
        }

        private string in_itemname;
       /// <summary>
       /// ��Ժ���
       /// </summary>
        public string In_itemname
        {
            get { return in_itemname; }
            set { in_itemname = value; }
        }

        private int court_card;
       /// <summary>
       /// Ժ�б���
       /// </summary>
       public int Court_card
        {
            get { return court_card; }
            set { court_card = value; }
        }

       private int infect_card;
       /// <summary>
       /// ��Ⱦ������
       /// </summary>
       public int Infect_card
        {
            get { return infect_card; }
            set { infect_card = value; }
        }

        private string resons_card;
       /// <summary>
       /// �˿�ԭ��
       /// </summary>
        public string Resons_card
        {
            get { return resons_card; }
            set { resons_card = value; }
        }

        private string state;
       /// <summary>
       /// ����״̬
       /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string id;
       /// <summary>
       /// ��������
       /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
