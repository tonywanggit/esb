using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Reflection;
using System.IO;
using System.Drawing.Imaging;

namespace ExtAspNet
{
    /// <summary>
    /// 资源处理程序
    /// </summary>
    public class ResourceHandler : IHttpHandler
    {
        /// <summary>
        /// 处理资源的请求
        /// </summary>
        /// <param name="context">Http请求上下文</param>
        public void ProcessRequest(HttpContext context)
        {
            string type = String.Empty, typeValue = String.Empty;

            if (!String.IsNullOrEmpty(typeValue = context.Request["icon"]))
            {
                type = "icon";
            }

            //else if (!String.IsNullOrEmpty(typeValue = context.Request["js"]))
            //{
            //    type = "js";
            //}
            //else if (!String.IsNullOrEmpty(typeValue = context.Request["lang"]))
            //{
            //    type = "lang";
            //}
            //else if (!String.IsNullOrEmpty(typeValue = context.Request["theme"]))
            //{
            //    type = "theme";
            //}
            //else if (!String.IsNullOrEmpty(typeValue = context.Request["css"]))
            //{
            //    type = "css";
            //}
            //else if (!String.IsNullOrEmpty(typeValue = context.Request["image"]))
            //{
            //    type = "image";
            //}

            //string resName = "ExtAspNet.";

            switch (type)
            {
                case "icon":
                    if (!typeValue.EndsWith(".png") && !typeValue.EndsWith(".gif"))
                    {
                        typeValue = IconHelper.GetName((Icon)Enum.Parse(typeof(Icon), typeValue));
                    }
                    //resName += "res.icon." + typeValue;
                    string serverPath = String.Format("{0}/{1}", GlobalConfig.GetIconBasePath(), typeValue);
                    context.Response.WriteFile(context.Server.MapPath(serverPath));

                    context.Response.ContentType = "image/" + GetImageFormat(typeValue);

                    break;
            }

            

            // 缓存一年，只能通过改变 URL 来强制更新缓存
            context.Response.Cache.SetExpires(DateTime.Now.AddYears(1));
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
        }

        //private void RenderImage(HttpContext context, string resName)
        //{
        //    Assembly assembly = Assembly.GetExecutingAssembly();
        //    using (Stream stream = assembly.GetManifestResourceStream(resName))
        //    {
        //        using (System.Drawing.Image image = System.Drawing.Image.FromStream(stream))
        //        {
        //            // PNG输出时出现“GDI+ 中发生一般性错误”
        //            using (MemoryStream ms = new MemoryStream())
        //            {
        //                image.Save(ms, image.RawFormat);
        //                ms.WriteTo(context.Response.OutputStream);
        //                context.Response.ContentType = "image/" + GetImageFormat(image.RawFormat);
        //            }
        //        }
        //    }
        //}

        private string GetImageFormat(string imageName)
        {
            int lastDotIndex = imageName.LastIndexOf(".");
            if (lastDotIndex >= 0)
            {
                return imageName.Substring(lastDotIndex + 1);
            }
            return "png";
        }

        private string GetImageFormat(ImageFormat format)
        {
            if (format == ImageFormat.Bmp)
            {
                return "bmp";
            }
            else if (format == ImageFormat.Gif)
            {
                return "gif";
            }
            else if (format == ImageFormat.Jpeg)
            {
                return "jpeg";
            }
            else if (format == ImageFormat.Png)
            {
                return "png";
            }
            else if (format == ImageFormat.Tiff)
            {
                return "tiff";
            }
            else if (format == ImageFormat.Icon)
            {
                return "icon";
            }
            return "gif";
        }


        /// <summary>
        /// 只要请求的 URL 相同，则请求可以重用
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
