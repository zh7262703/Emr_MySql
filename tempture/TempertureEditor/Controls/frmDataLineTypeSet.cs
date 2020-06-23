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
    public partial class frmDataLineTypeSet : Form
    {
        Comm cm = null;
        public frmDataLineTypeSet(ref Comm cm)
        {
            InitializeComponent();
            this.cm = cm;
            //画笔
            if (cm.listpens.Count > 0)
            {
                foreach (ClsPens temppen in cm.listpens)
                {
                    cboPenType.Items.Add(temppen);
                    cboPenType.DisplayMember = "Tname";
                    cboPenType.ValueMember = "Id";
                }
                cboPenType.SelectedIndex = 0;
            }

            //标签
            if (cm.listsymbols.Count>0)
            {
                foreach (ClsSymbol tempsymbol in cm.listsymbols)
                {
                    cboSymbol.Items.Add(tempsymbol);
                    cboSymbol.DisplayMember = "name";
                    cboSymbol.ValueMember = "name";
                }
                cboPenType.SelectedIndex = 0;
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text.Trim() == "")
                {
                    MessageBox.Show("名称不能为空！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                
                
                ///Start Add by xiao at 2017/3/15
                if (cm.IsExistsNodeName("ClsLinedata", txtName.Text, cm.XmlDoc.ChildNodes))
                {
                    MessageBox.Show("相同名称已经存在！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ///End
                
                ClsLinedata tempdata = new ClsLinedata();
                tempdata.Name = txtName.Text;
                tempdata.Symbolname = cboSymbol.Text;
                tempdata.Penid = cboPenType.Text;
                tempdata.X = Convert.ToSingle(numD_X.Value);
                tempdata.Y = Convert.ToSingle(numD_Y.Value);
                tempdata.Span_x = Convert.ToSingle(numD_SpanX.Value);
                tempdata.Span_y = Convert.ToSingle(numD_SpanY.Value);
                tempdata.Scale = txtScale.Text;
                tempdata.Basevalue = txtBaseVal.Text;
                tempdata.Broken = txtBrokenSet.Text;

                cm.newnode = new TreeNode();
                cm.newnode.Text = tempdata.Name;
                cm.newnode.Name = tempdata.Name;
                cm.newnode.Tag = tempdata;
                this.Close();
            }
            catch
            {
                cm.newnode = null;
            }

        }

        private void frmDataTextTypeSet_Load(object sender, EventArgs e)
        {

        }

        private void txtScale_TextChanged(object sender, EventArgs e)
        {            
        }

        private void txtBaseVal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtScale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = false;
                }
                else
                    e.Handled = true;
                //MessageBox.Show("只能输入数字和小数点!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txtBaseVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = false;
                }
                else
                    e.Handled = true;
                //MessageBox.Show("只能输入数字和小数点!");
            }
            else
            {
                e.Handled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
