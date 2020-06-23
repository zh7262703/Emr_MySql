using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 文书信息
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Text_A
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Class_Text_A()
        { }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string isenable;

        public string Isenable
        {
            get { return isenable; }
            set { isenable = value; }
        }
        private string issimpleinstance;

        public string Issimpleinstance
        {
            get { return issimpleinstance; }
            set { issimpleinstance = value; }
        }
        private int parentid;

        public int Parentid
        {
            get { return parentid; }
            set { parentid = value; }
        }
        private string textcode;

        /// <summary>
        /// 文书代码
        /// </summary>
        public string Textcode
        {
            get { return textcode; }
            set { textcode = value; }
        }
        private string textname;

        /// <summary>
        /// 文书名称
        /// </summary>
        public string Textname
        {
            get { return textname; }
            set { textname = value; }
        }
        private string txxttype;

        /// <summary>
        ///  文书总分类
        /// </summary>
        public string Txxttype
        {
            get { return txxttype; }
            set { txxttype = value; }
        }

        private Class_Doc_User_Range[] textranges;
        /// <summary>
        /// 文书使用范围
        /// </summary>
        public Class_Doc_User_Range[] TextRanges
        {
            get { return textranges; }
            set { textranges = value; }
        }
    }
}
