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
       /// ���
       /// </summary>
       public string Id
       {
           get { return id; }
           set { id = value; }
       }
       /// <summary>
       /// ������
       /// </summary>
       public string Person_in_charge
       {
           get { return person_in_charge; }
           set { person_in_charge = value; }
       }
       /// <summary>
       /// ��������
       /// </summary>
       public string Pidname
       {
           get { return pidname; }
           set { pidname = value; }
       }
       /// <summary>
       /// ������
       /// </summary>
       public string Pids
       {
           get { return pids; }
           set { pids = value; }
       }
       /// <summary>
       /// ����
       /// </summary>
       public string Beds
       {
           get { return beds; }
           set { beds = value; }
       }
  
       /// <summary>
       /// ����
       /// </summary>
       public double Book_type
       {
           get { return book_type; }
           set { book_type = value; }
       }
       /// <summary>
       /// Σ��
       /// </summary>
       public double Book_weizhong
       {
           get { return book_weizhong; }
           set { book_weizhong = value; }
       }
       /// <summary>
       /// �ϼ�
       /// </summary>
       public double Total
        {
            get { return total; }
            set { total = value; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public string Sick_id
        {
            get { return sick_id; }
            set { sick_id = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Sick_name
        {
            get { return sick_name; }
            set { sick_name = value; }
        }
        /// <summary>
        /// ����ID
        /// </summary>
        public string Section_id
        {
            get { return section_id; }
            set { section_id = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Section_name
        {
            get { return section_name; }
            set { section_name = value; }
        }
        /// <summary>
        /// �鿴
        /// </summary>
        public string Look_over
        {
            get { return look_over; }
            set { look_over = value; }
        }
       /// <summary>
       /// �ܺ�
       /// </summary>
       public string Sum_number
       {
           get { return sum_number; }
           set { sum_number = value; }
       }

    }
}
