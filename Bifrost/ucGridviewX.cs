using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{
    public partial class ucGridviewX : UserControl
    {       

          //private int RowCountPage = 200; //每页记录数

        private int CurrentPageIndex = 1; //当前页码

        private int TotalRowsCount = 1;   //总记录条数

        private int TotalPageCount = 1;   //记录总页数

        private string SQL = "";

        private string OldName = "";

        private string NewName = "";

        private string KeyCol = "";

        private bool storflag = false;      //排序标记 true升序 false降序

        private bool Selectflag = false;
       


        /// <summary>
        /// 构造函数
        /// </summary>
        public ucGridviewX()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 分页初始化
        /// </summary>
        /// <param name="Sql">查询语句</param>
        /// <param name="keycol">主健</param>
        /// <param name="keycol">升序降序</param>
        /// <param name="oldName">字段原名称</param>
        /// <param name="newName">字段新名称</param>
        public void DataBd(string Sql,string keycol,string oldName,string newName)
        {
            try
            {
                cboSize.Text = "200";
                cboCurrentPage.Text = "1";
                SQL = Sql;
                OldName = oldName;
                NewName = newName;
                KeyCol = keycol;
                DataSet ds = App.DataSetPage(SQL, KeyCol, storflag, Convert.ToInt32(cboSize.Text), 1, ref TotalRowsCount, ref TotalPageCount);
                App.reFleshGridViewX(ds, ref this.fg, OldName, NewName);
                this.fg.Columns["RN"].Visible = false;
                cboCurrentPage.Items.Clear();
                for (int i = 1; i <= TotalPageCount; i++)
                {
                    cboCurrentPage.Items.Add(i.ToString());
                }
                cboCurrentPage.Text = "1";
                btnTop.Enabled = false;
                btnUp.Enabled = false;
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
                //DataTable re;
               
                

            }
            catch
            {
 
            }
        }

        /// <summary>
        /// 分页初始化
        /// </summary>
        /// <param name="Sql">查询语句</param>
        /// <param name="keycol">主健</param>
        /// <param name="orderflag">升序降序</param>
        /// <param name="oldName">字段原名称</param>
        /// <param name="newName">字段新名称</param>
        public void DataBd(string Sql, string keycol, bool orderflag, string oldName, string newName)
        {
            try
            {
                cboSize.Text = "200";
                cboCurrentPage.Text = "1";
                SQL = Sql;
                OldName = oldName;
                NewName = newName;
                KeyCol = keycol;
                storflag = orderflag;
                DataSet ds = App.DataSetPage(SQL, KeyCol, storflag, Convert.ToInt32(cboSize.Text), 1, ref TotalRowsCount, ref TotalPageCount);
                App.reFleshGridViewX(ds, ref this.fg, OldName, NewName);
                this.fg.Columns["RN"].Visible = false;                
                cboCurrentPage.Items.Clear();
                for (int i = 1; i <= TotalPageCount; i++)
                {
                    cboCurrentPage.Items.Add(i.ToString());
                }
                cboCurrentPage.Text = "1";
                btnTop.Enabled = false;
                btnUp.Enabled = false;
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
                //DataTable re;

            }
            catch
            {

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
                DataSet ds = App.DataSetPage(SQL, KeyCol, storflag, Convert.ToInt32(cboSize.Text), CurrentIndex, ref TotalRowsCount, ref TotalPageCount);
                App.reFleshGridViewX(ds, ref this.fg, OldName, NewName);
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
            { }
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
            if (CurrentPageIndex==1)
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
        #endregion

        private void ucC1FlexGrid_Load(object sender, EventArgs e)
        {
            cboSize.Text = "200";
            cboCurrentPage.Text = "1";          
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

       
        private void panel1_Resize(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 调整位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel2_Resize(object sender, EventArgs e)
        {
            try
            {
                if (panel2.Width > panel1.Width)
                {
                    int wd = (panel2.Width - panel1.Width) / 2;
                    panel1.Left = wd;
                }
            }
            catch
            { }
        }

        private void fg_Click(object sender, EventArgs e)
        {

        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {

        }

        private void fg_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void fg_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fg_Sorted(object sender, EventArgs e)
        {

        }
    }
}
