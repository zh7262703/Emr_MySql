using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using Base_Function.BASE_DATA;

namespace Base_Function.BLL_FOLLOW
{
    public partial class ucFollowWrite_Type : UserControl
    {
        private bool isSave;                         //记录当前操作为保存或修改 true保存 false修改
        public static Class_Follow_Text Fathernode = null;  //用于寄存父节点的实例
        private Class_Follow_Text selectClasstext = null;   //用于寄存当前选中的节点实例
        public static string fahterId = "0";         //给父节点默认为0
        public static string fahterName = "0";       //父节点名称
        private string textname;                     //当前选中的文书类型名称       
        public static string texttype = "";          //父节点文书类型
        private string mark = "Y";                   //有效标志


        public static bool isShowNumChange = false;  //是否排序发生变化

        public ucFollowWrite_Type()
        {
            InitializeComponent();

        }

         private void followWrite_Type_Load(object sender, EventArgs e)
        {
            RefleshFrm();
            SectionLoad();
            btnSelect_Click(sender, e);
        }
        /// <summary>
        /// 初始化控件，使其处于默认状态
        /// </summary>
        private void RefleshFrm()
        {
            txtFather.Enabled = false;
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtOtherTextName.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnSelectTrv.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
            panel4.Enabled = false;
            panel5.Enabled = false;
            isSave = false;
            clbSection.Enabled = false;
        }
        /// <summary>
        /// 科室列表加载
        /// </summary>
        private void SectionLoad()
        {

            string sql_Section = "select sid,section_name from t_sectioninfo where enable_flag='Y'  and is_follow_visit='Y'";
            DataSet ds_section = App.GetDataSet(sql_Section);
            if (ds_section != null)
            {
                DataTable dt = ds_section.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Class_Sections section = new Class_Sections();
                    section.Sid = Convert.ToInt32(row["sid"]);
                    section.Section_Name = row["section_name"].ToString();
                    clbSection.Items.Add(section.Sid + ":" + section.Section_Name);
                }
            }
        }

