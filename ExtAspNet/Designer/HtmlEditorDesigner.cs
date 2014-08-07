
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    HtmlEditorDesigner.cs
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
using System.Web.UI.WebControls;
using System.Web;

namespace ExtAspNet
{

    public class HtmlEditorDesigner : ControlBaseDesigner
    {

        public override string GetDesignTimeHtml()
        {
            HtmlEditor control = CurrentControl as HtmlEditor;

            HtmlNodeBuilder nb = new HtmlNodeBuilder("div");

            if (!String.IsNullOrEmpty(control.Text))
            {
                nb.InnerProperty = control.Text;
            }
            else
            {
                nb.InnerProperty = String.Empty;
            }


            string styleStr = String.Empty;
            if (control.Height != Unit.Empty)
            {
                styleStr += String.Format("height:{0}px;", control.Height.Value);
            }
            styleStr += "border:solid 2px #999;padding:5px;";
            styleStr += "width:80%;";

            nb.SetProperty("style", styleStr);


            return control.GetDesignTimeHtml(nb.ToString());
        }


        #region old code

        //// 为了不显示滚动条，把 textarea 用 input 代替
        //private static readonly string HTMLEDITOR_TEMPLATE = "<div style='width: #DIV_WIDTH#;' class='x-html-editor-wrap'><div class='x-html-editor-tb'><div class='x-toolbar x-small-editor'><table cellspacing='0'><tbody><tr>#CONTENT#</tr></tbody></table></div></div><input type='text' value='#VALUE#' class='x-form-textarea x-form-field' style='border: 0pt none;width: #TEXTAREA_WIDTH#; height: #TEXTAREA_HEIGHT#;' autocomplete='off' /></div>";

        //// 分割符
        //private static readonly string SEPARATOR_HTML = "<td><span class='ytb-sep'></span></td>";

        //// EnableFormat
        //private static readonly string ENABLE_FORMAT_HTML = "<td id='ext-gen17'><table style='width: auto;' id='ext-comp-1003' class='x-btn-wrap x-btn x-btn-icon x-edit-bold x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen19' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td><td id='ext-gen26'><table style='width: auto;' id='ext-comp-1004' class='x-btn-wrap x-btn x-btn-icon x-edit-italic x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen28' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td><td id='ext-gen35'><table style='width: auto;' id='ext-comp-1005' class='x-btn-wrap x-btn x-btn-icon x-edit-underline x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen37' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td>";

        ////EnableFontSize
        //private static readonly string ENABLE_FONTSIZE_HTML = "<td id='ext-gen45'><table style='width: auto;' id='ext-comp-1006' class='x-btn-wrap x-btn x-btn-icon x-edit-increasefontsize x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen47' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td><td id='ext-gen54'><table style='width: auto;' id='ext-comp-1007' class='x-btn-wrap x-btn x-btn-icon x-edit-decreasefontsize x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen56' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td>";


        ////EnableColors
        //private static readonly string ENABLE_COLORS_HTML = "<td id='ext-gen67'><table style='width: auto;' id='ext-comp-1012' class='x-btn-wrap x-btn x-btn-icon x-edit-forecolor x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr class='x-btn-with-menu' id='ext-gen76'><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen69' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td><td id='ext-gen77'><table style='width: auto;' id='ext-comp-1013' class='x-btn-wrap x-btn x-btn-icon x-edit-backcolor x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr class='x-btn-with-menu' id='ext-gen86'><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen79' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td>";


        ////EnableAlignments
        //private static readonly string ENABLE_ALIGNMENTS_HTML = "<td id='ext-gen88'><table style='width: auto;' id='ext-comp-1014' class='x-btn-wrap x-btn x-btn-icon x-edit-justifyleft x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen90' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td><td id='ext-gen97'><table style='width: auto;' id='ext-comp-1015' class='x-btn-wrap x-btn x-btn-icon x-edit-justifycenter x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen99' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td><td id='ext-gen106'><table style='width: auto;' id='ext-comp-1016' class='x-btn-wrap x-btn x-btn-icon x-edit-justifyright x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen108' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td>";


        ////EnableLinks
        //private static readonly string ENABLE_LINKS_HTML = "<td id='ext-gen116'><table style='width: auto;' id='ext-comp-1017' class='x-btn-wrap x-btn x-btn-icon x-edit-createlink x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen118' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td>";


        ////EnableLists
        //private static readonly string ENABLE_LISTS_HTML = "<td id='ext-gen126'><table style='width: auto;' id='ext-comp-1018' class='x-btn-wrap x-btn x-btn-icon x-edit-insertorderedlist x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen128' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td><td id='ext-gen135'><table style='width: auto;' id='ext-comp-1019' class='x-btn-wrap x-btn x-btn-icon x-edit-insertunorderedlist x-item-disabled' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen137' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td>";


        ////EnableSourceEdit
        //private static readonly string ENABLE_SOURCEEDIT_HTML = "<td id='ext-gen145'><table style='width: auto;' id='ext-comp-1020' class='x-btn-wrap x-btn x-btn-icon x-edit-sourceedit' border='0' cellpadding='0' cellspacing='0'><tbody><tr><td class='x-btn-left'><i>&nbsp;</i></td><td class='x-btn-center'><em unselectable='on'><button tabindex='-1' id='ext-gen147' class='x-btn-text' type='button'>&nbsp;</button></em></td><td class='x-btn-right'><i>&nbsp;</i></td></tr></tbody></table></td>";


