
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TreeDesigner.cs
 * CreatedOn:   2008-06-05
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
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace ExtAspNet
{

    public class TreeDesigner : ControlBaseDesigner
    {


        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new Tree CurrentControl
        {
            get
            {
                return base.CurrentControl as Tree;
            }
        }

        #endregion


        #region GetDesignTimeHtml

        public override string GetDesignTimeHtml()
        {
            //string title = CurrentControl.Title;
            //if (String.IsNullOrEmpty(title))
            //{
            //    title = String.Format("[{0}]", CurrentControl.ID);
            //}

            //return String.Format(PANEL_TEMPLATE, title, "Tree");
            return this.CreatePlaceHolderDesignTimeHtml();
        }

        #endregion




    }
}
