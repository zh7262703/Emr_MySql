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
        string tfilename; //ģ������
        string tttype;    //���µ�����

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="info"></param>
        /// <param name="templatefilename"></param>
        /// <param name="templateType">���µ�����tempetureDataComm.TEMPLATE_CHILD-�������� tempetureDataComm.TEMPLATE_NORMA-��ͨ</param>
        /// <param name="isEditer">�Ƿ�ɱ༭ true �� false ��</param>
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
                //������
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
                //�׶����µ�
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
        /// ���Զ�ͯ���µ�
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
