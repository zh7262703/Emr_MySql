using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Bifrost;
using System.Reflection;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;

namespace Base_Function.TEMPERATURES
{
    public partial class frmTemperPrint : Office2007Form
    {

        /// <summary>
        /// ��������
        /// </summary>
        public frmTemperPrint()
        {
            InitializeComponent();

            App.Ini();
            //ucTemperPrint uc1 = new ucTemperPrint();

            //0000172392   1520  02  ФԪ�� 0 55�� ���ƶ����� 2012-12-30 10:58:33
            //0000176395,1134,01,��ˮ��,0,68��,ICU����,ICU����,2013-01-08 10:41:19
            //ucTemperPrint uc1 = new ucTemperPrint("0000176395", "1134", "01", "��ˮ��", "0", "68��", "ICU����", "ICU����", "2013-01-08 10:41:19","��״��������Ӳ��");          
            //uc1.Dock = DockStyle.Fill;
            //this.Controls.Add(uc1);
        }       

        /// <summary>
        /// ��ͨ���µ���ӡ���캯��
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="bedNo">����</param>
        /// <param name="sex">�Ա�</param>
        /// <param name="in_time">����ʱ��</param>
        /// <param name="pid">סԺ��</param>
        public frmTemperPrint(InPatientInfo currentPatient)//string pid, string medicare_no, string id, string bedNo, string name, string sex, string age, string section, string ward, string in_time)
        {
            InitializeComponent();
           // ucTemperPrintDataLoad uc1 = new ucTemperPrintDataLoad(currentPatient);//pid,medicare_no, id, bedNo, name, sex, age, section, ward, in_time, "");
           // uc1.Dock = DockStyle.Fill;
           // this.Controls.Add(uc1);
        }

        /// <summary>
        /// ��ͨ���µ���ӡ���캯��
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="bedNo">����</param>
        /// <param name="sex">�Ա�</param>
        /// <param name="in_time">����ʱ��</param>
        /// <param name="pid">סԺ��</param>
        
        //public frmTemperPrint(string pid, string id, string bedNo, string name, string sex, string age, string section, string ward, string in_time,string out_time)
        //{
        //    InitializeComponent();
        //    ucTemperPrint uc1 = new ucTemperPrint(pid, id, bedNo, name, sex, age, section, ward, in_time, out_time);
        //    uc1.Dock = DockStyle.Fill;
        //    this.Controls.Add(uc1);
        //}

        private void frmTemperPrint_Load(object sender, EventArgs e)
        {

        }
    }
}