
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    HiddenFieldDesigner.cs
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
using System.Text;
using System.ComponentModel.Design;
using System.Web.UI.WebControls;

namespace ExtAspNet
{

    public class HiddenFieldDesigner : ControlBaseDesigner
    {

       
      
        public override string GetDesignTimeHtml()
        {
            HiddenField control = CurrentControl as HiddenField;

            return CreatePlaceHolderDesignTimeHtml();
        }


    }
}
