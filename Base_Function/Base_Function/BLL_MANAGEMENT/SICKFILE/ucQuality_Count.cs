using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE.fuyou
{
    public partial class ucQuality_Count : UserControl
    {
        public ucQuality_Count()
        {
            InitializeComponent();

               
        }

     

        /// <summary>
        ///ComboBox控件数据绑定 
        /// </summary>
        private void comboxBox_Data()
        {
            cmbSaties.Items.Add("黄灯");
            cmbSaties.Items.Add("红灯");
            cmbSaties.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSaties.SelectedIndex = 0;

            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='39'");
            cmbFrequencyUnit.DataSource = ds.Tables[0].DefaultView;
            cmbFrequencyUnit.ValueMember = "ID";
            cmbFrequencyUnit.DisplayMember = "NAME";
        }

        /// <summary>
        /// 查询按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            flgview.Rows.Count = 1;
            //全院
            if (cmbFrequencyUnit.SelectedValue.ToString() == "178")
            {
                Check_All_Hospital();
            }
            //科室——病区
            else
            {
                Data_Search();
            }

        }

        /// <summary>
        /// 科室—病区查询
        /// </summary>
        private void Data_Search()
        {
            Bifrost.WebReference.Class_Table[] tables = new Bifrost.WebReference.Class_Table[3];
            DataSet ds = new DataSet();

            string sql_quality = @"select t.section_sickaera,t.doctype,count(t.id) from  t_quality_record t
                            inner join t_in_patient b on b.id=t.patient_id where 1=1";

            if (chkInTime.Checked == true)
            {
                //string strStart = dtpStart.Value.ToString();
                //string strEnd = dtpEnd.Value.ToString();

                //sql_quality += "AND to_char(b.in_time,'yyyy-mm-dd')between '" + strStart + "' and '" + strEnd + "'";
                sql_quality += " AND b.in_time between to_date('" + this.dtpStart.Value.ToShortDateString() + "','yyyy-mm-dd') and to_date('" + this.dtpEnd.Value.ToShortDateString() + "','yyyy-mm-dd')";
            }           

            //黄灯
            if (cmbSaties.SelectedIndex == 0)
            {
                sql_quality += " and pv='3'";
            }
            //红灯
            else if (cmbSaties.SelectedIndex == 1)
            {
                sql_quality += " and pv='1'";
            }

            //所有病区
            string sql_Sickarea = "select said,sick_area_name from t_sickareainfo";
            //所有科室
            string sql_Section = "select sid,section_name from t_sectioninfo where enable_flag='Y'";

            tables[0] = new Bifrost.WebReference.Class_Table();
            tables[0].Sql = sql_Sickarea;
            tables[0].Tablename = "sickarea";

            tables[1] = new Bifrost.WebReference.Class_Table();
            tables[1].Sql = sql_Section;
            tables[1].Tablename = "section";

            tables[2] = new Bifrost.WebReference.Class_Table();
            tables[2].Sql = sql_quality + "group by t.section_sickaera,t.doctype";
            tables[2].Tablename = "quality";

            try
            {
                ds = App.GetDataSet(tables);
            }
            catch (Exception ex)
            {
                return;
            }
            //病区
            if (cmbFrequencyUnit.SelectedValue.ToString() == "179")
            {
                Check_By_SickArea(ds);
            }
            //科室
            else if (cmbFrequencyUnit.SelectedValue.ToString() == "180")
            {
                Check_By_Section(ds);
            }
        }

        /// <summary>
        /// 表头设置
        /// </summary>
        private void setTableHeader()
        {
            string strSql = "select name  from t_data_code ta where ta.type = 18 and ta.name not in ('体温单', '一般护理记录', '危重护理记录')";
            DataSet ds = App.GetDataSet(strSql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    flgview.Cols.Count = ds.Tables[0].Rows.Count + 1;

                    flgview[0, 0] = "病区（科室）";

                    //绑定列名
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        flgview[0, i + 1] = ds.Tables[0].Rows[i][0].ToString();
                    }

                    //列名居中
                    for (int i = 0; i < flgview.Cols.Count; i++)
                    {
                        flgview.Cols[i].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;

                    }

                    flgview.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
                }

                flgview.AutoSizeCols();//自适应列宽
                flgview.Cols[0].Width = 150;//科室列宽
                flgview.Rows.Fixed = 0;
            }
        }

        /// <summary>
        /// 按病区统计
        /// </summary>
        private void Check_By_SickArea(DataSet ds)
        {
            int sickCount = ds.Tables["sickarea"].Rows.Count;

            for (int i = 0; i < sickCount; i++)
            {
                flgview.Rows.Add();
                DataRow dr = ds.Tables["sickarea"].Rows[i];
                string sickId = dr["said"].ToString(); //病区ID
                string sickName = dr["sick_area_name"].ToString(); //病区名称
                flgview[i + 1, 0] = sickName;

                for (int j = 0; j < flgview.Cols.Count - 1; j++)
                {
                    int iLength = ds.Tables["quality"].Select("section_sickaera='" + sickId + "' and doctype='" + flgview[0, j + 1].ToString() + "'").Length;


                    if (iLength == 0)
                    {
                        flgview[i + 1, j + 1] = 0;
                    }
                    else
                    {
                        DataRow[] drr = ds.Tables["quality"].Select("section_sickaera='" + sickId + "' and doctype='" + flgview[0, j + 1].ToString() + "'");
                        flgview[i + 1, j + 1] = drr[0]["count(t.id)"].ToString();
                    }
                }
            }

        }

        /// <summary>
        /// 按科室统计
        /// </summary>
        private void Check_By_Section(DataSet ds)
        {
            int sickCount = ds.Tables["section"].Rows.Count;

            for (int i = 0; i < sickCount; i++)
            {
                flgview.Rows.Add();
                DataRow dr = ds.Tables["section"].Rows[i];
                string sickId = dr["sid"].ToString(); //病区ID
                string sickName = dr["section_name"].ToString(); //病区名称
                flgview[i + 1, 0] = sickName;

                for (int j = 0; j < flgview.Cols.Count - 1; j++)
                {
                    int iLength = ds.Tables["quality"].Select("section_sickaera='" + sickId + "' and doctype='" + flgview[0, j + 1].ToString() + "'").Length;


                    if (iLength == 0)
                    {
                        flgview[i + 1, j + 1] = 0;
                    }
                    else
                    {
                        DataRow[] drr = ds.Tables["quality"].Select("section_sickaera='" + sickId + "' and doctype='" + flgview[0, j + 1].ToString() + "'");
                        flgview[i + 1, j + 1] = drr[0]["count(t.id)"].ToString();
                    }
                }
            }

        }

        /// <summary>
        /// 全院统计
        /// </summary>
        /// <param name="ds"></param>
        private void Check_All_Hospital()
        {
            string sql_quality = @"select t.doctype,count(t.id) from t_quality_record t
                            inner join t_in_patient b on b.id=t.patient_id where 1=1";

            if (chkInTime.Checked == true)
            {
                //string strStart = dtpStart.Value.ToString();
                //string strEnd = dtpEnd.Value.ToString();

                sql_quality += " AND b.in_time between to_date('" + this.dtpStart.Value.ToShortDateString() + "','yyyy-mm-dd') and to_date('" + this.dtpEnd.Value.ToShortDateString() + "','yyyy-mm-dd')";
            }

            //黄灯
            if (cmbSaties.SelectedIndex == 0)
            {
                sql_quality += " and pv='3'";
            }
            //红灯
            else if (cmbSaties.SelectedIndex == 1)
            {
                sql_quality += " and pv='1'";
            }

            sql_quality += "group by t.doctype";

            DataSet ds = new DataSet();
            try
            {                
                ds = App.GetDataSet(sql_quality);
            }
            catch (Exception ex) 
            { 
                return; 
            }

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    flgview.Rows.Add();
                    flgview[1, 0] = "全院";

                    for (int j = 0; j < flgview.Cols.Count - 1; j++)
                    {
                        int iLength = ds.Tables[0].Select("doctype='" + flgview[0, j + 1].ToString() + "'").Length;

                        if (iLength == 0)
                        {
                            flgview[1, j + 1] = 0;
                        }
                        else
                        {
                            DataRow[] drr = ds.Tables[0].Select("doctype='" + flgview[0, j + 1].ToString() + "'");
                            flgview[1, j + 1] = drr[0]["count(t.id)"].ToString();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 导出Excel按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "质控统计.xls";
            saveFileDialog1.Filter = "Excel工作簿(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

        /// <summary>
        /// 保存Excel提示框确定按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            flgview.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);

        }

        private void ucQuality_Count_Load(object sender, EventArgs e)
        {
            try
            {
                comboxBox_Data();//下拉框绑定
                setTableHeader();//表头设置 
            }
            catch (Exception ex)
            { }
        }
    }
}
