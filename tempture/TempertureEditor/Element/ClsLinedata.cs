using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 数据画线定义
    /// </summary>
    public class ClsLinedata
    {       
        private string _name;
        private float _x;
        private float _y;
        private float _span_x;
        private float _span_y;
        private string _symbolname;      
        private string _scale;
        private string _basevalue;
        private string _penid;
        private string _broken;  //事件中断处理

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

        public string Symbolname
        {
            get
            {
                return _symbolname;
            }

            set
            {
                _symbolname = value;
            }
        }

        public string Scale
        {
            get
            {
                return _scale;
            }

            set
            {
                _scale = value;
            }
        }

        public string Basevalue
        {
            get
            {
                return _basevalue;
            }

            set
            {
                _basevalue = value;
            }
        }

        public string Penid
        {
            get
            {
                return _penid;
            }

            set
            {
                _penid = value;
            }
        }

        public float Span_x
        {
            get
            {
                return _span_x;
            }

            set
            {
                _span_x = value;
            }
        }

        public float Span_y
        {
            get
            {
                return _span_y;
            }

            set
            {
                _span_y = value;
            }
        }

        public string Broken
        {
            get
            {
                return _broken;
            }

            set
            {
                _broken = value;
            }
        }
    }
}
