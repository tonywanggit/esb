
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    Form.cs
 * CreatedOn:   2008-04-22
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

using Newtonsoft.Json;
using System.Web.UI.HtmlControls;

namespace ExtAspNet
{
    /// <summary>
    /// 表单面板控件
    /// </summary>
    [Designer(typeof(FormDesigner))]
    [ToolboxData("<{0}:Form Title=\"Form\" BodyPadding=\"5px\" EnableBackgroundColor=\"true\" runat=\"server\"><Rows><{0}:FormRow runat=\"server\"></{0}:FormRow><{0}:FormRow runat=\"server\"></{0}:FormRow></Rows></{0}:Form>")]
    [ToolboxBitmap(typeof(Form), "res.toolbox.Form.bmp")]
    [Description("表单面板控件")]
    [ParseChildren(true)]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class Form : CollapsablePanel
    {

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override ControlBaseCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool EnableIFrame
        {
            get
            {
                return base.EnableIFrame;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameUrl
        {
            get
            {
                return base.IFrameUrl;
            }
        }


        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string IFrameName
        {
            get
            {
                return base.IFrameName;
            }
        }

        /// <summary>
        /// 布局类型
        /// </summary>
        [ReadOnly(true)]
        [Category(CategoryName.LAYOUT)]
        [DefaultValue(Layout.Anchor)]
        [Description("布局类型")]
        public override Layout Layout
        {
            get
            {
                return Layout.Form;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 标签的宽度
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(Unit), ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT_STRING)]
        [Description("标签的宽度")]
        public Unit LabelWidth
        {
            get
            {
                object obj = XState["LabelWidth"];
                if (obj == null)
                {
                    //return (Unit)ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT;
                    return PageManager.Instance.FormLabelWidth;
                }
                return (Unit)obj;
            }
            set
            {
                XState["LabelWidth"] = value;
            }
        }

        /// <summary>
        /// 标签与字段的分隔符
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        //[DefaultValue(typeof(String), ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)]
        [Description("标签与字段的分隔符")]
        public String LabelSeparator
        {
            get
            {
                object obj = XState["LabelSeparator"];
                if (obj == null)
                {
                    //return ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT;
                    return PageManager.Instance.FormLabelSeparator;
                }
                return obj.ToString();
            }
            set
            {
                XState["LabelSeparator"] = value;
            }
        }



        /// <summary>
        /// 标签的位置
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(LabelAlign.Left)]
        [Description("标签的位置")]
        public LabelAlign LabelAlign
        {
            get
            {
                object obj = XState["LabelAlign"];
                return obj == null ? LabelAlign.Left : (LabelAlign)obj;
            }
            set
            {
                XState["LabelAlign"] = value;
            }
        }

        #endregion

        #region Rows

        private FormRowCollection rows;

        /// <summary>
        /// 表单行控件集合
        /// </summary>
        [Browsable(false)]
        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public virtual FormRowCollection Rows
        {
            get
            {
                if (rows == null)
                {
                    rows = new FormRowCollection(this);
                }
                return rows;
            }
        }
        #endregion

        #region CreateChildControls

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
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

            ResourceManager.Instance.AddJavaScriptComponent("form");

            #region Options

            //JsObjectBuilder fieldDefaults = new JsObjectBuilder();
            //if (LabelWidth.Value != ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT)
            //{
            //    fieldDefaults.AddProperty("labelWidth", LabelWidth.Value);
            //}
            //if (LabelSeparator != ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)
            //{
            //    fieldDefaults.AddProperty("labelSeparator", LabelSeparator);
            //}

            //if (fieldDefaults.Count > 0)
            //{
            //    OB.AddProperty("fieldDefaults", fieldDefaults);
            //}

            if (LabelWidth.Value != ConfigPropertyValue.FORM_LABELWIDTH_DEFAULT)
            {
                OB.AddProperty("labelWidth", LabelWidth.Value);
            }
            if (LabelSeparator != ConfigPropertyValue.FORM_LABELSEPARATOR_DEFAULT)
            {
                OB.AddProperty("labelSeparator", LabelSeparator);
            }

            if (LabelAlign != LabelAlign.Left)
            {
                OB.AddProperty("labelAlign", LabelAlignHelper.GetName(LabelAlign));
            }

            #endregion

            #region ResolveRows

            // 包含行的列脚本
            string rowScriptStr = String.Empty;
            // 行的集合
            string rowItemScriptStr = String.Empty;

            // 如果存在Rows集合
            if (Rows.Count > 0)
            {
                // rowScriptStr
                // rowItemScriptStr: [X.__Panel1_UpdatePanelConnector1_Panel7_Form5_row0,X.__Panel1_UpdatePanelConnector1_Panel7_Form5_row2]
                ResolveRows(ref rowScriptStr, ref rowItemScriptStr);

                // 添加Items
                OB.RemoveProperty("items");
                OB.AddProperty("items", rowItemScriptStr, true);
            }

            //rowScriptStr += "\r\n";


            #endregion

            // This bug has been fixed in extjs v3.4.0.
            // Do layout when body size changed - I don't know why extjs do it automatically.
            // Why panel.layout.layout? Because Form outside layout doesn't has this function, why? I don't know now.
            //OB.Listeners.AddProperty("bodyresize", "function(panel){if(panel.layout.layout){panel.doLayout();}}", true);

            OB.Listeners.AddProperty("change", JsHelper.GetFunction("X.util.setPageStateChanged();"), true);


            string formPanelScript = String.Format("var {0}=new Ext.Panel({1});", XID, OB.ToString());
            //AddStartupScript(this, rowScriptStr + formPanelScript);

            string jsContent = rowScriptStr + formPanelScript;
            AddStartupScript(jsContent);

            #region oldcode

            //string doLayoutScript = String.Empty;

            //doLayoutScript += String.Format("Ext.EventManager.onWindowResize(function(){{X.{0}.doLayout();}});", ClientJavascriptID);

            //AddPageFirstLoadAbsoluteScript(doLayoutScript);

            #endregion
        }

        /// <summary>
        /// 处理列
        /// </summary>
        /// <returns></returns>
        private void ResolveRows(ref string rowScriptsStr, ref string rowIdsStr)
        {
            JsArrayBuilder rowIdsBuilder = new JsArrayBuilder();

            // 上一行的列数
            int lastRowColumnCount = 1;
            // 上一行的列数
            string lastRowColumnWidths = String.Empty;
            // 是否已经开始多列
            bool isMultiColumnStarted = false;
            // 多列的开始行的序号
            int multiColumnStartLineIndex = 0;

            for (int i = 0, rowCount = Rows.Count; i < rowCount; i++)
            {
                FormRow currentRow = Rows[i];
                int currentRowColumnCount = GetRowColumnCount(currentRow);
                string currentRowColumnWidths = currentRow.ColumnWidths;

                if (currentRowColumnCount == 0)
                {
                    // 如果当前行为空，则跳过此行
                    continue;
                }
                else if (currentRowColumnCount == 1)
                {
                    if (isMultiColumnStarted)
                    {
                        // 如果上一行是多列行，则添加本行之上的所有行
                        rowScriptsStr += AddColumnScript(rowIdsBuilder, multiColumnStartLineIndex, i - 1, lastRowColumnCount);
                        //rowScriptsStr += "\r\n";

                        // 开始重置记录本行为多列的开始
                        isMultiColumnStarted = false;
                        multiColumnStartLineIndex = 0;
                    }

                    // 如果当前行的列数为1，则直接添加Field元素
                    //AddItemScript(ab, currentRow.Fields[0].ClientID);
                    ControlBase component = GetRowColumnControl(currentRow, 0);
                    if (component != null)
                    {
                        rowIdsBuilder.AddProperty(String.Format("{0}", component.XID), true);
                    }
                }
                else
                {
                    // 如果本行是多列
                    if (!isMultiColumnStarted)
                    {
                        // 如果上一行还是单列的话，则开始多列
                        isMultiColumnStarted = true;
                        multiColumnStartLineIndex = i;
                    }
                    else
                    {
                        if (lastRowColumnCount == currentRowColumnCount && lastRowColumnWidths == currentRowColumnWidths)
                        {
                            // 如果上一行的列数和本行的列数相同（并且上一行每列的宽度和本行的每列宽度也一样），则继续下一行
                        }
                        else
                        {
                            // 如果上一行的列数和本行的列数不相同，则添加本行之上的所有行
                            rowScriptsStr += AddColumnScript(rowIdsBuilder, multiColumnStartLineIndex, i - 1, lastRowColumnCount);
                            //rowScriptsStr += "\r\n";

                            // 开始重新记录本行为多列的开始
                            isMultiColumnStarted = true;
                            multiColumnStartLineIndex = i;
                        }
                    }
                }


                lastRowColumnCount = currentRowColumnCount;
                lastRowColumnWidths = currentRowColumnWidths;
            }


            // 还要判断一下（如果最后一行是两列的情况）
            if (isMultiColumnStarted)
            {
                rowScriptsStr += AddColumnScript(rowIdsBuilder, multiColumnStartLineIndex, Rows.Count - 1, lastRowColumnCount);
                //rowScriptsStr += "\r\n";
            }

            rowIdsStr = rowIdsBuilder.ToString();
        }

        /// <summary>
        /// 添加列
        /// </summary>
        /// <param name="ab"></param>
        /// <param name="startLineIndex">开始行的索引（包含）</param>
        /// <param name="endLineIndex">结束行的索引（包含）</param>
        /// <param name="columnCount">行的列数</param>
        private string AddColumnScript(JsArrayBuilder rowIdsBuilder, int startLineIndex, int endLineIndex, int columnCount)
        {
            // 注意，注册脚本的控件应该是最后一个 Row
            // 假如有从上之下这些控件： Row1(Field1,Field2), Row2(Field3,Field4),Row3(Field5)
            // 则渲染时，JS脚本的执行顺序为：Field1,Field2,Row1,Field3,Field4,Row2,Field5,Row3
            // 所以，如果column Panel的脚本注册为控件 Row3，则能保证所有的子控件已经初始化
            // 需要注意的是：在此设置脚本内容到 Row3 控件
            // 现在已经不是这样的了！！！，Row不在是一个控件

            #region examples


            //            {
            //                    layout: 'column',
            //                    border:false,
            //                    items:[{
            //                        columnWidth: .5,
            //                        layout: 'form',
            //                        border:false,
            //                        items:[{
            //                            xtype:'combo',
            //                            store: nextStepStore,
            //                            displayField:'text',
            //                            valueField:'value',
            //                            typeAhead: true,
            //                            mode: 'local',
            //                            triggerAction: 'all',
            //                            value:'1',
            //                            emptyText:'请选择下一步',
            //                            selectOnFocus:true,
            //                            allowBlank:false,
            //                            fieldLabel: '下一步',
            //                            labelSeparator:'&nbsp;<span style="color:red;vertical-align:text-bottom;">*</span>',
            //                            name: 'nextStep',
            //                            anchor:'95%'
            //                        }]
            //                    },{
            //                        columnWidth: .5,
            //                        layout: 'form',
            //                        border:false,
            //                        items:[{
            //                            xtype:'combo',
            //                            store: executePersonStore,
            //                            displayField:'text',
            //                            valueField:'value',
            //                            typeAhead: true,
            //                            mode: 'local',
            //                            triggerAction: 'all',
            //                            value:'1',
            //                            emptyText:'请选择执行人',
            //                            selectOnFocus:true,
            //                            allowBlank:false,
            //                            fieldLabel: '执行人',
            //                            labelSeparator:'&nbsp;<span style="color:red;vertical-align:text-bottom;">*</span>',
            //                            name: 'executePerson',
            //                            anchor:'95%'
            //                        }]
            //                    }]
            //          }


            #endregion


            // 最后一行
            FormRow endLineRow = Rows[endLineIndex];
            string rowId = String.Format("{0}_row{1}", XID, endLineIndex);



            #region bodyStyleStr

            // 如果Form有背景色，这里也增加背景色
            string bodyStyleStr = String.Empty;
            if (EnableBackgroundColor)
            {
                bodyStyleStr = GlobalConfig.GetDefaultBackgroundColor();
            }
            //else if (EnableLightBackgroundColor)
            //{
            //    bodyStyleStr = GlobalConfig.GetLightBackgroundColor(PageManager.Instance.Theme.ToString());
            //}

            if (!String.IsNullOrEmpty(bodyStyleStr))
            {
                bodyStyleStr = String.Format("background-color:{0};", bodyStyleStr);
            }
            #endregion


            string defaultColumnWidthStr = (1.0 / columnCount).ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            string[] columnWidths = ResolveColumnWidths(columnCount, Rows[startLineIndex].ColumnWidths, defaultColumnWidthStr);

            // row_column
            JsArrayBuilder rowColumnScriptsBuilder = new JsArrayBuilder();
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                #region 计算每一列的值

                // 循环每一列
                JsArrayBuilder fieldsAB = new JsArrayBuilder();
                for (int rowIndex = startLineIndex; rowIndex <= endLineIndex; rowIndex++)
                {
                    FormRow currentRow = Rows[rowIndex];

                    if (columnIndex <= GetRowColumnCount(currentRow) - 1)
                    {
                        ControlBase component = GetRowColumnControl(currentRow, columnIndex);
                        if (component != null)
                        {
                            fieldsAB.AddProperty(String.Format("{0}", component.XID), true);
                        }
                    }
                }

                // 当前列的创建JS
                JsObjectBuilder columnOB = new JsObjectBuilder();
                string columnWidth = columnWidths[columnIndex];
                if (Convert.ToDouble(columnWidth) <= 1.0)
                {
                    columnOB.AddProperty("columnWidth", columnWidths[columnIndex], true);
                }
                else
                {
                    columnOB.AddProperty("width", columnWidths[columnIndex], true);
                }

                columnOB.AddProperty("layout", "form");
                columnOB.AddProperty("border", false);
                columnOB.AddProperty("bodyStyle", bodyStyleStr);
                columnOB.AddProperty("labelWidth", LabelWidth.Value);
                columnOB.AddProperty("id", rowId + "_column" + columnIndex.ToString());

                // 有可能为空
                if (fieldsAB.Count > 0)
                {
                    columnOB.AddProperty("items", fieldsAB.ToString(), true);
                }


                rowColumnScriptsBuilder.AddProperty(columnOB.ToString(), true);

                // 现在采取的是安全的ajax，不会出现下面的情况
                //// 所有Layout=form的地方必须用Ext.FormPanel，否则删除时不会把FieldLabek删除掉
                //rowColumnScriptsBuilder.AddProperty(String.Format("new Ext.FormPanel({0})", columnOB.ToString()), true);

                #endregion
            }

            // 外面的JS（X.__Panel1_UpdatePanelConnector1_Panel7_Form5_row0）
            JsObjectBuilder rowBuilder = new JsObjectBuilder();
            rowBuilder.AddProperty("layout", "column");
            rowBuilder.AddProperty("border", false);
            rowBuilder.AddProperty("bodyStyle", bodyStyleStr);

            // 有可能为空
            if (rowColumnScriptsBuilder.Count > 0)
            {
                rowBuilder.AddProperty("items", rowColumnScriptsBuilder.ToString(), true);
            }


            // 把当前节点添加到结果集合中
            rowIdsBuilder.AddProperty(String.Format("{0}", rowId), true);
            rowBuilder.AddProperty("id", rowId);

            // 注意要注册 最后 一个 Row的脚本
            return String.Format("var {0}=new Ext.Panel({1});", rowId, rowBuilder.ToString());
        }

