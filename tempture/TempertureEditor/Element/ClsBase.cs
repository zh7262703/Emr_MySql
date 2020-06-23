namespace TempertureEditor.Element
{
    /// <summary>
    /// 基础元素
    /// </summary>
    public class ClsBase
    {
        private string _id;
        private float _x1;
        private float _y1;
        private float _x2;
        private float _y2;
        private string _direction; //文字方向
        private int _times;      //出现频次 x 或 y
        private float _spans;    //间隔大小
       

        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        /// <summary>
        /// 起始坐标X
        /// </summary>
        public float X1
        {
            get
            {
                return _x1;
            }

            set
            {
                _x1 = value;
            }
        }

        /// <summary>
        /// 起始坐标Y
        /// </summary>
        public float Y1
        {
            get
            {
                return _y1;
            }

            set
            {
                _y1 = value;
            }
        }

        /// <summary>
        /// 结束X
        /// </summary>
        public float X2
        {
            get
            {
                return _x2;
            }

            set
            {
                _x2 = value;
            }
        }

        /// <summary>
        /// 结束Y
        /// </summary>
        public float Y2
        {
            get
            {
                return _y2;
            }

            set
            {
                _y2 = value;
            }
        }

        /// <summary>
        /// 方向
        /// </summary>
        public string Direction
        {
            get
            {
                return _direction;
            }

            set
            {
                _direction = value;
            }
        }

        /// <summary>
        /// 频次
        /// </summary>
        public int Times
        {
            get
            {
                return _times;
            }

            set
            {
                _times = value;
            }
        }

        /// <summary>
        /// 间隔大小
        /// </summary>
        public float Spans
        {
            get
            {
                return _spans;
            }

            set
            {
                _spans = value;
            }
        }
       
    }
}
