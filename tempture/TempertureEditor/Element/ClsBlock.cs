using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 区域组合
    /// </summary>
    public class ClsBlock
    {
        private string _name;
        private string _showtype;
        private string _val;

        /// <summary>
        /// 区域组合名称
        /// </summary>
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

        public string Showtype
        {
            get
            {
                return _showtype;
            }

            set
            {
                _showtype = value;
            }
        }

        /// <summary>
        /// 组合点线类型
        /// </summary>
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
