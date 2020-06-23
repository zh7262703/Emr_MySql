using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using Bifrost;
using System.Reflection;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Base_Function.BASE_COMMON;

namespace Base_Function.TEMPERATURES
{
    public partial class ucTemperPrint : UserControl
    {
        printTemper ph = new printTemper();
        printTemper_Child phChild = new printTemper_Child();
        PrintDocument pdDocument = new PrintDocument();
        private FieldInfo m_Position;
        private MethodInfo m_SetPositionMethod;
        private bool isMouseDown;
        private Point startPosition;
        private Point endPosition;
        private Point curPos;


        private string in_date = string.Empty;
        private string id = string.Empty;
        private string dcgDate = string.Empty;
        private string dcgBatchno = string.Empty;
        private string hepatitsDate = string.Empty;
        private string hepatitsBatchno = string.Empty;
        private string startTime;
        private string endTime;
        private bool isChild = false;
        private string pid = string.Empty;
        PrintDialog pd = new PrintDialog();

        public ucTemperPrint()
        {
            try
            {
                InitializeComponent();
                ph.Hospital = "XXXXXXҽԺ";
                ph.TextName = "�� �� �� ¼ ��";
                ph.User.Add("������", "����");
                ph.User.Add("���ţ�", "1��");
                ph.User.Add("�Ա�", "��");
                ph.User.Add("���ң�", "�����ڿ�");
                ph.User.Add("������", "�����ڿƲ���");
                this.startTime = "2011-12-22";
                this.endTime = "2011-12-28";
                this.in_date = "2011-12-22 00:00";
                this.id = "98905";
                ph.Init("98905", "2010-11-05 11:11");
                pdDocument.DocumentName = "��˫����һ����";
                temperInit();
            }
            catch { }
        }


