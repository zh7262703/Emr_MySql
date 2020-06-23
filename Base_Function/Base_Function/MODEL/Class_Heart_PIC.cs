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
        /// 日期
        /// </summary>
        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        /// <summary>
        /// 时间
        /// </summary>
        public string Time
        {
            get { return time; }
            set { time = value; }
        }
        /// <summary>
        /// 心电 HR/次分
        /// </summary>
        public string Value_val
        {
            get { return value_val; }
            set { value_val = value; }
        }
        /// <summary>
        /// 心电示波情况
        /// </summary>
        public string BZ
        {
            get { return bz; }
            set { bz = value; }
        }
        /// <summary>
        /// 签字
        /// </summary>
        public string Create_Name
        {
            get { return create_name; }
            set { create_name = value; }
        }
    }
}
