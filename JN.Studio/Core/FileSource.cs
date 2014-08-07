using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace JN.Studio.Core
{
    /// <summary>文件资源</summary>
    public static class FileSource
    {
        public static Icon GetIcon()
        {
            return new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(FileSource), "leaf.ico"));
        }

        /// <summary>释放模版文件</summary>
        public static Dictionary<String, String> GetTemplates()
        {
            String[] ss = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            if (ss == null || ss.Length <= 0) return null;

            Dictionary<String, String> dic = new Dictionary<string, string>();

            //找到资源名
            foreach (String item in ss)
            {
                if (item.StartsWith("JN.Studio.Template."))
                {
                    Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(item);
                    String tempName = item.Substring("JN.Studio.Template.".Length);
                    Byte[] buffer = new Byte[stream.Length];
                    Int32 count = stream.Read(buffer, 0, buffer.Length);

                    String content = Encoding.UTF8.GetString(buffer, 0, count);
                    dic.Add(tempName, content);
                }
            }

            return dic;
        }
    }
}