using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlButtonX : TlControl
    {
        private string _image = "";

        public string Image
        {
            get
            {
                return _image;
            }

            set
            {
                _image = value;
            }
        }
    }
}
