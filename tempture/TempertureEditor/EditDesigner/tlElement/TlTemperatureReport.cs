using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlTemperatureReport : TlControl
    {
        private string _tmbFileName = "";

        public string TmbFileName
        {
            get
            {
                return _tmbFileName;
            }

            set
            {
                _tmbFileName = value;
            }
        }
    }
}
