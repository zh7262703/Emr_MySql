using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
   public  class Class_T_FECTER_REPORT_CARD
    {
        private string patient_id;
       /// <summary>
       /// 住院号
       /// </summary>
        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        private string patient_name;
       /// <summary>
       /// 病人姓名
       /// </summary>
        public string Patient_name
        {
            get { return patient_name; }
            set { patient_name = value; }
        }

        private string in_section;
       /// <summary>
       /// 当前科室
       /// </summary>
        public string In_section
        {
            get { return in_section; }
            set { in_section = value; }
        }

        private string in_doctor;
        /// <summary>
        /// 管床医生
        /// </summary>
        public string In_doctor
        {
            get { return in_doctor; }
            set { in_doctor = value; }
        }

        private string in_time;
       /// <summary>
       /// 入院时间
       /// </summary>
        public string In_time
        {
            get { return in_time; }
            set { in_time = value; }
        }

        private string in_itemname;
       /// <summary>
       /// 入院诊断
       /// </summary>
        public string In_itemname
        {
            get { return in_itemname; }
            set { in_itemname = value; }
        }

        private int court_card;
       /// <summary>
       /// 院感报卡
       /// </summary>
       public int Court_card
        {
            get { return court_card; }
            set { court_card = value; }
        }

       private int infect_card;
       /// <summary>
       /// 传染病报卡
       /// </summary>
       public int Infect_card
        {
            get { return infect_card; }
            set { infect_card = value; }
        }

        private string resons_card;
       /// <summary>
       /// 退卡原因
       /// </summary>
        public string Resons_card
        {
            get { return resons_card; }
            set { resons_card = value; }
        }

        private string state;
       /// <summary>
       /// 报卡状态
       /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string id;
       /// <summary>
       /// 病人主键
       /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
