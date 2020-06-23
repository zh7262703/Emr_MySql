using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Bifrost;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowSetSecModel : Office2007Form
    {
        private string sid = "";
        private string current_id="";
        public UserControl templateManage;
        private string text_kind = "";
        public frmFollowSetSecModel()
        {
            InitializeComponent();
        }

        public frmFollowSetSecModel(string template_id,string text_kind,string sid , UserControl templateManage)
        {
            InitializeComponent();
            this.templateManage = templateManage;
            this.current_id = template_id;
            this.text_kind = text_kind;
            this.sid = sid;
            
        }

        private void frmSetSecModel_Load(object sender, EventArgs e)
        {
            string Section = "";
            if(sid!="0")
                Section="select a.sid 科室主键,a.section_name 科室名 from T_SECTIONINFO a  where a.sid in (" + sid + ") and a.is_follow_visit='Y'";
            else
                Section = "select a.sid 科室主键,a.section_name 科室名 from T_SECTIONINFO a where a.is_follow_visit='Y'";
            DataSet dsSection = App.GetDataSet(Section);
            

            DataGridViewCheckBoxColumn chkSectioncol = new DataGridViewCheckBoxColumn();
            chkSectioncol.HeaderText = "科室";
            chkSectioncol.Name = "科室";
            chkSectioncol.DisplayIndex = 0;
            chkSectioncol.Width = 40;
            chkSectioncol.TrueValue = "true";
            chkSectioncol.FalseValue = "false";
            dataGridViewX1.Columns.Add(chkSectioncol);

            DataGridViewCheckBoxColumn chkDefaultSectioncol = new DataGridViewCheckBoxColumn();
            chkDefaultSectioncol.HeaderText = "默认科室";
            chkDefaultSectioncol.Name = "默认科室";
            chkDefaultSectioncol.DisplayIndex = 1;
            chkDefaultSectioncol.Width = 60;
            chkDefaultSectioncol.TrueValue = "true";
            chkDefaultSectioncol.FalseValue = "false";
            dataGridViewX1.Columns.Add(chkDefaultSectioncol);
            dataGridViewX1.DataSource = dsSection.Tables[0].DefaultView;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ucFollowTemplateManagement.isSecDefault = "";
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNode parentNode;

            ucFollowTemplateManagement temp = (ucFollowTemplateManagement)templateManage;
            parentNode = temp.trvModel.SelectedNode;
            

            ArrayList Sqls = new ArrayList();
            Sqls.Add("delete from t_follow_tempplate_section where TEMPLATE_ID=" + current_id + "");
            
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell sc = dataGridViewX1["科室", i] as DataGridViewCheckBoxCell;
                if (sc.Value != null)
                {
                    if (sc.Value.ToString() == "true")
                    {
                        DataGridViewCheckBoxCell sc2 = dataGridViewX1["默认科室", i] as DataGridViewCheckBoxCell;
                        if (sc2.Value != null)
                        {
                            if (sc2.Value.ToString() == "true")
                            {
                                ucFollowTemplateManagement.isSecDefault = "true";
                                Sqls.Add("update t_follow_tempplate_section set ISDEFAULT='N' where template_id in (select tid from t_follow_tempplate where text_type=" + text_kind + " and tempplate_level='S') and section_id=" + dataGridViewX1["科室主键", i].Value.ToString() + "");
                                Sqls.Add("insert into t_follow_tempplate_section(TEMPLATE_ID,SECTION_ID,ISDEFAULT)values(" + current_id + "," + dataGridViewX1["科室主键", i].Value.ToString() + ",'Y')");
                                Sqls.Add("update t_follow_tempplate set TEMPPLATE_LEVEL='S', ISDEFAULT='Y' where TID=" + current_id + "");
                            }
                            else
                            {
                                Sqls.Add("insert into t_follow_tempplate_section(TEMPLATE_ID,SECTION_ID,ISDEFAULT)values(" + current_id + "," + dataGridViewX1["科室主键", i].Value.ToString() + ",'N')");

                            }
                        }
                        else
                        {
                            Sqls.Add("insert into t_follow_tempplate_section(TEMPLATE_ID,SECTION_ID,ISDEFAULT)values(" + current_id + "," + dataGridViewX1["科室主键", i].Value.ToString() + ",'N')");
                            
                        }
                    }
                }
            }
            if (ucFollowTemplateManagement.isSecDefault == "false")
                Sqls.Add("update t_follow_tempplate set ISDEFAULT='N' where tid=" + current_id + "");
            string[] strSqls = new string[Sqls.Count];
            for (int i = 0; i < Sqls.Count; i++)
            {
                strSqls[i] = Sqls[i].ToString();
            }
            if (App.ExecuteBatch(strSqls) > 0)
            {
                ucFollowTemplateManagement.Temp_Sections = App.GetDataSet("select * from T_FOLLOW_TEMPPLATE_SECTION");
                App.Msg("设置成功!");
            }

            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection.Checked)
            {
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell sc = dataGridViewX1["科室", i] as DataGridViewCheckBoxCell;
                    sc.Value = "true";
                }
            }
            else
            {
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell sc = dataGridViewX1["科室", i] as DataGridViewCheckBoxCell;
                    sc.Value = "false";
                }
            }
        }
    }
}