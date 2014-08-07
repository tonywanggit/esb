
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    SimpleFormDesigner.cs
 * CreatedOn:   2008-04-22
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      -> 2008-5-7 增加设计时支持 sanshi.ustc@gmail.com
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
   
    public class PageLayoutDesigner : ControlBaseDesigner
    {


        public override string GetDesignTimeHtml()
        {

            return CreatePlaceHolderDesignTimeHtml();
        }



       
       
    }
}
