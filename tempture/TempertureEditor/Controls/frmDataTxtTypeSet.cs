using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TempertureEditor.Element;

namespace TempertureEditor.Controls
{
    public partial class frmDataTxtTypeSet : Form
    {
        Comm cm = null;
        public frmDataTxtTypeSet(ref Comm cm)
        {
            InitializeComponent();
            this.cm = cm;
            if (cm.listfonts.Count > 0)
            {
                foreach (ClsFont temppen in cm.listfonts)
                {
                    cboFontType.Items.Add(temppen);
                    cboFontType.DisplayMember = "Tname";
                    cboFontType.ValueMember = "Id";
                }
                cboFontType.SelectedIndex = 0;
            }
            cboTDirection.SelectedIndex = 0;
            cboShowType.SelectedIndex = 0;
            cboAlign.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    MessageBox.Show("名称不能为空！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ///Start Add by xiao at 2017/3/15
                if (cm.IsExistsNodeName("ClsTextdata", txtName.Text, cm.XmlDoc.ChildNodes))
                {
                    MessageBox.Show("相同名称已经存在！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ///End
                
                ClsTextdata temptext = new ClsTextdata();
                temptext.Align = cboAlign.Text;
                temptext.Name = txtName.Text;
                temptext.Tdirection = cboTDirection.Text;
                temptext.Texttype = cboShowType.Text;
                temptext.Theight = Convert.ToInt16(numD_Height.Value);
                temptext.Twidth = Convert.ToInt16(numD_Width.Value);
                temptext.X = Convert.ToSingle(numD_X.Value);
                temptext.Y = Convert.ToSingle(numD_Y.Value);
                temptext.Fontid = cboFontType.Text;

                cm.newnode = new TreeNode();
                cm.newnode.Text = temptext.Name;
                cm.newnode.Name = temptext.Name;
                cm.newnode.Tag = temptext;
                this.Close();

            }
            catch
            {
                cm.newnode = null;
            }
        }
    }
}
