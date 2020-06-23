using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlAdvTree : TlControl
    {
        private Color _foreColor = Color.Black;
        private bool _allowDrop = true;

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

        public bool AllowDrop
        {
            get
            {
                return _allowDrop;
            }

            set
            {
                _allowDrop = value;
            }
        }

    }
}
