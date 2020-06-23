using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.HisInStance
{
    public partial class frmBa_Insert :UserControl
    {

        List<string> Ids = new List<string>();

        

        public frmBa_Insert()
        {
            InitializeComponent();
        }

        private void frmBa_Insert_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridViewX1.Columns.Clear();
            string sql = "select t.id as ����,t.patient_name as ����,Decode(t.gender_code,0,'��',1,'Ů') as �Ա�," +
                         "case when HIS_ID is not null then HIS_ID else PID end  סԺ��,PID as ������,in_time as ��Ժʱ��" +
                          ",die_time as ��Ժʱ��,t.section_name as ��Ժ����,t.sick_area_name as ��Ժ����,t.exe_document_time as �鵵ʱ�� from t_in_patient t " +
                          "where t.id in (select a.p_id from view_pat_interface a) " +
                          "and t.exe_document_time is not null  and to_char(t.exe_document_time,'yyyy-mm-dd') between '" + dateTimePicker_start.Value.ToString("yyyy-MM-dd") + "' and '" + dateTimePicker_End.Value.ToString("yyyy-MM-dd") + "'" +
                          " and t.baupload<>'1'";
            DataSet ds = App.GetDataSet(sql);
            dataGridViewX1.DataSource = ds.Tables[0].DefaultView;            
            DataGridViewCheckBoxColumn newColumn = new DataGridViewCheckBoxColumn();
            newColumn.HeaderText = "ѡ��";
            dataGridViewX1.Columns.Insert(0, newColumn);
            dataGridViewX1.AutoResizeColumns();
        }
        
        /// <summary>
        /// ���ݵ��벡����Ϣϵͳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInsert_Click(object sender, EventArgs e)
        {

            Ids.Clear();

            for (int i = 0; i < dataGridViewX1.RowCount; i++)
            {
                if (dataGridViewX1[0, i].Value != null)
                {
                    if (dataGridViewX1[0, i].Value.ToString() == "True")
                    {
                        Ids.Add(dataGridViewX1["����", i].Value.ToString());
                    }
                }
            }
            string names = "";
            for (int i = 0; i < Ids.Count; i++)
            {
                List<string> Sqls = new List<string>();
                Insert_pat_interface(ref Sqls, Ids[i]);
                try
                {
                    App.WebService.ExecuteBatch_SqlSv(Sqls.ToArray());
                    //if (App.WebService.ExecuteBatch_SqlSv(Sqls.ToArray()) > 0)
                    //{
                    //    App.Msg("�����Ѿ��ɹ���");
                    //}
                    //string conditions = "";
                    //if (Ids.Count == 0)
                    //    return;
                    //for (int i = 0; i < Ids.Count; i++)
                    //{
                    //    if (i == 0)
                    //    {
                    //        conditions = " where id in (" + Ids[i].ToString();
                    //    }
                    //    else if (i <= Ids.Count - 1)
                    //    {
                    //        conditions = conditions + "," + Ids[i].ToString();
                    //    }
                    //}
                    //if (conditions != "")
                    //    conditions = conditions + ")";
                    string update = "update t_in_patient set baupload='1' where id=" + Ids[i];
                    App.ExecuteSQL(update);
                }
                catch (Exception ex)
                {
                    //App.MsgErr("����ʧ�ܣ�" + ex.Message.ToString());
                    ex.Message.ToString();
                    if (names.Length == 0)
                    {
                        names = App.ReadSqlVal("select patient_name from t_in_patient where id=" + Ids[i], 0, "patient_name");
                    }
                    else
                    {
                        names += "��" + App.ReadSqlVal("select patient_name from t_in_patient where id=" + Ids[i], 0, "patient_name");
                    }
                }
            }
            if (names.Length == 0)
            {
                App.Msg("�����Ѿ��ɹ���");
            }
            else
            {
                App.Msg("����:" + names + "���������ϴ�ʧ��");
            }
        }

        /// <summary>
        /// �ӿ���Ϣ��
        /// </summary>
        /// <returns></returns>
        private void Insert_pat_interface(ref List<string> Sqls,string pid)
        {                         
            /*
             * ����ʵ��
             */            
            string sql_v = "select * from VIEW_PAT_INTERFACE ";
         

            string conditions = "";
            //if (Ids.Count == 0)
            //    return;
            //for (int i = 0; i < Ids.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        conditions = " where p_id in (" + Ids[i].ToString();
            //    }
            //    else if (i <= Ids.Count-1)
            //    {
            //       conditions = conditions + "," + Ids[i].ToString();
            //    }              
            //}
            //if (conditions!="")
            //     conditions = conditions + ")";
            conditions = " where p_id=" + pid;
            string strSqlBaSecionCode="select section_code,ba_code from t_sectioninfo";
            DataTable dtBaSecion = App.GetDataSet(strSqlBaSecionCode).Tables[0];

            //string 

            //string sql_conditions = " where p_id in (select t.id from t_in_patient t " +
            //              "where t.id not in (select a.patient_id from t_inhospital_action a) " +
            //              "and t.exe_document_time is not null  and t.exe_document_time between to_date('" + dateTimePicker_start.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd') and to_date('" + dateTimePicker_End.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd'))";



            DataSet ds = App.GetDataSet(sql_v + conditions);

            string patient_id, visit_id, name, sex, date_of_birth, birth_age, nation, marriage, country, job,
                   id_card, birth_place, birth_addr, birth_zip, birth_tell, work_addr, work_tell, work_zip,
                   relation_name, relation, relation_addr, relation_tell, fee_mode, enter_date, enter_dept, enter_loce, out_date,
                   out_dept, out_loce, fee_bed, fee_hl, fee_xy, fee_zcy, fee_zc, fee_fs, fee_hy, fee_sy, fee_sx, fee_zl, fee_mz, fee_ye,
                   fee_pc, fee_other_1, fee_other_2, fee_other_3, charge_01, charge_02, charge_03, charge_04, charge_05, charge_06,
                   charge_07, fee_sum, charge_10, charge_11, charge_12, fee_sum_pay, admiss_doctor, admiss_id, create_date, diagnose_door_icd,
                   diagnose_enter_icd, admiss_type, dis_type, trans_dept, diagnose_door_name, fact_days, health_no, newborn_birth_weight,
                   newborn_admiss_weight, native_place, registered_addr, registered_zip, clinical_pathway;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                //List<string> list = new List<string>();
                patient_id = ds.Tables[0].Rows[i]["patient_id"].ToString();
                visit_id = ds.Tables[0].Rows[i]["visit_id"].ToString();
                name = ds.Tables[0].Rows[i]["name"].ToString();
                sex = ds.Tables[0].Rows[i]["sex"].ToString();
                date_of_birth = ds.Tables[0].Rows[i]["date_of_birth"].ToString();
                birth_age = ds.Tables[0].Rows[i]["birth_age"].ToString();
                nation = ds.Tables[0].Rows[i]["nation"].ToString();
                marriage = ds.Tables[0].Rows[i]["marriage"].ToString();
                country = ds.Tables[0].Rows[i]["country"].ToString();
                job = ds.Tables[0].Rows[i]["job"].ToString();
                id_card = ds.Tables[0].Rows[i]["id_card"].ToString();
                birth_place = ds.Tables[0].Rows[i]["birth_place"].ToString();
                birth_addr = ds.Tables[0].Rows[i]["birth_addr"].ToString();
                birth_zip = ds.Tables[0].Rows[i]["birth_zip"].ToString();
                birth_tell = ds.Tables[0].Rows[i]["birth_tell"].ToString();
                work_addr = ds.Tables[0].Rows[i]["work_addr"].ToString();
                work_tell = ds.Tables[0].Rows[i]["work_tell"].ToString();
                work_zip = ds.Tables[0].Rows[i]["work_zip"].ToString();
                relation_name = ds.Tables[0].Rows[i]["relation_name"].ToString();
                relation = ds.Tables[0].Rows[i]["relation"].ToString();
                relation_addr = ds.Tables[0].Rows[i]["relation_addr"].ToString();
                relation_tell = ds.Tables[0].Rows[i]["relation_tell"].ToString();
                fee_mode = ds.Tables[0].Rows[i]["fee_mode"].ToString();
                enter_date = ds.Tables[0].Rows[i]["enter_date"].ToString();
                enter_dept = ds.Tables[0].Rows[i]["enter_dept"].ToString();
                enter_loce = ds.Tables[0].Rows[i]["enter_loce"].ToString();
                out_date = ds.Tables[0].Rows[i]["out_date"].ToString();
                out_dept = ds.Tables[0].Rows[i]["out_dept"].ToString();
                out_loce = ds.Tables[0].Rows[i]["out_loce"].ToString();
                fee_bed = ds.Tables[0].Rows[i]["fee_bed"].ToString();
                fee_hl = ds.Tables[0].Rows[i]["fee_hl"].ToString();
                fee_xy = ds.Tables[0].Rows[i]["fee_xy"].ToString();
                fee_zcy = ds.Tables[0].Rows[i]["fee_zcy"].ToString();
                fee_zc = ds.Tables[0].Rows[i]["fee_zc"].ToString();
                fee_fs = ds.Tables[0].Rows[i]["fee_fs"].ToString();
                fee_hy = ds.Tables[0].Rows[i]["fee_hy"].ToString();
                fee_sy = ds.Tables[0].Rows[i]["fee_sy"].ToString();
                fee_sx = ds.Tables[0].Rows[i]["fee_sx"].ToString();
                fee_zl = ds.Tables[0].Rows[i]["fee_zl"].ToString();
                fee_mz = ds.Tables[0].Rows[i]["fee_mz"].ToString();
                fee_ye = ds.Tables[0].Rows[i]["fee_ye"].ToString();
                fee_pc = ds.Tables[0].Rows[i]["fee_pc"].ToString();
                fee_other_1 = ds.Tables[0].Rows[i]["fee_other_1"].ToString();
                fee_other_2 = ds.Tables[0].Rows[i]["fee_other_2"].ToString();
                fee_other_3 = ds.Tables[0].Rows[i]["fee_other_3"].ToString();
                charge_01 = ds.Tables[0].Rows[i]["charge_01"].ToString();
                charge_02 = ds.Tables[0].Rows[i]["charge_02"].ToString();
                charge_03 = ds.Tables[0].Rows[i]["charge_03"].ToString();
                charge_04 = ds.Tables[0].Rows[i]["charge_04"].ToString();
                charge_05 = ds.Tables[0].Rows[i]["charge_05"].ToString();
                charge_06 = ds.Tables[0].Rows[i]["charge_06"].ToString();
                charge_07 = ds.Tables[0].Rows[i]["charge_07"].ToString();
                fee_sum = ds.Tables[0].Rows[i]["fee_sum"].ToString();
                charge_10 = ds.Tables[0].Rows[i]["charge_10"].ToString();
                charge_11 = ds.Tables[0].Rows[i]["charge_11"].ToString();
                charge_12 = ds.Tables[0].Rows[i]["charge_12"].ToString();
                fee_sum_pay = ds.Tables[0].Rows[i]["fee_sum_pay"].ToString();
                admiss_doctor = ds.Tables[0].Rows[i]["admiss_doctor"].ToString();
                admiss_id = ds.Tables[0].Rows[i]["admiss_id"].ToString();
                create_date = DateTime.Now.ToString("yyyy-MM-dd"); //ds.Tables[0].Rows[i]["create_date"].ToString();
                diagnose_door_icd = ds.Tables[0].Rows[i]["diagnose_door_icd"].ToString();
                diagnose_enter_icd = ds.Tables[0].Rows[i]["diagnose_enter_icd"].ToString();
                admiss_type = ds.Tables[0].Rows[i]["admiss_type"].ToString();
                dis_type = ds.Tables[0].Rows[i]["dis_type"].ToString();
                trans_dept = ds.Tables[0].Rows[i]["trans_dept"].ToString();
                diagnose_door_name = ds.Tables[0].Rows[i]["diagnose_door_name"].ToString();
                fact_days = ds.Tables[0].Rows[i]["fact_days"].ToString();
                health_no = ds.Tables[0].Rows[i]["health_no"].ToString();
                newborn_birth_weight = ds.Tables[0].Rows[i]["newborn_birth_weight"].ToString();
                newborn_admiss_weight = ds.Tables[0].Rows[i]["newborn_admiss_weight"].ToString();
                native_place = ds.Tables[0].Rows[i]["native_place"].ToString();
                registered_addr = ds.Tables[0].Rows[i]["registered_addr"].ToString();
                registered_zip = ds.Tables[0].Rows[i]["registered_zip"].ToString();
                clinical_pathway = ds.Tables[0].Rows[i]["clinical_pathway"].ToString();

                //����
                if (country == "CN")
                {
                    country = "156";
                }

                //ְҵ(�ɰ����ת���°����)
                switch (job.Trim())
                {
                    case "0":
                        job = "37";
                        break;
                    case "1":
                        job = "24";
                        break;
                    case "2":
                        job = "27";
                        break;
                    case "3":
                        job = "31";
                        break;
                    case "4":
                        job = "11";
                        break;
                    case "5":
                        job = "54";
                        break;
                    case "6":
                        job = "54";
                        break;
                    case "7":
                        job = "13";
                        break;
                    case "8":
                        job = "90";
                        break;
                    case "9":
                        job = "70";
                        break;
                    case "10":
                        job = "80";
                        break;
                    default:
                        if (job == "" || job.Trim().Length > 2)
                        {
                            job = "90";
                        }
                        break;
                }

                //��ϵת��
                switch (relation.Trim())
                {
                    case"":
                        relation = "8";
                        break;
                    case"0":
                        relation = "0";
                        break;
                    case"1":
                        relation = "1";
                        break;
                    case"2":
                        relation = "2";
                        break;
                    case"3":
                        relation = "4";
                        break;
                    case"4":
                        relation = "5";
                        break;
                    case"5":
                        relation = "6";
                        break;
                    case"6":
                        relation = "7";
                        break;
                    case"13":
                        relation = "3";
                        break;
                    default:
                        relation = "8";
                        break;
                }
                //������
                if (birth_place.Contains("|"))
                {
                    string[] strplace = birth_place.Split('|');
                    for (int i1 = strplace.Length - 1; i1 >= 0; i1--)
                    {
                        if (strplace[i1].Trim() != "")
                        {
                            birth_place = App.ReadSqlVal("select BZDM from t_data_code aa where aa.name='" + strplace[i1] + "'", 0, "BZDM");
                            if (birth_place != null)
                            {
                                break;
                            }
                        }
                    }                        
                }

                //����
                if (native_place.Contains("|"))
                {
                    string[] strplace = native_place.Split('|');
                    for (int i1 = strplace.Length - 1; i1 >= 0; i1--)
                    {
                        if (strplace[i1].Trim() != "")
                        {
                            native_place = App.ReadSqlVal("select BZDM from t_data_code aa where aa.name='" + strplace[i1] + "'", 0, "BZDM");
                            if (native_place != null)
                            {
                                break;
                            }
                        }
                    }
                }

                //���Ҵ���ת��
                string strBaSectionCode = dtBaSecion.Select("section_code='" + enter_dept + "'")[0]["ba_code"].ToString();
                //��Ժ����
                if (!string.IsNullOrEmpty(strBaSectionCode))
                {
                    enter_dept = strBaSectionCode;
                    strBaSectionCode = "";
                }
                //��Ժ����
                strBaSectionCode = dtBaSecion.Select("section_code='" + out_dept + "'")[0]["ba_code"].ToString();
                if (!string.IsNullOrEmpty(strBaSectionCode))
                {
                    out_dept = strBaSectionCode;
                    strBaSectionCode = "";
                }
                if (admiss_id.ToString() == "")
                {
                    admiss_id = patient_id;
                }

                if (visit_id.ToString() == "")
                {
                    visit_id = "1";
                }

                if (!birth_age.Contains("��"))
                {
                    if (birth_age.Trim().Contains("��") || birth_age.Trim().Contains("��"))
                    {
                        birth_age = "0";
                    }
                }
                else
                {
                    birth_age = birth_age.Split('��')[0];
                }

                if (!App.IsNumeric(charge_10))
                {
                    charge_10 = "null";
                }

                if (!App.IsNumeric(charge_11))
                {
                    charge_11 = "null";
                }

                if (!App.IsNumeric(charge_12))
                {
                    charge_12 = "null";
                }

                if (!App.IsNumeric(fee_sum_pay))
                {
                    fee_sum_pay = "null";
                }

                if (!App.IsNumeric(fact_days.Trim()))
                {
                    fact_days = "null";
                }

                if (!App.IsNumeric(newborn_birth_weight.Trim()))
                {
                    newborn_birth_weight = "null";

                }
                if (!App.IsNumeric(newborn_admiss_weight.Trim()))
                {
                    newborn_admiss_weight = "null";
                }


                birth_tell = GetNewStr(birth_tell, 14);

                work_tell = GetNewStr(work_tell, 14);

                registered_zip = GetNewStr(registered_zip, 6);

                birth_place = GetNewStr(birth_place, 50);

                birth_addr = GetNewStr(birth_addr, 50);

                work_addr = GetNewStr(work_addr, 50);

                relation_tell = GetNewStr(relation_tell, 14);

                relation_addr = GetNewStr(relation_addr, 50);

                relation_name = GetNewStr(relation_name, 12);

                birth_zip = GetNewStr(birth_zip, 6);

                work_zip = GetNewStr(work_zip, 6);

                name = GetNewStr(name, 12);

                diagnose_enter_icd = GetNewStr(diagnose_enter_icd, 20);

                diagnose_door_name = GetNewStr(diagnose_door_name, 20);

                // ת����Ϣ
                string selTurnWithAction = "select distinct ti.sid,ts.section_name,ti.happen_time,ti.action_type from t_inhospital_action_history ti"
                        + " inner join t_sectioninfo ts on ti.sid=ts.sid where ti.patient_id=" + ds.Tables[0].Rows[i]["p_id"].ToString() + " and ti.action_type in ('ת��','����')"
                        + " order by ti.happen_time asc";

                DataSet dsTuen = App.GetDataSet(selTurnWithAction);
                int length = dsTuen.Tables[0].Rows.Count;
                string sectionTemp = "��";
                for (int i1 = 0; i1 < length; i1++)
                {
                    string sectionName = dsTuen.Tables[0].Rows[i1]["SECTION_NAME"].ToString();
                    if (length > 1)
                    {
                        sectionTemp += sectionName + "��";
                    }
                }

                trans_dept = sectionTemp.Substring(0, sectionTemp.Length > 1 ? sectionTemp.Length - 1 : 0);

                #region ���˻�����Ϣ
                string sql_delete_info = "delete from pat_interface where patient_id='" + patient_id + "'";
                Sqls.Add(sql_delete_info);
                //list.Add(sql_delete_info);
                string Sql = "insert into pat_interface(patient_id, visit_id, name, sex, date_of_birth, birth_age, nation, marriage, country, job," +
                   "id_card, birth_place, birth_addr, birth_zip, birth_tell, work_addr, work_tell, work_zip," +
                   "relation_name, relation, relation_addr, relation_tell, fee_mode, enter_date, enter_dept, enter_loce, out_date," +
                   "out_dept, out_loce, fee_bed, fee_hl, fee_xy, fee_zcy, fee_zc, fee_fs, fee_hy, fee_sy, fee_sx, fee_zl, fee_mz, fee_ye," +
                   "fee_pc, fee_other_1, fee_other_2, fee_other_3, charge_01, charge_02, charge_03, charge_04, charge_05, charge_06," +
                   "charge_07, fee_sum, charge_10, charge_11, charge_12, fee_sum_pay, admiss_doctor, admiss_id, create_date, diagnose_door_icd," +
                   "diagnose_enter_icd, admiss_type, dis_type, trans_dept, diagnose_door_name, fact_days, health_no, newborn_birth_weight," +
                   "newborn_admiss_weight, native_place, registered_addr, registered_zip, clinical_pathway) values ('" + patient_id + "', '" + visit_id + "', '" + name + "', '" +
                   sex + "', '" + date_of_birth + "', '" + birth_age + "', '" + nation + "', '" + marriage + "', '" + country + "', '" + job + "','" +
                   id_card + "', '" + birth_place + "', '" + birth_addr + "', '" + birth_zip + "', '" + birth_tell + "', '" + work_addr + "', '" + work_tell + "', '" + work_zip + "','" +
                   relation_name + "', '" + relation + "', '" + relation_addr + "', '" + relation_tell + "', '" + fee_mode + "', '" + enter_date + "','" + enter_dept + "','" + enter_loce + "','" + out_date + "','"
                   + out_dept + "', '" + out_loce + "', '" + fee_bed + "', '" + fee_hl + "', '" + fee_xy + "', '" + fee_zcy + "','" + fee_zc + "','" + fee_fs + "', '" + fee_hy + "', '" + fee_sy + "', '" + fee_sx + "', '" + fee_zl + "', '" + fee_mz + "', '" + fee_ye + "','"
                   + fee_pc + "','" + fee_other_1 + "','" + fee_other_2 + "', '" + fee_other_3 + "', '" + charge_01 + "','" + charge_02 + "', '" + charge_03 + "', '" + charge_04 + "','" + charge_05 + "','" + charge_06 + "','"
                   + charge_07 + "','" + fee_sum + "'," + charge_10 + "," + charge_11 + "," + charge_12 + ", " + fee_sum_pay + ",'" + admiss_doctor + "','" + admiss_id + "','" + create_date + "','" + diagnose_door_icd + "','"
                   + diagnose_enter_icd + "','" + admiss_type + "','" + dis_type + "', '" + trans_dept + "', '" + diagnose_door_name + "'," + fact_days + ", '" + health_no + "', " + newborn_birth_weight + ","
                   + newborn_admiss_weight + ", '" + native_place + "', '" + registered_addr + "', '" + registered_zip + "', '" + clinical_pathway + "')";
                
                Sqls.Add(Sql);
                //list.Add(Sql);
                #endregion

                string strId = ds.Tables[0].Rows[i]["p_id"].ToString();
                
                #region ��ҽ���
                //��ҽ���
                string sql_dia = "select a.type,a.name,a.icd10name,a.pnumber,a.incondition from cover_diagnose a where patient_id='" + strId + "'";
                sql_dia += " and (a.is_chinese is null or a.is_chinese<>'Y')";
                //sql_dia += " and (name<>'-' or name<>'��' or name<>'') ";
                string sql_delete_dia = "delete from pat_interface_diag where patient_id='" + patient_id + "'";
                Sqls.Add(sql_delete_dia);
                //list.Add(sql_delete_dia);
                DataSet dsDiag = App.GetDataSet(sql_dia);
                if (dsDiag.Tables.Count > 0)
                {
                    int index = 1;
                    if (dsDiag.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drDiag in dsDiag.Tables[0].Rows)
                        {
                            if (drDiag["name"].ToString().Trim().Length == 0 || drDiag["name"].ToString().Trim() == "-"||drDiag["name"].ToString().Trim()=="��")
                            {
                                continue;
                            }
                            drDiag["name"] = App.GetStringList(drDiag["name"].ToString(), 120)[0];
                            drDiag["name"] = drDiag["name"].ToString().Replace("\'", "\'\'");
                            drDiag["pnumber"] = GetNewStr(drDiag["pnumber"].ToString(), 20);
                            StringBuilder sb = new StringBuilder(); //M
                            string diatype=drDiag["type"].ToString().Trim();
                            string admiss_thing = drDiag["incondition"].ToString().Trim();
                            if (diatype != "E")
                            {
                                if (diatype == "M")
                                {
                                    diatype = "1";
                                }
                                else if (diatype == "O")
                                {
                                    diatype = "2";
                                }
                                else if (diatype == "P")
                                {
                                    diatype = "4";
                                }
                                else if (diatype == "S")
                                {
                                    diatype = "5";
                                }
                                switch (admiss_thing)
                                {
                                    case "��":
                                        admiss_thing = "1";
                                        break;
                                    case "�ٴ�δȷ��":
                                        admiss_thing = "2";
                                        break;
                                    case "�������":
                                        admiss_thing = "3";
                                        break;
                                    case "��":
                                        admiss_thing = "4";
                                        break;
                                    default:
                                        if (admiss_thing.Length > 1)
                                        {
                                            admiss_thing = "";
                                        }
                                        break;
                                }
                                sb.Append("insert into pat_interface_diag(patient_id,visit_id,icdcode,trans_code,trans_code_xh,icd_name,trans_bl,admiss_thing) values ");
                                sb.Append("('" + patient_id + "'," + visit_id + ",'" + drDiag["icd10name"].ToString() + "','" + diatype + "','" + index.ToString() + "','" + drDiag["name"].ToString() + "','" + drDiag["pnumber"].ToString() + "','" + admiss_thing + "')");
                                Sqls.Add(sb.ToString());
                                //list.Add(sb.ToString());
                            }
                        }
                    }
                }
                #endregion

                #region ������Ϣ


                Sqls.Add("delete from pat_interface_operate where patient_id='" + patient_id + "'");
                //list.Add("delete from pat_interface_operate where patient_id='" + patient_id + "'");
                string sql = string.Empty;
                sql = string.Format("select a.oper_code,a.oper_name,a.oper_date,a.operator,a.oper_assist1,a.oper_assist2,a.anaes_method,a.anaesthetist,a.close_level,a.oper_level from cover_operation a where a.patient_id='{0}'", strId);
                DataSet dsOper = App.GetDataSet(sql);
                if (dsOper.Tables.Count > 0)
                {
                    if (dsOper.Tables[0].Rows.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        int index = 1;
                        foreach (DataRow drOper in dsOper.Tables[0].Rows)
                        {
                            sb = new StringBuilder();
                            if (drOper["oper_date"] == DBNull.Value || drOper["oper_date"].ToString().Trim().Length == 0)
                                break;
                            sb.Append("insert into pat_interface_operate(patient_id,visit_id,operate_no,operate_icd,operate_date,");
                            sb.Append("operate_name,operate_doctor_1,operate_doctor_2,operate_doctor_3,operate_mz,operate_doctor_mz,operate_qk,operate_type)");
                            sb.Append("values('" + patient_id + "'," + visit_id + ",'" + index.ToString() + "','" + drOper["oper_code"] + "','" + drOper["oper_date"].ToString() + "',");
                            string sOperName = drOper["oper_name"].ToString();
                            sOperName = App.GetStringList(sOperName, 50)[0];
                            sb.Append("'" + sOperName + "','" + drOper["operator"].ToString() + "','" + drOper["oper_assist1"].ToString() + "','" + drOper["oper_assist2"].ToString() + "',");
                            sb.Append("'" + drOper["anaes_method"].ToString() + "','" + drOper["anaesthetist"].ToString() + "','" + drOper["close_level"].ToString() + "','" + drOper["oper_level"].ToString() + "')");
                            Sqls.Add(sb.ToString());
                            //list.Add(sb.ToString());
                        }
                    }
                }
                #endregion

                #region ����������Ϣ
                Sqls.Add("delete from pat_interface_other where patient_id='" + patient_id + "'");
                //list.Add("delete from pat_interface_other where patient_id='" + patient_id + "'");  
                StringBuilder sb1 = new StringBuilder();
                sb1.Append("select a.medicinesensitive,a.xjpybbsj,a.blfx,a.Checkcorpse,a.blood_type,a.rh,a.outhospital,");
                sb1.Append("a.turntohospital,a.inagain,a.purpose,a.beforein_day,a.beforein_hour,a.beforein_minute,");
                sb1.Append("a.afterin_day,a.afterin_hour,a.afterin_minute,a.lcljgl,a.ssdrgs,a.dbzgl,a.ksssy,");
                sb1.Append("a.jh_day,a.jh_hour,a.fdcrb,a.zlfq_t,a.zlfq_n,a.zlfq_m1,a.zlfq_m2,a.baby_apgar,");
                sb1.Append("b.section_head,b.zr_doctor_name,b.zz_doctor_name,b.zy_doctor_name,");
                sb1.Append("b.jx_doctor_name,b.sx_doctor_name,b.coder_name,b.zr_nurse_name,b.q_doctor_name,b.q_nurse_name,b.quality,b.q_date,");
                sb1.Append("c.icd10name,c.pnumber");
                sb1.Append(" from cover_temp a ,cover_quality b left join cover_diagnose c on b.patient_id=c.patient_id and c.type='p'");
                sb1.Append("where a.patient_id=b.patient_id ");
                sb1.Append("and a.Patient_ID='" + strId + "'");
                DataSet dsOtherInfo = App.GetDataSet(sb1.ToString());
                if (dsOtherInfo.Tables.Count > 0)
                {
                    if (dsOtherInfo.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drOtherInfo in dsOtherInfo.Tables[0].Rows)
                        {
                            StringBuilder sb2 = new StringBuilder();
                            string strTemp = string.Empty;
                            sb2.Append("insert into pat_interface_other");
                            sb2.Append("(patient_id,visit_id,gmyw_hb,doctor_kzr,doctor_zrys,doctor_zzys,doctor_zyys,");
                            sb2.Append("doctor_jxys,doctor_sjys,doctor_bmy,doctor_bazl,doctor_zkys,doctor_zkhs,bafx,");
                            sb2.Append("other_sj,bloob_xx,rh,bl_name,bl_no,has_allergy_drugs,leave_hospital_type,");
                            sb2.Append("receive_hospital,readmission_plan,readmission_purpose,");
                            sb2.Append("pre_admission_coma_day,pre_admission_coma_hour,pre_admission_coma_minute,");
                            sb2.Append("af_admission_coma_day,af_admission_coma_hour,af_admission_coma_minute,");
                            sb2.Append("qc_date,charge_nurse,clinical_path_completion,DRGS_manage,single_disease,");
                            sb2.Append("antibiotic_use,intensive_care,intensive_care_day,intensive_care_hour,");
                            sb2.Append("legal_communicable,tumor_stage_t,tumor_stage_n,tumor_stage_m1,tumor_stage_m2,new_baby_score,specimen_check)");
                            sb2.Append("values(");
                            sb2.Append("'" + patient_id + "'," + visit_id + ",'" + drOtherInfo["medicinesensitive"].ToString() + "',");
                            sb2.Append("'" + drOtherInfo["section_head"].ToString() + "','" + drOtherInfo["zr_doctor_name"].ToString() + "',");
                            sb2.Append("'" + drOtherInfo["zz_doctor_name"].ToString() + "','" + drOtherInfo["zy_doctor_name"].ToString() + "',");
                            sb2.Append("'" + drOtherInfo["jx_doctor_name"].ToString() + "','" + drOtherInfo["sx_doctor_name"].ToString() + "',");
                            sb2.Append("'" + drOtherInfo["coder_name"].ToString() + "',");
                            strTemp = drOtherInfo["quality"].ToString();
                            sb2.Append("'" + (strTemp.Contains("��") ? "1" : (strTemp.Contains("��") ? "2" : (strTemp.Contains("��") ? "3" : "1"))) + "',");
                            sb2.Append("'" + drOtherInfo["q_doctor_name"].ToString() + "','" + drOtherInfo["q_nurse_name"].ToString() + "',");
                            strTemp = drOtherInfo["blfx"].ToString();
                            switch (strTemp)
                            {
                                case "A":
                                case"1":
                                    strTemp = "1";
                                    break;
                                case "B":
                                case"2":                               
                                    strTemp = "2";
                                    break;
                                case "C":
                                case"3":
                                    strTemp = "3";
                                    break;
                                case "D":
                                case"4":
                                    strTemp = "4";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["Checkcorpse"].ToString();
                            switch (strTemp)
                            {
                                case "��":
                                case"1":
                                    strTemp = "1";
                                    break;
                                case "��":
                                case"2":
                                    strTemp = "2";
                                    break;
                                default:
                                    strTemp = "";
                                    break;

                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["blood_type"].ToString();
                            switch (strTemp)
                            {
                                case "A":
                                case"1":
                                    strTemp = "1";
                                    break;
                                case "B":
                                case"2":
                                    strTemp = "2";
                                    break;
                                case "AB":
                                case"4":
                                    strTemp = "4";
                                    break;
                                case "O":
                                case"3":
                                    strTemp = "3";
                                    break;
                                case "����":
                                case "5":
                                    strTemp = "5";
                                    break;
                                case "δ��":
                                case "6":
                                    strTemp = "6";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["rh"].ToString();
                            switch (strTemp)
                            {
                                case "��":
                                case"1":
                                    strTemp = "1";
                                    break;
                                case "��":
                                case"2":
                                    strTemp = "2";
                                    break;
                                case "����":
                                case"3":
                                    strTemp = "3";
                                    break;
                                case "δ��":
                                case"4":
                                    strTemp = "4";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            sb2.Append("'" + drOtherInfo["icd10name"].ToString() + "','" + drOtherInfo["pnumber"].ToString() + "',");
                            sb2.Append("'" + (string.IsNullOrEmpty(drOtherInfo["medicinesensitive"].ToString().Trim()) ? "1" : "2") + "',");
                            strTemp = drOtherInfo["OUTHOSPITAL"].ToString();
                            if (strTemp == "ҽ����Ժ")
                            {
                                strTemp = "1";
                            }
                            else if (strTemp.Contains("ҽ��תԺ"))
                            {
                                strTemp = "2";
                            }
                            else if (strTemp.Contains("ҽ��ת����"))
                            {
                                strTemp = "3";
                            }
                            else if (strTemp == "��ҽ����Ժ")
                            {
                                strTemp = "4";
                            }
                            else if (strTemp == "����")
                            {
                                strTemp = "5";
                            }
                            else if (strTemp == "����")
                            {
                                strTemp = "9";
                            }
                            sb2.Append("'" + strTemp + "',");
                            sb2.Append("'" + drOtherInfo["turntohospital"].ToString() + "',");
                            sb2.Append("'" + (string.IsNullOrEmpty(drOtherInfo["inagain"].ToString()) ? "1" : (drOtherInfo["inagain"].ToString().Contains("��") ? "1" : "2")) + "',");
                            sb2.Append("'" + drOtherInfo["purpose"].ToString() + "',");
                            int temp = 0;
                            sb2.Append((int.TryParse(drOtherInfo["beforein_day"].ToString(), out temp) ? temp.ToString() : temp.ToString()) + ",");
                            temp = 0;
                            sb2.Append((int.TryParse(drOtherInfo["beforein_hour"].ToString(), out temp) ? temp.ToString() : temp.ToString()) + ",");
                            temp = 0;
                            sb2.Append((int.TryParse(drOtherInfo["beforein_minute"].ToString(), out temp) ? temp.ToString() : temp.ToString()) + ",");
                            temp = 0;
                            sb2.Append((int.TryParse(drOtherInfo["afterin_day"].ToString(), out temp) ? temp.ToString() : temp.ToString()) + ",");
                            temp = 0;
                            sb2.Append((int.TryParse(drOtherInfo["afterin_hour"].ToString(), out temp) ? temp.ToString() : temp.ToString()) + ",");
                            temp = 0;
                            sb2.Append((int.TryParse(drOtherInfo["afterin_minute"].ToString(), out temp) ? temp.ToString() : temp.ToString()) + ",");
                            strTemp = drOtherInfo["q_date"].ToString();
                            DateTime dttemp;
                            if (DateTime.TryParse(strTemp, out dttemp))
                            {
                                strTemp = dttemp.ToString("yyyy-MM-dd");
                                sb2.Append("'" + strTemp + "',");
                            }
                            else
                            {
                                sb2.Append("null,");
                            }
                            sb2.Append("'" + drOtherInfo["zr_nurse_name"].ToString() + "',");
                            strTemp = drOtherInfo["lcljgl"].ToString();
                            switch (strTemp)
                            {
                                case "δ����":
                                case "1":
                                    strTemp = "1";
                                    break;
                                case "�����˳�":
                                case "2":
                                    strTemp = "2";
                                    break;
                                case "���":
                                case "3":
                                    strTemp = "3";
                                    break;
                                default:
                                    strTemp = "";
                                    break;

                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["ssdrgs"].ToString();
                            switch (strTemp)
                            {
                                case "��":
                                case "1":
                                    strTemp = "1";
                                    break;
                                case "������":
                                case "2":
                                    strTemp = "2";
                                    break;
                                case "������":
                                case "3":
                                    strTemp = "3";
                                    break;
                                case "���߾���":
                                case "4":
                                    strTemp = "4";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["dbzgl"].ToString();
                            switch (strTemp)
                            {
                                case "��":
                                case "1":
                                    strTemp = "1";
                                    break;
                                case "��":
                                case "2":
                                    strTemp = "2";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["ksssy"].ToString();
                            switch (strTemp)
                            {
                                case "ʹ��":
                                case "1":
                                    strTemp = "1";
                                    break;
                                case "δʹ��":
                                case "2":
                                    strTemp = "2";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            //if(string.IsNullOrEmpty(drOtherInfo["jh_day"].ToString())&&string.IsNullOrEmpty(drOtherInfo["jh_hour"].ToString())
                            int jhday = 0, jhhour = 0;
                            if (int.TryParse(drOtherInfo["jh_day"].ToString(), out jhday) || int.TryParse(drOtherInfo["jh_hour"].ToString(), out jhhour))
                            {
                                if (jhday > 0 || jhhour > 0)
                                {
                                    sb2.Append("'2',");
                                }
                                else
                                {
                                    sb2.Append("'1',");
                                }
                            }
                            else
                            {
                                sb2.Append("'1',");
                            }
                            sb2.Append(jhday + "," + jhhour + ",");
                            strTemp = drOtherInfo["fdcrb"].ToString();
                            switch (strTemp)
                            {
                                case "����":
                                case"1":
                                    strTemp = "1";
                                    break;
                                case "����": 
                                case"2":
                                    strTemp = "2";
                                    break;
                                case "����":
                                case"3":
                                    strTemp = "3";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["zlfq_t"].ToString();
                            switch (strTemp)
                            {
                                case "0��":
                                case "1":
                                    strTemp = "1";
                                    break;
                                case "I��":
                                case "2":
                                    strTemp = "2";
                                    break;
                                case "II��":
                                case "3":
                                    strTemp = "3";
                                    break;
                                case "III��":
                                case "4":
                                    strTemp = "4";
                                    break;
                                case "IV��":
                                case "5":
                                    strTemp = "5";
                                    break;
                                case "����":
                                case "6":
                                    strTemp = "6";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["zlfq_n"].ToString();
                            switch (strTemp)
                            {
                                case "0��":
                                case "1":
                                    strTemp = "1";
                                    break;
                                case "I��":
                                case "2":
                                    strTemp = "2";
                                    break;
                                case "II��":
                                case "3":
                                    strTemp = "3";
                                    break;
                                case "III��":
                                case "4":
                                    strTemp = "4";
                                    break;
                                case "IV��":
                                case "5":
                                    strTemp = "5";
                                    break;
                                case "����":
                                case "6":
                                    strTemp = "6";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["zlfq_m1"].ToString();
                            switch (strTemp)
                            {
                                case "0��":
                                case "1":
                                    strTemp = "1";
                                    break;
                                case "I��":
                                case "2":
                                    strTemp = "2";
                                    break;
                                case "II��":
                                case "3":
                                    strTemp = "3";
                                    break;
                                case "III��":
                                case "4":
                                    strTemp = "4";
                                    break;
                                case "IV��":
                                case "5":
                                    strTemp = "5";
                                    break;
                                case "����":
                                case "6":
                                    strTemp = "6";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["zlfq_m2"].ToString();
                            switch (strTemp)
                            {
                                case "0��":
                                case "1":
                                    strTemp = "1";
                                    break;
                                case "I��":
                                case "2":
                                    strTemp = "2";
                                    break;
                                case "II��":
                                case "3":
                                    strTemp = "3";
                                    break;
                                case "III��":
                                case "4":
                                    strTemp = "4";
                                    break;
                                case "IV��":
                                case "5":
                                    strTemp = "5";
                                    break;
                                case "����":
                                case "6":
                                    strTemp = "6";
                                    break;
                                default:
                                    strTemp = "";
                                    break;
                            }
                            sb2.Append("'" + strTemp + "',");
                            strTemp = drOtherInfo["baby_apgar"].ToString();
                            if (int.TryParse(strTemp, out temp))
                            {
                                sb2.Append(temp.ToString()+",");
                            }
                            else
                            {
                                sb2.Append("null,");
                            }
                            sb2.Append("'" + drOtherInfo["xjpybbsj"] + "'");
                            sb2.Append(")");
                            Sqls.Add(sb2.ToString());
                            //list.Add(sb2.ToString());
                            sb2 = new StringBuilder("Update pat_interface set director='" + drOtherInfo["section_head"].ToString() + "' where patient_id='" + patient_id + "'");
                            Sqls.Add(sb2.ToString());
                            //list.Add(sb2.ToString());
                        }
                    }
                }
                #endregion

                #region �շ�
                #endregion
                //try
                //{
                //    if (App.WebService.ExecuteBatch_SqlSv(list.ToArray()) > 0)
                //    {
                //        //App.Msg("�����Ѿ��ɹ���");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    //App.MsgErr("����ʧ�ܣ�" + ex.Message.ToString());
                //    ex.Message.ToString();
                //}
            }
            
        }

        /// <summary>
        /// �ж��Ƿ�����ֵ����
        /// </summary>
        /// <returns></returns>
        private bool IsNum(string val)
        {
            try
            {
                float ff = Convert.ToSingle(val);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// �ַ�����ȡ
        /// </summary>
        /// <returns></returns>
        private string GetNewStr(string old_val, int VarcharLen)
        {
            try
            {
                string val = old_val;
                byte[] bytes = Encoding.Default.GetBytes(old_val);
                if (bytes.Length <= VarcharLen)
                {
                    return val;
                }
                else
                {

                    for (int i = 0; i < old_val.Length; i++)
                    {
                        string temp = old_val.Substring(0, i + 1);
                        bytes = Encoding.Default.GetBytes(temp);
                        if (bytes.Length > VarcharLen)
                        {
                            val = old_val.Substring(0, i);
                            break;
                        }
                    }
                }
                return val;
            }
            catch
            {
                return old_val;
            }
        }

        private void lblSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridViewX1.RowCount; i++)
                {
                    dataGridViewX1[0, i].Value = true;
                }
            }
            catch
            { }
        }

        private void lblCancelAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridViewX1.RowCount; i++)
                {
                    dataGridViewX1[0, i].Value = false;
                }
            }
            catch
            { }
        }

        private void btnPatientFee_Click(object sender, EventArgs e)
        {
            string sql = "select a.id,a.his_id from t_In_Patient a where a.document_state=1 and a.exe_document_time between to_date('" + dateTimePicker_start.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd') and to_date('" + dateTimePicker_End.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd')";
            DataSet dsPatient = App.GetDataSet(sql);
            if (dsPatient.Tables.Count > 0)
            {
                if (dsPatient.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in dsPatient.Tables[0].Rows)
                    {
                        try
                        {
                            His_Get_Cost(dr["his_id"].ToString(), dr["id"].ToString());
                        }
                        catch
                        {
                        }
                    }
                    App.Msg("��������ɣ�");
                }
            }
        }

        /// <summary>
        /// ��ȡHIS�ķ�����Ϣ
        /// </summary>
        private void His_Get_Cost(string His_Id,string Patient_ID)
        {
            //�ܷ���
            string total_Cost = "";
            //�Ը�����
            string seft_Cost = "";
            //�����
            string service_Cost = "";
            //������
            string operator_Cost ="";
            //�����
            string nurse_Cost = "";
            //������
            string other_Cost = "";
            //������Ϸ�
            string blzd_Cost = "";
            //ʵ������Ϸ�
            string syszd_Cost = "";
            //Ӱ��ѧ��Ϸ�
            string yxxzd_Cost = "";
            //�ٴ������Ŀ��
            string zdxm_Cost = "";
            //����ҩ�����
            string kjyw_Cost = "";
            //���������Ʒ�
            string fshszl_Cost = "";
            //�ٴ��������Ʒ�
            string wlzl_Cost ="";
            //�������Ʒ�
            string shszl_Cost = "";
            //�����
            string mz_Cost = "";
            //������
            string shs_Cost ="";
            //������
            string kf_Cost = "";
            //��ҽ���Ʒ�
            string zyzl_Cost = "";
            //��ҩ��
            string xy_Cost = "";
            //�г�ҩ��
            string zchy_Cost = "";
            //�в�ҩ��
            string zcy_Cost = "";
            //Ѫ��
            string xue_Cost = "";
            //�׵�������Ʒ��
            string bdbl_Cost = "";
            //�򵰰�����Ʒ��
            string qdbl_Cost = "";
            //��Ѫ��������Ʒ��
            string nxyzl_Cost = "";
            //ϸ����������Ʒ��
            string xbyzl_Cost = "";
            //���һ����ҽ�ò��Ϸ�
            string jccl_Cost = "";
            //����һ����ҽ�ò��Ϸ�
            string shscl_Cost ="";
            //����һ����ҽ�ò��Ϸ�
            string zlcl_Cost = "";
            //���������
            string qt_Cost = "";
            try
            {
                string sql = "select * from HNYZ_ZXYY.intf_emr_costview@DBHISLINK where zyh='" + His_Id + "'";
                DataSet ds_his_fee = App.GetDataSet(sql);

                /*
                 * ������Ϣ�Ķ�ȡ
                 */


                /*
                 * ��ȡС�����
                 */
                string sql_fee = "select code,bzdm from t_data_code where type=209";
                DataSet ds_fee = App.GetDataSet(sql_fee);

                /*
                 * ���ô���
                 */
                string sql_ba_cl = "select code from t_data_code where type=210";
                DataSet ds_ba_fee = App.GetDataSet(sql_ba_cl);

                #region ͨ�ü���
                for (int i = 0; i < ds_ba_fee.Tables[0].Rows.Count; i++)
                {
                    string bz = ds_ba_fee.Tables[0].Rows[i]["code"].ToString();

                    if (bz.Length < 2)
                    {
                        bz = "0" + bz;
                    }
                    if (bz == "01")
                    {
                        service_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, "");
                    }
                    else if (bz == "02")
                    {
                        operator_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, "");
                    }
                    else if (bz == "03")
                    {
                        nurse_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, "");
                    }
                    else if (bz == "04")
                    {
                        other_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, "");
                    }
                    else if (bz == "05")
                    {
                        blzd_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, "");
                    }
                    else if (bz == "06")
                    { syszd_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "07")
                    { yxxzd_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "08")
                    { zdxm_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "09")
                    { fshszl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "10")
                    { shszl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "11")
                    { kf_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "12")
                    { zyzl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "13")
                    { xy_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "14")
                    { zchy_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "15")
                    { zcy_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "16")
                    { xue_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "17")
                    { bdbl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "18")
                    { qdbl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "19")
                    { nxyzl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "20")
                    { xbyzl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "21")
                    { jccl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "22")
                    { zlcl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "23")
                    { shscl_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                    else if (bz == "24")
                    { qt_Cost = GetFeeSum(ds_his_fee, ds_fee, bz, ""); }
                }
                #endregion

                #region ���������
                //�ܷ���

                total_Cost = GetFeeSum(ds_his_fee, ds_fee, "", "");

                //�����
                mz_Cost = GetFeeSum(ds_his_fee, ds_fee, "", "039");

                //������
                shs_Cost = GetFeeSum(ds_his_fee, ds_fee, "", "037");

                #endregion

            }
            catch
            {

            }
            List<string> Sqls = new List<string>();
            Sqls.Add("delete convert_cost where PATIENT_ID='" + Patient_ID + "'");
            string Insert_Sql = string.Format("insert into convert_cost(total_cost,seft_cost,service_cost,operator_cost,nurse_cost,other_cost," +
                    " blzd_cost,syszd_cost,yxxzd_cost,zdxm_cost,fssxm_cost,wlzl_cost,sszl_cost,mz_cost,kjyw_cost," +
                    " kf_cost,zxzl_cost,xy_cost,zchy_cost,zcy_cost,xue_cost,bdbl_cost,qdbl_cost,nxyz_cost,xbyzl_cost," +
                    " jcyycl_cost,zlyycl_cost,ssyycl_cost,ol_cost,patient_id,Shs_Cost)values" +
                    " ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}'," +
                    " '{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}')",
                    total_Cost, seft_Cost, service_Cost, operator_Cost, nurse_Cost, other_Cost, blzd_Cost, syszd_Cost, yxxzd_Cost, zdxm_Cost,
                    fshszl_Cost, wlzl_Cost, shszl_Cost, mz_Cost, kjyw_Cost, kf_Cost, zyzl_Cost, xy_Cost, zchy_Cost, zcy_Cost,
                    xue_Cost, bdbl_Cost, qdbl_Cost, nxyzl_Cost, xbyzl_Cost, jccl_Cost, zlcl_Cost, shscl_Cost, qt_Cost, Patient_ID, shs_Cost);
            Sqls.Add(Insert_Sql);

            try
            {
                App.ExecuteBatch(Sqls.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        /// <summary>
        /// �����ܷ���
        /// </summary>
        /// <param name="ds_his_fee">HIS���ü���</param>
        /// <param name="ds_fee_code">�ҷ����ݿ���ô��뼯��</param>
        /// <param name="dl">���� ""�������з��õ�����</param>
        /// <param name="spacial_code"></param>
        /// <returns></returns>
        private string GetFeeSum(DataSet ds_his_fee, DataSet ds_fee_code, string dl, string spacial_code)
        {
            //ds_fee_code.Tables[0].Select("bzdm='" + dl + "'");
            try
            {
                float sumval = 0;

                for (int i = 0; i < ds_his_fee.Tables[0].Rows.Count; i++)
                {
                    string FYLBBM = ds_his_fee.Tables[0].Rows[i]["FYLBBM"].ToString();
                    string ZFY = ds_his_fee.Tables[0].Rows[i]["ZFY"].ToString();
                    if (dl != "")
                    {
                        //���������
                        if (ds_fee_code.Tables[0].Select("bzdm='" + dl + FYLBBM + "'").Length > 0)
                        {
                            sumval = sumval + Convert.ToSingle(ZFY);
                        }
                    }
                    else
                    {
                        if (spacial_code == "")
                        {
                            //��������
                            sumval = sumval + Convert.ToSingle(ZFY);
                        }
                        else
                        {
                            //�������
                            if (FYLBBM == spacial_code)
                            {
                                return ZFY;
                            }
                        }
                    }
                }

                return sumval.ToString();
            }
            catch
            {
                return "0";
            }
        }
    }
}