using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NewLife.CommonEntity;
using ExtAspNet;

namespace JN.MIS
{
    public partial class Login : System.Web.UI.Page
    {
        protected override void OnPreLoad(EventArgs e)
        {
            if (String.Equals("logout", Request["action"]))
            {
                Administrator.Current.Logout();
            }
            base.OnPreLoad(e);
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Administrator.Current != null)
                {
                    if (String.Equals("logout", Request["action"]))
                    {
                        Administrator.Current.Logout();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbxCaptcha.Text != Session["code"].ToString())
            {
                Alert.ShowInParent("验证码输入错误!");
                return;
            }
            try
            {
                Administrator.Login(UserName.Text, Password.Text);
                if (Administrator.Current != null)
                {
                    Response.Redirect("~/Default.aspx", true);
                    //Response.Write("Admin Success!");
                }
            }
            catch (Exception ex)
            {
                Alert.ShowInParent("登录失败," + ex.Message);
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AppendHeader("Content-encoding", "");

            Random random = new Random();
            imgCaptcha.ImageUrl = imgCaptcha.ImageUrl + "?" + random.ToString();
        }
    }
}