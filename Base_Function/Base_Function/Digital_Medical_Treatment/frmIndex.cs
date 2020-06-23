using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base_Function;
using Bifrost;
using Digital_Medical_Treatment.A_Discussion;
namespace Digital_Medical_Treatment
{
    /// <summary>
    /// 登陆界面
    /// </summary>
    public partial class frmIndex : UserControl
    {
        public frmIndex()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 护理看板配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfig_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfig frm = new frmConfig();
                frm.ShowDialog();
                 
            }
            catch 
            {
                
            }
        }
        /// <summary>
        /// 医生看板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDoctor_Click(object sender, EventArgs e)
        {
            UcDoctor frm = new UcDoctor();
            frm.ShowDialog();
        }
        /// <summary>
        /// 护士看板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNurse_Click(object sender, EventArgs e)
        {
            UcNurse frm = new UcNurse();
            frm.ShowDialog();
        }
        /// <summary>
        /// 屏幕控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScreenControl_Click(object sender, EventArgs e)
        {
            UcPMKZ frm = new UcPMKZ();
            frm.ShowDialog();
        }
        /// <summary>
        /// 备注编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            UcMark frm = new UcMark();
            frm.ShowDialog();
        }
        /// <summary>
        /// 病情讨论
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            UcDiscussionList frm = new UcDiscussionList();
            frm.ShowDialog();
        }

        private void frmIndex_Load(object sender, EventArgs e)
        {
            try
            {               
                string discusstextid = App.Read_ConfigInfo("WebServerPath", "DISCUSSTEXT", App.SysPath + "\\Config.ini");
                if (discusstextid == "")
                {
                    discusstextid = "6963715";
                    App.Write_ConfigInfo("WebServerPath", "DISCUSSTEXT", discusstextid, App.SysPath + "\\Config.ini");
                }

                Base_Function.BASE_COMMON.DataInit.discuss_text_id = Convert.ToInt32(discusstextid);

                this.btnConfig.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
                this.btnConfig.ForeColor = Color.White;
                this.btnDoctor.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
                this.btnDoctor.ForeColor = Color.White;
                this.btnNurse.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
                this.btnNurse.ForeColor = Color.White;
                this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
                this.buttonX1.ForeColor = Color.White;
                this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
                this.btnEdit.ForeColor = Color.White;
                pictureBox1.BackColor = Color.White;
            }
            catch(Exception ex)
            {
                App.MsgErr("数字化病区，初始化失败！" + ex.Message);
            }
        }
    }
}
