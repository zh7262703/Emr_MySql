using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Digital_Medical_Treatment
{
    public partial class frmConfig : DevComponents.DotNetBar.Office2007Form
    {

        int zkCount = 0;//质控已选项数量
        int zkhlCount = 0;//专科护理控件添加数量
        int WidthCount = 1;//专科护理每行控件总数

        //专科护理控件坐标
        int cboX = 0;
        int cboY = 0;

        //专科护理控件大小
        int cboWidth = 134;
        int cboHeight = 20;

        public frmConfig()
        {
            InitializeComponent();
            this.chkTW.Click += new System.EventHandler(this.chkZK_Click);
            this.chkDB.Click += new System.EventHandler(this.chkZK_Click);
            this.chkXB.Click += new System.EventHandler(this.chkZK_Click);
            this.chkXY.Click += new System.EventHandler(this.chkZK_Click);
            this.chkTZ.Click += new System.EventHandler(this.chkZK_Click);

            this.chkCXY.Click += new System.EventHandler(this.chkYZ_Click);
            this.chkCMB.Click += new System.EventHandler(this.chkYZ_Click);
            this.chkCHX.Click += new System.EventHandler(this.chkYZ_Click);
            this.chkCXL.Click += new System.EventHandler(this.chkYZ_Click);
            this.chkCBP.Click += new System.EventHandler(this.chkYZ_Click);
            this.chkP.Click += new System.EventHandler(this.chkYZ_Click);
            this.chkR.Click += new System.EventHandler(this.chkYZ_Click);
            this.chkHR.Click += new System.EventHandler(this.chkYZ_Click);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            cboX = cboZKHL0.Location.X + 30;
            cboY = btnAdd.Location.Y;
        }

        //增加专科护理项
        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnDel.Visible = true;
            if (zkhlCount > 10)
            {
                return;
            }
            ComboBox cbo = new ComboBox();
            cbo.Name = "cboZKHL" + (zkhlCount + 1);
            cbo.Text = "动态生成";
            cbo.Size = new Size(cboWidth, cboHeight);
            if (cboX + (WidthCount + 1) * cboWidth > this.Width)
            {
                WidthCount = 0;
                cboY += 30;
                cboX = cboZKHL0.Location.X;
                btnDel.Location = new Point(cboX + WidthCount * cboWidth, btnDel.Location.Y + 30);
            }
            cbo.Location = new Point(cboX + WidthCount * cboWidth, cboY);
            this.Controls.Add(cbo);
            cbo.BringToFront();

            btnDel.Location = new Point(cboX + (WidthCount + 1) * cboWidth + 5, btnDel.Location.Y);
            cboX += 30;
            zkhlCount++;
            WidthCount++;
        }

        //拟手术选项状态
        private void chkSYNSS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSYNSS.Checked == true)
            {

                chkJRNSS.Checked = false;
                chkMRNSS.Checked = false;
                chkJRNSS.Enabled = false;
                chkMRNSS.Enabled = false;
            }
            else
            {
                chkJRNSS.Enabled = true;
                chkMRNSS.Enabled = true;
            }
        }

        //质控选项点击事件
        private void chkZK_Click(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk.Checked == true)
            {
                if (zkCount >= 3)
                {
                    chk.Checked = false;
                    MessageBox.Show("选项超过3个。");
                }
                else
                {
                    zkCount++;
                }

            }
            else
            {
                zkCount--;
            }
        }

        //医嘱选项点击事件
        private void chkYZ_Click(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            switch (chk.Name)
            {
                case "chkCXY":
                    if (chk.Checked == true)
                    {
                        pnlCXY.Enabled = true;
                    }
                    else
                    {
                        pnlCXY.Enabled = false;
                        pnlEnabled(pnlCXY);

                    }
                    break;
                case "chkCMB":
                    if (chk.Checked == true)
                    {
                        pnlCMB.Enabled = true;
                    }
                    else
                    {
                        pnlCMB.Enabled = false;
                        pnlEnabled(pnlCMB);
                    }
                    break;
                case "chkCHX":
                    if (chk.Checked == true)
                    {
                        pnlCHX.Enabled = true;
                    }
                    else
                    {
                        pnlCHX.Enabled = false;
                        pnlEnabled(pnlCHX);
                    }
                    break;
                case "chkCXL":
                    if (chk.Checked == true)
                    {
                        pnlCXL.Enabled = true;
                    }
                    else
                    {
                        pnlCXL.Enabled = false;
                        pnlEnabled(pnlCXL);
                    }
                    break;
                case "chkCBP":
                case "chkP":
                case "chkR":
                case "chkHR":
                    if (chkCBP.Checked == true || chkP.Checked == true || chkR.Checked == true || chkHR.Checked == true)
                    {
                        pnlCDX.Enabled = true;
                    }
                    else
                    {
                        pnlCDX.Enabled = false;
                        pnlEnabled(pnlCDX);
                    }
                    break;
                default:
                    break;
            }

        }

        //更改pnl状态
        private void pnlEnabled(Panel pnl)
        {
            foreach (CheckBox chk in pnl.Controls)
            {
                chk.Checked = false;
            }
        }

        //判断医嘱已选项是否超过上限
        private void chkCHX12h_Click(object sender, EventArgs e)
        {
            if (pnlCDX.CheckCount() + pnlCHX.CheckCount() + pnlCMB.CheckCount() + pnlCXL.CheckCount() + pnlCXY.CheckCount() > 5)
            {
                CheckBox ch = sender as CheckBox;
                if (ch.Checked == true)
                    ch.Checked = false; MessageBox.Show("最多可选5项！");
            }
        }

        //删除专科护理选项
        private void btnDel_Click(object sender, EventArgs e)
        {
            this.Controls.RemoveByKey("cboZKHL" + zkhlCount);
            zkhlCount--;
            if (zkhlCount == 0)
            {
                btnDel.Visible = false;
            }

            foreach (Control c in this.Controls)
            {
                if (c.Name == "cboZKHL" + zkhlCount)
                {
                    if (WidthCount - 1 == 0)
                    {
                        WidthCount = 4;
                        btnDel.Location = new Point(c.Location.X + 5 + cboWidth, btnDel.Location.Y - 30);
                        cboY -= 30;
                        cboX += 30 * (WidthCount - 1);
                    }
                    else
                    {
                        btnDel.Location = new Point(c.Location.X + 5 + cboWidth, btnDel.Location.Y);
                        cboX -= 30;
                        WidthCount--;
                    }
                }
            }


        }

        //保存设置
        private void btnOK_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<HLKB/>");
            #region 病区概况
            XmlElement element = xmlDoc.CreateElement("bqgk");
            xmlDoc.DocumentElement.AppendChild(element);
            XmlElement bqgk;
            foreach (Control con in this.tblpnlBQGK.Controls)
            {
                if (con is ComboBox)
                {
                    bqgk = xmlDoc.CreateElement(con.Name);
                    bqgk.InnerText = con.Text;
                    element.AppendChild(bqgk);
                }
            }
            foreach (Control con in this.pnlNSS.Controls)
            {
                if (con is CheckBox)
                {
                    CheckBox chk = con as CheckBox;
                    if (chk.Checked)
                    {
                        bqgk = xmlDoc.CreateElement(con.Name);
                        bqgk.InnerText = con.Text;
                        element.AppendChild(bqgk);
                    }
                }
            }

            bqgk = xmlDoc.CreateElement(dtpStart.Name);
            bqgk.InnerText = dtpStart.Text;
            element.AppendChild(bqgk);

            bqgk = xmlDoc.CreateElement(dtpEnd.Name);
            bqgk.InnerText = dtpEnd.Text;
            element.AppendChild(bqgk);
            #endregion

            #region 生命体征监控
            XmlElement smtzjk;
            element = xmlDoc.CreateElement("smtzjk");
            xmlDoc.DocumentElement.AppendChild(element);
            foreach (Control con in this.pnlZK.Controls)
            {
                if (con is CheckBox)
                {
                    CheckBox chk = con as CheckBox;
                    if (chk.Checked)
                    {
                        smtzjk = xmlDoc.CreateElement(con.Name);
                        smtzjk.InnerText = con.Text;
                        element.AppendChild(smtzjk);
                    }
                }
            }

            foreach (Control con in this.pnlYZ.Controls)
            {
                if (con is CheckBox)
                {
                    CheckBox chk = con as CheckBox;
                    if (chk.Checked)
                    {
                        smtzjk = xmlDoc.CreateElement(con.Name);
                        switch (con.Name)
                        {
                            case "chkCXY":
                                foreach (Control item in pnlCXY.Controls)
                                {
                                    CheckBox chkyz = item as CheckBox;
                                    if (chkyz.Checked)
                                    {
                                        smtzjk.SetAttribute(chkyz.Name, chkyz.Text);
                                    }
                                }
                                break;
                            case "chkCMB":
                                foreach (Control item in pnlCMB.Controls)
                                {
                                    CheckBox chkyz = item as CheckBox;
                                    if (chkyz.Checked)
                                    {
                                        smtzjk.SetAttribute(chkyz.Name, chkyz.Text);
                                    }
                                }
                                break;
                            case "chkCHX":
                                foreach (Control item in pnlCHX.Controls)
                                {
                                    CheckBox chkyz = item as CheckBox;
                                    if (chkyz.Checked)
                                    {
                                        smtzjk.SetAttribute(chkyz.Name, chkyz.Text);
                                    }
                                }
                                break;
                            case "chkCXL":
                                foreach (Control item in pnlCXL.Controls)
                                {
                                    CheckBox chkyz = item as CheckBox;
                                    if (chkyz.Checked)
                                    {
                                        smtzjk.SetAttribute(chkyz.Name, chkyz.Text);
                                    }
                                }
                                break;
                            case "chkCBP":
                            case "chkP":
                            case "chkR":
                            case "chkHR":
                                foreach (Control item in pnlCDX.Controls)
                                {
                                    CheckBox chkyz = item as CheckBox;
                                    if (chkyz.Checked)
                                    {
                                        smtzjk.SetAttribute(chkyz.Name, chkyz.Text);
                                    }
                                }
                                break;
                        }

                        smtzjk.InnerText = con.Text;
                        element.AppendChild(smtzjk);
                    }
                }
            }
            #endregion
            #region 心电监护
            XmlElement xdjh;
            element = xmlDoc.CreateElement("xdjh");
            xmlDoc.DocumentElement.AppendChild(element);
            if (chkXDJH.Checked)
            {
                xdjh = xmlDoc.CreateElement(chkXDJH.Name);
                xdjh.InnerText = chkXDJH.Text;
                element.AppendChild(xdjh);
            }
            #endregion

            #region 专科护理
            XmlElement zkhl;
            element = xmlDoc.CreateElement("zkhl");
            xmlDoc.DocumentElement.AppendChild(element);
            foreach (Control con in this.Controls)
            {
                if (con is ComboBox)
                {
                    zkhl = xmlDoc.CreateElement(con.Name);
                    zkhl.InnerText = con.Text;
                    element.AppendChild(zkhl);
                }
            }
            #endregion

            #region 停医嘱后
            XmlElement tyz;
            element = xmlDoc.CreateElement("tyz");
            xmlDoc.DocumentElement.AppendChild(element);
            foreach (Control con in pnlTYZ.Controls)
            {
                if (con is RadioButton)
                {
                    RadioButton rdo = con as RadioButton;
                    if (rdo.Checked)
                    {
                        tyz = xmlDoc.CreateElement(rdo.Name);
                        tyz.InnerText = rdo.Text;
                        element.AppendChild(tyz);
                    }
                }
                else if (con is CheckBox)
                {
                    CheckBox chk = con as CheckBox;
                    if (chk.Checked)
                    {
                        tyz = xmlDoc.CreateElement(chk.Name);
                        tyz.InnerText = chk.Text;
                        element.AppendChild(tyz);
                    }
                }
                else if (con is TextBox)
                {
                    tyz = xmlDoc.CreateElement(con.Name);
                    tyz.InnerText = con.Text;
                    element.AppendChild(tyz);
                }
            }
            #endregion

            xmlDoc.Save(Application.StartupPath + "\\HLKBConfig.xml");
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //Form f = new UcNurse();
            //f.Show();
        }
    }
}
