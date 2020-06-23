using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

using Microsoft.Reporting.WinForms;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    /// <summary>
    /// 病历复印记录
    /// </summary>
    /// 开发 李伟
    /// 开发时间 2010年7月10号
    public partial class CoseCopyRegister : UserControl
    {
        ColumnInfo[] column = new ColumnInfo[11];
        string ID = "";
        bool isSaveOrUpdate = false;
        //string cckBeInhospital = "";//住院志
        //string cckAnimalheat = "";//体温单
        //string cckDoctorsAdvice = "";//医嘱单
        //string cckAssay = "";//化验单(检验报告)
        //string cckBlipData = "";//医学影像检查资料
        //string cckcorpsAgree = "";//特殊检查(治疗)同意书
        //string cckOperation = "";//手术同意书
        //string cckOperationNote = "";//手术及麻醉记录单
        //string cckWork_UP = "";//病理报告
        //string cckNurseNote = "";//护理记录
        //string cckOutHospitalNote = "";//出院记录
        string sql = "";
        public CoseCopyRegister()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        DataSet ds = null;
        //private void SetTable()
        //{

        //    ucC1FlexGrid1.fg.Cols.Count = 15;
        //    ucC1FlexGrid1.fg.Cols.Fixed = 0;
        //    ucC1FlexGrid1.fg.Rows.Count = 1;
        //    ucC1FlexGrid1.fg.Rows.Fixed = 1;
        //}
        //显示列表数据
        //private void ShowValue()
        //{
        //    string SQl = T_SickRoomInfo + "  order by SRID asc";
        //    ucC1FlexGrid1.DataBd(SQl, "编号", "", "");
        //    ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
        //    ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
        //    ucC1FlexGrid1.fg.Cols["病区编号"].Visible = false;
        //    ucC1FlexGrid1.fg.Cols["病区编号"].AllowEditing = false;
        //    ucC1FlexGrid1.fg.Cols["等级编号"].Visible = false;
        //    ucC1FlexGrid1.fg.Cols["等级编号"].AllowEditing = false;
        //    ucC1FlexGrid1.fg.AllowEditing = false;
        //}

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select ID as ID,COPY_TIME as 复印时间,APPLY_UNIT as 申请单位,APPLY_PERSON as 申请人,CASE_ID as 病历号," +
                       "DEGREE_NUMBER as 身份证,JOB_NUMBER as 工作证号,TRUST_DEED as 委托书,DEAD_ARGUE as 死亡证明," +
                       "NEAR_RELATIVE_ARGUE as 近亲属关系证明,COPY_VALUE as 复印内容,RECORD_TIME as 记录时间 " +
                       "from T_CASE_COPY_RECORD where 1=1 ";
                string datatime = dtpTime.Value.ToString("yyyy-MM");


                if (casenum.Text.Trim() != "")
                {
                    sql += " and CASE_ID like '%" + casenum.Text + "%' ";
                }
                if (txtName.Text.Trim() != "")
                {
                    sql += " and APPLY_PERSON like '" + txtName.Text + "%'";
                }
                if (datatime != "")
                {
                    sql += " and to_char(COPY_TIME,'yyyy-MM') like '" + datatime + "%'";
                }



                ds = new DataSet();
                ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    ucC1FlexGrid1.DataBd(sql, "ID", "", "");
                    ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//设置ID隐藏
                    ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                    ucC1FlexGrid1.fg.AllowEditing = false;
                }
                else
                {
                    ucC1FlexGrid1.DataBd(sql, "ID", "", "");
                    ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//设置ID隐藏
                    ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                    ucC1FlexGrid1.fg.AllowEditing = false;
                }
            }
            catch (Exception ee)
            {
            }
            //SetHeard();// 合并单元格
        }
        /// <summary>
        /// 申请单位绑定
        /// </summary>
        public void GetAllSection_Name()
        {
            DataSet ds = new DataSet();
            string sql = "select * from t_data_code where enable='Y' and type=48";
            ds = App.GetDataSet(sql);
            this.cbbapplyunit.DataSource = ds.Tables[0].DefaultView;
            cbbapplyunit.DisplayMember = "NAME";
            cbbapplyunit.ValueMember = "ID";

            cbbapplyunit.SelectedIndex = 0;
        }

        /// <summary>
        /// 加载复印内容
        /// </summary>
        public void GetFYNR()
        {
            DataSet ds_FYLR = App.GetDataSet("select t.code,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where enable='Y' and t2.type='BLFYNR'");
            chkFYNR.DataSource = ds_FYLR.Tables[0].DefaultView;
            chkFYNR.DisplayMember = "name";
            chkFYNR.ValueMember = "code";
        }

        //窗体加载事件
        private void CoseCopyRegister_Load(object sender, EventArgs e)
        {
            try
            {
                sql = "select ID as ID,COPY_TIME as 复印时间,APPLY_UNIT as 申请单位,APPLY_PERSON as 申请人,CASE_ID as 病历号," +
               "DEGREE_NUMBER as 身份证,JOB_NUMBER as 工作证号,TRUST_DEED as 委托书,DEAD_ARGUE as 死亡证明," +
               "NEAR_RELATIVE_ARGUE as 近亲属关系证明,COPY_VALUE as 复印内容,RECORD_TIME as 记录时间 " +
               "from T_CASE_COPY_RECORD ";
                ds = new DataSet();
                ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    ucC1FlexGrid1.DataBd(sql, "ID", "", "");//根据ID 绑定到ucC1FlexGrid1控件

                    ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//设置ID隐藏
                    ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;//不能编辑
                    ucC1FlexGrid1.fg.AllowEditing = false;


                }
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);

                GetAllSection_Name();//申请单位绑定
                SetControlEnabled(); //加载时设置控件的呈现
                GetFYNR();//加载复印内容

                if (ucC1FlexGrid1.fg.Rows.Count > 1)
                {
                    ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//设置ID隐藏
                    ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                    ucC1FlexGrid1.fg.AllowEditing = false;
                }
            }
            catch { }
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//设置ID隐藏
                ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
            catch
            { }
        }
        //加载时设置控件的呈现
        private void SetControlEnabled()
        {
            #region
            this.cbbapplyunit.Enabled = false;
            this.txtApplyName.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.txtCaseName.Enabled = false;
            this.txtIDCard.Enabled = false;
            this.txtWorkCard.Enabled = false;
            this.checkDelegate.Enabled = false;
            this.checkDeath.Enabled = false;
            this.checkKindred.Enabled = false;
            this.chkFYNR.Enabled = false;
            foreach (int i in chkFYNR.CheckedIndices)
            {
                chkFYNR.SetItemChecked(i, false);
            }
            this.btnConfirm.Enabled = false;
            this.btncancel.Enabled = false;
            #endregion
        }
        //点击添加按钮时触发
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region
            isSaveOrUpdate = true;
            this.ucC1FlexGrid1.Enabled = false;
            this.cbbapplyunit.Enabled = true;
            this.txtApplyName.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.txtCaseName.Enabled = true;
            this.txtIDCard.Enabled = true;
            this.txtWorkCard.Enabled = true;
            this.checkDelegate.Enabled = true;
            this.checkDeath.Enabled = true;
            this.checkKindred.Enabled = true;
            this.chkFYNR.Enabled = true;
            foreach (int i in chkFYNR.CheckedIndices)
            {
                chkFYNR.SetItemChecked(i, false);
            }
            this.btnSave.Enabled = false;
            this.btnConfirm.Enabled = true;
            this.btncancel.Enabled = true;
            this.btnUpdate.Enabled = false;
            this.btnDalete.Enabled = false;
            this.txtApplyName.Text = "";
            this.txtCaseName.Text = "";
            this.txtIDCard.Text = "";
            this.txtWorkCard.Text = "";
            checkDelegate.Checked = false;
            checkDeath.Checked = false;
            checkKindred.Checked = false;
            #endregion
        }
        //点击取消按钮时触发
        private void btncancel_Click(object sender, EventArgs e)
        {
            SetControlEnabled();
            this.ucC1FlexGrid1.Enabled = true;
            this.btnConfirm.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnConfirm.Enabled = false;
            this.btnUpdate.Enabled = true;
            this.btnDalete.Enabled = true;
        }

        /// <summary>
        /// 点击确定按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                this.ucC1FlexGrid1.Enabled = true;
                string applyUnit = this.cbbapplyunit.Text.ToString();//申请单位
                string applyName = this.txtApplyName.Text.Trim();//申请人姓名
                string applyTime = this.dateTimePicker1.Text.ToString();//复印时间
                string caseName = this.txtCaseName.Text.Trim();//病历号
                string iDCard = this.txtIDCard.Text.Trim();//身份证号
                string workCard = this.txtWorkCard.Text.Trim();//工作证
                string cckdelegate = "";//委托书  
                string cckDeath = "";//死亡证明
                string cckKindred = "";//近亲属关系证明
                string copyContert = "";
                if (checkDelegate.Checked == true)
                    cckdelegate = "Y";
                else
                    cckdelegate = "N";
                if (checkDeath.Checked == true)
                    cckDeath = "Y";
                else
                    cckDeath = "N";
                if (checkKindred.Checked == true)
                    cckKindred = "Y";
                else
                    cckKindred = "N";

                

                if (chkFYNR.Items.Count > 0 && chkFYNR.CheckedItems.Count == 0)
                {
                    App.Msg("提示:[复印内容]未选择!");
                    return;
                }
                for (int i = 0; i < chkFYNR.CheckedItems.Count; i++)
                {

                    DataRowView temp = (DataRowView)chkFYNR.CheckedItems[i];
                    if (copyContert == "")
                    {
                        copyContert = temp["name"].ToString();
                    }
                    else
                    {
                        copyContert += "," + temp["name"].ToString();
                    }

                }
                
                T_CASE_COPY_RECORD case_copy = new T_CASE_COPY_RECORD();
                if (isSaveOrUpdate)
                {
                    if (applyName == "")
                    {
                        App.Msg("申请人还没填写");
                        this.txtApplyName.Focus();
                        return;
                    }
                    if (caseName == "")
                    {
                        App.Msg("病历号还没填写");
                        this.txtCaseName.Focus();
                        return;
                    }
                    if (iDCard == "")
                    {
                        App.Msg("身份证号还没填写");
                        this.txtIDCard.Focus();
                        return;
                    }
                    if (workCard == "")
                    {
                        App.Msg("工作证号还没填写");
                        this.txtWorkCard.Focus();
                        return;
                    }
                    case_copy.APPLY_UNIT = applyUnit;//申请单位
                    case_copy.APPLY_PERSON = applyName;//申请人姓名
                    case_copy.COPY_TIME = applyTime;//复印时间
                    case_copy.CASE_ID = caseName;//病历号
                    case_copy.DEGREE_NUMBER = iDCard;//身份证
                    case_copy.JOB_NUMBER = workCard;//工作证
                    case_copy.TRUST_DEED = cckdelegate;//委托书
                    case_copy.DEAD_ARGUE = cckDeath;//死亡证明
                    case_copy.NEAR_RELATIVE_ARGUE = cckKindred;//近亲属关系

                    case_copy.COPY_VALUE = copyContert;
                    ID = App.GenId("T_CASE_COPY_RECORD", "ID").ToString();
                    string insertsql = "insert into T_CASE_COPY_RECORD(ID,COPY_TIME,APPLY_UNIT,APPLY_PERSON,CASE_ID,DEGREE_NUMBER,JOB_NUMBER,TRUST_DEED,DEAD_ARGUE,NEAR_RELATIVE_ARGUE,COPY_VALUE,RECORD_TIME)" +
                        " values('" + ID + "',to_TIMESTAMP('" + case_copy.COPY_TIME + "','yyyy-MM-dd hh24:mi'),'" + case_copy.APPLY_UNIT + "','" + case_copy.APPLY_PERSON +
                        "','" + case_copy.CASE_ID + "','" + case_copy.DEGREE_NUMBER + "','" + case_copy.JOB_NUMBER + "','" + case_copy.TRUST_DEED + "','" + case_copy.DEAD_ARGUE +
                        "','" + case_copy.NEAR_RELATIVE_ARGUE + "','" + case_copy.COPY_VALUE + "',sysdate)";
                    if (App.ExecuteSQL(insertsql) > 0)
                        App.Msg("添加成功");
                    CoseCopyRegister_Load(sender, e);
                    SetEnabled();
                    //btnQuery_Click(sender, e);
                }
                else
                {
                    string updatesql = "UPDATE T_CASE_COPY_RECORD set COPY_TIME=to_TIMESTAMP('" + applyTime + "' ,'yyyy-MM-dd hh24:mi')" +
                        ",APPLY_UNIT='" + applyUnit + "',APPLY_PERSON='" + applyName + "',CASE_ID='" + caseName + "'" +
                        ", DEGREE_NUMBER='" + iDCard + "', JOB_NUMBER='" + workCard + "',TRUST_DEED='" + cckdelegate + "'" +
                        ",DEAD_ARGUE='" + cckDeath + "', NEAR_RELATIVE_ARGUE='" + cckKindred + "'" +
                        ", COPY_VALUE='" + copyContert + "',RECORD_TIME=sysdate " + //to_TIMESTAMP('" + App.GetSystemTime().ToString("yyyy-MM-dd") + "' ,'yyyy-MM-dd hh24:mi')" +
                        " where ID='" + ID + "'";
                    try
                    {
                        if (App.ExecuteSQL(updatesql) > 0)
                            App.Msg("修改成功");
                        CoseCopyRegister_Load(sender, e);
                        SetEnabled();
                    }
                    catch (Exception ee)
                    {
                        App.MsgErr(ee.Message);
                    }
                    //btnQuery_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("错误信息：" + ex.Message);
            }
        }

        /// <summary>
        /// 设置匹配选中复选框
        /// </summary>
        /// <param name="val"></param>
        /// <param name="chkval"></param>
        /// <returns></returns>
        private bool SetCheckbox(string val, string chkval)
        {
            bool flag = false;
            try
            {

                for (int i = 0; i < val.Split(',').Length; i++)
                {
                    if (val.Split(',')[i].ToString().Trim() == chkval.Trim())
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            catch
            {
                return flag;
            }
        }
        /// <summary>
        /// 单击用户控件时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {

            if (ucC1FlexGrid1.fg.RowSel >= 0)
            {
                
                ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "复印时间"].ToString());
                cbbapplyunit.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请单位"].ToString();
                txtApplyName.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "申请人"].ToString();
                txtCaseName.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "病历号"].ToString();
                txtIDCard.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "身份证"].ToString();
                txtWorkCard.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "工作证号"].ToString();

                
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "复印内容"].ToString().Trim() != "")//并发症情况（从数据字典中取相关的代码）
                {
                    foreach (int i in chkFYNR.CheckedIndices)
                    {
                        chkFYNR.SetItemChecked(i, false);
                    }
                    string[] vals = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "复印内容"].ToString().Split(',');
                    for (int i1 = 0; i1 < vals.Length; i1++)
                    {
                        for (int j = 0; j < chkFYNR.Items.Count; j++)
                        {
                            DataRowView temp = (DataRowView)chkFYNR.Items[j];
                            if (temp["name"].ToString() == vals[i1])
                            {
                                chkFYNR.SetItemChecked(j, true);
                            }
                        }
                    }

                }

                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "委托书"].ToString() == "Y")
                {
                    checkDelegate.Checked = true;
                }
                else
                {
                    checkDelegate.Checked = false;
                }
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "死亡证明"].ToString() == "Y")
                {
                    checkDeath.Checked = true;
                }
                else
                {
                    checkDeath.Checked = false;
                }
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "近亲属关系证明"].ToString() == "Y")
                {
                    checkKindred.Checked = true;
                }
                else
                {
                    checkKindred.Checked = false;
                }
            }

        }

        /// <summary>
        /// 设置添加和确定了之后各控件的可编辑情况。
        /// </summary>
        private void SetEnabled()
        {
            #region
            this.cbbapplyunit.Enabled = false;
            this.txtApplyName.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.txtCaseName.Enabled = false;
            this.txtIDCard.Enabled = false;
            this.txtWorkCard.Enabled = false;
            this.checkDelegate.Enabled = false;
            this.checkDeath.Enabled = false;
            this.checkKindred.Enabled = false;
            this.chkFYNR.Enabled = false;
            foreach (int i in chkFYNR.CheckedIndices)
            {
                chkFYNR.SetItemChecked(i, false);
            }
            this.btnConfirm.Enabled = false;
            this.btncancel.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnDalete.Enabled = true;
            this.btnUpdate.Enabled = true;
            #endregion
        }
        /// <summary>
        /// 点击修改按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region
            this.ucC1FlexGrid1.Enabled = true;
            this.cbbapplyunit.Enabled = true;
            this.txtApplyName.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.txtCaseName.Enabled = true;
            this.txtIDCard.Enabled = true;
            this.txtWorkCard.Enabled = true;
            this.checkDelegate.Enabled = true;
            this.checkDeath.Enabled = true;
            this.checkKindred.Enabled = true;
            this.chkFYNR.Enabled = true;
            isSaveOrUpdate = false;
            this.btnConfirm.Enabled = true;
            this.btnDalete.Enabled = false;
            this.btncancel.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnUpdate.Enabled = false;
            #endregion
        }
        /// <summary>
        /// 点击删除按钮时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDalete_Click(object sender, EventArgs e)
        {
            string deleteSQL = "DELETE T_CASE_COPY_RECORD where ID='" + ID + "'";
            try
            {
                if (App.Ask("您确定要删除吗"))
                {
                    if (App.ExecuteSQL(deleteSQL) > 0)
                    {
                        App.Msg("删除成功");
                        CoseCopyRegister_Load(sender, e);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("错误信息：" + ex.Message);
            }
            this.btnConfirm.Enabled = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds == null || ds.Tables[0].Rows.Count <= 0)
                {
                    App.Msg("没有数据可打印，请确认");
                    return;
                }
                saveFileDialog1.FileName = "病历复印记录.xls";
                saveFileDialog1.Filter = "Excel工作簿(*.xls)|*.xls";
                saveFileDialog1.ShowDialog();
                //FrmPrint frmprint = new FrmPrint(ds.Tables[0]);
                //frmprint.ShowDialog();
            }
            catch (Exception ee)
            {
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            //ucC1FlexGrid1.fg.SaveExcel(pathname);
            ucC1FlexGrid1.fg.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
                             
        }

    }
}
