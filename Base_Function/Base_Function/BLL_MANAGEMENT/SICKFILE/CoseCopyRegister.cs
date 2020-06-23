using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

using Microsoft.Reporting.WinForms;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    /// <summary>
    /// ������ӡ��¼
    /// </summary>
    /// ���� ��ΰ
    /// ����ʱ�� 2010��7��10��
    public partial class CoseCopyRegister : UserControl
    {
        ColumnInfo[] column = new ColumnInfo[11];
        string ID = "";
        bool isSaveOrUpdate = false;
        //string cckBeInhospital = "";//סԺ־
        //string cckAnimalheat = "";//���µ�
        //string cckDoctorsAdvice = "";//ҽ����
        //string cckAssay = "";//���鵥(���鱨��)
        //string cckBlipData = "";//ҽѧӰ��������
        //string cckcorpsAgree = "";//������(����)ͬ����
        //string cckOperation = "";//����ͬ����
        //string cckOperationNote = "";//�����������¼��
        //string cckWork_UP = "";//������
        //string cckNurseNote = "";//�����¼
        //string cckOutHospitalNote = "";//��Ժ��¼
        string sql = "";
        public CoseCopyRegister()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        DataSet ds = null;
        //private void SetTable()
        //{

        //    ucC1FlexGrid1.fg.Cols.Count = 15;
        //    ucC1FlexGrid1.fg.Cols.Fixed = 0;
        //    ucC1FlexGrid1.fg.Rows.Count = 1;
        //    ucC1FlexGrid1.fg.Rows.Fixed = 1;
        //}
        //��ʾ�б�����
        //private void ShowValue()
        //{
        //    string SQl = T_SickRoomInfo + "  order by SRID asc";
        //    ucC1FlexGrid1.DataBd(SQl, "���", "", "");
        //    ucC1FlexGrid1.fg.Cols["���"].Visible = false;
        //    ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
        //    ucC1FlexGrid1.fg.Cols["�������"].Visible = false;
        //    ucC1FlexGrid1.fg.Cols["�������"].AllowEditing = false;
        //    ucC1FlexGrid1.fg.Cols["�ȼ����"].Visible = false;
        //    ucC1FlexGrid1.fg.Cols["�ȼ����"].AllowEditing = false;
        //    ucC1FlexGrid1.fg.AllowEditing = false;
        //}

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                sql = "select ID as ID,COPY_TIME as ��ӡʱ��,APPLY_UNIT as ���뵥λ,APPLY_PERSON as ������,CASE_ID as ������," +
                       "DEGREE_NUMBER as ���֤,JOB_NUMBER as ����֤��,TRUST_DEED as ί����,DEAD_ARGUE as ����֤��," +
                       "NEAR_RELATIVE_ARGUE as ��������ϵ֤��,COPY_VALUE as ��ӡ����,RECORD_TIME as ��¼ʱ�� " +
                       "from T_CASE_COPY_RECORD where 1=1 ";
                string datatime = dtpTime.Value.ToString("yyyy-MM");


                if (casenum.Text.Trim() != "")
                {
                    sql += " and CASE_ID like '%" + casenum.Text + "%' ";
                }
                if (txtName.Text.Trim() != "")
                {
                    sql += " and APPLY_PERSON like '" + txtName.Text + "%'";
                }
                if (datatime != "")
                {
                    sql += " and to_char(COPY_TIME,'yyyy-MM') like '" + datatime + "%'";
                }



                ds = new DataSet();
                ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    ucC1FlexGrid1.DataBd(sql, "ID", "", "");
                    ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//����ID����
                    ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                    ucC1FlexGrid1.fg.AllowEditing = false;
                }
                else
                {
                    ucC1FlexGrid1.DataBd(sql, "ID", "", "");
                    ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//����ID����
                    ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                    ucC1FlexGrid1.fg.AllowEditing = false;
                }
            }
            catch (Exception ee)
            {
            }
            //SetHeard();// �ϲ���Ԫ��
        }
        /// <summary>
        /// ���뵥λ��
        /// </summary>
        public void GetAllSection_Name()
        {
            DataSet ds = new DataSet();
            string sql = "select * from t_data_code where enable='Y' and type=48";
            ds = App.GetDataSet(sql);
            this.cbbapplyunit.DataSource = ds.Tables[0].DefaultView;
            cbbapplyunit.DisplayMember = "NAME";
            cbbapplyunit.ValueMember = "ID";

            cbbapplyunit.SelectedIndex = 0;
        }

        /// <summary>
        /// ���ظ�ӡ����
        /// </summary>
        public void GetFYNR()
        {
            DataSet ds_FYLR = App.GetDataSet("select t.code,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where enable='Y' and t2.type='BLFYNR'");
            chkFYNR.DataSource = ds_FYLR.Tables[0].DefaultView;
            chkFYNR.DisplayMember = "name";
            chkFYNR.ValueMember = "code";
        }

        //��������¼�
        private void CoseCopyRegister_Load(object sender, EventArgs e)
        {
            try
            {
                sql = "select ID as ID,COPY_TIME as ��ӡʱ��,APPLY_UNIT as ���뵥λ,APPLY_PERSON as ������,CASE_ID as ������," +
               "DEGREE_NUMBER as ���֤,JOB_NUMBER as ����֤��,TRUST_DEED as ί����,DEAD_ARGUE as ����֤��," +
               "NEAR_RELATIVE_ARGUE as ��������ϵ֤��,COPY_VALUE as ��ӡ����,RECORD_TIME as ��¼ʱ�� " +
               "from T_CASE_COPY_RECORD ";
                ds = new DataSet();
                ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    ucC1FlexGrid1.DataBd(sql, "ID", "", "");//����ID �󶨵�ucC1FlexGrid1�ؼ�

                    ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//����ID����
                    ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;//���ܱ༭
                    ucC1FlexGrid1.fg.AllowEditing = false;


                }
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);

                GetAllSection_Name();//���뵥λ��
                SetControlEnabled(); //����ʱ���ÿؼ��ĳ���
                GetFYNR();//���ظ�ӡ����

                if (ucC1FlexGrid1.fg.Rows.Count > 1)
                {
                    ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//����ID����
                    ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                    ucC1FlexGrid1.fg.AllowEditing = false;
                }
            }
            catch { }
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.Cols["ID"].Visible = false;//����ID����
                ucC1FlexGrid1.fg.Cols["ID"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
            catch
            { }
        }
        //����ʱ���ÿؼ��ĳ���
        private void SetControlEnabled()
        {
            #region
            this.cbbapplyunit.Enabled = false;
            this.txtApplyName.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.txtCaseName.Enabled = false;
            this.txtIDCard.Enabled = false;
            this.txtWorkCard.Enabled = false;
            this.checkDelegate.Enabled = false;
            this.checkDeath.Enabled = false;
            this.checkKindred.Enabled = false;
            this.chkFYNR.Enabled = false;
            foreach (int i in chkFYNR.CheckedIndices)
            {
                chkFYNR.SetItemChecked(i, false);
            }
            this.btnConfirm.Enabled = false;
            this.btncancel.Enabled = false;
            #endregion
        }
        //�����Ӱ�ťʱ����
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region
            isSaveOrUpdate = true;
            this.ucC1FlexGrid1.Enabled = false;
            this.cbbapplyunit.Enabled = true;
            this.txtApplyName.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.txtCaseName.Enabled = true;
            this.txtIDCard.Enabled = true;
            this.txtWorkCard.Enabled = true;
            this.checkDelegate.Enabled = true;
            this.checkDeath.Enabled = true;
            this.checkKindred.Enabled = true;
            this.chkFYNR.Enabled = true;
            foreach (int i in chkFYNR.CheckedIndices)
            {
                chkFYNR.SetItemChecked(i, false);
            }
            this.btnSave.Enabled = false;
            this.btnConfirm.Enabled = true;
            this.btncancel.Enabled = true;
            this.btnUpdate.Enabled = false;
            this.btnDalete.Enabled = false;
            this.txtApplyName.Text = "";
            this.txtCaseName.Text = "";
            this.txtIDCard.Text = "";
            this.txtWorkCard.Text = "";
            checkDelegate.Checked = false;
            checkDeath.Checked = false;
            checkKindred.Checked = false;
            #endregion
        }
        //���ȡ����ťʱ����
        private void btncancel_Click(object sender, EventArgs e)
        {
            SetControlEnabled();
            this.ucC1FlexGrid1.Enabled = true;
            this.btnConfirm.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnConfirm.Enabled = false;
            this.btnUpdate.Enabled = true;
            this.btnDalete.Enabled = true;
        }

        /// <summary>
        /// ���ȷ����ťʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                this.ucC1FlexGrid1.Enabled = true;
                string applyUnit = this.cbbapplyunit.Text.ToString();//���뵥λ
                string applyName = this.txtApplyName.Text.Trim();//����������
                string applyTime = this.dateTimePicker1.Text.ToString();//��ӡʱ��
                string caseName = this.txtCaseName.Text.Trim();//������
                string iDCard = this.txtIDCard.Text.Trim();//���֤��
                string workCard = this.txtWorkCard.Text.Trim();//����֤
                string cckdelegate = "";//ί����  
                string cckDeath = "";//����֤��
                string cckKindred = "";//��������ϵ֤��
                string copyContert = "";
                if (checkDelegate.Checked == true)
                    cckdelegate = "Y";
                else
                    cckdelegate = "N";
                if (checkDeath.Checked == true)
                    cckDeath = "Y";
                else
                    cckDeath = "N";
                if (checkKindred.Checked == true)
                    cckKindred = "Y";
                else
                    cckKindred = "N";

                

                if (chkFYNR.Items.Count > 0 && chkFYNR.CheckedItems.Count == 0)
                {
                    App.Msg("��ʾ:[��ӡ����]δѡ��!");
                    return;
                }
                for (int i = 0; i < chkFYNR.CheckedItems.Count; i++)
                {

                    DataRowView temp = (DataRowView)chkFYNR.CheckedItems[i];
                    if (copyContert == "")
                    {
                        copyContert = temp["name"].ToString();
                    }
                    else
                    {
                        copyContert += "," + temp["name"].ToString();
                    }

                }
                
                T_CASE_COPY_RECORD case_copy = new T_CASE_COPY_RECORD();
                if (isSaveOrUpdate)
                {
                    if (applyName == "")
                    {
                        App.Msg("�����˻�û��д");
                        this.txtApplyName.Focus();
                        return;
                    }
                    if (caseName == "")
                    {
                        App.Msg("�����Ż�û��д");
                        this.txtCaseName.Focus();
                        return;
                    }
                    if (iDCard == "")
                    {
                        App.Msg("���֤�Ż�û��д");
                        this.txtIDCard.Focus();
                        return;
                    }
                    if (workCard == "")
                    {
                        App.Msg("����֤�Ż�û��д");
                        this.txtWorkCard.Focus();
                        return;
                    }
                    case_copy.APPLY_UNIT = applyUnit;//���뵥λ
                    case_copy.APPLY_PERSON = applyName;//����������
                    case_copy.COPY_TIME = applyTime;//��ӡʱ��
                    case_copy.CASE_ID = caseName;//������
                    case_copy.DEGREE_NUMBER = iDCard;//���֤
                    case_copy.JOB_NUMBER = workCard;//����֤
                    case_copy.TRUST_DEED = cckdelegate;//ί����
                    case_copy.DEAD_ARGUE = cckDeath;//����֤��
                    case_copy.NEAR_RELATIVE_ARGUE = cckKindred;//��������ϵ

                    case_copy.COPY_VALUE = copyContert;
                    ID = App.GenId("T_CASE_COPY_RECORD", "ID").ToString();
                    string insertsql = "insert into T_CASE_COPY_RECORD(ID,COPY_TIME,APPLY_UNIT,APPLY_PERSON,CASE_ID,DEGREE_NUMBER,JOB_NUMBER,TRUST_DEED,DEAD_ARGUE,NEAR_RELATIVE_ARGUE,COPY_VALUE,RECORD_TIME)" +
                        " values('" + ID + "',to_TIMESTAMP('" + case_copy.COPY_TIME + "','yyyy-MM-dd hh24:mi'),'" + case_copy.APPLY_UNIT + "','" + case_copy.APPLY_PERSON +
                        "','" + case_copy.CASE_ID + "','" + case_copy.DEGREE_NUMBER + "','" + case_copy.JOB_NUMBER + "','" + case_copy.TRUST_DEED + "','" + case_copy.DEAD_ARGUE +
                        "','" + case_copy.NEAR_RELATIVE_ARGUE + "','" + case_copy.COPY_VALUE + "',sysdate)";
                    if (App.ExecuteSQL(insertsql) > 0)
                        App.Msg("��ӳɹ�");
                    CoseCopyRegister_Load(sender, e);
                    SetEnabled();
                    //btnQuery_Click(sender, e);
                }
                else
                {
                    string updatesql = "UPDATE T_CASE_COPY_RECORD set COPY_TIME=to_TIMESTAMP('" + applyTime + "' ,'yyyy-MM-dd hh24:mi')" +
                        ",APPLY_UNIT='" + applyUnit + "',APPLY_PERSON='" + applyName + "',CASE_ID='" + caseName + "'" +
                        ", DEGREE_NUMBER='" + iDCard + "', JOB_NUMBER='" + workCard + "',TRUST_DEED='" + cckdelegate + "'" +
                        ",DEAD_ARGUE='" + cckDeath + "', NEAR_RELATIVE_ARGUE='" + cckKindred + "'" +
                        ", COPY_VALUE='" + copyContert + "',RECORD_TIME=sysdate " + //to_TIMESTAMP('" + App.GetSystemTime().ToString("yyyy-MM-dd") + "' ,'yyyy-MM-dd hh24:mi')" +
                        " where ID='" + ID + "'";
                    try
                    {
                        if (App.ExecuteSQL(updatesql) > 0)
                            App.Msg("�޸ĳɹ�");
                        CoseCopyRegister_Load(sender, e);
                        SetEnabled();
                    }
                    catch (Exception ee)
                    {
                        App.MsgErr(ee.Message);
                    }
                    //btnQuery_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("������Ϣ��" + ex.Message);
            }
        }

        /// <summary>
        /// ����ƥ��ѡ�и�ѡ��
        /// </summary>
        /// <param name="val"></param>
        /// <param name="chkval"></param>
        /// <returns></returns>
        private bool SetCheckbox(string val, string chkval)
        {
            bool flag = false;
            try
            {

                for (int i = 0; i < val.Split(',').Length; i++)
                {
                    if (val.Split(',')[i].ToString().Trim() == chkval.Trim())
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            catch
            {
                return flag;
            }
        }
        /// <summary>
        /// �����û��ؼ�ʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {

            if (ucC1FlexGrid1.fg.RowSel >= 0)
            {
                
                ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ID"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��ӡʱ��"].ToString());
                cbbapplyunit.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���뵥λ"].ToString();
                txtApplyName.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "������"].ToString();
                txtCaseName.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "������"].ToString();
                txtIDCard.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���֤"].ToString();
                txtWorkCard.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����֤��"].ToString();

                
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��ӡ����"].ToString().Trim() != "")//����֢������������ֵ���ȡ��صĴ��룩
                {
                    foreach (int i in chkFYNR.CheckedIndices)
                    {
                        chkFYNR.SetItemChecked(i, false);
                    }
                    string[] vals = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��ӡ����"].ToString().Split(',');
                    for (int i1 = 0; i1 < vals.Length; i1++)
                    {
                        for (int j = 0; j < chkFYNR.Items.Count; j++)
                        {
                            DataRowView temp = (DataRowView)chkFYNR.Items[j];
                            if (temp["name"].ToString() == vals[i1])
                            {
                                chkFYNR.SetItemChecked(j, true);
                            }
                        }
                    }

                }

                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ί����"].ToString() == "Y")
                {
                    checkDelegate.Checked = true;
                }
                else
                {
                    checkDelegate.Checked = false;
                }
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����֤��"].ToString() == "Y")
                {
                    checkDeath.Checked = true;
                }
                else
                {
                    checkDeath.Checked = false;
                }
                if (ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������ϵ֤��"].ToString() == "Y")
                {
                    checkKindred.Checked = true;
                }
                else
                {
                    checkKindred.Checked = false;
                }
            }

        }

        /// <summary>
        /// ������Ӻ�ȷ����֮����ؼ��Ŀɱ༭�����
        /// </summary>
        private void SetEnabled()
        {
            #region
            this.cbbapplyunit.Enabled = false;
            this.txtApplyName.Enabled = false;
            this.dateTimePicker1.Enabled = false;
            this.txtCaseName.Enabled = false;
            this.txtIDCard.Enabled = false;
            this.txtWorkCard.Enabled = false;
            this.checkDelegate.Enabled = false;
            this.checkDeath.Enabled = false;
            this.checkKindred.Enabled = false;
            this.chkFYNR.Enabled = false;
            foreach (int i in chkFYNR.CheckedIndices)
            {
                chkFYNR.SetItemChecked(i, false);
            }
            this.btnConfirm.Enabled = false;
            this.btncancel.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnDalete.Enabled = true;
            this.btnUpdate.Enabled = true;
            #endregion
        }
        /// <summary>
        /// ����޸İ�ťʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            #region
            this.ucC1FlexGrid1.Enabled = true;
            this.cbbapplyunit.Enabled = true;
            this.txtApplyName.Enabled = true;
            this.dateTimePicker1.Enabled = true;
            this.txtCaseName.Enabled = true;
            this.txtIDCard.Enabled = true;
            this.txtWorkCard.Enabled = true;
            this.checkDelegate.Enabled = true;
            this.checkDeath.Enabled = true;
            this.checkKindred.Enabled = true;
            this.chkFYNR.Enabled = true;
            isSaveOrUpdate = false;
            this.btnConfirm.Enabled = true;
            this.btnDalete.Enabled = false;
            this.btncancel.Enabled = true;
            this.btnSave.Enabled = false;
            this.btnUpdate.Enabled = false;
            #endregion
        }
        /// <summary>
        /// ���ɾ����ťʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDalete_Click(object sender, EventArgs e)
        {
            string deleteSQL = "DELETE T_CASE_COPY_RECORD where ID='" + ID + "'";
            try
            {
                if (App.Ask("��ȷ��Ҫɾ����"))
                {
                    if (App.ExecuteSQL(deleteSQL) > 0)
                    {
                        App.Msg("ɾ���ɹ�");
                        CoseCopyRegister_Load(sender, e);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("������Ϣ��" + ex.Message);
            }
            this.btnConfirm.Enabled = false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (ds == null || ds.Tables[0].Rows.Count <= 0)
                {
                    App.Msg("û�����ݿɴ�ӡ����ȷ��");
                    return;
                }
                saveFileDialog1.FileName = "������ӡ��¼.xls";
                saveFileDialog1.Filter = "Excel������(*.xls)|*.xls";
                saveFileDialog1.ShowDialog();
                //FrmPrint frmprint = new FrmPrint(ds.Tables[0]);
                //frmprint.ShowDialog();
            }
            catch (Exception ee)
            {
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string pathname = saveFileDialog1.FileName;
            //ucC1FlexGrid1.fg.SaveExcel(pathname);
            ucC1FlexGrid1.fg.SaveGrid(pathname, C1.Win.C1FlexGrid.FileFormatEnum.Excel, C1.Win.C1FlexGrid.FileFlags.IncludeFixedCells);
                             
        }

    }
}
