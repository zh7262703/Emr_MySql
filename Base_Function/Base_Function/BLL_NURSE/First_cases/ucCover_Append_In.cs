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
    /// סԺ��ҳ�ı༭
    /// �޸�:������
    /// ʱ��:2013-01-27
    /// </summary>
    public partial class ucCover_Append_In : UserControl
    {

        private string PatientId="";           //��ǰ���˵�����
        private string Cover_Append_id = "";   //��ǰѡ�е�סԺ��ҳ������

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patientid">��������</param>
        public ucCover_Append_In(string patientid)
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
        public ucCover_Append_In(string patientid,string cover_append_id)
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
            string Sqlhisid = "select HIS_ID from t_in_patient  where ID ='" + PatientId + "'";
            string HIS_ID = App.ReadSqlVal(Sqlhisid, 0, "HIS_ID");
            HIS_ID = HIS_ID.Substring(0, 4);
            //�Ƿ�����Ժ����
            if (HIS_ID == "ZY01")
            {
                radISHAVEINNo.Checked = true;
                pISHAVEIN_YesNO.Enabled = false;
            }
            else if (HIS_ID != "")
            {
                radISHAVEINYes.Checked = true;
                pISHAVEIN_YesNO.Enabled = false;
            }
            else
            {
                pISHAVEIN_YesNO.Enabled = true;
            }

            //����ϵͳt_in_patient��IN_CASE�ֶ��Զ�ѡ��Σ ��Ӧ �˴��Ĳ�Σ���� �� �� ��Ӧ�˴��Ĳ��أ�һ�� ��Ӧ�˴���һ��

            string Sqlcircs = "select t.in_circs from t_in_patient t  where ID ='" + PatientId + "'";
            string circs = App.ReadSqlVal(Sqlcircs, 0, "in_circs");
            //�Ƿ�����Ժ����
            if (circs.IndexOf("Σ") > -1)
            {//�ַ���circs�а����ַ���Σ
                rdoIN_CASE_BW.Checked = true;
                pIN_CASE.Enabled = false;
            }
            else if (circs.IndexOf("��") > -1 || circs.IndexOf("��") > -1)
            {
                rdoIN_CASE_BZ.Checked = true;
                pIN_CASE.Enabled = false;
            }
            else if (circs.IndexOf("һ��") > -1 )
            {
                rdoIN_CASE_YB.Checked = true;
                pIN_CASE.Enabled = false;
            }
            else
            {
                pIN_CASE.Enabled = true;
            }

            //����֢
            DataSet ds_bf = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='BFZ001'");
            //ҽԴ���˺�
            DataSet ds_yxx = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='yxsh00001'");

            
            chkCOMPLICATING_DISEASE.DataSource = ds_bf.Tables[0].DefaultView;
            chkCOMPLICATING_DISEASE.DisplayMember = "name";
            chkCOMPLICATING_DISEASE.ValueMember = "id";
            chkCOMPLICATING_DISEASE.Enabled = false;

            chkIS_IATROGENIC_INJURY.DataSource = ds_yxx.Tables[0].DefaultView;
            chkIS_IATROGENIC_INJURY.DisplayMember = "name";
            chkIS_IATROGENIC_INJURY.ValueMember = "id";
            chkIS_IATROGENIC_INJURY.Enabled = false;
            

        }


        /// <summary>
        /// ��ʼ����ҳ��Ϣ
        /// </summary>
        /// <param name="Cover_Append_id">��ҳ������</param>
        private void iniData(string Cover_Append_id)
        {
            try
            {
                string Sql = "select Patient_Id, ISHAVEIN, HAVEIN_COUNT, HAVEIN_REASON, IN_CASE, DEATH_REASON,"+
                                      "ISINFUSE, INFUSE_REACTION, ISBOOLDINFUSE, BLOODINFUSE_REACTION, ISCOMPLICATING_DISEASE,"+
                                      "ISINFECT,OPER_FROZEN_PARAFFIN, BEF_OPER_CASE, COMPLICATING_DISEASE, IATROGENIC_INJURY,"+
                                      "IS_COMPLICATING_DISEASES,IS_IATROGENIC_INJURYS," +
                                      "IS_RESPIRATOR,RESPIRATOR_DAYS, IS_RPT_PNEUMONIA_INFECTION, IS_CATHETERIZATION, "+
                                      "CATHETERIZATION_DAYS,IS_CATHETERIZATION_INFECT, IS_CATHETER, CATHETER_DAYS,"+
                                      "IS_U_S_INFECTION, IS_HEMODIALYSIS,HEMODIALYSIS_DAYS, IS_HEMODIALYSIS_INFECT,CREATE_TIME,USER_ID"+
                                      " from cover_append_in  where id=" + Cover_Append_id;
                DataTable dt = App.GetDataSet(Sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ISHAVEIN"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["ISHAVEIN"].ToString() == "Y")//�Ƿ��ٴ���Ժ Y �� N ��
                            {
                                radISHAVEINYes.Checked = true;
                            }
                            else
                            {
                                radISHAVEINNo.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["HAVEIN_COUNT"].ToString().Trim() != "")//����Ժ����
                        {
                            txtHAVEIN_COUNT.Text=dt.Rows[i]["HAVEIN_COUNT"].ToString();
                            
                        }

                        if (dt.Rows[i]["HAVEIN_REASON"].ToString().Trim() != "")//�ٴ���Ժԭ��
                        {
                            if (dt.Rows[i]["HAVEIN_REASON"].ToString() == "2")
                            {
                                rdoHAVEIN_REASON_other.Checked = true;
                            }
                            else
                            {
                                rdoHAVEIN_REASON_as.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["IN_CASE"].ToString().Trim() != "")//��Ժʱ���
                        {
                            if (dt.Rows[i]["IN_CASE"].ToString() == "2")
                            {
                                rdoIN_CASE_BZ.Checked = true;
                            }
                            else if (dt.Rows[i]["IN_CASE"].ToString() == "3")
                            {
                                rdoIN_CASE_YB.Checked = true;
                            }
                            else
                            {
                                rdoIN_CASE_BW.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["DEATH_REASON"].ToString().Trim() != "")//����ԭ��
                        {
                            if (dt.Rows[i]["DEATH_REASON"].ToString() == "1")
                            {
                                rdoDEATH_REASON_SZSW.Checked = true;
                            }
                            else if (dt.Rows[i]["DEATH_REASON"].ToString() == "2")
                            {
                                rdoDEATH_REASON_MZSW.Checked = true;
                            }
                            else if (dt.Rows[i]["DEATH_REASON"].ToString() == "3")
                            {
                                rdoDEATH_REASON_YYCW.Checked = true;
                            }
                            else if (dt.Rows[i]["DEATH_REASON"].ToString() == "4")
                            {
                                rdoDEATH_REASON_SHBFZ.Checked = true;
                            }
                            else
                            {
                                rdoDEATH_REASON_YQSW.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ISINFUSE"].ToString().Trim() != "")//�Ƿ���Һ Y �� N ��
                        {
                            if (dt.Rows[i]["ISINFUSE"].ToString() == "Y")
                            {
                                rdoISINFUSE_Y.Checked = true;
                            }
                            else
                            {
                                rdoISINFUSE_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["INFUSE_REACTION"].ToString().Trim() != "")//��Һ��Ӧ
                        {
                            if (dt.Rows[i]["INFUSE_REACTION"].ToString() == "1")
                            {
                                rdoINFUSE_REACTION_Y.Checked = true;
                            }
                            else
                            {
                                rdoINFUSE_REACTION_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ISBOOLDINFUSE"].ToString().Trim() != "")//�Ƿ���Ѫ Y �� N ��
                        {
                            if (dt.Rows[i]["ISBOOLDINFUSE"].ToString() == "Y")
                            {
                                rdoISBOOLDINFUSE_Y.Checked = true;
                            }
                            else
                            {
                                rdoISBOOLDINFUSE_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["BLOODINFUSE_REACTION"].ToString().Trim() != "")//��Ѫ��Ӧ
                        {
                            if (dt.Rows[i]["BLOODINFUSE_REACTION"].ToString() == "1")
                            {
                                rdoBLOODINFUSE_REACTION_Y.Checked = true;
                            }
                            else
                            {
                                rdoBLOODINFUSE_REACTION_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ISCOMPLICATING_DISEASE"].ToString().Trim() != "")//�Ƿ񲢷�֢  Y �� N ��
                        {
                            if (dt.Rows[i]["ISCOMPLICATING_DISEASE"].ToString() == "Y")
                            {
                                rdoISCOMPLICATING_DISEASE_Y.Checked = true;
                            }
                            else
                            {
                                rdoISCOMPLICATING_DISEASE_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ISINFECT"].ToString().Trim() != "")//�Ƿ�Ժ�ڸ�Ⱦ  Y �� N ��
                        {
                            if (dt.Rows[i]["ISINFECT"].ToString() == "Y")
                            {
                                rdoISINFECT_Y.Checked = true;
                            }
                            else
                            {
                                rdoISINFECT_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["OPER_FROZEN_PARAFFIN"].ToString().Trim() != "")//����������ʯ��������Ϸ������
                        {
                            if (dt.Rows[i]["OPER_FROZEN_PARAFFIN"].ToString() == "1")
                            {
                                rdoOPER_FROZEN_PARAFFIN_FH.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_FROZEN_PARAFFIN"].ToString() == "2")
                            {
                                rdoOPER_FROZEN_PARAFFIN_BFH.Checked = true;
                            }
                            else
                            {
                                rdoOPER_FROZEN_PARAFFIN_WZ.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["BEF_OPER_CASE"].ToString().Trim() != "")//��ǰ�������������Ϸ������
                        {
                            if (dt.Rows[i]["BEF_OPER_CASE"].ToString() == "1")
                            {
                                rdoBEF_OPER_CASE_FH.Checked = true;
                            }
                            else if (dt.Rows[i]["BEF_OPER_CASE"].ToString() == "2")
                            {
                                rdoBEF_OPER_CASE_BFH.Checked = true;
                            }
                            else
                            {
                                rdoBEF_OPER_CASE_WZ.Checked = true;
                            }
                        }


                        if (dt.Rows[i]["IS_COMPLICATING_DISEASES"].ToString().Trim() != "")//�Ƿ������󲢷�֢  Y �� N ��
                        {
                            if (dt.Rows[i]["IS_COMPLICATING_DISEASES"].ToString() == "Y")
                            {
                                rdoCOMPLICATING_DISEASE_Y.Checked = true;
                                if (dt.Rows[i]["COMPLICATING_DISEASE"].ToString().Trim() != "")//����֢������������ֵ���ȡ��صĴ��룩
                                {
                                    //cboCOMPLICATING_DISEASE.SelectedValue = dt.Rows[i]["BEF_OPER_CASE"].ToString();

                                    string[] vals = dt.Rows[i]["COMPLICATING_DISEASE"].ToString().Split(',');
                                    for (int i1 = 0; i1 < vals.Length; i1++)
                                    {
                                        for (int j = 0; j < chkCOMPLICATING_DISEASE.Items.Count; j++)
                                        {
                                            DataRowView temp = (DataRowView)chkCOMPLICATING_DISEASE.Items[j];
                                            if (temp["id"].ToString() == vals[i1])
                                            {
                                                chkCOMPLICATING_DISEASE.SetItemChecked(j, true);
                                            }
                                        }
                                    }

                                }
                            }
                            else
                            {
                                rdoCOMPLICATING_DISEASE_N.Checked = true;
                            }
                        }


                        if (dt.Rows[i]["IS_IATROGENIC_INJURYS"].ToString().Trim() != "")//�Ƿ���ҽԴ���˺����  Y �� N ��
                        {
                            if (dt.Rows[i]["IS_IATROGENIC_INJURYS"].ToString() == "Y")
                            {
                                rdoIS_IATROGENIC_INJURY_Y.Checked = true;
                                if (dt.Rows[i]["IATROGENIC_INJURY"].ToString().Trim() != "")//ҽԴ���˺�������������ֵ���ȡ��صĴ��룩
                                {

                                    //cboIS_IATROGENIC_INJURY.SelectedValue = dt.Rows[i]["BEF_OPER_CASE"].ToString();
                                    string[] vals = dt.Rows[i]["IATROGENIC_INJURY"].ToString().Split(',');
                                    for (int i1 = 0; i1 < vals.Length; i1++)
                                    {
                                        for (int j = 0; j < chkIS_IATROGENIC_INJURY.Items.Count; j++)
                                        {
                                            DataRowView temp = (DataRowView)chkIS_IATROGENIC_INJURY.Items[j];
                                            if (temp["id"].ToString() == vals[i1])
                                            {
                                                chkIS_IATROGENIC_INJURY.SetItemChecked(j, true);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_IATROGENIC_INJURY_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["IS_RESPIRATOR"].ToString().Trim() != "")//�Ƿ�ʹ�ú�����  Y �� N ��
                        {
                            if (dt.Rows[i]["IS_RESPIRATOR"].ToString() == "Y")
                            {
                                rdoIS_RESPIRATOR_Y.Checked = true;
                                pIS_RESPIRATOR.Visible = true;
                                if (dt.Rows[i]["RESPIRATOR_DAYS"].ToString().Trim() != "")//������ʹ������
                                {
                                    txtRESPIRATOR_DAYS.Text = dt.Rows[i]["RESPIRATOR_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_RPT_PNEUMONIA_INFECTION"].ToString().Trim() != "")//�Ƿ���ʹ�ú�������ط��׸�Ⱦ  Y �� N ��
                                {
                                    if (dt.Rows[i]["IS_RPT_PNEUMONIA_INFECTION"].ToString() == "Y")
                                    {
                                        rdoIS_RPT_PNEUMONIA_INFECTION_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_RPT_PNEUMONIA_INFECTION_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_RESPIRATOR_N.Checked = true;
                                pIS_RESPIRATOR.Visible = false;
                            }
                        }

                        if (dt.Rows[i]["IS_CATHETERIZATION"].ToString().Trim() != "")//�Ƿ�ʹ�����ľ����ù� Y �� N ��
                        {
                            if (dt.Rows[i]["IS_CATHETERIZATION"].ToString() == "Y")
                            {
                                rdoIS_CATHETERIZATION_Y.Checked = true;
                                pIS_CATHETERIZATION.Visible = true;
                                if (dt.Rows[i]["CATHETERIZATION_DAYS"].ToString().Trim() != "")//���ľ����ù�����
                                {
                                    txtCATHETERIZATION_DAYS.Text = dt.Rows[i]["CATHETERIZATION_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_CATHETERIZATION_INFECT"].ToString().Trim() != "")//�Ƿ���ʹ�����ľ����ù����Ѫ����Ⱦ  Y �� N ��
                                {
                                    if (dt.Rows[i]["IS_CATHETERIZATION_INFECT"].ToString() == "Y")
                                    {
                                        rdoIS_CATHETERIZATION_INFECT_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_CATHETERIZATION_INFECT_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_CATHETERIZATION_N.Checked = true;
                                pIS_CATHETERIZATION.Visible = false;
                            }
                        }

                        

                        if (dt.Rows[i]["IS_CATHETER"].ToString().Trim() != "")//�Ƿ�ʹ�����õ���� Y �� N ��
                        {
                            if (dt.Rows[i]["IS_CATHETER"].ToString() == "Y")
                            {
                                rdoIS_CATHETER_Y.Checked = true;
                                pIS_CATHETER.Visible = true;
                                if (dt.Rows[i]["CATHETER_DAYS"].ToString().Trim() != "")//ʹ�õ��������
                                {
                                    txtCATHETER_DAYS.Text = dt.Rows[i]["CATHETER_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_U_S_INFECTION"].ToString().Trim() != "")//�Ƿ���ϵ��Ⱦ Y �� N ��
                                {
                                    if (dt.Rows[i]["IS_U_S_INFECTION"].ToString() == "Y")
                                    {
                                        rdoIS_U_S_INFECTION_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_U_S_INFECTION_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_CATHETER_N.Checked = true;
                                pIS_CATHETER.Visible = false;
                            }
                        }

                        

                        if (dt.Rows[i]["IS_HEMODIALYSIS"].ToString().Trim() != "")//ѪҺ͸��  Y �� N ��
                        {
                            if (dt.Rows[i]["IS_HEMODIALYSIS"].ToString() == "Y")
                            {
                                rdoIS_HEMODIALYSIS_Y.Checked = true;
                                pIS_HEMODIALYSIS.Visible = true;
                                if (dt.Rows[i]["HEMODIALYSIS_DAYS"].ToString().Trim() != "")//ѪҺ͸������
                                {
                                    txtHEMODIALYSIS_DAYS.Text = dt.Rows[i]["HEMODIALYSIS_DAYS"].ToString();
                                }

                                if (dt.Rows[i]["IS_HEMODIALYSIS_INFECT"].ToString().Trim() != "")//�Ƿ�ѪҺ͸����Ⱦ
                                {
                                    if (dt.Rows[i]["IS_HEMODIALYSIS_INFECT"].ToString() == "Y")
                                    {
                                        rdoIS_HEMODIALYSIS_INFECT_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_HEMODIALYSIS_INFECT_N.Checked = true;
                                    }
                                }
                            }
                            else
                            {
                                rdoIS_HEMODIALYSIS_N.Checked = true;
                                pIS_HEMODIALYSIS.Visible = false;
                            }
                        }

                        
                    }
                }

            }
            catch (Exception ex)
            {
                App.MsgErr("��ʼ��ʧ��,ԭ��:"+ex.Message);
            }
        }

        /// <summary>
        /// ��ӻ��޸ĸ�ҳ����Ϣ
        /// </summary>
        /// <returns></returns>
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
                foreach (Control c in this.pISHAVEIN.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }
                foreach (Control c in this.pIS_RESPIRATOR.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                } 
                foreach (Control c in this.pIS_CATHETERIZATION.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                } 
                foreach (Control c in this.pIS_CATHETER.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                } 
                foreach (Control c in this.pIS_HEMODIALYSIS.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }

                //c.ForeColor = Color.Black;//��list�е�������ɫ
                   

                string ISHAVEIN = "";    //�Ƿ��ٴ���Ժ Y �� N ��
                string HAVEIN_COUNT = "";  //�ٴ���Ժ����
                string HAVEIN_REASON = ""; //�ٴ���Ժԭ��

                if (radISHAVEINNo.Checked)
                {
                    ISHAVEIN = "N";
                }
                else if (radISHAVEINYes.Checked)
                {
                    ISHAVEIN = "Y";
                    if (txtHAVEIN_COUNT.Text != "")
                    {
                        HAVEIN_COUNT = txtHAVEIN_COUNT.Text;
                    }
                    else
                    {
                        label2.ForeColor = Color.Red;
                        label13.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label2.Text + "]δ��д!");
                        return false;
                    }


                    if (rdoHAVEIN_REASON_other.Checked)
                    {
                        HAVEIN_REASON = "2";
                    }
                    else if (rdoHAVEIN_REASON_as.Checked)
                    {
                        HAVEIN_REASON = "1";
                    }
                    else
                    {
                        label3.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label3.Text + "]δѡ��!");
                        return false;
                    }
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label1.Text + "]δѡ��!");
                    return false;
                }

                
                

                string IN_CASE = "";         //��Ժʱ���
                if (rdoIN_CASE_BW.Checked)
                {
                    IN_CASE = "1";
                }
                else if (rdoIN_CASE_BZ.Checked)
                {
                    IN_CASE = "2";
                }
                else if (rdoIN_CASE_YB.Checked)
                {
                    IN_CASE = "3";
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label4.Text + "]δѡ��!");
                    return false;
                }

                string DEATH_REASON = "";    //����ԭ��
                if (rdoDEATH_REASON_YQSW.Checked)
                {
                    DEATH_REASON = "0";
                }
                else if (rdoDEATH_REASON_SZSW.Checked)
                {
                    DEATH_REASON = "1";
                }
                else if (rdoDEATH_REASON_MZSW.Checked)
                {
                    DEATH_REASON = "2";
                }
                else if (rdoDEATH_REASON_YYCW.Checked)
                {
                    DEATH_REASON = "3";
                }
                else if (rdoDEATH_REASON_SHBFZ.Checked)
                {
                    DEATH_REASON = "4";
                }
                else
                {
                    label5.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label5.Text + "]δѡ��!");
                    return false;
                }



                string ISINFUSE = "";        //�Ƿ���Һ Y �� N ��
                if (rdoISINFUSE_Y.Checked)
                {
                    ISINFUSE = "Y";
                }
                else if (rdoISINFUSE_N.Checked)
                {
                    ISINFUSE = "N";
                }
                else
                {
                    label6.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label6.Text + "]δѡ��!");
                    return false;
                }

                string INFUSE_REACTION = ""; //��Һ��Ӧ
                if (rdoINFUSE_REACTION_Y.Checked)
                {
                    INFUSE_REACTION = "1";
                }
                else if (rdoINFUSE_REACTION_N.Checked)
                {
                    INFUSE_REACTION = "2";
                }
                else
                {
                    label14.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label14.Text + "]δѡ��!");
                    return false;
                }


                string ISBOOLDINFUSE = "";   //�Ƿ���Ѫ Y �� N ��
                if (rdoISBOOLDINFUSE_Y.Checked)
                {
                    ISBOOLDINFUSE = "Y";
                }
                else if (rdoISBOOLDINFUSE_N.Checked)
                {
                    ISBOOLDINFUSE = "N";
                }
                else
                {
                    label7.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label7.Text + "]δѡ��!");
                    return false;
                }

                string BLOODINFUSE_REACTION = ""; //��Ѫ��Ӧ
                if (rdoBLOODINFUSE_REACTION_Y.Checked)
                {
                    BLOODINFUSE_REACTION = "1";
                }
                else if (rdoBLOODINFUSE_REACTION_N.Checked)
                {
                    BLOODINFUSE_REACTION = "2";
                }
                else
                {
                    label15.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label15.Text + "]δѡ��!");
                    return false;
                }

                string ISCOMPLICATING_DISEASE = ""; //�Ƿ񲢷�֢  Y �� N ��
                if (rdoISCOMPLICATING_DISEASE_Y.Checked)
                {
                    ISCOMPLICATING_DISEASE = "Y";
                }
                else if (rdoISCOMPLICATING_DISEASE_N.Checked)
                {
                    ISCOMPLICATING_DISEASE = "N";
                }
                else
                {
                    label8.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label8.Text + "]δѡ��!");
                    return false;
                }

                string ISINFECT = "";                //�Ƿ�Ժ�ڸ�Ⱦ  Y �� N ��
                if (rdoISINFECT_Y.Checked)
                {
                    ISINFECT = "Y";
                }
                else if (rdoISINFECT_N.Checked)
                {
                    ISINFECT = "N";
                }
                else
                {
                    label16.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label16.Text + "]δѡ��!");
                    return false;
                }

                string OPER_FROZEN_PARAFFIN = "";    //����������ʯ��������Ϸ������
                if (rdoOPER_FROZEN_PARAFFIN_WZ.Checked)
                {
                    OPER_FROZEN_PARAFFIN = "0";
                }
                else if (rdoOPER_FROZEN_PARAFFIN_FH.Checked)
                {
                    OPER_FROZEN_PARAFFIN = "1";
                }
                else if (rdoOPER_FROZEN_PARAFFIN_BFH.Checked)
                {
                    OPER_FROZEN_PARAFFIN = "2";
                }
                else
                {
                    label9.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label9.Text + "]δѡ��!");
                    return false;
                }

                string BEF_OPER_CASE = "";           //��ǰ�������������Ϸ������
                if (rdoBEF_OPER_CASE_WZ.Checked)
                {
                    BEF_OPER_CASE = "0";
                }
                else if (rdoBEF_OPER_CASE_FH.Checked)
                {
                    BEF_OPER_CASE = "1";
                }
                else if (rdoBEF_OPER_CASE_BFH.Checked)
                {
                    BEF_OPER_CASE = "2";
                }
                else
                {
                    label10.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label10.Text + "]δѡ��!");
                    return false;
                }

                string IS_COMPLICATING_DISEASES = ""; //�Ƿ������󲢷�֢
                if (rdoCOMPLICATING_DISEASE_Y.Checked)
                {
                    IS_COMPLICATING_DISEASES = "Y";
                }
                else if (rdoCOMPLICATING_DISEASE_N.Checked)
                {
                    IS_COMPLICATING_DISEASES = "N";
                }
                else
                {
                    label11.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label11.Text + "]δѡ��!");
                    return false;
                }

                string COMPLICATING_DISEASE = "";     //����֢������������ֵ���ȡ��صĴ��룩

                if (rdoCOMPLICATING_DISEASE_Y.Checked)
                {
                    //if (cboCOMPLICATING_DISEASE.SelectedValue != null)
                    //{
                    //    COMPLICATING_DISEASE = cboCOMPLICATING_DISEASE.SelectedValue.ToString();
                    //}
                    if (chkCOMPLICATING_DISEASE.Items.Count > 0 && chkCOMPLICATING_DISEASE.CheckedItems.Count == 0)
                    {

                        label11.ForeColor = Color.Red;
                        App.Msg("��ʾ:[����֢���]δѡ��!");
                        return false;
                    }

                    for (int i = 0; i < chkCOMPLICATING_DISEASE.CheckedItems.Count; i++)
                    {

                        DataRowView temp = (DataRowView)chkCOMPLICATING_DISEASE.CheckedItems[i];
                        if (COMPLICATING_DISEASE == "")
                        {
                            COMPLICATING_DISEASE = temp["id"].ToString();
                        }
                        else
                        {
                            COMPLICATING_DISEASE =COMPLICATING_DISEASE+","+temp["id"].ToString();
                        }

                    }
                }

                string IS_IATROGENIC_INJURYS = ""; //�Ƿ���ҽԴ���˺����
                if (rdoIS_IATROGENIC_INJURY_Y.Checked)
                {
                    IS_IATROGENIC_INJURYS = "Y";
                }
                else if (rdoIS_IATROGENIC_INJURY_N.Checked)
                {
                    IS_IATROGENIC_INJURYS = "N";
                }
                else
                {
                    label12.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label12.Text + "]δѡ��!");
                    return false;
                }

                string IATROGENIC_INJURY = "";        //ҽԴ���˺�������������ֵ���ȡ��صĴ��룩
                if (rdoIS_IATROGENIC_INJURY_Y.Checked)
                {        
                    //if (cboIS_IATROGENIC_INJURY.SelectedValue != null)
                    //{
                    //    COMPLICATING_DISEASE = cboIS_IATROGENIC_INJURY.SelectedValue.ToString();
                    //}
                    if (chkIS_IATROGENIC_INJURY.Items.Count > 0 && chkIS_IATROGENIC_INJURY.CheckedItems.Count == 0)
                    {
                        label12.ForeColor = Color.Red;
                        App.Msg("��ʾ:[ҽԴ���˺����]δѡ��!");
                        return false;
                    }
                    for (int i = 0; i < chkIS_IATROGENIC_INJURY.CheckedItems.Count; i++)
                    {
                        DataRowView temp = (DataRowView)chkIS_IATROGENIC_INJURY.CheckedItems[i];
                        if (IATROGENIC_INJURY == "")
                        {
                            IATROGENIC_INJURY = temp["id"].ToString();
                        }
                        else
                        {
                            IATROGENIC_INJURY = IATROGENIC_INJURY + "," + temp["id"].ToString();
                        }
                    }
                }

                string IS_RESPIRATOR = "";           //�Ƿ�ʹ�ú�����  Y �� N ��
                string RESPIRATOR_DAYS = "";          //������ʹ������
                string IS_RPT_PNEUMONIA_INFECTION = "";//�Ƿ���ʹ�ú�������ط��׸�Ⱦ  Y �� N ��
                if (rdoIS_RESPIRATOR_Y.Checked)
                {
                    IS_RESPIRATOR = "Y";
                    if (txtRESPIRATOR_DAYS.Text != "")
                    {
                        RESPIRATOR_DAYS = txtRESPIRATOR_DAYS.Text;
                    }
                    else
                    {
                        label22.ForeColor = Color.Red;
                        label21.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label22.Text + "]δ��д!");
                        return false;
                    }

                    if (rdoIS_RPT_PNEUMONIA_INFECTION_Y.Checked)
                    {
                        IS_RPT_PNEUMONIA_INFECTION = "Y";
                    }
                    else if (rdoIS_RPT_PNEUMONIA_INFECTION_N.Checked)
                    {
                        IS_RPT_PNEUMONIA_INFECTION = "N";
                    }
                    else
                    {
                        label29.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label29.Text + "]δѡ��!");
                        return false;
                    }
                }
                else if (rdoIS_RESPIRATOR_N.Checked)
                {
                    IS_RESPIRATOR = "N";
                }
                else
                {
                    label17.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label17.Text + "]δѡ��!");
                    return false;
                }

                
                string IS_CATHETERIZATION = "";        //�Ƿ�ʹ�����ľ����ù� Y �� N ��
                string CATHETERIZATION_DAYS = "";       //���ľ����ù�����
                string IS_CATHETERIZATION_INFECT = ""; //�Ƿ���ʹ�����ľ����ù����Ѫ����Ⱦ  Y �� N ��
                if (rdoIS_CATHETERIZATION_Y.Checked)
                {
                    IS_CATHETERIZATION = "Y";
                    if (txtCATHETERIZATION_DAYS.Text != "")
                    {
                        CATHETERIZATION_DAYS = txtCATHETERIZATION_DAYS.Text;
                    }
                    else
                    {
                        label24.ForeColor = Color.Red;
                        label23.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label24.Text + "]δ��д!");
                        return false;
                    }

                    if (rdoIS_CATHETERIZATION_INFECT_Y.Checked)
                    {
                        IS_CATHETERIZATION_INFECT = "Y";
                    }
                    else if (rdoIS_CATHETERIZATION_INFECT_N.Checked)
                    {
                        IS_CATHETERIZATION_INFECT = "N";
                    }
                    else
                    {
                        label30.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label30.Text + "]δѡ��!");
                        return false;
                    }
                }
                else if (rdoIS_CATHETERIZATION_N.Checked)
                {
                    IS_CATHETERIZATION = "N";
                }
                else
                {
                    label18.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label18.Text + "]δѡ��!");
                    return false;
                }

                string IS_CATHETER = "";               //�Ƿ�ʹ�����õ���� Y �� N ��
                string CATHETER_DAYS = "";              //ʹ�õ��������
                string IS_U_S_INFECTION = "";          //�Ƿ���ϵ��Ⱦ Y �� N ��
                if (rdoIS_CATHETER_Y.Checked)
                {
                    IS_CATHETER = "Y";
                    if (txtCATHETER_DAYS.Text != "")
                    {
                        CATHETER_DAYS = txtCATHETER_DAYS.Text;
                    }
                    else
                    {
                        label26.ForeColor = Color.Red;
                        label25.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label26.Text + "]δ��д!");
                        return false;
                    }

                    if (rdoIS_U_S_INFECTION_Y.Checked)
                    {
                        IS_U_S_INFECTION = "Y";
                    }
                    else if (rdoIS_U_S_INFECTION_N.Checked)
                    {
                        IS_U_S_INFECTION = "N";
                    }
                    else
                    {
                        label31.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label31.Text + "]δѡ��!");
                        return false;
                    }
                }
                else if (rdoIS_CATHETER_N.Checked)
                {
                    IS_CATHETER = "N";
                }
                else
                {
                    label19.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label19.Text + "]δѡ��!");
                    return false;
                }

                
                

                string IS_HEMODIALYSIS = "";           //ѪҺ͸��  Y �� N ��
                string HEMODIALYSIS_DAYS = "";          //ѪҺ͸������
                string IS_HEMODIALYSIS_INFECT = "";    //�Ƿ�ѪҺ͸����Ⱦ
                if (rdoIS_HEMODIALYSIS_Y.Checked)
                {
                    IS_HEMODIALYSIS = "Y";
                    if (txtHEMODIALYSIS_DAYS.Text != "")
                    {
                        HEMODIALYSIS_DAYS = txtHEMODIALYSIS_DAYS.Text;
                    }
                    else
                    {
                        label28.ForeColor = Color.Red;
                        label27.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label28.Text + "]δ��д!");
                        return false;
                    }

                    if (rdoIS_HEMODIALYSIS_INFECT_Y.Checked)
                    {
                        IS_HEMODIALYSIS_INFECT = "Y";
                    }
                    else if (rdoIS_HEMODIALYSIS_INFECT_N.Checked)
                    {
                        IS_HEMODIALYSIS_INFECT = "N";
                    }
                    else
                    {
                        label32.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label32.Text + "]δѡ��!");
                        return false;
                    }
                }
                else if (rdoIS_HEMODIALYSIS_N.Checked)
                {
                    IS_HEMODIALYSIS = "N";
                }
                else
                {
                    label20.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label20.Text + "]δѡ��!");
                    return false;
                }


                string Sql = "";
                if (Cover_Append_id == "")
                {
                    Sql = "insert into COVER_APPEND_IN(PATIENT_ID,ISHAVEIN,HAVEIN_COUNT,HAVEIN_REASON," +
                                                           "IN_CASE,DEATH_REASON,ISINFUSE,INFUSE_REACTION,ISBOOLDINFUSE," +
                                                           "BLOODINFUSE_REACTION,ISCOMPLICATING_DISEASE,ISINFECT,OPER_FROZEN_PARAFFIN," +
                                                           "BEF_OPER_CASE,COMPLICATING_DISEASE,IATROGENIC_INJURY,IS_RESPIRATOR," +
                                                           "RESPIRATOR_DAYS,IS_RPT_PNEUMONIA_INFECTION,IS_CATHETERIZATION,CATHETERIZATION_DAYS," +
                                                           "IS_CATHETERIZATION_INFECT,IS_CATHETER,CATHETER_DAYS,IS_U_S_INFECTION,IS_HEMODIALYSIS," +
                                                           "HEMODIALYSIS_DAYS,IS_HEMODIALYSIS_INFECT,IS_COMPLICATING_DISEASES,IS_IATROGENIC_INJURYS,CREATE_TIME,USER_ID)values({0},'{1}','{2}','{3}','{4}','{5}'," +
                                                           "'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}'," +
                                                           "'{23}','{24}','{25}','{26}','{27}','{28}','{29}',to_timestamp('{30}','syyyy-mm-dd hh24:mi'),{31})";

                    Sql = string.Format(Sql, PatientId, ISHAVEIN, HAVEIN_COUNT, HAVEIN_REASON, IN_CASE, DEATH_REASON,
                                      ISINFUSE, INFUSE_REACTION, ISBOOLDINFUSE, BLOODINFUSE_REACTION, ISCOMPLICATING_DISEASE, ISINFECT,
                                      OPER_FROZEN_PARAFFIN, BEF_OPER_CASE, COMPLICATING_DISEASE, IATROGENIC_INJURY, IS_RESPIRATOR,
                                      RESPIRATOR_DAYS, IS_RPT_PNEUMONIA_INFECTION, IS_CATHETERIZATION, CATHETERIZATION_DAYS,
                                      IS_CATHETERIZATION_INFECT, IS_CATHETER, CATHETER_DAYS, IS_U_S_INFECTION, IS_HEMODIALYSIS,
                                      HEMODIALYSIS_DAYS, IS_HEMODIALYSIS_INFECT,IS_COMPLICATING_DISEASES,IS_IATROGENIC_INJURYS, App.GetSystemTime().ToShortDateString(), App.UserAccount.UserInfo.User_id);
                }
                else
                {
                    Sql = "update COVER_APPEND_IN set ISHAVEIN='{0}',HAVEIN_COUNT='{1}',HAVEIN_REASON='{2}'," +
                                                          "IN_CASE='{3}',DEATH_REASON='{4}',ISINFUSE='{5}',INFUSE_REACTION='{6}',ISBOOLDINFUSE='{7}'," +
                                                          "BLOODINFUSE_REACTION='{8}',ISCOMPLICATING_DISEASE='{9}',ISINFECT='{10}',OPER_FROZEN_PARAFFIN='{11}'," +
                                                          "BEF_OPER_CASE='{12}',COMPLICATING_DISEASE='{13}',IATROGENIC_INJURY='{14}',IS_RESPIRATOR='{15}'," +
                                                          "RESPIRATOR_DAYS='{16}',IS_RPT_PNEUMONIA_INFECTION='{17}',IS_CATHETERIZATION='{18}',CATHETERIZATION_DAYS='{19}'," +
                                                          "IS_CATHETERIZATION_INFECT='{20}',IS_CATHETER='{21}',CATHETER_DAYS='{22}',IS_U_S_INFECTION='{23}',IS_HEMODIALYSIS='{24}'," +
                                                          "HEMODIALYSIS_DAYS='{25}',IS_HEMODIALYSIS_INFECT='{26}',IS_COMPLICATING_DISEASES='{27}',IS_IATROGENIC_INJURYS='{28}' where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";

                    Sql = string.Format(Sql, ISHAVEIN, HAVEIN_COUNT, HAVEIN_REASON, IN_CASE, DEATH_REASON,
                                    ISINFUSE, INFUSE_REACTION, ISBOOLDINFUSE, BLOODINFUSE_REACTION, ISCOMPLICATING_DISEASE, ISINFECT,
                                    OPER_FROZEN_PARAFFIN, BEF_OPER_CASE, COMPLICATING_DISEASE, IATROGENIC_INJURY, IS_RESPIRATOR,
                                    RESPIRATOR_DAYS, IS_RPT_PNEUMONIA_INFECTION, IS_CATHETERIZATION, CATHETERIZATION_DAYS,
                                    IS_CATHETERIZATION_INFECT, IS_CATHETER, CATHETER_DAYS, IS_U_S_INFECTION, IS_HEMODIALYSIS,
                                    HEMODIALYSIS_DAYS, IS_HEMODIALYSIS_INFECT,IS_COMPLICATING_DISEASES,IS_IATROGENIC_INJURYS);

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
            catch(Exception ex)
            {
                App.MsgErr("����ʧ��,ԭ��:" + ex.Message);
                return false;
            }
        }
        

        #region �����Ƿ�ʹ�ú�����,���ľ����ù�,���õ����,ѪҺ͸��,�Ƿ�����Ժ,�Ƿ������󲢷�֢���,�Ƿ���ҽԴ���˺�����ȸ�����������ʾ�벻��ʾ
        private void rdoIS_HEMODIALYSIS_Y_CheckedChanged(object sender, EventArgs e)
        {//ѪҺ͸��
            if (rdoIS_HEMODIALYSIS_Y.Checked)
                pIS_HEMODIALYSIS.Visible = true;
            else
            {
                pIS_HEMODIALYSIS.Visible = false;
                txtHEMODIALYSIS_DAYS.Text = "";
                rdoIS_HEMODIALYSIS_INFECT_Y.Checked = false;
                rdoIS_HEMODIALYSIS_INFECT_N.Checked = false;
            }
        }

        private void rdoIS_CATHETER_Y_CheckedChanged(object sender, EventArgs e)
        {//���õ����
            if (rdoIS_CATHETER_Y.Checked)
                pIS_CATHETER.Visible = true;
            else
            {
                pIS_CATHETER.Visible = false;
                txtCATHETER_DAYS.Text = "";
                rdoIS_U_S_INFECTION_Y.Checked = false;
                rdoIS_U_S_INFECTION_N.Checked = false; 
            }
        }

        private void rdoIS_CATHETERIZATION_Y_CheckedChanged(object sender, EventArgs e)
        {//���ľ����ù�
            if (rdoIS_CATHETERIZATION_Y.Checked)
                pIS_CATHETERIZATION.Visible = true;
            else
            {
                pIS_CATHETERIZATION.Visible = false;
                txtCATHETERIZATION_DAYS.Text = "";
                rdoIS_CATHETERIZATION_INFECT_Y.Checked = false;
                rdoIS_CATHETERIZATION_INFECT_N.Checked = false;
            }
        }

        private void rdoIS_RESPIRATOR_Y_CheckedChanged(object sender, EventArgs e)
        {//������
            if (rdoIS_RESPIRATOR_Y.Checked)
                pIS_RESPIRATOR.Visible = true;
            else
            {
                pIS_RESPIRATOR.Visible = false;
                txtRESPIRATOR_DAYS.Text = "";
                rdoIS_RPT_PNEUMONIA_INFECTION_Y.Checked = false;
                rdoIS_RPT_PNEUMONIA_INFECTION_N.Checked = false;
            }
        }
        

        private void radISHAVEINYes_CheckedChanged(object sender, EventArgs e)
        {//�Ƿ�����Ժ
            if (radISHAVEINYes.Checked)
                pISHAVEIN.Visible = true;
            else
                pISHAVEIN.Visible = false;
        }

        private void rdoCOMPLICATING_DISEASE_Y_CheckedChanged(object sender, EventArgs e)
        {//�Ƿ������󲢷�֢���
            if (rdoCOMPLICATING_DISEASE_Y.Checked)
                chkCOMPLICATING_DISEASE.Enabled = true;
            else
            {
                chkCOMPLICATING_DISEASE.Enabled = false;
                foreach (int i in chkCOMPLICATING_DISEASE.CheckedIndices)
                {
                    chkCOMPLICATING_DISEASE.SetItemChecked(i, false);
                }
            }
        }

        private void rdoIS_IATROGENIC_INJURY_Y_CheckedChanged(object sender, EventArgs e)
        {//�Ƿ���ҽԴ���˺����
            if (rdoIS_IATROGENIC_INJURY_Y.Checked)
                chkIS_IATROGENIC_INJURY.Enabled = true;
            else
            {
                chkIS_IATROGENIC_INJURY.Enabled = false;
                foreach (int i in chkIS_IATROGENIC_INJURY.CheckedIndices)
                {
                    chkIS_IATROGENIC_INJURY.SetItemChecked(i, false);
                }
            }
        }

        #endregion
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
