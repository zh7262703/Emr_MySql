using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class frmTurnInOut_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {
        public frmTurnInOut_PatientInfo()
        {
            InitializeComponent();
        }

        public frmTurnInOut_PatientInfo(DataTable dt)
        {
            InitializeComponent();
            App.ButtonStytle(this);

            dt.Columns[0].ColumnName = "序号";
            dt.Columns[1].ColumnName = "姓名";
            dt.Columns[2].ColumnName = "性别";
            dt.Columns[4].ColumnName = "转出科室";
            dt.Columns[5].ColumnName = "转入科室";
            dt.Columns[6].ColumnName = "转科时间";
            dt.Columns[7].ColumnName = "当前科室";
            flgView.AllowEditing = false;
            flgView.DataSource = dt;

            
            
            flgView.Cols["said"].Visible = false;
            flgView.Cols["sick_area_name"].Visible = false;
            
            flgView.Cols["sid"].Visible = false;
        }
    }
}