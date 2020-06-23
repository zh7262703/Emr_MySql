using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ACCORD_REMIND
{
    public partial class frmAddType : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 操作是否成功
        /// </summary>
        public bool flag =false;
        public frmAddType()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTypeName.Text.Trim() == "")
                {
                    App.Msg("请输入类型名称！");
                    txtTypeName.Focus();
                    return;
                }
                string sql = "select count(*) from t_msg_type where type_name='" + txtTypeName.Text.Trim() + "'";
                //验证唯一性
                int count = Convert.ToInt32(App.ReadSqlVal(sql, 0, "id"));
                if (count > 0)
                {
                    App.Msg("已存在相同的类型名称！");
                    txtTypeName.SelectAll();
                }
                else
                {
                    int id = App.GenId("t_msg_type", "id");
                    string add = "insert into t_msg_type(id,type_name) values" +
                                 "(" + id + ",'" + txtTypeName.Text + "')";
                    int num = App.ExecuteSQL(add);
                    if (num > 0)
                    {
                        App.Msg("添加成功!");
                        flag = true;
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}