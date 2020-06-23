using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using Base_Function.BASE_COMMON;
using Bifrost;
using DevComponents.DotNetBar;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE
{
    public partial class ucMedicalMark_NEW_Blues : UserControl
    {
        Class_Mark selectDirectionary = null;
        public ucMedicalMark_NEW_Blues()
        {
            InitializeComponent();
        }

        private void ucMedicalMark_NEW_Blues_Load(object sender, EventArgs e)
        {
            GetAllBookTree(advAllDoc);
            setAllChechBox(advAllDoc.Nodes);
            Dtarow();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);//选择行
            //ucGridviewX1.fg.AllowUserToAddRows = false;
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            advAllDoc.ExpandAll();//展开所有文书节点
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

            DataTable TableSort = DataInit.GetTextSortSet(DataInit.SortTypeId);//获取该类型所有的排序信息
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

        /// <summary>
        /// 设置CheckBox框
        /// </summary>
        /// <param name="nodes"></param>
        private void setAllChechBox(NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].CheckBoxVisible = true;//设置复选框
                if (nodes[i].Nodes.Count > 0)
                {
                    setAllChechBox(nodes[i].Nodes);
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
        //新建
        private void tbtnNewRule_Click(object sender, EventArgs e)
        {
            frmMedicalMarkDetial fc = new frmMedicalMarkDetial("");
            fc.ShowDialog();
            if (fc.DialogResult == DialogResult.OK)
            {
                Dtarow();
            }
        }
        //修改
        private void tbtnChange_Click(object sender, EventArgs e)
        {
            int index = ucGridviewX1.fg.CurrentRow.Index;
            if (ucGridviewX1.fg.RowCount > 0)
            {
                string id = ucGridviewX1.fg["id", index].Value.ToString();
                frmMedicalMarkDetial fc = new frmMedicalMarkDetial(id);
                fc.ShowDialog();
                if (fc.DialogResult == DialogResult.OK)
                {
                    Dtarow();
                    ucGridviewX1.fg.Rows[index].Selected = true;
                    ucGridviewX1.fg.FirstDisplayedScrollingRowIndex = index;
                }
            }
            else
            {
                App.Msg("请选中要修改的规则！");
            }
        }
        //删除
        private void tbtnDel_Click(object sender, EventArgs e)
        {
            int index = ucGridviewX1.fg.CurrentRow.Index;
            if (ucGridviewX1.fg.RowCount > 0)
            {
                try
                {
                    if (App.Ask("确认要删除“" + ucGridviewX1.fg["规则名称", index].Value.ToString() + "”吗？"))
                    {
                        string id = ucGridviewX1.fg["id", index].Value.ToString();
                        string sqlDelData = "delete T_MEDICAL_MARK where id='" + id + "'";
                        string sqlDelText = "delete T_MEDICAL_MARK_TEXT where mark_id='" + id + "'";

                        List<string> sqls = new List<string>();
                        sqls.Add(sqlDelData);
                        sqls.Add(sqlDelText);
                        App.ExecuteBatch(sqls.ToArray());
                        App.Msg("删除成功！");
                        Dtarow();
                    }
                }
                catch
                {
                    App.Msg("删除失败！");
                }
            }
            else
            {
                App.Msg("请选中要删除的规则！");
            }
        }
        /// <summary>
        /// 显示文书对应规则
        /// </summary>
        /// <param name="str">文书类型</param>
        private void Dtarow()
        {
            try
            {
                string sql = "select tt.id,tt.code as 编码,tt.name as 规则名称,tt.check_req as 检查要求,tt.deduct_stand as 扣分标准," +
                                "tt.deduct_score as 单项扣分值, (case tt.issingveto  when 'Y' then '是' else '否' end)  as 单项否决,tt.singveto_lev as 单项否决级别," +
                                "(case tt.ismodify_manual  when 'Y' then '是' else '否' end) as 手动分值,(case tt.valid_state  when 'Y' then '有效' else '无效' end) as 有效标志,tt.spell_code as 拼音码,(case tt.type when 'Y' then '主观' else '客观' end) 类型 " +
                                "from T_MEDICAL_MARK tt ";

                ucGridviewX1.DataBd(sql, "id", false, "", "");
                ucGridviewX1.fg.Columns[0].Visible = false;
            }
            catch { }
        }
        string id = "";
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            int index = ucGridviewX1.fg.CurrentRow.Index;
            if (ucGridviewX1.fg.RowCount > 0)
            {
                ManyItems(advAllDoc.Nodes);
                id = ucGridviewX1.fg["id", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                selectDirectionary = GetSelectDirectionary(id);
                iniEditData(selectDirectionary);
            }
        }
        /// <summary>
        /// 项目过多
        /// 循环递归
        /// 1.父节点->有勾选项->递归（子节点项）->满足->继续
        /// </summary>
        /// <param name="nodes"></param>
        private void ManyItems(NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                nodes[i].Checked = false;
                if (nodes[i].Nodes.Count > 0)
                {
                    ManyItems(nodes[i].Nodes);
                }
            }
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
            /*
             * 树节点的绑定
             */
            DataSet ds = App.GetDataSet("select bb.text_id from T_MEDICAL_MARK_TEXT bb where bb.mark_id=" + temp.ID + "");
            //CheckCurrentNode(ds, advAllDoc.Nodes);
        }
        /// <summary>
        ///刷新当前所有与规则有关的文书节点
        /// </summary>
        /// <param name="ds"></param>
        private void CheckCurrentNode(DataSet ds, NodeCollection nodes)
        {
            //匹配符合条件的文书规则
            for (int i = 0; i < nodes.Count; i++)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    if (nodes[i].Nodes.Count > 0)//递归-满足-继续
                    {
                        CheckCurrentNode(ds, nodes[i].Nodes);
                    }
                    if (nodes[i].Name == ds.Tables[0].Rows[j]["text_id"].ToString())
                    {
                        nodes[i].Checked = true;
                    }
                }
            }
        }
    }
}
