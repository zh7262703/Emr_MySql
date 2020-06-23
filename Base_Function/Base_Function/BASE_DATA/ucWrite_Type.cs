using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using DevComponents.AdvTree;
using Base_Function.BASE_COMMON;

namespace Base_Function.BASE_DATA
{
    public partial class ucWrite_Type : UserControl
    {
        private bool isSave;                         //��¼��ǰ����Ϊ������޸� true���� false�޸�
        public static Class_Text Fathernode = null;  //���ڼĴ游�ڵ��ʵ��
        private Class_Text selectClasstext = null;   //���ڼĴ浱ǰѡ�еĽڵ�ʵ��
        public static string fahterId = "0";         //�����ڵ�Ĭ��Ϊ0
        public static string fahterName = "0";       //���ڵ�����
        private string textcode;                     //��ǰѡ�е��������ͱ��
        private string textname;                     //��ǰѡ�е�������������
        private string texttypes;                    //��ǰѡ������ڵ������id
        public string texttypeselect = "";          //��ǰѡ�нڵ����������
        public static string texttype = "";          //���ڵ���������
        private string mark = "Y";                   //��Ч��־
        private string signatrue = "Y";              //�Ƿ���Ҫҽʦǩ����־
        private string isneedsignatrue = "Y";            //�Ƿ���Ҫҽ��ǩ�ֵ�����
        private string isnewpage = "N";              //�Ƿ���Ҫ�ٴ�ӡ��ʱ������һҳ������
        private string issubmitsign = "Y";           //�Ƿ���Ҫ�ύ��ʱ���Զ�ǩ��
        private string isProblemName = "N";          //�Ƿ�����޸ı�������
        private string isProblemTime = "N";          //�Ƿ�����޸ı���ʱ��
        private string isTempSaveSign = "N";         //ʵϰ���ݴ������Ƿ�ǩ��

        public static bool isShowNumChange = false;  //�Ƿ��������仯

        public ucWrite_Type()
        {
            InitializeComponent();

        }


        private void frmWrite_Type_Load(object sender, EventArgs e)
        {
            App.SetMainFrmMsgToolBarText("����������Ϣ");
            Booktype();
            //cmbTypes();
            cboEditor.SelectedIndex = 0;
            cboBookAttribute.SelectedIndex = 0;
            RefleshFrm();
            SectionLoad();
            FixTypes();
            TextSortType();
            
        }
        /// <summary>
        /// �����б����
        /// </summary>
        private void SectionLoad()
        {

            string sql_Section = "select sid,section_name from t_sectioninfo where enable_flag='Y'";
            DataSet ds_section = App.GetDataSet(sql_Section);
            if (ds_section != null)
            {
                DataTable dt = ds_section.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Class_Sections section = new Class_Sections();
                    section.Sid = Convert.ToInt32(row["sid"]);
                    section.Section_Name = row["section_name"].ToString();
                    clbSection.Items.Add(section.Sid + ":" + section.Section_Name);
                }
            }
        }
        ///// <summary>
        ///// ����������
        ///// </summary>
        //private void cmbTypes()
        //{
        //    DataSet dts = App.GetDataSet("select * from T_DATA_CODE where TYPE=31");
        //    cmbType.DataSource = dts.Tables[0].DefaultView;
        //    cmbType.ValueMember = "ID";
        //    cmbType.DisplayMember = "NAME";
        //}
        /// <summary>
        /// ��ӵ�ʱ�����������
        /// </summary>
        private void Booktype()
        {
            DataSet dts = App.GetDataSet("select * from T_DATA_CODE where TYPE=31");
            cboBookType.DataSource = dts.Tables[0].DefaultView;
            cboBookType.ValueMember = "ID";
            cboBookType.DisplayMember = "NAME";
        }

        /// <summary>
        /// ��������
        /// </summary>
        private void TextSortType()
        {
            DataSet ds = App.GetDataSet("select a.code,a.name from t_data_code a inner join t_data_code_type b on a.type=b.id where b.type='pxfa001'");
            cboSortType.DataSource = ds.Tables[0].DefaultView;
            cboSortType.DisplayMember = "name";
            cboSortType.ValueMember = "code";
            cboSortType.SelectedIndex = 0;
        }

        /// <summary>
        /// ���ƽ������� 
        /// </summary>
        private void FixTypes()
        {
            List<FixTypeObject> FixTypeObjects = new List<FixTypeObject>();

            #region ��������
            FixTypeObject temp1 = new FixTypeObject();
            temp1.Code = "";
            temp1.Name = "";
            FixTypeObjects.Add(temp1);

            FixTypeObject ucDIAGNOSIS_CERTIFICATE = new FixTypeObject();
            ucDIAGNOSIS_CERTIFICATE.Code = "ucDIAGNOSIS_CERTIFICATE";
            ucDIAGNOSIS_CERTIFICATE.Name = "���֤��";
            FixTypeObjects.Add(ucDIAGNOSIS_CERTIFICATE);

            FixTypeObject ucTemperPrint = new FixTypeObject();
            ucTemperPrint.Code = "ucTemperPrint";
            ucTemperPrint.Name = "���µ���ӡչʾ";
            FixTypeObjects.Add(ucTemperPrint);

            FixTypeObject frmCases_First = new FixTypeObject();
            frmCases_First.Code = "frmCases_First";
            frmCases_First.Name = "��ҳ";
            FixTypeObjects.Add(frmCases_First);


            
            FixTypeObject ucfrmSickReport = new FixTypeObject();
            ucfrmSickReport.Code = "ucfrmSickReport";
            ucfrmSickReport.Name = "�Ű�����";
            FixTypeObjects.Add(ucfrmSickReport);

            FixTypeObject UcPatientInfo = new FixTypeObject();
            UcPatientInfo.Code = "UcPatientInfo";
            UcPatientInfo.Name = "���˻�����Ϣ";
            FixTypeObjects.Add(UcPatientInfo);

            FixTypeObject UOdinopoeia_Record = new FixTypeObject();
            UOdinopoeia_Record.Code = "UOdinopoeia_Record";
            UOdinopoeia_Record.Name = "���������������󲡳̼�¼";
            FixTypeObjects.Add(UOdinopoeia_Record);

            FixTypeObject ExpectantRecord = new FixTypeObject();
            ExpectantRecord.Code = "ExpectantRecord";
            ExpectantRecord.Name = "������¼";
            FixTypeObjects.Add(ExpectantRecord);

            FixTypeObject ucHeart_PIC = new FixTypeObject();
            ucHeart_PIC.Code = "ucHeart_PIC";
            ucHeart_PIC.Name = "�ĵ�ͼ";
            FixTypeObjects.Add(ucHeart_PIC);

          

            FixTypeObject MUcToolsControl = new FixTypeObject();
            MUcToolsControl.Code = "MUcToolsControl";
            MUcToolsControl.Name = "�༭������";
            FixTypeObjects.Add(MUcToolsControl);

            FixTypeObject ucTempraute = new FixTypeObject();
            ucTempraute.Code = "ucTempraute";
            ucTempraute.Name = "���µ�";
            FixTypeObjects.Add(ucTempraute);

            FixTypeObject ucTempraute_BB = new FixTypeObject();
            ucTempraute_BB.Code = "ucTempraute_BB";
            ucTempraute_BB.Name = "���������µ�";
            FixTypeObjects.Add(ucTempraute_BB);


            FixTypeObject ucPartogram = new FixTypeObject();
            ucPartogram.Code = "ucPartogram";
            ucPartogram.Name = "����ͼ";
            FixTypeObjects.Add(ucPartogram);
            #endregion

            cboFormName.Items.Clear();
            for (int i = 0; i < FixTypeObjects.Count; i++)
            {
                cboFormName.Items.Add(FixTypeObjects[i]);

            }
            cboFormName.DisplayMember = "name";
            cboFormName.ValueMember = "code";
               

        }

