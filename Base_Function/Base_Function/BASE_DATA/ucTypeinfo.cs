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
    public partial class ucTypeinfo : UserControl
    {
        bool isSave = false;      //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID = "";   //����ID
        private string Type_SQl;  //������Ϣ��ѯ
        private string type;      //��ǰѡ�е����ͱ��
        private string name;      //��ǰѡ�е���������
        DataSet ds;
        public ucTypeinfo()
        {
            InitializeComponent();
            Type_SQl = "select * from T_DATA_CODE_TYPE order by ID desc";
        }
        private void frmTypeinfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("������Ϣ");
            // ˢ�±��
            ShowU();
            //string SQL = Type_SQl;
            //ucC1FlexGrid1.DataBd(SQL, "ID", "ID,Name,Type", "���,��������,������");
            //DataSet ds = App.GetDataSet("select *from T_DATA_CODE_TYPE order by ID asc");
            //App.reFleshFlexGrid(ds, ref c1FlexGrid1, "ID,Name,Type", "���,��������,������");
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            RefleshFrm();
        }
       /// <summary>
       /// ˢ�±��
       /// </summary>
        private void ShowU()
        {
            string SQL = Type_SQl;
            ds = App.GetDataSet(SQL);
            if (ds != null)
            {
                ucGridviewX1.DataBd(SQL, "ID", false, "ID,Name,Type", "���,��������,���ͱ��");
                ucGridviewX1.fg.ReadOnly = true;
                this.ucGridviewX1.fg.RowsDefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#a8d4df");
                this.ucGridviewX1.fg.AutoResizeColumns();
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
                txtNumber.Text = "";
                txtName.Text = "";
               
            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
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
            txtNumber.Text = "";
            txtName.Text = "";
            txtName.Enabled = false;
            txtNumber.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel1.Enabled = true;
            //groupBox2.Enabled = true;
            isSave = false;
        }
        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE_TYPE where Type='" + id + "'");
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
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE_TYPE where Name='" + name + "'");
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
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("�������Ʋ���Ϊ�գ�");
                    txtName.Focus();
                    return;
                }
                if (txtNumber.Text.Trim() == "")
                {
                    App.Msg("���ͱ�Ų���Ϊ�գ�");
                    txtNumber.Focus();
                    return;
                }
                string sql = "";
                ID = App.GenId("T_DATA_CODE_TYPE", "ID").ToString();
                if (isSave)
                {
                    if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�����ͱ���ˣ�");
                        txtName.Focus();
                        return;
                    }
                    else if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�����������ˣ�");
                        txtName.Focus();
                        return;
                    }
                    sql = "insert into T_DATA_CODE_TYPE(ID,Name,Type) values("
                           + ID + ",'" + txtName.Text + "','" + txtNumber.Text + "') ";
                    btnAdd_Click(sender, e);
                }
                else
                {
                    if (type.Trim() != "")
                    {
                        if (txtNumber.Text.Trim() != type.Trim())
                        {
                           if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�����ͱ���ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    else if(name.Trim()!="")
                    {
                        if (txtName.Text.Trim() != name.Trim())
                        {
                           if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�����������ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_DATA_CODE_TYPE set Name='"
                          + App.ToDBC(txtName.Text) + "',Type='"
                          + txtNumber.Text + "' where ID=" + ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";
                    btnUpdate_Click(sender, e);
                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);
                    }
                // ˢ�±��
                ShowU();
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
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    ID = ucGridviewX1.fg["ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["Type", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    type = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["Name", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    name = txtName.Text;                    
                    //int rows = this.ucGridviewX1.fg.CurrentRow.Index;//����ѡ�е��к� 
                    //if (rows > 0)
                    //{
                    //    if (Rowcount == rows)
                    //    {
                    //        this.ucGridviewX1.fg.Rows[rows].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //    }
                    //    else
                    //    {
                    //        //�������ͷ��
                    //        if (rows > 0)
                    //        {
                    //            //�͸ı䱳��ɫ
                    //            this.ucGridviewX1.fg.Rows[rows].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#a8d4df");
                    //        }
                    //        if (Rowcount > 0 && ds.Tables[0].Rows.Count >= Rowcount)
                    //        {
                    //            //������һ�ε�������л�ԭ
                    //            this.ucGridviewX1.fg.Rows[Rowcount].DefaultCellStyle.BackColor = ucGridviewX1.fg.BackColor;
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