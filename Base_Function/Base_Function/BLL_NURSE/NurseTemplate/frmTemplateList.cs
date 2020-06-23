using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar.Controls;

namespace Base_Function.BLL_NURSE.NurseTemplate
{
    public partial class frmTemplateList : DevComponents.DotNetBar.Office2007Form
    {
        public RichTextBox rtbContent = null;
        public string nursecomplate = "";//ȫ�ֱ��� ��ֵ
        //��ѯ��ǰʹ�����Լ�������ģ��
        private string SqlPerson = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='p' and create_id=" + App.UserAccount.UserInfo.User_id + "";
        //��ѯ��ǰʹ�������ڲ����Ĳ���ģ��
        private string SqlSaid = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='s' and a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "";
        //����ΪȫԺ��ģ��
        private string Sqlhospital = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where temp_type='h'";

        public frmTemplateList(RichTextBox rtbContent)
        {
            InitializeComponent();
            this.rtbContent = rtbContent;
        }
        public frmTemplateList()
        {
            InitializeComponent();
        }
        public frmTemplateList(string txt)
        {
            InitializeComponent();
            this.textBox1.Text = txt;
        }
        private void frmTemplateList_Load(object sender, EventArgs e)
        {
            ucGridviewX1.fg.ReadOnly = true;
            ucGridviewX1.fg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucGridviewX1.fg.MultiSelect = false;
            ucGridviewX1.fg.Click += new EventHandler(ClickGrid);
            comboBoxEx1.SelectedIndex = 0;

            ShowAllModel();
        }

        /// <summary>
        /// ��ʾ����ģ��
        /// </summary>
        private void ShowAllModel()
        {
            string sql = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where (a.said=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and temp_type != 'p') or (a.create_id=" + App.UserAccount.UserInfo.User_id + " and temp_type != 's')";
            ucGridviewX1.DataBd(sql, "���", "", "");
            ucGridviewX1.fg.Columns[0].Width = 35;
            ucGridviewX1.fg.Columns[1].Width = 78;
            ucGridviewX1.fg.Columns[2].Width = 414;
            ucGridviewX1.fg.Columns[3].Width = 40;
            ucGridviewX1.fg.Columns[4].Width = 67;
            ucGridviewX1.fg.Columns[5].Width = 100;
            ucGridviewX1.fg.AutoSize = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*//string temp_type = comboBox1.Text;//ģ�����������ˡ�������ȫԺ
            //string Sql = "selest from  t_nures_template where TEMP_TYPE='"+temp_type+"'";
            //string txtcb2 = "";
            //string temp_temp_content = "";//ģ�������

            if (comboBox2.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("������û��ģ��");
                return;
            }
            string secondcbtxt = comboBox2.SelectedItem.ToString();
            string tempcontent="";
            string Sql = "select temp_content from t_nures_template where temp_name='"+secondcbtxt+"'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(Sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    tempcontent = dt.Rows[0][0].ToString();
                }
            }*/
            if (textBox1.Text.Length == 0)
            {
                MessageBox.Show("��ģ������Ϊ��");
                return;
            }
            //this.rtbContent.Text = textBox1.Text;
            nursecomplate = textBox1.Text;
            this.Close();
        }



        public void ClickGrid(object sender, EventArgs e)
        {
            if (ucGridviewX1.fg.SelectedRows.Count != 0)
            {
                if (ucGridviewX1.fg.SelectedRows[0].Cells["����"].Value != null)
                {
                    textBox1.Text = ucGridviewX1.fg.SelectedRows[0].Cells["����"].Value.ToString();
                }
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            /*string sql = "select id ��� ,temp_name ģ������,temp_content ����,case when temp_type='p' then '����' when temp_type='s' then '����' when temp_type='h' then 'ȫԺ' end ����,b.user_name  ������,c.sick_area_name ���� from t_nures_template a inner join t_userinfo b on a.create_id=b.user_id inner join t_sickareainfo c on a.said=c.said where 1=1";

            if (txtTempName.Text != "")
            {
                sql += " and temp_name like '" + txtTempName.Text + "%'";
            }*/
            string SqlQuery = "";
            if (comboBoxEx1.SelectedItem.ToString() == "����")
            {
                SqlQuery = SqlPerson;
                if (txtTempName.Text.Length > 0)
                {
                    SqlQuery += " and temp_name like '%" + txtTempName.Text + "%'";
                }
            }
            else if (comboBoxEx1.SelectedItem.ToString() == "����")
            {
                SqlQuery = SqlSaid;
                if (txtTempName.Text.Length > 0)
                {
                    SqlQuery += " and temp_name like '%" + txtTempName.Text + "%'";
                }
            }
            else if (comboBoxEx1.SelectedItem.ToString() == "ȫԺ")
            {
                SqlQuery = Sqlhospital;
                if (txtTempName.Text.Length > 0)
                {
                    SqlQuery += " and temp_name like '%" + txtTempName.Text + "%'";
                }
            }
            else if (comboBoxEx1.SelectedItem.ToString() == "--��ѡ��--")
            {
                SqlQuery = Sqlhospital + " and temp_name like '%" + txtTempName.Text + "%' union " + SqlPerson + " and temp_name like '%" + txtTempName.Text + "%' union " + SqlSaid + " and temp_name like '%" + txtTempName.Text + "%'";
            }
            ucGridviewX1.DataBd(SqlQuery, "���", "", "");
            ucGridviewX1.fg.Columns[0].Width = 35;
            ucGridviewX1.fg.Columns[1].Width = 78;
            ucGridviewX1.fg.Columns[2].Width = 414;
            ucGridviewX1.fg.Columns[3].Width = 40;
            ucGridviewX1.fg.Columns[4].Width = 67;
            ucGridviewX1.fg.Columns[5].Width = 100;
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
    }
}