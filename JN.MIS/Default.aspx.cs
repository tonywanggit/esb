using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using Newtonsoft.Json.Linq;
using ExtAspNet;
using menu = NewLife.CommonEntity.Menu;
using XCode;

namespace JN.MIS
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Administrator.Current == null)
            {
#if DEBUG
                // 如果是调试模式，则自动登录
                //Administrator.Login("admin", "admin");
#endif
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadDataMain();
                ToolbarText4.Text = "尊敬的 " + Administrator.Current.FriendName + "用户! 你好";
                ToolbarText3.Text = "您当前的用户角色是 " + Administrator.Current.RoleName;
                RegistClientIDS();
            }
        }

        /// <summary>
        /// 注册客户端脚本，服务器端控件ID和客户端ID的映射关系
        /// </summary>
        private void RegistClientIDS()
        {
            JObject ids = GetClientIDS(btnExpandAll, btnCollapseAll, windowSourceCode, mainTabStrip);
            ids.Add("mainMenu", treeMenu.ClientID);

            string idsScriptStr = String.Format("window.IDS={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
            PageContext.RegisterStartupScript(idsScriptStr);
        }

        private JObject GetClientIDS(params ControlBase[] ctrls)
        {
            JObject jo = new JObject();
            foreach (ControlBase ctrl in ctrls)
            {
                jo.Add(ctrl.ID, ctrl.ClientID);
            }
            return jo;
        }

        protected void Exit_Click(object sender, EventArgs e)
        {
            Administrator.Current.Logout();
            ExtAspNet.PageContext.Redirect("Login.aspx");
            //Page.Response.RedirectLocation = "Login.aspx";

            PageManager1.AjaxAspnetControls = new string[] { "Page" };
        }

        private void LoadDataMain()
        {
            menu m = menu.Root;
            if (m == null || m.Childs == null || m.Childs.Count < 1) return;
            m = m.Childs[0];
            if (m == null) return;
            EntityList<menu> list = Administrator.Current.Role.GetMySubMenus(m.ID);
            if ((list != null) && (list.Count > 0))
            {
                foreach (menu item in list)
                {
                    ExtAspNet.TreeNode tn = new ExtAspNet.TreeNode();
                    tn.Text = item.Name;
                    tn.Expanded = true;
                    tn.Leaf = false;

                    treeMenu.Nodes.Add(tn);
                    //循环得到父节点的子节点
                    ResolveSubTree(item, tn);
                }
            }

        }
        private void ResolveSubTree(menu entity, ExtAspNet.TreeNode treeNode)
        {
            EntityList<menu> list = Administrator.Current.Role.GetMySubMenus(entity.ID);
            if ((list != null) && (list.Count > 0))
            {
                foreach (NewLife.CommonEntity.Menu item in list)
                {
                    ExtAspNet.TreeNode node = new ExtAspNet.TreeNode();
                    node.Text = item.Name;
                    node.Expanded = true;
                    if ((item.Url != null) && (item.Url != ""))
                    {
                        node.Leaf = true;
                        node.NavigateUrl = item.Url;
                    }
                    else
                    {
                        node.Leaf = false;
                    }
                    treeNode.Nodes.Add(node);
                    //循环得到父节点的子节点
                    ResolveSubTree(item, node);
                }
            }
        }
    }
}