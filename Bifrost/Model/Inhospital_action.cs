using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
   public class Inhospital_action
    {
       /// <summary>
       /// 异动id
       /// </summary>
       private int _id;
       /// <summary>
       /// 来源科室id
       /// </summary>
       private int _sid;
       /// <summary>
       /// 来源病区id
       /// </summary>
       private int _said;
       /// <summary>
       /// 病人id
       /// </summary>
       private string _pid;
       /// <summary>
       /// 异动类型
       /// </summary>
       private string _action_Type;
       /// <summary>
       /// 异动状态
       /// </summary>
       private string _action_State;
       /// <summary>
       /// 发生时间
       /// </summary>
       private string _happen_Time;
       /// <summary>
       /// 当前床号
       /// </summary>
       private int _bed_Id;
       /// <summary>
       /// 诊疗护理组id
       /// </summary>
       private int _tng_Id;
       /// <summary>
       /// 当前管床医生id
       /// </summary>
       private string _doctor_Id;
       /// <summary>
       /// 当前管床护士id
       /// </summary>
       private string _nurse_Id;
       /// <summary>
       /// 当前操作Id
       /// </summary>
       private int _operate_Id;
       /// <summary>
       /// 指针，指向下一条记录
       /// </summary>
       private int _next_Id;

       /// <summary>
       /// 指针，指向上一条
       /// </summary>
       private int _preview_Id;
       /// <summary>
       /// 目标病区id
       /// </summary>
       private int _target_Said;
       /// <summary>
       /// 目标科室Id
       /// </summary>
       private int _target_Sid;
       /// <summary>
       /// 带参数的构造函数
       /// </summary>
       public Inhospital_action(int id,int sid,int said,string pid,string action_type,
                                string action_state,string happen_time,int bed_id,int tng_id,
                                string doctor_id,string nurse_id,int operate_id,int next_id,
                                int preview_id,int target_said,int target_sid)
       {
           this.Id = id;
           this.Sid = sid;
           this.Said = said;
           this.Pid = pid;
           this.Action_Type = action_type;
           this.Action_State = action_state;
           this.Happen_Time = happen_time;
           this.Bed_Id = bed_id;
           this.Tng_Id = tng_id;
           this.Doctor_Id = doctor_id;
           this.Nurse_Id = nurse_id;
           this.Operate_Id = operate_id;
           this.Next_Id = next_id;
           this.Preview_Id = preview_id;
           this.Target_Said = target_said;
           this.Target_Sid = target_sid;
       }

       /// <summary>
       /// 空的构造函数
       /// </summary>
       public Inhospital_action()
       { 
       
       }
       public int Target_Sid
       {
           get { return _target_Sid; }
           set { _target_Sid = value; }
       }
       public int Target_Said
       {
           get { return _target_Said; }
           set { _target_Said = value; }
       }
       public int Preview_Id
       {
           get { return _preview_Id; }
           set { _preview_Id = value; }
       }
       public int Next_Id
       {
           get { return _next_Id; }
           set { _next_Id = value; }
       }
       public int Operate_Id
       {
           get { return _operate_Id; }
           set { _operate_Id = value; }
       }
       public string Nurse_Id
       {
           get { return _nurse_Id; }
           set { _nurse_Id = value; }
       }
       public string Doctor_Id
       {
           get { return _doctor_Id; }
           set { _doctor_Id = value; }
       }
       public int Tng_Id
       {
           get { return _tng_Id; }
           set { _tng_Id = value; }
       }
       public int Bed_Id
       {
           get { return _bed_Id; }
           set { _bed_Id = value; }
       }
       public string Happen_Time
       {
           get { return _happen_Time; }
           set { _happen_Time = value; }
       }
       public string Action_State
       {
           get { return _action_State; }
           set { _action_State = value; }
       }
       public string Action_Type
       {
           get { return _action_Type; }
           set { _action_Type = value; }
       }
       public string Pid
       {
           get { return _pid; }
           set { _pid = value; }
       }
       public int Said
       {
           get { return _said; }
           set { _said = value; }
       }

       public int Sid
       {
           get { return _sid; }
           set { _sid = value; }
       }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
