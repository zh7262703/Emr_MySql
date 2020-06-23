using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   public class Patient_Doc
    {
       private int _id;
       private string _pid;
       private int _textkind_id;
       private string _patients_doc;
       private int _belongtosys_id;
       private int _sickkind_id;
       private string _textname;
       private string _submitted;
       private string _createid;      
       private string patient_id;
       private string ishighersign;
       private string havehighersign;
       private string havedoctorsign;
       private string highersignuserid;
       private string isreplacehighdoctor;
       private string isreplacehighdoctor2;
       private string docname;
       private string section_name;
       private string isnewpage;
       private string bed;
       private int parentid;
       private string operateid;
       private string charge_doctor_id;
       private string chief_doctor_id;
       private string _createname;
       private string isproblem_name;
       private string isproblem_time;
       private string guid_doctor_id;
       private string right_range;

      
                     
       public Patient_Doc()
       { }
       public Patient_Doc(int id,string pid,int textkind_id,string patients_doc,
                          int belongosys_id, int sickkind_id, string textName, 
                          string Ishigher_sign, string Havehigher_sign, 
                          string Havedoctor_sign, string Highersign_userid,
                          int Parentid, string Operateid, string Charge_doctor_id, string Chief_doctor_id)
       {
           this.Id = id;
           this.Pid = pid;
           this.Textkind_id = textkind_id;
           this.Patients_doc = patients_doc;
           this.Belongtosys_id = belongosys_id;
           this.Sickkind_id = sickkind_id;
           this.Textname = textName;
           this.Ishighersign = Ishigher_sign;
           this.Havehighersign = Havehigher_sign;
           this.Havedoctorsign = Havedoctor_sign;
           this.Highersignuserid = Highersign_userid;
           this.Parentid = Parentid;
           this.Operateid = Operateid;
           this.Charge_doctor_id = Charge_doctor_id;
           this.Chief_doctor_id = Chief_doctor_id;
       }
       /// <summary>
       /// 文书id
       /// </summary>
       public int Id
       {
            get { return _id; }
            set { _id = value; }
       }
       /// <summary>
       /// 病人id
       /// </summary>
       public string Pid
       {
          get { return _pid; }
          set { _pid = value; }
       }
       /// <summary>
       /// 文书类别id
       /// </summary>
       public int Textkind_id
       {
           get { return _textkind_id; }
           set { _textkind_id = value; }
       }
       /// <summary>
       /// 内容
       /// </summary>
       public string Patients_doc
       {
           get { return _patients_doc; }
           set { _patients_doc = value; }
       }
       /// <summary>
       /// 所属系统疾病ID
       /// </summary>
       public int Belongtosys_id
       {
           get { return _belongtosys_id; }
           set { _belongtosys_id = value; }
       }
       /// <summary>
       /// 病种类ID
       /// </summary>
       public int Sickkind_id
       {
           get { return _sickkind_id; }
           set { _sickkind_id = value; }
       }

       /// <summary>
       /// 是否 N 暂存 Y提交
       /// </summary>
       public string Submitted
       {
           get { return _submitted; }
           set { _submitted = value; }
       }

       /// <summary>
       /// 文书名称
       /// </summary>
       public string Textname
       {
           get { return _textname; }
           set { _textname = value; }
       }

       /// <summary>
       /// 病人主键
       /// </summary>
       public string Patient_id
       {
           get { return patient_id; }
           set { patient_id = value; }
       }

       /// <summary>
       /// 创建人
       /// </summary>
       public string Createid
       {
           get { return _createid; }
           set { _createid = value; }
       }


       /// <summary>
       /// 是否需要上级医生签名 Y 是 N否
       /// </summary>
       public string Ishighersign
       {
           get { return ishighersign; }
           set { ishighersign = value; }
       }

       /// <summary>
       /// 是否已经有上级医师签名
       /// </summary>
       public string Havehighersign
       {
           get { return havehighersign; }
           set { havehighersign = value; }
       }

       /// <summary>
       /// 是否有管床医生签字
       /// </summary>
       public string Havedoctorsign
       {
           get { return havedoctorsign; }
           set { havedoctorsign = value; }
       }

       /// <summary>
       /// 上级医师的ID
       /// </summary>
       public string Highersignuserid
       {
           get { return highersignuserid; }
           set { highersignuserid = value; }
       }

       /// <summary>
       /// 是否代替上级医师签名 0或空 否 1是
       /// </summary>
       public string Isreplacehighdoctor
       {
           get { return isreplacehighdoctor; }
           set { isreplacehighdoctor = value; }
       }

       /// <summary>
       /// 是否代替主任签名 0或空 否 1是
       /// </summary>
       public string Isreplacehighdoctor2
       {
           get { return isreplacehighdoctor2; }
           set { isreplacehighdoctor2 = value; }
       }

       /// <summary>
       /// 文书名称
       /// </summary>
       public string Docname
       {
           get { return docname; }
           set { docname = value; }
       }
       
       /// <summary>
       /// 科室名称
       /// </summary>
       public string Section_name
       {
           get { return section_name; }
           set { section_name = value; }
       }

       /// <summary>
       /// 是否需要分页打印 0 否 1是
       /// </summary>
       public string Isnewpage
       {
           get { return isnewpage; }
           set { isnewpage = value; }
       }

       /// <summary>
       /// 床号
       /// </summary>
       public string Bed
       {
           get { return bed; }
           set { bed = value; }
       }

       /// <summary>
       /// 父节点
       /// </summary>
       public int Parentid
       {
           get { return parentid; }
           set { parentid = value; }
       }

       /// <summary>
       /// 最后提交者
       /// </summary>
       public string Operateid
       {
           get { return operateid; }
           set { operateid = value; }
       }
       /// <summary>
       /// 主治医师签字
       /// </summary>
       public string Charge_doctor_id
       {
           get { return charge_doctor_id; }
           set { charge_doctor_id = value; }
       }
       /// <summary>
       /// 主任医师签字
       /// </summary>
       public string Chief_doctor_id
       {
           get { return chief_doctor_id; }
           set { chief_doctor_id = value; }
       }
       /// <summary>
       /// 创建者
       /// </summary>
       public string Createname
       {
           get { return _createname; }
           set { _createname = value; }
       }

       /// <summary>
       /// 是否可编辑标题内容
       /// </summary>
       public string Isproblem_name
       {
           get { return isproblem_name; }
           set { isproblem_name = value; }
       }

       /// <summary>
       /// 是否可编辑标题时间
       /// </summary>
       public string Isproblem_time
       {
           get { return isproblem_time; }
           set { isproblem_time = value; }
       }

        /// <summary>
        /// 最后操作人的带教医生id
        /// </summary>
       public string Guid_doctor_id
       {
           get { return guid_doctor_id; }
           set { guid_doctor_id = value; }
       }


       /// <summary>
       /// 文书所属类型:D医生 N护士 A所有
       /// </summary>
       public string Right_range
       {
           get { return right_range; }
           set { right_range = value; }
       }
    }
}
