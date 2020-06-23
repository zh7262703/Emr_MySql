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
    public partial class ucSickBedInfo : UserControl
    {
        bool IsSave = false;              //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID;               //����ID
        private string mark = "Y";      //��Ч��־
        private string T_SickBedInfo;   //������ѯ
        private string bed_code;        //��ǰѡ�еĲ������
        private string bed_name;        //��ǰѡ�еĴ���
        DataSet ds;
        public ucSickBedInfo()
        {
            InitializeComponent();
            T_SickBedInfo = @"select BED_ID as ���,a.SRID as ���ұ��,b.sick_room_code as ��������,a.SID as ���ұ��,c.section_name as ��������," +
                        @"a.SAID as �������,d.sick_area_name as ��������,BED_CODE as �������,BED_NO as ����,a.typeinfo as �����,g.name as �������," +
                        @"a.BEDLEVEL as �ȼ����,k.name as �ȼ�����,a.ORG_PROP as ����,STATE as ״̬���,t.name as ״̬����," +
                        @"(case when a.SEX_CTRL=0 then '��' else '��' end) as �Ա���Ʊ�־,(case when a.SEX_FLAG=0 then '��' when a.SEX_FLAG=1 then 'Ů' else  '��' end) as �Ա�," +
                        @"(case when a.ENABLEFLAG='Y' then '��Ч' else '��Ч' end) as ��Ч��־," +
                        @"PID as �������� from T_SICKBEDINFO a left join T_SICKROOMINFO b on b.srid=a.srid left join T_SECTIONINFO c on c.sid=a.sid left join T_SICKAREAINFO d on d.said=a.said left join T_DATA_CODE g on g.id=a.typeinfo left join T_DATA_CODE k on k.id=a.bedlevel left join T_DATA_CODE t on t.id=a.state";
        }
        private void frmSickBedInfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("������Ϣ");
            //��ʾ�б�����
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucGridviewX1.fg.RowColChange += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            cboGender.SelectedIndex = 0;
            cboGender1.SelectedIndex = 0;
            cboSickbedconstion.SelectedIndex = 0;
            SickRoom();
            Section();
            SickBay();
            Type();
            Grade();
            RefleshFrm();
        }
        private void frmSickBedInfo_Activated(object sender, EventArgs e)
        {
            //��ʾ�б�����
            ShowValue();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ұ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ұ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ұ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ұ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�����"].Visible = false;
                ucGridviewX1.fg.Columns["�����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�ȼ����"].Visible = false;
                ucGridviewX1.fg.Columns["�ȼ����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["״̬���"].Visible = false;
                ucGridviewX1.fg.Columns["״̬���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��������"].Visible = false;
                ucGridviewX1.fg.Columns["��������"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        //��ʾ�б�����
        private void ShowValue()
        {
            string SQl = T_SickBedInfo + " order by BED_ID desc";
             ds = App.GetDataSet(SQl);
             if (ds != null)
             {

                 //    ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                 ucGridviewX1.DataBd(SQl, "���", false, "", "");
                 ucGridviewX1.fg.Columns["���"].Visible = false;
                 ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["�������"].Visible = false;
                 ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["���ұ��"].Visible = false;
                 ucGridviewX1.fg.Columns["���ұ��"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["���ұ��"].Visible = false;
                 ucGridviewX1.fg.Columns["���ұ��"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["�������"].Visible = false;
                 ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["�����"].Visible = false;
                 ucGridviewX1.fg.Columns["�����"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["�ȼ����"].Visible = false;
                 ucGridviewX1.fg.Columns["�ȼ����"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["״̬���"].Visible = false;
                 ucGridviewX1.fg.Columns["״̬���"].ReadOnly = true;
                 ucGridviewX1.fg.Columns["��������"].Visible = false;
                 ucGridviewX1.fg.Columns["��������"].ReadOnly = true;
                 ucGridviewX1.fg.ReadOnly = true;

             }

        }
        //�󶨲���
        private void SickRoom()
        {
            try
            {
                DataSet ds = App.GetDataSet("select * from  T_SICKROOMINFO where SAID='" + cboSickBay.SelectedValue + "' and  ENABLEFLAG='Y'");
                cboSickRoom.DataSource = ds.Tables[0].DefaultView;
                cboSickRoom.ValueMember = "SRID";
                cboSickRoom.DisplayMember = "SICK_ROOM_CODE";
            }
            catch
            {
            }
        }
        //�󶨿���
        private void Section()
        {
            try
            {

                DataSet ds = App.GetDataSet("select b.* from T_SECTION_AREA  g inner join T_SECTIONINFO  b on b.sid=g.sid  where g.said='" + cboSickBay.SelectedValue + "' and  b.ENABLE_FLAG='Y'");
                cboSection.DataSource = ds.Tables[0].DefaultView;
                cboSection.ValueMember = "SID";
                cboSection.DisplayMember = "SECTION_NAME";

            }
            catch
            { }

        }
        //�󶨲���
        private void SickBay()
        {
            DataSet ds = App.GetDataSet("select * from  T_SICKAREAINFO  where ISBELONGTOSECTION='N' and  ENABLE_FLAG='Y'");
            cboSickBay.DataSource = ds.Tables[0].DefaultView;
            cboSickBay.ValueMember = "SAID";
            cboSickBay.DisplayMember = "SICK_AREA_NAME";

        }
        //�󶨵ȼ�
        private void Grade()
        {
            try
            {
                DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='13'");
                cboGrade.DataSource = ds.Tables[0].DefaultView;
                cboGrade.ValueMember = "ID";
                cboGrade.DisplayMember = "NAME";
            }
            catch
            {
            }
        }
        //�󶨲������
        private void Type()
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE where Type='15'");
            cboType.DataSource = ds.Tables[0].DefaultView;
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "NAME";
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {

            txtID.Enabled = false;
            cboSickRoom.Enabled = false;
            cboSickBay.Enabled = false;
            cboSection.Enabled = false;
            //cboSickperson.Enabled = false;
            txtBed.Enabled = false;
            cboType.Enabled = false;
            cboGrade.Enabled = false;
            txtPlait.Enabled = false;
            cboState.Enabled = false;
            cboGender.Enabled = false;
            cboGender1.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
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
                txtID.Text = "";
                txtBed.Text = "";
                txtPlait.Text = "";
            }
            txtID.Enabled = true;
            cboSickRoom.Enabled = true;
            cboSickBay.Enabled = true;
            cboSection.Enabled = true;
            //cboSickperson.Enabled = false;
            txtBed.Enabled = true;
            cboType.Enabled = true;
            cboGrade.Enabled = true;
            txtPlait.Enabled = true;
            cboState.Enabled = true;
            cboGender.Enabled = true;
            cboGender1.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (cboGender.SelectedIndex == 0)
            {
                cboGender1.Enabled = true;
            }
            else
            {
                if (btnCancel.Enabled)
                {
                    cboGender1.Enabled = false;
                    cboGender1.SelectedIndex = 2;

                }
            }
            txtID.Focus();
        }

        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_SICKBEDINFO  where BED_CODE='" + id + "'");
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
        private bool IsExisitBed(string Bed)
        {
            DataSet ds = App.GetDataSet("select SAID from T_SICKBEDINFO where  BED_NO='" + Bed + "'and SAID='" + cboSickBay.SelectedValue + "'");
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
                //if (txtID.Text.Trim()=="")
                //{
                //    App.Msg("������Ų���Ϊ�գ�");
                //    txtID.Focus();
                //    return;
                //}
                //if (cboSickRoom.Text.Trim() == "")
                //{
                //    App.Msg("������������Ϊ�գ�");
                //    cboSickRoom.Focus();
                //    return;
                //}
                if (cboSickBay.Text.Trim() == "")
                {
                    App.Msg("�������Ҳ���Ϊ�գ�");
                    cboSickBay.Focus();
                    return;
                }
                if (cboSection.Text.Trim() == "")
                {
                    App.Msg("������������Ϊ�գ�");
                    cboSection.Focus();
                    return;
                }
                if (txtBed.Text.Trim() == "")
                {
                    App.Msg("���Ų���Ϊ�գ�");
                    txtBed.Focus();
                    return;
                }
                if (cboType.Text.Trim() == "")
                {
                    App.Msg("�����Ϊ�գ�");
                    cboType.Focus();
                    return;
                }
                if (cboGrade.Text.Trim() == "")
                {
                    App.Msg("�ȼ�����Ϊ�գ�");
                    cboGrade.Focus();
                    return;
                }
                if (cboGender.Text.Trim() == "")
                {
                    App.Msg("�Ա���Ʊ�־������д");
                    cboGender.Focus();
                    return;
                }

                if (!rbtnValidmark.Checked)
                {
                    mark = "N";
                }
                string sql = "";

                ID = App.GenId("T_SICKBEDINFO ", "BED_ID").ToString();
                if (IsSave)
                {
                    //if (isExisitNames(App.ToDBC(txtID.Text.Trim())))
                    //{
                    //    App.Msg("�Ѿ���������ͬ���ƵĲ�������ˣ�");
                    //    txtID.Focus();
                    //    return;
                    //}
                    if (IsExisitBed(App.ToDBC(txtBed.Text.Trim())))
                    {
                        App.Msg("��ͬ�Ĳ������Ѿ�����ͬ�Ĵ����ˣ�");
                        txtBed.Focus();
                        return;
                    }
                    sql = "insert into T_SICKBEDINFO(BED_ID,SRID,SID,SAID,BED_CODE,BED_NO,TYPEINFO,BEDLEVEL,ORG_PROP,STATE,SEX_CTRL,SEX_FLAG,ENABLEFLAG) values("
                         + ID + ",'"
                         + cboSickRoom.SelectedValue + "',"
                         + cboSection.SelectedValue + ","
                         + cboSickBay.SelectedValue + ",'"
                         + txtBed.Text + "','"
                         + txtBed.Text + "',"
                         + cboType.SelectedValue + ","
                         + cboGrade.SelectedValue + ",'"
                         + txtPlait.Text + "',75,'"
                         + cboGender.SelectedIndex.ToString() + "','"
                         + cboGender1.SelectedIndex.ToString() + "','"
                         + mark + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    //if (bed_code.Trim() != "")
                    //{
                    //    if (txtID.Text.Trim() != bed_code.Trim())
                    //    {
                    //       if (isExisitNames(App.ToDBC(txtID.Text.Trim())))
                    //        {
                    //            App.Msg("�Ѿ���������ͬ���ƵĲ�������ˣ�");
                    //            txtID.Focus();
                    //            return;
                    //        }
                    //    }
                    //}
                    if (bed_name.Trim() != "")
                    {
                        if (txtBed.Text.Trim() != bed_name.Trim())
                        {
                            if (IsExisitBed(App.ToDBC(txtBed.Text.Trim())))
                            {
                                App.Msg("��ͬ�Ĳ������Ѿ�����ͬ�Ĵ����ˣ�");
                                txtBed.Focus();
                                return;
                            }
                        }
                    }

                    sql = "update T_SICKBEDINFO set SRID='"
                              + cboSickRoom.SelectedValue + "',SID="
                              + cboSection.SelectedValue + ",SAID="
                              + cboSickBay.SelectedValue + ",BED_CODE='"
                              + txtBed.Text + "',BED_NO='"
                              + txtBed.Text + "',TYPEINFO="
                              + cboType.SelectedValue + ",BEDLEVEL="
                              + cboGrade.SelectedValue + ",ORG_PROP='"
                              + txtPlait.Text + "',SEX_CTRL='"
                              + cboGender.SelectedIndex.ToString() + "',SEX_FLAG='"
                              + cboGender1.SelectedIndex.ToString() + "',ENABLEFLAG='"
                              + mark + "'  where BED_ID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";

                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);
                    }
                //��ʾ�б�����
                ShowValue();
                //string SQl = T_SickBedInfo;
                //ucC1FlexGrid1.DataBd(SQl, "BED_ID", "BED_ID,SRID,SRID_NAME,SID,SECTION_SID,SAID,SICK_SAID,BED_CODE,BED_NO,TYPEINFO,TYPEINFO_NAME,BEDLEVEL,BEDLEVEL_NAME,ORG_PROP,STATE,STATE_NAME,SEX_CTRL,SEX_FLAG,ENABLEFLAG,PID", "���,���ұ��,��������,���ұ��,��������,�������,��������,�������,����,�����,�������,�ȼ����,�ȼ�����,����,״̬���,״̬����,�Ա���Ʊ�־,�Ա�(��ǰ),��Ч��־,��������");

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
                    ID = ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["���ұ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboSickRoom.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["���ұ��",ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    if (ucGridviewX1.fg["���ұ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboSection.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["���ұ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());
                    }
                    if (ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboSickBay.SelectedValue = ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();//Convert.ToInt32

                    }
                    txtID.Text = ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    bed_code = txtID.Text;
                    txtBed.Text = ucGridviewX1.fg["����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    bed_name = txtBed.Text;
                    if (ucGridviewX1.fg["�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboType.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    if (ucGridviewX1.fg["�ȼ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboGrade.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["�ȼ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    txtPlait.Text = ucGridviewX1.fg["����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["״̬���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboState.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["״̬���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    if (ucGridviewX1.fg["�Ա���Ʊ�־", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                    {
                        cboGender.SelectedIndex = 0;
                    }
                    else
                    {
                        cboGender.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["�Ա�", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                    {
                        cboGender1.SelectedIndex = 0;
                    }
                    else
                    {
                        cboGender1.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["��Ч��־", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��Ч")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }
                    //cboSickperson.Text =ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��������"].ToString();
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
                string SQl = T_SickBedInfo + " order by BED_ID desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }
                // ������
                if (cboSickbedconstion.SelectedIndex == 0)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_SickBedInfo + " where ��BED_NO��like'%" + txtBox.Text.Trim() + "%' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                //����������
                else if (cboSickbedconstion.SelectedIndex == 1)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_SickBedInfo + " where  ��c.section_name��like'%" + txtBox.Text.Trim() + "%' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                //����������
                else  if (cboSickbedconstion.SelectedIndex == 2)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        SQl = T_SickBedInfo + " where ��d.sick_area_name��like'%" + txtBox.Text.Trim() + "%' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }
                }
                //����Ч��־ 
                else if (cboSickbedconstion.SelectedIndex == 3)
                {

                    if (cboValidmark.SelectedIndex == 0)
                    {
                        SQl = T_SickBedInfo + "  where  a.ENABLEFLAG='Y' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }
                    else if (cboValidmark.SelectedIndex == 1)
                    {
                        SQl = T_SickBedInfo + "  where  a.ENABLEFLAG='N' order by BED_ID desc";
                        this.Cursor = Cursors.Default;
                    }

                }
                ucGridviewX1.DataBd(SQl, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ұ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ұ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ұ��"].Visible = false;
                ucGridviewX1.fg.Columns["���ұ��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�����"].Visible = false;
                ucGridviewX1.fg.Columns["�����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�ȼ����"].Visible = false;
                ucGridviewX1.fg.Columns["�ȼ����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["״̬���"].Visible = false;
                ucGridviewX1.fg.Columns["״̬���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��������"].Visible = false;
                ucGridviewX1.fg.Columns["��������"].ReadOnly = true;
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
        /// ɾ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender, e);

        }
        /// <summary>
        /// ���ݴ��ŵı�Ż�ô���״̬
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string State(string id)
        {
            string sql = "select STATE from T_SICKBEDINFO where BED_ID='" + id + "'";
            string sta_id = App.ReadSqlVal(sql, 0, "STATE");
            return sta_id;
        }
        /// <summary>
        /// ˢ�±��
        /// </summary>
        private void refurbish()
        {
            txtID.Text = "";
            txtBed.Text = "";
            txtPlait.Text = "";
            txtID.Enabled = false;
            cboSickRoom.Enabled = false;
            cboSickBay.Enabled = false;
            cboSection.Enabled = false;
            //cboSickperson.Enabled = false;
            txtBed.Enabled = false;
            cboType.Enabled = false;
            cboGrade.Enabled = false;
            txtPlait.Enabled = false;
            cboState.Enabled = false;
            cboGender.Enabled = false;
            cboGender1.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
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
                string state_id = "";
                state_id = ucGridviewX1.fg["״̬���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                if (state_id == "75")
                {

                    if (App.ExecuteSQL("delete from T_SICKBEDINFO where  BED_ID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "") > 0)
                    {
                        App.Msg("�����Ѿ��ɹ���");
                    }
                    else
                    {
                        App.MsgErr("����ʧ�ܣ�");
                    }
                }
                else
                {
                    App.MsgErr("�����Ѿ�������ռ�У����ܽ���ɾ��");
                }

            }
            //��ʾ�б�����
            ShowValue();
            refurbish();
            //string SQl = T_SickBedInfo;
            //ucC1FlexGrid1.DataBd(SQl, "BED_ID", "BED_ID,SRID,SRID_NAME,SID,SECTION_SID,SAID,SICK_SAID,BED_CODE,BED_NO,TYPEINFO,TYPEINFO_NAME,BEDLEVEL,BEDLEVEL_NAME,ORG_PROP,STATE,STATE_NAME,SEX_CTRL,SEX_FLAG,ENABLEFLAG,PID", "���,���ұ��,��������,���ұ��,��������,�������,��������,�������,����,�����,�������,�ȼ����,�ȼ�����,����,״̬���,״̬����,�Ա���Ʊ�־,�Ա�(��ǰ),��Ч��־,��������");

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
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSickBay.Focus();
            }
        }

        private void txtBed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSickBay.Focus();
            }

        }
        private void cboSickBay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSection.Focus();
            }

        }

        private void cboSection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSickRoom.Focus();
            }

        }

        private void cboSickRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboType.Focus();
            }

        }

        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboGrade.Focus();
            }

        }

        private void cboGrade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPlait.Focus();
            }

        }

        private void txtPlait_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboGender.Focus();
            }

        }

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (cboGender.SelectedIndex == 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cboGender1.Focus();
                }

            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    rbtnValidmark.Focus();
                }

            }
        }

        private void cboGender1_KeyDown(object sender, KeyEventArgs e)
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
                btnSave_Click(sender, e);
            }

        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void cboSickBay_SelectedIndexChanged(object sender, EventArgs e)
        {
            Section();
            SickRoom();
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SickBay();
        }

        private void cboSickRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            Grade();
        }

        private void cboGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGender.SelectedIndex == 0)
            {
                cboGender1.Enabled = true;

            }
            else
            {
                if (btnCancel.Enabled)
                {

                    cboGender1.Enabled = false;
                    cboGender1.SelectedIndex = 2;

                }
            }
        }
        /// <summary>
        /// ��ѯ�������ж�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSickbedconstion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSickbedconstion.Enabled == true)
            {
                //��ѯ����Ϊ����Ч��־
                if (cboSickbedconstion.SelectedIndex == 3)
                {
                    cboValidmark.Visible = true;
                    cboValidmark.Enabled = true;
                    txtBox.Enabled = false;
                    txtBox.Visible = false;
                }
                else
                {
                    cboValidmark.Visible = false;
                    cboValidmark.Enabled = false;
                    txtBox.Enabled = true;
                    txtBox.Visible = true;
                }
            }
        }

        /// <summary>
        /// ��λͬ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBedRef_Click(object sender, EventArgs e)
        {

            try
            {

                //HIS��λ
                //select * from HNYZ_ZXYY.intf_emr_bedview where BQID=2037

                //�ҷ���λ
                //select * from t_sickbedinfo bb where bb.said=39

                //��λ����
                DataSet ds_Area = App.GetDataSet("select bbb.said,bbb.sick_area_code from t_sickareainfo bbb where length(bbb.sick_area_code)>=4");// and shid=221");//221��Ժ,1��Ժ
                List<string> Sqls = new List<string>();
                for (int i1 = 0; i1 < ds_Area.Tables[0].Rows.Count; i1++)
                {
                    string hisaid = ds_Area.Tables[0].Rows[i1]["sick_area_code"].ToString();//EMR�е�sick_area_code��Ӧhis�еĲ���id
                    string said = ds_Area.Tables[0].Rows[i1]["said"].ToString();
                    //���his�ж�Ӧ���ҵ����д�λ��Ϣ
                    DataSet ds_his_bed = App.GetDataSet("select * from HNYZ_ZXYY.intf_emr_bedview@dbhislink where BQID=" + hisaid + "");
                    DataSet ds_our_bed = App.GetDataSet("select * from t_sickbedinfo bb where bb.said=" + said + "");

                    for (int i = 0; i < ds_our_bed.Tables[0].Rows.Count; i++)
                    {//�ô���ȥƥ��his�д���
                        string bedno = ds_our_bed.Tables[0].Rows[i]["bed_no"].ToString();
                        for (int j = 0; j < ds_his_bed.Tables[0].Rows.Count; j++)
                        {
                            string bed_his_CWM = ds_his_bed.Tables[0].Rows[j]["CWMC"].ToString();
                            string bed_his_Code = ds_his_bed.Tables[0].Rows[j]["CWDM"].ToString();
                            if (App.IsNumeric(bedno) && App.IsNumeric(bed_his_CWM))
                            {
                                if (Convert.ToInt16(bedno) == Convert.ToInt16(bed_his_CWM))
                                {
                                    Sqls.Add("update t_sickbedinfo set bed_code='" + bed_his_Code + "' where said=" + said + " and bed_no='" + bedno + "' and bed_code<>'" + bed_his_Code + "'");
                                }
                            }
                            else
                            {
                                if (bedno == bed_his_CWM)
                                {
                                    Sqls.Add("update t_sickbedinfo set bed_code='" + bed_his_Code + "' where said=" + said + " and bed_no='" + bedno + "' and bed_code<>'" + bed_his_Code + "'");
                                }
                            }
                        }
                    }
                }
                if (App.ExecuteBatch(Sqls.ToArray()) > 0)
                {
                    App.Msg("ͬ���ɹ�!");
                }
                else
                {
                    App.Msg("ͬ��ʧ��!");
                }
            }
            catch (Exception ex)
            {
                App.Msg("��ʾ:ͬ����λ����,ԭ��:" + ex.Message);
            }
        }


    }
}