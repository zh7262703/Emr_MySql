using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class class_SickAreaInfo
    {
        /// <summary>
        /// 病区信息表
        /// </summary>
        private string said;
   
        private string sick_area_no;
    
        private string sick_area_name;
   
        private string depart_id;
    
        private string isbelongtosection;

        private string belongtosection;
  
        private string sub_hospital_code;
      
        private string enable_flag;

        private int bed_count;
    
        private int alow_count;
        /// <summary>
        /// 病区代码
        /// </summary>
        public string Said
        {
            get { return said; }
            set { said = value; }
        }

        /// <summary>
        /// 病区编号
        /// </summary>
        public string Sick_area_no
        {
            get { return sick_area_no; }
            set { sick_area_no = value; }
        }
        /// <summary>
        /// 病区名称
        /// </summary>
        public string Sick_area_name
        {
            get { return sick_area_name; }
            set { sick_area_name = value; }
        }
        /// <summary>
        /// 所属科室代码
        /// </summary>
        public string Depart_id
        {
            get { return depart_id; }
            set { depart_id = value; }
        }
        /// <summary>
        /// 是否大病区
        /// </summary>
        public string Isbelongtosection
        {
            get { return isbelongtosection; }
            set { isbelongtosection = value; }
        }
        /// <summary>
        /// 所属大病区
        /// </summary>
        public string Belongtosection
        {
            get { return belongtosection; }
            set { belongtosection = value; }
        }
        /// <summary>
        /// 所属分院部代码
        /// </summary>
        public string Sub_hospital_code
        {
            get { return sub_hospital_code; }
            set { sub_hospital_code = value; }
        }
        /// <summary>
        /// 有效标志
        /// </summary>
        public string Enable_flag
        {
            get { return enable_flag; }
            set { enable_flag = value; }
        }
        /// <summary>
        /// 标准病床数
        /// </summary>
        public int Bed_count
        {
            get { return bed_count; }
            set { bed_count = value; }
        }

        /// <summary>
        /// 允许加床数
        /// </summary>
        public int Alow_count
        {
            get { return alow_count; }
            set { alow_count = value; }
        }
    }
}
