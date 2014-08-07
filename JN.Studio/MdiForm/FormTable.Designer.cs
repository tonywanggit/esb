namespace JN.Studio.MdiForm
{
    partial class FormTable
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTable));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabColumn = new DevExpress.XtraTab.XtraTabPage();
            this.gridColumn = new DevExpress.XtraGrid.GridControl();
            this.gridViewColumn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrimaryKey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colChineseName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaxLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAllowNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesc = new DevExpress.XtraGrid.Columns.GridColumn();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabDataEntity = new DevExpress.XtraTab.XtraTabPage();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.txtDataEntity = new DevExpress.XtraEditors.MemoEdit();
            this.tabBizEntity = new DevExpress.XtraTab.XtraTabPage();
            this.btnCopyEntityBiz = new DevExpress.XtraEditors.SimpleButton();
            this.txtBizEntity = new DevExpress.XtraEditors.MemoEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEditTable = new DevExpress.XtraEditors.SimpleButton();
            this.lblDesc = new System.Windows.Forms.Label();
            this.lblTableName = new System.Windows.Forms.Label();
            this.lblArrow2 = new System.Windows.Forms.Label();
            this.lblDataTable = new System.Windows.Forms.LinkLabel();
            this.lblArrow1 = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.LinkLabel();
            this.lblTableCaption = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabColumn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.tabDataEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataEntity.Properties)).BeginInit();
            this.tabBizEntity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBizEntity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 129);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabColumn;
            this.xtraTabControl1.Size = new System.Drawing.Size(864, 622);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabColumn,
            this.tabDataEntity,
            this.tabBizEntity});
            this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
            // 
            // tabColumn
            // 
            this.tabColumn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabColumn.Controls.Add(this.gridColumn);
            this.tabColumn.Name = "tabColumn";
            this.tabColumn.Size = new System.Drawing.Size(855, 590);
            this.tabColumn.Text = "数据字典";
            // 
            // gridColumn
            // 
            this.gridColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridColumn.Location = new System.Drawing.Point(0, 0);
            this.gridColumn.MainView = this.gridViewColumn;
            this.gridColumn.Name = "gridColumn";
            this.gridColumn.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridColumn.Size = new System.Drawing.Size(855, 590);
            this.gridColumn.TabIndex = 0;
            this.gridColumn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewColumn});
            // 
            // gridViewColumn
            // 
            this.gridViewColumn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colColumnName,
            this.colPrimaryKey,
            this.colChineseName,
            this.colDataType,
            this.colMaxLength,
            this.colAllowNum,
            this.colDesc});
            this.gridViewColumn.GridControl = this.gridColumn;
            this.gridViewColumn.Images = this.imageList;
            this.gridViewColumn.Name = "gridViewColumn";
            this.gridViewColumn.OptionsView.ShowFooter = true;
            this.gridViewColumn.OptionsView.ShowGroupPanel = false;
            this.gridViewColumn.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridViewColumn_CustomDrawRowIndicator);
            this.gridViewColumn.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridViewColumn_RowStyle);
            // 
            // colColumnName
            // 
            this.colColumnName.Caption = "字段名";
            this.colColumnName.FieldName = "Name";
            this.colColumnName.Name = "colColumnName";
            this.colColumnName.Visible = true;
            this.colColumnName.VisibleIndex = 0;
            this.colColumnName.Width = 129;
            // 
            // colPrimaryKey
            // 
            this.colPrimaryKey.Caption = "是否主键";
            this.colPrimaryKey.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colPrimaryKey.FieldName = "PrimaryKey";
            this.colPrimaryKey.Name = "colPrimaryKey";
            this.colPrimaryKey.Visible = true;
            this.colPrimaryKey.VisibleIndex = 6;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colChineseName
            // 
            this.colChineseName.Caption = "中文名";
            this.colChineseName.FieldName = "DisplayName";
            this.colChineseName.Name = "colChineseName";
            this.colChineseName.Visible = true;
            this.colChineseName.VisibleIndex = 1;
            this.colChineseName.Width = 136;
            // 
            // colDataType
            // 
            this.colDataType.Caption = "数据类型";
            this.colDataType.FieldName = "RawType";
            this.colDataType.Name = "colDataType";
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 2;
            this.colDataType.Width = 94;
            // 
            // colMaxLength
            // 
            this.colMaxLength.Caption = "最大长度（Bytes）";
            this.colMaxLength.FieldName = "NumOfByte";
            this.colMaxLength.Name = "colMaxLength";
            this.colMaxLength.Visible = true;
            this.colMaxLength.VisibleIndex = 3;
            this.colMaxLength.Width = 116;
            // 
            // colAllowNum
            // 
            this.colAllowNum.Caption = "可否为NULL";
            this.colAllowNum.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colAllowNum.FieldName = "Nullable";
            this.colAllowNum.Name = "colAllowNum";
            this.colAllowNum.Visible = true;
            this.colAllowNum.VisibleIndex = 4;
            this.colAllowNum.Width = 90;
            // 
            // colDesc
            // 
            this.colDesc.Caption = "备注";
            this.colDesc.FieldName = "Description";
            this.colDesc.Name = "colDesc";
            this.colDesc.Visible = true;
            this.colDesc.VisibleIndex = 5;
            this.colDesc.Width = 269;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "pk.gif");
            this.imageList.Images.SetKeyName(1, "fk.gif");
            // 
            // tabDataEntity
            // 
            this.tabDataEntity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabDataEntity.Controls.Add(this.btnCopy);
            this.tabDataEntity.Controls.Add(this.txtDataEntity);
            this.tabDataEntity.Name = "tabDataEntity";
            this.tabDataEntity.Size = new System.Drawing.Size(855, 590);
            this.tabDataEntity.Text = "数据实体";
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(2, 6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(75, 23);
            this.btnCopy.TabIndex = 1;
            this.btnCopy.Text = "复制";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtDataEntity
            // 
            this.txtDataEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDataEntity.Location = new System.Drawing.Point(3, 35);
            this.txtDataEntity.Name = "txtDataEntity";
            this.txtDataEntity.Size = new System.Drawing.Size(849, 553);
            this.txtDataEntity.TabIndex = 0;
            // 
            // tabBizEntity
            // 
            this.tabBizEntity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tabBizEntity.Controls.Add(this.btnCopyEntityBiz);
            this.tabBizEntity.Controls.Add(this.txtBizEntity);
            this.tabBizEntity.Name = "tabBizEntity";
            this.tabBizEntity.Size = new System.Drawing.Size(855, 590);
            this.tabBizEntity.Text = "业务实体";
            // 
            // btnCopyEntityBiz
            // 
            this.btnCopyEntityBiz.Location = new System.Drawing.Point(3, 8);
            this.btnCopyEntityBiz.Name = "btnCopyEntityBiz";
            this.btnCopyEntityBiz.Size = new System.Drawing.Size(75, 23);
            this.btnCopyEntityBiz.TabIndex = 2;
            this.btnCopyEntityBiz.Text = "复制";
            this.btnCopyEntityBiz.Click += new System.EventHandler(this.btnCopyEntityBiz_Click);
            // 
            // txtBizEntity
            // 
            this.txtBizEntity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBizEntity.Location = new System.Drawing.Point(3, 37);
            this.txtBizEntity.Name = "txtBizEntity";
            this.txtBizEntity.Size = new System.Drawing.Size(849, 553);
            this.txtBizEntity.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.btnEditTable);
            this.panelControl1.Controls.Add(this.lblDesc);
            this.panelControl1.Controls.Add(this.lblTableName);
            this.panelControl1.Controls.Add(this.lblArrow2);
            this.panelControl1.Controls.Add(this.lblDataTable);
            this.panelControl1.Controls.Add(this.lblArrow1);
            this.panelControl1.Controls.Add(this.lblDatabase);
            this.panelControl1.Controls.Add(this.lblTableCaption);
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Location = new System.Drawing.Point(2, 5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(861, 118);
            this.panelControl1.TabIndex = 1;
            // 
            // btnEditTable
            // 
            this.btnEditTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTable.Location = new System.Drawing.Point(780, 87);
            this.btnEditTable.Name = "btnEditTable";
            this.btnEditTable.Size = new System.Drawing.Size(75, 23);
            this.btnEditTable.TabIndex = 8;
            this.btnEditTable.Text = "编辑信息";
            this.btnEditTable.Click += new System.EventHandler(this.btnEditTable_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Font = new System.Drawing.Font("Tahoma", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesc.Location = new System.Drawing.Point(10, 74);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(42, 17);
            this.lblDesc.TabIndex = 7;
            this.lblDesc.Text = "label4";
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableName.Location = new System.Drawing.Point(273, 44);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(102, 16);
            this.lblTableName.TabIndex = 6;
            this.lblTableName.Text = "CKM_SM_USR";
            // 
            // lblArrow2
            // 
            this.lblArrow2.AutoSize = true;
            this.lblArrow2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrow2.Location = new System.Drawing.Point(243, 43);
            this.lblArrow2.Name = "lblArrow2";
            this.lblArrow2.Size = new System.Drawing.Size(26, 18);
            this.lblArrow2.TabIndex = 5;
            this.lblArrow2.Text = ">>";
            // 
            // lblDataTable
            // 
            this.lblDataTable.AutoSize = true;
            this.lblDataTable.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataTable.Location = new System.Drawing.Point(186, 43);
            this.lblDataTable.Name = "lblDataTable";
            this.lblDataTable.Size = new System.Drawing.Size(50, 16);
            this.lblDataTable.TabIndex = 4;
            this.lblDataTable.TabStop = true;
            this.lblDataTable.Text = "数据表";
            // 
            // lblArrow1
            // 
            this.lblArrow1.AutoSize = true;
            this.lblArrow1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArrow1.Location = new System.Drawing.Point(154, 43);
            this.lblArrow1.Name = "lblArrow1";
            this.lblArrow1.Size = new System.Drawing.Size(26, 18);
            this.lblArrow1.TabIndex = 3;
            this.lblArrow1.Text = ">>";
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Font = new System.Drawing.Font("Arial", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabase.Location = new System.Drawing.Point(8, 43);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(142, 16);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.TabStop = true;
            this.lblDatabase.Text = "[10.30.1.4_BPMFlow]";
            // 
            // lblTableCaption
            // 
            this.lblTableCaption.Appearance.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTableCaption.Appearance.Options.UseFont = true;
            this.lblTableCaption.Location = new System.Drawing.Point(34, 12);
            this.lblTableCaption.Name = "lblTableCaption";
            this.lblTableCaption.Size = new System.Drawing.Size(114, 19);
            this.lblTableCaption.TabIndex = 1;
            this.lblTableCaption.Text = "CKM_SM_USR";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::JN.Studio.Properties.Resources.table;
            this.pictureBox1.Location = new System.Drawing.Point(11, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FormTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 748);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "FormTable";
            this.Text = "FormTable";
            this.Load += new System.EventHandler(this.FormTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabColumn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.tabDataEntity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataEntity.Properties)).EndInit();
            this.tabBizEntity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtBizEntity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabColumn;
        private DevExpress.XtraTab.XtraTabPage tabDataEntity;
        private DevExpress.XtraTab.XtraTabPage tabBizEntity;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LabelControl lblTableCaption;
        private DevExpress.XtraGrid.GridControl gridColumn;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewColumn;
        private DevExpress.XtraGrid.Columns.GridColumn colColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn colChineseName;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxLength;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.Label lblArrow2;
        private System.Windows.Forms.LinkLabel lblDataTable;
        private System.Windows.Forms.Label lblArrow1;
        private System.Windows.Forms.LinkLabel lblDatabase;
        private DevExpress.XtraGrid.Columns.GridColumn colAllowNum;
        private DevExpress.XtraGrid.Columns.GridColumn colDesc;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.SimpleButton btnEditTable;
        private System.Windows.Forms.ImageList imageList;
        private DevExpress.XtraGrid.Columns.GridColumn colPrimaryKey;
        private DevExpress.XtraEditors.MemoEdit txtDataEntity;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraEditors.MemoEdit txtBizEntity;
        private DevExpress.XtraEditors.SimpleButton btnCopyEntityBiz;
    }
}