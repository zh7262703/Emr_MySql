using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    /// <summary>
    /// ��Ժ������ѯ
    /// </summary>
    /// ���� ��ΰ
    /// ʱ�� 2010��9��14��
    public partial class UserfrmQueryLevy : UserControl
    {
        public UserfrmQueryLevy()
        {
            try
            {
                InitializeComponent();
                App.UsControlStyle(this);
                //try
                //{
                    LoadCard();
                //}
                //catch (Exception exe)
                //{
                //    App.MsgErr(exe.Message);
                //}
            }
            catch (Exception exe)
            {
                App.MsgErr(exe.Message);
            }
        }

        private void LoadCard()
        {
            try
            {
                this.panel1.Controls.Clear();
                //this.Controls.Clear();
                dt = App.GetDataSet(sql).Tables[0] as DataTable;
                Brush brush = new SolidBrush(Color.Green);//�����Ƶ��ı���ɫ������
                StringFormat stringFormat = new StringFormat();//�����ı����� ���ж��䷽ʽ
                stringFormat.Alignment = StringAlignment.Center;//��ֱ���ϵ��ı����䷽ʽ
                stringFormat.LineAlignment = StringAlignment.Center;//����ˮƽ�����ı����䷽ʽ
                stringFormat.Trimming = StringTrimming.EllipsisCharacter;//��ʾ������@�� StringFormat ������L�u�����ֳ��^���þ���߅���r�޼�ԓ���� ������....

                Image image = global::Base_Function.Resource.����ѡ��С��ͼ��_δѡ��;
                int howHeight = 10;//��ʼ��PictureBox �߶ȵĴ�С
                int howWeight = 15;//��ʼ��PictureBox ��ȵĴ�С


                //��Ժ����
                string sql_into_area = "select a.SICK_AREA_ID from t_In_Patient a where (select count(id) from t_inhospital_action b where b.patient_id=a.id)>0 and to_char(a.in_time,'yyyy-MM-dd')=to_char(sysdate,'yyyy-MM-dd')";

                //��Ժ����
                string sql_at_area = "select distinct a.id,a.SICK_AREA_ID from t_In_Patient a inner join t_inhospital_action b on a.id=b.patient_id where b.ACTION_TYPE<>'����' and b.Next_id=0 and b.ACTION_STATE<>3 ";

                //��λ��
                string sql_bed = "select said from t_sickbedinfo";

                //I��x�� Σ��x�� �أ�x��
                string sql_nurse_level = "select t.sick_area_id,td.name from t_in_patient t inner join (select * from t_data_code where type in (53) and name in('һ������')) td on t.nurse_level=td.id  where  DOCUMENT_STATE is null ";//inner join t_inhospital_action b on t.id=b.patient_id where b.ACTION_TYPE<>'����' and b.Next_id=0 and b.ACTION_STATE<>3 ";
                string sql_sick_degree = "select t.sick_area_id,decode(t.sick_degree,'1','һ��','2','����','3','��Σ') name from t_in_patient t where  DOCUMENT_STATE is null ";//inner join t_inhospital_action b on t.id=b.patient_id where b.ACTION_TYPE<>'����' and b.Next_id=0 and b.ACTION_STATE<>3 ";

                

                Class_Table[] temtables = new Class_Table[5];
                temtables[0] = new Class_Table();
                temtables[0].Sql = sql_into_area;
                temtables[0].Tablename = "in";

                temtables[1] = new Class_Table();
                temtables[1].Sql = sql_at_area;
                temtables[1].Tablename = "at";

                temtables[2] = new Class_Table();
                temtables[2].Sql = sql_bed;
                temtables[2].Tablename = "bed";

                temtables[3] = new Class_Table();
                temtables[3].Sql = sql_nurse_level;
                temtables[3].Tablename = "nurse";

                temtables[4] = new Class_Table();
                temtables[4].Sql = sql_sick_degree;
                temtables[4].Tablename = "sick";



                DataSet ds = App.GetDataSet(temtables);

                //dt�����ж����о��ж��ٸ�PictureBox ��һ��PictureBox����֮�󣬻��ڿ��+164�Ļ������ڳ����ڶ���������6���Ժ�ͻ���
                //�߶Ȼ���ÿ�� PictureBox �ĸ߶�֮�ϼ�120
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i != 0)
                    {
                        howWeight += 164;
                        if (howWeight > this.panel1.Width)
                        {
                            howHeight += 130;
                            howWeight = 25;
                        }
                    }
                    saID = dt.Rows[i]["said"].ToString();//�õ�ÿ������ID
                    //��ǰ��Ժ����
                    int at_Count = ds.Tables["at"].Select("sick_area_id=" + saID).Length;
                    //������Ժ����
                    int in_Count = ds.Tables["in"].Select("sick_area_id=" + saID).Length;
                    //���ճ�Ժ����
                    int out_Count = 0;
                    try
                    {
                        out_Count=ds.Tables["bed"].Select("said=" + saID).Length;
                    }
                    catch
                    { }

                    PictureBox pb = new PictureBox();
                    pb.MouseHover += new EventHandler(pb_MouseHover);//�����ͣ�¼�
                    pb.MouseLeave += new EventHandler(pb_MouseLeave);//����ƿ��¼�
                    pb.DoubleClick += new EventHandler(pb_DoubleClick);//���˫���¼�
                    pb.Size = new Size(image.Width + 15, image.Height + 35);//����PictureBox�Ĵ�С�������ͼƬ��5������
                    pb.SizeMode = PictureBoxSizeMode.StretchImage;//���������ʾPictureBox�����ͼ���������
                    //pb.BorderStyle = BorderStyle.FixedSingle;
                    pb.BackColor = Color.White;//����PictureBox�ı�����ɫ
                    pb.Tag = dt.Rows[i][0].ToString();//�벡��ID����
                    pb.Name = dt.Rows[i][2].ToString();//�벡�����ƹ���
                    Image im = new Bitmap(image.Width +8, image.Height +30);//��ʾҪ����PictureBox�еı���ͼƬ������ʼ����С
                    pb.Location = new Point(howWeight, howHeight);//�趨PictureBox �����������Ͻ�����ֵ
                    Graphics g = Graphics.FromImage(im);//����Ҫ��ͼƬ���滭����
                    g.Clear(Color.White);//���Ҫ�滭��ͼ�棬����ָ���ı���ɫ���
                    g.DrawImage(image, -4, -2, image.Width+10, image.Height+35);//Ҫ���Ƶ�ͼ�񣬲�ȷ����Ҫ���Ƶ����Ͻǵ�����
                    g.DrawString(dt.Rows[i]["section_name"].ToString(), Control.DefaultFont, brush, new RectangleF(0, 10, im.Width, 22), stringFormat);//�Ѳ���������ʾ�ڻ��������
                    g.DrawString(dt.Rows[i][2].ToString(), Control.DefaultFont, brush, new RectangleF(0, 23, im.Width, 22), stringFormat);//�Ѳ���������ʾ�ڻ��������

                    //g.DrawString(rows_nowHave.Length.ToString(), Control.DefaultFont, brush, new RectangleF(5, 38, 100, 22), stringFormat);//��ҽԺ�����˶�����ʾ�������
                    //g.DrawString("(" + rows_daySQl.Length.ToString() + ")", Control.DefaultFont, brush, new RectangleF(30, 38, 100, 22), stringFormat);//��ҽԺ������˶�����ʾ�������
                    //g.DrawString(rows_leaveSQl.Length.ToString(), Control.DefaultFont, brush, new RectangleF(18, 58, 100, 22), stringFormat);//��ҽԺ��Ժ���˶�����ʾ�������
                    g.DrawString(at_Count.ToString(), Control.DefaultFont, brush, new RectangleF(5, 43, 100, 22), stringFormat);//��ҽԺ�����˶�����ʾ�������
                    g.DrawString("(" + in_Count.ToString() + ")", Control.DefaultFont, brush, new RectangleF(30, 43, 100, 22), stringFormat);//��ҽԺ������˶�����ʾ�������
                    g.DrawString(out_Count.ToString(), Control.DefaultFont, brush, new RectangleF(18, 63, 100, 22), stringFormat);//��ҽԺ��Ժ���˶�����ʾ�������

                    //I��x��Σ��x���أ�x��
                    //һ������
                    int yjhl = ds.Tables["nurse"].Select("sick_area_id=" + saID + " and name='һ������'").Length;
                    //��Σ
                    int bw = ds.Tables["sick"].Select("sick_area_id=" + saID + " and name='��Σ'").Length;
                    //����
                    int bz = ds.Tables["sick"].Select("sick_area_id=" + saID + " and name='����'").Length;
                    Font font = new Font("����", 8);
                    g.DrawString("I(" + yjhl + ")Σ(" + bw + ")��(" + bz + ")", font, brush, new RectangleF(5, 83, 140, 22), stringFormat);

                    
                    
                    pb.Image = im;//ȷ��Ҫ��PictureBox������ʾ�ı���ͼ��
                    g.Dispose();//�ͷ���Դ
                    this.panel1.Controls.Add(pb);//��ӵ�panel1
                }
                brush.Dispose();//�ͷ���Դ
                GC.Collect();//��������
            }
            catch (Exception ex)
            {
                
            }
        }
        static string sql = @"select a.said,a.sick_area_code,a.sick_area_name,c.section_name from t_sickareainfo a 
                              inner join t_section_area b on a.said=b.said
                              inner join t_sectioninfo c on c.sid = b.sid
                              group  by a.shid,a.said,a.sick_area_code,a.sick_area_name,c.section_name 
                              order by a.shid,a.sick_area_code";

        DataTable dt;
        static string saID = "";

        private void frmQueryLevy_Load(object sender, EventArgs e)
        {
            try
            {
                #region ����û��ؼ�
                //int howWeight = 10;
                //int howHeight = 10;
                //for (int i = 0; i < 10; i++)
                //{
                //    //System.Windows.Forms.Control
                //    if (i != 0)
                //    {
                //        howWeight += 200;
                //        if (i % 5 == 0)
                //        {
                //            howWeight = 10;
                //            howHeight += 200;
                //        }
                //    }

                //    QueryPatient q=new QueryPatient();
                //    q.BorderStyle = BorderStyle.FixedSingle;
                //    q.Location = new Point(howWeight, howHeight);
                //    this.panel1.Controls.Add(q);
                //}
                //Pen p = new Pen(Color.Red);
                #endregion


            }
            catch (Exception ex)
            {

            }
        }
        public void pb_MouseHover(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            p.BackColor = ColorTranslator.FromHtml("#b2ecfe");
            p.Cursor = Cursors.Hand;
            //p.Image = global::Base_Function.Resource.����ѡ��С��ͼ��_ѡ��;
        }
        public void pb_MouseLeave(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            p.BackColor = Color.White;
            //p.Image = global::Base_Function.Resource.����ѡ��С��ͼ��_δѡ��;
        }
        public void pb_DoubleClick(object sender, EventArgs e)
        {
            PictureBox temppic = (sender as PictureBox);
            string id = temppic.Tag.ToString();
            QueryAllLevy allLevy = new QueryAllLevy(id);
            App.UsControlStyle(allLevy);
            App.AddNewBusUcControl(allLevy,"������Ϣ��");
        }
    }
}
