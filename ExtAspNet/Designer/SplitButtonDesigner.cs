
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    SplitButtonDesigner.cs
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
   
    public class SplitButtonDesigner : ControlBaseDesigner
    {

       
        public override string GetDesignTimeHtml()
        {
            Button control = CurrentControl as Button;

            HtmlNodeBuilder nb = new HtmlNodeBuilder("input");
            nb.SetProperty("value", String.IsNullOrEmpty(control.Text) ? ID : control.Text);
            nb.SetProperty("type", "button");
          

            return nb.ToString();
        }

    }
}
