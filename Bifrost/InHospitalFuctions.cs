using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using DevComponents.AdvTree;

namespace Bifrost
{
    /// <summary>
    /// ������������һЩ���÷���
    /// </summary>
    public class InHospitalFuctions
    {
        /// <summary>
        /// ����������
        /// </summary>
        private string Sql_BookCategory = "select * from t_data_code where type=31";

        /// <summary>
        /// �����������
        /// </summary>
        private string Sql_BookAll = "select * from t_data_code where type=31";

        /// <summary>
        ///  ��ʾ����
        /// </summary>
        /// <param name="trvBook"></param>
        public static void ReflashBookTree(TreeView trvBook)
        {
            //�����������
            string SQl = "select * from T_TEXT where enable_flag='Y' order by shownum asc";
            //�ҳ������������
            string Sql_Category = "select * from t_data_code where type=31 and enable='Y'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = GetSelectClassDs(ds);
            //�õ����������
            DataSet ds_category = App.GetDataSet(Sql_Category);
            Class_Datacodecs[] datacodes = GetSelectDirectionary(ds_category);
            if (datacodes != null)
            {
                for (int j = 0; j < datacodes.Length; j++)    //����������ڵ�
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
                                SetTreeView(Directionarys, tn);   //����������������顣
                            }
                        }
                    }
                    trvBook.Nodes.Add(tempNode);
                    SetTreeNodesImage(trvBook.Nodes);
                }
            }
        }

        /// <summary>
        ///  ��ʾ����
        /// </summary>
        /// <param name="trvBook"></param>
        public static void ReflashBookTree(DevComponents.AdvTree.AdvTree trvBook)
        {
            //�����������
            string SQl = "select * from T_TEXT where enable_flag='Y' order by shownum asc";
            //�ҳ������������
            string Sql_Category = "select * from t_data_code where type=31 and enable='Y'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = GetSelectClassDs(ds);
            //�õ����������
            DataSet ds_category = App.GetDataSet(Sql_Category);
            Class_Datacodecs[] datacodes = GetSelectDirectionary(ds_category);
            if (datacodes != null)
            {
                for (int j = 0; j < datacodes.Length; j++)    //����������ڵ�
                {
                    Node tempNode = new Node();
                    tempNode.Name = datacodes[j].Id;
                    tempNode.Text = datacodes[j].Name;
                    tempNode.Tag = datacodes[j] as object;
                    tempNode.ImageIndex = 1;                    
                    if (Directionarys != null)
                    {
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            Node tn = new Node();
                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;
                            tn.Name = Directionarys[i].Id.ToString();
                            //���붥���ڵ�
                            if (Directionarys[i].Parentid == 0 && datacodes[j].Id.Equals(Directionarys[i].Txxttype))
                            {
                                tempNode.Nodes.Add(tn);
                                SetTreeView(Directionarys, tn);   //����������������顣
                            }
                        }
                    }
                    trvBook.Nodes.Add(tempNode);
                    SetTreeNodesImage(trvBook.Nodes);
                }
            }
        }

        /// <summary>
        /// ������ͼ��
        /// </summary>
        /// <param name="nodes">�ڵ㼯��</param>
        public static void SetTreeNodesImage(TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Parent == null)
                {
                    nodes[i].ImageIndex = 15;
                    nodes[i].SelectedImageIndex = 15;
                }
                else if (nodes[i].Nodes.Count > 0 && nodes[i].Parent != null)
                {
                    nodes[i].ImageIndex = 20;
                    nodes[i].SelectedImageIndex = 20;

                }
                else
                {
                    if (nodes[i].Tag != null)
                    {
                        Class_Text cunrrentDir = (Class_Text)nodes[i].Tag;
                        if (cunrrentDir.Issimpleinstance == "0")   //�ǵ�������
                        {
                            nodes[i].SelectedImageIndex = 17;
                            nodes[i].ImageIndex = 17;
                        }
                        else
                        {
                            nodes[i].ImageIndex = 18;
                            nodes[i].SelectedImageIndex = 18;
                        }
                    }
                }

                if (nodes[i].Nodes.Count > 0)
                {
                    SetTreeNodesImage(nodes[i].Nodes);
                }
            } 
        }

        /// <summary>
        /// ������ͼ��
        /// </summary>
        /// <param name="nodes">�ڵ㼯��</param>
        public static void SetTreeNodesImage(NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Parent == null)
                {
                    nodes[i].ImageIndex = 15;                    
                }
                else if (nodes[i].Nodes.Count > 0 && nodes[i].Parent != null)
                {
                    nodes[i].ImageIndex = 20;                  
                }
                else
                {
                    if (nodes[i].Tag != null)
                    {
                        Class_Text cunrrentDir = (Class_Text)nodes[i].Tag;
                        if (cunrrentDir.Issimpleinstance == "0")   //�ǵ�������
                        {                            
                            nodes[i].ImageIndex = 17;
                        }
                        else
                        {
                            nodes[i].ImageIndex = 18;                           
                        }
                    }
                }

                if (nodes[i].Nodes.Count > 0)
                {
                    SetTreeNodesImage(nodes[i].Nodes);
                }
            }
        }

        /// <summary>
        /// ��������з�������
        /// </summary>
        /// <param Name="Directionarys">��������ڵ㼯��</param>
        /// <param Name="currentnode">��ǰ����ڵ�</param>
        public static void SetTreeView(Class_Text[] Directionarys, TreeNode current)
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
                    if (Directionarys[i].Issimpleinstance == "0")   //�ǵ�������
                    {
                        tn.SelectedImageIndex = 7;
                        tn.ImageIndex = 7;
                    }
                    else
                    {
                        tn.ImageIndex = 9;
                        tn.SelectedImageIndex = 9;
                    }
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }
            }
        }

        /// <summary>
        /// ��������з�������
        /// </summary>
        /// <param Name="Directionarys">��������ڵ㼯��</param>
        /// <param Name="currentnode">��ǰ����ڵ�</param>
        public static void SetTreeView(Class_Text[] Directionarys, Node current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Text cunrrentDir = (Class_Text)current.Tag;
                if (Directionarys[i].Parentid == cunrrentDir.Id)
                {
                    Node tn = new Node();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    if (Directionarys[i].Issimpleinstance == "0")   //�ǵ�������
                    {                     
                        tn.ImageIndex = 7;
                    }
                    else
                    {
                        tn.ImageIndex = 9;                       
                    }
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
        public static Class_Text[] GetSelectClassDs(DataSet tempds)
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
                        class_text[i].Issimpleinstance = tempds.Tables[0].Rows[i]["issimpleinstance"].ToString();
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
        /// ��õ�ǰ��������������ռ�õĴ���
        /// </summary>
        /// <returns>DataTable</returns>
        public static DataTable GetSickAreaBusyBed(int sick_Area)
        {
            DataTable dt = null;
            if (sick_Area != 0)
            {
                string Sql_GetBusyBed = "select a.sick_bed_id,a.sick_bed_no from t_in_patient a " +
                                         " inner join t_sickbedinfo b on a.sick_bed_id = b.bed_id" +
                                         " where sick_area_id=" + sick_Area + " and b.state=74";
                DataSet ds = App.GetDataSet(Sql_GetBusyBed);
                if (ds != null)
                {
                    dt = ds.Tables[0];
                }
            }
            return dt;
        }


        /// <summary>
        /// ���ݲ���סԺ�ţ��õ��ò��˵���������
        /// </summary>
        /// <param name="pid">סԺ��</param>
        /// <returns>����������ڵ�</returns>
        public static TreeNode SelectDoc(string pid)
        {
            TreeNode nodeTemp = new TreeNode();
            string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,b.textname,b.create_time from t_patients_doc a " +
                         "left join t_quality_text b on a.tid=b.tid where a.pid='" + pid + "' order by a.textname desc";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Patient_Doc pDoc = new Patient_Doc();
                        pDoc.Id = Convert.ToInt32(row["tid"]);
                        pDoc.Pid = row["pid"].ToString();
                        if (row["textkind_id"].ToString() != "")
                            pDoc.Textkind_id = Convert.ToInt32(row["textkind_id"]);
                        if (row["belongtosys_id"].ToString() != "")
                            pDoc.Belongtosys_id = Convert.ToInt32(row["belongtosys_id"]);
                        //pDoc.Patients_doc =row["patients_doc"].ToString();
                        if (row["sickkind_id"].ToString() != "")
                            pDoc.Sickkind_id = Convert.ToInt32(row["sickkind_id"]);
                        if (row["textname"].ToString() != "")
                        {
                            pDoc.Textname = row["textname"].ToString().TrimStart();
                        }
                        else
                        {
                            pDoc.Textname = row["create_time"].ToString().TrimStart();
                        }
                        TreeNode node = new TreeNode();
                        node.Text = pDoc.Textname;
                        node.Tag = pDoc as object;
                        node.Name = pDoc.Id.ToString();
                        node.ImageIndex = 19;
                        node.SelectedImageIndex = 19;
                        nodeTemp.Nodes.Add(node);
                    }
                }
            }
            return nodeTemp;
        }


        /// <summary>
        /// ���ݲ���סԺ�ţ��õ��ò��˵���������
        /// </summary>
        /// <param name="pid">סԺ��</param>
        /// <returns>����������ڵ�</returns>
        public static Node SelectDoc2(string pid)
        {
            Node nodeTemp = new Node();
            string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,b.textname,b.create_time from t_patients_doc a " +
                         "left join t_quality_text b on a.tid=b.tid where a.pid='" + pid + "' order by a.textname desc";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Patient_Doc pDoc = new Patient_Doc();
                        pDoc.Id = Convert.ToInt32(row["tid"]);
                        pDoc.Pid = row["pid"].ToString();
                        if (row["textkind_id"].ToString() != "")
                            pDoc.Textkind_id = Convert.ToInt32(row["textkind_id"]);
                        if (row["belongtosys_id"].ToString() != "")
                            pDoc.Belongtosys_id = Convert.ToInt32(row["belongtosys_id"]);
                        //pDoc.Patients_doc =row["patients_doc"].ToString();
                        if (row["sickkind_id"].ToString() != "")
                            pDoc.Sickkind_id = Convert.ToInt32(row["sickkind_id"]);
                        if (row["textname"].ToString() != "")
                        {
                            pDoc.Textname = row["textname"].ToString().TrimStart();
                        }
                        else
                        {
                            pDoc.Textname = row["create_time"].ToString().TrimStart();
                        }
                        Node node = new Node();
                        node.Text = pDoc.Textname;
                        node.Tag = pDoc as object;
                        node.Name = pDoc.Id.ToString();
                        node.ImageIndex = 19;                       
                        nodeTemp.Nodes.Add(node);
                    }
                }
            }
            return nodeTemp;
        }

        /// <summary>
        /// ���ݲ���סԺ�ţ��õ��ò��˵�ǰ���͵���������
        /// </summary>
        /// <param name="pid">סԺ��</param>
        ///<param name="tid">ס��������id</param>
        /// <returns>����������ڵ�</returns>
        public static TreeNode SelectDoc(string pid, string tid)
        {
            TreeNode nodeTemp = new TreeNode();
            string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,b.textname,b.create_time from t_patients_doc a " +
                         "left join t_quality_text b on a.tid=b.tid where a.pid='" + pid + "' and a.textkind_id=" + tid + " order by a.textname desc";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Patient_Doc pDoc = new Patient_Doc();
                        pDoc.Id = Convert.ToInt32(row["tid"]);
                        pDoc.Pid = row["pid"].ToString();
                        if (row["textkind_id"].ToString() != "")
                            pDoc.Textkind_id = Convert.ToInt32(row["textkind_id"]);
                        if (row["belongtosys_id"].ToString() != "")
                            pDoc.Belongtosys_id = Convert.ToInt32(row["belongtosys_id"]);
                        //pDoc.Patients_doc =row["patients_doc"].ToString();
                        if (row["sickkind_id"].ToString() != "")
                            pDoc.Sickkind_id = Convert.ToInt32(row["sickkind_id"]);
                        if (row["textname"].ToString() != "")
                        {
                            pDoc.Textname = row["textname"].ToString().TrimStart();
                        }
                        else
                        {
                            pDoc.Textname = row["create_time"].ToString().TrimStart();
                        }
                        TreeNode node = new TreeNode();
                        node.Text = pDoc.Textname;
                        node.Tag = pDoc as object;
                        node.Name = pDoc.Id.ToString();
                        node.ImageIndex = 13;
                        node.SelectedImageIndex = 13;
                        nodeTemp.Nodes.Add(node);
                    }
                }
            }
            return nodeTemp;
        }

        /// <summary>
        /// ���ݲ���סԺ�ţ��õ��ò��˵�ǰ���͵���������
        /// </summary>
        /// <param name="pid">סԺ��</param>
        ///<param name="tid">ס��������id</param>
        /// <returns>����������ڵ�</returns>
        public static Node SelectDoc2(string pid, string tid)
        {
            Node nodeTemp = new Node();
            string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,b.textname,b.create_time from t_patients_doc a " +
                         "left join t_quality_text b on a.tid=b.tid where a.pid='" + pid + "' and a.textkind_id=" + tid + " order by a.textname desc";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        Patient_Doc pDoc = new Patient_Doc();
                        pDoc.Id = Convert.ToInt32(row["tid"]);
                        pDoc.Pid = row["pid"].ToString();
                        if (row["textkind_id"].ToString() != "")
                            pDoc.Textkind_id = Convert.ToInt32(row["textkind_id"]);
                        if (row["belongtosys_id"].ToString() != "")
                            pDoc.Belongtosys_id = Convert.ToInt32(row["belongtosys_id"]);
                        //pDoc.Patients_doc =row["patients_doc"].ToString();
                        if (row["sickkind_id"].ToString() != "")
                            pDoc.Sickkind_id = Convert.ToInt32(row["sickkind_id"]);
                        if (row["textname"].ToString() != "")
                        {
                            pDoc.Textname = row["textname"].ToString().TrimStart();
                        }
                        else
                        {
                            pDoc.Textname = row["create_time"].ToString().TrimStart();
                        }
                        Node node = new Node();
                        node.Text = pDoc.Textname;
                        node.Tag = pDoc as object;
                        node.Name = pDoc.Id.ToString();
                        node.ImageIndex = 13;                       
                        nodeTemp.Nodes.Add(node);
                    }
                }
            }
            return nodeTemp;
        }
    }
}
