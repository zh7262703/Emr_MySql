using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using Microsoft.ReportingServices.ReportRendering;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;


namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// 新增评分病历
    /// </summary>
    /// 开发 李伟
    /// 时间 2010年9月14号
    public partial class frmAddGradeRepart : DevComponents.DotNetBar.Office2007Form
    {
        private ucfrmMainGradeRepart fmgr;
        private ucfrmMainGradeRepartDoctor fmgrDoctor;
        private ucfrmMainGradeRepartSection fmgrSection;
        public frmAddGradeRepart(ucfrmMainGradeRepart _fmgr)
        {
            InitializeComponent();

            this.fmgr = _fmgr;
        }
        public frmAddGradeRepart(ucfrmMainGradeRepartDoctor _fmgrDoctor)
        {
            InitializeComponent();

            this.fmgrDoctor = _fmgrDoctor;
        }
        public frmAddGradeRepart(ucfrmMainGradeRepartSection _fmgrSection)
        {
            InitializeComponent();

            this.fmgrSection = _fmgrSection;
        }
        /// <summary>
        /// 加载时候显示的数据
        /// </summary>
        private void SetSickData()
        {
            LinkLabel lkbel = new LinkLabel();
            lkbel.Text = "选中";
            string querySQL = "select id as 编号, in_area_name as 病区, pid as 住院号, patient_name as 患者姓名, in_time as 住院日期, " +
                              "die_time as 出院日期, Sick_Doctor_Name as 经治医师,pid as 病人ID from T_IN_Patient";
            DataSet ds = App.GetDataSet(querySQL);
            DataTable dt = ds.Tables[0];//给datatable赋值
            //添加一列checkedbox
            DataColumn dc = new DataColumn("" + lkbel.Text + "", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);

            this.ucC1FlexGrid1.fg.DataSource = dt.DefaultView;//绑定数据源dt
            this.ucC1FlexGrid1.fg.Cols["选中"].Width = 50;
            this.ucC1FlexGrid1.fg.Cols["编号"].Width = 50;
            this.ucC1FlexGrid1.fg.Cols["病区"].Width = 150;
            this.ucC1FlexGrid1.fg.Cols["住院号"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["患者姓名"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["住院日期"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["出院日期"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["经治医师"].Width = 50;
            this.ucC1FlexGrid1.fg.Cols["病人ID"].Width = 60;

            ucC1FlexGrid1.fg.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            //把添加的一行移动到数据表的第一列
            this.ucC1FlexGrid1.fg.Cols["" + lkbel.Text + ""].Move(1);
            for (int i = 0; i < ucC1FlexGrid1.fg.Cols.Count; i++)
            {
                ucC1FlexGrid1.fg.Cols[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }


        }
        //List<string> list = new List<string>();
        private void btnConfrom_Click(object sender, EventArgs e)
        {
            //循环UCC1的每行。如果选中的就添加  ucC1FlexGrid1.fg.Rows[i]这是UCC1的一行。
            for (int i = 1; i < ucC1FlexGrid1.fg.Rows.Count; i++)
            {
                //选中checkedbox以后会返回一个全部是小写的true 如果选中
                if (ucC1FlexGrid1.fg[i, 1].ToString().ToLower() == "true")
                {
                    //调用addrow方法添加一行
                    this.fmgr.AddRow(ucC1FlexGrid1.fg.Rows[i]);
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        int oldRow2 = 0;//上一次点击过的行号
        private void ucC1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (this.ucC1FlexGrid1.fg.ColSel == 1)
            {
                this.ucC1FlexGrid1.fg.AllowEditing = true;
            }
            else
            {
                this.ucC1FlexGrid1.fg.AllowEditing = false;
            }

            if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, 1].ToString().ToLower() == "true")
            {
                ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, 1] = false;
            }
            else
            {
                ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, 1] = true;
            }

            int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号
            if (rows == oldRow2)
            {
                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
            }
            else
            {
                //如果不是头行
                if (rows > 0)
                {
                    //就改变背景色
                    this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                }
                if (oldRow2 > 0)
                {
                    //定义上一次点击过的行还原
                    this.ucC1FlexGrid1.fg.Rows[oldRow2].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                }
            }
            //给上一次的行号赋值
            oldRow2 = rows;
        }
        int oldRow = 0;//上一次点击过的行号
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            if (this.ucC1FlexGrid1.fg.ColSel == 1)
            {
                this.ucC1FlexGrid1.fg.AllowEditing = true;
            }
            else
            {
                this.ucC1FlexGrid1.fg.AllowEditing = false;
            }


            int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号
            if (rows == oldRow)
            {
                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
            }
            else
            {
                //如果不是头行
                if (rows > 0)
                {
                    //就改变背景色
                    this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                }
                if (oldRow > 0)
                {
                    //定义上一次点击过的行还原
                    this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                }
            }
            //给上一次的行号赋值
            oldRow = rows;
        }

        private void frmAddGradeRepart_Load(object sender, EventArgs e)
        {
            SetSickData();
            ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
        }
    }
}   