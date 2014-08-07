
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    PageLoading.cs
 * CreatedOn:   2008-05-15
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
using System.Text;
using System.Web.UI;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design;

namespace ExtAspNet
{
    //[Designer(typeof(PageLoadingDesigner))]
    [ToolboxData("<{0}:PageLoading runat=server></{0}:PageLoading>")]
    [ToolboxBitmap(typeof(PageLoading), "res.toolbox.PageLoading.bmp")]
    [Description("")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class PageLoading : ControlBase
    {
        #region static readonly

        internal static readonly string LOADING_TEMLATE = "<div id='loading-mask'></div><div id='loading'><div class='loading-indicator'><img align='absmiddle' src='#LOADING_IMAGE_SRC#'/></div></div>";

        internal static readonly string LOADING_IMAGE_NAME = "ExtAspNet.res.images.loading_32.gif";

        #endregion

        #region Properties

        
        /// <summary>
        /// 自定义的加载图片
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("自定义的加载图片")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string ImageUrl
        {
            get
            {
                object obj = XState["ImageUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ImageUrl"] = value;
            }
        }


        
        /// <summary>
        /// 回发时是否显示
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("回发时是否显示")]
        public bool ShowOnPostBack
        {
            get
            {
                object obj = XState["ShowOnPostBack"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["ShowOnPostBack"] = value;
            }
        }


        /// <summary>
        /// 是否启用淡出效果
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用淡出效果")]
        public bool EnableFadeOut
        {
            get
            {
                object obj = XState["EnableFadeOut"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableFadeOut"] = value;
            }
        }


        #endregion

        #region RenderBeginTag/RenderEndTag

        protected override void RenderBeginTag(HtmlTextWriter writer)
        {
            //base.RenderBeginTag(writer);

            if (!Page.IsPostBack || (Page.IsPostBack && ShowOnPostBack))
            {
                string content = LOADING_TEMLATE;

                string imageUrl = String.Empty;
                if (String.IsNullOrEmpty(ImageUrl))
                {
                    imageUrl = ResourceHelper.GetWebResourceUrl(Page, LOADING_IMAGE_NAME);
                }
                else
                {
                    imageUrl = this.ResolveUrl(ImageUrl);
                }

                content = content.Replace("#LOADING_IMAGE_SRC#", imageUrl);

                writer.Write(content);

            }

            
        }

        protected override void RenderEndTag(HtmlTextWriter writer)
        {

            //base.RenderEndTag(writer);
        }
        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Readonly"))
            //{
            //    sb.AppendFormat("{0}.setReadOnly({1});", XID, Readonly.ToString().ToLower());
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            if (!Page.IsPostBack || (Page.IsPostBack && ShowOnPostBack))
            {
                string jsContent = String.Empty;

                jsContent = String.Format("X.util.removePageLoading({0});", EnableFadeOut.ToString().ToLower());
                //if (EnableFadeOut)
                //{
                //    jsContent = "Ext.get('loading').remove();Ext.get('loading-mask').fadeOut({remove:true});";
                //}
                //else
                //{
                //    jsContent = "Ext.get('loading').remove();Ext.get('loading-mask').remove();";
                //    //jsContent = JsHelper.GetSetTimeoutFunction(jsContent, 10, "box");
                //}

                //jsContent += "\r\n";
                //jsContent += "\r\n";

                AddStartupAbsoluteScript(jsContent, 50);
            }
        }

        #endregion
    }
}
