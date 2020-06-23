using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_NURSE.First_cases;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    /// <summary>
    /// 设计者：连伟
    /// 时  间：2017/02/26
    /// 功  能：入口、查询界面
    /// </summary>
    public partial class MedicalRecordCatalogue : UserControl
    {
        /// <summary>
        /// 声明SQL变量
        /// </summary>
        string Sql = "";
        /// <summary>
        /// 是否启用了时间查询控件
        /// </summary>
        bool Flag = false;
        private InPatientInfo inPatientInfo;
        public MedicalRecordCatalogue()
        {
            InitializeComponent();
            DataInit.A_btnSelect = null;
            DataInit.A_btnSelect += new EventHandler(btnSearch_Click);
            GetName();
            if (App.UserAccount.CurrentSelectRole.Role_type == "B")
            {
                CatalogStatus();
                GetSection();
                ucGridviewX1.fg.DoubleClick += new EventHandler(ucGridviewX1_DoubleClick);
            }
            else
            {
                CatalogStatusDoctor();
                cbxInSection.Text = App.UserAccount.CurrentSelectRole.Section_name;
                this.btn_println.Visible = true;
                ucGridviewX1.fg.Click += new EventHandler(ucGridviewX1_Click);
            }
        }
        /// <summary>
        /// 绑定编目状态
        /// 病案室
        /// </summary>
        private void CatalogStatus()
        {
            string sql = "select id,code,name from t_data_code where type='10944863'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-请选择-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            multiColumnComboBox_State.DisplayMember = "name";
            multiColumnComboBox_State.ValueMember = "code";
            multiColumnComboBox_State.DataSource = dt;
        }
        /// <summary>
        /// 绑定编目状态
        /// 医生站
        /// </summary>
        private void CatalogStatusDoctor()
        {
            string sql = "select id,code,name from t_data_code where type='10945255'";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow row = dt.NewRow();
            row["name"] = "-请选择-";
            row["id"] = "-1";
            dt.Rows.InsertAt(row, 0);
            multiColumnComboBox_State.DisplayMember = "name";
            multiColumnComboBox_State.ValueMember = "code";
            multiColumnComboBox_State.DataSource = dt;
        }
        /// <summary>
        /// 获取科室列表
        /// </summary>
        private void GetSection()
        {
            string sql_section = "select sid,section_name from t_sectioninfo a where a.enable_flag='Y' order by section_name";
            //入院科室
            DataSet ds_inSection = App.GetDataSet(sql_section);
            if (ds_inSection != null)
            {
                DataRow dr_inSection = ds_inSection.Tables[0].NewRow();
                dr_inSection["sid"] = 0;
                dr_inSection["section_name"] = "-请选择-";
                ds_inSection.Tables[0].Rows.InsertAt(dr_inSection, 0);

                cbxInSection.DisplayMember = "section_name";
                cbxInSection.ValueMember = "sid";
                cbxInSection.DataSource = ds_inSection.Tables[0];
            }
        }
        /// <summary>
        /// 获取患者名
        /// </summary>
        private void GetName()
        {
            string sql_name = "select patient_name,name_pinyin from t_in_patient a where a.die_time is not null";
            //入院科室
            DataSet ds_name = App.GetDataSet(sql_name);
            if (ds_name != null)
            {
                DataRow dr_name = ds_name.Tables[0].NewRow();
                dr_name["name_pinyin"] = 0;
                ds_name.Tables[0].Rows.InsertAt(dr_name, 0);

                txt_Name.DisplayMember = "patient_name";
                txt_Name.ValueMember = "name_pinyin";
                txt_Name.DataSource = ds_name.Tables[0];
            }
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*
             * 1.先获取当前最新一条记录的状态
             * 2.查询出当前状态和null的数据
             * 3.重复筛选复杂逻辑**/
            string Sql_1 = "select 状态,住院号,病人ID,姓名,性别,年龄,床号,出院科室,入院时间,出院时间,管床医生,编目时间,编目人,打印次数 from (select row_number() over(partition by 住院号 order by 编目时间 desc) rn,状态,住院号,病人ID,姓名,性别,年龄,床号,出院科室,入院时间,出院时间,管床医生,编目时间,编目人,打印次数 from(select 状态,住院号,病人ID,姓名,性别,年龄,床号,出院科室,入院时间,出院时间,管床医生,max(编目时间) as 编目时间,编目人,打印次数 from(";
            string Sql_2 = "select a.codestate 状态,t.pid 住院号,t.id 病人ID,t.patient_name 姓名,(case when t.gender_code = 0 then '男' else '女' end) 性别,t.age 年龄,t.sick_bed_no 床号,t.section_name 出院科室,t.in_time 入院时间,t.die_time 出院时间,t.sick_doctor_name 管床医生,a.codetime 编目时间,a.codename 编目人, c.pritn 打印次数 from t_in_patient t left join T_IN_Code_Information a on t.id = a.inpatient_id left join T_DEDUCT_SUMMARY b on t.id=b.patient_id left join cover_info c on c.inpatient_id=a.patient_id where 1=1 and b.state in('D','S') and t.die_time is not null";
            string Sql_3 = ") where 1=1 group by 状态,住院号,病人ID,姓名,性别,年龄,床号,出院科室,入院时间,出院时间,管床医生,编目人,打印次数)) where rn=1";

            /*
             * 1.医生评分完成-科室自评完成
             * 2.未完成（已完成评分未编目）
             * 3.暂存
             * 4.已编目
             * 5.已授权(此需求暂定)
             */
            if (multiColumnComboBox_State.Text != "-请选择-")
            {
                if (App.UserAccount.CurrentSelectRole.Role_type == "B")
                {
                    if (multiColumnComboBox_State.SelectedValue.ToString() == "2")
                    {
                        Sql_2 += " and a.codestate is null";//未完成
                    }
                    if (multiColumnComboBox_State.SelectedValue.ToString() == "4")
                    {
                        Sql_2 += " and a.codestate='提交'";//已编目
                    }
                    if (multiColumnComboBox_State.SelectedValue.ToString() == "5")
                    {
                        Sql_2 += " and a.codestate='授权'";//授权
                    }
                }
                else//医生站
                {
                    /*
                     * 2.已编目
                     * 3.未完成
                     * 4.授权未打印
                     * 5.已打印**/
                    if (multiColumnComboBox_State.SelectedValue.ToString() == "3")
                    {
                        Sql_2 += " and a.codestate='提交'";//已编目
                    }
                    if (multiColumnComboBox_State.SelectedValue.ToString() == "2")
                    {
                        Sql_2 += " and a.codestate is null";//未完成
                    }
                    if (multiColumnComboBox_State.SelectedValue.ToString() == "4")
                    {
                        Sql_2 += " and a.codestate='授权' and a.codetype is null";//授权未打印
                    }
                    if (multiColumnComboBox_State.SelectedValue.ToString() == "5")
                    {
                        Sql_2 += " and a.codetype is not null";//已打印
                    }
                }
            }
            //科室
            if (cbxInSection.Text != "-请选择-")
            {
                Sql_2 += " and t.section_name='" + cbxInSection.Text + "'";
            }
            //姓名
            if (txt_Name.Text != "")
            {
                Sql_2 += " and t.patient_name='" + txt_Name.Text + "'";
            }
            //住院号
            if (txt_pid.Text != "")
            {
                Sql_2 += " and t.pid='" + txt_pid.Text + "'";
            }
            //时间
            if (Flag == true && cbx_selectTime.Text == "")
            {
                App.Msg("请选择查询时间条件！");
                return;
            }
            else
            {
                if (Flag == true && cbx_selectTime.Text == "入院时间")
                {
                    Sql_2 += " and to_char(t.in_time,'yyyy-MM-dd') >= '" + dtpStartTime.Value.ToString("yyyy-MM-dd") +
                          "' and to_char(t.in_time,'yyyy-MM-dd') <= '" + dtpEndTime.Value.ToString("yyyy-MM-dd") + "'";
                }
                if (Flag == true && cbx_selectTime.Text == "出院时间")
                {
                    Sql_2 += " and to_char(t.die_time,'yyyy-MM-dd') >= '" + dtpStartTime.Value.ToString("yyyy-MM-dd") +
                          "' and to_char(t.die_time,'yyyy-MM-dd') <= '" + dtpEndTime.Value.ToString("yyyy-MM-dd") + "'";
                }
                if (Flag == true && cbx_selectTime.Text == "编目时间")
                {
                    Sql_2 += " and to_char(a.codetime,'yyyy-MM-dd') >= '" + dtpStartTime.Value.ToString("yyyy-MM-dd") +
                          "' and to_char(a.codetime,'yyyy-MM-dd') <= '" + dtpEndTime.Value.ToString("yyyy-MM-dd") + "'";
                }
            }
            
            string Sqls = Sql_1 + Sql_2 + Sql_3;
            this.ucGridviewX1.DataBd(Sqls, "状态", false, "", "");
            if (App.UserAccount.CurrentSelectRole.Role_type == "B")
            {
                ucGridviewX1.fg.Columns["打印次数"].Visible = false;
                ucGridviewX1.fg.Columns["病人ID"].Visible = false;
            }
            else
            {
                ucGridviewX1.fg.Columns["病人ID"].Visible = false;
            }
            for (int i = 0; i < ucGridviewX1.fg.Rows.Count; i++)
            {
                string a = ucGridviewX1.fg.Rows[i].Cells["打印次数"].Value.ToString();
                if (a == "")
                {
                    ucGridviewX1.fg.Rows[i].Cells["打印次数"].Value = "0";
                }
            }
        }
        /// <summary>
        /// 是否启用时间查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTime_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTime.Checked)
            {
                Flag = true;
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
                cbx_selectTime.Enabled = true;
            }
            else
            {
                Flag = false;
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
                cbx_selectTime.Enabled = false;
            }
        }
        /// <summary>
        /// 双击表格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucGridviewX1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                
                if (ucGridviewX1.fg.CurrentRow == null) { return; }
                int index = ucGridviewX1.fg.CurrentRow.Index;
                string Pid = ucGridviewX1.fg["住院号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                string id = ucGridviewX1.fg["病人ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                FrmMedicalRecord frmMedicalRecord = new FrmMedicalRecord(Pid, id);
                frmMedicalRecord.ShowDialog();
            }
            catch { }
        }
        /// <summary>
        /// 医生站单机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucGridviewX1_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow == null) { return;}
            int index = ucGridviewX1.fg.CurrentRow.Index;
            string state = ucGridviewX1.fg["状态", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
            if (state == "提交")
            {
                this.btn_println.Enabled = true;
            }
            else
            {
                this.btn_println.Enabled = false;
            }
        }
        /// <summary>
        /// 打印
        /// 医生前台
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_println_Click(object sender, EventArgs e)
        {
            //if (ucGridviewX1.fg.CurrentRow == null) { return; }
            //int index = ucGridviewX1.fg.CurrentRow.Index;
            //string ID = ucGridviewX1.fg["病人ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
            //this.inPatientInfo = DataInit.GetInpatientInfoByPid(ID);
            //frmCases_First ucCase_First = new frmCases_First(inPatientInfo);
            //ucCase_First.printCasesFirst();
            //string Sql_Pritn = "select pritn from cover_info where inpatient_id='" + inPatientInfo.PId + "'";
            //string next = App.ReadSqlVal(Sql_Pritn, 0, "pritn");
            //if (next == "") { next = "0"; }
            //int count = int.Parse(next);
            //count += 1;
            //string Sql_Update = "update cover_info set pritn='" + count + "' where inpatient_id='" + inPatientInfo.PId + "'";
            //App.ExecuteSQL(Sql_Update);
            //btnSearch_Click(sender, e);
        }
    }
}
