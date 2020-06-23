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
    public partial class ucMinim : UserControl
    {
        bool isSave = false;              //用于存放当前的操作状态 true为添加操作 false为修改操作
        private string ID = "";           //出入液量ID
        private string Inout_amount_dict; //出入液量信息查询
        private string item_code;         //当前选中的项目编号
        private string item_name;         //当前选中的项目名称
        private string display_seq;       //当前选中的显示顺序
        DataSet ds;
        public ucMinim()
        {
            InitializeComponent();
            Inout_amount_dict = @"select a.ID as 编号,ITEM_CODE as 项目编号,ITEM_NAME as 项目名称,ITEM_VALUE_TYPE as 项目类型编号,s.name as 项目值类型,ITEM_UNIT as 项目单位,DISPLAY_SEQ as 显示顺序," +
                                @"(case when AMOUNT_FLAG=0 then '汇总' else '不汇总' end) as 汇总标记," +
                                @"ITEM_TYPE as 项目分类编号,b.name as 项目分类名称,ITEM_MODE as 项目方式编号,d.name as 项目方式名称," +
                                @"(case when DRAINAGE_ATTRIBUTE=0 then '是' else '否' end) as 引流属性 from T_INOUT_AMOUNT_DICT a inner join T_DATA_CODE b on b.id=a.item_type inner join T_DATA_CODE s on a.item_value_type=s.id left join T_DATA_CODE d on a.ITEM_MODE=d.id";
       }

        private void frmMinim_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("出入液量信息");
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            Type();
            Item_Type();
            cboItem.SelectedIndex = 0;
            cboCollect.SelectedIndex = 0;
            RefleshFrm();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["项目类型编号"].Visible = false;
                ucGridviewX1.fg.Columns["项目类型编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["项目分类编号"].Visible = false;
                ucGridviewX1.fg.Columns["项目分类编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["项目方式编号"].Visible = false;
                ucGridviewX1.fg.Columns["项目方式编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        //显示列表数据
        private void ShowValue()
        {
            string SQl = Inout_amount_dict + " order by a.ID desc";
            ds = App.GetDataSet(SQl);
            if (ds != null)
            {
                ucGridviewX1.DataBd(SQl, "编号", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["项目类型编号"].Visible = false;
                ucGridviewX1.fg.Columns["项目类型编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["项目分类编号"].Visible = false;
                ucGridviewX1.fg.Columns["项目分类编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["项目方式编号"].Visible = false;
                ucGridviewX1.fg.Columns["项目方式编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }

         

        }
        /// <summary>
        /// 绑定项目护理值类型
        /// </summary>
        private void Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='21'");
            cboType.DataSource = ds.Tables[0].DefaultView;
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "NAME";
        }
        /// <summary>
        /// 绑定项目分类
        /// </summary>
        private void Item_Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='25'");
            cboItem_type.DataSource = ds.Tables[0].DefaultView;
            cboItem_type.ValueMember = "ID";
            cboItem_type.DisplayMember = "NAME";
        }
        /// <summary>
        /// 绑定项目方式
        /// </summary>
        private void ItemMode()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='26'");
            cboMode.DataSource = ds.Tables[0].DefaultView;
            cboMode.ValueMember = "ID";
            cboMode.DisplayMember = "NAME";
        }
 
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {
 
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboType.Enabled = false;
            txtUnit.Enabled = false;
            txtSequence.Enabled = false;
            cboCollect.Enabled = false;
            cboItem_type.Enabled = false;
            cboMode.Enabled = false;
            cboItem.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
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

                txtNumber.Text = "";
                txtName.Text = "";
                cboType.Text = "";
                txtUnit.Text = "";
                txtSequence.Text = "";
            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            cboType.Enabled = true;
            txtUnit.Enabled = true;
            txtSequence.Enabled = true;
            cboCollect.Enabled = true;
            cboItem_type.Enabled = true;
            cboMode.Enabled = true;
            cboItem.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (cboItem_type.Text.ToString() == "入液量")
            {

                cboMode.Enabled = true;
                cboItem.Enabled = false;
                ItemMode();
                cboItem.SelectedIndex = 1;
            }
            else if (cboItem_type.Text.ToString() == "出液量")
            {

                cboMode.Enabled = false;
                cboItem.Enabled = true;
            }
            txtNumber.Focus();
        }

        /// <summary>
        /// 判断是否出现重名ID
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitID(string id)
        {

            DataSet ds = App.GetDataSet("select * from T_INOUT_AMOUNT_DICT where  ITEM_CODE='" + id + "'");
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
        /// 判断是否出现重名NAME
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string Name)
        {
            DataSet ds = App.GetDataSet("select * from T_INOUT_AMOUNT_DICT where ITEM_NAME='" + Name + "'");
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
        /// 判断是否出现重名显示顺序
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitIndex(string index)
        {
            DataSet ds = App.GetDataSet("select * from T_INOUT_AMOUNT_DICT where DISPLAY_SEQ='" + index + "'");
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
        }
        //验证数据如果是0的就显示为空
        public string Valite(string str)
        {
            if (str == "0")
            {
                str = "";
            }
            return str;
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
                    App.Msg("项目编号不能为空！");
                    txtNumber.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("项目名称不能为空！");
                    txtName.Focus();
                    return;
                }
                if (txtUnit.Text.Trim() == "")
                {
                    App.Msg("项目单位不能为空");
                    txtUnit.Focus();
                    return;
                }
                if (cboCollect.Text.Trim() == "")
                {
                    App.Msg("汇总标记不能为空！");
                    cboCollect.Focus();
                    return;
                }
                int a;
                if (txtSequence.Text.Trim() != "")
                {
                    if (!int.TryParse(txtSequence.Text.Trim(), out a))
                    {
                        App.Msg("显示顺序只能填写整数");
                        txtSequence.Focus();
                        return;
                    }
                }
                string sql = "";
                string bid = "0";
                if (cboItem_type.SelectedIndex.ToString() == "出液量")
                {
                   bid =cboMode.SelectedValue.ToString();

                }
                ID = App.GenId("T_INOUT_AMOUNT_DICT ", "ID").ToString();
                if (isSave)
                {
                    if (isExisitID(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("已经存在了相同名称的项目编号了！");
                        txtNumber.Focus();
                        return;
                    }
                    else if (isExisitName(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("已经存在了相同名称的项目名称了！");
                        txtName.Focus();
                        return;
                    }
                    else if (isExisitIndex(App.ToDBC(txtSequence.Text.Trim())))
                    {
                        App.Msg("已经存在了相同名称的显示顺序了！");
                        txtSequence.Focus();
                        return;
                    }
                
                    sql = "insert into T_INOUT_AMOUNT_DICT(ID,ITEM_CODE,ITEM_NAME,ITEM_VALUE_TYPE,ITEM_UNIT,DISPLAY_SEQ,AMOUNT_FLAG,ITEM_TYPE,ITEM_MODE,DRAINAGE_ATTRIBUTE) values('"
                         + ID + "','"
                         + App.ToDBC(txtNumber.Text) + "','"
                         + App.ToDBC(txtName.Text) + "','"
                         + cboType.SelectedValue + "','"
                         +txtUnit.Text + "','"
                         + txtSequence.Text + "','"
                         + cboCollect.SelectedIndex.ToString() + "','"
                         + cboItem_type.SelectedValue + "',"
                         +bid + ",'"
                         +cboItem.SelectedIndex.ToString()+"')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (item_code.Trim() != "")
                    {
                        if (txtNumber.Text.Trim() != item_code.Trim())
                        {
                             if (isExisitID(App.ToDBC(txtNumber.Text.Trim())))
                                {
                                    App.Msg("已经存在了相同名称的项目编号了！");
                                    txtNumber.Focus();
                                    return;
                                }
                        }
                    }
                    else if (item_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != item_name.Trim())
                        {
                             if (isExisitName(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("已经存在了相同名称的项目名称了！");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    else if (display_seq.Trim() != "")
                    {
                        if (txtSequence.Text.Trim() != display_seq.Trim())
                        {
                            if (isExisitIndex(App.ToDBC(txtSequence.Text.Trim())))
                            {
                                App.Msg("已经存在了相同名称的显示顺序了！");
                                txtSequence.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_INOUT_AMOUNT_DICT set ITEM_CODE='"
                              + App.ToDBC(txtNumber.Text) + "',ITEM_NAME='"
                              + App.ToDBC(txtName.Text) + "',ITEM_VALUE_TYPE='"
                              + cboType.SelectedValue + "',ITEM_UNIT='"
                              + txtUnit.Text + "',DISPLAY_SEQ='"
                              + txtSequence.Text + "',AMOUNT_FLAG='"
                              + cboCollect.SelectedIndex.ToString() + "',ITEM_TYPE='"
                              + cboItem_type.SelectedValue + "',ITEM_MODE="
                              +bid + ",DRAINAGE_ATTRIBUTE='"
                              + cboItem.SelectedIndex.ToString() + "' where ID='" + ucGridviewX1.fg["编号", ucGridviewX1.fg.Rows.Count].Value.ToString() + "'";

                }
                
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        btnCancel_Click(sender, e);
                    }
                //显示列表数据
                ShowValue();
                //string SQl = Inout_amount_dict;
               // ucC1FlexGrid1.DataBd(SQl, "ID", "ID,ITEM_CODE,ITEM_NAME,ITEM_VALUE_TYPE,VALUE_TYPE,ITEM_UNIT,DISPLAY_SEQ,AMOUNT_FLAG,ITEM_TYPE,ITEM_TYPE_NAME,ITEM_MODE,ITEM_MODE_NAME,DRAINAGE_ATTRIBUTE", "编号,项目编号,项目名称,项目值编号,项目值类型,项目单位,显示顺序,汇总标记,项目分类编号,项目分类名称,项目方式编号,项目方式名称,引流属性");
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

        private void cboItem_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboItem_type.Text.ToString() == "入液量")
            {
               
                cboMode.Enabled = true;
                cboItem.Enabled = false;
                ItemMode();
                cboItem.SelectedIndex = 1;
            }
            else if (cboItem_type.Text.ToString() == "出液量")
            {

                cboMode.Enabled = false;
                cboItem.Enabled = true;
            }
           
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }
             /// <summary>
        /// 刷新表格
        /// </summary>
        private void refurbish()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            cboType.Text = "";
            txtUnit.Text = "";
            txtSequence.Text = "";
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboType.Enabled = false;
            txtUnit.Enabled = false;
            txtSequence.Enabled = false;
            cboCollect.Enabled = false;
            cboItem_type.Enabled = false;
            cboMode.Enabled = false;
            cboItem.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            //groupBox1.Enabled = true;
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (App.Ask("你是否要删除"))
            {
                App.ExecuteSQL("delete  from T_INOUT_AMOUNT_DICT where  ID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            //显示列表数据
            ShowValue();
            refurbish();
            
        }
        int Rowcount = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    ID = ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["项目编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    item_code = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["项目名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    item_name = txtName.Text;
                    cboType.Text = ucGridviewX1.fg["项目类型编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtUnit.Text = ucGridviewX1.fg["项目单位", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtSequence.Text = ucGridviewX1.fg["显示顺序", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    display_seq = txtSequence.Text;
                    if (ucGridviewX1.fg["汇总标记", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "汇总")
                    {
                        cboCollect.SelectedIndex = 0;
                    }
                    else
                    {
                        cboCollect.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["项目分类编号", ucGridviewX1.fg.CurrentRow.Index].Value != "")
                    {
                        cboItem_type.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["项目分类编号", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["项目方式编号", ucGridviewX1.fg.CurrentRow.Index].Value != "")
                    {
                        cboMode.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["项目方式编号", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["引流属性", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "是")
                    {
                        cboCollect.SelectedIndex = 0;
                    }
                    else
                    {
                        cboCollect.SelectedIndex = 1;
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
                RefleshFrm();
            }
            catch
            {
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnLookup_Click(object sender, EventArgs e)
        {
            try
            {
                btnLookup.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                string SQl = Inout_amount_dict + " order by a.ID desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtBox.Focus();
                    return;
                }
                //按项目编号进行查询
                if (chkID.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inout_amount_dict + " where  ITEM_CODE 　like'%" + txtBox.Text.Trim() + "%' order by a.ID desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                 //按项目名称进行查询
                else if (chkName.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inout_amount_dict + " where   ITEM_NAME　like'%" + txtBox.Text.Trim() + "%' order by a.ID desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                ucGridviewX1.DataBd(SQl, "编号", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["项目类型编号"].Visible = false;
                ucGridviewX1.fg.Columns["项目类型编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["项目分类编号"].Visible = false;
                ucGridviewX1.fg.Columns["项目分类编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["项目方式编号"].Visible = false;
                ucGridviewX1.fg.Columns["项目方式编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnLookup.Enabled = true;
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
                cboType.Focus();
            }

        }

        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnit.Focus();
            }

        }


        private void txtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSequence.Focus();
            }

        }

        private void txtSequence_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCollect.Focus();
            }

        }

        private void cboCollect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboItem_type.Focus();
            }

        }
        private void cboItem_type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboMode.Focus();
            }

        }
        private void cboMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboItem.Focus();
            }

        }
        private void cboItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void chkID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkID.Checked == true)
            {
                chkName.Checked = false;
            }
            else
            {
                chkName.Checked = true;
                txtBox.Text = "";
            }
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked == true)
            {
                chkID.Checked = false;
            }
            else
            {
                chkID.Checked = true;
                txtBox.Text = "";
            }
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }
   






   


    }
}