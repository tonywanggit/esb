using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Drawing;
using System.IO;
using System.Web.SessionState;

namespace JN.MIS
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://53wb.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class captcha : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            //string code = GetRndCh();
            string code = GetRandomint(1000, 9999);
            context.Session["code"] = code;
            Bitmap bitmap = CreateImages(code);
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

            context.Response.ClearContent();
            context.Response.ContentType = "image/Gif";
            context.Response.BinaryWrite(stream.ToArray());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private String GetRandomint(Int32 Start, Int32 Stop)
        {
            Random random = new Random();
            return (random.Next(Start, Stop).ToString());
        }
        /// <summary>
        /// 随机中文码
        /// </summary>
        /// <returns></returns>
        private string GetRndCh()
        {
            System.Text.Encoding gb = System.Text.Encoding.Default;//获取GB2312编码页（表）
            object[] bytes = CreateRegionCode(4);//调用函数产生1个随机中文汉字编码
            string[] str = new string[4];
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                str[i] = gb.GetString((byte[])Convert.ChangeType(bytes[i], typeof(byte[])));//根据汉字编码的字节数组解码出中文汉字
                sb.Append(str[i].ToString());
            }
            return sb.ToString();
        }

        /// <summary>
        /// 产生随机中文汉字编码
        /// </summary>
        /// <param name="strlength"></param>
        /// <returns></returns>
        private object[] CreateRegionCode(int strlength)
        {
            //定义一个字符串数组储存汉字编码的组成元素
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            object[] bytes = new object[strlength];

            for (int i = 0; i < strlength; i++)
            {
                //区位码第1位
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();

                //区位码第2位
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);
                int r2;
                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();

                //区位码第3位
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);//更换随机种子避免重复值
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();

                //区位码第4位
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();

                //定义两个字节变量存储产生的随机汉字区位码
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);

                //将两个字节变量存储在字节数组中
                byte[] str_r = new byte[] { byte1, byte2 };

                //将产生的一个汉字的字节数组放入object数组中
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }

        /// <summary>
        /// 画图片的背景图，干扰
        /// </summary>
        /// <param name="checkCode"></param>
        /// <returns></returns>
        private Bitmap CreateImages(string checkCode)
        {
            int step = 5;
            int iwidth = (int)(checkCode.Length * (13 + step));
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 22);
            Graphics g = Graphics.FromImage(image);

            g.Clear(Color.White);//清除背景色

            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };

            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
            Random rand = new Random();

            for (int i = 0; i < 50; i++)
            {
                int x = rand.Next(image.Width);
                int y = rand.Next(image.Height);

                int x1 = rand.Next(image.Width);
                int x2 = rand.Next(image.Width);
                int y1 = rand.Next(image.Height);
                int y2 = rand.Next(image.Height);


                g.DrawLine(new Pen(Color.LightGray, 1), x1, y1, x2, y2);
            }

            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(5);

                Font f = new System.Drawing.Font(font[findex], 10, System.Drawing.FontStyle.Bold);
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * (12 + step)), ii);
            }

            g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //Response.ClearContent();
            //Response.ContentType = "image/Jpeg";
            //Response.BinaryWrite(ms.ToArray());
            //g.Dispose();
            //image.Dispose();
            return image;

        }
    }
}
