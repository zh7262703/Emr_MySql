using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 帐户表ACCOUNT
    /// 创建者：张华
    /// 创建时间：2012-10-18
    /// </summary>
    public class Class_Mr_File_Index
    {
        private string _patient_id;

        public string Patient_id
        {
            get { return _patient_id; }
            set { _patient_id = value; }
        }
        private string _visit_id;

        public string Visit_id
        {
            get { return _visit_id; }
            set { _visit_id = value; }
        }
        private string _file_no;

        public string File_no
        {
            get { return _file_no; }
            set { _file_no = value; }
        }
        private string _file_name;

        public string File_name
        {
            get { return _file_name; }
            set { _file_name = value; }
        }
        private string _topic;

        public string Topic
        {
            get { return _topic; }
            set { _topic = value; }
        }
        private string _creator_name;

        public string Creator_name
        {
            get { return _creator_name; }
            set { _creator_name = value; }
        }
        private string _creator_id;

        public string Creator_id
        {
            get { return _creator_id; }
            set { _creator_id = value; }
        }
        private string _create_date_time;

        public string Create_date_time
        {
            get { return _create_date_time; }
            set { _create_date_time = value; }
        }
        private string _last_modify_date_time;

        public string Last_modify_date_time
        {
            get { return _last_modify_date_time; }
            set { _last_modify_date_time = value; }
        }

    }
}
