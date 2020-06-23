using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{   
    /// <summary>
    /// 文书的其他权限
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Doc_OtherRights
    {
        private int id;
        private int texttype;
        private int textcontrol;
        private string other_name;

        /// <summary>
        /// 主键
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
        /// <summary>
        /// 文书类型
        /// </summary>
        public int Texttype
        {
            get { return texttype; }
            set { texttype = value; }
        }        

        /// <summary>
        /// 文书操作按钮
        /// </summary>
        public int Textcontrol
        {
            get { return textcontrol; }
            set { textcontrol = value; }
        }
       
        /// <summary>
        /// 其他权限名称
        /// </summary>
        public string Other_name
        {
            get { return other_name; }
            set { other_name = value; }
        }
    }
}
