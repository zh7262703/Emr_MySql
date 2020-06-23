using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Text.RegularExpressions;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_DOCTOR.Archive
{
    public partial class ucLookSign : UserControl
    {
        private string sql = "select a.patient_name ����,(case gender_code when '1' then 'Ů' else '��' end) �Ա�,"+
                             " a.age ����,a.sick_doctor_name �ܴ�ҽ��, a.section_name ����,a.sick_area_name ����,"+
                             " b.textname ����,(case havedoctorsign when 'Y' then '��' when 'N' then '��' end) �ܴ�ҽ��ǩ��," +
                             " (case ISRAPLACEHIGHTDOCTOR when 'Y' THEN (case havehighersign when 'Y' then '��' when 'N' then '��' end)  END)�ϼ�ҽʦǩ��," +
                             " (case ISRAPLACEHIGHTDOCTOR2 when 'Y' THEN (case havehighersign when 'Y' then '��' when 'N' then '��' end) END)����ǩ��," +
                             " a.die_time,c.shortcut_code,a.name_pinyin from t_in_patient a  "+
                             " inner join t_patients_doc b on a.id = b.patient_id  "+
                             " inner join t_userinfo c on a.sick_doctor_id = c.user_id "+
                             " where ((b.ISRAPLACEHIGHTDOCTOR2='Y' and ISRAPLACEHIGHTDOCTOR2!=havehighersign)or"+
                             " (b.ISRAPLACEHIGHTDOCTOR='Y' and ISRAPLACEHIGHTDOCTOR!=havehighersign) or havedoctorsign='N')";
        public ucLookSign()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="sql">sql���</param>
        /// <param name="isvisable">�Ƿ���ʾ��ѯ</param>
        /// <param name="switchs">where ����</param>
        public ucLookSign(bool isvisable,string switchs)
        {
            InitializeComponent();
            this.gpnlSelect.Visible = isvisable;
            if (isvisable)//������
            {
                sql += " and a.section_name='" + switchs + "'";
                btnSelect_Click(this, null);
            }
            else
            {
                sql += " and patient_name='" + switchs + "'";
                InitData(sql);
            }
            flgView.fg.AfterDataRefresh += new ListChangedEventHandler(fg_AfterDataRefresh);
        }

        private void ChangeBgColor()
        {
            for (int i = 1; i < flgView.fg.Rows.Count; i++)
            {
                CellStyle cellRed = flgView.fg.Styles.Add("cellRed");
                cellRed.ForeColor = Color.Red;
                if (flgView.fg[i, "�ܴ�ҽ��ǩ��"].ToString() == "��")
                    flgView.fg.SetCellStyle(i, 8, cellRed);
                if (flgView.fg[i, "�ϼ�ҽʦǩ��"].ToString() == "��")
                    flgView.fg.SetCellStyle(i, 9, cellRed);
                if (flgView.fg[i, "����ǩ��"].ToString() == "��")
                    flgView.fg.SetCellStyle(i, 10, cellRed);
            }
        }

        void fg_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            flgView.fg.Cols["die_time"].Visible = false;
            flgView.fg.Cols["shortcut_code"].Visible = false;
            flgView.fg.Cols["name_pinyin"].Visible = false;
            ChangeBgColor();
        }
        private void InitData(string sql)
        {
            flgView.DataBd(sql, "����", "", "");
            ChangeBgColor();
            flgView.fg.Cols["die_time"].Visible = false;
            flgView.fg.Cols["shortcut_code"].Visible = false;
            flgView.fg.Cols["name_pinyin"].Visible = false;
        }

        private void txtPatient_Name_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txt = sender as TextBox;
            txt.Focus();
            txt.BackColor =SystemColors.Window;
            txt.Text = "";
        }

        private void txtPatient_Name_Leave(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrEmpty(txt.Text.Trim()))
            {
                txt.BackColor = SystemColors.Control;
                txt.Text = "��ƴ��������Ʋ�ѯ";
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(sql);
            string str1 = GetSwichs(txtPatient_Name);
            string str2 = GetSwichs(txtDoctor_Name);
            if (!string.IsNullOrEmpty(str1))
            {
                string switchs = "and name_pinyin='"+str1+"'";
                strBuilder.Append(switchs);
            }
            if (!string.IsNullOrEmpty(str2))
            {
                string switchs = "and shortcut_code='" + str2.ToUpper() + "'";
                strBuilder.Append(switchs);
            }
            string str3 = rbtnIn_Hostipal.Checked ? " and die_time is null" : "and die_time is not null";
            strBuilder.Append(str3);
            InitData(strBuilder.ToString());
        }
        private string GetSwichs(TextBox txt)
        { 
            string str = string.Empty;
            if (txt.BackColor == SystemColors.Window)
            {
                string text=txt.Text.Trim();
                Regex rg = new Regex(text);
                string reg ="[a-zA-Z]";
                Match mt = rg.Match(reg);
                if (mt.Success)
                {
                    str = text;
                }
                else
                {
                    str = App.getSpell(text).ToLower();
                }
            }

           return str;
        }
    }
}
