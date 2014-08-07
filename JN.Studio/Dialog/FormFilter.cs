using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XCode.DataAccessLayer;

namespace JN.Studio.Dialog
{
    /// <summary>
    /// 过滤器窗口，用于设置表或者是视图的过滤条件
    /// </summary>
    public partial class FormFilter : XtraForm
    {
        #region 成员及构造
        private FormFilter()
        {
            InitializeComponent();
        }
        #endregion

        #region UI事件
        /// <summary>
        /// 清除过滤条件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        #endregion

        #region 过滤逻辑
        /// <summary>
        /// 获取到过滤结果
        /// </summary>
        /// <param name="lstSource"></param>
        /// <returns></returns>
        public List<IDataTable> GetFilterResult(List<IDataTable> lstSource)
        {
            return lstSource.FindAll(x => FilterRule(x.Name)).ToList();
        }

        /// <summary>
        /// 匹配规则
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private Boolean FilterRule(String key)
        {
            String includeFilter = this.txtInclude.Text;
            String excludeFilter = this.txtExclude.Text;

            //--如果大小写不敏感，则统一转换成大写进行匹配
            if (!chkSense.Checked)
            {
                includeFilter = includeFilter.ToUpper();
                excludeFilter = excludeFilter.ToUpper();
                key = key.ToUpper();
            }

            //--如果要求精确匹配
            if (chkPrecision.Checked)  
            {
                return (String.IsNullOrEmpty(includeFilter) || MultiEqualOrNo(key, includeFilter, true))
                    && (String.IsNullOrEmpty(excludeFilter) || MultiEqualOrNo(key, excludeFilter, false));
            }
            else
            {
                return (String.IsNullOrEmpty(includeFilter) || MultiContainsOrNo(key, includeFilter, true))
                    && (String.IsNullOrEmpty(excludeFilter) || MultiContainsOrNo(key, excludeFilter, false));
            }

        }

        /// <summary>
        /// 多条件等于判断
        /// 当equalOrNo==True时， 只要key等于filter中的一个，即返回True
        /// 当equalOrNo==False时，只要key等于filter中的一个，即返回False
        /// </summary>
        /// <param name="key"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private Boolean MultiEqualOrNo(String key, String filter, Boolean equalOrNo)
        {
            String[] filters = filter.Split(',');
            foreach (String item in filters)
            {
                if (item == key) return equalOrNo;
            }

            return !equalOrNo;
        }

        /// <summary>
        /// 多条件包含判断
        /// 当containsOrNo==True时， 只要filter中的一个包含key，即返回True
        /// 当containsOrNo==False时，只要filter中的一个不包含key，即返回False
        /// </summary>
        /// <param name="key"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        private Boolean MultiContainsOrNo(String key, String filter, Boolean containsOrNo)
        {
            String[] filters = filter.Split(',');
            foreach (String item in filters)
            {
                if (key.Contains(item)) return containsOrNo;
            }

            return !containsOrNo;
        }
        #endregion

        #region 静态成员及方法
        private static Dictionary<TreeNode, FormFilter> s_dictForms = new Dictionary<TreeNode, FormFilter>();

        /// <summary>
        /// 根据节点获取到对应的过滤器窗体
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static FormFilter GetInstance(TreeNode node)
        {
            if (!s_dictForms.ContainsKey(node))
                s_dictForms[node] = new FormFilter();

            return s_dictForms[node];
        }
        #endregion
    }
}
