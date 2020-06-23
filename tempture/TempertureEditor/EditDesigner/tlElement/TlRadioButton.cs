using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlRadioButton : TlControl
    {
        private Color _foreColor = Color.Black;
        private bool _autoSize = true;
        private string _text = "";
        private bool _checked = false;
        private bool _useVisualStyleBackColor = false;
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

        public bool UseVisualStyleBackColor
        {
            get
            {
                return _useVisualStyleBackColor;
            }

            set
            {
                _useVisualStyleBackColor = value;
            }
        }
    }
}
