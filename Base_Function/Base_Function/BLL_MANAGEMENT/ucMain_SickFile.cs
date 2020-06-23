using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base_Function.BLL_DOCTOR.NApply_Medical_Record;
using Base_Function.BLL_DOCTOR.Doc_Return;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucMain_SickFile : UserControl
    {
        public ucMain_SickFile()
        {
            InitializeComponent();
        }

        private void frmMain1_Load(object sender, EventArgs e)
        {
            //≤°∞∏ÕÀªÿ…Û∫À
            try
            {
                App.SetToolButtonByUser("ttsbtnPrint", false);
                App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                App.SetToolButtonByUser("tsbtnTempSave", false);
                App.SetToolButtonByUser("tsbtnCommit", false);
                App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);
                App.SetToolButtonByUser("tsbtnTemplateSave", false);//±£¥Êƒ£∞Ê
                if (App.UserAccount.CurrentSelectRole.Role_type == "B")
                {
                    UcApply_DocReturn_Record_Room ucroom = new UcApply_DocReturn_Record_Room();
                    tabControlPanel24.Controls.Add(ucroom);
                    ucroom.Dock = DockStyle.Fill;
                    
                    //≤°∞∏…Í«Î…Û∫À

                    UcApply_Medical_Record_Room ucRecord = new UcApply_Medical_Record_Room();
                    tabControlPanel25.Controls.Add(ucRecord);
                    ucRecord.Dock = DockStyle.Fill;
                }
                else
                {
                    tabItem10.Visible = false;
                    tabItem26.Visible = false;
                    tabItem27.Visible = false;
                    tabItem30.Visible = false;
                }

            }
            catch (Exception ex)
            {
            }
            
          
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void coseCopyRegister1_Load(object sender, EventArgs e)
        {

        }

  
    }
}