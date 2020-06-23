using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Bifrost
{
    /// <summary>
    /// 重写事件参数
    /// </summary>
   public class Back_EventArgers:EventArgs 
    {
        private int _id;

        private Hashtable list=new Hashtable();

        private ArrayList array_Cols = new ArrayList();
       /// <summary>
       /// 存储列集合
       /// </summary>
        public ArrayList Array_Cols
        {
            get { return array_Cols; }
            set { array_Cols = value; }
        }
        public Hashtable List
        {
            get { return list; }
            set { list = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
    }
}
