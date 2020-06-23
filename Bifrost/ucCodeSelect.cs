using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Leadron
{
    public partial class ucCodeSelect : UserControl
    {
        /// <summary>
        /// �����ֶ�
        /// </summary>
        private string sel_name;
        
        /// <summary>
        /// ֵ�ֶ�
        /// </summary>
        private string sel_val;

        /// <summary>
        /// �󶨿ؼ�
        /// </summary>
        private Control trltepm;

        /// <summary>
        /// ���캯��
        /// </summary>
        public ucCodeSelect()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// ���������캯��
        /// </summary>
        /// <param name="Sql">sql���</param>
        /// <param name="trlTepm">�󶨿ؼ���</param>
        /// <param name="Sel_Name">�ֶ���</param>
        /// <param name="Sel_Val">ֵ</param>
        public void IniucCodeSelect(string Sql, Control trlTepm, string Sel_Name, string Sel_Val)
        {           
            fg.DataSource = App.GetDataSet(Sql).Tables[0].DefaultView;               
            this.Parent = trlTepm.Parent;
            this.BringToFront();                   
            Point p=new Point(trlTepm.Location.X,trlTepm.Location.Y+trlTepm.Height);
            
            this.Location = p;           
            sel_name = Sel_Name;
            sel_val = Sel_Val;
            trltepm = trlTepm;
            //fg.Focus();
        }

        /// <summary>
        /// �����ѯ�����ȡ����
        /// </summary>
        public void Fg_Focus()
        {
            fg.Focus();
        }

        private void fg_DoubleClick(object sender, EventArgs e)
        {
            if (fg.RowSel > 0)
            {
                App.SelectObj = new Class_SelectObj();
                App.SelectObj.Select_Name = fg[fg.RowSel, sel_name].ToString();
                App.SelectObj.Select_Val = fg[fg.RowSel, sel_val].ToString();
                trltepm.Text = App.SelectObj.Select_Name;
                trltepm.Focus();
            }
            trltepm.Parent.Controls.Remove(this);
        }

        private void fg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (fg.RowSel > 0)
                {
                    App.SelectObj = new Class_SelectObj();
                    App.SelectObj.Select_Name = fg[fg.RowSel, sel_name].ToString();
                    App.SelectObj.Select_Val = fg[fg.RowSel, sel_val].ToString();
                    trltepm.Text = App.SelectObj.Select_Name;                    
                    trltepm.Focus();
                    App.FastCodeFlag = true;
                }
                trltepm.Parent.Controls.Remove(this);
               
            }
            else if (e.KeyCode == Keys.Escape)
            {
                App.SelectObj = null;
                trltepm.Parent.Controls.Remove(this);
            }
        }
    }
}
