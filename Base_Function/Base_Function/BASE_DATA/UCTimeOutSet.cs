using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    public partial class UCTimeOutSet : UserControl
    {
        public UCTimeOutSet()
        {
            InitializeComponent();
        }

        private void txtCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //�����������֡�С���㡢ɾ�����͸���  
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                MessageBox.Show("������������");
                this.txtCount.Text = "";
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string[] strArr = new string[2];
                strArr[0] = "delete from t_timeout";
                strArr[1] = "insert into t_timeout(count,unit)values(" + txtCount.Text + ",'" + cboUnit.Text + "')";
                int num = App.ExecuteBatch(strArr);
                if (num > 0)
                {
                    App.Msg("����ɹ���");
                    //���°󶨳�ʱʱ��
                    DataSet ds_timeout = App.GetDataSet("select * from t_timeout");
                    if (ds_timeout != null)
                    {
                        if (ds_timeout.Tables[0].Rows.Count > 0)
                        {
                            App.UserAccount.TimeOut = Convert.ToInt32(ds_timeout.Tables[0].Rows[0]["count"]);
                            App.UserAccount.TimeOut_Unit = ds_timeout.Tables[0].Rows[0]["unit"].ToString();
                            if (App.UserAccount.TimeOut_Unit == "��")
                            {
                                App.UserAccount.Enable_end_time = App.GetSystemTime().AddMinutes(App.UserAccount.TimeOut);
                            }
                            else
                            {
                                App.UserAccount.Enable_end_time = App.GetSystemTime().AddSeconds(App.UserAccount.TimeOut);
                            }
                        }
                    }
                }
                else
                {
                    App.Msg("����ʧ�ܣ�");
                }
            }
            catch (Exception ex)
            {

                App.MsgErr(ex.Message);
            }
        }

        private void UCTimeOutSet_Load(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = App.GetDataSet("select * from t_timeout");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtCount.Text = ds.Tables[0].Rows[0]["count"].ToString();
                        cboUnit.Text = ds.Tables[0].Rows[0]["unit"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void txtCount_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