        /// <summary>
        /// ʵ��Class_Text����ѯ���
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Text[] GetSelectClassDs(DataSet tempds)
        {

            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {

                    Class_Text[] class_text = new Class_Text[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        class_text[i] = new Class_Text();
                        class_text[i].Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        if (tempds.Tables[0].Rows[i]["PARENTID"] != null)
                        {
                            if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0" && tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "")
                            {
                                class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                            }
                        }
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        textcode = class_text[i].Textcode;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        textname = class_text[i].Textname;
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                        texttypes = class_text[i].Txxttype;
                        class_text[i].Issimpleinstance = tempds.Tables[0].Rows[i]["ISSIMPLEINSTANCE"].ToString();
                        class_text[i].Enable = tempds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                        class_text[i].Shownum = tempds.Tables[0].Rows[i]["shownum"].ToString();
                        class_text[i].Ishighersign = tempds.Tables[0].Rows[i]["ishighersign"].ToString();
                        class_text[i].Ishavetime = tempds.Tables[0].Rows[i]["ishavetime"].ToString();
                        class_text[i].Formname = tempds.Tables[0].Rows[i]["formname"].ToString();
                        class_text[i].Other_textname = tempds.Tables[0].Rows[i]["OTHER_TEXTNAME"].ToString();
                    
                        if (tempds.Tables[0].Rows[i]["RIGHT_RANGE"].ToString() == "")
                        {
                            class_text[i].Right_range="D";
                        }
                        else
                        {
                            class_text[i].Right_range = tempds.Tables[0].Rows[i]["RIGHT_RANGE"].ToString();
                        }
                        if (tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString() == "")
                        {
                            class_text[i].Isneedsign = "Y";
                        }
                        else
                        {
                            class_text[i].Isneedsign = tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISTEMPSAVESIGN"].ToString() == "")
                        {
                            class_text[i].IsTempsavesign = "N";
                        }
                        else
                        {
                            class_text[i].IsTempsavesign = tempds.Tables[0].Rows[i]["ISTEMPSAVESIGN"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISNEWPAGE"].ToString() == "")
                        {
                            class_text[i].Isnewpage = "N";
                        }
                        else
                        {
                            class_text[i].Isnewpage = tempds.Tables[0].Rows[i]["ISNEWPAGE"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISSUBMITSIGN"].ToString() == "")
                        {
                            class_text[i].Issubmitsign = "N";
                        }
                        else
                        {
                            class_text[i].Issubmitsign = tempds.Tables[0].Rows[i]["ISSUBMITSIGN"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISPROBLEM_NAME"].ToString() == "")
                        {
                            class_text[i].IsProblemName = "N";
                        }
                        else
                        {
                            class_text[i].IsProblemName = tempds.Tables[0].Rows[i]["ISPROBLEM_NAME"].ToString();
                        }

                        if (tempds.Tables[0].Rows[i]["ISPROBLEM_TIME"].ToString() == "")
                        {
                            class_text[i].IsProblemTime = "N";
                        }
                        else
                        {
                            class_text[i].IsProblemTime = tempds.Tables[0].Rows[i]["ISPROBLEM_TIME"].ToString();
                        }

                    }
                    return class_text;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ����ID��ȡ�ڵ�
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private Class_Text GetDById(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_TEXT  where ID=" + id + "");
          
            if (ds != null)
            {
                Class_Text[] temps = GetSelectClassDs(ds);
                if (temps != null)
                {
                    if (temps.Length > 0)
                    {
                        return temps[0];
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
            txtFather.Enabled = false;
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtPname.Enabled = false;
            txtOtherTextName.Enabled = false;
            cboEditor.Enabled = false;
            cboBookType.Enabled = false;
            cboBookAttribute.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
           // btnSelectTrv.Enabled = false;
            cboTimeTitle.Enabled = false;           
            cboDoctorOrNuser.Enabled = false;
            rdoNeedSign_Y.Enabled = false;
            rdoNeedSign_N.Enabled = false;
            rdoNewPage_Y.Enabled = false;
            rdoNewPage_N.Enabled = false;
            rdoSubmitAutoSign_Y.Enabled = false;
            rdoSubmitAutoSign_N.Enabled = false;

            isSave = false;

        }
        /// <summary>
        /// �༭״̬
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            trvDictionary.Enabled = false;
            if (flag)
            {
                txtNumber.Text = "";
                txtName.Text = "";
                txtFather.Text = "";
                txtPname.Text = "";//�¼�ƴ�������޸�
                if (Fathernode != null)
                {
                    txtFather.Text = Fathernode.Textname;
                    txtNumber.Text = "";
                    txtName.Text = "";
                    txtPname.Text = "";
                }
                txtOtherTextName.Text = "";

            }
            txtFather.Enabled = true;
            txtNumber.Enabled = true;
            txtName.Enabled = true;
            txtOtherTextName.Enabled = true;
            cboEditor.Enabled = true;
            txtPname.Enabled = true;
            cboBookType.Enabled = true;
            cboBookAttribute.Enabled = true;
            if (cboEditor.Text == "��")
            {
                cboTimeTitle.Enabled = true;
            }
            else
            {
                cboFormName.Enabled = true;
            }
           
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            btnAdd.Enabled = false;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
           // btnSelectTrv.Enabled = true;
            clbSection.Enabled = true;
            rdoSignatrueTrue.Enabled = true;
            rdoSignatrueFalse.Enabled = true;
            btnDelFater.Enabled = true;
            //groupBox1.Enabled = false;
            cboDoctorOrNuser.Enabled = true;


            rdoNeedSign_Y.Enabled = true;
            rdoNeedSign_N.Enabled = true;
            rdoNewPage_Y.Enabled = true;
            rdoNewPage_N.Enabled = true;
            rdoSubmitAutoSign_Y.Enabled = true;
            rdoSubmitAutoSign_N.Enabled = true;
            rdoSave_Y.Enabled = true;
            rdoSave_N.Enabled = true;

            if (cboTimeTitle.Text != "")
            {
                rdoProblemName_Y.Enabled = true;
                rdoProblemName_N.Enabled = true;
                rdoProblemTime_Y.Enabled = true;
                rdoProblemTime_N.Enabled = true;
            }
            else
            {
                rdoProblemName_Y.Enabled = false;
                rdoProblemName_N.Enabled = false;
                rdoProblemTime_Y.Enabled = false;
                rdoProblemTime_N.Enabled = false;
            }
            

            txtNumber.Focus();
        }
        /// <summary>
        /// ���ˢ��
        /// </summary>
        private void refurbish()
        {
            txtNumber.Text = "";
            txtName.Text = "";
            txtPname.Text = "";
            Fathernode = null;
            txtFather.Text = "";           
            txtFather.Enabled = false;
            txtNumber.Enabled = false;
            txtName.Enabled = false;
            txtOtherTextName.Enabled = false;
            cboEditor.Enabled = false;
            txtPname.Enabled = false;
            cboBookType.Enabled = false;
            cboBookAttribute.Enabled = false;
            cboTimeTitle.Enabled = false;
            cboFormName.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
           // btnSelectTrv.Enabled = false;           
            isSave = false;
            clbSection.Enabled = false;
            rdoSignatrueTrue.Enabled = false;
            rdoSignatrueFalse.Enabled = false;
            btnDelFater.Enabled = false;
            cboDoctorOrNuser.Enabled = false;

            rdoNeedSign_Y.Enabled = false;
            rdoNeedSign_N.Enabled = false;
            rdoNewPage_Y.Enabled = false;
            rdoNewPage_N.Enabled = false;
            rdoSubmitAutoSign_Y.Enabled = false;
            rdoSubmitAutoSign_N.Enabled = false;
            trvDictionary.Enabled = true;

            rdoProblemName_Y.Enabled = false;
            rdoProblemName_N.Enabled = false;
            rdoProblemName_N.Checked = true;
            rdoProblemTime_Y.Enabled = false;
            rdoProblemTime_N.Enabled = false;
            rdoProblemTime_N.Checked = true;

            rdoSave_Y.Enabled = false;
            rdoSave_N.Enabled = false;
        }

        /// <summary>
        /// ��������з�������
        /// </summary>
        /// <param Name="Directionarys">��������ڵ㼯��</param>
        /// <param Name="current">��ǰ����ڵ�</param>
        private void SetTreeView(Class_Text[] Directionarys, TreeNode current,DataTable TableSort)
        {

            TableSort.DefaultView.Sort = "shownum asc";
            Class_Text cunrrentDir = (Class_Text)current.Tag;
            DataRow[] sorttemprows = TableSort.Select("parent_id=" + cunrrentDir.Id.ToString()+ "");
            DataRow[] sortrows = DataInit.ReSort(sorttemprows);
            if (sortrows.Length > 0)
            {
                //�������ù����
                for (int k = 0; k < sortrows.Length; k++)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        if (Directionarys[i].Id.ToString() == sortrows[k]["text_id"].ToString())
                        {
                            //�������ƥ������
                            //Class_Text cunrrentDir = (Class_Text)current.Tag;
                            if (Directionarys[i].Parentid == cunrrentDir.Id)
                            {

                                TreeNode tn = new TreeNode();
                                if (Directionarys[i].Enable == "Y")
                                {
                                    tn.Tag = Directionarys[i];
                                    tn.Text = Directionarys[i].Textname;
                                }
                                if (Directionarys[i].Enable == "N")
                                {
                                    tn.Tag = Directionarys[i];
                                    tn.Text = Directionarys[i].Textname;
                                    tn.ForeColor = Color.Gray;
                                }
                                current.Nodes.Add(tn);
                                SetTreeView(Directionarys, tn, TableSort);
                                break;

                            }
                        }
                    }
                }
            }
            else
            {
                //���������������Ϣ
                for (int i = 0; i < Directionarys.Length; i++)
                {
                   
                    //�������ƥ������
                    //Class_Text cunrrentDir = (Class_Text)current.Tag;
                    if (Directionarys[i].Parentid == cunrrentDir.Id)
                    {

                        TreeNode tn = new TreeNode();
                        if (Directionarys[i].Enable == "Y")
                        {
                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;
                        }
                        if (Directionarys[i].Enable == "N")
                        {
                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;
                            tn.ForeColor = Color.Gray;
                        }
                        current.Nodes.Add(tn);
                        SetTreeView(Directionarys, tn, TableSort);
                    }
                }
            }
        }


        /// <summary>
        /// ���ҽ����û�еĸ��ڵ�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string Sel_FDJ_SQL(string sql)
        {
            string sql_sel = "select * from t_text where id in  (select parentid from (" + sql + ") where parentid <>0)";

            string count = App.ReadSqlVal("select count(*) c from (" + sql_sel + ") where parentid<>0", 0, "c");

            if (Convert.ToInt16(count) > 0)
            {
                //δ�ҵ��������ڵ����������
                sql_sel += Sel_FDJ_SQL(sql_sel);
            }
            return "union all " + sql_sel;

        

        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelect.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                trvDictionary.Nodes.Clear();

                //string sqlSort = "select * from t_text_sort where sort_type=" + cboSortType.SelectedValue + " ";
                DataTable TableSort = DataInit.GetTextSortSet(cboSortType.SelectedValue.ToString());//App.GetDataSet(sqlSort).Tables[0]; //��ȡ���������е�������Ϣ
           
               // string SQl = "select * from T_TEXT order by shownum asc";
                string SQl = "select * from t_text where id in (select id from t_text where textname in (select textname from t_text group by textname having count(1) >= 1))";
                if (txtConName.Text.Trim() != "")
                {
                    SQl = "select * from T_TEXT where TEXTNAME like '%" + txtConName.Text.Trim() + "%' ";
                    //���ҽ����û�и��ڵ�
                    SQl += Sel_FDJ_SQL(SQl);
                    //ȥ��
                    SQl = "select distinct * from (" + SQl + ") order by shownum asc";
                    this.Cursor = Cursors.Default;
                }

                DataRow[] toptempRows=TableSort.Select("parent_id=0"); //��ȡ�����ڵ�
                DataRow[] topRows = DataInit.ReSort(toptempRows);//�����ڵ�����


                DataSet ds = new DataSet();
                ds = App.GetDataSet(SQl);
                Class_Text[] Directionarys = GetSelectClassDs(ds);
                if (Directionarys != null)
                {
                    if (topRows.Length > 0)
                    {
                        //���������õ�
                        for (int k = 0; k < topRows.Length; k++)
                        {
                            for (int i = 0; i < Directionarys.Length; i++)
                            {
                                if (topRows[k]["text_id"].ToString() == Directionarys[i].Id.ToString())
                                {
                                    TreeNode tn = new TreeNode();

                                    if (Directionarys[i].Enable == "N")
                                    {

                                        tn.Tag = Directionarys[i];
                                        tn.Text = Directionarys[i].Textname;
                                        tn.ForeColor = Color.Gray;
                                    }
                                    if (Directionarys[i].Enable == "Y")
                                    {
                                        tn.Tag = Directionarys[i];
                                        tn.Text = Directionarys[i].Textname;

                                    }
                                    //���붥���ڵ�
                                    if (Directionarys[i].Parentid == 0)
                                    {
                                        trvDictionary.Nodes.Add(tn);
                                        SetTreeView(Directionarys, tn, TableSort);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        //����������
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            TreeNode tn = new TreeNode();
                            if (Directionarys[i].Enable == "N")
                            {
                                tn.Tag = Directionarys[i];
                                tn.Text = Directionarys[i].Textname;
                                tn.ForeColor = Color.Gray;
                            }
                            if (Directionarys[i].Enable == "Y")
                            {
                                tn.Tag = Directionarys[i];
                                tn.Text = Directionarys[i].Textname;
                            }
                            //���붥���ڵ�
                            if (Directionarys[i].Parentid == 0)
                            {
                                trvDictionary.Nodes.Add(tn);
                                SetTreeView(Directionarys, tn, TableSort);
                            }
                        }
                    }
                    trvDictionary.ExpandAll();

                    if (trvDictionary.Nodes.Count > 0)
                    {
                        this.trvDictionary.Nodes[0].EnsureVisible();
                    }
                   
                }
                else
                {
                    App.Msg("û���ҵ���ѯ�����");
                }
            }
            catch
            {

            }
            finally
            {
                btnSelect.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            
        }

        /// <summary>
        /// �ж��Ƿ��������TEXTNAME
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string name)
        {
            string sql = "select ISBELONGTOTYPE,PARENTID from T_TEXT where TEXTNAME='" + name + "' and PARENTID=" + fahterId + "";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// �ж��Ƿ��������TEXTCODE
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExisitCode(string id)
        {

            string sql = "select  ISBELONGTOTYPE,PARENTID,TEXTCODE from T_TEXT  where  TEXTCODE='" + id + "' and  PARENTID=" + fahterId + " ";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            trvDictionary.SelectedNode = null;
            selectClasstext = null;

            isSave = true;
            //trvDictionary.Enabled = false;
            Edit(isSave);
        }
        /// <summary>
        /// �޸�
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            isSave = false;
            Edit(isSave);
        }
        /// <summary>
        /// ������޸Ĳ���
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ArrayList Sqls = new ArrayList();
            string sid = "";    //�������������,Ĭ��Ϊ�������п���
            if (clbSection.SelectedItems.Count == 0 && clbSection.CheckedItems.Count == 0)
            {
                sid = "0";
            }
            for (int i = 0; i < clbSection.Items.Count; i++)
            {
                if (clbSection.GetItemText(clbSection.Items[i]) == "0:ȫԺ" && clbSection.GetItemChecked(i))  //���ȫԺ��ѡ�У��������SIDֱ����Ϊ0
                {
                    sid = "0";
                    break;
                }
                if (clbSection.GetItemChecked(i))
                {
                    string sectionId = clbSection.GetItemText(clbSection.Items[i]).Substring(0, clbSection.GetItemText(clbSection.Items[i]).IndexOf(":"));
                    sid += sectionId + ",";
                }
            }
            if (txtName.Text.Trim() == "")
            {
                App.Msg("�������Ʊ�����д��");
                txtName.Focus();
                return;
            }
            if (txtPname.Text.Trim() == "")
            {
                App.Msg("������������д��");
                txtPname.Focus();
                return;
            }
            //��Ч��־
            if (rbtnVainmark.Checked == true)
            {
                mark = "N";
            }
            else
            {
                mark = "Y";
            }
            //�ϼ�ҽʦǩ��
            if (rdoSignatrueTrue.Checked == true)
            {
                signatrue = "Y";
            }
            else
            {
                signatrue = "N";
            }
            if (Fathernode != null)
            {
                if (txtFather.Text.Trim() != "")
                {
                    fahterId = Fathernode.Id.ToString();
                    txtFather.Text = fahterId;
                }
            }

            //�Ƿ���Ҫ����һҳ
            if (rdoNewPage_Y.Checked)
            {
                isnewpage = "Y";
            }
            else
            {
                isnewpage = "N";
            }

            //�Ƿ���Ҫҽ��ǩ�ֵ�����
            if (rdoNeedSign_Y.Checked)
            {
                isneedsignatrue = "Y";
            }
            else
            {
                isneedsignatrue = "N";
            }


            //�Ƿ��Զ�ǩ��
            if (rdoSubmitAutoSign_Y.Checked)
            {
                issubmitsign = "Y";
            }
            else
            {
                issubmitsign = "N";
            }

            //�ݴ��Ƿ�ǩ����ʵϰ����
            if (rdoSave_Y.Checked)
            {
                isTempSaveSign = "Y";
            }
            else
            {
                isTempSaveSign = "N";
            }

            //�������ʱ��������Ƿ���޸�
            if (cboTimeTitle.Text != "")
            {
                if (rdoProblemName_Y.Checked)
                {
                    isProblemName = "Y";
                }
                else
                {
                    isProblemName = "N";
                }
                if (rdoProblemTime_Y.Checked)
                {
                    isProblemTime = "Y";
                }
                else
                {
                    isProblemTime = "N";
                }
            }
            else
            {
                isProblemName = "";
                isProblemTime = "";
            }

            try
            {
                if (selectClasstext != null)
                {
                    if (selectClasstext.Id.ToString() == fahterId)
                    {
                        App.MsgWaring("���ڵ㲻��ȷ,�밴del��ť����ո��ڵ�����ѡ�񣡣�");
                        return;
                    }
                }
                string fromname = "";
                if (cboFormName.SelectedItem != null)
                {
                    FixTypeObject tempobject = (FixTypeObject)cboFormName.SelectedItem;
                    fromname = tempobject.Code;
                }

                string Sql = "";
                string sqlSort1 = "";
                string sqlSort2 = "";
                string sqlSort3 = "";
                if (isSave)
                {

                    if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ����������ˣ�");
                        txtName.Focus();
                        return;
                    }
                    else if (isExisitCode(App.ToDBC(txtNumber.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ����ı���ˣ�");
                        txtNumber.Focus();
                        return;
                    }
                    else if(isExisitCode(App.ToDBC(txtPname.Text.Trim())))
                    {
                        App.Msg("�Ѿ���������ͬ����ļ����ˣ�");
                        return;
                    }
                    //int textId = App.GenTextId();//ͣ�ô��������Լ��������ID
                    string textId = App.ReadSqlVal("select t_Text_Id.NEXTVAL col from dual WHERE ROWNUM =1", 0, "col");

                    Sql = "insert into T_TEXT(TEXTNAME,ID,TEXTCODE,ISENABLE,ISBELONGTOTYPE,PARENTID,ISSIMPLEINSTANCE,ENABLE_FLAG,SID,ISHIGHERSIGN,ISHAVETIME,FORMNAME,RIGHT_RANGE,ISNEWPAGE,ISSUBMITSIGN,ISNEEDSIGN,OTHER_TEXTNAME,PYJM,ISPROBLEM_NAME,ISPROBLEM_TIME,ISTEMPSAVESIGN)values('"
                           + App.ToDBC(txtName.Text) + "',"
                           + textId + ",'"
                           + App.ToDBC(txtNumber.Text) + "',"
                           + cboEditor.SelectedIndex.ToString() + ",'" + cboBookType.SelectedValue + "',"
                           + fahterId + ","
                           + cboBookAttribute.SelectedIndex.ToString() + ",'"
                           + mark + "','"
                           + sid + "','"
                           + signatrue + "','"
                           + cboTimeTitle.Text + "','" + fromname + "','" + cboDoctorOrNuser.Text + "','" + isnewpage + "','" + issubmitsign + "','" + isneedsignatrue + "','" + txtOtherTextName.Text + "','" + txtPname.Text + "','" + isProblemName + "','" + isProblemTime + "','" + isTempSaveSign + "')";
                    btnAdd_Click(sender, e);


                    sqlSort1 = "insert into T_TEXT_SORT(SORT_TYPE,TEXT_ID,PARENT_ID,SHOWNUM)values(" + 1 + "," + textId +"," + fahterId + ",0)";
                    sqlSort2 = "insert into T_TEXT_SORT(SORT_TYPE,TEXT_ID,PARENT_ID,SHOWNUM)values(" + 2 + "," + textId + "," + fahterId + ",0)";
                    sqlSort3 = "insert into T_TEXT_SORT(SORT_TYPE,TEXT_ID,PARENT_ID,SHOWNUM)values(" + 3 + "," + textId + "," + fahterId + ",0)";
 
                }
                else
                {
                    if (selectClasstext != null)
                    {
                        if (textname.Trim() != "")
                        {
                            if (txtName.Text.Trim() != textname.Trim() && txtName.Text.Trim() == textname.Trim())
                            {
                                if (isExisitNames(App.ToDBC(txtName.Text.Trim())))
                                {
                                    App.Msg("�Ѿ���������ͬ����������ˣ�");
                                    txtName.Focus();
                                    return;
                                }
                            }
                        }
                    }
                    
                    Sql = "update T_TEXT set  TEXTNAME='"
                        + txtName.Text + "',TEXTCODE='"
                        + txtNumber.Text + "',ISENABLE='"
                        + cboEditor.SelectedIndex.ToString() + "',ISBELONGTOTYPE='"
                        + cboBookType.SelectedValue + "',PARENTID='"
                        + fahterId + "',ISSIMPLEINSTANCE='" + cboBookAttribute.SelectedIndex.ToString()
                        + "',ENABLE_FLAG='" + mark
                        + "',SID='" + sid
                        + "', ishighersign='" + signatrue
                        + "',ishavetime='" + cboTimeTitle.Text
                        + "',formname='" + fromname +
                        "',RIGHT_RANGE='" + cboDoctorOrNuser.Text +
                        "',ISNEWPAGE='" + isnewpage + "',ISSUBMITSIGN='" + issubmitsign +
                        "',ISNEEDSIGN='" + isneedsignatrue +
                        "',OTHER_TEXTNAME='" + txtOtherTextName.Text + 
                        "',PYJM='" + txtPname.Text + 
                        "',ISPROBLEM_NAME='" + isProblemName +
                        "',ISPROBLEM_TIME='" + isProblemTime + "',ISTEMPSAVESIGN='" + isTempSaveSign + "' where id='" + selectClasstext.Id.ToString() + "'";
                }  
                Sqls.Add(Sql);
                Sqls.Add(sqlSort1);
                Sqls.Add(sqlSort2);
                Sqls.Add(sqlSort3);
                if (Sqls.Count > 0)
                {
                    string[] esqls = new string[Sqls.Count];
                    for (int i = 0; i < Sqls.Count; i++)
                    {
                        esqls[i] = Sqls[i].ToString();
                    }
                    if (App.ExecuteBatch(esqls) > 0)
                    {
                        SetItemChecked();
                        App.Msg("�����ɹ���");
                    }
                }

                btnCancel_Click(sender, e);
                //btnSelect_Click(sender, e);

                if (isSave)
                {
                    //���
                    btnSelect_Click(sender, e);
                    
                }
                else
                {
                    //�޸�
                    ReIniNode(trvDictionary.SelectedNode);
                    
                }
                
                


            }
            catch (Exception ex)
            {
                App.Msg("���ʧ�ܣ�ԭ��" + ex.ToString() + "");
            }
        }
        /// <summary>
        /// ������ؽڵ�
        /// </summary>
        /// <param name="SelNode"></param>
        private void ReIniNode(TreeNode SelNode)
        {              
            if(SelNode!=null)
            {
               
               Class_Text tempnow=(Class_Text)trvDictionary.SelectedNode.Tag;
               string SQl = "select * from T_TEXT where id=" + tempnow.Id+ " order by ID asc";
               DataSet ds = App.GetDataSet(SQl);

               Class_Text[] Directionarys = GetSelectClassDs(ds);
               SelNode.Tag = Directionarys[0];
               SelNode.Text = Directionarys[0].Textname;
               trvDictionary.SelectedNode = SelNode;

               selectClasstext = (Class_Text)trvDictionary.SelectedNode.Tag;
               Fathernode = GetDById(selectClasstext.Parentid.ToString());
               iniEditData(selectClasstext);
               texttypeselect = selectClasstext.Txxttype;
            }
        }


        ///// <summary>
        ///// ��ȡ��Ҫ�ı����������ӽڵ㼯��
        ///// </summary>
        ///// <param name="Sqls">������伯��</param>
        //private void GetChildNodes(ref ArrayList Sqls, TreeNode node)
        //{
        //    if (node != null)
        //    {
        //        if (node.Tag != null)
        //        {
        //            Class_Text temp = (Class_Text)node.Tag;
        //            Sqls.Add("update T_TEXT  set  ISBELONGTOTYPE=" + cboBookType.SelectedValue + "  where id=" + temp.Id.ToString() + "");
        //        }
        //    }
        //    if (node.Nodes.Count > 0)
        //    {
        //        for (int i = 0; i < node.Nodes.Count; i++)
        //        {
        //            GetChildNodes(ref Sqls, node.Nodes[i]);
        //        }
        //    }
        //}
        /// <summary>
        /// �˳�����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            refurbish();
        }
        private void iniEditData(Class_Text temp)
        {
            if (temp != null)
            {
                if (Fathernode != null)
                {
                    txtFather.Text = Fathernode.Textname;
                }
                else
                {
                    txtFather.Text = "";
                }
                txtNumber.Text = temp.Textcode;
                txtName.Text = temp.Textname;
                cboEditor.SelectedIndex = Convert.ToInt32(temp.Isenable);
                cboBookType.SelectedValue = temp.Txxttype == "" ? "0" : temp.Txxttype;
                cboBookAttribute.SelectedIndex = Convert.ToInt32(temp.Issimpleinstance);
                cboTimeTitle.Text = temp.Ishavetime;

                for (int i = 0; i < cboFormName.Items.Count; i++)
                {
                    FixTypeObject tempobject=(FixTypeObject)cboFormName.Items[i];
                    if (tempobject.Code.ToLower() == temp.Formname.ToLower())
                    {
                        cboFormName.SelectedItem = tempobject;
                        break;
                    }
                }

                   // cboFormName.Text = temp.Formname;
                mark = temp.Enable;
                if (mark == "N")
                {
                    rbtnVainmark.Checked = true;
                }
                else if (mark == "Y")
                {
                    rbtnValidmark.Checked = true;
                }
                if (temp.Ishighersign == "N")
                {
                    rdoSignatrueFalse.Checked = true;
                }
                else if (temp.Ishighersign == "Y")
                {
                    rdoSignatrueTrue.Checked = true;
                }

                if (temp.Isneedsign == "Y")
                {
                    rdoNeedSign_Y.Checked = true;
                }
                else
                {
                    rdoNeedSign_N.Checked = true;
                }

                if (temp.IsTempsavesign == "Y")
                {
                    rdoSave_Y.Checked = true;
                }
                else
                {
                    rdoSave_N.Checked = true;
                }

                if (temp.Isnewpage == "Y")
                {
                    rdoNewPage_Y.Checked =true;
                }
                else
                {
                    rdoNewPage_N.Checked = true;
                }

                if (temp.Issubmitsign == "Y")
                {
                    rdoSubmitAutoSign_Y.Checked = true;
                }
                else
                {
                    rdoSubmitAutoSign_N.Checked = true;
                }

                if (temp.IsProblemName == "Y")
                {
                    rdoProblemName_Y.Checked = true;
                }
                else
                {
                    rdoProblemName_N.Checked = true;
                }

                if (temp.IsProblemTime == "Y")
                {
                    rdoProblemTime_Y.Checked = true;
                }
                else
                {
                    rdoProblemTime_N.Checked = true;
                }

                cboDoctorOrNuser.Text = temp.Right_range;
                txtOtherTextName.Text = temp.Other_textname;

            }
        }
        private void trvDictionary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (groupPanel2.Enabled && !isSave)
            {
                if (trvDictionary.SelectedNode != null)
                {
                    if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                    {
                        Fathernode = null;
                        selectClasstext = (Class_Text)trvDictionary.SelectedNode.Tag;
                        Fathernode = GetDById(selectClasstext.Parentid.ToString());
                        iniEditData(selectClasstext);
                        texttypeselect = selectClasstext.Txxttype;
                    }
                }
            }
        }

        private void trvDictionary_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                {

                    selectClasstext = (Class_Text)trvDictionary.SelectedNode.Tag;
                    iniEditData(selectClasstext);
                    SetItemChecked();
                }
            }
        }

        /// <summary>
        /// ���ÿ����б�ѡ����
        /// </summary>
        private void SetItemChecked()
        {
            if (selectClasstext == null)
            {
                return;
            }
            //ȡ������ѡ�е�Item
            for (int i = 0; i < clbSection.Items.Count; i++)
            {
                clbSection.SetItemChecked(i, false);
            }
            int id = Convert.ToInt32(selectClasstext.Id);
            string sid = "";
            DataSet ds = App.GetDataSet("select sid from t_text where id=" + id);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    DataRow row = dt.Rows[0];
                    sid = row["sid"].ToString();
                }
            }
            string[] sections = sid.Split(',');
            //ѡ�и��������������
            for (int i = 0; i < clbSection.Items.Count; i++)
            {
                if (sid == "0")
                {
                    clbSection.SetItemChecked(i, true);
                    break;
                }
                string sectionid = clbSection.GetItemText(clbSection.Items[i]).Substring(0, clbSection.GetItemText(clbSection.Items[i]).IndexOf(":"));

                for (int j = 0; j < sections.Length; j++)
                {
                    if (sectionid == sections[j])
                    {
                        clbSection.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void trvDictionary_MouseDown(object sender, MouseEventArgs e)
        {
            trvDictionary.SelectedNode = trvDictionary.GetNodeAt(e.X, e.Y);
        }
        /// <summary>
        /// ����ӽڵ�
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ����ӽڵ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                Fathernode = selectClasstext;
                btnAdd_Click(sender, e);
            }
            else
            {
                App.Msg("��ѡ����Ҫ�������Ľڵ�!");
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                {

                    if (trvDictionary.SelectedNode.Nodes.Count == 0)
                    {
                        if (App.Ask("ȷ��Ҫɾ����,�û���д�ĸ������齫�ᶪʧ����"))
                        {
                            Class_Text temp = (Class_Text)trvDictionary.SelectedNode.Tag;
                            App.ExecuteSQL("delete from T_TEXT where ID=" + temp.Id + "");
                            trvDictionary.Nodes.Remove(trvDictionary.SelectedNode);

                        }

                    }
                    else
                    {
                        App.Msg("�ýڵ����Ѿ������ӽڵ�,Ҫɾ����ѽڵ��´��ڵ��ӽڵ��������ɾ��");
                    }
                }
                btnSelect_Click(sender, e);
            }
            else
            {
                App.Ask("��ѡ����Ҫɾ���Ľڵ㣡");

            }
        }
        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();
            }

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboEditor.Focus();
            }

        }

        private void cboEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //cboBookType.Focus();
            }

        }

        private void cboBookType_KeyDown(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// ����ҳ�治����ʱ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboEditor.Text == "��" && btnSave.Enabled)
            {
                cboTimeTitle.Enabled = true;
                cboFormName.Enabled = false;
                cboFormName.Text = "";
            }
            else if (cboEditor.Text == "��" && btnSave.Enabled)
            {
                cboFormName.Enabled = true;
                cboTimeTitle.Enabled = false;
                cboTimeTitle.Text = "";
            }
            else
            {
                cboTimeTitle.Enabled = false;
                cboTimeTitle.Text = "";
            }
        }

        private void btnSelectTrv_Click(object sender, EventArgs e)
        {
            if (selectClasstext != null)
            {               
                frmWrite_Type_TrvSelect fm = new frmWrite_Type_TrvSelect(selectClasstext.Id.ToString());
                fm.ShowDialog();
                if (fahterName != "")
                {
                    txtFather.Text = fahterName;
                    //cboBookType.SelectedValue = texttype;
                    Fathernode = null;
                }
            }
            else
            {
                frmWrite_Type_TrvSelect fm = new frmWrite_Type_TrvSelect();
                fm.ShowDialog();
                if (fahterName != "")
                {
                    txtFather.Text = fahterName;
                    //cboBookType.SelectedValue = texttype;
                    Fathernode = null;
                }
            }
        }
        private void txtFather_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                if (selectClasstext != null)
                {
                    fahterName = "";
                    frmWrite_Type_TrvSelect fm = new frmWrite_Type_TrvSelect(selectClasstext.Id.ToString());
                    fm.ShowDialog();
                    if (fahterName != "")
                    {
                        txtFather.Text = fahterName;
                        //cboBookType.SelectedValue = texttype;
                        Fathernode = null;
                    }
                }
            }
            else if (e.KeyCode == Keys.Back)
            {
                fahterName = "";
            }

        }

