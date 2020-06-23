using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.First_cases
{
    /// <summary>
    /// 抗生素附页的编辑
    /// 作者:李文明
    /// 时间:2013-01-29
    /// </summary>
    public partial class ucCover_Append_ANTIBIOTICS : UserControl
    {

        private string PatientId = "";           //当前病人的主键
        private string Cover_Append_id = "";   //当前选中的住院附页的主键
        private string option = "-请选择-";    //下拉首选值
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patientid">病人主键</param>
        public ucCover_Append_ANTIBIOTICS(string patientid)
        {
            InitializeComponent();
            PatientId = patientid;
            iniSelectValues();
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patientid">病人主键</param>
        /// <param name="cover_append_id">住院附页的主键</param>
        public ucCover_Append_ANTIBIOTICS(string patientid, string cover_append_id)
        {
            InitializeComponent();
            PatientId = patientid;
            Cover_Append_id = cover_append_id;
            iniSelectValues();
            if (Cover_Append_id != "")
            {
                //当附页是已经写过的附页
                iniData(cover_append_id);

            }

        }

        /// <summary>
        /// 初始化一些下拉选择项的值
        /// </summary>
        private void iniSelectValues()
        {
            try
            {
                //抗菌用药用途
                DataSet ds_U = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='KJYYYT001'");
                //抗菌药物名称
                DataSet ds_N = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='KJYWMC001'");
                //抗菌药物级别
                DataSet ds_L = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='KJYWJB001'");
                //抗菌药物类型
                DataSet ds_TY = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='KJYWLX001'");
                //病原学检测标本
                DataSet ds_BYX = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='BYXJCBB001'");
                //微生物检测结果
                DataSet ds_WSW = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='WSWJCJG001'");

                DataRow dr_U = ds_U.Tables[0].NewRow();
                dr_U["name"] = option;
                dr_U["id"] = "-1";
                ds_U.Tables[0].Rows.InsertAt(dr_U, 0);
                cboANTIBACTERIAL_DRUGS_U.DataSource = ds_U.Tables[0].DefaultView;
                cboANTIBACTERIAL_DRUGS_U.DisplayMember = "name";
                cboANTIBACTERIAL_DRUGS_U.ValueMember = "id";

                DataRow dr_N = ds_N.Tables[0].NewRow();
                dr_N["name"] = option;
                dr_N["id"] = "-1";
                ds_N.Tables[0].Rows.InsertAt(dr_N, 0);
                cboANTIBACTERIAL_DRUGS_N.DataSource = ds_N.Tables[0].DefaultView;
                cboANTIBACTERIAL_DRUGS_N.DisplayMember = "name";
                cboANTIBACTERIAL_DRUGS_N.ValueMember = "id";

                DataRow dr_L = ds_L.Tables[0].NewRow();
                dr_L["name"] = option;
                dr_L["id"] = "-1";
                ds_L.Tables[0].Rows.InsertAt(dr_L, 0);
                cboANTIBACTERIAL_DRUGS_L.DataSource = ds_L.Tables[0].DefaultView;
                cboANTIBACTERIAL_DRUGS_L.DisplayMember = "name";
                cboANTIBACTERIAL_DRUGS_L.ValueMember = "id";

                DataRow dr_TY = ds_TY.Tables[0].NewRow();
                dr_TY["name"] = option;
                dr_TY["id"] = "-1";
                ds_TY.Tables[0].Rows.InsertAt(dr_TY, 0);
                cboANTIBACTERIAL_DRUGS_TY.DataSource = ds_TY.Tables[0].DefaultView;
                cboANTIBACTERIAL_DRUGS_TY.DisplayMember = "name";
                cboANTIBACTERIAL_DRUGS_TY.ValueMember = "id";

                DataRow dr_BYX = ds_BYX.Tables[0].NewRow();
                dr_BYX["name"] = option;
                dr_BYX["id"] = "-1";
                ds_BYX.Tables[0].Rows.InsertAt(dr_BYX, 0);
                cboP_D_SPECIMENS.DataSource = ds_BYX.Tables[0].DefaultView;
                cboP_D_SPECIMENS.DisplayMember = "name";
                cboP_D_SPECIMENS.ValueMember = "id";

                DataRow dr_WSW = ds_WSW.Tables[0].NewRow();
                dr_WSW["name"] = option;
                dr_WSW["id"] = "-1";
                ds_WSW.Tables[0].Rows.InsertAt(dr_WSW, 0);
                cboMICROBE_DETECTION.DataSource = ds_WSW.Tables[0].DefaultView;
                cboMICROBE_DETECTION.DisplayMember = "name";
                cboMICROBE_DETECTION.ValueMember = "id";


            }
            catch (Exception ex)
            {
                App.MsgErr("初始化下拉选择项失败,原因:" + ex.Message);
            }

        }

        /// <summary>
        /// 保存数据
        /// </summary>
        public bool SaveData()
        {
            try
            {
                foreach (Control c in this.Controls)
                {
                    if (c is Label)
                    {
                        c.ForeColor = Color.Black;
                    }
                }

                string ANTIBACTERIAL_DRUGS_T = "";        //抗菌药物目的
                if (rdoANTIBACTERIAL_DRUGS_T_YF.Checked)
                {
                    ANTIBACTERIAL_DRUGS_T = "1";
                }
                else if (rdoANTIBACTERIAL_DRUGS_T_ZL.Checked)
                {
                    ANTIBACTERIAL_DRUGS_T = "2";
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    App.Msg("提示:[" + label1.Text + "]未选择!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_C = "";         //抗菌药物方案
                if (rdoANTIBACTERIAL_DRUGS_C_DD.Checked)
                {
                    ANTIBACTERIAL_DRUGS_C = "1";
                }
                else if (rdoANTIBACTERIAL_DRUGS_C_LH.Checked)
                {
                    ANTIBACTERIAL_DRUGS_C = "2";
                }
                else
                {
                    label2.ForeColor = Color.Red;
                    App.Msg("提示:[" + label2.Text + "]未选择!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_U = "";         //抗菌药物用途
                if (cboANTIBACTERIAL_DRUGS_U.SelectedValue != null && cboANTIBACTERIAL_DRUGS_U.Text!=option)
                {
                    ANTIBACTERIAL_DRUGS_U = cboANTIBACTERIAL_DRUGS_U.SelectedValue.ToString();
                }
                else if (cboANTIBACTERIAL_DRUGS_U.Items.Count > 1)
                {
                    label3.ForeColor = Color.Red;
                    App.Msg("提示:[" + label3.Text + "]未选择!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_TI = "";        //抗菌药物时间
                if (txtANTIBACTERIAL_DRUGS_TI.Text.Trim()!="")
                {
                    ANTIBACTERIAL_DRUGS_TI = txtANTIBACTERIAL_DRUGS_TI.Text;
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    App.Msg("提示:[" + label4.Text + "]未填写!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_D = "";         //抗菌药物消耗
                if (txtANTIBACTERIAL_DRUGS_D.Text.Trim()!="")
                {
                    ANTIBACTERIAL_DRUGS_D = txtANTIBACTERIAL_DRUGS_D.Text;
                }
                else
                {
                    label5.ForeColor = Color.Red;
                    App.Msg("提示:[" + label5.Text + "]未填写!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_CO = "";         //抗菌药代码
                if (txtANTIBACTERIAL_DRUGS_CO.Text.Trim()!="")
                {
                    ANTIBACTERIAL_DRUGS_CO = txtANTIBACTERIAL_DRUGS_CO.Text;
                }
                else
                {
                    label6.ForeColor = Color.Red;
                    App.Msg("提示:[" + label6.Text + "]未填写!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_N = "";          //抗菌药物名称
                if (cboANTIBACTERIAL_DRUGS_N.SelectedValue != null && cboANTIBACTERIAL_DRUGS_N.Text != option)
                {
                    ANTIBACTERIAL_DRUGS_N = cboANTIBACTERIAL_DRUGS_N.SelectedValue.ToString();
                }
                else if (cboANTIBACTERIAL_DRUGS_N.Items.Count > 1)
                {
                    label7.ForeColor = Color.Red;
                    App.Msg("提示:[" + label7.Text + "]未选择!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_L = "";          //抗菌药级别
                if (cboANTIBACTERIAL_DRUGS_L.SelectedValue != null && cboANTIBACTERIAL_DRUGS_L.Text != option)
                {
                    ANTIBACTERIAL_DRUGS_L = cboANTIBACTERIAL_DRUGS_L.SelectedValue.ToString();
                }
                else if (cboANTIBACTERIAL_DRUGS_L.Items.Count > 1)
                {
                    label8.ForeColor = Color.Red;
                    App.Msg("提示:[" + label8.Text + "]未选择!");
                    return false;
                }

                string ANTIBACTERIAL_DRUGS_TY = "";         //抗菌药类型
                if (cboANTIBACTERIAL_DRUGS_TY.SelectedValue != null && cboANTIBACTERIAL_DRUGS_TY.Text != option)
                {
                    ANTIBACTERIAL_DRUGS_TY = cboANTIBACTERIAL_DRUGS_TY.SelectedValue.ToString();
                }
                else if (cboANTIBACTERIAL_DRUGS_TY.Items.Count > 1)
                {
                    label9.ForeColor = Color.Red;
                    App.Msg("提示:[" + label9.Text + "]未选择!");
                    return false;
                }

                string ID_IATROGENIC_DETECTION = "";        //是否医源性检测 是 Y 否 N
                if (rdoID_IATROGENIC_DETECTION_Y.Checked)
                {
                    ID_IATROGENIC_DETECTION = "Y";
                }
                else if (rdoID_IATROGENIC_DETECTION_N.Checked)
                {
                    ID_IATROGENIC_DETECTION = "N";
                }
                else
                {
                    label10.ForeColor = Color.Red;
                    App.Msg("提示:[" + label10.Text + "]未选择!");
                    return false;
                }

                string P_D_SPECIMENS = "";                  //病原学检测标本
                if (cboP_D_SPECIMENS.SelectedValue != null && cboP_D_SPECIMENS.Text != option)
                {
                    P_D_SPECIMENS = cboP_D_SPECIMENS.SelectedValue.ToString();
                }
                else if (cboP_D_SPECIMENS.Items.Count > 1)
                {
                    label11.ForeColor = Color.Red;
                    App.Msg("提示:[" + label11.Text + "]未选择!");
                    return false;
                }

                string MICROBE_DETECTION = "";              //微生物检测结果
                if (cboMICROBE_DETECTION.SelectedValue != null && cboMICROBE_DETECTION.Text != option)
                {
                    MICROBE_DETECTION = cboMICROBE_DETECTION.SelectedValue.ToString();
                }
                else if (cboMICROBE_DETECTION.Items.Count > 1)
                {
                    label12.ForeColor = Color.Red;
                    App.Msg("提示:[" + label12.Text + "]未选择!");
                    return false;
                }

                string Sql = "";
                if (Cover_Append_id =="")
                {
                    Sql = "insert into COVER_APPEND_ANTIBIOTICS(PATIENT_ID,ANTIBACTERIAL_DRUGS_T,ANTIBACTERIAL_DRUGS_C,"+
                                                                "ANTIBACTERIAL_DRUGS_U,ANTIBACTERIAL_DRUGS_TI,ANTIBACTERIAL_DRUGS_D,"+
                                                                "ANTIBACTERIAL_DRUGS_CO,ANTIBACTERIAL_DRUGS_N,ANTIBACTERIAL_DRUGS_L,"+
                                                                "ANTIBACTERIAL_DRUGS_TY,ID_IATROGENIC_DETECTION,P_D_SPECIMENS,"+
                                                                "MICROBE_DETECTION,CREATE_TIME,USER_ID)values({0},'{1}','{2}','{3}',"+
                                                                "'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',"+
                                                                "to_timestamp('{13}','syyyy-mm-dd hh24:mi'),{14})";
                    Sql = string.Format(Sql,PatientId,ANTIBACTERIAL_DRUGS_T,ANTIBACTERIAL_DRUGS_C,
                                            ANTIBACTERIAL_DRUGS_U,ANTIBACTERIAL_DRUGS_TI,ANTIBACTERIAL_DRUGS_D,
                                            ANTIBACTERIAL_DRUGS_CO,ANTIBACTERIAL_DRUGS_N,ANTIBACTERIAL_DRUGS_L,
                                            ANTIBACTERIAL_DRUGS_TY,ID_IATROGENIC_DETECTION,P_D_SPECIMENS,
                                            MICROBE_DETECTION, App.GetSystemTime().ToShortDateString(),
                                            App.UserAccount.UserInfo.User_id);
                }
                else
                {
                    Sql = "update COVER_APPEND_ANTIBIOTICS set ANTIBACTERIAL_DRUGS_T='{0}',ANTIBACTERIAL_DRUGS_C='{1}'," +
                                            "ANTIBACTERIAL_DRUGS_U='{2}',ANTIBACTERIAL_DRUGS_TI='{3}',ANTIBACTERIAL_DRUGS_D='{4}'," +
                                            "ANTIBACTERIAL_DRUGS_CO='{5}',ANTIBACTERIAL_DRUGS_N='{6}',ANTIBACTERIAL_DRUGS_L='{7}'," +
                                            "ANTIBACTERIAL_DRUGS_TY='{8}',ID_IATROGENIC_DETECTION='{9}',P_D_SPECIMENS='{10}'," +
                                            "MICROBE_DETECTION='{11}' where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";
                                            
                    Sql = string.Format(Sql,ANTIBACTERIAL_DRUGS_T,ANTIBACTERIAL_DRUGS_C,
                                            ANTIBACTERIAL_DRUGS_U,ANTIBACTERIAL_DRUGS_TI,ANTIBACTERIAL_DRUGS_D,
                                            ANTIBACTERIAL_DRUGS_CO,ANTIBACTERIAL_DRUGS_N,ANTIBACTERIAL_DRUGS_L,
                                            ANTIBACTERIAL_DRUGS_TY,ID_IATROGENIC_DETECTION,P_D_SPECIMENS,
                                            MICROBE_DETECTION);
                }
                if (App.ExecuteSQL(Sql) > 0)
                {
                    App.Msg("保存成功!");
                    return true;
                }
                else
                {
                    App.MsgErr("保存失败!");
                    return false;
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败,原因:" + ex.Message);
                return false;
            }
        }

         /// <summary>
        /// 初始化手术附页信息
        /// </summary>
        /// <param name="Cover_Append_id">附页的主键</param>
        private void iniData(string Cover_Append_id)
        {
            try
            {
                string sql = "select ANTIBACTERIAL_DRUGS_T,ANTIBACTERIAL_DRUGS_C,"+
                                           " ANTIBACTERIAL_DRUGS_U,ANTIBACTERIAL_DRUGS_TI,ANTIBACTERIAL_DRUGS_D,"+
                                           " ANTIBACTERIAL_DRUGS_CO,ANTIBACTERIAL_DRUGS_N,ANTIBACTERIAL_DRUGS_L,"+
                                           " ANTIBACTERIAL_DRUGS_TY,ID_IATROGENIC_DETECTION,P_D_SPECIMENS,"+
                                           " MICROBE_DETECTION from COVER_APPEND_ANTIBIOTICS where ID=" + Cover_Append_id + "";
                DataTable dt = App.GetDataSet(sql).Tables[0];
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_T"].ToString().Trim() != "") //抗菌用药目的
                        {
                            if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_T"].ToString() == "2")
                            {
                                rdoANTIBACTERIAL_DRUGS_T_ZL.Checked = true;
                            }
                            else 
                            {
                                rdoANTIBACTERIAL_DRUGS_T_YF.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_C"].ToString().Trim() != "") //抗菌用药方案
                        {
                            if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_C"].ToString() == "2")
                            {
                                rdoANTIBACTERIAL_DRUGS_C_LH.Checked = true;
                            }
                            else
                            {
                                rdoANTIBACTERIAL_DRUGS_C_DD.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_U"].ToString().Trim() != "") //抗菌药物用途
                        {
                            cboANTIBACTERIAL_DRUGS_U.SelectedValue = dt.Rows[i]["ANTIBACTERIAL_DRUGS_U"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_TI"].ToString().Trim() != "") //抗菌药物时间
                        {
                            txtANTIBACTERIAL_DRUGS_TI.Text = dt.Rows[i]["ANTIBACTERIAL_DRUGS_TI"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_D"].ToString().Trim() != "") //抗菌药物消耗
                        {
                            txtANTIBACTERIAL_DRUGS_D.Text = dt.Rows[i]["ANTIBACTERIAL_DRUGS_D"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_CO"].ToString().Trim() != "") //抗菌药代码
                        {
                            txtANTIBACTERIAL_DRUGS_CO.Text = dt.Rows[i]["ANTIBACTERIAL_DRUGS_CO"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_N"].ToString().Trim() != "") //抗菌药物名称
                        {
                            cboANTIBACTERIAL_DRUGS_N.SelectedValue = dt.Rows[i]["ANTIBACTERIAL_DRUGS_N"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_L"].ToString().Trim() != "") //抗菌药物级别
                        {
                            cboANTIBACTERIAL_DRUGS_L.SelectedValue = dt.Rows[i]["ANTIBACTERIAL_DRUGS_L"].ToString();
                        }

                        if (dt.Rows[i]["ANTIBACTERIAL_DRUGS_TY"].ToString().Trim() != "") //抗菌药物类型
                        {
                            cboANTIBACTERIAL_DRUGS_TY.SelectedValue = dt.Rows[i]["ANTIBACTERIAL_DRUGS_TY"].ToString();
                        }

                        if (dt.Rows[i]["ID_IATROGENIC_DETECTION"].ToString().Trim() != "") //是否医源性检测 是 Y 否 N
                        {
                            if (dt.Rows[i]["ID_IATROGENIC_DETECTION"].ToString()=="Y")
                            {
                                rdoID_IATROGENIC_DETECTION_Y.Checked = true;
                            }
                            else
                            {
                                rdoID_IATROGENIC_DETECTION_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["P_D_SPECIMENS"].ToString().Trim() != "") //病原学检测标本
                        {
                            cboP_D_SPECIMENS.SelectedValue = dt.Rows[i]["P_D_SPECIMENS"].ToString();
                        }

                        if (dt.Rows[i]["MICROBE_DETECTION"].ToString().Trim() != "") //微生物检测结果
                        {
                            cboMICROBE_DETECTION.SelectedValue = dt.Rows[i]["MICROBE_DETECTION"].ToString();
                        }
                    }
                    
                }

            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败,原因:" + ex.Message);
            }

        }

        /// <summary>
        /// 只允许输入数字和小数点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
            if ((sender as TextBox).Text == "" && (Keys)(e.KeyChar) == Keys.Delete)
            {
                e.Handled = true;
                return;
            }

            if ((Keys)(e.KeyChar) == Keys.Delete)
            {
                if ((sender as TextBox).Text.Split('.').Length >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete)
            {
                return;
            }

            if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
            {
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// 只允许输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            string AstrictChar = "0123456789";
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
    }
}
