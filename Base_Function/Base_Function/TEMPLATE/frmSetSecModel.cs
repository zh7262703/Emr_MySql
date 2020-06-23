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

namespace Base_Function.TEMPLATE
{
    public partial class frmSetSecModel : Office2007Form
    {
        //DataTable dataTable;
        string current_id;
        public UserControl templateManage;
        public frmSetSecModel()
        {
            InitializeComponent();
        }

        public frmSetSecModel(string template_id, UserControl templateManage)
        {
            InitializeComponent();
            this.templateManage = templateManage;
            this.current_id = template_id;
        }

        private void frmSetSecModel_Load(object sender, EventArgs e)
        {
            DataSet dsSection = App.GetDataSet("select a.sid as ��������,a.section_name as �������� from t_sectioninfo a inner join t_section_area b on a.sid=b.sid where ENABLE_FLAG='Y'");           
            dataGridViewX1.DataSource = dsSection.Tables[0].DefaultView;
            dataGridViewX1.ReadOnly = false;

            DataGridViewCheckBoxColumn chkSectioncol = new DataGridViewCheckBoxColumn();
            chkSectioncol.HeaderText = "����";
            chkSectioncol.Name = "����";
            chkSectioncol.DisplayIndex = 0;
            chkSectioncol.Width = 40;
            chkSectioncol.TrueValue = "true";
            chkSectioncol.FalseValue = "false";
            dataGridViewX1.Columns.Add(chkSectioncol);

            DataGridViewCheckBoxColumn chkDefaultSectioncol = new DataGridViewCheckBoxColumn();
            chkDefaultSectioncol.HeaderText = "Ĭ�Ͽ���";
            chkDefaultSectioncol.Name = "Ĭ�Ͽ���";
            chkDefaultSectioncol.DisplayIndex = 1;
            chkDefaultSectioncol.Width = 60;
            chkDefaultSectioncol.TrueValue = "true";
            chkDefaultSectioncol.FalseValue = "false";
            dataGridViewX1.Columns.Add(chkDefaultSectioncol); 
       
            if(ucTemplateManagement.Temp_Sections!=null)
            {
                /*
                 * ��ԭ��ѡ����Ŀ���
                 */

                DataRow[] rows = ucTemplateManagement.Temp_Sections.Tables[0].Select("TEMPLATE_ID=" + current_id + "");
                if (rows != null)
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        for (int j = 0; j < dataGridViewX1.Rows.Count; j++)
                        {
                            if (dataGridViewX1["��������", j].Value != null)
                            {
                                if (rows[i]["SECTION_ID"].ToString() == dataGridViewX1["��������", j].Value.ToString())
                                {
                                    DataGridViewCheckBoxCell sc = dataGridViewX1["����", j] as DataGridViewCheckBoxCell;
                                    sc.Value = "true";
                                    if (rows[i]["ISDEFAULT"].ToString() == "Y")
                                    {
                                        DataGridViewCheckBoxCell sc2 = dataGridViewX1["Ĭ�Ͽ���", j] as DataGridViewCheckBoxCell;
                                        sc2.Value = "true";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ucTemplateManagement.isSecDefault = "";
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNode parentNode;           
            if(templateManage.GetType().ToString().Contains("ucTemplateManagement_Small"))
            {
                ucTemplateManagement_Small temp = (ucTemplateManagement_Small)templateManage;
                parentNode = temp.treeView1.SelectedNode;
            }
            else
            {
                ucTemplateManagement temp = (ucTemplateManagement)templateManage;
                parentNode = temp.treeView1.SelectedNode;
           }            

            ArrayList Sqls = new ArrayList();
            Sqls.Add("delete from t_tempplate_section where TEMPLATE_ID="+current_id+"");
            Sqls.Add("update t_tempplate set TEMPPLATE_LEVEL='S' where TID=" + current_id + "");
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell sc = dataGridViewX1["����", i] as DataGridViewCheckBoxCell;
                if (sc.Value != null)
                {                    
                        if (sc.Value.ToString() == "true")
                        {
                            DataGridViewCheckBoxCell sc2 = dataGridViewX1["Ĭ�Ͽ���", i] as DataGridViewCheckBoxCell;
                            if (sc2.Value != null)
                            {
                                if (sc2.Value.ToString() == "true")
                                {
                                    ucTemplateManagement.isSecDefault = "true";
                                    Sqls.Add("insert into t_tempplate_section(TEMPLATE_ID,SECTION_ID,ISDEFAULT)values(" + current_id + "," + dataGridViewX1["��������", i].Value.ToString() + ",'Y')");
                                }
                                else
                                    Sqls.Add("insert into t_tempplate_section(TEMPLATE_ID,SECTION_ID,ISDEFAULT)values(" + current_id + "," + dataGridViewX1["��������", i].Value.ToString() + ",'N')");
                            }
                            else
                            {
                                Sqls.Add("insert into t_tempplate_section(TEMPLATE_ID,SECTION_ID,ISDEFAULT)values(" + current_id + "," + dataGridViewX1["��������", i].Value.ToString() + ",'N')");
                            }
                        }                    
                }
            }
            Sqls.Add("delete from T_TEMPPLATE_GROUP where TEMPLATE_ID=" + current_id + "");
            string[] strSqls=new string[Sqls.Count];
            for(int i=0;i<Sqls.Count;i++)
            {
                strSqls[i]=Sqls[i].ToString();
            }
            if (App.ExecuteBatch(strSqls) > 0)
            {
                ucTemplateManagement.Temp_Sections = App.GetDataSet("select * from T_TEMPPLATE_SECTION");
                ucTemplateManagement.Temp_Groups = App.GetDataSet("select * from T_TEMPPLATE_GROUP");              
                App.Msg("���óɹ�!");
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
                    DataGridViewCheckBoxCell sc = dataGridViewX1["����", i] as DataGridViewCheckBoxCell;
                    sc.Value = "true";
                }
            }
            else
            {
                for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell sc = dataGridViewX1["����", i] as DataGridViewCheckBoxCell;
                    sc.Value = "false";
                }
            }
        }
    }
}