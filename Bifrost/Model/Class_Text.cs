using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// �������ͱ�
    /// </summary>
   public  class Class_Text
    {
         
        private int id;

        private int parentid;
  
        private string textcode;
    
        private string textname;
     
        private string isenable;
     
        private string txxttype;

        private string issimpleinstance;

        private string enable;

        private string submitted;

        private string sid;

        private string shownum;

        private string ishighersign;

        private string right_range;

        private string ishavetime;       

        private string formname;

        private string iscommon;
      
        private string printorder;
      
        private string isnewpage;

        private string isneedsign;
    
        private string issubmitsign;

        private string other_textname;

        private string isProblemName;

        private string isProblemTime;

        private string isTempsavesign;


        /// <summary>
        /// ������
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// ���ڵ�
        /// </summary>
        public int Parentid
        {
            get { return parentid; }
            set { parentid = value; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string Textcode
        {
            get { return textcode; }
            set { textcode = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Textname
        {
            get { return textname; }
            set { textname = value; }
        }
        /// <summary>
        /// �Ƿ����ñ༭��
        /// </summary>
        public string Isenable
        {
            get { return isenable; }
            set { isenable = value; }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public string Txxttype
        {
            get { return txxttype; }
            set { txxttype = value; }
        }
       /// <summary>
       /// �Ƿ��������
       /// </summary>
       public string Issimpleinstance
       {
           get { return issimpleinstance; }
           set { issimpleinstance = value; }
       }
       
       /// <summary>
       /// �Ƿ��������
       /// </summary>
       public string Enable
       {
           get { return enable; }
           set { enable = value; }
       }

       /// <summary>
       /// Y�Ѿ��ύ N���ݴ�
       /// </summary>
       public string Submitted
       {
           get { return submitted; }
           set { submitted = value; }
       }

       /// <summary>
       /// ���Ҵ��� 0��ʾȫԺ ��Ϊ0��ʾ��صĿ��ԣ�����Ƕ�����ҵĻ��ԡ������Ÿ�����
       /// </summary>
       public string Sid
       {
           get { return sid; }
           set { sid = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string Shownum
       {
           get { return shownum; }
           set { shownum = value; }
       }

       /// <summary>
       /// �Ƿ���Ҫ�ϼ�ҽ��ǩ�� Y �� N��
       /// </summary>
       public string Ishighersign
       {
           get { return ishighersign; }
           set { ishighersign = value; }
       }

       /// <summary>
       /// ���鷶Χ
       /// </summary>
       public string Right_range
       {
           get { return right_range; }
           set { right_range = value; }
       }

       /// <summary>
       /// �Ƿ���Ҫ����ʱ��
       /// </summary>
       public string Ishavetime
       {
           get { return ishavetime; }
           set { ishavetime = value; }
       }

       /// <summary>
       /// ��������
       /// </summary>
       public string Formname
       {
           get { return formname; }
           set { formname = value; }
       }


       /// <summary>
       /// �Ƿ�������
       /// </summary>
       public string Iscommon
       {
           get { return iscommon; }
           set { iscommon = value; }
       }

       /// <summary>
       /// ��ӡ˳��
       /// </summary>
       public string Printorder
       {
           get { return printorder; }
           set { printorder = value; }
       }

       /// <summary>
       /// �Ƿ���ҳ
       /// </summary>
       public string Isnewpage
       {
           get { return isnewpage; }
           set { isnewpage = value; }
       }

       /// <summary>
       /// �Ƿ���Ҫǩ��
       /// </summary>
       public string Isneedsign
       {
           get { return isneedsign; }
           set { isneedsign = value; }
       }

       /// <summary>
       /// �Ƿ��ύʱ�Զ�����ǩ��
       /// </summary>
       public string Issubmitsign
       {
           get { return issubmitsign; }
           set { issubmitsign = value; }
       }

       /// <summary>
       /// ����
       /// </summary>
       public string Other_textname
       {
           get { return other_textname; }
           set { other_textname = value; }
       }

       /// <summary>
       /// �Ƿ��޸������������
       /// </summary>
       public string IsProblemName
       {
           get { return isProblemName; }
           set { isProblemName = value; }
       }

       /// <summary>
       /// �Ƿ��޸��������ʱ��
       /// </summary>
       public string IsProblemTime
       {
           get { return isProblemTime; }
           set { isProblemTime = value; }
       }

       /// <summary>
       /// �ݴ������Ƿ���Ҫǩ����ʵϰ����
       /// </summary>
       public string IsTempsavesign
       {
           get { return isTempsavesign; }
           set { isTempsavesign = value; }
       }


       /// <summary>
       /// ǳ����ʹ��
       /// </summary>
       /// <returns></returns>
       public object Clone()
       {
           return this.MemberwiseClone();
       } 
    }
}
