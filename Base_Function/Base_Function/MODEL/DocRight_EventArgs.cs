using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    public class DocRight_EventArgs : EventArgs
    {
        private int id;
        private string functions;

        /// <summary>
        /// ����Ȩ��
        /// </summary>
        public string Functions
        {
            get { return functions; }
            set { functions = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
