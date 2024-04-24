<%@ Page Title="" Language="C#" MasterPageFile="~/MemberPortal/MainSite.master" AutoEventWireup="true"
    CodeFile="ModifyPassword.aspx.cs" Inherits="MemberPortal_ModifyPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        td.border-rb1
        {
            width: 180px;
            padding: 3px 10px 3px 15px;
        }
        td.border-rb
        {
            width: 381px;
        }
        .style2
        {
            border-bottom: 1 #CCCCCC solid;
            padding-left: 10px;
            text-align: left;
            width: 291px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <div class="middle">
            <div align="center">
                <table width="983" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="7" height="27">
                        </td>
                        <td>
                            <hr color="#8ab6db" size="1" align="center" width="98%" />
                        </td>
                        <td width="7">
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div align="center" style="padding-top: 10px; font-size: 14px;">
            修改步骤: <font color="#FF1100">1.使用原用户名、密码登录</font> > 2.输入旧密码、新密码 > 3.修改成功</font></div>
        <div>
            <table width="950" border="0" cellspacing="0" cellpadding="0" align="center">
                <tr>
                    <td style="font-size: 14px; color: #ff0000; font-weight: bold;" height="30">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td style="border: 1 #CCCCCC solid;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="border-rb1">
                                    您的用户名：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtId" runat="server" CssClass="login-input" Width="160px" ValidationGroup="Select"
                                        ReadOnly="True" MaxLength="30"></asp:TextBox>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    原密码：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" Width="160px"
                                        TextMode="Password" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*必填"
                                        ControlToValidate="txtPassword" ForeColor="red"></asp:RequiredFieldValidator>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    设置新密码：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtNewPassword" runat="server" CssClass="login-input" Width="160px"
                                        TextMode="Password" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*必填"
                                        ControlToValidate="txtNewPassword" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtNewPassword"
                                        runat="server" ErrorMessage="*密码不规范" ForeColor="Red" ValidationExpression="^\S{6,20}$"></asp:RegularExpressionValidator>
                                    <td class="border-rb">
                                        您的密码可以由除空格以外任意字符组成，长度6-20个字符。
                                    </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    再次输入您设置的新密码：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtAgainNewPassword" runat="server" CssClass="login-input" Width="160px"
                                        TextMode="Password" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*必填"
                                        ControlToValidate="txtAgainNewPassword" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*两次输入不一致"
                                        ControlToValidate="txtAgainNewPassword" ControlToCompare="txtNewPassword" ForeColor="Red"></asp:CompareValidator>
                                    <td class="border-rb">
                                        两次输入一致。
                                    </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" height="40" align="center">
                                    <asp:Button ID="btnRegister" runat="server" Text="确认修改" class="submit" OnClick="btnRegister_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