        /// <summary>
        /// ��ͨ���µ���ӡ���캯�� �·���
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="bedNo">����</param>
        /// <param name="sex">�Ա�</param>
        /// <param name="in_time">����ʱ��</param>
        /// <param name="pid">סԺ��</param>                 
        public ucTemperPrint(InPatientInfo info)//string pid, string medicare_no, string id, string bedNo, string name, string sex, string age, string section, string ward, string in_time, string out_time)
        {
            InitializeComponent();

            string age = info.Age;
            string sex = info.Gender_Code;

            this.id = info.Id.ToString();//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "'", 0, "id");
            this.in_date = info.In_Time.ToString("yyyy-MM-dd HH:mm");
            this.pid = info.PId;

            this.bedNo = info.Sick_Bed_Name;
            this.medicareNo = info.Medicare_no;
            string Age_Child = DataInit.GetAge(info.Id.ToString());
            if (string.IsNullOrEmpty(age) || age.Equals("0��") )
            {
                age = Age_Child;
            }
            if (pid.Contains("_"))
            {
                this.isChild = true;
            }
            else
            {
                if (Age_Child.Contains("��"))
                    Age_Child = Age_Child.Replace("��", "");

                if (Age_Child.Contains("Сʱ") || Age_Child.Contains("��") || (App.IsNumeric(Age_Child) && Convert.ToInt32(Age_Child) < 28))
                    this.isChild = true;
                else
                    this.isChild = false;
            }
            if (isChild)
            {
                if (sex == "0" || sex == "��")
                    sex = "��";
                else
                    sex = "Ů";
                phChild.Hospital = App.HospitalTittle;
                phChild.Bingqu = info.Sick_Area_Name;
                phChild.TextName = "�� �� �� ¼ ��";
                phChild.User.Add("����:", info.Patient_Name);
                phChild.User.Add("�Ա�:", sex);
                phChild.User.Add("����:", info.Sick_Area_Name);
                phChild.User.Add("����:", age);
                phChild.User.Add("����:", bedNo);
                phChild.User.Add("��Ժ����:", in_date);
                phChild.User.Add("�ǼǺ�:", medicareNo);
                phChild.User.Add("סԺ��:", pid);
                phChild.User.Add("ת������:", "");
                string diagnose = "������";
                phChild.User.Add("���:", "");
                phChild.User.Add("���:", id);// App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "' and to_char(in_time,'yyyy-MM-dd HH24:mi')='" + phChild.User["��Ժ����:"] + "' ", 0, "id"));
                phChild.User.Add("����:", TemperatureMethod.GetSection(phChild.User["���:"], phChild.PageIndex.ToString()));
                //if (out_time.Trim()!="")
                //  ph.User.Add("��Ժ����:", Convert.ToDateTime(out_time).ToString("yyyy-MM-dd HH:mm"));
                //else
                //  ph.User.Add("��Ժ����:","");

                //DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t where t.next_id=0 and t.action_type='����' and t.patient_id=" + id + "");
                //DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t inner join t_in_patient a on t.pid=a.id where t.next_id=0 and t.action_type='����' and t.patient_id=" + id + " and a.die_flag<>1");
                //if (ds.Tables[0].Rows.Count > 0)
                //    phChild.User.Add("��Ժ����:", Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm"));
                //else
                //    phChild.User.Add("��Ժ����:", "");

                phChild.Init(id, in_date);
                
            }
            else
            {
                if (sex == "0" || sex == "��")
                    sex = "��";
                else
                    sex = "Ů";
                ph.Hospital = App.HospitalTittle;
                ph.Bingqu = info.Sick_Area_Name;
                ph.TextName = "�� �� �� ¼ ��";
                ph.User.Add("����:", info.Patient_Name);
                ph.User.Add("�Ա�:", sex);
                ph.User.Add("����:", info.Sick_Area_Name);
                ph.User.Add("����:", age);
                ph.User.Add("����:", bedNo);
                ph.User.Add("��Ժ����:", in_date);
                ph.User.Add("�ǼǺ�:", medicareNo);
                ph.User.Add("סԺ��:", pid);
                ph.User.Add("ת������:", "");
                ph.User.Add("���:", id);//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "' and to_char(in_time,'yyyy-MM-dd HH24:mi')='" + ph.User["��Ժ����:"] + "'", 0, "id"));
                ph.User.Add("����:", TemperatureMethod.GetSection(ph.User["���:"], ph.PageIndex.ToString()));
                string diagnose = "";
                string sql_diagnose = "select a.diagnose_name from t_diagnose_item a where a.patient_id=" + id + " order by a.diagnose_sort asc ";
                sql_diagnose = "select distinct a.diagnose_name,a.diagnose_sort from t_diagnose_item a where a.patient_id = " + id + " and a.diagnose_type = '403' order by a.diagnose_sort";
                DataTable dtdiagnose = App.GetDataSet(sql_diagnose).Tables[0];
                if (dtdiagnose != null)
                {
                    for (int i = 0; i < dtdiagnose.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            diagnose = Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                        }
                        else if (i >= 3)
                        {
                            break;
                        }
                        else
                        {
                            diagnose += "," + Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
                        }
                    }
                }
                ph.User.Add("���:", diagnose);
                //if (out_time.Trim()!="")
                //  ph.User.Add("��Ժ����:", Convert.ToDateTime(out_time).ToString("yyyy-MM-dd HH:mm"));
                //else
                //  ph.User.Add("��Ժ����:","");

                //DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t where t.next_id=0 and t.action_type='����' and t.patient_id=" + id + "");
                DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t inner join t_in_patient a on t.pid=a.id where t.next_id=0 and t.action_type='����' and t.patient_id=" + id + " and a.die_flag<>1");
                if (ds.Tables[0].Rows.Count > 0)
                    ph.User.Add("��Ժ����:", Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm"));
                else
                    ph.User.Add("��Ժ����:", "");

                ph.Init(id, in_date);
            }
            
            temperInit();
        }

        private string bedNo = string.Empty;
        private string medicareNo = string.Empty;

        /// <summary>
        /// ��ͨ���µ���ӡ���캯�� ԭ����
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="medicare_no">�ǼǺ�</param>
        /// <param name="bedNo">����</param>
        /// <param name="sex">�Ա�</param>
        /// <param name="in_time">����ʱ��</param>
        /// <param name="pid">סԺ��</param>                 
        //public ucTemperPrint(string pid, string medicare_no, string id, string bedNo, string name, string sex, string age, string section, string ward, string in_time)
        //{
        //    InitializeComponent();
        //    this.bedNo = bedNo;
        //    this.medicareNo = medicare_no;
        //    string Age_Child = DataInit.GetAge(id);
        //    if (string.IsNullOrEmpty(age) || age.Equals("0��"))
        //    {
        //        age = Age_Child;
        //    }
        //    if (pid.Contains("_"))
        //    {
        //        this.isChild = true;
        //    }
        //    else
        //    {
        //        if (Age_Child.Contains("��"))
        //            Age_Child = Age_Child.Replace("��", "");

