
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    js_css_resource.cs
 * CreatedOn:   2008-07-07
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

namespace ExtAspNet
{
    /// <summary>
    /// 隐藏表单控件
    /// </summary>
    [Designer(typeof(HiddenFieldDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:HiddenField runat=\"server\"></{0}:HiddenField>")]
    [ToolboxBitmap(typeof(HiddenField), "res.toolbox.HiddenField.bmp")]
    [Description("隐藏表单控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class HiddenField : RealTextField
    {
        #region Properties

        

        #endregion

        #region OnPreRender



        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);


            

            string jsContent = String.Format("var {0}=new Ext.form.Hidden({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion


    }
}
