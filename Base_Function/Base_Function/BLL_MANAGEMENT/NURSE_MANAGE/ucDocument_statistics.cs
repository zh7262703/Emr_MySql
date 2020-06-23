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
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR;

namespace Base_Function.BLL_MANAGEMENT.NURSE_MANAGE
{
    public partial class ucDocument_statistics : UserControl
    {
        public ucDocument_statistics()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载
        /// </summary>
        private void DataLoad()
        {
            //文书
            string sql = "select t.id,t.textname from t_text t where t.id in('2222','13669957','50950232','13','50000062','14','50000036','295','2034','2035','2036','2037','2031')";
            DataSet ds_Text = App.GetDataSet(sql);
            DataTable dt_Text = ds_Text.Tables[0];
            DataRow row_Text = dt_Text.NewRow();
            row_Text[0] = 0;
            row_Text[1] = "请选择...";
            dt_Text.Rows.InsertAt(row_Text, 0);
            this.cbxText.DisplayMember = "textname";
            this.cbxText.ValueMember = "id";
            this.cbxText.DataSource = dt_Text;
            this.cbxText.SelectedIndex = 0;
            //病区
            sql = "select distinct ts.said,ts.sick_area_name from t_sickareainfo ts inner join t_section_area ta on ts.said=ta.said where ts.enable_flag='Y' order by sick_area_name";
            DataSet ds_Ward = App.GetDataSet(sql);
            DataTable dt_Ward = ds_Ward.Tables[0];
            DataRow row_Ward = dt_Ward.NewRow();
            row_Ward[0] = 0;
            row_Ward[1] = "请选择...";
            dt_Ward.Rows.InsertAt(row_Ward, 0);
            this.cbxWard.DisplayMember = "sick_area_name";
            this.cbxWard.ValueMember = "said";
            this.cbxWard.DataSource = dt_Ward;
            this.cbxWard.SelectedIndex = 0;
        }

        private void chbTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbTime.Checked)
            {
                this.dtpStart.Enabled = true;
                this.dtpEnd.Enabled = true;
            }
            else
            {
                this.dtpStart.Enabled = false;
                this.dtpEnd.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                /*1.文书类型分为三种：
                //    1）住院病人跌倒/坠床风险评估及告知单。
                //    2）压疮评估、预防监控记录单。
                //    3）病重病人上报表。
                     * 4.入院护理评估单
                     * 5.危重患者护理计划单
                     * 6.儿科病人跌倒/坠床风险评估及告知单
                     * 7.住院患儿跌倒/坠床风险评估及告知单
                //2．创建成功的标志根据点击保存来判断，保存一次生成一个，暂存的不计数。
                //3．双击总计表格里面的数字，会进入病区详细列表。
                //4．增加导出excel按钮。
                //5. 护理单元默认不选，不选时查出所有护理单元的数据，选择单个护理单元时查出该护理单元数据。
                //6．护理单元为文书创建时病人所在的护理单元，如是果是授权补录，则显示被授权帐号所在的护理单元。
                */
                string sql = "";
                string sqlwhere = "";
                Boolean bl = false;
                if (cbxWard.SelectedIndex != 0)
                {//按病区查询
                    bl = true;
                    dgv.ContextMenuStrip = contextMenuStrip1;
                    sql = @"select row_number() over(order by tp.sick_area_name,ti.patient_name,tp.doc_name) 序号,tp.sick_area_name 病区,
                            ti.patient_name 患者姓名,(CASE ti.gender_code WHEN '1' THEN '女' WHEN '0' THEN '男' end) 性别,tp.doc_name 文书创建时间,ti.id,ti.pid
                            from t_patients_doc tp inner join t_in_patient ti on tp.patient_id=ti.id 
                            where tp.submitted='Y' {0}  
                            order by tp.sick_area_name,ti.patient_name,tp.doc_name";
                    sqlwhere += " and tp.sick_area_name ='" + cbxWard.Text + "' ";
                }
                else
                {
                    dgv.ContextMenuStrip = null;
                    sql = @"select row_number() over(order by tp.sick_area_name) 序号,tp.sick_area_name 病区,count(tp.textname) 总计 
                                from t_patients_doc tp 
                                inner join t_in_patient ti on tp.patient_id=ti.id 
                                inner join t_sickareainfo ts on tp.sick_area_name=ts.sick_area_name
                                where tp.submitted='Y' {0}  group by tp.sick_area_name order by tp.sick_area_name ";
                }
                if (cbxText.SelectedIndex != 0)
                {//按文书查询
                    sqlwhere += " and textkind_id ='" + cbxText.SelectedValue.ToString() + "'";
                }
                else
                {
                    sqlwhere += " and tp.textkind_id in('2222','13669957','50950232','13','50000062','14','50000036','295','2034','2035','2036','2037','2031') ";
                }
                if (chbTime.Checked)
                {//时间条件
                    //sqlwhere += " and tp.doc_name between '" + dtpStart.Text + "' and '" + dtpEnd.Text + "'";// to_timestamp('" + rightNow + "','yyyy-MM-dd HH24:mi:ss')";
                    sqlwhere += " and to_date(tp.doc_name,'yyyy-MM-dd HH24:mi') between to_date('" + dtpStart.Text + "','yyyy-MM-dd HH24:mi') AND to_date('" + dtpEnd.Text + "','yyyy-MM-dd HH24:mi')";
                }

                sql = string.Format(sql, sqlwhere);
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    dgv.DataSource = ds.Tables[0];
                    if (bl)
                    {
                        dgv.Columns["id"].Visible = false;
                        dgv.Columns["pid"].Visible = false;
                    }
                    dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ucDocument_statistics_Load(object sender, EventArgs e)
        {
            try
            {
                chbTime.Checked = false;
                DataLoad();
            }
            catch (System.Exception ex)
            {
            	    
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataToExcel(dgv);
            //saveFileDialog1.FileName = "文书统计.xls";
            //saveFileDialog1.Filter = "Excel工作簿(*.xls)|*.xls";
            //saveFileDialog1.ShowDialog();
        }


        private void DataToExcel(DataGridViewX m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;// +".xls";
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

        

        private void 病案查阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = dgv.CurrentRow.Cells["id"].Value.ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);
                DataInit.isRightRun = true;
                ucDoctorOperater fq = new ucDoctorOperater(inPatient);
                App.UsControlStyle(fq);
                App.AddNewBusUcControl(fq, "病人文书");

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 查看PACS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pACSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = dgv.CurrentRow.Cells["id"].Value.ToString();
                InPatientInfo inPatient = BASE_COMMON.DataInit.GetInpatientInfoByPid(patient_id);
                App.frmShowPACS(inPatient);
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 查看LIS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string pid = dgv.CurrentRow.Cells["pid"].Value.ToString();
                App.frmShowLIS(pid);
            }
            catch (Exception ex)
            {

            }
        }

        private void 手术麻醉报告ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = dgv.CurrentRow.Cells["id"].Value.ToString();
                InPatientInfo inPatient = BASE_COMMON.DataInit.GetInpatientInfoByPid(patient_id);
                App.frmShowSSMZ(inPatient);
            }
            catch (Exception ex)
            { }
        }

        private void 医嘱单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = dgv.CurrentRow.Cells["id"].Value.ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);
                App.frmShowYZ(inPatient);
            }
            catch (Exception ex)
            { }
        }


        

    }
}
