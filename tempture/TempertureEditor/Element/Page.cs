using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 页对象
    /// </summary>
    public class Page
    {

        private string _starttime;    //开始时间
        private string _endtime;      //结束时间

        
        private List<ClsDataObj> _objs;     //获取所有页当中的数据集合
        public List<ClsDataObj> Objs
        {
            get
            {
                return _objs;
            }

            set
            {
                _objs = value;
            }
        }

        public string Starttime
        {
            get
            {
                return _starttime;
            }

            set
            {
                _starttime = value;
            }
        }

        public string Endtime
        {
            get
            {
                return _endtime;
            }

            set
            {
                _endtime = value;
            }
        }
    }
}
