using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
   public class Class_Grade
    {
        private string id;
        private string person_in_charge;
        private string pidname;
        private string pids;
        private string beds;
        private double book_type;
        private double book_weizhong;
        private double total;
        private string sick_id;
        private string sick_name;
        private string section_id;
        private string section_name;
        private string look_over;
        private string sum_number;

       

       /// <summary>
       /// 编号
       /// </summary>
       public string Id
       {
           get { return id; }
           set { id = value; }
       }
       /// <summary>
       /// 责任人
       /// </summary>
       public string Person_in_charge
       {
           get { return person_in_charge; }
           set { person_in_charge = value; }
       }
       /// <summary>
       /// 患者姓名
       /// </summary>
       public string Pidname
       {
           get { return pidname; }
           set { pidname = value; }
       }
       /// <summary>
       /// 病案号
       /// </summary>
       public string Pids
       {
           get { return pids; }
           set { pids = value; }
       }
       /// <summary>
       /// 床号
       /// </summary>
       public string Beds
       {
           get { return beds; }
           set { beds = value; }
       }
  
       /// <summary>
       /// 体温
       /// </summary>
       public double Book_type
       {
           get { return book_type; }
           set { book_type = value; }
       }
       /// <summary>
       /// 危重
       /// </summary>
       public double Book_weizhong
       {
           get { return book_weizhong; }
           set { book_weizhong = value; }
       }
       /// <summary>
       /// 合计
       /// </summary>
       public double Total
        {
            get { return total; }
            set { total = value; }
        }
        /// <summary>
        /// 病区ID
        /// </summary>
        public string Sick_id
        {
            get { return sick_id; }
            set { sick_id = value; }
        }
        /// <summary>
        /// 病区名称
        /// </summary>
        public string Sick_name
        {
            get { return sick_name; }
            set { sick_name = value; }
        }
        /// <summary>
        /// 科室ID
        /// </summary>
        public string Section_id
        {
            get { return section_id; }
            set { section_id = value; }
        }
        /// <summary>
        /// 科室名称
        /// </summary>
        public string Section_name
        {
            get { return section_name; }
            set { section_name = value; }
        }
        /// <summary>
        /// 查看
        /// </summary>
        public string Look_over
        {
            get { return look_over; }
            set { look_over = value; }
        }
       /// <summary>
       /// 总和
       /// </summary>
       public string Sum_number
       {
           get { return sum_number; }
           set { sum_number = value; }
       }

    }
}