        ///// <summary>
        ///// 设计时展示
        ///// </summary>
        ///// <returns></returns>
        //public override string GetDesignTimeHtml()
        //{
        //    HtmlEditor control = CurrentControl as HtmlEditor;

        //    //string htmlTemplate = "<textarea value=\"{0}\" />";
        //    //return String.Format(htmlTemplate, control.Text);

        //    string content = HTMLEDITOR_TEMPLATE;

        //    #region VALUE
        //    if (!String.IsNullOrEmpty(control.Text))
        //    {
        //        content = content.Replace("#VALUE#", control.Text);
        //    }
        //    else
        //    {
        //        content = content.Replace("#VALUE#", String.Empty);
        //    }
        //    #endregion

        //    #region WIDTH/HEIGHT
        //    if (control.Width != Unit.Empty)
        //    {
        //        content = content.Replace("#DIV_WIDTH#", String.Format("{0}px", control.Width.Value - 2));
        //        content = content.Replace("#TEXTAREA_WIDTH#", String.Format("{0}px", control.Width.Value - 8));
        //    }
        //    else
        //    {
        //        content = content.Replace("#DIV_WIDTH#", String.Format("{0}px", 506 - 2));
        //        content = content.Replace("#TEXTAREA_WIDTH#", String.Format("{0}px", 506 - 8));
        //    }

        //    if (control.Height != Unit.Empty)
        //    {
        //        content = content.Replace("#TEXTAREA_HEIGHT#", String.Format("{0}px", control.Height.Value - 32));
        //    }
        //    else
        //    {
        //        content = content.Replace("#TEXTAREA_HEIGHT#", String.Format("{0}px", 304 - 32));
        //    }
        //    #endregion

        //    StringBuilder sb = new StringBuilder();

        //    #region EnableFont ...

        //    // 当前是否第一个选项
        //    bool hasEnableItem = false;

        //    if (control.EnableFont)
        //    {
        //        hasEnableItem = true;

        //        if (control.FontFamilies != null && control.FontFamilies.Length > 0)
        //        {
        //            sb.AppendFormat("<td>{0}</td>", BuildFontFamiliesHtml(control.FontFamilies));
        //        }
        //        else
        //        {
        //            sb.AppendFormat("<td>{0}</td>", BuildFontFamiliesHtml(new string[] { "Arial", "Courier New", "Times New Roman" }));
        //        }
        //    }

        //    if (control.EnableFormat)
        //    {
        //        if (hasEnableItem)
        //            sb.Append(SEPARATOR_HTML);
        //        else
        //            hasEnableItem = true;


        //        sb.Append(ENABLE_FORMAT_HTML);
        //    }

        //    if (control.EnableFontSize)
        //    {
        //        if (hasEnableItem)
        //            sb.Append(SEPARATOR_HTML);
        //        else
        //            hasEnableItem = true;

        //        sb.Append(ENABLE_FONTSIZE_HTML);
        //    }

        //    if (control.EnableColors)
        //    {
        //        if (hasEnableItem)
        //            sb.Append(SEPARATOR_HTML);
        //        else
        //            hasEnableItem = true;

        //        sb.Append(ENABLE_COLORS_HTML);
        //    }

        //    if (control.EnableAlignments)
        //    {
        //        if (hasEnableItem)
        //            sb.Append(SEPARATOR_HTML);
        //        else
        //            hasEnableItem = true;

        //        sb.Append(ENABLE_ALIGNMENTS_HTML);
        //    }

        //    if (control.EnableLinks)
        //    {
        //        if (hasEnableItem)
        //            sb.Append(SEPARATOR_HTML);
        //        else
        //            hasEnableItem = true;

        //        sb.Append(ENABLE_LINKS_HTML);
        //    }

        //    if (control.EnableLists)
        //    {
        //        if (hasEnableItem)
        //            sb.Append(SEPARATOR_HTML);
        //        else
        //            hasEnableItem = true;

        //        sb.Append(ENABLE_LISTS_HTML);
        //    }

        //    if (control.EnableSourceEdit)
        //    {
        //        if (hasEnableItem)
        //            sb.Append(SEPARATOR_HTML);
        //        else
        //            hasEnableItem = true;

        //        sb.Append(ENABLE_SOURCEEDIT_HTML);
        //    }

        //    #endregion

        //    content = content.Replace("#CONTENT#", sb.ToString());


        //    // Form表单字段
        //    content = GetDesignTimeFormItemHtml(content);

        //    return content;
        //}

        //#region BuildFontFamiliesHtml

        //private string BuildFontFamiliesHtml(string[] fonts)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("<select class='x-font-select'>");

        //    foreach (string font in fonts)
        //    {
        //        sb.AppendFormat("<option value='{1}' style='font-family: {0};'>{0}</option>", font, font.ToLower());
        //    }

        //    sb.Append("</select>");

        //    return sb.ToString();
        //}

        //#endregion


        #endregion

    }
}
