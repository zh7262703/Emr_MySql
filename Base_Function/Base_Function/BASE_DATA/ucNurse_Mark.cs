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
    public partial class ucNurse_Mark : UserControl
    {
        bool isSave = false;                  //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID = "";              //������ID
        private string T_NURSE_RECORD_DICT; //��������Ϣ��ѯ
        private string item_code;           //��ǰѡ�е���Ŀ���
        private string item_name;          //��ǰѡ�е���Ŀ����
        private string display_index;     //��ǰѡ�е���ʾ˳��
        DataSet ds;
        public ucNurse_Mark()
        {
            InitializeComponent();
            T_NURSE_RECORD_DICT = @"select a.ID as ���,ITEM_CODE as ��Ŀ���,ITEM_NAME as ��Ŀ����,ITEM_VALUE_KIND as ��Ŀֵ���ͱ��,t.name as ��Ŀֵ����," +
                                @"ITEM_UNIT as ��Ŀ��λ,DISPLAY_INDEX as ��ʾ˳��,(case when HAS_SUM=0 then '������' else '����' end) as ���ܱ��," +
                                @"ITEM_TYPE as ��Ŀ�����,b.name as ��Ŀ�������,ITEM_ATTRIBUTE as ��Ŀ���Ա��,d.name as ��Ŀ����   from T_NURSE_RECORD_DICT a inner join T_DATA_CODE b on b.id=a.item_type left join T_DATA_CODE d on a.item_attribute=d.id left join T_DATA_CODE t on a.item_value_kind=t.id";
        }
        private void frmNurse_Mark_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("��������Ϣ");
            //��ʾ�б�����
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);          
            cboCollect.SelectedIndex = 0;
            ucGridviewX1.fg.AllowUserToAddRows = false;
            Type();
            Item_Type();
            RefleshFrm();

        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀֵ���ͱ��"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀֵ���ͱ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ�����"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ�����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ���Ա��"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ���Ա��"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        //��ʾ�б�����
        private void ShowValue()
        {
            string SQl = T_NURSE_RECORD_DICT + " order by a.ID desc";
            ds = App.GetDataSet(SQl);
            if (ds != null)
            {

                //    ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                ucGridviewX1.DataBd(SQl, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀֵ���ͱ��"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀֵ���ͱ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ�����"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ�����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ���Ա��"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ���Ա��"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }

        }
        //����Ŀ����ֵ����
        private void Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='21'");
            cboType.DataSource = ds.Tables[0].DefaultView;
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "NAME";
        }
        //����Ŀ�������
        private void Item_Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='20'");
            cboItem_type.DataSource = ds.Tables[0].DefaultView;
            cboItem_type.ValueMember = "ID";
            cboItem_type.DisplayMember = "NAME";
        }
        //����Ŀ��������
        private void Item()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='23'");
            cboItem.DataSource = ds.Tables[0].DefaultView;
            cboItem.ValueMember = "ID";
            cboItem.DisplayMember = "NAME";
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
            cboItem.Enabled = false;
            chkItem.Enabled = false;
            chkItem.Checked = false;
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
            cboItem.Enabled = true;
            chkItem.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (chkItem.Checked == true)
            {
                cboItem.Enabled = true;
                Item();
            }
            else
            {
                cboItem.Enabled = false;
            }
            txtNumber.Focus();
        }
        /// <summary>
        /// �ж��Ƿ��������ID
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExisitID(string id)
        {

            DataSet ds = App.GetDataSet("select * from T_NURSE_RECORD_DICT where  ITEM_CODE='" + id + "'");
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
        private bool isExisitName(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_NURSE_RECORD_DICT where ITEM_NAME='" + name + "' and  ITEM_TYPE='"+ cboItem_type.SelectedValue + "'");
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
        private bool isExisitIndex(string  index)
        {
            DataSet ds = App.GetDataSet("select * from T_NURSE_RECORD_DICT where DISPLAY_INDEX='" + index + "'");
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
                string atrribut="0";
                if (chkItem.Checked)
                {
                    atrribut = cboItem.SelectedValue.ToString();
                }
                ID = App.GenId("T_NURSE_RECORD_DICT ", "ID").ToString();
                if (isSave)
                {
                    if (isExisitID(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���Ƶ���Ŀ����ˣ�");
                        txtNumber.Focus();
                        return;
                    }
                    else if(isExisitName(App.ToDBC(txtName.Text.Trim())))
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

                    sql = "insert into T_NURSE_RECORD_DICT(ID,ITEM_CODE,ITEM_NAME,ITEM_VALUE_KIND,ITEM_UNIT,DISPLAY_INDEX,HAS_SUM,ITEM_TYPE,ITEM_ATTRIBUTE) values('"
                         + ID + "','"
                         +App.ToDBC(txtNumber.Text)+ "','"
                         +App.ToDBC(txtName.Text)+ "','"
                         + cboType.SelectedValue+ "','"
                         + txtUnit.Text + "','"
                         + txtSequence.Text + "','"
                         + cboCollect.SelectedIndex.ToString()+ "','"
                         +cboItem_type.SelectedValue+"',"
                         + atrribut + ")";
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
                             if(isExisitName(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ���Ƶ���Ŀ�����ˣ�");
                                 txtName.Focus();
                                 return;  
                            }
                        }
                    }
                    else if (display_index.Trim() != "")
                    {
                        if(txtSequence.Text.Trim()!=display_index.Trim())
                        {
                           if (isExisitIndex(App.ToDBC(txtSequence.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ���Ƶ���ʾ˳���ˣ�");
                                txtSequence.Focus();
                                return;  
                            }
                        }
                    }
                    sql = "update T_NURSE_RECORD_DICT set ITEM_CODE='"
                              + App.ToDBC(txtNumber.Text) + "',ITEM_NAME='"
                              +App.ToDBC(txtName.Text) + "',ITEM_VALUE_KIND='"
                              + cboType.SelectedValue + "',ITEM_UNIT='"
                              + txtUnit.Text + "',DISPLAY_INDEX='"
                              + txtSequence.Text + "',HAS_SUM='"
                              + cboCollect.SelectedIndex.ToString() + "',ITEM_TYPE='"
                              + cboItem_type.SelectedValue + "',ITEM_ATTRIBUTE="
                              + atrribut + " where ID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";

                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);
                       
                    }
                //��ʾ�б�����
                ShowValue();
                //string SQl = T_NURSE_RECORD_DICT;
                //ucC1FlexGrid1.DataBd(SQl, "ID", "ID,ITEM_CODE,ITEM_NAME,ITEM_VALUE_KIND,ITEM_UNIT,DISPLAY_INDEX,HAS_SUM,ITEM_TYPE,ITEM_TYPE_NAME,ITEM_ATTRIBUTE,ITEM_ATTRIBUTE_NAME", "���,��Ŀ���,��Ŀ����,��Ŀֵ����,��Ŀ��λ,��ʾ˳��,���ܱ��,��Ŀ�����,��Ŀ�������,��Ŀ���Ա��,��Ŀ����");
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
                if (ucGridviewX1.fg.RowCount >0)
                {
                    ID = ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["��Ŀ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    item_code = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["��Ŀ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    item_name = txtName.Text;
                    cboType.Text = ucGridviewX1.fg["��Ŀֵ���ͱ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtUnit.Text = ucGridviewX1.fg["��Ŀ��λ", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtSequence.Text = ucGridviewX1.fg["��ʾ˳��",ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    display_index = txtSequence.Text;
                    if (ucGridviewX1.fg["���ܱ��",ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "������")
                    {
                        cboCollect.SelectedIndex = 0;
                    }
                    else
                    {
                        cboCollect.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["��Ŀ�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboItem_type.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["��Ŀ�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    if (ucGridviewX1.fg["��Ŀ���Ա��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        if (chkItem.Checked == true)
                        {
                            cboItem.Enabled = false;
                        }
                        cboItem.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["��Ŀ���Ա��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());
                    }                  

                }
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
                string SQl = T_NURSE_RECORD_DICT + " order by a.ID desc";
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
                        SQl = T_NURSE_RECORD_DICT + " where  ITEM_CODE ��like'%" + txtBox.Text.Trim() + "%' order by a.ID desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                //����Ŀ���ƽ��в�ѯ
                else if (chkName.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_NURSE_RECORD_DICT + " where   ITEM_NAME��like'%" + txtBox.Text.Trim() + "%' order by a.ID desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                ucGridviewX1.DataBd(SQl, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀֵ���ͱ��"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀֵ���ͱ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ�����"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ�����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ŀ���Ա��"].Visible = false;
                ucGridviewX1.fg.Columns["��Ŀ���Ա��"].ReadOnly = true;
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
            txtNumber.Text = "";
            txtName.Text = "";
            cboType.Text = "";
            txtUnit.Text = "";
            txtSequence.Text = "";
            cboItem.Text = "";
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboType.Enabled = false;
            txtUnit.Enabled = false;
            txtSequence.Enabled = false;
            cboCollect.Enabled = false;
            cboItem_type.Enabled = false;
            chkItem.Checked = false;
            cboItem.Enabled = false;
            chkItem.Enabled = false;
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
                App.ExecuteSQL("delete from T_NURSE_RECORD_DICT where  ID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            //��ʾ�б�����
            ShowValue();
            refurbish();

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
                chkItem.Focus();
            }
     
        }
        private void chkItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (chkItem.Checked == true)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cboItem.Focus();
                }

            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave_Click(sender, e);
                }
   
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
            if (chkID.Checked)
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
            if (chkName.Checked)
            {
                chkID.Checked = false;
            }
            else
            {
                chkID.Checked = true;
                txtBox.Text = "";
            }
        }

        private void chkItem_CheckedChanged(object sender, EventArgs e)
        {
            
            if (chkItem.Checked == true)
            {
                cboItem.Enabled = true;
                Item();
            }
            else
            {
                cboItem.Enabled = false;
            }
        }

        private void btnTB_Click(object sender, EventArgs e)
        {
            try
            {
                //�����
                //select distinct t.patient_id,t.measure_time,t.record_type from t_nurse_record t where t.record_type is not null;
                //ͳ�Ʊ�
                //select ts.id,ts.patient_id,ts.start_time,ts.end_time,ts.record_type from t_nurse_dangery_inout_sum_h ts
                
                //��ѯ���л�������Ϊ�յ�ͳ��
                DataSet ds_Sum = App.GetDataSet("select ts.id,ts.patient_id,ts.start_time,ts.end_time,tt.seq,ts.record_type from t_nurse_dangery_inout_sum_h ts left join T_TAKE_OVER_SEQ tt on ts.seq_id=tt.id  where ts.record_type is null order by id");
                List<string> Sqls = new List<string>();
                for (int i = 0; i < ds_Sum.Tables[0].Rows.Count; i++)
                {
                    string id = ds_Sum.Tables[0].Rows[i]["id"].ToString();
                    string patient_id = ds_Sum.Tables[0].Rows[i]["patient_id"].ToString();
                    string start_time = ds_Sum.Tables[0].Rows[i]["start_time"].ToString();
                    string end_time = ds_Sum.Tables[0].Rows[i]["end_time"].ToString();
                    //���ҳ����зǿ����͵Ļ����¼��
                    string beginSgin = ">=";
                    if (ds_Sum.Tables[0].Rows[i]["seq"] != null && ds_Sum.Tables[0].Rows[i]["seq"].ToString().Contains("�׶���"))
                    {
                        beginSgin = ">";
                    }
                    string sql_nType = "select distinct t.patient_id,t.measure_time,t.record_type from t_nurse_record t where t.record_type is not null and patient_id =" + patient_id + " and measure_time" + beginSgin + "to_timestamp('" + start_time + "','syyyy-mm-dd hh24:mi:ss.ff9') and measure_time<=to_timestamp('" + end_time + "','syyyy-mm-dd hh24:mi:ss.ff9') order by measure_time desc";
                    string nType = App.ReadSqlVal(sql_nType, 0, "record_type");// == null ? "" : App.ReadSqlVal(sql_nType, 0, "record_type");
                    if (nType != null && nType != "")
                    {
                        Sqls.Add("update t_nurse_dangery_inout_sum_h set record_type='" + nType + "' where id=" + id + "");
                    }
                    //DataSet ds_nType = App.GetDataSet(sql_nType);
                    //for (int j = 0; j < ds_nType.Tables[0].Rows.Count; j++)
                    //{//
                    //    string nType = ds_nType.Tables[0].Rows[j]["record_type"] == null ? "" : ds_nType.Tables[0].Rows[j]["record_type"].ToString();
                    //    if (nType != "")
                    //    {
                    //        Sqls.Add("update t_nurse_dangery_inout_sum_h set record_type='" + nType + "' where id=" + id + "");
                    //        break;
                    //    }
                    //}
                }
                if (App.ExecuteBatch(Sqls.ToArray()) > 0)
                {
                    App.Msg("ͬ���ɹ�!");
                }
                else
                {
                    App.Msg("ͬ��ʧ��!");
                }
            }
            catch (Exception ex)
            {
                string bug = ex.Message;
            }
        }
     

    }
}