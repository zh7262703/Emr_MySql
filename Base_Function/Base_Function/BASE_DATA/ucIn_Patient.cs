using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using System.Collections;

namespace Base_Function.BASE_DATA
{
    public partial class ucIn_Patient : UserControl
    {
        bool IsSave = false;         //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID = "";        //����ID
        private string Inpaint_Sql;  //������Ϣ��ѯ
        private string pids = "";    //��ǰѡ�еĲ���סԺ��
        public ucIn_Patient()
        {
            InitializeComponent();
            Inpaint_Sql = @"select ID as ���,PATIENT_NAME as ��������,NAME_PINYIN  as ƴ��," +
                      @"(case when GENDER_CODE=0 then '��' else 'Ů' end) as �Ա�,AGE as ����,AGE_UNIT as ���䵥λ," +
                      @"to_char(BIRTHDAY,'yyyy-MM-dd') as ��������,PID as ����סԺ��,SECTION_ID as ��ǰ���ұ��,SECTION_NAME as ��ǰ����,sick_area_id as ��ǰ�������," +
                      @"sick_area_name as ��ǰ����,to_char(IN_TIME,'yyyy-MM-dd hh24:mi') as סԺʱ��,CARD_ID as ����Ψһ���� from T_IN_PATIENT ";
        }
        //public static WebReferenceHIS.Service sv = new Bifrost_Nurse.WebReferenceHIS.Service();

