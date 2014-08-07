
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    HeaderResourceHelper.cs
 * CreatedOn:   2008-05-04
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
using System.Configuration;
using System.Reflection;
using System.Web.UI;
using System.IO;
using System.Web.UI.HtmlControls;

namespace ExtAspNet
{
    internal static class CommonResourceHelper
    {
        #region static

        public static readonly string CONTROL_ID_PREFIX = "ExtAspNet_";

        //private static readonly string HeaderCommentId = HeaderControlIdPrefix + "comment";
        //private static readonly string HeaderDefaultCssId = HeaderControlIdPrefix + "ext-all-css";
        //private static readonly string HeaderGrayCssId = HeaderControlIdPrefix + "xtheme-gray-css";
        //private static readonly string HeaderExtBaseJsId = HeaderControlIdPrefix + "ext-base-js";
        //private static readonly string HeaderExtAllJsId = HeaderControlIdPrefix + "ext-all-js";



        public static readonly string COMMENT_INCLUDE_TEMPLATE = "<!-- {0} -->\r\n";
        public static readonly string SCRIPT_INCLUDE_TEMPLATE = "<script src=\"{0}\" type=\"text/javascript\"></script>\r\n";
        //public static readonly string SCRIPT_CONTENT_TEMPLATE = "\r\n<script type=\"text/javascript\">{0}</script>\r\n";
        public static readonly string STYLE_INCLUDE_TEMPLATE = "<link href=\"{0}\" rel=\"stylesheet\" text=\"text/css\"/>\r\n";
        public static readonly string STYLE_CONTENT_TEMPLATE = "<style type=\"text/css\">{0}</style>\r\n";


        #endregion

        #region RegisterCommonResource

