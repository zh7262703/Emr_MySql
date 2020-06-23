using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using TextEditor;


namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class popupView : DevComponents.DotNetBar.Office2007Form
    {
        private string DocXml;
        int Txtid = 0;
        int Belongtosys_id = 0;
        int Sickkind_id = 0;
        string Txtname = "";
        int Tid = 0;
        InPatientInfo ifo;

        public popupView(string docxml,string tittle)
        {
            InitializeComponent();
            DocXml = docxml;
            this.Text = tittle;
            App.FormStytleSet(this, false);          
            
        }

        public popupView(int txtid, int belongtosys_id, int sickkind_id, string txtname,int tid,InPatientInfo fo, string docxml, string tittle)
        {
            InitializeComponent();
            DocXml = docxml;
            this.Text = tittle;
            Txtid = txtid;
            Belongtosys_id = belongtosys_id;
            Sickkind_id = sickkind_id;
            Txtname = txtname;
            Tid = tid;
            ifo = fo;

            App.FormStytleSet(this, false);

        }

        public popupView()
        {
            InitializeComponent();
        }
        private void popupView_Load(object sender, EventArgs e)
        {
            frmText text = new frmText(Txtid, Belongtosys_id, Sickkind_id, Txtname, Tid, ifo,false);
            XmlDocument tmpxml = new System.Xml.XmlDocument();
            tmpxml.PreserveWhitespace = true;
            string content = DocXml;
            tmpxml.LoadXml(content);
            text.MyDoc.FromXML(tmpxml.DocumentElement);
            text.MyDoc.ContentChanged();
            text.Dock = DockStyle.Fill;
            text.MyDoc.Locked = true;
            this.Controls.Add(text);
        }
    }
}