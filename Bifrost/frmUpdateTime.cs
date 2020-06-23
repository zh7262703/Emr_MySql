using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{
    public partial class frmUpdateTime : DevComponents.DotNetBar.Office2007Form
    {
        //public event Inhospital_Info.frmMain.DeleGetRecord Event_GetRecord;
        public bool flag = true;     //true确定要修改,false不要修改。
        private string textName = "";
        public string suporSign = ""; //快码中选中医生的userId

        public frmUpdateTime()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="time">时间</param>
        /// <param name="text_Name">记录名称</param>
        /// <param name="flag">是否是上级医师查房</param>
        public frmUpdateTime(string time,string text_Name,bool flag)
        {
            InitializeComponent();
            this.txtContent.Text = text_Name;
            this.dtpTime.Value = DateTime.Parse(time);
            //this.txtContent.Enabled = false;
            textName = text_Name;
            if (flag)
            {
                label1.Visible = true;
                txtDoctor.Visible = true;
            }
            App.CurrentUpdateTime = "";
            App.CurrentUpdateContent = "";
            App.CurrentHightDoctorId = "";
        }
        public frmUpdateTime(string time)
        {
            InitializeComponent();
            this.dtpTime.Value = DateTime.Parse(time);
            this.txtContent.Enabled = false;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            App.CurrentUpdateTime = "";
            App.CurrentUpdateContent = "";
            App.CurrentHightDoctorId = "";

            App.CurrentUpdateTime = dtpTime.Value.ToString("yyyy-MM-dd HH:mm");
            App.CurrentUpdateContent = txtContent.Text.Trim();          
            App.CurrentHightDoctorId = suporSign;

            if (App.CurrentHightDoctorId.Trim() == "")
            {
                App.MsgWaring("请选择医生！");
                return;
            }

            this.FormClosing -= new FormClosingEventHandler(frmUpdateTime_FormClosing);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUpdateTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            flag = false;
            //App.SelectFastCodeCheck();
        }

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        private void txtDoctor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtDoctor.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select distinct(a.user_id) as 序号,a.user_name as 姓名,g.name as 职称,m.section_name as 科室 from t_userinfo a" +
                                                " inner join t_account_user b on a.user_id=b.user_id" +
                                                " inner join t_account c on b.account_id = c.account_id" +
                                                " inner join t_acc_role d on d.account_id = c.account_id" +
                                                " inner join t_role e on e.role_id = d.role_id" +
                                                " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                                                " inner join t_data_code g on g.id=a.u_tech_post" +
                                                " inner join t_sectioninfo m on f.section_id=m.sid" +
                                                " where e.role_type='D' and UPPER(a.shortcut_code) like '" + txtDoctor.Text.ToUpper().Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtDoctor, "姓名", "职称");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }


        private void txtDoctor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDoctor.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtContent.Text = row["姓名"].ToString() + row["职称"].ToString() + txtContent.Text;
                            suporSign = row["序号"].ToString();
                            App.SelectObj = null;
                        }
                }
                else
                {
                    txtContent.Text = textName;
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
            
        }

        private void frmUpdateTime_Load(object sender, EventArgs e)
        {

        }

        private void txtDoctor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }

        //private void txtDoctor_KeyDown(object sender, KeyEventArgs e)
        //{
        //    //if (e.KeyCode == Keys.Back)
        //    //{ 
        //        if(txtDoctor.Text.Trim()=="")
        //        {
        //            txtContent.Text = textName;
        //            //App.SelectObj.Select_Row = null;
        //        }
        //    //}
        //}
    }
}