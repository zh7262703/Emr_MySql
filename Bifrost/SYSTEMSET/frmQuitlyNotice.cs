using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;

namespace Bifrost
{
    /// <summary>
    /// �������Ʋ�ѯ
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2010-10-15
    /// </summary>
    public partial class frmQuitlyNotice : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// ���عܴ�ҽ������б�
        /// </summary>
        //public static Control ucRecord=App.;

        /// <summary>
        /// SQL���
        /// </summary>
        string tempSQL = "";       
        public frmQuitlyNotice()
        {
            InitializeComponent();
            App.FormStytleSet(this, false);
            //ucGridviewX1.fg.DataSourceChanged += new EventHandler(dataGridViewX1_DataSourceChanged);            
            ucGridviewX1.fg.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridViewX1_DataBindingComplete);
        }

        private void iniDocType()
        {
            try
            {
                string datasql = "select a.id,a.name from t_data_code a where a.type=18 and enable='Y' order by decode(name,'�״β��̼�¼',1,'D�Ͳ����鷿',2,'��Ժ��¼',3,'�ٴΣ���Σ���Ժ��¼',4,'24Сʱ���Ժ',5,'24Сʱ��Ժ����',6,'����',7,'���β鷿',8,'��Σ���߲��̼�¼',9,'���ػ��߲��̼�¼',10,'ת���¼',11,'ת����¼',12,'�����¼',13,'�Ӱ��¼',14,'�����¼',15,'���ȼ�¼',16,'������¼',17,'�����״β��̼�¼',18,'���󲡳�',19,'�׶�С��',20,'��Ժ��¼',21,'������¼',22,'�����������ۼ�¼',23,24)";
                if (App.UserAccount.CurrentSelectRole.Role_type=="N")
                {
                    datasql = "select a.id,a.name from t_data_code a where a.type=18 and a.name in('���µ�','���µ�����')";
                }
                DataSet ds = App.GetDataSet(datasql);
                DataTable dt = ds.Tables[0];
                DataRow rw = dt.NewRow();
                rw[0] = 0;
                rw[1] = "��ѡ��...";
                dt.Rows.Add(rw);

                cmbDocType.DataSource = dt;
                cmbDocType.DisplayMember = "name";
                cmbDocType.ValueMember = "id";
                if (cmbDocType.Items.Count > 0)
                {
                    cmbDocType.SelectedIndex = cmbDocType.Items.Count - 1;
                }

            }
            catch
            { }
        }

       

        private void frmQuitlyNotice_Load(object sender, EventArgs e)
        {
            iniDocType();
            btnQueary_Click(sender,e);
            //dataGridViewX1_DataSourceChanged(sender, e);    
            //refleshgrid();


            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("������"))
            {
                //ֻ��Կ�������ʾ�ù���
                //2014:�����ʿ���ӹܴ�ҽ���Ϳ���������,ֱ�ӵ��ùܴ�ҽ������б�ģ��
                //�ܴ�ҽ������б�
                this.tabItem2.Visible = true;
                System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                Type tmpType = assmble.GetType("Base_Function.Base");
                System.Reflection.MethodInfo tmpM = tmpType.GetMethod("RecordMonitorShow");
                object tmpobj = assmble.CreateInstance("Base_Function.Base");
                tmpM.Invoke(tmpobj, null);
                Control ucRecord = App.ucRecord;
                tabControlPanel2.Controls.Add(ucRecord);
                ucRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            }

        }

        /// <summary>
        /// �ϲ���Ԫ��
        /// </summary>
        private void MegCell()
        {           

         
        }

        private void refleshgrid()
        {
            try
            {

                for (int i = 0; i < ucGridviewX1.fg.Rows.Count; i++)
                {

                    /*
                     * С��
                     */

                    DataGridViewImageCell sc = ucGridviewX1.fg["״̬", i] as DataGridViewImageCell;
                    if (ucGridviewX1.fg["pv", i].Value.ToString().Trim() == "1")
                        sc.Value = imageList1.Images[1];
                    else
                        sc.Value = imageList1.Images[0];
                }
            }
            catch (Exception ex)
            { ex.Message.ToString(); }
        }

        private void InitTable(string temp)
        {
            try
            {
                ucGridviewX1.fg.Columns.Clear();
                //ucC1FlexGrid1.DataBd(temp, "note", "sick_bed_no,patient_name,sick_doctor_name, name,note,ptype", "����,����,�ܴ�ҽ��,ְ��,��ʾ����,״̬");
                ucGridviewX1.fg.AllowUserToAddRows = false;
                ucGridviewX1.DataBd(temp, "note", false, "sick_bed_no,patient_name,sick_doctor_name, name,note,ptype", "����,����,�ܴ�ҽ��,ְ��,��ʾ����,״̬");
                DataGridViewImageColumn imagecol = new DataGridViewImageColumn();
                imagecol.HeaderText = "����";
                imagecol.Name = "״̬";
                ucGridviewX1.fg.Columns.Add(imagecol);
                ucGridviewX1.fg.Columns["pv"].Visible = false;
                ucGridviewX1.fg.Columns["ptype"].HeaderText = "״̬";
                ucGridviewX1.fg.Columns["sick_bed_no"].HeaderText = "����";
                ucGridviewX1.fg.Columns["patient_name"].HeaderText = "����";
                ucGridviewX1.fg.Columns["sick_doctor_name"].HeaderText = "�ܴ�ҽ��";
                ucGridviewX1.fg.Columns["name"].HeaderText = "ְ��";
                ucGridviewX1.fg.Columns["note"].HeaderText = "��ʾ����";
                //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                ucGridviewX1.fg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                ucGridviewX1.fg.Columns["note"].Width = 350;
                ucGridviewX1.fg.AutoResizeRows();
            }
            catch { };
            //ucGridviewX1.fg.AutoResizeColumns();            
           
        }

      

        private void fg_MouseWheel(object sender,MouseEventArgs e)
        {           
        }

        /// <summary>
        /// ��ѯ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueary_Click(object sender, EventArgs e)
        {
            string strRoleType = App.UserAccount.CurrentSelectRole.Role_type;
            if (strRoleType == "N")
            {
                tempSQL = "select tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name, u.name,tqr.note,'δ���' as ptype,tqr.pv from t_quality_record_hlb tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                    " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id " +
                    " where tqr.pv<>3 and tip.section_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  tip.sick_bed_no like '%" + txtBedNum.Text + "%' and tip.patient_name like '%" + txtPatient.Text + "%' ";
               
            }
            else if(strRoleType=="D")
            {
                tempSQL = "select tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name, u.name,tqr.note,'δ���' as ptype,tqr.pv from t_quality_record tqr inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null " +
                    " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id " +
                    " where tqr.pv<>3 and tip.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  tip.sick_bed_no like '%" + txtBedNum.Text + "%' and tip.patient_name like '%" + txtPatient.Text + "%' "; //order by tip.sick_bed_id, tqr.noteztime asc            
            }
            else if (strRoleType == "Z")
            {
                tempSQL = "select tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name, u.name,tqr.note,'δ���' as ptype,tqr.pv from t_quality_record tqr inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null " +
                    " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id " +
                    " where tqr.pv<>3 and tip.sick_bed_no like '%" + txtBedNum.Text + "%' and tip.patient_name like '%" + txtPatient.Text + "%' ";
            }
            if (cmbDocType.Text.Trim() != "" && 
                cmbDocType.Text.Trim() != "��ѡ��...")
            {
                tempSQL = tempSQL + " and tqr.doctype='" + cmbDocType.Text + "'";
            }

            tempSQL = tempSQL + " order by substr(tqr.note,0,20) desc";
            InitTable(tempSQL);
            refleshgrid();
        }

        private void dataGridViewX1_DataSourceChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            refleshgrid();
        }

            

    }
}