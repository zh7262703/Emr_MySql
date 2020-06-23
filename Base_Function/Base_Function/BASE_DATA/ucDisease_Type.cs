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
    public partial class ucDisease_Type : UserControl
    {
       private bool IsSave = false;　//用于存放当前的操作状态 true为添加操作 false为修改操作
       private string ID = "";    //获取当前的ID
        private string T_sick_type_sql;
        private string t_sick_code;
        private string t_sick_name;
        public ucDisease_Type()
        {
            InitializeComponent();
            T_sick_type_sql = "select s.ID as 编号,SICK_CODE as 代码,SICK_NAME as 名称,SICK_SYSTEM as 所属病种目录编号,t.name as 所属病种目录 from T_SICK_TYPE s " +
                             @"inner join t_data_code t on t.id=s.sick_system ";
        }

        private void frmDisease_Type_Load(object sender, EventArgs e)
        {
            //显示列表数据
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = true;
            //绑定病种所属目录
            Property();
            RefleshFrm();

        }
        private void frmDisease_Type_Activated(object sender, EventArgs e)
        {
            Property();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        DataSet ds;
        //显示列表数据
        private void ShowValue()
        {
            string Sql = T_sick_type_sql + "  order by s.ID desc";
            ds = App.GetDataSet(Sql);
            if (ds != null)
            {
                ucGridviewX1.DataBd(Sql, "编号", false, "", "");

                //ucC1FlexGrid1.fg.Cols["编号"].Visible = false;
                //ucC1FlexGrid1.fg.Cols["编号"].AllowEditing = false;
                ucGridviewX1.fg.ReadOnly = true;
            }
        }
        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool IsCode(string code)
        {
            DataSet ds = App.GetDataSet("select * from t_sick_type  where sick_system='"+cboDisease_type.SelectedValue+"' and  sick_code='"+code+"'");
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
        private bool Isnames(string name)
        {
            DataSet ds = App.GetDataSet("select * from t_sick_type  where sick_system='"+cboDisease_type.SelectedValue+"' and  sick_name='"+name+"'");
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
        //绑定病种所属目录
        private void Property()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='16' order by ID asc");
            cboDisease_type.DataSource = ds.Tables[0].DefaultView;
            cboDisease_type.ValueMember = "ID";
            cboDisease_type.DisplayMember = "NAME";
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {

            cboDisease_type.Enabled = false;
            txtCode.Enabled = false;
            txtName.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            IsSave = false;

        }
        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtCode.Text = "";
                txtName.Text = "";
            }

            cboDisease_type.Enabled = true;
            txtCode.Enabled = true;
            txtName.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;

            txtCode.Focus();
        }
        /// 刷新表格
        /// </summary>
        private void refurbish()
        {
            txtCode.Text = "";
            txtName.Text = "";
            cboDisease_type.Enabled = false;
            txtCode.Enabled = false;
            txtName.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            //groupBox1.Enabled = true;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsSave = true;
            Edit(IsSave);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsSave = false;
            Edit(IsSave);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Trim()=="")
                {
                    App.Msg("代码必须填写！");
                    txtCode.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("病种名称必须填写！");
                    txtName.Focus();
                    return;
                }
                string sql = "";
                if (IsSave)
                {
                    if (IsCode(App.ToDBC(txtCode.Text.Trim())))
                    {
                        App.Msg("已经存在了相同的代码了！");
                        txtCode.Focus();
                        return;
                    }
                    else if (Isnames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("已经存在了相同的病种名称了！");
                        txtName.Focus();
                        return;
                    }
                    sql = "insert into t_sick_type(SICK_CODE,SICK_NAME,SICK_SYSTEM) values('" + txtCode.Text + "','" + txtName.Text + "','" + cboDisease_type.SelectedValue + "')";
                }
                else
                {
                    if (t_sick_code.Trim() != "")
                    {
                        if (txtCode.Text.Trim() != t_sick_code.Trim())
                        {
                            if (IsCode(App.ToDBC(txtCode.Text.Trim())))
                            {
                                App.Msg("已经存在了相同的科室编号了！");
                                txtCode.Focus();
                                return;
                            }
                        }
                    }
                    else if (t_sick_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != t_sick_name.Trim())
                        {
                            if (Isnames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("已经存在了相同的科室名称了！");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update  t_sick_type set SICK_CODE='" + txtCode.Text + "',SICK_NAME='" + txtName.Text + "',SICK_SYSTEM='" + cboDisease_type.SelectedValue + "' where ID='" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
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
            catch
            {
            }
        }
        int Rowcount = 0;
        /// <summary>
        /// 单击表格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    ID = ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtCode.Text = ucGridviewX1.fg["代码", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    t_sick_code = txtCode.Text;
                    txtName.Text = ucGridviewX1.fg["名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    t_sick_name = txtName.Text;
                    if (ucGridviewX1.fg["所属病种目录编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboDisease_type.SelectedValue = ucGridviewX1.fg["所属病种目录编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    }

                    //int rows = this.ucC1FlexGrid1.fg.RowSel;//定义选中的行号 
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
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            refurbish();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (App.Ask("你是否要删除"))
            {
                App.ExecuteSQL("delete from t_sick_type where  ID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            //显示列表数据
            ShowValue();
            refurbish();
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelect.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtBox.Focus();
                    return;
                }
                string Sql = T_sick_type_sql + " order by s.ID desc";
                if (txtBox.Text.Trim() != "")
                {


                    Sql = T_sick_type_sql + " where  SICK_NAME　like'%" + txtBox.Text.Trim() + "%' order by s.ID desc";

                }
                ucGridviewX1.DataBd(Sql, "编号", false, "", "");
                ucGridviewX1.fg.ReadOnly = true;
                ucGridviewX1.fg.AutoResizeColumns();
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnSelect.Enabled = true;
            }
        }

        private void cboDisease_type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCode.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
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
                btnSave_Click(sender,e);
            }
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }


 
   

  

   

     

    
    }
}