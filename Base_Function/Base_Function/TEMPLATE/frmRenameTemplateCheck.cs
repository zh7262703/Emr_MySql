using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Base_Function.TEMPLATE
{
    public partial class frmRenameTemplateCheck : Office2007Form
    {
        string current_id;

        public frmRenameTemplateCheck()
        {
            InitializeComponent();
        }


        public frmRenameTemplateCheck(string template_id)
        {
            InitializeComponent();
            this.current_id = template_id;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmRenameTemplateCheck_Load(object sender, EventArgs e)
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
