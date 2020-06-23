using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor.EditDesigner.tlElement
{
    class TlSlider : TlControl
    {
        private int _minimum = 0;
        private int _maximum = 100;
        private int _value = 0;
        private string _text = "";

        public int Minimum
        {
            get
            {
                return _minimum;
            }

            set
            {
                _minimum = value;
            }
        }

        public int Maximum
        {
            get
            {
                return _maximum;
            }

            set
            {
                _maximum = value;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        public string Text1
        {
            get
            {
                return _text;
            }

            set
            {
                _text = value;
            }
        }
    }
}
