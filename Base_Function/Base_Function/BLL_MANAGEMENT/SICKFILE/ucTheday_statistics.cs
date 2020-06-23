using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Hospital_Management.CommonClass;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class ucTheday_statistics : UserControl
    {



        /// <summary>
        /// 数据集
        /// </summary>
        DataSet ds = null;
        /// <summary>
        /// 年龄大于14岁
        /// </summary>
        DateTime CheckTime = DateTime.Now;
        /// <summary>
        /// 全局变量，记录查询范围，只有再次查询时，状态才改变
        /// </summary>
        string searchName = "";
        //列的集合
        ColumnInfo[] cols = new ColumnInfo[34];
        public ucTheday_statistics()
        {
            InitializeComponent();
            try
            {
            	App.UsControlStyle(this);
            }
            catch (System.Exception ex)
            {
            	
            }
        }

        private void ucTheday_statistics_Load(object sender, EventArgs e)
        {
            try
            {
                CheckTime = App.GetSystemTime();
                flgview.MouseHoverCell += new EventHandler(fg_MouseHover);
                flgview.AllowEditing = false;
                Statistics_Unit();
                setTableHeader();
                CellMerge();
            }
            catch
            { }

        }

        int oldRow = 0;
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
                        if (oldRow < flgview.Rows.Count && oldRow > 1)
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
                flgview.Cols.Count = 34;
                //flgview.Rows.Count = 2;
                flgview.Rows.Fixed = 2;
                //表头设置
                #region 总计
                cols[0].Name = "病区（科室）";
                cols[0].Field = "Sick_Section";
                cols[0].Index = 1;
                cols[0].visible = true;

                cols[1].Name = "入院人数";
                cols[1].Field = "Into";
                cols[1].Index = 2;
                cols[1].visible = true;

                cols[2].Name = "在院人数";
                cols[2].Field = "At";
                cols[2].Index = 3;
                cols[2].visible = true;

                cols[3].Name = "出院人数";
                cols[3].Field = "Out";
                cols[3].Index = 4;
                cols[3].visible = true;

                cols[4].Name = "转出人次";
                cols[4].Field = "Turn_Out";
                cols[4].Index = 5;
                cols[4].visible = true;

                cols[5].Name = "转入人次";
                cols[5].Field = "Turn_In";
                cols[5].Index = 6;
                cols[5].visible = true;

                cols[6].Name = "手术人数";
                cols[6].Field = "Operation";
                cols[6].Index = 7;
                cols[6].visible = true;

                cols[7].Name = "发会诊人次";
                cols[7].Field = "Consultation_Apply";
                cols[7].Index = 8;
                cols[7].visible = true;

                cols[8].Name = "接会诊人次";
                cols[8].Field = "Consultation_Accept";
                cols[8].Index = 9;
                cols[8].visible = true;

                cols[9].Name = "病危人数";
                cols[9].Field = "Danger";
                cols[9].Index = 10;
                cols[9].visible = true;

                cols[10].Name = "病重人数";
                cols[10].Field = "Bad";
                cols[10].Index = 11;
                cols[10].visible = true;

                cols[11].Name = "死亡人数";
                cols[11].Field = "death";
                cols[11].Index = 12;
                cols[11].visible = true;
                #endregion
                //
                #region 成年人Adult

                cols[12].Name = "入院人数";
                cols[12].Field = "Adult_Into";
                cols[12].Index = 13;
                cols[12].visible = true;

                cols[13].Name = "在院人数";
                cols[13].Field = "Adult_At";
                cols[13].Index = 14;
                cols[13].visible = true;

                cols[14].Name = "出院人数";
                cols[14].Field = "Adult_Out";
                cols[14].Index = 15;
                cols[14].visible = true;

                cols[15].Name = "转出人次";
                cols[15].Field = "Adult_Turn_Out";
                cols[15].Index = 16;
                cols[15].visible = true;

                cols[16].Name = "转入人次";
                cols[16].Field = "Adult_Turn_In";
                cols[16].Index = 17;
                cols[16].visible = true;

                cols[17].Name = "手术人数";
                cols[17].Field = "Adult_Operation";
                cols[17].Index = 18;
                cols[17].visible = true;

                cols[18].Name = "发会诊人次";
                cols[18].Field = "Adult_Consultation_Apply";
                cols[18].Index = 19;
                cols[18].visible = true;

                cols[19].Name = "接会诊人次";
                cols[19].Field = "Adult_Consultation_Accept";
                cols[19].Index = 20;
                cols[19].visible = true;

                cols[20].Name = "病危人数";
                cols[20].Field = "Adult_Danger";
                cols[20].Index = 21;
                cols[20].visible = true;

                cols[21].Name = "病重人数";
                cols[21].Field = "Adult_Bad";
                cols[21].Index = 22;
                cols[21].visible = true;

                cols[22].Name = "死亡人数";
                cols[22].Field = "Adult_death";
                cols[22].Index = 23;
                cols[22].visible = true;
                #endregion
                #region 儿童Child

                cols[23].Name = "入院人数";
                cols[23].Field = "Child_Into";
                cols[23].Index = 24;
                cols[23].visible = true;

                cols[24].Name = "在院人数";
                cols[24].Field = "Child_At";
                cols[24].Index = 25;
                cols[24].visible = true;

                cols[25].Name = "出院人数";
                cols[25].Field = "Child_Out";
                cols[25].Index = 26;
                cols[25].visible = true;

                cols[26].Name = "转出人次";
                cols[26].Field = "Child_Turn_Out";
                cols[26].Index = 27;
                cols[26].visible = true;

                cols[27].Name = "转入人次";
                cols[27].Field = "Child_Turn_In";
                cols[27].Index = 28;
                cols[27].visible = true;

                cols[28].Name = "手术人数";
                cols[28].Field = "Child_Operation";
                cols[28].Index = 29;
                cols[28].visible = true;

                cols[29].Name = "发会诊人次";
                cols[29].Field = "Child_Consultation_Apply";
                cols[29].Index = 30;
                cols[29].visible = true;

                cols[30].Name = "接会诊人次";
                cols[30].Field = "Child_Consultation_Accept";
                cols[30].Index = 31;
                cols[30].visible = true;

                cols[31].Name = "病危人数";
                cols[31].Field = "Child_Danger";
                cols[31].Index = 32;
                cols[31].visible = true;

                cols[32].Name = "病重人数";
                cols[32].Field = "Child_Bad";
                cols[32].Index = 33;
                cols[32].visible = true;

                cols[33].Name = "死亡人数";
                cols[33].Field = "Child_death";
                cols[33].Index = 34;
                cols[33].visible = true;
                #endregion
                flgview.Cols[0].Width = 70;
                flgview.Cols[1].Width = 50;
                flgview.Cols[2].Width = 50;
                flgview.Cols[3].Width = 50;
                flgview.Cols[4].Width = 50;
                flgview.Cols[5].Width = 50;
                flgview.Cols[6].Width = 50;
                flgview.Cols[7].Width = 50;
                flgview.Cols[8].Width = 50;
                flgview.Cols[9].Width = 50;
                flgview.Cols[10].Width = 50;
                flgview.Cols[11].Width = 50;
                flgview.Cols[12].Width = 50;
                flgview.Cols[13].Width = 50;
                flgview.Cols[14].Width = 50;
                flgview.Cols[15].Width = 50;
                flgview.Cols[16].Width = 50;
                flgview.Cols[17].Width = 50;
                flgview.Cols[18].Width = 50;
                flgview.Cols[19].Width = 50;
                flgview.Cols[20].Width = 50;
                flgview.Cols[21].Width = 50;
                flgview.Cols[22].Width = 50;
                flgview.Cols[23].Width = 50;
                flgview.Cols[24].Width = 50;
                flgview.Cols[25].Width = 50;
                flgview.Cols[26].Width = 50;
                flgview.Cols[27].Width = 50;
                flgview.Cols[28].Width = 50;
                flgview.Cols[29].Width = 50;
                flgview.Cols[30].Width = 50;
                flgview.Cols[31].Width = 50;
                flgview.Cols[32].Width = 50;
                flgview.Cols[33].Width = 50;

                for (int i = 0; i < flgview.Cols.Count; i++)
                {
                    flgview.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 单元格合并
        /// </summary>
        public void CellMerge()
        {
            //单元格合并和设置           
            flgview[1, 0] = "病区（科室）";
            flgview[1, 1] = "入院人数";
            flgview[1, 2] = "在院人数";
            flgview[1, 3] = "出院人数";
            flgview[1, 4] = "转出人次";
            flgview[1, 5] = "转入人次";
            flgview[1, 6] = "手术人数";
            flgview[1, 7] = "发会诊人次";
            flgview[1, 8] = "接会诊人次";
            flgview[1, 9] = "病危人数";
            flgview[1, 10] = "病重人数";
            flgview[1, 11] = "死亡人数";
            //成人
            flgview[1, 12] = "入院人数";
            flgview[1, 13] = "在院人数";
            flgview[1, 14] = "出院人数";
            flgview[1, 15] = "转出人次";
            flgview[1, 16] = "转入人次";
            flgview[1, 17] = "手术人数";
            flgview[1, 18] = "发会诊人次";
            flgview[1, 19] = "接会诊人次";
            flgview[1, 20] = "病危人数";
            flgview[1, 21] = "病重人数";
            flgview[1, 22] = "死亡人数";
            //儿童
            flgview[1, 23] = "入院人数";
            flgview[1, 24] = "在院人数";
            flgview[1, 25] = "出院人数";
            flgview[1, 26] = "转出人次";
            flgview[1, 27] = "转入人次";
            flgview[1, 28] = "手术人数";
            flgview[1, 29] = "发会诊人次";
            flgview[1, 30] = "接会诊人次";
            flgview[1, 31] = "病危人数";
            flgview[1, 32] = "病重人数";
            flgview[1, 33] = "死亡人数";
            flgview.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgview.Cols.Fixed = 0;


            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgview.GetCellRange(0, 0, 1, 0);
            cr.Data = "病区（科室）";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgview.MergedRanges.Add(cr);

            cr = flgview.GetCellRange(0, 1, 0, 11);
            cr.Data = "总计";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgview.MergedRanges.Add(cr);

            cr = flgview.GetCellRange(0, 12, 0, 22);
            cr.Data = "成人";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgview.MergedRanges.Add(cr);

            cr = flgview.GetCellRange(0, 23, 0, 33);
            cr.Data = "儿童";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgview.MergedRanges.Add(cr);

        }
        ////绑定统计项目
        //private void Statistics_Item()
        //{
        //    DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='38'");
        //    cboStatistics_Item.DataSource = ds.Tables[0].DefaultView;
        //    cboStatistics_Item.ValueMember = "ID";
        //    cboStatistics_Item.DisplayMember = "NAME";
        //}

        /// <summary>
        /// 验证数据如果是0的就显示为空
        /// </summary>
        /// <param Name="str">数据</param>
        /// <returns></returns>
        public string isExNot(string str)
        {
            if (str == "0")
            {
                str = "";
            }
            return str;
        }
        /// <summary>
        /// 统计
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                searchName = cboStatistics_Unit.Text;
                CheckTime = App.GetSystemTime().AddYears(-14);
                Get_Search_Data();
                flgview.Rows.Count = 2;
                if (cboStatistics_Unit.SelectedValue.ToString() == "178")
                {
                    //全院
                    Check_All_Hospital();
                }
                else if (cboStatistics_Unit.SelectedValue.ToString() == "179")
                {
                    //病区
                    Check_By_SickArea();
                }
                else if (cboStatistics_Unit.SelectedValue.ToString() == "180")
                {
                    //科室
                    Check_By_Section();
                }
            }
            catch (Exception ee)
            {
            }

        }
        /// <summary>
        /// 全院查询
        /// </summary>
        private void Check_All_Hospital()
        {
            try
            {
                if (Convert.ToInt32(cboStatistics_Unit.SelectedValue.ToString()) == 178)
                {

                    flgview.Rows.Add();
                    flgview[2, 0] = "全院";
                    #region 总计
                    int val = 0;

                    val = ds.Tables["into_area"].Rows.Count;
                    flgview[2, 1] = val;

                    val = ds.Tables["in_area"].Rows.Count;
                    flgview[2, 2] = val;

                    val = ds.Tables["out_area"].Rows.Count;
                    flgview[2, 3] = val;

                    val = ds.Tables["turn_out"].Rows.Count;
                    flgview[2, 4] = val;

                    val = ds.Tables["turn_in"].Rows.Count;
                    flgview[2, 5] = val;

                    val = ds.Tables["operate"].Rows.Count;
                    flgview[2, 6] = val;

                    val = ds.Tables["consultaion_applay"].Rows.Count;
                    flgview[2, 7] = val;

                    val = ds.Tables["consultaion_accept"].Rows.Count;
                    flgview[2, 8] = val;

                    val = ds.Tables["danger"].Rows.Count;
                    flgview[2, 9] = val;

                    val = ds.Tables["bad"].Rows.Count;
                    flgview[2, 10] = val;

                    val = ds.Tables["death"].Rows.Count;
                    flgview[2, 11] = val;
                    #endregion

                    #region 成人
                    val = ds.Tables["into_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 12] = val;

                    val = ds.Tables["in_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 13] = val;

                    val = ds.Tables["out_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 14] = val;

                    val = ds.Tables["turn_in"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 15] = val;

                    val = ds.Tables["turn_out"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 16] = val;

                    val = ds.Tables["operate"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 17] = val;

                    val = ds.Tables["consultaion_applay"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 18] = val;

                    val = ds.Tables["consultaion_accept"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 19] = val;

                    val = ds.Tables["danger"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 20] = val;

                    val = ds.Tables["bad"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 21] = val;

                    val = ds.Tables["death"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 22] = val;
                    #endregion

                    #region 儿童
                    val = ds.Tables["into_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 23] = val;

                    val = ds.Tables["in_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 24] = val;

                    val = ds.Tables["out_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 25] = val;

                    val = ds.Tables["turn_out"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 26] = val;

                    val = ds.Tables["turn_in"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 27] = val;

                    val = ds.Tables["operate"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 28] = val;

                    val = ds.Tables["consultaion_applay"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 29] = val;

                    val = ds.Tables["consultaion_accept"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 30] = val;

                    val = ds.Tables["danger"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 31] = val;

                    val = ds.Tables["bad"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 32] = val;

                    val = ds.Tables["death"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "'").Length;
                    flgview[2, 33] = val;
                    #endregion
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 科室查询
        /// </summary>
        private void Check_By_Section()
        {

            if (cbxSection.Text != "")
            {
                flgview.Rows.Add();
                flgview[2, 0] = cbxSection.Text;
                #region 总计
                int val = 0;

                val = ds.Tables["into_area"].Select("section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 1] = val;

                val = ds.Tables["in_area"].Select("section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 2] = val;

                val = ds.Tables["out_area"].Select("section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 3] = val;

                val = ds.Tables["turn_out"].Select("tsid='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 4] = val;

                val = ds.Tables["turn_in"].Select("sid='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 5] = val;

                val = ds.Tables["operate"].Select("section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 6] = val;

                val = ds.Tables["consultaion_applay"].Select("apply_sectionid='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 7] = val;

                val = ds.Tables["consultaion_accept"].Select("consul_record_section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 8] = val;

                val = ds.Tables["danger"].Select("section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 9] = val;

                val = ds.Tables["bad"].Select("section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 10] = val;

                val = ds.Tables["death"].Select("section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 11] = val;
                #endregion

                #region 成人
                val = ds.Tables["into_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 12] = val;

                val = ds.Tables["in_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 13] = val;

                val = ds.Tables["out_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 14] = val;

                val = ds.Tables["turn_out"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and sid='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 15] = val;

                val = ds.Tables["turn_in"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and sid='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 16] = val;

                val = ds.Tables["operate"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 17] = val;

                val = ds.Tables["consultaion_applay"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and apply_sectionid='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 18] = val;

                val = ds.Tables["consultaion_accept"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and consul_record_section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 19] = val;

                val = ds.Tables["danger"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 20] = val;

                val = ds.Tables["bad"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 21] = val;

                val = ds.Tables["death"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 22] = val;
                #endregion

                #region 儿童
                val = ds.Tables["into_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 23] = val;

                val = ds.Tables["in_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 24] = val;

                val = ds.Tables["out_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 25] = val;

                val = ds.Tables["turn_out"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and sid='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 26] = val;

                val = ds.Tables["turn_in"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and sid='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 27] = val;

                val = ds.Tables["operate"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 28] = val;

                val = ds.Tables["consultaion_applay"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and apply_sectionid='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 29] = val;

                val = ds.Tables["consultaion_accept"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and consul_record_section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 30] = val;

                val = ds.Tables["danger"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 31] = val;

                val = ds.Tables["bad"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 32] = val;

                val = ds.Tables["death"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 33] = val;
                #endregion
            }
            else
            {
                for (int i = 0; i < cbxSection.Items.Count - 1; i++)
                {
                    flgview.Rows.Add();
                    DataRowView drv = cbxSection.Items[i + 1] as DataRowView;
                    string sectionId = drv["sid"].ToString();
                    string sectionName = drv["section_name"].ToString();
                    flgview[i + 2, 0] = sectionName;

                    #region 总计
                    int val = 0;

                    val = ds.Tables["into_area"].Select("section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 1] = val;

                    val = ds.Tables["in_area"].Select("section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 2] = val;

                    val = ds.Tables["out_area"].Select("section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 3] = val;

                    val = ds.Tables["turn_out"].Select("sid='" + sectionId + "'").Length;
                    flgview[i + 2, 4] = val;

                    val = ds.Tables["turn_in"].Select("sid='" + sectionId + "'").Length;
                    flgview[i + 2, 5] = val;

                    val = ds.Tables["operate"].Select("section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 6] = val;

                    val = ds.Tables["consultaion_applay"].Select("apply_sectionid='" + sectionId + "'").Length;
                    flgview[i + 2, 7] = val;

                    val = ds.Tables["consultaion_accept"].Select("consul_record_section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 8] = val;

                    val = ds.Tables["danger"].Select("section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 9] = val;

                    val = ds.Tables["bad"].Select("section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 10] = val;

                    val = ds.Tables["death"].Select("section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 11] = val;
                    #endregion

                    #region 成人
                    val = ds.Tables["into_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 12] = val;

                    val = ds.Tables["in_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 13] = val;

                    val = ds.Tables["out_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 14] = val;

                    val = ds.Tables["turn_out"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and sid='" + sectionId + "'").Length;
                    flgview[i + 2, 15] = val;

                    val = ds.Tables["turn_in"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and sid='" + sectionId + "'").Length;
                    flgview[i + 2, 16] = val;

                    val = ds.Tables["operate"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 17] = val;

                    val = ds.Tables["consultaion_applay"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and apply_sectionid='" + sectionId + "'").Length;
                    flgview[i + 2, 18] = val;

                    val = ds.Tables["consultaion_accept"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and consul_record_section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 19] = val;

                    val = ds.Tables["danger"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 20] = val;

                    val = ds.Tables["bad"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 21] = val;

                    val = ds.Tables["death"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 22] = val;
                    #endregion

                    #region 儿童
                    val = ds.Tables["into_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 23] = val;

                    val = ds.Tables["in_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 24] = val;

                    val = ds.Tables["out_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 25] = val;

                    val = ds.Tables["turn_out"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and sid='" + sectionId + "'").Length;
                    flgview[i + 2, 26] = val;

                    val = ds.Tables["turn_in"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and sid='" + sectionId + "'").Length;
                    flgview[i + 2, 27] = val;

                    val = ds.Tables["operate"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 28] = val;

                    val = ds.Tables["consultaion_applay"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and apply_sectionid='" + sectionId + "'").Length;
                    flgview[i + 2, 29] = val;

                    val = ds.Tables["consultaion_accept"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and consul_record_section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 30] = val;

                    val = ds.Tables["danger"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 31] = val;

                    val = ds.Tables["bad"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 32] = val;

                    val = ds.Tables["death"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and section_id='" + sectionId + "'").Length;
                    flgview[i + 2, 33] = val;
                    #endregion
                }
            }
        }
        /// <summary>
        /// 病区查询
        /// </summary>
        private void Check_By_SickArea()
        {

            if (cbxSection.Text != "")
            {
                flgview.Rows.Add();
                flgview[2, 0] = cbxSection.Text;
                int val = 0;
                #region 总计
                val = ds.Tables["into_area"].Select("SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 1] = val;

                val = ds.Tables["in_area"].Select("SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 2] = val;

                val = ds.Tables["out_area"].Select("SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 3] = val;

                val = ds.Tables["turn_out"].Select("said='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 4] = val;

                val = ds.Tables["turn_in"].Select("said='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 5] = val;

                val = ds.Tables["operate"].Select("SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 6] = val;

                val = ds.Tables["consultaion_applay"].Select("SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 7] = val;

                val = ds.Tables["consultaion_accept"].Select("said='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 8] = val;

                val = ds.Tables["danger"].Select("SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 9] = val;

                val = ds.Tables["bad"].Select("SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 10] = val;

                val = ds.Tables["death"].Select("SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 11] = val;
                #endregion

                #region 成人
                val = ds.Tables["into_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 12] = val;

                val = ds.Tables["in_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 13] = val;

                val = ds.Tables["out_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 14] = val;

                val = ds.Tables["turn_out"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 15] = val;

                val = ds.Tables["turn_in"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 16] = val;

                val = ds.Tables["operate"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 17] = val;

                val = ds.Tables["consultaion_applay"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 18] = val;

                val = ds.Tables["consultaion_accept"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 19] = val;

                val = ds.Tables["danger"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 20] = val;

                val = ds.Tables["bad"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 21] = val;

                val = ds.Tables["death"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 22] = val;
                #endregion

                #region 儿童
                val = ds.Tables["into_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 23] = val;

                val = ds.Tables["in_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 24] = val;

                val = ds.Tables["out_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 25] = val;

                val = ds.Tables["turn_out"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 26] = val;

                val = ds.Tables["turn_in"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 27] = val;

                val = ds.Tables["operate"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 28] = val;

                val = ds.Tables["consultaion_applay"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 29] = val;

                val = ds.Tables["consultaion_accept"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 30] = val;

                val = ds.Tables["danger"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 31] = val;

                val = ds.Tables["bad"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 32] = val;

                val = ds.Tables["death"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + cbxSection.SelectedValue.ToString() + "'").Length;
                flgview[2, 33] = val;
                #endregion
            }
            else
            {
                for (int i = 0; i < cbxSection.Items.Count - 1; i++)
                {
                    flgview.Rows.Add();
                    DataRowView drv = cbxSection.Items[i + 1] as DataRowView;
                    string sickId = drv["said"].ToString();
                    string sickName = drv["sick_area_name"].ToString();
                    flgview[i + 2, 0] = sickName;
                    int val = 0;
                    #region 总计

                    val = ds.Tables["into_area"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 1] = val;

                    val = ds.Tables["in_area"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 2] = val;

                    val = ds.Tables["out_area"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 3] = val;

                    val = ds.Tables["turn_out"].Select("said='" + sickId + "'").Length;
                    flgview[i + 2, 4] = val;

                    val = ds.Tables["turn_in"].Select("said='" + sickId + "'").Length;
                    flgview[i + 2, 5] = val;

                    val = ds.Tables["operate"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 6] = val;

                    val = ds.Tables["consultaion_applay"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 7] = val;

                    val = ds.Tables["consultaion_accept"].Select("said='" + sickId + "'").Length;
                    flgview[i + 2, 8] = val;

                    val = ds.Tables["danger"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 9] = val;

                    val = ds.Tables["bad"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 10] = val;

                    val = ds.Tables["death"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 11] = val;
                    #endregion

                    #region 成人
                    val = ds.Tables["into_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 12] = val;

                    val = ds.Tables["in_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 13] = val;

                    val = ds.Tables["out_area"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 14] = val;

                    val = ds.Tables["turn_out"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + sickId + "'").Length;
                    flgview[i + 2, 15] = val;

                    val = ds.Tables["turn_in"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + sickId + "'").Length;
                    flgview[i + 2, 16] = val;

                    val = ds.Tables["operate"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 17] = val;

                    val = ds.Tables["consultaion_applay"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 18] = val;

                    val = ds.Tables["consultaion_accept"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + sickId + "'").Length;
                    flgview[i + 2, 19] = val;

                    val = ds.Tables["danger"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 20] = val;

                    val = ds.Tables["bad"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 21] = val;

                    val = ds.Tables["death"].Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 22] = val;
                    #endregion

                    #region 儿童
                    val = ds.Tables["into_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 23] = val;

                    val = ds.Tables["in_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 24] = val;

                    val = ds.Tables["out_area"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 25] = val;

                    val = ds.Tables["turn_out"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + sickId + "'").Length;
                    flgview[i + 2, 26] = val;

                    val = ds.Tables["turn_in"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + sickId + "'").Length;
                    flgview[i + 2, 27] = val;

                    val = ds.Tables["operate"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 28] = val;

                    val = ds.Tables["consultaion_applay"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 29] = val;

                    val = ds.Tables["consultaion_accept"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and said='" + sickId + "'").Length;
                    flgview[i + 2, 30] = val;

                    val = ds.Tables["danger"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 31] = val;

                    val = ds.Tables["bad"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 32] = val;

                    val = ds.Tables["death"].Select("birthday>='" + CheckTime.ToString("yyyy-MM-dd") + "' and SICK_AREA_ID='" + sickId + "'").Length;
                    flgview[i + 2, 33] = val;
                    #endregion

                }

            }
        }


        /// <summary>
        /// 获取查询的数据结果
        /// </summary>
        /// <returns></returns>
        private void Get_Search_Data()
        {
            try
            {
                Bifrost.WebReference.Class_Table[] temtables = new Bifrost.WebReference.Class_Table[13];

                //入院人数
                string sql_into_area = "select a.id,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,a.in_time,a.die_time,'' as 入院诊断,'' as 出院诊断,a.insection_name ,a.section_name ,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a where (select count(id) from t_inhospital_action b where b.patient_id=a.id)>0 and to_char(a.in_time,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "'";

                //在院人数
                string sql_in_area = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '男' else '女' end sex,a.in_time,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where b.ACTION_TYPE<>'出区' and b.Next_id=0 and b.ACTION_STATE<>3 ";

                //出院人数
                string sql_out_area = "select distinct a.id,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,a.in_time,a.die_time,'' as 入院诊断,'' as 出院诊断,a.insection_name ,a.section_name ,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where b.next_id=0 and b.ACTION_TYPE='出区' and b.ACTION_STATE=3 and a.die_flag<>1 and to_char(b.happen_time,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "'";

                //转出人次
                string sql_turn_out = "select distinct a.id, a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,d.section_name ,e.section_name 转入科室,b.happen_time,a.section_name ,b.sid,b.said,f.sick_area_name,a.birthday from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id inner join t_inhospital_action c on a.id=c.patient_id  inner join t_sectioninfo d on b.sid=d.sid inner join t_sectioninfo e on b.target_sid=e.sid inner join t_sickareainfo f on b.said=f.said where b.action_type='转出' and c.action_type='转入' and b.next_id=c.id and to_char(b.happen_time,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "'";

                //转入人次
                string sql_turn_in = "select distinct a.id, a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,d.section_name 转出科室,e.section_name,c.happen_time,a.section_name ,c.sid,c.said,f.sick_area_name,a.birthday from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id inner join t_inhospital_action c on a.id=c.patient_id  inner join t_sectioninfo d on b.sid=d.sid inner join t_sectioninfo e on b.target_sid=e.sid inner join t_sickareainfo f on c.said=f.said where b.action_type='转出' and c.action_type='转入' and b.next_id=c.id  and to_char(c.happen_time,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "'";

                //当日手术
                string sql_operate = "select distinct a.id,a.section_name,e.operator,e.oper_assist1,e.oper_assist2,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit),c.diagnose_name,e.oper_date,e.oper_name,'' as 手术分类,a.birthday,a.section_id,a.in_time,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id left join t_diagnose_item c on a.id=c.patient_id and c.diagnose_type=401 left join COVER_OPERATION e on a.id=e.inpatient_id  where a.id in(select patient_id from t_quality_text g  where g.texttkind_id=151 and to_char(g.create_time,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "')";

                //发会诊人次
                string sql_consultaion_applay = "select a.*,b.sick_area_id,b.birthday from t_consultaion_apply a inner join t_in_patient b on a.patient_id=b.id inner join t_consultaion_record c on a.id=c.apply_id  where submited='Y' and to_char(a.apply_time,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "'";

                //接会诊人次
                string sql_consultaion_recive = "select a.consul_record_section_id,d.said,c.birthday from t_consultaion_record a inner join t_consultaion_apply b on a.apply_id=b.id inner join t_in_patient c on b.patient_id=c.id  inner join t_section_area d on a.consul_record_section_id=d.sid where  a.isrecieve='1'  and b.is_dalete='N' and to_char(consul_time,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "'";

                //病危人数
                string sql_danger = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '男' else '女' end sex,a.in_time,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where b.next_id=0 and b.ACTION_TYPE<>'出区' and b.ACTION_STATE<>3 and Sick_Degree='1' ";

                //病重人数
                string sql_bad = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '男' else '女' end sex,a.in_time,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where b.next_id=0 and b.ACTION_TYPE<>'出区' and b.ACTION_STATE<>3 and Sick_Degree='2' ";

                //死亡人数 
                string sql_death = "select distinct a.id,a.section_name,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit),a.home_address,a.relation_name,a.in_time,'' as 入院诊断,'' as 死亡原因,'' as 死亡时间,sick_doctor_name,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where a.die_flag=1 and to_char(b.happen_time ,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "'";

                //所有入院诊断
                string sql_allin_diag = "select patient_id,diagnose_name,create_time,diagnose_sort from t_diagnose_item where diagnose_type=408 ";
                //所有出院诊断
                string sql_allout_diag = "select patient_id,diagnose_name,create_time,diagnose_sort from t_diagnose_item where diagnose_type=406";
                temtables[0] = new Bifrost.WebReference.Class_Table();
                temtables[0].Sql = sql_into_area;
                temtables[0].Tablename = "into_area";

                temtables[1] = new Bifrost.WebReference.Class_Table();
                temtables[1].Sql = sql_in_area;
                temtables[1].Tablename = "in_area";

                temtables[2] = new Bifrost.WebReference.Class_Table();
                temtables[2].Sql = sql_out_area;
                temtables[2].Tablename = "out_area";

                temtables[3] = new Bifrost.WebReference.Class_Table();
                temtables[3].Sql = sql_turn_out;
                temtables[3].Tablename = "turn_out";

                temtables[4] = new Bifrost.WebReference.Class_Table();
                temtables[4].Sql = sql_turn_in;
                temtables[4].Tablename = "turn_in";

                temtables[5] = new Bifrost.WebReference.Class_Table();
                temtables[5].Sql = sql_operate;
                temtables[5].Tablename = "operate";

                temtables[6] = new Bifrost.WebReference.Class_Table();
                temtables[6].Sql = sql_consultaion_applay;
                temtables[6].Tablename = "consultaion_applay";

                temtables[7] = new Bifrost.WebReference.Class_Table();
                temtables[7].Sql = sql_consultaion_recive;
                temtables[7].Tablename = "consultaion_accept";

                temtables[8] = new Bifrost.WebReference.Class_Table();
                temtables[8].Sql = sql_danger;
                temtables[8].Tablename = "danger";

                temtables[9] = new Bifrost.WebReference.Class_Table();
                temtables[9].Sql = sql_bad;
                temtables[9].Tablename = "bad";

                temtables[10] = new Bifrost.WebReference.Class_Table();
                temtables[10].Sql = sql_death;
                temtables[10].Tablename = "death";

                temtables[11] = new Bifrost.WebReference.Class_Table();
                temtables[11].Sql = sql_allin_diag;
                temtables[11].Tablename = "allindiag";

                temtables[12] = new Bifrost.WebReference.Class_Table();
                temtables[12].Sql = sql_allout_diag;
                temtables[12].Tablename = "alloutdiag";

                ds = App.GetDataSet(temtables);

            }
            catch (Exception ex)
            {
                ds = null;
            }
        }

        //绑定统计单位
        private void Statistics_Unit()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='39'");
            cboStatistics_Unit.DataSource = ds.Tables[0].DefaultView;
            cboStatistics_Unit.ValueMember = "ID";
            cboStatistics_Unit.DisplayMember = "NAME";
        }

        private void cboStatistics_Unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatistics_Unit.SelectedValue.ToString() == "180")//显示科室列表
            {
                cbxSection.DataSource = null;
                cbxSection.Enabled = true;
                string sql_Section = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
                DataSet ds = App.GetDataSet(sql_Section);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    DataRow allselect = dt.NewRow();
                    dt.Rows.InsertAt(allselect, 0);
                    cbxSection.DataSource = dt;
                    cbxSection.DisplayMember = "section_name";
                    cbxSection.ValueMember = "sid";

                }
            }
            else if (cboStatistics_Unit.SelectedValue.ToString() == "179")//显示病区列表
            {
                cbxSection.DataSource = null;
                cbxSection.Enabled = true;
                string sql_Section = "select said,sick_area_name from t_sickareainfo";
                DataSet ds = App.GetDataSet(sql_Section);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    DataRow allselect = dt.NewRow();
                    dt.Rows.InsertAt(allselect, 0);
                    cbxSection.DataSource = dt;
                    cbxSection.DisplayMember = "sick_area_name";
                    cbxSection.ValueMember = "said";

                }
            }
            else
            {
                cbxSection.Enabled = false;
                cbxSection.Text = "";
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
                string colHade = flgview[0, flgview.ColSel].ToString();
                //选中行行头
                string rowname = flgview[flgview.RowSel, 0].ToString();
                //第二级列头
                string colname = flgview[1, flgview.ColSel].ToString();
                if (colname.Contains("会诊"))
                {
                    App.Msg("会诊统计没有病人详细信息");
                    return;
                }
                switch (colname)
                {
                    case "入院人数":
                        dt = ds.Tables["into_area"];
                        break;
                    case "在院人数":
                        dt = ds.Tables["in_area"];
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
                    case "死亡人数":
                        dt = ds.Tables["death"];
                        break;
                    case "转出人次":
                        dt = ds.Tables["turn_out"];
                        break;
                    case "转入人次":
                        dt = ds.Tables["turn_in"];
                        break;
                }
                //入院诊断
                DataTable dt_inDiag = ds.Tables["allindiag"];
                //出院诊断
                DataTable dt_outDiag = ds.Tables["alloutdiag"];
                if (rowname == "全院")
                {
                    DataTable dt_all = new DataTable();
                    if (colHade == "总计")
                    {
                        dt_all = dt;
                    }
                    else if (colHade == "成人")
                    {
                        DataRow[] dr = dt.Select("birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'");
                        dt_all = dt.Clone();
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dt_all.Rows.Add(dr[i].ItemArray);
                        }
                    }
                    else if (colHade == "儿童")
                    {
                        DataRow[] dr = dt.Select("birthday>'" + CheckTime.ToString("yyyy-MM-dd") + "'");
                        dt_all = dt.Clone();
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dt_all.Rows.Add(dr[i].ItemArray);
                        }
                    }
                    if (colname == "手术人数")
                    {
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt_all);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "死亡人数")
                    {
                        frmTurnToDie_PatientInfo frmDie = new frmTurnToDie_PatientInfo(dt_all, dt_inDiag);
                        frmDie.ShowDialog();
                    }
                    else if (colname == "入院人数" || colname == "出院人数")
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_all, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "转出人次" || colname == "转入人次")
                    {
                        frmTurnInOut_PatientInfo patientInfo = new frmTurnInOut_PatientInfo(dt);
                        patientInfo.ShowDialog();
                    }
                    else
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_all);
                        patientInfo.ShowDialog();
                    }
                }
                if (searchName == "按病区")//按病区
                {
                    DataTable dt_sick_area = new DataTable();
                    if (colHade == "总计")
                    {
                        DataRow[] dr = dt.Select("sick_area_name='" + rowname + "'");
                        dt_sick_area = dt.Clone();
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dt_sick_area.Rows.Add(dr[i].ItemArray);
                        }
                    }
                    else if (colHade == "成人")
                    {
                        DataRow[] dr = dt.Select("sick_area_name='" + rowname + "' and birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'");
                        dt_sick_area = dt.Clone();
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dt_sick_area.Rows.Add(dr[i].ItemArray);
                        }
                    }
                    else if (colHade == "儿童")
                    {
                        DataRow[] dr = dt.Select("sick_area_name='" + rowname + "' and birthday>'" + CheckTime.ToString("yyyy-MM-dd") + "'");
                        dt_sick_area = dt.Clone();
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dt_sick_area.Rows.Add(dr[i].ItemArray);
                        }
                    }

                    if (colname == "手术人数")
                    {
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt_sick_area);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "死亡人数")
                    {
                        frmTurnToDie_PatientInfo frmDie = new frmTurnToDie_PatientInfo(dt_sick_area, dt_inDiag);
                        frmDie.ShowDialog();
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

                if (searchName == "按科室")//按科室
                {
                    DataTable dt_section = new DataTable();
                    if (colHade == "总计")
                    {
                        DataRow[] dr = dt.Select("section_name='" + rowname + "'");
                        dt_section = dt.Clone();
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dt_section.Rows.Add(dr[i].ItemArray);
                        }
                    }
                    else if (colHade == "成人")
                    {
                        DataRow[] dr = dt.Select("section_name='" + rowname + "' and birthday<'" + CheckTime.ToString("yyyy-MM-dd") + "'");
                        dt_section = dt.Clone();
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dt_section.Rows.Add(dr[i].ItemArray);
                        }

                    }
                    else if (colHade == "儿童")
                    {
                        DataRow[] dr = dt.Select("section_name='" + rowname + "' and birthday>'" + CheckTime.ToString("yyyy-MM-dd") + "'");
                        dt_section = dt.Clone();
                        for (int i = 0; i < dr.Length; i++)
                        {
                            dt_section.Rows.Add(dr[i].ItemArray);
                        }
                    }
                    if (colname == "手术人数")
                    {
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt_section);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "死亡人数")
                    {
                        frmTurnToDie_PatientInfo frmDie = new frmTurnToDie_PatientInfo(dt_section, dt_inDiag);
                        frmDie.ShowDialog();
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

    }
}
