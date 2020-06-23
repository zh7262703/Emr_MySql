using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{
    public partial class frmCode : DevComponents.DotNetBar.Office2007Form
    {
        public frmCode()
        {
            InitializeComponent();
            this.rcode.Checked = true;
            this.currBtn = rcode;
            
        }
        private List<string> Oldlist;
        private List<string> NewList;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="list">名称列、编码列、名称对应拼音码列</param>
        public frmCode(string sql, List<string> _OldList,List<string> _NewList)
        {
            InitializeComponent();
            this.SQL = sql;
            if (_OldList.Count < 2 || _NewList.Count < 2 || _OldList.Count != _NewList.Count)
                return;
            Oldlist = _OldList;
            NewList = _NewList;
            rcode.Text = NewList[1];
            rcode.Tag = Oldlist[1];
            rname.Text = NewList[0];
            rname.Tag = Oldlist[0];
            rname.Checked = true;
            IsName = true;
            currBtn = rname;
            HavePY();
            SetData();
        }
        private bool IsName = false;
        private bool IsHavePY = false;
        private void HavePY()
        {
            if (Oldlist.Count >= 3 && Oldlist[2].Trim().Length > 0)
            {
                IsHavePY = true;
            }
        }
        private void txtinput_TextChanged(object sender, EventArgs e)
        {

            if (SQL.ToLower().Contains("where"))
            {
                strCondition = " and upper(" + currBtn.Tag.ToString() + ") like '%" + txtinput.Text.Trim().ToUpper() + "%'";
                if (IsName && IsHavePY)
                {
                    strCondition = " and (upper(" + currBtn.Tag.ToString() + ") like '%" + txtinput.Text.Trim().ToUpper() + "%'";
                    strCondition += " OR upper(" + Oldlist[2] + ") like '%" + txtinput.Text.Trim().ToUpper() + "%')";
                }
            }
            else
            {
                strCondition = " where upper(" + currBtn.Tag.ToString() + ") like '%" + txtinput.Text.Trim().ToUpper() + "%'";
                if (IsName && IsHavePY)
                {
                    strCondition = " where upper(" + currBtn.Tag.ToString() + ") like '%" + txtinput.Text.Trim().ToUpper() + "%'";
                    strCondition += " OR upper(" + Oldlist[2] + ") like '%" + txtinput.Text.Trim().ToUpper() + "%'";
                }
            }

            SetData();
        }

        /*
         * 说明：
         * 该窗体是具体的，快码查询的结果的显示，用户可以选择所需要的信息。
         * 将选择的结果存放在App中的SelectObj类中，便于随时调用。
         */
        private string SQL = "";
        private string strCondition = "";
        DataSet ds;
        private void SetData()
        {
            //this.ucGridviewX1.DataBd(SQL + (string.IsNullOrEmpty(strCondition) ? "" : strCondition), currBtn.Text, rcode.Text + "," + rname.Text, rcode.Text + "," + rname.Text);
            ds = App.GetDataSet(SQL+(string.IsNullOrEmpty(strCondition) ? "" : strCondition));
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            //this.dataGridViewX1.AutoResizeColumns();
        }

        ///// <summary>
        ///// 快码查询界面获取焦点
        ///// </summary>
        //public void Fg_Focus()
        //{
        //    this.ucGridviewX1.fg.Focus();         
        //}


        private void frmCode_Load(object sender, EventArgs e)
        {
            this.dataGridViewX1.DoubleClick += new EventHandler(fg_DoubleClick);
            this.dataGridViewX1.KeyDown += new KeyEventHandler(fg_KeyDown);
        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewX1.RowCount > 0)
            {
                App.SelectObj = new Class_SelectObj();
                App.SelectObj.Select_Name = dataGridViewX1[rcode.Text, dataGridViewX1.CurrentRow.Index].Value.ToString();
                App.SelectObj.Select_Val = dataGridViewX1[rname.Text, dataGridViewX1.CurrentRow.Index].Value.ToString();
                App.SelectObj.Select_Row = ds.Tables[0].Rows[dataGridViewX1.CurrentRow.Index];
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void fg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridViewX1.RowCount > 0)
                {
                    App.SelectObj = new Class_SelectObj();
                    App.SelectObj.Select_Name = dataGridViewX1[rcode.Text, dataGridViewX1.CurrentRow.Index].Value.ToString();
                    App.SelectObj.Select_Val = dataGridViewX1[rname.Text, dataGridViewX1.CurrentRow.Index].Value.ToString();
                    App.SelectObj.Select_Row = ds.Tables[0].Rows[dataGridViewX1.CurrentRow.Index];
                    App.FastCodeFlag = false;
                    this.DialogResult = DialogResult.OK;
                }
                this.Close();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                App.SelectObj = null;
            }
        }
        private void rname_CheckedChanged(object sender, EventArgs e)
        {
            if (rcode.Checked)
            {
                currBtn = rcode;
            }
            else
            {
                currBtn = rname;
            }
        }
        private RadioButton currBtn;
        private void rcode_CheckedChanged(object sender, EventArgs e)
        {
            if (rcode.Checked)
            {
                currBtn = rcode;
                IsName = false;
            }
            else
            {
                currBtn = rname;
                IsName = true;
            }
            SetData();
        }
    }
}