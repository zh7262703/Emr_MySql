using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_DOCTOR.HisInStance
{
    public partial class frm_Pasc : DevComponents.DotNetBar.Office2007Form
    {
        InPatientInfo pt;
        string yxx_bx = "";
        string yxx_yj = "";
        string SqlConditions = ""; //查询条件
        bool arg;//控制不同入口进到操作页面的功能按键的可用性
        public frm_Pasc()
        {
            InitializeComponent();
            this.ControlBox = false;   // 设置不出现关闭按钮
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient">病人实体类</param>
        public frm_Pasc(InPatientInfo patient)
        {
            InitializeComponent();
            pt = patient;
            arg = true;
            App.PascResault = "";
            App.FormStytleSet(this, false);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient">病人实体类</param>
        public frm_Pasc(InPatientInfo patient,bool arg1,bool arg2,bool arg3)
        {
            InitializeComponent();
            pt = patient;
            arg = arg1;
            App.PascResault = "";
            App.FormStytleSet(this, false);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient">病人实体类</param>
        public frm_Pasc(InPatientInfo patient, string sqlcondition)
        {
            InitializeComponent();
            pt = patient;
            arg = true;
            App.PascResault = "";
            App.FormStytleSet(this, false);
            SqlConditions = sqlcondition;
        }

        private void frm_Pasc_Load(object sender, EventArgs e)
        {
            App.LisResault = "";
            App.His_Yz_Resault = "";
            if (pt != null)
            {
                lblName.Text = pt.Patient_Name;
                if (pt.Gender_Code == "0")
                {
                    lblSex.Text = "男";
                }
                else
                {
                    lblSex.Text = "女";
                }
                lblAge.Text = pt.Age.ToString();
                if (pt.Birthday != "")
                {
                    lblBirthday.Text = Convert.ToDateTime(pt.Birthday).ToString("yyyy-MM-dd");
                }
                lblSickNo.Text = pt.PId; //病案号
                if (App.UserAccount.CurrentSelectRole.Role_type == "O")
                {
                    btnOutPutYxxbx.Visible = false;
                    btnOutPutYxxyj.Visible = false;
                }
            }

            DataSet ds = App.GetDataSet("select * from  t_pasc_data where ZYH='" + pt.PId + "'");
            this.tabControl1.Tabs.Clear();
            string yxh;
            string jch;
            string shys;
            string bgys;
            string sqks;
            string sqbw;
            string sqys;
            string jcff;
            string yxxbx;
            string yxxyj;
            string sqsj;
            string jclx;
            if (ds != null)
            {

                sqsj = string.Empty;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    yxh = ds.Tables[0].Rows[i]["YXH"].ToString();
                    jch = ds.Tables[0].Rows[i]["JCH"].ToString();
                    shys = ds.Tables[0].Rows[i]["SHYD"].ToString();
                    bgys = ds.Tables[0].Rows[i]["BGYS"].ToString();
                    sqks = ds.Tables[0].Rows[i]["SQKS"].ToString();
                    sqbw = ds.Tables[0].Rows[i]["JCBW"].ToString();
                    sqys = ds.Tables[0].Rows[i]["SQYS"].ToString();
                    jcff = ds.Tables[0].Rows[i]["METHOD"].ToString();
                    yxxbx = ds.Tables[0].Rows[i]["EYESEE"].ToString();
                    yxxyj = ds.Tables[0].Rows[i]["ZDBG"].ToString();
                    //sqsj = ds.Tables[0].Rows[i]["JCSJ"].ToString();
                    jclx = ds.Tables[0].Rows[i]["JCLX"].ToString();
                    if (sqsj.Trim() != "")
                    {
                        sqsj = Convert.ToDateTime(sqsj).ToString("yyyy-MM-dd");
                    }
                    ucPascInfo pascinfo = new ucPascInfo(yxh, jch, shys, bgys, sqks, sqbw, sqys, jcff, yxxbx, yxxyj, sqsj, jclx, pt.PId);
                    pascinfo.Dock = DockStyle.Fill;
                    DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
                    tabctpnDoc.AutoScroll = true;
                    DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
                    page.Text = jch + "--" + jclx;
                    tabctpnDoc.TabItem = page;
                    tabctpnDoc.Dock = DockStyle.Fill;
                    page.AttachedControl = tabctpnDoc;
                    page.Tag = pascinfo;
                    tabctpnDoc.Controls.Add(pascinfo);
                    this.tabControl1.Controls.Add(tabctpnDoc);
                    //this.tabControl1.Tabs.Add(page);
                    this.tabControl1.Refresh();
                    this.tabControl1.SelectedTab = page;

                }
                
                if (arg == false)
                {
                    string msg = "";
                    BLL_DOCTOR.HisInStance.LIS.UcLis uc = new Base_Function.BLL_DOCTOR.HisInStance.LIS.UcLis(pt,msg);
                    tabControlPanel9.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;

                    BLL_DOCTOR.HisInStance.医嘱单.frmYzd frm = new Base_Function.BLL_DOCTOR.HisInStance.医嘱单.frmYzd(pt, msg);
                    tabControlPanel6.Controls.Add(frm);
                    frm.Dock = DockStyle.Fill;

                    btn_ok.Enabled = false;
                }
                else
                {
                    BLL_DOCTOR.HisInStance.LIS.UcLis uc = new Base_Function.BLL_DOCTOR.HisInStance.LIS.UcLis(pt);
                    tabControlPanel9.Controls.Add(uc);
                    uc.Dock = DockStyle.Fill;

                    BLL_DOCTOR.HisInStance.医嘱单.frmYzd frm = new Base_Function.BLL_DOCTOR.HisInStance.医嘱单.frmYzd(pt);
                    tabControlPanel6.Controls.Add(frm);
                    frm.Dock = DockStyle.Fill;

                    btn_ok.Enabled = true;
                }
            }


        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            //if (tabControl1.Tabs.Count > 0)
            //{
            //    if (tabControl1.SelectedTab != null)
            //    {
            //        ucPascInfo temp = (ucPascInfo)tabControl1.SelectedTab.Tag;
            //        lblCheckDoctor.Text = temp.Shys;
            //        lblReportDoctor.Text = temp.Bgys;

            //        temp.Yxxbx = temp.Yxxbx.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "；");
            //        temp.Yxxyj = temp.Yxxyj.Replace("\n", "").Replace(" ", "").Replace("\t", "").Replace("\r", "；");

            //        yxx_bx = temp.Sqsj + " " + temp.Jclx + " 影像学表现:" + temp.Yxxbx;
            //        yxx_yj = temp.Sqsj + " " + temp.Jclx + " 影像学意见:" + temp.Yxxyj;
            //    }
            //}
        }


        /// <summary>
        /// 去掉最后的空格和分号
        /// </summary>
        /// <returns></returns>
        private string remove_trimr(string jg)
        {
            string jgs = jg;
            if (jgs.Length > 0)
            {
                if (jgs.Substring(jg.Length - 1, 1) == "；" || jgs.Substring(jgs.Length - 1, 1) == " ")
                {
                    jgs = jgs.Substring(0, jgs.Length - 1);
                    jgs = remove_trimr(jgs);
                }
                else
                {
                    return jgs;
                }

            }
            return jgs;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            App.PascResault = "";
            this.Close();
        }

        //private void btnOutPutYxxbx_Click(object sender, EventArgs e)
        //{
        //    App.PascResault = "";
        //    App.PascResault = remove_trimr(yxx_bx);
        //    this.Close();
        //}

        //private void btnOutPutYxxyj_Click(object sender, EventArgs e)
        //{
        //    App.PascResault = "";
        //    App.PascResault = remove_trimr(yxx_yj);
        //    this.Close();
        //}
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            try
            {
                ucPascInfo temp = (ucPascInfo)tabControl1.SelectedTab.Tag;
                //全部导入
                if (temp.chk_yxxbx.Checked == true && temp.chk_yxxyj.Checked == true)
                {
                    App.PascResault = "";
                    App.PascResault_YJ = "";
                    yxx_bx = temp.LS_yxxbx[0].ToString();
                    App.PascResault = remove_trimr(yxx_bx);
                    yxx_yj = temp.LS_yxxyj[0].ToString();
                    App.PascResault_YJ = remove_trimr(yxx_yj);
                    this.Close();
                }
                //导入影像学表现
                if (temp.chk_yxxbx.Checked == true && temp.chk_yxxyj.Checked == false)
                {
                    yxx_bx = temp.LS_yxxbx[0].ToString();
                    App.PascResault = "";
                    App.PascResault = remove_trimr(yxx_bx);
                    this.Close();
                }
                //导入影像学意见
                if (temp.chk_yxxyj.Checked == true && temp.chk_yxxbx.Checked == false)
                {
                    yxx_yj = temp.LS_yxxyj[0].ToString();
                    App.PascResault_YJ = "";
                    App.PascResault_YJ = remove_trimr(yxx_yj);
                    this.Close();
                }
            }
            catch
            {

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnOutPutYxxbx_Click(object sender, EventArgs e)
        {

        }

        private void btnOutPutYxxyj_Click(object sender, EventArgs e)
        {

        }

        private void frm_Pasc_FormClosing(object sender, FormClosingEventArgs e)
        {
            //App.PascResault = "";
            //App.PascResault_YJ = "";
        }
    }
}
