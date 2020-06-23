using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class UCLisItem : UserControl
    { /// <summary>
        /// 当前操作类型
        /// </summary>
        public enum Operater
        {
            noThing,
            update,
            delete,
            add
        }

        public Operater operater = new Operater();

        public UCLisItem()
        {
            InitializeComponent();
            operater = Operater.noThing;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        private void GetData()
        {
            string sql_LisItem = "select a.item_code,item_name LIS项目名称,a.item_unit 单位,a.max_value 最高值, a.min_value 最低值,a.item_type 是否重要 from t_lis_item a where 1=1 ";
            if (txtSearchName.Text != "")
            {
                sql_LisItem += " and item_name like '%" + txtSearchName.Text + "%'";
            }
            if (ckbSearch.Checked)
            {
                sql_LisItem += " and a.item_type='重要'";
            }
            try
            {
                DataSet ds = App.GetDataSet(sql_LisItem);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        dgvItemList.DataSource = dt;
                        dgvItemList.Columns["item_code"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void UCLisItem_Load(object sender, EventArgs e)
        {
            GetData();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            operater = Operater.add;
            //禁用控件
            dgvItemList.Enabled = false;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnDel.Enabled = false;
            //启用
            txtItemName.Enabled = true;
            txtUnit.Enabled = true;
            txtMax.Enabled = true;
            txtMin.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            //清空文本框
            txtItemName.Text = "";
            txtMax.Text = "";
            txtMin.Text = "";
            txtUnit.Text = "";
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            operater = Operater.update;
            //禁用控件
            dgvItemList.Enabled = false;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnDel.Enabled = false;
            //启用
            txtItemName.Enabled = true;
            txtUnit.Enabled = true;
            txtMax.Enabled = true;
            txtMin.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            operater = Operater.delete;
            //禁用控件
            dgvItemList.Enabled = false;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnDel.Enabled = false;
            //启用
            txtItemName.Enabled = true;
            txtUnit.Enabled = true;
            txtMax.Enabled = true;
            txtMin.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (operater == Operater.add)//添加
            {
                Add();
            }
            else if (operater == Operater.update)//修改
            {
                Modify();
            }
            else if (operater == Operater.delete)//删除
            {
                Del();
            }
            else
            {
                App.Msg("您没有选择任何操作！");
            }
            //操作完成，还原界面
            operater = Operater.noThing;
            //启用控件
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnDel.Enabled = true;
            dgvItemList.Enabled = true;
            //禁用控件
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            txtItemName.Enabled = false;
            txtMax.Enabled = false;
            txtMin.Enabled = false;
            txtUnit.Enabled = false;
            GetData();
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //操作完成，还原界面
            operater = Operater.noThing;
            //启用控件
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnDel.Enabled = true;
            dgvItemList.Enabled = true;
            //禁用控件
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            txtItemName.Enabled = false;
            txtMax.Enabled = false;
            txtMin.Enabled = false;
            txtUnit.Enabled = false;
            GetData();
        }

        /// <summary>
        /// 添加：查出所有item_code，算出新的item_code
        /// </summary>
        private void Add()
        {
            try
            {
                //查出所有item_code放在string数组中
                string sql_item = "select item_code from t_lis_item";
                string[] str_arr = null;
                DataSet ds = App.GetDataSet(sql_item);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    str_arr = new string[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        str_arr[i] = dt.Rows[i]["item_code"].ToString();
                    }
                }

                //从string数组中截取字符串，得到int类型的数组
                int[] int_code = new int[str_arr.Length];
                for (int i = 0; i < int_code.Length; i++)
                {
                    int_code[i] = Convert.ToInt32(str_arr[i].Substring(3));
                }
                //求int数组中的最大值
                int temp = 0;
                for (int i = 0; i < int_code.Length; i++)
                {
                    if (int_code[i] > temp)
                    {
                        temp = int_code[i];
                    }
                }
                //拼出最新的item_code
                string newCode = "WJX" + (temp + 1);
                //是否重要
                string isImportant = ckbImportant.Checked ? "重要" : "";
                //插入数据库
                string sql_insert = "insert into t_lis_item(item_code,item_name,item_type,item_unit,max_value,min_value) values" +
                    "('" + newCode + "','" + txtItemName.Text + "','" + isImportant + "','" + txtUnit.Text + "','" + txtMax.Text + "','" + txtMin.Text + "')";
                int num = App.ExecuteSQL(sql_insert);
                if (num > 0)
                {
                    App.Msg("添加成功！");
                }
                else
                {
                    App.Msg("添加失败！");
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void Modify()
        {
            try
            {
                if (dgvItemList.CurrentRow != null)
                {
                    string item_code = dgvItemList.CurrentRow.Cells["item_code"].Value.ToString();
                    int num = 0;
                    string isImportant = ckbImportant.Checked ? "重要" : "";
                    string sql_update = "update t_lis_item set item_unit='" + txtUnit.Text + "',max_value='" + txtMax.Text + "',min_value='" + txtMin.Text + "',item_type='" + isImportant + "' where item_code='" + item_code + "'";
                    num = App.ExecuteSQL(sql_update);
                    if (num > 0)
                    {
                        App.Msg("更新成功！");
                    }
                    else
                    {
                        App.Msg("更新失败！");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Del()
        {
            try
            {
                if (dgvItemList.CurrentRow != null)
                {
                    string item_code = dgvItemList.CurrentRow.Cells["item_code"].Value.ToString();
                    string sql_del = "delete from t_lis_item where item_code='" + item_code + "'";

                    int num = App.ExecuteSQL(sql_del);
                    if (num > 0)
                    {
                        App.Msg("删除成功！");
                    }
                    else
                    {
                        App.Msg("删除失败！");
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 表格单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvItemList_Click(object sender, EventArgs e)
        {
            if (dgvItemList.CurrentRow != null)
            {
                txtItemName.Text = dgvItemList.CurrentRow.Cells["LIS项目名称"].Value.ToString();
                txtUnit.Text = dgvItemList.CurrentRow.Cells["单位"].Value.ToString();
                txtMax.Text = dgvItemList.CurrentRow.Cells["最高值"].Value.ToString();
                txtMin.Text = dgvItemList.CurrentRow.Cells["最低值"].Value.ToString();
                ckbImportant.Checked = dgvItemList.CurrentRow.Cells["是否重要"].Value.ToString() == "重要" ? true : false;
            }

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
