
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    RadioButton.cs
 * CreatedOn:   2008-06-20
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
    /// 单选框控件
    /// </summary>
    [Designer(typeof(RadioButtonDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:RadioButton Label=\"Label\" Text=\"RadioButton\" runat=server></{0}:RadioButton>")]
    [ToolboxBitmap(typeof(RadioButton), "res.toolbox.RadioButton.bmp")]
    [Description("单选框控件")]
    public class RadioButton : Field, IPostBackDataHandler
    {
        #region Constructor

        public RadioButton()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties("Checked");
        }

        #endregion

        #region Properties

        /// <summary>
        /// 文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("文本")]
        public virtual string Text
        {
            get
            {
                object obj = XState["Text"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["Text"] = value;
            }
        }

        /// <summary>
        /// [AJAX属性]是否选中
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("[AJAX属性]是否选中")]
        public bool Checked
        {
            get
            {
                object obj = XState["Checked"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["Checked"] = value;

                ProcessOthersInGroup();
            }
        }

        /// <summary>
        /// 设置本组内其他RadioButton的Checked属性为false
        /// 简单处理，只查找和此RadioButton在同一个层级的RadioButton
        /// </summary>
        private void ProcessOthersInGroup()
        {
            // 如果页面已经加载完毕，并且此RadioButton的属于某一个Group
            // 则在设置这个控件的Checked属性时需要考虑本组内其他控件的Checked属性。
            if (Page != null && !String.IsNullOrEmpty(GroupName) && Checked)
            {
                foreach (Control c in this.Parent.Controls)
                {
                    if (c is RadioButton)
                    {
                        RadioButton rbtn = c as RadioButton;
                        if (rbtn != this && rbtn.GroupName == this.GroupName)
                        {
                            rbtn.Checked = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 分组的名称
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("分组的名称")]
        public string GroupName
        {
            get
            {
                object obj = XState["GroupName"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["GroupName"] = value;
            }
        }


        #endregion

        #region OnInitControl

        protected override void OnInitControl()
        {
            base.OnInitControl();

            ProcessOthersInGroup();
        }

        #endregion

        #region OnPreRender

        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            if (PropertyModified("Checked"))
            {
                //if (ClientPropertyModifiedInServer("Checked"))

                sb.AppendFormat("{0}.x_setValue();", XID);

            }

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            #region options
            OB.AddProperty("checked", Checked);

            if (!String.IsNullOrEmpty(Text))
            {
                OB.AddProperty("boxLabel", Text);
            }

            if (!String.IsNullOrEmpty(GroupName))
            {
                OB.RemoveProperty("name");
                OB.AddProperty("name", GroupName);
                // <input type="radio" name="MyRadioGroup1" id="SimpleForm1_rbtnSecond" value="SimpleForm1_rbtnSecond">
                OB.AddProperty("inputValue", ClientID);
            }

            #endregion

            string jsContent = String.Format("var {0}=new Ext.form.Radio({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion

        #region IPostBackDataHandler Members

        /// <summary>
        /// 处理回发数据
        /// </summary>
        /// <param name="postDataKey">回发数据键</param>
        /// <param name="postCollection">回发数据集</param>
        /// <returns>回发数据是否改变</returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            if (String.IsNullOrEmpty(GroupName))
            {
                // This radio button is not in a group
                string postValue = postCollection[postDataKey];
                bool postChecked = !String.IsNullOrEmpty(postValue);
                if (Checked != postChecked)
                {
                    Checked = postChecked;
                    XState.BackupPostDataProperty("Checked");
                    return true;
                }
            }
            else
            {
                // This radio is in a group
                string postValue = postCollection[GroupName];
                if (!String.IsNullOrEmpty(postValue))
                {
                    bool postChecked = (ClientID == postValue) ? true : false;
                    if (Checked != postChecked)
                    {
                        Checked = postChecked;
                        XState.BackupPostDataProperty("Checked");
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 触发回发数据改变事件
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            //OnCheckedChanged(EventArgs.Empty);
        }

        #region old code
        ///// <summary>
        ///// 文本发生变化
        ///// </summary>
        //public event EventHandler CheckedChanged
        //{
        //    add
        //    {
        //        Events.AddHandler(_handlerKey, value);
        //    }
        //    remove
        //    {
        //        Events.RemoveHandler(_handlerKey, value);
        //    }
        //}

        //public object _handlerKey = new object();

        //public virtual void OnCheckedChanged(EventArgs e)
        //{
        //    EventHandler handler = Events[_handlerKey] as EventHandler;

        //    if (handler != null)
        //    {
        //        handler(this, e);
        //    }
        //} 
        #endregion

        #endregion
    }
}
