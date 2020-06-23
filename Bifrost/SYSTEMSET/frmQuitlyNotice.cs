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
    /// 质量控制查询
    /// 创建者：张华
    /// 创建时间：2010-10-15
    /// </summary>
    public partial class frmQuitlyNotice : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 加载管床医生监控列表
        /// </summary>
        //public static Control ucRecord=App.;

        /// <summary>
        /// SQL语句
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
                string datasql = "select a.id,a.name from t_data_code a where a.type=18 and enable='Y' order by decode(name,'首次病程记录',1,'D型病例查房',2,'入院记录',3,'再次（多次）入院记录',4,'24小时入出院',5,'24小时入院死亡',6,'病程',7,'主治查房',8,'病危患者病程记录',9,'病重患者病程记录',10,'转入记录',11,'转出记录',12,'交班记录',13,'接班记录',14,'会诊记录',15,'抢救记录',16,'手术记录',17,'术后首次病程记录',18,'术后病程',19,'阶段小结',20,'出院记录',21,'死亡记录',22,'死亡病历讨论记录',23,24)";
                if (App.UserAccount.CurrentSelectRole.Role_type=="N")
                {
                    datasql = "select a.id,a.name from t_data_code a where a.type=18 and a.name in('体温单','体温单其他')";
                }
                DataSet ds = App.GetDataSet(datasql);
                DataTable dt = ds.Tables[0];
                DataRow rw = dt.NewRow();
                rw[0] = 0;
                rw[1] = "请选择...";
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


            if (App.UserAccount.CurrentSelectRole.Role_name.Contains("科主任"))
            {
                //只针对科主任显示该功能
                //2014:永州质控添加管床医生和科室排序功能,直接调用管床医生监控列表模块
                //管床医生监控列表
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
        /// 合并单元格
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
                     * 小灯
                     */

                    DataGridViewImageCell sc = ucGridviewX1.fg["状态", i] as DataGridViewImageCell;
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
                //ucC1FlexGrid1.DataBd(temp, "note", "sick_bed_no,patient_name,sick_doctor_name, name,note,ptype", "床号,姓名,管床医生,职称,提示内容,状态");
                ucGridviewX1.fg.AllowUserToAddRows = false;
                ucGridviewX1.DataBd(temp, "note", false, "sick_bed_no,patient_name,sick_doctor_name, name,note,ptype", "床号,姓名,管床医生,职称,提示内容,状态");
                DataGridViewImageColumn imagecol = new DataGridViewImageColumn();
                imagecol.HeaderText = "提醒";
                imagecol.Name = "状态";
                ucGridviewX1.fg.Columns.Add(imagecol);
                ucGridviewX1.fg.Columns["pv"].Visible = false;
                ucGridviewX1.fg.Columns["ptype"].HeaderText = "状态";
                ucGridviewX1.fg.Columns["sick_bed_no"].HeaderText = "床号";
                ucGridviewX1.fg.Columns["patient_name"].HeaderText = "姓名";
                ucGridviewX1.fg.Columns["sick_doctor_name"].HeaderText = "管床医生";
                ucGridviewX1.fg.Columns["name"].HeaderText = "职称";
                ucGridviewX1.fg.Columns["note"].HeaderText = "提示内容";
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
        /// 查询设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueary_Click(object sender, EventArgs e)
        {
            string strRoleType = App.UserAccount.CurrentSelectRole.Role_type;
            if (strRoleType == "N")
            {
                tempSQL = "select tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name, u.name,tqr.note,'未完成' as ptype,tqr.pv from t_quality_record_hlb tqr inner join t_in_patient tip on tqr.patient_id=tip.id  and tip.DOCUMENT_STATE is null " +
                    " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id " +
                    " where tqr.pv<>3 and tip.section_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  tip.sick_bed_no like '%" + txtBedNum.Text + "%' and tip.patient_name like '%" + txtPatient.Text + "%' ";
               
            }
            else if(strRoleType=="D")
            {
                tempSQL = "select tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name, u.name,tqr.note,'未完成' as ptype,tqr.pv from t_quality_record tqr inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null " +
                    " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id " +
                    " where tqr.pv<>3 and tip.section_id=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  tip.sick_bed_no like '%" + txtBedNum.Text + "%' and tip.patient_name like '%" + txtPatient.Text + "%' "; //order by tip.sick_bed_id, tqr.noteztime asc            
            }
            else if (strRoleType == "Z")
            {
                tempSQL = "select tip.sick_bed_no,tip.patient_name,tip.sick_doctor_name, u.name,tqr.note,'未完成' as ptype,tqr.pv from t_quality_record tqr inner join t_in_patient tip on tqr.patient_id=tip.id and tip.DOCUMENT_STATE is null " +
                    " left join (select c.name,u.user_id from t_userinfo u left join T_DATA_CODE c on u.u_tech_post=c.id ) u on tip.sick_doctor_id=u.user_id " +
                    " where tqr.pv<>3 and tip.sick_bed_no like '%" + txtBedNum.Text + "%' and tip.patient_name like '%" + txtPatient.Text + "%' ";
            }
            if (cmbDocType.Text.Trim() != "" && 
                cmbDocType.Text.Trim() != "请选择...")
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