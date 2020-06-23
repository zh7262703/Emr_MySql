using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base_Function.BASE_COMMON;
using DevComponents.AdvTree;
using Bifrost;
using Base_Function.BLL_MEDICAL_RECORD_GRADE;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// 规则编辑
    /// </summary>
    public partial class frmMedicalMarkDetial : DevComponents.DotNetBar.Office2007Form
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


        private string ID = "";                    //当前规则的 ID
        Class_Mark selectDirectionary = null;      //当前规则对象
        List<string> sqls = new List<string>();    //存储保存SQL语句

        public frmMedicalMarkDetial(string mark_id)
        {
            InitializeComponent();

            ID = mark_id;
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


            btnSave.Enabled = true;
            groupBox2.Enabled = true;
            this.tbxName.Focus();
        }

        private void frmMedicalMarkDetial_Load(object sender, EventArgs e)
        {
            GetAllBookTree(advAllDoc);

            setAllChechBox(advAllDoc.Nodes);

            if (ID != "")
            {
                //修改操作
                selectDirectionary = GetSelectDirectionary(ID);
                iniEditData(selectDirectionary);

                isSave = false;
            }
            else
            {
                isSave = true;
            }
            Edit(isSave);         
        }


        /// <summary>
        /// 实例化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Mark GetSelectDirectionary(string markid)
        {
            string Sql = "select * from  T_MEDICAL_MARK where ID = '" + markid + "' order by ID desc";
            DataSet tempds = App.GetDataSet(Sql);
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Mark Directionary = new Class_Mark();
                    Directionary.ID = tempds.Tables[0].Rows[0]["ID"].ToString();
                    Directionary.Code = tempds.Tables[0].Rows[0]["CODE"].ToString();
                    Directionary.TypeId = tempds.Tables[0].Rows[0]["TYPE_ID"].ToString();
                    Directionary.Name = tempds.Tables[0].Rows[0]["NAME"].ToString();
                    Directionary.CheckReq = tempds.Tables[0].Rows[0]["CHECK_REQ"].ToString();
                    Directionary.DeductStand = tempds.Tables[0].Rows[0]["DEDUCT_STAND"].ToString();
                    Directionary.DeductScore = tempds.Tables[0].Rows[0]["DEDUCT_SCORE"].ToString();
                    Directionary.IsSingVeto = tempds.Tables[0].Rows[0]["ISSINGVETO"].ToString();
                    Directionary.SingVetoLev = tempds.Tables[0].Rows[0]["SINGVETO_LEV"].ToString();
                    Directionary.IsModifyManual = tempds.Tables[0].Rows[0]["ISMODIFY_MANUAL"].ToString();
                    Directionary.ValidState = tempds.Tables[0].Rows[0]["VALID_STATE"].ToString();
                    Directionary.SpellCode = tempds.Tables[0].Rows[0]["SPELL_CODE"].ToString();
                    Directionary.Type = tempds.Tables[0].Rows[0]["TYPE"].ToString();
                    Directionary.VetoProjects = tempds.Tables[0].Rows[0]["VETO_PROJECTS"].ToString();
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
                //this.cmbType.SelectedValue = temp.TypeId;
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

                /*
                 * 树节点的绑定
                 */

                DataSet ds = App.GetDataSet("select bb.text_id from T_MEDICAL_MARK_TEXT bb where bb.mark_id=" + temp.ID + "");
                CheckCurrentNode(ds, advAllDoc.Nodes);


            }
        }

        /// <summary>
        ///刷新当前所有与规则有关的文书节点
        /// </summary>
        /// <param name="ds"></param>
        private void CheckCurrentNode(DataSet ds, NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (nodes[i].Name == ds.Tables[0].Rows[j]["text_id"].ToString())
                    {
                        nodes[i].Checked = true;
                    }
                    //else
                    //{
                    //    nodes[i].Checked = false;
                    //}
                    if (nodes[i].Nodes.Count > 0)
                    {
                        CheckCurrentNode(ds, nodes[i].Nodes);
                    }
                }
            }
        }


        /// <summary>
        /// 设置CheckBox框
        /// </summary>
        /// <param name="nodes"></param>
        private void setAllChechBox(NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].CheckBoxVisible = true;
                if (nodes[i].Nodes.Count > 0)
                {
                    setAllChechBox(nodes[i].Nodes);
                }
            }
        }

        /// <summary>
        /// 设置当前节点子节点的选择状态
        /// </summary>
        private void SetCheckState(Node node)
        {
            if (node.Nodes.Count > 0)
            {
                if (node.Checked)
                {
                    for (int i = 0; i < node.Nodes.Count; i++)
                    {
                        node.Nodes[i].Checked = true;
                        SetCheckState(node.Nodes[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < node.Nodes.Count; i++)
                    {
                        node.Nodes[i].Checked = false;
                        SetCheckState(node.Nodes[i]);
                    }
                }
            }
        }

        /// <summary>
        /// 设置当前节点子节点的选择状态
        /// </summary>
        private void SetAllCheckState(NodeCollection nodes, bool checkState)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Checked = checkState;
                if (nodes[i].Nodes.Count > 0)
                {
                    SetAllCheckState(nodes[i].Nodes, checkState);
                }
            }
        }


        /// <summary>
        ///  显示所有文书类型
        /// </summary>
        /// <param name="trvBook"></param>
        private void GetAllBookTree(AdvTree trvBook)
        {

            trvBook.Nodes.Clear();
            //查出所有文书
            string SQl = "select * from T_TEXT where enable_flag='Y' order by shownum asc";

            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = DataInit.GetSelectClassDs(ds);

            DataTable TableSort = DataInit.GetTextSortSet(DataInit.SortTypeId);//App.GetDataSet(sqlSort).Tables[0]; //获取该类型所有的排序信息
            DataRow[] toptempRows = TableSort.Select("parent_id=0"); //获取顶级节点
            DataRow[] topRows = DataInit.ReSort(toptempRows);               //顶级节点排序

            ////得到文书的类型       
            if (Directionarys != null)
            {
                if (topRows.Length > 0)
                {
                    //有排序
                    for (int k = 0; k < topRows.Length; k++)
                    {
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            if (topRows[k]["text_id"].ToString() == Directionarys[i].Id.ToString())
                            {
                                Node tn = new Node();
                                tn.Tag = Directionarys[i];
                                tn.Text = Directionarys[i].Textname;
                                tn.Name = Directionarys[i].Id.ToString();
                                //插入顶级节点
                                if (Directionarys[i].Parentid == 0)
                                {
                                    tn.Image = global::Base_Function.Resource.住院记录;
                                    trvBook.Nodes.Add(tn);
                                    DataInit.SetTreeView(Directionarys, tn, TableSort);   //插入文书的子类文书。                                
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        Node tn = new Node();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        //插入顶级节点
                        if (Directionarys[i].Parentid == 0)
                        {
                            tn.Image = global::Base_Function.Resource.住院记录;
                            trvBook.Nodes.Add(tn);
                            DataInit.SetTreeView(Directionarys, tn, TableSort);   //插入文书的子类文书。 
                        }
                    }
                }
            }
        }

        private void advAllDoc_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (advAllDoc.SelectedNode != null)
            {
                //子节点全选中父节点自动选中，子节点取消父节点自动取消选中
                if (advAllDoc.SelectedNode.Nodes.Count == 0)
                {
                    Node parentNode = advAllDoc.SelectedNode.Parent;
                    if (parentNode == null)
                    {
                        return;
                    }
                    if (!advAllDoc.SelectedNode.Checked)
                    {
                        parentNode.Checked = false;
                    }
                    else
                    {
                        bool flag = false;
                        for (int i = 0; i < parentNode.Nodes.Count; i++)
                        {
                            if (parentNode.Nodes[i].Checked == false)
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!parentNode.Checked && !flag)
                        {
                            parentNode.Checked = true;
                        }
                    }
                }
                else
                {
                    SetCheckState(advAllDoc.SelectedNode);
                }
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            SetAllCheckState(advAllDoc.Nodes, chkAll.Checked);
        }

        private void rbnSubjective_CheckedChanged(object sender, EventArgs e)
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

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                sqls.Clear();
                if (isSave)
                {
                    ID = App.ReadSqlVal("select T_MEDICAL_MARK_ID.NEXTVAL as ID from dual", 0, "ID");

                    sqls.Add("insert into T_MEDICAL_MARK(id,code,name,check_req,deduct_stand,deduct_score,issingveto,singveto_lev,ismodify_manual,valid_state,spell_code,type,veto_projects)values('" + ID + "','" + this.tbxCode.Text + "'" +
                          ",'" + this.tbxName.Text + "','" + this.tbxCheckReq.Text + "','" + this.tbxDeductStand.Text + "','" + this.tbxDeductScore.Text + "','" + isSingVeto + "','" + singVetoLev + "','"
                          + isModifyManual + "','" + mark + "','" + this.tbxPinyin.Text + "','" + isSubjective + "','" + vetoProjects + "')");
                }
                else
                {
                    ID = selectDirectionary.ID;

                    sqls.Add("update T_MEDICAL_MARK set code = '" + this.tbxCode.Text + "',name = '" + this.tbxName.Text + "',check_req = '" + this.tbxCheckReq.Text + "',deduct_stand = '"
                        + this.tbxDeductStand.Text + "',deduct_score = '" + this.tbxDeductScore.Text + "',issingveto = '" + isSingVeto + "',singveto_lev = '" + singVetoLev + "',ismodify_manual = '" + isModifyManual + "',valid_state = '" + mark + "',spell_code = '" + this.tbxPinyin.Text + "',type = '" + isSubjective + "',veto_projects = '" + vetoProjects + "' where ID= '" + ID + "'");

                    sqls.Add("delete T_MEDICAL_MARK_TEXT where mark_id='" + selectDirectionary.ID + "'");

                    selectDirectionary.Code = this.tbxCode.Text;
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

                }
                int iCount = sqls.Count;
                treCheck(advAllDoc.Nodes);
                //判断是否选择了科室
                if (sqls.Count == iCount)
                {
                    App.Msg("没有选择科室！");
                    return;
                }
                if (sqls.Count > 0)
                {
                    App.ExecuteBatch(sqls.ToArray());
                    App.Msg("操作成功");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                App.Msg("添加失败，原因：" + ex.ToString() + "");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// 根据选定科室添加科室规则关系sql语句
        /// </summary>
        /// <param name="nodes"></param>
        private void treCheck(NodeCollection nodes)
        {
            foreach (Node n in nodes)
            {
                if (n.Nodes.Count > 0)
                {
                    treCheck(n.Nodes);
                }
                else if (n.Checked == true)
                {
                    sqls.Add("insert into T_MEDICAL_MARK_TEXT(mark_id,text_id) values('" + ID + "','" + n.Name + "')");
                }
            }
        }

        private void btnVetoProjects_Click(object sender, EventArgs e)
        {
            frmMarkInfo frmMark = new frmMarkInfo("", vetoProjects, isSave);
            frmMark.TopMost = true;
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

        /// <summary>
        /// 自动生成项目名称拼音码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            tbxPinyin.Text = App.getSpell(tbxName.Text.Trim()).ToUpper();
        }

    }
}
