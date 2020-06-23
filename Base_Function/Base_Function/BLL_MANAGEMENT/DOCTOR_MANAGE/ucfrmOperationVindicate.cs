using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using C1.Win.C1FlexGrid;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    /// <summary>
    /// ����ά��
    /// </summary>
    /// ���� ��ΰ
    /// ʱ�� 2010��9��14��
    public partial class ucfrmOperationVindicate : UserControl
    {
        UserRights userRights = new UserRights();
        public ucfrmOperationVindicate()
        {

            try
            {
                InitializeComponent();
                ffding = new ucLeverContact("��");
                ffbing = new ucLeverContact("��");
                ffyi = new ucLeverContact("��");
                ffjia = new ucLeverContact("��");

                ffding.Height = 172;
                ffding.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffding);

                ffbing.Height = 172;
                ffbing.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffbing);

                ffyi.Height = 172;
                ffyi.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffyi);


                ffjia.Height = 172;
                ffjia.Dock = System.Windows.Forms.DockStyle.Top;

                panel4.Controls.Add(ffjia);
                SetucC1FlexGrid3();
                SettabPages4();
            }
            catch 
            {
                
            }

        }
        public ucfrmOperationVindicate(ArrayList buttonRights)
        {

            try
            {
                InitializeComponent();
                ffding = new ucLeverContact("��");
                ffbing = new ucLeverContact("��");
                ffyi = new ucLeverContact("��");
                ffjia = new ucLeverContact("��");

                ffding.Height = 172;
                ffding.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffding);

                ffbing.Height = 172;
                ffbing.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffbing);

                ffyi.Height = 172;
                ffyi.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffyi);


                ffjia.Height = 172;
                ffjia.Dock = System.Windows.Forms.DockStyle.Top;

                panel4.Controls.Add(ffjia);
                SetucC1FlexGrid3();
                SettabPages4();
                //��ѯ
                this.btnQuery.Enabled = false;
                this.btnSheDing.Enabled = false;
                //ȷ��
                this.btnconfirm.Enabled = false;
                this.btnQueDing.Enabled = false;
                this.btnConfirmTeShu.Enabled = false;
                //���
                this.btnAdd.Enabled = false;
                //�޸�
                this.btnUpdate.Enabled = false;
                //ȡ��
                this.btnCancel.Enabled = false;
                //ɾ��
                this.btnDelete.Enabled = false;
                //�鿴��Ȩ��
                if (userRights.isExistRole("tsbtnLook", buttonRights))
                {
                    this.btnQuery.Enabled = true;
                    this.btnSheDing.Enabled = true;
                }
                //��д��Ȩ��
                if (userRights.isExistRole("tsbtnWrite", buttonRights))
                {
                    this.btnAdd.Enabled = true;
                    this.btnconfirm.Enabled = true;
                    this.btnQueDing.Enabled = true;
                    this.btnConfirmTeShu.Enabled = true;
                    this.btnCancel.Enabled = true;
                }
                //�޸ĵ�Ȩ��
                if (userRights.isExistRole("tsbtnModify", buttonRights))
                {
                    this.btnUpdate.Enabled = true;
                    this.btnQueDing.Enabled = true;
                    this.btnCancel.Enabled = true;
                }
                //ɾ����Ȩ��
                if (userRights.isExistRole("tsbtnDelete", buttonRights))
                {
                    this.btnDelete.Enabled = true;
                }
            }
            catch
            {

            }

        }
        ucLeverContact ffjia;
        ucLeverContact ffyi;
        ucLeverContact ffbing;
        ucLeverContact ffding;


        int rowsSel = 0;
        Dictionary<int, bool[]> Checks = new Dictionary<int, bool[]>();

        private ArrayList Sqls = new ArrayList();//���� ������ұ����� ɾ�����ұ�����sql���
        private ArrayList SqlsTeShu = new ArrayList();

        //����������������
        private List<ucLeverContact> list = new List<ucLeverContact>();
        
        ucLeverContact ff;//�����������û��ؼ�
        private void SettabPages4()
        {
            list.Clear();
            this.panel2.Controls.Clear();//���Ȱ�ȫ��panel2�������������ȫ�����
            for (int i = this.ucC1FlexGrid3.fg.Rows.Count - 1; i > 0; i--)
            {
                string str = "������������";
                /*
                 * ˼·����:��Ŀ���ͳ���̫������Ҫ���У�ÿ�ж���6�����ȣ�����6�����ȵľ���6��
                 * ���Ⱥ���Ӹ�\n
                 */
                //����ԭ������Ŀ����ֵ
                string ucc1Value = ucC1FlexGrid3.fg[i, "��Ŀ����"].ToString();
                //���廻�к��ֵ

                string old = "";
                //��¼���Ҫ����\nʱ�ĳ��ȵ�ֵ
                int sd = 0;
                //ÿ��6�����ȾͲ���һ��\n
                for (int j = 0; j <= ucc1Value.Length; j += 6)
                {
                    //���Ȳ�����0��ʱ��
                    if (j != 0)
                    {
                        //���ֵ�ͽ�ȡ6�����ȳ������Ӹ����н�ȥ
                        old += ucc1Value.Substring(j - 6, 6) + "\n";
                    }
                    //���ջ���ʱ�ĳ���ֵ
                    sd = j;
                }
                //��������\n��֮���ֲ���6���ģ���Ҫ�����ӽ�ȥ
                if (ucc1Value.Length - sd > 0 && ucc1Value.Length > 6)
                {
                    //�ѻ����еģ�6�����ȣ��Ͳ���6�����ȵ�ֵ������
                    old = old + ucc1Value.Substring(sd, ucc1Value.Length - sd);
                    //Font a = new FontSize();

                    //FontSize a = FontSize.Find(1);
                    //System.Drawing.Font a = new Font(old,9F,FontStyle.Bold);
                }
                else
                {
                    //û��6�����ȵ�ֵ
                    old = ucc1Value;
                    Font a = new Font(old, 10);
                }
                ff = new ucLeverContact(old, str, 9);

                ff.Tag = this.ucC1FlexGrid3.fg[i, "ID"].ToString();//��ID����
                ff.SetTeShuChecked(ff.Tag.ToString());//�������ݱ������ID��Ӧ�Ĳ�ѯ��ѡ�е�ҽ��
                ff.Height = 172;
                ff.Dock = System.Windows.Forms.DockStyle.Top;
                list.Add(ff);//�ü��ϰ�ÿ������������������
                this.panel2.Controls.Add(ff);//��ʾ
            }
        }

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        private void SetUCflgview()
        {
            string qureySql = "select Oper_level as �����ȼ�, is_appr as �Ƿ�����2,oper_code as ��������," +
                            " name as ��������,code as ICD9����,shortcut1 as " +
                            " ƴ����, shortcut2 as �����,is_enable as �Ƿ���Ч2 from oper_def_icd9 where 1=1 ";
            ds = App.GetDataSet(qureySql);
            dt = ds.Tables[0];

            DataColumn dc = new DataColumn("�Ƿ�����", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("�Ƿ���Ч", typeof(string));
            //dc.DefaultValue = false;
            dt.Columns.Add(dc1);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["�Ƿ�����"] = dt.Rows[i]["�Ƿ�����2"].ToString() == "Y" ? true : false;
                dt.Rows[i]["�Ƿ���Ч"] = dt.Rows[i]["�Ƿ���Ч2"].ToString() == "Y" ? "��" : "��";
            }
            this.ucC1FlexGridOperation.fg.DataSource = dt;

            this.ucC1FlexGridOperation.fg.Cols["�Ƿ�����"].Move(2);
            CellStyle cs = this.ucC1FlexGridOperation.fg.Styles.Add("�����ȼ�");
            cs.DataType = typeof(string);
            this.ucC1FlexGridOperation.fg.Cols["�����ȼ�"].Style.ComboList = " |��|��|��|��";

            this.ucC1FlexGridOperation.fg.Cols["�Ƿ�����2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["�Ƿ�����2"].AllowEditing = false;

            this.ucC1FlexGridOperation.fg.Cols["�Ƿ���Ч2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["�Ƿ���Ч2"].AllowEditing = false;

            ucC1FlexGridOperation.fg.Cols["�����ȼ�"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["�Ƿ�����"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["��������"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["��������"].Width = 300;
            ucC1FlexGridOperation.fg.Cols["ICD9����"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["ƴ����"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["�����"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["�Ƿ���Ч"].Width = 100;

            ucC1FlexGridOperation.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            for (int i = 0; i < ucC1FlexGridOperation.fg.Cols.Count; i++)
            {
                ucC1FlexGridOperation.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
            }

        }

        private void SetViSible(object sender, EventArgs e)
        {
            this.ucC1FlexGridOperation.fg.Cols["�Ƿ�����2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["�Ƿ�����2"].AllowEditing = false;

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucLeverContact1_TabIndexChanged(object sender, EventArgs e)
        {
        }
        
        private void btnConfirmTeShu_Click(object sender, EventArgs e)
        {
            string delectSql = "delete from T_SPECIALOPER_LEVEL_RELA";
            App.ExecuteSQL(delectSql);
            //SqlsTeShu.Add(delectSql);
            for (int i = 0; i < list.Count; i++)
            {
                //��ÿ����������ѡ�еĹ�����ҽ����ӵ����ݿ�
                list[i].getInsertTeShuSql();
            }
            list.Clear();
            App.Msg("�����Ѿ��ɹ���");
        }
        private void btnconfirm_Click(object sender, EventArgs e)
        {
            string sql = "delete from T_OPER_LEVEL_RELA";
            Sqls.Add(sql);//��ɾ�������ӽ�ȥ����
            ffding.getInsertSql(ref Sqls);//���һ���ȼ��Ƕ���sql���
            ffbing.getInsertSql(ref Sqls);//���һ���ȼ��Ǳ���sql���
            ffyi.getInsertSql(ref Sqls);//���һ���ȼ����ҵ�sql���
            ffjia.getInsertSql(ref Sqls);//���һ���ȼ��Ǽ׵�sql���

            string[] strsqls = new string[Sqls.Count];//�����string���� ��������sqls����
            for (int i = 0; i < Sqls.Count; i++)
            {
                strsqls[i] = Sqls[i].ToString();//��sqls��ÿһ�ֵ��strsqls
            }
            if (App.ExecuteBatch(strsqls) > 0)//һ��ִ��
            {
                App.Msg("�����Ѿ��ɹ���");
            }
        }
        /// <summary>
        /// �ȼ��趨
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSheDing_Click(object sender, EventArgs e)
        {
            this.btnSheDing.Enabled = false;//��ť�ҵ�
            this.Cursor = Cursors.WaitCursor;//�������ɳ©״
            string updateSQL = "";
            List<string> list = new List<string>();//����Ҫ�޸ĵ������ȼ�(ȫ��)
            for (int i = 1; i < ucC1FlexGridOperation.fg.Rows.Count; i++)
            {
                string dengji = ucC1FlexGridOperation.fg[i, 1].ToString();//��ȡÿ���е�һ�еĵȼ�
                string appr = "";
                string code = ucC1FlexGridOperation.fg[i, 6].ToString();
                if (ucC1FlexGridOperation.fg[i, 2].ToString().ToLower() == "true")
                {
                    appr = "Y";
                }
                else
                {
                    appr = "N";
                }
                updateSQL = "update oper_def_icd9 set oper_level='" + dengji + "',is_appr='" + appr + "' where code='" + code + "'";
                list.Add(updateSQL);
            }
            //ToArray�Ǹ��Ƶ�һ������������
            if (App.ExecuteBatch(list.ToArray()) > 0)
            {
                App.Msg("�����ȼ��趨�ɹ�");
                this.btnSheDing.Enabled = true;//�����ԭ����״
                this.Cursor = Cursors.Default;
                list.Clear();//���
                SetUCflgview();//ˢ��
            }
        }
        //������������
        private void SetucC1FlexGrid3()
        {
            string querySQl = "select ID as ID,RECORD_TIME as �������,TYPE_VALUE as ��Ŀ����,RECORDBY_NAME as �ϱ��� from T_SPECIALOPER_TYPE";
            ucC1FlexGrid3.DataBd(querySQl, "ID", "", "");
            ucC1FlexGrid3.fg.Cols["ID"].Width = 100;
            ucC1FlexGrid3.fg.Cols["�������"].Width = 270;
            ucC1FlexGrid3.fg.Cols["��Ŀ����"].Width = 500;
            ucC1FlexGrid3.fg.Cols["�ϱ���"].Width = 150;
            ucC1FlexGrid3.fg.AllowEditing = false;
            ucC1FlexGrid3.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            for (int j = 0; j < ucC1FlexGrid3.fg.Cols.Count; j++)
            {
                ucC1FlexGrid3.fg.Cols[j].TextAlign = TextAlignEnum.CenterCenter;
            }
            //int i = ucC1FlexGrid3.fg.Rows.Count;
        }

        private void ucC1FlexGrid3_Load(object sender, EventArgs e)
        {
            //SetucC1FlexGrid3();
            this.txtUserName.Text = App.UserAccount.UserInfo.User_name;
            this.txtProjectType.Enabled = false;
            this.txtUserName.Enabled = false;
            this.btnQueDing.Enabled = false;
            this.btnCancel.Enabled = false;
            ucC1FlexGrid3.fg.Click += new EventHandler(ucC1FlexGrid3_Click);
            ucC1FlexGrid3.fg.Cols["ID"].Width = 100;
            ucC1FlexGrid3.fg.Cols["�������"].Width = 270;
            ucC1FlexGrid3.fg.Cols["��Ŀ����"].Width = 500;
            ucC1FlexGrid3.fg.Cols["�ϱ���"].Width = 150;
            ucC1FlexGrid3.fg.AllowEditing = false;
            ucC1FlexGrid3.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            for (int j = 0; j < ucC1FlexGrid3.fg.Cols.Count; j++)
            {
                ucC1FlexGrid3.fg.Cols[j].TextAlign = TextAlignEnum.CenterCenter;
            }
        }
        bool isAddUpdate = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddUpdate = true;
            this.txtProjectType.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnQueDing.Enabled = true;
            this.btnCancel.Enabled = true;
            this.dateTimePicker1.Text = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
            this.txtProjectType.Text = "";

        }

        private void btnQueDing_Click(object sender, EventArgs e)
        {
            string record_time = this.dateTimePicker1.Text.Trim();
            string tYPE_VALUE = this.txtProjectType.Text.Trim();
            string rECORDBY_NAME = this.txtUserName.Text.Trim();
            string rECORD_BY_ID = App.UserAccount.UserInfo.User_id;
            string iS_STATE = "";
            if (isAddUpdate == true)
            {
                if (this.txtProjectType.Text == "")
                {
                    App.Msg("��Ŀ���Ͳ���Ϊ��");
                    this.txtProjectType.Focus();
                    return;
                }
                //'" + tYPE_VALUE + "','" + record_time + "','" + rECORD_BY_ID + "','" + rECORDBY_NAME + "','" + iS_STATE + "'
                string insertSQL = string.Format("insert into T_SPECIALOPER_TYPE(type_value,record_time,record_by_id,recordby_name,is_state)" +
                  " values('{0}',to_TIMESTAMP('{1}','yyyy-MM-dd hh24:mi:ss'),'{2}','{3}','{4}')", tYPE_VALUE, record_time, rECORD_BY_ID, rECORDBY_NAME, iS_STATE);
                if (App.ExecuteSQL(insertSQL) > 0)
                {
                    App.Msg("��ӳɹ�");
                    this.btnAdd.Enabled = true;
                    this.btnDelete.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnQueDing.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.txtProjectType.Enabled = false;
                    this.dateTimePicker1.Enabled = false;
                    SetucC1FlexGrid3();
                    SettabPages4();
                }
                else
                {
                    App.Msg("���ʧ����");
                    this.btnAdd.Enabled = true;
                    this.btnDelete.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnQueDing.Enabled = false;
                    this.btnCancel.Enabled = false;
                }
            }
            else
            {
                if (rowsSel > 0)
                {
                    if (this.txtProjectType.Text == "")
                    {
                        App.Msg("��Ŀ���Ͳ���Ϊ��");
                        this.txtProjectType.Focus();
                        return;
                    }
                    string updateSQL = "update T_SPECIALOPER_TYPE set record_time=to_TIMESTAMP('" + record_time + "','yyyy-MM-dd hh24:mi:ss'),type_value='" + tYPE_VALUE + "' where ID='" + ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "ID"].ToString() + "'";
                    if (App.ExecuteSQL(updateSQL) > 0)
                    {
                        App.Msg("�޸ĳɹ�");
                        this.btnCancel.Enabled = false;
                        this.btnQueDing.Enabled = false;
                        this.btnAdd.Enabled = true;
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.txtProjectType.Enabled = false;
                        SetucC1FlexGrid3();
                        SettabPages4();

                    }
                    else
                    {
                        App.MsgErr("�˴β���δ�ɹ�");
                    }
                }
                else
                {
                    App.Msg("����û��ѡ��Ҫ�޸ĵ���Ϣ");
                }

            }
        }
        private void ucC1FlexGrid3_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid3.fg.RowSel >= 0)
            {
                ucC1FlexGrid3.fg.AllowEditing = false;
                rowsSel = ucC1FlexGrid3.fg.RowSel;
                this.dateTimePicker1.Text = ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "�������"].ToString();
                this.txtProjectType.Text = ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "��Ŀ����"].ToString();
                this.txtUserName.Text = ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "�ϱ���"].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rowsSel > 0)
            {
                string deleteSQl = "delete T_SPECIALOPER_TYPE where ID='" + ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "ID"].ToString() + "'";
                if (App.Ask("�Ƿ�ȷ��ɾ��"))
                {
                    if (App.ExecuteSQL(deleteSQl) > 0)
                    {
                        App.Msg("ɾ���ɹ�");
                        this.btnCancel.Enabled = false;
                        this.btnQueDing.Enabled = false;
                        this.btnAdd.Enabled = true;
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.txtProjectType.Enabled = false;
                        SetucC1FlexGrid3();
                        SettabPages4();
                    }
                }
            }
            else
            {
                App.Msg("����û��ѡ��Ҫɾ������Ϣ");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rowsSel > 0)
            {
                this.txtProjectType.Enabled = true;
                this.dateTimePicker1.Enabled = true;
                this.txtUserName.Enabled = false;
                this.btnAdd.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnUpdate.Enabled = false;
                this.btnQueDing.Enabled = true;
                this.btnCancel.Enabled = true;
            }
            else
            {
                App.Msg("����û��ѡ��Ҫ�޸ĵ���Ϣ");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = false;
            this.txtProjectType.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnQueDing.Enabled = false;
            this.btnCancel.Enabled = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string qureySql = "select Oper_level as �����ȼ�, is_appr as �Ƿ�����2,oper_code as ��������," +
                            " name as ��������,code as ICD9����,shortcut1 as " +
                            " ƴ����, shortcut2 as �����,is_enable as �Ƿ���Ч2 from oper_def_icd9 where 1=1 ";
            string shoushudaima = this.txtOPSCode.Text;
            string shoushuName = this.txtOPSName.Text;
            string icd9Code = this.txtICD9Code.Text;
            string isavailability = "";
            if (this.cboxIsavailability.Text != "")
            {
                if (this.cboxIsavailability.Text == "��")
                {
                    isavailability = "Y";
                }
                else if (this.cboxIsavailability.Text == "��")
                {
                    isavailability = "N";
                }
                else
                {
                    isavailability = " ";
                }
            }

            if (shoushudaima != "")
            {
                qureySql += " and oper_code like '" + shoushudaima + "%'";
            }
            if (shoushuName != "")
            {
                qureySql += " and name like '" + shoushuName + "%'";
            }
            if (icd9Code != "")
            {
                qureySql += " and code like '" + icd9Code + "%'";
            }
            if (isavailability != "")
            {
                qureySql += " and is_enable = '" + isavailability + "'";
            }

            ds = App.GetDataSet(qureySql);
            dt = ds.Tables[0];

            DataColumn dc = new DataColumn("�Ƿ�����", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("�Ƿ���Ч", typeof(string));
            //dc.DefaultValue = false;
            dt.Columns.Add(dc1);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["�Ƿ�����"] = dt.Rows[i]["�Ƿ�����2"].ToString() == "Y" ? true : false;
                dt.Rows[i]["�Ƿ���Ч"] = dt.Rows[i]["�Ƿ���Ч2"].ToString() == "Y" ? "��" : "��";
            }
            this.ucC1FlexGridOperation.fg.DataSource = dt;

            this.ucC1FlexGridOperation.fg.Cols["�Ƿ�����"].Move(2);
            CellStyle cs = this.ucC1FlexGridOperation.fg.Styles.Add("�����ȼ�");
            cs.DataType = typeof(string);
            this.ucC1FlexGridOperation.fg.Cols["�����ȼ�"].Style.ComboList = " |��|��|��|��";

            this.ucC1FlexGridOperation.fg.Cols["�Ƿ�����2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["�Ƿ�����2"].AllowEditing = false;

            this.ucC1FlexGridOperation.fg.Cols["�Ƿ���Ч2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["�Ƿ���Ч2"].AllowEditing = false;

            ucC1FlexGridOperation.fg.Cols["�����ȼ�"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["�Ƿ�����"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["��������"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["��������"].Width = 300;
            ucC1FlexGridOperation.fg.Cols["ICD9����"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["ƴ����"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["�����"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["�Ƿ���Ч"].Width = 100;

            ucC1FlexGridOperation.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            for (int i = 0; i < ucC1FlexGridOperation.fg.Cols.Count; i++)
            {
                ucC1FlexGridOperation.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
            }
        }

        private void ucfrmOperationVindicate_Load(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGridOperation.fg.Click += new EventHandler(ucC1FlexGridOperation_Click);
                ucC1FlexGridOperation.fg.DoubleClick += new EventHandler(ucC1FlexGridOperation_DoubleClick);

                SetUCflgview();

                ffding.SetChecked();
                ffbing.SetChecked();
                ffyi.SetChecked();
                ffjia.SetChecked();
                ff.SetTeShuChecked(ff.Tag.ToString());
            }
            catch
            {
            }
        }

        private void ucC1FlexGridOperation_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGridOperation.fg.RowSel >= 0)
            {
                if (ucC1FlexGridOperation.fg.ColSel == 1 || ucC1FlexGridOperation.fg.ColSel == 2)
                {
                    ucC1FlexGridOperation.fg.AllowEditing = true;
                }
                else
                {
                    ucC1FlexGridOperation.fg.AllowEditing = false;
                }
            }
        }

        private void ucC1FlexGridOperation_DoubleClick(object sender, EventArgs e)
        {
            if (ucC1FlexGridOperation.fg.RowSel >= 0)
            {
                if (ucC1FlexGridOperation.fg.ColSel == 1 || ucC1FlexGridOperation.fg.ColSel == 2)
                {
                    ucC1FlexGridOperation.fg.AllowEditing = true;
                }
                else
                {
                    ucC1FlexGridOperation.fg.AllowEditing = false;
                }
            }
        }

        private void ucC1FlexGrid3_DoubleClick(object sender, EventArgs e)
        {
            if (ucC1FlexGrid3.fg.RowSel >= 0)
            {
                ucC1FlexGrid3.fg.AllowEditing = false;
            }
        }
    }
}
