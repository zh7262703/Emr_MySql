using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Bifrost;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Base_Function.TEMPLATE
{
    public partial class frmSetSectionTemplate : Office2007Form
    {
        DataTable dataTable;
        public ucTemplateManagement templateManage;
        string current_id;  //当前模板ID
        string text_type;   //模板文书类型

        public frmSetSectionTemplate()
        {
            InitializeComponent();
        }

        public frmSetSectionTemplate(string template_id, ucTemplateManagement templateManage, string text)
        {
            InitializeComponent();
            this.current_id = template_id;
            this.text_type = text;
            this.templateManage = templateManage;
        }

        //窗体加载
        private void frmSetSectionTemplate_Load(object sender, EventArgs e)
        {
            DataSet dsSection = App.GetDataSet("select * from t_sectioninfo a inner join t_section_area b on a.sid=b.sid where ENABLE_FLAG='Y'");
            dataTable = dsSection.Tables[0];

            this.cboSectionName.DataSource = dataTable.DefaultView;
            this.cboSectionName.ValueMember = "SID";
            this.cboSectionName.DisplayMember = "SECTION_NAME";
            this.cboSectionName.SelectedIndex = 0;
        }

        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //确定
        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNode parentNode = templateManage.treeView1.SelectedNode.Parent;
            string msg = this.cboSectionName.SelectedValue.ToString();
            string[] sqls = new string[2];
            int x = 0;
            if (current_id != "")
            {
                if (msg != "")
                {
                    //取消老模板
                    string oldSql = "select * from T_TempPlate where TEXT_TYPE='" + text_type + "' and ISDEFAULT='Y' and DEFAULT_SEC_ID ='" + msg + "'";
                    string oldId = App.ReadSqlVal(oldSql, 0, "TID");
                    foreach (TreeNode node in parentNode.Nodes)
                    {
                        if (node.Name == oldId)
                        {
                            node.ForeColor = SystemColors.ControlText;   //老模板
                        }
                    }
                    //科室默认模板，例如：取消入院记录文书类型下，所有属于神经内科的默认科室模板
                    sqls[0] = "update T_TempPlate set ISDEFAULT='N',DEFAULT_SEC_ID=null where TEXT_TYPE='" + text_type + "' and SECTION_ID='" + msg + "' and ISDEFAULT='Y' and DEFAULT_SEC_ID is not null";
                    //设置默认科室模板
                    sqls[1] = "update T_TempPlate set DEFAULT_SEC_ID='" + msg + "',SECTION_ID='" + msg + "',TEMPPLATE_LEVEL='S',ISDEFAULT='Y' where tid='" + current_id + "'";
                    templateManage.default_sec = "Y";
                    x = App.ExecuteBatch(sqls);
                }
            }

            if (x > 0)
            {
                templateManage.treeView1.SelectedNode.ForeColor = Color.Blue;
                App.Msg("设置成功!");
            }
            this.Close();
        }
    }
}