
#region Comment

/*
 * Project£º    ExtAspNet
 * 
 * FileName:    FlashParam.cs
 * CreatedOn:   2008-07-13
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description£º
 *      ->
 *   
 * History£º
 *      ->
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;


namespace ExtAspNet
{
    [ToolboxItem(false)]
    [ParseChildren(true)]
    [PersistChildren(false)]
    internal class FlashParam : MyStateItem
    {
        #region properties

      
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
        public string ParamKey
        {
            get
            {
                object obj = ViewState["ParamKey"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                ViewState["ParamKey"] = value;
            }
        }

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
        public string ParamValue
        {
            get
            {
                object obj = ViewState["ParamValue"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                ViewState["ParamValue"] = value;
            }
        }

        #endregion


        public FlashParam()
        {
        }

        public FlashParam(string key, string value)
        {
            ParamKey = key;
            ParamValue = value;
        }
    }
}



