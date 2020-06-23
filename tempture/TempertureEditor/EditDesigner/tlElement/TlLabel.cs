using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlLabel : TlControl
    {
        private Color _foreColor = Color.Black;
        private bool _autoSize = true;
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

        public bool AutoSize
        {
            get
            {
                return _autoSize;
            }

            set
            {
                _autoSize = value;
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
