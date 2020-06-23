using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// ÏûÏ¢Àà
    /// 
    /// </summary>
    public class Class_Message
    {
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private string pid;

        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        private string patient_name;

        public string Patient_name
        {
            get { return patient_name; }
            set { patient_name = value; }
        }
        private string in_time;

        public string In_time
        {
            get { return in_time; }
            set { in_time = value; }
        }
        private string receive_user;

        public string Receive_user
        {
            get { return receive_user; }
            set { receive_user = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }
        private string add_time;

        public string Add_time
        {
            get { return add_time; }
            set { add_time = value; }
        }
        private string operator_user;

        public string Operator_user
        {
            get { return operator_user; }
            set { operator_user = value; }
        }
    }
}
