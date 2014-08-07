
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    PageContext.cs
 * CreatedOn:   2008-06-09
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      -> 什么是PageStateChanged？（表单中任何一个字段发生改变，则页面状态PageState就改变了）
 *      PageStateChanged 更改为 FormChanged 
 *      sanshi.ustc@gmail.com 2009-02-26
 *      
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

namespace ExtAspNet
{
    /// <summary>
    /// 页面上下文帮助类（静态类），包括向页面注册脚本、刷新当前页面、页面重定向等实用函数
    /// </summary>
    public static class PageContext
    {
        #region static readonly

        //private static readonly string PAGE_STATE_CHANGED_FUNCTION_NAME = "X.box_pageStateChanged";

        #endregion

        #region Redirect

        /// <summary>
        /// 跳转到指定的Url
        /// </summary>
        /// <param name="url"></param>
        public static void Redirect(string url)
        {
            Redirect(url, "_self");
        }

        /// <summary>
        /// 跳转到指定的Url，Target指定在哪个窗口中跳转（_self,_parent,_top）
        /// </summary>
        /// <param name="url"></param>
        /// <param name="target">_self,_parent,_top</param>
        public static void Redirect(string url, string target)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                url = page.ResolveUrl(url);
            }

            string redirectScript = String.Empty;
            switch (target.ToLower())
            {
                case "_parent":
                    redirectScript = String.Format("parent.window.location.href='{0}';", url);
                    break;
                case "_top":
                    redirectScript = String.Format("top.window.location.href='{0}';", url);
                    break;
                default:
                    redirectScript = String.Format("window.location.href='{0}';", url);
                    break;
            }

            RegisterStartupScript(redirectScript);


            //if (ResourceManager.Instance.IsExtAspNetAjaxPostBack)
            //{
            //    RegisterStartupScript(redirectScript);
            //}
            //else
            //{
            //    page.ClientScript.RegisterStartupScript(page.GetType(), "redirect", redirectScript, true);
            //}

