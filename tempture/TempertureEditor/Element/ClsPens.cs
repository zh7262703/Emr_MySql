using System.Drawing;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 画笔设置
    /// </summary>
    public class ClsPens
    {
        private string _id;
        private float _pensize;
        private Color _pencolor;
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

        public float Pensize
        {
            get
            {
                return _pensize;
            }

            set
            {
                _pensize = value;
            }
        }

        public Color Pencolor
        {
            get
            {
                return _pencolor;
            }

            set
            {
                _pencolor = value;
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
