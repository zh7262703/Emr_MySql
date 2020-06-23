using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 文书类型表
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
        /// 文书编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 父节点
        /// </summary>
        public int Parentid
        {
            get { return parentid; }
            set { parentid = value; }
        }
        /// <summary>
        /// 文书代码
        /// </summary>
        public string Textcode
        {
            get { return textcode; }
            set { textcode = value; }
        }
        /// <summary>
        /// 文书名称
        /// </summary>
        public string Textname
        {
            get { return textname; }
            set { textname = value; }
        }
        /// <summary>
        /// 是否启用编辑器
        /// </summary>
        public string Isenable
        {
            get { return isenable; }
            set { isenable = value; }
        }

        /// <summary>
        /// 文书类型
        /// </summary>
        public string Txxttype
        {
            get { return txxttype; }
            set { txxttype = value; }
        }
       /// <summary>
       /// 是否单例或多例
       /// </summary>
       public string Issimpleinstance
       {
           get { return issimpleinstance; }
           set { issimpleinstance = value; }
       }
       
       /// <summary>
       /// 是否单例或多例
       /// </summary>
       public string Enable
       {
           get { return enable; }
           set { enable = value; }
       }

       /// <summary>
       /// Y已经提交 N是暂存
       /// </summary>
       public string Submitted
       {
           get { return submitted; }
           set { submitted = value; }
       }

       /// <summary>
       /// 科室代码 0表示全院 不为0表示相关的可以，如果是多个科室的话以‘，’号隔开。
       /// </summary>
       public string Sid
       {
           get { return sid; }
           set { sid = value; }
       }

       /// <summary>
       /// 排序
       /// </summary>
       public string Shownum
       {
           get { return shownum; }
           set { shownum = value; }
       }

       /// <summary>
       /// 是否需要上级医生签名 Y 是 N否
       /// </summary>
       public string Ishighersign
       {
           get { return ishighersign; }
           set { ishighersign = value; }
       }

       /// <summary>
       /// 文书范围
       /// </summary>
       public string Right_range
       {
           get { return right_range; }
           set { right_range = value; }
       }

       /// <summary>
       /// 是否需要插入时间
       /// </summary>
       public string Ishavetime
       {
           get { return ishavetime; }
           set { ishavetime = value; }
       }

       /// <summary>
       /// 窗体名称
       /// </summary>
       public string Formname
       {
           get { return formname; }
           set { formname = value; }
       }


       /// <summary>
       /// 是否常用文书
       /// </summary>
       public string Iscommon
       {
           get { return iscommon; }
           set { iscommon = value; }
       }

       /// <summary>
       /// 打印顺序
       /// </summary>
       public string Printorder
       {
           get { return printorder; }
           set { printorder = value; }
       }

       /// <summary>
       /// 是否新页
       /// </summary>
       public string Isnewpage
       {
           get { return isnewpage; }
           set { isnewpage = value; }
       }

       /// <summary>
       /// 是否需要签名
       /// </summary>
       public string Isneedsign
       {
           get { return isneedsign; }
           set { isneedsign = value; }
       }

       /// <summary>
       /// 是否提交时自动插入签名
       /// </summary>
       public string Issubmitsign
       {
           get { return issubmitsign; }
           set { issubmitsign = value; }
       }

       /// <summary>
       /// 别名
       /// </summary>
       public string Other_textname
       {
           get { return other_textname; }
           set { other_textname = value; }
       }

       /// <summary>
       /// 是否修改文书标题内容
       /// </summary>
       public string IsProblemName
       {
           get { return isProblemName; }
           set { isProblemName = value; }
       }

       /// <summary>
       /// 是否修改文书标题时间
       /// </summary>
       public string IsProblemTime
       {
           get { return isProblemTime; }
           set { isProblemTime = value; }
       }

       /// <summary>
       /// 暂存文书是否需要签名（实习生）
       /// </summary>
       public string IsTempsavesign
       {
           get { return isTempsavesign; }
           set { isTempsavesign = value; }
       }


       /// <summary>
       /// 浅拷贝使用
       /// </summary>
       /// <returns></returns>
       public object Clone()
       {
           return this.MemberwiseClone();
       } 
    }
}
