
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RegionCollection.cs
 * CreatedOn:   2008-06-12
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
using System.Collections.ObjectModel;
using System.Web.UI;

namespace ExtAspNet
{
    /// <summary>
    /// Region控件集合，继承自Collection<Region>
    /// </summary>
    public class RegionCollection : Collection<Region>
    {
        private PanelBase panelBase;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="panelBase">面板实例</param>
        public RegionCollection(PanelBase panelBase)
        {
            this.panelBase = panelBase;
        }


        protected override void InsertItem(int index, Region item)
        {
            base.InsertItem(index, item);

            item.RenderWrapperNode = false;
            panelBase.Controls.AddAt(index, item);
        }
    }
}
