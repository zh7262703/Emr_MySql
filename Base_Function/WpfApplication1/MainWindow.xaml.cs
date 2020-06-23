using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Forms;

namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.txtgd.Text = Screen.PrimaryScreen.WorkingArea.Height.ToString();
            this.txtkd.Text = Screen.PrimaryScreen.WorkingArea.Width.ToString();
            //this.Width = Screen.PrimaryScreen.Bounds.Width;
            //this.Height = Screen.PrimaryScreen.Bounds.Height;
        }
    }
}
