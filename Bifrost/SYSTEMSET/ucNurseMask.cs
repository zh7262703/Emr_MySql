using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.SYSTEMSET
{
    /// <summary>
    /// 护理项目维护模块
    /// 作者：张华
    /// 日期：2013-02-22
    /// </summary>
    public partial class ucNurseMask : UserControl
    {
        private string CurrentItemId = ""; //当前选择的节点的ID


        //绑定项目护理类别
        private void Item_Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='20'");
            cboItem_type.DataSource = ds.Tables[0].DefaultView;
            cboItem_type.ValueMember = "ID";
            cboItem_type.DisplayMember = "NAME";
        }
        //绑定项目护理属性
        private void Item()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='23'");
            cboItem.DataSource = ds.Tables[0].DefaultView;
            cboItem.ValueMember = "ID";
            cboItem.DisplayMember = "NAME";
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucNurseMask()
        {
            InitializeComponent();
        }


        private void ucNurseMask_Load(object sender, EventArgs e)
        {
            Item_Type();
            Item();
        }

        /// <summary>
        /// 添加顶级节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_AddTop_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 添加当前节点的子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_AddChild_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 删除当前节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {

        }
    }
}
