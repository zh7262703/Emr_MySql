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
        private bool isSave;                         //��¼��ǰ����Ϊ������޸� true���� false�޸�
        public static Class_Follow_Text Fathernode = null;  //���ڼĴ游�ڵ��ʵ��
        private Class_Follow_Text selectClasstext = null;   //���ڼĴ浱ǰѡ�еĽڵ�ʵ��
        public static string fahterId = "0";         //�����ڵ�Ĭ��Ϊ0
        public static string fahterName = "0";       //���ڵ�����
        private string textname;                     //��ǰѡ�е�������������       
        public static string texttype = "";          //���ڵ���������
        private string mark = "Y";                   //��Ч��־


        public static bool isShowNumChange = false;  //�Ƿ��������仯

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
        /// ��ʼ���ؼ���ʹ�䴦��Ĭ��״̬
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
        /// �����б����
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
        /// ʵ��Class_Text����ѯ���
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
        /// ����ID��ȡ�ڵ�
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
        /// ���ˢ��
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
        /// �༭״̬
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
        /// ��������з�������
        /// </summary>
        /// <param Name="Directionarys">��������ڵ㼯��</param>
        /// <param Name="current">��ǰ����ڵ�</param>
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
        /// ����,��ʼ������������
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
                        //��Ч�ڵ㣬��ɫ��ʾ
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
                        //���붥���ڵ�
                        if (Directionarys[i].Parentid == 0)
                        {
                            trvDictionary.Nodes.Add(tn);
                            SetTreeView(Directionarys, tn);
                        }
                    }
                    
                }
                else
                {
                    App.Msg("û���ҵ���ѯ�����");
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
        /// �������ҵ����������ڵ�չ���丸�ڵ�
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
        /// �ж��Ƿ��������TEXTNAME
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
        /// �ж��Ƿ��������TEXTCODE
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
        /// ���
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
        /// �޸�
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
        /// ������޸Ĳ���
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList Sqls = new ArrayList();
            string sid = "";    //�������������,Ĭ��Ϊ�������п���
            for (int i = 0; i < clbSection.Items.Count; i++)
            {
                if (clbSection.GetItemText(clbSection.Items[i]) == "0:ȫԺ" && clbSection.GetItemChecked(i))  //���ȫԺ��ѡ�У��������SIDֱ����Ϊ0
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
                App.Msg("�������Ʊ�����д��");
                txtName.Focus();
                return;
            }
            //��Ч��־
            if (rbtnVainmark.Checked == true)
            {
                mark = "N";
            }
            else
            {
                mark = "Y";
            }
            
            //�Ƿ����ñ༭��
            string isEdit = "Y";
            if (rbtnEnditYes.Checked)
                isEdit = "N";
            else
                isEdit = "Y";
            //��������
            int isSingle = 0;
            if (rbtnSingle.Checked)
                isSingle = 0;
            else
                isSingle = 1;
            //�����û�����,N����ʿ��D��ҽ����S��ְ�ܿ���
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
                        App.MsgWaring("���ڵ㲻��ȷ,�밴del��ť����ո��ڵ�����ѡ�񣡣�");
                        return;
                    }
                }

                string Sql = "";
                if (isSave)
                {

                    if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ����������ˣ�");
                        txtName.Focus();
                        return;
                    }
                    else if (isExisitCode(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ����ı���ˣ�");
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
                        App.Msg("�����ɹ���");
                    }
                }

                btnCancel_Click(sender, e);

                if (isSave)
                {
                    //���,ˢ������
                    btnSelect_Click(sender, e);
                }
                else
                {
                    //�޸�
                    ReIniNode(trvDictionary.SelectedNode);

                }


            }
            catch (Exception ex)
            {
                App.Msg("���ʧ�ܣ�ԭ��" + ex.ToString() + "");
            }
        }

        /// <summary>
        /// ������ؽڵ�
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
        /// �˳�����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            refurbish();
        }
        /// <summary>
        /// �󶨽ڵ���Ϣ ��ʾ���༭��
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
        /// ѡ�нڵ��
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
        /// ����ڵ�
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
        /// ���ÿ����б�ѡ����
        /// </summary>
        private void SetItemChecked()
        {
            if (selectClasstext == null)
            {
                return;
            }
            //ȡ������ѡ�е�Item
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
            //ѡ�и��������������
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
        /// ����ӽڵ�
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ����ӽڵ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                Fathernode = selectClasstext;
                btnAdd_Click(sender, e);
            }
            else
            {
                App.Msg("��ѡ����Ҫ�������Ľڵ�!");
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Follow_Text"))
                {

                    if (trvDictionary.SelectedNode.Nodes.Count == 0)
                    {
                        if (App.Ask("ȷ��Ҫɾ����,�û���д�ĸ������齫�ᶪʧ����"))
                        {
                            Class_Follow_Text temp = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                            try
                            {
                                if (App.ExecuteSQL("delete from T_FOLLOW_TEXT where ID=" + temp.Id + "")>0 || App.ExecuteSQL("delete from T_FOLLOW_TEMPPLATE where text_type=" + temp.Id + "")>0)
                                    trvDictionary.Nodes.Remove(trvDictionary.SelectedNode);
                                else
                                    App.Msg("ɾ��δ���");
                            }
                            catch
                            {
                                App.MsgErr("ɾ��ʧ��");
                            }
                        }

                    }
                    else
                    {
                        App.Msg("�ýڵ����Ѿ������ӽڵ�,Ҫɾ����ѽڵ��´��ڵ��ӽڵ��������ɾ��");
                    }
                }
                btnSelect_Click(sender, e);
            }
            else
            {
                App.Ask("��ѡ����Ҫɾ���Ľڵ㣡");

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
        /// ѡ�񸸽ڵ�
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
        /// ���ƶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// ���ƶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
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
        /// ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                Class_Follow_Text temp1 = (Class_Follow_Text)trvDictionary.SelectedNode.Tag;
                frmFollowWrite_Type_Order fr = new frmFollowWrite_Type_Order(temp1.Parentid.ToString());
                App.FormStytleSet(fr, false);
                fr.ShowDialog();

                //�������仯
                if (ucFollowWrite_Type.isShowNumChange)
                {
                    btnSelect_Click(sender, e);
                }
            }
            else
            {
                App.MsgWaring("��ѡ��Ҫ��������飡");
            }
        }

        /// <summary>
        /// ɾ�����ڵ�
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

        private void ��ЧToolStripMenuItem_Click(object sender, EventArgs e)
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
                                App.Msg("���óɹ�!");
                            else
                                App.Msg("����ʧ��!");
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