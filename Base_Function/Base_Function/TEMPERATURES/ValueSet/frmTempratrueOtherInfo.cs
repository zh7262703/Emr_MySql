using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;

namespace Base_Function.TEMPERATURES.ValueSet
{
    public partial class frmTempratrueOtherInfo : DevComponents.DotNetBar.Office2007Form
    {
        string startDate = "";
        string endDate = "";

        private string pid;//���˱��                  
        private string bed_no;//���� 
        private string pid_ids;//��������
        private string s_count = "";//����������
        private string Erm = "";//log��¼��Ϣ
        private DateTime SelectTime;//��ǰ����

        /// <summary>
        /// txtEmptyItemName1�Ƿ���޸�
        /// </summary>
        private bool emptyedited1 = false;

        /// <summary>
        /// txtEmptyItemName2�Ƿ���޸�
        /// </summary>
        private bool emptyedited2 = false;

        public frmTempratrueOtherInfo()
        {
            InitializeComponent();
        }

        private void LoadWeight()
        {
            this.txtWeight.Text = "";
            this.txtWeight.Enabled = false;
            this.cbWeight.SelectedIndex = 0;
            this.cbWeight.Enabled = false;
        }
     
        /// <summary>
        /// ��ѯ������Ϣ
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static List<DataTable> GetTemper(string time, string pid)
        {
            List<DataTable> list = new List<DataTable>();
            DataSet ds = new DataSet();          
            string sql2 = string.Format("select stool_count," +
                                        "stool_state, clysis_count, stool_count_e," +
                                        "stool_amount, stool_amount_unit, stale_amount," +
                                        "is_catheter, weighttype, weight, weight_unit," +
                                        "weight_special, length, sensi_test_code, sensi_test_result," +
                                        "sensi_test_result_temp, record_id, record_time, in_amount," +
                                        "out_amount, out_amount1, out_amount2, out_amount3," +
                                        "remark, bp_high, bp_low, bp_unit,out_other, bp_blood,Stool_count_f," +
                                        "SPO2,SPUTUM_QUANTITY,VOLUME_OF_DRAINAGE,VOMIT,Special,URINE,URINE_STATE,SHIT_STATE,empty_name1,empty_value1,empty_name2,empty_value2 from t_temperature_info WHERE " +
                                        "to_char(record_time,'yyyy-MM-dd') like '{0}' AND PATIENT_ID = '{1}' ", time, pid);          
            DataTable dt2 = App.GetDataSet(sql2).Tables[0];
            if (dt2.Rows.Count > 0)
                list.Add(dt2);
            else
                return null;
            return list;
        }

        /// <summary>
        /// ���ݴ������ƺʹ�������ѡ��
        /// </summary>
        /// <param name="name">��������</param>
        /// <param name="xxx">���Ĵ���</param>
        private void setIsTrurFalse(string name, int xxx)
        {
            switch (name)
            {
                //����
                case "rbNormal":
                    txtNormalDefecate.Enabled = true;
                    //txtEnemaCount.Text = "";
                    //txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    break;
                //ʧ��
                case "rbIncontinence":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    //txtEnemaCount.Text = "";
                    //txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    break;
                //�೦
                case "rbEnema":
                    txtNormalDefecate.Enabled = false;
                    //txtEnemaCount.Enabled = true;
                    txtEnemaDefecate.Enabled = true;
                    txtEnemaBeforeDefecate.Enabled = true;
                    break;
                //ʧ��,�೦
                case "rbEnema1":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    //txtEnemaCount.Text = "";
                    //txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    break;
                case "rbEnema2":
                    break;
                //�˹�����
                case "anus":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    //txtEnemaCount.Text = "";
                    //txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    break;

            }
        }

