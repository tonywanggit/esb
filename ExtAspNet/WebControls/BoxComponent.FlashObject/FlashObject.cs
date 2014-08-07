
#region Comment

/*
 * Project：    ExtAspNet
 * 
 * FileName:    FlashObject.cs
 * CreatedOn:   2008-07-13
 * CreatedBy:   sanshi.ustc@gmail.com
 * 
 * 
 * Description：
 *      ->
 *   
 * History：
 *      ->
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

using Nii.JSON;
using System.Web.UI.HtmlControls;

namespace ExtAspNet
{
    [Designer(typeof(FlashObjectDesigner))]
    [ToolboxData("<{0}:FlashObject runat=\"server\"></{0}:FlashObject>")]
    [ToolboxBitmap(typeof(FlashObject), "res.X.toolbox.FlashObject.bmp")]
    [Description("Flash控件")]
    [ParseChildren(true, "Params")]
    [PersistChildren(false)]
    [ControlBuilder(typeof(NotAllowWhitespaceLiteralsBuilder))]
    internal class FlashObject : BoxComponent
    {

        #region properties

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("#ffffff")]
        [Description("")]
        public string BackgroundColor
        {
            get
            {
                object obj = XState["BackgroundColor"];
                return obj == null ? "#ffffff" : (string)obj;
            }
            set
            {
                XState["BackgroundColor"] = value;
            }
        }

        [Category(CategoryName.OPTIONS)]
        [DefaultValue("")]
        [Description("")]
        public string SwfUrl
        {
            get
            {
                object obj = XState["SwfUrl"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                XState["SwfUrl"] = value;
            }
        }

        #endregion

        #region Params

        private FlashParamCollection _params;

        [Category(CategoryName.OPTIONS)]
        [NotifyParentProperty(true)]
        [PersistenceMode(PersistenceMode.InnerDefaultProperty)]
        public virtual FlashParamCollection Params
        {
            get
            {
                if (_params == null)
                {
                    _params = new FlashParamCollection();

                    if (base.IsTrackingViewState)
                    {
                        ((IStateManager)_params).TrackViewState();
                    }
                }
                return _params;
            }
        }
        #endregion

        #region RenderBeginTag/RenderEndTag

        public override void RenderBeginTag(HtmlTextWriter writer)
        {
            base.RenderBeginTag(writer);

            HtmlNodeBuilder node = new HtmlNodeBuilder("embed");
            node.SetProperty("align", "middle");
            if (Width != Unit.Empty)
            {
                node.SetProperty("width", Width.Value.ToString());
            }
            if (Height != Unit.Empty)
            {
                node.SetProperty("height", Height.Value.ToString());
            }
            node.SetProperty("type", "application/x-shockwave-flash");
            node.SetProperty("pluginspage", "http://www.adobe.com/go/getflashplayer");
            node.SetProperty("bgcolor", BackgroundColor);
            node.SetProperty("allowscriptaccess", "sameDomain");

            StringBuilder sb = new StringBuilder();
            foreach (FlashParam param in Params)
            {
                sb.AppendFormat("{0}={1}&", param.ParamKey, param.ParamValue);
            }
            node.SetProperty("flashvars", sb.ToString().TrimEnd('&'));
            node.SetProperty("wmode", "transparent");
            node.SetProperty("quality", "high");
            node.SetProperty("src", ResolveUrl(SwfUrl));

            writer.Write(node.ToString());

        }

        public override void RenderEndTag(HtmlTextWriter writer)
        {
            base.RenderEndTag(writer);
        }

        #endregion

        #region OnPreRender

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            
            #region examples

            //document.write(String(new Ext.ux.Media.Flash({mediaCfg:{
            //                           mediaType   : 'SWF'
            //                          ,url    : 'clock.swf'
            //                          ,id     :  'inlineClock'
            //                          ,style: {display:'inline', width:'100px',height:'80px'}
            //                          ,start    : true
            //                          ,loop     : true
            //                          ,controls :false
            //                          ,params: {
            //                              wmode     :'opaque'
            //                             ,scale     :'exactfit'
            //                             ,salign    :'t'
            //                          }
            //                     }}))); 

            #endregion

            #region old code

            //JsObjectBuilder mediaCfgBuilder = new JsObjectBuilder();

            //#region options

            //mediaCfgBuilder.AddProperty("mediaType", "SWF");
            //mediaCfgBuilder.AddProperty("start", true);
            //mediaCfgBuilder.AddProperty("loop", true);
            //mediaCfgBuilder.AddProperty("controls", false);
            //mediaCfgBuilder.AddProperty("url", ResolveUrl(SwfUrl));
            //mediaCfgBuilder.AddProperty("id", ClientID + "_flash");
            //if (Width != Unit.Empty)
            //{
            //    mediaCfgBuilder.AddProperty("width", Width.Value);
            //}
            //else
            //{
            //    mediaCfgBuilder.AddProperty("width", "100%");
            //}
            //if (Height != Unit.Empty)
            //{
            //    mediaCfgBuilder.AddProperty("height", Height.Value);
            //}
            //else
            //{
            //    mediaCfgBuilder.AddProperty("height", "100%");
            //}

            //mediaCfgBuilder.AddProperty("bgcolor", BackgroundColor);

            //#endregion

            //#region styleBuilder

            ////JsObjectBuilder styleBuilder = new JsObjectBuilder();
            ////styleBuilder.AddProperty("display", "inline");

            ////mediaCfgBuilder.AddProperty("style", styleBuilder);

            //#endregion

            //#region  paramsBuilder

            //StringBuilder sb = new StringBuilder();
            //foreach (FlashParam param in Params)
            //{
            //    sb.AppendFormat("{0}={1}&", param.ParamKey, param.ParamValue);
            //}

            //JsObjectBuilder paramsBuilder = new JsObjectBuilder();
            //paramsBuilder.AddProperty("flashvars", sb.ToString().TrimEnd('&'));
            //paramsBuilder.AddProperty("bgcolor", BackgroundColor);

            //mediaCfgBuilder.AddProperty("params", paramsBuilder);


            //#endregion


            //string jsContent = String.Format("var {0}=new Ext.ux.Media.Flash({{mediaCfg:{1}}});", ClientID, mediaCfgBuilder.ToString());
            //AddStartupScript(this, jsContent);


            ////string addToPageScript = String.Format("Ext.get('{0}').dom.innerHTML=String(X.{1});", WrapperID, ClientID);
            ////AddAbsoluteStartupScript( addToPageScript);

            //AddAbsoluteStartupScript( String.Format("if(X.{0}){{Ext.get('{1}').dom.innerHTML=String(X.{0});}}", ClientID, WrapperID));


            #endregion

            // <embed height="162" align="middle" width="510" type="application/x-shockwave-flash" pluginspage="http://www.adobe.com/go/getflashplayer"
            // allowscriptaccess="sameDomain" name="UploadApp" bgcolor="#F4F7FC" flashvars="url=http://localhost/ICSWeb//CommonPages/UploadFile.aspx&amp;ShowAddBtn=true&amp;ShowDelBtn=true&amp;SystemName=费用报销&amp;RecordID=24135572-dcd7-4a24-8981-6e202d380518&amp;AttributeName=属性&amp;DownloadUrl=http://localhost/ICSWeb//CommonPages/DownloadFile.aspx&amp;Columns=Size,ShortDate&amp;FileType=&amp;FileSize=10000000" 
            // wmode="transparent" quality="high" src="../App_Flash/UploadApp.swf"/>



        }

        #endregion

        #region public methods

        public void SetParam(string key, string value)
        {
            FlashParam param = GetParam(key);

            if (param == null)
            {
                Params.Add(new FlashParam(key, value));
            }
            else
            {
                param.ParamValue = value;
            }
        }

        public bool ContainParam(string key)
        {
            foreach (FlashParam param in Params)
            {
                if (param.ParamKey == key)
                {
                    return true;
                }
            }

            return false;
        }

        public FlashParam GetParam(string key)
        {
            foreach (FlashParam param in Params)
            {
                if (param.ParamKey == key)
                {
                    return param;
                }
            }

            return null;
        }


        #endregion

        #region SaveViewState/LoadViewState/TrackViewState

        protected override object SaveViewState()
        {
            object[] states = new object[] 
            { 
                base.SaveViewState(), 
                ((IStateManager)Params).SaveViewState()
            };

            return states;
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState != null)
            {
                object[] states = (object[])savedState;

                base.LoadViewState(states[0]);

                ((IStateManager)Params).LoadViewState(states[1]);
            }
        }

        protected override void TrackViewState()
        {
            base.TrackViewState();

            ((IStateManager)Params).TrackViewState();

        }

        #endregion
    }
}
