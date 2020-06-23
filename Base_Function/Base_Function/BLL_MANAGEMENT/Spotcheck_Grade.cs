using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
using Base_Function.MODEL;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class Spotcheck_Grade : UserControl
    {
        private string His_sql = "";
        private string pid = "";//当前pid
        private string Spock_sql = "";
        private string Grad_sql = "";
        private string Nurse_sql = "";
        private string Time_sql = ""; 
        private string Grade_times;//当前时间
        private string see_particulars = null;// 记录评分的体温单名称
        private string see_particulars_nurse = null;// 记录评分的危重护理记录单名称
        ArrayList TGrade = new ArrayList();
        

        ColumnInfo[] cols = new ColumnInfo[14];
        public Spotcheck_Grade()
        {
            try
            {
                InitializeComponent();
                Spock_sql = "select sum(down_point_1) as 合计,nus.PID as 病案号,nus.grade_doc_name as  责任人," +
                                 @"to_char(GRADE_TIME,'yyyy-mm-dd hh:mi')  as 抽查时间,t.patient_name  as 患者姓名,t.sick_bed_no as 床号," +
                                 @"nus.SICKAREA_ID as 病区编号,nus.SICKAREA_NAME as 病区,nus.SECTION_ID as 科室编号," +
                                 @"nus.SECTION_NAME as 科室,nus.doc_type as 文书类型 from T_NURSE_GRADE nus inner join t_in_patient t on t.pid=nus.pid";
                Grad_sql = "group by nus.pid,nus.grade_doc_name," +
                          @"to_char(GRADE_TIME,'yyyy-mm-dd hh:mi'),t.patient_name,t.sick_bed_no,nus.SICKAREA_ID,nus.SICKAREA_NAME,nus.SECTION_ID," +
                         @" nus.SECTION_NAME,nus.doc_type order by to_char(GRADE_TIME,'yyyy-mm-dd hh:mi') desc ";
                Time_sql = "select distinct to_char(GRADE_TIME,'yyyy-mm-dd hh:mi')  as 时间 from T_NURSE_GRADE";
              }
            catch 
            {
            }
        }

        private void Spotcheck_Grade_Load(object sender, EventArgs e)
        {
            try
            {
                flgView.fg.MouseDoubleClick += new MouseEventHandler(flgView_MouseDoubleClick);
                Sick();
                Section();
                flgView.fg.AllowEditing = false;
                btnSelete_Click(sender,e);
               //btnSelete_Click(sender,e);
                Refurbish();
            }
            catch
            {
            }
        }

        //绑定所属科病区
        private void Sick()
        {
            DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO  where ISBELONGTOSECTION='N'");
            cboSick.DataSource = ds.Tables[0].DefaultView;
            cboSick.ValueMember = "SAID";
            cboSick.DisplayMember = "SICK_AREA_NAME";
        }
        //绑定所属科室
        private void Section()
        {
            DataSet ds = App.GetDataSet("select * from T_SECTIONINFO where ISBELONGTOBIGSECTION='N'");
            cboSections.DataSource = ds.Tables[0].DefaultView;
            cboSections.ValueMember = "SID";
            cboSections.DisplayMember = "SECTION_NAME";
        }
        //刷新
        private void Refurbish()
        {
            if (chkTime.Checked == true)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
                chkSick.Checked = false;
                chkSection.Checked = false;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }

            if (chkSick.Checked == true)
            {
                cboSick.Enabled = true;
                chkSection.Checked = false;
                chkTime.Checked = false;
            }
            else
            {
                cboSick.Enabled = false;
            }
            if (chkSection.Checked == true)
            {
                cboSections.Enabled = true;
                chkTime.Checked = false;
                chkSick.Checked = false;
            }
            else
            {
                cboSections.Enabled = false;
            }
        }
        #region
        //        //日期查询

//        private void RuTime()
//        {
//         #region
//            string Start_Admission = dtpStartTime.Value.ToString("yyyy-MM-dd");
//            string End_Admission = dtpEndTime.Value.ToString("yyyy-MM-dd");
//            if (chkTime.Checked == true)
//            {
//                if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
//                {
//                    if (dtpEndTime.Value < dtpStartTime.Value)
//                    {
//                        App.Msg("结束日期不能小于起始日期！");
//                        dtpEndTime.Focus();
//                        return;
//                    }
//                    else
//                    {
//                        if (chkTemperture.Checked == true)
//                        {

//                            His_sql = Spock_sql + "  where nus.down_reason_1 like '%体温单%' and GRADE_TIME  between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd') " + Grad_sql;

//                        }
//                        if (chkGravenurserecord.Checked == true)
//                        {

//                            His_sql = Spock_sql + "  where nus.down_reason_1 like '%危重%' and GRADE_TIME  between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd') " + Grad_sql;
//                        }
//                        if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
//                        {

//                            His_sql = Spock_sql + "  where nus.down_reason_1 like '%体温单%' and GRADE_TIME  between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  " + Grad_sql;
                           
//                        }
//                    }
//                }
//                else
//                {
//                    App.Msg("请选择文书种类！");
//                }
//            }
//            #endregion
//        }

//        //病区查询
//        private void SickArae()
//        {
//#region
//            if (chkSick.Checked == true)
//            {
//                if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
//                {
//                    if (chkTemperture.Checked == true)
//                    {
//                        His_sql = Spock_sql + "  where nus.down_reason_1 like '%体温单%' and   t.sick_area_id='" + cboSick.SelectedValue + "'" + Grad_sql;
//                        //Te_sql = His_sql;
//                    }
//                    else if (chkGravenurserecord.Checked == true)
//                    {
//                        His_sql = Spock_sql + "  where nus.down_reason_1 like '%危重%' and   t.sick_area_id='" + cboSick.SelectedValue + "'" + Grad_sql;
//                    }
//                    if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
//                    {
//                        //or nus.down_reason_1 like '%危重%' and   t.sick_area_id='" + cboSick.SelectedValue + "'
//                        His_sql = Spock_sql + "  where nus.down_reason_1 like '%体温单%' and   t.sick_area_id='" + cboSick.SelectedValue + "' " + Grad_sql;
//                    }
//                }
//                else
//                {
//                    App.Msg("请选择文书种类！");
//                }
//            }
//#endregion
//        }
//        //科室查询
//        private void Sectioninfo()
//        {
//#region
//            if (chkSection.Checked == true)
//            {
//                if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
//                {
//                    if (chkTemperture.Checked == true)
//                    {
//                        His_sql = Spock_sql + "  where nus.down_reason_1 like '%体温单%' or nus.down_reason_1 like '%危重%' and  t.section_id='" + cboSections.SelectedValue + "'" + Grad_sql;
//                    }
//                    if (chkGravenurserecord.Checked == true)
//                    {
//                        His_sql = Spock_sql + "  where nus.down_reason_1 like '%危重%' and  t.section_id='" + cboSections.SelectedValue + "''" + Grad_sql;
//                    }
//                    if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
//                    {
                        
