
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ControlBase.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2008-04-11    sanshi.ustc@gmail.com  
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


using System.Reflection;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Permissions;
using System.Collections;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace ExtAspNet
{
    /// <summary>
    /// 控件基类（抽象类）
    /// </summary>
    [Designer(typeof(ControlBaseDesigner))]
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public abstract class ControlBase : Control, INamingContainer
    {
        #region Constructor

        /// <summary>
        /// 构造函数
        /// </summary>
        public ControlBase()
        {

            _state = new XState(this);

            AddServerAjaxProperties("Hidden", "Enabled");
            AddClientAjaxProperties();

        }

        private XState _state = null;

        /// <summary>
        /// XState用来在服务器和客户端之间持久化控件状态。
        /// </summary>
        protected XState XState
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
            }
        }

        protected void AddServerAjaxProperties(params string[] props)
        {
            foreach (string prop in props)
            {
                if (!_serverAjaxProperties.Contains(prop))
                {
                    _serverAjaxProperties.Add(prop);
                }
                if (!_ajaxProperties.Contains(prop))
                {
                    _ajaxProperties.Add(prop);
                }
            }

        }

        protected void AddClientAjaxProperties(params string[] props)
        {

            foreach (string prop in props)
            {
                if (!_clientAjaxProperties.Contains(prop))
                {
                    _clientAjaxProperties.Add(prop);
                }
                if (!_ajaxProperties.Contains(prop))
                {
                    _ajaxProperties.Add(prop);
                }
            }

        }


        private List<string> _ajaxProperties = new List<string>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<string> AjaxProperties
        {
            get { return _ajaxProperties; }
            set { _ajaxProperties = value; }
        }

        private List<string> _serverAjaxProperties = new List<string>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<string> ServerAjaxProperties
        {
            get { return _serverAjaxProperties; }
            set { _serverAjaxProperties = value; }
        }

        private List<string> _clientAjaxProperties = new List<string>();

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<string> ClientAjaxProperties
        {
            get { return _clientAjaxProperties; }
            set { _clientAjaxProperties = value; }
        }

        /// <summary>
        /// 标示是否初始化完成
        /// </summary>
        internal bool InitialComplete = false;

        #endregion

        #region Internal Properties


        private string _xid = String.Empty;

        /// <summary>
        /// JavaScript中使用ID（比如：x0, x1）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string XID
        {
            get
            {
                if (String.IsNullOrEmpty(_xid))
                {
                    _xid = ClientJavascriptIDManager.Instance.GetNextJavascriptID();
                }
                return _xid;
            }
        }

        /// <summary>
        /// 获取控件实例的JavaScript代码（比如：X('RegionPanel1_Button1')）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string ScriptID
        {
            get
            {
                return String.Format("X('{0}')", ClientID);
            }
        }


        private bool _renderWrapperNode = true;

        /// <summary>
        /// 是否向页面输出控件的外部容器（默认：true）
        /// 否：只创建Javascript对象而不添加到页面中
        /// 是：创建Javascript对象，并添加到页面中，页面上添加占位符
        /// </summary>
        internal virtual bool RenderWrapperNode
        {
            get
            {
                return _renderWrapperNode;
            }
            set
            {
                _renderWrapperNode = value;
            }
        }

        private OptionBuilder _optionBuilder;

        /// <summary>
        /// 参数对象创建器
        /// </summary>
        internal OptionBuilder OB
        {
            get
            {
                if (_optionBuilder == null)
                {
                    _optionBuilder = new OptionBuilder();
                }
                return _optionBuilder;
            }
        }



        private JObject _postBackState = null;

        /// <summary>
        /// 从 HTTP 请求中恢复当前控件的状态
        /// 比如当前请求 Request.Form["X_STATE"] = {"btnClientClick":{"OnClientClick":"X.util.alert(\"This is an alert dialog\",\"\",Ext.MessageBox.INFO,'');"},"btnPressed":{"Pressed":false}}
        /// 并且当前控件的 ClientID 是 "btnPressed"，则返回值为 JObject 对象 {"Pressed":false}
        /// </summary>
        internal JObject PostBackState
        {
            get
            {
                if (_postBackState == null)
                {
                    JObject states = ResourceManager.Instance.PostBackStates;

                    _postBackState = states.Value<JObject>(ClientID);
                    if (_postBackState == null)
                    {
                        _postBackState = new JObject();
                    }
                    //JProperty clientIDProperty = states.Property(ClientID);
                    //if (clientIDProperty != null)
                    //{
                    //    _postBackState = clientIDProperty.Value<JObject>(ClientID); //.getJObject(ClientID);
                    //}
                    //else
                    //{
                    //    _postBackState = new JObject();
                    //}
                }
                return _postBackState;
            }
        }


        #endregion

        #region ReadOnly Properties

        /// <summary>
        /// 不支持此属性（已禁用 Asp.Net 默认的 ViewState）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableViewState
        {
            get
            {
                return false;
            }
        }


        ///// <summary>
        ///// 不支持此属性（请使用 Hidden 属性）
        ///// </summary>
        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public override bool Visible
        //{
        //    get
        //    {
        //        return true;
        //    }
        //}


        /// <summary>
        /// 控件的客户端ID（比如：RegionPanel1_Button1）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string ClientID
        {
            get
            {
                return base.ClientID;
            }
        }


        // ID是设计的时候所指定的ID。
        // ClientID是当这个控件生成到客户端页面时候，需要在客户端访问时候用的。
        // UniqueID是当需要参与服务端回传的时候用的。
        // 备注：当控件是子控件的时候（例如在用户控件中的Button），ClientID在HTML页面中是作为控件的ID属性，
        // UniqueID是作为控件的Name属性，如果不是子控件，那么ClientID和UniqueID是相同的

        /// <summary>
        /// 控件外部容器的客户端ID（比如：Button1_wrapper）
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string WrapperID
        {
            get
            {
                return String.Format("{0}_wrapper", ClientID);
            }
        }


        /// <summary>
        /// 产品名称
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ProductName
        {
            get
            {
                return GlobalConfig.ProductName;
            }
        }

        /// <summary>
        /// 产品版本
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string ProductVersion
        {
            get
            {
                return GlobalConfig.ProductVersion;
            }
        }

        #endregion

        #region Properties


        /// <summary>
        /// 控件ID
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [Description("控件ID")]
        public override string ID
        {
            get
            {
                return base.ID;
            }
            set
            {
                base.ID = value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否可用
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(true)]
        [Description("[AJAX属性]是否可用")]
        public virtual bool Enabled
        {
            get
            {
                object obj = XState["Enabled"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["Enabled"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否隐藏
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]是否隐藏")]
        public virtual bool Hidden
        {
            get
            {
                object obj = XState["Hidden"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Hidden"] = value;
            }
        }

        /// <summary>
        /// 隐藏模式
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        [DefaultValue(HideMode.Display)]
        [Description("隐藏的模式")]
        public virtual HideMode HideMode
        {
            get
            {
                object obj = XState["HideMode"];
                return obj == null ? HideMode.Display : (HideMode)obj;
            }
            set
            {
                XState["HideMode"] = value;
            }
        }


        /// <summary>
        /// 是否启用AJAX
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        //[DefaultValue(true)]
        [Description("是否启用AJAX")]
        public virtual bool EnableAjax
        {
            get
            {
                object obj = XState["EnableAjax"];
                if (obj == null)
                {
                    return PageManager.Instance.EnableAjax;
                }
                return (bool)obj;
            }
            set
            {
                XState["EnableAjax"] = value;
            }
        }


        /// <summary>
        /// 是否启用Ajax正在加载提示
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        //[DefaultValue(true)]
        [Description("是否启用Ajax正在加载提示")]
        public bool EnableAjaxLoading
        {
            get
            {
                object obj = XState["EnableAjaxLoading"];
                if (obj == null)
                {
                    return PageManager.Instance.EnableAjaxLoading;
                }
                return (bool)obj;
            }
            set
            {
                XState["EnableAjaxLoading"] = value;
            }
        }


        /// <summary>
        /// Ajax正在加载提示的类型
        /// </summary>
        [Category(CategoryName.BASEOPTIONS)]
        //[DefaultValue(AjaxLoadingType.Default)]
        [Description("Ajax正在加载提示的类型")]
        public AjaxLoadingType AjaxLoadingType
        {
            get
            {
                object obj = XState["AjaxLoadingType"];
                if (obj == null)
                {
                    return PageManager.Instance.AjaxLoadingType;
                }
                return (AjaxLoadingType)obj;
            }
            set
            {
                XState["AjaxLoadingType"] = value;
            }
        }


        /// <summary>
        /// 是否处于ExtAspNet的AJAX回发过程
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsExtAspNetAjaxPostBack
        {
            get
            {
                return ResourceManager.Instance.IsExtAspNetAjaxPostBack;
            }
        }


        #endregion

        #region OnInit

        /// <summary>
        /// 页面初始化事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!DesignMode)
            {
                // 确保所有子控件都已经被创建
                EnsureChildControls();

                // 如果控件没有设置 ID，则自动创建一个（比如：ct100）
                base.EnsureID();

                // 此时，ASPX 页面上标签定义的控件已经初始化完毕
                // 如果当前是页面回发，则从 HTTP 请求的表单数据中（X_STATE）恢复当前控件的状态
                if (Page.IsPostBack)
                {
                    RecoverPropertiesFromJObject(PostBackState);
                }

                // 向子控件公开方法，可以在备份初始化属性之前修改属性值
                OnInitControl();

                // 备份初始化属性值
                XState.BackupInitializedProperties();

                // 标识初始化完成
                InitialComplete = true;

            }
        }

        /// <summary>
        /// 向子控件公开的方法，可以在备份初始化属性之前修改属性值
        /// 在这个地方对控件的属性做变更是安全的：
        //     -> 页面第一次加载时，运行到这里 ASPX 上面的标签已经初始化完毕
        //     -> 页面回发时（包括正常回发或者AJAX回发），此时请求表单中 X_STATE 已经恢复完毕
        /// </summary>
        protected virtual void OnInitControl()
        {

        }

        #endregion

        #region RenderBeginTag RenderEndTag

        /// <summary>
        /// 重载 RenderControl，为了向子控件公开 RenderBeginTag 和 RenderEndTag 两个方法
        /// </summary>
        /// <param name="writer">服务器控件输出流</param>
        public override void RenderControl(HtmlTextWriter writer)
        {
            RenderBeginTag(writer);

            base.RenderControl(writer);

            RenderEndTag(writer);
        }


        /// <summary>
        /// 生成控件的开始标签
        /// </summary>
        /// <param name="writer"></param>
        protected virtual void RenderBeginTag(HtmlTextWriter writer)
        {
            if (RenderWrapperNode)
            {
                writer.Write(String.Format("<div id=\"{0}\">", WrapperID));
            }
        }

        /// <summary>
        /// 渲染控件的结束标签
        /// </summary>
        /// <param name="writer"></param>
        protected virtual void RenderEndTag(HtmlTextWriter writer)
        {
            if (RenderWrapperNode)
            {
                writer.Write("</div>");
            }
        }



        //protected override void Render(HtmlTextWriter writer)
        //{
        //    base.Render(writer);

        //    if (Page != null)
        //    {
        //        Page.VerifyRenderingInServerForm(this);
        //    }
        //}

        #endregion

        #region OnPreRender

        /// <summary>
        /// 渲染输出 HTML 之前调用
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // 在页面第一次加载,正常的 PostBack以及 AJAX 都需要执行下面代码 
            if (this is IPostBackDataHandler)
            {
                // 如果当前控件实现了 IPostBackDataHandler 接口，则需要调用 RegisterRequiresPostBack，
                // 以便在 ControlState 中保存这个控件的 ClientID，然后下次回发时会由此调用此控件的 LoadPostData 函数
                // 主要用来处理客户端改变控件属性的情况
                Page.RegisterRequiresPostBack(this);
            }


            OnBothPreRender();

            // 计算被修改的属性列表
            XState.CalculateModifiedProperties();

            if (IsExtAspNetAjaxPostBack)
            {
                OnAjaxPreRender();

                if (_ajaxScriptBuilder.Length > 0)
                {
                    ResourceManager.Instance.AjaxScriptList.Add(_ajaxScriptBuilder.ToString());

                    // 添加在 JavaScript 中使用的控件变量的短格式（比如 x0=X('RegionPanel1_Button1')）
                    ResourceManager.Instance.AddAjaxShortName(ClientID, XID);
                }
            }
            else
            {
                // 页面第一次加载和正常的回发两种情况
                OnFirstPreRender();
            }
        }

        /// <summary>
        /// 在计算被修改属性列表之前调用，可以在此修改属性
        /// </summary>
        protected virtual void OnBothPreRender()
        {

        }

        /// <summary>
        /// 渲染输出 HTML 之前调用（AJAX回发阶段）
        /// </summary>
        protected virtual void OnAjaxPreRender()
        {
            StringBuilder sb = new StringBuilder();
            #region old code
            // There are new properties need to be persisted during the next postback.
            // Re-write the "x_props" property of the component instance.
            //if (XState.TotalModifiedProperties.Count > PostBackState.Count)
            //{
            //    sb.AppendFormat("{0}.x_props={1};", XID, new JArray(XState.TotalModifiedProperties));
            //}

            //foreach (string property in XState.ModifiedProperties)
            //{
            //    string propertyValue = String.Empty;

            //    PropertyInfo info = this.GetType().GetProperty(property);
            //    if (info.PropertyType == typeof(String))
            //    {
            //        propertyValue = JsHelper.Enquote(info.GetValue(this, null).ToString());
            //    }
            //    else if (info.PropertyType == typeof(Boolean))
            //    {
            //        // "true", "false"
            //        propertyValue = info.GetValue(this, null).ToString().ToLower();
            //    }
            //    else if (info.PropertyType.BaseType == typeof(Enum))
            //    {
            //        // ConfirmTarget -> "Self", "Parent", "Top"
            //        propertyValue = JsHelper.Enquote(StringUtil.GetEnumName((Enum)info.GetValue(this, null)));
            //    }

            //    sb.AppendFormat("{0}.x_p_{1}={2};", XID, property, propertyValue);
            //} 
            #endregion

            List<string> currentModifiedProperties = XState.ModifiedProperties;
            if (currentModifiedProperties.Count > 0)
            {
                // 更新当前控件的 X_STATE 状态
                sb.AppendFormat("X.state({0},{1});", XID, ConvertPropertiesToJObject(currentModifiedProperties).ToString(Formatting.None));
            }

            sb.Append(GetHiddenPropertyChangedScript());

            sb.Append(GetEnabledPropertyChangedScript());

            AddAjaxScript(sb);
        }

        /// <summary>
        /// 渲染输出 HTML 之前调用（页面第一次加载和正常的 PostBack 两种情况）
        /// </summary>
        protected virtual void OnFirstPreRender()
        {
            #region old code
            //foreach (string property in XState.TotalModifiedProperties)
            //{
            //    object propertyValue = null;

            //    PropertyInfo info = this.GetType().GetProperty(property);
            //    if (info.PropertyType == typeof(String))
            //    {
            //        propertyValue = info.GetValue(this, null).ToString();
            //    }
            //    else if (info.PropertyType == typeof(Boolean))
            //    {
            //        propertyValue = Convert.ToBoolean(info.GetValue(this, null));
            //    }
            //    else if (info.PropertyType.BaseType == typeof(Enum))
            //    {
            //        propertyValue = StringUtil.GetEnumName((Enum)info.GetValue(this, null));
            //    }

            //    OB.AddProperty("x_p_" + property, propertyValue);

            //}

            //// These properties has been modified in the past postbacks.
            //// Every ExtAspNet control should has this property.
            //OB.AddProperty("x_props", new JArray(XState.TotalModifiedProperties), true);

            #endregion

            List<string> totalModifiedProperties = XState.GetTotalModifiedProperties();
            if (totalModifiedProperties.Count > 0)
            {
                OB.AddProperty("x_state", ConvertPropertiesToJObject(totalModifiedProperties).ToString(Formatting.None), true);
            }
            else
            {
                OB.AddProperty("x_state", "{}", true);
            }

            // Every component need this property.
            OB.AddProperty("id", ClientID);

            if (RenderWrapperNode)
            {
                OB.AddProperty("renderTo", WrapperID);
            }

            if (Hidden)
            {
                OB.AddProperty("hidden", true);
            }
            if (HideMode != HideMode.Display)
            {
                OB.AddProperty("hideMode", HideModeName.GetName(HideMode));
            }

            if (!Enabled)
            {
                OB.AddProperty("disabled", true);
            }


            #region old code

            //if (AjaxPropertyChanged("Hidden", Hidden))
            //{
            //    HiddenPropertyChanged();
            //}

            //// 渲染到客户端时的JavascriptId
            //OB.AddProperty("id", ClientJavascriptID);

            // 不需要这样做，
            //// 判断父控件是否用户控件（UserControl）
            //if (Parent is UserControl || Parent is ContentPlaceHolder)
            //{
            //    if (!ResourceManagerInstance.IsStartupScriptExist(Parent as Control))
            //    {
            //        AddStartupScript(Parent, String.Empty);
            //    }
            //} 

            #endregion
        }

        #endregion

        #region PropertyModified

        /// <summary>
        /// 回发过程中此属性是否被改变
        /// 如果是客户端可以改变的属性，仅在服务器端改变时才返回 true，
        /// （如果仅是客户端改变，则返回 false，因为客户端改变的属性不需要再输出相应的 JavaScript 脚本）
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool PropertyModified(string propertyName)
        {
            bool modified = XState.ModifiedProperties.Contains(propertyName);
            if (modified)
            {
                if (ClientAjaxProperties.Contains(propertyName))
                {
                    if (XState.ClientPropertiesModifiedInServer.Contains(propertyName))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 回发过程中这些属性是否被改变
        /// 只要任何属性被改变，就返回 true
        /// </summary>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        protected bool PropertyModified(params string[] propertyNames)
        {
            foreach (string property in propertyNames)
            {
                if (PropertyModified(property))
                {
                    return true;
                }
            }
            return false;
        }

        //protected bool ClientPropertyModifiedInServer(string propertyName)
        //{
        //    return XState.ClientPropertiesModifiedInServer.Contains(propertyName);
        //}


        #region old code
        ///// <summary>
        ///// Whether the property has been changed in the past postbacks.
        ///// </summary>
        ///// <param name="propertyName"></param>
        ///// <returns></returns>
        //protected bool TotalPropertyModified(string propertyName)
        //{
        //    return XState.TotalModifiedProperties.Contains(propertyName);
        //}

        ///// <summary>
        ///// Get client value of a property in the postback state(X_STATE).
        ///// </summary>
        ///// <param name="propertyName"></param>
        ///// <returns></returns>
        //protected object GetPostBackClientValue(string propertyName)
        //{
        //    return PostBackState["X_" + propertyName];
        //} 
        #endregion

        #endregion

        #region RecoverPropertiesFromXState ConvertPropertiesToXState

        /// <summary>
        /// 从JObject恢复控件的属性
        /// </summary>
        /// <param name="state">对象属性的JObject形式</param>
        public void RecoverPropertiesFromJObject(JObject state)
        {
            foreach (JProperty propertyObj in state.Properties())
            {
                string property = propertyObj.Name;
                PropertyInfo info = this.GetType().GetProperty(property);
                if (info != null)
                {
                    if (info.PropertyType.BaseType == typeof(Enum))
                    {
                        info.SetValue(this, Enum.Parse(info.PropertyType, state.Value<string>(property)), null);
                    }
                    else if (info.PropertyType == typeof(Unit))
                    {
                        info.SetValue(this, Unit.Parse(state.Value<string>(property)), null);
                    }
                    else if (info.PropertyType.BaseType == typeof(Array))
                    {
                        if (info.PropertyType == typeof(Int32[]))
                        {
                            info.SetValue(this, JSONUtil.IntArrayFromJArray(state.Value<JArray>(property)), null);
                        }
                        else if (info.PropertyType == typeof(String[]))
                        {
                            info.SetValue(this, JSONUtil.StringArrayFromJArray(state.Value<JArray>(property)), null);
                        }
                    }
                    else
                    {
                        JToken jtoken = state.Property(property).Value;
                        if (jtoken is JContainer)
                        {
                            info.SetValue(this, jtoken, null);
                        }
                        else
                        {
                            object propertyValue = ((JValue)jtoken).Value;

                            // 类型“System.Int64”的对象无法转换为类型“System.Int32”。
                            // 类型“System.Int64”的对象无法转换为类型“System.Nullable`1[System.Int32]”。
                            // 类型“System.Int64”的对象无法转换为类型“System.Int16”。
                            // 类型“System.Int64”的对象无法转换为类型“System.Nullable`1[System.Int16]”。
                            if (propertyValue != null && propertyValue.GetType() == typeof(Int64))
                            {
                                if (info.PropertyType == typeof(Int32) || info.PropertyType == typeof(Int32?))
                                {
                                    propertyValue = Convert.ToInt32(propertyValue);
                                }

                                if (info.PropertyType == typeof(Int16) || info.PropertyType == typeof(Int16?))
                                {
                                    propertyValue = Convert.ToInt16(propertyValue);
                                }

                                // 类型“System.Int64”的对象无法转换为类型“System.Nullable`1[System.Double]”。
                                // 注意：“2.0”会被解析为Int64，而“2.1”会被解析为Double，所以有可能会进入这个分支
                                if (info.PropertyType == typeof(Double) || info.PropertyType == typeof(Double?))
                                {
                                    propertyValue = Convert.ToDouble(propertyValue);
                                }

                                if (info.PropertyType == typeof(float) || info.PropertyType == typeof(float?))
                                {
                                    propertyValue = Convert.ToSingle(propertyValue);
                                }
                            }

                            info.SetValue(this, propertyValue, null);
                        }

                    }
                }

            }
        }


        /// <summary>
        /// 将控件的属性列表转化为JObject对象
        /// </summary>
        /// <param name="propertyList">属性列表</param>
        /// <returns>属性列表的JObject形式</returns>
        public JObject ConvertPropertiesToJObject(List<string> propertyList)
        {
            JObject jo = new JObject();
            foreach (string property in propertyList)
            {
                object propertyValue = GetPropertyJSONValue(property);
                //jo.Add(property, propertyValue == null ? "" : propertyValue);

                if (propertyValue is JToken)
                {
                    jo.Add(property, (JToken)propertyValue);
                }
                else
                {
                    if (propertyValue is String)
                    {
                        // The browser HTML parser will see the </script> within the string and it will interpret it as the end of the script element.
                        // http://www.xiaoxiaozi.com/2010/02/24/1708/
                        // http://stackoverflow.com/questions/1659749/script-tag-in-javascript-string
                        string propertyValueStr = propertyValue.ToString().Replace("</script>", @"<\/script>");
                        jo.Add(property, propertyValueStr);
                    }
                    else if (propertyValue is Unit)
                    {
                        jo.Add(property, (Int32)((Unit)propertyValue).Value);
                    }
                    else
                    {
                        jo.Add(property, new JValue(propertyValue));
                    }
                }

            }
            return jo; //.ToString(Formatting.None);
        }


        // 获取属性的 JSON 对象值
        internal object GetPropertyJSONValue(string prop)
        {
            object propValue = null;

            PropertyInfo info = this.GetType().GetProperty(prop);
            if (info != null)
            {
                propValue = info.GetValue(this, null);

                if (info.PropertyType.BaseType == typeof(Enum))
                {
                    propValue = StringUtil.EnumToName((Enum)propValue);
                }
                else if (info.PropertyType.BaseType == typeof(Array))
                {
                    if (propValue == null)
                    {
                        propValue = new JArray();
                    }
                    else
                    {
                        propValue = new JArray((Array)propValue);
                    }
                }
            }

            return propValue;
        }

        #endregion

        #region AddAjaxScript

        private StringBuilder _ajaxScriptBuilder = new StringBuilder();

        /// <summary>
        /// AJAX 回发阶段，添加反映属性改变的 JavaScript 脚本
        /// </summary>
        /// <param name="script"></param>
        protected void AddAjaxScript(string script)
        {
            if (!String.IsNullOrEmpty(script))
            {
                _ajaxScriptBuilder.Append(script);
            }
        }

        /// <summary>
        /// AJAX 回发阶段，添加反映属性改变的 JavaScript 脚本
        /// </summary>
        /// <param name="sb"></param>
        protected void AddAjaxScript(StringBuilder sb)
        {
            if (sb.Length > 0)
            {
                _ajaxScriptBuilder.Append(sb);
            }
        }


        #endregion

        #region AddStartupCSS

        protected void AddStartupCSS(string key, string cssContent)
        {
            if (!IsExtAspNetAjaxPostBack)
            {
                ResourceManager.Instance.AddStartupCSS(key, cssContent);
            }
        }

        protected void RemoveStartupCSS(string key)
        {
            if (!IsExtAspNetAjaxPostBack)
            {
                ResourceManager.Instance.RemoveStartupCSS(key);
            }
        }

        #endregion

        #region AddStartupScript AddStartupAbsoluteScript

        protected void AddStartupAbsoluteScript(string script)
        {
            if (!IsExtAspNetAjaxPostBack)
            {
                ResourceManager.Instance.AddAbsoluteStartupScript(script);
            }
        }

        protected void AddStartupAbsoluteScript(string script, int level)
        {
            if (!IsExtAspNetAjaxPostBack)
            {
                ResourceManager.Instance.AddAbsoluteStartupScript(script, level);
            }
        }

        protected void AddStartupScript(string scriptContent)
        {
            if (!IsExtAspNetAjaxPostBack)
            {
                // 合并在基类中注册的脚本，然后整体注册
                if (ResourceManager.Instance.IsStartupScriptExist(this))
                {
                    scriptContent = scriptContent + ResourceManager.Instance.GetStartupScript(this).Script;
                    ResourceManager.Instance.RemoveStartupScript(this);
                }

                if (Visible)
                {
                    ResourceManager.Instance.AddStartupScript(this, scriptContent);
                }
            }

            #region old code

            //if (!IsExtAspNetAjaxPostBack)
            //{
            //    // 如果是页面第一次加载，或者不是ExtAspNetAjax（比如是普通的PostBack或者是Asp.netAjax回发）
            //    AddStartupScript(this, scriptContent);

            //    if (AjaxForceCompleteUpdate)
            //    {
            //        BoxState["__AllScript__"] = scriptContent.GetHashCode().ToString("X8");
            //    }
            //    //SaveAjaxProperty("AllScript", scriptContent, true);
            //}
            //else
            //{
            //    if (AjaxForceCompleteUpdate)
            //    {
            //        // 如果强制更新控件的整个内容，并且内容变化了，则更新
            //        if (BoxState["__AllScript__"].ToString() != scriptContent.GetHashCode().ToString("X8"))
            //        {
            //            AjaxCompleteUpdateControl(scriptContent);
            //        }
            //    }
            //    else
            //    {
            //        AjaxPartialUpdateControl();
            //    }
            //} 

            #endregion
        }

        #endregion

        #region GetHiddenPropertyChangedScript GetEnabledPropertyChangedScript

        /// <summary>
        /// 反映 Hidden 属性改变的 JavaScript 脚本
        /// 有些控件可能需要特别的逻辑，因此这里为虚函数（比如 Window 控件）
        /// </summary>
        protected virtual string GetHiddenPropertyChangedScript()
        {
            if (PropertyModified("Hidden"))
            {
                return String.Format("{0}.x_setVisible();", XID);
            }
            return String.Empty;
        }

        /// <summary>
        /// 反映 Enabled 属性改变的 JavaScript 脚本
        /// 有些控件可能需要特别的逻辑，因此这里为虚函数
        /// </summary>
        protected virtual string GetEnabledPropertyChangedScript()
        {
            if (PropertyModified("Enabled"))
            {
                return String.Format("{0}.x_setDisabled();", XID);
            }
            return String.Empty;
        }

        #endregion

        #region GetPostBackEventReference

        /// <summary>
        /// 获取回发页面的客户端脚本（比如：__doPostBack('btnChangeEnable','');)
        /// </summary>
        /// <returns>客户端脚本</returns>
        public string GetPostBackEventReference()
        {
            return GetPostBackEventReference(String.Empty);
        }

        /// <summary>
        /// 获取回发页面的客户端脚本（比如：__doPostBack('btnChangeEnable','true');)
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        /// <returns>客户端脚本</returns>
        public string GetPostBackEventReference(string eventArgument)
        {
            #region old code
            // 必须调用 Page.ClientScript.GetPostBackEventReference，不能手工返回js字符串
            ////return Page.ClientScript.GetPostBackEventReference(this, argument) + ";";
            //if (EnableAjax)
            //{
            //    return String.Format("__doAjaxPostBack('{0}','{1}');", this.ClientID, argument);
            //}
            //else
            //{
            //    //return String.Format("__doPostBack('{0}','{1}');", this.ClientID, argument);
            //    return Page.ClientScript.GetPostBackEventReference(this, argument) + ";";
            //} 


            //if (PageManager.Instance.EnableAjax && !EnableAjax)
            //{
            //    postBackScript += GetSetHiddenFieldValueScript(ResourceManager.DISABLE_AJAX_CONTROL_ID, this.UniqueID);
            //}
            #endregion

            StringBuilder sb = new StringBuilder();

            if (EnableAjax != PageManager.Instance.EnableAjax)
            {
                sb.AppendFormat("X.control_enable_ajax={0};", EnableAjax ? "true" : "false");
            }

            if (EnableAjaxLoading != PageManager.Instance.EnableAjaxLoading)
            {
                sb.AppendFormat("X.control_enable_ajax_loading={0};", EnableAjaxLoading ? "true" : "false");
            }

            if (AjaxLoadingType != PageManager.Instance.AjaxLoadingType)
            {
                sb.AppendFormat("X.control_ajax_loading_type='{0}';", AjaxLoadingTypeName.GetName(AjaxLoadingType));
            }

            //// 如果页面启用 AJAX，但是此控件禁用 AJAX
            //if (EnableAjax)
            //{
            //    if (EnableAjaxLoading)
            //    {
            //        if (AjaxLoadingType != AjaxLoadingType.Default)
            //        {
            //            sb.AppendFormat("X.control_ajax_loading_type='{0}';", AjaxLoadingTypeName.GetName(AjaxLoadingType));
            //        }
            //    }
            //    else
            //    {
            //        sb.Append("X.control_enable_ajax_loading=false;");
            //    }
            //}
            //else
            //{
            //    sb.Append("X.control_enable_ajax=false;");
            //}


            sb.Append(Page.ClientScript.GetPostBackEventReference(this, eventArgument));
            sb.Append(";");

            return sb.ToString();
        }

        // This is the same as UniqueID
        // Get PostBackID that can be used in postback event.
        //internal string GetPostBackID()
        //{
        //    string postbackscript = Page.ClientScript.GetPostBackEventReference(this, String.Empty);
        //    // __doPostBack('regionPanel$leftRegion$Button1','')
        //    int start = postbackscript.IndexOf("'"),
        //        end = postbackscript.LastIndexOf("','')");
        //    return postbackscript.Substring(start + 1, end - start - 1);
        //}

        #endregion

        #region GetSetHiddenFieldValueScript

        // 获取修改隐藏表单字段值的脚本（如果此隐藏表单字段不存在，则添加）
        protected string GetSetHiddenFieldValueScript(string id, string value)
        {
            return String.Format("X.util.setHiddenFieldValue('{0}','{1}');", id, value);
        }

        // 获取修改隐藏表单字段值的脚本（如果此隐藏表单字段不存在，则添加）
        protected string GetSetHiddenFieldValueScript(string id, string value, string windowObj)
        {
            if (String.IsNullOrEmpty(windowObj) || windowObj == "window")
            {
                return GetSetHiddenFieldValueScript(id, value);
            }
            return String.Format("{2}.X.util.setHiddenFieldValue('{0}','{1}');", id, value, windowObj);
        }

        #endregion

        #region GetResolvedIconUrl

        // 获取客户端可用的图标 URL 地址
        protected string GetResolvedIconUrl(Icon icon, string iconUrl)
        {
            /*
            string url = iconUrl;
            if (String.IsNullOrEmpty(url))
            {
                if (icon != Icon.None)
                {
                    url = IconHelper.GetIconUrl(icon);
                }
            }

            return ResolveUrl(url);
             * */
            return IconHelper.GetResolvedIconUrl(icon, iconUrl);
        }

        #endregion

        #region oldcode


        //private Dictionary<string, string> _xProperties = new Dictionary<string, string>();

        //internal void SaveXProperty(string key, string value)
        //{
        //    _xProperties[key] = value;
        //}

        //internal bool XPropertyModified(string key, string currentValue)
        //{
        //    if (_xProperties.ContainsKey(key))
        //    {
        //        string lastValue = _xProperties[key];
        //        if (lastValue != currentValue)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}




        //private Dictionary<string, string> _ajaxProperties__ = new Dictionary<string, string>();

        ///// <summary>
        /////
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="objSource"></param>
        ///// <returns></returns>
        //internal bool AjaxPropertyChanged(string key, object objSource)
        //{
        //    // 如果不是ExtAspNetAjax回发，则不执行此逻辑
        //    if (!IsExtAspNetAjaxPostBack)
        //    {
        //        return false;
        //    }

        //    if (!_ajaxProperties__.ContainsKey(key))
        //    {
        //        // 对于在Page_Load之后动态添加的控件，肯定会运行到这里，对这些属性不做处理
        //        // 所以动态添加控件，一定要在 Page_Init 中进行
        //        // throw new Exception(String.Format("Please set the property [{0}] in Page_OnPreLoad.", key));
        //        return false;
        //    }

        //    string objStr = String.Empty;
        //    if (objSource != null)
        //    {
        //        objStr = objSource.ToString();
        //    }

        //    if (_ajaxProperties__[key] == objStr)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        //internal void SaveAjaxProperty(string key, object objSource)
        //{
        //    string saveValue = String.Empty;
        //    if (objSource != null)
        //    {
        //        saveValue = objSource.ToString();
        //    }

        //    _ajaxProperties__[key] = saveValue;
        //}




        #endregion

        #region oldcode

        ///// <summary>
        ///// 如果不是ExtAspNetAjax回发，则保存值的改变到ViewState，同时返回false
        ///// 如果是ExtAspNetAjax回发，则判断此key存储在ViewState的值是否改变，如果改变则返回true
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="objSource"></param>
        ///// <returns></returns>
        //internal bool AjaxPropertyChanged(string key, object objSource)
        //{
        //    string hashCode = CreateAjaxPropertyValue(objSource);

        //    // 如果不是ExtAspNetAjax回发，则保存值的改变到ViewState，同时返回false
        //    if (!IsExtAspNetAjaxPostBack)
        //    {
        //        SaveAjaxProperty(key, hashCode);
        //        return false;
        //    }

        //    if (GetAjaxProperty(key) != hashCode)
        //    {
        //        SaveAjaxProperty(key, hashCode);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ///// <summary>
        ///// 保存HashCode到ViewState
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="hashCode"></param>
        ///// <param name="source"></param>
        //internal void SaveAjaxProperty(string key, object hashCode, bool source)
        //{
        //    string hashCodeStr = String.Empty;
        //    if (hashCode != null)
        //    {
        //        hashCodeStr = hashCode.ToString();
        //        if (source)
        //        {
        //            hashCodeStr = CreateAjaxPropertyValue(hashCode);
        //        }
        //    }

        //    SaveAjaxProperty(key, hashCodeStr);
        //}

        ///// <summary>
        ///// 生成需要保存的Ajax属性的值
        ///// 对于Boolean型的，直接返回"0"或者"1"
        ///// 对于其他类型，返回其ToString后的HashCode
        ///// </summary>
        ///// <param name="strSource"></param>
        ///// <returns></returns>
        //private string CreateAjaxPropertyValue(object objSource)
        //{
        //    if (objSource is Boolean)
        //    {
        //        return (Boolean)objSource ? "1" : "0";
        //    }

        //    string strSource = objSource.ToString();
        //    return String.IsNullOrEmpty(strSource) ? "" : strSource.GetHashCode().ToString("X8");
        //}

        ///// <summary>
        ///// 保存HashCode到ViewState
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="strSource"></param>
        //private void SaveAjaxProperty(string key, string hashCode)
        //{
        //    key = String.Format("{0}", key);
        //    ViewState[key] = hashCode;
        //}


        ///// <summary>
        ///// 从ViewState读取HashCode
        ///// </summary>
        ///// <param name="key"></param>
        ///// <returns></returns>
        //private string GetAjaxProperty(string key)
        //{
        //    key = String.Format("{0}", key);

        //    object obj = ViewState[key];
        //    return obj == null ? String.Empty : (string)obj;
        //}

        #endregion

        #region oldcode

        //private void RenderAjaxUpdateScript()
        //{
        //    if (_ajaxUpdateScriptList.Count > 0)
        //    {
        //        StringBuilder sb = new StringBuilder();
        //        foreach (string script in _ajaxUpdateScriptList)
        //        {
        //            sb.Append(script);
        //        }

        //        AddStartupScript(this, sb.ToString());
        //    }
        //}


        ///// <summary>
        ///// 全部更新不适用于所有控件
        ///// </summary>
        ///// <param name="scriptContent"></param>
        //private void AjaxCompleteUpdateControl(string scriptContent)
        //{
        //    if (this.Controls.Count > 0)
        //    {
        //        // 如果是容器控件，则目前不支持Ajax更新
        //        // TODO
        //    }
        //    else
        //    {

        //        #region 重要说明

        //        // 这是一个复杂的过程，有两种情况需要考虑：
        //        // 1.直接渲染的控件，先销毁，在重新渲染
        //        // 2.依赖父容器渲染的的控件，首先取得父容器，本控件在父容器的位置，然后从父容器中销毁此控件，创建新的控件，将新的控件添加到删除的位置，父容器重新布局。
        //        // 第二种情况的整体结构如下
        //        ////// 1.取得父容器
        //        ////// var owner=X.i3.ownerCt;
        //        ////// 2.本控件在父容器的位置
        //        ////// var insertIndex=owner.items.indexOf(X.i3);
        //        ////// 3.从父容器中销毁此控件
        //        ////// owner.remove(X.i3);
        //        ////// 4.创建新的控件
        //        ////// X.i3=new Ext.form.TextField({id:"SimpleForm1_tbxUserName",stateful:false,fieldLabel:"用户名2",labelSeparator:"&nbsp;<span style=\"color:red;\"\>*</span\>",anchor:"-25px",name:"SimpleForm1$tbxUserName",disabled:false,allowBlank:false,listeners:{change:function(){box_pageStateChange();}}});
        //        ////// 5.将新的控件添加到删除的位置
        //        ////// owner.insert(insertIndex,X.i3);
        //        ////// 6.父容器重新布局
        //        ////// owner.doLayout();


        //        #endregion

        //        string startupScript = String.Empty;

        //        // 如果是Panel，并且不使用布局，则需要把内容先移出来，否则会在Panel被重建时被清空
        //        if (this is PanelBase && (this as PanelBase).RenderChildrenAsContent)
        //        {
        //            startupScript += String.Format("Ext.get(X.{0}.contentEl).hide();Ext.get(X.{0}.contentEl).appendTo(document.forms[0]);", ClientJavascriptID);
        //        }

        //        // 更新Javascript对象和UI重新布局
        //        startupScript += String.Format("X.ajax.updateObject(X.{0},{1},{2});",
        //            ClientJavascriptID,
        //            String.Format("function(){{{0}}}", scriptContent),
        //            RenderWrapperDiv.ToString().ToLower());

        //        AddStartupScript(this, startupScript);
        //    }
        //}


        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(false)]
        //[Description("Ajax回发时强制更新此控件全部内容")]
        //internal virtual bool AjaxForceCompleteUpdate
        //{
        //    get
        //    {
        //        object obj = BoxState["AjaxForceCompleteUpdate"];
        //        return obj == null ? false : (bool)obj;
        //    }
        //    set
        //    {
        //        BoxState["AjaxForceCompleteUpdate"] = value;
        //    }
        //}

        #endregion

        #region oldcode


        //public override void RenderBeginTag(HtmlTextWriter writer)
        //{
        //    if (RenderImmediately)
        //    {
        //        //writer.AddAttribute(HtmlTextWriterAttribute.Id, ContainerID);
        //        //writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "inline");
        //        //writer.RenderBeginTag(HtmlTextWriterTag.Div);

        //        // 用上面的语句，div中间有很大的空白，看着不爽
        //        writer.Write(String.Format("<div id=\"{0}\" style=\"display:inline;\">", ContainerID));
        //    }
        //}

        //public override void RenderEndTag(HtmlTextWriter writer)
        //{
        //    if (RenderImmediately)
        //    {
        //        //writer.RenderEndTag();
        //        writer.Write("</div>");
        //    }
        //} 


        //private string _beforeOnPreRenderScript = String.Empty;

        ///// <summary>
        ///// 此控件预渲染之前需要执行的脚本
        ///// </summary>
        //internal string BeforeOnPreRenderScript
        //{
        //    get
        //    {
        //        return _beforeOnPreRenderScript;
        //    }
        //    set
        //    {
        //        _beforeOnPreRenderScript = value;
        //    }
        //}

        //#region IsInUpdatePanel

        ///// <summary>
        ///// 此控件是否在UpdatePanel中
        ///// 注意：在局部回发时，只要在 UpdatePanel 中的控件都要更新，但有例外情况（如果UpdatePanel属性 UpdateMode="Conditional"）
        ///// </summary>
        ///// <param name="control"></param>
        ///// <returns></returns>
        //public bool IsInPartialRendering()
        //{
        //    if (HttpContext.Current != null && HttpContext.Current.Request != null)
        //    {
        //        for (Control control = this.Parent; control != null; control = control.Parent)
        //        {
        //            if (control.GetType().FullName.Contains("System.Web.UI.UpdatePanel"))
        //            {
        //                if ((control as UpdatePanel).IsInPartialRendering)
        //                {
        //                    return true;
        //                }
        //            } 
        //        }
        //    }
        //    return false;
        //}

        //#endregion

        //#region RefParentControl

        //private ControlBase _refParentControl;

        ///// <summary>
        ///// 需要指定父控件，以便保持控件的JS的渲染顺序是正确的（目前只在MasterPage中使用过一次）
        ///// </summary>
        //internal ControlBase RefParentControl
        //{
        //    get { return _refParentControl; }
        //    set { _refParentControl = value; }
        //}

        //#endregion 


        ///// <summary>
        ///// 添加启动脚本
        ///// 这个方法容易让人误解，去除不用
        ///// </summary>
        ///// <param name="scriptContent"></param>
        //protected void AddStartupScript(string script)
        //{
        //    #region old code
        //    //// 如果是局部回发，并且此控件不在UpdatePanel中，则不重新创建此控件
        //    //if (ResourceHelper.IsPartialPostBack() && ResourceHelper.IsContainScriptManager(Page) && !IsInUpdatePanel())
        //    //{
        //    //    return;
        //    //}

        //    //if (ResourceHelper.IsPartialPostBack(Page) && !IsInPartialRendering())
        //    //{
        //    //    return;
        //    //}

        //    //string addOnScript = "";
        //    //if (AddOnJavaScript != "" && AddOnJavaScript.Contains("{0}"))
        //    //{
        //    //    addOnScript = String.Format(AddOnJavaScript, ClientID);
        //    //}
        //    //_rm.AddStartupScript(this, scriptContent +  addOnScript); 
        //    #endregion

        //    AddStartupScript(this, script);
        //} 



        //protected void AddStartupScript(Control control, string script)
        //{
        //    AddStartupScript(control, script, String.Empty);
        //}

        ///// <summary>
        ///// 添加启动脚本
        ///// </summary>
        ///// <param name="control"></param>
        ///// <param name="scriptContent"></param>
        //protected void AddStartupScript(Control control, string script, string extraScript)
        //{
        //    // 如果控件 可见， 才渲染 javascript 到页面中
        //    if (Visible)
        //    {
        //        ResourceManager.Instance.AddStartupScript(control, script, extraScript);
        //    }
        //}



        //protected virtual void SetDirty()
        //{
        //    //ViewState.SetDirty(true);
        //}



        ////bool IStateManager.IsTrackingViewState
        ////{
        ////    get
        ////    {
        ////        return IsTrackingViewState;
        ////    }
        ////}

        ////void IStateManager.LoadViewState(object state)
        ////{
        ////    LoadViewState(state);
        ////}

        ////object IStateManager.SaveViewState()
        ////{
        ////    return SaveViewState();
        ////}

        ////void IStateManager.TrackViewState()
        ////{
        ////    TrackViewState();
        ////}


        //void ISetDirty.SetDirty()
        //{
        //    //SetDirty();
        //}

        #endregion

        #region oldcode

        ///// <summary>
        ///// 在页面的Page_Load之前执行
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected virtual void OnPreLoad(object sender, EventArgs e)
        //{
        //    //SaveAjaxProperty("Hidden", Hidden);
        //}

        #endregion
    }
}
