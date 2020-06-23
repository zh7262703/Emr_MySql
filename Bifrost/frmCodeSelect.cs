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
    /// ���ڿ����ѯ
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2009-9-10
    /// </summary>
    public partial class frmCodeSelect : DevComponents.DotNetBar.Office2007Form
    {
        /*
         * ˵����
         * �ô����Ǿ���ģ������ѯ�Ľ������ʾ���û�����ѡ������Ҫ����Ϣ��
         * ��ѡ��Ľ�������App�е�SelectObj���У�������ʱ���á�
         */

        /// <summary>
        /// �����ֶ�
        /// </summary>
        private string sel_name;

        /// <summary>
        /// ֵ�ֶ�
        /// </summary>
        private string sel_val;

        /// <summary>
        /// �󶨿ؼ�
        /// </summary>
        private Control trltepm;

        private DataSet ds;

        private int CurrentPageIndex = 1; //��ǰҳ��

        private int TotalRowsCount = 1;   //�ܼ�¼����

        private int TotalPageCount = 1;   //��¼��ҳ��

        private string SQL = "";

        private string OldName = "";

        private string NewName = "";

        private string KeyCol = "";

        private bool storflag = false;     //������ true���� false����

        private bool Selectflag = false;



        Control TrlTepm1; 
        string Sel_Name1;
        string Sel_Val1;
       
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public frmCodeSelect()
        {
            InitializeComponent();
            //panel1.Visible = false;       
     
        }

        /// <summary>
        /// ���������캯��
        /// </summary>
        /// <param name="Sql">sql���</param>
        /// <param name="trlTepm">�󶨿ؼ���</param>
        /// <param name="Sel_Name">�ֶ���</param>
        /// <param name="Sel_Val">ֵ</param>
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
        /// ������Ŀ
        /// ���б��༭������λ��
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
        /// �����ѯ�����ȡ����
        /// </summary>
        public void Fg_Focus()
        {
            fg.Focus();         
        }

        

        /// <summary>
        /// ѡ��ĳһ����¼
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
        /// ���¿ؼ���ʱ��
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
        ///ˢ�±��
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
                    //        App.MsgWaring("����ϲ�����!����ϵ�����ң��绰��8677");
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


        #region ��ҳ����
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