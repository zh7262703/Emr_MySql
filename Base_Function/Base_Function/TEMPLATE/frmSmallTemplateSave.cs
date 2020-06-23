using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using System.Collections;
using Base_Function.MODEL;
using Base_Function.BASE_COMMON;
using TextEditor;
using TextEditor.TextDocument.Document;

namespace Base_Function.TEMPLATE
{
    public partial class frmSmallTemplateSave : DevComponents.DotNetBar.Office2007Form
    {
        private XmlDocument xmldoc;
        private DataTable dataTable;
        private DataRow newrow;
        private ZYTextDocument doc = null;

        public frmSmallTemplateSave()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// ��ʼ��Сģ�屣���
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <param name="treeView1"></param>
        /// <param name="doc"></param>
        public frmSmallTemplateSave(XmlDocument xmldoc,ZYTextDocument doc)
        {
            InitializeComponent();
            this.doc = doc;           
            this.xmldoc = xmldoc;

           
        }



        //Сģ�����
        private void InitSmallTypeList()
        {        
            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='174'");
            //��ʼ������ϵͳ����
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "��ѡ��...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboModelType.DataSource = dataTable.DefaultView;
            this.cboModelType.ValueMember = "ID";
            this.cboModelType.DisplayMember = "Name";            
        }

        /// <summary>
        /// ��ʼ������
        /// </summary>
        private void IniSection()
        {
            DataSet ds = App.GetDataSet("select sid,section_name from t_sectioninfo");
            this.cmbSection.DataSource = ds.Tables[0].DefaultView;
            this.cmbSection.ValueMember = "sid";
            this.cmbSection.DisplayMember = "section_name";
        }

        private void frmSmallTemplateSave_Load(object sender, EventArgs e)
        {         
                InitSmallTypeList();
                IniSection();
                cmbSection.Visible = false;
                this.cboModelType.SelectedIndex = 0;
                this.cmbSection.SelectedValue = 0;                          
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Class_Patients cpd = new Class_Patients();
            string modeltype;
            //string SectionId = "";

            if (cboModelType.Text == "��ѡ��...")
            {
                App.Msg("��ѡ��Сģ�����ͣ�");
                cboModelType.Focus();
                return;
            }
                //ģ��Id
                cpd.Tid = App.GenId("T_TempPlate", "TID");

                modeltype = cboModelType.SelectedValue.ToString();  //����Id

                //ʹ�÷�Χ
                if (this.rdoPersonal.Checked == true)
                {
                    cpd.TempPlate_Level = 'P'; //����
                }
                if (this.rdoSection.Checked == true)
                {
                    cpd.TempPlate_Level = 'S'; //����                   
                }                

                cpd.TName = txtAutoTPName.Text;  //ģ������
             
                cpd.Ages = -1;

                //�Ա�
                if (rdoSexNull.Checked)
                {
                    cpd.Sex = 'N';
                }
                else if (rdoMale.Checked)
                {
                    cpd.Sex = '0';
                }
                else if (rdoFemale.Checked)
                {
                    cpd.Sex = '1';
                }

                cpd.Section_ID = 0;
                //����ID
                if (App.UserAccount.CurrentSelectRole.Role_name != "ϵͳ����Ա")
                    cpd.Section_ID = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Section_Id);
                else
                {
                    if (cmbSection.Visible)
                    {
                        cpd.Section_ID = Convert.ToInt32(cmbSection.SelectedValue);
                    }
                }

                //����ID
                if (App.UserAccount.CurrentSelectRole.Sickarea_Id != string.Empty)
                    cpd.SickArea_ID = Convert.ToInt32(App.UserAccount.CurrentSelectRole.Sickarea_Id);

                //����ʱ��
                cpd.Create_Time = this.dtpTime.Value.ToString("yyyy-MM-dd HH:mm");

                //������ID
                cpd.Creator_ID = Convert.ToInt32(App.UserAccount.Account_id);

                ArrayList Sqls = new ArrayList();

                //����Ĭ��ģ��
                string ISDEFAULT = "N";               


                //�����Ǹ��»�������
                string temp = "";              
                DataSet samedocs = App.GetDataSet("select tid from T_TempPlate where tname='" + cpd.TName + "' and TEMPTYPE='S'");
                if (samedocs.Tables[0] != null)
                {
                    if (samedocs.Tables[0].Rows.Count > 0)
                    {
                        App.MsgWaring("�Ѿ�������ͬ���Ƶ����飬�����޸�����");
                        return;
                    }
                }
               

