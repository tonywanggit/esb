
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    TextArea.cs
 * CreatedOn:   2008-04-23
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
    /// 多行文本框控件
    /// </summary>
    [Designer(typeof(TextAreaDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TextArea Label=\"Label\" Text=\"\" Height=\"250px\" runat=\"server\"></{0}:TextArea>")]
    [ToolboxBitmap(typeof(TextArea), "res.toolbox.TextArea.bmp")]
    [Description("多行文本框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class TextArea : RealTextField
    {
        #region Constructor

        public TextArea()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Properties

        /// <summary>
        /// 是否自动增长高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否自动增长高度")]
        public bool AutoGrowHeight
        {
            get
            {
                object obj = XState["AutoGrowHeight"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["AutoGrowHeight"] = value;
            }
        }


        /// <summary>
        /// 自动增长的最大高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "1000")]
        [Description("自动增长的最大高度")]
        public Unit AutoGrowHeightMax
        {
            get
            {
                object obj = XState["AutoGrowHeightMax"];
                return obj == null ? (Unit)1000 : (Unit)obj;
            }
            set
            {
                XState["AutoGrowHeightMax"] = value;
            }
        }

        /// <summary>
        /// 自动增长的最小高度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(typeof(Unit), "60")]
        [Description("自动增长的最小高度")]
        public Unit AutoGrowHeightMin
        {
            get
            {
                object obj = XState["AutoGrowHeightMin"];
                return obj == null ? (Unit)60 : (Unit)obj;
            }
            set
            {
                XState["AutoGrowHeightMin"] = value;
            }
        }


        /// <summary>
        /// 是否总是隐藏滚动条
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否总是隐藏滚动条")]
        public bool HideScrollbars
        {
            get
            {
                object obj = XState["HideScrollbars"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["HideScrollbars"] = value;
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


            if (AutoGrowHeight)
            {
                OB.AddProperty("grow", AutoGrowHeight);

                if (AutoGrowHeightMax.Value != 1000)
                {
                    OB.AddProperty("growMax", AutoGrowHeightMax.Value);
                }

                if (AutoGrowHeightMin.Value != 60)
                {
                    OB.AddProperty("growMin", AutoGrowHeightMin.Value);
                }

                if (HideScrollbars)
                {
                    OB.AddProperty("preventScrollbars", true);
                }
            }


            //// 自动增长的最小高度要么等于高度，要么等于50（最小值）
            //if (AutoGrowHeight)
            //{
            //    Unit height = (Unit)50;
            //    if (Height != Unit.Empty)
            //    {
            //        height = Height;
            //    }

            //    OB.AddProperty("growMin", height.Value);
            //}

            string jsContent = String.Format("var {0}=new Ext.form.TextArea({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

    }
}