//                        His_sql = Spock_sql + "  where nus.down_reason_1 like '%体温单%' and  t.section_id='" + cboSections.SelectedValue + "'" + Grad_sql;
//                    }
//                }
//                else
//                {
//                    App.Msg("请选择文书种类！");
//                }
                
//            }
           
//#endregion

//        }
//        //抽查文书类型
//        private void Book_type()
//        {
//            #region
//            if (chkTemperture.Checked == true)
//            {
//                His_sql = Spock_sql + "  where nus.down_reason_1 like '%体温单%' " + Grad_sql;
//                //Te_sql = His_sql;
//            }
//            if (chkGravenurserecord.Checked == true)
//            {
//                His_sql = Spock_sql + " where nus.down_reason_1 like '%危重%'" + Grad_sql;
//            }
//            if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
//            {
//                His_sql= Spock_sql + "  where  nus.down_reason_1 like '%体温单%' " + Grad_sql;
//            }
#endregion
        /// <summary>
        /// 时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked == true)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
                chkSick.Checked = false;
                chkSection.Checked = false;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }
        /// <summary>
        /// 病区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSick_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSick.Checked == true)
            {
                cboSick.Enabled = true;
                chkSection.Checked = false;
                chkTime.Checked = false;
            }
            else
            {
                cboSick.Enabled = false;
            }
        }
        /// <summary>
        /// 科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection.Checked == true)
            {
                cboSections.Enabled = true;
                chkTime.Checked = false;
                chkSick.Checked = false;
            }
            else
            {
                cboSections.Enabled = false;
            }
        }
        /// <summary>
        /// 体温单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTemperture_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkTemperture.Checked == true)
            //{
            //    chkGravenurserecord.Checked = false;

            //}

        }
        /// <summary>
        /// 危重护理记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkGravenurserecord_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkGravenurserecord.Checked == true)
            //{
            //    chkTemperture.Checked = false;
            //}
        }
        /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        private void CellUnit()
        {
            #region
            //单元格合并和设置 
            flgView.fg[0, 0] = "";
            //flgView.fg[1, 0] = "";
            flgView.fg[1, 1] = "抽查时间";
            flgView.fg[1, 2] = "责任人";
            flgView.fg[1, 3] = "患者姓名";
            flgView.fg[1, 4] = "病案号";
            flgView.fg[1, 5] = "床号";
            flgView.fg[1, 6] = "病区编号";
            flgView.fg[1, 7] = "病区";
            flgView.fg[1, 8] = "科室编号";
            flgView.fg[1, 9] = "科室";
            flgView.fg[1, 10] = "体温单";
            flgView.fg[1, 11] = "危重护理记录单";
            flgView.fg[1, 12] = "合计";
            flgView.fg[1, 13] = "操作";

            flgView.fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.fg.Cols.Fixed = 0;
            //合并单元格
            C1.Win.C1FlexGrid.CellRange cr;

            cr = flgView.fg.GetCellRange(0, 0, 1, 0);
            cr.Data = "";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 1, 1, 1);
            cr.Data = "抽查时间";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 2, 1, 2);
            cr.Data = "责任人";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 3, 1, 3);
            cr.Data = "患者姓名";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 4, 1, 4);
            cr.Data = "病案号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);


            cr = flgView.fg.GetCellRange(0, 5, 1, 5);
            cr.Data = "床号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);


            cr = flgView.fg.GetCellRange(0, 6, 1, 6);
            cr.Data = "病区编号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 7, 1, 7);
            cr.Data = "病区";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 8, 1, 8);
            cr.Data = "科室编号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 9, 1, 9);
            cr.Data = "科室";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 10, 0, 11);
            cr.Data = "文书";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 12, 1, 12);
            cr.Data = "合计";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 13, 1, 13);
            cr.Data = "操作";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);


            flgView.fg.AutoSizeCols();
            for (int j =2; j < flgView.fg.Rows.Count; j++)
            {
                CellRange rg = flgView.fg.GetCellRange(j, 13);
                rg.StyleNew.ForeColor = Color.Blue;
            }
            for (int i = 2; i < flgView.fg.Rows.Count; i++)
            {

                if (flgView.fg[i, 1] != null)
                {
                    if (flgView.fg[i, 1].ToString().Contains("累计") || flgView.fg[i, 1].ToString().Contains("总平均分")||flgView.fg[i, 1].ToString().Contains("总分"))
                    {
                        flgView.fg.Rows[i].StyleNew.ForeColor = Color.Red;
                        //横线加粗
                        flgView.fg.Rows[i - 1].StyleNew.Border.Color = Color.Red;
                        flgView.fg.Rows[i - 1].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
                        flgView.fg.Rows[i - 1].StyleNew.Border.Width = 1;
                    }
                }
            }

                //把编号隐藏
                flgView.fg.Cols[0].Visible = false;
            flgView.fg.Cols[0].AllowEditing = false;

            flgView.fg.Cols[6].Visible = false;
            flgView.fg.Cols[6].AllowEditing = false;
            flgView.fg.Cols[7].Visible = false;
            flgView.fg.Cols[7].AllowEditing = false;
            flgView.fg.Cols[8].Visible = false;
            flgView.fg.Cols[8].AllowEditing = false;
            flgView.fg.Cols[9].Visible = false;
            flgView.fg.Cols[9].AllowEditing = false;

            if (chkTemperture.Checked == true)
            {
                flgView.fg.Cols[11].Visible = false;
                flgView.fg.Cols[11].AllowEditing = false;
            }
            else if (chkGravenurserecord.Checked == true)
            {
                flgView.fg.Cols[10].Visible = false;
                flgView.fg.Cols[10].AllowEditing = false;
            }
            if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
            {
                flgView.fg.Cols[11].Visible = true;
                flgView.fg.Cols[11].AllowEditing = true;
                flgView.fg.Cols[10].Visible = true;
                flgView.fg.Cols[10].AllowEditing = true;
            }
            #endregion
        }
        /// <summary>
        /// 表头
        /// /summary>
        private void SetTable()
        {
            flgView.fg.Cols.Count = 14;
            flgView.fg.Cols.Fixed = 0;
            flgView.fg.Rows.Count = 2;
            flgView.fg.Rows.Fixed = 2;
        }

        #region
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelete_Click(object sender, EventArgs e)
        {
            flgView.fg.AllowEditing = false;
            flgView.fg.Clear();
             TGrade.Clear();
            //抽查时间：Start_Admission 开始时间  End_Admission 结束时间
            string Start_Admission = dtpStartTime.Value.ToString("yyyy-MM-dd");
            string End_Admission = dtpEndTime.Value.ToString("yyyy-MM-dd");
            SetTable();
            int t = 0;
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            string name_count = "累计";
            string name = "查看明细";
            string temperatures = "0";
            string nuse = "0";
            double Tnursem = 0;
            double Wnurse = 0;
            double Tonurse = 0;
            int count = 0;
            int tt = 0;
            int ttt = 0;
            string Time_SQL = "";
            if (chkTime.Checked == true)
            {
                if (dtpEndTime.Value <= dtpStartTime.Value)
                {
                    App.Msg("结束日期不能小于或等于起始日期！");
                    dtpEndTime.Focus();
                    string ss = null;
                    DataSet ds3 = App.GetDataSet(ss);
                    if (ds3 == null)
                    {
                        CellUnit();
                    }
                    return;
                }
                else
                {

                     Time_SQL = Time_sql + "  where GRADE_TIME  between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  order by  to_char(GRADE_TIME,'yyyy-mm-dd hh:mi') desc";
               
                }
            }
            else
            {
        
                    Time_SQL = Time_sql + " order by  to_char(GRADE_TIME,'yyyy-mm-dd hh:mi') desc";
 
             
            }
            
            DataSet ds2 = App.GetDataSet(Time_SQL);
            if (ds2 != null)
            {
                DataTable dt2 = ds2.Tables[0];
                if (dt2 != null)
                {

                    for (int j = 0; j < dt2.Rows.Count; j++)
                    {
                        Class_Spotcheck spk = new Class_Spotcheck();
                        spk.Choucha_time = dt2.Rows[j]["时间"].ToString();
                        //文书种类查询
                        if (chkTemperture.Checked == true)
                        {
                            His_sql = Spock_sql + "  where nus.doc_type like '%体温单%' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi') " + Grad_sql;
                        }
                        if (chkGravenurserecord.Checked == true)
                        {
                            His_sql = Spock_sql + " where nus.doc_type  like '%病危%' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi') or nus.doc_type  like '%病重%' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi')" + Grad_sql;
                        }
                        if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                        {
                            His_sql = Spock_sql + "  where  nus.doc_type  like '%体温单%' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi') " + Grad_sql;
                        }
                        //科室+文书种类查询
                        if (chkSection.Checked == true)
                        {
                            #region
                            if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                            {
                                if (chkTemperture.Checked == true)
                                {
                                    His_sql = Spock_sql + "  where nus.doc_type  like '%体温单%' and  nus.SECTION_ID ='" + cboSections.SelectedValue + "' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi')" + Grad_sql;
                                }
                                if (chkGravenurserecord.Checked == true)
                                {
                                    His_sql = Spock_sql + "  where nus.doc_type  like '%病危%' and  nus.SECTION_ID ='" + cboSections.SelectedValue + "' and  nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi') or nus.doc_type  like '%病重%' and  t.section_id='" + cboSections.SelectedValue + "' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi')" + Grad_sql;
                                }
                                if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                                {

                                    His_sql = Spock_sql + "  where nus.doc_type  like '%体温单%' and  nus.SECTION_ID ='" + cboSections.SelectedValue + "' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi')" + Grad_sql;
                                }
                            }
                            else
                            {
                                App.Msg("请选择文书种类!");
                                string ss = null;
                                DataSet ds3 = App.GetDataSet(ss);
                                if (ds3 == null)
                                {
                                    CellUnit();
                                }
                                return;
                            }
                            #endregion

                        }
                        //病区+文书种类查询
                        if (chkSick.Checked == true)
                        {
                            #region
                            if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                            {
                                if (chkTemperture.Checked == true)
                                {
                                    His_sql = Spock_sql + "  where nus.doc_type  like '%体温单%' and   nus.SICKAREA_ID='" + cboSick.SelectedValue + "' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi')" + Grad_sql;
                                }
                                else if (chkGravenurserecord.Checked == true)
                                {
                                    His_sql = Spock_sql + "  where nus.doc_type  like '%危重%' and  nus.SICKAREA_ID='" + cboSick.SelectedValue + "' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi') or nus.doc_type  like '%病重%'  and   t.sick_area_id='" + cboSick.SelectedValue + "' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi')" + Grad_sql;
                                }
                                if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                                {

                                    His_sql = Spock_sql + "  where nus.doc_type  like '%体温单%' and   nus.SICKAREA_ID='" + cboSick.SelectedValue + "' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi') " + Grad_sql;
                                }
                            }
                            else
                            {
                                App.Msg("请选择文书种类!");
                                string ss = null;
                                DataSet ds3 = App.GetDataSet(ss);
                                if (ds3 == null)
                                {
                                    CellUnit();
                                }
                                return;
                            }
                            #endregion
                        }
                        //抽查时间+文书种类查询
                        if (chkTime.Checked == true)
                        {
                            #region
                            if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                            {

                                if (chkTemperture.Checked == true)
                                {

                                    His_sql = Spock_sql + "  where nus.doc_type  like '%体温单%' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi') " + Grad_sql;

                                }
                                if (chkGravenurserecord.Checked == true)
                                {

                                    His_sql = Spock_sql + "  where nus.doc_type  like '%危重%' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi') or nus.doc_type  like '%病重%' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi')" + Grad_sql;
                                }
                                if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                                {

                                    His_sql = Spock_sql + "  where nus.doc_type  like '%体温单%' and nus.GRADE_TIME=to_timestamp( '" + spk.Choucha_time + "','syyyy-mm-dd hh24:mi') " + Grad_sql;

                                }

                            #endregion
                            }
                            else
                            {
                                App.Msg("请选择文书种类!");
                                string ss = null;
                                DataSet ds3 = App.GetDataSet(ss);
                                if (ds3 == null)
                                {
                                    CellUnit();
                                }
                                return;
                            }
                        }


                        DataSet ds = App.GetDataSet(His_sql);
                        DataSet ds1 = new DataSet();
                        if (ds != null)
                        {

                            DataTable dt = ds.Tables[0];
                            if (dt != null)
                            {
                                sum1 = 0;
                                sum2 = 0;
                                sum3 = 0;

                                if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                                {
                                    count = TGrade.Count;
                                    #region
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        double sum;
                                        double bookType;
                                        double book_nurse;
                                        flgView.fg.Rows.Add();
                                        Class_Spotcheck spoteck = new Class_Spotcheck();
                                        spoteck.Choucha_time = dt.Rows[i]["抽查时间"].ToString();
                                        spoteck.Person_in_charge = dt.Rows[i]["责任人"].ToString();
                                        spoteck.Pidname = dt.Rows[i]["患者姓名"].ToString();
                                        spoteck.Pids = dt.Rows[i]["病案号"].ToString();
                                        pid = spoteck.Pids;
                                        spoteck.Beds = dt.Rows[i]["床号"].ToString();
                                        spoteck.Sickid = dt.Rows[i]["病区编号"].ToString();
                                        spoteck.Sickname = dt.Rows[i]["病区"].ToString();
                                        spoteck.Sectionid = dt.Rows[i]["科室编号"].ToString();
                                        spoteck.Sectionname = dt.Rows[i]["科室"].ToString();
                                        if (dt.Rows[i]["合计"].ToString() != "")
                                        {
                                            spoteck.Temperature = Convert.ToDouble(dt.Rows[i]["合计"].ToString());
                                        }
                                        else
                                        {
                                            spoteck.Temperature = Convert.ToDouble(temperatures);
                                        }
                                        Nurse_sql = "select sum(down_point_1) as 危重合计  from T_NURSE_GRADE nus where nus.down_reason_1 like '%危重%' and nus.PID='" + pid + "' and GRADE_TIME=to_timestamp( '" + spoteck.Choucha_time + "','syyyy-mm-dd hh24:mi')";
                                        ds1 = App.GetDataSet(Nurse_sql);
                                        if (ds1.Tables[0].Rows[0]["危重合计"].ToString() != "")
                                        {
                                            spoteck.Nurse_record = Convert.ToDouble(ds1.Tables[0].Rows[0]["危重合计"].ToString());
                                        }
                                        else
                                        {
                                            spoteck.Nurse_record = Convert.ToDouble(nuse);
                                        }
                                        bookType = spoteck.Temperature;
                                        book_nurse = spoteck.Nurse_record;
                                        sum = bookType + book_nurse;
                                        spoteck.Total = sum;
                                        flgView.fg[2 + i + count, 1] = spoteck.Choucha_time;
                                        flgView.fg[2 + i + count, 2] = spoteck.Person_in_charge;
                                        flgView.fg[2 + i + count, 3] = spoteck.Pidname;
                                        flgView.fg[2 + i + count, 4] = spoteck.Pids;
                                        flgView.fg[2 + i + count, 5] = spoteck.Beds;
                                        flgView.fg[2 + i + count, 6] = spoteck.Sickid;
                                        flgView.fg[2 + i + count, 7] = spoteck.Sickname;
                                        flgView.fg[2 + i + count, 8] = spoteck.Sectionid;
                                        flgView.fg[2 + i + count, 9] = spoteck.Sectionname;
                                        flgView.fg[2 + i + count, 10] = bookType.ToString();
                                        flgView.fg[2 + i + count, 11] = book_nurse.ToString();
                                        flgView.fg[2 + i + count, 12] = spoteck.Total;
                                        flgView.fg[2 + i + count, 13] = name;
                                        string value = flgView.fg[2 + i + count, 10].ToString();
                                        string value_nurse = flgView.fg[2 + i + count, 11].ToString();
                                        string sum_tw = flgView.fg[2 + i + count, 12].ToString();
                                        sum1 += Convert.ToDouble(value);
                                        Tnursem = sum1;
                                        sum2 += Convert.ToDouble(value_nurse);
                                        Wnurse = sum2;
                                        sum3 += Convert.ToDouble(sum_tw);
                                        Tonurse = sum3;
                                        TGrade.Add(spoteck);
                                        t = 2 + i + count;


                                    }
                                    #endregion
                                }
                                //体温单位true
                                else if (chkTemperture.Checked == true)
                                {
                                    see_particulars = "体温单";
                                    #region
                                    count = TGrade.Count;

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        flgView.fg.Rows.Add();
                                        Class_Spotcheck spoteck = new Class_Spotcheck();
                                        spoteck.Choucha_time = dt.Rows[i]["抽查时间"].ToString();
                                        spoteck.Person_in_charge = dt.Rows[i]["责任人"].ToString();
                                        spoteck.Pidname = dt.Rows[i]["患者姓名"].ToString();
                                        spoteck.Pids = dt.Rows[i]["病案号"].ToString();
                                        spoteck.Beds = dt.Rows[i]["床号"].ToString();
                                        spoteck.Sickid = dt.Rows[i]["病区编号"].ToString();
                                        spoteck.Sickname = dt.Rows[i]["病区"].ToString();
                                        spoteck.Sectionid = dt.Rows[i]["科室编号"].ToString();
                                        spoteck.Sectionname = dt.Rows[i]["科室"].ToString();
                                        if (dt.Rows[i]["合计"].ToString() != "")
                                        {
                                            spoteck.Temperature = Convert.ToDouble(dt.Rows[i]["合计"].ToString());
                                        }
                                        else
                                        {
                                            spoteck.Temperature = Convert.ToDouble(temperatures);
                                        }

                                        flgView.fg[2 + i + count, 1] = spoteck.Choucha_time;
                                        flgView.fg[2 + i + count, 2] = spoteck.Person_in_charge;
                                        flgView.fg[2 + i + count, 3] = spoteck.Pidname;
                                        flgView.fg[2 + i + count, 4] = spoteck.Pids;
                                        flgView.fg[2 + i + count, 5] = spoteck.Beds;
                                        flgView.fg[2 + i + count, 6] = spoteck.Sickid;
                                        flgView.fg[2 + i + count, 7] = spoteck.Sickname;
                                        flgView.fg[2 + i + count, 8] = spoteck.Sectionid;
                                        flgView.fg[2 + i + count, 9] = spoteck.Sectionname;
                                        flgView.fg[2 + i + count, 10] = spoteck.Temperature;
                                        flgView.fg[2 + i + count, 12] = spoteck.Temperature;
                                        flgView.fg[2 + i + count, 13] = name;
                                        string value = flgView.fg[2 + i + count, 10].ToString();
                                        sum1 += Convert.ToDouble(value);
                                        Tnursem = sum1;
                                        sum3 += Convert.ToDouble(value);
                                        Tonurse = sum3;
                                        TGrade.Add(spoteck);
                                        t = 2 + i + count;


                                    }

                                    #endregion
                                }
                                //危重护理为true
                                else if (chkGravenurserecord.Checked == true)
                                {
                                    see_particulars_nurse = "危重";
                                    #region
                                    count = TGrade.Count;
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        flgView.fg.Rows.Add();
                                        Class_Spotcheck spoteck = new Class_Spotcheck();
                                        spoteck.Choucha_time = dt.Rows[i]["抽查时间"].ToString();
                                        spoteck.Person_in_charge = dt.Rows[i]["责任人"].ToString();
                                        spoteck.Pidname = dt.Rows[i]["患者姓名"].ToString();
                                        spoteck.Pids = dt.Rows[i]["病案号"].ToString();
                                        spoteck.Beds = dt.Rows[i]["床号"].ToString();
                                        spoteck.Sickid = dt.Rows[i]["病区编号"].ToString();
                                        spoteck.Sickname = dt.Rows[i]["病区"].ToString();
                                        spoteck.Sectionid = dt.Rows[i]["科室编号"].ToString();
                                        spoteck.Sectionname = dt.Rows[i]["科室"].ToString();
                                        if (dt.Rows[i]["合计"].ToString() != "")
                                        {
                                            spoteck.Nurse_record = Convert.ToDouble(dt.Rows[i]["合计"].ToString());
                                        }
                                        else
                                        {
                                            spoteck.Nurse_record = Convert.ToDouble(nuse);
                                        }
                                        flgView.fg[2 + i + count, 1] = spoteck.Choucha_time;
                                        flgView.fg[2 + i + count, 2] = spoteck.Person_in_charge;
                                        flgView.fg[2 + i + count, 3] = spoteck.Pidname;
                                        flgView.fg[2 + i + count, 4] = spoteck.Pids;
                                        flgView.fg[2 + i + count, 5] = spoteck.Beds;
                                        flgView.fg[2 + i + count, 6] = spoteck.Sickid;
                                        flgView.fg[2 + i + count, 7] = spoteck.Sickname;
                                        flgView.fg[2 + i + count, 8] = spoteck.Sectionid;
                                        flgView.fg[2 + i + count, 9] = spoteck.Sectionname;
                                        //flgView.fg[2 + i + count, 10] = null;
                                        flgView.fg[2 + i + count, 11] = spoteck.Nurse_record;
                                        flgView.fg[2 + i + count, 12] = spoteck.Nurse_record;
                                        flgView.fg[2 + i + count, 13] = name;


                                        string value_nurse = flgView.fg[2 + i + count, 11].ToString();
                                        sum2 += Convert.ToDouble(value_nurse);
                                        Wnurse = sum2;
                                        sum3 += Convert.ToDouble(value_nurse);
                                        Tonurse = sum3;
                                        TGrade.Add(spoteck);
                                        t = 2 + i + count;
                                    }
                                    #endregion
                                }

                                if (t > 0)
                                {
                                    if (dt.Rows.Count > 0)
                                    {
                                        //在表格最后一行添加一行统计总数
                                        if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                                        {
                                            flgView.fg.Rows.Add();
                                            Class_Spotcheck spoteck = new Class_Spotcheck();
                                            spoteck.Choucha_time = name_count;
                                            spoteck.Person_in_charge = null;
                                            spoteck.Pidname = null;
                                            spoteck.Pids = null;
                                            spoteck.Beds = null;
                                            spoteck.Sickid = null;
                                            spoteck.Sickname = null;
                                            spoteck.Sectionid = null;
                                            spoteck.Sectionname = null;
                                            spoteck.Temperature = Tnursem;
                                            spoteck.Nurse_record = Wnurse;
                                            spoteck.Total = Tonurse;
                                            spoteck.Particulars = null;
                                            int counts = TGrade.Count;
                                            flgView.fg[t + 1, 1] = spoteck.Choucha_time;
                                            flgView.fg[t + 1, 2] = spoteck.Person_in_charge;
                                            flgView.fg[t + 1, 3] = spoteck.Pidname;
                                            flgView.fg[t + 1, 4] = spoteck.Pids;
                                            flgView.fg[t + 1, 5] = spoteck.Beds;
                                            flgView.fg[t + 1, 6] = spoteck.Sickid;
                                            flgView.fg[t + 1, 7] = spoteck.Sickname;
                                            flgView.fg[t + 1, 8] = spoteck.Sectionid;
                                            flgView.fg[t + 1, 9] = spoteck.Sectionname;
                                            string Book_T = Tvalues(spoteck.Temperature.ToString());
                                            flgView.fg[t + 1, 10] = Book_T;
                                            string Book_W = Tvalues(spoteck.Nurse_record.ToString());
                                            flgView.fg[t + 1, 11] = Book_W;
                                            string Book_Total = Tvalues(spoteck.Total.ToString());
                                            flgView.fg[t + 1, 12] = Book_Total;
                                            flgView.fg[t + 1, 13] = spoteck.Particulars;
                                            tt = t + 1;
                                            TGrade.Add(spoteck);
                                        }
                                        else if (chkTemperture.Checked == true)
                                        {
                                            flgView.fg.Rows.Add();
                                            Class_Spotcheck spoteck = new Class_Spotcheck();
                                            spoteck.Choucha_time = name_count;
                                            spoteck.Person_in_charge = null;
                                            spoteck.Pidname = null;
                                            spoteck.Pids = null;
                                            spoteck.Beds = null;
                                            spoteck.Sickid = null;
                                            spoteck.Sickname = null;
                                            spoteck.Sectionid = null;
                                            spoteck.Sectionname = null;
                                            spoteck.Temperature = Tnursem;
                                            //spoteck.Nurse_record = sum2;
                                            spoteck.Total = Tonurse;
                                            spoteck.Particulars = null;
                                            flgView.fg[t + 1, 1] = spoteck.Choucha_time;
                                            flgView.fg[t + 1, 2] = spoteck.Person_in_charge;
                                            flgView.fg[t + 1, 3] = spoteck.Pidname;
                                            flgView.fg[t + 1, 4] = spoteck.Pids;
                                            flgView.fg[t + 1, 5] = spoteck.Beds;
                                            flgView.fg[t + 1, 6] = spoteck.Sickid;
                                            flgView.fg[t + 1, 7] = spoteck.Sickname;
                                            flgView.fg[t + 1, 8] = spoteck.Sectionid;
                                            flgView.fg[t + 1, 9] = spoteck.Sectionname;
                                            string Book_T = Tvalues(spoteck.Temperature.ToString());
                                            flgView.fg[t + 1, 10] = Book_T;
                                            //string Book_W = Tvalues(spoteck.Nurse_record.ToString());
                                            //flgView.fg[t + 1, 11] = Book_W;
                                            string Book_Total = Tvalues(spoteck.Total.ToString());
                                            flgView.fg[t + 1, 12] = Book_Total;
                                            flgView.fg[t + 1, 13] = spoteck.Particulars;
                                            tt = t + 1;
                                            TGrade.Add(spoteck);
                                        }
                                        else if (chkGravenurserecord.Checked == true)
                                        {
                                            flgView.fg.Rows.Add();
                                            Class_Spotcheck spoteck = new Class_Spotcheck();
                                            spoteck.Choucha_time = name_count;
                                            spoteck.Person_in_charge = null;
                                            spoteck.Pidname = null;
                                            spoteck.Pids = null;
                                            spoteck.Beds = null;
                                            spoteck.Sickid = null;
                                            spoteck.Sickname = null;
                                            spoteck.Sectionid = null;
                                            spoteck.Sectionname = null;
                                            //spoteck.Temperature = sum1;
                                            spoteck.Nurse_record = Wnurse;
                                            spoteck.Total = Tonurse;
                                            spoteck.Particulars = null;
                                            flgView.fg[t + 1, 1] = spoteck.Choucha_time;
                                            flgView.fg[t + 1, 2] = spoteck.Person_in_charge;
                                            flgView.fg[t + 1, 3] = spoteck.Pidname;
                                            flgView.fg[t + 1, 4] = spoteck.Pids;
                                            flgView.fg[t + 1, 5] = spoteck.Beds;
                                            flgView.fg[t + 1, 6] = spoteck.Sickid;
                                            flgView.fg[t + 1, 7] = spoteck.Sickname;
                                            flgView.fg[t + 1, 8] = spoteck.Sectionid;
                                            flgView.fg[t + 1, 9] = spoteck.Sectionname;
                                            //string Book_T = Tvalues(spoteck.Temperature.ToString());
                                            //flgView.fg[t + 1, 10] = Book_T;
                                            string Book_W = Tvalues(spoteck.Nurse_record.ToString());
                                            flgView.fg[t + 1, 11] = Book_W;
                                            string Book_Total = Tvalues(spoteck.Total.ToString());
                                            flgView.fg[t + 1, 12] = Book_Total;
                                            flgView.fg[t + 1, 13] = spoteck.Particulars;
                                            tt = t + 1;
                                            TGrade.Add(spoteck);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            CellUnit();
                        }

                    }
                    if (tt > 0)
                    {
                        double tsum = 0;
                        double wsum = 0;
                        double tosum = 0;
                        int ros = 0;

                        //ros = dt2.Rows.Count;
                        for (int i = 2; i < flgView.fg.Rows.Count; i++)
                        {

                            if (flgView.fg[i, 1] != null)
                            {
                                if (flgView.fg[i, 1].ToString().Contains("累计"))
                                {

                                    ros += 1;
                                    string WoTal = "";

                                    string toTal = flgView.fg[i, 10].ToString();
                                    if (flgView.fg[i, 11] == null)
                                    {
                                        WoTal = "0";
                                    }
                                    else
                                    {
                                        WoTal = flgView.fg[i, 11].ToString();
                                    }
                                    string ToTals = flgView.fg[i, 12].ToString();
                                    tsum += Convert.ToDouble(toTal);
                                    wsum += Convert.ToDouble(WoTal);
                                    tosum += Convert.ToDouble(ToTals);
                                }
                            }
                        }

                        //在表格最后一行添加一行统计总数
                        if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                        {
                            flgView.fg.Rows.Add();
                            Class_Spotcheck spoteck = new Class_Spotcheck();
                            spoteck.Choucha_time = "总分";
                            spoteck.Person_in_charge = null;
                            spoteck.Pidname = null;
                            spoteck.Pids = null;
                            spoteck.Beds = null;
                            spoteck.Sickid = null;
                            spoteck.Sickname = null;
                            spoteck.Sectionid = null;
                            spoteck.Sectionname = null;
                            spoteck.Temperature = tsum;
                            spoteck.Nurse_record = wsum;
                            spoteck.Total = tosum;
                            spoteck.Particulars = null;
                            int counts = TGrade.Count;
                            flgView.fg[tt + 1, 1] = spoteck.Choucha_time;
                            flgView.fg[tt + +1, 2] = spoteck.Person_in_charge;
                            flgView.fg[tt + +1, 3] = spoteck.Pidname;
                            flgView.fg[tt + 1, 4] = spoteck.Pids;
                            flgView.fg[tt + 1, 5] = spoteck.Beds;
                            flgView.fg[tt + 1, 6] = spoteck.Sickid;
                            flgView.fg[tt + 1, 7] = spoteck.Sickname;
                            flgView.fg[tt + 1, 8] = spoteck.Sectionid;
                            flgView.fg[tt + 1, 9] = spoteck.Sectionname;
                            string Book_T = Tvalues(spoteck.Temperature.ToString());
                            flgView.fg[tt + 1, 10] = Book_T;
                            string Book_W = Tvalues(spoteck.Nurse_record.ToString());
                            flgView.fg[tt + 1, 11] = Book_W;
                            string Book_Total = Tvalues(spoteck.Total.ToString());
                            flgView.fg[tt + 1, 12] = Book_Total;
                            flgView.fg[tt + 1, 13] = spoteck.Particulars;
                            ttt = tt + 1;
                            TGrade.Add(spoteck);
                        }
                        else if (chkTemperture.Checked == true)
                        {
                            flgView.fg.Rows.Add();
                            Class_Spotcheck spoteck = new Class_Spotcheck();
                            spoteck.Choucha_time = "总分";
                            spoteck.Person_in_charge = null;
                            spoteck.Pidname = null;
                            spoteck.Pids = null;
                            spoteck.Beds = null;
                            spoteck.Sickid = null;
                            spoteck.Sickname = null;
                            spoteck.Sectionid = null;
                            spoteck.Sectionname = null;
                            spoteck.Temperature = tsum;
                            spoteck.Total = tosum;
                            spoteck.Particulars = null;
                            flgView.fg[tt + 1, 1] = spoteck.Choucha_time;
                            flgView.fg[tt + 1, 2] = spoteck.Person_in_charge;
                            flgView.fg[tt + 1, 3] = spoteck.Pidname;
                            flgView.fg[tt + 1, 4] = spoteck.Pids;
                            flgView.fg[tt + 1, 5] = spoteck.Beds;
                            flgView.fg[tt + 1, 6] = spoteck.Sickid;
                            flgView.fg[tt + 1, 7] = spoteck.Sickname;
                            flgView.fg[tt + 1, 8] = spoteck.Sectionid;
                            flgView.fg[tt + 1, 9] = spoteck.Sectionname;
                            string Book_T = Tvalues(spoteck.Temperature.ToString());
                            flgView.fg[tt + 1, 10] = Book_T;
                            //string Book_W = Tvalues(spoteck.Nurse_record.ToString());
                            //flgView.fg[t + 1, 11] = Book_W;
                            string Book_Total = Tvalues(spoteck.Total.ToString());
                            flgView.fg[tt + 1, 12] = Book_Total;
                            flgView.fg[tt + 1, 13] = spoteck.Particulars;
                            ttt = tt + 1;
                            TGrade.Add(spoteck);
                        }
                        else if (chkGravenurserecord.Checked == true)
                        {
                            flgView.fg.Rows.Add();

                            Class_Spotcheck spoteck = new Class_Spotcheck();
                            spoteck.Choucha_time = "总分";
                            spoteck.Person_in_charge = null;
                            spoteck.Pidname = null;
                            spoteck.Pids = null;
                            spoteck.Beds = null;
                            spoteck.Sickid = null;
                            spoteck.Sickname = null;
                            spoteck.Sectionid = null;
                            spoteck.Sectionname = null;
                            //spoteck.Temperature = sum1;
                            spoteck.Nurse_record = wsum;
                            spoteck.Total = tosum;
                            spoteck.Particulars = null;
                            flgView.fg[tt + 1, 1] = spoteck.Choucha_time;
                            flgView.fg[tt + 1, 2] = spoteck.Person_in_charge;
                            flgView.fg[tt + 1, 3] = spoteck.Pidname;
                            flgView.fg[tt + 1, 4] = spoteck.Pids;
                            flgView.fg[tt + 1, 5] = spoteck.Beds;
                            flgView.fg[tt + 1, 6] = spoteck.Sickid;
                            flgView.fg[tt + 1, 7] = spoteck.Sickname;
                            flgView.fg[tt + 1, 8] = spoteck.Sectionid;
                            flgView.fg[tt + 1, 9] = spoteck.Sectionname;
                            //string cout = Tvalues(spoteck.Temperature.ToString());
                            //flgView.fg[t + 1, 10] = Book_T;
                            string Book_W = Tvalues(spoteck.Nurse_record.ToString());
                            flgView.fg[tt + 1, 11] = Book_W;
                            string Book_Total = Tvalues(spoteck.Total.ToString());
                            flgView.fg[tt + 1, 12] = Book_Total;
                            flgView.fg[tt + 1, 13] = spoteck.Particulars;
                            ttt = tt + 1;
                            TGrade.Add(spoteck);
                        }


                        if (ttt > 0)
                        {
                            //在表格最后一行添加一行统计总数
                            if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                            {
                                flgView.fg.Rows.Add();
                                Class_Spotcheck spoteck = new Class_Spotcheck();
                                spoteck.Choucha_time = "总平均分";
                                spoteck.Person_in_charge = null;
                                spoteck.Pidname = null;
                                spoteck.Pids = null;
                                spoteck.Beds = null;
                                spoteck.Sickid = null;
                                spoteck.Sickname = null;
                                spoteck.Sectionid = null;
                                spoteck.Sectionname = null;
                                spoteck.Temperature = tsum / ros;
                                spoteck.Nurse_record = wsum / ros;
                                spoteck.Total = tosum / ros;
                                spoteck.Particulars = null;
                                int counts = TGrade.Count;
                                flgView.fg[ttt + 1, 1] = spoteck.Choucha_time;
                                flgView.fg[ttt + 1, 2] = spoteck.Person_in_charge;
                                flgView.fg[ttt + 1, 3] = spoteck.Pidname;
                                flgView.fg[ttt + 1, 4] = spoteck.Pids;
                                flgView.fg[ttt + 1, 5] = spoteck.Beds;
                                flgView.fg[ttt + 1, 6] = spoteck.Sickid;
                                flgView.fg[ttt + 1, 7] = spoteck.Sickname;
                                flgView.fg[ttt + 1, 8] = spoteck.Sectionid;
                                flgView.fg[ttt + 1, 9] = spoteck.Sectionname;
                                string Book_T = Tvalues(spoteck.Temperature.ToString());
                                flgView.fg[ttt + 1, 10] = Book_T;
                                string Book_W = Tvalues(spoteck.Nurse_record.ToString());
                                flgView.fg[ttt + 1, 11] = Book_W;
                                string Book_Total = Tvalues(spoteck.Total.ToString());
                                flgView.fg[ttt + 1, 12] = Book_Total;
                                flgView.fg[ttt + 1, 13] = spoteck.Particulars;
                                TGrade.Add(spoteck);
                            }
                            else if (chkTemperture.Checked == true)
                            {
                                flgView.fg.Rows.Add();
                                Class_Spotcheck spoteck = new Class_Spotcheck();
                                spoteck.Choucha_time = "总平均分";
                                spoteck.Person_in_charge = null;
                                spoteck.Pidname = null;
                                spoteck.Pids = null;
                                spoteck.Beds = null;
                                spoteck.Sickid = null;
                                spoteck.Sickname = null;
                                spoteck.Sectionid = null;
                                spoteck.Sectionname = null;
                                spoteck.Temperature = tsum / ros;
                                spoteck.Total = tosum / ros;
                                spoteck.Particulars = null;
                                flgView.fg[ttt + 1, 1] = spoteck.Choucha_time;
                                flgView.fg[ttt + 1, 2] = spoteck.Person_in_charge;
                                flgView.fg[ttt + 1, 3] = spoteck.Pidname;
                                flgView.fg[ttt + 1, 4] = spoteck.Pids;
                                flgView.fg[ttt + 1, 5] = spoteck.Beds;
                                flgView.fg[ttt + 1, 6] = spoteck.Sickid;
                                flgView.fg[ttt + 1, 7] = spoteck.Sickname;
                                flgView.fg[ttt + 1, 8] = spoteck.Sectionid;
                                flgView.fg[ttt + 1, 9] = spoteck.Sectionname;
                                string Book_T = Tvalues(spoteck.Temperature.ToString());
                                flgView.fg[ttt + +1, 10] = Book_T;
                                //string Book_W = Tvalues(spoteck.Nurse_record.ToString());
                                //flgView.fg[t + 1, 11] = Book_W;
                                string Book_Total = Tvalues(spoteck.Total.ToString());
                                flgView.fg[ttt + 1, 12] = Book_Total;
                                flgView.fg[ttt + 1, 13] = spoteck.Particulars;
                                TGrade.Add(spoteck);
                            }
                            else if (chkGravenurserecord.Checked == true)
                            {
                                flgView.fg.Rows.Add();
                                Class_Spotcheck spoteck = new Class_Spotcheck();
                                spoteck.Choucha_time = "总平均分";
                                spoteck.Person_in_charge = null;
                                spoteck.Pidname = null;
                                spoteck.Pids = null;
                                spoteck.Beds = null;
                                spoteck.Sickid = null;
                                spoteck.Sickname = null;
                                spoteck.Sectionid = null;
                                spoteck.Sectionname = null;
                                spoteck.Nurse_record = wsum / ros;
                                spoteck.Total = tosum / ros;
                                spoteck.Particulars = null;
                                flgView.fg[ttt + 1, 1] = spoteck.Choucha_time;
                                flgView.fg[ttt + 1, 2] = spoteck.Person_in_charge;
                                flgView.fg[ttt + 1, 3] = spoteck.Pidname;
                                flgView.fg[ttt + 1, 4] = spoteck.Pids;
                                flgView.fg[ttt + 1, 5] = spoteck.Beds;
                                flgView.fg[ttt + 1, 6] = spoteck.Sickid;
                                flgView.fg[ttt + 1, 7] = spoteck.Sickname;
                                flgView.fg[ttt + 1, 8] = spoteck.Sectionid;
                                flgView.fg[ttt + 1, 9] = spoteck.Sectionname;
                                //string cout = Tvalues(spoteck.Temperature.ToString());
                                //flgView.fg[t + 1, 10] = Book_T;
                                string Book_W = Tvalues(spoteck.Nurse_record.ToString());
                                flgView.fg[ttt + 1, 11] = Book_W;
                                string Book_Total = Tvalues(spoteck.Total.ToString());
                                flgView.fg[ttt + 1, 12] = Book_Total;
                                flgView.fg[ttt + 1, 13] = spoteck.Particulars;
                                TGrade.Add(spoteck);
                            }

                            CellUnit();
                            flgView.fg.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[6].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[7].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[8].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[9].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[10].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[11].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[12].TextAlign = TextAlignEnum.CenterCenter;
                            flgView.fg.Cols[13].TextAlign = TextAlignEnum.CenterCenter;
                        }
                    }
                    else
                    {
                        CellUnit();
                    }


                }


            }

        }
        #endregion
        private string Tvalues(string value)
        {
            string Tvalued = "";
            if (value.ToString().Contains("."))
            {
                //获取小数点的索引
                int index = value.ToString().IndexOf('.');
                //截取到小数点后面的一位小数
                Tvalued = value.ToString().Substring(0, index + 2);
            }
            else
            {
                Tvalued = value.ToString() + ".0";
            }
            return Tvalued;

        }
        private void flgView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
          
            if (flgView.fg.RowSel > 1)
            {
         
                if (flgView.fg[1, flgView.fg.ColSel].ToString().Trim() == "操作")
                {
                    string pid = "";
                    if (flgView.fg[flgView.fg.RowSel, 4] == null)
                    {
                        return;

                    }
                    if (flgView.fg[flgView.fg.RowSel, 4].ToString() != "")
                    {
                        pid = flgView.fg[flgView.fg.RowSel, 4].ToString();
                    }
                    string person_in_charge = flgView.fg[flgView.fg.RowSel, 2].ToString();
                    if (chkTemperture.Checked == true)
                    {
                        see_particulars = "体温单";
                    }
                    else
                    {
                        see_particulars = null;
                    }
                    if (chkGravenurserecord.Checked == true)
                    {
                        see_particulars_nurse = "危重";
                    }
                    else
                    {
                        see_particulars_nurse = null;
                    }
                    FrmSpotcheck_particulars frm = new FrmSpotcheck_particulars(pid, person_in_charge, see_particulars, see_particulars_nurse);
                    frm.Dock = DockStyle.Fill;
                    frm.ShowDialog();
                }
            }
        }

        private void flgView_Click(object sender, EventArgs e)
        {
            flgView.fg.Cols[0].AllowEditing = false;
            flgView.fg.Cols[1].AllowEditing = false;
            flgView.fg.Cols[2].AllowEditing = false;
            flgView.fg.Cols[3].AllowEditing = false;
            flgView.fg.Cols[4].AllowEditing = false;
            flgView.fg.Cols[5].AllowEditing = false;
            flgView.fg.Cols[6].AllowEditing = false;
            flgView.fg.Cols[7].AllowEditing = false;
            flgView.fg.Cols[8].AllowEditing = false;
            flgView.fg.Cols[9].AllowEditing = false;
            flgView.fg.Cols[10].AllowEditing = false;
            flgView.fg.Cols[11].AllowEditing = false;
            flgView.fg.Cols[12].AllowEditing = false;
        }
    }
}
