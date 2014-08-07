<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JN.MIS._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>江南造船-管理平台</title>    
    <link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />
    <link href="Styles/Default.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/Default.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" HideScrollbar="true" runat="server"></ext:PageManager>
    <ext:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <ext:Region ID="Region1" Margins="0 0 0 0" Height="62px" ShowBorder="false" ShowHeader="false"
                Position="Top" Layout="Fit" runat="server">
                <Toolbars>
                    <ext:Toolbar ID="Toolbar1" Position="Bottom" runat="server">
                        <Items>
                            <ext:ToolbarText ID="ToolbarText1" Text="&nbsp;" runat="server">
                            </ext:ToolbarText>
                            <ext:Button ID="btnExpandAll" IconUrl="~/images/expand-all.gif" Text="展开&nbsp;"
                                EnablePostBack="false" runat="server">
                            </ext:Button>
                            <ext:Button ID="btnCollapseAll" IconUrl="~/images/collapse-all.gif" Text="收拢&nbsp;"
                                EnablePostBack="false" runat="server">
                            </ext:Button>
                            <ext:Button ID="btnHello" IconUrl="~/images/collapse-all.gif" Text="测试&nbsp;"
                                EnablePostBack="false" runat="server">
                            </ext:Button>
                            <ext:ToolbarFill ID="ToolbarFill1" runat="server">
                            </ext:ToolbarFill>
                            <ext:ToolbarText ID="ToolbarText4" Text="" runat="server">
                            </ext:ToolbarText>
                            <ext:ToolbarText ID="ToolbarText3" Text="" runat="server">
                            </ext:ToolbarText>
                            <ext:ToolbarText ID="ToolbarText2" Text="&nbsp;" runat="server">
                            </ext:ToolbarText>
                            <ext:Button ID="Exit" Text="退出系统" runat="server" ConfirmTarget="Top" ConfirmText="你真的要退出系统吗？" ConfirmIcon="Question" Icon="ApplicationOsxHome" EnablePostBack="true" OnClick="Exit_Click"></ext:Button>
                        </Items>
                    </ext:Toolbar>
                </Toolbars>
                <Items>
                    <ext:ContentPanel ShowBorder="false" CssClass="header" ShowHeader="false" BodyStyle="background-color:#1C3E7E;"
                        ID="ContentPanel2" runat="server">
                        <div class="title">
                            <a href="./default.aspx" style="color:#fff;">江南造船信息管理系统</a>
                        </div>
						<div class="version">
                            <font style="color:#fff;">测试版 V1.0</font>
                        </div>
                    </ext:ContentPanel>
                </Items>
            </ext:Region>
            <ext:Region ID="Region2" Split="true" EnableSplitTip="true" CollapseMode="Mini" Width="200px"
                Margins="0 0 0 0" ShowHeader="true" Title="功能菜单" Icon="Outline" EnableCollapse="true"
                Layout="Fit" Position="Left" runat="server">
                <Items>
                    <ext:Tree runat="server" EnableArrows="true" ShowBorder="false" ShowHeader="false"  
                        AutoScroll="true" ID="treeMenu">
                    </ext:Tree>
                </Items>
            </ext:Region>
            <ext:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                runat="server">
                <Items>
                    <ext:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                        <Tabs>
                            <ext:Tab ID="Tab1" Title="我的桌面" Layout="Fit" Icon="House" runat="server">
                                <Toolbars>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:ToolbarFill ID="ToolbarFill2" runat="server">
                                            </ext:ToolbarFill>

                                            <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                            </ext:ToolbarSeparator>
  
                                        </Items>
                                    </ext:Toolbar>
                                </Toolbars>
                                <Items>
                                    <ext:ContentPanel ID="ContentPanel1" ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                        CssClass="intro" runat="server">

                                    </ext:ContentPanel>
                                </Items>
                            </ext:Tab>
                        </Tabs>
                    </ext:TabStrip>
                </Items>
            </ext:Region>
        </Regions>
    </ext:RegionPanel>
    <ext:Window ID="windowSourceCode" Title="Source Code" Popup="false" EnableIFrame="true"
        runat="server" IsModal="true" Width="900px" Height="550px" EnableClose="true"
        EnableMaximize="true">
    </ext:Window>
    </form>
    <script type="text/javascript" src="Scripts/Default.js"></script>
</body>
</html>

