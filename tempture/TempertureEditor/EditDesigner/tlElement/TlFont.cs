using System.Drawing;

namespace TempertureEditor.EditDesigner.tlElement
{
    /// <summary>
    /// 录入栏模板字体
    /// </summary>
    public class TlFont
    {
        private string _name;
        private string _familyName;
        private float _emSize = 9.0F;
        private int _style = 0;

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

        public string FamilyName
        {
            get
            {
                return _familyName;
            }

            set
            {
                _familyName = value;
            }
        }

        public float EmSize
        {
            get
            {
                return _emSize;
            }

            set
            {
                _emSize = value;
            }
        }

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
    }
}
