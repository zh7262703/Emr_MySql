using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_FOLLOW
{
    public partial class ucFollowTimeTypeSet : UserControl
    {
        private string T_SQL_Type = null;//查询表内数据
        private DataSet ds;             //存储查询到的数据
        private bool IsNew = true;     //判断是否为新建
        private static int id = 0;            //保存选中行的ID
        private string TimeType = "";       //存入数据库的时间类型
        public ucFollowTimeTypeSet()
        {
            InitializeComponent();
            T_SQL_Type = "select id 编号,typename 类型名 from t_follow_type order by 编号 asc";
        }

        private void followTypeSet_Load(object sender, EventArgs e)
        {
            ShowData();
            cmbUnit.SelectedIndex = 1;
        }
        /// <summary>
        /// 绑定GridView数据
        /// </summary>
        private void ShowData()
        {
            ds = App.GetDataSet(T_SQL_Type);
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
            //初始化控件           
            dataGridViewX1.ReadOnly = true;
            txtName.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            //初始化控件
            IsNew = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtName.Enabled = true;
            txtName.Text = "";
            txtName.Focus();

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            IsNew = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            txtName.Enabled = true;
            txtName.Focus();
        }
        /// <summary>
        /// 删除选中数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (App.Ask("是否删除"))
            {
                try
                {
                    string sql_delete = "delete from t_follow_type where id=" + id + "";
                    App.ExecuteSQL(sql_delete);
                    ShowData();
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
            }
            
        }
        /// <summary>
        /// 保存修改或新建数据
        /// </summary>
        private bool Edit()
        {
            string sql="";
            int i=0;
            if (txtName.Text == "" )
            {
                App.Msg("输入不能为空");
                txtName.Focus();
               
            }
            if (IsNew)
            {
                if (checkName())
                {
                    App.Msg("已存在该时间类型，请重新输入");
                    return false;
                }
                sql = "insert into t_follow_type(typename) values('" + txtName.Text.Trim()+cmbUnit.Text+"1次" + "')";
            }
            else
            {
                if (checkName())
                {
                    App.Msg("已存在该时间类型，请重新输入");
                    return false;
                }
                else
                {
                    if (id != 0)
                        sql = "update t_follow_type set typename='" + txtName.Text.Trim() + cmbUnit.Text + "1次" + "' where id=" + id + "";
                    else
                        App.Msg("选中数据后才能进行修改！");
                }
            }

            try
            {
                if (App.ExecuteSQL(sql) > 0)
                {
                    App.Msg("插入成功!");
                    return true;
                }
                else
                {
                    App.Msg("插入失败!");
                    return false;
                }
            }
            catch(Exception ex)
            {
                
                App.MsgErr(ex.Message);
                return false;
            }
        }

        //检查类型是否重复
        private bool checkName()
        {
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if ((txtName.Text+cmbUnit.Text+"1次") == ds.Tables[0].Rows[i][1].ToString())
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Edit())
                ShowData();
            else
                refreshForm();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ShowData();
        }
        /// <summary>
        /// 选中datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void refreshForm()
        {
            txtName.Text = "";
            txtName.Enabled = false;
            
        }
        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            else
            {
                string name = dataGridViewX1.Rows[e.RowIndex].Cells["类型名"].Value.ToString();
                txtName.Text=name.Substring(0,name.IndexOf('次')-2);
                cmbUnit.Text = name.Substring(name.IndexOf('次')-2,1);
                id = Convert.ToInt32(dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            } 
        }

    }
}
