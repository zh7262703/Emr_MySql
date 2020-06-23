using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor.Element
{
    /// <summary>
    /// 基本病人信息
    /// </summary>
    public class patientInfo
    {
        private string _patient_name; //病人姓名
        private string _gender_code;  //性别
        private string _age;          //年龄
        private string _section_name; //科室
        private string _pid;          //住院号
        private string _in_time;      //入院时间
        private string _diagnose;     //诊断

        public string Patient_name
        {
            get
            {
                return _patient_name;
            }

            set
            {
                _patient_name = value;
            }
        }

        public string Gender_code
        {
            get
            {
                return _gender_code;
            }

            set
            {
                _gender_code = value;
            }
        }

        public string Age
        {
            get
            {
                return _age;
            }

            set
            {
                _age = value;
            }
        }

        public string Section_name
        {
            get
            {
                return _section_name;
            }

            set
            {
                _section_name = value;
            }
        }

        public string Pid
        {
            get
            {
                return _pid;
            }

            set
            {
                _pid = value;
            }
        }

        public string In_time
        {
            get
            {
                return _in_time;
            }

            set
            {
                _in_time = value;
            }
        }

        public string Diagnose
        {
            get
            {
                return _diagnose;
            }

            set
            {
                _diagnose = value;
            }
        }
    }
}
