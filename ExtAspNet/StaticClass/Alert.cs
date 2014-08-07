
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Alert.cs
 * CreatedOn:   2008-04-07
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2008-04-11    sanshi.ustc@gmail.com  
 *      ->2008-04-30    sanshi.ustc@gmail.com    改为静态帮助类
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
    /// 提示对话框帮助类（静态类）
    /// </summary>
    public static class Alert
    {
        #region old code
        //#region Properties

        //private bool _hideDesign = false;
        //[Category(CategoryName.DESIGN_TIME)]
        //[DefaultValue(false)]
        //[Description("在设计视图中隐藏")]
        //public bool HideDesign
        //{
        //    get
        //    {
        //        return _hideDesign;
        //    }
        //    set
        //    {
        //        _hideDesign = value;
        //    }
        //}

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("")]
        //[Description("消息内容")]
        //public string Message
        //{
        //    get
        //    {
        //        string s = (string)BoxState["Message"];
        //        return ((s == null) ? String.Empty : s);
        //    }

        //    set
        //    {
        //        BoxState["Message"] = value;
        //    }
        //}

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue("提示")]
        //[Description("标题")]
        //public string Title
        //{
        //    get
        //    {
        //        string s = (string)BoxState["Title"];
        //        return (s == null) ? "提示" : s;
        //    }

        //    set
        //    {
        //        BoxState["Title"] = value;
        //    }
        //}

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(MessageBoxIcon.Information)]
        //[Description("图标")]
        //public MessageBoxIcon Icon
        //{
        //    get
        //    {
        //        object icon = BoxState["Icon"];
        //        return icon == null ? MessageBoxIcon.Information : (MessageBoxIcon)icon;
        //    }

        //    set
        //    {
        //        BoxState["Icon"] = value;
        //    }
        //}
        //#endregion

        //#region RenderBeginTag/RenderEndTag

        //public override void RenderBeginTag(HtmlTextWriter writer)
        //{

        //}

        //public override void RenderEndTag(HtmlTextWriter writer)
        //{

        //} 
        //#endregion

        #endregion

        #region public static

        public static MessageBoxIcon DefaultIcon = MessageBoxIcon.Information;

        #endregion

        #region Show

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message"></param>
        public static void Show(string message)
        {
            Show(message, String.Empty, DefaultIcon, String.Empty);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void Show(string message, string title)
        {
            Show(message, title, DefaultIcon, String.Empty);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        public static void Show(string message, MessageBoxIcon icon)
        {
            Show(message, String.Empty, icon, String.Empty);
        }

        public static void Show(string message, string title, string okScript)
        {
            Show(message, title, DefaultIcon, okScript);
        }

        public static void Show(string message, string title, MessageBoxIcon icon)
        {
            Show(message, title, DefaultIcon, String.Empty);
        }

        /// <summary>
        /// 显示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        public static void Show(string message, string title, MessageBoxIcon icon, string okScript)
        {
            PageContext.RegisterStartupScript(GetShowReference(message, title, icon, okScript));
        }
        #endregion

        #region ShowInParent

        /// <summary>
        /// 在父页面中显示消息框
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInParent(string message)
        {
            ShowInParent(message, String.Empty, DefaultIcon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowInParent(string message, string title)
        {
            ShowInParent(message, title, DefaultIcon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        public static void ShowInParent(string message, MessageBoxIcon icon)
        {
            ShowInParent(message, String.Empty, icon, String.Empty);
        }

        public static void ShowInParent(string message, string title, string okScript)
        {
            ShowInParent(message, title, DefaultIcon, okScript);
        }

        public static void ShowInParent(string message, string title, MessageBoxIcon icon)
        {
            ShowInParent(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 在父页面中显示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        public static void ShowInParent(string message, string title, MessageBoxIcon icon, string okScript)
        {
            PageContext.RegisterStartupScript(GetShowInParentReference(message, title, icon, okScript));
        }

        #endregion

        #region ShowInTop

        /// <summary>
        /// 在顶层窗口中显示消息框
        /// </summary>
        /// <param name="message"></param>
        public static void ShowInTop(string message)
        {
            ShowInTop(message, String.Empty, DefaultIcon, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void ShowInTop(string message, string title)
        {
            ShowInTop(message, title, DefaultIcon, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="icon"></param>
        public static void ShowInTop(string message, MessageBoxIcon icon)
        {
            ShowInTop(message, String.Empty, icon, String.Empty);
        }

        public static void ShowInTop(string message, string title, string okScript)
        {
            ShowInTop(message, title, DefaultIcon, okScript);
        }

        public static void ShowInTop(string message, string title, MessageBoxIcon icon)
        {
            ShowInTop(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 在顶层窗口中显示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="icon"></param>
        public static void ShowInTop(string message, string title, MessageBoxIcon icon, string okScript)
        {
            PageContext.RegisterStartupScript(GetShowInTopReference(message, title, icon, okScript));
        }

        #endregion

        #region GetShowReference

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message)
        {
            return GetShowReference(message, String.Empty, DefaultIcon);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title)
        {
            return GetShowReference(message, title, DefaultIcon);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, MessageBoxIcon icon)
        {
            return GetShowReference(message, String.Empty, icon);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowReference(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, string okScript)
        {
            return GetShowReference(message, title, DefaultIcon, okScript);
        }

        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon, string okScript)
        {
            return GetShowReference(message, title, icon, okScript, Target.Self);
        }


        /// <summary>
        /// 获取显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <param name="target">显示对话框的目标页面</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowReference(string message, string title, MessageBoxIcon icon, string okScript, Target target)
        {
            #region oldcode

            //Ext.MessageBox.show({
            //           title: 'Icon Support',
            //           msg: 'Here is a message with an icon!',
            //           buttons: Ext.MessageBox.OK,
            //           animEl: 'mb9',
            //           fn: showResult,
            //           icon: Ext.get('icons').dom.value
            //       });

            //string msgBoxScript = "var msgBox=Ext.MessageBox;";
            //msgBoxScript += "if(parent!=window){msgBox=parent.window.Ext.MessageBox;}";

            //title = title.Replace("\r\n", "<br/>").Replace("\n", "<br/>");
            //message = message.Replace("\r\n", "<br/>").Replace("\n", "<br/>");

            //JsObjectBuilder ob = new JsObjectBuilder();
            //ob.AddProperty(OptionName.Title, String.Format("'{0}'", title), true);
            //ob.AddProperty(OptionName.Msg, String.Format("'{0}'", message), true);
            //ob.AddProperty(OptionName.Buttons, "Ext.MessageBox.OK", true);
            //ob.AddProperty(OptionName.Icon, String.Format("'{0}'", MessageBoxIconName.GetName(icon)), true);

            //return String.Format("box_getMessageBox({0}).show({1});", windowInstance, ob.ToString());

            #endregion

            if (title == null)
            {
                title = String.Empty;
            }

            message = message.Replace("\r\n", "\n").Replace("\n", "<br/>");
            title = title.Replace("\r\n", "\n").Replace("\n", "<br/>");
            string targetScript = "window";
            if (target != Target.Self)
            {
                targetScript = TargetHelper.GetScriptName(target);
            }

            if (String.IsNullOrEmpty(title) && icon == DefaultIcon && String.IsNullOrEmpty(okScript))
            {
                return String.Format("{0}.X.alert({1});", targetScript, JsHelper.GetJsString(message));
            }
            else
            {
                return String.Format("{0}.X.alert({1},{2},{3},{4});",
                    targetScript,
                    JsHelper.GetJsStringWithScriptTag(message),
                    JsHelper.GetJsString(title),
                    MessageBoxIconHelper.GetName(icon),
                    String.IsNullOrEmpty(okScript) ? "''" : JsHelper.GetFunction(okScript));
            }
        }
        #endregion

        #region GetShowInParentReference

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message)
        {
            return GetShowInParentReference(message, String.Empty, DefaultIcon);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title)
        {
            return GetShowInParentReference(message, title, DefaultIcon);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, MessageBoxIcon icon)
        {
            return GetShowInParentReference(message, String.Empty, icon);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowInParentReference(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, string okScript)
        {
            return GetShowInParentReference(message, title, DefaultIcon, okScript);
        }

        /// <summary>
        /// 获取在父页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInParentReference(string message, string title, MessageBoxIcon icon, string okScript)
        {
            return GetShowReference(message, title, icon, okScript, Target.Parent);
        }
        #endregion

        #region GetShowInTopReference

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message)
        {
            return GetShowInTopReference(message, String.Empty, DefaultIcon);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title)
        {
            return GetShowInTopReference(message, title, DefaultIcon);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, MessageBoxIcon icon)
        {
            return GetShowInTopReference(message, String.Empty, icon);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, MessageBoxIcon icon)
        {
            return GetShowInTopReference(message, title, icon, String.Empty);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, string okScript)
        {
            return GetShowInTopReference(message, title, DefaultIcon, okScript);
        }

        /// <summary>
        /// 获取在最上层页面中显示提示对话框的客户端脚本
        /// </summary>
        /// <param name="message">对话框消息</param>
        /// <param name="title">对话框标题</param>
        /// <param name="icon">对话框图标</param>
        /// <param name="okScript">点击确定按钮执行的客户端脚本</param>
        /// <returns>客户端脚本</returns>
        public static string GetShowInTopReference(string message, string title, MessageBoxIcon icon, string okScript)
        {
            return GetShowReference(message, title, icon, okScript, Target.Top);
        }
        #endregion

    }
}
