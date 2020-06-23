using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;
using Bifrost;
using EmrCommon;
using TextEditor;
using EmrDAL;

namespace Base_Function.TEMPLATE
{
    public partial class ucTemplateManagement : UserControl
    {
        private static ArrayList source_words = new ArrayList();
        private static ArrayList target_words = new ArrayList();
        private XmlDocument xmlDoc;
        private XmlNode xmlNode;

        // private XmlElement xmlElem;
        private Class_Patients[] patients; //ģ��

        //private Class_Patients_Cont[] patients_conts;//ģ��ı�ǩ����
        private static TreeView temptrvbook;

        public static int text_kind;
        public static Class_Template[] Current_Template;
        private string current_id = "";   //��ȡ��ǰѡ��ģ���ID
        public string isdefault = "N";
        public string default_sec = "N";

        private DataTable dataTable;
        private DataRow newrow;
        private bool isSysInit = false;   //������Դ�Ƿ񴥷��¼���һ��Ŀ¼��

        //private bool isSickInit = false;  //������Դ�Ƿ񴥷��¼�������Ŀ¼��
        //private bool isTextKindInit = false;  //������Դ�Ƿ񴥷��¼�������Ŀ¼��
        private bool isQueryTag = false;   //��ѯ���

        public static DataSet Temp_Sections;           //��ȡ˵�е�ģ��󶨵Ŀ���
        public static DataSet Temp_Groups;             //��ȡ˵�е�ģ��󶨵�������
        public static string isSecDefault = "false";   //Ĭ�Ͽ���ģ��
        public static string isGroupDefault = "false"; //Ĭ��������ģ��

        private ArrayList listNodes = new ArrayList();         //ģ����ѯ�����ڵ㼯��
        //int nodeNum = 0;
        //string temp = "";

        public ucTemplateManagement()
        {
            InitializeComponent();
            App.UsControlStyle(this);
            try
            {
                Temp_Sections = App.GetDataSet("select * from T_TEMPPLATE_SECTION");//��ȡ���п��Һ�ģ��Ĺ�ϵ
                Temp_Groups = App.GetDataSet("select * from T_TEMPPLATE_GROUP");//��ȡ�����������ģ��Ĺ�ϵ
                ReflashBookTree(this.treeView1);
                temptrvbook = this.treeView1;
                ReflashTrvBook("");

                //groupBox3.Controls.Add(Template.fmT);//�༭������Ƕ��
                groupText.Controls.Add(Template.fmT);
                Template.fmT.MyDoc.OwnerControl.EnableSmartTag = true;
                Template.fmT.Dock = System.Windows.Forms.DockStyle.Fill;

                InitSystemList();    //��ʼ��һ��Ŀ¼������ϵͳ��
                InitTextTypeList();  //��ʼ������Ŀ¼���������ͣ�

                this.cboSicknessKind.SelectedIndex = 0;
                this.cboTextKind.SelectedIndex = 0;

                panelRange.Enabled = false;

                LoadMacrosElements();
                this.tvMacrosElements.NodeMouseDoubleClick += TvMacrosElements_NodeMouseDoubleClick;

                this.DoubleBuffered = true;
            }
            catch
            { }
        }

        private void TvMacrosElements_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var entity = this.tvMacrosElements.SelectedNode.Tag.As<T_MACROS_ELEMENTS>();
            var emrDoc = Template.fmT.MyDoc;
            List<ZYTextElement> elements = new List<ZYTextElement>();
            ArrayList list1 = new ArrayList();
            if (entity == null)
            {
                return;
            }
            entity.Name.ToList().ForEach(c =>
            {
                ZYTextChar zc = new ZYTextChar()
                {
                    OwnerDocument = emrDoc,
                    Char = c
                };
                elements.Add(zc);
                list1.Add(zc);
            });

            if (entity.Join != null)
            {
                entity.Join.ToList().ForEach(c =>
                {
                    ZYTextChar zc = new ZYTextChar()
                    {
                        OwnerDocument = emrDoc,
                        Char = c
                    };
                    elements.Add(zc);
                    list1.Add(zc);
                });
            }


            ZYTextInput input = new ZYTextInput()
            {
                OwnerDocument = emrDoc,
                Name = entity.Name,
                Text = entity.Default_Value??"",
                cFormat = entity.Format
            };
            elements.Add(input);
            list1.Add(input);

            emrDoc.Content.InsertRangeElements(list1);
        }

        //��������¼�
        private void frmTemplateManageMent_Load(object sender, EventArgs e)
        {

        }

