using System;
using System.Collections.Generic;
using System.Text;
using NewLife.Reflection;
using NewLife.Web;
using XCode;
using XCode.Configuration;
using ExtAspNet;
using System.Web.UI;
using NewLife.CommonEntity.Common;


namespace NewLife.CommonEntity.Web
{
    /// <summary>
    /// 实体表单基类
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    /// <typeparam name="TEntity">表单实体类</typeparam>
    public class ExtEntityForm<TKey, TEntity> : WebPageBase
        where TEntity : Entity<TEntity>, new()
    {
        #region 基本属性
        /// <summary>
        /// 主键名称，字符串默认返回Guid，其它默认返回ID
        /// </summary>
        protected virtual String EntityKeyName
        {
            get
            {
                if (Entity<TEntity>.Meta.Unique != null) return Entity<TEntity>.Meta.Unique.Name;

                Type type = typeof(TKey);
                if (type == typeof(Int32))
                    return "ID";
                else if (type == typeof(String))
                    return "Guid";
                else
                    return "ID";
            }
        }

        /// <summary>主键</summary>
        public TKey EntityID
        {
            get
            {
                String str = Request[EntityKeyName];
                if (String.IsNullOrEmpty(str)) return default(TKey);

                Type type = typeof(TKey);
                if (type == typeof(Int32))
                {
                    Int32 id = 0;
                    if (!Int32.TryParse(str, out id)) id = 0;
                    return (TKey)(Object)id;
                }
                else if (type == typeof(String))
                {
                    return (TKey)(Object)str;
                }
                else
                    throw new NotSupportedException("仅支持整数和字符串类型！");
            }
        }

        private TEntity _Entity;
        /// <summary>数据实体</summary>
        public virtual TEntity Entity
        {
            get { return _Entity ?? (_Entity = GetEntity()); }
            set { _Entity = value; }
        }

        /// <summary>获取数据实体，允许页面重载改变实体</summary>
        protected virtual TEntity GetEntity()
        {
            return Entity<TEntity>.FindByKeyForEdit(EntityID);
        }

        /// <summary>
        /// 表单项名字前缀，默认frm
        /// </summary>
        protected virtual String FormItemPrefix { get { return "frm"; } }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 保存按钮(保存后关闭)，查找名为btnSave或UpdateButton（兼容旧版本）的按钮，如果没找到，将使用第一个使用了提交行为的按钮
        /// </summary>
        protected virtual ExtAspNet.Button SaveCloseButton
        {
            get
            {
                foreach (Toolbar item in ExtSimpleForm.Toolbars)
                {
                    foreach (ControlBase Subitem in item.Items)
                    {
                        if (Subitem.ID == "btnSaveClose")
                            return Subitem as Button;
                    }
                }

                return null;
            }
        }

        /// <summary>
        /// 保存按钮(保存后继续)，查找名为btnSaveContinue的按钮，如果没找到，将使用第一个使用了提交行为的按钮
        /// </summary>
        protected virtual ExtAspNet.Button SaveContinueButton
        {
            get
            {
                foreach (Toolbar item in ExtSimpleForm.Toolbars)
                {
                    foreach (ControlBase Subitem in item.Items)
                    {
                        if (Subitem.ID == "btnSaveContinue")
                            return Subitem as Button;
                    }
                }
                return null;
            }
        }

        /// <summary>
        /// 关闭按钮，查找名为btnSave或UpdateButton（兼容旧版本）的按钮，如果没找到，将使用第一个使用了提交行为的按钮
        /// </summary>
        protected virtual ExtAspNet.Button CloseButton
        {
            get
            {
                foreach (Toolbar item in ExtSimpleForm.Toolbars)
                {
                    foreach (ControlBase Subitem in item.Items)
                    {
                        if (Subitem.ID == "btnClose")
                            return Subitem as Button;
                    }
                }
                return null;
            }
        }
        /// <summary>
        /// 简单表单
        /// </summary>
        protected virtual SimpleForm ExtSimpleForm
        {
            get
            {
                System.Web.UI.Control control = ExtAspNet.ControlUtil.FindControl("SimpleForm1");
                if (control != null) return control as SimpleForm;

                control = FindControl("UpdateButton");
                if (control != null) return control as SimpleForm;

                //// 随便找一个按钮
                //ExtAspNet.Button btn = ControlHelper.FindControl<ExtAspNet.Button>(Page, null);
                //if (btn != null && btn) return btn;

                return null;
            }
        }

        /// <summary>
        /// 是否空主键
        /// </summary>
        protected virtual Boolean IsNullKey
        {
            get
            {
                Type type = typeof(TKey);
                if (type == typeof(Int32))
                {
                    return (Int32)(Object)EntityID <= 0;
                }
                else if (type == typeof(String))
                {
                    return String.IsNullOrEmpty((String)(Object)EntityID);
                }
                else
                    throw new NotSupportedException("仅支持整数和字符串类型！");
            }
        }

        /// <summary>
        /// 扩展字段下拉列表框展示控件
        /// </summary>
        protected Dictionary<string, ExtAspNet.DropDownList> RelationsDropDownList = new Dictionary<string, ExtAspNet.DropDownList>();
        /// <summary>
        /// 扩展字段触发器输入框展示控件
        /// </summary>
        protected Dictionary<string, ExtAspNet.TriggerBox> RelationsTriggerBox = new Dictionary<string, TriggerBox>();
        #endregion

        #region 事件
        /// <summary>
        /// 已重载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitForm();
        }


