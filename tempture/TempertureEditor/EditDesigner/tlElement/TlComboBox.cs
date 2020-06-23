using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlComboBox : TlControl
    {
        private int _dropDownStyle = 1;
        private List<string> _listItems = new List<string>();

        public int DropDownStyle
        {
            get
            {
                return _dropDownStyle;
            }

            set
            {
                _dropDownStyle = value;
            }
        }

        public List<string> ListItems
        {
            get
            {
                return _listItems;
            }

            set
            {
                _listItems = value;
            }
        }
    }
}
