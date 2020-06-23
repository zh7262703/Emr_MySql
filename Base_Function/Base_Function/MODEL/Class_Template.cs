using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    /// <summary>
    /// 模板类
    /// </summary>
    public class Class_Template
    {
        //模版ID
        private int tid;

        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }

        //模版名字
        private string tname;

        public string Tname
        {
            get { return tname; }
            set { tname = value; }
        }

        //模板类型
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

        //模版内容
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

    }
}
