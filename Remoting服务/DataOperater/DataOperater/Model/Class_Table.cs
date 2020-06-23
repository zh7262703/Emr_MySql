using System;
using System.Collections.Generic;
using System.Text;

namespace DataOperater.Model
{
    [Serializable]
    public class Class_Table
    {
        /// <summary>
        /// SQl”Ôæ‰±Ì
        /// </summary>
        private string sql;
        public string Sql
        {
            get { return sql; }
            set { sql = value; }
        }

        /// <summary>
        /// ±Ì√˚
        /// </summary>
        private string tablename;
        public string Tablename
        {
            get { return tablename; }
            set { tablename = value; }
        }
    }
}
