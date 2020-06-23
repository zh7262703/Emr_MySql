using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using System.Collections;
using System.IO;

namespace Base_Function.BLL_NURSE.First_cases
{
    /// <summary>
    /// ������ҳ�ı༭
    /// ����:������
    /// ʱ��:2013-01-28
    /// </summary>
    public partial class ucCover_Append_OPER : UserControl
    {

        private string PatientId = "";           //��ǰ���˵�����
        private string Cover_Append_id = "";   //��ǰѡ�е�סԺ��ҳ������
        private string option = "-��ѡ��-";    //������ѡֵ
        ArrayList al = new ArrayList();

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patientid">��������</param>
        public ucCover_Append_OPER(string patientid)
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
        public ucCover_Append_OPER(string patientid, string cover_append_id)
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
            //���磺����С�ꡱ������� ��Ϣ������ ��   100000
            //select * from t_text a where a.textname like '%������¼%'
            //select t.tid from t_patients_doc t where t.patient_id=100000 and (t.textkind_id=389 or (t.textkind_id=151))
            //http://192.168.168.101/WebSite1/PATIENT_DOC/100000/9999.xml
            string sqlid = "select t.tid from t_patients_doc t where t.patient_id=" + PatientId + " and (t.textkind_id=389 or t.textkind_id=151)";
            DataSet ds_id = App.GetDataSet(sqlid);
            if (ds_id.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds_id.Tables[0].Rows.Count; i++)
                {
                    // @"http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite2/Service.asmx";
                    string urlxml = @"http://" + Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", Application.StartupPath + "\\Config.ini")) + @"/WebSite1/PATIENT_DOC/" + PatientId + @"/" + ds_id.Tables[0].Rows[i]["tid"].ToString() + ".xml";
                    //if (File.Exists(urlxml))
                    //{//����
                    try
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(urlxml);
                        XmlNodeList nodes = doc.SelectNodes("/emrtextdoc/text");
                        foreach (XmlNode node in nodes)
                        {//"2013-02-01��01:01--2013-02-02��02:02"
                            string str = node.InnerText;
                            str = str.Substring(str.LastIndexOf("����ʱ�䣺") + 5, str.LastIndexOf("��ǰ��ϣ�") - str.LastIndexOf("����ʱ�䣺") - 6);
                            if (str != "˫��ѡ��ʱ��--˫��ѡ��ʱ��")
                            {
                                str = str.Replace("��", " ");
                                al.Add(str);
                            }
                        }
                        Console.Read();
                    }
                    catch (Exception)
                    {
                        al.Add("---------��ǰ����ʱ��δ��ȡ---------");
                    }
                        
