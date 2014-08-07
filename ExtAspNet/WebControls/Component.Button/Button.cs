
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Button.cs
 * CreatedOn:   2008-04-07
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
using System.Web.UI.Design;

namespace ExtAspNet
{
    /// <summary>
    /// 按钮控件
    /// </summary>
    [Designer(typeof(ButtonDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Button Text=\"Button\" runat=\"server\"></{0}:Button>")]
    [ToolboxBitmap(typeof(Button), "res.toolbox.Button.bmp")]
    [Description("按钮控件")]
    [DefaultEvent("Click")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Button : Component, IPostBackEventHandler, IPostBackDataHandler
    {
        #region Constructor

        public Button()
        {
            AddServerAjaxProperties("Text", "Icon", "IconUrl", "ToolTip", "OnClientClick", "ConfirmTitle", "ConfirmText", "ConfirmIcon", "ConfirmTarget");
            AddClientAjaxProperties("Pressed");
        }

        #endregion

        #region Properties

        /// <summary>
        /// 回发之前禁用按钮（防止重复提交）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("回发之前禁用按钮（防止重复提交）")]
        public bool DisableControlBeforePostBack
        {
            get
            {
                object obj = XState["DisableControlBeforePostBack"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["DisableControlBeforePostBack"] = value;
            }
        }

        /// <summary>
        /// 是否可以回发
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("是否可以回发")]
        public bool EnablePostBack
        {
            get
            {
                object obj = XState["EnablePostBack"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnablePostBack"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]是否被按下
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]是否被按下")]
        public bool Pressed
        {
            get
            {
                object obj = XState["Pressed"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Pressed"] = value;
            }
        }

        /// <summary>
        /// 是否可以按下
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否可以按下")]
        public bool EnablePress
        {
            get
            {
                object obj = XState["EnablePress"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnablePress"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]点击按钮时需要执行的客户端脚本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]点击按钮时需要执行的客户端脚本")]
        public string OnClientClick
        {
            get
            {
                object obj = XState["OnClientClick"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["OnClientClick"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]预定义图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("[AJAX属性]预定义图标")]
        public Icon Icon
        {
            get
            {
                object obj = XState["Icon"];
                return obj == null ? Icon.None : (Icon)obj;
            }
            set
            {
                XState["Icon"] = value;
            }
        }

        /// <summary>
        /// 按钮的大小
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ButtonSize.Small)]
        [Description("按钮的大小")]
        public ButtonSize Size
        {
            get
            {
                object obj = XState["Size"];
                return obj == null ? ButtonSize.Small : (ButtonSize)obj;
            }
            set
            {
                XState["Size"] = value;
            }
        }

        /// <summary>
        /// 图标地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("图标地址")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string IconUrl
        {
            get
            {
                object obj = XState["IconUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["IconUrl"] = value;
            }
        }

        /// <summary>
        /// 图标摆放位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(IconAlign.Left)]
        [Description("图标摆放位置")]
        public IconAlign IconAlign
        {
            get
            {
                object obj = XState["IconAlign"];
                return obj == null ? IconAlign.Left : (IconAlign)obj;
            }
            set
            {
                XState["IconAlign"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]按钮文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]按钮文本")]
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
        /// [AJAX属性]提示文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]提示文本")]
        public string ToolTip
        {
            get
            {
                object obj = XState["ToolTip"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ToolTip"] = value;
            }
        }


        /// <summary>
        /// 提示文本类型
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ToolTipType.Qtip)]
        [Description("提示文本类型")]
        public ToolTipType ToolTipType
        {
            get
            {
                object obj = XState["ToolTipType"];
                return obj == null ? ToolTipType.Qtip : (ToolTipType)obj;
            }
            set
            {
                XState["ToolTipType"] = value;
            }
        }



        /// <summary>
        /// Tab键索引
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("Tab键索引")]
        public short? TabIndex
        {
            get
            {
                object obj = XState["TabIndex"];
                return obj == null ? null : (short?)obj;
            }
            set
            {
                XState["TabIndex"] = value;
            }
        }

        /// <summary>
        /// 按钮类型
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(ButtonType.Button)]
        [Description("按钮类型")]
        public virtual ButtonType Type
        {
            get
            {
                object obj = XState["ButtonType"];
                return obj == null ? ButtonType.Button : (ButtonType)obj;
            }
            set
            {
                XState["ButtonType"] = value;
            }
        }


        #endregion

        #region ValidateForms/ValidateTarget

        /// <summary>
        /// 需要验证的表单名称列表（逗号分隔）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("需要验证的表单名称列表（逗号分隔）")]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] ValidateForms
        {
            get
            {
                object obj = XState["ValidateForms"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                XState["ValidateForms"] = value;
            }
        }

        /// <summary>
        /// 验证失败时提示对话框弹出位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("验证失败时提示对话框弹出位置")]
        public Target ValidateTarget
        {
            get
            {
                object obj = XState["ValidateTarget"];
                return obj == null ? Target.Self : (Target)obj;
            }
            set
            {
                XState["ValidateTarget"] = value;
            }
        }


        /// <summary>
        /// 验证失败时是否出现提示对话框
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("验证失败时是否出现提示对话框")]
        public bool ValidateMessageBox
        {
            get
            {
                object obj = XState["ValidateMessageBox"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["ValidateMessageBox"] = value;
            }
        }

        #endregion

        #region ConfirmText/ConfirmTitle/ConfirmIcon/ConfirmTarget

        /// <summary>
        /// [AJAX属性]确认对话框标题
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]确认对话框标题")]
        public string ConfirmTitle
        {
            get
            {
                object obj = XState["ConfirmTitle"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ConfirmTitle"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]确认对话框内容
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]确认对话框内容")]
        public string ConfirmText
        {
            get
            {
                object obj = XState["ConfirmText"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ConfirmText"] = value;
            }
        }


        /// <summary>
        /// [AJAX属性]确认对话框提示图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(MessageBoxIcon.Warning)]
        [Description("[AJAX属性]确认对话框提示图标")]
        public MessageBoxIcon ConfirmIcon
        {
            get
            {
                object obj = XState["ConfirmIcon"];
                return obj == null ? MessageBoxIcon.Warning : (MessageBoxIcon)obj;
            }
            set
            {
                XState["ConfirmIcon"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]确认对话框弹出位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Target.Self)]
        [Description("[AJAX属性]确认对话框弹出位置")]
        public Target ConfirmTarget
        {
            get
            {
                object obj = XState["ConfirmTarget"];
                return obj == null ? Target.Self : (Target)obj;
            }
            set
            {
                XState["ConfirmTarget"] = value;
            }
        }

        #endregion

        #region Menu

        private Menu _menu;

        /// <summary>
        /// 按钮的上下文菜单
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("按钮的上下文菜单")]
        public Menu Menu
        {
            get
            {
                if (_menu == null)
                {
                    _menu = new Menu();
                }
                return _menu;
            }
        }


        /*
        private MenuCollection _menus;

        /// <summary>
        /// 按钮的上下文菜单
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("按钮的上下文菜单")]
        public virtual MenuCollection Menus
        {
            get
            {
                if (_menus == null)
                {
                    _menus = new MenuCollection(this);
                }
                return _menus;
            }
        }
         * */

        #endregion

        #region CreateChildControls

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            Menu.RenderWrapperNode = false;
            Controls.Add(Menu);

            //// 添加子控件
            //foreach (Menu menu in Menus)
            //{
            //    menu.RenderWrapperDiv = false;
            //    Controls.Add(menu);
            //}
        }
        #endregion

        #region OnAjaxPreRender OnFirstPreRender

        #region PressedHiddenFieldID

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private string PressedHiddenFieldID
        {
            get
            {
                return String.Format("{0}_Pressed", ClientID);
            }
        }

        #endregion

        #region OnAjaxPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            if (PropertyModified("Text"))
            {
                sb.AppendFormat("{0}.x_setText();", XID);
            }

            if (EnablePress)
            {
                if (PropertyModified("Pressed"))
                {
                    //if (ClientPropertyModifiedInServer("Pressed"))

                    sb.AppendFormat("{0}.x_toggle();", XID);

                }
            }

            if (PropertyModified("Icon", "IconUrl"))
            {
                string resolvedIconUrl = GetResolvedIconUrl(this.Icon, IconUrl);
                if (!String.IsNullOrEmpty(resolvedIconUrl))
                {
                    sb.AppendFormat("{0}.setIcon({1});", XID, JsHelper.Enquote(resolvedIconUrl));
                }
            }

            if (PropertyModified("ToolTip"))
            {
                sb.AppendFormat("{0}.x_setTooltip();", XID);
            }

            if (PropertyModified("OnClientClick", "ConfirmTitle", "ConfirmText", "ConfirmTarget", "ConfirmIcon"))
            {
                //sb.AppendFormat("{0}.un('click', {0}.initialConfig.listeners.click);", XID);
                //sb.AppendFormat("{0}.on('click',{1});", XID, GetClickScriptFunction());

                sb.AppendFormat("{0}.setHandler({1});", XID, JsHelper.GetFunction(GetClickScript()));
            }

            AddAjaxScript(sb);
        }

        #endregion


        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            //ResourceManager.Instance.AddJavaScriptComponent("button");
            //if (Menu.Items.Count > 0)
            //{
            //    ResourceManager.Instance.AddJavaScriptComponent("menu");
            //}

            #region Properties
            if (TabIndex != null)
            {
                OB.AddProperty("tabIndex", TabIndex);
            }

            if (!String.IsNullOrEmpty(ToolTip))
            {
                OB.AddProperty("tooltip", ToolTip);
                OB.AddProperty("tooltipType", ToolTipTypeName.GetName(ToolTipType));
            }

            OB.AddProperty("text", Text);

            if (EnablePress)
            {
                OB.AddProperty("enableToggle", EnablePress);
                OB.AddProperty("pressed", Pressed);

                //hiddenFieldsScript += GetSetHiddenFieldValueScript(PressedHiddenFieldID, Pressed.ToString().ToLower());
                //string toggleScript = String.Format("function(btn,pressed){{X.util.setHiddenFieldValue('{0}',pressed);}}", PressedHiddenFieldID);
                //OB.Listeners.AddProperty(OptionName.Toggle, toggleScript, true);
            }

            if (Type != ButtonType.Button)
            {
                OB.AddProperty("type", ButtonTypeName.GetName(Type));

            }

            if (Size != ButtonSize.Small)
            {
                OB.AddProperty("scale", ButtonSizeName.GetName(Size));
            }

            #endregion

            #region Icon IconUrl

            string resolvedIconUrl = GetResolvedIconUrl(Icon, IconUrl);
            if (!String.IsNullOrEmpty(resolvedIconUrl))
            {
                // 不需要先删除原来的属性，因为在AddProperty内部已经有这个逻辑了
                OB.AddProperty("cls", CssClass + " x-btn-text-icon");
                OB.AddProperty("icon", resolvedIconUrl);

                if (IconAlign != IconAlign.Left)
                {
                    OB.AddProperty("iconAlign", IconAlignHelper.GetName(IconAlign));
                }
            }

            #endregion

            #region Click

            string clickScript = GetClickScript();
            if (!String.IsNullOrEmpty(clickScript))
            {
                OB.AddProperty("handler", JsHelper.GetFunction(clickScript), true);
            }

            #endregion

            #region oldcode

            //string clickScriptFunction = GetClickScriptFunction();
            //if (AjaxPropertyChanged("ClickScriptFunction", clickScriptFunction))
            //{
            //    string ajaxClickFunction = String.Empty;
            //    //ajaxClickFunction += String.Format("{0}.purgeListeners('click');", ClientJavascriptID);
            //    ajaxClickFunction += String.Format("{0}.un('click', X.{0}.initialConfig.listeners.click);", XID);
            //    ajaxClickFunction += String.Format("{0}.on('click',{1});", XID, clickScriptFunction);

            //    AddAjaxPropertyChangedScript(ajaxClickFunction);
            //}

            //OB.Listeners.AddProperty(OptionName.Click, String.Format("{0}_click", ClientJavascriptID), true);


            //OB.AddProperty(OptionName.Handler, "function(){alert('sss');}", true);



            //string style = String.Empty;

            //if (CssStyle == "" || !CssStyle.ToLower().Contains("display"))
            //{
            //    style += CssStyle + "display:inline;";
            //}

            //OB.RemoveProperty(OptionName.Style);
            //OB.AddProperty(OptionName.Style, style);

            //AddExtraStyle("display", "inline");

            #endregion

            #region Menu

            /*
            if (Menus.Count > 0)
            {
                // 一个Button只能由一个Menu
                OB.AddProperty("menu", String.Format("{0}", Menus[0].XID), true);
            }
             * */
            if (Menu.Items.Count > 0)
            {
                OB.AddProperty("menu", String.Format("{0}", Menu.XID), true);
            }

            #endregion

            string createScript = String.Format("var {0}=new Ext.Button({1});", XID, OB.ToString());
            AddStartupScript(createScript);
        }

        ///// <summary>
        ///// Get resolved icon url (Can be used in client side) from both Icon and IconUrl properties.
        ///// </summary>
        ///// <returns></returns>
        //private string GetResolvedIconUrl()
        //{
        //    string iconUrl = IconUrl;
        //    if (String.IsNullOrEmpty(iconUrl))
        //    {
        //        if (Icon != Icon.None)
        //        {
        //            iconUrl = IconHelper.GetIconUrl(Icon);
        //        }
        //    }

        //    return ResolveUrl(iconUrl);
        //}

        private string GetClickScript()
        {
            string disableControlJavascriptID = ClientID;
            if (!DisableControlBeforePostBack)
            {
                disableControlJavascriptID = String.Empty;
            }

            string clientScript = OnClientClick;
            if (Type == ButtonType.Reset)
            {
                clientScript += "document.forms[0].reset();";
            }

            return ResolveClientScript(ValidateForms, ValidateTarget, ValidateMessageBox, EnablePostBack, GetPostBackEventReference(),
                ConfirmText, ConfirmTitle, ConfirmIcon, ConfirmTarget, clientScript, disableControlJavascriptID);


            // e.stopEvent(); is needed, otherwise there will be an error under IE6 (modified by sanshi.ustc@gmail.com 2008-08-13)
            //return JsHelper.GetFunction(clickScript, "btn", "e");
            //return String.Format("function(button,e){{{0}e.stopEvent();}}", clickScript);
        }


        #endregion

        #region ResolveClientScript

        /// <summary>
        /// 生成按钮客户端点击事件的脚本
        /// </summary>
        /// <param name="validateForms"></param>
        /// <param name="validateTarget"></param>
        /// <param name="enablePostBack"></param>
        /// <param name="postBackEventReference"></param>
        /// <param name="confirmText"></param>
        /// <param name="confirmTitle"></param>
        /// <param name="confirmIcon"></param>
        /// <param name="confirmTarget"></param>
        /// <param name="onClientClick"></param>
        /// <param name="disableControlJavascriptID"></param>
        /// <returns></returns>
        internal static string ResolveClientScript(string[] validateForms, Target validateTarget, bool validateMessageBox, bool enablePostBack, string postBackEventReference,
            string confirmText, string confirmTitle, MessageBoxIcon confirmIcon, Target confirmTarget, string onClientClick, string disableControlJavascriptID)
        {
            // 1. validateScript
            string validateScript = String.Empty;
            if (validateForms != null && validateForms.Length > 0)
            {
                #region old code

                //StringBuilder sb = new StringBuilder();
                //sb.Append("var forms=[];");
                //foreach (string formId in validateForms)
                //{
                //    Control control = ControlUtil.FindControl(formId);
                //    if (control != null && control is ControlBase)
                //    {
                //        sb.AppendFormat("forms.push(X.{0});", (control as ControlBase).ClientJavascriptID);
                //    }
                //}
                ////sb.Append("if(!box_validForms(forms,'表单不完整','请为 “{0}” 提供有效值！')){return false;}");
                //sb.AppendFormat("var validResult=X.util.validForms(forms);if(!validResult[0]){{{0}return false;}}",
                //    Alert.GetShowReference("请为 “'+validResult[1].fieldLabel+'” 提供有效值！", "表单不完整"));

                #endregion
                JsArrayBuilder array = new JsArrayBuilder();
                foreach (string formID in validateForms)
                {
                    Control control = ControlUtil.FindControl(formID);
                    if (control != null && control is ControlBase)
                    {
                        array.AddProperty((control as ControlBase).ClientID);
                    }
                }

                validateScript = String.Format("if(!X.util.validForms({0},'{1}',{2})){{return false;}}", array.ToString(), TargetHelper.GetName(validateTarget), validateMessageBox.ToString().ToLower());
            }

            // 2. 用户自定义脚本
            string clientClickScript = onClientClick;
            if (!String.IsNullOrEmpty(clientClickScript) && !clientClickScript.EndsWith(";"))
            {
                clientClickScript += ";";
            }


            // 3. 回发脚本
            string postBackScript = String.Empty;
            if (enablePostBack)
            {
                if (!String.IsNullOrEmpty(disableControlJavascriptID))
                {
                    postBackScript += String.Format("X.disable('{0}');", disableControlJavascriptID);
                    //postBackScript += String.Format("X.util.setHiddenFieldValue('{0}','{1}');", ResourceManager.DISABLED_CONTROL_BEFORE_POSTBACK, disableControlClientId);
                    //postBackScript += String.Format("X.util.setDisabledControlBeforePostBack('{0}');", disableControlJavascriptID);
                }
                postBackScript += postBackEventReference;
            }



            if (!String.IsNullOrEmpty(confirmText))
            {
                #region old code

                // 对confirm进行处理，对<script></script>包含的内容做js代码处理
                //string confirmText = ConfirmText.Replace("'", "\"");
                //if (confirmText.Contains("<script>"))
                //{
                //    confirmText = confirmText.Replace("<script>", "'+");
                //    confirmText = confirmText.Replace("</script>", "+'");
                //}
                //confirmText = String.Format("'{0}'", confirmText);

                //JsObjectBuilder ob = new JsObjectBuilder();
                //ob.AddProperty(OptionName.Title, String.Format("'{0}'", confirmTitle), true);
                //ob.AddProperty(OptionName.Msg, String.Format("'{0}'", JsHelper.GetStringWithJsBlock(confirmText)), true);
                //ob.AddProperty(OptionName.Buttons, "Ext.MessageBox.OKCANCEL", true);
                //ob.AddProperty(OptionName.Icon, String.Format("'{0}'", MessageBoxIconName.GetName(confirmIcon)), true);
                //ob.AddProperty(OptionName.Fn, String.Format("function(btn){{if(btn=='cancel'){{return false;}}else{{{0}}}}}", postBackScript), true);

                //postBackScript = String.Format("Ext.MessageBox.show({0});", ob.ToString()); 

                #endregion
                postBackScript = Confirm.GetShowReference(confirmText, confirmTitle, confirmIcon, postBackScript, "return false;", confirmTarget);
            }




            return validateScript + clientClickScript + postBackScript;
        }


        #endregion

        #region IPostBackDataHandler

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            if (EnablePress)
            {
                bool pressed = Convert.ToBoolean(postCollection[PressedHiddenFieldID]);
                if (pressed != Pressed)
                {
                    Pressed = pressed;
                    XState.BackupPostDataProperty("Pressed");
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            // If someday we need public a OnPressChanged event, we can return ture here.
            //throw new NotImplementedException();
        }

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            OnClick(EventArgs.Empty);
        }


        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 点击按钮事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("点击按钮事件")]
        public event EventHandler Click
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


        protected virtual void OnClick(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region oldcode

        //protected override void CreateChildControls()
        //{
        //    base.CreateChildControls();

        //    //// 添加子控件
        //    //foreach (Menu menu in Menus)
        //    //{
        //    //    menu.RenderWrapperDiv = false;
        //    //    Controls.Add(menu);
        //    //}
        //}

        //#region HiddenFieldID

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //[Description("是否按下隐藏字段的ID")]
        //protected string PressedHiddenFieldID
        //{
        //    get
        //    {
        //        return String.Format("{0}_pressed", XID);
        //    }
        //}

        //#endregion

        //public Unit MarginRight_Default = Unit.Empty;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(Unit), "")]
        //[Description("右侧空白宽度")]
        //public Unit MarginRight
        //{
        //    get
        //    {
        //        object obj = BoxState["MarginRight"];
        //        return obj == null ? MarginRight_Default : (Unit)obj;
        //    }
        //    set
        //    {
        //        BoxState["MarginRight"] = value;
        //    }
        //}

        //private Unit MinWidth_Default = Unit.Empty;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(Unit), "")]
        //[Description("最小宽度")]
        //public Unit MinWidth
        //{
        //    get
        //    {
        //        object obj = BoxState["MinWidth"];
        //        return obj == null ? MinWidth_Default : (Unit)obj;
        //    }
        //    set
        //    {
        //        BoxState["MinWidth"] = value;
        //    }
        //}

        //public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        //{
        //    //if (EnablePress)
        //    //{
        //    //    string postValue = postCollection[PressedHiddenFieldID];
        //    //    bool postPressed = Convert.ToBoolean(postValue);
        //    //    if (Pressed != postPressed)
        //    //    {
        //    //        Pressed = postPressed;
        //    //        return true;
        //    //    }
        //    //}

        //    return false;
        //}

        //public void RaisePostDataChangedEvent()
        //{
        //    //throw new NotImplementedException();
        //}

        #endregion

    }
}
