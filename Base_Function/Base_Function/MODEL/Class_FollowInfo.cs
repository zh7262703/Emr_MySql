using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function
{
    public class Class_FollowInfo
    {

        string id;
        /// <summary>
        /// 方案ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string follow_name;
        /// <summary>
        /// 方案名
        /// </summary>
        public string Follow_name
        {
            get { return follow_name; }
            set { follow_name = value; }
        }
        string account_ids;
        /// <summary>
        /// 
        /// </summary>
        public string Account_ids
        {
            get { return account_ids; }
            set { account_ids = value; }
        }
        string section_ids;
        /// <summary>
        /// 方案所筛选病人所属科室
        /// </summary>
        public string Section_ids
        {
            get { return section_ids; }
            set { section_ids = value; }
        }
        string section_names;
        /// <summary>
        /// 方案所筛选病人所属科室名
        /// </summary>
        public string Section_names
        {
            get { return section_names; }
            set { section_names = value; }
        }
        string creator;
        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator
        {
            get { return creator; }
            set { creator = value; }
        }
        string icd9codes;
        /// <summary>
        /// 手术码
        /// </summary>
        public string Icd9codes
        {
            get { return icd9codes; }
            set { icd9codes = value; }
        }
        string icd10codes;
        /// <summary>
        /// 诊断码
        /// </summary>
        public string Icd10codes
        {
            get { return icd10codes; }
            set { icd10codes = value; }
        }
        string ismaindiag;
        /// <summary>
        /// 是否主诊断
        /// </summary>
        public string Ismaindiag
        {
            get { return ismaindiag; }
            set { ismaindiag = value; }
        }
        string startingtime;
        /// <summary>
        /// 方案参考开始时间
        /// </summary>
        public string Startingtime
        {
            get { return startingtime; }
            set { startingtime = value; }
        }
        string defaultdays;
        /// <summary>
        /// 方案首次默认时间
        /// </summary>
        public string Defaultdays
        {
            get { return defaultdays; }
            set { defaultdays = value; }
        }


        string followtype;
        /// <summary>
        /// 方案设定循环时间
        /// </summary>
        public string Followtype
        {
            get { return followtype; }
            set { followtype = value; }
        }
        string definefollows;
        /// <summary>
        /// 方案自定义循环时间
        /// </summary>
        public string Definefollows
        {
            get { return definefollows; }
            set { definefollows = value; }
        }

        private string finishType;
        /// <summary>
        /// 方案结束条件
        /// </summary>
        public string FinishType
        {
            get { return finishType; }
            set { finishType = value; }
        }

        string followtextid;
        /// <summary>
        /// 方案相关文书
        /// </summary>
        public string Followtextid
        {
            get { return followtextid; }
            set { followtextid = value; }
        }
        string createtime;
        /// <summary>
        /// 方案创建时间
        /// </summary>
        public string Createtime
        {
            get { return createtime; }
            set { createtime = value; }
        }
        string isenable;
        /// <summary>
        /// 方案是否有效
        /// </summary>
        public string Isenable
        {
            get { return isenable; }
            set { isenable = value; }
        }
        string maintain_section;
        /// <summary>
        /// 方案维护科室
        /// </summary>
        public string Maintain_section
        {
            get { return maintain_section; }
            set { maintain_section = value; }
        }
        string exec_sections;
        /// <summary>
        /// 方案相关科室（医生）
        /// </summary>
        public string Exec_sections
        {
            get { return exec_sections; }
            set { exec_sections = value; }
        }
        string exec_secnames;
        /// <summary>
        /// 方案相关科室名（医生）
        /// </summary>
        public string Exec_secnames
        {
            get { return exec_secnames; }
            set { exec_secnames = value; }
        }
        string exec_sickarea;
        /// <summary>
        /// 方案相关病区（护士）
        /// </summary>
        public string Exec_sickarea
        {
            get { return exec_sickarea; }
            set { exec_sickarea = value; }
        }
        string exec_sickareanames;
        /// <summary>
        /// 方案相关病区名（护士）
        /// </summary>
        public string Exec_sickareanames
        {
            get { return exec_sickareanames; }
            set { exec_sickareanames = value; }
        }
    }
}
