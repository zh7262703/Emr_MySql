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
    /// ����/׹����ҳ�ı༭
    /// ����:������
    /// ʱ��:2013-01-30
    /// </summary>
    public partial class ucCover_Append_DROP : UserControl
    {
        private string PatientId = "";           //��ǰ���˵�����
        private string Cover_Append_id = "";   //��ǰѡ�е�סԺ��ҳ������
        private string option = "-��ѡ��-";    //������ѡֵ
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patientid">��������</param>
        public ucCover_Append_DROP(string patientid)
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
        public ucCover_Append_DROP(string patientid, string cover_append_id)
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
                //����/׹�����ԭ��
                DataSet ds_DROP_REASON = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='DDZCZCYY001'");
                //����/׹���˺��̶�
                DataSet ds_DROP_LEVEL = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='DDZCSHCD001'");
                //�������˵��¼���
                DataSet ds_SCALD_LEVEL = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='HZTSDZJB001'");
                //����Ż�µ��½��
                DataSet ds_VOMIT_RESAULT = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='HZOTDZJG001'");
                //�������⵼�½��
                DataSet ds_OTHER_RESAULT = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='QTYWDZJG001'");

                DataRow dr_DROP_REASON = ds_DROP_REASON.Tables[0].NewRow();
                dr_DROP_REASON["name"] = option;
                dr_DROP_REASON["id"] = "-1";
                ds_DROP_REASON.Tables[0].Rows.InsertAt(dr_DROP_REASON, 0);
                cboDROP_REASON.DataSource = ds_DROP_REASON.Tables[0].DefaultView;
                cboDROP_REASON.DisplayMember = "name";
                cboDROP_REASON.ValueMember = "id";

                DataRow dr_DROP_LEVEL = ds_DROP_LEVEL.Tables[0].NewRow();
                dr_DROP_LEVEL["name"] = option;
                dr_DROP_LEVEL["id"] = "-1";
                ds_DROP_LEVEL.Tables[0].Rows.InsertAt(dr_DROP_LEVEL, 0);
                cboDROP_LEVEL.DataSource = ds_DROP_LEVEL.Tables[0].DefaultView;
                cboDROP_LEVEL.DisplayMember = "name";
                cboDROP_LEVEL.ValueMember = "id";

                DataRow dr_SCALD_LEVEL = ds_SCALD_LEVEL.Tables[0].NewRow();
                dr_SCALD_LEVEL["name"] = option;
                dr_SCALD_LEVEL["id"] = "-1";
                ds_SCALD_LEVEL.Tables[0].Rows.InsertAt(dr_SCALD_LEVEL, 0);
                cboSCALD_LEVEL.DataSource = ds_SCALD_LEVEL.Tables[0].DefaultView;
                cboSCALD_LEVEL.DisplayMember = "name";
                cboSCALD_LEVEL.ValueMember = "id";

                DataRow dr_VOMIT_RESAULT = ds_VOMIT_RESAULT.Tables[0].NewRow();
                dr_VOMIT_RESAULT["name"] = option;
                dr_VOMIT_RESAULT["id"] = "-1";
                ds_VOMIT_RESAULT.Tables[0].Rows.InsertAt(dr_VOMIT_RESAULT, 0);
                cboVOMIT_RESAULT.DataSource = ds_VOMIT_RESAULT.Tables[0].DefaultView;
                cboVOMIT_RESAULT.DisplayMember = "name";
                cboVOMIT_RESAULT.ValueMember = "id";

                DataRow dr_OTHER_RESAULT = ds_OTHER_RESAULT.Tables[0].NewRow();
                dr_OTHER_RESAULT["name"] = option;
                dr_OTHER_RESAULT["id"] = "-1";
                ds_OTHER_RESAULT.Tables[0].Rows.InsertAt(dr_OTHER_RESAULT, 0);
                cboOTHER_RESAULT.DataSource = ds_OTHER_RESAULT.Tables[0].DefaultView;
                cboOTHER_RESAULT.DisplayMember = "name";
                cboOTHER_RESAULT.ValueMember = "id";
            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ��,ԭ��:" + ex.Message);
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

                //--------------------------------����/׹��-----------------------------------------
                string DROP_YN = "";
                string DROP_TIME = "";          //����/׹����������
                string DROP_DETIAL_TIME = "";  //���巢������ʱ��
                string IS_CRISI = "";           //��Ժʱ����Ϊ�߷��ջ��� Y �� N��
                string DROP_SCORE = "";         //����/׹��Σ�س̶�����
                string DROP_REASON = "";        //����/׹�����ԭ��
                string DROP_LEVEL = "";         //����/׹���˺��̶�
                string IS_DROP = "";            //�Ƿ��ٴη������� Y �� N ��
                if (rdoDROP_Y.Checked)
                {
                    DROP_YN = "Y";
                    
                    if (rdoDROP_TIME_GZR.Checked)
                    {
                        DROP_TIME = "1";
                    }
                    else if (rdoDROP_TIME_ZM.Checked)
                    {
                        DROP_TIME = "2";
                    }
                    else if (rdoDROP_TIME_JJR.Checked)
                    {
                        DROP_TIME = "3";
                    }
                    else
                    {
                        label14.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label14.Text + "]δѡ��!");
                        return false;
                    }

                    DROP_DETIAL_TIME = dtpDROP_DETIAL_TIME.Value.ToString("yyyy/MM/dd HH:mm:ss");  //���巢������ʱ��
                    
                    if (rdoIS_CRISI_Y.Checked)
                    {
                        IS_CRISI = "Y";
                    }
                    else if (rdoIS_CRISI_N.Checked)
                    {
                        IS_CRISI = "N";
                    }
                    else
                    {
                        label12.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label12.Text + "]δѡ��!");
                        return false;
                    }

                    
                    if (txtDROP_SCORE.Text.Trim() != "")
                    {
                        DROP_SCORE = txtDROP_SCORE.Text;
                    }
                    else
                    {
                        label11.ForeColor = Color.Red;
                        label10.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label11.Text + "]δ��д!");
                        return false;
                    }

                    
                    if (cboDROP_REASON.SelectedValue != null && cboDROP_REASON.Text != option)
                    {
                        DROP_REASON = cboDROP_REASON.SelectedValue.ToString();
                    }
                    else if (cboDROP_REASON.Items.Count > 1)
                    {
                        label15.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label15.Text + "]δѡ��!");
                        return false;
                    }

                    
                    if (cboDROP_LEVEL.SelectedValue != null && cboDROP_LEVEL.Text != option)
                    {
                        DROP_LEVEL = cboDROP_LEVEL.SelectedValue.ToString();
                    }
                    else if (cboDROP_LEVEL.Items.Count > 1)
                    {
                        label16.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label16.Text + "]δѡ��!");
                        return false;
                    }

                    
                    if (rdoIS_DROP_Y.Checked)
                    {
                        IS_DROP = "Y";
                    }
                    else if (rdoIS_DROP_N.Checked)
                    {
                        IS_DROP = "N";
                    }
                    else
                    {
                        label17.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label17.Text + "]δѡ��!");
                        return false;
                    }
                }
                else if (rdoDROP_N.Checked)
                {
                    DROP_YN = "N";
                }

                

                //--------------------------------����-----------------------------------------------
                string SCALD_YN = "";
                string SCALD_TIME = "";         //���˷�����
                string SCALD_DETIAL_TIME = "";  //���巢������ʱ��

                string IS_SCALD_CRISI = "";     //��Ժʱ����Ϊ�߷��ջ��� Y �� N��
                string SCALD_LEVEL = "";        //���������˺��̶�
                if (rdoSCALD_Y.Checked)
                {
                    SCALD_YN = "Y";
                    
                    if (rdoSCALD_TIME_GZR.Checked)
                    {
                        SCALD_TIME = "1";
                    }
                    else if (rdoSCALD_TIME_ZM.Checked)
                    {
                        SCALD_TIME = "2";
                    }
                    else if (rdoSCALD_TIME_JJR.Checked)
                    {
                        SCALD_TIME = "3";
                    }
                    else
                    {
                        label20.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label20.Text + "]δѡ��!");
                        return false;
                    }

                    SCALD_DETIAL_TIME = dtpSCALD_DETIAL_TIME.Value.ToString("yyyy/MM/dd HH:mm:ss");  //���巢������ʱ��
                   
                    if (rdoIS_SCALD_CRISI_Y.Checked)
                    {
                        IS_SCALD_CRISI = "Y";
                    }
                    else if (rdoIS_SCALD_CRISI_N.Checked)
                    {
                        IS_SCALD_CRISI = "N";
                    }
                    else
                    {
                        label18.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label18.Text + "]δѡ��!");
                        return false;
                    }


                    
                    if (cboSCALD_LEVEL.SelectedValue != null && cboSCALD_LEVEL.Text != option)
                    {
                        SCALD_LEVEL = cboSCALD_LEVEL.SelectedValue.ToString();
                    }
                    else if (cboSCALD_LEVEL.Items.Count > 1)
                    {
                        label21.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label21.Text + "]δѡ��!");
                        return false;
                    }
                }
                else if (rdoSCALD_N.Checked)
                {
                    SCALD_YN = "N";
                }

                

                //--------------------------------Ż��-----------------------------------------------
                string VOMIT_YN = "";
                string VOMIT_TIME = "";         //Ż����
                string VOMIT_DETIAL_TIME = "";  //Ż����ϸʱ��

                string IS_VOMIT_CRISI = "";     //��Ժʱ����Ϊ�߷��ջ��� Y �� N ��
                string VOMIT_RESAULT = "";      //Ż�������뵼�½��
                if (rdoVOMIT_Y.Checked)
                {
                    VOMIT_YN = "Y";
                    
                    if (rdoVOMIT_TIME_GZR.Checked)
                    {
                        VOMIT_TIME = "1";
                    }
                    else if (rdoVOMIT_TIME_ZM.Checked)
                    {
                        VOMIT_TIME = "2";
                    }
                    else if (rdoVOMIT_TIME_JJR.Checked)
                    {
                        VOMIT_TIME = "3";
                    }
                    else
                    {
                        label25.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label25.Text + "]δѡ��!");
                        return false;
                    }

                    VOMIT_DETIAL_TIME = dtpVOMIT_DETIAL_TIME.Value.ToString("yyyy/MM/dd HH:mm:ss");  //Ż����ϸʱ��
                    
                    if (rdoIS_VOMIT_CRISI_Y.Checked)
                    {
                        IS_VOMIT_CRISI = "Y";
                    }
                    else if (rdoIS_VOMIT_CRISI_N.Checked)
                    {
                        IS_VOMIT_CRISI = "N";
                    }
                    else
                    {
                        label23.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label23.Text + "]δѡ��!");
                        return false;
                    }

                    if (cboVOMIT_RESAULT.SelectedValue != null && cboVOMIT_RESAULT.Text != option)
                    {
                        VOMIT_RESAULT = cboVOMIT_RESAULT.SelectedValue.ToString();
                    }
                    else if (cboVOMIT_RESAULT.Items.Count > 1)
                    {
                        label22.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label22.Text + "]δѡ��!");
                        return false;
                    }


                }
                else if (rdoVOMIT_N.Checked)
                {
                    VOMIT_YN = "N";
                }
                        
                

                //--------------------------------����-----------------------------------------------
                string OTHER_YN = "";
                string OTHER_TIME = "";         //����������
                string OTHER_DETIAL_TIME = "";  //����������ϸʱ��

                string IS_OTHER_CRISI = "";     //��Ժʱ����Ϊ�߷��ջ��� Y �� N ��
                string OTHER_RESAULT = "";      //�������
                if (rdoOTHER_Y.Checked)
                {
                    OTHER_YN = "Y";
                    
                    if (rdoOTHER_TIME_GZR.Checked)
                    {
                        OTHER_TIME = "1";
                    }
                    else if (rdoOTHER_TIME_ZM.Checked)
                    {
                        OTHER_TIME = "2";
                    }
                    else if (rdoOTHER_TIME_JJR.Checked)
                    {
                        OTHER_TIME = "3";
                    }
                    else
                    {
                        label29.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label29.Text + "]δѡ��!");
                        return false;
                    }

                    OTHER_DETIAL_TIME = dtpOTHER_DETIAL_TIME.Value.ToString("yyyy/MM/dd HH:mm:ss");  //����������ϸʱ��
                    
                    if (rdoIS_OTHER_CRISI_Y.Checked)
                    {
                        IS_OTHER_CRISI = "Y";
                    }
                    else if (rdoIS_OTHER_CRISI_N.Checked)
                    {
                        IS_OTHER_CRISI = "N";
                    }
                    else
                    {
                        label27.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label27.Text + "]δѡ��!");
                        return false;
                    }

                    
                    if (cboOTHER_RESAULT.SelectedValue != null && cboOTHER_RESAULT.Text != option)
                    {
                        OTHER_RESAULT = cboOTHER_RESAULT.SelectedValue.ToString();
                    }
                    else if (cboOTHER_RESAULT.Items.Count > 1)
                    {
                        label26.ForeColor = Color.Red;
                        App.Msg("��ʾ:[" + label26.Text + "]δѡ��!");
                        return false;
                    }
                }
                else if (rdoOTHER_N.Checked)
                {
                    OTHER_YN = "N";
                }
                


                string Sql = "";

                if (Cover_Append_id == "")
                {
                    Sql = "insert into COVER_APPEND_DROP(PATIENT_ID,DROP_TIME,DROP_DETIAL_TIME,IS_CRISI,DROP_SCORE,DROP_REASON," +
                                                            "DROP_LEVEL,IS_DROP,SCALD_TIME,SCALD_DETIAL_TIME,IS_SCALD_CRISI," +
                                                            "SCALD_LEVEL,VOMIT_TIME,VOMIT_DETIAL_TIME,IS_VOMIT_CRISI," +
                                                            "VOMIT_RESAULT,OTHER_TIME,OTHER_DETIAL_TIME,IS_OTHER_CRISI," +
                                                            "OTHER_RESAULT,CREATE_TIME,USER_ID,DROP_YN,SCALD_YN,VOMIT_YN,OTHER_YN)values({0},'{1}'," +
                                                            "to_timestamp('{2}','syyyy-mm-dd hh24:mi:ss')," +
                                                            "'{3}','{4}','{5}','{6}','{7}','{8}'," +
                                                            "to_timestamp('{9}','syyyy-mm-dd hh24:mi:ss')," +
                                                            "'{10}','{11}','{12}',to_timestamp('{13}','syyyy-mm-dd hh24:mi:ss')," +
                                                            "'{14}','{15}','{16}',to_timestamp('{17}','syyyy-mm-dd hh24:mi:ss')," +
                                                            "'{18}','{19}',to_timestamp('{20}','syyyy-mm-dd hh24:mi'),{21},'{22}','{23}','{24}','{25}')";

                    Sql = string.Format(Sql, PatientId, DROP_TIME, DROP_DETIAL_TIME, IS_CRISI, DROP_SCORE, DROP_REASON,
                                            DROP_LEVEL, IS_DROP, SCALD_TIME, SCALD_DETIAL_TIME, IS_SCALD_CRISI,
                                            SCALD_LEVEL, VOMIT_TIME, VOMIT_DETIAL_TIME, IS_VOMIT_CRISI,
                                            VOMIT_RESAULT, OTHER_TIME, OTHER_DETIAL_TIME, IS_OTHER_CRISI,
                                            OTHER_RESAULT, App.GetSystemTime().ToShortDateString(),
                                            App.UserAccount.UserInfo.User_id,DROP_YN,SCALD_YN,VOMIT_YN,OTHER_YN);
                }
                else
                {
                    Sql = "update COVER_APPEND_DROP set DROP_TIME='{0}',DROP_DETIAL_TIME=to_timestamp('{1}','syyyy-mm-dd hh24:mi:ss')," +
                                                            "IS_CRISI='{2}',DROP_SCORE='{3}',DROP_REASON='{4}',DROP_LEVEL='{5}'," +
                                                            "IS_DROP='{6}',SCALD_TIME='{7}'," +
                                                            "SCALD_DETIAL_TIME=to_timestamp('{8}','syyyy-mm-dd hh24:mi:ss'),IS_SCALD_CRISI='{9}'," +
                                                            "SCALD_LEVEL='{10}',VOMIT_TIME='{11}'," +
                                                            "VOMIT_DETIAL_TIME=to_timestamp('{12}','syyyy-mm-dd hh24:mi:ss'),IS_VOMIT_CRISI='{13}'," +
                                                            "VOMIT_RESAULT='{14}',OTHER_TIME='{15}'," +
                                                            "OTHER_DETIAL_TIME=to_timestamp('{16}','syyyy-mm-dd hh24:mi:ss'),IS_OTHER_CRISI='{17}'," +
                                                            "OTHER_RESAULT='{18}',DROP_YN='{19}',SCALD_YN='{20}',VOMIT_YN='{21}',OTHER_YN='{22}' " + 
                                                            " where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";
                    Sql = string.Format(Sql, DROP_TIME, DROP_DETIAL_TIME, IS_CRISI, DROP_SCORE, DROP_REASON,
                                            DROP_LEVEL, IS_DROP, SCALD_TIME, SCALD_DETIAL_TIME, IS_SCALD_CRISI,
                                            SCALD_LEVEL, VOMIT_TIME, VOMIT_DETIAL_TIME, IS_VOMIT_CRISI,
                                            VOMIT_RESAULT, OTHER_TIME, OTHER_DETIAL_TIME, IS_OTHER_CRISI,
                                            OTHER_RESAULT, DROP_YN, SCALD_YN, VOMIT_YN, OTHER_YN);
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
                string sql = "select DROP_TIME,to_char(DROP_DETIAL_TIME,'YYYY/MM/DD HH24:MI:ss') as DROP_DETIAL_TIME,IS_CRISI," +
                                    "DROP_SCORE,DROP_REASON,DROP_LEVEL,IS_DROP,SCALD_TIME," +
                                    "to_char(SCALD_DETIAL_TIME,'YYYY/MM/DD HH24:MI:ss') as SCALD_DETIAL_TIME,IS_SCALD_CRISI," +
                                    "SCALD_LEVEL,VOMIT_TIME,to_char(VOMIT_DETIAL_TIME,'YYYY/MM/DD HH24:MI:ss') as VOMIT_DETIAL_TIME," +
                                    "IS_VOMIT_CRISI,VOMIT_RESAULT,OTHER_TIME," +
                                    "to_char(OTHER_DETIAL_TIME,'YYYY/MM/DD HH24:MI:ss') as OTHER_DETIAL_TIME,IS_OTHER_CRISI," +
                                    "OTHER_RESAULT,DROP_YN,SCALD_YN,VOMIT_YN,OTHER_YN from COVER_APPEND_DROP where id=" + Cover_Append_id;

                DataTable dt = App.GetDataSet(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        

                        //--------------------------------����/׹��-------------------------------------------
                        if (dt.Rows[i]["DROP_YN"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["DROP_YN"].ToString()=="Y")
                            {
                                rdoDROP_Y.Checked = true;
                                if (dt.Rows[i]["DROP_TIME"].ToString().Trim() != "")       //����/׹����������
                                {
                                    if (dt.Rows[i]["DROP_TIME"].ToString() == "2")
                                    {
                                        rdoDROP_TIME_ZM.Checked = true;
                                    }
                                    else if (dt.Rows[i]["DROP_TIME"].ToString() == "3")
                                    {
                                        rdoDROP_TIME_JJR.Checked = true;
                                    }
                                    else
                                    {
                                        rdoDROP_TIME_GZR.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["DROP_DETIAL_TIME"].ToString().Trim() != "")       //���巢������ʱ��
                                {
                                    dtpDROP_DETIAL_TIME.Text = dt.Rows[i]["DROP_DETIAL_TIME"].ToString();
                                }

                                if (dt.Rows[i]["IS_CRISI"].ToString().Trim() != "")       //��Ժʱ����Ϊ�߷��ջ��� Y �� N��
                                {
                                    if (dt.Rows[i]["IS_CRISI"].ToString() == "Y")
                                    {
                                        rdoIS_CRISI_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_CRISI_N.Checked = true;
                                    }

                                }

                                if (dt.Rows[i]["DROP_SCORE"].ToString().Trim() != "")       //����/׹��Σ�س̶�����
                                {
                                    txtDROP_SCORE.Text = dt.Rows[i]["DROP_SCORE"].ToString();
                                }

                                if (dt.Rows[i]["DROP_REASON"].ToString().Trim() != "")       //����/׹�����ԭ��
                                {
                                    cboDROP_REASON.SelectedValue = dt.Rows[i]["DROP_REASON"].ToString();
                                }

                                if (dt.Rows[i]["DROP_LEVEL"].ToString().Trim() != "")       //����/׹���˺��̶�
                                {
                                    cboDROP_LEVEL.SelectedValue = dt.Rows[i]["DROP_LEVEL"].ToString();
                                }

                                if (dt.Rows[i]["IS_DROP"].ToString().Trim() != "")       //�Ƿ��ٴη������� Y �� N ��
                                {
                                    if (dt.Rows[i]["IS_DROP"].ToString() == "Y")
                                    {
                                        rdoIS_DROP_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_DROP_N.Checked = true;
                                    }

                                }
                            }
                            else if (dt.Rows[i]["DROP_YN"].ToString() == "N")
                            {
                                rdoDROP_N.Checked = true;
                            }
                        } 
                        


                        //--------------------------------����-----------------------------------------------
                        if (dt.Rows[i]["SCALD_YN"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["SCALD_YN"].ToString() == "Y")
                            {
                                rdoSCALD_Y.Checked = true;
                                if (dt.Rows[i]["SCALD_TIME"].ToString().Trim() != "")       //���˷�����
                                {
                                    if (dt.Rows[i]["SCALD_TIME"].ToString() == "2")
                                    {
                                        rdoSCALD_TIME_ZM.Checked = true;
                                    }
                                    else if (dt.Rows[i]["SCALD_TIME"].ToString() == "3")
                                    {
                                        rdoSCALD_TIME_JJR.Checked = true;
                                    }
                                    else
                                    {
                                        rdoSCALD_TIME_GZR.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["SCALD_DETIAL_TIME"].ToString().Trim() != "")       //���巢������ʱ��
                                {
                                    dtpSCALD_DETIAL_TIME.Text = dt.Rows[i]["SCALD_DETIAL_TIME"].ToString();
                                }

                                if (dt.Rows[i]["IS_SCALD_CRISI"].ToString().Trim() != "")       //��Ժʱ����Ϊ�߷��ջ��� Y �� N��
                                {
                                    if (dt.Rows[i]["IS_SCALD_CRISI"].ToString() == "Y")
                                    {
                                        rdoIS_SCALD_CRISI_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_SCALD_CRISI_N.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["SCALD_LEVEL"].ToString().Trim() != "")       //���������˺��̶�
                                {
                                    cboSCALD_LEVEL.SelectedValue = dt.Rows[i]["SCALD_LEVEL"].ToString();
                                }
                            }
                            else if (dt.Rows[i]["SCALD_YN"].ToString() == "N")
                            {
                                rdoSCALD_N.Checked = true;
                            }
                        }
                        


                        //--------------------------------Ż��-----------------------------------------------
                        if (dt.Rows[i]["VOMIT_YN"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["VOMIT_YN"].ToString() == "Y")
                            {
                                rdoVOMIT_Y.Checked = true;
                                if (dt.Rows[i]["VOMIT_TIME"].ToString().Trim() != "")       //Ż����
                                {
                                    if (dt.Rows[i]["VOMIT_TIME"].ToString() == "2")
                                    {
                                        rdoVOMIT_TIME_ZM.Checked = true;
                                    }
                                    else if (dt.Rows[i]["VOMIT_TIME"].ToString() == "3")
                                    {
                                        rdoVOMIT_TIME_JJR.Checked = true;
                                    }
                                    else
                                    {
                                        rdoVOMIT_TIME_GZR.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["VOMIT_DETIAL_TIME"].ToString().Trim() != "")       //Ż����ϸʱ��
                                {
                                    dtpVOMIT_DETIAL_TIME.Text = dt.Rows[i]["VOMIT_DETIAL_TIME"].ToString();
                                }

                                if (dt.Rows[i]["IS_VOMIT_CRISI"].ToString().Trim() != "")       //��Ժʱ����Ϊ�߷��ջ��� Y �� N ��
                                {
                                    if (dt.Rows[i]["IS_VOMIT_CRISI"].ToString() == "Y")
                                    {
                                        rdoIS_VOMIT_CRISI_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_VOMIT_CRISI_N.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["VOMIT_RESAULT"].ToString().Trim() != "")       //Ż�������뵼�½��
                                {
                                    cboVOMIT_RESAULT.SelectedValue = dt.Rows[i]["VOMIT_RESAULT"].ToString();
                                }
                            }
                            else if (dt.Rows[i]["VOMIT_YN"].ToString() == "N")
                            {
                                rdoVOMIT_N.Checked = true;
                            }
                        }
                        


                        //--------------------------------����-----------------------------------------------
                        if (dt.Rows[i]["OTHER_YN"].ToString().Trim() != "")
                        {
                            if (dt.Rows[i]["OTHER_YN"].ToString() == "Y")
                            {
                                rdoOTHER_Y.Checked = true;
                                if (dt.Rows[i]["OTHER_TIME"].ToString().Trim() != "")       //����������
                                {
                                    if (dt.Rows[i]["OTHER_TIME"].ToString() == "2")
                                    {
                                        rdoOTHER_TIME_ZM.Checked = true;
                                    }
                                    else if (dt.Rows[i]["OTHER_TIME"].ToString() == "3")
                                    {
                                        rdoOTHER_TIME_JJR.Checked = true;
                                    }
                                    else
                                    {
                                        rdoOTHER_TIME_GZR.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["OTHER_DETIAL_TIME"].ToString().Trim() != "")       //����������ϸʱ��
                                {
                                    dtpOTHER_DETIAL_TIME.Text = dt.Rows[i]["OTHER_DETIAL_TIME"].ToString();
                                }

                                if (dt.Rows[i]["IS_OTHER_CRISI"].ToString().Trim() != "")       //��Ժʱ����Ϊ�߷��ջ��� Y �� N ��
                                {
                                    if (dt.Rows[i]["IS_OTHER_CRISI"].ToString() == "Y")
                                    {
                                        rdoIS_OTHER_CRISI_Y.Checked = true;
                                    }
                                    else
                                    {
                                        rdoIS_OTHER_CRISI_N.Checked = true;
                                    }
                                }

                                if (dt.Rows[i]["OTHER_RESAULT"].ToString().Trim() != "")       //�������
                                {
                                    cboOTHER_RESAULT.SelectedValue = dt.Rows[i]["OTHER_RESAULT"].ToString();
                                }
                            }
                            else if (dt.Rows[i]["OTHER_YN"].ToString() == "N")
                            {
                                rdoOTHER_N.Checked = true;
                            }
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

        /// <summary>
        /// ����/׹��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoDROP_Y_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDROP_Y.Checked)
            {
                pDROP_TIME.Enabled = true;
                dtpDROP_DETIAL_TIME.Enabled = true;
                pIS_CRISI.Enabled = true;
                txtDROP_SCORE.Enabled = true;
                cboDROP_REASON.Enabled = true;
                cboDROP_LEVEL.Enabled = true;
                pIS_DROP.Enabled = true;
            }
            else
            {
                pDROP_TIME.Enabled = false;
                dtpDROP_DETIAL_TIME.Enabled = false;
                pIS_CRISI.Enabled = false;
                txtDROP_SCORE.Enabled = false;
                cboDROP_REASON.Enabled = false;
                cboDROP_LEVEL.Enabled = false;
                pIS_DROP.Enabled = false;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoSCALD_Y_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoSCALD_Y.Checked)
            {
                pSCALD_TIME.Enabled = true;
                dtpSCALD_DETIAL_TIME.Enabled = true;
                pIS_SCALD_CRISI.Enabled = true;
                cboSCALD_LEVEL.Enabled = true;
            }
            else
            {
                pSCALD_TIME.Enabled = false;
                dtpSCALD_DETIAL_TIME.Enabled = false;
                pIS_SCALD_CRISI.Enabled = false;
                cboSCALD_LEVEL.Enabled = false;
            }
        }

        /// <summary>
        /// Ż����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoVOMIT_Y_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoVOMIT_Y.Checked)
            {
                pVOMIT_TIME.Enabled = true;
                dtpVOMIT_DETIAL_TIME.Enabled = true;
                pIS_VOMIT_CRISI.Enabled = true;
                cboVOMIT_RESAULT.Enabled = true;
            }
            else
            {
                pVOMIT_TIME.Enabled = false;
                dtpVOMIT_DETIAL_TIME.Enabled = false;
                pIS_VOMIT_CRISI.Enabled = false;
                cboVOMIT_RESAULT.Enabled = false;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoOTHER_Y_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOTHER_Y.Checked)
            {
                pOTHER_TIME.Enabled = true;
                dtpOTHER_DETIAL_TIME.Enabled = true;
                pIS_OTHER_CRISI.Enabled = true;
                cboOTHER_RESAULT.Enabled = true;
            }
            else
            {
                pOTHER_TIME.Enabled = false;
                dtpOTHER_DETIAL_TIME.Enabled = false;
                pIS_OTHER_CRISI.Enabled = false;
                cboOTHER_RESAULT.Enabled = false;
            }
        }


    }
}