        /// <summary>
        /// ���ؽ��ձ�����Ϣ
        /// </summary>
        /// <param name="lists"></param>
        public void LoadAll(List<DataTable> lists)
        {           
            DataTable dt2 = lists[0];           
            #region ������Ϣ

            if (dt2.Rows.Count > 0)
            {
                //������

                switch (dt2.Rows[0]["stool_state"].ToString())
                {
                    case "N":
                        this.rbNormal.Checked = true;
                        setIsTrurFalse("rbNormal");
                        if (dt2.Rows[0]["stool_count"].ToString() != "")
                        {// || dt2.Rows[0]["stool_count"].ToString() == "0") {//
                            this.txtNormalDefecate.Text = dt2.Rows[0]["stool_count"].ToString();
                        }
                        else
                        {
                            this.txtNormalDefecate.Text = "";
                        }
                        s_count = dt2.Rows[0]["stool_count"].ToString();
                        break;
                    case "C":
                        this.rbEnema2.Checked = true;
                        setIsTrurFalse("rbEnema2");
                        ////if (dt2.Rows[0]["Stool_count_f"].ToString() != "")
                        ////{// || dt2.Rows[0]["Stool_count_f"].ToString() != "0") {
                        ////    this.txtEnemaBeforeDefecate.Text = dt2.Rows[0]["Stool_count_f"].ToString();
                        ////}
                        //else 
                        //if (dt2.Rows[0]["clysis_count"].ToString() != "")
                        //{// || dt2.Rows[0]["clysis_count"].ToString() != "0") {
                        //    this.txtEnemaCount.Text = dt2.Rows[0]["clysis_count"].ToString();
                        //    //txtEnemaBeforeDefecate.Text = dt2.Rows[0]["clysis_count"].ToString();
                        //}
                        //else
                        //{
                        //    //this.txtEnemaCount.Text = "";
                        //    txtEnemaBeforeDefecate.Text = "";
                        //}

                        if (dt2.Rows[0]["stool_count_e"].ToString() != "")
                        {// || dt2.Rows[0]["stool_count_e"].ToString() != "0") {
                            //this.txtEnemaDefecate.Text = dt2.Rows[0]["stool_count_e"].ToString();
                            //this.txtAfterEnemaShitCount.Text = dt2.Rows[0]["stool_count_e"].ToString();
                            this.cmbAfterEnema.Text = dt2.Rows[0]["stool_count_e"].ToString();
                        }
                        if (dt2.Rows[0]["clysis_count"].ToString() != "")
                        {
                            this.cmbEnema.Text = dt2.Rows[0]["clysis_count"].ToString();
                        }
                        if (dt2.Rows[0]["stool_count_f"].ToString() != "")
                        {// || dt2.Rows[0]["stool_count_e"].ToString() != "0") {
                            //this.txtEnemaDefecate.Text = dt2.Rows[0]["stool_count_e"].ToString();
                            //this.txtAfterEnemaShitCount.Text = dt2.Rows[0]["stool_count_e"].ToString();
                            this.cmbBeforeEnema.Text = dt2.Rows[0]["stool_count_f"].ToString();
                        }
                        //else
                        //{
                        //    this.txtEnemaDefecate.Text = "";
                        //    string shit_state = dt2.Rows[0]["shit_state"] == null ? "" : dt2.Rows[0]["shit_state"].ToString();
                        //    if (shit_state != "" && shit_state != "N")
                        //    {
                        //        //chkIncontinence.Checked = true;
                        //        //txtEnemaTimes.Enabled = false;
                        //    }
                        //}
                        break;
                    case "G":
                        this.rbRengonggangchang.Checked = true;
                        setIsTrurFalse("rbRengonggangchang");
                        break;
                    case "I":
                        this.rbIncontinence.Checked = true;
                        setIsTrurFalse("rbIncontinence");
                        break;
                    case "E":
                        //this.rbEnema1.Checked = true;
                        setIsTrurFalse("rbEnema1");
                        break;
                }

                //������
                if (dt2.Rows[0]["in_amount"].ToString() != "")
                {
                    this.txtIn.Text = dt2.Rows[0]["in_amount"].ToString();
                }
                else
                {
                    txtIn.Text = "";
                }

                //������
                if (dt2.Rows[0]["out_amount"].ToString() != "")
                {
                    this.txtOut.Text = dt2.Rows[0]["out_amount"].ToString();
                }
                else
                {
                    this.txtOut.Text = "";
                }                                         

               



                if (dt2.Rows[0]["bp_high"].ToString() != "")
                {
                    this.txtBloodOne1.Text = dt2.Rows[0]["bp_high"].ToString();
                }

                //ҩ�����
                this.txtDragInfact.Text = dt2.Rows[0]["Special"].ToString();

                //С��
                switch (dt2.Rows[0]["URINE_STATE"].ToString())
                {
                    case "N":
                        this.rbNormal_Urine.Checked = true;
                        if (dt2.Rows[0]["URINE"].ToString() != "")
                        {
                            this.txtUrine.Text = dt2.Rows[0]["URINE"].ToString();
                        }
                        else
                        {
                            this.txtUrine.Text = "";
                        }                       
                        break;
                    case "I":
                        rbIncontinence_Urine.Checked = true;
                        txtUrine.Text = "";
                        txtUrine.Enabled = false;
                        break;
                }

                //����
                switch (dt2.Rows[0]["weighttype"].ToString())
                {
                    case "P":
                        this.rdFlatcar.Checked = true;
                        LoadWeight();
                        break;
                    case "W":
                        this.rdBed.Checked = true;
                        LoadWeight();
                        break;
                    case "L":
                        this.rbWheelchairs.Checked = true;
                        LoadWeight();
                        break;
                    default:
                        if (dt2.Rows[0]["weight"].ToString() != "")
                        {//&& dt2.Rows[0]["weight"].ToString() != "0") {
                            if (float.Parse(dt2.Rows[0]["weight"].ToString()) >= 0)
                            {
                                this.rbWeightOk.Checked = true;
                                this.txtWeight.Text = dt2.Rows[0]["weight"].ToString();
                                //this.cbWeight.SelectedIndex = Convert.ToInt32(dt2.Rows[0]["weight_unit"].ToString());
                            }                          
                        }
                        else
                        {
                            this.txtWeight.Text = "";
                        }
                        //���
                        if (dt2.Rows[0]["length"].ToString() != "")
                        {
                            this.txtHeight.Text = dt2.Rows[0]["length"].ToString();
                        }
                        else
                        {
                            this.txtHeight.Text = "";
                        }
                        break;
                }



                //Ѫѹ
                string bp_blood = dt2.Rows[0]["bp_blood"].ToString();
                if (bp_blood != "")
                {
                    if (!bp_blood.ToString().Contains(","))
                    {
                        if (!bp_blood.ToString().Contains("/"))
                        {
                            string oneOrTwo = bp_blood.Substring(0, 1);
                            string one = bp_blood.Substring(1, bp_blood.Length - 1);
                            if (oneOrTwo == "O")
                            {
                                if (one.Length > 1)
                                {
                                    this.rbBloodOne.Checked = true;
                                    this.txtBloodOne1.Text = one;
                                    this.txtBloodOne2.Text = "";
                                }
                                else
                                {
                                    this.rbBloodOneNo.Checked = true;
                                }
                            }
                            else
                            {
                                if (one.Length > 1)
                                {
                                    this.rbBloodTwo.Checked = true;
                                    this.txtBloodTwo1.Text = one;
                                    this.txtBloodTwo2.Text = "";
                                }
                                else
                                {
                                    this.rbBloodTwoNo.Checked = true;
                                }
                            }
                        }
                        else
                        {
                            string oneOrTwo = bp_blood.Substring(0, 1);
                            string[] one = bp_blood.Substring(1, bp_blood.Length - 1).Split('/');
                            if (oneOrTwo == "O")
                            {
                                if (one.Length > 1)
                                {
                                    this.rbBloodOne.Checked = true;
                                    this.txtBloodOne1.Text = one[0];
                                    this.txtBloodOne2.Text = one[1];
                                }
                                else
                                {
                                    this.rbBloodOneNo.Checked = true;
                                }
                            }
                            else
                            {
                                if (one.Length > 1)
                                {
                                    this.rbBloodTwo.Checked = true;
                                    this.txtBloodTwo1.Text = one[0];
                                    this.txtBloodTwo2.Text = one[1];
                                }
                                else
                                {
                                    this.rbBloodTwoNo.Checked = true;
                                }
                            }
                        }

                    }
                    else
                    {
                        string[] bloodArr = bp_blood.Split(',');
                        if (bloodArr.Length > 1)
                        {
                            string[] bloodOne = bloodArr[0].Substring(1, bloodArr[0].Length - 1).Split('/');

                            if (bloodOne.Length > 1)
                            {
                                this.rbBloodOne.Checked = true;
                                this.txtBloodOne1.Text = bloodOne[0];
                                this.txtBloodOne2.Text = bloodOne[1];
                            }
                            else
                            {
                                this.rbBloodOneNo.Checked = true;
                            }
                            string[] bloodTwo = bloodArr[1].Substring(1, bloodArr[1].Length - 1).Split('/');
                            if (bloodTwo.Length > 1)
                            {
                                this.rbBloodTwo.Checked = true;
                                this.txtBloodTwo1.Text = bloodTwo[0];
                                this.txtBloodTwo2.Text = bloodTwo[1];
                            }
                            else
                            {
                                this.rbBloodTwoNo.Checked = true;
                            }

                        }
                        else
                        {
                            string oneOrTwo = bp_blood.Substring(0, 1);
                            string[] one = bp_blood.Substring(1, bp_blood.Length - 1).Split('/');
                            if (oneOrTwo == "O")
                            {
                                if (one.Length > 1)
                                {
                                    this.rbBloodOne.Checked = true;
                                    this.txtBloodOne1.Text = one[0];
                                    this.txtBloodOne2.Text = one[1];
                                }
                                else
                                {
                                    this.rbBloodOneNo.Checked = true;
                                }
                            }
                            else
                            {
                                if (one.Length > 1)
                                {
                                    this.rbBloodTwo.Checked = true;
                                    this.txtBloodTwo1.Text = one[0];
                                    this.txtBloodTwo2.Text = one[1];
                                }
                                else
                                {
                                    this.rbBloodTwoNo.Checked = true;
                                }
                            }
                        }
                    }
                }

                //�հ�������1
                string stremptyname1 = dt2.Rows[0]["empty_name1"].ToString();
                txtEmptyItemName1.Text = stremptyname1;
                //�հ���ֵ1
                string stremptyvalue1 = dt2.Rows[0]["empty_value1"].ToString();
                txtEmptyItemValue1.Text = stremptyvalue1;
                //�հ�������2
                string stremptyname2 = dt2.Rows[0]["empty_name2"].ToString();
                txtEmptyItemName2.Text = stremptyname2;
                //�հ���ֵ2
                string stremptyvalue2 = dt2.Rows[0]["empty_value2"].ToString();
                txtEmptyItemValue2.Text = stremptyvalue2;

                if (this.rbBloodOneNo.Checked)
                {
                    this.txtBloodOne1.Enabled = false;
                    this.txtBloodOne2.Enabled = false;
                }
                else
                {
                    this.rbBloodOne.Checked = true;
                    this.txtBloodOne1.Enabled = true;
                    this.txtBloodOne2.Enabled = true;
                }

                if (this.rbBloodTwoNo.Checked)
                {
                    this.txtBloodTwo1.Enabled = false;
                    this.txtBloodTwo2.Enabled = false;
                }
                else
                {
                    this.rbBloodTwo.Checked = true;
                    this.txtBloodTwo1.Enabled = true;
                    this.txtBloodTwo2.Enabled = true;
                }
            }
            #endregion
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="starttime">��ʼʱ��</param>
        /// <param name="endtime">����ʱ��</param>
        public frmTempratrueOtherInfo(string starttime, string endtime, string Pid, string patient_i, string bedno,DateTime SelectDate)
        {
            InitializeComponent();
            startDate = starttime;
            endDate = endtime;
            this.lblNotice.Text = "ע�������ǰʱ��㷶ΧΪ" + starttime + "   ��   " + endtime;

            if (SelectDate==null)
               dateTimePicker_Select.Value = Convert.ToDateTime(starttime);
            else
               dateTimePicker_Select.Value = SelectDate;

            pid = Pid;
            bed_no = bedno;
            pid_ids = patient_i;
            if (App.ReadSqlVal("select count(*) from t_temperature_info a where  a.patient_id=" + patient_i + " and a.empty_value1 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endtime).ToString("yyyy-MM-dd") + "'", 0, "count(*)") == "1")
            {
                emptyedited1 = false;
            }
            else
            {
                emptyedited1 = true;
            }
            if (App.ReadSqlVal("select count(*) from t_temperature_info a where  a.patient_id=" + patient_i + " and a.empty_value2 is not null and to_char(a.record_time,'yyyy-mm-dd')>='" + Convert.ToDateTime(startDate).ToString("yyyy-MM-dd") + "' and to_char(a.record_time,'yyyy-mm-dd')<='" + Convert.ToDateTime(endtime).ToString("yyyy-MM-dd") + "'", 0, "count(*)") == "1")
            {
                emptyedited2 = false;
            }
            else
            {
                emptyedited2 = true;
            }
            txtEmptyItemName1.Enabled = emptyedited1;
            txtEmptyItemName2.Enabled = emptyedited2;

        }

        private void frmTempratrueOtherInfo_Load(object sender, EventArgs e)
        {
            //dateTimePicker_Select.Value = Convert.ToDateTime(this.startDate);
            dateTimePicker_Select_ValueChanged(sender, e);
        }

        /// <summary>
        /// ���ݴ������ƽ���ѡ��
        /// </summary>
        /// <param name="name">�������</param>
        private void setIsTrurFalse(string name)
        {
            switch (name)
            {
                //����
                case "rbNormal":
                    txtNormalDefecate.Enabled = true;
                    txtEnemaCount.Text = "";
                    if (txtEnemaCount.Text == "")
                    {
                        txtEnemaCount.Text = "0";
                    }
                    txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtAfterEnemaShitCount.Enabled = false;
                    txtAfterEnemaShitCount.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    chkIncontinence.Enabled = false;
                    chkIncontinence.Checked = false;
                    cmbAfterEnema.Enabled = false;
                    cmbAfterEnema.Text = "";
                    cmbBeforeEnema.Enabled = false;
                    cmbBeforeEnema.Text = "";
                    cmbEnema.Enabled = false;
                    cmbEnema.Text = "";
                    break;
                //ʧ��
                case "rbIncontinence":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Text = "";
                    txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtAfterEnemaShitCount.Enabled = false;
                    txtAfterEnemaShitCount.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    chkIncontinence.Enabled = false;
                    chkIncontinence.Checked = false;
                    cmbAfterEnema.Enabled = false;
                    cmbAfterEnema.Text = "";
                    cmbBeforeEnema.Enabled = false;
                    cmbBeforeEnema.Text = "";
                    cmbEnema.Enabled = false;
                    cmbEnema.Text = "";
                    break;
                //�೦
                case "rbEnema":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Text = "";
                    txtEnemaCount.Enabled = true;
                    txtAfterEnemaShitCount.Enabled = true;
                    txtAfterEnemaShitCount.Text = "";
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    //chkIncontinence.Enabled = false;
                    chkIncontinence.Checked = false;
                    break;
                //�೦2
                case "rbEnema2":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Text = "";
                    txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = true;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = true;
                    chkIncontinence.Enabled = true;
                    chkIncontinence.Checked = false;
                    cmbAfterEnema.Enabled = true;
                    cmbAfterEnema.Text = "0";
                    cmbBeforeEnema.Enabled = true;
                    cmbBeforeEnema.Text = "0";
                    cmbEnema.Enabled = true;
                    cmbEnema.Text = "1";
                    break;
                //��/E
                case "rbEnema1":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Text = "";
                    txtEnemaCount.Enabled = false;
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    chkIncontinence.Enabled = false;
                    chkIncontinence.Checked = false;
                    break;
                //�˹��س�
                case "rbRengonggangchang":
                    txtNormalDefecate.Text = "";
                    txtNormalDefecate.Enabled = false;
                    txtEnemaCount.Text = "";
                    txtEnemaCount.Enabled = false;
                    txtAfterEnemaShitCount.Enabled = false;
                    txtAfterEnemaShitCount.Text = "";
                    txtEnemaDefecate.Text = "";
                    txtEnemaDefecate.Enabled = false;
                    txtEnemaBeforeDefecate.Text = "";
                    txtEnemaBeforeDefecate.Enabled = false;
                    chkIncontinence.Enabled = false;
                    chkIncontinence.Checked = false;
                    cmbAfterEnema.Enabled = false;
                    cmbAfterEnema.Text = "";
                    cmbBeforeEnema.Enabled = false;
                    cmbBeforeEnema.Text = "";
                    cmbEnema.Enabled = false;
                    cmbEnema.Text = "";
                    break;
            }
        }

        /// <summary>
        /// ��������������Ϣ
        /// </summary>
        /// <returns></returns>
        public Class_T_Temperature_Info ExcuteTemperOther()
        {
            Class_T_Temperature_Info tti = new Class_T_Temperature_Info();
            //����
            tti.Bed_no = this.bed_no;
            //���˱��
            tti.Pid = this.pid;
            tti.Patient_id = this.pid_ids;
            //������
            if (rbNormal.Checked) //����
            {
                if (this.txtNormalDefecate.Text != "")
                {
                    tti.Stool_count = this.txtNormalDefecate.Text.ToString();
                }
                tti.Stool_state = "N";
            }
            else if (rbRengonggangchang.Checked)  //�˹�����
            {
                tti.Stool_state = "G";
            }
            else if (rbEnema.Checked) //�೦
            {
                if (this.txtEnemaCount.Text != "")
                {
                    tti.Clysis_count = this.txtEnemaCount.Text.ToString();
                }
                if (this.txtAfterEnemaShitCount.Text != "")
                {
                    tti.Stool_count_e = txtAfterEnemaShitCount.Text;
                }
                tti.Stool_state = "C";
            }
            else if (rbEnema1.Checked)  //ʧ����೦
            {
                tti.Stool_state = "E";
            }
            else if (rbEnema2.Checked) //�೦
            {
                //if (this.txtEnemaBeforeDefecate.Text != "")
                //{
                //    tti.Stool_count_f = this.txtEnemaBeforeDefecate.Text.Trim();
                //}
                //if (this.txtEnemaDefecate.Text != "")
                //{
                //    tti.Clysis_count = this.txtEnemaDefecate.Text.ToString();
                //}
                //if (chkIncontinence.Checked == true)
                //{//IΪʧ��,��Ϊ��ʧ��
                //    tti.Shit_state = "I";
                //}
                if (this.cmbAfterEnema.Text != "")
                {
                    tti.Stool_count_e = cmbAfterEnema.Text.Trim();
                }
                if (this.cmbEnema.Text != "")
                {
                    tti.Clysis_count = cmbEnema.Text.Trim();
                }
                if (this.cmbBeforeEnema.Text != "")
                {
                    tti.Stool_count_f = cmbBeforeEnema.Text.Trim();
                }
                tti.Stool_state = "C";
            }
            else
            {
                tti.Stool_state = "I";  //ʧ��
            }
            if (s_count != this.txtNormalDefecate.Text)
            {
                Erm = "�޸�ǰtextֵ:[" + s_count + "]-�޸ĺ�textֵ:[" + this.txtNormalDefecate.Text + "]-�������:[" + tti.Stool_state + "]";
            }
            else
            {
                Erm = "";
            }
            //С��
            if (rbNormal_Urine.Checked)
            {
                //����
                tti.Urine = txtUrine.Text;
                tti.Urine_state = "N";
            }
            else
            {
                //ʧ��
                tti.Urine_state = "I";
            }
                    

            //����
            if (this.rdFlatcar.Checked)
            {
                tti.Weighttype = "P";//ƽ��
            }
            else if (this.rdBed.Checked)
            {
                tti.Weighttype = "W";//�Դ�
            }
            else if (this.rbWheelchairs.Checked)
            {
                tti.Weighttype = "L";//����    
            }
            else
            {
                if (this.txtWeight.Text != "")
                {
                    //if (this.cbWeight.SelectedIndex == 0)
                    //{
                    tti.Weight = this.txtWeight.Text;
                    //    tti.Weight_unit = this.cbWeight.SelectedIndex.ToString();
                    //}
                }

                //���
                if (this.txtHeight.Text != "")
                {
                    tti.Length = this.txtHeight.Text;
                }

            }

           
            //ʱ��
            tti.Record_time = dateTimePicker_Select.Value.ToString("yyyy-MM-dd HH:mm");

            //����-����
            if (this.txtIn.Text != "")
            {
                tti.In_amount = this.txtIn.Text;
            }

            //����-����
            if (this.txtOut.Text != "")
            {
                tti.Out_amount = this.txtOut.Text;
            }           
            //��������
            if (this.txtDragInfact.Text != "")
            {
                tti.Special = this.txtDragInfact.Text;
            }
          
            string blood = "";
            //Ѫѹ 1
            if (rbBloodOne.Checked)
            {
                if (txtBloodOne1.Text != "" && txtBloodOne2.Text != "")
                {
                    blood += "O" + txtBloodOne1.Text + "/" + txtBloodOne2.Text;
                }
            }
            else if (rbBloodOneNo.Checked)
            {
                blood += "O" + "�ⲻ��";
            }


            if (rbBloodTwo.Checked)
            {
                if (txtBloodTwo1.Text != "" && txtBloodTwo2.Text != "")
                {            //Ѫѹ2
                    if (blood != "")
                    {
                        blood += ",";
                    }
                    blood += "T" + txtBloodTwo1.Text + "/" + txtBloodTwo2.Text;
                }
            }
            else if (rbBloodTwoNo.Checked)
            {            //Ѫѹ2
                if (blood != "")
                {
                    blood += ",";
                }
                blood += "T" + "�ⲻ��";
            }
            tti.Bp_blood = blood;
            tti.Empty_name1 = txtEmptyItemName1.Text;
            tti.Empty_value1 = txtEmptyItemValue1.Text;
            tti.Empty_name2 = txtEmptyItemName2.Text;
            tti.Empty_value2 = txtEmptyItemValue2.Text;
            return tti;
        }

        private void rbNormal_Click_1(object sender, EventArgs e)
        {
            setIsTrurFalse(((RadioButton)sender).Name);
        }

        /// <summary>
        /// ֻ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789.";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }
            if ((Keys)(e.KeyChar) == Keys.Back)
            {
                return;
            }
            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        private void rbRengonggangchang_Click(object sender, EventArgs e)
        {
            setIsTrurFalse(((RadioButton)sender).Name);
        }

        private void rbWeightOk_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWeightOk.Checked == true)
            {
                txtWeight.Enabled = true;
                txtHeight.Enabled = true;
            }
            else
            {
                txtWeight.Text = "";
                txtWeight.Enabled = false;
                txtHeight.Text = "";
                txtHeight.Enabled = false;

            }
        }

        private void rbBloodOne_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBloodOne.Checked == true)
            {
                txtBloodOne1.Enabled = true;
                txtBloodOne2.Enabled = true;
            }
            else
            {
                txtBloodOne1.Text = "";
                txtBloodOne2.Text = "";
                txtBloodOne1.Enabled = false;
                txtBloodOne2.Enabled = false;
            }
        }

