using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.TJBB
{
    public partial class UCkstj : UserControl
    {
        public UCkstj()
        {
            InitializeComponent();
        }

        string start = "";
        string end = "";
        bool is_sick = false;

        private void UCkstj_Load(object sender, EventArgs e)
        {
            BindSection();
            if (App.UserAccount.CurrentSelectRole.Role_type == "D")
            {
                cboSection.SelectedValue = App.UserAccount.CurrentSelectRole.Section_Id;
                cboSection.Enabled = false;
            }
            else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                BindSection(App.UserAccount.CurrentSelectRole.Sickarea_Id);
            }
            else
            {
                cboSection.SelectedValue = 0;
            }

        }

        /// <summary>
        /// 绑定科室
        /// </summary>
        private void BindSection()
        {
            string sql = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
            DataSet ds = App.GetDataSet(sql);
            //插入默认选项
            if (ds != null)
            {
                DataRow dr = ds.Tables[0].NewRow();
                dr["sid"] = 0;
                dr["section_name"] = "全院";
                ds.Tables[0].Rows.InsertAt(dr, 0);
            }
            cboSection.DataSource = ds.Tables[0].DefaultView;
            cboSection.DisplayMember = "section_name";
            cboSection.ValueMember = "sid";
            cboSection.SelectedIndex = 0;
        }


        /// <summary>
        /// 绑定科室
        /// </summary>
        private void BindSection(string said)
        {
            string sql = "select sid,section_name from t_sectioninfo where enable_flag='Y' and sid in (select sid from t_section_area where said='" + said + "')";
            DataSet ds = App.GetDataSet(sql);

            cboSection.DataSource = ds.Tables[0].DefaultView;
            cboSection.DisplayMember = "section_name";
            cboSection.ValueMember = "sid";
            cboSection.SelectedIndex = 0;
            is_sick = true;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = getSQL();
            DataTable dt = App.GetDataSet(sql).Tables[0];
            DataRow hj_dr = dt.NewRow();
            hj_dr[1] = "合计";
            for (int i = 2; i < dt.Columns.Count; i++)
            {
                int num = 0;
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    num += Int32.Parse(dt.Rows[j][i].ToString());
                }
                hj_dr[i] = num;
            }
            dt.Rows.Add(hj_dr);
            dgv.DataSource = dt;
            dgv.Columns["sid"].Visible = false;
        }

        private string getSQL()
        {
            string sel_sql = "";
            string where_sql = "";
            start = dtiStart.Value.ToString("yyyy-MM-dd");
            end = dtiEnd.Value.ToString("yyyy-MM-dd");
            if (cboSection.SelectedIndex != 0 || is_sick)
            {
                where_sql = " and s.sid='" + cboSection.SelectedValue.ToString() + "'";
            }
            sel_sql += @"select s.sid,section_name as 科室,nvl(ry.rs,0) as 入院人数,nvl(cy.rs,0) as 出院人数,nvl(sw.rs,0) as 死亡人数,nvl(ss.rs,0) as 手术人数,nvl(tss.rs,0) as 二次手术人数,nvl(sx.rs,0) as 输血人次,nvl(qj.rs,0) as 抢救人次,nvl(bw.rs,0) as 病危人数,nvl(bz.rs,0) as 病重人数,nvl(zr.rs,0) as 转入人数,     nvl(zc.rs, 0) as 转出人数,
       nvl(exzl.rs, 0) as 恶性肿瘤术前术后病理符合人数,
      nvl(bdqp.rs, 0) as  术中冰冻切片术后石蜡符合人数 from t_sectioninfo s";
            //入院人数
            sel_sql += @" left join (select insection_id as sid,count(*) as rs from t_in_patient where to_char(in_time,'yyyy-MM-dd') between '" + start + "' and '" + end + "'  group by insection_id) ry on s.sid=ry.sid ";
            //出院人数
            sel_sql += @" left join (select section_id as sid,count(*) as rs from t_in_patient where die_time is not null and die_flag=0 and to_char(die_time,'yyyy-MM-dd') between '" + start + "' and '" + end + "' group by section_id) cy on cy.sid=s.sid";
            //死亡人数
            sel_sql += @" left join (select section_id as sid,count(*) as rs from t_in_patient where die_time is not null and die_flag=1 and to_char(die_time,'yyyy-MM-dd') between '" + start + "' and '" + end + "' group by section_id) sw on sw.sid=s.sid";
            //手术人数
            sel_sql += @" left join (select section_id as sid,count(*) as rs from t_in_patient a inner join (select patient_id,count(*) as sscs from T_VITAL_SIGNS where instr(describe,'手术')>0 and to_char(MEASURE_TIME,'yyyy-MM-dd') between '" + start + "' and '" + end + "' group by patient_id) b on a.id=b.patient_id  group by a.section_id) ss on ss.sid=s.sid";
            //2次手术人数
            sel_sql += @" left join (select section_id as sid,count(*) as rs from t_in_patient a inner join (select patient_id,count(*) as sscs from T_VITAL_SIGNS where instr(describe,'手术')>0 and to_char(MEASURE_TIME,'yyyy-MM-dd') between '" + start + "' and '" + end + "' group by patient_id) b on a.id=b.patient_id and b.sscs>1  group by a.section_id) tss on tss.sid=s.sid";
            //输血人数
            sel_sql += @" left join (select sid,count(*) as rs from t_patients_doc where textkind_id=7710818 and substr(doc_name,0,10) between '" + start + "' and '" + end + "' group by sid) sx on sx.sid=s.sid";
            //抢救人数
            sel_sql += @" left join (select sid,count(*) as rs from t_patients_doc where textkind_id=132 and substr(doc_name,0,10) between '" + start + "' and '" + end + "' group by sid) qj on qj.sid=s.sid";
            //病危人数
            sel_sql += @" left join (select section_id as sid,count(*) as rs from t_in_patient a inner join (select patient_id,count(*) from T_SICKSTATE_CHANGE where state='危' and to_char(CHANGE_TIME,'yyyy-MM-dd') between '" + start + "' and '" + end + "' group by patient_id) b on a.id=b.patient_id group by a.section_id) bw on bw.sid=s.sid";
            //病重人数
            sel_sql += @" left join (select section_id as sid,count(*) as rs from t_in_patient a inner join (select patient_id,count(*) from T_SICKSTATE_CHANGE where state='重' and to_char(CHANGE_TIME,'yyyy-MM-dd') between '" + start + "' and '" + end + "' group by patient_id) b on a.id=b.patient_id group by a.section_id) bz on bz.sid=s.sid";
            //转入人数
            sel_sql += @" left join (select sid,count(*) as rs from (select * from t_inhospital_action union select * from T_Inhospital_Action_History) where action_type='转入' and to_char(happen_time,'yyyy-MM-dd') between '" + start + "' and '" + end + "' group by sid) zr on zr.sid=s.sid";
            //转出人数
            sel_sql += @" left join (select sid,count(*) as rs from (select * from t_inhospital_action union select * from T_Inhospital_Action_History) where action_type='转出' and to_char(happen_time,'yyyy-MM-dd') between '" + start + "' and '" + end + "' group by sid) zc on zc.sid=s.sid";
            //恶性肿瘤术前术后病理符合人数
            sel_sql += @" left join (select p.section_id as sid,count(*) as rs from COVER_APPEND_QAS a inner join t_in_patient p on a.patient_id =p.id where a.ISCANCER='Y' and to_char(a.create_time, 'yyyy-MM-dd') between
                                '" + start + "' and '"+end+"' group by p.section_id) exzl on exzl.sid =s.sid";
            //术中冰冻切片术后石蜡符合人数
            sel_sql += @" left join (select p.section_id as sid,count(*) as rs from COVER_APPEND_QAS a inner join t_in_patient p on a.patient_id =p.id where a.ISPARAFFIN_DIAGNOSIS='Y' and to_char(a.create_time, 'yyyy-MM-dd') between
                                '" + start + "' and '" + end + "' group by p.section_id) bdqp on bdqp.sid =s.sid";

            //科室条件
            sel_sql += @" where 1=1 " + where_sql + " order by s.sid";

            return sel_sql;
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex > 1)
            {
                string sid = dgv.Rows[e.RowIndex].Cells["sid"].Value.ToString();
                string hearder = dgv.Columns[e.ColumnIndex].HeaderText;
                string value = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (sid != "" && value != "0")
                {
                    frmkstj_rs frm = new frmkstj_rs(sid, hearder, start, end);
                    frm.ShowDialog();
                }
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataInit.DataToExcel(dgv);
        }
    }
}
