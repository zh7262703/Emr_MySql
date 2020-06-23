using System.Collections.Generic;
using System.Windows.Forms;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;
using EmrCommon;

namespace Base_Function.TEMPLATE
{
    public partial class frmMacrosElement : DevComponents.DotNetBar.Office2007Form
    {
        /// <summary>
        /// 修改一个宏元素
        /// </summary>
        /// <param name="element"></param>
        public frmMacrosElement(T_MACROS_ELEMENTS element)
        {
            InitializeComponent();
            entity = element;
            this.txtName.ReadOnly = true;
            this.BindControls();
            this.LoadData();
        }

        /// <summary>
        /// 创建一个宏元素
        /// </summary>
        /// <param name="type"></param>
        public frmMacrosElement(string type)
        {
            InitializeComponent();
            entity = new T_MACROS_ELEMENTS();
            entity.Type = type;
            this.BindControls();
            this.LoadData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        void BindControls()
        {
            this.txtName.DataBindings.Add(new Binding("Text", this.entity, "Name"));
            this.txtDesc.DataBindings.Add(new Binding("Text", this.entity, "Description", false, DataSourceUpdateMode.OnPropertyChanged));
            this.txtColname.DataBindings.Add(new Binding("Text", this.entity, "ColName", false, DataSourceUpdateMode.OnPropertyChanged));
            this.txtDefaultValue.DataBindings.Add(new Binding("Text", this.entity, "Default_Value", false, DataSourceUpdateMode.OnPropertyChanged));
            this.txtFormat.DataBindings.Add(new Binding("Text", this.entity, "Format"));
            this.txtSplit.DataBindings.Add(new Binding("Text", this.entity, "Split"));
            this.txtSelectIndex.DataBindings.Add(new Binding("Text", this.entity, "Select_Index"));
            this.txtJoin.DataBindings.Add(new Binding("Text", this.entity, "Join"));
            this.cbEnable.Checked = this.entity.Enable.IsNotEmpty() && this.entity.Enable.Equals("1");
            if (this.entity.OnlyOnNull.IsNotEmpty() && this.entity.OnlyOnNull.Equals("0"))
                this.cbOnlyOnNull.Checked = false;
            else
                this.cbOnlyOnNull.Checked = true;
        }

        T_MACROS_ELEMENTS entity = null;
        List<EmrCommon.DataEntity> cols = new List<EmrCommon.DataEntity>();

        void LoadData()
        {
            this.cols.Clear();
            switch (this.entity.Type)
            {
                case "1":
                    this.LoadPatientCols();
                    break;
                case "2":
                    this.LoadUserPs();
                    break;
                case "3":
                    this.LoadRolePs();
                    break;
                case "4":
                    break;
                case "5":
                    this.LoadPatientDiagnoseTypes();
                    break;
                case "6":
                    this.LoadPatientVitalCols();
                    break;
                case "7":
                    this.LoadPatientOtherVitalCols();
                    break;
                default:
                    break;
            }
            this.dataGridView1.DataSource = this.cols;
            this.dataGridView1.Columns["Id"].HeaderText = "列名";
            this.dataGridView1.Columns["Name"].HeaderText = "描述";
            this.dataGridView1.Columns["Code"].Visible = false;
            Bifrost.GridAction.SetGridStyle(this.dataGridView1);
            this.dataGridView1.DoubleClick += DataGridView1_DoubleClick;
        }

        private void DataGridView1_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                var row = this.cols[this.dataGridView1.SelectedRows[0].Index];
                this.txtColname.Text = row.Id;
                this.txtDesc.Text = row.Name;
            }
        }

        /// <summary>
        /// 加载用户属性
        /// </summary>
        void LoadUserPs()
        {
            var res = DataInit.GetPropertyDescription(Bifrost.App.UserAccount.UserInfo);
            if (res != null)
            {
                this.cols.AddRange(res);
            }
        }

        /// <summary>
        /// 加载角色属性
        /// </summary>
        void LoadRolePs()
        {
            var res = DataInit.GetPropertyDescription(Bifrost.App.UserAccount.CurrentSelectRole);
            if (res != null)
            {
                this.cols.AddRange(res);
            }
        }

        /// <summary>
        /// 加载患者视图的列属性
        /// </summary>
        void LoadPatientCols()
        {
            var res = DataInit.GetObjectComments("V_PATIENT_BASEINFO");
            if (res != null)
                this.cols.AddRange(res);
        }

        /// <summary>
        /// 加载体征信息的列属性
        /// </summary>
        void LoadPatientVitalCols()
        {
            var res = DataInit.GetObjectComments("v_patient_tpr");
            if (res != null)
                this.cols.AddRange(res);
        }

        /// <summary>
        /// 加载其他体征信息的列属性
        /// </summary>
        void LoadPatientOtherVitalCols()
        {
            var res = DataInit.GetObjectComments("v_patient_other_vital");
            if (res != null)
                this.cols.AddRange(res);
        }

        /// <summary>
        /// 加载诊断类型
        /// </summary>
        void LoadPatientDiagnoseTypes()
        {
            var res = EmrDAL.DbQuery.Query<EmrCommon.DataEntity>(" select a.id,a.name from t_data_code a where a.type='65'");
            if (res != null)
                this.cols.AddRange(res);
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            bool res = false;
            if (entity.Name.IsNullOrEmpty())
            {
                Bifrost.App.Msg("名称不能为空!");
                return;
            }
            entity.Enable = this.cbEnable.Checked ? "1" : "0";
            entity.OnlyOnNull = this.cbOnlyOnNull.Checked ? "1" : "0";
            if (entity.Id > 0)
            {
                EmrDAL.DbCud.Delete<T_MACROS_ELEMENTS>(o => o.Id == entity.Id);
                res = EmrDAL.DbCud.Insert(entity);
            }
            else
            {
                int count = EmrDAL.DbQuery.Count<T_MACROS_ELEMENTS>(o => o.ColName, o => o.Name.Equals(entity.Name));
                if (count > 0)
                {
                    Bifrost.App.Msg("已经存在名称为：" + entity.Name + "的元素，不能重复!");
                    return;
                }
                entity.Id = Bifrost.App.GenId();
                res = EmrDAL.DbCud.Insert(entity);
            }
            if (res)
            {
                Bifrost.App.Msg("操作成功!");
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
