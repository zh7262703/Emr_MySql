using Bifrost;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TempertureEditor.EditDesigner
{
    partial class ucAiTemperature
    {
        private bool isAll = false;
        private const string _txtDisplayAllNode = "显示全部";

        private void Register_ucTemperaturePrintFrame(Control sender, params Control[] controls)
        {

            #region 注册控件接口:增加特殊控件处理函数后,在此添加新函数至容器
            RegisterEventSubHandler("btn_up", btn_up);
            RegisterEventSubHandler("btn_next", btn_next);
            RegisterEventSubHandler("tvTimes_AfterNodeSelect", tvTimes_AfterNodeSelect);

            #endregion

            #region 注册自定义事件接口
            RegisterCustomEventHandler("ucTemperPrint_Load", ucTemperPrint_Load);
            RegisterCustomEventHandler("loadTree", loadTree);
            #endregion
        }

        #region 控件事件处理
        private void btn_up(Control sender, params Control[] controls)
        {
            TextBox txtIndex = (TextBox)controls[0];
            DevComponents.AdvTree.AdvTree tvTimes = (DevComponents.AdvTree.AdvTree)controls[1];
            if (Convert.ToInt32(txtIndex.Text) < tvTimes.Nodes.Count)
            {

                tvTimes.SelectedNode = tvTimes.Nodes[Convert.ToInt32(txtIndex.Text)];
                txtIndex.Text = (Convert.ToInt32(tvTimes.SelectedNode.Index) + 1).ToString();
            }
            else
            {
                App.Msg("已经是最后一页！");
            }

            tvTimes.Focus();
        }

        private void btn_next(Control sender, params Control[] controls)
        {
            TextBox txtIndex = (TextBox)controls[0];
            DevComponents.AdvTree.AdvTree tvTimes = (DevComponents.AdvTree.AdvTree)controls[1];
            if (Convert.ToInt32(txtIndex.Text) > 1)
            {

                tvTimes.SelectedNode = tvTimes.Nodes[tvTimes.SelectedNode.Index - 1];
                txtIndex.Text = (Convert.ToInt32(tvTimes.SelectedNode.Index) + 1).ToString();

            }
            else
            {
                App.Msg("已经是第一页！");
            }
            tvTimes.Focus();
        }

        /// <summary>
        /// 树节点 选择打印日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvTimes_AfterNodeSelect(Control sender, params Control[] controls)
        {
            /*
            TextBox txtIndex = (TextBox)controls[0];
            DevComponents.AdvTree.AdvTree tvTimes = (DevComponents.AdvTree.AdvTree)controls[1];
            Panel panel1 = (Panel)controls[3];

            DevComponents.AdvTree.Node selectNode = tvTimes.SelectedNode;
            if (selectNode != null)
            {
                panel1.AutoScrollPosition = new Point(0, 0);

                if (selectNode.Text == _txtDisplayAllNode)  //显示全部
                {
                    isAll = true;
                    ppcPreview.Rows = tvTimes.Nodes.Count - 1;
                    pdDocument.DocumentName = (tvTimes.Nodes.Count - 1).ToString();
                }
                else
                {
                    isAll = false;
                    ppcPreview.Rows = 1;
                    pdDocument.DocumentName = selectNode.Tag.ToString();

                    txtIndex.Text = selectNode.Tag.ToString();
                    //初始化一周体温单的开始和结束时间this.startDate, this.endDate
                    string tempString = selectNode.Text;
                    StarToEndTime(tempString);

                    currentPage.Objs = new List<ClsDataObj>();
                    currentPage.Starttime = startDate + " 00:00:00";
                    currentPage.Endtime = endDate + " 23:59:59";

                    //模板赋值
                    tempetureDataComm.GetPageContentByPageObj_child(pat, ref currentPage, selectNode.Tag.ToString(), outTime, ref cm);
                }
                txtIndex.Enabled = btn_up.Enabled = btn_next.Enabled = label1.Enabled = label4.Enabled = !isAll;
                txtIndex.Visible = btn_up.Visible = btn_next.Visible = label1.Visible = label4.Visible = !isAll;
                ppcPreview.InvalidatePreview();
            }
            */
        }

        #endregion

        #region 自定义事件处理
        private void ucTemperPrint_Load(Control sender, params Control[] controls)
        {
            TextBox txtIndex = (TextBox)controls[0];
            txtIndex.Text = "1";//页码初始化
            /*
            cm.startini(templatefilename); //体温单初始化;
            pt.cm = cm;
            pat = info;
            id = pat.Id.ToString();
            in_date = info.In_Time.ToString("yyyy-MM-dd HH:mm");
            temperInit();
            */
        }


        /// <summary>
        /// 加载时间项目
        /// </summary>
        private void loadTree(Control sender, params Control[] controls)
        {
            /*
            DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_date).ToString("yyyy-MM-dd"));
            DateTime today = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd"));

            DataTable dt = App.GetDataSet(string.Format("select aa.VALTYPE_TIME from t_temperature_record aa where " +
                  "aa.valtype ='操作事件' and (aa.t_val like '出院%' or aa.t_val like '死亡%') and patient_id={0} and template_type='{1}'  order by aa.VALTYPE_TIME asc", pat.Id.ToString(), tempetureDataComm.TEMPLATE_CHILD)).Tables[0];

            outTime = null;
            if (dt.Rows.Count > 0)
            {
                outTime = Convert.ToDateTime(dt.Rows[0]["VALTYPE_TIME"]);
                today = Convert.ToDateTime(Convert.ToDateTime(dt.Rows[0]["VALTYPE_TIME"]).ToString("yyyy-MM-dd"));
            }

            TimeSpan ts1 = new TimeSpan(inDatetime.Ticks);
            TimeSpan ts2 = new TimeSpan(today.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            int weekCount = 0;
            const int dayCountPerWeek = 7;
            if ((ts.Days + 1) % dayCountPerWeek == 0)
                weekCount = (ts.Days + 1) / dayCountPerWeek;
            else
                weekCount = (ts.Days + 1) / dayCountPerWeek + 1;

            string temper = "";
            this.tvTimes.Nodes.Clear();

            for (int i = 0; i < weekCount; i++)
            {
                temper = "第" + (i + 1).ToString() + "页(" + inDatetime.AddDays(i * dayCountPerWeek).ToString("yyyy-MM-dd") +
                   '~' + inDatetime.AddDays(i * dayCountPerWeek + dayCountPerWeek - 1).ToString("yyyy-MM-dd") + ")";

                Node tempnode = new Node();
                tempnode.Text = temper;
                tempnode.Name = i.ToString();
                tempnode.Tag = (i + 1).ToString();
                this.tvTimes.Nodes.Add(tempnode);
                temper = "";
            }
            //添加显示全部
            if (weekCount > 0)
            {
                Node displayallnode = new Node();
                displayallnode.Text = _txtDisplayAllNode;
                displayallnode.Name = weekCount.ToString();
                displayallnode.Tag = (weekCount + 1).ToString();
                this.tvTimes.Nodes.Add(displayallnode);
            }
            */
        }


        #endregion

        #region 本类中辅助函数
        /*
        /// <summary>
        /// 初始化
        /// </summary>
        private void temperInit()
        {
            this.ppcPreview.Document = pdDocument;
            this.pd.Document = pdDocument;
            this.pd.AllowSomePages = true;
            this.pd.ShowHelp = true;
            this.pd.UseEXDialog = true;
            this.pdDocument.DefaultPageSettings.Margins.Left = 30;
            this.pdDocument.DefaultPageSettings.Margins.Top = 0;  //78
            this.pdDocument.DefaultPageSettings.Landscape = false;
            this.pdDocument.OriginAtMargins = true;
            Type type = typeof(System.Windows.Forms.PrintPreviewControl);
            m_Position = type.GetField("position", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            m_SetPositionMethod = type.GetMethod("SetPositionNoInvalidate", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.ExactBinding);
            ppcPreview.MouseWheel += new MouseEventHandler(ppcPreview_MouseWheel);
            ppcPreview.Click += new EventHandler(ppcPreview_Click);
            ppcPreview.MouseDown += new MouseEventHandler(ppcPreview_MouseDown);
            ppcPreview.MouseUp += new MouseEventHandler(ppcPreview_MouseUp);
            ppcPreview.MouseMove += new MouseEventHandler(ppcPreview_MouseMove);
            pdDocument.PrintPage += new PrintPageEventHandler(pdDocument_PrintPage);
            foreach (PaperSize _papersize in this.pdDocument.PrinterSettings.PaperSizes)
            {
                if (_papersize.PaperName == "A4")
                {
                    pdDocument.DefaultPageSettings.PaperSize = _papersize;
                    break;
                }
            }
            this.MouseWheel += new MouseEventHandler(ppcPreview_MouseWheel);

            loadTree();
            ppcPreview.Refresh();

            if (tvTimes.Nodes.Count > 0)
                tvTimes.SelectedNode = tvTimes.Nodes[0];
        }
        */

        #endregion
    }
}
