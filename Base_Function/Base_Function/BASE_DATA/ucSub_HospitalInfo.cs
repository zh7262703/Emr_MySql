using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;

namespace Base_Function.BASE_DATA
{
    public partial class ucSub_HospitalInfo : UserControl
    {
        bool isSave = false;               //用于存放当前的操作状态 true为添加操作 false为修改操作
        private string ID = "";            //分院ID
        private string Sub_Hospital;       //分院查询
        private string sub_hospital_code; //当前选中的分院编号
        private string sub_hospital_name; //当前选中的分院名称
        DataSet ds;
        public ucSub_HospitalInfo()
        {
            InitializeComponent();
            Sub_Hospital = "select SHID as 编号,SUB_HOSPITAL_CODE as 分院编号,SUB_HOSPITAL_NAME as 分院名称 from T_SUB_HOSPITALINFO";
        }

 
        private void frmSub_HospitalInfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("分院信息");
            //显示列表数据
            ShowValue();
           // ucC1FlexGrid1.DataBd(SQL, "SHID", "SHID,SUB_HOSPITAL_CODE,SUB_HOSPITAL_NAME", "编号,分院代码,分院名称");
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            RefleshFrm();
        }
        private void ShowValue()
        {
            string SQL = Sub_Hospital + " order by SHID desc";
            ds = App.GetDataSet(SQL);
            if (ds != null)
            {

                //   ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                ucGridviewX1.DataBd(SQL, "编号", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }

        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {
            txtName.Enabled = false;
            txtNumber.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel1.Enabled = true;
            isSave = false;

        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtName.Text = "";
                txtNumber.Text = "";
            }
            txtName.Enabled = true;
            txtNumber.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel1.Enabled = false;
            txtNumber.Focus();
        }
        /// <summary>
        /// 表格刷新
        /// </summary>
        private void refurbish()
        {
            txtName.Text = "";
            txtNumber.Text = "";
            txtName.Enabled = false;
            txtNumber.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            //groupBox2.Enabled = true;
            groupPanel1.Enabled = true;
            isSave = false;
        }
        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_SUB_HOSPITALINFO where SUB_HOSPITAL_CODE='" + id + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_SUB_HOSPITALINFO where SUB_HOSPITAL_NAME='" + name + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            Edit(isSave);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            Edit(isSave);
            txtNumber.Enabled = false;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumber.Text.Trim() == "")
                {
                    App.Msg("代码编号不能为空！");
                    txtNumber.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("分院名称不能为空！");
                    txtName.Focus();
                    return;
                }
                string sql = "";
                ID = App.GenId("T_SUB_HOSPITALINFO", "SHID").ToString();
                if (isSave)
                {
                    if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("已经存在了相同的分院编号了！");
                        txtName.Focus();
                        return;
                    }
                    else if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("已经存在了相同的分院名称了！");
                        txtName.Focus();
                        return;
                    }
               
                    sql = "insert into T_SUB_HOSPITALINFO(SHID,SUB_HOSPITAL_CODE,SUB_HOSPITAL_NAME) values("
                           + ID + ",'" + txtNumber.Text + "','" +txtName.Text +"') ";
                    btnAdd_Click(sender, e);
                }
                else
                {
                    if (sub_hospital_code.Trim() != "")
                    {
                        if (txtNumber.Text.Trim() != sub_hospital_code.Trim())
                        {
                             if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("已经存在了相同的分院编号了！");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    else if(sub_hospital_name.Trim()!="")
                    {
                        if (txtName.Text.Trim() != sub_hospital_name.Trim())
                        {
                           if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("已经存在了相同的分院名称了！");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_SUB_HOSPITALINFO set SUB_HOSPITAL_CODE='"
                          + txtNumber.Text + "',SUB_HOSPITAL_NAME='"
                          + App.ToDBC(txtName.Text) + "' where SHID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";
                    btnUpdate_Click(sender, e);
                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        btnCancel_Click(sender, e);
                    }
                //显示列表数据
                ShowValue();
               
            }
            catch (Exception ex)
            {
                App.Msg("添加失败，原因：" + ex.ToString() + "");
            }
        }

         /// <summary>
         /// 取消
         /// </summary>
         /// <param Name="sender"></param>
         /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //RefleshFrm();
            refurbish();
        }
        int Rowcount = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count>0)
                {
                    ID = ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["分院编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    sub_hospital_code = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["分院名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    sub_hospital_name = txtName.Text;
                    //int rows = this.ucGridviewX1.fg.RowSel;//定义选中的行号 
                    //if (rows > 0)
                    //{
                    //    if (Rowcount == rows)
                    //    {
                    //        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //    }
                    //    else
                    //    {
                    //        //如果不是头行
                    //        if (rows > 0)
                    //        {
                    //            //就改变背景色
                    //            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //        }
                    //        if (Rowcount > 0 && ds.Tables[0].Rows.Count >= Rowcount)
                    //        {
                    //            //定义上一次点击过的行还原
                    //            this.ucC1FlexGrid1.fg.Rows[Rowcount].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    //        }
                    //    }
                    //}
                    ////给上一次的行号赋值
                    //Rowcount = rows;
                }
            }
            catch
            {
            }
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }
  
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }


  
    }
}