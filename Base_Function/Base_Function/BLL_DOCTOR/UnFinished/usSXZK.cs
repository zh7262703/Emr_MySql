using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_DOCTOR.UnFinished
{
    public partial class usSXZK : UserControl
    {
        public usSXZK()
        {
            InitializeComponent();
        }
        //声明变量
        string tempSQL = "";
        string tempSQL_S = "";
        string tempSQL_R = "";
        string tempSQL_Y = "";
        int ColCount = 0;
        //frmHint 窗体右侧块数据源
        DataSet ds = new DataSet();
        //frmHint 窗体左侧块数据源
        DataSet ds1 = new DataSet();

        /// <summary>
        /// 病历工作站 质控提醒调用
        /// </summary>
        /// <param name="secid">当前科室或者病区id</param>
        /// <param name="userid">当前用户id</param>
        /// <param name="type">D:医生;N:护士</param>
        public usSXZK(string secid, string userid,string type,string patientid)
        {
            InitializeComponent();
            string sql = "";
            string whereID = "";
            if (patientid != "")
                whereID = " and t.id=" + patientid;
            if (type=="D")
            {//查询医务时限质控
                sql = @"select '' 序号, t.section_name 科室,t.sick_doctor_name 管床医生,t.pid 住院号,t.sick_bed_no 床号,t.patient_name 病人姓名,tt.textname 文书类型, qc.wgxx 提示内容,qc.jgsj 应完成时间,qc.WGZT 类型id
                        from qc_zlkzjlk qc 
                        inner join t_in_patient t on qc.syxh=t.id
                        inner join t_text tt on qc.blxh=tt.id
                        where qc.WGZT in(0,3,4) and t.section_id= '" + secid + "' and t.sick_doctor_id='" + userid + "' " + whereID;
                sql += " order by t.pid,tt.textname,qc.jgsj desc,qc.wgxx";
            }
            else if(type=="N")
            {//查询护理时限质控
//                sql = @"select '' 序号, t.sick_area_name 病区,tu.user_name 责任护士,t.pid 住院号,t.sick_bed_no 床号,t.patient_name 病人姓名,'体温单' 文书类型, qc.wgxx 提示内容,qc.jgsj 应完成时间,qc.WGZT 类型id
//                        from qc_zlkzjlk qc 
//                        inner join t_in_patient t on qc.syxh=t.id 
//                        inner join t_patient_area_nurser tp on t.id=tp.patient_id and t.sick_area_id=tp.area_id  
//                        inner join t_userinfo tu on tp.nurser_id=tu.user_id                     
//                        where qc.WGZT in(0,3,4) and qc.blxh=0 and tp.area_id= '" + secid + "' and tp.nurser_id='" + userid + "' " + whereID;
//                sql += " order by t.pid,qc.jgsj desc,qc.wgxx";
                sql = @"select '' 序号, t.sick_area_name 病区,t.pid 住院号,t.sick_bed_no 床号,t.patient_name 病人姓名,'体温单' 文书类型, qc.wgxx 提示内容,qc.jgsj 应完成时间,qc.WGZT 类型id
                        from qc_zlkzjlk qc 
                        inner join t_in_patient t on qc.syxh=t.id 
                        where qc.WGZT in(0,3,4) and qc.blxh=0 and t.sick_area_id= '" + secid + "' " + whereID;
                sql += " order by t.pid,qc.jgsj desc,qc.wgxx";
            }

            ds = GetDataSet(sql,"1");

            refreshdgvListxx(ds);
        }
        

        /// <summary>
        /// 这是全局显示灯的方法
        /// 1、lx 类型
        /// 2、lxid 类型id
        /// 3、1 代表超时
        /// 4、0 代表即将超时
        /// 5、3 代表补录
        /// 疑问：为啥没有2？这个问题靠你了！^_^
        /// 解答: 以前有2,代表质控,后面质控研发调整改了,也不知道为啥O(∩_∩)O~
        /// </summary>
        /// <param name="DGV">DataGridViewX</param>
        private void Light(DevComponents.DotNetBar.Controls.DataGridViewX DGV)
        {
            try
            {
                DGV.Columns["类型id"].Visible = false;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        private void frmHint_Load(object sender, EventArgs e)
        {
            Light(this.dgvListxx);//亮灯
        }

       

        /// <summary>
        /// 超时算法（超时）
        /// </summary>
        /// <param name="DateTime1"></param>
        /// <param name="DateTime2"></param>
        /// <returns></returns>
        private string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts = DateTime1.Subtract(DateTime2).Duration();
            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟";
            if (DateTime1 > DateTime2)
            {
                dateDiff = "+" + dateDiff;
            }
            else
            {
                dateDiff = "-" + dateDiff;
            }

            return dateDiff;
        }


        /// <summary>
        /// 刷新全部信息表
        /// </summary>
        /// <param name="ds"></param>
        public void refreshdgvListxx(DataSet ds)
        {
            DataTable dt = ds.Tables[0];
            if (dt == null)
                return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {//添加序号值
                dt.Rows[i]["序号"] = i + 1;
            }
            dgvListxx.DataSource = dt;

            Light(this.dgvListxx);
        }

        

        /// <summary>
        /// 新增"类型"列,保存在dataset里面,
        /// </summary>
        /// <param name="sql"></param>
        public DataSet GetDataSet(string sql, string pv)
        {
            try
            {
                DataSet ds = App.GetDataSet(sql.ToString());

                DataTable dts = ds.Tables[0];
                // 增加一个字段将 url 转换为 image
                dts.Columns.Add("类型", typeof(Image));
                foreach (DataRow row in dts.Rows)
                {
                    if (row["类型id"].ToString().Trim() == "0")
                    {
                        row["类型"] =Resource.黄灯泡;
                    }
                    else if (row["类型id"].ToString().Trim() == "3")
                    {
                        row["类型"] = Resource.红灯泡;
                    }
                    else if (row["类型id"].ToString().Trim() == "4")
                    {
                        row["类型"] = Resource.蓝灯泡;
                    }
                }

                //if (ds != null)
                //{
                //    if (pv == "1" || pv == "0")
                //    {//计算超时
                //        DateTime dt = App.GetSystemTime();
                //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //        {
                //            ds.Tables[0].Rows[i]["超时"] = DateDiff(dt, DateTime.Parse(ds.Tables[0].Rows[i]["应完成时间"].ToString()));
                //        }
                //    }
                //    if (pv == "3")
                //    {//计算补录
                //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //        {
                //            ds.Tables[0].Rows[i]["超时"] = DateDiff(DateTime.Parse(ds.Tables[0].Rows[i]["完成时间"].ToString()), DateTime.Parse(ds.Tables[0].Rows[i]["应完成时间"].ToString()));
                //        }
                //    }
                //}

                return ds;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        /// <summary>
        /// DataRow[]转换DataTable
        /// </summary>
        /// <param name="rows"></param>
        /// <returns></returns>
        public DataTable ToDataTable(DataRow[] rows)
        {
            if (rows == null || rows.Length == 0) return null;
            DataTable tmp = rows[0].Table.Clone();  // 复制DataRow的表结构
            foreach (DataRow row in rows)
            {
                try
                {
                    tmp.Rows.Add(row.ItemArray);  // 将DataRow添加到DataTable中
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
            return tmp;
        }

        /// <summary>
        /// 双击病人文书浏览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvListxx_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string id= dgvListxx.CurrentRow.Cells["id"].Value.ToString();
                object[] args = new object[1];
                args[0] = id;
                System.Reflection.Assembly assmble = System.Reflection.Assembly.LoadFile(App.AppPath + "\\Base_Function.dll");
                Type tmpType = assmble.GetType("Base_Function.Base");
                System.Reflection.MethodInfo tmpM = tmpType.GetMethod("ucDoctorOperaterShow");
                object tmpobj = assmble.CreateInstance("Base_Function.Base");
                tmpM.Invoke(tmpobj, args);
            }
            catch (Exception)
            {
                App.Msg("该按钮参数未设置或功能尚未启用！");
            }

        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            //XmlOperate.DataToExcel(dgvListxx, "质控详细列表");
        }
    }
}
