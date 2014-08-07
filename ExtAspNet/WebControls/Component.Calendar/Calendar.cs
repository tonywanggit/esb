
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    js_css_resource.cs
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
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;

namespace ExtAspNet
{
    /// <summary>
    /// 日期控件
    /// </summary>
    [Designer(typeof(CalendarDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:Calendar runat=server></{0}:Calendar>")]
    [ToolboxBitmap(typeof(Calendar), "res.toolbox.Calendar.bmp")]
    [DefaultEvent("DateSelect")]
    [Description("日期控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Calendar : Component, IPostBackEventHandler, IPostBackDataHandler
    {
        #region Constructor

        public Calendar()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("SelectedDate");
        }

        #endregion

        #region Properties

        /// <summary>
        /// [AJAX属性]选择的日期
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("[AJAX属性]选择的日期")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? SelectedDate
        {
            get
            {
                object obj = XState["SelectedDate"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                // 传入的值可能包含时间信息，这里就是为了把时间信息去掉，只保留日期信息
                XState["SelectedDate"] = DateTime.ParseExact(value.Value.ToString(DateFormatString), DateFormatString, CultureInfo.InvariantCulture);
            }
        }


        /// <summary>
        /// 日期格式
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("yyyy-MM-dd")]
        [Description("日期格式")]
        public string DateFormatString
        {
            get
            {
                object obj = XState["DateFormatString"];
                return obj == null ? "yyyy-MM-dd" : (string)obj;
            }
            set
            {
                XState["DateFormatString"] = value;
            }
        }

        /// <summary>
        /// 最大日期
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("最大日期")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MaxDate
        {
            get
            {
                object obj = XState["MaxDate"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                XState["MaxDate"] = value;
            }
        }

        /// <summary>
        /// 最小日期
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(null)]
        [Description("最小日期")]
        [Editor("System.ComponentModel.Design.DateTimeEditor", typeof(UITypeEditor))]
        public DateTime? MinDate
        {
            get
            {
                object obj = XState["MinDate"];
                return obj == null ? null : (DateTime?)obj;
            }
            set
            {
                XState["MinDate"] = value;
            }
        }

        /// <summary>
        /// 是否启用选择日期事件
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否启用选择日期事件")]
        public bool EnableDateSelect
        {
            get
            {
                object obj = XState["EnableDateSelect"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["EnableDateSelect"] = value;
            }
        }

        #endregion

        #region SelectedDateHiddenFieldID

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected string SelectedDateHiddenFieldID
        {
            get
            {
                return String.Format("{0}_SelectedDate", ClientID);
            }
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();

            if (PropertyModified("SelectedDate"))
            {
                sb.AppendFormat("{0}.setValue({1});", XID, ExtDateTimeConvertor.GetExtDateObject(SelectedDate.Value));
            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            
            // extjs 的日期格式化字符串
            string extjsDateFormatString = ExtDateTimeConvertor.ConvertToExtDateFormat(DateFormatString);
            OB.AddProperty("format", extjsDateFormatString);

            //if (EnableChineseAltFormats)
            //{
            //    OB.AddProperty("altFormats", "Y-m-d|Y-n-j|Ymd|Ynj|y-m-d|y-n-j|ymd|ynj");
            //}

            if (SelectedDate != null)
            {
                OB.AddProperty("value", ExtDateTimeConvertor.GetExtDateObject(SelectedDate.Value), true);
            }

            if (MaxDate != null)
            {
                OB.AddProperty("maxDate", ExtDateTimeConvertor.GetExtDateObject(MaxDate.Value), true);
            }

            if (MinDate != null)
            {
                OB.AddProperty("minDate", ExtDateTimeConvertor.GetExtDateObject(MinDate.Value), true);
            }


            if (EnableDateSelect)
            {
                OB.Listeners.AddProperty("select", JsHelper.GetFunction(GetPostBackEventReference("Select")), true);
            }


            string jsContent = String.Format("var {0}=new Ext.DatePicker({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion


        #region RaisePostBackEvent

        /// <summary>
        /// 处理回发事件
        /// </summary>
        /// <param name="eventArgument">事件参数</param>
        public void RaisePostBackEvent(string eventArgument)
        {
            if (eventArgument.StartsWith("Select"))
            {
                OnDateSelect(EventArgs.Empty);
            }
        }

        #endregion

        #region OnDateSelect

        private object _handlerKey = new object();

        /// <summary>
        /// 选择日期事件（需要启用EnableDateSelect）
        /// </summary>
        [Category(CategoryName.ACTION)]
        [Description("选择日期事件（需要启用EnableDateSelect）")]
        public virtual event EventHandler DateSelect
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

        protected virtual void OnDateSelect(EventArgs e)
        {
            EventHandler handler = Events[_handlerKey] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public virtual bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            string postSelectedDateStr = postCollection[SelectedDateHiddenFieldID];
            if (!String.IsNullOrEmpty(postSelectedDateStr))
            {
                DateTime currentSelectedDate = DateTime.ParseExact(postSelectedDateStr, DateFormatString, CultureInfo.InvariantCulture);
                if (currentSelectedDate != SelectedDate)
                {
                    SelectedDate = currentSelectedDate;
                    XState.BackupPostDataProperty("SelectedDate");
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public virtual void RaisePostDataChangedEvent()
        {
            //OnCollapsedChanged(EventArgs.Empty);
        }

       

        #endregion
    }
}
