using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls
{
    public partial class frmFormula : DevComponents.DotNetBar.Office2007Form
    {
        public bool successflag = false; //�����Ƿ�ɹ�

        /// <summary>
        /// ����ͼƬ
        /// </summary>
        public Image ImgTemp;

        private InPatientInfo currentpatient;      //��������
        private string measureTime = "";           //����ʱ��
        private string showname = "";              //��ʾ����


        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="patient">����ʵ����</param>
        /// <param name="dtime">ִ��ʱ��</param>
        /// <param name="sname">��ʾ����</param>
        public frmFormula(InPatientInfo patient, string dtime,string sname)
        {
            InitializeComponent();
            currentpatient = patient;
            measureTime = dtime;
            showname = sname;
        }

        private void frmFormula_Load(object sender, EventArgs e)
        {
        }

        private Image DrawValueImage(string val)
        {
            Pen blackPen = new Pen(Color.Black, 1f);
            if (val.Contains(","))
            {
                string[] strs = val.Split(',');
                string UpL = "";    //����
                string UpR = "";   //����
                string DownL = ""; //����
                string DownR = ""; //����
                Font df = new Font("����", 8f);
                StringFormat sf = new StringFormat();
                sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.FitBlackBox;
                SizeF UpLSize = new SizeF();
                SizeF UpRSize = new SizeF();
                SizeF DownLSize = new SizeF();
                SizeF DownRSize = new SizeF();
                UpL = strs[0];
                UpR = strs[1];
                DownL = strs[2];
                DownR = strs[3];
                Bitmap bt = new Bitmap(35, 25);
                Graphics g = Graphics.FromImage(bt);
                UpLSize = g.MeasureString(UpL, df);
                UpRSize = g.MeasureString(UpR, df);
                DownLSize = g.MeasureString(DownL, df);
                DownRSize = g.MeasureString(DownR, df);               
                //ʮ�ּ�
                g.DrawLine(blackPen, 0, bt.Height / 2, bt.Width, bt.Height / 2);
                g.DrawLine(blackPen, bt.Width / 2, 0, bt.Width / 2, bt.Height);
                //����
                g.DrawString(UpL, df, Brushes.Black, 1, 1);
                //����
                g.DrawString(UpR, df, Brushes.Black, bt.Width / 2 + 1, 1);
                //����
                g.DrawString(DownL, df, Brushes.Black, 1, bt.Height / 2 + 1);
                //����
                g.DrawString(DownR, df, Brushes.Black, bt.Width / 2 + 1, bt.Height / 2 + 1);
                Image myImage = bt;
                return myImage;
            }
            else
            {
                if (val != "")
                {
                    Font df = new Font("����", 10f);
                    Image imgTest = new Bitmap(50, 50);
                    Graphics grp = Graphics.FromImage(imgTest);
                    SizeF sz = grp.MeasureString(val, df);
                    Bitmap bt = new Bitmap((int)sz.Width, (int)sz.Height);
                    Graphics g = Graphics.FromImage(bt);
                    g.DrawString(val, df, Brushes.Black, 0, 0);
                    Image myImage = bt;
                    return myImage;
                }
                else
                {
                    return null;
                }
            }
        }

        private void btnSure_Click(object sender, EventArgs e)
        {
            string val = "";
            if (radioButton_Formula.Checked)
            {                
                val = txtUpL.Text + "," + txtUpR.Text + "," + txtDownL.Text + "," + txtDownR.Text;
            }
            else
            {
                if (txtNormalVal.Text != "")
                {
                    val = txtNormalVal.Text;
                }
                //else
                //{
                //    App.MsgWaring("ֵ����Ϊ�գ�");
                //    return;
                //}
            }
            //pictureBox1.Image = DrawValueImage(val);           
            //ȡ��ǰ����ʱ������Ĵ�����id
            string userId = "";
            try
            {
                userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentpatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                if (userId == null || userId == "")
                {
                    userId = App.UserAccount.UserInfo.User_id;
                }
            }
            catch (Exception ex)
            {
                userId = App.UserAccount.UserInfo.User_id;
            }
            string[] sqlstrs = new string[2];
            sqlstrs[0] = "delete from t_nurse_record where patient_id=" + currentpatient.Id + " and item_show_name='" + showname + "' and RECORD_TYPE='O' and measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9')";
            if (val.Replace(",","")!="")
            {
                sqlstrs[1] = "insert into t_nurse_record" +
                                         "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE)values" +
                                         "( '" + currentpatient.Sick_Bed_Name + "', '" + currentpatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '', '" + val + "', '" + userId + "', sysdate, " + currentpatient.Id + ", '" + showname + "','O')";
            }
            else
            {
                sqlstrs[1] = "";
            }
            
            if (App.ExecuteBatch(sqlstrs) > 0)
            {
                successflag = true;
                this.Close();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            successflag = false;
            this.Close();
        }
    }
}