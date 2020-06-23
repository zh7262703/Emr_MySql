using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.AdvTree;
using TextEditor.TextDocument.Document;
using TextEditor.TextDocument.frmWindow;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR;
using System.Reflection;
using System.Linq;

namespace Base_Function.BLL_DIAGNOSE
{
    public partial class frmDiagnoseSimple : DevComponents.DotNetBar.Office2007Form
    {
        public InPatientInfo patient;
        bool flage;
        int x;
        public frmDiagnoseSimple(InPatientInfo _patient)
        {

            InitializeComponent();
            x= this.tcDiagnose.SelectedTabIndex;
            flage = false;
            string sql = "select t.id,t.name from t_data_code t where t.type = '65' order by t.order_id";
            DataTable typeTable = App.GetDataSet(sql).Tables[0];
            this.comboBox1.DataSource = typeTable;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "id";
            this.comboBox2.DataSource = typeTable.Copy();
            this.comboBox2.DisplayMember = "name";
            this.comboBox2.ValueMember = "id";

            DateTime NewTime = App.GetSystemTime();
            this.dateTimePicker1.Value = NewTime;
            this.dateTimePicker2.Value = NewTime;
            this.patient = _patient;
            this.tcpWestern.Controls.Add(this.txtDiagnose.listBoxAutoComplete);
            this.txtDiagnose.SetPoint();
            this.txtDiagnose.OnReturnId = ReturnId;
            this.tcpChinese.Controls.Add(this.txtBm.listBoxAutoComplete);
            this.txtBm.SetPoint();
            this.txtBm.SetSql(" select bm_name name,bm_code id,bm_name||'  '||bm_code as ni from t_bm where lower(py) like '{0}%' UNION all select bm_name name,bm_code id,bm_name||'  '||bm_code as ni from t_bm where lower(wb) like '{0}%' UNION all select bm_name name,bm_code id,bm_name||'  '||bm_code as ni from t_bm where bm_name like '%{0}%'");
            this.txtBm.OnReturnId = ReturnId2;
            this.tcpChinese.Controls.Add(this.txtZh.listBoxAutoComplete);
            this.txtZh.SetSql(" select zh_name name,zh_code id,zh_name||'  '||zh_code as ni from t_zh where lower(py) like '{0}%' UNION all select zh_name name,zh_code id,zh_name||'  '||zh_code as ni from t_zh where lower(wb) like '{0}%' UNION all select zh_name name,zh_code id,zh_name||'  '||zh_code as ni from t_zh where zh_name like '%{0}%'");
            this.txtZh.SetPoint();
            this.txtZh.OnReturnId = ReturnId3;
            RefreshDiagnose(atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
            RefreshDiagnose(atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
            cbiSelectAll_Click(null, null);

            //if (!CanWriter())
            //{
            //    ribbonBar1.Enabled = false;
            //    panel1.Enabled = false;
            //    cmsChineseDiagnose.Enabled = false;
            //    cmsDiagnose.Enabled = false;
            //    panel3.Enabled = false;
            //    ribbonBar2.Enabled = false;
            //}

            ucDiagnoseOften usDO = new ucDiagnoseOften(_patient);
            usDO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Controls.Add(usDO);
        }

        string action = string.Empty;
        string caction = string.Empty;

        /// <summary>
        /// 验证是否在三级范围内
        /// </summary>
        /// <returns></returns>
        bool CanWriter()
        {
            //①编辑：除患者三级医师本人，各级大夫的附属账号也应能够编辑诊断；
            string currentUserId = App.UserAccount.UserInfo.User_id;
            if (currentUserId == patient.Resident_Doctor_Id.ToString()
                || currentUserId == patient.Charge_Doctor_Id.ToString()
                || currentUserId == patient.Chief_Doctor_Id.ToString())
            {
                return true;
            }

            if (!string.IsNullOrEmpty(App.UserAccount.UserInfo.Guid_doctor_id)
                && (App.UserAccount.UserInfo.Guid_doctor_id == patient.Resident_Doctor_Id.ToString()
                    || App.UserAccount.UserInfo.Guid_doctor_id == patient.Charge_Doctor_Id.ToString()
                    || App.UserAccount.UserInfo.Guid_doctor_id == patient.Chief_Doctor_Id.ToString()))
            {
                return true;
            }
            return false;
        }

        public void RefreshDiagnose(AdvTree diagnoseTree, string isChinese, string diagnose_Type)
        {
            diagnoseTree.Nodes.Clear();
            //string sqlMainDiagnose = string.Format("select id,diagnose_code,diagnose_type,to_char(fix_time,'yyyy-mm-dd hh24:mi') fix_time,diagnose_name, diagnose_icd10,diagnose_sort,SYMPTOMS_NAME,SYMPTOMS_CODE,fssx_id, yjsx_id, ejsx_id, sjsx_id, fssx_name, yjsx_name, ejsx_name, sjsx_name from t_diagnose_item where diagnose_type = '{2}' and patient_id = '{0}' and is_chinese = '{1}' order by diagnose_sort", this.patient.Id.ToString(), isChinese, diagnose_Type);
            string sqlMainDiagnose
                = string.Format("select id,diagnose_code,diagnose_type,to_char(fix_time,'yyyy-mm-dd') fix_time,diagnose_name, diagnose_icd10,diagnose_sort,SYMPTOMS_NAME,SYMPTOMS_CODE,fssx_id, yjsx_id, ejsx_id, sjsx_id, fssx_name, yjsx_name, ejsx_name, sjsx_name ,tu.guid_doctor_id " +
                                "from t_diagnose_item t left join t_userinfo tu on t.fssx_id=tu.user_id " +
                                "where diagnose_type = '{2}' " +
                                "and patient_id = '{0}' " +
                                "and is_chinese = '{1}' " +
                                "order by fix_time,diagnose_sort", this.patient.Id.ToString(), isChinese, diagnose_Type);
            //string sqlMainDiagnose
            //   = string.Format("select id,diagnose_code,diagnose_type,to_char(fix_time,'yyyy-mm-dd') fix_time,diagnose_name, diagnose_icd10,diagnose_sort,SYMPTOMS_NAME,SYMPTOMS_CODE " +
            //                   "from t_diagnose_item t left join t_userinfo tu on t.fssx_id=tu.user_id " +
            //                   "where diagnose_type = '{2}' " +
            //                   "and patient_id = '{0}' " +
            //                   "and is_chinese = '{1}' " +
            //                   "order by fix_time,diagnose_sort", this.patient.Id.ToString(), isChinese, diagnose_Type);
            
            DataTable mainDt = App.GetDataSet(sqlMainDiagnose).Tables[0];
            if (mainDt != null && mainDt.Rows.Count > 0)
            {
                foreach (DataRow mainRow in mainDt.Rows)
                {
                    Node parentNode = new Node();
                    parentNode.Name = mainRow["id"].ToString();
                    parentNode.Text = mainRow["diagnose_name"].ToString();
                    parentNode.Tag = mainRow;
                    parentNode.CheckBoxVisible = true;

                    if (isChinese == "Y")
                    {
                        parentNode.Cells.Add(new Cell(mainRow["SYMPTOMS_NAME"].ToString()));
                    }
                    parentNode.Cells.Add(new Cell(mainRow["diagnose_code"].ToString()));

                    Cell cellDiagnoseType = new Cell();
                    string diagnoseTypeId = mainRow["diagnose_type"].ToString();
                    if (!string.IsNullOrEmpty(diagnoseTypeId))
                    {
                        DataRow[] rows = (this.comboBox1.DataSource as DataTable).Select(string.Format("id = {0}", diagnoseTypeId));
                        if (rows != null && rows.Length > 0)
                        {
                            cellDiagnoseType.Text = rows[0][1].ToString();
                        }
                    }
                    parentNode.Cells.Add(cellDiagnoseType);

                    parentNode.Cells.Add(new Cell(mainRow["fix_time"].ToString()));
                    Cell fcell = new Cell(mainRow["fssx_name"].ToString());
                    fcell.Name = mainRow["fssx_id"].ToString();
                    parentNode.Cells.Add(fcell);

                    Cell ycell = new Cell(mainRow["yjsx_name"].ToString());
                    ycell.Name = mainRow["yjsx_id"].ToString();
                    parentNode.Cells.Add(ycell);

                    Cell ecell = new Cell(mainRow["ejsx_name"].ToString());
                    ecell.Name = mainRow["ejsx_id"].ToString();
                    parentNode.Cells.Add(ecell);

                    Cell scell = new Cell(mainRow["sjsx_name"].ToString());
                    scell.Name = mainRow["sjsx_id"].ToString();
                    parentNode.Cells.Add(scell);

                    string sqlTrendDiagnose = string.Format("select id, trend_diagnose_name, diagnose_icd10, diagnose_code, sort_sequence, parent_id from t_trend_diagnose where diagnoseitem_id = '{0}' order by sort_sequence", parentNode.Name);
                    DataTable trendDt = App.GetDataSet(sqlTrendDiagnose).Tables[0];
                    if (trendDt != null && trendDt.Rows.Count > 0)
                        AddTrendDiagnose(parentNode, parentNode.Name, trendDt, parentNode.Name, isChinese);
                    diagnoseTree.Nodes.Add(parentNode);
                }
            }
            diagnoseTree.ExpandAll();
        }

        public void ReturnId(string icd)
        {
            if (icd == "add")
            {
                btnAdd_Click(null, null);
            }
            else
            {
                this.lblIcd10Encode.Text = icd;
            }
        }

        public void ReturnId2(string icd)
        {
            if (icd == "add")
            {
                if (this.txtZh.Enabled == false)
                {
                    btnChineseAdd_Click(null, null);
                }
                else
                {
                    this.txtZh.Focus();
                }
            }
            else
            {
                this.lbChineseBmIcd.Text = icd;
            }
        }

        public void ReturnId3(string icd)
        {
            if (icd == "add")
            {
                btnChineseAdd_Click(null, null);
            }
            else
            {
                this.lbChineseZhIcd.Text = icd;
            }
        }

        static void AddTrendDiagnose(Node parentNode, string parentId, DataTable trendDt, string parentName, string icChinese)
        {
            DataRow[] dr = trendDt.Select(string.Format("parent_id = '{0}'", parentId));
            if (dr != null && dr.Length > 0)
            {
                foreach (DataRow trendRow in dr)
                {
                    Node childNode = new Node();
                    //childNode.CheckBoxVisible = true;
                    childNode.Name = trendRow["id"].ToString();
                    childNode.Text = trendRow["trend_diagnose_name"].ToString();
                    if (icChinese != "Y")
                        childNode.Cells.Add(new Cell(trendRow["diagnose_icd10"].ToString()));
                    childNode.Tag = trendRow;
                    if (childNode.Name != parentId && childNode.Name != parentName)
                        AddTrendDiagnose(childNode, childNode.Name, trendDt, parentName, icChinese);
                    parentNode.Nodes.Add(childNode);
                }
            }
        }

        private void biUp_Click(object sender, EventArgs e)
        {
            ChangedNodeMoveUp(atDiagnoseList);
            if (atDiagnoseList.SelectedNode != null && atDiagnoseList.SelectedNode.Parent == null)
            {
                RefreshDiagnose(atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
            }

        }

        static bool ChangedNodeMoveUp(AdvTree tree)
        {
            Node selectNode = tree.SelectedNode;
            if (selectNode != null)
            {
                if (selectNode.Parent == null)
                {
                    if (selectNode.Index > 0)
                    {
                        Node newNode = selectNode.PrevNode;
                        if (((DataRow)newNode.Tag)["fix_time"].ToString() == ((DataRow)selectNode.Tag)["fix_time"].ToString())
                        {
                            InterChangerParentId(newNode, selectNode);
                            return false;
                        }
                        else
                        {
                            App.Msg("相同诊断时间的才能上移下移！");
                            return true;
                        }
                    }
                }
                else
                {
                    if (selectNode != null && selectNode.Index > 0)
                    {
                        Node PrentNode = GetParentNode(selectNode);
                        Node preNode = selectNode.PrevNode;
                        Node newNode = selectNode.Copy();
                        CopyToNode(selectNode, newNode);
                        if (selectNode.Parent == null)
                        {
                            InterChangerParentId(newNode, preNode);

                        }
                        else
                        {
                            preNode.Parent.Nodes.Insert(preNode.Index, newNode);
                            preNode.Parent.Nodes.Remove(selectNode);
                            tree.SelectedNode = newNode;
                            InterchangeNodeId(newNode, preNode);
                        }
                    }
                }
            }
            return true;
        }

        static bool ChangedNodeMoveDown(AdvTree tree)
        {
            Node selectNode = tree.SelectedNode;

            if (selectNode != null)
            {
                if (selectNode.Parent == null)
                {
                    if (selectNode.NextNode != null)
                    {
                        Node newNode = selectNode.NextNode;
                        if (((DataRow)newNode.Tag)["fix_time"].ToString() == ((DataRow)selectNode.Tag)["fix_time"].ToString())
                        {
                            InterChangerParentId(newNode, selectNode);
                            return true;
                        }
                        else
                        {
                            App.Msg("相同诊断时间的才能上移下移！");
                            return false;
                        }
                    }
                }
                else
                {
                    if (selectNode != null && selectNode.NextNode != null)
                    {
                        Node PrentNode = GetParentNode(selectNode);
                        Node nextNode = selectNode.NextNode;
                        Node newNode = selectNode.Copy();
                        CopyToNode(selectNode, newNode);
                        if (selectNode.Parent == null)
                        {
                            tree.Nodes.Insert(nextNode.Index + 1, newNode);
                            tree.Nodes.Remove(selectNode);
                            tree.SelectedNode = newNode;
                            InterChangerParentId(nextNode, newNode);
                        }
                        else
                        {
                            nextNode.Parent.Nodes.Insert(nextNode.Index + 1, newNode);
                            nextNode.Parent.Nodes.Remove(selectNode);
                            tree.SelectedNode = newNode;
                            InterchangeNodeId(nextNode, newNode);
                        }
                    }
                }
            }
            return true;

        }

        /// <summary>
        /// 交换排序ID
        /// </summary>
        /// <param name="_node1"></param>
        /// <param name="_node2"></param>
        /// <returns></returns>
        static int InterchangeNodeId(Node _node1, Node _node2)
        {
            string sql1 = string.Format("UPDATE t_trend_diagnose T set T.sort_sequence ='{1}' WHERE T.ID = '{0}'", _node1.Name, ((DataRow)_node2.Tag)["sort_sequence"].ToString());
            string sql2 = string.Format("UPDATE t_trend_diagnose Y set Y.sort_sequence ='{1}' WHERE Y.ID = '{0}'", _node2.Name, ((DataRow)_node1.Tag)["sort_sequence"].ToString());
            return App.ExecuteBatch(new string[] { sql1, sql2 });
        }

        static int InterChangerParentId(Node _node1, Node _node2)
        {
            string sql1 = string.Format("UPDATE t_diagnose_item T set T.diagnose_sort ='{1}' WHERE T.ID = '{0}'", _node1.Name, ((DataRow)_node2.Tag)["diagnose_sort"].ToString());
            string sql2 = string.Format("UPDATE t_diagnose_item Y set Y.diagnose_sort ='{1}' WHERE Y.ID = '{0}'", _node2.Name, ((DataRow)_node1.Tag)["diagnose_sort"].ToString());
            return App.ExecuteBatch(new string[] { sql1, sql2 });
        }

        /// <summary>
        /// 获取顶级节点
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        static Node GetParentNode(Node _node)
        {
            Node node = _node;
            while (node.Parent != null)
            {
                node = node.Parent;
            }
            return node;
        }

        /// <summary>
        /// 复制到新节点
        /// </summary>
        /// <param name="oldNode"></param>
        /// <param name="newNode"></param>
        /// <returns></returns>
        static void CopyToNode(Node oldNode, Node newNode)
        {
            foreach (Node childNode in oldNode.Nodes)
            {
                Node newChildNode = childNode.Copy();
                newNode.Nodes.Add(newChildNode);
                CopyToNode(childNode, newChildNode);
            }
        }

        private void biDown_Click(object sender, EventArgs e)
        {
            ChangedNodeMoveDown(atDiagnoseList);
            if (atDiagnoseList.SelectedNode != null && atDiagnoseList.SelectedNode.Parent == null)
            {
                RefreshDiagnose(atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            string diagnoseName = this.txtDiagnose.Text.Trim().Replace("'", "''");
            string timeStr = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss");
            if (string.IsNullOrEmpty(diagnoseName))
            {
                App.Msg("[诊断名称]未填写完整！");
                return;
            }

            if (this.action == "trend")
            {
                Node selectNode = this.atDiagnoseList.SelectedNode;
                if (selectNode != null)
                {
                    Node parentNode = GetParentNode(selectNode);

                    int num = parentNode.Nodes.Count;
                    t_simple_trend_diagnose tstd = new t_simple_trend_diagnose(parentNode.Name, diagnoseName, this.lblIcd10Encode.Text, this.lblIcd10Encode.Text, num + 1, selectNode.Name);
                    if (tstd.Insert())
                    {
                        App.Msg("附属诊断添加成功！");
                        上级审签(selectNode, this.atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
                    }
                }
            }
            else if (this.action == "update")
            {
                Node selectNode = this.atDiagnoseList.SelectedNode;
                if (selectNode != null)
                {
                    if (selectNode.Parent == null)
                    {
                        int num = this.atDiagnoseList.Nodes.Count;
                        t_simple_diagnose tsd = new t_simple_diagnose(this.lblIcd10Encode.Text, "", diagnoseName, this.lblIcd10Encode.Text, 0, "0", this, this.comboBox1.SelectedValue.ToString(), this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"));
                        t_simple_diagnose tsd1 = new t_simple_diagnose(this.lblIcd10Encode.Text, timeStr, diagnoseName, this.lblIcd10Encode.Text, num + 1, this.patient.Id.ToString(), this, this.comboBox1.SelectedValue.ToString(), this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"));

                        if (flage)
                        {
                            string sqldelete = string.Format("delete necp.t_patient_diagnose where patient_id = '{0}'", patient.Id);
                            int x = App.ExecuteSQL(sqldelete);
                            DataInit.MatchPath(int.Parse(tsd1.Patient_id), tsd1.Diagnose_code, diagnoseName, tsd1.DiagnoseType);
                            flage = false;
                        }
                        if (tsd.Update(selectNode.Name))
                        {
                            
                            App.Msg("诊断修改成功！");
                            
                            上级审签(selectNode, this.atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
                        }
                      

                    }
                    else
                    {
                        int num = this.atDiagnoseList.Nodes.Count;
                        t_simple_diagnose tsd1 = new t_simple_diagnose(this.lblIcd10Encode.Text, timeStr, diagnoseName, this.lblIcd10Encode.Text, num + 1, this.patient.Id.ToString(), this, this.comboBox1.SelectedValue.ToString(), this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"));
                        t_simple_trend_diagnose tstd = new t_simple_trend_diagnose("", diagnoseName, this.lblIcd10Encode.Text, this.lblIcd10Encode.Text, 0, "");
                        if (flage)
                        {
                            string sqldelete = string.Format("delete necp.t_patient_diagnose where patient_id = '{0}'", patient.Id);
                            int x = App.ExecuteSQL(sqldelete);
                           DataInit.MatchPath(int.Parse(tsd1.Patient_id), tsd1.Diagnose_code, diagnoseName, tsd1.DiagnoseType);
                            flage = false;
                        }
                        if (tstd.Update(selectNode.Name))
                        {
                            App.Msg("附属诊断修改成功！");
                            上级审签(selectNode, this.atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
                        }
                    }
                }

            }
            else
            {
                int num = this.atDiagnoseList.Nodes.Count;
                t_simple_diagnose tsd = new t_simple_diagnose(this.lblIcd10Encode.Text, timeStr, diagnoseName, this.lblIcd10Encode.Text, num + 1, this.patient.Id.ToString(), this, this.comboBox1.SelectedValue.ToString(), this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"));
                if (tsd.Insert())
                {
                    App.Msg("诊断添加成功！");
                    if (num==0 && tsd.DiagnoseType=="403") {
                        DataInit.MatchPath(int.Parse(tsd.Patient_id), tsd.Diagnose_code, diagnoseName, tsd.DiagnoseType);
                    }
                }
            }
            
            this.action = string.Empty;
            this.atDiagnoseList.Enabled = true;
            this.clearDiagnose();
            RefreshDiagnose(atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
        }

        private void 添加附属诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atDiagnoseList.SelectedNode;
            if (selectNode != null)
            {
                if (IsEditDiag(selectNode))
                {
                    this.action = "trend";
                    this.atDiagnoseList.Enabled = false;
                    clearDiagnose();
                }
                else
                {
                    App.Msg("提示:权限不够,不能添加！");
                }
            }
            else
            {
                App.Msg("请选中要添加附属诊断的节点！");
            }
        }

        void clearDiagnose()
        {
            this.lblIcd10Encode.Text = "";
            this.txtDiagnose.Text = "";
        }

        void clearChineseDiagnose()
        {
            this.lbChineseBmIcd.Text = "";
            this.lbChineseZhIcd.Text = "";
            this.txtBm.Text = "";
            this.txtZh.Text = "";
            this.txtZh.Enabled = true;
        }

        private void atDiagnoseList_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            Node selectNode = (sender as AdvTree).SelectedNode;
            if (selectNode != null)
            {
                selectNode.Checked = !selectNode.Checked;
            }
        }

        static void ChildCheck(Node node, bool b)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (Node childNode in node.Nodes)
                {
                    childNode.Checked = b;
                    ChildCheck(childNode, b);
                }
            }
        }

        private void atDiagnoseList_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (changed)
                return;
            Node selectNode = this.atDiagnoseList.SelectedNode;
            if (selectNode != null)
            {
                ChildCheck(selectNode, selectNode.Checked);
            }
        }

        private void atDiagnoseList_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            Node findNode = this.atDiagnoseList.GetNodeAt(e.Y);
            if (findNode != null)
            {
                //this.atDiagnoseList.SelectedNode = findNode;
            }
        }

        private int getSXLevel(Node node, ref string fssx_id, ref string Guid_doctor_id)
        {
            try
            {
                int SXlevel = 0;
                if (node.Parent == null)
                {
                    DataRow mrow = node.Tag as DataRow;
                    string sjsx = mrow["sjsx_id"].ToString();  //三级书写
                    string ejsx = mrow["ejsx_id"].ToString();  //二级书写
                    string yjsx = mrow["yjsx_id"].ToString();  //一级书写
                    string fssx = mrow["fssx_id"].ToString();  //附属书写
                    if (!string.IsNullOrEmpty(sjsx))
                    {
                        SXlevel = 3;
                    }
                    else if (!string.IsNullOrEmpty(ejsx))
                    {
                        SXlevel = 2;
                    }
                    else if (!string.IsNullOrEmpty(yjsx))
                    {
                        SXlevel = 1;
                    }
                    else if (!string.IsNullOrEmpty(fssx))
                    {
                        SXlevel = 0;
                        fssx_id = mrow["fssx_id"].ToString();
                        Guid_doctor_id = mrow["guid_doctor_id"].ToString();
                    }
                }
                else
                {
                    SXlevel=getSXLevel(node.Parent,ref fssx_id ,ref Guid_doctor_id);
                }
                return SXlevel;
            }
            catch (System.Exception ex)
            {
                return 0;
            }
        }

        private void 删除诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Node selectNode = this.atDiagnoseList.SelectedNode;
            int index = this.atDiagnoseList.SelectedIndex;
            int num = this.atDiagnoseList.Nodes.Count;
            string diagnoseName = this.txtDiagnose.Text.Trim().Replace("'", "''");
          
            string timeStr = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss");
            if (index > 0 )
            {
                if (selectNode == null)
                {
                    App.Msg("请选中要删除诊断的节点！");
                    return;
                }
                if (IsEditDiag(selectNode))
                {
                    if (MessageBox.Show("确定要删除该诊断吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                        return;
                    if (selectNode.Parent == null)
                    {
                       
                        t_simple_diagnose.Delete(selectNode.Name, patient.Id.ToString(), this.comboBox1.SelectedValue.ToString(), "N");
                        t_simple_trend_diagnose.Delete(selectNode.Name, 1, "");
                    }
                    else
                    {
                        t_simple_trend_diagnose.Delete(selectNode.Name, 0, selectNode.Parent.Name);
                    }
                    this.action = string.Empty;
                    this.atDiagnoseList.Enabled = true;
                    this.clearDiagnose();
                    RefreshDiagnose(atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
                }
                else
                {
                    App.Msg("提示:权限不够,不能删除！！");
                }
            }
            else
            {
                string sql = "select *  from necp.t_patient_path a where a.patient_id='" + patient.Id + "' ";
                DataTable sqlDt = App.GetDataSet(sql).Tables[0];
                if (sqlDt.Rows.Count > 0)
                {
                    App.Msg("已录入临床路径不可删除！");
                }
                else {
                    if (selectNode == null)
                    {
                        App.Msg("请选中要删除诊断的节点！");
                        return;
                    }
                    if (IsEditDiag(selectNode))
                    {
                        if (MessageBox.Show("确定要删除该诊断吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                            return;
                        if (selectNode.Parent == null)
                        {
                            string sb="";
                            t_simple_diagnose.Delete(selectNode.Name, patient.Id.ToString(), this.comboBox1.SelectedValue.ToString(), "N");
                            t_simple_trend_diagnose.Delete(selectNode.Name, 1, "");
                            string sqldelete = string.Format("delete necp.t_patient_diagnose where patient_id = '{0}'", patient.Id);
                            int m = App.ExecuteSQL(sqldelete);
                            if (m == 0 && index + 1 < num)
                            {  
                                if (x == 0)
                                {
                                    sb = this.atDiagnoseList.Nodes[1].ToString();
                                    string[] sArray = sb.Split(',');
                                    DataInit.MatchPath(patient.Id, sArray[1].Trim(), sArray[0].Trim(), "403");
                                }
                            }
                        }
                        else
                        {
                            t_simple_trend_diagnose.Delete(selectNode.Name, 0, selectNode.Parent.Name);
                        }
                        this.action = string.Empty;
                        this.atDiagnoseList.Enabled = true;
                        this.clearDiagnose();
                        RefreshDiagnose(atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
                    }
                    else
                    {
                        App.Msg("提示:权限不够,不能删除！！");
                    }
                }
            }
        }

        /// <summary>
        /// 普通书写的诊断，除自己修改外，三级逐级修改；附属账号书写的诊断除本人修改外（带教审签前），带教医师可修改，不可跨级由上级修改，带教审签后，三级逐级修改；
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改诊断ToolStripMenuItem_Click(object sender, EventArgs e)
     {
           
            Node selectNode = this.atDiagnoseList.SelectedNode;
            int index = this.atDiagnoseList.SelectedIndex;
            if (index > 0)
        {
            
                if (selectNode != null)
            {
                if (IsEditDiag(selectNode))
                {
                    this.action = "update";
                    this.atDiagnoseList.Enabled = false;
                    this.txtDiagnose.Text = selectNode.Text;
                    this.lblIcd10Encode.Text = ((DataRow)selectNode.Tag)["diagnose_code"].ToString();
                    if (selectNode.Parent == null)
                    {
                        string timeText = ((DataRow)selectNode.Tag)["fix_time"].ToString();
                        this.dateTimePicker1.Value = string.IsNullOrEmpty(timeText) ? App.GetSystemTime() : Convert.ToDateTime(timeText);
                    }
                }
                else
                {
                    App.Msg("提示:权限不够,不能修改！");
                }
            }
            else
            {
                App.Msg("请选中要修改的诊断节点！");
            }
        }
            else
            {
                string sb = this.atDiagnoseList.Nodes[0].ToString();
                string[] sArray = sb.Split(',');
                string sql = "select *  from necp.t_patient_path a where a.patient_id='"+patient.Id+"' and IN_CODE='"+ sArray [1].Trim() + "' ";
                DataTable sqlDt = App.GetDataSet(sql).Tables[0];
                if (sqlDt.Rows.Count>0)
                {
                    App.Msg("已录入临床路径不可修改！");
                }
                else
                {

                    if (selectNode != null)
                    {
                        if (IsEditDiag(selectNode))
                        {
                            this.action = "update";
                            flage=true;
                            this.atDiagnoseList.Enabled = false;
                            this.txtDiagnose.Text = selectNode.Text;
                            this.lblIcd10Encode.Text = ((DataRow)selectNode.Tag)["diagnose_code"].ToString();
                            if (selectNode.Parent == null)
                            {
                                string timeText = ((DataRow)selectNode.Tag)["fix_time"].ToString();
                                this.dateTimePicker1.Value = string.IsNullOrEmpty(timeText) ? App.GetSystemTime() : Convert.ToDateTime(timeText);
                            }
                        }
                        else
                        {
                            App.Msg("提示:权限不够,不能修改！");
                        }
                    }
                    else
                    {
                        App.Msg("请选中要修改的诊断节点！");
                    }

                }

            }
    }


        private bool IsEditDiag(Node selectNode)
        {
            /*
             ②修改：普通书写的诊断，除自己修改外，三级逐级修改；附属账号书写的诊断除本人修改外（带教审签前），带教医师可修改，不可跨级由上级修改，带教审签后，三级逐级修改；
             ③删除：普通书写的诊断，最后一级或者上级可删除；附属账号书写的诊断除本人删除外（带教审签前），带教可删除，上级不可跨级删除；带教审签后，上级可删除
             */
            string currentId = App.UserAccount.UserInfo.User_id;
            //附属书写id
            string fssx_id = "";
            string Guid_doctor_id = "";
            int SXlevel =1; //getSXLevel(selectNode, ref fssx_id, ref Guid_doctor_id);//审签到几级
            int level = 3; //DataInit.GetThreeLevel(patient, currentId);//当前用户等级

            bool bl = false;
            if ((level > SXlevel && SXlevel != 0) ||
                (SXlevel == 3 && currentId == patient.Chief_Doctor_Id.ToString()) ||
                (SXlevel == 2 && currentId == patient.Charge_Doctor_Id.ToString()) ||
                (SXlevel == 1 && currentId == patient.Resident_Doctor_Id.ToString()) ||
                (SXlevel == 0 && currentId == fssx_id)||
                (SXlevel == 0 && currentId == Guid_doctor_id && level > SXlevel))
            {
                bl = true;
            }
            return bl;
        }


        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.action = string.Empty;
            this.atDiagnoseList.Enabled = true;
            this.clearDiagnose();
        }
        bool changed = false;
        private void cbiSelectAll_Click(object sender, EventArgs e)
        {
            changed = true;
            if (this.atDiagnoseList.Nodes.Count > 0)
            {
                foreach (Node node in this.atDiagnoseList.Nodes)
                {
                    //ChildCheck(node, node.Checked);
                    node.Checked = this.checkBoxItem2.Checked;
                }
            }
            changed = false;
        }

        bool isCheckedMore(Node tvNode)
        {
            if (tvNode.Nodes.Count > 0)
            {
                int count1 = 0;
                foreach (Node node in tvNode.Nodes)
                {
                    if (node.Checked)
                    {
                        count1++;
                    }
                    if (count1 > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool isCheckedMore(AdvTree tvNode)
        {
            if (tvNode.Nodes.Count > 0)
            {
                int count1 = 0;
                foreach (Node node in tvNode.Nodes)
                {
                    if (node.Checked)
                    {
                        count1++;
                    }
                    if (count1 > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //private void buttonX2_Click(object sender, EventArgs e)
        //{
        //    if (this.cbDiagnoseBox.SelectedIndex == 0)
        //    {
        //        App.Msg("请选择要插入的诊断类别！");
        //        return;
        //    }
        //    List<Diagnose_item> diagnoseStr = new List<Diagnose_item>();
        //    string selectType = this.cbDiagnoseBox.Text;
        //    StringBuilder DiagnoseIdbuilder = new StringBuilder("diagnoseid_");
        //    List<string> sqlList = new List<string>();
        //    bool b = this.document.IshaveDiagnoseDiv(selectType);
        //    string createTime = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss");
        //    if (b)
        //    {
        //        string diagnoseType = TextDocument.frmWindow.frmDiagnoseModify.diagnoseTypeNO(selectType);
        //        if (!document.SqlDiagnoseList.ContainsKey(diagnoseType))
        //        {
        //            document.SqlDiagnoseList.Add(diagnoseType, sqlList);
        //        }
        //        else
        //        {
        //            document.SqlDiagnoseList[diagnoseType] = sqlList;
        //        }

        //        sqlList.Add("delete t_trend_diagnose where diagnoseitem_id in(select id from t_diagnose_item where doc_id = '{0}' and diagnose_type ='" + diagnoseType + "')");
        //        sqlList.Add("delete t_diagnose_item where doc_id = '{0}' and diagnose_type ='" + diagnoseType + "'");
        //    }

        //    bool haveChinese = false;
        //    int count2 = 1;
        //    bool haveMore = isCheckedMore(this.atChineseDiagnose);
        //    bool haveMore2 = isCheckedMore(this.atDiagnoseList);
        //    foreach (Node diagnoseNode in this.atChineseDiagnose.Nodes)
        //    {
        //        if (diagnoseNode.Checked)
        //        {
        //            haveChinese = true;
        //            if (diagnoseStr.Count > 0)
        //            {
        //                DiagnoseIdbuilder.Append("|");
        //            }
        //            Diagnose_item item = new Diagnose_item();

        //            if (count2 == 1)
        //            {
        //                item.DiagnoseName = "中医诊断:" + (haveMore ? count2.ToString() + "." : "") + diagnoseNode.Text;
        //                item.ZyStart = true;
        //            }
        //            else
        //            {
        //                item.DiagnoseName = count2.ToString() + "." + diagnoseNode.Text;
        //            }
        //            item.Lever = diagnoseNode.Level;
        //            item.Index = count2;
        //            diagnoseStr.Add(item);
        //            Diagnose_item item2 = new Diagnose_item();
        //            item2.DiagnoseName = diagnoseNode.Cells[1].Text.Trim();
        //            item2.Lever = diagnoseNode.Level + 1;
        //            item2.Index = 0;
        //            if (!string.IsNullOrEmpty(item2.DiagnoseName))
        //                diagnoseStr.Add(item2);
        //            GetSelectListString(diagnoseNode, diagnoseStr, true);
        //            DiagnoseIdbuilder.Append(diagnoseNode.Name);
        //            if (b)
        //            {
        //                GetSql(diagnoseNode.Name, selectType, sqlList, createTime, diagnoseNode);
        //            }
        //            count2++;
        //        }
        //    }

        //    int count = 1;
        //    foreach (Node diagnoseNode in this.atDiagnoseList.Nodes)
        //    {
        //        if (diagnoseNode.Checked)
        //        {
        //            if (diagnoseStr.Count > 0)
        //            {
        //                DiagnoseIdbuilder.Append("|");
        //            }
        //            Diagnose_item item = new Diagnose_item();
        //            if (haveChinese && count == 1)
        //            {
        //                item.DiagnoseName = "西医诊断:" + (haveMore2 ? count.ToString() + "." : "") + diagnoseNode.Text;
        //                item.ZyStart = true;
        //            }
        //            else
        //            {
        //                item.DiagnoseName = (haveMore2 ? count.ToString() + "." : "") + diagnoseNode.Text;
        //            }
        //            item.Lever = diagnoseNode.Level;
        //            item.Index = count;
        //            diagnoseStr.Add(item);
        //            GetSelectListString(diagnoseNode, diagnoseStr, false);
        //            DiagnoseIdbuilder.Append(diagnoseNode.Name);
        //            if (b)
        //            {
        //                GetSql(diagnoseNode.Name, selectType, sqlList, createTime, diagnoseNode);
        //            }
        //            count++;
        //        }
        //    }


        //    this.document.RefreshDiagnose(this.cbDiagnoseBox.Text, diagnoseStr, DiagnoseIdbuilder.ToString());
        //    this.Close();
        //}

        //private void GetSelectListString(Node _diagnoseNode, List<Diagnose_item> diagnoseStrs, bool isChinese)
        //{
        //    int index = 0;
        //    bool haveMore = isCheckedMore(_diagnoseNode);
        //    foreach (Node _childNode in _diagnoseNode.Nodes)
        //    {
        //        if (_childNode.Checked)
        //        {
        //            Diagnose_item item = new Diagnose_item();
        //            //if (_childNode.Level == 1)
        //            //{
        //            item.DiagnoseName = (haveMore ? (index + 1).ToString() + "）" : "") + _childNode.Text;
        //            //}
        //            //else
        //            //{
        //            //    item.DiagnoseName = _childNode.Text;
        //            //}
        //            item.Lever = _childNode.Level;
        //            item.Index = _childNode.Index + 1;
        //            diagnoseStrs.Add(item);
        //            GetSelectListString(_childNode, diagnoseStrs, isChinese);
        //            index++;
        //        }
        //    }
        //}

        /// <summary>
        /// 复制诊断
        /// </summary>
        /// <param name="diagnoseid"></param>
        /// <param name="type"></param>
        /// <param name="sqlList"></param>
        /// <param name="create_time"></param>
        private void GetSql(string type, string create_time, Node treeNode, List<string> sqlList, int countAdd, string is_chinese, string sxqm)
        {
            string id = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString();
            string max = App.GetDataSet(string.Format("select max(diagnose_sort)+{2} from t_diagnose_item where patient_id = '{0}' and diagnose_type = '{1}' and is_chinese = '{3}'", this.patient.Id.ToString(), type, countAdd + 1, is_chinese)).Tables[0].Rows[0][0].ToString();
            
            if (string.IsNullOrEmpty(max))
            {
                max = countAdd.ToString();
            }
            //id,diagnose_type,diagnose_code,create_id,create_time,fix_time,diagnose_name, diagnose_icd10,diagnose_sort,patient_id,is_chinese,symptoms_name,symptoms_code
            string sql = string.Format("INSERT INTO t_diagnose_item(    "   //新增诊断条目
                                    + " id,                     "
                                    + " diagnose_code,          "
                                    + " create_time,            "
                                    + " fix_time,               "
                                    + " create_id,              "
                                    + " diagnose_name,          "
                                    + " diagnose_icd10,         "
                                    + " is_chinese,         "
                                    + " patient_id,             "
                                    + " diagnose_sort,          "
                                    + " diagnose_type,          "
                                    + " SYMPTOMS_NAME,          "
                                    + " SYMPTOMS_CODE        {0} ) "
                                    + "SELECT "
                                    + "'{1}',"
                                    + "diagnose_code,"
                                    + "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi:ss'),"
                                    + "to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi:ss'),"
                                    + "'{3}',"
                                    + "diagnose_name,"
                                    + "diagnose_icd10,"
                                    + "is_chinese,"
                                    + "patient_id,"
                                    + "'{4}',"
                                    + "'{5}',"
                                    + "SYMPTOMS_NAME,"
                                    + "SYMPTOMS_CODE ,"
                                    + "'{6}',"
                                    + "'{7}'"
                                    + " FROM t_diagnose_item "
                                    + " WHERE ID = '{8}'",
                                    sxqm,
                                    id,
                                    create_time,
                                    App.UserAccount.UserInfo.User_id,
                                    max,
                                    type,
                                    App.UserAccount.UserInfo.User_id,
                                    App.UserAccount.UserInfo.User_name,
                                    treeNode.Name
                                   );
            sqlList.Add(sql);
            SetCopyDiagnose(sqlList, treeNode, id, id);
        }

        private void SetCopyDiagnose(List<string> sqlList, Node _node, string id, string parentId)
        {
            foreach (Node childNode in _node.Nodes)
            {
                DataRow row = childNode.Tag as DataRow;
                string newid = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString(); //诊断条目ID
                string sql = string.Format(" INSERT INTO t_trend_diagnose (ID,DIAGNOSEITEM_ID,TREND_DIAGNOSE_NAME,DIAGNOSE_ICD10,DIAGNOSE_CODE,SORT_SEQUENCE,PARENT_ID) "
                           + " VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", newid, id, childNode.Text.Replace("'", "''"), row["DIAGNOSE_ICD10"].ToString(), row["DIAGNOSE_ICD10"].ToString(), childNode.Index, parentId);
                if (childNode.Nodes.Count > 0)
                {
                    SetCopyDiagnose(sqlList, childNode, id, newid);
                }
                sqlList.Add(sql);
            }
        }

        //private void buttonX3_Click(object sender, EventArgs e)
        //{
        //    frmDiagnoseModify fr = new frmDiagnoseModify(document);
        //    fr.ShowDialog();
        //}

        private void atDiagnoseList_DoubleClick(object sender, EventArgs e)
        {
            atDiagnoseList_NodeDoubleClick(sender, null);
        }

        private void btnChineseClear_Click(object sender, EventArgs e)
        {
            this.caction = string.Empty;
            this.atChineseDiagnose.Enabled = true;
            this.clearChineseDiagnose();
        }

        private void btnChineseAdd_Click(object sender, EventArgs e)
        {
            string diagnoseBm = this.txtBm.Text.Trim();
            string diagnoseZh = this.txtZh.Text.Trim();
            if (string.IsNullOrEmpty(diagnoseBm))
            {
                App.Msg("[病名]未填写完整！");
                return;
            }

            string timeStr = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss");
            if (this.caction == "trend")
            {
                Node selectNode = this.atChineseDiagnose.SelectedNode;
                if (selectNode != null)
                {
                    Node parentNode = GetParentNode(selectNode);
                    int num = parentNode.Nodes.Count;
                    t_simple_trend_diagnose tstd = new t_simple_trend_diagnose(parentNode.Name, diagnoseBm, this.lbChineseBmIcd.Text, this.lbChineseBmIcd.Text, num + 1, selectNode.Name);
                    if (tstd.Insert())
                    {
                        App.Msg("附属诊断添加成功！");
                        上级审签(selectNode, this.atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
                    }
                }
            }
            else if (this.caction == "update")
            {
                Node selectNode = this.atChineseDiagnose.SelectedNode;
                if (selectNode != null)
                {
                    if (selectNode.Parent == null)
                    {
                        t_simple_diagnose tsd = new t_simple_diagnose(this.lbChineseBmIcd.Text, "", diagnoseBm, this.lbChineseBmIcd.Text, 0, "0", "Y", diagnoseZh, this.lbChineseZhIcd.Text, this, this.comboBox2.SelectedValue.ToString(), this.dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm"));
                        if (tsd.Update(selectNode.Name))
                        {

                            if (flage)
                            {
                                string sqldelete = string.Format("delete necp.t_patient_diagnose where patient_id = '{0}'", patient.Id);
                                int x = App.ExecuteSQL(sqldelete);
                                DataInit.MatchPath(int.Parse(tsd.Patient_id), tsd.Diagnose_code, diagnoseBm, tsd.DiagnoseType);
                                flage = false;
                            }
                            App.Msg("诊断修改成功！");
                            上级审签(selectNode, this.atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
                        }
                    }
                    else
                    {
                        t_simple_trend_diagnose tstd = new t_simple_trend_diagnose("", diagnoseBm, this.lbChineseBmIcd.Text, this.lbChineseBmIcd.Text, 0, "");
                        if (tstd.Update(selectNode.Name))
                        {
                            App.Msg("附属诊断修改成功！");
                            上级审签(selectNode, this.atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
                        }
                    }
                }
            }
            else
            {
                int num = this.atChineseDiagnose.Nodes.Count;
                t_simple_diagnose tsd = new t_simple_diagnose(this.lbChineseBmIcd.Text, timeStr, diagnoseBm, this.lbChineseBmIcd.Text, num + 1, this.patient.Id.ToString(), "Y", diagnoseZh, this.lbChineseZhIcd.Text, this, this.comboBox2.SelectedValue.ToString(), this.dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm"));
                if (tsd.Insert())
                {
                    App.Msg("诊断添加成功！");
                }
            }
            this.caction = string.Empty;
            this.atChineseDiagnose.Enabled = true;
            this.clearChineseDiagnose();
            RefreshDiagnose(atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atChineseDiagnose.SelectedNode;
            if (selectNode != null)
            {
                if (IsEditDiag(selectNode))
                {
                    this.caction = "trend";
                    this.atChineseDiagnose.Enabled = false;
                    clearChineseDiagnose();
                    this.txtZh.Enabled = false;
                }
                else
                {
                    App.Msg("提示:权限不够,不能添加！");
                }
            }
            else
            {
                App.Msg("请选中要添加附属诊断的节点！");
            }
        }

        /// <summary>
        /// 中医-修改诊断
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atChineseDiagnose.SelectedNode;
            int index = this.atChineseDiagnose.SelectedIndex;
            if (index > 0)
            {

                if (selectNode != null)
                {
                    if (IsEditDiag(selectNode))
                    {
                        this.caction = "update";
                        this.atChineseDiagnose.Enabled = false;
                        DataRow row = (DataRow)selectNode.Tag;
                        this.txtBm.Text = selectNode.Text;
                        this.lbChineseBmIcd.Text = row["diagnose_code"].ToString();
                        if (selectNode.Parent == null)
                        {
                            string timeText = ((DataRow)selectNode.Tag)["fix_time"].ToString();
                            this.dateTimePicker2.Value = string.IsNullOrEmpty(timeText) ? App.GetSystemTime() : Convert.ToDateTime(timeText);
                        }
                        if (selectNode.Parent == null)
                        {
                            this.txtZh.Text = row["SYMPTOMS_NAME"].ToString();
                            this.lbChineseZhIcd.Text = row["SYMPTOMS_CODE"].ToString();
                        }
                        else
                        {
                            this.txtZh.Text = "";
                            this.lbChineseZhIcd.Text = "";
                            this.txtZh.Enabled = false;
                        }
                    }
                    else
                    {
                        App.Msg("提示:权限不够,不能修改！");
                    }
                }
                else
                {
                    App.Msg("请选中要修改的诊断节点！");
                }
            }
            else
            {
                string sb = this.atChineseDiagnose.Nodes[0].ToString();
                string[] sArray = sb.Split(',');
                string sql = "select *  from necp.t_patient_path a where a.patient_id='" + patient.Id + "' and IN_CODE='"+ sArray[2].Trim()+ "' ";
                DataTable sqlDt = App.GetDataSet(sql).Tables[0];
                if (sqlDt.Rows.Count > 0)
                {
                    App.Msg("已录入临床路径不可修改！");
                }
                else
                {

                    if (selectNode != null)
                    {
                        if (IsEditDiag(selectNode))
                        {
                            this.caction = "update";
                            flage = true;
                            this.atChineseDiagnose.Enabled = false;
                            DataRow row = (DataRow)selectNode.Tag;
                            this.txtBm.Text = selectNode.Text;
                            this.lbChineseBmIcd.Text = row["diagnose_code"].ToString();
                            if (selectNode.Parent == null)
                            {
                                string timeText = ((DataRow)selectNode.Tag)["fix_time"].ToString();
                                this.dateTimePicker2.Value = string.IsNullOrEmpty(timeText) ? App.GetSystemTime() : Convert.ToDateTime(timeText);
                            }
                            if (selectNode.Parent == null)
                            {
                                this.txtZh.Text = row["SYMPTOMS_NAME"].ToString();
                                this.lbChineseZhIcd.Text = row["SYMPTOMS_CODE"].ToString();
                            }
                            else
                            {
                                this.txtZh.Text = "";
                                this.lbChineseZhIcd.Text = "";
                                this.txtZh.Enabled = false;
                            }
                        }
                        else
                        {
                            App.Msg("提示:权限不够,不能修改！");
                        }
                    }
                    else
                    {
                        App.Msg("请选中要修改的诊断节点！");
                    }
                }
            }
        }
            

        /// <summary>
        /// 中医-删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            int index = this.atChineseDiagnose.SelectedIndex;
            int num = this.atChineseDiagnose.Nodes.Count;
            Node selectNode = this.atChineseDiagnose.SelectedNode;
            if (index > 0) {
                if (selectNode == null)
            {
                App.Msg("请选中要删除诊断的节点！");
                return;
            }
            if (IsEditDiag(selectNode))
            {
                if (MessageBox.Show("确定要删除该诊断吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                    return;
                if (selectNode.Parent == null)
                {
                    t_simple_diagnose.Delete(selectNode.Name, patient.Id.ToString(), this.comboBox2.SelectedValue.ToString(), "Y");
                    t_simple_trend_diagnose.Delete(selectNode.Name, 1, "");
                    string sb = "";
                }
                else
                {
                    t_simple_trend_diagnose.Delete(selectNode.Name, 0, selectNode.Parent.Name);
                }

                this.caction = string.Empty;
                this.atChineseDiagnose.Enabled = true;
                this.clearChineseDiagnose();
                RefreshDiagnose(atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
            }
            else
            {
                App.Msg("提示:权限不够,不能修改！");
            }
            }
            else
            {
                if (selectNode == null)
                {
                    App.Msg("请选中要删除诊断的节点！");
                    return;
                }
                if (IsEditDiag(selectNode))
                {
                    if (MessageBox.Show("确定要删除该诊断吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                        return;
                    if (selectNode.Parent == null)
                    {
                        t_simple_diagnose.Delete(selectNode.Name, patient.Id.ToString(), this.comboBox2.SelectedValue.ToString(), "Y");
                        t_simple_trend_diagnose.Delete(selectNode.Name, 1, "");
                        string sb = "";
                        string sqldelete = string.Format("delete necp.t_patient_diagnose where patient_id = '{0}'", patient.Id);
                        int m = App.ExecuteSQL(sqldelete);
                        if (m == 0 && index + 1 < num)
                        {
                            if (x == 1)
                            {
                                sb = this.atChineseDiagnose.Nodes[1].ToString();
                                string[] sArray = sb.Split(',');
                                DataInit.MatchPath(patient.Id, sArray[2].Trim(), sArray[0].Trim(), "403");
                            }
                        }
                    }
                    else
                    {
                        t_simple_trend_diagnose.Delete(selectNode.Name, 0, selectNode.Parent.Name);
                    }

                    this.caction = string.Empty;
                    this.atChineseDiagnose.Enabled = true;
                    this.clearChineseDiagnose();
                    RefreshDiagnose(atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
                }
                else
                {
                    App.Msg("提示:权限不够,不能修改！");
                }

            }
        }

        private void atChineseDiagnose_DoubleClick(object sender, EventArgs e)
        {
            atDiagnoseList_NodeDoubleClick(sender, null);
        }

        bool chineseChanged = false;
        private void atChineseDiagnose_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (chineseChanged)
                return;
            Node selectNode = this.atChineseDiagnose.SelectedNode;
            if (selectNode != null)
            {
                ChildCheck(selectNode, selectNode.Checked);
            }
        }

        private void checkBoxItem1_Click(object sender, EventArgs e)
        {
            chineseChanged = true;
            if (this.atChineseDiagnose.Nodes.Count > 0)
            {
                foreach (Node node in this.atChineseDiagnose.Nodes)
                {
                    node.Checked = checkBoxItem1.Checked;
                    //ChildCheck(node, node.Checked);
                }
            }
            chineseChanged = false;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            if (ChangedNodeMoveUp(atChineseDiagnose))
            {
                if (atDiagnoseList.SelectedNode != null && atDiagnoseList.SelectedNode.Parent == null)
                {
                    RefreshDiagnose(atDiagnoseList, "Y", this.comboBox1.SelectedValue.ToString());
                }
            }
        }
        private void buttonItem2_Click(object sender, EventArgs e)
        {
            if (ChangedNodeMoveDown(atChineseDiagnose))
            {
                if (atDiagnoseList.SelectedNode != null && atDiagnoseList.SelectedNode.Parent == null)
                {
                    RefreshDiagnose(atDiagnoseList, "Y", this.comboBox1.SelectedValue.ToString());
                }
            }
        }


        private void buttonItem3_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atDiagnoseList.SelectedNode;
            上级审签(selectNode, this.atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
        }

        private void 上级审签(Node selectNode, AdvTree tree, string isChinese, string diagnoset_Type)
        {
            if (selectNode != null && selectNode.Parent == null)
            {
                string currentId = App.UserAccount.UserInfo.User_id;
                //DataRow mrow = selectNode.Tag as DataRow;
                //string sjsx = mrow["sjsx_id"].ToString();  //三级书写
                //string ejsx = mrow["ejsx_id"].ToString();  //二级书写
                //string yjsx = mrow["yjsx_id"].ToString();  //一级书写
                //string fssx = mrow["fssx_id"].ToString();  //附属书写
                string fssx_id = "";
                string Guid_doctor_id = "";
                int SXlevel = 0;//getSXLevel(selectNode, ref fssx_id, ref Guid_doctor_id);
                currentId = "0";
                if (SXlevel == 3||
                    (SXlevel == 3 && currentId == patient.Chief_Doctor_Id.ToString()) ||
                    (SXlevel == 2 && currentId == patient.Charge_Doctor_Id.ToString()) ||
                    (SXlevel == 1 && currentId == patient.Resident_Doctor_Id.ToString()) ||
                    (SXlevel == 0 && currentId == fssx_id)||
                    (SXlevel == 0 && currentId != Guid_doctor_id))
                {
                    //return;
                }
                string sql = string.Empty;
                if (SXlevel < 3 && currentId == patient.Chief_Doctor_Id.ToString())
                {
                    sql = string.Format("update t_diagnose_item set sjsx_id='{0}',sjsx_name='{1}' where id = '{2}' ", currentId, App.UserAccount.UserInfo.User_name, selectNode.Name);
                }

                if (SXlevel < 2 && currentId == patient.Charge_Doctor_Id.ToString())
                {
                    sql = string.Format("update t_diagnose_item set ejsx_id='{0}',ejsx_name='{1}' where id = '{2}' ", currentId, App.UserAccount.UserInfo.User_name, selectNode.Name);
                }

                if (SXlevel < 1 && currentId == patient.Resident_Doctor_Id.ToString())
                {
                    sql = string.Format("update t_diagnose_item set yjsx_id='{0}',yjsx_name='{1}' where id = '{2}' ", currentId, App.UserAccount.UserInfo.User_name, selectNode.Name);
                }
                if (!string.IsNullOrEmpty(sql))
                {
                    App.ExecuteSQL(sql);
                    RefreshDiagnose(tree, isChinese, diagnoset_Type);
                }
                else
                {
                    App.Msg("提示:权限不够,无法审签！");
                }
            }
            else
            {
                App.Msg("提示:请选择需要审签的诊断！");
                //上级审签(selectNode.Parent, tree, isChinese, diagnoset_Type);
            }
        }

        private void cmsDiagnose_Opening(object sender, CancelEventArgs e)
        {
            this.复制诊断ToolStripMenuItem.DropDownItems.Clear();
            foreach (DataRow row in (this.comboBox1.DataSource as DataTable).Rows)
            {
                if (comboBox1.Text != row[1].ToString())
                {
                    ToolStripMenuItem items = new ToolStripMenuItem();
                    items.Text = row[1].ToString();
                    items.Tag = "N";
                    items.Name = row[0].ToString();
                    items.Click += new EventHandler(items_Click);
                    this.复制诊断ToolStripMenuItem.DropDownItems.Add(items);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                RefreshDiagnose(atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
                this.comboBox2.SelectedValue=this.comboBox1.SelectedValue.ToString();
            }
        }

        void items_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem items = sender as ToolStripMenuItem;
            if (items != null)
            {
                AdvTree advTree;
                if (items.Tag.ToString() == "N")
                {
                    advTree = this.atDiagnoseList;
                }
                else
                {
                    advTree = this.atChineseDiagnose;
                }
                string sxqm = string.Empty;
                this.GetDiagnoseQm(ref sxqm);
                if (string.IsNullOrEmpty(sxqm))
                {
                    App.Msg("您的权限不能够复制诊断。");
                    return;
                }
                List<string> list = new List<string>();
                int countadd = 0;
                foreach (Node item in advTree.Nodes)
                {
                    if (item.Checked)
                    {
                        GetSql(items.Name, App.GetSystemTime().ToString(), item, list, countadd, (advTree.Name == "atDiagnoseList" ? "N" : "Y"), sxqm);
                        countadd++;
                    }
                }
                if (list.Count > 0)
                {
                    if (App.ExecuteBatch(list.ToArray()) > 0)
                    {
                        App.Msg("复制成功。");
                        return;
                    }
                    App.Msg("复制失败");
                }
                else
                {
                    App.Msg("请勾选需要复制的诊断。");
                }
            }
        }

        public string GetDiagnoseQm(ref string sxQx)
        {
            string currentUserId = App.UserAccount.UserInfo.User_id;
            //if (currentUserId == patient.Resident_Doctor_Id.ToString())

            //if (App.UserAccount.UserInfo.U_tech_post_name.Contains("住院医师"))
            //{
            //    sxQx = ",yjsx_id,yjsx_name";
            //}
            ////if (currentUserId == patient.Charge_Doctor_Id.ToString())
            //if(App.UserAccount.UserInfo.U_tech_post_name.Contains("主治医师"))
            //{
            //    sxQx = ",ejsx_id,ejsx_name";
            //}
            ////if (currentUserId == patient.Chief_Doctor_Id.ToString())
            //if (App.UserAccount.UserInfo.U_tech_post_name.Contains("主任医师"))
            //{
            //    sxQx = ",sjsx_id,sjsx_name";
            //}
            sxQx = ",yjsx_id,yjsx_name";
            if (string.IsNullOrEmpty(sxQx) && this.comboBox1.SelectedValue.ToString() == "403")
            {//初步诊断: 才有附属书写;
                if (App.UserAccount.UserInfo.Guid_doctor_id == patient.Resident_Doctor_Id.ToString()
                    || App.UserAccount.UserInfo.Guid_doctor_id == patient.Charge_Doctor_Id.ToString()
                    || App.UserAccount.UserInfo.Guid_doctor_id == patient.Chief_Doctor_Id.ToString())
                {
                    sxQx = ",fssx_id,fssx_name";
                }
            }
            return currentUserId;
        }

        private void buttonItem4_Click(object sender, EventArgs e)
        {
            Node selectedNode = this.atChineseDiagnose.SelectedNode;
            上级审签(selectedNode, this.atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox2.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                RefreshDiagnose(atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
                this.comboBox1.SelectedValue = this.comboBox2.SelectedValue.ToString();
            }
        }

        private void cmsChineseDiagnose_Opening(object sender, CancelEventArgs e)
        {
            this.复制诊断到ToolStripMenuItem.Enabled = true;
            this.复制诊断到ToolStripMenuItem.Visible = true;
            this.复制诊断到ToolStripMenuItem.DropDownItems.Clear();
            foreach (DataRow row in (this.comboBox2.DataSource as DataTable).Rows)
            {
                if (comboBox2.Text != row[1].ToString())
                {
                    ToolStripMenuItem items = new ToolStripMenuItem();
                    items.Text = row[1].ToString();
                    items.Name = row[0].ToString();
                    items.Tag = "Y";
                    items.Click += new EventHandler(items_Click);
                    this.复制诊断到ToolStripMenuItem.DropDownItems.Add(items);
                }
            }
        }

        private void 添加为常用诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem items=sender as ToolStripMenuItem;
            AdvTree advTree;
            if (items.Tag.ToString() == "N")
            {
                advTree = this.atDiagnoseList;
            }
            else
            {
                advTree = this.atChineseDiagnose;
            }
            List<string> list = new List<string>();
            int countadd = 0;
            DateTime createTime = App.GetSystemTime();
            foreach (Node item in advTree.Nodes)
            {
                if (item.Checked)
                {
                    //GetSql(items.Name, App.GetSystemTime().ToString(), item, list, countadd, IsChinese);
                    string diagnose_id = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString();
                    string sql = string.Format(@"INSERT INTO t_diagnose_often( id,
                                                                              create_time,
                                                                              create_id,
                                                                              diagnose_name,
                                                                              diagnose_icd10,
                                                                              is_chinese,
                                                                              diagnose_sort,
                                                                              symptoms_name,
                                                                              symptoms_code)
                                                                        SELECT 
                                                                              '{0}',
                                                                              to_TIMESTAMP('{1}','yyyy-MM-dd hh24:mi:ss'),
                                                                              '{2}',
                                                                              diagnose_name,
                                                                              diagnose_icd10,
                                                                              is_chinese,
                                                                              diagnose_sort,
                                                                              symptoms_name,
                                                                              symptoms_code
                                                                        FROM t_diagnose_item  WHERE ID = '{3}'",
                                                                        diagnose_id,
                                                                        createTime.ToString(),
                                                                        App.UserAccount.UserInfo.User_id,
                                                                        item.Name);
                    list.Add(sql);
                    SetCopyTrend_diagnose_often(list, item, diagnose_id, diagnose_id);
                    countadd++;
                }
            }
            if (list.Count > 0)
            {
                if (App.ExecuteBatch(list.ToArray()) > 0)
                {
                    App.Msg("添加成功。");
                    return;
                }
                App.Msg("添加失败");
            }
            else
            {
                App.Msg("请勾选需要添加为常用的诊断。");
            }
        }

        private void SetCopyTrend_diagnose_often(List<string> sqlList, Node _node, string diagnoseId, string parentId)
        {
            foreach (Node childNode in _node.Nodes)
            {
                DataRow row = childNode.Tag as DataRow;
                string newid = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString(); //诊断条目ID
                string sql = string.Format(@"INSERT INTO t_trend_diagnose_often(ID,
                                                TREND_DIAGNOSE_NAME,
                                                DIAGNOSE_ICD10,
                                                TREND_SORT,
                                                PARENT_ID,DIAGNOSE_ID) 
                                            VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                      newid,
                                      childNode.Text.Replace("'", "''"),
                                      row["DIAGNOSE_ICD10"].ToString(),
                                      childNode.Index,
                                      parentId, diagnoseId);
                sqlList.Add(sql);
                if (childNode.Nodes.Count > 0)
                {
                    SetCopyTrend_diagnose_often(sqlList, childNode, diagnoseId, newid);
                }
            }
        }

        private void tabItem1_Click(object sender, EventArgs e)
        {
            RefreshDiagnose(atDiagnoseList, "N", this.comboBox1.SelectedValue.ToString());
        }

        private void tabItem2_Click(object sender, EventArgs e)
        {
            RefreshDiagnose(atChineseDiagnose, "Y", this.comboBox2.SelectedValue.ToString());
        }

        private void tabItem3_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DateTimePicker dtp = sender as DateTimePicker;
                if (patient != null && dtp.Value < patient.In_Time)
                {
                    App.Msg("提示:当前选择日期小于病人入院日期!");
                    dtp.Value = DateTime.Now;
                }
            }
            catch (Exception)
            {
            }
        }

        private void frmDiagnoseSimple_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Hide();
            //DataInit.RefreshDocDiagnoseAction?.Invoke(2);
        }

        private void tcDiagnose_TabIndexChanged(object sender, EventArgs e)
        {
            int y = this.tcDiagnose.SelectedTabIndex;
        }

        private void tcDiagnose_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
             x = this.tcDiagnose.SelectedTabIndex;
        }
    }

    public class t_simple_diagnose
    {
        private string diagnose_code;

        public string Diagnose_code
        {
            get { return diagnose_code; }
            set { diagnose_code = value; }
        }

        private string diagnoseType;

        public string DiagnoseType
        {
            get { return diagnoseType; }
            set { diagnoseType = value; }
        }

        private string create_time;

        public string Create_time
        {
            get { return create_time; }
            set { create_time = value; }
        }

        private string fix_time;


        public string Fix_time
        {
            get { return fix_time; }
            set { fix_time = value; }
        }
        private string diagnose_name;

        public string Diagnose_name
        {
            get { return diagnose_name; }
            set { diagnose_name = value; }
        }
        private string diagnose_icd10;

        public string Diagnose_icd10
        {
            get { return diagnose_icd10; }
            set { diagnose_icd10 = value; }
        }
        private int diagnose_sort;

        public int Diagnose_sort
        {
            get { return diagnose_sort; }
            set { diagnose_sort = value; }
        }
        private string patient_id;

        public string Patient_id
        {
            get { return patient_id; }
            set { patient_id = value; }
        }

        private string is_chinese = "N";

        public string Is_chinese
        {
            get { return is_chinese; }
            set { is_chinese = value; }
        }

        private string symptoms_name;

        public string Symptoms_name
        {
            get { return symptoms_name; }
            set { symptoms_name = value; }
        }

        private string symptoms_code;

        public string Symptoms_code
        {
            get { return symptoms_code; }
            set { symptoms_code = value; }
        }

        private frmDiagnoseSimple Diagnose;

        public t_simple_diagnose(
            string code,
            string time,
            string name,
            string icd10,
            int sort,
            string pid,
            frmDiagnoseSimple DiagnoseSimple,
            string diagnose_type,
            string fix_time)
        {
            this.diagnose_code = code;
            this.create_time = time;
            this.diagnose_name = name;
            this.diagnose_icd10 = icd10;
            this.diagnose_sort = sort;
            this.patient_id = pid;
            Diagnose = DiagnoseSimple;
            this.diagnoseType = diagnose_type;
            this.fix_time = fix_time;
        }

        public t_simple_diagnose(
            string code,
            string time,
            string name,
            string icd10,
            int sort,
            string pid,
            string is_chinese,
            string zhName,
            string zhIcd,
            frmDiagnoseSimple DiagnoseSimple,
            string diagnose_type,
            string fix_time)
        {
            this.diagnose_code = code;
            this.create_time = time;
            this.diagnose_name = name;
            this.diagnose_icd10 = icd10;
            this.diagnose_sort = sort;
            this.patient_id = pid;
            this.symptoms_name = zhName;
            this.Symptoms_code = zhIcd;
            this.is_chinese = is_chinese;
            Diagnose = DiagnoseSimple;
            this.diagnoseType = diagnose_type;
            this.fix_time = fix_time;
        }


        public bool Insert()
        {
            string sxQx = string.Empty;
            Diagnose.GetDiagnoseQm(ref sxQx);
            if (string.IsNullOrEmpty(sxQx))
            {
                //测试
                //sxQx = ",sjsx_id,sjsx_name";
                App.Msg("您的权限不能够添加诊断。");
                return false;
            }

            string newid = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString();
            string max = App.GetDataSet(string.Format("select max(diagnose_sort)+1 from t_diagnose_item where patient_id = '{0}' and diagnose_type = '{1}' and is_chinese = '{2}'", patient_id, diagnoseType, this.is_chinese)).Tables[0].Rows[0][0].ToString();
            if (string.IsNullOrEmpty(max))
            {
                max = "0";
            }
            string sql =
                string.Format("insert into t_diagnose_item(id,diagnose_type,diagnose_code,create_id,create_time,fix_time,diagnose_name, diagnose_icd10,diagnose_sort,patient_id,is_chinese,symptoms_name,symptoms_code{9})values('{12}','{13}','{0}','{14}',to_TIMESTAMP('{1}','yyyy-MM-dd hh24:mi:ss'),to_TIMESTAMP('{15}','yyyy-MM-dd hh24:mi:ss'),'{2}','{3}','{4}','{5}','{6}','{7}','{8}','{10}','{11}')",
                diagnose_code,
                create_time,
                diagnose_name,
                diagnose_icd10,
                max,
                patient_id,
                is_chinese,
                symptoms_name,
                symptoms_code,
                sxQx,
               App.UserAccount.UserInfo.User_id,
               App.UserAccount.UserInfo.User_name,
               newid,
               this.diagnoseType,
               App.UserAccount.UserInfo.User_id,
               fix_time);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }

        public static bool Delete(string id, string patient_id, string diagnose_type, string isChinese)
        {
            string sql2 = string.Format("update t_diagnose_item t set t.diagnose_sort = t.diagnose_sort-1 where t.patient_id = '{0}' and is_chinese='{3}' and t.diagnose_type = '{2}' and t.diagnose_sort > (select x.diagnose_sort from t_diagnose_item x where x.id = '{1}')", patient_id, id, diagnose_type, isChinese);
            App.ExecuteSQL(sql2);
            string sql = string.Format("delete t_diagnose_item where id = '{0}'", id);

            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Update(string id)
        {
            string sql
                = string.Format("update t_diagnose_item " +
                  "set diagnose_code = '{0}'," +
                  "diagnose_name = '{1}'," +
                  "diagnose_icd10 = '{2}'," +
                  "symptoms_name = '{3}'," +
                  "symptoms_code = '{4}', " +
                  "fix_time = to_TIMESTAMP('{6}','yyyy-MM-dd hh24:mi:ss') " +
                  "where id = '{5}'",
                  diagnose_code,
                  diagnose_name,
                  diagnose_icd10,
                  symptoms_name,
                  symptoms_code,
                  id,
                  this.fix_time);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }
    }

    public class t_simple_trend_diagnose
    {
        private string diagnoseitem_id;

        public string Diagnoseitem_id
        {
            get { return diagnoseitem_id; }
            set { diagnoseitem_id = value; }
        }
        private string trend_diagnose_name;

        public string Trend_diagnose_name
        {
            get { return trend_diagnose_name; }
            set { trend_diagnose_name = value; }
        }
        private string diagnose_icd10;

        public string Diagnose_icd10
        {
            get { return diagnose_icd10; }
            set { diagnose_icd10 = value; }
        }
        private string diagnose_code;

        public string Diagnose_code
        {
            get { return diagnose_code; }
            set { diagnose_code = value; }
        }
        private int sort_sequence;

        public int Sort_sequence
        {
            get { return sort_sequence; }
            set { sort_sequence = value; }
        }
        private string parent_id;

        public string Parent_id
        {
            get { return parent_id; }
            set { parent_id = value; }
        }

        private string diagnose_type;
        public string Diagnose_Type
        {
            get { return diagnose_type; }
            set { diagnose_type = value; }
        }

        public t_simple_trend_diagnose(
            string parentId,
            string name,
            string icd10,
            string code,
            int sort,
            string pid)
        {
            diagnoseitem_id = parentId;
            trend_diagnose_name = name;
            diagnose_icd10 = icd10;
            diagnose_code = code;
            sort_sequence = sort;
            parent_id = pid;
        }

        public bool Insert()
        {
            string newid = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString();

            string max = App.GetDataSet(string.Format("select max(sort_sequence)+1 from t_trend_diagnose where parent_id = '{0}'", parent_id)).Tables[0].Rows[0][0].ToString();
            if (string.IsNullOrEmpty(max))
            {
                max = "0";
            }

            string sql = string.Format("insert into t_trend_diagnose" +
                "(id,diagnoseitem_id, trend_diagnose_name, diagnose_icd10, diagnose_code, sort_sequence, parent_id)" +
                "values" +
                "('{6}','{0}', '{1}', '{2}', '{3}', {4}, {5})",
                diagnoseitem_id,
                trend_diagnose_name,
                diagnose_icd10,
                diagnose_code,
                max,
                parent_id,
                newid);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }

        public static bool Delete(string id, int type, string parent_id)
        {
            string sql = string.Empty;
            if (type == 0)
            {
                string sql2 = string.Format("update t_trend_diagnose t set t.sort_sequence = t.sort_sequence-1 where t.parent_id = '{0}' and t.sort_sequence > (select x.sort_sequence from t_trend_diagnose x where x.id = '{1}')", parent_id, id);
                App.ExecuteSQL(sql2);

                sql = string.Format("delete t_trend_diagnose where id = {0}", id);
            }
            else
                sql = string.Format("delete t_trend_diagnose where parent_id ='{0}'", id);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Update(string id)
        {
            string sql = string.Format(
                "update t_trend_diagnose " +
                "set " +
                "trend_diagnose_name = '{0}'," +
                "diagnose_icd10 = '{1}'," +
                "diagnose_code = '{2}' " +
                "where id = '{3}'",
                trend_diagnose_name,
                diagnose_icd10,
                diagnose_code,
                id);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }
    }
}
