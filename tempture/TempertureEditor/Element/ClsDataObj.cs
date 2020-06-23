using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 数据对象
    /// </summary>
    public class ClsDataObj
    {
        private string val; //值
        private string _typename; //类型名称
        private float _x;   //X
        private float _y;   //X
        private string _rdatatime; //记录时间   
        private Comm cm;

        public ClsDataObj(Comm tcm)
        {
            cm = tcm;
        }

        public string Val
        {
            get
            {
                return val;
            }

            set
            {
                val = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }       

        /// <summary>
        /// 记录时间
        /// </summary>
        public string Rdatatime
        {
            get
            {
                return _rdatatime;
            }

            set
            {
                _rdatatime = value;
            }
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string Typename
        {
            get
            {
                return _typename;
            }

            set
            {
                _typename = value;
            }
        }

        /// <summary>
        /// 确定相关坐标
        /// </summary>
        /// <param name="pagestarttime"></param>
        public void setdataxy(string pagestarttime)
        {
            object typeobj = cm.GetVDataSetByName(this.Typename);
            if (typeobj == null)
                return;
            if (typeobj.ToString().Contains("ClsLinedata"))
            {
                ClsLinedata tempc = (ClsLinedata)typeobj;
                this.X = tempc.X;
                this.Y = tempc.Y;
            }
            else if (typeobj.ToString().Contains("ClsTextdata"))
            {
                ClsTextdata tempc = (ClsTextdata)typeobj;
                this.X = tempc.X;
                this.Y = tempc.Y;
            }
            if(cm.Day_Width>cm.Time_width && this.Rdatatime != "")
                cm.SetDrawDayTimePoint(pagestarttime, this.Rdatatime, this);         
        }
    }
}
