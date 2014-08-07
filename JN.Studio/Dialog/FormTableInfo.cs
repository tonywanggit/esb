using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using XCode.DataAccessLayer;
using JN.Studio.Entity;

namespace JN.Studio.Dialog
{
    public partial class FormTableInfo : XtraForm
    {
        TreeNode node;
        UserConn conn;
        IDataTable table;

        public FormTableInfo(TreeNode node)
        {
            this.node = node;
            this.conn = node.Parent.Parent.Tag as UserConn;
            this.table = node.Tag as IDataTable;
            InitializeComponent();
        }

        private void FormTableInfo_Load(object sender, EventArgs e)
        {
            this.lblConn.Text = node.Parent.Parent.Text;
            this.lblDatabase.Text = conn.Database.DatabaseName;
            this.txtDataTable.Text = table.Name;
            this.txtDesc.Text = table.DisplayName;
        }
    }
}
