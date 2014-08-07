
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    PageLoadingDesigner.cs
 * CreatedOn:   2008-08-02
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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Web;


namespace ExtAspNet
{

    public class PageLoadingDesigner : ControlBaseDesigner
    {

        public override string GetDesignTimeHtml()
        {
            return CreatePlaceHolderDesignTimeHtml();
        }






    }
}
