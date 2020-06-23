using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.Tempreture_Management;
using Bifrost;
using TempertureEditor.EditDesigner;

namespace TempertureEditor
{
    public partial class frmOperaterTest : DevComponents.DotNetBar.Office2007Form
    {
        InPatientInfo currentInpo;

        public frmOperaterTest(InPatientInfo tt)
        {
            InitializeComponent();

            currentInpo = tt;
            treeView1.ExpandAll();

        }

        private void frmOperaterTest_Load(object sender, EventArgs e)
        {

        }

        private void treeView1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //try
            //{
            if (e.Node.Name == "t1")
            {
                superTabControlPanel1.Controls.Clear();
                ucTempraute tp = new ucTempraute(currentInpo, tempetureDataComm.TEMPLATE_NORMAL, true);
                tp.Dock = DockStyle.Fill;
                superTabControlPanel1.Controls.Add(tp);
            }
            else if (e.Node.Name == "t2")
            {
                superTabControlPanel1.Controls.Clear();
                ucTempraute tp = new ucTempraute(currentInpo, tempetureDataComm.TEMPLATE_BABY, true);
                tp.Dock = DockStyle.Fill;
                superTabControlPanel1.Controls.Add(tp);
            }
            else if (e.Node.Name == "t3")
            {
                superTabControlPanel1.Controls.Clear();
                ucTempraute tp = new ucTempraute(currentInpo, tempetureDataComm.TEMPLATE_CHILD, true);
                tp.Dock = DockStyle.Fill;
                superTabControlPanel1.Controls.Add(tp);
            }
            else if (e.Node.Name == "t4")
            {
                superTabControlPanel1.Controls.Clear();
                ucTempratureDataLoad_ai tp = new ucTempratureDataLoad_ai(currentInpo, "TempertureSet_newTable_ai.tmb", "TempertureSet_newTable_ai.tlmb");
                tp.Dock = DockStyle.Fill;
                superTabControlPanel1.Controls.Add(tp);
            }
            else if (e.Node.Name == "tAi")
            {
                superTabControlPanel1.Controls.Clear();
                
                ucAiTemperature tFrm = new ucAiTemperature("ucMainFrame.clmb");
                tFrm.ucMainFrame_InitData(currentInpo);

                tFrm.Dock = DockStyle.Fill;
                superTabControlPanel1.Controls.Add(tFrm);
                
             
            }
            //}
            //catch
            //{ }
        }
    }
}
