using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{
    /// <summary>
    /// 用于快码查询
    /// 创建者：张华
    /// 创建时间：2009-9-10
    /// </summary>
    public partial class frmCodeSelect : DevComponents.DotNetBar.Office2007Form
    {
        /*
         * 说明：
         * 该窗体是具体的，快码查询的结果的显示，用户可以选择所需要的信息。
         * 将选择的结果存放在App中的SelectObj类中，便于随时调用。
         */

        /// <summary>
        /// 名称字段
        /// </summary>
        private string sel_name;

        /// <summary>
        /// 值字段
        /// </summary>
        private string sel_val;

        /// <summary>
        /// 绑定控件
        /// </summary>
        private Control trltepm;

        private DataSet ds;

        private int CurrentPageIndex = 1; //当前页码

        private int TotalRowsCount = 1;   //总记录条数

        private int TotalPageCount = 1;   //记录总页数

        private string SQL = "";

        private string OldName = "";

        private string NewName = "";

        private string KeyCol = "";

        private bool storflag = false;     //排序标记 true升序 false降序

        private bool Selectflag = false;



        Control TrlTepm1; 
        string Sel_Name1;
        string Sel_Val1;
       
        /// <summary>
        /// 初始化函数
        /// </summary>
        public frmCodeSelect()
        {
            InitializeComponent();
            //panel1.Visible = false;       
     
        }

        /// <summary>
        /// 带参数构造函数
        /// </summary>
        /// <param name="Sql">sql语句</param>
        /// <param name="trlTepm">绑定控件名</param>
        /// <param name="Sel_Name">字段名</param>
        /// <param name="Sel_Val">值</param>
        public void IniucCodeSelect(string Sql, Control trlTepm, string Sel_Name, string Sel_Val)
        {
            try
            {               

                if (trlTepm.Text != "")
                { 
                    TrlTepm1 = trlTepm;
                    this.Location = TrlTepm1.PointToScreen(new Point(0, TrlTepm1.Height));
                    cboSize.Text = "200";
                    cboCurrentPage.Text = "1";  
                    //fg.Rows.Clear();
                    //ds = App.GetDataSet(Sql);
                   
                    Sel_Name1 = Sel_Name;
                    Sel_Val1 = Sel_Val;
                    SQL = Sql;
                    int index = 0;
                    if (cboCurrentPage.Text == "")
                    {
                        index = 1;
                    }
                    else
                    {
                        index = Convert.ToInt16(cboCurrentPage.Text);
                    }
                    DataPageSet(index);                   
                    fg.AutoResizeColumns();
                }
            }
            catch
            { this.Hide(); }           
        }

        /// <summary>
        /// 病案编目
        /// 所有表格编辑弹窗的位置
        /// </summary>
        /// <param name="Sql"></param>
        /// <param name="trlTepm"></param>
        /// <param name="Sel_Name"></param>
        /// <param name="Sel_Val"></param>
        /// <param name="BABM"></param>
        public void IniucCodeSelect(string Sql, Control trlTepm, string Sel_Name, string Sel_Val, string BABM)
        {
            try
            {

                if (trlTepm.Text != "")
                {
                    TrlTepm1 = trlTepm;
                    this.Location = TrlTepm1.PointToScreen(new Point(0, TrlTepm1.Height + 10));
                    cboSize.Text = "200";
                    cboCurrentPage.Text = "1";
                    //fg.Rows.Clear();
                    //ds = App.GetDataSet(Sql);

                    Sel_Name1 = Sel_Name;
                    Sel_Val1 = Sel_Val;
                    SQL = Sql;
                    int index = 0;
                    if (cboCurrentPage.Text == "")
                    {
                        index = 1;
                    }
                    else
                    {
                        index = Convert.ToInt16(cboCurrentPage.Text);
                    }
                    DataPageSet(index);
                    fg.AutoResizeColumns();
                }
            }
            catch
            { this.Hide(); }
        }     

        /// <summary>
        /// 快码查询界面获取焦点
        /// </summary>
        public void Fg_Focus()
        {
            fg.Focus();         
        }

        

        /// <summary>
        /// 选择某一条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fg_DoubleClick(object sender, EventArgs e)
        {
            if (fg.RowCount>0)
            {
                App.SelectObj = new Class_SelectObj();
                if (sel_val.Trim()!= "")
                {
                    App.SelectObj.Select_Name = fg[sel_name,fg.CurrentRow.Index].Value.ToString();
                    App.SelectObj.Select_Val = fg[sel_val, fg.CurrentRow.Index].Value.ToString();
                }               
                App.SelectObj.Select_Row = ds.Tables[0].Rows[fg.CurrentRow.Index];                
                trltepm.Text = App.SelectObj.Select_Name;
                trltepm.Focus();
            }
            this.Hide();
        }

        /// <summary>
        /// 按下控件的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (fg.RowCount > 0)
                {
                    App.SelectObj = new Class_SelectObj();
                    if (sel_val.Trim() != "")
                    {
                        App.SelectObj.Select_Name = fg[sel_name, fg.CurrentRow.Index].Value.ToString();
                        App.SelectObj.Select_Val = fg[sel_val, fg.CurrentRow.Index].Value.ToString();
                    }
                    App.SelectObj.Select_Row = ds.Tables[0].Rows[fg.CurrentRow.Index];
                    trltepm.Text = App.SelectObj.Select_Name;
                    trltepm.Focus();
                    App.FastCodeFlag = false;
                }
                this.Hide();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                App.SelectObj = null;
                this.Hide();
            }
        }

        /// <summary>
        ///刷新表格
        /// </summary>
        /// <param name="CurrentIndex"></param>
        private void DataPageSet(int CurrentIndex)
        {
            try
            {
                KeyCol = Sel_Name1;
                ds = App.DataSetPage(SQL, KeyCol, storflag, Convert.ToInt32(cboSize.Text), CurrentIndex, ref TotalRowsCount, ref TotalPageCount);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.Show();
                    fg.DataSource = ds.Tables[0].DefaultView;
                    //this.Location = TrlTepm1.PointToScreen(new Point(0, TrlTepm1.Height));
                    sel_name = Sel_Name1;
                    sel_val = Sel_Val1;
                    trltepm = TrlTepm1;                                      

                    if (fg.Rows.Count * 20 > 300)
                    {
                        this.Height = 300;
                    }
                    else
                    {
                        if (fg.Rows.Count * 20 < 200)
                        {
                            this.Height = 200;
                        }
                        else
                        {
                            this.Height = fg.Rows.Count * 20;
                        }                        
                    }
                    if (fg.Rows.Count > 0)
                    {
                        this.Activate();
                        fg.Visible = true;
                        fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        //fg.Select(1,0);
                        //fg.SelectedRows[1].Selected=true;
                        //fg.Focus();                       
                    }
                    else
                    {
                        this.Hide();
                    }
                }
                else
                {
                    this.Hide();
                    App.SelectObj = null;
                    App.HideFastCodeCheck();
                    TrlTepm1.Parent.Refresh();
                    //for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                    //{
                    //    if (ds.Tables[0].Columns[i].ColumnName == "ICD10")
                    //    {
                    //        App.MsgWaring("此诊断不存在!请联系病案室，电话：8677");
                    //        TrlTepm1.Text = "";
                    //        break;
                    //    }
                    //}
                }

                //App.reFleshFlexGrid(ds, ref this.fg, OldName, NewName);
                this.fg.Columns["RN"].Visible = false;
                Selectflag = true;
                cboCurrentPage.Items.Clear();
                for (int i = 1; i <= TotalPageCount; i++)
                {
                    cboCurrentPage.Items.Add(i.ToString());
                }
                cboCurrentPage.Text = CurrentIndex.ToString();
                Selectflag = false;
            }
            catch
            {
                this.Hide();
            }
        }


        #region 分页操作
        private void btnTop_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            //DataPageSet(CurrentPageIndex);
            cboCurrentPage.Text = CurrentPageIndex.ToString();
            btnTop.Enabled = false;
            btnUp.Enabled = false;
            btnDown.Enabled = true;
            btnBottom.Enabled = true;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 1)
            {
                CurrentPageIndex = CurrentPageIndex - 1;
                cboCurrentPage.Text = CurrentPageIndex.ToString();
                btnTop.Enabled = true;
                btnUp.Enabled = true;
            }
            if (CurrentPageIndex == 1)
            {
                btnTop.Enabled = false;
                btnUp.Enabled = false;
            }
            btnDown.Enabled = true;
            btnBottom.Enabled = true;
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex < TotalPageCount)
            {
                CurrentPageIndex = CurrentPageIndex + 1;
                cboCurrentPage.Text = CurrentPageIndex.ToString();
                btnDown.Enabled = true;
                btnBottom.Enabled = true;
            }
            if (CurrentPageIndex == TotalPageCount)
            {
                btnDown.Enabled = false;
                btnBottom.Enabled = false;
            }
            btnTop.Enabled = true;
            btnUp.Enabled = true;
        }

        private void btnBottom_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = TotalPageCount;
            cboCurrentPage.Text = CurrentPageIndex.ToString();
            btnDown.Enabled = false;
            btnBottom.Enabled = false;
            btnTop.Enabled = true;
            btnUp.Enabled = true;
        }

        private void cboCurrentPage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                btnTop.Enabled = false;
                btnUp.Enabled = false;
                CurrentPageIndex = 1;
                DataPageSet(CurrentPageIndex);
                if (TotalPageCount == 1)
                {
                    btnDown.Enabled = false;
                    btnBottom.Enabled = false;
                }
                else
                {
                    btnDown.Enabled = true;
                    btnBottom.Enabled = true;
                }
            }
            catch
            { }
        }

        private void cboCurrentPage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!Selectflag)
                {
                    CurrentPageIndex = Convert.ToInt32(cboCurrentPage.Text);
                    DataPageSet(CurrentPageIndex);
                    btnTop.Enabled = true;
                    btnUp.Enabled = true;
                    btnDown.Enabled = true;
                    btnBottom.Enabled = true;
                    if (CurrentPageIndex == 1)
                    {
                        btnTop.Enabled = false;
                        btnUp.Enabled = false;

                    }
                    else if (CurrentPageIndex == TotalPageCount)
                    {
                        btnDown.Enabled = false;
                        btnBottom.Enabled = false;
                    }
                }
            }
            catch
            { }
        }
        #endregion

        private void frmCodeSelect_Load(object sender, EventArgs e)
        {
            App.FormStytleSet(this, false);                   
        }

        private void frmCodeSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            return;         
        }

        private void fg_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void fg_Scroll(object sender, ScrollEventArgs e)
        {
            fg.Refresh();
        }
    }
}