using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    class Class_Heart_PIC
    {
        private string date;
        private string time;
        private string value_val;
        private string bz;
        private string create_name;


        /// <summary>
        /// ����
        /// </summary>
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// ʱ��
        /// </summary>
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        /// <summary>
        /// �ĵ� HR/�η�
        /// </summary>
        public string Value_val
        {
            get { return value_val; }
            set { value_val = value; }
        }
        /// <summary>
        /// �ĵ�ʾ�����
        /// </summary>
        public string BZ
        {
            get { return bz; }
            set { bz = value; }
        }
        /// <summary>
        /// ǩ��
        /// </summary>
        public string Create_Name
        {
            get { return create_name; }
            set { create_name = value; }
        }
    }
}
