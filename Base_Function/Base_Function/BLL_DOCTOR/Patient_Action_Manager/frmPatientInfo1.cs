using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Bifrost_Doctor.CommonClass;
using Bifrost;
using Base_Function.BASE_COMMON;


namespace Base_Function.BLL_DOCTOR.Patient_Action_Manager
{
    public partial class frmPatientInfo1 : DevComponents.DotNetBar.Office2007Form
    {
        private InPatientInfo inpatient;
        /*
         *护理等级 
         */
        private string Sql_Nurse_Leavel = "select a.id,a.name from t_data_code a"+
                                          " inner join t_data_code_type b on a.type=b.id"+
                                          " where b.name='护理等级'";
        public frmPatientInfo1()
        {
            InitializeComponent();
        }
        public frmPatientInfo1(InPatientInfo inPatientInfo)
        {
            InitializeComponent();
            App.FormStytleSet(this, false);

            string Sql_section_Patient = "select * from t_in_patient where id='" + inPatientInfo.Id + "'";

            DataSet ds = App.GetDataSet(Sql_section_Patient);

            this.inpatient = DataInit.InitPatient(ds.Tables[0].Rows[0]);
            //this.inpatient = inPatientInfo;        

            this.Text = inpatient.Sick_Bed_Name + "-" + inpatient.Patient_Name + "-" + this.Text.Trim();
            //性别
            if (inpatient.Gender_Code == "0")
            {
                cbxSex.SelectedIndex = 2;
            }
            else if (inpatient.Gender_Code == "1")
            {
                cbxSex.SelectedIndex = 1;
            }
            else
            {
                cbxSex.SelectedIndex = 0;
            }
            DataTable dt = App.GetDataSet(Sql_Nurse_Leavel).Tables[0];
            DataRow newRow = dt.NewRow();
            newRow["id"] = -1;
            newRow["name"] = "请选择护理等级";
            dt.Rows.Add(newRow);
            foreach(DataRow row in dt.Rows)
            {
                ListItem item = new ListItem();
                item.Id = row["id"].ToString();
                item.Name = row["name"].ToString();
                cbxNurse_Leavel.Items.Add(item);
            }
            cbxNurse_Leavel.DisplayMember = "Name";
            cbxNurse_Leavel.ValueMember = "Id";
            cbxNurse_Leavel.Text = "请选择护理等级";
            cboCreer.SelectedIndex = 0;

            //省份
            dataBingProvince();
            //民族
            dataBindNational();
            cbxProvince.Text = "江苏省";
            cbxShi.Text = "淮安市";
            textBox5.Text = "金湖县";

            cbxNational.Text="汉族";
            cbxNationality.Text="中国";
           

            InitForm(inpatient);
            
            try
            {
                int year = App.GetSystemTime().Year - dtpBirth_Date.Value.Year;
                txtAge.Text = year.ToString();
                cbxAge_Unit.SelectedIndex = 0;
            }
            catch
            { }

            
        }

