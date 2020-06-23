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
    public partial class frmInOut_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {

        DataTable dt = new DataTable();//数据表
        public static string beginTime = "";
        public static string endTime = "";
        public static string sectionName = "";
        public static string titleName = "";
        public frmInOut_PatientInfo()
        {
            InitializeComponent();
        }
        public frmInOut_PatientInfo(DataTable dt_info)
        {
            InitializeComponent();
            App.ButtonStytle(this);
            btnPrint.Visible = false;
            DataTable dt = new DataTable();
            dt = dt_info;
            if (dt != null)
            {
                dt.Columns[0].ColumnName = "病人ID";
                dt.Columns[1].ColumnName = "姓名";
                dt.Columns[2].ColumnName = "住院号";
                //dt.Columns[3].ColumnName = "生日";
                dt.Columns[4].ColumnName = "性别";
                dt.Columns[5].ColumnName = "入院时间";
                dt.Columns[6].ColumnName = "科室ID";
                dt.Columns[7].ColumnName = "科室名称";
                dt.Columns[8].ColumnName = "病区ID";
                dt.Columns[9].ColumnName = "病区名称";
                flgView.DataSource = dt;
                flgView.AllowEditing = false;
                flgView.Cols["birthday"][0] = "生日";
            }
        }

        public frmInOut_PatientInfo(DataTable dt,DataTable dt_inDiag,DataTable dt_outDiag)
        {
            InitializeComponent();
            App.ButtonStytle(this);
            dt.Columns[0].ColumnName = "序号";
            dt.Columns[1].ColumnName = "住院号";
            dt.Columns[2].ColumnName = "姓名";
            dt.Columns[3].ColumnName = "性别";
            dt.Columns[4].ColumnName = "年龄";
            dt.Columns[5].ColumnName = "入院时间";
            dt.Columns[6].ColumnName = "出院时间";
            dt.Columns[7].ColumnName = "入院诊断";
            dt.Columns[8].ColumnName = "出院诊断";
            dt.Columns[9].ColumnName = "入院科室";
            dt.Columns[10].ColumnName = "出院科室";
            flgView.DataSource= dt;
            flgView.AllowEditing = false;//a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name
            flgView.Cols["birthday"].Visible = false;
            flgView.Cols["section_id"].Visible = false;
            flgView.Cols["SICK_AREA_ID"].Visible = false;
            flgView.Cols["SICK_AREA_name"].Visible = false;

            string[] patientsId = new string[dt.Rows.Count];
            for (int i = 0; i < patientsId.Length; i++)
            {
                patientsId[i] = flgView[i + 1, "序号"].ToString(); //dt.Rows[i]["病人ID"].ToString();
            }
            //设置入院诊断
            SetInDiagnose(patientsId, dt_inDiag);
            //设置入院诊断
            SetOutDiagnose(patientsId, dt_outDiag);
            if (beginTime=="" || endTime == "")
            {
                btnPrint.Visible = false;
            }
        }

        private void frmTheday_PatientInfo_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 设置入院诊断
        /// 思路：1、从入院诊断表中找出patient_Id对应的诊断
        ///        如果有0条则显示空，1条直接显示诊断名
        ///        如果多于1条：(1)先找出所有诊断的创建时间，放到List<DateTime>中，排序按升序
        ///                     (2)循环找出DataRow[]中创建时间相同的诊断，并插入表格
        ///        
        /// </summary>
        /// <param name="patientsId">治愈病人ID集合</param>
        /// <param name="dt_allinDiag">所有入院诊断的表</param>
        public void SetInDiagnose(string[] patientsId, DataTable dt_allinDiag)
        {
            string diagNoseSort = "";
            for (int i = 0; i < patientsId.Length; i++)
            {
                DataRow[] dr_inDiag = dt_allinDiag.Select("patient_id=" + patientsId[i]);
                if (dr_inDiag.Length == 1)//只有一条入院诊断
                {
                    flgView[i + 1, "入院诊断"] = dr_inDiag[0]["diagnose_name"].ToString();
                }
                else if (dr_inDiag.Length == 0)//没有入院诊断
                {
                    flgView[i + 1, "入院诊断"] = "";
                }
                else //多条入院诊断，首先判断diagnose_sort的值，如果都为空，则按诊断的创建时间升序排列
                {
                    for (int j = 0; j < dr_inDiag.Length; j++)
                    {
                        diagNoseSort = dr_inDiag[j]["diagnose_sort"].ToString();
                        if (diagNoseSort == "1")//1：表示主诊断
                        {
                            flgView[i + 1, "入院诊断"] = dr_inDiag[j]["diagnose_sort"].ToString();
                        }
                    }
                    if (diagNoseSort == "")//按时间升序排，取最早创建的诊断
                    {
                        //把所有时间取出来保存到List中
                        List<DateTime> list = new List<DateTime>();
                        for (int j = 0; j < dr_inDiag.Length; j++)
                        {
                            list.Add(Convert.ToDateTime(dr_inDiag[j]["create_time"]));
                        }
                        list.Sort();
                        //找到时间最早的诊断，插入表格
                        for (int j = 0; j < dr_inDiag.Length; j++)
                        {
                            if (Convert.ToDateTime(dr_inDiag[j]["create_time"]) == list[0])
                            {
                                flgView[i + 1, "入院诊断"] = dr_inDiag[j]["diagnose_name"].ToString();
                            }
                        }

                    }
                }
            }

        }

        public void SetOutDiagnose(string[] patientsId, DataTable dt_alloutDiag)
        {
            string diagNoseSort = "";
            for (int i = 0; i < patientsId.Length; i++)
            {
                DataRow[] dr_outDiag = dt_alloutDiag.Select("patient_id=" + patientsId[i]);
                if (dr_outDiag.Length == 1)//只有一条出院诊断
                {
                    flgView[i + 1, "出院诊断"] = dr_outDiag[0]["diagnose_name"].ToString();
                }
                else if (dr_outDiag.Length == 0)//没有出院诊断
                {
                    flgView[i + 1, "出院诊断"] = "";
                }
                else //多条出院诊断，首先判断diagnose_sort的值，如果都为空，则按诊断的创建时间升序排列
                {
                    for (int j = 0; j < dr_outDiag.Length; j++)
                    {
                        diagNoseSort = dr_outDiag[j]["diagnose_sort"].ToString();
                        if (diagNoseSort == "1")//1：表示主诊断
                        {
                            flgView[i + 1, "出院诊断"] = dr_outDiag[j]["diagnose_sort"].ToString();
                        }
                    }
                    if (diagNoseSort == "")//按时间升序排，取最早创建的诊断
                    {
                        //把所有时间取出来保存到List中
                        List<DateTime> list = new List<DateTime>();
                        for (int j = 0; j < dr_outDiag.Length; j++)
                        {
                            list.Add(Convert.ToDateTime(dr_outDiag[j]["create_time"]));
                        }
                        list.Sort();
                        //找到时间最早的诊断，插入表格
                        for (int j = 0; j < dr_outDiag.Length; j++)
                        {
                            if (Convert.ToDateTime(dr_outDiag[j]["create_time"]) == list[0])
                            {
                                flgView[i + 1, "出院诊断"] = dr_outDiag[j]["diagnose_name"].ToString();
                            }
                        }

                    }
                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = CreateDataSetWidthFlexGrid(this.flgView);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    frmInOut_Print fp = new frmInOut_Print(ds, frmInOut_PatientInfo.sectionName, frmInOut_PatientInfo.beginTime, frmInOut_PatientInfo.endTime, frmInOut_PatientInfo.titleName);
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
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["入院时间"] = ds.Tables[0].Rows[i]["入院时间"].ToString().Split(' ')[0];
                ds.Tables[0].Rows[i]["出院时间"] = ds.Tables[0].Rows[i]["出院时间"].ToString().Split(' ')[0];
            }
            return ds;
        } 
    }
}