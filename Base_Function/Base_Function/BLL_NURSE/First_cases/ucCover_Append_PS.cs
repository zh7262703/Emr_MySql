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
    /// 压疮附页的编辑
    /// 作者:李文明
    /// 时间:2013-01-30
    /// </summary>
    public partial class ucCover_Append_PS : UserControl
    {
        private string PatientId = "";           //当前病人的主键
        private string Cover_Append_id = "";   //当前选中的住院附页的主键
        private string option = "-请选择-";    //下拉首选值
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patientid">病人主键</param>
        public ucCover_Append_PS(string patientid)
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
        public ucCover_Append_PS(string patientid, string cover_append_id)
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
        /// 初始化值
        /// </summary>
        private void iniSelectValues()
        {
            try
            {
                //患者压疮级别
                DataSet ds_PS_LEVEL = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='HZYCJB001'");
                //患者压疮级别
                DataSet ds_PS_LEVEL2 = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='HZYCJB001'");
                
                //患者压疮来源
                DataSet ds_SOURCE = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='HZYCLY001'");
                //压疮发生部位
                DataSet ds_PARTS = App.GetDataSet("select t.id,t.name from t_data_code t inner join t_data_code_type t2 on t.type=t2.id where t2.type='YCFSBW001'");

                DataRow dr_PS_LEVEL = ds_PS_LEVEL.Tables[0].NewRow();
                dr_PS_LEVEL["name"] = option;
                dr_PS_LEVEL["id"] = "-1";
                ds_PS_LEVEL.Tables[0].Rows.InsertAt(dr_PS_LEVEL, 0);
                cboPS_LEVEL.DataSource = ds_PS_LEVEL.Tables[0].DefaultView;
                cboPS_LEVEL.DisplayMember = "name";
                cboPS_LEVEL.ValueMember = "id";
                
                DataRow dr_PS_LEVEL2 = ds_PS_LEVEL2.Tables[0].NewRow();
                dr_PS_LEVEL2["name"] = option;
                dr_PS_LEVEL2["id"] = "-1";
                ds_PS_LEVEL2.Tables[0].Rows.InsertAt(dr_PS_LEVEL2, 0);
                cboPS_LEVEL2.DataSource = ds_PS_LEVEL2.Tables[0].DefaultView;
                cboPS_LEVEL2.DisplayMember = "name";
                cboPS_LEVEL2.ValueMember = "id";

                DataRow dr_SOURCE = ds_SOURCE.Tables[0].NewRow();
                dr_SOURCE["name"] = option;
                dr_SOURCE["id"] = "-1";
                ds_SOURCE.Tables[0].Rows.InsertAt(dr_SOURCE, 0);
                cboSOURCE.DataSource = ds_SOURCE.Tables[0].DefaultView;
                cboSOURCE.DisplayMember = "name";
                cboSOURCE.ValueMember = "id";

                
                chkPARTS.DataSource = ds_PARTS.Tables[0].DefaultView;
                chkPARTS.DisplayMember = "name";
                chkPARTS.ValueMember = "id";

               
            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败,原因:"+ex.Message);
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

                string PS_TIME = "";            //压疮日
                if (rdoPS_TIME_GZR.Checked)
                {
                    PS_TIME = "1";
                }
                else if (rdoPS_TIME_ZM.Checked)
                {
                    PS_TIME = "2";
                }
                else if (rdoPS_TIME_JJR.Checked)
                {
                    PS_TIME = "3";
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    App.Msg("提示:[" + label1.Text + "]未选择!");
                    return false;
                }

                string PS_DETIAL_TIEM = dtpPS_DETIAL_TIEM.Value.ToString("yyyy/MM/dd HH:mm:ss");     //具体发生或发现时间

                string IS_CRISI_PATIENT = "";   //入院时评估为高风险患者
                if (rdoIS_CRISI_PATIENT_N.Checked)
                {
                    IS_CRISI_PATIENT = "N";
                }
                else if (rdoIS_CRISI_PATIENT_Y.Checked)
                {
                    IS_CRISI_PATIENT = "Y";
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    App.Msg("提示:[" + label3.Text + "]未选择!");
                    return false;
                }

                string CRISI_SCORE = "";        //压疮危重程度评分
                if (txtCRISI_SCORE.Text.Trim()!="")
                {
                    CRISI_SCORE = txtCRISI_SCORE.Text;
                }
                else
                {
                    label4.ForeColor = Color.Red;
                    label9.ForeColor = Color.Red;
                    App.Msg("提示:[" + label4.Text + "]未填写!");
                    return false;
                }

                string PS_TYPE = "";            //压疮来源类型
                string PS_LEVEL = "";           //压疮级别
                string SOURCE = "";             //患者压疮来源（数据字典代码）
                
                
                string PS_TYPE2 = "";            //压疮来源类型
                string PS_LEVEL2 = "";           //压疮级别
                string IS_MOREPART = "";        //是否发生多部位压疮情况 Y 是 N 否
                string PARTS = "";              //发生部位
                if (chkPS_TYPE_in.Checked == true || chkPS_TYPE_on.Checked == true)
                {
                    if (chkPS_TYPE_in.Checked)
                    {//入院前
                        PS_TYPE = "Y";
                                   //压疮级别
                        if (cboPS_LEVEL.SelectedValue != null && cboPS_LEVEL.Text != option)
                        {
                            PS_LEVEL = cboPS_LEVEL.SelectedValue.ToString();
                        }
                        else if (cboPS_LEVEL.Items.Count > 1)
                        {
                            label10.ForeColor = Color.Red;
                            App.Msg("提示:[" + label10.Text + "]未选择!");
                            return false;
                        }
                        //压疮来源
                        if (cboSOURCE.SelectedValue != null && cboSOURCE.Text != option)
                        {
                            SOURCE = cboSOURCE.SelectedValue.ToString();
                        }
                        else if (cboSOURCE.Items.Count > 1)
                        {
                            label6.ForeColor = Color.Red;
                            App.Msg("提示:[" + label6.Text + "]未选择!");
                            return false;
                        }

                    }
                    if (chkPS_TYPE_on.Checked)
                    {//入院后
                        PS_TYPE2 = "Y";
                        if (cboPS_LEVEL2.SelectedValue != null && cboPS_LEVEL2.Text != option)
                        {
                            PS_LEVEL2 = cboPS_LEVEL2.SelectedValue.ToString();
                        }
                        else if (cboPS_LEVEL2.Items.Count > 1)
                        {
                            label11.ForeColor = Color.Red;
                            App.Msg("提示:[" + label11.Text + "]未选择!");
                            return false;
                        }

                        //是否发生多部位
                        if (rdoIS_MOREPART_N.Checked)
                        {
                            IS_MOREPART = "N";
                        }
                        else if (rdoIS_MOREPART_Y.Checked)
                        {
                            IS_MOREPART = "Y";
                        }
                        else
                        {
                            label8.ForeColor = Color.Red;
                            App.Msg("提示:[" + label8.Text + "]未选择!");
                            return false;
                        }
                        //发生部位
                        if (chkPARTS.Items.Count > 0 && chkPARTS.CheckedItems.Count == 0)
                        {
                            label7.ForeColor = Color.Red;
                            App.Msg("提示:[" + label7.Text + "]未选择!");
                            return false;
                        }
                        for (int i = 0; i < chkPARTS.CheckedItems.Count; i++)
                        {

                            DataRowView temp = (DataRowView)chkPARTS.CheckedItems[i];
                            if (PARTS == "")
                            {
                                PARTS = temp["id"].ToString();
                            }
                            else
                            {
                                PARTS = PARTS + "," + temp["id"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    label5.ForeColor = Color.Red;
                    App.Msg("提示:[" + label5.Text + "]未选择!");
                    return false;
                }

                string Sql = "";
                //if (PS_TIME != "" && PS_DETIAL_TIEM != "" && IS_CRISI_PATIENT != "" && CRISI_SCORE != "" && PS_TYPE != "" && PS_LEVEL != "" && SOURCE != "" && PARTS != "" && IS_MOREPART != "")
                
                if (Cover_Append_id == "")
                {
                    Sql = "insert into COVER_APPEND_PS(PATIENT_ID,PS_TIME,PS_DETIAL_TIEM,IS_CRISI_PATIENT," +
                                                            "CRISI_SCORE,PS_TYPE,PS_LEVEL,SOURCE,PARTS,IS_MOREPART," +
                                                            "CREATE_TIME,USER_ID,PS_TYPE_ON,PS_LEVEL_ON)values({0},'{1}'" +
                                                            ",to_timestamp('{2}','syyyy-mm-dd hh24:mi:ss')" +
                                                            ",'{3}','{4}','{5}','{6}','{7}','{8}','{9}'," +
                                                            "to_timestamp('{10}','syyyy-mm-dd hh24:mi'),{11},'{12}','{13}')";

                    Sql = string.Format(Sql, PatientId, PS_TIME, PS_DETIAL_TIEM, IS_CRISI_PATIENT,
                                            CRISI_SCORE, PS_TYPE, PS_LEVEL, SOURCE, PARTS, IS_MOREPART,
                                            App.GetSystemTime().ToShortDateString(),
                                            App.UserAccount.UserInfo.User_id, PS_TYPE2, PS_LEVEL2);
                }
                else
                {
                    Sql = "update COVER_APPEND_PS set PS_TIME='{0}',PS_DETIAL_TIEM=to_timestamp('{1}','syyyy-mm-dd hh24:mi:ss')," +
                                                            "IS_CRISI_PATIENT='{2}',CRISI_SCORE='{3}',PS_TYPE='{4}',PS_LEVEL='{5}'," +
                                                            "SOURCE='{6}',PARTS='{7}',IS_MOREPART='{8}',PS_TYPE_ON='{9}',PS_LEVEL_ON='{10}' " +
                                                            " where PATIENT_ID=" + PatientId + " and ID=" + Cover_Append_id + "";
                    Sql = string.Format(Sql, PS_TIME, PS_DETIAL_TIEM, IS_CRISI_PATIENT,
                                            CRISI_SCORE, PS_TYPE, PS_LEVEL, SOURCE, PARTS, IS_MOREPART, PS_TYPE2, PS_LEVEL2);
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
        /// 初始化压疮附页信息
        /// </summary>
        /// <param name="Cover_Append_id">附页的主键</param>
        private void iniData(string Cover_Append_id)
        {
            try 
	        {
                string sql = "select PS_TIME,to_char(PS_DETIAL_TIEM,'YYYY/MM/DD HH24:MI:ss') as PS_DETIAL_TIEM,IS_CRISI_PATIENT,"+
                                    "CRISI_SCORE,PS_TYPE,PS_LEVEL,SOURCE,PARTS,IS_MOREPART,PS_TYPE_ON,PS_LEVEL_ON" +
                                    " from COVER_APPEND_PS where id=" + Cover_Append_id;
                                    
                DataTable dt = App.GetDataSet(sql).Tables[0];
                if (dt.Rows.Count>0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //--------------------------------压疮-----------------------------------------------
                        if (dt.Rows[i]["PS_TIME"].ToString().Trim() != "")       //压疮日
                        {
                            if (dt.Rows[i]["PS_TIME"].ToString()=="2")
                            {
                                rdoPS_TIME_ZM.Checked = true;
                            }
                            else if (dt.Rows[i]["PS_TIME"].ToString() == "3")
                            {
                                rdoPS_TIME_JJR.Checked = true;
                            }
                            else
                            {
                                rdoPS_TIME_GZR.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["PS_DETIAL_TIEM"].ToString().Trim() != "")       //具体发生或发现时间
                        {
                            dtpPS_DETIAL_TIEM.Text = dt.Rows[i]["PS_DETIAL_TIEM"].ToString();
                        }
                        //入院时评估为高风险患者Y 是 N 否
                        if (dt.Rows[i]["IS_CRISI_PATIENT"].ToString().Trim() != "")       
                        {
                            if (dt.Rows[i]["IS_CRISI_PATIENT"].ToString() == "Y")
                            {
                                rdoIS_CRISI_PATIENT_Y.Checked = true;
                            }
                            else
                            {
                                rdoIS_CRISI_PATIENT_N.Checked = true;
                            }
                        }

                        if (dt.Rows[i]["CRISI_SCORE"].ToString().Trim() != "")       //压疮危重程度评分
                        {
                            txtCRISI_SCORE.Text = dt.Rows[i]["CRISI_SCORE"].ToString();
                        }

                        if (dt.Rows[i]["PS_TYPE"].ToString().Trim() != "")       //压疮来源类型
                        {
                            chkPS_TYPE_in.Checked = true;
                            if (dt.Rows[i]["PS_LEVEL"].ToString().Trim() != "")       //压疮级别
                            {
                                cboPS_LEVEL.SelectedValue = dt.Rows[i]["PS_LEVEL"].ToString();
                            }

                            if (dt.Rows[i]["SOURCE"].ToString().Trim() != "")       //患者压疮来源（数据字典代码）
                            {
                                cboSOURCE.SelectedValue = dt.Rows[i]["SOURCE"].ToString();
                            }
                        }

                        
                        if (dt.Rows[i]["PS_TYPE_ON"].ToString().Trim() != "")       //住院间发生压疮 Y 是 null 否
                        {
                            chkPS_TYPE_on.Checked = true;
                            if (dt.Rows[i]["PS_LEVEL_ON"].ToString().Trim() != "")       //患者压疮级别
                            {
                                cboPS_LEVEL2.SelectedValue = dt.Rows[i]["PS_LEVEL_ON"].ToString();
                            }


                            if (dt.Rows[i]["PARTS"].ToString().Trim() != "")       //发生部位
                            {

                                string[] vals = dt.Rows[i]["PARTS"].ToString().Split(',');
                                for (int i1 = 0; i1 < vals.Length; i1++)
                                {
                                    for (int j = 0; j < chkPARTS.Items.Count; j++)
                                    {
                                        DataRowView temp = (DataRowView)chkPARTS.Items[j];
                                        if (temp["id"].ToString() == vals[i1])
                                        {
                                            chkPARTS.SetItemChecked(j, true);
                                        }
                                    }
                                }
                            }

                            if (dt.Rows[i]["IS_MOREPART"].ToString().Trim() != "")       //是否发生多部位压疮情况 Y 是 N 否
                            {
                                if (dt.Rows[i]["IS_MOREPART"].ToString() == "Y")
                                {
                                    rdoIS_MOREPART_Y.Checked = true;
                                }
                                else
                                {
                                    rdoIS_MOREPART_N.Checked = true;
                                }
                            }
                        }

                    }
                }
	        }
	        catch (Exception ex)
	        {
                App.MsgErr("操作失败,原因:"+ex.Message);
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

       

        /// <summary>
        /// 入院前
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPS_TYPE_in_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPS_TYPE_in.Checked)
                plPS_TYPE_in.Enabled = true;
            else
            {
                plPS_TYPE_in.Enabled = false;
                cboPS_LEVEL.SelectedIndex = 0;
                cboSOURCE.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 入院后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPS_TYPE_on_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPS_TYPE_on.Checked)
                plPS_TYPE_on.Enabled = true;
            else
            {
                plPS_TYPE_on.Enabled = false;
                cboPS_LEVEL2.SelectedIndex = 0;
                rdoIS_MOREPART_Y.Checked = false;
                rdoIS_MOREPART_N.Checked = false;
                foreach (int i in chkPARTS.CheckedIndices)
                {
                    chkPARTS.SetItemChecked(i, false);
                }
            }
        }
    
    }
}
