<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LoginControl.ascx.cs"
    Inherits="Controls_LoginControl" %>
<div class="login-right">
    <div class="login-top">
    </div>
    <div class="login-mid">
        <div class="notice">
            <asp:Label runat="server" Text="用户登录" ID="lblMessage" /></div>
        <div class="main">
            <asp:Panel ID="pnlOne" runat="server">
                <div class="login-main">
                    <table cellpadding="0" style="width: 99%">
                        <tr>
                            <td style="width: 60px;">
                                Email地址或昵称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtLoginId" runat="server" CssClass="login-input" MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*请输入用户名"
                                    ControlToValidate="txtLoginId" ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                密码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtLoginPwd" runat="server" CssClass="login-input" TextMode="Password"
                                    MaxLength="20"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*请输入密码"
                                    ControlToValidate="txtLoginPwd" Text="" ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" style="width: 200px">
                        <tr>
                            <asp:CheckBox ID="cbTime" Text="两周内自动登录" runat="server" />
                        </tr>
                    </table>
                    <table cellpadding="0" style="width: 200px">
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnLogin" runat="server" class="submit" OnClick="btnLogin_Click"
                                    Style="height: 26px" Text="登录" />
                                &nbsp;<a href="#">忘记密码</a>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="login-end">
                    您还不是当当网用户？</div>
                <div align="right">
                    <a href="UserRegister.aspx">创建一个新用户</a>&nbsp;&nbsp;</div>
                <br />
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
        <div class="login-bottom">
        </div>
    </div>
</div>
