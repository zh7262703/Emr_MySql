using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TempertureEditor.Element;

namespace TempertureEditor
{
    /// <summary>
    /// 体温单数据操作
    /// </summary>
    public partial class frmTempertureDataEdit : Form
    {             
        Comm cm;
        private string TemptureXml; //体温单XML
        private XmlDocument xmldoc; //
        ucTempertureEditor fcEdit;
        private int MaxId = 0;  //当前最大Id

        DateTime dateStart = new DateTime();
        DateTime dateEnd = new DateTime();

        bool isAddflag = false;
        private string cutrrentid = "0";
        
        DataTable dt;

        public frmTempertureDataEdit(ucTempertureEditor fcedit)
        {
            InitializeComponent();           

            fcEdit = fcedit;
            cm = fcedit.cm;
            
            dt = new DataTable();
            DataColumn dc0 = new DataColumn("主键", Type.GetType("System.String"));
            DataColumn dc1 = new DataColumn("数据类型", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("时间", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("值", Type.GetType("System.String"));
            dt.Columns.Add(dc0);
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);

            xmldoc = new XmlDocument();

            string testDataFullName = cm.GetTestDataFullName();

            if (!File.Exists(testDataFullName))
            {
                xmldoc.LoadXml(cm.GetTestDataDefaultContent());
                xmldoc.Save(testDataFullName);
            }
            else
            {
                xmldoc.Load(testDataFullName);
            }
            dataTpicTime.Enabled = false;

            XmlNodeList nodes = xmldoc.GetElementsByTagName("page");
            dtpStart.Value = Convert.ToDateTime(nodes[0].Attributes["Starttime"].Value);

            refdatagrid();

            /*
             * 初始化类型
             */
            foreach (ClsLinedata ldata in cm.listlinedatas)
            {
                cboDataType.Items.Add(ldata.Name);
            }

            foreach(ClsTextdata ldata in cm.listtextdatas)
            {
                cboDataType.Items.Add(ldata.Name);
            }
            
            if (cboDataType.Items.Count > 0)
                cboDataType.SelectedIndex = 0;
        }

        private void refdatagrid()
        {

            string testDataFullName = cm.GetTestDataFullName();

            if (!File.Exists(testDataFullName))
            { 
                xmldoc.LoadXml(cm.GetTestDataDefaultContent());
                xmldoc.Save(testDataFullName);
            }
            else
            {
                xmldoc.Load(testDataFullName);
            }
            XmlNodeList nodes = xmldoc.GetElementsByTagName("page");
            //dataGridView1.Rows.Clear();
            dt.Clear();
            //获取所有的页
            for (int i = 0; i < nodes.Count; i++)
            {
                XmlNode tempelement = nodes[i];              

                foreach (XmlNode tempobjelement in tempelement.ChildNodes)
                {
                    DataRow dr = dt.NewRow();
                    dr["主键"] = tempobjelement.Attributes["id"].Value;
                    dr["数据类型"] = tempobjelement.Attributes["clsdate"].Value;
                    dr["时间"] = tempobjelement.Attributes["rdatetime"].Value;
                    dr["值"] = tempobjelement.InnerText;
                    dt.Rows.Add(dr);
                }
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
            dataGridView1.Columns["时间"].Width = 150;
            dataGridView1.Columns["值"].Width = 150;
        }

        public void refleshtree()
        {
            //TimeSpan ts1 = new TimeSpan(inDatetime.Ticks);
            //TimeSpan ts2 = new TimeSpan(today.Ticks);
            //TimeSpan ts = ts1.Subtract(ts2).Duration();
            //int weekCount = 0;
            //if ((ts.Days + 1) % 7 == 0)
            //    weekCount = (ts.Days + 1) / 7;
            //else
            //    weekCount = (ts.Days + 1) / 7 + 1;

            //string temper = "";
            //for (int i = 0; i < weekCount; i++)
            //{
            //    temper = "第" + (i + 1).ToString() + "页(" + inDatetime.AddDays(i * 7).ToString("yyyy-MM-dd") +
            //       '~' + inDatetime.AddDays(i * 7 + 6).ToString("yyyy-MM-dd") + ")";
            //    TreeNode tn = new TreeNode();
            //    tn.Text = temper;
            //    this.tvTimes.Nodes.Add(tn);
            //    temper = "";
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frmTempertureDataEdit_Load(object sender, EventArgs e)
        {
           
        }

        private void btnSure_Click(object sender, EventArgs e)
        {

            

            if (txtVal.Text == "")
            {
                MessageBox.Show("值不能为空！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVal.Focus();
                return;
            }
            
            
            foreach(ClsLinedata temp in cm.listlinedatas)
            {
                if (temp.Name == cboDataType.Text)
                {
                    if (!cm.isfloattype(txtVal.Text))
                    {
                        MessageBox.Show("该数据类型值该为数值类型！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtVal.Focus();
                        return;
                    }
                }
            }

            if (chkNoTime.Checked)
            {
                if (dataTpicTime.Value < dateStart ||
                    dataTpicTime.Value > Convert.ToDateTime(lblEndTime.Text))
                {
                    MessageBox.Show("日期必须在给定的范围内！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dataTpicTime.Focus();
                    return;
                }
            }

            try
            {
                if (isAddflag)
                {
                    //添加
                    XmlNodeList nodes = xmldoc.GetElementsByTagName("page");
                    XmlElement tn = xmldoc.CreateElement("ClsDataObj");
                    tn.SetAttribute("id", Convert.ToString(MaxId + 1));
                    tn.SetAttribute("clsdate", cboDataType.Text);
                    if (chkNoTime.Checked)
                        tn.SetAttribute("rdatetime", dataTpicTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    else
                        tn.SetAttribute("rdatetime", "");
                    tn.InnerText = txtVal.Text;
                    nodes[0].AppendChild(tn);


                }
                else
                {
                    //修改
                    XmlNode node = xmldoc.SelectSingleNode("Tempture/page/ClsDataObj[@id='" + cutrrentid + "']");
                    if (node != null)
                    {
                        if (chkNoTime.Checked)
                            node.Attributes["rdatetime"].Value = dataTpicTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
                        else
                            node.Attributes["rdatetime"].Value = "";
                        node.Attributes["clsdate"].Value = cboDataType.Text;
                        node.InnerText = txtVal.Text;
                    }

                }
                xmldoc.Save(cm.GetTestDataFullName());
                MessageBox.Show("操作成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.ClearSelection();
                refdatagrid();
                cm.GetTestPages();
                fcEdit.Refresh();
                if (isAddflag)
                {
                    button2_Click(sender,e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败，原因：" + ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 新建数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            lblNowOperaterType.Text = "添加";
            int cc = 0;
            dataGridView1.ClearSelection();
            foreach (DataGridViewRow temprow in dataGridView1.Rows)
            {
                cc = Convert.ToInt32(temprow.Cells["主键"].Value);
                if (cc > MaxId)
                {
                    MaxId = cc;
                }
            }
            txtVal.Text = "";
            isAddflag = true;
            cboDataType.Focus();

        }

        private void chkNoTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNoTime.Checked)
            {
                dataTpicTime.Enabled = true;
            }
            else
            {
                dataTpicTime.Enabled = false;
            }

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 删除所选的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                XmlNodeList nodes = xmldoc.GetElementsByTagName("page");
                bool isdel = false;
                foreach (DataGridViewRow temprow in this.dataGridView1.SelectedRows)
                {                   
                    DelXmlNodeById(temprow.Cells["主键"].Value.ToString(), nodes, ref isdel);
                }
               
                xmldoc.Save(cm.GetTestDataFullName());
                refdatagrid();
                MessageBox.Show("删除成功！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cm.GetTestPages();
                fcEdit.Refresh();               
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！原因："+ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="xnodes"></param>
        /// <param name="sflag"></param>
        public static void DelXmlNodeById(string Id, XmlNodeList xnodes, ref bool sflag)
        {
            foreach (XmlNode xnode in xnodes)
            {
                bool ishaveattributes = false;
                if (xnode.Attributes != null)
                {
                    foreach (XmlAttribute tat in xnode.Attributes)
                    {
                        if (tat.Name == "id")
                        {
                            ishaveattributes = true;
                        }
                    }

                    if (ishaveattributes)
                    {
                        if (xnode.Attributes["id"].Value.ToString() == Id)
                        {

                            XmlElement xe = (XmlElement)xnode.ParentNode;
                            xe.RemoveChild(xnode);
                            sflag = true;
                            return;
                        }
                    }
                    if (xnode.ChildNodes.Count > 0)
                        DelXmlNodeById(Id, xnode.ChildNodes, ref sflag);
                }
            }

        }

        private void txtVal_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /// <summary>
        /// 设置时间范围
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                MessageBox.Show("设置当前页之前时间范围，需要清空现有数据！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            XmlNodeList nodes = xmldoc.GetElementsByTagName("page");
            nodes[0].Attributes["Starttime"].Value = dtpStart.Value.ToString("yyyy-MM-dd")+" 00:00:00";
            nodes[0].Attributes["Endtime"].Value = lblEndTime.Text;//dtpStart.Value.ToString("yyyy-MM-dd")+ " 23:59:59";
            xmldoc.Save(cm.GetTestDataFullName());
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            lblEndTime.Text = dtpStart.Value.AddDays(6).ToString("yyyy-MM-dd") + " 23:59:59";
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                lblNowOperaterType.Text = "修改";
                isAddflag = false;
                cutrrentid = dataGridView1["主键", dataGridView1.CurrentRow.Index].Value.ToString();
                //e.RowIndex
                cboDataType.Text = dataGridView1["数据类型", dataGridView1.CurrentRow.Index].Value.ToString();
                if (dataGridView1["时间", dataGridView1.CurrentRow.Index].Value != null)
                {
                    if (dataGridView1["时间", dataGridView1.CurrentRow.Index].Value.ToString().Trim() != "")
                    {
                        dataTpicTime.Value = Convert.ToDateTime(dataGridView1["时间", dataGridView1.CurrentRow.Index].Value);
                        chkNoTime.Checked = true;
                    }
                    else
                    {
                        chkNoTime.Checked = false;
                    }
                }
                else
                    chkNoTime.Checked = false;
                txtVal.Text = dataGridView1["值", dataGridView1.CurrentRow.Index].Value.ToString();
            }
            catch
            {

            }
        }
    }
}
