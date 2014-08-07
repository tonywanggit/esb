
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Timer.cs
 * CreatedOn:   2009-09-14
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
    [Designer(typeof(TimerDesigner))]
    [ToolboxData("<{0}:Timer Interval=\"30\" runat=\"server\"></{0}:Timer>")]
    [ToolboxBitmap(typeof(Timer), "res.toolbox.Timer.bmp")]
    [Description("定时器")]
    [DefaultEvent("Tick")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Timer : ControlBase, IPostBackEventHandler
    {
        #region Constructor

        public Timer()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 定时间隔（单位：秒）
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(30)]
        [Description("定时间隔（单位：秒）")]
        public int Interval
        {
            get
            {
                object obj = XState["Interval"];
                return obj == null ? 30 : (int)obj;
            }
            set
            {
                XState["Interval"] = value;
            }
        }


        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();


            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            RenderWrapperNode = false;

            base.OnFirstPreRender();

            if (Enabled)
            {
                AddStartupAbsoluteScript(GetTimerScript());
            }

            string contentScript = String.Format("var {0}=new Ext.Component({1});", XID, OB.ToString());
            AddStartupScript(contentScript);
        }

        private string GetTimerScript()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("window.clearInterval({0}.x_timer);", XID);

            if (Enabled)
            {
                sb.AppendFormat("{0}.x_timer=window.setInterval(function(){{{1}}}, {2});", XID, GetPostBackEventReference(), Interval * 1000);
            }

            return sb.ToString();
        }

        protected override string GetEnabledPropertyChangedScript()
        {
            if (PropertyModified("Enabled"))
            {
                return GetTimerScript();
            }
            return String.Empty;
        }

        #endregion

        #region IPostBackEventHandler

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            OnTick(EventArgs.Empty);
        }

        #endregion

        #region OnTick

        private static readonly object _handlerKey = new object();

        /// <summary>
        /// 定时事件
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("定时事件")]
        public event EventHandler Tick
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


        protected virtual void OnTick(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
    }
}
