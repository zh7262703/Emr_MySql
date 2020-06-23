using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlControl
    {
        private TlControl _tlParentControl = null; //父控件
        private Color? _backColor = null;
        private string _type = "";
        private string _name = "";
        //private Point _ptLocation = new Point(0, 0);
        //private Size _size = new Size(0, 0);
        private int _x = 0;
        private int _y = 0;
        private int _width = 0;
        private int _height = 0;
        private string _text = "";
        private bool _tabStop = true;
        private int _tabIndex = 0;
        private bool _visable = true;
        private bool _enable = true;
        private string _fontName = "";
        private int _dock;
        private Dictionary<string, string> _dicEvents;

        internal TlControl TlParentControl
        {
            get
            {
                return _tlParentControl;
            }

            set
            {
                _tlParentControl = value;
            }
        }

        public Color? BackColor
        {
            get
            {
                return _backColor;
            }

            set
            {
                _backColor = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

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

        public int X
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

        public int Y
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

        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        public string Text
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
            }
        }

        public bool TabStop
        {
            get
            {
                return _tabStop;
            }

            set
            {
                _tabStop = value;
            }
        }

        public int TabIndex
        {
            get
            {
                return _tabIndex;
            }

            set
            {
                _tabIndex = value;
            }
        }

        public bool Visable
        {
            get
            {
                return _visable;
            }

            set
            {
                _visable = value;
            }
        }

        public bool Enable
        {
            get
            {
                return _enable;
            }

            set
            {
                _enable = value;
            }
        }     

        public string FontName
        {
            get
            {
                return _fontName;
            }

            set
            {
                _fontName = value;
            }
        }

        public int Dock
        {
            get
            {
                return _dock;
            }

            set
            {
                _dock = value;
            }
        }

        public Dictionary<string, string> DicEvents
        {
            get
            {
                return _dicEvents;
            }

            set
            {
                _dicEvents = value;
            }
        }

    }
}
