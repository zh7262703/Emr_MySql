using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;


namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class ucElement : UserControl
    {
        private static string name = ""; //´æ´¢¿Õ¼äÃû  
        private string flagid;
        public static string id;
        public string Flagid
        {
            get { return flagid; }
            set { flagid = value; }
        }
        public static string myName;
  

        public ucElement()
        {
            InitializeComponent();
            showContent.Text = name;
        }
        public ucElement(string showName,string myid)
        {
            InitializeComponent();
            showContent.Text = showName;
            flagid = myid;
            this.Tag = myid;
            this.Width = this.showContent.Width;
            
        }

        private void showContent_DoubleClick(object sender, EventArgs e)
        {
            if (App.Ask("ÊÇ·ñÉ¾³ý"))
            {
                
                this.Dispose();
            }
        }
    }
}
