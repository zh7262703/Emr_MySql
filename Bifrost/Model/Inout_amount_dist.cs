using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 护理记录单字典表
    /// </summary>
    public class Inout_amount_dist
    {
        /// <summary>
        /// 子增id
        /// </summary>
        private int _id;
        /// <summary>
        /// 项目代码
        /// </summary>
        private string _item_code;
        /// <summary>
        /// 项目名称
        /// </summary>
        private string _item_name;
        /// <summary>
        /// 项目值类型
        /// </summary>
        private string _item_value_type;
        /// <summary>
        /// 项目单位
        /// </summary>
        private string _item_unit;
        /// <summary>
        /// 显示顺序
        /// </summary>
        private int _display_seq;
        /// <summary>
        /// 汇总标记
        /// </summary>
        private string _amount_flag;
        /// <summary>
        /// 项目分类
        /// </summary>
        private int _item_type;
        /// <summary>
        /// 项目方式
        /// </summary>
        private int _item_mode;
        /// <summary>
        /// 项目属性
        /// </summary>
        private int _drainage_attribute;


        public Inout_amount_dist()
        { }

        public Inout_amount_dist(int id,string item_code,string item_name,string item_value_type,string item_unit,
                                int display_seq,string amount_flag,int item_type,int item_mode,int drainage_attribute)
        {
            this.Id = id;
            this.Item_code = item_code;
            this.Item_name = item_name;
            this.Item_value_type = item_value_type;
            this.Item_unit = item_unit;
            this.Display_seq = display_seq;
            this.Amount_flag = amount_flag;
            this.Item_type = item_type;
            this.Item_mode = item_mode;
            this.Drainage_attribute = drainage_attribute;
        }
        public int Drainage_attribute
        {
            get { return _drainage_attribute; }
            set { _drainage_attribute = value; }
        }

        public int Item_mode
        {
            get { return _item_mode; }
            set { _item_mode = value; }
        }

        public int Item_type
        {
            get { return _item_type; }
            set { _item_type = value; }
        }

        public string Amount_flag
        {
            get { return _amount_flag; }
            set { _amount_flag = value; }
        }

        public int Display_seq
        {
            get { return _display_seq; }
            set { _display_seq = value; }
        }

        public string Item_unit
        {
            get { return _item_unit; }
            set { _item_unit = value; }
        }

        public string Item_value_type
        {
            get { return _item_value_type; }
            set { _item_value_type = value; }
        }

        public string Item_name
        {
            get { return _item_name; }
            set { _item_name = value; }
        }

        public string Item_code
        {
            get { return _item_code; }
            set { _item_code = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