        private void frmPatientInfo_Load(object sender, EventArgs e)
        {
            txtPName.Text = inpatient.Patient_Name;
            //if (inpatient.Gender_Code != "")
            //    cbxSex.SelectedIndex =Convert.ToInt32(inpatient.Gender_Code);
            txtIn_Hospital_Time.Text = string.Format("{0:g}",inpatient.In_Time);
            #region 选中当前病人的护理等级
            if (inpatient.Nurse_Level != "")
            {
                for (int i = 0; i < cbxNurse_Leavel.Items.Count;i++)
                {
                    ListItem item = cbxNurse_Leavel.Items[i] as ListItem;
                    if(item.Id == inpatient.Nurse_Level)
                    {
                        cbxNurse_Leavel.SelectedItem = item;
                        break;
                    }
                }
            }
            #endregion
            if (inpatient.Sick_Degree=="病危")
            {
                btnAddIn_Danger.Enabled = false;
                btnAddIll.Enabled = false;
                btnStopIll.Enabled = false;
                btnStopIn_Danger.Enabled = true;
            }
            else if (inpatient.Sick_Degree == "病重")
            {
                btnAddIn_Danger.Enabled = false;
                btnAddIll.Enabled = false;
                btnStopIn_Danger.Enabled = false;
                btnStopIll.Enabled = true;
            }

          
            
        }
        //病危
        private void btnAddIn_Danger_Click(object sender, EventArgs e)
        {
            this.btnAddIn_Danger.Enabled = true;
            this.btnStopIn_Danger.Enabled = true;
            this.btnAddIll.Enabled = false;
            this.btnStopIll.Enabled = false;
            inpatient.Sick_Degree = "病危";
            try
            {
                //向质控临时表新增一条病危记录
                string strAge = string.Empty;
                if (App.IsNumeric(inpatient.Age))
                {
                    strAge = inpatient.Age;
                }
                string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,age)" +
                                        " values('" + inpatient.PId + "','病危',sysdate,'" + strAge + "')";
                App.ExecuteSQL(InsertJob_Temp);
            }
            catch (Exception)
            {
            }
        }

        private void btnAddIll_Click(object sender, EventArgs e)
        {
            this.btnAddIn_Danger.Enabled = false;
            this.btnStopIn_Danger.Enabled = false;
            this.btnAddIll.Enabled = true;
            this.btnStopIll.Enabled = true;
            inpatient.Sick_Degree = "病重";
            try
            {
                string strAge = string.Empty;
                if (App.IsNumeric(inpatient.Age))
                {
                    strAge = inpatient.Age;
                }
                //向质控临时表新增一条病危记录
                string InsertJob_Temp = "insert into t_job_temp(pid,operate_type,operate_time,age)" +
                                        " values('" + inpatient.PId + "','病重',sysdate,'" + strAge + "')";
                App.ExecuteSQL(InsertJob_Temp);
            }
            catch (Exception)
            {
            }
        }
        //停止病危医嘱
        private void btnStopIn_Danger_Click(object sender, EventArgs e)
        {
            this.btnAddIn_Danger.Enabled = true;
            this.btnAddIll.Enabled = true;
            this.btnStopIn_Danger.Enabled = false;
            this.btnStopIll.Enabled = false;
            inpatient.Sick_Degree = "一般";
        }
        //停止病重医嘱

