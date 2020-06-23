using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.HisInStance.PACS
{
    public partial class ucPasc : UserControl
    {
        InPatientInfo pt;
        string yxx_bx = "";
        string yxx_yj = "";
        string SqlConditions = ""; //查询条件
        public ucPasc()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient">病人实体类</param>
        public ucPasc(InPatientInfo patient)
        {
            InitializeComponent();
            pt = patient;
            App.PascResault = "";
            //App.FormStytleSet(this, false);
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient">病人实体类</param>
        public ucPasc(InPatientInfo patient,bool flag,bool e)
        {
            InitializeComponent();
            pt = patient;
            App.PascResault = "";
            //App.FormStytleSet(this, false);
            panel2.Visible = false;
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient">病人实体类</param>
        public ucPasc(InPatientInfo patient, string sqlcondition)
        {
            InitializeComponent();
            pt = patient;
            App.PascResault = "";
            //App.FormStytleSet(this, false);
            SqlConditions = sqlcondition;
        }

        private void ucPasc_Load(object sender, EventArgs e)
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
                    panel3.Controls.Add(pascinfo);
                    pascinfo.Dock = DockStyle.Fill;
                    //DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
                    //tabctpnDoc.AutoScroll = true;
                    //DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
                    //page.Text = jch + "--" + jclx;
                    //tabctpnDoc.TabItem = page;
                    //tabctpnDoc.Dock = DockStyle.Fill;
                   // page.AttachedControl = tabctpnDoc;
                    //page.Tag = pascinfo;
                   // tabctpnDoc.Controls.Add(pascinfo);
                   // this.tabControl1.Controls.Add(tabctpnDoc);
                    //this.tabControl1.Refresh();
                    //this.tabControl1.SelectedTab = page;

                }
            }
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
        }

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
                }
                //导入影像学表现
                if (temp.chk_yxxbx.Checked == true && temp.chk_yxxyj.Checked == false)
                {
                    yxx_bx = temp.LS_yxxbx[0].ToString();
                    App.PascResault = "";
                    App.PascResault = remove_trimr(yxx_bx);
                }
                //导入影像学意见
                if (temp.chk_yxxyj.Checked == true && temp.chk_yxxbx.Checked == false)
                {
                    yxx_yj = temp.LS_yxxyj[0].ToString();
                    App.PascResault_YJ = "";
                    App.PascResault_YJ = remove_trimr(yxx_yj);
                }
            }
            catch
            {

            }
        }
    }
}
