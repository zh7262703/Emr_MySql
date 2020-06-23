using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Chart;

namespace Base_Function.EMERGENCY
{
    public partial class frmSJZ : DevComponents.DotNetBar.Office2007Form
    {
        public frmSJZ(DataTable dt)
        {
            InitializeComponent();
            SetSJZ(dt);
        }


        void SetSJZ(DataTable dt)
        {

            try
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    if (dt.Rows[0][dt.Columns[i].ColumnName].ToString() != "")
                    {
                        switch (dt.Columns[i].ColumnName)
                        {
                            case "发病时间":
                                lblFB.Text = Convert.ToDateTime(dt.Rows[0]["发病时间"]).ToShortTimeString();
                                lblstart.Text = Convert.ToDateTime(dt.Rows[0]["发病时间"]).ToLongDateString();
                                break;
                            case "呼救时间":
                                lblHJ.Text = Convert.ToDateTime(dt.Rows[0]["呼救时间"]).ToShortTimeString();
                                break;
                            case "出车时间":
                                lblCC.Text = Convert.ToDateTime(dt.Rows[0]["出车时间"]).ToShortTimeString();
                                break;
                            case "出诊医生到达现场":
                                lblCZYSDDXC.Text = Convert.ToDateTime(dt.Rows[0]["出诊医生到达现场"]).ToShortTimeString();
                                break;
                            case "首次医疗接触时间":
                                lblSCYLJC.Text = Convert.ToDateTime(dt.Rows[0]["首次医疗接触时间"]).ToShortTimeString();
                                break;
                            case "院前首份心电图":
                                lblYQSFXDT.Text = Convert.ToDateTime(dt.Rows[0]["院前首份心电图"]).ToShortTimeString();
                                break;
                            case "心电图诊断时间":
                                lblSCXDT.Text = Convert.ToDateTime(dt.Rows[0]["心电图诊断时间"]).ToShortTimeString();
                                break;
                            case "远程心电传输时间":
                                lblXDTCS.Text = Convert.ToDateTime(dt.Rows[0]["远程心电传输时间"]).ToShortTimeString();
                                break;
                            case "生化标志物抽血时间":
                                lblSHBZWCX.Text = Convert.ToDateTime(dt.Rows[0]["生化标志物抽血时间"]).ToShortTimeString();
                                break;
                            case "到达本院大门时间":
                                lblDDBYDM.Text = Convert.ToDateTime(dt.Rows[0]["到达本院大门时间"]).ToShortTimeString();
                                break;
                            case "患者到达急诊科时间":
                                lblHZDDJZK.Text = Convert.ToDateTime(dt.Rows[0]["患者到达急诊科时间"]).ToShortTimeString();
                                break;
                            case "院内接诊时间":
                                lblYNJZ.Text = Convert.ToDateTime(dt.Rows[0]["院内接诊时间"]).ToShortTimeString();
                                break;
                            case "院内首份心电图时间":
                                lblYNSFXDT.Text = Convert.ToDateTime(dt.Rows[0]["院内首份心电图时间"]).ToShortTimeString();
                                break;
                            case "生化标志物报告时间":
                                lblSHBZWBG.Text = Convert.ToDateTime(dt.Rows[0]["生化标志物报告时间"]).ToShortTimeString();
                                break;
                            case "初步诊断时间":
                                lblCBZD.Text = Convert.ToDateTime(dt.Rows[0]["初步诊断时间"]).ToShortTimeString();
                                break;
                            case "首次给药时间":
                                lblSCGY.Text = Convert.ToDateTime(dt.Rows[0]["首次给药时间"]).ToShortTimeString();
                                break;
                            case "院内心内科医生首诊时间":
                                lblYNXNKYSSZ.Text = Convert.ToDateTime(dt.Rows[0]["院内心内科医生首诊时间"]).ToShortTimeString();
                                break;
                            case "患者到达CCU":
                                lblHZDDCCU.Text = Convert.ToDateTime(dt.Rows[0]["患者到达CCU"]).ToShortTimeString();
                                break;
                            case "溶栓时间":
                                lblRSZL.Text = Convert.ToDateTime(dt.Rows[0]["溶栓时间"]).ToShortTimeString();
                                break;
                            case "决定介入手术时间":
                                lblJDJRSS.Text = Convert.ToDateTime(dt.Rows[0]["决定介入手术时间"]).ToShortTimeString();
                                break;
                            case "启动导管室时间":
                                lblQDDGS.Text = Convert.ToDateTime(dt.Rows[0]["启动导管室时间"]).ToShortTimeString();
                                break;
                            case "介入人员到达时间":
                                lblJRRYDD.Text = Convert.ToDateTime(dt.Rows[0]["介入人员到达时间"]).ToShortTimeString();
                                break;
                            case "开始知情同意时间":
                                lblKSZQTY.Text = Convert.ToDateTime(dt.Rows[0]["开始知情同意时间"]).ToShortTimeString();
                                break;
                            case "签署知情同意时间":
                                lblQSZQTY.Text = Convert.ToDateTime(dt.Rows[0]["签署知情同意时间"]).ToShortTimeString();
                                break;
                            case "导管室激活时间":
                                lblDGSJH.Text = Convert.ToDateTime(dt.Rows[0]["导管室激活时间"]).ToShortTimeString();
                                break;
                            case "患者到达导管室":
                                lblHZDDGS.Text = Convert.ToDateTime(dt.Rows[0]["患者到达导管室"]).ToShortTimeString();
                                break;
                            case "开始穿刺时间":
                                lblKSCC.Text = Convert.ToDateTime(dt.Rows[0]["开始穿刺时间"]).ToShortTimeString();
                                break;
                            case "造影开始时间":
                                lblZYKS.Text = Convert.ToDateTime(dt.Rows[0]["造影开始时间"]).ToShortTimeString();
                                break;
                            case "造影结束时间":
                                lblZYJS.Text = Convert.ToDateTime(dt.Rows[0]["造影结束时间"]).ToShortTimeString();
                                break;
                            case "再次签署知情同意":
                                lblZCQSZQTY.Text = Convert.ToDateTime(dt.Rows[0]["再次签署知情同意"]).ToShortTimeString();
                                break;
                            case "球囊扩张时间":
                                lblQNKZ.Text = Convert.ToDateTime(dt.Rows[0]["球囊扩张时间"]).ToShortTimeString();
                                break;
                            case "手术结束时间":
                                lblSSJS.Text = Convert.ToDateTime(dt.Rows[0]["手术结束时间"]).ToShortTimeString();
                                lblend.Text = Convert.ToDateTime(dt.Rows[0]["手术结束时间"]).ToLongDateString();
                                break;
                            case "D2B时间":
                                lblDTOB.Text = dt.Rows[0]["D2B时间"].ToString()+"分钟";
                                break;
                        }
                    }

                }

            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        private void frmSJZ_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}