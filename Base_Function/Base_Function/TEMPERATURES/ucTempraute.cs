using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
using TempertureEditor.Tempreture_Management;

namespace Base_Function.TEMPERATURES
{
    public partial class ucTempraute : UserControl
    {       
        string Pid;
        string Id;
        string BedNo;
        string Name;
        string Sex;
        string Age;
        string Section;
        string Ward;
        string In_time;
        string Medicare_no;
        bool IsChild = false;
        InPatientInfo currentPatient;
        public ucTempraute(InPatientInfo info)//string pid,string medicare_no, string id, string bedNo, string name, string sex, string age, string section, string ward, string in_time)
        {
            InitializeComponent();
            currentPatient = info;
            string age = currentPatient.Age;
            string Age_Child = DataInit.GetAge(currentPatient.Id.ToString());
            if (string.IsNullOrEmpty(age) || age.Equals("0岁"))
            {
                Age = Age_Child;
            }
            if (currentPatient.PId.Contains("_"))
            {
                IsChild = true;
            }
            else 
            {
                if (Age_Child.Contains("天"))
                    Age_Child = Age_Child.Replace("天", "");

                if (Age_Child.Contains("小时")||Age_Child.Contains("分")||(App.IsNumeric(Age_Child) && Convert.ToInt32(Age_Child) < 28))
                    IsChild = true;
                else
                    IsChild = false;
            }
        }

        private void radioButton_Edit_CheckedChanged(object sender, EventArgs e)
        {
            groupPanel2.Controls.Clear();
            bool isEdit = false;

            if (radioButton_Edit.Checked)
            {
                isEdit = true;
            }
            if (IsChild)
            {
                TempertureEditor.ucTempraute uc = new TempertureEditor.ucTempraute(currentPatient, tempetureDataComm.TEMPLATE_CHILD, isEdit);
                uc.Dock = DockStyle.Fill;
                App.UsControlStyle(uc);
                groupPanel2.Controls.Add(uc);
            }
            else
            {
                TempertureEditor.ucTempraute uc = new TempertureEditor.ucTempraute(currentPatient, tempetureDataComm.TEMPLATE_NORMAL, isEdit);
                uc.Dock = DockStyle.Fill;
                App.UsControlStyle(uc);
                groupPanel2.Controls.Add(uc);
            }
            

            //if (radioButton_Edit.Checked)
            //{

            //    if (IsChild)
            //    {
            //        //ucTempratureEdit_Child uc = new ucTempratureEdit_Child(Pid,Medicare_no, Id, BedNo, Name, Sex, Age, Section, Ward, In_time);
            //        StrType="tempetureDataComm.TEMPLATE_CHILD";
            //        isEdit =true;
            //    }
            //    else
            //    {
            //        //ucTempratureEdit uc = new ucTempratureEdit(Pid,Medicare_no, Id, BedNo, Name, Sex, Age, Section, Ward, In_time);
            //        TempertureEditor.ucTempraute uc = new TempertureEditor.ucTempraute(currentPatient, "tempetureDataComm.TEMPLATE_NORMAL",true);
            //        uc.Dock = DockStyle.Fill;
            //        App.UsControlStyle(uc);
            //        groupPanel2.Controls.Add(uc);
            //    }               
            //}
            //else
            //{
            //    //ucTemperPrint uc = new ucTemperPrint(Pid, Medicare_no,Id, BedNo, Name, Sex, Age, Section, Ward, In_time);

            //    ucTemperPrintDataLoad uc = new ucTemperPrintDataLoad(currentPatient);
            //    uc.Dock = DockStyle.Fill;
            //    App.UsControlStyle(uc);
            //    groupPanel2.Controls.Add(uc);
            //}

        }

        private void ucTempraute_Load(object sender, EventArgs e)
        {
             radioButton_Edit_CheckedChanged(sender,e);
        }

        /// <summary>
        /// 测试儿童体温单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //frmTEST fc = new frmTEST(Pid,Medicare_no, Id, BedNo, Name, Sex, Age, Section, Ward, In_time);
            //fc.Show();
            
        }
    }
}
