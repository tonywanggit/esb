
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ImageDesigner.cs
 * CreatedOn:   2008-09-22
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
using System.ComponentModel.Design;
using System.Web;

namespace ExtAspNet
{
    public class ImageDesigner : ControlBaseDesigner
    {

        public override string GetDesignTimeHtml()
        {
            Image control = CurrentControl as Image;

            string content = String.Format("<img src=\"{0}\" style=\"border: 0px;\" />", String.IsNullOrEmpty(control.ImageUrl) ? "" : control.ImageUrl);

            return control.GetDesignTimeHtml(content);

        }


    }
}
