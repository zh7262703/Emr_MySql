using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Diagnostics;
using System.Collections;
using System.Net;
using System.IO;
using System.Reflection;

namespace BifrostMainPro
{
    /// <summary>
    /// ϵͳ��¼
    /// �����ߣ��Ż�
    /// ����ʱ�䣺2009-12-10
    /// </summary>
    public partial class frmLogin : DevComponents.DotNetBar.Office2007Form
    {
        public static bool isUpdate = false;             //�Ƿ����       
        public frmLogin(string[] args)
        {
            InitializeComponent();
            //args = new string[1];
            //args[0] = @"HC,00059381,G:\EMR4.0\Project\BIFOST_FRAME";//,0014444-1


            //string path=Directory.GetFile("Bifrost",".dll");
            //App.SysPath = @"G:\������Ŀ\BIFOST_FRAME";
            //Assembly.LoadFrom(App.SysPath + "\\Bifrost.dll");            
            

            /*
             * �жϵ�ǰ�Ƿ��в�������
             */
            if (args.Length > 0)
            {
                if (args[0].Contains(","))
                {
                    App.OtherSystemAccount = args[0].Split(',')[0].ToUpper();
                    App.OtherSystemHisId = args[0].Split(',')[1];
                    App.SysPath=args[0].Split(',')[2];                  
                    Assembly.LoadFrom(App.SysPath + "\\Base_App.dll");
                    App.isOtherSystemRefrenceflag = true;

                    if (args[0].Split(',').Length > 3)
                    {
                        App.OtherSystemDept = args[0].Split(',')[3];
                    }

                }
                else
                {
                    App.OtherSystemAccount = args[0].ToUpper();
                    App.isOtherSystemRefrenceflag = true;

                }
            }
            else
            {
                App.OtherSystemAccount = "";
            }


            //try
            //{
            //    /*
            //     * �Ƿ����������
            //     */
            //    WebClient newt = new WebClient();
            //    string Ip = Encrypt.DecryptStr(App.Read_ConfigInfo("WebServerPath", "Url", App.SysPath + "\\Config.ini"));
            //    newt.DownloadString("http://" + Ip + @"/WebSite1/Test.txt");
            //}
            //catch
            //{
            //    //�޸��ļ��������޸ĵ�ַ
            //    string ip = "175.16.8.92";
            //    App.Write_ConfigInfo("WebServerPath", "Url", Encrypt.EncryptStr(ip), App.SysPath + "\\Config.ini");
            //    if (App.Ask("�ļ���������ַ�Ѿ��ı䣬���Ӳ���ϵͳ��Ҫ��������?"))
            //    {
            //        Application.Restart();
            //        return;
            //    }
            //    else
            //    {
            //        Application.Exit();
            //        this.Close();
            //        return;
            //    }
            //}
        }

