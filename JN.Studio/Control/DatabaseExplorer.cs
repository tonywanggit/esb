using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using JN.Studio.Dialog;
using XCode;
using JN.Studio.Entity;
using JN.Studio.Core;
using XCode.DataAccessLayer;
using JN.Studio.MdiForm;
using DevExpress.XtraEditors;
using NewLife.Threading;
using NewLife.Log;

namespace JN.Studio.Control
{
    /// <summary>
    /// 数据库架构浏览器
    /// </summary>
    public partial class DatabaseExplorer : UserControl
    {
        #region 成员及委托
        /// <summary>
        /// Mdi窗体管理器
        /// </summary>
        MdiFormManager mdiFormManager;
        /// <summary>
        /// 新建连接窗体
        /// </summary>
        FormNewConn frmNewConn = new FormNewConn();
        /// <summary>
        /// 用户的所有连接
        /// </summary>
        EntityList<UserConn> lstUserConn = UserConn.FindByUserOID(CurrentUser.UserInfo.OID);

        /// <summary>
        /// 定义用于更新数据表或视图节点的委托
        /// </summary>
        /// <param name="curNode"></param>
        /// <param name="tableCount"></param>
        /// <param name="viewCount"></param>
        delegate void DelegateUpdateNodeText(TreeNode curNode, Int32 tableCount, Int32 viewCount);
        #endregion

        #region 构造
        public DatabaseExplorer()
        {
            InitializeComponent();
        }
        #endregion

        #region 控件加载
        /// <summary>
        /// 控件加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatabaseExplorer_Load(object sender, EventArgs e)
        {
            mdiFormManager = MdiFormManager.GetInstance(this.ParentForm);

            if (lstUserConn != null)
            {
                foreach (UserConn conn in lstUserConn)
                {
                    AddConn(conn);
                }
            }
        }

        /// <summary>
        /// 增加一个数据库连接
        /// </summary>
        /// <param name="databaseConn"></param>
        public void AddConn(UserConn conn)
        {
            Database databaseConn = conn.Database;
            TreeNode nodeTable, nodeView;
            TreeNode nodeDatabase = new TreeNode(databaseConn.ConnName, 7, 7, new TreeNode[]{
                nodeTable = new TreeNode("数据表[加载中...]", 6, 6),
                nodeView = new TreeNode("视图[加载中...]", 6, 6)
            });
            nodeDatabase.Tag = conn;
            trvDatabase.Nodes.Add(nodeDatabase);

            DataSchema.InitDataSchema(conn);
        }
        #endregion

        #region 工具栏按钮事件
        /// <summary>
        /// 工具栏-新建连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btiNewConn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmNewConn.DatabaseExplorer = this;
            frmNewConn.ShowDialog();
        }

        /// <summary>
        /// 工具栏-移除数据库连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btiRemoveConn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserConn conn = trvDatabase.SelectedNode.Tag as UserConn;
            if (conn != null)
            {
                if (XtraMessageBox.Show(this, "您确定要移除此连接吗？", "信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    trvDatabase.Nodes.Remove(trvDatabase.SelectedNode);
                    conn.Delete();
                }
            }
        }

        /// <summary>
        /// 工具栏-过滤器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btiFilter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TreeNode curNode = trvDatabase.SelectedNode;
            List<IDataTable> lstSource = curNode.Tag as List<IDataTable>;

            FormFilter frmFilter = FormFilter.GetInstance(curNode);
            DialogResult result = frmFilter.ShowDialog();

