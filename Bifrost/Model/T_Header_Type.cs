using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    public class T_Header_Type
    {
        private int id;
        /// <summary>
        /// ���
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// ·������
        /// </summary>
        private string path_code;

        public string Path_code
        {
            get { return path_code; }
            set { path_code = value; }
        }
        /// <summary>
        /// ���
        /// </summary>
        private string days_id;

        public string Days_id
        {
            get { return days_id; }
            set { days_id = value; }
        }
        /// <summary>
        /// ��ͷ1
        /// </summary>
        private string label1;

        public string Label1
        {
            get { return label1; }
            set { label1 = value; }
        }
        /// <summary>
        /// ��ͷ2
        /// </summary>
        private string label2;

        public string Label2
        {
            get { return label2; }
            set { label2 = value; }
        }
        /// <summary>
        /// ·������
        /// </summary>
        private string path_name;

        public string Path_name
        {
            get { return path_name; }
            set { path_name = value; }
        }
    }
}
