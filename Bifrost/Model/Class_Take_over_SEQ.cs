using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   /// <summary>
   /// ��α�
   /// </summary>
    public class Class_Take_over_SEQ
    {
        private string id;
  
        private string seq;

        private string begin_time;
   
        private string end_time;
     
        private string begin_logic;
   
        private string end_logic;
        /// <summary>
        /// ���ID
        /// </summary>
        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// ��δ���
        /// </summary>
        public string Seq
        {
            get { return seq; }
            set { seq = value; }
        }
        /// <summary>
        /// ��ε���ʼʱ��
        /// </summary>
        public string Begin_time
        {
            get { return begin_time; }
            set { begin_time = value; }
        }
        /// <summary>
        /// ��εĽ���ʱ��
        /// </summary>
        public string End_time
        {
            get { return end_time; }
            set { end_time = value; }
        }
        /// <summary>
        ///  ��ε���ʼ��������
        /// </summary>
        public string Begin_logic
        {
            get { return begin_logic; }
            set { begin_logic = value; }
        }
        /// <summary>
        /// ��εĽ�����������
        /// </summary>
        public string End_logic
        {
            get { return end_logic; }
            set { end_logic = value; }
        }
    }
}
