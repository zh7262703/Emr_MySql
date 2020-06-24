using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using MySql.Data.MySqlClient;

namespace Base_Function.Infection
{
    public partial class FrmModifyInfect : DevComponents.DotNetBar.Office2007Form
    {
        bool isModify = false;
        int infection_id;
        string smg = "添加";
        public FrmModifyInfect()
        {
            InitializeComponent();
            this.Text = smg + "传染病";
        }

        public FrmModifyInfect(int _infection_id, bool _isModify)
        {
            InitializeComponent();
            this.infection_id = _infection_id;
            this.isModify = _isModify;
            LoadData();
        }

        void LoadData()
        {
            if (infection_id > 0)
            {
                smg = "修改";
                string sql = "select a.* from t_infection_index a where a.infection_id=" + infection_id;
                DataTable table = App.GetDataSet(sql).Tables[0];
                if (table != null && table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    this.textBox1.Text = row["infection_name"].ToString();
                    byte[] bs = (byte[])row["description"];
                    string content = System.Text.Encoding.Default.GetString(bs);
                    this.richTextBox1.AppendText(content);
                }
            }
            this.Text = smg + "传染病";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Sql = string.Empty;
                string infection_name = this.textBox1.Text.Trim();
                if (string.IsNullOrEmpty(infection_name))
                {
                    App.Msg("名称不能为空！");
                    return;
                }
                string v_enabled = "0";
                if (this.checkBox1.Checked)
                    v_enabled = "1";
                if (this.infection_id > 0)
                {
                    Sql = "update t_infection_index a set a.infection_name='" + infection_name + "',a.enabled='" + v_enabled + "'";
                    Sql += ",description=:description where a.infection_id=" + infection_id;
                }
                else
                {
                    infection_id = App.GenId();
                    Sql = " insert into t_infection_index (infection_id, infection_name, enabled, description) values";
                    Sql += "(" + infection_id + ", '" + infection_name + "', '" + v_enabled + "', :description)";
                }

                string Content = this.richTextBox1.Text;
                if (string.IsNullOrEmpty(Content))
                    Content = " ";
                byte[] bs = System.Text.Encoding.Default.GetBytes(Content);
                MySqlDBParameter[] ops = new MySqlDBParameter[1];
                MySqlDBParameter op = new MySqlDBParameter();
                op.DBType = MySqlDbType.Blob;
                op.ParameterName = "description";
                op.Value = bs;
                ops[0] = op;
                int count = App.ExecuteSQL(Sql, ops);
                App.Msg(smg + "成功！");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch { App.Msg(smg + "失败!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmModifyInfect_Load(object sender, EventArgs e)
        {

        }
    }
}