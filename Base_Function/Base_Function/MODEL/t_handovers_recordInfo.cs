using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.MODEL
{
    public class t_handovers_recordInfo
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string bed_no;

        public string Bed_no
        {
            get { return bed_no; }
            set { bed_no = value; }
        }
        private string pid;

        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        private string diagnosis_id;

        public string Diagnosis_id
        {
            get { return diagnosis_id; }
            set { diagnosis_id = value; }
        }
        private string actiontype;

        public string Actiontype
        {
            get { return actiontype; }
            set { actiontype = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string set_yuanwai_datetime;

        public string Set_yuanwai_datetime
        {
            get { return set_yuanwai_datetime; }
            set { set_yuanwai_datetime = value; }
        }
        private string sid;

        public string Sid
        {
            get { return sid; }
            set { sid = value; }
        }
        private string nurse_id;

        public string Nurse_id
        {
            get { return nurse_id; }
            set { nurse_id = value; }
        }
        private DateTime recodertime;

        public DateTime Recodertime
        {
            get { return recodertime; }
            set { recodertime = value; }
        }
        private string daywork;

        public string Daywork
        {
            get { return daywork; }
            set { daywork = value; }
        }
    }
}