        //        if (Age_Child.Contains("Сʱ") || Age_Child.Contains("��") || (App.IsNumeric(Age_Child) && Convert.ToInt32(Age_Child) < 28))
        //            this.isChild = true;
        //        else
        //            this.isChild = false;
        //    }
        //    if (isChild)
        //    {
        //        if (sex == "0" || sex == "��")
        //            sex = "��";
        //        else
        //            sex = "Ů";
        //        phChild.Hospital = App.HospitalTittle;
        //        phChild.Bingqu = ward;
        //        phChild.TextName = "�� �� �� ¼ ��";
        //        phChild.User.Add("����:", bedNo);
        //        phChild.User.Add("����:", name);
        //        phChild.User.Add("�Ա�:", sex);
        //        phChild.User.Add("����:", age);
        //        phChild.User.Add("����:", section);
        //        phChild.User.Add("��Ժ����:", Convert.ToDateTime(in_time).ToString("yyyy-MM-dd HH:mm"));
        //        phChild.User.Add("�ǼǺ�:", medicare_no);
        //        phChild.User.Add("סԺ��:", pid);
        //        phChild.User.Add("ת������:", "");
        //        phChild.User.Add("���:", id);//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "' and to_char(in_time,'yyyy-MM-dd HH24:mi')='" + phChild.User["��Ժ����:"] + "'", 0, "id"));
        //        phChild.User.Add("����:", TemperatureMethod.GetSection(phChild.User["���:"], phChild.PageIndex.ToString()));
        //        string diagnose = "������";
        //        //phChild.User.Add("���:", diagnose);
        //        DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t where t.next_id=0 and t.action_type='����' and t.patient_id=" + id + "");
        //        if (ds.Tables[0].Rows.Count > 0)
        //            phChild.User.Add("��Ժ����:", Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm"));
        //        else
        //            phChild.User.Add("��Ժ����:", "");
        //        phChild.Init(id, in_time);
        //        this.id = id;//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "'", 0, "id");
        //        this.in_date = in_time;
        //        this.pid = pid;
        //    }
        //    else
        //    {
        //        if (sex == "0" || sex == "��")
        //            sex = "��";
        //        else
        //            sex = "Ů";
        //        ph.Hospital = App.HospitalTittle;
        //        ph.Bingqu = ward;
        //        ph.TextName = "�� �� �� ¼ ��";
        //        ph.User.Add("����:", name);
        //        ph.User.Add("�Ա�:", sex);
        //        ph.User.Add("����:", section);
        //        ph.User.Add("����:", age);
        //        ph.User.Add("����:", bedNo);
        //        ph.User.Add("��Ժ����:", Convert.ToDateTime(in_time).ToString("yyyy-MM-dd HH:mm"));
        //        ph.User.Add("�ǼǺ�:", medicare_no);
        //        ph.User.Add("סԺ��:", pid);
        //        ph.User.Add("ת������:", "");
        //        ph.User.Add("���:",id);// App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "' and to_char(in_time,'yyyy-MM-dd HH24:mi')='" + ph.User["��Ժ����:"] + "'", 0, "id"));
        //        ph.User.Add("����:", TemperatureMethod.GetSection(ph.User["���:"], ph.PageIndex.ToString()));
        //        string diagnose = "";
        //        string sql_diagnose = "select a.diagnose_name from t_diagnose_item a where a.patient_id=" + id + " order by a.diagnose_sort asc ";
        //        sql_diagnose = "select distinct a.diagnose_name,a.diagnose_sort from t_diagnose_item a where a.patient_id = " + id + " and a.diagnose_type = '403' order by a.diagnose_sort";
        //        DataTable dtdiagnose = App.GetDataSet(sql_diagnose).Tables[0];
        //        if (dtdiagnose != null)
        //        {
        //            for (int i = 0; i < dtdiagnose.Rows.Count; i++)
        //            {
        //                if (i == 0)
        //                {
        //                    diagnose = Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
        //                }
        //                else if (i >= 3)
        //                {
        //                    break;
        //                }
        //                else
        //                {
        //                    diagnose += "," + Convert.ToString(i + 1) + "." + dtdiagnose.Rows[i][0].ToString();
        //                }
        //            }
        //        }
        //        //ph.User.Add("���:", diagnose);
        //        DataSet ds = App.GetDataSet("select t.happen_time from t_inhospital_action t where t.next_id=0 and t.action_type='����' and t.patient_id=" + id + "");
        //        if (ds.Tables[0].Rows.Count > 0)
        //            ph.User.Add("��Ժ����:", Convert.ToDateTime(ds.Tables[0].Rows[0][0]).ToString("yyyy-MM-dd HH:mm"));
        //        else
        //            ph.User.Add("��Ժ����:", "");
        //        ph.Init(id, in_time);
        //        this.isChild = false;
        //        this.id = id;//App.ReadSqlVal("select id from t_in_patient where pid='" + pid + "'", 0, "id");
        //        this.in_date = in_time;
        //        this.pid = pid;
        //    }
        //    temperInit();


