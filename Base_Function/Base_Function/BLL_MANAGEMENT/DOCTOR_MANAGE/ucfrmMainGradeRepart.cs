using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Bifrost;
using System.Collections;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR;
using Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    /// <summary>
    /// �������ֱ����û��ؼ�
    /// </summary>
    /// �޸� ������
    /// �޸�ʱ�� 2013��12��25��
    public partial class ucfrmMainGradeRepart : UserControl
    {
        UserRights userRights = new UserRights();
        /// <summary>
        /// ѡ�в���id
        /// </summary>
        public string gid;
        /// <summary>
        /// ѡ�в���pid
        /// </summary>
        public string gpid;
        /// <summary>
        /// Ĭ��ѡ�п���
        /// </summary>
        public string sickname;

        /// <summary>
        /// �������ֽ����Ƿ���ʾ,Ĭ����ʾ
        /// </summary>
        public bool tabItemVisible = true;

        int selRow = 0;

        public ucfrmMainGradeRepart()
        {           
           InitializeComponent();
           AddComboxItem();
        }

        /// <summary>
        /// ������ָ�����Ҵ���
        /// </summary>
        /// <param name="sick_name"></param>
        public ucfrmMainGradeRepart(string sick_name)
        {
            sickname = sick_name;
            InitializeComponent();
            AddComboxItem();
        }

         /// <summary>
        /// ���ַ���ָ�����Ҵ���
         /// </summary>
         /// <param name="sick_name">������</param>
         /// <param name="visbool">�Ƿ���ʾ����ҳ</param>
        public ucfrmMainGradeRepart(string sick_name,bool visbool)
        {
            sickname = sick_name;
            InitializeComponent();
            //���ַ���ֻ�ÿ�����ʷ����
            tabItem1.Visible = visbool;
            AddComboxItem();
        }

        public ucfrmMainGradeRepart(ArrayList buttonRights)
        {
            try
            {
                InitializeComponent();
                SetSickName();
                AddComboxItem();
                this.cboxRand.SelectedIndex = 0;
                this.btnQuery.Enabled = false;
                this.btnAddGrade.Enabled = false;
                this.btnSave.Enabled = false;
                this.button5.Enabled = false;
                //��д��Ȩ��
                if (userRights.isExistRole("tsbtnWrite", buttonRights))
                {
                    this.btnAddGrade.Enabled = true;
                    this.btnSave.Enabled = true;
                    this.btnQuery.Enabled = true;
                }
                //�鿴��Ȩ��
                if (userRights.isExistRole("tsbtnLook", buttonRights))
                {
                    this.button5.Enabled = true;
                }
            }
            catch
            {
            }
        }
        DataTable dt = new DataTable();//���ݲ�ѯ������ʱ���һ�ΰ󶨵�datatable
        DataView dv;//Ҫ���������ȡ��ʱ�򱣴����ݵ��Զ�����ͼ
        DataTable dt2;//��������ڰ󶨵�datatable
        //DataRowView drview;
        private void SetSickName()
        {
            string sickSQL = "select sid,section_name from t_sectioninfo t where  enable_flag='Y' order by section_name";
            DataSet ds1 = App.GetDataSet(sickSQL);
            DataSet ds2 = App.GetDataSet(sickSQL);

            DataRow dr = ds1.Tables[0].NewRow();
            dr["sid"] = "0";
            dr["section_name"] = "ȫԺ";
            ds1.Tables[0].Rows.InsertAt(dr, 0);
            this.cboxSick.DataSource = ds1.Tables[0].DefaultView;
            this.cboxSick.DisplayMember = "section_name";
            this.cboxSick.ValueMember = "sid";

            dr = ds2.Tables[0].NewRow();
            dr["sid"] = "0";
            dr["section_name"] = "ȫԺ";
            ds2.Tables[0].Rows.InsertAt(dr, 0);
            dr = ds2.Tables[0].NewRow();
            dr["sid"] = "1";
            dr["section_name"] = "�ʿؿ�";
            ds2.Tables[0].Rows.InsertAt(dr, 1);
            dr = ds2.Tables[0].NewRow();
            dr["sid"] = "2";
            dr["section_name"] = "ҽ���";
            ds2.Tables[0].Rows.InsertAt(dr, 2);
            this.cboxSickname.DataSource = ds2.Tables[0].DefaultView;
            this.cboxSickname.DisplayMember = "section_name";
            this.cboxSickname.ValueMember = "sid";

            if (sickname!=null&&sickname!="")
            {//�Ƿ񹤾�����������
                this.cboxSick.Text = sickname;
                this.cboxSick.Enabled = false;
                this.cboxSickname.Text = sickname;
                this.cboxSickname.Enabled = false;
            }

        }

        /// <summary>
        /// ������������������"�����ȡ"����Ϊ200�ݡ�
        /// </summary>
        private void AddComboxItem()
        {
            this.cboxRand.Items.Clear();
            for (int i = 1; i <= 200; i++)
            {
                this.cboxRand.Items.Add(i);
            }
            this.cboxRand.SelectedIndex = 0;
        }
        
        private void pingfentoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (c1FlexGrid1.RowSel <= 0)
            {
                App.Msg("����δѡ��Ҫ���ֵ���");
                return;
            }
            frmGrade fg = new frmGrade(this);
            fg.ShowDialog();
        }
        /// <summary>
        /// ��סԺ�Ŵ���ȥ��PID��
        /// </summary>
        /// <returns></returns>
        public string SetPingfen()
        {
            if (c1FlexGrid1.RowSel >= 0)
            {
                gid = c1FlexGrid1[c1FlexGrid1.RowSel, "���"].ToString();
                gpid = c1FlexGrid1[c1FlexGrid1.RowSel, "סԺ��"].ToString();
                return gpid;
            }
            else
            {
                App.Msg("��ûѡ���˰�");
                return "";
            }
        }
        /// <summary>
        /// �ѹܴ�ҽ����������ȥ
        /// </summary>
        /// <returns></returns> 
        public string SetSuffererName()
        {
            if (c1FlexGrid1.RowSel >= 0)
            {
                return c1FlexGrid1[c1FlexGrid1.RowSel, "�ܴ�ҽ��"].ToString();
            }
            else
            {
                App.Msg("��ûѡ���˰�");
                return "";
            }
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (c1FlexGrid1.RowSel <= 0)
            {
                App.Msg("����δѡ��Ҫɾ������");
                return;
            }
            //ɾ������ɾ�����ݿ⡣���ǰ���ѡ�е�һ���Ƴ���
            int r = c1FlexGrid1.Rows[c1FlexGrid1.RowSel].DataIndex;//ѡ�е���
            if (r >= 0)
                dt2.Rows.RemoveAt(r);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //�鿴
            if (ucC1FlexGrid1.fg.RowSel <= 0)
            {
                App.Msg("����δѡ��Ҫ�鿴����");
                return;
            }
            frmMainSelectHistoryRepart fsht = new frmMainSelectHistoryRepart(this);
            fsht.ShowDialog();
        }
        /// <summary>
        /// ����ʱ������ֵ�ʱ�䴫��ȥ
        /// </summary>
        /// <returns></returns>
        public string SetTime()
        {
            return ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "����ʱ��"].ToString();
        }

        /// <summary>
        /// �ѿ�����������ȥ
        /// </summary>
        /// <returns></returns>
        public string SetSection_name()
        {
            return ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, "���ֿ���"].ToString();
        }
        /// <summary>
        /// ����������ֲ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            frmAddGradeRepart fagr = new frmAddGradeRepart(this, this.cboxSick.Text);
            App.ButtonStytle(fagr, false);
            fagr.ShowDialog();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string num = this.cboxRand.Text;//��ѯ��������
            string querySQL = "select id as ���, SECTION_NAME as ����, pid as סԺ��, patient_name as ��������, in_time as סԺ����, " +
                              "die_time as ��Ժ����, Sick_Doctor_Name as �ܴ�ҽ�� from T_IN_Patient where id not in(select distinct patient_id from t_Doc_Grade where patient_id is not null)  and die_time is not null ";
            if (this.cboxSick.Text == "ȫԺ")
            {
                querySQL += "and to_char(die_time,'yyyy-MM') like '" + this.dateTimePickerIN_OUT_time.Text + "%'";
            }
            else
            {
                querySQL += "and SECTION_NAME='" + this.cboxSick.Text + "' and to_char(die_time,'yyyy-MM') like '" + this.dateTimePickerIN_OUT_time.Text + "%'";
            }

            dt = App.GetDataSet(querySQL).Tables[0];//������Դ��ֵ

            Random rd = new Random();
            #region ���Ч��
            //string where = "";
            //List<int> iList = new List<int>();
            //bool b = true;
            //if (dt.Rows.Count > Convert.ToInt32(this.cboxRand.Text))
            //{
            //    do
            //    {
            //        int numRand = rd.Next(0, dt.Rows.Count - 1);
            //        b = true;
            //        foreach (int var in iList)
            //        {
            //            if (numRand == var)
            //            {
            //                b = false;
            //                break;
            //            }
            //        }
            //        if (b)
            //        {
            //            iList.Add(numRand);
            //        }
            //    }
            //    while (iList.Count < Convert.ToInt32(this.cboxRand.Text));

            //    for (int i = 0; i < iList.Count; i++)
            //    {
            //        if (where == "")
            //        {
            //            where = dt.Rows[Convert.ToInt32(iList[i])]["ID"].ToString();
            //        }
            //        else
            //        {
            //            where = where + "," + dt.Rows[Convert.ToInt32(iList[i])]["ID"].ToString();
            //        }
            //    }
            //    if (where != "")
            //    {
            //        where = "id in (" + where + ")";
            //    }
            //}
            #endregion
            /*���˼· ������Ҫ�����������ȡ����ѭ�����ٴ� ѭ��һ�β���һ�������
             *Ȼ��ѭ���жϲ����������������û���ظ����� ����оͰ����Ƴ��������²���
             * ֱ��û���ظ���Ϊֹ��Ȼ���һ���趨��ֵidlist��ֵ idlist��ֵ�����������
             * ��ÿ�м�¼��IDֵ
             */
            List<int> randSum = new List<int>();
            randSum.Clear();
            string idlist = "";//����ÿ�м�¼��ID

            int dtrowCount = dt.Rows.Count;//��ѯ������
            int randm = Convert.ToInt32(this.cboxRand.Text);//��Ҫ�����ѯ������
            if (dtrowCount < randm)//�����ѯ������С�������ѯ��ѯ����
            {
                randm = dtrowCount;//��� ��Ҫ�����ѯ������ ���� ��ѯ�����ܵ����� �͸���Ҫ�����ѯ��������ֵ�ɲ�ѯ�ܵ�����
                //��һ��ѭ���������ȡ����
                for (int i = 0; i < randm; i++)
                {
                    if (dt.Rows.Count <= 0)
                    {
                        App.Msg("δ���ҵ�����");
                        c1FlexGrid1.Clear();
                        return;
                    }
                    //����һ�����������datatable����Ҫһ�£������10�� ��Ҫ����0��10֮����������
                    int numSum = rd.Next(0, dt.Rows.Count);
                    //ѭ����������������Ԫ�أ��������ͬ�ľ���ѭ��һ��
                    for (int j = 0; j < randSum.Count; j++)
                    {
                        if (randSum[j] == numSum)
                        {
                            //numSum = rd.Next(0, dt.Rows.Count - 1);

                            //�������ͬ�ľͰ����Ƴ�
                            randSum.RemoveAt(j);
                            i--;//�Ƴ���һ��Ԫ�ؾ�Ҫ��i--��ѭ��һ��
                        }
                    }
                    //ÿ�ΰ�ѭ������������ӵ�һ����������
                    randSum.Add(numSum);
                    //������ϲ�Ϊ��idlist��ֵ����ID���
                    if (idlist == "")
                    {
                        idlist = dt.Rows[numSum]["���"].ToString();
                    }
                    else
                    {
                        idlist = idlist + "," + dt.Rows[numSum]["���"].ToString();
                    }
                }
            }
            else
            {
                //��һ��ѭ���������ȡ����
                for (int i = 0; i < randm; i++)
                {
                    if (dt.Rows.Count <= 0)
                    {
                        App.Msg("δ���ҵ�����");
                        c1FlexGrid1.Clear();
                        return;
                    }
                    //����һ�����������datatable����Ҫһ�£������10�� ��Ҫ����0��10֮����������
                    int numSum = rd.Next(0, dt.Rows.Count);
                    //ѭ����������������Ԫ�أ��������ͬ�ľ���ѭ��һ��
                    for (int j = 0; j < randSum.Count; j++)
                    {
                        if (randSum[j] == numSum)
                        {
                            //numSum = rd.Next(0, dt.Rows.Count - 1);

                            //�������ͬ�ľͰ����Ƴ�
                            randSum.RemoveAt(j);
                            i--;//�Ƴ���һ��Ԫ�ؾ�Ҫ��i--��ѭ��һ��
                        }
                    }
                    //ÿ�ΰ�ѭ������������ӵ�һ����������
                    randSum.Add(numSum);
                    //������ϲ�Ϊ��idlist��ֵ����ID���
                    if (idlist == "")
                    {
                        idlist = dt.Rows[numSum]["���"].ToString();
                    }
                    else
                    {
                        idlist = idlist + "," + dt.Rows[numSum]["���"].ToString();
                    }
                }
            }
            //���idlist��Ϊ�վ͸�idlist��ֵ
            if (idlist != "")
            {
                idlist = "��� in (" + idlist + ")";
            }
            //Dataview�Ǳ�ʾ��������ɸѡ���������༭�͵����� System.Data.DataTable �Ŀɰ����ݵ��Զ�����ͼ��
            dv = dt.DefaultView;

            //�ٽ���ɸѡ
            dv.RowFilter = idlist;

            dt2 = dv.ToTable();
            DataColumn d = new DataColumn("��ֵ", typeof(double));
            dt2.Columns.Add(d);
            this.c1FlexGrid1.DataSource = dt2;//������Դ
            c1FlexGrid1.Rows[0].TextAlign = TextAlignEnum.CenterCenter;
            //�ı�c1�еĳ���
            for (int i = 1; i < c1FlexGrid1.Cols.Count; i++)
            {
                c1FlexGrid1.Cols[i].Width = 123;
                c1FlexGrid1.Cols[i].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            }
        }
        /// <summary>
        /// ������ֵ������
        /// </summary>
        /// <param name="values">100-�۷�ֵ</param>
        public void SetFenzhi(double values)
        {
            c1FlexGrid1[c1FlexGrid1.RowSel, 8] = values;
        }


        int setNum = 1;
        /// <summary>
        /// ����ʱ�����¼�
        /// </summary>
        /// <param name="row"></param>
        public void AddRow(Row row)
        {
            if (dt2 != null)
            {
                DataRow dr = dt2.NewRow();//new ��
                //drview = dv.AddNew();
                if (dr.Table.Columns.Count > 0)
                {
                    //��dataRow��ֵ
                    dr[0] = row[2].ToString();
                    dr[1] = row[3].ToString();
                    dr[2] = row[4].ToString();
                    dr[3] = row[5].ToString();
                    dr[4] = Convert.ToDateTime(row[6].ToString());
                    if (row[7].ToString() == "")
                    {
                        dr[5] = DBNull.Value;
                    }
                    else
                    {
                        dr[5] = Convert.ToDateTime(row[7].ToString());
                    }
                    dr[6] = row[8].ToString();

                    //dr[7] = row[9].ToString();
                    //drview["ID"] = row[2].ToString();
                    //drview["����"] = row[3].ToString();
                    //drview["סԺ��"] = row[4].ToString();
                    //drview["��������"] = row[5].ToString();
                    //drview["סԺ����"] = Convert.ToDateTime(row[6].ToString());
                    //if (row[7].ToString() == "")
                    //{
                    //    drview["��Ժ����"] = DBNull.Value;
                    //}
                    //else
                    //{
                    //    drview["��Ժ����"] = Convert.ToDateTime(row[7].ToString());
                    //}
                    //drview["�ܴ�ҽ��"] = row[8].ToString();
                    this.dt2.Rows.Add(dr);
                    this.c1FlexGrid1.DataSource = dt2;
                }
                //else
                //{
                //    //Ϊ�˲�����ÿ��ѭ����Ҫִ������ֻ������ִ��һ��
                //    if (setNum == 1)
                //    {
                //        App.Msg("����֮ǰԭ���ݽṹҪ����");
                //        setNum++;
                //    }
                //}
            }
            else
            {
                if (setNum == 1)
                {
                    App.Msg("����֮ǰԭ���ݽṹҪ����");
                    setNum++;
                }
            }

        }
        int oldRow = 0;
        /// <summary>
        /// ����c1FlexGrid1�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_Click(object sender, EventArgs e)
        {
            selRow = 1;
            c1FlexGrid1.AllowEditing = false;


            int rows = this.c1FlexGrid1.RowSel;//����ѡ�е��к� 
            if (rows > 0)
            {
                if (oldRow == rows)
                {
                    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                }
                else
                {
                    //�������ͷ��
                    if (rows > 0)
                    {
                        //�͸ı䱳��ɫ
                        this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                    }
                    if (oldRow > 0 && dt2.Rows.Count >= oldRow)
                    {
                        //������һ�ε�������л�ԭ
                        this.c1FlexGrid1.Rows[oldRow].StyleNew.BackColor = c1FlexGrid1.BackColor;
                    }
                    //else
                    //{
                    //    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = c1FlexGrid1.BackColor;
                    //}
                }
            }
            //����һ�ε��кŸ�ֵ
            oldRow = rows;
        }
        List<string> itmeList = new List<string>();
        /// <summary>
        ///  ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            //ִ��Ҫ���������sql���
            if (App.ExecuteBatch(itmeList.ToArray()) > 0)
            {
                App.Msg("����ɹ�");
                //ÿ�α���һ�ζ�Ҫ���һ��
                itmeList.Clear();
            }
            else
            {
                App.Msg("����ʧ��");
                itmeList.Clear();
            }

        }
        /// <summary>
        /// ��������list������Ҫ�����������
        /// </summary>
        /// <param name="list"></param>
        public void addPingFen(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                itmeList.Add(list[i]);
            }
        }
        /// <summary>
        /// ������ѯ��ʷ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        DataTable history;
        public void button5_Click(object sender, EventArgs e)
        {
            
            //��ʷ�����ѯʱ��������ʱ����ͬ �ָ��飬���һ����¼
            string selectSQL = "select to_char(grade_time,'yyyy-MM-dd HH24:mi:ss') as ����ʱ��,t.SECTION_NAME as ���ֿ���  " +
                               " from t_doc_grade g inner join t_in_patient t on g.patient_id=t.id where "+
                               " to_char(grade_time,'yyyy-MM') like '" + dateTimePicker2.Text + "%' "+
                               " {0}  group by grade_time,t.SECTION_NAME "+
                               " order by grade_time desc,t.SECTION_NAME ";

            if (this.cboxSickname.Text == "ҽ���" || this.cboxSickname.Text == "�ʿؿ�")
            {
                selectSQL = string.Format(selectSQL, "and OPERATE_SECTION='" + this.cboxSickname.Text + "'");
                selectSQL = selectSQL.Replace("t.SECTION_NAME", "OPERATE_SECTION");
            }
            else if (this.cboxSickname.Text == "ȫԺ")
            {
                selectSQL = string.Format(selectSQL, "");
            }
            else
            {
                selectSQL = string.Format(selectSQL, "and t.SECTION_NAME='" + this.cboxSickname.Text + "'");
            }
            
            history = App.GetDataSet(selectSQL).Tables[0];
            //DataColumn dc = new DataColumn("����", typeof(string));
            //dc.DefaultValue = "ȫԺ";
            //history.Columns.Add(dc);
            ucC1FlexGrid1.fg.DataSource = history;
            this.ucC1FlexGrid1.fg.Cols["����ʱ��"].Width = 400;
            this.ucC1FlexGrid1.fg.Cols["���ֿ���"].Width = 400;
        }

        //���û��Ƿ�����UCC1�ؼ��������� �͸�����ֵΪ1
        int rowselect = 0;
        int rowselectold = 0;
        /// <summary>
        /// ������ʷ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            rowselect = 1;
            int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к�
            if (rows > 0)
            {
                if (rowselectold == rows)
                {
                    this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                }
                else
                {
                    //�������ͷ��
                    if (rows > 0)
                    {
                        //�͸ı䱳��ɫ
                        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                    }
                    if (rowselectold > 0 && history.Rows.Count >= rowselect)
                    {
                        //������һ�ε�������л�ԭ
                        this.ucC1FlexGrid1.fg.Rows[rowselectold].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    }
                }
            }
            //����һ�ε��кŸ�ֵ
            rowselectold = rows;
        }
        private void frmMainGradeRepart_Load(object sender, EventArgs e)
        {
            try
            {                                  
                SetSickName();
                
                             
                ucC1FlexGrid1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
                ucC1FlexGrid1.fg.DoubleClick += new EventHandler(ucC1FlexGrid1_DoubleClick);
                ucC1FlexGrid1.fg.MouseClick += new MouseEventHandler(ucC1FlexGrid1_MouseClick);
                //btnQuery_Click(sender, e);
                ucC1FlexGrid1.fg.ContextMenuStrip = contextMenuStrip1;
            }
            catch
            {
            }
        }
        private void btntransitorily_Save_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// ˫�����ɱ���ʱ
        /// </summary>
        int oldRow2 = 0;
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            c1FlexGrid1.AllowEditing = false;

            int rows = this.c1FlexGrid1.RowSel;//����ѡ�е��к�
            if (rows > 0)
            {
                if (oldRow2 == rows)
                {
                    this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                }
                else
                {
                    //�������ͷ��
                    if (rows > 0)
                    {
                        //�͸ı䱳��ɫ
                        this.c1FlexGrid1.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                    }
                    if (oldRow2 > 0 && dt2.Rows.Count >= oldRow)
                    {
                        //������һ�ε�������л�ԭ
                        this.c1FlexGrid1.Rows[oldRow2].StyleNew.BackColor = c1FlexGrid1.BackColor;
                    }
                }
                try
                {
                    string id = this.c1FlexGrid1[c1FlexGrid1.RowSel, "���"].ToString().ToString();
                    if (id != null && id != "")
                    {
                        string sql = "select * from t_in_patient t where t.id='" + id + "'";
                        DataSet ds1 = App.GetDataSet(sql);
                        if (ds1 != null)
                        {
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                                InPatientInfo patientInfo = new InPatientInfo();

                                patientInfo.Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["id"]);
                                patientInfo.Patient_Name = ds1.Tables[0].Rows[0]["Patient_Name"].ToString();
                                //if (ds1.Tables[0].Rows[0]["Gender_Code"].ToString().Equals("��"))
                                //{
                                patientInfo.Gender_Code = ds1.Tables[0].Rows[0]["Gender_Code"].ToString();
                                //}
                                //else
                                //{
                                //    patientInfo.Gender_Code = "1";
                                //}
                                patientInfo.Marrige_State = ds1.Tables[0].Rows[0]["marriage_state"].ToString();
                                patientInfo.Medicare_no = ds1.Tables[0].Rows[0]["Medicare_no"].ToString();
                                patientInfo.Home_address = ds1.Tables[0].Rows[0]["Home_address"].ToString();
                                patientInfo.HomePostal_code = ds1.Tables[0].Rows[0]["HomePostal_code"].ToString();
                                patientInfo.Home_phone = ds1.Tables[0].Rows[0]["Home_phone"].ToString();
                                patientInfo.Office = ds1.Tables[0].Rows[0]["Office"].ToString();
                                patientInfo.Office_address = ds1.Tables[0].Rows[0]["Office_Address"].ToString();
                                patientInfo.Office_phone = ds1.Tables[0].Rows[0]["Office_phone"].ToString();
                                patientInfo.Relation = ds1.Tables[0].Rows[0]["Relation"].ToString();
                                patientInfo.Relation_address = ds1.Tables[0].Rows[0]["Relation_address"].ToString();
                                patientInfo.Relation_phone = ds1.Tables[0].Rows[0]["Relation_phone"].ToString();
                                patientInfo.RelationPos_code = ds1.Tables[0].Rows[0]["RelationPos_code"].ToString();
                                patientInfo.OfficePos_code = ds1.Tables[0].Rows[0]["OfficePos_code"].ToString();
                                if (ds1.Tables[0].Rows[0]["InHospital_Count"].ToString() != "")
                                    patientInfo.InHospital_count = Convert.ToInt32(ds1.Tables[0].Rows[0]["InHospital_Count"].ToString());
                                patientInfo.Cert_Id = ds1.Tables[0].Rows[0]["cert_id"].ToString();
                                patientInfo.Pay_Manager = ds1.Tables[0].Rows[0]["pay_manner"].ToString();
                                patientInfo.In_Circs = ds1.Tables[0].Rows[0]["IN_Circs"].ToString();
                                patientInfo.Natiye_place = ds1.Tables[0].Rows[0]["native_place"].ToString();
                                patientInfo.Birth_place = ds1.Tables[0].Rows[0]["Birth_place"].ToString();
                                patientInfo.Folk_code = ds1.Tables[0].Rows[0]["Folk_code"].ToString();

                                patientInfo.Birthday = ds1.Tables[0].Rows[0]["Birthday"].ToString();
                                patientInfo.PId = ds1.Tables[0].Rows[0]["PId"].ToString();
                                patientInfo.Insection_Id = Convert.ToInt32(ds1.Tables[0].Rows[0]["insection_id"]);
                                patientInfo.Insection_Name = ds1.Tables[0].Rows[0]["insection_name"].ToString();
                                patientInfo.In_Area_Id = ds1.Tables[0].Rows[0]["in_area_id"].ToString();
                                patientInfo.In_Area_Name = ds1.Tables[0].Rows[0]["in_area_name"].ToString();
                                if (ds1.Tables[0].Rows[0]["Age"].ToString() != "")
                                    patientInfo.Age = ds1.Tables[0].Rows[0]["Age"].ToString();
                                else
                                {
                                    if (patientInfo.Age == "0")
                                    {
                                        patientInfo.Age = Convert.ToString(App.GetSystemTime().Year - Convert.ToDateTime(patientInfo.Birthday).Year);
                                        patientInfo.Age_unit = "��";
                                    }
                                }
                                //inpatient.Action_State = row["action_state"].ToString();
                                patientInfo.Sick_Doctor_Id = ds1.Tables[0].Rows[0]["sick_doctor_id"].ToString();
                                patientInfo.Sick_Doctor_Name = ds1.Tables[0].Rows[0]["sick_doctor_name"].ToString();
                                if (ds1.Tables[0].Rows[0]["Sick_Area_Id"] != null)
                                    patientInfo.Sike_Area_Id = ds1.Tables[0].Rows[0]["Sick_Area_Id"].ToString();
                                patientInfo.Sick_Area_Name = ds1.Tables[0].Rows[0]["sick_area_name"].ToString();
                                if (ds1.Tables[0].Rows[0]["section_id"].ToString() != "")
                                    patientInfo.Section_Id = Int32.Parse(ds1.Tables[0].Rows[0]["section_id"].ToString());
                                patientInfo.Section_Name = ds1.Tables[0].Rows[0]["section_name"].ToString();
                                if (ds1.Tables[0].Rows[0]["in_time"] != null)
                                    patientInfo.In_Time = DateTime.Parse(ds1.Tables[0].Rows[0]["in_time"].ToString());
                                patientInfo.State = ds1.Tables[0].Rows[0]["state"].ToString();
                                if (ds1.Tables[0].Rows[0]["sick_bed_id"].ToString() != "")
                                    patientInfo.Sick_Bed_Id = Int32.Parse(ds1.Tables[0].Rows[0]["sick_bed_id"].ToString());
                                patientInfo.Sick_Bed_Name = ds1.Tables[0].Rows[0]["sick_bed_no"].ToString();
                                patientInfo.Age_unit = ds1.Tables[0].Rows[0]["age_unit"].ToString();
                                patientInfo.Sick_Degree = Convert.ToString(ds1.Tables[0].Rows[0]["Sick_Degree"]);
                                if (ds1.Tables[0].Rows[0]["Die_flag"].ToString() != "")
                                    patientInfo.Die_flag = Convert.ToInt32(ds1.Tables[0].Rows[0]["Die_flag"]);
                                patientInfo.Card_Id = ds1.Tables[0].Rows[0]["card_id"].ToString();
                                patientInfo.Nurse_Level = ds1.Tables[0].Rows[0]["nurse_level"].ToString();
                                patientInfo.Career = ds1.Tables[0].Rows[0]["Career"].ToString();//ְҵ
                                patientInfo.Out_Id = ds1.Tables[0].Rows[0]["out_id"].ToString();//�����
                                patientInfo.Relation_name = ds1.Tables[0].Rows[0]["Relation_Name"].ToString();//��ϵ������


                                ucDoctorOperater fq = new ucDoctorOperater(patientInfo); //new ucDoctorOperater(patientInfo, false, patientInfo.Id);
                                App.UsControlStyle(fq);
                                App.AddNewBusUcControl(fq, "��������");
                                frmGrade fg = new frmGrade(this);
                                fg.Show();
                                fg.TopMost = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }


            }
            //����һ�ε��кŸ�ֵ
            oldRow2 = rows;
        }
        /// <summary>
        /// ˫����ʷ ����
        /// </summary>
        int hostoryRow = 0;
        private void ucC1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            ucC1FlexGrid1.fg.AllowEditing = false;
            int rows = this.ucC1FlexGrid1.fg.RowSel;//����ѡ�е��к�
            if (rows > 0)
            {
                if (hostoryRow == rows)
                {
                    this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                }
                else
                {
                    //�������ͷ��
                    if (rows > 0)
                    {
                        //�͸ı䱳��ɫ
                        this.ucC1FlexGrid1.fg.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#9BB9ED");
                    }
                    if (hostoryRow > 0 && history.Rows.Count >= hostoryRow)
                    {
                        //������һ�ε�������л�ԭ
                        this.ucC1FlexGrid1.fg.Rows[hostoryRow].StyleNew.BackColor = ucC1FlexGrid1.fg.BackColor;
                    }
                }
            }
            //����һ�ε��кŸ�ֵ
            hostoryRow = rows;
        }
        /// <summary>
        /// ���ɱ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = c1FlexGrid1.PointToClient(Cursor.Position);
                if (c1FlexGrid1.HitTest(e.X, e.Y).Row >= 1)//���Ƿ�����Ϣ������
                {
                    ctmnspDelete.Show(c1FlexGrid1, p);
                }
            }
        }
        /// <summary>
        /// ��ʷ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucC1FlexGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = ucC1FlexGrid1.fg.PointToClient(Cursor.Position);
                if (ucC1FlexGrid1.fg.HitTest(e.X, e.Y).Row >= 1)
                {
                    contextMenuStrip1.Show(ucC1FlexGrid1, p);
                }
            }
        }
    }
}
