
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    CheckBoxList.cs
 * CreatedOn:   2012-01-22
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ExtAspNet
{
    /// <summary>
    /// 复选框列表控件
    /// </summary>
    [Designer(typeof(RadioButtonListDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:CheckBoxList runat=server></{0}:CheckBoxList>")]
    [ToolboxBitmap(typeof(CheckBoxList), "res.toolbox.CheckBoxList.bmp")]
    [Description("复选框列表控件")]
    [ParseChildren(true, DefaultProperty = "Items")]
    [PersistChildren(false)]
    [DefaultEvent("SelectedIndexChanged")]
    public class CheckBoxList : Field, IPostBackDataHandler
    {
        #region Constructor

        public CheckBoxList()
        {
            AddServerAjaxProperties("X_Items");
            AddClientAjaxProperties("SelectedValueArray");
        }

        #endregion

        #region Properties

        #region old code

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否显示浅色的背景色")]
        //public virtual bool EnableLightBackgroundColor
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableLightBackgroundColor"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableLightBackgroundColor"] = value;
        //    }
        //}

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否显示背景色")]
        //public virtual bool EnableBackgroundColor
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableBackgroundColor"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableBackgroundColor"] = value;
        //    }
        //}


        #endregion

        /// <summary>
        /// 是否必填项
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(false)]
        [Description("是否必填项")]
        public bool Required
        {
            get
            {
                object obj = XState["Required"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Required"] = value;
            }
        }

        /// <summary>
        /// 为空时提示信息
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue("")]
        [Description("为空时提示信息")]
        public string RequiredMessage
        {
            get
            {
                object obj = XState["RequiredMessage"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["RequiredMessage"] = value;
            }
        }


        /// <summary>
        /// 是否自动回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动回发")]
        public bool AutoPostBack
        {
            get
            {
                object obj = XState["AutoPostBack"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["AutoPostBack"] = value;
            }
        }

        ///// <summary>
        ///// 是否选中
        ///// </summary>
        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否选中")]
        //public bool Checked
        //{
        //    get
        //    {
        //        object obj = XState["Checked"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        XState["Checked"] = value;
        //    }
        //}

        /// <summary>
        /// 渲染成几列
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(0)]
        [Description("渲染成几列")]
        public int ColumnNumber
        {
            get
            {
                object obj = XState["ColumnNumber"];
                return obj == null ? 0 : (int)obj;
            }
            set
            {
                XState["ColumnNumber"] = value;
            }
        }

        /// <summary>
        /// 是否按照纵向顺序渲染
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否按照纵向顺序渲染")]
        public bool ColumnVertical
        {
            get
            {
                object obj = XState["ColumnVertical"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["ColumnVertical"] = value;
            }
        }

        #endregion

        #region Data Properties

        /// <summary>
        /// 显示文本的数据字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示文本的数据字段")]
        public string DataTextField
        {
            get
            {
                object obj = XState["DataTextField"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["DataTextField"] = value;
            }
        }

        /// <summary>
        /// 显示文本的格式化字符串
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示文本的格式化字符串")]
        public string DataTextFormatString
        {
            get
            {
                object obj = XState["DataTextFormatString"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["DataTextFormatString"] = value;
            }
        }

        /// <summary>
        /// 显示值的数据字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示值的数据字段")]
        public string DataValueField
        {
            get
            {
                object obj = XState["DataValueField"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["DataValueField"] = value;
            }
        }

        private object _dataSource;

        /// <summary>
        /// 数据源
        /// </summary>
        [DefaultValue(null)]
        [Description("数据源")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSource
        {
            set
            {
                _dataSource = value;
            }
            get
            {
                return _dataSource;
            }
        }

        #endregion

        #region SelectedIndexArray/SelectedValueArray/SelectedItemArray

        /// <summary>
        /// [AJAX属性]选中项的值
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("[AJAX属性]选中项的值")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string[] SelectedValueArray
        {
            get
            {
                List<string> selectedValues = new List<string>();
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    CheckItem item = Items[i];
                    if (item.Selected)
                    {
                        selectedValues.Add(item.Value);
                    }
                }
                return selectedValues.ToArray();
            }
            set
            {
                List<string> selectedValues = new List<string>(value);
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    CheckItem item = Items[i];
                    if (selectedValues.Contains(item.Value))
                    {
                        item.Selected = true;
                    }
                    else
                    {
                        item.Selected = false;
                    }
                }
            }
        }


        /// <summary>
        /// [AJAX属性]选中项的索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("[AJAX属性]选中项的索引")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int[] SelectedIndexArray
        {
            get
            {
                List<int> selectedIndexs = new List<int>();
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    if (Items[i].Selected)
                    {
                        selectedIndexs.Add(i);
                    }
                }
                return selectedIndexs.ToArray();
            }
            set
            {
                List<int> selectedIndexs = new List<int>(value);
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    if (selectedIndexs.Contains(i))
                    {
                        Items[i].Selected = true;
                    }
                    else
                    {
                        Items[i].Selected = false;
                    }
                }
            }
        }

        /// <summary>
        /// 选中项
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("选中项")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CheckItem[] SelectedItemArray
        {
            get
            {
                List<CheckItem> selectedItems = new List<CheckItem>();
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    CheckItem item = Items[i];
                    if (item.Selected)
                    {
                        selectedItems.Add(item);
                    }
                }
                return selectedItems.ToArray();
            }
        }

        #endregion

        #region Items

        private CheckItemCollection _items;

        /// <summary>
        /// 复选框集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public virtual CheckItemCollection Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new CheckItemCollection();
                }
                return _items;
            }
        }

        #endregion

        #region X Properties

        /// <summary>
        /// 保存的复选框数据（内部使用）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JArray X_Items
        {
            get
            {
                JArray ja = new JArray();
                foreach (CheckItem item in Items)
                {
                    JArray ja2 = new JArray();
                    ja2.Add(item.Text);
                    ja2.Add(item.Value);
                    ja.Add(ja2);
                }
                return ja;
            }
            set
            {
                // 和DropDownList的情况相同，清空前备份选中项
                string[] selectedValues = SelectedValueArray;

                Items.Clear();
                foreach (JArray ja2 in value)
                {
                    CheckItem item = new CheckItem();
                    item.Text = ja2[0].Value<string>(); //ja2.getString(0);
                    item.Value = ja2[1].Value<string>();  //ja2.getString(1);
                    Items.Add(item);
                }

                // 恢复选中项
                SelectedValueArray = selectedValues;
            }
        }

        #endregion

        #region old code

        //private int itemsHashCode;
        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);

        //    itemsHashCode = XItemsToState().ToString().GetHashCode();
        //}

        //protected override void OnBothPreRender()
        //{
        //    base.OnBothPreRender();

        //    // Items has been changed in server-side code after onInit.
        //    if (itemsHashCode != XItemsToState().ToString().GetHashCode())
        //    {
        //        XState.AddModifiedProperty("X_Items");
        //    }
        //}

        //protected override void LoadXState(JObject state, string property)
        //{
        //    base.LoadXState(state, property);

        //    if (property == "X_Items")
        //    {
        //        XItemsFromState(state.getJArray(property));
        //    }
        //}

        //protected override void SaveXState(JObject state, string property)
        //{
        //    if (property == "X_Items")
        //    {
        //        state.put(property, XItemsToState());
        //    }
        //}

        //private JArray XItemsToState()
        //{
        //    JArray ja = new JArray();
        //    foreach (CheckItem item in Items)
        //    {
        //        JArray ja2 = new JArray();
        //        ja2.Add(item.Text);
        //        ja2.Add(item.Value);
        //        ja.Add(ja2);
        //    }
        //    return ja;
        //}

        //private void XItemsFromState(JArray ja)
        //{
        //    foreach (JArray ja2 in ja.getArrayList())
        //    {
        //        CheckItem item = new CheckItem();
        //        item.Text = ja2.getString(0);
        //        item.Value = ja2.getString(1);
        //        Items.Add(item);
        //    }
        //}

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            bool dataReloaded = false;

            StringBuilder sb = new StringBuilder();

            if (PropertyModified("X_Items"))
            {
                sb.AppendFormat("{0}.x_reloadData('{1}');", XID, UniqueID); //, GetItemsJArray().ToString(Formatting.None));

                dataReloaded = true;
            }


            if (!dataReloaded)
            {
                if (PropertyModified("SelectedValueArray"))
                {
                    sb.AppendFormat("{0}.x_setValue();", XID);

                }
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            #region options

            if (Required)
            {
                OB.AddProperty("allowBlank", false);
                if (!String.IsNullOrEmpty(RequiredMessage))
                {
                    OB.AddProperty("blankText", RequiredMessage);
                }
            }


            OB.RemoveProperty("name");

            if (ColumnNumber <= 0)
            {
                OB.AddProperty("columns", "auto");
            }
            else
            {
                OB.AddProperty("columns", ColumnNumber);
            }

            if (ColumnVertical)
            {
                OB.AddProperty("vertical", true);
            }

            //OB.AddProperty("name", UniqueID);

            #endregion

            #region Items

            string xstateName = String.Format("{0}_xstate", XID);
            string xitemsName = String.Format("{0}_xitems", XID);
            string hasDataName = xstateName;

            string xstate = OB.GetProperty("x_state");
            OB.AddProperty("x_state", xstateName, true);

            string jsState = String.Format("var {0}={1};", xstateName, xstate);

            if (!XState.ModifiedProperties.Contains("X_Items"))
            {
                xstate = ConvertPropertiesToJObject(new List<string> { "X_Items", "SelectedValueArray" }).ToString(Formatting.None);
                jsState += String.Format("var {0}={1};", xitemsName, xstate);
                hasDataName = xitemsName;
            }

            //if (Items.Count > 0)
            //{
            //    //OB.AddProperty("items", GetItemsJArray().ToString(Formatting.None), true);
            //    OB.AddProperty("items", String.Format("X.util.resolveCheckBoxGroup('{0}',{1})", UniqueID, hasDataName), true);
            //}
            OB.AddProperty("items", String.Format("X.util.resolveCheckBoxGroup('{0}',{1})", UniqueID, hasDataName), true);


            if (Items.Count == 0)
            {
                OB.Listeners.AddProperty("afterrender", JsHelper.GetFunction("cmp.x_toBeDeleted();", "cmp"), true);
            }

            #endregion

            #region AutoPostBack

            if (AutoPostBack)
            {
                // 道理和RadioButtonList类似。
                OB.Listeners.AddProperty("change", String.Format("function(group,checkedArray){{if(typeof(checkedArray)!=='boolean'){{{0}}}}}", GetPostBackEventReference()), true);
            }
            /*
            if (!String.IsNullOrEmpty(SelectedValue))
            {
                OB.AddProperty("value", SelectedValue);
            }
            */

            #region old code
            //string autoPostBackScript = String.Empty;
            //if (AutoPostBack)
            //{
            //    //// change 事件只有在失去焦点时才触发，是不及时的
            //    //OB.Listeners.RemoveProperty(OptionName.Change);
            //    //OB.Listeners.AddProperty(OptionName.Check, String.Format("function(newValue,oldValue){{\r\nbox_pageStateChange();alert(newValue+':'+oldValue);\r\n}}"), true);

            //    string selectScript = String.Format("function(newValue,oldValue){{\r\nalert(newValue+':'+oldValue);\r\n}}");
            //    selectScript = String.Format("{0}.on('{1}',{2},box,{{delay:0}});", ClientID, OptionName.Check, selectScript);

            //    autoPostBackScript += selectScript;
            //} 

            //string backgroundColorStyle = String.Empty;
            //if (EnableBackgroundColor)
            //{
            //    backgroundColorStyle = AboutConfig.GetDefaultBackgroundColor(PageManagerInstance.Theme.ToString());
            //}
            //else if (EnableLightBackgroundColor)
            //{
            //    backgroundColorStyle = AboutConfig.GetLightBackgroundColor(PageManagerInstance.Theme.ToString());
            //}

            //if (!String.IsNullOrEmpty(backgroundColorStyle))
            //{
            //    string backgroundColorScript = String.Format("Ext.each(X.{0}.el.query('.x-panel-body'),function(item,index){{Ext.get(item).setStyle('background-color','{1}');}});", ClientJavascriptID, backgroundColorStyle);

            //    string renderScript = "(function(){" + backgroundColorScript + "}).defer(20);";
            //    OB.Listeners.AddProperty("render", "function(component){" + renderScript + "}", true);
            //}

            #endregion

            #endregion


            string jsContent = String.Format("var {0}=new Ext.form.CheckboxGroup({1});", XID, OB.ToString());
            AddStartupScript(jsState + jsContent);
        }

        #region old code

        //private JArray GetItemsJArray()
        //{
        //    JArray ja = new JArray();
        //    int itemIndex = 0;
        //    foreach (CheckItem item in Items)
        //    {
        //        JObject jo = new JObject();
        //        jo.Add("inputValue", item.Value);
        //        jo.Add("boxLabel", item.Text);
        //        jo.Add("name", UniqueID + "_" + itemIndex.ToString());
        //        if (item.Selected)
        //        {
        //            jo.Add("checked", true);
        //        }

        //        ja.Add(jo);

        //        itemIndex++;
        //    }

        //    return ja;
        //} 

        #endregion

        #endregion

        #region DataBind

        /// <summary>
        /// 绑定到数据源
        /// </summary>
        public override void DataBind()
        {
            base.DataBind();

            if (_dataSource != null)
            {
                // 1. 首先清空 Items 属性
                Items.Clear();

                // 2. 绑定到数据源
                if (_dataSource is DataView || _dataSource is DataSet || _dataSource is DataTable)
                {
                    DataTable dataTable = null;
                    if (_dataSource is DataView)
                    {
                        dataTable = ((DataView)_dataSource).ToTable();
                    }
                    else if (_dataSource is DataSet)
                    {
                        dataTable = ((DataSet)_dataSource).Tables[0];
                    }
                    else
                    {
                        dataTable = ((DataTable)_dataSource);
                    }
                    DataBindToDataTable(dataTable);
                }
                else if (_dataSource is IEnumerable)
                {
                    DataBindToEnumerable((IEnumerable)_dataSource);
                }
                else
                {
                    throw new Exception("DataSource doesn't support data type: " + _dataSource.GetType().ToString());
                }

                // X_Items属性不是ServerAjaxProperty，所以只在页面第一次加载时判断是否改变
                if (!Page.IsPostBack)
                {
                    XState.AddModifiedProperty("X_Items");
                }
            }
        }

        /// <summary>
        /// 绑定到数据表
        /// </summary>
        /// <param name="dataTable"></param>
        private void DataBindToDataTable(DataTable dataTable)
        {
            int startIndex = 0;
            int endIndex = Int32.MaxValue;
            for (int i = startIndex; i < Math.Min(endIndex, dataTable.Rows.Count); i++)
            {
                DataRow row = dataTable.Rows[i];
                Items.Add(CreateCheckItem(row));
            }
        }

        /// <summary>
        /// 绑定到可枚举列表
        /// </summary>
        /// <param name="enumerable"></param>
        private void DataBindToEnumerable(IEnumerable enumerable)
        {
            #region old code
            //int startIndex = 0;
            //int endIndex = Int32.MaxValue;

            //IEnumerator enumerator = enumerable.GetEnumerator();

            //// 定位开始位置
            //enumerator.Reset();
            //enumerator.MoveNext();

            //int count = 0;

            //// skip some items?
            //while (count < startIndex)
            //{
            //    enumerator.MoveNext();
            //    count++;
            //}

            //try
            //{
            //    if (enumerator.Current == null)
            //    {
            //        return;
            //    }
            //}
            //catch
            //{
            //    return;
            //}

            //while (enumerator.Current != null && count < endIndex)
            //{
            //    object currentObject = enumerator.Current;

            //    CheckItem item = new CheckItem();

            //    if (currentObject is string)
            //    {
            //        item.Text = currentObject.ToString();
            //        item.Value = currentObject.ToString();
            //    }
            //    else
            //    {
            //        // Load item
            //        if (DataTextField != "")
            //        {
            //            item.Text = GetPropertyValue(currentObject, DataTextField);
            //        }
            //        else
            //        {
            //            item.Text = currentObject.ToString();
            //        }

            //        if (DataValueField != "")
            //        {
            //            item.Value = GetPropertyValue(currentObject, DataValueField);
            //        }
            //        else
            //        {
            //            item.Value = currentObject.ToString();
            //        }

            //    }

            //    Items.Add(item);

            //    if (!enumerator.MoveNext())
            //    {
            //        break;
            //    }

            //    count++;
            //} 
            #endregion

            IEnumerator enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object currentObject = enumerator.Current;
                Items.Add(CreateCheckItem(currentObject));
            }
        }

        private CheckItem CreateCheckItem(Object obj)
        {
            CheckItem item = new CheckItem();
            if (obj is string)
            {
                item.Text = obj.ToString();
                item.Value = obj.ToString();
            }
            else
            {
                if (!String.IsNullOrEmpty(DataTextField))
                {
                    if (!String.IsNullOrEmpty(DataTextFormatString))
                    {
                        item.Text = String.Format(DataTextFormatString, GetPropertyValue(obj, DataTextField));
                    }
                    else
                    {
                        item.Text = GetPropertyValue(obj, DataTextField);
                    }
                }
                else
                {
                    item.Text = obj.ToString();
                }

                if (!String.IsNullOrEmpty(DataValueField))
                {
                    item.Value = GetPropertyValue(obj, DataValueField);
                }
                else
                {
                    item.Value = obj.ToString();
                }
            }
            return item;
        }



        /// <summary>
        /// 取得属性值
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="propertyName"></param>
        private string GetPropertyValue(object obj, string propertyName)
        {
            object result = null;

            result = ObjectUtil.GetPropertyValue(obj, propertyName);

            return result == null ? String.Empty : result.ToString();
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public virtual bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            //string postValue = postCollection[postDataKey];

            List<string> selectedValues = new List<string>();
            for (int i = 0, count = Items.Count; i < count; i++)
            {
                if (!String.IsNullOrEmpty(postCollection[postDataKey + "_" + i.ToString()]))
                {
                    CheckItem item = Items[i];
                    selectedValues.Add(item.Value);
                }
            }
            string[] selectedValueArray = selectedValues.ToArray();
            if (!StringUtil.CompareStringArray(selectedValueArray, SelectedValueArray))
            {
                SelectedValueArray = selectedValueArray;
                XState.BackupPostDataProperty("SelectedValueArray");
                return true;
            }
            /*
            if (postValue != null && SelectedValue != postValue)
            {
                CheckItem item = Items.FindByValue(postValue);
                if (item != null)
                {
                    SelectedValue = postValue;
                    XState.BackupPostDataProperty("SelectedValue");
                    return true;
                }
            }
            */
            return false;
        }

        private object _handlerKey = new object();

        /// <summary>
        /// 选中项改变事件（需要启用AutoPostBack）
        /// </summary>
        public event EventHandler SelectedIndexChanged
        {
            add
            {
                Events.AddHandler(_handlerKey, value);
            }
            remove
            {
                Events.RemoveHandler(_handlerKey, value);
            }
        }

        protected virtual void OnSelectedIndexChanged(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            OnSelectedIndexChanged(EventArgs.Empty);
        }

        #endregion

        #region old code

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[2];

        //    states[0] = base.SaveViewState();
        //    states[1] = ((IStateManager)Items).SaveViewState();


        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Items).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Items).TrackViewState();
        //}

        //protected override void SetDirty()
        //{
        //    base.SetDirty();

        //    ((ISetDirty)Items).SetDirty();
        //}

        //public override string GetValueReference()
        //{
        //    //string template = "(function(){var value=null;" +
        //    //    "Ext.each(X.#ID#.items.items, function(item,index){if(item.checked){value=item.inputValue;}});" +
        //    //    "return value;})()";

        //    //return template.Replace("#ID#", ClientJavascriptID);

        //    return String.Format("{0}.getValue()", ClientJavascriptID);
        //}

        #endregion
    }
}
