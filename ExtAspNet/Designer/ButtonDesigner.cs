
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
using System.Text;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web;

namespace ExtAspNet
{
    /// <summary>
    /// 按钮设计时
    /// </summary>
    public class ButtonDesigner : ControlBaseDesigner
    {

        //private static readonly string BUTTON_TEMPLATE = "<table style='width: auto;display:inline;' class='x-btn-wrap x-btn #DISABLED_CLASSNAME#' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button class='x-btn-text' type='button'>#TEXT#</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table>";



        public override string GetDesignTimeHtml()
        {
            Button control = CurrentControl as Button;

            HtmlNodeBuilder nb = new HtmlNodeBuilder("input");
            nb.SetProperty("value", String.IsNullOrEmpty(control.Text) ? ID : control.Text);
            nb.SetProperty("type", "button");
            //if(!control.Enabled)
            //{
            //    nb.SetProperty("disabled", "disabled");
            //}

            return nb.ToString();

            #region old code
            //string content = BUTTON_TEMPLATE;

            //if (String.IsNullOrEmpty(control.Text))
            //{
            //    content = content.Replace("#TEXT#", String.Format("[{0}]", control.ID));
            //}
            //else
            //{
            //    content = content.Replace("#TEXT#", control.Text);
            //}

            //if (control.Enabled)
            //{
            //    content = content.Replace("#DISABLED_CLASSNAME#", String.Empty);
            //}
            //else
            //{
            //    content = content.Replace("#DISABLED_CLASSNAME#", DISABLED_CLASSNAME);
            //}
            //return base.GetDesignTimeHtml() + content;

            //return CreatePlaceHolderDesignTimeHtml(); 
            #endregion
        }


        #region old code
        //private DesignerActionListCollection _actionLists;
        ///// <summary>
        ///// ActionLists
        ///// </summary>
        //public override DesignerActionListCollection ActionLists
        //{
        //    get
        //    {
        //        if (_actionLists == null)
        //        {
        //            _actionLists = new DesignerActionListCollection();
        //            _actionLists.Add(new ButtonActionList(Component));
        //        }
        //        return _actionLists;
        //    }
        //} 
        #endregion
    }
}
