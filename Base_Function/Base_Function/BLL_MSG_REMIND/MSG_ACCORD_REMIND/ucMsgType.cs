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
        /// �Ƿ�����Ӳ���
        /// </summary>
        bool isAdd = false;
        public ucMsgType()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "select id ���, type_name �������� from t_msg_type";
            if (txtTypeName.Text.Trim() != "")
            {
                sql += "where type_name like '" + txtTypeName.Text.Trim() + "%'";
            }
            ucGridviewX1.DataBd(sql, "���", true, "id", "���");
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //����
            txtEdit_TypeName.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            //����
            groupPanel2.Enabled = false;
            groupPanel1.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            //����
            txtEdit_TypeName.Text = "";

            isAdd = true;
        }

        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //����
            txtEdit_TypeName.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            //����
            groupPanel2.Enabled = false;
            groupPanel1.Enabled = false;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            isAdd = false;
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow != null)
            {
                if (App.Ask("ɾ����Ϣ���ͻ�ͬʱɾ�������͵����࣬ȷ��Ҫɾ����"))
                {
                    string id = ucGridviewX1.fg.CurrentRow.Cells["���"].Value.ToString();
                    string del_type = "delete from t_msg_type where id=" + id;
                    string del_msg = "delete from t_msg_content where type_id=" + id;
                    string[] strArr = new string[2];
                    strArr[0] = del_type;
                    strArr[1] = del_msg;
                    int num = App.ExecuteBatch(strArr);
                    if (num > 0)
                    {
                        App.Msg("ɾ���ɹ���");
                        btnSearch_Click(sender, e);
                    }
                    else
                    {
                        App.Msg("ɾ��ʧ�ܣ�");
                    }
                }
            }
        }
        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //��֤����
            if (txtEdit_TypeName.Text.Trim() == "")
            {
                App.Msg("�������������ƣ�");
                txtEdit_TypeName.Focus();
                return;
            }

            //�����Ƿ�ɹ�
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
                string update = "update t_msg_type set type_name='" + txtEdit_TypeName.Text.Trim() + "' where id=" + ucGridviewX1.fg.CurrentRow.Cells["���"].Value.ToString();
                num = App.ExecuteSQL(update);
            }

            if (num > 0)
            {
                App.Msg("�����ɹ���");
                btnSearch_Click(sender, e);
                btnCancel_Click(sender, e);

            }
            else
            {
                App.Msg("����ʧ�ܣ�");
            }
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //����
            groupPanel2.Enabled = true;
            groupPanel1.Enabled = true;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            //����

            txtEdit_TypeName.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            fg_Click(sender,e);
        }

        /// <summary>
        /// ��񵥻�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fg_Click(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.CurrentRow != null)
            {
                txtEdit_TypeName.Text = ucGridviewX1.fg.CurrentRow.Cells["��������"].Value.ToString();
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
