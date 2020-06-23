using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record_Manager
{
    public partial class UcInout_Amount : UserControl
    {
        //项目代码
        public string Item_code;
        public string Name;
        private int _index;
        public string ItemType;
        public string ItemMode;
        //定义事件
        public event UcInout_AddControla.RefPanel EventRef;
        TextBox txtName = new TextBox();
        public UcInout_Amount(string name,string item_code,string itemtype,string itemmode)
        {
            InitializeComponent();
            lblName.Text = name;
            this.Item_code = item_code;
            this.ItemType = itemtype;
            this.ItemMode = itemmode;
            if (name == "其它")
            {
                if (item_code == "8")
                {
                    lblName.Text = "管入";     //项目名称
                }
                else if (item_code == "4")
                {
                    lblName.Text = "口入";
                }
                else if (item_code == "17")
                {
                    lblName.Text = "经静脉入";
                }
                else if (item_code == "30")
                {
                    lblName.Text = "引流";
                }
                btnOthers.Visible = true;
                //lblName.Visible = false;
                txtName = new TextBox();
                this.txtName.AutoSize = true;
                this.txtName.Location = new System.Drawing.Point(txtValue.Location.X - 30, txtValue.Location.Y);
                this.txtName.Name = "txtName";
                this.txtName.Size = new System.Drawing.Size(47, 12);
                this.txtName.TabIndex = 0;
                this.txtValue.Visible = true;
                this.txtValue.Location = new System.Drawing.Point(txtName.Location.X + 50, txtName.Location.Y);
                this.txtValue.Size = new System.Drawing.Size(txtValue.Width - 20, txtValue.Height);
                txtName.Text = "其它";
                this.Controls.Add(txtName);
            }
            else
            {
                btnOthers.Visible = false;
            }

        }
        public UcInout_Amount(string name, string item_code,bool fla)
        {
            InitializeComponent();
            if (item_code == "8")
            {
                lblName.Text = "管入";     //项目名称
            }
            else if (item_code == "4")
            {
                lblName.Text = "口入";
            }
            else if (item_code == "17")
            {
                lblName.Text = "经静脉入";
            }
            else if (item_code == "30")
            {
                lblName.Text = "引流";
            }
            this.Item_code = item_code;
            btnOthers.Visible = fla;
            if (name == "其它")
            {
                txtName = new TextBox();
                this.txtName.AutoSize = true;
                this.txtName.Location = new System.Drawing.Point(txtValue.Location.X - 30, txtValue.Location.Y);
                //this.txtName.Location = new System.Drawing.Point(2, 6);
                this.txtName.Name = "txtName";
                this.txtName.Size = new System.Drawing.Size(47, 12);
                txtName.KeyUp += new KeyEventHandler(txtName_KeyUp);
                this.txtName.TabIndex = 0;
                this.txtValue.Visible = true;
                this.txtValue.Location = new System.Drawing.Point(txtName.Location.X + 50, txtName.Location.Y);
                this.txtValue.Size = new System.Drawing.Size(txtValue.Width - 20, txtValue.Height);
                txtName.Text = "其它";
                this.Controls.Add(txtName);
            }
    

        }

        private void txtName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                App.SelectFastCodeCheck();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                App.HideFastCodeCheck();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                string sql = "";
                if (txtName.Text.Trim() != "")
                {
                    #region
                    //    if (IfItemName == true)
                    //    {
                    //        if (flgView[1, flgView.ColSel].ToString() == "口入")
                    //        {
                    //            sql = "select ITEM_NAME as 名称 from t_inout_amount_dict where ITEM_NAME like '%" + resuleBox.Text + "%' and ITEM_MODE=111 order by id";
                    //        }
                    //        else if (flgView[1, flgView.ColSel].ToString() == "管入")
                    //        {
                    //            sql = "select ITEM_NAME as 名称 from t_inout_amount_dict where ITEM_NAME like '%" + resuleBox.Text + "%' and ITEM_MODE=112 order by id";
                    //        }
                    //        else if (flgView[1, flgView.ColSel].ToString() == "经静脉入")
                    //        {
                    //            sql = "select ITEM_NAME as 名称 from t_inout_amount_dict where ITEM_NAME like '%" + resuleBox.Text + "%' and ITEM_MODE=113 order by id";
                    //        }
                    //        else if (flgView[1, flgView.ColSel].ToString() == "引流")
                    //        {
                    //            sql = "select ITEM_NAME as 名称 from t_inout_amount_dict where ITEM_NAME like '%" + resuleBox.Text + "%' and item_type=110 and drainage_attribute!=1 order by id";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        sql = "select ITEM_NAME as 名称 from t_inout_amount_dict where ITEM_NAME like '%" + resuleBox.Text + "%' order by id";
                    //    }
                    //}
                    #endregion
                    sql = "select ITEM_NAME as 名称 from t_inout_amount_dict where ITEM_NAME like '%" + txtName.Text + "%' order by id";
                }
                DataSet ds = App.GetDataSet(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (!App.FastCodeFlag)
                    {
                        App.FastCodeCheck(sql, txtName, "名称", "名称");
                    }
                    App.FastCodeFlag = false;
                }
                else
                {
                    App.Msg("医药库没有这种药品名!");
                } 
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //触发事件
            if (EventRef != null)
            {
                EventRef(this);
            }
        }

        public static bool IsFloat(string inString)
        {

            Regex regex = new Regex(@"^\d*\.?\d*$");

            return regex.IsMatch(inString.Trim());

        }

        private void txtValue_Validating(object sender, CancelEventArgs e)
        {
            if(!IsFloat(txtValue.Text))
            {
                App.MsgErr("请输入大于零的数字！");
                this.Focus();
            }
        }
        // 赋值给传过来的参数
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (lblName.Text == "管入" || lblName.Text == "口入" || lblName.Text == "经静脉入" || lblName.Text == "引流")
            {
                Name = txtName.Text.Trim();
            }
            else
            {
                Name = lblName.Text.Trim();
            }
        }
        /// <summary>
        /// 添加其他项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOthers_Click(object sender, EventArgs e)
        {
            if (Item_code == "8" || Item_code == "4" || Item_code == "17" || Item_code == "30" && txtName.Text == "其它")
            {
                UcInout_AddControla.OtherName(txtName.Text, Item_code);
                //Btn.Visible = false;
            }
        }

    }
}
