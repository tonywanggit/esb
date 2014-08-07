namespace JN.Studio.Dialog
{
    partial class FormTableInfo
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
            this.lblConnStr = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblConn = new DevExpress.XtraEditors.LabelControl();
            this.lblDatabase = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDataTable = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDesc = new DevExpress.XtraEditors.MemoEdit();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataTable.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblConnStr
            // 
            this.lblConnStr.Location = new System.Drawing.Point(22, 15);
            this.lblConnStr.Name = "lblConnStr";
            this.lblConnStr.Size = new System.Drawing.Size(48, 14);
            this.lblConnStr.TabIndex = 0;
            this.lblConnStr.Text = "连接名：";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "数据库：";
            // 
            // lblConn
            // 
            this.lblConn.Location = new System.Drawing.Point(77, 15);
            this.lblConn.Name = "lblConn";
            this.lblConn.Size = new System.Drawing.Size(70, 14);
            this.lblConn.TabIndex = 2;
            this.lblConn.Text = "labelControl2";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Location = new System.Drawing.Point(77, 44);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(70, 14);
            this.lblDatabase.TabIndex = 3;
            this.lblDatabase.Text = "labelControl2";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(22, 75);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(48, 14);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "数据表：";
            // 
            // txtDataTable
            // 
            this.txtDataTable.Location = new System.Drawing.Point(76, 72);
            this.txtDataTable.Name = "txtDataTable";
            this.txtDataTable.Size = new System.Drawing.Size(278, 21);
            this.txtDataTable.TabIndex = 5;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(34, 105);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "描述：";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(76, 103);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(278, 74);
            this.txtDesc.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(280, 184);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存";
            // 
            // FormTableInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 222);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtDataTable);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.lblConn);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblConnStr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormTableInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "编辑表信息";
            this.Load += new System.EventHandler(this.FormTableInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataTable.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDesc.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblConnStr;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblConn;
        private DevExpress.XtraEditors.LabelControl lblDatabase;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDataTable;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txtDesc;
        private DevExpress.XtraEditors.SimpleButton btnSave;
    }
}