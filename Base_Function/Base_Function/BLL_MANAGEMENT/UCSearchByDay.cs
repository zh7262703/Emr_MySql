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
        //数据集
        DataSet ds = null;

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvList.DataSource = null;
            dgvList.Columns.Clear();
            //科室
            string sql_section = "select a.sid,a.section_name from t_sectioninfo a inner join t_section_area b on a.sid=b.sid";
            //危机值病人
            string sql_patient = "select distinct a.id,a.pid,a.patient_name,a.gender_code,a.sick_bed_id,a.sick_bed_no,a.section_id,a.section_name,a.sick_doctor_name from t_in_patient a " +
                                " inner join t_lis_sample b on a.pid=b.mzh " +
                                " inner join t_lis_result c on b.bblsh=c.bblsh" +
                                " inner join t_inhospital_action d on a.id=d.pid" +
                                " where (c.xmjg='阳性' or c.jgbz='L' or c.jgbz='H') and to_char(b.jyrq,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "' and a.document_state is null and d.next_id=0 and d.action_type<>'出区'";


            Class_Table[] tables = new Class_Table[2];
            tables[0] = new Class_Table();
            tables[0].Sql = sql_section;
            tables[0].Tablename = "section";

            tables[1] = new Class_Table();
            tables[1].Sql = sql_patient;
            tables[1].Tablename = "patient";

            ds = App.GetDataSet(tables);

            //拼出数据列
            DataGridViewTextBoxColumn columns1 = new DataGridViewTextBoxColumn();
            columns1.HeaderText = "科室名称";
            columns1.Name = "科室名称";
            columns1.DataPropertyName = "科室名称";
            dgvList.Columns.Add(columns1);
            DataGridViewTextBoxColumn columns2 = new DataGridViewTextBoxColumn();
            columns2.HeaderText = "危急值数目";
            columns2.Name = "危急值数目";
            columns2.DataPropertyName = "危急值数目";

            dgvList.Columns.Add(columns2);

            //拼数据行
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
        /// 根据科室ID查询出本科室中危机值数目
        /// </summary>
        /// <param name="sectionId">科室ID</param>
        /// <returns></returns>
        private int GetNum(int sectionId)
        {
            //得到科室病人集合
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
        /// 表格双击事件，调出病人基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvList.CurrentRow != null)
            {
                string selectSection = dgvList.CurrentRow.Cells["科室名称"].Value.ToString();

                //危机值病人
                string sql_sectionPatient = "select distinct a.pid 住院号,a.sick_bed_no 床号,a.patient_name 姓名,(case when a.gender_code='0' then '男' else '女' end) 性别,a.age 年龄 ,a.sick_doctor_name 管床医生,a.in_time 住院日期 from t_in_patient a " +
                                    " inner join t_lis_sample b on a.pid=b.mzh " +
                                    " inner join t_lis_result c on b.bblsh=c.bblsh" +
                                    " inner join t_inhospital_action d on a.id=d.pid" +
                                    " where (c.xmjg='阳性' or c.jgbz='L' or c.jgbz='H') and to_char(b.jyrq,'yyyy-MM-dd')='" + dtpTime.Value.ToString("yyyy-MM-dd") + "' and a.document_state is null and d.next_id=0 and d.action_type<>'出区' and a.section_name='" + selectSection + "'";

                frmLis_Query frmlis = new frmLis_Query(sql_sectionPatient);
                frmlis.StartPosition = FormStartPosition.CenterParent;
                frmlis.ShowDialog();
                //DataRow[] dr_patients = ds.Tables["patient"].Select("section_name='"+selectSection+"'");

                ////数据行集合转DataTable
                //DataTable dt = ds.Tables["patient"].Clone();
                //for (int i = 0; i < dr_patients.Length; i++)
                //{
                //    dt.ImportRow(dr_patients[i]);
                //}
            }
        }
    }
}
