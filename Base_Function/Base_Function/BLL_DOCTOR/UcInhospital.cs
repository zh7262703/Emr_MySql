using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.AdvTree;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_DOCTOR.Patient_Action_Manager;
using Bifrost_Doctor.Consultation_Manager;

namespace Base_Function.BLL_DOCTOR
{
    public partial class UcInhospital : UserControl
    {           
        public UcInhospital()
        {
            InitializeComponent();
        }
        private InPatientInfo inpat;
        private NodeCollection nodes;
        private Node nodeInpatient = new Node();
        private bool flag = false;                    //判断是否是跳到文书操作
        private bool ChangeColor = false;             //打开右键菜单，小卡还是蓝色
        public event ucHospitalIofn.DelerefInpatient EventRefinpatient;
        /// <summary>
        /// 病人树
        /// </summary>
        private AdvTree patientTree = new AdvTree();
        public UcInhospital(InPatientInfo inpatient,NodeCollection node)
        {
            InitializeComponent();
            this.inpat = inpatient;
            this.nodes = node;
            this.nodeInpatient.Tag = inpatient as object;
        }
        //Pen pp;
        //Pen pp2;
        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.SkyBlue ;
            //pp = new Pen(Color.Black);
            //pp2 = new Pen(Color.SkyBlue);           
        }