        private void frmIn_Patient_Load(object sender, EventArgs e)
        {
            try
            {
                //App.SetMainFrmMsgToolBarText("������Ϣ");
                //��ʾ�б�����
                ShowValue();

                ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                //ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
                ucGridviewX1.fg.AllowUserToAddRows = false;
                ucGridviewX1.fg.ContextMenuStrip = contextMenuStrip1;
                cboGender.SelectedIndex = 0;
                //�󶨵�ǰ����
                CuSick();
                //�����䵥λ
                AgeUint();
                //�󶨿���
                Cusection();
                RefleshFrm();
            }
            catch
            {
            }


        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��ǰ���ұ��"].Visible = false;
                ucGridviewX1.fg.Columns["��ǰ���ұ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��ǰ�������"].Visible = false;
                ucGridviewX1.fg.Columns["��ǰ�������"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        DataSet ds;
        //��ʾ�б�����
        private void ShowValue()
        {
            try
            {
                string SQl = Inpaint_Sql + " order by IN_TIME desc";
                ds = App.GetDataSet(SQl);
                if (ds != null)
                {
                    ucGridviewX1.DataBd(SQl, "סԺʱ��", false, "", "");
                    ucGridviewX1.fg.Columns["���"].Visible = false;
                    ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                    ucGridviewX1.fg.Columns["��ǰ���ұ��"].Visible = false;
                    ucGridviewX1.fg.Columns["��ǰ���ұ��"].ReadOnly = true;
                    ucGridviewX1.fg.Columns["��ǰ�������"].Visible = false;
                    ucGridviewX1.fg.Columns["��ǰ�������"].ReadOnly = true;
                    ucGridviewX1.fg.ReadOnly = true;
                }
            }
            catch
            { }
        }
        ///// <summary>
        ///// ���ʱ��Ϊ��ǰʱ��ʱ����Ĭ��Ϊһ��
        ///// </summary>
        // private void datetime()
        // {
        //     int ages = 1;
        //     string agesunit = "��";
        //     if (dtpDatetime.Value.Year == dtpBirthday.Value.Year)
        //     {

        //         if (dtpDatetime.Value.Month == dtpDatetime.Value.Month)
        //         {
        //             if (dtpDatetime.Value.Day == dtpBirthday.Value.Day)
        //             {
        //                 txtAge.Text = ages.ToString();
        //                 cboAgeunit.Text =agesunit;

        //             }
        //         }
        //     }
        // }
        /// <summary>
        /// ����ʱ��ı仯�Ӷ��õ����˵�����
        /// </summary>
        private void stamp()
        {
            //int incount;
            //string ageunit = "��";
            //if(dtpDatetime.Value.Year==dtpBirthday.Value.Year)
            //{
            //    if(dtpDatetime.Value.Month==dtpDatetime.Value.Month)
            //    {
            //        ��
            //        if (dtpDatetime.Value.Day == dtpBirthday.Value.Day)
            //        {
            //            incount = 1;
            //            ageunit = "��";
            //        }
            //        else
            //        {
            //            incount = dtpDatetime.Value.Day - dtpBirthday.Value.Day;
            //            ageunit = "��";
            //        }
            //    }
            //    else
            //    {
            //        ��
            //        incount=dtpDatetime.Value.Month-dtpBirthday.Value.Month;
            //        ageunit = "��";
            //    }
            //}
            //else
            //{
            //    if (dtpDatetime.Value.Month == dtpDatetime.Value.Month)
            //    {
            //        if (dtpDatetime.Value.Day == dtpBirthday.Value.Day)
            //        {
            //            incount = dtpDatetime.Value.Year - dtpBirthday.Value.Year;
            //        }
            //    }

            //    incount=dtpDatetime.Value.Year-dtpBirthday.Value.Year;
            //    ��
            //}

            //string  date = Convert.ToDateTime(dtpBirthday.Value.ToShortDateString());
            // string  date1 = Convert.ToDateTime(dtpDateTime.Value.ToString("yyyy-MM-dd"));
            TimeSpan sp = new TimeSpan();
            sp = dtpDatetime.Value - dtpBirthday.Value;
            int indaycount;
            int incount;
            string ageunit = "��";
            indaycount = sp.Days;
            if (indaycount >= 365)
            {
                if (indaycount == 365)
                {
                    incount = 1;
                }
                else
                {
                    incount = indaycount / 365;
                }
            }
            else
            {
                if (indaycount >= 30)
                {
                    if (indaycount == 30)
                    {
                        incount = 1;
                        ageunit = "��";
                    }
                    else
                    {
                        incount = indaycount / 30;
                        ageunit = "��";
                    }
                }
                else
                {

                    incount = indaycount;
                    ageunit = "��";
                }
            }

            txtAge.Text = incount.ToString();
            cboAgeunit.Text = ageunit;
        }
        //�󶨵�ǰ����
        private void Cusick()
        {
            try
            {
                DataSet ds = App.GetDataSet("select b.* from T_SECTION_AREA  g inner join  T_SICKAREAINFO b on b.said=g.said  where g.sid='" + cboCusection.SelectedValue + "' and  b.ENABLE_FLAG='Y' and  b.ISBELONGTOSECTION='N'");
                cboCusick.DataSource = ds.Tables[0].DefaultView;
                cboCusick.ValueMember = "SAID";
                cboCusick.DisplayMember = "SICK_AREA_NAME";
            }
            catch
            {
            }
        }
        //�����䵥λ
        private void AgeUint()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='37'order by ID asc");

            cboAgeunit.DataSource = ds.Tables[0].DefaultView;
            cboAgeunit.ValueMember = "ID";
            cboAgeunit.DisplayMember = "NAME";
        }
        //�󶨵�ǰ����
        private void Cusection()
        {
            DataSet dt = App.GetDataSet("select * from T_SECTIONINFO where ENABLE_FLAG='Y' and ISBELONGTOBIGSECTION='N'");
            cboCusection.DataSource = dt.Tables[0].DefaultView;
            cboCusection.ValueMember = "SID";
            cboCusection.DisplayMember = "SECTION_NAME";
        }
        private void CuSick()
        {
            DataSet dt = App.GetDataSet("select * from T_SICKAREAINFO  where ISBELONGTOSECTION='N'and ENABLE_FLAG='Y'");
            cboCusick.DataSource = dt.Tables[0].DefaultView;
            cboCusick.ValueMember = "SAID";
            cboCusick.DisplayMember = "SICK_AREA_NAME";
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {

            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtPiyin.Enabled = false;
            dtpBirthday.Enabled = false;
            cboGender.Enabled = false;
            txtAge.Enabled = false;
            cboCusection.Enabled = false;
            cboAgeunit.Enabled = false;
            cboCusick.Enabled = false;
            dtpDatetime.Enabled = false;
            txtCardId.Enabled = false;
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
                txtNumber.Text = "";
                txtName.Text = "";
                txtAge.Text = "";

            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            txtPiyin.Enabled = true;
            dtpBirthday.Enabled = true;
            cboGender.Enabled = true;
            txtAge.Enabled = false;
            cboAgeunit.Enabled = false;
            cboCusection.Enabled = true;
            cboCusick.Enabled = true;
            dtpDatetime.Enabled = true;
            txtCardId.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (dtpBirthday.Enabled == true)
            {
                stamp();
            }
            txtNumber.Focus();

        }
        /// <summary>
        /// �ж��Ƿ��������ID
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExisitNames(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_IN_PATIENT  where PID='" + id + "'");
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
        private bool IsExisitName(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_IN_PATIENT where  PATIENT_NAME='" + name + "'");
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
            IsSave = true;
            Edit(IsSave);
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsSave = false;
            Edit(IsSave);
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
                    App.Msg("����סԺ�Ų���Ϊ�գ�");
                    txtNumber.Focus();
                    return;

                }
                else if (txtName.Text.Trim() == "")
                {
                    App.Msg("������������Ϊ�գ�");
                    txtName.Focus();
                    return;

                }
                //else if (cboCusection.Text.Trim() == "")
                //{
                //    App.Msg("��ǰ���Ҳ���Ϊ�գ�");
                //    cboCusection.Focus();
                //    return;

                //}
                //else if (cboCusick.Text.Trim() == "")
                //{
                //    App.Msg("��ǰ��������Ϊ�գ�");
                //    cboCusick.Focus();
                //    return;

                //}
                else if (txtAge.Text.Trim() == "")
                {
                    App.Msg("���䲻��Ϊ�գ�");
                    txtAge.Focus();
                    return;
                }
                else if (cboAgeunit.Text.Trim() == "")
                {
                    App.Msg("���䵥λ����Ϊ�գ�");
                    cboAgeunit.Focus();
                    return;
                }

                string birthday = dtpBirthday.Value.ToString("yyyy-MM-dd ");
                string datetime = dtpDatetime.Value.ToString("yyyy-MM-dd HH:mm");
                string sql = "";


                ID = App.GenId("T_IN_PATIENT ", "ID").ToString();

                if (IsSave)
                {
                    //if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                    //{
                    //    App.Msg("�Ѿ���������ͬ���ƵĲ���סԺ���ˣ�");
                    //    txtNumber.Focus();
                    //    return;
                    //}
                    //if (IsExisitName(App.ToDBC(txtName.Text.Trim())))
                    //{
                    //    App.Msg("������Ϣ���Ѿ�����ͬ�������ˣ�");
                    //    txtName.Focus();
                    //    return;
                    //}
                    sql = "insert into T_IN_PATIENT(ID,PATIENT_NAME,NAME_PINYIN,GENDER_CODE,BIRTHDAY,PID,AGE,AGE_UNIT,SECTION_ID,SECTION_NAME,INSECTION_ID,INSECTION_NAME,IN_AREA_ID,IN_AREA_NAME,SICK_AREA_ID,SICK_AREA_NAME,IN_TIME,CARD_ID) values('"
                         + ID + "','"
                         + txtName.Text + "','"
                         + txtPiyin.Text + "','"
                         + cboGender.SelectedIndex.ToString() + "',to_timestamp('"
                         + birthday + "','syyyy-mm-dd '),'"
                         + txtNumber.Text + "','"
                         + txtAge.Text + "','"
                         + cboAgeunit.Text + "','"
                         + cboCusection.SelectedValue + "','"
                         + cboCusection.Text + "','"
                         + cboCusection.SelectedValue + "','"
                         + cboCusection.Text + "','"
                         + cboCusick.SelectedValue + "','"
                         + cboCusick.Text + "','"
                         + cboCusick.SelectedValue + "','"
                         + cboCusick.Text + "',to_timestamp('"
                         + datetime + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
                         + txtCardId.Text + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (pids.Trim() != null)
                    {
                        if (txtNumber.Text.Trim() != pids.Trim())
                        {
                            if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ���ƵĲ���סԺ���ˣ�");
                                txtNumber.Focus();
                                return;
                            }
                        }
                    }
                    //
                    string in_patient = "";
                    sql = "update T_IN_PATIENT set PATIENT_NAME='"
                              + txtName.Text + "',NAME_PINYIN='"
                              + txtPiyin.Text + "',GENDER_CODE='"
                              + cboGender.SelectedIndex.ToString() + "',BIRTHDAY=to_timestamp('"
                              + birthday + "','syyyy-mm-dd hh24:mi:ss.ff9'),PID='"
                              + txtNumber.Text + "',AGE='"
                              + txtAge.Text + "',AGE_UNIT='"
                              + cboAgeunit.Text + "',SECTION_ID='"
                              + cboCusection.SelectedValue + "',SECTION_NAME='"
                              + cboCusection.Text + "',SICK_AREA_ID='"
                              //+ cboCusection.Text + "',INSECTION_ID='"
                              //+ cboCusection.SelectedValue + "',INSECTION_NAME='"
                              //+ cboCusection.Text + "',IN_AREA_ID='"
                              //+ cboCusick.SelectedValue + "',IN_AREA_NAME='"
                              //+ cboCusick.Text + "',SICK_AREA_ID='"
                              + cboCusick.SelectedValue + "',SICK_AREA_NAME='"
                              + cboCusick.Text + "',IN_TIME=to_timestamp('"
                              + datetime + "','syyyy-mm-dd hh24:mi:ss.ff9'),CARD_ID='"
                              + txtCardId.Text + "'  where ID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";

                }
                if (sql != "")
                {
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);

                    }
                }
                ShowValue();
                //string SQl = Inpaint_Sql;
                //ucC1FlexGrid1.DataBd(SQl, "ID", "ID,PATIENT_NAME,NAME_PINYIN,GENDER_CODE,AGE,AGE_UNIT,BIRTHDAY,PID,SECTION_ID,SECTION_NAME,IN_AREA_ID,IN_AREA_NAME,IN_TIME", "���,��������,ƴ��,�Ա�,����,���䵥λ,��������,����סԺ��,��ǰ���ұ��,��ǰ����,��ǰ�������,��ǰ����,��Ժ����");
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
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {

                if (ucGridviewX1.fg.Rows.Count >0)
                {
                    ID = ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtNumber.Text = ucGridviewX1.fg["����סԺ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    pids = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtAge.Text = ucGridviewX1.fg["����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["���䵥λ", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        cboAgeunit.Text = ucGridviewX1.fg["���䵥λ", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    } txtPiyin.Text = ucGridviewX1.fg["ƴ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpBirthday.Value = Convert.ToDateTime(ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["סԺʱ��", ucGridviewX1.fg.CurrentRow.Index].Value != DBNull.Value)
                    {
                        dtpDatetime.Value = Convert.ToDateTime(ucGridviewX1.fg["סԺʱ��", ucGridviewX1.fg.CurrentRow.Index].Value);

                    }
                    if (ucGridviewX1.fg["��ǰ���ұ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboCusection.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["��ǰ���ұ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());
                    }
                    if (ucGridviewX1.fg["��ǰ�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboCusick.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["��ǰ�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());
                    }
                    if (ucGridviewX1.fg["�Ա�", ucGridviewX1.fg.CurrentRow.Index].ToString() == "��")
                    {
                        cboGender.SelectedIndex = 0;

                    }
                    else
                    {
                        cboGender.SelectedIndex = 1;

                    }

                    txtCardId.Text = ucGridviewX1.fg["����Ψһ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtPiyin.Text = App.getSpell(App.ToDBC(txtName.Text.Trim()));
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
                string SQl = Inpaint_Sql + "order by IN_TIME desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }
                //���ݲ���PID���в�ѯ
                if (chId.Checked == true)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inpaint_Sql + " where  PID��like'%" + txtBox.Text.Trim() + "%' order by IN_TIME desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                //���ݲ����������в�ѯ
                if (chkName.Checked == true)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inpaint_Sql + " where  PATIENT_NAME��like'%" + txtBox.Text.Trim() + "%' order by IN_TIME desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                if (chkCardID.Checked == true)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = Inpaint_Sql + " where  CARD_ID��like'%" + txtBox.Text.Trim() + "%' order by IN_TIME desc";
                        this.Cursor = Cursors.Default;
                    }
                }

                ucGridviewX1.DataBd(SQl, "סԺʱ��", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��ǰ���ұ��"].Visible = false;
                ucGridviewX1.fg.Columns["��ǰ���ұ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��ǰ�������"].Visible = false;
                ucGridviewX1.fg.Columns["��ǰ�������"].ReadOnly = true;
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

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);
        }
        /// <summary>
        /// ˢ�±��
        /// </summary>
        private void refurbish()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtPiyin.Enabled = false;
            dtpBirthday.Enabled = false;
            cboGender.Enabled = false;
            txtAge.Enabled = false;
            cboCusection.Enabled = false;
            cboAgeunit.Enabled = false;
            cboCusick.Enabled = false;
            dtpDatetime.Enabled = false;
            txtCardId.Enabled = false;
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
                App.ExecuteSQL("delete from T_IN_PATIENT where  ID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
            }
            ShowValue();
            refurbish();

        }
        private void chId_CheckedChanged(object sender, EventArgs e)
        {
            if (chId.Checked == true)
            {
                chId.Checked = true;
                chkName.Checked = false;
                chkCardID.Checked = false;
            }
            else
            {
                chId.Checked = false;
                txtBox.Text = "";
            }
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked == true)
            {
                chkName.Checked = true;
                chId.Checked = false;
                chkCardID.Checked = false;
            }
            else
            {
                chkName.Checked = false;
                txtBox.Text = "";
            }
        }
        private void chkCardID_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCardID.Checked == true)
            {
                chkCardID.Checked = true;
                chId.Checked = false;
                chkName.Checked = false;
            }
            else
            {
                chkCardID.Checked = false;
                txtBox.Text = "";
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
                dtpBirthday.Focus();
            }

        }

