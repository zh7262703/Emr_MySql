using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;

namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// �������ֲ������ÿؼ�
    /// </summary>
    public partial class ucMedicalMark : UserControl
    {
        bool isSave = false;                       //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���

        int isMark = 0;

        string strRole_tyep = "";
        private string mark = "Y";                 //��Ч��־
        private string isSubjective = "Y";         //�Ƿ���������
        private string isSingVeto = "N";           //�Ƿ�����
        private string singVetoLev = "";           //����������
        private string isModifyManual = "Y";       //�Ƿ��ֶ��޸�

        private string vetoProjects = "";          //�����ĿID ���ŷָ�


        private string ID = "";                    //�����ֵ�ά��ID
        Class_Mark selectDirectionary = null;

        public ucMedicalMark()
        {
            InitializeComponent();
        }

        private void frmDictionary_Load(object sender, EventArgs e)
        {
            strRole_tyep = App.UserAccount.CurrentSelectRole.Role_type.ToString();//��ȡ��ǰ��½��ɫ����
            if (strRole_tyep == "H")//��������һЩ���Ӧ�����õ��ֶκ��ı���
            {
                label2.Visible = false;
                tbxPinyin.Visible = false;
                label10.Text = "   ���:";
                label11.Visible = false;
                tbxCheckReq.Visible = false;
                label7.Visible = false;
                cmbType.Visible = false;
            }
            Bangding();
            BangType();
            RefleshFrm();
            //btnAdd.Visible = false;
            btnModify.Visible = false;
            rbnModifyY.Enabled = false;
            rbnModifyN.Enabled = false;
         //   btnNewPFProgram.Visible = false;
        }

        //������
        private void Bangding()
        {
            if (strRole_tyep == "H")//Ŀǰ��Ϊ��ǰ�û���ɫΪ������ɫ����
            {
                DataSet dt = App.GetDataSet("select * from t_data_code where type = 196");
                cmbType.DataSource = dt.Tables[0].DefaultView;
                cmbType.ValueMember = "ID";
                cmbType.DisplayMember = "NAME";
            }
            else
            {
                DataSet dt = App.GetDataSet("select * from t_data_code where type = 196");
                cmbType.DataSource = dt.Tables[0].DefaultView;
                cmbType.ValueMember = "ID";
                cmbType.DisplayMember = "NAME";
            }
        }
        /// <summary>
        /// �󶨲�ѯ������
        /// </summary>
        private void BangType()
        {
            if (strRole_tyep == "H")//Ŀǰ��Ϊ��ǰ�û���ɫΪ������ɫ����
            {
                isMark = 1;
                DataSet dts = App.GetDataSet("select * from t_data_code where type = 196");
                cmbTypes.DataSource = dts.Tables[0].DefaultView;
                cmbTypes.ValueMember = "ID";
                cmbTypes.DisplayMember = "NAME";
                isMark = 0;
            }
            else
            {
                isMark = 1;
                DataSet dts = App.GetDataSet("select * from t_data_code where type = 196");
                cmbTypes.DataSource = dts.Tables[0].DefaultView;
                cmbTypes.ValueMember = "ID";
                cmbTypes.DisplayMember = "NAME";
                isMark = 0;
            }
        }

        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
            this.tbxName.Enabled = false;
            this.tbxPinyin.Enabled = false;
            this.tbxCode.Enabled = false;
            this.tbxCheckReq.Enabled = false;
            this.tbxDeductStand.Enabled = false;
            this.tbxDeductScore.Enabled = false;


            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            groupBox1.Enabled = true;

            selectDirectionary = null;
            trvDictionary.SelectedNode = null;

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
                this.tbxName.Text = "";
                this.tbxPinyin.Text = "";
                this.tbxCode.Text = "";
                this.tbxCheckReq.Text = "";
                this.tbxDeductStand.Text = "";
                this.tbxDeductScore.Text = "";

            }

            this.tbxName.Enabled = true;
            this.tbxPinyin.Enabled = true;
            this.tbxCode.Enabled = true;
            this.tbxCheckReq.Enabled = true;
            this.tbxDeductStand.Enabled = true;
            this.tbxDeductScore.Enabled = true;


            this.panel3.Enabled = true;
            this.panel4.Enabled = true;
            this.panel2.Enabled = true;
            this.panel6.Enabled = true;


            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;

            groupBox1.Enabled = false;

            this.tbxName.Focus();
        }
        /// <summary>
        /// ���ˢ��
        /// </summary>
        private void refurbish()
        {
            this.tbxName.Text = "";
            this.tbxPinyin.Text = "";
            this.tbxCode.Text = "";
            this.tbxCheckReq.Text = "";
            this.tbxDeductStand.Text = "";
            this.tbxDeductScore.Text = "";

            this.vetoProjects = "";

            this.tbxName.Enabled = false;
            this.tbxPinyin.Enabled = false;
            this.tbxCode.Enabled = false;
            this.tbxCheckReq.Enabled = false;
            this.tbxDeductStand.Enabled = false;
            this.tbxDeductScore.Enabled = false;

            this.panel3.Enabled = false;
            this.panel4.Enabled = false;
            this.panel2.Enabled = false;
            this.panel6.Enabled = false;

            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;

            groupBox1.Enabled = true;

            selectDirectionary = null;
            trvDictionary.SelectedNode = null;

            isSave = false;
        }
        /// <summary>
        /// ʵ������ѯ���
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Mark[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Mark[] Directionary = new Class_Mark[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Mark();

                        Directionary[i].ID = tempds.Tables[0].Rows[i]["ID"].ToString();
                        Directionary[i].Code = tempds.Tables[0].Rows[i]["CODE"].ToString();
                        Directionary[i].TypeId = tempds.Tables[0].Rows[i]["TYPE_ID"].ToString();
                        Directionary[i].Name = tempds.Tables[0].Rows[i]["NAME"].ToString();
                        Directionary[i].CheckReq = tempds.Tables[0].Rows[i]["CHECK_REQ"].ToString();
                        Directionary[i].DeductStand = tempds.Tables[0].Rows[i]["DEDUCT_STAND"].ToString();
                        Directionary[i].DeductScore = tempds.Tables[0].Rows[i]["DEDUCT_SCORE"].ToString();
                        Directionary[i].IsSingVeto = tempds.Tables[0].Rows[i]["ISSINGVETO"].ToString();
                        Directionary[i].SingVetoLev = tempds.Tables[0].Rows[i]["SINGVETO_LEV"].ToString();
                        Directionary[i].IsModifyManual = tempds.Tables[0].Rows[i]["ISMODIFY_MANUAL"].ToString();
                        Directionary[i].ValidState = tempds.Tables[0].Rows[i]["VALID_STATE"].ToString();
                        Directionary[i].SpellCode = tempds.Tables[0].Rows[i]["SPELL_CODE"].ToString();
                        Directionary[i].Type = tempds.Tables[0].Rows[i]["TYPE"].ToString();
                        Directionary[i].VetoProjects = tempds.Tables[0].Rows[i]["VETO_PROJECTS"].ToString();
                    }
                    return Directionary;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private void iniEditData(Class_Mark temp)
        {
            if (temp != null)
            {
                this.tbxCode.Text = temp.Code;
                this.cmbType.SelectedValue = temp.TypeId;
                this.tbxName.Text = temp.Name;
                this.tbxCheckReq.Text = temp.CheckReq;
                this.tbxDeductStand.Text = temp.DeductStand;
                this.tbxDeductScore.Text = temp.DeductScore;
                this.tbxPinyin.Text = temp.SpellCode;
                this.vetoProjects = temp.VetoProjects;

                if (temp.IsSingVeto == "Y")
                {
                    this.rbnSingVetoYes.Checked = true;
                    this.rbnSingVetoNo.Checked = false;

                    if (temp.SingVetoLev == "��")
                    {
                        this.rbnB.Checked = true;
                        this.rbnC.Checked = false;
                    }
                    else
                    {
                        this.rbnB.Checked = false;
                        this.rbnC.Checked = true;
                    }
                }
                else
                {
                    this.rbnSingVetoYes.Checked = false;
                    this.rbnSingVetoNo.Checked = true;
                }

                if (temp.IsModifyManual == "Y")
                {
                    this.rbnModifyY.Checked = true;
                    this.rbnModifyN.Checked = false;
                }
                else
                {
                    this.rbnModifyY.Checked = false;
                    this.rbnModifyN.Checked = true;
                }

                if (temp.ValidState == "Y")
                {
                    this.rbnYes.Checked = true;
                    this.rbnNo.Checked = false;
                }
                else
                {
                    this.rbnYes.Checked = false;
                    this.rbnNo.Checked = true;
                }

                if (temp.Type == "Y")
                {
                    this.rbnSubjective.Checked = true;
                    this.rbnObjective.Checked = false;
                }
                else
                {
                    this.rbnSubjective.Checked = false;
                    this.rbnObjective.Checked = true;
                }

            }
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            trvDictionary.SelectedNode = null;
            selectDirectionary = null;
            isSave = true;
            Edit(isSave);

        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                isSave = false;
                Edit(isSave);
            }
            else
            {
                App.Msg("����ѡ��Ҫ�޸ĵĽڵ㣡");
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

                if (string.IsNullOrEmpty(this.tbxName.Text.Trim()))
                {
                    App.Msg("��Ŀ���Ʋ���Ϊ�գ�");
                    this.tbxName.Focus();
                    return;
                }
                //if (string.IsNullOrEmpty(this.tbxCode.Text.Trim()))
                //{
                //    App.Msg("��Ŀ���벻��Ϊ�գ�");
                //    this.tbxCode.Focus();
                //    return;
                //}
                //if (string.IsNullOrEmpty(this.tbxCheckReq.Text.Trim()))
                //{
                //    App.Msg("���Ҫ����Ϊ�գ�");
                //    this.tbxCheckReq.Focus();
                //    return;
                //}
                if (string.IsNullOrEmpty(this.tbxDeductStand.Text.Trim()))
                {
                    App.Msg("�۷ֱ�׼����Ϊ�գ�");
                    this.tbxDeductStand.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.tbxDeductScore.Text.Trim()))
                {
                    App.Msg("����۷�ֵ����Ϊ�գ�");
                    this.tbxDeductScore.Focus();
                    return;
                }

                if (this.cmbType.Text.Trim() == "")
                {
                    App.Msg("���Ͳ���Ϊ�գ�");
                    this.cmbType.Focus();
                    return;
                }


                if (this.rbnSubjective.Checked)
                {
                    this.isSubjective = "Y";
                }
                else
                {
                    this.isSubjective = "N";
                }

                if (this.rbnSingVetoYes.Checked)
                {
                    this.isSingVeto = "Y";

                    if (this.rbnB.Checked) { this.singVetoLev = "��"; }
                    else { this.singVetoLev = "��"; }

                }
                else
                {
                    this.isSingVeto = "N";
                    this.singVetoLev = "";
                }

                if (this.rbnModifyY.Checked)
                {
                    this.isModifyManual = "Y";
                }
                else
                {
                    this.isModifyManual = "N";
                }


                if (this.rbnYes.Checked)
                {
                    this.mark = "Y";
                }
                else
                {
                    this.mark = "N";
                }



                string Sql = "";
                //ID = App.GenId("T_MEDICAL_MARK", "ID").ToString();

                ID = App.ReadSqlVal("select T_MEDICAL_MARK_ID.NEXTVAL as ID from dual", 0, "ID");
                if (isSave)
                {
                    Sql = "insert into T_MEDICAL_MARK(id,code,type_id,name,check_req,deduct_stand,deduct_score,issingveto,singveto_lev,ismodify_manual,valid_state,spell_code,type,veto_projects)values('" + ID + "','" + this.tbxCode.Text + "','"
                    + this.cmbType.SelectedValue + "','" + this.tbxName.Text + "','" + this.tbxCheckReq.Text + "','" + this.tbxDeductStand.Text + "','" + this.tbxDeductScore.Text + "','" + isSingVeto + "','" + singVetoLev + "','" + isModifyManual + "','" + mark + "','" + this.tbxPinyin.Text + "','" + isSubjective + "','" + vetoProjects + "')";
                    btnAdd_Click(sender, e);
                }
                else
                {
                    Sql = "update T_MEDICAL_MARK set code = '" + this.tbxCode.Text + "',type_id = '" + this.cmbType.SelectedValue + "',name = '" + this.tbxName.Text + "',check_req = '" + this.tbxCheckReq.Text + "',deduct_stand = '"
                        + this.tbxDeductStand.Text + "',deduct_score = '" + this.tbxDeductScore.Text + "',issingveto = '" + isSingVeto + "',singveto_lev = '" + singVetoLev + "',ismodify_manual = '" + isModifyManual + "',valid_state = '" + mark + "',spell_code = '" + this.tbxPinyin.Text + "',type = '" + isSubjective + "',veto_projects = '" + vetoProjects + "' where ID= '" + selectDirectionary.ID + "'";

                    selectDirectionary.Code = this.tbxCode.Text;
                    selectDirectionary.TypeId = this.cmbType.SelectedValue.ToString();
                    selectDirectionary.Name = this.tbxName.Text;

                    selectDirectionary.CheckReq = this.tbxCheckReq.Text;
                    selectDirectionary.DeductStand = this.tbxDeductStand.Text;
                    selectDirectionary.DeductScore = this.tbxDeductScore.Text;
                    selectDirectionary.IsSingVeto = isSingVeto;
                    selectDirectionary.SingVetoLev = singVetoLev;
                    selectDirectionary.IsModifyManual = isModifyManual;
                    selectDirectionary.ValidState = mark;
                    selectDirectionary.SpellCode = this.tbxPinyin.Text;
                    selectDirectionary.Type = this.isSubjective;
                    selectDirectionary.VetoProjects = vetoProjects;


                    trvDictionary.SelectedNode.Tag = selectDirectionary;
                    trvDictionary.SelectedNode.Text = this.tbxName.Text;
                    RefleshFrm();

                }
                if (Sql != "")
                    if (App.ExecuteSQL(Sql) > 0)
                    {
                        App.Msg("�����ɹ�");
                        btnCancel_Click(sender, e);
                        btnSelect_Click(sender, e);
                    }

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
        }
        /// <summary>
        /// ��������ʾ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDictionary_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {

                if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Mark"))
                {
                    selectDirectionary = (Class_Mark)trvDictionary.SelectedNode.Tag;
                    iniEditData(selectDirectionary);
                }
            }
        }

        private void trvDictionary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (groupBox1.Enabled && !isSave)
            {
                if (trvDictionary.SelectedNode != null)
                {
                    if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Mark"))
                    {
                        selectDirectionary = (Class_Mark)trvDictionary.SelectedNode.Tag;
                        iniEditData(selectDirectionary);
                    }
                }
            }
        }


        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelect.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                trvDictionary.Nodes.Clear();
                if (txtConditions.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ�գ�");
                    txtConditions.Focus();
                    return;
                }
                string Sql = "select * from  T_MEDICAL_MARK where TYPE_ID = '" + cmbTypes.SelectedValue + "' order by ID desc";
                if (radPY.Checked)
                {
                    if (txtConditions.Text.Trim() != "")
                        Sql = "select * from T_MEDICAL_MARK where SPELL_CODE like '%" + txtConditions.Text.Trim() + "%' and TYPE_ID ='" + cmbTypes.SelectedValue + "' order by ID desc";
                }
                else if (radName.Checked)
                {
                    if (txtConditions.Text.Trim() != "")
                        Sql = "select * from T_MEDICAL_MARK where NAME like '%" + txtConditions.Text.Trim() + "%' and TYPE_ID ='" + cmbTypes.SelectedValue + "' order by ID desc";
                }
                else
                {
                }
                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_Mark[] Directionarys = GetSelectDirectionary(ds);
                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        TreeNode tn = new TreeNode();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Name;
                        trvDictionary.Nodes.Add(tn);
                    }
                }
                else
                {
                    App.Msg("û���ҵ���ѯ�����");
                }

            }
            catch
            {

            }
            finally
            {
                btnSelect.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void trvDictionary_MouseDown(object sender, MouseEventArgs e)
        {
            trvDictionary.SelectedNode = trvDictionary.GetNodeAt(e.X, e.Y);
        }
        /// <summary>
        /// ɾ����Ϣ
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                if (App.Ask("��ȷ��Ҫɾ����"))
                {
                    App.ExecuteSQL("delete from T_MEDICAL_MARK where ID='" + selectDirectionary.ID + "'");
                    trvDictionary.Nodes.Remove(trvDictionary.SelectedNode);
                }
            }
            else
            {
                App.Msg("����ѡ��Ҫɾ���Ľڵ㣡");
            }
        }

        private void tbxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxCode.Focus();
            }
        }

        private void tbxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxCheckReq.Focus();
            }
        }

        private void tbxCheckReq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxDeductStand.Focus();
            }
        }

        private void tbxDeductStand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbxDeductScore.Focus();
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxPinyin.Text = App.getSpell(App.ToDBC(this.tbxName.Text.Trim()));
        }

        private void btnVetoProjects_Click(object sender, EventArgs e)
        {
            frmMarkInfo frmMark = new frmMarkInfo(this.cmbTypes.SelectedValue.ToString(), vetoProjects, isSave);
            DialogResult dlg = frmMark.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                this.vetoProjects = listToString(frmMark.List);
            }
        }

        /// <summary>
        /// ��listת��Ϊһ���ö��ŷָ����ַ��� 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string listToString(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            if (list != null && list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (i < list.Count - 1)
                    {
                        sb.Append(list[i] + ",");
                    }
                    else
                    {
                        sb.Append(list[i]);
                    }
                }
            }
            return sb.ToString();
        }

        private void rbnSingVetoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbnSingVetoYes.Checked)
            {
                this.panel5.Enabled = true;
                this.btnVetoProjects.Enabled = true;
            }
            else
            {
                this.panel5.Enabled = false;
                this.btnVetoProjects.Enabled = false;
            }
        }

        private void btnObjectiveMark_Click(object sender, EventArgs e)
        {
            frmGradeObjectiveInfo fg = new frmGradeObjectiveInfo();
            if (fg.ShowDialog() == DialogResult.OK)
            {
                if (strRole_tyep != "H")
                {
                    this.tbxCode.Text = fg.Ids;
                    this.tbxName.Text = fg.Names;
                    this.tbxDeductScore.Text = fg.KouFenZhi;//�۷�ֵ����
                }
                else//����ʹ��
                {
                    this.tbxName.Text = fg.Names + "," + fg.KouFenZhi;
                    this.tbxCode.Text = fg.Ids;
                }

            }
        }

        private void rbnObjective_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbnSubjective.Checked)
            {
                this.btnObjectiveMark.Enabled = false;
            }
            else
            {
                this.btnObjectiveMark.Enabled = true;
            }

        }
        /// <summary>
        /// ����������Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewPFProgram_Click(object sender, EventArgs e)
        {
            try
            {
                frmNewPFProgram frm = new frmNewPFProgram();
                frm.ShowDialog();
                this.BangType();
                this.Bangding();

            }
            catch
            {

            }
        }

        private void cmbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isMark != 1)
            {
                btnSelect_Click(null, null);
            }
        }
        /// <summary>
        /// �����ӽڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �����ӽڵ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvDictionary.SelectedNode = null;
            selectDirectionary = null;
            isSave = true;
            Edit(isSave);
        }
        /// <summary>
        /// �޸��ӽڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �޸��ӽڵ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                isSave = false;
                Edit(isSave);
            }
            else
            {
                App.Msg("����ѡ��Ҫ�޸ĵĽڵ㣡");
            }
        }
        /// <summary>
        /// ֻ���Ƿ�����ѡ���ˡ��ǡ�����ѡ��������������Ŀ����ť�����ã����򲻿���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnSingVetoYes_Click(object sender, EventArgs e)
        {
            try
            {
                btnVetoProjects.Visible = true;
            }
            catch
            {

            }
        }
        /// <summary>
        /// �Ƿ��ܶԿ͹����͹������ķ��������޸ģ�����ֻ����Ŀ��ѡ���ˡ��͹����֡�ʱ���á�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbnObjective_Click(object sender, EventArgs e)
        {
            rbnModifyY.Enabled = true;
            rbnModifyN.Enabled = true;
        }

        private void rbnSubjective_Click(object sender, EventArgs e)
        {
            rbnModifyY.Enabled = false;
            rbnModifyN.Enabled = false;
        }


    }
}