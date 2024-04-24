<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserLogin.ascx.cs" Inherits="Controls_UserLogin" %>
<div id="left-top">
    <table width="100%" border="0" style="text-align:center" cellspacing="0" cellpadding="0">
        <tr>
            <td width="6">
                <img src="./MemberPortal/image/index-bg-left.gif">
            </td>
            <td class="booktype-headerbg">
                <span class="white-13">用户登录</span>
            </td>
            <td width="6">
                <img src="./MemberPortal/image/index-bg-right.gif">
            </td>
        </tr>
    </table>
</div>
<div id="left-middle2" style="width: 99%" class="border-lr">
    <asp:Panel ID="pnlOne" runat="server">
        <div id="rightlist" class="border-lr" style="text-align: left">
            Email地址或昵称：<br />
            <asp:TextBox ID="txtLoginId" runat="server"></asp:TextBox><br />
            密码：<br />
            <asp:TextBox ID="txtLoginPwd" runat="server" TextMode="Password"></asp:TextBox><br />
            <br />
            <asp:Label runat="server" ID="lblMessage" ForeColor="Gray"></asp:Label>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" /><br />
            <br />
            您还不是叮当网用户？<br />
            <br />
            <a href="MemberPortal/UserRegister.aspx" target="_blank">创建一个新用户>></a>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlTwo" runat="server">
        <table>
            <tr>
                <td>
                    欢迎：
                </td>
                <td>
                    <asp:Label ID="lblGreet" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    登录日期：
                </td>
                <td>
                    <asp:Label ID="lblBrithday" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    登录IP：
                </td>
                <td>
                    <asp:Label ID="lblIP" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" class="submit" Style="height: 26px" Text="注销"
                        OnClick="Button1_Click" />
            </tr>
        </table>
    </asp:Panel>
</div>
<div id="left-end2">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td width="7" height="6">
                <img src="./MemberPortal/image/index-end-left.gif">
            </td>
            <td class="bottom">
                &nbsp;&nbsp;&nbsp;
            </td>
            <td width="7">
                <img src="./MemberPortal/image/index-end-right.gif">
            </td>
        </tr>
    </table>
</div>
