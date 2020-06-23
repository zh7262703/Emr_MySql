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
    public partial class ucSub_HospitalInfo : UserControl
    {
        bool isSave = false;               //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID = "";            //��ԺID
        private string Sub_Hospital;       //��Ժ��ѯ
        private string sub_hospital_code; //��ǰѡ�еķ�Ժ���
        private string sub_hospital_name; //��ǰѡ�еķ�Ժ����
        DataSet ds;
        public ucSub_HospitalInfo()
        {
            InitializeComponent();
            Sub_Hospital = "select SHID as ���,SUB_HOSPITAL_CODE as ��Ժ���,SUB_HOSPITAL_NAME as ��Ժ���� from T_SUB_HOSPITALINFO";
        }

 
        private void frmSub_HospitalInfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("��Ժ��Ϣ");
            //��ʾ�б�����
            ShowValue();
           // ucC1FlexGrid1.DataBd(SQL, "SHID", "SHID,SUB_HOSPITAL_CODE,SUB_HOSPITAL_NAME", "���,��Ժ����,��Ժ����");
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            RefleshFrm();
        }
        private void ShowValue()
        {
            string SQL = Sub_Hospital + " order by SHID desc";
            ds = App.GetDataSet(SQL);
            if (ds != null)
            {

                //   ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                ucGridviewX1.DataBd(SQL, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }

        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
            txtName.Enabled = false;
            txtNumber.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel1.Enabled = true;
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
                txtName.Text = "";
                txtNumber.Text = "";
            }
            txtName.Enabled = true;
            txtNumber.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel1.Enabled = false;
            txtNumber.Focus();
        }
        /// <summary>
        /// ���ˢ��
        /// </summary>
        private void refurbish()
        {
            txtName.Text = "";
            txtNumber.Text = "";
            txtName.Enabled = false;
            txtNumber.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            //groupBox2.Enabled = true;
            groupPanel1.Enabled = true;
            isSave = false;
        }
        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_SUB_HOSPITALINFO where SUB_HOSPITAL_CODE='" + id + "'");
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
        private bool isExisitNames(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_SUB_HOSPITALINFO where SUB_HOSPITAL_NAME='" + name + "'");
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
            txtNumber.Enabled = false;
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
                    App.Msg("�����Ų���Ϊ�գ�");
                    txtNumber.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("��Ժ���Ʋ���Ϊ�գ�");
                    txtName.Focus();
                    return;
                }
                string sql = "";
                ID = App.GenId("T_SUB_HOSPITALINFO", "SHID").ToString();
                if (isSave)
                {
                    if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�ķ�Ժ����ˣ�");
                        txtName.Focus();
                        return;
                    }
                    else if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�ķ�Ժ�����ˣ�");
                        txtName.Focus();
                        return;
                    }
               
                    sql = "insert into T_SUB_HOSPITALINFO(SHID,SUB_HOSPITAL_CODE,SUB_HOSPITAL_NAME) values("
                           + ID + ",'" + txtNumber.Text + "','" +txtName.Text +"') ";
                    btnAdd_Click(sender, e);
                }
                else
                {
                    if (sub_hospital_code.Trim() != "")
                    {
                        if (txtNumber.Text.Trim() != sub_hospital_code.Trim())
                        {
                             if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�ķ�Ժ����ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    else if(sub_hospital_name.Trim()!="")
                    {
                        if (txtName.Text.Trim() != sub_hospital_name.Trim())
                        {
                           if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�ķ�Ժ�����ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_SUB_HOSPITALINFO set SUB_HOSPITAL_CODE='"
                          + txtNumber.Text + "',SUB_HOSPITAL_NAME='"
                          + App.ToDBC(txtName.Text) + "' where SHID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";
                    btnUpdate_Click(sender, e);
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
                if (ucGridviewX1.fg.Rows.Count>0)
                {
                    ID = ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["��Ժ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    sub_hospital_code = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["��Ժ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    sub_hospital_name = txtName.Text;
                    //int rows = this.ucGridviewX1.fg.RowSel;//����ѡ�е��к� 
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
                btnSave_Click(sender, e);
            }

        }


  
    }
}