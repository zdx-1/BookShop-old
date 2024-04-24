<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserLoginNavigator.ascx.cs"
    Inherits="Controls_UserLoginNavigator" %>
<asp:Image ID="Image2" runat="server" ImageUrl="~/MemberPortal/image/top-gwc.gif" />
<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MemberPortal/ShoppingCart.aspx"
    CssClass="A1">购物车</asp:HyperLink>
|
<asp:HyperLink ID="HyperLink2" runat="server" Text="帮助" NavigateUrl="~/MemberPortal/Helper.aspx"
    CssClass="A1"></asp:HyperLink>
|
<asp:HyperLink ID="hlRegister" runat="server" Text="新用户注册" NavigateUrl="~/MemberPortal/UserRegister.aspx"
    CssClass="A1"></asp:HyperLink>
|
<asp:HyperLink ID="hlLogin" runat="server" Text="登录" NavigateUrl="~/MemberPortal/UserLogin.aspx"
    CssClass="A1"></asp:HyperLink>
|
<asp:HyperLink ID="hlPassword" runat="server" Text="修改密码" NavigateUrl="~/MemberPortal/ModifyPassword.aspx"
    CssClass="A1"></asp:HyperLink>
<asp:HyperLink ID="hla" runat="server" Text="|" Visible="false" NavigateUrl="~/MemberPortal/UserLogin.aspx"
    CssClass="A1"></asp:HyperLink>
<asp:LinkButton ID="hlClear" runat="server" OnClick="hlClear_Click">注销</asp:LinkButton>