using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraTabbedMdi;
using JN.Studio.MdiForm;
using DevExpress.XtraEditors;
using JN.Studio.Core;
using JN.Studio.Entity;

namespace JN.Studio
{
    public partial class FormMain : XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMdi_Load(object sender, EventArgs e)
        {
            //--TODO: 登录校验
            CurrentUser.UserInfo = UserInfo.FindByLoginName("admin");

            //--利用后台线程编译模板
            CodeGen.AsyncCompileTemplate();
        }

        int ctr = 0;
        void barItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Create an MDI child form.
            //FormTable f = new FormTable();
            //f.Text = "Child Form " + (++ctr).ToString();
            //f.MdiParent = this;
            //f.Show();
        }

        private void barSubItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FormTable f = new FormTable();
            //f.Text = "Child Form " + (++ctr).ToString();
            //f.MdiParent = this;
            //f.Show();
        }

    }
}
