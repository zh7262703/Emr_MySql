using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    /// <summary>
    /// ����ߣ���ΰ
    /// ʱ  �䣺2017/02/26
    /// </summary>
    public partial class FrmMedicalRecord : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// סԺ��
        /// </summary>
        string pid = "";
        /// <summary>
        /// Ĭ�Ϲ�����
        /// </summary>
        public FrmMedicalRecord()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="Pid">סԺ��</param>
        public FrmMedicalRecord(string Pid,string id)
        {
            InitializeComponent();
            pid = Pid;
            //���
            UcCodeDiagnose ucCodeDiagnose = new UcCodeDiagnose(pid);
            tabControlPanel9.Controls.Add(ucCodeDiagnose);
            ucCodeDiagnose.Dock = DockStyle.Fill;
            App.UsControlStyle(ucCodeDiagnose);
            //����
            UcCodeOperation ucCodeOperation = new UcCodeOperation(pid);
            tabControlPanel6.Controls.Add(ucCodeOperation);
            ucCodeOperation.Dock = DockStyle.Fill;
            App.UsControlStyle(ucCodeOperation);

            bool sqc = false;
            bool fgs = false;
            InPatientInfo inPatient = DataInit.GetInpatientInfoByPid(id);

            ucDocs fq = new ucDocs(inPatient, "Y");
            tabControlPanel1.Controls.Add(fq);
            fq.Dock = DockStyle.Fill;
         

            BLL_DOCTOR.HisInStance.ҽ����.frmYzd frm = new Base_Function.BLL_DOCTOR.HisInStance.ҽ����.frmYzd(inPatient, sqc, fgs);
            tabControlPanel2.Controls.Add(frm);
            frm.Dock = DockStyle.Fill;
            //App.UsControlStyle(frm);

            BLL_DOCTOR.HisInStance.LIS.UcLis uc = new Base_Function.BLL_DOCTOR.HisInStance.LIS.UcLis(inPatient, sqc, fgs);
            tabControlPanel3.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            //App.UsControlStyle(uc);

            BLL_DOCTOR.HisInStance.PACS.ucPasc ucp = new Base_Function.BLL_DOCTOR.HisInStance.PACS.ucPasc(inPatient, sqc, fgs);
            tabControlPanel4.Controls.Add(ucp);
            ucp.Dock = DockStyle.Fill;


            DataInit.O_Edite = false;
            DataInit.O_UpOrNext = false;
            DataInit.D_UpOrNext = false;
            DataInit.D_Edite = false;
        }
        /// <summary>
        /// �ύ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_tj_Click(object sender, EventArgs e)
        {
            DataInit.A_btnSave_Operation(sender, e);
            DataInit.A_btnSave(sender, e);
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            if (DataInit.D_Edite == true || DataInit.D_UpOrNext == true || DataInit.O_Edite == true || DataInit.O_UpOrNext == true)
            {
                if (App.Ask("��Ŀ��Ϣ�������ı��Ƿ�����رգ�"))
                {
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            DataInit.A_UP(sender, e);
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            DataInit.A_Next(sender, e);
        }

        private void btn_upOperation_Click(object sender, EventArgs e)
        {
            DataInit.A_UP_(sender, e);
        }

        private void btn_nextoperation_Click(object sender, EventArgs e)
        {
            DataInit.A_Next_(sender, e);
        }

        private void tabItem8_Click(object sender, EventArgs e)
        {
            btn_nextoperation.Visible = true;
            btn_upOperation.Visible = true;
        }

        private void tabItem7_Click(object sender, EventArgs e)
        {
            btn_nextoperation.Visible = false;
            btn_upOperation.Visible = false;
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            btn_nextoperation.Visible = false;
            btn_upOperation.Visible = false;

        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            btn_nextoperation.Visible = false;
            btn_upOperation.Visible = false;
        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
            btn_nextoperation.Visible = false;
            btn_upOperation.Visible = false;
        }
    }
}