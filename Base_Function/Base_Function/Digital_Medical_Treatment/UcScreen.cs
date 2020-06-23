using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Bifrost_Doctor;
using Bifrost.HisInstance;
using Base_Function.BLL_DOCTOR;
using Base_Function.BASE_COMMON;
using System.Xml;
using TextEditor;

namespace Digital_Medical_Treatment
{
    public partial class UcScreen : DevComponents.DotNetBar.Office2007Form
    {
        
        public UcScreen()
        {
            InitializeComponent();
        }
        public UcScreen(InPatientInfo inpateint)
        {
            InitializeComponent();
            DataInit.CurrentPatient = inpateint;

            if (DataInit.CurrentPatient != null)
            {

                string sql = "select * from T_DISCUSS_DOC where patient_id=" + DataInit.CurrentPatient.Id + "";
                DataSet ds = App.GetDataSet(sql);
                string Record_Time = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int tid = Convert.ToInt32(ds.Tables[0].Rows[0]["id"].ToString());
                    int textkindid = Convert.ToInt32(ds.Tables[0].Rows[0]["TEXTKIND_ID"].ToString());
                    string Content = ds.Tables[0].Rows[0]["CONTENT"].ToString();

                    //读取已有文书
                    frmText text = new frmText(textkindid, 0, 0, "病例讨论", tid, DataInit.CurrentPatient, true, false, Record_Time, "病例讨论");
                    if (Content != "")
                    {
                        //读取默认模板
                        XmlDocument tempxmldoc = new XmlDocument();
                        tempxmldoc.PreserveWhitespace = true;
                        tempxmldoc.LoadXml(Content);
                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                    }


                    text.Dock = DockStyle.Fill;

                    panel2.Controls.Add(text);
                }
                else
                {
                    Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                    //新的文书
                    frmText text = new frmText(DataInit.discuss_text_id, 0, 0, "病例讨论", 0, DataInit.CurrentPatient, true, false, Record_Time, "病例讨论");


                    string templatecontent = DataInit.GetDefaultTemp(DataInit.discuss_text_id.ToString());
                    //ucTemp.Reflesh(text.MyDoc.Us.TextKind_id.ToString());
                    if (templatecontent != "" && templatecontent!=null)
                    {
                        //读取默认模板
                        XmlDocument tempxmldoc = new XmlDocument();
                        tempxmldoc.PreserveWhitespace = true;
                        tempxmldoc.LoadXml(templatecontent);
                        text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                    }

                    text.Dock = DockStyle.Fill;
                    panel2.Controls.Add(text);
                }

            }

        }
        #region 字段与属性
        /// <summary>
        /// 当前患者的Info
        /// </summary>

        #endregion




        #region 方法

        private string TransGender(string genderCode)
        {
            if (!string.IsNullOrEmpty(genderCode))
            {
                if (genderCode.Equals("1"))
                {
                    return genderCode = "女";
                }
                else
                {
                    if (genderCode.Equals("0"))
                    {
                        return genderCode = "男";
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcScreen_Load(object sender, EventArgs e)
        {
            this.lblPatientName.Text = DataInit.CurrentPatient.Patient_Name.ToString();
            this.lblSex.Text = this.TransGender(DataInit.CurrentPatient.Gender_Code);
            this.lblAge.Text = DataInit.CurrentPatient.Age.ToString() + DataInit.CurrentPatient.Age_unit.ToString();
            this.lblBedNum.Text = DataInit.CurrentPatient.Sick_Bed_Name + "床";
            this.lblIndate.Text = DataInit.CurrentPatient.In_Time.ToString();
            this.lblCurrentDate.Text = App.GetSystemTime().ToString();
         
         
        }
        private string GetSelectNodes(Patient_Doc text)
        {
            string arrs = null;
            if (text != null)
            {
                string sql = "select tid,textname from t_patients_doc where patient_id='" + DataInit.CurrentPatient.Id + "' and tid=" + text.Id + "";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string content = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", DataInit.CurrentPatient.Id.ToString());
                            if (content == "")
                            {
                                content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                            }
                            arrs += content;
                        }
                    }
                }
            }
            return arrs;
        }
        /// <summary>
        /// 打开患者的病历概述和已写病历
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRecord_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnRecord.Enabled = false;
                Form frm = new Form();
                frm.WindowState = FormWindowState.Maximized;

                ucDoctorOperater ucOperater = new ucDoctorOperater(DataInit.CurrentPatient);
                //ucOperater.c1OutPage2.PageVisible = false;
                //ucOperater.c1OutPage4.PageVisible = false;
                //ucOperater.c1OutPage5.PageVisible = false;
                //ucOperater.c1OutPage3.PageVisible = true;
                frm.Controls.Add(ucOperater);
                ucOperater.Dock = DockStyle.Fill;
                frm.ShowDialog();
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnRecord.Enabled = true;
            }
        }
        /// <summary>
        /// 显示屏显示患者的检验信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnCheck.Enabled = false;
                FrmLis fc = new FrmLis(DataInit.CurrentPatient.PId);
                App.FormStytleSet(fc, false);

                fc.ShowDialog();
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnCheck.Enabled = true;
            }
        }
        /// <summary>
        /// 显示屏展示患者的检查信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnTest.Enabled = false;
                Bifrost.HisInStance.frm_Pasc fc = new Bifrost.HisInStance.frm_Pasc(DataInit.CurrentPatient);
                App.FormStytleSet(fc, false);

                fc.Show();
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnTest.Enabled = true;
            }
        }
        /// <summary>
        /// 曲线图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCurveGraph_Click(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnCurveGraph.Enabled = false;
                frmPatientProgress fpp = new frmPatientProgress(DataInit.CurrentPatient);
                fpp.groupPanel1.Visible = false;
                fpp.groupPanel2.Visible = false;

                fpp.ShowDialog();
            }
            catch
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnCurveGraph.Enabled = true;
            }
        }
        #endregion

        private void UcScreen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void groupPanel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnRecord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnEvent_Click(object sender, EventArgs e)
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

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            frmText trmptext = (frmText)panel2.Controls[0];
            DataInit.DiscussDocSave(trmptext);
        }








    }
}
