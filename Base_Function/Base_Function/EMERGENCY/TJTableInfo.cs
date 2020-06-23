using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.EMERGENCY
{
    public class TJTableInfo
    {
        string name;
        /// <summary>
        /// 表格名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string caption;
        /// <summary>
        /// 显示名称
        /// </summary>
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        string parent;
        /// <summary>
        /// 父级名称
        /// </summary>
        public string Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        int order = 0;
        /// <summary>
        /// 显示序号
        /// </summary>
        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        //public TableInfo(string _name, string _caption)
        //{
        //    this.name = _name;
        //    this.caption = _caption;
        //}

        //public TableInfo()
        //{

        //}
    }
}
