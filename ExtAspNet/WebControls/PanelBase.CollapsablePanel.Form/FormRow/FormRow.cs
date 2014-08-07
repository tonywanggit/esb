
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    FormRow.cs
 * CreatedOn:   2008-04-23
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
using System.Web.UI.Design.WebControls;

using Newtonsoft.Json;
using System.Web.UI.HtmlControls;


namespace ExtAspNet
{
    /// <summary>
    /// 表单行控件
    /// </summary>
    [ToolboxItem(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class FormRow : ControlBase
    {

        #region Properties

        /// <summary>
        /// 各列的宽度，空格分割
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [DefaultValue("")]
        [Description("各列的宽度，空格分割")]
        public string ColumnWidths
        {
            get
            {
                object obj = XState["ColumnWidths"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ColumnWidths"] = ResolveColumnWidths(value);
            }
        }

        #endregion

        #region Items

        private ControlBaseCollection _items;

        /// <summary>
        /// 子控件集合
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ControlBaseCollection Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ControlBaseCollection(this);
                }
                return _items;
            }
        }

        #endregion

        #region CreateChildControls

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            //// 添加子控件
            //foreach (ControlBase item in Items)
            //{
            //    item.RenderWrapperDiv = false;
            //    Controls.Add(item);
            //}
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();



            
            //// 目的：子控件的JS代码在父控件的前面
            //AddStartupScript(this, String.Empty);
            AddStartupScript(String.Empty);
        }

        #endregion

        #region private ResolveColumnWidths

        /// <summary>
        /// 格式化widths
        /// </summary>
        /// <param name="widths"></param>
        /// <returns></returns>
        private string ResolveColumnWidths(string widths)
        {
            List<string> widthList = new List<string>();

            string[] widthArray = widths.Split(' ');
            foreach (string s in widthArray)
            {
                string tmp = s.Trim();
                if (!String.IsNullOrEmpty(tmp))
                {
                    widthList.Add(ResolveColumnWidth(tmp));
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (string s in widthList)
            {
                sb.AppendFormat("{0} ", s);
            }

            return sb.ToString().TrimEnd();
        }

        private string ResolveColumnWidth(string width)
        {
            string result = width;
            if (result.EndsWith("%"))
            {
                result = (Convert.ToInt32(width.TrimEnd('%')) * 0.01).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            }
            else if (result.ToLower().EndsWith("px"))
            {
                result = result.ToLower().Substring(0, result.Length - 2);
            }

            return result;
        }

        #endregion

        #region old code

        //#region SaveViewState/LoadViewState/TrackViewState

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[2];

        //    states[0] = base.SaveViewState();

        //    states[1] = ((IStateManager)Rows).SaveViewState();

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Rows).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Rows).TrackViewState();
        //}

        //#endregion

        //#region readonly Items

        //private List<ControlBase> _items;

        ///// <summary>
        ///// 从AddParsedSubObject解析出来的内容
        ///// </summary>
        //internal List<ControlBase> Items
        //{
        //    get
        //    {
        //        if (_items == null)
        //        {
        //            _items = new List<ControlBase>();
        //        }

        //        return _items;
        //    }
        //}

        //#endregion

        // #region AddParsedSubObject

        //protected override void AddParsedSubObject(object obj)
        //{
        //    ControlBase c = obj as ControlBase;
        //    if (c != null)
        //    {
        //        c.RenderImmediately = false;
        //        base.AddParsedSubObject(c);

        //        Items.Add(c);
        //    }

        //}

        //  #endregion

        //#region override LoadViewState/SaveViewState

        //protected override void LoadViewState(object state)
        //{
        //    object[] states = (object[])state;

        //    base.LoadViewState(states[0]);

        //    for (int i = 0, count = Items.Count; i < count; i++)
        //    {
        //        ((IStateManager)Items[i]).LoadViewState(states[i + 1]);
        //    }
        //}

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[Items.Count + 1];

        //    states[0] = base.SaveViewState();

