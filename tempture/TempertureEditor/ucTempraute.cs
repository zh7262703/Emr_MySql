using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using TempertureEditor.Tempreture_Management;

namespace TempertureEditor
{
    public partial class ucTempraute : UserControl
    {

        InPatientInfo currentPatient;
        string tfilename; //模版名称
        string tttype;    //体温单类型

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="info"></param>
        /// <param name="templatefilename"></param>
        /// <param name="templateType">体温单类型tempetureDataComm.TEMPLATE_CHILD-新生儿、 tempetureDataComm.TEMPLATE_NORMA-普通</param>
        /// <param name="isEditer">是否可编辑 true 可 false 否</param>
        public ucTempraute(InPatientInfo info, string templateType, bool isEditer)
        {
            InitializeComponent();
            currentPatient = info;
            string templatefilename = tempetureDataComm.GetTemplateFileByType(templateType);
            tfilename = templatefilename;
            tttype = templateType;




            radioButton_Edit.Enabled = false;
            if (isEditer)
            {
                radioButton_Print.Checked = false;
                radioButton_Edit.Enabled = true;
                radioButton_Edit.Checked = true;
            }
            else
            {
                radioButton_Print.Checked = true;
                radioButton_Edit.Enabled = false;
            }

        }

        private void radioButton_Edit_CheckedChanged(object sender, EventArgs e)
        {
            groupPanel2.Controls.Clear();

            if (tttype == tempetureDataComm.TEMPLATE_CHILD)
            {
                //新生儿
                if (radioButton_Edit.Checked)
                {
                    ucTempratureDataLoad_child uc = new ucTempratureDataLoad_child(currentPatient, tfilename);
                    uc.Dock = DockStyle.Fill;
                    App.UsControlStyle(uc);
                    groupPanel2.Controls.Add(uc);
                }
                else
                {
                    ucTemperPrintDataLoad_child uc = new ucTemperPrintDataLoad_child(currentPatient, tfilename);
                    uc.Dock = DockStyle.Fill;
                    App.UsControlStyle(uc);
                    groupPanel2.Controls.Add(uc);

                }
            }
            else if (tttype == tempetureDataComm.TEMPLATE_NORMAL || tttype == tempetureDataComm.TEMPLATE_BABY)
            {
                //幼儿体温单
                if (radioButton_Edit.Checked)
                {
                    ucTempratureDataLoad uc = new ucTempratureDataLoad(currentPatient, tfilename);
                    uc.Dock = DockStyle.Fill;
                    App.UsControlStyle(uc);
                    groupPanel2.Controls.Add(uc);
                }
                else
                {
                    ucTemperPrintDataLoad uc = new ucTemperPrintDataLoad(currentPatient, tfilename);
                    uc.Dock = DockStyle.Fill;
                    App.UsControlStyle(uc);
                    groupPanel2.Controls.Add(uc);

                }
            }
        }

        private void ucTempraute_Load(object sender, EventArgs e)
        {
            radioButton_Edit_CheckedChanged(sender, e);
        }

        /// <summary>
        /// 测试儿童体温单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void radioButton_Print_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
