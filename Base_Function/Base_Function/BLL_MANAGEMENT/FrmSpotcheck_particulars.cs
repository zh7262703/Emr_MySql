using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.MODEL;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class FrmSpotcheck_particulars : DevComponents.DotNetBar.Office2007Form
    {
        ColumnInfo[] cols = new ColumnInfo[7];
        private string SQl_tper;
        private string pid;
        private string person;
        private string temperture;
        private string nurse;
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        public string Person
        {
            get { return person; }
            set { person = value; }
        }
        public string Temperture
        {
            get { return temperture; }
            set { temperture = value; }
        }
        public string Nurse
        {
            get { return nurse; }
            set { nurse = value; }
        }
        public FrmSpotcheck_particulars()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// 评分详细列表初始化
        /// </summary>
        /// <param name="pids">住院号</param>
        /// <param name="person">责任人</param>
        /// <param name="tempertures"></param>
        /// <param name="nurse"></param>
        public FrmSpotcheck_particulars(string pids, string person, string tempertures, string nurse)
        {
            InitializeComponent();
            this.Pid = pids;
            this.Person = person;
            this.Temperture = tempertures;
            this.Nurse = nurse;
        }

        private void FrmSpotcheck_particulars_Load(object sender, EventArgs e)
        {
            Toshow_particulars();
        }
        /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        private void CellUnit()
        {

            //单元格合并和设置 
            c1flgview[0, 0] = "病案号";
            c1flgview[0, 1] = "责任人编号";
            c1flgview[0, 2] = "责任人";
            c1flgview[0, 3] = "扣分点";
            c1flgview[0, 4] = "扣分文书";
            c1flgview[0, 5] = "记录时间";
            c1flgview[0, 6] = "扣分分值";


            c1flgview.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            c1flgview.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;

            cr = c1flgview.GetCellRange(0, 0, 0, 0);
            cr.Data = "病案号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 1, 0, 1);
            cr.Data = "责任人编号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 2, 0, 2);
            cr.Data = "责任人";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 3, 0, 3);
            cr.Data = "扣分点";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 4, 0, 4);
            cr.Data = "扣分文书";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 5, 0, 5);
            cr.Data = "记录时间";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 6, 0, 6);
            cr.Data = "扣分分值";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            //字体居中
            c1flgview.Cols[0].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[1].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[2].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //c1flgview.Cols[3].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[4].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[5].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[6].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

            c1flgview.AutoSizeCols();



            //把编号隐藏
            c1flgview.Cols[0].Visible = false;
            c1flgview.Cols[0].AllowEditing = false;

            c1flgview.Cols[1].Visible = false;
            c1flgview.Cols[1].AllowEditing = false;

        }
        /// <summary>
        /// 表头设置
        /// </summary>
        private void SetTable()
        {
            c1flgview.Cols.Count = 7;
            c1flgview.Cols.Fixed = 0;
            c1flgview.Rows.Count = 1;
            c1flgview.Rows.Fixed = 1;
        }
        private void Toshow_particulars()
        {
            SetTable();
            SQl_tper = @"select tua.pid as 病案号,tua.GRADE_DOC_ID as 责任人编号,tua.GRADE_DOC_NAME as 责任人, " +
                       @"tua.down_reason_1 as 扣分点,tua.doc_type as 扣分文书,to_char(tua.grade_time,'yyyy-MM-dd hh:mi:ss') as 记录时间, " +
                       @"tua.down_point_1 as 扣分值 from T_NURSE_GRADE tua ";
            string sql = "";
            if (Temperture != null && Nurse != null)
            {
                sql = SQl_tper + " where tua.pid='" + Pid + "' and  tua.GRADE_DOC_NAME='" + Person + "' and  tua.doc_type like '%体温单%' or tua.pid='" + Pid + "' and  tua.GRADE_DOC_NAME='" + Person + "' and tua.doc_type like '%危重%'  order by to_char(tua.grade_time,'yyyy-MM-dd hh:mi:ss') desc";
            }
            if (Temperture != null && Nurse == null)
            {
                sql = SQl_tper + " where tua.pid='" + Pid + "' and  tua.GRADE_DOC_NAME='" + Person + "' and  tua.doc_type like '%体温单%'  order by to_char(tua.grade_time,'yyyy-MM-dd hh:mi:ss') desc";
            }
            if (Temperture == null && Nurse != null)
            {
                sql = SQl_tper + " where tua.pid='" + Pid + "' and tua.GRADE_DOC_NAME='" + Person + "' and  tua.doc_type like '%危重%' order by to_char(tua.grade_time,'yyyy-MM-dd hh:mi:ss') desc";
            }

            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        c1flgview.Rows.Add();
                        Class_Toshow_particulars pat = new Class_Toshow_particulars();
                        pat.Pids = dt.Rows[i]["病案号"].ToString();
                        pat.Person_in_change_id = dt.Rows[i]["责任人编号"].ToString();
                        pat.Person_in_change = dt.Rows[i]["责任人"].ToString();
                        pat.Deduct_mark = dt.Rows[i]["扣分点"].ToString();
                        pat.Deduct_mark_book = dt.Rows[i]["扣分文书"].ToString();
                        pat.Record_time = dt.Rows[i]["记录时间"].ToString();
                        pat.Deduct_mark_value = dt.Rows[i]["扣分值"].ToString();

                        c1flgview[1 + i, 0] = pat.Pids;
                        c1flgview[1 + i, 1] = pat.Person_in_change_id;
                        c1flgview[1 + i, 2] = pat.Person_in_change;
                        c1flgview[1 + i, 3] = pat.Deduct_mark;
                        c1flgview[1 + i, 4] = pat.Deduct_mark_book;
                        c1flgview[1 + i, 5] = pat.Record_time;
                        c1flgview[1 + i, 6] = pat.Deduct_mark_value;
                    }
                }
                CellUnit();
            }
        }
    }
}