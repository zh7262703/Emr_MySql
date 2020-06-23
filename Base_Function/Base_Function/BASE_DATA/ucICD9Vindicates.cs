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
    /// <summary>
    /// ICD9ά��
    /// </summary>
    /// ���� ��ΰ
    /// ʱ�� 2010��9��14��
    public partial class ucICD9Vindicates : UserControl
    {

        bool isDelectUpdate = false;
        string current_id = "";
        string current_name = "";
        string current_icd9code = "";

        public ucICD9Vindicates()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void SetflgViewData()
        {
            string sql = "select code as ICD9����,name as �����,shortcut1 as ƴ����,shortcut2 as �����,(code || name) as ICD9,QTXM as �������,FJBM as ��ϱ��� from oper_def_icd9";
             ds= App.GetDataSet(sql);
            if (ds != null)
            {
                this.ucGridviewX1.DataBd(sql, "ICD9����", "", "");
                ucGridviewX1.fg.ReadOnly = true;
            }

        }

        /// <summary>
        /// ��ʾָ�����Զ�������ICD9
        /// </summary>
        /// <param name="Icd9code"></param>
        private void ShowUserICD9Data(string Icd9code)
        {
            string sql = "select diag_id as ID ,NAME as ����,SHORTCUT1 as ƴ����,SHORTCUT2 as �����,IS_ICD9 as �Ƿ�ICD9������, ICD9 as ICD9������ from t_oper_def where ICD9='" + Icd9code + "'";

            //string sql = "select code as ICD10����,name as �����,shortcut1 as ƴ����,shortcut2 as �����,(code || name) as ICD10 from diag_def_icd10";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                this.ucGridviewX2.DataBd(sql, "ID", false, "", "");
                ucGridviewX2.fg.ReadOnly = true;
            }

        }

        private void frmICD10Vindicate_Load(object sender, EventArgs e)
        {
            txtICD9code.Enabled = false;
            txtICD9name.Enabled = false;
            this.btncancel.Enabled = false;
            this.btnconfirm.Enabled = false;
            txtBIAO.Enabled = false;
            txtZHEND.Enabled = false;
            SetflgViewData();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX2.fg.ContextMenuStrip = contextMenuStrip1;
            ucGridviewX2.fg.DoubleClick += new EventHandler(ucC1FlexGrid2_DoubleClick);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            ucGridviewX2.fg.AllowUserToAddRows = false;
        }
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count >0)
                {
                    txtICD9code.Enabled = false;
                    txtICD9name.Enabled = false;

                    this.txtICD9code.Text = ucGridviewX1.fg["ICD9����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtICD9name.Text = ucGridviewX1.fg["�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtspellCode.Text = ucGridviewX1.fg["ƴ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtfiveCode.Text = ucGridviewX1.fg["�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtBIAO.Text = ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtZHEND.Text = ucGridviewX1.fg["��ϱ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    ShowUserICD9Data(this.txtICD9code.Text);

                    //int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к� 
                    //if (rows > 0)
                    //{
                    //    if (oldRow == rows)
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
                    //        int count = ucC1FlexGrid1.fg.Rows.Count;
                    //        if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow)
                    //        {
                    //            if (oldRow < count - 1)
                    //            {
                    //                //������һ�ε�������л�ԭ
                    //                this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    //            }
                    //        }
                    //        //else
                    //        //{
                    //        //    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = c1FlexGrid1.BackColor;
                    //        //}
                    //    }
                    //}
                    ////����һ�ε��кŸ�ֵ
                    //oldRow = rows;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucGridviewX1.Enabled = false;
            isDelectUpdate = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            txtBIAO.Enabled = true;
            txtZHEND.Enabled = true;
            txtICD9code.Enabled = true;
            txtICD9name.Enabled = true;
            txtspellCode.Enabled = true;
            txtfiveCode.Enabled = true;
       
        }

        private void btnconfirm_Click(object sender, EventArgs e)
        {

            try
            {
                ucGridviewX1.Enabled = true;
              
                    if (this.txtICD9code.Text == "")
                    {
                        App.Msg("ICD9���벻��Ϊ��");
                        this.txtICD9code.Focus();
                        return;
                    }
                    if (this.txtICD9name.Text == "")
                    {
                        App.Msg("���Ʋ���Ϊ��");
                        this.txtICD9name.Focus();
                        return;
                    }
                    if (isDelectUpdate == true)
                    {
                        string innsetsql = "insert into oper_def_icd9(CODE,NAME,SHORTCUT1,SHORTCUT2,QTXM,FJBM) values('" + txtICD9code.Text + "','" + txtICD9name.Text + "','" + txtspellCode.Text + "','" + txtfiveCode.Text + "','" + txtBIAO.Text + "','" + txtZHEND.Text + "')";
                        int count = App.ExecuteSQL(innsetsql);
                        if (count > 0)
                        {
                            App.Msg("��ӳɹ���");
                            SetflgViewData();
                            btncancel_Click(sender,e);
                        }
                    }
                    else
                    {
                        string spellcode = App.getSpell(this.txtICD9name.Text);
                        string fivecode = App.GetWBcode(this.txtICD9name.Text);
                        string updatesql = "update oper_def_icd9 set name='" + this.txtICD9name.Text + "',shortcut1='" + spellcode + "',shortcut2='" + fivecode + "',QTXM='" + txtBIAO.Text + "',FJBM='" + txtZHEND.Text + "' where code='" + txtICD9code.Text + "'";
                        if (App.ExecuteSQL(updatesql) > 0)
                        {
                            App.Msg("�޸ĳɹ�");
                            SetflgViewData();
                            btncancel_Click(sender, e);
                        }
                    }
            }
            catch
            {
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtICD9code.Text == "" || this.txtICD9name.Text == "")
            {
                App.Msg("��û��Ҫ�޸ĵ���Ϣ");
                return;
            }
            isDelectUpdate = false;
            txtBIAO.Enabled = true;
            txtZHEND.Enabled = true;
            txtICD9code.Enabled = true;
            txtICD9name.Enabled = true;
            txtspellCode.Enabled = true;
            txtfiveCode.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btncancel.Enabled = true;
            this.btnconfirm.Enabled = true;
        }

        private void txtICD9name_TextChanged(object sender, EventArgs e)
        {
            string spellcode = App.getSpell(this.txtICD9name.Text);
            string fivecode = App.GetWBcode(this.txtICD9name.Text);
            this.txtspellCode.Text = spellcode;
            this.txtfiveCode.Text = fivecode;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.ucGridviewX1.Enabled = true;
            this.btnAdd.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;
            txtBIAO.Enabled = false;
            txtZHEND.Enabled = false;
            txtICD9code.Enabled = false;
            txtICD9name.Enabled = false;
            txtspellCode.Enabled = false;
            txtfiveCode.Enabled = false;
            txtICD9code.Text = "";
            txtICD9name.Text = "";
            txtspellCode.Text = "";
            txtfiveCode.Text = "";
            txtBIAO.Text = "";
            txtZHEND.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtICD9code.Text == "" || this.txtICD9name.Text == "")
                {
                    App.Msg("��ȷ����Ҫɾ������Ϣ");
                    return;
                }
                else
                {
                    string deletesql = "delete oper_def_icd9 where code='" + this.txtICD9code.Text + "'";

                    if (App.Ask("��ȷ��Ҫɾ����"))
                    {
                        if (App.ExecuteSQL(deletesql) > 0)
                        {
                            App.Msg("ɾ���ɹ���");
                            SetflgViewData();
                            btncancel_Click(sender, e);
                        }
                    }
                    
                }
            }
            catch
            {
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string icd9Name = this.txtVindicateName.Text;
            if (icd9Name == "")
            {
                SetflgViewData();
            }
            else
            {
                string sql = "select code as ICD9����,name as �����,shortcut1 as ƴ����,shortcut2 as �����,(code || name) as ICD9,QTXM as �������,FJBM as ��ϱ��� from oper_def_icd9 where name like '" + icd9Name + "%' or shortcut1 like '" + icd9Name + "%'";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    this.ucGridviewX1.DataBd(sql, "ICD9����", "", "");
                    ucGridviewX1.fg.ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// �Զ�������ά��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpmodify_Click(object sender, EventArgs e)
        {
            if (txtICD9code.Text.Trim() != "")
            {
                current_id = "";
                frmICD9Vindicate_ModiFy fc = new frmICD9Vindicate_ModiFy(current_name, current_id,txtICD9code.Text.Trim());
                App.FormStytleSet(fc, false);
                fc.ShowDialog();
                ShowUserICD9Data(txtICD9code.Text.Trim());
            }
            else
            {
                App.MsgWaring("����ѡ���׼ICD9��ϣ�");
            }
        }

        private void ɾ���Զ�������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucGridviewX2.fg.Rows.Count > 0)
            {
                if (App.Ask("ȷ��Ҫɾ�����������Զ����¼��"))
                {
                    if (App.ExecuteSQL("delete from t_oper_def where DIAG_ID=" + ucGridviewX2.fg["ID", ucGridviewX2.fg.CurrentRow.Index].Value.ToString() + "") > 0)
                    {
                        App.Msg("�����Ѿ��ɹ���");
                        ShowUserICD9Data(txtICD9code.Text);
                    }

                }
            }
            else
            {
                App.MsgErr("��ѡ��Ҫɾ���ļ�¼��");
            }
        }

        private void ucC1FlexGrid2_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX2.fg.Rows.Count >0)
                {
                    current_id = ucGridviewX2.fg["ID", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    current_name = ucGridviewX2.fg["����", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    current_icd9code = ucGridviewX2.fg["ICD9������", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    frmICD9Vindicate_ModiFy fc = new frmICD9Vindicate_ModiFy(current_name, current_id,current_icd9code);
                    App.FormStytleSet(fc, false);
                    fc.ShowDialog();
                    ShowUserICD9Data(current_icd9code);
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("��ѡ��Ҫ�޸ĵ����ݣ�" + ex.Message);
            }
        }


    
    }
}