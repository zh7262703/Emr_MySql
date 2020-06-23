using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.BLL_NURSE.Expectant_Record
{
    public partial class ExpectantRecord : UserControl
    {
        bool isSave = false;//���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID = "";//�����Զ�����ID
        string sql_MATERNITY = "";//��ѯ������¼
        private string PID = "";//סԺ��
        private string Pidname = "";//��������
        private string SickName = "";//��������
        private string Bed = "";//����
        private string PID_IDS = "";//����ID
        DataSet ds;
        public ExpectantRecord()
        {
           InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pid">סԺ��</param>
        /// <param name="sickname">����</param>
        /// <param name="bed">����</param>
        /// <param name="name">��������</param>
        /// <param name="pids_id">����ID</param>
        public ExpectantRecord(string pid,string sickname,string bed,string name,string pids_id)
        {
            try
            {
                InitializeComponent();
                PID = pid;
                Pidname = name;
                SickName = sickname;
                Bed = bed;
                PID_IDS = pids_id;
            }
            catch
            {
            }
        }

        private void ExpectantRecord_Load(object sender, EventArgs e)
        {
            try
            {
                ShowDate();
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.RowColChange += new EventHandler(CurrentDataChange);
                RefleshFrm();
            }
            catch
            {
            }
        }
        private void CurrentDataChange(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                ucC1FlexGrid1.fg.AllowEditing = false;
            }
            catch
            { }
        }
        /// <summary>
        /// ��ʾ����
        /// </summary>
        private void ShowDate()
        {
            try
            {
                //sql_MATERNITY = @"select  ID as ���,to_char(RECORD_TIME,'yyyy-MM-dd') as ����,to_char(RECORD_TIME,'HH24:mi:ss') as ʱ��," +
                //        @" PALACE_BOTTOM as ����,TIRE_TO_UNCOVER as ̥��¶,TIRE_AZIMUTH as ̥��λ," +
                //        @" TAIXIN as ̥��,QUICKENED as ̥��,COHESION as �ν�,BLOOD_PRESSURE as Ѫѹ,EDEMA as ˮ��," +
                //       @" CONTRACTIONS as ����,PROCESSING as ����,SIGNATURE as ǩ��,PID as סԺ��,PATIENT_ID from T_MATERNITY_BEFORE_RECORD where PATIENT_ID='"+PID_IDS+"'";
                                // + " order by ID desc"
                sql_MATERNITY = "select ID as ���,to_char(RECORD_TIME,'yyyy-MM-dd') as ����,to_char(RECORD_TIME,'HH24:mi') as ʱ��,BLOOD_PRESSURE as Ѫѹ,EDEMA as ����," +
                   " PALACE_BOTTOM as ����,TIRE_AZIMUTH as ̥λ,TAIXIN as ̥��,QUICKENED as ̥��,TIRE_TO_UNCOVER as ��¶��λ,TOUTONG as ͷʹ" +
                   " ,TOUYUN as ͷ��,EXIN as ����,YANHUA as �ۻ�,REMARK as ��ע,signature as ǩ��,PID as סԺ��,PATIENT_ID" +
                   " from T_MATERNITY_BEFORE_RECORD where PATIENT_ID='"+PID_IDS+"'";
                string SQl = sql_MATERNITY;
                ds = App.GetDataSet(SQl);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ucC1FlexGrid1.DataBd(SQl, "���", false, "", "");
                        ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;

                        ucC1FlexGrid1.fg.Cols["PATIENT_ID"].Visible = false;
                        ucC1FlexGrid1.fg.Cols["PATIENT_ID"].AllowEditing = false;
                        ucC1FlexGrid1.fg.AllowEditing = false;
                    }
                    for (int i = 0; i < ds.Tables[0].Rows.Count+1; i++)
                    {
                        if (ucC1FlexGrid1.fg.Rows[i]["ͷʹ"].ToString() == "True")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["ͷʹ"] = "��";
                        }
                        else if (ucC1FlexGrid1.fg.Rows[i]["ͷʹ"].ToString() == "False")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["ͷʹ"] = "";
                        }
                        
                        if (ucC1FlexGrid1.fg.Rows[i]["ͷ��"].ToString() == "True")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["ͷ��"] = "��";
                        }
                        else if (ucC1FlexGrid1.fg.Rows[i]["ͷ��"].ToString() == "False")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["ͷ��"] = "";
                        }

                        if (ucC1FlexGrid1.fg.Rows[i]["����"].ToString() == "True")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["����"] = "��";
                        }
                        else if (ucC1FlexGrid1.fg.Rows[i]["����"].ToString() == "False")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["����"] = "";
                        }
                        if (ucC1FlexGrid1.fg.Rows[i]["�ۻ�"].ToString() == "True")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["�ۻ�"] = "��";
                        }
                        else if (ucC1FlexGrid1.fg.Rows[i]["�ۻ�"].ToString() == "False")
                        {
                            ucC1FlexGrid1.fg.Rows[i]["�ۻ�"] = "";
                        }
                    }
                }
            }
            catch
            {
            }
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {

            txtFundus.Enabled = false;
            txtFetal_Presentation.Enabled = false;
            txtPosition.Enabled = false;
            txtHeart.Enabled = false;
            txtQuickening.Enabled = false;
            cbxTouTong.Enabled = false;
            txtBloodHigh.Enabled = false;
            txtBloodLow.Enabled = false;
            cbxEdema.Enabled = false;
            cbxTouYun.Enabled = false;
            cbxEXin.Enabled = false;
            cbxYanHua.Enabled = false;
           txtRemark.Enabled = false;
            //txtAutograph.Enabled = false;
            dtpTime.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false; ;
            btnCancel.Enabled = false;
            ucC1FlexGrid1.fg.Enabled = true;
            if (chKs.Checked == true)
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
            }
            isSave = false;


        }
        /// <summary>
        /// �༭״̬
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtBloodHigh.Text = ""; //Ѫѹ
                txtBloodLow.Text = "";//Ѫѹ/��
                cbxEdema.SelectedIndex = 1;//����
                txtFundus.Text = "";//����
                txtPosition.Text = "";//̥λ
                txtHeart.Text = "";//̥��
                txtQuickening.Text = "";//̥��
                txtFetal_Presentation.Text = "";//��¶��λ
                cbxTouTong.Checked = false;//ͷʹ
                cbxTouYun.Checked = false;//ͷ��
                cbxEXin.Checked = false;//����
                cbxYanHua.Checked = false;//�ۻ�
                txtRemark.Text = "";//��ע
                //txtAutograph.Text = "";//ǩ��
               
            }
            txtBloodHigh.Enabled = true;
            txtBloodLow.Enabled = true;
            cbxEdema.Enabled = true;
            txtFundus.Enabled = true;
            txtPosition.Enabled = true;
            txtHeart.Enabled = true;
            txtQuickening.Enabled = true;
            txtRemark.Enabled = true;
            txtFetal_Presentation.Enabled = true;
            cbxTouTong.Enabled = true;
            cbxTouYun.Enabled = true;
            cbxEXin.Enabled = true;
            cbxYanHua.Enabled = true;
            //txtAutograph.Enabled = true;
            dtpTime.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            ucC1FlexGrid1.fg.Enabled = false;
            txtBloodHigh.Focus();
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            Edit(isSave);
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            Edit(isSave);
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "";
                ID = App.GenId("T_MATERNITY_BEFORE_RECORD", "ID").ToString();
                if (isSave)
                {

                    sql = "insert into T_MATERNITY_BEFORE_RECORD(id, record_time, pid, palace_bottom, tire_to_uncover, tire_azimuth, taixin, quickened, blood_pressure, edema , signature, patient_id, toutong, touyun, exin, yanhua, remark) values(" +
                        ID +
                        ",to_timestamp('" + dtpTime.Value + "','syyyy-mm-dd hh24:mi:ss'),'" +
                        PID + "','" +
                        txtFundus.Text + "','" +
                        txtFetal_Presentation.Text + "','" +
                        txtPosition.Text + "','" +
                        txtHeart.Text + "','" +
                        txtQuickening.Text + "','" +
                        txtBloodHigh.Text+"/"+txtBloodLow.Text + "','" +
                        cbxEdema.SelectedItem.ToString() + "','" +
                        App.UserAccount.UserInfo.User_name + "'," +
                        PID_IDS + ",'" +
                        cbxTouTong.Checked.ToString() + "','" +
                        cbxTouYun.Checked.ToString() + "','" +
                        cbxEXin.Checked.ToString() + "','" +
                        cbxYanHua.Checked.ToString() + "','" +
                        txtRemark.Text + "')";

                       
                    //+ ID + ",to_timestamp('"
                       //+ dtpTime.Value + "','syyyy-mm-dd hh24:mi:ss'),'"
                       // +txtFundus.Text+"','"
                       //+txtFetal_Presentation.Text+"','"
                       //+txtPosition.Text+"','"
                       //+txtHeart.Text+"','"
                       //+txtQuickening.Text+"','"
                       //+txtTouTong.Text+"','"
                       //+txtBlood.Text+"','"
                       //+txtEdema.Text+"','"
                       //+txtTouYun.Text+"','"
                       //+txtEXin.Text+"','"
                       //+txtAutograph.Text+"','"+PID+"',"+PID_IDS+")";
                    btnAdd_Click(sender, e);
                }
                else
                {
                    
                    sql = "update t_maternity_before_record"+
                    " set record_time = to_timestamp('"+ dtpTime.Value + "','syyyy-mm-dd hh24:mi:ss'),"+
                        "pid = '"+PID+"',"+
                        "palace_bottom = '" + txtFundus.Text + "'," +
                        "tire_to_uncover = '" + txtFetal_Presentation.Text + "'," +
                        "tire_azimuth = '" + txtPosition.Text + "'," +
                        "taixin = '" + txtHeart.Text + "'," +
                        "quickened = '" + txtQuickening.Text + "'," +
                        "blood_pressure = '" + txtBloodHigh.Text+"/"+txtBloodLow.Text + "'," +
                        "edema = '" + cbxEdema.SelectedItem.ToString() + "'," +
                        "signature = '" + App.UserAccount.UserInfo.User_name + "'," +
                        "patient_id = "+PID_IDS+","+
                        "toutong = '"+cbxTouTong.Checked.ToString()+"',"+
                        "touyun = '"+cbxTouYun.Checked.ToString()+"',"+
                        "exin = '"+cbxEXin.Checked.ToString()+"',"+
                        "yanhua = '"+cbxYanHua.Checked.ToString()+"',"+
                        "remark = '"+txtRemark.Text+"'"+
                        " where id = " + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString();
                    //sql = "update T_MATERNITY_BEFORE_RECORD set PALACE_BOTTOM='"
                    //    + txtFundus.Text + "',TIRE_TO_UNCOVER='"
                    //    +txtFetal_Presentation.Text +"',TIRE_AZIMUTH='"
                    //    +txtPosition.Text + "',TAIXIN='"
                    //    +txtHeart.Text + "',QUICKENED='"
                    //    +txtQuickening.Text + "',COHESION='"
                    //    +txtTouTong.Text + "',BLOOD_PRESSURE='"
                    //    +txtBlood.Text + "',EDEMA='"
                    //    +txtEdema.Text + "',CONTRACTIONS='"
                    //    +txtTouYun.Text+"',PROCESSING='"
                    //    +txtEXin.Text+"',SIGNATURE='"
                    //    + txtAutograph.Text + "',RECORD_TIME=to_timestamp('"
                    //    + dtpTime.Value + "','syyyy-mm-dd hh24:mi:ss'),PID='" + PID + "'  where PATIENT_ID=" + PID_IDS + " and ID='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString() + "'";
                    btnUpdate_Click(sender,e);
                }
                if (sql != "")
                {
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("����ɹ���");
                        ShowDate();
                        btnCancel_Click(sender, e);
                    }
                   
                }
       
            }
            catch
            {
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            RefleshFrms();
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrms()
        {

            txtFundus.Text = "";
            txtFetal_Presentation.Text = "";
            txtPosition.Text = "";
            txtHeart.Text = "";
            txtQuickening.Text = "";
            
            txtBloodHigh.Text = "";
            txtBloodLow.Text = "";
            cbxEdema.SelectedIndex = 1;
            cbxTouTong.Checked = false;
            cbxTouYun.Checked = false;
            cbxEXin.Checked = false;
            cbxYanHua.Checked = false;
            //txtAutograph.Text = "";
            
            txtFundus.Enabled = false;
            txtFetal_Presentation.Enabled = false;
            txtPosition.Enabled = false;
            txtHeart.Enabled = false;
            txtQuickening.Enabled = false;
            cbxTouTong.Enabled = false;
            txtBloodHigh.Enabled = false;
            txtBloodLow.Enabled = false;
            cbxEdema.Enabled = false;
            cbxTouYun.Enabled = false;
            cbxEXin.Enabled = false;
            cbxYanHua.Enabled = false;
            //txtAutograph.Enabled = false;
            txtRemark.Enabled = false;
            dtpTime.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false; ;
            btnCancel.Enabled = false;
            ucC1FlexGrid1.fg.Enabled = true;
            isSave = false;


        }
        int Rowcount = 0;
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                int index = ucC1FlexGrid1.fg.RowSel;
                if (ucC1FlexGrid1.fg.RowSel >= 0)
                {
                    ID = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString();
                    string time = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString() + " " + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ʱ��"].ToString();
                    string Blood = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "Ѫѹ"].ToString();
                    if (Blood.Split('/').Length > 1)
                    {
                        txtBloodHigh.Text = Blood.Split('/')[0].ToString();
                        txtBloodLow.Text = Blood.Split('/')[1].ToString();
                    }
                    else
                    {
                        txtBloodHigh.Text = Blood.Split('/')[0].ToString();
                        txtBloodLow.Text = "";
                    }
                    
                    cbxEdema.SelectedIndex = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString() == "��" ? 1 : 0;
                    txtFundus.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString();
                    txtPosition.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "̥λ"].ToString();
                    txtHeart.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "̥��"].ToString();
                    txtQuickening.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "̥��"].ToString();
                    txtFetal_Presentation.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��¶��λ"].ToString();
                    //֢״
                    cbxTouTong.Checked = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ͷʹ"].ToString() == "��" ? true : false;
                    cbxTouYun.Checked = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ͷ��"].ToString() == "��" ? true : false;
                    cbxEXin.Checked = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString() == "��" ? true : false;
                    cbxYanHua.Checked = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�ۻ�"].ToString() == "��" ? true : false;
                    
                    //txtTouTong.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "�ν�"].ToString();
                    
                    
                    //txtTouYun.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString();
                    //txtEXin.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����"].ToString();
                    txtRemark.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "��ע"].ToString();
                    //txtAutograph.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "ǩ��"].ToString();
                    
                    dtpTime.Value =Convert.ToDateTime(time);
                    int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к� 
                    if (rows > 0)
                    {
                        if (Rowcount == rows)
                        {
                            this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                        }
                        else
                        {
                            //�������ͷ��
                            if (rows > 0)
                            {
                                //�͸ı䱳��ɫ
                                this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                            }
                            if (Rowcount > 0 && ds.Tables[0].Rows.Count >= Rowcount)
                            {
                                //������һ�ε�������л�ԭ
                                this.ucC1FlexGrid1.fg.Rows[Rowcount].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                            }
                        }
                    }
                    //����һ�ε��кŸ�ֵ
                    Rowcount = rows;
                }
                RefleshFrm();
            }
            catch
            {
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (App.Ask("���Ƿ�Ҫɾ��"))
            {
                string sql = "delete from  T_MATERNITY_BEFORE_RECORD  where  ID='" + ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���"].ToString() + "' and PATIENT_ID=" + PID_IDS + "";
                App.ExecuteSQL(sql);
                ShowDate();
                btnCancel_Click(sender,e);
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dtpEnd.Value.Date >= dtpStart.Value.Date)
            {
                string sql="";
                sql = sql_MATERNITY;
                if (chKs.Checked == true)
                {
                    if (dtpEnd.Value.Date == dtpStart.Value.Date)
                    {
                        sql = sql_MATERNITY + " and to_char(RECORD_TIME,'yyyy-MM-dd')='" + dtpStart.Text + "'";
                    }
                    else
                    {
                        sql = sql_MATERNITY + " and   to_char(RECORD_TIME,'yyyy-MM-dd') between  '" + dtpStart.Text + "' and  '" + dtpEnd.Text + "'";

                    }
                }
                ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    ucC1FlexGrid1.DataBd(sql, "���", false, "", "");
                    ucC1FlexGrid1.fg.Cols["���"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["���"].AllowEditing = false;
                    ucC1FlexGrid1.fg.Cols["PATIENT_ID"].Visible = false;
                    ucC1FlexGrid1.fg.Cols["PATIENT_ID"].AllowEditing = false;
                    ucC1FlexGrid1.fg.AllowEditing = false;
                }
            }
            else
            {
                App.Msg("����ʱ����ڿ�ʼʱ�䣡");
            }
        }

        private void txtFundus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFetal_Presentation.Focus();
            }

        }

        private void txtFetal_Presentation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPosition.Focus();
            }
        }

        private void txtPosition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtHeart.Focus();
            }
        }

        private void txtHeart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuickening.Focus();
            }
        }

        private void txtQuickening_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxTouTong.Focus();
            }
        }

        private void txtJion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBloodHigh.Focus();
            }
        }

       

        private void txtEdema_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxTouYun.Focus();
            }
        }

        private void txtUC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cbxEXin.Focus();
            }
        }



        private void txtAutograph_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpTime.Focus();
            }
        }

        private void dtpTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender,e);
            }
        }

        private void btnPaint_Click(object sender, EventArgs e)
        {
           //string  sql_MATERNITY1 = @"select  ID as ���,to_char(RECORD_TIME,'yyyy-MM-dd') as ����,to_char(RECORD_TIME,'HH24:mi') as ʱ��," +
           //        @" PALACE_BOTTOM as ����,TIRE_TO_UNCOVER as ̥��¶,TIRE_AZIMUTH as ̥��λ," +
           //        @" TAIXIN as ̥��,QUICKENED as ̥��,COHESION as �ν�,BLOOD_PRESSURE as Ѫѹ,EDEMA as ˮ��," +
           //       @" CONTRACTIONS as ����,PROCESSING as ����,SIGNATURE as ǩ��,PID as סԺ�� from T_MATERNITY_BEFORE_RECORD where PID='"+PID+"'";
            string sql_MATERNITY1 = @"select  ID as ���,to_char(RECORD_TIME,'yyyy-MM-dd') as ����,to_char(RECORD_TIME,'HH24:mi') as ʱ��,BLOOD_PRESSURE as Ѫѹ,EDEMA as ����,PALACE_BOTTOM as ����,TIRE_AZIMUTH as ̥λ,TAIXIN as ̥��,QUICKENED as ̥��,TIRE_TO_UNCOVER as ��¶��λ,(case when TOUTONG='True' then '��' else '' end) as ͷʹ,(case when TOUYUN='True' then '��' else '' end) as ͷ��,(case when EXIN='True' then '��' else '' end) as ����,(case when YANHUA='True' then '��' else '' end) as �ۻ�,REMARK ��ע,SIGNATURE as ǩ��,PID as סԺ�� from T_MATERNITY_BEFORE_RECORD where PID='" + PID + "'";
                  
           string SQl = sql_MATERNITY1;
           DataSet ds = App.GetDataSet(SQl);
           if (ds != null)
           {
               if (ds.Tables[0].Rows.Count > 0)
               {
                   FrmExpectant fx = new FrmExpectant(ds, Pidname, SickName, Bed, PID);
                   fx.Show();
               }
           }

        }

        private void chKs_CheckedChanged(object sender, EventArgs e)
        {
            if (chKs.Checked == true)
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
            }
        }
    }
}
