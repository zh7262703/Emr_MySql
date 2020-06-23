using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 血压群录实体类
    /// 创建者：杨妹
    /// 创建时间 2011-03-06
    /// </summary>
    public class ClassBlood_pressure
    {
        private string bed;
      
        private string pidname;
        
        private string blood_pressure08;
     
        private string blood_pressure14;
    
        private string pid;
        private string pidids;

   
        /// <summary>
        /// 床号
        /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Pidname
        {
            get { return pidname; }
            set { pidname = value; }
        }
        /// <summary>
        /// 血压8:00
        /// </summary>
        public string Blood_pressure08
        {
            get { return blood_pressure08; }
            set { blood_pressure08 = value; }
        }
        /// <summary>
        /// 血压14:00
        /// </summary>
        public string Blood_pressure14
        {
            get { return blood_pressure14; }
            set { blood_pressure14 = value; }
        }
        /// <summary>
        /// 病人住院号
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        /// <summary>
        /// 病人编号
        /// </summary>
        public string Pidids
        {
            get { return pidids; }
            set { pidids = value; }
        }

    }
}
