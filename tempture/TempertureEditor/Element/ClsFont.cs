using System.Drawing;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 字体设置
    /// </summary>
    public class ClsFont
    {
        private string _id;
        private string _fontname;
        private float _fontsize;
        private Color _fontcolor;
        private bool _isunderline; //下划线
        private bool _isbold; //粗体
        private bool _isita; //斜体
        private string _tname;   //节点名称

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Fontname
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

        public float Fontsize
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

        public Color Fontcolor
        {
            get
            {
                return _fontcolor;
            }

            set
            {
                _fontcolor = value;
            }
        }

        public bool Isunderline
        {
            get
            {
                return _isunderline;
            }

            set
            {
                _isunderline = value;
            }
        }

        public bool Isbold
        {
            get
            {
                return _isbold;
            }

            set
            {
                _isbold = value;
            }
        }

        public bool Isita
        {
            get
            {
                return _isita;
            }

            set
            {
                _isita = value;
            }
        }

        public string Tname
        {
            get
            {
                return _tname;
            }

            set
            {
                _tname = value;
            }
        }
    }
}