            //if (ResourceManager.Instance.IsExtAspNetAjaxPostBack)
            //{
            //    HttpContext.Current.Response.RedirectLocation = url;
            //}
            //else
            //{
            //    HttpContext.Current.Response.Redirect(url);
            //}
            


        }

        #endregion

        #region Refresh

        public static void Refresh()
        {
            Refresh("_self");
        }

        public static void Refresh(string target)
        {
            
            string refreshScript = String.Empty;
            switch (target.ToLower())
            {
                case "_parent":
                    refreshScript = "parent.window.location.reload();";
                    break;
                case "_top":
                    refreshScript = "top.window.location.reload();";
                    break;
                default:
                    refreshScript = "window.location.reload();";
                    break;
            }

            RegisterStartupScript(refreshScript);
        }

        #endregion

        #region RegisterStartupScript

        #region old code

        ///// <summary>
        ///// 是否独占的脚本，将禁止页面元素的渲染
        ///// </summary>
        ///// <param name="scriptContent"></param>
        //public static void RegisterExclusiveScript(string scriptContent)
        //{
        //    Page page = HttpContext.Current.CurrentHandler as Page;
        //    if (page != null)
        //    {
        //        ResourceManager.Instance.SetExclusiveScript(scriptContent);
        //    }

        //}

        //public static void RegisterStartupScript(string scriptContent, bool preRegister)
        //{
        //    if (preRegister)
        //    {
        //        RegisterStartupScript(scriptContent, -100);
        //    }
        //    else
        //    {
        //        RegisterStartupScript(scriptContent);
        //    }
        //}

        ///// <summary>
        ///// 注册页面加载后的JS脚本
        ///// Level 层次（层次越高，注册越靠后）（缺省100），负值表示在所有注册脚本之前执行
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="scriptContent"></param>
        //public static void RegisterStartupScript(string scriptContent, int level)
        //{
        //    Page page = HttpContext.Current.CurrentHandler as Page;
        //    if (page != null)
        //    {
        //        ResourceManager.Instance.AddAbsoluteStartupScript(scriptContent, level);
        //    }
        //} 

        #endregion

        /// <summary>
        /// 注册页面加载后的JS脚本
        /// </summary>
        /// <param name="page"></param>
        /// <param name="scriptContent"></param>
        public static void RegisterStartupScript(string scriptContent)
        {
            //Page page = HttpContext.Current.CurrentHandler as Page;
            //if (page != null)
            //{
            //    ResourceManager.Instance.AddAbsoluteStartupScript(scriptContent);
            //}
            ResourceManager manager = ResourceManager.Instance;
            if (manager.IsExtAspNetAjaxPostBack)
            {
                manager.AjaxAbsoluteScriptList.Add(scriptContent);
            }
            else
            {
                manager.AddAbsoluteStartupScript(scriptContent);
            }
        }

        #endregion

        #region old code


        ///// <summary>
        ///// 获取当前页面中表单修改的确认提示框的脚本
        ///// </summary>
        ///// <returns></returns>
        //public static string GetConfirmFormModifiedReference()
        //{
        //    //return String.Format("{0}();", PAGE_STATE_CHANGED_FUNCTION_NAME);
        //    return "X.wnd.confirmFormModified();";
        //}

        //public static void RegisterPageStateChangedStartupScript()
        //{
        //    string confirmText = "是否确认关闭当前页？<br/>您在当前页所做的修改没有保存。继续编辑当前页，请选择“取消”。<br/>选择“确定”关闭当前页，选择“取消”继续编辑当前页。";

        //    RegisterPageStateChangedStartupScript(confirmText);
        //}

        //public static void RegisterPageStateChangedStartupScript(string confirmText)
        //{
        //    string okScript = CurrentActiveWindow.GetCloseReference();
        //    string cancelScript = "return false;";

        //    RegisterPageStateChangedStartupScript(confirmText, okScript, cancelScript);
        //}

        ///// <summary>
        ///// PageManager 的一个属性
        ///// </summary>
        ///// <param name="page"></param>
        ///// <param name="scriptContent"></param>
        //public static void RegisterPageStateChangedStartupScript(string confirmText, string okScript, string cancelScript)
        //{
        //    string pageStateChangeScript = PageContext.GetPageStateChangedConfirmReference("确认关闭", confirmText, okScript, cancelScript);

        //    string scriptContent = String.Format("{0}={1};", PAGE_STATE_CHANGED_FUNCTION_NAME, JsHelper.GetFunctionWrapper(pageStateChangeScript));

        //    RegisterStartupScript(scriptContent);
        //}



        ///// <summary>
        ///// 页面状态已经变化的提示信息
        ///// </summary>
        ///// <param name="alertMsg"></param>
        ///// <returns></returns>
        //private static string GetPageStateChangedReference()
        //{
        //    return "X.util.isPageStateChanged();";
        //}

        ///// <summary>
        ///// 页面状态已经变化的提示信息
        ///// </summary>
        ///// <param name="alertMsg"></param>
        ///// <returns></returns>
        //private static string GetPageStateChangedConfirmReference(string confirmTitle, string confirmMsg, string okScript, string cancelScript)
        //{
        //    // okScript 和 notChangeScript 一样
        //    return GetPageStateChangedConfirmReference(confirmTitle, confirmMsg, okScript, cancelScript, okScript);
        //}

        ///// <summary>
        ///// 页面状态已经变化的提示信息
        ///// </summary>
        ///// <param name="alertMsg"></param>
        ///// <returns></returns>
        //private static string GetPageStateChangedConfirmReference(string confirmTitle, string confirmMsg, string okScript, string cancelScript, string notChangeScript)
        //{
        //    //string closeScript = notChangeScript;
        //    //string confirmScript = ExtAspNet.Confirm.GetShowReference(confirmMsg, confirmTitle, ExtAspNet.MessageBoxIcon.Question, "return false;", closeScript);
        //    //btnClose.OnClientClick = String.Format("if({0}){{{1}}}else{{{2}}}", ExtAspNet.PageContext.GetPageStateChangedReference(), confirmScript, closeScript);

        //    string confirmScript = Confirm.GetShowReference(confirmMsg, confirmTitle, MessageBoxIcon.Warning, okScript, cancelScript);
        //    return String.Format("if({0}){{{1}}}else{{{2}}}", GetPageStateChangedReference(), confirmScript, notChangeScript);
        //}

        #endregion

    }
}
