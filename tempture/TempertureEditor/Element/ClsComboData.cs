using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 组合标签类型
    /// </summary>
    public class ClsComboData
    {
        private string _name;
        private string _combolsymbol;    

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


        public string combolsymbol
        {
            get
            {
                return _combolsymbol;
            }

            set
            {
                _combolsymbol = value;
            }
        }    
    }
}
