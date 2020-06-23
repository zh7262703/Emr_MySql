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
    public partial class ucSickAreaInfo : UserControl
    {
        bool IsSave = false;��               //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string BigsickArea = "Y";   //�Ƿ�Ϊ����
        private string mark = "Y";         //��Ч��־
        private string  ID="";            //����ID
        private string T_SickArea_Sql;   //������ѯ
        Class_Sickarea[] sickarea;
        private string sick_area_code;   //��ǰѡ�еĲ������
        private string sick_area_name;   //��ǰѡ�еĲ�������
        DataSet ds;
        public ucSickAreaInfo()
        {
            InitializeComponent();
            T_SickArea_Sql = @"select SAID as ���,a.SHID as ��Ժ���,c.sub_hospital_name as ��Ժ����,SICK_AREA_CODE as �������," +
                         @"SICK_AREA_NAME as ��������,(case when ISBELONGTOSECTION='Y' then '��' else '��' end) as �Ƿ����," +
                         @"BELONGTOSECTION as ��������,(select SICK_AREA_NAME from T_SICKAREAINFO b where b.SAID=a.belongtosection and ENABLE_FLAG='Y') as ��������," +
                         @"(case when ENABLE_FLAG='Y' then '��Ч' else '��Ч' end) as ��Ч��־," +
                         @"BED_COUNT as ��׼������,ALOW_COUNT as ����Ӵ��� from T_SICKAREAINFO a inner join T_SUB_HOSPITALINFO c on a.shid=c.shid where ENABLE_FLAG='Y'";
        }

        private void frmSickAreaInfo_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("������Ϣ");
            //��ʾ�б�����
            ShowValue();

            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            HospitalInfo();
            Bigsickarea();
            btnCancel_Click(sender, e);
            cboBigsickarea.SelectedIndex = 0;
            RefleshFrm();
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {

                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ժ���"].Visible = false;
                ucGridviewX1.fg.Columns["��Ժ���"].ReadOnly = true;
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
           
                string SQl = T_SickArea_Sql + " order by SAID desc";
                 ds = App.GetDataSet(SQl);
                 if (ds != null)
                 {

                     //    ucC1FlexGrid1.fg.DataSource = ds.Tables[0].DefaultView;
                     ucGridviewX1.DataBd(SQl, "���", false, "", "");
                     ucGridviewX1.fg.Columns["���"].Visible = false;
                     ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                     ucGridviewX1.fg.Columns["��Ժ���"].Visible = false;
                     ucGridviewX1.fg.Columns["��Ժ���"].ReadOnly = true;
                     ucGridviewX1.fg.Columns["��������"].Visible = false;
                     ucGridviewX1.fg.Columns["��������"].ReadOnly = true;
                     ucGridviewX1.fg.ReadOnly = true;
                 }

        }
        //�󶨴���
        private void Bigsickarea()
        {
            cboBigsickarea.Items.Clear();
            Class_Sickarea none=new Class_Sickarea();
            none.Said = "";
            none.Shid = "��";
            none.Sick_area_code = "��";
            none.Sick_area_name = "��";
            none.Isbelongtosection = "��";
            none.Belongtosection="��";
            none.Enable_flag = "��";
            none.Bed_count = "��";
            none.Alow_count = "��";
            cboBigsickarea.Items.Add(none);
            DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO where ISBELONGTOSECTION='Y'and ENABLE_FLAG='Y'");
            sickarea = new Class_Sickarea[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                sickarea[i] = new Class_Sickarea();
                sickarea[i].Said =ds.Tables[0].Rows[i]["SAID"].ToString();
                sickarea[i].Shid = ds.Tables[0].Rows[i]["SHID"].ToString();
                sickarea[i].Sick_area_code = ds.Tables[0].Rows[i]["SICK_AREA_CODE"].ToString();
                sickarea[i].Sick_area_name = ds.Tables[0].Rows[i]["SICK_AREA_NAME"].ToString();
                sickarea[i].Isbelongtosection = ds.Tables[0].Rows[i]["ISBELONGTOSECTION"].ToString();
                sickarea[i].Belongtosection = ds.Tables[0].Rows[i]["BELONGTOSECTION"].ToString();
                sickarea[i].Enable_flag = ds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                sickarea[i].Bed_count = ds.Tables[0].Rows[i]["BED_COUNT"].ToString();
                sickarea[i].Alow_count = ds.Tables[0].Rows[i]["ALOW_COUNT"].ToString();
                cboBigsickarea.Items.Add(sickarea[i]);
                
            }
            //cboBigsickarea.DataSource = ds.Tables[0].DefaultView;
            cboBigsickarea.ValueMember = "SAID";
            cboBigsickarea.DisplayMember = "SICK_AREA_NAME";
        }
        //������Ժ
        private void HospitalInfo()
        {
            DataSet ds = App.GetDataSet("select * from T_SUB_HOSPITALINFO ");
            cboBranchcourts.DataSource = ds.Tables[0].DefaultView;
            cboBranchcourts.ValueMember = "SHID";
            cboBranchcourts.DisplayMember = "SUB_HOSPITAL_NAME";
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
   
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboBigsickarea.Enabled = false;
            rdtnSickAreaYes.Enabled = false;
            rdtnSickAreaNo.Enabled = false;
            cboBranchcourts.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            txtSickbed.Enabled = false;
            txtExtrabed.Enabled = false;
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
                txtSickbed.Text = "";
                txtExtrabed.Text = "";
            }
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            cboBigsickarea.Enabled = true;
            rdtnSickAreaYes.Enabled = true;
            rdtnSickAreaNo.Enabled = true;
            cboBranchcourts.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            txtSickbed.Enabled = true;
            txtExtrabed.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
            if (rdtnSickAreaYes.Checked == true)
            {
                if (btnCancel.Enabled)
                {
                    cboBigsickarea.Enabled = false;
                    cboBigsickarea.SelectedIndex = -1;
                }
            }
            else
            {
                cboBigsickarea.Enabled = true;
            }
            txtNumber.Focus();
        }

        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO where SICK_AREA_CODE='" + id + "'");
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
            DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO where SICK_AREA_NAME='" + name + "'");
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
        ///���
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
                    App.Msg("������Ų���Ϊ�գ�");
                    txtNumber.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("�������Ʋ���Ϊ�գ�");
                    txtName.Focus();
                    return;
                }
                if (cboBranchcourts.Text.Trim() == "")
                {
                    App.Msg("������Ժ����Ϊ�գ�");
                    cboBranchcourts.Focus();
                    return;
                }
                if (!rdtnSickAreaYes.Checked)
                {
                    BigsickArea = "N";

                }
                if (!rbtnValidmark.Checked)
                {
                    mark = "N";
                }
                string sql = "";
                string bigid = "";
                if (rdtnSickAreaYes.Checked)
                {
                    bigid = null;
                }
                else
                {
                
                    if (cboBigsickarea.SelectedItem != null)
                    {
                        Class_Sickarea temp = (Class_Sickarea)cboBigsickarea.SelectedItem;
                        bigid = temp.Said.ToString();
                    }
                }
                ID = App.GenId("T_SICKAREAINFO", "SAID").ToString();
                if (IsSave)
                {
                    if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���ƵĲ�������ˣ�");
                        txtNumber.Focus();
                        return;
                    }
                    else if (Isnames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���ƵĲ��������ˣ�");
                        txtName.Focus();
                        return;
                    }

                    sql = "insert into T_SICKAREAINFO(SAID,SHID,SICK_AREA_CODE,SICK_AREA_NAME,ISBELONGTOSECTION,BELONGTOSECTION,ENABLE_FLAG,BED_COUNT,ALOW_COUNT) values('"
                         + ID + "','"
                         + cboBranchcourts.SelectedValue + "','"
                         + txtNumber.Text + "','"
                         + App.ToDBC(txtName.Text) + "','"
                         + BigsickArea + "','"
                         + bigid + "','"
                         + mark + "','"
                         +txtSickbed.Text+ "','"
                         +txtExtrabed.Text + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (sick_area_code.Trim() != "")
                    {
                        if (txtNumber.Text.Trim()!=sick_area_code.Trim())
                        {
                           if (isExisitNames(App.ToDBC(txtNumber.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ���ƵĲ�������ˣ�");
                                txtNumber.Focus();
                                return;
                            }
                        }
                    }
                    else if (sick_area_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != sick_area_name.Trim())
                        {
                            if (Isnames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("�Ѿ���������ͬ���ƵĲ��������ˣ�");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_SICKAREAINFO set SHID='"
                              + cboBranchcourts.SelectedValue + "',SICK_AREA_CODE='"
                              + txtNumber.Text + "',SICK_AREA_NAME='"
                              + App.ToDBC(txtName.Text) + "',ISBELONGTOSECTION='"
                              + BigsickArea + "',BELONGTOSECTION='"
                              + bigid + "',ENABLE_FLAG='"
                              + mark + "',BED_COUNT='"
                              + txtSickbed.Text + "',ALOW_COUNT='"
                              + txtExtrabed.Text + "' where SAID=" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";

                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        btnCancel_Click(sender, e);
                    }
                //��ʾ�б�����
                ShowValue();
                //string SQl = T_SickArea_Sql;
                //ucC1FlexGrid1.DataBd(SQl, "SAID", "SAID,SHID,SHID_NAME,SICK_AREA_CODE,SICK_AREA_NAME,ISBELONGTOSECTION,BELONGTOSECTION,ENABLE_FLAG,BED_COUNT,ALOW_COUNT", "���,��Ժ���,��Ժ����,�������,��������,�Ƿ����,��������,��Ч��־,��׼������,����Ӵ���");
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
                    txtNumber.Text = ucGridviewX1.fg["�������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    sick_area_code = txtNumber.Text;
                    txtName.Text = ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    sick_area_name = txtName.Text;
                    //cboBigsickarea.Text = "";
                    //cboBigsickarea.Items.Clear();
                    cboBigsickarea.SelectedItem = null;
                    if (ucGridviewX1.fg["�Ƿ����", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��")
                    {
                        rdtnSickAreaYes.Checked = true;
                        //cboBigsickarea.SelectedItem = -1;
                        cboBigsickarea.SelectedItem = null;
                    }
                    else
                    {
                        string said = "";
                        rdtnSickAreaNo.Checked = true;
                        if (ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                        {
                            said = ucGridviewX1.fg["��������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                            SelectValues(said);
                        }
                        else
                        {

                            SelectValues(said);
                        }


                    }

                    if (ucGridviewX1.fg["��Ժ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboBranchcourts.SelectedValue = ucGridviewX1.fg["��Ժ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    }
                    if (ucGridviewX1.fg["��Ч��־", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "��Ч")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }
                    if (ucGridviewX1.fg["��׼������", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        txtSickbed.Text = Convert.ToInt32(ucGridviewX1.fg["��׼������", ucGridviewX1.fg.CurrentRow.Index].Value).ToString();
                    }
                    if (ucGridviewX1.fg["����Ӵ���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        txtExtrabed.Text = Convert.ToInt32(ucGridviewX1.fg["����Ӵ���", ucGridviewX1.fg.CurrentRow.Index].Value).ToString();
                    }

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
            txtSickbed.Text = "";
            txtExtrabed.Text = "";
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            cboBigsickarea.Enabled = false;
            rdtnSickAreaYes.Enabled = false;
            rdtnSickAreaNo.Enabled = false;
            cboBranchcourts.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            txtSickbed.Enabled = false;
            txtExtrabed.Enabled = false;
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
                DataSet ds = App.GetDataSet("select Count(*) from T_SECTION_AREA where SAID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");
                if (ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                {
                    string sql = "update  T_SICKAREAINFO  set ENABLE_FLAG='N' where  SAID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";
                    App.ExecuteSQL(sql);
                    
                }
                else
                {
                    
                    if (App.Ask("�ò�����Ϣ�Ѿ�����һ������������������ǡ�ɾ���������������!"))
                    {
                        App.ExecuteSQL("update T_SICKAREAINFO  set ENABLE_FLAG='N' where  SAID='" + ucGridviewX1.fg["���", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'");
                        
                    }
                }
            }
            //��ʾ�б�����
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

                string Sql = T_SickArea_Sql + " order by SAID desc";
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtBox.Focus();
                    return;
                }
                //���������ƽ��в�ѯ
                if (chkName.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_SickArea_Sql + " and SICK_AREA_NAME��like'%" + txtBox.Text.Trim() + "%' order by SAID desc";
                      
                    }

                }
                //��������Ž��в�ѯ
                else if (chkId.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_SickArea_Sql + " and ��SICK_AREA_CODE ��like'%" + txtBox.Text.Trim() + "%' order by SAID desc";
                       
                    }
                }
                ucGridviewX1.DataBd(Sql, "���", false, "", "");
                ucGridviewX1.fg.Columns["���"].Visible = false;
                ucGridviewX1.fg.Columns["���"].ReadOnly = true;
                ucGridviewX1.fg.Columns["��Ժ���"].Visible = false;
                ucGridviewX1.fg.Columns["��Ժ���"].ReadOnly = true;
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
                cboBranchcourts.Focus();
            }

        }

        private void cboBranchcourts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdtnSickAreaYes.Focus();
            }

        }

        private void rdtnSickAreaYes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnValidmark.Focus();
            }

        }

        private void rdtnSickAreaNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboBigsickarea.Focus();
            }

        }
        private void cboBigsickarea_KeyDown(object sender, KeyEventArgs e)
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
                txtSickbed.Focus();
            }

        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSickbed.Focus();
            }

        }

        private void txtSickbed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtExtrabed.Focus();
            }

        }

        private void txtExtrabed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        
        }

        private void rdtnSickAreaYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnSickAreaYes.Checked == true)
            {
                if (btnCancel.Enabled)
                {
                    cboBigsickarea.Enabled = false;
                    cboBigsickarea.SelectedIndex = -1;
                } 
            } 
        }

        private void rdtnSickAreaNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnSickAreaNo.Checked == true)
            {
                Bigsickarea();
                if (btnCancel.Enabled)
                    cboBigsickarea.Enabled = true;
                cboBigsickarea.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// ���ݱ��ѡ�������б�
        /// </summary>
        /// <returns></returns>
        public void SelectValues(string said)
        { 
            //bool flag =false;
            foreach (object var in cboBigsickarea.Items)
	        {
                Class_Sickarea class_Sickarea = var as Class_Sickarea;
                if (said == class_Sickarea.Said.ToString())
                {
                    cboBigsickarea.SelectedItem = var;
                    break;
                }
                else
                {
                    cboBigsickarea.SelectedIndex = 0;
                }
	        }
        }
     
    }
}