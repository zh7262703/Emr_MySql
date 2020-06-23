using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using DevComponents.DotNetBar.Controls;
using System.Data;

namespace TempertureEditor.Util
{
    /// <summary>
    /// 自定义的DataGridView操作类
    /// </summary>
    public class DgvTools
    {
        #region 创建DataGridView的TextBox列
        /// <summary>
        /// 创建DataGridView的TextBox列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_maxInputLength">可输入的最大长度</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvTextBoxColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText, int _maxInputLength, bool _readOnly, bool _visible,
            bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewTextBoxColumn textBoxCol = new DataGridViewTextBoxColumn();
            textBoxCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            textBoxCol.Name = _columnName;
            textBoxCol.HeaderText = _headerText;
            textBoxCol.DataPropertyName = _dataPropertyName;
            textBoxCol.ToolTipText = _toolTipText;
            textBoxCol.MaxInputLength = _maxInputLength;
            textBoxCol.Visible = _visible;
            textBoxCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                textBoxCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(textBoxCol);
        }
        #endregion

        #region 创建DataGridView的扩展的TextBoxDropDown列
        /// <summary>
        /// 创建DataGridView的扩展的TextBoxDropDown列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_maxInputLength">可输入的最大长度</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_buttonCustomVisible">设置是否显示可选择按钮，true 显示，false 隐藏</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvTextBoxDropDownColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText, int _maxInputLength, bool _readOnly, bool _visible,
            bool _notEmpty, Color _backColor, bool _buttonCustomVisible, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewTextBoxDropDownColumn textBoxDropDownCol = new DataGridViewTextBoxDropDownColumn();
            textBoxDropDownCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            textBoxDropDownCol.Name = _columnName;
            textBoxDropDownCol.HeaderText = _headerText;
            textBoxDropDownCol.DataPropertyName = _dataPropertyName;
            textBoxDropDownCol.ToolTipText = _toolTipText;
            textBoxDropDownCol.MaxInputLength = _maxInputLength;
            textBoxDropDownCol.Visible = _visible;
            textBoxDropDownCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                textBoxDropDownCol.DefaultCellStyle.BackColor = _backColor;
            }
            textBoxDropDownCol.ButtonCustom.Visible = _buttonCustomVisible;
            //textBoxDropDownCol.ButtonCustom2.Visible = _buttonCustomVisible;
            //textBoxDropDownCol.ButtonClear.Visible = _buttonCustomVisible;
            //textBoxDropDownCol.ButtonDropDown.Visible = _buttonCustomVisible;
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(textBoxDropDownCol);
        }
        #endregion

        #region 创建DataGridView的Button列
        /// <summary>
        /// 创建DataGridView的Button列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvButtonColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText, bool _readOnly, bool _visible, bool _notEmpty,
            Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewButtonColumn buttonCol = new DataGridViewButtonColumn();
            buttonCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            buttonCol.Name = _columnName;
            buttonCol.HeaderText = _headerText;
            buttonCol.DataPropertyName = _dataPropertyName;
            buttonCol.ToolTipText = _toolTipText;
            buttonCol.Visible = _visible;
            buttonCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                buttonCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(buttonCol);
        }
        #endregion

        #region 创建DataGridView的扩展的Button列
        /// <summary>
        /// 创建DataGridView的扩展的Button列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_autoCheckOnClick">设置单击时是否选择相同内容的，true 是，false 否</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvButtonXColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText, bool _readOnly, bool _visible, bool _notEmpty, Color _backColor,
            bool _autoCheckOnClick, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewButtonXColumn buttonXCol = new DataGridViewButtonXColumn();
            buttonXCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            buttonXCol.Name = _columnName;
            buttonXCol.HeaderText = _headerText;
            buttonXCol.DataPropertyName = _dataPropertyName;
            buttonXCol.ToolTipText = _toolTipText;
            buttonXCol.Visible = _visible;
            buttonXCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                buttonXCol.DefaultCellStyle.BackColor = _backColor;
            }
            buttonXCol.AutoCheckOnClick = _autoCheckOnClick;
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(buttonXCol);
        }
        #endregion

        #region 创建DataGridView的CheckBox列
        /// <summary>
        /// 创建DataGridView的CheckBox列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvCheckBoxColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText, bool _readOnly, bool _visible, bool _notEmpty,
            Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewCheckBoxColumn checkBoxCol = new DataGridViewCheckBoxColumn();
            checkBoxCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            checkBoxCol.Name = _columnName;
            checkBoxCol.HeaderText = _headerText;
            checkBoxCol.DataPropertyName = _dataPropertyName;
            checkBoxCol.ToolTipText = _toolTipText;
            checkBoxCol.Visible = _visible;
            checkBoxCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                checkBoxCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(checkBoxCol);
        }
        #endregion

        #region 创建DataGridView扩展的CheckBox列
        /// <summary>
        /// 创建DataGridView扩展的CheckBox列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvCheckBoxXColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText, bool _readOnly, bool _visible, bool _notEmpty,
            Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewCheckBoxXColumn checkBoxXCol = new DataGridViewCheckBoxXColumn();
            checkBoxXCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            checkBoxXCol.Name = _columnName;
            checkBoxXCol.HeaderText = _headerText;
            checkBoxXCol.DataPropertyName = _dataPropertyName;
            checkBoxXCol.ToolTipText = _toolTipText;
            checkBoxXCol.Visible = _visible;
            checkBoxXCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                checkBoxXCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(checkBoxXCol);
        }
        #endregion

        #region 创建DataGridView的ComboBox列
        /// <summary>
        /// 创建DataGridView的ComboBox列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_cboDataSource">绑定ComboBox的数据源</param>
        /// <param name="_displayMember">用于显示的字段名</param>
        /// <param name="_valueMember">绑定Value的字段名</param>
        /// <param name="_maxDropDownItems">设置显示最大的下拉项条数</param>
        /// <param name="_cboDisplayStyle">设置显示类型</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvComboBoxColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText, bool _readOnly, bool _visible,
            DataTable _cboDataSource, string _displayMember, string _valueMember,
            int _maxDropDownItems, DataGridViewComboBoxDisplayStyle _cboDisplayStyle,
            bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewComboBoxColumn comboBoxCol = new DataGridViewComboBoxColumn();
            comboBoxCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            comboBoxCol.Name = _columnName;
            comboBoxCol.HeaderText = _headerText;
            comboBoxCol.DataPropertyName = _dataPropertyName;
            comboBoxCol.ToolTipText = _toolTipText;
            comboBoxCol.Visible = _visible;
            comboBoxCol.ReadOnly = _readOnly;
            comboBoxCol.DataSource = _cboDataSource;
            comboBoxCol.DisplayMember = _displayMember;
            comboBoxCol.ValueMember = _valueMember;
            comboBoxCol.MaxDropDownItems = _maxDropDownItems;
            comboBoxCol.DisplayStyle = _cboDisplayStyle;
            comboBoxCol.AutoComplete = _cboDisplayStyle == DataGridViewComboBoxDisplayStyle.ComboBox ? true : false;
            if (_notEmpty == true)
            {
                comboBoxCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(comboBoxCol);
        }
        #endregion

        #region 创建DataGridView扩展的ComboBox列
        /// <summary>
        /// 创建DataGridView扩展的ComboBox列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_cboDataSource">绑定ComboBox的数据源</param>
        /// <param name="_displayMember">用于显示的字段名</param>
        /// <param name="_valueMember">绑定Value的字段名</param>
        /// <param name="_maxDropDownItems">设置显示最大的下拉项条数</param>
        /// <param name="_dropDownStyle">设置显示类型</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvComboBoxExColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText, bool _readOnly, bool _visible,
            DataTable _cboDataSource, string _displayMember, string _valueMember,
            int _maxDropDownItems, ComboBoxStyle _dropDownStyle,
            bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewComboBoxExColumn comboBoxExCol = new DataGridViewComboBoxExColumn();
            comboBoxExCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            comboBoxExCol.Name = _columnName;
            comboBoxExCol.HeaderText = _headerText;
            comboBoxExCol.DataPropertyName = _dataPropertyName;
            comboBoxExCol.ToolTipText = _toolTipText;
            comboBoxExCol.Visible = _visible;
            comboBoxExCol.ReadOnly = _readOnly;
            comboBoxExCol.DataSource = _cboDataSource;
            comboBoxExCol.DisplayMember = _displayMember;
            comboBoxExCol.ValueMember = _valueMember;
            comboBoxExCol.MaxDropDownItems = _maxDropDownItems;
            comboBoxExCol.DropDownStyle = _dropDownStyle;
            if (_notEmpty == true)
            {
                comboBoxExCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(comboBoxExCol);
        }
        #endregion

        #region 创建DataGridView扩展的DateTime列
        /// <summary>
        /// 创建DataGridView扩展的DateTime列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_format">设置日期格式</param>
        /// <param name="_defaultInputValues">设置当日起为空时，是否显示默认日期，true 显示，false 不显示</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvDateTimeColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText,
            string _format, bool _defaultInputValues,
            bool _readOnly, bool _visible, bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewDateTimeInputColumn dateTimeCol = new DataGridViewDateTimeInputColumn();
            dateTimeCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            dateTimeCol.Name = _columnName;
            dateTimeCol.HeaderText = _headerText;
            dateTimeCol.DataPropertyName = _dataPropertyName;
            dateTimeCol.ToolTipText = _toolTipText;
            dateTimeCol.AutoSelectDate = true;
            dateTimeCol.CustomFormat = _format;
            dateTimeCol.DefaultInputValues = _defaultInputValues;
            dateTimeCol.Visible = _visible;
            dateTimeCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                dateTimeCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(dateTimeCol);
        }
        #endregion

        #region 创建DataGridView扩展的DoubleInput列
        /// <summary>
        /// 创建DataGridView扩展的DoubleInput列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_format">设置数字格式</param>
        /// <param name="_showUpDown">设置是否显示上下调节按钮，true 显示，false 不显示</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvDoubleInputColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText,
            string _format, bool _showUpDown,
            bool _readOnly, bool _visible, bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewDoubleInputColumn doubleInputCol = new DataGridViewDoubleInputColumn();
            doubleInputCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            doubleInputCol.Name = _columnName;
            doubleInputCol.HeaderText = _headerText;
            doubleInputCol.DataPropertyName = _dataPropertyName;
            doubleInputCol.ToolTipText = _toolTipText;
            doubleInputCol.DisplayFormat = _format;
            doubleInputCol.ShowUpDown = _showUpDown;
            doubleInputCol.Visible = _visible;
            doubleInputCol.ReadOnly = _readOnly;
            doubleInputCol.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Right;
            if (_notEmpty == true)
            {
                doubleInputCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(doubleInputCol);
        }
        #endregion

        #region 创建DataGridView扩展的Image列
        /// <summary>
        /// 创建DataGridView扩展的Image列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_image">图片</param>
        /// <param name="_layout">设置图片布局方式</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvImageColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText,
            Image _image, DataGridViewImageCellLayout _layout,
            bool _readOnly, bool _visible, bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            imageCol.Name = _columnName;
            imageCol.HeaderText = _headerText;
            imageCol.DataPropertyName = _dataPropertyName;
            imageCol.ToolTipText = _toolTipText;
            imageCol.Image = _image;
            imageCol.ImageLayout = _layout;
            imageCol.Visible = _visible;
            imageCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                imageCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(imageCol);
        }
        #endregion

        #region 创建DataGridView扩展的IntegerInput列
        /// <summary>
        /// 创建DataGridView扩展的IntegerInput列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_showUpDown">设置列是否显示上下可调节按钮，true 显示，false 隐藏</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvIntegerInputColumn(DataGridView _dgv,
           DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
           string _dataPropertyName, string _toolTipText, bool _showUpDown,
           bool _readOnly, bool _visible, bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewIntegerInputColumn integerInputCol = new DataGridViewIntegerInputColumn();
            integerInputCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            integerInputCol.Name = _columnName;
            integerInputCol.HeaderText = _headerText;
            integerInputCol.DataPropertyName = _dataPropertyName;
            integerInputCol.ToolTipText = _toolTipText;
            integerInputCol.ShowUpDown = _showUpDown;
            integerInputCol.Visible = _visible;
            integerInputCol.ReadOnly = _readOnly;
            integerInputCol.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Right;
            if (_notEmpty == true)
            {
                integerInputCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(integerInputCol);
        }
        #endregion

        #region 创建DataGridView扩展的IpAddressInput列
        /// <summary>
        /// 创建DataGridView扩展的IpAddressInput列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvIpAddressInputColumn(DataGridView _dgv,
          DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
          string _dataPropertyName, string _toolTipText,
          bool _readOnly, bool _visible, bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewIpAddressInputColumn ipCol = new DataGridViewIpAddressInputColumn();
            ipCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            ipCol.Name = _columnName;
            ipCol.HeaderText = _headerText;
            ipCol.DataPropertyName = _dataPropertyName;
            ipCol.ToolTipText = _toolTipText;
            ipCol.Visible = _visible;
            ipCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                ipCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(ipCol);
        }
        #endregion

        #region 创建DataGridView扩展的Lable列
        /// <summary>
        /// 创建DataGridView扩展的Lable列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_familyName">设置字体</param>
        /// <param name="_fontSize">设置字体大小</param>
        /// <param name="_fontStyle">设置字体样式</param>
        /// <param name="_fontColor">设置字体颜色</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvLableXColumn(DataGridView _dgv,
           DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
           string _dataPropertyName, string _toolTipText,
           string _familyName, float _fontSize, FontStyle _fontStyle, Color _fontColor,
           bool _readOnly, bool _visible, bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewLabelXColumn lablelXCol = new DataGridViewLabelXColumn();
            lablelXCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            lablelXCol.Name = _columnName;
            lablelXCol.HeaderText = _headerText;
            lablelXCol.DataPropertyName = _dataPropertyName;
            lablelXCol.ToolTipText = _toolTipText;
            lablelXCol.Visible = _visible;
            lablelXCol.ReadOnly = _readOnly;
            lablelXCol.DefaultCellStyle.ForeColor = _fontColor;
            lablelXCol.DefaultCellStyle.SelectionForeColor = _fontColor;
            lablelXCol.DefaultCellStyle.Font = new Font(_familyName, _fontSize, _fontStyle);
            if (_notEmpty == true)
            {
                lablelXCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(lablelXCol);
        }
        #endregion

        #region 创建DataGridView扩展的Link列
        /// <summary>
        /// 创建DataGridView扩展的Link列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_fontColor">设置字体颜色</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvLinkColumn(DataGridView _dgv,
           DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
           string _dataPropertyName, string _toolTipText, Color _fontColor,
           bool _readOnly, bool _visible, bool _notEmpty, Color _backColor, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewLinkColumn linkCol = new DataGridViewLinkColumn();
            linkCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            linkCol.Name = _columnName;
            linkCol.HeaderText = _headerText;
            linkCol.DataPropertyName = _dataPropertyName;
            linkCol.ToolTipText = _toolTipText;
            linkCol.Visible = _visible;
            linkCol.ReadOnly = _readOnly;
            linkCol.LinkColor = _fontColor;
            linkCol.UseColumnTextForLinkValue = true;
            linkCol.LinkBehavior = LinkBehavior.AlwaysUnderline;
            linkCol.DefaultCellStyle.ForeColor = _fontColor;
            linkCol.DefaultCellStyle.SelectionForeColor = _fontColor;
            if (_notEmpty == true)
            {
                linkCol.DefaultCellStyle.BackColor = _backColor;
            }
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(linkCol);
        }
        #endregion

        #region 创建DataGridView的扩展的MaskedTextBoxAdvColumn列
        /// <summary>
        /// 创建DataGridView的扩展的MaskedTextBoxAdvColumn列
        /// </summary>
        /// <param name="_dgv">要创建列的DataGridView</param>
        /// <param name="_alignment">设置列的对齐方式</param>
        /// <param name="_columnName">列名</param>
        /// <param name="_headerText">标题名</param>
        /// <param name="_dataPropertyName">绑定数据源的字段名称</param>
        /// <param name="_toolTipText">TipText提示</param>
        /// <param name="_maxInputLength">可输入的最大长度</param>
        /// <param name="_readOnly">设置列是否只读，true 只读，false 读写</param>
        /// <param name="_visible">设置列是否可见，true 显示，false 隐藏</param>
        /// <param name="_notEmpty">设置列是否为必填列，true 必填，false 非必填</param>
        /// <param name="_backColor">设置列的背景色，当_notEmpty为true时，此项为必需值，为false，此项可以为Color.Empty</param>
        /// <param name="_buttonCustomVisible">设置是否显示可选择按钮，true 显示，false 隐藏</param>
        /// <param name="_columnState">装载DataGridView可写可读、只读列的数据字典</param>
        public static void InitDgvMaskedTextBoxAdvColumn(DataGridView _dgv,
            DataGridViewContentAlignment _alignment, string _columnName, string _headerText,
            string _dataPropertyName, string _toolTipText, int _maxInputLength, bool _readOnly, bool _visible,
            bool _notEmpty, Color _backColor, bool _buttonCustomVisible, ref Dictionary<string, bool> _columnState)
        {
            DataGridViewMaskedTextBoxAdvColumn maskedTextBoxAdvCol = new DataGridViewMaskedTextBoxAdvColumn();
            maskedTextBoxAdvCol.HeaderCell.Style.Alignment = _alignment == 0 ? DataGridViewContentAlignment.MiddleLeft : _alignment;
            maskedTextBoxAdvCol.Name = _columnName;
            maskedTextBoxAdvCol.HeaderText = _headerText;
            maskedTextBoxAdvCol.DataPropertyName = _dataPropertyName;
            maskedTextBoxAdvCol.ToolTipText = _toolTipText;
            maskedTextBoxAdvCol.MaxInputLength = _maxInputLength;
            maskedTextBoxAdvCol.Visible = _visible;
            maskedTextBoxAdvCol.ReadOnly = _readOnly;
            if (_notEmpty == true)
            {
                maskedTextBoxAdvCol.DefaultCellStyle.BackColor = _backColor;
            }
            maskedTextBoxAdvCol.ButtonCustom.Visible = _buttonCustomVisible;
            _columnState.Add(_columnName, _readOnly);
            _dgv.Columns.Add(maskedTextBoxAdvCol);
        }
        #endregion

        #region 合并单元格
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="columnIndexList">合并的列索引</param>
        /// <param name="dgv">DataGridView控件</param>
        /// <param name="e"></param>
        public static void DataGridViewRowSpan(ArrayList columnIndexList, DataGridView dgv, DataGridViewCellPaintingEventArgs e)
        {
            int cellheight;
            int fontheight;
            int cellwidth;
            int fontwidth;
            int countU = 0;
            int countD = 0;
            int count = 0;
            int totalheight = 0;
            int heightU = 0;
            int heightD = 0;
            //纵向合并
            if (columnIndexList.Contains(e.ColumnIndex) && e.RowIndex >= 0)
            {
                cellheight = e.CellBounds.Height;
                fontheight = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Height;
                cellwidth = e.CellBounds.Width;
                fontwidth = (int)e.Graphics.MeasureString(e.Value.ToString(), e.CellStyle.Font).Width;
                string curValue = dgv.Rows[e.RowIndex].Cells[0].Value == null ? "" : dgv.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                string curSelected = dgv.CurrentRow.Cells[0].Value == null ? "" : dgv.CurrentRow.Cells[0].Value.ToString().Trim();
                if (!string.IsNullOrEmpty(curValue))
                {
                    for (int i = e.RowIndex; i < dgv.Rows.Count; i++)
                    {
                        if (dgv.Rows[i].Cells[0].Value.ToString().Equals(curValue))
                        {
                            dgv.Rows[i].Cells[0].Selected = dgv.Rows[e.RowIndex].Selected;
                            dgv.Rows[i].Selected = dgv.Rows[e.RowIndex].Selected;
                            countD++;
                            heightD += dgv.Rows[i].Height;
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int i = e.RowIndex; i >= 0; i--)
                    {
                        if (dgv.Rows[i].Cells[0].Value.ToString().Equals(curValue))
                        {
                            dgv.Rows[i].Cells[0].Selected = dgv.Rows[e.RowIndex].Selected;
                            dgv.Rows[i].Selected = dgv.Rows[e.RowIndex].Selected;
                            heightU += dgv.Rows[i].Height;
                            countU++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    heightU = heightU - e.CellBounds.Height;
                    totalheight = heightU + heightD;
                    count = countD + countU - 1;
                    if (count < 2) { return; }
                }


                Brush gridBrush = new SolidBrush(dgv.GridColor),
                backColorBrush = new SolidBrush(e.CellStyle.BackColor);

                Pen gridLinePen = new Pen(gridBrush);

                // 擦除原单元格背景
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);
                ////绘制线条,这些线条是单元格相互间隔的区分线条,
                ////因为我们只对列name做处理,所以datagridview自己会处理左侧和上边缘的线条
                if (e.RowIndex != dgv.RowCount - 1)
                {
                    if (e.Value.ToString() != dgv.Rows[e.RowIndex + 1].Cells[e.ColumnIndex].Value.ToString())
                    {
                        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                        e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);//下边缘的线
                        //绘制值
                        if (e.Value != null)
                        {
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                Brushes.Black, e.CellBounds.X,
                            e.CellBounds.Y - heightU + (totalheight - fontheight) / 2,
                            StringFormat.GenericDefault);
                        }
                    }
                    else
                    {
                        //绘制值
                        if (e.Value != null)
                        {
                            e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                                Brushes.Black, e.CellBounds.X,
                            e.CellBounds.Y - heightU + (totalheight - fontheight) / 2,
                            StringFormat.GenericDefault);
                        }
                    }
                }
                else
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                        e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);//下边缘的线
                    //绘制值
                    if (e.Value != null)
                    {
                        e.Graphics.DrawString(e.Value.ToString(), e.CellStyle.Font,
                            Brushes.Black, e.CellBounds.X,
                            e.CellBounds.Y - heightU + (totalheight - fontheight) / 2,
                            StringFormat.GenericDefault);
                    }
                }
                //右侧的线
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
                    e.CellBounds.Top, e.CellBounds.Right - 1,
                    e.CellBounds.Bottom - 1);
                e.Handled = true;

            }

            //单击单元格改变颜色
            dgv.CellClick += new DataGridViewCellEventHandler(dgv_CellClick);

        }

        private static int rowIndex = -1;
        private static int colIndex = -1;
        static void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                rowIndex = e.RowIndex;
                colIndex = e.RowIndex;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j] != dgv.Rows[rowIndex].Cells[colIndex])
                        {
                            dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
                            dgv.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                        }
                        else
                        {
                            dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = SystemColors.Info;
                        }
                    }
                }

                dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;

            }
            catch
            {

            }
        }
        #endregion
    }
}