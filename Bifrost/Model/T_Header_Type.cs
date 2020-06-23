using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class T_Header_Type
    {
        private int id;
        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 路径代码
        /// </summary>
        private string path_code;

        public string Path_code
        {
            get { return path_code; }
            set { path_code = value; }
        }
        /// <summary>
        /// 序号
        /// </summary>
        private string days_id;

        public string Days_id
        {
            get { return days_id; }
            set { days_id = value; }
        }
        /// <summary>
        /// 列头1
        /// </summary>
        private string label1;

        public string Label1
        {
            get { return label1; }
            set { label1 = value; }
        }
        /// <summary>
        /// 列头2
        /// </summary>
        private string label2;

        public string Label2
        {
            get { return label2; }
            set { label2 = value; }
        }
        /// <summary>
        /// 路径名称
        /// </summary>
        private string path_name;

        public string Path_name
        {
            get { return path_name; }
            set { path_name = value; }
        }
    }
}
