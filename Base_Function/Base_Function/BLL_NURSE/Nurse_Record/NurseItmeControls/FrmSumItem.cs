using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    public partial class FrmSumItem : DevComponents.DotNetBar.Office2007Form
    {
        public bool successflag = false; //操作是否成功
        private string ID;//统计ID
        private string Type;//统计ID
        public FrmSumItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type">D:成人,C:儿童,O:产科,B:新生儿</param>
        public FrmSumItem(string id,string type)
        {
            InitializeComponent();
            ID = id;
            Type = type;
            if (Type=="D")
            {
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
            }
            else if (Type=="O")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
                panel4.Visible = false;
            }
            else if (Type == "C")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
                panel4.Visible = false;
            }
            else if (Type == "B")
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = true;
            }
        }


        private void FrmSumItem_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            successflag = false;
            this.Close();
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {//D:成人,C:儿童,O:产科
            string str="";
            if (Type == "D")
            {
                if (checkBox9.Checked)
                {
                    str += checkBox9.Text + "|";
                }
                if (chkDB.Checked)
                {
                    str += chkDB.Text + "|";
                }
                if (chkXB.Checked)
                {
                    str += chkXB.Text + "|";
                }
                if (chkG1.Checked)
                {
                    str += chkG1.Text + "|";
                }
                if (chkG2.Checked)
                {
                    str += chkG2.Text + "|";
                }
                if (chkG3.Checked)
                {
                    str += chkG3.Text + "|";
                }
                if (chkG4.Checked)
                {
                    str += chkG4.Text + "|";
                }
                if (chkG5.Checked)
                {
                    str += chkG5.Text + "|";
                }
            }
            else if (Type == "O")
            {
                if (checkBox5.Checked)
                {
                    str += checkBox5.Text + "|";
                }
                if (chkYDLX.Checked)
                {
                    str += chkYDLX.Text + "|";
                }
                if (chkNY.Checked)
                {
                    str += chkNY.Text + "|";
                }
                if (chkQT.Checked)
                {
                    str += chkQT.Text + "|";
                }
            }
            else if (Type == "C")
            {
                if (cbBabyIn.Checked)
                {
                    str += cbBabyIn.Text + "|";
                }
                if (cbBabyInOther.Checked)
                {
                    str += cbBabyInOther.Text + "|";
                }
                if (cbBabyShit.Checked)
                {
                    str += cbBabyShit.Text + "|";
                }
                if (cbBabyU.Checked)
                {
                    str += cbBabyU.Text + "|";
                }
                if (cbBabyOther1.Checked)
                {
                    str += cbBabyOther1.Text + "|";
                }
                if (cbBabyOther2.Checked)
                {
                    str += cbBabyOther2.Text + "|";
                }
            }
            else if (Type == "B")
            {
                GetSectString(panel4, ref str);
            }
            if (str!="")
            {
                str=str.Substring(0, str.Length - 1);
                string sql = "update t_nurse_dangery_inout_sum_h set sum_item='" + str + "' where id=" + ID;
                if (App.ExecuteSQL(sql) > 0)
                {
                    successflag = true;
                    this.Close();
                }
            }
            else
            {
                App.Msg("提示:请至少选择一个项目统计!");
                return;
            }
            
        }

        /// <summary>
        /// 获取容器中被选中的CheckBox
        /// </summary>
        /// <param name="p"></param>
        /// <param name="strSectString"></param>
        private void GetSectString(Panel p,ref string strSectString)
        {
            foreach (Control c in p.Controls)
            {
                if (c is CheckBox)
                {
                    CheckBox cb = (CheckBox)c;
                    if (cb.Checked)
                    {
                        strSectString += cb.Text + "|";
                    }
                }
            }
        }
    }
}