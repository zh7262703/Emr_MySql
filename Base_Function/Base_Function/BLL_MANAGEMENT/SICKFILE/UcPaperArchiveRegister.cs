using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class UcPaperArchiveRegister : UserControl
    {
        public UcPaperArchiveRegister()
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
        private DataSet dsPatientInfo = null;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAll();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dsPatientInfo == null)
            {
                MessageBox.Show("没有需要导出的数据！");
                return;
            }
            SaveFileDialog sf=new SaveFileDialog ();
            //Excel2007(*.xlsx)|*.xlsx|
            sf.FileName = "纸质归档记录.xls";
            sf.Filter = "Excel工作簿(*.xls)|*.xls";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                this.flgView.fg.SaveExcel(sf.FileName, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
                //this.flgView.fg.SaveGrid(sf.FileName, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.None, System.Text.Encoding.Default);
            }
        }

        private void SearchAll()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select ID as ID,PID as 住院号, sick_bed_no as 床号,patient_name as 姓名,case gender_code when '1' then '女' else '男' end as 性别,");
            sb.Append("case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,sick_doctor_name as 管床医生,in_time as 住院日期,");
            sb.Append("die_time as 出院日期,");
            sb.Append("section_name as 当前科室,");
            sb.Append("case DOCUMENT_STATE when '1' then '已归档' else '未归档' end 归档状态,EXE_DOCUMENT_TIME as 归档执行时间,ISGETPAPERDOC as 上交纸质病历,");
            sb.Append("getpaperdoc_date as 纸质上交时间,");
            sb.Append("section_name,birthday from t_in_patient where");
            sb.Append(" 1=1 and die_time is not null ");
            if (cbeSeccion.SelectedIndex != 0 && cbeSeccion.SelectedIndex != -1)
            {
                sb.Append(" and section_name='" + cbeSeccion.Text + "'");
            }
            if (tbxPID.Text.Trim().Length > 0)
            {
                sb.Append(" and PID like '%" + tbxPID.Text.Trim() + "%'");
            }
            if (tbxName.Text.Trim().Length > 0)
            {
                sb.Append(" and patient_name like '%" + tbxName.Text.Trim() + "%'");
            }
            if (cbeEArchive.SelectedIndex != 0 && cbeEArchive.SelectedIndex != -1)
            {
                if (cbeEArchive.Text == "出院未归档")
                {
                    sb.Append(" AND (DOCUMENT_STATE!='1' OR DOCUMENT_STATE IS NULL)");
                }
                else
                {
                    sb.Append(" AND DOCUMENT_STATE='1'");
                }
            }
            if (cbePArchive.SelectedIndex != 0 && cbePArchive.SelectedIndex != -1)
            {
                if (cbePArchive.Text == "出院未归档")
                {
                    sb.Append(" AND (ISGETPAPERDOC='N' OR ISGETPAPERDOC IS NULL)");
                }
                else
                {
                    sb.Append(" AND ISGETPAPERDOC='Y'");
                }
            }
            if (cbOutTime.Checked)
            {
                sb.Append(" AND die_time>=to_date('" + dtStart.Text.ToString() + "','yyyy-mm-dd hh24:mi:ss')");
                sb.Append(" AND die_time<to_date('" + Convert.ToDateTime(dtEnd.Text).AddDays(1).ToString() + "','yyyy-mm-dd hh24:mi:ss')");
            }
            sb.Append(" order by id desc");
            dsPatientInfo = Bifrost.App.GetDataSet(sb.ToString());
            if (dsPatientInfo != null)
            {
                flgView.DataBd(sb.ToString(), "ID", "", "");
                //flgView.fg.Cols["ID"].Width = 100;
                //flgView.fg.Cols["住院号"].Width = 100;
                //flgView.fg.Cols["床号"].Width = 100;
                //flgView.fg.Cols["姓名"].Width = 100;
                //flgView.fg.Cols["性别"].Width = 100;
                //flgView.fg.Cols["年龄"].Width = 100;
                //flgView.fg.Cols["管床医生"].Width = 100;
                //flgView.fg.Cols["住院日期"].Width = 100;
                //flgView.fg.Cols["出院日期"].Width = 100;
                //flgView.fg.Cols["当前科室"].Width = 100;
                //flgView.fg.Cols["归档状态"].Width = 100;
                //flgView.fg.Cols["上交纸质病历"].Width = 100;
                //flgView.fg.Cols["纸质上交时间"].Width = 100;
                flgView.fg.Cols["section_name"].Visible = false;
                flgView.fg.Cols["birthday"].Visible = false;
                flgView.fg.Cols["上交纸质病历"].Visible = true;
                for (int i = 0; i < 9; i++)
                {
                    this.flgView.fg.Cols[i].StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                }
                try
                {

                    //计算年龄
                    //CountAgeByBirthday();
                }
                catch (Exception ex)
                {
                }
                flgView.fg.AllowEditing = false;
                //ucC1FlexGrid2.fg.DataSource = ds;
            }
            //Sick_area_id='" + cbeSeccion.Text + "' and patient_name like '%" + tbxName.Text + "%' and PID like '%" + tbxPID.Text + "%' order by id desc";
        }

        /// <summary>
        /// 计算年龄
        /// </summary>
        private void CountAgeByBirthday()
        {
            //分页统计当数据行数超过200时不计算
            try
            {
                for (int i = 0; i < 200; i++)
                {
                    //if (dsPatientInfo.Tables[0].Rows[i]["id"].ToString() == "7524")
                    //{
                    //    App.Msg("");
                    //}
                    string birthday = dsPatientInfo.Tables[0].Rows[i]["birthday"].ToString(); //生日
                    string in_time = dsPatientInfo.Tables[0].Rows[i]["住院日期"].ToString(); //
                    int year, month, day;
                    DataInit.GetAgeByBirthday(Convert.ToDateTime(birthday), Convert.ToDateTime(in_time), out year, out month, out day);
                    string strTemp = "";
                    if (year > 0)
                    {
                        strTemp = year.ToString() + "岁";
                    }
                    else if (month > 0)
                    {
                        strTemp = month.ToString() + "月";
                    }
                    else
                    {
                        strTemp = day.ToString() + "天";
                    }
                    flgView.fg.Cols["年龄"][i + 1] = strTemp;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {

            try
            {
                //flgView.fg.Cols["ID"].Width = 100;
                //flgView.fg.Cols["床号"].Width = 100;
                //flgView.fg.Cols["姓名"].Width = 100;
                //flgView.fg.Cols["性别"].Width = 100;
                //flgView.fg.Cols["年龄"].Width = 100;
                //flgView.fg.Cols["管床医生"].Width = 100;
                //flgView.fg.Cols["住院日期"].Width = 100;
                //flgView.fg.Cols["出院日期"].Width = 100;
                //flgView.fg.Cols["当前科室"].Width = 100;
                //flgView.fg.Cols["归档状态"].Width = 100;
                //flgView.fg.Cols["上交纸质病历"].Width = 100;
                //flgView.fg.Cols["纸质上交时间"].Width = 100;
                flgView.fg.Cols["section_name"].Visible = false;
                flgView.fg.Cols["birthday"].Visible = false;
                flgView.fg.Cols["上交纸质病历"].Visible = true;
                flgView.fg.AllowEditing = false;
            }
            catch
            {
            }
        }

        private void cbeHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            StringBuilder sbSeccion = new StringBuilder("select section_name from t_sectioninfo");
            switch (cbeHospital.Text)
            {
                case "全院":
                    break;
                case "北院":
                    sbSeccion.Append(" where shid='1'");
                    sbSeccion.Append(" and section_name !='北院手术室'");
                    sbSeccion.Append(" and section_name !='北院住院急诊'");
                    sbSeccion.Append(" and section_name !='北院麻醉科'");
                    sbSeccion.Append(" and section_name !='质控科'");
                    break;
                case "南院":
                    sbSeccion.Append(" where shid='221'");
                    sbSeccion.Append(" and section_name !='南院急诊'");
                    sbSeccion.Append(" and section_name !='南院麻醉科'");
                    sbSeccion.Append(" and section_name !='南院手术室'");
                    break;
                default:
                    break;
            }
            DataSet dsSeccion = Bifrost.App.GetDataSet(sbSeccion.ToString());
            DataRow objRow = dsSeccion.Tables[0].NewRow();
            objRow[0] = "--请选择--";
            dsSeccion.Tables[0].Rows.InsertAt(objRow, 0);
            cbeSeccion.DisplayMember = "section_name";
            cbeSeccion.ValueMember = "section_name";
            cbeSeccion.DataSource = dsSeccion.Tables[0];
        }

        private void 归档退回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (flgView.fg[flgView.fg.RowSel, "归档状态"].ToString()!="已归档")
            //{
            //    App.Msg("提示: 当前病人未归档!")
            //    return;
            //}
            int id =Bifrost.App.GenId("t_inhospital_action", "id");
            ArrayList Sqls = new ArrayList();

            string sql_Select = "select * from T_INHOSPITAL_ACTION_HISTORY where pid='" + flgView.fg[flgView.fg.RowSel, "ID"].ToString() + "' order by id";
            DataSet dsactionhistory = App.GetDataSet(sql_Select);
            //string[] strsqls = new string[dsactionhistory.Tables[0].Rows.Count+3];


            string strsql = "delete from t_doc_neaten where pid='" + flgView.fg[flgView.fg.RowSel, "住院号"].ToString() + "'";
            Sqls.Add(strsql);
            string bedid = "";
            for (int i = 0; i < dsactionhistory.Tables[0].Rows.Count; i++)
            {
                bedid = dsactionhistory.Tables[0].Rows[i]["bed_id"].ToString();
                if (bedid.Trim() == "")
                {
                    bedid = "0";
                }
                strsql = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
                                       " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id,patient_id)" +
                                       " values(" + id + "," + dsactionhistory.Tables[0].Rows[i]["sid"].ToString() + "," +
                                       dsactionhistory.Tables[0].Rows[i]["said"].ToString() + ",'" +
                                       dsactionhistory.Tables[0].Rows[i]["pid"].ToString() + "'," +
                                       "'" + dsactionhistory.Tables[0].Rows[i]["action_type"].ToString() + "','" +
                                       dsactionhistory.Tables[0].Rows[i]["action_state"].ToString() + "',to_timestamp('" + dsactionhistory.Tables[0].Rows[i]["happen_time"].ToString()
                                                    + "','yyyy-MM-dd hh24:mi:ss')," +
                                                    bedid + ",'" +
                                                    dsactionhistory.Tables[0].Rows[i]["doctor_id"].ToString() + "'," +
                                                    dsactionhistory.Tables[0].Rows[i]["operate_id"].ToString() + "," +
                                                    dsactionhistory.Tables[0].Rows[i]["next_id"].ToString() + "," +
                                                    dsactionhistory.Tables[0].Rows[i]["preview_id"].ToString() + "," +
                                                    dsactionhistory.Tables[0].Rows[i]["pid"].ToString() + ")";
                id = Bifrost.App.GenId("t_inhospital_action", "id");
                Sqls.Add(strsql);
            }

            strsql = "delete from T_INHOSPITAL_ACTION_HISTORY where pid='" + flgView.fg[flgView.fg.RowSel, "ID"].ToString() + "'";
            Sqls.Add(strsql);
            strsql = "update t_in_patient set baupload='2',document_state=null,exe_document_time=(Sysdate+1) where id='" + flgView.fg[flgView.fg.RowSel, "ID"].ToString() + "'";
            Sqls.Add(strsql);
            try
            {
                string[] strsqls = new string[Sqls.Count];
                for (int i = 0; i < Sqls.Count; i++)
                {
                    strsqls[i] = Sqls[i].ToString();
                }
                App.ExecuteBatch(strsqls);
                App.Msg("退回成功！");
                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                App.Msg("退回失败！原因：" + ex.Message);
            }
        }

        private void 纸质病历上交ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (flgView.fg.RowSel >= 1)
                {
                    if (null != dsPatientInfo && dsPatientInfo.Tables[0].Rows.Count > 0)
                    {
                        StringBuilder strBuilder = new StringBuilder();

                        string pid = flgView.fg[flgView.fg.RowSel, "住院号"].ToString();
                        string patient_Id = flgView.fg[flgView.fg.RowSel, "ID"].ToString();
                        string strTemp = "Y";
                        if (flgView.fg[flgView.fg.RowSel, "上交纸质病历"].ToString() == "Y")
                        {
                            strTemp = "N";
                        }
                        string sql = "update T_IN_PATIENT set ISGETPAPERDOC='" + strTemp + "',GETPAPERDOC_DATE=to_date('" + Bifrost.App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss') where ID=" + patient_Id + "";
                        strBuilder.Append(sql + ";");

                        string sql_Select = "select count(*) from T_INHOSPITAL_ACTION_HISTORY where patient_Id='" + flgView.fg[flgView.fg.RowSel, "ID"].ToString() + "'";
                        string strCon = App.ReadSqlVal(sql_Select, 0, "count(*)");
                        if (flgView.fg[flgView.fg.RowSel, "归档状态"].ToString() != "已归档" && strCon == "0")
                        {
                            //文书归档
                            //整理
                            string SqlNeaten_Nurse = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,patient_Id)" +
                                        " values ('" + pid + "',0,1,sysdate," + patient_Id + ")";
                            string SqlNeaten_Doctor = "insert into t_doc_neaten (pid,doc_neaten_type,neaten_flag,neaten_time,patient_Id)" +
                                            " values ('" + pid + "',1,1,sysdate," + patient_Id + ")";
                            //归档操作
                            string SqlActions_History_Delete = "delete from T_INHOSPITAL_ACTION_HISTORY where patient_id='" + patient_Id + "'";
                            string SqlActions_History = "insert into T_INHOSPITAL_ACTION_HISTORY select * from t_inhospital_action where patient_id='" + patient_Id + "' order by id";
                            string SqlActions = "delete from t_inhospital_action where patient_id='" + patient_Id + "'";
                            //归档操作护理记录单
                            string SqlActions_N_Insert = "insert into T_NURSE_RECORD_HISTORY select ID,BED_NO,PID,MEASURE_TIME,ITEM_CODE,ITEM_VALUE,LIE_POS,STATUS_MEASURE,STATE,CREAT_ID,CREATE_TIME,UPDATE_ID,UPDATE_TIME,C_STATE,OTHER_NAME,PATIENT_ID,DIAGNOSE_NAME,ITEM_SHOW_NAME,RECORD_TYPE from T_NURSE_RECORD where patient_id='" + patient_Id + "' order by id";
                            string SqlActions_N_Del = "delete from T_NURSE_RECORD where patient_id='" + patient_Id + "'";
                            //删除授权记录
                            string sqlupdate = "update t_in_patient  set document_state='1',document_time=sysdate,DOCUMENT_OPER_ID=" + App.UserAccount.UserInfo.User_id + " where id='" + patient_Id + "'";
                            string sqlDocRight = "delete from t_set_text_rights aa where aa.patient_id=" + patient_Id;
                            strBuilder.Append(SqlNeaten_Nurse + ";");
                            strBuilder.Append(SqlNeaten_Doctor + ";");
                            strBuilder.Append(SqlActions_History_Delete + ";");
                            strBuilder.Append(SqlActions_History + ";");
                            strBuilder.Append(SqlActions + ";");
                            strBuilder.Append(SqlActions_N_Insert + ";");
                            strBuilder.Append(SqlActions_N_Del + ";");
                            strBuilder.Append(sqlupdate + ";");
                            strBuilder.Append(sqlDocRight + ";");


                        }
                        string[] arr = strBuilder.ToString().Substring(0, strBuilder.Length - 1).Split(';');
                        if (App.ExecuteBatch(arr) > 0)//Bifrost.App.ExecuteSQL(sql) > 0)
                        {
                            Bifrost.App.Msg("操作已经成功！");
                            btnSearch_Click(sender, e);
                        }
                        else
                        {
                            Bifrost.App.MsgErr("操作已经失败！");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Bifrost.App.MsgErr(ex.Message);
            }
        }

        private void UcPaperArchiveRegister_Load(object sender, EventArgs e)
        {
            //cbeHospital.SelectedIndex = 0;
            //cbePArchive.SelectedIndex = 0;
            //cbeEArchive.SelectedIndex = 0;
            try
            {
                this.dtStart.Text = App.GetSystemTime().ToString();
                this.dtEnd.Text = App.GetSystemTime().ToString();
                this.cbePArchive.SelectedIndex = 1;
                //SearchAll();
                this.flgView.fg.RowColChange += new EventHandler(CurrentDataChange);
                this.flgView.fg.MouseHoverCell += new EventHandler(fg_MouseHoverCell);
            }
            catch(Exception ex)
            {

            }
        }

        int oldRow = 0;
        private void fg_MouseHoverCell(object sender, EventArgs e)
        {

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    ucC1FlexGrid2.fg.Styles[ucC1FlexGrid2.fg.Row].BackColor = Color.Red;
            //}
            //App.Msg("日");
            //for (int i = 1; i < 200; i++)
            //{
            //    int row = ucC1FlexGrid2.fg.BottomRow;
            //    ucC1FlexGrid2.fg.Rows[i].StyleNew.BackColor = Color.Red;
            //}
            int Row = this.flgView.fg.MouseRow;

            if (Row > 0)
            {
                if (Row != oldRow && oldRow <= flgView.fg.Rows.Count)
                {
                    this.flgView.fg.Rows[Row].StyleNew.BackColor = ColorTranslator.FromHtml("#e9f7f6");
                    this.flgView.fg.Rows[Row].StyleNew.ForeColor = ColorTranslator.FromHtml("#00619d");
                    this.flgView.fg.Cursor = Cursors.Hand;
                    this.flgView.fg.Cols[2].StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    if (oldRow > 0)
                    {
                        if (oldRow < flgView.fg.Rows.Count)
                        {
                            this.flgView.fg.Rows[oldRow].StyleNew.BackColor = this.flgView.fg.BackColor;
                            this.flgView.fg.Rows[oldRow].StyleNew.ForeColor = this.flgView.fg.ForeColor;
                        }
                    }
                }
                oldRow = Row;
            }
        }

        private void cbOutTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbOutTime.Checked)
            {
                dtStart.Enabled = true;
                dtEnd.Enabled = true;
            }
            else
            {
                dtStart.Enabled = true;
                dtEnd.Enabled = true;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            /*
             * 不是admin右键中不显示“归档退回”按钮
             */
            if (App.UserAccount.UserInfo.User_name == "管理员" && flgView.fg[flgView.fg.RowSel, "归档状态"].ToString() == "已归档")
            {
                归档退回ToolStripMenuItem.Visible = true;
            }
            else
            {
                归档退回ToolStripMenuItem.Visible = false;
            }
        }
    }
}
