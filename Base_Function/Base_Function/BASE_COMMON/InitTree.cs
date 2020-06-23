using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using Bifrost;
using Base_Function.MODEL;

namespace Base_Function.BASE_COMMON
{
    public class InitTree
    {
        private Class_Patients[] patients;
        public void InitTreeControl(TreeView treeView1)
        {
            treeView1.Nodes.Clear();
            DataSet ds = App.GetDataSet("select Tid,TName from T_TempPlate");

            patients = new Class_Patients[ds.Tables[0].Rows.Count];

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                patients[i] = new Class_Patients();
                patients[i].Tid = Convert.ToInt32(ds.Tables[0].Rows[i]["TID"].ToString());
                patients[i].TName = ds.Tables[0].Rows[i]["TName"].ToString();

                TreeNode tnRoot = new TreeNode();
                tnRoot.Tag = patients[i];
                tnRoot.Text = patients[i].TName;
                treeView1.Nodes.Add(tnRoot);
            }
        }
    }
}
