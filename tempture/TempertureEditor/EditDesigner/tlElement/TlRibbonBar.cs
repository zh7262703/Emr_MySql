using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlRibbonBar : TlControl
    {
        private int _style = 0;
        private bool _titleVisible = false;
        private bool _autoOverflowEnabled = true;
        private bool _containerControlProcessDialogKey = true;
        private List<string> _listItems = new List<string>();

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

        public bool TitleVisible
        {
            get
            {
                return _titleVisible;
            }

            set
            {
                _titleVisible = value;
            }
        }

        public bool AutoOverflowEnabled
        {
            get
            {
                return _autoOverflowEnabled;
            }

            set
            {
                _autoOverflowEnabled = value;
            }
        }

        public bool ContainerControlProcessDialogKey
        {
            get
            {
                return _containerControlProcessDialogKey;
            }

            set
            {
                _containerControlProcessDialogKey = value;
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
