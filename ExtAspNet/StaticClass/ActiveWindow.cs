
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    CurrentActiveWindow.cs
 * CreatedOn:   2008-06-18 22:30
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
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
    /// 当前活动窗体帮助类（静态类）
    /// </summary>
    public static class ActiveWindow
    {
        #region old code

        // aw = aw
        //private static readonly string ACTIVE_WINDOW_SCRIPT = "if(!aw){var aw=parent.window.X.window_default_group.getActive();}";
        //private static readonly string ACTIVE_WINDOW_SCRIPT = "var parentClientID=box_getParentClientIdFromUrl();if(parentClientID){var window2=parent.window;var aw=parent.window.Ext.getCmp(parentClientID);if(aw.box_property_frame_element_name){window2=parent.Ext.query('iframe[name='+aw.box_property_frame_element_name+']')[0].contentWindow;aw=eval('window2.X.'+aw.id);}}";
        //private static readonly string ACTIVE_WINDOW_SCRIPT = "var aw=X.wnd.getActiveWindow();";

        #endregion

        #region GetWriteBackValueReference


        /// <summary>
        /// 获取将values值写回控件的客户端脚本
        /// </summary>
        /// <param name="values">需要写回的字符串列表</param>
        /// <returns>客户端脚本</returns>
        public static string GetWriteBackValueReference(params string[] values)
        {
            #region old code

            //// 去除重复的 ACTIVE_WINDOW_SCRIPT
            //if (controlClientIds.Contains(ACTIVE_WINDOW_SCRIPT))
            //{
            //    controlClientIds = controlClientIds.Replace(ACTIVE_WINDOW_SCRIPT, "");
            //}

            //// 此时 controlClientId 是个字符串 或者是 是个字符串的数组，里面是需要赋值的文本框的ClientID
            //StringBuilder sb = new StringBuilder();
            //sb.Append(ACTIVE_WINDOW_SCRIPT);
            //sb.AppendFormat("var controlClientIds={0};", controlClientIds);

            //sb.AppendFormat("if(typeof(controlClientIds)=='string'){{{0}}}", "aw[1].Ext.getCmp(controlClientIds).setValue(" + JsHelper.Enquote(value) + ");");

            //// values
            //StringBuilder valuesBuilder = new StringBuilder();
            //if (values.Length > 0)
            //{
            //    valuesBuilder.AppendFormat("var controlValues={0};", JsHelper.GetJsStringArray(values));
            //    valuesBuilder.Append("var controlCount=Math.min(controlClientIds.length-1,controlValues.length);");

            //    valuesBuilder.AppendFormat("for(var i=0;i<controlCount;i++){{{0}}}", "aw[1].Ext.getCmp(controlClientIds[i+1]).setValue(controlValues[i]);");
            //}


            //sb.AppendFormat("else{{{0}{1}}}", "aw[1].Ext.getCmp(controlClientIds[0]).setValue(" + JsHelper.Enquote(value) + ");", valuesBuilder.ToString());
            //return sb.ToString(); 

            #endregion

            return String.Format("X.wnd.writeBackValue.apply(window,{0});", JsHelper.GetJsStringArray(values));

        }

        #endregion

        #region GetHideReference/GetHideRefreshReference/GetHidePostBackReference

        /// <summary>
        /// 获取关闭当前激活窗体的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public static string GetHideReference()
        {
            return "(function(){var aw=X.wnd.getActiveWindow();if(aw){aw[0].box_hide();}})();";
        }

        /// <summary>
        /// 获取关闭当前激活窗体并刷新父页面的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public static string GetHideRefreshReference()
        {
            //return ACTIVE_WINDOW_SCRIPT + "if(aw){eval('aw[1].X.'+aw[0].id+'_hide_refresh();');}";
            //return ACTIVE_WINDOW_SCRIPT + "if(aw){aw[0].box_hide_refresh();}";
            return "(function(){var aw=X.wnd.getActiveWindow();if(aw){aw[0].box_hide_refresh();}})();";
        }

        /// <summary>
        /// 获取关闭当前激活窗体并回发父页面的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public static string GetHidePostBackReference()
        {
            //return ACTIVE_WINDOW_SCRIPT + "if(aw){eval('aw[1].X.'+aw[0].id+'_hide_postback();');}";
            //return ACTIVE_WINDOW_SCRIPT + "if(aw){aw[0].box_hide_postback();}";
            return "(function(){var aw=X.wnd.getActiveWindow();if(aw){aw[0].box_hide_postback();}})();";
        }

        /// <summary>
        /// 获取关闭当前激活窗体并回发父页面的客户端脚本
        /// </summary>
        /// <param name="argument">回发参数</param>
        /// <returns>客户端脚本</returns>
        public static string GetHidePostBackReference(string argument)
        {
            //return ACTIVE_WINDOW_SCRIPT + "if(aw){eval('aw[1].X.'+aw[0].id+'_hide_postback(\"" + argument + "\");');}";
            //return ACTIVE_WINDOW_SCRIPT + "if(aw){aw[0].box_hide_postback('" + argument + "');}";

            //return "(function(){var aw=X.wnd.getActiveWindow(); if(aw){ aw[0].box_hide_postback('" + argument + "'); }})();";
            return "(function(){var aw=X.wnd.getActiveWindow();if(aw){aw[0].box_hide_postback(" + JsHelper.GetJsString(argument) + ");}})();";
        }

        #endregion

        #region GetConfirmHideReference

        /// <summary>
        /// 获取先确认当前页面中表单是否更改，然后关闭当前激活窗体的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public static string GetConfirmHideReference()
        {
            return String.Format("X.wnd.confirmFormModified(function(){{{0}}});", GetHideReference());
        }

        /// <summary>
        /// 获取先确认当前页面中表单是否更改，然后关闭当前激活窗体，再刷新父页面的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public static string GetConfirmHideRefreshReference()
        {
            return String.Format("X.wnd.confirmFormModified(function(){{{0}}});", GetHideRefreshReference());
        }

        /// <summary>
        /// 获取先确认当前页面中表单是否更改，然后关闭当前激活窗体，再回发父页面的客户端脚本
        /// </summary>
        /// <returns>客户端脚本</returns>
        public static string GetConfirmHidePostBackReference()
        {
            return String.Format("X.wnd.confirmFormModified(function(){{{0}}});", GetHidePostBackReference());
        }

        /// <summary>
        /// 获取先确认当前页面中表单是否更改，然后关闭当前激活窗体，再回发父页面的客户端脚本
        /// </summary>
        /// <param name="argument">回发参数</param>
        /// <returns>客户端脚本</returns>
        public static string GetConfirmHidePostBackReference(string argument)
        {
            return String.Format("X.wnd.confirmFormModified(function(){{{0}}});", GetHidePostBackReference(argument));
        }

        #endregion
    }
}
