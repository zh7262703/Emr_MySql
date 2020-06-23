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
        /// ����
        /// </summary>
        private void DataLoad()
        {
            //����
            string sql = "select t.id,t.textname from t_text t where t.id in('2222','13669957','50950232','13','50000062','14','50000036','295','2034','2035','2036','2037','2031')";
            DataSet ds_Text = App.GetDataSet(sql);
            DataTable dt_Text = ds_Text.Tables[0];
            DataRow row_Text = dt_Text.NewRow();
            row_Text[0] = 0;
            row_Text[1] = "��ѡ��...";
            dt_Text.Rows.InsertAt(row_Text, 0);
            this.cbxText.DisplayMember = "textname";
            this.cbxText.ValueMember = "id";
            this.cbxText.DataSource = dt_Text;
            this.cbxText.SelectedIndex = 0;
            //����
            sql = "select distinct ts.said,ts.sick_area_name from t_sickareainfo ts inner join t_section_area ta on ts.said=ta.said where ts.enable_flag='Y' order by sick_area_name";
            DataSet ds_Ward = App.GetDataSet(sql);
            DataTable dt_Ward = ds_Ward.Tables[0];
            DataRow row_Ward = dt_Ward.NewRow();
            row_Ward[0] = 0;
            row_Ward[1] = "��ѡ��...";
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
                /*1.�������ͷ�Ϊ���֣�
                //    1��סԺ���˵���/׹��������������֪����
                //    2��ѹ��������Ԥ����ؼ�¼����
                //    3�����ز����ϱ���
                     * 4.��Ժ����������
                     * 5.Σ�ػ��߻���ƻ���
                     * 6.���Ʋ��˵���/׹��������������֪��
                     * 7.סԺ��������/׹��������������֪��
                //2�������ɹ��ı�־���ݵ���������жϣ�����һ������һ�����ݴ�Ĳ�������
                //3��˫���ܼƱ����������֣�����벡����ϸ�б�
                //4�����ӵ���excel��ť��
                //5. ����ԪĬ�ϲ�ѡ����ѡʱ������л���Ԫ�����ݣ�ѡ�񵥸�����Ԫʱ����û���Ԫ���ݡ�
                //6������ԪΪ���鴴��ʱ�������ڵĻ���Ԫ�����ǹ�����Ȩ��¼������ʾ����Ȩ�ʺ����ڵĻ���Ԫ��
                */
                string sql = "";
                string sqlwhere = "";
                Boolean bl = false;
                if (cbxWard.SelectedIndex != 0)
                {//��������ѯ
                    bl = true;
                    dgv.ContextMenuStrip = contextMenuStrip1;
                    sql = @"select row_number() over(order by tp.sick_area_name,ti.patient_name,tp.doc_name) ���,tp.sick_area_name ����,
                            ti.patient_name ��������,(CASE ti.gender_code WHEN '1' THEN 'Ů' WHEN '0' THEN '��' end) �Ա�,tp.doc_name ���鴴��ʱ��,ti.id,ti.pid
                            from t_patients_doc tp inner join t_in_patient ti on tp.patient_id=ti.id 
                            where tp.submitted='Y' {0}  
                            order by tp.sick_area_name,ti.patient_name,tp.doc_name";
                    sqlwhere += " and tp.sick_area_name ='" + cbxWard.Text + "' ";
                }
                else
                {
                    dgv.ContextMenuStrip = null;
                    sql = @"select row_number() over(order by tp.sick_area_name) ���,tp.sick_area_name ����,count(tp.textname) �ܼ� 
                                from t_patients_doc tp 
                                inner join t_in_patient ti on tp.patient_id=ti.id 
                                inner join t_sickareainfo ts on tp.sick_area_name=ts.sick_area_name
                                where tp.submitted='Y' {0}  group by tp.sick_area_name order by tp.sick_area_name ";
                }
                if (cbxText.SelectedIndex != 0)
                {//�������ѯ
                    sqlwhere += " and textkind_id ='" + cbxText.SelectedValue.ToString() + "'";
                }
                else
                {
                    sqlwhere += " and tp.textkind_id in('2222','13669957','50950232','13','50000062','14','50000036','295','2034','2035','2036','2037','2031') ";
                }
                if (chbTime.Checked)
                {//ʱ������
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
            //saveFileDialog1.FileName = "����ͳ��.xls";
            //saveFileDialog1.Filter = "Excel������(*.xls)|*.xls";
            //saveFileDialog1.ShowDialog();
        }


        private void DataToExcel(DataGridViewX m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "����EXECL�ļ�";
            kk.Filter = "EXECL�ļ�(*.xls) |*.xls |�����ļ�(*.*) |*.*";
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
                MessageBox.Show(this, "����EXCEL�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string patient_id = dgv.CurrentRow.Cells["id"].Value.ToString();
                InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(patient_id);
                DataInit.isRightRun = true;
                ucDoctorOperater fq = new ucDoctorOperater(inPatient);
                App.UsControlStyle(fq);
                App.AddNewBusUcControl(fq, "��������");

            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// �鿴PACS
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
        /// �鿴LIS
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

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void ҽ����ToolStripMenuItem_Click(object sender, EventArgs e)
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
