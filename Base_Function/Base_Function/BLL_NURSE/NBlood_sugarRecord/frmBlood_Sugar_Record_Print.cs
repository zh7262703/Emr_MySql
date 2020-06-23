using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using Bifrost;

namespace Base_Function.BLL_NURSE.NBlood_sugarRecord
{
    public partial class frmBlood_Sugar_Record_Print : DevComponents.DotNetBar.Office2007Form
    {
        private string bed_no;

        private string pname;

        private string pid;
        private string section_name;

        private string sickarea_name;


        /// <summary>
        /// 床号
        /// </summary>
        public string Bed_no
        {
            get { return bed_no; }
            set { bed_no = value; }
        }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }
        /// <summary>
        /// 病人住院号
        /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        /// <summary>
        /// 科别
        /// </summary>
        public string Section_name
        {
            get { return section_name; }
            set { section_name = value; }
        }
        /// <summary>
        /// 病区
        /// </summary>
        public string Sickarea_name
        {
            get { return sickarea_name; }
            set { sickarea_name = value; }
        }

        DataSet dsItems = new DataSet();
        DataSet dsPatients = new DataSet();
        /// <summary>
        /// 单个病人的构造函数
        /// </summary>
        /// <param name="dsitems"></param>
        /// <param name="dspatients"></param>
        /// <param name="bed">床号</param>
        /// <param name="pname">病人姓名</param>
        /// <param name="pid">病人住院号</param>
        public frmBlood_Sugar_Record_Print(DataSet dsitems, DataSet dspatients,string bed,string pname,string pid,string section_name,string sickarea_name)
        {
            InitializeComponent();
            dsItems = dsitems;
            Bed_no = bed;
            Pname = pname;
            Pid = pid;
            Section_name = section_name;
            Sickarea_name = sickarea_name;
        
           
        }
        public frmBlood_Sugar_Record_Print(DataSet dsitems, string bed, string pname, string pid, string section_name)
        {
            InitializeComponent();
            dsItems = dsitems;
            Bed_no = bed;
            Pname = pname;
            Pid = pid;
            Section_name = section_name;
        }
        private void frmBlood_Sugar_Record_Print_Load(object sender, EventArgs e)
        {
            if (dsItems != null)
            {
                if (dsItems.Tables[0].Rows.Count < 1)
                {
                    App.Msg("没有可以打印的信息！");
                    return;
                }
                else
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    this.reportViewer1.RefreshReport();
                    //this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\Report_First_Cases.rdlc";
                    this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\ReportFile\\Report_Bgrecord.rdlc";
                    string path ="file:///"+App.SysPath+@"\2.jpg";//图片地址

                    this.reportViewer1.LocalReport.EnableExternalImages = true;
                    ReportParameter[] pams = new ReportParameter[6];
                    pams[0] = new ReportParameter("Bed", Bed_no);
                    pams[1] = new ReportParameter("Name", Pname);
                    pams[2] = new ReportParameter("Hospital", Pid);
                    pams[3] = new ReportParameter("setion_name", Section_name);
                    pams[4] = new ReportParameter("sickarea_name", Sickarea_name);
                    pams[5] = new ReportParameter("image1", path);
                    reportViewer1.LocalReport.SetParameters(pams);
                   
                    //reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet_Bgrecord_DateBgrecord", dsItems.Tables[0]));
                    

                    this.reportViewer1.RefreshReport();
                    this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                    this.reportViewer1.ZoomMode = ZoomMode.Percent;
                    this.reportViewer1.ZoomPercent = 100;
                    this.reportViewer1.RefreshReport();
                }
            }
        }

        //public string ImageDatabytes(string FilePath)
        //{
        //    if (!File.Exists(FilePath))
        //        return null;
        //    Bitmap myBitmap = new Bitmap(Image.FromFile(FilePath));

        //    using (MemoryStream curImageStream = new MemoryStream())
        //    {
        //        myBitmap.Save(curImageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //        curImageStream.Flush();

        //        byte[] bmpBytes = curImageStream.ToArray();
        //        //如果转字符串的话
        //        string BmpStr = Convert.ToBase64String(bmpBytes);
        //        return BmpStr;
        //    }
        //}


      


    }
}