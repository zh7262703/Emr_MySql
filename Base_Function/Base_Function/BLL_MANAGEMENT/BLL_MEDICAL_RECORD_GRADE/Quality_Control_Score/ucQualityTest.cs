using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class ucQualityTest : UserControl
    {
        string type = "";
        public ucQualityTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="strTpye">D：医生自评；S：科室自评；H：院级；E：终末；M：病历评分</param>
        public ucQualityTest(string strTpye)
        {
            InitializeComponent();
            type = strTpye;
            DataInit.SetDoubleBuffered(this.tableLayoutPanel1, true);
        }

        /// <summary>
        /// 界面初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucLinkQuality_Load(object sender, EventArgs e)
        {
            cmbPatiState_Data();
            GetAllSection_Name();

            NurseLevelInit();
            PayManagerInit();
            PatientCaseInit();
            SpecialPatInit();

            cbxTimeType.SelectedIndex = 0;
            cbxScoreCondition.SelectedIndex = 0;
        }

        /// <summary>
        /// 护理等级初始化
        /// </summary>
        private void NurseLevelInit()
        {
            string sql_NurseLevel = "select t.id,t.name from t_data_code t where t.type = 53 and t.enable = 'Y'";

            DataSet ds_NurseLevel = App.GetDataSet(sql_NurseLevel);
            //插入默认选项（请选择）
            if (ds_NurseLevel != null)
            {
                DataRow dr = ds_NurseLevel.Tables[0].NewRow();
                dr["id"] = 0;
                dr["name"] = "请选择";
                ds_NurseLevel.Tables[0].Rows.InsertAt(dr, 0);
            }
            cbxNurseLevel.DataSource = ds_NurseLevel.Tables[0];
            cbxNurseLevel.DisplayMember = "name";
            cbxNurseLevel.ValueMember = "id";
        }

        /// <summary>
        /// 医疗付款方式初始化
        /// </summary>
        private void PayManagerInit()
        {
            string sql_PayManager = "select t.code,t.name from t_data_code t where t.type = 70 and t.enable = 'Y'";

            DataSet ds_PayManager = App.GetDataSet(sql_PayManager);
            //插入默认选项（请选择）
            if (ds_PayManager != null)
            {
                DataRow dr = ds_PayManager.Tables[0].NewRow();
                dr["code"] = 0;
                dr["name"] = "请选择";
                ds_PayManager.Tables[0].Rows.InsertAt(dr, 0);
            }
            cbxPayManner.DataSource = ds_PayManager.Tables[0];
            cbxPayManner.DisplayMember = "name";
            cbxPayManner.ValueMember = "code";
        }

        /// <summary>
        /// 病情初始化
        /// </summary>
        private void PatientCaseInit()
        {
            string sql_PatientCase = "select t.code,t.name from t_data_code t where t.type = 133 and t.enable = 'Y'";

            DataSet ds_PatientCase = App.GetDataSet(sql_PatientCase);
            //插入默认选项（请选择）
            if (ds_PatientCase != null)
            {
                DataRow dr = ds_PatientCase.Tables[0].NewRow();
                dr["code"] = 0;
                dr["name"] = "请选择";
                ds_PatientCase.Tables[0].Rows.InsertAt(dr, 0);
            }
            cbxCondition.DataSource = ds_PatientCase.Tables[0];
            cbxCondition.DisplayMember = "name";
            cbxCondition.ValueMember = "code";
        }

        /// <summary>
        /// 特殊患者
        /// </summary>
        private void SpecialPatInit()
        {
            string sql_SpecialPat = "select t.code,t.name from t_data_code t where t.type = 10946362 and t.enable = 'Y'";

            DataSet ds_SpecialPat = App.GetDataSet(sql_SpecialPat);
            //插入默认选项（请选择）
            if (ds_SpecialPat != null)
            {
                DataRow dr = ds_SpecialPat.Tables[0].NewRow();
                dr["code"] = 0;
                dr["name"] = "请选择";
                ds_SpecialPat.Tables[0].Rows.InsertAt(dr, 0);
            }
            cbxSpecialPat.DataSource = ds_SpecialPat.Tables[0];
            cbxSpecialPat.DisplayMember = "name";
            cbxSpecialPat.ValueMember = "code";
        }



        /// <summary>
        /// 病人状态下拉框
        /// </summary>
        private void cmbPatiState_Data()
        {
            if (type != "M")
            {
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("id");
                DataColumn dc2 = new DataColumn("name");
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);

                DataRow dr1 = dt.NewRow();
                dr1["id"] = "0";
                dr1["name"] = "出院未归档";

                DataRow dr2 = dt.NewRow();
                dr2["id"] = "1";
                dr2["name"] = "已归档";

                DataRow dr3 = dt.NewRow();
                dr3["id"] = "2";
                dr3["name"] = "在院";

                //终末和病历评分只能查已归档的
                if (type == "E")
                {
                    dt.Rows.Add(dr2);
                    cmbPatiState.Enabled = false;
                }
                else
                {
                    dt.Rows.Add(dr1);
                    if (type == "H")
                    {
                        dt.Rows.Add(dr3);
                    }
                    //cmbPatiState.Enabled = false;
                }

                cmbPatiState.DataSource = dt;
                cmbPatiState.ValueMember = "id";
                cmbPatiState.DisplayMember = "name";
                cmbPatiState.SelectedIndex = 0;
            }
            else//病历评分权限，病人状态更改
            {
                DataTable dt = new DataTable();
                DataColumn dc1 = new DataColumn("id");
                DataColumn dc2 = new DataColumn("name");
                dt.Columns.Add(dc1);
                dt.Columns.Add(dc2);

                DataRow dr1 = dt.NewRow();
                dr1["id"] = "0";
                dr1["name"] = "全部";

                DataRow dr2 = dt.NewRow();
                dr2["id"] = "1";
                dr2["name"] = "未评分";

                DataRow dr3 = dt.NewRow();
                dr3["id"] = "2";
                dr3["name"] = "暂存";

                DataRow dr4 = dt.NewRow();
                dr4["id"] = "3";
                dr4["name"] = "已评分";

                dt.Rows.Add(dr1);
                dt.Rows.Add(dr3);
                dt.Rows.Add(dr2);
                dt.Rows.Add(dr4);

                cmbPatiState.DataSource = dt;
                cmbPatiState.ValueMember = "id";
                cmbPatiState.DisplayMember = "name";
                cmbPatiState.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 科室下拉框
        /// </summary>
        private void GetAllSection_Name()
        {
            DataSet ds = new DataSet();
            string sql = "select sID,Section_Name from t_sectioninfo where enable_flag='Y' order by section_name";
            ds = App.GetDataSet(sql);

            DataRow dr = ds.Tables[0].NewRow();
            dr["sid"] = "0";
            dr["Section_Name"] = "全院";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            cmbSection.DataSource = ds.Tables[0].DefaultView;
            cmbSection.DisplayMember = "Section_Name";
            cmbSection.ValueMember = "sID";

            //科室自评和医生自评只能查本科室的
            if (App.UserAccount.CurrentSelectRole.Section_Id != null)
            {
                if (!string.IsNullOrEmpty(App.UserAccount.CurrentSelectRole.Section_Id) && (type == "D" || type == "S"))
                {
                    cmbSection.SelectedValue = App.UserAccount.CurrentSelectRole.Section_Id;
                    cmbSection.Enabled = false;
                }
            }
        }

        /// <summary>
        /// 查询按钮触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSerch_Click(object sender, EventArgs e)
        {
            DataShow();
        }

        private void DataShow()
        {
            string strSql = " select distinct a.id as 编号,''质控标识,aa.STATE," +//regexp_substr(a.his_id,'[^-]+',1,1) as 病人id,
                                "a.pid as 住院号,a.inhospital_count as 住院次数,a.patient_name as 患者姓名, (case when a.gender_code='1'then '男'else  '女' end) as 性别," +
                                "a.age||a.age_unit||a.child_age as 年龄,a.section_name as 科室, a.sick_doctor_name as 管床医生," +
                                "t.diagnose_name as 诊断," +
                                "to_char(a.in_time, 'yyyy-MM-dd HH24:mi') as 入院日期, to_char(a.die_time, 'yyyy-MM-dd HH24:mi') as " +
                                "出院日期, (select name from t_data_code where type='70'and code=a.pay_manner) as 医保类型," +
                                "t2.质控科室,t2.质控人员,t2.最后质控日期,to_char(aa.score) 分数,t2.type " +
                                "from T_IN_Patient a left join t_deduct_summary aa on a.id=aa.PATIENT_ID left join " +     //这个是获取的入院记录里的诊断   最好是在代码里修改 应该效率会好一些
                                "(select distinct patient_id,diagnose_name, diagnose_type, rn from (select patient_id,diagnose_name,diagnose_type," +
                                "row_number() over(partition by patient_id order by decode(diagnose_sort,diagnose_type,'406',1,'407',2,'405',3,'7923',4,'404',5,'403',6)) as rn " +
                                "from t_diagnose_item) where rn = 1) t on  a.id = t.patient_id left join (select patient_id,to_char(record_time,'yyyy-MM-dd HH24:mi') as " +
                                "最后质控日期,USER_NAME " +
                                "as 质控人员,user_section as 质控科室,type,rn from (select c.patient_id,c.record_time,c.user_section,c.USER_NAME,c.type,row_number() " +
                                "over(partition by patient_id order by id desc) as rn from T_MEDICAL_RECORD c) c1 " +
                               "where rn=1) t2 on a.id=t2.patient_id where 1=1";
            //管理员不允许查看医生自评
            if (cmbSection.SelectedValue == null)
            {
                return;
            }


            if (txtPid.Text != "")//住院号模糊查询
            {
                strSql += " and a.pid like '%" + txtPid.Text.Trim() + "%'";
            }
            if (txtName.Text != "")//按病人姓名查询
            {
                strSql += " and a.patient_name like '" + txtName.Text.Trim() + "%'";
            }
            if (txtDiagnoseName.Text != "")
            {
                strSql += " and t.diagnose_name like '%" + txtDiagnoseName.Text + "%'";
            }

            if (cbxPayManner.Text != "请选择")
            {
                strSql += " and a.pay_manner='" + cbxPayManner.SelectedValue.ToString() + "'";
            }
            if (cbxNurseLevel.Text != "请选择")
            {
                strSql += " and a.nurse_level='" + cbxNurseLevel.SelectedValue.ToString() + "'";
            }
            if (cbxCondition.Text != "请选择")
            {
                strSql += " and a.sick_degree='" + cbxCondition.Text + "'";
            }
            if (cbxSpecialPat.Text != "请选择")
            {
                switch (cbxSpecialPat.SelectedValue.ToString())
                {
                    case "0":
                        strSql += " and a.in_time >= sysdate-3";
                        break;
                    case "1":
                        break;
                    case "2":
                        strSql += " and a.die_flag = 1";
                        break;
                    case "3":
                        break;
                }
                //strSql += " and a.pay_manner='" + cbxSpecialPat.SelectedValue.ToString() + "'";
            }

            if (chkScore.Checked == true && !string.IsNullOrEmpty(tbxScore.Text.Trim()))
            {
                int score = Convert.ToInt32(tbxScore.Text.Trim());
                switch (cbxScoreCondition.Text)
                {
                    case "大于":
                        strSql += " and aa.score > " + score + " ";
                        break;
                    case "等于":
                        strSql += " and aa.score = " + score + " ";
                        break;
                    case "小于":
                        strSql += " and aa.score < " + score + " ";
                        break;
                }
            }


            //科室下拉框-全院
            if (cmbSection.SelectedValue.ToString() != "0")
            {
                strSql += " and a.section_id='" + cmbSection.SelectedValue.ToString() + "'";
            }
            if (chkTime.Checked == true)
            {
                strSql += " and to_char(a.in_time,'yyyy-MM-DD')>='" + dtpInTime1.Value.ToString("yyyy-MM-dd") + "' and to_char(a.in_time,'yyyy-MM-DD')<='" + dtpIntime2.Value.ToString("yyyy-MM-dd") + "'";
            }
            #region 带在院状态 作废
            //if (type != "M")//病历评分权限病人状态下拉框集合不一样
            //{
            //    //病人状态
            //    if (cmbPatiState.SelectedValue.ToString() == "0")//全部
            //    {
            //        if (cmbPatiState.Items.Count < 4)//不可选已归档的
            //        {
            //            strSql += " and a.document_state is null";
            //        }
            //    }
            //    else if (cmbPatiState.SelectedValue.ToString() == "1")//在院
            //    {
            //        strSql += " and a.die_time is null";
            //    }
            //    else if (cmbPatiState.SelectedValue.ToString() == "2")//出院未归档
            //    {
            //        strSql += " and a.die_time is not null and a.document_state is null";
            //    }
            //    else if (cmbPatiState.SelectedValue.ToString() == "3")//已归档
            //    {
            //        int returnDay = Convert.ToInt32(App.ReadSqlVal("select DOCUMENT_DAYS from T_GRADE_PARAM_SHEZHI", 0, "DOCUMENT_DAYS"));
            //        strSql += " and (a.document_state is not null or a.LEAVE_TIME<=sysdate-" + returnDay + " or a.DIE_TIME<=sysdate-" + returnDay + ")";//归档退回也需要查询出来
            //    }
            //}
            #endregion
            if (type != "M")//病历评分权限病人状态下拉框集合不一样
            {
                //病人状态
                if (cmbPatiState.SelectedValue.ToString() == "0")//出院未归档
                {
                    strSql += " and a.die_time is not null and a.document_state is null";
                }
                else if (cmbPatiState.SelectedValue.ToString() == "1")//已归档
                {
                    int returnDay = Convert.ToInt32(App.ReadSqlVal("select DOCUMENT_DAYS from T_GRADE_PARAM_SHEZHI", 0, "DOCUMENT_DAYS"));
                    strSql += " and (a.document_state is not null or a.LEAVE_TIME<=sysdate-" + returnDay + " or a.DIE_TIME<=sysdate-" + returnDay + ")";//归档退回也需要查询出来
                }
                else if (cmbPatiState.SelectedValue.ToString() == "2")//在院
                {
                    strSql += " and a.die_time is null and a.document_state is null";
                }
            }

            #region 评分权限，查询不到无评分权限患者，院级不涉及到权限

            //医生自评-限制管床病人、只能看见没有评分的病人（自评暂存不算）
            if (type == "D") { strSql += " and a.sick_doctor_id='" + App.UserAccount.UserInfo.User_id.ToString() + "' and aa.STATE is null"; }
            //科室评分只能看见医生自评结束
            else if (type == "S") { strSql += " and aa.STATE='D'"; }
            //终末评分只能看见科室自评结束
            else if (type == "E") { strSql += " and aa.STATE='S'"; }
            //病历评分只能看见终末自评结束
            else if (type == "M")
            {
                if (cmbPatiState.SelectedValue.ToString() == "0")//全部
                    strSql += " and (aa.STATE='E' or aa.state='M')";
                else if (cmbPatiState.SelectedValue.ToString() == "1")//未评分
                    strSql += " and aa.STATE='E' and t2.type<>'M'";
                else if (cmbPatiState.SelectedValue.ToString() == "2")//暂存
                    strSql += " and aa.STATE='E' and t2.type='M'";
                else if (cmbPatiState.SelectedValue.ToString() == "3")//已评分
                    strSql += " and aa.STATE='M'";
            }

            #endregion

            strSql += " order by 科室";
            //TODO
            DataSet dsData = App.GetDataSet(strSql);
            //DataColumn dc = new DataColumn("质控标识", typeof(Bitmap));
            //dsData.Tables[0].Columns.Add(dc);
            if (dsData != null)
            {
                //if (dsData.Tables[0].Rows.Count > 0)
                //{                    
                dgvPatient.DataSource = dsData.Tables[0].DefaultView;

                dgvPatient.Columns["编号"].Visible = false;
                dgvPatient.Columns["type"].Visible = false;
                dgvPatient.Columns["state"].Visible = false;
                if (type != "M") { dgvPatient.Columns["分数"].Visible = false; }  //病历评分显示分数列              
                dgvPatient.Columns["质控标识"].DisplayIndex = 0;

                //质控标识图标
                for (int i = 0; i < dgvPatient.Rows.Count; i++)
                {
                    if (string.IsNullOrEmpty(dgvPatient.Rows[i].Cells["type"].Value.ToString().Trim()))//未质控
                    {
                        //dgvPatient.Rows[i].Cells["质控标识"].Value = global::Base_Function.Resource.日;
                        dgvPatient.Rows[i].Cells["质控标识"].Value = "";
                    }
                    else if (dgvPatient.Rows[i].Cells["type"].Value.ToString().Trim() == "D")//自评
                    {
                        //dgvPatient.Rows[i].Cells["质控标识"].Value = global::Base_Function.Resource.日;
                        dgvPatient.Rows[i].Cells["质控标识"].Value = "医生自评";
                    }
                    else if (dgvPatient.Rows[i].Cells["type"].Value.ToString().Trim() == "S")//科室
                    {
                        //dgvPatient.Rows[i].Cells["质控标识"].Value = global::Base_Function.Resource.月亮;
                        dgvPatient.Rows[i].Cells["质控标识"].Value = "科室自评";
                    }
                    else if (dgvPatient.Rows[i].Cells["type"].Value.ToString().Trim() == "H")//院级
                    {
                        //dgvPatient.Rows[i].Cells["质控标识"].Value = global::Base_Function.Resource.星星;
                        dgvPatient.Rows[i].Cells["质控标识"].Value = "院级评分";
                    }
                    else if (dgvPatient.Rows[i].Cells["type"].Value.ToString().Trim() == "E")//终末
                    {
                        //dgvPatient.Rows[i].Cells["质控标识"].Value = global::Base_Function.Resource.星星;
                        dgvPatient.Rows[i].Cells["质控标识"].Value = "终末质控";
                    }
                    else if (dgvPatient.Rows[i].Cells["type"].Value.ToString().Trim() == "M")//病历评分
                    {
                        //dgvPatient.Rows[i].Cells["质控标识"].Value = global::Base_Function.Resource.星星;
                        dgvPatient.Rows[i].Cells["质控标识"].Value = "质控评分";
                    }
                    if (type == "M")//病历评分权限，病人状态为全部，用颜色区分
                    {
                        if (dgvPatient.Rows[i].Cells["type"].Value.ToString().Trim() != "M" && dgvPatient.Rows[i].Cells["STATE"].Value.ToString().Trim() == "E")//未评分
                        {
                            if (cmbPatiState.SelectedValue.ToString() == "0")
                                dgvPatient.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
                            dgvPatient.Rows[i].Cells["分数"].Value = "";//暂存和未评分，分数列值为空
                        }
                        else if (dgvPatient.Rows[i].Cells["type"].Value.ToString().Trim() == "M" && dgvPatient.Rows[i].Cells["STATE"].Value.ToString().Trim() == "E")//暂存
                        {
                            if (cmbPatiState.SelectedValue.ToString() == "0")
                                dgvPatient.Rows[i].DefaultCellStyle.BackColor = Color.PaleTurquoise;
                            dgvPatient.Rows[i].Cells["分数"].Value = "";
                        }
                        else if (dgvPatient.Rows[i].Cells["STATE"].Value.ToString().Trim() == "M")//已评分
                        {
                            if (cmbPatiState.SelectedValue.ToString() == "0")
                                dgvPatient.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        }

                    }
                    dgvPatient.ClearSelection();
                }
                //}
            }
        }

        /// <summary>
        /// 双击表格数据事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //行标题和列标题
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    DataTable dtLocked = App.GetDataSet("select USER_NAME,user_id,type,IP from T_quality_locked where PATIENT_ID='" + dgvPatient.Rows[e.RowIndex].Cells["编号"].Value.ToString() + "'").Tables[0];
                    if (dtLocked.Rows.Count > 0)
                    {
                        if (dtLocked.Rows[0]["user_id"].ToString() != App.UserAccount.UserInfo.User_id.ToString() || dtLocked.Rows[0]["IP"].ToString() != App.GetHostIp())
                        {
                            string typeName = "";
                            switch (type)
                            {
                                case "D":
                                    typeName = "医生自评";
                                    break;
                                case "S":
                                    typeName = "科室自评";
                                    break;
                                case "H":
                                    typeName = "全院质控";
                                    break;
                                case "E":
                                    typeName = "终末质控";
                                    break;
                                case "M":
                                    typeName = "病历评分";
                                    break;
                            }
                            if (!App.Ask("" + dtLocked.Rows[0]["USER_NAME"].ToString() + "老师正在对该患者进行评分，权限为：" + typeName + "，操作电脑IP:" +
                                     dtLocked.Rows[0]["IP"].ToString() + "，是否继续？"))
                            { return; }
                        }
                    }
                    //是否质控结束 仅供查看
                    string strIsRead = "N";
                    if (dgvPatient.Rows[e.RowIndex].Cells["STATE"].Value.ToString().Trim() == "M" && type == "M")
                    {
                        strIsRead = "Y";
                    }

                    frmQualityChild frm = new frmQualityChild(dgvPatient.Rows[e.RowIndex].Cells["编号"].Value.ToString(),
                      dgvPatient.Rows[e.RowIndex].Cells["质控人员"].Value.ToString(),
                      dgvPatient.Rows[e.RowIndex].Cells["质控科室"].Value.ToString(),
                      dgvPatient.Rows[e.RowIndex].Cells["最后质控日期"].Value.ToString(), type, strIsRead);
                    frm.Name = dgvPatient.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                    frm.Refresh += new frmQualityChild.RefEventHandler(DataShow);
                    //判断该病人窗体是否已经打开
                    FormCollection fc = Application.OpenForms;
                    if (fc[dgvPatient.Rows[e.RowIndex].Cells["编号"].Value.ToString()] != null)
                    {
                        (fc[dgvPatient.Rows[e.RowIndex].Cells["编号"].Value.ToString()] as Form).Focus();
                    }
                    else
                    {
                        if (strIsRead != "Y")
                        {
                            //评分加锁                   
                            App.ExecuteSQL("insert into T_quality_locked t (t.USER_ID,t.USER_NAME,t.PATIENT_ID,t.type,IP,t.LOCKTIME) values('" + App.UserAccount.UserInfo.User_id.ToString() +
                                             "','" + App.UserAccount.UserInfo.User_name.ToString() + "','" +
                                             dgvPatient.Rows[e.RowIndex].Cells["编号"].Value.ToString() + "','" + type + "','" + App.GetHostIp() + "',sysdate)");
                        }
                        frm.ShowDialog();
                    }

                }
            }
            catch { }
        }

        /// <summary>
        /// 行标题序列号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPatient_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

        /// <summary>
        /// 入院日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked)
            {
                cbxTimeType.Enabled = true;
                dtpInTime1.Enabled = true;
                dtpIntime2.Enabled = true;
            }
            else
            {
                cbxTimeType.Enabled = false;
                dtpInTime1.Enabled = false;
                dtpIntime2.Enabled = false;
            }
        }

        private void chkScore_CheckedChanged(object sender, EventArgs e)
        {
            if (chkScore.Checked)
            {
                cbxScoreCondition.Enabled = true;
                tbxScore.Enabled = true;
            }
            else
            {
                cbxScoreCondition.Enabled = false;
                tbxScore.Enabled = false;
            }
        }

        /// <summary>
        /// 只能输入正实数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            txtPid.Text = "";
            txtName.Text = "";
            txtDiagnoseName.Text = "";
            tbxScore.Text = "";

            cbxPayManner.SelectedIndex = 0;
            cbxNurseLevel.SelectedIndex = 0;
            cbxSpecialPat.SelectedIndex = 0;
            cbxTimeType.SelectedIndex = 0;
            cbxCondition.SelectedIndex = 0;
            cbxScoreCondition.SelectedIndex = 0;
            cmbPatiState.SelectedIndex = 0;
        }


    }
}
