namespace JN.Studio.Control
{
    partial class DatabaseExplorer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseExplorer));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDatabase = new DevExpress.XtraBars.Bar();
            this.btiNewConn = new DevExpress.XtraBars.BarButtonItem();
            this.btiRemoveConn = new DevExpress.XtraBars.BarButtonItem();
            this.btiRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btiFilter = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.trvDatabase = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barDatabase});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Images = this.imageList;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btiNewConn,
            this.btiRemoveConn,
            this.btiRefresh,
            this.btiFilter});
            this.barManager.MaxItemId = 5;
            // 
            // barDatabase
            // 
            this.barDatabase.BarName = "Tools";
            this.barDatabase.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.barDatabase.DockCol = 0;
            this.barDatabase.DockRow = 0;
            this.barDatabase.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barDatabase.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btiNewConn),
            new DevExpress.XtraBars.LinkPersistInfo(this.btiRemoveConn),
            new DevExpress.XtraBars.LinkPersistInfo(this.btiRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.btiFilter)});
            this.barDatabase.OptionsBar.AllowQuickCustomization = false;
            this.barDatabase.OptionsBar.DrawDragBorder = false;
            this.barDatabase.OptionsBar.UseWholeRow = true;
            this.barDatabase.Text = "Tools";
            // 
            // btiNewConn
            // 
            this.btiNewConn.Caption = "newConnn";
            this.btiNewConn.Id = 1;
            this.btiNewConn.ImageIndex = 1;
            this.btiNewConn.Name = "btiNewConn";
            toolTipItem1.Text = "连接到数据库...";
            superToolTip1.Items.Add(toolTipItem1);
            this.btiNewConn.SuperTip = superToolTip1;
            this.btiNewConn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btiNewConn_ItemClick);
            // 
            // btiRemoveConn
            // 
            this.btiRemoveConn.Caption = "delConn";
            this.btiRemoveConn.Enabled = false;
            this.btiRemoveConn.Id = 2;
            this.btiRemoveConn.ImageIndex = 2;
            this.btiRemoveConn.Name = "btiRemoveConn";
            toolTipItem2.Text = "删除数据库连接";
            superToolTip2.Items.Add(toolTipItem2);
            this.btiRemoveConn.SuperTip = superToolTip2;
            this.btiRemoveConn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btiRemoveConn_ItemClick);
            // 
            // btiRefresh
            // 
            this.btiRefresh.Caption = "refresh";
            this.btiRefresh.Id = 3;
            this.btiRefresh.ImageIndex = 3;
            this.btiRefresh.Name = "btiRefresh";
            toolTipItem3.Text = "刷新";
            superToolTip3.Items.Add(toolTipItem3);
            this.btiRefresh.SuperTip = superToolTip3;
            // 
            // btiFilter
            // 
            this.btiFilter.Caption = "btiFilter";
            this.btiFilter.Id = 4;
            this.btiFilter.ImageIndex = 8;
            this.btiFilter.Name = "btiFilter";
            this.btiFilter.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btiFilter_ItemClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList.Images.SetKeyName(0, "refresh.bmp");
            this.imageList.Images.SetKeyName(1, "newConn.gif");
            this.imageList.Images.SetKeyName(2, "delConn.gif");
            this.imageList.Images.SetKeyName(3, "refresh.gif");
            this.imageList.Images.SetKeyName(4, "database.gif");
            this.imageList.Images.SetKeyName(5, "table.gif");
            this.imageList.Images.SetKeyName(6, "folder.gif");
            this.imageList.Images.SetKeyName(7, "ntDatabase.gif");
            this.imageList.Images.SetKeyName(8, "filter.png");
            // 
            // trvDatabase
            // 
            this.trvDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvDatabase.ImageIndex = 5;
            this.trvDatabase.ImageList = this.imageList;
            this.trvDatabase.Location = new System.Drawing.Point(0, 26);
            this.trvDatabase.Name = "trvDatabase";
            this.trvDatabase.SelectedImageIndex = 5;
            this.trvDatabase.Size = new System.Drawing.Size(334, 430);
            this.trvDatabase.TabIndex = 4;
            this.trvDatabase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDatabase_AfterSelect);
            this.trvDatabase.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.trvDatabase_NodeMouseClick);
            this.trvDatabase.Leave += new System.EventHandler(this.trvDatabase_Leave);
            // 
            // DatabaseExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trvDatabase);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "DatabaseExplorer";
            this.Size = new System.Drawing.Size(334, 456);
            this.Load += new System.EventHandler(this.DatabaseExplorer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barDatabase;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraBars.BarButtonItem btiNewConn;
        private DevExpress.XtraBars.BarButtonItem btiRemoveConn;
        private System.Windows.Forms.TreeView trvDatabase;
        private DevExpress.XtraBars.BarButtonItem btiRefresh;
        private DevExpress.XtraBars.BarButtonItem btiFilter;
    }
}
