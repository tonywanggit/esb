using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XCode.DataAccessLayer;
using JN.Studio.Dialog;
using DevExpress.Utils.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using JN.Studio.Core;
using JN.Studio.Entity;

namespace JN.Studio.MdiForm
{
    public partial class FormTable : JN.Studio.Core.MdiForm
    {
        #region 构造
        public FormTable(String formCode) : base(formCode)
        {
            InitializeComponent();
        }

        public FormTable() { InitializeComponent(); }
        #endregion

        #region 属性
        IDataTable table;
        FormTableInfo frmTableInfo;
        #endregion

        #region 方法
        public void LoadData()
        {
            lblTableCaption.Text = table.Name;
            lblTableName.Text = table.Name;
            lblDatabase.Text = String.Format("[{0}]", BindingNode.Parent.Parent.Text);
            lblDesc.Text = table.Description;

            lblArrow1.Location = new Point(lblDatabase.Location.X + lblDatabase.Width, lblArrow1.Location.Y);
            lblDataTable.Location = new Point(lblArrow1.Location.X + lblArrow1.Width, lblDataTable.Location.Y);
            lblArrow2.Location = new Point(lblDataTable.Location.X + lblDataTable.Width, lblArrow2.Location.Y);
            lblTableName.Location = new Point(lblArrow2.Location.X + lblArrow2.Width, lblTableName.Location.Y);

            List<IDataColumn> lstColumn = table.Columns;
            this.gridColumn.DataSource = lstColumn;
            this.gridViewColumn.Invalidate();
            this.gridViewColumn.SelectRow(0);
        }
        #endregion

        #region 事件
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTable_Load(object sender, EventArgs e)
        {
            table = BindingNode.Tag as IDataTable;
            frmTableInfo = new FormTableInfo(BindingNode);

            LoadData();
        }

        /// <summary>
        /// 编辑表信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditTable_Click(object sender, EventArgs e)
        {
            frmTableInfo.ShowDialog();
        }

        /// <summary>
        /// 绘制主键图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridViewColumn_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            //if (e.RowHandle > -1)
            //{
            //    Brush brush = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, Color.AliceBlue, Color.DodgerBlue, 90);
            //    Rectangle r = e.Bounds;
            //    r.Inflate(-1, -1);
            //    //e.Graphics.FillRectangle(brush, r);
            //    int x = 0;
            //    int y = 0;
            //    if (e.Info.ImageIndex > -1)
            //    {
            //        ImageCollection lstImage = e.Info.ImageCollection as ImageCollection;

            //        x = r.X + (r.Width - lstImage.ImageSize.Width) / 2;
            //        y = r.Y + (r.Height - lstImage.ImageSize.Height) / 2;
            //        //e.Graphics.DrawImageUnscaled(lstImage.Images[e.Info.ImageIndex], x, y);
            //        e.Graphics.DrawImage(lstImage.Images[e.Info.ImageIndex], x, y);
            //        //e.Graphics.DrawImage(imageList.Images[e.Info.ImageIndex], x, y);
            //    }
            //    ControlPaint.DrawBorder3D(e.Graphics, e.Bounds, Border3DStyle.RaisedInner);

            //    e.Graphics.DrawImage(imageList.Images[0], x + 20, y);

            //    e.Handled = true;
            //}
        }

        private void gridViewColumn_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                IDataColumn column = view.GetRow(e.RowHandle) as IDataColumn;
                //string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Category"]);
                if (column != null && column.PrimaryKey)
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;

                }
            }
            //e.Appearance.
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtDataEntity.Text);
        }

        private void btnCopyEntityBiz_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.txtBizEntity.Text);
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabDataEntity)
            {
                List<IDataTable> lstTable = BindingNode.Parent.Tag as List<IDataTable>;
                UserConn conn = BindingNode.Parent.Parent.Tag as UserConn;
                String[] sourceFile = CodeGen.Render(table.Name, lstTable, new XConfig(XConfig.TEMPLATE_ENTITY_DATA, conn.Database.DatabaseName));

                this.txtDataEntity.Text = sourceFile[0];
            }
            else if (e.Page == tabBizEntity)
            {
                List<IDataTable> lstTable = BindingNode.Parent.Tag as List<IDataTable>;
                UserConn conn = BindingNode.Parent.Parent.Tag as UserConn;
                String[] sourceFile = CodeGen.Render(table.Name, lstTable, new XConfig(XConfig.TEMPLATE_ENTITY_BIZ, conn.Database.DatabaseName));

                this.txtBizEntity.Text = sourceFile[0];
            }
        }
        #endregion
        
    }
}