        /// <summary>
        /// �жϵ�ǰ�ʺ��Ƿ��Ѿ�������
        /// </summary>
        /// <param name="account">�ʺ�</param>
        /// <returns></returns>
        private bool isUserOnline(string account)
        {
            /*
             * ����˼·��
             * 1.�����ʺű��е����е������û���Ȼ��͵�ǰ��¼�ʻ����бȶԣ����������ؼ�¼��˵���ʺ��Ѿ���ʹ��.
             */
            DataSet ds = App.GetDataSet("select t.account_name from t_account t where IS_ONLINE=1");
            bool onlinefleg = false;
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (ds.Tables[0].Rows[i]["account_name"].ToString() == account)
                            {
                                onlinefleg = true;
                            }
                        }
                    }
                }
            }
            return onlinefleg;
        }

        private void Reflesh()
        {
            //txtAccount.Text = "";
            txtPassword.Text = "";

            txtAccount.Focus();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                DeletingStores isod = new DeletingStores();
                isod.DeleteIsoStores();
            }
            catch
            { }
            App.Ini();
            

            #region �û���ƴ
            //DataSet dsu = App.GetDataSet("select * from T_USERINFO");

            //for (int i = 0; i < dsu.Tables[0].Rows.Count; i++)
            //{
            //    string uname = dsu.Tables[0].Rows[i]["USER_NAME"].ToString();
            //    string shortcode=App.getSpell(uname);
            //    App.ExecuteSQL("Update T_USERINFO set SHORTCUT_CODE='" + shortcode + "' where USER_ID=" + dsu.Tables[0].Rows[i]["USER_ID"].ToString() + "");
            //}
            #endregion
            this.TopMost = true;
            cboAccountType.SelectedIndex = 0;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Activate();
            txtAccount.Focus();
            this.TopMost = false;
      
            label1.BackColor = Color.WhiteSmoke;
            lblVersion.Text = "��ǰ�汾��" + App.ProgrameVersion;                        

            #region ����ϵͳ����
            //*
            // * �жϱ��ذ汾�źͷ������汾���Ƿ�ͬ
            // */
          
            //string ServerVersion = App.WebService.GetServerVersion();
            //string ClientVersion = App.ProgrameVersion;
            //if (App.ProgrameVersion != ServerVersion)
            //{
            //    App.Write_ConfigInfo("WebServerPath", "HISVAL", Accountname + "," + HISID, App.SysPath + "\\Config.ini");
            //    Process.Start(App.SysPath + "\\EmrUpdate.exe");
            //    this.Close();
            //}
            //string hisval = App.Read_ConfigInfo("WebServerPath", "HISVAL", App.SysPath + "\\Config.ini");
            //if (hisval != "")
            //{
            //    Accountname = hisval.Split(',')[0];
            //    HISID = hisval.Split(',')[1];
            //}          
            //if (App.OtherSystemAccount != "")
            //{
            //    App.isOtherSystemRefrenceflag = true;
            //    App.OtherSystemAccount = App.OtherSystemAccount;
            //    App.OtherSystemHisId = App.OtherSystemHisId;
            //    App.OtherSystemDept = T_SICKDEPART;
            //}
            if (!App.isOtherSystemRefrenceflag)
            {
                this.TopMost = true;
                cboAccountType.SelectedIndex = 0;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.Activate();
                txtAccount.Focus();
                this.TopMost = false;
                label1.BackColor = Color.WhiteSmoke;
                lblVersion.Text = "��ǰ�汾��" + App.ProgrameVersion;
            }
            else
            {
                this.Visible = false;

                string sql_account = "select * from T_ACCOUNT where upper(ACCOUNT_NAME)='" + App.OtherSystemAccount.ToUpper() + "'";

                string sql_userinfo = "select a.*,d1.name as u_tech_post_name,d2.name as u_position_name from t_userinfo a inner join t_account_user b on a.User_Id=b.user_id inner join T_DATA_CODE d1 on a.u_tech_post=d1.id inner join T_DATA_CODE d2 on a.u_position=d2.id where b.account_id in (select ACCOUNT_ID from T_ACCOUNT where upper(ACCOUNT_NAME)='" + App.OtherSystemAccount.ToUpper() + "')";


                DataSet ds_account = App.GetDataSet(sql_account);
                if (ds_account != null)
                {
                    if (ds_account.Tables[0].Rows.Count > 0)
                    {
                        /*
                         * ��ȡ��ǰ�ʺ���Ϣ
                         */
                        App.UserAccount = new Class_Account();
                        App.UserAccount.Account_id = ds_account.Tables[0].Rows[0]["ACCOUNT_ID"].ToString();
                        App.UserAccount.Account_type = ds_account.Tables[0].Rows[0]["ACCOUNT_TYPE"].ToString();
                        App.UserAccount.Account_name = ds_account.Tables[0].Rows[0]["ACCOUNT_NAME"].ToString();
                        App.UserAccount.Password = ds_account.Tables[0].Rows[0]["PASSWORD"].ToString();
                        App.UserAccount.Enable = ds_account.Tables[0].Rows[0]["ENABLE"].ToString();
                        if (App.isNumval(ds_account.Tables[0].Rows[0]["KIND"].ToString()))
                            App.UserAccount.Kind = Convert.ToInt16(ds_account.Tables[0].Rows[0]["KIND"].ToString());
                        App.UserAccount.Last_login_ip = App.GetHostIp();
                        App.UserAccount.Group_id = 0;
                        App.UserAccount.Group_name = "";
                        App.CurrentHospitalId = Convert.ToInt16(ds_account.Tables[0].Rows[0]["HSID"].ToString());
                        DataSet ds_Account_Group = App.GetDataSet("select t.tng_id from t_tng_account t where t.account_id=" + App.UserAccount.Account_id + "");
                        if (ds_Account_Group != null)
                        {
                            if (ds_Account_Group.Tables[0].Rows.Count > 0)
                            {
                                DataSet AccountGroup = App.GetDataSet("select t.tng_id,t.tng_name from t_treatornurse_group t where tng_id=" + ds_Account_Group.Tables[0].Rows[0][0].ToString() + "");
                                if (AccountGroup != null)
                                {
                                    if (AccountGroup.Tables[0].Rows.Count > 0)
                                    {
                                        App.UserAccount.Group_id = Convert.ToInt16(AccountGroup.Tables[0].Rows[0]["tng_id"]);
                                        App.UserAccount.Group_name = AccountGroup.Tables[0].Rows[0]["tng_name"].ToString();
                                    }
                                }
                            }
                        }
                        /*
                         * ��ȡ��ǰ�ʺ�����Ӧ���û���Ϣ                     
                         */
                        DataSet ds_userinfo = App.GetDataSet(sql_userinfo);
                        if (ds_userinfo.Tables[0] != null)
                        {
                            if (ds_userinfo.Tables[0].Rows.Count > 0)
                            {
                                App.UserAccount.UserInfo = new Class_User();
                                App.UserAccount.UserInfo.User_id = ds_userinfo.Tables[0].Rows[0]["USER_ID"].ToString();
                                App.UserAccount.UserInfo.User_name = ds_userinfo.Tables[0].Rows[0]["USER_NAME"].ToString();
                                App.UserAccount.UserInfo.U_gender_code = ds_userinfo.Tables[0].Rows[0]["Gender_Code"].ToString();
                                if (ds_userinfo.Tables[0].Rows[0]["Birthday"].ToString() != "")
                                    App.UserAccount.UserInfo.Birth_date = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["Birthday"].ToString());
                                App.UserAccount.UserInfo.U_tech_post = ds_userinfo.Tables[0].Rows[0]["U_TECH_POST"].ToString();
                                App.UserAccount.UserInfo.U_tech_post_name = ds_userinfo.Tables[0].Rows[0]["U_TECH_POST_NAME"].ToString(); ;
                                App.UserAccount.UserInfo.U_seniority = ds_userinfo.Tables[0].Rows[0]["U_SENIORITY"].ToString();
                                if (ds_userinfo.Tables[0].Rows[0]["IN_TIME"].ToString() != "")
                                    App.UserAccount.UserInfo.In_time = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["IN_TIME"].ToString());
                                App.UserAccount.UserInfo.U_position = ds_userinfo.Tables[0].Rows[0]["U_POSITION"].ToString();
                                App.UserAccount.UserInfo.U_position_name = ds_userinfo.Tables[0].Rows[0]["U_POSITION_NAME"].ToString(); ;
                                App.UserAccount.UserInfo.U_recipe_power = ds_userinfo.Tables[0].Rows[0]["U_RECIPE_POWER"].ToString();
                                App.UserAccount.UserInfo.Section_id = ds_userinfo.Tables[0].Rows[0]["SECTION_ID"].ToString();
                                App.UserAccount.UserInfo.Sickarea_id = ds_userinfo.Tables[0].Rows[0]["SICKAREA_ID"].ToString();
                                App.UserAccount.UserInfo.Phone = ds_userinfo.Tables[0].Rows[0]["PHONE"].ToString();
                                App.UserAccount.UserInfo.Mobile_phone = ds_userinfo.Tables[0].Rows[0]["MOBILE_PHONE"].ToString();
                                App.UserAccount.UserInfo.Email = ds_userinfo.Tables[0].Rows[0]["EMAIL"].ToString();
                                App.UserAccount.UserInfo.Enable_flag = ds_userinfo.Tables[0].Rows[0]["Enable"].ToString();
                                App.UserAccount.UserInfo.Profession_card = ds_userinfo.Tables[0].Rows[0]["PROFESSION_CARD"].ToString();
                                App.UserAccount.UserInfo.Prof_card_name = ds_userinfo.Tables[0].Rows[0]["PROF_CARD_NAME"].ToString();
                                if (ds_userinfo.Tables[0].Rows[0]["PASS_TIME"].ToString() != "")
                                    App.UserAccount.UserInfo.Pass_time = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["PASS_TIME"].ToString());
                                if (ds_userinfo.Tables[0].Rows[0]["RECEIVE_TIME"].ToString() != "")
                                    App.UserAccount.UserInfo.Receive_time = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["RECEIVE_TIME"].ToString());
                                if (ds_userinfo.Tables[0].Rows[0]["REGISTER_TIME"].ToString() != "")
                                    App.UserAccount.UserInfo.Register_time = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["REGISTER_TIME"].ToString());
                            }
                            else
                            {
                                App.MsgErr("���ʺŵ�ǰû���κ��û���Ϣ�����ȸ��ʺ������û���Ϣ!");
                                return;
                            }
                        }

                        //��¼��¼ʱ���IP
                        App.ExecuteSQL("update T_ACCOUNT set LAST_LOGIN_IP='" + App.UserAccount.Last_login_ip + "',LAST_LOGIN_TIME=to_timestamp('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff") + "', 'syyyy-mm-dd hh24:mi:ss.ff9'),IS_ONLINE=1 where ACCOUNT_ID=" + App.UserAccount.Account_id + "");

                        /*
                         *��ȡ��ǰ�ʺ���ӵ�еĽ�ɫ���� 
                         */
                        IniAccountRoleRanges(App.OtherSystemAccount);
                        if (App.UserAccount.Roles == null)
                        {
                            App.MsgErr("���ʺ�û�к��κν�ɫ��,����ϵ����Ա�����˺Ž�ɫ��");
                            return;
                        }
                        else
                        {
                            if (App.OtherSystemHisId != "")
                            {
                                DataSet ds = App.GetDataSet("select t.id,section_id,sick_area_id,sick_doctor_id,t.section_name,t.sick_area_name from t_in_patient t where t.his_id='" + App.OtherSystemHisId + "' or t.pid='" + App.OtherSystemHisId + "'");
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    //��ǰ�ҷ�ϵͳ���Ѿ������������

                                    //��ȡʹ�÷�Χ
                                    for (int i = 0; i < App.UserAccount.Roles.Length; i++)
                                    {
                                        for (int j = 0; j < App.UserAccount.Roles[i].Rnages.Length; j++)
                                        {
                                            if (App.UserAccount.Roles[i].Rnages[j].Section_id !="0")
                                            {
                                                if (App.UserAccount.Roles[i].Rnages[j].Section_id == ds.Tables[0].Rows[0]["section_id"].ToString())
                                                {
                                                    App.UserAccount.Roles[i].Section_Id = ds.Tables[0].Rows[0]["section_id"].ToString();
                                                    App.UserAccount.Roles[i].Section_name = ds.Tables[0].Rows[0]["section_name"].ToString();
                                                    App.UserAccount.CurrentSelectRole = App.UserAccount.Roles[i];

                                                }
                                            }
                                            else
                                            {
                                                App.UserAccount.Roles[i].Sickarea_Id = ds.Tables[0].Rows[0]["sick_area_id"].ToString();
                                                App.UserAccount.Roles[i].Sickarea_name = ds.Tables[0].Rows[0]["sick_area_name"].ToString();
                                                App.UserAccount.CurrentSelectRole = App.UserAccount.Roles[i];
                                            }
                                        }
                                    }

                                    if (App.UserAccount.CurrentSelectRole == null)
                                    {
                                        App.MsgWaring("��ǰ�û�û�в������ڿ��ҵĲ���Ȩ�ޣ�");
                                        this.Close();
                                    }
                                }
                                else
                                {
                                    App.MsgWaring("��ǰѡ��Ĳ��ˣ��ڵ��Ӳ����в����ڣ�");
                                    this.Close();
                                }
                            }
                            else
                            {
                                try
                                {
                                    string sqlset = "select a.sid,b.section_code,b.section_name,a.said,c.sick_area_code,c.sick_area_name from t_section_area a inner join t_sectioninfo b on a.sid=b.sid inner join t_sickareainfo c on a.said=c.said";
                                    DataSet ds_section_area = App.GetDataSet(sqlset);
                                    //��ȡʹ�÷�Χ
                                    for (int i = 0; i < App.UserAccount.Roles.Length; i++)
                                    {
                                        if (App.UserAccount.Roles[i].Rnages.Length == 1)
                                        {
                                            if (App.UserAccount.Roles[i].Rnages[0].Section_id != "0")
                                            {
                                                App.UserAccount.CurrentSelectRole = App.UserAccount.Roles[i];
                                                App.UserAccount.CurrentSelectRole.Section_Id = App.UserAccount.Roles[i].Rnages[0].Section_id;
                                                App.UserAccount.CurrentSelectRole.Section_name = App.UserAccount.Roles[i].Rnages[0].Rnagename.Split('-')[App.UserAccount.Roles[i].Rnages[0].Rnagename.Split('-').Length - 1];
                                                break;
                                            }
                                            else
                                            {
                                                App.UserAccount.CurrentSelectRole = App.UserAccount.Roles[i];
                                                App.UserAccount.CurrentSelectRole.Sickarea_Id = App.UserAccount.Roles[i].Rnages[0].Sickarea_id;
                                                App.UserAccount.CurrentSelectRole.Section_name = App.UserAccount.Roles[i].Rnages[0].Rnagename.Split('-')[App.UserAccount.Roles[i].Rnages[0].Rnagename.Split('-').Length - 1];
                                                break;
                                            }
                                        }
                                        else
                                        {

                                            for (int j = 0; j < App.UserAccount.Roles[i].Rnages.Length; j++)
                                            {
                                                if (App.OtherSystemDept.Contains("D"))
                                                {
                                                    DataRow[] rows = ds_section_area.Tables[0].Select("sid=" + App.UserAccount.Roles[i].Rnages[j].Section_id + "");
                                                    if (rows[0]["section_code"].ToString().Trim().Contains(App.OtherSystemDept.Split('-')[1].Trim()))
                                                    {
                                                        App.UserAccount.CurrentSelectRole = App.UserAccount.Roles[i];
                                                        App.UserAccount.CurrentSelectRole.Section_Id = App.UserAccount.Roles[i].Rnages[j].Section_id;
                                                        App.UserAccount.CurrentSelectRole.Section_name = App.UserAccount.Roles[i].Rnages[j].Rnagename.Split('-')[App.UserAccount.Roles[i].Rnages[j].Rnagename.Split('-').Length - 1];
                                                        break;
                                                    }

                                                }
                                                else if (App.OtherSystemDept.Contains("N"))
                                                {
                                                    DataRow[] rows = ds_section_area.Tables[0].Select("said=" + App.UserAccount.Roles[i].Rnages[j].Sickarea_id + "");
                                                    if (rows[0]["sick_area_code"].ToString().Contains(App.OtherSystemDept.Split('-')[1].Trim()))
                                                    {
                                                        App.UserAccount.CurrentSelectRole = App.UserAccount.Roles[i];
                                                        App.UserAccount.CurrentSelectRole.Sickarea_Id = App.UserAccount.Roles[i].Rnages[j].Sickarea_id;
                                                        App.UserAccount.CurrentSelectRole.Sickarea_name = App.UserAccount.Roles[i].Rnages[j].Rnagename.Split('-')[App.UserAccount.Roles[i].Rnages[j].Rnagename.Split('-').Length - 1];
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch
                                { }
                             }
                        }

                        App.CurrentHospitalId = Convert.ToInt16(ds_account.Tables[0].Rows[0]["HSID"].ToString());
                        frmMain main = new frmMain();
                        main.Show();
                        App.SendtoServerMes.Start();
                        this.Hide();
                    }
                    else
                    {
                        App.MsgWaring("���˺��ڵ��Ӳ���ϵͳ��δע�ᣬ����ע���˺ţ�");
                        this.Close();
                    }
                }
                else
                {
                    App.MsgWaring("���˺��ڵ��Ӳ���ϵͳ��δע�ᣬ����ע���˺ţ�");
                    this.Close();
                }
                this.Hide();
                this.Visible = false;
            }
            ////���Config.ini��HISVAL��ֵ
            //App.Write_ConfigInfo("WebServerPath", "HISVAL", "", App.SysPath + "\\Config.ini");
            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// ϵͳ�ĵ�¼����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            try
            {              
                /*
                 * ����˼·��
                 * 1.���ȸ����ʺź����룬Ѱ���Ƿ���T_Account���д�����ؼ�¼�����������֤�����ʺſ��Ե�¼��
                 * 2.�����¼�ɹ��Ļ��򣬻�ȡ���ʺ�����Ӧ����ؽ�ɫ���û���Ϣ���Լ�ÿ����ɫ����Ӧ��ʹ�÷�Χ��
                 * 3.����ص���Ϣ�洢��App�е�ȫ���������UserAccount���У����ڸ�������ҵ��ģ��ĵ��á�
                 */
                frmMain.AccountType = cboAccountType.SelectedIndex;
                if (cboAccountType.SelectedIndex == 0)
                {
                    /*
                     * һ���¼ģʽ
                     */
                    string sql_account = "select * from T_ACCOUNT where upper(ACCOUNT_NAME)='" + txtAccount.Text.ToUpper() + "' and PASSWORD='" + Encrypt.EncryptStr(txtPassword.Text) + "'";

                    string sql_userinfo = "select a.*,d1.name as u_tech_post_name,d2.name as u_position_name from t_userinfo a inner join t_account_user b on a.User_Id=b.user_id inner join T_DATA_CODE d1 on a.u_tech_post=d1.id inner join T_DATA_CODE d2 on a.u_position=d2.id where b.account_id in (select ACCOUNT_ID from T_ACCOUNT where upper(ACCOUNT_NAME)='" + txtAccount.Text.ToUpper() + "' and PASSWORD='" + Encrypt.EncryptStr(txtPassword.Text) + "')";

                    DataSet ds_account = App.GetDataSet(sql_account);
                    if (ds_account != null)
                    {
                        if (ds_account.Tables[0].Rows.Count > 0)
                        {
                            //�ж��˺ŵ���Ч��
                            if (ds_account.Tables[0].Rows[0]["ENABLE"].ToString() != "N")
                            {
                                //if (isUserOnline(txtAccount.Text))
                                //{
                                //    App.MsgErr("���ʻ���ǰ�ڱ����ڱ�ʹ�ã�");
                                //    return;
                                //}
                                /*
                                 * ��ȡ��ǰ�ʺ���Ϣ
                                 */
                                App.UserAccount = new Class_Account();
                                App.UserAccount.Account_id = ds_account.Tables[0].Rows[0]["ACCOUNT_ID"].ToString();
                                App.UserAccount.Account_type = ds_account.Tables[0].Rows[0]["ACCOUNT_TYPE"].ToString();
                                App.UserAccount.Account_name = ds_account.Tables[0].Rows[0]["ACCOUNT_NAME"].ToString();
                                App.UserAccount.Password = ds_account.Tables[0].Rows[0]["PASSWORD"].ToString();
                                App.UserAccount.Enable = ds_account.Tables[0].Rows[0]["ENABLE"].ToString();
                                if (App.isNumval(ds_account.Tables[0].Rows[0]["KIND"].ToString()))
                                    App.UserAccount.Kind = Convert.ToInt16(ds_account.Tables[0].Rows[0]["KIND"].ToString());
                                App.UserAccount.Last_login_ip = App.GetHostIp();
                                App.UserAccount.Group_id = 0;
                                App.UserAccount.Group_name = "";
                                App.CurrentHospitalId = Convert.ToInt16(ds_account.Tables[0].Rows[0]["HSID"].ToString());
                                DataSet ds_Account_Group = App.GetDataSet("select t.tng_id from t_tng_account t where t.account_id=" + App.UserAccount.Account_id + "");
                                if (ds_Account_Group != null)
                                {
                                    if (ds_Account_Group.Tables[0].Rows.Count > 0)
                                    {
                                        DataSet AccountGroup = App.GetDataSet("select t.tng_id,t.tng_name from t_treatornurse_group t where tng_id=" + ds_Account_Group.Tables[0].Rows[0][0].ToString() + "");
                                        if (AccountGroup != null)
                                        {
                                            if (AccountGroup.Tables[0].Rows.Count > 0)
                                            {
                                                App.UserAccount.Group_id = Convert.ToInt16(AccountGroup.Tables[0].Rows[0]["tng_id"]);
                                                App.UserAccount.Group_name = AccountGroup.Tables[0].Rows[0]["tng_name"].ToString();
                                            }
                                        }
                                    }
                                }
                                /*
                                 * ��ȡ��ǰ����Ӧ���û���Ϣ                     
                                 */
                                DataSet ds_userinfo = App.GetDataSet(sql_userinfo);
                                if (ds_userinfo.Tables[0] != null)
                                {
                                    if (ds_userinfo.Tables[0].Rows.Count > 0)
                                    {
                                        //�ж���Ч��
                                        if (ds_userinfo.Tables[0].Rows[0]["ENABLE"].ToString() != "N")
                                        {
                                            App.UserAccount.UserInfo = new Class_User();
                                            App.UserAccount.UserInfo.User_id = ds_userinfo.Tables[0].Rows[0]["USER_ID"].ToString();
                                            App.UserAccount.UserInfo.User_name = ds_userinfo.Tables[0].Rows[0]["USER_NAME"].ToString();
                                            App.UserAccount.UserInfo.U_gender_code = ds_userinfo.Tables[0].Rows[0]["Gender_Code"].ToString();
                                            if (ds_userinfo.Tables[0].Rows[0]["Birthday"].ToString() != "")
                                                App.UserAccount.UserInfo.Birth_date = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["Birthday"].ToString());
                                            App.UserAccount.UserInfo.U_tech_post = ds_userinfo.Tables[0].Rows[0]["U_TECH_POST"].ToString();
                                            App.UserAccount.UserInfo.U_tech_post_name = ds_userinfo.Tables[0].Rows[0]["U_TECH_POST_NAME"].ToString(); ;
                                            App.UserAccount.UserInfo.U_seniority = ds_userinfo.Tables[0].Rows[0]["U_SENIORITY"].ToString();
                                            if (ds_userinfo.Tables[0].Rows[0]["IN_TIME"].ToString() != "")
                                                App.UserAccount.UserInfo.In_time = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["IN_TIME"].ToString());
                                            App.UserAccount.UserInfo.U_position = ds_userinfo.Tables[0].Rows[0]["U_POSITION"].ToString();
                                            App.UserAccount.UserInfo.U_position_name = ds_userinfo.Tables[0].Rows[0]["U_POSITION_NAME"].ToString(); ;
                                            App.UserAccount.UserInfo.U_recipe_power = ds_userinfo.Tables[0].Rows[0]["U_RECIPE_POWER"].ToString();
                                            App.UserAccount.UserInfo.Section_id = ds_userinfo.Tables[0].Rows[0]["SECTION_ID"].ToString();
                                            App.UserAccount.UserInfo.Sickarea_id = ds_userinfo.Tables[0].Rows[0]["SICKAREA_ID"].ToString();
                                            App.UserAccount.UserInfo.Phone = ds_userinfo.Tables[0].Rows[0]["PHONE"].ToString();
                                            App.UserAccount.UserInfo.Mobile_phone = ds_userinfo.Tables[0].Rows[0]["MOBILE_PHONE"].ToString();
                                            App.UserAccount.UserInfo.Email = ds_userinfo.Tables[0].Rows[0]["EMAIL"].ToString();
                                            App.UserAccount.UserInfo.Enable_flag = ds_userinfo.Tables[0].Rows[0]["Enable"].ToString();
                                            App.UserAccount.UserInfo.Profession_card = ds_userinfo.Tables[0].Rows[0]["PROFESSION_CARD"].ToString();
                                            App.UserAccount.UserInfo.Prof_card_name = ds_userinfo.Tables[0].Rows[0]["PROF_CARD_NAME"].ToString();
                                            if (ds_userinfo.Tables[0].Rows[0]["PASS_TIME"].ToString() != "")
                                                App.UserAccount.UserInfo.Pass_time = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["PASS_TIME"].ToString());
                                            if (ds_userinfo.Tables[0].Rows[0]["RECEIVE_TIME"].ToString() != "")
                                                App.UserAccount.UserInfo.Receive_time = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["RECEIVE_TIME"].ToString());
                                            if (ds_userinfo.Tables[0].Rows[0]["REGISTER_TIME"].ToString() != "")
                                                App.UserAccount.UserInfo.Register_time = Convert.ToDateTime(ds_userinfo.Tables[0].Rows[0]["REGISTER_TIME"].ToString());
                                        }
                                        else
                                        {
                                            App.MsgErr("���û���Ч!");
                                            Reflesh();
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        App.MsgErr("���ʺŵ�ǰû���κ��û���Ϣ�����ȸ��ʺ������û���Ϣ!");
                                        return;
                                    }
                                }

                                //��¼��¼ʱ���IP
                                App.ExecuteSQL("update T_ACCOUNT set LAST_LOGIN_IP='" + App.UserAccount.Last_login_ip + "',LAST_LOGIN_TIME=to_timestamp('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff") + "', 'syyyy-mm-dd hh24:mi:ss.ff9'),IS_ONLINE=1 where ACCOUNT_ID=" + App.UserAccount.Account_id + "");

                                /*
                                 *��ȡ��ǰ�ʺ���ӵ�еĽ�ɫ���� 
                                 */
                                IniAccountRoleRanges(txtAccount.Text.ToUpper());
                                if (App.UserAccount.Roles == null)
                                {
                                    App.MsgErr("���ʺ�û�к��κν�ɫ��!");
                                    return;
                                }

                                App.CurrentHospitalId = Convert.ToInt16(ds_account.Tables[0].Rows[0]["HSID"].ToString());
                                frmMain main = new frmMain();
                                //frmMain2018 main = new frmMain2018();
                                this.Hide();
                                main.Show();
                                App.SendtoServerMes.Start();
                            }
                            else
                            {
                                App.MsgErr("�˹�����Ч!");
                                Reflesh();
                            }
                        }
                        else
                        {
                            App.MsgErr("�ʺŻ����벻��ȷ!");
                            Reflesh();
                        }
                    }
                    else
                    {
                        App.MsgErr("�ʺŻ����벻��ȷ!");
                        Reflesh();
                    }
                }
                else
                {
                    //��ʱ�˻�
                    DataSet ds_account = App.GetDataSet("select * from T_TEMP_ACCOUNT where ACCOUNT_NAME='" + txtAccount.Text + "' and PASSWORD='" + Encrypt.EncryptStr(txtPassword.Text) + "'");
                    if (ds_account.Tables[0].Rows.Count > 0)
                    {
                        App.UserAccount = new Class_Account();
                        App.UserAccount.Account_id = ds_account.Tables[0].Rows[0]["ACCOUNT_ID"].ToString();
                        App.UserAccount.Account_name = ds_account.Tables[0].Rows[0]["ACCOUNT_NAME"].ToString();
                        App.UserAccount.Password = ds_account.Tables[0].Rows[0]["PASSWORD"].ToString();
                        App.UserAccount.CurrentSelectRole = null;
                        App.UserAccount.UserInfo = null;
                        this.Close();
                        frmMain main = new frmMain();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        App.MsgErr("�ʺŻ����벻��ȷ!");
                        Reflesh();
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("��¼ʧ��!ԭ��" + ex.Message);
                Application.Exit();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ds">���ݼ���</param>
        private void IniAppAccountinfo(DataSet ds)
        {
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    /*
                     * ��ȡ��ǰ�ʺ���Ϣ
                     */
                    App.UserAccount = new Class_Account();
                    App.UserAccount.Account_id = ds.Tables["account"].Rows[0]["ACCOUNT_ID"].ToString();
                    App.UserAccount.Account_type = ds.Tables["account"].Rows[0]["ACCOUNT_TYPE"].ToString();
                    App.UserAccount.Account_name = ds.Tables["account"].Rows[0]["ACCOUNT_NAME"].ToString();
                    App.UserAccount.Password = ds.Tables["account"].Rows[0]["PASSWORD"].ToString();
                    App.UserAccount.Enable = ds.Tables["account"].Rows[0]["ENABLE"].ToString();
                    if (App.isNumval(ds.Tables["account"].Rows[0]["KIND"].ToString()))
                        App.UserAccount.Kind = Convert.ToInt16(ds.Tables["account"].Rows[0]["KIND"].ToString());
                    App.UserAccount.Last_login_ip = App.GetHostIp();

                    /*
                    *��ȡ��ǰ�ʺ���ӵ�еĽ�ɫ���� 
                    */
                    if (ds.Tables["role"] != null)
                    {
                        App.UserAccount.Roles = new Class_Role[ds.Tables["role"].Rows.Count];
                        for (int i = 0; i < ds.Tables["role"].Rows.Count; i++)
                        {
                            App.UserAccount.Roles[i] = new Class_Role();
                            App.UserAccount.Roles[i].Role_id = ds.Tables["role"].Rows[i]["ROLE_ID"].ToString();
                            App.UserAccount.Roles[i].Role_name = ds.Tables["role"].Rows[i]["ROLE_NAME"].ToString();
                            App.UserAccount.Roles[i].Enable = ds.Tables["role"].Rows[i]["ENABLE_FLAG"].ToString();
                            App.UserAccount.Roles[i].Section_Id = ds.Tables["role"].Rows[i]["SECTION_ID"].ToString();
                            App.UserAccount.Roles[i].Sickarea_Id = ds.Tables["role"].Rows[i]["SICKAREA_ID"].ToString();
                            App.UserAccount.Roles[i].Role_type = ds.Tables["role"].Rows[i]["ROLE_TYPE"].ToString();

                            /*
                             * ��ȡÿ��Ȩ������Ӧ�����÷�Χ      
                             */
                            DataRow[] rows = ds.Tables["ranges"].Select("role_id=" + App.UserAccount.Roles[i].Role_id + "");
                            App.UserAccount.Roles[i].Rnages = new Class_Rnage[rows.Length];
                            for (int j1 = 0; j1 < rows.Length; j1++)
                            {
                                App.UserAccount.Roles[i].Rnages[j1] = new Class_Rnage();
                                App.UserAccount.Roles[i].Rnages[j1].Id = rows[j1]["id"].ToString();
                                App.UserAccount.Roles[i].Rnages[j1].Section_id = rows[j1]["section_id"].ToString();
                                App.UserAccount.Roles[i].Rnages[j1].Sickarea_id = rows[j1]["sickarea_id"].ToString();
                                App.UserAccount.Roles[i].Rnages[j1].Acc_role_id = rows[j1]["acc_role_id"].ToString();
                                App.UserAccount.Roles[i].Rnages[j1].Isbelonge = rows[j1]["isbelongto"].ToString();
                                //App.UserAccount.Roles[i].Rnages[j1].Shid = rows[j1]["shid"].ToString();
                                //0���� 1����
                                if (App.UserAccount.Roles[i].Rnages[j1].Isbelonge == "0")
                                {
                                    string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SECTIONINFO b on a.shid=b.shid where b.sid=" + rows[j1]["section_id"].ToString() + "", 0, "sub_hospital_name");
                                    App.UserAccount.Roles[i].Rnages[j1].Rnagename = HospitalName + "--" + rows[j1]["section_name"].ToString();
                                }
                                else
                                {
                                    string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SICKAREAINFO b on a.shid=b.shid where b.said=" + rows[j1]["sickarea_id"].ToString() + "", 0, "sub_hospital_name");
                                    App.UserAccount.Roles[i].Rnages[j1].Rnagename = HospitalName + "--" + rows[j1]["sick_area_name"].ToString();
                                }
                            }
                        }
                    }

                    /*
                     * ��ȡ��ǰ�ʺ�����Ӧ���û���Ϣ                     
                     */
                    if (ds.Tables["userinfo"] != null)
                    {
                        if (ds.Tables["userinfo"].Rows.Count > 0)
                        {
                            App.UserAccount.UserInfo = new Class_User();
                            App.UserAccount.UserInfo.User_id = ds.Tables["userinfo"].Rows[0]["USER_ID"].ToString();
                            App.UserAccount.UserInfo.User_name = ds.Tables["userinfo"].Rows[0]["USER_NAME"].ToString();
                            App.UserAccount.UserInfo.U_gender_code = ds.Tables["userinfo"].Rows[0]["Gender_Code"].ToString();
                            App.UserAccount.UserInfo.Birth_date = Convert.ToDateTime(ds.Tables["userinfo"].Rows[0]["Birthday"].ToString());
                            App.UserAccount.UserInfo.U_tech_post = ds.Tables["userinfo"].Rows[0]["U_TECH_POST"].ToString();
                            App.UserAccount.UserInfo.U_tech_post_name = ds.Tables["userinfo"].Rows[0]["U_TECH_POST_NAME"].ToString(); ;
                            App.UserAccount.UserInfo.U_seniority = ds.Tables["userinfo"].Rows[0]["U_SENIORITY"].ToString();
                            App.UserAccount.UserInfo.In_time = Convert.ToDateTime(ds.Tables["userinfo"].Rows[0]["IN_TIME"].ToString());
                            App.UserAccount.UserInfo.U_position = ds.Tables["userinfo"].Rows[0]["U_POSITION"].ToString();
                            App.UserAccount.UserInfo.U_position_name = ds.Tables["userinfo"].Rows[0]["U_POSITION_NAME"].ToString(); ;
                            App.UserAccount.UserInfo.U_recipe_power = ds.Tables["userinfo"].Rows[0]["U_RECIPE_POWER"].ToString();
                            App.UserAccount.UserInfo.Section_id = ds.Tables["userinfo"].Rows[0]["SECTION_ID"].ToString();
                            App.UserAccount.UserInfo.Sickarea_id = ds.Tables["userinfo"].Rows[0]["SICKAREA_ID"].ToString();
                            App.UserAccount.UserInfo.Phone = ds.Tables["userinfo"].Rows[0]["PHONE"].ToString();
                            App.UserAccount.UserInfo.Mobile_phone = ds.Tables["userinfo"].Rows[0]["MOBILE_PHONE"].ToString();
                            App.UserAccount.UserInfo.Email = ds.Tables["userinfo"].Rows[0]["EMAIL"].ToString();
                            App.UserAccount.UserInfo.Enable_flag = ds.Tables["userinfo"].Rows[0]["Enable"].ToString();
                            App.UserAccount.UserInfo.Profession_card = ds.Tables["userinfo"].Rows[0]["PROFESSION_CARD"].ToString();
                            App.UserAccount.UserInfo.Prof_card_name = ds.Tables["userinfo"].Rows[0]["PROF_CARD_NAME"].ToString();
                            App.UserAccount.UserInfo.Pass_time = Convert.ToDateTime(ds.Tables["userinfo"].Rows[0]["PASS_TIME"].ToString());
                            App.UserAccount.UserInfo.Receive_time = Convert.ToDateTime(ds.Tables["userinfo"].Rows[0]["RECEIVE_TIME"].ToString());
                            App.UserAccount.UserInfo.Register_time = Convert.ToDateTime(ds.Tables["userinfo"].Rows[0]["REGISTER_TIME"].ToString());
                        }
                    }
                    //��¼��¼ʱ���IP
                    App.ExecuteSQL("update T_ACCOUNT set LAST_LOGIN_IP='" + App.UserAccount.Last_login_ip + "',LAST_LOGIN_TIME=to_timestamp('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff") + "', 'syyyy-mm-dd hh24:mi:ss.ff9'),IS_ONLINE=1 where ACCOUNT_ID=" + App.UserAccount.Account_id + "");
                }
            }
        }


        /// <summary>
        /// ��ȡȨ�޼��϶��Ժ
        /// </summary>
        private void IniAccountRoleRanges(string accountname)
        {
            Bifrost.WebReference.Class_Table[] tabSqls = new Bifrost.WebReference.Class_Table[2];
            DataSet ds;
            ArrayList Roles = new ArrayList();
            if (App.HosptalIds != null)
            {
                for (int i = 0; i < App.HosptalIds.Length; i++)
                {

                    //App.ServerList2=App.GetServerListByHospitalId(App.ServerList, Convert.ToInt16(App.HosptalIds[i]));
                    App.CurrentHospitalId = Convert.ToInt16(App.HosptalIds[i]);
                    tabSqls[0] = new Bifrost.WebReference.Class_Table();
                    tabSqls[0].Sql = "select * from T_ROLE where ROLE_ID in (select ROLE_ID from T_ACC_ROLE where ACCOUNT_ID=(Select ACCOUNT_ID from T_ACCOUNT where upper(ACCOUNT_NAME)='" + accountname.ToUpper() + "')) and enable_flag='Y'";
                    tabSqls[0].Tablename = "role";

                    tabSqls[1] = new Bifrost.WebReference.Class_Table();
                    string Sql_range = "select a.id,a.acc_role_id,a.section_id,a.sickarea_id,a.isbelongto,c.section_name,d.sick_area_name,b.role_id from T_ACC_ROLE_RANGE a left join T_ACC_ROLE b on a.acc_role_id=b.id left join T_SECTIONINFO c on a.section_id=c.sid left join T_SICKAREAINFO d on a.sickarea_id=d.said ";
                    tabSqls[1].Sql = Sql_range + " where b.account_id in (select ACCOUNT_ID from T_ACCOUNT where upper(ACCOUNT_NAME)='" + accountname.ToUpper() + "')";
                    tabSqls[1].Tablename = "ranges";
                    ds = App.GetDataSet(tabSqls);
                    if (ds.Tables["role"] != null)
                    {
                        Class_Role temprole;
                        for (int j = 0; j < ds.Tables["role"].Rows.Count; j++)
                        {
                            temprole = new Class_Role();
                            temprole.Role_id = ds.Tables["role"].Rows[j]["ROLE_ID"].ToString();
                            temprole.Role_name = ds.Tables["role"].Rows[j]["ROLE_NAME"].ToString();
                            temprole.Enable = ds.Tables["role"].Rows[j]["ENABLE_FLAG"].ToString();
                            temprole.Section_Id = ds.Tables["role"].Rows[j]["SECTION_ID"].ToString();
                            temprole.Sickarea_Id = ds.Tables["role"].Rows[j]["SICKAREA_ID"].ToString();
                            temprole.Role_type = ds.Tables["role"].Rows[j]["ROLE_TYPE"].ToString();
                            temprole.Sub_hospital = App.CurrentHospitalId.ToString();

                            /*
                             * ��ȡÿ��Ȩ������Ӧ�����÷�Χ      
                             */
                            DataRow[] rows = ds.Tables["ranges"].Select("role_id=" + temprole.Role_id + "");
                            temprole.Rnages = new Class_Rnage[rows.Length];
                            if (rows.Length == 0)
                            {
                                //if (temprole.Sub_hospital == "1" || temprole.Sub_hospital == "2")
                                //{
                                    temprole.Role_name = temprole.Role_name;
                                //}
                                //else if (temprole.Sub_hospital == "201")
                                //{
                                //    temprole.Role_name = temprole.Role_name + "--��Ժ";
                                //}
                            }
                            for (int j1 = 0; j1 < rows.Length; j1++)
                            {
                                temprole.Rnages[j1] = new Class_Rnage();
                                temprole.Rnages[j1].Id = rows[j1]["id"].ToString();
                                temprole.Rnages[j1].Section_id = rows[j1]["section_id"].ToString();
                                temprole.Rnages[j1].Sickarea_id = rows[j1]["sickarea_id"].ToString();
                                temprole.Rnages[j1].Acc_role_id = rows[j1]["acc_role_id"].ToString();
                                temprole.Rnages[j1].Isbelonge = rows[j1]["isbelongto"].ToString();
                                temprole.Rnages[j1].Shid = App.CurrentHospitalId.ToString();
                                //0���� 1����
                                if (temprole.Rnages[j1].Isbelonge == "0")
                                {
                                    string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SECTIONINFO b on a.shid=b.shid where b.sid=" + rows[j1]["section_id"].ToString() + "", 0, "sub_hospital_name");
                                    temprole.Rnages[j1].Rnagename =  rows[j1]["section_name"].ToString();
                                }
                                else
                                {
                                    string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SICKAREAINFO b on a.shid=b.shid where b.said=" + rows[j1]["sickarea_id"].ToString() + "", 0, "sub_hospital_name");
                                    temprole.Rnages[j1].Rnagename = rows[j1]["sick_area_name"].ToString();
                                }
                            }
                            Roles.Add(temprole);
                        }
                    }
                }
                App.UserAccount.Roles = new Class_Role[Roles.Count];
                for (int j = 0; j < Roles.Count; j++)
                {
                    App.UserAccount.Roles[j] = Roles[j] as Class_Role;
                }
            }
            else
            {
                /*
                 * ��û�л�ö��Ժ�������б�ʱ
                 */
                tabSqls[0] = new Bifrost.WebReference.Class_Table();
                tabSqls[0].Sql = "select * from T_ROLE where ROLE_ID in (select ROLE_ID from T_ACC_ROLE where ACCOUNT_ID=(Select ACCOUNT_ID from T_ACCOUNT where upper(ACCOUNT_NAME)='" + accountname.ToUpper() + "')) and enable_flag='Y'";
                tabSqls[0].Tablename = "role";

                tabSqls[1] = new Bifrost.WebReference.Class_Table();
                string Sql_range = "select a.id,a.acc_role_id,a.section_id,a.sickarea_id,a.isbelongto,c.section_name,d.sick_area_name,b.role_id from T_ACC_ROLE_RANGE a left join T_ACC_ROLE b on a.acc_role_id=b.id left join T_SECTIONINFO c on a.section_id=c.sid left join T_SICKAREAINFO d on a.sickarea_id=d.said ";
                tabSqls[1].Sql = Sql_range + " where b.account_id in (select ACCOUNT_ID from T_ACCOUNT where upper(ACCOUNT_NAME)='" + accountname.ToUpper() + "')";
                tabSqls[1].Tablename = "ranges";
                ds = App.GetDataSet(tabSqls);

                if (ds.Tables["role"] != null)
                {
                    Class_Role temprole;
                    for (int i = 0; i < ds.Tables["role"].Rows.Count; i++)
                    {
                        temprole = new Class_Role();
                        temprole.Role_id = ds.Tables["role"].Rows[i]["ROLE_ID"].ToString();
                        temprole.Role_name = ds.Tables["role"].Rows[i]["ROLE_NAME"].ToString();
                        temprole.Enable = ds.Tables["role"].Rows[i]["ENABLE_FLAG"].ToString();
                        temprole.Section_Id = ds.Tables["role"].Rows[i]["SECTION_ID"].ToString();
                        temprole.Sickarea_Id = ds.Tables["role"].Rows[i]["SICKAREA_ID"].ToString();
                        temprole.Role_type = ds.Tables["role"].Rows[i]["ROLE_TYPE"].ToString();

                        /*
                         * ��ȡÿ��Ȩ������Ӧ�����÷�Χ      
                         */
                        DataRow[] rows = ds.Tables["ranges"].Select("role_id=" + temprole.Role_id + "");
                        temprole.Rnages = new Class_Rnage[rows.Length];
                        for (int j1 = 0; j1 < rows.Length; j1++)
                        {
                            temprole.Rnages[j1] = new Class_Rnage();
                            temprole.Rnages[j1].Id = rows[j1]["id"].ToString();
                            temprole.Rnages[j1].Section_id = rows[j1]["section_id"].ToString();
                            temprole.Rnages[j1].Sickarea_id = rows[j1]["sickarea_id"].ToString();
                            temprole.Rnages[j1].Acc_role_id = rows[j1]["acc_role_id"].ToString();
                            temprole.Rnages[j1].Isbelonge = rows[j1]["isbelongto"].ToString();
                            //temprole.Rnages[j1].Shid = rows[j1]["shid"].ToString();
                            //0���� 1����
                            if (temprole.Rnages[j1].Isbelonge == "0")
                            {
                                string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SECTIONINFO b on a.shid=b.shid where b.sid=" + rows[j1]["section_id"].ToString() + "", 0, "sub_hospital_name");
                                temprole.Rnages[j1].Rnagename = HospitalName + "--" + rows[j1]["section_name"].ToString();
                            }
                            else
                            {
                                string HospitalName = App.ReadSqlVal("select a.sub_hospital_name from t_sub_hospitalinfo a inner join T_SICKAREAINFO b on a.shid=b.shid where b.said=" + rows[j1]["sickarea_id"].ToString() + "", 0, "sub_hospital_name");
                                temprole.Rnages[j1].Rnagename = HospitalName + "--" + rows[j1]["sick_area_name"].ToString();
                            }
                        }
                        Roles.Add(temprole);
                    }

                    App.UserAccount.Roles = new Class_Role[Roles.Count];
                    for (int i = 0; i < Roles.Count; i++)
                    {
                        App.UserAccount.Roles[i] = Roles[i] as Class_Role;
                    }

                }
            }
        }

        private void txtAccount_Leave(object sender, EventArgs e)
        {
        }

        private void txtAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSure_Click(sender, e);
            }
        }

        private void btnSure_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblVersion_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void lblVersion_DragLeave(object sender, EventArgs e)
        {

        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {

        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        /// <summary>
        /// �ֶ����²���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            App.Write_ConfigInfo("WebServerPath", "Version", Encrypt.EncryptStr("1"), Application.StartupPath + "\\Config.ini");
            isUpdate = true;
            Application.ExitThread();
            Application.Exit();
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            if (App.OtherSystemAccount != "")
            {
                this.Hide();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {           
            Application.ExitThread();
        }

        private void txtAccount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}