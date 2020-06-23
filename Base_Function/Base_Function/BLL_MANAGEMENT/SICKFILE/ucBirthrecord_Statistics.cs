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
    public partial class ucBirthrecord_Statistics : UserControl
    {
        public ucBirthrecord_Statistics()
        {
            InitializeComponent();

            cmbInOut.Items.Add("入院");
            cmbInOut.Items.Add("出院");
            cmbInOut.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInOut.SelectedIndex = 0;

            chkInOutTime.Checked = true;
            chkBirthTime.Checked = false;
            this.Load += new EventHandler(ucBirthrecord_Statistics_Load);
        }

        void ucBirthrecord_Statistics_Load(object sender, EventArgs e)
        {
            InitDept();
        }

        /// <summary>
        /// 初始化科室下拉列表
        /// </summary>
        private void InitDept()
        {
            try
            {
                string sql_Section = @"select a.sid,a.section_name,a.section_code from t_sectioninfo a 
                                        inner join t_section_area b on a.sid=b.sid where section_name like '%产%'
                                        group  by a.shid,a.sid,a.section_code,a.section_name
                                        order by a.shid,to_number(a.section_code)";//查询科室

                DataSet ds_InSection = new DataSet();

                ds_InSection = App.GetDataSet(sql_Section);
                //插入默认选项（请选择）
                if (ds_InSection != null)
                {
                    DataRow dr1 = ds_InSection.Tables[0].NewRow();
                    dr1["sid"] = 0;
                    dr1["section_name"] = "所有产科病房";
                    ds_InSection.Tables[0].Rows.InsertAt(dr1, 0);
                }
                cboDept.DataSource = ds_InSection.Tables[0];
                cboDept.DisplayMember = "section_name";
                cboDept.ValueMember = "sid";
                //默认下拉框“所以产科病房”
                cboDept.SelectedIndex = '0';
            }
            catch { }
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            Get_Search_Data();
        }

        private void Get_Search_Data()
        {
            //            string sql = @"select rownum as 序号,姓名,年龄,病房,住院号,孕产史,病毒,催产素使用,促胎肺成熟用药,分娩方式,手术指征,特殊情况,怀孕周数,出生时间,性别,体重,身长,出生时脐动脉血PH值,出生1分钟Apgar评分,
            //                        畸形,羊水量,胎盘大小,胎盘异常,脐带长,脐带异常,会阴,会阴切开指征,会阴麻醉方式,会阴缝合,阴道血肿,产后出血量,第一产程时长,第二产程时长,第三产程时长,总产程时长,分娩时用药,确定诊断,接生者,
            //                        section_id,in_time,die_time from (select a.姓名,a.年龄,a.科室 as 病房,a.住院号,a.孕产史,a.病毒,a.催产素使用,a.促胎肺成熟用药,a.分娩方式,a.手术指征,a.特殊情况,a.怀孕周数,
            //                        a.第一胎出生时间 as 出生时间,a.第一胎性别 as 性别,a.第一胎体重 as 体重,a.第一胎身长 as 身长,a.第一胎出生时脐动脉血PH值 as 出生时脐动脉血PH值,a.第一胎出生1分钟Apgar评分 as 出生1分钟Apgar评分,
            //                        a.第一胎畸形 as 畸形,a.第一胎羊水量 as 羊水量,a.第一胎胎盘大小 as 胎盘大小,a.第一胎胎盘异常 as 胎盘异常,a.第一胎脐带长 as 脐带长,a.第一胎脐带异常 as 脐带异常,d.会阴,d.会阴切开指征,
            //                        d.会阴麻醉方式,d.会阴缝合,d.阴道血肿,d.产后出血量,d.第一产程小时长||d.小时||d.第一产程分钟长||d.分钟 as 第一产程时长,d.第二产程小时长||d.小时||d.第二产程分钟长||d.分钟 as 第二产程时长,
            //                        d.第三产程小时长||d.小时||d.第三产程分钟长||d.分钟 as 第三产程时长,d.总产程小时长||d.小时||d.总产程分钟长||d.分钟 as 总产程时长,d.分娩时用药,d.确定诊断,d.接生者,
            //                        b.section_id,b.in_time,b.die_time from t_birth_records a inner join t_in_patient b on a.patient_id = b.id left join t_delivery_records d on a.patient_id = d.patient_id
            //                        union all select c.姓名,c.年龄,c.科室 as 病房,c.住院号,c.孕产史,c.病毒,c.催产素使用,c.促胎肺成熟用药,c.分娩方式,c.手术指征,c.特殊情况,c.怀孕周数,
            //                        c.第二胎出生时间 as 出生时间,c.第二胎性别 as 性别,c.第二胎体重 as 体重,c.第二胎身长 as 身长,c.第二胎出生时脐动脉血PH值 as 出生时脐动脉血PH值,c.第二胎出生1分钟Apgar评分 as 出生1分钟Apgar评分,
            //                        c.第二胎畸形 as 畸形,c.第二胎羊水量 as 羊水量,c.第二胎胎盘大小 as 胎盘大小,c.第二胎胎盘异常 as 胎盘异常,c.第二胎脐带长 as 脐带长,c.第二胎脐带异常 as 脐带异常,d.会阴,d.会阴切开指征,
            //                        d.会阴麻醉方式,d.会阴缝合,d.阴道血肿,d.产后出血量,d.第一产程小时长||d.小时||d.第一产程分钟长||d.分钟 as 第一产程时长,d.第二产程小时长||d.小时||d.第二产程分钟长||d.分钟 as 第二产程时长,
            //                        d.第三产程小时长||d.小时||d.第三产程分钟长||d.分钟 as 第三产程时长,d.总产程小时长||d.小时||d.总产程分钟长||d.分钟 as 总产程时长,d.分娩时用药,d.确定诊断,d.接生者,
            //                        b.section_id,b.in_time,b.die_time from t_birthsecond_records c inner join t_in_patient b on c.patient_id = b.id left join t_delivery_records d on d.patient_id = c.patient_id order by 住院号 asc)";

            string sql = @"select rownum as 序号,patient_id,姓名 as 母亲姓名,年龄,科室 as 病房,住院号,孕产史,病毒,催产素使用,促胎肺成熟用药,分娩方式,手术指征,特殊情况,
                        怀孕周数 as 妊娠周数,第一胎出生时间 as 出生时间,第一胎性别 as 性别,第一胎体重 as ""体重/g"",
                        第一胎身长 as ""身长/cm"",第一胎出生时脐动脉血PH值 as 出生时脐动脉血PH值,第一胎出生1分钟Apgar评分 as ""出生1分钟Apgar评分/分"",
                        第一胎出生5分钟Apgar评分 as ""出生5分钟Apgar评分/分"",第一胎畸形 as 畸形,第一胎羊水量 as ""羊水量/ml"",
                        第一胎胎盘异常 as 胎盘异常,第一胎脐带长 as ""脐带长度/cm"",第一胎脐带异常 as 脐带异常,第一胎抢救过程 as 抢救过程,
                        第一胎新生儿去向 as 新生儿去向,第一胎新生儿转运方式 as 新生儿转运方式,初步诊断 as 新生儿诊断, 
                        会阴,会阴切开指征,阴道血肿,产后出血量 as ""产后出血量/ml"",第一产程小时长||小时||第一产程分钟长||分钟 as 第一产程时长,
                        第二产程小时长||小时||第二产程分钟长||分钟 as 第二产程时长,第三产程小时长||小时||第三产程分钟长||分钟 as 第三产程时长,
                        总产程小时长||小时||总产程分钟长||分钟 as 总产程时长,确定诊断 as 产妇诊断,接生者,
                        section_id,in_time,die_time from (select * from t_birth_records a inner join t_in_patient b on a.patient_id = b.id left join t_delivery_records d 
                        on a.patient_id = d.patient_id
                        union all select * from t_birthsecond_records c inner join t_in_patient b on c.patient_id = b.id left join t_deliverysec_records e 
                        on e.patient_id = c.patient_id where c.patient_id in (select patient_id from t_birth_records) order by 6 asc)";


            if (this.cboDept.SelectedValue.ToString() == "0")
            {
                sql += " where 1=1";
            }
            else
            {
                sql += " where section_id='" + this.cboDept.SelectedValue.ToString() + "'";
            }

            if (this.chkInOutTime.Checked == true)
            {
                if (cmbInOut.Text == "入院")
                {
                    string dataStart = dtpInOutStart.Value.ToString("yyyy-MM-dd ");
                    string dataend = dtpInOutEnd.Value.ToString("yyyy-MM-dd ");

                    sql += " and to_char(in_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                }

                else if (cmbInOut.Text == "出院")
                {
                    string dataStart = dtpInOutStart.Value.ToString("yyyy-MM-dd ");
                    string dataend = dtpInOutEnd.Value.ToString("yyyy-MM-dd ");

                    sql += " and to_char(die_time,'yyyy-MM-dd') between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
                }
            }
            if (this.chkBirthTime.Checked == true)
            {
                string dataStart = dtpBirthStart.Value.ToString("yyyy-MM-dd ");
                string dataend = dtpBirthEnd.Value.ToString("yyyy-MM-dd ");

                sql += " and 第一胎出生时间 between '" + dataStart.Trim() + "' and '" + dataend.Trim() + "'";
            }

            sql = sql + " order by 住院号 asc,出生时间 asc";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(sql);

            if (ds.Tables[0].Rows.Count == 0)
            {
                App.MsgWaring("未找到符合该条件的记录！");                
                flgview.Clear();
            }
            else
            {
                this.flgview.DataSource = ds.Tables[0].DefaultView;
                //flgview.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
                this.flgview.Cols["section_id"].Visible = false;
                this.flgview.Cols["in_time"].Visible = false;
                this.flgview.Cols["die_time"].Visible = false;
                this.flgview.Cols["patient_id"].Visible = false;

            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "新生儿分娩情况统计表.xls";
            saveFileDialog1.Filter = "Excel工作簿(*.xls)|*.xls";
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            this.flgview.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
        }

        private void chkInOutTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInOutTime.Checked == true)
            {
                cmbInOut.Enabled = true;
                dtpInOutEnd.Enabled = true;
                dtpInOutStart.Enabled = true;
            }
            else {
                cmbInOut.Enabled = false;
                dtpInOutEnd.Enabled = false;
                dtpInOutStart.Enabled = false;
            }
        }

        private void chkBirthTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBirthTime.Checked == true)
            {               
                dtpBirthEnd .Enabled = true;
                dtpBirthStart.Enabled = true;
            }
            else
            {
                dtpBirthEnd.Enabled = false;
                dtpBirthStart.Enabled = false;
            }
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }



    }
}
