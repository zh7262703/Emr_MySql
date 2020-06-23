using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    public partial class frmTemplateList : DevComponents.DotNetBar.Office2007Form
    {
        public string  nursecomplate="";//ȫ�ֱ��� ��ֵ
      
        public frmTemplateList()
        {
            InitializeComponent();
        }
        
        private void frmTemplateList_Load(object sender, EventArgs e)
        {
            cboType.Text = "����";

            ucGridviewX1.fg.AllowUserToAddRows = false;
            ucGridviewX1.fg.ReadOnly = true;
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.Click += new EventHandler(ClickGrid);
            buttonX1_Click_1(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("��ģ������Ϊ��");
                this.Close();
            }
            nursecomplate=textBox1.Text;

            //����secondcbtxt������ȥ��ѯ���ݿ�t_nures_template���ҵ�t_nures_template��temp_type��secondcbtxt��ͬ������
            //���������ݵ�����temp_contentд�뵽����������ڵĴ�����ȥ,���رմ��塣
            this.Close();
        }

        public void ClickGrid(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = ucGridviewX1.fg.SelectedRows[0].Cells["����"].Value.ToString();
            }
            catch
            { }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {           
            string SqlQuery = "";
            if (cboType.Text == "����")
            {
                SqlQuery = "select id ��� ,temp_name ģ������,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='p' and create_id=" + App.UserAccount.UserInfo.User_id + " and temp_name like '%" + txtTempName.Text + "%'";
            }
            else if (cboType.Text == "����")
            {
                SqlQuery = "select id ��� ,temp_name ģ������,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='s' and temp_name like '%" + txtTempName.Text + "%'";
            }
            else if (cboType.Text == "ȫԺ")
            {
                SqlQuery = "select id ��� ,temp_name ģ������,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='h' and temp_name like '%" + txtTempName.Text + "%'";
            }                      
            ucGridviewX1.DataBd(SqlQuery, "���", "", "");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            nursecomplate = "";
            this.Close();
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTempName.Text = "";
        }

        private void btnNewTemplate_Click(object sender, EventArgs e)
        {
            frmTemplateAdd fc = new frmTemplateAdd();
            fc.ShowDialog();
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {               
                string templatename=ucGridviewX1.fg[ucGridviewX1.fg.Columns["ģ������"].Index,ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                if (App.Ask("ȷ��Ҫɾ����¼��" + templatename + "��"))
                {
                    string sql = "delete from t_nures_template aa where aa.id=" + ucGridviewX1.fg[ucGridviewX1.fg.Columns["���"].Index, ucGridviewX1.fg.CurrentRow.Index].Value.ToString()+ "";
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("�����ɹ���");
                        buttonX1_Click_1(sender, e);
                    }
                    else
                    {
                        App.MsgErr("ɾ��ʧ�ܣ�");
                    }
                }
            }
            catch(Exception ex)
            {
                App.MsgErr("ɾ��ʧ�ܣ�"+ex.Message);
            }
        }     
    }
}