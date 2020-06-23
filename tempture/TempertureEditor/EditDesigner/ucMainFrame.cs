using Bifrost;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.Element;

namespace TempertureEditor.EditDesigner
{
    partial class ucAiTemperature
    {

        #region 控件事件详细处理
        /// <summary>
        /// 体温单模板类型切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="controls"></param>
        private void temperatureFrame_Click(Control sender, params Control[] controls)
        {
            Panel panelTemperatureFrame1 = (Panel)controls[0];
            Panel GroupPanel2 = (Panel)controls[1];
            panelTemperatureFrame1.Controls.Clear();

            ucAiTemperature ucTemperatureFrame = null;

            foreach (Control cl in GroupPanel2.Controls)
            {
                int index = listWinControls.IndexOf(cl);

                if (index >= 0 && _clmb.listTlControls[index].Type == "RadioButton")
                {
                    RadioButton rdBtn = (RadioButton)cl;
                    if (rdBtn.Checked)
                    {
                        if (_clmb.dicVars.ContainsKey(rdBtn.Name))
                        {
                            ucTemperatureFrame = new ucAiTemperature(_clmb.dicVars[rdBtn.Name].Trim());
                            break;
                        }
                    }
                }
            }

            if (ucTemperatureFrame != null)
            {
                ucTemperatureFrame.ucTemperatureFrame_InitData(this.tPatInfo);
                ucTemperatureFrame.Dock = DockStyle.Fill;
                panelTemperatureFrame1.Controls.Add(ucTemperatureFrame);
            }

        }

        #endregion

        #region 自定义事件详细处理
        private void Register_ucMainFrame(Control sender, params Control[] controls)
        {

            #region 注册接口:增加特殊控件处理函数后,在此添加新函数至容器
            RegisterEventSubHandler("temperatureFrame_Click", temperatureFrame_Click);

            #endregion

            #region 注册自定义事件处理接口
            #endregion
        }

        #endregion

        #region 本类中辅助函数
        public void ucMainFrame_InitData(InPatientInfo tPatInfo)
        {
            this.tPatInfo = tPatInfo;

        }
        #endregion
    }
}
