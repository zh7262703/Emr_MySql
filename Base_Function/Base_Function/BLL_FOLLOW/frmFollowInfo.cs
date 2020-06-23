using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BLL_FOLLOW.Element;
using System.Collections;
using Base_Function.BASE_COMMON;



namespace Base_Function.BLL_FOLLOW
{
    public partial class frmFollowInfo : DevComponents.DotNetBar.Office2007Form
    {
        string FollowId = "";           //当前选中的随访记录主键
        private string followName = "";  //方案名称
        private string userIds = "";    //存储用户ID
        private string sectionIds = ""; //存放科室ID
        private string icd9codes = "";  //存储icd9代码
        private string icd10codes = ""; //存储icd10代码
        private string starttime = "";  //存储参考时间
        private int defaultdays =0;   //存放首次默认天数
        private string followTimeType ="";    //存放随访时间类型
        private string followWrite_Type=""; //存放文书类别代码
        private string definefollow = "";  //随访循环天数
        private string creattime = "";   //创建时间
        private string isenable = "";       //是否有效
        private string ismain = "";     //是否为主诊断
        private string finishType = ""; //结束随访方式（次数或者时间）    
        private string maintain_section = "";   //维护科室        
      

        public frmFollowInfo(string followid)
        {

            InitializeComponent();
            FollowId = "";
            FollowId = followid;
            IniFollowType();
            refresh();
            if (FollowId != "")
            {
                IniData(FollowId);
            }
            {
                label2.Visible = false;
                ucUser.Visible = false;
                buttonX2.Visible = false;
            }
        }
        /// <summary>
        /// 获取方案实例
        /// </summary>
        /// <param name="FollowId"></param>
        private void IniData(string FollowId)
        { 
            /*
             * 加载出当前，所选择方案的所有信息
             */
            DataSet dsTempInfo = App.GetDataSet("select * from t_follow_info where id=" + FollowId + "");
            Class_FollowInfo info = new Class_FollowInfo();
            info.Id = dsTempInfo.Tables[0].Rows[0]["id"].ToString();
            info.Follow_name = dsTempInfo.Tables[0].Rows[0]["Follow_name"].ToString();
            info.Section_ids = dsTempInfo.Tables[0].Rows[0]["Section_ids"].ToString();
            info.Section_names = dsTempInfo.Tables[0].Rows[0]["Section_names"].ToString();
            info.Icd9codes = dsTempInfo.Tables[0].Rows[0]["Icd9codes"].ToString();
            info.Icd10codes = dsTempInfo.Tables[0].Rows[0]["Icd10codes"].ToString();
            info.Ismaindiag = dsTempInfo.Tables[0].Rows[0]["Ismaindiag"].ToString();
            info.Followtype = dsTempInfo.Tables[0].Rows[0]["Followtype"].ToString();
            info.Defaultdays = dsTempInfo.Tables[0].Rows[0]["Defaultdays"].ToString();
            info.Definefollows = dsTempInfo.Tables[0].Rows[0]["Definefollows"].ToString();
            info.Createtime = dsTempInfo.Tables[0].Rows[0]["Createtime"].ToString();
            info.Exec_sections = dsTempInfo.Tables[0].Rows[0]["Exec_sections"].ToString();
            info.Exec_secnames = dsTempInfo.Tables[0].Rows[0]["Exec_secnames"].ToString();
            info.Exec_sickarea = dsTempInfo.Tables[0].Rows[0]["Exec_sickarea"].ToString();
            info.Exec_sickareanames = dsTempInfo.Tables[0].Rows[0]["Exec_sickareanames"].ToString();
            info.FinishType = dsTempInfo.Tables[0].Rows[0]["FinishType"].ToString();
            info.Isenable = dsTempInfo.Tables[0].Rows[0]["Isenable"].ToString();
            info.Startingtime = dsTempInfo.Tables[0].Rows[0]["Startingtime"].ToString();
            info.Followtextid = dsTempInfo.Tables[0].Rows[0]["followtextid"].ToString();
            IniControls(info);

        }

