using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlPanelControl : TlPanel
    {
        private bool _showFocusRectangle = false;
        private int _colorSchemeStyle = 4;
        private Color _canvasColor = SystemColors.Control;

        public bool ShowFocusRectangle
        {
            get
            {
                return _showFocusRectangle;
            }

            set
            {
                _showFocusRectangle = value;
            }
        }

        public int ColorSchemeStyle
        {
            get
            {
                return _colorSchemeStyle;
            }

            set
            {
                _colorSchemeStyle = value;
            }
        }

        public Color CanvasColor
        {
            get
            {
                return _canvasColor;
            }

            set
            {
                _canvasColor = value;
            }
        }
    }
}
