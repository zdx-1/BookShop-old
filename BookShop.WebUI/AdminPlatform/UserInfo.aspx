<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPlatform/AdminPlatform.master"
    AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="AdminPlatform_UserInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        td.border-rb1
        {
            width: 120px;
            padding: 10px 10px 10px 25px;
            background-color: #D3EAF3;
            font-size: 20px;
            text-align: left;
            vertical-align: middle;
            float: left;
        }
        td.border-rb
        {
            width: 381px;
        }
        .style2
        {
            border-bottom: 1 #CCCCCC solid;
            padding-left: 15px;
            width: 477px;
            font-size: 20px;
            text-align: left;
            vertical-align: middle;
            float: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <asp:DataList ID="dlsUserInfoList" runat="server" RepeatColumns="1">
            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" HorizontalAlign="Center" VerticalAlign="Middle" />
            <ItemTemplate>
                <table width="950" style="margin-left: 25px" border="0" cellspacing="0" cellpadding="0"
                    align="center">
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
                                        用户名：
                                    </td>
                                    <td class="style2">
                                        <asp:Label ID="lblLoginId" runat="server" Text='<%#Eval("LoginId") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="border-rb1">
                                        用户级别：
                                    </td>
                                    <td class="style2">
                                        <asp:Label ID="lblUserRolesName" runat="server" Text='<%#Eval("UserRoles.Name") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="border-rb1">
                                        姓名：
                                    </td>
                                    <td class="style2">
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="border-rb1">
                                        联系地址：
                                    </td>
                                    <td class="style2">
                                        <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="border-rb1">
                                        联系方式：
                                    </td>
                                    <td class="style2">
                                        <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="border-rb1">
                                        E-Mail：
                                    </td>
                                    <td class="style2">
                                        <asp:Label ID="lblMail" runat="server" Text='<%#Eval("Mail") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="border-rb1">
                                        注册时间：
                                    </td>
                                    <td class="style2">
                                        <asp:Label ID="lblRegDate" runat="server" Text='<%#Eval("RegDate") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
