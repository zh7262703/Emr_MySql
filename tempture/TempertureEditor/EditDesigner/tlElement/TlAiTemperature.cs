using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlAiTemperature : TlControl
    {
        private string _clmbFileName = "";

        public string ClmbFileName
        {
            get
            {
                return _clmbFileName;
            }

            set
            {
                _clmbFileName = value;
            }
        }
    }
}
