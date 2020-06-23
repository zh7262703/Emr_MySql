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
    public partial class frmQCTextCommit_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {
        public frmQCTextCommit_PatientInfo()
        {
            InitializeComponent();
        }
        public frmQCTextCommit_PatientInfo(DataTable dt_info, DataTable dt_allinDiag)
        {
            InitializeComponent();
            App.ButtonStytle(this);

            flgView.DataSource = dt_info;
            flgView.AllowEditing = false;
            flgView.Cols["section_id"].Visible = false;
            flgView.Cols["SICK_AREA_ID"].Visible = false;
            flgView.Cols["SICK_AREA_name"].Visible = false;
            flgView.Cols["科室"].Visible = false;
            flgView.Cols["病人ID"].Visible = false;
            flgView.Cols["入院诊断"].Width = 300;

            string[] patientsId = new string[dt_info.Rows.Count];
            for (int i = 0; i < patientsId.Length; i++)
            {
                patientsId[i] = flgView[i + 1, "病人ID"].ToString(); //dt.Rows[i]["病人ID"].ToString();
            }
            //设置入院诊断
            SetInDiagnose(patientsId, dt_allinDiag);
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

     
        private void btnPrint_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "质控办文书完成统计详细列表.xls";
            saveFileDialog1.Filter = "Excel工作簿(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            flgView.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
        }
    }
}