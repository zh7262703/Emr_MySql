using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_FOLLOW.Element;
using System.Collections;
using Base_Function.BASE_COMMON;



namespace Base_Function.BLL_FOLLOW
{
    public partial class frmFollowInfo : DevComponents.DotNetBar.Office2007Form
    {
        string FollowId = "";           //��ǰѡ�е���ü�¼����
        private string followName = "";  //��������
        private string userIds = "";    //�洢�û�ID
        private string sectionIds = ""; //��ſ���ID
        private string icd9codes = "";  //�洢icd9����
        private string icd10codes = ""; //�洢icd10����
        private string starttime = "";  //�洢�ο�ʱ��
        private int defaultdays =0;   //����״�Ĭ������
        private string followTimeType ="";    //������ʱ������
        private string followWrite_Type=""; //�������������
        private string definefollow = "";  //���ѭ������
        private string creattime = "";   //����ʱ��
        private string isenable = "";       //�Ƿ���Ч
        private string ismain = "";     //�Ƿ�Ϊ�����
        private string finishType = ""; //������÷�ʽ����������ʱ�䣩    
        private string maintain_section = "";   //ά������        
      

        public frmFollowInfo(string followid)
        {

            InitializeComponent();
            FollowId = "";
            FollowId = followid;
            IniFollowType();
            refresh();
            if (FollowId != "")
            {
                IniData(FollowId);
            }
            {
                label2.Visible = false;
                ucUser.Visible = false;
                buttonX2.Visible = false;
            }
        }
        /// <summary>
        /// ��ȡ����ʵ��
        /// </summary>
        /// <param name="FollowId"></param>
        private void IniData(string FollowId)
        { 
            /*
             * ���س���ǰ����ѡ�񷽰���������Ϣ
             */
            DataSet dsTempInfo = App.GetDataSet("select * from t_follow_info where id=" + FollowId + "");
            Class_FollowInfo info = new Class_FollowInfo();
            info.Id = dsTempInfo.Tables[0].Rows[0]["id"].ToString();
            info.Follow_name = dsTempInfo.Tables[0].Rows[0]["Follow_name"].ToString();
            info.Section_ids = dsTempInfo.Tables[0].Rows[0]["Section_ids"].ToString();
            info.Section_names = dsTempInfo.Tables[0].Rows[0]["Section_names"].ToString();
            info.Icd9codes = dsTempInfo.Tables[0].Rows[0]["Icd9codes"].ToString();
            info.Icd10codes = dsTempInfo.Tables[0].Rows[0]["Icd10codes"].ToString();
            info.Ismaindiag = dsTempInfo.Tables[0].Rows[0]["Ismaindiag"].ToString();
            info.Followtype = dsTempInfo.Tables[0].Rows[0]["Followtype"].ToString();
            info.Defaultdays = dsTempInfo.Tables[0].Rows[0]["Defaultdays"].ToString();
            info.Definefollows = dsTempInfo.Tables[0].Rows[0]["Definefollows"].ToString();
            info.Createtime = dsTempInfo.Tables[0].Rows[0]["Createtime"].ToString();
            info.Exec_sections = dsTempInfo.Tables[0].Rows[0]["Exec_sections"].ToString();
            info.Exec_secnames = dsTempInfo.Tables[0].Rows[0]["Exec_secnames"].ToString();
            info.Exec_sickarea = dsTempInfo.Tables[0].Rows[0]["Exec_sickarea"].ToString();
            info.Exec_sickareanames = dsTempInfo.Tables[0].Rows[0]["Exec_sickareanames"].ToString();
            info.FinishType = dsTempInfo.Tables[0].Rows[0]["FinishType"].ToString();
            info.Isenable = dsTempInfo.Tables[0].Rows[0]["Isenable"].ToString();
            info.Startingtime = dsTempInfo.Tables[0].Rows[0]["Startingtime"].ToString();
            info.Followtextid = dsTempInfo.Tables[0].Rows[0]["followtextid"].ToString();
            IniControls(info);

        }

