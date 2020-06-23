using System.Drawing;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 体温单主区域
    /// </summary>
    public class ClsMainFrame
    {

        private int _twidth;     //主区域宽
        private int _theight;    //主区域高
        private int _day_x;      //天起始X
        private int _day_y;      //天起始Y
        private int _daywidth;   //天宽度
        private int _timewidth;  //时间宽度

        public int Twidth
        {
            get
            {
                return _twidth;
            }

            set
            {
                _twidth = value;
            }
        }

        public int Theight
        {
            get
            {
                return _theight;
            }

            set
            {
                _theight = value;
            }
        }

        public int Day_x
        {
            get
            {
                return _day_x;
            }

            set
            {
                _day_x = value;
            }
        }

        public int Day_y
        {
            get
            {
                return _day_y;
            }

            set
            {
                _day_y = value;
            }
        }

        public int Daywidth
        {
            get
            {
                return _daywidth;
            }

            set
            {
                _daywidth = value;
            }
        }

        public int Timewidth
        {
            get
            {
                return _timewidth;
            }

            set
            {
                _timewidth = value;
            }
        }
    }
}
