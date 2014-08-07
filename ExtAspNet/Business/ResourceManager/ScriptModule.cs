using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;


namespace ExtAspNet
{
    /// <summary>
    /// 请求处理模块（主要用来处理Response.Redirect的情况）
    /// </summary>
    public class ScriptModule : IHttpModule
    {
        private void PreSendRequestHeadersHandler(object sender, EventArgs args)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpResponse response = application.Response;

            if (response.StatusCode == 302)
            {
                if (application.Request.Form["X_AJAX"] == "true")
                {
                    string redirectLocation = response.RedirectLocation;
                    List<HttpCookie> cookies = new List<HttpCookie>(response.Cookies.Count);
                    for (int i = 0; i < response.Cookies.Count; i++)
                    {
                        cookies.Add(response.Cookies[i]);
                    }


                    response.ClearContent();
                    response.ClearHeaders();
                    for (int i = 0; i < cookies.Count; i++)
                    {
                        response.AppendCookie(cookies[i]);
                    }
                    response.Cache.SetCacheability(HttpCacheability.NoCache);
                    response.ContentType = "text/plain";
                    response.Write(String.Format("window.location.href='{0}';", redirectLocation));
                }
            }
        }

        #region IHttpModule 成员

        /// <summary>
        /// 清除资源
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// 初始化模块
        /// </summary>
        /// <param name="context">Http应用程序</param>
        public void Init(HttpApplication context)
        {
            context.PreSendRequestHeaders += new EventHandler(PreSendRequestHeadersHandler);
        }

        #endregion
    }
}
