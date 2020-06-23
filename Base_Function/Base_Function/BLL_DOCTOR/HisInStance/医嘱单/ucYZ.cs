﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.HisInStance.医嘱单
{
    /// <summary>
    /// 医嘱
    /// </summary>
    public partial class ucYZ : UserControl
    {
        DataSet ds;
        InPatientInfo patient;

        string Sql = "select distinct visit_id 住院次数,inp_no 住院号,start_date_time 开始时间,order_text 医嘱内容,'' CZH,'' 总量单位,'' 总量,dosage 剂量," +
                     "dosage_units 单位,frequency 频次,administration 途径 ,stop_dagte_time 结束时间,doctor_name 医生," +
                     "frequency 次数,stop_doctor 停止医生,stop_nurse 停止校对护士,order_sub_no 医嘱序号,order_no 乘组号," +
                     "(case order_class when 'A' then '药品' else '非药品' end) 医嘱属性  " +
                     "from t_his_yzxx ";


        //private string Pid = String.Empty;

        /// <summary>
        /// 医嘱
        /// </summary>
        public ucYZ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pid">住院号</param>
        public ucYZ(InPatientInfo inPatient)
        {
            patient = inPatient;
            InitializeComponent();
            lblPatient.Text = "  住院号：" + patient.PId + "   姓名：" + patient.Patient_Name;
            //Pid = patient.PId;          
            //try
            //{
            //    string medicare_no = App.ReadSqlVal("select medicare_no from t_in_patient t where t.Pid='" + Pid + "'", 0, "medicare_no");
            //    if (!string.IsNullOrEmpty(medicare_no))
            //    {
            //        if (medicare_no.Length > Pid.Length)
            //        {
            //            Pid = medicare_no;
            //        }
            //        else
            //        {
            //            Pid = patient.PId;
            //        }

            //    }
            //    else
            //    {
            //        Pid=patient.PId;
            //    }
            //}
            //catch
            //{
            //    Pid = patient.PId;
            //}
            if (App.UserAccount.CurrentSelectRole.Role_type == "O")
            {
                chkAll.Visible = false;
                btnSure.Visible = false;
            }
        }

        private void frmYZ_Load(object sender, EventArgs e)
        {           
            btnOk_Click(sender, e);
            longDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        /// <summary>
        /// 医嘱查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                string pid1 = patient.PId;
                //医嘱单看不到
                string tsql = Sql;
                tsql = tsql + " where order_status<>8 and order_status<>4 and (patient_id='" + pid1 + "' or  patient_id='" + patient.Medicare_no + "' ) and visit_id=" + patient.InHospital_count;// patient.PId
                string conditions = "";



                if (chkMedical.Checked && chkNoMedical.Checked)
                {
                }
                else
                {
                    if (chkMedical.Checked)
                    {
                        conditions += " and order_class='A'";
                    }
                    else if (chkNoMedical.Checked)
                    {
                        conditions += " and order_class<>'A'";
                    }
                }

                if (IsLongTabPage)
                {
                    //repeat_indicator 1:长期医嘱 2:临时医嘱
                    conditions += " and repeat_indicator=1";
                    conditions = conditions + " order by visit_id,order_no,order_sub_no ,start_date_time desc";
                    tsql = tsql + conditions;
                    DataTable dtlong = App.GetDataSet(tsql).Tables[0];
                    ResetCZBS(dtlong);
                    longDgv.DataSource = dtlong.DefaultView;
                    longDgv.Columns["住院次数"].Visible = false;
                    longDgv.Columns["住院号"].Visible = false;
                    longDgv.Columns["医嘱序号"].Visible = false;
                    longDgv.Columns["总量"].Visible = false;
                    longDgv.Columns["总量单位"].Visible = false;
                    //longDgv.Columns["医嘱类型"].Visible = false;
                    // DevComponents.DotNetBar.Controls.DataGridViewX.ch

                    // DataGridViewCheckBoxXColumn cb =
                    //dataGridViewX2.Columns["Feedback"] as DataGridViewCheckBoxXColumn;
                    if (!longDgv.Columns[0].GetType().ToString().Contains("DataGridViewCheckBoxColumn"))
                    {
                        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                        checkColumn.HeaderText = "选择";
                        checkColumn.DisplayIndex = 0;
                        checkColumn.Width = 30;
                        checkColumn.TrueValue = "true";
                        checkColumn.FalseValue = "false";
                        longDgv.Columns.Insert(0, checkColumn);
                    }
                    else
                    {
                        for (int i = 0; i < longDgv.Rows.Count; i++)
                        {
                            longDgv[0, i].Value = "false";
                        }
                    }

                    longDgv.AutoResizeColumns();
                }
                else
                {
                    conditions += " and repeat_indicator=2";
                    conditions = conditions + " order by visit_id,order_no,order_sub_no ,start_date_time desc";
                    tsql = tsql + conditions;
                    DataTable dtshort = App.GetDataSet(tsql).Tables[0];
                    ResetCZBS(dtshort);
                    ShortDgv.DataSource = dtshort.DefaultView;
                    ShortDgv.Columns["住院次数"].Visible = false;
                    ShortDgv.Columns["住院号"].Visible = false;
                    ShortDgv.Columns["医嘱序号"].Visible = false;
                    //ShortDgv.Columns["医嘱类型"].Visible = false;
                    // DevComponents.DotNetBar.Controls.DataGridViewX.ch

                    // DataGridViewCheckBoxXColumn cb =
                    //dataGridViewX2.Columns["Feedback"] as DataGridViewCheckBoxXColumn;
                    if (!ShortDgv.Columns[0].GetType().ToString().Contains("DataGridViewCheckBoxColumn"))
                    {
                        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                        checkColumn.HeaderText = "选择";
                        checkColumn.DisplayIndex = 0;
                        checkColumn.Width = 30;
                        checkColumn.TrueValue = "true";
                        checkColumn.FalseValue = "false";
                        ShortDgv.Columns.Insert(0, checkColumn);
                    }
                    else
                    {
                        for (int i = 0; i < ShortDgv.Rows.Count; i++)
                        {
                            ShortDgv[0, i].Value = "false";
                        }
                    }

                    ShortDgv.AutoResizeColumns();
                }

            }
            catch (Exception ex)
            {
                App.MsgErr("查询出错，原因：" + ex.Message);
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 医嘱属性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYzlx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            string strtext = "";
            for (int i = 0; i < longDgv.RowCount; i++)
            {
                DataGridViewCheckBoxCell sc = longDgv[0, i] as DataGridViewCheckBoxCell;
                if (sc != null)
                {
                    if (sc.Value != null)
                    {
                        if (sc.Value.ToString() == "true")
                        {
                            if (strtext == "")
                            {
                                strtext = OutText(longDgv.Rows[i]);
                            }
                            else
                            {
                                strtext += ";" + OutText(longDgv.Rows[i]);
                            }
                        }
                    }

                }
            }
            for (int i = 0; i < ShortDgv.RowCount; i++)
            {
                DataGridViewCheckBoxCell sc = ShortDgv[0, i] as DataGridViewCheckBoxCell;
                if (sc != null)
                {
                    if (sc.Value != null)
                    {
                        if (sc.Value.ToString() == "true")
                        {
                            if (strtext == "")
                            {
                                strtext = OutText(ShortDgv.Rows[i]);
                            }
                            else
                            {
                                strtext += ";" + OutText(ShortDgv.Rows[i]);

                            }
                        }
                    }
                }
            }
            App.His_Yz_Resault = strtext;           
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            App.His_Yz_Resault = "";          
        }

        /// <summary>
        ///重新排列遗嘱名称
        /// </summary>
        /// <param name="yzm">医嘱名称</param>
        /// <param name="jl">剂量</param>
        /// <param name="sl">数量</param>
        /// <param name="yf">用法</param>
        /// <param name="tj">途径</param>
        /// <returns></returns>
        private string Reset_Yz_Name(string yzm, string jl, string sl, string yf, string tj)
        {
            string newyzm = "";
            try
            {

                string[] tempyzm = yzm.Split('/');
                string dw = ""; //单位

                /*
                 * 获取剂量单位
                 */
                string temp_jl = "";
                int indexstart = 0;
                int indexend = 0;
                for (int i = 0; i < tempyzm[1].Length; i++)
                {
                    if (temp_jl == "")
                        temp_jl = tempyzm[1][i].ToString();
                    else
                        temp_jl = temp_jl + tempyzm[1][i];
                    if (!App.IsNumeric(temp_jl))
                    {
                        indexstart = i;
                        break;
                    }
                }
                for (int i = 0; i < tempyzm[1].Length; i++)
                {
                    if (tempyzm[1][i] == '*' || tempyzm[1][i] == '＊' || tempyzm[1][i] == ':' || tempyzm[1][i] == '：')
                    {
                        indexend = i;
                        break;
                    }
                }
                dw = tempyzm[1].Substring(indexstart, indexend - indexstart);

                float sl1 = Convert.ToSingle(sl);
                newyzm = tempyzm[0] + " " + tempyzm[1].Substring(0, indexend) + "＊" + sl1.ToString() + " " + tempyzm[2] + @"/" + jl + dw + " " + tj + " " + yf;

            }
            catch
            {
                newyzm = yzm + "," + jl + "," + sl;
            }

            return newyzm;
        }

        /// <summary>
        /// 处理乘组号
        /// </summary>
        /// <param name="dt"></param>
        private void ResetCZBS(DataTable dt)
        {
            string objCZBS = "";
            foreach (DataRow objdr in dt.Rows)
            {
                if (objCZBS == objdr["乘组号"].ToString())
                {
                    continue;
                }
                objCZBS = objdr["乘组号"].ToString();
                DataRow[] drs = dt.Select("乘组号='" + objCZBS + "'");
                if (drs.Length > 1)
                {
                    for (int i = 0; i < drs.Length; i++)
                    {
                        if (i == 0)
                        {
                            drs[i]["CZH"] = "┐";
                        }
                        else if (i == drs.Length - 1)
                        {
                            drs[i]["CZH"] = "┘";
                        }
                        else
                        {
                            drs[i]["CZH"] = "│";
                        }
                    }
                }
            }
        }


        private string OutText(DataGridViewRow dr)
        {
            string strReturn = "";
            if (dr == null)
                return strReturn;
            if (dr.Cells["医嘱属性"].Value.ToString() == "药品")
            {
                strReturn += dr.Cells["医嘱内容"].Value.ToString();
                strReturn += " " + dr.Cells["剂量"].Value.ToString();
                strReturn += dr.Cells["单位"].Value.ToString();
                strReturn += " " + dr.Cells["途径"].Value.ToString();
                strReturn += " " + dr.Cells["频次"].Value.ToString();
            }
            else if (dr.Cells["医嘱属性"].Value.ToString() == "非药品")
            {
                strReturn += dr.Cells["医嘱内容"].Value.ToString();
                strReturn += " " + dr.Cells["途径"].Value.ToString();
            }
            return strReturn;
        }

        private void dataGridViewX1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewCheckBoxCell sc = longDgv[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
                    if (sc != null)
                    {
                        if (sc.Value != null)
                        {
                            if (sc.Value.ToString() != "true")
                            {
                                sc.Value = "true";
                            }
                            else
                            {
                                sc.Value = "false";
                            }
                        }
                        else
                        {
                            sc.Value = "true";
                        }

                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            DataGridViewCheckBoxCell cell = null;
            for (int i = 0; i < longDgv.Rows.Count; i++)
            {
                cell = longDgv[0, i] as DataGridViewCheckBoxCell;
                if (cell != null)
                {

                    if (chkAll.Checked)
                    {
                        cell.Value = "true";
                    }
                    else
                    {
                        cell.Value = "false";
                    }
                }
            }
            for (int i = 0; i < ShortDgv.Rows.Count; i++)
            {
                cell = ShortDgv[0, i] as DataGridViewCheckBoxCell;
                if (cell != null)
                {

                    if (chkAll.Checked)
                    {
                        cell.Value = "true";
                    }
                    else
                    {
                        cell.Value = "false";
                    }
                }
            }
        }
        private bool IsLongTabPage = true;
        private void tabControl1_SelectedTabChanged(object sender, TabStripTabChangedEventArgs e)
        {
            if (this.tabControl1.SelectedTab.Name == "longtab")
            {
                IsLongTabPage = true;
            }
            else if (this.tabControl1.SelectedTab.Name == "shorttab")
            {
                IsLongTabPage = false;
            }
        }
    }

}