        //    //FormTest fc = new FormTest(pid,id,bedNo,name,sex,age,section,ward,in_time);
        //    //fc.Show();

        //}

        /// <summary>
        /// ��ʼ��
        /// </summary>
        private void temperInit()
        {
            this.ppcPreview.Document = pdDocument;
            this.pd.Document = pdDocument;
            this.pd.AllowSomePages = true;
            this.pd.ShowHelp = true;
            this.pd.UseEXDialog = true;
            this.pdDocument.DefaultPageSettings.Margins.Left = 38;//38
            this.pdDocument.DefaultPageSettings.Margins.Top = 78;  //78
            this.pdDocument.DefaultPageSettings.Landscape = false;
            //this.pdDocument.PrinterSettings.CanDuplex
            //this.pdDocument.DefaultPageSettings.Margins.Bottom = 15;
            this.pdDocument.OriginAtMargins = true;
            Type type = typeof(System.Windows.Forms.PrintPreviewControl);
            m_Position = type.GetField("position", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            m_SetPositionMethod = type.GetMethod("SetPositionNoInvalidate", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            ppcPreview.MouseWheel += new MouseEventHandler(ppcPreview_MouseWheel);
            ppcPreview.Click += new EventHandler(ppcPreview_Click);
            ppcPreview.MouseDown += new MouseEventHandler(ppcPreview_MouseDown);
            ppcPreview.MouseUp += new MouseEventHandler(ppcPreview_MouseUp);
            ppcPreview.MouseMove += new MouseEventHandler(ppcPreview_MouseMove);
            pdDocument.PrintPage += new PrintPageEventHandler(pdDocument_PrintPage);
            foreach (PaperSize _papersize in this.pdDocument.PrinterSettings.PaperSizes)
            {
                if (_papersize.PaperName == "A4")
                {
                    pdDocument.DefaultPageSettings.PaperSize = _papersize;
                    break;
                }
            }
            this.MouseWheel += new MouseEventHandler(ppcPreview_MouseWheel);

            loadTree();
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        int index = 0;              //��ӡ�ڼ�ҳ
        private bool isAll = false; //�Ƿ�ȫ����ӡ
        /// <summary>
        /// ��ӡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                if (id != "")
                {
                    e.Graphics.ScaleTransform(1f, 0.97f);
                    Graphics g = e.Graphics;
                    if (isAll)
                    {
                        StarToEndTime(this.tvTimes.Nodes[index].Text);
                        if (isChild)
                        {
                            phChild.PageIndex = index + 1;
                            phChild.User["����:"] = TemperatureMethod.GetSection(phChild.User["���:"], phChild.PageIndex.ToString());
                            //phChild.User["����:"] = TemperatureMethod.GetTransferBed(this.pid, phChild.PageIndex.ToString(), this.bedNo);
                            phChild.printMain(e.Graphics, startTime, endTime);
                        }
                        else
                        {
                            ph.PageIndex = index + 1;
                            //ph.User["����:"] = TemperatureMethod.GetTransferBed(this.pid, ph.PageIndex.ToString(), this.bedNo);
                            //ph.User["���:"] = TemperatureMethod.GetDiagnose(this.pid);
                            ph.User["����:"] = TemperatureMethod.GetSection(ph.User["���:"], ph.PageIndex.ToString());
                            ph.User["����:"] = App.UserAccount.CurrentSelectRole.Role_type == "N" ? ph.User["����:"] : TemperatureMethod.GetSection(this.id, ph.PageIndex.ToString());
                            ph.printMain(e.Graphics, startTime, endTime);
                        }
                        index++;
                        if (index == this.tvTimes.Nodes.Count - 1)
                        {
                            e.HasMorePages = false;
                            index = 0;
                        }
                        else
                        {
                            e.HasMorePages = true;
                        }
                    }
                    else
                    {

                        if (isChild)
                        {
                            phChild.printMain(e.Graphics, startTime, endTime);
                        }
                        else
                        {
                            ph.printMain(e.Graphics, startTime, endTime);
                        }
                    }
                }
            }
            catch
            {
                MessageBoxEx.Show("�����쳣��û�а�װ��ӡ��");
                // this.Close();
            }
        }

        private void tvTime_MouseDown(object sender, MouseEventArgs e)
        {
            this.tvTimes.SelectedNode = tvTimes.GetNodeAt(e.X, e.Y);
        }

        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Node select = this.tvTimes.SelectedNode;
                if (select != null)
                {
                    if (select.Text == "��ʾȫ��")
                    {
                        if (MessageBox.Show("ȷ��Ҫ��ӡȫ�����µ���?", "��ܰ��ʾ!"
                            , MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    this.pdDocument.Print();
                }
            }
            catch (Exception)
            {
                App.Msg("��ӡ���쳣��");
            }
        }


        /// <summary>
        /// ����ʱ����Ŀ
        /// </summary>
        public void loadTree()
        {
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd"));

            DataTable dt = null;
            if (this.isChild)
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM T_VITAL_SIGNS T WHERE (T.DESCRIBE like '%��Ժ%' OR T.DESCRIBE like '%����%') AND patient_id = '{0}' ORDER BY MEASURE_TIME", this.id)).Tables[0];
            }
            else
            {
                dt = App.GetDataSet(string.Format("SELECT to_char(MEASURE_TIME,'yyyy-MM-dd') as MEASURE_TIME FROM T_VITAL_SIGNS T WHERE (T.DESCRIBE like '%��Ժ%' OR T.DESCRIBE like '%����%') AND patient_id = '{0}' ORDER BY MEASURE_TIME", this.id)).Tables[0];
            }
            if (dt.Rows.Count > 0)
            {
                today = Convert.ToDateTime(dt.Rows[0]["MEASURE_TIME"].ToString());
                if (isChild)
                {
                    phChild.out_time = today;
                }
                else
                {
                    ph.out_time = today;
                }
            }
            if (pid.Contains("_"))
            {
                inDatetime = Convert.ToDateTime(App.ReadSqlVal(" select to_char(birthday,'yyyy-MM-dd') birthday from t_in_patient where id=" + this.id, 0, "birthday"));
            }
            TimeSpan ts1 = new TimeSpan(inDatetime.Ticks);
            TimeSpan ts2 = new TimeSpan(today.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            int weekCount = 0;
            if ((ts.Days + 1) % 7 == 0)
                weekCount = (ts.Days + 1) / 7;
            else
                weekCount = (ts.Days + 1) / 7 + 1;

            string temper = "";
            for (int i = 0; i < weekCount; i++)
            {
                temper = "��" + (i + 1).ToString() + "��(" + inDatetime.AddDays(i * 7).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * 7 + 6).ToString("yyyy-MM-dd") + ")";
                Node tn = new Node();
                tn.Text = temper;
                this.tvTimes.Nodes.Add(tn);
                temper = "";
            }
            string tempString = tvTimes.Nodes[tvTimes.Nodes.Count - 1].Text.ToString();
            StarToEndTime(tempString);
            if (isChild)
            {
                phChild.PageIndex = tvTimes.Nodes.Count;
                phChild.User["����:"] = TemperatureMethod.GetSection(phChild.User["���:"], phChild.PageIndex.ToString());
                //phChild.User["����:"] = TemperatureMethod.GetTransferBed(this.pid, phChild.PageIndex.ToString(), this.bedNo);
                //ph.User["���:"] = TemperatureMethod.GetDiagnose(this.pid, ph.PageIndex.ToString());
            }
            else
            {
                ph.PageIndex = tvTimes.Nodes.Count;
                ph.User["����:"] = TemperatureMethod.GetSection(ph.User["���:"], ph.PageIndex.ToString());
                //ph.User["����:"] = TemperatureMethod.GetTransferBed(this.pid, ph.PageIndex.ToString(), this.bedNo);
                //ph.User["���:"] = TemperatureMethod.GetDiagnose(this.pid);
                ph.User["����:"] = App.UserAccount.CurrentSelectRole.Role_type == "N" ? ph.User["����:"] :
                                    TemperatureMethod.GetSection(this.id, ph.PageIndex.ToString());
            }
            Node de = new Node();
            de.Text = "��ʾȫ��";
            this.tvTimes.Nodes.Add(de);
        }


        /// <summary>
        /// ���ÿ�ʼʱ�� ����ʱ��
        /// </summary>
        /// <param name="tempString"></param>
        private void StarToEndTime(string tempString)
        {
            string temp = tempString.Split('(')[1].ToString();
            string howWeek = tempString.Split('(')[0].ToString();
            string weeks = howWeek.Substring(1, howWeek.Length - 2);
            string[] startEndDate = temp.Substring(0, temp.Length - 1).Split('~');
            this.startTime = startEndDate[0];
            this.endTime = startEndDate[1];
        }

        /// <summary>
        /// ���ڵ� ѡ���ӡ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimes_AfterNodeSelect(object sender, AdvTreeNodeEventArgs e)
        {
            Node selectNode = this.tvTimes.SelectedNode;
            if (selectNode != null && this.tvTimes.Nodes.Count > 1)
            {
                if (selectNode.Text == "��ʾȫ��")
                {
                    this.isAll = true;
                    this.ppcPreview.Rows = this.tvTimes.Nodes.Count - 1;
                    this.pdDocument.DocumentName = (this.tvTimes.Nodes.Count - 1).ToString();
                }
                else
                {
                    this.isAll = false;
                    string tempString = selectNode.Text;
                    string temp = tempString.Split('(')[1].ToString();
                    string howWeek = tempString.Split('(')[0].ToString();
                    string weeks = howWeek.Substring(1, howWeek.Length - 2);
                    string[] startEndDate = temp.Substring(0, temp.Length - 1).Split('~');
                    this.startTime = startEndDate[0];
                    this.endTime = startEndDate[1];
                    if (isChild)
                    {
                        phChild.PageIndex = selectNode.Index + 1;
                        phChild.User["����:"] = TemperatureMethod.GetSection(phChild.User["���:"], phChild.PageIndex.ToString());
                        //phChild.User["����:"] = TemperatureMethod.GetTransferBed(this.pid, phChild.PageIndex.ToString(), this.bedNo);
                        //ph.User["���:"] = TemperatureMethod.GetDiagnose(this.pid);
                    }
                    else
                    {
                        ph.PageIndex = selectNode.Index + 1;
                        //ph.User["����:"] = TemperatureMethod.GetTransferBed(this.pid, ph.PageIndex.ToString(), this.bedNo);
                        //ph.User["���:"] = TemperatureMethod.GetDiagnose(this.pid);
                        ph.User["����:"] = TemperatureMethod.GetSection(ph.User["���:"], ph.PageIndex.ToString());
                        ph.User["����:"] = App.UserAccount.CurrentSelectRole.Role_type == "N" ? ph.User["����:"] :
                                           TemperatureMethod.GetSection(this.id, ph.PageIndex.ToString());
                    }
                    this.ppcPreview.Rows = 1;
                    this.pdDocument.DocumentName = "1";
                }
                this.ppcPreview.InvalidatePreview();
            }
        }

        /// <summary>       
        /// ������       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        void ppcPreview_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!SystemInformation.MouseWheelPresent)
            {
                //If have no wheel       
                return;
            }
            int scrollAmount;
            float amount = Math.Abs(e.Delta) / SystemInformation.MouseWheelScrollDelta;
            amount *= SystemInformation.MouseWheelScrollLines;
            amount *= 12;//Row height       
            amount *= (float)ppcPreview.Zoom;//Zoom Rate       
            if (e.Delta < 0)
            {
                scrollAmount = (int)amount;
            }
            else
            {
                scrollAmount = -(int)amount;
            }
            Point curPos = (Point)(m_Position.GetValue(ppcPreview));
            m_SetPositionMethod.Invoke(ppcPreview, new object[] { new Point(curPos.X + 0, curPos.Y + scrollAmount) });
        }

