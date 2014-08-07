using System;
using System.Collections.Generic;
using System.Windows.Forms;
using JN.Studio.Entity;
using NewLife.Log;
using System.Text.RegularExpressions;

namespace JN.Studio
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DevExpress.Skins.SkinManager.EnableFormSkins();

            Application.Run(new FormMain());

            /* String proj = "H2510H";
             String outString = proj.Split('-', '_')[0]; 
             Regex reg = new Regex("\\D");
             outString = reg.Replace(outString, "");
             Console.WriteLine(outString);


             UserInfo.Meta.BeginTrans();
             try
             {
                 UserInfo user = new UserInfo();
                 user.OID = Guid.NewGuid().ToString();
                 user.LoginName = "huky";
                 user.Password = "dd";
                 user.TrueName = "Huky";

                 user.Insert();

                 throw new Exception("huky");


                 UserInfo.Meta.Commit();
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);
                 XTrace.WriteException(ex);

                 UserInfo.Meta.Rollback();
             }

             Orderdrawinfo.Meta.BeginTrans();
             try
             {
                 Orderdrawinfo dwg = new Orderdrawinfo()
                 {
                     工程号 = "H9999",
                     备注 = "Demo",
                     创建日期 = DateTime.Now.ToString(),
                     计划日期 = DateTime.Now.ToString(),
                     类型 = 9,
                     入库日期 = DateTime.Now.ToString(),
                     图号 = "Hello Demo",
                     图纸名称 = "Hello Demo",
                     专业 = "",
                     状态 = "未发布"
                 };
                 dwg.Insert();

                 Orderdrawinfo.Meta.Commit();
             }
             catch (Exception ex)
             {
                 Orderdrawinfo.Meta.Rollback();
                 XTrace.WriteException(ex);
             }

             UserInfo.Meta.BeginTrans();
             try
             {
                 UserInfo user = new UserInfo();
                 user.OID = Guid.NewGuid().ToString();
                 user.LoginName = "huky";
                 user.Password = "dd";
                 user.TrueName = "Huky";

                 user.Insert();

                 //throw new Exception("huky");


                 UserInfo.Meta.Commit();
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);

                 UserInfo.Meta.Rollback();
             }

             UserInfo.Meta.BeginTrans();
             try
             {
                 UserInfo user = new UserInfo();
                 user.OID = Guid.NewGuid().ToString();
                 user.LoginName = "huky";
                 user.Password = "dd";
                 user.TrueName = "Huky";

                 user.Insert();

                 throw new Exception("huky");


                 UserInfo.Meta.Commit();
             }
             catch (Exception ex)
             {
                 Console.WriteLine(ex.Message);

                 UserInfo.Meta.Rollback();
             }*/

        }
    }
}
