using Bifrost;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor.EditDesigner
{
    partial class ucAiTemperature
    {

        #region 控件事件详细处理
        private void panel4_SizeChanged(Control sender, params Control[] controls)
        {

        }

        //编辑或打印模式切换
        private void ckMode_CheckedChanged(Control sender, params Control[] controls)
        {
        }

        /// <summary>
        /// 体温单模板类型切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="controls"></param>
        private void templateType_CheckedChanged(Control sender, params Control[] controls)
        {
        
        }

        #endregion

        #region 自定义事件详细处理
        private void Register_ucTemperatureFrame(Control sender, params Control[] controls)
        {

            #region 注册接口:增加特殊控件处理函数后,在此添加新函数至容器
            RegisterEventSubHandler("panel4_SizeChanged", panel4_SizeChanged);
            RegisterEventSubHandler("ckMode_CheckedChanged", ckMode_CheckedChanged);
            RegisterEventSubHandler("templateType_CheckedChanged", templateType_CheckedChanged);

            #endregion

            #region 注册自定义事件处理接口
            RegisterCustomEventHandler("TemperatureReportRefreshData", TemperatureReportRefreshData);
            RegisterCustomEventHandler("ucTemperatureLrToolBar_InitData", ucTemperatureLrToolBar_InitData);

            #endregion
        }

        private void TemperatureReportRefreshData(Control sender, params Control[] controls)
        {
            ucAiTemperature ucTLrToolBar = (ucAiTemperature)controls[0];
            ucTemperatureReport ucTReport = (ucTemperatureReport)controls[1];

            ucTReport.RefreshData(ucTLrToolBar.startDate, ucTLrToolBar.endDate, ucTLrToolBar.tPatInfo, (ucTLrToolBar.pageSelectedIndex + 1).ToString(), ucTLrToolBar.outTime, ucTLrToolBar.TemplateType);
        }

        private void ucTemperatureLrToolBar_InitData(Control sender, params Control[] controls)
        {
            ucAiTemperature ucTemperatureLrToolBar = (ucAiTemperature)controls[0];

            ucTemperatureLrToolBar.ucTemperatureLrToolBar_InitData(tPatInfo);
        }
        #endregion

            #region 本类中辅助函数
        public void ucTemperatureFrame_InitData(InPatientInfo tPatInfo)
        {
            this.tPatInfo = tPatInfo;

            ucAiTemperatureCustomEventHnadler("MSG_ucTemperatureLrToolBar_InitData");
        }
        #endregion
    }
}
