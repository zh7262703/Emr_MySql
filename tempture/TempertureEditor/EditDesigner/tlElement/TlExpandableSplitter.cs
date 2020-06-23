using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlExpandableSplitter : TlControl
    {
        private int _style = 2;
        private string _expandableControl = "";

        public int Style
        {
            get
            {
                return _style;
            }

            set
            {
                _style = value;
            }
        }

        public string ExpandableControl
        {
            get
            {
                return _expandableControl;
            }

            set
            {
                _expandableControl = value;
            }
        }
    }
}
