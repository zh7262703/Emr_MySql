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
    public partial class ucMinim : UserControl
    {
        bool isSave = false;              //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID = "";           //����Һ��ID
        private string Inout_amount_dict; //����Һ����Ϣ��ѯ
        private string item_code;         //��ǰѡ�е���Ŀ���
        private string item_name;         //��ǰѡ�е���Ŀ����
        private string display_seq;       //��ǰѡ�е���ʾ˳��
        DataSet ds;
        public ucMinim()
        {
            InitializeComponent();
            Inout_amount_dict = @"select a.ID as ���,ITEM_CODE as ��Ŀ���,ITEM_NAME as ��Ŀ����,ITEM_VALUE_TYPE as ��Ŀ���ͱ��,s.name as ��Ŀֵ����,ITEM_UNIT as ��Ŀ��λ,DISPLAY_SEQ as ��ʾ˳��," +
                                @"(case when AMOUNT_FLAG=0 then '����' else '������' end) as ���ܱ��," +
                                @"ITEM_TYPE as ��Ŀ������,b.name as ��Ŀ��������,ITEM_MODE as ��Ŀ��ʽ���,d.name as ��Ŀ��ʽ����," +
                                @"(case when DRAINAGE_ATTRIBUTE=0 then '��' else '��' end) as �������� from T_INOUT_AMOUNT_DICT a inner join T_DATA_CODE b on b.id=a.item_type inner join T_DATA_CODE s on a.item_value_type=s.id left join T_DATA_CODE d on a.ITEM_MODE=d.id";
       }

        private void frmMinim_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("����Һ����Ϣ");
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            Type();
            Item_Type();
            cboItem.SelectedIndex = 0;
            cboCollect.SelectedIndex = 0;
            RefleshFrm();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ���ͱ��"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ���ͱ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ������"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ��ʽ���"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ��ʽ���"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        //��ʾ�б�����
        private void ShowValue()
        {
            string SQl = Inout_amount_dict + " order by a.ID desc";
            ds = App.GetDataSet(SQl);
            if (ds != null)
            {
                ucGridviewX1.DataBd(SQl, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ���ͱ��"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ���ͱ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ������"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ��ʽ���"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ��ʽ���"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }

         

        }
        /// <summary>
        /// ����Ŀ����ֵ����
        /// </summary>
        private void Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='21'");
            cboType.DataSource = ds.Tables[0].DefaultView;
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "NAME";
        }
        /// <summary>
        /// ����Ŀ����
        /// </summary>
        private void Item_Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='25'");
            cboItem_type.DataSource = ds.Tables[0].DefaultView;
            cboItem_type.ValueMember = "ID";
            cboItem_type.DisplayMember = "NAME";
        }
        /// <summary>
        /// ����Ŀ��ʽ
        /// </summary>
        private void ItemMode()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='26'");
            cboMode.DataSource = ds.Tables[0].DefaultView;
            cboMode.ValueMember = "ID";
            cboMode.DisplayMember = "NAME";
        }
 
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
 
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboType.Enabled = false;
            txtUnit.Enabled = false;
            txtSequence.Enabled = false;
            cboCollect.Enabled = false;
            cboItem_type.Enabled = false;
            cboMode.Enabled = false;
            cboItem.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            isSave = false;

        }

        /// <summary>
        /// �༭״̬
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {

                txtNumber.Text = "";
                txtName.Text = "";
                cboType.Text = "";
                txtUnit.Text = "";
                txtSequence.Text = "";
            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            cboType.Enabled = true;
            txtUnit.Enabled = true;
            txtSequence.Enabled = true;
            cboCollect.Enabled = true;
            cboItem_type.Enabled = true;
            cboMode.Enabled = true;
            cboItem.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (cboItem_type.Text.ToString() == "��Һ��")
            {

                cboMode.Enabled = true;
                cboItem.Enabled = false;
                ItemMode();
                cboItem.SelectedIndex = 1;
            }
            else if (cboItem_type.Text.ToString() == "��Һ��")
            {

                cboMode.Enabled = false;
                cboItem.Enabled = true;
            }
            txtNumber.Focus();
        }

        /// <summary>
        /// �ж��Ƿ��������ID
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitID(string id)
        {

            DataSet ds = App.GetDataSet("select * from T_INOUT_AMOUNT_DICT where  ITEM_CODE='" + id + "'");
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
        /// �ж��Ƿ��������NAME
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string Name)
        {
            DataSet ds = App.GetDataSet("select * from T_INOUT_AMOUNT_DICT where ITEM_NAME='" + Name + "'");
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
        /// �ж��Ƿ����������ʾ˳��
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitIndex(string index)
        {
            DataSet ds = App.GetDataSet("select * from T_INOUT_AMOUNT_DICT where DISPLAY_SEQ='" + index + "'");
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
            isSave = true;
            Edit(isSave);
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            Edit(isSave);
        }
        //��֤���������0�ľ���ʾΪ��
        public string Valite(string str)
        {
            if (str == "0")
            {
                str = "";
            }
            return str;
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
                if (txtNumber.Text.Trim() == "")
                {
                    App.Msg("��Ŀ��Ų���Ϊ�գ�");
                    txtNumber.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("��Ŀ���Ʋ���Ϊ�գ�");
                    txtName.Focus();
                    return;
                }
                if (txtUnit.Text.Trim() == "")
                {
                    App.Msg("��Ŀ��λ����Ϊ��");
                    txtUnit.Focus();
                    return;
                }
                if (cboCollect.Text.Trim() == "")
                {
                    App.Msg("���ܱ�ǲ���Ϊ�գ�");
                    cboCollect.Focus();
                    return;
                }
                int a;
                if (txtSequence.Text.Trim() != "")
                {
                    if (!int.TryParse(txtSequence.Text.Trim(), out a))
                    {
                        App.Msg("��ʾ˳��ֻ����д����");
                        txtSequence.Focus();
                        return;
                    }
                }
                string sql = "";
                string bid = "0";
                if (cboItem_type.SelectedIndex.ToString() == "��Һ��")
                {
                   bid =cboMode.SelectedValue.ToString();

                }
                ID = App.GenId("T_INOUT_AMOUNT_DICT ", "ID").ToString();
                if (isSave)
                {
                    if (isExisitID(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���Ƶ���Ŀ����ˣ�");
                        txtNumber.Focus();
                        return;
                    }
                    else if (isExisitName(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���Ƶ���Ŀ�����ˣ�");
                        txtName.Focus();
                        return;
                    }
                    else if (isExisitIndex(App.ToDBC(txtSequence.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���Ƶ���ʾ˳���ˣ�");
                        txtSequence.Focus();
                        return;
                    }
                
                    sql = "insert into T_INOUT_AMOUNT_DICT(ID,ITEM_CODE,ITEM_NAME,ITEM_VALUE_TYPE,ITEM_UNIT,DISPLAY_SEQ,AMOUNT_FLAG,ITEM_TYPE,ITEM_MODE,DRAINAGE_ATTRIBUTE) values('"
                         + ID + "','"
                         + App.ToDBC(txtNumber.Text) + "','"
                         + App.ToDBC(txtName.Text) + "','"
                         + cboType.SelectedValue + "','"
                         +txtUnit.Text + "','"
                         + txtSequence.Text + "','"
                         + cboCollect.SelectedIndex.ToString() + "','"
                         + cboItem_type.SelectedValue + "',"
                         +bid + ",'"
                         +cboItem.SelectedIndex.ToString()+"')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (item_code.Trim() != "")
                    {
                        if (txtNumber.Text.Trim() != item_code.Trim())
                        {
                             if (isExisitID(App.ToDBC(txtNumber.Text.Trim())))
                                {
                                    App.Msg("�Ѿ���������ͬ���Ƶ���Ŀ����ˣ�");
                                    txtNumber.Focus();
                                    return;
                                }
                        }
                    }
                    else if (item_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != item_name.Trim())
                        {
                             if (isExisitName(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ���Ƶ���Ŀ�����ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    else if (display_seq.Trim() != "")
                    {
                        if (txtSequence.Text.Trim() != display_seq.Trim())
                        {
                            if (isExisitIndex(App.ToDBC(txtSequence.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ���Ƶ���ʾ˳���ˣ�");
                                txtSequence.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_INOUT_AMOUNT_DICT set ITEM_CODE='"
                              + App.ToDBC(txtNumber.Text) + "',ITEM_NAME='"
                              + App.ToDBC(txtName.Text) + "',ITEM_VALUE_TYPE='"
                              + cboType.SelectedValue + "',ITEM_UNIT='"
                              + txtUnit.Text + "',DISPLAY_SEQ='"
                              + txtSequence.Text + "',AMOUNT_FLAG='"
                              + cboCollect.SelectedIndex.ToString() + "',ITEM_TYPE='"
                              + cboItem_type.SelectedValue + "',ITEM_MODE="
                              +bid + ",DRAINAGE_ATTRIBUTE='"
                              + cboItem.SelectedIndex.ToString() + "' where ID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.Rows.Count].Value.ToString() + "'";

                }
                
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);
                    }
                //��ʾ�б�����
                ShowValue();
                //string SQl = Inout_amount_dict;
               // ucC1FlexGrid1.DataBd(SQl, "ID", "ID,ITEM_CODE,ITEM_NAME,ITEM_VALUE_TYPE,VALUE_TYPE,ITEM_UNIT,DISPLAY_SEQ,AMOUNT_FLAG,ITEM_TYPE,ITEM_TYPE_NAME,ITEM_MODE,ITEM_MODE_NAME,DRAINAGE_ATTRIBUTE", "���,��Ŀ���,��Ŀ����,��Ŀֵ���,��Ŀֵ����,��Ŀ��λ,��ʾ˳��,���ܱ��,��Ŀ������,��Ŀ��������,��Ŀ��ʽ���,��Ŀ��ʽ����,��������");
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

        private void cboItem_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboItem_type.Text.ToString() == "��Һ��")
            {
               
                cboMode.Enabled = true;
                cboItem.Enabled = false;
                ItemMode();
                cboItem.SelectedIndex = 1;
            }
            else if (cboItem_type.Text.ToString() == "��Һ��")
            {

                cboMode.Enabled = false;
                cboItem.Enabled = true;
            }
           
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }
             /// <summary>
        /// ˢ�±��
        /// </summary>
        private void refurbish()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            cboType.Text = "";
            txtUnit.Text = "";
            txtSequence.Text = "";
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboType.Enabled = false;
            txtUnit.Enabled = false;
            txtSequence.Enabled = false;
            cboCollect.Enabled = false;
            cboItem_type.Enabled = false;
            cboMode.Enabled = false;
            cboItem.Enabled = false;
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
                App.ExecuteSQL("delete  from T_INOUT_AMOUNT_DICT where  ID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            //��ʾ�б�����
            ShowValue();
            refurbish();
            
        }
        int Rowcount = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    ID = ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["��Ŀ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    item_code = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["��Ŀ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    item_name = txtName.Text;
                    cboType.Text = ucGridviewX1.fg["��Ŀ���ͱ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtUnit.Text = ucGridviewX1.fg["��Ŀ��λ", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtSequence.Text = ucGridviewX1.fg["��ʾ˳��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    display_seq = txtSequence.Text;
                    if (ucGridviewX1.fg["���ܱ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "����")
                    {
                        cboCollect.SelectedIndex = 0;
                    }
                    else
                    {
                        cboCollect.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["��Ŀ������", ucGridviewX1.fg.CurrentRow.Index].Value != "")
                    {
                        cboItem_type.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["��Ŀ������", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["��Ŀ��ʽ���", ucGridviewX1.fg.CurrentRow.Index].Value != "")
                    {
                        cboMode.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["��Ŀ��ʽ���", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                    {
                        cboCollect.SelectedIndex = 0;
                    }
                    else
                    {
                        cboCollect.SelectedIndex = 1;
                    }

                    //int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к� 
                    //if (rows > 0)
                    //{
                    //    if (Rowcount == rows)
                    //    {
                    //        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //    }
                    //    else
                    //    {
                    //        //�������ͷ��
                    //        if (rows > 0)
                    //        {
                    //            //�͸ı䱳��ɫ
                    //            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //        }
                    //        if (Rowcount > 0 && ds.Tables[0].Rows.Count >= Rowcount)
                    //        {
                    //            //������һ�ε�������л�ԭ
                    //            this.ucC1FlexGrid1.fg.Rows[Rowcount].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    //        }
                    //    }
                    //}
                    ////����һ�ε��кŸ�ֵ
                    //Rowcount = rows;
                }
                RefleshFrm();
            }
            catch
            {
            }
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
                string SQl = Inout_amount_dict + " order by a.ID desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }
                //����Ŀ��Ž��в�ѯ
                if (chkID.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inout_amount_dict + " where  ITEM_CODE ��like'%" + txtBox.Text.Trim() + "%' order by a.ID desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                 //����Ŀ���ƽ��в�ѯ
                else if (chkName.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inout_amount_dict + " where   ITEM_NAME��like'%" + txtBox.Text.Trim() + "%' order by a.ID desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                ucGridviewX1.DataBd(SQl, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ���ͱ��"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ���ͱ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ������"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ��ʽ���"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ��ʽ���"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
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
        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboType.Focus();
            }

        }

        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUnit.Focus();
            }

        }


        private void txtUnit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSequence.Focus();
            }

        }

        private void txtSequence_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCollect.Focus();
            }

        }

        private void cboCollect_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboItem_type.Focus();
            }

        }
        private void cboItem_type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboMode.Focus();
            }

        }
        private void cboMode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboItem.Focus();
            }

        }
        private void cboItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void chkID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkID.Checked == true)
            {
                chkName.Checked = false;
            }
            else
            {
                chkName.Checked = true;
                txtBox.Text = "";
            }
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked == true)
            {
                chkID.Checked = false;
            }
            else
            {
                chkID.Checked = true;
                txtBox.Text = "";
            }
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }
   






   


    }
}