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
    /// �����ظ�ҳ�ı༭
    /// ����:������
    /// ʱ��:2013-01-29
    /// </summary>
    public partial class ucCover_Append_ANTIBIOTICS : UserControl
    {

        private string PatientId = "";           //��ǰ���˵�����
        private string Cover_Append_id = "";   //��ǰѡ�е�סԺ��ҳ������
        private string option = "-��ѡ��-";    //������ѡֵ
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patientid">��������</param>
        public ucCover_Append_ANTIBIOTICS(string patientid)
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
        public ucCover_Append_ANTIBIOTICS(string patientid, string cover_append_id)
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
        /// ��ʼ��һЩ����ѡ�����ֵ
        /// </summary>
        private void iniSelectValues()
        {
            try
            {
                //������ҩ��;
                DataSet ds_U = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='KJYYYT001'");
                //����ҩ������
                DataSet ds_N = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='KJYWMC001'");
                //����ҩ�Ｖ��
                DataSet ds_L = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='KJYWJB001'");
                //����ҩ������
                DataSet ds_TY = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='KJYWLX001'");
                //��ԭѧ���걾
                DataSet ds_BYX = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='BYXJCBB001'");
                //΢��������
                DataSet ds_WSW = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='WSWJCJG001'");

                DataRow dr_U = ds_U.Tables[0].NewRow();
                dr_U["name"] = option;
                dr_U["id"] = "-1";
                ds_U.Tables[0].Rows.InsertAt(dr_U, 0);
                cboANTIBACTERIAL_DRUGS_U.DataSource = ds_U.Tables[0].DefaultView;
                cboANTIBACTERIAL_DRUGS_U.DisplayMember = "name";
                cboANTIBACTERIAL_DRUGS_U.ValueMember = "id";

                DataRow dr_N = ds_N.Tables[0].NewRow();
                dr_N["name"] = option;
                dr_N["id"] = "-1";
                ds_N.Tables[0].Rows.InsertAt(dr_N, 0);
                cboANTIBACTERIAL_DRUGS_N.DataSource = ds_N.Tables[0].DefaultView;
                cboANTIBACTERIAL_DRUGS_N.DisplayMember = "name";
                cboANTIBACTERIAL_DRUGS_N.ValueMember = "id";

                DataRow dr_L = ds_L.Tables[0].NewRow();
                dr_L["name"] = option;
                dr_L["id"] = "-1";
                ds_L.Tables[0].Rows.InsertAt(dr_L, 0);
                cboANTIBACTERIAL_DRUGS_L.DataSource = ds_L.Tables[0].DefaultView;
                cboANTIBACTERIAL_DRUGS_L.DisplayMember = "name";
                cboANTIBACTERIAL_DRUGS_L.ValueMember = "id";

                DataRow dr_TY = ds_TY.Tables[0].NewRow();
                dr_TY["name"] = option;
                dr_TY["id"] = "-1";
                ds_TY.Tables[0].Rows.InsertAt(dr_TY, 0);
                cboANTIBACTERIAL_DRUGS_TY.DataSource = ds_TY.Tables[0].DefaultView;
                cboANTIBACTERIAL_DRUGS_TY.DisplayMember = "name";
                cboANTIBACTERIAL_DRUGS_TY.ValueMember = "id";

                DataRow dr_BYX = ds_BYX.Tables[0].NewRow();
                dr_BYX["name"] = option;
                dr_BYX["id"] = "-1";
                ds_BYX.Tables[0].Rows.InsertAt(dr_BYX, 0);
                cboP_D_SPECIMENS.DataSource = ds_BYX.Tables[0].DefaultView;
                cboP_D_SPECIMENS.DisplayMember = "name";
                cboP_D_SPECIMENS.ValueMember = "id";

                DataRow dr_WSW = ds_WSW.Tables[0].NewRow();
                dr_WSW["name"] = option;
                dr_WSW["id"] = "-1";
                ds_WSW.Tables[0].Rows.InsertAt(dr_WSW, 0);
                cboMICROBE_DETECTION.DataSource = ds_WSW.Tables[0].DefaultView;
                cboMICROBE_DETECTION.DisplayMember = "name";
                cboMICROBE_DETECTION.ValueMember = "id";


            }
            catch (Exception ex)
            {
                App.MsgErr("��ʼ������ѡ����ʧ��,ԭ��:" + ex.Message);
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

                string ANTIBACTERIAL_DRUGS_T = "";        //����ҩ��Ŀ��
                if (rdoANTIBACTERIAL_DRUGS_T_YF.Checked)
                {
                    ANTIBACTERIAL_DRUGS_T = "1";
                }
                else if (rdoANTIBACTERIAL_DRUGS_T_ZL.Checked)
                {
                    ANTIBACTERIAL_DRUGS_T = "2";
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label1.Text + "]δѡ��!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_C = "";         //����ҩ�﷽��
                if (rdoANTIBACTERIAL_DRUGS_C_DD.Checked)
                {
                    ANTIBACTERIAL_DRUGS_C = "1";
                }
                else if (rdoANTIBACTERIAL_DRUGS_C_LH.Checked)
                {
                    ANTIBACTERIAL_DRUGS_C = "2";
                }
                else
                {
                    label2.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label2.Text + "]δѡ��!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_U = "";         //����ҩ����;
                if (cboANTIBACTERIAL_DRUGS_U.SelectedValue != null && cboANTIBACTERIAL_DRUGS_U.Text!=option)
                {
                    ANTIBACTERIAL_DRUGS_U = cboANTIBACTERIAL_DRUGS_U.SelectedValue.ToString();
                }
                else if (cboANTIBACTERIAL_DRUGS_U.Items.Count > 1)
                {
                    label3.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label3.Text + "]δѡ��!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_TI = "";        //����ҩ��ʱ��
                if (txtANTIBACTERIAL_DRUGS_TI.Text.Trim()!="")
                {
                    ANTIBACTERIAL_DRUGS_TI = txtANTIBACTERIAL_DRUGS_TI.Text;
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label4.Text + "]δ��д!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_D = "";         //����ҩ������
                if (txtANTIBACTERIAL_DRUGS_D.Text.Trim()!="")
                {
                    ANTIBACTERIAL_DRUGS_D = txtANTIBACTERIAL_DRUGS_D.Text;
                }
                else
                {
                    label5.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label5.Text + "]δ��д!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_CO = "";         //����ҩ����
                if (txtANTIBACTERIAL_DRUGS_CO.Text.Trim()!="")
                {
                    ANTIBACTERIAL_DRUGS_CO = txtANTIBACTERIAL_DRUGS_CO.Text;
                }
                else
                {
                    label6.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label6.Text + "]δ��д!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_N = "";          //����ҩ������
                if (cboANTIBACTERIAL_DRUGS_N.SelectedValue != null && cboANTIBACTERIAL_DRUGS_N.Text != option)
                {
                    ANTIBACTERIAL_DRUGS_N = cboANTIBACTERIAL_DRUGS_N.SelectedValue.ToString();
                }
                else if (cboANTIBACTERIAL_DRUGS_N.Items.Count > 1)
                {
                    label7.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label7.Text + "]δѡ��!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_L = "";          //����ҩ����
                if (cboANTIBACTERIAL_DRUGS_L.SelectedValue != null && cboANTIBACTERIAL_DRUGS_L.Text != option)
                {
                    ANTIBACTERIAL_DRUGS_L = cboANTIBACTERIAL_DRUGS_L.SelectedValue.ToString();
                }
                else if (cboANTIBACTERIAL_DRUGS_L.Items.Count > 1)
                {
                    label8.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label8.Text + "]δѡ��!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_TY = "";         //����ҩ����
                if (cboANTIBACTERIAL_DRUGS_TY.SelectedValue != null && cboANTIBACTERIAL_DRUGS_TY.Text != option)
                {
                    ANTIBACTERIAL_DRUGS_TY = cboANTIBACTERIAL_DRUGS_TY.SelectedValue.ToString();
                }
                else if (cboANTIBACTERIAL_DRUGS_TY.Items.Count > 1)
                {
                    label9.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label9.Text + "]δѡ��!");
                    return false;
                }

                string ID_IATROGENIC_DETECTION = "";        //�Ƿ�ҽԴ�Լ�� �� Y �� N
                if (rdoID_IATROGENIC_DETECTION_Y.Checked)
                {
                    ID_IATROGENIC_DETECTION = "Y";
                }
                else if (rdoID_IATROGENIC_DETECTION_N.Checked)
                {
                    ID_IATROGENIC_DETECTION = "N";
                }
                else
                {
                    label10.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label10.Text + "]δѡ��!");
                    return false;
                }

                string P_D_SPECIMENS = "";                  //��ԭѧ���걾
                if (cboP_D_SPECIMENS.SelectedValue != null && cboP_D_SPECIMENS.Text != option)
                {
                    P_D_SPECIMENS = cboP_D_SPECIMENS.SelectedValue.ToString();
                }
                else if (cboP_D_SPECIMENS.Items.Count > 1)
                {
                    label11.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label11.Text + "]δѡ��!");
                    return false;
                }

                string MICROBE_DETECTION = "";              //΢��������
                if (cboMICROBE_DETECTION.SelectedValue != null && cboMICROBE_DETECTION.Text != option)
                {
                    MICROBE_DETECTION = cboMICROBE_DETECTION.SelectedValue.ToString();
                }
                else if (cboMICROBE_DETECTION.Items.Count > 1)
                {
                    label12.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label12.Text + "]δѡ��!");
                    return false;
                }

                string Sql = "";
                if (Cover_Append_id =="")
                {
                    Sql = "insert into COVER_APPEND_ANTIBIOTICS(PATIENT_ID,ANTIBACTERIAL_DRUGS_T,ANTIBACTERIAL_DRUGS_C,"+
                                                                "ANTIBACTERIAL_DRUGS_U,ANTIBACTERIAL_DRUGS_TI,ANTIBACTERIAL_DRUGS_D,"+
                                                                "ANTIBACTERIAL_DRUGS_CO,ANTIBACTERIAL_DRUGS_N,ANTIBACTERIAL_DRUGS_L,"+
                                                                "ANTIBACTERIAL_DRUGS_TY,ID_IATROGENIC_DETECTION,P_D_SPECIMENS,"+
                                                                "MICROBE_DETECTION,CREATE_TIME,USER_ID)values({0},'{1}','{2}','{3}',"+
                                                                "'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',"+
                                                                "to_timestamp('{13}','syyyy-mm-dd hh24:mi'),{14})";
                    Sql = string.Format(Sql,PatientId,ANTIBACTERIAL_DRUGS_T,ANTIBACTERIAL_DRUGS_C,
                                            ANTIBACTERIAL_DRUGS_U,ANTIBACTERIAL_DRUGS_TI,ANTIBACTERIAL_DRUGS_D,
                                            ANTIBACTERIAL_DRUGS_CO,ANTIBACTERIAL_DRUGS_N,ANTIBACTERIAL_DRUGS_L,
                                            ANTIBACTERIAL_DRUGS_TY,ID_IATROGENIC_DETECTION,P_D_SPECIMENS,
                                            MICROBE_DETECTION, App.GetSystemTime().ToShortDateString(),
                                            App.UserAccount.UserInfo.User_id);
                }
                else
                {
                    Sql = "update COVER_APPEND_ANTIBIOTICS set ANTIBACTERIAL_DRUGS_T='{0}',ANTIBACTERIAL_DRUGS_C='{1}'," +
                                            "ANTIBACTERIAL_DRUGS_U='{2}',ANTIBACTERIAL_DRUGS_TI='{3}',ANTIBACTERIAL_DRUGS_D='{4}'," +
                                            "ANTIBACTERIAL_DRUGS_CO='{5}',ANTIBACTERIAL_DRUGS_N='{6}',ANTIBACTERIAL_DRUGS_L='{7}'," +
                                            "ANTIBACTERIAL_DRUGS_TY='{8}',ID_IATROGENIC_DETECTION='{9}',P_D_SPECIMENS='{10}'," +
                                            "MICROBE_DETECTION='{11}' where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";
                                            
                    Sql = string.Format(Sql,ANTIBACTERIAL_DRUGS_T,ANTIBACTERIAL_DRUGS_C,
                                            ANTIBACTERIAL_DRUGS_U,ANTIBACTERIAL_DRUGS_TI,ANTIBACTERIAL_DRUGS_D,
                                            ANTIBACTERIAL_DRUGS_CO,ANTIBACTERIAL_DRUGS_N,ANTIBACTERIAL_DRUGS_L,
                                            ANTIBACTERIAL_DRUGS_TY,ID_IATROGENIC_DETECTION,P_D_SPECIMENS,
                                            MICROBE_DETECTION);
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
        /// ��ʼ��������ҳ��Ϣ
        /// </summary>
        /// <param name="Cover_Append_id">��ҳ������</param>
        private void iniData(string Cover_Append_id)
        {
            try
            {
                string sql = "select ANTIBACTERIAL_DRUGS_T,ANTIBACTERIAL_DRUGS_C,"+
                                           " ANTIBACTERIAL_DRUGS_U,ANTIBACTERIAL_DRUGS_TI,ANTIBACTERIAL_DRUGS_D,"+
                                           " ANTIBACTERIAL_DRUGS_CO,ANTIBACTERIAL_DRUGS_N,ANTIBACTERIAL_DRUGS_L,"+
                                           " ANTIBACTERIAL_DRUGS_TY,ID_IATROGENIC_DETECTION,P_D_SPECIMENS,"+
                                           " MICROBE_DETECTION from COVER_APPEND_ANTIBIOTICS where ID=" + Cover_Append_id + "";
                DataTable dt = App.GetDataSet(sql).Tables[0];
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_T"].ToString().Trim() != "") //������ҩĿ��
                        {
                            if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_T"].ToString() == "2")
                            {
                                rdoANTIBACTERIAL_DRUGS_T_ZL.Checked = true;
                            }
                            else 
                            {
                                rdoANTIBACTERIAL_DRUGS_T_YF.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_C"].ToString().Trim() != "") //������ҩ����
                        {
                            if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_C"].ToString() == "2")
                            {
                                rdoANTIBACTERIAL_DRUGS_C_LH.Checked = true;
                            }
                            else
                            {
                                rdoANTIBACTERIAL_DRUGS_C_DD.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_U"].ToString().Trim() != "") //����ҩ����;
                        {
                            cboANTIBACTERIAL_DRUGS_U.SelectedValue = dt.Rows[i]["ANTIBACTERIAL_DRUGS_U"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_TI"].ToString().Trim() != "") //����ҩ��ʱ��
                        {
                            txtANTIBACTERIAL_DRUGS_TI.Text = dt.Rows[i]["ANTIBACTERIAL_DRUGS_TI"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_D"].ToString().Trim() != "") //����ҩ������
                        {
                            txtANTIBACTERIAL_DRUGS_D.Text = dt.Rows[i]["ANTIBACTERIAL_DRUGS_D"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_CO"].ToString().Trim() != "") //����ҩ����
                        {
                            txtANTIBACTERIAL_DRUGS_CO.Text = dt.Rows[i]["ANTIBACTERIAL_DRUGS_CO"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_N"].ToString().Trim() != "") //����ҩ������
                        {
                            cboANTIBACTERIAL_DRUGS_N.SelectedValue = dt.Rows[i]["ANTIBACTERIAL_DRUGS_N"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_L"].ToString().Trim() != "") //����ҩ�Ｖ��
                        {
                            cboANTIBACTERIAL_DRUGS_L.SelectedValue = dt.Rows[i]["ANTIBACTERIAL_DRUGS_L"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_TY"].ToString().Trim() != "") //����ҩ������
                        {
                            cboANTIBACTERIAL_DRUGS_TY.SelectedValue = dt.Rows[i]["ANTIBACTERIAL_DRUGS_TY"].ToString();
                        }

                        if (dt.Rows[i]["ID_IATROGENIC_DETECTION"].ToString().Trim() != "") //�Ƿ�ҽԴ�Լ�� �� Y �� N
                        {
                            if (dt.Rows[i]["ID_IATROGENIC_DETECTION"].ToString()=="Y")
                            {
                                rdoID_IATROGENIC_DETECTION_Y.Checked = true;
                            }
                            else
                            {
                                rdoID_IATROGENIC_DETECTION_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["P_D_SPECIMENS"].ToString().Trim() != "") //��ԭѧ���걾
                        {
                            cboP_D_SPECIMENS.SelectedValue = dt.Rows[i]["P_D_SPECIMENS"].ToString();
                        }

                        if (dt.Rows[i]["MICROBE_DETECTION"].ToString().Trim() != "") //΢��������
                        {
                            cboMICROBE_DETECTION.SelectedValue = dt.Rows[i]["MICROBE_DETECTION"].ToString();
                        }
                    }
                    
                }

            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ��,ԭ��:" + ex.Message);
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
    }
}
