using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class frmOpration_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dt = new DataTable();//数据表
        public static string beginTime = "";
        public static string endTime = "";
        public static string sectionName = "";
        public frmOpration_PatientInfo()
        {
            InitializeComponent();
        }

        public frmOpration_PatientInfo(DataTable dt)
        {
            InitializeComponent();
            App.ButtonStytle(this);
            flgView.AllowEditing = false;
            dt.Columns[0].ColumnName = "序号";
            dt.Columns[1].ColumnName = "科室";
            dt.Columns[2].ColumnName = "主刀医师";
            dt.Columns[3].ColumnName = "手术一助";
            dt.Columns[4].ColumnName = "手术二助";
            dt.Columns[5].ColumnName = "住院号";
            dt.Columns[6].ColumnName = "姓名";
            dt.Columns[7].ColumnName = "性别";
            dt.Columns[8].ColumnName = "年龄";
            dt.Columns[9].ColumnName = "术前诊断";
            dt.Columns[10].ColumnName = "手术日期";
            dt.Columns[11].ColumnName = "手术名称";
            dt.Columns[12].ColumnName = "手术分类";
            flgView.DataSource = dt;
            flgView.Cols["birthday"].Visible = false;
            flgView.Cols["section_id"].Visible = false;
            flgView.Cols["in_time"].Visible = false;
            flgView.Cols["sick_area_id"].Visible = false;
            flgView.Cols["sick_area_name"].Visible = false;
            if (beginTime=="" &&endTime=="")
            {
                btnPrint.Visible = false;
            }
        }
        /// <summary>
        /// 手术打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = CreateDataSetWidthFlexGrid(this.flgView);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    frmOpration_Print fp = new frmOpration_Print(ds, frmOpration_PatientInfo.sectionName, frmOpration_PatientInfo.beginTime, frmOpration_PatientInfo.endTime);
                    fp.Show();
                }
            }
        }

        /// <summary>
        /// 将表格转换成数据集
        /// </summary>
        /// <param name="fg"></param>
        /// <returns></returns>
        private static DataSet CreateDataSetWidthFlexGrid(C1FlexGrid fg)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            //创建列
            for (int i = 1; i < fg.Cols.Count; i++)
            {
                DataColumn dc;
                dc = new DataColumn(fg.Cols[i][0].ToString());
                dt.Columns.Add(dc);
            }

            //创建行，绑定数据
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].NewRow();
                for (int j = 1; j < fg.Cols.Count; j++)
                {
                    dr[j - 1] = fg.Rows[i][j].ToString();
                }
                ds.Tables[0].Rows.Add(dr);
            }
            return ds;
        } 
    }
}