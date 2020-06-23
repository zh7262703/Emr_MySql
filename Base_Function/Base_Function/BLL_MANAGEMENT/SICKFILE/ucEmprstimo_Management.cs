using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class ucEmprstimo_Management : UserControl
    {
        ColumnInfo[] cols = new ColumnInfo[18];
        
        private string Case_hispital;
        public ucEmprstimo_Management()
        {
            InitializeComponent();
            Case_hispital = "select * from percuriam_borrow_management";
            App.UsControlStyle(this);
        }
        private void ucEmprstimo_Management_Load(object sender, EventArgs e)
        {
            try
            {
                Section();
                Inquiry_Range();
                chkHospitalTime_CheckedChanged(sender, e);
                chkToHospitalTime_CheckedChanged(sender, e);
                chkBorrowTime_CheckedChanged(sender, e);
                chkBorrowSection_CheckedChanged(sender, e);
                chkRange_CheckedChanged(sender, e);
                
            }
            catch { }
 
        }
        /// <summary>
        /// 绑定科室
        /// </summary>
        private void Section()
        {

            DataSet ds = App.GetDataSet("select * from t_sectioninfo ");
            cboBorrow_Section.DataSource = ds.Tables[0].DefaultView;
            cboBorrow_Section.ValueMember = "SID";
            cboBorrow_Section.DisplayMember = "SECTION_NAME";
        }
        /// <summary>
        /// 绑定查询范围
        /// </summary>
        private void Inquiry_Range()
        {
            DataSet ds = App.GetDataSet("select * from t_data_code where TYPE='45' order by ID asc");
            cboInquiry_Range.DataSource = ds.Tables[0].DefaultView;
            cboInquiry_Range.ValueMember = "ID";
            cboInquiry_Range.DisplayMember = "NAME";
        }
        /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        private void CellUnit()
        {
          
            //单元格合并和设置  
            //flgView.fg[0, 0] = "";
            flgView.fg[0, 1] = "借阅日期";
            flgView.fg[0, 2] = "借阅人";
            flgView.fg[0, 3] = "借阅科室";
            flgView.fg[0, 4] = "查询内容";
            flgView.fg[0, 5] = "归还日期";
            flgView.fg[0, 6] = "计划归还日期";
            flgView.fg[0, 7] = "病案号";
            flgView.fg[0, 8] = "姓名";
            flgView.fg[0, 9] = "年龄";
            flgView.fg[0, 10] = "入院日期";
            flgView.fg[0, 11] = "出院主诊断";
            flgView.fg[0, 12] = "出院科别";
            flgView.fg[0, 13] = "费别";
            flgView.fg[0, 14] = "出院日期";
            flgView.fg[0, 15] = "疾病分类代码";
            flgView.fg[0, 16] = "手术分类代码";
            flgView.fg[0, 17] = "病案状态";
            flgView.fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.fg.Cols.Fixed = 0;

            //单元格合并
            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.fg.GetCellRange(0, 1, 0, 1);
            cr.Data = "借阅日期";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 2, 0,2);
            cr.Data = "借阅人";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 3, 0, 3);
            cr.Data = "借阅科室";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 4, 0, 4);
            cr.Data = "查询内容";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 5, 0, 5);
            cr.Data = "归还日期";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 6, 0, 6);
            cr.Data = "计划归还日期";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 7, 0, 7);
            cr.Data = "病案号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 8, 0, 8);
            cr.Data = "姓名";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 9, 0, 9);
            cr.Data = "年龄";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 10, 0, 10);
            cr.Data = "入院日期";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 11, 0, 11);
            cr.Data = "出院主诊断";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 12, 0, 12);
            cr.Data = "出院科别";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 13, 0, 13);
            cr.Data = "费别";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 14, 0, 14);
            cr.Data = "出院日期";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);


            cr = flgView.fg.GetCellRange(0, 15, 0, 15);
            cr.Data = "疾病分类代码";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);


            cr = flgView.fg.GetCellRange(0, 16, 0, 16);
            cr.Data = "手术分类代码";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);


            cr = flgView.fg.GetCellRange(0, 17, 0, 17);
            cr.Data = "病案状态";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);
            flgView.fg.AutoSizeCols();

            //把疾病分类代码隐藏
            flgView.fg.Cols[15].Visible = false;
            flgView.fg.Cols[15].AllowEditing = false;

            //把手术分类代码隐藏
            flgView.fg.Cols[16].Visible = false;
            flgView.fg.Cols[16].AllowEditing = false;

            //把病案状态隐藏
            flgView.fg.Cols[17].Visible = false;
            flgView.fg.Cols[17].AllowEditing = false;
            
            //把0列设置为不能点击
            flgView.fg.Cols[0].AllowEditing = false;
            flgView.fg.Cols[0].StyleNew.BackColor = Color.Coral;

            for (int i = 0; i < flgView.fg.Rows.Count; i++)
            {
                //只要有超期这两个字的字体都变成红色
                if (flgView.fg[i, 5].ToString().Contains("超期"))
                {

                    flgView.fg.Rows[i].StyleNew.ForeColor = Color.Red;
                }
                else 
                {
                    flgView.fg.Rows[i].StyleNew.ForeColor = Color.Black;
                }

            }
            


        }
        /// <summary>
        /// 表头设置
        /// </summary>
        private void SetTable()
        {
            flgView.fg.Cols.Count = 18;
            flgView.fg.Cols.Fixed = 0;
            flgView.fg.Rows.Count = 1;
            flgView.fg.Rows.Fixed = 1;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                //入院起始时间 和 入院截止时间
                string Start_Admission = dtpStart_Admission.Value.ToString("yyyy-MM-dd");
                string End_Admission = dtpEnd_Admission.Value.ToString("yyyy-MM-dd");

                //出院起始时间 和 出院截止时间
                string Start_Tohospital = dtpStart_Tohospital.Value.ToString("yyyy-MM-dd");
                string End_Tohospital = dtpEnd_Tohospital.Value.ToString("yyyy-MM-dd");

                //借阅起始时间 和 借阅截止时间
                string StartBorrow_Time = dtpStartBorrow_Time.Value.ToString("yyyy-MM-dd");
                string EndBorrow_Time = dtpEndBorrow_Time.Value.ToString("yyyy-MM-dd");

                SetTable();
                string sql = Case_hispital + " order by 借阅日期 asc";
                #region 住院号不为空
                if (txtNumber.Text.Trim() != "")
                {
                    sql = Case_hispital + "  where  病案号 like'%" + txtNumber.Text.Trim() + "%'";
                }
                else if (txtNumber.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    sql = Case_hispital + "  where   病案号 like'%" + txtNumber.Text.Trim() + "%' and  姓名 like'%" + txtName.Text.Trim() + "%' ";
                }
                else if (txtNumber.Text.Trim() != "" && txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "")
                {
                    sql = Case_hispital + "  where   病案号  like'%" + txtNumber.Text.Trim() + "%' and  姓名  like'%" + txtName.Text.Trim() + "%' and  疾病分类代码  like'%" + txtICD10.Text.Trim() + "%'";
                }
                else if (txtNumber.Text.Trim() != "" && txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Case_hispital + "  where   病案号   like'%" + txtNumber.Text.Trim() + "%' and  姓名   like'%" + txtName.Text.Trim() + "%' and  疾病分类代码  like'%" + txtICD10.Text.Trim() + "%' and 手术分类代码  like'%" + txtICD9.Text.Trim() + "%'";
                }
                else if (txtNumber.Text.Trim() != "" && txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "" && txtBorrow_People.Text.Trim() != "")
                {
                    sql = Case_hispital + "  where   病案号  like'%" + txtNumber.Text.Trim() + "%' and  姓名  like'%" + txtName.Text.Trim() + "%' and  疾病分类代码  like'%" + txtICD10.Text.Trim() + "%' and 手术分类代码 like'%" + txtICD9.Text.Trim() + "%' and  借阅人  like'%" + txtBorrow_People.Text.Trim() + "%'";
                }
                #endregion

                #region 姓名不为空
                else if (txtName.Text.Trim() != "")
                {
                    sql = Case_hispital + "  where  姓名 like'%" + txtName.Text.Trim() + "%'";
                }
                else if (txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "")
                {
                    sql = Case_hispital + "  where  姓名  like'%" + txtName.Text.Trim() + "%' and  疾病分类代码  like'%" + txtICD10.Text.Trim() + "%'";
                }
                else if (txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Case_hispital + "  where  姓名  like'%" + txtName.Text.Trim() + "%' and  疾病分类代码  like'%" + txtICD10.Text.Trim() + "%' and 手术分类代码  like'%" + txtICD9.Text.Trim() + "%'";
                }
                else if (txtName.Text.Trim() != "" && txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "" && txtBorrow_People.Text.Trim() != "")
                {
                    sql = Case_hispital + "  where  姓名  like'%" + txtName.Text.Trim() + "%' and  疾病分类代码   like'%" + txtICD10.Text.Trim() + "%' and 手术分类代码  like'%" + txtICD9.Text.Trim() + "%'and 借阅人  like'%" + txtBorrow_People.Text.Trim() + "%'";
                }
                #endregion

                #region  疾病分类代码不为空
                else if (txtICD10.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 疾病分类代码 like'%" + txtICD10.Text.Trim() + "%'";
                }
                else if (txtICD10.Text.Trim() != "" && txtNumber.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 疾病分类代码 like'%" + txtICD10.Text.Trim() + "%' and  病案号  like'%" + txtNumber.Text.Trim() + "%'";
                }
                else if (txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 疾病分类代码  like'%" + txtICD10.Text.Trim() + "%' and  手术分类代码  like'%" + txtICD9.Text.Trim() + "%'";
                }
                else if (txtICD10.Text.Trim() != "" && txtICD9.Text.Trim() != "" && txtBorrow_People.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 疾病分类代码  like'%" + txtICD10.Text.Trim() + "%' and  手术分类代码  like'%" + txtICD9.Text.Trim() + "%' and 借阅人  like'%" + txtBorrow_People.Text.Trim() + "%'";
                }
                #endregion

                #region 手术分类代码不为空
                else if (txtICD9.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 手术分类代码  like'%" + txtICD9.Text.Trim() + "%'";
                }
                else if (txtICD9.Text.Trim() != "" && txtNumber.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 手术分类代码  like'%" + txtICD9.Text.Trim() + "%' and  病案号  like'%" + txtNumber.Text.Trim() + "%'";
                }
                else if (txtICD9.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 手术分类代码  like'%" + txtICD9.Text.Trim() + "%' and  姓名  like'%" + txtName.Text.Trim() + "%'";
                }
                else if (txtICD9.Text.Trim() != "" && txtName.Text.Trim() != "" && txtBorrow_People.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 手术分类代码 like'%" + txtICD9.Text.Trim() + "%' and  姓名  like'%" + txtName.Text.Trim() + "%'  and  借阅人  like'%" + txtBorrow_People.Text.Trim() + "%'";
                }
                #endregion

                #region  借阅人不为空
                else if (txtBorrow_People.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 借阅人  like'%" + txtBorrow_People.Text.Trim() + "%'";
                }
                else if (txtBorrow_People.Text.Trim() != "" && txtNumber.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 借阅人  like'%" + txtBorrow_People.Text.Trim() + "%' and 病案号  like'%" + txtNumber.Text.Trim() + "%'";
                }
                else if (txtBorrow_People.Text.Trim() != "" && txtName.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 借阅人  like'%" + txtBorrow_People.Text.Trim() + "%' and 姓名  like'%" + txtName.Text.Trim() + "%'";
                }
                else if (txtBorrow_People.Text.Trim() != "" && txtICD10.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 借阅人  like'%" + txtBorrow_People.Text.Trim() + "%' and 疾病分类代码  like'%" + txtICD10.Text.Trim() + "%'";
                }
                else if (txtBorrow_People.Text.Trim() != "" && txtICD9.Text.Trim() != "")
                {
                    sql = Case_hispital + " where 借阅人  like'%" + txtBorrow_People.Text.Trim() + "%' and 手术分类代码  like'%" + txtICD9.Text.Trim() + "%'";
                }
                #endregion
                //查询范围
                else if (chkRange.Checked == true)
                {
                    if (cboInquiry_Range.Text.Trim() != "")
                    {
                        sql = Case_hispital + " where 病案状态='" + cboInquiry_Range.SelectedValue + "' ";
                    }
                }
                //借阅科室查询
                else if (chkBorrowSection.Checked == true)
                {
                    if (cboBorrow_Section.Text.Trim() != "")
                    {
                        sql = Case_hispital + " where 借阅科室='" + cboBorrow_Section.SelectedValue + "' ";
                    }
                }
                #region 时间都不为空
                else if (chkHospitalTime.Checked == true)
                {
                    if (Start_Admission != "" && End_Admission != "")
                    {
                        if (dtpEnd_Admission.Value < dtpStart_Admission.Value)
                        {
                            App.Msg("入院结束日期不能小于入院起始日期！");
                            dtpEnd_Admission.Focus();
                            return;
                        }
                        sql = Case_hispital + " where  入院日期 between  '" + Start_Admission + "'  and  '" + End_Admission + "'";
                    }
                }
                else if (chkToHospitalTime.Checked == true)
                {
                    if (Start_Tohospital != "" && End_Tohospital != "")
                    {
                        if (dtpEnd_Tohospital.Value < dtpStart_Tohospital.Value)
                        {
                            App.Msg("出院结束日期不能小于出院起始日期！");
                            dtpEnd_Tohospital.Focus();
                            return;
                        }
                        sql = Case_hispital + " where   出院日期  between  '" + Start_Tohospital + "' and  '" + End_Tohospital + "'";
                    }
                }
                else if (chkBorrowTime.Checked == true)
                {
                    if (StartBorrow_Time != "" && EndBorrow_Time != "")
                    {
                        if (dtpEndBorrow_Time.Value < dtpStartBorrow_Time.Value)
                        {
                            App.Msg("出院结束日期不能小于出院起始日期！");
                            dtpEndBorrow_Time.Focus();
                            return;
                        }
                        sql = Case_hispital + " where  借阅日期 between  '" + StartBorrow_Time + "' and  '" + EndBorrow_Time + "'";
                    }
                }
                else if (chkHospitalTime.Checked == true && chkBorrowTime.Checked == true && chkBorrowTime.Checked == true)
                {
                    if (Start_Admission != "" && End_Admission != "" && Start_Tohospital != "" && End_Tohospital != "" && StartBorrow_Time != "" && EndBorrow_Time != "")
                    {
                        if (dtpEnd_Admission.Value < dtpStart_Admission.Value)
                        {
                            App.Msg("入院结束日期不能小于入院起始日期！");
                            dtpEnd_Admission.Focus();
                            return;
                        }
                        if (dtpEnd_Tohospital.Value < dtpStart_Tohospital.Value)
                        {
                            App.Msg("出院结束日期不能小于出院起始日期！");
                            dtpEnd_Tohospital.Focus();
                            return;
                        }
                        if (dtpEndBorrow_Time.Value < dtpStartBorrow_Time.Value)
                        {
                            App.Msg("出院结束日期不能小于出院起始日期！");
                            dtpEndBorrow_Time.Focus();
                            return;
                        }
                        sql = Case_hispital + " where  入院日期 between  '" + Start_Admission + "'  and  '" + End_Admission + "'  and  出院日期  between  '" + Start_Tohospital + "'  and   '" + End_Tohospital + "'  and  借阅日期 between  '" + StartBorrow_Time + "'  and  '" + EndBorrow_Time + "'";
                    }
                }
                #endregion

                #region 绑定数据
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        //获得时间设置的参数
                        int set_datatemp = param_shezhi();
                        string unit = "";
                        //根据时间设置的参数获得时间单位
                        unit = Hospital_time(set_datatemp.ToString());

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            flgView.fg.Rows.Add();
                            Class_CaseHospital temp = new Class_CaseHospital();
                            if (dt.Rows[i]["借阅日期"].ToString() != null)
                                temp.Borrow_date = Convert.ToDateTime(dt.Rows[i]["借阅日期"].ToString()).ToString("yyyy-MM-dd");
                            if (dt.Rows[i]["借阅人"].ToString() != null)
                                temp.Borrow_people = dt.Rows[i]["借阅人"].ToString();
                            if (dt.Rows[i]["借阅科室"].ToString() != null)
                                temp.Borrow_section = dt.Rows[i]["借阅科室"].ToString();
                            if (dt.Rows[i]["查询内容"].ToString() != null)
                                temp.Content_query = dt.Rows[i]["查询内容"].ToString();
                            if (dt.Rows[i]["归还日期"].ToString() != null)
                                temp.Return_date = dt.Rows[i]["归还日期"].ToString();
                            if (dt.Rows[i]["计划归还日期"].ToString() != null)
                            {
                                // 201:天  202:小时  203:分钟
                                if (unit == "201")
                                {
                                    temp.Plan_returndate = Convert.ToDateTime(dt.Rows[i]["计划归还日期"].ToString()).AddDays(set_datatemp).ToString("yyyy-MM-dd");
                                }
                                if (unit == "202")
                                {
                                    temp.Plan_returndate = Convert.ToDateTime(dt.Rows[i]["计划归还日期"].ToString()).AddHours(set_datatemp).ToString("yyyy-MM-dd");

                                }
                                if (unit == "203")
                                {
                                    temp.Plan_returndate = Convert.ToDateTime(dt.Rows[i]["计划归还日期"].ToString()).AddMinutes(set_datatemp).ToString("yyyy-MM-dd");

                                }
                            }
                            if (dt.Rows[i]["病案号"].ToString() != null)
                                temp.Case_number = dt.Rows[i]["病案号"].ToString();
                            if (dt.Rows[i]["姓名"].ToString() != null)
                                temp.Name = dt.Rows[i]["姓名"].ToString();
                            if (dt.Rows[i]["年龄"].ToString() != null)
                                temp.Age = dt.Rows[i]["年龄"].ToString();
                            if (dt.Rows[i]["入院日期"].ToString() != null)
                                temp.Admission_date = dt.Rows[i]["入院日期"].ToString();
                            if (dt.Rows[i]["出院主诊断"].ToString() != null)
                                temp.To_hospital_diagnosis = dt.Rows[i]["出院主诊断"].ToString();
                            if (dt.Rows[i]["出院科别"].ToString() != null)
                                temp.To_hospital_section = dt.Rows[i]["出院科别"].ToString();
                            if (dt.Rows[i]["费别"].ToString() != null)
                                temp.Hospital_fee = dt.Rows[i]["费别"].ToString();
                            if (dt.Rows[i]["出院日期"].ToString() != null)
                                temp.To_hospital_date = dt.Rows[i]["出院日期"].ToString();
                            if (dt.Rows[i]["疾病分类代码"].ToString() != null)
                                temp.Icd10 = dt.Rows[i]["疾病分类代码"].ToString();
                            if (dt.Rows[i]["手术分类代码"].ToString() != null)
                                temp.Icd9 = dt.Rows[i]["手术分类代码"].ToString();
                            if (dt.Rows[i]["病案状态"].ToString() != null)
                                temp.State = dt.Rows[i]["病案状态"].ToString();

                            flgView.fg[1 + i, 1] = temp.Borrow_date;
                            flgView.fg[1 + i, 2] = temp.Borrow_people;
                            flgView.fg[1 + i, 3] = temp.Borrow_section;
                            flgView.fg[1 + i, 4] = temp.Content_query;
                            //flgView.fg[1 + i, 5] = temp.Return_date;
                            if (temp.Return_date != null)
                            {
                                if (temp.Return_date != temp.Plan_returndate)
                                {
                                    flgView.fg[1 + i, 5] = " 超期 " + temp.Return_date;
                                }
                                else
                                {
                                    flgView.fg[1 + i, 5] = "      " + temp.Return_date;
                                }
                            }
                            else
                            {
                                flgView.fg[1 + i, 5] = " 超期未归还 ";
                            }

                            flgView.fg[1 + i, 6] = temp.Plan_returndate;

                            flgView.fg[1 + i, 7] = temp.Case_number;
                            flgView.fg[1 + i, 8] = temp.Name;
                            flgView.fg[1 + i, 9] = temp.Age;
                            flgView.fg[1 + i, 10] = temp.Admission_date;
                            flgView.fg[1 + i, 11] = temp.To_hospital_diagnosis;
                            flgView.fg[1 + i, 12] = temp.To_hospital_section;
                            flgView.fg[1 + i, 13] = temp.Hospital_fee;
                            flgView.fg[1 + i, 14] = temp.To_hospital_date;
                            flgView.fg[1 + i, 15] = temp.Icd10;
                            flgView.fg[1 + i, 16] = temp.Icd9;
                            flgView.fg[1 + i, 17] = temp.State;

                        }

                    }
                    CellUnit();
                }
                else
                {
                    App.Msg("没有找到查询结果");
                }
                #endregion
            }
            catch (Exception ee)
            {
            }
  

        }
        /// <summary>
        /// 获取时间设置的参数
        /// </summary>
        /// <returns></returns>
        private int param_shezhi()
        {
            string sql = @"select SET_DATETIME,DATETIME_YN,YUANWAI_DA,SET_YUANWAI_DATETIME from T_GRADE_PARAM_SHEZHI a "+
                @"inner join t_data_code b on b.id=a.datetime_yn " +
                @"inner join t_data_code c on c.id=a.set_yuanwai_datetime";
            DataSet ds = App.GetDataSet(sql);
            int  datatemp = 0;
            if (ds != null)
            {
                DataTable dt=ds.Tables[0];
                if (dt != null)
                {
                    Class_Hospital_GradeParam graTemp = new Class_Hospital_GradeParam();
                    graTemp.Hospital_datetime = dt.Rows[0]["SET_DATETIME"].ToString();
                    graTemp.Hospital_datetime_unit = dt.Rows[0]["DATETIME_YN"].ToString();
                    graTemp.Outside_hospital_datetime = dt.Rows[0]["YUANWAI_DA"].ToString();
                    graTemp.Outside_hospital_datetime_unit = dt.Rows[0]["SET_YUANWAI_DATETIME"].ToString();
                    datatemp =Convert.ToInt32(graTemp.Hospital_datetime);
                }

            }

            return datatemp;
            #region
            //DataTable dt = ds.Tables[0];
            //int datatemp = 0;
            //object o = null;
            //o["set_datetime"] = dt.Rows[0]["SET_DATETIME"];
            //o["datetime_ye"] = dt.Rows[0]["DATETIME_YN"];
            //if (o["datetime_ye"] == "天")
            //{
            //    datatemp = (int)o["set_datetime"];
            //}
            #endregion
        }
        /// <summary>
        /// 根据时间设置的参数获取时间单位
        /// </summary>
        /// <param name="strTime"></param>
        /// <returns></returns>
        private string Hospital_time(string strTime)
        {
            string sql = "select DATETIME_YN  from  T_GRADE_PARAM_SHEZHI where SET_DATETIME='" + strTime + "'";
            string Hospital_uint = App.ReadSqlVal(sql, 0, "DATETIME_YN");
            return Hospital_uint;
        }
        /// <summary>
        /// 入院时间控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkHospitalTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHospitalTime.Checked == true)
            {
                dtpStart_Admission.Enabled = true;
                lblAdmission.Enabled = true;
                dtpEnd_Admission.Enabled = true;
            }
            else
            {
                dtpStart_Admission.Enabled = false;
                lblAdmission.Enabled = false;
                dtpEnd_Admission.Enabled = false;
            }
        }
        /// <summary>
        /// 出院时间控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkToHospitalTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkToHospitalTime.Checked == true)
            {
                dtpStart_Tohospital.Enabled = true;
                lblToHospital.Enabled = true;
                dtpEnd_Tohospital.Enabled = true;
            }
            else
            {
                dtpStart_Tohospital.Enabled = false;
                lblToHospital.Enabled = false;
                dtpEnd_Tohospital.Enabled = false;
            }
        }
        /// <summary>
        /// 借阅时间控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBorrowTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBorrowTime.Checked == true)
            {
                dtpStartBorrow_Time.Enabled = true;
                lblBorrow.Enabled = true;
                dtpEndBorrow_Time.Enabled = true;
            }
            else
            {
                dtpStartBorrow_Time.Enabled = false;
                lblBorrow.Enabled = false;
                dtpEndBorrow_Time.Enabled = false;
            }
        }
        /// <summary>
        /// 科室控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkBorrowSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBorrowSection.Checked == true)
            {
                cboBorrow_Section.Enabled = true;
            }
            else
            {
                cboBorrow_Section.Enabled = false;
            }
        }
        /// <summary>
        /// 查询范围控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRange.Checked == true)
            {
                cboInquiry_Range.Enabled = true;
            }
            else
            {
                cboInquiry_Range.Enabled = false;
            }
        }

    }
}
