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
        /// 抽查时间
        /// </summary>
        public string Choucha_time
        {
            get { return choucha_time; }
            set { choucha_time = value; }
        }
        /// <summary>
        /// 责任人
        /// </summary>
        public string Person_in_charge
        {
            get { return person_in_charge; }
            set { person_in_charge = value; }
        }
        /// <summary>
        /// 患者姓名
        /// </summary>
        public string Pidname
        {
            get { return pidname; }
            set { pidname = value; }
        }
        /// <summary>
        /// 病案号
        /// </summary>
        public string Pids
        {
            get { return pids; }
            set { pids = value; }
        }
        /// <summary>
        /// 床号
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
        /// 体温单合计
        /// </summary>
       public double Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }
        /// <summary>
        /// 危重合计
        /// </summary>
       public double Nurse_record
        {
            get { return nurse_record; }
            set { nurse_record = value; }
        }
       /// <summary>
       /// 合计
       /// </summary>
       public double Total
        {
            get { return total; }
            set { total = value; }
        }
       /// <summary>
       /// 查看明细
       /// </summary>
       public string Particulars
       {
           get { return particulars; }
           set { particulars = value; }
       }
    }
}
