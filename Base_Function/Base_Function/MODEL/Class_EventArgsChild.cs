using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    public class Class_EventArgsChild:EventArgs
    {
        private string name;
        private string code;
        private DateTime dtOprator;
        private string levels;
        public Class_EventArgsChild()
        { 
        
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime DtOprator
        {
            get { return dtOprator; }
            set { dtOprator = value; }
        }
        /// <summary>
        /// 代码
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
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
        /// 手术级别
        /// </summary>
        public string Levels
        {
            get { return levels; }
            set { levels = value; }
        }
    }
}
