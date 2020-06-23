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
    public partial class ucSection : UserControl
    {
        bool IsSave = false;��            //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private  string inspection = "Y"; //�Ƿ�Ϊ����
        private  string Science = "Y";    //�Ƿ�Ϊ���
        private  string Hospital = "I";��//סԺ��������ұ�־
        private  string Mark = "Y";      //��Ч��־
        private  string ID="";          //��ȡ��ǰ��ID
        private string T_section_Sql;  //���Ҳ�ѯ
        Class_Sections[] section;
        private string section_code;   //��ǰѡ�еĿ��ұ��
        private string section_name;   //��ǰѡ�еĿ�������
        DataSet ds;
        public ucSection()
        {
            InitializeComponent();
            T_section_Sql =@" select SID as ���,SECTION_CODE as ���ұ��,SECTION_NAME as ��������,BELONGTO_SECTION_ID as �����������,(case when ISCHECKSECTION='Y' then '��' else '��' end) as �Ƿ��Ǽ���,
                            BELONGTO_SECTION_NAME as ���������,BELONGTO_BIGSECTION_ID �������,(select SECTION_NAME from T_SECTIONINFO b where b.SID=a.BELONGTO_BIGSECTION_ID) as �������,
                            (case when ISBELONGTOBIGSECTION='Y' then '��' else '��' end) as �Ƿ���,TYPEINFO as �����,g.name as ���,
                            (case when IN_FLAG='I' then 'סԺ' else '����' end) as סԺ�������־,MANAGE_TYPE as ���ҹ������Ա��,s.name as ���ҹ�������,
                            (case when ENABLE_FLAG='Y' then '��Ч' else '��Ч' end) as ��Ч��־,
                            a.SHID as ��Ժ���,c.sub_hospital_name as ��Ժ���� from T_SECTIONINFO a inner join T_SUB_HOSPITALINFO c on a.shid=c.shid inner join T_DATA_CODE s on a.manage_type=s.id inner join T_DATA_CODE g on a.typeinfo=g.id  where 1=1 ";//ENABLE_FLAG='Y'";
        }

        private void frmSection_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("������Ϣ");
            //��ʾ�б�����
            ShowValue();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucGridviewX1.fg.CellValueChanged += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            //�󶨴��
            BigSenction();
            //�󶨷�Ժ
            HospitalInfo();
            //�󶨿��ҹ�������
            Property();
            //������
            Type();
            cboBigscience.SelectedIndex = 0;
            RefleshFrm();
            ucGridviewX1.fg.AutoResizeColumns();

        }

        private void CurrentDataChange(object sender, EventArgs e)
        {

            try
            {

                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�����"].Visible = false;
                ucGridviewX1.fg.Columns["�����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ҹ������Ա��"].Visible = false;
                ucGridviewX1.fg.Columns["���ҹ������Ա��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ժ���"].Visible = false;
                ucGridviewX1.fg.Columns["��Ժ���"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }

            catch
            { }
                 
        }

        //��ʾ�б�����
        private void ShowValue()
        {
            string Sql = T_section_Sql + "  order by SID desc";
            ds = App.GetDataSet(Sql);
            if (ds != null)
            {
                ucGridviewX1.DataBd(Sql, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�����"].Visible = false;
                ucGridviewX1.fg.Columns["�����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ҹ������Ա��"].Visible = false;
                ucGridviewX1.fg.Columns["���ҹ������Ա��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ժ���"].Visible = false;
                ucGridviewX1.fg.Columns["��Ժ���"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }    
        }


      /// <summary>
      /// �󶨴��
      /// </summary>
        private void BigSenction()
        {
            cboBigscience.Items.Clear();
            Class_Sections none = new Class_Sections();
            none.Sid = 0;
            none.Section_Code = "��";
            none.Section_Name = "��";
            none.Belongto_Section_Id = "��";
            none.isCheckSection = "��";
            none.Belongto_Section_Name = "��";
            none.Belongto_BigSection_ID = "��";
            none.isBelongToBigSection = "��";
            none.Type = "��";
            none.Inout_flag = "��";
            none.Manage_type = "��";
            none.State = "��";
            none.Belongto_hospital = "��";
            cboBigscience.Items.Add(none);
                  
            string sql = "select * from T_SECTIONINFO  where ISBELONGTOBIGSECTION='Y' and ENABLE_FLAG='Y'";
            DataSet ds = App.GetDataSet(sql);
            section= new Class_Sections[ds.Tables[0].Rows.Count]; 
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                section[i] = new Class_Sections();
                section[i].Sid =Convert.ToInt32( ds.Tables[0].Rows[i]["SID"].ToString());
                section[i].Section_Code = ds.Tables[0].Rows[i]["SECTION_CODE"].ToString();
                section[i].Section_Name = ds.Tables[0].Rows[i]["SECTION_NAME"].ToString();
                section[i].Belongto_Section_Id = ds.Tables[0].Rows[i]["BELONGTO_SECTION_ID"].ToString();
                section[i].isCheckSection = ds.Tables[0].Rows[i]["ISCHECKSECTION"].ToString();
                section[i].Belongto_Section_Name = ds.Tables[0].Rows[i]["BELONGTO_SECTION_NAME"].ToString();
                section[i].Belongto_BigSection_ID = ds.Tables[0].Rows[i]["BELONGTO_BIGSECTION_ID"].ToString();
                section[i].isBelongToBigSection = ds.Tables[0].Rows[i]["ISBELONGTOBIGSECTION"].ToString();
                section[i].Type = ds.Tables[0].Rows[i]["TYPEINFO"].ToString();
                section[i].Inout_flag = ds.Tables[0].Rows[i]["IN_FLAG"].ToString();
                section[i].Manage_type = ds.Tables[0].Rows[i]["MANAGE_TYPE"].ToString();
                section[i].State = ds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                section[i].Belongto_hospital = ds.Tables[0].Rows[i]["SHID"].ToString();
                cboBigscience.Items.Add(section[i]);
                
            }

                cboBigscience.ValueMember = "SID";
                cboBigscience.DisplayMember = "SECTION_NAME";
               
                //cboBigscience.SelectedValue = "SID";

        }
        //������Ժ
        private void HospitalInfo()
        {
            DataSet ds = App.GetDataSet("select * from T_SUB_HOSPITALINFO");
            cboBranchcourts.DataSource = ds.Tables[0].DefaultView;
            cboBranchcourts.ValueMember = "SHID";
            cboBranchcourts.DisplayMember = "SUB_HOSPITAL_NAME";
        }
        //�󶨿��ҹ�������
        private void Property()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='8'");
            cboProperty.DataSource = ds.Tables[0].DefaultView;
            cboProperty.ValueMember = "ID";
            cboProperty.DisplayMember = "NAME";
        }
        //������
        private void Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='9'");
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
            txtName.Enabled = false;
            cboOffice.Enabled = false;
            rbtnYes.Enabled = false;
            rbtnNo.Enabled = false;
            cboComputation.Enabled = false;
            cboBigscience.Enabled = false;
            rdtnScienceYes.Enabled = false;
            rdtnScienceNo.Enabled = false;
            cboType.Enabled = false;
            rbtnHospital.Enabled = false;
            rbtnOutpatient.Enabled = false;
            cboProperty.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            cboBranchcourts.Enabled = false;
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
                txtName.Text = "";
                cboOffice.Text = "";
                cboComputation.Text = "";
            }
            txtID.Enabled = true;
            txtName.Enabled = true;
            cboOffice.Enabled =false;
            rbtnYes.Enabled = true;
            rbtnNo.Enabled = true;
            cboComputation.Enabled = false;
            cboBigscience.Enabled = true;
            rdtnScienceYes.Enabled = true;
            rdtnScienceNo.Enabled = true;
            cboType.Enabled = true;
            rbtnHospital.Enabled = true;
            rbtnOutpatient.Enabled = true;
            cboProperty.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            cboBranchcourts.Enabled = true;
            btnAdd.Enabled = false ;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
           
            if (rdtnScienceYes.Checked == true)
            {
                cboBigscience.Enabled = false;
                cboBigscience.SelectedIndex = -1;
            }
            else
            {
                cboBigscience.Enabled = true;
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
            DataSet ds = App.GetDataSet("select * from T_SECTIONINFO  where SECTION_CODE='" + id + "'");
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
        private bool Isnames(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_SECTIONINFO  where SECTION_NAME='" + name + "'");
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
                if (txtID.Text.Trim() == "")
                {
                    App.Msg("������Ϣ��ű�����д��");
                    txtID.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("�������Ʊ�����д��");
                    txtName.Focus();
                    return;
                }
             
                //�Ƿ�Ϊ����
                if (!rbtnYes.Checked)
                {
                    inspection = "N";
                }
 
                //�Ƿ�Ϊ���
                if (!rdtnScienceYes.Checked)
                {
                    Science = "N";
                }
                if (cboType.Text.Trim() == "")
                {
                    App.Msg("���ͱ�����д��");
                    cboType.Focus();
                    return;
                }
                //סԺ��������ұ�־
                if (!rbtnHospital.Checked)
                {
                    Hospital = "O";
                }
                if (cboProperty.Text.Trim() == "")
                {
                    App.Msg("���ҹ������Ա�����д��");
                    cboProperty.Focus();
                    return;
                }
                //��Ч��־
                if (!rbtnValidmark.Checked)
                {
                    Mark = "N";
                }
                if (cboBranchcourts.Text.Trim() == "")
                {
                    App.Msg("������Ժ������д��");
                    cboBranchcourts.Focus();
                    return;
                }
                string sql = "";
                string bigid = "";
                if (rdtnScienceYes.Checked)
                {
                    bigid = null;
                }
                else
                {
                    if (cboBigscience.SelectedItem!= null)
                    {
                        Class_Sections temp = (Class_Sections)cboBigscience.SelectedItem;
                        bigid = temp.Sid.ToString();
                    }
                }
               
                ID = App.GenId("T_SECTIONINFO", "SID").ToString();
                if (IsSave)
                {
                    if (isExisitNames(App.ToDBC(txtID.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�Ŀ��ұ���ˣ�");
                        txtID.Focus();
                        return;
                    }
                    else if (Isnames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ�Ŀ��������ˣ�");
                        txtName.Focus();
                        return;
                    }
                   
                    sql = "insert into T_SECTIONINFO(SID,SECTION_CODE,SECTION_NAME,BELONGTO_SECTION_ID,ISCHECKSECTION,BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,ISBELONGTOBIGSECTION,TYPEINFO,IN_FLAG,MANAGE_TYPE,ENABLE_FLAG,SHID) values('"
                         +ID+"','"
                         + txtID.Text + "','"
                         + txtName.Text + "','"
                         + cboOffice.Text + "','"
                         + inspection + "','"
                         + cboComputation.Text + "','"
                         + bigid + "','"
                         + Science + "','"
                         + cboType.SelectedValue+ "','"
                         + Hospital + "','"
                         + cboProperty.SelectedValue+ "','"
                         + Mark + "','"
                         + cboBranchcourts.SelectedValue + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (section_code.Trim() != "")
                    {
                        if (txtID.Text.Trim() != section_code.Trim())
                        {
                            if (isExisitNames(App.ToDBC(txtID.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�Ŀ��ұ���ˣ�");
                                txtID.Focus();
                                return;
                            }
                        }
                    }
                    else if (section_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != section_name.Trim())
                        {
                          if (Isnames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ�Ŀ��������ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_SECTIONINFO set SECTION_CODE='"
                              + txtID.Text + "',SECTION_NAME='"
                              + App.ToDBC(txtName.Text) + "',BELONGTO_SECTION_ID='"
                              + cboOffice.Text + "',ISCHECKSECTION='"
                              + inspection + "',BELONGTO_SECTION_NAME='"
                              + cboComputation.Text + "',BELONGTO_BIGSECTION_ID='"
                              + bigid+ "',ISBELONGTOBIGSECTION='"
                              + Science + "',TYPEINFO='"
                              + cboType.SelectedValue + "',IN_FLAG='"
                              + Hospital + "',MANAGE_TYPE='"
                              + cboProperty.SelectedValue+ "',ENABLE_FLAG='"
                              + Mark + "',SHID='"
                              + cboBranchcourts.SelectedValue + "' where SID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";

                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);
                    }

                //��ʾ�б�����
                ShowValue();
                //string Sql = T_section_Sql + "  order by SID asc";
                //ucC1FlexGrid1.DataBd(Sql, "SID", "SID,SECTION_CODE,SECTION_NAME,BELONGTO_SECTION_ID,ISCHECKSECTION,BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,ISBELONGTOBIGSECTION,TYPEINFO,TYPEINFO_NAME,IN_FLAG,MANAGE_TYPE,MANAGE_TYPE_NAME,ENABLE_FLAG,SHID,SHID_NAME", "���,���ұ��,��������,�����������,�Ƿ��Ǽ���,���������,�������,�Ƿ���,�����,���,סԺ�������־,���ҹ������Ա��,���ҹ�������,��Ч��־,��Ժ���,��Ժ����");
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
            refurbish();
            //RefleshFrm();
        }

       /// <summary>
       /// ɾ��������Ϣ
       /// </summary>
       /// <param Name="sender"></param>
       /// <param Name="e"></param>
     
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }
            /// ˢ�±��
        /// </summary>
        private void refurbish()
        {
            txtID.Text = "";
            txtName.Text = "";
            cboOffice.Text = "";
            cboComputation.Text = "";
            txtID.Enabled = false;
            txtName.Enabled = false;
            cboOffice.Enabled = false;
            rbtnYes.Enabled = false;
            rbtnNo.Enabled = false;
            cboComputation.Enabled = false;
            cboBigscience.Enabled = false;
            rdtnScienceYes.Enabled = false;
            rdtnScienceNo.Enabled = false;
            cboType.Enabled = false;
            rbtnHospital.Enabled = false;
            rbtnOutpatient.Enabled = false;
            cboProperty.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            cboBranchcourts.Enabled = false;
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
                DataSet ds = App.GetDataSet("select Count(*) from T_SECTION_AREA where SID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
                if (ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                {
                    string sqlup = "update  T_SECTIONINFO set ENABLE_FLAG='N' where SID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";
                    App.ExecuteSQL(sqlup);
                }
                else
                {
                    if (App.Ask("�ÿ�����Ϣ�Ѿ��벡���������������������ǡ�ɾ�����Ҳ��������!"))
                    {
                        string sqlup = "update  T_SECTIONINFO set ENABLE_FLAG='N' where SID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";
                        App.ExecuteSQL(sqlup);
                    }
                }
            }
            //��ʾ�б�����
            ShowValue();
            refurbish();
            //string Sql = T_section_Sql + "   order by SID asc";
            //ucC1FlexGrid1.DataBd(Sql, "SID", "SID,SECTION_CODE,SECTION_NAME,BELONGTO_SECTION_ID,ISCHECKSECTION,BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,ISBELONGTOBIGSECTION,TYPEINFO,TYPEINFO_NAME,IN_FLAG,MANAGE_TYPE,MANAGE_TYPE_NAME,ENABLE_FLAG,SHID,SHID_NAME", "���,���ұ��,��������,�����������,�Ƿ��Ǽ���,���������,�������,�Ƿ���,�����,���,סԺ�������־,���ҹ������Ա��,���ҹ�������,��Ч��־,��Ժ���,��Ժ����");
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
                if (ucGridviewX1.fg.Rows.Count> 0)
                {
                    ID =ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtID.Text = ucGridviewX1.fg["���ұ��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    section_code = txtID.Text;
                    txtName.Text = ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    section_name = txtName.Text;
                    cboOffice.Text = ucGridviewX1.fg["�����������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["�Ƿ��Ǽ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                    {
                        rbtnYes.Checked = true;
                    }
                    else
                    {
                        rbtnNo.Checked = true;
                    }
                    cboComputation.Text = ucGridviewX1.fg["���������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    cboBigscience.SelectedItem = null;
                    if (ucGridviewX1.fg["�Ƿ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                    {
                        rdtnScienceYes.Checked = true;
                        cboBigscience.SelectedItem = null;
                    }
                    else
                    {
                        rdtnScienceNo.Checked = true;
                        string sid = "";
                        if (ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                        {
                            //cboBigscience.SelectedValue = Convert.ToInt32();

                            sid = ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                            SelectValues(sid);
                        }
                        else
                        {
                            SelectValues(sid);
                        }

                    }
                    if (ucGridviewX1.fg["�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboType.SelectedValue = ucGridviewX1.fg["�����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    }
                    if (ucGridviewX1.fg["סԺ�������־",ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "סԺ")
                    {
                        rbtnHospital.Checked = true;
                    }
                    else
                    {
                        rbtnOutpatient.Checked = true;
                    }
                    if (ucGridviewX1.fg["���ҹ������Ա��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboProperty.SelectedValue = ucGridviewX1.fg["���ҹ������Ա��", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    }
                    if (ucGridviewX1.fg["��Ч��־",ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��Ч")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }
                    if (ucGridviewX1.fg["��Ժ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboBranchcourts.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["��Ժ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    cboBranchcourts.Refresh();
                   

                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }
        /// <summary>
        /// ���ݱ��ѡ�������б�
        /// </summary>
        /// <returns></returns>
        public void SelectValues(string sid)
        {
            //bool flag = false;
            foreach (object var in cboBigscience.Items)
            {
                Class_Sections class_Section = var as Class_Sections;
                if (sid == class_Section.Sid.ToString())
                {
                    cboBigscience.SelectedItem = var;
                    break;
                }
                else
                {
                    cboBigscience.SelectedIndex = 0;
                }
            }
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
                string Sql = T_section_Sql + "  order by SID desc";
              
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }
        ��������//���������ƽ��в�ѯ
                if (chkName.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_section_Sql + " and  SECTION_NAME��like'%" + txtBox.Text.Trim() + "%' order by SID desc";
                        
                    }

                }
                //�����ұ�Ž��в�ѯ
                else if (chkId.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_section_Sql + " and SECTION_CODE like'%" + txtBox.Text.Trim() + "%' order by SID desc";
                        
                    }
                }

                ucGridviewX1.DataBd(Sql, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������"].Visible = false;
                ucGridviewX1.fg.Columns["�������"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�����"].Visible = false;
                ucGridviewX1.fg.Columns["�����"].ReadOnly = true;
                ucGridviewX1.fg.Columns["���ҹ������Ա��"].Visible = false;
                ucGridviewX1.fg.Columns["���ҹ������Ա��"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ժ���"].Visible = false;
                ucGridviewX1.fg.Columns["��Ժ���"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
               
            }
            catch(Exception ex)
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnLookup.Enabled = true;
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
                cboType.Focus();
            }
     
        }


        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnYes.Focus();
            }

        }

        private void rbtnYes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdtnScienceYes.Focus();
                //cboComputation.Focus();
            }

        }

        private void rbtnNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdtnScienceYes.Focus();
                //cboComputation.Focus();
            }

        }

        private void cboComputation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboBigscience.Focus();
            }

        }
        private void cboOffice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdtnScienceYes.Focus();
            }

        }

 

        private void rdtnScienceYes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnHospital.Focus();              
                
            }

        }

        private void rdtnScienceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboBigscience.Focus();
                //cboType.Focus();
            }

        }

        private void cboBigscience_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnHospital.Focus();
            }

        }
        private void rbtnHospital_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboProperty.Focus();
            }

        }

        private void rbtnOutpatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboProperty.Focus();
            }

        }

        private void cboProperty_KeyDown(object sender, KeyEventArgs e)
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
                cboBranchcourts.Focus();
            }

        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboBranchcourts.Focus();
            }

        }

        private void cboBranchcourts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void rdtnScienceYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnScienceYes.Checked == true)
            {
                if (btnCancel.Enabled)
                {
                    cboBigscience.Enabled = false;
                    cboBigscience.SelectedIndex = -1;
                }
               
            }            
        }

        private void rdtnScienceNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnScienceNo.Checked == true)
            {
                BigSenction();
                if (btnCancel.Enabled)
                    cboBigscience.Enabled = true;
              cboBigscience.SelectedIndex = 0;
             
            }
        }

 




  

      


    }
}