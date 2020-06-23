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
    /// ICD10ά��
    /// </summary>
    /// ���� ��ΰ
    /// ʱ�� 2010��9��14��
    public partial class ucICD10Vindicate :UserControl
    {

        bool isDelectUpdate = false;                //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���

        string current_id = "";
        string current_name = "";
        string current_icd10code = "";
        string current_iszy = "";
        string current_isicd10 = "";

        public ucICD10Vindicate()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void SetflgViewData()
        {
            string sql = "select code as ICD10����,name as �����,shortcut1 as ƴ����,shortcut2 as �����,(code || name) as ICD10,QTXM as �������,FJBM as ��ϱ��� from diag_def_icd10";
             ds= App.GetDataSet(sql);
            if (ds != null)
            {               
                this.ucGridviewX1.DataBd(sql, "ICD10����", "", "");
                ucGridviewX1.fg.ReadOnly = true;
            }

        }

        /// <summary>
        /// ��ʾ�Զ������
        /// </summary>
        private void ShowSelfDigs(string icd10code)
        {
            try
            {
                string sql = "select DIAG_ID as ����, NAME as ����, CATEGORY_ID as Ŀ¼ID, IS_CHN as �Ƿ���ҽ���, SHORTCUT1 as ƴ����, SHORTCUT2 as �����, IS_ICD10 as �Ƿ�ICD10�����, ICD10_ID as ICD10�����  from T_DIAG_DEF where ICD10_ID='" + icd10code + "'";
                this.ucGridviewX2.DataBd(sql, "����", false, "", "");
                ucGridviewX2.fg.ReadOnly = true;

            }
            catch
            { }
        }

        private void frmICD10Vindicate_Load(object sender, EventArgs e)
        {
            txtICD10code.Enabled = false;
            txtICD10name.Enabled = false;
            txtspellCode.Enabled = false;
            txtfiveCode.Enabled = false;
            txtBIAO.Enabled = false;
            txtZHEND.Enabled = false;
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;            

            SetflgViewData();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX2.fg.DoubleClick += new EventHandler(ucC1FlexGrid2_DoubleClick);
            ucGridviewX2.fg.ContextMenuStrip = contextMenuStrip1;
            ucGridviewX1.fg.AllowUserToAddRows = false;
            ucGridviewX2.fg.AllowUserToAddRows = false;
        }
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count>0)
                {
                    txtICD10code.Enabled = false;
                    txtICD10name.Enabled = false;
                    txtspellCode.Enabled = false;
                    txtfiveCode.Enabled = false;

                    this.txtICD10code.Text = ucGridviewX1.fg["ICD10����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtICD10name.Text = ucGridviewX1.fg["�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtspellCode.Text = ucGridviewX1.fg["ƴ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtfiveCode.Text = ucGridviewX1.fg["�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtBIAO.Text = ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtZHEND.Text = ucGridviewX1.fg["��ϱ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    ShowSelfDigs(this.txtICD10code.Text);

                   // int rows = this.ucGridviewX1.fg.RowSel;//����ѡ�е��к� 
                   // if (rows > 0)
                   // {
                   //     if (oldRow == rows)
                   //     {
                   //         this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                   //     }
                   //     else
                   //     {
                   //         //this.ucC1FlexGrid1.fg.BackColor= ucC1FlexGrid1.fg.BackColor;
                   //         //�������ͷ��
                   //         if (rows > 0)
                   //         {
                   //             //�͸ı䱳��ɫ
                   //             this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                   //         }
                   //         int t = ucC1FlexGrid1.fg.Rows.Count;
                   //         if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow) //
                   //         {
                   //             if (oldRow < t)
                   //             {
                                   

                   //                 //������һ�ε�������л�ԭ
                   //                 //this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                   //                 this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                   //             }

                   //         }
                   //         //else
                   //         //{
                   //         //    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = c1FlexGrid1.BackColor;
                   //         //}
                   //     }
                   // }
                   // //����һ�ε��кŸ�ֵ
                   //oldRow = rows;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }


        private void ucC1FlexGrid2_Click(object sender, EventArgs e)
        {
            
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            ucGridviewX1.Enabled = false;
            isDelectUpdate = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            txtICD10code.Enabled = true;
            txtICD10name.Enabled = true;
            txtspellCode.Enabled = true;
            txtfiveCode.Enabled = true;
            txtBIAO.Enabled = true;
            txtZHEND.Enabled = true;
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            txtICD10code.Text = "";
            txtICD10name.Text = "";
            txtspellCode.Text = "";
            txtfiveCode.Text = "";
            txtBIAO.Text = "";
            txtZHEND.Text = "";

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.Enabled = true;
          
                    if (this.txtICD10code.Text == "")
                    {
                        App.Msg("ICD10���벻��Ϊ��");
                        this.txtICD10code.Focus();
                        return;
                    }
                    if (this.txtICD10name.Text == "")
                    {
                        App.Msg("���Ʋ���Ϊ��");
                        this.txtICD10name.Focus();
                        return;
                    }
                    if (isDelectUpdate == true)
                    {
                        string innsetsql = "insert into diag_def_icd10 (code,name,shortcut1,shortcut2,qtxm,fjbm) values('" + txtICD10code.Text + "','" + txtICD10name.Text + "','" + txtspellCode.Text + "','" + txtfiveCode.Text + "','" + txtBIAO.Text + "','" + txtZHEND.Text + "')";
                        int count = App.ExecuteSQL(innsetsql);
                        if (count > 0)
                        {
                            App.Msg("��ӳɹ���");
                            btncancel_Click(sender, e);
                            SetflgViewData();
                        }
                    }
                    else
                    {
                        string spellcode = App.getSpell(this.txtICD10name.Text);
                        string fivecode = App.GetWBcode(this.txtICD10name.Text);
                        string updatesql = "update diag_def_icd10 set name='" + this.txtICD10name.Text + "',shortcut1='" + spellcode + "',shortcut2='" + fivecode + "',QTXM='" + txtBIAO.Text + "',FJBM='" + txtZHEND.Text + "'  where code='" + txtICD10code.Text + "'";
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
            if (txtICD10code.Text == "" || this.txtICD10name.Text == "")
            {
                App.Msg("��û��Ҫ�޸ĵ���Ϣ");
                return;
            }
            isDelectUpdate = false;
            txtICD10code.Enabled = true;
            txtICD10name.Enabled = true;
            txtspellCode.Enabled = true;
            txtBIAO.Enabled = true;
            txtZHEND.Enabled = true;
            txtfiveCode.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btncancel.Enabled = true;
            this.btnconfirm.Enabled = true;
        }

        private void txtICD10name_TextChanged(object sender, EventArgs e)
        {
            string spellcode = App.getSpell(this.txtICD10name.Text);
            string fivecode = App.GetWBcode(this.txtICD10name.Text);
            this.txtspellCode.Text = spellcode;
            this.txtfiveCode.Text = fivecode;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.ucGridviewX1.Enabled = true;
            this.btnAdd.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
            txtICD10code.Enabled = false;
            txtICD10name.Enabled = false;
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;
            txtBIAO.Enabled = false;
            txtZHEND.Enabled = false;
            txtICD10code.Text = "";
            txtICD10name.Text = "";
            txtspellCode.Text = "";
            txtfiveCode.Text = "";
            txtBIAO.Text = "";
            txtZHEND.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtICD10code.Text == "" || this.txtICD10name.Text == "")
                {
                    App.Msg("��ȷ����Ҫɾ������Ϣ");
                    return;
                }
                else
                {
                    string deletesql = "delete diag_def_icd10 where code='" + this.txtICD10code.Text + "'";

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
            string icd10Name = this.txtVindicateName.Text;
            if (icd10Name == "")
            {
                SetflgViewData();
            }
            else
            {
                string sql = "select code as ICD10����,name as �����,shortcut1 as ƴ����,shortcut2 as �����,(code || name) as ICD10,QTXM as �������,FJBM as ��ϱ��� from diag_def_icd10 where name like '" + icd10Name + "%' or shortcut1 like '" + icd10Name + "%'";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    this.ucGridviewX1.DataBd(sql, "ICD10����", "", "");
                    ucGridviewX1.fg.ReadOnly = true;
                }
            }
        }

        private void txtICD10name_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtICD10name_KeyUp(object sender, KeyEventArgs e)
        {
           

        }

        /// <summary>
        /// �Զ������ά��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDigmodify_Click(object sender, EventArgs e)
        {         
            if (txtICD10code.Text.Trim() != "")
            {
                current_id = "";
                frmICD10Vindicate_ModiFy fc = new frmICD10Vindicate_ModiFy(current_name, current_id, current_iszy, current_isicd10, txtICD10code.Text.Trim());
                App.FormStytleSet(fc, false);
                fc.ShowDialog();
                ShowSelfDigs(txtICD10code.Text.Trim());
            }
            else
            {
                App.MsgWaring("����ѡ���׼ICD10��ϣ�");
            }
        }

        private void ucC1FlexGrid2_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                if (ucGridviewX2.fg.Rows.Count >0)
                {
                    current_id = ucGridviewX2.fg["����", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    current_name = ucGridviewX2.fg["����", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX2.fg["�Ƿ���ҽ���", ucGridviewX2.fg.CurrentRow.Index].Value.ToString() == "N")
                    {
                        current_iszy = "N";
                    }
                    else
                    {
                        current_iszy = "Y";
                    }
                    if (ucGridviewX2.fg["�Ƿ�ICD10�����",ucGridviewX2.fg.CurrentRow.Index].Value.ToString() == "Y")
                    {
                        current_isicd10 = "N";
                    }
                    else
                    {
                        current_isicd10 = "Y";
                    }
                    current_icd10code = ucGridviewX2.fg["ICD10�����", ucGridviewX2.fg.CurrentRow.Index].Value.ToString();
                    frmICD10Vindicate_ModiFy fc = new frmICD10Vindicate_ModiFy(current_name, current_id, current_iszy, current_isicd10, current_icd10code);
                    App.FormStytleSet(fc, false);
                    fc.ShowDialog();
                    ShowSelfDigs(current_icd10code);
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("��ѡ��Ҫ�޸ĵ����ݣ�"+ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ���Զ������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ucGridviewX2.fg.Rows.Count >0)
            {
                if (App.Ask("ȷ��Ҫɾ����������Զ����¼��"))
                {
                    if (App.ExecuteSQL("delete from T_DIAG_DEF where DIAG_ID=" + ucGridviewX2.fg["����", ucGridviewX2.fg.CurrentRow.Index].Value.ToString() + "") > 0)
                    {
                        App.Msg("�����Ѿ��ɹ���");
                        ShowSelfDigs(txtICD10code.Text);
                    }

                }
            }
            else
            {
                App.MsgErr("��ѡ��Ҫɾ���ļ�¼��");
            }
        }

        private void txtICD10name_TextChanged_1(object sender, EventArgs e)
        {
            string spellcode = App.getSpell(this.txtICD10name.Text);
            string fivecode = App.GetWBcode(this.txtICD10name.Text);
            this.txtspellCode.Text = spellcode;
            this.txtfiveCode.Text = fivecode;
        }
    }
}