        void UcInhospital_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawRectangle(pp, e.ClipRectangle.X, e.ClipRectangle.Y,
            //          e.ClipRectangle.X + e.ClipRectangle.Width - 1, e.ClipRectangle.Y + e.ClipRectangle.Height - 1);            
            //e.Graphics.DrawLines(pp2, new Point[]{ new Point(e.ClipRectangle.X + e.ClipRectangle.Width, e.ClipRectangle.Y),
            //    new Point(e.ClipRectangle.X, e.ClipRectangle.Y),
            //    new Point(e.ClipRectangle.X , e.ClipRectangle.Y+e.ClipRectangle.Height)});
            //护理等级
            string nurse_Name = DataInit.GetNurse_Leavel_Name(inpat.Nurse_Level);
            if (inpat.Id != 0)
            {
                if (inpat.Gender_Code.Equals("0"))
                {
                    e.Graphics.DrawImage(global::Base_Function.Resource.card_man, new Point(4, 2));
                }
                else
                {
                    e.Graphics.DrawImage(global::Base_Function.Resource.card_woman, new Point(4, 2));
                }
                if(inpat.State.Equals("1"))
                {
                    e.Graphics.DrawString(inpat.Patient_Name + " " + inpat.Age.ToString() + inpat.Age_unit, new Font("宋体", 9F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Red, new PointF(4, 52));
                }
                else
                {
                    e.Graphics.DrawString(inpat.Patient_Name + " " + inpat.Age.ToString() + inpat.Age_unit, new Font("宋体", 9F, FontStyle.Regular,
                       GraphicsUnit.Point, ((byte)(134))), Brushes.Blue, new PointF(4, 52));
                }
                e.Graphics.DrawString("住 院 号：" + inpat.PId, new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(4, 73));
                e.Graphics.DrawString("住院日期：" + string.Format("{0:g}", inpat.In_Time), new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(4, 94));
                e.Graphics.DrawString("管床医生：" + inpat.Sick_Doctor_Name, new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(4, 115));
                e.Graphics.DrawString("入院诊断：" + inpat.Patient_Name, new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(4, 136));
                if (DataInit.GetActionState(inpat.Id.ToString()) == "3")
                {
                    e.Graphics.DrawString(inpat.Sick_Bed_Name, new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Red, new PointF(75, 27));
                }
                else
                {
                    e.Graphics.DrawString(inpat.Sick_Bed_Name, new Font("宋体", 9F, FontStyle.Regular,
                            GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(75, 27));
                }
                /*
                 *护理等级 
                 */
                e.Graphics.DrawString(nurse_Name, new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Red, new PointF(170, 160));
            }
            else
            {
                e.Graphics.DrawImage(global::Base_Function.Resource.unbed, new Point(4, 4));
                //e.Graphics.DrawString(inpat.Patient_Name+" "+inpat.Age.ToString()+inpat.Age_unit, new Font("宋体", 9F, FontStyle.Regular,
                //         GraphicsUnit.Point, ((byte)(134))), Brushes.Blue, new PointF(4, 52));
                e.Graphics.DrawString("住 院 号：", new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(4, 73));
                e.Graphics.DrawString("住院日期：" , new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(4, 94));
                e.Graphics.DrawString("管床医生：", new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(4, 115));
                e.Graphics.DrawString("入院诊断：", new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(4, 136));
                e.Graphics.DrawString(inpat.Sick_Bed_Name, new Font("宋体", 9F, FontStyle.Regular,
                        GraphicsUnit.Point, ((byte)(134))), Brushes.Black, new PointF(75, 27));
                ///*
                // *护理等级 
                // */
                //e.Graphics.DrawString(nurse_Leavel, new Font("宋体", 9F, FontStyle.Regular,

            }
        }



        private void UcInhospital_Load(object sender, EventArgs e)
        {
            //pp = new Pen(Color.Black);
            //pp2 = new Pen(SystemColors.Info);         
        }

        private void 入区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (inpat != null)
            {
                frmInArea zone = new frmInArea(inpat);
                zone.ShowDialog();
                if (DataInit.isInAreaSucceed ==true)
                {
                    Node node =  DataInit.RefCardTree(nodes, inpat);
                    if(node != null)
                    {
                        for (int i = 0; i < nodes[0].Nodes.Count; i++)
                        {
                            if (nodes[0].Nodes[i].Name == "tnSection_patient")
                            {
                                for (int j = 0; j < nodes[0].Nodes[i].Nodes.Count; i++)
                                {
                                    Node tempNode = nodes[0].Nodes[i].Nodes[j];
                                    if (tempNode.Name == inpat.Section_Id.ToString())
                                    {
                                        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                                        //把当前选中的节点移到科室病人节点下
                                        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodes);
                                    }
                                }
                            }
                        }

                            //foreach (Node tempNode in nodes[0].Nodes["tnSection_patient"].Nodes)
                            //{
                            //    if (tempNode.Name == inpat.Section_Id.ToString())
                            //    {
                            //        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                            //        //把当前选中的节点移到科室病人节点下
                            //        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodes);
                            //    }
                            //}
                    }
                    //自定义刷新事件
                    EventRefinpatient(this);
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string content = name + "," + sex + "。";
                    //App.Msg(content);
                    App.SendMessage(content, App.GetHostIp());
                    this.Visible = false;
                }
                
            }
          
        }

