using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    [Serializable]
    public class Class_Table
    {
        /// <summary>
        /// SQl语句表
        /// </summary>
        private string sql;
        public string Sql
        {
            get { return sql; }
            set { sql = value; }
        }

        /// <summary>
        /// 表名
        /// </summary>
        private string tablename;
        public string Tablename
        {
            get { return tablename; }
            set { tablename = value; }
        }
    }
}
