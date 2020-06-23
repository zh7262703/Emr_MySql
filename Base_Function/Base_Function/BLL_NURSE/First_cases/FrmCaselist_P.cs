using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_DOCTOR;

namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class FrmCaselist_P : DevComponents.DotNetBar.Office2007Form
    {
        private string PID="";
        private string Name_hospital="";
        string sql = "";
        DataSet ds;
        public FrmCaselist_P()
        {
            InitializeComponent();
           
        }
        //,string names
        public FrmCaselist_P(string pid)
        {
            InitializeComponent();
            this.PID = pid;
            //Name_hospital = names;
           
        }

        private void FrmCaselist_Load(object sender, EventArgs e)
        {
            ShowData();
            //c1FlexGrid1.MouseDoubleClick += new MouseEventHandler(c1FlexGrid1_MouseDoubleClick);

            //c1FlexGrid1.AllowEditing = false;
        }
        private void ShowData()
        {
            sql = "select DIAGNOSE_CODE as ICD_10±‡¬Î,DIAGNOSE_NAME as ’Ô∂œ√˚,ID from t_diagnose_item ";
            string sqls = sql + " where PATIENT_ID='" + PID + "'";

             ds = App.GetDataSet(sqls);
             if (ds != null)
             {
                
                 DataColumn selectionCol = new DataColumn("—°‘Ò", typeof(bool));
                 selectionCol.DefaultValue = false;                 
                 ds.Tables[0].Columns.Add(selectionCol);               
                 c1FlexGrid1.DataSource = ds.Tables[0].DefaultView;                
                 c1FlexGrid1.Cols["—°‘Ò"].Move(1);

                 for (int i = 0; i < c1FlexGrid1.Cols.Count; i++)
                 {
                     if (c1FlexGrid1.Cols[i].Name=="—°‘Ò")
                     c1FlexGrid1.Cols[i].AllowEditing = true;
                     else
                     c1FlexGrid1.Cols[i].AllowEditing = false;
                 }
             }
        }

        //private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (c1FlexGrid1.Rows.Count > 0)
        //        {
        //            string name = "";
        //            name = c1FlexGrid1[c1FlexGrid1.RowSel, 2].ToString();
        //            frmCases_First.Dename = name;
        //            frmCases_First fs = new frmCases_First();
        //            fs.Show();
        //            this.Close();
        //            //return;
        //        }
        //    }
        //    catch
        //    {
        //    }            
        //}

        private void FrmCaselist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void c1FlexGrid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    if (c1FlexGrid1.RowSel > 0)
            //    {
            //        //if (ds != null && ds.Tables[0].Rows.Count > 0)
            //        //{
            //            string ICD_10 = "";
            //            string name = "";
            //            ICD_10 = c1FlexGrid1[c1FlexGrid1.RowSel, "ICD_10±‡¬Î"].ToString();
            //            name = c1FlexGrid1[c1FlexGrid1.RowSel, "’Ô∂œ√˚"].ToString();
                     
            //            //TemperControl(name, Name_hospital);
                       
            //            this.Close();
            //            //return;
            //        //}
            //    }
            //}
            //catch
            //{
            //}
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ucDIAGNOSIS_CERTIFICATE.CaseListValue = "";
            this.Close();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                ucDIAGNOSIS_CERTIFICATE.CaseListValue = "";
                for (int i = 0; i < c1FlexGrid1.Rows.Count; i++)
                {
                    if (c1FlexGrid1[i, "—°‘Ò"].ToString().ToLower() == "true")
                    {
                        //string ICD_10 = "";
                        string name = "";
                        string childname = "";
                        //ICD_10 = c1FlexGrid1[c1FlexGrid1.RowSel, "ICD_10±‡¬Î"].ToString();
                        name = c1FlexGrid1[i, "’Ô∂œ√˚"].ToString();
                        advTree1.Nodes.Clear();
                        iniDiagnosisTree(c1FlexGrid1[i, "ID"].ToString());
                        SrtChildDiagnosis(ref childname, advTree1.Nodes,"  ");
                        name = name + childname;
                        
                        if (ucDIAGNOSIS_CERTIFICATE.CaseListValue == "")
                        {
                            ucDIAGNOSIS_CERTIFICATE.CaseListValue = name;
                        }
                        else
                        {
                            ucDIAGNOSIS_CERTIFICATE.CaseListValue = ucDIAGNOSIS_CERTIFICATE.CaseListValue + name;
                        }
                        ucDIAGNOSIS_CERTIFICATE.CaseListValue = ucDIAGNOSIS_CERTIFICATE.CaseListValue + "\n";
                    }
                }
                this.Close();
            }
            catch
            {

            }
            finally
            {
                this.Close();
            }
        }

        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.Rows.Count > 0)
            {
                c1FlexGrid1[c1FlexGrid1.RowSel, 0] = true;
                advTree1.Nodes.Clear();
                iniDiagnosisTree(c1FlexGrid1[c1FlexGrid1.RowSel, "ID"].ToString());
            }
        }

        //private void c1FlexGrid1_Click(object sender, EventArgs e)
        //{
        //    //if (c1FlexGrid1.RowSel > 0)
        //    //{
        //    //    string name = c1FlexGrid1[c1FlexGrid1.RowSel, 2].ToString();
        //    //    frmCases_First.Dename=name;
        //    //   this.Close();
        //    //}
        //}


        /// <summary>
        /// ≥ı ºªØ∏Ω Ù’Ô∂œ ˜“ªº∂∏Ω Ù’Ô∂œ
        /// </summary>
        /// <param name="did">÷˜’Ô∂œID</param>
        private void iniDiagnosisTree(string did)
        {
            DataSet ds = App.GetDataSet("select * from t_trend_diagnose t where t.diagnoseitem_id='" + did + "'");
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                DevComponents.AdvTree.Node tempnode = new DevComponents.AdvTree.Node();
                tempnode.Name = ds.Tables[0].Rows[i]["id"].ToString();
                tempnode.Text = ds.Tables[0].Rows[i]["trend_diagnose_name"].ToString();
                IniDiagnosisNode(tempnode);
                advTree1.Nodes.Add(tempnode);
            }
        }

        /// <summary>
        /// ∞Û∂®∏Ω Ù’Ô∂œµƒ∏Ω Ù’Ô∂œ
        /// </summary>
        /// <param name="node1">∏Ω Ù’Ô∂œΩ⁄µ„</param>
        private void IniDiagnosisNode(DevComponents.AdvTree.Node node1)
        {
            DataSet ds = App.GetDataSet("select * from t_trend_diagnose t where t.parent_id='" + node1.Name + "'");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DevComponents.AdvTree.Node tempnode = new DevComponents.AdvTree.Node();
                tempnode.Name = ds.Tables[0].Rows[i]["id"].ToString();
                tempnode.Text = ds.Tables[0].Rows[i]["trend_diagnose_name"].ToString();
                IniDiagnosisNode(tempnode);
                node1.Nodes.Add(tempnode);
            }
        }

        /// <summary>
        /// ∆¥Ω”∏Ω Ù’Ô∂œµƒ◊÷∑˚¥Æ
        /// </summary>
        /// <param name="strv"></param>
        private void SrtChildDiagnosis(ref string strv,DevComponents.AdvTree.NodeCollection nodes,string kg)
        {          
            for (int i = 0; i < nodes.Count; i++)
            {
                strv = strv + "\n" + kg + nodes[i].Text;
                if (nodes[i].Nodes.Count > 0)
                {
                    SrtChildDiagnosis(ref strv, nodes[i].Nodes, kg+"  ");
                }               
                
            }
        }
    }       
}