using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TempertureEditor.Element
{
    public class ClsImg
    {
        private string _id;
        private Bitmap _img;
        private string _imgname;
        private int _x;
        private int _y;
        private int _pwidth;
        private int _pheight;

        public Bitmap Img
        {
            get
            {
                return _img;
            }

            set
            {
                _img = value;
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

        public int Pwidth
        {
            get
            {
                return _pwidth;
            }

            set
            {
                _pwidth = value;
            }
        }

        public int Pheight
        {
            get
            {
                return _pheight;
            }

            set
            {
                _pheight = value;
            }
        }

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

        public string Imgname
        {
            get
            {
                return _imgname;
            }

            set
            {
                _imgname = value;
            }
        }
    }
}
