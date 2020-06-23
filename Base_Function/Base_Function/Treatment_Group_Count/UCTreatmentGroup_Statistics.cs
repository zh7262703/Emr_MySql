using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar.Controls;
using System.IO;

namespace Base_Function.Treatment_Group_Count
{
    public partial class UCTreatmentGroup_Statistics : UserControl
    {
        public UCTreatmentGroup_Statistics()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select * from (select a1.section_id sid1,a1.section_name 科室名称,count(a1.section_name) 在院人数 from t_in_patient a1 where   a1.leave_time is null and a1.document_time is null group by a1.section_name,a1.section_id) a"
                        + " inner join"
                        + " (select d2.section_id sid2,a2.tng_id tng_id2,a2.tng_name 诊疗组,count(a2.tng_name) 诊疗组管理患者人数 from T_TREATORNURSE_GROUP a2 inner join t_tng_account b2 on a2.tng_id=b2.tng_id inner join t_account_user c2 on b2.account_id=c2.account_id inner Join t_in_patient d2 on c2.user_id=d2.sick_doctor_id where   d2.leave_time is null and d2.document_time is null group by a2.tng_name,d2.section_id,a2.tng_id) b"
                        + " on a.sid1=b.sid2"

                        + " inner join (select a3.section_id sid3,c3.tng_id tng_id3,a3.sick_doctor_name 医生姓名,count(a3.sick_doctor_name) 管床人数 from t_in_patient a3 inner join t_account_user b3 on a3.sick_doctor_id=b3.user_id inner join t_tng_account c3 on b3.account_id=c3.account_id where  a3.leave_time is null and a3.document_time is null group by a3.sick_doctor_name,a3.section_id,c3.tng_id) c"
                        + " on b.tng_id2=c.tng_id3 and a.sid1=c.sid3";



            if (cboSection.SelectedIndex > 0)
            {
                sql += " where a.sid1=" + cboSection.SelectedValue.ToString();
            }

            sql += " order by a.sid1";

            DataSet ds = App.GetDataSet(sql);
            if (ds!= null)
            {
                ucGridviewX1.DataBd(sql,"sid1","","");
                ucGridviewX1.fg.Columns["sid1"].Visible = false;
                ucGridviewX1.fg.Columns["sid2"].Visible = false;
                ucGridviewX1.fg.Columns["sid3"].Visible = false;
                ucGridviewX1.fg.Columns["tng_id2"].Visible = false;
                ucGridviewX1.fg.Columns["tng_id3"].Visible = false;
            }
        }

        private void UCTreatmentGroup_Statistics_Load(object sender, EventArgs e)
        {
            ucGridviewX1.fg.AllowUserToAddRows = false;
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.ReadOnly = true;

            BandSection();

        }

        private void BandSection()
        {
            string sql_Section = @"select a.sid,a.section_name,a.section_code from t_sectioninfo a 
                                        inner join t_section_area b on a.sid=b.sid
                                        group  by a.shid,a.sid,a.section_code,a.section_name
                                        order by a.shid,to_number(a.section_code)";//查询科室
            //绑定下拉菜单项
            //入院科室
            DataSet ds_InSection = new DataSet();

            ds_InSection = App.GetDataSet(sql_Section);
            //插入默认选项（请选择）
            if (ds_InSection != null)
            {
                DataRow dr = ds_InSection.Tables[0].NewRow();
                dr["sid"] = 0;
                dr["section_name"] = "全院";
                ds_InSection.Tables[0].Rows.InsertAt(dr, 0);
            }
            cboSection.DataSource = ds_InSection.Tables[0];
            cboSection.DisplayMember = "section_name";
            cboSection.ValueMember = "sid";
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataToExcel(ucGridviewX1.fg);
        }
        public void DataToExcel(DataGridViewX m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                for (int i = 0; i < m_DataView.Columns.Count; i++)
                {
                    if (m_DataView.Columns[i].Visible == true)
                    {
                        strLine = strLine + m_DataView.Columns[i].HeaderText.ToString() + Convert.ToChar(9);
                    }
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";

                for (int i = 0; i < m_DataView.Rows.Count; i++)
                {
                    if (m_DataView.Columns[0].Visible == true)
                    {
                        if (m_DataView.Rows[i].Cells[0].Value == null)
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                            strLine = strLine + m_DataView.Rows[i].Cells[0].Value.ToString() + Convert.ToChar(9);
                    }
                    for (int j = 1; j < m_DataView.Columns.Count; j++)
                    {
                        if (m_DataView.Columns[j].Visible == true)
                        {
                            if (m_DataView.Rows[i].Cells[j].Value == null)
                                strLine = strLine + " " + Convert.ToChar(9);
                            else
                            {
                                string rowstr = "";
                                rowstr = m_DataView.Rows[i].Cells[j].Value.ToString();
                                if (rowstr.IndexOf("\r\n") > 0)
                                    rowstr = rowstr.Replace("\r\n", " ");
                                if (rowstr.IndexOf("\t") > 0)
                                    rowstr = rowstr.Replace("\t", " ");
                                strLine = strLine + rowstr + Convert.ToChar(9);
                            }
                        }
                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
