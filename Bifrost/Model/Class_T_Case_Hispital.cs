using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 借阅登记
    /// </summary>
    public class Class_T_Case_Hispital
    {
        private string number;
     
        private string name;
     
        private string age;

        private string admission_datetime;

        private string to_hospital_diagnosis;
    
        private string to_hospital_section;
 
        private string fee;

        private string to_hospital_datetime;

        private string borrowcount;
  
        private string if_hospital;
 
        private string state;
  
        private string icd9;
   
        private string icd10;
     
        private string fid;
        /// <summary>
        /// 病案号
        /// </summary>
        public string Number
        {
            get { return number; }
            set { number = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        /// <summary>
        /// 入院日期
        /// </summary>
        public string Admission_datetime
        {
            get { return admission_datetime; }
            set { admission_datetime = value; }
        }

        /// <summary>
        /// 出院主诊断
        /// </summary>
        public string To_hospital_diagnosis
        {
            get { return to_hospital_diagnosis; }
            set { to_hospital_diagnosis = value; }
        }
        /// <summary>
        /// 出院科别
        /// </summary>
        public string To_hospital_section
        {
            get { return to_hospital_section; }
            set { to_hospital_section = value; }
        }
        /// <summary>
        /// 费别
        /// </summary>
        public string Fee
        {
            get { return fee; }
            set { fee = value; }
        }
        /// <summary>
        /// 出院日期
        /// </summary>

        public string To_hospital_datetime
        {
            get { return to_hospital_datetime; }
            set { to_hospital_datetime = value; }
        }

        /// <summary>
        /// 借阅次数
        /// </summary>
        public string Borrowcount
        {
            get { return borrowcount; }
            set { borrowcount = value; }
        }
        /// <summary>
        /// 是否院外
        /// </summary>
        public string If_hospital
        {
            get { return if_hospital; }
            set { if_hospital = value; }
        }
        /// <summary>
        /// 病案状态
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        /// <summary>
        /// 手术分类代码
        /// </summary>
        public string Icd9
        {
            get { return icd9; }
            set { icd9 = value; }
        }
        /// <summary>
        /// 疾病分类代码
        /// </summary>
        public string Icd10
        {
            get { return icd10; }
            set { icd10 = value; }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public string Fid
        {
            get { return fid; }
            set { fid = value; }
        }

    }
}
