using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Bifrost
{
    public class InPatientInfo:IComparer
    {
        private int _id;
        private string _patient_Name;
        private string _name_Pinyin;
        private string _gender_Code;
        private string _birthday;
        private string _marrige_State;
        private string _bloodtype_ABO;
        private float _height;
        private float _weight;
        private string _pId;
        private string _religion;
        private string _country;
        private string _culture_level;
        private string _natiye_place;
        private string birth_place;
        private string folk_code;
        private string _career;
        private string _position;
        private string _cer_type;
        private string _medicare_no;
        private string _home_address;
        private string _homePostal_code;
        private string _home_phone;
        private string _office;
        private string _office_address;
        private string _office_phone;
        private string _relation_name;
        private string _relation;
        private string _relation_address;
        private string _relation_phone;
        private string _relationPos_code;
        private string _create_time;
        private string _officePos_code;
        private string _age;
        private string _age_unit;
        private int _inHospital_count;
        private string _bloodtype_Rh;
        private float _total_Fee;
        private string _cert_Id;
        private string _state;
        private string _patient_Id;
        private int _patient_Mr;
        private int _section_Id;
        private string _section_Name;
        private int _insection_Id;
        private string _insection_Name;
        private string _in_Doctor_Id;
        private string _in_Doctor_Name;
        private string _sick_Doctor_Id;
        private string _sick_Doctor_Name;
        private string _user_Id;
        private string _in_Area_Id;
        private string _in_Area_Name;
        private string sike_Area_Id;
        private string _sick_Area_Name;
        private int _in_Room_Id;
        private string _in_Room_Name;
        private int _sick_Room_Id;
        private string _sick_Room_Name;
        private int _sick_Group_Id;
        private string _sick_Group_Name;
        private int _in_Treatgroup_Id;
        private string _in_Treatgroup_Name;
        private int _sick_Bed_Id;
        private string _sick_Bed_Name;
        private int _in_Bed_Id;
        private string _in_Bed_Name;
        private float _pre_Pay;
        private string _nurse_Level;
        private DateTime _in_Time;
        private string _reg_In_Time;
        private string _sick_Degree;
        private string _inhospital_Id;
        private string _from_Hospital;
        private string _fee_Type;
        private string _assist_Check;
        private string _leave_Time;
        private string _pay_Manager;
        private int _real_Indays;
        private string _out_Id;
        private string _out_Mrid;
        private string _mrrecord_Time;
        private string _intime_Real;
        private string _document_State;
        private string _in_Approach;
        private string _in_Circs;
        private string _in_Sec_Approach;
        private string _is_Create_Index;
        private string _leavetime_Real;
        private string _Relater_Mr;
        private string _relianstate;
        private string _action_State;
        private int _die_flag;
        private string _card_Id;
        private DateTime _die_time;

        private bool _IsHaveRight;

        private char _IsChangeSection;

        private string _path_state;

        private string his_id;
        private string now_address;
        private string now_addres_postno;
        private string now_addres_phone;
        private string health_card_no;
        private string bornweight;
        private string inweight;
        private string property_flag;
        private string career_other;
        private string sick_doc_no;


        private string patientState;

        private string child_age;

        private string exe_document_time;

        private string _Sick_Nurse_Name;
        private string _Sick_Nurse_Id;


        #region 爱德堡:三级医师
        /// <summary>
        /// 住院医师id
        /// </summary>
        private int resident_Doctor_Id;

        public int Resident_Doctor_Id
        {
            get { return resident_Doctor_Id; }
            set { resident_Doctor_Id = value; }
        }
        /// <summary>
        /// 住院医师姓名
        /// </summary>
        private string resident_Doctor_Name;

        public string Resident_Doctor_Name
        {
            get { return resident_Doctor_Name; }
            set { resident_Doctor_Name = value; }
        }
        /// <summary>
        /// 主治医师id
        /// </summary>
        private int charge_Doctor_Id;

        public int Charge_Doctor_Id
        {
            get { return charge_Doctor_Id; }
            set { charge_Doctor_Id = value; }
        }
        /// <summary>
        /// 主治医师姓名
        /// </summary>
        private string charge_Doctor_Name;

        public string Charge_Doctor_Name
        {
            get { return charge_Doctor_Name; }
            set { charge_Doctor_Name = value; }
        }
        /// <summary>
        /// 主任医师id
        /// </summary>
        private int chief_Doctor_Id;

        public int Chief_Doctor_Id
        {
            get { return chief_Doctor_Id; }
            set { chief_Doctor_Id = value; }
        }
        /// <summary>
        ///主任医师姓名
        /// </summary>
        private string chief_Doctor_Name;

        public string Chief_Doctor_Name
        {
            get { return chief_Doctor_Name; }
            set { chief_Doctor_Name = value; }
        }
        #endregion



        public InPatientInfo() { }

        //public InPatientInfo(int id, string patient_Name, string name_Pinyin, string gender_Code,
        //    string birthday,string marrige_State,string bloodtype_ABO,float height,float weight,
        //    string pId, string religion, string country, string culture_level,string natiye_place,
        //    string birth_place, string folk_code, string career, string position, string cer_type,
        //    string medicare_no, string home_address, string homePostal_code, string home_phone, string office,
        //    string office_address,string )
        //{
        
        //}

        public InPatientInfo(int id, string patient_Name, string gender_Code,string birthday,string pId,string age,string action_State,string age_Unit,string sick_Danger,string nurse_Leavel)
        {
            this.Id = id;
            this.Patient_Name = patient_Name;
            this.Gender_Code = gender_Code;
            this.Birthday = birthday;
            this.PId = pId;
            this.Age = age;
            this.Action_State = action_State;
            this.Age_unit = age_Unit;
            this.Sick_Degree = sick_Danger;
            this.Nurse_Level = nurse_Leavel;
        }
        public string Action_State
        {
            get { return _action_State; }
            set { _action_State = value; }
        }
        public string Relianstate
        {
            get { return _relianstate; }
            set { _relianstate = value; }
        }
        public string Relater_Mr
        {
            get { return _Relater_Mr; }
            set { _Relater_Mr = value; }
        }
        public string Leavetime_Real
        {
            get { return _leavetime_Real; }
            set { _leavetime_Real = value; }
        }
        public string Is_Create_Index
        {
            get { return _is_Create_Index; }
            set { _is_Create_Index = value; }
        }
        public string In_Sec_Approach
        {
            get { return _in_Sec_Approach; }
            set { _in_Sec_Approach = value; }
        }
        public string In_Circs
        {
            get { return _in_Circs; }
            set { _in_Circs = value; }
        }
        public string In_Approach
        {
            get { return _in_Approach; }
            set { _in_Approach = value; }
        }
        public string Document_State
        {
            get { return _document_State; }
            set { _document_State = value; }
        }
        public string Intime_Real
        {
            get { return _intime_Real; }
            set { _intime_Real = value; }
        }
        public string Mrrecord_Time
        {
            get { return _mrrecord_Time; }
            set { _mrrecord_Time = value; }
        }
        public string Out_Mrid
        {
            get { return _out_Mrid; }
            set { _out_Mrid = value; }
        }
        public string Out_Id
        {
            get { return _out_Id; }
            set { _out_Id = value; }
        }
        public int Real_Indays
        {
            get { return _real_Indays; }
            set { _real_Indays = value; }
        }
        public string Pay_Manager
        {
            get { return _pay_Manager; }
            set { _pay_Manager = value; }
        }
        public string Leave_Time
        {
            get { return _leave_Time; }
            set { _leave_Time = value; }
        }
        public string Assist_Check
        {
            get { return _assist_Check;}
            set { _assist_Check = value;}
        }
        public string Fee_Type
        {
            get { return _fee_Type; }
            set { _fee_Type = value; }
        }
        public string From_Hospital
        {
            get { return _from_Hospital;}
            set { _from_Hospital = value;}
        }
        public string Inhospital_Id
        {
            get { return _inhospital_Id;}
            set { _inhospital_Id = value;}
        }
        public string Sick_Degree
        {
            get { return _sick_Degree;}
            set { _sick_Degree = value;}
        }
        public string Reg_In_Time
        {
            get { return _reg_In_Time;}
            set { _reg_In_Time = value;}
        }
        public DateTime In_Time
        {
            get { return _in_Time;}
            set { _in_Time = value;}
        }
        public string Nurse_Level
        {
            get { return _nurse_Level; }
            set { _nurse_Level = value; }
        }
        public float Pre_Pay
        {
            get { return _pre_Pay; }
            set { _pre_Pay = value; }
        }
        public string In_Bed_Name
        {
            get { return _in_Bed_Name; }
            set { _in_Bed_Name = value; }
        }
        public int In_Bed_Id
        {
            get { return _in_Bed_Id; }
            set { _in_Bed_Id = value; }
        }
        public string Sick_Bed_Name
        {
            get { return _sick_Bed_Name; }
            set { _sick_Bed_Name = value; }
        }
        public int Sick_Bed_Id
        {
            get { return _sick_Bed_Id; }
            set { _sick_Bed_Id = value; }
        }
        public string In_Treatgroup_Name
        {
            get { return _in_Treatgroup_Name; }
            set { _in_Treatgroup_Name = value; }
        }
        public int In_Treatgroup_Id
        {
            get { return _in_Treatgroup_Id; }
            set { _in_Treatgroup_Id = value; }
        }
        public string Sick_Group_Name
        {
            get { return _sick_Group_Name; }
            set { _sick_Group_Name = value; }
        }
        public int Sick_Group_Id
        {
            get { return _sick_Group_Id; }
            set { _sick_Group_Id = value; }
        }
        public string Sick_Room_Name
        {
            get { return _sick_Room_Name; }
            set { _sick_Room_Name = value; }
        }
        public int Sick_Room_Id
        {
            get { return _sick_Room_Id; }
            set { _sick_Room_Id = value; }
        }
        public string In_Room_Name
        {
            get { return _in_Room_Name; }
            set { _in_Room_Name = value; }
        }
        public int In_Room_Id
        {
            get { return _in_Room_Id; }
            set { _in_Room_Id = value; }
        }
        public string Sick_Area_Name
        {
            get { return _sick_Area_Name; }
            set { _sick_Area_Name = value; }
        }
        public string Sike_Area_Id
        {
            get { return sike_Area_Id;}
            set { sike_Area_Id = value;}
        }
        public string In_Area_Name
        {
            get { return _in_Area_Name;}
            set { _in_Area_Name = value;}
        }
        public string In_Area_Id
        {
            get { return _in_Area_Id;}
            set { _in_Area_Id = value;}
        }
        public string User_Id
        {
            get { return _user_Id;}
            set { _user_Id = value;}
        }
        public string Sick_Doctor_Name
        {
            get { return _sick_Doctor_Name;}
            set { _sick_Doctor_Name = value;}
        }
        public string Sick_Nurse_Id
        {
            get { return _Sick_Nurse_Id; }
            set { _Sick_Nurse_Id = value; }
        }
        public string Sick_Nurse_Name
        {
            get { return _Sick_Nurse_Name; }
            set { _Sick_Nurse_Name = value; }
        }
        public string Sick_Doctor_Id
        {
            get { return _sick_Doctor_Id;}
            set { _sick_Doctor_Id = value;}
        }
        public string In_Doctor_Name
        {
            get { return _in_Doctor_Name; }
            set { _in_Doctor_Name = value; }
        }


        public string In_Doctor_Id
        {
            get { return _in_Doctor_Id; }
            set { _in_Doctor_Id = value; }
        }
        public string Insection_Name
        {
            get { return _insection_Name; }
            set { _insection_Name = value; }
        }
        public int Insection_Id
        {
            get { return _insection_Id; }
            set { _insection_Id = value; }
        }
        public string Section_Name
        {
            get { return _section_Name; }
            set { _section_Name = value; }
        }
        public int Section_Id
        {
            get { return _section_Id; }
            set { _section_Id = value; }
        }
        public int Patient_Mr
        {
            get { return _patient_Mr; }
            set { _patient_Mr = value; }
        }

        public string Patient_Id
        {
            get { return _patient_Id; }
            set { _patient_Id = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string Cert_Id
        {
            get { return _cert_Id; }
            set { _cert_Id = value; }
        }
        public float Total_Fee
        {
            get { return _total_Fee; }
            set { _total_Fee = value; }
        }
        public string Bloodtype_Rh
        {
            get { return _bloodtype_Rh; }
            set { _bloodtype_Rh = value; }
        }
        public int InHospital_count
        {
            get { return _inHospital_count; }
            set { _inHospital_count = value; }
        }

        public string Age_unit
        {
          get { return _age_unit; }
          set { _age_unit = value; }
        }
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string OfficePos_code
        {
            get { return _officePos_code; }
            set { _officePos_code = value; }
        }
        public string Create_time
        {
            get { return _create_time; }
            set { _create_time = value; }
           
        }
        public string RelationPos_code
        {
            get { return _relationPos_code; }
            set { _relationPos_code = value; }
        }
        public string Relation_phone
        {
            get { return _relation_phone; }
            set { _relation_phone = value; }
        }
        public string Relation_address
        {
            get { return _relation_address; }
            set { _relation_address = value; }
        }
        public string Relation
        {
            get { return _relation; }
            set { _relation = value; }
        }
        public string Relation_name
        {
            get { return _relation_name; }
            set { _relation_name = value; }
        }

        public string Office_phone
        {
            get { return _office_phone; }
            set { _office_phone = value; }
        }
        public string Office_address
        {
            get { return _office_address; }
            set { _office_address = value; }
        }
        public string Office
        {
            get { return _office; }
            set { _office = value; }
        }
        public string Home_phone
        {
            get { return _home_phone; }
            set { _home_phone = value; }
        }
        public string HomePostal_code
        {
            get { return _homePostal_code; }
            set { _homePostal_code = value; }
        }
        public string Home_address
        {
          get { return _home_address; }
          set { _home_address = value; }
        }
                public string Medicare_no
        {
            get { return _medicare_no; }
            set { _medicare_no = value; }
        }
        public string Cer_type
        {
          get { return _cer_type; }
          set { _cer_type = value; }
        }
     
        public string Position
        {
            get { return _position; }
            set { _position = value; }
        }
        public string Career
        {
            get { return _career; }
            set { _career = value; }
        }

        public string Folk_code
        {
            get { return folk_code; }
            set { folk_code = value; }
        }

        public string Birth_place
        {
            get { return birth_place; }
            set { birth_place = value; }
        }
        public string Natiye_place
        {
            get { return _natiye_place; }
            set { _natiye_place = value; }
        }
        public string Culture_level
        {
            get { return _culture_level; }
            set { _culture_level = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string Religion
        {
            get { return _religion; }
            set { _religion = value; }
        }
        public string PId
        {
            get { return _pId; }
            set { _pId = value; }
        }
        public float Weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public string Bloodtype_ABO
        {
            get { return _bloodtype_ABO; }
            set { _bloodtype_ABO = value; }
        }
        public string Marrige_State
        {
            get { return _marrige_State; }
            set { _marrige_State = value; }
        }
        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }
        public string Gender_Code
        {
            get { return _gender_Code; }
            set { _gender_Code = value; }
        }
        public string Name_Pinyin
        {
            get { return _name_Pinyin; }
            set { _name_Pinyin = value; }
        }

        public string Patient_Name
        {
            get { return _patient_Name; }
            set { _patient_Name = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Die_flag
        {
            get { return _die_flag; }
            set { _die_flag = value; }
        }

        public string Card_Id
        {
            get { return _card_Id; }
            set { _card_Id = value; }
        }

        public DateTime Die_time
        {
            get { return _die_time; }
            set { _die_time = value; }
        }

        /// <summary>
        /// 是否被授权
        /// </summary>
        public bool IsHaveRight
        {
            get { return _IsHaveRight; }
            set { _IsHaveRight = value; }
        }

        /// <summary>
        /// 是否转科
        /// </summary>
        public char IsChangeSection
        {
            get { return _IsChangeSection; }
            set { _IsChangeSection = value; }
        }

        /// <summary>
        /// 临床路径状态
        /// </summary>
        public string Path_state
        {
            get { return _path_state; }
            set { _path_state = value; }
        }

        /// <summary>
        /// 记录HIS的主键
        /// </summary>
        public string His_id
        {
            get { return his_id; }
            set { his_id = value; }
        }

        /// <summary>
        /// 现住地址
        /// </summary>
        public string Now_address
        {
            get { return now_address; }
            set { now_address = value; }
        }

        /// <summary>
        /// 现住地址邮编
        /// </summary>
        public string Now_addres_postno
        {
            get { return now_addres_postno; }
            set { now_addres_postno = value; }
        }

        /// <summary>
        ///现住地址电话 
        /// </summary>
        public string Now_addres_phone
        {
            get { return now_addres_phone; }
            set { now_addres_phone = value; }
        }

        /// <summary>
        /// 健康卡号
        /// </summary>
        public string Health_card_no
        {
            get { return health_card_no; }
            set { health_card_no = value; }
        }

       
        /// <summary>
        /// 新生儿出生体重
        /// </summary>
        public string Bornweight
        {
            get { return bornweight; }
            set { bornweight = value; }
        }
        /// <summary>
        /// 新生儿入院体重
        /// </summary>
        public string Inweight
        {
            get { return inweight; }
            set { inweight = value; }
        }

        /// <summary>
        /// 病人性质标志 1, 2
        /// </summary>
        public string Property_flag
        {
            get { return property_flag; }
            set { property_flag = value; }
        }

        /// <summary>
        /// 其他职业手填部分
        /// </summary>
        public string Career_other
        {
            get { return career_other; }
            set { career_other = value; }
        }

        /// <summary>
        /// 病案号
        /// </summary>
        public string Sick_doc_no
        {
            get { return sick_doc_no; }
            set { sick_doc_no = value; }
        }

        /// <summary>
        /// 病人状态：“借阅”，“授权”
        /// 病案借阅和文书授权的病人状态
        /// </summary>
        public string PatientState
        {
            get { return patientState; }
            set { patientState = value; }
        }

        /// <summary>
        /// 不满一周岁的儿童年龄
        /// </summary>
        public string Child_age
        {
            get { return child_age; }
            set { child_age = value; }
        }
        /// <summary>
        /// 归档时间
        /// </summary>
        public string Exe_document_time
        {
            get { return exe_document_time; }
            set { exe_document_time = value; }
        }
        //袁杨添加  江苏徐州项目组使用    141230
        private string now_addres_PostNo;
        public string Now_addres_PostNo
        {
            get { return now_addres_PostNo; }
            set { now_addres_PostNo = value; }
        }
        private string nornWeight;
        public string BornWeight
        {
            get { return nornWeight; }
            set { nornWeight = value; }
        }

        /// <summary>
        /// 质控级别
        /// </summary>
        public string Quality_Level { get; set; }

        /// <summary>
        /// 授权操作
        /// </summary>
        public string Grant_Action { get; set; }

        /// <summary>
        /// 授权开始时间
        /// </summary>
        public DateTime Grant_Begin_Time { get; set; }

        /// <summary>
        /// 授权结束时间
        /// </summary>
        public DateTime Grant_End_Time { get; set; }

        /// <summary>
        /// 患者类型
        /// 1:在科、2:出院未归档、3:转科、4:授权
        /// </summary>
        public string PatientType { get; set; }

        /// <summary>
        /// 诊疗组id
        /// </summary>
        public string Tng_Id { get; set; }

        /// <summary>
        /// 诊疗组名称
        /// </summary>
        public string Tng_Name { get; set; }


        /// <summary>
        /// 病案首页类型 null未选择 1中医 2西医
        /// </summary>
        public string CASEFIRST_FLAG { get; set; }


        /// <summary>
        /// 转科时间
        /// </summary>
        public DateTime Transfer_Date { get; set; }

        /// <summary>
        /// 责任护士id
        /// </summary>
        public int Charge_Nurser_Id { get; set; }

        /// <summary>
        /// 责任护士名称
        /// </summary>
        public string Charge_Nurser_Name { get; set; }

        /// <summary>
        /// 出院状态描述
        /// </summary>
        public string Die_Flag_Desc { get; set; }

        /// <summary>
        /// 质控分值
        /// </summary>
        public string Score { get; set; }

        #region IComparer 成员
        public int Compare(object x, object y)
        {
            try
            {
                InPatientInfo inpatient1 = x as InPatientInfo;
                InPatientInfo inpatient2 = y as InPatientInfo;
                string bed_No1 = inpatient1.Sick_Bed_Name;
                string bed_No2 = inpatient2.Sick_Bed_Name;
                int count = 0;
                for (int i = 0; i < bed_No1.Length; i++)
                {
                    char a = bed_No1[i];
                    char b = bed_No2[i];
                    count = a.CompareTo(b);
                    if (count > 0 || count < 0)
                    {
                        break;
                    }
                }
                return count;
            }
            catch
            {
                return 0;
            }
        }
        #endregion
    }
}
