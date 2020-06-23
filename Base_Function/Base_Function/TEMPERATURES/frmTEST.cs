using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.TEMPERATURES
{
    public partial class frmTEST : Form
    {

        string Pid;
        string Id;
        string BedNo;
        string Name;
        string Sex;
        string Age;
        string Section;
        string Medicare_no;
        string Ward;
        string In_time;

        public frmTEST(string pid, string medicare_no,string id, string bedNo, string name, string sex, string age, string section, string ward, string in_time)
        {
            InitializeComponent();
            Pid = pid;
            Id = id;
            BedNo = bedNo;
            Name = name;
            Sex = sex;
            Age = age;
            Section = section;
            Ward = ward;
            In_time = in_time;
            Medicare_no = medicare_no;
        }


        public frmTEST()
        {
            InitializeComponent();
            App.Ini();
            Pid = "0013118800";
            Id = "23137";
            BedNo = "01";
            Name = "��ʯ��";
            Sex = "0";
            Age = "50��";
            Section = "��Ժ�����ڿ�һ��";
            Ward = "��Ժ��ʮ����";
            In_time = "2013-12-02 15:43";
        }


        private void frmTEST_Load(object sender, EventArgs e)
        {                       
            ucTempratureEdit_Child uc = new ucTempratureEdit_Child(Pid,Medicare_no, Id, BedNo, Name, Sex, Age, Section, Ward, In_time);
            uc.Dock = DockStyle.Fill;           
            this.Controls.Add(uc);
        }

    }
}