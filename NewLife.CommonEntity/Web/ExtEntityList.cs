
using System;
using System.Collections.Generic;
using System.Text;
using NewLife.Reflection;
using NewLife.Web;
using XCode;
using XCode.Configuration;
using ExtAspNet;
using System.Web.UI;

namespace NewLife.CommonEntity.Web
{
    /// <summary>
    /// 实体表单基类
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    /// <typeparam name="TEntity">表单实体类</typeparam>
    public class ExtEntityList<TKey, TEntity> : WebPageBase
        where TEntity : Entity<TEntity>, new()
    {

        #region 基本属性
        /// <summary>
        /// 主键名称，字符串默认返回Guid，其它默认返回ID
        /// </summary>
        protected virtual String EntityKeyName
        {
            get
            {
                if (Entity<TEntity>.Meta.Unique != null) return Entity<TEntity>.Meta.Unique.Name;

                Type type = typeof(TKey);
                if (type == typeof(Int32))
                    return "ID";
                else if (type == typeof(String))
                    return "Guid";
                else
                    return "ID";
            }
        }

        /// <summary>主键</summary>
        public TKey EntityID
        {
            get
            {
                String str = Request[EntityKeyName];
                if (String.IsNullOrEmpty(str)) return default(TKey);

                Type type = typeof(TKey);
                if (type == typeof(Int32))
                {
                    Int32 id = 0;
                    if (!Int32.TryParse(str, out id)) id = 0;
                    return (TKey)(Object)id;
                }
                else if (type == typeof(String))
                {
                    return (TKey)(Object)str;
                }
                else
                    throw new NotSupportedException("仅支持整数和字符串类型！");
            }
        }

        private TEntity _Entity;
        /// <summary>数据实体</summary>
        public virtual TEntity Entity
        {
            get { return _Entity ?? (_Entity = GetEntity()); }
            set { _Entity = value; }
        }

        /// <summary>获取数据实体，允许页面重载改变实体</summary>
        protected virtual TEntity GetEntity()
        {
            return Entity<TEntity>.FindByKeyForEdit(EntityID);
        }

        /// <summary>
        /// 表单项名字前缀，默认frm
        /// </summary>
        protected virtual String FormItemPrefix { get { return "frm"; } }


        private string _EditIFrameUrlFormatString = null;
        /// <summary>
        /// 编辑窗口的地址URL
        /// </summary>
        protected string EditIFrameUrlFormatString
        {
            set
            {
                _EditIFrameUrlFormatString = value;
            }
            get
            {
                if (_EditIFrameUrlFormatString == null)
                    throw new ArgumentNullException("请在子类的InitFormParam方法中设置编辑窗口的地址URL。");

                return _EditIFrameUrlFormatString;
            }
        }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 保存按钮，查找名为btnSave或UpdateButton（兼容旧版本）的按钮，如果没找到，将使用第一个使用了提交行为的按钮
        /// </summary>
        protected virtual ExtAspNet.Grid ExtGrid
        {
            get
            {
                foreach (ControlBase Subitem in ExtPanel.Items)
                {
                    if (Subitem.ID == "ExtGrid")
                        return Subitem as Grid;
                }
                return null;
            }
        }
        /// <summary>
        /// 保存按钮，查找名为btnSave或UpdateButton（兼容旧版本）的按钮，如果没找到，将使用第一个使用了提交行为的按钮
        /// </summary>
        protected virtual Panel ExtPanel
        {
            get
            {
                System.Web.UI.Control control = ExtAspNet.ControlUtil.FindControl("ExtPanel");
                if (control != null) return control as Panel;
                return null;
            }
        }

        /// <summary>
        /// 是否空主键
        /// </summary>
        protected virtual Boolean IsNullKey
        {
            get
            {
                Type type = typeof(TKey);
                if (type == typeof(Int32))
                {
                    return (Int32)(Object)EntityID <= 0;
                }
                else if (type == typeof(String))
                {
                    return String.IsNullOrEmpty((String)(Object)EntityID);
                }
                else
                    throw new NotSupportedException("仅支持整数和字符串类型！");
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 已重载
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitFormParam();
            InitForm();
        }


        /// <summary>
        /// 已重载。
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
        }
        #endregion

        #region 初始化窗体

        /// <summary>
        /// 初始化窗体
        /// </summary>
        private void InitForm()
        {
            FieldItem FIdentity = null;
            if (ExtGrid == null) return;
            ExtGrid.Title = Entity<TEntity>.Meta.Table.Description;

            foreach (FieldItem item in InitFields(Entity<TEntity>.Meta.Fields))
            {
                if (item.IsIdentity) FIdentity = item;
                ExtAspNet.BoundField boundField1 = new ExtAspNet.BoundField();
                //boundField1.DataToolTipField = item.Name;
                boundField1.DataField = item.Name;
                boundField1.DataFormatString = "{0}";
                boundField1.HeaderText = item.Description;
                ExtGrid.Columns.Add(boundField1);
            }

            #region 编辑操作
            if (Acquire(PermissionFlags.Update))
            {
                if (FIdentity != null)
                {
                    ExtAspNet.WindowField WindowField1 = new ExtAspNet.WindowField();
                    //                    <ext:WindowField Text="编辑" WindowID="Window1" Title="编辑" DataIFrameUrlFields="Id"
                    //            DataIFrameUrlFormatString="~/admin/menu_edit.aspx?id={0}" Width="50px" />
                    WindowField1.Text = "编辑";
                    WindowField1.Title = "编辑";
                    WindowField1.HeaderText = "编辑";
                    WindowField1.WindowID = "Window1";
                    WindowField1.DataIFrameUrlFormatString = EditIFrameUrlFormatString;
                    WindowField1.Width = 50;
                    WindowField1.DataIFrameUrlFields = FIdentity.Name;
                    ExtGrid.Columns.Add(WindowField1);
                }
            }
            #endregion
            #region 删除操作
            if (Acquire(PermissionFlags.Delete))
            {
                LinkButtonField DelField = new LinkButtonField();
                DelField.Text = "删除";
                DelField.ConfirmIcon = MessageBoxIcon.Question;
                DelField.ConfirmText = "确定删除此" + Entity<TEntity>.Meta.Table.Description + "?";
                DelField.ConfirmTarget = Target.Top;
                DelField.HeaderText = "删除";
                DelField.CommandName = "Delete";
                DelField.Width = 50;
                ExtGrid.Columns.Add(DelField);
            }
            #endregion
            if (FIdentity != null) ExtGrid.DataKeyNames = new String[] { FIdentity.Name };

            BindGrid();
        }

        /// <summary>
        /// 页面初始化参数设置
        /// </summary>
        protected virtual void InitFormParam()
        {
            throw new NotImplementedException("请在子类中重写InitFormParam方法，并设置相关参数，如：EditIFrameUrlFormatString。");
        }

        /// <summary>
        /// 返回处理后的实体字段，例如排除不需要显示的字段
        /// </summary>
        /// <returns></returns>
        protected virtual FieldItem[] InitFields(FieldItem[] fields)
        {
            bool needSort = true;
            while (needSort)
            {
                needSort = false;
                for (int i = 0; i < fields.Length - 1; i++)
                {
                    if (fields[i].Column.Order > fields[i + 1].Column.Order)
                    {
                        FieldItem temp = fields[i];
                        fields[i] = fields[i + 1];
                        fields[i + 1] = temp;
                        needSort = true;
                    }
                }
            }
            return fields;
        }

        /// <summary>
        /// 绑定表格数据
        /// </summary>
        protected void BindGrid()
        {
            ExtGrid.DataSource = Entity<TEntity>.FindAll();
            ExtGrid.DataBind();
        }

        #endregion
    }
}
