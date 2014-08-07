
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    LayoutType.cs
 * CreatedOn:   2008-06-11
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

namespace ExtAspNet
{
    /// <summary>
    /// 布局类型
    /// </summary>
    public enum Layout
    {
        /// <summary>
        /// 容器布局（默认值）
        /// </summary>
        Container,
        /// <summary>
        /// 锚点布局
        /// </summary>
        Anchor,
        /// <summary>
        /// 边框布局（只用于RegionPanel控件）
        /// </summary>
        Border,
        /// <summary>
        /// 自适应布局（用于只有一个子控件的情况）
        /// </summary>
        Fit,
        /// <summary>
        /// 手风琴布局（只用于Accordion控件）
        /// </summary>
        Accordion,
        /// <summary>
        /// 表单布局（用于SimpleForm和Form控件）
        /// </summary>
        Form,
        /// <summary>
        /// 卡片布局（只用于TabStrip控件）
        /// </summary>
        Card,
        /// <summary>
        /// 列布局
        /// </summary>
        Column,
        /// <summary>
        /// 绝对定位布局
        /// </summary>
        Absolute,
        /// <summary>
        /// 行布局
        /// </summary>
        Row,
        /// <summary>
        /// 表格布局
        /// </summary>
        Table,
        /// <summary>
        /// 垂直盒子布局
        /// </summary>
        VBox,
        /// <summary>
        /// 水平盒子布局
        /// </summary>
        HBox
    }

    /// <summary>
    /// 布局类型名称
    /// </summary>
    internal static class LayoutHelper
    {
        public static string GetName(Layout type)
        {
            string result = String.Empty;

            switch (type)
            {
                case Layout.Container:
                    result = "container";
                    break;
                case Layout.Accordion:
                    result = "accordion";
                    break;
                case Layout.Anchor:
                    result = "anchor";
                    break;
                case Layout.Border:
                    result = "border";
                    break;
                case Layout.Card:
                    result = "card";
                    break;
                case Layout.Column:
                    result = "column";
                    break;
                case Layout.Fit:
                    result = "fit";
                    break;
                case Layout.Form:
                    result = "form";
                    break;
                case Layout.Absolute:
                    result = "absolute";
                    break;
                //case LayoutType.Center:
                //    result = "ux.center";
                //    break;
                case Layout.Row:
                    result = "ux.row";
                    break;
                case Layout.Table:
                    result = "table";
                    break;
                case Layout.VBox:
                    result = "vbox";
                    break;
                case Layout.HBox:
                    result = "hbox";
                    break;
            }

            return result;
        }
    }
}