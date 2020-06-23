using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    public partial class updateTitle : Form
    {
        private int status = 0;
        private TreeNode tn;
        public updateTitle()
        {
            InitializeComponent();
        }

        public updateTitle(int _status, TreeNode _tn, string _formTitle, string _lbName)
        {
            InitializeComponent();
            if (_status == 3)
            {
                this.txtName.Text = _tn.Text;
            }
            this.status = _status;
            this.tn = _tn;
            this.Text = _formTitle;
            this.label1.Text = _lbName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text.Trim().ToString() == "")
            {
                App.Msg("���Ʋ���Ϊ��");
                this.txtName.Focus();
                return;
            }
            try
            {

                if (tn != null)
                {
                    string inputName = this.txtName.Text.ToString();

                    //if (App.GetDataSet(string.Format("SELECT NAME FROM TABLE_F WHERE NAME = '{0}'"
                    //    , inputName)).Tables[0].Rows.Count > 0)
                    //{
                    //    App.Msg("�Ѵ�������Ϊ[" + inputName + "]��Ŀ¼��Ԫ��!");
                    //    return;
                    //}
                    int showType = 0;
                    int imageIndex = 0;
                    int selectImageIndex = 0;
                    switch (status)
                    {
                        case 0:   //Ŀ¼
                            showType = 2;
                            imageIndex = 0;
                            selectImageIndex = 1;
                            break;
                        case 1:   //ѡ����Ԫ��
                            showType = 3;
                            imageIndex = 2;
                            selectImageIndex = 3;
                            break;
                        case 2:   //�������Ԫ��
                            showType = 4;
                            break;
                        case 3:   //�޸ı���
                            showType = 5;
                            break;
                    }
                    if (showType == 5)
                    {
                        string sql = string.Format("UPDATE TABLE_F SET NAME ='{0}' WHERE ID = '{1}'", inputName, tn.Tag.ToString());
                        App.ExecuteSQL(sql);
                        App.Msg("�����޸ĳɹ�");
                        tn.Text = inputName;
                    }
                    else
                    {
                        string id = App.GenId().ToString();//App.GenId("TABLE_F", "ID").ToString()
                        string sql = string.Format("INSERT INTO TABLE_F(NAME,PARENTID,SHOWTYPE,id) VALUES('{0}','{1}','{2}','{3}')",
                                             inputName, tn.Tag.ToString(), showType,id);
                        App.ExecuteSQL(sql);

                        App.Msg("����Ŀ¼��Ԫ�سɹ�");
                        TreeNode tnChild = new TreeNode();
                        if (status == 1)
                        {
                            tnChild.Name = "3";
                        }
                        tnChild.Text = inputName;
                        tnChild.Tag = id;
                        tnChild.ImageIndex = imageIndex;
                        tnChild.SelectedImageIndex = selectImageIndex;
                        tnChild.ContextMenuStrip = tn.ContextMenuStrip;
                        tn.Nodes.Add(tnChild);
                        tn.Expand();
                    }
                    this.Close();
                }
            }
            catch
            {
                App.Msg("���粻ͨ�����������Ƿ����ã�");
                throw;
            }
        }
    }
}