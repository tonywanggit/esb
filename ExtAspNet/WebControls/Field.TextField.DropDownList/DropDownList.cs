
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    DropDownList.cs
 * CreatedOn:   2008-04-24
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
using System.Collections;
using System.Data;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExtAspNet
{
    /// <summary>
    /// 下拉列表控件
    /// </summary>
    [Designer(typeof(DropDownListDesigner))]
    [ToolboxData("<{0}:DropDownList Label=\"Label\" runat=\"server\"></{0}:DropDownList>")]
    [ToolboxBitmap(typeof(DropDownList), "res.toolbox.DropDownList.bmp")]
    [Description("下拉列表控件")]
    [ParseChildren(true, DefaultProperty = "Items")]
    [PersistChildren(false)]
    [DefaultEvent("SelectedIndexChanged")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class DropDownList : TextField, IPostBackDataHandler
    {
        #region Constructor

        public DropDownList()
        {
            AddServerAjaxProperties("X_Items");
            AddClientAjaxProperties("SelectedValue", "Text");
        }

        #endregion

        #region SelectedIndex/SelectedValue/SelectedItem

        /// <summary>
        /// [AJAX属性]用户输入的文本（只有在允许编辑和不强制选择的情况下才有效）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]用户输入的文本（只有在允许编辑和不强制选择的情况下才有效）")]
        public string Text
        {
            get
            {
                object obj = XState["Text"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Text"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]选中项的值
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedValue
        {
            get
            {
                string value = null;
                if (SelectedItem == null)
                {
                    // 如果强制选择一项，我们可能需要选中第一项
                    if (ForceSelection)
                    {
                        if (Items.Count > 0)
                        {
                            SelectedIndex = 0;
                            // If SelectedValue is null, then we select the first item of the list.
                            value = Items[0].Value;
                        }
                    }
                }
                else
                {
                    value = SelectedItem.Value;
                }
                return value;
            }
            set
            {
                foreach (ListItem item2 in Items)
                {
                    item2.Selected = false;
                }

                if (value != null)
                {
                    ListItem item = Items.FindByValue(value);
                    if (item != null)
                    {
                        item.Selected = true;
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
        public int SelectedIndex
        {
            get
            {
                int selectedIndex = -1;
                for (int i = 0, count = Items.Count; i < count; i++)
                {
                    if (Items[i].Selected)
                    {
                        selectedIndex = i;
                        break;
                    }
                }
                return selectedIndex;
            }
            set
            {
                if (value >= 0 && value < Items.Count)
                {
                    foreach (ListItem item in Items)
                    {
                        item.Selected = false;
                    }

                    Items[value].Selected = true;
                }
            }
        }

        /// <summary>
        /// 选中项的文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("选中项的文本")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedText
        {
            get
            {
                if (SelectedItem != null)
                {
                    return SelectedItem.Text;
                }
                return null;
            }
        }

        /// <summary>
        /// 选中项
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [Description("选中项")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ListItem SelectedItem
        {
            get
            {
                int selectedIndex = SelectedIndex;
                if (selectedIndex >= 0 && selectedIndex < Items.Count)
                {
                    return Items[selectedIndex];
                }
                return null;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否强制选中项为下拉列表中的项（启用编辑的情况下）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否强制选中项为下拉列表中的项（启用编辑的情况下）")]
        public bool ForceSelection
        {
            get
            {
                object obj = XState["ForceSelection"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ForceSelection"] = value;
            }
        }


        /// <summary>
        /// 是否启用可编辑，以便在录入时自动过滤下拉框中的值
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用可编辑，以便在录入时自动过滤下拉框中的值")]
        public bool EnableEdit
        {
            get
            {
                object obj = XState["EnableEdit"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableEdit"] = value;
            }
        }


        /// <summary>
        /// 是否启用模拟树显示
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用模拟树显示")]
        public bool EnableSimulateTree
        {
            get
            {
                object obj = XState["EnableSimulateTree"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableSimulateTree"] = value;
            }
        }

        /// <summary>
        /// 模拟树显示时指示所在层次的数据字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("模拟树显示时指示所在层次的数据字段")]
        public string DataSimulateTreeLevelField
        {
            get
            {
                object obj = XState["DataSimulateTreeLevelField"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["DataSimulateTreeLevelField"] = value;
                //// 如果设置了DataSimulateTreeLevelField，则设置EnableSimulateTree=true
                //if (!String.IsNullOrEmpty(value))
                //{
                //    EnableSimulateTree = true;
                //}
            }
        }

        /// <summary>
        /// 是否可选择的字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("是否可选择的字段")]
        public string DataEnableSelectField
        {
            get
            {
                object obj = XState["DataEnableSelectField"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["DataEnableSelectField"] = value;
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


        /// <summary>
        /// 是否可以改变下拉列表的宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以改变下拉列表的宽度")]
        public bool Resizable
        {
            get
            {
                object obj = XState["Resizable"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Resizable"] = value;
            }
        }

        #region old code

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("文本框为空时显示的文本")]
        //public string EmptyText
        //{
        //    get
        //    {
        //        object obj = BoxState["EmptyText"];
        //        return obj == null ? "" : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["EmptyText"] = value;
        //    }
        //}

        //private bool Traditional_Default = true;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        //[Description("是否渲染为传统的下拉列表")]
        //public bool Traditional
        //{
        //    get
        //    {
        //        object obj = BoxState["Editable"];
        //        return obj == null ? Traditional_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["Editable"] = value;
        //    }
        //}

        //private bool TypeAhead_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否提前输入")]
        //public bool TypeAhead
        //{
        //    get
        //    {
        //        object obj = BoxState["TypeAhead"];
        //        return obj == null ? TypeAhead_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["TypeAhead"] = value;
        //    }
        //} 


        //private bool EnableFirstItem_Default = false;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("是否启用“全部”项")]
        //public bool EnableFirstItem
        //{
        //    get
        //    {
        //        object obj = BoxState["EnableFirstItem"];
        //        return obj == null ? EnableFirstItem_Default : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["EnableFirstItem"] = value;
        //    }
        //}

        //private string FirstItemText_Default = "全部";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("全部")]
        //[Description("“全部”的名称")]
        //public string FirstItemText
        //{
        //    get
        //    {
        //        object obj = BoxState["FirstItemText"];
        //        return obj == null ? FirstItemText_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["FirstItemText"] = value;
        //    }
        //}

        //private string FirstItemValue_Default = "-1";

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("-1")]
        //[Description("“全部”的值")]
        //public string FirstItemValue
        //{
        //    get
        //    {
        //        object obj = BoxState["FirstItemValue"];
        //        return obj == null ? FirstItemValue_Default : (string)obj;
        //    }
        //    set
        //    {
        //        BoxState["FirstItemValue"] = value;
        //    }
        //}

        #endregion

        #endregion

        #region Data Properties

        /// <summary>
        /// 显示文本字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示文本字段")]
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
        /// 显示值字段
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("显示值字段")]
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

        #region X Properties

        /// <summary>
        /// 保存的列表项数据（内部使用）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JArray X_Items
        {
            get
            {
                JArray ja = new JArray();
                foreach (ListItem item in Items)
                {
                    JArray ja2 = new JArray();
                    ja2.Add(item.Value);
                    ja2.Add(item.Text);
                    ja2.Add(item.EnableSelect ? 1 : 0);
                    if (EnableSimulateTree)
                    {
                        ja2.Add(item.SimulateTreeLevel);
                    }
                    ja.Add(ja2);
                }
                return ja;
            }
            set
            {
                // 由于SelectedValue是单独保存的，所以在清空之前的数据之前要先备份
                string selectedValue = SelectedValue;
                Items.Clear();

                foreach (JArray ja2 in value)
                {
                    ListItem item = new ListItem();
                    item.Value = ja2[0].Value<string>(); // ja2.getString(0);
                    item.Text = ja2[1].Value<string>();  //ja2.getString(1);
                    item.EnableSelect = ja2[2].Value<int>() == 1 ? true : false;
                    if (EnableSimulateTree)
                    {
                        item.SimulateTreeLevel = ja2[3].Value<int>();
                    }
                    Items.Add(item);
                }

                // 恢复选中项
                SelectedValue = selectedValue;
            }
        }

        #endregion

        #region Items

        private ListItemCollection items;

        /// <summary>
        /// 列表项集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public virtual ListItemCollection Items
        {
            get
            {
                if (items == null)
                {
                    items = new ListItemCollection();
                }
                return items;
            }
        }
        #endregion

        #region LoadXState/SaveXState
        //private string lastSelectedValue = null;
        //protected override void LoadXState(JObject state, string property)
        //{
        //    base.LoadXState(state, property);

        //    if (property == "X_Items")
        //    {
        //        XItemsFromJSON(state.getJArray(property));
        //        // After recover Items property, we should recover SelectedValue according to Items.
        //        SelectedValue = lastSelectedValue;
        //    }
        //    else if (property == "X_SelectedValue")
        //    {
        //        lastSelectedValue = state.getString(property);
        //        SaveXProperty("X_SelectedValue", lastSelectedValue);
        //        SelectedValue = lastSelectedValue;
        //    }
        //}

        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);

        //    SaveXProperty("X_Items", XItemsToJSON().ToString());
        //    SaveXProperty("X_SelectedValue", SelectedValue);
        //}

        //protected override void OnBothPreRender()
        //{
        //    base.OnBothPreRender();

        //    // Items has been changed in server-side code after onInit.
        //    if (XPropertyModified("X_Items", XItemsToJSON().ToString()))
        //    {
        //        XState.AddModifiedProperty("X_Items");
        //        // If Items have been changed, then we must reset the SelectedValue.
        //        XState.AddModifiedProperty("X_SelectedValue");
        //    }

        //    if (XPropertyModified("X_SelectedValue", SelectedValue))
        //    {
        //        XState.AddModifiedProperty("X_SelectedValue");
        //    }

        //}

        //protected override void SaveXState(JObject state, string property)
        //{
        //    if (property == "X_Items")
        //    {
        //        state.put(property, XItemsToJSON());
        //    }
        //    else if (property == "X_SelectedValue")
        //    {
        //        state.put(property, SelectedValue);
        //    }
        //}

        //private JArray XItemsToJSON()
        //{
        //    JArray ja = new JArray();
        //    foreach (ListItem item in Items)
        //    {
        //        JArray ja2 = new JArray();
        //        ja2.Add(item.Value);
        //        ja2.Add(item.Text);
        //        ja2.Add(item.EnableSelect ? 1 : 0);
        //        if (EnableSimulateTree)
        //        {
        //            ja2.Add(item.SimulateTreeLevel);
        //        }
        //        ja.Add(ja2);
        //    }
        //    return ja;
        //}

        //private void XItemsFromJSON(JArray ja)
        //{
        //    foreach (JArray ja2 in ja.getArrayList())
        //    {
        //        ListItem item = new ListItem();
        //        item.Value = ja2.getString(0);
        //        item.Text = ja2.getString(1);
        //        item.EnableSelect = ja2.getInt(2) == 1 ? true : false;
        //        if (EnableSimulateTree)
        //        {
        //            item.SimulateTreeLevel = ja2.getInt(3);
        //        }
        //        Items.Add(item);
        //    }
        //}

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("X_Items"))
            {
                sb.AppendFormat("{0}.x_loadData();", XID);

                // TODO: 修改Items记录后要更新SelectedValue
            }

            if (PropertyModified("SelectedValue"))
            {
                //if (ClientPropertyModifiedInServer("SelectedValue"))

                sb.AppendFormat("{0}.x_setValue();", XID);

            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            // 确保 X_Items 和 SelectedValue 在页面第一次加载时都存在于x_state中
            XState.AddModifiedProperty("X_Items");
            XState.AddModifiedProperty("SelectedValue");

            base.OnFirstPreRender();

            #region examples

            //var nextStepList = [
            //    ['审核', '1'],
            //    ['不审核', '2']
            //];
            //var nextStepStore = new Ext.data.SimpleStore({
            //    fields: ['text', 'value'],
            //    data: nextStepList
            //});
            //{
            //    xtype:'combo',
            //    store: nextStepStore,
            //    displayField:'text',
            //    valueField:'value',
            //    typeAhead: true,
            //    mode: 'local',
            //    triggerAction: 'all',
            //    value:'1',
            //    emptyText:'请选择下一步',
            //    selectOnFocus:true,
            //    allowBlank:false,
            //    fieldLabel: '下一步',
            //    labelSeparator:'&nbsp;<span style="color:red;vertical-align:text-bottom;">*</span>',
            //    name: 'nextStep',
            //    anchor:'95%'
            //}

            #endregion

            #region Properties

            if (!EnableEdit)
            {
                OB.AddProperty("editable", false);
            }

            if (!ForceSelection)
            {
                OB.AddProperty("forceSelection", false);
            }

            if (Resizable)
            {
                OB.AddProperty("resizable", true);
            }

            OB.AddProperty("hiddenName", UniqueID);
            //OB.RemoveProperty("name");
            OB.AddProperty("store", "new Ext.data.ArrayStore({fields:['value','text','enabled','prefix']})", true);


            #region old code
            //OB.AddProperty("mode", "local");
            //// 点击下拉按钮时显示全部内容
            //OB.AddProperty("triggerAction", "all");
            //// 必须选中一个值，不能自己输入内容
            //OB.AddProperty("forceSelection", true);
            //// 此下拉列表控件不可以编辑
            //OB.AddProperty("editable", false);

            //OB.AddProperty(OptionName.Title, "Title");
            //if (TypeAhead) OB.AddProperty(OptionName.TypeAhead, true);
            //OB.AddProperty(OptionName.SelectOnFocus, true);

            //// SelectedValue可以为空
            //if (!String.IsNullOrEmpty(SelectedValue))
            //{
            //    OB.AddProperty("value", SelectedValue);
            //} 
            #endregion

            #endregion

            #region old code

            //string hiddenFieldsScript = String.Empty;
            //if (AutoPostBack)
            //{
            //    hiddenFieldsScript += GetSetHiddenFieldValueScript(LastSelectedValueHiddenID, SelectedValue);
            //}

            //string disableSelectRowIndexsString = GetDisableSelectRowIndexsString();
            //string disableSelectRowIndexsScript = GetSetHiddenFieldValueScript(DisableRowIndexsHiddenID, disableSelectRowIndexsString);

            //// TODO:
            //// 这个要放在加载数据的前面，因为加载数据时需要渲染UI，渲染UI时需要用到这个隐藏字段的值
            //if (AjaxPropertyChanged("DisableSelectRowIndexsString", disableSelectRowIndexsString))
            //{
            //    AddAjaxPropertyChangedScript(disableSelectRowIndexsScript);
            //}


            // 不管是不是disableSelectFields.Count > 0，都要执行下面的语句，因为可能页面加载时为0，在Ajax后不为零
            //if (disableSelectFields.Count > 0)
            //OB.AddProperty(OptionName.Tpl, String.Format("'<tpl for=\".\"><div class=\"x-combo-list-item {{[X.util.isHiddenFieldContains(\"{0}\",xindex-1) ? \"box-combo-list-item-disable-select\" : \"\"]}}\">{{text}}</div></tpl>'", DisableSelectRowIndexsHiddenID), true);
            //var tplStr = "'<tpl for=\".\"><div class=\"x-combo-list-item\">{text}</div></tpl>'";
            //var tplStr = "new Ext.XTemplate('<tpl for=\".\"><div class=\"x-combo-list-item\">{text}</div></tpl>')";

            //var tplStr = "<tpl for=\".\"><div class=\"x-combo-list-item <tpl if=\"!enabled\">x-combo-list-item-disable</tpl>\">{prefix}{text}</div></tpl>";
            //OB.AddProperty("tpl", tplStr);
            //OB.AddProperty("tpl", tplStr.Replace("#DisableRowIndexsHiddenID#", DisableRowIndexsHiddenID), true);


            //string setSimulateTreeTextFunctionScript = String.Empty;
            //string setSimulateTreeTextScript = String.Empty;
            //if (EnableSimulateTree)
            //{
            //    string setSimulateTextScript = String.Format("var text=Ext.get('{0}').dom.value;if(text.lastIndexOf('<img')>=0){{Ext.get('{0}').dom.value=X.util.stripHtmlTags(text);}}", ClientID);
            //    setSimulateTreeTextFunctionScript = String.Format("{0}_setSimulateText=function(){{{1}}};", ClientJavascriptID, setSimulateTextScript);

            //    // 加载完毕后，显示选中的值
            //    //AddAbsoluteStartupScript(String.Format("{0}_setSimulateText();", ClientJavascriptID));
            //    // 下拉列表加载完毕后，立即去掉前面图片的HTML标签
            //    string renderScript = JsHelper.GetDeferScript(String.Format("{0}_setSimulateText();", ClientJavascriptID), 20); // "(function(){" + String.Format("{0}_setSimulateText();", ClientJavascriptID) + "}).defer(20);";
            //    OB.Listeners.AddProperty(OptionName.EVENT_RENDER, "function(component){" + renderScript + "}", true);
            //}


            //string simulateTreeAllScript = String.Empty;
            //if (EnableSimulateTree)
            //{
            //    // 在选中一项后，立即去掉前面图片的HTML标签
            //    simulateTreeAllScript += "\r\n";
            //    //string simulateTreeScript = String.Format("function(ddl,record,index){{var text=record.data.text;var startDivIndex=text.lastIndexOf('</div>');text=text.substr(startDivIndex+6);Ext.get('{0}').dom.value=text;}}", ClientID);
            //    string simulateTreeScript = String.Format("function(ddl,record,index){{X.{0}_setSimulateText();}}", ClientJavascriptID);
            //    simulateTreeScript = String.Format("{0}.on('{1}',{2},box,{{delay:0}});", ClientJavascriptID, OptionName.Select, simulateTreeScript);
            //    //AddAbsoluteStartupScript( simulateTreeScript);
            //    simulateTreeAllScript += simulateTreeScript;

            //    simulateTreeAllScript += "\r\n";
            //    string simulateTreeBlurScript = String.Format("function(ddl){{X.{0}_setSimulateText();}}", ClientJavascriptID);
            //    simulateTreeBlurScript = String.Format("{0}.on('{1}',{2},box,{{delay:10}});", ClientJavascriptID, OptionName.Blur, simulateTreeBlurScript);
            //    //AddAbsoluteStartupScript( simulateTreeBlurScript);
            //    simulateTreeAllScript += simulateTreeBlurScript;
            //}




            // These are default values, which are assignment in extender.js.
            //OB.AddProperty("displayField", "text");
            //OB.AddProperty("valueField", "value");
            //OB.AddProperty("store", "new Ext.data.ArrayStore({fields:['value','text','enabled','prefix']})", true);

            //string dataScript = String.Empty;
            //string fields = "['value','text','enabled','prefix']";
            //string storeScript = "new Ext.data.ArrayStore({fields:['value','text','enabled','prefix']})";//", fields, GetDataArrayString()); // GetDataArrayString()

            //OB.AddProperty(OptionName.Store, String.Format("new Ext.data.ArrayStore({{fields:['value','text'],data:{0}}})", dataArrayString), true);
            //OB.AddProperty("store", String.Format("{0}_data", XID), true);
            //string dataScript = String.Format("{0}_data=new Ext.data.ArrayStore({{fields:['value','text'],data:{1}}});", ClientJavascriptID, dataArrayString);
            //sb.AppendFormat("this.{0}_store=new Ext.data.SimpleStore({{fields:['text', 'value'],data:this.{0}_data}});", ClientJavascriptID);
            #endregion

            #region AutoPostBack

            StringBuilder beforeselectSB = new StringBuilder();
            // 是否能选中一项（如果此项不能选中，则点击没用）
            //beforeselectSB.AppendFormat("if(X.util.isHiddenFieldContains('{0}',index)){{return false;}}", DisableRowIndexsHiddenID);
            beforeselectSB.Append("if(!record.data.enabled){return false;}");

            if (AutoPostBack)
            {
                beforeselectSB.Append("cmp.x_tmp_lastvalue=cmp.getValue();");

                string selectScript = "if(cmp.x_tmp_lastvalue!==cmp.getValue()){" + GetPostBackEventReference() + "}";
                OB.Listeners.AddProperty("select", JsHelper.GetFunction(selectScript, "cmp"), true);
            }

            OB.Listeners.AddProperty("beforeselect", JsHelper.GetFunction(beforeselectSB.ToString(), "cmp", "record", "index"), true);

            #region old code
            //if (AutoPostBack)
            //{
            //    // Note: we can't use change event, because it get triggered when the combox lost focus, which is not in time.
            //    // Beforeselect - If current select item is not changed, don't PostBack.
            //    string beforeselectScript = String.Format("function(ddl,record,index){{Ext.get('{0}').dom.value=Ext.get('{1}').dom.value;}}", LastSelectedValueHiddenID, SelectedValueHiddenID);
            //    beforeselectScript = String.Format("{0}.on('{1}',{2},X,{{delay:0}});", XID, "beforeselect", beforeselectScript);
            //    //AddAbsoluteStartupScript( beforeselectScript);
            //    autoPostBackScript += beforeselectScript;

            //    // Select
            //    string selectScript = String.Format("function(ddl,record,index){{if(record.data.value!=Ext.get('{0}').dom.value){{{1}}}}}", LastSelectedValueHiddenID, GetPostBackEventReference());
            //    selectScript = String.Format("{0}.on('{1}',{2},X,{{delay:0}});", XID, "select", selectScript);
            //    //AddAbsoluteStartupScript( selectScript);
            //    autoPostBackScript += selectScript;


            //    //OB.Listeners.RemoveProperty(OptionName.Change);
            //    //OB.Listeners.AddProperty(OptionName.Change, String.Format("function(ddl,newValue,oldValue){{box_pageStateChange();alert(newValue+':'+oldValue);}}"), true);
            //} 
            #endregion

            #endregion

            #region Listeners - render

            string renderScript = "cmp.x_loadData();cmp.x_setValue();";

            OB.Listeners.AddProperty("render", JsHelper.GetFunction(renderScript, "cmp"), true);

            #endregion

            #region AddStartupScript

            string contentScript = String.Format("var {0}=new Ext.form.ComboBox({1});", XID, OB.ToString());

            AddStartupScript(contentScript);

            #region old code
            //List<string> totalModifiedProperties = XState.GetTotalModifiedProperties();
            //StringBuilder loadDataSB = new StringBuilder();
            //if (totalModifiedProperties.Contains("X_Items"))
            //{
            //    loadDataSB.AppendFormat("{0}.x_loadData();", XID);
            //}
            //else
            //{
            //    loadDataSB.AppendFormat("{0}.store.loadData({1});", XID, X_Items.ToString());
            //}

            //if (totalModifiedProperties.Contains("SelectedValue"))
            //{
            //    loadDataSB.AppendFormat("{0}.x_setValue();", XID);
            //}
            //else
            //{
            //    loadDataSB.AppendFormat("{0}.x_setValue({1});", XID, JsHelper.Enquote(SelectedValue));
            //} 
            #endregion

            #endregion

        }

        #region old code

        //private string GetDataArrayString()
        //{
        //    if (Items.Count == 0)
        //    {
        //        return "[[]]";
        //    }
        //    else
        //    {
        //        if (EnableSimulateTree)
        //        {
        //            List<SimulateTreeNode> silumateTreeNodes = new List<SimulateTreeNode>();
        //            // Set up a list for calculate(mainly the front images).
        //            for (int rowIndex = 0; rowIndex < Items.Count; rowIndex++)
        //            {
        //                ListItem item = Items[rowIndex];
        //                SimulateTreeNode node = new SimulateTreeNode();
        //                node.Text = item.Text;
        //                node.Value = item.Value;
        //                node.Level = item.SimulateTreeLevel;
        //                node.EnableSelect = item.EnableSelect;
        //                node.HasLittleBrother = false;
        //                node.ParentNode = null;
        //                silumateTreeNodes.Add(node);
        //            }
        //            // Use a helper class to calculate tree.
        //            SimulateTreeHeper treeHelper = new SimulateTreeHeper();
        //            treeHelper.ResolveSimulateTree(silumateTreeNodes, false);


        //            JArray ja = new JArray();
        //            foreach (SimulateTreeNode node in silumateTreeNodes)
        //            {
        //                JArray ja2 = new JArray();
        //                ja2.Add(node.Value);
        //                ja2.Add(node.Text);
        //                ja2.Add(node.EnableSelect ? 1 : 0);
        //                ja2.Add(node.SimulateTreeText);

        //                ja.Add(ja2);
        //            }
        //            return ja.ToString();
        //        }
        //        else
        //        {
        //            JArray ja = new JArray();
        //            foreach (ListItem item in Items)
        //            {
        //                JArray ja2 = new JArray();
        //                ja2.Add(item.Value);
        //                ja2.Add(item.Text);
        //                ja2.Add(item.EnableSelect ? 1 : 0);

        //                ja.Add(ja2);
        //            }
        //            return ja.ToString();
        //        }
        //    }
        //}

        ///// <summary>
        ///// Return values: "0,1,2,10"
        ///// </summary>
        ///// <returns></returns>
        //private string GetDisableSelectRowIndexsString()
        //{
        //    List<int> disableSelectRows = new List<int>();
        //    for (int rowIndex = 0, rowCount = Items.Count; rowIndex < rowCount; rowIndex++)
        //    {
        //        if (!Items[rowIndex].EnableSelect)
        //        {
        //            disableSelectRows.Add(rowIndex);
        //        }
        //    }

        //    #region old code
        //    // 下面的条件判断不能加，因为如果页面第一次加载时没有不能选择的项，则以后回发时都不会有不能选择的项
        //    //if (disableSelectFields.Count > 0)
        //    //{
        //    // 把这个状态保存在隐藏字段中，因为可能在Ajax中改变
        //    //disableSelectScript = String.Format("{0}_disableSelect={1};", ClientJavascriptID, JsHelper.GetJsIntArray(disableSelectFields.ToArray()));
        //    //disableSelectScript += "\r\n"; 
        //    #endregion
        //    return StringUtil.GetStringFromIntArray(disableSelectRows.ToArray());
        //}


        #endregion

        #endregion

        #region DataBind
        /// <summary>
        /// 绑定到数据源
        /// </summary>
        public override void DataBind()
        {
            if (_dataSource != null)
            {
                // Clear all items
                Items.Clear();

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
            }

            base.DataBind();
        }

        #endregion

        #region private DataBind


        /// <summary>
        /// 绑定到数据表
        /// </summary>
        /// <param name="dataView"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        private void DataBindToDataTable(DataTable dataTable)
        {
            int startIndex = 0;
            int endIndex = Int32.MaxValue;
            for (int i = startIndex; i < Math.Min(endIndex, dataTable.Rows.Count); i++)
            {
                DataRow row = dataTable.Rows[i];

                Items.Add(CreateListItem(row));
            }
        }


        /// <summary>
        /// 绑定到可枚举列表
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
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

            //    ListItem item = new ListItem();

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

            //        // 如果需要模拟树
            //        if (!String.IsNullOrEmpty(DataSimulateTreeLevelField))
            //        {
            //            item.SimulateTreeLevel = Convert.ToInt32(GetPropertyValue(currentObject, DataSimulateTreeLevelField));
            //        }

            //        // 是否选择
            //        item.EnableSelect = true;
            //        if (!String.IsNullOrEmpty(DataEnableSelectField))
            //        {
            //            item.EnableSelect = Convert.ToBoolean(GetPropertyValue(currentObject, DataEnableSelectField));
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
                Items.Add(CreateListItem(currentObject));
            }
        }

        private ListItem CreateListItem(Object obj)
        {
            ListItem item = new ListItem();

            if (obj is string)
            {
                item.Text = obj.ToString();
                item.Value = obj.ToString();
            }
            else
            {
                if (DataTextField != "")
                {
                    if (DataTextFormatString != "")
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

                if (DataValueField != "")
                {
                    item.Value = GetPropertyValue(obj, DataValueField);
                }
                else
                {
                    item.Value = obj.ToString();
                }

                // 如果需要模拟树
                if (!String.IsNullOrEmpty(DataSimulateTreeLevelField))
                {
                    item.SimulateTreeLevel = Convert.ToInt32(GetPropertyValue(obj, DataSimulateTreeLevelField));
                }

                // 是否可以选择
                item.EnableSelect = true;
                if (!String.IsNullOrEmpty(DataEnableSelectField))
                {
                    item.EnableSelect = Convert.ToBoolean(GetPropertyValue(obj, DataEnableSelectField));
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

        //private void AfterDataBind()
        //{
        //    //// 必须重新计算模拟数的数据
        //    //mustReCalculateSimulateTreeData = true;
        //}

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string postValue = postCollection[postDataKey];

            if (SelectedValue != postValue)
            {
                ListItem item = Items.FindByValue(postValue);
                if (item != null)
                {
                    SelectedValue = postValue;
                    XState.BackupPostDataProperty("SelectedValue");
                    return true;
                }
                else
                {
                    if (!ForceSelection)
                    {
                        SelectedValue = null;
                        XState.BackupPostDataProperty("SelectedValue");

                        Text = postValue;
                        XState.BackupPostDataProperty("Text");
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            OnSelectedIndexChanged(EventArgs.Empty);
        }

        #endregion

        #region SelectedIndexChanged

        private object _handlerKey = new object();

        /// <summary>
        /// 选中项改变事件（需要启用AutoPostBack）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("选中项改变事件（需要启用AutoPostBack）")]
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



        ///// <summary>
        ///// 保存上次选中值的Input
        ///// </summary>
        //private string LastSelectedValueHiddenID
        //{
        //    get
        //    {
        //        return String.Format("{0}_last_value", XID);
        //    }
        //}

        ///// <summary>
        ///// 保存当前选中值的Input
        ///// </summary>
        //private string SelectedValueHiddenID
        //{
        //    get
        //    {
        //        return UniqueID;
        //    }
        //}


        ///// <summary>
        ///// 不可用的行Index列表
        ///// </summary>
        //private string DisableRowIndexsHiddenID
        //{
        //    get
        //    {
        //        return String.Format("{0}_disable_rows", ClientID);
        //    }
        //}


        //protected override void OnPreLoad(object sender, EventArgs e)
        //{
        //    base.OnPreLoad(sender, e);

        //    SaveAjaxProperty("DisableSelectRowIndexsString", GetDisableSelectRowIndexsString());
        //    SaveAjaxProperty("DataArrayString", GetDataArrayString());
        //    SaveAjaxProperty("SelectedValue", SelectedValue);
        //}

        #endregion
    }
}