        private void rbBloodTwo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBloodTwo.Checked == true)
            {
                txtBloodTwo1.Enabled = true;
                txtBloodTwo2.Enabled = true;
            }
            else
            {
                txtBloodTwo1.Text = "";
                txtBloodTwo2.Text = "";
                txtBloodTwo1.Enabled = false;
                txtBloodTwo2.Enabled = false;
            }
        }

        #region ���
        private void txtNormalDefecate_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtNormalDefecate")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }


        private void txtEnemaDefecate_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtEnemaDefecate" || textBox.Name == "txtEnemaBeforeDefecate")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtEnemaCount_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtEnemaCount")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }
        #endregion

        #region  /*Ѫѹ*/
        private void txtBloodOne1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtBloodOne1")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtBloodOne2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtBloodOne2")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtBloodTwo1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtBloodTwo1")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtBloodTwo2_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtBloodTwo2")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }
        #endregion


        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThe_TextChanged_1(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtThe")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtOut_TextChanged(object sender, EventArgs e)
        {
            if (this.txtOut.Text == ".")
            {
                this.txtOut.Text = "";
                return;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCatheterization_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtCatheterization")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }

        private void txtBoxLength_KeyDown(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string txtBox = textBox.Text;
            int nLength = 0;
            for (int i = 0; i < txtBox.Length; i++)
            {
                if (txtBox[i] >= 0x3000 && txtBox[i] <= 0x9FFF)
                    nLength += 2;
                else
                    nLength++;
            }          
        }

        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHeight_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Name == "txtHeight")
            {
                if (textBox.Text == ".")
                {
                    textBox.Text = "";
                    return;
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
             * ��صĲ������� �� Ը���µ�¼��Ĳ������
             */

            if (dateTimePicker_Select.Value.Date > Convert.ToDateTime(endDate) ||
             dateTimePicker_Select.Value.Date < Convert.ToDateTime(startDate))
            {
                App.MsgWaring("ѡ���ʱ�䲻��ȷ����ѡ�������ʱ��η�Χ֮�ڵ�ʱ�䣡");
                return;
            }

            //if (rbEnema.Checked)
            //{
            //    if (txtEnemaCount.Text.Trim() == "")
            //    {
            //        App.Msg("ѡ��೦���೦��������Ϊ��!");
            //        return;
            //    }
            //    if (txtEnemaCount.Text.Trim() == "0")
            //    {
            //        App.Msg("ѡ��೦���೦��������Ϊ0!");
            //        return;
            //    }
            //    if (txtAfterEnemaShitCount.Text.Trim().Length == 0)
            //    {
            //        App.Msg("ѡ��೦������������Ϊ��!");
            //        return;
            //    }
            //}
            if (rbEnema2.Checked)
            {
                int iEnema = 0;
                int.TryParse(this.cmbEnema.Text.Trim(), out iEnema);
                if (iEnema < 1)
                {
                    App.Msg("ѡ��೦���೦��������С��1");
                    return;
                }
            }

            string time = dateTimePicker_Select.Value.ToString("yyyy-MM-dd");
            DBControl.IsClear_Others(time, this.pid_ids); //����ʱ���������
            string title = string.Format("��ѯʱ��[{0}]-��������[{1}]-���˱��[{2}]-��������[{3}]-����[{4}]-����[{5}]-", time, pid_ids, pid, "", bed_no, "");

            //list.Add(this.GetTempers(this.pid, this.bed_no, dateTimePicker_Select.Value.ToString("yyyy-MM-dd"), this.pid_ids));


            if (DBControl.InsertTempers_Others(ExcuteTemperOther()))                      //���²�������Remove
            {
                if (Erm != "")
                {
                    DBControl.ErrorLog("���µ�����ɹ�: �����û�:" + App.UserAccount.UserInfo.User_name, title + Erm);
                }
                App.Msg("���ݱ���ɹ�");                
            }
            else
            {
                if (Erm != "")
                {
                    DBControl.ErrorLog("���µ�����ʧ��: �����û�:" + App.UserAccount.UserInfo.User_name, title + Erm);
                }
                App.Msg("���ݱ���ʧ��");               
            }
            this.Close();
        }

        /// <summary>
        /// �����˳�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// ˢ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePicker_Select_ValueChanged(object sender, EventArgs e)
        {
            List<DataTable> list = GetTemper(dateTimePicker_Select.Value.ToString("yyyy-MM-dd"), this.pid_ids);
            Clear();
            if (list != null)
            {
                
                LoadAll(list);
            }
        }

        /// <summary>
        /// ������е���Ϣ
        /// </summary>
        private void Clear()
        {
            rbNormal.Checked = true;
            txtNormalDefecate.Text = "";
            txtEnemaCount.Text = "";
            txtAfterEnemaShitCount.Text = "";
            txtEnemaDefecate.Text = "";
            txtEnemaBeforeDefecate.Text = "";
            txtBloodOne1.Text = "";
            txtBloodOne2.Text = "";
            txtBloodTwo1.Text = "";
            txtBloodTwo2.Text = "";        
            txtWeight.Text = "";
            txtHeight.Text = "";       
            txtOut.Text = "";           
            rbWeightOk.Checked = true;
            txtDragInfact.Text = "";
            txtUrine.Text = "";
            rbNormal_Urine.Checked = true;
            txtEmptyItemName1.Text = "";
            txtEmptyItemName2.Text = "";
            txtEmptyItemValue1.Text = "";
            txtEmptyItemValue2.Text = "";
        }

        private void rbIncontinence_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtUrine_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbNormal_Urine_CheckedChanged(object sender, EventArgs e)
        {
            if (rbNormal_Urine.Checked)
            {
                txtUrine.Enabled = true;
            }
            else
            {
                txtUrine.Enabled = false;
            }
        }

        /// <summary>
        /// ��ҩ�������ŵ��ֵ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsertDic_Click(object sender, EventArgs e)
        {
            try
            {

                DataSet ds = App.GetDataSet("select id from T_DATA_CODE where type=195 and name='" + App.ToDBC(txtDragInfact.Text) + "'");

                if (ds.Tables[0].Rows.Count>0)
                {
                    App.MsgWaring("�ֵ�����Ѿ�������ص�ҩ�������¼��");
                    return;
                }
                
               string ID = App.GenId("T_DATA_CODE", "ID").ToString();
               string Sql = "insert into T_DATA_CODE(ID,NAME,CODE,SHORTCUT_CODE,ENABLE,TYPE)values(" + ID + ",'" + App.ToDBC(txtDragInfact.Text) + "','"
                     + App.getSpell(App.ToDBC(txtDragInfact.Text)) + ID.ToString() + "','" + App.getSpell(App.ToDBC(txtDragInfact.Text)) + "','Y','195')";
               if (App.ExecuteSQL(Sql) > 0)
               {
                   App.Msg("�����ɹ���");
               }
               else
               {
                   App.MsgErr("����ʧ�ܣ�");
               }

               
            }
            catch(Exception ex)
            {
                App.MsgErr("����ʧ�ܣ�ԭ��"+ex.Message);
            }

        }

        private void txtDragInfact_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtDragInfact_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtDragInfact.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select id as ���,name as ���� from t_data_code d where d.type=195 and upper(d.shortcut_code) like '" + txtDragInfact.Text.ToUpper().Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtDragInfact, "����", "���");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }

        private void chkIncontinence_Click(object sender, EventArgs e)
        {
            //if (chkIncontinence.Checked==true)
            //{
            //    txtEnemaTimes.Text = "";
            //    txtEnemaTimes.Enabled = false;
            //}
            //else
            //{
            //    txtEnemaTimes.Enabled = true;
            //}
        }

        private void rbEnema_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkIncontinence_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbEnema_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtAfterEnemaShitCount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void cmbBeforeEnema_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}