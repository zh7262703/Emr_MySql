using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Base_Function.BLL_FOLLOW.DispalayList;

namespace Base_Function.BLL_FOLLOW
{
    public partial class ucTest : UserControl
    {
        public ucTest()
        {
            InitializeComponent();
            IniTabPanel();
        }
        public void IniTabPanel()
        {
            ucFollowTobeFinished ucTF = new ucFollowTobeFinished();
            ucTF.Dock = DockStyle.Fill;
            this.tabControlPanel1.Controls.Add(ucTF);
            this.tabItem1.Text = "待访列表";
            //新加一个TabControlPanel
            DevComponents.DotNetBar.TabControlPanel tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            tabControlPanel2.Dock = DockStyle.Fill;
            DevComponents.DotNetBar.TabItem tabItem2 = new DevComponents.DotNetBar.TabItem();
            this.tabControl1.Controls.Add(tabControlPanel2);
            this.tabControl1.Tabs.Add(tabItem2);
            tabItem2.AttachedControl = tabControlPanel2;
            ucTodayFollowList ucTdF = new ucTodayFollowList();
            ucTdF.Dock = DockStyle.Fill;
            tabControlPanel2.Controls.Add(ucTdF);
            tabItem2.Text = "今日随访列表";

            DevComponents.DotNetBar.TabControlPanel tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            tabControlPanel5.Dock = DockStyle.Fill;
            DevComponents.DotNetBar.TabItem tabItem5 = new DevComponents.DotNetBar.TabItem();
            this.tabControl1.Controls.Add(tabControlPanel5);
            this.tabControl1.Tabs.Add(tabItem5);
            tabItem5.AttachedControl = tabControlPanel5;
            ucFollowVisite visit = new ucFollowVisite();
            visit.Dock = DockStyle.Fill;
            tabControlPanel5.Controls.Add(visit);
            tabItem5.Text = "随访列表";

            DevComponents.DotNetBar.TabControlPanel tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            tabControlPanel3.Dock = DockStyle.Fill;
            DevComponents.DotNetBar.TabItem tabItem3 = new DevComponents.DotNetBar.TabItem();
            this.tabControl1.Controls.Add(tabControlPanel3);
            this.tabControl1.Tabs.Add(tabItem3);
            tabItem3.AttachedControl = tabControlPanel3;
            ucFollowDieList ucFDL = new ucFollowDieList();
            ucFDL.Dock = DockStyle.Fill;
            tabControlPanel3.Controls.Add(ucFDL);
            tabItem3.Text = "死亡列表";

            DevComponents.DotNetBar.TabControlPanel tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            tabControlPanel4.Dock = DockStyle.Fill;
            DevComponents.DotNetBar.TabItem tabItem4 = new DevComponents.DotNetBar.TabItem();
            this.tabControl1.Controls.Add(tabControlPanel4);
            this.tabControl1.Tabs.Add(tabItem4);
            tabItem4.AttachedControl = tabControlPanel4;
            ucFollowCancel ucCancel = new ucFollowCancel();
            ucCancel.Dock = DockStyle.Fill;
            tabControlPanel4.Controls.Add(ucCancel);
            tabItem4.Text = "不随访列表";


        }
    }
}
