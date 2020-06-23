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
    public partial class ucDiagnosis_Treat :UserControl
    {
        bool IsSave = false;������������//���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        //bool isbool = false;
        private string Mark = "Y";      //��Ч��־
        private string ID = "";         //���ƻ�����ID

        private string Sql_Type_1 = ""; //�������ѯ

        private string Sql_Type_2 = ""; //�������ѯ
        private string tng_code = "";   //��ǰѡ�е����ƻ�������
        private string tng_name = ""; //��ǰѡ�е����ƻ���������

        public ucDiagnosis_Treat()
        {
            InitializeComponent();

            Sql_Type_1 = @"select TNG_ID��as ���,TNG_CODE as ���ƻ�������,TNG_NAME as  ���ƻ���������," +
                       @"DIRECTOR_ID  as �鳤���,b.user_name as �鳤����," +
                       @"(case when TNG_TYPE=0 then '������'  else '������' end) as ���," +
                       @"(case when a.ENABLE_FLAG='Y' then '��Ч' else '��Ч' end) as ��Ч��־," +
                       @"BELONGTO_ID  as  �������һ������,c.section_name as �������һ�������," +
                       @"SPECIALTIES_FLAG as ������ from T_TREATORNURSE_GROUP a left join T_USERINFO b on b.user_id=a.director_id left join T_SECTIONINFO c on c.sid=a.belongto_id where TNG_TYPE=0 ";

            Sql_Type_2 = @" select TNG_ID as ���,TNG_CODE as ���ƻ�������,TNG_NAME as  ���ƻ���������," +
                                   @"DIRECTOR_ID  as �鳤���,b.user_name as �鳤����," +
                                   @"(case when TNG_TYPE=0 then '������'  else '������' end) as ���," +
                                   @"(case when a.ENABLE_FLAG='Y' then '��Ч' else '��Ч' end) as ��Ч��־," +
                                   @"BELONGTO_ID  as  �������һ������,d.sick_area_name as �������һ�������," +
                                   @"SPECIALTIES_FLAG as ������ from T_TREATORNURSE_GROUP a left join T_USERINFO b on b.user_id=a.director_id left join T_SICKAREAINFO d on d.said=a.belongto_id where TNG_TYPE<>0 ";
        }

        private void frmDiagnosis_Treat_Load(object sender, EventArgs e)
        {
                //App.SetMainFrmMsgToolBarText("���ƻ�������Ϣ");

                ShowValue();

                ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                //ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
                ucGridviewX1.fg.AllowUserToAddRows = false;

                if (cboType.Items.Count>0)
                   cboType.SelectedIndex = 0;
                if (cboSec_sick.Items.Count>0)
                   cboSec_sick.SelectedIndex = 0;
               
                RefleshFrm();
      

        }
        private void frmDiagnosis_Treat_Activated(object sender, EventArgs e)
        {
            //�󶨲�����Ϣ
            Sick();
            //�󶨿�����Ϣ
            Section();
        }
 
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�鳤���"].Visible = false;
                ucGridviewX1.fg.Columns["�鳤���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������һ������"].Visible = false;
                ucGridviewX1.fg.Columns["�������һ������"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
            catch
            { }
        }
        DataSet ds;
        //��ʾ����
        private void ShowValue()
        {
            string Sql = Sql_Type_1 + "union" + Sql_Type_2;
            ds = App.GetDataSet(Sql);
            if (ds != null)
            {
                ucGridviewX1.DataBd(Sql, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�鳤���"].Visible = false;
                ucGridviewX1.fg.Columns["�鳤���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������һ������"].Visible = false;
                ucGridviewX1.fg.Columns["�������һ������"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }
        }

        //���û���Ϣ
        private void User()
        {
            try
            {
                if (cboType.SelectedItem.ToString() == "������")
                {
                   /* string sql = @"select distinct tua.user_id,tua.user_name,tua.u_position from t_userinfo  tua " +
                         @"inner join t_account_user  tac on tac.user_id=tua.user_id " +
                         @"inner join  t_acc_role_range rag on rag.acc_role_id=tac.account_id " +
                         @"inner join t_sectioninfo sct on sct.sid=rag.section_id " +
                         @"where sct.ENABLE_FLAG='Y' and sct.ISBELONGTOBIGSECTION='N' and tua.U_POSITION='21' and  tua.ENABLE='Y' and  sct.sid='" + cboSec_sick.SelectedValue+ "'";*/
                    string sql = "select distinct tua.user_id,tua.user_name,tua.u_position from t_userinfo  tua " +
                                @"inner join t_account_user  tot on tot.user_id=tua.user_id  " +
                                @"inner join t_acc_role tac on tac.account_id=tot.account_id " +
                                @"inner join t_acc_role_range rag on tac.id = rag.acc_role_id " +
                                @"inner join t_sectioninfo sct on sct.sid=rag.section_id where sct.ENABLE_FLAG='Y' " +
                                @"and sct.ISBELONGTOBIGSECTION='N' and tac.role_id='21' and  tua.ENABLE='Y' and  sct.sid='" + cboSec_sick.SelectedValue + "'";
                    
                    DataSet ds = App.GetDataSet(sql);
                    cboUser.DataSource = ds.Tables[0].DefaultView;
                    cboUser.ValueMember = "USER_ID";
                    cboUser.DisplayMember = "USER_NAME";
                }
                else
                {
                    /*string sql = @"select distinct tua.user_id,tua.user_name,tua.u_position from t_userinfo  tua " +
                         @"inner join t_account_user  tac on tac.user_id=tua.user_id " +
                         @"inner join  t_acc_role_range rag on rag.acc_role_id=tac.account_id " +
                         @"inner join T_SICKAREAINFO tck on tck.said=rag.sickarea_id  " +
                         @"where tck.ENABLE_FLAG='Y' and tck.ISBELONGTOSECTION='N' and tua.U_POSITION='26' and  tua.ENABLE='Y' and  tck.said='" + cboSec_sick.SelectedValue + "'";*/
                   
                    
                    string  sql="select distinct tua.user_id,tua.user_name,tua.u_position from t_userinfo  tua "+
                                @"inner join t_account_user  tot on tot.user_id=tua.user_id "+
                                @"inner join t_acc_role tac on tac.account_id=tot.account_id "+
                                @"inner join t_acc_role_range rag on tac.id = rag.acc_role_id "+
                                @"inner join T_SICKAREAINFO tck on tck.said=rag.sickarea_id   "+
                                @"where tck.ENABLE_FLAG='Y' and tck.ISBELONGTOSECTION='N' and tac.role_id='26' and  tua.ENABLE='Y' and tck.said='" + cboSec_sick.SelectedValue + "'";
                    DataSet ds = App.GetDataSet(sql);
                    cboUser.DataSource = ds.Tables[0].DefaultView;
                    cboUser.ValueMember = "USER_ID";
                    cboUser.DisplayMember = "USER_NAME";
                }
            }
            catch
            {
            }

        }
        //�󶨿�����Ϣ
        private void Section()
        {
            try
            {
                string sql = "select * from T_SECTIONINFO where ENABLE_FLAG='Y' and ISBELONGTOBIGSECTION='N'";
                DataSet ds = App.GetDataSet(sql);
                cboSec_sick.DataSource = ds.Tables[0].DefaultView;
                cboSec_sick.ValueMember = "SID";
                cboSec_sick.DisplayMember = "SECTION_NAME";
            }
            catch
            {
            }
     
 
        }
        //�󶨲�����Ϣ
        private void Sick()
        {

            try
            {
               
                DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO where ENABLE_FLAG='Y' and ISBELONGTOSECTION='N'");
                cboSec_sick.DataSource = ds.Tables[0].DefaultView;
                cboSec_sick.ValueMember = "SAID";
                cboSec_sick.DisplayMember = "SICK_AREA_NAME";
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
            cboUser.Enabled = false;
            cboType.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            cboSec_sick.Enabled = false;
            txtMak.Enabled = false;
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
            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            cboUser.Enabled = true;
            cboType.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            cboSec_sick.Enabled = true;
            txtMak.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            txtNumber.Focus();
        }

        private void cboBranchcourts_SelectedIndexChanged(object sender, EventArgs e)
        {
      
                if (cboType.SelectedItem.ToString() == "������")
                {
                    Section();
                    User();

                }
                else
                {
                    Sick();
                    User();
                }
     
        }
        private void cboSec_sick_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSec_sick.Items.Count > 0)
            {
                User();
            }
        }

        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_TREATORNURSE_GROUP where TNG_CODE='" + id + "'");
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
            DataSet ds = App.GetDataSet(@"select * from T_TREATORNURSE_GROUP where TNG_NAME='" + name + "'");
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
                if (txtNumber.Text.Trim()=="")
                {
                    App.Msg("����/�������ű�����д��");
                    txtNumber.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("����/���������Ʊ�����д��");
                    txtName.Focus();
                    return;
                }
                if (cboUser.Text.Trim() == "")
                {
                    App.Msg("�����鳤������д��");
                    cboUser.Focus();
                    return;
                }
                if (cboType.Text.Trim() == "")
                {
                    App.Msg("���ͱ�����д��");
                    cboType.Focus();
                    return;
                }
              
                //��Ч��־
                if (!rbtnValidmark.Checked)
                {
                    Mark = "N";
                }
                if (cboSec_sick.Text.Trim() == "")
                {
                    App.Msg("�������һ���������д��");
                    cboSec_sick.Focus();
                    return;
                }
                string sql = "";

                ID = App.GenId("T_TREATORNURSE_GROUP", "TNG_ID").ToString();
                if (IsSave)
                {
                    if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���Ƶ����ƻ��������ˣ�");
                        txtNumber.Focus();
                        return;
                    }
                    else if (Isnames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���ƻ��������Ƶ�ֵ�ˣ�");
                        txtName.Focus();
                        return;
                    }

                    sql = "insert into T_TREATORNURSE_GROUP(TNG_ID,TNG_CODE,TNG_NAME,DIRECTOR_ID,TNG_TYPE,ENABLE_FLAG,BELONGTO_ID,SPECIALTIES_FLAG) values('"
                         + ID + "','"
                         + txtNumber.Text + "','"
                         + txtName.Text + "','"
                         + cboUser.SelectedValue + "','"
                         + cboType.SelectedIndex + "','"
                         + Mark+ "','"
                         + cboSec_sick.SelectedValue + "','"
                         +txtMak.Text+"')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (tng_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != tng_name.Trim())
                        {
                            if (Isnames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ���ƻ��������Ƶ�ֵ�ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    else if (tng_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != tng_name.Trim())
                        {
                            if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ������Ƶ�ֵ�ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_TREATORNURSE_GROUP set TNG_CODE='"
                              + txtNumber.Text + "',TNG_NAME='"
                              + App.ToDBC(txtName.Text) + "',DIRECTOR_ID='"
                              + cboUser.SelectedValue + "',TNG_TYPE='"
                              + cboType.SelectedIndex + "',ENABLE_FLAG='"
                              + Mark + "',BELONGTO_ID='"
                              + cboSec_sick.SelectedValue + "',SPECIALTIES_FLAG='"
                              + txtMak.Text + "' where TNG_ID=" + Convert.ToInt32(ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value).ToString() + "";

                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        //btnCancel_Click(sender, e);
                        refurbish();
                    }
                ShowValue();
                //string Sql = Sql_Type_1 + "union" + Sql_Type_2;
                //ucC1FlexGrid1.DataBd(Sql, "TNG_ID", "TNG_ID,TNG_CODE,TNG_NAME,DIRECTOR_ID,DIRECTOR_NAME,TNG_TYPE,ENABLE_FLAG,BELONGTO_ID,BELONGTO_NAME,SPECIALTIES_FLAG", "���,����/��������,����/����������,�鳤���,�鳤����,���,��Ч��־,�������һ������,�������һ�������,������");

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
            RefleshFrm();
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
                if (ucGridviewX1.fg.Rows.Count >= 0)
                {
                    ID = Convert.ToInt32(ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value).ToString();
                    txtNumber.Text = ucGridviewX1.fg["���ƻ�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    tng_code = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["���ƻ���������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    tng_name = txtName.Text;
                    if (ucGridviewX1.fg["�鳤���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboUser.SelectedValue = ucGridviewX1.fg["�鳤���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    }
                    if (ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "������")
                    {
                        cboType.SelectedIndex = 0;
                    }
                    else
                    {
                        cboType.SelectedIndex = 1;
                    }
                    if (ucGridviewX1.fg["��Ч��־", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��Ч")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }
                    if (ucGridviewX1.fg["�������һ������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboSec_sick.SelectedValue = ucGridviewX1.fg["�������һ������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    }
                    txtMak.Text = ucGridviewX1.fg["������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    
                    
                    
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
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }
         /// <summary>
        /// ˢ�±��
        /// </summary>
        private void refurbish()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboUser.Enabled = false;
            cboType.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            cboSec_sick.Enabled = false;
            txtMak.Enabled = false;
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

            DataSet ds = App.GetDataSet("select Count(*) from T_TNG_ACCOUNT where TNG_ID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");
                if (ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                {
                    if (App.Ask("���Ƿ�Ҫɾ��"))
                    {
                        App.ExecuteSQL("delete from T_TREATORNURSE_GROUP where  TNG_ID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");
                    }
                }
              else
                {
                    if (App.Ask("����/�ƻ�������Ϣ�Ѿ����˺Ź����������������ǡ�ɾ������/�����鲢�������!"))
                    {
                        App.ExecuteSQL("delete from T_TREATORNURSE_GROUP where  TNG_ID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");
                        string sql = "delete from T_TREATORNURSE_GROUP where TNG_ID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                        App.ExecuteSQL(sql);
                    }


                }
                
        
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

                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }              
                string Sql = Sql_Type_1  + " union "  +  Sql_Type_2;
                //�������ƻ��������ƽ��в�ѯ
                if (chkName.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                       

                        Sql = Sql_Type_1 + " and  TNG_NAME��like'%" + txtBox.Text.Trim() + "%' union " +  Sql_Type_2  + " and  TNG_NAME��like'%" + txtBox.Text.Trim() + "%'";
                       
                    }

                }
                //������ϻ�����ı�Ž��в�ѯ
                else if (chkId.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        
                        Sql = Sql_Type_1 + " and TNG_CODE��like'%" + txtBox.Text.Trim() + "%' union " +  Sql_Type_2  + " and  TNG_CODE��like'%" + txtBox.Text.Trim() + "%'";

                    }
                }

                ucGridviewX1.DataBd(Sql, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�鳤���"].Visible = false;
                ucGridviewX1.fg.Columns["�鳤���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["�������һ������"].Visible = false;
                ucGridviewX1.fg.Columns["�������һ������"].ReadOnly = true;
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
                cboUser.Focus();
            }

        }

        private void cboUser_KeyDown(object sender, KeyEventArgs e)
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
                rbtnValidmark.Focus();
            }
        }

        private void rbtnValidmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSec_sick.Focus();
            }
        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboSec_sick.Focus();
            }
        }

        private void cboSec_sick_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMak.Focus();
            }

        }

        private void txtMak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

  



  



 

    
    }
}