        //    for (int i = 0, count = Items.Count; i < count; i++)
        //    {
        //        states[i + 1] = ((IStateManager)Items[i]).SaveViewState();
        //    }

        //    return states;
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    for (int i = 0, count = Items.Count; i < count; i++)
        //    {
        //        ((IStateManager)Items[i]).TrackViewState();
        //    }
        //}

        //#endregion

        //#region SetDirty

        //protected override void SetDirty()
        //{
        //    base.SetDirty();

        //    for (int i = 0, count = Items.Count; i < count; i++)
        //    {
        //        ((ISetDirty)Items[i]).SetDirty();
        //    }
        //}

        //#endregion 

        #endregion

        #region old code
        //#region Controls

        //private List<ControlBase> _controls;

        //public List<ControlBase> Controls
        //{
        //    get
        //    {
        //        if (_controls == null)
        //        {
        //            _controls = new List<ControlBase>();
        //        }
        //        return _controls;
        //    }
        //    set
        //    {
        //        _controls = value;
        //    }
        //}

        //#endregion

        //#region IParserAccessor Members

        //public void AddParsedSubObject(object obj)
        //{
        //    ControlBase control = obj as ControlBase;

        //    if (control != null)
        //    {
        //        Controls.Add(control);
        //    }
        //}

        //#endregion

        //#region override ViewState

        //public override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    foreach (ControlBase control in Controls)
        //    {
        //        ((IStateManager)control).TrackViewState();
        //    }
        //}

        //public override object SaveViewState()
        //{
        //    int index = 0;
        //    foreach (ControlBase control in Controls)
        //    {
        //        BoxState["control" + index] = ((IStateManager)control).SaveViewState();

        //        index++;
        //    }

        //    return base.SaveViewState();
        //}

        //public override void LoadViewState(object state)
        //{
        //    base.LoadViewState(state);

        //    int index = 0;
        //    foreach (ControlBase control in Controls)
        //    {
        //        ((IStateManager)control).LoadViewState(BoxState["control" + index]);

        //        index++;
        //    }
        //}


        //#endregion 
        #endregion

        #region old code

        #region Properties

        //private int? ColumnCount_Default = null;

        //[Category(CategoryName.OPTIONS)]
        //[DefaultValue(null)]
        //[Description("本行有几列")]
        //public int? ColumnCount
        //{
        //    get
        //    {
        //        object obj = BoxState["ColumnCount"];
        //        return obj == null ? ColumnCount_Default : (int?)obj;
        //    }
        //    set
        //    {
        //        BoxState["ColumnCount"] = value;
        //    }
        //}

        #endregion

        #region old code

        //#region AddParsedSubObject

        //protected override void AddParsedSubObject(object obj)
        //{
        //    ControlBase c = obj as ControlBase;
        //    if (c != null)
        //    {
        //        c.RenderImmediately = false;
        //        base.AddParsedSubObject(c);
        //    }
        //}

        //#endregion

        //#region OnPreRender

        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);

        //    AddStartupScript(this, String.Empty);
        //}

        //#endregion

        //#region IStateManager Members

        //bool IStateManager.IsTrackingViewState
        //{
        //    get { return base.IsTrackingViewState; }
        //}

        //void IStateManager.LoadViewState(object state)
        //{
        //    base.LoadViewState(state);
        //}

        //object IStateManager.SaveViewState()
        //{
        //    return base.SaveViewState();
        //}

        //void IStateManager.TrackViewState()
        //{
        //    base.TrackViewState();
        //}

        //#endregion 

        #endregion

        #region old code

        //#region Fields

        //private FieldCollection _fields;

        //[Category(CategoryName.OPTIONS)]
        //[NotifyParentProperty(true)]
        //[PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        //public virtual FieldCollection Fields
        //{
        //    get
        //    {
        //        if (_fields == null)
        //        {
        //            _fields = new FieldCollection();
        //        }
        //        return _fields;
        //    }
        //}
        //#endregion



        #endregion

        #endregion



    }
}
