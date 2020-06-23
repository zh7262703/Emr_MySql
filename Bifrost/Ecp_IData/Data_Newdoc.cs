using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
//using DataOperater;
using System.Data.OracleClient;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Services;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
namespace Bifrost.Ecp_IData
{
    public class Data_Newdoc:IDataSource
    {

        private readonly static string tableSpace = "newdoc.";
        /// <summary>
        /// 账号类型
        /// </summary>
        private string acountType = string.Empty;
        #region IDataSource 成员

        /// <summary>
        /// 获得当前科室,或者病区所有病人
        /// </summary>
        /// <param name="area_Id">科室或者病区id</param>
        /// <param name="account_Type">账号类别</param>
        /// <returns></returns>
        public DataSet GetPatients(int area_Id, string account_Type)
        {
            string sql = "";
            if (account_Type == "D")
            {
                sql =string.Format(" select a.id,a.patient_name,a.gender_code,a.birthday,a.pid,a.age,a.sick_doctor_id," +
                      " a.sick_doctor_name,a.sick_area_id,a.sick_area_name,a.section_id," +
                      " a.section_name,a.in_time,a.state,a.sick_bed_id,a.sick_bed_no,a.age_unit,Sick_Degree," +
                      " a.NURSE_LEVEL,a.insection_id,a.insection_name,a.in_area_id,in_area_name,a.Die_flag," +
                      " Marriage_State,Medicare_NO,Home_Address,Homepostal_Code,Home_Phone," +
                      " Office,Office_Address,Office_Phone,Career,Relation_Name,Relation,Relation_Address," +
                      " Relation_Phone,RelationPOS_Code,OfficePOS_Code,InHospital_Count," +
                      " CERT_ID,Pay_Manner,IN_Circs,native_place,Birth_Place,Folk_Code," +
                      " a.Sick_Group_Id,a.card_id,d.* from " + tableSpace + "t_in_patient a " +
                      " inner join " + tableSpace + "t_inhospital_action b on a.id=b.pid  " +
                      " inner join " + tableSpace + "t_sickbedinfo c on a.sick_bed_id=c.bed_id " +
                      " left join  {0}t_entity_mutate_path_instance d on to_char(a.id) = d.pid"+
                      " where a.section_id=" + area_Id + "" +
                      " and  b.action_state=4 and b.id in (select max(id) from " + tableSpace + "t_inhospital_action group by pid)",App.tablespace);
            }
            else
            {
                sql = string.Format(" select a.id,a.patient_name,a.gender_code,a.birthday,a.pid,a.age,a.sick_doctor_id," +
                      " a.sick_doctor_name,a.sick_area_id,a.sick_area_name,a.section_id," +
                      " a.section_name,a.in_time,a.state,a.sick_bed_id,a.sick_bed_no,a.age_unit,Sick_Degree," +
                      " a.NURSE_LEVEL,a.insection_id,a.insection_name,a.in_area_id,in_area_name,a.Die_flag," +
                      " Marriage_State,Medicare_NO,Home_Address,Homepostal_Code,Home_Phone," +
                      " Office,Office_Address,Office_Phone,Career,Relation_Name,Relation,Relation_Address," +
                      " Relation_Phone,RelationPOS_Code,OfficePOS_Code,InHospital_Count," +
                      " CERT_ID,Pay_Manner,IN_Circs,native_place,Birth_Place,Folk_Code," +
                      " a.Sick_Group_Id,a.card_id,d.* from " + tableSpace + "t_in_patient a " +
                      " inner join " + tableSpace + "t_inhospital_action b on a.id=b.pid  " +
                      " inner join " + tableSpace + "t_sickbedinfo c on a.sick_bed_id=c.bed_id " +
                      " left join  {0}t_entity_mutate_path_instance d on to_char(a.id) = d.pid" +
                      " where a.sick_area_id=" + area_Id + "" +
                      " and  b.action_state=4 and b.id in (select max(id) from " + tableSpace + "t_inhospital_action group by pid)",App.tablespace);
            }
            return App.GetDataSet(sql);

        }

