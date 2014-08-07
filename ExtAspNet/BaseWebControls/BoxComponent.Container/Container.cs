
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Container.cs
 * CreatedOn:   2008-04-14
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


namespace ExtAspNet
{
    /// <summary>
    /// 容器控件基类（抽象类）
    /// </summary>
    public abstract class Container : BoxComponent
    {
        #region Constructor

        public Container()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool FocusOnPageLoad
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Layout

        /// <summary>
        /// 布局类型
        /// </summary>
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Container)]
        [Description("布局类型")]
        public virtual Layout Layout
        {
            get
            {
                object obj = XState["Layout"];
                return obj == null ? Layout.Container : (Layout)obj;
            }
            set
            {
                XState["Layout"] = value;
            }
        } 

        #endregion

        

        #region OnPreRender


        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();

            if (Layout != Layout.Container)
            {
                OB.AddProperty("layout", LayoutHelper.GetName(Layout));

                if (Layout == Layout.Table)
                {
                    OptionBuilder layoutConfigOB = new OptionBuilder();
                    layoutConfigOB.AddProperty("columns", TableConfigColumns);

                    OB.AddProperty("layoutConfig", layoutConfigOB);
                }
                else if (Layout == Layout.HBox || Layout == Layout.VBox)
                {
                    OptionBuilder layoutConfigOB = new OptionBuilder();
                    if (BoxConfigAlign != BoxLayoutAlign.Top)
                    {
                        layoutConfigOB.AddProperty("align", BoxLayoutAlignHelper.GetName(BoxConfigAlign, Layout));
                    }

                    if (BoxConfigPosition != BoxLayoutPosition.Left)
                    {
                        layoutConfigOB.AddProperty("pack", BoxLayoutPositionHelper.GetName(BoxConfigPosition));
                    }

                    if (BoxConfigPadding != "0")
                    {
                        layoutConfigOB.AddProperty("padding", BoxConfigPadding);
                    }

                    if (BoxConfigChildMargin != "0")
                    {
                        layoutConfigOB.AddProperty("defaultMargins", BoxConfigChildMargin);
                    }

                    
                    OB.AddProperty("layoutConfig", layoutConfigOB);
                }

            }

            
        }

        #endregion

    }
}
