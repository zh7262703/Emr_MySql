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

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    /// <summary>
    /// 新增评分病历
    /// </summary>
    /// 修改 李文明
    /// 修改时间 2013年12月25号
    public partial class frmAddGradeRepart : DevComponents.DotNetBar.Office2007Form
    {
        private ucfrmMainGradeRepart fmgr;
        /// <summary>
        /// 选中的病人科室
        /// </summary>
        public string sickname;

        public frmAddGradeRepart(ucfrmMainGradeRepart _fmgr,string sick_name)
        {
            this.sickname = sick_name;
            InitializeComponent();
            this.fmgr = _fmgr;
        }
        /// <summary>
        /// 加载时候显示的数据
        /// </summary>
        private void SetSickData()
        {
            LinkLabel lkbel = new LinkLabel();
            lkbel.Text = "选中";
            string querySQL = "select id as 编号, SECTION_NAME as 科室, pid as 住院号, patient_name as 患者姓名, in_time as 住院日期, " +
                              "die_time as 出院日期, Sick_Doctor_Name as 管床医生 from T_IN_Patient where id not in(select distinct patient_id from t_Doc_Grade where patient_id is not null) and die_time is not null  ";

            if (cboxSick.Text != "全院")
            {
                querySQL += " and SECTION_NAME ='" + cboxSick.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtPid.Text.Trim()))
            {
                querySQL += " and pid like '%" + txtPid.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                querySQL += " and patient_name like '%" + txtName.Text.Trim() + "%'";
            }
            querySQL += " order by SECTION_NAME,id,pid";
            DataSet ds = App.GetDataSet(querySQL);
            DataTable dt = ds.Tables[0];//给datatable赋值
            //添加一列checkedbox
            DataColumn dc = new DataColumn("" + lkbel.Text + "", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);

            this.ucC1FlexGrid1.fg.DataSource = dt.DefaultView;//绑定数据源dt
            this.ucC1FlexGrid1.fg.Cols["选中"].Width = 50;
            this.ucC1FlexGrid1.fg.Cols["编号"].Width = 50;
            this.ucC1FlexGrid1.fg.Cols["科室"].Width = 150;
            this.ucC1FlexGrid1.fg.Cols["住院号"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["患者姓名"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["住院日期"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["出院日期"].Width = 100;
            this.ucC1FlexGrid1.fg.Cols["管床医生"].Width = 50;
            //this.ucC1FlexGrid1.fg.Cols["病人ID"].Width = 60;

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
            DataBandSick();
            ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SetSickData();
        }

        private void DataBandSick()
        {
            string sickSQL = "select t.sid,section_name from t_sectioninfo t inner join t_section_area x on t.sid=x.sid where  enable_flag='Y' order by section_name";
            DataSet ds1 = App.GetDataSet(sickSQL);

            DataRow dr = ds1.Tables[0].NewRow();
            dr["sid"] = "0";
            dr["section_name"] = "全院";
            ds1.Tables[0].Rows.InsertAt(dr, 0);
            this.cboxSick.DataSource = ds1.Tables[0].DefaultView;
            this.cboxSick.DisplayMember = "section_name";
            this.cboxSick.ValueMember = "sid";
            cboxSick.Text = this.sickname;
        }
    }
}   