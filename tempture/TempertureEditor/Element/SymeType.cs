using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 点线大类
    /// </summary>
    public class SymeType
    {
        private string _name;
        private string _val;
        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string Val
        {
            get
            {
                return _val;
            }

            set
            {
                _val = value;
            }
        }
    }
}
