using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmUser : DevComponents.DotNetBar.Office2007Form
    {
        private string Sql = "";    //存储调用相关数据库语句       
        private string Type = "";  //存储调用类型
        private int flag = 0;
        private string id="";

        public frmUser()
        {
            InitializeComponent();
            
        }
        public frmUser(string type)
        {
            InitializeComponent();
            Type = type;
            dataGridView1.ReadOnly = true;
            ucElement.id = "";
            ucElement.myName = "";
            switch (type)
            {
                case "User":
                    label1.Text = "请输入用户名:";
                    break;
                case "ICD10":
                    label1.Text = "请输入诊断名:";
                    break;
                case "ICD9":
                    label1.Text = "请输入手术名:";
                    break;

            }
        }
        

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    dataGridView1.Focus(); 
                }
                else
                {
                    if (textBox1.Text != "")
                    {
                        switch (Type)
                        {
                            case "User":
                                Sql = "select user_id 用户编号,user_name 用户姓名 from t_userinfo where shortcut_code like '%" + textBox1.Text.ToUpper() + "%'";
                                break;
                            case "ICD10":
                                Sql = "select code 编码,name 诊断名称 from diag_def_icd10 where shortcut1 like '%" + textBox1.Text.ToUpper() + "%' or name like '%" + textBox1.Text + "%'";
                                break;
                            case "ICD9":
                                Sql = "select code 编码,name 手术名称 from oper_def_icd9 where shortcut1 like '%" + textBox1.Text.ToLower() + "%' or name like '%" + textBox1.Text + "%'";
                                break;
                        }
                        DataSet ds = App.GetDataSet(Sql);
                        if (ds == null)
                        {
                            App.Msg("重新输入");
                            textBox1.Text = "";
                        }
                        dataGridView1.DataSource = ds.Tables[0].DefaultView;
                        dataGridView1.AutoResizeColumns();
                    }
                    
                }
            }
            else
            {
                if (flag == 1)
                {
                    this.Close();
                }
                else
                    App.Msg("请规范输入");
              
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            flag = 1;
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            ucElement.id = id;
            ucElement.myName = textBox1.Text;
            textBox1.Focus();
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (flag == 1)
                this.Close();
            else
                App.Msg("格式不符合要求！");
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                flag = 1;
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                ucElement.id = id;
                ucElement.myName = textBox1.Text;
            }
        }

    }
}