            if (result == DialogResult.OK)
            {
                List<IDataTable> lstTables = frmFilter.GetFilterResult(lstSource);
                LoadTableOrViewNodes(curNode, lstTables);
            }
            else if (result == DialogResult.Ignore) //--代表清除过滤条件
            {
                LoadTableOrViewNodes(curNode, lstSource);
            }

        }
        #endregion

        #region 树节点事件
        /// <summary>
        /// 节点点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDatabase_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode curNode = e.Node;
            if (curNode.Level == 0)
            {
                NodeDatabaseClick(curNode);
            }
            else if (curNode.Level == 1 && curNode.Text.StartsWith("数据表") && curNode.Tag == null)
            {
                NodeTableOrViewClick(curNode, false);
            }
            else if (curNode.Level == 1 && curNode.Text.StartsWith("视图") && curNode.Tag == null)
            {
                NodeTableOrViewClick(curNode, true);
            }
            else if (curNode.Level == 2 && curNode.Parent.Text.StartsWith("数据表"))
            {
                mdiFormManager.ShowTableForm(curNode.FullPath + "//" + curNode.Text, curNode.Text, curNode);
            }
            else if (curNode.Level == 2 && curNode.Parent.Text.StartsWith("视图"))
            {
                mdiFormManager.ShowTableForm(curNode.FullPath + "//" + curNode.Text, curNode.Text, curNode);
            }
        }

        /// <summary>
        /// 点击数据库节点时检测无效的数据库连接
        /// </summary>
        /// <param name="curNode"></param>
        private void NodeDatabaseClick(TreeNode curNode)
        {
            UserConn conn = curNode.Tag as UserConn;
            if (curNode.IsExpanded)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    DataSchema dataSchema = DataSchema.GetInstance(conn);

                    //--如果数据库架构初始化完成，则更新数据表或则视图节点
                    if (dataSchema.InitStatus == DataSchemaInitStatus.Initialized)
                    {
                        UpdateNodeText(curNode, dataSchema.TableCount, dataSchema.ViewCount);
                    }
                    else //--如果数据库架构没有初始化完成则订阅其完成事件，用以更新数据表或视图节点
                    {
                        dataSchema.AddStatusChangeHandler(new EventHandler<StatusChangeEventArgs>((sender, e) =>
                        {
                            this.Invoke(new DelegateUpdateNodeText(UpdateNodeText), curNode, dataSchema.TableCount, dataSchema.ViewCount);
                        }));
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("此连接已经失效将被移除，具体原因如下：\r\n" + ex.Message,
                        "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    conn.Database.Delete();
                    conn.Delete();
                    trvDatabase.Nodes.Remove(curNode);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// 更新数据表和视图节点
        /// </summary>
        /// <param name="curNode"></param>
        /// <param name="tableCount"></param>
        /// <param name="viewCount"></param>
        private void UpdateNodeText(TreeNode curNode, Int32 tableCount, Int32 viewCount)
        {
            curNode.Nodes[0].Text = "数据表[" + tableCount + "]";
            if (tableCount > 0)
                curNode.Nodes[0].Nodes.Add(new TreeNode());

            curNode.Nodes[1].Text = "视图[" + viewCount + "]";
            if (viewCount > 0)
                curNode.Nodes[1].Nodes.Add(new TreeNode());
        }

        /// <summary>
        /// 加载表或者视图数据
        /// </summary>
        /// <param name="curNode"></param>
        private void NodeTableOrViewClick(TreeNode curNode, Boolean isView)
        {
            //--如果数据还在加载，则无需任何处理
            if (!curNode.Text.Contains("加载中..."))
            {
                String connName = curNode.Parent.Text;
                UserConn conn = UserConn.FindByUserAndConnName(CurrentUser.UserInfo.OID, connName);

                DAL.AddConnStr(connName, conn.ConnString, null, conn.Database.Provider);
                List<IDataTable> lstTables = DAL.Create(connName).Tables.FindAll(x => x.IsView == isView);
                curNode.Tag = lstTables;

                LoadTableOrViewNodes(curNode, lstTables);
            }
        }

        /// <summary>
        /// 加载表或者视图节点
        /// </summary>
        /// <param name="curNode"></param>
        /// <param name="lstTables"></param>
        private void LoadTableOrViewNodes(TreeNode curNode, List<IDataTable> lstTables)
        {
            curNode.Nodes.Clear();
            this.trvDatabase.SuspendLayout();
            foreach (IDataTable table in lstTables)
            {
                TreeNode tableNode = curNode.Nodes.Add(curNode.FullPath + "//" + curNode.Text, String.Format("{0}({1})", table.Name, table.DisplayName), 5, 5);
                tableNode.Tag = table;
            }
            this.trvDatabase.ResumeLayout();
        }


        /// <summary>
        /// 当数据库树的选择节点发生变化后控制按钮的状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDatabase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //--如果是数据库节点
            if (e.Node.Level == 0) 
                btiRemoveConn.Enabled = true;
            else
                btiRemoveConn.Enabled = false;

            //--如果是表或视图节点
            if (e.Node.Level == 1)
                btiFilter.Enabled = true;
            else
                btiFilter.Enabled = false;

        }

        /// <summary>
        /// 当数据树失去焦点时禁用移除连接按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvDatabase_Leave(object sender, EventArgs e)
        {
            btiRemoveConn.Enabled = false;
        }
        #endregion
    }
}
