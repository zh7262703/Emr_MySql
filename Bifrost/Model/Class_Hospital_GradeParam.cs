using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 病案借阅参数设置
    /// </summary>
    public class Class_Hospital_GradeParam
    {
        private int id;
   
        private string hospital_borrowtype;

        private string hospital_datetime;

        private string hospital_datetime_unit;
    
        private string outside_hospital_borrowtype;

        private string outside_hospital_datetime;
  
        private string outside_hospital_datetime_unit;
 
        private DateTime cradte_time;
 
        private DateTime update_time;
    
        private string username;
        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 院内借阅时间设置标识
        /// </summary>
        public string Hospital_borrowtype
        {
            get { return hospital_borrowtype; }
            set { hospital_borrowtype = value; }
        }
        /// <summary>
        /// 院内时间
        /// </summary>
        public string Hospital_datetime
        {
            get { return hospital_datetime; }
            set { hospital_datetime = value; }
        }
        /// <summary>
        /// 院内时间单位
        /// </summary>
        public string Hospital_datetime_unit
        {
            get { return hospital_datetime_unit; }
            set { hospital_datetime_unit = value; }
        }
        /// <summary>
        /// 院外借阅时间设置标识
        /// </summary>
        public string Outside_hospital_borrowtype
        {
            get { return outside_hospital_borrowtype; }
            set { outside_hospital_borrowtype = value; }
        }
        /// <summary>
        /// 院外时间
        /// </summary>
        public string Outside_hospital_datetime
        {
            get { return outside_hospital_datetime; }
            set { outside_hospital_datetime = value; }
        }
        /// <summary>
        /// 院外时间单位
        /// </summary>
        public string Outside_hospital_datetime_unit
        {
            get { return outside_hospital_datetime_unit; }
            set { outside_hospital_datetime_unit = value; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Cradte_time
        {
            get { return cradte_time; }
            set { cradte_time = value; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime Update_time
        {
            get { return update_time; }
            set { update_time = value; }
        }
        /// <summary>
        /// 操作者
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
    }
}