        /// <summary>
        /// 实例Class_Text化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Follow_Text[] GetSelectClassDs(DataSet tempds)
        {

            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Follow_Text[] class_text = new Class_Follow_Text[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        class_text[i] = new Class_Follow_Text();
                        class_text[i].Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        if (tempds.Tables[0].Rows[i]["PARENTID"] != null)
                        {
                            if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0" && tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "")
                            {
                                class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                            }
                        }
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        textname = class_text[i].Textname;
                        class_text[i].Iscommon = tempds.Tables[0].Rows[i]["Iscommon"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                        class_text[i].Issimpleinstance = tempds.Tables[0].Rows[i]["ISSIMPLEINSTANCE"].ToString();
                        class_text[i].Enable = tempds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                        class_text[i].Shownum = tempds.Tables[0].Rows[i]["shownum"].ToString();
                        class_text[i].Ishighersign = tempds.Tables[0].Rows[i]["ishighersign"].ToString();
                        class_text[i].Ishavetime = tempds.Tables[0].Rows[i]["ishavetime"].ToString();
                        class_text[i].Formname = tempds.Tables[0].Rows[i]["formname"].ToString();
                        class_text[i].Other_textname = tempds.Tables[0].Rows[i]["OTHER_TEXTNAME"].ToString();
                        if (tempds.Tables[0].Rows[i]["RIGHT_RANGE"].ToString() == "")
                        {
                            class_text[i].Right_range = "D";
                        }
                        else
                        {
                            class_text[i].Right_range = tempds.Tables[0].Rows[i]["RIGHT_RANGE"].ToString();
                        }
                        if (tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString() == "")
                        {
                            class_text[i].Isneedsign = "Y";
                        }
                        else
                        {
                            class_text[i].Isneedsign = tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString();
                        }
                        if (tempds.Tables[0].Rows[i]["ISNEWPAGE"].ToString() == "")
                        {
                            class_text[i].Isnewpage = "N";
                        }
                        else
                        {
                            class_text[i].Isnewpage = tempds.Tables[0].Rows[i]["ISNEWPAGE"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISSUBMITSIGN"].ToString() == "")
                        {
                            class_text[i].Issubmitsign = "N";
                        }
                        else
                        {
                            class_text[i].Issubmitsign = tempds.Tables[0].Rows[i]["ISSUBMITSIGN"].ToString();
                        }

                    }
                    return class_text;
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
        /// <summary>
        /// 根据ID获取节点
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private Class_Follow_Text GetNodeById(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_FOLLOW_TEXT  where ID=" + id + "");
            if (ds != null)
            {
                Class_Follow_Text[] temps = GetSelectClassDs(ds);
                if (temps != null)
                {
                    if (temps.Length > 0)
                    {
                        return temps[0];
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
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 表格刷新
        /// </summary>
        private void refurbish()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            Fathernode = null;
            txtFather.Text = "";
            txtFather.Enabled = false;
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtOtherTextName.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnSelectTrv.Enabled = false;
            clbSection.Enabled = false;
            btnDelFater.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
            panel4.Enabled = false;
            panel5.Enabled = false;
            trvDictionary.Enabled = true;

        }
        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtNumber.Text = "";
                txtName.Text = "";
                txtFather.Text = "";
                if (Fathernode != null)
                {
                    txtFather.Text = Fathernode.Textname;
                    txtNumber.Text = "";
                    txtName.Text = "";
                }
                txtOtherTextName.Text = "";
                ckBoxDoc.Checked = true;
                ckBoxNur.Checked = false;
                ckBoxSec.Checked = false;

            }
            txtFather.Enabled = true;
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            txtOtherTextName.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnSelectTrv.Enabled = true;
            btnDelFater.Enabled = true;
            clbSection.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
            panel4.Enabled = true;
            panel5.Enabled = true;

            txtNumber.Focus();
        }

        /// <summary>
        /// 对文书进行分类设置
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="current">当前文书节点</param>
        private void SetTreeView(Class_Follow_Text[] Directionarys, TreeNode current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Follow_Text cunrrentDir = (Class_Follow_Text)current.Tag;
                if (Directionarys[i].Parentid == cunrrentDir.Id)
                {

                    TreeNode tn = new TreeNode();
                    if (Directionarys[i].Enable == "Y")
                    {
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                    }
                    if (Directionarys[i].Enable == "N")
                    {
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.ForeColor = Color.Gray;
                    }
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }

            }
        }

        /// <summary>
        /// 查找,初始化文书类型树
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
                string SQl = "select * from T_FOLLOW_TEXT order by shownum asc";
                DataSet ds = App.GetDataSet(SQl);
                Class_Follow_Text[] Directionarys = GetSelectClassDs(ds);
                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        TreeNode tn = new TreeNode();
                        //无效节点，灰色显示
                        if (Directionarys[i].Enable == "N")
                        {

                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;
                            tn.ForeColor = Color.Gray;
                        }
                        if (Directionarys[i].Enable == "Y")
                        {
                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;

                        }
                        //插入顶级节点
                        if (Directionarys[i].Parentid == 0)
                        {
                            trvDictionary.Nodes.Add(tn);
                            SetTreeView(Directionarys, tn);
                        }
                    }
                    
                }
                else
                {
                    App.Msg("没有找到查询结果！");
                }
                if (txtConName.Text.Trim() != "")
                {
                    string select_SQl = "select distinct parentid from T_FOLLOW_TEXT where TEXTNAME like '%" + txtConName.Text.Trim() + "%'  ";
                    DataSet ds_result = App.GetDataSet(select_SQl);
                    for (int i = 0; i < ds_result.Tables[0].Rows.Count; i++)
                    {
                        foreach (TreeNode node in trvDictionary.Nodes)
                        {
                            Class_Follow_Text text = (Class_Follow_Text)node.Tag;
                            if (ds_result.Tables[0].Rows[i][0].ToString() == text.Id.ToString())
                                node.Expand();
                            else
                                TraversTree(node, ds_result.Tables[0].Rows[i][0].ToString());
                            
                        }
                    }
                }
                else
                    trvDictionary.ExpandAll();
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
        /// <summary>
        /// 遍历树找到符合条件节点展开其父节点
        /// </summary>
        /// <param name="tn"></param>
        /// <param name="param"></param>
        public void TraversTree(TreeNode tn,string param)
        {
            if (tn.Nodes != null)
            {
                foreach (TreeNode node in tn.Nodes)
                {
                    Class_Follow_Text text = (Class_Follow_Text)node.Tag;
                    if (text.Id.ToString() == param)
                    {
                        ExpandResultNode(node);
                    }
                    TraversTree(node,param);
                }

            }

        }
        public void ExpandResultNode(TreeNode tn)
        {
            if (tn.Parent != null)
            {
                TreeNode nexttn = tn.Parent;
                ExpandResultNode(nexttn);
                
            }
            tn.Expand();
        }
        /// <summary>
        /// 判断是否出现重名TEXTNAME
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string name)
        {
            string sql = "select * from T_FOLLOW_TEXT where textname='"+name+"' ";
            DataSet ds = App.GetDataSet(sql);
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
        /// 判断是否出现重名TEXTCODE
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExisitCode(string id)
        {

            string sql = "select * from T_FOLLOW_TEXT where textcode='"+id+"' ";
            DataSet ds = App.GetDataSet(sql);
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
        /// 添加
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            trvDictionary.SelectedNode = null;
            selectClasstext = null;
            isSave = true;
            trvDictionary.Enabled = false;
            Edit(isSave);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            iniEditData(selectClasstext);
            Edit(isSave);
        }
        /// <summary>
        /// 保存或修改操作
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList Sqls = new ArrayList();
            string sid = "";    //文书的所属科室,默认为属于所有科室
            for (int i = 0; i < clbSection.Items.Count; i++)
            {
                if (clbSection.GetItemText(clbSection.Items[i]) == "0:全院" && clbSection.GetItemChecked(i))  //如果全院被选中，则把文书SID直接设为0
                {
                    sid = "0";
                    break;
                }
                if (clbSection.GetItemChecked(i))
                {
                    string sectionId = clbSection.GetItemText(clbSection.Items[i]).Substring(0, clbSection.GetItemText(clbSection.Items[i]).IndexOf(":"));
                    if (sid == "")
                        sid = sectionId;
                    else
                        sid +="," +sectionId ;
                }
            }
            if (txtName.Text.Trim() == "")
            {
                App.Msg("文书名称必须填写！");
                txtName.Focus();
                return;
            }
            //有效标志
            if (rbtnVainmark.Checked == true)
            {
                mark = "N";
            }
            else
            {
                mark = "Y";
            }
            
            //是否启用编辑器
            string isEdit = "Y";
            if (rbtnEnditYes.Checked)
                isEdit = "N";
            else
                isEdit = "Y";
            //单例文书
            int isSingle = 0;
            if (rbtnSingle.Checked)
                isSingle = 0;
            else
                isSingle = 1;
            //文书用户类型,N：护士，D：医生，S：职能科室
            string writeType ="";
            if (ckBoxDoc.Checked||ckBoxNur.Checked||ckBoxSec.Checked)
            {
                if (ckBoxDoc.Checked && !ckBoxNur.Checked && !ckBoxSec.Checked)
                    writeType = "D";
                else if (!ckBoxDoc.Checked && ckBoxNur.Checked && !ckBoxSec.Checked)
                    writeType = "N";
                else if (!ckBoxDoc.Checked && !ckBoxNur.Checked && ckBoxSec.Checked)
                    writeType = "S";
                else if (ckBoxDoc.Checked && ckBoxNur.Checked && !ckBoxSec.Checked)
                    writeType = "D,N";
                else if (ckBoxDoc.Checked && !ckBoxNur.Checked && ckBoxSec.Checked)
                    writeType = "D,S";
                else if (!ckBoxDoc.Checked && ckBoxNur.Checked && ckBoxSec.Checked)
                    writeType = "N,S";
                else
                    writeType = "D,N,S";
            }
            if (Fathernode != null)
            {
                if (txtFather.Text.Trim() != "")
                {
                    fahterId = Fathernode.Id.ToString();
                    txtFather.Text = Fathernode.Textname;
                }
            }           
            try
            {
                if (selectClasstext != null)
                {
                    if (selectClasstext.Id.ToString() == fahterId)
                    {
                        App.MsgWaring("父节点不正确,请按del按钮，清空父节点重新选择！！");
                        return;
                    }
                }

                string Sql = "";
                if (isSave)
                {

                    if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("已经存在了相同文书的名称了！");
                        txtName.Focus();
                        return;
                    }
                    else if (isExisitCode(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("已经存在了相同文书的编号了！");
                        txtNumber.Focus();
                        return;
                    }
                    Sql = "insert into T_FOLLOW_TEXT(TEXTNAME,TEXTCODE,ISCOMMON,PARENTID,ENABLE_FLAG,SID,RIGHT_RANGE,OTHER_TEXTNAME,ISSIMPLEINSTANCE)values('"
                           + App.ToDBC(txtName.Text) + "','"
                           + App.ToDBC(txtNumber.Text) + "','"
                           +isEdit + "'," 
                           + fahterId + ",'"
                           + mark + "','"
                           + sid + "','"
                           + writeType + "','"
                           + txtOtherTextName.Text + "',"+isSingle+")";
                    btnAdd_Click(sender, e);
                }
                else
                {

                    Sql = "update T_FOLLOW_TEXT set  TEXTNAME='"
                        + txtName.Text + "',TEXTCODE='"
                        + txtNumber.Text + "',ISCOMMON='"
                        + isEdit+ "',PARENTID='"
                        + fahterId + "',ENABLE_FLAG='" + mark
                        + "',SID='" + sid
                        + "', RIGHT_RANGE='" + writeType +"',OTHER_TEXTNAME='" + txtOtherTextName.Text + "' ,issimpleinstance="+isSingle+" where id='" + selectClasstext.Id.ToString() + "'";
                }
                Sqls.Add(Sql);
                if (Sqls.Count > 0)
                {
                    string[] esqls = new string[Sqls.Count];
                    for (int i = 0; i < Sqls.Count; i++)
                    {
                        esqls[i] = Sqls[i].ToString();
                    }
                    if (App.ExecuteBatch(esqls) > 0)
                    {
                        SetItemChecked();
                        App.Msg("操作成功！");
                    }
                }

                btnCancel_Click(sender, e);

                if (isSave)
                {
                    //添加,刷新数据
                    btnSelect_Click(sender, e);
                }
                else
                {
                    //修改
                    ReIniNode(trvDictionary.SelectedNode);

                }


            }
            catch (Exception ex)
            {
                App.Msg("添加失败，原因：" + ex.ToString() + "");
            }
        }

        /// <summary>
        /// 更新相关节点
        /// </summary>
        /// <param name="SelNode"></param>
        private void ReIniNode(TreeNode SelNode)
        {
            if (SelNode != null)
            {
                Class_Follow_Text tempnow = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                string SQl = "select * from T_FOLLOW_TEXT where id=" + tempnow.Id + " ";
                DataSet ds = App.GetDataSet(SQl);
                Class_Follow_Text[] Directionarys = GetSelectClassDs(ds);
                SelNode.Tag = Directionarys[0];
                SelNode.Text = Directionarys[0].Textname;
                trvDictionary.SelectedNode = SelNode;

                selectClasstext = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                Fathernode = GetNodeById(selectClasstext.Parentid.ToString());
                iniEditData(selectClasstext);
                //texttypeselect = selectClasstext.Txxttype;
            }
        }
        /// <summary>
        /// 退出操作
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            refurbish();
        }
        /// <summary>
        /// 绑定节点信息 显示到编辑框
        ///  </summary>
        /// <param name="temp"></param>
        private void iniEditData(Class_Follow_Text temp)
        {
            if (temp != null)
            {
                if (Fathernode != null)
                {
                    txtFather.Text = Fathernode.Textname;
                }
                else
                {
                    txtFather.Text = "";
                }
                txtNumber.Text = temp.Textcode;
                txtName.Text = temp.Textname;
                if (temp.Iscommon == "Y")
                {
                    rbtnEditNo.Checked = true;
                    rbtnEnditYes.Checked = false;
                }
                else
                {
                    rbtnEditNo.Checked = false;
                    rbtnEnditYes.Checked = true;
                }
                mark = temp.Issimpleinstance;
                if (mark == "0")
                {
                    rbtnSingle.Checked = true;
                }
                else if (mark == "1")
                {
                    rbtnDouble.Checked = true;
                }
                switch (temp.Right_range.Trim())
                { 
                    case "D":
                        ckBoxDoc.Checked=true;
                        ckBoxNur.Checked = false;
                        ckBoxSec.Checked = false;
                        break;
                    case "N":
                        ckBoxNur.Checked=true;
                        ckBoxSec.Checked = false;
                        ckBoxDoc.Checked = false;
                        break;
                    case "S":
                        ckBoxSec.Checked=true;
                        ckBoxDoc.Checked = false;
                        ckBoxNur.Checked = false;
                        break;
                    case "D,N":
                        ckBoxDoc.Checked = true;
                        ckBoxNur.Checked = true;
                        ckBoxSec.Checked = false;
                        break;
                    case "D,S":
                        ckBoxDoc.Checked = true;
                        ckBoxSec.Checked = true;
                        ckBoxNur.Checked = false;
                        break;
                    case "N,S":
                        ckBoxNur.Checked=true;
                        ckBoxSec.Checked=true;
                        ckBoxDoc.Checked = false;
                        break;
                    default:
                        ckBoxSec.Checked=true;
                        ckBoxDoc.Checked=true;
                        ckBoxNur.Checked=true;
                        break;
                }

                txtOtherTextName.Text = temp.Other_textname;

            }
        }
        /// <summary>
        /// 选中节点后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDictionary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (groupPanel2.Enabled && !isSave)
            {
                if (trvDictionary.SelectedNode != null)
                {
                    if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                    {
                        Fathernode = null;
                        selectClasstext = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                        Fathernode = GetNodeById(selectClasstext.Parentid.ToString());
                        iniEditData(selectClasstext);
                        //texttypeselect = selectClasstext.Txxttype;
                    }
                }
            }
        }
        /// <summary>
        /// 点击节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void trvDictionary_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                {

                    selectClasstext = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                    iniEditData(selectClasstext);
                    SetItemChecked();
                }
            }
        }

        /// <summary>
        /// 设置科室列表选中项
        /// </summary>
        private void SetItemChecked()
        {
            if (selectClasstext == null)
            {
                return;
            }
            //取消所有选中的Item
            for (int i = 0; i < clbSection.Items.Count; i++)
            {
                clbSection.SetItemChecked(i, false);
            }
            int id = Convert.ToInt32(selectClasstext.Id);
            string sid = "";
            DataSet ds = App.GetDataSet("select sid from t_follow_text where id="+id+" ");
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    DataRow row = dt.Rows[0];
                    sid = row["sid"].ToString();
                }
            }
            string[] sections = sid.Split(',');
            //选中该文书的所属科室
            for (int i = 0; i < clbSection.Items.Count; i++)
            {
                if (sid == "0")
                {
                    clbSection.SetItemChecked(i, true);
                    break;
                }
                string sectionid = clbSection.GetItemText(clbSection.Items[i]).Substring(0, clbSection.GetItemText(clbSection.Items[i]).IndexOf(":"));

                for (int j = 0; j < sections.Length; j++)
                {
                    if (sections[j] != "")
                    {
                        if (sectionid == sections[j])
                        {
                            clbSection.SetItemChecked(i, true);
                        }
                    }
                }
                
            }
        }
        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void 添加子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                Fathernode = selectClasstext;
                btnAdd_Click(sender, e);
            }
            else
            {
                App.Msg("请选择需要添加子项的节点!");
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                {

                    if (trvDictionary.SelectedNode.Nodes.Count == 0)
                    {
                        if (App.Ask("确定要删除吗,用户所写的该类文书将会丢失？？"))
                        {
                            Class_Follow_Text temp = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                            try
                            {
                                if (App.ExecuteSQL("delete from T_FOLLOW_TEXT where ID=" + temp.Id + "")>0 || App.ExecuteSQL("delete from T_FOLLOW_TEMPPLATE where text_type=" + temp.Id + "")>0)
                                    trvDictionary.Nodes.Remove(trvDictionary.SelectedNode);
                                else
                                    App.Msg("删除未完成");
                            }
                            catch
                            {
                                App.MsgErr("删除失败");
                            }
                        }

                    }
                    else
                    {
                        App.Msg("该节点下已经存在子节点,要删除请把节点下存在的子节点清除才能删除");
                    }
                }
                btnSelect_Click(sender, e);
            }
            else
            {
                App.Ask("请选择需要删除的节点！");

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }

        }
        /// <summary>
        /// 选择父节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectTrv_Click(object sender, EventArgs e)
        {
            if (selectClasstext != null)
            {
                frmFollowWrite_Type_TrvSelect fm = new frmFollowWrite_Type_TrvSelect(selectClasstext.Id.ToString());
                fm.ShowDialog();
                if (fahterName != "")
                {
                    txtFather.Text = fahterName;
                    Fathernode = null;
                }
            }
            else
            {
                frmFollowWrite_Type_TrvSelect fm = new frmFollowWrite_Type_TrvSelect();
                fm.ShowDialog();
                if (fahterName != "")
                {
                    txtFather.Text = fahterName;
                    Fathernode = null;
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDictionary_MouseDown(object sender, MouseEventArgs e)
        {
            trvDictionary.SelectedNode = trvDictionary.GetNodeAt(e.X, e.Y);
        }
        private void trvDictionary_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        /// <summary>
        /// 上移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.PrevNode != null)
                {
                    Class_Follow_Text temp1 = (Class_Follow_Text)trvDictionary.SelectedNode.PrevNode.Tag;
                    Class_Follow_Text temp2 = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                    App.ExecuteSQL("update t_follow_text set shownum=" + temp1.Shownum + " where id='" + temp2.Id.ToString() + "' and idnum<>'" + temp1.Shownum + "'");
                    App.ExecuteSQL("update t_follow_text set shownum=" + temp2.Shownum + " where id='" + temp1.Id.ToString() + "' and idnum<>'" + temp1.Shownum + "'");
                    App.TrvNodeMovUp(trvDictionary.SelectedNode, trvDictionary);
                }

            }
        }

        /// <summary>
        /// 下移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.TrvNodeMovDown(trvDictionary.SelectedNode, trvDictionary);
            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.NextNode != null)
                {
                    Class_Follow_Text temp1 = (Class_Follow_Text)trvDictionary.SelectedNode.NextNode.Tag;
                    Class_Follow_Text temp2 = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                    App.ExecuteSQL("update t_follow_text set shownum=" + temp1.Shownum + " where id='" + temp2.Id.ToString() + "' and idnum<>'" + temp1.Shownum + "'");
                    App.ExecuteSQL("update t_follow_text set shownum=" + temp2.Shownum + " where id='" + temp1.Id.ToString() + "' and idnum<>'" + temp1.Shownum + "'");
                }
            }
        }

        /// <summary>
        /// 文书排序设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 文书排序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                Class_Follow_Text temp1 = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                frmFollowWrite_Type_Order fr = new frmFollowWrite_Type_Order(temp1.Parentid.ToString());
                App.FormStytleSet(fr, false);
                fr.ShowDialog();

                //排序发生变化
                if (ucFollowWrite_Type.isShowNumChange)
                {
                    btnSelect_Click(sender, e);
                }
            }
            else
            {
                App.MsgWaring("请选择要排序的文书！");
            }
        }

        /// <summary>
        /// 删除父节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelFater_Click(object sender, EventArgs e)
        {
            txtFather.Text = "";
            fahterId = "0";
            fahterName = "";
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            RefleshFrm();
            trvDictionary.Enabled = true;
        }

        private void 无效ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.Tag != null)
                {
                    if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                    {
                        Class_Follow_Text clss = trvDictionary.SelectedNode.Tag as Class_Follow_Text;
                        try
                        {
                            string sql = "update T_FOLLOW_TEXT set enable_flag='N' where id=" + clss.Id + "";
                            if (App.ExecuteSQL(sql) > 0)
                                App.Msg("设置成功!");
                            else
                                App.Msg("设置失败!");
                        }
                        catch (Exception ex)
                        {
                            App.MsgErr(ex.Message);
                        }
                        btnSelect_Click(sender, e);
                    }
                }
            }
        }



    }
}