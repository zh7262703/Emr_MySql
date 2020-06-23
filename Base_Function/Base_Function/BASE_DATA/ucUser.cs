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
    public partial class ucUser : UserControl
    {
        bool isSave = false;                 //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID = "";              //�û�ID
        private string mark = "Y";           //��Ч��־
        private string prescription = "true";//ְҵ�ʸ�֤
        private string T_user_sql;           //�û���ѯ
        private string user_number = "";     //��ǰѡ�еĹ���
        private string accounttype = "0";    //�ʺ�����

        DataSet ds;
        public ucUser()
        {
            InitializeComponent();
            T_user_sql = @"select user_id��as �û����,user_num as �û�����,user_name as �û�����,a.shortcut_code ƴ����,(case when gender_code=0 then '��' else 'Ů' end) as �û��Ա�,to_char(birthday,'yyyy-mm-dd ') as ��������," +
                        @"u_tech_post as ְ�Ʊ��,c.name as ְ��,u_seniority as ���ʱ��,f.name as ����,to_char(in_time,'yyyy-mm-dd ')  as ��ְ����,u_position as ְ����,b.name as ְ��,u_recipe_power as ����Ȩ���," +
                        @"g.name as ����Ȩ,section_id as ���ұ��,d.section_name as ��������,sickarea_id as �������,s.sick_area_name as ��������,phone as �绰,email as �����ַ," +
                        @"mobile_phone as �ֻ�����,(case when a.enable='Y' then '��Ч' else '��Ч' end) as ��Ч��־,(case when profession_card='true' then '��' else '��' end) as ְҵ�ʸ�֤," +
                        @"prof_card_name as �ʸ�֤������,to_char(pass_time,'yyyy-mm-dd ') as ͨ��ʱ��,to_char(receive_time,'yyyy-mm-dd ') as ��֤ʱ��," +
                        @"to_char(register_time,'yyyy-mm-dd ') as ע��ʱ��,a.ACCOUNT_TYPE as �û����� from t_userinfo a "+
                        @"left join T_DATA_CODE b on a.u_position=b.id  left join T_DATA_CODE c on a.u_tech_post=c.id left join T_SECTIONINFO d on a.section_id=d.sid  left join T_DATA_CODE f on a.u_seniority=f.id left join T_DATA_CODE g on a.u_recipe_power=g.id left join T_SICKAREAINFO s on a.sickarea_id=s.said "+
                        //@"left join t_account_user au on a.user_id=au.user_id left join t_account acc on acc.account_id = au.account_id"+
                        @" where 1=1 ";//a.enable='Y'";
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("�û���Ϣ");           
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);          
      
            cboGender.SelectedIndex = 0;
            cboCondition.SelectedIndex = 0;
            Bangding();
            professional();
            position();
            Price();
            Prescription();
            Sick();
            RefleshFrm();
            btnLookup_Click(sender, e);
            ucGridviewX1.fg.AllowUserToAddRows=false;
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["�û����"].Visible = false;
                ucGridviewX1.fg.Columns["�û����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].Visible = false;
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ʱ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ʱ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["ְ����"].Visible = false;
                ucGridviewX1.fg.Columns["ְ����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["����Ȩ���"].Visible = false;
                ucGridviewX1.fg.Columns["����Ȩ���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ұ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ұ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        //��ʾ�б�����
        private void ShowValue()
        {
            string SQl = T_user_sql + " order by user_id desc";
            //ds = App.GetDataSet(SQl);
            if (ds != null)
            {
                ucGridviewX1.DataBd(SQl, "�û����", false, "", "");
                ucGridviewX1.fg.Columns["�û����"].Visible = false;
                ucGridviewX1.fg.Columns["�û����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].Visible = false;
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ʱ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ʱ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["ְ����"].Visible = false;
                ucGridviewX1.fg.Columns["ְ����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["����Ȩ���"].Visible = false;
                ucGridviewX1.fg.Columns["����Ȩ���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ұ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ұ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
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
        //��ְ��
        private void position()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='2'");
            cboCreers.DataSource = ds.Tables[0].DefaultView;
            cboCreers.ValueMember = "ID";
            cboCreers.DisplayMember = "NAME";
        }
        //������
        private void Price()
        {

            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='6'");
            cboPrice.DataSource = ds.Tables[0].DefaultView;
            cboPrice.ValueMember = "ID";
            cboPrice.DisplayMember = "NAME";
        }
        //�󶨴���Ȩ
        private void Prescription()
        {

            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='7' order by ID asc");
            cboPrescription.DataSource = ds.Tables[0].DefaultView;
            cboPrescription.ValueMember = "ID";
            cboPrescription.DisplayMember = "NAME";
        }

        private void Prescriptions()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='7' and id>59");
            cboPrescription.DataSource = ds.Tables[0].DefaultView;
            cboPrescription.ValueMember = "ID";
            cboPrescription.DisplayMember = "NAME";
        }
        //����������
        private void Bangding()
        {
            DataSet dt = App.GetDataSet("select * from T_SECTIONINFO a inner join T_SECTION_AREA b on a.sid=b.sid where ENABLE_FLAG='Y' order by section_name,a.sid");
            cboOffice.DataSource = dt.Tables[0].DefaultView;
            cboOffice.ValueMember = "SID";
            cboOffice.DisplayMember = "SECTION_NAME";
        }
        //����������
        private void Sick()
        {
            try
            {
                DataSet dt = App.GetDataSet("select b.* from T_SECTION_AREA  g inner join t_sickareainfo b on b.said=g.said where g.sid='" + cboOffice.SelectedValue + "' and ENABLE_FLAG='Y' ");
                cboSick.DataSource = dt.Tables[0].DefaultView;
                cboSick.ValueMember = "SAID";
                cboSick.DisplayMember = "SICK_AREA_NAME";
            }
            catch
            {

            }
        }

        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtShortCode.Enabled = false;
            cboGender.Enabled = false;
            dtpBirthday.Enabled = false;
            cboCreer.Enabled = false;
            cboPrice.Enabled = false;
            dtpAppointment.Enabled = false;
            cboCreers.Enabled = false;
            cboOffice.Enabled = false;
            cboSick.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtTelphone.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            rbtnSelected.Enabled = false;
            rbtnNoselected.Enabled = false;
            txtCertificatename.Enabled = false;
            dtpPassingtime.Enabled = false;
            dtpLeadcard.Enabled = false;
            dtpRegdate.Enabled = false;
            cboPrescription.Enabled = false;
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
                txtShortCode.Text = "";
                //cboSick.Text = "";
                txtPhone.Text = "";
                txtEmail.Text = "";
                txtTelphone.Text = "";
                txtCertificatename.Text = "";
            }
            txtShortCode.Enabled = true;
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            cboGender.Enabled = true;
            dtpBirthday.Enabled = true;
            cboCreer.Enabled = true;
            cboPrice.Enabled = true;
            dtpAppointment.Enabled = true;
            cboCreers.Enabled = true;
            cboOffice.Enabled = true;
            cboSick.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            txtTelphone.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            rbtnSelected.Enabled = true;
            rbtnNoselected.Enabled = true;
            txtCertificatename.Enabled = true;
            dtpPassingtime.Enabled = true;
            dtpLeadcard.Enabled = true;
            dtpRegdate.Enabled = true;
            cboPrescription.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            btnAddTempUser.Enabled = false;
            if (rbtnSelected.Checked == true)
            {
                txtCertificatename.Enabled = true;
                dtpPassingtime.Enabled = true;
                dtpLeadcard.Enabled = true;
                dtpRegdate.Enabled = true;
                Prescription();
            }
            else
            {
                txtCertificatename.Enabled = false;
                dtpPassingtime.Enabled = false;
                dtpLeadcard.Enabled = false;
                dtpRegdate.Enabled = false;
                Prescriptions();
            }



            //if (Convert.ToInt32( cboCreer.SelectedValue.ToString()) ==5)
            //{
            //    if (Convert.ToInt32(cboCreers.SelectedIndex.ToString()) ==27 )
            //    {
            //        Prescriptions();
            //    }
            //}
            txtNumber.Focus();
        }

        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string id)
        {

            DataSet ds = App.GetDataSet("select * from t_userinfo where  USER_NUM='" + id + "'");
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
            DataSet ds = App.GetDataSet("select * from t_userinfo where USER_NAME='" + name + "'");
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
            accounttype = "0";
            isSave = true;
            Edit(isSave);
            txtNumber.ReadOnly = false;
            for (int i = 0; i < cboCreers.Items.Count; i++)
            {
                DataRowView drv = cboCreers.Items[i] as DataRowView;
                if (drv["NAME"].ToString() == "��ְͨ��")
                {
                    cboCreers.SelectedItem = cboCreers.Items[i];
                }
            }
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

                //��Ч��־

                if (!rbtnValidmark.Checked)
                {
                    mark = "N";
                }
                else
                {
                    mark = "Y";
                }
                //ְҵ�ʸ�֤

                if (!rbtnSelected.Checked)
                {
                    prescription = "false";
                }
                else
                {
                    prescription = "true";
                }

                if (txtNumber.Text.Trim() == "")
                {
                    App.Msg("�û����Ų���Ϊ��");
                    txtNumber.Focus();
                    return;
                }

                if (txtName.Text.Trim() == "")
                {
                    App.Msg("�û����ֱ�����д��");
                    txtName.Focus();
                    return;
                }


                if (cboGender.Text.Trim() == ""|| cboGender.SelectedIndex < 0)
                {
                    App.Msg("�Ա������д");
                    cboGender.Focus();
                    return;
                }
                if (cboCreer.Text.Trim() == "" || cboCreer.SelectedIndex < 0)
                {
                    App.Msg("ְ�Ʊ�����д��");
                    cboCreer.Focus();
                    return;
                }
                if (cboCreers.Text.Trim() == "" || cboCreers.SelectedIndex < 0)
                {
                    App.Msg("ְ�������д��");
                    cboCreers.Focus();
                    return;
                }
                if (cboOffice.Text.Trim() == "" || cboOffice.SelectedIndex < 0)
                {
                    App.Msg("�������ұ�����д��");
                    cboOffice.Focus();
                    return;
                }


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

                if (cboPrescription.Text.Trim() == "")
                {
                    App.Msg("����Ȩ������д��");
                    cboPrescription.Focus();
                    return;
                }

                //��������
                string Birthday = dtpBirthday.Value.ToString("yyyy-MM-dd");
                //��ְ����
                string Appointment = dtpAppointment.Value.ToString("yyyy-MM-dd");
                //ͨ��ʱ��
                string Passingtime = dtpPassingtime.Value.ToString("yyyy-MM-dd");
                //��֤ʱ��
                string Leadcard = dtpLeadcard.Value.ToString("yyyy-MM-dd");
                //ע��ʱ��
                string Regdate = dtpRegdate.Value.ToString("yyyy-MM-dd");


                string sql = "";
                ID = App.GenId("t_userinfo", "USER_ID").ToString();

                if (isSave)
                {

                    if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�û��Ĺ����ˣ�");
                        txtNumber.Focus();
                        return;
                    }
                    //else if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    //{
                    //    App.Msg("�Ѿ���������ͬ�����û��������ˣ�");
                    //    //txtName.Focus();
                    //    return;
                    //}

                    sql = "insert into t_userinfo(User_Id,User_Num,User_Name,Gender_Code,Birthday,U_Tech_Post,U_Seniority,In_Time,U_Position,U_Recipe_Power,Section_Id,Sickarea_Id,Phone,Email,Mobile_Phone,Enable,Profession_Card,Prof_Card_Name,Pass_Time,Receive_Time,Register_Time,ACCOUNT_TYPE,SHORTCUT_CODE)  values("
                          + ID + ",'"
                          + App.ToDBC(txtNumber.Text) + "','"
                          + App.ToDBC(txtName.Text) + "','"
                          + cboGender.SelectedIndex.ToString() + "',to_timestamp('"
                          + Birthday + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
                          + cboCreer.SelectedValue + "','"
                          + cboPrice.SelectedValue + "',to_timestamp('"
                          + Appointment + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
                          + cboCreers.SelectedValue + "','"
                          + cboPrescription.SelectedValue + "','"
                          + cboOffice.SelectedValue + "','"
                          + cboSick.SelectedValue + "','"
                          + txtPhone.Text + "','"
                          + txtEmail.Text + "','"
                          + txtTelphone.Text + "','"
                          + mark + "','"
                          + prescription + "','"
                          + txtCertificatename.Text + "',to_timestamp('"
                          + Passingtime + "','syyyy-mm-dd hh24:mi:ss.ff9'),to_timestamp('"
                          + Leadcard + "','syyyy-mm-dd hh24:mi:ss.ff9'),to_timestamp('"
                          + Regdate + "','syyyy-mm-dd hh24:mi:ss.ff9'),'" + accounttype + "','" + txtShortCode.Text + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (user_number.Trim() != "")
                    {
                        if (txtNumber.Text.Trim() != user_number.Trim())
                        {
                            if (isExisitName(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�û��Ĺ����ˣ�");
                                txtNumber.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update t_userinfo set User_Num='"
                             + App.ToDBC(txtNumber.Text) + "', User_Name='"
                             + App.ToDBC(txtName.Text) + "',Gender_Code='"
                             + cboGender.SelectedIndex.ToString() + "',Birthday=to_timestamp('"
                             + dtpBirthday.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),U_Tech_Post='"
                             + cboCreer.SelectedValue + "',U_Seniority='"
                             + cboPrice.SelectedValue + "',In_Time=to_timestamp('"
                             + dtpAppointment.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),U_Position='"
                             + cboCreers.SelectedValue + "',U_Recipe_Power='"
                             + cboPrescription.SelectedValue + "',Section_Id='"
                             + cboOffice.SelectedValue + "',Sickarea_Id='"
                             + cboSick.SelectedValue + "',Phone='"
                             + txtPhone.Text + "',Email='"
                             + txtEmail.Text + "',Mobile_Phone='"
                             + txtTelphone.Text + "',Enable='"
                             + mark + "',Profession_Card='"
                             + prescription + "',Prof_Card_Name='"
                             + txtCertificatename.Text + "',Pass_Time=to_timestamp('"
                             + dtpPassingtime.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),Receive_Time=to_timestamp('"
                             + dtpLeadcard.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),Register_Time=to_timestamp('"
                             + dtpRegdate.Value.ToString("yyyy-MM-dd") + "','syyyy-mm-dd hh24:mi:ss.ff9'),ACCOUNT_TYPE='" + accounttype + "',shortcut_code='" + txtShortCode.Text + "'  where User_Id=" + ucGridviewX1.fg["�û����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";
                    btnUpdate_Click(sender, e);
                    
                }

                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        App.SynchronizationDataBase(App.CurrentHospitalId.ToString(), sql);
                        btnCancel_Click(sender, e);
                        btnLookup_Click(sender, e);
                    }
                //��ʾ�б�����
                ShowValue();
                //string SQl = T_user_sql + "  order by User_Id asc";
                //ucC1FlexGrid1.DataBd(SQl, "User_Id", "User_Id,User_Num,User_Name,Gender_Code,Birthday,U_Tech_Post,u_tech_post_name,U_Seniority,u_seniority_name,In_Time,U_Position,u_position_name,U_Recipe_Power,u_recipe_power_name,Section_Id,section_id_name,Sickarea_Id,sickarea_id_name,Phone,Email,Mobile_Phone,Enable,Profession_Card,Prof_Card_Name,Pass_Time,Receive_Time,Register_Time", "�û����,�û�����,�û�����,�û��Ա�,��������,ְ�Ʊ��,ְ��,���ʱ��,����,��ְ����,ְ����,ְ��,����Ȩ���,����Ȩ,���ұ��,��������,�������,��������,�绰,�����ַ,�ֻ�����,��Ч��־,ְҵ�ʸ�֤,�ʸ�֤������,ͨ��ʱ��,��֤ʱ��,ע��ʱ��");         
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
        /// ˢ�±��
        /// </summary>
        private void refurbish()
        {
            //txtNumber.Text = "";
            //txtName.Text = "";
            ////cboSick.Text = "";
            //txtPhone.Text = "";
            //txtEmail.Text = "";
            //txtTelphone.Text = "";
            //txtCertificatename.Text = "";
            ucC1FlexGrid1_Click(null, null);
            txtNumber.Enabled = false;
            txtShortCode.Enabled = false;
            txtName.Enabled = false;
            cboGender.Enabled = false;
            dtpBirthday.Enabled = false;
            cboCreer.Enabled = false;
            cboPrice.Enabled = false;
            dtpAppointment.Enabled = false;
            cboCreers.Enabled = false;
            cboOffice.Enabled = false;
            cboSick.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtTelphone.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            rbtnSelected.Enabled = false;
            rbtnNoselected.Enabled = false;
            txtCertificatename.Enabled = false;
            dtpPassingtime.Enabled = false;
            dtpLeadcard.Enabled = false;
            dtpRegdate.Enabled = false;
            cboPrescription.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            btnAddTempUser.Enabled = true;
            //groupBox1.Enabled = true;

        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {

            DataSet ds = App.GetDataSet("select Count(*) from t_account_user where USER_ID=" + ucGridviewX1.fg["�û����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            if (ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
            {
                if (App.Ask("���Ƿ�Ҫɾ��"))
                {
                    App.ExecuteSQL("update  t_userinfo  set enable='N' where  User_Id='" + ucGridviewX1.fg["�û����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");
                }
            }
            else
            {
                if (App.Ask("���û���Ϣ�Ѿ����˺Ź����������������ǡ�ɾ���û����������!"))
                    App.ExecuteSQL("update  t_userinfo  set enable='N' where  User_Id='" + ucGridviewX1.fg["�û����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");


            }


            //��ʾ�б�����
            ShowValue();
            refurbish();
            //btnCancel_Click(sender,e);
            //string SQl = T_user_sql + "  order by User_Id asc";
            //ucC1FlexGrid1.DataBd(SQl, "User_Id", "User_Id,User_Num,User_Name,Gender_Code,Birthday,U_Tech_Post,u_tech_post_name,U_Seniority,u_seniority_name,In_Time,U_Position,u_position_name,U_Recipe_Power,u_recipe_power_name,Section_Id,section_id_name,Sickarea_Id,sickarea_id_name,Phone,Email,Mobile_Phone,Enable,Profession_Card,Prof_Card_Name,Pass_Time,Receive_Time,Register_Time", "�û����,�û�����,�û�����,�û��Ա�,��������,ְ�Ʊ��,ְ��,���ʱ��,����,��ְ����,ְ����,ְ��,����Ȩ���,����Ȩ,���ұ��,��������,�������,��������,�绰,�����ַ,�ֻ�����,��Ч��־,ְҵ�ʸ�֤,�ʸ�֤������,ͨ��ʱ��,��֤ʱ��,ע��ʱ��");  
        }

        int index = 0;
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (index >= 0)
            {
                btnDelete_Click(sender, e);
            }
            else
            {
                App.Msg("����û��ѡ��Ҫ�������û�");
            }
        }

        int Rowcount = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (ucGridviewX1.fg.Rows.Count >= 0)
                {
                    index = ucGridviewX1.fg.CurrentRow.Index;
                    ID = ucGridviewX1.fg["�û����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["�û�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    user_number = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["�û�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtShortCode.Text = ucGridviewX1.fg["ƴ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["�û��Ա�", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                    {
                        cboGender.SelectedIndex = 0;
                    }
                    else
                    {
                        cboGender.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpBirthday.Value = Convert.ToDateTime(ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["ְ�Ʊ��", ucGridviewX1.fg.CurrentRow.Index].Value != null)
                    {
                        cboCreer.SelectedValue = ucGridviewX1.fg["ְ�Ʊ��", ucGridviewX1.fg.CurrentRow.Index].Value;
                    }
                    if (ucGridviewX1.fg["���ʱ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboPrice.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["���ʱ��",ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    if (ucGridviewX1.fg["��ְ����",ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpAppointment.Value = Convert.ToDateTime(ucGridviewX1.fg["��ְ����", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["ְ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboCreers.SelectedValue = ucGridviewX1.fg["ְ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    }
                    if (ucGridviewX1.fg["����Ȩ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboPrescription.SelectedValue = ucGridviewX1.fg["����Ȩ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    }
                    if (ucGridviewX1.fg["���ұ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboOffice.SelectedValue = Convert.ToInt64(ucGridviewX1.fg["���ұ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    if (ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboSick.SelectedValue = Convert.ToInt64(ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    txtPhone.Text = ucGridviewX1.fg["�绰", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtEmail.Text = ucGridviewX1.fg["�����ַ", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtTelphone.Text = ucGridviewX1.fg["�ֻ�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
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
                    accounttype = ucGridviewX1.fg["�û�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

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
                    //        if (Rowcount > 0 && ucC1FlexGrid1.fg.Rows.Count >= Rowcount)
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
                string SQl = T_user_sql + " order by user_id desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }
                //���û��������в�ѯ
                if (cboCondition.SelectedIndex == 0)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and   User_Name��like'%" + txtBox.Text.Trim() + "%' order by User_Id desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                //���û����Ž��в�ѯ
                else if (cboCondition.SelectedIndex == 1)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and  user_num  like'%" + txtBox.Text.Trim() + "%' order by User_Id desc";
                    }
                }
                //���������ƽ��в�ѯ
                else if (cboCondition.SelectedIndex == 2)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and  ��s.sick_area_name  like'%" + txtBox.Text.Trim() + "%' order by User_Id desc";
                    }
                }
                //�����ҽ��в�ѯ
                else if (cboCondition.SelectedIndex == 3)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and  ��d.section_name  like'%" + txtBox.Text.Trim() + "%' order by User_Id asc";
                    }
                }
                //��ְ�ƽ��в�ѯ
                else if (cboCondition.SelectedIndex == 4)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_user_sql + "  and ��c.name  like'%" + txtBox.Text.Trim() + "%' order by User_Id asc";
                    }
                }
                ucGridviewX1.DataBd(SQl, "�û����", false, "", "");
                ucGridviewX1.fg.Columns["�û����"].Visible = false;
                ucGridviewX1.fg.Columns["�û����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].Visible = false;
                ucGridviewX1.fg.Columns["ְ�Ʊ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ʱ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ʱ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["ְ����"].Visible = false;
                ucGridviewX1.fg.Columns["ְ����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["����Ȩ���"].Visible = false;
                ucGridviewX1.fg.Columns["����Ȩ���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ұ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ұ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch(Exception ex)
            {
                //App.MsgWaring(ex.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnLookup.Enabled = true;
            }
        }

        private void �˺Ź���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (index >= 0)
            {
                Class_User user = new Class_User();
                user.User_id = ID;
                user.User_name = txtName.Text;
                user.User_num = txtNumber.Text;
                user.Accounttype = accounttype;
                App.frmAccountSetByUser(user);
            }
            else
            {
                App.Msg("����û��ѡ��Ҫ�������û�");
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
                cboGender.Focus();
            }


        }

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpBirthday.Focus();
            }

        }

        private void dtpBirthday_KeyDown(object sender, KeyEventArgs e)
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
                cboPrice.Focus();
            }
        }

        private void cboPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpAppointment.Focus();
            }

        }

        private void dtpAppointment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboCreers.Focus();
            }

        }

        private void cboCreers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboOffice.Focus();
            }

        }

        private void cboOffice_KeyDown(object sender, KeyEventArgs e)
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
                cboPrescription.Focus();
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
                cboPrescription.Focus();
            }

        }

        private void cboPrescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void rbtnSelected_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSelected.Checked == true)
            {
                txtCertificatename.Enabled = true;
                dtpPassingtime.Enabled = true;
                dtpLeadcard.Enabled = true;
                dtpRegdate.Enabled = true;
                Prescription();
            }
        }

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
                    Prescriptions();
                }
            }
        }

        private void cboOffice_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sick();
        }

        /// <summary>
        /// �����ʱ�ʺ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTempUser_Click(object sender, EventArgs e)
        {
            accounttype = "1";
            isSave = true;
            Edit(isSave);

            txtNumber.ReadOnly = true;
            txtNumber.Text = GenTempAccount();
        }

        /// <summary>
        /// �Զ�������ʱ�ʺţ����ţ�
        /// </summary>
        /// <returns></returns>
        private string GenTempAccount()
        {
            string sql1 = "select t.user_num from t_userinfo t where t.user_num='T00000001'";
            DataSet ds = App.GetDataSet(sql1);
            string account = "T";
            if (ds.Tables[0].Rows.Count > 0)
            {
                string sql2 = "select max(t.user_num) as num from t_userinfo t where Length(t.user_num)=9";
                string num = App.ReadSqlVal(sql2, 0, "num");

                int tempindex = Convert.ToInt32(num.Replace("T", ""));
                tempindex = tempindex + 1;

                for (int i = 0; i < 8 - tempindex.ToString().Length; i++)
                {
                    account = account + "0";
                }
                account = account + tempindex.ToString();
            }
            else
            {
                account = "T00000001";
            }
            return account;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtShortCode.Text = App.getSpell(txtName.Text).ToUpper();
        }

        private void ucGridviewX1_Load(object sender, EventArgs e)
        {

        }

    }
}









