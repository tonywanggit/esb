<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="JN.MIS.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>江南造船-管理平台</title>
</head>
<body>
    <form id="form1" runat="server">
    <ext:PageManager ID="PageManager1" runat="server" />
    <ext:Window ID="Window1" runat="server" Title="登陆到管理平台" IsModal="false" EnableClose="false"
        Width="350px" EnableDrag="True" WindowPosition="GoldenSection">
        <Items>
            <ext:SimpleForm ID="SimpleForm1" runat="server" ShowBorder="false" BodyPadding="10px" EnableBackgroundColor="true" ShowHeader="false">
                <Items>
                    <ext:TextBox ID="UserName" Label="用户名" Required="true" runat="server"></ext:TextBox>
                    <ext:TextBox ID="Password" Label="密码" TextMode="Password" Required="true" runat="server"></ext:TextBox>
                    <ext:TextBox ID="tbxCaptcha" Label="验证码" Required="true" runat="server"></ext:TextBox>
                    <ext:Image ID="imgCaptcha" runat="server" ImageUrl="captcha.ashx?w=207&h=30" ToolTip="看不清楚，换一张" ShowLabel="true"></ext:Image>
                    <ext:LinkButton ID="LinkButton3" Label="" Text="看不清楚，换一张" EnablePostBack="true" runat="server" OnClick="LinkButton3_Click"></ext:LinkButton>
                    <ext:Button ID="btnLogin" Text="登陆" Type="Submit" ValidateForms="SimpleForm1" ValidateTarget="Top" runat="server" OnClick="btnLogin_Click"></ext:Button>
                </Items>
            </ext:SimpleForm>
        </Items>
    </ext:Window>
    </form>
    <script type="text/javascript">
        function onReady() {
            var txtUserName = Ext.getCmp("<%= UserName.ClientID%>");
            txtUserName.focus(true, true);
        }
    </script>
</body>
</html>