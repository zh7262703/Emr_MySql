using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class ucFollowStateSet : UserControl
    {
        private bool Flag = false;
        private string selectedId=""; 
        public ucFollowStateSet()
        {
            InitializeComponent();
            dgvStateList.ReadOnly = true;
            ShowUndefineList();
            ShowEndList();
            ShowNotEndList();
            IniControls();
        }
        /// <summary>
        /// �������״̬�б�
        /// </summary>
        public void ShowEndList()
        {
            string temp = "select id ����,des ״̬ from t_follow_state where isfinished=1";
            DataSet dsTemp = App.GetDataSet(temp);
            if (dsTemp.Tables[0].Rows.Count != 0)
                dgvEnd.DataSource = dsTemp.Tables[0].DefaultView;
            else
                dgvEnd.DataSource = null;
        }
        /// <summary>
        /// ����������б�
        /// </summary>
        public void ShowNotEndList()
        {
            string temp = "select id ����,des ״̬ from t_follow_state where isfinished=0";
            DataSet dsTemp = App.GetDataSet(temp);
            if (dsTemp.Tables[0].Rows.Count != 0)
                dgvNotEnd.DataSource = dsTemp.Tables[0].DefaultView;
            else
                dgvNotEnd.DataSource = null;
        }
        /// <summary>
        /// ��ʼ���ؼ�
        /// </summary>
        public void IniControls()
        {
            txtState.Text = "";
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            txtState.Enabled = false;
            btnAdd.Enabled = true;
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public void ShowUndefineList()
        {
            string temp = "select id ����,des ״̬ from t_follow_state where isfinished is null order by id";
            DataSet dsTemp=App.GetDataSet(temp);
            if (dsTemp.Tables[0].Rows.Count != 0)
                dgvStateList.DataSource = dsTemp.Tables[0].DefaultView;
            else
                dgvStateList.DataSource = null;

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
                    Sql = "insert into T_FOLLOW_STATE(DES) values('" + txtState.Text.Trim() + "')";
                else
                    Sql = "update T_FOLLOW_STATE set des='" + txtState.Text.Trim() + "' where id=" + selectedId + "";
                try
                {
                    App.ExecuteSQL(Sql);
                    App.Msg("�����ɹ�");
                    IniControls();
                    ShowUndefineList();
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
            }
            else
                App.Msg("���벻��Ϊ��");
        }

        private void dgvStateList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                selectedId = dgvStateList.Rows[e.RowIndex].Cells["����"].Value.ToString();
                txtState.Text = dgvStateList.Rows[e.RowIndex].Cells["״̬"].Value.ToString();
                btnUpdate.Enabled = true;
            }
            else
            {
                selectedId = "";
                txtState.Text = "";
                btnUpdate.Enabled = false;

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
                        ShowUndefineList();
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

        private void btnToRight1_Click(object sender, EventArgs e)
        {
            if (dgvStateList.SelectedRows != null)
            {
                ArrayList End = new ArrayList();
                string Sql = "";
                foreach (DataGridViewRow Row in dgvStateList.SelectedRows)
                {
                    string Id = Row.Cells["����"].Value.ToString();
                    Sql = "update t_follow_state set isfinished=1 where id=" + Id + "";
                    End.Add(Sql);
                }
                string[] Batch = new string[End.Count];
                for (int i = 0; i < End.Count; i++)
                {
                    Batch[i] = End[i].ToString();
                }
                try
                {
                    App.ExecuteBatch(Batch);
                    //ˢ��
                    ShowUndefineList();
                    ShowEndList();

                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
            }
        }

        private void btnToLeft1_Click(object sender, EventArgs e)
        {
            if (dgvEnd.SelectedRows != null)
            {
                ArrayList End = new ArrayList();
                string Sql = "";
                foreach (DataGridViewRow Row in dgvEnd.SelectedRows)
                {
                    string Id = Row.Cells["����"].Value.ToString();
                    Sql = "update t_follow_state set isfinished=null where id=" + Id + "";
                    End.Add(Sql);
                }
                string[] Batch = new string[End.Count];
                for (int i = 0; i < End.Count; i++)
                {
                    Batch[i] = End[i].ToString();
                }
                try
                {
                    App.ExecuteBatch(Batch);
                    //ˢ��
                    ShowUndefineList();
                    ShowEndList();
                    
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
            }
        }

        private void btnToRight2_Click(object sender, EventArgs e)
        {
            if (dgvStateList.SelectedRows != null)
            {
                ArrayList End = new ArrayList();
                string Sql = "";
                foreach (DataGridViewRow Row in dgvStateList.SelectedRows)
                {
                    string Id = Row.Cells["����"].Value.ToString();
                    Sql = "update t_follow_state set isfinished=0 where id=" + Id + "";
                    End.Add(Sql);
                }
                string[] Batch = new string[End.Count];
                for (int i = 0; i < End.Count; i++)
                {
                    Batch[i] = End[i].ToString();
                }
                try
                {
                    App.ExecuteBatch(Batch);
                    //ˢ��
                    ShowUndefineList();
                    
                    ShowNotEndList();
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
            }
        }

        private void btnToLeft2_Click(object sender, EventArgs e)
        {
            if (dgvNotEnd.SelectedRows != null)
            {
                ArrayList End = new ArrayList();
                string Sql = "";
                foreach (DataGridViewRow Row in dgvNotEnd.SelectedRows)
                {
                    string Id = Row.Cells["����"].Value.ToString();
                    Sql = "update t_follow_state set isfinished=null where id=" + Id + "";
                    End.Add(Sql);
                }
                string[] Batch = new string[End.Count];
                for (int i = 0; i < End.Count; i++)
                {
                    Batch[i] = End[i].ToString();
                }
                try
                {
                    App.ExecuteBatch(Batch);
                    //ˢ��
                    ShowUndefineList();
                    
                    ShowNotEndList();
                }
                catch (Exception ex)
                {
                    App.MsgErr(ex.Message);
                }
            }
        }

    }
}

