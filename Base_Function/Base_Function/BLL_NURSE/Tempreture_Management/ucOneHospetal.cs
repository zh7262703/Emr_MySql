using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using Base_Function.TEMPERATURES;


namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    public partial class ucOneHospetal : UserControl
    {
        private string pid;

        private string bed;

        private string pidname;

        private string gender;

        private string age;

        private string medicare_no;

        private string section_name;

        private string sick_name;

        private string in_time;

        private DateTime time;
        private string pids;

        ucTemperatureInfo TemperatureInfo;

        InPatientInfo currentPatient;
        /// <summary>
        /// 登记号
        /// </summary>
        public string Medicare_no
        {
            get { return medicare_no; }
            set { medicare_no = value; }
        }

        /// <summary>
        /// 住院号
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        /// <summary>
        /// 床号
        /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string Pidname
        {
            get { return pidname; }
            set { pidname = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        /// <summary>
        /// 科别
        /// </summary>
        public string Section_name
        {
            get { return section_name; }
            set { section_name = value; }
        }
        /// <summary>
        /// 病区
        /// </summary>
        public string Sick_name
        {
            get { return sick_name; }
            set { sick_name = value; }
        }
        /// <summary>
        /// 入院时间
        /// </summary>
        public string In_time
        {
            get { return in_time; }
            set { in_time = value; }
        }
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
        public string Pids
        {
            get { return pids; }
            set { pids = value; }
        }

        public ucOneHospetal()
        {
            InitializeComponent();
        }
        public ucOneHospetal(InPatientInfo info)//ucTemperatureInfo temperature, string pids,string medicare_nos, string beds, string pidnames, string gender_code, string ages, string section_names, string sick_names, string in_times, DateTime time, string pid_ids)
        {
            InitializeComponent();
            currentPatient = info;
            //TemperatureInfo = temperature;
            //this.Medicare_no = medicare_nos;
            //this.Pid = pids;
            //this.Bed = beds;
            //this.Pidname = pidnames;
            //this.gender = gender_code;
            //this.Age = ages;
            //this.Section_name = section_names;
            //this.Sick_name = sick_names;
            //this.In_time = in_times;
            //this.Time = time;
            //this.Pids=pid_ids;

            //UControl.TemperInfo fx = new UControl.TemperInfo(pids, beds, pidnames, gender_code, ages, section_names, sick_names, in_times, time);
            //this.Controls.Add(fx);
            //fx.Dock = DockStyle.Fill;
            //this.panel1.Controls.Add(new UControl.TemperInfo(pids, beds, pidnames, gender_code, ages, section_names, sick_names, in_times, time));

        }
        private void FrmOneHospetal_Load(object sender, EventArgs e)
        {

            //this.panel1.Controls.Add(new TemperInfo(Pid, Bed, Pidname, Gender, Age,Sick_name,Sick_name, In_time));
            //TemperInfo aa = new TemperInfo(TemperatureInfo,Pid, Bed, Pidname, Gender, Age, Sick_name, Sick_name, In_time, Time, Pids);            

            //ucTempraute aa = new ucTempraute(currentPatient);//Pid, Medicare_no, Pids, Bed, Pidname, Gender, Age, Sick_name, Sick_name, In_time);
            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, true);
            temper.Dock = DockStyle.Fill;
            this.Controls.Add(temper);
            App.UsControlStyle(this);
        }
    }
}