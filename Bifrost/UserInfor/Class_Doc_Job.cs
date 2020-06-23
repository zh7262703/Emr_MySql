using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{   
    /// <summary>
    /// 文书的职务职称
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Doc_Job
    {
        private int id;
        private int texttype;
        private int textcontrol;
        private string flag;
        private int jobtitle;
        private int type;

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
        /// 文书操作
        /// </summary>
        public int Textcontrol
        {
            get { return textcontrol; }
            set { textcontrol = value; }
        }       

        /// <summary>
        /// 标记符号
        /// </summary>
        public string Flag
        {
            get { return flag; }
            set { flag = value; }
        }        

        /// <summary>
        /// 具体职务或职称主键
        /// </summary>
        public int Jobtitle
        {
            get { return jobtitle; }
            set { jobtitle = value; }
        }       

        /// <summary>
        /// 职务或职称类型
        /// </summary>
        public int Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
 