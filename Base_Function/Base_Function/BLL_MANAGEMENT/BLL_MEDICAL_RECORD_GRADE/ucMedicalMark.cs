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
    /// 病案评分参数设置控件
    /// </summary>
    public partial class ucMedicalMark : UserControl
    {
        bool isSave = false;                       //用于存放当前的操作状态 true为添加操作 false为修改操作

        int isMark = 0;

        string strRole_tyep = "";
        private string mark = "Y";                 //有效标志
        private string isSubjective = "Y";         //是否主观评分
        private string isSingVeto = "N";           //是否单项否决
        private string singVetoLev = "";           //单项否决级别
        private string isModifyManual = "Y";       //是否手动修改

        private string vetoProjects = "";          //否决项目ID 逗号分隔


        private string ID = "";                    //数据字典维护ID
        Class_Mark selectDirectionary = null;

        public ucMedicalMark()
        {
            InitializeComponent();
        }

        private void frmDictionary_Load(object sender, EventArgs e)
        {
            strRole_tyep = App.UserAccount.CurrentSelectRole.Role_type.ToString();//获取当前登陆角色类型
            if (strRole_tyep == "H")//护理部隐藏一些相对应不适用的字段和文本框
            {
                label2.Visible = false;
                tbxPinyin.Visible = false;
                label10.Text = "   编号:";
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

        //绑定类型
        private void Bangding()
        {
            if (strRole_tyep == "H")//目前认为当前用户角色为护理部角色类型
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
        /// 绑定查询的类型
        /// </summary>
        private void BangType()
        {
            if (strRole_tyep == "H")//目前认为当前用户角色为护理部角色类型
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
        /// 刷新
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
        /// 编辑状态
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
        /// 表格刷新
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
        /// 实例化查询结果
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

                    if (temp.SingVetoLev == "乙")
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
        /// 添加
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
        /// 修改
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
                App.Msg("请先选择要修改的节点！");
            }
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(this.tbxName.Text.Trim()))
                {
                    App.Msg("项目名称不能为空！");
                    this.tbxName.Focus();
                    return;
                }
                //if (string.IsNullOrEmpty(this.tbxCode.Text.Trim()))
                //{
                //    App.Msg("项目编码不能为空！");
                //    this.tbxCode.Focus();
                //    return;
                //}
                //if (string.IsNullOrEmpty(this.tbxCheckReq.Text.Trim()))
                //{
                //    App.Msg("检查要求不能为空！");
                //    this.tbxCheckReq.Focus();
                //    return;
                //}
                if (string.IsNullOrEmpty(this.tbxDeductStand.Text.Trim()))
                {
                    App.Msg("扣分标准不能为空！");
                    this.tbxDeductStand.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(this.tbxDeductScore.Text.Trim()))
                {
                    App.Msg("单项扣分值不能为空！");
                    this.tbxDeductScore.Focus();
                    return;
                }

                if (this.cmbType.Text.Trim() == "")
                {
                    App.Msg("类型不能为空！");
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

                    if (this.rbnB.Checked) { this.singVetoLev = "乙"; }
                    else { this.singVetoLev = "丙"; }

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
                        App.Msg("操作成功");
                        btnCancel_Click(sender, e);
                        btnSelect_Click(sender, e);
                    }

            }
            catch (Exception ex)
            {
                App.Msg("添加失败，原因：" + ex.ToString() + "");

            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            refurbish();
        }
        /// <summary>
        /// 把数据显示到表格
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
        /// 查询
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
                    App.Msg("该查询条件存在SQL注入的危险！");
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
                    App.Msg("没有找到查询结果！");
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
        /// 删除信息
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                if (App.Ask("你确定要删除吗？"))
                {
                    App.ExecuteSQL("delete from T_MEDICAL_MARK where ID='" + selectDirectionary.ID + "'");
                    trvDictionary.Nodes.Remove(trvDictionary.SelectedNode);
                }
            }
            else
            {
                App.Msg("请先选择要删除的节点！");
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
        /// 把list转换为一个用逗号分隔的字符串 
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
                    this.tbxDeductScore.Text = fg.KouFenZhi;//扣分值传递
                }
                else//护理部使用
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
        /// 新增评分项目
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
        /// 新增子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 新增子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trvDictionary.SelectedNode = null;
            selectDirectionary = null;
            isSave = true;
            Edit(isSave);
        }
        /// <summary>
        /// 修改子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                isSave = false;
                Edit(isSave);
            }
            else
            {
                App.Msg("请先选择要修改的节点！");
            }
        }
        /// <summary>
        /// 只有是否单项否决选择了“是”，“选择否决其他评分项目”按钮方可用，否则不可用
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
        /// 是否能对客观类型规则所的分数进行修改，该项只有项目处选择了“客观评分”时启用。
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