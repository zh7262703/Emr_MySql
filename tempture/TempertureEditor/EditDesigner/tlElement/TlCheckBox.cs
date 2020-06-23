using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlCheckBox : TlControl
    {
        private Color _foreColor = Color.Black;
        private bool _autoSize = true;
        private bool _checked = false;

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
        public bool Checked
        {
            get
            {
                return _checked;
            }

            set
            {
                _checked = value;
            }
        }
    }
}
