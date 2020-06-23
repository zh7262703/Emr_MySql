using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlPanel : TlControl
    {
        private bool _autoScroll = false;

        public bool AutoScroll
        {
            get
            {
                return _autoScroll;
            }

            set
            {
                _autoScroll = value;
            }
        }
    }
}
