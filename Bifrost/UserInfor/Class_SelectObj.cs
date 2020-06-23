using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bifrost
{   
    /// <summary>
    /// 用于获取快码查询的值
    /// 创建者：张华
    /// 创建时间：2010-6-15
    /// </summary>
    public class Class_SelectObj
    {
        private string select_name;
        private string select_val;
        private DataRow select_row;

        /// <summary>
        /// 名称
        /// </summary>
        public string Select_Name
        {
            get { return select_name; }
            set { select_name = value; }
        }

        /// <summary>
        /// 值
        /// </summary>
        public string Select_Val
        {
            get { return select_val; }
            set { select_val = value; }
        }

        /// <summary>
        /// 整行数据
        /// </summary>
        public DataRow Select_Row
        {
            get { return select_row; }
            set { select_row = value; }
        }
    }
}
