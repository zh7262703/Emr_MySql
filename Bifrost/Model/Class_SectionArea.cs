using System;
using System.Collections.Generic;
using System.Text;


namespace Bifrost
{
    /// <summary>
    /// 科室病区关系表
    /// </summary>
   public class Class_SectionArea
    {
        private string id;
  
        private string sid;
    
        private string said;
        /// <summary>
        /// 编号
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 科室ID
        /// </summary>
        public string Sid
        {
            get { return sid; }
            set { sid = value; }
        }
        /// <summary>
        /// 病区ID
        /// </summary>
        public string Said
        {
            get { return said; }
            set { said = value; }
        }
    }
}
