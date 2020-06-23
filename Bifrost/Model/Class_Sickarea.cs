using System;
using System.Collections.Generic;
using System.Text;


namespace Bifrost
{
    /// <summary>
    /// 病区信息表
    /// </summary>
  public   class Class_Sickarea
    {
        private string said;

        private string shid;

        private string sick_area_code;
   
        private string sick_area_name;

        private string isbelongtosection;
    
        private string belongtosection;
     
        private string enable_flag;

        private string bed_count;
  
        private string alow_count;
        /// <summary>
        /// 编号
        /// </summary>
        public string Said
        {
            get { return said; }
            set { said = value; }
        }
        /// <summary>
        /// 分院
        /// </summary>
        public string Shid
        {
            get { return shid; }
            set { shid = value; }
        }

        /// <summary>
        /// 病区代码
        /// </summary>
        public string Sick_area_code
        {
            get { return sick_area_code; }
            set { sick_area_code = value; }
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
        /// 是否为大病区
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
        public string Bed_count
        {
            get { return bed_count; }
            set { bed_count = value; }
        }

        /// <summary>
        /// 允许加床数
        /// </summary>
        public string Alow_count
        {
            get { return alow_count; }
            set { alow_count = value; }
        }

    
    }
}
