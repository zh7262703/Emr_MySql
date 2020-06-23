using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
using Base_Function.MODEL;

namespace Base_Function.BLL_NURSE.Odinopoeia_Record
{
    public partial class UOdinopoeia_Record : UserControl
    {
        bool isSave = false;//用于存放当前的操作状态 true为添加操作 false为修改操作
        ColumnInfo[] cols = new ColumnInfo[13];
        private string ID = "";//自动增长ID
        string sql_MATERNITY = "";//查询中期妊娠引产产后病程一般纪录
        private string PID = "";//住院号
        private string Pidname = "";//名字
        private string SickName = "";//病区
        private string Bed = "";//床号
        private string PID_IDS = "";//病人ID
        ArrayList List = new ArrayList();
        public UOdinopoeia_Record()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 中期妊娠引产产后病程一般纪录初始化
        /// </summary>
        /// <param name="pid">住院号</param>
        /// <param name="sickname">病区</param>
        /// <param name="bed">床号</param>
        /// <param name="name">病人名字</param>
        /// <param name="pids_id">住院号</param>
        public UOdinopoeia_Record(string pid, string sickname, string bed, string name, string pids_id)
        {
            try
            {
                InitializeComponent();
                PID = pid;
                Pidname = name;
                SickName = sickname;
                Bed = bed;
                PID_IDS = pids_id;
            }
            catch
            {
            }
        }
        private void UOdinopoeia_Record_Load(object sender, EventArgs e)
        {
            try
            {
                 ShowDate();
                 flgView.Click += new EventHandler(flgView_Click);
                RefleshFrm();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        private void CellUnit()
        {
            //单元格合并和设置         
            flgView[1, 0] = "日期";
            flgView[1, 1] = "宫底";
            flgView[1, 2] = "压痛";
            flgView[1, 3] = "乳胀";
            flgView[1, 4] = "量";
            flgView[1, 5] = "色";
            flgView[1, 6] = "味";
            flgView[1, 7] = "会阴情况";
            flgView[1, 8] = "备注";
            flgView[1, 9] = "签名";
            flgView[1, 10] = "编号";
            flgView[1, 11] = "病人主键";
            flgView[1, 12] = "时间";
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 1, 0);
            cr.Data = "日期";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 1, 1);
            cr.Data = "宫底";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 1, 2);
            cr.Data = "压痛";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 1, 3);
            cr.Data = "乳胀";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 4, 0, 6);
            cr.Data = "恶露";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 4, 1, 4);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 5, 1, 5);
            cr.Data = "色";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 6, 1, 6);
            cr.Data = "味";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 7, 1, 7);
            cr.Data = "会阴情况";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(0, 8, 1,8);
            cr.Data = "备注";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(0, 9, 1, 9);
            cr.Data = "签名";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(0, 10, 1, 10);
            cr.Data = "编号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(0, 11, 1, 11);
            cr.Data = "病人主键";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(0, 12, 1, 12);
            cr.Data = "时间";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
           
            for (int i = 0; i < flgView.Cols.Count; i++)
            {
                if (i == 7)
                {
                    flgView.Cols[i].Width = 80;
                }
                else if (i == 8)
                {
                    flgView.Cols[i].Width = 100;
                }
                else
                {

                    flgView.Cols[i].Width = 60;
                }
               
            }

            for (int i = 0; i < flgView.Rows.Count; i++)
            {
                flgView.Rows[i].Height = 25;
            }
            //把编号、病人主键隐藏
            flgView.Cols[11].Visible = false;
            flgView.Cols[11].AllowEditing = false;

            flgView.Cols[12].Visible = false;
            flgView.Cols[12].AllowEditing = false;
            flgView.Cols[10].Visible = false;
            flgView.Cols[10].AllowEditing = false;

            //居中显示
            flgView.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[6].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[7].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[8].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[9].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[10].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[11].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[12].TextAlign = TextAlignEnum.CenterCenter;

        }
        /// <summary>
        /// 表头设置
        /// </summary>
        private void SetTable()
        {
            //单元格合并和设置           
            flgView.Cols.Count = 13;
            flgView.Cols.Fixed = 0;
            flgView.Rows.Count = 2;
            flgView.Rows.Fixed = 2;


        }
        /// <summary>
        /// 显示数据
        /// </summary>
        private void ShowDate()
        {
            try
            {
                List.Clear();
                SetTable();
                sql_MATERNITY = @"select ID as 编号,PATIENT_ID as 病人主键,to_char(RECORD_DATE,'yyyy-MM-dd') as 日期,"+
                            @" PALACE_BOTTOM as 宫底,TENDERNESS as 压痛,YOUNG_BULGE as 乳胀,LOCHIA_VOLUEM as 量,"+
                            @" LOCHIA_COLOR as 色,LOCHIA_TASTE as 味,PERINEUM_SITUATION as 会阴情况,NOTE as 备注, "+
                            @" SIGNATURE as 签字,to_char(RECORD_DATE,'HH24:mi') as 时间 from T_MEDIATE_PREGNANCY_RECORD where  PATIENT_ID='" + PID_IDS + "'";
                DataSet ds = App.GetDataSet(sql_MATERNITY);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            flgView.Rows.Add();
                            Class__T_MEDIATE_PREGNANCY_RECORD temp = new Class__T_MEDIATE_PREGNANCY_RECORD();
                            temp.Id = ds.Tables[0].Rows[i]["编号"].ToString();
                            temp .Pid_ids= ds.Tables[0].Rows[i]["病人主键"].ToString();
                            temp.Data = ds.Tables[0].Rows[i]["日期"].ToString();
                            temp.Palace_bottom = ds.Tables[0].Rows[i]["宫底"].ToString();
                            temp.Tenderness = ds.Tables[0].Rows[i]["压痛"].ToString();
                            temp.Young_bulge = ds.Tables[0].Rows[i]["乳胀"].ToString();
                            temp.Lochia_voluem = ds.Tables[0].Rows[i]["量"].ToString();
                            temp.Lochia_color = ds.Tables[0].Rows[i]["色"].ToString();
                            temp.Lochia_taste = ds.Tables[0].Rows[i]["味"].ToString();
                            temp.Perineum_situation = ds.Tables[0].Rows[i]["会阴情况"].ToString();
                            temp.Note = ds.Tables[0].Rows[i]["备注"].ToString();
                            temp.Signature = ds.Tables[0].Rows[i]["签字"].ToString();
                            temp.Time = ds.Tables[0].Rows[i]["时间"].ToString();
                           
                           
                            flgView[2 + i, 0] = temp.Data;
                            flgView[2 + i, 1] = isExNot(temp.Palace_bottom);
                            flgView[2 + i, 2] = isExNot(temp.Tenderness);
                            flgView[2 + i, 3] = isExNot(temp.Young_bulge);
                            flgView[2 + i, 4] = isExNot(temp.Lochia_voluem);
                            flgView[2 + i, 5] = isExNot(temp.Lochia_color);
                            flgView[2 + i, 6] = isExNot(temp.Lochia_taste);
                            flgView[2 + i, 7] = isExNot(temp.Perineum_situation);
                            flgView[2 + i, 8] = isExNot(temp.Note);
                            flgView[2 + i, 9] = isExNot(temp.Signature);
                            flgView[2 + i, 10] = isExNot(temp.Id);
                            flgView[2 + i, 11] = isExNot(temp.Pid_ids);
                            flgView[2 + i, 12] = temp.Time;
                            List.Add(temp);
                        }
                    }
                }
                CellUnit();
            }
            catch
            {

            }
        }
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
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {
            dtpTime.Enabled = false;
            txtFundus.Enabled = false;
            txtTenderness.Enabled = false;
            txtYoung_bulge.Enabled = false;
            txtCount.Enabled = false;
            txtColor.Enabled = false;
            txtTaste.Enabled = false;
            rchBOX.Enabled = false;
            rTBRecord.Enabled = false;
            txtAutograph.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false; ;
            btnCancel.Enabled = false;
            flgView.Enabled = true;
            isSave = false;


        }
        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtFundus.Text = "";
                txtTenderness.Text = "";
                txtYoung_bulge.Text = "";
                txtCount.Text = "";
                txtColor.Text = "";
                txtTaste.Text = "";
                rchBOX.Text = "";
                rTBRecord.Text = "";
                txtAutograph.Text = "";

            }
            dtpTime.Enabled = true;
            txtFundus.Enabled = true;
            txtTenderness.Enabled = true;
            txtYoung_bulge.Enabled = true;
            txtCount.Enabled = true;
            txtColor.Enabled = true;
            txtTaste.Enabled = true;
            rchBOX.Enabled = true;
            rTBRecord.Enabled = true;
            txtAutograph.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            flgView.Enabled = false;
            dtpTime.Focus();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            Edit(isSave);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            Edit(isSave);
        }
     
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                string sql = "";
                ID = App.GenId("T_MEDIATE_PREGNANCY_RECORD", "ID").ToString();
                string datetime = dtpTime.Value.ToString("yyyy-MM-dd HH:MM");
                if (isSave)
                {
                    sql = "insert into T_MEDIATE_PREGNANCY_RECORD(ID,PATIENT_ID,RECORD_DATE,PALACE_BOTTOM,TENDERNESS,YOUNG_BULGE,LOCHIA_VOLUEM,LOCHIA_COLOR,LOCHIA_TASTE,PERINEUM_SITUATION,NOTE,SIGNATURE) values("
                          + ID + ",'"
                          + PID_IDS + "',to_timestamp('"
                          + datetime + "','syyyy-mm-dd hh24:mi'),'"
                          + txtFundus.Text + "','"
                          + txtTenderness.Text + "','"
                          + txtYoung_bulge.Text + "','"
                          + txtCount.Text + "','"
                          + txtColor.Text + "','"
                          + txtTaste.Text + "','"
                          + rchBOX.Text + "','"
                          + rTBRecord.Text + "','"
                          + txtAutograph.Text + "')";
                    btnAdd_Click(sender, e);
                }
                else
                {
                    sql = "update T_MEDIATE_PREGNANCY_RECORD set PALACE_BOTTOM='"
                      + txtFundus.Text + "',TENDERNESS='"
                      + txtTenderness.Text + "',YOUNG_BULGE='"
                      + txtYoung_bulge.Text + "',LOCHIA_VOLUEM='"
                      + txtCount.Text + "',LOCHIA_COLOR='"
                      + txtColor.Text + "',LOCHIA_TASTE='"
                      + txtTaste.Text + "',PERINEUM_SITUATION='"
                      + rchBOX.Text + "',NOTE='"
                      + rTBRecord.Text + "',SIGNATURE='"
                      + txtAutograph.Text + "',RECORD_DATE=to_timestamp('"
                      + datetime + "','syyyy-mm-dd hh24:mi')  where PATIENT_ID=" + PID_IDS + " and ID='" + flgView[flgView.RowSel, 10].ToString() + "'";
                    btnUpdate_Click(sender, e);
                }
                if (sql != "")
                {
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("保存成功！");
                        ShowDate();
                        btnCancel_Click(sender, e);
                    }

                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            RefleshFrms();
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrms()
        {

            txtFundus.Text = "";
            txtTenderness.Text = "";
            txtYoung_bulge.Text = "";
            txtCount.Text = "";
            txtColor.Text = "";
            txtTaste.Text = "";
            rchBOX.Text = "";
            rTBRecord.Text = "";
            txtAutograph.Text = "";
            dtpTime.Enabled = false;
            txtFundus.Enabled = false;
            txtTenderness.Enabled = false;
            txtYoung_bulge.Enabled = false;
            txtCount.Enabled = false;
            txtColor.Enabled = false;
            txtTaste.Enabled = false;
            rchBOX.Enabled = false;
            rTBRecord.Enabled = false;
            txtAutograph.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false; ;
            btnCancel.Enabled = false;
            flgView.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false; ;
            btnCancel.Enabled = false;
            isSave = false;


        }
        int Rowcount = 0;
        private void flgView_Click(object sender, EventArgs e)
        {
            try
            {
                int index = flgView.RowSel;
                if (flgView.RowSel >1)
                {
                    ID = flgView[flgView.RowSel, 10].ToString();
                    txtFundus.Text = flgView[flgView.RowSel, 1].ToString();
                    txtTenderness.Text = flgView[flgView.RowSel, 2].ToString();
                    txtYoung_bulge.Text = flgView[flgView.RowSel, 3].ToString();
                    txtCount.Text = flgView[flgView.RowSel,4].ToString();
                    txtColor.Text = flgView[flgView.RowSel, 5].ToString();
                    txtTaste.Text = flgView[flgView.RowSel, 6].ToString();
                    rchBOX.Text = flgView[flgView.RowSel, 7].ToString();
                    rTBRecord.Text = flgView[flgView.RowSel,8].ToString();
                    txtAutograph.Text = flgView[flgView.RowSel, 9].ToString();
                    string time = flgView[flgView.RowSel, 0].ToString() + " " + flgView[flgView.RowSel, 12].ToString();
                    dtpTime.Value = Convert.ToDateTime(time);
                    int rows = this.flgView.RowSel;//定义选中的行号 
                    //if (rows > 0)
                    //{
                    //    if (Rowcount == rows)
                    //    {
                    //        this.flgView.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //    }
                    //    else
                    //    {
                    //        //如果不是头行
                    //        if (rows > 2)
                    //        {
                    //            //就改变背景色
                    //            this.flgView.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //        }
                    //        int count = flgView.Rows.Count;
                    //        if (Rowcount > 0)
                    //        {
                    //            //if (Rowcount < count - 2)
                    //            //{
                    //                //定义上一次点击过的行还原
                    //                this.flgView.Rows[Rowcount].StyleNew.BackColor = flgView.BackColor;
                    //            //}
                    //        }
                    //    }
                    //}
                    //给上一次的行号赋值
                   // Rowcount = rows;
                }
                //RefleshFrm();
            }
            catch
            {
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flgView.RowSel > 1)
            {
                if (App.Ask("你是否要删除"))
                {
                    string sql = "delete from  T_MEDIATE_PREGNANCY_RECORD  where  ID='" + flgView[flgView.RowSel, 10].ToString() + "' and PATIENT_ID=" + PID_IDS + "";
                    App.ExecuteSQL(sql);
                    //ShowDate();
                    dtpDate_ValueChanged(sender,e);
                    btnCancel_Click(sender, e);
                }
            }
        }

        private void dtpTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFundus.Focus();
            }
        }

        private void txtFundus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTenderness.Focus();
            }
        }

        private void txtTenderness_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtYoung_bulge.Focus();
            }
        }

        private void txtYoung_bulge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCount.Focus();
            }
        }

        private void txtCount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtColor.Focus();
            }
        }

        private void txtColor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTaste.Focus();
            }
        }

        private void txtTaste_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rchBOX.Focus();
            }
        }

        private void rchBOX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rTBRecord.Focus();
            }
        }

        private void rTBRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtAutograph.Focus();
            }
        }

        private void txtAutograph_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender,e);
            }
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPaint_Click(object sender, EventArgs e)
        {
            Class__T_MEDIATE_PREGNANCY_RECORD[] class_obgs = new Class__T_MEDIATE_PREGNANCY_RECORD[List.Count];
            for (int i = 0; i < List.Count; i++)
            {
                class_obgs[i] = new Class__T_MEDIATE_PREGNANCY_RECORD();
                class_obgs[i] = (Class__T_MEDIATE_PREGNANCY_RECORD)List[i];
            }
            frmOdinopeio_Paint fx = new frmOdinopeio_Paint(App.ObjectArrayToDataSet(class_obgs), Pidname, SickName, Bed, PID);
            fx.Show();
        }

        /// <summary>
        /// 根据时间查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                string dateStart = dtpDate.Value.ToString("yyyy-MM-dd");
                lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
                lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
                    SetTable();
                    sql_MATERNITY = @"select ID as 编号,PATIENT_ID as 病人主键,to_char(RECORD_DATE,'yyyy-MM-dd') as 日期," +
                                @" PALACE_BOTTOM as 宫底,TENDERNESS as 压痛,YOUNG_BULGE as 乳胀,LOCHIA_VOLUEM as 量," +
                                @" LOCHIA_COLOR as 色,LOCHIA_TASTE as 味,PERINEUM_SITUATION as 会阴情况,NOTE as 备注, " +
                                @" SIGNATURE as 签字,to_char(RECORD_DATE,'HH24:mi') as 时间 from T_MEDIATE_PREGNANCY_RECORD where  to_char(RECORD_DATE,'yyyy-MM-dd')='" + dateStart + "'  and  PATIENT_ID='" + PID_IDS + "'";
                    DataSet ds = App.GetDataSet(sql_MATERNITY);
                    if (ds != null)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                flgView.Rows.Add();
                                Class__T_MEDIATE_PREGNANCY_RECORD temp = new Class__T_MEDIATE_PREGNANCY_RECORD();
                                temp.Id = ds.Tables[0].Rows[i]["编号"].ToString();
                                temp.Pid_ids = ds.Tables[0].Rows[i]["病人主键"].ToString();
                                temp.Data = ds.Tables[0].Rows[i]["日期"].ToString();
                                temp.Palace_bottom = ds.Tables[0].Rows[i]["宫底"].ToString();
                                temp.Tenderness = ds.Tables[0].Rows[i]["压痛"].ToString();
                                temp.Young_bulge = ds.Tables[0].Rows[i]["乳胀"].ToString();
                                temp.Lochia_voluem = ds.Tables[0].Rows[i]["量"].ToString();
                                temp.Lochia_color = ds.Tables[0].Rows[i]["色"].ToString();
                                temp.Lochia_taste = ds.Tables[0].Rows[i]["味"].ToString();
                                temp.Perineum_situation = ds.Tables[0].Rows[i]["会阴情况"].ToString();
                                temp.Note = ds.Tables[0].Rows[i]["备注"].ToString();
                                temp.Signature = ds.Tables[0].Rows[i]["签字"].ToString();
                                temp.Time = ds.Tables[0].Rows[i]["时间"].ToString();


                                flgView[2 + i, 0] = temp.Data;
                                flgView[2 + i, 1] = isExNot(temp.Palace_bottom);
                                flgView[2 + i, 2] = isExNot(temp.Tenderness);
                                flgView[2 + i, 3] = isExNot(temp.Young_bulge);
                                flgView[2 + i, 4] = isExNot(temp.Lochia_voluem);
                                flgView[2 + i, 5] = isExNot(temp.Lochia_color);
                                flgView[2 + i, 6] = isExNot(temp.Lochia_taste);
                                flgView[2 + i, 7] = isExNot(temp.Perineum_situation);
                                flgView[2 + i, 8] = isExNot(temp.Note);
                                flgView[2 + i, 9] = isExNot(temp.Signature);
                                flgView[2 + i, 10] = isExNot(temp.Id);
                                flgView[2 + i, 11] = isExNot(temp.Pid_ids);
                                flgView[2 + i, 12] = temp.Time;

                            }
                        }
                    }
                    CellUnit();
              
            }
            catch
            {

            }
        }
        /// <summary>
        /// 上一天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDatePriview_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(-1));
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            dtpDate_ValueChanged(sender, e);
        }
        /// <summary>
        /// 下一天
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDateNext_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(1));
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            dtpDate_ValueChanged(sender, e);
        }



    }
}