        private void btnStopIll_Click(object sender, EventArgs e)
        {
            this.btnAddIn_Danger.Enabled = true;
            this.btnAddIll.Enabled = true;
            this.btnStopIn_Danger.Enabled = false;
            this.btnStopIll.Enabled = false;
            inpatient.Sick_Degree = "一般";
        }
        //修改当前病人的病危程度和护理等级
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
             {
	            ListItem SelectItem = cbxNurse_Leavel.SelectedItem as ListItem;
                //住院次数
                //string in_Count = txtIn_Count.Text;
                //姓名
                string name = txtPName.Text;
                //性别
                string sex = "";
                if (cbxSex.SelectedIndex == 1)
                {
                    sex = "0";
                }
                else if ( cbxSex.SelectedIndex ==  2)
                {
                    sex = "1"
                   ;
                }
                //婚姻状态
                string marrige_State = "";
                if (cbxMarred.SelectedIndex == 1) //未婚
                {
                    marrige_State="0";
                }
                else if (cbxMarred.SelectedIndex == 2)  //已婚
                {
                    marrige_State = "1";
                }
                //住院次数
                string in_Count = txtIn_Count.Text;
                //身份证号
                string medicare_no = txtId_Number.Text;
                //出生日期
                string birth_Date = dtpBirth_Date.Value.ToString("yyyy-MM-dd HH:mm");
                //年龄
                string age = txtAge.Text;
                //年龄单位
                string age_Unit = cbxAge_Unit.Text;
                //民族
                string national= cbxNational.SelectedValue.ToString();
                //国籍
               string nationallity = cbxNationality.Text;
                //出生地 省份            
               string province = cbxProvince.Text;
                //县
               string xian = cbxShi.Text;
                //工作单位及地址
                string office_Address = txtWorkAddress.Text;
                //电话
                string office_Phone = txtOffice_Phone.Text;
                string officepos_code=txtOffice_Post.Text;
                //户口地址
                string home_Address = txtAccountAddress.Text;
                //邮政编码
                string home_Post = txtHome_Post.Text;
                //联系人地址
                string relation_Address = txtContactAddress.Text;
                string relation = null;
                //联系人姓名
                string relationname = txtRelationName.Text;
                //职业
                string creer = cboCreer.Text;
                if (cbxRelationship.SelectedIndex != 0)
                {
                    //关系
                    relation = cbxRelationship.Text;
                }
                //电话
                string relation_Phone = txtRelation_Phone.Text;
                //住院时间
                string in_Time = txtIn_Hospital_Time.Text;
                //付款方式
                string pay_Mothod = "";
                if(cbxPay.SelectedIndex!=0)
                {
                    pay_Mothod = cbxPay.SelectedIndex.ToString();
                }
                if (SelectItem.Name != "请选择护理等级")
                    inpatient.Nurse_Level = SelectItem.Id;
                //if (inpatient.Nurse_Level != "请选择护理等级" &&
                //   inpatient.Sick_Degree != "" && inpatient.PId != "")
                //{
                /*
                 *修改患者的信息 
                 */
                string sql_Update_Inpatient = "update t_in_patient set patient_name='" + name + "',age_Unit ='" + age_Unit + "',age =" + age + ",nurse_level='" + inpatient.Nurse_Level + "'," +
                                              " Sick_Degree='" + inpatient.Sick_Degree + "',Marriage_State='" + marrige_State + "',Home_Address='" + home_Address + "'," +
                                              " Homepostal_Code='" + home_Post + "',Office='" + office_Address + "',Office_Address='" + office_Address + "'," +
                                              " Office_Phone='" + office_Phone + "',OFFICEPOS_CODE='" + officepos_code + "',Relation='" + relation + "',gender_code='" + sex + "'," +
                                              " Relation_Address='" + relation_Address + "',Relation_Phone='" + relation_Phone + "',InHospital_Count=" + in_Count + "," +
                                              " medicare_no='" + medicare_no + "',Pay_Manner='" + pay_Mothod + "',IN_Circs='" + cbxIn_Cirs.Text + "',native_place='" + nationallity + "',BIRTHDAY=to_date('" + dtpBirth_Date.Value.ToShortDateString() + "','yyyy-MM-dd')," +
                                              " Birth_Place='" + province + "," + xian + "," + textBox5.Text + "',Folk_Code=" + national + ",Career='"+creer+"',Relation_Name='"+relationname+"' where pid='" + inpatient.PId + "'";
                //string sql_Update_Inpatient = "";
                //if (age == "" && age_Unit == "")
                //{
                //    sql_Update_Inpatient = "update t_in_patient set patient_name='" + name + "',Sick_Degree='" + inpatient.Sick_Degree + "'," +
                //                           " nurse_level='" + inpatient.Nurse_Level + "',gender_code='" + sex + "',Marriage_State='" + marrige_State + "'  where pid='" + inpatient.PId + "'";
                //}
                //else
                //{
                //    sql_Update_Inpatient = "update t_in_patient set patient_name='" + name + "',Sick_Degree='" + inpatient.Sick_Degree + "'," +
                //                               " nurse_level='" + inpatient.Nurse_Level + "',age_Unit ='" + age_Unit + "',age =" + age + ",gender_code='" + sex + "',Marriage_State='" + marrige_State + "'  where pid='" + inpatient.PId + "'";
                //}
                    int count = App.ExecuteSQL(sql_Update_Inpatient);
                    if (count > 0)
                    {
                        DataInit.isInAreaSucceed = true;
                        inpatient.Patient_Name = name;
                        inpatient.Gender_Code = sex;
                        if (age != "" && age_Unit != "")
                        {
                            inpatient.Age =age.ToString();
                            inpatient.Age_unit= age_Unit;
                        }
                        App.Msg("操作成功！");

                        
                        
                    }
                //}
                //else
                //{
                //    App.Msg("请您选择护理等级和遗嘱！");
                //}
             }
             catch (System.Exception ex)
             {
             	
             }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void InitForm(InPatientInfo inpat)
        {
            //if (inpat.Pay_Manager != "")
            //{
            //    //付款方式
            //    cbxPay.SelectedIndex = Convert.ToInt32(inpat.Pay_Manager);
            //}
            //else
            //{
            //    cbxPay.SelectedIndex = 0;
            //}
            try
            {
                cbxPay.SelectedIndex = Convert.ToInt32(inpat.Pay_Manager);
            }
            catch
            {
                cbxPay.SelectedIndex = 0;
            }
            //cbxPay.Text = inpat.Pay_Manager;
            //住院次数
            txtIn_Count.Text = inpat.InHospital_count.ToString();
            if (txtIn_Count.Text.Trim() == "" || txtIn_Count.Text.Trim() == "0")
            {
                txtIn_Count.Text = "1";
            }


            //姓名
            txtPName.Text = inpat.Patient_Name;
            //性别
            if(inpat.Gender_Code=="0")
            {
                cbxSex.SelectedIndex = 1;
            }
            else if (inpat.Gender_Code == "1")
            {
                cbxSex.SelectedIndex = 2;
            }
            else
            {
                cbxSex.SelectedIndex = 0;
            }
            //婚姻状态
            if (inpat.Marrige_State == "0") //未婚
            {
                cbxMarred.SelectedIndex = 1;
            }
            else if (inpat.Marrige_State == "1")  //已婚
            {
                cbxMarred.SelectedIndex = 2;
            }
            else
            {
                cbxMarred.SelectedIndex = 0;
            }
            //身份证号
            txtId_Number.Text = inpat.Medicare_no;
            if (inpat.Birthday!=null)
              dtpBirth_Date.Value =Convert.ToDateTime(inpat.Birthday); 
            //年龄
            txtAge.Text = inpat.Age.ToString();
            //年龄单位
            cbxAge_Unit.Text = inpat.Age_unit;
            //民族
            if (inpat.Folk_code != "")
            {
                cbxNational.SelectedValue = inpat.Folk_code;
                if (cbxNational.SelectedValue == null)
                {
                    cbxNational.Text = "汉族";
                }
            }
            //国籍
            cbxNationality.Text  = inpat.Natiye_place;
            //出生地 省份   
            if (inpat.Birth_place != "")
                cbxProvince.Text = inpat.Birth_place.Split(',')[0];
            dataBindShi(cbxProvince.SelectedValue);
            //县
            if (inpat.Birth_place!="")
                cbxShi.Text = inpat.Birth_place.Split(',')[1];
            try
            {
                textBox5.Text = inpat.Birth_place.Split(',')[2];
            }
            catch
            { }
            //工作单位及地址
            txtWorkAddress.Text = inpat.Office_address;

            this.txtOffice_Phone.Text = inpat.Office_phone;
            this.txtOffice_Post.Text = inpat.OfficePos_code;
            //户口地址
            txtAccountAddress.Text = inpat.Home_address;
            //邮政编码
            txtHome_Post.Text = inpat.HomePostal_code;
            //联系人地址
            txtContactAddress.Text = inpat.Relation_address;
            if (inpat.Relation.ToString() != "")
            {
                //关系
                cbxRelationship.Text = inpat.Relation;
            }
            else
            {
                cbxRelationship.SelectedIndex = 0;
            }
            //职业
            try
            {
                cboCreer.Text = inpat.Career;
            }
            catch
            { cboCreer.SelectedIndex = 0; }

            //联系人姓名
            txtRelationName.Text = inpat.Relation_name;
            cbxIn_Cirs.Text = inpat.In_Circs;

            //电话
            txtRelation_Phone.Text = inpat.Relation_phone;
            //住院时间
            txtIn_Hospital_Time.Text = inpat.In_Time.ToString("yyyy-MM-dd HH:mm") ;
        }