        internal static void RegisterCommonResource(Page page)
        {
            #region comment

            // head - comment
            string descriptor = String.Format("Powered by ExtAspNet v{0} - ExtJS based ASP.NET 2.0 Controls with native AJAX support - http://extaspnet.codeplex.com/", GlobalConfig.ProductVersion);
            AddContentToHead(page, CONTROL_ID_PREFIX + "comments", String.Format(COMMENT_INCLUDE_TEMPLATE, descriptor));

            //#if DEBUG
            //            AddContentToHead(page, CONTROL_ID_PREFIX + "x_start_time", String.Format(SCRIPT_CONTENT_TEMPLATE, "var x_start_time=new Date();"));

            //#endif
            #endregion

            #region css

            //if (GlobalConfig.GetDebugMode())
            //{
            //    var themeName = ThemeHelper.GetName(PageManager.Instance.Theme);
            //    AddStylesheetIncludeToHead(page, CONTROL_ID_PREFIX + "css-" + themeName, "ExtAspNet.res.css." + themeName + ".css");
            //}
            //else
            //{
            //    var themeName = ThemeHelper.GetName(PageManager.Instance.Theme);
            //    AddStylesheetIncludeToHead(page, CONTROL_ID_PREFIX + "css-" + themeName + "-min", "ExtAspNet.res.css." + themeName + ".min.css");
            //}

            AddCssResourceToHead(page, CONTROL_ID_PREFIX + "notheme.css", "ExtAspNet.res.css.notheme.css");

            if (!String.IsNullOrEmpty(PageManager.Instance.CustomTheme))
            {
                string themePath = String.Format("{0}/css/xtheme-{1}.css", page.ResolveUrl(PageManager.Instance.CustomThemeBasePath), PageManager.Instance.CustomTheme);
                AddCssPathToHead(page, CONTROL_ID_PREFIX + "custom-theme.css", themePath);
            }
            else
            {
                var themeName = ThemeHelper.GetName(PageManager.Instance.Theme);
                AddCssResourceToHead(page, CONTROL_ID_PREFIX + themeName + ".css", "ExtAspNet.res.css." + themeName + ".css");
            }

            #endregion

            #region javascript

            AddJavascriptIncludeToPageBottom(page, "ext-core.js", "ExtAspNet.js.ext-core.js");
            AddJavascriptIncludeToPageBottom(page, "ext-foundation.js", "ExtAspNet.js.ext-foundation.js");

            List<string> components = ResourceManager.Instance.JavaScriptComponentList;
            if (components.Contains("form"))
            {
                AddJavascriptIncludeToPageBottom(page, "ext-form.js", "ExtAspNet.js.ext-form.js");
            }
            if (components.Contains("grid"))
            {
                AddJavascriptIncludeToPageBottom(page, "ext-grid.js", "ExtAspNet.js.ext-grid.js");
            }
            if (components.Contains("menu") || components.Contains("tab") || components.Contains("tree"))
            {
                AddJavascriptIncludeToPageBottom(page, "ext-menutabtree.js", "ExtAspNet.js.ext-menutabtree.js");
            }

            //foreach (string comname in new string[] { "form", "grid", "menu", "tab", "tree" })
            //{
            //    if (ResourceManager.Instance.JavaScriptComponentList.Contains(comname))
            //    {
            //        AddJavascriptIncludeToPageBottom(page, "ext-" + comname + ".js", "ExtAspNet.js.ext-" + comname + ".js");
            //    }
            //}

            if (GlobalConfig.GetDebugMode())
            {
                AddJavascriptIncludeToPageBottom(page, "x-debug.js", "ExtAspNet.js.x-debug.js");
            }
            else
            {
                AddJavascriptIncludeToPageBottom(page, "x.js", "ExtAspNet.js.x.js");
            }

            string languageName = LanguageHelper.GetName(PageManager.Instance.Language);
            AddJavascriptIncludeToPageBottom(page, languageName + ".js", "ExtAspNet.js.lang.ext-lang-" + languageName + ".js");

            #region release old code

            //LiteralControl boxPageStartTimeControl = new LiteralControl();
            //boxPageStartTimeControl.ID = "ExtAspNet-page-start-time";
            //boxPageStartTimeControl.Text = "<script type=\"text/javascript\">var boxPageStartTime=new Date();</script>";

            //page.Controls.Add(new LiteralControl("<script type=\"text/javascript\">var boxPageEndTime=new Date();</script>"));


            //if (GlobalConfig.GetDebugMode())
            //{
            //    //// 注册开始下载页面脚本的时间
            //    //page.ClientScript.RegisterStartupScript(page.GetType(), "x_start_javascript_time", String.Format(SCRIPT_CONTENT_TEMPLATE, "var x_start_javascript_time=new Date();"), false);

            //    AddJavascriptIncludeToPageBottom(page, "ext-base.js", "ExtAspNet.js.lib.ext-base.js");
            //    AddJavascriptIncludeToPageBottom(page, "ext-all.js", "ExtAspNet.js.lib.ext-all.js");
            //    AddJavascriptIncludeToPageBottom(page, "Base64.js", "ExtAspNet.js.lib.Base64.js");
            //    AddJavascriptIncludeToPageBottom(page, "json2.js", "ExtAspNet.js.lib.json2.js");
            //    AddJavascriptIncludeToPageBottom(page, "ux.js", "ExtAspNet.js.ux.ux.js");
            //    AddJavascriptIncludeToPageBottom(page, "X.js", "ExtAspNet.js.X.X.js");

            //}
            //else
            //{
            //    AddJavascriptIncludeToPageBottom(page, "ext-core.js", "ExtAspNet.js.ext-core.js");
            //    AddJavascriptIncludeToPageBottom(page, "ext-foundation.js", "ExtAspNet.js.ext-foundation.js");

            //    foreach (string comname in new string[] { "form", "grid", "menu", "tab", "tree" })
            //    {
            //        if (ResourceManager.Instance.JavaScriptComponentList.Contains(comname))
            //        {
            //            AddJavascriptIncludeToPageBottom(page, "ext-" + comname + ".js", "ExtAspNet.js.ext-" + comname + ".js");
            //        }
            //    }

            //    AddJavascriptIncludeToPageBottom(page, "x.js", "ExtAspNet.js.x.js");
            //}



            //if (pageManager.ApplyParentStyleJavascript)
            //{
            //    //LiteralControl jsControl = new LiteralControl();
            //    //jsControl.ID = "ExtAspNet-js-inline";
            //    //jsControl.Text = "<script type=\"text/javascript\">"
            //    //   + "window.eval.call(window, parent.document.getElementById(\"boxJavascriptInline\").innerHTML);"
            //    //   + "</script>";
            //    //page.Header.Controls.AddAt(GetNextControlIndex(page), jsControl);

            //    StringBuilder evalJsSB = new StringBuilder();
            //    evalJsSB.Append("<script type=\"text/javascript\">");

            //    evalJsSB.Append("var box_start_javascript_time=new Date();");
            //    evalJsSB.Append("window.eval.call(window, parent.document.getElementById(\"boxJavascriptInline\").innerHTML);");
            //    evalJsSB.Append("var box_end_javascript_time=new Date();");

            //    evalJsSB.Append("</script>");

            //    page.ClientScript.RegisterStartupScript(page.GetType(), "ExtAspNet-js-inline", evalJsSB.ToString(), false);

            //}
            //else if (pageManager.EnableInlineStyleJavascript)
            //{
            //    StringBuilder jsSB = new StringBuilder();

            //    jsSB.Append("var box_start_javascript_time=new Date();");

            //    jsSB.Append(ResourceHelper.GetResourceContent("ExtAspNet.js.ext-release.js"));

            //    if (pageManager.Language == LanguageType.CN)
            //    {
            //        jsSB.Append(ResourceHelper.GetResourceContent("ExtAspNet.js.languages.ext-lang-zh_CN.js"));
            //    }
            //    else if (pageManager.Language == LanguageType.TW)
            //    {
            //        jsSB.Append(ResourceHelper.GetResourceContent("ExtAspNet.js.languages.ext-lang-zh_TW.js"));
            //    }

            //    jsSB.Append("var box_end_javascript_time=new Date();");

            //    //LiteralControl jsControl = new LiteralControl();
            //    //jsControl.ID = "ExtAspNet-js-inline";
            //    //jsControl.Text = String.Format("<script type=\"text/javascript\" id=\"boxJavascriptInline\">{0}</script>", jsSB);
            //    //page.Header.Controls.AddAt(GetNextControlIndex(page), jsControl);

            //    page.ClientScript.RegisterStartupScript(page.GetType(), "ExtAspNet-js-inline",
            //       "<script type=\"text/javascript\" id=\"boxJavascriptInline\">" + jsSB.ToString() + "</script>", false);
            //}
            //else
            //{

            //}

            #endregion

            #endregion
        }

