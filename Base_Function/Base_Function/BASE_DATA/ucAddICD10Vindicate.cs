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
    /// ��������Զ���
    /// </summary>
    /// ���� ��ΰ
    /// ʱ�� 2010��9��14��
    public partial class ucAddICD10Vindicate : UserControl
    {

        bool isDelectUpdate = false;
        string sysTemcode = "";
        public ucAddICD10Vindicate()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void SetflgViewData()
        {
            string sql = "select DIAG_ID as ����, NAME as ����, CATEGORY_ID as Ŀ¼ID, IS_CHN as �Ƿ���ҽ���, SHORTCUT1 as ƴ����, SHORTCUT2 as �����, IS_ICD10 as �Ƿ�ICD10�����, ICD10_ID as ICD10����� from T_DIAG_DEF ";

            //string sql = "select code as ICD10����,name as �����,shortcut1 as ƴ����,shortcut2 as �����,(code || name) as ICD10 from diag_def_icd10";
            ds = App.GetDataSet(sql);
            if (ds != null)
            {
                this.ucGridviewX1.DataBd(sql, "����", false, "", "");
                ucGridviewX1.fg.ReadOnly =true;
            }

        }

        private void frmAddICD10Vindicate_Load(object sender, EventArgs e)
        {
            this.btncancel.Enabled = false;
            this.btnconfirm.Enabled = false;
            this.txtName.Enabled = false;
            this.cobisberbalistdocter.Enabled = false;
            this.cxbisDiagnoseCode.Enabled = false;
            SetflgViewData();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            ucGridviewX1.fg.AllowUserToAddRows = false;
        }
        int oldRow = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                txtDiaselogCode.Enabled = false;
                txtDaiMa.Enabled = false;
                txtName.Enabled = false;
                txtMuLuID.Enabled = false;
                txtspellcode.Enabled = false;
                txtfivecode.Enabled = false;
                cobisberbalistdocter.Checked = false;
                cxbisDiagnoseCode.Checked = false;
                //txtDiaselogCode.Text = "";
                if (ucGridviewX1.fg.Rows.Count >0)
                {
                    this.txtDaiMa.Text = ucGridviewX1.fg["����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtName.Text = ucGridviewX1.fg["����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtMuLuID.Text = ucGridviewX1.fg["Ŀ¼ID", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtspellcode.Text = ucGridviewX1.fg["ƴ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    this.txtfivecode.Text = ucGridviewX1.fg["�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["�Ƿ���ҽ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "N")
                    {
                        this.cobisberbalistdocter.Checked = false;
                    }
                    else
                    {
                        this.cobisberbalistdocter.Checked = true;
                    }
                    if (ucGridviewX1.fg["�Ƿ�ICD10�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "Y")
                    {
                        this.cxbisDiagnoseCode.Checked = true;
                    }
                    else
                    {
                        this.cxbisDiagnoseCode.Checked = false;
                    }
                    //this.txtSystemCode.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, ""].ToString();
                    this.txtDiaselogCode.Text = ucGridviewX1.fg["ICD10�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

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
                    //        if (oldRow > 0 && ds.Tables[0].Rows.Count >= oldRow)
                    //        {
                    //            //������һ�ε�������л�ԭ
                    //            this.ucC1FlexGrid1.fg.Rows[oldRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
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
            this.txtName.Enabled = true;
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            this.cobisberbalistdocter.Enabled = true;
            this.cxbisDiagnoseCode.Enabled = true;
            txtDiaselogCode.Enabled = true;
            sysTemcode = App.GenId("T_DIAG_DEF", "DIAG_ID").ToString();
            isDelectUpdate = true;
            //this.btncancel.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            //this.txtMuLuID.Text = "";
            //this.txtName.Text = "";
            this.txtDaiMa.Text = sysTemcode;
            //this.txtspellcode.Text = "";
            //this.txtfivecode.Text = "";
            this.cobisberbalistdocter.Checked = false;
            this.cxbisDiagnoseCode.Checked = false;
            //this.txtDiaselogCode.Text = "";
            btncancel.Enabled = true;
            btnAdd.Enabled = false;

            txtDiaselogCode.Enabled = true;
            txtDaiMa.Enabled = true;
            txtName.Enabled = true;
            txtMuLuID.Enabled = true;
            txtspellcode.Enabled = true;
            txtfivecode.Enabled = true;
            cobisberbalistdocter.Enabled = true;
            cxbisDiagnoseCode.Enabled = true;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (isDelectUpdate == true)
                {
                    
                    string isherbalist = "N";
                    string isdiagnoseCode = "Y";

                    string name = this.txtName.Text.Trim();
                    string cotelog = this.txtMuLuID.Text.Trim();
                    string spellcode = this.txtspellcode.Text.Trim();
                    string fivecode = this.txtfivecode.Text.Trim();
                    if (this.cobisberbalistdocter.Checked == false)
                    {
                        isherbalist = "N";
                    }
                    else
                    {
                        isherbalist = "Y";
                    }
                    if (this.cxbisDiagnoseCode.Checked == false)
                    {
                        isdiagnoseCode = "N";
                    }
                    else
                    {
                        isdiagnoseCode = "Y";                                         
                    }
                    string diaselogCode = this.txtDiaselogCode.Text.Trim();                                                   //cotelog
                    string innsetsql = "insert into T_DIAG_DEF values('" + Convert.ToInt64(sysTemcode) + "','" + name + "'," + 1 +
                        ",'" + isherbalist + "','" + spellcode + "','" + fivecode + "','" + isdiagnoseCode + "','" + diaselogCode + "')";
                    if (App.ExecuteSQL(innsetsql) > 0)
                    {
                        App.Msg("��ӳɹ���");
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        SetflgViewData();
                        btnAdd.Enabled = true;
                        this.btncancel.Enabled =false;
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        btnconfirm.Enabled = false;
                        ShowEClear();
                    }
                    else
                    {
                        App.MsgErr("���ʧ�ܣ�����ֵ�Ƿ�Ϊ�գ�");
                    }
                }
                else
                {
                   
                    string isherbalist = "N";
                    string isdiagnoseCode = "Y";
                    string spellcode = App.getSpell(this.txtName.Text.Trim());
                    string fivecode = App.GetWBcode(this.txtName.Text.Trim());
                    if (this.cobisberbalistdocter.Checked == false)
                    {
                        isherbalist = "N";
                    }
                    else
                    {
                        isherbalist = "Y";
                    }
                    if (this.cxbisDiagnoseCode.Checked == false)
                    {
                        isdiagnoseCode = "N";
                    }
                    else
                    {
                        isdiagnoseCode = "Y";
                    }
                    string updatesql = "update T_DIAG_DEF set name='" + this.txtName.Text.Trim() + "',shortcut1='" + spellcode + "',shortcut2='" + fivecode + "',is_chn='" + isherbalist + "',is_icd10='" + isdiagnoseCode + "',ICD10_ID='"+this.txtDiaselogCode.Text.Trim()+"' where diag_id='" + txtDaiMa.Text.Trim() + "'";
                    if (App.ExecuteSQL(updatesql) > 0)
                    {
                        App.Msg("�޸ĳɹ�");
                        SetflgViewData();
                        this.btncancel.Enabled = false;
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.btnconfirm.Enabled = false;
                        this.btncancel.Enabled = false;
                        btnAdd.Enabled = true;
                        ShowEClear();
                    }
                    else
                    {
                        App.MsgErr("�޸�ʧ�ܣ������Ƿ��д˼�¼���߹رպ�����");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                App.Msg("��û��Ҫ�޸ĵ���Ϣ");
                return;
            }
            this.btnconfirm.Enabled = true;
            this.btncancel.Enabled = true;
            this.btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            this.txtName.Enabled = true;
            this.cobisberbalistdocter.Enabled = true;
            this.cxbisDiagnoseCode.Enabled = true;
            isDelectUpdate = false;
            this.btncancel.Enabled = true;
            //this.btnUpdate.Enabled = false;
            txtDiaselogCode.Enabled = true;
            this.btnDelete.Enabled = false;
            txtDiaselogCode.Enabled = true;

            txtDiaselogCode.Enabled = true;
            txtDaiMa.Enabled = true;
            txtName.Enabled = true;
            txtMuLuID.Enabled = true;
            txtspellcode.Enabled = true;
            txtfivecode.Enabled = true;
            cobisberbalistdocter.Enabled = true;
            cxbisDiagnoseCode.Enabled = true;
        }

        private void txtICD10name_TextChanged(object sender, EventArgs e)
        {
            //string spellcode = App.getSpell(this.txtICD10name.Text);
            //string fivecode = App.GetWBcode(this.txtICD10name.Text);
            //this.txtspellCode.Text = spellcode;
            //this.txtfiveCode.Text = fivecode;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.btnconfirm.Enabled = false;
            this.btncancel.Enabled = false;
            this.txtName.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btncancel.Enabled = false;
            this.btnUpdate.Enabled = true;
            this.btnDelete.Enabled = true;
            txtDiaselogCode.Enabled = false;
            cobisberbalistdocter.Enabled = false ;
            cxbisDiagnoseCode.Enabled = false;
            ShowEClear();
           
        }
        private void ShowEClear()
        {
            txtDaiMa.Text = "";
            txtName.Text = "";
            txtMuLuID.Text = "";
            txtspellcode.Text = "";
            txtfivecode.Text = "";
            cobisberbalistdocter.Checked = false;
            cxbisDiagnoseCode.Checked = false;
            txtDiaselogCode.Text = "";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               
                    string deletesql = "delete T_DIAG_DEF where diag_id='" + this.txtDaiMa.Text.Trim() + "'";

                    if (App.Ask("��ȷ��Ҫɾ����"))
                    {
                        if (App.ExecuteSQL(deletesql) > 0)
                        {
                            App.Msg("ɾ���ɹ���");
                            SetflgViewData();
                            this.btncancel.Enabled = true;
                            this.btnUpdate.Enabled = true;
                            this.btnDelete.Enabled = true;
                            this.btnconfirm.Enabled = false;
                            this.btncancel.Enabled = false;

                            ShowEClear();
                        }
                        else
                        {
                            App.MsgErr("ɾ��ʧ�ܣ������Ƿ��д˼�¼���߹رպ�����");
                        }
                    }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string icd10Name = this.txtVindicateName.Text.Trim();
            if (icd10Name == "")
            {
                SetflgViewData();
            }
            else
            {
                string sql = "select DIAG_ID as Ŀ¼ID, NAME as ����, CATEGORY_ID as ����, IS_CHN as �Ƿ���ҽ���, SHORTCUT1 as ƴ����, SHORTCUT2 as �����, IS_ICD10 as �Ƿ�ICD10�����, ICD10_ID as ICD10����� from T_DIAG_DEF where name like '"+icd10Name+"%'";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    this.ucGridviewX1.DataBd(sql, "Ŀ¼ID", false, "", "");
                    ucGridviewX1.fg.ReadOnly = true;
                }
            }
        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    App.SelectFastCodeCheck();
            //}
            //else if (e.KeyCode == Keys.Left)
            //{

            //}
            //else if (e.KeyCode == Keys.Right)
            //{

            //}
            //else if (e.KeyCode == Keys.Escape)
            //{
            //    App.HideFastCodeCheck();
            //}
            //else
            //{
            //    if (!App.FastCodeFlag)
            //        if (txtName.Text.Trim() != "")
            //        {
            //            App.FastCodeCheck("select code as ����,name as �����,(code || name) as ICD10 from diag_def_icd10 where rownum<11 and shortcut1 like '" + this.txtName.Text.Trim() + "%'", txtName, "�����", "����");
                       
            //            //App.FastCodeCheck("select code as ����,name as �����,(code || name) as ICD10 from diag_def_icd10 where rownum<11 and shortcut1 like '" + this.txtName.Text + "%'", txtName, "�����", "ICD10");
            //        }
                
            //    App.FastCodeFlag = false;
            //    //txtDiaselogCode.Text = App.SelectObj.Select_Val;
            //}
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            //if (App.SelectObj != null)
            //{
            //    this.txtMuLuID.Text = App.SelectObj.Select_Val;
            //    txtDiaselogCode.Text = App.SelectObj.Select_Val;
            //    //this.txtDiaselogCode.Text = App.SelectObj.Select_Val;// +App.SelectObj.Select_Name;
            //}
            string spellcode = App.getSpell(this.txtName.Text.Trim());
            string fivecode = App.GetWBcode(this.txtName.Text.Trim());
            this.txtspellcode.Text = spellcode;
            this.txtfivecode.Text = fivecode;
        }

        private void cxbisDiagnoseCode_CheckedChanged(object sender, EventArgs e)
        {
            if (cxbisDiagnoseCode.Checked == true)
            {
                if (App.SelectObj != null)
                {
                    this.txtDiaselogCode.Text = App.SelectObj.Select_Val;
                }
            }
            else
            {
                this.txtDiaselogCode.Text = "";//App.SelectObj.Select_Val;// +App.SelectObj.Select_Name;
            }

        }

        private void txtDiaselogCode_KeyDown(object sender, KeyEventArgs e)
        {
        //    if (e.KeyCode == Keys.Down)
        //    {
        //        App.SelectFastCodeCheck();
        //    }
        //    else if (e.KeyCode == Keys.Left)
        //    {

        //    }
        //    else if (e.KeyCode == Keys.Right)
        //    {

        //    }
        //    else if (e.KeyCode == Keys.Escape)
        //    {
        //        App.HideFastCodeCheck();
        //    }
        //    else
        //    {

        //        if (!App.FastCodeFlag)
        //        {
        //            if (txtDiaselogCode.Text.Trim() != "")
        //            {
        //                App.FastCodeCheck("select CODE as ICD10���,NAME as ���� from diag_def_icd10 t where SHORTCUT1 like '" + txtDiaselogCode.Text + "%'", txtDiaselogCode, "ICD10���", "����");
        //                App.FastCodeFlag = false;
        //            }
        //            else
        //            {
        //                App.HideFastCodeCheck();
        //            }
        //        }
            


        //    }  
            if (e.KeyCode == Keys.Enter)
            {
                btnconfirm.Focus();
            }
        }

        private void txtDiaselogCode_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {

                    if (!App.FastCodeFlag)
                    {
                        if (txtDiaselogCode.Text.Trim() != "")
                        {
                            App.FastCodeCheck("select CODE as ICD10���,NAME as ���� from diag_def_icd10 t where SHORTCUT1 like '" + txtDiaselogCode.Text + "%'", txtDiaselogCode, "ICD10���", "����");
                            App.FastCodeFlag = false;
                        }
                        else
                        {
                            App.HideFastCodeCheck();
                        }
                    }



                }
            }
            catch
            {
            }
            finally
            {
                App.FastCodeFlag = false;
            }
            
        }

        private void txtDiaselogCode_TextChanged(object sender, EventArgs e)
        {
            //if (txtDiaselogCode.Text== "")
            //{
            //    App.FastCodeFlag = false;
            //}
        }
    }
}