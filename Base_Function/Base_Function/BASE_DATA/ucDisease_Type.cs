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
    public partial class ucDisease_Type : UserControl
    {
       private bool IsSave = false;��//���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
       private string ID = "";    //��ȡ��ǰ��ID
        private string T_sick_type_sql;
        private string t_sick_code;
        private string t_sick_name;
        public ucDisease_Type()
        {
            InitializeComponent();
            T_sick_type_sql = "select s.ID as ���,SICK_CODE as ����,SICK_NAME as ����,SICK_SYSTEM as ��������Ŀ¼���,t.name as ��������Ŀ¼ from T_SICK_TYPE s " +
                             @"inner join t_data_code t on t.id=s.sick_system ";
        }

        private void frmDisease_Type_Load(object sender, EventArgs e)
        {
            //��ʾ�б�����
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = true;
            //�󶨲�������Ŀ¼
            Property();
            RefleshFrm();

        }
        private void frmDisease_Type_Activated(object sender, EventArgs e)
        {
            Property();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        DataSet ds;
        //��ʾ�б�����
        private void ShowValue()
        {
            string Sql = T_sick_type_sql + "  order by s.ID desc";
            ds = App.GetDataSet(Sql);
            if (ds != null)
            {
                ucGridviewX1.DataBd(Sql, "���", false, "", "");

                //ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                //ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                ucGridviewX1.fg.ReadOnly = true;
            }
        }
        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool IsCode(string code)
        {
            DataSet ds = App.GetDataSet("select * from t_sick_type  where sick_system='"+cboDisease_type.SelectedValue+"' and  sick_code='"+code+"'");
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
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool Isnames(string name)
        {
            DataSet ds = App.GetDataSet("select * from t_sick_type  where sick_system='"+cboDisease_type.SelectedValue+"' and  sick_name='"+name+"'");
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
        //�󶨲�������Ŀ¼
        private void Property()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='16' order by ID asc");
            cboDisease_type.DataSource = ds.Tables[0].DefaultView;
            cboDisease_type.ValueMember = "ID";
            cboDisease_type.DisplayMember = "NAME";
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {

            cboDisease_type.Enabled = false;
            txtCode.Enabled = false;
            txtName.Enabled = false;
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
                txtCode.Text = "";
                txtName.Text = "";
            }

            cboDisease_type.Enabled = true;
            txtCode.Enabled = true;
            txtName.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;

            txtCode.Focus();
        }
        /// ˢ�±��
        /// </summary>
        private void refurbish()
        {
            txtCode.Text = "";
            txtName.Text = "";
            cboDisease_type.Enabled = false;
            txtCode.Enabled = false;
            txtName.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            //groupBox1.Enabled = true;
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsSave = true;
            Edit(IsSave);
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsSave = false;
            Edit(IsSave);
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text.Trim()=="")
                {
                    App.Msg("���������д��");
                    txtCode.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("�������Ʊ�����д��");
                    txtName.Focus();
                    return;
                }
                string sql = "";
                if (IsSave)
                {
                    if (IsCode(App.ToDBC(txtCode.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�Ĵ����ˣ�");
                        txtCode.Focus();
                        return;
                    }
                    else if (Isnames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�Ĳ��������ˣ�");
                        txtName.Focus();
                        return;
                    }
                    sql = "insert into t_sick_type(SICK_CODE,SICK_NAME,SICK_SYSTEM) values('" + txtCode.Text + "','" + txtName.Text + "','" + cboDisease_type.SelectedValue + "')";
                }
                else
                {
                    if (t_sick_code.Trim() != "")
                    {
                        if (txtCode.Text.Trim() != t_sick_code.Trim())
                        {
                            if (IsCode(App.ToDBC(txtCode.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�Ŀ��ұ���ˣ�");
                                txtCode.Focus();
                                return;
                            }
                        }
                    }
                    else if (t_sick_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != t_sick_name.Trim())
                        {
                            if (Isnames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�Ŀ��������ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update  t_sick_type set SICK_CODE='" + txtCode.Text + "',SICK_NAME='" + txtName.Text + "',SICK_SYSTEM='" + cboDisease_type.SelectedValue + "' where ID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);
                    }
                //��ʾ�б�����
                ShowValue();
            }
            catch
            {
            }
        }
        int Rowcount = 0;
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    ID = ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtCode.Text = ucGridviewX1.fg["����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    t_sick_code = txtCode.Text;
                    txtName.Text = ucGridviewX1.fg["����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    t_sick_name = txtName.Text;
                    if (ucGridviewX1.fg["��������Ŀ¼���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboDisease_type.SelectedValue = ucGridviewX1.fg["��������Ŀ¼���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
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
            }
            catch
            {
            }
        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            refurbish();
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (App.Ask("���Ƿ�Ҫɾ��"))
            {
                App.ExecuteSQL("delete from t_sick_type where  ID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            //��ʾ�б�����
            ShowValue();
            refurbish();
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelect.Enabled = false;
                this.Cursor = Cursors.WaitCursor;

                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }
                string Sql = T_sick_type_sql + " order by s.ID desc";
                if (txtBox.Text.Trim() != "")
                {


                    Sql = T_sick_type_sql + " where  SICK_NAME��like'%" + txtBox.Text.Trim() + "%' order by s.ID desc";

                }
                ucGridviewX1.DataBd(Sql, "���", false, "", "");
                ucGridviewX1.fg.ReadOnly = true;
                ucGridviewX1.fg.AutoResizeColumns();
            }
            catch
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnSelect.Enabled = true;
            }
        }

        private void cboDisease_type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCode.Focus();
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
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
                btnSave_Click(sender,e);
            }
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }


 
   

  

   

     

    
    }
}