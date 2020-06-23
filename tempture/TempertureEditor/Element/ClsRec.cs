using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TempertureEditor.Element
{
    public class ClsRec
    {
        private string _id;
        private string _penid;
        private Rectangle _rec;

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

        public Rectangle Rec
        {
            get
            {
                return _rec;
            }

            set
            {
                _rec = value;
            }
        }
    }
}
