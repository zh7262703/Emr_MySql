using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace TempertureEditor
{
    public partial class UcTempertureCheckValSet : UserControl
    {
        bool flagTemperature = false;
        Class_Temperature_Monitoring ctm = new Class_Temperature_Monitoring();
        

        public UcTempertureCheckValSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 容器类某些控件的值不能为空
        /// </summary>
        /// <param name="parContainer">容器类控件</param>
        /// <param name="flag">用于判断是否可用</param>
        public static bool IsNotNull(Control parContainer)
        {
            bool flag = false;
            for (int index = 0; index < parContainer.Controls.Count; index++)
            {
                //如果是容器类控件，递归调用自己
                if (parContainer.Controls[index].HasChildren)
                {
                    IsNotNull(parContainer.Controls[index]);
                }
                else
                {
                    switch (parContainer.Controls[index].GetType().Name)
                    {
                        case "TextBox":
                            if (parContainer.Controls[index].Text == "" || parContainer.Controls[index].Text == null)
                            {
                                flag = true;
                            }
                            break;
                    }
                }
            }
            if (flag)
            {
                MessageBox.Show("文本框不能为空，请输入值，默认为0", "错误提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            return flag;
        }

        

        /// <summary>
        /// 获取监测值中的TextBox数据
        /// </summary>
        private void GetMonitoringTextBoxValue()
        {
            // 体温
            ctm.TemperatureMax = Convert.ToDouble(this.txtTemperatureMax.Text);
            ctm.TemperatureMin = Convert.ToDouble(this.txtTemperatureMin.Text);

            //脉搏
            ctm.PulseMax = Convert.ToDouble(this.txtPulseMax.Text);
            ctm.PulseMin = Convert.ToDouble(this.txtPulseMin.Text);


            //呼吸
            ctm.BreathMax = Convert.ToDouble(this.txtBreathMax.Text);
            ctm.BreathMin = Convert.ToDouble(this.txtBreathMin.Text);

            //收缩压 
            ctm.SBPMax = Convert.ToDouble(this.txtSBPMax.Text);
            ctm.SBPMin = Convert.ToDouble(this.txtSBPMin.Text);

            //舒张压
            ctm.DBPMax = Convert.ToDouble(this.txtDBPMax.Text);
            ctm.DBPMin = Convert.ToDouble(this.txtDBPMin.Text);

            //大便
            ctm.StoolMax = Convert.ToDouble(this.txtStoolMax.Text);
            ctm.StoolMin = Convert.ToDouble(this.txtStoolMin.Text);
        }

        private void btnSaveJC_Click(object sender, EventArgs e)
        {

            if (flagTemperature)
            {
                GetMonitoringTextBoxValue();
                //血压没有起作用，同样屏蔽掉
                //string tempSQL = "update T_TEMPERATURE_MONITORING t set t.TemperatureMax=" + ctm.TemperatureMax + ",t.TemperatureMin=" + ctm.TemperatureMin + ",t.PulseMax=" + ctm.PulseMax + ",t.PulseMin=" + ctm.PulseMin + ",t.BreathMax=" + ctm.BreathMax + ",t.BreathMin=" + ctm.BreathMin + ",t.SBPMax=" + ctm.SBPMax + ",t.SBPMin=" + ctm.SBPMin + ",t.DBPMax=" + ctm.DBPMax + ",t.DBPMin=" + ctm.DBPMin + ",t.StoolMax=" + ctm.StoolMax + ",t.StoolMin=" + ctm.StoolMin;
                string tempSQL = "update T_TEMPERATURE_MONITORING t set t.TemperatureMax=" + ctm.TemperatureMax + ",t.TemperatureMin=" + ctm.TemperatureMin + ",t.PulseMax=" + ctm.PulseMax + ",t.PulseMin=" + ctm.PulseMin + ",t.BreathMax=" + ctm.BreathMax + ",t.BreathMin=" + ctm.BreathMin + ",t.StoolMax=" + ctm.StoolMax + ",t.StoolMin=" + ctm.StoolMin;
                int i = 0;
                DialogResult result = MessageBox.Show("确认要保存已修改的数据？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    i = App.ExecuteSQL(tempSQL);
                }
                else
                {
                    return;
                }


                if (i > 0)
                {
                    App.Msg("数据修改成功！");                   
                }
                else
                {
                    App.MsgErr("数据修改失败！");
                }
            }
            else
            {
                if (IsNotNull(grpMonitoring))
                {
                    return;
                }
                else
                {
                    GetMonitoringTextBoxValue();
                    string tempSQL = "insert into T_TEMPERATURE_MONITORING values(" + ctm.TemperatureMax + "," + ctm.TemperatureMin + "," + ctm.PulseMax + "," + ctm.PulseMin + "," + ctm.BreathMax + "," + ctm.BreathMin + "," + ctm.SBPMax + "," + ctm.SBPMin + "," + ctm.DBPMin + "," + ctm.DBPMax + "," + ctm.StoolMax + "," + ctm.StoolMin + ")";
                    int i = 0;
                    DialogResult result = MessageBox.Show("确认要保存数据？", "消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        i = App.ExecuteSQL(tempSQL);
                    }
                    else
                    {
                        return;
                    }
                    if (i > 0)
                    {
                        App.Msg("添加成功！");                       
                    }
                    else
                    {
                        App.MsgErr("添加失败！");
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcTempertureCheckValSet_Load(object sender, EventArgs e)
        {
            try
            {
                //---------------------------体温监测--------------------------------
                DataSet dsTemperature = App.GetDataSet("select * from T_TEMPERATURE_MONITORING");//体温监测
                int count = dsTemperature.Tables[0].Rows.Count;
                if (count >= 1)
                {
                    flagTemperature = true;

                    this.txtTemperatureMax.Text = dsTemperature.Tables[0].Rows[0]["TEMPERATUREMAX"].ToString();
                    this.txtTemperatureMin.Text = dsTemperature.Tables[0].Rows[0]["TEMPERATUREMIN"].ToString();
                    this.txtPulseMax.Text = dsTemperature.Tables[0].Rows[0]["PULSEMAX"].ToString();
                    this.txtPulseMin.Text = dsTemperature.Tables[0].Rows[0]["PULSEMIN"].ToString();
                    this.txtBreathMax.Text = dsTemperature.Tables[0].Rows[0]["BREATHMAX"].ToString();
                    this.txtBreathMin.Text = dsTemperature.Tables[0].Rows[0]["BREATHMIN"].ToString();

                    this.txtSBPMax.Text = dsTemperature.Tables[0].Rows[0]["SBPMAX"].ToString();
                    this.txtSBPMin.Text = dsTemperature.Tables[0].Rows[0]["SBPMIN"].ToString();

                    this.txtDBPMax.Text = dsTemperature.Tables[0].Rows[0]["DBPMAX"].ToString();
                    this.txtDBPMin.Text = dsTemperature.Tables[0].Rows[0]["DBPMIN"].ToString();

                    this.txtStoolMax.Text = dsTemperature.Tables[0].Rows[0]["STOOLMAX"].ToString();
                    this.txtStoolMin.Text = dsTemperature.Tables[0].Rows[0]["STOOLMIN"].ToString();
                }
            }
            catch
            { }

        }
    }
}
