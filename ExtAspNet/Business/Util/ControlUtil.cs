
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    ControlUtil.cs
 * CreatedOn:   2008-05-20
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
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace ExtAspNet
{
    /// <summary>
    /// 控件相关帮助函数
    /// </summary>
    public class ControlUtil
    {
        #region FindParentControl

        /// <summary>
        /// 查找父控件
        /// </summary>
        /// <param name="control">当前控件</param>
        /// <param name="controlType">查找控件的类型</param>
        /// <returns>找到的第一个父控件</returns>
        public static Control FindParentControl(Control control, Type controlType)
        {
            if (control == null || control is System.Web.UI.HtmlControls.HtmlForm)
            {
                return null;
            }

            if (control.Parent != null)
            {
                if (control.Parent.GetType().Equals(controlType))
                {
                    return control.Parent;
                }
                else
                {
                    return FindParentControl(control.Parent, controlType);
                }
            }

            return null;
        } 

        #endregion

        #region FindControl

        /// <summary>
        /// 根据控件ID查找控件
        /// </summary>
        /// <param name="findControlID">要查找的控件ID</param>
        /// <returns>找到的控件</returns>
        public static Control FindControl(string findControlID)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                return FindControl(page, findControlID);
            }

            return null;
        }

        /// <summary>
        /// 根据控件类型查找控件
        /// </summary>
        /// <param name="controlType">要查找的控件类型</param>
        /// <returns>找到的控件</returns>
        public static Control FindControl(Type controlType)
        {
            Page page = HttpContext.Current.CurrentHandler as Page;
            if (page != null)
            {
                return FindControl(page, controlType);
            }

            return null;
        }

        /// <summary>
        /// 在父控件的所有子控件中查找控件
        /// </summary>
        /// <param name="parentControl">父控件</param>
        /// <param name="controlId">要查找的控件ID</param>
        /// <returns>找到的控件</returns>
        public static Control FindControl(Control control, string findControlId)
        {
            if (control != null && control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {
                    if (c != null && c.ID == findControlId)
                    {
                        return c;
                    }
                    else
                    {
                        Control childControl = FindControl(c, findControlId);
                        if (childControl != null)
                        {
                            return childControl;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// 在父控件的所有子控件中查找控件
        /// </summary>
        /// <param name="parentControl">父控件</param>
        /// <param name="controlId">要查找的控件类型</param>
        /// <returns>找到的控件</returns>
        public static Control FindControl(Control control, Type controlType)
        {
            if (control != null && control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {
                    if (c != null && c.GetType() == controlType)
                    {
                        return c;
                    }
                    else
                    {
                        Control childControl = FindControl(c, controlType);
                        if (childControl != null)
                        {
                            return childControl;
                        }
                    }
                }
            }

            return null;
        }

        #endregion
    }
}
