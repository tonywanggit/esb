using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using JN.Studio.Control;
using JN.Studio.Entity;
using XCode;
using JN.Studio.Core;
using DevExpress.XtraEditors.DXErrorProvider;
using XCode.DataAccessLayer;
using NewLife.Net;

namespace JN.Studio.Dialog
{
    public partial class FormNewConn : XtraForm
    {
        private ConditionValidationRule notEmptyValidationRule;

        public FormNewConn()
        {
            InitializeComponent();
            InitValidationRules(null);
        }

        private void InitValidationRules(String databaseType)
        {
            if (notEmptyValidationRule == null)
            {
                notEmptyValidationRule = new ConditionValidationRule();
                notEmptyValidationRule.ConditionOperator = ConditionOperator.IsNotBlank;
                notEmptyValidationRule.ErrorText = "此字段不能为空！";
            }
            
            dxValidationProvider.SetValidationRule(this.cmbServer, notEmptyValidationRule);
            dxValidationProvider.SetValidationRule(this.txtDatabaseName, notEmptyValidationRule);
            dxValidationProvider.SetValidationRule(this.txtPassword, notEmptyValidationRule);
            dxValidationProvider.SetValidationRule(this.txtUserName, notEmptyValidationRule);

            //if (databaseType == "Oracle")
            //{
            //    dxValidationProvider.SetValidationRule(this.txtDatabaseName, null);
            //}
        }

        /// <summary>
        /// 从界面上获取到ConnName：DatabaseName_cmbServer
        /// </summary>
        private String ConnName {
            get {
                return String.Format("{0}_{1}", txtDatabaseName.Text, cmbServer.Text);
            }
        }


        /// <summary>
        /// 数据库对象浏览器
        /// </summary>
        public DatabaseExplorer DatabaseExplorer { get; set; }

        /// <summary>
        /// 确定添加新连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider.Validate())
            {
                Database db = GetDatabaseFromUI();
                if (ConnectToDatabase(db))
                {
                    db = Database.FindByConnName(ConnName);
                    if (db == null)
                    {
                        db = GetDatabaseFromUI();
                        db.Insert();
                    }

                    UserConn conn = UserConn.FindByUserAndDatabaseID(CurrentUser.UserInfo.OID, db.OID);
                    if (conn == null)
                    {
                        conn = new UserConn()
                        {
                            OID = Guid.NewGuid().ToString(),
                            UserID = CurrentUser.UserInfo.OID,
                            DatabaseID = db.OID,
                            ConnString = db.ConnString
                        };
                        conn.Insert();

                        DatabaseExplorer.AddConn(conn);
                        this.Close();
                    }
                    else
                    {
                        XtraMessageBox.Show("此连接您已经添加过了！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            InitValidationRules(this.cmbDatabaseType.Text);

            if (dxValidationProvider.Validate() && ConnectToDatabase(GetDatabaseFromUI()))
            {
                XtraMessageBox.Show("连接成功！", "信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Database GetDatabaseFromUI()
        {
            return new Database()
            {
                OID = Guid.NewGuid().ToString(),
                ConnName = ConnName,
                DatabaseName = txtDatabaseName.Text,
                Server = cmbServer.Text,
                DatabaseType = cmbDatabaseType.Text,
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            };
        }

        /// <summary>
        /// 测试数据库连接是否正确
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private Boolean ConnectToDatabase(Database db)
        {
            Boolean ret = true;
            DAL.AddConnStr(db.ConnName, db.ConnString, null, db.Provider);
            try
            {
                DAL dal = DAL.Create(db.ConnName);
                dal.ConnStr = db.ConnString;
                dal.Session.QuickTest();
            }
            catch (Exception ex)
            {
                ret = false;
                XtraMessageBox.Show(ex.Message, "无法连到数据库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ret;
        }

    }
}
