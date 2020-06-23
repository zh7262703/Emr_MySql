using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Xml;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_MANAGEMENT.SICKFILE
{
    public partial class frmTurnToDie_PatientInfo : DevComponents.DotNetBar.Office2007Form
    {
        DataTable dt = new DataTable();//数据表
        public static string beginTime = "";
        public static string endTime = "";
        public static string sectionName = "";
        public frmTurnToDie_PatientInfo()
        {
            InitializeComponent();
        }

        public frmTurnToDie_PatientInfo(DataTable dt, DataTable dt_inDiag)
        {
            InitializeComponent();
            App.ButtonStytle(this);
            flgView.AllowEditing = false;
            dt.Columns[0].ColumnName = "序号";
            dt.Columns[1].ColumnName = "科室";
            dt.Columns[2].ColumnName = "住院号";
            dt.Columns[3].ColumnName = "姓名";
            dt.Columns[4].ColumnName = "性别";
            dt.Columns[5].ColumnName = "年龄";
            dt.Columns[6].ColumnName = "家庭地址";
            dt.Columns[7].ColumnName = "监护人姓名";
            dt.Columns[8].ColumnName = "入院时间";
            dt.Columns[9].ColumnName = "入院诊断";
            dt.Columns[10].ColumnName = "死亡原因";
            dt.Columns[11].ColumnName = "死亡时间";
            dt.Columns[12].ColumnName = "接诊医生";

            flgView.DataSource = dt;

            flgView.Cols["birthday"].Visible = false;
            flgView.Cols["section_id"].Visible = false;
            flgView.Cols["sick_area_id"].Visible = false;
            flgView.Cols["sick_area_name"].Visible = false;
            string[] patientsId = new string[dt.Rows.Count];
            for (int i = 0; i < patientsId.Length; i++)
            {
                patientsId[i] = flgView[i + 1, "序号"].ToString(); //dt.Rows[i]["病人ID"].ToString();
            }
            //设置入院诊断
            SetInDiagnose(patientsId, dt_inDiag);
            //设置死亡原因及时间
            SetDieReason(patientsId);
        }

        /// <summary>
        /// 设置死亡原因
        /// 思路：读取死亡记录文书，遍历节点得到死亡原因
        /// </summary>
        public void SetDieReason(string[] patientsId)
        {
            string strPid = "";
            for (int i = 0; i < patientsId.Length; i++)
            {
                if (strPid == "")
                {
                    strPid += patientsId[i];
                }
                else
                {
                    strPid +=","+ patientsId[i];
                }

            }
            string sql_die = "select patient_id,patients_doc from t_patients_doc where textkind_id=138 and patient_id in(" + strPid + ")";
            DataSet ds = App.GetDataSet(sql_die);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string patientid = dt.Rows[i]["patient_id"].ToString();//病人ID
                    string patientDoc = dt.Rows[i]["patients_doc"].ToString();//文书内容
                    //创建XML对象，加载文书内容
                    XmlDocument xml = new XmlDocument();
                    xml.LoadXml(patientDoc);
                    XmlNodeList xmlListDiv = xml.GetElementsByTagName("div");
                    //遍历xml中的每个DIV标签，找到死亡原因
                    foreach (XmlNode divNode in xmlListDiv)
                    {
                        if (divNode.Attributes["title"].Value.ToString().Contains("死亡原因"))
                        {
                            string dieReason = "";//死亡原因
                            //遍历死亡原因节点，把死亡原因的内容拼接成字符串
                            foreach (XmlNode spanNode in divNode)
                            {
                                dieReason += spanNode.InnerText;
                            }
                            for (int j = 0; j < flgView.Rows.Count; j++)
                            {
                                if (flgView.Rows[j]["序号"].ToString()==patientid)
                                {
                                    flgView[j, "死亡原因"] = dieReason;
                                    break;
                                }
                            }
                        }
                    }
                    XmlNodeList xmlListInput = xml.GetElementsByTagName("input");
                    //找死亡时间
                    foreach (XmlNode inputNode in xmlListInput)
                    {
                        string dieTime = "";//死亡日期
                        if (inputNode.Attributes["id"].Value == "死亡日期")
                        {
                            foreach (XmlNode spanNode in inputNode)
                            {
                                dieTime += spanNode.InnerText;
                            }
                            for (int j = 0; j < flgView.Rows.Count; j++)
                            {
                                if (flgView.Rows[j]["序号"].ToString() == patientid)
                                {
                                    flgView[j, "死亡时间"] = dieTime;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 设置入院诊断
        /// 思路：1、从入院诊断表中找出patient_Id对应的诊断
        ///        如果有0条则显示空，1条直接显示诊断名
        ///        如果多于1条：(1)先找出所有诊断的创建时间，放到List<DateTime>中，排序按升序
        ///                     (2)循环找出DataRow[]中创建时间相同的诊断，并插入表格
        ///        
        /// </summary>
        /// <param name="patientsId">治愈病人ID集合</param>
        /// <param name="dt_allinDiag">所有入院诊断的表</param>
        public void SetInDiagnose(string[] patientsId, DataTable dt_allinDiag)
        {
            string diagNoseSort = "";
            for (int i = 0; i < patientsId.Length; i++)
            {
                DataRow[] dr_inDiag = dt_allinDiag.Select("patient_id=" + patientsId[i]);
                if (dr_inDiag.Length == 1)//只有一条入院诊断
                {
                    flgView[i + 1, "入院诊断"] = dr_inDiag[0]["diagnose_name"].ToString();
                }
                else if (dr_inDiag.Length == 0)//没有入院诊断
                {
                    flgView[i + 1, "入院诊断"] = "";
                }
                else //多条入院诊断，首先判断diagnose_sort的值，如果都为空，则按诊断的创建时间升序排列
                {
                    for (int j = 0; j < dr_inDiag.Length; j++)
                    {
                        diagNoseSort = dr_inDiag[j]["diagnose_sort"].ToString();
                        if (diagNoseSort == "1")//1：表示主诊断
                        {
                            flgView[i + 1, "入院诊断"] = dr_inDiag[j]["diagnose_sort"].ToString();
                        }
                    }
                    if (diagNoseSort == "")//按时间升序排，取最早创建的诊断
                    {
                        //把所有时间取出来保存到List中
                        List<DateTime> list = new List<DateTime>();
                        for (int j = 0; j < dr_inDiag.Length; j++)
                        {
                            list.Add(Convert.ToDateTime(dr_inDiag[j]["create_time"]));
                        }
                        list.Sort();
                        //找到时间最早的诊断，插入表格
                        for (int j = 0; j < dr_inDiag.Length; j++)
                        {
                            if (Convert.ToDateTime(dr_inDiag[j]["create_time"]) == list[0])
                            {
                                flgView[i + 1, "入院诊断"] = dr_inDiag[j]["diagnose_name"].ToString();
                            }
                        }

                    }
                }
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = CreateDataSetWidthFlexGrid(this.flgView);
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    frmTurnToDie_Print fp = new frmTurnToDie_Print(ds,frmTurnToDie_PatientInfo.sectionName,frmTurnToDie_PatientInfo.beginTime,frmTurnToDie_PatientInfo.endTime);
                    fp.Show();
                }
            }
        }

        /// <summary>
        /// 将表格转换成数据集
        /// </summary>
        /// <param name="fg"></param>
        /// <returns></returns>
        private static DataSet CreateDataSetWidthFlexGrid(C1FlexGrid fg)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            //创建列
            for (int i = 1; i < fg.Cols.Count; i++)
            {
                DataColumn dc;
                dc = new DataColumn(fg.Cols[i][0].ToString());
                dt.Columns.Add(dc);
            }

            //创建行，绑定数据
            for (int i = 1; i < fg.Rows.Count; i++)
            {
                DataRow dr = ds.Tables[0].NewRow();
                for (int j = 1; j < fg.Cols.Count; j++)
                {
                    dr[j-1] = fg.Rows[i][j].ToString();
                }
                ds.Tables[0].Rows.Add(dr);
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ds.Tables[0].Rows[i]["入院时间"] = ds.Tables[0].Rows[i]["入院时间"].ToString().Split(' ')[0];
                //ds.Tables[0].Rows[i]["出院时间"] = ds.Tables[0].Rows[i]["出院时间"].ToString().Split(' ')[0];
            }
            return ds;
        } 


    }
}