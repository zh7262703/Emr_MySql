using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;

namespace Bifrost.HisInstance
{
    /// <summary>
    /// 病理检查
    /// </summary>
    public partial class frmBljc : DevComponents.DotNetBar.Office2007Form
    {
        //WebReference2.Service WebService;

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmBljc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="pid">病人主键</param>
        public frmBljc(string Pid)
        {
            InitializeComponent();
            txtPid.Text = Pid;
            SetData();
        }

        private void frmBljc_Load(object sender, EventArgs e)
        {
            //WebService = new WebReference2.Service();
            //string webip = @"http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite2/Service.asmx";
            //WebService.Url = webip;
            //btnOk_Click(sender, e);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SetData();
            //try
            //{
            //    string sql = "select patholid as '主键',patholcode as '住院号',[name] as '姓名',sex as '性别',specimen as '部位',patholresult as '结果',checkdoctor as '检查医生',reportdate as '报告日期' from bl_checkinfo where patholcode='" + txtPid.Text + "'";
            //    sql = "select '' as YXH,JCH,SHYD,BGYS,SQKS,'' as JCBW,SQYS,JCFF as METHOD,ZDBG as EYESEE,REPORTDIAGNOSE as ZDBG,JCSJ,JCLX,ZYH  from  INTERFACEUSER.T_PASC_DATA@DBPACSLINK where ZYH='" + pt.His_id + "' "
            //    + " and jclx <>'显微镜' and jclx<>'南院病理'"
            //    + " order by jcsj asc";
            //    flgview_Patient.DataSource = WebService.His_GetDataSet(sql).Tables[0].DefaultView;
            //}
            //catch (Exception ex)
            //{
            //    App.MsgErr("HIS数据库连接失败，具体原因：" + ex.Message);
            //}
        }

        private void SetData()
        {
            try
            {
                //string sql = "select patholid as '主键',patholcode as '住院号',[name] as '姓名',sex as '性别',specimen as '部位',patholresult as '结果',checkdoctor as '检查医生',reportdate as '报告日期' from bl_checkinfo where patholcode='" + txtPid.Text + "'";
                string sql = "";
                sql = "select "
                    //+"'' as YXH,"
                    + "JCH as 检查号,"
                    + "SHYD as 审核医生,"
                    + "BGYS as 报告医生,"
                    + "SQKS as 申请科室,"
                    //+ "'' as JCBW,"
                    + "SQYS as 申请医生,"
                    + "Method as 检查方法,"
                    //+ "ZDBG as 影像学表现,"
                    + "ZDBG as 病理诊断"
                    //+ "JCSJ as 检查时间"
                    //+ "JCLX,"
                    //+ "ZYH"
                    + " from T_PASC_DATA"
                    + " where ZYH like'%" + txtPid.Text.Trim() + "%'"
                    + " and jclx in ('显微镜','南院病理')";
                    //+ " order by jcsj asc";
                flgview_Patient.DataSource = App.GetDataSet(sql).Tables[0].DefaultView;
                //flgview_Patient.DataSource = WebService.His_GetDataSet(sql).Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                App.MsgErr("HIS数据库连接失败，具体原因：" + ex.Message);
            }
        }
    }
}