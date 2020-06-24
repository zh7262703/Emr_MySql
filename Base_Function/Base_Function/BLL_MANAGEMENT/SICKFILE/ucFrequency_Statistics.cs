using System;
using System.Collections;
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
    public partial class ucFrequency_Statistics : UserControl
    {
        ArrayList Cols = new ArrayList();
        /// <summary>
        /// 所有数据
        /// </summary>
        DataSet ds = null;
        /// <summary>
        /// 全局变量，记录查询范围，只有再次查询时，状态才改变
        /// </summary>
        string searchName = "";
        /// <summary>
        /// 列的集合
        /// </summary>
        ColumnInfo[] cols = new ColumnInfo[28];

        public ucFrequency_Statistics()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void ucFrequency_Statistics_Load(object sender, EventArgs e)
        {
            try
            {
                flgview.MouseHoverCell += new EventHandler(fg_MouseHover);
                flgview.AllowEditing = false;
                FrequencyUnit();
                Frequency();
                setTableHeader();
                CellMerge();
            }
            catch
            {
            }


        }

        int oldRow = 0;
        /// <summary>
        /// 鼠标停留，行底色改变 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fg_MouseHover(object sender, EventArgs e)
        {
            int Row = flgview.MouseRow;

            if (Row > 0)
            {
                if (Row != oldRow && oldRow <= flgview.Rows.Count)
                {
                    flgview.Rows[Row].StyleNew.BackColor = ColorTranslator.FromHtml("#e9f7f6");
                    flgview.Rows[Row].StyleNew.ForeColor = ColorTranslator.FromHtml("#00619d");
                    flgview.Cursor = Cursors.Hand;
                    flgview.Cols[2].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
                    if (oldRow > 0)
                    {
                        if (oldRow < flgview.Rows.Count && oldRow > 0)
                        {
                            flgview.Rows[oldRow].StyleNew.BackColor = flgview.BackColor;
                            flgview.Rows[oldRow].StyleNew.ForeColor = flgview.ForeColor;
                        }
                    }
                }
                oldRow = Row;
            }
        }
        /// <summary>
        /// 设置表头
        /// </summary>
        public void setTableHeader()
        {
            try
            {
                flgview.Cols.Count = 12;
                flgview.Rows.Fixed = 1;
                //表头设置

                cols[0].Name = "病区（科室）";
                cols[0].Field = "Sick_Section";
                cols[0].Index = 1;
                cols[0].visible = true;

                cols[1].Name = "入院人数";
                cols[1].Field = "into_area";
                cols[1].Index = 2;
                cols[1].visible = true;

                cols[2].Name = "出院人数";
                cols[2].Field = "out_area";
                cols[2].Index = 3;
                cols[2].visible = true;

                cols[3].Name = "转出人次";
                cols[3].Field = "turn_out";
                cols[3].Index = 4;
                cols[3].visible = true;

                cols[4].Name = "转入人次";
                cols[4].Field = "turn_in";
                cols[4].Index = 5;
                cols[4].visible = true;

                cols[5].Name = "手术人数";
                cols[5].Field = "operate";
                cols[5].Index = 6;
                cols[5].visible = true;

                cols[6].Name = "发会诊人次";
                cols[6].Field = "consultation_apply";
                cols[6].Index = 7;
                cols[6].visible = true;

                cols[7].Name = "接会诊人次";
                cols[7].Field = "consultaion_recive";
                cols[7].Index = 8;
                cols[7].visible = true;

                cols[8].Name = "病危人数";
                cols[8].Field = "danger";
                cols[8].Index = 9;
                cols[8].visible = true;

                cols[9].Name = "病重人数";
                cols[9].Field = "bad";
                cols[9].Index = 10;
                cols[9].visible = true;

                cols[10].Name = "治愈率";
                cols[10].Field = "ZhiyuLv";
                cols[10].Index = 11;
                cols[10].visible = true;

                cols[11].Name = "病死率";
                cols[11].Field = "BingSiLv";
                cols[11].Index = 12;
                cols[11].visible = true;

                //cols[12].Name = "诊断正确率";
                //cols[12].Field = "ZhenDuanZhengQueLv";
                //cols[12].Index = 13;
                //cols[12].visible = true;

                //cols[13].Name = "误诊率";
                //cols[13].Field = "WuZhenLv";
                //cols[13].Index = 14;
                //cols[13].visible = true;

                flgview.Cols[0].Width = 80;
                flgview.Cols[1].Width = 60;
                flgview.Cols[2].Width = 60;
                flgview.Cols[3].Width = 60;
                flgview.Cols[4].Width = 60;
                flgview.Cols[5].Width = 60;
                flgview.Cols[6].Width = 60;
                flgview.Cols[7].Width = 60;
                flgview.Cols[8].Width = 60;
                flgview.Cols[9].Width = 60;
                flgview.Cols[10].Width = 60;
                flgview.Cols[11].Width = 60;
                //flgview.Cols[12].Width = 60;
                //flgview.Cols[13].Width = 60;
                for (int i = 0; i < flgview.Cols.Count; i++)
                {
                    flgview.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
                }
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// 单元格合并
        /// </summary>
        public void CellMerge()
        {
            //单元格合并和设置           
            flgview[0, 0] = "病区（科室）";
            flgview[0, 1] = "入院人数";
            flgview[0, 2] = "出院人数";
            flgview[0, 3] = "转出人次";
            flgview[0, 4] = "转入人次";
            flgview[0, 5] = "手术人数";
            flgview[0, 6] = "发会诊人次";
            flgview[0, 7] = "接会诊人次";
            flgview[0, 8] = "病危人数";
            flgview[0, 9] = "病重人数";
            flgview[0, 10] = "治愈率";
            flgview[0, 11] = "病死率";
            //flgview[0, 12] = "诊断正确率";
            //flgview[0, 13] = "误诊率";
            flgview.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgview.Cols.Fixed = 0;
        }

        //绑定频次统计单位
        private void FrequencyUnit()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='39'");
            cboFrequencyUnit.DataSource = ds.Tables[0].DefaultView;
            cboFrequencyUnit.ValueMember = "ID";
            cboFrequencyUnit.DisplayMember = "NAME";
        }

        //绑定频率
        private void Frequency()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='42'");
            cboFrequency.DataSource = ds.Tables[0].DefaultView;
            cboFrequency.ValueMember = "ID";
            cboFrequency.DisplayMember = "NAME";
        }
        /// 求某年有多少周
        /// 返回 int
        /// </summary>
        /// <param name="strYear"></param>
        /// <returns>int</returns>
        public static int GetYearWeekCount(int strYear)
        {

            System.DateTime fDt = DateTime.Parse(strYear.ToString() + "-01-01");
            int k = Convert.ToInt32(fDt.DayOfWeek);//得到该年的第一天是周几 
            if (k == 1)
            {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 1;
                return countWeek;

            }
            else
            {
                int countDay = fDt.AddYears(1).AddDays(-1).DayOfYear;
                int countWeek = countDay / 7 + 2;
                return countWeek;
            }

        }

        private void Month()
        {
            try
            {
                if (cboFrequency.Text == "")
                {
                    return;
                }
                //按周判断
                if (Convert.ToInt32(cboFrequency.SelectedValue.ToString()) == 197)
                {

                    //string dateend = dtpEndYear.Value.ToString("yyyy-MM");
                    dtpStartYear.Format = DateTimePickerFormat.Custom;
                    dtpStartYear.CustomFormat = "yyyy";

                    lblWeek.Visible = true;
                    cboWeek.Visible = true;
                    cboStartMonth.Visible = false;
                    lblStartMonth.Visible = false;
                }
                //按月判断：198
                if (Convert.ToInt32(cboFrequency.SelectedValue.ToString()) == 198)
                {
                    string datestart = dtpStartYear.Value.ToString("yyyy-MM");
                    //string dateend = dtpEndYear.Value.ToString("yyyy-MM");
                    dtpStartYear.Format = DateTimePickerFormat.Custom;
                    dtpStartYear.CustomFormat = "yyyy-MM";
                    //dtpEndYear.Format = DateTimePickerFormat.Custom;
                    //dtpEndYear.CustomFormat = "yyyy-MM";
                    dtpStartYear.Value = Convert.ToDateTime(datestart);
                    //dtpEndYear.Value = Convert.ToDateTime(dateend);
                    cboStartMonth.Visible = false;
                    lblStartMonth.Visible = false;
                    lblWeek.Visible = false;
                    cboWeek.Visible = false;
                }
                //按季度判断：199
                if (Convert.ToInt32(cboFrequency.SelectedValue.ToString()) == 199)
                {
                    //lblStartMonth.Text = "季度";
                    //lblEndMonth.Text = "季度";
                    cboStartMonth.Visible = true;
                    lblStartMonth.Visible = true;
                    lblWeek.Visible = false;
                    cboWeek.Visible = false;

                }
                //按年判断：200
                if (Convert.ToInt32(cboFrequency.SelectedValue.ToString()) == 200)
                {
                    string datestart = dtpStartYear.Value.ToString("yyyy");
                    //string dateend = dtpEndYear.Value.ToString("yyyy");
                    dtpStartYear.Format = DateTimePickerFormat.Custom;
                    dtpStartYear.CustomFormat = "yyyy";
                    lblWeek.Visible = false;
                    cboWeek.Visible = false;
                    cboStartMonth.Visible = false;
                    lblStartMonth.Visible = false;

                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 频率值判断
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void cboFrequency_SelectedValueChanged(object sender, EventArgs e)
        {
            Month();
        }

        ///// <summary>
        ///// 根据月份返回季度
        ///// </summary>
        ///// <param Name="mounth"></param>
        ///// <returns></returns>
        //private string Return_Jidu(int mounth)
        //{
        //    if (mounth >= 1 && mounth <= 3)
        //    {
        //        return "1季度";
        //    }
        //    else if (mounth >= 4 && mounth <= 6)
        //    {
        //        return "2季度";
        //    }
        //    else if (mounth >= 7 && mounth <= 9)
        //    {
        //        return "3季度";
        //    }
        //    else
        //    {
        //        return "4季度";
        //    }
        //}

        /// <summary>
        /// 添加季度
        /// </summary>
        /// <param Name="tempVal"></param>
        /// <returns></returns>
        private void Add_Jidu(string tempVal)
        {
            if (Cols.Count > 0)
            {
                if (Cols[Cols.Count - 1].ToString() != tempVal)
                {
                    Cols.Add(tempVal);
                }
            }
            else
                Cols.Add(tempVal);
        }

        /// <summary>
        /// 全院查询
        /// </summary>
        private void Check_All_Hospital()
        {
            string datestart = dtpStartYear.Value.ToString("yyyy-MM");
            //string dateend = dtpEndYear.Value.ToString("yyyy-MM");
            string dataStart = dtpStartYear.Value.ToString("yyyy");
            //string dataEnd = dtpEndYear.Value.ToString("yyyy");

            //在表格中添加一个空行
            flgview.Rows.Add();
            flgview[1, 0] = "全院";

            int val = 0;
            val = ds.Tables["into_area"].Rows.Count;
            flgview[1, 1] = val;

            val = ds.Tables["out_area"].Rows.Count;
            flgview[1, 2] = val;

            val = ds.Tables["turn_out"].Rows.Count;
            flgview[1, 3] = val;

            val = ds.Tables["turn_in"].Rows.Count;
            flgview[1, 4] = val;

            val = ds.Tables["operate"].Rows.Count;
            flgview[1, 5] = val;

            val = ds.Tables["consultaion_applay"].Rows.Count;
            flgview[1, 6] = val;

            val = ds.Tables["consultaion_recive"].Rows.Count;
            flgview[1, 7] = val;

            val = ds.Tables["danger"].Rows.Count;
            flgview[1, 8] = val;

            val = ds.Tables["bad"].Rows.Count;
            flgview[1, 9] = val;
            //治愈率等于治愈人数除以出院人数
            int out_area_Count = ds.Tables["out_area"].Rows.Count;
            int zy_Count = ds.Tables["zhiyulv"].Rows.Count; //治愈人数
            double valdouble = 0.00;        //概率计算精确到小数点后两位
            if (zy_Count != 0)
            {
                valdouble = Convert.ToDouble(zy_Count) * 100 / Convert.ToDouble(out_area_Count);
                flgview[1, 10] = Convert.ToDouble(valdouble.ToString("0.00"))+"%";
            }
            else
            {
                flgview[1, 10] = 0 + "%";
            }
            //病死率等于病死人数除以出院人数
            int bs_Count = ds.Tables["bingsilv"].Rows.Count;
            if (bs_Count != 0)
            {
                valdouble = Convert.ToDouble(bs_Count) * 100 / Convert.ToDouble(out_area_Count);
                flgview[1, 11] = valdouble.ToString("0.00") + "%";
            }
            else
            {
                flgview[1, 11] = 0 + "%";
            }
            //诊断正确率等于正确诊断数除以入院人数
            //int zd_Count = ds.Tables["zhenduan_right"].Rows.Count;
            //if (zd_Count != 0)
            //{
            //    valdouble = Convert.ToDouble(zd_Count) * 100 / Convert.ToDouble(out_area_Count);
            //    flgview[1, 12] = valdouble.ToString("0.00") + "%";
            //}
            //else
            //{
            //    flgview[1, 12] = 0 + "%";
            //}
            //误诊率：误诊人数等于出院人数减去诊断正确数
            //if (zd_Count != 0)
            //{
            //    valdouble = Convert.ToDouble((out_area_Count - zd_Count)) * 100 / Convert.ToDouble(out_area_Count);
            //    flgview[1, 13] = valdouble.ToString("0.00") + "%";
            //}
            //else
            //{
            //    flgview[1, 13] = 100 + "%";
            //}
        }

        /// <summary>
        /// 科室查询
        /// </summary>
        private void    Check_By_Section()
        {
            //string datestart = dtpStartYear.Value.ToString("yyyy-MM");
            //string dateend = dtpEndYear.Value.ToString("yyyy-MM");
            //string dataStart = dtpStartYear.Value.ToString("yyyy");
            //string dataEnd = dtpEndYear.Value.ToString("yyyy");
            int sectionCount = ds.Tables["section"].Rows.Count;
            int val = 0;

            for (int i = 0; i < sectionCount; i++)
            {
                flgview.Rows.Add();
                DataRow dr = ds.Tables["section"].Rows[i];
                string sectionId = dr["sid"].ToString(); //病区ID
                string sectionName = dr["section_name"].ToString(); //病区名称

                flgview[i + 1, 0] = sectionName;

                val = ds.Tables["into_area"].Select("section_id='" + sectionId + "'").Length;
                flgview[i + 1, 1] = val;

                val = ds.Tables["out_area"].Select("section_id='" + sectionId + "'").Length;
                flgview[i + 1, 2] = val;

                val = ds.Tables["turn_out"].Select("sid='" + sectionId + "'").Length;
                flgview[i + 1, 3] = val;

                val = ds.Tables["turn_in"].Select("sid='" + sectionId + "'").Length;
                flgview[i + 1, 4] = val;

                val = ds.Tables["operate"].Select("section_id='" + sectionId + "'").Length;
                flgview[i + 1, 5] = val;

                val = ds.Tables["consultaion_applay"].Select("apply_sectionid='" + sectionId + "'").Length;
                flgview[i + 1, 6] = val;

                val = ds.Tables["consultaion_recive"].Select("consul_record_section_id='" + sectionId + "'").Length;
                flgview[i + 1, 7] = val;

                val = ds.Tables["danger"].Select("section_id='" + sectionId + "'").Length;
                flgview[i + 1, 8] = val;

                val = ds.Tables["bad"].Select("section_id='" + sectionId + "'").Length;
                flgview[i + 1, 9] = val;



                //治愈率
                int out_area_Count = ds.Tables["out_area"].Select("section_id='" + sectionId + "'").Length;//入院人数
                int zy_Count = ds.Tables["zhiyulv"].Select("section_id='" + sectionId + "'").Length;//治愈人数
                double valdouble = 0.00;    //概率计算精确到小数点后两位
                if (zy_Count != 0)
                {
                    valdouble = Convert.ToDouble(zy_Count) * 100 / Convert.ToDouble(out_area_Count);
                    flgview[i + 1, 10] = valdouble.ToString("0.00") + "%";
                }
                else
                {
                    flgview[i + 1, 10] = 0 + "%";
                }
                //病死率
                int bs_Count = ds.Tables["bingsilv"].Select("section_id='" + sectionId + "'").Length;//病死人数
                if (bs_Count != 0)
                {
                    valdouble = Convert.ToDouble(bs_Count) * 100 / Convert.ToDouble(out_area_Count);
                    flgview[i + 1, 11] = valdouble.ToString("0.00") + "%";
                }
                else
                {
                    flgview[i + 1, 11] = 0 + "%";
                }
                //诊断正确率
                //int zd_Count = ds.Tables["zhenduan_right"].Select("section_id='" + sectionId + "'").Length;//正确诊断数
                //if (zd_Count != 0)
                //{
                //    valdouble = Convert.ToDouble(zd_Count) * 100 / Convert.ToDouble(out_area_Count);
                //    flgview[i + 1, 12] = valdouble.ToString("0.00");
                //}
                //else
                //{
                //    flgview[i + 1, 12] = 0;
                //}

                //诊断错误率
                //if (zd_Count != 0)
                //{
                //    valdouble = Convert.ToDouble((out_area_Count - zd_Count)) / Convert.ToDouble(out_area_Count);

                //    flgview[i + 1, 13] = valdouble.ToString("0.00");
                //}
                //else
                //{
                //    flgview[i + 1, 13] = 100;
                //}

            }

        }

        /// <summary>
        /// 病区查询
        /// </summary>
        private void Check_By_SickArea()
        {
            //string datestart = dtpStartYear.Value.ToString("yyyy-MM");
            //string dateend = dtpEndYear.Value.ToString("yyyy-MM");
            //string dataStart = dtpStartYear.Value.ToString("yyyy");
            //string dataEnd = dtpEndYear.Value.ToString("yyyy");
            int sickCount = ds.Tables["sickarea"].Rows.Count;


            int val = 0;

            for (int i = 0; i < sickCount; i++)
            {
                flgview.Rows.Add();
                DataRow dr = ds.Tables["sickarea"].Rows[i];
                string sickId = dr["said"].ToString(); //病区ID
                string sickName = dr["sick_area_name"].ToString(); //病区名称
                flgview[i + 1, 0] = sickName;

                val = ds.Tables["into_area"].Select("sick_area_id='" + sickId + "'").Length;
                flgview[i + 1, 1] = val;

                val = ds.Tables["out_area"].Select("sick_area_id='" + sickId + "'").Length;
                flgview[i + 1, 2] = val;

                val = ds.Tables["turn_out"].Select("said='" + sickId + "'").Length;
                flgview[i + 1, 3] = val;

                val = ds.Tables["turn_in"].Select("said='" + sickId + "'").Length;
                flgview[i + 1, 4] = val;

                val = ds.Tables["operate"].Select("sick_area_id='" + sickId + "'").Length;
                flgview[i + 1, 5] = val;

                val = ds.Tables["consultaion_applay"].Select("sick_area_id='" + sickId + "'").Length;
                flgview[i + 1, 6] = val;

                val = ds.Tables["consultaion_recive"].Select("said='" + sickId + "'").Length;
                flgview[i + 1, 7] = val;

                val = ds.Tables["danger"].Select("sick_area_id='" + sickId + "'").Length;
                flgview[i + 1, 8] = val;

                val = ds.Tables["bad"].Select("sick_area_id='" + sickId + "'").Length;
                flgview[i + 1, 9] = val;

                int out_area_Count = ds.Tables["out_area"].Select("sick_area_id='" + sickId + "'").Length;//入院人数
                int zy_Count = ds.Tables["zhiyulv"].Select("sick_area_id='" + sickId + "'").Length;//治愈人数
                double valdouble = 0.00;
                //治愈率
                if (zy_Count != 0)
                {
                    valdouble = Convert.ToDouble(zy_Count) * 100 / Convert.ToDouble(out_area_Count);
                    flgview[i + 1, 10] = valdouble.ToString("0.00") + "%";
                }
                else
                {
                    flgview[i + 1, 10] = 0 + "%";
                }
                //病死率
                int bz_Count = ds.Tables["bingsilv"].Select("sick_area_id='" + sickId + "'").Length;//病死人数
                if (bz_Count != 0)
                {
                    valdouble = Convert.ToDouble(bz_Count) * 100 / Convert.ToDouble(out_area_Count);
                    flgview[i + 1, 11] = valdouble.ToString("0.00") + "%";
                }
                else
                {
                    flgview[i + 1, 11] = 0 + "%";
                }
                //诊断正确率
                //int zd_Count = ds.Tables["zhenduan_right"].Select("sick_area_id='" + sickId + "'").Length;//正确诊断数
                //if (zd_Count != 0)
                //{
                //    valdouble = Convert.ToDouble(zd_Count) * 100 / Convert.ToDouble(out_area_Count);
                //    flgview[i + 1, 12] = valdouble.ToString("0.00");
                //}
                //else
                //{
                //    flgview[i + 1, 12] = 0;
                //}

                //诊断错误率
                //if (zd_Count != 0)
                //{
                //    valdouble = Convert.ToDouble((out_area_Count - zd_Count)) * 100 / Convert.ToDouble(out_area_Count);
                //    flgview[i + 1, 13] = valdouble.ToString("0.00");
                //}
                //else
                //{
                //    flgview[i + 1, 13] = 100;
                //}
            }
        }

        /// <summary>
        /// 统计
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            //每次查询，重新赋值
            searchName = cboFrequencyUnit.Text;
            //获取查询的数据
            Get_Search_Data();
            flgview.Rows.Count = 1;
            if (cboFrequencyUnit.SelectedValue.ToString() == "178")
            {
                //全院
                Check_All_Hospital();
            }
            else if (cboFrequencyUnit.SelectedValue.ToString() == "179")
            {
                //病区
                Check_By_SickArea();
            }
            else if (cboFrequencyUnit.SelectedValue.ToString() == "180")
            {
                //科室
                Check_By_Section();
            }

        }



        /// <summary>
        /// 获取查询的数据
        /// </summary>
        private void Get_Search_Data()
        {
            Class_Table[] tables = new Class_Table[15];

            //所有病区
            string sql_Sickarea = "select said,sick_area_name from t_sickareainfo";
            //所有科室
            string sql_Section = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
            //入院人数
            string sql_into_area = "select a.id,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,a.in_time,a.die_time,'' as 入院诊断,'' as 出院诊断,a.insection_name ,a.section_name ,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a where (select count(id) from t_inhospital_action b where b.patient_id=a.id)>0 ";
            //出院人数
            string sql_out_area = "select distinct a.id,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,a.in_time,a.die_time,'' as 入院诊断,'' as 出院诊断,a.insection_name ,a.section_name ,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where b.next_id=0 and b.ACTION_TYPE='出区' and b.ACTION_STATE=3 and a.die_flag<>1 ";
            //转出人次
            string sql_turn_out = "select distinct a.id, a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,d.section_name ,e.section_name 转入科室,b.happen_time,a.section_name ,b.sid,b.said,f.sick_area_name from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id inner join t_inhospital_action c on a.id=c.patient_id  inner join t_sectioninfo d on b.sid=d.sid inner join t_sectioninfo e on b.target_sid=e.sid inner join t_sickareainfo f on b.said=f.said where b.action_type='转出' and c.action_type='转入' and b.next_id=c.id ";
            //转入人次
            string sql_turn_in = "select distinct a.id, a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,d.section_name 转出科室,e.section_name,c.happen_time,a.section_name ,c.sid,c.said,f.sick_area_name from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id inner join t_inhospital_action c on a.id=c.patient_id  inner join t_sectioninfo d on b.sid=d.sid inner join t_sectioninfo e on b.target_sid=e.sid inner join t_sickareainfo f on c.said=f.said where b.action_type='转出' and c.action_type='转入' and b.next_id=c.id ";
            //手术人数
            string sql_operate = "select distinct a.id,a.section_name,e.operator,e.oper_assist1,e.oper_assist2,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit),c.diagnose_name,e.oper_date,e.oper_name,'' as 手术分类,a.birthday,a.section_id,a.in_time,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id left join t_diagnose_item c on a.id=c.patient_id and c.diagnose_type=401 left join COVER_OPERATION e on a.id=e.inpatient_id  where a.id in(select patient_id from t_quality_text g  where g.texttkind_id=151 ";
            //发会诊人次
            string sql_consultaion_applay = "select a.*,b.sick_area_id,b.birthday from t_consultaion_apply a inner join t_in_patient b on a.patient_id=b.id inner join t_consultaion_record c on a.id=c.apply_id  where submited='Y'";
            //接会诊人次
            string sql_consultaion_recive = "select a.consul_record_section_id,d.said,c.birthday from t_consultaion_record a inner join t_consultaion_apply b on a.apply_id=b.id inner join t_in_patient c on b.patient_id=c.id inner join t_section_area d on a.consul_record_section_id=d.sid  where  a.isrecieve='1'  and b.is_dalete='N' ";
            //病危人数
            string sql_Danger = "select distinct a1.id,a1.patient_name,a1.pid,a1.birthday,case when a1.gender_code=0 then '男' else '女' end sex,a1.in_time,a1.section_id,a1.section_name,a1.SICK_AREA_ID,a1.SICK_AREA_name from t_In_Patient a1 inner join t_inhospital_action b1 on a1.id=b1.patient_id where b1.next_id=0 and b1.ACTION_TYPE<>'出区' and b1.ACTION_STATE<>3 and Sick_Degree='1' ";
            //病重人数
            string sql_Bad = "select distinct a1.id,a1.patient_name,a1.pid,a1.birthday,case when a1.gender_code=0 then '男' else '女' end sex,a1.in_time,a1.section_id,a1.section_name,a1.SICK_AREA_ID,a1.SICK_AREA_name from t_In_Patient a1 inner join t_inhospital_action b1 on a1.id=b1.patient_id where b1.next_id=0 and b1.ACTION_TYPE<>'出区' and b1.ACTION_STATE<>3 and Sick_Degree='2' ";
            //治愈率
            string sql_zhiyulv = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '男' else '女' end sex,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name,a.in_time,a.die_time,a.sick_doctor_id,a.sick_doctor_name,'' as 入院诊断,'' as 出院诊断 from t_In_Patient a inner join t_inhospital_action b on (a.id=b.patient_id) inner join t_diagnose_item c on (a.id=c.patient_id) where b.action_type='出区' and c.turn_to='治愈' ";
            //病死率
            string sql_bingsilv = "select distinct a.id,a.section_name,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit),a.home_address,a.relation_name,a.in_time,'' as 入院诊断,'' as 死亡原因,'' as 死亡时间,sick_doctor_name,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where a.die_flag=1";
            //诊断正确率
            //string sql_zhenduan_right = "select d.id,d.patient_name,d.pid,d.birthday,case when d.gender_code=0 then '男' else '女' end sex,d.in_time,d.section_id,d.section_name,d.SICK_AREA_ID,d.SICK_AREA_name  from cover_diagnose a inner join cover_diagnose b on (a.inpatient_id=b.inpatient_id) inner join t_inhospital_action c on(a.inpatient_id=c.patient_id) inner join t_in_patient d on (a.inpatient_id=d.id) where a.id in (select id from cover_diagnose where type='I') and b.id in (select id from cover_diagnose where type='L' and code=1) and a.name=b.name ";
            //误诊率
            //string sql_zhenduan_wrong = "select in_time from cover_diagnose a inner join cover_diagnose b on (a.inpatient_id=b.inpatient_id) inner join t_in_patient on(a.inpatient_id=b.id) where a.icd10name<>b.icd10name and a.id in (select id from cover_diagnose where type='I') and b.id in (select id from cover_diagnose where type='L' and code=1)";
            //if (cboFrequencyUnit.SelectedValue.ToString() == "178") //全院
            //{
            //所有入院诊断
            string sql_allin_diag = "select patient_id,diagnose_name,create_time,diagnose_sort from t_diagnose_item where diagnose_type=408 ";
            //所有出院诊断
            string sql_allout_diag = "select patient_id,diagnose_name,create_time,diagnose_sort from t_diagnose_item where diagnose_type=406";
            //按周
            if (Convert.ToInt32(cboFrequency.SelectedValue.ToString()) == 197)
            {
                int weekNum = cboWeek.SelectedIndex + 1;
                sql_into_area += " and to_char(in_time,'ww')='" + weekNum + "'";
                sql_out_area += " and to_char(b.happen_time,'ww')='" + weekNum + "'";
                sql_turn_out += " and to_char(b.happen_time,'ww')='" + weekNum + "'";
                sql_turn_in += " and to_char(c.happen_time,'ww')='" + weekNum + "'";
                sql_operate += " and to_char(g.create_time,'ww')='" + weekNum + "')";
                sql_consultaion_applay += " and to_char(apply_time,'ww')='" + weekNum + "'";
                sql_consultaion_recive += " and to_char(consul_time,'ww')='" + weekNum + "'";

                sql_zhiyulv += " and to_char(b.happen_time,'ww')='" + weekNum + "'";
                sql_bingsilv += " and to_char(b.happen_time,'ww')='" + weekNum + "'";
                //sql_zhenduan_right += " and to_char(c.happen_time,'ww')='" + weekNum + "'";
                //string beginTime = "";
                //string endTime = "";
                //int y = dtpStartYear.Value.Year;
                //int m = dtpStartYear.Value.Month;
                //int d = dtpStartYear.Value.Day;
                //if (m == 1 || m == 2)
                //{
                //    m += 12;
                //    y--;         //把一月和二月看成是上一年的十三月和十四月，例：如果是2004-1-10则换算成：2003-13-10来代入公式计算。
                //}
                //int week = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;
                //string weekstr = "";
                //switch (week)
                //{
                //    case 0: weekstr = "星期一"; break;
                //    case 1: weekstr = "星期二"; break;
                //    case 2: weekstr = "星期三"; break;
                //    case 3: weekstr = "星期四"; break;
                //    case 4: weekstr = "星期五"; break;
                //    case 5: weekstr = "星期六"; break;
                //    case 6: weekstr = "星期日"; break;
                //}
            }
            //按月
            if (Convert.ToInt32(cboFrequency.SelectedValue.ToString()) == 198)
            {
                string year_month = dtpStartYear.Value.ToString("yyyy-MM");
                sql_into_area += " and to_char(in_time,'yyyy-MM')='" + year_month + "'";
                sql_out_area += " and to_char(b.happen_time,'yyyy-MM')='" + year_month + "'";
                sql_turn_out += " and to_char(b.happen_time,'yyyy-MM')='" + year_month + "'";
                sql_turn_in += " and to_char(c.happen_time,'yyyy-MM')='" + year_month + "'";
                sql_operate += " and to_char(g.create_time,'yyyy-MM')='" + year_month + "')";
                sql_consultaion_applay += " and to_char(apply_time,'yyyy-MM')='" + year_month + "'";
                sql_consultaion_recive += " and to_char(consul_time,'yyyy-MM')='" + year_month + "'";
                //sql_Danger += " and to_char(in_time,'yyyy-MM')='" + year_month + "'";
                //sql_Bad += " and to_char(in_time,'yyyy-MM')='" + year_month + "'";
                sql_zhiyulv += " and to_char(b.happen_time,'yyyy-MM')='" + year_month + "'";
                sql_bingsilv += " and to_char(b.happen_time,'yyyy-MM')='" + year_month + "'";
                //sql_zhenduan_right += " and to_char(c.happen_time,'yyyy-MM')='" + year_month + "'";
                //sql_zhenduan_wrong += " and to_char(in_time,'yyyy-MM')='" + year_month + "'";

            }
            //按季度
            if (Convert.ToInt32(cboFrequency.SelectedValue.ToString()) == 199)
            {
                string beginTime = ""; //开始时间
                string endTime = "";//结束时间

                string year = dtpStartYear.Value.ToString("yyyy");
                switch (cboStartMonth.SelectedIndex)
                {
                    case 0:
                        beginTime = year + "-01";
                        endTime = year + "-03";
                        break;
                    case 1:
                        beginTime = year + "-04";
                        endTime = year + "-06";
                        break;
                    case 2:
                        beginTime = year + "-07";
                        endTime = year + "-09";
                        break;
                    case 3:
                        beginTime = year + "-10";
                        endTime = year + "-12";
                        break;
                }

                sql_into_area += " and to_char(in_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                sql_out_area += " and to_char(b.happen_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                sql_turn_out += " and to_char(b.happen_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                sql_turn_in += " and to_char(c.happen_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                sql_operate += " and to_char(g.create_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "')";
                sql_consultaion_applay += " and to_char(apply_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                sql_consultaion_recive += " and to_char(consul_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                //sql_Danger += " and to_char(in_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                //sql_Bad += " and to_char(in_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                sql_zhiyulv += " and to_char(b.happen_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                sql_bingsilv += " and to_char(b.happen_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                //sql_zhenduan_right += " and to_char(c.happen_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
                //sql_zhenduan_wrong += " and to_char(in_time,'yyyy-MM') between '" + beginTime + "' and '" + endTime + "'";
            }
            //按年
            if (Convert.ToInt32(cboFrequency.SelectedValue.ToString()) == 200)
            {
                string year = dtpStartYear.Value.ToString("yyyy");
                sql_into_area += " and to_char(in_time,'yyyy')='" + year + "'";
                sql_out_area += " and to_char(b.happen_time,'yyyy')='" + year + "'";
                sql_turn_out += " and to_char(c.happen_time,'yyyy')='" + year + "'";
                sql_turn_in += " and to_char(b.happen_time,'yyyy')='" + year + "'";
                sql_operate += " and to_char(g.create_time,'yyyy')='" + year + "')";
                sql_consultaion_applay += " and to_char(apply_time,'yyyy')='" + year + "'";
                sql_consultaion_recive += " and to_char(consul_time,'yyyy')='" + year + "'";
                //sql_Danger += " and to_char(in_time,'yyyy')='" + year + "'";
                //sql_Bad += " and to_char(in_time,'yyyy')='" + year + "'";

                sql_zhiyulv += " and to_char(b.happen_time,'yyyy')='" + year + "'";
                sql_bingsilv += " and to_char(b.happen_time,'yyyy')='" + year + "'";
                //sql_zhenduan_right += " and to_char(c.happen_time,'yyyy')='" + year + "'";
                //sql_zhenduan_wrong += " and to_char(in_time,'yyyy')='" + year + "'";
            }

            tables[0] = new Class_Table();
            tables[0].Sql = sql_into_area;
            tables[0].Tablename = "into_area";

            tables[1] = new Class_Table();
            tables[1].Sql = sql_out_area;
            tables[1].Tablename = "out_area";

            tables[2] = new Class_Table();
            tables[2].Sql = sql_turn_out;
            tables[2].Tablename = "turn_out";

            tables[3] = new Class_Table();
            tables[3].Sql = sql_turn_in;
            tables[3].Tablename = "turn_in";

            tables[4] = new Class_Table();
            tables[4].Sql = sql_operate;
            tables[4].Tablename = "operate";

            tables[5] = new Class_Table();
            tables[5].Sql = sql_consultaion_applay;
            tables[5].Tablename = "consultaion_applay";

            tables[6] = new Class_Table();
            tables[6].Sql = sql_consultaion_recive;
            tables[6].Tablename = "consultaion_recive";

            tables[7] = new Class_Table();
            tables[7].Sql = sql_Danger;
            tables[7].Tablename = "danger";

            tables[8] = new Class_Table();
            tables[8].Sql = sql_Bad;
            tables[8].Tablename = "bad";

            tables[9] = new Class_Table();
            tables[9].Sql = sql_Section;
            tables[9].Tablename = "section";

            tables[10] = new Class_Table();
            tables[10].Sql = sql_Sickarea;
            tables[10].Tablename = "sickarea";

            tables[11] = new Class_Table();
            tables[11].Sql = sql_zhiyulv;
            tables[11].Tablename = "zhiyulv";

            tables[12] = new Class_Table();
            tables[12].Sql = sql_bingsilv;
            tables[12].Tablename = "bingsilv";

            //tables[13] = new Class_Table();
            //tables[13].Sql = sql_zhenduan_right;
            //tables[13].Tablename = "zhenduan_right";

            tables[13] = new Class_Table();
            tables[13].Sql = sql_allin_diag;
            tables[13].Tablename = "indiag";

            tables[14] = new Class_Table();
            tables[14].Sql = sql_allout_diag;
            tables[14].Tablename = "outdiag";

            //tables[14] = new Class_Table();
            //tables[14].Sql = sql_zhenduan_wrong;
            //tables[14].Tablename = "zhenduan_wrong";
            try
            {
                ds = App.GetDataSet(tables);
            }
            catch (Exception e)
            {
                return;
            }
        }

        /// <summary>
        /// 双击数字，显示相应的病人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgview_DoubleClick(object sender, EventArgs e)
        {

            if (flgview[flgview.RowSel, flgview.ColSel] != null && App.IsNumeric(flgview[flgview.RowSel, flgview.ColSel].ToString()))
            {
                //flgview[flgview.RowSel, "在院人数"];
                DataTable dt = new DataTable();
                //第一级列头
                //选中行行头
                string rowname = flgview[flgview.RowSel, 0].ToString();
                //第二级列头
                string colname = flgview[0, flgview.ColSel].ToString();
                if (colname.Contains("会诊") || colname.Contains("率"))
                {
                    App.Msg("会诊、概率统计没有病人详细信息");
                    return;
                }
                switch (colname)
                {
                    case "入院人数":
                        dt = ds.Tables["into_area"];
                        break;
                    case "出院人数":
                        dt = ds.Tables["out_area"];
                        break;
                    case "手术人数":
                        dt = ds.Tables["operate"];
                        break;
                    case "病危人数":
                        dt = ds.Tables["danger"];
                        break;
                    case "病重人数":
                        dt = ds.Tables["bad"];
                        break;
                    case "转出人次":
                        dt = ds.Tables["turn_out"];
                        break;
                    case "转入人次":
                        dt = ds.Tables["turn_in"];
                        break;
                }
                //入院诊断
                DataTable dt_inDiag = ds.Tables["indiag"];
                //出院诊断
                DataTable dt_outDiag = ds.Tables["outdiag"];
                if (rowname == "全院")
                {
                    if (colname == "手术人数")
                    {
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "入院人数" || colname == "出院人数")
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "转出人次" || colname == "转入人次")
                    {
                        frmTurnInOut_PatientInfo patientInfo = new frmTurnInOut_PatientInfo(dt);
                        patientInfo.ShowDialog();
                    }
                    else
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt);
                        patientInfo.ShowDialog();
                    }
                }
                else if (searchName == "按病区")//按病区
                {
                    DataTable dt_sick_area = new DataTable();
                    DataRow[] dr = dt.Select("sick_area_name='" + rowname + "'");
                    dt_sick_area = dt.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt_sick_area.Rows.Add(dr[i].ItemArray);
                    }
                    if (colname == "手术人数")
                    {
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt_sick_area);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "入院人数" || colname == "出院人数")
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_sick_area, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "转出人次" || colname == "转入人次")
                    {
                        frmTurnInOut_PatientInfo patientInfo = new frmTurnInOut_PatientInfo(dt_sick_area);
                        patientInfo.ShowDialog();
                    }
                    else
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_sick_area);
                        patientInfo.ShowDialog();
                    }
                }
                else if (searchName == "按科室")//按科室
                {
                    DataTable dt_section = new DataTable();

                    DataRow[] dr = dt.Select("section_name='" + rowname + "'");
                    dt_section = dt.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt_section.Rows.Add(dr[i].ItemArray);
                    }
                    if (colname == "手术人数")
                    {
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt_section);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "入院人数" || colname == "出院人数")
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_section, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "转出人次" || colname == "转入人次")
                    {
                        frmTurnInOut_PatientInfo patientInfo = new frmTurnInOut_PatientInfo(dt_section);
                        patientInfo.ShowDialog();
                    }
                    else
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_section);
                        patientInfo.ShowDialog();
                    }
                }
            }

        }

        /// <summary>
        /// 根据选择年限的不同重置周数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpStartYear_ValueChanged(object sender, EventArgs e)
        {
            int year = dtpStartYear.Value.Year;
            int weekCount = GetYearWeekCount(year);
            cboWeek.Items.Clear();
            for (int i = 0; i < weekCount; i++)
            {

                cboWeek.Items.Add("第" + (i + 1) + "周");
            }
            cboWeek.SelectedIndex = 0;
        }

    }

}