                //����ģ���
                if (cpd.Section_ID != 0)
                {
                    temp = "insert into T_TempPlate(tid, tname, shortcut, text_type, tempplate_level, sex, ages, sickarea_id, creator_id, create_time, updater_id, update_time, verify_id1, verify_time1, verify_id2, verify_time2, verify_sign, isdiag, enable_flag,ISDEFAULT,SECTION_ID,SMALLTEMPTYPE,TEMPTYPE) values(" + cpd.Tid + ",'" + cpd.TName + "','" + cpd.Shortcut + "',"
                                    + "'" + cpd.TextKind + "','" + cpd.TempPlate_Level + "','" + cpd.Sex + "'," + cpd.Ages + ","
                                    + cpd.SickArea_ID + "," + cpd.Creator_ID + ",to_timestamp("
                                    + " '" + cpd.Create_Time + "','yyyy-MM-dd HH24:mi')," + cpd.Updater_ID + ",'" + cpd.Update_Time + "'," + cpd.Verify_ID1 + ","
                                    + "'" + cpd.Verify_Time1 + "'," + cpd.Verify_ID2 + ",'" + cpd.Verify_Time2 + "','" + cpd.Verify_Sign + "',"
                                    + "'N','N','" + ISDEFAULT + "'," + cpd.Section_ID + ",'" + modeltype + "','S')";

                }
                else
                {
                    temp = "insert into T_TempPlate(tid, tname, shortcut, text_type, tempplate_level, sex, ages, sickarea_id, creator_id, create_time, updater_id, update_time, verify_id1, verify_time1, verify_id2, verify_time2, verify_sign, isdiag, enable_flag,ISDEFAULT,SECTION_ID,SMALLTEMPTYPE,TEMPTYPE) values(" + cpd.Tid + ",'" + cpd.TName + "','" + cpd.Shortcut + "',"
                                                       + "'" + cpd.TextKind + "','" + cpd.TempPlate_Level + "','" + cpd.Sex + "'," + cpd.Ages + ","
                                                       + cpd.SickArea_ID + "," + cpd.Creator_ID + ",to_timestamp("
                                                       + " '" + cpd.Create_Time + "','yyyy-MM-dd HH24:mi')," + cpd.Updater_ID + ",'" + cpd.Update_Time + "'," + cpd.Verify_ID1 + ","
                                                       + "'" + cpd.Verify_Time1 + "'," + cpd.Verify_ID2 + ",'" + cpd.Verify_Time2 + "','" + cpd.Verify_Sign + "',"
                                                       + "'N','N','" + ISDEFAULT + "'," + cpd.Section_ID + ",'" + modeltype + "','S')";
                }
                Sqls.Add(temp);

                /*
                 * �Ƴ�����timeTitle���Ե�div�ڵ�
                 */
                XmlNode root = xmldoc.FirstChild;
                bool atrribue = false;
                foreach (XmlNode firstNode in root.ChildNodes)
                {
                    if (firstNode.Name == "body")
                    {
                        foreach (XmlNode secondNode in firstNode.ChildNodes)
                        {
                            if (secondNode.Name == "div")
                            {

                                if (secondNode != null)
                                {
                                    for (int i = 0; i < secondNode.Attributes.Count; i++)
                                    {
                                        if (secondNode.Attributes[i].Name.Trim().ToLower() == "timetitle")
                                            atrribue = true;
                                    }

                                    if (atrribue)
                                    {
                                        firstNode.RemoveChild(secondNode);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (atrribue)
                        break;
                }

                 

                string temp3 = this.doc.InsertLableContent(cpd.Tid, xmldoc.OuterXml);
                if (temp3.Trim() == "")
                {
                    App.MsgErr("����ʧ�ܣ�");
                    Template.fmT.MyDoc.ClearContent();
                    this.Close();
                    return;
                }

                string[] AddSqls = new string[Sqls.Count];

                for (int i = 0; i < Sqls.Count; i++)
                {
                    AddSqls[i] = Sqls[i].ToString();
                }

                int x = App.ExecuteBatch(AddSqls);

                if (x > 0)
                {
                    App.Msg("ģ�汣��ɹ�!");
                    this.Close();                   
                }
                else
                {
                    App.MsgErr("����ʧ�ܣ�");
                }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdoPersonal_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoPersonal.Checked)
            {
                if (App.UserAccount.CurrentSelectRole.Section_Id != string.Empty)
                {
                    if (App.UserAccount.CurrentSelectRole.Role_name != "ϵͳ����Ա")
                    {
                        cmbSection.Visible = false;
                    }
                    else
                    {
                        cmbSection.Visible = true;
                    }
                }
            }
            else
            {
                cmbSection.Visible = false;
            }
        }
    }
}