        /// <summary>
        /// ���ؿؼ���Ϣ
        /// </summary>
        public void IniControls(Class_FollowInfo info)
        {
            if (info != null)
            {
                txtFollowName.Text = info.Follow_name;

                //������ؿ���
                txtExecSecs.Text = info.Exec_secnames;
                txtExecSecs.Tag = info.Exec_sections;
                //������ز���
                txtExecSickAeras.Text = info.Exec_sickareanames;
                txtExecSickAeras.Tag = info.Exec_sickarea;
                //���ز�����ؿ���
                txtSection.Text = info.Section_names;
                txtSection.Tag = info.Section_ids;
                //����
                if (icd9codes != "")
                {
                    DataSet ds_icd9 = App.GetDataSet("select code ,name  from oper_def_icd9");
                    string[] opred = info.Icd9codes.Split(',');
                    string opredname = "";

                    for (int i = 0; i < opred.Length; i++)
                    {
                        for (int j = 0; j < ds_icd9.Tables[0].Rows.Count; j++)
                            if (opred[i] == ds_icd9.Tables[0].Rows[j][0].ToString())
                            {
                                opredname = ds_icd9.Tables[0].Rows[j][1].ToString();
                                ucICD9.setWidth(ucICD9.Width);
                                ucElement element = new ucElement(opredname, opred[i]);
                                ucICD9.createUser(element);
                                break;
                            }
                    }
                }
                if (info.Icd10codes != "")
                {
                    DataSet dsIcd10 = App.GetDataSet("select code ,name  from diag_def_icd10");
                    string[] diag = info.Icd10codes.Split(',');
                    string diagName = "";
                    for (int i = 0; i < diag.Length; i++)
                    {

                        for (int j = 0; j < dsIcd10.Tables[0].Rows.Count; j++)
                            if (diag[i] == dsIcd10.Tables[0].Rows[j][0].ToString())
                            {
                                diagName = dsIcd10.Tables[0].Rows[j][1].ToString();
                                ucICD10.setWidth(ucICD10.Width);
                                ucElement element = new ucElement(diagName, diag[i]);
                                ucICD10.createUser(element);
                                break;
                            }
                    }
                }
                //�Ƿ������
                if (info.Ismaindiag == "Y")
                    checkMain.Checked = true;
                else
                    checkMain.Checked = false;
                //Ĭ�ϲο�ʱ��
                cmbStartTime.Text = info.Startingtime;
                //�״�Ĭ��ʱ��
                txtDefaultDay.Text = info.Defaultdays;
                //��÷�ʽ
                if (info.Followtype != "")
                {
                    grpBoxDefineTime.Enabled = false;
                    int i = 0;
                    foreach (Object ob in cmbFollowTimeType.Items)
                    {
                        DataRowView drv = ob as DataRowView;
                        string value = drv["typename"].ToString();
                        if (value == info.Followtype)
                        {
                            cmbFollowTimeType.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                //���ѭ����ʽ
                else
                {
                    string times;
                    string[] days = info.Definefollows.Split(',');
                    for (int i = 0; i < days.Length; i++)
                    {
                        int temp = i + 1;
                        times = "��" + temp + "��";
                        dgvDefineTime.Rows.Add(false, times, days[i]);
                    }

                }
                //
                if (info.FinishType != "")
                {
                    ckbEnd.Checked = true;
                    panel3.Enabled = true;
                    if (info.FinishType.IndexOf("��") != -1)
                    {
                        rbtnTime.Checked = true;
                        rbtnTimes.Checked = false;
                        txtTime.Text = info.FinishType.Substring(0, info.FinishType.IndexOf("��"));
                        cmbYMD2.Text = "��";

                    }
                    else if (info.FinishType.IndexOf("��") != -1)
                    {
                        rbtnTime.Checked = true;
                        rbtnTimes.Checked = false;
                        txtTime.Text = info.FinishType.Substring(0, info.FinishType.IndexOf("��"));
                        cmbYMD2.Text = "��";
                    }
                    else if (info.FinishType.IndexOf("��") != -1)
                    {
                        rbtnTime.Checked = true;
                        rbtnTimes.Checked = false;
                        txtTime.Text = info.FinishType.Substring(0, info.FinishType.IndexOf("��"));
                        cmbYMD2.Text = "��";
                    }
                    else if (info.FinishType.IndexOf("��") != -1)
                    {
                        rbtnTime.Checked = false;
                        rbtnTimes.Checked = true;
                        txtTimes.Text = info.FinishType.Substring(0, info.FinishType.IndexOf("��"));
                    }
                }
                else
                {
                    panel3.Enabled = false;
                    ckbEnd.Checked = false;
                }
                //
                DataSet ds_texttype = App.GetDataSet("select id,textname from t_follow_text where  enable_flag='Y'");
                string[] texttypes = info.Followtextid.Split(',');
                txtFollowType.Tag = info.Followtextid;
                ///������������
                if (info.Followtextid != "")
                {
                    for (int i = 0; i < texttypes.Length; i++)
                    {
                        if (texttypes[i] == "")
                            break;
                        else
                            for (int j = 0; j < ds_texttype.Tables[0].Rows.Count; j++)
                                if (texttypes[i] == ds_texttype.Tables[0].Rows[j][0].ToString())
                                {
                                    if (txtFollowType.Text == "")
                                        txtFollowType.Text = ds_texttype.Tables[0].Rows[j]["textname"].ToString();
                                    else
                                        txtFollowType.Text += "," + ds_texttype.Tables[0].Rows[j]["textname"].ToString();
                                    break;
                                }
                    }
                }

                //�Ƿ���Ч��ѡ��
                if (info.Isenable == "Y")
                    rbtnValid.Checked = true;
                else
                    rbtnVain.Checked = true;
                //����ʱ��
                dataTimeCreate.Value= Convert.ToDateTime(info.Createtime);
            }

        }
        /// <summary>
        /// ��ʼ�����ؼ�
        /// </summary>
        public void refresh()
        {
            grpBoxDefineTime.Enabled = true;    //ѭ��ʱ�����Ϳؼ�
            cmbStartTime.SelectedIndex = 0;     
            cmbYMD.SelectedIndex = 0;
            checkMain.Checked = false;
            txtFollowName.Text = "";
            txtDefaultDay.Text = "";
            txtFollowDefineTime.Text = "";
            txtTimes.Text = "";
            txtTime.Text = "";
            txtTime.Enabled = false;
            cmbYMD2.Enabled = false;
            dgvDefineTime.Columns[1].ReadOnly = true;
            dgvDefineTime.Columns[2].ReadOnly = true;   
       
            txtSection.Text = "";
            txtSection.Tag = null;
            txtFollowType.Text = "";
            txtFollowType.Tag = null;
            txtFollowType.ReadOnly = true;
            txtSection.ReadOnly = true;
            if (FollowId == "")
            {
                grpBoxDefineTime.Enabled = false;
                panel3.Enabled = false;
            }
            else
            {
                
                panel3.Enabled = true;
            }
            ucUser.disposeElement();
            ucICD10.disposeElement();
            ucICD9.disposeElement();
            
        }
        /// <summary>
        ///��ʱ������������ 
        /// </summary>
        public void IniFollowType()
        {
            //��ʼ�����ʱ������ComboBox
            string sql = "select id,typename from T_FOLLOW_TYPE";
            DataSet ds_time = App.GetDataSet(sql);
            DataRow row = ds_time.Tables[0].NewRow();
            row[0] = "0";
            row[1] = "";
            ds_time.Tables[0].Rows.InsertAt(row,0);
            cmbFollowTimeType.DataSource = ds_time.Tables[0].DefaultView;
            cmbFollowTimeType.DisplayMember = "typename";
            cmbFollowTimeType.ValueMember = "id";
            cmbFollowTimeType.SelectedIndex = 0;
        }
        #region
        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagAdd_Click(object sender, EventArgs e)
        {
            //��ʼ���Զ���ؼ����
            ucICD10.setWidth(ucICD10.Width);
            frmUser us = new frmUser("ICD10");
            us.ShowDialog();
            if (ucElement.id != "" && ucElement.myName != "")
            {
                ucElement element = new ucElement(ucElement.myName, ucElement.id);
                ucICD10.createUser(element);
            }
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSurAdd_Click(object sender, EventArgs e)
        {
            ucICD9.setWidth(ucICD9.Width);
            frmUser us = new frmUser("ICD9");
            us.ShowDialog();
            if (ucElement.id != "" && ucElement.myName != "")
            {
                ucElement element = new ucElement(ucElement.myName, ucElement.id);
                ucICD9.createUser(element);
            }
        }
        /// <summary>
        /// ��Ͻ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSectionAdd_Click(object sender, EventArgs e)
        {
            frmSection us = new frmSection(0);
            if (txtSection.Tag != null&&txtSection.Tag.ToString()!="")
                us.SetSelected((string)txtSection.Tag);
            us.ShowDialog();
            txtSection.Text = us.GetNames();
            txtSection.Tag = us.GetIds();

        }
        /// <summary>
        /// �����÷���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFollowTypeAdd_Click(object sender, EventArgs e)
        {
            if (txtSection.Text == "")
            {
                App.Msg("���Ҳ���Ϊ��!");
                return;
            }
            Template.fmT = new TextEditor.frmText();
            frmFollowDocScan us = new frmFollowDocScan(txtSection.Tag.ToString());
            if (txtFollowType.Tag != null)
                us.SetSelectType(txtFollowType.Tag.ToString());
            us.ShowDialog();
            txtFollowType.Text = us.CkTypeNames;
            txtFollowType.Tag = us.CkTypeIds;
        }
        #endregion
        /// <summary>
        /// ��ʱ�����ͼӵ�dataGridView��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string type;
            type = txtFollowDefineTime.Text.Trim() + cmbYMD.Text;
            string times;
            times = "��" + (dgvDefineTime.Rows.Count+1).ToString() + "��";
            dgvDefineTime.Rows.Add(false,times, type);

        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int id ;
            id = App.GenId("t_follow_info", "id");
            string followName = "";
            if (txtFollowName.Text != "")
                followName = txtFollowName.Text;
            else
            {
                App.Msg("����������Ϊ��");
                txtFollowName.Focus();
                return;
            }
            ////�����û�id
            //if (ucUser.GetIds() != "")
            //    userIds = ucUser.GetIds();
            //else
            //{
            //    App.Msg("�û�����Ϊ��!");
            //    return;
            //}
            //��������id
            string sectionIds = "";
            string sectionNames = "";
            if (txtSection.Text != "")
            {
                sectionIds = txtSection.Tag.ToString();
                sectionNames = txtSection.Text.Trim();
            }
            else
            {
                App.Msg("���Ҳ���Ϊ��");
                return;
            }
            //�������id
            string icd10codes = "";
            if (ucICD10.GetIds() != "")
                icd10codes = ucICD10.GetIds();
            string ismain = "";
            if(checkMain.Checked==true)
                ismain="Y";
            else
                ismain="N";
            //��������id
            string icd9codes = "";
            if (ucICD9.GetIds() != "")
                icd9codes = ucICD9.GetIds();
            //�ο�ʱ��
            string stattime = "";
            starttime = cmbStartTime.Text;
            //�״�Ĭ������
            int defaultdays = 0;
            if (txtDefaultDay.Text != "")
                defaultdays = Convert.ToInt32(txtDefaultDay.Text);
            else
                defaultdays = 0;
            //ѭ������
            string followTimeType = "";
            string definefollow = "";
            if (cmbFollowTimeType.Text == "" && dgvDefineTime.Rows.Count == 0)
            {
                App.Msg("��ѡ�����ʱ�䷽ʽ");
                return;
            }
            //���ʱ������
            if (cmbFollowTimeType.Text != "")
            {
                followTimeType = cmbFollowTimeType.Text;
                
            }
            //���ѭ����������
            else
            {
                for (int i = 0; i < dgvDefineTime.Rows.Count; i++)
                {
                    if (definefollow == "")
                        definefollow = dgvDefineTime.Rows[i].Cells["ʱ��"].Value.ToString();
                    else
                        definefollow += "," + dgvDefineTime.Rows[i].Cells["ʱ��"].Value.ToString();
                }
                
            }
            //ѭ����������
            string finishType = "";
            if (ckbEnd.Checked)
            {
                if (rbtnTimes.Checked == true)
                {
                    if (txtTimes.Text != "")
                        finishType = txtTimes.Text.Trim() + "��";
                    else
                    {
                        App.MsgErr("���ý�������");
                        return;
                    }

                }
                //ѭ������ʱ��
                else
                {
                    if (txtTime.Text != "")
                        finishType = txtTime.Text + cmbYMD2.Text;
                    else
                    {
                        App.MsgErr("���ý���ʱ��");
                        return;
                    }
                }
            }
            //��ȡ����id
            string followWrite_Type = "";
            if (txtFollowType.Text!= "")
                followWrite_Type = txtFollowType.Tag.ToString();
            string creattime = "";
            creattime = dataTimeCreate.Value.ToShortDateString();
            string isenable = "";
            if (rbtnValid.Checked == true)
                isenable = "Y";
            else
                isenable = "N";
            string mySql = "";
            string ExecSecs = "";
            string ExecSickArea = "";
            string ExecSecNames = "";
            string ExecSickAreaNames = "";
            if (txtExecSecs.Tag != null)
            {
                ExecSecs = txtExecSecs.Tag.ToString();
                ExecSecNames = txtExecSecs.Text.Trim();
            }
            if (txtExecSickAeras.Tag != null)
            {
                ExecSickArea = txtExecSickAeras.Tag.ToString();
                ExecSickAreaNames = txtExecSickAeras.Text.Trim();
            }
            if (FollowId == "")
            {
                if (checkExist(txtFollowName.Text))
                {
                    App.Msg("�������Ѵ���");
                    txtFollowName.Text = "";
                    txtFollowName.Focus();
                    return;
                }
                maintain_section = App.UserAccount.CurrentSelectRole.Section_name;
                
                //��Ӳ���
                mySql = "insert into t_follow_info(id,follow_name,section_ids,icd9codes,icd10codes,ismaindiag,startingtime,defaultdays,followtype,definefollows,followtextid,createtime,isenable,maintain_section,creator,finishtype,exec_sections,exec_sickarea,section_names,exec_secnames,exec_sickareanames) values(" + id + ","  //����id
                + "'" + followName + "',"                                                           //���뷽����                                                     
                + "'" + sectionIds + "',"                                                           //������ұ��
                + "'" + icd9codes + "',"                                                            //�����������
                + "'" + icd10codes + "',"                                                           //������ϱ��
                + "'" + ismain + "',"                                                               //�Ƿ�����ϱ��
                + "'" + starttime + "',"                                                         //�ο�ʱ��
                +"" + defaultdays + ","                                                            //Ĭ�Ͽ�ʼ����
                + "'" + followTimeType + "',"                                                             //ѭ��ʱ������
                + "'" + definefollow + "',"                                                         //����ѭ������                                                     
                + "'" + followWrite_Type + "',"                                                     //������
                + "to_date('" + creattime + "','yyyy-MM-dd'),"                                                            //����ʱ��
                + "'" + isenable + "',"
                +"'" + maintain_section + "',"
                +"" + App.UserAccount.UserInfo.User_id + " ,"
                +"'" + finishType + "',"
                + "'" + ExecSecs + "',"
                +"'"+ExecSickArea+"',"
                +"'"+sectionNames+"',"
                +"'"+ExecSecNames+"',"
                +"'"+ExecSickAreaNames+"')";                                                         //�Ƿ���Ч
            }
            else
            {
                //�޸Ĳ���
                mySql = "update t_follow_info set follow_name='" + followName + "',"           //                
                + "section_ids='" + sectionIds + "',"
                + "icd9codes='" + icd9codes + "',"
                + "icd10codes='" + icd10codes + "',"
                + "ismaindiag='" + ismain + "',"
                + "startingtime='" + starttime + "',"
                +"defaultdays="+defaultdays+","
                + "followtype='" + followTimeType + "',"
                + "definefollows='" + definefollow + "',"
                +"finishtype='"+finishType+"',"
                + "followtextid='" + followWrite_Type + "',"
                + "createtime=to_date('" + creattime + "','yyyy-MM-dd'),"
                + "isenable='" + isenable + "',"
                +"creator="+App.UserAccount.UserInfo.User_id+","
                +"exec_sections='"+ExecSecs+"',"
                +"exec_sickarea='"+ExecSickArea+"',"
                +"section_names='"+sectionNames+"',"
                +"exec_secnames='"+ExecSecNames+"',"
                +"exec_sickareanames='"+ExecSickAreaNames+"'where id='"+FollowId+"'";        
            }
            try
            {
                if (App.ExecuteSQL(mySql) > 0)
                    App.Msg("�����ɹ���");
                else
                    App.Msg("����ʧ�ܣ�");

            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// ��鷽�����Ƿ��Ѵ���
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool checkExist(string name)
        {
            DataSet ds_name = new DataSet();
            string sql = "select * from t_follow_info where follow_name='"+name+"'";
            ds_name = App.GetDataSet(sql);
            if (ds_name != null)
                if (ds_name.Tables[0].Rows.Count != 0)
                    return true;
            return false;
        }
        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDefaultDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <='9' ||e.KeyChar==08))
                e.Handled = true;
        }

        private void txtTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
                e.Handled = true;
        }

        private void textFollowDefineTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
                e.Handled = true;
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
                e.Handled = true;
        }

