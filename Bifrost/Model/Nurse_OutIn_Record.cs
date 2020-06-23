using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   public partial class Nurse_OutIn_Record
    {
       /// <summary>
       ///  护理出入液量记录id 
       /// </summary>
        private int _id;
       /// <summary>
       /// 病人id
       /// </summary>
        private string _pid;
       /// <summary>
       /// 班次
       /// </summary>
        private string _take_Over_Seq;
       /// <summary>
       ///  记录时间
       /// </summary>
        private string _record_Time;
       /// <summary>
       ///  记录人id
       /// </summary>
        private string _record_Id;
       /// <summary>
       /// 记录人姓名
       /// </summary>
        private string _record_Name;
       /// <summary>
       /// 项目代码
       /// </summary>
        private string _item_Code;
       /// <summary>
       /// 项目值
       /// </summary>
        private string _item_Value;
       /// <summary>
       /// 项目属性
       /// </summary>
        private int _item_Attribute;

       public Nurse_OutIn_Record()
       { }

       public Nurse_OutIn_Record(int id,string pid,string take_Over_Seq,string record_Time,
                                  string record_Id,string record_Name,string item_Code,
                                  string item_Value,int item_Attribute)
       {
           this.Id = id;
           this.Pid = pid;
           this.Take_Over_Seq = take_Over_Seq;
           this.Record_Time = record_Time;
           this.Record_Id = record_Id;
           this.Record_Name = record_Name;
           this.Item_Code = item_Code;
           this.Item_Value = item_Value;
           this.Item_Attribute = item_Attribute;
       }

        public int Item_Attribute
        {
            get { return _item_Attribute; }
            set { _item_Attribute = value; }
        }
        public string Item_Value
        {
            get { return _item_Value; }
            set { _item_Value = value; }
        }
        public string Item_Code
        {
            get { return _item_Code; }
            set { _item_Code = value; }
        }
        public string Record_Name
        {
            get { return _record_Name; }
            set { _record_Name = value; }
        }

        public string Record_Id
        {
            get { return _record_Id; }
            set { _record_Id = value; }
        }
        public string Record_Time
        {
            get { return _record_Time; }
            set { _record_Time = value; }
        }
        public string Take_Over_Seq
        {
            get { return _take_Over_Seq; }
            set { _take_Over_Seq = value; }
        } 
        public string Pid
        {
            get { return _pid; }
            set { _pid = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
