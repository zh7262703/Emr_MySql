using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.First_cases
{
    /// <summary>
    /// ѹ����ҳ�ı༭
    /// ����:������
    /// ʱ��:2013-01-30
    /// </summary>
    public partial class ucCover_Append_PS : UserControl
    {
        private string PatientId = "";           //��ǰ���˵�����
        private string Cover_Append_id = "";   //��ǰѡ�е�סԺ��ҳ������
        private string option = "-��ѡ��-";    //������ѡֵ
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patientid">��������</param>
        public ucCover_Append_PS(string patientid)
        {
            InitializeComponent();
            PatientId = patientid;
            iniSelectValues();
        }


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patientid">��������</param>
        /// <param name="cover_append_id">סԺ��ҳ������</param>
        public ucCover_Append_PS(string patientid, string cover_append_id)
        {
            InitializeComponent();
            PatientId = patientid;
            Cover_Append_id = cover_append_id;
            iniSelectValues();
            if (Cover_Append_id != "")
            {
                //����ҳ���Ѿ�д���ĸ�ҳ
                iniData(cover_append_id);

            }

        }

        /// <summary>
        /// ��ʼ��ֵ
        /// </summary>
        private void iniSelectValues()
        {
            try
            {
                //����ѹ������
                DataSet ds_PS_LEVEL = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='HZYCJB001'");
                //����ѹ������
                DataSet ds_PS_LEVEL2 = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='HZYCJB001'");
                
                //����ѹ����Դ
                DataSet ds_SOURCE = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='HZYCLY001'");
                //ѹ��������λ
                DataSet ds_PARTS = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='YCFSBW001'");

                DataRow dr_PS_LEVEL = ds_PS_LEVEL.Tables[0].NewRow();
                dr_PS_LEVEL["name"] = option;
                dr_PS_LEVEL["id"] = "-1";
                ds_PS_LEVEL.Tables[0].Rows.InsertAt(dr_PS_LEVEL, 0);
                cboPS_LEVEL.DataSource = ds_PS_LEVEL.Tables[0].DefaultView;
                cboPS_LEVEL.DisplayMember = "name";
                cboPS_LEVEL.ValueMember = "id";
                
                DataRow dr_PS_LEVEL2 = ds_PS_LEVEL2.Tables[0].NewRow();
                dr_PS_LEVEL2["name"] = option;
                dr_PS_LEVEL2["id"] = "-1";
                ds_PS_LEVEL2.Tables[0].Rows.InsertAt(dr_PS_LEVEL2, 0);
                cboPS_LEVEL2.DataSource = ds_PS_LEVEL2.Tables[0].DefaultView;
                cboPS_LEVEL2.DisplayMember = "name";
                cboPS_LEVEL2.ValueMember = "id";

                DataRow dr_SOURCE = ds_SOURCE.Tables[0].NewRow();
                dr_SOURCE["name"] = option;
                dr_SOURCE["id"] = "-1";
                ds_SOURCE.Tables[0].Rows.InsertAt(dr_SOURCE, 0);
                cboSOURCE.DataSource = ds_SOURCE.Tables[0].DefaultView;
                cboSOURCE.DisplayMember = "name";
                cboSOURCE.ValueMember = "id";

                
                chkPARTS.DataSource = ds_PARTS.Tables[0].DefaultView;
                chkPARTS.DisplayMember = "name";
                chkPARTS.ValueMember = "id";

               
            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ��,ԭ��:"+ex.Message);
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        public bool SaveData()
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }

                string PS_TIME = "";            //ѹ����
                if (rdoPS_TIME_GZR.Checked)
                {
                    PS_TIME = "1";
                }
                else if (rdoPS_TIME_ZM.Checked)
                {
                    PS_TIME = "2";
                }
                else if (rdoPS_TIME_JJR.Checked)
                {
                    PS_TIME = "3";
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label1.Text + "]δѡ��!");
                    return false;
                }

                string PS_DETIAL_TIEM = dtpPS_DETIAL_TIEM.Value.ToString("yyyy/MM/dd HH:mm:ss");     //���巢������ʱ��

                string IS_CRISI_PATIENT = "";   //��Ժʱ����Ϊ�߷��ջ���
                if (rdoIS_CRISI_PATIENT_N.Checked)
                {
                    IS_CRISI_PATIENT = "N";
                }
                else if (rdoIS_CRISI_PATIENT_Y.Checked)
                {
                    IS_CRISI_PATIENT = "Y";
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label3.Text + "]δѡ��!");
                    return false;
                }

                string CRISI_SCORE = "";        //ѹ��Σ�س̶�����
                if (txtCRISI_SCORE.Text.Trim()!="")
                {
                    CRISI_SCORE = txtCRISI_SCORE.Text;
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label4.Text + "]δ��д!");
                    return false;
                }

                string PS_TYPE = "";            //ѹ����Դ����
                string PS_LEVEL = "";           //ѹ������
                string SOURCE = "";             //����ѹ����Դ�������ֵ���룩
                
                
                string PS_TYPE2 = "";            //ѹ����Դ����
                string PS_LEVEL2 = "";           //ѹ������
                string IS_MOREPART = "";        //�Ƿ����ಿλѹ����� Y �� N ��
                string PARTS = "";              //������λ
                if (chkPS_TYPE_in.Checked == true || chkPS_TYPE_on.Checked == true)
                {
                    if (chkPS_TYPE_in.Checked)
                    {//��Ժǰ
                        PS_TYPE = "Y";
                                   //ѹ������
                        if (cboPS_LEVEL.SelectedValue != null && cboPS_LEVEL.Text != option)
                        {
                            PS_LEVEL = cboPS_LEVEL.SelectedValue.ToString();
                        }
                        else if (cboPS_LEVEL.Items.Count > 1)
                        {
                            label10.ForeColor = Color.Red;
                            App.Msg("��ʾ:[" + label10.Text + "]δѡ��!");
                            return false;
                        }
                        //ѹ����Դ
                        if (cboSOURCE.SelectedValue != null && cboSOURCE.Text != option)
                        {
                            SOURCE = cboSOURCE.SelectedValue.ToString();
                        }
                        else if (cboSOURCE.Items.Count > 1)
                        {
                            label6.ForeColor = Color.Red;
                            App.Msg("��ʾ:[" + label6.Text + "]δѡ��!");
                            return false;
                        }

                    }
                    if (chkPS_TYPE_on.Checked)
                    {//��Ժ��
                        PS_TYPE2 = "Y";
                        if (cboPS_LEVEL2.SelectedValue != null && cboPS_LEVEL2.Text != option)
                        {
                            PS_LEVEL2 = cboPS_LEVEL2.SelectedValue.ToString();
                        }
                        else if (cboPS_LEVEL2.Items.Count > 1)
                        {
                            label11.ForeColor = Color.Red;
                            App.Msg("��ʾ:[" + label11.Text + "]δѡ��!");
                            return false;
                        }

                        //�Ƿ����ಿλ
                        if (rdoIS_MOREPART_N.Checked)
                        {
                            IS_MOREPART = "N";
                        }
                        else if (rdoIS_MOREPART_Y.Checked)
                        {
                            IS_MOREPART = "Y";
                        }
                        else
                        {
                            label8.ForeColor = Color.Red;
                            App.Msg("��ʾ:[" + label8.Text + "]δѡ��!");
                            return false;
                        }
                        //������λ
                        if (chkPARTS.Items.Count > 0 && chkPARTS.CheckedItems.Count == 0)
                        {
                            label7.ForeColor = Color.Red;
                            App.Msg("��ʾ:[" + label7.Text + "]δѡ��!");
                            return false;
                        }
                        for (int i = 0; i < chkPARTS.CheckedItems.Count; i++)
                        {

                            DataRowView temp = (DataRowView)chkPARTS.CheckedItems[i];
                            if (PARTS == "")
                            {
                                PARTS = temp["id"].ToString();
                            }
                            else
                            {
                                PARTS = PARTS + "," + temp["id"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    label5.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label5.Text + "]δѡ��!");
                    return false;
                }

                string Sql = "";
                //if (PS_TIME != "" && PS_DETIAL_TIEM != "" && IS_CRISI_PATIENT != "" && CRISI_SCORE != "" && PS_TYPE != "" && PS_LEVEL != "" && SOURCE != "" && PARTS != "" && IS_MOREPART != "")
                
                if (Cover_Append_id == "")
                {
                    Sql = "insert into COVER_APPEND_PS(PATIENT_ID,PS_TIME,PS_DETIAL_TIEM,IS_CRISI_PATIENT," +
                                                            "CRISI_SCORE,PS_TYPE,PS_LEVEL,SOURCE,PARTS,IS_MOREPART," +
                                                            "CREATE_TIME,USER_ID,PS_TYPE_ON,PS_LEVEL_ON)values({0},'{1}'" +
                                                            ",to_timestamp('{2}','syyyy-mm-dd hh24:mi:ss')" +
                                                            ",'{3}','{4}','{5}','{6}','{7}','{8}','{9}'," +
                                                            "to_timestamp('{10}','syyyy-mm-dd hh24:mi'),{11},'{12}','{13}')";

                    Sql = string.Format(Sql, PatientId, PS_TIME, PS_DETIAL_TIEM, IS_CRISI_PATIENT,
                                            CRISI_SCORE, PS_TYPE, PS_LEVEL, SOURCE, PARTS, IS_MOREPART,
                                            App.GetSystemTime().ToShortDateString(),
                                            App.UserAccount.UserInfo.User_id, PS_TYPE2, PS_LEVEL2);
                }
                else
                {
                    Sql = "update COVER_APPEND_PS set PS_TIME='{0}',PS_DETIAL_TIEM=to_timestamp('{1}','syyyy-mm-dd hh24:mi:ss')," +
                                                            "IS_CRISI_PATIENT='{2}',CRISI_SCORE='{3}',PS_TYPE='{4}',PS_LEVEL='{5}'," +
                                                            "SOURCE='{6}',PARTS='{7}',IS_MOREPART='{8}',PS_TYPE_ON='{9}',PS_LEVEL_ON='{10}' " +
                                                            " where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";
                    Sql = string.Format(Sql, PS_TIME, PS_DETIAL_TIEM, IS_CRISI_PATIENT,
                                            CRISI_SCORE, PS_TYPE, PS_LEVEL, SOURCE, PARTS, IS_MOREPART, PS_TYPE2, PS_LEVEL2);
                }
                if (App.ExecuteSQL(Sql) > 0)
                {
                    App.Msg("����ɹ�!");
                    return true;
                }
                else
                {
                    App.MsgErr("����ʧ��!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ��,ԭ��:" + ex.Message);
                return false;
            }
	
        }

        /// <summary>
        /// ��ʼ��ѹ����ҳ��Ϣ
        /// </summary>
        /// <param name="Cover_Append_id">��ҳ������</param>
        private void iniData(string Cover_Append_id)
        {
            try 
	        {
                string sql = "select PS_TIME,to_char(PS_DETIAL_TIEM,'YYYY/MM/DD HH24:MI:ss') as PS_DETIAL_TIEM,IS_CRISI_PATIENT,"+
                                    "CRISI_SCORE,PS_TYPE,PS_LEVEL,SOURCE,PARTS,IS_MOREPART,PS_TYPE_ON,PS_LEVEL_ON" +
                                    " from COVER_APPEND_PS where id=" + Cover_Append_id;
                                    
                DataTable dt = App.GetDataSet(sql).Tables[0];
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //--------------------------------ѹ��-----------------------------------------------
                        if (dt.Rows[i]["PS_TIME"].ToString().Trim() != "")       //ѹ����
                        {
                            if (dt.Rows[i]["PS_TIME"].ToString()=="2")
                            {
                                rdoPS_TIME_ZM.Checked = true;
                            }
                            else if (dt.Rows[i]["PS_TIME"].ToString() == "3")
                            {
                                rdoPS_TIME_JJR.Checked = true;
                            }
                            else
                            {
                                rdoPS_TIME_GZR.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["PS_DETIAL_TIEM"].ToString().Trim() != "")       //���巢������ʱ��
                        {
                            dtpPS_DETIAL_TIEM.Text = dt.Rows[i]["PS_DETIAL_TIEM"].ToString();
                        }
                        //��Ժʱ����Ϊ�߷��ջ���Y �� N ��
                        if (dt.Rows[i]["IS_CRISI_PATIENT"].ToString().Trim() != "")       
                        {
                            if (dt.Rows[i]["IS_CRISI_PATIENT"].ToString() == "Y")
                            {
                                rdoIS_CRISI_PATIENT_Y.Checked = true;
                            }
                            else
                            {
                                rdoIS_CRISI_PATIENT_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["CRISI_SCORE"].ToString().Trim() != "")       //ѹ��Σ�س̶�����
                        {
                            txtCRISI_SCORE.Text = dt.Rows[i]["CRISI_SCORE"].ToString();
                        }

                        if (dt.Rows[i]["PS_TYPE"].ToString().Trim() != "")       //ѹ����Դ����
                        {
                            chkPS_TYPE_in.Checked = true;
                            if (dt.Rows[i]["PS_LEVEL"].ToString().Trim() != "")       //ѹ������
                            {
                                cboPS_LEVEL.SelectedValue = dt.Rows[i]["PS_LEVEL"].ToString();
                            }

                            if (dt.Rows[i]["SOURCE"].ToString().Trim() != "")       //����ѹ����Դ�������ֵ���룩
                            {
                                cboSOURCE.SelectedValue = dt.Rows[i]["SOURCE"].ToString();
                            }
                        }

                        
                        if (dt.Rows[i]["PS_TYPE_ON"].ToString().Trim() != "")       //סԺ�䷢��ѹ�� Y �� null ��
                        {
                            chkPS_TYPE_on.Checked = true;
                            if (dt.Rows[i]["PS_LEVEL_ON"].ToString().Trim() != "")       //����ѹ������
                            {
                                cboPS_LEVEL2.SelectedValue = dt.Rows[i]["PS_LEVEL_ON"].ToString();
                            }


                            if (dt.Rows[i]["PARTS"].ToString().Trim() != "")       //������λ
                            {

                                string[] vals = dt.Rows[i]["PARTS"].ToString().Split(',');
                                for (int i1 = 0; i1 < vals.Length; i1++)
                                {
                                    for (int j = 0; j < chkPARTS.Items.Count; j++)
                                    {
                                        DataRowView temp = (DataRowView)chkPARTS.Items[j];
                                        if (temp["id"].ToString() == vals[i1])
                                        {
                                            chkPARTS.SetItemChecked(j, true);
                                        }
                                    }
                                }
                            }

                            if (dt.Rows[i]["IS_MOREPART"].ToString().Trim() != "")       //�Ƿ����ಿλѹ����� Y �� N ��
                            {
                                if (dt.Rows[i]["IS_MOREPART"].ToString() == "Y")
                                {
                                    rdoIS_MOREPART_Y.Checked = true;
                                }
                                else
                                {
                                    rdoIS_MOREPART_N.Checked = true;
                                }
                            }
                        }

                    }
                }
	        }
	        catch (Exception ex)
	        {
                App.MsgErr("����ʧ��,ԭ��:"+ex.Message);
	        }
        }

        /// <summary>
        /// ֻ�����������ֺ�С����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Delete)
            {
                if ((sender as TextBox).Text.Split('.').Length >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// ֻ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Back)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

       

        /// <summary>
        /// ��Ժǰ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPS_TYPE_in_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPS_TYPE_in.Checked)
                plPS_TYPE_in.Enabled = true;
            else
            {
                plPS_TYPE_in.Enabled = false;
                cboPS_LEVEL.SelectedIndex = 0;
                cboSOURCE.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// ��Ժ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPS_TYPE_on_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPS_TYPE_on.Checked)
                plPS_TYPE_on.Enabled = true;
            else
            {
                plPS_TYPE_on.Enabled = false;
                cboPS_LEVEL2.SelectedIndex = 0;
                rdoIS_MOREPART_Y.Checked = false;
                rdoIS_MOREPART_N.Checked = false;
                foreach (int i in chkPARTS.CheckedIndices)
                {
                    chkPARTS.SetItemChecked(i, false);
                }
            }
        }
    
    }
}
