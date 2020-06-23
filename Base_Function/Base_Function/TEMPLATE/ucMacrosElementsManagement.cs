using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;
using EmrCommon;
using TextEditor;
using System.Collections;
using System.Data;
using Bifrost;

namespace Base_Function.TEMPLATE
{
    public partial class ucMacrosElementsManagement : UserControl
    {
        public ucMacrosElementsManagement()
        {
            InitializeComponent();
            this.LoadData();
            this.LoadMenus();
            this.tvMacrosElements.NodeMouseDoubleClick += this.TvMacrosElements_NodeMouseDoubleClick;
            editorControl.Dock = DockStyle.Fill;
            this.pText.Controls.Add(this.editorControl);
        }

        private List<EmrCommon.DataEntity> roots = new List<EmrCommon.DataEntity>();
        private List<T_MACROS_ELEMENTS> elements = new List<T_MACROS_ELEMENTS>();
        private List<EmrCommon.MenuItemAction> menus = new List<EmrCommon.MenuItemAction>();
        private UcEditorControl editorControl = new UcEditorControl();

        private void LoadData()
        {
            this.roots.Clear();
            this.elements.Clear();
            var res = DataInit.GetMacrosKinds();
            if (res != null)
            {
                roots.AddRange(res);
            }
            //var res2 = EmrDAL.DbQuery.Query<T_MACROS_ELEMENTS>();
            //if (res2 != null)
            //{
            //    this.elements.AddRange(res2);
            //}
            this.LoadTree();
        }

        private void LoadTree()
        {
            this.tvMacrosElements.Nodes.Clear();
            //this.roots.ForEach(o =>
            //{
            //    TreeNode tn = new TreeNode();
            //    tn.Text = o.Name;
            //    tn.Tag = o.Id;
            //    this.tvMacrosElements.Nodes.Add(tn);
            //    var res = this.elements.FindAll(o1 => o1.Type == o.Id);
            //    if (res != null)
            //    {
            //        res.ForEach(o2 =>
            //        {
            //            TreeNode tnChild = new TreeNode();
            //            tnChild.Text = o2.Name;
            //            tnChild.Tag = o2;
            //            tn.Nodes.Add(tnChild);
            //        });
            //    }
            //});

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
                            DataRow[] rows = dsMacros.Tables[0].Select("Type=" + roots[i].Id + "");
                            for (int k = 0; k < rows.Length; k++)
                            {
                                TreeNode tnChild = new TreeNode();
                                T_MACROS_ELEMENTS macros = new T_MACROS_ELEMENTS();

                                if (rows[k]["Id"] != null)
                                    macros.Id = Convert.ToInt32(rows[k]["Id"]);
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
                                    if (App.IsNumeric(rows[k]["Select_Index"].ToString()))
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

        private void LoadMenus()
        {
            menus.Clear();
            menus.Add(new EmrCommon.MenuItemAction() { Name = "新增", Action = Add });
            menus.Add(new EmrCommon.MenuItemAction() { Name = "修改", Action = Modify });
            menus.Add(new EmrCommon.MenuItemAction() { Name = "删除", Action = Delete });
            this.contextMenuStrip1.Items.Clear();
            this.menus.ForEach(o =>
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Text = o.Name;
                if (o.Action != null)
                    menuItem.Click += new EventHandler(o.Action);
                this.contextMenuStrip1.Items.Add(menuItem);
            });
        }

        /// <summary>
        /// 修改
        /// </summary>
        private void Modify(object sender, EventArgs e)
        {
            if (this.tvMacrosElements.SelectedNode != null)
            {
                var entity = tvMacrosElements.SelectedNode.Tag.As<T_MACROS_ELEMENTS>();
                if (entity != null)
                {
                    frmMacrosElement frm = new frmMacrosElement(entity);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.LoadData();
                    }
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        private void Delete(object sender, EventArgs e)
        {
            if (this.tvMacrosElements.SelectedNode != null)
            {
                var entity = tvMacrosElements.SelectedNode.Tag.As<T_MACROS_ELEMENTS>();
                if (entity != null)
                {
                   // bool res = EmrDAL.DbCud.Delete<T_MACROS_ELEMENTS>(o => o.Id == entity.Id);
                    string sqldel = "delete from T_MACROS_ELEMENTS where id="+ entity.Id+ "";

                    if (App.ExecuteSQL(sqldel)>0)
                    {
                        Bifrost.App.Msg("操作成功!");
                        this.LoadData();
                    }
                    else
                        Bifrost.App.Msg("操作失败!");
                }
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        private void Add(object sender, EventArgs e)
        {
            if (this.tvMacrosElements.SelectedNode != null)
            {
                var type = tvMacrosElements.SelectedNode.Tag.As<string>();
                if (type.IsNotEmpty())
                {
                    frmMacrosElement frm = new frmMacrosElement(type);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        this.LoadData();
                    }
                }
            }
        }

        private void TvMacrosElements_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (this.tvMacrosElements.SelectedNode.Tag is T_MACROS_ELEMENTS)
            {                
                var entity = this.tvMacrosElements.SelectedNode.Tag.As<T_MACROS_ELEMENTS>();
                var emrDoc = editorControl.EMRDoc;
                List<ZYTextElement> elements = new List<ZYTextElement>();
                ArrayList list1 = new ArrayList();                
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.IsNotEmpty())
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml("<emrdoc/>");
                editorControl.EMRDoc.ToXML(xmldoc.DocumentElement);
                var nodes = xmldoc.GetElementsByTagName("body");
                if (nodes != null && nodes.Count > 0)
                {
                    DataInit.Filter(nodes[0].As<XmlElement>(), this.textBox1.Text.ParseTo<int>());
                }
                this.editorControl.EMRDoc.FromXML(xmldoc.DocumentElement);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.editorControl.EMRDoc.ClearContent();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml("<emrdoc/>");
            editorControl.EMRDoc.ToXML(xmldoc.DocumentElement);
            var inputs = xmldoc.GetElementsByTagName("input");
            if (inputs != null && inputs.Count > 0)
            {
                inputs.Cast<XmlElement>().ToList().ForEach(o =>
                {
                    o.InnerText = "";
                });
            }
            editorControl.EMRDoc.FromXML(xmldoc.DocumentElement);
        }
    }
}