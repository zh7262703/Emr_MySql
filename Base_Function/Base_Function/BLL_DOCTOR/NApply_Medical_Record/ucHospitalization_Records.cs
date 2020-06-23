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
        /// 住院号
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }

        private string pname;
        /// <summary>
        /// 姓名, 郧西妇幼根据姓名查询.
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
        /// 查询统计       
        /// </summary>
        private void CheckData()
        {
            try
            {
                //string Sql = "select distinct t.id,t.section_name as 科室,t.patient_name as 姓名," +
                //             "t.pid as 住院号,t.in_time as 入区时间,case when (select count(tid) from T_PATIENTS_DOC a1 where a1.textkind_id in (125,119) and a1.patient_id=t.id)=2 then '两个都写了' when (select count(tid) from T_PATIENTS_DOC a1 where a1.textkind_id=125 and a1.patient_id=t.id)=1 then '首次病程' else '入院记录' end 所写首程或入院记录,case when (select count(tid) from T_PATIENTS_DOC a2 where a2.patient_id=t.id and a2.submitted='Y' and a2.textkind_id=158)>0 then '完成' else '未完成' end 出院记录,case when (select c.action_type from t_inhospital_action c where c.next_id=0 and c.action_state=3 and c.pid=t.id and rownum=1)='出区' then '是' else '否' end 是否出院," +
                //             "t.sick_doctor_name 管床医生 from t_in_patient t " +
                //             "inner join T_PATIENTS_DOC b on b.patient_id=t.id " +
                //             "where b.textkind_id=125 or b.textkind_id=119 order by t.section_name";
                
                string Sql = "select a.id,"+
                            "a.patient_name as 病人姓名," +
                            "a.gender_code as 性别," +
                            "a.pid as 住院号," +
                            "a.in_time as 入院时间," +
                            "a.die_time as 出院时间," +
                            "a.Section_Name as 科室名称," +
                            "a.Document_State as 归档状态 " +
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
                    
                    
                    if (ucGridviewX1.fg["性别", i].Value.ToString() == "1")
                    {
                        ucGridviewX1.fg["性别", i].Value = "女";
                    }
                    else if (ucGridviewX1.fg["性别", i].Value.ToString() == "0")
                    {
                        ucGridviewX1.fg["性别", i].Value = "男";
                    }
                    if (ucGridviewX1.fg["归档状态", i].Value.ToString() == "1")
                    {
                        ucGridviewX1.fg["归档状态", i].Value = "已归档";
                    }
                    else
                    {
                        ucGridviewX1.fg["归档状态", i].Value = "未归档";
                    }
                }
                ucGridviewX1.fg.Refresh();

            }
            catch//(Exception ex)
            {
                //App.MsgErr("查询出错，原因："+ex.ToString());
            }
        }

        private void fg_Sorted(object sender, EventArgs e)
        {
            //for (int i = 0; i < ucGridviewX1.fg.RowCount; i++)
            //{
            //    if (ucGridviewX1.fg["出院记录", i].Value != null)
            //    {
            //        if (ucGridviewX1.fg["出院记录", i].Value.ToString() == "未完成")
            //        {
            //            if (ucGridviewX1.fg["是否出院", i].Value.ToString() == "是")
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
                //获取病人ID
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
                        App.AddNewBusUcControl(fq, "病人文书");
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
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucHospitalization_Records_Load(object sender, EventArgs e)
        {
            CheckData();
        }
    }
}
