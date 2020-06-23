using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Bifrost;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmRenameFollowTemplate : Office2007Form
    {
        UserControl templateManage;
        string current_id;
        public frmRenameFollowTemplate()
        {
            InitializeComponent();
        }

        public frmRenameFollowTemplate(string template_id, UserControl templateManage)
        {
            InitializeComponent();
            this.current_id = template_id;
            this.templateManage = templateManage;
        }

        //�������
        private void frmRenameFollowTemplate_Load(object sender, EventArgs e)
        {
            InitTemplateName();
        }

        //��ʼ��ģ������
        private void InitTemplateName()
        {
            string sql = "select tname from t_follow_tempplate where tid='" + current_id + "'";
            DataSet ds = App.GetDataSet(sql);
            string tname = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                tname = ds.Tables[0].Rows[0]["tname"].ToString();
            }
            this.txtTemplateName.Text = tname;
        }

        //ȡ��
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ȷ��
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                string tname = this.txtTemplateName.Text.Trim();
                if (tname != "")
                {
                    string sql = "update t_follow_tempplate set tname='" + tname + "' where tid='" + current_id + "'";
                    int num = App.ExecuteSQL(sql);
                    if (num > 0)
                    {
                        App.Msg("���³ɹ���");

                        //��ģ���������                      

                        ucFollowTemplateManagement temp = (ucFollowTemplateManagement)templateManage;
                        temp.trvModel.SelectedNode.Text = tname;

                    }
                    else
                    {
                        App.Msg("����ʧ�ܣ�");
                    }
                    this.Close();
                }
                else
                {
                    App.Msg("ģ�����Ʋ���Ϊ�գ�");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}