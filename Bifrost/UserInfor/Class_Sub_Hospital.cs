using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{   
    /// <summary>
    /// 分院信息
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Sub_Hospital
    {
        private string id;       
        private string sub_code;       
        private string sub_name;

        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 代码
        /// </summary>
        public string Sub_code
        {
            get { return sub_code; }
            set { sub_code = value; }
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Sub_name
        {
            get { return sub_name; }
            set { sub_name = value; }
        }

        
    }
}
