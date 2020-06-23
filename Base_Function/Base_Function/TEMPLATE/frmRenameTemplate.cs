using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Bifrost;
using DevComponents.DotNetBar;
using System.Windows.Forms;

namespace Base_Function.TEMPLATE
{
    public partial class frmRenameTemplate : Office2007Form
    {
        UserControl templateManage;
        string current_id;
        public frmRenameTemplate()
        {
            InitializeComponent();
        }

        public frmRenameTemplate(string template_id, UserControl templateManage)
        {
            InitializeComponent();
            this.current_id = template_id;
            this.templateManage = templateManage;
        }

        //窗体加载
        private void frmRenameTemplate_Load(object sender, EventArgs e)
        {
            InitTemplateName();
        }

        //初始化模板名称
        private void InitTemplateName()
        {
            string sql = "select tname from t_tempplate where tid='" + current_id + "'";
            DataSet ds = App.GetDataSet(sql);
            string tname = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                tname = ds.Tables[0].Rows[0]["tname"].ToString();
            }
            this.txtTemplateName.Text = tname;
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
               
                string tname = this.txtTemplateName.Text.Trim();
                if (tname != "")
                {
                    string sql = "update t_tempplate set tname='" + tname + "' where tid='" + current_id + "'";
                    int num = App.ExecuteSQL(sql);
                    if (num > 0)
                    {
                        App.Msg("更新成功！");

                        //对模板界面设置                      
                        if(templateManage.GetType().ToString().Contains("ucTemplateManagement_Small"))
                        {
                            ucTemplateManagement_Small temp = (ucTemplateManagement_Small)templateManage;
                            temp.treeView1.SelectedNode.Text = tname;
                        }
                        else
                        {
                            ucTemplateManagement temp = (ucTemplateManagement)templateManage;
                            temp.treeView1.SelectedNode.Text = tname;
                        }                        
                    }
                    else
                    {
                        App.Msg("更新失败！");
                    }
                    this.Close();
                }
                else
                {
                    App.Msg("模板名称不能为空！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}