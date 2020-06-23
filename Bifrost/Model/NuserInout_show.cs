using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    ///  功能：显示出入液量记录单表格数据的类
    ///  作者：卢星星
    ///  时间：2010-04-14
    /// </summary>
   public class NuserInout_show
   {
       /// <summary>
       /// 日期
       /// </summary>
       private string _date;
       /// <summary>
       /// 时间
       /// </summary>
       private string _time; 
       /// <summary>
       /// 口入
       /// </summary>
       private string _item_Mouth;
       /// <summary>
       /// 管入
       /// </summary>
       private string _item_Tube;
       /// <summary>
       /// 经静脉入
       /// </summary>
       private string _imte_Intravenous;
       /// <summary>
       /// 实入量
       /// </summary>
       private string _the_Real;
       /// <summary>
       /// 尿量
       /// </summary>
       private string _urine;
       /// <summary>
       /// 大便
       /// </summary>
       private string _defecate;
       /// <summary>
       /// 呕吐
       /// </summary>
       private string _vomiting;
       /// <summary>
       /// 引流
       /// </summary>
       private string _drainage;
       /// <summary>
       /// 引流出量
       /// </summary>
       private string _drainage_value;

       /// <summary>
       /// 渗血渗液
       /// </summary>
       private string _Oozing_drainage;
       /// <summary>
       /// 记录人
       /// </summary>
       private string _operater;
       /// <summary>
       /// 空的构造函数
       /// </summary>
       public NuserInout_show() { }

       /// <summary>
       /// 带惨的构造函数
       /// </summary>
       /// <param name="date">日期</param>
       /// <param name="time">时间</param>
       /// <param name="item_moutn">口入</param>
       /// <param name="item_tube">管入</param>
       /// <param name="item_intravenous">经静脉入</param>
       /// <param name="the_real">实入量</param>
       /// <param name="urine">尿量</param>
       /// <param name="defecate">大便</param>
       /// <param name="vomiting">呕吐</param>
       /// <param name="drainage">引流</param>
       /// <param name="oozing_drainage">渗血渗液</param>
       /// <param name="operater">记录人</param>
       public NuserInout_show(string date,string time,string item_moutn,string item_tube,string item_intravenous,
                              string the_real,string urine,string defecate,string vomiting,string drainage,
                              string drainage_value,string oozing_drainage,string operater)
       {
           this.Date = date;
           this.Time = time;
           this.Item_Mouth = item_moutn;
           this.Item_Tube = item_tube;
           this.Imte_Intravenous = item_intravenous;
           this.The_Real = the_real;
           this.Urine = urine;
           this.Defecate = defecate;
           this.Vomiting = vomiting;
           this.Drainage = drainage;
           this.Drainage_value = drainage_value;
           this.Oozing_drainage = oozing_drainage;
           this.Operater = operater;
       }

       /// <summary>
       /// 日期
       /// </summary>
       public string Date
       {
           get { return _date; }
           set { _date = value; }
       }

       /// <summary>
       /// 时间
       /// </summary>
       public string Time
       {
           get { return _time; }
           set { _time = value; }
       }

       /// <summary>
       /// 口入
       /// </summary>
       public string Item_Mouth
       {
           get { return _item_Mouth; }
           set { _item_Mouth = value; }
       }
       /// <summary>
       /// 管入
       /// </summary>
       public string Item_Tube
       {
           get { return _item_Tube; }
           set { _item_Tube = value; }
       }
       /// <summary>
       /// 经静脉入
       /// </summary>
       public string Imte_Intravenous
       {
           get { return _imte_Intravenous; }
           set { _imte_Intravenous = value; }
       }
       /// <summary>
       /// 实入量
       /// </summary>
       public string The_Real
       {
           get { return _the_Real; }
           set { _the_Real = value; }
       }
       /// <summary>
       /// 尿量
       /// </summary>
       public string Urine
       {
           get { return _urine; }
           set { _urine = value; }
       }
       /// <summary>
       /// 大便
       /// </summary>
       public string Defecate
       {
           get { return _defecate; }
           set { _defecate = value; }
       }
       /// <summary>
       /// 呕吐
       /// </summary>
       public string Vomiting
       {
           get { return _vomiting; }
           set { _vomiting = value; }
       }
       /// <summary>
       /// 引流
       /// </summary>
       public string Drainage
       {
           get { return _drainage; }
           set { _drainage = value; }
       }
       /// <summary>
       /// 引流出量
       /// </summary>

       public string Drainage_value
       {
           get { return _drainage_value; }
           set { _drainage_value = value; }
       }
       /// <summary>
       /// 渗血渗液
       /// </summary>
       public string Oozing_drainage
       {
           get { return _Oozing_drainage; }
           set { _Oozing_drainage = value; }
       }
       /// <summary>
       /// 记录人
       /// </summary>
       public string Operater
       {
           get { return _operater; }
           set { _operater = value; }
       }
   }
}
