using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Bifrost;
using System.Windows.Forms;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmState : DevComponents.DotNetBar.Office2007Form
    {
        private int IsNormalClose = 0;
        private string stateIds="";

        public string StateIds
        {
            get { return stateIds; }
            set { stateIds = value; }
        }
        private string stateDes="";

        public string StateDes
        {
            get { return stateDes; }
            set { stateDes = value; }
        }




        public frmState(string ids)
        {
            InitializeComponent();
            if (ids != ""&&ids!=null)
                stateIds = ids;
            AddItem();
            SetSelectItem(stateIds);
        }
        /// <summary>
        /// 添加项
        /// </summary>
        public void AddItem()
        {
            string StateSql = "select * from T_FOLLOW_STATE order by id";
            DataSet Temp = App.GetDataSet(StateSql);
            if (Temp != null)
                if (Temp.Tables[0].Rows.Count != 0)
                {
                    cklbState.DataSource = Temp.Tables[0].DefaultView;
                    cklbState.DisplayMember = "des";
                    cklbState.ValueMember = "id";
                }


        }
        /// <summary>
        /// 设置选中项
        /// </summary>
        /// <param name="stateids"></param>
        public void SetSelectItem(string stateids)
        {
            if (stateids != "")
            {
                string[] id = stateIds.Split(',');
                foreach (string str in id)
                {
                    for (int i = 0; i < cklbState.Items.Count; i++)
                    {
                        DataRowView dv = (DataRowView)(cklbState.Items[i]);
                        string temp = dv["id"].ToString();
                        //string text = dv["des"].ToString();
                        if (temp == str)
                            cklbState.SetItemChecked(i, true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < cklbState.Items.Count; i++)
                {
                    cklbState.SetItemChecked(i, false);
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            stateIds = "";
            StateDes = "";
            for (int i = 0; i < cklbState.Items.Count; i++)
            {
                DataRowView dv = (DataRowView)(cklbState.Items[i]);
                string temp = dv["id"].ToString();
                string des = dv["des"].ToString();
                if (cklbState.GetItemChecked(i))
                {
                    if (stateIds == "")
                    {
                        stateIds = temp;
                        stateDes = des;
                    }
                    else
                    {
                        stateIds += "," + temp;
                        stateDes += "," + des;
                    }
                }

            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmState_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (IsNormalClose == 0)
            //{
            //    stateDes = "";
            //    stateIds = "";
            //}
        }
    }
}