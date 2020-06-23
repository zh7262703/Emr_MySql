using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using Base_Function.BLL_DOCTOR.UnFinished;
using Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score;

namespace Base_Function.BLL_DOCTOR
{
    public partial class frmUnWork : DevComponents.DotNetBar.Office2007Form
    {
        public InPatientInfo inpatient;
        //ucWjzJY uc;
        //ucWjzJC uc1;

        //public delegate void AddNewDoc(string tid);
        //public event AddNewDoc addnewdoc;

        public frmUnWork()
        {
            InitializeComponent();
            string user_id = App.UserAccount.UserInfo.User_id.ToString();
            string type = App.UserAccount.CurrentSelectRole.Role_type;
            if (type=="D")
            {
                tabItem4.Visible = true;
                tabItem6.Visible = false;
                string section_id = App.UserAccount.CurrentSelectRole.Section_Id.ToString();

                ucDSQWS ucD = new ucDSQWS(section_id, user_id,"");
                tabControlPanel3.Controls.Add(ucD);
                ucD.Dock = DockStyle.Fill;
                App.UsControlStyle(ucD);

                usSXZK ucS = new usSXZK(section_id, user_id,type,"");
                tabControlPanel1.Controls.Add(ucS);
                ucS.Dock = DockStyle.Fill;
                App.UsControlStyle(ucS);

                ucReceiveNotice ucR = new ucReceiveNotice();
                tabControlPanel2.Controls.Add(ucR);
                ucR.Dock = DockStyle.Fill;
                App.UsControlStyle(ucR);


                uc30day frmd = new uc30day();
                tabControlPanel4.Controls.Add(frmd);
                frmd.Dock = DockStyle.Fill;
                App.UsControlStyle(frmd);


            }
            else
            {
                tabItem4.Visible = false;
                tabItem6.Visible = true;
                tabItem2.Visible = false;
                tabItem3.Visible = false;
                string Sickarea_Id = App.UserAccount.CurrentSelectRole.Sickarea_Id.ToString();
                usSXZK ucS = new usSXZK(Sickarea_Id, user_id, type,"");
                tabControlPanel1.Controls.Add(ucS);
                ucS.Dock = DockStyle.Fill;
                App.UsControlStyle(ucS);
                
                ucElementQuality uclb = new ucElementQuality();
                tabControlPanel6.Controls.Add(uclb);
                uclb.Dock = DockStyle.Fill;
                App.UsControlStyle(uclb);
            }
            
        }

        public frmUnWork(string Sick_doctor_id)
        {
            InitializeComponent();
            


            //ucWjzZk uc2 = new ucWjzZk(Sick_doctor_id);
            //uc2.Dock = DockStyle.Fill;
            //superTabControlPanel3.Controls.Add(uc2);
            ////uc2.add += new ucWjzZk.AddNewDoc(uc2_add);
            
            
            //ucBAZG uc3 = new ucBAZG();
            //uc3.Dock = DockStyle.Fill;
            //superTabControlPanel4.Controls.Add(uc3);
        }

        public frmUnWork(InPatientInfo Info)
        {
            InitializeComponent();
            inpatient = Info;
            string patientid = inpatient.Id.ToString();
            string user_id = App.UserAccount.UserInfo.User_id.ToString();
            string type = App.UserAccount.CurrentSelectRole.Role_type;
            if (type == "D")
            {
                tabItem4.Visible = true;
                tabItem6.Visible = false;
                string section_id = App.UserAccount.CurrentSelectRole.Section_Id.ToString();

                ucDSQWS ucD = new ucDSQWS(section_id, user_id, patientid);
                tabControlPanel3.Controls.Add(ucD);
                ucD.Dock = DockStyle.Fill;
                App.UsControlStyle(ucD);

                usSXZK ucS = new usSXZK(section_id, user_id, type, patientid);
                tabControlPanel1.Controls.Add(ucS);
                ucS.Dock = DockStyle.Fill;
                App.UsControlStyle(ucS);

                ucReceiveNotice ucR = new ucReceiveNotice(patientid);
                tabControlPanel2.Controls.Add(ucR);
                ucR.Dock = DockStyle.Fill;
                App.UsControlStyle(ucR);


                uc30day frmd = new uc30day();
                tabControlPanel4.Controls.Add(frmd);
                frmd.Dock = DockStyle.Fill;
                App.UsControlStyle(frmd);
            }
            else
            {
                tabItem4.Visible = false;
                tabItem6.Visible = true;
                tabItem2.Visible = false;
                tabItem3.Visible = false;
                string Sickarea_Id = App.UserAccount.CurrentSelectRole.Sickarea_Id.ToString();
                usSXZK ucS = new usSXZK(Sickarea_Id, user_id, type, patientid);
                tabControlPanel1.Controls.Add(ucS);
                ucS.Dock = DockStyle.Fill;
                App.UsControlStyle(ucS);

                ucElementQuality uclb = new ucElementQuality();
                tabControlPanel6.Controls.Add(uclb);
                uclb.Dock = DockStyle.Fill;
                App.UsControlStyle(uclb);

            }
        }

        //void uc2_add(string tid)
        //{
        //    addnewdoc(tid);
        //}

        private void frmUnWork_Load(object sender, EventArgs e)
        {
            //superTabItem1.Text = superTabItem1.Text + "\r\n" + uc.Count.ToString();
            //superTabItem2.Text = superTabItem2.Text + "\r\n" + uc1.Count.ToString();

        }
    }
}
