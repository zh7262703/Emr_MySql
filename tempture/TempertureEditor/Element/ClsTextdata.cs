using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 文字类型数据
    /// </summary>
    public class ClsTextdata
    {        
        private string _name;
        private float _x;
        private float _y;
        private int _twidth;
        private int _theight;
        private string _texttype;
        private string _fontid;
        private string _tdirection;
        private string _align;
        private string _changecolorstr;
        private string _changecolorfontid;
        private string _positiontype;
        public string Name
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

        public float X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }

        public int Twidth
        {
            get
            {
                return _twidth;
            }

            set
            {
                _twidth = value;
            }
        }

        public int Theight
        {
            get
            {
                return _theight;
            }

            set
            {
                _theight = value;
            }
        }

        public string Texttype
        {
            get
            {
                return _texttype;
            }

            set
            {
                _texttype = value;
            }
        }

        public string Fontid
        {
            get
            {
                return _fontid;
            }

            set
            {
                _fontid = value;
            }
        }

        public string Tdirection
        {
            get
            {
                return _tdirection;
            }

            set
            {
                _tdirection = value;
            }
        }

        public string Align
        {
            get
            {
                return _align;
            }

            set
            {
                _align = value;
            }
        }

        public string Changecolorstr
        {
            get
            {
                return _changecolorstr;
            }

            set
            {
                _changecolorstr = value;
            }
        }

        public string Changecolorfontid
        {
            get
            {
                return _changecolorfontid;
            }

            set
            {
                _changecolorfontid = value;
            }
        }

        public string Positiontype
        {
            get
            {
                return _positiontype;
            }

            set
            {
                _positiontype = value;
            }
        }
    }
}
