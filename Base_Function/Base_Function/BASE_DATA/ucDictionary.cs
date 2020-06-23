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
    public partial class ucDictionary : UserControl
    {
        bool isSave = false;        //���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string mark = "Y";  //��Ч��־
        private string ID = "";     //�����ֵ�ά��ID
        Class_Datacodecs selectDirectionary=null;
        public ucDictionary()
        {
            InitializeComponent();
        }
        private void frmDictionary_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("�����ֵ�ά����Ϣ");
            Bangding();
            BangType();
            RefleshFrm();

        }

        private void frmDictionary_Activated(object sender, EventArgs e)
        {
            Bangding();
            BangType();
        }
        //������
        private void Bangding()
        {
            DataSet dt = App.GetDataSet("select * from T_DATA_CODE_TYPE order by name");
            cmbType.DataSource = dt.Tables[0].DefaultView;
            cmbType.ValueMember = "ID";
            cmbType.DisplayMember = "NAME";
        }
        /// <summary>
        /// �󶨲�ѯ������
        /// </summary>
        private void BangType()
        {
            DataSet dts = App.GetDataSet("select * from T_DATA_CODE_TYPE order by name");
            cmbTypes.DataSource = dts.Tables[0].DefaultView;
            cmbTypes.ValueMember = "ID";
            cmbTypes.DisplayMember = "NAME";
        }

        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
            txtName.Enabled = false;
            txtCode.Enabled = false;
            radYes.Enabled = false;
            radNo.Enabled = false;
            txtPinyin.Enabled = false;
            cmbType.Enabled = false;
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            selectDirectionary = null;
            trvDictionary.SelectedNode = null;          
            groupBox1.Enabled = true;
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
                txtName.Text = "";
                txtCode.Text = "";
                txtPinyin.Text = "";
            }
            txtName.Enabled = true;
            txtCode.Enabled = true;
            radYes.Enabled = true;
            radNo.Enabled = true;
            txtPinyin.Enabled = true;
            cmbType.Enabled = true;
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupBox1.Enabled = false;
            txtCode.Focus();
        }
        /// <summary>
        /// ���ˢ��
        /// </summary>
        private void refurbish()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtPinyin.Text = "";
            txtName.Enabled = false;
            txtCode.Enabled = false;
            radYes.Enabled = false;
            radNo.Enabled = false;
            txtPinyin.Enabled = false;
            cmbType.Enabled = false;
            btnAdd.Enabled = true;
            btnModify.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            selectDirectionary = null;
            trvDictionary.SelectedNode = null;
            groupBox1.Enabled = true;
            isSave = false;
        }
        /// <summary>
        /// ʵ������ѯ���
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Datacodecs[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Datacodecs[] Directionary = new Class_Datacodecs[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Datacodecs();
                        Directionary[i].Id =tempds.Tables[0].Rows[i]["ID"].ToString();
                        Directionary[i].Name = tempds.Tables[0].Rows[i]["NAME"].ToString();
                        Directionary[i].Code = tempds.Tables[0].Rows[i]["CODE"].ToString();
                        Directionary[i].Shortchut_code = tempds.Tables[0].Rows[i]["SHORTCUT_CODE"].ToString();
                        Directionary[i].Enable = tempds.Tables[0].Rows[i]["ENABLE"].ToString();
                        Directionary[i].Type = tempds.Tables[0].Rows[i]["TYPE"].ToString();
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

        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string name)
        {
            DataSet ds = App.GetDataSet("select TYPE from T_DATA_CODE where NAME='" + name + "' and TYPE='" + cmbType.SelectedValue+ "'");
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

        /// <summary>.
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitName(string name, string id)
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE where NAME='" + name + "' and ID=" + id + "");
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

        private void iniEditData(Class_Datacodecs temp)
        {
            if (temp != null)
            {
                txtCode.Text = temp.Code;
                txtName.Text = temp.Name;
                txtPinyin.Text = temp.Shortchut_code;
                mark = temp.Enable;
                if (mark == "Y")
                {
                    radYes.Checked = true;
                    radNo.Checked = false;
                }
                else
                {
                    radNo.Checked = true;
                    radYes.Checked = false;
                }
                cmbType.SelectedValue = temp.Type;
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
            isSave = false;
            Edit(isSave);
            //if (txtCode.Text.Trim()!="")
                txtCode.Enabled = false;
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
                if (txtCode.Enabled && txtCode.Text.Trim() == "")
                {
                    App.Msg("�����Ų���Ϊ�գ�");
                    txtCode.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("���Ʋ���Ϊ�գ�");
                    txtName.Focus();
                    return;
                }
                if (!radYes.Checked)
                {
                    mark = "N";
                }
                else
                {
                    mark = "Y";
                }
                if (cmbType.Text.Trim() == "")
                {
                    App.Msg("���Ͳ���Ϊ�գ�");
                    txtCode.Focus();
                    return;
                }
                string Sql = "";
                ID = App.GenId("T_DATA_CODE", "ID").ToString();
                if (isSave)
                {
                    if (isExisitName(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ���Ƶ�ֵ�ˣ�");
                        txtCode.Focus();
                        return;
                    }
                    Sql = "insert into T_DATA_CODE(ID,NAME,CODE,SHORTCUT_CODE,ENABLE,TYPE)values(" + ID + ",'" + App.ToDBC(txtName.Text) + "','"
                    + App.ToDBC(txtCode.Text) + "','" + txtPinyin.Text + "','" + mark + "','" + cmbType.SelectedValue + "')";
                    btnAdd_Click(sender, e);
                }
                else
                {
                    Sql = "update T_DATA_CODE set NAME='" + App.ToDBC(txtName.Text) + "',CODE='"
                                       + App.ToDBC(txtCode.Text) + "',SHORTCUT_CODE='" + txtPinyin.Text + "',ENABLE='" + mark + "',TYPE='" + cmbType.SelectedValue + "' where ID=" + selectDirectionary.Id.ToString() + "";
                    selectDirectionary.Name = txtName.Text;
                    selectDirectionary.Code = txtCode.Text;
                    selectDirectionary.Shortchut_code = txtPinyin.Text;
                    selectDirectionary.Enable =mark;
                    selectDirectionary.Type = cmbType.SelectedValue.ToString();
                    trvDictionary.SelectedNode.Tag = selectDirectionary;
                    trvDictionary.SelectedNode.Text = txtName.Text;
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
            //RefleshFrm();
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

                if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Datacodecs"))
                {
                    selectDirectionary = (Class_Datacodecs)trvDictionary.SelectedNode.Tag;
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
                    if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Datacodecs"))
                    {
                        selectDirectionary = (Class_Datacodecs)trvDictionary.SelectedNode.Tag;
                        iniEditData(selectDirectionary);
                    }
                }
            }
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
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
                radYes.Focus();
            }
            
        }
        private void radYes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbType.Focus();
            }
        }

        private void radNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmbType.Focus();
            }
        }

        private void cmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtPinyin.Text = App.getSpell(App.ToDBC(txtName.Text.Trim()));   
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
                string Sql = "select * from  T_DATA_CODE where TYPE='"+cmbTypes.SelectedValue+"' order by ID desc";
                if (radPY.Checked)
                {
                    if (txtConditions.Text.Trim() != "")
                        Sql = "select * from T_DATA_CODE where SHORTCUT_CODE like '%" + txtConditions.Text.Trim() + "%' and TYPE='" + cmbTypes.SelectedValue + "' order by ID desc";
                }
                else if (radName.Checked)
                {
                    if (txtConditions.Text.Trim() != "")
                        Sql = "select * from T_DATA_CODE where name like '%" + txtConditions.Text.Trim() + "%' and TYPE='" + cmbTypes.SelectedValue + "' order by ID desc";
                }
                else
                {
                }
                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_Datacodecs[] Directionarys = GetSelectDirectionary(ds);
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
                    App.ExecuteSQL("delete from T_DATA_CODE where ID=" + selectDirectionary.Id.ToString()+ "");
                    trvDictionary.Nodes.Remove(trvDictionary.SelectedNode);
                   
                    
                }
            }
            else
            {
                App.Msg("����ѡ��Ҫɾ���Ľڵ㣡");
            }
        }




      

    }
}