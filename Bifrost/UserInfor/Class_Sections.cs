using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{  
    /// <summary>
    /// 科室信息表SECTION
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Sections
    {

        private string section_code;
        private string section_name;
        private string belongto_section_id;
        private string ischecksection;
        private string belongto_section_name;
        private string belongto_bigsection_id;
        private string isbelongtobigsection;
        private string type;
        private string inout_flag;
        private string manage_type;
        private string state;
        private string belongto_hospital;
        private int sid;

        /// <summary>
        /// 科室ID
        /// </summary>
        public int Sid
        {
            get { return sid; }
            set { sid = value; }
        }


        /// <summary>
        /// 科室代码
        /// </summary>
        public string Section_Code
        {
            get { return section_code; }
            set { section_code = value; }
        }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string Section_Name
        {
            get { return section_name; }
            set { section_name = value; }
        }
        /// <summary>
        /// 所属核算科的ID
        /// </summary>
        public string Belongto_Section_Id
        {
            get { return belongto_section_id; }
            set { belongto_section_id = value; }
        }
        /// <summary>
        /// 是否检查科：Y是
        /// </summary>
        public string isCheckSection
        {
            get { return ischecksection; }
            set { ischecksection = value; }
        }
        /// <summary>
        /// 所属核算科的名称
        /// </summary>
        public string Belongto_Section_Name
        {
            get { return belongto_section_name; }
            set { belongto_section_name = value; }
        }
        /// <summary>
        /// 所属大科ID
        /// </summary>
        public string Belongto_BigSection_ID
        {
            get { return belongto_bigsection_id; }
            set { belongto_bigsection_id = value; }
        }
        /// <summary>
        /// 是否是大科：Y是
        /// </summary>
        public string isBelongToBigSection
        {
            get { return isbelongtobigsection; }
            set { isbelongtobigsection = value; }
        }
        /// <summary>
        /// 类别：1-核算 2-大科 3-普通
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        /// <summary>
        /// 住院及门诊标志：I-住院 O-门诊
        /// </summary>
        public string Inout_flag
        {
            get { return inout_flag; }
            set { inout_flag = value; }
        }
        /// <summary>
        /// 科室管理属性：1-临床 2-药剂 3-后勤 4-行政 5-医技 6-科研 7-教学
        /// </summary>
        public string Manage_type
        {
            get { return manage_type; }
            set { manage_type = value; }
        }
        /// <summary>
        /// 有效标志：Y-有效  N-无效 
        /// </summary>
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        /// <summary>
        /// 所属分院
        /// </summary>
        public string Belongto_hospital
        {
            get { return belongto_hospital; }
            set { belongto_hospital = value; }
        }
    }
}
