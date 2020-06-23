using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class frmScoreResults : DevComponents.DotNetBar.Office2007Form
    {
        string patient_id = "";
        string pid = "";
        string pName = "";
        string operatorName = "";
        string score = "";
        string grade = "";
        string content = "";

        public frmScoreResults()
        {
            InitializeComponent();
        }

        public frmScoreResults(string strPatientId,string strPid,string strPName,string strOperatorName,string strScore,string strGrade,string strContent)
        {
            InitializeComponent();

            patient_id = strPatientId;
            pid = strPid;
            pName = strPName;
            operatorName = strOperatorName;
            score = strScore;
            grade = strGrade;
            content = strContent;
        }

        private void frmScoreResults_Load(object sender, EventArgs e)
        {
            lblPid.Text = pid;
            lblPName.Text = pName;
            lblOperatorName.Text = operatorName;
            lblScore.Text = score;
            lblGrade.Text = grade;
            rtxRemarks.Text = content;
        }
    }
}
