using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_DOCTOR
{
    public partial class frmSpecialSectionAction : DevComponents.DotNetBar.Office2007Form
    {
        private string strID;
        private string strSectionName;
        private DataSet dsSection = null;
        public frmSpecialSectionAction(string _strID,string _strSectionName)
        {
            InitializeComponent();
            this.strID = _strID;
            this.strSectionName = _strSectionName;
        }

        private void LoadSelections()
        {
            StringBuilder sb = new StringBuilder("select b.sid,c.said,b.section_code,b.section_name,c.sick_area_code,c.sick_area_name from t_section_area a,t_sectioninfo b,t_sickareainfo c");
            sb.Append(" where a.sid=b.sid and a.said=c.said and (b.section_name like '北院消化内科%' or b.section_name like '北院肿瘤内科%')");
            if (strSectionName.Contains("病室"))
            {
                string strTemp = Bifrost.App.GetDataSet(sb.ToString() + " and c.sick_area_name='" + strSectionName + "'").Tables[0].Rows[0]["section_name"].ToString();
                sb.Append("section_name like '" + strTemp.Substring(0, strTemp.Length - 2) + "%'");
                dsSection = Bifrost.App.GetDataSet(sb.ToString());
                this.comboBoxEx1.DisplayMember = "sick_area_name";
                this.comboBoxEx1.ValueMember = "sick_area_name";
                this.comboBoxEx1.DataSource = dsSection.Tables[0];
            }
            else
            {
                sb.Append(" and b.section_name like '" + strSectionName.Substring(0, strSectionName.Length - 2) + "%'");
                dsSection = Bifrost.App.GetDataSet(sb.ToString());
                this.comboBoxEx1.DisplayMember = "section_name";
                this.comboBoxEx1.ValueMember = "section_name";
                this.comboBoxEx1.DataSource = dsSection.Tables[0];
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string strCurSid=string.Empty;
            string strCurSname = string.Empty;
            string strCurSickid = string.Empty;
            string strCurSickname = string.Empty;
            DataRow[] drs = null;
            if (drs == null)
            {
                drs = dsSection.Tables[0].Select("section_name='" + comboBoxEx1.Text);
            }
            if (drs == null)
            {
                drs = dsSection.Tables[0].Select("sick_area_name='" + comboBoxEx1.Text);
            }
            if (drs == null)
                return;
            strCurSid = drs[0]["sid"].ToString();
            strCurSname = drs[0]["section_name"].ToString();
            strCurSickid = drs[0]["sick_area_id"].ToString();
            strCurSickname = drs[0]["sick_area_name"].ToString();
            if (strCurSickname == strSectionName || strSectionName == strCurSname)
            {
                Bifrost.App.Msg("同一科室无需转科！");
                return;
            }

            StringBuilder sb = new StringBuilder("Update t_in_patient Set");
            sb.Append(" section_id=" + strCurSid + ",");
            sb.Append(" section_name='"+strCurSname+"',");
            sb.Append(" sick_area_id=" + strCurSickid + ",");
            sb.Append(" sick_area_name='" + strCurSickname + "'");
            sb.Append(" where id=" + strID);
            try
            {
                Bifrost.App.ExecuteSQL(sb.ToString());
                Bifrost.App.Msg("手动转科成功！");
                this.Close();
            }
            catch
            {
                Bifrost.App.MsgErr("手动转科发生异常！");
                this.Close();
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSpecialSectionAction_Load(object sender, EventArgs e)
        {

        }
    }
}
