using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.AdvTree;
using Base_Function.BASE_COMMON;
using Bifrost;
using Bifrost_Doctor;
using System.Diagnostics;
using Base_Function.BLL_DOCTOR;
using TextEditor;
using System.Xml;
using Base_Function.TEMPLATE;
using Base_Function.BLL_DOCTOR.Consultation_Manager;
using Base_Function.Digital_Medical_Treatment;

namespace Digital_Medical_Treatment
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 病人id
        /// </summary>
        public string strPatient_id;

       

        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(InPatientInfo inpatientInfo)
        {
            InitializeComponent();
            DataInit.CurrentPatient=inpatientInfo;

            ucTemp = new ucTemplateListGet();
            ucTemp.Dock = DockStyle.Fill;
            ucTemp.TemplateSelect += new EventHandler(Template_Doubleclick);

            ucTemp.Reflesh(DataInit.discuss_text_id.ToString());
            splitContainer1.Panel2.Controls.Add(ucTemp);

            if (DataInit.CurrentPatient != null)
            {

                string sql = "select * from T_DISCUSS_DOC where patient_id=" + DataInit.CurrentPatient.Id + "";
                DataSet ds = App.GetDataSet(sql);
                string Record_Time = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int tid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                    string Content = ds.Tables[0].Rows[0]["CONTENT"].ToString();
                   
                    //读取已有文书
                    frmText text = new frmText(DataInit.discuss_text_id, 0, 0, "病例讨论", tid, DataInit.CurrentPatient, true, false, Record_Time, "病例讨论");
                    if (Content != "")
                    {
                        //读取默认模板
                        XmlDocument tempxmldoc = new XmlDocument();
                        tempxmldoc.PreserveWhitespace = true;
                        tempxmldoc.LoadXml(Content);
                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                    }

                    
                    text.Dock = DockStyle.Fill;
                    groupPanel1.Controls.Add(text);
                }
                else
                {
                    Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                    //新的文书
                    frmText text = new frmText(DataInit.discuss_text_id, 0, 0, "病例讨论", 0, DataInit.CurrentPatient, true, false, Record_Time, "病例讨论");


                    string templatecontent = DataInit.GetDefaultTemp(DataInit.discuss_text_id.ToString());
                    ucTemp.Reflesh(text.MyDoc.Us.TextKind_id.ToString());
                    if (templatecontent != "" && templatecontent!=null)
                    {
                        //读取默认模板
                        XmlDocument tempxmldoc = new XmlDocument();
                        tempxmldoc.PreserveWhitespace = true;
                        tempxmldoc.LoadXml(templatecontent);
                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                    }

                    text.Dock = DockStyle.Fill;
                    groupPanel1.Controls.Add(text);
                }

            }
           
        }
        public frmMain(string strID)
        {
            InitializeComponent();
            strPatient_id = strID;
           
        }

        /// <summary>
        /// 模板提取
        /// </summary>
        ucTemplateListGet ucTemp;
    






        #region  事件

        /// <summary>
        /// 模板双击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Template_Doubleclick(object sender, EventArgs e)
        {
            try
            {
                    frmText trmptext = (frmText)groupPanel1.Controls[0];
                    if (ucTemp.Temptype == "S")
                    {                      
                        trmptext.MyDoc._insertElements("<a>" + ucTemp.LoadContent + "</a>");
                    }
                    else
                    {                        
                       
                        trmptext.MyDoc.ClearContent();                       
                        XmlDocument tempxmldoc = new XmlDocument();
                        tempxmldoc.PreserveWhitespace = true;
                        tempxmldoc.LoadXml(ucTemp.LoadContent);
                        trmptext.MyDoc.SaveLogs.Clear();
                        trmptext.MyDoc.FilterXml(ucTemp.LoadContent, 1, null);                        
                        trmptext.MyDoc.FromXML(tempxmldoc.DocumentElement);
                    }

              
            }
            catch (Exception ex)
            {
                string bug = ex.Message;

            }
        }

        ///// <summary>
        ///// 文书内容的获取
        ///// </summary>
        ///// <param name="editor"></param>
        ///// <param name="id"></param>
        //public static void GetDiscussDoc(frmText editor, string Patient_id)
        //{
        //    if (editor != null)
        //    {
        //        string sql = "select * from T_DISCUSS_DOC where patient_id=" + Patient_id + "";
        //        DataSet ds = App.GetDataSet(sql);

        //        if (ds.Tables[0].Rows.Count > 0)
        //        {
        //            string content = ds.Tables[0].Rows[0]["CONTENT"].ToString();
        //            XmlDocument tempxmldoc = new XmlDocument();
        //            tempxmldoc.PreserveWhitespace = true;
        //            tempxmldoc.LoadXml(content);
        //            editor.MyDoc.FromXML(tempxmldoc.DocumentElement);
        //        }
        //        else
        //        {
        //            return;
        //        }
        //    }
        //}

        /// <summary>
        /// 窗口加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {          
           App.FormStytleSet(this,false);                     
        }
        #endregion

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 关闭系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmText trmptext = (frmText)groupPanel1.Controls[0];
            DataInit.DiscussDocSave(trmptext);
        }

        /// <summary>
        /// 文书内容提取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGetText_Click(object sender, EventArgs e)
        {
            frmText trmptext = (frmText)groupPanel1.Controls[0];
            frmDoctorBookGet frm = new frmDoctorBookGet(DataInit.CurrentPatient.PId, DataInit.CurrentPatient.Id, trmptext);
            frm.Show();
        }

        
    }

}