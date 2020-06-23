using Bifrost;
using DevComponents.DotNetBar.Controls;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    public partial class ucfrmStochasticRepartType : UserControl
    {
        public ucfrmStochasticRepartType()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            try
            {
                string strCreatetime = dateTimePickerIN_OUT_time.Text.ToString();
                string strSql = "select t.id, t.name as ��������,t.createtime as ����ʱ��,(select count(*) from T_DATA_STOCHASTIC_DETAIL where type=t.id) as ���� from T_DATA_STOCHASTIC_TYPE t  where to_char(t.createtime,'yyyy-MM')='" + strCreatetime + "'";
                DataSet ds = App.GetDataSet(strSql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
                    dataGridViewX1.Columns["id"].Visible = false;
                    dataGridViewX1.Columns["����ʱ��"].Width = 200;
                }
                else
                {
                    App.Msg("��ǰû�з��ϲ�ѯ���������ݣ�");
                    return;
                }
            }
            catch
            {

            }
        }
        private void dataGridViewX1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// ˫��ĳһ�н��в�ѯ��ϸ��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewX1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String strId = dataGridViewX1.CurrentRow.Cells["id"].Value.ToString();
                if (strId != "")
                {
                    frmStochasticRepart frm = new frmStochasticRepart(strId);
                    frm.ShowDialog();
                }
                else
                {
                    App.Msg("��˫��ĳһ�����ݽ��в�����");
                    return;
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                DataToExcel(dataGridViewX1);
            }
            catch
            {

            }
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="m_DataView"></param>
        public void DataToExcel(DataGridViewX m_DataView)
        {
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "����EXECL�ļ�";
            kk.Filter = "EXECL�ļ�(*.xls) |*.xls |�����ļ�(*.*) |*.*";
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
                MessageBox.Show(this, "����EXCEL�ɹ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
