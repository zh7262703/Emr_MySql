using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Bifrost.HisInStance
{
    public partial class ucPascInfo : UserControl
    {

        //DllTest，我们的动态链接库
        [DllImport("XEFORHIS.dll")]
        public static extern bool XePacsCall(int nPatintIDType, string lpszID, int nCallType);
        [DllImport("XEFORHIS.dll")]
        public static extern bool XePacsInit();
        [DllImport("XEFORHIS.dll")]
        public static extern bool XePacsRelease();

        private string _yxh;
        private string _jch;
        private string _shys;
        private string _bgys;
        private string _sqks;      
        private string _sqbw;     
        private string _sqys;
        private string _jcff;
        private string _yxxbx;
        private string _yxxyj;
        private string _sqsj;
        private string _jclx;
        private string _zyhm;

      
       
      
        /// <summary>
        /// 影像号
        /// </summary>
        public string Yxh
        {
            get { return _yxh; }
            set { _yxh = value; }
        }

        /// <summary>
        /// 检查号
        /// </summary>
        public string Jch
        {
            get { return _jch; }
            set { _jch = value; }
        }

        /// <summary>
        /// 审核医生
        /// </summary>
        public string Shys
        {
            get { return _shys; }
            set { _shys = value; }
        }

        /// <summary>
        /// 报告医生
        /// </summary>
        public string Bgys
        {
            get { return _bgys; }
            set { _bgys = value; }
        }

        /// <summary>
        /// 申请科室
        /// </summary>
        public string Sqks
        {
            get { return _sqks; }
            set { _sqks = value; }
        }

        /// <summary>
        /// 申请部位
        /// </summary>
        public string Sqbw
        {
            get { return _sqbw; }
            set { _sqbw = value; }
        }

        /// <summary>
        /// 申请医生
        /// </summary>
        public string Sqys
        {
            get { return _sqys; }
            set { _sqys = value; }
        }

        /// <summary>
        /// 检查方法
        /// </summary>
        public string Jcff
        {
            get { return _jcff; }
            set { _jcff = value; }
        }

        /// <summary>
        /// 影像学表现
        /// </summary>
        public string Yxxbx
        {
            get { return _yxxbx; }
            set { _yxxbx = value; }
        }

        /// <summary>
        /// 影像学意见
        /// </summary>
        public string Yxxyj
        {
            get { return _yxxyj; }
            set { _yxxyj = value; }
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public string Sqsj
        {
            get { return _sqsj; }
            set { _sqsj = value; }
        }

        /// <summary>
        /// 检查类型
        /// </summary>
        public string Jclx
        {
            get { return _jclx; }
            set { _jclx = value; }
        }

        /// <summary>
        /// 住院号
        /// </summary>
        public string Zyhm
        {
            get { return _zyhm; }
            set { _zyhm = value; }
        }
        

        public ucPascInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="yxh">影响号</param>
        /// <param name="jch">检查号</param>
        /// <param name="shys">审核医生</param>
        /// <param name="bgys">报告医生</param>
        /// <param name="sqks">申请科室</param>
        /// <param name="sqbw">申请部位</param>
        /// <param name="sqys">申请医生</param>
        /// <param name="jcff">检查方法</param>
        /// <param name="yxxbx">影像学表现</param>
        /// <param name="yxxyj">影像学意见</param>
        public ucPascInfo(string yxh,string jch,string shys,string bgys,
            string sqks,string sqbw,string sqys,string jcff,string yxxbx,string yxxyj,string sqsj,string jclx)
        {
            InitializeComponent();
            this.Yxh = yxh;
            this.Jch = jch;
            this.Shys = shys;
            this.Bgys = bgys;
            this.Sqks = sqks;
            this.Sqbw = sqbw;
            this.Sqys = sqys;
            this.Jcff = jcff;
            this.Yxxbx = yxxbx;
            this.Yxxyj = yxxyj;
            this.Sqsj = sqsj;
            this.Jclx = jclx;
            
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="yxh">影响号</param>
        /// <param name="jch">检查号</param>
        /// <param name="shys">审核医生</param>
        /// <param name="bgys">报告医生</param>
        /// <param name="sqks">申请科室</param>
        /// <param name="sqbw">申请部位</param>
        /// <param name="sqys">申请医生</param>
        /// <param name="jcff">检查方法</param>
        /// <param name="yxxbx">影像学表现</param>
        /// <param name="yxxyj">影像学意见</param>
        /// <param name="zyhm">住院号</param>
        public ucPascInfo(string yxh, string jch, string shys, string bgys,
            string sqks, string sqbw, string sqys, string jcff, string yxxbx, string yxxyj, string sqsj, string jclx, string zyhm)
        {
            InitializeComponent();
            this.Yxh = yxh;
            this.Jch = jch;
            this.Shys = shys;
            this.Bgys = bgys;
            this.Sqks = sqks;
            this.Sqbw = sqbw;
            this.Sqys = sqys;
            this.Jcff = jcff;
            this.Yxxbx = yxxbx;
            this.Yxxyj = yxxyj;
            this.Sqsj = sqsj;
            this.Jclx = jclx;
            this.Zyhm = zyhm;
        }     

        private void ucPascInfo_Load(object sender, EventArgs e)
        {
            //初始化设置

            lbljch.Text = Jch;
            lblSqks.Text = Sqks;
            lblSqbw.Text = Sqbw;
            lblSqys.Text = Sqys;
            lblCheckDate.Text = Sqsj;

            txtJcfa.Text = Jcff;
            txtYxxbx.Text = Yxxbx;
            txtYxxyj.Text = Yxxyj;
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 报告查看
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblReport_Click(object sender, EventArgs e)
        {
           // DataSet ds_path = App.GetDataSet("select * from t_ser_address_list where type='P'");
           // string wpath = ds_path.Tables[0].Rows[0]["ADDRESS"].ToString();
            //string url = @"http://" + wpath + "/" + this.Zyhm + @"/" + this.Jch + ".pdf";
             string webPath = App.Read_ConfigInfo("SYSTEMSET", "PACSWEBPATH", Application.StartupPath + "\\Config.ini");
             string url = @"http://" + webPath + @"/WebPacs/webpacs/pacs?type=pipid&view=report&id=" + Zyhm + "";
            HisInStance.frmPicShow fc = new frmPicShow(url);
            fc.ShowDialog();
        }

        private void lblImage_Click(object sender, EventArgs e)
        {          
            string pacsstyle=App.Read_ConfigInfo("SYSTEMSET", "PACSSTYLE", Application.StartupPath + "\\Config.ini");
            string webPath = App.Read_ConfigInfo("SYSTEMSET", "PACSWEBPATH", Application.StartupPath + "\\Config.ini");
            if (pacsstyle == "1")
            {
                //调用PACS客户端程序
                try
                {
                    XePacsInit();//PACS初始化
                    XePacsCall(2, this.Zyhm, 1);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());                   
                }
            }
            else
            {
                //网页
                string url = @"http://" + webPath + @"/WebPacs/webpacs/pacs?type=pipid&view=image&id=" + Zyhm + "";
                HisInStance.frmPicShow fc = new frmPicShow(url);
                fc.ShowDialog();
            }
            
        }

        private bool StartProcess(string filename, string[] args)
        {
            try
            {
                string s = "";
                foreach (string arg in args)
                {
                    s = s + arg + ",";
                }
                s = s.Trim();
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(filename, s);
                myprocess.StartInfo = startInfo;
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("启动应用程序时出错！原因：" + ex.Message);
            }
            return false;
        } 
    }
}
