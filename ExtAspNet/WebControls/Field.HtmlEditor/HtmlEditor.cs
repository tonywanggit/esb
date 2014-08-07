
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    HtmlEditor.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2008-04-11    sanshi.ustc@gmail.com  
 *      ->2008-04-28    改名为 HtmlEditor
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

namespace ExtAspNet
{
    /// <summary>
    /// HTML编辑框控件
    /// </summary>
    [Designer(typeof(HtmlEditorDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:HtmlEditor Label=\"Label\" Text=\"\" Height=\"250px\" runat=server></{0}:HtmlEditor>")]
    [ToolboxBitmap(typeof(HtmlEditor), "res.toolbox.HtmlEditor.bmp")]
    [Description("HTML编辑框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class HtmlEditor : Field, IPostBackDataHandler
    {
        #region Constructor

        public HtmlEditor()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("Text");
        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Enabled
        {
            get
            {
                return true;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Readonly
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// [AJAX属性]文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("[AJAX属性]文本")]
        public virtual string Text
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
        /// 启用左右定位
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用左右定位")]
        public bool EnableAlignments
        {
            get
            {
                object obj = XState["EnableAlignments"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableAlignments"] = value;
            }
        }

        /// <summary>
        /// 启用颜色
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用颜色")]
        public bool EnableColors
        {
            get
            {
                object obj = XState["EnableColors"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableColors"] = value;
            }
        }


        /// <summary>
        /// 启用字体
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用字体")]
        public bool EnableFont
        {
            get
            {
                object obj = XState["EnableFont"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableFont"] = value;
            }
        }


        /// <summary>
        /// 启用调整字体大小
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用调整字体大小")]
        public bool EnableFontSize
        {
            get
            {
                object obj = XState["EnableFontSize"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableFontSize"] = value;
            }
        }


        /// <summary>
        /// 启用格式化
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用格式化")]
        public bool EnableFormat
        {
            get
            {
                object obj = XState["EnableFormat"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableFormat"] = value;
            }
        }


        /// <summary>
        /// 启用创建链接
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用创建链接")]
        public bool EnableLinks
        {
            get
            {
                object obj = XState["EnableLinks"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableLinks"] = value;
            }
        }


        /// <summary>
        /// 启用创建列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用创建列表")]
        public bool EnableLists
        {
            get
            {
                object obj = XState["EnableLists"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableLists"] = value;
            }
        }


        /// <summary>
        /// 启用源码视图
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用源码视图")]
        public bool EnableSourceEdit
        {
            get
            {
                object obj = XState["EnableSourceEdit"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableSourceEdit"] = value;
            }
        }


        /// <summary>
        /// 字体列表
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("字体列表")]
        //[Editor("System.Web.UI.Design.WebControls.DataFieldEditor", typeof(UITypeEditor))]
        [TypeConverter(typeof(StringArrayConverter))]
        public string[] FontFamilies
        {
            get
            {
                object obj = XState["FontFamilies"];
                return obj == null ? null : (string[])obj;
            }
            set
            {
                XState["FontFamilies"] = value;
            }
        }

        /// <summary>
        /// 启用中文字体
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(true)]
        [Description("启用中文字体")]
        public bool EnableChineseFont
        {
            get
            {
                object obj = XState["EnableChineseFont"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                XState["EnableChineseFont"] = value;
            }
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("Text"))
            {
                sb.AppendFormat("{0}.x_setValue();", XID);
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            // Color需要菜单组件的支持
            if (EnableColors)
            {
                ResourceManager.Instance.AddJavaScriptComponent("menu");
            }

            if (!EnableAlignments) OB.AddProperty("enableAlignments", false);
            if (!EnableColors) OB.AddProperty("enableColors", false);
            if (!EnableFont) OB.AddProperty("enableFont", false);
            if (!EnableFontSize) OB.AddProperty("enableFontSize", false);
            if (!EnableFormat) OB.AddProperty("enableFormat", false);
            if (!EnableLinks) OB.AddProperty("enableLinks", false);
            if (!EnableLists) OB.AddProperty("enableLists", false);
            if (!EnableSourceEdit) OB.AddProperty("enableSourceEdit", false);

            #region Fonts

            string[] fonts = null;
            if (EnableChineseFont)
            {
                fonts = new string[] { "宋体", "黑体", "仿宋", "楷体", "隶书", "幼圆", "Arial", "Courier New", "Tahoma", "Times New Roman", "Verdana" };
            }
            else if (FontFamilies != null)
            {
                fonts = FontFamilies;
            }

            if (fonts != null && fonts.Length > 0)
            {
                JsArrayBuilder ab = new JsArrayBuilder();
                foreach (string fontName in fonts)
                {
                    ab.AddProperty(fontName);
                }

                OB.AddProperty("fontFamilies", ab);
            }

            #endregion

            if (!String.IsNullOrEmpty(Text))
            {
                OB.AddProperty("value", Text);
            }

            string jsContent = String.Format("var {0}=new Ext.form.HtmlEditor({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// 回发到服务器，判断控件的属性是否变化，
        /// 如果变化返回true，则RaisePostDataChangedEvent
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string postValue = postCollection[UniqueID];

            //// Extjs4.0.1 没能正确的设置 htmleditor 的提交隐藏字段，这个在更高版本中可能要删除
            //string postValue = postCollection[ClientID + "_Text"];

            if (postValue != null && Text != postValue)
            {
                Text = postValue;
                XState.BackupPostDataProperty("Text");
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 文本发生变化
        /// </summary>
        public event EventHandler TextChanged
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

        private object _handlerKey = new object();

        protected virtual void OnTextChanged(EventArgs e)
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
        public void RaisePostDataChangedEvent()
        {
            OnTextChanged(EventArgs.Empty);
        }

        #endregion
    }
}