                    //}
                    //else
                    //{//������
                    //    al.Add("---------��ǰ����ʱ��δ��ȡ---------");
                    //}
                    
                }
                cboSTART_TIME.DataSource = al;
                label15.Visible = true;
                cboSTART_TIME.Visible = true;
            }
            else
            {
                label15.Visible = false;
                cboSTART_TIME.Visible = false;
            }
            


            //������λ
            DataSet ds_SSBW = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='SSBW001'");
            //����ҰƤ׼������
            DataSet ds_SSYP = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='SSYPZBFF001'");

            DataRow dr_SSBW = ds_SSBW.Tables[0].NewRow();
            dr_SSBW["name"] = option;
            dr_SSBW["id"] = "-1";
            ds_SSBW.Tables[0].Rows.InsertAt(dr_SSBW, 0);
            cboOPER_PART.DataSource = ds_SSBW.Tables[0].DefaultView;
            cboOPER_PART.DisplayMember = "name";
            cboOPER_PART.ValueMember = "id";

            DataRow dr_SSYP = ds_SSYP.Tables[0].NewRow();
            dr_SSYP["name"] = option;
            dr_SSYP["id"] = "-1";
            ds_SSYP.Tables[0].Rows.InsertAt(dr_SSYP, 0);
            cboOPER_FIELD_SKIN.DataSource = ds_SSYP.Tables[0].DefaultView;
            cboOPER_FIELD_SKIN.DisplayMember = "name";
            cboOPER_FIELD_SKIN.ValueMember = "id";

            

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

                string START_TIME = dtpSTART_TIME.Value.ToString("yyyy/MM/dd HH:mm");     //������ʼʱ��

                string END_TIME = dtpEND_TIME.Value.ToString("yyyy/MM/dd HH:mm");      //��������ʱ��

                if (dtpSTART_TIME.Value >= dtpEND_TIME.Value)
                {
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label1.Text + "]���ܴ��ڵ���[" + label2.Text + "]!");
                    return false;
                }

                string OPER_PROPERTY = ""; //��������
                if (rdoOPER_PROPERTY_ZQSS.Checked)
                {
                    OPER_PROPERTY = "1";
                }
                else if (rdoOPER_PROPERTY_JZSS.Checked)
                {
                    OPER_PROPERTY = "2";
                }
                else if (rdoOPER_PROPERTY_XZSS.Checked)
                {
                    OPER_PROPERTY = "3";
                }
                else if (rdoOPER_PROPERTY_BFZSS.Checked)
                {
                    OPER_PROPERTY = "4";
                }
                else if (rdoOPER_PROPERTY_FYQSS.Checked)
                {
                    OPER_PROPERTY = "5";
                }
                else if (rdoOPER_PROPERTY_BYYYX.Checked)
                {
                    OPER_PROPERTY = "6";
                }
                else if (rdoOPER_PROPERTY_WYYYX.Checked)
                {
                    OPER_PROPERTY = "7";
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label3.Text + "]δѡ��!");
                    return false;
                }

                string OPER_PART = "";     //������λ
                if (cboOPER_PART.SelectedValue != null && cboOPER_PART.Text != option)
                {
                    OPER_PART = cboOPER_PART.SelectedValue.ToString();
                }
                else if (cboOPER_PART.Items.Count>1)
                {
                    label4.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label4.Text + "]δѡ��!");
                    return false;
                }

                string ANAESTHESIA_LEVEL = "";   //����ּ�
                if (rdoANAESTHESIA_LEVEL_1.Checked)
                {
                    ANAESTHESIA_LEVEL = "1";
                }
                else if (rdoANAESTHESIA_LEVEL_2.Checked)
                {
                    ANAESTHESIA_LEVEL = "2";
                }
                else if (rdoANAESTHESIA_LEVEL_3.Checked)
                {
                    ANAESTHESIA_LEVEL = "3";
                }
                else if (rdoANAESTHESIA_LEVEL_4.Checked)
                {
                    ANAESTHESIA_LEVEL = "4";
                }
                else if (rdoANAESTHESIA_LEVEL_5.Checked)
                {
                    ANAESTHESIA_LEVEL = "5";
                }
                else if (rdoANAESTHESIA_LEVEL_6.Checked)
                {
                    ANAESTHESIA_LEVEL = "6";
                }
                else
                {
                    label5.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label5.Text + "]δѡ��!");
                    return false;
                }

                string OPER_INFECT_LEVEL = "";   //������Ⱦ���յȼ�
                if (rdoOPER_INFECT_LEVEL_0.Checked)
                {
                    OPER_INFECT_LEVEL = "0";
                }
                else if (rdoOPER_INFECT_LEVEL_1.Checked)
                {
                    OPER_INFECT_LEVEL = "1";
                }
                else if (rdoOPER_INFECT_LEVEL_2.Checked)
                {
                    OPER_INFECT_LEVEL = "2";
                }
                else if (rdoOPER_INFECT_LEVEL_3.Checked)
                {
                    OPER_INFECT_LEVEL = "3";
                }
                else
                {
                    label6.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label6.Text + "]δѡ��!");
                    return false;
                }

                string OPER_IFCT_PART_TYPE = "";  //������Ⱦ��λ����
                if (rdoOPER_IFCT_PART_TYPE_QKQB.Checked)
                {
                    OPER_IFCT_PART_TYPE = "1";
                }
                else if (rdoOPER_IFCT_PART_TYPE_QKSB.Checked)
                {
                    OPER_IFCT_PART_TYPE = "2";
                }
                else if (rdoOPER_IFCT_PART_TYPE_QGBW.Checked)
                {
                    OPER_IFCT_PART_TYPE = "3";
                }
                else if (rdoOPER_IFCT_PART_TYPE_QXBW.Checked)
                {
                    OPER_IFCT_PART_TYPE = "4";
                }
                else
                {
                    label7.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label7.Text + "]δѡ��!");
                    return false;
                }

                string OPER_FIELD_SKIN = "";      //����ҰƤ׼������
                if (cboOPER_FIELD_SKIN.SelectedValue != null && cboOPER_FIELD_SKIN.Text != option)
                {
                    OPER_FIELD_SKIN = cboOPER_FIELD_SKIN.SelectedValue.ToString();
                }
                else if (cboOPER_FIELD_SKIN.Items.Count > 1)
                {
                    label8.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label8.Text + "]δѡ��!");
                    return false;
                }

                string IS_OTHER_TIME = "";        //�Ƿ�Ԥ������ �� Y �� N
                if (rdoIS_OTHER_TIME_Y.Checked)
                {
                    IS_OTHER_TIME = "Y";
                }
                else if (rdoIS_OTHER_TIME_N.Checked)
                {
                    IS_OTHER_TIME = "N";
                }
                else
                {
                    label11.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label11.Text + "]δѡ��!");
                    return false;
                }

                string IS_NEW_TARGET = "";        //��չ�����Ƿ�Ϊ�¼���������Ŀ  �� Y �� N
                if (rdoIS_NEW_TARGET_Y.Checked)
                {
                    IS_NEW_TARGET = "Y";
                }
                else if (rdoIS_NEW_TARGET_N.Checked)
                {
                    IS_NEW_TARGET = "N";
                }
                else
                {
                    label9.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label9.Text + "]δѡ��!");
                    return false;
                }

                string IS_IN_OPER = "";             //�Ƿ�Ϊ��������  �� Y �� N
                if (rdoIS_IN_OPER_Y.Checked)
                {
                    IS_IN_OPER = "Y";
                }
                else if (rdoIS_IN_OPER_N.Checked)
                {
                    IS_IN_OPER = "N";
                }
                else
                {
                    label12.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label12.Text + "]δѡ��!");
                    return false;
                }

                string IS_FOREIGN_MATTER = "";      //�Ƿ���������    �� Y �� N
                if (rdoIS_FOREIGN_MATTER_Y.Checked)
                {
                    IS_FOREIGN_MATTER = "Y";
                }
                else if (rdoIS_FOREIGN_MATTER_N.Checked)
                {
                    IS_FOREIGN_MATTER = "N";
                }
                else
                {
                    label10.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label10.Text + "]δѡ��!");
                    return false;
                }

                string BLOOD_IN_OPER = "";          //�����г�Ѫ��
                if (txtBLOOD_IN_OPER.Text.Trim()!="")
                {
                    BLOOD_IN_OPER = txtBLOOD_IN_OPER.Text;
                }
                else
                {
                    label13.ForeColor = Color.Red;
                    App.Msg("��ʾ:[" + label13.Text + "]δ��д!");
                    return false;
                }

                string Sql = "";
                //if (START_TIME==""||END_TIME==""||OPER_PROPERTY==""||OPER_PART==""||
                //                         ANAESTHESIA_LEVEL==""||OPER_INFECT_LEVEL==""||OPER_IFCT_PART_TYPE==""||
                //                         OPER_FIELD_SKIN==""||IS_OTHER_TIME==""||IS_NEW_TARGET==""||IS_IN_OPER==""||
                //                         IS_FOREIGN_MATTER==""||BLOOD_IN_OPER=="")
                //{
                //    App.MsgWaring("������δ��д��ѡ�����!");
                //    return;
                //}
                if (Cover_Append_id=="")
                {
                    Sql = "insert into COVER_APPEND_OPER(PATIENT_ID,START_TIME,END_TIME,OPER_PROPERTY,OPER_PART," +
                                                         "ANAESTHESIA_LEVEL,OPER_INFECT_LEVEL,OPER_IFCT_PART_TYPE," +
                                                         "OPER_FIELD_SKIN,IS_OTHER_TIME,IS_NEW_TARGET,IS_IN_OPER," +
                                                         "IS_FOREIGN_MATTER,BLOOD_IN_OPER,CREATE_TIME,USER_ID)values(" +
                                                         "{0},to_timestamp('{1}','syyyy-mm-dd hh24:mi'),"+
                                                         "to_timestamp('{2}','syyyy-mm-dd hh24:mi'),'{3}','{4}','{5}',"+
                                                         "'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',"+
                                                         "to_timestamp('{14}','syyyy-mm-dd hh24:mi'),'{15}')";
                    Sql=string.Format(Sql,PatientId,START_TIME,END_TIME,OPER_PROPERTY,OPER_PART,
                                         ANAESTHESIA_LEVEL,OPER_INFECT_LEVEL,OPER_IFCT_PART_TYPE,
                                         OPER_FIELD_SKIN,IS_OTHER_TIME,IS_NEW_TARGET,IS_IN_OPER,
                                         IS_FOREIGN_MATTER,BLOOD_IN_OPER, App.GetSystemTime().ToShortDateString(), 
                                         App.UserAccount.UserInfo.User_id);
                }
                else
	            {
                    Sql = "update COVER_APPEND_OPER set START_TIME=to_timestamp('{0}','syyyy-mm-dd hh24:mi'),"+
                                                        "END_TIME=to_timestamp('{1}','syyyy-mm-dd hh24:mi'),"+
                                                        "OPER_PROPERTY='{2}',OPER_PART='{3}',ANAESTHESIA_LEVEL='{4}',"+
                                                        "OPER_INFECT_LEVEL='{5}',OPER_IFCT_PART_TYPE='{6}',"+
                                                         "OPER_FIELD_SKIN='{7}',IS_OTHER_TIME='{8}',IS_NEW_TARGET='{9}',IS_IN_OPER='{10}',"+
                                                         "IS_FOREIGN_MATTER='{11}',BLOOD_IN_OPER='{12}' where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";
                    Sql = string.Format(Sql,START_TIME,END_TIME,OPER_PROPERTY,OPER_PART,
                                         ANAESTHESIA_LEVEL,OPER_INFECT_LEVEL,OPER_IFCT_PART_TYPE,
                                         OPER_FIELD_SKIN,IS_OTHER_TIME,IS_NEW_TARGET,IS_IN_OPER,
                                         IS_FOREIGN_MATTER,BLOOD_IN_OPER);
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
                string sql = "select to_char(START_TIME,'YYYY/MM/DD HH24:MI') as START_TIME,to_char(END_TIME,'YYYY/MM/DD HH24:MI') as END_TIME," +
                                    "OPER_PROPERTY,OPER_PART,ANAESTHESIA_LEVEL,OPER_INFECT_LEVEL," +
                                    "OPER_IFCT_PART_TYPE,OPER_FIELD_SKIN,IS_OTHER_TIME,IS_NEW_TARGET,IS_IN_OPER,"+
                                    "IS_FOREIGN_MATTER,BLOOD_IN_OPER from cover_append_oper where id=" + Cover_Append_id;
                DataTable dt = App.GetDataSet(sql).Tables[0];
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["START_TIME"].ToString().Trim() != "")//������ʼʱ��
                        {
                            //dtpSTART_TIME.Text = DateTime.ParseExact(dt.Rows[i]["START_TIME"].ToString(), "yyyy/MM/dd HH:mm",null);
                            dtpSTART_TIME.Text = dt.Rows[i]["START_TIME"].ToString();
                        }

                        if (dt.Rows[i]["END_TIME"].ToString().Trim() != "") //��������ʱ��
                        {
                            //dtpEND_TIME.Text = DateTime.ParseExact(dt.Rows[i]["END_TIME"].ToString(), "yyyy/MM/dd HH:mm", null);
                            dtpEND_TIME.Text = dt.Rows[i]["END_TIME"].ToString();
                        }

                        if (dt.Rows[i]["OPER_PROPERTY"].ToString().Trim() != "") //��������
                        {
                            if (dt.Rows[i]["OPER_PROPERTY"].ToString()=="2")
                            {
                                rdoOPER_PROPERTY_JZSS.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_PROPERTY"].ToString()=="3")
                            {
                                rdoOPER_PROPERTY_XZSS.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_PROPERTY"].ToString()=="4")
                            {
                                rdoOPER_PROPERTY_BFZSS.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_PROPERTY"].ToString()=="5")
                            {
                                rdoOPER_PROPERTY_FYQSS.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_PROPERTY"].ToString() == "6")
                            {
                                rdoOPER_PROPERTY_BYYYX.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_PROPERTY"].ToString() == "7")
                            {
                                rdoOPER_PROPERTY_WYYYX.Checked = true;
                            }
                            else
                            {
                                rdoOPER_PROPERTY_ZQSS.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["OPER_PART"].ToString().Trim() != "") //������λ
                        {
                            cboOPER_PART.SelectedValue = dt.Rows[i]["OPER_PART"].ToString();
                        }

                        if (dt.Rows[i]["ANAESTHESIA_LEVEL"].ToString().Trim() != "") //����ּ�
                        {
                            if (dt.Rows[i]["ANAESTHESIA_LEVEL"].ToString() == "2")
                            {
                                rdoANAESTHESIA_LEVEL_2.Checked = true;
                            }
                            else if (dt.Rows[i]["ANAESTHESIA_LEVEL"].ToString() == "3")
                            {
                                rdoANAESTHESIA_LEVEL_3.Checked = true;
                            }
                            else if (dt.Rows[i]["ANAESTHESIA_LEVEL"].ToString() == "4")
                            {
                                rdoANAESTHESIA_LEVEL_4.Checked = true;
                            }
                            else if (dt.Rows[i]["ANAESTHESIA_LEVEL"].ToString() == "5")
                            {
                                rdoANAESTHESIA_LEVEL_5.Checked = true;
                            }
                            else if (dt.Rows[i]["ANAESTHESIA_LEVEL"].ToString() == "6")
                            {
                                rdoANAESTHESIA_LEVEL_6.Checked = true;
                            }
                            else
                            {
                                rdoANAESTHESIA_LEVEL_1.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["OPER_INFECT_LEVEL"].ToString().Trim() != "")       //������Ⱦ���յȼ�
                        {
                            if (dt.Rows[i]["OPER_INFECT_LEVEL"].ToString() == "1")
                            {
                                rdoOPER_INFECT_LEVEL_1.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_INFECT_LEVEL"].ToString() == "2")
                            {
                                rdoOPER_INFECT_LEVEL_2.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_INFECT_LEVEL"].ToString() == "3")
                            {
                                rdoOPER_INFECT_LEVEL_3.Checked = true;
                            }
                            else
                            {
                                rdoOPER_INFECT_LEVEL_0.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["OPER_IFCT_PART_TYPE"].ToString().Trim() != "")       //������Ⱦ��λ����
                        {
                            if (dt.Rows[i]["OPER_IFCT_PART_TYPE"].ToString() == "2")
                            {
                                rdoOPER_IFCT_PART_TYPE_QKSB.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_IFCT_PART_TYPE"].ToString() == "3")
                            {
                                rdoOPER_IFCT_PART_TYPE_QGBW.Checked = true;
                            }
                            else if (dt.Rows[i]["OPER_IFCT_PART_TYPE"].ToString() == "4")
                            {
                                rdoOPER_IFCT_PART_TYPE_QXBW.Checked = true;
                            }
                            else
                            {
                                rdoOPER_IFCT_PART_TYPE_QKQB.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["OPER_FIELD_SKIN"].ToString().Trim() != "")               //����ҰƤ׼������
                        {
                            cboOPER_FIELD_SKIN.SelectedValue = dt.Rows[i]["OPER_FIELD_SKIN"].ToString();
                        }

                        if (dt.Rows[i]["IS_OTHER_TIME"].ToString().Trim() != "")               //�Ƿ��������� �� Y �� N
                        {
                            if (dt.Rows[i]["IS_OTHER_TIME"].ToString() == "Y")
                            {
                                rdoIS_OTHER_TIME_Y.Checked = true;
                            }
                            else
                            {
                                rdoIS_OTHER_TIME_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["IS_NEW_TARGET"].ToString().Trim() != "")               //��չ�����Ƿ�Ϊ�¼���������Ŀ  �� Y �� N
                        {
                            if (dt.Rows[i]["IS_NEW_TARGET"].ToString() == "Y")
                            {
                                rdoIS_NEW_TARGET_Y.Checked = true;
                            }
                            else
                            {
                                rdoIS_NEW_TARGET_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["IS_IN_OPER"].ToString().Trim() != "")               //�Ƿ�Ϊ��������  �� Y �� N
                        {
                            if (dt.Rows[i]["IS_IN_OPER"].ToString() == "Y")
                            {
                                rdoIS_IN_OPER_Y.Checked = true;
                            }
                            else
                            {
                                rdoIS_IN_OPER_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["IS_FOREIGN_MATTER"].ToString().Trim() != "")        //�Ƿ���������    �� Y �� N
                        {
                            if (dt.Rows[i]["IS_FOREIGN_MATTER"].ToString() == "Y")
                            {
                                rdoIS_FOREIGN_MATTER_Y.Checked = true;
                            }
                            else
                            {
                                rdoIS_FOREIGN_MATTER_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["BLOOD_IN_OPER"].ToString().Trim() != "")        //�����г�Ѫ��
                        {
                            txtBLOOD_IN_OPER.Text = dt.Rows[i]["BLOOD_IN_OPER"].ToString();
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                App.MsgErr("����ʧ��,ԭ��:"+ex.Message);
            }

        }

        #region �ı�����������
        
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

        #endregion

        /// <summary>
        /// ����ʱ��ѡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSTART_TIME_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = cboSTART_TIME.Text;
            string str1 = str.Substring(0, str.LastIndexOf("--"));
            string str2 = str.Substring(str.LastIndexOf("--") + 2, str.Length - str.LastIndexOf("--") - 2);
            DateTime dt1;
            DateTime dt2;
            if (DateTime.TryParse(str1, out dt1))
            {//�ж��Ƿ���ʱ���ַ���
                dtpSTART_TIME.Text = dt1.ToString();
            }
            if (DateTime.TryParse(str2, out dt2))
            {
                dtpEND_TIME.Text = dt2.ToString();
            }
        }
    }
}
