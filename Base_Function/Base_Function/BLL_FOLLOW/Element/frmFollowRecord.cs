using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using Base_Function.MODEL;

namespace Base_Function.BLL_FOLLOW.Element
{
    public partial class frmFollowRecord : DevComponents.DotNetBar.Office2007Form
    {
        private string pid="";      //保存病人ID
        private string sid = "";    //保存方案ID
        Class_Follow_Patient[] myRec; //保存记录信息

        Class_FollowInfo[] myInfo;
        
        DataGridViewRow myRow;
        public frmFollowRecord(string id1, string id2, DataGridViewRow row)
        {
            pid = id1;
            sid = id2;
            myRow = row;
            
            
            InitializeComponent();
            Procedure();
            DataBind();
            DetailDataBind(id1,id2);            
            //ucPatientInfo1.RefleshForm(id1);

        }

        public frmFollowRecord(string id1, string id2,int td)
        {
            pid = id1;
            sid = id2;
            
            InitializeComponent();
            //Procedure();
            DataBind();
            DetailDataBind(id1, id2);

            //ucPatientInfo1.RefleshForm(id1);

        }
        /// <summary>
        /// 绑定方案总览表
        /// </summary>
        public void DataBind()
        {
            string temp = "select a.solution_id 随访方案号,b.follow_name 随访方案,(select min(actual_time) from T_FOLLOW_RECORD where patient_id=a.patient_id and solution_id=a.solution_id and isfinished=1 ) 初次随访时间,(select max(actual_time) from T_FOLLOW_RECORD where patient_id=a.patient_id and solution_id=a.solution_id and isfinished=1 ) 末次随访时间,(select count(*) from T_FOLLOW_RECORD where patient_id=a.patient_id and solution_id=a.solution_id and isfinished=1) 随访次数,(select des from T_FOLLOW_RECORD t join T_FOLLOW_STATE s on t.state_id=s.id where t.id=a.id and not exists (select 1 from T_FOLLOW_RECORD where id=t.id and requested_time>t.requested_time)) 随访状态 from T_FOLLOW_RECORD a join T_FOLLOW_INFO b on a.solution_id=b.id where a.patient_id=" + pid + " and a.solution_id =" + sid + " and rownum=1 ";
            DataTable dsTemp = App.GetDataSet(temp).Tables[0];
            if(dsTemp!=null)
            {
                if (dsTemp.Rows.Count != 0)
                {

                    dgvHistoryFollow.DataSource = null;
                    dgvHistoryFollow.DataSource = dsTemp.DefaultView;
                    for (int i = 0; i < dgvHistoryFollow.Rows.Count; i++)
                    {
                        if (dgvHistoryFollow.Rows[i].Cells["初次随访时间"].Value != null)
                            if (dgvHistoryFollow.Rows[i].Cells["初次随访时间"].Value.ToString() != "")
                                dgvHistoryFollow.Rows[i].Cells["初次随访时间"].Value = dgvHistoryFollow.Rows[i].Cells["初次随访时间"].Value.ToString().Substring(0, dgvHistoryFollow.Rows[i].Cells["初次随访时间"].Value.ToString().IndexOf(' '));
                        if (dgvHistoryFollow.Rows[i].Cells["末次随访时间"].Value != null)
                            if (dgvHistoryFollow.Rows[i].Cells["末次随访时间"].Value.ToString() != "")
                                dgvHistoryFollow.Rows[i].Cells["末次随访时间"].Value = dgvHistoryFollow.Rows[i].Cells["末次随访时间"].Value.ToString().Substring(0, dgvHistoryFollow.Rows[i].Cells["末次随访时间"].Value.ToString().IndexOf(' '));
                    }
                    dgvHistoryFollow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dgvHistoryFollow.ReadOnly = true;
                    dgvHistoryFollow.Columns["随访方案号"].Visible = false;
                }
            }
        }
        /// <summary>
        /// 绑定具体随访方案信息
        /// </summary>
        /// <param name="p"></param>
        /// <param name="s"></param>
        public void DetailDataBind(string p, string s)
        {
            
            string temp = "select a.id 随访记录号,'' 随访次序,a.actual_time 实际随访时间,a.requested_time 规定随访时间,b.user_name 随访者,c.des 随访状态,(select next_time from t_follow_record where id=a.id and is_timeset=1) 下次随访时间 from T_FOLLOW_RECORD a join T_USERINFO b on a.creator_id=b.user_id  join T_FOLLOW_STATE c on a.state_id=c.id where a.patient_id="+p+" and a.solution_id="+s+" order by a.id";
            DataTable detailTb = App.GetDataSet(temp).Tables[0];
            
            if (detailTb != null)
                if (detailTb.Rows.Count != 0)
                {
                    dgvDetailRecord.Columns.Clear();
                    dgvDetailRecord.DataSource = detailTb.DefaultView;
                    DataGridViewLinkColumn linkCol = new DataGridViewLinkColumn();
                    linkCol.UseColumnTextForLinkValue = true;
                    linkCol.Text = "浏览随访信息";
                    linkCol.HeaderText = "操作";
                    linkCol.Name = "随访信息";
                    //if(dgvDetailRecord.Columns.IndexOf(linkCol)==-1)
                    dgvDetailRecord.Columns.Add(linkCol);
                    for (int i = 0; i < dgvDetailRecord.Rows.Count; i++)
                    {
                        dgvDetailRecord.Rows[i].Cells["随访次序"].Value = i + 1;
                        if (dgvDetailRecord.Rows[i].Cells["实际随访时间"].Value != null)
                            if (dgvDetailRecord.Rows[i].Cells["实际随访时间"].Value.ToString() != "")
                                dgvDetailRecord.Rows[i].Cells["实际随访时间"].Value = dgvDetailRecord.Rows[i].Cells["实际随访时间"].Value.ToString().Substring(0, dgvDetailRecord.Rows[i].Cells["实际随访时间"].Value.ToString().IndexOf(' '));
                    }
                    dgvDetailRecord.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dgvDetailRecord.Columns["随访记录号"].Visible = false;
                    dgvDetailRecord.ReadOnly = true;
                }
        }
        /// <summary>
        /// 实例化病人随访记录
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        public Class_Follow_Patient[] GetRecords(DataTable T)
        {
            if (T != null)
            {
                if (T.Rows.Count != 0)
                {
                    Class_Follow_Patient[] Rec = new Class_Follow_Patient[T.Rows.Count];
                    for (int i = 0; i < T.Rows.Count; i++)
                    {
                        Rec[i] = new Class_Follow_Patient();
                        Rec[i].Id = T.Rows[i]["id"].ToString();
                        Rec[i].Patient_Id = T.Rows[i]["patient_id"].ToString();
                        Rec[i].Solution_Id = T.Rows[i]["solution_id"].ToString();
                        Rec[i].Actual_time = T.Rows[i]["Actual_time"].ToString();
                        Rec[i].Requested_time = T.Rows[i]["Requested_time"].ToString();
                        Rec[i].Next_time = T.Rows[i]["next_time"].ToString();
                        Rec[i].Is_timeset = T.Rows[i]["is_timeset"].ToString();
                    }
                    return Rec;
                }
                else
                    return null;
            }
            else
                return null;
        }
        /// <summary>
        /// 根据方案管理者ID，生成记录包括完成与未完成的（按循环条件）
        /// </summary>
        public void Procedure()
        {
            if (myRow != null)
            {
                string quryRec = "select * from T_FOLLOW_RECORD where patient_id=" + pid + " and solution_id=" + sid + " order by id";
                DataTable recTb = App.GetDataSet(quryRec).Tables[0];
                myRec = GetRecords(recTb);
            }
            
            string uid = App.UserAccount.UserInfo.User_id;
            string tempSql;
            if (sid != "")
            {
                tempSql = "select * from T_FOLLOW_INFO where id ="+sid+"";
                DataSet dsTemp = App.GetDataSet(tempSql);
                myInfo = GetInfo(dsTemp);
            }
            //全部插入，然后遍历现有Record表去除已有的记录
            ArrayList Batch = new ArrayList();
            Batch.Clear();
            Class_FollowInfo info = myInfo[0];

            //参考时间默认为出院时间
            DateTime myTime = Convert.ToDateTime(myRow.Cells["参考时间"].Value.ToString());
            string sql = "";
            try
            {
                //先考虑是否为手动控制启用病人
                
                string Manual = App.ReadSqlVal("select * from T_FOLLOW_MANUALPATIENT where patient_id=" + pid + " and solution_id=" + info.Id + " and isadd=1   ", 0, "definefollows");
                
                #region Manual
                if (Manual != ""&&Manual!=null)
                {
                    string ExistRecord = App.ReadSqlVal("select max(requested_time) 完成时间 from T_FOLLOW_RECORD where patient_id=" + pid + " and solution_id=" + info.Id + " ", 0, "完成时间");
                    DateTime NowTime = App.GetSystemTime().Date;
                    DateTime RefTime = Convert.ToDateTime(myRow.Cells["参考时间"].Value.ToString());
                    DateTime RecordTime;
                    if (ExistRecord != "")
                        RecordTime = Convert.ToDateTime(ExistRecord);
                    else
                        RecordTime = RefTime;
                    TimeSpan tSpan1 = RecordTime - RefTime;
                    TimeSpan tSpan2 = NowTime - RecordTime;
                    int MinusTime1 = (int)tSpan1.TotalDays;
                    int MinusTime2 = (int)tSpan2.TotalDays;
                    if (Manual.IndexOf(",") != -1)
                    {
                        string[] Items = Manual.Split(',');
                        for (int i = 0; i < Items.Length; i++)
                        {
                            string Span = Items[i];
                            if (MinusTime2 < 0)
                                break;
                            if (Span.IndexOf("年") != -1)
                            {
                                if (MinusTime1 > 0)
                                    MinusTime1 -= Convert.ToInt32(Span.Substring(0, Span.IndexOf("年"))) * 365;
                                else
                                {
                                    MinusTime2 -= Convert.ToInt32(Span.Substring(0, Span.IndexOf("年"))) * 365;
                                    RecordTime = RecordTime.AddYears(Convert.ToInt32(Span.Substring(0, Span.IndexOf("年"))));
                                    if (MinusTime2 >= 0)
                                    {
                                        sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",'" + RecordTime.ToShortDateString() + "')";
                                        Batch.Add(sql);
                                    }

                                }
                            }
                            if (Span.IndexOf("月") != -1)
                            {
                                if (MinusTime1 > 0)
                                    MinusTime1 -= Convert.ToInt32(Span.Substring(0, Span.IndexOf("月"))) * 30;
                                else
                                {
                                    MinusTime2 -= Convert.ToInt32(Span.Substring(0, Span.IndexOf("月"))) * 30;
                                    RecordTime = RecordTime.AddMonths(Convert.ToInt32(Span.Substring(0, Span.IndexOf("月"))));
                                    if (MinusTime2 >= 0)
                                    {
                                        sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",'" + RecordTime.ToShortDateString() + "')";
                                        Batch.Add(sql);
                                    }

                                }
                            }
                            if (Span.IndexOf("天") != -1)
                            {
                                if (MinusTime1 > 0)
                                    MinusTime1 -= Convert.ToInt32(Span.Substring(0, Span.IndexOf("天")));
                                else
                                {
                                    MinusTime2 -= Convert.ToInt32(Span.Substring(0, Span.IndexOf("天")));
                                    RecordTime = RecordTime.AddDays(Convert.ToInt32(Span.Substring(0, Span.IndexOf("天"))));
                                    if (MinusTime2 >= 0)
                                    {
                                        sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",'" + RecordTime.ToShortDateString() + "')";
                                        Batch.Add(sql);
                                    }

                                }
                            }
                            if (i == Items.Length - 1)
                                i--;

                        }
                    }
                    else
                    {
                        
                        while (true)
                        {
                            if (MinusTime2 < 0)
                                break;
                            if (Manual.IndexOf("年") != -1)
                            {
                                if (MinusTime1 > 0)
                                    MinusTime1 -= Convert.ToInt32(Manual.Substring(0, Manual.IndexOf("年"))) * 365;
                                else
                                {
                                    MinusTime2 -= Convert.ToInt32(Manual.Substring(0, Manual.IndexOf("年"))) * 365;
                                    RecordTime = RecordTime.AddYears(Convert.ToInt32(Manual.Substring(0, Manual.IndexOf("年"))));
                                    if (MinusTime2 >= 0)
                                    {
                                        sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                        Batch.Add(sql);
                                    }

                                }

                            }
                            if (Manual.IndexOf("月") != -1)
                            {
                                if (MinusTime1 > 0)
                                    MinusTime1 -= Convert.ToInt32(Manual.Substring(0, Manual.IndexOf("月"))) * 30;
                                else
                                {
                                    MinusTime2 -= Convert.ToInt32(Manual.Substring(0, Manual.IndexOf("月"))) * 30;
                                    RecordTime = RecordTime.AddMonths(Convert.ToInt32(Manual.Substring(0, Manual.IndexOf("月"))));
                                    if (MinusTime2 >= 0)
                                    {
                                        sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                        Batch.Add(sql);
                                    }

                                }

                            }
                            if (Manual.IndexOf("天") != -1)
                            {
                                if (MinusTime1 > 0)
                                    MinusTime1 -= Convert.ToInt32(Manual.Substring(0, Manual.IndexOf("天")));
                                else
                                {
                                    MinusTime2 -= Convert.ToInt32(Manual.Substring(0, Manual.IndexOf("天")));
                                    RecordTime = RecordTime.AddDays(Convert.ToInt32(Manual.Substring(0, Manual.IndexOf("天"))));
                                    if (MinusTime2 >= 0)
                                    {
                                        sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                        Batch.Add(sql);
                                    } 

                                }

                            }

                        }
                    }

                }

                #endregion
                /**************************************************************************************************************************************************************************************/
                /***************************************************************************************完成手动添加病人的记录插入***********************************************************************************************/
                #region Auto
                else
                {
                    string ExistRecord ="";
                    int ExistTimes = 0; //计数用来查看是否超过方案规定次数
                    int TimesCount = 0; //计数当前已生成记录
                    DateTime NowTime = DateTime.Today;
                    DateTime RefTime = Convert.ToDateTime(myRow.Cells["参考时间"].Value.ToString());
                    DateTime RecordTime;
                    //判断是否已存在记录，若已存在则时间点以当前最大应随访时间开始计算
                    if (myRec != null)
                    {
                        ExistRecord = myRec[myRec.Length - 1].Requested_time;
                        ExistTimes = TimesCount = myRec.Length;                        
                        RecordTime = Convert.ToDateTime(ExistRecord);
                    }
                    else
                    {
                        RecordTime = RefTime;
                        if (info.Defaultdays != "0")
                        {
                            RecordTime = RecordTime.AddDays(Convert.ToInt32(info.Defaultdays));                            
                            sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                            Batch.Add(sql);
                            ExistTimes++;
                        }
                    }                   
                    
                    int MinusTime2 = (int)(NowTime - RecordTime).TotalDays;

                    
                    if (info.Definefollows != "")
                    {
                        string[] Items = info.Definefollows.Split(',');
                        for (int i = 0; i < Items.Length; i++)
                        {
                            if (MinusTime2 < 0)
                                break;
                            if (TimesCount != 0)
                            {
                                //若最后一条记录设置了下次随访时间
                                if (TimesCount == 1)
                                {

                                    if (myRec[myRec.Length - 1].Next_time != "")
                                    {
                                        if (myRec[myRec.Length - 1].Is_timeset == "1")
                                        {
                                            RecordTime = Convert.ToDateTime(myRec[myRec.Length - 1].Next_time);
                                            sql = "insert into t_follow_record(patient_id,solution_id,creator_id,requested_time) values(" + pid + "," + sid + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                            Batch.Add(sql);
                                            ExistTimes++;
                                        }
                                        if (myRec[myRec.Length - 1].Is_timeset == "0")
                                        {
                                            RecordTime = Convert.ToDateTime(myRec[myRec.Length - 1].Next_time);
                                        }


                                    }
                                    MinusTime2 = (int)(NowTime - RecordTime).TotalDays;
                                }
                                if (i >= Items.Length - 1)
                                    i--;
                                TimesCount--;
                                continue;
                            }
                            //判断是否符合方案的结束条件
                            if (info.FinishType != "")
                            {
                                if (info.FinishType.IndexOf("次") != -1)
                                {
                                    if (ExistTimes >= Convert.ToInt32(info.FinishType.Substring(0, info.FinishType.IndexOf("次"))))
                                        break;

                                }
                                else
                                {
                                    int span2 = 0;
                                    TimeSpan tempSpan = RecordTime - RefTime;
                                    span2 = (int)tempSpan.TotalDays + Convert.ToInt32(info.Defaultdays);
                                    int span1 = 0;
                                    if (info.FinishType.IndexOf("年") != -1)
                                    {
                                        span1 = Convert.ToInt32(info.FinishType.Substring(0, info.FinishType.IndexOf("年"))) * 365;
                                    }
                                    if (info.FinishType.IndexOf("月") != -1)
                                    {
                                        span1 = Convert.ToInt32(info.FinishType.Substring(0, info.FinishType.IndexOf("月"))) * 30;
                                    }
                                    if (info.FinishType.IndexOf("天") != -1)
                                    {
                                        span1 = Convert.ToInt32(info.FinishType.Substring(0, info.FinishType.IndexOf("天")));
                                    }
                                    if (span1 <= span2)
                                        break;
                                }
                            }

                            string Span = "";
                            if (i >= Items.Length)
                            {
                                i = Items.Length - 1;
                                
                            }                           
                            Span = Items[i];
                            if (Span.IndexOf("年") != -1)
                            {
                                RecordTime = RecordTime.AddYears(Convert.ToInt32(Span.Substring(0, Span.IndexOf("年"))));
                                sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                Batch.Add(sql);
                                ExistTimes++;
                                MinusTime2 = (int)(NowTime - RecordTime).TotalDays;
                                
                            }
                            if (Span.IndexOf("月") != -1)
                            {
                                RecordTime = RecordTime.AddMonths(Convert.ToInt32(Span.Substring(0, Span.IndexOf("月"))));
                                sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                Batch.Add(sql);
                                ExistTimes++;
                                MinusTime2 = (int)(NowTime - RecordTime).TotalDays;
                                
                            }
                            if (Span.IndexOf("天") != -1)
                            {
                                RecordTime = RecordTime.AddDays(Convert.ToInt32(Span.Substring(0, Span.IndexOf("天"))));
                                sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                Batch.Add(sql);
                                ExistTimes++;
                                MinusTime2 = (int)(NowTime - RecordTime).TotalDays;                                
                            }
                            if (i >= Items.Length - 1)
                                i--;

                        }
                    }
                    else
                    {
                        
                        while (true)
                        {
                            string Span = info.Followtype;
                            if (MinusTime2 < 0)
                                break;
                            if (TimesCount != 0)
                            {
                                //若最后一条记录设置了下次随访时间
                                if (TimesCount == 1)
                                {

                                    if (myRec[myRec.Length - 1].Next_time != "")
                                    {
                                        RecordTime = Convert.ToDateTime(myRec[myRec.Length - 1].Next_time);
                                        sql = "insert into t_follow_record(patient_id,solution_id,creator_id,requested_time) values(" + pid + "," + sid + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                        Batch.Add(sql);
                                        ExistTimes++;

                                    }
                                    MinusTime2 = (int)(NowTime - RecordTime).TotalDays;
                                }
                                TimesCount--;
                                continue;
                            }
                            if (info.FinishType != "")
                            {
                                if (info.FinishType.IndexOf("次") != -1)
                                {
                                    if (ExistTimes >= Convert.ToInt32(info.FinishType.Substring(0, info.FinishType.IndexOf("次"))))
                                        break;

                                }
                                else
                                {
                                    int span2 = 0;
                                    TimeSpan tempSpan = RecordTime - RefTime;
                                    span2 = (int)tempSpan.TotalDays + Convert.ToInt32(info.Defaultdays);
                                    int span1 = 0;
                                    if (info.FinishType.IndexOf("年") != -1)
                                    {
                                        span1 = Convert.ToInt32(info.FinishType.Substring(0, info.FinishType.IndexOf("年"))) * 365;
                                    }
                                    if (info.FinishType.IndexOf("月") != -1)
                                    {
                                        span1 = Convert.ToInt32(info.FinishType.Substring(0, info.FinishType.IndexOf("月"))) * 30;
                                    }
                                    if (info.FinishType.IndexOf("天") != -1)
                                    {
                                        span1 = Convert.ToInt32(info.FinishType.Substring(0, info.FinishType.IndexOf("天")));
                                    }
                                    if (span1 <= span2)
                                        break;
                                }
                            }

                            if (info.Followtype.IndexOf("年") != -1)
                            {
                                RecordTime = RecordTime.AddYears(Convert.ToInt32(info.Followtype.Substring(0, info.Followtype.IndexOf("年"))));
                                sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                Batch.Add(sql);
                                ExistTimes++;
                                MinusTime2 = (int)(NowTime - RecordTime).TotalDays;                                
                            }
                            if (info.Followtype.IndexOf("月") != -1)
                            {
                                RecordTime = RecordTime.AddMonths(Convert.ToInt32(info.Followtype.Substring(0, info.Followtype.IndexOf("月"))));
                                sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                Batch.Add(sql);
                                ExistTimes++;
                                MinusTime2 = (int)(NowTime - RecordTime).TotalDays;
                                

                            }
                            if (info.Followtype.IndexOf("天") != -1)
                            {
                                RecordTime = RecordTime.AddDays(Convert.ToInt32(info.Followtype.Substring(0, info.Followtype.IndexOf("天"))));
                                sql = "insert into T_FOLLOW_RECORD(PATIENT_ID,SOLUTION_ID,CREATOR_ID,REQUESTED_TIME) VALUES(" + pid + "," + info.Id + "," + App.UserAccount.UserInfo.User_id + ",to_date('" + RecordTime.ToShortDateString() + "','yyyy-MM-dd'))";
                                Batch.Add(sql);
                                ExistTimes++;
                                MinusTime2 = (int)(NowTime - RecordTime).TotalDays;                                
                            }

                        }
                    }

                }

                #endregion
                string[] final = new string[Batch.Count];
                for (int j = 0; j < Batch.Count; j++)
                {
                    final[j] = Batch[j].ToString();
                }

                App.ExecuteBatch(final);

            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        
        }
        /// <summary>
        /// 字符再处理（形如'1'，'2'，'3'）
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public string ProcessStr(string temp)
        {
            string outStr = "";
            if (temp.IndexOf(',') != -1)
            {
                string[] str = temp.Split(',');
                foreach (string item in str)
                {
                    if (outStr == "")
                        outStr = "," + item + ",";
                    else
                        outStr += ",'" + item + ",";
                }
                return outStr;
            }
            else
                return "'" + temp + "'";
        }
        /// <summary>
        /// 实例化方案
        /// </summary>
        /// <param name="temp"></param>
        /// <returns></returns>
        public Class_FollowInfo[] GetInfo(DataSet temp)
        {
            if (temp != null)
                if (temp.Tables[0].Rows.Count != 0)
                {

                    DataTable dt = temp.Tables[0];
                    Class_FollowInfo[] info = new Class_FollowInfo[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        info[i] = new Class_FollowInfo();
                        info[i].Id = dt.Rows[i]["id"].ToString();
                        info[i].Follow_name = dt.Rows[i]["follow_name"].ToString();
                        info[i].Account_ids = dt.Rows[i]["account_ids"].ToString();
                        info[i].Section_ids = dt.Rows[i]["section_ids"].ToString();
                        info[i].Icd9codes = dt.Rows[i]["icd9codes"].ToString();
                        info[i].Icd10codes = dt.Rows[i]["icd10codes"].ToString();
                        info[i].Ismaindiag = dt.Rows[i]["ismaindiag"].ToString();
                        info[i].Startingtime = dt.Rows[i]["startingtime"].ToString();
                        info[i].Defaultdays = dt.Rows[i]["defaultdays"].ToString();
                        info[i].Followtype = dt.Rows[i]["followtype"].ToString();
                        info[i].Definefollows = dt.Rows[i]["definefollows"].ToString();
                        info[i].Followtextid = dt.Rows[i]["followtextid"].ToString();
                        info[i].Createtime = dt.Rows[i]["createtime"].ToString();
                        info[i].Isenable = dt.Rows[i]["isenable"].ToString();
                        info[i].Maintain_section = dt.Rows[i]["maintain_section"].ToString();
                        info[i].FinishType = dt.Rows[i]["finishType"].ToString();
                    }
                    return info;
                }
            return null;
        }
        /// <summary>
        /// 获取相关方案ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetSolutionIds(string id)
        {
            string getUserIds = "select id,account_ids from T_FOLLOW_INFO ";
            string ReturnIds = "";
            DataSet sTemp = App.GetDataSet(getUserIds);
            if (sTemp != null)
            {
                if (sTemp.Tables[0].Rows.Count != 0)
                {
                    DataTable dt = sTemp.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string[] ids = dt.Rows[i]["account_ids"].ToString().Split(',');
                        foreach (string temp in ids)
                        {
                            if (id == temp)
                            {
                                if (ReturnIds == "")
                                    ReturnIds = dt.Rows[i]["id"].ToString();
                                else
                                    ReturnIds += "," + dt.Rows[i]["id"].ToString();
                                break;
                            }

                        }
                    }
                    return ReturnIds;
                }
            }
            return "";
        }
        private void dgvHistoryFollow_DoubleClick(object sender, EventArgs e)
        {
            if (sid != "" && pid != "")
            {
                DetailDataBind(pid, sid);
            }
        }
        
        private void dgvHistoryFollow_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex!=-1)
                sid = dgvHistoryFollow.Rows[e.RowIndex].Cells["随访方案号"].Value.ToString();
        }

        private void dgvDetailRecord_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetailRecord.Columns[e.ColumnIndex].Name == "随访信息")
            {
                string rid = dgvDetailRecord.Rows[e.RowIndex].Cells["随访记录号"].Value.ToString();
                frmFollowDocOper frm = new frmFollowDocOper(rid,this);
                frm.ShowDialog();
                
            }
        }

    }
}