        public DataSet GetDiagnoses(string patient_Id)
        {
            string sql = "select a.diagnose_code 诊断码,a.diagnose_name 诊断名称,b.name 诊断类别 from " + tableSpace + "t_diagnose_item a" +
                         " inner join " + tableSpace + "t_data_code b on a.diagnose_type = b.id" +
                         " where a.patient_id="+patient_Id+"";
            DataSet ds = App.GetDataSet(sql);
            return ds;
        }

        public DataSet GetOperation(string patient_Id)
        {
            string sql = "select oper_type,desioper_names,code_icd9,create_date,operation_docname "+
                        "from " + tableSpace + " t_operapproval_application " +
                        " where patient_id=" + patient_Id + " and issend='Y'";
            DataSet ds = App.GetDataSet(sql);
            return ds;
        }

        public Class_Account GetAccountInfo(string user_Number, string pass_World, string account_Type)
        {
            Class_Account accout = null;
            try
            {
                string password = Encrypt.EncryptStr(pass_World);
                string sql = "select distinct(a.account_type),a.account_id,account_name from " + tableSpace + "t_account a" +
                    //" inner join " + tableSpace + "t_acc_role b on a.account_id = b.account_id" +
                    //" inner join " + tableSpace + "t_role c on b.role_id = c.role_id" +
                    " where a.account_name='" + user_Number + "' and a.password='" + password + "'";
                DataSet ds_Accout = App.GetDataSet(sql);
                if (ds_Accout.Tables[0].Rows.Count > 0)
                {
                    accout = new Class_Account();
                    accout.Account_id = ds_Accout.Tables[0].Rows[0]["ACCOUNT_ID"].ToString();
                    accout.Account_type = ds_Accout.Tables[0].Rows[0]["account_type"].ToString();
                    accout.Account_name = ds_Accout.Tables[0].Rows[0]["ACCOUNT_NAME"].ToString();
                    accout.UserInfo = GetUserByAccot(user_Number, password);
                    acountType = accout.Account_type;
                    GetRolesByAccount(accout, user_Number, password);
                    //GetRangeByRole(user_Number, password, accout.Roles[0]);
                }
                else
                {
                    App.Msg("用户名或密码错误!");
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return accout;
        }

        public InPatientInfo InitPatient(DataRow row)
        {
            InPatientInfo inpatient = new InPatientInfo();
            inpatient.Marrige_State = row["Marriage_State"].ToString();
            inpatient.Medicare_no = row["Medicare_NO"].ToString();
            inpatient.Home_address = row["Home_Address"].ToString();
            inpatient.HomePostal_code = row["Homepostal_Code"].ToString();
            inpatient.Home_phone = row["Home_Phone"].ToString();
            inpatient.Office = row["Office"].ToString();
            inpatient.Office_address = row["Office_Address"].ToString();
            inpatient.Office_phone = row["Office_Phone"].ToString();
            inpatient.Relation = row["Relation"].ToString();
            inpatient.Relation_name = row["Relation_Name"].ToString();
            inpatient.Career = row["Career"].ToString();
            inpatient.Relation_address = row["Relation_Address"].ToString();
            inpatient.Relation_phone = row["Relation_Phone"].ToString();
            inpatient.RelationPos_code = row["RelationPOS_Code"].ToString();
            inpatient.OfficePos_code = row["OfficePOS_Code"].ToString();
            if (row["InHospital_Count"].ToString() != "")
                inpatient.InHospital_count = Convert.ToInt32(row["InHospital_Count"].ToString());
            inpatient.Cert_Id = row["CERT_ID"].ToString();
            inpatient.Pay_Manager = row["Pay_Manner"].ToString();
            inpatient.In_Circs = row["IN_Circs"].ToString();
            inpatient.Natiye_place = row["native_place"].ToString();
            inpatient.Birth_place = row["Birth_Place"].ToString();
            inpatient.Folk_code = row["Folk_Code"].ToString();

            inpatient.Id = Convert.ToInt32(row["id"].ToString());
            inpatient.Patient_Name = row["patient_name"].ToString();
            inpatient.Gender_Code = row["gender_code"].ToString();
            inpatient.Birthday = row["birthday"].ToString();
            inpatient.PId = row["pid"].ToString();
            if (row["insection_id"].ToString() != "")
                inpatient.Insection_Id = Convert.ToInt32(row["insection_id"]);
            inpatient.Insection_Name = row["insection_name"].ToString();
            inpatient.In_Area_Id = row["in_area_id"].ToString();
            inpatient.In_Area_Name = row["in_area_name"].ToString();
            if (row["age"].ToString() != "")
                inpatient.Age = row["age"].ToString();
            //inpatient.Action_State = row["action_state"].ToString();
            inpatient.Sick_Doctor_Id = row["sick_doctor_id"].ToString();
            inpatient.Sick_Doctor_Name = row["sick_doctor_name"].ToString();
            if (row["sick_area_id"].ToString() != "")
                inpatient.Sike_Area_Id = row["sick_area_id"].ToString();
            inpatient.Sick_Area_Name = row["sick_area_name"].ToString();
            if (row["section_id"].ToString() != "")
                inpatient.Section_Id = Int32.Parse(row["section_id"].ToString());
            inpatient.Section_Name = row["section_name"].ToString();
            if (row["in_time"] != null)
                inpatient.In_Time = DateTime.Parse(row["in_time"].ToString());
            inpatient.State = row["state"].ToString();
            if (row["sick_bed_id"].ToString() != "")
                inpatient.Sick_Bed_Id = Int32.Parse(row["sick_bed_id"].ToString());
            inpatient.Sick_Bed_Name = row["sick_bed_no"].ToString();
            inpatient.Age_unit = row["age_unit"].ToString();
            inpatient.Sick_Degree = Convert.ToString(row["Sick_Degree"]);
            inpatient.Nurse_Level = Convert.ToString(row["Nurse_Level"]);
            if (row["Die_flag"].ToString() != "")
                inpatient.Die_flag = Convert.ToInt32(row["Die_flag"]);
            if (row["Sick_Group_Id"].ToString() != "")
                inpatient.Sick_Group_Id = Convert.ToInt32(row["Sick_Group_Id"]);
            inpatient.Card_Id = row["card_id"].ToString();
            return inpatient;
        }


        private void GetRolesByAccount(Class_Account account, string user_Number, string pass_World)
        {
            string password = Encrypt.EncryptStr(pass_World);
            string sql = string.Empty;
            if (string.IsNullOrEmpty(acountType))
            {
                sql = "select a.role_id,a.role_name,a.enable_flag,c.sickarea_id,e.sick_area_name,c.section_id," +
                           " d.section_name,a.role_type,b.account_id from " + tableSpace + "T_ROLE a" +
                           " inner join " + tableSpace + "T_ACC_ROLE b on a.role_id = b.role_id" +
                           " inner join " + tableSpace + "t_acc_role_range c on c.acc_role_id = b.id" +
                           " left join " + tableSpace + "t_sectioninfo d on c.section_id=d.sid" +
                           " left join " + tableSpace + "t_sickareainfo e on c.sickarea_id = e.said" +
                           " where b.account_id=" + account.Account_id + " and a.enable_flag='Y'";
            }
            else
            {
                sql = "select a.role_id,a.role_name,a.enable_flag," +
                      " a.role_type,b.account_id from newdoc.T_ROLE a " +
                      " inner join newdoc.T_ACC_ROLE b on a.role_id = b.role_id " +
                      " where b.account_id=" + account.Account_id + " and a.enable_flag='Y'";
            }
            try
            {
                DataSet ds = App.GetDataSet(sql);
                account.Roles = new Class_Role[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    account.Roles[i] = new Class_Role();
                    account.Roles[i].Role_id = ds.Tables[0].Rows[i]["ROLE_ID"].ToString();
                    account.Roles[i].Role_name = ds.Tables[0].Rows[i]["ROLE_NAME"].ToString();
                    account.Roles[i].Enable = ds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                    if (string.IsNullOrEmpty(acountType))
                    {
                        account.Roles[i].Section_Id = ds.Tables[0].Rows[i]["SECTION_ID"].ToString();
                        account.Roles[i].Section_name = ds.Tables[0].Rows[i]["section_name"].ToString();
                        account.Roles[i].Sickarea_Id = ds.Tables[0].Rows[i]["SICKAREA_ID"].ToString();
                        account.Roles[i].Sickarea_name = ds.Tables[0].Rows[i]["sick_area_name"].ToString();
                    }
                    account.Roles[i].Role_type = ds.Tables[0].Rows[i]["ROLE_TYPE"].ToString();
                    GetRangeByRole(user_Number, password, account.Roles[i]);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        private void GetRangeByRole(string user_Number, string pass_World, Class_Role role)
        {
            string  sql = "select a.id,a.acc_role_id,a.section_id,a.sickarea_id,a.isbelongto," +
                           " c.section_name,d.sick_area_name,b.role_id from " + tableSpace + "T_ACC_ROLE_RANGE a " +
                           " left join " + tableSpace + "T_ACC_ROLE b on a.acc_role_id=b.id left join " + tableSpace + "T_SECTIONINFO c " +
                           " on a.section_id=c.sid left join " + tableSpace + "T_SICKAREAINFO d on a.sickarea_id=d.said" +
                           " where b.account_id in (select ACCOUNT_ID from " + tableSpace + "T_ACCOUNT " +
                           " where ACCOUNT_NAME='" + user_Number + "' and PASSWORD='" + pass_World + "') ";
            try
            {
                DataSet ds = App.GetDataSet(sql);
                /*
                * 获取每个权限所对应的适用范围      
                */
                DataRow[] rows = ds.Tables[0].Select("role_id=" + role.Role_id + "");
                role.Rnages = new Class_Rnage[rows.Length];
                for (int j1 = 0; j1 < rows.Length; j1++)
                {
                    role.Rnages[j1] = new Class_Rnage();
                    role.Rnages[j1].Id = rows[j1]["id"].ToString();
                    role.Rnages[j1].Section_id = rows[j1]["section_id"].ToString();
                    role.Rnages[j1].Sickarea_id = rows[j1]["sickarea_id"].ToString();
                    role.Rnages[j1].Acc_role_id = rows[j1]["acc_role_id"].ToString();
                    role.Rnages[j1].Isbelonge = rows[j1]["isbelongto"].ToString();
                    //0科室 1病区
                    if (role.Rnages[j1].Isbelonge == "0")
                    {
                        role.Rnages[j1].Rnagename = rows[j1]["section_name"].ToString();
                    }
                    else
                    {
                        role.Rnages[j1].Rnagename = rows[j1]["sick_area_name"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private Class_User GetUserByAccot(string user_Number, string pass_World)
        {
            Class_User userInfo = new Class_User();

            string sql = "select * from " + tableSpace + "t_userinfo a inner join " + tableSpace + "t_account_user b on a.User_Id=b.user_id " +
                         " where b.account_id in (select ACCOUNT_ID from " + tableSpace + "T_ACCOUNT where " +
                         " ACCOUNT_NAME='" + user_Number + "' and PASSWORD='" + pass_World + "')";
            /*
             * 获取当前帐号所对应的用户信息                     
             */
            DataSet ds = App.GetDataSet(sql);
            if (ds.Tables[0] != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // App.UserAccount.UserInfo = new Class_User();

                    userInfo.User_id = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                    userInfo.User_name = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                    userInfo.U_gender_code = ds.Tables[0].Rows[0]["Gender_Code"].ToString();
                    userInfo.Birth_date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Birthday"].ToString());
                    userInfo.U_tech_post = ds.Tables[0].Rows[0]["U_TECH_POST"].ToString();
                    userInfo.U_seniority = ds.Tables[0].Rows[0]["U_SENIORITY"].ToString();
                    userInfo.In_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["IN_TIME"].ToString());
                    userInfo.U_position = ds.Tables[0].Rows[0]["U_POSITION"].ToString();
                    userInfo.U_recipe_power = ds.Tables[0].Rows[0]["U_RECIPE_POWER"].ToString();
                    userInfo.Section_id = ds.Tables[0].Rows[0]["SECTION_ID"].ToString();
                    userInfo.Sickarea_id = ds.Tables[0].Rows[0]["SICKAREA_ID"].ToString();
                    userInfo.Phone = ds.Tables[0].Rows[0]["PHONE"].ToString();
                    userInfo.Mobile_phone = ds.Tables[0].Rows[0]["MOBILE_PHONE"].ToString();
                    userInfo.Email = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                    userInfo.Enable_flag = ds.Tables[0].Rows[0]["Enable"].ToString();
                    userInfo.Profession_card = ds.Tables[0].Rows[0]["PROFESSION_CARD"].ToString();
                    userInfo.Prof_card_name = ds.Tables[0].Rows[0]["PROF_CARD_NAME"].ToString();
                    userInfo.Pass_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["PASS_TIME"].ToString());
                    userInfo.Receive_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["RECEIVE_TIME"].ToString());
                    userInfo.Register_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["REGISTER_TIME"].ToString());
                }
                else
                {
                    App.MsgErr("该帐号当前没有任何用户信息，请先给帐号设置用户信息!");
                }
            }
            return userInfo;
        }
        private Class_User GetUserByAccot(string user_Number)
        {
            Class_User userInfo = new Class_User();

            string sql = "select * from " + tableSpace + "t_userinfo a inner join " + tableSpace + "t_account_user b on a.User_Id=b.user_id " +
                         " where b.account_id in (select ACCOUNT_ID from " + tableSpace + "T_ACCOUNT where " +
                         " ACCOUNT_NAME='" + user_Number + "')";
            /*
             * 获取当前帐号所对应的用户信息                     
             */
            DataSet ds = App.GetDataSet(sql);
            if (ds.Tables[0] != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // App.UserAccount.UserInfo = new Class_User();

                    userInfo.User_id = ds.Tables[0].Rows[0]["USER_ID"].ToString();
                    userInfo.User_name = ds.Tables[0].Rows[0]["USER_NAME"].ToString();
                    userInfo.U_gender_code = ds.Tables[0].Rows[0]["Gender_Code"].ToString();
                    userInfo.Birth_date = Convert.ToDateTime(ds.Tables[0].Rows[0]["Birthday"].ToString());
                    userInfo.U_tech_post = ds.Tables[0].Rows[0]["U_TECH_POST"].ToString();
                    userInfo.U_seniority = ds.Tables[0].Rows[0]["U_SENIORITY"].ToString();
                    userInfo.In_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["IN_TIME"].ToString());
                    userInfo.U_position = ds.Tables[0].Rows[0]["U_POSITION"].ToString();
                    userInfo.U_recipe_power = ds.Tables[0].Rows[0]["U_RECIPE_POWER"].ToString();
                    userInfo.Section_id = ds.Tables[0].Rows[0]["SECTION_ID"].ToString();
                    userInfo.Sickarea_id = ds.Tables[0].Rows[0]["SICKAREA_ID"].ToString();
                    userInfo.Phone = ds.Tables[0].Rows[0]["PHONE"].ToString();
                    userInfo.Mobile_phone = ds.Tables[0].Rows[0]["MOBILE_PHONE"].ToString();
                    userInfo.Email = ds.Tables[0].Rows[0]["EMAIL"].ToString();
                    userInfo.Enable_flag = ds.Tables[0].Rows[0]["Enable"].ToString();
                    userInfo.Profession_card = ds.Tables[0].Rows[0]["PROFESSION_CARD"].ToString();
                    userInfo.Prof_card_name = ds.Tables[0].Rows[0]["PROF_CARD_NAME"].ToString();
                    userInfo.Pass_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["PASS_TIME"].ToString());
                    userInfo.Receive_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["RECEIVE_TIME"].ToString());
                    userInfo.Register_time = Convert.ToDateTime(ds.Tables[0].Rows[0]["REGISTER_TIME"].ToString());
                }
                else
                {
                    App.MsgErr("该帐号当前没有任何用户信息，请先给帐号设置用户信息!");
                }
            }
            return userInfo;
        }

        /// <summary>
        /// 浏览器直接登录
        /// </summary>
        /// <param name="user_Number"></param>
        /// <param name="section_Id"></param>
        /// <returns></returns>
        public Class_Account GetAccountInfoByBrowe(string user_Number, string section_Id, string account_Type)
        {
            Class_Account account = new Class_Account();
            try
            {
                //string password = App.EncryptStr(pass_World);
                string sql_Account = "select distinct(c.role_type),a.account_id,account_name from " + tableSpace + "t_account a" +
                    " inner join " + tableSpace + "t_acc_role b on a.account_id = b.account_id" +
                    " inner join " + tableSpace + "t_role c on b.role_id = c.role_id" +
                    " where a.account_name='" + user_Number + "'";
                DataSet ds_Accout = App.GetDataSet(sql_Account);
                account.Account_id = ds_Accout.Tables[0].Rows[0]["ACCOUNT_ID"].ToString();
                account.Account_type = ds_Accout.Tables[0].Rows[0]["role_type"].ToString();
                account.Account_name = ds_Accout.Tables[0].Rows[0]["ACCOUNT_NAME"].ToString();
                account.UserInfo = GetUserByAccot(user_Number);
                string sql = string.Empty;
                if (account_Type != "N" || account_Type != "D")
                {
                    if (account_Type == "D")
                    {
                        sql = "select a.role_id,a.role_name,a.enable_flag,c.sickarea_id,e.sick_area_name,c.section_id," +
                                   " d.section_name,a.role_type,b.account_id from " + tableSpace + "T_ROLE a" +
                                   " inner join " + tableSpace + "T_ACC_ROLE b on a.role_id = b.role_id" +
                                   " inner join " + tableSpace + "t_acc_role_range c on c.acc_role_id = b.id" +
                                   " left join " + tableSpace + "t_sectioninfo d on c.section_id=d.sid" +
                                   " left join " + tableSpace + "t_sickareainfo e on c.sickarea_id = e.said" +
                                   " where b.account_id=" + account.Account_id + " and a.enable_flag='Y' and c.section_id='" + section_Id + "'";
                    }
                    else
                    {
                        sql = "select a.role_id,a.role_name,a.enable_flag,c.sickarea_id,e.sick_area_name,c.section_id," +
                               " d.section_name,a.role_type,b.account_id from " + tableSpace + "T_ROLE a" +
                               " inner join " + tableSpace + "T_ACC_ROLE b on a.role_id = b.role_id" +
                               " inner join " + tableSpace + "t_acc_role_range c on c.acc_role_id = b.id" +
                               " left join " + tableSpace + "t_sectioninfo d on c.section_id=d.sid" +
                               " left join " + tableSpace + "t_sickareainfo e on c.sickarea_id = e.said" +
                               " where b.account_id=" + account.Account_id + " and a.enable_flag='Y' and c.sickarea_id='" + section_Id + "'";
                    }
                }
                else
                {
                    sql = "select a.role_id,a.role_name,a.enable_flag," +
                          " a.role_type,b.account_id from newdoc.T_ROLE a " +
                          " inner join newdoc.T_ACC_ROLE b on a.role_id = b.role_id " +
                          " where b.account_id=" + account.Account_id + " and a.enable_flag='Y' and a.role_type='" + acountType + "'";
                }
                try
                {
                    DataSet ds = App.GetDataSet(sql);
                    account.Roles = new Class_Role[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        account.Roles[i] = new Class_Role();
                        account.Roles[i].Role_id = ds.Tables[0].Rows[i]["ROLE_ID"].ToString();
                        account.Roles[i].Role_name = ds.Tables[0].Rows[i]["ROLE_NAME"].ToString();
                        account.Roles[i].Enable = ds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                        if (account_Type != "N" || account_Type != "D")
                        {
                            account.Roles[i].Section_Id = ds.Tables[0].Rows[i]["SECTION_ID"].ToString();
                            account.Roles[i].Section_name = ds.Tables[0].Rows[i]["section_name"].ToString();
                            account.Roles[i].Sickarea_Id = ds.Tables[0].Rows[i]["SICKAREA_ID"].ToString();
                            account.Roles[i].Sickarea_name = ds.Tables[0].Rows[i]["sick_area_name"].ToString();
                        }
                        account.Roles[i].Role_type = ds.Tables[0].Rows[i]["ROLE_TYPE"].ToString();
                        //GetRangeByRole(user_Number, password, account.Roles[i]);
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return account;
        }


        /// <summary>
        /// 获得所有的科室
        /// </summary>,
        /// <returns></returns>
        public DataSet GetAllSection()
        {
            try
            {
                string sql = string.Format("select sid id,section_name name  from {0}t_sectioninfo", tableSpace);
                return App.GetDataSet(sql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// 获得所有的病区
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllArea()
        {
            try
            {
                string sql = string.Format("select * from {0}t_sickareainfo", tableSpace);
                return App.GetDataSet(sql);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
