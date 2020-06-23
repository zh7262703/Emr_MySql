using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    public partial class frmTemplateList : DevComponents.DotNetBar.Office2007Form
    {
        public string  nursecomplate="";//全局变量 传值
      
        public frmTemplateList()
        {
            InitializeComponent();
        }
        
        private void frmTemplateList_Load(object sender, EventArgs e)
        {
            cboType.Text = "个人";

            ucGridviewX1.fg.AllowUserToAddRows = false;
            ucGridviewX1.fg.ReadOnly = true;
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.Click += new EventHandler(ClickGrid);
            buttonX1_Click_1(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("该模板内容为空");
                this.Close();
            }
            nursecomplate=textBox1.Text;

            //根据secondcbtxt的内容去查询数据库t_nures_template，找到t_nures_template中temp_type和secondcbtxt相同的数据
            //将这条数据的内容temp_content写入到调用这个窗口的窗口中去,最后关闭窗体。
            this.Close();
        }

        public void ClickGrid(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = ucGridviewX1.fg.SelectedRows[0].Cells["内容"].Value.ToString();
            }
            catch
            { }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {           
            string SqlQuery = "";
            if (cboType.Text == "个人")
            {
                SqlQuery = "select id 编号 ,temp_name 模板名称,case when temp_type='p' then '个人' when temp_type='s' then '病区' when temp_type='h' then '全院' end 类型,b.user_name  创建人,c.sick_area_name 病区 from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='p' and create_id=" + App.UserAccount.UserInfo.User_id + " and temp_name like '%" + txtTempName.Text + "%'";
            }
            else if (cboType.Text == "病区")
            {
                SqlQuery = "select id 编号 ,temp_name 模板名称,case when temp_type='p' then '个人' when temp_type='s' then '病区' when temp_type='h' then '全院' end 类型,b.user_name  创建人,c.sick_area_name 病区 from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='s' and temp_name like '%" + txtTempName.Text + "%'";
            }
            else if (cboType.Text == "全院")
            {
                SqlQuery = "select id 编号 ,temp_name 模板名称,case when temp_type='p' then '个人' when temp_type='s' then '病区' when temp_type='h' then '全院' end 类型,b.user_name  创建人,c.sick_area_name 病区 from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='h' and temp_name like '%" + txtTempName.Text + "%'";
            }                      
            ucGridviewX1.DataBd(SqlQuery, "编号", "", "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            nursecomplate = "";
            this.Close();
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTempName.Text = "";
        }

        private void btnNewTemplate_Click(object sender, EventArgs e)
        {
            frmTemplateAdd fc = new frmTemplateAdd();
            fc.ShowDialog();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {               
                string templatename=ucGridviewX1.fg[ucGridviewX1.fg.Columns["模板名称"].Index,ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                if (App.Ask("确定要删除记录“" + templatename + "”"))
                {
                    string sql = "delete from t_nures_template aa where aa.id=" + ucGridviewX1.fg[ucGridviewX1.fg.Columns["编号"].Index, ucGridviewX1.fg.CurrentRow.Index].Value.ToString()+ "";
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        buttonX1_Click_1(sender, e);
                    }
                    else
                    {
                        App.MsgErr("删除失败！");
                    }
                }
            }
            catch(Exception ex)
            {
                App.MsgErr("删除失败！"+ex.Message);
            }
        }     
    }
}