        #endregion

        #region add script to head methods

        /// <summary>
        /// 添加JS文件到页面的底部
        /// </summary>
        /// <param name="page"></param>
        /// <param name="controlId"></param>
        /// <param name="resourceName"></param>
        public static void AddJavascriptIncludeToPageBottom(Page page, string controlId, string resourceName)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered(controlId))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), controlId, String.Format(SCRIPT_INCLUDE_TEMPLATE, ResourceHelper.GetWebResourceUrl(page, resourceName)), false);
            }

            //if (!IsHeaderContains(page, controlId))
            //{
            //    LiteralControl control = new LiteralControl();
            //    control.ID = controlId;
            //    control.Text = String.Format(SCRIPT_INCLUDE_TEMPLATE, ResourceHelper.GetWebResourceUrl(page, resourceName));

            //    page.Header.Controls.AddAt(GetNextControlIndex(page), control);
            //}
        }

        public static void AddCssPathToHead(Page page, string controlId, string cssPath)
        {
            if (!IsHeaderContains(page, controlId))
            {
                LiteralControl control = new LiteralControl();
                control.ID = controlId;
                control.Text = String.Format(STYLE_INCLUDE_TEMPLATE, cssPath);

                page.Header.Controls.AddAt(GetNextControlIndex(page), control);
            }
        }

        /// <summary>
        /// 添加样式表到页头
        /// </summary>
        /// <param name="controlId"></param>
        /// <param name="resourceName"></param>
        public static void AddCssResourceToHead(Page page, string controlId, string resourceName)
        {
            AddCssPathToHead(page, controlId, ResourceHelper.GetWebResourceUrl(page, resourceName));
        }

        public static void AddCssContentToHead(Page page, string controlId, string cssContent)
        {
            if (!IsHeaderContains(page, controlId))
            {
                LiteralControl control = new LiteralControl();
                control.ID = controlId;
                control.Text = String.Format(STYLE_CONTENT_TEMPLATE, cssContent);

                page.Header.Controls.AddAt(GetNextControlIndex(page), control);
            }
        }

        /// <summary>
        /// 向页面头部添加内容
        /// </summary>
        /// <param name="page"></param>
        /// <param name="controlId"></param>
        /// <param name="msg"></param>
        public static void AddContentToHead(Page page, string controlId, string msg)
        {
            if (!IsHeaderContains(page, controlId))
            {
                LiteralControl control = new LiteralControl();
                control.ID = controlId;
                control.Text = msg;

                page.Header.Controls.AddAt(GetNextControlIndex(page), control);
                //page.Header.Controls.Add(control);
            }
        }

        /// <summary>
        /// 页头是否包含控件
        /// </summary>
        /// <param name="controlId"></param>
        /// <returns></returns>
        public static bool IsHeaderContains(Page page, string controlId)
        {
            foreach (Control c in page.Header.Controls)
            {
                if (c.ID != null && c.ID == controlId)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 取得下一个控件的位置
        /// </summary>
        /// <returns></returns>
        private static int GetNextControlIndex(Page page)
        {
            int index = 0;

            // 如果存在自定义（以HeaderControlIdPrefix开头）的控件，则返回最后一个自定义控件的下一个位置
            // 如果不存在自定义的控件，则返回<title>的下一个位置
            bool startControlBlock = false;
            int titleIndex = 0;
            foreach (Control c in page.Header.Controls)
            {
                if (c.ID != null && c.ID.StartsWith(CONTROL_ID_PREFIX))
                {
                    if (c is HtmlTitle)
                    {
                        titleIndex = index;
                    }

                    startControlBlock = true;
                }
                else
                {
                    if (startControlBlock)
                    {
                        break;
                    }
                }

                index++;
            }

            return startControlBlock ? index : titleIndex + 1;
        }

        ///// <summary>
        ///// 取得Comment控件的位置（默认在title的下面）
        ///// </summary>
        ///// <returns></returns>
        //private static int GetCommentControlIndex(Page page)
        //{
        //    int index = 0;

        //    bool isFindTitle = false;
        //    foreach (Control c in page.Header.Controls)
        //    {
        //        if (c is System.Web.UI.HtmlControls.HtmlTitle)
        //        {
        //            isFindTitle = true;
        //            break;
        //        }

        //        index++;
        //    }

        //    return isFindTitle ? ++index : 0;
        //}
        #endregion

        #region RegisterHeaderCSS

        public static void RegisterHeaderCSS(Page page, string cssContent)
        {
            string controlId = CONTROL_ID_PREFIX + "user_defined_css";
            if (!IsHeaderContains(page, controlId))
            {
                AddCssContentToHead(page, controlId, cssContent);
            }
        }

        #endregion
    }
}
