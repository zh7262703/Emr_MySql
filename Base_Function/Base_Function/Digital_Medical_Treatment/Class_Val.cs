using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Digital_Medical_Treatment
{
    /// <summary>
    /// 指对象
    /// </summary>
    public class Class_Val
    {
        /// <summary>
        /// 值内容的绘制区域
        /// </summary>
        private RectangleF _reg;
        public RectangleF Reg
        {
            get { return _reg; }
            set { _reg = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        private string _tittle;
        public string Tittle
        {
            get { return _tittle; }
            set { _tittle = value; }
        }

    }
}
