using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;

namespace Base_Function.BASE_DATA
{
    public partial class ucTake_over_SEQ : UserControl
    {
        bool IsSave = false;             //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID;              //���ID
        private string Take_over_SEQ;   //��β�ѯ
        private string seq;             //��ǰѡ�еİ������
        DataSet ds;
        public ucTake_over_SEQ()
        {
            InitializeComponent();
            Take_over_SEQ = @"select ID as  ��α��,SEQ as �������,BEGIN_TIME as ��ʼʱ��,END_TIME as ��ֹʱ��,(case when BEGIN_LOGIC=0 then '>' else '>=' end) as  �����ʼ��������," +
                         @"(case when END_LOGIC=0 then '<' else '<=' end) as ��ν�ֹ�������� from T_TAKE_OVER_SEQ ";
        }
        private void frmTake_over_SEQ_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("�����Ϣά��");
            ShowValue();
            ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
            cboStart_condition.SelectedIndex = 0;
            cboEnd_condition.SelectedIndex = 0;
            RefleshFrm();
        }
        /// <summary>
        /// ����ˢ��
        /// </summary>
        private void ShowValue()
        {
            string SQl = Take_over_SEQ + "  order by ID desc";
            ds = App.GetDataSet(SQl);
            if (ds != null)
            {
                ucC1FlexGrid1.DataBd(SQl, "��α��", false, "", "");
                ucC1FlexGrid1.fg.Cols["��α��"].Visible = false;
                ucC1FlexGrid1.fg.Cols["��α��"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.Cols["��α��"].Visible = false;
                ucC1FlexGrid1.fg.Cols["��α��"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
            catch
            { }
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
           
            txtName.Enabled = false;
            dtpStartTime.Enabled = false;
            dtpEndTime.Enabled = false;
            cboStart_condition.Enabled = false;
            cboEnd_condition.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            IsSave = false;

        }
        /// <summary>
        /// �༭״̬
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtName.Text = "";
            }
            txtName.Enabled = true ;
            dtpStartTime.Enabled = true;
            dtpEndTime.Enabled = true;
            cboStart_condition.Enabled = true;
            cboEnd_condition.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            txtName.Focus();
        }
        /// <summary>
        /// �жϰ�������Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_TAKE_OVER_SEQ where SEQ='" + name + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsSave = true;
            Edit(IsSave);
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsSave = false;
            Edit(IsSave);
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("������Ʋ���Ϊ�գ�");
                    txtName.Focus();
                    return;
                }
                string sql = "";
                ID = App.GenId("T_TAKE_OVER_SEQ", "ID").ToString();
                if (IsSave)
                {
                    if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�İ�������ˣ�");
                        txtName.Focus();
                        return;
                    }
                    sql = "insert into T_TAKE_OVER_SEQ(ID,SEQ,BEGIN_TIME,END_TIME,BEGIN_LOGIC,END_LOGIC) values('"
                         + ID + "','"
                         +txtName.Text+ "','"
                         + dtpStartTime.Value.ToString("yyyy-MM-dd") + "','"
                         + dtpEndTime.Value.ToString("yyyy-MM-dd") + "','"
                         +cboStart_condition.SelectedIndex.ToString() + "','"
                         + cboEnd_condition.SelectedIndex.ToString()+ "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (seq.Trim() != "")
                    {
                        if (txtName.Text.Trim() != seq.Trim())
                        {
                             if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�İ�������ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_TAKE_OVER_SEQ set SEQ='"
                         + txtName.Text + "',BEGIN_TIME='"
                         + dtpStartTime.Value.ToString("yyyy-MM-dd") + "',END_TIME='"
                         + dtpEndTime.Value.ToString("yyyy-MM-dd") + "',BEGIN_LOGIC='"
                         + cboStart_condition.SelectedIndex.ToString() + "',END_LOGIC='"
                         + cboEnd_condition.SelectedIndex.ToString() + "' where ID=" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��α��"].ToString() + "";

                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);
                    }
                //����ˢ��
                ShowValue();
            }
            catch (Exception ex)
            {
                App.Msg("���ʧ�ܣ�ԭ��" + ex.ToString() + "");
            }
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //RefleshFrm();
            refurbish();
        }
        int Rowcount = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucC1FlexGrid1.fg.RowSel > 0)
                {

                    ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��α��"].ToString();
                    txtName.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�������"].ToString();
                    seq = txtName.Text;
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��ʼʱ��"] != DBNull.Value)
                    {
                        dtpStartTime.Value = Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��ʼʱ��"]);

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��ֹʱ��"] != DBNull.Value)
                    {
                        dtpEndTime.Value = Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��ֹʱ��"]);
                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�����ʼ��������"].ToString() == ">")
                    {
                        cboStart_condition.SelectedIndex = 0;

                    }
                    else
                    {
                        cboStart_condition.SelectedIndex = 1;

                    }
                    if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��ν�ֹ��������"].ToString() == "<")
                    {
                        cboEnd_condition.SelectedIndex = 0;

                    }
                    else
                    {
                        cboEnd_condition.SelectedIndex = 1;

                    }

                    int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к� 
                    if (rows > 0)
                    {
                        if (Rowcount == rows)
                        {
                            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                        }
                        else
                        {
                            //�������ͷ��
                            if (rows > 0)
                            {
                                //�͸ı䱳��ɫ
                                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                            }
                            if (Rowcount > 0 && ds.Tables[0].Rows.Count >= Rowcount)
                            {
                                //������һ�ε�������л�ԭ
                                this.ucC1FlexGrid1.fg.Rows[Rowcount].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                            }
                        }
                    }
                    //����һ�ε��кŸ�ֵ
                    Rowcount = rows;

                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }
         /// <summary>
        /// ˢ�±��
        /// </summary>
        private void refurbish()
        {
            txtName.Text = "";
            txtName.Enabled = false;
            dtpStartTime.Enabled = false;
            dtpEndTime.Enabled = false;
            cboStart_condition.Enabled = false;
            cboEnd_condition.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            //groupBox1.Enabled = true;
        }

        /// <summary>
        /// ɾ����ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (App.Ask("���Ƿ�Ҫɾ��"))
            {
                App.ExecuteSQL("delete from T_TAKE_OVER_SEQ where  ID=" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��α��"].ToString() + "");
            }
            //����ˢ��
            ShowValue();
            refurbish();
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnLookup_Click(object sender, EventArgs e)
        {
            try
            {
                btnLookup.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                string SQl = Take_over_SEQ + " order by ID asc ";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }
                //���������
                if (chkName.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {

                        SQl = Take_over_SEQ + " where SEQ like'%" + txtBox.Text.Trim() + "%' order by ID asc";
                        this.Cursor = Cursors.Default;
                    }

                }
                ucC1FlexGrid1.DataBd(SQl, "��α��",false, "", "");
                ucC1FlexGrid1.fg.Cols["��α��"].Visible = false;
                ucC1FlexGrid1.fg.Cols["��α��"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnLookup.Enabled = true;
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpStartTime.Focus();
            }

        }

        private void dtpStartTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboStart_condition.Focus();
            }

        }

        private void cboStart_condition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpEndTime.Focus();
            }

        }

        private void dtpEndTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboEnd_condition.Focus();
            }

        }

        private void cboEnd_condition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender,e);
            }

        }




    
    }
}