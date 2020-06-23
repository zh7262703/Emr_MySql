using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmSection : DevComponents.DotNetBar.Office2007Form
    {
        private string ids="";         //存储科室号
        private string names="";       //存储科室名
        private int IsNormalClose = 0;
        
        public frmSection()    
        {
            InitializeComponent();
            
            
        }
        public frmSection(int SecOrSick)    //0科室,1病区
        {
            InitializeComponent();
           
            if (SecOrSick == 0)
            {
                this.Text = "科室选择";
                groupBox1.Text = "科室列表";
                SectionLoad();
            }
            else
            {
                this.Text = "病区选择";
                groupBox1.Text = "病区列表";
                SickAreaLoad();
            }

        }
        /// <summary>
        /// 科室加载
        /// </summary>
        private void SectionLoad()
        {

            string sqlSection = "select sid,section_name from t_sectioninfo where enable_flag='Y'  and is_follow_visit='Y'";
            DataSet dsTemp = App.GetDataSet(sqlSection);
            if (dsTemp != null)
            {
                clbSection.Items.Add("0:全院");
                DataTable dt = dsTemp.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    Class_Sections section = new Class_Sections();
                    section.Sid = Convert.ToInt32(row["sid"]);
                    section.Section_Name = row["section_name"].ToString();
                    clbSection.Items.Add(section.Sid + ":" + section.Section_Name);
                }
            }
        }
        /// <summary>
        /// 病区加载
        /// </summary>
        public void SickAreaLoad()
        {
            string sqlSickArea = "select said,sick_area_name from T_SICKAREAINFO where enable_flag='Y'";
            DataSet dsTemp = App.GetDataSet(sqlSickArea);
            if (dsTemp != null)
            {
                if (dsTemp.Tables[0].Rows.Count != 0)
                {
                    clbSection.Items.Add("0:全区");
                    foreach(DataRow Row in dsTemp.Tables[0].Rows)
                    {
                        class_SickAreaInfo sickArea = new class_SickAreaInfo();
                        sickArea.Said = Row["said"].ToString();
                        sickArea.Sick_area_name = Row["sick_area_name"].ToString();
                        clbSection.Items.Add(sickArea.Said + ":" + sickArea.Sick_area_name);
                    }
                }
            }

        }
        /// <summary>
        /// 根据Ids设定被选中项
        /// </summary>
        /// <param name="Ids"></param>
        public void SetSelected(string Ids)
        {
            if (Ids != "")
            {
                string[] id = Ids.Split(',');                
                if (Ids == "0")
                {
                    clbSection.SetItemChecked(0, true);
                }
                else
                {
                    for (int i = 0; i < id.Length; i++)
                    {
                        for (int j = 0; j < clbSection.Items.Count; j++)
                        {
                            string myId = clbSection.Items[j].ToString().Substring(0, clbSection.Items[j].ToString().IndexOf(":"));
                            if (id[i] == myId)
                            {
                                clbSection.SetItemChecked(j, true);
                                break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 返回科室/病区ids
        /// </summary>
        /// <returns></returns>
        public string GetIds()
        {
            return ids;
        }
        /// <summary>
        /// 返回科室/病区名称
        /// </summary>
        /// <returns></returns>
        public string GetNames()
        {
            return names;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IsNormalClose = 1;
            ids = "";
            names = "";
            for (int i = 0; i < clbSection.Items.Count; i++)
            {
                if (clbSection.GetItemText(clbSection.Items[i]) == "0:全院" && clbSection.GetItemChecked(i))  //如果全院被选中，则把文书SID直接设为0
                {
                    ids = "0";
                    names = "全院";
                    break;
                }
                if (clbSection.GetItemChecked(i))
                {
                    int pos = clbSection.GetItemText(clbSection.Items[i]).IndexOf(":");
                    string id = clbSection.GetItemText(clbSection.Items[i]).Substring(0, pos);
                    string name = clbSection.GetItemText(clbSection.Items[i]).Substring(pos + 1);
                    if (ids == "")
                    {
                        ids = id;
                        names = name;
                    }
                    else
                    {
                        ids +=  "," + id;
                        names += "," + name;
                    }
                }
            }
            this.Close();
        }

        private void frmSection_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (IsNormalClose == 0)
            {
                ids = "";
                names = "";
            }
        }
    }
}