        private void 转入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             DataInit.isInAreaSucceed = false;
            if (inpat!=null)
            {
                frmTurn_In inAction = new frmTurn_In(inpat);
                inAction.ShowDialog();
                if (DataInit.isInAreaSucceed==true)
                {
                    Node node = DataInit.RefCardTree(nodes, inpat);
                    if (node != null)
                    {
                        //foreach (Node tempNode in nodes[0].Nodes["tnSection_patient"].Nodes)
                        //{
                        //    if (tempNode.Text.Equals(inpat.Section_Name))
                        //    {
                        //        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                        //        //把当前选中的节点移到科室病人节点下
                        //        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodes);
                        //    }
                        //}

                        for (int i = 0; i < nodes[0].Nodes.Count; i++)
                        {
                            if (nodes[0].Nodes[i].Name == "tnSection_patient")
                            {
                                for (int j = 0; j < nodes[0].Nodes[i].Nodes.Count; i++)
                                {
                                    Node tempNode = nodes[0].Nodes[i].Nodes[j];
                                    if (tempNode.Name == inpat.Section_Id.ToString())
                                    {
                                        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                                        //把当前选中的节点移到科室病人节点下
                                        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodes);
                                    }
                                }
                            }
                        }
                    }
                    //自定义刷新事件
                    EventRefinpatient(this);
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string bed_no = inpat.Sick_Bed_Name;
                    string doctor_Name = inpat.Sick_Doctor_Name;
                    string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                    //App.Msg(content);
                    App.SendMessage(content, App.GetHostIp());
                    this.Visible = false;
                }
            }
            
        }
        private void 转出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (inpat!=null)
            {
                frmRoll_Out inAction = new frmRoll_Out(inpat);
                inAction.ShowDialog();
                if (DataInit.isInAreaSucceed ==true)
                {
                    Node node = DataInit.RefCardTree(nodes, inpat);
                    if (node != null)
                    {
                        node.Text = inpat.Patient_Name;
                        for (int i = 0; i < nodes[0].Nodes.Count; i++)
                        {
                            if (nodes[0].Nodes[i].Name == "tnYizhuanchu_patient")
                            {
                                nodes[0].Nodes[i].Nodes.Add(node);
                            }
                        }
                       // nodes[0].Nodes["tnYizhuanchu_patient"].Nodes.Add(node);
                    }
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string bed_no = inpat.Sick_Bed_Name;
                    string doctor_Name = inpat.Sick_Doctor_Name;
                    string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                    //App.Msg(content);
                    //App.SendMessage(content, App.GetHostIp());
                    //inpat.Id = 0;
                    //this.Paint+=new PaintEventHandler(UcInhospital_Paint);
                    //inpat.Id = id;
                    //this.Visible = false;
                    //自定义刷新事件
                    //自定义刷新事件
                    EventRefinpatient(this);
                    DataInit.UpdatPatientsNodes(nodeInpatient,4);
                    //ucHospitalIofn ucHospitalIofn1 = (ucHospitalIofn)this.Parent.Parent.Parent.Parent.Parent.Parent;
                    //ucHospitalIofn1.HospitalIni(DataInit.PatientsNode.Nodes, nodes, inpat.Patient_Name);
                    DataInit.isInAreaSucceed = false;
                }
            }
        }

        private void 退回转出科室ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if(inpat!=null)
            {
                frmCancleTurnIn outAction = new frmCancleTurnIn(inpat);
                outAction.ShowDialog();
                if (DataInit.isInAreaSucceed == true)
                {
                     Node node = DataInit.RefCardTree(nodes, inpat);
                     string name = inpat.Patient_Name;
                     string sex = DataInit.StringFormat(inpat.Gender_Code);
                     string bed_no = inpat.Sick_Bed_Name;
                     string doctor_Name = inpat.Sick_Doctor_Name;
                     string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                     //App.Msg(content);
                     App.SendMessage(content, App.GetHostIp());
                     this.Visible = false;
                     //自定义刷新事件
                     EventRefinpatient(this);
                }
            }
        }

        private void 修改入区时间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if(inpat !=null)
            {
                frmUpdate_InArea_Time outAction = new frmUpdate_InArea_Time(inpat);
                outAction.ShowDialog();
                if (DataInit.isInAreaSucceed ==true)
                {
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string bed_no = inpat.Sick_Bed_Name;
                    string doctor_Name = inpat.Sick_Doctor_Name;
                    string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                    //App.Msg(content);
                    App.SendMessage(content, App.GetHostIp());
                }
            }
        }

        private void 换床ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if(inpat!=null)
            {
                frmUpdateBed outAction = new frmUpdateBed(inpat);
                outAction.ShowDialog();
                if (DataInit.isInAreaSucceed ==true)
                {
                    Node node = DataInit.RefCardTree(nodes, inpat);
                    if (node != null)
                    {
                        
                        //foreach (Node tempNode in nodes[0].Nodes["tnSection_patient"].Nodes)
                        //{
                        //    if (tempNode.Name==inpat.Section_Id.ToString())
                        //    {
                        //        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                        //        //把当前选中的节点移到科室病人节点下
                        //        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodes);
                        //    }
                        //}
                    }
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string bed_no = inpat.Sick_Bed_Name;
                    string doctor_Name = inpat.Sick_Doctor_Name;
                    string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                    //App.Msg(content);
                    //App.SendMessage(content, App.GetHostIp());
                    DataInit.UpdatPatientsNodes(nodeInpatient,4);
                    ucHospitalIofn ucHospitalIofn1 = (ucHospitalIofn)this.Parent.Parent.Parent;
                    ucHospitalIofn1.HospitalIni(DataInit.PatientsNode.Nodes, nodes, inpat.Patient_Name, DataInit.ViewSwitch, patientTree);
                    DataInit.isInAreaSucceed = false;
                }
            }
        }

        private void 更换管床医生ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if(inpat!=null)
            {
                frmUpdateDoctor outAction = new frmUpdateDoctor(inpat);
                outAction.ShowDialog();
                if (DataInit.isInAreaSucceed ==true)
                {
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string bed_no = inpat.Sick_Bed_Name;
                    string doctor_Name = inpat.Sick_Doctor_Name;
                    string content = name + "," + sex + "," + bed_no + "床,管床医生：" + doctor_Name + "。";
                    App.Msg(content);
                    App.SendMessage(content, App.GetHostIp());
                }
            }
        }

        private void 出区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if(inpat!=null)
            {
                frmOutArea outAction = new frmOutArea(inpat);
                outAction.ShowDialog();
                if (DataInit.isInAreaSucceed == true)
                {
                    Node node = DataInit.RefCardTree(nodes, inpat);
                    if (node != null)
                    {
                        node.Text = inpat.Patient_Name;
                        node.Remove();
                        for (int i = 0; i < nodes[0].Nodes.Count; i++)
                        {
                            if (nodes[0].Nodes[i].Name=="tnYiChuyuan_patient")
                            {
                                nodes[0].Nodes[i].Nodes.Add(node);
                            }
                        }
                        //nodes[0].Nodes["tnYiChuyuan_patient"].Nodes.Add(node);
                    }
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string bed_no = inpat.Sick_Bed_Name;
                    string doctor_Name = inpat.Sick_Doctor_Name;
                    string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                   // App.Msg(content);
                    App.SendMessage(content, App.GetHostIp());
                    this.Visible = false;
                    //自定义刷新事件
                    EventRefinpatient(this);
                }
            }
        }

        private void 取消转科ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if(inpat!=null)
            {
                frmBackRollOut outAction = new frmBackRollOut(inpat);
                outAction.ShowDialog();
                if (DataInit.isInAreaSucceed ==true)
                {
                    Node node = DataInit.RefCardTree(nodes, inpat);
                    if (node != null)
                    {
                        for (int i = 0; i < nodes[0].Nodes.Count; i++)
                        {
                            if (nodes[0].Nodes[i].Name=="tnSection_patient")
                            {
                                for (int j = 0; j < nodes[0].Nodes[i].Nodes.Count; j++)
                                {
                                    Node tempNode = nodes[0].Nodes[i].Nodes[j];
                                    if (tempNode.Text.Equals(inpat.Section_Name))
                                    {
                                        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                                        //把当前选中的节点移到科室病人节点下
                                        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodes);
                                    }
                                }
                                
                            }
                        }
                        //foreach (Node tempNode in nodes[0].Nodes["tnSection_patient"].Nodes)
                        //{
                        //    if (tempNode.Text.Equals(inpat.Section_Name))
                        //    {
                        //        node.Text = inpat.Sick_Bed_Name + "  " + inpat.Patient_Name;
                        //        //把当前选中的节点移到科室病人节点下
                        //        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name,nodes);
                        //    }
                        //}
                    }
                    //自定义刷新事件
                    EventRefinpatient(this);
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string bed_no = inpat.Sick_Bed_Name;
                    string doctor_Name = inpat.Sick_Doctor_Name;
                    string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                    //App.Msg(content);
                    App.SendMessage(content, App.GetHostIp());
                    this.Visible = false;
                }
            }
        }

        private void 回收ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (inpat!=null)
            {
                frmBack_Area outAction = new frmBack_Area(inpat);
                outAction.ShowDialog();
                if (DataInit.isInAreaSucceed ==true)
                {
                    Node node = DataInit.RefCardTree(nodes, inpat);
                    if (node != null)
                    {
                        for (int i = 0; i < nodes[0].Nodes.Count ; i++)
                        {
                            if (nodes[0].Nodes[i].Name == "tnSection_patient")
                            {
                                for (int j = 0; j < nodes[0].Nodes[i].Nodes.Count; j++)
                                {
                                    Node tempNode = nodes[0].Nodes[i].Nodes[j];
                                    if (tempNode.Text.Equals(inpat.Section_Name))
                                    {
                                        node.Text = inpat.Sick_Bed_Name + " " + inpat.Patient_Name;
                                        //把当前选中的节点移到科室病人节点下
                                        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name, nodes);
                                    }
                                }
                            }
                        }
                        //foreach (Node tempNode in nodes[0].Nodes["tnSection_patient"].Nodes)
                        //{
                        //    if (tempNode.Text.Equals(inpat.Section_Name))
                        //    {
                        //        node.Text = inpat.Sick_Bed_Name + " " + inpat.Patient_Name;
                        //        //把当前选中的节点移到科室病人节点下
                        //        DataInit.RefLocationTreeNode(node, inpat.Sick_Bed_Name,nodes);
                        //    }
                        //}
                    }
                    //自定义刷新事件
                    EventRefinpatient(this);
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string bed_no = inpat.Sick_Bed_Name;
                    string doctor_Name = inpat.Sick_Doctor_Name;
                    string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                    //App.Msg(content);
                    App.SendMessage(content, App.GetHostIp());
                    this.Visible = false;
                }
            }
        }

        private void 挂床ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            if (inpat != null)
            {
                frmHangBed outAction = new frmHangBed(inpat);
                outAction.ShowDialog();
                if (DataInit.isInAreaSucceed == true)
                {
                    string name = inpat.Patient_Name;
                    string sex = DataInit.StringFormat(inpat.Gender_Code);
                    string bed_no = inpat.Sick_Bed_Name;
                    string doctor_Name = inpat.Sick_Doctor_Name;
                    string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                    //App.Msg(content);
                    //this.Paint += new PaintEventHandler(UcInhospital_Paint); //修改用户名的颜色
                    App.SendMessage(content, App.GetHostIp());
                }
            }
        }


        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.SkyBlue;
        }

        private void UcInhospital_MouseLeave(object sender, EventArgs e)
        {
            if (!flag)  //是否是跳到文书操作
            {
                App.SetMainFrmMsgToolBarText("");
            }
            if (ChangeColor)
            {
                //this.BackColor = Color.SkyBlue;
                ChangeColor = false;
            }
            else
            {
                this.BackColor = SystemColors.Info;
            }
        }
       
        private void UcInhospital_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
            //    App.SetMainFrmMsgToolBarText("");
            //    if (inpat.Sick_Bed_Id != 0)
            //    {
            //        string sex = null;
            //        if (inpat.Gender_Code.Equals("0"))
            //        {
            //            sex = "男";
            //        }
            //        else
            //        {
            //            sex = "女";
            //        }
            //        App.SetMainFrmMsgToolBarText(inpat.Sick_Bed_Name + "床  " + "ID:" + inpat.Id.ToString() +
            //                                    "  住院号:" + inpat.PId + "  姓名:" + inpat.Patient_Name +
            //                                    "  性别:" + sex + "  年龄:" + inpat.Age.ToString() +
            //                                    "  入院时间:" + inpat.In_Time.ToString() +
            //                                    "  当前科室:" + inpat.Sick_Area_Name);
            //    }
            }

            catch
            { }
        }

        /// <summary>
        /// 根据当前病人的状态，显示不同的右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            this.BackColor = Color.SkyBlue;
            ChangeColor = true;
            if (App.UserAccount.CurrentSelectRole.Role_type != "D")
            {
                /*
                 * 从异动表获取当前病人的最后一条记录的异动类型，和异动状态
                 */
                string Sql_Action_ByPidLastInfo = "select action_type,action_state,target_said,target_sid,sid,said from t_inhospital_action" +
                                                  " where id = (select max(id) from t_inhospital_action where pid='" + inpat.Id + "')";
                /*
                 * 查看当前病人在异动表的记录数目。
                 */
                string Sql_Action_Count = "select count(*) as num from t_inhospital_action where pid ='" + inpat.Id + "'";
                string count = App.ReadSqlVal(Sql_Action_Count, 0, "num");
                DataSet ds = App.GetDataSet(Sql_Action_ByPidLastInfo);

                if (Convert.ToInt32(count) > 0)                  //大于零，则当前病人属于已经入区的。
                {
                    if (ds != null)
                    {
                        DataTable dt = ds.Tables[0];
                        if (dt != null)
                        {
                            foreach (DataRow row in dt.Rows)
                            {
                                string type = row["action_type"].ToString();
                                int state = Convert.ToInt32(row["action_state"]);
                                string said = row["said"].ToString();
                                string target_said = row["target_said"].ToString();
                                if (type.Equals("转出") && state == 2 &&
                                    App.UserAccount.CurrentSelectRole.Sickarea_Id.Equals(target_said))
                                {
                                    this.转入ToolStripMenuItem.Visible = true;
                                    this.退回转出科室ToolStripMenuItem.Visible = true;

                                    this.入区ToolStripMenuItem.Visible = false;
                                    this.修改入区时间ToolStripMenuItem.Visible = false;
                                    this.换床ToolStripMenuItem.Visible = false;
                                    this.更换管床医生ToolStripMenuItem.Visible = false;
                                    this.出区ToolStripMenuItem.Visible = false;
                                    this.挂床ToolStripMenuItem.Visible = false;
                                    this.转出ToolStripMenuItem.Visible = false;
                                    this.回收ToolStripMenuItem.Visible = false;
                                    this.取消转科ToolStripMenuItem.Visible = false;
                                    this.tlspmnitApply.Visible = false;
                     
                                    this.病人信息ToolStripMenuItem.Visible = false;
                                }
                                else if (state == 4)
                                {
                                    if (inpat.Id != 0)
                                    {
                                        this.修改入区时间ToolStripMenuItem.Visible = true;
                                        this.转出ToolStripMenuItem.Visible = true;
                                        this.换床ToolStripMenuItem.Visible = true;
                                        this.更换管床医生ToolStripMenuItem.Visible = true;
                                        this.出区ToolStripMenuItem.Visible = true;
                                        this.挂床ToolStripMenuItem.Visible = true;
                                        this.病人信息ToolStripMenuItem.Visible = true;

                                        this.转入ToolStripMenuItem.Visible = false;
                                        this.退回转出科室ToolStripMenuItem.Visible = false;
                                        this.回收ToolStripMenuItem.Visible = false;
                                        this.取消转科ToolStripMenuItem.Visible = false;
                                        this.入区ToolStripMenuItem.Visible = false;
                                        this.tlspmnitApply.Visible = false;
                                    }
                                    else
                                    {
                                        this.取消转科ToolStripMenuItem.Visible = false;
                                        this.回收ToolStripMenuItem.Visible = false;
                                        this.修改入区时间ToolStripMenuItem.Visible = false;
                                        this.转出ToolStripMenuItem.Visible = false;
                                        this.换床ToolStripMenuItem.Visible = false;
                                        this.更换管床医生ToolStripMenuItem.Visible = false;
                                        this.出区ToolStripMenuItem.Visible = false;
                                        this.挂床ToolStripMenuItem.Visible = false;
                                        this.转入ToolStripMenuItem.Visible = false;
                                        this.退回转出科室ToolStripMenuItem.Visible = false;
                                        this.入区ToolStripMenuItem.Visible = false;
                                        this.tlspmnitApply.Visible = false;
                                        this.病人信息ToolStripMenuItem.Visible = false;
                                    }
                                }
                                else if (type.Equals("出区") && state == 3)
                                {
                                    this.回收ToolStripMenuItem.Visible = true;

                                    this.修改入区时间ToolStripMenuItem.Visible = false;
                                    this.转出ToolStripMenuItem.Visible = false;
                                    this.换床ToolStripMenuItem.Visible = false;
                                    this.更换管床医生ToolStripMenuItem.Visible = false;
                                    this.出区ToolStripMenuItem.Visible = false;
                                    this.挂床ToolStripMenuItem.Visible = false;
                                    this.转入ToolStripMenuItem.Visible = false;
                                    this.退回转出科室ToolStripMenuItem.Visible = false;
                                    this.取消转科ToolStripMenuItem.Visible = false;
                                    this.入区ToolStripMenuItem.Visible = false;
                                    this.tlspmnitApply.Visible = false;
                                    this.病人信息ToolStripMenuItem.Visible = false;
                                }
                                else if (type.Equals("转出") && state == 2 &&
                                       App.UserAccount.CurrentSelectRole.Sickarea_Id.Equals(said))
                                {
                                    this.取消转科ToolStripMenuItem.Visible = true;

                                    this.回收ToolStripMenuItem.Visible = false;
                                    this.修改入区时间ToolStripMenuItem.Visible = false;
                                    this.转出ToolStripMenuItem.Visible = false;
                                    this.换床ToolStripMenuItem.Visible = false;
                                    this.更换管床医生ToolStripMenuItem.Visible = false;
                                    this.出区ToolStripMenuItem.Visible = false;
                                    this.挂床ToolStripMenuItem.Visible = false;
                                    this.转入ToolStripMenuItem.Visible = false;
                                    this.退回转出科室ToolStripMenuItem.Visible = false;
                                    this.入区ToolStripMenuItem.Visible = false;
                                    this.tlspmnitApply.Visible = false;
                                    this.病人信息ToolStripMenuItem.Visible = false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (inpat.Id != 0)
                    {
                        this.入区ToolStripMenuItem.Visible = true;
                        this.退回转出科室ToolStripMenuItem.Visible = false;
                        this.修改入区时间ToolStripMenuItem.Visible = false;
                        this.换床ToolStripMenuItem.Visible = false;
                        this.更换管床医生ToolStripMenuItem.Visible = false;
                        this.出区ToolStripMenuItem.Visible = false;
                        this.挂床ToolStripMenuItem.Visible = false;
                        this.转出ToolStripMenuItem.Visible = false;
                        this.回收ToolStripMenuItem.Visible = false;
                        this.取消转科ToolStripMenuItem.Visible = false;
                        this.转入ToolStripMenuItem.Visible = false;
                        this.tlspmnitApply.Visible = false;
                        this.病人信息ToolStripMenuItem.Visible = false;
                    }
                    else
                    {
                        this.入区ToolStripMenuItem.Visible = false;
                        this.退回转出科室ToolStripMenuItem.Visible = false;
                        this.修改入区时间ToolStripMenuItem.Visible = false;
                        this.换床ToolStripMenuItem.Visible = false;
                        this.更换管床医生ToolStripMenuItem.Visible = false;
                        this.出区ToolStripMenuItem.Visible = false;
                        this.挂床ToolStripMenuItem.Visible = false;
                        this.转出ToolStripMenuItem.Visible = false;
                        this.回收ToolStripMenuItem.Visible = false;
                        this.取消转科ToolStripMenuItem.Visible = false;
                        this.转入ToolStripMenuItem.Visible = false;
                        this.tlspmnitApply.Visible = false;
                        this.病人信息ToolStripMenuItem.Visible = false;
                    }
                }
            }
            else
            {
                this.入区ToolStripMenuItem.Visible = false;
                this.退回转出科室ToolStripMenuItem.Visible = false;
                this.修改入区时间ToolStripMenuItem.Visible = false;
                this.换床ToolStripMenuItem.Visible = false;
                this.更换管床医生ToolStripMenuItem.Visible = false;
                this.出区ToolStripMenuItem.Visible = false;
                this.挂床ToolStripMenuItem.Visible = false;
                this.转出ToolStripMenuItem.Visible = false;
                this.回收ToolStripMenuItem.Visible = false;
                this.取消转科ToolStripMenuItem.Visible = false;
                this.转入ToolStripMenuItem.Visible = false;
                this.tlspmnitApply.Visible = true;
                this.病人信息ToolStripMenuItem.Visible = true;
            }
            
        }


        private void UcInhospital_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                //if(App.UserAccount.CurrentSelectRole.Sickarea_Id!="")
                //{
                    if ((sender as UcInhospital).inpat.Id != 0)
                    {
                        if (DataInit.GetActionState(inpat.Id.ToString()) == "4" || 
                            DataInit.GetActionState(inpat.Id.ToString()) == "3")
                        {
                            ucMain main = (this.Parent.Parent.Parent.Parent.Parent.Parent.Parent.Parent) as ucMain;
               
                            App.UsControlStyle(main);
                            //main.MdiParent = App.ParentForm;
                            main.currentPatient = null;
                            main.currentPatient = inpat;
                         
                            //if (main.tctlNormolOperate.Tabs[0].Text == "常用操作")
                            //{
                            //    main.tctlNormolOperate.SelectedTabIndex = 1;
                            //}
                            //else
                            //{
                            //    main.tctlNormolOperate.SelectedTabIndex = 0;
                            //}
                            
                            flag = true;
                        }
                    }
                    else
                    {
                        App.Msg("该床是空床！");
                    }
                //}
            }
        }




        /// <summary>
        /// 会诊申请
        /// </summary>
        private void tlspmnitApply_Click(object sender, EventArgs e)
        {
            frmConsultation_Apply frmconsultation_apply = new frmConsultation_Apply(inpat);
            App.FormStytleSet(frmconsultation_apply);
            frmconsultation_apply.MdiParent = App.ParentForm;
            frmconsultation_apply.Show();
        }

        private void contextMenuStrip1_MouseLeave(object sender, EventArgs e)
        {
            ChangeColor = false;
            this.UcInhospital_MouseLeave(sender, e);
        }

        private void contextMenuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            ChangeColor = true;
            this.UcInhospital_MouseLeave(sender, e);
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            this.BackColor = Color.SkyBlue;
        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.BackColor = SystemColors.Info;
        }

        private void 病人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataInit.isInAreaSucceed = false;
            frmPatientInfo1 frmpatient = new frmPatientInfo1(inpat);
            App.FormStytleSet(frmpatient);
            frmpatient.MdiParent = App.ParentForm;
            frmpatient.Show();
            if(DataInit.isInAreaSucceed)
            {
                string name = inpat.Patient_Name;
                string sex = DataInit.StringFormat(inpat.Gender_Code);
                string bed_no = inpat.Sick_Bed_Name;
                string doctor_Name = inpat.Sick_Doctor_Name;
                string content = name + "," + sex + "," + bed_no + "," + doctor_Name + "。";
                //App.Msg(content);
                App.SendMessage(content, App.GetHostIp());
                DataInit.UpdatPatientsNodes(nodeInpatient,4);
                ucHospitalIofn ucHospitalIofn1 = (ucHospitalIofn)this.Parent.Parent.Parent;
                ucHospitalIofn1.HospitalIni(DataInit.PatientsNode.Nodes, nodes, inpat.Patient_Name, DataInit.ViewSwitch, patientTree);
                DataInit.isInAreaSucceed = false;
            }
        }

        
        private void 病案首页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmCases_First frmcases = new frmCases_First(inpat);
            //App.FormStytleSet(frmcases);
            //frmcases.MdiParent = App.ParentForm;
            //frmcases.Show();
        }
    }
}
