using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    public partial class ucQualityControl : UserControl
    {
        /// <summary>
        /// SQL语句
        /// </summary>
        string tempSQL = "";   
        public ucQualityControl()
        {
            InitializeComponent();
            //App.FormStytleSet(this,false);
            //ucGridviewX1.fg.DataSourceChanged += new EventHandler(dataGridViewX1_DataSourceChanged);            
            ucGridviewX1.fg.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(dataGridViewX1_DataBindingComplete);
        }
        private void iniDocType()
        {
            try
            {
                DataSet ds = App.GetDataSet("select a.id,a.name from t_data_code a where a.type=18");
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
                    if (ucGridviewX1.fg["pv", i].Value.ToString() == "1")
                        sc.Value = imageList1.Images[1];
                    else
                        sc.Value = imageList1.Images[0];
                }
            }
            catch
            { }
        }
        private void InitTable(string temp)
        {
            ucGridviewX1.fg.Columns.Clear();
            //ucC1FlexGrid1.DataBd(temp, "sick_bed_no", "sick_bed_no,patient_name,note,ptype", "床号,姓名,提示内容,状态");
            ucGridviewX1.DataBd(temp, "sick_bed_no", "sick_bed_no,patient_name,note,ptype", "床号,姓名,提示内容,状态");
            DataGridViewImageColumn imagecol = new DataGridViewImageColumn();
            imagecol.HeaderText = "提醒";
            imagecol.Name = "状态";
            ucGridviewX1.fg.Columns.Add(imagecol);
            ucGridviewX1.fg.Columns["pv"].Visible = false;
            ucGridviewX1.fg.Columns["ptype"].HeaderText = "状态";
            ucGridviewX1.fg.Columns["sick_bed_no"].HeaderText = "床号";
            ucGridviewX1.fg.Columns["patient_name"].HeaderText = "姓名";
            ucGridviewX1.fg.Columns["note"].HeaderText = "提示内容";
            ucGridviewX1.fg.AutoResizeColumns();

        }
        /// <summary>
        /// 查询设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQueary_Click(object sender, EventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Role_type == "N")
            {
                tempSQL = "select tip.sick_bed_no,tip.patient_name,tqr.note,'未完成' as ptype,tqr.pv from t_quality_record_hlb tqr inner join t_in_patient tip on tqr.patient_id=tip.id where tqr.section_sickaera=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  tip.sick_bed_no like '%" + txtBedNum.Text + "%' and tip.patient_name like '%" + txtPatient.Text + "%' ";

            }
            else
            {
                tempSQL = "select tip.sick_bed_no,tip.patient_name,tqr.note,'未完成' as ptype,tqr.pv from t_quality_record tqr inner join t_in_patient tip on tqr.patient_id=tip.id where tqr.section_sickaera=" + App.UserAccount.CurrentSelectRole.Section_Id + " and  tip.sick_bed_no like '%" + txtBedNum.Text + "%' and tip.patient_name like '%" + txtPatient.Text + "%' "; //order by tip.sick_bed_id, tqr.noteztime asc            
            }

            if (cmbDocType.Text.Trim() != "" &&
                cmbDocType.Text.Trim() != "请选择...")
            {
                tempSQL = tempSQL + " and tqr.doctype='" + cmbDocType.Text + "'";
            }

            tempSQL = tempSQL + "  order by tip.sick_bed_id, tqr.noteztime asc";
            InitTable(tempSQL);
            refleshgrid();
        }
        private void dataGridViewX1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            refleshgrid();
        }

        private void ucQualityControl_Load(object sender, EventArgs e)
        {
            try
            {
                iniDocType();
                btnQueary_Click(sender, e);  
                refleshgrid();
            }
            catch 
            {

            }

        } 
    }
}
