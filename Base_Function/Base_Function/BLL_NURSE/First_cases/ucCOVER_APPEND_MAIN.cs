using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Microsoft.ReportingServices.ReportRendering;

namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class ucCOVER_APPEND_MAIN : UserControl
    {

        ucCover_Append_In temp_in;
        ucCover_Append_OPER temp_oper;
        ucCover_Append_ANTIBIOTICS temp_antibiotics;
        ucCover_Append_GRAVE temp_grave;
        ucCover_Append_PS temp_ps;
        ucCover_Append_DROP temp_drop;

        /// <summary>
        /// ��ȡ������Ϣ����ʵ��
        /// </summary>
        private InPatientInfo inPatientInfo;

        public ucCOVER_APPEND_MAIN()
        {
            InitializeComponent();

            cboType.SelectedIndex = 0;
        }

        public ucCOVER_APPEND_MAIN(InPatientInfo inpatientinfo)
        {
            InitializeComponent();

            cboType.SelectedIndex = 0;
            inPatientInfo = inpatientinfo;

            IniCovers();
        }

        /// <summary>
        /// ˢ�¸�ҳ�б�
        /// </summary>
        private void IniCovers()
        {

            #region ��ʼ������
            Class_Table[] tables=new Class_Table[6]; //6
            
            //סԺ��ҳ
            tables[0] = new Class_Table();
            tables[0].Sql = "select id,CREATE_TIME from COVER_APPEND_IN where PATIENT_ID="+inPatientInfo.Id.ToString()+"";
            tables[0].Tablename = "APPEND_IN";

            //������ҳ
            tables[1] = new Class_Table();
            tables[1].Sql = "select id,CREATE_TIME from COVER_APPEND_OPER where PATIENT_ID="+inPatientInfo.Id.ToString()+"";
            tables[1].Tablename = "APPEND_OPER";

            //�����ظ�ҳ
            tables[2] = new Class_Table();
            tables[2].Sql = "select id,CREATE_TIME from COVER_APPEND_ANTIBIOTICS where PATIENT_ID=" + inPatientInfo.Id.ToString() + "";
            tables[2].Tablename = "APPEND_ANTIBIOTICS";

            //��֢ҽѧ��ҳ
            tables[3] = new Class_Table();
            tables[3].Sql = "select id,CREATE_TIME from COVER_APPEND_GRAVE where PATIENT_ID=" + inPatientInfo.Id.ToString() + "";
            tables[3].Tablename = "APPEND_GRAVE";

            //ѹ�����߸�ҳ
            tables[4] = new Class_Table();
            tables[4].Sql = "select id,create_time from COVER_APPEND_PS where patient_id=" + inPatientInfo.Id.ToString() + "";
            tables[4].Tablename = "APPEND_PS";

            //����/׹���Ȼ��߸�ҳ
            tables[5] = new Class_Table();
            tables[5].Sql = "select id,create_time from COVER_APPEND_DROP where patient_id=" + inPatientInfo.Id.ToString() + "";
            tables[5].Tablename = "APPEND_DROP";

            #endregion

            #region ��ʼ����ֵ
            DataSet ds = App.GetDataSet(tables);

            List<Cls_Cover_Append> Covers = new List<Cls_Cover_Append>();

            /*
             * ��ʼ��סԺ��ҳ����
             */
            for (int i = 0; i < ds.Tables["APPEND_IN"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_IN"].Rows[i]["id"].ToString();
                temp.Cover_name = "סԺ������ҳ��ҳ";
                temp.Cover_time = ds.Tables["APPEND_IN"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_IN";
                Covers.Add(temp);
            }


            /*
             * ��ʼ��������ҳ����
             */
            for (int i = 0; i < ds.Tables["APPEND_OPER"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_OPER"].Rows[i]["id"].ToString();
                temp.Cover_name = "�����������߸�ҳ";
                temp.Cover_time = ds.Tables["APPEND_OPER"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_OPER";
                Covers.Add(temp);
            }

            /*
            * ��ʼ��������ʹ�û��߸�ҳ����
            */
            for (int i = 0; i < ds.Tables["APPEND_ANTIBIOTICS"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_ANTIBIOTICS"].Rows[i]["id"].ToString();
                temp.Cover_name = "������ʹ�û��߸�ҳ";
                temp.Cover_time = ds.Tables["APPEND_ANTIBIOTICS"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_ANTIBIOTICS";
                Covers.Add(temp);
            }

            /*
            * ��ʼ����֢ҽѧ�Ʋ�����ҳ����
            */
            for (int i = 0; i < ds.Tables["APPEND_GRAVE"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_GRAVE"].Rows[i]["id"].ToString();
                temp.Cover_name = "��֢ҽѧ�Ʋ�����ҳ";
                temp.Cover_time = ds.Tables["APPEND_GRAVE"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_GRAVE";
                Covers.Add(temp);
            }

            /*
            * ��ʼ��ѹ�����߸�ҳ����
            */
            for (int i = 0; i < ds.Tables["APPEND_PS"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_PS"].Rows[i]["id"].ToString();
                temp.Cover_name = "ѹ�����߸�ҳ";
                temp.Cover_time = ds.Tables["APPEND_PS"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_PS";
                Covers.Add(temp);
            }

            /*
            * ��ʼ������/׹���Ȼ��߸�ҳ����
            */
            for (int i = 0; i < ds.Tables["APPEND_DROP"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_DROP"].Rows[i]["id"].ToString();
                temp.Cover_name = "����/׹���Ȼ��߸�ҳ";
                temp.Cover_time = ds.Tables["APPEND_DROP"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_DROP";
                Covers.Add(temp);
            }


            #endregion
            

            //��������ʾ���б���   
            dataGvAppendPages.DataSource = Covers;
            dataGvAppendPages.Columns["Id"].Visible = false;
            dataGvAppendPages.Columns["Cover_name"].HeaderText = "��ҳ����";
            dataGvAppendPages.Columns["Cover_time"].HeaderText = "����ʱ��";
            dataGvAppendPages.Columns["Cover_type"].Visible = false;
            dataGvAppendPages.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGvAppendPages.Refresh();                       
        }

        /// <summary>
        /// ɾ����ǰѡ�еĸ�ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("�Ƿ�ȷ��ɾ����ǰѡ�еĸ�ҳ��", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string[] sqls = new string[dataGvAppendPages.SelectedRows.Count];
                int index=0;
                foreach (DataGridViewRow gdvr in dataGvAppendPages.SelectedRows)
                {
                    string cover_id = gdvr.Cells["ID"].Value.ToString();//��ȡ����IDֵ                    
                    string cover_type = gdvr.Cells["Cover_type"].Value.ToString();//����
                    string sql = "delete from {0} where id={1}";
                    sqls[index] = string.Format(sql, cover_type, cover_id);
                    index++;
                }
                
                if (App.ExecuteBatch(sqls) > 0)
                {
                    App.Msg("ɾ���ɹ�!");
                }
                else
                {
                    App.Msg("ɾ��ʧ��!");
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("����ʧ��,ԭ��:" + ex.Message);
            }
            finally 
            {
                IniCovers();
                groupPanel7.Controls.Clear();
            }
        }

       

        /// <summary>
        /// ��Ӹ�ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAppendPage_Click(object sender, EventArgs e)
        {
            groupPanel7.Controls.Clear();
            if (cboType.SelectedIndex == 0)
            {
                if (GetSelectItemId("COVER_APPEND_IN", inPatientInfo.Id.ToString()) == false)
                {
                    //סԺ��ҳ
                    temp_in = new ucCover_Append_In(inPatientInfo.Id.ToString());
                    App.UsControlStyle(temp_in);
                    // temp1.Dock = DockStyle.Fill;
                    temp_in.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_in);
                }
                
            }
            else if (cboType.SelectedIndex == 1)
            {
                //������ҳ
                temp_oper = new ucCover_Append_OPER(inPatientInfo.Id.ToString());
                App.UsControlStyle(temp_oper);
                //temp1.Dock = DockStyle.Fill;
                temp_oper.BackColor = System.Drawing.Color.Transparent;
                groupPanel7.Controls.Add(temp_oper);
            }
            else if (cboType.SelectedIndex == 2)
            {//������ʹ�û��߸�ҳ
                //if (GetSelectItemId("COVER_APPEND_ANTIBIOTICS", inPatientInfo.Id.ToString()) == false)
                //{
                    temp_antibiotics = new ucCover_Append_ANTIBIOTICS(inPatientInfo.Id.ToString());
                    App.UsControlStyle(temp_antibiotics);
                    temp_antibiotics.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_antibiotics);
                //}
            }
            else if (cboType.SelectedIndex == 3)
            {//��֢ҽѧ�Ʋ�����ҳ
                temp_grave = new ucCover_Append_GRAVE(inPatientInfo.Id.ToString());
                App.UsControlStyle(temp_grave);
                temp_grave.BackColor = System.Drawing.Color.Transparent;
                groupPanel7.Controls.Add(temp_grave);
            }
            else if (cboType.SelectedIndex == 4)
            {//ѹ����׹��/������ҳ
                if (GetSelectItemId("COVER_APPEND_PS", inPatientInfo.Id.ToString()) == false)
                {
                    temp_ps = new ucCover_Append_PS(inPatientInfo.Id.ToString());
                    App.UsControlStyle(temp_ps);
                    temp_ps.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_ps);
                }
            }
            else if (cboType.SelectedIndex == 5)
            {//׹��/������ҳ
                if (GetSelectItemId("COVER_APPEND_DROP", inPatientInfo.Id.ToString()) == false)
                {
                    temp_drop = new ucCover_Append_DROP(inPatientInfo.Id.ToString());
                    App.UsControlStyle(temp_drop);
                    temp_drop.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_drop);
                }
            }

           
        }

        /// <summary>
        /// �Ƿ���������ҳ
        /// </summary>
        /// <param name="tablename">����</param>
        /// <param name="pid">����ID</param>
        /// <returns></returns>
        private bool GetSelectItemId(string tablename,string pid)
        {
            try
            {
                string Sql = "select count(*) as num from " + tablename + "  where PATIENT_ID ='" + pid + "'";
                string num = App.ReadSqlVal(Sql, 0, "num");
                if (num != "")
                {
                    if (num == "0")
                    {
                        //��
                        return false;
                    }
                    else
                    {
                        //��
                        App.Msg("�Ѿ�������ͬ�ĸ�ҳ,�����ظ����!");
                        return true;
                    }
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {
                return true;
            }
        }

        /// <summary>
        /// ���淽��
        /// </summary>
        public void SaveConver()
        {
            bool b = true;
            if (cboType.SelectedIndex == 0)
            {//סԺ��ҳ
                b=temp_in.SaveData();
                
            }
            else if (cboType.SelectedIndex == 1)
            {//�����������߸�ҳ
                b = temp_oper.SaveData();
            }
            else if (cboType.SelectedIndex == 2)
            {//������ʹ�û��߸�ҳ
                b = temp_antibiotics.SaveData();
            }
            else if (cboType.SelectedIndex == 3)
            {//��֢ҽѧ�Ʋ�����ҳ
                b = temp_grave.SaveData();
            }
            else if (cboType.SelectedIndex == 4)
            {//ѹ����׹��/������ҳ
                b = temp_ps.SaveData();
            }
            else if (cboType.SelectedIndex == 5)
            {//ѹ����׹��/������ҳ
                b = temp_drop.SaveData();
            }
            if (b==true)
            {
                IniCovers();
                groupPanel7.Controls.Clear();
            }
            
        }

        /// <summary>
        /// ˫���б���ʾ��Ӧ�ĸ�ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGvAppendPages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {


                string cover_id = dataGvAppendPages["Id", dataGvAppendPages.CurrentRow.Index].Value.ToString();
                string cover_type = dataGvAppendPages["Cover_type", dataGvAppendPages.CurrentRow.Index].Value.ToString();

                groupPanel7.Controls.Clear();
                if (cover_type == "COVER_APPEND_IN")
                {
                    //סԺ��ҳ
                    cboType.SelectedIndex = 0;
                    temp_in = new ucCover_Append_In(inPatientInfo.Id.ToString(), cover_id);
                    App.UsControlStyle(temp_in);
                    // temp1.Dock = DockStyle.Fill;
                    temp_in.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_in);
                }
                else if (cover_type == "COVER_APPEND_OPER")
                {
                    //������ҳ
                    cboType.SelectedIndex = 1;                   
                    temp_oper = new ucCover_Append_OPER(inPatientInfo.Id.ToString(), cover_id);
                    //App.UsControlStyle(temp_oper);
                    //temp1.Dock = DockStyle.Fill;
                    temp_oper.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_oper);
                }
                else if (cover_type == "COVER_APPEND_ANTIBIOTICS")
                {//������ʹ�û��߸�ҳ
                    cboType.SelectedIndex = 2;
                    temp_antibiotics = new ucCover_Append_ANTIBIOTICS(inPatientInfo.Id.ToString(), cover_id);
                    App.UsControlStyle(temp_antibiotics);
                    //temp1.Dock = DockStyle.Fill;
                    temp_antibiotics.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_antibiotics);
                }
                else if (cover_type == "COVER_APPEND_GRAVE")
                {//��֢ҽѧ�Ʋ�����ҳ 
                    cboType.SelectedIndex = 3;
                    temp_grave = new ucCover_Append_GRAVE(inPatientInfo.Id.ToString(), cover_id);
                    //App.UsControlStyle(temp_grave);
                    //temp1.Dock = DockStyle.Fill;
                    temp_grave.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_grave);
                }
                else if (cover_type == "COVER_APPEND_PS")
                {//ѹ����׹��/������ҳ 
                    cboType.SelectedIndex = 4;
                    temp_ps = new ucCover_Append_PS(inPatientInfo.Id.ToString(), cover_id);
                    //App.UsControlStyle(temp_grave);
                    //temp1.Dock = DockStyle.Fill;
                    temp_ps.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_ps);
                }
                else if (cover_type == "COVER_APPEND_DROP")
                {//ѹ����׹��/������ҳ 
                    cboType.SelectedIndex = 5;
                    temp_drop = new ucCover_Append_DROP(inPatientInfo.Id.ToString(), cover_id);
                    //App.UsControlStyle(temp_grave);
                    //temp1.Dock = DockStyle.Fill;
                    temp_drop.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_drop);
                }

            }
            catch
            {
                App.MsgWaring("����ѡ��Ҫ�����ļ�¼!");
            }
        }

        private void button1_Click(object sender, EventArgs e)  //�����ƶ�
        {
            int rowIndex = dataGvAppendPages.SelectedRows[0].Index;  //�õ���ǰѡ���е�����

            if (rowIndex == 0)
            {
                App.Msg("�Ѿ��ǵ�һ����!");
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < dataGvAppendPages.Columns.Count; i++)
            {
                list.Add(dataGvAppendPages.SelectedRows[0].Cells[i].Value.ToString());   //�ѵ�ǰѡ���е����ݴ���list������
            }

            for (int j = 0; j < dataGvAppendPages.Columns.Count; j++)
            {
                dataGvAppendPages.Rows[rowIndex].Cells[j].Value = dataGvAppendPages.Rows[rowIndex - 1].Cells[j].Value;
                dataGvAppendPages.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
            }
            dataGvAppendPages.Rows[rowIndex - 1].Selected = true;
            dataGvAppendPages.Rows[rowIndex].Selected = false;
        }

        private void button2_Click(object sender, EventArgs e)  //�����ƶ�
        {
            int rowIndex = dataGvAppendPages.SelectedRows[0].Index;  //�õ���ǰѡ���е�����

            if (rowIndex == dataGvAppendPages.Rows.Count - 1)
            {
                App.Msg("�Ѿ������һ����!");
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < dataGvAppendPages.Columns.Count; i++)
            {
                list.Add(dataGvAppendPages.SelectedRows[0].Cells[i].Value.ToString());   //�ѵ�ǰѡ���е����ݴ���list������
            }

            for (int j = 0; j < dataGvAppendPages.Columns.Count; j++)
            {
                dataGvAppendPages.Rows[rowIndex].Cells[j].Value = dataGvAppendPages.Rows[rowIndex + 1].Cells[j].Value;
                dataGvAppendPages.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
            }
            dataGvAppendPages.Rows[rowIndex + 1].Selected = true;
            dataGvAppendPages.Rows[rowIndex].Selected = false;
        }


    }

    /// <summary>
    /// ��ҳ����
    /// </summary>
    public class Cls_Cover_Append
    {
        /// <summary>
        /// ��ҳ����
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ��ҳ����
        /// </summary>
        private string cover_name;
        public string Cover_name
        {
            get { return cover_name; }
            set { cover_name = value; }
        }

        /// <summary>
        /// ��ҳ����ʱ��
        /// </summary>
        private string cover_time;
        public string Cover_time
        {
            get { return cover_time; }
            set { cover_time = value; }
        }

        /// <summary>
        /// ��ҳ����
        /// </summary>
        private string cover_type;
        public string Cover_type
        {
            get { return cover_type; }
            set { cover_type = value; }
        }

    }


}
