using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.TEMPLATE
{
    /// <summary>
    /// ����Ĵ�ӡ˳������
    /// ���ߣ�
    /// ʱ�䣺
    /// </summary>
    public partial class frmPrintOrderSet : DevComponents.DotNetBar.Office2007Form
    {


        public frmPrintOrderSet()
        {
            InitializeComponent();
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
                this.trvTextView.Nodes.Clear();
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

        private void frmPrintOrderSet_Load(object sender, EventArgs e)
        {
            ReflashBookTree(this.trvTextView);
        }

        private void trvTextView_AfterSelect(object sender, TreeViewEventArgs e)
        {                      
            RefleshData();            
        }

        /// <summary>
        /// ˢ������
        /// </summary>
        private void RefleshData()
        {
            if (trvTextView.SelectedNode != null)
            {
                DataSet ds = App.GetDataSet("select id,textname,PRINTORDER,(case when ISNEWPAGE='Y' then '��' else '��' end) ISNEWPAGE from T_TEXT where PARENTID=" + trvTextView.SelectedNode.Name + " order by PRINTORDER,id ");
                dataGvText.DataSource = ds.Tables[0].DefaultView;
                dataGvText.Columns["id"].HeaderText = "����";
                dataGvText.Columns["textname"].HeaderText = "��������";
                dataGvText.Columns["PRINTORDER"].HeaderText = "��ӡ˳��";
                dataGvText.Columns["ISNEWPAGE"].HeaderText = "�Ƿ�ҳ";

                dataGvText.Columns["id"].ReadOnly = true;
                dataGvText.Columns["textname"].ReadOnly = true;
                dataGvText.Columns["ISNEWPAGE"].ReadOnly = true;              
                dataGvText.AutoResizeColumns();

                for (int i = 0; i < dataGvText.RowCount; i++)
                {                  
                    if (dataGvText["ISNEWPAGE", i].Value.ToString() == "��")
                    {
                        dataGvText.Rows[i].DefaultCellStyle.ForeColor = Color.Blue;
                    }                   
                }

            }
        }

        /// <summary>
        /// �Զ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoOrder_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            for (int i = 0; i < dataGvText.RowCount; i++)
            {
                sqls.Add("update t_text set PRINTORDER=" + i.ToString() + " where ID=" + dataGvText["id",i].Value.ToString()+ "");
            }

            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                App.Msg("�����ɹ���");
                RefleshData();
            }
            else
            {
                App.MsgErr("����ʧ�ܣ�");
            }
        }

        /// <summary>
        /// �޸ı���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            for (int i = 0; i < dataGvText.RowCount; i++)
            {
                string PRINTORDER = "0";
                if (dataGvText["PRINTORDER", i].Value.ToString() != "")
                {
                    PRINTORDER = dataGvText["PRINTORDER", i].Value.ToString();
                }

                string ISNEWPAGE = "0";
                if (dataGvText["ISNEWPAGE", i].Value.ToString() == "��")
                {
                    ISNEWPAGE = "1";
                }
                sqls.Add("update t_text set PRINTORDER=" +PRINTORDER + ",ISNEWPAGE=" +ISNEWPAGE + " where ID=" + 
                    dataGvText["id", i].Value.ToString() + "");
            }

            if (App.ExecuteBatch(sqls.ToArray()) > 0)
            {
                App.Msg("�����ɹ���");
                RefleshData();
            }
            else
            {
                App.MsgErr("����ʧ�ܣ�");
            }
        }               

        /// <summary>
        /// ˫�������Ƿ�������һҳ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGvText_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (dataGvText.RowCount > 0)
            {
                if (e.ColumnIndex != -1)
                {
                    if (dataGvText.Columns[e.ColumnIndex].HeaderText == "�Ƿ�ҳ")
                    {
                        if (dataGvText["ISNEWPAGE", e.RowIndex].Value.ToString() == "" ||
                            dataGvText["ISNEWPAGE", e.RowIndex].Value.ToString() == "��")
                        {
                            dataGvText["ISNEWPAGE", e.RowIndex].Value = "��";
                            dataGvText.CurrentRow.DefaultCellStyle.ForeColor = Color.Blue;
                        }
                        else
                        {
                            dataGvText["ISNEWPAGE", e.RowIndex].Value = "��";
                            dataGvText.CurrentRow.DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }

            }
        }
    }


    /// <summary>
    /// �����б���Ϣ
    /// </summary>
    public class tText
    {
        /// <summary>
        /// ��������
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ����˳��
        /// </summary>
        private int order;
        public int Order
        {
            get { return order; }
            set { order = value; }
        }

        /// <summary>
        /// �����Ƿ�����һҳ
        /// </summary>
        private int isNewPage;
        public int IsNewPage
        {
            get { return isNewPage; }
            set { isNewPage = value; }
        }
    }
}