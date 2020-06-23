using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BLL_NURSE.NurseItemControls
{
    public partial class ComboBoxEdit : ComboBox
    {

        public CheckedListBox list = new CheckedListBox();
        Dictionary<object, string> SelectItems = new Dictionary<object, string>();

        public ComboBoxEdit()
        {
            InitializeComponent();
        }

        #region IsMultiSelect

        private bool isMultiSelect = false;
        [Description("�����Ƿ������ѡ")]
        public bool IsMultiSelect
        {
            get { return isMultiSelect; }
            set
            {
                isMultiSelect = value;
                if (isMultiSelect)
                {
                    //ֻ�������������ΪOwnerDrawFixed�ſ����ػ�������
                    this.DrawMode = DrawMode.OwnerDrawFixed;
                    this.IntegralHeight = false;
                    this.DoubleBuffered = true;
                    this.DroppedDown = false;
                    this.DropDownHeight = 1;
                    this.DropDownStyle = ComboBoxStyle.DropDown;
                    list.CheckOnClick = true;
                    list.ItemCheck += new ItemCheckEventHandler(list_ItemCheck);
                    list.MouseUp += new MouseEventHandler(list_MouseUp);
                    list.MouseLeave += new EventHandler(list_MouseLeave);
                    list.BorderStyle = BorderStyle.Fixed3D;
                    list.Visible = false;
                }
                else
                {
                    //ֻ�������������ΪNormal�ſ����ػ���������
                    this.DrawMode = DrawMode.Normal;
                    this.IntegralHeight = true;
                    this.DoubleBuffered = true;
                    this.DropDownHeight = 106;
                }
            }
        }
        #endregion

        #region SelectedValues
        private string[] selectedValues = null;
        [Description("ѡ�����Valueֵ(����)")]
        public string[] SelectedValues
        {
            get
            {
                if (IsMultiSelect)
                {
                    string str = "";
                    foreach (KeyValuePair<object, string> m in SelectItems)
                    {
                        str = str + m.Key.ToString() + ";";
                    }
                    string[] array = str.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    return array;
                }
                return selectedValues;
            }
            set
            {
                selectedValues = value;
            }
        }

        #endregion

        #region ItemCheck�¼�

        //����CheckBoxList
        private void list_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                if (SelectItems.ContainsKey(list.SelectedValue))
                {
                    throw new Exception("Value�����ظ���ֵ��");
                }
                if (list.Text =="��ѡ��")
                {
                    return;
                }
                SelectItems.Add(list.SelectedValue, list.Text);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                if (SelectItems.ContainsKey(list.SelectedValue))
                {
                    SelectItems.Remove(list.SelectedValue);
                }
            }
            else
            {
                if (e.NewValue == CheckState.Checked)
                {
                    if (SelectItems.ContainsKey(list.Text))
                    {
                        throw new Exception("�ֹ���ӵ�ֵ�����ظ������ݣ�");
                    }

                    SelectItems.Add(list.Text, list.Text);
                }
                else if (e.NewValue == CheckState.Unchecked)
                {
                    if (SelectItems.ContainsKey(list.Text))
                    {
                        SelectItems.Remove(list.Text);
                    }
                }

            }
        }

        //����ComboBox�ı�ֵ
        private void list_MouseUp(object sender, MouseEventArgs e)
        {
            string str = "";
            foreach (KeyValuePair<object, string> m in SelectItems)
            {
                str = str + m.Value + ";";
            }
            this.Text = str.Trim(';');
        }
        //����뿪�¼�
        private void list_MouseLeave(object sender, EventArgs e)
        {
            list.Visible = false;
        }

        #endregion

        #region ��д����¼�
        //������
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (IsMultiSelect)
            {
                this.DroppedDown = false;
            }
        }
        //�ͷ����
        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (IsMultiSelect)
            {
                this.DroppedDown = false;
            }
        }
        //TextChange�¼�
        protected override void OnTextChanged(EventArgs e)
        {
            if (!list.Visible)
            {
                list.DataSource = null;
                list.Items.Clear();
                SelectItems.Clear();
            }
        }
        //�����б��¼�
        protected override void OnDropDown(EventArgs e)
        {
            if (IsMultiSelect)
            {
                list.Visible = !list.Visible;
                if (list.Visible)
                {
                    list.Focus();
                    list.ItemHeight = this.ItemHeight;
                    list.BorderStyle = BorderStyle.FixedSingle;
                    list.Font = this.Font;
                    list.Size = new Size(this.DropDownWidth, this.ItemHeight * (this.MaxDropDownItems - 1) - (int)this.ItemHeight / 2);
                    list.Location = new Point(this.Left, this.Top + this.ItemHeight + 6);

                    list.BeginUpdate();
                    if (this.DataSource != null)
                    {
                        list.DataSource = this.DataSource;
                        list.DisplayMember = this.DisplayMember;
                        list.ValueMember = this.ValueMember;
                    }

                    list.EndUpdate();

                    if (!this.Parent.Controls.Contains(list))
                    {
                        this.Parent.Controls.Add(list);
                        list.BringToFront();
                    }
                }
            }
        }
        #endregion
    }

}
