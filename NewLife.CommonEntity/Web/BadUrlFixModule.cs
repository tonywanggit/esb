using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace NewLife.CommonEntity.Web
{
    /// <summary>
    /// 对于包含#的URL进行处理,避免产生404错误
    ///     例如: http://localhost:1477/Default.aspx#/SystemSet/Menu.aspx
    /// </summary>
    public class BadUrlFixModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            HttpApplication application = sender as HttpApplication;
            HttpContext context = application.Context;

            string currentPath = context.Request.Path;
            if (currentPath.Contains("#"))
                context.RewritePath(currentPath.Split('#')[0]);
        }

        #endregion
    }
}
