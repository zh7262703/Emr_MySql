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

            dt.Columns[0].ColumnName = "���";
            dt.Columns[1].ColumnName = "����";
            dt.Columns[2].ColumnName = "�Ա�";
            dt.Columns[4].ColumnName = "ת������";
            dt.Columns[5].ColumnName = "ת�����";
            dt.Columns[6].ColumnName = "ת��ʱ��";
            dt.Columns[7].ColumnName = "��ǰ����";
            flgView.AllowEditing = false;
            flgView.DataSource = dt;

            
            
            flgView.Cols["said"].Visible = false;
            flgView.Cols["sick_area_name"].Visible = false;
            
            flgView.Cols["sid"].Visible = false;
        }
    }
}