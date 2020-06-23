using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 借阅管理实体类
    /// </summary>
    public class Class_CaseHospital
    {
        private string borrow_date;
    
        private string borrow_people;
   
        private string borrow_section;
    
        private string content_query;
     
        private string return_date;
     
        private string plan_returndate;
    
        private string case_number;
   
        private string name;
      
        private string age;
   
        private string admission_date;
       
        private string to_hospital_diagnosis;
    
        private string to_hospital_section;
    
        private string hospital_fee;
   
        private string to_hospital_date;

        private string icd10;
     
        private string icd9;
 
        private string state;
      
        /// <summary>
        /// 借阅日期
        /// </summary>
        public string Borrow_date
        {
            get { return borrow_date; }
            set { borrow_date = value; }
        }
        /// <summary>
        /// 借阅人
        /// </summary>
        public string Borrow_people
        {
            get { return borrow_people; }
            set { borrow_people = value; }
        }
        /// <summary>
        /// 借阅科别
        /// </summary>
        public string Borrow_section
        {
            get { return borrow_section; }
            set { borrow_section = value; }
        }
        /// <summary>
        /// 查询内容
        /// </summary>
        public string Content_query
        {
            get { return content_query; }
            set { content_query = value; }
        }
        /// <summary>
        /// 归还日期
        /// </summary>
        public string Return_date
        {
            get { return return_date; }
            set { return_date = value; }
        }
        /// <summary>
        /// 计划归还日期
        /// </summary>
        public string Plan_returndate
        {
            get { return plan_returndate; }
            set { plan_returndate = value; }
        }
        /// <summary>
        /// 病案号
        /// </summary>
        public string Case_number
        {
            get { return case_number; }
            set { case_number = value; }
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
        public string Admission_date
        {
            get { return admission_date; }
            set { admission_date = value; }
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
        public string Hospital_fee
        {
            get { return hospital_fee; }
            set { hospital_fee = value; }
        }
        /// <summary>
        /// 出院日期
        /// </summary>
        public string To_hospital_date
        {
            get { return to_hospital_date; }
            set { to_hospital_date = value; }
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
        /// 手术分类代码
        /// </summary>
        public string Icd9
        {
            get { return icd9; }
            set { icd9 = value; }
        }
        /// <summary>
        /// 病案状态
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }
    }
}
