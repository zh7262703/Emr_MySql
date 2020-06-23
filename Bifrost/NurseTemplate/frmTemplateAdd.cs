using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Bifrost.NurseTemplate
{
    public partial class frmTemplateAdd : DevComponents.DotNetBar.Office2007Form
    {
        private string T_Content = ""; //模板内容
        private string Sql = "";//增加sql语句
        private string Sql2 = "";//修改sql语句
        private string Sql3 = "";//删除sql语句
        private int tid = -1;

        private enum operate
        {
            add,
            update,
            //delete,
            nothing
        }

        private operate oper = operate.nothing;

        /// <summary>
        /// 查询个人模板
        /// </summary>
        private string SqlPerson = "select id 编号 ,temp_name 模板名称,temp_content 内容,case when temp_type='p' then '个人' when temp_type='s' then '病区' when temp_type='h' then '全院' end 类型,b.user_name  创建人,c.sick_area_name 病区 from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='p' and create_id=" + App.UserAccount.UserInfo.User_id + "";

        /// <summary>
        /// 查询病区模板
        /// </summary>
        private string SqlSaid = "select id 编号 ,temp_name 模板名称,temp_content 内容,case when temp_type='p' then '个人' when temp_type='s' then '病区' when temp_type='h' then '全院' end 类型,b.user_name  创建人,c.sick_area_name 病区 from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='s' and a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "";

        /// <summary>
        /// 查询全院模板
        /// </summary>
        private string Sqlhospital = "select id 编号 ,temp_name 模板名称,temp_content 内容,case when temp_type='p' then '个人' when temp_type='s' then '病区' when temp_type='h' then '全院' end 类型,b.user_name  创建人,c.sick_area_name 病区 from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='h'";

        public frmTemplateAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="template_content">模板的内容</param>
        public frmTemplateAdd(string template_content)
        {
            InitializeComponent();
            T_Content = template_content;
        }

        private void frmTemplateAdd_Load(object sender, EventArgs e)
        {
            ucGridviewX1.fg.ReadOnly = true;
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.Click += new EventHandler(ClickGrid);
            cboType.SelectedIndex = 0;
            cboCondiction.SelectedIndex = 0;
            txtModelContent.Text = T_Content;
            oper = operate.add;

            ShowAllModel();
            buttonchange();
            buttonchange1();
        }

        public void ClickGrid(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.SelectedRows.Count != 0)
            {
                txtModelContent.Text = ucGridviewX1.fg.SelectedRows[0].Cells["内容"].Value == null ? "" : ucGridviewX1.fg.SelectedRows[0].Cells["内容"].Value.ToString();
                txtModelID.Text = ucGridviewX1.fg.SelectedRows[0].Cells["编号"].Value == null ? "" : ucGridviewX1.fg.SelectedRows[0].Cells["编号"].Value.ToString();
                txtModelTitle.Text = ucGridviewX1.fg.SelectedRows[0].Cells["模板名称"].Value == null ? "" : ucGridviewX1.fg.SelectedRows[0].Cells["模板名称"].Value.ToString();
                cboType.Text = ucGridviewX1.fg.SelectedRows[0].Cells["类型"].Value == null ? "" : ucGridviewX1.fg.SelectedRows[0].Cells["类型"].Value.ToString();
            }
            buttonexchange();
            buttonexchange1();
        }

        /// <summary>
        /// 按条件查询
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            /*
             * 按条件查询，先判断是按什么条件查询，如果按类型，直接显示出当前类型的数据
             * 如果是按模板内容/名称，那就是根据输入的内容/名称实施模糊查询
             */
            string SqlQuery = "";
            txtTemplateName.ReadOnly = false;

            if (cboCondiction.SelectedItem == null||cboCondiction.SelectedItem.ToString().Contains("请选择"))
            {
                SqlQuery = SqlPerson + " union " + SqlSaid + " union " + Sqlhospital;
            }

            else if (cboCondiction.SelectedItem.ToString() == "无")
            {

                if (txtTemplateName.Text == "")
                {
                    SqlQuery = SqlPerson + " union " + SqlSaid + " union " + Sqlhospital;
                }
                else
                {
                    SqlQuery = SqlPerson + " and temp_name like '%" + txtTemplateName.Text + "%'" + " union " + SqlSaid + " and temp_name like '%" + txtTemplateName.Text + "%'" + " union " + Sqlhospital + " and temp_name like '%" + txtTemplateName.Text + "%'";
                }
            }
            else if (cboCondiction.SelectedItem.ToString() == "按模板名称查询")
            {
                SqlQuery = SqlPerson + " and temp_name like '%" + txtTemplateName.Text + "%'" + " union " + SqlSaid + " and temp_name like '%" + txtTemplateName.Text + "%'" + " union " + Sqlhospital + " and temp_name like '%" + txtTemplateName.Text + "%'";
            }
            else if (cboCondiction.SelectedItem.ToString() == "个人模板查询")
            {
                SqlQuery = SqlPerson;
                if (txtTemplateName.Text != "")
                {
                    SqlQuery += " and temp_name like '%" + txtTemplateName.Text + "%'";
                }
            }
            else if (cboCondiction.SelectedItem.ToString() == "病区模板查询")
            {
                SqlQuery = SqlSaid;
                if (txtTemplateName.Text != "")
                {
                    SqlQuery += " and temp_name like '%" + txtTemplateName.Text + "%'";
                }
            }
            else if (cboCondiction.SelectedItem.ToString() == "全院模板查询")
            {
                SqlQuery = Sqlhospital;
                if (txtTemplateName.Text != "")
                {
                    SqlQuery += " and temp_name like '%" + txtTemplateName.Text + "%'";
                }
            }
            else if (cboCondiction.SelectedItem.ToString() == "按模板内容查询")
            {
                SqlQuery = SqlPerson + " and temp_content like '%" + txtTemplateName.Text + "%'" + " union " + SqlSaid + "and temp_content like '%" + txtTemplateName.Text + "%'" + " union " + Sqlhospital + " and temp_content like '%" + txtTemplateName.Text + "%'";
            }
            ucGridviewX1.DataBd(SqlQuery, "编号", "", "");


            /*string sql = "select id 编号 ,temp_name 模板名称,temp_content 内容,case when temp_type='p' then '个人' when temp_type='s' then '病区' when temp_type='h' then '全院' end 类型,b.user_name  创建人,c.sick_area_name 病区 from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where 1=1";

            if (txtTemplateName.Text != "")
            {
                sql += " and temp_name like '%" + txtTemplateName.Text + "%'";
            }
            ucGridviewX1.DataBd(sql, "编号", "", "");*/
        }


        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)//添加按钮
        {
            buttonchange1();
            buttonchange();
            txtModelTitle.Text = "";
            txtModelContent.Text = "";
            txtModelID.Text = "";
            oper = operate.add;
        }

        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)//修改按钮
        {
            buttonchange1();
            buttonchange();
            oper = operate.update;
        }

        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)//删除按钮
        {
            if (MessageBox.Show("确认删除该模板？", "此删除不可恢复", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string textbox = txtModelID.Text;
                int.TryParse(textbox, out tid);
                Sql3 = "delete t_nures_template where id=" + tid + "";
                int num = App.ExecuteSQL(Sql3);
                if (num > 0)
                {
                    App.Msg("删除成功");
                }
                else
                {
                    App.Msg("无选中内容可以删除");

                }
                ShowAllModel();
            }
            else
            {

            }
            buttonexchange();
            buttonexchange1();
            txtModelTitle.Text = "";
            txtModelContent.Text = "";
            //oper = operate.delete;   
        }

        /// <summary>
        /// 文本标记可写
        /// </summary>
        private void buttonchange()
        {
            txtModelTitle.ReadOnly = false;
            txtModelContent.ReadOnly = false;
            cboType.Enabled = true;
            buttonX1.Enabled = true;
            btnClose.Enabled = true;
        }

        /// <summary>
        /// 文本标记只读
        /// </summary>
        private void buttonexchange()
        {
            txtModelTitle.ReadOnly = true;
            txtModelContent.ReadOnly = true;
            cboType.Enabled = false;
            buttonX1.Enabled = false;
            btnClose.Enabled = false;
        }

        /// <summary>
        /// 增删改按钮标记不能用
        /// </summary>
        private void buttonchange1()
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        /// <summary>
        /// 增删改按钮标记可用
        /// </summary>
        private void buttonexchange1()
        {

            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void ucGridviewX1_Load(object sender, EventArgs e)
        {
            ShowAllModel();
            cboType.SelectedIndex = 0;
            cboCondiction.SelectedIndex = 0;
        }

        /// <summary>
        /// 查询区域的combobox的内容变化产生的变化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTemplateName.Text = "";
            if (cboCondiction.SelectedItem.ToString() == "无")//||comboBoxEx2.SelectedItem.ToString() =="个人模板查询"||comboBoxEx2.SelectedItem.ToString() =="病区模板查询"||comboBoxEx2.SelectedItem.ToString() =="全院模板查询")
            {
                txtTemplateName.ReadOnly = true;
            }
            if (cboCondiction.SelectedItem.ToString() == "按模板名称查询" || cboCondiction.SelectedItem.ToString() == "按模板内容查询" || cboCondiction.SelectedItem.ToString() == "个人模板查询" || cboCondiction.SelectedItem.ToString() == "病区模板查询" || cboCondiction.SelectedItem.ToString() == "全院模板查询")
            {
                txtTemplateName.ReadOnly = false;
            }
        }



        //==================================== Xiao Jun ===============================================

        /// <summary>
        /// 确定按钮,根据操作类型执行 增,删,改
        /// </summary>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (CheckForm() == false)
            {
                return;
            }

            int result = 0;

            #region 获取模板类型
            string type = "";
            if (cboType.SelectedItem.ToString() == "个人")
            {
                type = "p";
            }
            else if (cboType.SelectedItem.ToString() == "病区")
            {
                type = "s";
            }
            else if (cboType.SelectedItem.ToString() == "全院")
            {
                type = "h";
            }
            #endregion

            if (oper == operate.add)
            {
                tid = App.GenId("t_nures_template", "id");
                Sql = @"insert into t_nures_template (ID,TEMP_NAME,TEMP_CONTENT,TEMP_TYPE,CREATE_ID,SAID) values (" + tid + ",'" + txtModelTitle.Text + "','" + txtModelContent.Text + "','" + type + "'," + App.UserAccount.UserInfo.User_id + "," + App.UserAccount.CurrentSelectRole.Sickarea_Id + ")";
                result = App.ExecuteSQL(Sql);
            }
            if (oper == operate.update)
            {
                Sql2 = "update t_nures_template SET temp_name='" + txtModelTitle.Text + "',temp_content='" + txtModelContent.Text + "',temp_type='" + type + "' where id=" + txtModelID.Text + "";
                result = App.ExecuteSQL(Sql2);
            }
            string msg = result > 0 ? "保存成功!" : "保存失败!";
            App.Msg(msg);

            ShowAllModel();
            txtModelID.Text = "";
            cboType.SelectedIndex = 0;
            txtModelTitle.Text = "";
            txtModelContent.Text = "";
            //按钮状态变更
            buttonexchange();
            buttonexchange1();
        }

        /// <summary>
        /// 显示所有模板
        /// </summary>
        private void ShowAllModel()
        {
            string Sqlucload = "select id 编号 ,temp_name 模板名称,temp_content 内容,case when temp_type='p' then '个人' when temp_type='s' then '病区' when temp_type='h' then '全院' end 类型,b.user_name  创建人,c.sick_area_name 病区 from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where (a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and temp_type != 'p') or (a.create_id=" + App.UserAccount.UserInfo.User_id + " and temp_type != 's')";
            //string Sqlucload = SqlPerson + " union " + SqlSaid + " union " + Sqlhospital;
            ucGridviewX1.DataBd(Sqlucload, "编号", "", "");
        }

        /// <summary>
        /// 增删改操作前检查窗体各输入是否正确
        /// </summary>
        private bool CheckForm()
        {
            if (txtModelTitle.Text.Length == 0)
            {
                App.Msg("请输入模板的名称!");
                txtModelTitle.Focus();
                return false;
            }
            if (txtModelContent.Text.Length == 0)
            {
                App.Msg("请输入模板的内容!");
                txtModelContent.Focus();
                return false;
            }
            if (cboType.SelectedIndex == 0)
            {
                App.Msg("请选择模板的类型!");
                cboType.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// 关闭
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}