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
    public partial class ucMessageSet : UserControl
    {
        /// <summary>
        /// 是否是添加操作
        /// </summary>
        bool isAdd = false;
        public ucMessageSet()
        {
            InitializeComponent();
        }

        private void ucMessageSet_Load(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ucGridviewX1.fg.Click += new EventHandler(fg_Click);
                //绑定消息类型
                SetMsgType();
                btnSearch_Click(sender, e);
            }
            catch (Exception ex)
            {
                App.Msg(ex.Message);
            }
        }

        /// <summary>
        /// 设置消息类型下拉菜单
        /// </summary>
        private void SetMsgType()
        {
            cbxEdit_Type.DataSource = null;
            cbxMsgType.DataSource = null;

            string sqlMsgType = "select id,type_name from t_msg_type";
            DataSet ds = App.GetDataSet(sqlMsgType);
            //插入项
            DataRow dr = ds.Tables[0].NewRow();
            dr["id"] = 0;
            dr["type_name"] = "全部";
            ds.Tables[0].Rows.InsertAt(dr, 0);

           
            //查询类型
            cbxMsgType.DisplayMember = "type_name";
            cbxMsgType.ValueMember = "id";
            cbxMsgType.DataSource = ds.Tables[0];

            DataSet ds_2 = App.GetDataSet(sqlMsgType);
            //编辑类型
            cbxEdit_Type.DisplayMember = "type_name";
            cbxEdit_Type.ValueMember = "id";
            cbxEdit_Type.DataSource = ds_2.Tables[0];
            cbxMsgType.SelectedIndex = 0;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select a.id 编号,a.type_id,b.type_name 消息类型,a.message 消息内容,a.msg_scale 消息级别 from t_msg_content a inner join t_msg_type b on a.type_id=b.id where 1=1";
            //按消息内容查询
            if (txtMsgName.Text.Trim() != "")
            {
                sql += " and message like '%" + txtMsgName.Text.Trim() + "%'";
            }

            //按类型查询
            if (cbxMsgType.Text != "全部")
            {
                sql += " and a.type_id =" + cbxMsgType.SelectedValue;
            }
            ucGridviewX1.DataBd(sql, "消息类型", true, "id", "编号");
            ucGridviewX1.fg.Columns["type_id"].Visible = false;
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region 控件设置
            //启用
            txtEdit_Msg.Enabled = true;

            cbxEdit_Type.Enabled = true;
            cbMsg_Scale.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            //清理
            txtEdit_Msg.Text = "";

            cbMsg_Scale.Text = "";
            cbxEdit_Type.SelectedIndex = 0;
            btnAdd.Enabled = false;

            //禁用
            groupPanel2.Enabled = false;
            groupPanel1.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;


            isAdd = true;
            #endregion


        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow!=null)
            {
                #region 控件设置
                txtEdit_Msg.Enabled = true;

                cbxEdit_Type.Enabled = true;
                cbMsg_Scale.Enabled = true;
                btnSave.Enabled = true;
                btnCancel.Enabled = true;

                //禁用
                groupPanel2.Enabled = false;
                groupPanel1.Enabled = false;
                btnDelete.Enabled = false;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;

                isAdd = false;
                #endregion 
            }
            else
            {
                App.Msg("请选择一条数据！");
            }


        }

        /// <summary>
        /// 验证单精度浮点型数字
        /// </summary>
        /// <param name="score"></param>
        /// <returns></returns>
        private bool IsFloat(string score)
        {
            try
            {
                float.Parse(score);
                return true;
            }
            catch
            {
                return false;
            }
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
                string id = ucGridviewX1.fg.CurrentRow.Cells["编号"].Value.ToString();
                if (App.Ask("确定要删除吗？"))
                {
                    string del = "delete from t_msg_content where id=" + id;
                    int num = App.ExecuteSQL(del);
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
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            string score = "null";
            #region 验证数据
            if (txtEdit_Msg.Text == "")
            {
                App.Msg("请输入消息内容！");
                txtEdit_Msg.Focus();
                return;
            }
            if (cbMsg_Scale.Text == "")
            {
                App.Msg("清输入消息级别！");
                cbMsg_Scale.Focus();
                return;
            }
            //操作是否成功
            int num = 0;
            #endregion
            if (isAdd)
            {
                #region 添加数据
                int id = App.GenId("t_msg_content", "id");
                string sql = "insert into t_msg_content(id,type_id,message,msg_scale) values" +
                             "(" + id + "," + cbxEdit_Type.SelectedValue + ",'" + txtEdit_Msg.Text + "','"+cbMsg_Scale.Text+"')";

                num = App.ExecuteSQL(sql);

                #endregion
            }
            else
            {
                #region 修改
                string id = ucGridviewX1.fg.CurrentRow.Cells["编号"].Value.ToString();
                string update = "update t_msg_content set type_id=" + cbxEdit_Type.SelectedValue + ",message='" + txtEdit_Msg.Text + "',msg_scale='"+cbMsg_Scale.Text+"' where id=" + id;
                num = App.ExecuteSQL(update);
                #endregion
            }
            if (num > 0)
            {
                App.Msg("操作成功！");
                btnCancel_Click(sender, e);
                btnSearch_Click(sender, e);
                
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
            #region 控件设置
            //启用
            groupPanel2.Enabled = true;
            groupPanel1.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            //禁用
            txtEdit_Msg.Enabled = false;

            cbxEdit_Type.Enabled = false;
            cbMsg_Scale.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            fg_Click(sender, e);
            #endregion
        }

        /// <summary>
        /// 表格单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fg_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow != null)
            {
                txtEdit_Msg.Text = ucGridviewX1.fg.CurrentRow.Cells["消息内容"].Value.ToString();
                cbMsg_Scale.Text = ucGridviewX1.fg.CurrentRow.Cells["消息级别"].Value.ToString();
               // txtEdit_Score.Text = ucGridviewX1.fg.CurrentRow.Cells["扣分值"].Value.ToString(); 
                cbxEdit_Type.SelectedValue = ucGridviewX1.fg.CurrentRow.Cells["type_id"].Value;
            }
        }

        private void btnAddMsgType_Click(object sender, EventArgs e)
        {
            frmAddType frm = new frmAddType();
            frm.ShowDialog();
            if (frm.flag)
            {
                SetMsgType();
            }
            
        }


    }
}
