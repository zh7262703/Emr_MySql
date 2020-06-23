using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost.WebReference;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class UCSearchByDay : UserControl
    {
        public UCSearchByDay()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }
        //���ݼ�
        DataSet ds = null;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = null;
            dgvList.Columns.Clear();
            //����
            string sql_section = "select a.sid,a.section_name from t_sectioninfo a inner join t_section_area b on a.sid=b.sid";
            //Σ��ֵ����
            string sql_patient = "select distinct a.id,a.pid,a.patient_name,a.gender_code,a.sick_bed_id,a.sick_bed_no,a.section_id,a.section_name,a.sick_doctor_name from t_in_patient a " +
                                " inner join t_lis_sample b on a.pid=b.mzh " +
                                " inner join t_lis_result c on b.bblsh=c.bblsh" +
                                " inner join t_inhospital_action d on a.id=d.pid" +
                                " where (c.xmjg='����' or c.jgbz='L' or c.jgbz='H') and to_char(b.jyrq,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "' and a.document_state is null and d.next_id=0 and d.action_type<>'����'";


            Class_Table[] tables = new Class_Table[2];
            tables[0] = new Class_Table();
            tables[0].Sql = sql_section;
            tables[0].Tablename = "section";

            tables[1] = new Class_Table();
            tables[1].Sql = sql_patient;
            tables[1].Tablename = "patient";

            ds = App.GetDataSet(tables);

            //ƴ��������
            DataGridViewTextBoxColumn columns1 = new DataGridViewTextBoxColumn();
            columns1.HeaderText = "��������";
            columns1.Name = "��������";
            columns1.DataPropertyName = "��������";
            dgvList.Columns.Add(columns1);
            DataGridViewTextBoxColumn columns2 = new DataGridViewTextBoxColumn();
            columns2.HeaderText = "Σ��ֵ��Ŀ";
            columns2.Name = "Σ��ֵ��Ŀ";
            columns2.DataPropertyName = "Σ��ֵ��Ŀ";

            dgvList.Columns.Add(columns2);

            //ƴ������
            for (int i = 0; i < ds.Tables["section"].Rows.Count; i++)
            {
                DataGridViewRow dgvRow = new DataGridViewRow();
                dgvRow.CreateCells(dgvList);
                dgvRow.Cells[0].Value = ds.Tables["section"].Rows[i]["section_name"];
                dgvRow.Cells[1].Value = GetNum(Convert.ToInt32(ds.Tables["section"].Rows[i]["sid"]));
                dgvList.Rows.Add(dgvRow);
            }
        }

        /// <summary>
        /// ���ݿ���ID��ѯ����������Σ��ֵ��Ŀ
        /// </summary>
        /// <param name="sectionId">����ID</param>
        /// <returns></returns>
        private int GetNum(int sectionId)
        {
            //�õ����Ҳ��˼���
            DataRow[] dr_patient = ds.Tables["patient"].Select("section_id=" + sectionId);
            if (dr_patient != null)
            {
                return dr_patient.Length;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// ���˫���¼����������˻�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null)
            {
                string selectSection = dgvList.CurrentRow.Cells["��������"].Value.ToString();

                //Σ��ֵ����
                string sql_sectionPatient = "select distinct a.pid סԺ��,a.sick_bed_no ����,a.patient_name ����,(case when a.gender_code='0' then '��' else 'Ů' end) �Ա�,a.age ���� ,a.sick_doctor_name �ܴ�ҽ��,a.in_time סԺ���� from t_in_patient a " +
                                    " inner join t_lis_sample b on a.pid=b.mzh " +
                                    " inner join t_lis_result c on b.bblsh=c.bblsh" +
                                    " inner join t_inhospital_action d on a.id=d.pid" +
                                    " where (c.xmjg='����' or c.jgbz='L' or c.jgbz='H') and to_char(b.jyrq,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "' and a.document_state is null and d.next_id=0 and d.action_type<>'����' and a.section_name='" + selectSection + "'";

                frmLis_Query frmlis = new frmLis_Query(sql_sectionPatient);
                frmlis.StartPosition = FormStartPosition.CenterParent;
                frmlis.ShowDialog();
                //DataRow[] dr_patients = ds.Tables["patient"].Select("section_name='"+selectSection+"'");

                ////�����м���תDataTable
                //DataTable dt = ds.Tables["patient"].Clone();
                //for (int i = 0; i < dr_patients.Length; i++)
                //{
                //    dt.ImportRow(dr_patients[i]);
                //}
            }
        }
    }
}
