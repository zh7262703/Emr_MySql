using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
   public  class Class_Spotcheck
    {
        private string choucha_time;
    
        private string person_in_charge;
   
        private string pidname;
      
        private string pids;
   
        private string beds;
      
        private string sickid;


        private string sickname;


        private string sectionid;


        private string sectionname;
    
        private double temperature;
     
        private double nurse_record;
   
        private double total;
        private string particulars;

        /// <summary>
        /// ���ʱ��
        /// </summary>
        public string Choucha_time
        {
            get { return choucha_time; }
            set { choucha_time = value; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Person_in_charge
        {
            get { return person_in_charge; }
            set { person_in_charge = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Pidname
        {
            get { return pidname; }
            set { pidname = value; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Pids
        {
            get { return pids; }
            set { pids = value; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Beds
        {
            get { return beds; }
            set { beds = value; }
        }
        public string Sickid
        {
            get { return sickid; }
            set { sickid = value; }
        }
        public string Sickname
        {
            get { return sickname; }
            set { sickname = value; }
        }
        public string Sectionid
        {
            get { return sectionid; }
            set { sectionid = value; }
        }
        public string Sectionname
        {
            get { return sectionname; }
            set { sectionname = value; }
        }
        /// <summary>
        /// ���µ��ϼ�
        /// </summary>
       public double Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        /// <summary>
        /// Σ�غϼ�
        /// </summary>
       public double Nurse_record
        {
            get { return nurse_record; }
            set { nurse_record = value; }
        }
       /// <summary>
       /// �ϼ�
       /// </summary>
       public double Total
        {
            get { return total; }
            set { total = value; }
        }
       /// <summary>
       /// �鿴��ϸ
       /// </summary>
       public string Particulars
       {
           get { return particulars; }
           set { particulars = value; }
       }
    }
}
