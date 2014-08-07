using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace JN.Studio.Core
{
    public class MdiForm : XtraForm
    {

       #region 属性
        /// <summary>
        /// 表界面所绑定的节点信息
        /// </summary>
        public TreeNode BindingNode { get; set; }

        private String mdiFormCode = String.Empty;
        /// <summary>
        /// 窗体代码，用于MdiFormManager进行管理
        /// </summary>
        public String FormCode
        {
            set { mdiFormCode = value; }
            get { return mdiFormCode; }
        }
        #endregion

        public MdiForm(String mdiFormCode)
        {
            this.mdiFormCode = mdiFormCode;
        }

        public MdiForm()
        {

        }
    }
}
