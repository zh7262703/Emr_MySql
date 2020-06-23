using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.HandoverRecord
{
    public partial class FrmSetSectionHandoverTimePoint : DevComponents.DotNetBar.Office2007Form
    {
        public FrmSetSectionHandoverTimePoint()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        string SectionID = string.Empty;

        private void FrmSetSectionHandoverTimePoint_Load(object sender, EventArgs e)
        {
            SectionID = App.UserAccount.CurrentSelectRole.Section_Id;
            string Sql = "select * from t_sectionhandovertimepoint a where a.sectionid='" + SectionID + "'";
            DataTable table = App.GetDataSet(Sql).Tables[0];
            if (table != null && table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                daystart.Value = Convert.ToDateTime(row["daystart"].ToString());
                dayend.Value = Convert.ToDateTime(row["dayend"].ToString());
                nightstart.Value = Convert.ToDateTime(row["nightstart"].ToString());
                nightend.Value = Convert.ToDateTime(row["nightend"].ToString());
            }
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            List<string> Sqls = new List<string>();
            string Sql = "delete from t_sectionhandovertimepoint a where a.sectionid='" + SectionID + "'";
            Sqls.Add(Sql);
            string id;
            string sdaystart;
            string sdayend;
            string snightstart;
            string snightend;
            id = App.GenId().ToString();
            sdaystart = daystart.Value.ToString("HH:mm");
            sdayend = dayend.Value.ToString("HH:mm");
            snightstart = nightstart.Value.ToString("HH:mm");
            snightend = nightend.Value.ToString("HH:mm");
            Sql = "insert into t_sectionhandovertimepoint(id,sectionid,daystart,dayend,nightstart,nightend)";
            Sql += " values('" + id + "','" + SectionID + "','" + sdaystart + "','" + sdayend + "','" + snightstart + "','" + snightend + "')";
            Sqls.Add(Sql);
            int count = 0;
            try
            {
                count = App.ExecuteBatch(Sqls.ToArray());
                if (count > 0)
                {
                    App.Msg("保存成功！");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                App.Msg("保存出现异常：" + ex.Message.ToString());
                return;
            }
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}