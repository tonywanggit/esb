
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TemplateField.cs
 * CreatedOn:   2008-05-27
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
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Reflection;
using System.Web.UI.HtmlControls;
using System.IO;


namespace ExtAspNet
{
    /// <summary>
    /// 表格模板列
    /// </summary>
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    public class TemplateField : GridColumn
    {
        #region Properties

        private ITemplate _itemTemplate;

        [Browsable(false)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TemplateInstance(TemplateInstance.Single)]
        [TemplateContainer(typeof(GridRowControl))]
        public virtual ITemplate ItemTemplate
        {
            get
            {
                return _itemTemplate;
            }
            set
            {
                _itemTemplate = value;
            }
        }


        public bool _renderAsRowExpander = false;

        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("渲染为行扩展")]
        public bool RenderAsRowExpander
        {
            get
            {
                return _renderAsRowExpander;
            }
            set
            {
                _renderAsRowExpander = value;
            }
        }

        #endregion

        #region GetColumnValue

        internal override string GetColumnValue(GridRow row)
        {
            GridRowControl control = row.TemplateContainers[ColumnIndex];
            

            return String.Format("#@TPL@#{0}", control.ClientID);
            //return String.Format("<div id=\"{0}_container\"></div>", control.ClientID);
            //string result = String.Empty;

            //if (_itemTemplate != null)
            //{
            //    StringBuilder output = new StringBuilder();
            //    using (StringWriter sw = new StringWriter(output, CultureInfo.CurrentCulture))
            //    {
            //        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            //        {
            //            //using (GridRowControl control = new GridRowControl(row.DataItem, row.RowIndex))
            //            //{
            //            //    _itemTemplate.InstantiateIn(control);
            //            //    control.ID = String.Format("{0}_{1}", Grid.ID, row.RowIndex);
            //            //    control.DataBind();

            //            //    control.RenderControl(htw);

            //            //}
            //            //GridRowControl control = row.TemplateContainers[ColumnIndex];
            //            //if (control != null)
            //            //{
            //            //    control.DataBind();
            //            //    //control.RenderControl(htw);
            //            //}
            //        }
            //    }

            //    result = output.ToString();
            //}

            //return result;
        }

        //public override string GetFieldType()
        //{
        //    return "string";
        //}

        #endregion

    }
}



