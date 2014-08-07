
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    GridDesigner.cs
 * CreatedOn:   2008-05-19
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
using System.Text.RegularExpressions;

namespace ExtAspNet
{

    public class GridDesigner : ControlBaseDesigner
    {

        #region CurrentControl

        /// <summary>
        /// Current Control
        /// </summary>
        public new Grid CurrentControl
        {
            get
            {
                return base.CurrentControl as Grid;
            }
        }

        #endregion

        #region GetDesignTimeHtml

        public override string GetDesignTimeHtml()
        {
            string title = CurrentControl.Title;
            if (String.IsNullOrEmpty(title))
            {
                title = String.Format("[{0}]", CurrentControl.ID);
            }

            return String.Format(PANEL_TEMPLATE, title, GetGridContent());
        }

        #region GetGridContent

        private static readonly string GRID_HEAD_TH_TEMPLATE = "<th style=\"border-bottom:solid 1px #aaaaaa;padding:3px;\">{0}</th>";
        private static readonly string GRID_ITEM_TD_TEMPLATE = "<td style=\"border-bottom:solid 1px #dddddd;padding:2px;\">{0}</td>";


        private string GetGridContent()
        {
            StringBuilder sb = new StringBuilder();

            int columnCount = CurrentControl.Columns.Count;

            sb.Append("<table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tbody>");

            #region Grid Header

            if (CurrentControl.ShowGridHeader)
            {
                sb.Append("<tr>");

                if (CurrentControl.EnableRowNumber)
                {
                    sb.AppendFormat(GRID_HEAD_TH_TEMPLATE, "");
                }

                if (CurrentControl.EnableCheckBoxSelect)
                {
                    sb.AppendFormat(GRID_HEAD_TH_TEMPLATE, "<input type=\"checkbox\" checked=\"checked\" />");
                }

                foreach (GridColumn column in CurrentControl.Columns)
                {
                    sb.AppendFormat(GRID_HEAD_TH_TEMPLATE, column.HeaderText);
                }
                sb.Append("</tr>");
            }


            #endregion

            #region Rows

            // Only show 5 rows in design mode
            for (int i = 0; i < 5; i++)
            {
                if (CurrentControl.EnableAlternateRowColor)
                {
                    if (i % 2 == 0)
                    {
                        sb.Append("<tr>");
                    }
                    else
                    {
                        sb.Append("<tr style=\"background-color:#f1f1f1;\">");
                    }
                }
                else
                {
                    sb.Append("<tr>");
                }

                if (CurrentControl.EnableRowNumber)
                {
                    sb.AppendFormat(GRID_ITEM_TD_TEMPLATE, i + 1);
                }

                if (CurrentControl.EnableCheckBoxSelect)
                {
                    sb.AppendFormat(GRID_ITEM_TD_TEMPLATE, "<input type=\"checkbox\" checked=\"checked\" />");
                }

                for (int j = 0; j < columnCount; j++)
                {
                    string columnContent = String.Empty;
                    GridColumn column = CurrentControl.Columns[j];

                    if (column is HyperLinkField)
                    {
                        columnContent = "<a href=\"#\">DataBind</a>";
                    }
                    else if (column is CheckBoxField)
                    {
                        columnContent = "<input type=\"checkbox\" checked=\"checked\" />";
                    }
                    else if (column is TemplateField)
                    {
                        columnContent = "Template";
                    }
                    else
                    {
                        columnContent = "DataBind";
                    }

                    sb.AppendFormat(GRID_ITEM_TD_TEMPLATE, columnContent);
                }
                sb.Append("</tr>");
            }


            #endregion

            sb.Append("</tbody></table>");

            return sb.ToString();
        }
        #endregion

        #endregion


    }
}
