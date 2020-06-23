using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 会诊申请实体类
    /// 作者：卢星星
    /// 日期：10-05-31
    /// </summary>
   public class Consultation_Apply
    {
        private int _id;
        private string _apply_Time;
        private string _apply_Name;
        private int _apply_SectionID;
        private int _consultation_Type;
        private int _apply_Type;
        private string _consultation_Content;
        private int _consultation_End;
        private int _isLock;
        private string _pId;
        private int _apply_UserID;
        private string _update_Time;
        private string _submited;
        private int _updateBy_ID;
        private string _updateBy_Name;
        private string _isDelete;
        private string _title;

       public Consultation_Apply()
       { }

       public Consultation_Apply(int id,string apply_Time,string apply_Name,int apply_SectionID,
                                int consultation_type,int apply_Type,string consultation_Content,
                                int consultation_End,int isLock,string pid,int apply_UserId,
                                string update_Time,string submited,int upateByID,string updateBy_Name,
                                string isDelete,string title)
       {
           this.Id = id;
           this.Apply_Time = apply_Time;
           this.Apply_Name = apply_Name;
           this.Apply_SectionID = apply_SectionID;
           this.Consultation_Type = consultation_type;
           this.Apply_Type = apply_Type;
           this.Consultation_Content = consultation_Content;
           this.Consultation_End = consultation_End;
           this.IsLock = isLock;
           this.PId = pid;
           this.Apply_UserID = apply_UserId;
           this.IsDelete = isDelete;
           this.Title = title;
       }
       /// <summary>
       /// 会诊申请id，主键
       /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// 会诊申请时间
        /// </summary>
        public string Apply_Time
        {
            get { return _apply_Time; }
            set { _apply_Time = value; }
        }
        /// <summary>
        /// 会诊申请医师的姓名
        /// </summary>
        public string Apply_Name
        {
            get { return _apply_Name; }
            set { _apply_Name = value; }
        }
        /// <summary>
        /// 会诊申请人所属科室id
        /// </summary>
        public int Apply_SectionID
        {
            get { return _apply_SectionID; }
            set { _apply_SectionID = value; }
        }
        /// <summary>
        /// 会诊类别0普，1急会诊。
        /// </summary>
        public int Consultation_Type
        {
            get { return _consultation_Type; }
            set { _consultation_Type = value; }
        }
        /// <summary>
        /// 申请类别，0本院，1外院。
        /// </summary>
        public int Apply_Type
        {
            get { return _apply_Type; }
            set { _apply_Type = value; }
        }
        /// <summary>
        /// 申请会诊内容
        /// </summary>
        public string Consultation_Content
        {
            get { return _consultation_Content; }
            set { _consultation_Content = value; }
        }
        /// <summary>
        /// 会诊是否结束?1结束,0未结束。
        /// </summary>
        public int Consultation_End
        {
            get { return _consultation_End; }
            set { _consultation_End = value; }
        }
        /// <summary>
        /// 是否锁定?1锁定,0未锁定。
        /// </summary>
        public int IsLock
        {
            get { return _isLock; }
            set { _isLock = value; }
        }
        /// <summary>
        /// 病人住院号
        /// </summary>
        public string PId
        {
            get { return _pId; }
            set { _pId = value; }
        }
        /// <summary>
        /// 会诊申请医师id
        /// </summary>
        public int Apply_UserID
        {
            get { return _apply_UserID; }
            set { _apply_UserID = value; }
        }
        /// <summary>
        /// 会诊申请修改时间
        /// </summary>
        public string Update_Time
        {
            get { return _update_Time; }
            set { _update_Time = value; }
        }
        /// <summary>
        /// 会诊申请提交状态
        /// </summary>
        public string Submited
        {
            get { return _submited; }
            set { _submited = value; }
        }
        /// <summary>
        /// 会诊申请修改医师id
        /// </summary>
        public int UpdateBy_ID
        {
            get { return _updateBy_ID; }
            set { _updateBy_ID = value; }
        }
        /// <summary>
        /// 会诊申请修改医师姓名
        /// </summary>
        public string UpdateBy_Name
        {
            get { return _updateBy_Name; }
            set { _updateBy_Name = value; }
        }
        /// <summary>
        /// 是否已删除1删除，0未删除
        /// </summary>
        public string IsDelete
        {
            get { return _isDelete; }
            set { _isDelete = value; }
        }
        /// <summary>
        /// 会诊申请标题
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
    }
}
