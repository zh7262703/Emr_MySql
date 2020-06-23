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
        //�еļ���
        ColumnInfo[] cols = new ColumnInfo[13];
        /// <summary>
        /// ���ݼ�
        /// </summary>
        DataSet ds = null;

        /// <summary>
        /// ȫ�ֱ�������¼��ѯ��Χ��ֻ���ٴβ�ѯʱ��״̬�Ÿı�
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
        /// ���ͣ�����е�ɫ�ı� 
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
        ////��ʱ��ͳ����Ŀ
        //private void TimeItem()
        //{
        //    DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='40'");
        //    cboTimeItem.DataSource = ds.Tables[0].DefaultView;
        //    cboTimeItem.ValueMember = "ID";
        //    cboTimeItem.DisplayMember = "NAME";
        //}
        //��ʱ��ͳ�Ʒ�Χ
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
        /// ��ȡ��ѯ�����ݽ��
        /// </summary>
        /// <returns></returns>
        private DataSet Get_Search_Data()
        {
            string dataStart = dtpStart.Value.ToString("yyyy-MM-dd ");
            string dataend = dtpEnd.Value.ToString("yyyy-MM-dd ");
            try
            {
                Bifrost.WebReference.Class_Table[] temtables = new Bifrost.WebReference.Class_Table[15];

                //��Ժ����
                string sql_into_area = "select a.id,a.pid,a.patient_name,case when a.gender_code=0 then '��' else 'Ů' end sex,concat(age,age_unit) as ����,a.in_time,a.die_time,'' as ��Ժ���,'' as ��Ժ���,a.insection_name ,a.section_name ,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a where (select count(id) from t_inhospital_action b where b.patient_id=a.id)>0 and to_char(a.in_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'  ";
                //��Ժ����
                string sql_out_area = "select distinct a.id,a.pid,a.patient_name,case when a.gender_code=0 then '��' else 'Ů' end sex,concat(age,age_unit) as ����,a.in_time,a.die_time,'' as ��Ժ���,'' as ��Ժ���,a.insection_name ,a.section_name ,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where b.next_id=0 and b.ACTION_TYPE='����' and b.ACTION_STATE=3 and a.die_flag<>1 and to_char(b.HAPPEN_TIME,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'  ";
                //ת���˴�
                string sql_turn_out = "select distinct a.id, a.patient_name,case when a.gender_code=0 then '��' else 'Ů' end sex,concat(age,age_unit) as ����,d.section_name ,e.section_name ת�����,b.happen_time,a.section_name ,b.sid,b.said,f.sick_area_name from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id inner join t_inhospital_action c on a.id=c.patient_id  inner join t_sectioninfo d on b.sid=d.sid inner join t_sectioninfo e on b.target_sid=e.sid inner join t_sickareainfo f on b.said=f.said where b.action_type='ת��' and c.action_type='ת��' and b.next_id=c.id and to_char(b.happen_time,'yyyy-MM-dd')  between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //ת���˴�
                string sql_turn_in = "select distinct a.id, a.patient_name,case when a.gender_code=0 then '��' else 'Ů' end sex,concat(age,age_unit) as ����,d.section_name ת������,e.section_name,c.happen_time,a.section_name ,c.sid,c.said,f.sick_area_name from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id inner join t_inhospital_action c on a.id=c.patient_id  inner join t_sectioninfo d on b.sid=d.sid inner join t_sectioninfo e on b.target_sid=e.sid inner join t_sickareainfo f on c.said=f.said where b.action_type='ת��' and c.action_type='ת��' and b.next_id=c.id  and to_char(c.happen_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //��������
                string sql_operate = "select distinct a.id,a.section_name,e.operator,e.oper_assist1,e.oper_assist2,a.pid,a.patient_name,case when a.gender_code=0 then '��' else 'Ů' end sex,concat(age,age_unit),c.diagnose_name,e.oper_date,e.oper_name,'' as ��������,a.birthday,a.section_id,a.in_time,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id left join t_diagnose_item c on a.id=c.patient_id and c.diagnose_type=401 left join COVER_OPERATION e on a.id=e.inpatient_id  where a.id in(select patient_id from t_quality_text g  where g.texttkind_id=151 and to_char(g.create_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "')  ";
                //�������˴�
                string sql_consultaion_Apply = "select a.*,b.sick_area_id,b.birthday from t_consultaion_apply a inner join t_in_patient b on a.patient_id=b.id inner join t_consultaion_record c on a.id=c.apply_id  where submited='Y' and to_char(a.apply_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "' ";
                //�ӻ����˴�
                string sql_consultaion_Accept = "select a.consul_record_section_id,d.said,c.birthday from t_consultaion_record a inner join t_consultaion_apply b on a.apply_id=b.id inner join t_in_patient c on b.patient_id=c.id  inner join t_section_area d on a.consul_record_section_id=d.sid where  a.isrecieve='1'  and b.is_dalete='N' and to_char(consul_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend + "'";
                //��������
                string sql_ZhiYu = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '��' else 'Ů' end sex,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name,a.in_time,a.die_time,a.sick_doctor_id,a.sick_doctor_name,'' as ��Ժ���,'' as ��Ժ��� from t_In_Patient a inner join t_inhospital_action b on (a.id=b.patient_id) inner join t_diagnose_item c on (a.id=c.patient_id) where b.action_type='����' and c.turn_to='����' and to_char(b.happen_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //��ת����
                string sql_HaoZhuan = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '��' else 'Ů' end sex,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name,a.in_time,a.die_time,a.sick_doctor_id,a.sick_doctor_name,'' as ��Ժ���,'' as ��Ժ��� from t_In_Patient a inner join t_inhospital_action b on (a.id=b.patient_id) inner join t_diagnose_item c on (a.id=c.patient_id) where b.action_type='����' and c.turn_to='��ת' and  to_char(b.happen_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //��������
                string sql_Death = "select distinct a.id,a.section_name,a.pid,a.patient_name,case when a.gender_code=0 then '��' else 'Ů' end sex,concat(age,age_unit),a.home_address,a.relation_name,a.in_time,'' as ��Ժ���,'' as ����ԭ��,'' as ����ʱ��,sick_doctor_name,a.birthday,a.section_id,a.SICK_AREA_ID,a.SICK_AREA_name from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where a.die_flag=1 and to_char(b.happen_time ,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                //δ������
                string sql_WeiYu = "select distinct a.id,a.patient_name,a.pid,a.birthday,case when a.gender_code=0 then '��' else 'Ů' end sex,a.section_id,a.section_name,a.SICK_AREA_ID,a.SICK_AREA_name,a.in_time,a.die_time,a.sick_doctor_id,a.sick_doctor_name,'' as ��Ժ���,'' as ��Ժ��� from t_In_Patient a inner join t_inhospital_action b on (a.id=b.patient_id) inner join t_diagnose_item c on (a.id=c.patient_id) where b.action_type='����' and c.turn_to='δ��' and  to_char(b.happen_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";

                //���в���
                string sql_allSickArea = "select said,sick_area_name from t_sickareainfo";
                //���п���
                string sql_allSection = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
                //������Ժ���
                string sql_allin_diag = "select patient_id,diagnose_name,create_time,diagnose_sort from t_diagnose_item where diagnose_type=408 ";
                //���г�Ժ���
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
        /// ��������������
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private void Get_Fill_Grid(DataSet ds)
        {
            flgview.Rows.Count = 1;
            if (ds != null)
            {
                //178��ȫԺ��ѯ
                if (Convert.ToInt32(cboTimeUnit.SelectedValue.ToString()) == 178)
                {
                    flgview.Rows.Add();
                    //�������
                    flgview[1, 0] = "ȫԺ";

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
                //179����������ѯ
                if (Convert.ToInt32(cboTimeUnit.SelectedValue.ToString()) == 179)
                {
                    //����
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
                //�����Ҳ�ѯ
                if (Convert.ToInt32(cboTimeUnit.SelectedValue.ToString()) == 180)
                {
                    //����
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
        /// ���ñ�ͷ
        /// </summary>
        public void setTableHeader()
        {

            try
            {
                flgview.Cols.Count = 13;
                //flgview.Rows.Count = 2;
                flgview.Rows.Fixed = 1;
                //��ͷ����
                //�ܼ�
                cols[0].Name = "���������ң�";
                cols[0].Field = "Sick_Section";
                cols[0].Index = 1;
                cols[0].visible = true;

                cols[1].Name = "��Ժ����";
                cols[1].Field = "into_area";
                cols[1].Index = 2;
                cols[1].visible = true;

                cols[2].Name = "��Ժ����";
                cols[2].Field = "out_area";
                cols[2].Index = 3;
                cols[2].visible = true;

                cols[3].Name = "ת���˴�";
                cols[3].Field = "turn_out";
                cols[3].Index = 4;
                cols[3].visible = true;

                cols[4].Name = "ת���˴�";
                cols[4].Field = "turn_in";
                cols[4].Index = 5;
                cols[4].visible = true;

                cols[5].Name = "��������";
                cols[5].Field = "operate";
                cols[5].Index = 6;
                cols[5].visible = true;

                cols[6].Name = "�������˴�";
                cols[6].Field = "consultation_apply";
                cols[6].Index = 7;
                cols[6].visible = true;

                cols[7].Name = "�ӻ����˴�";
                cols[7].Field = "consultation_accept";
                cols[7].Index = 8;
                cols[7].visible = true;

                cols[8].Name = "��������";
                cols[8].Field = "heal";
                cols[8].Index = 9;
                cols[8].visible = true;

                cols[9].Name = "��ת����";
                cols[9].Field = "mend";
                cols[9].Index = 10;
                cols[9].visible = true;

                cols[10].Name = "��������";
                cols[10].Field = "death";
                cols[10].Index = 11;
                cols[10].visible = true;

                cols[11].Name = "δ������";
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
        /// ��Ԫ��ϲ�
        /// </summary>
        public void CellMerge()
        {
            //��Ԫ������           
            flgview[0, 0] = "���������ң�";
            flgview[0, 1] = "��Ժ����";
            flgview[0, 2] = "��Ժ����";
            flgview[0, 3] = "ת���˴�";
            flgview[0, 4] = "ת���˴�";
            flgview[0, 5] = "��������";
            flgview[0, 6] = "�������˴�";
            flgview[0, 7] = "�ӻ����˴�";
            flgview[0, 8] = "��������";
            flgview[0, 9] = "��ת����";
            flgview[0, 10] = "��������";
            flgview[0, 11] = "δ������";
            flgview.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgview.Cols.Fixed = 0;
        }

        /// <summary>
        /// ˫�����֣���ʾ��Ӧ�Ĳ�����Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgview_DoubleClick(object sender, EventArgs e)
        {

            if (flgview[flgview.RowSel, flgview.ColSel] != null && App.IsNumeric(flgview[flgview.RowSel, flgview.ColSel].ToString()))
            {
                //flgview[flgview.RowSel, "��Ժ����"];
                DataTable dt = new DataTable();
                //��һ����ͷ
                //ѡ������ͷ
                string rowname = flgview[flgview.RowSel, 0].ToString();
                //�ڶ�����ͷ
                string colname = flgview[0, flgview.ColSel].ToString();
                if (colname.Contains("����"))
                {
                    App.Msg("����ͳ��û�в�����ϸ��Ϣ");
                    return;
                }
                switch (colname)
                {
                    case "��Ժ����":
                        dt = ds.Tables["into_area"];
                        break;
                    case "��Ժ����":
                        dt = ds.Tables["out_area"];
                        break;
                    case "��������":
                        dt = ds.Tables["operate"];
                        break;
                    case "��������":
                        dt = ds.Tables["zhiyu"];
                        break;
                    case "��ת����":
                        dt = ds.Tables["haozhuan"];
                        break;
                    case "��������":
                        dt = ds.Tables["death"];
                        break;
                    case "δ������":
                        dt = ds.Tables["weiyu"];
                        break;
                    case "ת���˴�":
                        dt = ds.Tables["turn_out"];
                        break;
                    case "ת���˴�":
                        dt = ds.Tables["turn_in"];
                        break;
                }
                //��Ժ���
                DataTable dt_inDiag = ds.Tables["allin_diag"];
                //��Ժ���
                DataTable dt_outDiag = ds.Tables["allout_diag"];
                if (rowname == "ȫԺ")
                {
                    if (colname == "��������" || colname == "��ת����" || colname == "δ������")
                    {
                        frmTurnTo_PatientInfo patientInfo = new frmTurnTo_PatientInfo(dt, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "��������")
                    {
                        frmOpration_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmOpration_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmOpration_PatientInfo.sectionName = rowname;
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "��������")
                    {
                        frmTurnToDie_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmTurnToDie_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmTurnToDie_PatientInfo.sectionName = rowname;
                        frmTurnToDie_PatientInfo frmDie = new frmTurnToDie_PatientInfo(dt, dt_inDiag);
                        frmDie.ShowDialog();
                    }
                    else if (colname == "��Ժ����" || colname == "��Ժ����")
                    {
                        frmInOut_PatientInfo.titleName = colname.Substring(0, 2);
                        frmInOut_PatientInfo.sectionName = rowname;
                        frmInOut_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmInOut_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "ת���˴�" || colname == "ת���˴�")
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
                if (searchName == "������")//������
                {
                    DataTable dt_sick_area = new DataTable();
                    DataRow[] dr = dt.Select("sick_area_name='" + rowname + "'");
                    dt_sick_area = dt.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt_sick_area.Rows.Add(dr[i].ItemArray);
                    }
                    if (colname == "��������" || colname == "��ת����" || colname == "δ������")
                    {
                        frmTurnTo_PatientInfo patientInfo = new frmTurnTo_PatientInfo(dt_sick_area, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "��������")
                    {
                        //���ڱ�����ʾ�Ĳ���
                        frmOpration_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmOpration_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmOpration_PatientInfo.sectionName = rowname;
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt_sick_area);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "��������")
                    {
                        frmTurnToDie_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmTurnToDie_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmTurnToDie_PatientInfo.sectionName = rowname;
                        frmTurnToDie_PatientInfo frmDie = new frmTurnToDie_PatientInfo(dt_sick_area, dt_inDiag);
                        frmDie.ShowDialog();
                    }
                    else if (colname == "��Ժ����" || colname == "��Ժ����")
                    {
                        frmInOut_PatientInfo.titleName = colname.Substring(0, 2);
                        frmInOut_PatientInfo.sectionName = rowname;
                        frmInOut_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmInOut_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_sick_area, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "ת���˴�" || colname == "ת���˴�")
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
                if (searchName == "������")//������
                {
                    DataTable dt_section = new DataTable();

                    DataRow[] dr = dt.Select("section_name='" + rowname + "'");
                    dt_section = dt.Clone();
                    for (int i = 0; i < dr.Length; i++)
                    {
                        dt_section.Rows.Add(dr[i].ItemArray);
                    }
                    if (colname == "��������" || colname == "��ת����" || colname == "δ������")
                    {
                        frmTurnTo_PatientInfo patientInfo = new frmTurnTo_PatientInfo(dt_section, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "��������")
                    {
                        //���ڱ�����ʾ�Ĳ���
                        frmOpration_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmOpration_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmOpration_PatientInfo.sectionName = rowname;
                        frmOpration_PatientInfo frmOper = new frmOpration_PatientInfo(dt_section);
                        frmOper.ShowDialog();
                    }
                    else if (colname == "��������")
                    {
                        frmTurnToDie_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmTurnToDie_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmTurnToDie_PatientInfo.sectionName = rowname;
                        frmTurnToDie_PatientInfo frmDie = new frmTurnToDie_PatientInfo(dt_section, dt_inDiag);
                        frmDie.ShowDialog();
                    }
                    else if (colname == "��Ժ����" || colname == "��Ժ����")
                    {
                        frmInOut_PatientInfo.titleName = colname.Substring(0, 2);
                        frmInOut_PatientInfo.sectionName = rowname;
                        frmInOut_PatientInfo.beginTime = dtpStart.Value.ToString();
                        frmInOut_PatientInfo.endTime = dtpEnd.Value.ToString();
                        frmInOut_PatientInfo patientInfo = new frmInOut_PatientInfo(dt_section, dt_inDiag, dt_outDiag);
                        patientInfo.ShowDialog();
                    }
                    else if (colname == "ת���˴�" || colname == "ת���˴�")
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