        /// <summary>
        /// 添加Items变量
        /// </summary>
        /// <param name="ab"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private void AddItemScript(JsArrayBuilder ab, string id)
        {
            ab.AddProperty(String.Format("{0}", id), true);
        }

        /// <summary>
        /// 取得当前行的列数
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private int GetRowColumnCount(FormRow row)
        {
            int fieldCount = 0;

            foreach (Control c in row.Controls)
            {
                if (c is ControlBase)
                {
                    fieldCount++;
                }
            }

            #region old code
            //if (row.ColumnCount == null)
            //{
            //    return fieldCount;
            //}
            //else
            //{
            //    if (row.ColumnCount.Value > fieldCount)
            //    {
            //        return row.ColumnCount.Value;
            //    }
            //    else
            //    {
            //        return fieldCount;
            //    }
            //} 
            #endregion

            return fieldCount;
        }

        /// <summary>
        /// 取得当前行 columnIndex 列的控件
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        private ControlBase GetRowColumnControl(FormRow row, int columnIndex)
        {
            int index = 0;
            foreach (Control c in row.Controls)
            {
                if (c is ControlBase)
                {
                    if (columnIndex == index)
                    {
                        return c as ControlBase;
                    }

                    index++;
                }
            }

            return null;
        }

        private string[] ResolveColumnWidths(int columnCount, string columnWidths, string defaultColumnWidthStr)
        {
            string[] results = null;
            if (!String.IsNullOrEmpty(columnWidths))
            {
                string[] columnWidthArray = columnWidths.Split(' ');
                if (columnWidthArray.Length == columnCount)
                {
                    results = columnWidthArray;
                }
            }

            if (results == null)
            {
                results = new string[columnCount];
                for (int i = 0; i < columnCount; i++)
                {
                    results[i] = defaultColumnWidthStr;
                }
            }

            return results;
        }

        #endregion

        #region old code

        //#region SaveViewState/LoadViewState/TrackViewState

        //protected override object SaveViewState()
        //{
        //    object[] states = new object[2];

        //    states[0] = base.SaveViewState();

        //    states[1] = ((IStateManager)Rows).SaveViewState();

        //    return states;
        //}

        //protected override void LoadViewState(object savedState)
        //{
        //    if (savedState != null)
        //    {
        //        object[] states = (object[])savedState;

        //        base.LoadViewState(states[0]);

        //        ((IStateManager)Rows).LoadViewState(states[1]);
        //    }
        //}

        //protected override void TrackViewState()
        //{
        //    base.TrackViewState();

        //    ((IStateManager)Rows).TrackViewState();
        //}

        //#endregion 

        #endregion


    }
}
