using System.Collections.Generic;
using System.Drawing;

namespace TempertureEditor.EditDesigner.tlElement
{
    /// <summary>
    /// 录入栏模板字体
    /// </summary>
    public class TlEventHandler
    {
        private string _name;
        private List<string> _listParamTypes;
    
        public string Name
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

        public List<string> ListParamTypes
        {
            get
            {
                return _listParamTypes;
            }

            set
            {
                _listParamTypes = value;
            }
        }
    }
}
