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
        /// �����Ƿ�ɹ�
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
                    App.Msg("�������������ƣ�");
                    txtTypeName.Focus();
                    return;
                }
                string sql = "select count(*) from t_msg_type where type_name='" + txtTypeName.Text.Trim() + "'";
                //��֤Ψһ��
                int count = Convert.ToInt32(App.ReadSqlVal(sql, 0, "id"));
                if (count > 0)
                {
                    App.Msg("�Ѵ�����ͬ���������ƣ�");
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
                        App.Msg("��ӳɹ�!");
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