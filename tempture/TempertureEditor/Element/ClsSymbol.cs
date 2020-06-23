using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 图形标签设置
    /// </summary>
    public class ClsSymbol
    {
        private string _name;    //名称
        private string _symbol1; //标签1
        private string _symbol2; //标签2
        private string _symbol3; //标签3
        private string _color;   //颜色
        private string _color2;   //颜色
        private string _fontname;//字体
        private string _fontsize;//字体大小
        private bool _blackcolor;//是否底色
        private int _cx;
        private int _cy;
        private string _cfontsize;


        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string symbol1
        {
            get
            {
                return _symbol1;
            }

            set
            {
                _symbol1 = value;
            }
        }

        public string symbol2
        {
            get
            {
                return _symbol2;
            }

            set
            {
                _symbol2 = value;
            }
        }

        public string symbol3
        {
            get
            {
                return _symbol3;
            }

            set
            {
                _symbol3 = value;
            }
        }

        public string color
        {
            get
            {
                return _color;
            }

            set
            {
                _color = value;
            }
        }

        public string fontname
        {
            get
            {
                return _fontname;
            }

            set
            {
                _fontname = value;
            }
        }

        public string fontsize
        {
            get
            {
                return _fontsize;
            }

            set
            {
                _fontsize = value;
            }
        }

        public bool blackcolor
        {
            get
            {
                return _blackcolor;
            }

            set
            {
                _blackcolor = value;
            }
        }

        public int cx
        {
            get
            {
                return _cx;
            }

            set
            {
                _cx = value;
            }
        }

        public int cy
        {
            get
            {
                return _cy;
            }

            set
            {
                _cy = value;
            }
        }

        public string cfontsize
        {
            get
            {
                return _cfontsize;
            }

            set
            {
                _cfontsize = value;
            }
        }

        public string color2
        {
            get
            {
                return _color2;
            }

            set
            {
                _color2 = value;
            }
        }
    }
}