        /// <summary>
        /// 加载控件信息
        /// </summary>
        public void IniControls(Class_FollowInfo info)
        {
            if (info != null)
            {
                txtFollowName.Text = info.Follow_name;

                //加载相关科室
                txtExecSecs.Text = info.Exec_secnames;
                txtExecSecs.Tag = info.Exec_sections;
                //加载相关病区
                txtExecSickAeras.Text = info.Exec_sickareanames;
                txtExecSickAeras.Tag = info.Exec_sickarea;
                //加载病人相关科室
                txtSection.Text = info.Section_names;
                txtSection.Tag = info.Section_ids;
                //手术
                if (icd9codes != "")
                {
                    DataSet ds_icd9 = App.GetDataSet("select code ,name  from oper_def_icd9");
                    string[] opred = info.Icd9codes.Split(',');
                    string opredname = "";

                    for (int i = 0; i < opred.Length; i++)
                    {
                        for (int j = 0; j < ds_icd9.Tables[0].Rows.Count; j++)
                            if (opred[i] == ds_icd9.Tables[0].Rows[j][0].ToString())
                            {
                                opredname = ds_icd9.Tables[0].Rows[j][1].ToString();
                                ucICD9.setWidth(ucICD9.Width);
                                ucElement element = new ucElement(opredname, opred[i]);
                                ucICD9.createUser(element);
                                break;
                            }
                    }
                }
                if (info.Icd10codes != "")
                {
                    DataSet dsIcd10 = App.GetDataSet("select code ,name  from diag_def_icd10");
                    string[] diag = info.Icd10codes.Split(',');
                    string diagName = "";
                    for (int i = 0; i < diag.Length; i++)
                    {

                        for (int j = 0; j < dsIcd10.Tables[0].Rows.Count; j++)
                            if (diag[i] == dsIcd10.Tables[0].Rows[j][0].ToString())
                            {
                                diagName = dsIcd10.Tables[0].Rows[j][1].ToString();
                                ucICD10.setWidth(ucICD10.Width);
                                ucElement element = new ucElement(diagName, diag[i]);
                                ucICD10.createUser(element);
                                break;
                            }
                    }
                }
                //是否主诊断
                if (info.Ismaindiag == "Y")
                    checkMain.Checked = true;
                else
                    checkMain.Checked = false;
                //默认参考时间
                cmbStartTime.Text = info.Startingtime;
                //首次默认时间
                txtDefaultDay.Text = info.Defaultdays;
                //随访方式
                if (info.Followtype != "")
                {
                    grpBoxDefineTime.Enabled = false;
                    int i = 0;
                    foreach (Object ob in cmbFollowTimeType.Items)
                    {
                        DataRowView drv = ob as DataRowView;
                        string value = drv["typename"].ToString();
                        if (value == info.Followtype)
                        {
                            cmbFollowTimeType.SelectedIndex = i;
                            break;
                        }
                        i++;
                    }
                }
                //添加循环方式
                else
                {
                    string times;
                    string[] days = info.Definefollows.Split(',');
                    for (int i = 0; i < days.Length; i++)
                    {
                        int temp = i + 1;
                        times = "第" + temp + "次";
                        dgvDefineTime.Rows.Add(false, times, days[i]);
                    }

                }
                //
                if (info.FinishType != "")
                {
                    ckbEnd.Checked = true;
                    panel3.Enabled = true;
                    if (info.FinishType.IndexOf("年") != -1)
                    {
                        rbtnTime.Checked = true;
                        rbtnTimes.Checked = false;
                        txtTime.Text = info.FinishType.Substring(0, info.FinishType.IndexOf("年"));
                        cmbYMD2.Text = "年";

                    }
                    else if (info.FinishType.IndexOf("月") != -1)
                    {
                        rbtnTime.Checked = true;
                        rbtnTimes.Checked = false;
                        txtTime.Text = info.FinishType.Substring(0, info.FinishType.IndexOf("月"));
                        cmbYMD2.Text = "月";
                    }
                    else if (info.FinishType.IndexOf("日") != -1)
                    {
                        rbtnTime.Checked = true;
                        rbtnTimes.Checked = false;
                        txtTime.Text = info.FinishType.Substring(0, info.FinishType.IndexOf("日"));
                        cmbYMD2.Text = "日";
                    }
                    else if (info.FinishType.IndexOf("次") != -1)
                    {
                        rbtnTime.Checked = false;
                        rbtnTimes.Checked = true;
                        txtTimes.Text = info.FinishType.Substring(0, info.FinishType.IndexOf("次"));
                    }
                }
                else
                {
                    panel3.Enabled = false;
                    ckbEnd.Checked = false;
                }
                //
                DataSet ds_texttype = App.GetDataSet("select id,textname from t_follow_text where  enable_flag='Y'");
                string[] texttypes = info.Followtextid.Split(',');
                txtFollowType.Tag = info.Followtextid;
                ///加载文书类型
                if (info.Followtextid != "")
                {
                    for (int i = 0; i < texttypes.Length; i++)
                    {
                        if (texttypes[i] == "")
                            break;
                        else
                            for (int j = 0; j < ds_texttype.Tables[0].Rows.Count; j++)
                                if (texttypes[i] == ds_texttype.Tables[0].Rows[j][0].ToString())
                                {
                                    if (txtFollowType.Text == "")
                                        txtFollowType.Text = ds_texttype.Tables[0].Rows[j]["textname"].ToString();
                                    else
                                        txtFollowType.Text += "," + ds_texttype.Tables[0].Rows[j]["textname"].ToString();
                                    break;
                                }
                    }
                }

                //是否有效复选框
                if (info.Isenable == "Y")
                    rbtnValid.Checked = true;
                else
                    rbtnVain.Checked = true;
                //创建时间
                dataTimeCreate.Value= Convert.ToDateTime(info.Createtime);
            }

        }
        /// <summary>
        /// 初始化各控件
        /// </summary>
        public void refresh()
        {
            grpBoxDefineTime.Enabled = true;    //循环时间类型控件
            cmbStartTime.SelectedIndex = 0;     
            cmbYMD.SelectedIndex = 0;
            checkMain.Checked = false;
            txtFollowName.Text = "";
            txtDefaultDay.Text = "";
            txtFollowDefineTime.Text = "";
            txtTimes.Text = "";
            txtTime.Text = "";
            txtTime.Enabled = false;
            cmbYMD2.Enabled = false;
            dgvDefineTime.Columns[1].ReadOnly = true;
            dgvDefineTime.Columns[2].ReadOnly = true;   
       
            txtSection.Text = "";
            txtSection.Tag = null;
            txtFollowType.Text = "";
            txtFollowType.Tag = null;
            txtFollowType.ReadOnly = true;
            txtSection.ReadOnly = true;
            if (FollowId == "")
            {
                grpBoxDefineTime.Enabled = false;
                panel3.Enabled = false;
            }
            else
            {
                
                panel3.Enabled = true;
            }
            ucUser.disposeElement();
            ucICD10.disposeElement();
            ucICD9.disposeElement();
            
        }
        /// <summary>
        ///绑定时间类型下拉框 
        /// </summary>
        public void IniFollowType()
        {
            //初始化随访时间类型ComboBox
            string sql = "select id,typename from T_FOLLOW_TYPE";
            DataSet ds_time = App.GetDataSet(sql);
            DataRow row = ds_time.Tables[0].NewRow();
            row[0] = "0";
            row[1] = "";
            ds_time.Tables[0].Rows.InsertAt(row,0);
            cmbFollowTimeType.DataSource = ds_time.Tables[0].DefaultView;
            cmbFollowTimeType.DisplayMember = "typename";
            cmbFollowTimeType.ValueMember = "id";
            cmbFollowTimeType.SelectedIndex = 0;
        }
        #region
        /// <summary>
        /// 添加诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagAdd_Click(object sender, EventArgs e)
        {
            //初始化自定义控件宽度
            ucICD10.setWidth(ucICD10.Width);
            frmUser us = new frmUser("ICD10");
            us.ShowDialog();
            if (ucElement.id != "" && ucElement.myName != "")
            {
                ucElement element = new ucElement(ucElement.myName, ucElement.id);
                ucICD10.createUser(element);
            }
        }
        /// <summary>
        /// 添加手术
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSurAdd_Click(object sender, EventArgs e)
        {
            ucICD9.setWidth(ucICD9.Width);
            frmUser us = new frmUser("ICD9");
            us.ShowDialog();
            if (ucElement.id != "" && ucElement.myName != "")
            {
                ucElement element = new ucElement(ucElement.myName, ucElement.id);
                ucICD9.createUser(element);
            }
        }
        /// <summary>
        /// 管辖科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSectionAdd_Click(object sender, EventArgs e)
        {
            frmSection us = new frmSection(0);
            if (txtSection.Tag != null&&txtSection.Tag.ToString()!="")
                us.SetSelected((string)txtSection.Tag);
            us.ShowDialog();
            txtSection.Text = us.GetNames();
            txtSection.Tag = us.GetIds();

        }
        /// <summary>
        /// 添加随访方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFollowTypeAdd_Click(object sender, EventArgs e)
        {
            if (txtSection.Text == "")
            {
                App.Msg("科室不得为空!");
                return;
            }
            Template.fmT = new TextEditor.frmText();
            frmFollowDocScan us = new frmFollowDocScan(txtSection.Tag.ToString());
            if (txtFollowType.Tag != null)
                us.SetSelectType(txtFollowType.Tag.ToString());
            us.ShowDialog();
            txtFollowType.Text = us.CkTypeNames;
            txtFollowType.Tag = us.CkTypeIds;
        }
        #endregion
        /// <summary>
        /// 将时间类型加到dataGridView中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string type;
            type = txtFollowDefineTime.Text.Trim() + cmbYMD.Text;
            string times;
            times = "第" + (dgvDefineTime.Rows.Count+1).ToString() + "次";
            dgvDefineTime.Rows.Add(false,times, type);

        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int id ;
            id = App.GenId("t_follow_info", "id");
            string followName = "";
            if (txtFollowName.Text != "")
                followName = txtFollowName.Text;
            else
            {
                App.Msg("方案名不得为空");
                txtFollowName.Focus();
                return;
            }
            ////遍历用户id
            //if (ucUser.GetIds() != "")
            //    userIds = ucUser.GetIds();
            //else
            //{
            //    App.Msg("用户不得为空!");
            //    return;
            //}
            //遍历科室id
            string sectionIds = "";
            string sectionNames = "";
            if (txtSection.Text != "")
            {
                sectionIds = txtSection.Tag.ToString();
                sectionNames = txtSection.Text.Trim();
            }
            else
            {
                App.Msg("科室不得为空");
                return;
            }
            //遍历诊断id
            string icd10codes = "";
            if (ucICD10.GetIds() != "")
                icd10codes = ucICD10.GetIds();
            string ismain = "";
            if(checkMain.Checked==true)
                ismain="Y";
            else
                ismain="N";
            //遍历手术id
            string icd9codes = "";
            if (ucICD9.GetIds() != "")
                icd9codes = ucICD9.GetIds();
            //参考时间
            string stattime = "";
            starttime = cmbStartTime.Text;
            //首次默认天数
            int defaultdays = 0;
            if (txtDefaultDay.Text != "")
                defaultdays = Convert.ToInt32(txtDefaultDay.Text);
            else
                defaultdays = 0;
            //循环设置
            string followTimeType = "";
            string definefollow = "";
            if (cmbFollowTimeType.Text == "" && dgvDefineTime.Rows.Count == 0)
            {
                App.Msg("请选择随访时间方式");
                return;
            }
            //随访时间类型
            if (cmbFollowTimeType.Text != "")
            {
                followTimeType = cmbFollowTimeType.Text;
                
            }
            //随访循环天数设置
            else
            {
                for (int i = 0; i < dgvDefineTime.Rows.Count; i++)
                {
                    if (definefollow == "")
                        definefollow = dgvDefineTime.Rows[i].Cells["时间"].Value.ToString();
                    else
                        definefollow += "," + dgvDefineTime.Rows[i].Cells["时间"].Value.ToString();
                }
                
            }
            //循环结束次数
            string finishType = "";
            if (ckbEnd.Checked)
            {
                if (rbtnTimes.Checked == true)
                {
                    if (txtTimes.Text != "")
                        finishType = txtTimes.Text.Trim() + "次";
                    else
                    {
                        App.MsgErr("设置结束次数");
                        return;
                    }

                }
                //循环结束时间
                else
                {
                    if (txtTime.Text != "")
                        finishType = txtTime.Text + cmbYMD2.Text;
                    else
                    {
                        App.MsgErr("设置结束时间");
                        return;
                    }
                }
            }
            //获取文书id
            string followWrite_Type = "";
            if (txtFollowType.Text!= "")
                followWrite_Type = txtFollowType.Tag.ToString();
            string creattime = "";
            creattime = dataTimeCreate.Value.ToShortDateString();
            string isenable = "";
            if (rbtnValid.Checked == true)
                isenable = "Y";
            else
                isenable = "N";
            string mySql = "";
            string ExecSecs = "";
            string ExecSickArea = "";
            string ExecSecNames = "";
            string ExecSickAreaNames = "";
            if (txtExecSecs.Tag != null)
            {
                ExecSecs = txtExecSecs.Tag.ToString();
                ExecSecNames = txtExecSecs.Text.Trim();
            }
            if (txtExecSickAeras.Tag != null)
            {
                ExecSickArea = txtExecSickAeras.Tag.ToString();
                ExecSickAreaNames = txtExecSickAeras.Text.Trim();
            }
            if (FollowId == "")
            {
                if (checkExist(txtFollowName.Text))
                {
                    App.Msg("方案名已存在");
                    txtFollowName.Text = "";
                    txtFollowName.Focus();
                    return;
                }
                maintain_section = App.UserAccount.CurrentSelectRole.Section_name;
                
                //添加操作
                mySql = "insert into t_follow_info(id,follow_name,section_ids,icd9codes,icd10codes,ismaindiag,startingtime,defaultdays,followtype,definefollows,followtextid,createtime,isenable,maintain_section,creator,finishtype,exec_sections,exec_sickarea,section_names,exec_secnames,exec_sickareanames) values(" + id + ","  //插入id
                + "'" + followName + "',"                                                           //插入方案名                                                     
                + "'" + sectionIds + "',"                                                           //插入科室编号
                + "'" + icd9codes + "',"                                                            //插入手术编号
                + "'" + icd10codes + "',"                                                           //插入诊断编号
                + "'" + ismain + "',"                                                               //是否主诊断标记
                + "'" + starttime + "',"                                                         //参考时间
                +"" + defaultdays + ","                                                            //默认开始天数
                + "'" + followTimeType + "',"                                                             //循环时间类型
                + "'" + definefollow + "',"                                                         //具体循环方案                                                     
                + "'" + followWrite_Type + "',"                                                     //文书编号
                + "to_date('" + creattime + "','yyyy-MM-dd'),"                                                            //创建时间
                + "'" + isenable + "',"
                +"'" + maintain_section + "',"
                +"" + App.UserAccount.UserInfo.User_id + " ,"
                +"'" + finishType + "',"
                + "'" + ExecSecs + "',"
                +"'"+ExecSickArea+"',"
                +"'"+sectionNames+"',"
                +"'"+ExecSecNames+"',"
                +"'"+ExecSickAreaNames+"')";                                                         //是否有效
            }
            else
            {
                //修改操作
                mySql = "update t_follow_info set follow_name='" + followName + "',"           //                
                + "section_ids='" + sectionIds + "',"
                + "icd9codes='" + icd9codes + "',"
                + "icd10codes='" + icd10codes + "',"
                + "ismaindiag='" + ismain + "',"
                + "startingtime='" + starttime + "',"
                +"defaultdays="+defaultdays+","
                + "followtype='" + followTimeType + "',"
                + "definefollows='" + definefollow + "',"
                +"finishtype='"+finishType+"',"
                + "followtextid='" + followWrite_Type + "',"
                + "createtime=to_date('" + creattime + "','yyyy-MM-dd'),"
                + "isenable='" + isenable + "',"
                +"creator="+App.UserAccount.UserInfo.User_id+","
                +"exec_sections='"+ExecSecs+"',"
                +"exec_sickarea='"+ExecSickArea+"',"
                +"section_names='"+sectionNames+"',"
                +"exec_secnames='"+ExecSecNames+"',"
                +"exec_sickareanames='"+ExecSickAreaNames+"'where id='"+FollowId+"'";        
            }
            try
            {
                if (App.ExecuteSQL(mySql) > 0)
                    App.Msg("操作成功！");
                else
                    App.Msg("插入失败！");

            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
            finally
            {
                this.Close();
            }
        }

