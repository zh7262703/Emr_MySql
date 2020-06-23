using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{   
    /// <summary>
    /// 文书的使用范围
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_Doc_User_Range
    {
        private int id;
        private int texttype; 
        private int belonghospital;
        private int section;
        private int workgroup;

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
        /// 分院
        /// </summary>
        public int Belonghospital
        {
            get { return belonghospital; }
            set { belonghospital = value; }
        }
        
        /// <summary>
        /// 科室
        /// </summary>
        public int Section
        {
            get { return section; }
            set { section = value; }
        }
       
        /// <summary>
        /// 分组
        /// </summary>
        public int Workgroup
        {
            get { return workgroup; }
            set { workgroup = value; }
        }
    }
}
