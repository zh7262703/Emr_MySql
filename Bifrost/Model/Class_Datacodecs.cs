using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 数据字典信息
    /// </summary>
   public class Class_Datacodecs
    {
        private string id;

        private string name;
    
        private string code;
     
        private string shortchut_code;
 
        private string enable;
   
        private string type;
        /// <summary>
        /// 编号
        /// </summary>

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 代码编号
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        /// <summary>
        /// 拼音
        /// </summary>
        public string Shortchut_code
        {
            get { return shortchut_code; }
            set { shortchut_code = value; }
        }
        /// <summary>
        /// 有效标志
        /// </summary>
        public string Enable
        {
            get { return enable; }
            set { enable = value; }
        }
        /// <summary>
        ///类型
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
