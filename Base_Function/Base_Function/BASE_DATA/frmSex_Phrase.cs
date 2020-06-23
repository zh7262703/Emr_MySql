using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    public partial class frmSex_Phrase : UserControl
    {
        private bool isSave = false; //判断是新增还是修改
        private string T_Sex_Phrase = ""; //查询关键字表SQL语句
        private string ID = "";              //关键表ID
        public frmSex_Phrase()
        {
            InitializeComponent();
            App.UsControlStyle(this);
            T_Sex_Phrase = "select t.id as 编号,t.phrase as 关键字,(case when t.sex=0 then '男' else '女' end) as 性别 from t_sex_phrase t";
            DataBd();
            txtPhrase.Enabled = false;
            cboGender.Enabled = false;
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = false;
        }
        /// <summary>
        /// 数据源单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            int index = ucGridviewX1.fg.CurrentRow.Index;
            if (ucGridviewX1.fg.RowCount > 0)
            {
                txtPhrase.Text = ucGridviewX1.fg["关键字", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                if (ucGridviewX1.fg["性别", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "男")
                {
                    cboGender.SelectedIndex = 0;
                }
                else
                {
                    cboGender.SelectedIndex = 1;
                }
                
            }
        }
        //绑定数据
        private void DataBd()
        {
            ucGridviewX1.DataBd(T_Sex_Phrase, "编号", false, "", "");
            ucGridviewX1.fg.ReadOnly = true;
        }
        //添加和修改改变控件状态
        private void Changed()
        {
            ucGridviewX1.fg.Enabled = false;
            txtPhrase.Enabled = true;
            cboGender.Enabled = true;
        }
        //取消改变控件状态
        private void ESCChanged()
        {
            ucGridviewX1.fg.Enabled = true;
            txtPhrase.Enabled = false;
            cboGender.Enabled = false;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        //添加
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            Changed();
        }
        //修改
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            Changed();
        }
        //删除
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.Ask("您确认要删除吗？"))
                {
                    string SQLDelete = "delete from t_sex_phrase where id ='" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                    int count = App.ExecuteSQL(SQLDelete);
                    if (count > 0)
                    {
                        App.Msg("删除成功!");
                    }
                }
            }
            catch (Exception)
            {
                App.Msg("删除失败!");
            }
            //绑定数据
            DataBd();
            ESCChanged();
        }
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPhrase.Text.Trim() == "")
                {
                    App.Msg("关键字不能为空！");
                    txtPhrase.Focus();
                    return;
                }
                ID = App.GenId("t_sex_phrase", "id").ToString();
                string sql = "";
                if (isSave)
                {
                    sql = "insert into t_sex_phrase(id, phrase, sex)values('" + ID + "', '" + txtPhrase.Text.Trim() + "', '" + cboGender.SelectedIndex + "')";
                }
                else
                {
                    sql = "update t_sex_phrase set phrase = '" + txtPhrase.Text.Trim() + "',sex = '" + cboGender.SelectedIndex + "' where id = '" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                }
                if (sql != "")
                {
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        btnAdd.Enabled = true;
                        btnUpdate.Enabled = true;
                        btnDelete.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                App.Msg("添加失败，原因：" + ex.ToString() + "");
            }
            //绑定数据
            DataBd();
            ESCChanged();
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ESCChanged();
        }
    }
}