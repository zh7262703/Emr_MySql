using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Bifrost.HisInstance
{
    /// <summary>
    /// ҽ��
    /// </summary>
    public partial class frmYZ : DevComponents.DotNetBar.Office2007Form
    {        
        DataSet ds;         
        InPatientInfo patient;

//        string Sql = @"select distinct visit_id סԺ����,inp_no סԺ��,start_date_time ��ʼʱ��,order_text ҽ������,'' CZH,'' ������λ,'' ����,dosage ����,
//                     dosage_units ��λ,frequency Ƶ��,administration ;�� ,stop_dagte_time ����ʱ��,doctor_name ҽ��,
//                     frequency ����,stop_doctor ֹͣҽ��,stop_nurse ֹͣУ�Ի�ʿ,order_sub_no ҽ�����,order_no �����,
//                     (case order_class when 'A' then 'ҩƷ' else '��ҩƷ' end) ҽ������  
//                     from ORDER_VIEW@dbhislink ";

//        string Sql = @"select distinct visit_id סԺ����,ZYH סԺ��,KSSJ ��ʼʱ��,YZMC ҽ������,'' CZH,ZLDW ������λ,ZLJL ����,MCJL ����,
//                     MCDW ��λ,YPPC Ƶ��,SYPC ;�� ,TZSJ ����ʱ��,YSGH ҽ��,
//                     frequency ����,TZYS ֹͣҽ��,YZBM ҽ�����,CZBS �����,
//                     (case LSYZ when 'A' then 'ҩƷ' else '��ҩƷ' end) ҽ������, 
//                     temporary_flag ������ʱ��־
                     //from V_XYPT_ORDERS@dbhislink ";
        string Sql = @"select ZYH סԺ��,KSSJ ��ʼʱ��,YZMC ҽ������,'' �����־,ZLDW ������λ,ZLJL ����,MCJL ����,
                     MCDW ��λ,YPPC Ƶ��,SYPC ;�� ,TZSJ ����ʱ��,YSGH_NAME ҽ��,
                     TZYS_NAME ֹͣҽ��,YZBM ҽ�����,yzxh �����,
                     (case LSYZ when 'A' then 'ҩƷ' else '��ҩƷ' end) ҽ������, 
                     ""temporary_flag"" repeatindicator
                     from V_XYPT_ORDERS@IDBLIMK ";


        //private string Pid = String.Empty;

        /// <summary>
        /// ҽ��
        /// </summary>
        public frmYZ()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="pid">סԺ��</param>
        public frmYZ(InPatientInfo inPatient)
        {
            patient = inPatient;
            InitializeComponent();
            lblPatient.Text = "  סԺ�ţ�" + patient.PId + "   ������" + patient.Patient_Name;
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
            App.FormStytleSet(this, true);
            btnOk_Click(sender, e);
            longDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;           
            
        }

        /// <summary>
        /// ҽ����ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                //string pid1 = "0" + patient.PId; 
                //ҽ����������
                string tsql = Sql;
                //tsql = tsql + " where order_status<>8 and order_status<>4 and ZYH='" + patient.PId + "'  and visit_id=" + patient.InHospital_count;// patient.PId
                tsql = tsql + @" where "" visit_no""='" + patient.His_id+"'";
                string conditions = "";

                

                if (chkMedical.Checked && chkNoMedical.Checked)
                {
                }
                else
                {
                    if (chkMedical.Checked)
                    {
                        conditions += " and LSYZ='A'";
                    }
                    else if (chkNoMedical.Checked)
                    {
                        conditions += " and LSYZ<>'A'";
                    }
                }

                if (IsLongTabPage)
                {
                    //repeat_indicator 1:����ҽ�� 2:��ʱҽ��
                    conditions += @" and ""temporary_flag""=1";
                    conditions = conditions + " order by ��ʼʱ��,YZXH,YZZXH asc";
                    tsql = tsql + conditions;
                    DataTable dtlong = App.GetDataSet(tsql).Tables[0];
                    ResetCZBS(dtlong);
                    longDgv.DataSource = dtlong.DefaultView;
                    //longDgv.Columns["CZH"].Visible = false;
                    longDgv.Columns["סԺ��"].Visible = false;
                    //longDgv.Columns["ҽ�����"].Visible = false;
                    longDgv.Columns["����"].Visible = false;
                    longDgv.Columns["������λ"].Visible = false;
                    //longDgv.Columns["ҽ������"].Visible = false;
                    longDgv.Columns["repeatindicator"].Visible = false;
                    // DevComponents.DotNetBar.Controls.DataGridViewX.ch

                    // DataGridViewCheckBoxXColumn cb =
                    //dataGridViewX2.Columns["Feedback"] as DataGridViewCheckBoxXColumn;
                    if (!longDgv.Columns[0].GetType().ToString().Contains("DataGridViewCheckBoxColumn"))
                    {
                        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                        checkColumn.HeaderText = "ѡ��";
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
                    conditions += @" and ""temporary_flag""=0";
                    conditions = conditions + " order by ��ʼʱ��,YZXH,YZZXH asc";
                    tsql = tsql + conditions;
                    DataTable dtshort = App.GetDataSet(tsql).Tables[0];
                    ResetCZBS(dtshort);
                    ShortDgv.DataSource = dtshort.DefaultView; 
                    //ShortDgv.Columns["סԺ����"].Visible = false;
                    ShortDgv.Columns["סԺ��"].Visible = false;
                    ShortDgv.Columns["ҽ�����"].Visible = false;
                    ShortDgv.Columns["repeatindicator"].Visible = false;
                    //ShortDgv.Columns["ҽ������"].Visible = false;
                    // DevComponents.DotNetBar.Controls.DataGridViewX.ch

                    // DataGridViewCheckBoxXColumn cb =
                    //dataGridViewX2.Columns["Feedback"] as DataGridViewCheckBoxXColumn;
                    if (!ShortDgv.Columns[0].GetType().ToString().Contains("DataGridViewCheckBoxColumn"))
                    {
                        DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                        checkColumn.HeaderText = "ѡ��";
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
            catch(Exception ex)
            {
                App.MsgErr("��ѯ����ԭ��" + ex.Message);
            }
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {           
           
        }

        /// <summary>
        /// ҽ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboYzlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// ȷ��
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
            this.Close();
        }

        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            App.His_Yz_Resault = "";
            this.Close();
        }

       /// <summary>
        ///����������������
       /// </summary>
       /// <param name="yzm">ҽ������</param>
       /// <param name="jl">����</param>
       /// <param name="sl">����</param>
       /// <param name="yf">�÷�</param>
       /// <param name="tj">;��</param>
       /// <returns></returns>
        private string Reset_Yz_Name(string yzm,string jl,string sl,string yf,string tj)
        {
            string newyzm = "";
            try
            {
                
                string[] tempyzm = yzm.Split('/');
                string dw = ""; //��λ

                /*
                 * ��ȡ������λ
                 */
                string temp_jl = "";
                int indexstart=0;
                int indexend=0;
                for (int i = 0; i < tempyzm[1].Length; i++)
                {
                    if (temp_jl=="")
                       temp_jl = tempyzm[1][i].ToString();
                    else
                       temp_jl = temp_jl+tempyzm[1][i];
                   if (!App.IsNumeric(temp_jl))
                   {
                       indexstart = i;
                       break;
                   }                  
                }
                for (int i = 0; i < tempyzm[1].Length; i++)
                {
                    if (tempyzm[1][i] == '*' || tempyzm[1][i] == '��' || tempyzm[1][i] == ':' || tempyzm[1][i] == '��')
                    {
                        indexend = i;
                        break;
                    }
                }
                dw = tempyzm[1].Substring(indexstart, indexend - indexstart);

                float sl1=Convert.ToSingle(sl);
                newyzm = tempyzm[0] + " " + tempyzm[1].Substring(0, indexend) + "��" + sl1.ToString() +" "+ tempyzm[2] + @"/" + jl + dw + " " + tj + " " + yf;

            }
            catch
            {
                newyzm = yzm + "," + jl + "," + sl;
            }

            return newyzm;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="dt"></param>
        private void ResetCZBS(DataTable dt)
        {
            string objCZBS = "";
            foreach (DataRow objdr in dt.Rows)
            {
                if (objCZBS == objdr["�����"].ToString())
                {
                    continue;
                }
                if (objdr["ҽ������"].ToString()=="��ҩƷ")
                {
                    continue;
                }
                objCZBS = objdr["�����"].ToString();
                DataRow[] drs = dt.Select("�����='" + objCZBS + "'");
                if (drs.Length > 1)
                {
                    for (int i = 0; i < drs.Length; i++)
                    {
                        if (i == 0)
                        {
                            drs[i]["�����־"] = "��";
                        }
                        else if (i == drs.Length - 1)
                        {
                            drs[i]["�����־"] = "��";
                        }
                        else
                        {
                            drs[i]["�����־"] = "��";
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
            if (dr.Cells["ҽ������"].Value.ToString() == "ҩƷ")
            {
                strReturn += dr.Cells["ҽ������"].Value.ToString();
                strReturn += " " + dr.Cells["����"].Value.ToString();
                strReturn += dr.Cells["��λ"].Value.ToString();
                strReturn += " " + dr.Cells[";��"].Value.ToString();
                strReturn += " " + dr.Cells["Ƶ��"].Value.ToString();
            }
            else if (dr.Cells["ҽ������"].Value.ToString() == "��ҩƷ")
            {
                strReturn += dr.Cells["ҽ������"].Value.ToString();
                strReturn += " " + dr.Cells[";��"].Value.ToString();
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

        private void dataGridViewX2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewCheckBoxCell sc = ShortDgv[e.ColumnIndex, e.RowIndex] as DataGridViewCheckBoxCell;
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
                shorttab_Click(sender, e);
            }
        }

        private void shorttab_Click(object sender, EventArgs e)
        {
            btnOk_Click(null, null);
        }
    }
   
}