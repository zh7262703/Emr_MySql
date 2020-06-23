using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class ucTime_Statistics : UserControl
    {
        public ucTime_Statistics()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }
        //列的集合
        ColumnInfo[] cols = new ColumnInfo[13];
        /// <summary>
        /// 数据集
        /// </summary>
        DataSet ds = null;

        /// <summary>
        /// 全局变量，记录查询范围，只有再次查询时，状态才改变
        /// </summary>
        string searchName = "";

        private void ucTime_Statistics_Load(object sender, EventArgs e)
        {
            try
            {
                flgview.MouseHoverCell += new EventHandler(fg_MouseHover);
                flgview.AllowEditing = false;
                TimeUnit();
                setTableHeader();
                CellMerge();
            }
            catch
            { }
        }

        int oldRow = 0;
        /// <summary>
        /// 鼠标停留，行底色改变 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fg_MouseHover(object sender, EventArgs e)
        {
            int Row = flgview.MouseRow;

            if (Row > 0)
            {
                if (Row != oldRow && oldRow <= flgview.Rows.Count)
                {
                    flgview.Rows[Row].StyleNew.BackColor = ColorTranslator.FromHtml("#e9f7f6");
                    flgview.Rows[Row].StyleNew.ForeColor = ColorTranslator.FromHtml("#00619d");
                    flgview.Cursor = Cursors.Hand;
                    flgview.Cols[2].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
                    if (oldRow > 0)
                    {
                        if (oldRow < flgview.Rows.Count && oldRow > 0)
                        {
                            flgview.Rows[oldRow].StyleNew.BackColor = flgview.BackColor;
                            flgview.Rows[oldRow].StyleNew.ForeColor = flgview.ForeColor;
                        }
                    }
                }
                oldRow = Row;
            }
        }
        ////绑定时间统计项目
        //private void TimeItem()
        //{
        //    DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='40'");
        //    cboTimeItem.DataSource = ds.Tables[0].DefaultView;
        //    cboTimeItem.ValueMember = "ID";
        //    cboTimeItem.DisplayMember = "NAME";
        //}
        //绑定时间统计范围
        private void TimeUnit()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='39'");
            cboTimeUnit.DataSource = ds.Tables[0].DefaultView;
            cboTimeUnit.ValueMember = "ID";
            cboTimeUnit.DisplayMember = "NAME";
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            searchName = cboTimeUnit.Text;
            DataSet ds = Get_Search_Data();

            Get_Fill_Grid(ds);
        }

        /// <summary>
        /// 获取查询的数据结果
        /// </summary>
        /// <returns></returns>
        private DataSet Get_Search_Data()
        {
            string dataStart = dtpStart.Value.ToString("yyyy-MM-dd ");
            string dataend = dtpEnd.Value.ToString("yyyy-MM-dd ");
            try
            {
                Bifrost.WebReference.Class_Table[] temtables = new Bifrost.WebReference.Class_Table[15];

                //入院人数
                string sql_into_area = "select a.id,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,a.in_time,a.die_time,'' as 入院诊断,'' as 出院诊断,a.insection_name ,a.section_name ,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a where (select count(id) from t_inhospital_action b where b.patient_id=a.id)>0 and to_char(a.in_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'  ";
                //出院人数
                string sql_out_area = "select distinct a.id,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,a.in_time,a.die_time,'' as 入院诊断,'' as 出院诊断,a.insection_name ,a.section_name ,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where b.next_id=0 and b.ACTION_TYPE='出区' and b.ACTION_STATE=3 and a.die_flag<>1 and to_char(b.HAPPEN_TIME,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'  ";
                //转出人次
                string sql_turn_out = "select distinct a.id, a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,d.section_name ,e.section_name 转入科室,b.happen_time,a.section_name ,b.sid,b.said,f.sick_area_name from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id inner join t_inhospital_action c on a.id=c.patient_id  inner join t_sectioninfo d on b.sid=d.sid inner join t_sectioninfo e on b.target_sid=e.sid inner join t_sickareainfo f on b.said=f.said where b.action_type='转出' and c.action_type='转入' and b.next_id=c.id and to_char(b.happen_time,'yyyy-MM-dd')  between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //转入人次
                string sql_turn_in = "select distinct a.id, a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit) as 年龄,d.section_name 转出科室,e.section_name,c.happen_time,a.section_name ,c.sid,c.said,f.sick_area_name from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id inner join t_inhospital_action c on a.id=c.patient_id  inner join t_sectioninfo d on b.sid=d.sid inner join t_sectioninfo e on b.target_sid=e.sid inner join t_sickareainfo f on c.said=f.said where b.action_type='转出' and c.action_type='转入' and b.next_id=c.id  and to_char(c.happen_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //手术人数
                string sql_operate = "select distinct a.id,a.section_name,e.operator,e.oper_assist1,e.oper_assist2,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit),c.diagnose_name,e.oper_date,e.oper_name,'' as 手术分类,a.birthday,a.section_id,a.in_time,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id left join t_diagnose_item c on a.id=c.patient_id and c.diagnose_type=401 left join COVER_OPERATION e on a.id=e.inpatient_id  where a.id in(select patient_id from t_quality_text g  where g.texttkind_id=151 and to_char(g.create_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "')  ";
                //发会诊人次
                string sql_consultaion_Apply = "select a.*,b.sick_area_id,b.birthday from t_consultaion_apply a inner join t_in_patient b on a.patient_id=b.id inner join t_consultaion_record c on a.id=c.apply_id  where submited='Y' and to_char(a.apply_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' ";
                //接会诊人次
                string sql_consultaion_Accept = "select a.consul_record_section_id,d.said,c.birthday from t_consultaion_record a inner join t_consultaion_apply b on a.apply_id=b.id inner join t_in_patient c on b.patient_id=c.id  inner join t_section_area d on a.consul_record_section_id=d.sid where  a.isrecieve='1'  and b.is_dalete='N' and to_char(consul_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend + "'";
                //治愈人数
                string sql_ZhiYu = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '男' else '女' end sex,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name,a.in_time,a.die_time,a.sick_doctor_id,a.sick_doctor_name,'' as 入院诊断,'' as 出院诊断 from t_In_Patient a inner join t_inhospital_action b on (a.id=b.patient_id) inner join t_diagnose_item c on (a.id=c.patient_id) where b.action_type='出区' and c.turn_to='治愈' and to_char(b.happen_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //好转人数
                string sql_HaoZhuan = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '男' else '女' end sex,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name,a.in_time,a.die_time,a.sick_doctor_id,a.sick_doctor_name,'' as 入院诊断,'' as 出院诊断 from t_In_Patient a inner join t_inhospital_action b on (a.id=b.patient_id) inner join t_diagnose_item c on (a.id=c.patient_id) where b.action_type='出区' and c.turn_to='好转' and  to_char(b.happen_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //死亡人数
                string sql_Death = "select distinct a.id,a.section_name,a.pid,a.patient_name,case when a.gender_code=0 then '男' else '女' end sex,concat(age,age_unit),a.home_address,a.relation_name,a.in_time,'' as 入院诊断,'' as 死亡原因,'' as 死亡时间,sick_doctor_name,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where a.die_flag=1 and to_char(b.happen_time ,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //未愈人数
                string sql_WeiYu = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '男' else '女' end sex,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name,a.in_time,a.die_time,a.sick_doctor_id,a.sick_doctor_name,'' as 入院诊断,'' as 出院诊断 from t_In_Patient a inner join t_inhospital_action b on (a.id=b.patient_id) inner join t_diagnose_item c on (a.id=c.patient_id) where b.action_type='出区' and c.turn_to='未愈' and  to_char(b.happen_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";

                //所有病区
                string sql_allSickArea = "select said,sick_area_name from t_sickareainfo";
                //所有科室
                string sql_allSection = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
                //所有入院诊断
                string sql_allin_diag = "select patient_id,diagnose_name,create_time,diagnose_sort from t_diagnose_item where diagnose_type=408 ";
                //所有出院诊断
                string sql_allout_diag = "select patient_id,diagnose_name,create_time,diagnose_sort from t_diagnose_item where diagnose_type=406";
                temtables[0] = new Bifrost.WebReference.Class_Table();
                temtables[0].Sql = sql_into_area;
                temtables[0].Tablename = "into_area";

                temtables[1] = new Bifrost.WebReference.Class_Table();
                temtables[1].Sql = sql_out_area;
                temtables[1].Tablename = "out_area";

                temtables[2] = new Bifrost.WebReference.Class_Table();
                temtables[2].Sql = sql_turn_out;
                temtables[2].Tablename = "turn_out";

                temtables[3] = new Bifrost.WebReference.Class_Table();
                temtables[3].Sql = sql_turn_in;
                temtables[3].Tablename = "turn_in";

                temtables[4] = new Bifrost.WebReference.Class_Table();
                temtables[4].Sql = sql_operate;
                temtables[4].Tablename = "operate";

                temtables[5] = new Bifrost.WebReference.Class_Table();
                temtables[5].Sql = sql_consultaion_Apply;
                temtables[5].Tablename = "consultaion_Apply";

                temtables[6] = new Bifrost.WebReference.Class_Table();
                temtables[6].Sql = sql_consultaion_Accept;
                temtables[6].Tablename = "consultaion_Accept";

                temtables[7] = new Bifrost.WebReference.Class_Table();
                temtables[7].Sql = sql_ZhiYu;
                temtables[7].Tablename = "zhiyu";

                temtables[8] = new Bifrost.WebReference.Class_Table();
                temtables[8].Sql = sql_HaoZhuan;
                temtables[8].Tablename = "haozhuan";

                temtables[9] = new Bifrost.WebReference.Class_Table();
                temtables[9].Sql = sql_Death;
                temtables[9].Tablename = "death";

                temtables[10] = new Bifrost.WebReference.Class_Table();
                temtables[10].Sql = sql_WeiYu;
                temtables[10].Tablename = "weiyu";

                temtables[11] = new Bifrost.WebReference.Class_Table();
                temtables[11].Sql = sql_allSickArea;
                temtables[11].Tablename = "allSickArea";

                temtables[12] = new Bifrost.WebReference.Class_Table();
                temtables[12].Sql = sql_allSection;
                temtables[12].Tablename = "allSection";

                temtables[13] = new Bifrost.WebReference.Class_Table();
                temtables[13].Sql = sql_allin_diag;
                temtables[13].Tablename = "allin_diag";

                temtables[14] = new Bifrost.WebReference.Class_Table();
                temtables[14].Sql = sql_allout_diag;
                temtables[14].Tablename = "allout_diag";

                ds = App.GetDataSet(temtables);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 将数据填充至表格
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private void Get_Fill_Grid(DataSet ds)
        {
            flgview.Rows.Count = 1;
            if (ds != null)
            {
                //178：全院查询
                if (Convert.ToInt32(cboTimeUnit.SelectedValue.ToString()) == 178)
                {
                    flgview.Rows.Add();
                    //填充数据
                    flgview[1, 0] = "全院";

                    int val = 0;
                    val = ds.Tables["into_area"].Rows.Count;
                    flgview[1, 1] = val;

                    val = ds.Tables["out_area"].Rows.Count;
                    flgview[1, 2] = val;

                    val = ds.Tables["turn_out"].Rows.Count;
                    flgview[1, 3] = val;

                    val = ds.Tables["turn_in"].Rows.Count;
                    flgview[1, 4] = val;

                    val = ds.Tables["operate"].Rows.Count;
                    flgview[1, 5] = val;

                    val = ds.Tables["consultaion_Apply"].Rows.Count;
                    flgview[1, 6] = val;

                    val = ds.Tables["consultaion_Accept"].Rows.Count;
                    flgview[1, 7] = val;

                    val = ds.Tables["zhiyu"].Rows.Count;
                    flgview[1, 8] = val;

                    val = ds.Tables["haozhuan"].Rows.Count;
                    flgview[1, 9] = val;

                    val = ds.Tables["death"].Rows.Count;
                    flgview[1, 10] = val;

                    val = ds.Tables["weiyu"].Rows.Count;
                    flgview[1, 11] = val;


                }
                //179：按病区查询
                if (Convert.ToInt32(cboTimeUnit.SelectedValue.ToString()) == 179)
                {
                    //行数
                    int count = ds.Tables["allSickArea"].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        flgview.Rows.Add();
                        DataRow dr = ds.Tables["allSickArea"].Rows[i];
                        string sickId = dr["said"].ToString();
                        string sickName = dr["sick_area_name"].ToString();
                        flgview[i + 1, 0] = sickName;
                        int val = 0;
                        val = ds.Tables["into_area"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                        flgview[i + 1, 1] = val;

                        val = ds.Tables["out_area"].Select("SICK_AREA_ID='" + sickId + "'").Length;
                        flgview[i + 1, 2] = val;

                        val = ds.Tables["turn_out"].Select("said='" + sickId + "'").Length;
                        flgview[i + 1, 3] = val;

                        val = ds.Tables["turn_in"].Select("said='" + sickId + "'").Length;
                        flgview[i + 1, 4] = val;

                        val = ds.Tables["operate"].Select("sick_area_id='" + sickId + "'").Length;
                        flgview[i + 1, 5] = val;

                        val = ds.Tables["consultaion_Apply"].Select("sick_area_id='" + sickId + "'").Length;
                        flgview[i + 1, 6] = val;

                        val = ds.Tables["consultaion_Accept"].Select("said='" + sickId + "'").Length;
                        flgview[i + 1, 7] = val;

                        val = ds.Tables["zhiyu"].Select("sick_area_id='" + sickId + "'").Length;
                        flgview[i + 1, 8] = val;

                        val = ds.Tables["haozhuan"].Select("sick_area_id='" + sickId + "'").Length;
                        flgview[i + 1, 9] = val;

                        val = ds.Tables["death"].Select("sick_area_id='" + sickId + "'").Length;
                        flgview[i + 1, 10] = val;

                        val = ds.Tables["weiyu"].Select("sick_area_id='" + sickId + "'").Length;
                        flgview[i + 1, 11] = val;
                    }
                }
                //按科室查询
                if (Convert.ToInt32(cboTimeUnit.SelectedValue.ToString()) == 180)
                {
                    //行数
                    int count = ds.Tables["allSection"].Rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        flgview.Rows.Add();
                        DataRow dr = ds.Tables["allSection"].Rows[i];
                        string sectionId = dr["sid"].ToString();
                        string sectionName = dr["section_name"].ToString();
                        flgview[i + 1, 0] = sectionName;
                        int val = 0;
                        val = ds.Tables["into_area"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 1] = val;

                        val = ds.Tables["out_area"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 2] = val;

                        val = ds.Tables["turn_out"].Select("sid='" + sectionId + "'").Length;
                        flgview[i + 1, 3] = val;

                        val = ds.Tables["turn_in"].Select("sid='" + sectionId + "'").Length;
                        flgview[i + 1, 4] = val;

                        val = ds.Tables["operate"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 5] = val;

                        val = ds.Tables["consultaion_Apply"].Select("apply_sectionid='" + sectionId + "'").Length;
                        flgview[i + 1, 6] = val;

                        val = ds.Tables["consultaion_Accept"].Select("consul_record_section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 7] = val;

                        val = ds.Tables["zhiyu"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 8] = val;

                        val = ds.Tables["haozhuan"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 9] = val;

                        val = ds.Tables["death"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 10] = val;

                        val = ds.Tables["weiyu"].Select("section_id='" + sectionId + "'").Length;
                        flgview[i + 1, 11] = val;
                    }
                }

                setTableHeader();
                CellMerge();
            }
        }

       

        /// <summary>
        /// 设置表头
        /// </summary>
        public void setTableHeader()
        {

            try
            {
                flgview.Cols.Count = 13;
                //flgview.Rows.Count = 2;
                flgview.Rows.Fixed = 1;
                //表头设置
                //总计
                cols[0].Name = "病区（科室）";
                cols[0].Field = "Sick_Section";
                cols[0].Index = 1;
                cols[0].visible = true;

                cols[1].Name = "入院人数";
                cols[1].Field = "into_area";
                cols[1].Index = 2;
                cols[1].visible = true;

                cols[2].Name = "出院人数";
                cols[2].Field = "out_area";
                cols[2].Index = 3;
                cols[2].visible = true;

                cols[3].Name = "转出人次";
                cols[3].Field = "turn_out";
                cols[3].Index = 4;
                cols[3].visible = true;

                cols[4].Name = "转入人次";
                cols[4].Field = "turn_in";
                cols[4].Index = 5;
                cols[4].visible = true;

                cols[5].Name = "手术人数";
                cols[5].Field = "operate";
                cols[5].Index = 6;
                cols[5].visible = true;

                cols[6].Name = "发会诊人次";
                cols[6].Field = "consultation_apply";
                cols[6].Index = 7;
                cols[6].visible = true;

                cols[7].Name = "接会诊人次";
                cols[7].Field = "consultation_accept";
                cols[7].Index = 8;
                cols[7].visible = true;

                cols[8].Name = "治愈人数";
                cols[8].Field = "heal";
                cols[8].Index = 9;
                cols[8].visible = true;

                cols[9].Name = "好转人数";
                cols[9].Field = "mend";
                cols[9].Index = 10;
                cols[9].visible = true;

                cols[10].Name = "死亡人数";
                cols[10].Field = "death";
                cols[10].Index = 11;
                cols[10].visible = true;

                cols[11].Name = "未愈人数";
                cols[11].Field = "no_heal";
                cols[11].Index = 12;
                cols[11].visible = true;

                flgview.Cols[0].Width = 80;
                flgview.Cols[1].Width = 60;
                flgview.Cols[2].Width = 60;
                flgview.Cols[3].Width = 60;
                flgview.Cols[4].Width = 60;
                flgview.Cols[5].Width = 60;
                flgview.Cols[6].Width = 60;
                flgview.Cols[7].Width = 60;
                flgview.Cols[8].Width = 60;
                flgview.Cols[9].Width = 60;
                flgview.Cols[10].Width = 60;
                flgview.Cols[11].Width = 60;

                for (int i = 0; i < flgview.Cols.Count; i++)
                {
                    flgview.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// 单元格合并
        /// </summary>
        public void CellMerge()
        {
            //单元格设置           
            flgview[0, 0] = "病区（科室）";
            flgview[0, 1] = "入院人数";
            flgview[0, 2] = "出院人数";
            flgview[0, 3] = "转出人次";
            flgview[0, 4] = "转入人次";
            flgview[0, 5] = "手术人数";
            flgview[0, 6] = "发会诊人次";
            flgview[0, 7] = "接会诊人次";
            flgview[0, 8] = "治愈人数";
            flgview[0, 9] = "好转人数";
            flgview[0, 10] = "死亡人数";
            flgview[0, 11] = "未愈人数";
            flgview.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgview.Cols.Fixed = 0;
        }

        /// <summary>
        /// 双击数字，显示相应的病人信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgview_DoubleClick(object sender, EventArgs e)
        {

            if (flgview[flgview.RowSel, flgview.ColSel] != null && App.IsNumeric(flgview[flgview.RowSel, flgview.ColSel].ToString()))
            {
                //flgview[flgview.RowSel, "在院人数"];
                DataTable dt = new DataTable();
                //第一级列头
                //选中行行头
                string rowname = flgview[flgview.RowSel, 0].ToString();
                //第二级列头
                string colname = flgview[0, flgview.ColSel].ToString();
                if (colname.Contains("会诊"))
                {
                    App.Msg("会诊统计没有病人详细信息");
                    return;
                }
                switch (colname)
                {
                    case "入院人数":
                        dt = ds.Tables["into_area"];
                        break;
                    case "出院人数":
                        dt = ds.Tables["out_area"];
                        break;
                    case "手术人数":
                        dt = ds.Tables["operate"];
                        break;
                    case "治愈人数":
                        dt = ds.Tables["zhiyu"];
                        break;
                    case "好转人数":
                        dt = ds.Tables["haozhuan"];
                        break;
                    case "死亡人数":
                        dt = ds.Tables["death"];
                        break;
                    case "未愈人数":
                        dt = ds.Tables["weiyu"];
                        break;
                    case "转出人次":
                        dt = ds.Tables["turn_out"];
                        break;
                    case "转入人次":
                        dt = ds.Tables["turn_in"];
                        break;
                }
                //入院诊断
                DataTable dt_inDiag = ds.Tables["allin_diag"];
                //出院诊断
                DataTable dt_outDiag = ds.Tables["allout_diag"];
                if (rowname == "全院")
                {
                    if (colname == "治愈人数" || colname == "好转人数" || colname == "未愈人数")
                    {
                        frmTurnTo_PatientInfo patientInfo = new frmTurnTo_PatientInfo(dt, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "手术人数")
                    {
                        frmOpration_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmOpration_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmOpration_PatientInfo.sectionName = rowname;
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "死亡人数")
                    {
                        frmTurnToDie_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmTurnToDie_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmTurnToDie_PatientInfo.sectionName = rowname;
                        frmTurnToDie_PatientInfo frmDie = new frmTurnToDie_PatientInfo(dt, dt_inDiag);
                        frmDie.ShowDialog();
                    }
                    else if (colname == "入院人数" || colname == "出院人数")
                    {
                        frmInOut_PatientInfo.titleName = colname.Substring(0, 2);
                        frmInOut_PatientInfo.sectionName = rowname;
                        frmInOut_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmInOut_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "转出人次" || colname == "转入人次")
                    {
                        frmTurnInOut_PatientInfo patientInfo = new frmTurnInOut_PatientInfo(dt);
                        patientInfo.ShowDialog();
                    }
                    else
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt);
                        patientInfo.ShowDialog();
                    }

                }
                if (searchName == "按病区")//按病区
                {
                    DataTable dt_sick_area = new DataTable();
                    DataRow[] dr = dt.Select("sick_area_name='" + rowname + "'");
                    dt_sick_area = dt.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt_sick_area.Rows.Add(dr[i].ItemArray);
                    }
                    if (colname == "治愈人数" || colname == "好转人数" || colname == "未愈人数")
                    {
                        frmTurnTo_PatientInfo patientInfo = new frmTurnTo_PatientInfo(dt_sick_area, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "手术人数")
                    {
                        //用于报表显示的参数
                        frmOpration_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmOpration_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmOpration_PatientInfo.sectionName = rowname;
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt_sick_area);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "死亡人数")
                    {
                        frmTurnToDie_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmTurnToDie_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmTurnToDie_PatientInfo.sectionName = rowname;
                        frmTurnToDie_PatientInfo frmDie = new frmTurnToDie_PatientInfo(dt_sick_area, dt_inDiag);
                        frmDie.ShowDialog();
                    }
                    else if (colname == "入院人数" || colname == "出院人数")
                    {
                        frmInOut_PatientInfo.titleName = colname.Substring(0, 2);
                        frmInOut_PatientInfo.sectionName = rowname;
                        frmInOut_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmInOut_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_sick_area, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "转出人次" || colname == "转入人次")
                    {
                        frmTurnInOut_PatientInfo patientInfo = new frmTurnInOut_PatientInfo(dt_sick_area);
                        patientInfo.ShowDialog();
                    }
                    else
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_sick_area);
                        patientInfo.ShowDialog();
                    }
                }
                if (searchName == "按科室")//按科室
                {
                    DataTable dt_section = new DataTable();

                    DataRow[] dr = dt.Select("section_name='" + rowname + "'");
                    dt_section = dt.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt_section.Rows.Add(dr[i].ItemArray);
                    }
                    if (colname == "治愈人数" || colname == "好转人数" || colname == "未愈人数")
                    {
                        frmTurnTo_PatientInfo patientInfo = new frmTurnTo_PatientInfo(dt_section, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "手术人数")
                    {
                        //用于报表显示的参数
                        frmOpration_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmOpration_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmOpration_PatientInfo.sectionName = rowname;
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt_section);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "死亡人数")
                    {
                        frmTurnToDie_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmTurnToDie_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmTurnToDie_PatientInfo.sectionName = rowname;
                        frmTurnToDie_PatientInfo frmDie = new frmTurnToDie_PatientInfo(dt_section, dt_inDiag);
                        frmDie.ShowDialog();
                    }
                    else if (colname == "入院人数" || colname == "出院人数")
                    {
                        frmInOut_PatientInfo.titleName = colname.Substring(0, 2);
                        frmInOut_PatientInfo.sectionName = rowname;
                        frmInOut_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmInOut_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_section, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "转出人次" || colname == "转入人次")
                    {
                        frmTurnInOut_PatientInfo patientInfo = new frmTurnInOut_PatientInfo(dt_section);
                        patientInfo.ShowDialog();
                    }
                    else
                    {
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_section);
                        patientInfo.ShowDialog();
                    }
                }
            }

        }



    }
}
