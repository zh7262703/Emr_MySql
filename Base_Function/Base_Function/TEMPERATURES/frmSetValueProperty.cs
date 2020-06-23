using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.TEMPERATURES
{
    public partial class frmSetValueProperty : DevComponents.DotNetBar.Office2007Form
    {
        private float X = 0;
        private float Y = 0;
        private float D_Width = 0;
        private float D_Height = 0;

        public frmSetValueProperty()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dwidth"></param>
        /// <param name="dheight"></param>
        public frmSetValueProperty(float x,float y,float dwidth,float dheight)
        {
            InitializeComponent();
            X = x;
            Y =y;
            D_Width=dwidth;
            D_Height = dheight;
        }

        private void frmSetValueProperty_Load(object sender, EventArgs e)
        {
            label_X.Text ="起点坐标X:" +X.ToString();
            label_Y.Text = "起点坐标Y:" + Y.ToString();
            label_Width.Text = "区间宽度:" + D_Width.ToString();
            lable_Height.Text = "区间高度:" + D_Height.ToString();


        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {


            if (txtArea_name.Text.Trim() == "")
            {
                App.MsgWaring("区域名称不能为空！");
                return;
            }

            if (txtOperatorName.Text.Trim() == "")
            {
                App.MsgWaring("操作方式不能为空！");
                return;
            }

            DataSet ds_1 = App.GetDataSet("select * from T_TEMPRETURE_OP_SET where area_name='" + txtArea_name.Text + "'");

            if (ds_1.Tables[0].Rows.Count > 0)
            {
                if (!App.Ask("已经存在了相同区域名称的记录,如果继续操作会对已有的记录进行修改，是否继续?"))
                {
                    return;
                }

            }

            string Sql = "insert into T_TEMPRETURE_OP_SET(area_name,start_x,start_y,height,WIDTH,operater_form)values('" + txtArea_name.Text.Trim() + "'," + X.ToString() + "," + Y.ToString() + "," + D_Height + "," + D_Width + ",'" + txtOperatorName.Text.Trim() + "')";

            string[] strsqls = new string[2];
            strsqls[0] = "delete from T_TEMPRETURE_OP_SET where area_name='" + txtArea_name.Text + "'";
            strsqls[1] = Sql;

            if (App.ExecuteBatch(strsqls) > 0)
            {
                App.Msg("设置成功！");
                this.Close();
            }
            else
            {
                App.MsgErr("设置失败！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}