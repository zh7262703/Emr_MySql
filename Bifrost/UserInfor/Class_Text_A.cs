using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// ������Ϣ
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-6-15
    /// </summary>
    public class Class_Text_A
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public Class_Text_A()
        { }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string isenable;

        public string Isenable
        {
            get { return isenable; }
            set { isenable = value; }
        }
        private string issimpleinstance;

        public string Issimpleinstance
        {
            get { return issimpleinstance; }
            set { issimpleinstance = value; }
        }
        private int parentid;

        public int Parentid
        {
            get { return parentid; }
            set { parentid = value; }
        }
        private string textcode;

        /// <summary>
        /// �������
        /// </summary>
        public string Textcode
        {
            get { return textcode; }
            set { textcode = value; }
        }
        private string textname;

        /// <summary>
        /// ��������
        /// </summary>
        public string Textname
        {
            get { return textname; }
            set { textname = value; }
        }
        private string txxttype;

        /// <summary>
        ///  �����ܷ���
        /// </summary>
        public string Txxttype
        {
            get { return txxttype; }
            set { txxttype = value; }
        }

        private Class_Doc_User_Range[] textranges;
        /// <summary>
        /// ����ʹ�÷�Χ
        /// </summary>
        public Class_Doc_User_Range[] TextRanges
        {
            get { return textranges; }
            set { textranges = value; }
        }
    }
}
