using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.TJBB
{
    public partial class frmkstj_rs : Form
    {
        string sid;
        string hearder;
        string dtistart;
        string dtiend;
        public frmkstj_rs()
        {
            InitializeComponent();
        }

        public frmkstj_rs(string sid_, string hearder_, string start, string end)
        {
            InitializeComponent();

            sid = sid_;
            hearder = hearder_;
            dtistart = start;
            dtiend = end;
        }



        private void frmkstj_rs_Load(object sender, EventArgs e)
        {
            string sql = getSQL();
            DataTable dt = App.GetDataSet(sql).Tables[0];
            dgv.DataSource = dt;
        }

        private string getSQL()
        {
            string sql = "";
            switch (hearder)
            {
                case "入院人数":
                    sql = @"select insection_name as 入院科室,in_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,leave_time as 出院时间,diagnose_name as 初步诊断,in_doctor_name as 管床医生 from t_in_patient a left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1) where to_char(in_time,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' and insection_id='" + sid + "' order by in_time";
                    break;
                case "出院人数":
                    sql = @"select section_name as 当前科室,sick_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,leave_time as 出院时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生,nvl(cc.total_cost,0) as 总费用 from t_in_patient a left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1)  left join convert_cost cc on cc.patient_id=a.id where die_time is not null and die_flag=0 and to_char(die_time,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' and a.section_id='" + sid + "' order by in_time";
                    break;
                case "死亡人数":
                    sql = @"select section_name as 当前科室,sick_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,die_time as 死亡时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生,nvl(cc.total_cost,0) as 总费用 from t_in_patient a left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1)  left join convert_cost cc on cc.patient_id=a.id  where die_time is not null and die_flag=1 and to_char(die_time,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' and a.section_id='" + sid + "' order by in_time";
                    break;
                case "手术人数":
                    sql = @"select section_name as 当前科室,sick_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,b.sssj as 手术时间,leave_time as 出院时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生 from t_in_patient a left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1) inner join (select patient_id,substr(to_char(MEASURE_TIME,'yyyy-MM-dd '),0,11)||substr(describe,instr(describe, '手术_')+3,5) as sssj from T_VITAL_SIGNS where instr(describe,'手术')>0 and to_char(MEASURE_TIME,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "') b on a.id=b.patient_id where a.section_id='" + sid + "' order by a.in_time";
                    break;
                case "二次手术人数":
                    sql = @"select section_name as 当前科室,sick_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,b.sssj as 手术时间,leave_time as 出院时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生 from t_in_patient a left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1) inner join (select patient_id,substr(to_char(MEASURE_TIME,'yyyy-MM-dd '),0,11)||substr(describe,instr(describe, '手术_')+3,5) as sssj from T_VITAL_SIGNS where patient_id in (Select patient_id From T_VITAL_SIGNS where instr(describe,'手术')>0 and to_char(MEASURE_TIME,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' Group By patient_id Having Count(*)>1) and instr(describe,'手术')>0 and to_char(MEASURE_TIME,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "') b on a.id=b.patient_id where a.section_id='" + sid + "' order by a.in_time";
                    break;
                case "输血人次":
                    sql = @"select a.section_name as 当前科室,sick_bed_no as 床号,a.pid as 住院号,a.patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,substr(doc_name,0,16) as 输血时间,leave_time as 出院时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生 from t_patients_doc c left join t_in_patient a on c.patient_id=a.id left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1) where textkind_id=7710818 and substr(doc_name,0,10) between '" + dtistart + "' and '" + dtiend + "' and c.sid='" + sid + "'";
                    break;
                case "抢救人次":
                    sql = @"select a.section_name as 当前科室,sick_bed_no as 床号,a.pid as 住院号,a.patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,substr(doc_name,0,16) as 抢救时间,leave_time as 出院时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生 from t_patients_doc c left join t_in_patient a on c.patient_id=a.id left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1) where textkind_id=132 and substr(doc_name,0,10) between '" + dtistart + "' and '" + dtiend + "' and c.sid='" + sid + "'";
                    break;
                case "病危人数":
                    sql = @"select section_name as 当前科室,sick_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,leave_time as 出院时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生 from t_in_patient a left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1) inner join (select patient_id,count(*) from T_SICKSTATE_CHANGE where state='危' and to_char(CHANGE_TIME,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' group by patient_id) b on a.id=b.patient_id where a.section_id='" + sid + "'";
                    break;
                case "病重人数":
                    sql = @"select section_name as 当前科室,sick_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,leave_time as 出院时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生 from t_in_patient a left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1) inner join (select patient_id,count(*) from T_SICKSTATE_CHANGE where state='重' and to_char(CHANGE_TIME,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' group by patient_id) b on a.id=b.patient_id where a.section_id='" + sid + "'";
                    break;
                case "转入人数":
                    sql = @"select a.section_name as 当前科室,sick_bed_no as 床号,a.pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,c.happen_time as 转入时间,s.section_name as 转入科室,leave_time as 出院时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生 from (select * from t_inhospital_action union select * from T_Inhospital_Action_History) c inner join t_in_patient a on a.id=c.patient_id left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1) left join t_sectioninfo s on c.sid=s.sid where action_type='转入' and to_char(happen_time,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' and c.sid='" + sid + "' order by c.happen_time";
                    break;
                case "转出人数":
                    sql = @"select a.section_name as 当前科室,sick_bed_no as 床号,a.pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,c.happen_time as 转出时间,s.section_name as 转出科室,leave_time as 出院时间,diagnose_name as 初步诊断,sick_doctor_name as 管床医生 from (select * from t_inhospital_action union select * from T_Inhospital_Action_History) c inner join t_in_patient a on a.id=c.patient_id left join t_diagnose_item d on a.id=d.patient_id and d.id in (select id from t_diagnose_item where diagnose_type=403 and text_id=6973567 and patient_id=a.id and rownum=1) left join t_sectioninfo s on c.sid=s.sid where action_type='转出' and to_char(happen_time,'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' and c.sid='" + sid + "' order by c.happen_time";
           
                    break;
                case "恶性肿瘤术前术后病理符合人数":
                    sql = @"select section_name as 当前科室,sick_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,leave_time as 出院时间,d.name as 出院诊断,sick_doctor_name as 管床医生 from t_in_patient a left join   cover_diagnose d on a.id =
                                                         d.patient_id and type = 'M' inner join (select patient_id, count(*)
               from COVER_APPEND_QAS
              where ISCANCER='Y'
                and to_char(create_time, 'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' group by patient_id) b on a.id=b.patient_id where a.section_id='" + sid + "'";
                    break;

                case "术中冰冻切片术后石蜡符合人数":
                    sql = @"select section_name as 当前科室,sick_bed_no as 床号,pid as 住院号,patient_name as 姓名,case when Gender_Code=0 then '男' else '女' end as 性别,age||age_unit as 年龄,in_time as 入院时间,leave_time as 出院时间,d.name as 出院诊断,sick_doctor_name as 管床医生 from t_in_patient a left join  cover_diagnose d on a.id =
                                                         d.patient_id and type = 'M'  inner join (select patient_id, count(*)
               from COVER_APPEND_QAS
              where ISPARAFFIN_DIAGNOSIS='Y'
                and to_char(create_time, 'yyyy-MM-dd') between '" + dtistart + "' and '" + dtiend + "' group by patient_id) b on a.id=b.patient_id where a.section_id='" + sid + "'";
                    break;
            }
            return sql;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataInit.DataToExcel(dgv);
        }
    }
}
