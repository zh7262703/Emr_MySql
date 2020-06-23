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
        /// ������ϸ�б��ʼ��
        /// </summary>
        /// <param name="pids">סԺ��</param>
        /// <param name="person">������</param>
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
        /// ��Ԫ��ϲ������� 
        /// </summary>
        private void CellUnit()
        {

            //��Ԫ��ϲ������� 
            c1flgview[0, 0] = "������";
            c1flgview[0, 1] = "�����˱��";
            c1flgview[0, 2] = "������";
            c1flgview[0, 3] = "�۷ֵ�";
            c1flgview[0, 4] = "�۷�����";
            c1flgview[0, 5] = "��¼ʱ��";
            c1flgview[0, 6] = "�۷ַ�ֵ";


            c1flgview.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            c1flgview.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;

            cr = c1flgview.GetCellRange(0, 0, 0, 0);
            cr.Data = "������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 1, 0, 1);
            cr.Data = "�����˱��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 2, 0, 2);
            cr.Data = "������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 3, 0, 3);
            cr.Data = "�۷ֵ�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 4, 0, 4);
            cr.Data = "�۷�����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 5, 0, 5);
            cr.Data = "��¼ʱ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            cr = c1flgview.GetCellRange(0, 6, 0, 6);
            cr.Data = "�۷ַ�ֵ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.MergedRanges.Add(cr);

            //�������
            c1flgview.Cols[0].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[1].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[2].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //c1flgview.Cols[3].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[4].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[5].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            c1flgview.Cols[6].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

            c1flgview.AutoSizeCols();



            //�ѱ������
            c1flgview.Cols[0].Visible = false;
            c1flgview.Cols[0].AllowEditing = false;

            c1flgview.Cols[1].Visible = false;
            c1flgview.Cols[1].AllowEditing = false;

        }
        /// <summary>
        /// ��ͷ����
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
            SQl_tper = @"select tua.pid as ������,tua.GRADE_DOC_ID as �����˱��,tua.GRADE_DOC_NAME as ������, " +
                       @"tua.down_reason_1 as �۷ֵ�,tua.doc_type as �۷�����,to_char(tua.grade_time,'yyyy-MM-dd hh:mi:ss') as ��¼ʱ��, " +
                       @"tua.down_point_1 as �۷�ֵ from T_NURSE_GRADE tua ";
            string sql = "";
            if (Temperture != null && Nurse != null)
            {
                sql = SQl_tper + " where tua.pid='" + Pid + "' and  tua.GRADE_DOC_NAME='" + Person + "' and  tua.doc_type like '%���µ�%' or tua.pid='" + Pid + "' and  tua.GRADE_DOC_NAME='" + Person + "' and tua.doc_type like '%Σ��%'  order by to_char(tua.grade_time,'yyyy-MM-dd hh:mi:ss') desc";
            }
            if (Temperture != null && Nurse == null)
            {
                sql = SQl_tper + " where tua.pid='" + Pid + "' and  tua.GRADE_DOC_NAME='" + Person + "' and  tua.doc_type like '%���µ�%'  order by to_char(tua.grade_time,'yyyy-MM-dd hh:mi:ss') desc";
            }
            if (Temperture == null && Nurse != null)
            {
                sql = SQl_tper + " where tua.pid='" + Pid + "' and tua.GRADE_DOC_NAME='" + Person + "' and  tua.doc_type like '%Σ��%' order by to_char(tua.grade_time,'yyyy-MM-dd hh:mi:ss') desc";
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
                        pat.Pids = dt.Rows[i]["������"].ToString();
                        pat.Person_in_change_id = dt.Rows[i]["�����˱��"].ToString();
                        pat.Person_in_change = dt.Rows[i]["������"].ToString();
                        pat.Deduct_mark = dt.Rows[i]["�۷ֵ�"].ToString();
                        pat.Deduct_mark_book = dt.Rows[i]["�۷�����"].ToString();
                        pat.Record_time = dt.Rows[i]["��¼ʱ��"].ToString();
                        pat.Deduct_mark_value = dt.Rows[i]["�۷�ֵ"].ToString();

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