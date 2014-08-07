
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    StyleUtil.cs
 * CreatedOn:   2008-05-22
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

namespace ExtAspNet
{

    public class StyleUtil
    {
        /// <summary>
        /// 从字符串“padding:5px;background-color:#DFE8F6;”中提取“background-color:#DFE8F6;”
        /// </summary>
        /// <param name="css"></param>
        /// <param name="styleName"></param>
        /// <returns></returns>
        public static string GetSingleStyleFormCSS(string css, string styleName)
        {
            styleName = styleName.ToLower();
            css = css.ToLower().Replace(" ", "");

            if (css.Contains(styleName))
            {
                int styleStartIndex = css.IndexOf(styleName);
                int styleEndIndex = css.IndexOf(";", styleStartIndex);

                return css.Substring(styleStartIndex, styleEndIndex - styleStartIndex + 1);
            }

            return String.Empty;
        }

        public static string GetBackgroundStyle(string selector, string imageUrl)
        {
            return String.Format("{0}{{background: url({1}) !important;}}", selector, imageUrl);
        }

        public static string GetNoRepeatBackgroundStyle(string selector, string imageUrl)
        {
            return String.Format("{0}{{background: url({1}) no-repeat;}}", selector, imageUrl);
        }


        #region oldcode
        /*
        public static Rectangle ResolvePadding(string paddingOrMargin)
        {
            Rectangle rect = new Rectangle();

            string[] pads = paddingOrMargin.ToLower().Replace("px", "").Split(' ');

            try
            {

                List<int> padList = new List<int>();
                foreach (string pad in pads)
                {
                    string item = pad.Trim();
                    if (!String.IsNullOrEmpty(item))
                    {
                        padList.Add(Convert.ToInt32(item));
                    }
                }
                if (padList.Count > 0)
                {
                    if (padList.Count == 1)
                    {
                        int top = padList[0];

                        rect.Top = top;
                        rect.Right = top;
                        rect.Bottom = top;
                        rect.Left = top;
                    }
                    else if (padList.Count == 2)
                    {
                        int top = padList[0];
                        int right = padList[1];

                        rect.Top = top;
                        rect.Right = right;
                        rect.Bottom = top;
                        rect.Left = right;
                    }
                    else if (padList.Count == 3)
                    {
                        int top = padList[0];
                        int right = padList[1];
                        int bottom = padList[2];

                        rect.Top = top;
                        rect.Right = right;
                        rect.Bottom = bottom;
                        rect.Left = right;
                    }
                    else if (padList.Count >= 4)
                    {
                        int top = padList[0];
                        int right = padList[1];
                        int bottom = padList[2];
                        int left = padList[3];

                        rect.Top = top;
                        rect.Right = right;
                        rect.Bottom = bottom;
                        rect.Left = left;
                    }
                }
            }
            catch (Exception)
            {
                ;
            }

            return rect;
        }
        */
        
        #endregion
    }

    #region oldcode
    /*
    public struct Rectangle
    {
        private int _top;

        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }


        private int _bottom;

        public int Bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }


        private int _left;

        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }


        private int _right;

        public int Right
        {
            get { return _right; }
            set { _right = value; }
        }

    }
    */

    #endregion
}
