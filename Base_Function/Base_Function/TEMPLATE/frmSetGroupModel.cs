using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.TEMPLATE
{
    public partial class frmSetGroupModel : DevComponents.DotNetBar.Office2007Form
    {
        string current_id;
        public UserControl templateManage;

        public frmSetGroupModel()
        {
            InitializeComponent();
        }

        public frmSetGroupModel(string template_id, UserControl templateManage)
        {
            InitializeComponent();
            this.templateManage = templateManage;
            this.current_id = template_id;
        }


        private void frmSetGroupModel_Load(object sender, EventArgs e)
        {
            DataSet dsGroup = App.GetDataSet("select a.TNG_ID as ����������,a.TNG_NAME as ���������� from t_treatornurse_group a where ENABLE_FLAG='Y'");
            dataGridViewX1.DataSource = dsGroup.Tables[0].DefaultView;

            DataGridViewCheckBoxColumn chkGroupcol = new DataGridViewCheckBoxColumn();
            chkGroupcol.HeaderText = "������";
            chkGroupcol.Name = "������";
            chkGroupcol.DisplayIndex = 0;
            chkGroupcol.Width = 40;
            chkGroupcol.TrueValue = "true";
            chkGroupcol.FalseValue = "false";
            dataGridViewX1.Columns.Add(chkGroupcol);

            DataGridViewCheckBoxColumn chkDefaultGroupcol = new DataGridViewCheckBoxColumn();
            chkDefaultGroupcol.HeaderText = "Ĭ��������";
            chkDefaultGroupcol.Name = "Ĭ��������";
            chkDefaultGroupcol.DisplayIndex = 1;
            chkDefaultGroupcol.Width = 60;
            chkDefaultGroupcol.TrueValue = "true";
            chkDefaultGroupcol.FalseValue = "false";
            dataGridViewX1.Columns.Add(chkDefaultGroupcol);

            if (ucTemplateManagement.Temp_Groups != null)
            {
                /*
                 * ��ԭ��ѡ����Ŀ���
                 */

                DataRow[] rows = ucTemplateManagement.Temp_Groups.Tables[0].Select("TEMPLATE_ID=" + current_id + "");
                if (rows != null)
                {
                    for (int i = 0; i < rows.Length; i++)
                    {
                        for (int j = 0; j < dataGridViewX1.Rows.Count; j++)
                        {
                            if (dataGridViewX1["����������", j].Value != null)
                            {
                                if (rows[i]["GROUP_ID"].ToString() == dataGridViewX1["����������", j].Value.ToString())
                                {
                                    DataGridViewCheckBoxCell sc = dataGridViewX1["������", j] as DataGridViewCheckBoxCell;
                                    sc.Value = "true";
                                    if (rows[i]["ISDEFAULT"].ToString() == "Y")
                                    {
                                        DataGridViewCheckBoxCell sc2 = dataGridViewX1["Ĭ��������", j] as DataGridViewCheckBoxCell;
                                        sc2.Value = "true";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            TreeNode parentNode;
            if (templateManage.GetType().ToString().Contains("ucTemplateManagement_Small"))
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
            Sqls.Add("delete from T_TEMPPLATE_GROUP where TEMPLATE_ID=" + current_id + "");
            Sqls.Add("update t_tempplate set TEMPPLATE_LEVEL='G' where TID=" + current_id + "");
            for (int i = 0; i < dataGridViewX1.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell sc = dataGridViewX1["������", i] as DataGridViewCheckBoxCell;
                if (sc.Value != null)
                {
                    if (sc.Value.ToString() == "true")
                    {
                        DataGridViewCheckBoxCell sc2 = dataGridViewX1["Ĭ��������", i] as DataGridViewCheckBoxCell;
                        if (sc2.Value != null)
                        {
                            if (sc2.Value.ToString() == "true")
                            {
                                ucTemplateManagement.isGroupDefault = "true";
                                Sqls.Add("insert into T_TEMPPLATE_GROUP(TEMPLATE_ID,GROUP_ID,ISDEFAULT)values(" + current_id + "," + dataGridViewX1["����������", i].Value.ToString() + ",'Y')");
                            }
                            else
                                Sqls.Add("insert into T_TEMPPLATE_GROUP(TEMPLATE_ID,GROUP_ID,ISDEFAULT)values(" + current_id + "," + dataGridViewX1["����������", i].Value.ToString() + ",'N')");
                        }
                        else
                        {
                            Sqls.Add("insert into T_TEMPPLATE_GROUP(TEMPLATE_ID,GROUP_ID,ISDEFAULT)values(" + current_id + "," + dataGridViewX1["����������", i].Value.ToString() + ",'N')");
                        }
                    }
                }
            }
            Sqls.Add("delete from t_tempplate_section where TEMPLATE_ID=" + current_id + "");
            string[] strSqls = new string[Sqls.Count];
            for (int i = 0; i < Sqls.Count; i++)
            {
                strSqls[i] = Sqls[i].ToString();
            }
            if (App.ExecuteBatch(strSqls) > 0)
            {
                ucTemplateManagement.Temp_Sections = App.GetDataSet("select * from T_TEMPPLATE_SECTION");
                ucTemplateManagement.Temp_Groups = App.GetDataSet("select * from T_TEMPPLATE_GROUP");              
                App.Msg("���óɹ�!");
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ucTemplateManagement.isGroupDefault = "";
            this.Close();
        }
    }
}