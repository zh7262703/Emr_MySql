using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.UnFinished
{
    public partial class ucDSQWS : UserControl
    {
        public ucDSQWS()
        {
            InitializeComponent();
        }

        public ucDSQWS(string secid, string userid, string patientid)
        {
            InitializeComponent();

            //A、 上级医师：书写“上级查房”中所选择上级医师来进行提醒。
            string sql = @"select ti.pid 住院号,ti.patient_name 患者姓名,ti.sick_bed_no 床号,to_char(ti.in_time,'yyyy-MM-dd hh24:mi') 入院时间,
                        '上级查房' 类型,tp.doc_name 详细, tu.user_name 创建人
                        from t_patients_doc tp 
                        inner join t_in_patient ti on tp.patient_id=ti.id
                        inner join t_userinfo tu on tp.createid=tu.user_id
                        where ti.section_id='{0}' and tp.highersignuserid='{1}' {2}";
            sql += " union all ";


            //B、 带教医师：附属账号所书写且带教未审签文书、诊断，对其带教医师进行提醒。
            sql += @"select ti.pid 住院号,ti.patient_name 患者姓名,ti.sick_bed_no 床号,to_char(ti.in_time,'yyyy-MM-dd hh24:mi') 入院时间,
                        '未审签文书' 类型,tp.doc_name 详细, tu.user_name 创建人
                        from t_patients_doc tp 
                        inner join t_in_patient ti on tp.patient_id=ti.id
                        inner join t_userinfo tu on tp.createid=tu.user_id
                        where ti.section_id='{0}' and tu.guid_doctor_id='{1}' {2}";
            sql += " union all ";

            //诊断
            sql += @"select ti.pid 住院号,ti.patient_name 患者姓名,ti.sick_bed_no 床号,to_char(ti.in_time,'yyyy-MM-dd hh24:mi') 入院时间,
                    '未审签诊断' 类型,tc.name||(case td.is_chinese when 'N' then '(西医)' when 'Y' then '(中医)' end)  详细, tu.user_name 创建人
                    from t_diagnose_item td 
                    inner join t_in_patient ti on td.patient_id=ti.id
                    inner join t_data_code tc on td.diagnose_type=tc.id
                    inner join t_userinfo tu on td.fssx_id=tu.user_id
                    where  td.yjsx_id is null and td.ejsx_id is null and td.sjsx_id is null and ti.section_id='{0}' and tu.guid_doctor_id='{1}' {2}";
            sql += " union all ";
            //C、 普通医师：有未提交文书的普通医师。
            sql += @"select ti.pid 住院号,ti.patient_name 患者姓名,ti.sick_bed_no 床号,to_char(ti.in_time,'yyyy-MM-dd hh24:mi') 入院时间,
                    '未提交文书' 类型,tp.doc_name 详细, tu.user_name 创建人
                    from t_patients_doc tp 
                    inner join t_in_patient ti on tp.patient_id=ti.id
                    inner join t_userinfo tu on tp.createid=tu.user_id
                    where tp.submitted='N' and ti.section_id='{0}' and tp.createid='{1}' {2}";


            string whereID = "";
            if (patientid != "")
                whereID = " and ti.id=" + patientid;
            sql = string.Format(sql, secid, userid, whereID);
            sql = @"select * from (" + sql + ") order by 住院号,类型,详细 desc";
            DataSet ds = App.GetDataSet(sql);

            DataTable dt = ds.Tables[0];
            if (dt != null)
            {
                //for (int i = 0; i < dt.Rows.Count; i++)
                //{//添加序号值
                //    dt.Rows[i]["序号"] = i + 1;
                //}
                dgvListxx.DataSource = dt;
            }
        }

        /// <summary>
        /// 拼接sql
        /// </summary>
        /// <returns></returns>
        private string getSql()
        {
            //A、 上级医师：书写“上级查房”中所选择上级医师来进行提醒。
            string sql = @"select ti.pid 住院号,ti.patient_name 患者姓名,ti.sick_bed_no 床号,to_char(ti.in_time,'yyyy-MM-dd hh24:mi') 入院时间,
                        '上级查房' 类型,tp.doc_name 详细, tu.user_name 创建人
                        from t_patients_doc tp 
                        inner join t_in_patient ti on tp.patient_id=ti.id
                        inner join t_userinfo tu on tp.createid=tu.user_id
                        where ti.section_id='{0}' and tp.highersignuserid='{1}' ";
            sql += " union all ";


            //B、 带教医师：附属账号所书写且带教未审签文书、诊断，对其带教医师进行提醒。
            sql += @"select ti.pid 住院号,ti.patient_name 患者姓名,ti.sick_bed_no 床号,to_char(ti.in_time,'yyyy-MM-dd hh24:mi') 入院时间,
                        '未审签文书' 类型,tp.doc_name 详细, tu.user_name 创建人
                        from t_patients_doc tp 
                        inner join t_in_patient ti on tp.patient_id=ti.id
                        inner join t_userinfo tu on tp.createid=tu.user_id
                        where ti.section_id='{0}' and tu.guid_doctor_id='{1}' ";
            sql += " union all ";

            //诊断
            sql += @"select ti.pid 住院号,ti.patient_name 患者姓名,ti.sick_bed_no 床号,to_char(ti.in_time,'yyyy-MM-dd hh24:mi') 入院时间,
                    '未审签诊断' 类型,tc.name||(case td.is_chinese when 'N' then '(西医)' when 'Y' then '(中医)' end)  详细, tu.user_name 创建人
                    from t_diagnose_item td 
                    inner join t_in_patient ti on td.patient_id=ti.id
                    inner join t_data_code tc on td.diagnose_type=tc.id
                    inner join t_userinfo tu on td.fssx_id=tu.user_id
                    where  td.yjsx_id is null and td.ejsx_id is null and td.sjsx_id is null and ti.section_id='{0}' and tu.guid_doctor_id='{1}' ";
            sql += " union all ";
            //C、 普通医师：有未提交文书的普通医师。
            sql += @"select ti.pid 住院号,ti.patient_name 患者姓名,ti.sick_bed_no 床号,to_char(ti.in_time,'yyyy-MM-dd hh24:mi') 入院时间,
                    '未提交文书' 类型,tp.doc_name 详细, tu.user_name 创建人
                    from t_patients_doc tp 
                    inner join t_in_patient ti on tp.patient_id=ti.id
                    inner join t_userinfo tu on tp.createid=tu.user_id
                    where tp.submitted='N' and ti.section_id='{0}' and tp.createid='{1}' ";
            return sql;
        }
    }
}
