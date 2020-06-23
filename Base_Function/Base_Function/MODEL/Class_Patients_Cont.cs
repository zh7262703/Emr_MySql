using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 标签类
    /// </summary>
    class Class_Patients_Cont
    {

        private int id;

        /// <summary>
        /// 自增ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        } 

        private int tid; //模版ID

        /// <summary>
        /// 模版ID
        /// </summary>
        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }
        private string lableName; //模版标签

        /// <summary>
        /// 模版标签
        /// </summary>
        public string LableName
        {
            get { return lableName; }
            set { lableName = value; }
        }
        private string content; //标签内容

        /// <summary>
        /// 标签内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }
      
      
      

    }
}
