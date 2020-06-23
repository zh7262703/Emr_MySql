using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 结构类
    /// </summary>
    class Class_Struct
    {
        private int sid;

        /// <summary>
        /// id自增
        /// </summary>
        public int Sid
        {
            get { return sid; }
            set { sid = value; }
        }
        private int lid;

        /// <summary>
        /// 标签模版的关联Id
        /// </summary>
        public int Lid
        {
            get { return lid; }
            set { lid = value; }
        }
        private string struct_Lable;

        /// <summary>
        /// 结构化名称
        /// </summary>
        public string Struct_Lable
        {
            get { return struct_Lable; }
            set { struct_Lable = value; }
        }
        private string struct_Value;

        /// <summary>
        /// 结构化的值
        /// </summary>
        public string Struct_Value
        {
            get { return struct_Value; }
            set { struct_Value = value; }
        }

    }
}
