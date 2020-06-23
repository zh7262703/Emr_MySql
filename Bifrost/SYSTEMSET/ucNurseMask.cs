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
    /// ������Ŀά��ģ��
    /// ���ߣ��Ż�
    /// ���ڣ�2013-02-22
    /// </summary>
    public partial class ucNurseMask : UserControl
    {
        private string CurrentItemId = ""; //��ǰѡ��Ľڵ��ID


        //����Ŀ�������
        private void Item_Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='20'");
            cboItem_type.DataSource = ds.Tables[0].DefaultView;
            cboItem_type.ValueMember = "ID";
            cboItem_type.DisplayMember = "NAME";
        }
        //����Ŀ��������
        private void Item()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='23'");
            cboItem.DataSource = ds.Tables[0].DefaultView;
            cboItem.ValueMember = "ID";
            cboItem.DisplayMember = "NAME";
        }

        /// <summary>
        /// ���캯��
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
        /// ��Ӷ����ڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_AddTop_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ��ӵ�ǰ�ڵ���ӽڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_AddChild_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// ɾ����ǰ�ڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Del_Click(object sender, EventArgs e)
        {

        }
    }
}