        private void rbtnTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTime.Checked == true)
            {
                txtTime.Enabled = true;
                cmbYMD2.Enabled = true;
                txtTimes.Enabled = false;
            }
            else
            {
                txtTime.Enabled = false;
                cmbYMD2.Enabled = false;
                txtTimes.Enabled = true;
            }

        }


        private void btnReset_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < dgvDefineTime.Rows.Count; i++)
            {
                if ((bool)dgvDefineTime.Rows[i].Cells[0].Value)
                    dgvDefineTime.Rows.RemoveAt(i);
            }
            if (dgvDefineTime.Rows.Count != 0)
            {
                for (int i = 0; i < dgvDefineTime.Rows.Count; i++)
                {
                    int seq=i+1;
                    dgvDefineTime.Rows[i].Cells["˳��"].Value = "��" + seq + "��";

                }
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFollowTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFollowTimeType.Text != "")
                grpBoxDefineTime.Enabled = false;
            else
                grpBoxDefineTime.Enabled = true;
        }

        private void rbtnTimes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTimes.Checked)
            {
                txtTimes.Enabled = true;
                txtTime.Text = "";
                txtTime.Enabled = false;
                cmbYMD2.SelectedIndex = 0;
                cmbYMD2.Enabled = false;
            }
            else
            {
                txtTimes.Text = "";
                txtTimes.Enabled = false;
                txtTime.Enabled = true;               
                cmbYMD2.Enabled = true;
                cmbYMD2.SelectedIndex = 1;
            }

        }

        private void ckbEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEnd.Checked)
            {
                panel3.Enabled = true;
            }
            else
            {
                panel3.Enabled = false;
            }
        }
        /// <summary>
        /// ���ִ�п���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecSecs_Click(object sender, EventArgs e)
        {
            frmSection sec = new frmSection(0);
            if ( txtExecSecs.Tag != null&&txtExecSecs.Tag.ToString() != "" )
                sec.SetSelected(txtExecSecs.Tag.ToString());
            sec.ShowDialog();
            txtExecSecs.Text = sec.GetNames();
            txtExecSecs.Tag = sec.GetIds();
        }
        /// <summary>
        /// ���ִ�в���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecSickAeras_Click(object sender, EventArgs e)
        {
            frmSection sec = new frmSection(1);
            if (txtExecSickAeras.Tag != null && txtExecSickAeras.Tag.ToString() != "")
                sec.SetSelected(txtExecSickAeras.Tag.ToString());
            sec.ShowDialog();
            txtExecSickAeras.Text = sec.GetNames();
            txtExecSickAeras.Tag = sec.GetIds();
        }




    }
}
