<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    AutoEventWireup="true" CodeFile="UserRegister.aspx.cs" Inherits="AdminPlatform_UserRegister" %>

<%@ Register Assembly="Great.Control" Namespace="Great.Control" TagPrefix="cc1" %>
<%@ Register Assembly="DateTextBox" Namespace="Titan.WebForm" TagPrefix="TW" %>
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
        .style1
        {
            width: 18px;
        }
        .style2
        {
            border-bottom: 1 #CCCCCC solid;
            padding-left: 10px;
            text-align: left;
            width: 477px;
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
            注册步骤: <font color="#FF1100">1.填写信息（均为必填项）</font> > 2.验证邮箱 > 3.注册成功</font></div>
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
                                    请填写您的用户名：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtId" runat="server" CssClass="login-input" ValidationGroup="Select"
                                        Width="160px" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*必填"
                                        ValidationGroup="Select" ControlToValidate="txtId" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:Button ID="btnSelect" runat="server" Text="检验" CssClass="login-input" class="submit"
                                        ValidationGroup="Select" Width="75px" Height="21px" OnClick="btnSelect_Click" />
                                    <asp:Label ID="lblMessages" Visible="false" runat="server" Text="Label"></asp:Label>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*必填"
                                        ControlToValidate="txtId" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="*用户名不符合规范"
                                        ControlToValidate="txtId" ValidationExpression="^[\u4E00-\u9FA5A-Za-z0-9]{4,20}"
                                        ForeColor="red"></asp:RegularExpressionValidator>
                                    <td class="border-rb">
                                        您的用户名可以由小写英文字母、中文、数字组成，长度4－20个字符。
                                    </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    您的真实姓名：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="login-input" Width="160px" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*必填"
                                        ControlToValidate="txtName" ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="border-rb">
                                    请如实填写您的真实姓名。
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    设置密码：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="login-input" TextMode="Password"
                                        Width="160px" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*必填"
                                        ControlToValidate="txtPassword" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtPassword"
                                        runat="server" ErrorMessage="*密码不规范" ForeColor="Red" ValidationExpression="^\S{6,20}$"></asp:RegularExpressionValidator>
                                </td>
                                <td class="border-rb">
                                    您的密码可以由除空格以外任意字符组成，长度6-20个字符。
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    再次输入您设置的密码：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtAgainPassword" runat="server" CssClass="login-input" TextMode="Password"
                                        Width="160px" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*必填"
                                        ControlToValidate="txtAgainPassword" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*两次密码输入不同"
                                        ControlToValidate="txtAgainPassword" Type="String" ControlToCompare="txtPassword"
                                        ForeColor="red"></asp:CompareValidator>
                                </td>
                                <td class="border-rb">
                                    请再次输入您设置的密码，并确保两次密码一致。
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    性别：
                                </td>
                                <td class="style2">
                                    <asp:RadioButton ID="rdoMail" runat="server" Text="男" GroupName="RadioButton" />
                                    <asp:RadioButton ID="rdoFemail" runat="server" Text="女" GroupName="RadioButton" />
                                </td>
                                <td class="border-rb">
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    出生年月：
                                </td>
                                <td class="style2">
                                    <TW:DateTextBox ID="dtbBrithday" runat="server" Width="66px"></TW:DateTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*必填"
                                        ControlToValidate="dtbBrithday" ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="border-rb">
                                    请选择至少五年前，格式：1990-6-6
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    学历/学位：
                                </td>
                                <td class="style2">
                                    <asp:DropDownList ID="ddlDegree" runat="server">
                                        <asp:ListItem Value="=请选择=">=请选择=</asp:ListItem>
                                        <asp:ListItem>博士</asp:ListItem>
                                        <asp:ListItem>硕士</asp:ListItem>
                                        <asp:ListItem>本科</asp:ListItem>
                                        <asp:ListItem>大专</asp:ListItem>
                                        <asp:ListItem>高中</asp:ListItem>
                                        <asp:ListItem>初中</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="style1">
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    联系电话：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="login-input" Width="160px" MaxLength="20"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator4" runat="server" ErrorMessage="*必填" ControlToValidate="txtPhone"
                                        ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="*联系电话填写不规范"
                                        ControlToValidate="txtPhone" ForeColor="red" ValidationExpression="^(\d{11})|(((\d{4})|(\d{4}-))?\d{8})$"></asp:RegularExpressionValidator>
                                </td>
                                <td class="border-rb">
                                    请填写有效的联系电话，以获得有效购物服务。
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    Email：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtEmail" runat="server" ValidationGroup="Select" CssClass="login-input"
                                        Width="160px" MaxLength="20"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="*必填"
                                        ValidationGroup="Select" ControlToValidate="txtEmail" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*必填"
                                        ControlToValidate="txtEmail" ForeColor="red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="*Email填写不规范"
                                        ControlToValidate="txtEmail" ForeColor="red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"></asp:RegularExpressionValidator>
                                </td>
                                <td class="border-rb">
                                    请填写有效的Email地址，在下一步中您将用此邮箱接收验证邮件。
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    联系地址：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtAddress" runat="server" CssClass="login-input" Width="160px"
                                        MaxLength="40"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                            runat="server" ErrorMessage="*必填" ControlToValidate="txtAddress" ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="border-rb">
                                    请填写有效的联系地址，此地址主要作为商品配送联系地址。
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    个人描述：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtPersonDescribe" runat="server" Height="97px" TextMode="MultiLine"
                                        Width="160px"></asp:TextBox>
                                </td>
                                <td class="border-rb">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    从何处了解到本网站：
                                </td>
                                <td class="style2">
                                    <asp:CheckBoxList ID="cbOrigin" runat="server">
                                        <asp:ListItem>朋友推荐</asp:ListItem>
                                        <asp:ListItem>网络广告、媒体</asp:ListItem>
                                        <asp:ListItem>网上链接</asp:ListItem>
                                        <asp:ListItem>报纸、电视等媒体</asp:ListItem>
                                        <asp:ListItem>其他</asp:ListItem>
                                    </asp:CheckBoxList>
                                </td>
                                <td class="border-rb">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    验证码：
                                </td>
                                <td class="style2">
                                    <asp:TextBox ID="txtValidator" runat="server" MaxLength="8"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="*验证码错误"
                                        ControlToValidate="txtValidator" ForeColor="red"></asp:CompareValidator>
                                </td>
                                <td class="border-rb">
                                </td>
                            </tr>
                            <tr>
                                <td class="border-rb1">
                                    &nbsp;
                                </td>
                                <td class="style2">
                                    <cc1:GreatValidateCode ID="gvcCheckCode" runat="server" />
                                    <asp:HyperLink ID="HyperLink7" runat="server">看不清，换一个...</asp:HyperLink>
                                </td>
                                <td class="border-rb">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" height="40" align="center">
                                    <asp:Button ID="btnRegister" runat="server" Text="确认注册" class="submit" OnClick="btnRegister_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    你填写的信息：
                                </td>
                                <td colspan="2">
                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List"
                                        ForeColor="red" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
