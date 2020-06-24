using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Data.OleDb;
using C1.Win.C1FlexGrid;
using System.Collections;
using DevComponents.DotNetBar;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR.SurgeryManager;
using Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE;
using Base_Function.BLL_MANAGEMENT;
using QualityControl;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucYWCParam : UserControl
    {
        ColumnInfo[] cols = new ColumnInfo[15];
        
        string T_YWC_Quality_Sql = "select * from QUALITY_VAR_YWC_VIEW q order by q.文档类型,q.执行周期 desc";
        private DataTable dataTable;
        private DataRow newrow;

        Class_Quality_Var_YWC ywc = new Class_Quality_Var_YWC();
        Class_Quality_YWC_View ywcv = new Class_Quality_YWC_View();
        public DataSet DS_SECTIONTABLE = null;
        CellNote note;

        DataSet CBO_DS;// 初始化下拉列表框数据集

        #region  属性
        private static bool modifyFlag = false;
        private static string flexSection;
        private static bool doubleModifyFlag = false;

        /// <summary>
        /// 界面上双击修改科室标识
        /// </summary>
        public static bool DoubleModifyFlag
        {
            get { return ucYWCParam.doubleModifyFlag; }
            set { ucYWCParam.doubleModifyFlag = value; }
        }

        /// <summary>
        /// 修改操作标识
        /// </summary>
        public static bool ModifyFlag
        {
            get { return ucYWCParam.modifyFlag; }
            set { ucYWCParam.modifyFlag = value; }
        }

        /// <summary>
        /// 用于区别现有规则与新规则是否存在相同科室
        /// </summary>
        public static string FlexSection
        {
            get { return flexSection; }
            set { flexSection = value; }
        }

        #endregion

        /// <summary>
        /// 刷新FlexGrid的委托
        /// </summary>
        public delegate void DisplayUpdate(bool flag);

        /// <summary>
        /// 显示TextBox的值
        /// </summary>
        public delegate void DisplayTextBoxValue();

        public ucYWCParam()
        {
            InitializeComponent();
            InitCombobox();
            Con_ClearCntrValue.ClearCntrValue(this.groupBox1, true);
            frmYWCParam_Load(null, null);
            c1FlexGrid1.AllowEditing = false;

        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset(false);
        }

        private void rdoIsOverAlert_CheckedChanged(object sender, EventArgs e)
        {
            //是否预警
            if (this.rdoIsOverAlert.Checked == true)
            {
                this.IsOverAlert(true);
            }
            else
            {
                this.IsOverAlert(false);
            }
        }

        /// <summary>
        /// 是否预警显示控制
        /// </summary>
        /// <param name="flag"></param>
        private void IsOverAlert(bool flag)
        {
            this.cboPrealertUnit.Enabled = flag;
            this.txtPrealertTime.Enabled = flag;
        }

        private void rdoIsMend_CheckedChanged(object sender, EventArgs e)
        {
            //超时补上是否扣分
            if (this.rdoIsMend.Checked == true)
            {
                txtDeduction.Enabled = true;//扣分值
            }
            else
            {
                txtDeduction.Enabled = false;
            }
        }



        /// <summary>
        /// 保存规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            //文书类型
            if (cboTextKind.SelectedIndex != 0)
            {
                ywc.Document_type = Convert.ToInt32(this.cboTextKind.SelectedValue.ToString());
            }
            else
            {
                App.MsgErr("请选择文书类型");
                return;
            }

            //患者类型
            if (cboMonitorType.SelectedIndex != 0)
            {
                ywc.Inpatient_type = Convert.ToInt32(this.cboMonitorType.SelectedValue.ToString());
            }
            else
            {
                App.MsgErr("请选择患者类型");
                return;
            }

            //参考时间
            if (cboCKTime.SelectedIndex != 0)
            {
                ywc.Base_time = Convert.ToInt32(this.cboCKTime.SelectedValue.ToString());
            }
            else
            {
                App.MsgErr("请选择参考时间");
                return;
            }

            //偏移时间
            if (txtTrueTime.Text != "")
            {
                ywc.True_time = Convert.ToInt32(this.txtTrueTime.Text);
                ywc.Truetime_unit = this.cboTrueTimeUnit.SelectedItem.ToString();//偏移时间单位   
            }
            else
            {
                ywc.True_time = 0;
                ywc.Truetime_unit = "";
                //App.MsgErr("请输入偏移时间");
                //return;
            }

            //执行总次数
            if (txtExceTimes.Text != "")
            {
                ywc.Excetimes = Convert.ToInt32(this.txtExceTimes.Text);
            }
            else
            {
                ywc.Excetimes = 0;

            }

            //执行周期
            //if (txtExecCycles.Enabled == true && cboCyclesUnit.Enabled == true)
            //{
            if (txtExecCycles.Text == "")
            {
                ywc.Runcycle = 0;
                ywc.Runcycleunit = "";
                //App.MsgErr("请输入执行周期");
                //return;
            }

            else
            {
                ywc.Runcycle = Convert.ToInt32(txtExecCycles.Text);
                ywc.Runcycleunit = cboCyclesUnit.SelectedItem.ToString();
            }
            //}


            //是否预警
            if (this.rdoIsOverAlert.Checked == true)
            {
                ywc.Isprealert = 'Y';

            }
            else
            {
                ywc.Isprealert = 'N';

            }

            //超时补上是否扣分
            if (this.rdoIsMend.Checked == true)
            {
                ywc.Is_take_grade = 'Y';

            }
            else
            {
                ywc.Is_take_grade = 'N';

            }

            if (this.txtPrealertTime.Enabled == true)
            {
                //预警时间
                if (this.txtPrealertTime.Text != null && this.txtPrealertTime.Text != "")
                {
                    ywc.Prealerttime = Convert.ToInt32(this.txtPrealertTime.Text);//预警时间
                    ywc.Pretimeunit = this.cboPrealertUnit.SelectedItem.ToString();//预警单位     
                }
                else
                {
                    App.Msg("请输入预警时间");
                }
            }
            else
            {
                ywc.Prealerttime = 0;//预警时间
                ywc.Pretimeunit = "";//预警单位
            }

            //扣分值
            if (txtDeduction.Enabled == true)
            {
                ywc.Take_grade = Convert.ToDouble(this.txtDeduction.Text);
            }

            //是否提醒

            if (this.rdoIsNotice.Checked == true)
            {
                ywc.Is_notice = 'Y';
            }
            else
            {
                ywc.Is_notice = 'N';
            }

            ywc.Isoveralert = 'Y';//警告
            ywc.Overalerttime = 0;//报警提前时间(超过)
            ywc.Overtimeunit = "";//报警提前时间单位(超过)
            ywc.Threadstate = 1;//线程状态-----------默认为1，启动

            ywc.Effect_section = frmSectionCheck.YwcSectionID;

            if (ywc.Id == 0)
            {
                string temp = "insert into T_QUALITY_VAR_YWC(DOCUMENT_TYPE,INPATIENT_TYPE,BASE_TIME,TRUE_TIME,TRUETIME_UNIT,RUNCYCLE,RUNCYCLEUNIT,ISPREALERT,PREALERTTIME,PRETIMEUNIT,ISOVERALERT,OVERALERTTIME,OVERTIMEUNIT,IS_TAKE_GRADE,TAKE_GRADE,IS_NOTICE,THREADSTATE,EXCETIMES,EFFECT_SECTION,EXE_COUNT) values(" + ywc.Document_type + "," + ywc.Inpatient_type + "," + ywc.Base_time + "," + ywc.True_time + ",'" + ywc.Truetime_unit + "'," + ywc.Runcycle + ",'" + ywc.Runcycleunit + "','" + ywc.Isprealert + "'," + ywc.Prealerttime + ",'" + ywc.Pretimeunit + "','" + ywc.Isoveralert + "'," + ywc.Overalerttime + ",'" + ywc.Overtimeunit + "','" + ywc.Is_take_grade + "'," + ywc.Take_grade + ",'" + ywc.Is_notice + "','" + ywc.Threadstate + "'," + ywc.Excetimes + ",'" + ywc.Effect_section + "','1')";

                int i = 0;
                DialogResult result = MessageBox.Show("确认要保存数据？", "消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    i = App.ExecuteSQL(temp);
                }
                else
                {
                    return;
                }

                if (i > 0)
                {
                    App.Msg("添加成功！");
                    Reset(true);
                    //c1FlexGrid1.Select(c1FlexGrid1.Rows.Count - 1, 0);
                }
                else
                {
                    App.MsgErr("添加失败！");
                }
            }
            else
            {

                string tempUpdate = "update T_QUALITY_VAR_YWC t set DOCUMENT_TYPE=" + ywc.Document_type + ",INPATIENT_TYPE=" + ywc.Inpatient_type + ",BASE_TIME=" + ywc.Base_time + ",TRUE_TIME=" + ywc.True_time + ",TRUETIME_UNIT='" + ywc.Truetime_unit + "',RUNCYCLE=" + ywc.Runcycle + ",RUNCYCLEUNIT='" + ywc.Runcycleunit + "',ISPREALERT='" + ywc.Isprealert + "',PREALERTTIME=" + ywc.Prealerttime + ",PRETIMEUNIT='" + ywc.Pretimeunit + "',ISOVERALERT='" + ywc.Isoveralert + "',OVERALERTTIME=" + ywc.Overalerttime + ",OVERTIMEUNIT='" + ywc.Overtimeunit + "',IS_TAKE_GRADE='" + ywc.Is_take_grade + "',TAKE_GRADE=" + ywc.Take_grade + ",IS_NOTICE='" + ywc.Is_notice + "',THREADSTATE='" + ywc.Threadstate + "',EXCETIMES=" + ywc.Excetimes + ",EFFECT_SECTION='" + ywc.Effect_section + "' where t.id=" + ywc.Id;

                int i = 0;
                DialogResult resultUpdate = MessageBox.Show("确认要保存已修改的数据？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultUpdate == DialogResult.OK)
                {
                    i = App.ExecuteSQL(tempUpdate);
                }
                else
                {
                    return;
                }

                if (i > 0)
                {
                    App.Msg("数据修改成功！");

                    //c1FlexGrid1.Select(c1FlexGrid1.RowSel, 0);
                    Reset(true);
                    ywc.Id = 0;
                    return;
                }
                else
                {
                    App.MsgErr("数据修改失败！");
                    return;
                }
            }
        }

        private void btnSectionSelect_Click(object sender, EventArgs e)
        {

            //文书类型
            if (cboTextKind.SelectedIndex != 0)
            {
                ywc.Document_type = Convert.ToInt32(this.cboTextKind.SelectedValue.ToString());
            }
            else
            {
                App.MsgErr("请选择文书类型");
                return;
            }

            //患者类型
            if (cboMonitorType.SelectedIndex != 0)
            {
                ywc.Inpatient_type = Convert.ToInt32(this.cboMonitorType.SelectedValue.ToString());
            }
            else
            {
                App.MsgErr("请选择患者类型");
                return;
            }


            SectionSelFilter();

            //用于判断是否是新增或者修改规则
            if (ModifyFlag) //修改或者是预览列表中的科室
            {
                frmSectionCheck.YwcSectionName = this.txtSectionText.Text;
            }
            if (!ModifyFlag) //新增加
            {
                frmSectionCheck.Id = null;
                frmSectionCheck.DocumentType = null;
                frmSectionCheck.YwcSectionID = null;
                frmSectionCheck.YwcSectionName = null;
                //flexSection = null;
            }

            frmSectionCheck sc = new frmSectionCheck();
            sc.ShowTextBoxValue += new DisplayTextBoxValue(ShowTextBoxValue);

            sc.ShowDialog();
        }

        /// <summary>
        /// 获得科室名称
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public string GetSectionName(string note)
        {
            string[] strtemp = note.Split(',');

            Class_Table[] qualityTable = new Class_Table[strtemp.Length];
            for (int i = 0; i < qualityTable.Length; i++)
            {
                qualityTable[i] = new Class_Table();
                qualityTable[i].Sql = "select sec.section_name from t_sectioninfo sec where sec.sid=" + strtemp[i] + " and sec.enable_flag='Y'";
                qualityTable[i].Tablename = i.ToString();
            }


            DS_SECTIONTABLE = App.GetDataSet(qualityTable);

            string resultList = "";


            for (int j = 0; j < DS_SECTIONTABLE.Tables.Count; j++)
            {
                if (DS_SECTIONTABLE.Tables[j].Rows.Count != 0) //判断如果旧数据中包含有现在已经删除的科室，则跳过
                {
                    resultList += string.Format("{0},", DS_SECTIONTABLE.Tables[j].Rows[0][0].ToString());
                }

            }
            return resultList.Trim(',');
        }

        #region 表头设置

        /// <summary>
        /// 表头设置
        /// </summary>
        public void TableSet()
        {
            c1FlexGrid1.Cols.Count = 15;
            c1FlexGrid1.Rows.Count = 1;
            c1FlexGrid1.Rows.Fixed = 1;
            //表头设置
            cols[0].Name = "编号";
            cols[0].Field = "id";
            cols[0].Index = 1;
            cols[0].visible = true;

            cols[1].Name = "文书类型";
            cols[1].Field = "document_Type";
            cols[1].Index = 2;
            cols[1].visible = true;

            cols[2].Name = "患者类型";
            cols[2].Field = "inpatient_Type";
            cols[2].Index = 3;
            cols[2].visible = true;

            cols[3].Name = "参考时间";
            cols[3].Field = "base_Time";
            cols[3].Index = 4;
            cols[3].visible = true;

            cols[4].Name = "偏移时间";
            cols[4].Field = "true_time";
            cols[4].Index = 5;
            cols[4].visible = true;

            cols[5].Name = "执行周期";
            cols[5].Field = "runcycle";
            cols[5].Index = 6;
            cols[5].visible = true;

            cols[6].Name = "执行总次数";
            cols[6].Field = "excetimes";
            cols[6].Index = 7;
            cols[6].visible = true;

            cols[7].Name = "是否预警";
            cols[7].Field = "isprealert";
            cols[7].Index = 8;
            cols[7].visible = true;

            cols[8].Name = "预警时间";
            cols[8].Field = "prealerttime";
            cols[8].Index = 9;
            cols[8].visible = true;

            cols[9].Name = "是否扣分";
            cols[9].Field = "is_take_grade";
            cols[9].Index = 10;
            cols[9].visible = true;

            cols[10].Name = "扣分值";
            cols[10].Field = "take_grade";
            cols[10].Index = 11;
            cols[10].visible = true;

            cols[11].Name = "是否提醒";
            cols[11].Field = "is_notice";
            cols[11].Index = 12;
            cols[11].visible = true;

            cols[12].Name = "科室";
            cols[12].Field = "effect_section";
            cols[12].Index = 13;
            cols[12].visible = true;

            cols[13].Name = "线程状态";
            cols[13].Field = "threadState";
            cols[13].Index = 14;
            cols[13].visible = true;

            cols[14].Name = "科室2";
            cols[14].Field = "effect_section";
            cols[14].Index = 15;
            cols[14].visible = true;

        }


        private void CellUnit()
        {
            c1FlexGrid1[0, 0] = "编号";
            c1FlexGrid1[0, 1] = "文书类型";
            c1FlexGrid1[0, 2] = "患者类型";
            c1FlexGrid1[0, 3] = "参考时间";
            c1FlexGrid1[0, 4] = "偏移时间";
            c1FlexGrid1[0, 5] = "执行周期";
            c1FlexGrid1[0, 6] = "执行总次数";
            c1FlexGrid1[0, 7] = "是否预警";
            c1FlexGrid1[0, 8] = "预警时间";
            c1FlexGrid1[0, 9] = "是否扣分";
            c1FlexGrid1[0, 10] = "扣分值";
            c1FlexGrid1[0, 11] = "是否提醒";
            c1FlexGrid1[0, 12] = "科室";
            c1FlexGrid1[0, 13] = "线程状态";
            c1FlexGrid1[0, 14] = "科室2";
            c1FlexGrid1.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            c1FlexGrid1.Cols.Fixed = 0;

            //c1FlexGrid1.AutoSizeCols();
        }

        #endregion


        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            doubleModifyFlag = true;
            SectionSelFilter();

            if (c1FlexGrid1.RowSel > 0)
            {
                //frmSectionCheck.Id = c1FlexGrid1[c1FlexGrid1.RowSel, 0].ToString();//所双击那行的ID
                frmSectionCheck.DocumentType = c1FlexGrid1[c1FlexGrid1.RowSel, 1].ToString();//所双击那行的文书类型

                CellRange rg = c1FlexGrid1.GetCellRange(c1FlexGrid1.RowSel, 12);//科室

                CellNote no = (CellNote)rg.UserData;

                if (c1FlexGrid1[0, c1FlexGrid1.ColSel].ToString().Trim() != null)
                {

                    if (c1FlexGrid1[0, c1FlexGrid1.ColSel].ToString().Trim() == "科室")
                    {
                        if (no != null)
                        {
                            frmSectionCheck.YwcSectionName = no.NoteText;//科室
                            frmSectionCheck sc = new frmSectionCheck();
                            sc.ShowUpdate += new DisplayUpdate(Reset);
                            sc.ShowDialog();
                        }
                        else
                        {
                            frmSectionCheck.YwcSectionName = null;
                            frmSectionCheck sc = new frmSectionCheck();
                            sc.ShowUpdate += new DisplayUpdate(Reset);
                            sc.ShowDialog();

                        }
                    }
                }

            }
        }

        /// <summary>
        /// 初始化表格
        /// </summary>
        public void InitFlexGrid()
        {
            TableSet();

            DataSet ds = App.GetDataSet(T_YWC_Quality_Sql);

            int dscount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < dscount; i++)
            {
                c1FlexGrid1.Rows.Add();

                //视图的实体
                ywcv.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["编号"].ToString());
                ywcv.Document_Type = ds.Tables[0].Rows[i]["文档类型"].ToString();
                ywcv.Inpatient_Type = ds.Tables[0].Rows[i]["病人类型"].ToString();
                ywcv.Base_Time = ds.Tables[0].Rows[i]["参考时间"].ToString();
                ywcv.True_time = ds.Tables[0].Rows[i]["偏移时间"].ToString();
                ywcv.Runcycle = ds.Tables[0].Rows[i]["执行周期"].ToString();
                ywcv.Excetimes = Convert.ToInt32(ds.Tables[0].Rows[i]["执行总次数"].ToString());
                ywcv.Isprealert = ds.Tables[0].Rows[i]["是否预警"].ToString();
                ywcv.Prealerttime = ds.Tables[0].Rows[i]["预警时间"].ToString();
                ywcv.Is_Take_grade = ds.Tables[0].Rows[i]["是否扣分"].ToString();
                ywcv.Take_Grade = Convert.ToDouble(ds.Tables[0].Rows[i]["扣分值"].ToString());
                ywcv.Is_Notice = ds.Tables[0].Rows[i]["是否提醒"].ToString();
                ywcv.Effect_section = ds.Tables[0].Rows[i]["科室"].ToString();
                ywcv.ThreadState = ds.Tables[0].Rows[i]["线程状态"].ToString();

                c1FlexGrid1[1 + i, 0] = ywcv.Id;
                c1FlexGrid1[1 + i, 1] = ywcv.Document_Type;
                c1FlexGrid1[1 + i, 2] = ywcv.Inpatient_Type;
                c1FlexGrid1[1 + i, 3] = ywcv.Base_Time;
                c1FlexGrid1[1 + i, 4] = IsNotNull(ywcv.True_time);
                c1FlexGrid1[1 + i, 5] = IsNotNull(ywcv.Runcycle);
                c1FlexGrid1[1 + i, 6] = IsNotNull(ywcv.Excetimes.ToString());
                c1FlexGrid1[1 + i, 7] = ywcv.Isprealert;
                c1FlexGrid1[1 + i, 8] = ywcv.Prealerttime;
                c1FlexGrid1[1 + i, 9] = ywcv.Is_Take_grade;
                c1FlexGrid1[1 + i, 10] = Temperature(ywcv.Take_Grade.ToString());
                c1FlexGrid1[1 + i, 11] = ywcv.Is_Notice;
                c1FlexGrid1[1 + i, 12] = null;
                c1FlexGrid1[1 + i, 13] = ywcv.ThreadState;
                c1FlexGrid1[1 + i, 14] = ywcv.Effect_section;

            }


            for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
            {
                /*
                 * 科室图标
                 */
                CellRange rg1 = c1FlexGrid1.GetCellRange(i, 12);
                rg1.Image = imageList1.Images[0];

            }
            c1FlexGrid1.Cols[12].ImageAlign = ImageAlignEnum.CenterCenter;

            //hide ID colum
            c1FlexGrid1.Cols[0].Visible = false;
            // hide Notes column (we'll use CellNotes instead)
            c1FlexGrid1.Cols[14].Visible = false;
            //c1FlexGrid1.Cols[12].AllowEditing = false; //不允许编辑
            c1FlexGrid1.AllowEditing = false;
            // create cell notes for every employee
            int noteColumn = c1FlexGrid1.Cols[12].Index;

            for (int r = c1FlexGrid1.Rows.Fixed; r < c1FlexGrid1.Rows.Count; r++)
            {
                string temp = c1FlexGrid1[r, 14] as string;

                if (temp != "")
                {
                    // create note
                    note = new CellNote(GetSectionName(temp));

                    // attach note to "FirstName" column
                    CellRange rg = c1FlexGrid1.GetCellRange(r, noteColumn);
                    rg.UserData = note;
                }
            }

            // create manager to display/edit the cell notes
            CellNoteManager mgr = new CellNoteManager(c1FlexGrid1);
            CellUnit();
        }


        private void ShowTextBoxValue()
        {
            this.txtSectionText.Text = frmSectionCheck.YwcSectionName;
        }

        # region KeyPress
        private void txtTrueTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            Con_Regex.IsNumberForKeyPress(e);
        }

        private void txtExecCycles_KeyPress(object sender, KeyPressEventArgs e)
        {
            Con_Regex.IsNumberForKeyPress(e);
        }

        private void txtExceTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            Con_Regex.IsNumberForKeyPress(e);
        }

        private void txtPrealertTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            Con_Regex.IsNumberForKeyPress(e);
        }
        #endregion

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel > 0)
            {
                string id = c1FlexGrid1[c1FlexGrid1.RowSel, 0].ToString();//所双击那行的ID
                string documentType = c1FlexGrid1[c1FlexGrid1.RowSel, 1].ToString();//所双击那行的文书类型             
                string tempDelete = "delete t_quality_var_ywc t where t.id=" + id;
                int i = 0;
                DialogResult result = MessageBox.Show("确认要删除此“" + documentType + "”的规则？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    i = App.ExecuteSQL(tempDelete);
                }
                else
                {
                    return;
                }

                if (i > 0)
                {
                    App.Msg("数据删除成功！");
                    Reset(true);
                }
                else
                {
                    App.MsgErr("数据删除失败！");
                }
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ywc.Id = Convert.ToInt32(c1FlexGrid1[c1FlexGrid1.RowSel, 0].ToString());//所双击那行的ID
            string documentType = c1FlexGrid1[c1FlexGrid1.RowSel, 1].ToString();//所双击那行的文书类型                   
            cboTextKind.Text = documentType;

            cboMonitorType.Text = c1FlexGrid1[c1FlexGrid1.RowSel, 2].ToString();//病人
            cboCKTime.Text = c1FlexGrid1[c1FlexGrid1.RowSel, 3].ToString();//参考时间

            string trueTime = c1FlexGrid1[c1FlexGrid1.RowSel, 4] == null ? "" : c1FlexGrid1[c1FlexGrid1.RowSel, 4].ToString();//偏移时间(时间+单位的字符串)
            txtTrueTime.Text = trueTime == "" ? trueTime : trueTime.Substring(0, trueTime.IndexOf(" "));//时间
            cboTrueTimeUnit.Text = trueTime == "" ? "小时" : trueTime.Substring(trueTime.IndexOf(" ") + 1);//偏移单位
            string execCycles = c1FlexGrid1[c1FlexGrid1.RowSel, 5] == null ? "" : c1FlexGrid1[c1FlexGrid1.RowSel, 5].ToString();//执行周期(时间+单位的字符串)
            txtExecCycles.Text = execCycles == "" ? execCycles : execCycles.Substring(0, execCycles.IndexOf(" "));//时间
            cboCyclesUnit.Text = execCycles == "" ? "小时" : execCycles.Substring(execCycles.IndexOf(" ") + 1).Substring(0, 1);//周期单位
            txtExceTimes.Text = c1FlexGrid1[c1FlexGrid1.RowSel, 6] == null ? "0" : c1FlexGrid1[c1FlexGrid1.RowSel, 6].ToString();// 执行总次数          
            string isprealert = c1FlexGrid1[c1FlexGrid1.RowSel, 7].ToString();//是否预警
            if (isprealert == "是")
            {
                this.rdoIsOverAlert.Checked = true;
                string prealertTime = c1FlexGrid1[c1FlexGrid1.RowSel, 8].ToString();//预警时间(时间+单位的字符串)
                txtPrealertTime.Text = prealertTime.Substring(0, prealertTime.IndexOf(" "));//时间
                this.cboPrealertUnit.Text = prealertTime.Substring(prealertTime.IndexOf(" ") + 1);//预警单位
            }
            else
            {
                this.rdoIsOverAlertF.Checked = true;
            }

            string is_Take_grade = c1FlexGrid1[c1FlexGrid1.RowSel, 9].ToString();//是否扣分
            if (is_Take_grade == "是")
            {
                this.rdoIsMend.Checked = true;
                txtDeduction.Text = c1FlexGrid1[c1FlexGrid1.RowSel, 10].ToString();//扣分值                   
            }
            else
            {
                this.rdoIsMendF.Checked = true;
            }

            string is_notice = c1FlexGrid1[c1FlexGrid1.RowSel, 11].ToString();//是否提醒
            if (is_notice == "是")
            {
                this.rdoIsNotice.Checked = true;
            }
            else
            {
                this.rdoIsNoticeF.Checked = true;
            }

            CellRange rg = c1FlexGrid1.GetCellRange(c1FlexGrid1.RowSel, 12);//科室
            CellNote no = (CellNote)rg.UserData;
            if (no != null)
            {
                frmSectionCheck.YwcSectionName = no.NoteText;//科室名字
                frmSectionCheck.YwcSectionID = c1FlexGrid1[c1FlexGrid1.RowSel, 14].ToString();//科室ID
                txtSectionText.Text = no.NoteText;
            }
            else
            {
                frmSectionCheck.YwcSectionName = null;
                frmSectionCheck.YwcSectionID = null;
                txtSectionText.Text = "";
            }

            modifyFlag = true;//修改操作
        }


        public string IsNotNull(string temp)
        {
            if (temp.Trim() == "0")
            {
                return null;
            }
            if (temp == null)
            {
                return "";
            }
            if (temp == "0 /次")
            {
                return null;
            }
            return temp;

        }

        /// <summary>
        /// 科室选择过滤
        /// </summary>
        public void SectionSelFilter()
        {
            flexSection = null;

            if (c1FlexGrid1.Rows.Count > 1)
            {
                string docType = null;
                string huanz = null;

                if (doubleModifyFlag)
                {
                    frmSectionCheck.Id = c1FlexGrid1[c1FlexGrid1.RowSel, 0].ToString(); ;//ID
                    CellRange docTypeCR = c1FlexGrid1.GetCellRange(c1FlexGrid1.RowSel, 1);//文书类型
                    CellRange huanzCR = c1FlexGrid1.GetCellRange(c1FlexGrid1.RowSel, 2);//患者类型

                    docType = docTypeCR.Data.ToString();
                    huanz = huanzCR.Data.ToString();
                }
                else if (modifyFlag)
                {
                    for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
                    {
                        if (ywc.Id.ToString() != c1FlexGrid1.Rows[i][0].ToString())
                        {
                            if (cboTextKind.Text == c1FlexGrid1.Rows[i][1].ToString() &&
                                cboMonitorType.Text == c1FlexGrid1.Rows[i][2].ToString())
                            {
                                CellRange cr = c1FlexGrid1.GetCellRange(i, 12);//科室 
                                if (cr.UserData != null)
                                {
                                    CellNote cn = (CellNote)cr.UserData;
                                    flexSection += String.Format("{0},", cn.NoteText);
                                }
                            }
                        }
                    }
                    if (flexSection != null)
                    {
                        flexSection.Trim(',');
                    }
                    return;
                }
                else
                {
                    docType = this.cboTextKind.Text;
                    huanz = this.cboMonitorType.Text;
                }
                for (int i = 1; i < c1FlexGrid1.Rows.Count; i++)
                {
                    if (frmSectionCheck.Id != c1FlexGrid1.Rows[i][0].ToString())
                    {
                        if (docType == c1FlexGrid1.Rows[i][1].ToString() &&
                            huanz == c1FlexGrid1.Rows[i][2].ToString())
                        {
                            CellRange cr = c1FlexGrid1.GetCellRange(i, 12);//科室 
                            if (cr.UserData != null)
                            {
                                CellNote cn = (CellNote)cr.UserData;
                                flexSection += String.Format("{0},", cn.NoteText);
                            }
                        }
                    }
                    else if (frmSectionCheck.Id == null)
                    {

                        CellRange rg = c1FlexGrid1.GetCellRange(i, 12);//科室
                        if (rg.UserData != null)
                        {
                            CellNote no = (CellNote)rg.UserData;
                            flexSection += String.Format("{0},", no.NoteText);
                        }
                    }
                }
                if (flexSection != null)
                {
                    flexSection.Trim(',');
                }
            }
        }

        /// <summary>
        /// 重设
        /// </summary>
        public void Reset(bool flag)
        {
            ModifyFlag = false;
            flexSection = null;
            doubleModifyFlag = false;
            if (flag)
            {
                InitFlexGrid();
            }
            frmSectionCheck.YwcSectionName = null;
            frmSectionCheck.YwcSectionID = null;

            frmSectionCheck.Id = null;
            frmSectionCheck.DocumentType = null;
            Con_ClearCntrValue.ClearCntrValue(this.groupBox1, true);
        }

        /// <summary>
        /// 初始化Combobox
        /// </summary>
        public void InitCombobox()
        {
            Class_Table[] cboTables = new Class_Table[3];

            //初始化文书类型
            cboTables[0] = new Class_Table();
            cboTables[0].Sql = "select * from t_data_code ta where ta.type=18 and enable='Y' order by decode(name,'首次病程记录',1,'D型病例查房',2,'入院记录',3,'再次（多次）入院记录',4,'24小时入出院',5,'24小时入院死亡',6,'病程',7,'主治查房',8,'病危患者病程记录',9,'病重患者病程记录',10,'转入记录',11,'转出记录',12,'交班记录',13,'接班记录',14,'会诊记录',15,'抢救记录',16,'手术记录',17,'术后首次病程记录',18,'术后病程',19,'阶段小结',20,'出院记录',21,'死亡记录',22,'死亡病历讨论记录',23,24)";
            cboTables[0].Tablename = "TextKind";

            //监控患者类型
            cboTables[1] = new Class_Table();
            cboTables[1].Sql = "select * from t_data_code where type=27";
            cboTables[1].Tablename = "MonitorType";

            //参考时间
            cboTables[2] = new Class_Table();
            cboTables[2].Sql = "select * from t_data_code where type=28";
            cboTables[2].Tablename = "CKTime";

            CBO_DS = App.GetDataSet(cboTables);

            //初始化文书类型
            dataTable = CBO_DS.Tables["TextKind"];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboTextKind.DataSource = CBO_DS.Tables["TextKind"].DefaultView;
            this.cboTextKind.ValueMember = "ID";
            this.cboTextKind.DisplayMember = "Name";

            //监控患者类型
            dataTable = CBO_DS.Tables["MonitorType"];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboMonitorType.DataSource = CBO_DS.Tables["MonitorType"].DefaultView;
            this.cboMonitorType.ValueMember = "ID";
            this.cboMonitorType.DisplayMember = "Name";

            //参考时间
            dataTable = CBO_DS.Tables["CKTime"];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboCKTime.DataSource = CBO_DS.Tables["CKTime"].DefaultView;
            this.cboCKTime.ValueMember = "ID";
            this.cboCKTime.DisplayMember = "Name";

            //ucRecordMonitor uc = new ucRecordMonitor("医务处", CBO_DS.Tables["TextKind"].DefaultView,true);
            //ucQualityList ucr = new ucQualityList("医务处", CBO_DS.Tables["TextKind"].DefaultView);
        }



        private void frmYWCParam_Load(object sender, EventArgs e)
        {
            try
            {
                App.SetToolButtonByUser("ttsbtnPrint", false);
                App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                App.SetToolButtonByUser("tsbtnTempSave", false);
                App.SetToolButtonByUser("tsbtnCommit", false);
                App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);
                App.SetToolButtonByUser("tsbtnTemplateSave", false);//保存模版
                //延安妇幼老版质控屏蔽
                //InitFlexGrid();
                //病案查阅
                UserfrmQueryLevy ucQueryLevy = new UserfrmQueryLevy();

                ucQueryLevy.Dock = System.Windows.Forms.DockStyle.Fill;
                ucQueryLevy.Location = new System.Drawing.Point(3, 3);
                ucQueryLevy.Name = "ucQueryLevy";
                ucQueryLevy.Size = new System.Drawing.Size(940, 698);
                ucQueryLevy.TabIndex = 0;

                tabControlPanel5.Controls.Add(ucQueryLevy);


                //延安妇幼-新版质控报表
                QualityControl.UcMainForm ucQuality = new QualityControl.UcMainForm(1);

                ucQuality.Dock = System.Windows.Forms.DockStyle.Fill;
                ucQuality.Name = "ucQuality";
                tabControlPanel39.Controls.Add(ucQuality);

            

                //手术维护
                //ucfrmOperationVindicate ucOperation = new ucfrmOperationVindicate();

                //ucOperation.Dock = System.Windows.Forms.DockStyle.Fill;
                //ucOperation.Location = new System.Drawing.Point(3, 3);
                //ucOperation.Name = "ucOperation";
                //ucOperation.Size = new System.Drawing.Size(940, 698);
                //ucOperation.TabIndex = 0;
                //App.UsControlStyle(ucOperation);
                //tabControlPanel3.Controls.Add(ucOperation);


                //手术审批
                //UcApproval ucOpationA = new UcApproval();

                //ucOpationA.Dock = System.Windows.Forms.DockStyle.Fill;
                //ucOpationA.Location = new System.Drawing.Point(3, 3);
                //ucOpationA.Name = "ucOpationA";
                //ucOpationA.Size = new System.Drawing.Size(940, 698);
                //ucOpationA.TabIndex = 0;
                //App.UsControlStyle(ucOpationA);
                //tabControlPanel8.Controls.Add(ucOpationA);

                //手术权限
                //ucfrmAccraditationPermission ucOpationB = new ucfrmAccraditationPermission();

                //ucOpationB.Dock = System.Windows.Forms.DockStyle.Fill;
                //ucOpationB.Location = new System.Drawing.Point(3, 3);
                //ucOpationB.Name = "ucOpationB";
                //ucOpationB.Size = new System.Drawing.Size(940, 698);
                //ucOpationB.TabIndex = 0;
                //App.UsControlStyle(ucOpationB);
                //tabControlPanel7.Controls.Add(ucOpationB);

                #region 延安妇幼-老版质控屏蔽
                //主观评分
                //ucfrmMainGradeRepart ucGradeA = new ucfrmMainGradeRepart();

                //ucGradeA.Dock = System.Windows.Forms.DockStyle.Fill;
                //ucGradeA.Location = new System.Drawing.Point(3, 3);
                //ucGradeA.Name = "ucGradeA";
                //ucGradeA.Size = new System.Drawing.Size(940, 698);
                //ucGradeA.TabIndex = 0;
                //App.UsControlStyle(ucGradeA);
                //tabControlPanel23.Controls.Add(ucGradeA);

                //管床医生监控列表
                //ucRecordMonitor ucRecord = new ucRecordMonitor("医务处", CBO_DS.Tables["TextKind"].DefaultView, true);
                //tabControlPanel25.Controls.Add(ucRecord);
                //ucRecord.Dock = System.Windows.Forms.DockStyle.Fill;

                //详细列表
                //ucQualityList ucquality = new ucQualityList("医务处", CBO_DS.Tables["TextKind"].DefaultView);
                //tabControlPanel29.Controls.Add(ucquality);
                //ucquality.Dock = System.Windows.Forms.DockStyle.Fill;

                //客观观评分
                //Uckgpf ucGradeB = new Uckgpf();

                //ucGradeB.Dock = System.Windows.Forms.DockStyle.Fill;
                //ucGradeB.Location = new System.Drawing.Point(3, 3);
                //ucGradeB.Name = "ucGradeB";
                //ucGradeB.TabIndex = 1;
                //App.UsControlStyle(ucGradeB);
                //tabControlPanel33.Controls.Add(ucGradeB);
                #endregion

                //解锁文书
                ucUnlockDoc ucDoc = new ucUnlockDoc();

                ucDoc.Dock = System.Windows.Forms.DockStyle.Fill;
                ucDoc.Location = new System.Drawing.Point(3, 3);
                ucDoc.Name = "ucDoc";
                ucDoc.TabIndex = 1;
                App.UsControlStyle(ucDoc);
                tabControlPanel41.Controls.Add(ucDoc);

                
                //封存文书
                //ucSafeUpDoc ucUpDoc = new ucSafeUpDoc();

                //ucDoc.Dock = System.Windows.Forms.DockStyle.Fill;
                //ucDoc.Location = new System.Drawing.Point(3, 3);
                //ucDoc.Name = "ucUpDoc";
                //ucDoc.TabIndex = 1;
                //App.UsControlStyle(ucUpDoc);
                //tabControlPanel40.Controls.Add(ucUpDoc);

                //插入消息提醒
                //ucMessageList ucmsg=new ucMessageList();
                //tabControlPanel30.Controls.Add(ucmsg);
                //ucmsg.Dock = System.Windows.Forms.DockStyle.Fill;  

                if (App.UserAccount.CurrentSelectRole.Role_type == "Y")
                {//医务科屏蔽项
                    //this.tabItem22.Visible = false;//质控参数设置
                }

            }
            catch (Exception)
            {                
                //throw;
            }


        }


        /// <summary>
        /// 验证体温数据如果后面有.的话，就默认为一位小数，如果是整数的话，就添加.0
        /// </summary>
        /// <param name="newValue">体温数据</param>
        /// <returns></returns>
        public string Temperature(string newValue)
        {
            if (newValue.ToString().Contains("."))
            {
                int index = newValue.ToString().IndexOf('.');
                newValue = newValue.ToString().Substring(0, index + 2);


            }
            else
            {
                newValue = newValue.ToString() + ".0";
            }
            if (newValue == "0.0")
            {
                newValue = "";
            }
            return newValue;
        }

        private void tabItem29_Click(object sender, EventArgs e)
        {

        }

        private void ctlPnlBingWei_Click(object sender, EventArgs e)
        {

        }

        private void tabSpectial_Case_Click(object sender, EventArgs e)
        {
            foreach (TabItem tabit in tabctlCase.Tabs)
            {
                if(tabit.AttachedControl.Controls.Count==0)
                {
                    bool isvisable = false;
                    string old_Name = string.Empty;
                    string new_Name = string.Empty;
                    string[] cols=null;
                    string sql = GetSql(tabit.Text.Trim(),ref isvisable,out old_Name,out new_Name,ref cols);
                    UcCase uccase=null;
                    if (cols != null)
                    {
                        uccase = new UcCase(sql, isvisable, old_Name, new_Name,cols);
                    }
                    else
                    {
                        uccase = new UcCase(sql, isvisable, old_Name, new_Name);
                    }
                    tabit.AttachedControl.Controls.Add(uccase);
                    uccase.Dock = DockStyle.Fill;
                }
            }
        }
        /// <summary>
        /// 获得sql语句
        /// </summary>
        /// <param name="strtext">当前item的文本</param>
        /// <param name="isVisable">是否显示在院，出院</param>
        /// <param name="old_name">原来列</param>
        /// <param name="new_name">新列</param>
        /// <param name="cols">要隐藏的列</param>
        /// <returns></returns>
        private string GetSql(string strtext,ref bool isVisable,out string old_name,out string new_name,ref string[] cols)
        {
            string sql=string.Empty;
            old_name = "";
            new_name = "";
            switch (strtext)
            {
                //病危,病重,危+重选项页未使用,所以注释了
                //case "病危":
                //    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室," +
                //           " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,a.id,a.BIRTHDAY from t_in_patient a" +
                //           " inner join (select min(id) id,patient_id from t_diagnose_item "+
                //           " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id"+
                //           " inner join t_diagnose_item c on b.id = c.id"+
                //           " where a.sick_degree='3'  and a.die_time is null  order by 住院号)";
                //    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time";
                //    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间";
                //    cols = new string[2];
                //    cols[0] = "id";
                //    cols[1] = "BIRTHDAY";
                //    break;
                //case "病重":
                //    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室," +
                //           " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,a.id,a.BIRTHDAY from t_in_patient a" +
                //           " inner join (select min(id) id,patient_id from t_diagnose_item " +
                //           " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id" +
                //           " inner join t_diagnose_item c on b.id = c.id" +
                //           " where a.sick_degree='2'  and a.die_time is null  order by 住院号)";
                //    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time";
                //    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间";
                //    cols = new string[2];
                //    cols[0] = "id";
                //    cols[1] = "BIRTHDAY";
                //    break;
                //case "危+重":
                //    string str = @"""危+重""";
                //    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室," +
                //           " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间," +
                //           " (case a.sick_degree when '1' then '病危' else '病重' end) " + str + " ,a.id,a.BIRTHDAY from t_in_patient a" +
                //           " inner join (select min(id) id,patient_id from t_diagnose_item " +
                //           " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id" +
                //           " inner join t_diagnose_item c on b.id = c.id" +
                //           " where a.sick_degree in('3','2')  and a.die_time is null  order by 住院号)";
                //    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time,sick_degree";
                //    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间,危+重";
                //    cols = new string[2];
                //    cols[0] = "id";
                //    cols[1] = "BIRTHDAY";
                //    break;
                case "手术":

//                    sql = @"select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then  '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄, 
//                              a.section_name 科室,a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, 
//                              to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,to_char(f.operations_time, 'yyyy-MM-dd HH24:mi') 手术时间, 
//                              a.die_time,a.id,a.BIRTHDAY from t_in_patient a 
//                              left outer join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c 
//                              on a.id=c.patient_id 
//                              inner join (select patient_id,t.operations_time  from t_vital_signs t where t.describe like '%手术%') f 
//                              on a.id = f.patient_id order by 姓名)";
                    sql = @"select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then  '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄, 
                              a.section_name 科室,a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, 
                              to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,REPLACE(doc_name, '术后首次病程记录', '')  术后首次病程记录, 
                              a.die_time,a.id,a.BIRTHDAY from t_in_patient a 
                              left outer join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c 
                              on a.id=c.patient_id 
                              inner join (select tp.tid, tp.patient_id, tp.doc_name from t_patients_doc tp  where textkind_id = 136 and tp.submitted = 'Y') f 
                              on a.id = f.patient_id order by 姓名)";
                    //20140313:LWM改 手术时间, 手术及操作名称 这两个字段统一取病案首页中手术页的记录.
                    //sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then  '女' else '男' end) 性别,case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄, " +
                    //          "a.section_name 科室,a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, " +
                    //          "to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,o.oper_date 手术时间, o.oper_name 手术及操作名称, " +
                    //          "a.die_time,a.id,a.BIRTHDAY from t_in_patient a " +
                    //          " inner join  cover_operation o on a.id = o.patient_id " +
                    //          " left join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c " +
                    //          " on a.id=c.patient_id " +
                    //          " order by 住院号)";
                        cols = new string[3];
                        cols[0] = "die_time";
                        cols[1] = "id";
                        cols[2] = "BIRTHDAY";
                    break;
                case "死亡":
                    //sql =" select * from (select a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,"+
                    //     " a.age 年龄,a.Age_unit 年龄单位,a.section_name 科室,a.sick_area_name 病区,a.sick_doctor_name 管床医生," +
                    //     " b.入院诊断,b.死亡诊断,a.in_time 入院时间,a.die_time 死亡时间 from t_in_patient a"+
                    //     " inner join (select patient_id,"+
                    //     " max(case diagnose_type when '408' then diagnose_name end) 入院诊断,"+
                    //     " max(case diagnose_type when '407' then diagnose_name end) 死亡诊断 "+
                    //     " from t_diagnose_item "+
                    //     " where id in (select min(id) from t_diagnose_item "+
                    //     " where diagnose_type='407' and patient_id is not null"+
                    //     " group by patient_id,diagnose_type union"+
                    //     " select min(id) from t_diagnose_item "+
                    //     " where diagnose_type='408' and patient_id is not null"+
                    //     " group by patient_id,diagnose_type) "+
                    //     " group by patient_id) b on a.id = b.patient_id " +
                    //     " inner join (select min(tid) tid,patient_id from t_patients_doc "+
                    //     " where textkind_id=138 group by patient_id order by patient_id) c on b.patient_id=c.patient_id)";
                    //old_name = "patient_name 姓名,gender_code,age,section_name,sick_area_name,sick_doctor_name,in_diagnose,in_time,dead_diagnose,die_time";
                    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间,死亡诊断,死亡时间";
                    sql = "select * from (select a.pid 住院号,a.patient_name 姓名, (case a.gender_code when '1' then  '女' else  '男' end) 性别, " +
                          "case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄, a.section_name 科室, a.sick_area_name 病区, a.sick_doctor_name 管床医生, " +
                          "b.入院诊断, b.死亡诊断, to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间, to_char(a.die_time, 'yyyy-MM-dd HH24:mi') 死亡时间,a.id,a.BIRTHDAY " +
                          "from t_in_patient a " +
                          "left outer join (select patient_id, max(case diagnose_type when '408' then diagnose_name end) 入院诊断, " +
                          "max(case diagnose_type when '407' then diagnose_name end) 死亡诊断 " +
                          "from t_diagnose_item where id in " +
                          "(select min(id) from t_diagnose_item where diagnose_type = '407' and patient_id is not null " +
                          "group by patient_id, diagnose_type " +
                          "union " +
                          "select min(id) from t_diagnose_item where diagnose_type = '408' and patient_id is not null " +
                          "group by patient_id, diagnose_type) " +
                          "group by patient_id) b " +
                          "on a.id = b.patient_id where a.DIE_FLAG=1  order by 住院号)";
                    cols = new string[2];
                    cols[0] = "id";
                    cols[1] = "BIRTHDAY";
                    break;
                case "输血记录":
                    //sql = "select e.* from (select a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,concat(age,age_unit) 年龄,a.section_name 科室," +
                    //       " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time,'yyyy-MM-dd HH24:mi') 入院时间," +
                    //       " a.die_time,a.id from t_in_patient a inner join (select min(id) id,patient_id from t_diagnose_item "+
                    //       " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id "+
                    //       " left join t_diagnose_item c on b.id = c.id "+
                    //       " order by patient_name) e "+
                    //       " inner join (select min(tid) tid,patient_id from t_patients_doc "+
                    //       " where textkind_id=153 group by patient_id order by patient_id) f on e.id = f.patient_id";
                    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time";
                    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间";
                    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别, " +
                           "case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室,a.sick_area_name 病区, " +
                           "a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, "+
                           "to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间, "+
                           "REPLACE(doc_name,'临床输血申请单','') 临床输血申请单,a.die_time,a.id,a.BIRTHDAY " +
                           "from t_in_patient a "+
                           "left outer join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c "+
                           "on a.id=c.patient_id "+
                           "inner join (select tp.tid,tp.patient_id,tp.doc_name from t_patients_doc tp  where textkind_id = 47555630 and tp.submitted='Y') f " +
                           "on a.id = f.patient_id order by 住院号)";
                    isVisable = true;
                    cols = new string[3];
                    cols[0] = "die_time";
                    cols[1] = "id";
                    cols[2] = "BIRTHDAY";
                    break;
                case "抢救记录":
                    //sql = "select e.* from (select a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别,a.age 年龄,a.Age_unit 年龄单位,a.section_name 科室," +
                    //    " a.sick_area_name 病区,a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断,to_char(a.in_time,'yyyy-MM-dd HH24:mi') 入院时间," +
                    //    " a.die_time,a.id from t_in_patient a inner join (select min(id) id,patient_id from t_diagnose_item " +
                    //    " where diagnose_type='408' group by patient_id) b on a.id = b.patient_id " +
                    //    " left join t_diagnose_item c on b.id = c.id " +
                    //    " order by patient_name) e " +
                    //    " inner join (select min(tid) tid,patient_id from t_patients_doc " +
                    //    " where textkind_id=132 group by patient_id order by patient_id) f on e.id = f.patient_id";
                    //old_name = "patient_name,gender_code,age,section_name,sick_area_name,sick_doctor_name,diagnose_name,in_time";
                    //new_name = "姓名,性别,年龄,科室,病区,管床医生,入院诊断,入院时间";
                    sql = "select * from (select a.pid 住院号,a.patient_name 姓名,(case a.gender_code when '1' then '女' else '男' end) 性别, " +
                           "case when age is null then child_age when age='-' then child_age when age='0' then child_age else concat(age,age_unit) end  年龄,a.section_name 科室,a.sick_area_name 病区, " +
                           "a.sick_doctor_name 管床医生,c.diagnose_name 入院诊断, " +
                           "to_char(a.in_time, 'yyyy-MM-dd HH24:mi') 入院时间,REPLACE(doc_name,'抢救记录','') 抢救记录, " +
                           "a.die_time,a.id,a.BIRTHDAY " +
                           "from t_in_patient a " +
                           "left outer join (select b.patient_id,a.diagnose_name　from t_diagnose_item a inner join (select min(id) id,patient_id from t_diagnose_item  where diagnose_type='408' group by patient_id) b on a.id=b.id) c " +
                           "on a.id=c.patient_id " +
                           "inner join (select tp.tid,tp.patient_id,tp.doc_name from t_patients_doc tp  where textkind_id = 132 and tp.submitted='Y') f " +
                           "on a.id = f.patient_id order by 住院号)";
                    isVisable = true;
                    cols = new string[3];
                    cols[0] = "die_time";
                    cols[1] = "id";
                    cols[2] = "BIRTHDAY";
                    break;
                default:
                    break;
            }
            return sql;
        }
    }
};