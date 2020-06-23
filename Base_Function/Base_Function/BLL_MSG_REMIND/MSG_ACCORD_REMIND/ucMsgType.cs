using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND
{
    public partial class ucMsgType : UserControl
    {
        /// <summary>
        /// 是否是添加操作
        /// </summary>
        bool isAdd = false;
        public ucMsgType()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select id 编号, type_name 类型名称 from t_msg_type";
            if (txtTypeName.Text.Trim() != "")
            {
                sql += "where type_name like '" + txtTypeName.Text.Trim() + "%'";
            }
            ucGridviewX1.DataBd(sql, "编号", true, "id", "编号");
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //启用
            txtEdit_TypeName.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            //禁用
            groupPanel2.Enabled = false;
            groupPanel1.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            //清理
            txtEdit_TypeName.Text = "";

            isAdd = true;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //启用
            txtEdit_TypeName.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            //禁用
            groupPanel2.Enabled = false;
            groupPanel1.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            isAdd = false;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow != null)
            {
                if (App.Ask("删除消息类型会同时删除该类型的子类，确定要删除吗？"))
                {
                    string id = ucGridviewX1.fg.CurrentRow.Cells["编号"].Value.ToString();
                    string del_type = "delete from t_msg_type where id=" + id;
                    string del_msg = "delete from t_msg_content where type_id=" + id;
                    string[] strArr = new string[2];
                    strArr[0] = del_type;
                    strArr[1] = del_msg;
                    int num = App.ExecuteBatch(strArr);
                    if (num > 0)
                    {
                        App.Msg("删除成功！");
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        App.Msg("删除失败！");
                    }
                }
            }
        }
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //验证输入
            if (txtEdit_TypeName.Text.Trim() == "")
            {
                App.Msg("请输入类型名称！");
                txtEdit_TypeName.Focus();
                return;
            }

            //操作是否成功
            int num = 0;
            if (isAdd)
            {
                int id = App.GenId("t_msg_type", "id");
                string insert = "insert into t_msg_type(id,type_name) values" +
                        "(" + id + ",'" + txtEdit_TypeName.Text.Trim() + "')";
                num = App.ExecuteSQL(insert);

            }
            else
            {
                string update = "update t_msg_type set type_name='" + txtEdit_TypeName.Text.Trim() + "' where id=" + ucGridviewX1.fg.CurrentRow.Cells["编号"].Value.ToString();
                num = App.ExecuteSQL(update);
            }

            if (num > 0)
            {
                App.Msg("操作成功！");
                btnSearch_Click(sender, e);
                btnCancel_Click(sender, e);

            }
            else
            {
                App.Msg("操作失败！");
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //启用
            groupPanel2.Enabled = true;
            groupPanel1.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            //禁用

            txtEdit_TypeName.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            fg_Click(sender,e);
        }

        /// <summary>
        /// 表格单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fg_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow != null)
            {
                txtEdit_TypeName.Text = ucGridviewX1.fg.CurrentRow.Cells["类型名称"].Value.ToString();
            }
        }

        private void ucMsgType_Load(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.Click += new EventHandler(fg_Click);
        }
    }
}
