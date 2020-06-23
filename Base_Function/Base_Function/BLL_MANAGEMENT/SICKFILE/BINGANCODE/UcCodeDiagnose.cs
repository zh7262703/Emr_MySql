using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
using System.Net;
using Microsoft.ReportingServices.ReportRendering;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    /// <summary>
    /// 设计者：连伟
    /// 时  间：2017/02/26
    /// </summary>
    public partial class UcCodeDiagnose : UserControl
    {
        string Pid = "";
        public string isChinese = "";
        private DataGridViewTextBoxEditingControl dgvBoxEditingControl;
        private DataSet ds1;
        private DataSet ds2;
        private DataTable dt;
        /// <summary>
        /// 默认构造器
        /// </summary>
        public UcCodeDiagnose()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pid">传值住院号</param>
        public UcCodeDiagnose(string pid)
        {
            InitializeComponent();
            Pid = pid;
            LED_Diagnose();
            DataInit.A_btnSave = null;
            DataInit.A_btnSave = new EventHandler(btn_tj_Click);
            DataInit.A_UP = null;
            DataInit.A_UP = new EventHandler(buttonX2_Click);
            DataInit.A_Next = null;
            DataInit.A_Next = new EventHandler(buttonX3_Click);
        }
        /// <summary>
        /// 显示诊断
        /// </summary>
        public void LED_Diagnose()
        {
            #region
            //西医诊断
            string sql = "";
            #region
            //string sqls_O = "";
            //string sqls_I = "";
            //string sqls_D = "";
            //string sqls_E = "";
            //string sqls_P = "";
            //string sqls_S = "";
            //string sqls_H = "";

            //sqls_O = "select * from cover_diagnose where type in('O','M') and inpatient_id = '" + Pid + "'";//出院
            //sqls_I = "select * from cover_diagnose where type='I' and inpatient_id = '" + Pid + "'";//入院
            //sqls_D = "select * from cover_diagnose where type='D' and inpatient_id = '" + Pid + "'";//死亡
            //sqls_E = "select * from cover_diagnose where type='E' and inpatient_id = '" + Pid + "'";//门诊
            //sqls_P = "select * from cover_diagnose where type='P' and inpatient_id = '" + Pid + "'";//病理
            //sqls_S = "select * from cover_diagnose where type='S' and inpatient_id = '" + Pid + "'";//损伤中毒
            //sqls_H = "select * from cover_diagnose where type='H' and inpatient_id = '" + Pid + "'";//院内感染

            //DataSet ds_O = App.GetDataSet(sqls_O);
            //DataSet ds_I = App.GetDataSet(sqls_I);
            //DataSet ds_D = App.GetDataSet(sqls_D);
            //DataSet ds_E = App.GetDataSet(sqls_E);
            //DataSet ds_P = App.GetDataSet(sqls_P);
            //DataSet ds_S = App.GetDataSet(sqls_S);
            //DataSet ds_H = App.GetDataSet(sqls_H);
            //if (ds_E.Tables[0].Rows.Count > 0)
            //{
            //    sql = " select '门诊诊断' as 诊疗类别,a as 诊断名称,b 疾病编码,c 症候,f as 中西医,g as 主要诊断,h 类型,1 as 序号,i as ID from (select t.name as a,t.ICD10CODE as b,SYMPTOMS_NAME as c,incondition as d,pnumber as e,(case when is_chinese = 0 then '西医' else '中医' end) as f,(case when t.type = 'M' then '√' else '' end) as g,t.type as h,t.id as i from t_data_code a left join cover_diagnose t on a.code = t.type WHERE 1 = 1 AND t.inpatient_id = '" + Pid + "' AND a.code = 'E' AND A.TYPE = '10939503') union all";// and t.is_chinese='1'
            //}
            //else
            //{
            //    sql = " select distinct '门诊诊断' as 诊疗类别,null as 诊断名称,null 疾病编码,null 症候,null as 中西医,null as 主要诊断,null as 类型,1 as 序号,null as ID from (select count(t.type) as h from cover_diagnose t where 1 = 1) union all";
            //}

            //if (ds_I.Tables[0].Rows.Count > 0)
            //{
            //    sql += " select distinct '入院诊断' as 诊疗类别,a as 诊断名称,b 疾病编码,c 症候,f as 中西医,g as 主要诊断,h 类型,2 as 序号,i as ID from (select t.name as a,t.ICD10CODE as b,SYMPTOMS_NAME as c,incondition as d,pnumber as e,(case when is_chinese = 0 then '西医' else '中医' end) as f,(case when t.type = 'M' then '√' else '' end) as g,t.type as h,t.id as i from t_data_code a left join cover_diagnose t on a.code = t.type WHERE 1 = 1 AND t.inpatient_id = '" + Pid + "' AND a.code = 'I' AND A.TYPE = '10939503') union all";
            //}
            //else
            //{
            //    sql += " select distinct '入院诊断' as 诊疗类别,null as 诊断名称,null 疾病编码,null 症候,null as 中西医,null as 主要诊断,null as 类型,2 as 序号,null as ID  from (select count(t.type) as h from cover_diagnose t where 1 = 1) union all";
            //}

            ////中医
            //if (ds_O.Tables[0].Rows.Count > 0)
            //{//正常逻辑
            //    sql += " select distinct '出院诊断' as 诊疗类别,a as 诊断名称,b 疾病编码,c 症候,f as 中西医,g as 主要诊断,h 类型,3 as 序号,i as ID from (select t.name as a,t.ICD10CODE as b,SYMPTOMS_NAME as c,incondition as d,pnumber as e,(case when is_chinese = 0 then '西医' else '中医' end) as f,(case when t.type = 'M' then '√' else '' end) as g,t.type as h,t.id as i from t_data_code a left join cover_diagnose t on a.code = t.type WHERE 1 = 1 AND t.inpatient_id = '" + Pid + "' AND a.code in('M','O') AND A.TYPE = '10939503') union all";
            //}
            //else
            //{//如果无数据，计算一空行进行显示
            //    sql += " select distinct '出院诊断' as 诊疗类别,null as 诊断名称,null 疾病编码,null 症候,null as 中西医,null as 主要诊断,null as 类型,3 as 序号,null as id from (select count(t.type) as h from cover_diagnose t where 1 = 1) union all";
            //}

            //if (ds_D.Tables[0].Rows.Count > 0)
            //{
            //    sql += " select distinct '死亡诊断' as 诊疗类别,a as 诊断名称,b 疾病编码,c 症候,f as 中西医,g as 主要诊断,h 类型,4 as 序号,i as ID from (select t.name as a,t.ICD10CODE as b,SYMPTOMS_NAME as c,incondition as d,pnumber as e,(case when is_chinese = 0 then '西医' else '中医' end) as f,(case when t.type = 'M' then '√' else '' end) as g,t.type as h,t.id as i from t_data_code a left join cover_diagnose t on a.code = t.type WHERE 1 = 1 AND t.inpatient_id = '" + Pid + "' AND a.code = 'D' AND A.TYPE = '10939503') union all";
            //}
            //else
            //{
            //    sql += " select distinct '死亡诊断' as 诊疗类别,null as 诊断名称,null 疾病编码,null 症候,null as 中西医,null as 主要诊断,null as 类型,4 as 序号,null as id from (select count(t.type) as h from cover_diagnose t where 1 = 1) union all";
            //}

            //if (ds_P.Tables[0].Rows.Count > 0)
            //{
            //    sql += " select distinct '病理诊断' as 诊疗类别,a as 诊断名称,b 疾病编码,c 症候,f as 中西医,g as 主要诊断,h 类型,5 as 序号,i as ID from (select t.name as a,t.ICD10CODE as b,SYMPTOMS_NAME as c,incondition as d,pnumber as e,(case when is_chinese = 0 then '西医' else '中医' end) as f,(case when t.type = 'M' then '√' else '' end) as g,t.type as h,t.id as i from t_data_code a left join cover_diagnose t on a.code = t.type WHERE 1 = 1 AND t.inpatient_id = '" + Pid + "' AND a.code = 'P' AND A.TYPE = '10939503') union all";
            //}
            //else
            //{
            //    sql += " select distinct '病理诊断' as 诊疗类别,null as 诊断名称,null 疾病编码,null 症候,null as 中西医,null as 主要诊断,null as 类型,5 as 序号,null as id from (select count(t.type) as h from cover_diagnose t where 1 = 1) union all";
            //}

            //if (ds_S.Tables[0].Rows.Count > 0)
            //{
            //    sql += " select '损伤、中毒的外部原因' as 诊疗类别,a as 诊断名称,b 疾病编码,c 症候,f as 中西医,g as 主要诊断,h 类型, 6 as 序号,i as ID from (select t.name as a,t.ICD10CODE as b,SYMPTOMS_NAME as c,incondition as d,pnumber as e,(case when is_chinese = 0 then '西医' else '中医' end) as f,(case when t.type = 'M' then '√' else '' end) as g,t.type as h,t.id as i from t_data_code a left join cover_diagnose t on a.code = t.type WHERE 1 = 1 AND t.inpatient_id = '" + Pid + "' AND a.code = 'S' AND A.TYPE = '10939503') union all";
            //}
            //else
            //{
            //    sql += " select '损伤、中毒的外部原因' as 诊疗类别,null as 诊断名称,null 疾病编码,null 症候,null as 中西医,null as 主要诊断,null as 类型, 6 as 序号,null as id from (select count(t.type) as h from cover_diagnose t where 1 = 1) union all";
            //}

            //if (ds_H.Tables[0].Rows.Count > 0)
            //{
            //    sql += " select distinct '院内感染' as 诊疗类别,a as 诊断名称,b 疾病编码,c 症候,f as 中西医,g as 主要诊断,h 类型,7 as 序号,i as ID from (select t.name as a,t.ICD10CODE as b,SYMPTOMS_NAME as c,incondition as d,pnumber as e,(case when is_chinese = 0 then '西医' else '中医' end) as f,(case when t.type = 'M' then '√' else '' end) as g,t.type as h,t.id as i from t_data_code a left join cover_diagnose t on a.code = t.type WHERE 1 = 1 AND t.inpatient_id = '" + Pid + "' AND a.code = 'H' AND A.TYPE = '10939503')";
            //}
            //else
            //{
            //    sql += " select distinct '院内感染' as 诊疗类别,null as 诊断名称,null 疾病编码,null 症候,null as 中西医,null as 主要诊断,null as 类型,7 as 序号,null as id from (select count(t.type) as h from cover_diagnose t where 1 = 1)";
            //}
            #endregion

            sql = "select distinct r as 诊疗类别,a as 诊断名称,b 疾病编码,c 症候,f as 中西医,g as 主要诊断,h 类型,i as ID,u as 序号 from (select (case when t.type='I' THEN '入院诊断' when t.type='O' THEN '出院诊断' when t.type='D' THEN '死亡诊断' when t.type='E' THEN '门诊诊断' when t.type='P' THEN '病理诊断' when t.type='S' THEN '损伤、中毒的外部原因' ELSE '院内感染' END) AS R,t.name as a,t.ICD10CODE as b,SYMPTOMS_NAME as c,incondition as d,pnumber as e,(case when is_chinese = 0 then '西医' else '中医' end) as f,(case when t.type = 'M' then '√' else ''end) as g,t.type as h,t.id as i,t.d_number as u from t_data_code a left join cover_diagnose t on a.code = t.type WHERE 1 = 1 AND t.inpatient_id = '" + Pid + "' AND A.TYPE = '10939503') order by u asc";
            //TODO:
            //左侧数据源
            ds1 = App.GetDataSet(sql);
            dgv_1.DataSource = ds1.Tables[0].DefaultView;
            dgv_1.Columns["类型"].Visible = false;
            dgv_1.Sort(dgv_1.Columns["诊疗类别"], ListSortDirection.Ascending);
            //dgv_1.Columns["序号"].Visible = false;
            //表格只能使用代码进行排序
            for (int i = 0; i < this.dgv_1.Columns.Count; i++)
            {
                this.dgv_1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //右侧数据源
            ds2 = App.GetDataSet(sql);
            dt = App.GetDataSet(sql).Tables[0];
            dgv_2.DataSource = ds2.Tables[0].DefaultView;
            dgv_2.Columns["类型"].Visible = false;
            dgv_2.Sort(dgv_2.Columns["诊疗类别"], ListSortDirection.Ascending);
            //dgv_2.Columns["序号"].Visible = false;
            //表格只能使用代码进行排序
            for (int i = 0; i < this.dgv_2.Columns.Count; i++)
            {
                this.dgv_2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgv_1.Columns[8].Visible = false;
            dgv_2.Columns[8].Visible = false;
            //}
            #endregion
        }
        #region 合并单元格
        /// <summary>
        /// 诊断合并单元格 
        /// </summary>
        /// <param name="sender">dgv_1</param>
        /// <param name="e"></param>
        private void dgv_1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                Brush datagridBrush = new SolidBrush(dgv_1.GridColor);
                SolidBrush groupLineBrush = new SolidBrush(e.CellStyle.BackColor);
                using (Pen datagridLinePen = new Pen(datagridBrush))
                {
                    // 清除单元格
                    e.Graphics.FillRectangle(groupLineBrush, e.CellBounds);
                    if (e.RowIndex < dgv_1.Rows.Count - 1 && dgv_1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value != null && dgv_1.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString())
                    {
                        //绘制底边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        // 画右边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    }
                    else
                    {
                        // 画右边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    }
                    //对最后一条记录只画底边线
                    if (e.RowIndex == dgv_1.Rows.Count - 1)
                    {
                        //绘制底边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }
                    // 填写单元格内容，相同的内容的单元格只填写第一个                        
                    if (e.Value != null)
                    {
                        if (!(e.RowIndex > 0 && dgv_1.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == e.Value.ToString()))
                        {
                            //绘制单元格内容
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault);
                        }
                    }
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// 诊断合并单元格 
        /// </summary>
        /// <param name="sender">dgv_2</param>
        /// <param name="e"></param>
        private void dgv_2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                Brush datagridBrush = new SolidBrush(dgv_2.GridColor);
                SolidBrush groupLineBrush = new SolidBrush(e.CellStyle.BackColor);
                using (Pen datagridLinePen = new Pen(datagridBrush))
                {
                    // 清除单元格
                    e.Graphics.FillRectangle(groupLineBrush, e.CellBounds);
                    if (e.RowIndex < dgv_2.Rows.Count - 1 && dgv_2.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value != null && dgv_2.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString() != e.Value.ToString())
                    {
                        //绘制底边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                        // 画右边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    }
                    else
                    {
                        // 画右边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    }
                    //对最后一条记录只画底边线
                    if (e.RowIndex == dgv_2.Rows.Count - 1)
                    {
                        //绘制底边线
                        e.Graphics.DrawLine(datagridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right, e.CellBounds.Bottom - 1);
                    }
                    // 填写单元格内容，相同的内容的单元格只填写第一个                        
                    if (e.Value != null)
                    {
                        if (!(e.RowIndex > 0 && dgv_2.Rows[e.RowIndex - 1].Cells[e.ColumnIndex].Value.ToString() == e.Value.ToString()))
                        {
                            //绘制单元格内容
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font, Brushes.Black, e.CellBounds.X + 2, e.CellBounds.Y + 5, StringFormat.GenericDefault);
                        }
                    }
                    e.Handled = true;
                }
            }
        }
        #endregion
        /// <summary>
        /// 双击单元格进入编目修改界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            isChinese = dgv_2.Rows[e.RowIndex].Cells[4].Value.ToString();//获取中西医
            dgv_2.ReadOnly = false;
            foreach (DataGridViewColumn col in dgv_2.Columns)
            {
                if (col.Name == "疾病编码")
                {
                    col.ReadOnly = false;
                }
                else
                {
                    col.ReadOnly = true;
                }
            }

        }
        private void dgv_2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dgvBoxEditingControl = (DataGridViewTextBoxEditingControl)e.Control;
            dgvBoxEditingControl.KeyUp += new KeyEventHandler(dgvBoxEditingControl_KeyUp);
        }

        void dgvBoxEditingControl_KeyUp(object sender, KeyEventArgs e)
        {
            System.Windows.Forms.TextBox txtBox = sender as System.Windows.Forms.TextBox;
            if (txtBox.ReadOnly == true)
                return;
            App.FastCodeFlag = false;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        string text = txtBox.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            DataInit.D_Edite = true;
                            App.SelectObj = null;
                            int length = text.Length;
                            string sql_select = "";
                            if (isChinese == "西医")
                            {
                                sql_select = "select distinct id 疾病编码,name 疾病名称 from (select ICD10_ID AS id, name from t_diag_def t where t.is_chn = 'N' union all select code AS id, name FROM diag_def_icd10 a where a.is_chinese = 'N') where 1 = 1 and upper(id) like '%" + text.ToUpper() + "%'";
                            }
                            else
                            {
                                sql_select = "select bm_code 疾病编码,bm_name 疾病名称 from t_bm where 1 = 1 and upper(bm_code) like '%" + text.ToUpper() + "%'";
                            }
                            string BABM = "";
                            App.FastCodeCheck(sql_select, txtBox, "疾病编码", "疾病名称", BABM);
                            App.FastCodeFlag = true;
                        }
                    }
                }
            }
            catch
            { }
        }
        /// <summary>
        /// 监听消息钩子
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref　Message msg, Keys keyData)
        {

            if (keyData == Keys.Down || keyData == Keys.Up)　　//监听 上、下 事件　
            {
                if (this.dgv_2.IsCurrentCellInEditMode)　　//如果当前单元格处于编辑模式　
                {
                    return true;
                }
            }
            //继续原来base.ProcessCmdKey中的处理　
            return base.ProcessCmdKey(ref　msg, keyData);
        }
        /// <summary>
        /// 提交 诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_tj_Click(object sender, EventArgs e)
        {
            try
            {
                /*
             * T_IN_Code_Information 编目信息表
             * ID
             * 编目状态
             * 编目人
             * 编目时间
             * 住院号
             */
                //获取病人ID
                string Inpatient_ID = App.ReadSqlVal("select ID from t_in_patient where pid='" + Pid + "'", 0, "ID");
                //执行插入操作
                string CodeState = "提交";
                string CodeName = App.UserAccount.UserInfo.User_name;
                DateTime CodeTime = App.GetSystemTime();
                int ID = App.GenId();
                DataInit.ID = ID;
                string User_Id = App.UserAccount.UserInfo.User_id;
                IPAddress ip = System.Net.IPAddress.Parse(App.GetHostIp());
                int count = 0;
                int count_xh = 0;
                //TODO:
                List<string> ls_1_icd10 = new List<string>();//存储dgv_1中的疾病编码
                List<string> ls_1_ID = new List<string>();//存储dgv_1中的疾病主键ID
                List<string> ls_diagnoseType = new List<string>();
                List<string> ls_diagnoseName = new List<string>();
                List<string> ls_isChinses = new List<string>();
                List<string> ls_mainDiagnose = new List<string>();
                List<string> ls_zh = new List<string>();
                List<string> ls_xh = new List<string>();
                for (int i = 0; i < dgv_1.Rows.Count - 1; i++)
                {
                    string icd10_1_Diagnose = dgv_1.Rows[i].Cells["疾病编码"].Value.ToString();
                    string ID_1_Diagnose = dgv_1.Rows[i].Cells["ID"].Value.ToString();
                    string diagnoseType = dgv_1.Rows[i].Cells["诊疗类别"].Value.ToString();
                    string diagnoseName = dgv_1.Rows[i].Cells["诊断名称"].Value.ToString();
                    string isChinses = dgv_1.Rows[i].Cells["中西医"].Value.ToString();
                    string mainDiagnose = dgv_1.Rows[i].Cells["主要诊断"].Value.ToString();
                    string zh = dgv_1.Rows[i].Cells["症候"].Value.ToString();
                    string xh = dgv_1.Rows[i].Cells["序号"].Value.ToString();
                    ls_1_icd10.Add(icd10_1_Diagnose);
                    ls_1_ID.Add(ID_1_Diagnose);
                    ls_diagnoseType.Add(diagnoseType);
                    ls_diagnoseName.Add(diagnoseName);
                    ls_isChinses.Add(isChinses);
                    ls_mainDiagnose.Add(mainDiagnose);
                    ls_zh.Add(zh);
                    ls_xh.Add(xh);
                }
                List<string> ls_2_icd10 = new List<string>();//存储dgv_2中的疾病编码
                List<string> ls_2_ID = new List<string>();//存储dgv_2中的疾病主键ID
                List<string> ls_2_xh = new List<string>();//存储dgv_2中的疾病主键ID
                for (int i = 0; i < dgv_2.Rows.Count - 1; i++)
                {
                    string icd10_2_Diagnose = dgv_2.Rows[i].Cells["疾病编码"].Value.ToString();
                    string ID_2_Diagnose = dgv_2.Rows[i].Cells["ID"].Value.ToString();
                    string xh_2 = dgv_2.Rows[i].Cells["序号"].Value.ToString();
                    ls_2_icd10.Add(icd10_2_Diagnose);
                    ls_2_ID.Add(ID_2_Diagnose);
                    ls_2_xh.Add(xh_2);
                }
                //获取改变之前的数据
                //获取改变之后的数据
                for (int k = 0; k < ls_1_icd10.Count; k++)
                {
                    if ((ls_1_icd10[k].ToString() != ls_2_icd10[k].ToString() && ls_1_ID[k].ToString() == ls_2_ID[k].ToString()))
                    {
                        count++;
                        int _ID = App.GenId();
                        int ID_ = App.GenId();
                        string diagnoseCode_Befor = ls_1_icd10[k].ToString();//之前的诊断编码
                        string diagnoseCode_After = ls_2_icd10[k].ToString();//之后的诊断编码
                        string iid = ls_2_ID[k].ToString();//与首页诊断表主键相关联的ID
                        string befor = "修改前"; string after = "修改后";
                        /*
                         * 1.先插入之前的诊断信息
                         * 2.再插入之后的诊断信息
                         * 3.更新cover_diagnose中的诊断信息
                         * **/
                        string Sql_Diagnose_Befor = "insert into T_IN_Code_Diagnose(ID,PATIENT_ID,diagnosetype,diagnosename,diagnosecode,ischinses,maindiagnose,zh,user_id,iid,key_id,befororafter)values('" + _ID + "','" + Pid + "','" + ls_diagnoseType[k].ToString() + "','" + ls_diagnoseName[k].ToString() + "','" + diagnoseCode_Befor + "','" + ls_isChinses[k].ToString() + "','" + ls_mainDiagnose[k].ToString() + "','" + ls_zh[k].ToString() + "','" + User_Id + "','" + iid + "','" + ID + "','" + befor + "')";
                        App.ExecuteSQL(Sql_Diagnose_Befor);//1
                        string Sql_Diagnose_After = "insert into T_IN_Code_Diagnose(ID,PATIENT_ID,diagnosetype,diagnosename,diagnosecode,ischinses,maindiagnose,zh,user_id,iid,key_id,befororafter)values('" + ID_ + "','" + Pid + "','" + ls_diagnoseType[k].ToString() + "','" + ls_diagnoseName[k].ToString() + "','" + diagnoseCode_After + "','" + ls_isChinses[k].ToString() + "','" + ls_mainDiagnose[k].ToString() + "','" + ls_zh[k].ToString() + "','" + User_Id + "','" + iid + "','" + ID + "','" + after + "')";
                        App.ExecuteSQL(Sql_Diagnose_After);//2
                        string Sql_Update = "update cover_diagnose set icd10code='" + diagnoseCode_After + "' where id='" + iid + "'";//3
                        App.ExecuteSQL(Sql_Update);
                    }
                    if (ls_xh[k].ToString() != ls_2_xh[k].ToString())
                    {
                        count_xh++;
                        string iid = ls_2_ID[k].ToString();//与首页诊断表主键相关联的ID
                        string xh_2 = ls_2_xh[k].ToString();
                        string Sql_Update = "update cover_diagnose set d_number='" + xh_2 + "' where id='" + iid + "'";
                        App.ExecuteSQL(Sql_Update);
                    }
                }
                if (count > 0 || DataInit.Count > 0)
                {
                    string Sql_Information = "insert into T_IN_Code_Information(ID,PATIENT_ID,CODESTATE,CODENAME,CODETIME,INPATIENT_ID,user_id,ip)values('" + ID + "','" + Pid + "','" + CodeState + "','" + CodeName + "',to_date('" + CodeTime + "','yyyy-MM-dd hh24:mi:ss'),'" + Inpatient_ID + "','" + User_Id + "','" + ip + "')";
                    App.ExecuteSQL(Sql_Information);
                    App.Msg("提交成功!");
                    DataInit.A_btnSelect(sender, e);
                }
                else if (count_xh > 0 || DataInit.Count_xh > 0)
                {
                    App.Msg("排序成功！");
                }
                else
                {
                    App.Msg("提交失败,未检测到数据更改!");
                }
                LED_Diagnose();
                ls_1_icd10 = null;
                ls_1_ID = null;
                ls_diagnoseType = null;
                ls_diagnoseName = null;
                ls_isChinses = null;
                ls_mainDiagnose = null;
                ls_zh = null;
                ls_2_icd10 = null;
                ls_2_ID = null;
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.ToString());
            }
        }
        /// <summary>
        /// 上移
        /// 事件 buttonX2_Click
        /// 名字不做改动
        /// 承载界面委托调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }
            int rowIndex = dgv_2.SelectedRows[0].Index;  //得到当前选中行的索引 
            dgv_1.Rows[0].Selected = false;
            if (rowIndex == 0)
            {
                MessageBox.Show("已经是第一行了!");
                return;
            }
            string dgvType = dgv_2.Rows[rowIndex].Cells[0].Value.ToString();
            string dgvUpType = dgv_2.Rows[rowIndex - 1].Cells[0].Value.ToString();//
            if (dgvType == dgvUpType)
            {
                List<string> list = new List<string>();
                List<string> list_ = new List<string>();
                for (int i = 0; i < dgv_2.Columns.Count; i++)
                {
                    list.Add(dgv_2.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中  
                    list_.Add(dgv_2.Rows[rowIndex - 1].Cells[i].Value.ToString());
                }
                for (int j = 0; j < dgv_2.Columns.Count; j++)
                {
                    if (j < 8)
                    {
                        dgv_2.Rows[rowIndex].Cells[j].Value = dgv_2.Rows[rowIndex - 1].Cells[j].Value;
                        dgv_2.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
                    }
                    else
                    {
                        dgv_2.Rows[rowIndex].Cells[j].Value = list[j].ToString();
                        dgv_2.Rows[rowIndex - 1].Cells[j].Value = list_[j].ToString();
                    }
                }
                dgv_2.Rows[rowIndex - 1].Selected = true;
                dgv_2.Rows[rowIndex].Selected = false;
                this.dgv_2.Refresh();

                List<string> list2 = new List<string>();
                List<string> list_2 = new List<string>();
                for (int h = 0; h < dgv_1.Columns.Count; h++)
                {
                    list2.Add(dgv_1.Rows[rowIndex].Cells[h].Value.ToString());   //把当前选中行的数据存入list数组中  
                    list_2.Add(dgv_1.Rows[rowIndex - 1].Cells[h].Value.ToString());
                }
                for (int l = 0; l < dgv_1.Columns.Count; l++)
                {
                    dgv_1.Rows[rowIndex].Cells[l].Value = dgv_1.Rows[rowIndex - 1].Cells[l].Value;
                    dgv_1.Rows[rowIndex - 1].Cells[l].Value = list2[l].ToString();
                }
                dgv_1.Rows[rowIndex - 1].Selected = false;
                dgv_1.Rows[rowIndex].Selected = false;
                this.dgv_1.Refresh();
                DataInit.D_UpOrNext = true;
            }
            else
            {
                App.Msg("只限制在同一类型诊断内移动！");
            }

        }
        /// <summary>
        /// 下移
        /// 事件 buttonX3_Click
        /// 名字不做改动
        /// 承载界面委托调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }
            int rowIndex = dgv_2.SelectedRows[0].Index;  //得到当前选中行的索引     
            dgv_1.Rows[0].Selected = false;
            if (rowIndex == dgv_2.Rows.Count - 1)
            {
                MessageBox.Show("已经是最后一行了!");
                return;
            }
            string dgvType = dgv_2.Rows[rowIndex].Cells[0].Value.ToString();
            string dgvNextType = dgv_2.Rows[rowIndex + 1].Cells[0].Value.ToString();//
            if (dgvType == dgvNextType)
            {
                List<string> list = new List<string>();
                List<string> list_ = new List<string>();
                for (int i = 0; i < dgv_2.Columns.Count; i++)
                {
                    list.Add(dgv_2.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中  
                    list_.Add(dgv_2.Rows[rowIndex + 1].Cells[i].Value.ToString());
                }

                for (int j = 0; j < dgv_2.Columns.Count; j++)
                {
                    if (j < 8)
                    {
                        dgv_2.Rows[rowIndex].Cells[j].Value = dgv_2.Rows[rowIndex + 1].Cells[j].Value;
                        dgv_2.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
                    }
                    else
                    {
                        dgv_2.Rows[rowIndex].Cells[j].Value = list[8].ToString();
                        dgv_2.Rows[rowIndex + 1].Cells[j].Value = list_[8].ToString();
                    }
                }
                dgv_2.Rows[rowIndex + 1].Selected = true;
                dgv_2.Rows[rowIndex].Selected = false;
                this.dgv_2.Refresh();
                List<string> list2 = new List<string>();
                List<string> list_2 = new List<string>();
                for (int h = 0; h < dgv_1.Columns.Count; h++)
                {
                    list2.Add(dgv_1.Rows[rowIndex].Cells[h].Value.ToString());   //把当前选中行的数据存入list数组中  
                    list_2.Add(dgv_1.Rows[rowIndex + 1].Cells[h].Value.ToString());
                }
                for (int l = 0; l < dgv_1.Columns.Count; l++)
                {
                    dgv_1.Rows[rowIndex].Cells[l].Value = dgv_1.Rows[rowIndex + 1].Cells[l].Value;
                    dgv_1.Rows[rowIndex + 1].Cells[l].Value = list2[l].ToString();
                }
                dgv_1.Rows[rowIndex + 1].Selected = false;
                dgv_1.Rows[rowIndex].Selected = false;
                this.dgv_1.Refresh();
                DataInit.D_UpOrNext = true;
            }
            else
            {
                App.Msg("只限制在同一类型诊断内移动！");
            }
        }
    }
}