        private void dtpBirthday_KeyDown(object sender, KeyEventArgs e)
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
                cboCusection.Focus();
            }

        }

        private void txtAge_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    cboCusection.Focus();
            //}

        }

        private void cboCusection_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                cboCusick.Focus();
            }

        }


        private void cboCusick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDatetime.Focus();
            }

        }

        private void dtpDatetime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void cboCusection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cusick();
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            stamp();
        }

       

        

        private void ����Ժ���˻���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBedInfo fm = new frmBedInfo();
                App.FormStytleSet(fm, false);
                fm.ShowDialog();
                string bed_id = fm.bedInfo_id;
                string bed_name = fm.bedInfo_name;
                fm.Close();
                if (ucGridviewX1.fg.Rows.Count > 0)
                {
                    ID = ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (bed_id != "" && bed_name != "")
                    {
                        string sql_update = "update T_IN_PATIENT set sick_bed_id=" + bed_id + ",sick_bed_no='" + bed_name + "' where id=" + ID + "";
                        if (App.ExecuteSQL(sql_update) > 0)
                        {
                            App.Msg("�����ɹ���");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ��,ԭ��:" + ex.Message);
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            ///*
            // *��ȡ����Ժ����סԺ�ŵļ��� 
            // */
            //ArrayList sqls = new ArrayList();

            ///*
            // * ��ȡ�Ƿ��Ѿ�������
            // */
            ////��ȡ��ǰ���ݿ�Ĳ���  histime
            //string oursql = "select id,his_id from t_in_patient";
            ////if (histime != "")
            ////{
            ////    DateTime starttime = Convert.ToDateTime(histime);
            ////    oursql = "select id,his_id from t_in_patient where in_time>=to_timestamp('"
            ////                 + starttime.AddDays(-15).ToShortDateString() + "','syyyy-mm-dd hh24:mi:ss.ff9')";
            ////}
            //DataSet DataOurPatient = App.GetDataSet(oursql);

            ////cypb=0 ��Ժ    

            //DataSet Ds_Patient = sv.His_GetDataSet("select * from V_DZBL_ZY_BRRY where cypb=0 and zyys is not null and zyys<>''");


            //int action_id = App.GenId("t_inhospital_action", "id");
            //string zyys = "0";
            //int id = App.GenId("t_in_patient", "id");
            //if (id < 10000)
            //{
            //    id = 10000;
            //}

            ///*
            // * ���뵽�ҷ����ݿ�
            // */
            //for (int i = 0; i < Ds_Patient.Tables[0].Rows.Count; i++)
            //{

            //    if (DataOurPatient.Tables[0].Select("his_id='" + Ds_Patient.Tables[0].Rows[i]["ZYH"].ToString() + "'").Length == 0)
            //    {
            //        if (Ds_Patient.Tables[0].Rows[i]["ZYYS"].ToString().Trim() == "")
            //        {
            //            zyys = "-1";
            //            //hisGanBao.Add("-1," + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString());
            //        }
            //        else
            //        {
            //            zyys = Ds_Patient.Tables[0].Rows[i]["ZYYS"].ToString();
            //            //hisGanBao.Add(Ds_Patient.Tables[0].Rows[i]["ZYYS"].ToString() + "," + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString());
            //        }

            //        //�����Ա����
            //        string sex = "0";
            //        if (Ds_Patient.Tables[0].Rows[i]["BRXB"].ToString() == "1")
            //        {
            //            sex = "0";
            //        }
            //        else
            //        {
            //            sex = "1";
            //        }

            //        int year = 0;
            //        int month = 0;
            //        int days = 0;
            //        string AGE = "";
            //        string AGE_UNIT = "";
            //        GetAgeByBirthday(Convert.ToDateTime(Ds_Patient.Tables[0].Rows[i]["CSNY"]), App.GetSystemTime(), out year, out month, out days);
            //        if (year != 0)
            //        {
            //            AGE = year.ToString();
            //            AGE_UNIT = "��";
            //        }
            //        else
            //        {
            //            if (month != 0)
            //            {
            //                AGE = month.ToString();
            //                AGE_UNIT = "��";

            //            }
            //            else
            //            {
            //                if (days != 0)
            //                {
            //                    AGE = days.ToString();
            //                    AGE_UNIT = "��";
            //                }
            //            }
            //        }

            //        string PROPERTY = "";
            //        if (Ds_Patient.Tables[0].Rows[i]["xzbz_zjg"] != null)
            //        {
            //            PROPERTY = Ds_Patient.Tables[0].Rows[i]["xzbz_zjg"].ToString();
            //        }

            //        //���û�д��Ļ��Զ����ɴ�λ
            //        GenBed(Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString(), Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString(), Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString());

            //        string InsertPatient = "insert into T_IN_PATIENT(ID,HIS_ID,PATIENT_NAME,NAME_PINYIN,GENDER_CODE," +
            //                            "BIRTHDAY,Marriage_State,PID," +
            //                            "Country,Native_Place,Birth_Place,Folk_Code," +
            //                            "Career,Medicare_NO,Home_Address,Homepostal_Code,Home_Phone," +
            //                            "Office,Office_Phone,Relation_Name,Relation,Relation_Address," +
            //                            "Relation_Phone,IN_AREA_ID,SICK_AREA_ID," +
            //                            "Section_ID,Insection_ID," +
            //                            "IN_TIME,CARD_ID,IN_DOCTOR_ID,SICK_DOCTOR_ID,IN_DOCTOR_NAME,SICK_DOCTOR_NAME,SECTION_NAME," +
            //                            "INSECTION_NAME,IN_AREA_NAME,SICK_AREA_NAME,SICK_BED_NO,SICK_BED_ID,IN_BED_NO,IN_BED_ID,PAY_MANNER,AGE,AGE_UNIT,PROPERTY_FLAG,SICK_DOC_NO) values("
            //         + id + ",'"
            //         + Ds_Patient.Tables[0].Rows[i]["ZYH"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["BRXM"].ToString() + "','"
            //         + App.getSpell(Ds_Patient.Tables[0].Rows[i]["BRXM"].ToString()) + "','"
            //         + sex + "',to_timestamp('"
            //         + Ds_Patient.Tables[0].Rows[i]["CSNY"].ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
            //         + Ds_Patient.Tables[0].Rows[i]["HYZK"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["ZYHM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["GJDM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["SFDM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["HKDZ"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["MZDM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["ZYDM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["SFZH"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["HKDZ"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["HKYB"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["DH"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["GZDW"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["DWDH"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["LXRM"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["LXGX"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["LXDZ2"].ToString() + "','"
            //         + Ds_Patient.Tables[0].Rows[i]["LXDH"].ToString() +
            //         "',(select said from T_SICKAREAINFO where SICK_AREA_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1)" +
            //         ",(select said from T_SICKAREAINFO where SICK_AREA_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1)" +
            //         ",(select sid from T_SECTIONINFO where SECTION_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1)" +
            //         ",(select sid from T_SECTIONINFO where SECTION_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1)"
            //         + ",to_timestamp('"
            //         + Ds_Patient.Tables[0].Rows[i]["RYRQ"].ToString() + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
            //         + Ds_Patient.Tables[0].Rows[i]["GFZH"].ToString() + "'" +
            //         ",(select USER_ID from T_USERINFO where USER_NUM='" + zyys + "' and rownum=1)" +
            //         ",(select USER_ID from T_USERINFO where USER_NUM='" + zyys + "' and rownum=1)" +
            //         ",(select USER_NAME from T_USERINFO where USER_NUM='" + zyys + "' and rownum=1)" +
            //         ",(select USER_NAME from T_USERINFO where USER_NUM='" + zyys + "' and rownum=1)" +

            //         ",(select SECTION_NAME from T_SECTIONINFO where SECTION_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1)" +
            //         ",(select SECTION_NAME from T_SECTIONINFO where SECTION_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1)" +
            //         ",(select SICK_AREA_NAME from T_SICKAREAINFO where SICK_AREA_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1)" +
            //         ",(select SICK_AREA_NAME from T_SICKAREAINFO where SICK_AREA_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1),'"

            //          + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() +
            //          "',(select BED_ID from T_SICKBEDINFO where BED_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() + "' and rownum=1),'"

            //          + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() +
            //           "',(select BED_ID from T_SICKBEDINFO where BED_CODE='" + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() + "' and rownum=1),'"
            //          + Ds_Patient.Tables[0].Rows[i]["BRXZ"].ToString() + "'" + AGE + ",'" + AGE_UNIT + "','" + PROPERTY + "','" + Ds_Patient.Tables[0].Rows[i]["BAHM"].ToString() + "')";


            //        //ָ�����ź󣬸ô���״̬��Ϊռ��74
            //        string UpdateBed_State = "update t_sickbedinfo set state=74,pid=" + id + " where bed_no='" + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() + "'";

            //        //���춯�����һ��������¼
            //        string InsertInArea = "insert into t_inhospital_action (id,sid,said,pid,action_type," +
            //                               " action_state,happen_time,bed_id,doctor_id,operate_id,next_id,preview_id,patient_id)" +
            //                               " values(" + action_id.ToString() + ",(select sid from T_SECTIONINFO where section_code='" + Ds_Patient.Tables[0].Rows[i]["BRKS"].ToString() + "' and rownum=1),(select said from T_SICKAREAINFO where sick_area_code='" + Ds_Patient.Tables[0].Rows[i]["BRBQ"].ToString() + "' and rownum=1),'" + id + "'," +
            //                               "'����','4',sysdate,(select bed_id from T_SICKBEDINFO where bed_no='" + Ds_Patient.Tables[0].Rows[i]["BRCH"].ToString() + "' and rownum=1),'" + zyys + "',0,0,0," + id + ")";
            //        //���ʿ���ʱ������һ��������¼
            //        string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,patient_id)" +
            //                                " values('" + Ds_Patient.Tables[0].Rows[i]["ZYHM"].ToString() + "','����',to_timestamp('" + Ds_Patient.Tables[0].Rows[i]["RYRQ"].ToString()
            //                                + "','yyyy-MM-dd hh24:mi:ss')," + id + ")";

            //        sqls.Add(InsertPatient);
            //        sqls.Add(UpdateBed_State);
            //        sqls.Add(InsertInArea);
            //        sqls.Add(InsertJob_Temp);
            //        id++;
            //        action_id++;
            //    }
            //}
            //string[] sqlsstrs = new string[sqls.Count];
            //for (int i = 0; i < sqls.Count; i++)
            //{
            //    sqlsstrs[i] = sqls[i].ToString();
            //}
            //int count = App.ExecuteBatch(sqlsstrs);
            //if (count > 0)
            //{
            //    App.Msg("����ɹ�����������" + sqlsstrs.Length / 4);
            //}
            //else
            //{
            //    App.Msg("����ʧ�ܣ�");
            //}
        }

        #region HIS�����Զ�������ز���
        /// ͨ�����պ͵�ǰ���ڼ����꣬�£���
        /// </summary>
        /// <param name="birthday">����</param>
        /// <param name="now">��ǰ����</param>
        /// <param name="year">��</param>
        /// <param name="month">��</param>
        /// <param name="day">��</param>
        public static void GetAgeByBirthday(DateTime birthday, DateTime now, out int year, out int month, out int day)
        {
            //int day, month, year;
            //���յ��꣬�£���
            int birthdayYear = birthday.Year;
            int birthdayMonth = birthday.Month;
            int birthdayDay = birthday.Day;
            //��ǰʱ�����,��,��
            int nowYear = now.Year;
            int nowMonth = now.Month;
            int nowDay = now.Day;

            //�õ���

            if (nowDay >= birthdayDay)
            {
                day = nowDay - birthdayDay;
            }
            else
            {
                nowMonth -= 1;
                day = GetDay(nowMonth, nowYear) + nowDay - birthdayDay;
            }


            //�õ���
            if (nowMonth >= birthdayMonth)
            {
                month = nowMonth - birthdayMonth;
            }

            else
            {
                nowYear -= 1;
                month = 12 + nowMonth - birthdayMonth;
            }
            //�õ���
            year = nowYear - birthdayYear;
        }

        /// <summary>
        /// ��ȡ����
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        private static int GetDay(int month, int year)
        {

            int day = 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    day = 31;
                    break;
                case 2:

                    //�����죬ƽ����

                    if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                    {

                        day = 29;

                    }

                    else
                    {

                        day = 28;

                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    day = 30;
                    break;
            }
            return day;

        }
        /// <summary>
        /// ��û��HIS�еĴ��ŵ��Զ��½�����
        /// </summary>
        /// <param name="BedCode"></param>
        /// <param name="sickareacode"></param>
        /// <param name="sectioncode"></param>
        private static void GenBed(string BedCode, string sickareacode, string sectioncode)
        {
            try
            {
                DataSet ds_bed = App.GetDataSet("select a.bed_id from t_sickbedinfo a where a.bed_code='" + BedCode + "'");
                if (ds_bed != null)
                {
                    if (ds_bed.Tables[0].Rows.Count == 0)
                    {
                        string BedId = App.GenId("t_sickbedinfo", "bed_id").ToString();
                        string Sql = "insert into T_SICKBEDINFO(BED_ID,SRID,SID,SAID,BED_CODE,BED_NO,TYPEINFO,BEDLEVEL,ORG_PROP,STATE,SEX_CTRL,SEX_FLAG,ENABLEFLAG) values(" + BedId + ",'',(select sid from T_SECTIONINFO where SECTION_CODE='" +
                            sectioncode + "' and rownum=1),(select said from T_SICKAREAINFO where SICK_AREA_CODE='" + sickareacode + "' and rownum=1),'" +
                            BedCode + "','" + BedCode + "',76,73,'',75,'1','2','Y')";
                        App.ExecuteSQL(Sql);
                    }
                }
            }
            catch
            { }
        }
        #endregion

    }
}