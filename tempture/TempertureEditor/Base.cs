using Bifrost;
using System;
using System.Collections.Generic;
using System.Text;

namespace TempertureEditor
{
    public class Base
    {
        /// <summary>
        /// 体温单编辑器        
        /// </summary>
        public void frmTempertureEditorShow()
        {
            ucTempertureEditor uc = new ucTempertureEditor();
            App.UsControlStyle(uc);
            App.AddNewBusUcControl(uc, "体温单编辑器");
        }
    }
}