        //һ��Ŀ¼ѡ����ı��¼�
        private void cboSys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isSysInit)
            {
                string msg = this.cboSys.SelectedValue.ToString();
                InitSickList(msg);
            }
        }

        /// <summary>
        /// ���غ�Ԫ��
        /// </summary>
        private void LoadMacrosElements()
        {
            try
            {
                var flag = App.GetHospitalConfig("ZM2016122901");
                if (flag == "1")
                {
                    //var roots = DataInit.GetMacrosKinds();
                    //if (roots != null && roots.Count > 0)
                    //{
                    //    var elements = EmrDAL.DbQuery.Query<T_MACROS_ELEMENTS>(o => o.Enable.Equals("1"));
                    //    roots.ForEach(o =>
                    //    {
                    //        TreeNode tn = new TreeNode();
                    //        tn.Text = o.Name;
                    //        tn.Tag = o.Id;
                    //        this.tvMacrosElements.Nodes.Add(tn);
                    //        var res = elements.FindAll(o1 => o1.Type == o.Id);
                    //        if (res != null)
                    //        {
                    //            res.ForEach(o2 =>
                    //            {
                    //                TreeNode tnChild = new TreeNode();
                    //                tnChild.Text = o2.Name;
                    //                tnChild.Tag = o2;
                    //                tn.Nodes.Add(tnChild);
                    //            });
                    //        }
                    //    });
                    //}

                    DataSet dsMacros = App.GetDataSet("select * from T_MACROS_ELEMENTS where Enable=1");
                    if (dsMacros != null)
                    {
                        if (dsMacros.Tables[0].Rows.Count > 0)
                        {
                            var roots = DataInit.GetMacrosKinds();
                            if (roots != null && roots.Count > 0)
                            {
                                for (int i = 0; i < roots.Count; i++)
                                {
                                    TreeNode tn = new TreeNode();
                                    tn.Text = roots[i].Name;
                                    tn.Tag = roots[i].Id;
                                    this.tvMacrosElements.Nodes.Add(tn);
                                    DataRow[] rows=dsMacros.Tables[0].Select("Type="+ roots[i].Id + "");
                                    for (int k = 0; k < rows.Length; k++)
                                    {
                                        TreeNode tnChild = new TreeNode();
                                        T_MACROS_ELEMENTS macros = new T_MACROS_ELEMENTS();

                                        if(rows[k]["Id"]!=null)
                                           macros.Id= Convert.ToInt32(rows[k]["Id"]);
                                        if (rows[k]["Name"] != null)
                                            macros.Name = rows[k]["Name"].ToString();
                                        if (rows[k]["Description"] != null)
                                            macros.Description = rows[k]["Description"].ToString();
                                        if (rows[k]["Type"] != null)
                                            macros.Type = rows[k]["Type"].ToString();
                                        if (rows[k]["Default_Value"] != null)
                                            macros.Default_Value = rows[k]["Default_Value"].ToString();
                                        if (rows[k]["ColName"] != null)
                                            macros.ColName = rows[k]["ColName"].ToString();
                                        if (rows[k]["Format"] != null)
                                            macros.Format = rows[k]["Format"].ToString();
                                        if (rows[k]["Enable"] != null)
                                            macros.Enable = rows[k]["Enable"].ToString();
                                        if (rows[k]["OnlyOnNull"] != null)
                                            macros.OnlyOnNull = rows[k]["OnlyOnNull"].ToString();
                                        if (rows[k]["Split"] != null)
                                            macros.Split = rows[k]["Split"].ToString();
                                        if (rows[k]["Select_Index"] != null)
                                            if(App.IsNumeric(rows[k]["Select_Index"].ToString()))
                                                macros.Select_Index = Convert.ToInt32(rows[k]["Select_Index"]);
                                        if (rows[k]["Join"] != null)
                                            macros.Join = rows[k]["Join"].ToString();
                                        tnChild.Text = macros.Name.ToString();
                                        tnChild.Tag = macros;
                                        tn.Nodes.Add(tnChild);
                                    }
                                }
                            }
                        }
                    }


                }
                else
                {
                    this.panel1.Visible = false;
                    this.expandableSplitter2.Visible = false;
                }
            }
            catch(Exception ex)
            { App.MsgErr(ex.Message); }

        }

        //��ʼ��һ��Ŀ¼������ϵͳ��
        private void InitSystemList()
        {
            isSysInit = false;   //������Դ�Ƿ񴥷��¼�

            DataSet dsSys = App.GetDataSet("select * from t_data_code where type='16'");
            //��ʼ������ϵͳ����
            dataTable = dsSys.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "��ѡ��...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSys.DataSource = dataTable.DefaultView;
            this.cboSys.ValueMember = "ID";
            this.cboSys.DisplayMember = "Name";

            isSysInit = true;  //������Դ�Ƿ񴥷��¼�
        }

        //��ʼ������Ŀ¼�������ࣩ
        private void InitSickList(string msg)
        {
            //isSickInit = false;  //������Դ�Ƿ񴥷��¼�

            string sql = "select s.ID,SICK_CODE," +
                        @"SICK_NAME,SICK_SYSTEM, " +
                        @"t.name as Name  from T_SICK_TYPE s " +
                        @"inner join t_data_code t on t.id=s.sick_system where t.id='" + msg + "'";
            //��ʼ������
            DataSet dsSick = App.GetDataSet(sql);
            dataTable = dsSick.Tables[0];
            newrow = dataTable.NewRow();
            newrow[2] = "��ѡ��...";
            dataTable.Rows.InsertAt(newrow, 0);

            this.cboSicknessKind.DataSource = dataTable.DefaultView;
            this.cboSicknessKind.ValueMember = "ID";
            this.cboSicknessKind.DisplayMember = "SICK_NAME";

            //isSickInit = true;  //������Դ�Ƿ񴥷��¼�
        }

        //��ʼ������Ŀ¼���������ͣ�
        private void InitTextTypeList()
        {
            //isTextKindInit = false;  //������Դ�Ƿ񴥷��¼�

            string sql = "select * from t_text t where t.parentid != 0";
            //��ʼ����������
            DataSet dsTextKind = App.GetDataSet(sql);

            dataTable = dsTextKind.Tables[0];
            newrow = dataTable.NewRow();
            newrow[1] = "��ѡ��...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboTextKind.DataSource = dsTextKind.Tables[0].DefaultView;
            this.cboTextKind.ValueMember = "ID";
            this.cboTextKind.DisplayMember = "TEXTNAME";

            //isTextKindInit = true;  //������Դ�Ƿ񴥷��¼�
        }

        /// <summary>
        /// ���β˵���Ϣ���أ�������⣩
        /// </summary>
        /// <param name="trvBook">���β˵�</param>
        public void ReflashBookTree(TreeView trvBook)
        {
            string Sql_Category = "select * from t_data_code where type=31";
            DataSet ds_category = App.GetDataSet(Sql_Category);
            Class_Datacodecs[] datacodes = GetSelectDirectionary(ds_category);

            string SQl = "select * from T_TEXT where ENABLE_FLAG='Y'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = GetSelectClassDs(ds);

            if (datacodes != null)
            {
                this.treeView1.Nodes.Clear();
                for (int j = 0; j < datacodes.Length; j++)
                {
                    TreeNode tempNode = new TreeNode();
                    tempNode.Name = datacodes[j].Id;
                    tempNode.Text = datacodes[j].Name;
                    tempNode.Tag = datacodes[j] as object;
                    tempNode.ImageIndex = 1;
                    tempNode.SelectedImageIndex = 1;
                    if (Directionarys != null)
                    {
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;
                            tn.Name = Directionarys[i].Id.ToString();

                            // Class_Template[] templates = GetTemplates(Directionarys[i]);
                            //setTreeView2(templates, tempNode);
                            //for (int k = 0; k < templates.Length; k++)
                            //{
                            //    TreeNode t = new TreeNode();
                            //    t.Tag = templates[k];
                            //    t.Text = templates[k].Tname;
                            //    t.Name = templates[k].Tid.ToString();
                            //    SetTreeView(Directionarys, t);
                            //}

                            //���붥���ڵ�
                            if (Directionarys[i].Parentid == 0 && datacodes[j].Id.Equals(Directionarys[i].Txxttype))
                            {
                                tempNode.Nodes.Add(tn);
                                SetTreeView(Directionarys, tn);
                            }
                        }
                    }
                    trvBook.Nodes.Add(tempNode);
                }
            }
        }

        /// <summary>
        /// ��������з�������
        /// </summary>
        /// <param Name="Directionarys">��������ڵ㼯��</param>
        /// <param Name="currentnode">��ǰ����ڵ�</param>
        private static void SetTreeView(Class_Text[] Directionarys, TreeNode current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Text cunrrentDir = (Class_Text)current.Tag;
                if (Directionarys[i].Parentid == cunrrentDir.Id)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    tn.ImageIndex = 9;
                    tn.SelectedImageIndex = 9;
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }
            }
        }

        /// <summary>
        /// ��ʼ����ѯ������Combobox
        /// </summary>
        //private void InitCombobox()
        //{
        //    //��ʼ������ϵͳ����
        //    DataSet dsSys = App.GetDataSet("select * from t_data_code where type=16");
        //    this.cboSys.DataSource = dsSys.Tables[0].DefaultView;
        //    this.cboSys.ValueMember = "ID";
        //    this.cboSys.DisplayMember = "Name";

        //    //��ʼ������
        //    DataSet dsSick = App.GetDataSet("select * from t_data_code where type=17");
        //    this.cboSicknessKind.DataSource = dsSick.Tables[0].DefaultView;
        //    this.cboSicknessKind.ValueMember = "ID";
        //    this.cboSicknessKind.DisplayMember = "Name";

        //    //��ʼ����������
        //    DataSet dsTextKind = App.GetDataSet("select * from t_data_code where type=18");
        //    this.cboTextKind.DataSource = dsTextKind.Tables[0].DefaultView;
        //    this.cboTextKind.ValueMember = "ID";
        //    this.cboTextKind.DisplayMember = "Name";

        //}

        /// <summary>
        /// ˢģ��
        /// </summary>
        /// <param name="trvBook"></param>
        public static void RefreshBookTree(TreeView trvBook)
        {
            string SQl = "select * from t_tempplate";
            string Sql_Category = "select * from t_data_code where type=31";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = GetSelectClassDs(ds);
            DataSet ds_category = App.GetDataSet(Sql_Category);
            Class_Datacodecs[] datacodes = GetSelectDirectionary(ds_category);
            if (datacodes != null)
            {
                for (int j = 0; j < datacodes.Length; j++)
                {
                    TreeNode tempNode = new TreeNode();
                    tempNode.Name = datacodes[j].Id;
                    tempNode.Text = datacodes[j].Name;
                    tempNode.Tag = datacodes[j] as object;
                    tempNode.ImageIndex = 1;
                    tempNode.SelectedImageIndex = 1;
                    if (Directionarys != null)
                    {
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;
                            tn.Name = Directionarys[i].Id.ToString();
                            //���붥���ڵ�
                            if (Directionarys[i].Parentid == 0 && datacodes[j].Id.Equals(Directionarys[i].Txxttype))
                            {
                                tempNode.Nodes.Add(tn);
                                SetTreeView(Directionarys, tn);
                            }
                        }
                    }
                    trvBook.Nodes.Add(tempNode);
                }
            }
        }

        /// <summary>
        /// ģ������
        /// </summary>
        /// <param name="templates"></param>
        /// <param name="current"></param>
        //private static void setTreeView2(Class_Template [] templates, TreeNode current)
        //{
        //    for (int i = 0; i < templates.Length; i++)
        //    {
        //        Class_Text cunrrentDir = (Class_Text)current.Tag;
        //        if (templates[i].TextType == cunrrentDir.Id)
        //        {
        //            TreeNode tn = new TreeNode();
        //            tn.Tag = templates[i];
        //            tn.Text = templates[i].Tname;
        //            tn.Name = templates[i].Tid.ToString();
        //            tn.ImageIndex = 9;
        //            tn.SelectedImageIndex = 9;
        //            current.Nodes.Add(tn);
        //            setTreeView2(templates, tn);
        //        }
        //    }
        //}

        /// <summary>
        /// ˢ�������������
        /// </summary>
        public void ReflashTrvBook(string msg)
        {
            //InPatientInfo inpatient = GetInpatientByBedId();
            Class_Patients[] templates;
            if (isQueryTag)
            {
                templates = GetTemplates(msg);
                if (templates != null)  //����ģ��
                {
                    foreach (Class_Patients template in templates)
                    {
                        setTreeView3(template, treeView1.Nodes);
                    }
                }
            }
            else
            {
                templates = GetTemplates("");
                foreach (Class_Patients template in templates)
                {
                    setTreeView2(template, treeView1.Nodes);
                }
            }

            //treeView1.Nodes.Clear();
            //for (int i = 0; i < temptrvbook.Nodes.Count; i++)
            //{
            //    treeView1.Nodes.Add((TreeNode)temptrvbook.Nodes[i].Clone());
            //}
        }

        ///// <summary>
        ///// ʵ������ѯ��� Class_Template
        ///// </summary>
        ///// <param name="text"></param>
        ///// <returns></returns>
        //public Class_Patients[] GetTemplates()
        //{
        //    //int textId = text.Id;
        //    string sql = "select * from t_tempplate";// where Text_type = " + textId;
        //    DataSet ds = App.GetDataSet(sql);

        //    //string sql2 = "select * from t_tempplate_cont";
        //    //DataSet ds2 = App.GetDataSet(sql2);

        //    Class_Patients[] templates = new Class_Patients[ds.Tables[0].Rows.Count];
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        templates[i] = new Class_Patients();
        //        templates[i].Tid = Convert.ToInt32( ds.Tables[0].Rows[i]["TID"]);
        //        templates[i].TName = ds.Tables[0].Rows[i]["TNAME"].ToString();
        //        if(ds.Tables[0].Rows[i]["TEXT_TYPE"].ToString().Trim()!= "")
        //            templates[i].TextKind = ds.Tables[0].Rows[i]["TEXT_TYPE"].ToString();
        //        templates[i].TempPlate_Level = Convert.ToChar(ds.Tables[0].Rows[i]["TEMPPLATE_LEVEL"]);
        //        templates[i].IsDefault = Convert.ToChar(ds.Tables[0].Rows[i]["ISDEFAULT"]);
        //        templates[i].Default_sec_id = ds.Tables[0].Rows[i]["DEFAULT_SEC_ID"].ToString();

        //        //DataRow[] tr=ds2.Tables[0].Select(" TID = " + templates[i].Tid);
        //        //templates[i].Content = tr[0]["CONTENT"].ToString();
        //    }
        //    return templates;
        //}

        /// <summary>
        /// ʵ������ѯ��� Class_Template
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public Class_Patients[] GetTemplates(string msg)
        {
            //int textId = text.Id;
            string sql = "";
            if (msg != "")
            {
                sql = "select * from t_tempplate where " + msg;// where Text_type = " + textId;
            }
            else
            {
                sql = "select * from t_tempplate";// where Text_type = " + textId;
            }
            DataSet ds = App.GetDataSet(sql);

            //string sql2 = "select * from t_tempplate_cont";
            //DataSet ds2 = App.GetDataSet(sql2);

            if (ds != null)
            {
                Class_Patients[] templates = new Class_Patients[ds.Tables[0].Rows.Count];
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    templates[i] = new Class_Patients();
                    templates[i].Tid = Convert.ToInt32(ds.Tables[0].Rows[i]["TID"]);
                    templates[i].TName = ds.Tables[0].Rows[i]["TNAME"].ToString();
                    if (ds.Tables[0].Rows[i]["TEXT_TYPE"].ToString().Trim() != "")
                        templates[i].TextKind = ds.Tables[0].Rows[i]["TEXT_TYPE"].ToString();
                    if (ds.Tables[0].Rows[i]["TEMPPLATE_LEVEL"].ToString().Trim() != "")
                        templates[i].TempPlate_Level = Convert.ToChar(ds.Tables[0].Rows[i]["TEMPPLATE_LEVEL"]);
                    if (ds.Tables[0].Rows[i]["ISDEFAULT"].ToString().Trim() != "")
                        templates[i].IsDefault = Convert.ToChar(ds.Tables[0].Rows[i]["ISDEFAULT"]);
                    templates[i].Default_sec_id = ds.Tables[0].Rows[i]["DEFAULT_SEC_ID"].ToString();

                    //DataRow[] tr=ds2.Tables[0].Select(" TID = " + templates[i].Tid);
                    //templates[i].Content = tr[0]["CONTENT"].ToString();
                }
                return templates;
            }
            else
            {
                return null;
            }
        }

        private static void setTreeView2(Class_Patients templates, TreeNodeCollection nodes)
        {
            if (templates != null)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Tag.GetType().ToString().Contains("Class_Text"))
                    {
                        Class_Text cunrrentDir = node.Tag as Class_Text;
                        if (templates.TextKind == cunrrentDir.Id.ToString())
                        {
                            TreeNode tn = new TreeNode();
                            if (Temp_Groups.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                            {
                                //�����鼶��Ĭ��ģ��
                                tn.ForeColor = Color.Teal;
                            }
                            else if (Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                            {
                                //���Ҽ�Ĭ��ģ��
                                tn.ForeColor = Color.Blue;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'Y')
                            {
                                //ȫԺĬ��ģ��
                                tn.ForeColor = Color.Green;
                            }
                            else if (Temp_Groups.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                                     Temp_Groups.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                            {
                                //����ģ��
                                tn.ForeColor = Color.DarkSlateBlue;
                            }
                            else if (Temp_Sections.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                                     Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                            {
                                //����ģ��
                                tn.ForeColor = Color.Crimson;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'N')
                            {
                                //ȫԺĬ��ģ��
                                tn.ForeColor = Color.DarkGoldenrod;
                            }
                            else
                            {
                                //ʲô������
                                tn.ForeColor = Color.Black;
                            }

                            tn.Tag = templates;
                            tn.Text = templates.TName;
                            tn.Name = templates.Tid.ToString();
                            tn.ImageIndex = 13;
                            tn.SelectedImageIndex = 13;
                            node.Nodes.Add(tn);
                            tn.Parent.SelectedImageIndex = 6;
                            tn.Parent.ImageIndex = 6;
                        }
                    }

                    if (node.Nodes.Count > 0)
                        setTreeView2(templates, node.Nodes);
                }
            }
        }

        private static void setTreeView3(Class_Patients templates, TreeNodeCollection nodes)
        {
            if (templates != null)
            {
                foreach (TreeNode node in nodes)
                {
                    if (node.Tag.GetType().ToString().Contains("Class_Text"))
                    {
                        Class_Text cunrrentDir = node.Tag as Class_Text;
                        if (templates.TextKind == cunrrentDir.Id.ToString())
                        {
                            TreeNode tn = new TreeNode();
                            //if (templates.Default_sec_id != "" && templates.Section_ID.ToString() != "" && templates.IsDefault == 'Y')
                            if (Temp_Groups.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                            {
                                //�����鼶��Ĭ��ģ��
                                tn.ForeColor = Color.Teal;
                            }
                            else if (Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                            {
                                //���Ҽ�Ĭ��ģ��
                                tn.ForeColor = Color.Blue;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'Y')
                            {
                                //ȫԺĬ��ģ��
                                tn.ForeColor = Color.Green;
                            }
                            else if (Temp_Groups.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                                     Temp_Groups.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                            {
                                //����ģ��
                                tn.ForeColor = Color.DarkSlateBlue;
                            }
                            else if (Temp_Sections.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                                     Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                            {
                                //����ģ��
                                tn.ForeColor = Color.Crimson;
                            }
                            else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'N')
                            {
                                //ȫԺĬ��ģ��
                                tn.ForeColor = Color.DarkGoldenrod;
                            }
                            else
                            {
                                //ʲô������
                                tn.ForeColor = Color.Black;
                            }
                            tn.Tag = templates;
                            tn.Text = templates.TName;
                            tn.Name = templates.Tid.ToString();
                            tn.ImageIndex = 13;
                            tn.SelectedImageIndex = 13;
                            node.Nodes.Add(tn);
                            tn.Parent.SelectedImageIndex = 6;
                            tn.Parent.ImageIndex = 6;
                            SetParentNodeExpand(tn);
                        }
                    }

                    if (node.Nodes.Count > 0)
                        setTreeView3(templates, node.Nodes);
                }
            }
        }

        public void setNodeColor(Class_Patients templates, TreeNode node)
        {
            if (templates != null)
            {
                //if (templates.Default_sec_id != "" && templates.Section_ID.ToString() != "" && templates.IsDefault == 'Y')
                if (Temp_Groups.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                {
                    //�����鼶��Ĭ��ģ��
                    node.ForeColor = Color.Teal;
                }
                else if (Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0)
                {
                    //���Ҽ�Ĭ��ģ��
                    node.ForeColor = Color.Blue;
                }
                else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'Y')
                {
                    //ȫԺĬ��ģ��
                    node.ForeColor = Color.Green;
                }
                else if (Temp_Groups.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                         Temp_Groups.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                {
                    //����ģ��
                    node.ForeColor = Color.DarkSlateBlue;
                }
                else if (Temp_Sections.Tables[0].Select("ISDEFAULT='N' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length > 0 &&
                         Temp_Sections.Tables[0].Select("ISDEFAULT='Y' and TEMPLATE_ID='" + templates.Tid.ToString() + "'").Length == 0)
                {
                    //����ģ��
                    node.ForeColor = Color.Crimson;
                }
                else if (templates.TempPlate_Level == 'H' && templates.IsDefault == 'N')
                {
                    //ȫԺĬ��ģ��
                    node.ForeColor = Color.DarkGoldenrod;
                }
                else
                {
                    //ʲô������
                    node.ForeColor = Color.Black;
                }
            }
        }

        private static void SetParentNodeExpand(TreeNode tn)
        {
            if (tn.Parent != null)
            {
                tn.Parent.Expand();
                TreeNode tempNode = tn.Parent;
                SetParentNodeExpand(tempNode);
            }
        }

        /// <summary>
        /// ʵ������ѯ���
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Datacodecs[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Datacodecs[] Directionary = new Class_Datacodecs[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Datacodecs();
                        Directionary[i].Id = tempds.Tables[0].Rows[i]["ID"].ToString();
                        Directionary[i].Name = tempds.Tables[0].Rows[i]["NAME"].ToString();
                        Directionary[i].Code = tempds.Tables[0].Rows[i]["CODE"].ToString();
                        Directionary[i].Shortchut_code = tempds.Tables[0].Rows[i]["SHORTCUT_CODE"].ToString();
                        Directionary[i].Enable = tempds.Tables[0].Rows[i]["ENABLE"].ToString();
                        Directionary[i].Type = tempds.Tables[0].Rows[i]["TYPE"].ToString();
                    }
                    return Directionary;
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
        /// ʵ��Class_Text����ѯ���
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Text[] GetSelectClassDs(DataSet tempds)
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
                        if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0")
                        {
                            class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                        }
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
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
        /// ��յ�ǰ�༭��
        /// </summary>
        private void ClearEditor()
        {
            if (Template.fmT.MyDoc.DocumentElement != null)
            {
                Template.fmT.MyDoc.DocumentElement.ClearChild();
                Template.fmT.MyDoc.ContentChanged();
            }
        }

        /// <summary>
        /// ��XML���ݲ�չʾ���༭����(��ȡ���ݿ��е����飬����ʾ���༭����)
        /// </summary>
        /// <param name="temdoc"></param>
        private void IniEditContent(string xmldoc)
        {
            try
            {
                XmlDocument temdoc = new XmlDocument();
                temdoc.LoadXml(xmldoc);
                Template.fmT.MyDoc.FromXML(temdoc.DocumentElement);

                Template.fmT.MyDoc.ContentChanged();
            }
            catch (Exception ex)
            {
                App.MsgErr("����ԭ��:" + ex);
            }
        }

        /// <summary>
        /// ����ǰ�༭���е�����ת����xml�������ַ�������ʽ���� �����ڲ������ݿ⣩
        /// </summary>
        /// <returns></returns>
        private string GetXmlContent()
        {
            XmlDocument tempxmldoc = new XmlDocument();
            tempxmldoc.PreserveWhitespace = true;
            tempxmldoc.LoadXml("<emrtextdoc/>");
            Template.fmT.MyDoc.IsHaveDeleted = true;
            Template.fmT.MyDoc.ToXML(tempxmldoc.DocumentElement);
            Template.fmT.MyDoc.IsHaveDeleted = false;
            return tempxmldoc.OuterXml;
        }

        /// <summary>
        /// �����ݿ��ȡģ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string temp = App.ReadSqlVal("select * from t_patients_doc", 1, "PATIENTS_DOC");
            IniEditContent(temp);
        }

        /// <summary>
        /// ��ģ��������ݿ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string temp = GetXmlContent();

            string filterKetWord = "select Source_word,Target_word from T_TempPlate_Filter where Enable_Flag='Y'";
            DataSet filterKetWordDS = App.GetDataSet(filterKetWord);
            if (filterKetWordDS != null)
            {
                DataTable dataTable = filterKetWordDS.Tables[0];

                string source_word = "";
                string target_word = "";
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    source_word = dataTable.Rows[i]["source_word"].ToString();
                    source_words.Add(source_word);
                    target_word = dataTable.Rows[i]["target_word"].ToString();
                    target_words.Add(target_word);
                }

                temp = IsFilter(temp, source_words);//���˹ؼ���
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(temp);

            if (current_id == "")
            {
                Template.XmlClearInfo(ref xmlDoc);
                frmTemplateSave tpSave = new frmTemplateSave(xmlDoc, treeView1, Template.fmT.MyDoc);
                App.FormStytleSet(tpSave, false);
                tpSave.ShowDialog();
            }
            else
            {
                //XmlElement xmlElement = xmlDoc.DocumentElement;
                int message = 0;
                try
                {
                    //foreach (XmlNode bodyNode in xmlElement.ChildNodes)
                    //{
                    //    if (bodyNode.Name == "body")
                    //    {
                    //        if (bodyNode.HasChildNodes)
                    //        {   //int i = 1;
                    string updateLable = "update T_TempPlate_Cont set Content=:divContent where tid=" + current_id;
                    Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
                    xmlPars[0] = new Bifrost.WebReference.OracleParameter();
                    xmlPars[0].ParameterName = "divContent";
                    //xmlPars[0].Value = divNode.OuterXml;
                    xmlPars[0].Value = temp;//bodyNode.InnerXml;
                    xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
                    xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
                    message = App.ExecuteSQL(updateLable, xmlPars);
                    if (message > 0)
                    {
                        App.Msg("����ɹ�");
                    }
                    else
                    {
                        App.MsgErr("����ʧ��");
                    }
                    //        }
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    App.MsgErr("����ʧ��,����ԭ��:" + ex.Message);
                }
            }
        }

        /// <summary>
        /// ��ѯ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string msg = "";

            if (chkDocType.Checked)
            {
                //��������
                if (rdoPersonal.Checked)
                {
                    msg += "TEMPPLATE_LEVEL='P' ";
                }
                else if (rdoSection.Checked)
                {
                    msg += "TEMPPLATE_LEVEL='S' ";
                }
                else if (rdoHospital.Checked)
                {
                    msg += "TEMPPLATE_LEVEL='H' ";
                }
                else if (rdoGroup.Checked)
                {
                    msg += "TEMPPLATE_LEVEL='G' ";
                }
                string sick_kind = "";  //������
                if (this.cboSicknessKind.Text != "��ѡ��...")
                {
                    sick_kind = this.cboSicknessKind.SelectedValue.ToString();
                    msg += "and SICK_ID='" + sick_kind + "' ";
                }
                string text_type = "";      //��������
                if (this.cboTextKind.Text != "��ѡ��...")
                {
                    text_type = this.cboTextKind.SelectedValue.ToString();
                    if (text_type.Trim() != "")
                        msg += "and TEXT_TYPE='" + text_type + "' ";
                }

                string tname = "";  //ģ������
                if (this.txtDocName.Text.Trim() != "")
                {
                    tname = this.txtDocName.Text.Trim();
                    msg += "and TNAME like '%" + tname + "%' ";
                }
            }
            else
            {
                //ʹ�÷�Χ
                if (chkAllDefault.Checked)
                {
                    //ȫԺĬ��
                    if (msg != "")
                        msg = msg + " or ";
                    msg += "(TEMPPLATE_LEVEL='H' and isdefault='Y') ";
                }
                if (chkAll.Checked)
                {
                    //ȫԺ
                    if (msg != "")
                        msg = msg + " or ";
                    msg += "(TEMPPLATE_LEVEL='H' and  isdefault='N') ";
                }
                if (chkSectionDefault.Checked)
                {
                    //����Ĭ��
                    if (msg != "")
                        msg = msg + " or ";
                    msg += "(TEMPPLATE_LEVEL='S' and tid in (select template_id from t_tempplate_section where isdefault='Y')) ";
                }
                if (chkSection.Checked)
                {
                    //����
                    if (msg != "")
                        msg = msg + " or ";
                    msg += "(TEMPPLATE_LEVEL='S' and tid not in (select template_id from t_tempplate_section where isdefault='Y')) ";
                }
                if (chkGroupDefault.Checked)
                {
                    //������Ĭ��
                    if (msg != "")
                        msg = msg + " or ";
                    msg += "tid in (select template_id from t_tempplate_group where isdefault='Y') ";
                }
                if (chkGroup.Checked)
                {
                    //������
                    if (msg != "")
                        msg = msg + " or ";
                    msg += "tid in (select template_id from t_tempplate_group) ";
                }
                if (chkPerson.Checked)
                {
                    //����
                    if (msg != "")
                        msg = msg + " or ";
                    msg += "TEMPPLATE_LEVEL='P' ";
                }
            }
            this.isQueryTag = true;   //��Ϊ��ѯ���
            ReflashBookTree(this.treeView1);
            temptrvbook = this.treeView1;
            ReflashTrvBook(msg);
        }

        ///// <summary>
        ///// ���˹ؼ���
        ///// </summary>
        ///// <param name="source"></param>
        ///// <param name="filter"></param>
        ///// <returns></returns>
        //public static string IsFilter(string source, ArrayList filter)
        //{
        //    for (int i = 0; i < filter.Count; i++)
        //    {
        //        source = source.Replace(filter[i].ToString(), target_words[i].ToString());

        //    }

        //    return source;
        //}
        /// <summary>
        /// ���˹ؼ���
        /// </summary>
        /// <param name="source">��Ҫ���˵�Դ�ļ�������Ҫ����ı༭�������ɵ�XMl��</param>
        /// <param name="filter">�ؼ���</param>
        /// <returns></returns>
        public static string IsFilter(string source, ArrayList filter)
        {
            XmlDocument doc = new XmlDocument();
            doc.PreserveWhitespace = true;
            doc.LoadXml(source);
            try
            {
                XmlElement rootElement = doc.DocumentElement;
                XmlNodeList list = doc.GetElementsByTagName("select");

                //��ȡ����֪ʶ���� ���˹ؼ���
                for (int i = 0; i < filter.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].Name == "select")
                        {
                            // keys[i] = list[i].Attributes["value"].Value;
                            if (list[j].Attributes["text"].Value.Trim() == source_words[i].ToString().Trim())
                            {
                                //list[j].Attributes["forecolor"].Value = "#FF0000";
                                list[j].Attributes["value"].Value = list[j].Attributes["name"].Value;
                                list[j].Attributes["text"].Value = list[j].Attributes["name"].Value;
                            }
                        }
                    }
                }
                source = doc.OuterXml;

                //����<span>�е�����,����Ӧ�����ֹ��ˣ��������ı���ʾǰ��ɫ
                list = doc.GetElementsByTagName("span");
                for (int i = 0; i < filter.Count; i++)
                {
                    for (int j = 0; j < list.Count; j++)
                    {
                        if (list[j].Name == "span")
                        {
                            //����
                            //ArrayList arry = getIndex(list[j].InnerText, filter[i].ToString());
                            //ArrayList test = new ArrayList();
                            //string temp = "";
                            //for (int k = 1; k <= arry.Count; k++)
                            //{
                            //    temp = list[j].InnerText.Substring((int)arry[k - 1], filter[i].ToString().Length);//(int)arry[k]-(int)arry[k-1]);
                            //    test.Add(temp);
                            //}
                            //��Ϊ���������Ҫ���˵Ĺؼ��������ڵģ���ô�ڱ༭��������Ϊͬһ��<span>��ǩ��InnerText����ģ�
                            //�����ڹ���<span>�еĹؼ���ʱ����Ҫ�ж�<span>��InnerText���Ƿ�����ؼ��֣���������Ļ��ѹؼ���
                            //���ˣ�Ȼ���ǰ��ɫ��Ϊ#FF0000
                            if (list[j].InnerText.IndexOf(filter[i].ToString()) > -1)
                            {
                                //int index = list[j].InnerText.IndexOf(filter[i].ToString());
                                //XmlNode preNode = list[j].PreviousSibling;
                                //XmlNode parNode = list[j].ParentNode;
                                //string preStr = list[i].InnerText.Substring(0, index );
                                //string targetStr = filter[i].ToString();
                                //string bckStr = list[i].InnerText.Substring(index+targetStr.Length, list[i].InnerText.Length - index-targetStr.Length);

                                //XmlElement newElement1 = doc.CreateElement("span");
                                //newElement1.SetAttribute("operatercreater", "0");
                                //newElement1.SetAttribute("fontsize", "11");
                                //newElement1.SetAttribute("forecolor", "#000000");
                                //newElement1.InnerText = preStr;
                                //parNode.AppendChild(newElement1);

                                //XmlElement newElement2 = doc.CreateElement("span");
                                //newElement2.SetAttribute("operatercreater", "0");
                                //newElement2.SetAttribute("fontsize", "11");
                                //newElement2.SetAttribute("forecolor", "#FF0000");
                                //newElement2.InnerText = targetStr;
                                //parNode.AppendChild(newElement2);

                                //XmlElement newElement3 = doc.CreateElement("span");
                                //newElement3.SetAttribute("operatercreater", "0");
                                //newElement3.SetAttribute("fontsize", "11");
                                //newElement3.SetAttribute("forecolor", "#000000");
                                //newElement3.InnerText = bckStr;
                                //parNode.AppendChild(newElement3);

                                //parNode.InsertAfter(newElement1, preNode);
                                //parNode.InsertAfter(newElement2, newElement1);
                                //parNode.InsertAfter(newElement3, newElement2);
                                //parNode.RemoveChild(list[j]);

                                list[j].InnerText = list[j].InnerText.Replace(source_words[i].ToString().Trim(), target_words[i].ToString());
                                if (list[j].Attributes["forecolor"] != null)
                                    list[j].Attributes["forecolor"].Value = "#FF0000";
                            }
                        }
                    }
                }
                source = doc.OuterXml;
                return source;
            }
            catch
            {
                return doc.OuterXml;
            }
        }

        //foreach (XmlNode body in rootElement.ChildNodes)
        //{
        //    if (body.Name == "body")
        //    {
        //        if (body.HasChildNodes)
        //        {
        //            foreach (XmlNode div in body.ChildNodes)
        //            {
        //                if (div.Name == "div")
        //                {
        //                    if (div.HasChildNodes)
        //                    {
        //                        foreach (XmlNode select in div.ChildNodes)
        //                        {
        //                            if (select.Name == "select")
        //                            {
        //                                if (select.Attributes["text"].Value.Trim() == source_words[i].ToString().Trim())
        //                                {
        //                                    select.Attributes["value"].Value = select.Attributes["name"].Value;
        //                                    select.Attributes["text"].Value = select.Attributes["name"].Value;
        //                                }
        //                            }
        //                        }
        //                    }

        //                }
        //            }
        //        }
        //    }
        //}
        //source = source.Replace(filter[i].ToString(), target_words[i].ToString());

        /// <summary>
        /// ����һ���ַ����г����ض��ַ��Ĵ�������ÿ�γ��ֵ��ַ�������������
        /// </summary>
        /// <param name="str">Դ�ַ���</param>
        /// <param name="value">��Ҫ���ҵ�Ŀ�괮</param>
        /// <returns></returns>
        public static ArrayList getIndex(string str, string value)
        {
            ArrayList list = new ArrayList();

            list.Add(0);//list�еĵ�һ��λ�ù̶�Ϊ�ַ�������ʼλ��
            int i = -1, x = -1;
            do
            {
                i = str.IndexOf(value, ++i);
                list.Add(i);
                x++;
            } while (i != -1);

            return list;
        }

        public void InitTree()
        {
            DataSet ds = App.GetDataSet("select Tid,TName from T_TempPlate");

            patients = new Class_Patients[ds.Tables[0].Rows.Count];

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                patients[i] = new Class_Patients();
                patients[i].Tid = Convert.ToInt32(ds.Tables[0].Rows[i]["TID"].ToString());
                patients[i].TName = ds.Tables[0].Rows[i]["TName"].ToString();

                TreeNode tnRoot = new TreeNode();
                tnRoot.Tag = patients[i];
                tnRoot.Text = patients[i].TName;
                treeView1.Nodes.Add(tnRoot);

                //if (tnRoot != null)
                //{
                //    DataSet dsLableName = App.GetDataSet("select LableName,Content from T_TempPlate_Cont where tid=" + patients[i].Tid);

                //    patients_conts =new Class_Patients_Cont[dsLableName.Tables[0].Rows.Count];
                //    for (int j = 0; j < dsLableName.Tables[0].Rows.Count; j++)
                //    {
                //        TreeNode childNode = new TreeNode();
                //        patients_conts[j]=new Class_Patients_Cont();
                //        patients_conts[j].LableName = dsLableName.Tables[0].Rows[j]["LableName"].ToString();//���ñ�ǩ����
                //        patients_conts[j].Content = dsLableName.Tables[0].Rows[j]["Content"].ToString();//���ñ�ǩ����

                //        childNode.Tag = patients_conts[j];
                //        childNode.Text = patients_conts[j].LableName;

                //        tnRoot.Nodes.Add(childNode);//���븸�ڵ�
                //    }

                //}
            }
        }

        public void InitTree(int strSys_ID, int strSick_ID, int strTextKind_ID)
        {
            //DataSet ds = App.GetDataSet("select * from t_patients_doc t where textkind_id=" + strSys_ID + " ,belongtosys_id=" + strSick_ID + " ,sickkind_id=" + strTextKind_ID);

            //Class_patients_doc[] patients_docs = new Class_patients_doc[ds.Tables[0].Rows.Count];

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    patients_docs[i] = new Class_patients_doc();
            //    patients_docs[i].Tid = ds.Tables[0].Rows[i]["TID"].ToString();
            //    patients_docs[i].Pid = ds.Tables[0].Rows[i]["PID"].ToString();
            //    patients_docs[i].TextName = ds.Tables[0].Rows[i]["TEXTNAME"].ToString();
            //    //patients_docs[i].Patients_doc = ds.Tables[0].Rows[i]["patients_doc"].ToString();

            //    TreeNode tn = new TreeNode();
            //    tn.Tag = patients_docs[i];
            //    tn.Text = patients_docs[i].TextName;

            //    treeView1.Nodes.Add(tn);
            //}
        }

        /// <summary>
        /// ����༭������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewPage_Click(object sender, EventArgs e)
        {
            Template.fmT.MyDoc.ClearContent();
        }

        private void ɾ������ģ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result = App.Ask("ȷ��Ҫɾ����");
            if (result)
            {
                Class_Patients pdoc = (Class_Patients)treeView1.SelectedNode.Tag;

                //int i=App.ExecuteSQL("delete from t_patients_doc where tid="+pdoc.Tid);

                string delPatients_Doc = "delete from t_tempplate where tid=" + pdoc.Tid;

                string delModel_Lable = "delete from t_tempplate_cont where tid=" + pdoc.Tid;
                //string delStruct = "delete from T_Struct where tid=" + pdoc.Tid;
                string[] strSqls = { delPatients_Doc, delModel_Lable };
                int i = App.ExecuteBatch(strSqls);
                if (i > 0)
                {
                    MessageBox.Show("ɾ���ɹ�");
                    //InitTree it = new InitTree();
                    //it.InitTreeControl(this.treeView1);
                    //this.treeView1.Nodes.Clear();
                    //ReflashBookTree(this.treeView1);
                    //temptrvbook = this.treeView1;
                    //ReflashTrvBook();
                    this.treeView1.SelectedNode.Remove();

                    Template.fmT.MyDoc.ClearContent();
                    //InitTree();
                }
                else
                {
                    MessageBox.Show("ɾ��ʧ��");
                }
            }
        }

        /// <summary>
        /// ģ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiRename_Click(object sender, EventArgs e)
        {
            frmRenameTemplate renameTemplate = new frmRenameTemplate(current_id, this);
            App.FormStytleSet(renameTemplate, false);
            renameTemplate.Show();
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            treeView1.SelectedNode = treeView1.GetNodeAt(e.X, e.Y);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LeftMouseClick();
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {
            //LeftMouseClick();   //�����������¼�

            //    Class_patients_doc doc = (Class_patients_doc)treeView1.SelectedNode.Tag;
            //    string temp = App.ReadSqlVal("select * from t_patients_doc where tid=" + doc.Tid + "", 0, "PATIENTS_DOC");
            //    Class_patients_doc pdoc = (Class_patients_doc)treeView1.SelectedNode.Tag;
            //    IniEditContent(temp);
            //}
        }

        private void LeftMouseClick()
        {
            ctmTreeViewMenu.Enabled = true;
            //if (e.Button == MouseButtons.Left)
            //{
            if (treeView1.SelectedNode.Tag.GetType().ToString().Contains("Class_Patients"))
            {
                toolStripMenuItem1.Enabled = false;
                ɾ������ģ��ToolStripMenuItem.Enabled = true;
                tsmiRename.Enabled = true;
                tsmiModel.Enabled = true;
                tsmiDefaultModel.Enabled = true;
                //tsmiSetSection.Enabled = true;
                tsmiSetSectionModel.Enabled = true;
                tsmiSetGroupModel.Enabled = true;
                ��������ToolStripMenuItem.Enabled = true;
                button2.Enabled = true;
                Class_Patients doc = (Class_Patients)treeView1.SelectedNode.Tag;

                current_id = doc.Tid.ToString();
                string temp = "select Content from T_TempPlate_Cont where tid=" + doc.Tid;

                DataSet dsTemp = App.GetDataSet(temp);
                DataTable dtTemp = dsTemp.Tables[0];
                string content = "";
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    content = content + dtTemp.Rows[i][0].ToString();
                }
                xmlDoc = new XmlDocument();//����XML����������
                xmlDoc.PreserveWhitespace = true;
                if (content.Contains("emrtextdoc"))
                {
                    xmlDoc.LoadXml(content);
                }
                else
                {
                    string strXml = GetXmlContent();
                    xmlDoc.LoadXml(strXml);
                    xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

                    foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                    {
                        if (bodyNode.Name == "body")
                        {
                            bodyNode.InnerXml = content;
                        }
                    }
                }
                Template.fmT.MyDoc.FromXML(xmlDoc.DocumentElement);
                Template.fmT.MyDoc.OwnerControl.EnableSmartTag = true;
                Template.fmT.MyDoc.ContentChanged();
            }
            else
            {
                if (treeView1.SelectedNode.Parent == null)
                    ctmTreeViewMenu.Enabled = false;
                else
                {
                    ctmTreeViewMenu.Enabled = true;
                    if (treeView1.SelectedNode.Nodes.Count > 0)
                    {
                        if (treeView1.SelectedNode.Nodes[0].Tag.GetType().ToString().Contains("Class_Patients"))
                        {
                            ɾ������ģ��ToolStripMenuItem.Enabled = false;
                            ��������ToolStripMenuItem.Enabled = false;
                            tsmiRename.Enabled = false;
                            tsmiDefaultModel.Enabled = false;
                            tsmiModel.Enabled = false;
                            //tsmiSetSection.Enabled = false;
                            tsmiSetSectionModel.Enabled = false;
                            tsmiSetGroupModel.Enabled = false;
                            toolStripMenuItem1.Enabled = true;
                            button2.Enabled = false;
                        }
                        else
                        {
                            ctmTreeViewMenu.Enabled = false;
                            button2.Enabled = false;
                        }
                    }
                    else
                    {
                        ɾ������ģ��ToolStripMenuItem.Enabled = false;
                        ��������ToolStripMenuItem.Enabled = false;
                        tsmiRename.Enabled = false;
                        tsmiModel.Enabled = false;
                        //tsmiSetSection.Enabled = false;
                        tsmiSetSectionModel.Enabled = false;
                        tsmiSetGroupModel.Enabled = false;
                        tsmiDefaultModel.Enabled = false;
                        toolStripMenuItem1.Enabled = true;
                        button2.Enabled = false;
                    }
                }
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            //Class_Patients_Cont doc = (Class_Patients_Cont)treeView1.SelectedNode.Tag;
            //xmlDoc = new XmlDocument();//����XML����������
            //xmlDoc.Load(@"C:\tempplate.xml");
            //xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

            //string temp = "select Content from T_TempPlate_Cont where tid=" + doc.Tid;

            //DataSet dsTemp = App.GetDataSet(temp);
            //DataTable dtTemp = dsTemp.Tables[0];
            //string content = "";
            //for (int i = 0; i < dtTemp.Rows.Count; i++)
            //{
            //    content = content + dtTemp.Rows[i][0].ToString();
            //}

            //foreach (XmlNode bodyNode in xmlNode.ChildNodes)
            //{
            //    if (bodyNode.Name == "body")
            //    {
            //        //if (treeView1.SelectedNode.Checked)
            //        //{ doc.Content += doc.Content; }
            //        bodyNode.InnerXml = doc.Content;
            //    }
            //}
            //Template.fmT.MyDoc.FromXML(xmlDoc.DocumentElement);
            //Template.fmT.MyDoc.ContentChanged();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            current_id = "";
            Template.fmT.MyDoc.ClearContent();
            if (treeView1.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
            {
                Class_Text text = (Class_Text)this.treeView1.SelectedNode.Tag;
                text_kind = text.Id;
            }
            this.button2.Enabled = true;
        }

        public static string SelectTempContent = "";

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmTemplateList ff = new frmTemplateList();
            App.FormStytleSet(ff, false);
            ff.ShowDialog();
            if (SelectTempContent != "")
            {
                xmlDoc = new XmlDocument();//����XML����������
                string strXml = GetXmlContent();
                //xmlDoc.Load(@"C:\tempplate.xml");
                xmlDoc.LoadXml(strXml);
                xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                {
                    if (bodyNode.Name == "body")
                    {
                        bodyNode.InnerXml = SelectTempContent;
                    }
                }
                Template.fmT.MyDoc.FromXML(xmlDoc.DocumentElement);
                Template.fmT.MyDoc.ContentChanged();
            }
        }

        //����Ҽ���ʱ�����¼�
        private void ctmTreeViewMenu_Opening(object sender, CancelEventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType().ToString().Contains("Class_Patients"))
            {
                Class_Patients pdoc = (Class_Patients)treeView1.SelectedNode.Tag;
                string sql = "select ISDEFAULT,DEFAULT_SEC_ID from T_TempPlate where tid=" + pdoc.Tid;
                isdefault = App.ReadSqlVal(sql, 0, "ISDEFAULT");
                if (App.ReadSqlVal(sql, 0, "DEFAULT_SEC_ID").ToString() != "")
                {
                    default_sec = "Y";
                }
                else
                {
                    default_sec = "N";
                }

                //�ж�Ĭ��ģ��
                if (isdefault == "Y" && default_sec == "N")
                {
                    tsmiDefaultModel.Enabled = false;
                }
                else
                {
                    tsmiDefaultModel.Enabled = true;
                    tsmiSetSectionModel.Enabled = true;
                }
            }
        }

        //����ΪȫԺĬ��ģ��
        private void tsmiDefaultModel_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType().ToString().Contains("Class_Patients"))
            {
                Class_Patients pdoc = (Class_Patients)treeView1.SelectedNode.Tag;
                TreeNode selectedNode = treeView1.SelectedNode;
                TreeNode parentNode = selectedNode.Parent;
                string[] sqls = new string[3];
                int x = 0;

                //ȡ����ģ��
                string oldSql = "select * from T_TempPlate where TEXT_TYPE='" + parentNode.Name + "' and ISDEFAULT='Y' and DEFAULT_SEC_ID is null and SECTION_ID is null";
                string oldId = App.ReadSqlVal(oldSql, 0, "TID");
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.Name == oldId)
                    {
                        node.ForeColor = SystemColors.ControlText;   //��ģ��
                    }
                }

                //Ĭ��ģ���ȡ��
                sqls[0] = "update T_TempPlate set ISDEFAULT='N',DEFAULT_SEC_Id=null,SECTION_ID=null where DEFAULT_SEC_ID is null and TEXT_TYPE='" + parentNode.Name + "' and SECTION_ID is null and ISDEFAULT='Y'";

                //����Ĭ��ģ��
                sqls[1] = "update T_TempPlate set tempplate_level='H',ISDEFAULT='Y',DEFAULT_SEC_Id=null,SECTION_ID=null where tid =" + pdoc.Tid;

                //ɾ�����еĿ���ģ������
                sqls[2] = "delete from t_tempplate_section t where TEMPLATE_ID=" + pdoc.Tid + "";
                x = App.ExecuteBatch(sqls);

                selectedNode.ForeColor = Color.Green;  //��ģ��

                if (x > 0)
                {
                    App.Msg("���óɹ�!");
                }
            }
        }

        /// <summary>
        /// ����ΪȫԺģ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiModel_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType().ToString().Contains("Class_Patients"))
            {
                Class_Patients pdoc = (Class_Patients)treeView1.SelectedNode.Tag;
                TreeNode selectedNode = treeView1.SelectedNode;
                TreeNode parentNode = selectedNode.Parent;
                string[] sqls = new string[2];
                int x = 0;

                //ȡ����ģ��
                string oldSql = "select * from T_TempPlate where TEXT_TYPE='" + parentNode.Name + "' and ISDEFAULT='Y' and DEFAULT_SEC_ID is null and SECTION_ID is null";
                string oldId = App.ReadSqlVal(oldSql, 0, "TID");
                foreach (TreeNode node in parentNode.Nodes)
                {
                    if (node.Name == oldId)
                    {
                        node.ForeColor = SystemColors.ControlText;   //��ģ��
                    }
                }

                //����Ĭ��ģ��
                sqls[0] = "update T_TempPlate set tempplate_level='H',ISDEFAULT='N',DEFAULT_SEC_Id=null,SECTION_ID=null where tid =" + pdoc.Tid;

                //ɾ�����еĿ���ģ������
                sqls[1] = "delete from t_tempplate_section t where TEMPLATE_ID=" + pdoc.Tid + "";
                x = App.ExecuteBatch(sqls);

                selectedNode.ForeColor = Color.DarkGoldenrod;  //��ģ��

                if (x > 0)
                {
                    App.Msg("���óɹ�!");
                }
            }
        }

        //����Ĭ�Ͽ���ģ��
        private void tsmiSetSection_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType().ToString().Contains("Class_Patients"))
            {
                frmSetSectionTemplate sectionTemplate = new frmSetSectionTemplate(current_id, this, treeView1.SelectedNode.Parent.Name);
                App.FormStytleSet(sectionTemplate, false);
                sectionTemplate.Show();
                Class_Patients tempcls = (Class_Patients)treeView1.SelectedNode.Tag;
                setNodeColor(tempcls, treeView1.SelectedNode);
            }
        }

        //��Ϊ����ģ��
        private void tsmiSetSectionModel_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType().ToString().Contains("Class_Patients"))
            {
                ucTemplateManagement.isSecDefault = "false";
                frmSetSecModel secModel = new frmSetSecModel(current_id, this);
                App.FormStytleSet(secModel, false);
                secModel.ShowDialog();

                //Color tempColor = new Color();
                //tempColor = treeView1.SelectedNode.ForeColor;
                //if (ucTemplateManagement.isSecDefault=="true")
                //{
                //    treeView1.SelectedNode.ForeColor = Color.Blue;
                //}
                //else if (ucTemplateManagement.isSecDefault == "false")
                //{
                //    treeView1.SelectedNode.ForeColor = Color.Crimson;
                //}
                //else
                //{
                //    treeView1.SelectedNode.ForeColor = tempColor;
                //}
                Class_Patients tempcls = (Class_Patients)treeView1.SelectedNode.Tag;
                setNodeColor(tempcls, treeView1.SelectedNode);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (File.Exists(App.SysPath + "\\ModelFiles"))
            {
                Directory.Delete(App.SysPath + "\\ModelFiles", true);
            }

            Directory.CreateDirectory(App.SysPath + "\\ModelFiles");

            CreateDirByTree(treeView1.Nodes, App.SysPath + "\\ModelFiles");

            CreateFilesBytree(treeView1.Nodes, App.SysPath + "\\ModelFiles");
            App.Msg("���������Ѿ��ɹ���");
        }

        /// <summary>
        /// ���ݵ�ǰ���ڵ㴴���ļ�Ŀ¼
        /// </summary>
        /// <param name="nodes">�ڵ㼯��</param>
        private void CreateDirByTree(TreeNodeCollection nodes, string path)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].ImageIndex != 13)
                {
                    nodes[i].Text = App.ToDBC(nodes[i].Text);
                    string ntxt = "";
                    if (nodes[i].Text.Contains(@"/"))
                    {
                        ntxt = nodes[i].Text.Replace('/', '-');
                    }
                    else if (nodes[i].Text.Contains(@"?"))
                    {
                        ntxt = nodes[i].Text.Replace('?', '-');
                    }
                    else if (nodes[i].Text.Contains(@","))
                    {
                        ntxt = nodes[i].Text.Replace(',', '-');
                    }
                    else
                    {
                        ntxt = App.ToDBC(nodes[i].Text);
                    }
                    Directory.CreateDirectory(path + "\\" + nodes[i].Name + "," + ntxt);
                    if (nodes[i].Nodes.Count > 0)
                    {
                        CreateDirByTree(nodes[i].Nodes, path + "\\" + nodes[i].Name + "," + ntxt);
                    }
                }
            }
        }

        /// <summary>
        /// ���ݵ�ǰ���ڵ㴴���ļ�Ŀ¼
        /// </summary>
        /// <param name="nodes">�ڵ㼯��</param>
        private void CreateFilesBytree(TreeNodeCollection nodes, string path)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].ImageIndex == 13)
                {
                    //XmlDocument xmlDoc = new XmlDocument();
                    //xmlDoc.LoadXml();
                    //xmlDoc.Save(path + "\\" + nodes[i].Text);

                    Class_Patients doc = (Class_Patients)nodes[i].Tag;
                    xmlDoc = new XmlDocument();//����XML����������
                    xmlDoc.PreserveWhitespace = true;
                    string strXml = GetXmlContent();
                    //xmlDoc.Load(@"C:\tempplate.xml");
                    xmlDoc.LoadXml(strXml);
                    xmlNode = xmlDoc.SelectSingleNode("emrtextdoc");//����<body>

                    current_id = doc.Tid.ToString();
                    string temp = "select Content from T_TempPlate_Cont where tid=" + doc.Tid;

                    DataSet dsTemp = App.GetDataSet(temp);
                    DataTable dtTemp = dsTemp.Tables[0];
                    string content = "";
                    for (int j = 0; j < dtTemp.Rows.Count; j++)
                    {
                        content = content + dtTemp.Rows[j][0].ToString();
                    }

                    foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                    {
                        if (bodyNode.Name == "body")
                        {
                            bodyNode.InnerXml = content;
                        }
                    }
                    nodes[i].Text = App.ToDBC(nodes[i].Text);
                    string ntxt = "";
                    if (nodes[i].Text.Contains(@"/"))
                    {
                        ntxt = nodes[i].Text.Replace('/', '-');
                    }
                    if (nodes[i].Text.Contains(@"?"))
                    {
                        ntxt = ntxt.Replace('?', '_');
                    }
                    if (nodes[i].Text.Contains(@","))
                    {
                        ntxt = ntxt.Replace(',', '_');
                    }
                    if (nodes[i].Text.Contains(@":"))
                    {
                        ntxt = ntxt.Replace(':', '_');
                    }

                    //if (ntxt.Length > 0)
                    //{
                    //    if(ntxt.Substring(ntxt.Length - 1, 1)=="-")
                    //    {
                    //        ntxt=ntxt+"1";
                    //    }
                    //}

                    xmlDoc.Save(path + "\\ModlFile_" + ntxt + ".xml");
                }
                else
                {
                    if (nodes[i].Nodes.Count > 0)
                    {
                        nodes[i].Text = App.ToDBC(nodes[i].Text);
                        string ntxt = "";
                        if (nodes[i].Text.Contains(@"/"))
                        {
                            ntxt = nodes[i].Text.Replace('/', '-');
                        }
                        else if (nodes[i].Text.Contains(@"?"))
                        {
                            ntxt = nodes[i].Text.Replace('?', '-');
                        }
                        else if (nodes[i].Text.Contains(@","))
                        {
                            ntxt = nodes[i].Text.Replace(',', '-');
                        }
                        else
                        {
                            ntxt = App.ToDBC(nodes[i].Text);
                        }
                        CreateFilesBytree(nodes[i].Nodes, path + "\\" + nodes[i].Name + "," + ntxt);
                    }
                }
            }
        }

        /// <summary>
        /// ����Ϊ������ģ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiSetGroupModel_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode.Tag.GetType().ToString().Contains("Class_Patients"))
            {
                ucTemplateManagement.isGroupDefault = "false";
                frmSetGroupModel goupModel = new frmSetGroupModel(current_id, this);
                App.FormStytleSet(goupModel, false);
                goupModel.ShowDialog();

                Class_Patients tempcls = (Class_Patients)treeView1.SelectedNode.Tag;
                setNodeColor(tempcls, treeView1.SelectedNode);
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class_Patients pdoc = (Class_Patients)treeView1.SelectedNode.Tag;
            frmPropertySet fm = new frmPropertySet(pdoc.Tid.ToString());
            App.FormStytleSet(fm, false);
            fm.ShowDialog();
        }

        /// <summary>
        /// ��ӡ˳������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblDocOrderSet_Click(object sender, EventArgs e)
        {
            frmPrintOrderSet fc = new frmPrintOrderSet();
            App.FormStytleSet(fc, false);
            fc.ShowDialog();
        }

        private void chkDocType_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDocType.Checked)
            {
                chkRange.Checked = false;
                panelDocType.Enabled = true;
                panelRange.Enabled = false;
                chkAllDefault.Checked = false;
                chkSectionDefault.Checked = false;
                chkSection.Checked = false;
                chkPerson.Checked = false;
                chkGroup.Checked = false;
                chkGroupDefault.Checked = false;
                chkAll.Checked = false;
            }
            else
            {
                chkRange.Checked = true;
            }
        }

        private void chkRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRange.Checked)
            {
                chkDocType.Checked = false;
                panelDocType.Enabled = false;
                panelRange.Enabled = true;
            }
            else
            {
                chkDocType.Checked = true;
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataSet ds = App.GetDataSet("select tid from t_tempplate");//t_tempplate t_tempplate_cont

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                /*
                 * ��ȡ�ļ�
                 */
                DataSet dss = App.GetDataSet("select a.content from t_tempplate_cont a where a.tid=" + ds.Tables[0].Rows[i][0].ToString() + "");
                string content = dss.Tables[0].Rows[i][0].ToString();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(content);

                //string updateLable = "update T_TempPlate_Cont set Content=:divContent where tid=" + current_id;
                //Bifrost.WebReference.OracleParameter[] xmlPars = new Bifrost.WebReference.OracleParameter[1];
                //xmlPars[0] = new Bifrost.WebReference.OracleParameter();
                //xmlPars[0].ParameterName = "divContent";
                ////xmlPars[0].Value = divNode.OuterXml;
                //xmlPars[0].Value = temp;//bodyNode.InnerXml;
                //xmlPars[0].OracleType = Bifrost.WebReference.OracleType.Clob;
                //xmlPars[0].Direction = Bifrost.WebReference.ParameterDirection.Input;
                //message = App.ExecuteSQL(updateLable, xmlPars);
            }
        }
    }
}