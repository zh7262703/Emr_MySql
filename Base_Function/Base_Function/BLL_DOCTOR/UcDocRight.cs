using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
//using Bifrost_Doctor.CommonClass;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;

namespace Base_Function.BLL_DOCTOR
{
    public partial class UcDocRight : UserControl
    {
        public delegate void RefEventHandler(object sender, DocRight_EventArgs e);

        /// <summary>
        /// 浏览文书
        /// </summary>
        public event RefEventHandler browse_Book;
        public UcDocRight()
        {
            InitializeComponent();
            ShowGrid();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvPatientList.DataSource = null;
            ShowGrid();

        }

        /// <summary>
        /// 显示表格数据
        /// </summary>
        private void ShowGrid()
        {
            string sql = "select a.patient_name 姓名,a.pid 住院号,a.section_name 当前科室,a.sick_doctor_name 当前管床医生,b.patient_id,b.text_id,b.right_type,b.relation_id,b.begin_time 开始时间,b.end_time 结束时间,b.functions 操作权限 from t_in_patient a inner join t_set_text_rights b on a.id=b.patient_id where a.document_state is null and b.end_time > sysdate ";
            if (txtName.Text != "")
            {
                sql += " and patient_name like '" + txtName.Text + "%'";
            }
            if (txtPid.Text != "")
            {
                sql += " and pid like '%" + txtPid.Text + "%'";
            }
            try
            {
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {

                    

                    string section_id=App.UserAccount.CurrentSelectRole.Section_Id;
                    if (section_id == "")
                    {
                        DataSet ds_sections = App.GetDataSet("select a.sid,a.section_name from t_sectioninfo a inner join t_section_area b on a.sid=b.sid where b.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id+ "");
                        section_id = ds_sections.Tables[0].Rows[0]["sid"].ToString();
                    }

                    //1.首先筛选出right_type='s'的。
                    DataRow[] dr_Section = ds.Tables[0].Select("RIGHT_TYPE='S' and RELATION_ID<>'" + section_id + "'");
                    //2.筛选出right_type='p'的个人模版
                    DataRow[] dr_P = ds.Tables[0].Select("RIGHT_TYPE='P' and RELATION_ID<>'" + App.UserAccount.UserInfo.User_id + "'");

                    if (dr_Section.Length > 0)
                    {
                        for (int i = 0; i < dr_Section.Length; i++)
                        {
                            if (!dr_Section[i]["relation_id"].ToString().Contains(section_id))
                                ds.Tables[0].Rows.Remove(dr_Section[i]);
                        }
                    }
                    if (dr_P.Length > 0)
                    {
                        for (int i = 0; i < dr_P.Length; i++)
                        {
                            if (!dr_P[i]["relation_id"].ToString().Contains(App.UserAccount.UserInfo.User_id))
                                ds.Tables[0].Rows.Remove(dr_P[i]);
                        }
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dgvPatientList.DataSource = ds.Tables[0];
                        //隐藏列
                        dgvPatientList.Columns["PATIENT_ID"].Visible = false;
                        dgvPatientList.Columns["TEXT_ID"].Visible = false;
                        dgvPatientList.Columns["RIGHT_TYPE"].Visible = false;
                        dgvPatientList.Columns["RELATION_ID"].Visible = false;
                        //dgvPatientList.Columns["FUNCTIONS"].Visible = false;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }


        public void dgvPatientList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvPatientList.Rows.Count > 0)
            {
                DataInit.boolAgree = false;
                DocRight_EventArgs args = new DocRight_EventArgs();
                args.Id = Convert.ToInt32(dgvPatientList.SelectedRows[0].Cells["patient_id"].Value);
                args.Functions = dgvPatientList.SelectedRows[0].Cells["操作权限"].Value.ToString();
                if (browse_Book != null)
                {
                    browse_Book(sender, args);
                }
                Form f = this.Parent as Form;
                f.Close();
            }
        }


    }
}