        /// <summary>
        /// 已重载。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);

            if (!Page.IsPostBack)
            {
                // 判断实体
                if (Entity == null)
                {
                    String msg = null;
                    if (IsNullKey)
                        msg = String.Format("参数错误！无法取得编号为{0}的{1}！可能未设置自增主键！", EntityID, Entity<TEntity>.Meta.TableName);
                    else
                        msg = String.Format("参数错误！无法取得编号为{0}的{1}！", EntityID, Entity<TEntity>.Meta.TableName);

                    ExtAspNet.Alert.ShowInTop(msg);
                    Response.Write(msg);
                    Response.End();
                    return;
                }

                //ExtAspNet.Button btnSaveClose = SaveCloseButton;
                //ExtAspNet.Button btnSaveContinue = SaveContinueButton;
                //ExtAspNet.Button CloseBtn = CloseButton;

                //if (CloseBtn != null)
                //    CloseButton.OnClientClick = ExtAspNet.ActiveWindow.GetConfirmHidePostBackReference();
                
                //if (btnSaveClose != null)
                //    btnSaveClose.Click += delegate { GetForm(); SaveFormWithTrans(true); };

                //if (btnSaveContinue != null)
                //    btnSaveContinue.Click += delegate { GetForm(); SaveFormWithTrans(false); };

                SetForm();
            }

