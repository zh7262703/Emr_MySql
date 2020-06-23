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
    /// ������
    /// </summary>
    public partial class frmBljc : DevComponents.DotNetBar.Office2007Form
    {
        //WebReference2.Service WebService;

        /// <summary>
        /// ���캯��
        /// </summary>
        public frmBljc()
        {
            InitializeComponent();
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="pid">��������</param>
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
            //    string sql = "select patholid as '����',patholcode as 'סԺ��',[name] as '����',sex as '�Ա�',specimen as '��λ',patholresult as '���',checkdoctor as '���ҽ��',reportdate as '��������' from bl_checkinfo where patholcode='" + txtPid.Text + "'";
            //    sql = "select '' as YXH,JCH,SHYD,BGYS,SQKS,'' as JCBW,SQYS,JCFF as METHOD,ZDBG as EYESEE,REPORTDIAGNOSE as ZDBG,JCSJ,JCLX,ZYH  from  INTERFACEUSER.T_PASC_DATA@DBPACSLINK where ZYH='" + pt.His_id + "' "
            //    + " and jclx <>'��΢��' and jclx<>'��Ժ����'"
            //    + " order by jcsj asc";
            //    flgview_Patient.DataSource = WebService.His_GetDataSet(sql).Tables[0].DefaultView;
            //}
            //catch (Exception ex)
            //{
            //    App.MsgErr("HIS���ݿ�����ʧ�ܣ�����ԭ��" + ex.Message);
            //}
        }

        private void SetData()
        {
            try
            {
                //string sql = "select patholid as '����',patholcode as 'סԺ��',[name] as '����',sex as '�Ա�',specimen as '��λ',patholresult as '���',checkdoctor as '���ҽ��',reportdate as '��������' from bl_checkinfo where patholcode='" + txtPid.Text + "'";
                string sql = "";
                sql = "select "
                    //+"'' as YXH,"
                    + "JCH as ����,"
                    + "SHYD as ���ҽ��,"
                    + "BGYS as ����ҽ��,"
                    + "SQKS as �������,"
                    //+ "'' as JCBW,"
                    + "SQYS as ����ҽ��,"
                    + "Method as ��鷽��,"
                    //+ "ZDBG as Ӱ��ѧ����,"
                    + "ZDBG as �������"
                    //+ "JCSJ as ���ʱ��"
                    //+ "JCLX,"
                    //+ "ZYH"
                    + " from T_PASC_DATA"
                    + " where ZYH like'%" + txtPid.Text.Trim() + "%'"
                    + " and jclx in ('��΢��','��Ժ����')";
                    //+ " order by jcsj asc";
                flgview_Patient.DataSource = App.GetDataSet(sql).Tables[0].DefaultView;
                //flgview_Patient.DataSource = WebService.His_GetDataSet(sql).Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                App.MsgErr("HIS���ݿ�����ʧ�ܣ�����ԭ��" + ex.Message);
            }
        }
    }
}