using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class ucOverthirtySum_Statistics : UserControl
    {
        public ucOverthirtySum_Statistics()
        {
            InitializeComponent();
            this.Load += new EventHandler(ucOverthirtySum_Statistics_Load);
        }

        private DataSet ds = new DataSet();

        void ucOverthirtySum_Statistics_Load(object sender, EventArgs e)
        {           
            InitUnit();
        }

        /// <summary>
        /// 全院查询
        /// </summary>
        private void Check_All_Hospital()
        {

            //在表格中添加一个空行
            flgview.Rows.Add();
            flgview[1, 0] = "全院";

            int val = 0;
            val = ds.Tables[0].DefaultView.ToTable(true, "文书主键").Rows.Count;
            flgview[1, 1] = val;
        }

        /// <summary>
        /// 科室查询
        /// </summary>
        private void Check_By_Section()
        {
            DataSet dsDept = App.GetDataSet("select sid,section_name from t_sectioninfo where enable_flag='Y'");
            int sectionCount = dsDept.Tables[0].Rows.Count;
            int val = 0;

            for (int i = 0; i < sectionCount; i++)
            {
                flgview.Rows.Add();
                DataRow dr = dsDept.Tables[0].Rows[i];
                string sectionId = dr["sid"].ToString(); //病区ID
                string sectionName = dr["section_name"].ToString(); //病区名称

                flgview[i + 1, 0] = sectionName;

                val = ds.Tables[0].DefaultView.ToTable(true, "文书主键", "section_id").Select("section_id='" + sectionId + "'").Length;
                flgview[i + 1, 1] = val;

            }

        }

        //绑定频次统计单位
        private void InitUnit()
        {
            try
            {
                DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='39'");
                cboUnit.DataSource = ds.Tables[0].DefaultView;
                cboUnit.ValueMember = "ID";
                cboUnit.DisplayMember = "NAME";
            }
            catch { }
        }


        /// <summary>
        /// 设置表头
        /// </summary>
        public void setTableHeader()
        {
            try
            {
                flgview.Cols.Count = 2;
                //flgview.Rows.Fixed = 1;

                flgview.Cols[0].Width = 100;
                flgview.Cols[1].Width = 100;

                for (int i = 0; i < flgview.Cols.Count; i++)
                {
                    flgview.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
                }


                //单元格合并和设置 
                flgview[0, 0] = "科室";
                flgview[0, 1] = "书写份数合计";
                flgview.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
                flgview.Cols.Fixed = 0;
            }
            catch
            { }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            Get_Search_Data();

            flgview.Rows.Count = 1;
            if (cboUnit.SelectedValue.ToString() == "178")
            {
                //全院
                setTableHeader();
                Check_All_Hospital();
            }
            else if (cboUnit.SelectedValue.ToString() == "179")
            {
                //病区
                setTableHeader();
                Check_By_Section();
            }
            else if (cboUnit.SelectedValue.ToString() == "180")
            {
                //科室
                setTableHeader();
                Check_By_Section();
            }
        }

        private void Get_Search_Data()
        {
            string sql = @"select b.section_name as 科室,a.上报人,b.patient_name as 患者姓名,b.pid as 住院号,b.in_time as 住院时间,a.上报时间 as 书写时间,a.住院天数,b.sick_doctor_name as 主管医生,b.section_id,a.id as 文书主键 from t_overthirty_up a inner join t_in_patient b on a.patient_id = b.id";


            if (this.rbnIntime.Checked)
            {
                string dataStart = dtpInStart.Value.ToString("yyyy-MM-dd ");
                string dataend = dtpInEnd.Value.ToString("yyyy-MM-dd ");

                sql += " where to_char(b.in_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
            }
            else if (this.rbnOuttime.Checked)
            {
                string dataStart = dtpOutStart.Value.ToString("yyyy-MM-dd ");
                string dataend = dtpOutEnd.Value.ToString("yyyy-MM-dd ");

                sql += " where to_char(b.die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
            }
            else if (this.rbnWritetime.Checked)
            {
                string dataStart = dtpWriteStart.Value.ToString("yyyy-MM-dd ");
                string dataend = dtpWriteEnd.Value.ToString("yyyy-MM-dd ");

                sql += " where a.上报时间  between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
            }

            ds = App.GetDataSet(sql);

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "住院超过30天统计表.xls.xls";
            saveFileDialog1.Filter = "Excel工作簿(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            this.flgview.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
        }
    }
}