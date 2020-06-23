using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR
{
    public partial class frmUpdateTime : DevComponents.DotNetBar.Office2007Form
    {
        public event ucDoctorOperater.DeleGetRecord Event_GetRecord;
        public bool flag = true;     //true确定要修改,false不要修改。
        private string textName = "";
        public string suporSign = ""; //快码中选中医生的userId
        private bool isSelectedDoc = false;     //是否选择医生，默认为false未选择

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
            App.FormStytleSet(this,false);
            this.txtContent.Text = text_Name;
            this.dtpTime.Value = DateTime.Parse(time);
            //this.txtContent.Enabled = false;
            textName = text_Name;
            if (flag)
            {
                label1.Visible = true;
                txtDoctor.Visible = true;
            }
        }
        public frmUpdateTime(string time)
        {
            InitializeComponent();
            this.dtpTime.Value = DateTime.Parse(time);
            this.txtContent.Enabled = false;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtDoctor.Visible == true )
            {
                if (isSelectedDoc == false || txtDoctor.Text == "")
                {
                    App.Msg("请选择一个医生！");
                    txtDoctor.Text = "";
                    return ;
                } 
            }
            if (txtContent.Text == "")
            {
                App.Msg("记录名称不能为空！");
                txtContent.Focus();
                return;
            }
            if (Event_GetRecord!=null)
            {
                Event_GetRecord(string.Format("{0:g}", dtpTime.Value.ToString("yyyy-MM-dd HH:mm")), txtContent.Text.Trim());
            }
            this.FormClosing -= new FormClosingEventHandler(frmUpdateTime_FormClosing);

            ucDoctorOperater.isFlagtrue = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ucDoctorOperater.isFlagtrue = false;
            this.Close();
        }

        private void frmUpdateTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            flag = false;            
            App.SelectFastCodeCheck();
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
                            txtContent.Text = row["姓名"].ToString() + row["职称"].ToString() + txtContent.Text; //textName;
                            suporSign = row["序号"].ToString();
                            App.SelectObj = null;
                            isSelectedDoc = true;
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