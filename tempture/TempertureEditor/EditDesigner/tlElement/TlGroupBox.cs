using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlGroupBox : TlControl
    {
        private Color _foreColor = Color.White;
        private string _text = "";

        public Color ForeColor
        {
            get
            {
                return _foreColor;
            }

            set
            {
                _foreColor = value;
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
    }
}
