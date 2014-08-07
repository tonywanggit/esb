
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    js_css_resource.cs
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
    /// 数字输入框控件
    /// </summary>
    [Designer(typeof(NumberBoxDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:NumberBox Label=\"Label\" runat=\"server\"></{0}:NumberBox>")]
    [ToolboxBitmap(typeof(NumberBox), "res.toolbox.NumberBox.bmp")]
    [Description("数字输入框控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class NumberBox : RealTextField
    {
        #region Properties



        /// <summary>
        /// 不允许小数
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(false)]
        [Description("不允许小数")]
        public bool NoDecimal
        {
            get
            {
                object obj = XState["NoDecimal"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["NoDecimal"] = value;
            }
        }


        /// <summary>
        /// 不允许负数
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(false)]
        [Description("不允许负数")]
        public bool NoNegative
        {
            get
            {
                object obj = XState["NoNegative"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["NoNegative"] = value;
            }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最大值")]
        public double? MaxValue
        {
            get
            {
                object obj = XState["MaxValue"];
                return obj == null ? null : (double?)obj;
            }
            set
            {
                XState["MaxValue"] = value;
            }
        }

        /// <summary>
        /// 最小值
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(null)]
        [Description("最小值")]
        public double? MinValue
        {
            get
            {
                object obj = XState["MinValue"];
                return obj == null ? null : (double?)obj;
            }
            set
            {
                XState["MinValue"] = value;
            }
        }


        /// <summary>
        /// 小数点后的位数（默认为2）
        /// </summary>
        [Category(CategoryName.VALIDATION)]
        [DefaultValue(2)]
        [Description("小数点后的位数（默认为2）")]
        public int DecimalPrecision
        {
            get
            {
                object obj = XState["DecimalPrecision"];
                return obj == null ? 2 : (int)obj;
            }
            set
            {
                XState["DecimalPrecision"] = value;
            }
        }


        #endregion

        #region OnPreRender

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            
            OB.AddProperty("allowDecimals", !NoDecimal);
            OB.AddProperty("allowNegative", !NoNegative);
            if (MaxValue != null)
            {
                OB.AddProperty("maxValue", MaxValue.Value);
            }
            if (MinValue != null)
            {
                OB.AddProperty("minValue", MinValue.Value);
            }

            if (DecimalPrecision != 2)
            {
                OB.AddProperty("decimalPrecision", DecimalPrecision);
            }


            string jsContent = String.Format("var {0}=new Ext.form.NumberField({1});", XID, OB.ToString());

            AddStartupScript(jsContent);
        }

        #endregion



    }
}
