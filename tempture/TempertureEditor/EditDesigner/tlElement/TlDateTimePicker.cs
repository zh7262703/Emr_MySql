using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlDateTimePicker : TlControl
    {
        private bool _showUpDown = false;
        private int _format = 8;
        private string _customFormat = "yyyy-MM-dd HH:mm";

        public bool ShowUpDown
        {
            get
            {
                return _showUpDown;
            }

            set
            {
                _showUpDown = value;
            }
        }

        public int Format
        {
            get
            {
                return _format;
            }

            set
            {
                _format = value;
            }
        }

        public string CustomFormat
        {
            get
            {
                return _customFormat;
            }

            set
            {
                _customFormat = value;
            }
        }
    }
}
