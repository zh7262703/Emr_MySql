using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 会诊记录实体类
    /// 作者：卢星星
    /// 日期：10-05-31
    /// </summary>
    public class Consultation_Record
    {
        private int _consul_RecordId;
        private int _apply_Id;
        private int _consul_Record_SectionID;
        private int _consul_R_ID;
        private string _consul_Record_Content;
        private int _isRecieve;
        private string _consul_Time;
        private string _state;
        private string _consul_Section_Name;
        private string _consul_R_Name;
        private int _consul_Record_submite_state;
        public Consultation_Record()
        { }

        public Consultation_Record(int consul_Record,int apply_Id,int consul_Record_SectionID,
                                    int consul_R_ID,string cosul_Record_Content,int isRecieve,
            string consul_Time,string state,string consul_Section_Name,string consul_R_Name,int consul_Record_submite_state)
        {
            this.Consul_RecordId = consul_Record;
            this.Apply_Id = apply_Id;
            this.Consul_Record_SectionID = consul_Record_SectionID;
            this.Consul_R_ID = consul_R_ID;
            this.Consul_Record_Content = cosul_Record_Content;
            this.IsRecieve = isRecieve;
            this.Consul_Time = consul_Time;
            this.State = state;
            this.Consul_Section_Name = consul_Section_Name;
            this.Consul_R_Name = consul_R_Name;
            this.Consul_Record_submite_state = consul_Record_submite_state;
        }
         /// <summary>
        /// 会诊记录id,主键
        /// </summary>
        public int Consul_RecordId
        {
          get { return _consul_RecordId; }
          set { _consul_RecordId = value; }
        }
        /// <summary>
        /// 会诊申请id，外键.
        /// </summary>
        public int Apply_Id
        {
            get { return _apply_Id; }
            set { _apply_Id = value; }
        }
        /// <summary>
        /// 会诊记录科室id
        /// </summary>
        public int Consul_Record_SectionID
        {
            get { return _consul_Record_SectionID; }
            set { _consul_Record_SectionID = value; }
        }
        /// <summary>
        /// 会诊记录医师id
        /// </summary>
        public int Consul_R_ID
        {
            get { return _consul_R_ID; }
            set { _consul_R_ID = value; }
        }
        /// <summary>
        /// 会诊记录内容
        /// </summary>
        public string Consul_Record_Content
        {
            get { return _consul_Record_Content; }
            set { _consul_Record_Content = value; }
        }
        /// <summary>
        /// 是否接诊1是，0否。
        /// </summary>
        public int IsRecieve
        {
            get { return _isRecieve; }
            set { _isRecieve = value; }
        }
        /// <summary>
        /// 会诊记录创建时间
        /// </summary>
        public string Consul_Time
        {
            get { return _consul_Time; }
            set { _consul_Time = value; }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        /// <summary>
        /// 会诊记录科室名字
        /// </summary>
        public string Consul_Section_Name
        {
            get { return _consul_Section_Name; }
            set { _consul_Section_Name = value; }
        }
        /// <summary>
        /// 会诊记录医师名字
        /// </summary>
        public string Consul_R_Name
        {
            get { return _consul_R_Name; }
            set { _consul_R_Name = value; }
        }
        /// <summary>
        /// 会诊记录提交状态1结束，0未结束。
        /// </summary>
        public int Consul_Record_submite_state
        {
            get { return _consul_Record_submite_state; }
            set { _consul_Record_submite_state = value; }
        }
    }
}
