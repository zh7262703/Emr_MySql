using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{    
    /// <summary>
    /// IP��ַר�������
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2009-9-10
    /// </summary>
    public partial class IPAddressTextBox : UserControl
    {
        private string _text = "";

        /// <summary>
        /// ���캯��
        /// </summary>
        public IPAddressTextBox()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskIpAddr(textBox1, e);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskIpAddr(textBox2, e);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskIpAddr(textBox3, e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            MaskIpAddr(textBox4, e);
        }

        private void IPAddressTextBox_Load(object sender, EventArgs e)
        {

        }

        private void MaskIpAddr(System.Windows.Forms.TextBox textBox, KeyPressEventArgs e)
        {
            int len = textBox.Text.Length;
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == 8)
            {
                if (e.KeyChar != 8)
                {
                    if (len == 2 && e.KeyChar != '.')
                    {
                        string tmp = textBox.Text + e.KeyChar;
                        if (textBox.Name == "textBox1")
                        {
                            if (Int32.Parse(tmp) > 223) // ������֤
                            {
                                MessageBox.Show(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 223 ֮�����ֵ��");
                                textBox.Text = "223";
                                textBox.Focus();
                                return;
                            }
                            textBox2.Focus();
                            textBox2.SelectAll();

                        }
                        else if (textBox.Name == "textBox2")
                        {
                            if (Int32.Parse(tmp) > 255)
                            {
                                MessageBox.Show(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 255 ֮�����ֵ��");
                                textBox.Text = "255";
                                textBox.Focus();
                                return;
                            }
                            textBox3.Focus();
                            textBox3.SelectAll();
                        }
                        else if (textBox.Name == "textBox3")
                        {
                            if (Int32.Parse(tmp) > 255)
                            {
                                MessageBox.Show(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 255 ֮�����ֵ��");
                                textBox.Text = "255";
                                textBox.Focus();
                                return;
                            }
                            textBox4.Focus();
                            textBox4.SelectAll();
                        }
                        else if (textBox.Name == "textBox4")
                        {
                            if (Int32.Parse(tmp) > 255)
                            {
                                MessageBox.Show(tmp + " ����һ����Ч��Ŀ����ָ��һ������ 1 �� 255 ֮�����ֵ��");
                                textBox.Text = "255";
                                textBox.Focus();
                                return;
                            }

                        }

                    }
                    if (e.KeyChar == '.')
                    {
                        if (textBox.Name == "textBox1" && textBox.Text != "")
                        {
                            textBox2.Focus();
                            textBox2.SelectAll();
                        }
                        if (textBox.Name == "textBox2" && textBox.Text != "")
                        {
                            textBox3.Focus();
                            textBox3.SelectAll();
                        }
                        if (textBox.Name == "textBox3" && textBox.Text != "")
                        {
                            textBox4.Focus();
                            textBox4.SelectAll();
                        }
                        if (textBox.Name == "textBox4" && textBox.Text != "")
                        {

                        }
                        e.Handled = true;
                    }
                }
                else
                {
                    if (textBox.Name == "textBox1" && textBox.Text == "")
                    {

                    }
                    if (textBox.Name == "textBox2" && textBox.Text == "")
                    {
                        textBox1.Focus();
                        textBox1.SelectionStart = textBox1.Text.Length;
                    }
                    if (textBox.Name == "textBox3" && textBox.Text == "")
                    {
                        textBox2.Focus();
                        textBox2.SelectionStart = textBox2.Text.Length;
                    }
                    if (textBox.Name == "textBox4" && textBox.Text == "")
                    {
                        textBox3.Focus();
                        textBox3.SelectionStart = textBox3.Text.Length;
                    }
                    e.Handled = false;
                }
            }
            else
                e.Handled = true;
        }

        /// <summary>
        /// ��ȡ IpBox ���ı���
        /// </summary>
        [Browsable(true)]          
        public new string Text
        {
            get
            {
                if (textBox1.Text == ""
                 || textBox2.Text == ""
                 || textBox3.Text == ""
                 || textBox4.Text == "")
                {
                    _text = "";
                    return _text;
                }
                else
                {
                    _text = Convert.ToInt32(textBox1.Text).ToString() + "." + Convert.ToInt32(textBox2.Text).ToString() + "." + Convert.ToInt32(textBox3.Text).ToString() + "." + Convert.ToInt32(textBox4.Text).ToString();
                    return _text;
                }

            }           
        }

        /// <summary>
        /// ����IP��ֵ
        /// </summary>
        /// <param name="IpAddress"></param>
        public void SetValue(string IpAddress)
        {
            try
            {
                if (App.IPAddressCheck(IpAddress))
                {
                    textBox1.Text = IpAddress.Split('.')[0];
                    textBox2.Text = IpAddress.Split('.')[1];
                    textBox3.Text = IpAddress.Split('.')[2];
                    textBox4.Text = IpAddress.Split('.')[3];
                }
                else
                {
                    App.MsgErr("������Ч��IP��ַ��ʽ��");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
                
            }
            catch
            {
                App.MsgErr("������Ч��IP��ַ��ʽ��");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

    }
}
