using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
using System.Collections;
using Base_Function.MODEL;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    public partial class UcReportcard_management : UserControl
    {
        ColumnInfo[] cols = new ColumnInfo[11];
        /// <summary>
        /// 归档状态
        /// </summary>
        private bool boolFlag = false;
        public UcReportcard_management()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcReportcard_management_Load(object sender, EventArgs e)
        {
            try
            {
                Section();

                if (chkKS.Checked == true)
                {
                    cboSection.Enabled = true;
                    chkRY_Time.Checked = false;
                }
                else
                {
                    cboSection.Enabled = false;
                }
                if (chkRY_Time.Checked == true)
                {
                    dtpStartTime.Enabled = true;
                    dtpEndTime.Enabled = true;
                    chkKS.Checked = false;
                }
                else
                {
                    dtpStartTime.Enabled = false;
                    dtpEndTime.Enabled = false;
                }
                //flgView.DoubleClick += new EventHandler(flgView_DoubleClick);
            }
            catch
            { }
        }
        /// <summary>
        /// 显示科室
        /// </summary>
        private void Section()
        {
            DataSet dt = App.GetDataSet("select * from T_SECTIONINFO where ENABLE_FLAG='Y'");
            cboSection.DataSource = dt.Tables[0].DefaultView;
            cboSection.ValueMember = "SID";
            cboSection.DisplayMember = "SECTION_NAME";
        }
        /// <summary>
        /// 表头设置
        /// </summary>
        private void SetTable()
        {
            flgView.Cols.Count = 11;
            flgView.Cols.Fixed = 0;
            flgView.Rows.Count = 1;
            flgView.Rows.Fixed = 1;
        }
        /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        private void CellUnit()
        {

            #region
            //单元格合并和设置 
            flgView[0, 0] = "";
            flgView[0, 1] = "住院号";
            flgView[0, 2] = "姓名";
            flgView[0, 3] = "当前科室";
            flgView[0, 4] = "管床医生";
            flgView[0, 5] = "入院日期";
            flgView[0, 6] = "入院诊断";
            flgView[0, 7] = "院感报卡";
            flgView[0, 8] = "传染病报卡";
            flgView[0, 9] = "归档状态";
            flgView[0, 10] = "病人ID";

            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;
            //合并单元格
            C1.Win.C1FlexGrid.CellRange cr;

            cr = flgView.GetCellRange(0, 0, 0, 0);
            cr.Data = "";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 0, 1);
            cr.Data = "住院号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 0, 2);
            cr.Data = "姓名";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 0, 3);
            cr.Data = "当前科室";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 4, 0, 4);
            cr.Data = "管床医生";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 5, 0, 5);
            cr.Data = "入院日期";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 6, 0, 6);
            cr.Data = "入院诊断";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 7, 0, 7);
            cr.Data = "院感报卡";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 8, 0, 8);
            cr.Data = "传染病报卡";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 9, 0, 9);
            cr.Data = "归档状态";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 10, 0, 10);
            cr.Data = "病人ID";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            flgView.AutoSizeCols();

            for (int i = 1; i < flgView.Rows.Count; i++)
            {
                CellRange rg2 = flgView.GetCellRange(i, 0);
                rg2.StyleNew.DataType = typeof(bool);
            }

            //CellRange rg = flgView.GetCellRange(0, 0);
            //rg.StyleNew.ForeColor = Color.SkyBlue;

            for (int i = 0; i < flgView.Cols.Count; i++)
            {
                if (i == 0)
                {
                    flgView.Cols[i].Width = 30;
                }
                else if (i == 6)
                {
                    flgView.Cols[i].Width = 150;
                }
                else
                {
                    flgView.Cols[i].Width = 100;
                }
                
            }
           
            flgView.Cols[1].AllowEditing = false;
            flgView.Cols[2].AllowEditing = false;
            flgView.Cols[3].AllowEditing = false;
            flgView.Cols[4].AllowEditing = false;
            flgView.Cols[5].AllowEditing = false;
            flgView.Cols[6].AllowEditing = false;
            flgView.Cols[7].AllowEditing = false;
            flgView.Cols[8].AllowEditing = false;
            flgView.Cols[9].AllowEditing = false;
            flgView.Cols[10].AllowEditing = false;
            flgView.Cols[10].Visible = false;
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

            #endregion
        }
        /// <summary>
        /// 查询报卡管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                SetTable();
                string BKsql = "";
                string sql = "select distinct t.patient_id,p.pid,p.patient_name,s.sid,s.section_name,p.sick_doctor_name,to_char(p.in_time,'yyyy-MM-dd HH24:mi') as 入院日期 from t_fecter_report_card t" +
                           @" inner join t_in_patient p on p.id=t.patient_id  inner join t_sectioninfo s on s.sid=t.sid";
                if (chkKS.Checked == true)
                {
                    #region 科室不为空
                    if (cboSection.Text != "")
                    {
                        BKsql =sql+" where s.sid='"+cboSection.SelectedValue+"'";
                        if (cboState.SelectedIndex == 1)//待审核
                        {
                            BKsql = sql + " where s.sid='" + cboSection.SelectedValue + "' and  t.state=0";
                        }
                        else if(cboState.SelectedIndex == 2) //退回科室
                        {
                            BKsql = sql + " where s.sid='" + cboSection.SelectedValue + "' and  t.state=1";
                        }
                        else if (cboState.SelectedIndex == 3)//已归档
                        {
                            BKsql = sql + " where s.sid='" + cboSection.SelectedValue + "' and  t.state=2";
                        }
                    }
                    #endregion

                }
                else if (chkRY_Time.Checked == true)
                {
                    #region 入院时间
                    string startTime = dtpStartTime.Value.ToString("yyyy-MM-dd HH:MM");
                    string EndTime = dtpEndTime.Value.ToString("yyyy-MM-dd HH:MM");
                    if (startTime == EndTime)//当入院日期起始日期等于结束日期
                    {
                        BKsql = sql + " where 入院日期='" + startTime + "'";
                        if (cboState.SelectedIndex == 1)//待审核
                        {
                            BKsql = sql + " where 入院日期='" + startTime + "' and  t.state=0";
                        }
                        else if (cboState.SelectedIndex == 2)//退回科室
                        {
                            BKsql = sql + " where 入院日期='" + startTime + "' and  t.state=1";
                        }
                        else if (cboState.SelectedIndex == 3)//已归档
                        {
                            BKsql = sql + " where 入院日期='" + startTime + "' and  t.state=2";
                        }
                    }
                    else if (Convert.ToDateTime(EndTime)>Convert.ToDateTime(startTime))//当入院日期的结束日期大于起始日期
                    {
                       
                        BKsql = sql + " where  入院日期 between '" + startTime + "' and '" + EndTime + "'";
                        if (cboState.SelectedIndex == 1)//待审核
                        {
                            BKsql = sql + " where t.state=0 and 入院日期 between '" + startTime + "' and '" + EndTime + "'";
                        }
                        else if (cboState.SelectedIndex == 2)//退回科室
                        {
                            BKsql = sql + " where t.state=1 and  入院日期 between '" + startTime + "' and '" + EndTime + "'";
                        }
                        else if (cboState.SelectedIndex == 3)//已归档
                        {
                            BKsql = sql + " where t.state=2  and  入院日期 between '" + startTime + "' and '" + EndTime + "'";
                        }
                    }
                    else  //入院日期的结束日期小于开始日期的话，就提醒
                    {
                        App.Msg("入院的结束日期不能小于起始日期");
                        return;
                    }
                   #endregion
                }
                else
                {
                    #region 归档状态>0
                    if (cboState.SelectedIndex>0)
                    {
                        if (cboState.SelectedIndex == 1)//待审核
                        {
                            BKsql = sql + " where t.state=0";
                        }
                        else if (cboState.SelectedIndex == 2)//退回科室
                        {
                            BKsql = sql + " where t.state=1";
                        }
                        else if (cboState.SelectedIndex == 3)//已归档
                        {
                            BKsql = sql + " where t.state=2";
                        }
                    }
                    #endregion
                }
                DataSet ds = App.GetDataSet(BKsql);
                string Item_sql = "select DIAGNOSE_CODE,DIAGNOSE_NAME,PATIENT_ID  from t_diagnose_item  order by CREATE_TIME ";
                DataSet dsItem = App.GetDataSet(Item_sql);
                string RPsql = "select * from t_fecter_report_card ";
                DataSet dsRp = App.GetDataSet(RPsql);
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count;i++)
                    {
                        flgView.Rows.Add();
                        Class_T_FECTER_REPORT_CARD temp = new Class_T_FECTER_REPORT_CARD();
                        temp.Patient_id = ds.Tables[0].Rows[i]["pid"].ToString();
                        temp.Patient_name = ds.Tables[0].Rows[i]["patient_name"].ToString();
                        temp.In_section = ds.Tables[0].Rows[i]["section_name"].ToString();
                        temp.In_doctor = ds.Tables[0].Rows[i]["sick_doctor_name"].ToString();
                        temp.In_time = ds.Tables[0].Rows[i]["入院日期"].ToString();
                        temp.Id = ds.Tables[0].Rows[i]["patient_id"].ToString();
                        DataRow[] dt = dsItem.Tables[0].Select(" PATIENT_ID='" + temp.Id + "'");
                        if (dt.Length > 0)
                        {
                            temp.In_itemname = dt[0]["DIAGNOSE_NAME"].ToString();
                        }
                        DataRow[] dtRp = dsRp.Tables[0].Select("PATIENT_ID='" + temp.Id + "' and CART_TYPE=0");
                        if (dtRp.Length > 0)
                        {
                            temp.Court_card = 1;
                            if (dtRp[0]["STATE"].ToString() == "0")
                            {
                                temp.State = "待审核";
                            }
                            else if (dtRp[0]["STATE"].ToString() == "1")
                            {
                                temp.State = "已归档";
                            }
                            else if (dtRp[0]["STATE"].ToString() == "2")
                            {
                                temp.State = "退回科室";
                            }
                        }
                        DataRow[] dtRps = dsRp.Tables[0].Select("PATIENT_ID='" + temp.Id + "' and CART_TYPE=1");
                        if (dtRps.Length > 0)
                        {
                            temp.Infect_card = 1;
                            if (dtRps[0]["RESONS"].ToString() != "")
                            {
                                temp.Resons_card = dtRps[0]["RESONS"].ToString();
                            }
                            if (dtRps[0]["STATE"].ToString() == "0")
                            {
                                temp.State = "待审核";
                            }
                            else if (dtRps[0]["STATE"].ToString() == "1")
                            {
                                temp.State = "已归档";
                            }
                            else if (dtRps[0]["STATE"].ToString() == "2")
                            {
                                temp.State = "退回科室";
                            }
                        }
                        flgView[1 + i, 0] = "";
                        flgView[1 + i, 1] = temp.Patient_id;
                        flgView[1 + i, 2] = temp.Patient_name;
                        flgView[1 + i, 3] = temp.In_section;
                        flgView[1 + i, 4] = temp.In_doctor;
                        flgView[1 + i, 5] = temp.In_time;
                        flgView[1 + i, 6] = temp.In_itemname;
                        flgView[1 + i, 7] = temp.Court_card;
                        flgView[1 + i, 8] = temp.Infect_card;
                        flgView[1 + i, 9] = temp.State;
                        flgView[1 + i, 10] = temp.Id;
                    }
                }
                CellUnit();
            }
            catch
            {
            }
        }

        private void chkKS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkKS.Checked == true)
            {
                cboSection.Enabled = true;
                chkRY_Time.Checked = false;
            }
            else
            {
                cboSection.Enabled = false;
            }
    
         
        }

        private void chkRY_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRY_Time.Checked == true)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
                chkKS.Checked =false;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        
        }
        /// <summary>
        /// 判断复选框是否选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_Click(object sender, EventArgs e)
        {
            if (flgView.RowSel > 0)
            {
                if (flgView[flgView.RowSel, 0] == null)
                {
                    return;
                }
                else
                {
                    if (flgView[flgView.RowSel, 0].ToString().ToLower() == "False" || flgView[flgView.RowSel, 0].ToString().ToLower() == "false")
                    {
                        flgView[flgView.RowSel, 0] = null;

                    }
                }
            }
        }
        /// <summary>
        /// 存档
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccessFile_Click(object sender, EventArgs e)
        {
            if (flgView.RowSel > 0)
            {
                ArrayList Sqls = new ArrayList();
                Sqls.Clear();
                for (int i = 1; i < flgView.Rows.Count; i++)
                {
                    if (flgView[i, 0] != null)
                    {
                        flgView[i, 0] = "true";
                        if (flgView[i, 0].ToString().ToLower() != "false")
                        {
                            string Pid = flgView[i, 10].ToString();
                            string sql="";
                            sql= "update t_fecter_report_card  set STATE=1 where PATIENT_ID='" + Pid + "'";
                            Sqls.Add(sql);
                        }
                    }
                }
                if (Sqls.Count > 0)
                {
                    string[] strsqls = new string[Sqls.Count];
                    for (int i = 0; i < Sqls.Count; i++)
                    {
                        strsqls[i] = Sqls[i].ToString();
                    }

                    if (App.ExecuteBatch(strsqls) > 0)
                    {
                        App.Msg("存档成功！");
                        btnSelect_Click(sender,e);
                    }
                }

            }
        }

        private void btnBackSection_Click(object sender, EventArgs e)
        {
            if (flgView.RowSel > 0)
            {
                ArrayList Sql = new ArrayList();
                Sql.Clear();
                //string sql = "select ID,DOCUMENT_STATE from t_in_patient t ";
                for (int i = 1; i < flgView.Rows.Count; i++)
                {
                    if (flgView[i, 0] != null)
                    {
                        flgView[i, 0] = "true";
                        if (flgView[i, 0].ToString().ToLower() != "false")
                        {
                            string Pid = flgView[i, 10].ToString();
                            string sqls = "";
                            sqls = "update t_fecter_report_card  set STATE=2 where PATIENT_ID='" + Pid + "'";
                            Sql.Add(sqls);
                           
                            //string bedid = "";
                            //int id = App.GenId("t_inhospital_action", "id");

                            //string TSSql = "select * from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + Pid + "' order by id asc";
                            //DataSet dsactionhistory = App.GetDataSet(TSSql);
                            //string strsql = "delete from t_doc_neaten where patient_id='" + Pid + "'";
                            //Sql.Add(strsql);

                            //for (int i = 0; i < dsactionhistory.Tables[0].Rows.Count; i++)
                            //{
                            //    bedid = dsactionhistory.Tables[0].Rows[i]["bed_id"].ToString();
                            //    string sqls = "";
                            //    if (bedid.Trim() == "")
                            //    {
                            //        bedid = "0";
                            //    }
                            //    sqls = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                            //                           " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id,patient_id)" +
                            //                           " values(" + id + "," + dsactionhistory.Tables[0].Rows[i]["sid"].ToString() + "," +
                            //                           dsactionhistory.Tables[0].Rows[i]["said"].ToString() + ",'" +
                            //                           dsactionhistory.Tables[0].Rows[i]["pid"].ToString() + "'," +
                            //                           "'" + dsactionhistory.Tables[0].Rows[i]["action_type"].ToString() + "','" +
                            //                           dsactionhistory.Tables[0].Rows[i]["action_state"].ToString() + "',to_timestamp('" + dsactionhistory.Tables[0].Rows[i]["happen_time"].ToString()
                            //                                        + "','yyyy-MM-dd hh24:mi:ss')," +
                            //                                        bedid + ",'" +
                            //                                        dsactionhistory.Tables[0].Rows[i]["doctor_id"].ToString() + "'," +
                            //                                        dsactionhistory.Tables[0].Rows[i]["operate_id"].ToString() + "," +
                            //                                        dsactionhistory.Tables[0].Rows[i]["next_id"].ToString() + "," +
                            //                                        dsactionhistory.Tables[0].Rows[i]["preview_id"].ToString() + "," +
                            //                                        dsactionhistory.Tables[0].Rows[i]["patient_id"].ToString() + ")";
                            //    id = id + 1;
                            //    Sql.Add(sqls);
                            //}
                            //TSSql = "delete from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + Pid + "'";
                            //Sql.Add(TSSql);
                            //string strsqls = "update t_in_patient set document_state=null where id='" + Pid + "'";
                            //Sql.Add(strsqls);
                        }
                    }
                }
                if (Sql.Count > 0)
                {
                    string[] strsqls = new string[Sql.Count];
                    for (int i = 0; i < Sql.Count; i++)
                    {
                        strsqls[i] = Sql[i].ToString();
                    }
                    if (App.ExecuteBatch(strsqls) > 0)
                    {
                        App.Msg("退回成功！");
                        btnSelect_Click(sender, e);
                    }
                }

            }
        }

        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (flgView.RowSel > 0)
                {
                    if (flgView.ColSel > 0)
                    {
                        if (flgView[0, flgView.ColSel].ToString() == "院感报卡" || flgView[0, flgView.ColSel].ToString() == "传染病报卡")
                        {
                            string pid = flgView[flgView.RowSel, 1].ToString();
                            
                            if (pid != "")
                            {

                                string sql = "select * from t_in_patient t where t.pid='" + pid + "'";
                                DataSet ds1 = App.GetDataSet(sql);
                                if (ds1 != null)
                                {
                                    if (ds1.Tables[0].Rows.Count > 0)
                                    {
                                        InPatientInfo patientInfo = new InPatientInfo();

                                        patientInfo.Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"]);
                                        patientInfo.Patient_Name = ds1.Tables[0].Rows[0]["Patient_Name"].ToString();
                                        if (ds1.Tables[0].Rows[0]["Gender_Code"].ToString().Equals("男"))
                                        {
                                            patientInfo.Gender_Code = "0";
                                        }
                                        else
                                        {
                                            patientInfo.Gender_Code = "1";
                                        }
                                        patientInfo.Marrige_State = ds1.Tables[0].Rows[0]["marriage_state"].ToString();
                                        patientInfo.Medicare_no = ds1.Tables[0].Rows[0]["Medicare_no"].ToString();
                                        patientInfo.Home_address = ds1.Tables[0].Rows[0]["Home_address"].ToString();
                                        patientInfo.HomePostal_code = ds1.Tables[0].Rows[0]["HomePostal_code"].ToString();
                                        patientInfo.Home_phone = ds1.Tables[0].Rows[0]["Home_phone"].ToString();
                                        patientInfo.Office = ds1.Tables[0].Rows[0]["Office"].ToString();
                                        patientInfo.Office_address = ds1.Tables[0].Rows[0]["Office_Address"].ToString();
                                        patientInfo.Office_phone = ds1.Tables[0].Rows[0]["Office_phone"].ToString();
                                        patientInfo.Relation = ds1.Tables[0].Rows[0]["Relation"].ToString();
                                        patientInfo.Relation_address = ds1.Tables[0].Rows[0]["Relation_address"].ToString();
                                        patientInfo.Relation_phone = ds1.Tables[0].Rows[0]["Relation_phone"].ToString();
                                        patientInfo.RelationPos_code = ds1.Tables[0].Rows[0]["RelationPos_code"].ToString();
                                        patientInfo.OfficePos_code = ds1.Tables[0].Rows[0]["OfficePos_code"].ToString();
                                        if (ds1.Tables[0].Rows[0]["InHospital_Count"].ToString() != "")
                                            patientInfo.InHospital_count = Convert.ToInt32(ds1.Tables[0].Rows[0]["InHospital_Count"].ToString());
                                        patientInfo.Cert_Id = ds1.Tables[0].Rows[0]["cert_id"].ToString();
                                        patientInfo.Pay_Manager = ds1.Tables[0].Rows[0]["pay_manner"].ToString();
                                        patientInfo.In_Circs = ds1.Tables[0].Rows[0]["IN_Circs"].ToString();
                                        patientInfo.Natiye_place = ds1.Tables[0].Rows[0]["native_place"].ToString();
                                        patientInfo.Birth_place = ds1.Tables[0].Rows[0]["Birth_place"].ToString();
                                        patientInfo.Folk_code = ds1.Tables[0].Rows[0]["Folk_code"].ToString();

                                        patientInfo.Birthday = ds1.Tables[0].Rows[0]["Birthday"].ToString();
                                        patientInfo.PId = ds1.Tables[0].Rows[0]["PId"].ToString();
                                        patientInfo.Insection_Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["insection_id"]);
                                        patientInfo.Insection_Name = ds1.Tables[0].Rows[0]["insection_name"].ToString();
                                        patientInfo.In_Area_Id = ds1.Tables[0].Rows[0]["in_area_id"].ToString();
                                        patientInfo.In_Area_Name = ds1.Tables[0].Rows[0]["in_area_name"].ToString();
                                        if (ds1.Tables[0].Rows[0]["Age"].ToString() != "")
                                            patientInfo.Age = ds1.Tables[0].Rows[0]["Age"].ToString();
                                        //inpatient.Action_State = row["action_state"].ToString();
                                        patientInfo.Sick_Doctor_Id = ds1.Tables[0].Rows[0]["sick_doctor_id"].ToString();
                                        patientInfo.Sick_Doctor_Name = ds1.Tables[0].Rows[0]["sick_doctor_name"].ToString();
                                        if (ds1.Tables[0].Rows[0]["Sick_Area_Id"] != null)
                                            patientInfo.Sike_Area_Id = ds1.Tables[0].Rows[0]["Sick_Area_Id"].ToString();
                                        patientInfo.Sick_Area_Name = ds1.Tables[0].Rows[0]["sick_area_name"].ToString();
                                        if (ds1.Tables[0].Rows[0]["section_id"].ToString() != "")
                                            patientInfo.Section_Id = Int32.Parse(ds1.Tables[0].Rows[0]["section_id"].ToString());
                                        patientInfo.Section_Name = ds1.Tables[0].Rows[0]["section_name"].ToString();
                                        if (ds1.Tables[0].Rows[0]["in_time"] != null)
                                            patientInfo.In_Time = DateTime.Parse(ds1.Tables[0].Rows[0]["in_time"].ToString());
                                        patientInfo.State = ds1.Tables[0].Rows[0]["state"].ToString();
                                        if (ds1.Tables[0].Rows[0]["sick_bed_id"].ToString() != "")
                                            patientInfo.Sick_Bed_Id = Int32.Parse(ds1.Tables[0].Rows[0]["sick_bed_id"].ToString());
                                        patientInfo.Sick_Bed_Name = ds1.Tables[0].Rows[0]["sick_bed_no"].ToString();
                                        patientInfo.Age_unit = ds1.Tables[0].Rows[0]["age_unit"].ToString();
                                        patientInfo.Sick_Degree = Convert.ToString(ds1.Tables[0].Rows[0]["Sick_Degree"]);
                                        if (ds1.Tables[0].Rows[0]["Die_flag"].ToString() != "")
                                            patientInfo.Die_flag = Convert.ToInt32(ds1.Tables[0].Rows[0]["Die_flag"]);
                                        patientInfo.Card_Id = ds1.Tables[0].Rows[0]["card_id"].ToString();
                                        if (ds1.Tables[0].Rows[0]["Nurse_Level"].ToString().Equals("护理一级"))
                                        {
                                            patientInfo.Nurse_Level = "233";
                                        }
                                        else if (ds1.Tables[0].Rows[0]["Nurse_Level"].ToString().Equals("护理二级"))
                                        {
                                            patientInfo.Nurse_Level = "234";
                                        }
                                        else if (ds1.Tables[0].Rows[0]["Nurse_Level"].ToString().Equals("护理三级"))
                                        {
                                            patientInfo.Nurse_Level = "235";
                                        }
                                        else if (ds1.Tables[0].Rows[0]["Nurse_Level"].ToString().Equals("特护"))
                                        {
                                            patientInfo.Nurse_Level = "236";
                                        }
                                        if (ds1.Tables[0].Rows[0]["DOCUMENT_STATE"].ToString() == "1")
                                        {
                                            boolFlag = true;
                                        }
                                        else
                                        {
                                            boolFlag = false;

                                        }

                                        //frmReport_Main fq = new frmReport_Main(patientInfo, boolFlag, patientInfo.Id);
                                        //App.AddNewChildForm(fq);
                                    }
                                }

                            }
                        }
                    }
                }
            }
            catch
            {
            }
        }



    }
}
