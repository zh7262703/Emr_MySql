using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// ģ����
    /// </summary>
    public class Class_Template
    {
        //ģ��ID
        private int tid;

        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }

        //ģ������
        private string tname;

        public string Tname
        {
            get { return tname; }
            set { tname = value; }
        }

        //ģ������
        private int textType;

        public int TextType
        {
            get { return textType; }
            set { textType = value; }
        }

        private string tempplate_level;

        public string Tempplate_level
        {
            get { return tempplate_level; }
            set { tempplate_level = value; }
        }

        //ģ������
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

    }
}