        //绑定省份
        private void dataBingProvince()
        {
            try
            {
                string sql = " select id,name from t_data_code_type where id between 72 and 106";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    cbxProvince.DisplayMember = "name";
                    cbxProvince.ValueMember = "id";
                    cbxProvince.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 根据省查找市
        /// </summary>
        /// <param name="id"></param>
        private void dataBindShi(object id)
        {
            try
            {
                string sql = " select id,name from t_data_code where type='"+id+"'";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    cbxShi.DisplayMember = "name";
                    cbxShi.ValueMember = "id";
                    cbxShi.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception)
            {
            }
        }

        private void cbxProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataBindShi(cbxProvince.SelectedValue);
        }
        private void dataBindNational()
        {
            try
            {
                string sql = " select id,name from t_data_code where type='71' order by case  when name='汉族' then 0 else 1 end,code";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    cbxNational.DisplayMember = "name";
                    cbxNational.ValueMember = "id";
                    cbxNational.DataSource = ds.Tables[0].DefaultView;
                }
            }
            catch (Exception)
            {
            }
        }

        private void chbReadonly_CheckedChanged(object sender, EventArgs e)
        {
            if (chbReadonly.Checked)
            {
                IsReadOnly(false);
            }
            else
            {
                IsReadOnly(true);
            }
        }
        /// <summary>
        /// 是否只读
        /// </summary>
        /// <param name="IsRead"></param>
        private void IsReadOnly(bool IsRead)
        {
            cbxPay.Enabled = IsRead;
            txtPName.Enabled = IsRead;
            txtIn_Count.Enabled = IsRead;
            cbxSex.Enabled = IsRead;
            cbxMarred.Enabled = IsRead;
            txtId_Number.Enabled = IsRead;
            dtpBirth_Date.Enabled = IsRead;
            txtAge.Enabled = IsRead;
            cbxAge_Unit.Enabled = IsRead;
            textBox4.Enabled = IsRead;
            cbxNational.Enabled = IsRead;
            cbxNationality.Enabled = IsRead;
            cbxProvince.Enabled = IsRead;
            cbxShi.Enabled = IsRead;
            textBox5.Enabled = IsRead;
            txtWorkAddress.Enabled = IsRead;
            txtOffice_Phone.Enabled = IsRead;
            txtOffice_Post.Enabled = IsRead;
            txtAccountAddress.Enabled = IsRead;
            txtHome_Post.Enabled = IsRead;
            txtContactAddress.Enabled = IsRead;
            cbxRelationship.Enabled = IsRead;
            txtRelation_Phone.Enabled = IsRead;
            txtIn_Hospital_Time.Enabled = IsRead;
            txtDiagnostic.Enabled = IsRead;
            cbxNurse_Leavel.Enabled = IsRead;
            cbxIn_Cirs.Enabled = IsRead;
        }

        private ListItem GetItem(string code)
        { 
            ListItem tempItem=new ListItem();
            for(int i=0;i<cbxSex.Items.Count;i++)
            {
                ListItem item = cbxSex.Items[i] as ListItem;
                if (item.Name == code)
                {
                    tempItem = cbxSex.Items[i] as ListItem;
                    break;
                }
            }
            return tempItem;
        }

        private void dtpBirth_Date_ValueChanged(object sender, EventArgs e)
        {
          int year =App.GetSystemTime().Year- dtpBirth_Date.Value.Year;
          txtAge.Text = year.ToString();
          cbxAge_Unit.SelectedIndex = 0;
        }
    }
}