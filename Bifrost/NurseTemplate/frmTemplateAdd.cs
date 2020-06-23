using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Bifrost.NurseTemplate
{
    public partial class frmTemplateAdd : DevComponents.DotNetBar.Office2007Form
    {
        private string T_Content = ""; //ģ������
        private string Sql = "";//����sql���
        private string Sql2 = "";//�޸�sql���
        private string Sql3 = "";//ɾ��sql���
        private int tid = -1;

        private enum operate
        {
            add,
            update,
            //delete,
            nothing
        }

        private operate oper = operate.nothing;

        /// <summary>
        /// ��ѯ����ģ��
        /// </summary>
        private string SqlPerson = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='p' and create_id=" + App.UserAccount.UserInfo.User_id + "";

        /// <summary>
        /// ��ѯ����ģ��
        /// </summary>
        private string SqlSaid = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='s' and a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "";

        /// <summary>
        /// ��ѯȫԺģ��
        /// </summary>
        private string Sqlhospital = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='h'";

        public frmTemplateAdd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="template_content">ģ�������</param>
        public frmTemplateAdd(string template_content)
        {
            InitializeComponent();
            T_Content = template_content;
        }

        private void frmTemplateAdd_Load(object sender, EventArgs e)
        {
            ucGridviewX1.fg.ReadOnly = true;
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.Click += new EventHandler(ClickGrid);
            cboType.SelectedIndex = 0;
            cboCondiction.SelectedIndex = 0;
            txtModelContent.Text = T_Content;
            oper = operate.add;

            ShowAllModel();
            buttonchange();
            buttonchange1();
        }

        public void ClickGrid(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.SelectedRows.Count != 0)
            {
                txtModelContent.Text = ucGridviewX1.fg.SelectedRows[0].Cells["����"].Value == null ? "" : ucGridviewX1.fg.SelectedRows[0].Cells["����"].Value.ToString();
                txtModelID.Text = ucGridviewX1.fg.SelectedRows[0].Cells["���"].Value == null ? "" : ucGridviewX1.fg.SelectedRows[0].Cells["���"].Value.ToString();
                txtModelTitle.Text = ucGridviewX1.fg.SelectedRows[0].Cells["ģ������"].Value == null ? "" : ucGridviewX1.fg.SelectedRows[0].Cells["ģ������"].Value.ToString();
                cboType.Text = ucGridviewX1.fg.SelectedRows[0].Cells["����"].Value == null ? "" : ucGridviewX1.fg.SelectedRows[0].Cells["����"].Value.ToString();
            }
            buttonexchange();
            buttonexchange1();
        }

        /// <summary>
        /// ��������ѯ
        /// </summary>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            /*
             * ��������ѯ�����ж��ǰ�ʲô������ѯ����������ͣ�ֱ����ʾ����ǰ���͵�����
             * ����ǰ�ģ������/���ƣ��Ǿ��Ǹ������������/����ʵʩģ����ѯ
             */
            string SqlQuery = "";
            txtTemplateName.ReadOnly = false;

            if (cboCondiction.SelectedItem == null||cboCondiction.SelectedItem.ToString().Contains("��ѡ��"))
            {
                SqlQuery = SqlPerson + " union " + SqlSaid + " union " + Sqlhospital;
            }

            else if (cboCondiction.SelectedItem.ToString() == "��")
            {

                if (txtTemplateName.Text == "")
                {
                    SqlQuery = SqlPerson + " union " + SqlSaid + " union " + Sqlhospital;
                }
                else
                {
                    SqlQuery = SqlPerson + " and temp_name like '%" + txtTemplateName.Text + "%'" + " union " + SqlSaid + " and temp_name like '%" + txtTemplateName.Text + "%'" + " union " + Sqlhospital + " and temp_name like '%" + txtTemplateName.Text + "%'";
                }
            }
            else if (cboCondiction.SelectedItem.ToString() == "��ģ�����Ʋ�ѯ")
            {
                SqlQuery = SqlPerson + " and temp_name like '%" + txtTemplateName.Text + "%'" + " union " + SqlSaid + " and temp_name like '%" + txtTemplateName.Text + "%'" + " union " + Sqlhospital + " and temp_name like '%" + txtTemplateName.Text + "%'";
            }
            else if (cboCondiction.SelectedItem.ToString() == "����ģ���ѯ")
            {
                SqlQuery = SqlPerson;
                if (txtTemplateName.Text != "")
                {
                    SqlQuery += " and temp_name like '%" + txtTemplateName.Text + "%'";
                }
            }
            else if (cboCondiction.SelectedItem.ToString() == "����ģ���ѯ")
            {
                SqlQuery = SqlSaid;
                if (txtTemplateName.Text != "")
                {
                    SqlQuery += " and temp_name like '%" + txtTemplateName.Text + "%'";
                }
            }
            else if (cboCondiction.SelectedItem.ToString() == "ȫԺģ���ѯ")
            {
                SqlQuery = Sqlhospital;
                if (txtTemplateName.Text != "")
                {
                    SqlQuery += " and temp_name like '%" + txtTemplateName.Text + "%'";
                }
            }
            else if (cboCondiction.SelectedItem.ToString() == "��ģ�����ݲ�ѯ")
            {
                SqlQuery = SqlPerson + " and temp_content like '%" + txtTemplateName.Text + "%'" + " union " + SqlSaid + "and temp_content like '%" + txtTemplateName.Text + "%'" + " union " + Sqlhospital + " and temp_content like '%" + txtTemplateName.Text + "%'";
            }
            ucGridviewX1.DataBd(SqlQuery, "���", "", "");


            /*string sql = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where 1=1";

            if (txtTemplateName.Text != "")
            {
                sql += " and temp_name like '%" + txtTemplateName.Text + "%'";
            }
            ucGridviewX1.DataBd(sql, "���", "", "");*/
        }


        /// <summary>
        /// ��Ӱ�ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)//��Ӱ�ť
        {
            buttonchange1();
            buttonchange();
            txtModelTitle.Text = "";
            txtModelContent.Text = "";
            txtModelID.Text = "";
            oper = operate.add;
        }

        /// <summary>
        /// �޸İ�ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)//�޸İ�ť
        {
            buttonchange1();
            buttonchange();
            oper = operate.update;
        }

        /// <summary>
        /// ɾ����ť
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)//ɾ����ť
        {
            if (MessageBox.Show("ȷ��ɾ����ģ�壿", "��ɾ�����ɻָ�", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string textbox = txtModelID.Text;
                int.TryParse(textbox, out tid);
                Sql3 = "delete t_nures_template where id=" + tid + "";
                int num = App.ExecuteSQL(Sql3);
                if (num > 0)
                {
                    App.Msg("ɾ���ɹ�");
                }
                else
                {
                    App.Msg("��ѡ�����ݿ���ɾ��");

                }
                ShowAllModel();
            }
            else
            {

            }
            buttonexchange();
            buttonexchange1();
            txtModelTitle.Text = "";
            txtModelContent.Text = "";
            //oper = operate.delete;   
        }

        /// <summary>
        /// �ı���ǿ�д
        /// </summary>
        private void buttonchange()
        {
            txtModelTitle.ReadOnly = false;
            txtModelContent.ReadOnly = false;
            cboType.Enabled = true;
            buttonX1.Enabled = true;
            btnClose.Enabled = true;
        }

        /// <summary>
        /// �ı����ֻ��
        /// </summary>
        private void buttonexchange()
        {
            txtModelTitle.ReadOnly = true;
            txtModelContent.ReadOnly = true;
            cboType.Enabled = false;
            buttonX1.Enabled = false;
            btnClose.Enabled = false;
        }

        /// <summary>
        /// ��ɾ�İ�ť��ǲ�����
        /// </summary>
        private void buttonchange1()
        {
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
        }

        /// <summary>
        /// ��ɾ�İ�ť��ǿ���
        /// </summary>
        private void buttonexchange1()
        {

            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void ucGridviewX1_Load(object sender, EventArgs e)
        {
            ShowAllModel();
            cboType.SelectedIndex = 0;
            cboCondiction.SelectedIndex = 0;
        }

        /// <summary>
        /// ��ѯ�����combobox�����ݱ仯�����ı仯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEx2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTemplateName.Text = "";
            if (cboCondiction.SelectedItem.ToString() == "��")//||comboBoxEx2.SelectedItem.ToString() =="����ģ���ѯ"||comboBoxEx2.SelectedItem.ToString() =="����ģ���ѯ"||comboBoxEx2.SelectedItem.ToString() =="ȫԺģ���ѯ")
            {
                txtTemplateName.ReadOnly = true;
            }
            if (cboCondiction.SelectedItem.ToString() == "��ģ�����Ʋ�ѯ" || cboCondiction.SelectedItem.ToString() == "��ģ�����ݲ�ѯ" || cboCondiction.SelectedItem.ToString() == "����ģ���ѯ" || cboCondiction.SelectedItem.ToString() == "����ģ���ѯ" || cboCondiction.SelectedItem.ToString() == "ȫԺģ���ѯ")
            {
                txtTemplateName.ReadOnly = false;
            }
        }



        //==================================== Xiao Jun ===============================================

        /// <summary>
        /// ȷ����ť,���ݲ�������ִ�� ��,ɾ,��
        /// </summary>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (CheckForm() == false)
            {
                return;
            }

            int result = 0;

            #region ��ȡģ������
            string type = "";
            if (cboType.SelectedItem.ToString() == "����")
            {
                type = "p";
            }
            else if (cboType.SelectedItem.ToString() == "����")
            {
                type = "s";
            }
            else if (cboType.SelectedItem.ToString() == "ȫԺ")
            {
                type = "h";
            }
            #endregion

            if (oper == operate.add)
            {
                tid = App.GenId("t_nures_template", "id");
                Sql = @"insert into t_nures_template (ID,TEMP_NAME,TEMP_CONTENT,TEMP_TYPE,CREATE_ID,SAID) values (" + tid + ",'" + txtModelTitle.Text + "','" + txtModelContent.Text + "','" + type + "'," + App.UserAccount.UserInfo.User_id + "," + App.UserAccount.CurrentSelectRole.Sickarea_Id + ")";
                result = App.ExecuteSQL(Sql);
            }
            if (oper == operate.update)
            {
                Sql2 = "update t_nures_template SET temp_name='" + txtModelTitle.Text + "',temp_content='" + txtModelContent.Text + "',temp_type='" + type + "' where id=" + txtModelID.Text + "";
                result = App.ExecuteSQL(Sql2);
            }
            string msg = result > 0 ? "����ɹ�!" : "����ʧ��!";
            App.Msg(msg);

            ShowAllModel();
            txtModelID.Text = "";
            cboType.SelectedIndex = 0;
            txtModelTitle.Text = "";
            txtModelContent.Text = "";
            //��ť״̬���
            buttonexchange();
            buttonexchange1();
        }

        /// <summary>
        /// ��ʾ����ģ��
        /// </summary>
        private void ShowAllModel()
        {
            string Sqlucload = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where (a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and temp_type != 'p') or (a.create_id=" + App.UserAccount.UserInfo.User_id + " and temp_type != 's')";
            //string Sqlucload = SqlPerson + " union " + SqlSaid + " union " + Sqlhospital;
            ucGridviewX1.DataBd(Sqlucload, "���", "", "");
        }

        /// <summary>
        /// ��ɾ�Ĳ���ǰ��鴰��������Ƿ���ȷ
        /// </summary>
        private bool CheckForm()
        {
            if (txtModelTitle.Text.Length == 0)
            {
                App.Msg("������ģ�������!");
                txtModelTitle.Focus();
                return false;
            }
            if (txtModelContent.Text.Length == 0)
            {
                App.Msg("������ģ�������!");
                txtModelContent.Focus();
                return false;
            }
            if (cboType.SelectedIndex == 0)
            {
                App.Msg("��ѡ��ģ�������!");
                cboType.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// �ر�
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}