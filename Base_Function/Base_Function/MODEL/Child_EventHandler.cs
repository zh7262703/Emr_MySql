using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    public class Child_EventArgs: EventArgs
    {
        private string _state;
        private int _id;
        private string user_Id;
        //用户id
        public string User_Id
        {
            get { return user_Id; }
            set { user_Id = value; }
        }
        
        /// <summary>
        /// 病人主键
        /// </summary>
        public int Id
        {
          get { return _id; }
          set { _id = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }


    }
}
