using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Bifrost;
using DevComponents.DotNetBar;

namespace Base_Function.BASE_DATA
{
    public partial class ucInterim_userInfo :UserControl
    {
        bool isSave = false;������������������//���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string mark = "Y";������������//��Ч��־
        private string prescription = "true"; //ְҵ�ʸ�֤
        private string T_IntermUser_Sql;����  //��ʱ�û���
        private string temp_id = "";          //��ǰѡ�е��û�����
        DataSet ds;

        public ucInterim_userInfo()
        {
            InitializeComponent();
            T_IntermUser_Sql=@"select TEMP_ID as �û�����,a.NAME as �û�����,(case when GENDER=0 then '��' else 'Ů' end) as �û��Ա�,"+
                            @"TECH_POST as ְ�Ʊ��,b.name as ְ��,PHONE as �绰,MOBILE_PHONE as �ֻ�����,EMAIL as �����ַ,"+
                            @"(case when ENABLE_FLAG='Y' then '��Ч' else '��Ч' end) as ��Ч��־,"+
                            @"(case when PROFESSION_CARD='true' then '��' else '��' end) as ְҵ�ʸ�֤,"+
                            @"PROF_CARD_NAME as �ʸ�֤������,to_char(PASS_TIME,'yyyy-mm-dd ') as ͨ��ʱ��,to_char(RECEIVE_TIME,'yyyy-mm-dd ') as ��֤ʱ��,to_char(REGISTER_TIME,'yyyy-mm-dd ') as ע��ʱ��,TUTOR as ָ����ʦ," +
                            @"ISBELONGTO_HOSPITAL as ����ҽԺ,ISBELONGTO_SCHOOL as ����ѧУ,SPECIALTY as ��ѧרҵ,PRAXIS_NO as ʵϰ���κ�,"+
                            @"STUDY_NO as ѧ�� from T_TEMP_USER a inner join T_DATA_CODE b on a.tech_post=b.id  where ENABLE_FLAG='Y'";
        }
        private void frmInterim_userInfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("��ʱ�û���Ϣ");
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucGridviewX1.fg.RowColChange += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            cboGender.SelectedIndex = 0;
            professional();
            RefleshFrm();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].Visible = false;
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
       //��ʾ�������
        private void ShowValue()
        {
            string SQl = T_IntermUser_Sql + "  order by �û����� desc";
            ds = App.GetDataSet(SQl);
            if (ds != null)
            {

            //    ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                ucGridviewX1.DataBd(SQl, "�û�����", false, "", "");
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].Visible = false;
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }

        }
        //��ְ��
        private void professional()
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE  where Type='1'");
            cboCreer.DataSource = ds.Tables[0].DefaultView;
            cboCreer.ValueMember = "ID";
            cboCreer.DisplayMember = "NAME";
        }

        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
            txtID.Enabled = false;
            txtName.Enabled = false;
            cboGender.Enabled = false;
            cboCreer.Enabled = false;
            txtPhone.Enabled = false;
            txtTelphone.Enabled = false;
            txtEmail.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            rbtnSelected.Enabled = false;
            rbtnNoselected.Enabled = false;
            txtCertificatename.Enabled = false;
            dtpPassingtime.Enabled = false;
            dtpLeadcard.Enabled = false;
            dtpRegdate.Enabled = false;
            txtToguid_teacher.Enabled = false;
            txtHospital.Enabled = false;
            txtSchool.Enabled = false;
            txtSpecialized_field.Enabled = false;
            txtBatchno.Enabled = false;
            txtNumber.Enabled = false;
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
                txtID.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtTelphone.Text = "";
                txtCertificatename.Text = "";
                txtToguid_teacher.Text = "";
                txtHospital.Text = "";
                txtSchool.Text = "";
                txtSpecialized_field.Text = "";
                txtBatchno.Text = "";
                txtNumber.Text = "";
            }
            txtID.Enabled = true;
            txtName.Enabled = true;
            cboGender.Enabled = true;
            cboCreer.Enabled = true;
            txtPhone.Enabled = true;
            txtTelphone.Enabled = true;
            txtEmail.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            rbtnSelected.Enabled = true;
            rbtnNoselected.Enabled = true;
            txtCertificatename.Enabled = true;
            dtpPassingtime.Enabled = true;
            dtpLeadcard.Enabled = true;
            dtpRegdate.Enabled = true;
            txtToguid_teacher.Enabled = true;
            txtHospital.Enabled = true;
            txtSchool.Enabled = true;
            txtSpecialized_field.Enabled = true;
            txtBatchno.Enabled = true;
            txtNumber.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (rbtnSelected.Checked == true)
            {
                txtCertificatename.Enabled = true;
                dtpPassingtime.Enabled = true;
                dtpLeadcard.Enabled = true;
                dtpRegdate.Enabled = true;
            }
            else
            {
                txtCertificatename.Enabled = false;
                dtpPassingtime.Enabled = false;
                dtpLeadcard.Enabled = false;
                dtpRegdate.Enabled = false;
            }
            txtID.Focus();
        }
        /// <summary>
        /// �ж��Ƿ��������TEMP_ID
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExisitName(string id)
        {

            DataSet ds = App.GetDataSet("select * from T_TEMP_USER where  TEMP_ID='" + id + "'");
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
            DataSet ds = App.GetDataSet("select * from T_TEMP_USER where NAME='" + name + "'");
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
        ///����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                //��Ч��־

                if (!rbtnValidmark.Checked)
                {
                    mark = "N";
                }
                //ְҵ�ʸ�֤

                if (!rbtnSelected.Checked)
                {
                    prescription = "false";
                }

                if (txtID.Text.Trim() == "")
                {
                    App.Msg("��ʱ�û���Ų���Ϊ��");
                    txtID.Focus();
                    return;
                }

                if (txtName.Text.Trim() == "")
                {
                    App.Msg("���ֱ�����д��");
                    txtName.Focus();
                    return;
                }
                if (cboGender.Text.Trim() == "")
                {
                    App.Msg("�Ա������д");
                    cboGender.Focus();
                    return;
                }
                if (cboCreer.Text.Trim() == "")
                {
                    App.Msg("ְ�Ʊ�����д��");
                    cboCreer.Focus();
                    return;
                }

                //if (txtCertificatename.Text.Trim() == "")
                //{
                //    App.Msg("ִҵ�ʸ�֤�������д��");
                //    txtCertificatename.Focus();
                //    return;
                //}
                //if (txtEmail.Text.Trim() == "")
                //{
                //    App.Msg("Email����Ϊ�գ�");
                //    return;
                //}
                //Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                //if (!regex.IsMatch(txtEmail.Text.Trim()))
                //{
                //    App.Msg("Email���Ϸ���");
                //    return;
                //}
                if (txtToguid_teacher.Text.Trim() == "")
                {
                    App.Msg("ָ����ʦ������д��");
                    txtToguid_teacher.Focus();
                    return;
                }
                if (txtHospital.Text.Trim() == "")
                {
                    App.Msg("����ҽԺ������д��");
                    txtHospital.Focus();
                    return;
                }
                if (txtSchool.Text.Trim() == "")
                {
                    App.Msg("����ѧУ������д��");
                    txtSchool.Focus();
                    return;
                }
                if (txtSpecialized_field.Text.Trim() == "")
                {
                    App.Msg("����רҵ������д��");
                    txtSpecialized_field.Focus();
                    return;
                }
                if (txtBatchno.Text.Trim() == "")
                {
                    App.Msg("ʵϰ���κű�����д��");
                    txtBatchno.Focus();
                    return;
                }
                if (txtNumber.Text.Trim() == "")
                {
                    App.Msg("ѧ�ű�����д��");
                    txtNumber.Focus();
                    return;
                }
                //ͨ��ʱ��
                string Passingtime = dtpPassingtime.Value.ToString("yyyy-MM-dd");
                //��֤ʱ��
                string Leadcard = dtpLeadcard.Value.ToString("yyyy-MM-dd");
                //ע��ʱ��
                string Regdate = dtpRegdate.Value.ToString("yyyy-MM-dd");

                string sql = "";

                if (isSave)
                {
                    if (isExisitName(App.ToDBC(txtID.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���û������ˣ�");
                        txtID.Focus();
                        return;
                    }
                    //else if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    //{
                    //    App.Msg("�Ѿ���������ͬ�����û���ֵ�ˣ�");
                    //    txtName.Focus();
                    //    return;
                    //}

                    sql = "insert into T_TEMP_USER(TEMP_ID,NAME,GENDER,TECH_POST,PHONE,MOBILE_PHONE,EMAIL,ENABLE_FLAG,PROFESSION_CARD,PROF_CARD_NAME,PASS_TIME,RECEIVE_TIME,REGISTER_TIME,TUTOR,ISBELONGTO_HOSPITAL,ISBELONGTO_SCHOOL,SPECIALTY,PRAXIS_NO,STUDY_NO)  values('"
                          + txtID.Text + "','"
                          + txtName.Text + "','"
                          + cboGender.SelectedIndex.ToString() + "','"
                          + cboCreer.SelectedValue + "','"
                          + txtPhone.Text + "','"
                          + txtTelphone.Text + "','"
                          + txtEmail.Text + "','"
                          + mark + "','"
                          + prescription + "','"
                          + txtCertificatename.Text + "',to_timestamp('"
                          + Passingtime + "','syyyy-mm-dd hh24:mi:ss.ff9'),to_timestamp('"
                          + Leadcard + "','syyyy-mm-dd hh24:mi:ss.ff9'),to_timestamp('"
                          + Regdate + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
                          + txtToguid_teacher.Text + "','"
                          + txtHospital.Text + "','"
                          + txtSchool.Text + "','"
                          + txtSpecialized_field.Text + "','"
                          + txtBatchno.Text + "','"
                          + txtNumber.Text + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (temp_id.Trim() != "")
                    {
                        if (txtID.Text.Trim() != temp_id.Trim())
                        {
                            if (isExisitName(App.ToDBC(txtID.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ���û������ˣ�");
                                txtID.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_TEMP_USER  set TEMP_ID='"
                             +txtID.Text+"',NAME='"
                             + App.ToDBC(txtName.Text) + "',GENDER='"
                             + cboGender.SelectedIndex.ToString() + "',TECH_POST='"
                             + cboCreer.SelectedValue + "',PHONE='"
                             + txtPhone.Text + "',MOBILE_PHONE='"
                             + txtTelphone.Text + "',EMAIL='"
                             + txtEmail.Text + "',ENABLE_FLAG='"
                             + mark + "',PROFESSION_CARD='"
                             + prescription + "',PROF_CARD_NAME='"
                             + txtCertificatename.Text + "',PASS_TIME=to_timestamp('"
                             + dtpPassingtime.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),RECEIVE_TIME=to_timestamp('"
                             + dtpLeadcard.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),REGISTER_TIME=to_timestamp('"
                             + dtpRegdate.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),TUTOR='"
                             + txtToguid_teacher.Text + "',ISBELONGTO_HOSPITAL='"
                             + txtHospital.Text + "',ISBELONGTO_SCHOOL='"
                             + txtSchool.Text + "',SPECIALTY='"
                             + txtSpecialized_field.Text + "',PRAXIS_NO='"
                             + txtBatchno.Text + "',STUDY_NO='"
                             + txtNumber.Text + "'  where  TEMP_ID='" + ucGridviewX1.fg["�û�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                    

                }

                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {

                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);
                    }
                //��ʾ�������
                ShowValue();
                //string SQl = T_IntermUser_Sql + "  order by TEMP_ID asc";
                //ucC1FlexGrid1.DataBd(SQl, "TEMP_ID", "TEMP_ID,NAME,GENDER,TECH_POST,TECH_POST_NAME,PHONE,MOBILE_PHONE,EMAIL,ENABLE_FLAG,PROFESSION_CARD,PROF_CARD_NAME,PASS_TIME,RECEIVE_TIME,REGISTER_TIME,TUTOR,ISBELONGTO_HOSPITAL,ISBELONGTO_SCHOOL,SPECIALTY,PRAXIS_NO,STUDY_NO", "�û����,�û�����,�û��Ա�,ְ�Ʊ��,ְ��,�绰,�ֻ�����,�����ַ,��Ч��־,ְҵ�ʸ�֤,�ʸ�֤������,ͨ��ʱ��,��֤ʱ��,ע��ʱ��,ָ����ʦ,����ҽԺ,����ѧУ,��ѧרҵ,ʵϰ���κ�,ѧ��");
            }
            catch (Exception ex)
            {
                App.Msg("���ʧ�ܣ�ԭ��" + ex.ToString() + "");

            }
          
        }
        /// <summary>
        ///���
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
                    txtID.Text = ucGridviewX1.fg["�û�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    temp_id = txtID.Text;
                    txtName.Text = ucGridviewX1.fg["�û�����",ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["�û��Ա�", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                    {
                        cboGender.SelectedIndex = 0;
                    }
                    else
                    {
                        cboGender.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["ְ�Ʊ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboCreer.SelectedValue = ucGridviewX1.fg["ְ�Ʊ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    }
                    txtPhone.Text = ucGridviewX1.fg["�绰", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtTelphone.Text = ucGridviewX1.fg["�ֻ�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtEmail.Text = ucGridviewX1.fg["�����ַ", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["��Ч��־", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��Ч")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }
                    if (ucGridviewX1.fg["ְҵ�ʸ�֤", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                    {
                        rbtnSelected.Checked = true;
                    }
                    else
                    {
                        rbtnNoselected.Checked = true;
                    }
                    txtCertificatename.Text = ucGridviewX1.fg["�ʸ�֤������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    if (ucGridviewX1.fg["ͨ��ʱ��", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpPassingtime.Value = Convert.ToDateTime(ucGridviewX1.fg["ͨ��ʱ��", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["��֤ʱ��", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpLeadcard.Value = Convert.ToDateTime(ucGridviewX1.fg["��֤ʱ��", ucGridviewX1.fg.CurrentRow.Index].Value);
                    }
                    if (ucGridviewX1.fg["ע��ʱ��", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpRegdate.Value = Convert.ToDateTime(ucGridviewX1.fg["ע��ʱ��", ucGridviewX1.fg.CurrentRow.Index].Value);
                    }
                    txtToguid_teacher.Text = ucGridviewX1.fg["ָ����ʦ", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtHospital.Text = ucGridviewX1.fg["����ҽԺ", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtSchool.Text = ucGridviewX1.fg["����ѧУ", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtSpecialized_field.Text = ucGridviewX1.fg["��ѧרҵ", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtBatchno.Text = ucGridviewX1.fg["ʵϰ���κ�", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["ѧ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

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
        /// ɾ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
       
        }
        //int index = 0;
        private void �˺Ź���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (index > 0)
            //{
            //    class_T_ user = new Class_User();
            //    user.User_id = ID;
            //    user.User_name = txtName.Text;
            //    App.frmAccountSetByUser(user);
            //}
            //else
            //{
            //    App.Msg("����û��ѡ��Ҫ�������û�");
            //}
        }
           /// <summary>
        /// ˢ�±��
        /// </summary>
        private void refurbish()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtTelphone.Text = "";
            txtCertificatename.Text = "";
            txtToguid_teacher.Text = "";
            txtHospital.Text = "";
            txtSchool.Text = "";
            txtSpecialized_field.Text = "";
            txtBatchno.Text = "";
            txtNumber.Text = "";
            txtID.Enabled = false;
            txtName.Enabled = false;
            cboGender.Enabled = false;
            cboCreer.Enabled = false;
            txtPhone.Enabled = false;
            txtTelphone.Enabled = false;
            txtEmail.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            rbtnSelected.Enabled = false;
            rbtnNoselected.Enabled = false;
            txtCertificatename.Enabled = false;
            dtpPassingtime.Enabled = false;
            dtpLeadcard.Enabled = false;
            dtpRegdate.Enabled = false;
            txtToguid_teacher.Enabled = false;
            txtHospital.Enabled = false;
            txtSchool.Enabled = false;
            txtSpecialized_field.Enabled = false;
            txtBatchno.Enabled = false;
            txtNumber.Enabled = false;
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
                App.ExecuteSQL("update  T_TEMP_USER  set  ENABLE_FLAG='N' where  TEMP_ID=" + ucGridviewX1.fg["�û�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            //��ʾ�������
            ShowValue();
            refurbish();
        }
        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                chkId.Checked = false;
               
            }
            else
            {
                chkId.Checked = true;
                txtBox.Text = "";
            }
        }

        private void chkId_CheckedChanged(object sender, EventArgs e)
        {
            if (chkId.Checked)
            {
                chkName.Checked = false;
            
            }
            else
            {
                chkName.Checked = true;
                txtBox.Text = "";
             
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
                string Sql = T_IntermUser_Sql+" order by TEMP_ID desc";

                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }
                //������ʱ�û��������в�ѯ
                if (chkName.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_IntermUser_Sql + "  and    a.NAME��like'%" + txtBox.Text.Trim() + "%' order by TEMP_ID desc";

                    }

                }
                //������ʱ�û���Ž��в�ѯ
                else if (chkId.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_IntermUser_Sql + " and  TEMP_ID like'%" + txtBox.Text.Trim() + "%' order by TEMP_ID desc";

                    }
                }

                ucGridviewX1.DataBd(Sql, "�û�����", false, "", "");

                ucGridviewX1.fg.Columns["ְ�Ʊ��"].Visible = false;
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].ReadOnly = true;
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
        ///  ְҵ�ʸ�֤Ϊ���С�ʱ,�ʸ�֤�����ơ�ͨ��ʱ�䡢��֤ʱ�䡢 ע��ʱ��Ϊtrue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSelected.Checked == true)
            {
                txtCertificatename.Enabled = true;
                dtpPassingtime.Enabled = true;
                dtpLeadcard.Enabled = true;
                dtpRegdate.Enabled = true;
            }
        }
        /// <summary>
        /// ְҵ�ʸ�֤Ϊ���ޡ�ʱ,�ʸ�֤�����ơ�ͨ��ʱ�䡢��֤ʱ�䡢 ע��ʱ��Ϊfalse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtnNoselected_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNoselected.Checked == true)
            {
                if (btnCancel.Enabled)
                {
                    txtCertificatename.Enabled = false;
                    dtpPassingtime.Enabled = false;
                    dtpLeadcard.Enabled = false;
                    dtpRegdate.Enabled = false;
                }
            }

        }


        private void txtID_KeyDown(object sender, KeyEventArgs e)
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
                cboGender.Focus();
            }

        }

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCreer.Focus();
            }

        }

        private void cboCreer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPhone.Focus();
            }

        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelphone.Focus();
            }

        }

        private void txtTelphone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }

        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnValidmark.Focus();
            }

        }

        private void rbtnValidmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnSelected.Focus();
            }

        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnSelected.Focus();
            }

        }

        private void rbtnSelected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCertificatename.Focus();
            }

        }

        private void rbtnNoselected_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtToguid_teacher.Focus();
            }

        }

        private void txtCertificatename_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpPassingtime.Focus();
            }

        }

        private void dtpPassingtime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpLeadcard.Focus();
            }

        }

        private void dtpLeadcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpRegdate.Focus();
            }

        }

        private void dtpRegdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtToguid_teacher.Focus();
            }

        }

        private void txtToguid_teacher_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHospital.Focus();
            }

        }

        private void txtHospital_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtSchool.Focus();
            }

        }

        private void txtSchool_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSpecialized_field.Focus();
            }

        }

        private void txtSpecialized_field_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBatchno.Focus();
            }

        }

        private void txtBatchno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNumber.Focus();
            }

        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        
        }

        //private void buttonX1_Click(object sender, EventArgs e)
        //{
        //    test tt = new test();
        //    tt.ucHisUserSearchPatientInfo();
        //}




 
    

  




    }
}