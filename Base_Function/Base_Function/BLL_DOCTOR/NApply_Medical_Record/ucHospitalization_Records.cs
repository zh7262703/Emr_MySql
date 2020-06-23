using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
//using Bifrost_Hospital_Management.CommonClass;

namespace Base_Function.BLL_DOCTOR.NApply_Medical_Record
{
    public partial class ucHospitalization_Records : UserControl
    {
        private string pid;
        /// <summary>
        /// סԺ��
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        private string pname;
        /// <summary>
        /// ����, �������׸���������ѯ.
        /// </summary>
        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }

        public ucHospitalization_Records()
        {
            InitializeComponent();
        }

        public ucHospitalization_Records(string pname)
        {
            InitializeComponent();
            Pname = pname;
            ucGridviewX1.fg.Sorted += new EventHandler(fg_Sorted);
            ucGridviewX1.fg.DoubleClick += new EventHandler(fg_DoubleClick);
            ucGridviewX1.fg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// ��ѯͳ��       
        /// </summary>
        private void CheckData()
        {
            try
            {
                //string Sql = "select distinct t.id,t.section_name as ����,t.patient_name as ����," +
                //             "t.pid as סԺ��,t.in_time as ����ʱ��,case when (select count(tid) from T_PATIENTS_DOC a1 where a1.textkind_id in (125,119) and a1.patient_id=t.id)=2 then '������д��' when (select count(tid) from T_PATIENTS_DOC a1 where a1.textkind_id=125 and a1.patient_id=t.id)=1 then '�״β���' else '��Ժ��¼' end ��д�׳̻���Ժ��¼,case when (select count(tid) from T_PATIENTS_DOC a2 where a2.patient_id=t.id and a2.submitted='Y' and a2.textkind_id=158)>0 then '���' else 'δ���' end ��Ժ��¼,case when (select c.action_type from t_inhospital_action c where c.next_id=0 and c.action_state=3 and c.pid=t.id and rownum=1)='����' then '��' else '��' end �Ƿ��Ժ," +
                //             "t.sick_doctor_name �ܴ�ҽ�� from t_in_patient t " +
                //             "inner join T_PATIENTS_DOC b on b.patient_id=t.id " +
                //             "where b.textkind_id=125 or b.textkind_id=119 order by t.section_name";
                
                string Sql = "select a.id,"+
                            "a.patient_name as ��������," +
                            "a.gender_code as �Ա�," +
                            "a.pid as סԺ��," +
                            "a.in_time as ��Ժʱ��," +
                            "a.die_time as ��Ժʱ��," +
                            "a.Section_Name as ��������," +
                            "a.Document_State as �鵵״̬ " +
                            " from t_in_patient a where a.PATIENT_NAME='" + Pname + "' and die_time is not null  order by a.id";

                ucGridviewX1.DataBd(Sql, "id", "", "");
                ucGridviewX1.fg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                ucGridviewX1.fg.Columns["id"].Visible = false;
                ucGridviewX1.fg.ReadOnly = true;

                /*
                 * 
                 */
                for (int i = 0; i < ucGridviewX1.fg.RowCount; i++)
                {
                    
                    
                    if (ucGridviewX1.fg["�Ա�", i].Value.ToString() == "1")
                    {
                        ucGridviewX1.fg["�Ա�", i].Value = "Ů";
                    }
                    else if (ucGridviewX1.fg["�Ա�", i].Value.ToString() == "0")
                    {
                        ucGridviewX1.fg["�Ա�", i].Value = "��";
                    }
                    if (ucGridviewX1.fg["�鵵״̬", i].Value.ToString() == "1")
                    {
                        ucGridviewX1.fg["�鵵״̬", i].Value = "�ѹ鵵";
                    }
                    else
                    {
                        ucGridviewX1.fg["�鵵״̬", i].Value = "δ�鵵";
                    }
                }
                ucGridviewX1.fg.Refresh();

            }
            catch//(Exception ex)
            {
                //App.MsgErr("��ѯ����ԭ��"+ex.ToString());
            }
        }

        private void fg_Sorted(object sender, EventArgs e)
        {
            //for (int i = 0; i < ucGridviewX1.fg.RowCount; i++)
            //{
            //    if (ucGridviewX1.fg["��Ժ��¼", i].Value != null)
            //    {
            //        if (ucGridviewX1.fg["��Ժ��¼", i].Value.ToString() == "δ���")
            //        {
            //            if (ucGridviewX1.fg["�Ƿ��Ժ", i].Value.ToString() == "��")
            //            {
            //                for (int j = 0; j < ucGridviewX1.fg.Columns.Count; j++)
            //                {
            //                    ucGridviewX1.fg[j, i].Style.ForeColor = Color.Red;
            //                }
            //            }
            //        }
            //    }
            //}
        }


        private void fg_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                //��ȡ����ID
                string id = ucGridviewX1.fg.SelectedRows[0].Cells[0].Value.ToString();

                string sql = "select * from t_in_patient t where t.id='" + id + "'";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        InPatientInfo patientInfo = new InPatientInfo();
                        patientInfo = DataInit.InitPatient(ds.Tables[0].Rows[0]);
                        ucDoctorOperater fq = new ucDoctorOperater(patientInfo);
                        //frmMain fq = new frmMain(patientInfo, true, patientInfo.Id);
                        App.AddNewBusUcControl(fq, "��������");
                        ((Form)this.ParentForm).Close();
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }

        /// <summary>
        /// ��������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucHospitalization_Records_Load(object sender, EventArgs e)
        {
            CheckData();
        }
    }
}
