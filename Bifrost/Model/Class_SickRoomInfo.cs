using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   /// <summary>
   /// 病房信息
   /// </summary>
   public class Class_SickRoomInfo
    {
        private int srid;
     
        private int said;
   
        private int sick_room_code;
     
        private int bedlevel;
    
        private string org_prop;
    
        private string sex_ctrl;
     
        private string sex_flag;
    
        private string enableflag;

        /// <summary>
        /// 病房ID
        /// </summary>
        public int Srid
        {
            get { return srid; }
            set { srid = value; }
        }
        /// <summary>
        /// 病区ID
        /// </summary>
        public int Said
        {
            get { return said; }
            set { said = value; }
        }
        /// <summary>
        /// 病房代码
        /// </summary>
        public int Sick_room_code
        {
            get { return sick_room_code; }
            set { sick_room_code = value; }
        }
        /// <summary>
        /// 等级
        /// </summary>
        public int Bedlevel
        {
            get { return bedlevel; }
            set { bedlevel = value; }
        }
        /// <summary>
        /// 编制
        /// </summary>
        public string Org_prop
        {
            get { return org_prop; }
            set { org_prop = value; }
        }
        /// <summary>
        /// 性别控制标志
        /// </summary>
        public string Sex_ctrl
        {
            get { return sex_ctrl; }
            set { sex_ctrl = value; }
        }
        /// <summary>
        /// 性别(当前)
        /// </summary>
        public string Sex_flag
        {
            get { return sex_flag; }
            set { sex_flag = value; }
        }
        /// <summary>
        /// 有效标志
        /// </summary>
        public string Enableflag
        {
            get { return enableflag; }
            set { enableflag = value; }
        }
    }
}
