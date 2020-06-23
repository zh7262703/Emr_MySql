using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.TEMPLATE
{
    public partial class ucSmallTemplate_Count_set : UserControl
    {
        public ucSmallTemplate_Count_set()
        {
            InitializeComponent();
            App.UsControlStyle(this);
        }

        public void refleshsection()
        {
            DataSet dssid = App.GetDataSet("select * from T_SECTIONINFO t where t.sid not in (select section_id from t_small_template_count_set)");
            string[] strsqls = new string[dssid.Tables[0].Rows.Count];
            for (int i = 0; i < dssid.Tables[0].Rows.Count; i++)
            {
                string id = App.GenId().ToString();
                strsqls[i] = "insert into T_SMALL_TEMPLATE_COUNT_SET(id,SECTION_ID,MAX_COUNT)values(" + id + "," + dssid.Tables[0].Rows[i]["SID"].ToString() + ",50)";
            }

            App.ExecuteBatch(strsqls);

            DataSet ds = App.GetDataSet("select t.sid,t.section_name from t_sectioninfo t");
            comboBox1.DataSource = ds.Tables[0].DefaultView;
            comboBox1.DisplayMember = "section_name";
            comboBox1.ValueMember = "sid";
            comboBox1.SelectedValue = App.UserAccount.CurrentSelectRole.Section_Id;
            comboBox1.Enabled = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            GetMAX_COUNT();
        }

        private void ucSmallTemplate_Count_set_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMAX_COUNT();
        }

        private void GetMAX_COUNT()
        {
            try
            {
                DataSet ds = App.GetDataSet("select * from t_small_template_count_set t where t.section_id=" + comboBox1.SelectedValue.ToString() + "");
                numericUpDown1.Value = Convert.ToDecimal(ds.Tables[0].Rows[0]["MAX_COUNT"]);
            }
            catch
            { }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            if (App.ExecuteSQL("Update t_small_template_count_set set MAX_COUNT=" + numericUpDown1.Value.ToString() + " where section_id=" + comboBox1.SelectedValue.ToString() + "") > 0)
            {
                App.Msg("操作已经成功！");
            }
            else
            {
                App.Msg("操作失败！");
            }
        }
    }
}
