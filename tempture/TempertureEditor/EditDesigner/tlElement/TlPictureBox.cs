using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlPictureBox : TlControl
    {
        private Color _backColor = Color.White;

        public Color BackColor
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
    }
}