        /// <summary>
        /// 检查方案名是否已存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool checkExist(string name)
        {
            DataSet ds_name = new DataSet();
            string sql = "select * from t_follow_info where follow_name='"+name+"'";
            ds_name = App.GetDataSet(sql);
            if (ds_name != null)
                if (ds_name.Tables[0].Rows.Count != 0)
                    return true;
            return false;
        }
        /// <summary>
        /// 限制数字输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtDefaultDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <='9' ||e.KeyChar==08))
                e.Handled = true;
        }

        private void txtTimes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
                e.Handled = true;
        }

        private void textFollowDefineTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
                e.Handled = true;
        }

        private void txtTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == 8))
                e.Handled = true;
        }

        private void rbtnTime_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTime.Checked == true)
            {
                txtTime.Enabled = true;
                cmbYMD2.Enabled = true;
                txtTimes.Enabled = false;
            }
            else
            {
                txtTime.Enabled = false;
                cmbYMD2.Enabled = false;
                txtTimes.Enabled = true;
            }

        }


        private void btnReset_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < dgvDefineTime.Rows.Count; i++)
            {
                if ((bool)dgvDefineTime.Rows[i].Cells[0].Value)
                    dgvDefineTime.Rows.RemoveAt(i);
            }
            if (dgvDefineTime.Rows.Count != 0)
            {
                for (int i = 0; i < dgvDefineTime.Rows.Count; i++)
                {
                    int seq=i+1;
                    dgvDefineTime.Rows[i].Cells["顺序"].Value = "第" + seq + "次";

                }
            }
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFollowTimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFollowTimeType.Text != "")
                grpBoxDefineTime.Enabled = false;
            else
                grpBoxDefineTime.Enabled = true;
        }

        private void rbtnTimes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTimes.Checked)
            {
                txtTimes.Enabled = true;
                txtTime.Text = "";
                txtTime.Enabled = false;
                cmbYMD2.SelectedIndex = 0;
                cmbYMD2.Enabled = false;
            }
            else
            {
                txtTimes.Text = "";
                txtTimes.Enabled = false;
                txtTime.Enabled = true;               
                cmbYMD2.Enabled = true;
                cmbYMD2.SelectedIndex = 1;
            }

        }

        private void ckbEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEnd.Checked)
            {
                panel3.Enabled = true;
            }
            else
            {
                panel3.Enabled = false;
            }
        }
        /// <summary>
        /// 添加执行科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecSecs_Click(object sender, EventArgs e)
        {
            frmSection sec = new frmSection(0);
            if ( txtExecSecs.Tag != null&&txtExecSecs.Tag.ToString() != "" )
                sec.SetSelected(txtExecSecs.Tag.ToString());
            sec.ShowDialog();
            txtExecSecs.Text = sec.GetNames();
            txtExecSecs.Tag = sec.GetIds();
        }
        /// <summary>
        /// 添加执行病区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExecSickAeras_Click(object sender, EventArgs e)
        {
            frmSection sec = new frmSection(1);
            if (txtExecSickAeras.Tag != null && txtExecSickAeras.Tag.ToString() != "")
                sec.SetSelected(txtExecSickAeras.Tag.ToString());
            sec.ShowDialog();
            txtExecSickAeras.Text = sec.GetNames();
            txtExecSickAeras.Tag = sec.GetIds();
        }




    }
}
