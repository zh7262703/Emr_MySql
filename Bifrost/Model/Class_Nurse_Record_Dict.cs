using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 护理标记记录表
    /// </summary>
    public  class Class_Nurse_Record_Dict
    {
        private int id;
    
        private string item_code;
       
        private string item_name;
     
        private string item_value_kind;
      
        private string item_unit;
       
        private int display_index;
  
        private string has_sum;

        private int   item_type;

        private int item_attribute;

        /// <summary>
        ///护理标记记录ID 
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 项目代码
        /// </summary>
        public string Item_code
        {
            get { return item_code; }
            set { item_code = value; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Item_name
        {
            get { return item_name; }
            set { item_name = value; }
        }
        /// <summary>
        /// 项目值类型
        /// </summary>
        public string Item_value_kind
        {
            get { return item_value_kind; }
            set { item_value_kind = value; }
        }
        /// <summary>
        /// 项目单位
        /// </summary>
        public string Item_unit
        {
            get { return item_unit; }
            set { item_unit = value; }
        }
        /// <summary>
        /// 显示顺序
        /// </summary>
        public int Display_index
        {
            get { return display_index; }
            set { display_index = value; }
        }
        /// <summary>
        /// 汇总标记
        /// </summary>
        public string Has_sum
        {
            get { return has_sum; }
            set { has_sum = value; }
        }
        /// <summary>
        /// 项目类别
        /// </summary>
        public int  Item_type
        {
            get { return item_type; }
            set { item_type = value; }
        }
        /// <summary>
        /// 项目属性
        /// </summary>
        public int Item_attribute
        {
            get { return item_attribute; }
            set { item_attribute = value; }
        }
 
    }
}
