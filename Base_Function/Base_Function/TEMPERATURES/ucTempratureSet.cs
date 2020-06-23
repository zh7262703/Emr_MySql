using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.TEMPERATURES
{
    /// <summary>
    /// ���µ����Ե�����
    /// </summary>
    public partial class ucTempratureSet : UserControl
    {

        printTemper ph = new printTemper();
        private string in_date = string.Empty;
        private string pid = string.Empty;
        private string dcgDate = string.Empty;
        private string dcgBatchno = string.Empty;
        private string hepatitsDate = string.Empty;
        private string hepatitsBatchno = string.Empty;
        private string startTime;
        private string endTime;
        private bool isChild = false;
        private string id = string.Empty;
        public string CurrentNodeStr;

        private Point start = new Point();//�������
        private Point end = new Point();//�����յ�
        private bool blnDraw = false;//�Ƿ�ʼ������
        Graphics g;
        Graphics g_p;

        public ucTempratureSet()
        {
            InitializeComponent();
            //ph.Hospital = "XXXXXXҽԺ";
            //ph.TextName = "�� �� �� ¼ ��";
            //ph.User.Add("������", "����");
            //ph.User.Add("���ţ�", "1��");
            //ph.User.Add("�Ա�", "��");
            //ph.User.Add("���ң�", "�����ڿ�");
            //ph.User.Add("������", "�����ڿƲ���");
            //ph.User.Add("��Ժ����:", "2010-11-05 11:11");
            //ph.User.Add("סԺ��:", "98905");

            //this.startTime = "2011-12-22";
            //this.endTime = "2011-12-28";
            //this.in_date = "2011-12-22 00:00";
            //this.pid = "98905";
            //ph.Init("98905", "2010-11-05 11:11");                               
            
            ph.Hospital = App.HospitalTittle;
            ph.Bingqu = "�����ڿƲ���";
            ph.TextName = "�� �� �� ¼ ��";
            ph.User.Add("����:", "XXX");
            ph.User.Add("�Ա�:", "��");
            ph.User.Add("�Ʊ�:", "�����ڿ�");
            ph.User.Add("����:","61��");
            ph.User.Add("����:", "01");
            ph.User.Add("��Ժ����:", "2011-12-22 00:00");
            ph.User.Add("סԺ��:", "98905");
            this.startTime = "2011-12-22";
            this.endTime = "2011-12-28";
            this.in_date = "2011-12-22 00:00";
            this.pid = "98905";
            ph.Init("98905", "2010-11-05 11:11");    
        }

        /// <summary>
        /// ���µ��Ѿ���������
        /// </summary>
        private void RefreshDataGrid()
        {
            DataSet ds = App.GetDataSet("select t.area_name as ��������,t.start_x as �������X,t.start_y as �������Y,t.height as ����߶�,t.width as ������,t.operater_form as ������ʽ from t_tempreture_op_set t");
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;
        }
                     
          

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(38, 78);
            ph.printMain(e.Graphics, this.startTime, this.endTime);  
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
          
            g = this.pictureBox1.CreateGraphics();
            start.X = e.X;
            start.Y = e.Y;
            end.X = e.X;
            end.Y = e.Y;
            blnDraw = true;            
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                pictureBox1.Refresh();
                g_p = pictureBox1.CreateGraphics();
                g_p.TranslateTransform(38, 78);
                ph.printMain(g_p, this.startTime, this.endTime);
                g.DrawRectangle(new Pen(Color.GreenYellow, 3), start.X, start.Y, e.X - start.X, e.Y - start.Y);

                blnDraw = false;

                if (start.X != e.X)
                {
                    frmSetValueProperty fc = new frmSetValueProperty(start.X, start.Y, e.X - start.X, e.Y - start.Y);
                    fc.ShowDialog();
                    RefreshDataGrid();
                    g_p = pictureBox1.CreateGraphics();
                    g_p.TranslateTransform(38, 78);
                    ph.printMain(g_p, this.startTime, this.endTime);

                }
            }
            catch
            { }
        }            

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (blnDraw)
            {
                pictureBox1.Refresh();
                g_p = pictureBox1.CreateGraphics();
                g_p.TranslateTransform(38, 78);
                ph.printMain(g_p, this.startTime, this.endTime);
                g.DrawRectangle(new Pen(Color.GreenYellow, 3), start.X, start.Y, e.X - start.X, e.Y - start.Y);
            }
        }

        private void ucTempratureSet_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Left = 0;
                pictureBox1.Top = 0;
                pictureBox1.Width = ph.pWidth;
                pictureBox1.Height = ph.pHeight;                        
                pictureBox1.Refresh();
                RefreshDataGrid();
             
            }
            catch
            { }
        }

        private void dataGridViewX1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            g_p = pictureBox1.CreateGraphics();
            g_p.TranslateTransform(38, 78);
            ph.printMain(g_p, this.startTime, this.endTime);
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            //pictureBox1.Refresh();
            //g_p = pictureBox1.CreateGraphics();
            //g_p.TranslateTransform(38, 78);
            //ph.printMain(g_p, this.startTime, this.endTime);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void ɾ����¼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (App.Ask("ȷ��Ҫɾ����" + dataGridViewX1["��������", dataGridViewX1.CurrentRow.Index].Value.ToString() + "����"))
                {
                    if (App.ExecuteSQL("delete from t_tempreture_op_set where area_name='" + dataGridViewX1["��������", dataGridViewX1.CurrentRow.Index].Value.ToString() + "'") > 0)
                    {
                        App.Msg("�����Ѿ��ɹ���");
                    }
                    else
                    {
                        App.MsgErr("�������ɹ���");
                    }
                }

            }
            catch
            {
                App.MsgErr("�������ɹ���");
            }
        }         

    }
}
