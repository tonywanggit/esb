
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    FileUpload.cs
 * CreatedOn:   2011-12-25
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->2011-12-25    sanshi.ustc@gmail.com  
 * 
 * 
 * 
 * 
 */

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI.Design.WebControls;
using System.Web.UI.Design;

namespace ExtAspNet
{
    /// <summary>
    /// 文件上传控件
    /// </summary>
    [Designer(typeof(TextBoxDesigner))]
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:FileUpload Label=\"Label\" runat=\"server\"></{0}:FileUpload>")]
    [ToolboxBitmap(typeof(FileUpload), "res.toolbox.FileUpload.bmp")]
    [Description("文件上传控件")]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    public class FileUpload : RealTextField
    {
        #region Constructor

        public FileUpload()
        {
            AddServerAjaxProperties();
            AddClientAjaxProperties();

        }

        #endregion

        #region Unsupported Properties

        /// <summary>
        /// 不支持此属性
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 按钮文本
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("按钮文本")]
        public string ButtonText
        {
            get
            {
                object obj = XState["ButtonText"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ButtonText"] = value;
            }
        }

        /// <summary>
        /// 是否只显示按钮，不显示只读输入框
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(false)]
        [Description("是否只显示按钮，不显示只读输入框")]
        public bool ButtonOnly
        {
            get
            {
                object obj = XState["ButtonOnly"];
                return obj == null ? false : (bool)obj;
            }
            set
            {
                XState["ButtonOnly"] = value;
            }
        }



        /// <summary>
        /// 按钮图标
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue(Icon.None)]
        [Description("按钮图标")]
        public Icon ButtonIcon
        {
            get
            {
                object obj = XState["ButtonIcon"];
                return obj == null ? Icon.None : (Icon)obj;
            }
            set
            {
                XState["ButtonIcon"] = value;
            }
        }

        /// <summary>
        /// 按钮图标地址
        /// </summary>
        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("按钮图标地址")]
        [Editor(typeof(ImageUrlEditor), typeof(UITypeEditor))]
        public string ButtonIconUrl
        {
            get
            {
                object obj = XState["ButtonIconUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["ButtonIconUrl"] = value;
            }
        }


        /// <summary>
        /// 上传的文件
        /// </summary>
        [Description("上传的文件")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HttpPostedFile PostedFile
        {
            get
            {
                return Page.Request.Files[UniqueID];
            }
        }

        /// <summary>
        /// 是否包含文件
        /// </summary>
        [Description("是否包含文件")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasFile
        {
            get
            {
                return PostedFile != null;
            }
        }

        /// <summary>
        /// 客户端文件名称，包含目录路径（IE下为完成路径，Chrome下为文件名）
        /// </summary>
        [Description("客户端文件名称，包含目录路径（IE下为完成路径，Chrome下为文件名）")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FileName
        {
            get
            {
                return PostedFile.FileName;
            }
        }


        /// <summary>
        /// 客户端文件名称，不包含目录路径
        /// </summary>
        [Description("客户端文件名称，不包含目录路径")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ShortFileName
        {
            get
            {
                string fileName = FileName;
                int lastSlashIndex = fileName.LastIndexOf("\\");
                if (lastSlashIndex >= 0)
                {
                    fileName = fileName.Substring(lastSlashIndex + 1);
                }
                return fileName;
            }
        }


        #endregion

        #region Public

        /// <summary>
        /// 将上载文件的内容保存到 Web 服务器上的指定路径
        /// </summary>
        /// <param name="filename">保存的文件的名称</param>
        public void SaveAs(string filename)
        {
            if (HasFile)
            {
                PostedFile.SaveAs(filename);
            }
        }


        #endregion

        #region OnPreRender


        protected override void OnAjaxPreRender()
        {
            base.OnAjaxPreRender();

            StringBuilder sb = new StringBuilder();
            //if (PropertyModified("Text"))
            //{
            //    sb.AppendFormat("{0}.setValue({1});", XID, JsHelper.Enquote(Text));
            //}

            AddAjaxScript(sb);
        }

        protected override void OnFirstPreRender()
        {
            base.OnFirstPreRender();


            AddStartupAbsoluteScript("X.form_upload_file=true;");


            if (!String.IsNullOrEmpty(ButtonText))
            {
                OB.AddProperty("buttonText", ButtonText);
            }

            if (ButtonOnly)
            {
                OB.AddProperty("buttonOnly", true);
            }


            string resolvedIconUrl = IconHelper.GetResolvedIconUrl(ButtonIcon, ButtonIconUrl);
            if (!String.IsNullOrEmpty(resolvedIconUrl))
            {
                OptionBuilder buttonOB = new OptionBuilder();
                buttonOB.AddProperty("cls", " x-btn-text-icon");
                buttonOB.AddProperty("icon", resolvedIconUrl);

                OB.AddProperty("buttonCfg", buttonOB);
            }
            //if (TextMode != TextMode.Text)
            //{
            //    OB.AddProperty("inputType", TextModeHelper.GetName(TextMode));
            //}

            string jsContent = String.Format("var {0}=new Ext.ux.form.FileUploadField({1});", XID, OB.ToString());
            AddStartupScript(jsContent);
        }

        #endregion


    }
}
