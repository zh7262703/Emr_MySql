using Bifrost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.EditDesigner;
using TempertureEditor.Tempreture_Management;

namespace TempertureEditor
{
    public partial class frmMainSelect : DevComponents.DotNetBar.Office2007Form
    {
        public frmMainSelect()
        {
            InitializeComponent();
        }

        private void btnTemplateEdit_Click(object sender, EventArgs e)
        {
            frmTempertureEditor fc = new frmTempertureEditor();
            fc.ShowDialog();
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
           
            frmUser fc = new frmUser();
            fc.ShowDialog();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmInputAll frm = new frmInputAll();
            frm.ShowDialog();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            //IDesignerHostExampleComponent com = new IDesignerHostExampleComponent() ;
            //IDesignerHostExampleDesigner designer = new IDesignerHostExampleDesigner();

            //designer.Initialize(com);
            //designer.DoDefaultAction();

            DateTime dtEvent = Convert.ToDateTime("2017-11-17 01:28");


            InPatientInfo tPat = tempetureDataComm.GetInpatientInfoByPid("12283022");
            tempetureDataComm.InsertAutoOptEvent(tPat, dtEvent, "入院", tempetureDataComm.TEMPLATE_NORMAL);
        }

        private void frmMainSelect_Load(object sender, EventArgs e)
        {
            App.Ini();
        }
    }
}