        private void trvDictionary_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(TreeNode)))
            //{
            //    e.Effect = DragDropEffects.Move;
            //}
            //else
            //{
            //    e.Effect = DragDropEffects.None;
            //}
        }

        /// <summary>
        /// ��ʼ�϶�ʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDictionary_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //TreeNode TNode = e.Item as TreeNode;
            //if((e.Button==MouseButtons.Left)&&(TNode!=null)&&(TNode.Parent!=null))
            //{
            //    this.trvDictionary.DoDragDrop(TNode,DragDropEffects.Copy|DragDropEffects.Move|DragDropEffects.Link);
            //}
            DoDragDrop(e.Item, DragDropEffects.Move);

        }
        private Point Position = new Point(0, 0);
        /// <summary>
        /// �Ϸ����ʱ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDictionary_DragDrop(object sender, DragEventArgs e)
        {
            //TreeNode myNode =new TreeNode();
            //myNode.BackColor = SystemColors.Window;
            //if (e.Data.GetDataPresent(typeof(TreeNode)))
            //{
            //    myNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
            //}
            //else
            //{
            //    App.Msg("����");
            //}
            //Position.X = e.X;
            //Position.Y = e.Y;
            //Position = trvDictionary.PointToClient(Position);
            //TreeNode DropNode = this.trvDictionary.GetNodeAt(Position);
            //// 1.Ŀ��ڵ㲻�ǿ� 2.Ŀ��ڵ㲻�Ǳ���ק�ӵ���ֽڵ� 3.Ŀ��ڵ㲻�Ǳ���ק�ڵ㱾��
            //if (DropNode != null && DropNode.Parent != myNode && DropNode != myNode)
            //{
            //    TreeNode DragNode = myNode;

            //    // ������ק�ڵ��ԭ��λ��ɾ��
            //    myNode.Remove();
            //    //string tag = DropNode.Tag.ToString();

            //    // ��Ŀ��ڵ������ӱ���ק�ڵ�
            //    DropNode.Nodes.Add(DragNode);
            //     string name=DropNode.Text;
            //     string id=GetSelectItemId(name);
            //     string names=myNode.Text;
            //     string ids=GetSelectItemId(names);
            //    string isType=GetSelectItemType(name);
            //    App.ExecuteSQL("update T_TEXT set PARENTID='" + id + "',ISBELONGTOTYPE='" + isType + "' where ID='" + ids + "'");


            //}
            //// ���Ŀ��ڵ㲻���ڣ�����ק��λ�ò����ڽڵ㣬��ô�ͽ�����ק�ڵ���ڸ��ڵ�֮��
            //if (DropNode == null)
            //{
            //    TreeNode DragNode = myNode;
            //    myNode.Remove();
            //    trvDictionary.Nodes.Add(DragNode);
            //}
        }
        /// <summary>
        /// ������Ŀ���ƻ�ȡ��ؼ�¼��ID
        /// </summary>
        /// <param Name="ItemName"></param>
        /// <param Name="strtime"></param>
        /// <returns></returns>
        private string GetSelectItemId(string ItemName)
        {
            string Sql = "select ID from T_TEXT  where TEXTNAME='" + ItemName + "'";
            string ID = App.ReadSqlVal(Sql, 0, "ID");
            return ID;
        }
        /// <summary>
        /// ������Ŀ���ƻ�ȡ��ؼ�¼������
        /// </summary>
        /// <param Name="ItemName"></param>
        /// <param Name="strtime"></param>
        /// <returns></returns>
        private string GetSelectItemType(string ItemName)
        {
            string Sql = "select ISBELONGTOTYPE from T_TEXT  where TEXTNAME='" + ItemName + "'";
            string isbelongtotype = App.ReadSqlVal(Sql, 0, "ISBELONGTOTYPE");
            return isbelongtotype;
        }

        /// <summary>
        /// ���ƶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.PrevNode != null)
                {
                    Class_Text temp1 = (Class_Text)trvDictionary.SelectedNode.PrevNode.Tag;
                    Class_Text temp2 = (Class_Text)trvDictionary.SelectedNode.Tag;
                    App.ExecuteSQL("update t_text set shownum=" + temp1.Shownum + " where id='" + temp2.Id.ToString() + "' and idnum<>'" + temp1.Shownum + "'");
                    App.ExecuteSQL("update t_text set shownum=" + temp2.Shownum + " where id='" + temp1.Id.ToString() + "' and idnum<>'" + temp1.Shownum + "'");
                    App.TrvNodeMovUp(trvDictionary.SelectedNode, trvDictionary);
                }

            }
        }

        /// <summary>
        /// ���ƶ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.TrvNodeMovDown(trvDictionary.SelectedNode, trvDictionary);
            if (trvDictionary.SelectedNode != null)
            {
                if (trvDictionary.SelectedNode.NextNode != null)
                {
                    Class_Text temp1 = (Class_Text)trvDictionary.SelectedNode.NextNode.Tag;
                    Class_Text temp2 = (Class_Text)trvDictionary.SelectedNode.Tag;
                    App.ExecuteSQL("update t_text set shownum=" + temp1.Shownum + " where id='" + temp2.Id.ToString() + "' and idnum<>'" + temp1.Shownum + "'");
                    App.ExecuteSQL("update t_text set shownum=" + temp2.Shownum + " where id='" + temp1.Id.ToString() + "' and idnum<>'" + temp1.Shownum + "'");
                }
            }
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {
                //if (trvDictionary.SelectedNode.Nodes.Count > 0)
                //{
                Class_Text temp1 = (Class_Text)trvDictionary.SelectedNode.Tag;
                frmWrite_Type_Order fr = new frmWrite_Type_Order(temp1.Id.ToString(),cboSortType.SelectedIndex);
                App.FormStytleSet(fr, false);
                fr.ShowDialog();

                //�������仯
                if (ucWrite_Type.isShowNumChange)
                {
                    btnSelect_Click(sender, e);
                }
                //}
                //else
                //{
                //    App.MsgWaring("�����鲻���������飡");
                //}
            }
            else
            {
                App.MsgWaring("��ѡ��Ҫ��������飡");
            }
        }

        /// <summary>
        /// ɾ�����ڵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelFater_Click(object sender, EventArgs e)
        {
            txtFather.Text = "";
            fahterId = "0";
            fahterName = "";
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trvDictionary.SelectedNode != null)
            {


                frmWrite_Type_Order fr = new frmWrite_Type_Order("0", cboSortType.SelectedIndex);
                App.FormStytleSet(fr, false);
                fr.ShowDialog();

                //�������仯
                if (ucWrite_Type.isShowNumChange)
                {
                    btnSelect_Click(sender, e);
                }
             
            }
            else
            {
                App.MsgWaring("��ѡ��Ҫ��������飡");
            }
        }

        private void cboSortType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //��������

        }

        private void txtPname_TextChanged(object sender, EventArgs e)
        {
            //txtPname.Text = App.getSpell(txtName.Text).ToUpper();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtPname.Text = App.getSpell(txtName.Text).ToUpper();
        }

        private void cboTimeTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((cboTimeTitle.Text == "A"||cboTimeTitle.Text == "B") && btnSave.Enabled)
            {
                rdoProblemName_Y.Enabled = true;
                rdoProblemName_N.Enabled = true;
                rdoProblemName_N.Checked = true;
                rdoProblemTime_Y.Enabled = true;
                rdoProblemTime_N.Enabled = true;
                rdoProblemTime_N.Checked = true;
            }
            else
            {
                rdoProblemName_Y.Enabled = false;
                rdoProblemName_N.Enabled = false;
                rdoProblemName_N.Checked = true;
                rdoProblemTime_Y.Enabled = false;
                rdoProblemTime_N.Enabled = false;
                rdoProblemTime_N.Checked = true;
            }
        }
   
    }

    class FixTypeObject
    {

        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }



}