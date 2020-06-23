using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Base_Function.EMERGENCY
{
    public partial class ucOutPatientTJ : UserControl
    {
        public ucOutPatientTJ()
        {
            InitializeComponent();
            try
            {
                InitTableInfoList();
                InitControl();
            }
            catch (Exception ex)
            {
            }

        }

        List<TJTableInfo> TableInfoList = null;
        void InitTableInfoList()
        {
            TableInfoList = new List<TJTableInfo>();
            TJTableInfo tableinfo = new TJTableInfo();
            tableinfo.Name = "419";
            tableinfo.Caption = "首次医疗接触到首次心电图时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "420";
            tableinfo.Caption = "首次医疗接触到医师解读心电图的时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "421";
            tableinfo.Caption = "入门到生化标志物结果的时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "422";
            tableinfo.Caption = "首次D-to-B时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "423";
            tableinfo.Caption = "首次FMC-to-B时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "424";
            tableinfo.Caption = "STEMI患者的死亡率";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "425";
            tableinfo.Caption = "急救现场远程传输心电图的比例";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "426";
            tableinfo.Caption = "急救人员在现场确定STEMI的能力";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "427";
            tableinfo.Caption = "导管室团队启动时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "428";
            tableinfo.Caption = "确认第一个心电图提示STEMI到进入心导管室的时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "429";
            tableinfo.Caption = "非PCI机构与PCI机构之间的转诊时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "430";
            tableinfo.Caption = "溶栓治疗者,D-to-N或FMC-to-N时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "431";
            tableinfo.Caption = "转运PCI患者,入门到出门时间";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "432";
            tableinfo.Caption = "ACS漏诊率";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);

            tableinfo = new TJTableInfo();
            tableinfo.Name = "433";
            tableinfo.Caption = "改善社区教育";
            tableinfo.Order = TableInfoList.Count + 1;
            TableInfoList.Add(tableinfo);
        }

        void InitControl()
        {
            if (TableInfoList != null)
            {
                for (int i = 0; i < TableInfoList.Count; i++)
                {
                    ButtonItem btnItem = new ButtonItem();
                    this.BarGroupItem1.SubItems.Add(btnItem);
                    btnItem.Text = TableInfoList[i].Caption;
                    btnItem.Tag = TableInfoList[i];
                    btnItem.Click += new EventHandler(btnItem_Click);
                }
            }
        }

        void btnItem_Click(object sender, EventArgs e)
        {
            TJTableInfo tableinfo = (sender as ButtonItem).Tag as TJTableInfo;
            if (tableinfo == null)
                return;
            TabItem item = null;
            foreach (TabItem var in this.tabControl1.Tabs)
            {
                if (var.Text == tableinfo.Caption)
                {
                    item = var;
                    break;
                }
            }
            if (item == null)
            {
                ucList uclist = new ucList(tableinfo.Name);
                item = new TabItem();
                //item.Click += new EventHandler(item_Click);
                item.Text = tableinfo.Caption;
                TabControlPanel tcp = new TabControlPanel();
                this.tabControl1.Controls.Add(tcp);
                this.tabControl1.Tabs.Add(item);
                item.AttachedControl = tcp;
                tcp.TabItem = item;
                tcp.Dock = System.Windows.Forms.DockStyle.Fill;
                tcp.Padding = new System.Windows.Forms.Padding(1);
                tcp.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
                tcp.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
                tcp.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
                tcp.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
                tcp.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                            | DevComponents.DotNetBar.eBorderSide.Bottom)));
                tcp.Style.GradientAngle = 90;
                tcp.Controls.Add(uclist);
                uclist.Dock = DockStyle.Fill;
            }
            tabControl1.SelectedTab = item;
            this.tabControl1.Refresh();
        }
    }
}