            if (SaveCloseButton != null) SaveCloseButton.Click += delegate { GetForm(); SaveFormWithTrans(true); };
            if (SaveContinueButton != null) SaveContinueButton.Click += delegate { GetForm(); SaveFormWithTrans(true); };
            if (CloseButton != null) CloseButton.OnClientClick = ExtAspNet.ActiveWindow.GetConfirmHidePostBackReference();

        }
        #endregion

        #region 初始化窗体
        private System.Web.UI.WebControls.ObjectDataSource ExtSource(BindRelationAttribute at)
        {
            System.Web.UI.WebControls.ObjectDataSource tmp = new System.Web.UI.WebControls.ObjectDataSource();
            tmp.ID = "ObjectDataSource" + at.RelationTable;
            tmp.DataObjectTypeName = "NewLife.CommonEntity." + at.RelationTable;
            tmp.SelectMethod = "FindAllChildsByParent";
            tmp.TypeName = "NewLife.CommonEntity." + at.RelationTable;
            tmp.OldValuesParameterFormatString = "original_{0}";
            tmp.SelectParameters.Add("parentKey", System.Data.DbType.Object, "0");

            return tmp;
        }
        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitForm()
        {
            String PKName = null;

            // 处理扩展字段
            if (Entity<TEntity>.Meta.Table.Relations != null && Entity<TEntity>.Meta.Table.Relations.Length > 0)
            {
                InitExtFields(Entity<TEntity>.Meta.Table.Relations, RelationsDropDownList, RelationsTriggerBox);
            }

            #region 处理所字段
            FieldItemEx[] fieldEx = new FieldItemEx[Entity<TEntity>.Meta.Fields.Length];
            for (int i = 0; i < Entity<TEntity>.Meta.Fields.Length; i++)
            {
                fieldEx[i] = Entity<TEntity>.Meta.Fields[i];
            }

            foreach (FieldItemEx fieldItemEx in InitFields(fieldEx))
            {
                FieldItem Field = fieldItemEx.Field;
                String pname = Field.Name;
                if (Field.PrimaryKey) { PKName = pname; continue; }

                String frmName = "frm" + pname;
                TypeCode code = Type.GetTypeCode(Field.Type);

                #region 初始化界面控件
                switch (code)
                {
                    case TypeCode.Boolean:
                        ExtAspNet.CheckBox CheckBoxTextBox = new ExtAspNet.CheckBox();
                        CheckBoxTextBox.ID = frmName;
                        CheckBoxTextBox.Label = Field.Description;
                        CheckBoxTextBox.ShowRedStar = !Field.IsNullable;
                        CheckBoxTextBox.Enabled = fieldItemEx.Editabled;
                        (ExtSimpleForm as ExtAspNet.SimpleForm).Items.Add(CheckBoxTextBox);
                        break;
                    case TypeCode.Byte:
                        break;
                    case TypeCode.Char:
                        break;
                    case TypeCode.DBNull:
                        break;
                    case TypeCode.DateTime:
                        ExtAspNet.DatePicker DateTimeTextBox = new ExtAspNet.DatePicker();
                        DateTimeTextBox.ID = frmName;
                        DateTimeTextBox.Label = Field.Description;
                        DateTimeTextBox.Required = !Field.IsNullable;
                        DateTimeTextBox.ShowRedStar = !Field.IsNullable;
                        DateTimeTextBox.Enabled = fieldItemEx.Editabled;
                        (ExtSimpleForm as ExtAspNet.SimpleForm).Items.Add(DateTimeTextBox);
                        break;
                    case TypeCode.Decimal:
                        ExtAspNet.NumberBox DecimaltBox = new ExtAspNet.NumberBox();
                        DecimaltBox.ID = frmName;
                        DecimaltBox.Label = Field.Description;
                        DecimaltBox.NoDecimal = false;
                        DecimaltBox.Required = !Field.IsNullable;
                        DecimaltBox.ShowRedStar = !Field.IsNullable;
                        DecimaltBox.Enabled = fieldItemEx.Editabled;
                        (ExtSimpleForm as ExtAspNet.SimpleForm).Items.Add(DecimaltBox);
                        break;
                    case TypeCode.Double:
                        ExtAspNet.NumberBox DoubleTextBox = new ExtAspNet.NumberBox();
                        DoubleTextBox.ID = frmName;
                        DoubleTextBox.Label = Field.Description;
                        DoubleTextBox.NoDecimal = false;
                        DoubleTextBox.Required = !Field.IsNullable;
                        DoubleTextBox.ShowRedStar = !Field.IsNullable;
                        DoubleTextBox.Enabled = fieldItemEx.Editabled;
                        (ExtSimpleForm as ExtAspNet.SimpleForm).Items.Add(DoubleTextBox);
                        break;
                    case TypeCode.Empty:
                        break;
                    case TypeCode.Int16:
                        break;
                    case TypeCode.Int32:
                        if (RelationsDropDownList.ContainsKey(Field.Name))
                        {
                            RelationsDropDownList[Field.Name].Label = Field.Description;
                            RelationsDropDownList[Field.Name].DataBind();
                            RelationsDropDownList[Field.Name].Enabled = fieldItemEx.Editabled;
                            (ExtSimpleForm as ExtAspNet.SimpleForm).Items.Add(RelationsDropDownList[Field.Name]);
                        }
                        else
                        {
                            ExtAspNet.NumberBox Int32TextBox = new ExtAspNet.NumberBox();
                            Int32TextBox.ID = frmName;
                            Int32TextBox.Label = Field.Description;
                            Int32TextBox.Required = true;
                            Int32TextBox.ShowRedStar = true;
                            Int32TextBox.Required = !Field.IsNullable;
                            Int32TextBox.ShowRedStar = !Field.IsNullable;
                            Int32TextBox.Enabled = fieldItemEx.Editabled;
                            (ExtSimpleForm as ExtAspNet.SimpleForm).Items.Add(Int32TextBox);
                        }
                        break;
                    case TypeCode.Int64:
                        break;
                    case TypeCode.Object:
                        break;
                    case TypeCode.SByte:
                        break;
                    case TypeCode.Single:
                        break;
                    case TypeCode.String:
                        #region String
                        if (pname.Equals("Password", StringComparison.OrdinalIgnoreCase) || pname.Equals("Pass", StringComparison.OrdinalIgnoreCase))
                        {
                            ExtAspNet.TextBox TextBoxP = new ExtAspNet.TextBox();
                            TextBoxP.ID = frmName;
                            TextBoxP.Label = Field.Description;
                            TextBoxP.TextMode = TextMode.Password; 
                            TextBoxP.Required = !Field.IsNullable;
                            TextBoxP.ShowRedStar = TextBoxP.Required;
                            TextBoxP.Enabled = fieldItemEx.Editabled;
                            (ExtSimpleForm as ExtAspNet.SimpleForm).Items.Add(TextBoxP);
                        }
                        else if (Field.Length > 300 || Field.Length < 0)
                        {
                            ExtAspNet.TextArea TextBoxP = new ExtAspNet.TextArea();
                            TextBoxP.ID = frmName;
                            TextBoxP.Label = Field.Description;
                            TextBoxP.Required = !Field.IsNullable;
                            TextBoxP.ShowRedStar = TextBoxP.Required;
                            TextBoxP.Enabled = fieldItemEx.Editabled;
                            (ExtSimpleForm as ExtAspNet.SimpleForm).Items.Add(TextBoxP);
                        }
                        else
                        {
                            ExtAspNet.TextBox TextBoxP = new ExtAspNet.TextBox();
                            TextBoxP.ID = frmName;
                            TextBoxP.Label = Field.Description;
                            TextBoxP.TextMode = TextMode.Text;
                            TextBoxP.Required = !Field.IsNullable;
                            TextBoxP.ShowRedStar = TextBoxP.Required;
                            TextBoxP.Enabled = fieldItemEx.Editabled;
                            (ExtSimpleForm as ExtAspNet.SimpleForm).Items.Add(TextBoxP);
                        }
                        #endregion
                        break;
                    case TypeCode.UInt16:
                        break;
                    case TypeCode.UInt32:
                        break;
                    case TypeCode.UInt64:
                        break;
                    default:
                        break;
                }
                #endregion
            }
            #endregion
        }

        /// <summary>
        /// 初始化扩展字段
        /// <param name="relations">关系</param>
        /// <param name="relationsDropDownList">扩展字段的下拉框展示控件</param>
        /// <param name="relationsTriggerBox">扩展字段的触发列表展示控件</param>
        /// </summary>
        protected virtual void InitExtFields(BindRelationAttribute[] relations
            , Dictionary<string, ExtAspNet.DropDownList> relationsDropDownList
            , Dictionary<string, ExtAspNet.TriggerBox> relationsTriggerBox)
        {
        }

        /// <summary>
        /// 将实体字段处理后返回，例如删除不需要显示或更改的字段
        /// </summary>
        /// <param name="fields">实体上的所有字段</param>
        /// <returns>处理后的字段</returns>
        protected virtual FieldItemEx[] InitFields(FieldItemEx[] fields)
        {
            bool needSort = true;
            while (needSort)
            {
                needSort = false;
                for (int i = 0; i < fields.Length - 1; i++)
                {
                    if (fields[i].Field.Column.Order > fields[i + 1].Field.Column.Order)
                    {
                        FieldItemEx temp = fields[i];
                        fields[i] = fields[i + 1];
                        fields[i + 1] = temp;
                        needSort = true;
                    }
                }
            }
            return fields;
        }

        #endregion

        #region 加载
        /// <summary>
        /// 把实体的属性设置到控件上
        /// </summary>
        protected virtual void SetForm()
        {
            // 是否有权限保存数据
            Boolean canSave = CanSave;

            foreach (FieldItem item in Entity<TEntity>.Meta.AllFields)
            {
                System.Web.UI.Control control = ExtAspNet.ControlUtil.FindControl(FormItemPrefix + item.Name);
                if (control == null) continue;

                try
                {
                    SetFormItem(item, control, canSave);
                }
                catch (Exception ex)
                {
                    WebHelper.Alert("设置" + item.Name + "的数据时出错！" + ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// 是否有权限保存数据
        /// </summary>
        protected virtual Boolean CanSave
        {
            get
            {
                return IsNullKey && Acquire(PermissionFlags.Insert) || Acquire(PermissionFlags.Update);
            }
        }

        /// <summary>
        /// 把实体成员的值设置到控件上
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        /// <param name="canSave"></param>
        protected virtual void SetFormItem(FieldItem field, System.Web.UI.Control control, Boolean canSave)
        {
            if (field == null || control == null) return;

            String toolTip = String.IsNullOrEmpty(field.Description) ? field.Name : field.Description;
            if (field.IsNullable)
                toolTip = String.Format("请填写{0}！", toolTip);
            else
                toolTip = String.Format("必须填写{0}！", toolTip);

            if (control is Label) toolTip = null;

            if (control is ExtAspNet.ControlBase)
            {
                ExtAspNet.ControlBase wc = control as ExtAspNet.ControlBase;

                // 设置ToolTip
                //if (String.IsNullOrEmpty(wc.ToolTip) && !String.IsNullOrEmpty(toolTip)) wc.ToolTip = toolTip;

                //// 必填项
                //if (!field.IsNullable) SetNotAllowNull(field, control, canSave);

                // 设置只读，只有不能保存时才设置，因为一般都不是只读，而前端可能自己设置了控件为只读，这种情况下这里再设置就会修改前端的意思
                if (!canSave)
                {
                    if (wc is ExtAspNet.TextBox)
                        (wc as TextBox).Enabled = !canSave;
                    else
                        wc.Enabled = canSave;
                }

                // 分控件处理
                if (wc is TextBox || wc is DatePicker)
                    SetFormItemTextBox(field, wc as RealTextField, canSave);
                else if (wc is Label)
                    SetFormItemLabel(field, wc as Label, canSave);
                else if (wc is RadioButton)
                    SetFormItemRadioButton(field, wc as RadioButton, canSave);
                else if (wc is CheckBox)
                    SetFormItemCheckBox(field, wc as CheckBox, canSave);
                else if (wc is DropDownList)
                    SetFormItemListControl(field, wc as DropDownList, canSave);
                else
                {
                    SetControlValue(control as ControlBase, Entity[field.Name]);
                }
            }
            else
            {
                SetControlValue(control as ControlBase, Entity[field.Name]);

                PropertyInfoX pix = PropertyInfoX.Create(control.GetType(), "ToolTip");
                if (pix != null && String.IsNullOrEmpty((String)pix.GetValue(control)))
                {
                    pix.SetValue(control, toolTip);
                }
            }
        }

        /// <summary>
        /// 文本框
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        /// <param name="canSave"></param>
        protected virtual void SetFormItemTextBox(FieldItem field, RealTextField control, Boolean canSave)
        {
            Type type = field.Type;
            Object value = Entity[field.Name];
            if (type == typeof(DateTime))
            {
                DateTime d = (DateTime)value;
                if (IsNullKey && d == DateTime.MinValue) d = DateTime.Now;

                (control as DatePicker).SelectedDate = d;
            }
            else
            {
                if(!SetControlValue(control, value)) control.Text = value.ToString();
            }
        }

        /// <summary>
        /// 标签
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        /// <param name="canSave"></param>
        protected virtual void SetFormItemLabel(FieldItem field, Label control, Boolean canSave)
        {
            Type type = field.Type;
            if (type == typeof(DateTime))
            {
                DateTime d = (DateTime)Entity[field.Name];
                if (IsNullKey && d == DateTime.MinValue) d = DateTime.Now;
                control.Text = d.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else if (type == typeof(Decimal))
            {
                Decimal d = (Decimal)Entity[field.Name];
                control.Text = d.ToString("c");
            }
            else
                control.Text = String.Empty + Entity[field.Name];
        }

        /// <summary>
        /// 复选框
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        /// <param name="canSave"></param>
        protected virtual void SetFormItemCheckBox(FieldItem field, CheckBox control, Boolean canSave)
        {
            Type type = field.Type;
            ExtAspNet.CheckBox controlChk = control as ExtAspNet.CheckBox;
            if (type == typeof(Boolean))
                controlChk.Checked = (Boolean)Entity[field.Name];
            else if (type == typeof(Int32))
                controlChk.Checked = (Int32)Entity[field.Name] != 0;
            else
                controlChk.Checked = Entity[field.Name] != null;
        }

        /// <summary>
        /// 列表框
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        /// <param name="canSave"></param>
        protected virtual void SetFormItemListControl(FieldItem field, DropDownList control, Boolean canSave)
        {
            if (control.Items.Count < 1) return;

            String value = String.Empty + Entity[field.Name];

            ListItem li = control.Items.FindByValue(value);
            if (li != null)
            {
                //li.Selected = true;
                control.SelectedValue = li.Value;
            }
            else
            {
                li = new ListItem(value, value);
                control.Items.Add(li);
                li.Selected = true;
            }
        }

        /// <summary>
        /// 单选框
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        /// <param name="canSave"></param>
        protected virtual void SetFormItemRadioButton(FieldItem field, RadioButton control, Boolean canSave)
        {
            List<RadioButton> list = new List<RadioButton>();
            // 找到同一级同组名的所有单选
            foreach (ControlBase item in control.Parent.Controls)
            {
                if (!(item is RadioButton)) continue;

                RadioButton rb = item as RadioButton;
                if (rb.GroupName != control.GroupName) continue;

                list.Add(rb);
            }
            if (list.Count < 1) return;

            // 特殊处理数字
            if (field.Type == typeof(Int32))
            {
                Int32 id = (Int32)Entity[field.Name];
                if (id < 0 || id >= list.Count) id = 0;
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Checked = (i == id);
                }
            }
            else
            {
                String value = String.Empty + Entity[field.Name];

                foreach (RadioButton item in list)
                {
                    item.Checked = item.Text == value;
                }
            }
        }

        #endregion

        #region 读取
        /// <summary>
        /// 读取控件的数据保存到实体中去
        /// </summary>
        protected virtual void GetForm()
        {
            foreach (FieldItem item in Entity<TEntity>.Meta.AllFields)
            {
                ControlBase control = null;
                foreach (ControlBase Controlitem in ExtSimpleForm.Items)
                {
                    if (Controlitem.ID == FormItemPrefix + item.Name)
                    {
                        control = Controlitem;
                        break;
                    }
                }
                if (control == null) continue;

                try
                {
                    GetFormItem(item, control);
                }
                catch (Exception ex)
                {
                    WebHelper.Alert("读取" + item.Name + "的数据时出错！" + ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// 把控件的值设置到实体属性上
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        protected virtual void GetFormItem(FieldItem field, ControlBase control)
        {
            if (field == null || control == null) return;

            if (control is ControlBase)
            {
                ControlBase wc = control as ControlBase;

                // 分控件处理
                if (wc is TextBox)
                    GetFormItemTextBox(field, wc as TextBox);
                else if (wc is Label)
                    GetFormItemLabel(field, wc as Label);
                else if (wc is RadioButton)
                    GetFormItemRadioButton(field, wc as RadioButton);
                else if (wc is CheckBox)
                    GetFormItemCheckBox(field, wc as CheckBox);
                else if (wc is DropDownList)
                    GetFormItemListControl(field, wc as DropDownList);
                else
                {
                    Object v = null;
                    if (GetControlValue(control, out v) && !Object.Equals(Entity[field.Name], v)) SetEntityItem(field, v);
                }
            }
            else
            {
                Object v = null;
                if (GetControlValue(control, out v) && !Object.Equals(Entity[field.Name], v)) SetEntityItem(field, v);
            }
        }

        void SetEntityItem(FieldItem field, Object value)
        {
            // 先转为目标类型
            value = TypeX.ChangeType(value, field.Type);
            // 如果是字符串，并且为空，则让它等于实体里面的值，避免影响脏数据
            if (field.Type == typeof(String) && String.IsNullOrEmpty((String)value) && String.IsNullOrEmpty((String)Entity[field.Name])) value = Entity[field.Name];
            Entity.SetItem(field.Name, value);
        }

        /// <summary>
        /// 文本框
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        protected virtual void GetFormItemTextBox(FieldItem field, TextBox control)
        {
            //String v = control.Text;
            //if (!Object.Equals(Entity[field.Name], v)) SetEntityItem(field, v);

            Object v = null;
            if (!GetControlValue(control, out v)) v = control.Text;
            if (!Object.Equals(Entity[field.Name], v)) SetEntityItem(field, v);
        }

        /// <summary>
        /// 标签，不做任何操作
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        protected virtual void GetFormItemLabel(FieldItem field, Label control)
        {

        }

        /// <summary>
        /// 复选框
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        protected virtual void GetFormItemCheckBox(FieldItem field, CheckBox control)
        {
            Type type = field.Type;
            Object v;
            if (type == typeof(Boolean))
                v = control.Checked;
            else if (type == typeof(Int32))
                v = control.Checked ? 1 : 0;
            else
                v = control.Checked;

            if (!Object.Equals(Entity[field.Name], v)) SetEntityItem(field, v);
        }

        /// <summary>
        /// 列表框
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        protected virtual void GetFormItemListControl(FieldItem field, DropDownList control)
        {
            //if (String.IsNullOrEmpty(control.SelectedValue)) return;

            String v = control.SelectedValue;
            if (!Object.Equals(Entity[field.Name], v)) SetEntityItem(field, v);
        }

        /// <summary>
        /// 单选框
        /// </summary>
        /// <param name="field"></param>
        /// <param name="control"></param>
        protected virtual void GetFormItemRadioButton(FieldItem field, RadioButton control)
        {
            List<RadioButton> list = new List<RadioButton>();
            // 找到同一级同组名的所有单选
            foreach (Control item in control.Parent.Controls)
            {
                if (!(item is RadioButton)) continue;

                RadioButton rb = item as RadioButton;
                if (rb.GroupName != control.GroupName) continue;

                list.Add(rb);
            }
            if (list.Count < 1) return;

            // 特殊处理数字
            if (field.Type == typeof(Int32))
            {
                Int32 id = -1;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Checked)
                    {
                        id = i;
                        break;
                    }
                }
                if (id >= 0 && !Object.Equals(Entity[field.Name], id)) SetEntityItem(field, id);
            }
            else
            {
                foreach (RadioButton item in list)
                {
                    if (item.Checked)
                    {
                        if (!Object.Equals(Entity[field.Name], item.Text)) SetEntityItem(field, item.Text);
                    }
                }
            }
        }
        #endregion

        #region 保存
        private void SaveFormWithTrans(bool closeAfterSave)
        {
            Entity<TEntity>.Meta.BeginTrans();
            try
            {
                SaveForm();

                Entity<TEntity>.Meta.Commit();

                SaveFormSuccess(closeAfterSave);
            }
            catch (Exception ex)
            {
                Entity<TEntity>.Meta.Rollback();

                SaveFormUnsuccess(ex);
            }
        }

        /// <summary>
        /// 保存表单，把实体保存到数据库，当前方法处于事务保护之中
        /// </summary>
        protected virtual void SaveForm()
        {
            Entity.Save();
        }

        /// <summary>
        /// 保存成功
        /// </summary>
        protected virtual void SaveFormSuccess(bool closeAfterSave)
        {
            ExtAspNet.Alert.Show("操作成功！", String.Empty, closeAfterSave ? ExtAspNet.ActiveWindow.GetHidePostBackReference() : "Ext.get('X_CHANGED').dom.value='false';");
        }

        /// <summary>
        /// 保存失败
        /// </summary>
        /// <param name="ex"></param>
        protected virtual void SaveFormUnsuccess(Exception ex)
        {
            // 如果是参数异常，参数名可能就是字段名，可以定位到具体控件
            ArgumentException ae = ex as ArgumentException;
            if (ae != null && !String.IsNullOrEmpty(ae.ParamName))
            {
                Control control = Page.FindControl(FormItemPrefix + ae.ParamName);
                if (control != null) control.Focus();
            }

            ExtAspNet.Alert.Show("失败！" + ex.Message);
        }
        #endregion

        #region 辅助
        static Boolean GetControlValue(ControlBase control, out Object value)
        {
            TypeX tx = control.GetType();
            String name = tx.GetCustomAttributeValue<ControlValuePropertyAttribute, String>();
            PropertyInfoX pix = null;
            if (!String.IsNullOrEmpty(name)) pix = PropertyInfoX.Create(tx.BaseType, name);
            if (pix == null) pix = PropertyInfoX.Create(tx.BaseType, "Value");
            if (pix == null) pix = PropertyInfoX.Create(tx.BaseType, "Text");
            if (pix != null)
            {
                value = pix.GetValue(control);
                return true;
            }

            value = null;
            return false;
        }

        static Boolean SetControlValue(ControlBase control, Object value)
        {
            TypeX tx = control.GetType();
            String name = tx.GetCustomAttributeValue<ControlValuePropertyAttribute, String>();
            PropertyInfoX pix = null;
            if (!String.IsNullOrEmpty(name)) pix = PropertyInfoX.Create(tx.BaseType, name);
            if (pix == null) pix = PropertyInfoX.Create(tx.BaseType, "Value");
            if (pix == null) pix = PropertyInfoX.Create(tx.BaseType, "Text");
            if (pix != null)
            {
                pix.SetValue(control, value);
                return true;
            }

            return false;
        }
        #endregion

    }
}
