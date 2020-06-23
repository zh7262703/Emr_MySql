using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 血糖监测单
    /// </summary>
    public class Class_Bgrecode
    {
        private string date;

        private string limosis;
    
        private string limosis_tosign;
  
        private string breakfast;
  
        private string breakfast_tosign;
       
        private string lunch;
      
        private string lunch_tosign;
       
        private string evening_meal;
   
        private string evening_meal_tosign;
   
        private string remarks;
     
        private string remarks_tosign;

        private string bed;
  
        private string name;
     
        private string hospital_number;
     
  
        /// <summary>
        /// 时间
        /// </summary>
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        /// <summary>
        /// 空腹
        /// </summary>
        public string Limosis
        {
            get { return limosis; }
            set { limosis = value; }
        }
        /// <summary>
        /// 空腹签名
        /// </summary>
        public string Limosis_tosign
        {
            get { return limosis_tosign; }
            set { limosis_tosign = value; }
        }
        /// <summary>
        /// 早餐2小时后
        /// </summary>
        public string Breakfast
        {
            get { return breakfast; }
            set { breakfast = value; }
        }
        /// <summary>
        /// 早餐签名
        /// </summary>
        public string Breakfast_tosign
        {
            get { return breakfast_tosign; }
            set { breakfast_tosign = value; }
        }
        /// <summary>
        /// 午餐2小时后
        /// </summary>
        public string Lunch
        {
            get { return lunch; }
            set { lunch = value; }
        }
        /// <summary>
        /// 午餐签名
        /// </summary>
        public string Lunch_tosign
        {
            get { return lunch_tosign; }
            set { lunch_tosign = value; }
        }
        /// <summary>
        /// 晚餐2小时后
        /// </summary>
        public string Evening_meal
        {
            get { return evening_meal; }
            set { evening_meal = value; }
        }
        /// <summary>
        /// 晚餐签名
        /// </summary>
        public string Evening_meal_tosign
        {
            get { return evening_meal_tosign; }
            set { evening_meal_tosign = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }
        /// <summary>
        /// 备注签名
        /// </summary>
        public string Remarks_tosign
        {
            get { return remarks_tosign; }
            set { remarks_tosign = value; }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string Hospital_number
        {
            get { return hospital_number; }
            set { hospital_number = value; }
        }
    }
}
