using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 文书类
    /// </summary>
    class Class_Patients_Doc
    {
        private int tid;

        /// <summary>
        /// id自增列
        /// </summary>
        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }
        private string pid;

        /// <summary>
        /// 病人主ID（HIS）
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        private string patients_Doc;

        /// <summary>
        /// 文书内容
        /// </summary>
        public string Patients_Doc
        {
            get { return patients_Doc; }
            set { patients_Doc = value; }
        }

        private string textName;

        /// <summary>
        /// 文书名字
        /// </summary>
        public string TextName
        {
            get { return textName; }
            set { textName = value; }
        }
    }
}
