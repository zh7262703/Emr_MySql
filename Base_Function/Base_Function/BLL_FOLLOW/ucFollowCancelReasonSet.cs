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
    public partial class ucFollowCancelReasonSet : UserControl
    {
        private bool Flag = false;
        private string selectedId = "";
        public ucFollowCancelReasonSet()
        {
            InitializeComponent();
            dgvCancelReason.ReadOnly = true;
            ShowList();
            IniControls();
        }
        public void IniControls()
        {
            txtState.Text = "";
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            txtState.Enabled = false;
            btnAdd.Enabled = true;
        }
        public void ShowList()
        {
            string temp = "select id ����,des ԭ�� from T_FOLLOW_CANCEL_REASON order by id";
            DataSet dsTemp = App.GetDataSet(temp);
            dgvCancelReason.DataSource = dsTemp.Tables[0].DefaultView;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtState.Enabled = true;
            btnAdd.Enabled = false;
            txtState.Text = "";
            Flag = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtState.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            Flag = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtState.Text.Trim() != "")
            {
                string Sql;
                if (Flag)
                    Sql = "insert into T_FOLLOW_CANCEL_REASON(DES) values('" + txtState.Text.Trim() + "')";
                else
                    Sql = "update T_FOLLOW_CANCEL_REASON set des='" + txtState.Text.Trim() + "' where id=" + selectedId + "";
                try
                {
                    App.ExecuteSQL(Sql);
                    App.Msg("�����ɹ�");
                    IniControls();
                    ShowList();
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
            }
            else
                App.Msg("���벻��Ϊ��");
        }
        private void dgvCancelReason_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedId = dgvCancelReason.Rows[e.RowIndex].Cells["����"].Value.ToString();
                txtState.Text = dgvCancelReason.Rows[e.RowIndex].Cells["ԭ��"].Value.ToString();
                btnUpdate.Enabled = true;

            }
        }


        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedId != "")
            {
                if (App.Ask("ȷ��ɾ��"))
                {
                    try
                    {
                        string Sql = "delete from T_FOLLOW_STATE where id=" + selectedId + "";
                        App.ExecuteSQL(Sql);
                        IniControls();
                        ShowList();
                    }
                    catch (Exception ex)
                    {
                        App.MsgErr(ex.Message);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            IniControls();
        }

    }
}