        /// <summary>       
        /// ����ڿؼ��ϵ��ʱ����Ҫ�����ý��㣬��ΪĬ�ϲ����ý���       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_Click(object sender, EventArgs e)
        {
            ppcPreview.Select();
            ppcPreview.Focus();
        }

        /// <summary>       
        /// ��갴�£���ʼ�϶�       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            startPosition = new Point(e.X, e.Y);
            curPos = (Point)(m_Position.GetValue(ppcPreview));
        }

        /// <summary>       
        /// ����ͷţ�����϶�       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            endPosition = new Point(e.X, e.Y);
            m_SetPositionMethod.Invoke(ppcPreview, new object[] { new Point(curPos.X + (startPosition.X - endPosition.X), curPos.Y + (startPosition.Y - endPosition.Y)) });
        }

        /// <summary>       
        /// ����ƶ����϶���       
        /// </summary>       
        /// <param name="sender"></param>       
        /// <param name="e"></param>       
        private void ppcPreview_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                endPosition = new Point(e.X, e.Y);
                m_SetPositionMethod.Invoke(ppcPreview, new object[] { new Point(curPos.X + (startPosition.X - endPosition.X), curPos.Y + (startPosition.Y - endPosition.Y)) });
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slider1_ValueChanged(object sender, EventArgs e)
        {
            this.ppcPreview.Zoom = float.Parse(this.slider1.Value.ToString("#0.0")) / 10;
        }

        /// <summary>
        /// ���������ִ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTemperPrint_Load(object sender, EventArgs e)
        {
            this.tvTimes.SelectedNode = this.tvTimes.Nodes[tvTimes.Nodes.Count - 2];
            this.tvTimes.Focus();
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Stream StreamRead;
            OpenFileDialog DialogueCharger = new OpenFileDialog();
            DialogueCharger.DefaultExt = "shape";
            DialogueCharger.Title = "Load shape";
            DialogueCharger.Filter = "frame files (*.shape)|*.shape|All files (*.*)|*.*";
            if (DialogueCharger.ShowDialog() == DialogResult.OK)
            {
                if ((StreamRead = DialogueCharger.OpenFile()) != null)
                {
                    BinaryFormatter BinaryRead = new BinaryFormatter();
                    Base_Function.BASE_COMMON.Class1 cls = new Base_Function.BASE_COMMON.Class1();
                    cls = (Base_Function.BASE_COMMON.Class1)BinaryRead.Deserialize(StreamRead);
                    StreamRead.Close();
                    if (isChild)
                    {
                        this.phChild.dbList = cls.List;
                    }
                    else
                    {
                        this.ph.dbList = cls.List;
                    }
                    this.ppcPreview.InvalidatePreview();
                }
            }
        }

        public void getList(List<DataTable> tabs)
        {
            //Stream streamWrite;
            //SaveFileDialog sf = new SaveFileDialog();
            //sf.DefaultExt = "shape";
            //sf.Title = "����";
            //sf.Filter = "shape files (*.shape)|*.shape|All files (*.*)|*.*";
            //if (sf.ShowDialog() == DialogResult.OK)
            //{
            //    if ((streamWrite = sf.OpenFile()) != null)
            //    {
            //        BinaryFormatter BinaryWrite = new BinaryFormatter();
            //        TemperPrints.Class1 cla = new TemperPrints.Class1();
            //        cla.List = tabs;
            //        BinaryWrite.Serialize(streamWrite, cla);
            //        streamWrite.Close();
            //    }
            //}
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            this.ppcPreview.InvalidatePreview();
        }
    }
}
