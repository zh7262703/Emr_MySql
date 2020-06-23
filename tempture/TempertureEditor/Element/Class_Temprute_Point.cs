using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 体温单 点 的信息
    /// </summary>
    public class Class_Temprute_Point
    {
        private string _val;   //点的值
        public string Val
        {
            get { return _val; }
            set { _val = value; }
        }
        private float _x;        //点的坐标 X
        public float X
        {
            get { return _x; }
            set { _x = value; }
        }
        private float _y;        //点的坐标 Y

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }
        private int _pointtype;//点的类型

        public int Pointtype
        {
            get { return _pointtype; }
            set { _pointtype = value; }
        }
        private int _width;    //宽度

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        private int _height;   //高度
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// 区域碰撞检测
        /// </summary>
        /// <param name="Mouse_x"></param>
        /// <param name="Mouse_y"></param>
        /// <returns></returns>
        public bool isCrush(int Mouse_x,int Mouse_y)
        {
            if (Mouse_x >= this.X-5 && Mouse_x <= this.X + 15)
            {
                if (Mouse_y >= this.Y-5 && Mouse_y <= this.Y+15)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
