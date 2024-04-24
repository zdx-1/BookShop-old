<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminPlatform_AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户登录</title>
    <link href="images/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="login">
        <div id="top">
            <div id="top_left">
                <img src="images/login_03.gif" /></div>
            <div id="top_center">
                <img src="images/login_05.gif" /></div>
        </div>
        <div id="center">
            <div id="center_left">
                <img src="images/login_09.gif" />
            </div>
            <div id="center_middle">
                <table style="margin-left: 40px;">
                    <tr>
                        <td>
                            用&nbsp;&nbsp;户&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtID" runat="server" Width="120px"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtID"
                                ErrorMessage="*请输入用户名" ForeColor="red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lblShow1" runat="server" Text="" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密&nbsp;&nbsp;码&nbsp;
                        </td>
                        <td>
                            <asp:TextBox ID="txtPassword" runat="server" Width="120px" TextMode="Password"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="red" ControlToValidate="txtPassword"
                                runat="server" ErrorMessage="*请输入密码"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Label ID="lblShow2" runat="server" Text="" ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="btnarea">
                    <asp:Button ID="btnOk" runat="server" Text="登 录" OnClick="btnOk_Click" Font-Size="12px"
                        Height="20px" Width="50px" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" Text="重 置" OnClick="btnClear_Click" Font-Size="12px"
                        Height="20px" Width="50px" />
                </div>
            </div>
            <div id="center_right">
            </div>
        </div>
        <div id="down">
            <div id="down_left">
                <div id="inf">
                    <span class="inf_text">版本信息</span> <span class="copyright">网上书店 2009-2012 v1.0<asp:Literal
                        ID="ltMessage" runat="server"></asp:Literal>
                    </span>&nbsp;</div>
            </div>
            <div id="down_center">
                <img src="images/login_16.gif" /></div>
        </div>
    </div>
    </form>
</body>
</html>
